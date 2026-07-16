Imports System.ServiceModel
Public Class frmOportunidadNegocio_Cotizaciones
    '===========================Servicios====================================
    Private oOportunidadNegocioService As New OportunidadNegocioService.OportunidadNegocioServiceClient

    '======================Declaración de Variables==============================   
    Public IdOportunidad As Integer
    Private dtDatos As DataTable

    Private Sub frmOportunidadNegocio_Cotizaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOportunidadNegocioService.Close()
        Catch ex As TimeoutException
            oOportunidadNegocioService.Abort()
        Catch ex As CommunicationException
            oOportunidadNegocioService.Abort()
        End Try
    End Sub

    Private Sub frmOportunidadNegocio_Cotizaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOportunidadNegocio_Cotizaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right

        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oOportunidadNegocioService.MostrarCotizaciones(IdOportunidad).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbElminar_Click(sender As Object, e As EventArgs) Handles cmbElminar.Click
        Try
            Dim IdCotizacion As Int64 = dgvDatos.CurrentRow.Cells("IdCotizacion").Text
            '  Dim IdOportunidad As Int64 = dgvDatos.CurrentRow.Cells("IdOportunidad").Text

            Dim estado_process As Boolean
            If MsgBox("¿Está seguro de DESVINCULAR la cotización a la Oportunidad de Negocio N°: " & IdOportunidad.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                estado_process = oOportunidadNegocioService.DesvincularCotizacion(IdOportunidad, IdCotizacion, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                MsgBox("Se desvinculó la Cotización correctamente ")
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox("Error al Desvincular la Cotización: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class