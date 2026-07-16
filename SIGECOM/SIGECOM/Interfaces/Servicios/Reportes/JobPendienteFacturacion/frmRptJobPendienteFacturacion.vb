Imports System.ServiceModel

Public Class frmRptJobPendienteFacturacion

    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient

    Private dtOficinas As DataTable
    Private dtAnios As DataTable
    Private dtDatos As New DataTable
    Public IdCliente As Integer
    Private Tipo As Integer
    Private dtTipo As DataTable
    Private dtSupervisor As DataTable

    Private Sub frmRptJobPendienteFacturacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
            oCotizacionServicioService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oCotizacionServicioService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oCotizacionServicioService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRptJobPendienteFacturacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRptJobPendienteFacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 118)
        '/*************************************************************************************/

        txtFechaInicio.Value = CDate("01/01/" + utils.toBlank(Year(Today)))
        txtFechaFin.Value = Today()

        llenarCombos()

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

    Private Sub llenarCombos()
        Try

            '------------------------------- Oficinas --------------------------------------------
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbLocacion.DataSource = dtOficinas
            cmbLocacion.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbLocacion.SelectedIndex = 0

            '======================================= TIPO ================================================
            dtTipo = oJobService.MostrarTipo.Tables(0)
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbTipoJob.DataSource = dtTipo
            cmbTipoJob.DropDownList.DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipoJob.DropDownList.DisplayMember = dtTipo.Columns("DesTipo").ToString
            cmbTipoJob.DropDownList.ValueMember = dtTipo.Columns("IdTipoJob").ToString
            cmbTipoJob.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdTipoJob").ToString
            cmbTipoJob.DropDownList.Columns(1).DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipoJob.SelectedIndex = 0
            dtTipo = Nothing


            '------------------------------- Supervisor --------------------------------------------
            dtSupervisor = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisor.Rows.InsertAt(getRowTodos(dtSupervisor), 0)
            cmbSupervisor.DataSource = dtSupervisor
            cmbSupervisor.DropDownList.DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.DisplayMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.DropDownList.ValueMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(0).DataMember = dtSupervisor.Columns("IdPer").ToString
            cmbSupervisor.DropDownList.Columns(1).DataMember = dtSupervisor.Columns("ApeNom").ToString
            cmbSupervisor.SelectedIndex = 0
            dtSupervisor = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL CARGAR COMBOS : " + ex.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If chkCliente.Checked Then
            txtCliente.Text = ""
            IdCliente = 0
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                txtCliente.Text = frm.descripcion
                txtCliente.BackColor = System.Drawing.SystemColors.Control
                IdCliente = frm.codigo
                'Cliente = frm.descripcion

            End If
            txtCliente.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(118, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptPendienteFacturacion

            Dim DesCli As String
            Dim Anio As String
            Dim Oficina As String


            Dim CodOfi As String
            Dim CodCli As String

            If txtCliente.Text = "" Then
                DesCli = "Todos"
            Else
                DesCli = txtCliente.Text
            End If
            Anio = Year(txtFechaInicio.Value)
            'Oficina = cmbLocacion.Text

            If cmbLocacion.Text = "(Todos)" Then
                Oficina = "Todos"
            Else
                Oficina = cmbLocacion.Text
            End If

            'Datos para DataTable

            CodOfi = cmbLocacion.Value
            CodCli = IdCliente

            dtDatos = oJobService.ReportePendienteFacturacion(Session.sCodEmp, txtFechaInicio.Value, txtFechaFin.Value, CodOfi, utils.toNumber(CodCli), cmbSupervisor.Value, utils.toNumber(cmbTipoJob.Value), Tipo).Tables(0)

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
                'forma.crvReportes.DisplayGroupTree = False
                reporte.SetParameterValue("pAnio", Anio)
                reporte.SetParameterValue("fecinicio", txtFechaInicio.Value)
                reporte.SetParameterValue("fecfinal", txtFechaFin.Value)
                reporte.SetParameterValue("pDesCli", DesCli)
                reporte.SetParameterValue("pOficina", Oficina)
                reporte.SetParameterValue("pTipoJob", cmbTipoJob.Text)
                reporte.SetParameterValue("pSupervisor", cmbSupervisor.Text)
                If Tipo = 1 Then
                    forma.Text = "Reporte de OT Pendiente Facturación"
                    reporte.SetParameterValue("pCabecera", "Reporte de OTs Pendientes de Facturación")
                Else
                    forma.Text = "Reporte de OT Facturados"
                    reporte.SetParameterValue("pCabecera", "Reporte de OTs Facturados")
                End If

                forma.ShowDialog()

            End If


        Catch ex As Exception
            MsgBox("Error en el reporte : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

   
    Private Sub rbPendiente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPendiente.CheckedChanged, rbFacturado.CheckedChanged
        Try
            If rbPendiente.Checked = True Then
                Tipo = 1
            ElseIf rbFacturado.Checked = True Then
                Tipo = 2
            End If
        Catch ex As Exception
            MsgBox("Error en el Grupo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class