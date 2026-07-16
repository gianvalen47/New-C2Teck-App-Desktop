Imports System.ServiceModel
Public Class frmLlamada

    '===========================Servicios====================================================
    Private oLlamadasService As New LlamadasService.LlamadasServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oUsuario As New SeguridadService.Usuario

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdLlamada As Integer
    Public IdPersona As Integer
    Public IdPersonaSolicita As Integer
    '=============================Evento FormClosed==========================================

    Private Sub Finalizar()
        Try
            oLlamadasService.Close()
            oMaestroService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oLlamadasService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oLlamadasService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmLlamada_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmLlamada_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmLlamada_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        LlenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
        Else                                      'Nuevo            
            activar()
            ObtenerEncargado()
            txtFecha.Focus()
            txtFecha.Value = Today
            txtHora.Text = Now().ToString("HH:mm")
        End If        
    End Sub

    Private Sub ObtenerEncargado()
        Dim usuario As New SeguridadService.Usuario
        usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        IdPersona = usuario.Persona.IdPer
        txtEncargado.Text = usuario.Persona.ApeNom
    End Sub

    Private Sub LlenarCombos()
        Try

          
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As LlamadasService.Llamadas
            registro = oLlamadasService.Obtener(IdLlamada)

            IdLlamada = registro.IdLlamada
            IdPersona = registro.Persona.IdPer
            txtEncargado.Text = registro.Persona.ApeNom
            txtFecha.Value = registro.Fecha
            txtHora.Text = registro.Hora.ToString("HH:mm")
            txtNumero.Text = registro.Numero
            txtDestino.Text = registro.Destino
            txtEmpresa.Text = registro.Empresa
            txtContacto.Text = registro.Contacto
            IdPersonaSolicita = registro.PersonaSolicita.IdPer
            txtPersonaSolicita.Text = registro.PersonaSolicita.ApeNom
            txtMotivo.Text = registro.Motivo
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub desactivar()
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtHora.ReadOnly = False
        txtHora.BackColor = System.Drawing.SystemColors.Window
        txtNumero.ReadOnly = False
        txtNumero.BackColor = System.Drawing.SystemColors.Window
        txtDestino.ReadOnly = False
        txtDestino.BackColor = System.Drawing.SystemColors.Window
        txtEmpresa.ReadOnly = False
        txtEmpresa.BackColor = System.Drawing.SystemColors.Window
        txtContacto.ReadOnly = False
        txtContacto.BackColor = System.Drawing.SystemColors.Window
        btnBuscarPersonaS.Enabled = False
        txtMotivo.ReadOnly = False
        txtMotivo.BackColor = System.Drawing.SystemColors.Window

        btnGuardar.Enabled = True
    End Sub

    Private Sub activar()
        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        txtHora.ReadOnly = False
        txtHora.BackColor = System.Drawing.SystemColors.Window
        txtNumero.ReadOnly = False
        txtNumero.BackColor = System.Drawing.SystemColors.Window
        txtDestino.ReadOnly = False
        txtDestino.BackColor = System.Drawing.SystemColors.Window
        txtEmpresa.ReadOnly = False
        txtEmpresa.BackColor = System.Drawing.SystemColors.Window
        txtContacto.ReadOnly = False
        txtContacto.BackColor = System.Drawing.SystemColors.Window
        btnBuscarPersonaS.Enabled = True
        txtMotivo.ReadOnly = False
        txtMotivo.BackColor = System.Drawing.SystemColors.Window


        btnGuardar.Enabled = True
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New LlamadasService.Llamadas
                Dim Encargado As New LlamadasService.Persona
                Dim PersonaSolicita As New LlamadasService.Persona

                registro.IdLlamada = IdLlamada
                Encargado.IdPer = IdPersona
                registro.Persona = Encargado
                registro.Fecha = txtFecha.Value
                registro.Hora = txtHora.Text
                registro.Numero = txtNumero.Text
                registro.Destino = txtDestino.Text
                registro.Empresa = txtEmpresa.Text
                registro.Contacto = txtContacto.Text
                PersonaSolicita.IdPer = IdPersonaSolicita
                registro.PersonaSolicita = PersonaSolicita
                registro.Motivo = txtMotivo.Text

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc                
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA LLAMADA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As LlamadasService.Llamadas)
        Try
            Dim estado_process As Integer
            estado_process = oLlamadasService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdLlamada = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA LLAMADA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As LlamadasService.Llamadas)
        Try
            Dim estado_process As Boolean
            estado_process = oLlamadasService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA LLAMADA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersona) = 0 Then
                MsgBox("Debe Ingresar la Persona Encargada", MsgBoxStyle.Information, "Información")                
                txtEncargado.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe ingresar la Fecha", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf Not (txtHora.MaskFull) Then
                MsgBox("Debe de Ingresa la Hora de llamada.", MsgBoxStyle.Information, "Información")
                txtHora.Focus()
                Return False
            ElseIf toBlank(txtNumero.Text) = "" Then
                MsgBox("Debe ingresar el Número", MsgBoxStyle.Information, "Información")
                txtNumero.Focus()
                Return False
            ElseIf toBlank(txtDestino.Text) = "" Then
                MsgBox("Debe ingresar el Destino", MsgBoxStyle.Information, "Información")
                txtDestino.Focus()
                Return False
            ElseIf toBlank(txtEmpresa.Text) = "" Then
                MsgBox("Debe ingresar la Empresa", MsgBoxStyle.Information, "Información")
                txtEmpresa.Focus()
                Return False
            ElseIf toNumber(IdPersonaSolicita) = 0 Then
                MsgBox("Debe Ingresar la Persona que Solicita la Llamada", MsgBoxStyle.Information, "Información")                
                btnBuscarPersonaS.Focus()
                Return False           
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnBuscarPersonaSolicita_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersonaSolicita = frm.codigo
                    txtPersonaSolicita.Text = frm.descripcion
                    txtMotivo.Focus()
                Else
                    IdPersonaSolicita = 0
                    txtPersonaSolicita.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtPersonaSolicita_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPersonaSolicita.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersonaS.Enabled = True Then
                e.Handled = True
                btnBuscarPersonaSolicita_Click(sender, e)
            End If
        End If
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtEncargado.KeyPress _
                           , txtFecha.KeyPress _
                           , txtHora.KeyPress _
                           , txtNumero.KeyPress _
                           , txtDestino.KeyPress _
                           , txtEmpresa.KeyPress _
                           , txtContacto.KeyPress _
                           , txtMotivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPersonaSolicita_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPersonaSolicita.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMotivo.Focus()
        End If
    End Sub
End Class