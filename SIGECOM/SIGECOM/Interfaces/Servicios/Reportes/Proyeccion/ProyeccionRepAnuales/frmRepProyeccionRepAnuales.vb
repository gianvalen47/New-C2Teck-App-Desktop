Imports System.ServiceModel

Public Class frmRepProyeccionRepAnuales

    Private oHorasMotorService As New HorasMotorService.HorasMotorServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Dim forma As New frmReportes
    Private dtTipoPlanMantenimiento As DataTable
    Private dtDatos As DataTable
    Private dtDatosResumen As DataTable
    Private dtUbicacion As DataTable

    Private Sub frmRepProyeccionRepAnuales_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oHorasMotorService.Close()
            oJobService.close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oHorasMotorService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oHorasMotorService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRepProyeccionRepAnuales_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepProyeccionRepAnuales_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        llenarCombos()
        cmbAnio.Value = Today.Year
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Try

            oSeguridadService.RegistrarVisitaOpciones(275, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            Dim reporte As New rptProyeccionRepAnuales

            Dim nomantenimiento As String
            If cbnow3.Checked Then
                nomantenimiento = "103"
            Else
                nomantenimiento = ""
            End If

            dtDatos = oHorasMotorService.ReporteProyeccionReparacion(Session.sCodEmp, utils.toNumber(cmbAnio.Value), utils.toBlank(cmbUbicacion.Value), utils.toNumber(cmbTipoPlanMant.Value), nomantenimiento, cbMostrarSoloPendientes.Checked).Tables(0)
            dtDatosResumen = oHorasMotorService.ReporteProyeccionReparacionResumen(Session.sCodEmp, utils.toNumber(cmbAnio.Value), utils.toBlank(cmbUbicacion.Value), utils.toNumber(cmbTipoPlanMant.Value), nomantenimiento, cbMostrarSoloPendientes.Checked).Tables(0)

            'DataGridView1.DataSource = dtDatos

            If reporte.Subreports.Count > 0 Then
                reporte.Subreports(0).SetDataSource(dtDatosResumen)
            End If

            If dtDatos.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtDatos)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.Text = "Reporte de Proyección de Reparaciones Anuales"
                reporte.SetParameterValue("DesUbicacion", cmbUbicacion.Text)
                reporte.SetParameterValue("TipoPlanMant", cmbTipoPlanMant.Text)
                reporte.SetParameterValue("Anio", cmbAnio.Value)
                'reporte.SetParameterValue("ModeloEquipo", cmbModeloEquipo.Text)
                'reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox("Error al llenar los combos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub llenarCombos()
        Try

            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '================================= TIPO PLAN MANTENIMIENTO =======================================
            dtTipoPlanMantenimiento = oHorasMotorService.MostrarTipoPlanMantenimiento().Tables(0)
            dtTipoPlanMantenimiento.Rows.InsertAt(getRowTodos(dtTipoPlanMantenimiento), 0)
            cmbTipoPlanMant.DataSource = dtTipoPlanMantenimiento
            cmbTipoPlanMant.DropDownList.DataMember = dtTipoPlanMantenimiento.Columns("DesPlan").ToString
            cmbTipoPlanMant.DropDownList.DisplayMember = dtTipoPlanMantenimiento.Columns("DesPlan").ToString
            cmbTipoPlanMant.DropDownList.ValueMember = dtTipoPlanMantenimiento.Columns("IdPlan").ToString
            cmbTipoPlanMant.DropDownList.Columns(0).DataMember = dtTipoPlanMantenimiento.Columns("IdPlan").ToString
            cmbTipoPlanMant.DropDownList.Columns(1).DataMember = dtTipoPlanMantenimiento.Columns("DesPlan").ToString
            cmbTipoPlanMant.SelectedIndex = 0
            dtTipoPlanMantenimiento = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
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
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

End Class