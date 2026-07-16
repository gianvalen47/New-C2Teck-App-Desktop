Imports System.ServiceModel

Public Class frmActivoFijo_Archivos_Actualizar

    '===========================Servicios====================================================
    Private oActivoFijoService As New ActivoFijoService.ActivoFijoServiceClient

    Private dtDatos As DataTable
    Public IdGasto As Integer
    Public Nombre As String
    Public CodActivo As String
    Public IdActivoArchivo As Integer
    Public type_process As String

    Private Sub frmActivoFijo_Archivos_Actualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerRegistro()
    End Sub

    Private Sub frmActivoFijo_Archivos_Actualizar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmActivoFijo_Archivos_Actualizar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oActivoFijoService.Close()
        Catch ex As TimeoutException
            oActivoFijoService.Abort()
        Catch ex As CommunicationException
            oActivoFijoService.Abort()
        End Try
    End Sub

    Private Sub ObtenerRegistro()

        Try
            Dim registro As ActivoFijoService.ActivoFijoArchivos
            oActivoFijoService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
            registro = oActivoFijoService.ObtenerArchivo(IdActivoArchivo)

            txtArchivo.Text = registro.Nombre
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            Dim registro As New ActivoFijoService.ActivoFijoArchivos
            Dim activofijo As New ActivoFijoService.ActivoFijo
            Dim empresa As New ActivoFijoService.Empresa

            empresa.CodEmp = Session.sCodEmp
            activofijo.Empresa = empresa
            activofijo.CodActivo = CodActivo
            registro.ActivoFijo = activofijo

            registro.IdActivoArchivo = CLng(IdActivoArchivo)
            registro.Nombre = txtArchivo.Text
            registro.Observacion = txtObservacion.Text
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            Dim actualizar As Boolean

            actualizar = oActivoFijoService.ActualizarArchivo(registro)

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