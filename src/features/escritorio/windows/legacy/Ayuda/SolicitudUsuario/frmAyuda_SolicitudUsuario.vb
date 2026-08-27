Imports System.ServiceModel
Public Class frmAyuda_SolicitudUsuario

    '=========================== Servicios ===================================================
    Private oSeguridadUsuarioService As New SeguridadService.SeguridadClient
    Private oSolicitudUsuarioService As New SolicitudUsuarioService.SolicitudUsuarioServiceClient
    Private oMaestroService As New MaestroService.MaestroClient    

    '======================Declaración de Variables==============================
    Public state_button As Boolean                'True: Modificar    False: nuevo
    Private IdPer As Integer
    Public IdSolicitud As Integer
    Public IdPerUsu As Integer

    Private dtTipoSolicitud As DataTable
    Private dtDatos As DataTable
    Private dtAreas As DataTable

    Private Sub frmAyuda_SolicitudUsuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmAyuda_SolicitudUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        If state_button Then
            ObtenerRegistro()
            Desactivar()
            gbEstados.Visible = True
            btnGuardar.Visible = False
            btnCancelar.Visible = False
            listaDatos()
            Desactivar()
        Else
            Me.Size = New System.Drawing.Size(605, 235)
            IdPer = IdPerUsu
            txtSolicitante.Text = oSeguridadUsuarioService.MostrarUsuarioPorCodigo(Session.sCodUsu).Persona.ApeNom
            gbEstados.Visible = False
            btnGuardar.Visible = True
            btnCancelar.Visible = True
            cmbTipoSolicitud.Focus()
            Activar()
        End If
    End Sub

    Private Sub frmAyuda_SolicitudUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oSeguridadUsuarioService.Close()
            oSolicitudUsuarioService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oSeguridadUsuarioService.Abort()
            oSolicitudUsuarioService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oSeguridadUsuarioService.Abort()
            oSolicitudUsuarioService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If state_button And toNumber(IdSolicitud) = 0 Then
                MsgBox("Debe Ingresar el número de la solicitud.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf cmbTipoSolicitud.Value = 0 Then
                MsgBox("Debe ingresar el tipo de solicitud", MsgBoxStyle.Information, "Faltan Datos")
                cmbTipoSolicitud.Focus()
                Return False
            ElseIf IdPer = 0 Then
                MsgBox("Debe ingresar el solicitante", MsgBoxStyle.Information, "Faltan Datos")
                btnBuscarPersona.Focus()
                Return False
            ElseIf txtObservacion.Text = "" Then
                MsgBox("Debe ingresar el motivo de su solicitud")
                txtObservacion.Focus()
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Activar()
        cmbTipoSolicitud.ReadOnly = False
        cmbTipoSolicitud.BackColor = System.Drawing.SystemColors.Window
        txtSolicitante.ReadOnly = True
        txtSolicitante.BackColor = System.Drawing.SystemColors.Control
        btnBuscarPersona.Enabled = True
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub Desactivar()
        cmbTipoSolicitud.ReadOnly = True
        cmbTipoSolicitud.BackColor = System.Drawing.SystemColors.Control
        txtSolicitante.ReadOnly = True
        txtSolicitante.BackColor = System.Drawing.SystemColors.Control
        btnBuscarPersona.Enabled = False
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
    End Sub

    Private Sub Insertar(ByVal registro As SolicitudUsuarioService.Solicitud)
        Try
            Dim estado_process As Integer
            estado_process = oSolicitudUsuarioService.Insertar(registro)
            If estado_process > 0 Then
                IdSolicitud = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR INSERTAR SOLICITUD DE USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SolicitudUsuarioService.Solicitud
            registro = oSolicitudUsuarioService.Obtener(IdSolicitud)

            txtNumDoc.Text = registro.IdSolicitud
            cmbTipoSolicitud.Value = registro.TipoTrabajo.IdTipo
            IdPer = registro.Persona.IdPer
            txtSolicitante.Text = registro.Persona.ApeNom
            txtObservacion.Text = registro.Motivo
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAyuda_SolicitudUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
              txtSolicitante.KeyPress _
            , cmbTipoSolicitud.KeyPress _
            , txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub llenarCombos()
        Try
            dtTipoSolicitud = oSolicitudUsuarioService.MostrarTipoTrabajo().Tables(0)
            cmbTipoSolicitud.DataSource = dtTipoSolicitud
            cmbTipoSolicitud.DropDownList.DataMember = dtTipoSolicitud.Columns("Nombre").ToString
            cmbTipoSolicitud.DropDownList.DisplayMember = dtTipoSolicitud.Columns("Nombre").ToString
            cmbTipoSolicitud.DropDownList.ValueMember = dtTipoSolicitud.Columns("IdTipo").ToString
            cmbTipoSolicitud.DropDownList.Columns(0).DataMember = dtTipoSolicitud.Columns("IdTipo").ToString
            cmbTipoSolicitud.DropDownList.Columns(1).DataMember = dtTipoSolicitud.Columns("Nombre").ToString
            cmbTipoSolicitud.SelectedIndex = 0
            dtTipoSolicitud = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSolicitudUsuarioService.MostrarEstados(IdSolicitud, IdPer).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click

        Dim frm As New frmBuscarPersonal
        frm.codigoArea = ""
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtSolicitante.Text = frm.descripcion
            txtSolicitante.BackColor = System.Drawing.SystemColors.Control
            IdPer = frm.codigo
        End If
        txtSolicitante.Select()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then
                Dim registro As New SolicitudUsuarioService.Solicitud
                Dim tiposolicitud As New SolicitudUsuarioService.TipoTrabajo
                Dim motivoproblema As New SolicitudUsuarioService.MotivoProblema
                Dim persona As New SolicitudUsuarioService.Persona
                Dim usuario As New SolicitudUsuarioService.Persona
                Dim tipotrabajo As New SolicitudUsuarioService.TipoTrabajo

                registro.Aplicacion = "SIGECOM"
                registro.Medio = "ONLINE"
                registro.Estado = "GN"
                persona.IdPer = IdPer
                registro.Persona = persona
                usuario.IdPer = IdPerUsu
                registro.Usuario = usuario
                tipotrabajo.IdTipo = cmbTipoSolicitud.Value
                registro.TipoTrabajo = tipotrabajo
                motivoproblema.IdMotivo = Nothing
                registro.MotivoProblema = motivoproblema
                registro.Motivo = txtObservacion.Text
                registro.CodUsu = Session.sCodUsu
                registro.Fecha = Today

                Insertar(registro)

            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtSolicitante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicitante.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub cmbTipoSolicitud_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoSolicitud.ValueChanged
        If state_button = False Then
            If cmbTipoSolicitud.Value = 1 Then
                txtObservacion.Text = "Paralización de la computadora, ofimatica"
            ElseIf cmbTipoSolicitud.Value = 2 Then
                txtObservacion.Text = "Matriciales, inyección de tinta, laser"
            ElseIf cmbTipoSolicitud.Value = 3 Then
                txtObservacion.Text = "Desconexion al dominio, no ingresa a ningun sistema"
            ElseIf cmbTipoSolicitud.Value = 4 Then
                txtObservacion.Text = "Envio, recepción de correos electrónicos"
            ElseIf cmbTipoSolicitud.Value = 5 Then
                txtObservacion.Text = "Navegación a internet"
            ElseIf cmbTipoSolicitud.Value = 6 Then
                txtObservacion.Text = "Aviso de virus, spywere, troyanos, etc."
            ElseIf cmbTipoSolicitud.Value = 7 Then
                txtObservacion.Text = "Creación de nuevos modulos, reportes, etc."
            ElseIf cmbTipoSolicitud.Value = 8 Then
                txtObservacion.Text = "Modificación de modulos y/o reportes de sistema"
            ElseIf cmbTipoSolicitud.Value = 9 Then
                txtObservacion.Text = "Correción de errores y modificación  de ingreso de datos"
            ElseIf cmbTipoSolicitud.Value = 10 Then
                txtObservacion.Text = "Registrar huella digital a un nuevo personal o actualizar en en lector digital."
            ElseIf cmbTipoSolicitud.Value = 11 Then
                txtObservacion.Text = "Capacitar al usuario cuando desconoce algun procedimiento de nuestros sistemas."
            ElseIf cmbTipoSolicitud.Value = 12 Then
                txtObservacion.Text = "Crear un usuario nuevo para accesar al sistema SIGECOM/Personal/Intranet, etc."
            ElseIf cmbTipoSolicitud.Value = 13 Then
                txtObservacion.Text = "Consulta de datos especificas para un usuario. Entregado en XLS ó PDF."
            ElseIf cmbTipoSolicitud.Value = 14 Then
                txtObservacion.Text = "Dar permisos especificos a ciertas opciones del sistema"
            End If
            txtObservacion.Focus()
        End If
    End Sub
End Class