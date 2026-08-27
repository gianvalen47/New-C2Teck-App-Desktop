Imports System.ServiceModel

Public Class frmProcesarMarcas
    Private oMarcacion As New MarcacionService.MarcacionServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        
        If MsgBox("¿Está Seguro de procesar las marcaciones de asistencia?", MsgBoxStyle.YesNo, "Procesar Marcas") = MsgBoxResult.Yes Then
            Try
                
                oMarcacion.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)

                oMarcacion.ProcesarMarcas(Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                MsgBox("Se procesaron las marcas con exito", MsgBoxStyle.Information, "Exito")

                Me.Close()

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Proceso")
            End Try

        End If
    End Sub

    Private Sub frmProcesarMarcas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMarcacion.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMarcacion.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMarcacion.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmProcesarMarcas_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 246)
        '/*************************************************************************************/

    End Sub
End Class