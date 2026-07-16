Imports System.Net
Imports System.ServiceModel
Public Class frmGenerarPeriodoInventario
    Dim ObjCierre As New CierreMesService.CierreMesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("¿Está seguro de GENERAR periodo?", MsgBoxStyle.YesNo, "Generar") = MsgBoxResult.Yes Then
            Try
                If ObjCierre.GenerarPeriodo(txtPeriodo.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                    MsgBox("Se realizó con exito el proceso", MsgBoxStyle.Information, "Exito")
                    Close()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

        End If
    End Sub

    Private Sub frmGenerarPeriodoInventario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            ObjCierre.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            ObjCierre.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            ObjCierre.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmGenerarPeriodoInventario_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub frmGenerarPeriodoInventario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 83)
        '/*************************************************************************************/

        txtPeriodo.Value = Year(Session.sFecha) + 1
    End Sub
End Class