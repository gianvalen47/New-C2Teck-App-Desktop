Imports System.ServiceModel

Public Class frmPedidosImportacion_Archivos_Actualizar

    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient

    Private dtDatos As DataTable
    'Public CodJob As Integer
    Public Nombre As String
    Public IdPedidoImpArchivo As Integer
    Public IdPedidoImp As String
    Public type_process As String

    Private Sub frmPedidosImportacion_Archivos_Actualizar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPedidoImportService.Close()
        Catch ex As TimeoutException
            oPedidoImportService.Abort()
        Catch ex As CommunicationException
            oPedidoImportService.Abort()
        End Try
    End Sub

    Private Sub frmPedidosImportacion_Archivos_Actualizar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPedidosImportacion_Archivos_Actualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerRegistro()
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro2 As PedidoImportService.PedidoImportArchivos
            oPedidoImportService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            registro2 = oPedidoImportService.ObtenerArchivo(IdPedidoImpArchivo)

            txtArchivo.Text = registro2.Nombre
            txtObservacion.Text = registro2.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            Dim registro As New PedidoImportService.PedidoImportArchivos
            Dim pedidoimp As New PedidoImportService.PedidoImport

            pedidoimp.IdPedidoImp = IdPedidoImp
            registro.PedidoImport = pedidoimp

            registro.IdPedidoImpArchivo = CLng(IdPedidoImpArchivo)
            registro.Nombre = txtArchivo.Text
            registro.Observacion = txtObservacion.Text
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            Dim actualizar As Boolean

            actualizar = oPedidoImportService.ActualizarArchivo(registro)

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