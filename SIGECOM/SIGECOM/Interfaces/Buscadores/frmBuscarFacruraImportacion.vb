Imports System.Windows.Forms

Public Class frmBuscarFacruraImportacion

    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private dtClientes As DataTable

    Public codigo As String
    Public numero As String
    Public IdClienteSold As Int64
    Public DesCliSold As String
    Public IdProveedor As Int64
    Public DesProv As String
    Public IdSerieImp As Int64

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                  cmbIdClienteSold.KeyPress _
                , txtFecIni.KeyPress _
                , txtFecFin.KeyPress _
                , txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            If dgvDatos.RowCount > 0 Then
                dgvDatos.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          cmbIdClienteSold.KeyPress _
                        , txtFecIni.KeyPress _
                        , txtFecFin.KeyPress _
                        , txtNumDoc.KeyPress _
                        , btnBuscar.KeyPress _
                        , dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmBuscarFacruraImportacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        state_Search = False
        llenarCombos()
        txtFecIni.Text = txtFecIni.Value.AddDays(-1 * (txtFecIni.Value.Day - 1))
        txtFecFin.Text = Today
        state_Search = True
        listaDatos()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oFacturaImportService.Close()
            oMaestroService.Close()
            oClienteService.Close()
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionar.Enabled = False
        Else
            miSeleccionar.Enabled = True
        End If
    End Sub
    'Private Function getRowTodos(ByVal data As DataTable)
    '    Dim fila As DataRow = data.NewRow
    '    Try
    '        fila(0) = ""
    '    Catch ex As Exception
    '        fila(0) = 0
    '    End Try
    '    Try
    '        fila(1) = "(Todos)"
    '    Catch ex As Exception
    '    End Try

    '    Try
    '        fila(6) = "(Todos)"
    '    Catch ex As Exception

    '    End Try

    '    Return fila
    'End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub Seleccionar()
        Try
            codigo = dgvDatos.CurrentRow.Cells("IdFactura").Text
            numero = dgvDatos.CurrentRow.Cells("NumDoc").Text
            IdClienteSold = dgvDatos.CurrentRow.Cells("IdClienteSold").Text
            DesCliSold = dgvDatos.CurrentRow.Cells("DesCliSold").Text
            IdProveedor = dgvDatos.CurrentRow.Cells("IdProveedor").Text
            DesProv = dgvDatos.CurrentRow.Cells("DesProv").Text
            IdSerieImp = dgvDatos.CurrentRow.Cells("IdSerieImp").Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                Dim registro As New FacturaImportService.FacturaImport
                Dim serieImp As New FacturaImportService.SerieImportacion
                Dim clienteSold As New FacturaImportService.Cliente
                Dim clienteShip As New FacturaImportService.Cliente

                serieImp.IdSerieImp = 1     'facturas de importacion
                registro.SerieImportacion = serieImp
                clienteSold.IdCliente = IIf(cmbIdClienteSold.SelectedIndex = 0, 0, toNumber(cmbIdClienteSold.Value))
                registro.ClienteSold = clienteSold
                registro.NumDoc = txtNumDoc.Text
                If toNull(txtFecIni.Text) <> Nothing Then
                    registro.FecIni = txtFecIni.Text
                End If
                If toNull(txtFecFin.Text) <> Nothing Then
                    registro.FecFin = txtFecFin.Text
                End If

                dtDatos = oFacturaImportService.Filtrar(registro, "").Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(5) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(6) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try
            '======================================= CLIENTES ================================================
            dtClientes = oClienteService.Filtrar(Session.sCodEmp, New ClienteService.Cliente).Tables(0)
            dtClientes.Rows.InsertAt(getRowTodos(dtClientes), 0)
            cmbIdClienteSold.DataSource = dtClientes
            cmbIdClienteSold.DropDownList.DataMember = dtClientes.Columns("DesCli").ToString
            cmbIdClienteSold.DropDownList.DisplayMember = dtClientes.Columns("DesCli").ToString
            cmbIdClienteSold.DropDownList.ValueMember = dtClientes.Columns("IdCliente").ToString
            cmbIdClienteSold.DropDownList.Columns(0).DataMember = dtClientes.Columns("IdCliente").ToString
            cmbIdClienteSold.DropDownList.Columns(1).DataMember = dtClientes.Columns("DesCli").ToString

            'Dim row As DataRow = dtClientes.NewRow
            'row(1) = 0
            'row(6) = "(Todos)"
            'dtClientes.Rows.InsertAt(row, 0)
            cmbIdClienteSold.SelectedIndex = 0
            dtClientes = Nothing
        Catch ex As Exception
            MsgBox("ERROR [BUSC-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtNumDoc.TextChanged, txtFecFin.TextChanged, txtFecIni.TextChanged, cmbIdClienteSold.ValueChanged
        listaDatos()
    End Sub
    Private Sub miSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdFactura").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "IdFactura", codigo)
        End If
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdClienteSold.ValueChanged
        listaDatos()
    End Sub
    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        codigo = Nothing
        numero = ""
        IdClienteSold = 0
        DesCliSold = ""
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub txtFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecIni.ValueChanged, txtFecFin.ValueChanged
        listaDatos()
    End Sub
End Class
