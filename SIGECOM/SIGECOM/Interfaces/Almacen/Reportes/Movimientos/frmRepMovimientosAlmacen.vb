Imports System.ServiceModel

Public Class frmRepMovimientosAlmacen

    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMercaderia As New MercaderiaService.MercaderiaServiceClient
    Private dtoficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtMovimientos As DataTable
    Private dtTipoMovimientos As DataTable
    Private dtRubros As DataTable
    Dim codMar As String

    Private dtDatosN As DataTable
    Private dtDatosN2 As DataTable

    Private Sub frmRepMovimientosAlmacen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLocacionMercaderiaService.Close()
            oMaestro.Close()
            oSeguridadService.Close()
            oMercaderia.Close()
        Catch ex As TimeoutException
            oLocacionMercaderiaService.Abort()
            oMaestro.Close()
            oSeguridadService.Abort()
            oMercaderia.Abort()
        Catch ex As CommunicationException
            oLocacionMercaderiaService.Abort()
            oMaestro.Abort()
            oSeguridadService.Abort()
            oMercaderia.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmRepMovimientosAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepMovimientosAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 14)
        '/*************************************************************************************/

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date

        Fecha = Today
        meses = Month(Today)
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        cmbCodMov.Value = "(Todos)"
        llenarCombos()

    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
            dtoficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtoficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtoficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtoficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtoficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtoficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtoficinas = Nothing

            '======================================= MOVIMIENTOS ===============================================
            dtMovimientos = oMaestro.MostrarMovimiento.Tables(0)
            dtMovimientos.Rows.InsertAt(getRowTodos(dtMovimientos), 0)
            cmbCodMov.DataSource = dtMovimientos
            cmbCodMov.DropDownList.DataMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.DropDownList.DisplayMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.DropDownList.ValueMember = dtMovimientos.Columns("CodMov").ToString
            cmbCodMov.DropDownList.Columns(0).DataMember = dtMovimientos.Columns("CodMov").ToString
            cmbCodMov.DropDownList.Columns(1).DataMember = dtMovimientos.Columns("DesMov").ToString
            dtMovimientos = Nothing

            '======================================= TIPO MOVIMIENTOS ===============================================
            dtTipoMovimientos = New DataTable
            dtTipoMovimientos.Columns.Add(New DataColumn("Tipo", Type.GetType("System.String")))
            dtTipoMovimientos.Columns.Add(New DataColumn("Nombre", Type.GetType("System.String")))
            dtTipoMovimientos.Rows.Add(New Object() {"H", "INGRESOS"})
            dtTipoMovimientos.Rows.Add(New Object() {"D", "SALIDAS"})
            dtTipoMovimientos.Rows.Add(New Object() {"C", "COSTOS"})
            cmbTipoMovimiento.DataSource = dtTipoMovimientos
            cmbTipoMovimiento.DisplayMember = "Nombre"
            cmbTipoMovimiento.ValueMember = "Tipo"
            cmbTipoMovimiento.DropDownList.Columns(0).DataMember = "Tipo"
            cmbTipoMovimiento.DropDownList.Columns(1).DataMember = "Nombre"
            cmbTipoMovimiento.SelectedIndex = 0
            dtTipoMovimientos = Nothing

            '======================================= RUBROS ================================================
            dtRubros = oMercaderia.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbCodRub.DataSource = dtRubros
            cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.SelectedIndex = 0
            dtRubros = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function

    Private Sub MostrarReporte()

        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepMovimientosAlmacen
            Dim reporte2 As New rpRepMovimientosAlmacen2   'Cambio hecho el 28/02/2013 por solicitud de usuario N° 2916
            Dim dtReporte As New DataView

            dtReporte = dtDatosN.Copy.DefaultView

            'dtReporte = oLocacionMercaderiaService.ReporteMovimientos(cbFecInicio.Value, cbFecFinal.Value, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), cmbTipoMovimiento.Value, txtUbiMer.Text, cmbCodRub.Value, IIf(cbUbicacion.Checked = True, 2, 1)).Tables(0).DefaultView
            'dtReporte = oLocacionMercaderiaService.ReporteMovimientos(Today, Today, "1", "", "", "D", "").Tables(0)

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                If cbBajoMaximo.Checked Then
                    dtReporte.RowFilter = "Stock < MaxMer"
                End If

                If rbFormato1.Checked Then

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Movimientos de Almacen"
                    Dim TipMov As String
                    TipMov = cmbTipoMovimiento.Value
                    Select Case TipMov
                        Case "H"
                            reporte.SetParameterValue("TipMov", "Ingresos")
                        Case "D"
                            reporte.SetParameterValue("TipMov", "Salidas")
                        Case "C"
                            reporte.SetParameterValue("TipMov", "Costos")
                    End Select

                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Marca", txtMarca.Text)
                    'reporte.SetParameterValue("Rubro", cmbCodRub.Text)
                    Dim cadenax As String = ""
                    For x = 0 To DataGridView3.Rows.Count - 2
                        If cadenax = "" Then
                            cadenax = DataGridView3.Item("DesRub", x).Value
                        Else
                            cadenax = cadenax + ", " + DataGridView3.Item("DesRub", x).Value
                        End If
                    Next

                    reporte.SetParameterValue("Rubro", cadenax)
                    reporte.SetParameterValue("Movimiento", cmbCodMov.Text)
                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepMovimientosAlmacen.xml")

                    forma.ShowDialog()

                Else

                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Movimientos de Almacen"
                    Dim TipMov As String
                    TipMov = cmbTipoMovimiento.Value
                    Select Case TipMov
                        Case "H"
                            reporte2.SetParameterValue("TipMov", "Ingresos")
                        Case "D"
                            reporte2.SetParameterValue("TipMov", "Salidas")
                        Case "C"
                            reporte2.SetParameterValue("TipMov", "Costos")
                    End Select

                    reporte2.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte2.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte2.SetParameterValue("Marca", txtMarca.Text)
                    'reporte2.SetParameterValue("Rubro", cmbCodRub.Text)
                    Dim cadenax As String = ""
                    For x = 0 To DataGridView3.Rows.Count - 2
                        If cadenax = "" Then
                            cadenax = DataGridView3.Item("DesRub", x).Value
                        Else
                            cadenax = cadenax + ", " + DataGridView3.Item("DesRub", x).Value
                        End If
                    Next

                    reporte2.SetParameterValue("Rubro", cadenax)
                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepMovimientosAlmacen.xml")

                    forma.ShowDialog()

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                   cmbIdLocacion.ValueChanged

    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
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

    Private Sub btnBuscaMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaMarca.Click
        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbMarca.Checked = False
            txtMarca.Text = frm.descripcion
            txtMarca.BackColor = System.Drawing.SystemColors.Control
            codMar = frm.codigo
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        oSeguridadService.RegistrarVisitaOpciones(14, "SYSTECK", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If Year(cbFecInicio.Value) <> Year(cbFecFinal.Value) Then
            MsgBox("Las fechas deben pertenecer al mismo año")
        Else
            ChequearMarcados()
            If rbResumen.Checked Then
                If DataGridView3.Rows.Count > 1 And cbRubro.Checked Then
                    MostrarReporte1()
                Else
                    MostrarReporteAntiguo()
                End If

            End If

            'MostrarReporte()
        End If

    End Sub

    Private Sub MostrarReporteDetallado()

        Dim dtReporte As New DataView
        'dtReporte = oLocacionMercaderiaService.ReporteMovimientosDetallado(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IIf(rbMarca.Checked, "", codMar), cmbCodMov.Value, txtUbiMer.Text, cmbCodRub.Value, IIf(cbUbicacion.Checked = True, 2, 1)).Tables(0).DefaultView

        dtReporte = oLocacionMercaderiaService.ReporteMovimientosDetallado(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IIf(rbMarca.Checked, "", codMar), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), txtUbiMer.Text, cmbCodRub.Value, IIf(cbUbicacion.Checked = True, 2, 1)).Tables(0).DefaultView

        If cbBajoMaximo.Checked Then
            dtReporte.RowFilter = "Stock < MaxMer"
        End If


        DataGridView4.DataSource = dtReporte
        Dim Export As Boolean = ExportarExcel(DataGridView4)
        If Export Then
            MsgBox("Se realizó la exportación correctamente")
        End If

    End Sub
    Private Sub MostrarReporteAntiguo()

        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepMovimientosAlmacen
            Dim reporte2 As New rpRepMovimientosAlmacen2   'Cambio hecho el 28/02/2013 por solicitud de usuario N° 2916
            Dim dtReporte As New DataView

            dtReporte = oLocacionMercaderiaService.ReporteMovimientos(cbFecInicio.Value, cbFecFinal.Value, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), cmbTipoMovimiento.Value, txtUbiMer.Text, cmbCodRub.Value, IIf(cbUbicacion.Checked = True, 2, 1)).Tables(0).DefaultView
            'dtReporte = oLocacionMercaderiaService.ReporteMovimientos(Today, Today, "1", "", "", "D", "").Tables(0)

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                If cbBajoMaximo.Checked Then
                    dtReporte.RowFilter = "Stock < MaxMer"
                End If

                If rbFormato1.Checked Then

                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Movimientos de Almacen"
                    Dim TipMov As String
                    TipMov = cmbTipoMovimiento.Value
                    Select Case TipMov
                        Case "H"
                            reporte.SetParameterValue("TipMov", "Ingresos")
                        Case "D"
                            reporte.SetParameterValue("TipMov", "Salidas")
                        Case "C"
                            reporte.SetParameterValue("TipMov", "Costos")
                    End Select

                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte.SetParameterValue("Marca", txtMarca.Text)
                    reporte.SetParameterValue("Rubro", cmbCodRub.Text)
                    reporte.SetParameterValue("Movimiento", cmbCodMov.Text)
                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepMovimientosAlmacen.xml")

                    forma.ShowDialog()

                Else

                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Movimientos de Almacen"
                    Dim TipMov As String
                    TipMov = cmbTipoMovimiento.Value
                    Select Case TipMov
                        Case "H"
                            reporte2.SetParameterValue("TipMov", "Ingresos")
                        Case "D"
                            reporte2.SetParameterValue("TipMov", "Salidas")
                        Case "C"
                            reporte2.SetParameterValue("TipMov", "Costos")
                    End Select

                    reporte2.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte2.SetParameterValue("FecFinal", cbFecFinal.Value)
                    reporte2.SetParameterValue("Marca", txtMarca.Text)
                    reporte2.SetParameterValue("Rubro", cmbCodRub.Text)
                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepMovimientosAlmacen.xml")

                    forma.ShowDialog()

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub ChequearMarcados()

        Dim dtSeleccionados As New DataTable("tabla")
        dtSeleccionados.Columns.Add(New DataColumn("CodRub", Type.GetType("System.String")))
        dtSeleccionados.Columns.Add(New DataColumn("DesRub", Type.GetType("System.String")))

        dtSeleccionados.Rows.Add(New Object() {"1", "1"})
        dtDatosN2 = dtSeleccionados.Copy
        dtDatosN2.Clear()

        Dim row As DataRow

        Dim rows() As Janus.Windows.GridEX.GridEXRow
        Dim Cadena As String = ""
        rows = dgvRubro.GetCheckedRows()
        Dim row2 As Janus.Windows.GridEX.GridEXRow
        If rows.Count <> 0 Then
            For Each row2 In rows
                row = dtDatosN2.NewRow
                row(0) = row2.Cells("CodRub").Text
                row(1) = row2.Cells("DesRub").Text
                dtDatosN2.Rows.Add(row)
            Next
        End If

        DataGridView3.DataSource = dtDatosN2

    End Sub

    Private Sub MostrarReporte1()


        Dim rowP As DataRow

        Dim dtCopia As New DataTable("tabla")
        'dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.Int32")))
        'dtCopia.Columns.Add(New DataColumn("IdLista", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("CodEmp", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesEmp", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("RucEmp", Type.GetType("System.String")))       'datetime
        dtCopia.Columns.Add(New DataColumn("DesUnidad", Type.GetType("System.String")))        'datetime
        dtCopia.Columns.Add(New DataColumn("CodOfi", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesOfi", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodAlm", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesAlm", Type.GetType("System.String")))        'string
        dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodRub", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesMer1", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodMov", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesMov", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("UbiMer", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CanMer", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("Stock", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("MinMer", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("MaxMer", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("Pedido", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("CanSep", Type.GetType("System.Int32")))


        dtCopia.Rows.Add(New Object() {"1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1"})

        dtDatosN = dtCopia.Copy
        dtDatosN.Clear()

        Dim forma As New frmReportes
        Dim reporte As New rpRepInventario
        Dim dtReporte As New DataTable

        ' dtReporte = oLocacionMercaderiaService.ReporteInventario(Today, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), cmbCiclos.Value, cmbCodMov.Value, txtUbiMer.Text).Tables(0).DefaultView

        dtReporte = oLocacionMercaderiaService.ReporteMovimientos(cbFecInicio.Value, cbFecFinal.Value, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), cmbTipoMovimiento.Value, txtUbiMer.Text, cmbCodRub.Value, IIf(cbUbicacion.Checked = True, 2, 1)).Tables(0)
        DataGridView2.DataSource = dtReporte

        For i As Integer = 0 To DataGridView2.Rows.Count - 2

            For j As Integer = 0 To DataGridView3.Rows.Count - 2

                If DataGridView3.Item("CodRub", j).Value = DataGridView2.Item("CodRub", i).Value Then

                    rowP = dtDatosN.NewRow

                    rowP(0) = DataGridView2.Item(0, i).Value
                    rowP(1) = DataGridView2.Item(1, i).Value
                    rowP(2) = DataGridView2.Item(2, i).Value
                    rowP(3) = DataGridView2.Item(3, i).Value
                    rowP(4) = DataGridView2.Item(4, i).Value      'codofi
                    rowP(5) = DataGridView2.Item(5, i).Value            'desofi
                    rowP(6) = DataGridView2.Item(6, i).Value
                    rowP(7) = DataGridView2.Item(7, i).Value
                    rowP(8) = DataGridView2.Item(8, i).Value            'CodMer
                    rowP(9) = DataGridView2.Item(9, i).Value            'CodRub
                    rowP(10) = DataGridView2.Item(10, i).Value          'DesMer1
                    rowP(11) = DataGridView2.Item(11, i).Value          'CodMov
                    rowP(12) = DataGridView2.Item(12, i).Value          'DesMov
                    rowP(13) = DataGridView2.Item(13, i).Value          'UbiMer
                    rowP(14) = CInt(DataGridView2.Item(14, i).Value)
                    rowP(15) = CInt(DataGridView2.Item(15, i).Value)
                    rowP(16) = CInt(DataGridView2.Item(16, i).Value)
                    rowP(17) = CInt(DataGridView2.Item(17, i).Value)    'codapl
                    rowP(18) = CInt(DataGridView2.Item(18, i).Value)
                    rowP(19) = CInt(DataGridView2.Item(19, i).Value)

                    dtDatosN.Rows.Add(rowP)

                End If
            Next
        Next

        MostrarReporte()

    End Sub

    Private Sub rbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMarca.CheckedChanged
        txtMarca.Text = ""
    End Sub

    Private Sub cbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles cbRubro.CheckedChanged
        If cmbCodRub.Value = "" Then
            If cbRubro.Checked Then
                gbRubro.Visible = True
                llenarGrillaRubro()
            Else
                gbRubro.Visible = False
            End If
        End If
    End Sub

    Private Sub llenarGrillaRubro()

        '======================================= RUBROS ================================================
        dtRubros = oMercaderia.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
        dgvRubro.DataSource = dtRubros
        dtRubros = Nothing

    End Sub

    Private Sub cmbCodRub_ValueChanged(sender As Object, e As EventArgs) Handles cmbCodRub.ValueChanged
        If cmbCodRub.Value = "" Then
            cbRubro.Visible = True
            'gbRubro.Visible = True
        Else
            cbRubro.Visible = False
            cbRubro.Checked = False
            gbRubro.Visible = False
        End If
    End Sub

    Private Sub rbDetallado_CheckedChanged(sender As Object, e As EventArgs) Handles rbDetallado.CheckedChanged
        cmbIdLocacion.Enabled = False
        cmbOficinas.Enabled = False
        cmbTipoMovimiento.Enabled = False
        gbMercaderia.Enabled = False
        cbRubro.Enabled = False
    End Sub

    Private Sub rbResumen_CheckedChanged(sender As Object, e As EventArgs) Handles rbResumen.CheckedChanged
        cmbIdLocacion.Enabled = True
        cmbOficinas.Enabled = True
        cmbTipoMovimiento.Enabled = True
        gbMercaderia.Enabled = True
        cbRubro.Enabled = True

        If rbResumen.Checked = True Then

            btnAceptar.Visible = True
            btnAceptarD.Visible = False
        ElseIf rbDetallado.Checked = True Then

            btnAceptar.Visible = False
            btnAceptarD.Visible = True
        End If





    End Sub

    Private Sub btnAceptarD_Click(sender As Object, e As EventArgs) Handles btnAceptarD.Click
        oSeguridadService.RegistrarVisitaOpciones(14, "SYSTECK", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        If Year(cbFecInicio.Value) <> Year(cbFecFinal.Value) Then
            MsgBox("Las fechas deben pertenecer al mismo año")
        Else

            MostrarReporteDetallado()

        End If

    End Sub
End Class