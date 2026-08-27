Imports System.ServiceModel
Imports System.IO
Imports System

Public Class frmSeguimiento_Fotos_Nuevo

    Private oSeguimientoService As New SeguimientoService.SeguimientoServiceClient

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String

    Private dtDatos As DataTable
    Public IdSeguimiento As Integer
    Public IdSeguimientoFoto As Integer
    Private Extension As String

    Private Sub frmSeguimiento_Fotos_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSeguimientoService.Close()
        Catch ex As TimeoutException
            oSeguimientoService.Abort()
        Catch ex As CommunicationException
            oSeguimientoService.Abort()
        End Try
    End Sub

    Private Sub frmSeguimiento_Fotos_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSeguimiento_Fotos_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If state_button Then
            ObtenerRegistro()
            desactivar()
        Else
            activar()
            Me.Text = "Nueva Foto de Seguimiento"
        End If

    End Sub

    Private Sub desactivar()

        txtArchivo.ReadOnly = True
        txtArchivo.BackColor = System.Drawing.SystemColors.Window
        btnBuscarFoto.Enabled = False
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        biGuardar.Enabled = False

    End Sub

    Private Sub activar()

        txtArchivo.ReadOnly = False
        txtArchivo.BackColor = System.Drawing.SystemColors.Window
        btnBuscarFoto.Enabled = True
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        biGuardar.Enabled = True

    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As SeguimientoService.FotoSeguimiento
            registro = oSeguimientoService.ObtenerFoto(IdSeguimientoFoto)

            txtArchivo.Text = registro.Nombre & "" & registro.Extension
            Me.pbFoto.Image = utils.ByteArrayToImage(registro.ArchivoData)
            txtObservacion.Text = registro.Observacion

            Me.Text = "Foto Seguimiento: " + Chr(34) + registro.Nombre + Chr(34)

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA FOTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnBuscarFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFoto.Click
        Dim file As New OpenFileDialog()
        'file.Filter = "Archivo JPG|*.jpg"
        file.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png|BMP|*.bmp"
        If file.ShowDialog() = DialogResult.OK Then

            Dim fi As New FileInfo(file.FileName)
            Dim fileSize As Long = fi.Length

            If fileSize < 2097152 Then
                pbFoto.Image = Image.FromFile(file.FileName)
                txtArchivo.Text = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
                Extension = IO.Path.GetExtension(file.FileName)
            Else
                MsgBox("El archivo supero el maximo tamaño permitido : 2 mb.", MsgBoxStyle.Information, "Información")

            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IsDBNull(pbFoto.Image) Then
                MsgBox("Debe ingresar una foto.", MsgBoxStyle.Information, "Información")
                btnBuscarFoto.Focus()
                Return False
            ElseIf toBlank(txtArchivo.Text) = "" Then
                MsgBox("Debe ingresar el nombre del archivo.", MsgBoxStyle.Information, "Información")
                txtArchivo.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR la Foto?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
                Dim registro As New SeguimientoService.FotoSeguimiento
                Dim seguimiento As New SeguimientoService.Seguimiento

                'registro.IdSeguimientoFoto 
                seguimiento.IdSeguimiento = IdSeguimiento
                registro.Seguimiento = seguimiento

                registro.Nombre = txtArchivo.Text
                registro.Extension = toBlank(Extension)

                registro.ArchivoData = utils.ImageToByteArray(pbFoto.Image)

                registro.Observacion = txtObservacion.Text
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then
                    'Modificar(registro)
                Else
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR LA FOTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As SeguimientoService.FotoSeguimiento)
        Try
            '            Dim estado_process As Boolean
            IdSeguimientoFoto = oSeguimientoService.InsertarFoto(registro)
            type_process = "insert"
            If IdSeguimientoFoto > 0 Then

                MsgBox("Se inserto la foto correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA FOTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub Modificar(ByVal registro As SeguimientoService.FotoSeguimiento)
    '    Try
    '        Dim estado_process As Boolean
    '        estado_process = oSeguimientoService.(registro)
    '        type_process = "update"
    '        If estado_process = True Then
    '            MsgBox("Se modificó el Colaborador Correctamente")
    '            Desactivar()
    '            ObtenerRegistro()
    '        Else
    '            MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas!", MsgBoxStyle.Critical)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("ERROR AL MODIFICAR COLABORADOR: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub


    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class