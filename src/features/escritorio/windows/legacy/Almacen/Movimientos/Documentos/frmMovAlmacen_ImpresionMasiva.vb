Imports System.ServiceModel

Public Class frmMovAlmacenImpMasiva

    Private oMaestroService As New MaestroService.MaestroClient
    Private oMoviAlmacenService As New MoviAlmacenService.MoviAlmacenServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer

    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtTipoDocumentos As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable
    Private dtFacturas As DataTable
    Private dtSeleccionados As DataTable

    Private IdMovimiento As Integer
    Private IdLocacion As Integer
    Private IdDocumento As Integer
    Private Nombre As String
    Private AbrDoc As String
    Private IdSerieDoc As Integer
    Private NumDoc As Integer
    Private FecDoc As Date
    Private NumJob As String
    Private DesCli As String
    Private CodMon As String
    Private TotNeto As Double
    Private NumFac As Integer
    Private Estado As String

    Private Sub frmMovAlmacenImpMasiva_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMoviAlmacenService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMoviAlmacenService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMoviAlmacenService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmMovAlmacenImpMasiva_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmMovAlmacenImpMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        txtanio.Value = Today.Year
        'txtFecha.Value = Today
        lblRegistros.Text = "0"
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            fila(2) = "(Todos)"
        End Try

        Return fila
    End Function

    Private Sub cmbOficinas_ValueChanged(sender As Object, e As EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================

            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
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
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub

    Private Sub listaSeleccionados()
        Try
            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oMoviAlmacenService.Filtrar(txtanio.Value, cmbMes.Value, IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), 0, toNumber(IdCliente), "TR", 10).Tables(0)   '10 para llenar la grilla vacia
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdMovimiento1.DataPropertyName = dtFacturas.Columns("IdMovimiento").ColumnName
            cIdLocacion1.DataPropertyName = dtFacturas.Columns("IdLocacion").ColumnName
            cIdDocumento1.DataPropertyName = dtFacturas.Columns("IdDocumento").ColumnName
            cNombre1.DataPropertyName = dtFacturas.Columns("Nombre").ColumnName
            cAbrDoc1.DataPropertyName = dtFacturas.Columns("AbrDoc").ColumnName
            cIdSerieDoc1.DataPropertyName = dtFacturas.Columns("IdSerieDoc").ColumnName
            cNumDoc1.DataPropertyName = dtFacturas.Columns("NumDoc").ColumnName
            cFecDoc1.DataPropertyName = dtFacturas.Columns("FecDoc").ColumnName
            cNumJob1.DataPropertyName = dtFacturas.Columns("NumJob").ColumnName
            cDesCli1.DataPropertyName = dtFacturas.Columns("DesCli").ColumnName
            cCodMon1.DataPropertyName = dtFacturas.Columns("CodMon").ColumnName
            cTotNeto1.DataPropertyName = dtFacturas.Columns("TotNeto").ColumnName
            cNumFac1.DataPropertyName = dtFacturas.Columns("NumFac").ColumnName
            cEstado1.DataPropertyName = dtFacturas.Columns("Estado").ColumnName

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS SELECCIONADOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, txtanio.TextChanged, cmbMes.ValueChanged, cmbIdLocacion.ValueChanged
        listaDatos
    End Sub

    Private Sub listaDatos()
        Try

            dtFacturas = oMoviAlmacenService.Filtrar(txtanio.Value, cmbMes.Value, IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), 0, toNumber(IdCliente), "TR", 0).Tables(0)

            ''===================================== LISTA FACTURAS ======================================
            'dtFacturas = oMoviAlmacenService.ReportePendientes(Session.sCodEmp, 0).Tables(0)
            dgvFacturas.DataSource = dtFacturas
            cIdMovimiento.DataPropertyName = dtFacturas.Columns("IdMovimiento").ColumnName
            cIdLocacion.DataPropertyName = dtFacturas.Columns("IdLocacion").ColumnName
            cIdDocumento.DataPropertyName = dtFacturas.Columns("IdDocumento").ColumnName
            cNombre.DataPropertyName = dtFacturas.Columns("Nombre").ColumnName
            cAbrDoc.DataPropertyName = dtFacturas.Columns("AbrDoc").ColumnName
            cIdSerieDoc.DataPropertyName = dtFacturas.Columns("IdSerieDoc").ColumnName
            cNumDoc.DataPropertyName = dtFacturas.Columns("NumDoc").ColumnName
            cFecDoc.DataPropertyName = dtFacturas.Columns("FecDoc").ColumnName
            cNumJob.DataPropertyName = dtFacturas.Columns("NumJob").ColumnName
            cDesCli.DataPropertyName = dtFacturas.Columns("DesCli").ColumnName
            cCodMon.DataPropertyName = dtFacturas.Columns("CodMon").ColumnName
            cTotNeto.DataPropertyName = dtFacturas.Columns("TotNeto").ColumnName
            cNumFac.DataPropertyName = dtFacturas.Columns("NumFac").ColumnName
            cEstado.DataPropertyName = dtFacturas.Columns("Estado").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'NumDoc = dgvFacturas.Rows(dgvFacturas.CurrentRow.Index).Cells("cNumDoc").Value.ToString
        'If ValidaIdImportacion(dgvSeleccionados, NumDoc) Then
        AgregarFila(dtSeleccionados, dgvSeleccionados, dgvFacturas)
            EnableOptions()
        'Else
        '    MsgBox("La factura ya fue seleccionada.", MsgBoxStyle.Exclamation)
        'End If
        lblRegistros.Text = dgvSeleccionados.RowCount
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdMovimiento = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdMovimiento").Value.ToString
            IdLocacion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdLocacion").Value.ToString
            IdDocumento = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdDocumento").Value.ToString
            Nombre = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNombre").Value.ToString
            AbrDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cAbrDoc").Value.ToString
            IdSerieDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdSerieDoc").Value.ToString
            NumDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNumDoc").Value.ToString
            FecDoc = CDate(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cFecDoc").Value.ToString)
            NumJob = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNumJob").Value.ToString
            DesCli = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesCli").Value.ToString
            CodMon = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cCodMon").Value.ToString
            TotNeto = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotNeto").Value.ToString)
            NumFac = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNumFac").Value.ToString
            Estado = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cEstado").Value.ToString

            dr("IdMovimiento") = IdMovimiento
            dr("IdLocacion") = IdLocacion
            dr("IdDocumento") = IdDocumento
            dr("Nombre") = Nombre
            dr("AbrDoc") = AbrDoc
            dr("IdSerieDoc") = IdSerieDoc
            dr("NumDoc") = NumDoc
            dr("FecDoc") = FecDoc
            dr("NumJob") = NumJob
            dr("DesCli") = DesCli
            dr("CodMon") = CodMon
            dr("TotNeto") = TotNeto
            dr("NumFac") = NumFac
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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvSeleccionados.RowCount < 1 Then
                MsgBox("Debe seleccionar al menos una Factura.", MsgBoxStyle.Information, "Información")
                dgvFacturas.Focus()
                Return False
                'ElseIf toBlank(txtNumRegistro.Text) = "" Then
                '    MsgBox("Debe Ingresar el número de registro.", MsgBoxStyle.Information, "Información")
                '    txtNumRegistro.Focus()
                '    Return False
                'ElseIf cbApliSeguro.Checked = True And toDouble(txtSeguro.Value) = 0 Then
                '    MsgBox("Debe Ingresar el porcentaje de seguro.", MsgBoxStyle.Information, "Información")
                '    txtSeguro.Focus()
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        '    Dim Cont As Integer = 0
        '    For i As Integer = 0 To dgvFacturas.RowCount - 1
        '        IdImportacion = dgvFacturas.Item("cIdImportacion".ToLower, i).Value
        '        If Not (ValidaIdImportacion(dgvSeleccionados, IdImportacion)) Then
        '            Cont = Cont + 1
        '        End If
        '    Next

        '    If Cont > 1 Then
        '        MsgBox("Alguna(s) de las facturas ya han sido seleccionadas.", MsgBoxStyle.Exclamation, "Error de Datos")
        '    Else
        For i As Integer = 0 To dgvFacturas.RowCount - 1
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvFacturas)
        Next
        EnableOptions()
        'End If
        lblRegistros.Text = dgvSeleccionados.RowCount
    End Sub

    Private Sub miEliminar_Click(sender As Object, e As EventArgs) Handles miEliminar.Click
        EliminarFila(dgvSeleccionados)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If MsgBox("¿Está seguro de IMPRIMIR la(s) Factura(s) seleccionada(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim dtTable As New DataTable
                    Dim dtDataView As New DataView
                    Dim rows As DataRow

                    Dim forma As New frmReportes
                    Dim dtReporte As New DataTable
                    Dim reporteMovAlmacenOC As New rptMovAlmacenOrdenCompra
                    Dim reporteMovAlmacenFac As New rptMovAlmacenNumDoc
                    Dim reporte As New rptMovAlmacenOrdenCompraNoAgrupado

                    dtReporte = oMoviAlmacenService.Imprimir(0).Tables(0)

                    For j As Integer = 0 To dgvSeleccionados.RowCount - 1

                        dtTable = oMoviAlmacenService.Imprimir(toNumber(dgvSeleccionados.Item("cIdMovimiento1".ToLower, j).Value)).Tables(0)

                        For i As Integer = 0 To dtTable.Rows.Count - 1

                            rows = dtReporte.NewRow
                            rows(0) = dtTable.Rows(i).Item(0)
                            rows(1) = dtTable.Rows(i).Item(1)
                            rows(2) = dtTable.Rows(i).Item(2)
                            rows(3) = dtTable.Rows(i).Item(3)
                            rows(4) = dtTable.Rows(i).Item(4)
                            rows(5) = dtTable.Rows(i).Item(5)
                            rows(6) = dtTable.Rows(i).Item(6)
                            rows(7) = dtTable.Rows(i).Item(7)
                            rows(8) = dtTable.Rows(i).Item(8)
                            rows(9) = dtTable.Rows(i).Item(9)
                            rows(10) = dtTable.Rows(i).Item(10)
                            rows(11) = dtTable.Rows(i).Item(11)
                            rows(12) = dtTable.Rows(i).Item(12)
                            rows(13) = dtTable.Rows(i).Item(13)
                            rows(14) = dtTable.Rows(i).Item(14)
                            rows(15) = dtTable.Rows(i).Item(15)
                            rows(16) = dtTable.Rows(i).Item(16)
                            rows(17) = dtTable.Rows(i).Item(17)
                            rows(18) = dtTable.Rows(i).Item(18)
                            rows(19) = dtTable.Rows(i).Item(19)
                            rows(20) = dtTable.Rows(i).Item(20)
                            rows(21) = dtTable.Rows(i).Item(21)
                            rows(22) = dtTable.Rows(i).Item(22)
                            rows(23) = dtTable.Rows(i).Item(23)
                            rows(24) = dtTable.Rows(i).Item(24)
                            rows(25) = dtTable.Rows(i).Item(25)
                            rows(26) = dtTable.Rows(i).Item(26)
                            rows(27) = dtTable.Rows(i).Item(27)
                            rows(28) = dtTable.Rows(i).Item(28)
                            rows(29) = dtTable.Rows(i).Item(29)
                            rows(30) = dtTable.Rows(i).Item(30)
                            rows(31) = dtTable.Rows(i).Item(31)
                            rows(32) = dtTable.Rows(i).Item(32)
                            rows(33) = dtTable.Rows(i).Item(33)
                            rows(34) = dtTable.Rows(i).Item(34)
                            rows(35) = dtTable.Rows(i).Item(35)


                            dtReporte.Rows.Add(rows)
                        Next

                    Next

                    dtDataView = ConvertToDataView(dtReporte)

                    If rbPorCodigo.Checked Then

                        dtDataView.Sort = "CodMer Asc"

                        reporte.SetDataSource(dtDataView)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Chequeo de Mov. Almacen"
                        forma.ShowDialog()

                    ElseIf rbPorDestino.Checked Then

                        dtDataView.Sort = "Observacion Asc"

                        reporte.SetDataSource(dtDataView)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Chequeo de Mov. Almacen"
                        forma.ShowDialog()

                    ElseIf rbPorUbicacion.Checked Then

                        dtDataView.Sort = "UbiMer Asc"

                        reporte.SetDataSource(dtDataView)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Chequeo de Mov. Almacen"
                        forma.ShowDialog()

                    ElseIf rbPorOrdenCompra.Checked Then

                        dtDataView.Sort = "CodMer Asc"

                        reporteMovAlmacenOC.SetDataSource(dtDataView)
                        forma.crvReportes.ReportSource = reporteMovAlmacenOC

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Chequeo de Mov. Almacen"
                        forma.ShowDialog()
                    ElseIf rbPorFactura.Checked Then

                        dtDataView.Sort = "CodMer Asc"

                        reporteMovAlmacenFac.SetDataSource(dtDataView)
                        forma.crvReportes.ReportSource = reporteMovAlmacenFac

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Chequeo de Mov. Almacen"
                        forma.ShowDialog()
                    End If

                    'reporte.SetDataSource(dtReporte)
                    'forma.crvReportes.ReportSource = reporte
                    'forma.Text = "Reporte de Chequeo de Mov. Almacen"
                    'forma.ShowDialog()


                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir Movimientos de Almacen: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ConvertToDataView(ByVal dt As DataTable) As DataView
        Dim dv As DataView = New DataView(dt)
        Return dv
    End Function

End Class