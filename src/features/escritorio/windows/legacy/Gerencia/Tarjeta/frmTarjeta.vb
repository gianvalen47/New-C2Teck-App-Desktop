Imports System.ServiceModel

Public Class frmTarjeta

    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Public CodMer As String
    Private dtDatos As DataTable
    Public IdLocacion As Integer

    Public CodPartida As String
    Public Partida As String
    Public Descripcion1 As String
    Public Descripcion2 As String
    Public CodRubro As String
    Public Rubro As String
    Public Peso As Decimal
    Public TipCodMov As String
    Public TipMov As String
    Public Stock As Integer
    Public FabricaUSA As Decimal
    Public MostradorNS As Decimal
    Public MostradorUS As Decimal
    Public CostoDol As Decimal
    Public CostoSol As Decimal

    Private Sub frmTarjeta_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionMercaderiaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oLocacionMercaderiaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oLocacionMercaderiaService.Abort()
            oSeguridadService.Abort()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmTarjeta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmTarjeta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        Me.CancelButton = Me.btnCancelar
        listaDatos()
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
        dgvDatos.RowFormatStyle.FontSize = 9.0!
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right
        Me.Text = "Lista de Stock's de la Mercadería ( " + CodMer + " )"
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oLocacionMercaderiaService.MostrarStockGeneral(IdLocacion, CodMer, toNumber(txtanio.Value)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpTarjetaGerencial
            Dim dtReporte As New DataTable

            dtReporte = oLocacionMercaderiaService.MostrarStockGeneral(IdLocacion, CodMer, toNumber(txtanio.Value)).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                reporte.SetParameterValue("CodMer", CodMer)
                reporte.SetParameterValue("CodPartida", CodPartida)
                reporte.SetParameterValue("Partida", Partida)
                reporte.SetParameterValue("CodRubro", CodRubro)
                reporte.SetParameterValue("Rubro", Rubro)
                reporte.SetParameterValue("Descripcion1", Descripcion1)
                reporte.SetParameterValue("Descripcion2", Descripcion2)
                reporte.SetParameterValue("Peso", Peso)
                reporte.SetParameterValue("TipMov", TipMov)
                reporte.SetParameterValue("TipCodMov", TipCodMov)
                reporte.SetParameterValue("FabricaUSA", FabricaUSA)
                reporte.SetParameterValue("MostradorUS", MostradorUS)
                reporte.SetParameterValue("MostradorNS", MostradorNS)
                reporte.SetParameterValue("CostoDol", CostoDol)
                reporte.SetParameterValue("CostoSol", CostoSol)
                reporte.SetParameterValue("Stock", Stock)
                reporte.SetParameterValue("Anio", txtanio.Value)

                forma.Text = "Reporte  de Tarjetas"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub txtanio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtanio.ValueChanged
        listaDatos()
    End Sub


End Class