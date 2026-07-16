Imports System.ServiceModel

Public Class frmCambioClave
    Private ObjSeguridad As New SeguridadService.SeguridadClient
    Dim user As New SeguridadService.Usuario
    Dim cambiarClave As Boolean

    Private Sub Finalizar()
        Try
            ObjSeguridad.Close()
        Catch ex As TimeoutException
            ObjSeguridad.Abort()
        Catch ex As CommunicationException
            ObjSeguridad.Abort()
        End Try
        'Me.Dispose(True)
        Me.Hide()

    End Sub

    Private Sub frmCambioClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            btnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Finalizar()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try

            If Len(txtConfirmarClave.Text) < 6 Then
                MsgBox("La clave debe tener como minimo 6 caracteres.!!!", MsgBoxStyle.Information, "Verifique")
                Exit Sub
            End If

            user = ObjSeguridad.MostrarUsuarioPorCodigo(Session.sCodUsu)
            If txtClaveActual.Text = "" Then
                MsgBox("Debe ingresar su clave actual.!!!", MsgBoxStyle.Information, "Verifique")
            Else
                'If txtClaveActual.Text = user.Clave Then
                If txtNuevaClave.Text = txtConfirmarClave.Text Then
                    If txtClaveActual.Text <> txtNuevaClave.Text And txtClaveActual.Text <> txtConfirmarClave.Text Then
                        If MsgBox("Esta seguro que desea Cambiar su contraseña?", MsgBoxStyle.YesNo, "Cambio de Contraseña") = MsgBoxResult.Yes Then
                            cambiarClave = ObjSeguridad.ActualizarClave(Session.sCodUsu, Trim(txtClaveActual.Text), Trim(txtConfirmarClave.Text), Session.sNomPc, Session.sDirIp)
                            If cambiarClave = True Then
                                MsgBox("Su clave ha sido cambiada exitosamente!!!")
                                If user.Seteo = False Then
                                    Me.Close()
                                    Finalizar()
                                ElseIf user.Seteo = True Then
                                    MDIPrincipal.Show()
                                    Finalizar()
                                    Me.Close()
                                    frmLogin.Hide()
                                End If
                            Else
                                MsgBox("Su clave actual no debe ser igual a la nueva clave!!!", MsgBoxStyle.Information, "Cambio de Contraseña")
                            End If
                        Else
                            txtNuevaClave.Text = ""
                            txtConfirmarClave.Text = ""
                            txtNuevaClave.Select()
                            Me.Show()
                        End If
                    Else
                        MsgBox("Su clave nueva no debe ser igual a la clave actual .Por favor verificar!!!", MsgBoxStyle.Information, "Verifique")
                        txtNuevaClave.Text = ""
                        txtConfirmarClave.Text = ""
                        txtNuevaClave.Select()
                    End If
                Else
                    MsgBox("Las claves no coinciden.Por favor verificar", MsgBoxStyle.Information, "Verifique")
                    txtNuevaClave.Text = ""
                    txtConfirmarClave.Text = ""
                    txtNuevaClave.Select()
                End If
                'Else
                '    MsgBox("La clave ingresada no es su clave actual", MsgBoxStyle.Information, "Cambio de Contraseña")
                '    txtClaveActual.Text = ""
                '    txtNuevaClave.Text = ""
                '    txtConfirmarClave.Text = ""
                '    txtClaveActual.Select()
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        
    End Sub

    Private Sub frmCambioClave_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtClaveActual.Select()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtClaveActual.KeyPress _
                         , txtNuevaClave.KeyPress _
                         , txtConfirmarClave.KeyPress _
                         , btnAceptar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class