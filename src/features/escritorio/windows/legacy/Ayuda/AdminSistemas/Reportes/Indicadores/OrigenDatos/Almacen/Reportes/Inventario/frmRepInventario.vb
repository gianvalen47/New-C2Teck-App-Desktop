Imports System.ServiceModel
Public Class frmRepInventario
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oMaestro As New MaestroService.MaestroClient
    'Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Private oTipoMotorService As New TipoMotorService.TipoMotorServiceClient
    Private dtAlmacenes As DataTable
    Private dtOficinas As DataTable
    Private dtCiclos As DataTable
    Private dtMovimientos As DataTable
    Private dtTiposMotores As DataTable
    Private dtClases As DataTable
    Private dtRubros As DataTable
    Private codMar As String
    Private codApl As String

    Private Sub frmRepInventario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub


    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCombos()

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
        Catch ex As TimeoutException
            oMaestro.Abort()
            oLocacionMercaderiaService.Abort()
            oTipoMotorService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oLocacionMercaderiaService.Abort()
            oTipoMotorService.Close()

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
    
    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpRepInventario
            Dim dtReporte As New DataView

            ' dtReporte = oLocacionMercaderiaService.ReporteInventario(Today, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), cmbCiclos.Value, cmbCodMov.Value, txtUbiMer.Text).Tables(0).DefaultView

            dtReporte = oLocacionMercaderiaService.ReporteInventario(txtFecha.Text, cmbIdLocacion.Value, IIf(rbMarca.Checked, "", codMar), IIf(rbAplicacion.Checked, "", codApl), IIf(cmbCiclos.Value = "(Todos)", "", cmbCiclos.Value), IIf(cmbCodMov.Value = "(Todos)", "", cmbCodMov.Value), IIf(txtUbiMer.Text = "", "", txtUbiMer.Text), IIf(cmbTipMot.Text = "(Todos)", "", cmbTipMot.Value), cmbCodRub.Value, cmbIdClase.Value).Tables(0).DefaultView

            If dtReporte.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExportExcel.Checked Then
                    '-----------------------------------


                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        dtReporte.RowFilter = "Stock <> 0"
                    ElseIf rbceros.Checked Then
                        dtReporte.RowFilter = "Stock = 0"
                    ElseIf rbpositivos.Checked Then
                        dtReporte.RowFilter = "Stock > 0"
                    ElseIf rbnegativos.Checked Then
                        dtReporte.RowFilter = "Stock < 0"
                    ElseIf rbbajominimo.Checked Then
                        dtReporte.RowFilter = "Stock < MinMer"
                    ElseIf rbbajomaximo.Checked Then
                        dtReporte.RowFilter = "Stock < MaxMer"
                    End If

                    dtReporte.Table.Columns.Remove("CodEmp")
                    dtReporte.Table.Columns.Remove("DesEmp")
                    dtReporte.Table.Columns.Remove("RucEmp")
                    dtReporte.Table.Columns.Remove("CodOfi")
                    dtReporte.Table.Columns.Remove("CodAlm")
                    dtReporte.Table.Columns.Remove("CodMov")

                    DataGridView1.DataSource = dtReporte
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente")
                    End If

                ElseIf rbPantalla.Checked Then
                    If rbtodos.Checked Then
                        dtReporte.RowFilter = ""
                    ElseIf rbsinceros.Checked Then
                        dtReporte.RowFilter = "Stock <> 0"
                    ElseIf rbceros.Checked Then
                        dtReporte.RowFilter = "Stock = 0"
                    ElseIf rbpositivos.Checked Then
                        dtReporte.RowFilter = "Stock > 0"
                    ElseIf rbnegativos.Checked Then
                        dtReporte.RowFilter = "Stock < 0"
                    ElseIf rbbajominimo.Checked Then
                        dtReporte.RowFilter = "Stock < MinMer"
                    ElseIf rbbajomaximo.Checked Then
                        dtReporte.RowFilter = "Stock < MaxMer"
                    End If


                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
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
                    reporte.SetParameterValue("Rubro", cmbCodRub.Text)
                    reporte.SetParameterValue("Clase", cmbIdClase.Text)

                    If rbtodos.Checked Then
                        reporte.SetParameterValue("Stock", "Todos")
                    ElseIf rbsinceros.Checked Then
                        reporte.SetParameterValue("Stock", "Sin Ceros")
                    ElseIf rbceros.Checked Then
                        reporte.SetParameterValue("Stock", "Con Ceros")
                    ElseIf rbpositivos.Checked Then
                        reporte.SetParameterValue("Stock", "Positivos")
                    ElseIf rbnegativos.Checked Then
                        reporte.SetParameterValue("Stock", "Negativos")
                    ElseIf rbbajominimo.Checked Then
                        reporte.SetParameterValue("Stock", "Bajo el Mínimo")
                    ElseIf rbbajomaximo.Checked Then
                        reporte.SetParameterValue("Stock", "Bajo el Máximo")
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
            '======================================= Oficinas ================================================
            dtOficinas = oMaestro.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
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

            dtTiposMotores = oTipoMotorService.Mostrar.Tables(0)
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
            dtRubros = oMaestro.MostrarRubros.Tables(0)
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
            dtClases = oMaestro.MostrarClaseMerca.Tables(0)
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
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbIdLocacion.ValueChanged

    End Sub
    Private Sub btnBuscaMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaMarca.Click

        Dim frm As New frmBuscarMarca
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            rbMarca.Checked = False
            txtMarca.Text = frm.descripcion
            txtMarca.BackColor = System.Drawing.SystemColors.Control
            codMar = frm.codigo

        End If
    End Sub
    Private Sub btnBuscarAplicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAplicacion.Click

        Dim frm As New frmBuscarAplicacion
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            rbAplicacion.Checked = False
            txtAplicacion.Text = frm.descripcion
            txtAplicacion.BackColor = System.Drawing.SystemColors.Control
            codApl = frm.codigo

        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        MostrarReporte()
    End Sub
    Private Sub rbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMarca.CheckedChanged
        txtMarca.Text = ""

    End Sub
    Private Sub rbAplicacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAplicacion.CheckedChanged
        txtAplicacion.Text = ""
    End Sub

End Class