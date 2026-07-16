Public Class frmRepCostoVenta
    Private oDocumentoCostoService As New DocumentoCostoService.DocumentoCostoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtAlmacenes As DataTable
    Private dtOficinas As DataTable
    Private dtMonedas As DataTable
    Dim IdCliente As Integer

    Private Sub frmRepCostoVenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepCostoVenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCliente.KeyPress _
            , cbCodMon.KeyPress _
            , cbFecFinal.KeyPress _
            , cbFecInicio.KeyPress _
            , cmbIdLocacion.KeyPress _
            , cmbOficinas.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmRepCostoVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Mes, Anio As Integer
        Dim Fecha As Date

        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        llenarCombos()
        cbFecInicio.Focus()
        IdCliente = 0
        cbCodMon.Value = "NS"
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cbCodMon.DataSource = dtMonedas
            cbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            cbCodMon.SelectedIndex = 0
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepCostoVenta
            dtReporte = oDocumentoCostoService.ReporteCostoVenta(IIf(cmbOficinas.Text = "(Todos)", 0, cmbIdLocacion.Value), cbFecInicio.Text, cbFecFinal.Text, cbCodMon.Value, IdCliente).Tables(0)
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False
                reporte.SetParameterValue("cbFecInicio", cbFecInicio.Text)
                reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
                If cbCodMon.Value = "US" Then
                    reporte.SetParameterValue("Moneda", "DÓLARES")
                ElseIf cbCodMon.Value = "NS" Then
                    reporte.SetParameterValue("Moneda", "SÓLES")
                ElseIf cbCodMon.Value = "EU" Then
                    reporte.SetParameterValue("Moneda", "EUROS")
                End If
                forma.Text = "Reporte de Costo de Venta"
                ' dtReporte.WriteXmlSchema("D:\SIGECOM\SIGECOM\Interfaces\Costos\Reportes\OrigenDatos\CostoVenta.xml")
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            dtAlmacenes = Nothing
            If cmbOficinas.Text = "(Todos)" Then
                lblAlmacen.Enabled = False
                cmbIdLocacion.Enabled = False
            Else
                lblAlmacen.Enabled = True
                cmbIdLocacion.Enabled = True
            End If

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            rbBuscarCliente.Checked = False
            txtCliente.Text = frm.descripcion
            'txtCliente.ReadOnly = True
            'txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        MostrarReporte()
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Clear()
        IdCliente = 0
    End Sub
End Class