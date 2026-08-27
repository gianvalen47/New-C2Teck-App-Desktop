'Imports System.ServiceModel
Public Class frmAprobacion
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjDocumento As New AprobarVentaService.AprobarVentaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtOficina As New DataTable
    Private dtAlmacen As New DataTable
    Private dtDocumento As New DataTable
    Private dtVentas As New DataTable

    Private Sub frmAprobacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjDocumento) = False Then
                ObjDocumento.Close()
            End If
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub dgDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgDocumentos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.KeyCode = Keys.Enter Then
                If dgDocumentos.RowCount > 0 Then
                    btnMostrar_Click(sender, e)
                    e.Handled = True
                End If
            ElseIf e.KeyCode = Keys.Delete Then
                txtNumero.Select()
            End If
        End If
    End Sub

    Private Sub frmAprobacion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
  
    Private Sub RowPossesion(ByVal lista As DataGridView, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstDisplayedScrollingRowIndex = dtVentas.DefaultView.Find(codigo)
            lista.Rows(dtVentas.DefaultView.Find(codigo)).Selected = True
            lista.CurrentCell = lista.Rows(dtVentas.DefaultView.Find(codigo)).Cells(1)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub frmAprobacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 39)
        '/*************************************************************************************/

        'Dim estilo As New Estilo
        'estilo.CargaEstiloGrid(dgDocumentos)
        Dim estilo As New Estilo
        estilo.cargaEstiloDataDrid(dgDocumentos)
        LlenarCombos()
        LlenarGrilla()
        txtNumero.Select()
        'dgDocumentos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]
    End Sub

    Private Sub LlenarCombos()
        Try
            dtOficina = ObjMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            'Dim row As DataRow = dtOficina.NewRow
            'row(0) = ""
            'row(1) = "(Todos)"
            'dtOficina.Rows.InsertAt(row, 0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing

            dtDocumento = ObjDocumento.MostrarTipoDocumento.Tables(0)
            Dim rowd As DataRow = dtDocumento.NewRow
            rowd(0) = 0
            rowd(1) = "(Todos)"
            dtDocumento.Rows.InsertAt(rowd, 0)
            cbDocumento.DataSource = dtDocumento
            cbDocumento.DisplayMember = "Nombre"
            cbDocumento.ValueMember = "IdDocumento"
            cbDocumento.DropDownList.Columns(0).DataMember = "IdDocumento"
            cbDocumento.DropDownList.Columns(1).DataMember = "Nombre"
            cbDocumento.SelectedIndex = 0
            dtDocumento = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try

    End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
        Dim row As DataRow = dtAlmacen.NewRow
        row(0) = 0
        row("DesAlm") = "(Todos)"
        dtAlmacen.Rows.InsertAt(row, 0)
        cbAlmacen.DataSource = dtAlmacen
        cbAlmacen.DisplayMember = "DesAlm"
        cbAlmacen.ValueMember = "IdLocacion"
        cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
        cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
        cbAlmacen.SelectedIndex = 0
        dtAlmacen = Nothing
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click, cmAprobar.Click
        If dtVentas.Rows.Count > 0 Then
            Dim forma As New frmAprobar
            forma.pTipDoc = dgDocumentos.Item("cTipDoc", dgDocumentos.CurrentRow.Index).Value
            forma.pIdVenta = dgDocumentos.CurrentRow.Cells(0).Value
            forma.pIdSugerido = dgDocumentos.CurrentRow.Cells(9).Value
            forma.pIdCliente = dgDocumentos.CurrentRow.Cells(10).Value
            forma.txtCondicion.Select()
            If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                LlenarGrilla()
            End If
        Else
            MsgBox("No hay nada que Aprobar", MsgBoxStyle.Information, "Lista Vacia")
        End If
    End Sub

    Public Sub LlenarGrilla()
        Try
            dtVentas = ObjDocumento.Filtrar(Session.sCodEmp, cbAlmacen.Value, cbDocumento.Value, IIf(Trim(txtNumero.Text) = "", 0, txtNumero.Text)).Tables(0)
            If dtVentas.Rows.Count > 0 Then
                System.Media.SystemSounds.Asterisk.Play()
                btnAprobar.Enabled = True
                btnMostrar.Enabled = True
                btnImprimir.Enabled = True
                cmAprobar.Enabled = True
                cmMostrar.Enabled = True
                cmImprimir.Enabled = True
            Else
                btnAprobar.Enabled = False
                btnMostrar.Enabled = False
                btnImprimir.Enabled = False
                cmAprobar.Enabled = False
                cmMostrar.Enabled = False
                cmImprimir.Enabled = False
            End If
            'Me.dgDocumentos.SetDataBinding(dtVentas, 0)
            dgDocumentos.DataSource = dtVentas
            cIdVenta.DataPropertyName = dtVentas.Columns("IdVenta").ColumnName
            cDocumento.DataPropertyName = dtVentas.Columns("Documento").ColumnName
            cFecDoc.DataPropertyName = dtVentas.Columns("FecDoc").ColumnName
            cDesCli.DataPropertyName = dtVentas.Columns("DesCli").ColumnName
            cCodMon.DataPropertyName = dtVentas.Columns("CodMon").ColumnName
            cTotNeto.DataPropertyName = dtVentas.Columns("TotNeto").ColumnName
            cTotNetoSug.DataPropertyName = dtVentas.Columns("TotNetoSug").ColumnName
            cEstado.DataPropertyName = dtVentas.Columns("Estado").ColumnName
            cTipDoc.DataPropertyName = dtVentas.Columns("TipDoc").ColumnName
            cIdSugerido.DataPropertyName = dtVentas.Columns("IdSugerido").ColumnName
            cIdCliente.DataPropertyName = dtVentas.Columns("IdCliente").ColumnName

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cbAlmacen.ValueChanged, cbDocumento.ValueChanged, txtNumero.TextChanged
        LlenarGrilla()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click, cmMostrar.Click
        If dtVentas.Rows.Count = 0 Then
            MsgBox("No hay nada que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmAprobacionDetalle
            forma.pTipDoc = dgDocumentos.Item("cTipDoc", dgDocumentos.CurrentRow.Index).Value    'dgDocumentos.CurrentRow.Cells(8).Text
            forma.pIdVenta = dgDocumentos.Item("cIdVenta", dgDocumentos.CurrentRow.Index).Value
            forma.pIdSugerido = dgDocumentos.Item("cIdSugerido", dgDocumentos.CurrentRow.Index).Value
            forma.pIdCliente = dgDocumentos.CurrentRow.Cells(10).Value
            forma.ShowDialog()
        End If
    End Sub

    Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click, cmActualizar.Click
        LlenarGrilla()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim codigo As String = ""
            If dgDocumentos.RowCount > 0 Then
                codigo = dgDocumentos.Item("cDocumento", dgDocumentos.CurrentRow.Index).Value
            End If
            dtVentas = Nothing
            LlenarGrilla()
            If dgDocumentos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgDocumentos, dtVentas, "Documento", codigo)
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgDocumentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub dgDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDocumentos.DoubleClick
        btnMostrar_Click(sender, e)
    End Sub

    Private Sub dgDocumentos_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgDocumentos.RowPrePaint
        If dgDocumentos.Rows(e.RowIndex).Cells(6).Value <> "0.00" Then
            dgDocumentos.Rows(e.RowIndex).Cells(6).Style.BackColor = Color.IndianRed
            dgDocumentos.Rows(e.RowIndex).Cells(6).Style.ForeColor = Color.Black
        End If
    End Sub

    Private Sub dgDocumentos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDocumentos.CellContentClick

    End Sub
End Class