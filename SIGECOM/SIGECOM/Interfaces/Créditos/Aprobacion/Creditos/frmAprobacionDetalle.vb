Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmAprobacionDetalle
    Public pIdVenta As Int64
    Public pTipDoc As Int16
    Public pIdSugerido As Integer
    Public pIdCliente As Integer
    Private ObjDocumento As New AprobarVentaService.AprobarVentaServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private DocumentoVenta As New AprobarVentaService.DocumentoAprobacion
    Private SugeridoCabecera As New AprobarVentaService.SugeridoCabecera
    Private dtDetalle As DataTable
    Private IdLocacion As Integer
    Private Oficina As String
    Private Locacion As String
    Private GruAlm As String
    Private IdCliente As Integer
    Private CodMon As String
    Public Fecha As Date
    Private Resta As Decimal

    Private Sub frmAprobacionDetalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjDocumento) = False Then
                ObjDocumento.Close()
            End If
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAprobacionDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MsgBox("Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                dgDetalle.Focus()
            End If
        End If
    End Sub

    'Private Sub frmAprobacionDetalle_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    '    If e.KeyCode = Keys.Escape Then
    '        btnSalir_Click(sender, e)
    '    End If
    'End Sub
    Private Sub frmAprobacionDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim estilo As New Estilo
        'estilo.CargaEstiloGrid(dgDetalle)
        Dim estilo As New Estilo
        estilo.cargaEstiloDataDrid(dgDetalle)
        LlenarDatos()
        ' dgDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]


        If txtDscto.Value <> 0 Then
            txtDscto.BackColor = Color.IndianRed
            txtDscto.ForeColor = Color.Black
        End If
        If txtFactor.Value <> 0 Then
            txtFactor.BackColor = Color.IndianRed
            txtFactor.ForeColor = Color.Black
        End If
        If txtTotalSug.Value <> 0 Then
            txtTotalSug.BackColor = Color.Yellow
            txtTotalSug.ForeColor = Color.Black
        End If
    End Sub
    Private Sub LlenarDatos()
        Try
            DocumentoVenta = ObjDocumento.MostrarPorId(pIdVenta, pTipDoc)
            txtNumero.Text = DocumentoVenta.NumDoc
            txtFecDoc.Text = DocumentoVenta.FecDoc
            txtCliente.Text = DocumentoVenta.Cliente.DesCli
            txtOrden.Text = DocumentoVenta.NumOrden
            txtMoneda.Text = DocumentoVenta.Moneda.DesMon
            txtTipCam.Text = ObjMaestro.MostrarTipoCambio(DocumentoVenta.Moneda.CodMon, DocumentoVenta.FecDoc)
            'Comentado 17-07-24 porque mostraba totalneto con igv
            'txtTotalNeto.Text = DocumentoVenta.TotNeto
            IdLocacion = DocumentoVenta.Locacion.IdLocacion
            Oficina = DocumentoVenta.Locacion.Oficina.DesOfi
            Locacion = DocumentoVenta.Locacion.Almacen.DesAlm
            IdCliente = DocumentoVenta.Cliente.IdCliente
            CodMon = DocumentoVenta.Moneda.CodMon
            Fecha = DocumentoVenta.FecDoc
            If pIdSugerido > 0 Then
                SugeridoCabecera = ObjDocumento.MostrarSugerido(pIdSugerido, pTipDoc)
                'llenarTotalSugerido()
                LlenarGrilla()
                Dim Contador As Decimal
                Contador = 0
                For i As Integer = 0 To dtDetalle.Rows.Count - 1

                    If dgDetalle.Item(7, i).Value > 0 Then
                        If dgDetalle.Item(8, i).Value > 0 Then
                            Resta = (dgDetalle.Item(7, i).Value * dgDetalle.Item(3, i).Value) '* ((100 - dgDetalle.Item(8, i).Value) / 100)
                            'Comentado 20-01-25 porque aplicaba nuevamente el descuento y calculaba mal el txttotalsug
                            'Resta = (dgDetalle.Item(7, i).Value * dgDetalle.Item(3, i).Value) * ((100 - dgDetalle.Item(8, i).Value) / 100)
                        ElseIf dgDetalle.Item(8, i).Value = 0 Then
                            Resta = dgDetalle.Item(7, i).Value * dgDetalle.Item(3, i).Value
                        End If
                    ElseIf dgDetalle.Item(7, i).Value = 0 Then
                        If dgDetalle.Item(8, i).Value > 0 Then
                            Resta = (((100 - dgDetalle.Item(8, i).Value) * dgDetalle.Item(4, i).Value * dgDetalle.Item(3, i).Value) / 100)
                        ElseIf dgDetalle.Item(8, i).Value = 0 Then
                            Resta = dgDetalle.Item(6, i).Value
                        End If
                    End If
                    Contador = Contador + Resta
                    'Dim Resta As Decimal
                    'Resta = Val(dgDetalle.Item(7, i).Value) - Val(dgDetalle.Item(8, i).Value * dgDetalle.Item(3, i).Value)
                    'Contador = Contador + Val(Resta)
                Next
                Dim igv As Double = DocumentoVenta.Igv + 100
                'Comentado 30-05-24
                'txtTotalSug.Text = (Contador * igv) / 100
                txtTotalSug.Text = (Contador)


                'txtTotalSug.Text = (Contador * 118) / 100
                'txtTotalSug.Text = SugeridoCabecera.TotNetoSug
                txtFactor.Text = SugeridoCabecera.FactorSug
                txtDscto.Text = SugeridoCabecera.DsctoSug
                txtObservacion.Text = SugeridoCabecera.Observacion
            End If
            Me.Text = DocumentoVenta.Locacion.Oficina.DesOfi & " - " & DocumentoVenta.Locacion.Almacen.DesAlm & " / " & DocumentoVenta.SerieDocumento.TipoDocumento.Nombre & "(" & DocumentoVenta.SerieDocumento.TipoDocumento.AbrDoc & ") " & DocumentoVenta.SerieDocumento.CodSerie & "-" & Trim(DocumentoVenta.NumDoc)
            lblVendedor.Text = DocumentoVenta.Persona.ApeNom
            txtUsuario.Text = DocumentoVenta.CodUsu
            txtMotivo.Text = DocumentoVenta.Motivos.DesMot
            If DocumentoVenta.Motivos.CodMot = "2" Then
                txtMotivo.ForeColor = Color.Red
            End If
            LlenarGrilla()
            SumarTotalNeto()
            SumarCosto()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Mostrar Datos")
        End Try
    End Sub
    'Private Sub llenarTotalSugerido()
    '    Try
    '        LlenarDatos()
    '        Dim Contador As Decimal
    '        Contador = 0
    '        For i As Integer = 0 To dtDetalle.Rows.Count - 1
    '            Dim Resta As Decimal
    '            Resta = dgDetalle.Item(7, i).Value - dgDetalle.Item(8, i).Value
    '            Contador = Contador + Val(Resta)
    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Mostrar Datos")
    '    End Try
    'End Sub
    Public Sub LlenarGrilla()
        Try

            dtDetalle = ObjDocumento.MostrarDetalles(pIdVenta, pTipDoc).Tables(0)
            'Me.dgDetalle.SetDataBinding(dtDetalle, 0)
            dgDetalle.DataSource = dtDetalle

            'cIdMovimientoDet.DataPropertyName = dtDetalle.Columns("IdMovimientoDet").ColumnName
            cCodMer.DataPropertyName = dtDetalle.Columns("CodMer").ColumnName
            cDesMer1.DataPropertyName = dtDetalle.Columns("DesMer1").ColumnName
            cCanMer.DataPropertyName = dtDetalle.Columns("CanMer").ColumnName
            cPreMer.DataPropertyName = dtDetalle.Columns("PreMer").ColumnName
            cDscMer.DataPropertyName = dtDetalle.Columns("DscMer").ColumnName
            cTotalFila.DataPropertyName = dtDetalle.Columns("TotalFila").ColumnName
            cPreMerSug.DataPropertyName = dtDetalle.Columns("PreMerSug").ColumnName
            cDsctoSug.DataPropertyName = dtDetalle.Columns("DsctoSug").ColumnName
            cTipDoc.DataPropertyName = dtDetalle.Columns("TipDoc").ColumnName
            cListaPrecio.DataPropertyName = dtDetalle.Columns("ListaPrecio").ColumnName
            cProveedor.DataPropertyName = dtDetalle.Columns("Proveedor").ColumnName
            cCosto.DataPropertyName = dtDetalle.Columns("Costo").ColumnName
            cUtilidad.DataPropertyName = dtDetalle.Columns("Utilidad").ColumnName
            cPorcentajeUtilidad.DataPropertyName = dtDetalle.Columns("PorcentajeUtilidad").ColumnName

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub

    Private Sub SumarCosto()
        Dim totCosto As Double = 0
        For Each Fila As DataRow In dtDetalle.Rows
            totCosto = totCosto + Fila.Item("TotalCosto")
        Next
        txtTotalCosto.Value = totCosto
        txtUtilidad.Value = IIf(txtTotalSug.Value > 0, txtTotalSug.Value, txtTotalNeto.Value) - totCosto
    End Sub

    Private Sub SumarTotalNeto()
        Dim totFila As Double = 0
        For Each Fila As DataRow In dtDetalle.Rows
            totFila = totFila + Fila.Item("TotalFila")
        Next
        txtTotalNeto.Value = totFila
        'txtUtilidad.Value = IIf(txtTotalSug.Value > 0, txtTotalSug.Value, txtTotalNeto.Value) - totCosto
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        
        Dim forma As New frmAprobar
        forma.pTipDoc = pTipDoc
        forma.pIdVenta = pIdVenta
        forma.pIdSugerido = pIdSugerido
        forma.pIdCliente = pIdCliente
        forma.ShowDialog()
    End Sub

    Private Sub dgDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            txtNumero.Select()
        End If
    End Sub

    Private Sub dgDetalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub dgDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetalle.DoubleClick
        If oLocacionMercaderiaService.Buscar(IdLocacion, dgDetalle.Item("cCodMer", dgDetalle.CurrentRow.Index).Value) Then
            Dim frm As New frmKardex_Tarjeta
            frm.state_button = True
            frm.IdLocacion = IdLocacion
            frm.txtCodMer.Text = dgDetalle.CurrentRow.Cells(1).Value
            frm.Text = " CONSULTA DE TARJETAS DE INVENTARIO   -   OFICINA: " & Oficina & "  -  ALMACEN: " & Locacion
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Else
            MsgBox("Esta Mercaderia no tiene tarjeta en este almacén")
            Dim frm As New frmKardex_Tarjetas
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        End If

       
    End Sub

    Private Sub dgDetalle_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgDetalle.RowPrePaint
        If dgDetalle.Rows(e.RowIndex).Cells(7).Value <> "0.00" And dgDetalle.Rows(e.RowIndex).Cells(7).Value <> dgDetalle.Rows(e.RowIndex).Cells(4).Value Then
            dgDetalle.Rows(e.RowIndex).Cells(7).Style.BackColor = Color.Yellow
            dgDetalle.Rows(e.RowIndex).Cells(7).Style.ForeColor = Color.Black
        End If

        If dgDetalle.Rows(e.RowIndex).Cells(8).Value <> "0.00" And dgDetalle.Rows(e.RowIndex).Cells(8).Value <> dgDetalle.Rows(e.RowIndex).Cells(5).Value Then
            dgDetalle.Rows(e.RowIndex).Cells(8).Style.BackColor = Color.Yellow
            dgDetalle.Rows(e.RowIndex).Cells(8).Style.ForeColor = Color.Black
        End If

        If dgDetalle.Rows(e.RowIndex).Cells(13).Value <= 0 Then
            dgDetalle.Rows(e.RowIndex).Cells(13).Style.BackColor = Color.IndianRed
            dgDetalle.Rows(e.RowIndex).Cells(13).Style.ForeColor = Color.Black
        End If

    End Sub

    Private Sub miFactor_Dscto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFactor_Dscto.Click
        Dim frm As New frmAprobarFactor_Dscto
        GruAlm = ObjMaestro.MostrarDato("Maestro.Locaciones", "GruAlm", "IdLocacion", IdLocacion)
        frm.IdLocacion = IdLocacion
        frm.GruAlm = GruAlm
        frm.IdCliente = IdCliente
        frm.Cliente = txtCliente.Text
        frm.CodMer = dgDetalle.Item("cCodMer", dgDetalle.CurrentRow.Index).Value
        frm.CodMon = CodMon
        frm.Fecha = Fecha
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

        End If
    End Sub
End Class
