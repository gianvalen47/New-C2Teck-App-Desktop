Imports System.Windows.Forms
Imports System.ServiceModel
Imports AxMSChart20Lib
Public Class frmProductividad_Persona

    '===========================Servicios====================================================
    Private oJobService As New JobService.JobServiceClient
    Private oMarcacionJobService As New MarcacionJobService.MarcacionJobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable

    Private Sub frmProductividad_Persona_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim estilo As New Estilo
            estilo.CargaEstiloGrid(dgvDatos)
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

            With txtFechaMensual
                .Format = DateTimePickerFormat.Custom
                .CustomFormat = "MM-yyyy"
            End With

            txtFechaMensual.Text = Today.Date

            'dtDatos = oJobService.ReporteIndicadores(Session.sCodEmp, txtFechaMensual.Value, txtFechaMensual.Value, 0, 0, "", 12, 0, 1).Tables(0)
            'dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox("Error al Cargar el Formulario. " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarMensual.Click, txtFechaMensual.ValueChanged
        Try
            dtDatos = oJobService.ReporteIndicadores(Session.sCodEmp, txtFechaMensual.Value, txtFechaMensual.Value, 0, 0, "", 12, 0, 1).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox("Error al Listar Datos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '==============================Evento KeyDown==============================================
    Private Sub frmAsignacionesRecursos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAsignacionesRecursos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oMarcacionJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oMarcacionJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oMarcacionJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub dgvDatos_FormattingRow(sender As Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles dgvDatos.FormattingRow

    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick

        If ValidaCodigoSeleccionado() Then
            'GraficoPie()
            Imprimir()
        End If

    End Sub

    Private Sub GraficoPie()

        If (dgvDatos.CurrentRow.Cells("TotHorPag").Value) >= dgvDatos.CurrentRow.Cells("TotHorMar").Value Then

            Dim frm As New frmProductividad_Persona_Porc
            frm.JobVen = Math.Round((dgvDatos.CurrentRow.Cells("JobVen").Value / dgvDatos.CurrentRow.Cells("TotHorPag").Value), 2) * 100
            frm.JobInt = Math.Round((dgvDatos.CurrentRow.Cells("JobInt").Value / dgvDatos.CurrentRow.Cells("TotHorPag").Value), 2) * 100
            frm.JobGar = Math.Round((dgvDatos.CurrentRow.Cells("JobGar").Value / dgvDatos.CurrentRow.Cells("TotHorPag").Value), 2) * 100
            frm.JobAse = Math.Round((dgvDatos.CurrentRow.Cells("JobAse").Value / dgvDatos.CurrentRow.Cells("TotHorPag").Value), 2) * 100
            frm.JobCap = Math.Round((dgvDatos.CurrentRow.Cells("JobCap").Value / dgvDatos.CurrentRow.Cells("TotHorPag").Value), 2) * 100
            frm.Diferencia = Math.Round((dgvDatos.CurrentRow.Cells("Diferencia").Value / dgvDatos.CurrentRow.Cells("TotHorPag").Value), 2) * 100
            frm.ShowDialog()

        End If
    End Sub

    Private Sub Imprimir()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptHorasGenerales
            Dim FechaInicio As Date
            Dim FechaFin As Date

            FechaInicio = CDate("01/" + utils.toBlank(Month(txtFechaMensual.Value)) + "/" + utils.toBlank(Year(txtFechaMensual.Value)))
            FechaFin = DateSerial(Year(txtFechaMensual.Value), (Month(txtFechaMensual.Value)) + 1, 0)
            'FechaFin = DateSerial(Year(Today), (Month(Today) - 1) + 1, 0)
            'FechaFin = Today

            dtReporte = oMarcacionJobService.Reporte(Session.sCodEmp, utils.toBlank(FechaInicio), utils.toBlank(FechaFin), "", "", 0, dgvDatos.CurrentRow.Cells("IdPer").Value).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                'Validar por usuario - Exportar Excel 
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.DisplayGroupTree = False

                'If txtSolicitante.Text = "" Then
                '    txtSolicitante.Text = "Todos"
                'End If
                reporte.SetParameterValue("pDesPer", dgvDatos.CurrentRow.Cells("Colaborador").Value)
                reporte.SetParameterValue("pFechaInicio", FechaInicio)
                reporte.SetParameterValue("pFechaFin", FechaFin)
                reporte.SetParameterValue("pTipo", "")
                reporte.SetParameterValue("pOficina", "")

                forma.Text = "Reporte de Horas Generales"

                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If ValidaCodigoSeleccionado() Then
            'GraficoPie()
            Imprimir()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGraficoProductividad_Click(sender As Object, e As EventArgs) Handles btnGraficoProductividad.Click
        If ValidaCodigoSeleccionado() Then
            GraficoPie()
        End If
    End Sub
End Class