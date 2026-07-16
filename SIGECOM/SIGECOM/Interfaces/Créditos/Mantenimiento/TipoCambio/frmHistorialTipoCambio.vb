Imports System.ServiceModel
Public Class frmHistorialTipoCambio

    Private oAprobarVentaService As New AprobarVentaService.AprobarVentaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================   
    Private dtDatos As DataTable

    Private Sub frmHistorialTipoCambio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oAprobarVentaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oAprobarVentaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oAprobarVentaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmHistorialTipoCambio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmHistorialTipoCambio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 278)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oAprobarVentaService.MostrarHistorialTipoCambio().Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class