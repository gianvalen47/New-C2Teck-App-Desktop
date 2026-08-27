Imports System.ServiceModel

Public Class frmJob_Archivos_Actualizar

    Private oJobService As New JobService.JobServiceClient

    Private dtDatos As DataTable
    Public CodJob As String
    Public Nombre As String
    Public IdArchivo As Integer
    Public type_process As String

    Private Sub frmJob_Archivos_Actualizar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
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
            Dim registro2 As JobService.JobArchivos
            oJobService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            registro2 = oJobService.ObtenerArchivos(IdArchivo)

            txtArchivo.Text = registro2.Nombre
            txtObservacion.Text = registro2.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Try

            Dim registro As New JobService.JobArchivos
            Dim job As New JobService.Job

            job.CodJob = CodJob
            registro.Job = job

            registro.IdArchivo = CLng(IdArchivo)
            registro.Nombre = txtArchivo.Text
            registro.Observacion = txtObservacion.Text
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            Dim actualizar As Boolean

            actualizar = oJobService.ActualizarArchivos(registro)

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