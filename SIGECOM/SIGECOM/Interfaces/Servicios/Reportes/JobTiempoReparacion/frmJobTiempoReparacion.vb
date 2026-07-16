Imports System.ServiceModel

Public Class frmJobTiempoReparacion

    Private oJobservices As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private dtEstado As DataTable

    Private Sub frmJobTiempoReparacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobservices.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oJobservices.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oJobservices.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmJobTiempoReparacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJobTiempoReparacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 119)
        '/*************************************************************************************/

        txtFechaInicio.Value = CDate("01/01/" + utils.toBlank(Year(Today)))
        txtFechaFin.Value = Today()
        llenarCombos()
    End Sub

    Private Sub llenarCombos()

        Try
            '======================================= ESTADOS ================================================
            dtEstado = oJobservices.MostrarEstados.Tables(0)
            dtEstado.Rows.InsertAt(getRowTodos(dtEstado), 0)
            cmbEstado.DataSource = dtEstado
            cmbEstado.DropDownList.DataMember = dtEstado.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstado.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstado.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstado.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstado.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstado = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try

    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception

        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try

        Try
            fila(2) = "(Todos)"
        Catch ex As Exception

        End Try

        Try
            fila(5) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(119, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub MostrarReporte()

        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptJobTiempoReparacion

            If utils.toBlank(txtFechaInicio.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Inicio")
            ElseIf utils.toBlank(txtFechaFin.Text) = "" Then
                MsgBox("Debe ingresar la Fecha de Termino")
            Else

                Dim FecInicio As Date
                Dim FecFinal As Date
                Dim CodEstado As String

                FecInicio = txtFechaInicio.Text
                FecFinal = txtFechaFin.Text
                If cmbEstado.Text = "(Todos)" Then
                    CodEstado = 0
                Else
                    CodEstado = cmbEstado.Value
                End If

                dtDatos = oJobservices.ReporteTiempoReparacion(Session.sCodEmp, FecInicio, FecFinal, utils.toNumber(CodEstado)).Tables(0)

                If dtDatos.Rows.Count <= 0 Then
                    MsgBox("No hay Datos a mostrar en este reporte")
                Else
                    reporte.SetDataSource(dtDatos)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    reporte.SetParameterValue("pFechaIni", FecInicio)
                    reporte.SetParameterValue("pFechaFin", FecFinal)
                    reporte.SetParameterValue("pEstado", IIf(cmbEstado.Text = "(Todos)", "(Todos)", cmbEstado.Text))

                    forma.Text = "Reporte de Tiempo de Reparación OT"

                    forma.ShowDialog()

                End If

            End If
        Catch ex As Exception
            MsgBox("Error en el reporte : " + ex.Message)
        End Try

    End Sub

End Class