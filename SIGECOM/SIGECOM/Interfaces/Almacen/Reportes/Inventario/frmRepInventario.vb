Imports System.ServiceModel
Public Class frmRepInventario
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Private oTipoMotorService As New TipoMotorProductoService.TipoMotorProductoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtAlmacenes As DataTable
    Private dtOficinas As DataTable
    Private dtCiclos As DataTable
    Private dtMovimientos As DataTable
    Private dtTiposMotores As DataTable
    Private dtClases As DataTable
    Private dtRubros As DataTable
    Private dtUnidades As DataTable
    Private codMar As String
    Private codApl As String
    Dim IdProveedor As Integer = 0

    Private dtDatosN As DataTable
    Private dtDatosN2 As DataTable
    Private codRubs As String
    Private Sub frmRepInventario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 12)
        '/*************************************************************************************/

        llenarCombos()
        llenarGrillaRubro()

        gbRubro.Visible = False
        cbRubro.Visible = True
        cbRubro.Checked = False

        txtFecha.ReadOnly = False
        txtFecha.BackColor = System.Drawing.SystemColors.Window
        cmbCiclos.Value = "(Todos)"
        cmbCodMov.Value = "(Todos)"

    End Sub

    Private Sub frmRepInventario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oLocacionMercaderiaService.Close()
            oTipoMotorService.Close()
            oSeguridadService.Close()
            oMercaderiaService.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oLocacionMercaderiaService.Abort()
            oTipoMotorService.Abort()
            oSeguridadService.Abort()
            oMercaderiaService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oLocacionMercaderiaService.Abort()
            oTipoMotorService.Abort()
            oSeguridadService.Abort()
            oMercaderiaService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
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

    Private Function getRowAlmacen(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow()
        Try

            fila(0) = 0

        Catch ex As Exception

        End Try
        Try

            fila(2) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Function getRowMotores(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Return fila
    End Function

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
        dtCopia.Columns.Add(New DataColumn("DesAlm", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodRub", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("Rubro", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodMer2", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesMer1", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DeaMer", Type.GetType("System.Double")))
        dtCopia.Columns.Add(New DataColumn("MinMer", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("MaxMer", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodMov", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("DesMov", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("CodApl", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("NomClas", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("UbiMer", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("TipMot", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("Idproveedor", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("DesProv", Type.GetType("System.String")))
        dtCopia.Columns.Add(New DataColumn("Stock", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("Pedido", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("Salida0", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("Salida1", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("Salida2", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("Salida3", Type.GetType("System.Int32")))
        dtCopia.Columns.Add(New DataColumn("CosDol", Type.GetType("System.Double")))
        dtCopia.Columns.Add(New DataColumn("CosSol", Type.GetType("System.Double")))
        dtCopia.Columns.Add(New DataColumn("CanSep", Type.GetType("System.Int32")))


        dtCopia.Rows.Add(New Object() {"1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "0.00", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "0.00", "0.00", "1"})

        dtDatosN = dtCopia.Copy
        dtDatosN.Clear()

        Dim forma As New frmReportes
        Dim reporte As New rpRepInventario
        Dim dtReporte As New DataTable

        ' dtReporte = oLocacionMercaderiaService.ReporteInventario(Today, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), cmbCiclos.Value, cmbCodMov.Value, txtUbiMer.Text).Tables(0).DefaultView
        oLocacionMercaderiaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)
        'dtReporte = oLocacionMercaderiaService.ReporteInventario(txtFecha.Text, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), IIf(cmbCiclos.Value = "(Todos)", "", cmbCiclos.Value), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), IIf(txtUbiMer.Text = "", "", txtUbiMer.Text), IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Value), cmbCodRub.Value, cmbIdClase.Value, IdProveedor).Tables(0)
        dtReporte = oLocacionMercaderiaService.ReporteInventarioPorUnidad(Session.sCodEmp, cmbUnidad.Value, IIf(cmbOficinas.Value = "(Todos)", "", cmbOficinas.Value), IIf(cmbIdLocacion.Text = "(Todos)", 0, cmbIdLocacion.Value), txtFecha.Text, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), IIf(cmbCiclos.Value = "(Todos)", "", cmbCiclos.Value), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), IIf(txtUbiMer.Text = "", "", txtUbiMer.Text), IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Value), cmbCodRub.Value, cmbIdClase.Value, IdProveedor).Tables(0)

        DataGridView2.DataSource = dtReporte

        For i As Integer = 0 To DataGridView2.Rows.Count - 2

            For j As Integer = 0 To DataGridView3.Rows.Count - 2

                If DataGridView3.Item("CodRub", j).Value = DataGridView2.Item("CodRub", i).Value Then

                        rowP = dtDatosN.NewRow
                        rowP(0) = DataGridView2.Item("CodEmp", i).Value
                        rowP(1) = DataGridView2.Item("DesEmp", i).Value
                        rowP(2) = DataGridView2.Item("RucEmp", i).Value
                        rowP(3) = DataGridView2.Item("DesUnidad", i).Value
                        rowP(4) = DataGridView2.Item("CodOfi", i).Value      'codofi
                        rowP(5) = DataGridView2.Item("DesOfi", i).Value      'desofi
                        rowP(6) = DataGridView2.Item("CodAlm", i).Value
                        rowP(7) = DataGridView2.Item("DesAlm", i).Value
                        rowP(8) = DataGridView2.Item("CodRub", i).Value            'CodRub
                        rowP(9) = DataGridView2.Item("Rubro", i).Value            'Rubro
                        rowP(10) = DataGridView2.Item("CodMer", i).Value
                        rowP(11) = DataGridView2.Item("CodMer2", i).Value
                        rowP(12) = DataGridView2.Item("DesMer1", i).Value
                        rowP(13) = DataGridView2.Item("DeaMer", i).Value          'deamer
                        rowP(14) = DataGridView2.Item("MinMer", i).Value
                        rowP(15) = DataGridView2.Item("MaxMer", i).Value
                        rowP(16) = DataGridView2.Item("CodMov", i).Value
                        rowP(17) = DataGridView2.Item("DesMov", i).Value
                        rowP(18) = DataGridView2.Item("CodApl", i).Value    'codapl
                        rowP(19) = DataGridView2.Item("NomClas", i).Value
                        rowP(20) = DataGridView2.Item("UbiMer", i).Value
                    rowP(21) = DataGridView2.Item("TipMot", i).Value    'tipmot
                    rowP(22) = DataGridView2.Item("IdProveedor", i).Value    'idproveedor
                    rowP(23) = DataGridView2.Item("DesProv", i).Value    'proveedor
                    rowP(24) = CInt(DataGridView2.Item("Stock", i).Value)    'Stock
                        rowP(25) = CInt(DataGridView2.Item("Pedido", i).Value)
                        rowP(26) = CInt(DataGridView2.Item("Salida0", i).Value)
                        rowP(27) = CInt(DataGridView2.Item("Salida1", i).Value)
                        rowP(28) = CInt(DataGridView2.Item("Salida2", i).Value)
                        rowP(29) = CInt(DataGridView2.Item("Salida3", i).Value)
                        rowP(30) = CDbl(DataGridView2.Item("CosDol", i).Value)
                        rowP(31) = CDbl(DataGridView2.Item("CosSol", i).Value)
                        rowP(32) = CInt(DataGridView2.Item("CanSep", i).Value)

                        dtDatosN.Rows.Add(rowP)

                    End If

            Next
        Next

        MostrarReporte()

    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepInventario
            Dim reporteResumen As New rpRepInventarioGlobal
            Dim dtReporte As New DataView


            If rbExportExcel.Checked Then
                dtReporte = oLocacionMercaderiaService.ReporteInventarioExcel(Session.sCodEmp, txtFecha.Text, IIf(cmbIdLocacion.Text = "(Todos)", 0, cmbIdLocacion.Value), IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), IIf(cmbCiclos.Value = "(Todos)", "", cmbCiclos.Value), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), IIf(txtUbiMer.Text = "", "", txtUbiMer.Text), IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Value), codRubs, cmbIdClase.Value, IdProveedor).Tables(0).DefaultView
            Else
                dtReporte = dtDatosN.Copy.DefaultView
            End If

            ' dtReporte = oLocacionMercaderiaService.ReporteInventario(Today, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), cmbCiclos.Value, cmbCodMov.Value, txtUbiMer.Text).Tables(0).DefaultView

            'dtReporte = oLocacionMercaderiaService.ReporteInventario(txtFecha.Text, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), IIf(cmbCiclos.Value = "(Todos)", "", cmbCiclos.Value), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), IIf(txtUbiMer.Text = "", "", txtUbiMer.Text), IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Value), cmbCodRub.Value, cmbIdClase.Value, IdProveedor).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else

                '////////////////////////////////////// EXCEL //////////////////////////////////////
                If rbExportExcel.Checked Then
                    '-----------------------------------


                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) <> 0"
                        Else
                            dtReporte.RowFilter = "Stock <> 0"
                        End If
                    ElseIf rbceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) = 0"
                        Else
                            dtReporte.RowFilter = "Stock = 0"
                        End If
                    ElseIf rbpositivos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) > 0"
                        Else
                            dtReporte.RowFilter = "Stock > 0"
                        End If
                    ElseIf rbnegativos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) < 0"
                        Else
                            dtReporte.RowFilter = "Stock < 0"
                        End If
                    ElseIf rbbajominimo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) < MinMer"
                        Else
                            dtReporte.RowFilter = "Stock < MinMer"
                        End If
                    ElseIf rbbajomaximo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) < MaxMer"
                        Else
                            dtReporte.RowFilter = "Stock < MaxMer"
                        End If
                    End If

                    'dtReporte.Table.Columns.Remove("CodEmp")
                    'dtReporte.Table.Columns.Remove("DesEmp")
                    'dtReporte.Table.Columns.Remove("RucEmp")
                    'dtReporte.Table.Columns.Remove("CodOfi")
                    'dtReporte.Table.Columns.Remove("CodAlm")
                    'dtReporte.Table.Columns.Remove("CodMov")

                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If


                    '////////////////////////////////////// INVENTARIO GENERAL //////////////////////////////////////
                ElseIf rbInvGeneralExcel.Checked = True And rbDetallado.checked Then
                    dtReporte = oLocacionMercaderiaService.ReporteInventarioGlobal(Session.sCodEmp, txtFecha.Value, cmbCodRub.Value).Tables(0).DefaultView

                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) <> 0"
                        Else
                            dtReporte.RowFilter = "Stock <> 0"
                        End If
                    ElseIf rbceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) = 0"
                        Else
                            dtReporte.RowFilter = "Stock = 0"
                        End If
                    ElseIf rbpositivos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) > 0"
                        Else
                            dtReporte.RowFilter = "Stock > 0"
                        End If
                    ElseIf rbnegativos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < 0"
                        Else
                            dtReporte.RowFilter = "Stock < 0"
                        End If
                    ElseIf rbbajominimo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MinMer"
                        Else
                            dtReporte.RowFilter = "Stock < MinMer"
                        End If
                    ElseIf rbbajomaximo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MaxMer"
                        Else
                            dtReporte.RowFilter = "Stock < MaxMer"
                        End If
                    End If

                    DataGridView4.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView4)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If

                    '////////////////////////////////////// PANTALLA //////////////////////////////////////

                ElseIf rbInvGeneralExcel.Checked = True And rbTotalizado.Checked Then

                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) <> 0"
                        Else
                            dtReporte.RowFilter = "Stock <> 0"
                        End If
                    ElseIf rbceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) = 0"
                        Else
                            dtReporte.RowFilter = "Stock = 0"
                        End If
                    ElseIf rbpositivos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) > 0"
                        Else
                            dtReporte.RowFilter = "Stock > 0"
                        End If
                    ElseIf rbnegativos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < 0"
                        Else
                            dtReporte.RowFilter = "Stock < 0"
                        End If
                    ElseIf rbbajominimo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MinMer"
                        Else
                            dtReporte.RowFilter = "Stock < MinMer"
                        End If
                    ElseIf rbbajomaximo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MaxMer"
                        Else
                            dtReporte.RowFilter = "Stock < MaxMer"
                        End If
                    End If

                    dtReporte = oLocacionMercaderiaService.ReporteInventarioGlobal(Session.sCodEmp, txtFecha.Value, cmbCodRub.Value).Tables(0).DefaultView

                    DataGridView4.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView4)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If
                ElseIf rbPantalla.Checked = True And rbTotalizado.Checked Then

                    '*************************************************************************** RESUMEN PANTALLA ***************************************************************

                    dtReporte = oLocacionMercaderiaService.ReporteInventarioGlobal(Session.sCodEmp, txtFecha.Value, cmbCodRub.Value).Tables(0).DefaultView

                    reporteResumen.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteResumen

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Inventario de Almacen - Resumen"

                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepInventario.xml")
                    reporteResumen.SetParameterValue("Fecha", txtFecha.Text)
                    Dim fecha As Date
                    fecha = txtFecha.Text
                    reporteResumen.SetParameterValue("Año3", Format(fecha, "yyyy"))
                    reporteResumen.SetParameterValue("Año2", Format(fecha, "yyyy") - 1)
                    reporteResumen.SetParameterValue("Año1", Format(fecha, "yyyy") - 2)
                    reporteResumen.SetParameterValue("Año0", Format(fecha, "yyyy") - 3)
                    reporteResumen.SetParameterValue("Marca", txtMarca.Text)
                    reporteResumen.SetParameterValue("Aplicacion", txtAplicacion.Text)
                    reporteResumen.SetParameterValue("TipMot", IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Text))
                    reporteResumen.SetParameterValue("pDesProv", IIf(txtProveedor.Text = "(Todos)", "", txtProveedor.Text))

                    Dim cadenax As String = ""
                    If cbRubro.Checked Then
                        For x = 0 To DataGridView3.Rows.Count - 2
                            If cadenax = "" Then
                                cadenax = DataGridView3.Item("DesRub", x).Value
                            Else
                                cadenax = cadenax + ", " + DataGridView3.Item("DesRub", x).Value
                            End If
                        Next
                        reporteResumen.SetParameterValue("Rubro", cadenax)
                    Else
                        reporteResumen.SetParameterValue("Rubro", cmbCodRub.Text)
                    End If

                    'Dim cadenax As String = ""
                    'For x = 0 To DataGridView3.Rows.Count - 2
                    '    If cadenax = "" Then
                    '        cadenax = DataGridView3.Item("DesRub", x).Value
                    '    Else
                    '        cadenax = cadenax + ", " + DataGridView3.Item("DesRub", x).Value
                    '    End If
                    'Next

                    'reporteResumen.SetParameterValue("Rubro", cadenax)

                    reporteResumen.SetParameterValue("Clase", cmbIdClase.Text)

                    If rbFisico.Checked Then
                        reporteResumen.SetParameterValue("Stock", "f")
                    ElseIf rbDisponible.Checked Then
                        reporteResumen.SetParameterValue("Stock", "d")
                    End If

                    If rbtodos.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Todos")
                    ElseIf rbsinceros.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Sin Ceros")
                    ElseIf rbceros.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Con Ceros")
                    ElseIf rbpositivos.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Positivos")
                    ElseIf rbnegativos.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Negativos")
                    ElseIf rbbajominimo.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Bajo el Mínimo")
                    ElseIf rbbajomaximo.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Bajo el Máximo")
                    End If

                    forma.ShowDialog()

                    '*************************************************************************** RESUMEN PANTALLA ***************************************************************





                ElseIf rbPantalla.Checked Then
                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) <> 0"
                        Else
                            dtReporte.RowFilter = "Stock <> 0"
                        End If
                    ElseIf rbceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) = 0"
                        Else
                            dtReporte.RowFilter = "Stock = 0"
                        End If
                    ElseIf rbpositivos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) > 0"
                        Else
                            dtReporte.RowFilter = "Stock > 0"
                        End If
                    ElseIf rbnegativos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < 0"
                        Else
                            dtReporte.RowFilter = "Stock < 0"
                        End If
                    ElseIf rbbajominimo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MinMer"
                        Else
                            dtReporte.RowFilter = "Stock < MinMer"
                        End If
                    ElseIf rbbajomaximo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MaxMer"
                        Else
                            dtReporte.RowFilter = "Stock < MaxMer"
                        End If
                    End If


                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Inventario de Almacen"
                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepInventario.xml")
                    reporte.SetParameterValue("Fecha", txtFecha.Text)
                    Dim fecha As Date
                    fecha = txtFecha.Text
                    reporte.SetParameterValue("Año3", Format(fecha, "yyyy"))
                    reporte.SetParameterValue("Año2", Format(fecha, "yyyy") - 1)
                    reporte.SetParameterValue("Año1", Format(fecha, "yyyy") - 2)
                    reporte.SetParameterValue("Año0", Format(fecha, "yyyy") - 3)
                    reporte.SetParameterValue("Marca", txtMarca.Text)
                    reporte.SetParameterValue("Aplicacion", txtAplicacion.Text)
                    reporte.SetParameterValue("TipMot", IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Text))
                    reporte.SetParameterValue("pDesProv", IIf(txtProveedor.Text = "(Todos)", "", txtProveedor.Text))
                    Dim cadenax As String = ""
                    For x = 0 To DataGridView3.Rows.Count - 2
                        If cadenax = "" Then
                            cadenax = DataGridView3.Item("DesRub", x).Value
                        Else
                            cadenax = cadenax + ", " + DataGridView3.Item("DesRub", x).Value
                        End If
                    Next

                    reporte.SetParameterValue("Rubro", cadenax)

                    reporte.SetParameterValue("Clase", cmbIdClase.Text)

                    If rbFisico.Checked Then
                        reporte.SetParameterValue("Stock", "f")
                    ElseIf rbDisponible.Checked Then
                        reporte.SetParameterValue("Stock", "d")
                    End If

                    If rbtodos.Checked Then
                        reporte.SetParameterValue("TipoStock", "Todos")
                    ElseIf rbsinceros.Checked Then
                        reporte.SetParameterValue("TipoStock", "Sin Ceros")
                    ElseIf rbceros.Checked Then
                        reporte.SetParameterValue("TipoStock", "Con Ceros")
                    ElseIf rbpositivos.Checked Then
                        reporte.SetParameterValue("TipoStock", "Positivos")
                    ElseIf rbnegativos.Checked Then
                        reporte.SetParameterValue("TipoStock", "Negativos")
                    ElseIf rbbajominimo.Checked Then
                        reporte.SetParameterValue("TipoStock", "Bajo el Mínimo")
                    ElseIf rbbajomaximo.Checked Then
                        reporte.SetParameterValue("TipoStock", "Bajo el Máximo")
                    End If

                    forma.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub MostrarReporteAntiguo()
        Try
            Dim forma As New frmReportes
            'Dim reporte As New rpRepInventario
            Dim reporte As New rpRepInventarioPorUnidad
            Dim reporteResumen As New rpRepInventarioGlobal
            Dim reporteComprometidos As New rpRepInventarioComprometido
            Dim dtReporte As New DataView

            'dtReporte = oLocacionMercaderiaService.ReporteInventario(Today, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), cmbCiclos.Value, cmbCodMov.Value, txtUbiMer.Text).Tables(0).DefaultView

            oLocacionMercaderiaService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(20)

            If rbInvGeneralExcel.Checked = True Then
                'dtReporte = oLocacionMercaderiaService.ReporteInventarioGlobal(Session.sCodEmp, txtFecha.Value, cmbCodRub.Value).Tables(0).DefaultView
                dtReporte = oLocacionMercaderiaService.ReporteInventarioGlobalExcel(Session.sCodEmp, txtFecha.Value, cmbCodRub.Value).Tables(0).DefaultView
            ElseIf rbExportExcel.Checked And rbDetallado.Checked Then
                dtReporte = oLocacionMercaderiaService.ReporteInventarioExcel(Session.sCodEmp, txtFecha.Text, IIf(cmbIdLocacion.Text = "(Todos)", 0, cmbIdLocacion.Value), IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), IIf(cmbCiclos.Value = "(Todos)", "", cmbCiclos.Value), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), IIf(txtUbiMer.Text = "", "", txtUbiMer.Text), IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Value), cmbCodRub.Value, cmbIdClase.Value, IdProveedor).Tables(0).DefaultView
            ElseIf rbPantalla.Checked And rbTotalizado.Checked Then
                dtReporte = oLocacionMercaderiaService.ReporteInventarioGlobal(Session.sCodEmp, txtFecha.Value, cmbCodRub.Value).Tables(0).DefaultView
            ElseIf rbComprometidos.Checked Then
                dtReporte = oLocacionMercaderiaService.ReporteInventarioComprometido(Session.sCodEmp, cmbUnidad.Value, cmbOficinas.Value, cmbIdLocacion.Value).Tables(0).DefaultView
            Else
                'dtReporte = oLocacionMercaderiaService.ReporteInventario(txtFecha.Text, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), IIf(cmbCiclos.Value = "(Todos)", "", cmbCiclos.Value), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), IIf(txtUbiMer.Text = "", "", txtUbiMer.Text), IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Value), cmbCodRub.Value, cmbIdClase.Value, IdProveedor).Tables(0).DefaultView
                dtReporte = oLocacionMercaderiaService.ReporteInventarioPorUnidad(Session.sCodEmp, cmbUnidad.Value, IIf(cmbOficinas.Value = "(Todos)", "", cmbOficinas.Value), IIf(cmbIdLocacion.Text = "(Todos)", 0, cmbIdLocacion.Value), txtFecha.Text, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), IIf(cmbCiclos.Value = "(Todos)", "", cmbCiclos.Value), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), IIf(txtUbiMer.Text = "", "", txtUbiMer.Text), IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Value), cmbCodRub.Value, cmbIdClase.Value, IdProveedor).Tables(0).DefaultView
            End If


            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                '////////////////////////////////////// EXCEL //////////////////////////////////////
                If rbExportExcel.Checked And rbComprometidos.Checked Then

                    dtReporte.Table.Columns.Remove("DesEmp")
                    dtReporte.Table.Columns.Remove("RucEmp")
                    dtReporte.Table.Columns.Remove("CodMer")

                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If

                ElseIf rbExportExcel.Checked Then
                    '-----------------------------------
                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) <> 0" '"(Stock-CanSep) <> 0"
                        Else
                            dtReporte.RowFilter = "Stock <> 0"
                        End If
                    ElseIf rbceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) = 0"
                        Else
                            dtReporte.RowFilter = "Stock = 0"
                        End If
                    ElseIf rbpositivos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) > 0"
                        Else
                            dtReporte.RowFilter = "Stock > 0"
                        End If
                    ElseIf rbnegativos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) < 0"
                        Else
                            dtReporte.RowFilter = "Stock < 0"
                        End If
                    ElseIf rbbajominimo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) < MinMer"
                        Else
                            dtReporte.RowFilter = "Stock < MinMer"
                        End If
                    ElseIf rbbajomaximo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) < MaxMer"
                        Else
                            dtReporte.RowFilter = "Stock < MaxMer"
                        End If
                    End If

                    'dtReporte.Table.Columns.Remove("CodEmp")
                    'dtReporte.Table.Columns.Remove("DesEmp")
                    'dtReporte.Table.Columns.Remove("RucEmp")
                    'dtReporte.Table.Columns.Remove("CodOfi")
                    'dtReporte.Table.Columns.Remove("CodAlm")
                    'dtReporte.Table.Columns.Remove("CodMov")

                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If


                    '////////////////////////////////////// INVENTARIO GENERAL //////////////////////////////////////
                ElseIf rbInvGeneralExcel.Checked = True And rbDetallado.Checked Then

                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) <> 0"
                        Else
                            dtReporte.RowFilter = "Stock <> 0"
                        End If
                    ElseIf rbceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) = 0"
                        Else
                            dtReporte.RowFilter = "Stock = 0"
                        End If
                    ElseIf rbpositivos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) > 0"
                        Else
                            dtReporte.RowFilter = "Stock > 0"
                        End If
                    ElseIf rbnegativos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) < 0"
                        Else
                            dtReporte.RowFilter = "Stock < 0"
                        End If
                    ElseIf rbbajominimo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) < MinMer"
                        Else
                            dtReporte.RowFilter = "Stock < MinMer"
                        End If
                    ElseIf rbbajomaximo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-Comprometido) < MaxMer"
                        Else
                            dtReporte.RowFilter = "Stock < MaxMer"
                        End If
                    End If

                    DataGridView4.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView4)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If

                ElseIf rbInvGeneralExcel.Checked = True And rbTotalizado.Checked Then

                    '*************************************************************************** RESUMEN EXCEL ***************************************************************

                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) <> 0"
                        Else
                            dtReporte.RowFilter = "Stock <> 0"
                        End If
                    ElseIf rbceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) = 0"
                        Else
                            dtReporte.RowFilter = "Stock = 0"
                        End If
                    ElseIf rbpositivos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) > 0"
                        Else
                            dtReporte.RowFilter = "Stock > 0"
                        End If
                    ElseIf rbnegativos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < 0"
                        Else
                            dtReporte.RowFilter = "Stock < 0"
                        End If
                    ElseIf rbbajominimo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MinMer"
                        Else
                            dtReporte.RowFilter = "Stock < MinMer"
                        End If
                    ElseIf rbbajomaximo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MaxMer"
                        Else
                            dtReporte.RowFilter = "Stock < MaxMer"
                        End If
                    End If

                    DataGridView4.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView4)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If

                ElseIf rbPantalla.Checked = True And rbTotalizado.Checked Then

                    '*************************************************************************** RESUMEN PANTALLA ***************************************************************

                    '  dtReporte = oLocacionMercaderiaService.ReporteInventarioGlobal(Session.sCodEmp, txtFecha.Value, cmbCodRub.Value).Tables(0).DefaultView

                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) <> 0"
                        Else
                            dtReporte.RowFilter = "Stock <> 0"
                        End If
                    ElseIf rbceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) = 0"
                        Else
                            dtReporte.RowFilter = "Stock = 0"
                        End If
                    ElseIf rbpositivos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) > 0"
                        Else
                            dtReporte.RowFilter = "Stock > 0"
                        End If
                    ElseIf rbnegativos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < 0"
                        Else
                            dtReporte.RowFilter = "Stock < 0"
                        End If
                    ElseIf rbbajominimo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MinMer"
                        Else
                            dtReporte.RowFilter = "Stock < MinMer"
                        End If
                    ElseIf rbbajomaximo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MaxMer"
                        Else
                            dtReporte.RowFilter = "Stock < MaxMer"
                        End If
                    End If

                    reporteResumen.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteResumen

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Inventario de Almacen - Resumen"

                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepInventario.xml")
                    reporteResumen.SetParameterValue("Fecha", txtFecha.Text)
                    Dim fecha As Date
                    fecha = txtFecha.Text
                    reporteResumen.SetParameterValue("Año3", Format(fecha, "yyyy"))
                    reporteResumen.SetParameterValue("Año2", Format(fecha, "yyyy") - 1)
                    reporteResumen.SetParameterValue("Año1", Format(fecha, "yyyy") - 2)
                    reporteResumen.SetParameterValue("Año0", Format(fecha, "yyyy") - 3)
                    reporteResumen.SetParameterValue("Marca", txtMarca.Text)
                    reporteResumen.SetParameterValue("Aplicacion", txtAplicacion.Text)
                    reporteResumen.SetParameterValue("TipMot", IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Text))
                    reporteResumen.SetParameterValue("pDesProv", IIf(txtProveedor.Text = "(Todos)", "", txtProveedor.Text))

                    If cbRubro.Checked Then
                        Dim cadenax As String = ""
                        For x = 0 To DataGridView3.Rows.Count - 2
                            If cadenax = "" Then
                                cadenax = DataGridView3.Item("DesRub", x).Value
                            Else
                                cadenax = cadenax + ", " + DataGridView3.Item("DesRub", x).Value
                            End If
                        Next
                        reporteResumen.SetParameterValue("Rubro", cadenax)
                    Else
                        reporteResumen.SetParameterValue("Rubro", cmbCodRub.Text)
                    End If

                    reporteResumen.SetParameterValue("Clase", cmbIdClase.Text)

                    If rbFisico.Checked Then
                        reporteResumen.SetParameterValue("Stock", "f")
                    ElseIf rbDisponible.Checked Then
                        reporteResumen.SetParameterValue("Stock", "d")
                    End If

                    If rbtodos.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Todos")
                    ElseIf rbsinceros.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Sin Ceros")
                    ElseIf rbceros.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Con Ceros")
                    ElseIf rbpositivos.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Positivos")
                    ElseIf rbnegativos.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Negativos")
                    ElseIf rbbajominimo.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Bajo el Mínimo")
                    ElseIf rbbajomaximo.Checked Then
                        reporteResumen.SetParameterValue("TipoStock", "Bajo el Máximo")
                    End If

                    forma.ShowDialog()


                    '*************************************************************************** RESUMEN PANTALLA ***************************************************************

                    '//////////COMPROMETIDOS ////////////
                ElseIf rbComprometidos.Checked Then


                    reporteComprometidos.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteComprometidos

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Inventario de Almacen - Comprometidos"
                    reporteComprometidos.SetParameterValue("pUnidadNegocio", cmbUnidad.Text)
                    forma.ShowDialog()




                    '////////////////////////////////////// PANTALLA //////////////////////////////////////
                ElseIf rbPantalla.Checked Then
                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) <> 0"
                        Else
                            dtReporte.RowFilter = "Stock <> 0"
                        End If
                    ElseIf rbceros.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) = 0"
                        Else
                            dtReporte.RowFilter = "Stock = 0"
                        End If
                    ElseIf rbpositivos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) > 0"
                        Else
                            dtReporte.RowFilter = "Stock > 0"
                        End If
                    ElseIf rbnegativos.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < 0"
                        Else
                            dtReporte.RowFilter = "Stock < 0"
                        End If
                    ElseIf rbbajominimo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MinMer"
                        Else
                            dtReporte.RowFilter = "Stock < MinMer"
                        End If
                    ElseIf rbbajomaximo.Checked Then
                        If rbDisponible.Checked Then
                            dtReporte.RowFilter = "(Stock-CanSep) < MaxMer"
                        Else
                            dtReporte.RowFilter = "Stock < MaxMer"
                        End If
                    End If


                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Inventario de Almacen"

                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\RepInventario.xml")
                    reporte.SetParameterValue("Fecha", txtFecha.Text)
                    Dim fecha As Date
                    fecha = txtFecha.Text
                    reporte.SetParameterValue("Año3", Format(fecha, "yyyy"))
                    reporte.SetParameterValue("Año2", Format(fecha, "yyyy") - 1)
                    reporte.SetParameterValue("Año1", Format(fecha, "yyyy") - 2)
                    reporte.SetParameterValue("Año0", Format(fecha, "yyyy") - 3)
                    reporte.SetParameterValue("Marca", txtMarca.Text)
                    reporte.SetParameterValue("Aplicacion", txtAplicacion.Text)
                    reporte.SetParameterValue("TipMot", IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Text))
                    reporte.SetParameterValue("pDesProv", IIf(txtProveedor.Text = "(Todos)", "", txtProveedor.Text))
                    reporte.SetParameterValue("Rubro", cmbCodRub.Text)
                    reporte.SetParameterValue("Clase", cmbIdClase.Text)

                    If rbFisico.Checked Then
                        reporte.SetParameterValue("Stock", "f")
                    ElseIf rbDisponible.Checked Then
                        reporte.SetParameterValue("Stock", "d")
                    End If

                    If rbtodos.Checked Then
                        reporte.SetParameterValue("TipoStock", "Todos")
                    ElseIf rbsinceros.Checked Then
                        reporte.SetParameterValue("TipoStock", "Sin Ceros")
                    ElseIf rbceros.Checked Then
                        reporte.SetParameterValue("TipoStock", "Con Ceros")
                    ElseIf rbpositivos.Checked Then
                        reporte.SetParameterValue("TipoStock", "Positivos")
                    ElseIf rbnegativos.Checked Then
                        reporte.SetParameterValue("TipoStock", "Negativos")
                    ElseIf rbbajominimo.Checked Then
                        reporte.SetParameterValue("TipoStock", "Bajo el Mínimo")
                    ElseIf rbbajomaximo.Checked Then
                        reporte.SetParameterValue("TipoStock", "Bajo el Máximo")
                    End If

                    forma.ShowDialog()






                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oLocacionMercaderiaService.MostrarUnidadesNegocioAlmacen(Session.sCodEmp, Session.sCodUsu).Tables(0)
            'dtUnidades.Rows.InsertAt(getRowTodos(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

            '======================================= Tipos Movimientos ================================================
            dtMovimientos = oMaestro.MostrarMovimiento.Tables(0)
            dtMovimientos.Rows.InsertAt(getRowTodos(dtMovimientos), 0)
            cmbCodMov.DataSource = dtMovimientos
            cmbCodMov.DropDownList.DataMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.DropDownList.DisplayMember = dtMovimientos.Columns("DesMov").ToString
            cmbCodMov.DropDownList.ValueMember = dtMovimientos.Columns("CodMov").ToString
            cmbCodMov.DropDownList.Columns(0).DataMember = dtMovimientos.Columns("CodMov").ToString
            cmbCodMov.DropDownList.Columns(1).DataMember = dtMovimientos.Columns("DesMov").ToString
            dtMovimientos = Nothing
            '======================================= Ciclos ==========================================================

            dtCiclos = oMaestro.MostrarCiclos.Tables(0)
            dtCiclos.Rows.InsertAt(getRowTodos(dtCiclos), 0)
            cmbCiclos.DataSource = dtCiclos
            cmbCiclos.DropDownList.DataMember = dtCiclos.Columns("DesCic").ToString
            cmbCiclos.DropDownList.DisplayMember = dtCiclos.Columns("DesCic").ToString
            cmbCiclos.DropDownList.ValueMember = dtCiclos.Columns("CodCic").ToString
            cmbCiclos.DropDownList.Columns(0).DataMember = dtCiclos.Columns("CodCic").ToString
            cmbCiclos.DropDownList.Columns(1).DataMember = dtCiclos.Columns("DesCic").ToString
            dtCiclos = Nothing
            '====================================== Tipo Motor =======================================================

            dtTiposMotores = oTipoMotorService.Mostrar(Session.sCodEmp).Tables(0)
            dtTiposMotores.Rows.InsertAt(getRowMotores(dtTiposMotores), 0)
            cmbTipMot.DataSource = dtTiposMotores
            cmbTipMot.DropDownList.DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.DisplayMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.ValueMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(0).DataMember = dtTiposMotores.Columns("TipMot").ToString
            cmbTipMot.DropDownList.Columns(1).DataMember = dtTiposMotores.Columns("Descripcion").ToString
            cmbTipMot.SelectedIndex = 0
            dtTiposMotores = Nothing

            '======================================= RUBROS ================================================
            dtRubros = oMercaderiaService.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbCodRub.DataSource = dtRubros
            cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.SelectedIndex = 0
            dtRubros = Nothing

            '======================================= CLASES ================================================
            dtClases = oMercaderiaService.MostrarClasePorEmpresa(Session.sCodEmp).Tables(0)
            dtClases.Rows.InsertAt(getRowTodos(dtClases), 0)
            cmbIdClase.DataSource = dtClases
            cmbIdClase.DropDownList.DataMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.DropDownList.DisplayMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.DropDownList.ValueMember = dtClases.Columns("IdClase").ToString
            cmbIdClase.DropDownList.Columns(0).DataMember = dtClases.Columns("IdClase").ToString
            cmbIdClase.DropDownList.Columns(1).DataMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.SelectedIndex = 0
            dtClases = Nothing


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub cmbUnidad_ValueChanged(sender As Object, e As EventArgs) Handles cmbUnidad.ValueChanged
        '======================================= Oficinas ================================================
        dtOficinas = oLocacionMercaderiaService.MostrarOficinasUnidad(Session.sCodEmp, cmbUnidad.Value, Session.sCodUsu).Tables(0)
        dtOficinas.Rows.InsertAt(getRowTodos(dtOficinas), 0)
        cmbOficinas.DataSource = dtOficinas
        'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
        cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
        cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
        cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
        cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
        cmbOficinas.SelectedIndex = 1
        If dtOficinas.Rows.Count > 1 Then
            cmbOficinas.SelectedIndex = 1

        Else
            cmbOficinas.SelectedIndex = 0

        End If
        dtOficinas = Nothing

        Try
            '======================================= ALMACENES ================================================
            dtAlmacenes = oLocacionMercaderiaService.MostrarLocacionesUnidad(Session.sCodEmp, cmbUnidad.Value, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            dtAlmacenes.Rows.InsertAt(getRowAlmacen(dtAlmacenes), 0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString

            If dtAlmacenes.Rows.Count > 1 Then
                cmbIdLocacion.SelectedIndex = 1
            Else
                cmbIdLocacion.SelectedIndex = 0
                'cmbIdLocacion.Text = "(Todos)"
            End If
            dtAlmacenes = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try


    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged

        Try

            '======================================= ALMACENES ================================================
            dtAlmacenes = oLocacionMercaderiaService.MostrarLocacionesUnidad(Session.sCodEmp, cmbUnidad.Value, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            dtAlmacenes.Rows.InsertAt(getRowAlmacen(dtAlmacenes), 0)
            cmbIdLocacion.DataSource = dtAlmacenes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString

            If dtAlmacenes.Rows.Count > 1 Then
                cmbIdLocacion.SelectedIndex = 1
            Else
                cmbIdLocacion.SelectedIndex = 0
                'cmbIdLocacion.Text = "(Todos)"
            End If
            dtAlmacenes = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try

    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbIdLocacion.ValueChanged

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
    Private Sub btnBuscarAplicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAplicacion.Click

        Dim frm As New frmBuscarAplicacion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            rbAplicacion.Checked = False
            txtAplicacion.Text = frm.descripcion
            txtAplicacion.BackColor = System.Drawing.SystemColors.Control
            codApl = frm.codigo

        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(12, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)

        ChequearMarcados()

        If DataGridView3.Rows.Count > 1 And cbRubro.Checked Then
            If rbExportExcel.Checked Then
                MostrarReporte()
            Else
                MostrarReporte1()
            End If

        Else
            MostrarReporteAntiguo()
        End If

    End Sub

    Private Sub ChequearMarcados()

        codRubs = ""
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
                codRubs = codRubs + "'" + row2.Cells("CodRub").Text + "'" + ","
            Next
            codRubs = Strings.Left(codRubs, codRubs.Length - 1)
        End If


        DataGridView3.DataSource = dtDatosN2

    End Sub
    Private Sub rbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMarca.CheckedChanged
        txtMarca.Text = ""

    End Sub
    Private Sub rbAplicacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAplicacion.CheckedChanged
        txtAplicacion.Text = ""
    End Sub
    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Dim frm As New frmBuscarProveedor
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtProveedor.Text = frm.descripcion
            txtProveedor.BackColor = System.Drawing.SystemColors.Control
            IdProveedor = frm.codigo
        End If
        txtProveedor.Select()
        rbBuscarProveedor.Checked = False
    End Sub

    Private Sub rbBuscarProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuscarProveedor.CheckedChanged
        If rbBuscarProveedor.Checked = True Then
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
        End If
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
        dtRubros = oMercaderiaService.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
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

    Private Sub btnComprasAnuales_Click(sender As Object, e As EventArgs) Handles btnComprasAnuales.Click
        If toBlank(txtFecha.Text) = "" Then
            MsgBox("Debe Ingresar la fecha.", MsgBoxStyle.Information, "Información")
            txtFecha.Focus()
        ElseIf toNumber(cmbIdLocacion.Value) = 0 Then
            MsgBox("Debe Seleccionar el almacen.", MsgBoxStyle.Information, "Información")
            cmbCodRub.Focus()
        ElseIf toBlank(cmbCodRub.Value) = "" Then
            MsgBox("Debe Seleccionar el rubro.", MsgBoxStyle.Information, "Información")
            cmbCodRub.Focus()
        Else
            MostrarReporteCompras()
        End If
    End Sub

    Private Sub mostrarReporteCompras()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepComprasAnuales

            dtReporte = oLocacionMercaderiaService.ReporteCompras(toNumber(cmbIdLocacion.Value), txtFecha.Value, toBlank(cmbCodRub.Value)).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay datos a mostrar")
            Else
                Dim fecha As Date
                fecha = txtFecha.Text
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte

                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                'forma.crvReportes.RefreshReport = False
                'forma.crvReportes.DisplayGroupTree = False

                reporte.SetParameterValue("pRubro", cmbCodRub.Text.ToUpper)
                reporte.SetParameterValue("pFecha", txtFecha.Text)
                reporte.SetParameterValue("pOficina", cmbOficinas.Text.ToUpper)
                reporte.SetParameterValue("pAlmacen", cmbIdLocacion.Text.ToUpper)
                reporte.SetParameterValue("Anio3", Format(fecha, "yyyy"))
                reporte.SetParameterValue("Anio2", Format(fecha, "yyyy") - 1)
                reporte.SetParameterValue("Anio1", Format(fecha, "yyyy") - 2)
                reporte.SetParameterValue("Anio0", Format(fecha, "yyyy") - 3)
                forma.Text = "Reporte de Compras Anuales"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub rbDetallado_CheckedChanged(sender As Object, e As EventArgs) Handles rbDetallado.CheckedChanged
        If rbDetallado.Checked Then
            cmbOficinas.Enabled = True
            cmbIdLocacion.Enabled = True
            cmbOficinas.Enabled = True
            cmbIdLocacion.Enabled = True
            txtUbiMer.Enabled = True
            cmbIdClase.Enabled = True
            cmbCodMov.Enabled = True
            cmbCiclos.Enabled = True
            cmbTipMot.Enabled = True
            cmbCodRub.Enabled = True
            btnBuscarProveedor.Enabled = True
            btnComprasAnuales.Enabled = True
            'btnBuscarMarca.Enabled = True
            btnBuscaMarca.Enabled = True
            btnBuscarAplicacion.Enabled = True
            btnBuscaMarca.Enabled = True
            'rbPantalla.Enabled = True
            rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
            'rbExportExcel.Enabled = True
            rbFisico.Enabled = True
            rbDisponible.Enabled = True
            rbBuscarProveedor.Enabled = True
            grTipoStock.Enabled = True
            rbInvGeneralExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
        Else
            cmbOficinas.Enabled = False
            cmbIdLocacion.Enabled = False
            txtUbiMer.Enabled = False
            cmbIdClase.Enabled = False
            cmbCodMov.Enabled = False
            cmbCiclos.Enabled = False
            cmbTipMot.Enabled = False
            btnBuscarProveedor.Enabled = False
            btnComprasAnuales.Enabled = False
            'btnBuscarMarca.Enabled = False
            btnBuscarAplicacion.Enabled = False
            'rbPantalla.Enabled = False
            rbExportExcel.Enabled = False
            rbFisico.Enabled = False
            rbDisponible.Enabled = False
        End If
    End Sub

    Private Sub rbTotalizado_CheckedChanged(sender As Object, e As EventArgs) Handles rbTotalizado.CheckedChanged
        If rbTotalizado.Checked Then
            cmbOficinas.Enabled = False
            cmbIdLocacion.Enabled = False
            cmbUnidad.Enabled = False
            txtUbiMer.Enabled = False
            cmbIdClase.Enabled = False
            cmbCodMov.Enabled = False
            cmbCiclos.Enabled = False
            cmbTipMot.Enabled = False
            cbRubro.Visible = False
            cmbCodRub.Enabled = True
            btnBuscarProveedor.Enabled = False
            btnComprasAnuales.Enabled = False
            'btnBuscarMarca.Enabled = False
            btnBuscaMarca.Enabled = False
            btnBuscarAplicacion.Enabled = False
            'rbPantalla.Enabled = False
            rbExportExcel.Enabled = False
            rbFisico.Enabled = False
            rbDisponible.Enabled = False
            rbBuscarProveedor.Enabled = False
            grTipoStock.Enabled = True
            rbInvGeneralExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
        Else
            cmbUnidad.Enabled = True
            cmbOficinas.Enabled = True
            cmbIdLocacion.Enabled = True
            txtUbiMer.Enabled = True
            cmbIdClase.Enabled = True
            cmbCodMov.Enabled = True
            cmbCiclos.Enabled = True
            cmbTipMot.Enabled = True
            btnBuscarProveedor.Enabled = True
            btnComprasAnuales.Enabled = True
            'btnBuscarMarca.Enabled = True
            btnBuscarAplicacion.Enabled = True
            'rbPantalla.Enabled = True
            rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
            'rbExportExcel.Enabled = True
            rbFisico.Enabled = True
            rbDisponible.Enabled = True
        End If
    End Sub

    Private Sub rbComprometidos_CheckedChanged(sender As Object, e As EventArgs) Handles rbComprometidos.CheckedChanged
        If rbComprometidos.Checked Then
            cmbUnidad.Enabled = True
            cmbOficinas.Enabled = True
            cmbIdLocacion.Enabled = True
            rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
            'rbExportExcel.Enabled = True

            txtUbiMer.Enabled = False
            cmbIdClase.Enabled = False
            cmbCodMov.Enabled = False
            cmbCiclos.Enabled = False
            cmbTipMot.Enabled = False
            cbRubro.Visible = False
            cmbCodRub.Enabled = False
            btnBuscarProveedor.Enabled = False
            btnComprasAnuales.Enabled = False
            'btnBuscarMarca.Enabled = False
            btnBuscaMarca.Enabled = False
            btnBuscarAplicacion.Enabled = False
            rbInvGeneralExcel.Enabled = False
            rbFisico.Enabled = False
            rbDisponible.Enabled = False
            rbBuscarProveedor.Enabled = False
            grTipoStock.Enabled = False
            txtFecha.Text = Today
            txtFecha.ReadOnly = True
        Else
            cmbUnidad.Enabled = True
            cmbOficinas.Enabled = True
            cmbIdLocacion.Enabled = True
            txtUbiMer.Enabled = True
            cmbIdClase.Enabled = True
            cmbCodMov.Enabled = True
            cmbCiclos.Enabled = True
            cmbTipMot.Enabled = True
            btnBuscarProveedor.Enabled = True
            btnComprasAnuales.Enabled = True
            'btnBuscarMarca.Enabled = True
            btnBuscarAplicacion.Enabled = True
            'rbPantalla.Enabled = True
            rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
            'rbExportExcel.Enabled = True
            rbFisico.Enabled = True
            rbDisponible.Enabled = True
            txtFecha.ReadOnly = False
        End If
    End Sub


End Class