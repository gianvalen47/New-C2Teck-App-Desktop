Imports System.ServiceModel
Public Class frmValorizarFIMasivo

    '===========================Servicios====================================================
    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient

    '======================Declaración de Variables==============================================
    Private dtSeleccionados As DataTable
    Private dtFacturas As DataTable

    Private dtProveedores As DataTable
    Private dtVia As DataTable
    Private dtEstados As DataTable

    Private IdImportacion As Integer
    Private IdSerieDoc As Integer    
    Private IdLocacion As Integer
    Private NumDoc As String
    Private DesAlm As String
    Private FecDoc As Date
    Private IdProveedor As Integer
    Private DesProv As String
    Private CodMon As String
    Private DesMon As String
    Private TipCam As Double
    Private Observacion As String
    Private TotFobGen As Double
    Private TotFobGenSol As Double
    Private TotalNeto As Double
    Private TotalNetoSol As Double
    Private Estado As String
    Private IdProveedorAduana As Integer = 0

    Public pCodPais As String = Nothing
    Public dtDetalles As DataTable
    Public registroImp As New ImportacionService.Importacion

    Private Sub frmValorizarFIMasivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvFacturas.BackgroundColor = Color.Beige
        dgvFacturas.BackColor = Color.Beige
        dgvFacturas.ForeColor = Color.MidnightBlue
        dgvFacturas.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False
       
        LlenarCombos()
        listaSeleccionados()
        dtInicio.Value = Today
        dtFinal.Value = Today
        lblRegistros.Text = "0"
    End Sub

    Private Sub frmValorizarFIMasivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmValorizarFIMasivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oImportacionService.Close()
            oPedidoImportService.Close()
        Catch ex As TimeoutException
            oImportacionService.Abort()
            oPedidoImportService.Abort()
        Catch ex As CommunicationException
            oImportacionService.Abort()
            oPedidoImportService.Abort()
        End Try
    End Sub

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
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try
           
         
            '============================================ VÍA =====================================================
            dtVia = New DataTable
            dtVia.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtVia.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtVia.Rows.Add(New Object() {"1", "Maritima"})
            dtVia.Rows.Add(New Object() {"2", "Aerea"})

            cmbVia.DataSource = dtVia
            cmbVia.DropDownList.DataMember = dtVia.Columns("nombre").ToString
            cmbVia.DropDownList.DisplayMember = dtVia.Columns("nombre").ToString
            cmbVia.DropDownList.ValueMember = dtVia.Columns("nombre").ToString
            cmbVia.DropDownList.Columns(0).DataMember = dtVia.Columns("codigo").ToString
            cmbVia.DropDownList.Columns(1).DataMember = dtVia.Columns("nombre").ToString
            cmbVia.SelectedIndex = 0
            dtVia = Nothing

            '======================================= ESTADOS ================================================
            dtEstados = oImportacionService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cbEstados.DataSource = dtEstados
            cbEstados.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cbEstados.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cbEstados.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cbEstados.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cbEstados.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cbEstados.SelectedIndex = 0
            dtEstados = Nothing


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            '===================================== LISTA FACTURAS ======================================
            dtFacturas = oImportacionService.Filtrar(0, 0, dtInicio.Value, dtFinal.Value, txtNumero.Text, cbEstados.Value, "", txtCodEmbarque.Text).Tables(0)
            dgvFacturas.DataSource = dtFacturas            

            cIdImportacion.DataPropertyName = dtFacturas.Columns("IdImportacion").ColumnName
            cIdSerieDoc.DataPropertyName = dtFacturas.Columns("IdSerieDoc").ColumnName
            cIdLocacion.DataPropertyName = dtFacturas.Columns("IdLocacion").ColumnName
            cNumDoc.DataPropertyName = dtFacturas.Columns("NumDoc").ColumnName
            cDesAlm.DataPropertyName = dtFacturas.Columns("DesAlm").ColumnName
            cFecDoc.DataPropertyName = dtFacturas.Columns("FecDoc").ColumnName
            cIdProveedor.DataPropertyName = dtFacturas.Columns("IdProveedor").ColumnName
            cDesProv.DataPropertyName = dtFacturas.Columns("DesProv").ColumnName
            cCodMon.DataPropertyName = dtFacturas.Columns("CodMon").ColumnName
            cDesMon.DataPropertyName = dtFacturas.Columns("DesMon").ColumnName
            cTipCam.DataPropertyName = dtFacturas.Columns("TipCam").ColumnName
            cObservacion.DataPropertyName = dtFacturas.Columns("Observacion").ColumnName
            cTotFobGen.DataPropertyName = dtFacturas.Columns("TotFobGen").ColumnName
            cTotFobGenSol.DataPropertyName = dtFacturas.Columns("TotFobGenSol").ColumnName
            cTotalNeto.DataPropertyName = dtFacturas.Columns("TotalNeto").ColumnName
            cTotalNetoSol.DataPropertyName = dtFacturas.Columns("TotalNetoSol").ColumnName
            cEstado.DataPropertyName = dtFacturas.Columns("Estado").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaSeleccionados()
        Try

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oImportacionService.Filtrar(0, 0, Nothing, Nothing, "", "0", "", txtCodEmbarque.Text).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdImportacion1.DataPropertyName = dtFacturas.Columns("IdImportacion").ColumnName
            cIdSerieDoc1.DataPropertyName = dtFacturas.Columns("IdSerieDoc").ColumnName
            cIdLocacion1.DataPropertyName = dtFacturas.Columns("IdLocacion").ColumnName
            cNumDoc1.DataPropertyName = dtFacturas.Columns("NumDoc").ColumnName
            cDesAlm1.DataPropertyName = dtFacturas.Columns("DesAlm").ColumnName
            cFecDoc1.DataPropertyName = dtFacturas.Columns("FecDoc").ColumnName
            cIdProveedor1.DataPropertyName = dtFacturas.Columns("IdProveedor").ColumnName
            cDesProv1.DataPropertyName = dtFacturas.Columns("DesProv").ColumnName
            cCodMon1.DataPropertyName = dtFacturas.Columns("CodMon").ColumnName
            cDesMon1.DataPropertyName = dtFacturas.Columns("DesMon").ColumnName
            cTipCam1.DataPropertyName = dtFacturas.Columns("TipCam").ColumnName
            cObservacion1.DataPropertyName = dtFacturas.Columns("Observacion").ColumnName
            cTotFobGen1.DataPropertyName = dtFacturas.Columns("TotFobGen").ColumnName
            cTotFobGenSol1.DataPropertyName = dtFacturas.Columns("TotFobGenSol").ColumnName
            cTotalNeto1.DataPropertyName = dtFacturas.Columns("TotalNeto").ColumnName
            cTotalNetoSol1.DataPropertyName = dtFacturas.Columns("TotalNetoSol").ColumnName
            cEstado1.DataPropertyName = dtFacturas.Columns("Estado").ColumnName

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS SELECCIONADOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvFacturas.RowCount > 0 Then
                btnAgregar.Enabled = True
                btnAgregarTodos.Enabled = True
            Else
                btnAgregar.Enabled = False
                btnAgregarTodos.Enabled = False
            End If

            If dgvSeleccionados.RowCount > 0 Then
                miEliminar.Enabled = True
            Else
                miEliminar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        IdImportacion = dgvFacturas.Rows(dgvFacturas.CurrentRow.Index).Cells("cIdImportacion").Value.ToString
        If ValidaIdImportacion(dgvSeleccionados, IdImportacion) Then
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvFacturas)
            EnableOptions()
        Else
            MsgBox("La factura ya fue seleccionada.", MsgBoxStyle.Exclamation)
        End If
        lblRegistros.Text = dgvSeleccionados.RowCount
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdImportacion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdImportacion").Value.ToString
            IdSerieDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdSerieDoc").Value.ToString
            IdLocacion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdLocacion").Value.ToString
            NumDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNumDoc").Value.ToString            
            DesAlm = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesAlm").Value.ToString
            FecDoc = CDate(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cFecDoc").Value.ToString)
            IdProveedor = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdProveedor").Value.ToString
            DesProv = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesProv").Value.ToString
            CodMon = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cCodMon").Value.ToString
            DesMon = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesMon").Value.ToString
            TipCam = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTipCam").Value.ToString)
            Observacion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cObservacion").Value.ToString
            TotFobGen = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotFobGen").Value.ToString)
            TotFobGenSol = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotFobGenSol").Value.ToString)
            TotalNeto = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotalNeto").Value.ToString)
            TotalNetoSol = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotalNetoSol").Value.ToString)
            Estado = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cEstado").Value.ToString


            dr("IdImportacion") = IdImportacion
            dr("IdLocacion") = IdLocacion
            dr("IdSerieDoc") = IdSerieDoc
            dr("NumDoc") = NumDoc
            dr("DesAlm") = DesAlm
            dr("FecDoc") = FecDoc
            dr("IdProveedor") = IdProveedor
            dr("DesProv") = DesProv
            dr("CodMon") = CodMon
            dr("DesMon") = DesMon
            dr("TipCam") = TipCam
            dr("Observacion") = Observacion
            dr("TotFobGen") = TotFobGen
            dr("TotFobGenSol") = TotFobGenSol
            dr("TotalNeto") = TotalNeto
            dr("TotalNetoSol") = TotalNetoSol
            dr("Estado") = Estado


            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EliminarFila(ByVal dgvDatos As DataGridView)
        dgvDatos.Rows.Remove(dgvDatos.CurrentRow)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtNumero.TextChanged, dtInicio.ValueChanged, dtFinal.ValueChanged, cbEstados.ValueChanged
        listaDatos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) ''Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvSeleccionados.RowCount < 1 Then
                MsgBox("Debe seleccionar al menos una Factura.", MsgBoxStyle.Information, "Información")
                dgvFacturas.Focus()
                Return False
            ElseIf toBlank(txtNumRegistro.Text) = "" Then
                MsgBox("Debe Ingresar el número de registro.", MsgBoxStyle.Information, "Información")
                txtNumRegistro.Focus()
                Return False
            ElseIf cbApliSeguro.Checked = True And toDouble(txtSeguro.Value) = 0 Then
                MsgBox("Debe Ingresar el porcentaje de seguro.", MsgBoxStyle.Information, "Información")
                txtSeguro.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        Dim Cont As Integer = 0
        For i As Integer = 0 To dgvFacturas.RowCount - 1
            IdImportacion = dgvFacturas.Item("cIdImportacion".ToLower, i).Value
            If Not (ValidaIdImportacion(dgvSeleccionados, IdImportacion)) Then
                Cont = Cont + 1
            End If
        Next

        If Cont > 1 Then
            MsgBox("Alguna(s) de las facturas ya han sido seleccionadas.", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            For i As Integer = 0 To dgvFacturas.RowCount - 1
                AgregarFila(dtSeleccionados, dgvSeleccionados, dgvFacturas)
            Next
            EnableOptions()
        End If
        lblRegistros.Text = dgvSeleccionados.RowCount
    End Sub

    Private Function ValidaIdImportacion(ByVal dgvDatos As DataGridView, ByVal IdImportacion As Integer) As Boolean
        Try
            If dgvDatos.RowCount > 0 Then
                Dim cont As Integer = 0
                For i As Integer = 0 To dgvDatos.RowCount - 1
                    If IdImportacion = dgvDatos.Item("cIdImportacion1".ToLower, i).Value Then
                        cont = cont + 1
                    End If
                Next

                If cont > 0 Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al Validar Factura de Importación: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub miEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        EliminarFila(dgvSeleccionados)
    End Sub

    Private Sub cbApliSeguro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbApliSeguro.CheckedChanged
        If cbApliSeguro.Checked = True Then
            txtSeguro.Select()
            txtSeguro.Enabled = True
        End If
        If cbApliSeguro.Checked = False Then
            txtSeguro.Enabled = False
            txtSeguro.Text = 0.0
        End If
    End Sub

    Private Sub btnBuscarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPais.Click
        Dim frm As New frmBuscarPais
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtOrigen.Text = frm.descripcion
            txtOrigen.BackColor = System.Drawing.SystemColors.Control
            pCodPais = frm.codigo
        End If
        txtOrigen.Select()
    End Sub

    Private Sub frmImportacionDet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
              txtNumRegistro.KeyPress _
            , txtAduana.KeyPress _
            , txtTransporte.KeyPress _
            , txtOrigen.KeyPress _
            , txtFactura.KeyPress _
            , cmbVia.KeyPress _
            , txtPtoEmb.KeyPress _
            , txtGuia.KeyPress _
            , txtPoliza.KeyPress _
            , txtTipCambio.KeyPress _
            , txtIgvAdu.KeyPress _
            , txtServicio.KeyPress _
            , cbApliSeguro.KeyPress _
            , txtSeguro.KeyPress _
            , txtCarga.KeyPress _
            , txtTerminal.KeyPress _
            , txtGastoAgencia.KeyPress _
            , txtTranspLocal.KeyPress _
            , txtOtroGastos.KeyPress _
            , txtResguardo.KeyPress _
            , txtHandling.KeyPress _
            , txtTotFleteSol.KeyPress _
            , txtTotOtrosGastos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            'If MsgBox("¿Está seguro de VALORIZAR la(s) Factura(s) seleccionada(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            dgvSeleccionados.Update()
            Dim dtTable As DataTable
            Dim rows As DataRow

            dtTable = dtSeleccionados.Copy
            dtTable.Clear()

            For i As Integer = 0 To dgvSeleccionados.Rows.Count - 1
                Dim row As DataGridViewRow = dgvSeleccionados.Rows(i)

                rows = dtTable.NewRow
                rows(0) = dgvSeleccionados.Rows(i).Cells(0).Value
                rows(1) = dgvSeleccionados.Rows(i).Cells(1).Value
                rows(2) = dgvSeleccionados.Rows(i).Cells(2).Value
                rows(3) = dgvSeleccionados.Rows(i).Cells(3).Value
                rows(4) = dgvSeleccionados.Rows(i).Cells(4).Value
                rows(5) = dgvSeleccionados.Rows(i).Cells(5).Value
                rows(6) = dgvSeleccionados.Rows(i).Cells(6).Value
                rows(7) = dgvSeleccionados.Rows(i).Cells(7).Value
                rows(8) = dgvSeleccionados.Rows(i).Cells(8).Value
                rows(9) = dgvSeleccionados.Rows(i).Cells(9).Value
                rows(10) = dgvSeleccionados.Rows(i).Cells(10).Value
                rows(11) = dgvSeleccionados.Rows(i).Cells(11).Value
                rows(12) = dgvSeleccionados.Rows(i).Cells(12).Value
                rows(13) = dgvSeleccionados.Rows(i).Cells(13).Value
                rows(14) = dgvSeleccionados.Rows(i).Cells(14).Value
                rows(15) = dgvSeleccionados.Rows(i).Cells(15).Value
                rows(16) = dgvSeleccionados.Rows(i).Cells(16).Value

                dtTable.Rows.Add(rows)
            Next

            If dtTable.Rows.Count = 0 Then
                MsgBox("¡Debe seleccionar alguno de las Facturas...!", MsgBoxStyle.Information, "No hay datos")
            Else

                Dim Registro As New ImportacionService.Importacion
                Dim ProveedorAduana As New ImportacionService.Proveedor
                Dim SerieDoc As New ImportacionService.SerieDocumento
                Dim Pais As New ImportacionService.Pais

                Registro.IdImportacion = IdImportacion
                Registro.NroIng = txtNumRegistro.Text

                ProveedorAduana.IdProveedor = IdProveedorAduana
                Registro.ProveedorAgeAdu = ProveedorAduana

                Registro.AgeTra = txtTransporte.Text
                Pais.CodPais = pCodPais
                Registro.Pais = Pais
                Registro.FacAdu = txtFactura.Text
                Registro.Medio = cmbVia.Text
                Registro.PtoEmbarque = txtPtoEmb.Text
                Registro.Poliza = txtPoliza.Text
                Registro.TipCam = txtTipCambio.Text
                Registro.ApliSeguro = cbApliSeguro.Checked
                Registro.Guia = txtGuia.Text
                Registro.PorApliSeguro = txtSeguro.Value
                Registro.IgvAdu = txtIgvAdu.Value
                Registro.Servicio = txtServicio.Value
                Registro.CarDes = txtCarga.Value
                Registro.TerAlm = txtTerminal.Value
                Registro.GasAdu = txtGastoAgencia.Value
                Registro.TraLoc = txtTranspLocal.Value
                Registro.OtroGasto = txtOtroGastos.Value
                Registro.Resguardo = txtResguardo.Value
                Registro.Handling = txtHandling.Value
                Registro.TotOtroGasto = txtTotOtrosGastos.Value
                Registro.TotFlete = txtTotFleteSol.Value
                Registro.CodUsu = Session.sCodUsu

                dtDetalles = dtTable
                registroImp = Registro

                Dim frm As New frmValorizarFIDatos
                frm.dtDetalles = dtDetalles
                frm.RegistroImp = registroImp

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If
            End If
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL VALORIZAR FACTURAS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarProveedor_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedorAduana = frm.codigo
                    txtAduana.Text = frm.descripcion
                    'cmbCondPago.Focus()
                Else
                    IdProveedorAduana = 0
                    txtAduana.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class