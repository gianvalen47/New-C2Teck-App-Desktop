Imports System.ServiceModel

Public Class frmComSolicitudGastos_Archivos_Actualizar

    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient

    Private dtDatos As DataTable
    Public IdGasto As Integer
    Public Nombre As String
    Public IdGastoArchivo As Integer
    Public type_process As String
    Dim a() As Byte

    Private Sub frmComSolicitudGastos_Archivos_Actualizar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoService.Close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
        End Try
    End Sub

    Private Sub frmComSolicitudGastos_Archivos_Actualizar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComSolicitudGastos_Archivos_Actualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerRegistro()
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As SolicitudGastoService.SolicitudGastoArchivos
            oSolicitudGastoService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            registro = oSolicitudGastoService.ObtenerArchivo(IdGastoArchivo)

            txtArchivo.Text = registro.Nombre
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try

            Dim registro As New SolicitudGastoService.SolicitudGastoArchivos
            Dim solgasto As New SolicitudGastoService.SolicitudGasto


            solgasto.IdGasto = IdGasto
            registro.SolicitudGasto = solgasto

            registro.IdGastoArchivo = CLng(IdGastoArchivo)
            registro.Nombre = txtArchivo.Text
            registro.Observacion = txtObservacion.Text

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            Dim actualizar As Boolean

            actualizar = oSolicitudGastoService.ActualizarArchivo(registro)

            If actualizar = True Then
                type_process = "actualizar"
                MsgBox("Se actualizó el archivo correctamente.", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("No se pudo actualizar el archivo, Comuniquese con el Departamento de TI", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR EL ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    End Sub
End Class