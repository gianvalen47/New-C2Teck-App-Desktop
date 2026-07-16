Imports System.ServiceModel
Public Class frmPedido_Imprimir

    '===========================Servicios====================================================
    Private oPedidoService As New PedidoService.PedidoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Public IdLocacion As Integer
    Public IdCliente As Integer
    Public IdPedido As Integer
    Public NumOrden As String
    Public NumJob As String
    Public FecIni As String
    Public FecFin As String
    Public DesOfi As String
    Public DesAlm As String
    Public DesCli As String
    Public NumPedido As Integer

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmComSolicitudGasto_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oPedidoService) = False Then
                oPedidoService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmPedido_Imprimir_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        rbPrincipal.Checked = True
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            If rbPrincipal.Checked = True Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rpPedidoInterno

                dtReporte = oPedidoService.ReportePedido(IdPedido).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    If rbExcel.Checked Then
                        DataGridView1.DataSource = dtReporte
                        Dim Export As Boolean = ExportarExcel(DataGridView1)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Pedido Interno para Importar"

                        forma.ShowDialog()
                    End If
                End If

            ElseIf rbListado.Checked = True Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rpListadoPedido

                Dim registro As New PedidoService.Pedido
                Dim locacion As New PedidoService.Locacion
                Dim cliente As New PedidoService.Cliente

                If toNumber(IdLocacion) = 0 Then
                    locacion.IdLocacion = -1
                    registro.Locacion = locacion
                Else
                    locacion.IdLocacion = toNumber(IdLocacion)
                    registro.Locacion = locacion
                End If
                cliente.IdCliente = toNumber(IdCliente)
                registro.Cliente = cliente
                registro.IdPedido = toNumber(NumPedido)
                registro.NumOrden = NumOrden
                registro.NumJob = toBlank(NumJob)
                If toNull(FecIni) <> Nothing Then
                    registro.FecIni = FecIni
                End If
                If toNull(FecFin) <> Nothing Then
                    registro.FecFin = FecFin
                End If


                dtReporte = oPedidoService.Filtrar(registro).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    If rbExcel.Checked Then
                        DataGridView1.DataSource = dtReporte
                        Dim Export As Boolean = ExportarExcel(DataGridView1)
                        If Export Then
                            MsgBox("Se realizó la exportación correctamente")
                        End If
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        reporte.SetParameterValue("pDesOfi", DesOfi)
                        reporte.SetParameterValue("pDesAlm", DesAlm)
                        reporte.SetParameterValue("pDesCli", DesCli)
                        reporte.SetParameterValue("pFecIni", FecIni)
                        reporte.SetParameterValue("pFecFin", FecFin)
                        reporte.SetParameterValue("pNumJob", NumJob)
                        reporte.SetParameterValue("pIdPedido", IIf(toNumber(NumPedido) = 0, "", NumPedido))
                        reporte.SetParameterValue("pNumOrden", NumOrden)
                        forma.Text = "Reporte de Listado de Pedidos Internos"

                        forma.ShowDialog()
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class