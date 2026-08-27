Imports System.ServiceModel
Public Class frmJob_Nuevo

    Private oJobService As New JobService.JobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oGastoRealService As New GastoRealService.GastoRealServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oJobDetalleService As New JobDetalleService.JobDetalleServiceClient

    Private dtOficinas As DataTable
    Private dtTipo As DataTable
    Private dtTipoMantenimiento As DataTable
    Private dtMonedas As DataTable
    Private dtLocal As DataTable
    Private dtSupervisor As DataTable
    Private dtEstados As DataTable
    Private dtUbicacion As DataTable
    Private dtAplicacion As DataTable
    Private IdSolicitante As Integer
    Private IdBeneficiado As Integer

    Public CodJob As String
    Public Actualizar As Boolean
    Public Anio As Integer

    Private dtCotizaciones As DataTable
    Private dtFacturacion As DataTable
    Private dtFabricante As DataTable

    Private dtDatos As DataTable                  '------------- Agregado el 05/03/2013 Detalles de Job -------------
    Public edicion As Boolean = True            '--------------------- True: Edición      False: Vista --------------------
    Public Estado As Integer
    Private dtCotRepAdjuntadas As DataTable

    Private dtAreas As New DataTable
    Private dtCentroCosto As New DataTable

    Public iCodArea As String
    Public iCodCentro As String

    Private Sub frmJob_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oMaestroService.Close()
            oCotizacionServicioService.Close()
            oSeguridadService.Close()
            oGastoRealService.Close()
            oJobDetalleService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oMaestroService.Abort()
            oCotizacionServicioService.Abort()
            oSeguridadService.Abort()
            oGastoRealService.Abort()
            oJobDetalleService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oMaestroService.Abort()
            oCotizacionServicioService.Abort()
            oSeguridadService.Abort()
            oGastoRealService.Abort()
            oJobDetalleService.Abort()
        End Try
    End Sub

    Private Sub frmJob_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvCotAsignadas)
        dgvCotAsignadas.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        estilo.cargaEstiloGridExtAlternating(dgvDocFacturacion)
        dgvDocFacturacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()
        If Actualizar = True Then
            ObtenerRegistro()
            listaDatos()
            Desactivar()
        Else
            cmbCodMon.Value = oMaestroService.ObtenerMonedaNacional("1")
            'cmbCodMon.Value = "US"
            txtNroClaim.Visible = False
            txtCreditState.Visible = False
            lblNroClaim.Visible = False
            lblCreditState.Visible = False
            cbNoFacturar.Visible = False
            lblRegularizar.Visible = False
            lblMarcable.Visible = False
            txtFecInicio.Value = Today.Date
            txtFecFin.Value = Today.Date
            CargarCentroCosto()
        End If
        'HabilitarGastos()
        enableOpciones()
        enableOptions()
        listaCotizaciones()
        listaFacturacion()
        cmbOficinas.Focus()
    End Sub

    Private Sub CargarCentroCosto()
        Try
            cmbArea.Value = iCodArea
            cmbCentroCosto.Value = iCodCentro
            lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(iCodArea)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================== OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            'Session.sCodUsu
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '========================================== TIPO ==================================================
            dtTipo = oJobService.MostrarTipo.Tables(0)
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbTipoJob.DataSource = dtTipo
            cmbTipoJob.DropDownList.DataMember = dtTipo.Columns("AbrTipo").ToString
            cmbTipoJob.DropDownList.DisplayMember = dtTipo.Columns("AbrTipo").ToString
            cmbTipoJob.DropDownList.ValueMember = dtTipo.Columns("IdTipoJob").ToString
            cmbTipoJob.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdTipoJob").ToString
            cmbTipoJob.DropDownList.Columns(1).DataMember = dtTipo.Columns("AbrTipo").ToString
            cmbTipoJob.SelectedIndex = 0
            dtTipo = Nothing

            '=================================== TIPO MANTENIMIENTO ===========================================
            dtTipoMantenimiento = oCotizacionServicioService.MostrarTipoMantenimiento.Tables(0)
            dtTipoMantenimiento.Rows.InsertAt(getRowTodos(dtTipoMantenimiento), 0)
            cmbMantenimiento.DataSource = dtTipoMantenimiento
            cmbMantenimiento.DropDownList.DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.DisplayMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            cmbMantenimiento.DropDownList.ValueMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(0).DataMember = dtTipoMantenimiento.Columns("CodMantenimiento").ToString
            cmbMantenimiento.DropDownList.Columns(1).DataMember = dtTipoMantenimiento.Columns("AbrMantenimiento").ToString
            'cmbMantenimiento.SelectedIndex = 0
            dtTipoMantenimiento = Nothing

            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

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

            '======================================= LUGAR A REALIZAR=========================================
            dtLocal = New DataTable
            dtLocal.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtLocal.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtTipos.Rows.Add(New Object() {"", "(Todos)"})
            dtLocal.Rows.Add(New Object() {"1", "Interno"})
            dtLocal.Rows.Add(New Object() {"2", "Externo"})

            cmbTipo.DataSource = dtLocal
            cmbTipo.DropDownList.DataMember = dtLocal.Columns("nombre").ToString
            cmbTipo.DropDownList.DisplayMember = dtLocal.Columns("nombre").ToString
            cmbTipo.DropDownList.ValueMember = dtLocal.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtLocal.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtLocal.Columns("nombre").ToString

            '============================================ APLICACIÓN ==========================================
            dtAplicacion = oJobService.MostrarAplicacionMotor.Tables(0)
            dtAplicacion.Rows.InsertAt(getRowTodos(dtAplicacion), 0)
            cmbAplicacion.DataSource = dtAplicacion
            cmbAplicacion.DropDownList.DataMember = dtAplicacion.Columns("DesAplicacion").ToString
            cmbAplicacion.DropDownList.DisplayMember = dtAplicacion.Columns("DesAplicacion").ToString
            cmbAplicacion.DropDownList.ValueMember = dtAplicacion.Columns("CodAplicacion").ToString
            cmbAplicacion.DropDownList.Columns(0).DataMember = dtAplicacion.Columns("CodAplicacion").ToString
            cmbAplicacion.DropDownList.Columns(1).DataMember = dtAplicacion.Columns("DesAplicacion").ToString
            cmbAplicacion.SelectedIndex = 0
            dtAplicacion = Nothing

            '============================================== UBICACIÓN ========================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            dtUbicacion = Nothing

            '============================================== FABRICANTE =======================================
            dtFabricante = oCotizacionServicioService.MostrarFabricante.Tables(0)
            dtFabricante.Rows.InsertAt(getRowTodos(dtFabricante), 0)
            cmbFabricante.DataSource = dtFabricante
            cmbFabricante.DropDownList.DataMember = dtFabricante.Columns("NomFabricante").ToString
            cmbFabricante.DropDownList.DisplayMember = dtFabricante.Columns("NomFabricante").ToString
            cmbFabricante.DropDownList.ValueMember = dtFabricante.Columns("IdFabricante").ToString
            cmbFabricante.DropDownList.Columns(0).DataMember = dtFabricante.Columns("IdFabricante").ToString
            cmbFabricante.DropDownList.Columns(1).DataMember = dtFabricante.Columns("NomFabricante").ToString
            cmbFabricante.SelectedIndex = 0
            dtFabricante = Nothing

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message)
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, Session.sCodUsu).Tables(0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0            

            If cmbArea.Value = "" Then
                lblUnidadNegocio.Text = ""
            Else
                lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(cmbArea.Value)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub Desactivar()
        cmbOficinas.ReadOnly = True
        cmbOficinas.BackColor = System.Drawing.SystemColors.Control
        cmbFabricante.ReadOnly = True
        cmbFabricante.BackColor = System.Drawing.SystemColors.Control
        cmbTipo.ReadOnly = True
        cmbTipo.BackColor = System.Drawing.SystemColors.Control
        cmbTipoJob.ReadOnly = True
        cmbTipoJob.BackColor = System.Drawing.SystemColors.Control
        txtMontoHrsHombre.ReadOnly = True
        txtMontoHrsHombre.BackColor = System.Drawing.SystemColors.Control
        cmbMantenimiento.ReadOnly = True
        cmbMantenimiento.BackColor = System.Drawing.SystemColors.Control
        cbKitRepower.Enabled = False
        'cbEquipo.Enabled = False
        cbNoFacturar.Enabled = False
        cmbAplicacion.ReadOnly = True
        cmbAplicacion.BackColor = System.Drawing.SystemColors.Control
        txtModMer.ReadOnly = True
        txtCodMer.ReadOnly = True
        btnBuscarMercaderia.Enabled = False
        cmbUbicacion.ReadOnly = True
        cmbUbicacion.BackColor = System.Drawing.SystemColors.Control
        btnBuscarSolicitud.Enabled = False
        txtNumSolicitud.ReadOnly = True
        txtSolicitante.ReadOnly = True
        txtBeneficiario.ReadOnly = True
        btnBuscarSolicitante.Enabled = False
        btnBuscarBeneficiario.Enabled = False
        txtFecInicio.ReadOnly = True
        txtFecInicio.BackColor = System.Drawing.SystemColors.Control
        txtFecFin.ReadOnly = True
        txtFecFin.BackColor = System.Drawing.SystemColors.Control
        txtDescripcion.ReadOnly = True
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control

        If cmbTipoJob.Value = 3 Then
            txtNroClaim.ReadOnly = True
            txtCreditState.ReadOnly = True
            txtNroClaim.Visible = True
            txtCreditState.Visible = True
            lblNroClaim.Visible = True
            lblCreditState.Visible = True
        Else
            txtNroClaim.Visible = False
            txtCreditState.Visible = False
            lblNroClaim.Visible = False
            lblCreditState.Visible = False
        End If
        cmbSupervisor.ReadOnly = True
        cmbSupervisor.BackColor = System.Drawing.SystemColors.Control
        '---------------------------------------
        btnGuardar.Enabled = False
        biImprimir.Enabled = True
        biRegularGastos.Enabled = IIf(oJobService.Estado(CodJob) = 6 Or oJobService.Estado(CodJob) = 1, False, True)


        txtFecLlegada.ReadOnly = True
        txtFecLlegada.BackColor = System.Drawing.SystemColors.Control
        txtFecEntrega.ReadOnly = True
        txtFecEntrega.BackColor = System.Drawing.SystemColors.Control


        txtFecIniRep.ReadOnly = True
        txtFecIniRep.BackColor = System.Drawing.SystemColors.Control
        txtFecFinRep.ReadOnly = True
        txtFecFinRep.BackColor = System.Drawing.SystemColors.Control


        txtFecIniModulo.ReadOnly = True
        txtFecIniModulo.BackColor = System.Drawing.SystemColors.Control
        txtFecFinModulo.ReadOnly = True
        txtFecFinModulo.BackColor = System.Drawing.SystemColors.Control
        txtFecFinDesarmado.ReadOnly = True
        txtFecFinDesarmado.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOptions()
    End Sub

    Private Sub Activar()
        '============================= EJECUCIÓN ================================
        If oJobService.Estado(txtNumJob.Text) = 6 Then
            cmbOficinas.ReadOnly = False
            cmbOficinas.BackColor = System.Drawing.SystemColors.Window
            cmbFabricante.ReadOnly = False
            cmbFabricante.BackColor = System.Drawing.SystemColors.Window
            cmbTipo.ReadOnly = True
            cmbTipo.BackColor = System.Drawing.SystemColors.Control
            cmbTipoJob.ReadOnly = False
            cmbTipoJob.BackColor = System.Drawing.SystemColors.Window
            If cmbTipoJob.Value = 1 Then
                txtMontoHrsHombre.ReadOnly = False
                txtMontoHrsHombre.BackColor = System.Drawing.SystemColors.Window
            Else
                txtMontoHrsHombre.ReadOnly = True
                txtMontoHrsHombre.BackColor = System.Drawing.SystemColors.Control
                txtMontoHrsHombre.Value = 0.0
            End If
            cmbMantenimiento.ReadOnly = False
            cmbMantenimiento.BackColor = System.Drawing.SystemColors.Window
            cbKitRepower.Enabled = True
            'cbEquipo.Enabled = True
            cbNoFacturar.Enabled = True
            cmbAplicacion.ReadOnly = False
            cmbAplicacion.BackColor = System.Drawing.SystemColors.Window
            txtModMer.ReadOnly = False
            txtCodMer.ReadOnly = False
            btnBuscarMercaderia.Enabled = True
            cmbUbicacion.ReadOnly = False
            cmbUbicacion.BackColor = System.Drawing.SystemColors.Window

            btnBuscarSolicitud.Enabled = False
            txtNumSolicitud.ReadOnly = True
            txtSolicitante.ReadOnly = True
            txtBeneficiario.ReadOnly = True
            btnBuscarSolicitante.Enabled = True
            btnBuscarBeneficiario.Enabled = True
            txtFecInicio.ReadOnly = False
            txtFecInicio.BackColor = System.Drawing.SystemColors.Window
            txtFecFin.ReadOnly = False
            txtFecFin.BackColor = System.Drawing.SystemColors.Window
            txtDescripcion.ReadOnly = False
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control

            If cmbTipoJob.Value = 3 Then
                txtNroClaim.ReadOnly = True
                txtCreditState.ReadOnly = True
                txtNroClaim.Visible = True
                txtCreditState.Visible = True
                lblNroClaim.Visible = True
                lblCreditState.Visible = True
            Else
                txtNroClaim.Visible = False
                txtCreditState.Visible = False
                lblNroClaim.Visible = False
                lblCreditState.Visible = False
            End If

            cmbSupervisor.ReadOnly = False
            cmbSupervisor.BackColor = System.Drawing.SystemColors.Window

            txtFecLlegada.ReadOnly = False
            txtFecLlegada.BackColor = System.Drawing.SystemColors.Window
            txtFecEntrega.ReadOnly = False
            txtFecEntrega.BackColor = System.Drawing.SystemColors.Window


            txtFecIniRep.ReadOnly = False
            txtFecIniRep.BackColor = System.Drawing.SystemColors.Window
            txtFecFinRep.ReadOnly = False
            txtFecFinRep.BackColor = System.Drawing.SystemColors.Window


            txtFecIniModulo.ReadOnly = False
            txtFecIniModulo.BackColor = System.Drawing.SystemColors.Window
            txtFecFinModulo.ReadOnly = False
            txtFecFinModulo.BackColor = System.Drawing.SystemColors.Window
            txtFecFinDesarmado.ReadOnly = False
            txtFecFinDesarmado.BackColor = System.Drawing.SystemColors.Window


            '========================= CULMINADO O LIQUIDADO PARCIAL ===========================
        ElseIf oJobService.Estado(txtNumJob.Text) = 28 Or oJobService.Estado(txtNumJob.Text) = 29 Then
            If cmbTipoJob.Value = 3 Then
                If oJobService.Estado(txtNumJob.Text) = 28 Then
                    'cmbCodMon.ReadOnly = False
                    'cmbCodMon.BackColor = System.Drawing.SystemColors.Window
                    cmbFabricante.ReadOnly = False
                    cmbFabricante.BackColor = System.Drawing.SystemColors.Window
                Else
                    'cmbCodMon.ReadOnly = True
                    'cmbCodMon.BackColor = System.Drawing.SystemColors.Control
                    cmbFabricante.ReadOnly = True
                    cmbFabricante.BackColor = System.Drawing.SystemColors.Control
                End If
                txtNroClaim.ReadOnly = True
                txtCreditState.ReadOnly = True
                txtNroClaim.Visible = True
                txtCreditState.Visible = True
                lblNroClaim.Visible = True
                lblCreditState.Visible = True
            Else
                txtNroClaim.Visible = False
                txtCreditState.Visible = False
                lblNroClaim.Visible = False
                lblCreditState.Visible = False
            End If

            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control

            If oJobService.Estado(txtNumJob.Text) = 28 Then

                txtFecEntrega.ReadOnly = False
                txtFecEntrega.BackColor = System.Drawing.SystemColors.Window

            End If

        End If
        '--------------------------------------------

        btnGuardar.Enabled = True
        btnEditar.Enabled = False
        biImprimir.Enabled = False
        biRegularGastos.Enabled = False

        edicion = True
        enableOptions()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If utils.toBlank(cmbOficinas.Value) = "" Then
                MsgBox("Debe ingresar la oficina.")
                cmbOficinas.Focus()
                Return False
            ElseIf utils.toBlank(cmbFabricante.Text) = "" Then
                MsgBox("Debe ingresar el fabricante.")
                cmbFabricante.Focus()
                Return False
            ElseIf utils.toBlank(cmbMantenimiento.Value) = "" Then
                MsgBox("Debe ingresar el Mantenimiento.")
                cmbMantenimiento.Focus()
                Return False
            ElseIf utils.toBlank(cmbTipoJob.Text) = "" Then
                MsgBox("Debe ingresar el tipo de OT.")
                cmbTipoJob.Focus()
                Return False
            ElseIf utils.toBlank(cmbTipo.Value) = "" Then
                MsgBox("Debe ingresar el tipo.")
                cmbTipo.Focus()
                Return False
            ElseIf utils.toBlank(txtNumSolicitud.Text) = "" Then
                MsgBox("Debe ingresar el número de solicitud.")
                btnBuscarSolicitud.Focus()
                Return False
            ElseIf utils.toBlank(cmbAplicacion.Value = "") Then
                MsgBox("Debe ingresar la aplicación.")
                cmbAplicacion.Focus()
                Return False
            ElseIf utils.toBlank(txtSolicitante.Text) = "" Then
                MsgBox("Debe ingresar el Solicitante.")
                btnBuscarSolicitante.Focus()
                Return False
            ElseIf utils.toBlank(txtBeneficiario.Text) = "" Then
                MsgBox("Debe ingresar el Beneficiario.")
                btnBuscarBeneficiario.Focus()
                Return False
            ElseIf utils.toBlank(txtFecInicio.Value) = "" Then
                MsgBox("Debe Ingresar la fecha de Inicio.")
                txtFecInicio.Focus()
                Return False
            ElseIf utils.toBlank(txtFecFin.Value) = "" Then
                MsgBox("Debe ingresar la fecha de termino.")
                txtFecFin.Focus()
                Return False
            ElseIf utils.toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe ingresar la moneda....")
                cmbCodMon.Focus()
                Return False
                'ElseIf txtCodMer.Text = "" Then
                '    Utilidades.UserMsgBox("Debe ingresar el codigo de la mercaderia", Me)
                '    txtCodMer.Focus()
                '    Return False
                'ElseIf txtModMer.Text = "" Then
                '    Utilidades.UserMsgBox("Debe ingresar el modelo de la mercaderia", Me)
                '    txtModMer.Focus()
                '    Return False
            ElseIf utils.toBlank(cmbSupervisor.Value) = "" Then
                MsgBox("Debe ingresar el supervisor.")
                cmbSupervisor.Focus()
                Return False
            ElseIf txtDescripcion.Text = "" Then
                MsgBox("Debe ingresar la observación de la OT.")
                txtDescripcion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS : " + ex.Message)
        End Try
    End Function

    Private Sub listaCotizaciones()
        Try
            dtCotizaciones = oJobService.MostrarCotizacionAsignada(Trim(txtNumJob.Text)).Tables(0)
            dgvCotAsignadas.DataSource = dtCotizaciones
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR COTIZACIONES ASIGNADAS : " + ex.Message)
        End Try
    End Sub

    Private Sub listaFacturacion()
        Try
            dtFacturacion = oJobService.MostrarFacturacion(Trim(txtNumJob.Text)).Tables(0)
            dgvDocFacturacion.DataSource = dtFacturacion
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DOCUMENTOS DE FACTURACION : " + ex.Message)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As JobService.Job
            oJobService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            registro = oJobService.Obtener(CodJob)

            txtNumJob.Text = registro.CodJob
            If oJobService.Regularizar(txtNumJob.Text) = True Then
                lblRegularizar.Visible = True
                lblRegularizar.Text = "OT Activado Temporalmente por el Administrador para ser Regularizado"
            Else
                lblRegularizar.Visible = False
            End If

            If oJobService.Marcable(txtNumJob.Text) = True And oJobService.Estado(txtNumJob.Text) = 6 Then
                lblMarcable.Visible = True
                lblMarcable.Text = "OT habilitado para marcación"
            Else
                lblMarcable.Visible = False
            End If

            cmbOficinas.Value = registro.Oficina.CodOfi
            If registro.Tipo = 1 Then
                cmbTipo.Value = 1
                cmbTipo.Text = "Interno"
            ElseIf registro.Tipo = 2 Then
                cmbTipo.Value = 2
                cmbTipo.Text = "Externo"
            End If
            txtNumSolicitud.Text = registro.SolicitudJob.IdSolicitud
            cmbTipoJob.Value = registro.TipoJob.IdTipoJob

            txtMontoHrsHombre.Value = registro.MontoHora

            lblAsterisco.Visible = True
            lblLeyenda.Visible = True
            If cmbTipoJob.Value = 2 Then
                lblLeyenda.Text = " Precio de Venta, Incluido el Descuento."
            Else
                lblLeyenda.Text = " Costos."
            End If
            cmbFabricante.Value = registro.Fabricante.IdFabricante
            IdSolicitante = registro.ClienteSolicita.IdCliente
            txtSolicitante.Text = registro.ClienteSolicita.DesCli
            IdBeneficiado = registro.ClienteBeneficiado.IdCliente
            txtBeneficiario.Text = registro.ClienteBeneficiado.DesCli
            cmbMantenimiento.Value = registro.TipoMantenimiento.CodMantenimiento
            cbKitRepower.Checked = registro.Repower
            txtCodMer.Text = registro.CodMer
            txtModMer.Text = registro.ModMer
            cbNoFacturar.Checked = registro.Facturar
            cmbAplicacion.Value = registro.TipoAplicacionMotor.CodAplicacion
            cmbUbicacion.Value = registro.UbicacionEquipo.CodUbicacion
            txtDescripcion.Text = registro.Observacion
            txtFecInicio.Value = registro.FecInicio
            txtFecFin.Value = registro.FecFinal
            cmbCodMon.Value = registro.Moneda.CodMon
            txtNroClaim.Text = registro.NroClaim
            txtCreditState.Text = registro.CreditState
            cmbSupervisor.Value = registro.PersonaDelegado.IdPer

            txtFecLiqAdm.Text = utils.toNull(registro.FecLiquidacionAdmin.ToString)

            Estado = registro.EstadoJob.IdEstado
            lblEstado.Text = registro.EstadoJob.DesEstado
            If lblEstado.Text Is Nothing Or lblEstado.Text = "" Then
                lblEstado.Visible = False
            Else
                lblEstado.Visible = True
            End If

            If Not (registro.FecLlegada.ToString = "") Then
                txtFecLlegada.Value = CDate(registro.FecLlegada)
                txtFecLlegada.Text = registro.FecLlegada.ToString
            End If

            If Not (registro.FecIniRep.ToString = "") Then
                txtFecIniRep.Value = CDate(registro.FecLlegada)
                txtFecLlegada.Text = registro.FecLlegada.ToString
            End If

            'txtFecIniRep.Text = utils.toNull(registro.FecIniRep.Value)
            'txtFecFinRep.Text = utils.toNull(registro.FecFinRep.ToString)

            If Not (registro.FecEntrega.ToString = "") Then
                txtFecEntrega.Value = CDate(registro.FecEntrega)
                txtFecEntrega.Text = registro.FecEntrega.ToString
            End If



            If Not (registro.FecIniRep.ToString = "") Then
                txtFecIniRep.Value = CDate(registro.FecIniRep)
                txtFecIniRep.Text = registro.FecIniRep.ToString
            End If
            If Not (registro.FecFinRep.ToString = "") Then
                txtFecFinRep.Value = CDate(registro.FecFinRep)
                txtFecFinRep.Text = registro.FecFinRep.ToString
            End If


            If Not (registro.FecIniModulo.ToString = "") Then
                txtFecIniModulo.Value = CDate(registro.FecIniModulo)
                txtFecIniModulo.Text = registro.FecIniModulo.ToString
            End If
            If Not (registro.FecFinModulo.ToString = "") Then
                txtFecFinModulo.Value = CDate(registro.FecFinModulo)
                txtFecFinModulo.Text = registro.FecFinModulo.ToString
            End If
            If Not (registro.FecFinDesarmado.ToString = "") Then
                txtFecFinDesarmado.Value = CDate(registro.FecFinDesarmado)
                txtFecFinDesarmado.Text = registro.FecFinDesarmado.ToString
            End If

            cmbArea.Value = registro.CentroCosto.Area.CodArea
            cmbCentroCosto.Value = registro.CentroCosto.CodCentro
            lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(registro.CentroCosto.Area.CodArea)

            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub enableOpciones()
        Try
            If Actualizar = False Then
                btnGuardar.Enabled = True
                btnEditar.Enabled = False
                '--------------------------------------------
                btnDesvincularCotizacion.Enabled = False
                btnAsignarCotizacion.Enabled = False
                btnVerRepuestos.Enabled = False
                biImprimir.Enabled = False
                biRegularGastos.Enabled = True
            Else
                btnGuardar.Enabled = False
                '--------------------------------------------- Se agrego al Editar el estado 29 (Liquidado Parcial) (13/07/2012) -----------------------------------------------
                btnEditar.Enabled = IIf(oJobService.Estado(txtNumJob.Text) = 6 Or (oJobService.Estado(txtNumJob.Text) = 28 Or oJobService.Estado(txtNumJob.Text) = 29 And cmbTipoJob.Value = 3), True, False)
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                '======================= Se cambió permitiendo desvincular o vincular en el estado culminado 19/05/2014 (Cesar) ======================
                '======================= Se cambió permitiendo vincular en el estado culminado 16/09/2014 (Cesar, Sra Dolores) ======================
                btnDesvincularCotizacion.Enabled = IIf(oJobService.Estado(txtNumJob.Text) = 6 Or oJobService.Estado(txtNumJob.Text) = 28, True, False)
                btnAsignarCotizacion.Enabled = IIf(oJobService.Estado(txtNumJob.Text) = 6 Or oJobService.Estado(txtNumJob.Text) = 28 Or oJobService.Estado(txtNumJob.Text) = 29, True, False)
                '============================================================================================================
                btnVerRepuestos.Enabled = True
                biImprimir.Enabled = True
                biImprimir.Visible = True

                biRegularGastos.Visible = True
                biRegularGastos.Enabled = IIf(oJobService.Estado(CodJob) = 6 Or oJobService.Estado(CodJob) = 1, False, True)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL HABILITAR LAS OPCIONES : " + ex.Message)
        End Try
    End Sub

    Private Sub enableOptions()
        '================ OPCIONES DEL DETALLE (05/03/2012) ================
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(Estado = 6, True, False)
        End If
        miNuevo.Enabled = IIf(Estado = 6, True, False)
        cmOpciones.Enabled = IIf(lblEstado.Text <> "", Not edicion, False)
        '==============================================================
    End Sub

    Private Sub Guardar()
        Try
            If IdSolicitante = 7176 And cmbTipoJob.Value <> 1 Then

                If MsgBox("¿Estás seguro de guardar la OT aunque no sea interno?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                    Dim registro As New JobService.Job
                    Dim oficina As New JobService.Oficina
                    Dim empresa As New JobService.Empresa
                    Dim clienteSolicita As New JobService.Cliente
                    Dim clienteBeneficiario As New JobService.Cliente
                    Dim persona As New JobService.Persona
                    Dim moneda As New JobService.Moneda
                    Dim solicitud As New JobService.SolicitudJob
                    Dim tipojob As New JobService.TipoJob
                    Dim tipomantenimiento As New JobService.TipoMantenimiento
                    Dim tipoaplicacion As New JobService.TipoAplicacionMotor
                    Dim ubicacion As New JobService.UbicacionEquipo
                    Dim posesionjob As New JobService.PosesionJob
                    Dim fabricante As New JobService.Fabricante
                    Dim Area As New JobService.Area
                    Dim CentroCosto As New JobService.CentroCosto

                    registro.CodJob = txtNumJob.Text
                    registro.Tipo = utils.toNumber(cmbTipo.Value)
                    empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = empresa
                    oficina.CodOfi = utils.toNull(cmbOficinas.Value)
                    registro.Oficina = oficina
                    fabricante.IdFabricante = utils.toBlank(cmbFabricante.Value)
                    registro.Fabricante = fabricante

                    clienteSolicita.IdCliente = IdSolicitante
                    registro.ClienteSolicita = clienteSolicita
                    clienteBeneficiario.IdCliente = IdBeneficiado
                    registro.ClienteBeneficiado = clienteBeneficiario

                    registro.FecCreacion = Today
                    registro.FecInicio = txtFecInicio.Value
                    registro.FecFinal = txtFecFin.Value
                    registro.CodMer = txtCodMer.Text
                    registro.ModMer = txtModMer.Text
                    persona.IdPer = utils.toNumber(cmbSupervisor.Value)
                    registro.PersonaDelegado = persona
                    registro.Observacion = utils.toNull(txtDescripcion.Text)
                    moneda.CodMon = cmbCodMon.Value
                    registro.Moneda = moneda
                    registro.NroClaim = utils.toNull(txtNroClaim.Text)
                    registro.CreditState = utils.toNull(txtCreditState.Text)
                    registro.Repower = cbKitRepower.Checked
                    registro.BanLiquidacion = 0
                    registro.Anulado = 0
                    registro.NoFacturar = cbNoFacturar.Checked
                    solicitud.IdSolicitud = txtNumSolicitud.Text
                    registro.SolicitudJob = solicitud
                    tipojob.IdTipoJob = cmbTipoJob.Value
                    registro.TipoJob = tipojob

                    registro.MontoHora = txtMontoHrsHombre.Value

                    tipomantenimiento.CodMantenimiento = utils.toNull(cmbMantenimiento.Value)
                    registro.TipoMantenimiento = tipomantenimiento
                    tipoaplicacion.CodAplicacion = utils.toNull(cmbAplicacion.Value)
                    registro.TipoAplicacionMotor = tipoaplicacion
                    ubicacion.CodUbicacion = utils.toNull(cmbUbicacion.Value)
                    registro.UbicacionEquipo = ubicacion
                    registro.FecLlegada = IIf(txtFecLlegada.Text = "", Nothing, txtFecLlegada.Value)


                    registro.FecIniRep = IIf(txtFecIniRep.Text = "", Nothing, txtFecIniRep.Value)
                    registro.FecFinRep = IIf(txtFecFinRep.Text = "", Nothing, txtFecFinRep.Value)


                    registro.FecIniModulo = IIf(txtFecIniModulo.Text = "", Nothing, txtFecIniModulo.Value)
                    registro.FecFinModulo = IIf(txtFecFinModulo.Text = "", Nothing, txtFecFinModulo.Value)
                    registro.FecFinDesarmado = IIf(txtFecFinDesarmado.Text = "", Nothing, txtFecFinDesarmado.Value)


                    Area.CodArea = cmbArea.Value
                    CentroCosto.CodCentro = cmbCentroCosto.Value
                    CentroCosto.Area = Area
                    registro.CentroCosto = CentroCosto

                    If Actualizar = True Then
                        registro.FecEntrega = IIf(txtFecEntrega.Text = "", Nothing, txtFecEntrega.Value)
                    Else
                        registro.FecEntrega = Nothing
                    End If
                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    If Actualizar = True Then
                        Modificar(registro)
                    Else
                        Insertar(registro)
                    End If


                End If
            Else

                If MsgBox("¿Estás seguro de guardar los cambios?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                    Dim registro As New JobService.Job
                    Dim oficina As New JobService.Oficina
                    Dim empresa As New JobService.Empresa
                    Dim clienteSolicita As New JobService.Cliente
                    Dim clienteBeneficiario As New JobService.Cliente
                    Dim persona As New JobService.Persona
                    Dim moneda As New JobService.Moneda
                    Dim solicitud As New JobService.SolicitudJob
                    Dim tipojob As New JobService.TipoJob
                    Dim tipomantenimiento As New JobService.TipoMantenimiento
                    Dim tipoaplicacion As New JobService.TipoAplicacionMotor
                    Dim ubicacion As New JobService.UbicacionEquipo
                    Dim posesionjob As New JobService.PosesionJob
                    Dim fabricante As New JobService.Fabricante
                    Dim Area As New JobService.Area
                    Dim CentroCosto As New JobService.CentroCosto

                    registro.CodJob = txtNumJob.Text
                    registro.Tipo = utils.toNumber(cmbTipo.Value)
                    empresa.CodEmp = Session.sCodEmp
                    registro.Empresa = empresa
                    oficina.CodOfi = utils.toNull(cmbOficinas.Value)
                    registro.Oficina = oficina
                    fabricante.IdFabricante = utils.toBlank(cmbFabricante.Value)
                    registro.Fabricante = fabricante

                    clienteSolicita.IdCliente = IdSolicitante
                    registro.ClienteSolicita = clienteSolicita
                    clienteBeneficiario.IdCliente = IdBeneficiado
                    registro.ClienteBeneficiado = clienteBeneficiario

                    registro.FecCreacion = Today
                    registro.FecInicio = txtFecInicio.Value
                    registro.FecFinal = txtFecFin.Value
                    registro.CodMer = txtCodMer.Text
                    registro.ModMer = txtModMer.Text
                    persona.IdPer = utils.toNumber(cmbSupervisor.Value)
                    registro.PersonaDelegado = persona
                    registro.Observacion = utils.toNull(txtDescripcion.Text)
                    moneda.CodMon = cmbCodMon.Value
                    registro.Moneda = moneda
                    registro.NroClaim = utils.toNull(txtNroClaim.Text)
                    registro.CreditState = utils.toNull(txtCreditState.Text)
                    registro.Repower = cbKitRepower.Checked
                    registro.BanLiquidacion = 0
                    registro.Anulado = 0
                    registro.NoFacturar = cbNoFacturar.Checked
                    solicitud.IdSolicitud = txtNumSolicitud.Text
                    registro.SolicitudJob = solicitud
                    tipojob.IdTipoJob = cmbTipoJob.Value
                    registro.TipoJob = tipojob

                    registro.MontoHora = txtMontoHrsHombre.Value

                    tipomantenimiento.CodMantenimiento = utils.toNull(cmbMantenimiento.Value)
                    registro.TipoMantenimiento = tipomantenimiento
                    tipoaplicacion.CodAplicacion = utils.toNull(cmbAplicacion.Value)
                    registro.TipoAplicacionMotor = tipoaplicacion
                    ubicacion.CodUbicacion = utils.toNull(cmbUbicacion.Value)
                    registro.UbicacionEquipo = ubicacion
                    registro.FecLlegada = IIf(txtFecLlegada.Text = "", Nothing, txtFecLlegada.Value)


                    registro.FecIniRep = IIf(txtFecIniRep.Text = "", Nothing, txtFecIniRep.Value)
                    registro.FecFinRep = IIf(txtFecFinRep.Text = "", Nothing, txtFecFinRep.Value)


                    registro.FecIniModulo = IIf(txtFecIniModulo.Text = "", Nothing, txtFecIniModulo.Value)
                    registro.FecFinModulo = IIf(txtFecFinModulo.Text = "", Nothing, txtFecFinModulo.Value)
                    registro.FecFinDesarmado = IIf(txtFecFinDesarmado.Text = "", Nothing, txtFecFinDesarmado.Value)


                    If Actualizar = True Then
                        registro.FecEntrega = IIf(txtFecEntrega.Text = "", Nothing, txtFecEntrega.Value)
                    Else
                        registro.FecEntrega = Nothing
                    End If

                    Area.CodArea = cmbArea.Value
                    CentroCosto.CodCentro = cmbCentroCosto.Value
                    CentroCosto.Area = Area
                    registro.CentroCosto = CentroCosto

                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    If Actualizar = True Then
                        Modificar(registro)
                    Else
                        Insertar(registro)
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub Insertar(ByVal registro As JobService.Job)
        Try
            Dim estado_process As String
            estado_process = oJobService.Insertar(registro)
            If estado_process <> "" Then
                CodJob = estado_process
                MsgBox("Se guardaron los datos correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comunicarse con el departamento de TI...!")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LOS DATOS : " + ex.Message)
        End Try
    End Sub

    Protected Sub Modificar(ByVal registro As JobService.Job)
        Try
            Dim estado_process As Boolean
            estado_process = oJobService.Actualizar(registro)

            If estado_process Then
                MsgBox("Se modifico correctamente la OT")
                ObtenerRegistro()
                Desactivar()
            Else
                MsgBox("Error en el proceso , comunicarse con el administrador del sistema")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LOS DATOS " + ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Activar()
    End Sub

    'Private Sub HabilitarGastos()
    'Try
    'Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "13" Then
    'If Session.CodPerfil = "01" Or Session.CodPerfil = "24" Or Session.CodPerfil = "13" Then

    'lblGastos.Visible = True
    'lblCodMon.Visible = True
    'lblGasRepuestos.Visible = True
    'lblGasDescuento.Visible = True
    'lblGasManoObra.Visible = True
    'lblGasGastoViaje.Visible = True
    'lblGasRefrigMov.Visible = True
    'lblGasMateriales.Visible = True
    'lblGasTerceros.Visible = True
    'lblGasVarios.Visible = True
    'lblTotal.Visible = True

    'txtCostoRepuestos.Visible = True
    'txtCostoDescuento.Visible = True
    'txtCostoManoObra.Visible = True
    'txtCostoViaticos.Visible = True
    'txtCostoRefrigerio.Visible = True
    'txtCostoMateriales.Visible = True
    'txtCostoTerceros.Visible = True
    'txtCostoVarios.Visible = True
    'txtTotCosto.Visible = True

    'btnRepuestos.Visible = True
    '' btnDescuento.Visible = True
    'btnManoObra.Visible = True
    'btnGastosViaje.Visible = True
    'btnTerceros.Visible = True
    'btnMateriales.Visible = True
    'btnRefrigMov.Visible = True
    'btnVarios.Visible = True

    'Else

    'lblGastos.Visible = False
    'lblCodMon.Visible = False
    'lblGasRepuestos.Visible = False
    'lblGasDescuento.Visible = False
    'lblGasManoObra.Visible = False
    'lblGasGastoViaje.Visible = False
    'lblGasRefrigMov.Visible = False
    'lblGasMateriales.Visible = False
    'lblGasTerceros.Visible = False
    'lblGasVarios.Visible = False
    'lblTotal.Visible = False

    'txtCostoRepuestos.Visible = False
    'txtCostoDescuento.Visible = False
    'txtCostoManoObra.Visible = False
    'txtCostoViaticos.Visible = False
    'txtCostoRefrigerio.Visible = False
    'txtCostoMateriales.Visible = False
    'txtCostoTerceros.Visible = False
    'txtCostoVarios.Visible = False
    'txtTotCosto.Visible = False

    'btnRepuestos.Visible = False
    '' btnDescuento.Visible = False
    'btnManoObra.Visible = False
    'btnGastosViaje.Visible = False
    'btnTerceros.Visible = False
    'btnMateriales.Visible = False
    'btnRefrigMov.Visible = False
    'btnVarios.Visible = False

    'End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL HABILITAR GASTOS : " + ex.Message)
    '    End Try
    'End Sub

    Private Sub Desvincular()
        Try
            Dim estado_process As Boolean
            estado_process = oJobService.DesvincularCotizacion(Trim(txtNumJob.Text), dgvCotAsignadas.CurrentRow.Cells("IdCotizacionSer").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If estado_process Then
                MsgBox("Se realizó el desvinculo correctamente")
                listaCotizaciones()
                ObtenerRegistro()
                listaDatos()
            Else
                MsgBox("Error en el proceso , comunicarse con el area de TI")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DESVINCULAR COTIZACION : " + ex.Message)
        End Try
    End Sub

    'Private Sub btnRepuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_Repuestos
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "6"
    '    'frm.CodMon = lblCodMon.Text
    '    frm.ShowDialog()
    'End Sub

    'Private Sub btnManoObra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_ManoObra
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "1"
    '    'frm.CodMon = lblCodMon.Text
    '    frm.ShowDialog()
    'End Sub

    'Private Sub btnTerceros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_Terceros
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "2"
    '    frm.ShowDialog()
    '    If frm.Actualizar = True Then
    '        ObtenerRegistro()
    '    End If
    'End Sub

    'Private Sub btnGastosViaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_GastosViaje
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "3"
    '    frm.ShowDialog()
    'End Sub

    'Private Sub btnMateriales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim frm As New frmJob_Mostrar_Materiales
    '        Dim dtMateriales As DataTable
    '        frm.CodJob = CodJob
    '        frm.CodRubro = "4"
    '        'frm.CodMon = lblCodMon.Text
    '        frm.Anio = Anio
    '        dtMateriales = oGastoRealService.Filtrar(Anio, CodJob, "4", 0, "", "", "").Tables(0)

    '        If dtMateriales.Rows.Count > 0 Then
    '            frm.MostrarMat = True
    '        Else : frm.MostrarMat = False
    '        End If
    '        frm.ShowDialog()
    '    Catch ex As Exception
    '        MsgBox("ERROR AL MOSTRAR LOS MATERIALES " + ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnVarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_Varios
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "5"
    '    frm.ShowDialog()
    '    If frm.Actualizar = True Then
    '        ObtenerRegistro()
    '    End If
    'End Sub

    'Private Sub btnRefrigMov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmJob_Mostrar_RefrigMovil
    '    frm.CodJob = CodJob
    '    frm.CodRubro = "7"
    '    frm.ShowDialog()
    '    If frm.Actualizar = True Then
    '        ObtenerRegistro()
    '    End If
    'End Sub

    Private Sub btnBuscarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarSolicitante.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdSolicitante = frm.codigo
                Else
                    txtSolicitante.Text = ""
                    IdSolicitante = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarBeneficiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarBeneficiario.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtBeneficiario.Text = frm.descripcion
                    IdBeneficiado = frm.codigo
                Else
                    txtBeneficiario.Text = ""
                    IdBeneficiado = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarSolicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarSolicitud.Click
        Dim frm As New frmJob_AsignarSolicitud
        frm.ShowDialog()

        If frm.IdSolicitud <> 0 Then
            txtNumSolicitud.Text = frm.IdSolicitud
        Else
            txtNumSolicitud.Text = ""
        End If
        IdSolicitante = frm.IdClienteSolicitante
        IdBeneficiado = frm.IdClienteBeneficiario
        txtSolicitante.Text = frm.ClienteSolicitante
        txtBeneficiario.Text = frm.ClienteBeneficiario
        txtCodMer.Text = frm.CodMer
        txtModMer.Text = frm.ModMer
        cmbUbicacion.Value = frm.CodUbicacion
        txtDescripcion.Text = frm.Observacion
        cmbTipoJob.Value = frm.IdTipoJob

    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Try
            Dim frm As New frmBuscarMercaderia
            frm.CodRub = "04"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                txtCodMer.Text = frm.codigo
                'txtDesMer.Text = frm.descripcion
                txtModMer.Text = frm.ModMer
            End If
            txtCodMer.Select()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As DataTable
            Dim dtSubReporte As DataTable
            Dim reporte As New rptJobDetalle

            dtReporte = oJobService.Imprimir(txtNumJob.Text).Tables(0)
            dtSubReporte = oJobService.MostrarLiquidaciones(txtNumJob.Text).Tables(0)

            If reporte.Subreports.Count > 0 Then
                reporte.Subreports(0).SetDataSource(dtSubReporte)
            End If

            If dtReporte.Rows.Count = 0 Then
                MsgBox("¡No hay Datos que mostrar, verifique...!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                forma.Text = "reporte por Rubros de la OT"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        MostrarReporte()
    End Sub

    Private Sub biRegularGastos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRegularGastos.Click
        Dim frm As New frmJob_Regularizar

        frm.CodJob = CodJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub btnAsignarCoti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarCotizacion.Click
        Dim frm As New frmJob_AsignarCotizacion
        frm.CodJob = CodJob
        frm.IdBeneficiado = IdBeneficiado
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            listaCotizaciones()
            ObtenerRegistro()
            listaDatos()            
        End If
    End Sub

    Private Sub btnDesvincularCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesvincularCotizacion.Click
        If dgvCotAsignadas.RowCount = 0 Then
            MsgBox("¡Selecccione un registro, tenga cuidado ...!")
        Else
            If MsgBox("¿Está seguro de DESVINCULAR la cotizacion N° " & dgvCotAsignadas.CurrentRow.Cells("NumCotizacion").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Desvincular()
            End If
        End If
    End Sub

    Private Sub btnVerRepuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerRepuestos.Click
        Try
            Dim frm2 As New frmJob_ListadoRepuestos
            frm2.CodJob = CodJob
            frm2.DesCli = txtSolicitante.Text
            frm2.ModMer = txtModMer.Text
            frm2.IdCliente = IdSolicitante
            If frm2.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        'MsgBox("La opción esta desabilitado por la organización...!", MsgBoxStyle.Information, "Bloqueado")

    End Sub

    Private Sub dgvCotAsignadas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCotAsignadas.DoubleClick
        btnVerRepuestos_Click(sender, e)
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oJobDetalleService.Mostrar(txtNumJob.Text).Tables(0)
            dgvDatos.DataSource = dtDatos
            Dim registro As New JobService.Job
            registro = oJobService.Obtener(txtNumJob.Text)

            lblMontoVenta.Text = "(Montos no incluyen Igv)  TOTAL MONTO VENTA:" & " " & registro.Moneda.CodMon
            lblMontoCosto.Text = "TOTAL MONTO COSTO:" & " " & registro.Moneda.CodMon

            txtMontoVenta.Value = registro.TotVentaCot
            txtMontoCosto.Value = registro.TotBrutoCosto
            enableOptions()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Try
            If Actualizar = True Then
                NuevoDetalle()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL AGREGAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        Try
            If ValidaCodigoSeleccionado() Then
                MostrarDetalle()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                eliminarDetalle()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdRubro").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdRubro").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(2).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oJobDetalleService.Borrar(txtNumJob.Text, toNumber(dgvDatos.CurrentRow.Cells("IdRubro").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmJob_Detalle
                frm.state_button = False
                frm.CodJob = txtNumJob.Text
                frm.estado = Estado
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdRubro)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarDetalle()
        Try
            Dim frm As New frmJob_Detalle
            frm.state_button = True
            frm.CodJob = txtNumJob.Text
            frm.IdRubro = toNumber(dgvDatos.CurrentRow.Cells("IdRubro").Value)
            frm.estado = Estado
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdRubro)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdRubro)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_ColumnButtonClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnButtonClick
        Try
            If e.Column.Key = "Mostrar" Then
                Dim IdRubro As Integer
                IdRubro = toNumber(dgvDatos.CurrentRow.Cells("IdRubro").Value)

                '======================= REPUESTOS ==========================
                If IdRubro = 1 Then
                    Dim frm As New frmJob_Mostrar_Repuestos
                    frm.CodJob = CodJob
                    frm.CodRubro = "6"
                    frm.CodMon = cmbCodMon.Value
                    frm.ShowDialog()

                    '==================== MANO DE OBRA ========================
                ElseIf IdRubro = 2 Then
                    Dim frm As New frmJob_Mostrar_ManoObra
                    frm.CodJob = CodJob
                    frm.CodRubro = "1"
                    frm.CodMon = cmbCodMon.Value
                    frm.ShowDialog()

                    '===================== MATERIALES =========================
                ElseIf IdRubro = 3 Then
                    Try
                        Dim frm As New frmJob_Mostrar_Materiales
                        Dim dtMateriales As DataTable
                        frm.CodJob = CodJob
                        frm.CodRubro = "4"
                        frm.CodMon = cmbCodMon.Value
                        frm.Anio = Anio
                        dtMateriales = oGastoRealService.Filtrar(Anio, CodJob, "4", 0, "", "", "", 0).Tables(0)

                        If dtMateriales.Rows.Count > 0 Then
                            frm.MostrarMat = True
                        Else : frm.MostrarMat = False
                        End If
                        frm.ShowDialog()
                    Catch ex As Exception
                        MsgBox("ERROR AL MOSTRAR LOS MATERIALES " + ex.Message)
                    End Try

                    '===================== IMPLEMENTOS DE SEGURIDAD =========================
                ElseIf IdRubro = 9 Then
                    Try
                        Dim frm As New frmJob_Mostrar_Materiales
                        Dim dtMateriales As DataTable
                        frm.CodJob = CodJob
                        frm.CodRubro = "15"
                        frm.CodMon = cmbCodMon.Value
                        frm.Anio = Anio
                        dtMateriales = oGastoRealService.Filtrar(Anio, CodJob, "15", 0, "", "", "", 0).Tables(0)

                        If dtMateriales.Rows.Count > 0 Then
                            frm.MostrarMat = True
                        Else : frm.MostrarMat = False
                        End If
                        frm.ShowDialog()
                    Catch ex As Exception
                        MsgBox("ERROR AL MOSTRAR LOS MATERIALES " + ex.Message)
                    End Try

                    '================ TRABAJO DE TERCEROS ====================
                ElseIf IdRubro = 4 Then
                    Dim frm As New frmJob_Mostrar_Terceros
                    frm.CodJob = CodJob
                    frm.CodRubro = "2"
                    frm.ShowDialog()
                    If frm.Actualizar = True Then
                        ObtenerRegistro()
                    End If

                    '=================== GASTOS DE VIAJE =======================
                ElseIf IdRubro = 5 Then
                    Dim frm As New frmJob_Mostrar_GastosViaje
                    frm.CodJob = CodJob
                    frm.CodRubro = "3"
                    frm.ShowDialog()

                    '======================= VARIOS ===========================
                ElseIf IdRubro = 6 Then
                    Dim frm As New frmJob_Mostrar_Varios
                    frm.CodJob = CodJob
                    frm.CodRubro = "5"
                    frm.ShowDialog()
                    If frm.Actualizar = True Then
                        ObtenerRegistro()
                    End If

                    '===================== REF. Y MOV. =========================
                ElseIf IdRubro = 8 Then
                    Dim frm As New frmJob_Mostrar_RefrigMovil
                    frm.CodJob = CodJob
                    frm.CodRubro = "7"
                    frm.ShowDialog()
                    If frm.Actualizar = True Then
                        ObtenerRegistro()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar Detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function SumarDescuento() As Double
        Try
            Dim totalDscto As Double = 0
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim bSelected As Boolean
            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                bSelected = row.Cells("MontoDscto").Value
                If bSelected Then
                    totalDscto = totalDscto + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoDscto").Value)
                End If
            Next
            Return totalDscto
        Catch ex As Exception
            MsgBox("Error al sumar Montos" + ex.Message)
        End Try
    End Function

    Private Sub cmbTipoJob_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoJob.ValueChanged
        'Se agrega el tipo de Job '4' Asesoría a pedido de la Sra Dolores 
        If toNumber(cmbTipoJob.Value) = 1 Or toNumber(cmbTipoJob.Value) = 4 Then
            cmbCodMon.Value = "NS"
        End If

        If toNumber(cmbTipoJob.Value) = 1 Then
            txtMontoHrsHombre.ReadOnly = False
            txtMontoHrsHombre.BackColor = System.Drawing.SystemColors.Window
        Else
            txtMontoHrsHombre.ReadOnly = True
            txtMontoHrsHombre.BackColor = System.Drawing.SystemColors.Control
            txtMontoHrsHombre.Value = 0.0
        End If
    End Sub


End Class