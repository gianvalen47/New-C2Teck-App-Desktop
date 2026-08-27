Public Class frmAprobarServicios_Detalle

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oCotizacionServicioDetService As New CotizacionServicioDetService.CotizacionServicioDetServiceClient
    Public Fecha As Date
    Private dtDatos As DataTable
    Private dtDatos2 As DataTable
    Private dtDatosCosto As DataTable
    Private dtDetalles As DataTable
    Public IdCotizacionSer As Integer
    Public NumCotizacion As String
    Public Cliente As String
    Public IdCliente As Int64
    Private Resta As Decimal
    Private Precio As Decimal
    Private TotalRepuestos As Decimal

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub AprobarServicios_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
        End If
    End Sub
    Private Sub AprobarServicios_Detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)

        txtFecha.Text = Format(Fecha, "dd/MM/yyyy")
        txtNumDoc.Text = NumCotizacion
        txtCliente.Text = Cliente
        ObtenerRegistro()
        listaDatos()
        listaDatosCotMon()
        listaDatosCostos()
        If txtUtilidadteocrico.Value <= 0 Then
            txtUtilidadteocrico.BackColor = Color.IndianRed
            txtUtilidadteocrico.ForeColor = Color.Black
        End If
        position()

    End Sub

    Private Sub position()
        If dgvDatos.RowCount > 0 Then
            dgvDatos.Row = 0
            dgvDatos.Col = 1
        End If
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As New CotizacionServicioService.CotizacionServicio
            registro = oCotizacionServicioService.Obtener(IdCotizacionSer)

            cmbCodMon.Value = registro.Moneda.CodMon

            txtArea.Text = registro.CentroCosto.Area.DesArea
            txtCentroCosto.Text = registro.CentroCosto.DesCentro
            txtUsuario.Text = registro.CodUsu

            lblTotalMontoSinIgv.Text = "IGV " + cmbCodMon.Text + " ==> "
            'lblTotalMontoBruto.Text = "MONTO TOTAL BRUTO " + cmbCodMon.Text + " :"
            lblMontoDscto.Text = "SUBTOTAL " + cmbCodMon.Text + " ==> "
            lblMontoTotal.Text = "MONTO TOTAL " + cmbCodMon.Text + " ==> "
            lblMontoTotalNeto.Text = "MONTO TOTAL NETO " + cmbCodMon.Text + " ==> "


            txtMontoSinIGV.Value = registro.TotIgv
            txtMontoBruto.Value = registro.TotBruto
            txtTotalDescuento.Value = registro.TotDscto
            txtMontoTotalNeto.Value = registro.TotNeto
            txtMontoTotal.Value = registro.TotVenta
            txtventa.Value = registro.TotVenta

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            dtDatos = oCotizacionServicioService.MostrarParaCreditosDet(IdCotizacionSer).Tables(0)
            dgvDatos.DataSource = dtDatos

            Dim Contador As Decimal
            Dim Contador2 As Decimal
            Contador = 0
            Contador2 = 0

            For Each Fila As DataRow In dtDatos.Rows
                If Fila.Item("PreMerSug") > 0 Then
                    If Fila.Item("DsctoSug") > 0 Then
                        Resta = (Fila.Item("PreMerSug") * Fila.Item("CanMer")) * ((100 - Fila.Item("DsctoSug")) / 100)
                    ElseIf Fila.Item("DsctoSug") = 0 Then
                        Resta = Fila.Item("PreMerSug") * Fila.Item("CanMer")
                    End If
                ElseIf Fila.Item("PreMerSug") = 0 Then
                    If Fila.Item("DsctoSug") > 0 Then
                        Resta = (((100 - Fila.Item("DsctoSug")) * Fila.Item("PreMer") * Fila.Item("CanMer")) / 100)
                    ElseIf Fila.Item("DsctoSug") = 0 Then
                        Resta = 0
                    End If
                End If
                Contador = Contador + Resta
            Next

            For Each Fila As DataRow In dtDatos.Rows
                Precio = (Fila.Item("TotFila"))
                Contador2 = Contador2 + Precio
            Next

            txtTotalSug.Text = Contador
            txtTotalNeto.Text = Contador2
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosCotMon()
        Try
            dtDatos2 = oCotizacionServicioDetService.Mostrar(IdCotizacionSer).Tables(0)
            dgvDatosCot.DataSource = dtDatos2
            'enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub listaDatosCostos()
        Try
            dtDatosCosto = oCotizacionServicioService.MostrarCostosCotizacion(IdCotizacionSer).Tables(0)
            dgvcostos.DataSource = dtDatosCosto


            Dim totcostoteorico As Decimal
            'Dim totcostoreal As Decimal

            For Each Fila As DataRow In dtDatosCosto.Rows
                totcostoteorico = totcostoteorico + IIf(IsDBNull(Fila.Item("CostoTeorico")), 0, Fila.Item("CostoTeorico"))
                '  totcostoreal = totcostoreal + IIf(IsDBNull(Fila.Item("CostoReal")), 0, Fila.Item("CostoReal"))
            Next

            txtCostoTeorico.Value = totcostoteorico
            txtUtilidadteocrico.Value = txtMontoTotal.Value - totcostoteorico
            txtporcentajeteorico.Value = (txtUtilidadteocrico.Value / txtMontoTotal.Value) * 100


            'enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.Click
        dgvDatos.SelectCurrentCellText()
    End Sub

    Private Sub biAprobar_Click(sender As Object, e As EventArgs) Handles biAprobar.Click
        Try

            Dim frm As New frmAprobarServicios_Aprobar
            frm.IdCotizacionSer = IdCotizacionSer
            frm.IdCliente = IdCliente
            frm.NumCotizacion = NumCotizacion
            frm.Fecha = Fecha
            frm.Text = "Aprobar/Rechazar Cotización Nº " & NumCotizacion
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class