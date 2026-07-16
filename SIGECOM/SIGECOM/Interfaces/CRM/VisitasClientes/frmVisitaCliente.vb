Imports System.ServiceModel
Imports System.Windows.Forms
Public Class frmVisitaCliente

    Private oVisitaOportunidadService As New VisitaOportunidadService.VisitaOportunidadServiceClient
    Private oVisitaClienteService As New VisitaClienteService.VisitaClienteServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oContactoService As New ContactoService.ContactoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public state_button As Boolean
    Public type_process As String
    Public IdVisita As Integer
    Public IdCliente As Integer
    Public IdOportunidad As Integer
    Public IdPersona As Integer
    Private dtTipoVisita As DataTable
    'Private dtVendedor As DataTable
    Private dtUnidades As DataTable
    Private dtTipoCancelacion As DataTable
    Private dtContactos As DataTable
    Public IdEstado As Integer
    Private Sub frmVisitaCliente_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub
    Private Sub frmVisitaCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()

        If state_button Then                'Modificar
            If IdEstado <> 3 Then
                gbCancelacion.Visible = False
                btnGuardar.Location = New System.Drawing.Point(238, 348)
                btnCancelar.Location = New System.Drawing.Point(322, 348)
                Me.Size = New System.Drawing.Size(647, 414)
            Else
                gbCancelacion.Visible = True
                btnGuardar.Location = New System.Drawing.Point(238, 398)
                btnCancelar.Location = New System.Drawing.Point(322, 398)
                Me.Size = New System.Drawing.Size(647, 464)
            End If

            ObtenerRegistro()
            desactivar()
            txtCliente.Focus()
            EnableOptions()
        Else                                      'Nuevo
            gbCancelacion.Visible = False
            btnGuardar.Location = New System.Drawing.Point(238, 348)
            btnCancelar.Location = New System.Drawing.Point(322, 348)
            Me.Size = New System.Drawing.Size(647, 414)
            ObtenerSolicitante()
            activar()            
            txtCliente.Focus()
        End If
        txtCliente.Focus()
    End Sub
    Private Sub ObtenerSolicitante()
        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPersona = usuario.Persona.IdPer
        txtPersona.Text = usuario.Persona.ApeNom
    End Sub
    Private Sub frmVisitaCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el  Cliente de la Visita.", MsgBoxStyle.Information, "Información")
                txtCliente.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe Ingresar la Fecha de la Visita.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toNumber(cmbIdContacto.Value) = 0 Then
                MsgBox("Debe Ingresar el Contacto de la Visita.", MsgBoxStyle.Information, "Información")
                cmbIdContacto.Focus()
                Return False
            ElseIf toNumber(cmbTipoVisita.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Visita.", MsgBoxStyle.Information, "Información")
                cmbTipoVisita.Focus()
                Return False
            ElseIf toNumber(cmbUnidad.Value) = 0 Then
                MsgBox("Debe Ingresar la Unidad de Negocio.", MsgBoxStyle.Information, "Información")
                cmbUnidad.Focus()
                Return False
            ElseIf toNumber(IdPersona) = 0 Then
                MsgBox("Debe Ingresar el Colaborador de la Visita.", MsgBoxStyle.Information, "Información")
                txtPersona.Focus()
                Return False
            ElseIf cbEjecutado.Checked = True And txtLugar.Text = "" Then
                MsgBox("Debe Ingresar el Lugar de la Visita.", MsgBoxStyle.Information, "Información")
                txtLugar.Focus()
                Return False
            ElseIf cbEjecutado.Checked = True And txtHora.Text = "" Then
                MsgBox("Debe Ingresar el Horario de la Visita.", MsgBoxStyle.Information, "Información")
                txtHora.Focus()
                Return False
            ElseIf cbEjecutado.Checked = True And txtResultados.Text = "" Then
                MsgBox("Debe Ingresar los Resultados de la Visita.", MsgBoxStyle.Information, "Información")
                txtResultados.Focus()
                Return False
            ElseIf cbEjecutado.Checked = True And txtTemas.Text = "" Then
                MsgBox("Debe Ingresar los Etregables de la Visita.", MsgBoxStyle.Information, "Información")
                txtTemas.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub EnableOptions()
        If IdEstado = 1 Or (Session.CodPerfil = "14" Or Session.CodPerfil = "01") Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub
    Private Sub activar()
        btnBuscarCliente.Enabled = True
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        cmbIdContacto.ReadOnly = False
        cmbIdContacto.BackColor = System.Drawing.SystemColors.Window
        btnAgregarContacto.Enabled = True
        cmbTipoVisita.ReadOnly = False
        cmbTipoVisita.BackColor = System.Drawing.SystemColors.Window
        cmbUnidad.ReadOnly = False
        cmbUnidad.BackColor = System.Drawing.SystemColors.Window
        txtObjetivos.ReadOnly = False
        txtObjetivos.BackColor = System.Drawing.SystemColors.Window
        btnBuscarPersona.Enabled = True
        btnBuscarOportunidad.Enabled = True
        cbEjecutado.Enabled = True
        txtCliente.Focus()
    End Sub
    Private Sub desactivar()
        If IdEstado = 1 Or (Session.CodPerfil = "14" Or Session.CodPerfil = "01") Then
            activar()
        Else
            btnBuscarCliente.Enabled = False
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            cmbIdContacto.ReadOnly = True
            cmbIdContacto.BackColor = System.Drawing.SystemColors.Control
            btnAgregarContacto.Enabled = False
            cmbTipoVisita.ReadOnly = True
            cmbTipoVisita.BackColor = System.Drawing.SystemColors.Control
            cmbUnidad.ReadOnly = True
            cmbUnidad.BackColor = System.Drawing.SystemColors.Control
            txtObjetivos.ReadOnly = True
            txtObjetivos.BackColor = System.Drawing.SystemColors.Control
            btnBuscarPersona.Enabled = False
            btnBuscarOportunidad.Enabled = False
            cbEjecutado.Enabled = False
            gbEjecutado.Enabled = False
        End If
    End Sub
    Private Sub Insertar(ByVal registro As VisitaClienteService.VisitaCliente)
        Try
            Dim estado_process As Integer
            estado_process = oVisitaClienteService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdVisita = estado_process
                MsgBox("Se inserto la Visita de Cliente Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR VISITA CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As VisitaClienteService.VisitaCliente)
        Try
            Dim estado_process As Boolean
            estado_process = oVisitaClienteService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'MsgBox("Se modificó la Visita de Cliente Correctamente")                
                'ObtenerRegistro()
                'desactivar()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR VISITA CLIENTE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As VisitaClienteService.VisitaCliente
            registro = oVisitaClienteService.Obtener(IdVisita)

            IdVisita = registro.IdVisita
            IdCliente = registro.Contacto.Cliente.IdCliente
            txtFecha.Text = registro.Fecha
            listarContactos()
            lblEstado.Text = registro.EstadoVisitaCliente.DesEstado
            txtCliente.Text = registro.Contacto.Cliente.DesCli
            cmbIdContacto.Value = registro.Contacto.IdContacto
            cmbTipoVisita.Value = registro.TipoVisita.IdTipoVisita
            cmbUnidad.Value = registro.UnidadNegocio.IdUnidad
            txtObjetivos.Text = registro.Objetivos
            IdPersona = registro.Persona.IdPer
            txtPersona.Text = registro.Persona.ApeNom
            If registro.OportunidadNegocio.IdOportunidad <> 0 Then
                IdOportunidad = registro.OportunidadNegocio.IdOportunidad
                txtOportunidad.Text = registro.OportunidadNegocio.Nombre
            End If
            cbEjecutado.Checked = registro.Ejecutado
            txtLugar.Text = registro.Lugar
            txtHora.Text = registro.Horario
            txtResultados.Text = registro.Resultados
            txtTemas.Text = registro.Observacion
            If toNumber(registro.TipoCancelacionVisita.IdCancelacion) > 0 Then
                cmbTipoCancelacion.Value = registro.TipoCancelacionVisita.IdCancelacion
            Else
                cmbTipoCancelacion.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try

            ''===================================== TIPO DE VISITA ============================================
            dtTipoVisita = oVisitaOportunidadService.MostrarTipoVisita().Tables(0)
            'dtTipoVisita.Rows.InsertAt(getRowTodos(dtTipoVisita), 0)
            cmbTipoVisita.DataSource = dtTipoVisita
            cmbTipoVisita.DropDownList.DataMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.DropDownList.DisplayMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.DropDownList.ValueMember = dtTipoVisita.Columns("IdTipoVisita").ToString
            cmbTipoVisita.DropDownList.Columns(0).DataMember = dtTipoVisita.Columns("IdTipoVisita").ToString
            cmbTipoVisita.DropDownList.Columns(1).DataMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            cmbTipoVisita.SelectedIndex = 0
            dtTipoVisita = Nothing

            ''======================================= VENDEDOR ===========================================
            'dtVendedor = oPersonaService.MostrarVendedoresVigente.Tables(0)
            'dtVendedor.Rows.InsertAt(getRowVendedor(dtVendedor), 0)
            'cmbVendedor.DataSource = dtVendedor
            'cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            'cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            'cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.SelectedIndex = 0
            'dtVendedor = Nothing

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

            ''================================== TIPO CANCELACION ============================================
            dtTipoCancelacion = oVisitaClienteService.MostrarTipoCancelacionVisita().Tables(0)
            dtTipoCancelacion.Rows.InsertAt(getRowTodos(dtTipoCancelacion), 0)
            cmbTipoCancelacion.DataSource = dtTipoCancelacion
            cmbTipoCancelacion.DropDownList.DataMember = dtTipoCancelacion.Columns("Nombre").ToString
            cmbTipoCancelacion.DropDownList.DisplayMember = dtTipoCancelacion.Columns("Nombre").ToString
            cmbTipoCancelacion.DropDownList.ValueMember = dtTipoCancelacion.Columns("IdCancelacion").ToString
            cmbTipoCancelacion.DropDownList.Columns(0).DataMember = dtTipoCancelacion.Columns("IdCancelacion").ToString
            cmbTipoCancelacion.DropDownList.Columns(1).DataMember = dtTipoCancelacion.Columns("Nombre").ToString
            cmbTipoCancelacion.SelectedIndex = 0
            dtTipoCancelacion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New VisitaClienteService.VisitaCliente                 
                    Dim Contacto As New VisitaClienteService.Contacto
                    Dim TipoVisita As New VisitaClienteService.TipoVisita
                    Dim Unidad As New VisitaClienteService.UnidadNegocio
                    Dim Persona As New VisitaClienteService.Persona
                    Dim Oportunidad As New VisitaClienteService.OportunidadNegocio
                    Dim Estado As New VisitaClienteService.EstadoVisitaCliente

                    registro.IdVisita = IdVisita
                    Contacto.IdContacto = toNumber(cmbIdContacto.Value)
                    registro.Contacto = Contacto
                    registro.Fecha = txtFecha.Value
                    TipoVisita.IdTipoVisita = toNumber(cmbTipoVisita.Value)
                    registro.TipoVisita = TipoVisita
                    Unidad.IdUnidad = toNumber(cmbUnidad.Value)
                    registro.UnidadNegocio = Unidad
                    registro.Objetivos = IIf(txtObjetivos.Text = "", Nothing, txtObjetivos.Text)

                    If toNumber(IdOportunidad) = 0 Then
                        Oportunidad.IdOportunidad = Nothing
                        registro.OportunidadNegocio = Oportunidad
                    Else
                        Oportunidad.IdOportunidad = IdOportunidad
                        registro.OportunidadNegocio = Oportunidad
                    End If

                    Persona.IdPer = toNumber(IdPersona)
                    registro.Persona = Persona
                    registro.Ejecutado = IIf(cbEjecutado.Checked = True, True, False)
                    registro.Lugar = IIf(txtLugar.Text = "", Nothing, txtLugar.Text)
                    registro.Resultados = IIf(txtResultados.Text = "", Nothing, txtResultados.Text)
                    registro.Horario = IIf(txtHora.Text = "", Nothing, txtHora.Text)
                    registro.Observacion = IIf(txtTemas.Text = "", Nothing, txtTemas.Text)
                    Estado.IdEstado = IIf(cbEjecutado.Checked = True, 2, 1)
                    registro.EstadoVisitaCliente = Estado

                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.CodUsu = Session.sCodUsu

                    If state_button Then            'Modificar                
                        Modificar(registro)
                    Else                                  'Nuevo                        
                        registro.FecReg = Today
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR VISITA CLIENTE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Finalizar()
        Try
            oVisitaOportunidadService.Close()
            oVisitaClienteService.Close()
            oCentroCostoService.Close()
            oPersonaService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oVisitaOportunidadService.Abort()
            oVisitaClienteService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oVisitaOportunidadService.Abort()
            oVisitaClienteService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                  txtCliente.KeyPress _
                  , txtFecha.KeyPress _
                  , cmbIdContacto.KeyPress _
                  , cmbTipoVisita.KeyPress _
                    , cmbUnidad.KeyPress _
                    , txtObjetivos.KeyPress _
                , txtOportunidad.KeyPress _
                , txtPersona.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = "(Ninguno)"
        End Try

        Return fila
    End Function
    Private Function getRowVendedor(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
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
        Return fila
    End Function
    Private Sub cbEjecutado_CheckedChanged(sender As Object, e As EventArgs) Handles cbEjecutado.CheckedChanged
        If cbEjecutado.Checked = True Then
            gbEjecutado.Enabled = True
        Else
            gbEjecutado.Enabled = False
            txtLugar.Text = ""
            txtHora.Text = ""
            txtResultados.Text = ""
            txtTemas.Text = ""
        End If
    End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdCliente = frm.codigo
                    txtCliente.Text = frm.descripcion
                    txtFecha.Focus()
                    listarContactos()
                Else
                    IdCliente = 0
                    txtCliente.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                e.Handled = True
                btnBuscarCliente_Click(sender, e)                
            End If
        End If
    End Sub
    Private Sub btnBuscarOportunidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarOportunidad.Click
        Try
            If IdCliente = 0 Then
                MsgBox("Debe Ingresar el Cliente.", MsgBoxStyle.Information, "Información")
            Else
                Dim frm As New frmBuscarOportunidad
                frm.IdCliente = IdCliente
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    If toNull(frm.codigo) <> Nothing Then
                        IdOportunidad = frm.codigo
                        txtOportunidad.Text = frm.descripcion
                    Else
                        IdOportunidad = 0
                        txtOportunidad.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub txtOportunidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOportunidad.KeyDown
        If e.KeyCode = Keys.F12 Then
            If IdCliente = 0 Then
                MsgBox("Debe Ingresar el Cliente.", MsgBoxStyle.Information, "Información")
            Else
                If btnBuscarOportunidad.Enabled = True Then
                    e.Handled = True
                    btnBuscarOportunidad_Click(sender, e)
                End If
            End If
        End If
    End Sub
    Private Sub listarContactos()
        Try
            '======================================= CONTACTOS ================================================
            dtContactos = oContactoService.Mostrar(IdCliente).Tables(0)
            cmbIdContacto.DataSource = dtContactos
            cmbIdContacto.DropDownList.DataMember = dtContactos.Columns("Apellidos").ToString
            cmbIdContacto.DropDownList.DisplayMember = dtContactos.Columns("Apellidos").ToString
            cmbIdContacto.DropDownList.ValueMember = dtContactos.Columns("IdContacto").ToString
            cmbIdContacto.DropDownList.Columns(0).DataMember = dtContactos.Columns("IdContacto").ToString
            cmbIdContacto.DropDownList.Columns(1).DataMember = dtContactos.Columns("Apellidos").ToString
            cmbIdContacto.DropDownList.Columns(2).DataMember = dtContactos.Columns("Nombres").ToString
            dtContactos = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR LOS CONTACTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(sender As Object, e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtPersona.Text = frm.descripcion
                    txtOportunidad.Focus()                    
                Else
                    IdPersona = 0
                    txtPersona.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub txtPersona_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersona.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub btnAgregarContacto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarContacto.Click
        Try
            If IdCliente > 0 Then
                Dim frm As New frmAgregarContacto
                frm.IdCliente = IdCliente
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    ListarContactos()
                    cmbIdContacto.Select()
                    cmbIdContacto.DroppedDown = True
                End If
            Else
                MsgBox("Debe ingresar el Cliente")
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el contacto : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class
