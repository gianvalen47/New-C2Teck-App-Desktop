Imports System.ServiceModel
Public Class frmAlmacen_FacturaImportacion_ImpMas

    '===========================Servicios====================================================
    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtSeleccionados As DataTable
    Private dtFacturas As DataTable

    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable

    Private IdImportacion As Integer
    Private IdLocacion As Integer
    Private NumDoc As String    
    Private FecDoc As Date    
    Private DesProv As String    
    Private TotalNeto As Double    
    Private Estado As String


    Private Sub frmAlmacen_FacturaImportacion_ImpMas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        txtFecha.Value = Today
        lblRegistros.Text = "0"
    End Sub

    Private Sub frmAlmacen_FacturaImportacion_ImpMas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmAlmacen_FacturaImportacion_ImpMas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oImportacionService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oImportacionService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oImportacionService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
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

            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oImportacionService.MostrarLocacionImportacion(Session.sCodEmp, cmbOficinas.Value).Tables(0) 'oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
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

    Private Sub listaDatos()
        Try

            '===================================== LISTA FACTURAS ======================================
            dtFacturas = oImportacionService.Filtrar(IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value), 0, txtFecha.Value, txtFecha.Value, "", "", "", txtCodEmbarque.Text).Tables(0)
            dgvFacturas.DataSource = dtFacturas
            cIdImportacion.DataPropertyName = dtFacturas.Columns("IdImportacion").ColumnName
            cIdLocacion.DataPropertyName = dtFacturas.Columns("IdLocacion").ColumnName
            cNumDoc.DataPropertyName = dtFacturas.Columns("NumDoc").ColumnName
            cFecDoc.DataPropertyName = dtFacturas.Columns("FecDoc").ColumnName
            cDesProv.DataPropertyName = dtFacturas.Columns("DesProv").ColumnName            
            cTotalNeto.DataPropertyName = dtFacturas.Columns("TotalNeto").ColumnName            
            cEstado.DataPropertyName = dtFacturas.Columns("Estado").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaSeleccionados()
        Try

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oImportacionService.Filtrar(0, 0, Nothing, Nothing, "", "0", "", "").Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdImportacion1.DataPropertyName = dtFacturas.Columns("IdImportacion").ColumnName
            cIdLocacion1.DataPropertyName = dtFacturas.Columns("IdLocacion").ColumnName
            cNumDoc1.DataPropertyName = dtFacturas.Columns("NumDoc").ColumnName
            cFecDoc1.DataPropertyName = dtFacturas.Columns("FecDoc").ColumnName
            cDesProv1.DataPropertyName = dtFacturas.Columns("DesProv").ColumnName
            cTotalNeto1.DataPropertyName = dtFacturas.Columns("TotalNeto").ColumnName            
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
            IdLocacion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdLocacion").Value.ToString
            NumDoc = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNumDoc").Value.ToString
            FecDoc = CDate(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cFecDoc").Value.ToString)
            DesProv = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesProv").Value.ToString
            TotalNeto = toDouble(dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cTotalNeto").Value.ToString)
            Estado = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cEstado").Value.ToString

            dr("IdImportacion") = IdImportacion
            dr("IdLocacion") = IdLocacion
            dr("NumDoc") = NumDoc
            dr("FecDoc") = FecDoc
            dr("DesProv") = DesProv            
            dr("TotalNeto") = TotalNeto            
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

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbIdLocacion.ValueChanged, txtFecha.ValueChanged, txtCodEmbarque.TextChanged
        listaDatos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
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

    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Try
            If MsgBox("¿Está seguro de IMPRIMIR la(s) Factura(s) seleccionada(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    If rbConformidad.Checked = True Then

                        Dim dtTable As New DataTable
                        Dim rows As DataRow

                        Dim forma As New frmReportes
                        Dim dtReporte As New DataTable
                        Dim reporte As New rpConformidadImportacionMas

                        dtReporte = oImportacionService.ImprimirConformidad(0, "", 0).Tables(0)

                        For j As Integer = 0 To dgvSeleccionados.RowCount - 1

                            dtTable = oImportacionService.ImprimirConformidad(toBlank(dgvSeleccionados.Item("cIdImportacion1".ToLower, j).Value), toBlank(dgvSeleccionados.Item("cNumDoc1".ToLower, j).Value), toNumber(dgvSeleccionados.Item("cIdLocacion1".ToLower, j).Value)).Tables(0)

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

                                dtReporte.Rows.Add(rows)
                            Next

                        Next
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Conformidad de F/I"
                        forma.ShowDialog()


                    ElseIf rbListadoGeneral.Checked = True Then
                        '========== Ordenado por Factura ==========
                        If rbPorNumFactura.Checked = True Then
                            Dim dtTable As New DataTable
                            Dim rows As DataRow

                            Dim forma As New frmReportes
                            Dim dtReporte As New DataTable
                            Dim reporte As New rpChequeoImportacionImpMas_Factura

                            dtReporte = oImportacionService.ImprimirChequeo(0, "", 0, Nothing, Nothing, "", "").Tables(0)

                            For j As Integer = 0 To dgvSeleccionados.RowCount - 1

                                dtTable = oImportacionService.ImprimirChequeo(toBlank(dgvSeleccionados.Item("cIdImportacion1".ToLower, j).Value), toBlank(dgvSeleccionados.Item("cNumDoc1".ToLower, j).Value), toNumber(dgvSeleccionados.Item("cIdLocacion1".ToLower, j).Value), Nothing, Nothing, "", "").Tables(0)

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

                                    dtReporte.Rows.Add(rows)
                                Next

                            Next

                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                            forma.Text = "Reporte de Chequeo de Importacion"
                            forma.ShowDialog()

                            '========== Ordenado por Código ==========
                        ElseIf rbPorCodigo.Checked = True Then
                            Dim dtTable As New DataTable
                            Dim rows As DataRow

                            Dim forma As New frmReportes
                            Dim dtReporte As New DataTable
                            Dim reporte As New rpChequeoImportacionImpMas_Codigo

                            dtReporte = oImportacionService.ImprimirChequeo(0, "", 0, Nothing, Nothing, "", "").Tables(0)

                            For j As Integer = 0 To dgvSeleccionados.RowCount - 1

                                dtTable = oImportacionService.ImprimirChequeo(toBlank(dgvSeleccionados.Item("cIdImportacion1".ToLower, j).Value), toBlank(dgvSeleccionados.Item("cNumDoc1".ToLower, j).Value), toNumber(dgvSeleccionados.Item("cIdLocacion1".ToLower, j).Value), Nothing, Nothing, "", "").Tables(0)

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

                                    dtReporte.Rows.Add(rows)
                                Next

                            Next

                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            reporte.SetParameterValue("Stock", IIf(rbDisponible.Checked = True, "d", "s"))
                            forma.Text = "Reporte de Chequeo de Importacion"
                            forma.ShowDialog()
                        End If

                    End If
                   
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Imprimir Facturas de Importación: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub rbListadoGeneral_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbListadoGeneral.CheckedChanged, rbConformidad.CheckedChanged
        If rbListadoGeneral.Checked = True Then
            gbMostrarStock.Enabled = True
        ElseIf rbConformidad.Checked = True Then
            gbMostrarStock.Enabled = False
        End If
    End Sub
End Class