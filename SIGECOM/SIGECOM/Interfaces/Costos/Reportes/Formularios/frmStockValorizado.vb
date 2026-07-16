Imports System.ServiceModel
Public Class frmStockValorizado
    Private ObjCierre As New CierreMesService.CierreMesServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjLocMerca As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private dtOficina As New DataTable
    Private dtAlmacen As New DataTable

    Private Sub frmStockValorizado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cbAlmacen.KeyPress _
            , cbFecha.KeyPress _
            , cbOficina.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmStockValorizado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjCierre) = False Then
                ObjCierre.Close()
            End If
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
            If isClosed(ObjLocMerca) = False Then
                ObjLocMerca.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmStockValorizado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmStockValorizado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombos()
    End Sub
    'Private Sub Finalizar()
    '    Try
    '        ObjCierre.Close()
    '        ObjMaestro.Close()

    '    Catch ex As TimeoutException
    '        ObjCierre.Abort()
    '        ObjMaestro.Abort()
    '    Catch ex As CommunicationException
    '        ObjCierre.Abort()
    '        ObjMaestro.Abort()

    '    End Try
    '    Me.Dispose(True)
    '    GC.SuppressFinalize(Me)
    'End Sub

    Private Sub LlenarCombos()
        Try
            dtOficina = ObjMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing
        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Dim dtStockValorizado As New DataView

            If rbStockFecha.Checked Then
                dtStockValorizado = ObjCierre.StockValorizado(Session.sCodEmp, IIf(rbTotalGeneral.Checked, 0, cbAlmacen.Value), cbFecha.Value).Tables(0).DefaultView
            ElseIf rbSaldoInicio.Checked Then
                dtStockValorizado = ObjCierre.MostrarSaldoInicio(Session.sCodEmp, IIf(rbTotalGeneral.Checked, 0, cbAlmacen.Value), cbFecha.Value).Tables(0).DefaultView
            ElseIf rbStockActual.Checked Then
                dtStockValorizado = ObjLocMerca.Mostrar(Session.sCodEmp, IIf(rbTotalGeneral.Checked, 0, cbAlmacen.Value)).Tables(0).DefaultView
            End If
            If dtStockValorizado.Count = 0 Then
                MsgBox("No hay datos que Mostrar, Verfique los parametros.", MsgBoxStyle.Information, "No Hay Datos")
            Else
                '/////FILTRAR STOCK/////
                If rbSinCeros.Checked Then
                    dtStockValorizado.RowFilter = "Stock <> 0"
                ElseIf rbPositivos.Checked Then
                    dtStockValorizado.RowFilter = "Stock > 0"
                ElseIf rbNegativos.Checked Then
                    dtStockValorizado.RowFilter = "Stock < 0"
                ElseIf rbCeros.Checked Then
                    dtStockValorizado.RowFilter = "Stock = 0"
                End If
                '///////////////////////

                Dim forma As New frmReportes
                If rbDetalle.Checked Then
                    If ckLibro.Checked Then
                        Dim reporte As New rpStockValorizadoLibro
                        reporte.SetDataSource(dtStockValorizado)
                        forma.crvReportes.ReportSource = reporte
                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                    Else
                        Dim reporte As New rpStockValorizado
                        reporte.SetDataSource(dtStockValorizado)
                        forma.crvReportes.ReportSource = reporte
                        reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                    End If
                ElseIf rbTotalGeneral.Checked Then
                    Dim reporte As New rpStockValorizadoGeneral
                    reporte.SetDataSource(dtStockValorizado)
                    forma.crvReportes.ReportSource = reporte
                    reporte.SetParameterValue("Fecha", IIf(rbStockActual.Checked, Today, cbFecha.Text))
                End If
                forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Reporte de Stock Valorizado"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Consulta")
        End Try

    End Sub

    Private Sub rdTotalAlmacen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ckLibro.Visible = False
        ckLibro.Checked = False
    End Sub

    Private Sub rbTotalGeneral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTotalGeneral.CheckedChanged
        ckLibro.Visible = False
        ckLibro.Checked = False
        gpAlmacenes.Enabled = False
    End Sub

    Private Sub rbDetalle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDetalle.CheckedChanged
        ckLibro.Visible = True
        gpAlmacenes.Enabled = True
    End Sub

End Class