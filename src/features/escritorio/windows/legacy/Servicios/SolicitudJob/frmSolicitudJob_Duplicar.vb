Imports System.ServiceModel

Public Class frmSolicitudJob_Duplicar

    Private oSolicitudJobService As New SolicitudJobService.SolicitudJobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public NumSolicitud As String

    Private Sub frmSolicitudJob_Duplicar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSolicitudJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSolicitudJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmSolicitudJob_Duplicar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSolicitudJob_Duplicar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtFecha.Value = Today
        Me.Text = "Duplicar Solicitud de OT N°:" & NumSolicitud
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDuplicar.Click
        Try
            If MsgBox("¿Esta seguro de DUPLICAR la Solicitud de OT N° " & NumSolicitud & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim usuario As New SeguridadService.Usuario
                Dim IdPersona As Integer
                usuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
                IdPersona = usuario.Persona.IdPer

                Dim estado_process As String = ""
                estado_process = oSolicitudJobService.Duplicar(NumSolicitud, txtFecha.Value, IdPersona, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process <> "" Then
                    MsgBox("Se generó la Solicitud de OT Nº " + estado_process + " correctamente.")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el Proceso, comunicarse con el área de TI!!!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class