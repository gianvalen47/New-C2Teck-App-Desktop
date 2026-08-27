Imports System.ServiceModel
Public Class frmProducto_Imagen_Actualizar

    Private oProductoService As New ProductoService.ProductoServiceClient

    Private dtDatos As DataTable
    Public CodMer As String
    Public Nombre As String
    Public IdImagen As Integer
    Public type_process As String
    Private Extension As String

    Private Sub frmProducto_Imagen_Actualizar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProductoService.Close()
        Catch ex As TimeoutException
            oProductoService.Abort()
        Catch ex As CommunicationException
            oProductoService.Abort()
        End Try
    End Sub

    Private Sub frmProducto_Imagen_Actualizar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProducto_Imagen_Actualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerRegistro()

        txtArchivo.ReadOnly = True
        txtArchivo.BackColor = System.Drawing.SystemColors.Control

        txtItem.Select()

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro2 As ProductoService.ImagenesProducto
            oProductoService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            registro2 = oProductoService.ObtenerImagen(IdImagen)

            txtArchivo.Text = registro2.Nombre
            txtObservacion.Text = registro2.Observacion
            txtItem.Value = registro2.Item
            cbPrincipal.Checked = registro2.Principal

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click

        Try

            Dim registro As New ProductoService.ImagenesProducto
            Dim producto As New ProductoService.Producto
            Dim empresa As New ProductoService.Empresa
            'registro.IdSeguimientoFoto 

            empresa.CodEmp = Session.sCodEmp
            producto.Empresa = empresa
            producto.CodMer = CodMer

            registro.Producto = producto

            registro.Item = txtItem.Value
            registro.Principal = cbPrincipal.Checked

            registro.IdImagen = IdImagen

            registro.Nombre = txtArchivo.Text
            'End If
            registro.Extension = toBlank(Extension)

            registro.Observacion = txtObservacion.Text
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            Dim actualizar As Boolean

            actualizar = oProductoService.ActualizarImagen(registro)

            If actualizar = True Then
                type_process = "actualizar"
                MsgBox("Se actualizó la imagen correctamente.", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("No se pudo actualizar la imagen, Comuniquese con el Departamento de TI", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR LA IMAGEN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.Close()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            Else
                'dgvDatos.Select()
            End If
        End If
    End Sub

    Private Sub txtItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItem.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObservacion.Select()
        End If
    End Sub

End Class