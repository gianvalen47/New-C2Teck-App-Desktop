
Imports System.ServiceModel
Imports Janus.Windows.GridEX

Public Class frmMovimAlmacen_OrdenCompra

    Private oOrdenesCompraDetService As New OrdenesCompraDetService.OrdenesCompraDetServiceClient
    Private oMoviAlmacenService As New MoviAlmacenService.MoviAlmacenServiceClient
    Private oMoviAlmacenDetService As New MoviAlmacenDetService.MoviAlmacenDetServiceClient

    Private dtDatos As DataTable
    'Private IdOrdenDet As Integer
    Private dtDatosN As DataTable
    Public IdMovimiento As Integer
    Public IdOrdenG As Integer

    Private Sub frmMovimAlmacen_OrdenCompra_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenesCompraDetService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraDetService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraDetService.Abort()
        End Try
    End Sub

    Private Sub frmMovimAlmacen_OrdenCompra_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMovimAlmacen_OrdenCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim estilo As New Estilo
        'estilo.cargaEstiloDataDrid(dgvDatosN)

        Me.Text = "Orden de Compra N° : " & IdOrdenG

        dgvDatosN.BackgroundColor = Color.Beige
        dgvDatosN.BackColor = Color.Beige
        dgvDatosN.ForeColor = Color.MidnightBlue
        dgvDatosN.AutoGenerateColumns = False

        listaDatos()

        dgvDatosN.ReadOnly = False

        dgvDatosN.Columns(0).ReadOnly = True
        dgvDatosN.Columns(1).ReadOnly = True
        dgvDatosN.Columns(2).ReadOnly = True
        dgvDatosN.Columns(3).ReadOnly = True
        dgvDatosN.Columns(4).ReadOnly = True
        dgvDatosN.Columns(5).ReadOnly = True
        dgvDatosN.Columns(6).ReadOnly = True
        dgvDatosN.Columns(7).ReadOnly = True
        dgvDatosN.Columns(8).ReadOnly = True
        dgvDatosN.Columns(9).ReadOnly = True
        dgvDatosN.Columns(10).ReadOnly = True
        dgvDatosN.Columns(11).ReadOnly = False
        dgvDatosN.Columns(12).ReadOnly = True
        dgvDatosN.Columns(13).ReadOnly = True
        dgvDatosN.Columns(14).ReadOnly = True
        dgvDatosN.Columns(15).ReadOnly = True
        dgvDatosN.Columns(16).ReadOnly = True

    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oOrdenesCompraDetService.MostrarPendientes(toNumber(IdOrdenG)).Tables(0)
            dgvDatos.DataSource = dtDatos
            dgvDatosN.DataSource = dtDatos

            IdOrdenGrd.DataPropertyName = dtDatos.Columns("IdOrdenDet").ColumnName
            IdOrden.DataPropertyName = dtDatos.Columns("IdOrden").ColumnName
            CodArea.DataPropertyName = dtDatos.Columns("CodArea").ColumnName
            CodRubro.DataPropertyName = dtDatos.Columns("CodRubro").ColumnName
            CodJob.DataPropertyName = dtDatos.Columns("CodJob").ColumnName
            Item.DataPropertyName = dtDatos.Columns("Item").ColumnName
            CodMer.DataPropertyName = dtDatos.Columns("CodMer").ColumnName
            DesMer.DataPropertyName = dtDatos.Columns("DesMer").ColumnName
            CanMer.DataPropertyName = dtDatos.Columns("CanMer").ColumnName
            PreMer.DataPropertyName = dtDatos.Columns("PreMer").ColumnName
            DscMer.DataPropertyName = dtDatos.Columns("DscMer").ColumnName
            TotalFila.DataPropertyName = dtDatos.Columns("TotalFila").ColumnName
            Observacion.DataPropertyName = dtDatos.Columns("Observacion").ColumnName
            Placa.DataPropertyName = dtDatos.Columns("Placa").ColumnName
            CanRec.DataPropertyName = dtDatos.Columns("CanRec").ColumnName
            CanPen.DataPropertyName = dtDatos.Columns("CanPen").ColumnName
            Despacho.DataPropertyName = dtDatos.Columns("Despacho").ColumnName

            sslTotal.Text = dtDatos.Rows.Count

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub CargandoValoresGrilla()

    '    Try

    '        Dim row As DataRow

    '        Dim dtCopia As New DataTable("tabla")

    '        dtCopia.Columns.Add(New DataColumn("IdOrdenDet", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("IdOrden", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("CodArea", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("CodRubro", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("CodJob", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.String")))       'datetime
    '        dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))        'datetime
    '        dtCopia.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("CanMer", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("CanRec", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("CanPen", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("PreMer", Type.GetType("System.Double")))
    '        dtCopia.Columns.Add(New DataColumn("DscMer", Type.GetType("System.Double")))
    '        dtCopia.Columns.Add(New DataColumn("TotalFila", Type.GetType("System.Double")))
    '        dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("Placa", Type.GetType("System.String")))

    '        dtCopia.Rows.Add(New Object() {"1", "1", "area", "rubro", "job", "item", "codmer", "desmer", "0", "0", "0", "0.00", "0.00", "0.00", "observacion", "placa"})

    '        dtDatosN = dtCopia.Copy
    '        dtDatosN.Clear()

    '        Dim Saldo As Double = 0

    '        For i As Integer = 0 To DataGridView1.Rows.Count - 2

    '            If CInt(DataGridView1.Item(5, i).Value) <> 0 Then

    '                row = dtDatosN.NewRow

    '                'row(0) = CInt(DataGridView1.Item(0, i).Value)
    '                'row(1) = CInt(DataGridView1.Item(1, i).Value)
    '                'row(2) = DataGridView1.Item(2, i).Value
    '                'row(3) = DataGridView1.Item(3, i).Value
    '                'row(4) = DataGridView1.Item(4, i).Value
    '                'row(5) = DataGridView1.Item(5, i).Value
    '                'row(6) = DataGridView1.Item(6, i).Value     'canmerhttp://190.102.134.70/Intranet
    '                'row(7) = DataGridView1.Item(7, i).Value     'canrec
    '                'row(8) = CInt(DataGridView1.Item(8, i).Value)
    '                'row(9) = DataGridView1.Item(9, i).Value
    '                'row(10) = DataGridView1.Item(10, i).Value
    '                'row(11) = DataGridView1.Item(11, i).Value
    '                'row(12) = IIf(DataGridView1.Item(12, i).Value = "", "0.00", DataGridView1.Item(12, i).Value)    'CDbl(DDataGridView1.Item(12, i).Value)
    '                'row(13) = DataGridView1.Item(13, i).Value
    '                'row(14) = DataGridView1.Item(14, i).Value
    '                'row(15) = DataGridView1.Item(15, i).Value

    '                row(0) = CInt(DataGridView1.Item(0, i).Value)
    '                row(1) = CInt(DataGridView1.Item(1, i).Value)
    '                row(2) = DataGridView1.Item(2, i).Value
    '                row(3) = DataGridView1.Item(3, i).Value
    '                row(4) = DataGridView1.Item(4, i).Value
    '                row(5) = DataGridView1.Item(5, i).Value
    '                row(6) = DataGridView1.Item(6, i).Value     'canmerhttp://190.102.134.70/Intranet
    '                row(7) = DataGridView1.Item(7, i).Value     'canrec
    '                row(8) = CInt(DataGridView1.Item(8, i).Value)
    '                row(9) = DataGridView1.Item(14, i).Value
    '                row(10) = DataGridView1.Item(15, i).Value
    '                row(11) = DataGridView1.Item(9, i).Value
    '                row(12) = DataGridView1.Item(10, i).Value   'CDbl(DDataGridView1.Item(12, i).Value)
    '                row(13) = DataGridView1.Item(11, i).Value
    '                row(14) = DataGridView1.Item(12, i).Value
    '                row(15) = DataGridView1.Item(13, i).Value


    '                dtDatosN.Rows.Add(row)

    '            End If
    '        Next

    '        dgvDatos.DataSource = dtDatosN

    '    Catch ex As Exception
    '        MsgBox("Error al Crear el Datatable Nuevo : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    Private Sub btnInsertarDetalles_Click(sender As Object, e As EventArgs) Handles btnInsertarDetalles.Click

        Try
            If MsgBox("¿Está seguro de Insertar los detalles?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                txtUpdate.Focus()
                dgvDatos.Update()
                Dim dtTable As DataTable
                'Dim rows As DataRow

                dtTable = dtDatos.Copy
                dtTable.Clear()

                Dim contador As Integer = 0
                Dim estado_process As Boolean

                For i As Integer = 0 To dtDatos.Rows.Count - 1

                    Dim row As DataGridViewRow = dgvDatosN.Rows(i)
                    'Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbAtender"), DataGridViewCheckBoxCell)

                    'If toBoolean(cellSelecion.Value) = True Then
                    If toNumber(dtDatos.Rows(i).Item("Despacho")) > 0 Then

                        'Cadena = row.Cells("IdOrdenDet").Text

                        Dim registro As New MoviAlmacenDetService.MoviAlmacenDet
                        Dim movimiento As New MoviAlmacenDetService.MoviAlmacen
                        Dim mercaderia As New MoviAlmacenDetService.Mercaderia
                        Dim ordencompradet As New MoviAlmacenDetService.OrdenesCompraDet
                        Dim ordencompra As New MoviAlmacenDetService.OrdenesCompra

                        registro.IdMovimientoDet = 0
                        movimiento.IdMovimiento = IIf(toNumber(IdMovimiento) = 0, Nothing, IdMovimiento)
                        registro.MoviAlmacen = movimiento

                        mercaderia.CodMer = dtDatos.Rows(i).Item("CodMer")
                        registro.Mercaderia = mercaderia

                        ordencompra.IdOrden = IdOrdenG
                        ordencompradet.OrdenesCompra = ordencompra
                        ordencompradet.IdOrdenDet = dtDatos.Rows(i).Item(0)
                        registro.OrdenesCompraDet = ordencompradet

                        'ordencompradet.IdOrdenDet = dtDatos.Rows(i).Item(0)
                        'registro.OrdenesCompraDet = ordencompradet

                        registro.CanMer = toNumber(dtDatos.Rows(i).Item("Despacho"))  'toNumber(row.Cells("CanMer").Text)
                        registro.PreMer = toDouble(dtDatos.Rows(i).Item("PreMer"))
                        registro.DscMer = toDouble(dtDatos.Rows(i).Item("DscMer"))

                        estado_process = oMoviAlmacenDetService.Insertar(registro, Session.sCodUsu)

                        'rows = dtTable.NewRow
                        'rows(0) = dtDatos.Rows(i).Item(0)
                        'rows(1) = dtDatos.Rows(i).Item(1)
                        'rows(2) = dtDatos.Rows(i).Item(2)
                        'rows(3) = dtDatos.Rows(i).Item(3)
                        'rows(4) = dtDatos.Rows(i).Item(4)
                        'rows(5) = dtDatos.Rows(i).Item(5)
                        'rows(6) = dtDatos.Rows(i).Item(6)
                        'rows(7) = dtDatos.Rows(i).Item(7)
                        'rows(8) = dtDatos.Rows(i).Item(8)
                        'rows(9) = dtDatos.Rows(i).Item(9)
                        'rows(10) = dtDatos.Rows(i).Item(10)
                        'rows(11) = dtDatos.Rows(i).Item(11)
                        'rows(12) = dtDatos.Rows(i).Item(12)
                        'rows(13) = dtDatos.Rows(i).Item(13)
                        'rows(14) = dtDatos.Rows(i).Item(14)
                        'rows(15) = dtDatos.Rows(i).Item(15)
                        'rows(16) = dtDatos.Rows(i).Item(16)
                        'rows(17) = dtDatos.Rows(i).Item(17)

                        'dtTable.Rows.Add(rows)
                        'Else
                        'MsgBox("Debe seleccionar alguno de los correos")

                        If estado_process = False Then
                            contador = +1
                        End If

                    End If

                Next

                If contador = 0 Then
                    MsgBox("No se insertaron ningun detalle de la Orden de Compra..., Verifique.", MsgBoxStyle.Information)

                Else
                    MsgBox("Se insertaron los detalles de la Orden de Compra", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try


        'Try
        '    If dgvDatos.RowCount > 0 Then

        '        Dim rows() As Janus.Windows.GridEX.GridEXRow
        '        Dim Cadena As String = ""
        '        rows = dgvDatos.GetCheckedRows()
        '        Dim row As Janus.Windows.GridEX.GridEXRow

        '        If rows.Count <> 0 Then
        '            For Each row In rows

        '                'Cadena = row.Cells("IdOrdenDet").Text

        '                Dim registro As New MoviAlmacenDetService.MoviAlmacenDet
        '                Dim movimiento As New MoviAlmacenDetService.MoviAlmacen
        '                Dim mercaderia As New MoviAlmacenDetService.Mercaderia
        '                Dim ordencompradet As New MoviAlmacenDetService.OrdenesCompraDet

        '                registro.IdMovimientoDet = 0
        '                movimiento.IdMovimiento = IIf(toNumber(IdMovimiento) = 0, Nothing, IdMovimiento)
        '                registro.MoviAlmacen = movimiento
        '                mercaderia.CodMer = row.Cells("CodMer").Text
        '                registro.Mercaderia = mercaderia
        '                ordencompradet.IdOrdenDet = row.Cells("IdOrdenDet").Text
        '                registro.OrdenesCompraDet = ordencompradet
        '                registro.CanMer = toNumber(row.Cells("CanRec").Text)  'toNumber(row.Cells("CanMer").Text)
        '                registro.PreMer = toDouble(row.Cells("PreMer").Text)
        '                registro.DscMer = toDouble(row.Cells("DscMer").Text)

        '                Dim estado_process As Boolean
        '                estado_process = oMoviAlmacenDetService.Insertar(registro, Session.sCodUsu)
        '            Next
        '            MsgBox("Se insertaron los detalles de la Orden de Compra", MsgBoxStyle.Information)

        '        Else
        '            MsgBox("Debe seleccionar alguno de los correos")
        '        End If

        '    Else
        '        MsgBox("Debe ingresar los detalles", MsgBoxStyle.Exclamation)
        '    End If
        'Catch ex As Exception
        '    MsgBox("Error al Enviar la Solicitud de Gastos: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub miSeleccionarTodo_Click(sender As Object, e As EventArgs) Handles miSeleccionarTodo.Click
        seleccionaTodos(True)
    End Sub

    Private Sub miSeterCEROTodos_Click(sender As Object, e As EventArgs) Handles miSeterCEROTodos.Click
        seleccionaTodos(False)
    End Sub

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    Private Sub seleccionaTodos(ByVal condicion As Boolean)
        ''//Codigo Comentado agregado para solucionar el problema de Columna Despacho q seteaba 0

        For i As Integer = 0 To dtDatos.Rows.Count - 1
            If condicion = True Then
                dgvDatosN.Rows(i).Cells("Despacho").Value = dgvDatosN.Rows(i).Cells("CanPen").Value
            Else
                dgvDatosN.Rows(i).Cells("Despacho").Value = 0
            End If
        Next
    End Sub

    'Private Function actualizaListaDetalle() As Integer
    '    Dim nroItem As Integer = 0
    '    For i As Integer = 0 To dtDatos.Rows.Count - 1
    '        dtDatos.Rows(i).Item(13) = dgvDatosN.Rows(i).Cells("Despacho").Value
    '        If toNumber(dtDatos.Rows(i).Item(13)) > 0 Then
    '            nroItem = nroItem + 1
    '        End If
    '    Next
    '    Return nroItem
    'End Function

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatosN.Rows.Count > 0 Then
                If IsDBNull(dgvDatosN.CurrentRow.Cells(0).Value) = False Then
                    codigo = dgvDatosN.CurrentRow.Cells("Item").Value
                End If
            End If
            dtDatos = Nothing
            'listaDatos()
            If dgvDatosN.Rows.Count > 0 And codigo.Trim.Length > 0 Then
                dgvDatosN.CurrentRow.Cells("Despacho").Value = 0
                'RowPossesion(dgvDatos, dtDatos, "Item", codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-04]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_CellEditCanceled(sender As Object, e As ColumnActionEventArgs) Handles dgvDatos.CellEditCanceled
        If dgvDatos.RowCount < 1 Then
        ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
        ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
        Else
            dgvDatos.CurrentRow.Cells("Despacho").Text = 0
        End If
    End Sub

    Private Sub dgvDatos_CellUpdated(sender As Object, e As ColumnActionEventArgs) Handles dgvDatos.CellUpdated
        If toNumber(dgvDatos.CurrentRow.Cells("Despacho").Text) > toNumber(dgvDatos.CurrentRow.Cells("CanPen").Text) Then
            MsgBox("El cantidad a despachar esta fuera de rango.", MsgBoxStyle.Information, "Información")
            actualizar()
        Else

        End If
    End Sub

    Private Sub miMarcarTodos_Click(sender As Object, e As EventArgs) Handles miMarcarTodos.Click
        For Each fila As DataGridViewRow In dgvDatosN.Rows
            fila.Cells(16).Value = True
        Next
    End Sub

    Private Sub miDesmarcarTodos_Click(sender As Object, e As EventArgs) Handles miDesmarcarTodos.Click
        For Each fila As DataGridViewRow In dgvDatosN.Rows
            fila.Cells(16).Value = False
        Next
    End Sub

    Private Sub miBuscar_Click_1(sender As Object, e As EventArgs) Handles miBuscar.Click
        BuscarDetalle()
    End Sub

    Private Sub BuscarDetalle()
        Try
            Dim frm As New frmBuscarDetalle
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'MessageBox.Show(" " & frm.codigoDetalle)
                Dim rows() As Janus.Windows.GridEX.GridEXRow
                rows = dgvDatos.GetRows

                For Each row In rows

                    If CStr(row.Cells("CodMer").Value) = frm.codigoDetalle Then

                        dgvDatos.Row = row.Position
                        dgvDatos.Col = 1

                        Exit For
                    End If
                Next
                'RowPossesion(dgvDatos, dtDatos, "CodMer", frm.codigoDetalle)
            End If
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    'Private Sub miSeleccionarTodo_Click(sender As Object, e As EventArgs) Handles miSeleccionarTodo.Click

    '    Try
    '        Dim row As DataRow

    '        Dim dtCopia As New DataTable("tabla")

    '        dtCopia.Columns.Add(New DataColumn("IdOrdenDet", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("IdOrden", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("CodArea", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("CodRubro", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("CodJob", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.String")))       'datetime
    '        dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))        'datetime
    '        dtCopia.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("CanMer", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("CanRec", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("CanPen", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("PreMer", Type.GetType("System.Double")))
    '        dtCopia.Columns.Add(New DataColumn("DscMer", Type.GetType("System.Double")))
    '        dtCopia.Columns.Add(New DataColumn("TotalFila", Type.GetType("System.Double")))
    '        dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("Placa", Type.GetType("System.String")))

    '        dtCopia.Rows.Add(New Object() {"1", "1", "area", "rubro", "job", "item", "codmer", "desmer", "0", "0", "0", "0.00", "0.00", "0.00", "observacion", "placa"})

    '        dtDatosN = dtCopia.Copy
    '        dtDatosN.Clear()

    '        Dim Saldo As Double = 0

    '        For i As Integer = 0 To DataGridView1.Rows.Count - 2

    '            If DataGridView1.Item(1, i).Value <> 0 Then

    '                row = dtDatosN.NewRow

    '                'row(0) = CInt(DataGridView1.Item(0, i).Value)
    '                'row(1) = CInt(DataGridView1.Item(1, i).Value)
    '                'row(2) = DataGridView1.Item(2, i).Value
    '                'row(3) = DataGridView1.Item(3, i).Value
    '                'row(4) = DataGridView1.Item(4, i).Value
    '                'row(5) = DataGridView1.Item(5, i).Value
    '                'row(6) = DataGridView1.Item(6, i).Value     'canmer
    '                'row(7) = DataGridView1.Item(7, i).Value     'canrec
    '                'row(8) = CInt(DataGridView1.Item(8, i).Value)
    '                'row(9) = DataGridView1.Item(8, i).Value
    '                'row(10) = 0 'DataGridView1.Item(10, i).Value
    '                'row(11) = DataGridView1.Item(11, i).Value
    '                'row(12) = DataGridView1.Item(12, i).Value
    '                'row(13) = DataGridView1.Item(13, i).Value
    '                'row(14) = DataGridView1.Item(14, i).Value
    '                'row(15) = DataGridView1.Item(15, i).Value

    '                row(0) = CInt(DataGridView1.Item(0, i).Value)
    '                row(1) = CInt(DataGridView1.Item(1, i).Value)
    '                row(2) = DataGridView1.Item(2, i).Value
    '                row(3) = DataGridView1.Item(3, i).Value
    '                row(4) = DataGridView1.Item(4, i).Value
    '                row(5) = DataGridView1.Item(5, i).Value
    '                row(6) = DataGridView1.Item(6, i).Value     'canmerhttp://190.102.134.70/Intranet
    '                row(7) = DataGridView1.Item(7, i).Value     'canrec
    '                row(8) = CInt(DataGridView1.Item(8, i).Value)
    '                row(9) = DataGridView1.Item(8, i).Value
    '                row(10) = 0 ' DataGridView1.Item(15, i).Value
    '                row(11) = DataGridView1.Item(9, i).Value
    '                row(12) = DataGridView1.Item(10, i).Value   'CDbl(DDataGridView1.Item(12, i).Value)
    '                row(13) = DataGridView1.Item(11, i).Value
    '                row(14) = DataGridView1.Item(12, i).Value
    '                row(15) = DataGridView1.Item(13, i).Value


    '                dtDatosN.Rows.Add(row)

    '            End If
    '        Next

    '        dgvDatos.DataSource = dtDatosN

    '    Catch ex As Exception
    '        MsgBox("Error al Crear el Datatable Nuevo : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try



    'End Sub

    'Private Sub miSeterCEROTodos_Click(sender As Object, e As EventArgs) Handles miSeterCEROTodos.Click

    '    Try
    '        Dim row As DataRow

    '        Dim dtCopia As New DataTable("tabla")

    '        dtCopia.Columns.Add(New DataColumn("IdOrdenDet", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("IdOrden", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("CodArea", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("CodRubro", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("CodJob", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("Item", Type.GetType("System.String")))       'datetime
    '        dtCopia.Columns.Add(New DataColumn("CodMer", Type.GetType("System.String")))        'datetime
    '        dtCopia.Columns.Add(New DataColumn("DesMer", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("CanMer", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("CanRec", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("CanPen", Type.GetType("System.Int32")))
    '        dtCopia.Columns.Add(New DataColumn("PreMer", Type.GetType("System.Double")))
    '        dtCopia.Columns.Add(New DataColumn("DscMer", Type.GetType("System.Double")))
    '        dtCopia.Columns.Add(New DataColumn("TotalFila", Type.GetType("System.Double")))
    '        dtCopia.Columns.Add(New DataColumn("Observacion", Type.GetType("System.String")))
    '        dtCopia.Columns.Add(New DataColumn("Placa", Type.GetType("System.String")))

    '        dtCopia.Rows.Add(New Object() {"1", "1", "area", "rubro", "job", "item", "codmer", "desmer", "0", "0", "0", "0.00", "0.00", "0.00", "observacion", "placa"})

    '        dtDatosN = dtCopia.Copy
    '        dtDatosN.Clear()

    '        Dim Saldo As Double = 0

    '        For i As Integer = 0 To DataGridView1.Rows.Count - 2

    '            If DataGridView1.Item(1, i).Value <> 0 Then

    '                row = dtDatosN.NewRow

    '                'row(0) = CInt(DataGridView1.Item(0, i).Value)
    '                'row(1) = CInt(DataGridView1.Item(1, i).Value)
    '                'row(2) = DataGridView1.Item(2, i).Value
    '                'row(3) = DataGridView1.Item(3, i).Value
    '                'row(4) = DataGridView1.Item(4, i).Value
    '                'row(5) = DataGridView1.Item(5, i).Value
    '                'row(6) = DataGridView1.Item(6, i).Value     'canmer
    '                'row(7) = DataGridView1.Item(7, i).Value     'canrec
    '                'row(8) = CInt(DataGridView1.Item(8, i).Value)
    '                'row(9) = 0 'DataGridView1.Item(9, i).Value
    '                'row(10) = DataGridView1.Item(8, i).Value
    '                'row(11) = DataGridView1.Item(11, i).Value
    '                'row(12) = DataGridView1.Item(12, i).Value
    '                'row(13) = DataGridView1.Item(13, i).Value
    '                'row(14) = DataGridView1.Item(14, i).Value
    '                'row(15) = DataGridView1.Item(15, i).Value


    '                row(0) = CInt(DataGridView1.Item(0, i).Value)
    '                row(1) = CInt(DataGridView1.Item(1, i).Value)
    '                row(2) = DataGridView1.Item(2, i).Value
    '                row(3) = DataGridView1.Item(3, i).Value
    '                row(4) = DataGridView1.Item(4, i).Value
    '                row(5) = DataGridView1.Item(5, i).Value
    '                row(6) = DataGridView1.Item(6, i).Value     'canmerhttp://190.102.134.70/Intranet
    '                row(7) = DataGridView1.Item(7, i).Value     'canrec
    '                row(8) = CInt(DataGridView1.Item(8, i).Value)
    '                row(9) = 0 'DataGridView1.Item(8, i).Value
    '                row(10) = DataGridView1.Item(8, i).Value
    '                row(11) = DataGridView1.Item(9, i).Value
    '                row(12) = DataGridView1.Item(10, i).Value   'CDbl(DDataGridView1.Item(12, i).Value)
    '                row(13) = DataGridView1.Item(11, i).Value
    '                row(14) = DataGridView1.Item(12, i).Value
    '                row(15) = DataGridView1.Item(13, i).Value


    '                dtDatosN.Rows.Add(row)

    '            End If
    '        Next

    '        dgvDatos.DataSource = dtDatosN

    '    Catch ex As Exception
    '        MsgBox("Error al Crear el Datatable Nuevo : " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try

    'End Sub

    'Private Sub dgvDatos_CellUpdated(sender As Object, e As ColumnActionEventArgs) Handles dgvDatos.CellUpdated

    '    If toNumber(dgvDatos.CurrentRow.Cells("CanRec").Text) > toNumber(dgvDatos.CurrentRow.Cells("CanMer").Text) Then
    '        MsgBox("El cantidad a despachar esta fuera de rango.", MsgBoxStyle.Information, "Información")
    '        dgvDatos.CurrentRow.Cells("CanRec").Text = toNumber(dgvDatos.CurrentRow.Cells("CanMer").Text)
    '        Dim a As Integer
    '        a = dgvDatos.CurrentRow.RowIndex
    '    End If
    '    'actualizar()

    'End Sub
End Class