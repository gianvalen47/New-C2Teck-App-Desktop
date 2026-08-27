Imports System.ServiceModel

Public Class frmRptSolicitudJob

    Private oSolicitudJob As New SolicitudJobService.SolicitudJobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtAreas As DataTable
    Private dtUbicacion As DataTable
    Private dtVendedor As DataTable
    Private dtTipoSolicitud As DataTable
    Private dtEstado As DataTable

    Private IdCliente As Integer

    Dim dtReporte As DataTable

    Private Sub frmRptSolicitudJob_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudJob.Close()
            oMaestroService.Close()
            oCotizacionService.Close()
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSolicitudJob.Abort()
            oMaestroService.Abort()
            oCotizacionService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSolicitudJob.Abort()
            oMaestroService.Abort()
            oCotizacionService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRptSolicitudJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRptSolicitudJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 171)
        '/*************************************************************************************/

        ' Validar Usuario - Exportar Excel
        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
            rbExportExcel.Enabled = True
        Else
            rbExportExcel.Enabled = False
        End If

        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        txtCliente.Text = "(Todos)"
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
            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

            '======================================= UBICACION ================================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '======================================= Vendedor - VENTAS ===========================================
            dtVendedor = oMaestroService.MostrarVendedores(Session.sCodEmp).Tables(0)
            dtVendedor.Rows.InsertAt(getRowTodos(dtVendedor), 0)
            cmbVendedorv.DataSource = dtVendedor
            cmbVendedorv.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedorv.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedorv.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedorv.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            cmbVendedorv.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            cmbVendedorv.SelectedIndex = 0
            dtVendedor = Nothing

            '======================================= ESTADOS ================================================
            dtEstado = oSolicitudJob.MostrarEstados.Tables(0)
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
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ReporteSolicitudJob()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptSolicitudJob

            dtReporte = oSolicitudJob.ReporteSolicitudJob(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, cmbCodArea.Value, utils.toNumber(cmbVendedorv.Value), utils.toNumber(cmbTipo.Value), IdCliente, utils.toNumber(cmbEstado.Value), cmbUbicacion.Value).Tables(0)
            DataGridView1.DataSource = dtReporte

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExportExcel.Checked Then
                    Dim Export As Boolean
                    Export = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente ")
                    End If
                ElseIf rbPantalla.Checked Then
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Solicitud OT"
                    'reporte.SetParameterValue("DesEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "DesEmp", "CodEmp", Session.sCodEmp))
                    'reporte.SetParameterValue("RucEmp", oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "RucEmp", "CodEmp", Session.sCodEmp))
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Cliente", IIf((txtCliente.Text = "(Todos)"), "(Todos)", txtCliente.Text))
                    reporte.SetParameterValue("Area", IIf((cmbCodArea.Text = "(Todos)"), "(Todos)", cmbCodArea.Text))
                    reporte.SetParameterValue("Vendedor", IIf((cmbVendedorv.Text = "(Todos)"), "(Todos)", cmbVendedorv.Text))
                    reporte.SetParameterValue("Tipo", IIf((cmbTipo.Text = "(Todos)"), "(Todos)", cmbTipo.Text))
                    reporte.SetParameterValue("Estado", IIf((cmbEstado.Text = "(Todos)"), "(Todos)", cmbEstado.Text))
                    reporte.SetParameterValue("Ubicacion", IIf((cmbUbicacion.Text = "(Todos)"), "(Todos)", cmbUbicacion.Text))
                    forma.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        '======================================= TIPO SOLICITUD ================================================
        dtTipoSolicitud = oSolicitudJob.MostrarTipoSolicitud(cmbCodArea.Value).Tables(0)
        dtTipoSolicitud.Rows.InsertAt(getRowTodos(dtTipoSolicitud), 0)
        cmbTipo.DataSource = dtTipoSolicitud
        cmbTipo.DropDownList.DataMember = dtTipoSolicitud.Columns("DesTipo").ToString
        cmbTipo.DropDownList.DisplayMember = dtTipoSolicitud.Columns("DesTipo").ToString
        cmbTipo.DropDownList.ValueMember = dtTipoSolicitud.Columns("IdTipo").ToString
        cmbTipo.DropDownList.Columns(0).DataMember = dtTipoSolicitud.Columns("IdTipo").ToString
        cmbTipo.DropDownList.Columns(1).DataMember = dtTipoSolicitud.Columns("DesTipo").ToString
        cmbTipo.SelectedIndex = 0
        dtTipoSolicitud = Nothing
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If validarData() = True Then
                oSeguridadService.RegistrarVisitaOpciones(171, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                ReporteSolicitudJob()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Function validarData() As Boolean
        If cbFecInicio.Value > cbFecFinal.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final")
            cbFecInicio.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If chkCliente.Checked Then
            txtCliente.Text = "(Todos)"
            IdCliente = 0
        End If
    End Sub
End Class