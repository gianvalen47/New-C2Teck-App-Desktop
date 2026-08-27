Imports System.ServiceModel
Imports System.Net
Public Class frmOrdenCompra_GenerarPedido

    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient

    Public IdOrden As Integer
    Private dtSupervisores As DataTable
    Public estado_process As Integer
    Private dtADR As DataTable

    Private Sub frm_Ser_Cotizaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oOrdenCompraService) = False Then
                oOrdenCompraService.Close()
            End If
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
            If isClosed(oPedidoImportService) = False Then
                oPedidoImportService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmOrdenCompra_GenerarPedido_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        llenarCombos()
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         cmbIdPer.KeyPress _
                      , txtNumJob.KeyPress _
                      , txtInterprete.KeyPress _
                      , txtDestino.KeyPress _
                      , txtTecnico.KeyPress _
                      , cmbADR.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Ninguno)"
        Return fila
    End Function
    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Return fila
    End Function
    Private Sub llenarCombos()
        Try
            '======================================= SUPERVISOR ================================================
            dtSupervisores = oCotizacionServicioService.MostrarSupervisores(Session.sCodEmp).Tables(0)
            dtSupervisores.Rows.InsertAt(getRowTodos(dtSupervisores), 0)
            cmbIdPer.DataSource = dtSupervisores
            cmbIdPer.DropDownList.DataMember = dtSupervisores.Columns("ApeNom").ToString
            cmbIdPer.DropDownList.DisplayMember = dtSupervisores.Columns("ApeNom").ToString
            cmbIdPer.DropDownList.ValueMember = dtSupervisores.Columns("IdPer").ToString
            cmbIdPer.DropDownList.Columns(0).DataMember = dtSupervisores.Columns("IdPer").ToString
            cmbIdPer.DropDownList.Columns(1).DataMember = dtSupervisores.Columns("ApeNom").ToString
            cmbIdPer.SelectedIndex = 0
            dtSupervisores = Nothing

            '======================================= ADR ================================================
            dtADR = oPedidoImportService.ConsultarNumerosADR().Tables(0)
            dtADR.Rows.InsertAt(getRowTodos1(dtADR), 0)
            cmbADR.DataSource = dtADR
            cmbADR.DropDownList.DataMember = dtADR.Columns("NumeroADR").ToString
            cmbADR.DropDownList.DisplayMember = dtADR.Columns("NumeroADR").ToString
            cmbADR.DropDownList.ValueMember = dtADR.Columns("NumeroADR").ToString
            cmbADR.DropDownList.Columns(0).DataMember = dtADR.Columns("NumeroADR").ToString
            cmbADR.SelectedIndex = 0
            dtADR = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
        End If
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                Button1_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try

            If toNumber(cmbIdPer.Value) = 0 Then
                MsgBox("Debe Ingresar el supervisor del Pedido", MsgBoxStyle.Information, "Información")
                cmbIdPer.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Estás seguro de Generar el Pedido Interno?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    estado_process = oOrdenCompraService.GenerarPedidoInternoCodigoAntiguo(IdOrden, IIf(txtNumJob.Text = "", Nothing, txtNumJob.Text), cmbIdPer.Value,
                                                txtInterprete.Text, txtTecnico.Text, txtDestino.Text, IIf(cmbADR.SelectedIndex = 0, Nothing, cmbADR.Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    MsgBox("Se Generó el Pedido Interno Nº " + estado_process.ToString)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR EL PEDIDO INTERNO: " + ex.Message, MsgBoxStyle.Exclamation)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub
End Class