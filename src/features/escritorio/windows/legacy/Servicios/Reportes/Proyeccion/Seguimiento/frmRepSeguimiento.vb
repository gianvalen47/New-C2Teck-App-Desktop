Imports System.ServiceModel

Public Class frmRepSeguimiento

    '=========================== Servicios ====================================
    Private oSeguimientoService As New SeguimientoService.SeguimientoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private dtOficinas As DataTable
    Private dtSisMot As DataTable
    Private dtTipSeg As DataTable
    Private dtProSeg As DataTable
    Private dtSupervisor As DataTable

    Private Sub frmRepSeguimiento_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSeguimientoService.Close()
            oMaestroService.Close()
            oJobService.Close()
            oSeguridadService.Close()
            oCotizacionServicioService.close()
        Catch ex As TimeoutException
            oSeguimientoService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
            oCotizacionServicioService.abort()
        Catch ex As CommunicationException
            oSeguimientoService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
            oCotizacionServicioService.abort()
        End Try
    End Sub

    Private Sub frmRepSeguimiento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepSeguimiento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        LlenarCombo()

    End Sub

    Private Sub LlenarCombo()

        Try

            '====================================== OFICINAS ============================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            'dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '======================================= SUPERVISOR =============================================
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("AbrPer").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("AbrPer").ToString
            'cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

            '================================= SISTEMAS MOTOR ====================================
            dtSisMot = oSeguimientoService.MostrarSistemaMotor.Tables(0)
            dtSisMot.Rows.InsertAt(getRowTodos(dtSisMot), 0)
            cmbSistemasMotor.DataSource = dtSisMot
            cmbSistemasMotor.DropDownList.DataMember = dtSisMot.Columns("DesSistema").ToString
            cmbSistemasMotor.DropDownList.DisplayMember = dtSisMot.Columns("DesSistema").ToString
            cmbSistemasMotor.DropDownList.ValueMember = dtSisMot.Columns("IdSistema").ToString
            cmbSistemasMotor.DropDownList.Columns(0).DataMember = dtSisMot.Columns("IdSistema").ToString
            cmbSistemasMotor.DropDownList.Columns(1).DataMember = dtSisMot.Columns("DesSistema").ToString
            cmbSistemasMotor.SelectedIndex = 0
            dtSisMot = Nothing

            '================================= TIPO SEGUIMIENTO ===================================
            dtTipSeg = oSeguimientoService.MostrarTipoSeguimiento.Tables(0)
            dtTipSeg.Rows.InsertAt(getRowTodos(dtTipSeg), 0)
            cmbTipoSeguimiento.DataSource = dtTipSeg
            cmbTipoSeguimiento.DropDownList.DataMember = dtTipSeg.Columns("DesTipo").ToString
            cmbTipoSeguimiento.DropDownList.DisplayMember = dtTipSeg.Columns("DesTipo").ToString
            cmbTipoSeguimiento.DropDownList.ValueMember = dtTipSeg.Columns("IdTipo").ToString
            cmbTipoSeguimiento.DropDownList.Columns(0).DataMember = dtTipSeg.Columns("IdTipo").ToString
            cmbTipoSeguimiento.DropDownList.Columns(1).DataMember = dtTipSeg.Columns("DesTipo").ToString
            cmbTipoSeguimiento.SelectedIndex = 0
            dtTipSeg = Nothing

            '=============================== PROCESO SEGUIMIENTO =================================
            dtProSeg = oSeguimientoService.MostrarProcesoSeguimiento.Tables(0)
            dtProSeg.Rows.InsertAt(getRowTodos(dtProSeg), 0)
            cmbProceso.DataSource = dtProSeg
            cmbProceso.DropDownList.DataMember = dtProSeg.Columns("DesProceso").ToString
            cmbProceso.DropDownList.DisplayMember = dtProSeg.Columns("DesProceso").ToString
            cmbProceso.DropDownList.ValueMember = dtProSeg.Columns("IdProceso").ToString
            cmbProceso.DropDownList.Columns(0).DataMember = dtProSeg.Columns("IdProceso").ToString
            cmbProceso.DropDownList.Columns(1).DataMember = dtProSeg.Columns("DesProceso").ToString
            cmbProceso.SelectedIndex = 0
            dtProSeg = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
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


    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click


        Try
            Dim forma As New frmReportes
            Dim reporte As New rptrRepSeguimiento

            Dim dtDatos As DataTable

            oSeguridadService.RegistrarVisitaOpciones(261, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            dtDatos = oSeguimientoService.Reporte(Session.sCodEmp, cmbOficinas.Value, cbFecInicio.Value, cbFecFinal.Value, utils.toNumber(cmbTipoSeguimiento.Value), utils.toNumber(cmbSistemasMotor.Value), utils.toNumber(cmbSupervisor.Value), utils.toBlank(txtNumSerie.Text), utils.toBlank(txtEquipo.Text), utils.toBlank(txtNumJob.Text), utils.toNumber(cmbProceso.Value)).Tables(0)

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
                'forma.crvReportes.RefreshReport = False

                reporte.SetParameterValue("Oficina", cmbOficinas.Text)
                reporte.SetParameterValue("TipoSeguimiento", cmbTipoSeguimiento.Text)
                reporte.SetParameterValue("SistemasMotor", cmbSistemasMotor.Text)
                reporte.SetParameterValue("Supervisor", IIf(cmbSupervisor.Text = "", "(Todos)", cmbSupervisor.Text))
                reporte.SetParameterValue("NumJob", IIf(txtNumJob.Text = "", "(Todos)", txtNumJob.Text))
                reporte.SetParameterValue("NumSerie", IIf(txtNumSerie.Text = "", "(Todos)", txtNumSerie.Text))
                reporte.SetParameterValue("Equipo", IIf(txtEquipo.Text = "", "(Todos)", txtEquipo.Text))
                reporte.SetParameterValue("ProcSeguimiento", IIf(cmbProceso.Text = "", "(Todos)", cmbProceso.Text))
                reporte.SetParameterValue("FecInicio", CDate(cbFecInicio.Value))
                reporte.SetParameterValue("FecFinal", CDate(cbFecFinal.Value))

                forma.Text = "Reporte de Seguimiento"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarJob_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarJob_Validated(sender As Object, e As System.EventArgs) Handles btnBuscarJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbSupervisor.Focus()
                End If
            Else
                cmbSupervisor.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub


End Class