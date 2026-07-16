Imports System.ServiceModel
Public Class frmRepKardex
    Private oLocacionMercaderia As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private ObjMaestro As New MaestroService.MaestroClient

    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtDatosN As DataTable
    Private dtMonedas As New DataTable

    Dim IdCliente As Integer
    Dim IdClase As Integer

    Private Sub frmRepKardex_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oLocacionMercaderia.Close()
            oLocacionMercaderiaService.Close()
            ObjMaestro.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oLocacionMercaderia.Abort()
            oLocacionMercaderiaService.Abort()
            ObjMaestro.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oLocacionMercaderia.Abort()
            oLocacionMercaderiaService.Abort()
            ObjMaestro.Abort()
        End Try
    End Sub

    Private Sub frmRepKardex_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub txtClase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClase.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarClase.Enabled = True Then
                btnBuscarClase_Click(sender, e)
            End If

        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub frmRepKardex_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtCliente.KeyPress _
            , cbFecFinal.KeyPress _
            , cbFecInicio.KeyPress _
            , cmbIdLocacion.KeyPress _
            , cmbOficinas.KeyPress _
            , txtCodMer.KeyPress _
            , txtClase.KeyPress _
            , cmbMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub frmRepKardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 65)
        '/*************************************************************************************/

        Dim Mes, Anio As Integer
        Dim Fecha As Date

        Fecha = Today
        Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha) - 1)
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = DateSerial(Year(Fecha), (Month(Fecha) - 1) + 1, 0)
        IdCliente = 0
        IdClase = 0
        llenarCombos()
        cbFecInicio.Focus()
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
            dtOficinas = oMaestroService.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

            '========================================= MONEDAS ==================================================
            dtMonedas = ObjMaestro.MostrarMonedas.Tables(0)
            'dtMonedas.Rows.InsertAt(getRowTodos(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepKardex
            dtReporte = oLocacionMercaderia.ReporteKardex(cmbIdLocacion.Value, txtCodMer.Text, cbFecInicio.Text, cbFecFinal.Text, IdCliente, IdClase).Tables(0)
            DataGridView1.DataSource = dtReporte

            'CreacionDataTable()

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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

                reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
                reporte.SetParameterValue("Moneda", cmbMoneda.Value)
                forma.Text = "Reporte de Kardex"
                ' dtReporte.WriteXmlSchema("D:\SIGECOM\SIGECOM\Interfaces\Costos\Reportes\OrigenDatos\RepKardex.xml")
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub


    Private Sub CreacionDataTable()


        Try

            Dim row As DataRow

            Dim dtCopia As New DataTable("tabla")

            dtCopia.Columns.Add(New DataColumn("DesEmp", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("RucEmp", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodOfi", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesOfi", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodAlm", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesAlm", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesMer1", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("ModMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DeaMer", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("UbiMer", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodMar", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesMar", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodRub", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("DesRub", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("IdClase", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("NomClas", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("FecDoc", Type.GetType("System.String")))       'datetime
            dtCopia.Columns.Add(New DataColumn("Documento", Type.GetType("System.String")))        'datetime
            dtCopia.Columns.Add(New DataColumn("Referencia", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Ingreso", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Salida", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Stock", Type.GetType("System.Int32")))
            dtCopia.Columns.Add(New DataColumn("Pedido", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("NumJob", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("PreMer", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("CosDol", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("CosSol", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("CosProD", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("CosProS", Type.GetType("System.Double")))
            dtCopia.Columns.Add(New DataColumn("Cliente", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("CodMon", Type.GetType("System.String")))
            dtCopia.Columns.Add(New DataColumn("Precio", Type.GetType("System.Double")))

            dtCopia.Rows.Add(New Object() {"1", "1", "1", "1", "1", "1", "1", "1", "1", "0.00", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "0.00", "0.00", "0.00", "0.00", "0.00", "1", "1", "1", "0.00"})

            dtDatosN = dtCopia.Copy
            dtDatosN.Clear()

            Dim Saldo As Double = 0

            For i As Integer = 0 To DataGridView1.Rows.Count - 2

                If DataGridView1.Item(18, i).Value <> "***INICIO***" Then

                    row = dtDatosN.NewRow

                    row(0) = DataGridView1.Item(0, i).Value
                    row(1) = DataGridView1.Item(1, i).Value
                    row(2) = DataGridView1.Item(2, i).Value
                    row(3) = DataGridView1.Item(3, i).Value
                    row(4) = DataGridView1.Item(4, i).Value
                    row(5) = DataGridView1.Item(5, i).Value
                    row(6) = DataGridView1.Item(6, i).Value
                    row(7) = DataGridView1.Item(7, i).Value
                    row(8) = DataGridView1.Item(8, i).Value
                    row(9) = CDbl(DataGridView1.Item(9, i).Value)
                    row(10) = DataGridView1.Item(10, i).Value
                    row(11) = DataGridView1.Item(11, i).Value
                    row(12) = DataGridView1.Item(12, i).Value
                    row(13) = DataGridView1.Item(13, i).Value
                    row(14) = DataGridView1.Item(14, i).Value
                    row(15) = DataGridView1.Item(15, i).Value
                    row(16) = DataGridView1.Item(16, i).Value
                    row(17) = DataGridView1.Item(17, i).Value
                    row(18) = DataGridView1.Item(18, i).Value
                    row(19) = DataGridView1.Item(19, i).Value
                    If IsDBNull(DataGridView1.Item(20, i).Value) Then
                        row(20) = 0
                    Else
                        row(20) = CInt(DataGridView1.Item(20, i).Value)
                    End If
                    If IsDBNull(DataGridView1.Item(21, i).Value) Then
                        row(21) = 0
                    Else
                        row(21) = CInt(DataGridView1.Item(21, i).Value)
                    End If
                    If IsDBNull(DataGridView1.Item(22, i).Value) Then
                        row(22) = 0
                    Else
                        row(22) = CInt(DataGridView1.Item(22, i).Value)
                    End If
                    ' row(20) = IIf(IsDBNull(DataGridView1.Item(20, i).Value), "0", CInt(DataGridView1.Item(20, i).Value))
                    'row(20) = IIf(DataGridView1.Item(20, i).Value = "", 0, CInt(DataGridView1.Item(20, i).Value))
                    'row(21) = IIf(IsDBNull(DataGridView1.Item(21, i).Value) = True, 0, CInt(DataGridView1.Item(21, i).Value))
                    'row(22) = IIf(IsDBNull(DataGridView1.Item(22, i).Value) = True, 0, CInt(DataGridView1.Item(22, i).Value))
                    'row(21) = CInt(DataGridView1.Item(21, i).Value)
                    'row(22) = CInt(DataGridView1.Item(22, i).Value)
                    row(23) = DataGridView1.Item(23, i).Value
                    row(24) = DataGridView1.Item(24, i).Value
                    row(25) = CDbl(DataGridView1.Item(25, i).Value)
                    row(26) = CDbl(DataGridView1.Item(26, i).Value)
                    row(27) = CDbl(DataGridView1.Item(27, i).Value)
                    row(28) = CDbl(DataGridView1.Item(28, i).Value)
                    row(29) = CDbl(DataGridView1.Item(29, i).Value)
                    row(30) = DataGridView1.Item(30, i).Value
                    row(31) = DataGridView1.Item(31, i).Value
                    row(32) = DataGridView1.Item(32, i).Value
                    row(33) = CDbl(DataGridView1.Item(33, i).Value)

                    dtDatosN.Rows.Add(row)

                End If
            Next


        Catch ex As Exception
            MsgBox("Error al Crear el Datatable Nuevo : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    'Private Sub MostrarReporte()
    '    Try
    '        Dim forma As New frmReportes
    '        Dim dtReporte As New DataTable
    '        Dim reporte As New rpRepKardex
    '        dtReporte = oLocacionMercaderia.ReporteKardex(cmbIdLocacion.Value, txtCodMer.Text, cbFecInicio.Text, cbFecFinal.Text, IdCliente, IdClase).Tables(0)
    '        If dtReporte.Rows.Count = 0 Then
    '            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
    '        Else
    '            reporte.SetDataSource(dtReporte)
    '            forma.crvReportes.ReportSource = reporte
    '            forma.crvReportes.DisplayGroupTree = False
    '            reporte.SetParameterValue("cbFecFinal", cbFecFinal.Text)
    '            forma.Text = "Reporte de Kardex"
    '            ' dtReporte.WriteXmlSchema("D:\SIGECOM\SIGECOM\Interfaces\Costos\Reportes\OrigenDatos\RepKardex.xml")
    '            forma.ShowDialog()
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
    '    End Try
    'End Sub

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

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbBuscarCliente.Checked = False
            txtCliente.Text = frm.descripcion
            'txtCliente.ReadOnly = True
            'txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
        txtCliente.Focus()
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        txtCliente.Clear()
        IdCliente = 0
    End Sub

    Private Sub btnBuscarClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarClase.Click
        Dim frm As New frmBuscarClase
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbBuscarClase.Checked = False
            txtClase.Text = frm.descripcion
            txtClase.BackColor = System.Drawing.SystemColors.Control
            IdClase = frm.codigo
            txtCodMer.Clear()
            txtCodMer.BackColor = System.Drawing.SystemColors.Control
        End If
        txtClase.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(65, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub rbBuscarClase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarClase.CheckedChanged
        txtClase.Clear()
        IdClase = 0
    End Sub

    Private Sub txtCodMer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMer.TextChanged
        If txtCodMer.Text <> "" Then
            txtClase.Clear()
            btnBuscarClase.Enabled = False
            rbBuscarClase.Checked = True
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
        Else
            txtClase.Clear()
            btnBuscarClase.Enabled = True
        End If
    End Sub

    Private Sub txtCodMer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMer.Validating
        Try
            If Len(Trim(txtCodMer.Text)) > 0 Then
                If oLocacionMercaderiaService.Buscar(cmbIdLocacion.Value, txtCodMer.Text) Then
                    btnAceptar.Focus()
                Else
                    MsgBox("No Existe esta Mercaderia")
                    txtCodMer.Clear()
                    txtCodMer.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscarMercaderia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarMercaderia.Click
        Dim frm As New frmBuscarMercaderia
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCodMer.Text = frm.codigo
            txtCodMer.BackColor = System.Drawing.SystemColors.Window
            txtCodMer.Select()
        End If

    End Sub
End Class