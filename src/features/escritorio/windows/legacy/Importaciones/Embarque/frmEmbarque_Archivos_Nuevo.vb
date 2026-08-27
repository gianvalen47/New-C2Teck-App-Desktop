Imports System.ServiceModel
Imports System.IO
Imports System

Public Class frmEmbarque_Archivos_Nuevo

    Private oEmbarqueService As New EmbarqueService.EmbarqueServiceClient

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String

    Private dtDatos As DataTable
    Public CodEmbarque As String
    Public IdEmbarqueArchivo As Int64
    Private Extension As String
    Private NombreArchivo As String
    Private RutaArchivo As String

    Private Sub frmCotizacion_Archivos_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oEmbarqueService.Close()
        Catch ex As TimeoutException
            oEmbarqueService.Abort()
        Catch ex As CommunicationException
            oEmbarqueService.Abort()
        End Try
    End Sub

    Private Sub frmCotizacion_Archivos_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCotizacion_Archivos_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If state_button Then
            'ObtenerRegistro()
            desactivar()
        Else
            activar()
            Me.Text = "Nuevo Archivo"
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

    'Private Sub ObtenerRegistro()
    '    Try
    '        Dim registro As CotizacionService.CotizacionArchivo
    '        registro = oCotizacionService.ObtenerArchivo(IdCotizacionArchivo)

    '        txtArchivo.Text = registro.Nombre & "" & registro.Extension
    '        Me.pbFoto.Image = utils.ByteArrayToImage(registro.ArchivoData)
    '        txtObservacion.Text = registro.Observacion

    '        Me.Text = "Foto Seguimiento: " + Chr(34) + registro.Nombre + Chr(34)

    '    Catch ex As Exception
    '        MsgBox("ERROR AL OBTENER LA FOTO: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub btnBuscarArchivo_Click(sender As Object, e As EventArgs) Handles btnBuscarArchivo.Click

        Dim file As New OpenFileDialog()
        'file.Filter = "Archivo JPG|*.jpg"
        file.Filter = "Archivos(*.pdf,*.jpg,*.png,*.bmp)|*.pdf;*.jpg;*.jpeg;*.png;*.bmp|PDF(*.pdf)|*.pdf|JPG(*.jpg)|*.jpg;*.jpeg|PNG(*.png)|*.png|BMP(*.bmp)|*.bmp"
        If file.ShowDialog() = DialogResult.OK Then

            Extension = IO.Path.GetExtension(file.FileName)
            RutaArchivo = ""
            NombreArchivo = ""

            If Extension <> ".pdf" Then
                Dim fi As New FileInfo(file.FileName)
                Dim fileSize As Long = fi.Length

                '    If fileSize < 2097152 Then
                pbFoto.Image = Image.FromFile(file.FileName)
                txtArchivo.Text = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
                'Extension = IO.Path.GetExtension(file.FileName)
                '   Else
                '  MsgBox("El archivo supero el maximo tamaño permitido : 2 mb.", MsgBoxStyle.Information, "Información")
                'End If
            Else
                txtArchivo.Text = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
                RutaArchivo = file.FileName
                '   NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If Extension <> ".pdf" Then
                If IsDBNull(pbFoto.Image) Then
                    MsgBox("Debe ingresar una imagen.", MsgBoxStyle.Information, "Información")
                    btnBuscarArchivo.Focus()
                    Return False
                ElseIf toBlank(txtArchivo.Text) = "" Then
                    MsgBox("Debe ingresar el nombre del archivo.", MsgBoxStyle.Information, "Información")
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
            If MsgBox("¿Está seguro de GUARDAR el Archivo?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New EmbarqueService.EmbarqueArchivos
                Dim embarque As New EmbarqueService.Embarque

                'registro.IdSeguimientoFoto 
                embarque.CodEmbarque = CodEmbarque
                registro.Embarque = embarque

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
                    registro.ArchivoData = IIf(RutaArchivo = "", Nothing, binarioPDF)
                Else
                    registro.ArchivoData = utils.ImageToByteArray(pbFoto.Image)
                End If

                If state_button Then
                    'Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As EmbarqueService.EmbarqueArchivos)
        Try
            IdEmbarqueArchivo = oEmbarqueService.InsertarArchivos(registro)
            type_process = "insert"
            If IdEmbarqueArchivo > 0 Then

                MsgBox("Se inserto el archivo correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR EL ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class