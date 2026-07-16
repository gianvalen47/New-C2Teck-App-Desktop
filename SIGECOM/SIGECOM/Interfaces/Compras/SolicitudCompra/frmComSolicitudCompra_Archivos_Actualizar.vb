Imports System.ServiceModel

Public Class frmComSolicitudCompra_Archivos_Actualizar

    Private oSolicitudService As New SolicitudCompraService.SolicitudCompraServiceClient

    Private dtDatos As DataTable
    Public IdSolicitud As Int64
    Public Nombre As String
    Public IdArchivo As Int64
    Public type_process As String

    Private Sub frmJob_Archivos_Actualizar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudService.Close()
        Catch ex As TimeoutException
            oSolicitudService.Abort()
        Catch ex As CommunicationException
            oSolicitudService.Abort()
        End Try
    End Sub

    Private Sub frmJob_Archivos_Actualizar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_Archivos_Actualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerRegistro()
    End Sub


    Private Sub ObtenerRegistro()

        Try
            Dim registro2 As SolicitudCompraService.SolicitudCompraArchivos
            oSolicitudService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            registro2 = oSolicitudService.ObtenerArchivo(IdArchivo)

            txtArchivo.Text = registro2.Nombre
            txtObservacion.Text = registro2.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try

            Dim registro As New SolicitudCompraService.SolicitudCompraArchivos

            Dim solicitud As New SolicitudCompraService.SolicitudCompra
            solicitud.IdSolicitud = IdSolicitud
            registro.SolicitudCompra = solicitud

            registro.IdSolicitudArchivo = IdArchivo
            registro.Nombre = txtArchivo.Text
            registro.Observacion = txtObservacion.Text
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            Dim actualizar As Boolean

            actualizar = oSolicitudService.ActualizarArchivo(registro)

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