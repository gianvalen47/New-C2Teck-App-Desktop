Imports System.Data.OleDb
Imports System.ServiceModel
Imports System.Xml
Imports System.IO

Public Class frmComSolicitudGasto

    '===========================Servicios====================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oCuentaContableService As New CuentaContableService.CuentaContableServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private Persona As New PersonaService.Persona
    Private oEmpresaUsuario As New EmpresaUsuarioService.EmpresaUsuarioServiceClient
    Private empresaUsuario As New EmpresaUsuarioService.EmpresaUsuario

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True          'True: Editable     False: No Editable

    Public iEstado As Integer
    Public IdGasto As Integer
    Public IdPersonaSolicita As Integer
    'Public iCodJob As String                 'Se comenta ya que se procesará el Job desde el detalle de solictud de gastos 05/05/2014
    'Public iProcesoJob As Boolean       'Se comenta ya que se procesará el Job desde el detalle de solictud de gastos 05/05/2014
    Private dtDatos As DataTable
    Private dtAreas As DataTable
    Private dtMonedas As DataTable
    Private dtCorreos As DataTable
    Private dtProvisional As DataTable

    'Public CodJob As String             'Numero de Job ingresado en el primer detalle (en caso que cbGastoViaje = True)  'Se comenta ya que se ingresara el Job en la cabecera cuando cbGastoViaje = True 24/04/2014
    Public IdDestino As Integer         'Destino de Viaje ingresado en el primer detalle (en caso que cbGastoViaje = True)
    Public iCentroCosto As String     'Centro de Costo de solicitante

    '------------- Variables para exportación a Excel -----------
    Private DirFile As String
    Private fileExt As String
    Private dtDatosExcel As DataTable
    '----------------------------------------------------------------------------
    Private Igv As Double = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", 1))

    Private dtDestino As DataTable

    Private Sub frmComSolicitudGasto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iEstado = oSolicitudGastoService.ObtenerEstado(IdGasto)
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        estilo.cargaEstiloGridExt(dgvCorreos)
        dgvDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvCorreos.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEstado.Visible = True
            gbDetalle.Visible = True
            actualizarDetalles()
            listaCorreos()
            If iEstado <> 1 Then
                If iEstado = 3 Or iEstado = 5 Or iEstado = 7 Then
                    dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
                    Me.Size = New System.Drawing.Size(915, 594)
                    gbCorreos.Visible = False
                Else
                    Me.Size = New System.Drawing.Size(915, 594)
                    gbCorreos.Visible = False
                    dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
                End If
            Else
                dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
                Me.Size = New System.Drawing.Size(915, 742)
                gbCorreos.Visible = True
            End If
            Me.Text = "SOLICITUD DE GASTOS Nº " + Chr(34) + txtNumGasto.Text.ToString + Chr(34)
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            cmbMoneda.Value = "NS"
            Me.Size = New System.Drawing.Size(915, 285)
            cbGastoViaje.Checked = False
            gbTipo.Enabled = False
            gbEstado.Visible = False
            gbDetalle.Visible = False
            gbCorreos.Visible = False
            Me.Text = "Registrar nueva Solicitud de Gastos"
            activar()
            ObtenerSolicitante()
            txtFecha.Value = Today
            txtFecha.Select()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGasto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoService.Close()
            oSolicitudGastoDetService.Close()
            oAsignacionJefesService.Close()
            oMaestroService.Close()
            oJobService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
            oCentroCostoService.Close()
            oCuentaContableService.Close()
            oEmpresaUsuario.Close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
            oSolicitudGastoDetService.Abort()
            oAsignacionJefesService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oCentroCostoService.Abort()
            oCuentaContableService.Abort()
            oEmpresaUsuario.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
            oSolicitudGastoDetService.Abort()
            oAsignacionJefesService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
            oCentroCostoService.Abort()
            oCuentaContableService.Abort()
            oEmpresaUsuario.Abort()
        End Try
    End Sub

    Private Sub txtPersonaSolicita_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPersonaSolicita.TextChanged
        Persona = oPersonaService.Obtener(IdPersonaSolicita)
        cmbArea.Value = Persona.CentroCosto.Area.CodArea
        iCentroCosto = Persona.CentroCosto.CodCentro
        lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(Persona.CentroCosto.Area.CodArea)
        listaProvisionales()
        cbGastoViaje_CheckedChanged(sender, e)
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub listaProvisionales()
        Try
            '========================================== PROVISIONALES ===============================================
            dtProvisional = oSolicitudGastoService.MostrarProvisionales(IdPersonaSolicita).Tables(0)
            dtProvisional.Rows.InsertAt(getRowTodos(dtProvisional), 0)
            cmbProvisional.DataSource = dtProvisional
            cmbProvisional.DropDownList.DataMember = dtProvisional.Columns("IdProvisional").ToString
            cmbProvisional.DropDownList.DisplayMember = dtProvisional.Columns("IdProvisional").ToString
            cmbProvisional.DropDownList.ValueMember = dtProvisional.Columns("IdProvisional").ToString
            cmbProvisional.DropDownList.Columns(0).DataMember = dtProvisional.Columns("IdProvisional").ToString
            cmbProvisional.DropDownList.Columns(1).DataMember = dtProvisional.Columns("IdProvisional").ToString
            cmbProvisional.SelectedIndex = 0
            dtProvisional = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR PROVISIONALES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdGastoDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing

            '======================================= DESTINOS ==============================================
            dtDestino = oSolicitudGastoDetService.MostrarDestinos.Tables(0)
            dtDestino.Rows.InsertAt(getRowTodos(dtDestino), 0)
            cmbDestinoViaje.DataSource = dtDestino
            cmbDestinoViaje.DropDownList.DataMember = dtDestino.Columns("DesDestino").ToString
            cmbDestinoViaje.DropDownList.DisplayMember = dtDestino.Columns("DesDestino").ToString
            cmbDestinoViaje.DropDownList.ValueMember = dtDestino.Columns("IdDestino").ToString
            cmbDestinoViaje.DropDownList.Columns(0).DataMember = dtDestino.Columns("IdDestino").ToString
            cmbDestinoViaje.DropDownList.Columns(1).DataMember = dtDestino.Columns("DesDestino").ToString
            cmbDestinoViaje.SelectedIndex = 0
            dtDestino = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerSolicitante()
        Try
            empresaUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp)
            'Dim usuario As New SeguridadService.Usuario
            'usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
            'IdPersonaSolicita = usuario.Persona.IdPer
            'txtPersonaSolicita.Text = usuario.Persona.ApeNom

            IdPersonaSolicita = empresaUsuario.Persona.IdPer
            txtPersonaSolicita.Text = empresaUsuario.Persona.ApeNom


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub enableOpciones()
        Try
            iEstado = oSolicitudGastoService.ObtenerEstado(IdGasto)
            If dgvDatos.RowCount < 1 Then
                miMostrar.Enabled = False
                miEliminar.Enabled = False
                miActivarMasivo.Enabled = False
                'miMostrarCompras.Enabled = False
                'miProcesarJob.Enabled=False
                miMostrarDetPlanilla.Enabled = False
            Else
                'iProcesoJob = toBoolean(dgvDatos.CurrentRow.Cells("ProcesoJob2").Value)
                miMostrar.Enabled = True
                miEliminar.Enabled = IIf(editable And iEstado = 1, True, False)
                miActivarMasivo.Enabled = IIf((Session.CodPerfil = "22" Or Session.CodPerfil = "01" Or Session.CodPerfil = "12" Or Session.CodPerfil = "11" Or Session.CodPerfil = "05") And iEstado = 3, True, False) 'Se agrega el perfiles Solicitud de Usuario 65887,65888
                'miMostrarCompras.Enabled = True
                miMostrarDetPlanilla.Enabled = IIf(oSolicitudGastoDetService.BuscarPlanilla(toNumber(dgvDatos.CurrentRow.Cells("IdGastoDet").Value)), True, False)
                '--------------------------------------------- Se comenta ya que se procesará el Job desde el detalle de la solictud de gastos 05/05/2014 ---------------------------------------------------------
                'miProcesarJob.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (iCodJob <> "" Or iCodJob <> Nothing) And (iEstado = 3 Or iEstado = 5) And Not iProcesoJob, True, False)             
                'dgvDatos.RootTable.Columns(0).Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (iEstado = 3 Or iEstado = 5 Or iEstado = 7), True, False)
                'dgvDatos.RootTable.Columns(7).Width = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (iEstado = 3 Or iEstado = 5 Or iEstado = 7), "128", "150")
                '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            End If
            miNuevoDetViaje.Enabled = IIf(editable And iEstado = 1 And (rbViajeNacional.Checked = True Or rbViajeExterior.Checked = True), True, False)
            miNuevo.Enabled = IIf(editable And iEstado = 1, True, False)
            miProcesarViatico.Enabled = IIf(editable And iEstado = 1 And (Session.CodPerfil = "30" Or Session.CodPerfil = "24" Or Session.CodPerfil = "25" Or Session.CodPerfil = "01" Or Session.CodPerfil = "15"), True, False)
            biEditarr.Enabled = IIf(editable, Not edicion, False)
            biCerrar.Enabled = Not edicion
            biAprobar.Enabled = IIf(Not edicion And (iEstado = 8 Or iEstado = 2), True, False)
            biGuardar.Enabled = edicion
            biDeshacerr.Enabled = edicion
            'Se inhabilita esta opción ya que se agrego los detalles de centro de costo y de Job (Se volvera a replantear)
            biActualizarJob.Enabled = False   '(Not edicion And cbGastoViaje.Checked And iEstado = 1 And (Session.CodPerfil = "01" Or Session.CodPerfil = "25" Or Session.CodPerfil = "17" Or Session.CodPerfil = "24" Or Session.CodPerfil = "42"))
            miImportarExcel.Enabled = IIf(editable And iEstado = 1, True, False)
            cmOpciones.Enabled = IIf(Not edicion, True, False)
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        Try
            Dim estado_process As Boolean
            If Not (dgvDatos.CurrentRow.Cells("CodCuenta").Text = "") Then
                If oCuentaContableService.BuscarCuenta(Session.sCodEmp, dgvDatos.CurrentRow.Cells("CodCuenta").Value) Then
                    estado_process = oSolicitudGastoDetService.ActualizarNumeroCuenta(dgvDatos.CurrentRow.Cells("IdGastoDet").Value, IdGasto, dgvDatos.CurrentRow.Cells("CodCuenta").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = False Then
                        MsgBox("Error al Actualizar Número de Cuenta Contable...")
                    End If
                Else
                    MsgBox("Número de Cuenta Contable no existente, Verifique")
                    dgvDatos.CurrentRow.Cells("CodCuenta").Text = ""
                End If
            Else
                estado_process = oSolicitudGastoDetService.ActualizarNumeroCuenta(dgvDatos.CurrentRow.Cells("IdGastoDet").Value, IdGasto, Nothing, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = False Then
                    MsgBox("Error al Actualizar Número de Cuenta Contable...")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al actualizar la cuenta contable: " + ex.Message)
        End Try
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub activar()
        If state_button Then
            If dgvDatos.RowCount < 1 Then
                cmbMoneda.ReadOnly = False
                cmbMoneda.BackColor = System.Drawing.SystemColors.Window
                cbGastoViaje.Enabled = True
            Else
                cmbMoneda.ReadOnly = True
                cmbMoneda.BackColor = System.Drawing.SystemColors.Control
                cbGastoViaje.Enabled = False
            End If
            txtNumGasto.ReadOnly = True
            txtNumGasto.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersonaS.Enabled = False
            If cbGastoViaje.Enabled = True And cbGastoViaje.Checked = True Then
                gbGastoViaje.Enabled = True
                gbTipo.Enabled = True
                txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True
                cmbProvisional.ReadOnly = False
                cmbProvisional.BackColor = System.Drawing.SystemColors.Window
            Else
                gbGastoViaje.Enabled = False
                gbTipo.Enabled = False
                txtNumJob.ReadOnly = True
                txtNumJob.BackColor = System.Drawing.SystemColors.Control
                btnBuscarJob.Enabled = False
                cmbProvisional.ReadOnly = True
                cmbProvisional.BackColor = System.Drawing.SystemColors.Control
            End If
            txtObsGasto.ReadOnly = False
            txtObsGasto.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtObsGasto.Focus()
        Else
            txtNumGasto.ReadOnly = True
            txtNumGasto.BackColor = System.Drawing.SystemColors.Control
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            btnBuscarPersonaS.Enabled = True
            cbGastoViaje.Enabled = True
            If cbGastoViaje.Enabled = True And cbGastoViaje.Checked = True Then
                gbGastoViaje.Enabled = True
                gbTipo.Enabled = True
                cmbProvisional.ReadOnly = False
                cmbProvisional.BackColor = System.Drawing.SystemColors.Window
                txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True
            Else
                gbGastoViaje.Enabled = False
                gbTipo.Enabled = False
                cmbProvisional.ReadOnly = True
                cmbProvisional.BackColor = System.Drawing.SystemColors.Control
                txtNumJob.ReadOnly = True
                txtNumJob.BackColor = System.Drawing.SystemColors.Control
                btnBuscarJob.Enabled = False
            End If
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtObsGasto.ReadOnly = False
            txtObsGasto.BackColor = System.Drawing.SystemColors.Window
            edicion = True
            enableOpciones()
            txtObsGasto.Focus()
        End If
    End Sub

    Private Sub desactivar()
        txtNumGasto.ReadOnly = True
        txtNumGasto.BackColor = System.Drawing.SystemColors.Control
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        btnBuscarPersonaS.Enabled = False
        cbGastoViaje.Enabled = False
        gbGastoViaje.Enabled = False
        gbTipo.Enabled = False
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        btnBuscarJob.Enabled = False
        cmbProvisional.ReadOnly = True
        cmbProvisional.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtObsGasto.ReadOnly = True
        txtObsGasto.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
        txtFecha.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf toNumber(IdPersonaSolicita) = 0 Then
                MsgBox("Debe Ingresar la Persona que Solicita la Orden ", MsgBoxStyle.Information, "Información")
                txtPersonaSolicita.BackColor = Color.Red
                btnBuscarPersonaS.Focus()
                Return False
            ElseIf toBlank(cmbArea.Value) = "" Then
                MsgBox("Debe de Ingresar el Área.", MsgBoxStyle.Information, "Información")
                cmbArea.BackColor = Color.Red
                cmbArea.Focus()
                Return False
                'ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then         'Se comenta 07/08/2017 ya que se valida en el detalle
                '    MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                '    txtFecha.BackColor = Color.Red
                '    txtFecha.Focus()
                '    Return False
            ElseIf (cbGastoViaje.Checked = True And (cmbArea.Value = "05" Or cmbArea.Value = "20")) And txtNumJob.Text = "" Then
                MsgBox("Debe ingresar el número de Job", MsgBoxStyle.Information, "Información")
                txtNumJob.Focus()
                Return False
            ElseIf cbGastoViaje.Checked = True And cmbProvisional.SelectedIndex = 0 Then
                MsgBox("Debe ingresar el Provisional", MsgBoxStyle.Information, "Información")
                cmbProvisional.Focus()
                Return False
            ElseIf cbGastoViaje.Checked = True And cmbDestinoViaje.SelectedIndex = 0 Then
                MsgBox("Debe ingresar el Destino de Viaje", MsgBoxStyle.Information, "Información")
                cmbDestinoViaje.Focus()
                Return False
            ElseIf cbGastoViaje.Checked = True And toBlank(txtFecInicio.Text) = "" Then 'Se valida que la fecha del gasto sea obligatoria en cualquier caso
                MsgBox("Debe Ingresar la fecha Inicio del Viaje.", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            ElseIf cbGastoViaje.Checked = True And toBlank(txtFecFinal.Text) = "" Then 'Se valida que la fecha del gasto sea obligatoria en cualquier caso
                MsgBox("Debe Ingresar la fecha Final del Viaje.", MsgBoxStyle.Information, "Información")
                txtFecFinal.Focus()
                Return False
            ElseIf cbGastoViaje.Checked = True And txtObsGasto.Text = "" Then
                MsgBox("Debe ingresar la observación del Gasto de Viaje", MsgBoxStyle.Information, "Información")
                txtObsGasto.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
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

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudGastoService.SolicitudGasto
            oSolicitudGastoService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            registro = oSolicitudGastoService.Obtener(IdGasto)

            IdGasto = registro.IdGasto
            txtNumGasto.Text = registro.IdGasto
            txtFecha.Value = registro.Fecha
            cmbArea.Value = registro.Area.CodArea
            cmbMoneda.Value = registro.Moneda.CodMon
            lblEstado.Text = registro.EstadoSolicitudGasto.DesEstado
            IdPersonaSolicita = registro.PersonaSolicita.IdPer
            listaProvisionales()
            txtPersonaSolicita.Text = registro.PersonaSolicita.ApeNom
            txtPersonaAutoriza.Text = registro.PersonaJefe.ApeNom

            If registro.DestinosViaje.IdDestino Is Nothing Or registro.DestinosViaje.IdDestino = 0 Then
                cmbDestinoViaje.SelectedIndex = 0
            Else
                cmbDestinoViaje.Value = registro.DestinosViaje.IdDestino
            End If

            If Not (registro.FecInicio.ToString = "") Then
                txtFecInicio.Value = CDate(registro.FecInicio)
                txtFecInicio.Text = registro.FecInicio.ToString
            End If
            If Not (registro.FecFinal.ToString = "") Then
                txtFecFinal.Value = CDate(registro.FecFinal)
                txtFecFinal.Text = registro.FecFinal.ToString
            End If

            '-------------- Modificado el 14/05/2012 para ingresar gastos de viaje en solicitud de gastos -------------
            cbGastoViaje.Checked = IIf(registro.GastoViaje Or registro.GastoViajeExt, True, False)
            rbViajeNacional.Checked = registro.GastoViaje
            rbViajeExterior.Checked = registro.GastoViajeExt
            If registro.Provisional.IdProvisional = Nothing Or registro.Provisional.IdProvisional = 0 Then
                cmbProvisional.SelectedIndex = 0
            Else
                cmbProvisional.Value = registro.Provisional.IdProvisional
            End If
            txtNumJob.Text = registro.Job.CodJob     'Agregado el 24/04/2014 quedando que se ingresa el Job en la cabecera cuando es Gasto de Viaje
            '------------------------------------------------------------------------------------------------------------------------------------------
            txtObsGasto.Text = registro.Observacion
            If state_button Then
                lblTotalMontoSinIgv.Text = "Monto Total Sin Igv  " + cmbMoneda.Text
                txtTotalMontoSinIgv.Value = registro.TotalMontoSinIgv
                lblMontoTotal.Text = "Monto Total  " + cmbMoneda.Text
                txtMontoTotal.Value = registro.TotalMonto
                lblMontoNoAfecto.Text = "Monto Total No Afecto Al Igv  " + cmbMoneda.Text
                txtMontoNoAfecto.Value = registro.TotalNoAfecto
                lblMontoTotalNeto.Text = "Monto Total Neto " + cmbMoneda.Text
                txtMontoTotalNeto.Value = registro.TotalNeto
            End If
            Me.Text = "Solicitud de Gasto Nº " + registro.IdGasto.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            '=================================== GASTO DE VIAJE ===================================
            If cbGastoViaje.Checked = True Then
                Dim lLog As Boolean = True
                While lLog
                    Dim frm As New frmComSolicitudGastoDetNew
                    frm.state_button = False
                    frm.edicion = True
                    frm.editable = True
                    frm.IdGasto = IdGasto
                    frm.txtIgv.Text = Igv
                    frm.IdPersonaSolicita = IdPersonaSolicita
                    frm.GastoViaje = cbGastoViaje.Checked 'Check Gasto de Viaje de la Cabecera
                    frm.Moneda = cmbMoneda.Value
                    frm.IdDestino = IIf(cmbDestinoViaje.SelectedIndex = 0, 0, cmbDestinoViaje.Value)
                    If dgvDatos.RowCount > 0 Then
                        frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
                        'frm.IdDestino = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdDestino").Value), 0, dgvDatos.CurrentRow.Cells("IdDestino").Value)
                        frm.DestinoEnable = False
                    Else
                        frm.txtItem.Text = 1
                        'frm.DestinoEnable = True
                    End If
                    frm.estado = 1
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        dtDatos = Nothing
                        listaDatos()
                        ObtenerRegistro()
                        If frm.type_process = "insert" Then
                            RowPossesion(dgvDatos, frm.IdGastoDet)
                        End If
                    Else
                        lLog = False
                    End If
                End While

            Else      '============================ <> GASTO DE VIAJE =============================
                Dim frm As New frmComSolicitudGastoDetNew
                frm.state_button = False
                frm.edicion = True
                frm.editable = True
                frm.IdGasto = IdGasto
                frm.txtIgv.Text = Igv
                frm.IdPersonaSolicita = IdPersonaSolicita
                frm.GastoViaje = cbGastoViaje.Checked 'Check Gasto de Viaje de la Cabecera
                frm.Moneda = cmbMoneda.Value
                frm.IdDestino = IIf(cmbDestinoViaje.SelectedIndex = 0, 0, cmbDestinoViaje.Value)
                If dgvDatos.RowCount > 0 Then
                    frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
                    'frm.DestinoEnable = True
                Else
                    frm.txtItem.Text = 1
                    'frm.DestinoEnable = True
                End If
                frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdGastoDet)
                        Mostrar()
                        actualizarDetalles()
                    End If
                    enableOpciones()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("Item").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSolicitudGastoDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdGastoDet").Value), toNumber(txtNumGasto.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Mostrar()
        Try
            Dim frm As New frmComSolicitudGastoDetNew
            frm.state_button = True
            frm.IdGastoDet = dgvDatos.CurrentRow.Cells("IdGastoDet").Text
            frm.IdGasto = IdGasto
            frm.estado = oSolicitudGastoService.ObtenerEstado(IdGasto)
            frm.GastoViaje = cbGastoViaje.Checked 'Check Gasto de Viaje de la Cabecera            
            frm.DestinoEnable = IIf(cbGastoViaje.Checked = True, False, True) 'Inhabilitar cmbDestinoViaje cuando sea Gasto de Viaje
            frm.IdPersonaSolicita = IdPersonaSolicita
            frm.editable = IIf(frm.estado = 1 Or frm.estado = 2 Or frm.estado = 3 Or (frm.estado = 5 And (Session.CodPerfil = "22" Or Session.CodPerfil = "01" Or Session.CodPerfil = "11" Or Session.CodPerfil = "05")), True, False) 'Se agrega el perfiles Solicitud de Usuario 65887,65888
            frm.edicion = False
            frm.Moneda = cmbMoneda.Value
            frm.IdDestino = IIf(cmbDestinoViaje.SelectedIndex = 0, 0, cmbDestinoViaje.Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdGastoDet)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            actualizarDetalles()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdGastoDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SolicitudGastoService.SolicitudGasto)
        Try
            Dim estado_process As Integer
            estado_process = oSolicitudGastoService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdGasto = estado_process
                MsgBox("Se inserto la Solicitud de Gasto Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR SOLICITUD DE GASTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As SolicitudGastoService.SolicitudGasto)
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGastoService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Solicitud de Gasto Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR SOLICITUD DE GASTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oSolicitudGastoService.Borrar(IdGasto, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR SOLICITUD DE GASTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSolicitudGastoDetService.Mostrar(toNumber(IdGasto)).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
            If Session.CodPerfil = "01" Or Session.CodPerfil = "22" Or Session.CodPerfil = "12" Or Session.CodPerfil = "11" Or Session.CodPerfil = "05" Then 'Se agrega el perfiles Solicitud de Usuario 65887,65888
                dgvDatos.RootTable.Columns("CodCuenta").EditType = Janus.Windows.GridEX.EditType.TextBox
            Else
                dgvDatos.RootTable.Columns("CodCuenta").EditType = Janus.Windows.GridEX.EditType.NoEdit
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersonaSolicita_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersonaSolicita = frm.codigo
                    txtPersonaSolicita.Text = frm.descripcion
                    txtObsGasto.Focus()
                Else
                    IdPersonaSolicita = 0
                    txtPersonaSolicita.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New SolicitudGastoService.SolicitudGasto
                Dim area As New SolicitudGastoService.Area
                Dim Moneda As New SolicitudGastoService.Moneda
                Dim empresa As New SolicitudGastoService.Empresa
                Dim personaSolicita As New SolicitudGastoService.Persona
                Dim estado As New SolicitudGastoService.EstadoSolicitudGasto
                Dim Provisional As New SolicitudGastoService.Provisional
                Dim Job As New SolicitudGastoService.Job
                Dim Destino As New SolicitudGastoService.DestinosViaje

                registro.IdGasto = IdGasto
                registro.Fecha = txtFecha.Value
                area.CodArea = cmbArea.Value
                registro.Area = area
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                personaSolicita.IdPer = IdPersonaSolicita
                registro.PersonaSolicita = personaSolicita
                '-------------- Modificado el 14/05/2012 para ingresar gastos de viaje en solicitud de gastos  ---------
                registro.GastoViaje = rbViajeNacional.Checked 'registro.GastoViaje = cbGastoViaje.Checked
                registro.GastoViajeExt = rbViajeExterior.Checked
                Provisional.IdProvisional = IIf(cmbProvisional.SelectedIndex = 0 Or cbGastoViaje.Checked = False, 0, cmbProvisional.Value)
                registro.Provisional = Provisional
                '---------------------- Se agregó el Job para cuando sea gasto de viaje 24/04/2014 ---------------------------
                Job.CodJob = IIf(txtNumJob.Text = "" Or cbGastoViaje.Checked = False, Nothing, txtNumJob.Text)
                registro.Job = Job
                '------------------------------------------------------------------------------------------------------------------------------------------

                Destino.IdDestino = IIf(CInt(cmbDestinoViaje.Value) = 0, Nothing, cmbDestinoViaje.Value)
                registro.DestinosViaje = Destino

                registro.FecInicio = IIf(txtFecInicio.Text = "", Nothing, txtFecInicio.Value)
                registro.FecFinal = IIf(txtFecFinal.Text = "", Nothing, txtFecFinal.Value)

                registro.Observacion = txtObsGasto.Text
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                registro.CodUsu = Session.sCodUsu
                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    estado.IdEstado = 1
                    registro.EstadoSolicitudGasto = estado
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR SOLICITUD DE GASTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub biDeshacerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacerr.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditarr.Click
        activar()
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Dim estado As Integer
        estado = oSolicitudGastoService.ObtenerEstado(CInt(txtNumGasto.Text))
        If state_button = True And estado = 1 Then
            Nuevo()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdGastoDet").Text
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

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If cmOpciones.Enabled = True Then
            If ValidaCodigoSeleccionado() Then
                Mostrar()
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
            '============== Agregado por pedido de la Sra Gladys 08-03-13 ==============
        ElseIf (e.KeyCode = Keys.F1) And (iEstado = 3 Or iEstado = 5 Or iEstado = 7) Then
            Dim frm As New frmBuscarCuentaContable
            Dim estado_process As Boolean
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    dgvDatos.CurrentRow.Cells("CodCuenta").Value = frm.codigo
                Else
                    dgvDatos.CurrentRow.Cells("CodCuenta").Value = ""
                End If
                estado_process = oSolicitudGastoDetService.ActualizarNumeroCuenta(dgvDatos.CurrentRow.Cells("IdGastoDet").Value, IdGasto, dgvDatos.CurrentRow.Cells("CodCuenta").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = False Then
                    MsgBox("Error al Actualizar Número de Cuenta Contable...")
                End If
            End If
        End If
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbMoneda.Focus()
        End If
    End Sub

    Private Sub cmbMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtPersonaSolicita.Focus()
        End If
    End Sub

    Private Sub txtPersonaSolicita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersonaSolicita.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersonaS.Enabled = True Then
                e.Handled = True
                btnBuscarPersonaSolicita_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtPersonaSolicita_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPersonaSolicita.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cbGastoViaje.Focus()
        End If
    End Sub

    Private Sub cbGastoViaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbGastoViaje.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtNumJob.Focus()
        End If
    End Sub

    Private Sub txtNumJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbProvisional.Focus()
        End If
    End Sub

    Private Sub cmbProvisional_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtObsGasto.Focus()
        End If
    End Sub

    '==================== Se comenta ya que se procesara el Job desde la grilla de Solicitud de gasto detalle ===================
    'Private Sub miProcesarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miProcesarJob.Click
    'Try
    '    If dgvDatos.RowCount > 0 Then
    '        If MsgBox("¿Está seguro de Ingresar el Gasto N° " & dgvDatos.CurrentRow.Cells("IdGastoDet").Value & " al Job Nº " & dgvDatos.CurrentRow.Cells("CodJob").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
    '            Dim estado_process As Boolean
    '            estado_process = oSolicitudGastoDetService.ProcesarJob(dgvDatos.CurrentRow.Cells("IdGastoDet").Value, dgvDatos.CurrentRow.Cells("IdGasto").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '            If estado_process Then
    '                MsgBox("Se Ingresó el Gasto al Job correctamente")
    '                actualizar()
    '            Else
    '                MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
    '            End If
    '        End If
    '    Else
    '        MsgBox("No existen datos, Verifique...")
    '    End If
    'Catch ex As Exception
    '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    'End Try
    'End Sub

    Private Sub biAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.Click
        Try
            If txtNumGasto.Text <> "" Then
                If cbGastoViaje.Checked = True And oSolicitudGastoDetService.BuscarNoAplicaTarifa(IdGasto) = True Then
                    If MsgBox("La Solicitud de Gastos N°: " & IdGasto & " presenta detalles donde No Aplica Tarifa ¿Está seguro de Continuar?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim frm As New frmComSolicitudGasto_Aprobar
                        frm.IdGasto = toNumber(txtNumGasto.Text)
                        frm.IdEstado = oSolicitudGastoService.ObtenerEstado(toNumber(txtNumGasto.Text))
                        frm.IdPersonaSolicita = IdPersonaSolicita
                        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                            ObtenerRegistro()
                            actualizarDetalles()
                        End If
                    End If
                Else
                    Dim frm As New frmComSolicitudGasto_Aprobar
                    frm.IdGasto = toNumber(txtNumGasto.Text)
                    frm.IdEstado = oSolicitudGastoService.ObtenerEstado(toNumber(txtNumGasto.Text))
                    frm.IdPersonaSolicita = IdPersonaSolicita
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        ObtenerRegistro()
                        actualizarDetalles()
                    End If
                End If
            Else
                MsgBox("Número de Gasto no válido...")
            End If
        Catch ex As Exception
            MsgBox("Error al APROBAR la Solicitud de Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaCorreos()
        Try
            dtCorreos = oAsignacionJefesService.MostrarJefeArea(iCentroCosto).Tables(0)
            dgvCorreos.DataSource = dtCorreos
        Catch ex As Exception
            MsgBox("Error al listar correos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ENVIAR la Solicitud de Gasto Nº" & txtNumGasto.Text & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    Dim rows() As Janus.Windows.GridEX.GridEXRow
                    Dim Cadena As String = ""
                    rows = dgvCorreos.GetCheckedRows()
                    Dim row As Janus.Windows.GridEX.GridEXRow

                    If rows.Count <> 0 Then
                        For Each row In rows
                            If Cadena = "" Then
                                Cadena = row.Cells("Email").Text
                            Else
                                Cadena = Cadena + ";" + row.Cells("Email").Text
                            End If
                        Next
                        '=================================Enviar a Correos Seleccionados=================================
                        Dim estado_process As Boolean
                        estado_process = oSolicitudGastoService.Enviar(IdGasto, Cadena, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If estado_process Then
                            MsgBox("Se envió correctamente la Solicitud de Gastos", MsgBoxStyle.Information)
                            ObtenerRegistro()
                            enableOpciones()
                            Me.Size = New System.Drawing.Size(905, 552)
                            gbCorreos.Visible = False
                        Else
                            MsgBox("Error en el Proceso ,Comunicarse con el Administrador del Sistema")
                        End If
                    Else
                        MsgBox("Debe seleccionar alguno de los correos")
                    End If
                End If
            Else
                MsgBox("Debe ingresar los detalles", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Error al Enviar la Solicitud de Gastos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miActivarMasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActivarMasivo.Click
        Try
            Dim frm As New frmComSolicitudGasto_ActCuenta
            frm.IdGasto = IdGasto
            frm.Masivo = True
            frm.dtDetalles = dtDatos.Copy
            frm.dgvDatos.DataSource = dgvDatos.DataSource
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                miActualizar_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR el Nro de Cuenta Masivo: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '============== Se Comenta ya que se actualizara la cuneta contable desde la grilla de solictud de gasto ====================
    'Private Sub miActCuentaContable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActCuentaContable.Click
    '    Try
    '        If ValidaCodigoSeleccionado() Then
    '            Dim frm As New frmComSolicitudGasto_ActCuenta
    '            frm.IdGasto = IdGasto
    '            frm.IdGastoDet = CInt(dgvDatos.CurrentRow.Cells("IdGastoDet").Text)
    '            frm.Masivo = False
    '            frm.dtDetalles = Nothing
    '            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '                miActualizar_Click(sender, e)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al ACTUALIZAR el Número de cuenta Contable: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub miProcesarViatico_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miProcesarViatico.Click
        Try
            Dim frm As New frmComSolicitudGasto_Viatico
            frm.IdGasto = toNumber(txtNumGasto.Text)
            frm.CodMon = cmbMoneda.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                If dgvDatos.RowCount > 0 And frm.state_process > 0 Then
                    RowPossesion(dgvDatos, frm.state_process)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al INGRESAR Viáticos a la Solicitud de Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '========================= Se comenta ya que se procesara el Job desde la grilla de solicitud de gasto detalle ======================
    'Private Sub dgvDatos_EditingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.EditingCellEventArgs) Handles dgvDatos.EditingCell
    '    Try
    '        Dim Check As String = ""

    '        If e.Column.ActAsSelector Then
    '            Check = Me.dgvDatos.GetValue("ProcesoJob2").ToString.Trim
    '            If Check = False Then

    '                Dim estado_process As Boolean
    '                'Dim registro As New SolicitudGastoDetService.SolicitudGastoDet
    '                'registro = oSolicitudGastoDetService.Obtener(dgvDatos.CurrentRow.Cells("IdGastoDet").Value)

    '                'iCodJob = registro.Job.CodJob
    '                iProcesoJob = dgvDatos.CurrentRow.Cells("ProcesoJob2").Value
    '                iEstado = oSolicitudGastoService.ObtenerEstado(IdGasto)

    '                'If (Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (iCodJob <> "" Or iCodJob <> Nothing) And (iEstado = 3 Or iEstado = 5 Or iEstado = 7) And Not IProcesoJob Then
    '                If (Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (iEstado = 3 Or iEstado = 5 Or iEstado = 7) And Not iProcesoJob Then
    '                    estado_process = oSolicitudGastoDetService.ProcesarJob(CInt(dgvDatos.CurrentRow.Cells("IdGastoDet").Value), CInt(dgvDatos.CurrentRow.Cells("IdGasto").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '                End If

    '                If estado_process = True Then
    '                    'MsgBox("Se Ingreso correctamente el Gasto al Job")
    '                    actualizar()
    '                    'Else
    '                    'MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
    '                End If
    '            Else
    '                MsgBox("Este Documento ya ha sido Procesado")
    '                actualizar()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al PROCESAR el Documento : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub dgvDatos_ColumnHeaderClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles dgvDatos.ColumnHeaderClick
    '    Try
    '        If dgvDatos.RootTable.Columns(e.Column.Index).Caption = "P" Then

    '            If VerificarSeleccion() = True Then

    '                If MsgBox("¿Está seguro de PROCESAR Todos los Documentos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

    '                    Dim rows() As Janus.Windows.GridEX.GridEXRow
    '                    rows = dgvDatos.GetCheckedRows()
    '                    Dim row As Janus.Windows.GridEX.GridEXRow

    '                    If rows.Count <> 0 Then
    '                        Dim estado_process As Boolean
    '                        For Each row In rows
    '                            'Dim registro As New SolicitudGastoDetService.SolicitudGastoDet
    '                            'registro = oSolicitudGastoDetService.Obtener(row.Cells("IdGastoDet").Text)
    '                            'iCodJob = registro.Job.CodJob
    '                            iProcesoJob = row.Cells("ProcesoJob2").Text
    '                            iEstado = oSolicitudGastoService.ObtenerEstado(IdGasto)
    '                            'If (Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (iCodJob <> "" Or iCodJob <> Nothing) And (iEstado = 3 Or iEstado = 5 Or iEstado = 7) And Not IProcesoJob Then
    '                            If (Session.CodPerfil = "01" Or Session.CodPerfil = "24") And (iEstado = 3 Or iEstado = 5 Or iEstado = 7) And Not iProcesoJob Then
    '                                estado_process = oSolicitudGastoDetService.ProcesarJob(row.Cells("IdGastoDet").Text, row.Cells("IdGasto").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
    '                            End If
    '                        Next
    '                        '=================================Enviar a Correos Seleccionados=================================
    '                        If estado_process Then
    '                            actualizar()
    '                        Else
    '                            MsgBox("No se Proceso Ningun Documento porque ya ha sido Procesado o No Cumple con los Requisitos")
    '                            actualizar()
    '                        End If
    '                    Else
    '                        MsgBox("Debe seleccionar alguno de los gastos a procesar")
    '                    End If
    '                End If
    '            Else
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al PROCESAR los Documentos : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Function VerificarSeleccion() As Boolean
    '    Dim rows() As Janus.Windows.GridEX.GridEXRow
    '    Dim Cadena As String = ""
    '    rows = dgvDatos.GetCheckedRows()
    '    Dim row As Janus.Windows.GridEX.GridEXRow

    '    If rows.Count <> 0 Then
    '        For Each row In rows
    '            If Cadena = "" Then
    '                Cadena = row.Cells("Item").Text
    '            Else
    '                Cadena = Cadena + ";" + row.Cells("Item").Text
    '            End If
    '        Next
    '    End If
    '    If Cadena = "" Then
    '        VerificarSeleccion = False
    '    Else
    '        VerificarSeleccion = True
    '    End If
    'End Function

    Private Sub miMostrarCompras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarCompras.Click
        'If cmOpciones.Enabled = True Then
        '    If ValidaCodigoSeleccionado() Then
        '        mostrarComprasJob()
        '    End If
        'End If
    End Sub

    ''====================== Se comenta ya que se mostrará las compras de Job desde la grilla de solicitud de gasto detalle ===================
    'Private Sub mostrarComprasJob()
    '    Try
    '        Dim registro As New SolicitudGastoDetService.SolicitudGastoDet
    '        registro = oSolicitudGastoDetService.Obtener(dgvDatos.CurrentRow.Cells("IdGastoDet").Value)
    '        iCodJob = registro.Job.CodJob
    '        If iCodJob <> "" Or iCodJob <> Nothing Then
    '            Dim frm As New frmComSolicitudGasto_Compras
    '            frm.CodJob = dgvDatos.CurrentRow.Cells("CodJob").Value
    '            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '                dtDatos = Nothing
    '                actualizarDetalles()
    '                ObtenerRegistro()
    '            End If
    '        Else
    '            MsgBox("¡Este detalle no presenta Nro de Job....!")
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL MOSTRAR COMPRAS DE JOB: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub miMostrarDetPlanilla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarDetPlanilla.Click
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetPlanilla()
            End If
        End If
    End Sub

    Private Sub mostrarDetPlanilla()
        Try
            Dim frm As New frmComSolicitudGasto_MostrarPlanilla
            frm.IdGastoDet = dgvDatos.CurrentRow.Cells("IdGastoDet").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                actualizarDetalles()
                ObtenerRegistro()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR DETALLES DE PLANILLA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cbGastoViaje_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbGastoViaje.CheckedChanged
        If cbGastoViaje.Checked = True Then
            cmbProvisional.ReadOnly = False
            cmbProvisional.BackColor = System.Drawing.SystemColors.Window
            '   gbGastoViaje.Enabled = True
            '----- Se realiza el cambio quedando que si se ingresa un personal diferente de servicio técnico el campo Job de gasto de viaje se inhabilita y se ingresa null 11/06/2014 ---
            'If cmbArea.Value = "05" Or cmbArea.Value = "20" Then
            txtNumJob.ReadOnly = False
                txtNumJob.BackColor = System.Drawing.SystemColors.Window
                btnBuscarJob.Enabled = True
            'Else
            '    txtNumJob.ReadOnly = True
            '    txtNumJob.BackColor = System.Drawing.SystemColors.Control
            '    txtNumJob.Text = ""
            '    btnBuscarJob.Enabled = False
            'End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            '      gbTipo.Enabled = True
            ' rbViajeNacional.Checked = True
        Else
            cmbProvisional.ReadOnly = True
            cmbProvisional.BackColor = System.Drawing.SystemColors.Control
            cmbProvisional.SelectedIndex = 0
            gbGastoViaje.Enabled = False
            txtNumJob.ReadOnly = True
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = ""
            btnBuscarJob.Enabled = False
            gbTipo.Enabled = False
            rbViajeNacional.Checked = False
            rbViajeExterior.Checked = False
        End If
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
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

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de Job no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbProvisional.Focus()
                End If
            Else
                cmbProvisional.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de Job no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) = 1 Then
                    MsgBox("Número de Job Anulado, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbProvisional.Focus()
                End If
            Else
                cmbProvisional.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
        End Try
    End Sub

    Private Sub biActualizarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizarJob.Click
        Try
            Dim frm As New frmComSolicitudGasto_ActualizarJob
            frm.IdGasto = IdGasto
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                miActualizar_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR el Job: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
    '    If cbGastoViaje.Checked = True Then
    '        If cmbArea.Value = "05" Then
    '            txtNumJob.ReadOnly = False
    '            txtNumJob.BackColor = System.Drawing.SystemColors.Window
    '            btnBuscarJob.Enabled = True
    '        Else
    '            txtNumJob.ReadOnly = True
    '            txtNumJob.BackColor = System.Drawing.SystemColors.Control
    '            txtNumJob.Text = ""
    '            btnBuscarJob.Enabled = False
    '        End If
    '    Else
    '        txtNumJob.ReadOnly = True
    '        txtNumJob.BackColor = System.Drawing.SystemColors.Control
    '        txtNumJob.Text = ""
    '        btnBuscarJob.Enabled = False
    '    End If
    'End Sub

    Private Sub miDescargarXml_Click(sender As System.Object, e As System.EventArgs) Handles miDescargarXml.Click
        Try
            If oSolicitudGastoDetService.BuscarXml(dgvDatos.CurrentRow.Cells("IdGastoDet").Text) = True Then
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(New StringReader(oSolicitudGastoDetService.DescargarXml(dgvDatos.CurrentRow.Cells("IdGastoDet").Text)))

                Dim NombreXMLPDF As String = oSolicitudGastoDetService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdGastoDet").Text)
                Dim Ubicacion As String

                Dim file As New SaveFileDialog()
                file.FileName = NombreXMLPDF
                file.Filter = "XML|*.xml"
                If file.ShowDialog() = DialogResult.OK Then
                    Ubicacion = file.FileName

                End If

                xmlDoc.Save(Ubicacion)
            Else
                MsgBox("No existe Documento XML, verifique...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DESCARGAR XML:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miDescargarPdf_Click(sender As System.Object, e As System.EventArgs) Handles miDescargarPdf.Click
        Try
            If oSolicitudGastoDetService.BuscarXml(dgvDatos.CurrentRow.Cells("IdGastoDet").Text) = True Then
                Dim PdfByte As Byte() = oSolicitudGastoDetService.DescargarPdf(dgvDatos.CurrentRow.Cells("IdGastoDet").Text)

                Dim NombreXMLPDF As String = oSolicitudGastoDetService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdGastoDet").Text)
                Dim Ubicacion As String

                Dim file As New SaveFileDialog()
                file.FileName = NombreXMLPDF
                file.Filter = "PDF|*.pdf"
                If file.ShowDialog() = DialogResult.OK Then
                    Ubicacion = file.FileName

                End If

                System.IO.File.WriteAllBytes(Ubicacion, PdfByte)
            Else
                MsgBox("No existe Documento XML, verifique...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DESCARGAR PDF:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miGastosReales_Click(sender As System.Object, e As System.EventArgs) Handles miGastosReales.Click
        Try
            Dim frm As New frmGastoReal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                miActualizar_Click(sender, e)
            End If            
        Catch ex As Exception
            MsgBox("Error al MOSTRAR gastos reales : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miFormatoExcel_Click(sender As System.Object, e As System.EventArgs) Handles miFormatoExcel.Click
     FormatoExcel()
    End Sub

    Private Sub FormatoExcel()

        Dim dtExcel As New DataTable("tabla2")

        'dtExcel.Columns.Add(New DataColumn("IdGasto", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Item", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Cantidad", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CodRubro", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("AfectoIgv", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("MontoAfecto", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("MontoNoAfecto", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Descripcion", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Justificacion", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Colaborador", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Proveedor", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CondicionPago", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("Documento", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("SerieDoc", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("NumDoc", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("FecDoc", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CodJob", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("CentroCosto", Type.GetType("System.String")))
        dtExcel.Columns.Add(New DataColumn("TipoGasto", Type.GetType("System.String")))

        dtExcel.Rows.Add(New Object() {"1", "1", "7", "1", "0.01", "0.01", "", "", "1", "7566", "1", "3", "0000", "0000000000", "01/01/2001", "0001/11", "05", "7"})

        dgvFormatoExcel.DataSource = dtExcel

        Dim Export As Boolean
        Export = ExportarExcel(dgvFormatoExcel)

        If Export Then
            MsgBox("Se descargo el excel correctamente")
        End If
    End Sub

    Private Sub miImportarExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miImportarExcel.Click
        OpenFileDialog1.InitialDirectory = "d:\"
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            DirFile = OpenFileDialog1.FileName
            CargadoFinal()
        End If
    End Sub

    Private Sub CargadoFinal()
        If Not OpenFileDialog1.FileName Is Nothing And OpenFileDialog1.FileName.Length > 0 Then
            fileExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
            If (fileExt <> ".xls") And (fileExt <> ".xlsx") Then
                MsgBox("¡Solo se aceptan archivos de Excel, tenga cuidado...!", MsgBoxStyle.Information)
                Exit Sub
            Else
                CargarGrilla()
            End If
        End If
    End Sub

    Private Sub CargarGrilla()
        Try
            If MsgBox("¿Está seguro de IMPORTAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvImportarExcel.DataSource = GetDataExcel(DirFile, fileExt)

                Dim estado_process As Integer = 0
                Dim state_processCC As Boolean
                Dim state_processJ As Boolean

                If dgvImportarExcel.RowCount > 0 Then

                    For Each fila As DataGridViewRow In dgvImportarExcel.Rows
                        Dim registro As New SolicitudGastoDetService.SolicitudGastoDet
                        Dim CondicionPago As New SolicitudGastoDetService.CondicionPagoProveedor
                        Dim Proveedor As New SolicitudGastoDetService.Proveedor
                        Dim SolicitudGasto As New SolicitudGastoDetService.SolicitudGasto
                        Dim TipoDocumento As New SolicitudGastoDetService.TipoDocumento
                        Dim Persona As New SolicitudGastoDetService.Persona
                        Dim Planilla As New SolicitudGastoDetService.PlanillaViatico
                        Dim Rubro As New SolicitudGastoDetService.RubroGasto
                        Dim TipoGasto As New SolicitudGastoDetService.TipoGasto
                        '------------------------------------------------------------------------------------------------------
                        Dim Destino As New SolicitudGastoDetService.DestinosViaje
                        Dim RubroViaje As New SolicitudGastoDetService.RubroViaje
                        Dim SubRubro As New SolicitudGastoDetService.SubRubroViaje
                        Dim Placa As New SolicitudGastoDetService.Unidad
                        '-----------------------------------------------------------------------------------------------------
                        Dim Embarque As New SolicitudGastoDetService.Embarque

                        Dim AfectoIgv As Boolean = toBoolean(fila.Cells("AfectoIgv").Value)
                        Dim MontoAfecto As Double = IIf(Convert.ToString(fila.Cells("MontoAfecto").Value) = "", 0.0, toDouble(fila.Cells("MontoAfecto").Value))
                        Dim MontoNoAfecto As Double = IIf(Convert.ToString(fila.Cells("MontoNoAfecto").Value) = "", 0.0, toDouble(fila.Cells("MontoNoAfecto").Value))
                        Dim MontoSinIgv As Double = IIf(AfectoIgv = True, (MontoAfecto / ((Igv + 100) / 100)) + MontoNoAfecto, MontoNoAfecto)

                        Dim dtCentroCosto As New DataTable
                        Dim dtJob As New DataTable

                        registro.IdGastoDet = 0
                        SolicitudGasto.IdGasto = IdGasto
                        SolicitudGasto.GastoViaje = cbGastoViaje.Checked
                        registro.SolicitudGasto = SolicitudGasto
                        registro.Item = toNumber(fila.Cells("Item").Value)
                        registro.Cantidad = toNumber(fila.Cells("Cantidad").Value)
                        Rubro.CodRubro = toBlank(fila.Cells("CodRubro").Value)
                        registro.RubroGasto = Rubro
                        TipoGasto.IdTipoGasto = toNumber(fila.Cells("TipoGasto").Value)
                        registro.TipoGasto = TipoGasto
                        registro.Igv = Igv
                        registro.Descripcion = IIf(Convert.ToString(fila.Cells("Descripcion").Value) = "", Nothing, Convert.ToString(fila.Cells("Descripcion").Value))
                        Planilla.IdPlanilla = Nothing
                        registro.PlanillaViatico = Planilla
                        Persona.IdPer = IIf(Convert.ToString(fila.Cells("Colaborador").Value) = "", Nothing, toNumber(fila.Cells("Colaborador").Value))
                        registro.Persona = Persona

                        Embarque.CodEmbarque = Nothing
                        registro.Embarque = Embarque

                        Proveedor.IdProveedor = IIf(Convert.ToString(fila.Cells("Proveedor").Value) = "", Nothing, toNumber(fila.Cells("Proveedor").Value))
                        registro.Proveedor = Proveedor

                        CondicionPago.IdCondicion = IIf(Convert.ToString(fila.Cells("CondicionPago").Value) = "", Nothing, toNumber(fila.Cells("CondicionPago").Value))
                        registro.CondicionPagoProveedor = CondicionPago
                        TipoDocumento.IdDocumento = IIf(Convert.ToString(fila.Cells("Documento").Value) = "", Nothing, toNumber(fila.Cells("Documento").Value))
                        registro.TipoDocumento = TipoDocumento

                        registro.Afecto = AfectoIgv
                        registro.Monto = MontoAfecto
                        registro.MontoSinIgv = MontoSinIgv
                        registro.MontoNoAfecto = MontoNoAfecto

                        registro.NumDoc = IIf(Convert.ToString(fila.Cells("NumDoc").Value) = "", Nothing, NumDoc(fila.Cells("NumDoc").Value))
                        registro.SerDoc = IIf(Convert.ToString(fila.Cells("SerieDoc").Value) = "", Nothing, SerieDoc(fila.Cells("SerieDoc").Value))

                        registro.FecDoc = IIf(Convert.ToString(fila.Cells("FecDoc").Value) = "", Nothing, Convert.ToDateTime(fila.Cells("FecDoc").Value))
                        registro.Justificacion = IIf(Convert.ToString(fila.Cells("Justificacion").Value) = "", Nothing, Convert.ToString(fila.Cells("Justificacion").Value))
                        registro.CodUsu = Session.sCodUsu
                        registro.DirIp = Session.sDirIp
                        registro.NomPc = Session.sNomPc

                        Placa.Placa = Nothing
                        registro.Unidad = Placa

                        registro.NoAplicaTarifa = False
                        'Destino.IdDestino = Nothing
                        'registro.DestinosViaje = Destino
                        SubRubro.IdSubRubro = Nothing
                        RubroViaje.IdRubro = Nothing
                        SubRubro.RubroViaje = RubroViaje
                        registro.SubRubroViaje = SubRubro

                        registro.DocumentoXml = Nothing
                        registro.DocumentoPdf = Nothing
                        registro.NombreArchivo = Nothing

                        estado_process = oSolicitudGastoDetService.Insertar(registro)

                        dtCentroCosto = AgregarCentroCosto(CodCentro(Convert.ToString(fila.Cells("CentroCosto").Value)), MontoAfecto, MontoSinIgv, MontoNoAfecto)

                        state_processCC = oSolicitudGastoDetService.InsertarCentroCosto(estado_process, IdGasto, dtCentroCosto, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If Convert.ToString(fila.Cells("CodJob").Value) <> "" Then
                            dtJob = AgregarJob(CodCentro(Convert.ToString(fila.Cells("CodJob").Value)), MontoAfecto, MontoSinIgv, MontoNoAfecto)
                            state_processJ = oSolicitudGastoDetService.InsertarJob(estado_process, IdGasto, dtJob, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        End If

                        dtCentroCosto.Clear()
                        dtJob.Clear()

                    Next

                    If estado_process > 0 Then
                        MsgBox("Se ingresó los detalles correctamente", MsgBoxStyle.Information, "Error de datos")
                        listaDatos()
                    End If
                Else
                    MsgBox("¡No existen detalles a importar...!", MsgBoxStyle.Information, "Error de datos")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al IMPORTAR los detalles: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function SerieDoc(ByVal Serie As String) As String
        Try
            Dim cant As Integer = Len(Serie)
            Do While cant < 4
                Serie = "0" & Serie
                cant = cant + 1
            Loop
            Return Serie
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
        End Try
    End Function

    Private Function NumDoc(ByVal Numero As String) As String
        Try
            Dim cant As Integer = Len(Numero)
            Do While cant < 10
                Numero = "0" & Numero
                cant = cant + 1
            Loop
            Return Numero
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL NÚMERO DEL DOCUMENTO : " + ex.Message)
        End Try
    End Function

    Private Function CodCentro(ByVal CentroCosto As String) As String
        Try
            Dim cant As Integer = Len(CentroCosto)
            Do While cant < 2
                CentroCosto = "0" & CentroCosto
                cant = cant + 1
            Loop
            Return CentroCosto
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL CENTRO DE COSTO : " + ex.Message)
        End Try
    End Function

    Private Function AgregarCentroCosto(ByVal CodCentro As String, ByVal Monto As Double, ByVal MontoSinIgv As Double, ByVal MontoNoAfecto As Double) As DataTable
        Try
            Dim dtTable As New DataTable
            Dim rows As DataRow

            dtTable = oSolicitudGastoDetService.MostrarCentro(0).Tables(0)
            dtTable.Clear()

            rows = dtTable.NewRow
            rows(0) = 0
            rows(1) = 0
            rows(2) = ""
            rows(3) = ""
            rows(4) = CodCentro
            rows(5) = ""
            rows(6) = Monto
            rows(7) = MontoSinIgv
            rows(8) = MontoNoAfecto
            rows(9) = ""

            dtTable.Rows.Add(rows)

            Return dtTable
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL CENTRO DE COSTO : " + ex.Message)
        End Try
    End Function

    Private Function AgregarJob(ByVal CodJob As String, ByVal Monto As Double, ByVal MontoSinIgv As Double, ByVal MontoNoAfecto As Double) As DataTable
        Try
            Dim dtTable As New DataTable
            Dim rows As DataRow

            dtTable = oSolicitudGastoDetService.MostrarJob(0).Tables(0)
            dtTable.Clear()

            rows = dtTable.NewRow
            rows(0) = 0
            rows(1) = 0
            rows(2) = CodJob
            rows(3) = Monto
            rows(4) = MontoSinIgv
            rows(5) = MontoNoAfecto
            rows(6) = ""
            rows(7) = False

            dtTable.Rows.Add(rows)

            Return dtTable
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
        End Try
    End Function

    Private Sub miNuevoDetViaje_Click(sender As Object, e As System.EventArgs) Handles miNuevoDetViaje.Click
        Dim estado As Integer
        estado = oSolicitudGastoService.ObtenerEstado(CInt(txtNumGasto.Text))
        If state_button = True And estado = 1 Then
            NuevoDetViaje()
        End If
    End Sub

    Private Sub NuevoDetViaje()
        Try
            '=================================== GASTO DE VIAJE ===================================

            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmComSolicitudGastoDet_Viaje
                frm.state_button = False
                frm.edicion = True
                frm.editable = True
                frm.IdGasto = IdGasto
                frm.txtIgv.Text = Igv
                frm.IdPersonaSolicita = IdPersonaSolicita
                frm.GastoViaje = cbGastoViaje.Checked 'Check Gasto de Viaje de la Cabecera
                frm.Moneda = cmbMoneda.Value
                frm.IdDestino = IIf(cmbDestinoViaje.SelectedIndex = 0, 0, cmbDestinoViaje.Value)
                If dgvDatos.RowCount > 0 Then
                    frm.txtItem.Text = toNumber(dgvDatos.GetRow(dgvDatos.RowCount - 1).Cells("Item").Text) + 1
                    'frm.IdDestino = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdDestino").Value), 0, dgvDatos.CurrentRow.Cells("IdDestino").Value)
                    frm.DestinoEnable = False
                Else
                    frm.txtItem.Text = 1
                    'frm.DestinoEnable = True
                End If
                frm.estado = 1
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    ObtenerRegistro()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdGastoDet)
                    End If
                Else
                    lLog = False
                End If
            End While

        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbProvisional_ValueChanged(sender As Object, e As EventArgs) Handles cmbProvisional.ValueChanged
        If cmbProvisional.Value = 1 Then
            '  cmbProvisional.ReadOnly = False
            ' cmbProvisional.BackColor = System.Drawing.SystemColors.Window
            gbGastoViaje.Enabled = True
            '----- Se realiza el cambio quedando que si se ingresa un personal diferente de servicio técnico el campo Job de gasto de viaje se inhabilita y se ingresa null 11/06/2014 ---
            'If cmbArea.Value = "05" Or cmbArea.Value = "20" Then
            'txtNumJob.ReadOnly = False
            'txtNumJob.BackColor = System.Drawing.SystemColors.Window
            'btnBuscarJob.Enabled = True
            'Else
            '    txtNumJob.ReadOnly = True
            '    txtNumJob.BackColor = System.Drawing.SystemColors.Control
            '    txtNumJob.Text = ""
            '    btnBuscarJob.Enabled = False
            'End If
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            gbTipo.Enabled = True
            rbViajeNacional.Checked = True
        Else
            'cmbProvisional.ReadOnly = True
            'cmbProvisional.BackColor = System.Drawing.SystemColors.Control
            'cmbProvisional.SelectedIndex = 0
            gbGastoViaje.Enabled = False
            'txtNumJob.ReadOnly = True
            'txtNumJob.BackColor = System.Drawing.SystemColors.Control
            'txtNumJob.Text = ""
            'btnBuscarJob.Enabled = False
            gbTipo.Enabled = False
            rbViajeNacional.Checked = False
            rbViajeExterior.Checked = False
        End If
    End Sub
End Class