
Imports System.ServiceModel

Public Class frmGuiaRemision_ConsultarSugerido

    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oCotizacionService As New CotizacionService.CotizacionServiceClient

    Private dtDatos As DataTable
    Public IdCodigo As Integer
    Public TipoCodigo As String

    Private Sub frmGuiaRemision_ConsultarSugerido_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oGuiaRemisionService.Close()
            oFacturaService.Close()
            oBoletaService.Close()
            oOrdenCompraService.Close()
            oCotizacionService.Close()
        Catch ex As TimeoutException
            oGuiaRemisionService.Abort()
            oFacturaService.Abort()
            oBoletaService.Abort()
            oOrdenCompraService.Abort()
            oCotizacionService.Abort()
        Catch ex As CommunicationException
            oGuiaRemisionService.Abort()
            oFacturaService.Abort()
            oBoletaService.Abort()
            oOrdenCompraService.Abort()
            oCotizacionService.Abort()
        End Try
        GC.SuppressFinalize(Me)
    End Sub


    Private Sub frmGuiaRemision_ConsultarSugerido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGuiaRemision_ConsultarSugerido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim estilo As New Estilo
            estilo.cargaEstiloGridExt(dgvDatos)
            dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            listaDatos()

        Catch ex As Exception
            MsgBox("Error al Cargar el Load : " + ex.Message)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If TipoCodigo = "GR" Then
                dtDatos = oGuiaRemisionService.ConsultarSugerido(IdCodigo).Tables(0)
                dgvDatos.DataSource = dtDatos
            ElseIf TipoCodigo = "FA" Then
                dtDatos = oFacturaService.ConsultarSugerido(IdCodigo).Tables(0)
                dgvDatos.DataSource = dtDatos
            ElseIf TipoCodigo = "BO" Then
                dtDatos = oBoletaService.ConsultarSugerido(IdCodigo).Tables(0)
                dgvDatos.DataSource = dtDatos
            ElseIf TipoCodigo = "OC" Then
                dtDatos = oOrdenCompraService.ConsultarSugerido(IdCodigo).Tables(0)
                dgvDatos.DataSource = dtDatos
            ElseIf TipoCodigo = "CT" Then
                dtDatos = oCotizacionService.ConsultarSugerido(IdCodigo).Tables(0)
                dgvDatos.DataSource = dtDatos
            End If

        Catch ex As Exception
            MsgBox("Error al listar los Datos " + ex.Message)
        End Try
    End Sub


End Class