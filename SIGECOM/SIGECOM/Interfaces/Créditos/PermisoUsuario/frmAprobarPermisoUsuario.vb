
Imports System.ServiceModel

Public Class frmAprobarPermisoUsuario

    Private oAprobarVentaService As New AprobarVentaService.AprobarVentaServiceClient

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public IdAutorizar As Integer
    Public CodPerfil As String


    Private Sub frmAprobarPermisoUsuario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            oAprobarVentaService.Close()
        Catch ex As TimeoutException

            oAprobarVentaService.Abort()
        Catch ex As CommunicationException

            oAprobarVentaService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)

    End Sub

    Private Sub frmAprobarPermisoUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                cbFecInicio.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub frmAprobarPermisoUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If state_button Then

            ObtenerRegistro()
            Desactivar()

        Else

            biGuardar.Enabled = True
            biEditar.Enabled = False
            biDeshacer.Enabled = True
            biSalir.Enabled = False
            btnBuscarUsuario.Select()
            cbFecInicio.Value = Now
            cbFecFinal.Value = Now
        End If

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As AprobarVentaService.AutorizarAprobacion

            registro = oAprobarVentaService.ObtenerAutorizacion(IdAutorizar)

            txtCodUsuario.Text = registro.CodUsu
            cbFecInicio.Value = registro.FecInicio
            cbFecFinal.Value = registro.FecFinal
           

        Catch ex As Exception
            MsgBox("Error al Obtener el Registro : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarUsuario.Click
        Try
            Dim frm As New frmBuscarUsuario
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                txtCodUsuario.Text = frm.CodUsuario
                cbFecInicio.Focus()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar usuario", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Desactivar()

        btnBuscarUsuario.Enabled = False
        cbFecInicio.ReadOnly = True
        cbFecFinal.ReadOnly = True
        biGuardar.Enabled = False
        biDeshacer.Enabled = False
        biEditar.Enabled = True

    End Sub

    Private Sub Activar()

        btnBuscarUsuario.Enabled = True
        cbFecInicio.ReadOnly = False
        cbFecFinal.ReadOnly = False
      
        biGuardar.Enabled = True
        biDeshacer.Enabled = True
        biEditar.Enabled = False

    End Sub

    Private Sub Insertar(ByVal registro As AprobarVentaService.AutorizarAprobacion)
        Try
            Dim estado_process As Integer

            estado_process = oAprobarVentaService.InsertarAutorizacion(registro)
            If estado_process Then
                IdAutorizar = estado_process
                MsgBox("Se insertó el registro correctamente", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            Else
                MsgBox("Error en el proceso, comunicarse con el administrador del sistema")
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As AprobarVentaService.AutorizarAprobacion)
        Try
            Dim estado_process As Boolean

            estado_process = oAprobarVentaService.ActualizarAutorizacion(registro)

            If estado_process Then
                MsgBox("Se modificó el registro correctamente", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comunicarse con el administrador del sistema")
            End If

            estado_process = oAprobarVentaService.ActualizarAutorizacion(registro)
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
           
            If toBlank(txtCodUsuario.Text) = "" Then
                MsgBox("Debe ingresar el usuario a quien se le dara la autorización")
                btnBuscarUsuario.Select()
                Return False

            ElseIf state_button = False And oAprobarVentaService.BuscarFecha(Session.sCodUsu, cbFecInicio.Value.ToString("dd/MM/yyyy"), cbFecFinal.Value.ToString("dd/MM/yyyy")) Then
                MsgBox("Este rango de fechas ya existe , Verifique...")
                cbFecInicio.Select()
                Return False

            ElseIf CDate(cbFecInicio.Value) >= CDate(cbFecFinal.Value) Then
                MsgBox("El rango de fechas esta incorrecto,Debe existir un rango de fechas u hora, Verifique...")
                cbFecInicio.Select()
                Return False
            Else
                Return True

            End If
        Catch ex As Exception
            MsgBox("Error al Validar los Campos : " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los cambios?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim registro As New AprobarVentaService.AutorizarAprobacion

                registro.IdAutorizar = IdAutorizar
                registro.CodUsu = txtCodUsuario.Text
                registro.CodPerfil = ""
                registro.FecInicio = cbFecInicio.Value
                registro.FecFinal = cbFecFinal.Value
                registro.Activo = True
                registro.CodUsuTran = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then

                    Modificar(registro)

                Else
                    Insertar(registro)

                End If

            End If
        Catch ex As Exception
            MsgBox("Error al Guardar los Datos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Está seguro de Deshacer los cambios?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If state_button Then
                ObtenerRegistro()
                Desactivar()
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If

        End If

    End Sub

    Private Sub cbFecFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            biGuardar_Click(sender, e)
            e.Handled = True
        End If
    End Sub

   
End Class