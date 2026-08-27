Imports System.ServiceModel
Imports System.IO
Public Class frmProducto_Imagen

    Private oProductoService As New ProductoService.ProductoServiceClient
    'Private oJobService As New JobService.JobServiceClient

    Public state_button As Boolean
    Public type_process As String

    Private dtDatos As DataTable
    Public CodMer As String
    Public IdImagen As String
    Private Extension As String
    Private RutaArchivo As String
    Private NombreArchivo As String

    Private Sub frmProducto_Imagen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If state_button Then
            desactivar()
        Else
            activar()
            Me.Text = "Nueva Imagen"
            txtItem.Text = oProductoService.SugerirItem(CodMer, Session.sCodEmp)
        End If
    End Sub

    Private Sub frmProducto_Imagen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProductoService.Close()
        Catch ex As TimeoutException
            oProductoService.Abort()
        Catch ex As CommunicationException
            oProductoService.Abort()
        End Try
    End Sub

    Private Sub frmProducto_Imagen_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub desactivar()
        txtArchivo.ReadOnly = True
        txtArchivo.BackColor = System.Drawing.SystemColors.Window
        btnBuscarArchivo.Enabled = False
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        biGuardar.Enabled = False
    End Sub

    Private Sub activar()
        txtArchivo.ReadOnly = False
        txtArchivo.BackColor = System.Drawing.SystemColors.Window
        btnBuscarArchivo.Enabled = True
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        biGuardar.Enabled = True
    End Sub

    Private Sub btnBuscarArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscarArchivo.Click
        Dim file As New OpenFileDialog()
        'file.Filter = "Archivo JPG|*.jpg"
        'file.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png|BMP|*.bmp|PDF|*.pdf"
        file.Filter = "Archivos(*.pdf,*.jpg,*.png,*.bmp)|*.pdf;*.jpg;*.jpeg;*.png;*.bmp|PDF(*.pdf)|*.pdf|JPG(*.jpg)|*.jpg;*.jpeg|PNG(*.png)|*.png|BMP(*.bmp)|*.bmp"
        If file.ShowDialog() = DialogResult.OK Then

            Extension = IO.Path.GetExtension(file.FileName)
            RutaArchivo = ""
            NombreArchivo = ""

            If Extension <> ".pdf" Then

                Dim fi As New FileInfo(file.FileName)
                Dim fileSize As Long = fi.Length

                'If fileSize < 2097152 Then
                pbFoto.Image = Image.FromFile(file.FileName)
                txtArchivo.Text = System.IO.Path.GetFileNameWithoutExtension(file.FileName)

                txtItem.Select()
                'Else
                'MsgBox("El archivo supero el maximo tamaño permitido : 2 mb.", MsgBoxStyle.Information, "Información")
                'End If
            Else
                txtArchivo.Text = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
                RutaArchivo = file.FileName

                txtItem.Select()
                ' NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If Extension <> ".pdf" Then
                If IsDBNull(pbFoto.Image) Then
                    MsgBox("Debe ingresar una imagen", MsgBoxStyle.Information, "Información")
                    btnBuscarArchivo.Focus()
                    Return False
                ElseIf toBlank(txtArchivo.Text) = "" Then
                    MsgBox("Debe ingresar el nombre de la imagen.", MsgBoxStyle.Information, "Información")
                    txtArchivo.Focus()
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biGuardar_Click(sender As Object, e As EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR la Imagen?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
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

                registro.IdImagen = 0
                'If Extension = ".pdf" Then
                'registro.Nombre = NombreArchivo
                'Else

                registro.Nombre = txtArchivo.Text
                'End If
                registro.Extension = toBlank(Extension)

                registro.Observacion = txtObservacion.Text
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If Extension = ".pdf" Then
                    Dim rutapdf As New FileStream(RutaArchivo, FileMode.Open, FileAccess.Read)
                    Dim binarioPDF(rutapdf.Length) As Byte
                    rutapdf.Read(binarioPDF, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                    rutapdf.Close()
                    registro.ArchivoData = IIf(txtArchivo.Text = "", Nothing, binarioPDF)
                Else
                    registro.ArchivoData = utils.ImageToByteArray(pbFoto.Image)
                End If

                If state_button Then

                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As ProductoService.ImagenesProducto)
        Try
            IdImagen = oProductoService.InsertarImagen(registro) 'oJobService.InsertarArchivos(registro)
            type_process = "insert"
            If IdImagen > 0 Then
                MsgBox("Se inserto la imagen correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA IMAGEN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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