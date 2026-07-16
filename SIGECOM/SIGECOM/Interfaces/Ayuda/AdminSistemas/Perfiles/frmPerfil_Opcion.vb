Imports System.ServiceModel
Public Class frmPerfil_Opcion

    '============================Servicios===================================
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private Perfil As New SeguridadService.Perfil

    '======================Declaración de Variables==============================
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public IdOpcion As Integer
    Public CodPerfil As String

    Private Sub frmPerfil_Opcion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        If state_button Then    'Modificar
            ObtenerRegistro()
            desactivar()
            cbLectura.Select()
        Else                          'Nuevo
            activar()
            cbLectura.Select()
        End If
        EnableOptions()
    End Sub

    '========================== Evento KeyDown ==================================
    Private Sub frmPerfil_Opcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    '========================== Evento KeyPress ==================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtDesOpcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(CodPerfil) = "" Then
                MsgBox("Debe Ingresar el código del Perfil. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(IdOpcion) = 0 Then
                MsgBox("Debe Ingresar el código de la Opción. ", MsgBoxStyle.Information, "Información")
                Return False               
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EnableOptions()

    End Sub

    Private Sub activar()
        btnGuardar.Enabled = True
    End Sub

    Private Sub desactivar()
        txtDesOpcion.ReadOnly = True
        txtDesOpcion.BackColor = System.Drawing.SystemColors.Control
        cbLectura.Enabled = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub Modificar()
        Try
            Dim estado_process As Boolean
            estado_process = oSeguridadService.ActualizarPerfilOpciones(IdOpcion, CodPerfil, cbLectura.Checked)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR OPCIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As SeguridadService.PerfilOpcion
            registro = oSeguridadService.ObtenerPerfilOpciones(IdOpcion, CodPerfil)

            lblPerfil.Text = registro.Perfil.Nombre
            txtDesOpcion.Text = registro.OpcionesMenu.DesOpc1
            cbLectura.Checked = registro.Lectura

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
           And ValidaCampos() Then

                Modificar()

            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cbLectura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbLectura.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class