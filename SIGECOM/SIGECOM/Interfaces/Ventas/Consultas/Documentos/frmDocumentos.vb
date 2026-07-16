Imports System.Windows.Forms

Public Class frmDocumentos

    Private oMaestroService As New MaestroService.MaestroClient
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    'Public IdSerieImp As String
    Private dtDocumentos As DataTable
    Private dtClientes As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbIdSerieImp.KeyPress _
                      , txtFecIni.KeyPress _
                      , txtFecFin.KeyPress _
                      , txtIdCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown

        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
                e.Handled = True
            End If
        End If

    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbIdSerieImp.KeyPress _
                      , txtIdCliente.KeyPress _
                      , txtFecIni.KeyPress _
                      , txtFecFin.KeyPress _
                      , btnBuscar.KeyPress _
                      , dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
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
    Private Sub frmDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        state_Search = False
        llenarCombos()
        IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        state_Search = True
        listaDatos()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oFacturaImportService) = False Then
                oFacturaImportService.Close()
            End If
            If isClosed(oClienteService) = False Then
                oClienteService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal codigoCampo As String, ByVal documento As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbIdSerieImp.Value = toNumber(documento)
            IdCliente = 0
            txtIdCliente.Text = "(Todos)"
            txtFecIni.Text = ""
            txtFecFin.Text = ""
            txtNumDoc.Text = codigoCampo
        End If
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miGenerarDocumento.Enabled = False
            miImprimir.Enabled = False

            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biGenerarDocumento.Enabled = False
            biImprimir.Enabled = False

        Else
            Dim lestado As String
            Dim ltotal As Decimal
            lestado = dgvDatos.CurrentRow.Cells("Estado").Text
            ltotal = dgvDatos.CurrentRow.Cells("TotalNeto").Text

            biEliminar.Enabled = IIf(lestado = "PR" Or lestado = "PROCESADO", False, True)
            biGenerarDocumento.Enabled = IIf(lestado = "PR" Or lestado = "PROCESADO" Or ltotal = 0, False, True)
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            miEliminar.Enabled = IIf(lestado = "PR" Or lestado = "PROCESADO", False, True)
            miGenerarDocumento.Enabled = IIf(lestado = "PR" Or lestado = "PROCESADO" Or ltotal = 0, False, True)
            miImprimir.Enabled = True
            miMostrar.Enabled = True


        End If
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
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub mostrar()
        Try
            Dim frm As New frmDocumento
            frm.state_button = True
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.IdSerieImp = cmbIdSerieImp.Value
            frm.estado = dgvDatos.CurrentRow.Cells("Estado").Text
            frm.lblUbicacion.Text = "DOCUMENTO : " & cmbIdSerieImp.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text, frm.IdSerieImp)
                    listaDatos()
                    RowPossesion(dgvDatos, dtDatos, "IdFactura", frm.IdFactura)
                ElseIf frm.type_process = "generated" Then
                    limpiaOpcionesBusqueda("update", frm.NumeroDocGenerated, frm.tipoDocGenerated)
                    listaDatos()
                    RowPossesion(dgvDatos, dtDatos, "IdFactura", frm.FacturaGenerated)
                Else
                    listaDatos()
                    MsgBox("Se elimino el registro correctamente...!!!", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdFactura").Text.ToString, MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New FacturaImportService.FacturaImport
                registro.IdFactura = toNumber(dgvDatos.CurrentRow.Cells("IdFactura").Text)
                estado_process = oFacturaImportService.Borrar(registro)

                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se elimino correctamente el registro...!!!", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                Dim registro As New FacturaImportService.FacturaImport
                Dim serieImp As New FacturaImportService.SerieImportacion
                Dim clienteSold As New FacturaImportService.Cliente
                Dim clienteShip As New FacturaImportService.Cliente

                serieImp.IdSerieImp = toNumber(cmbIdSerieImp.Value)
                registro.SerieImportacion = serieImp
                clienteSold.IdCliente = toNumber(IdCliente)
                registro.ClienteSold = clienteSold
                registro.NumDoc = toNumber(txtNumDoc.Text)
                If toNull(txtFecIni.Text) <> Nothing Then
                    registro.FecIni = txtFecIni.Text
                End If
                If toNull(txtFecFin.Text) <> Nothing Then
                    registro.FecFin = txtFecFin.Text
                End If

                dtDatos = oFacturaImportService.Filtrar(registro).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Nuevo()
        Try
            Dim frm As New frmDocumento
            frm.state_button = False
            frm.IdSerieImp = cmbIdSerieImp.Value
            frm.txtNumDoc.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.SerieImportacion", "NumDoc", "IdSerieImp", cmbIdSerieImp.Value)
            frm.lblUbicacion.Text = "DOCUMENTO : " & cmbIdSerieImp.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text, frm.IdSerieImp)
                listaDatos()
                mostrar()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, dtDatos, "IdFactura", frm.IdFactura)
                    Actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Actualizar()
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
    Private Sub GenerarDocumento()
        Try
            Dim frm As New frmGenerarDocumento
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                MsgBox("Se genero el Documento " + toBlank(frm.txtNumDoc.Text) + " ( " + oMaestroService.MostrarDato("SIGECOM.Maestro.SerieImportacion", "Descripcion", "IdSerieImp", frm.cmbDocaumentos.Value) + " ) ")
                Actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells("IdFactura").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub llenarCombos()
        Try
            '======================================= DOCUMENTOS ================================================
            dtDocumentos = oMaestroService.MostrarSerieImportacion.Tables(0)
            cmbIdSerieImp.DataSource = dtDocumentos
            cmbIdSerieImp.DropDownList.DataMember = dtDocumentos.Columns("Descripcion").ToString
            cmbIdSerieImp.DropDownList.DisplayMember = dtDocumentos.Columns("Descripcion").ToString
            cmbIdSerieImp.DropDownList.ValueMember = dtDocumentos.Columns("IdSerieImp").ToString
            cmbIdSerieImp.DropDownList.Columns(0).DataMember = dtDocumentos.Columns("IdSerieImp").ToString
            cmbIdSerieImp.DropDownList.Columns(1).DataMember = dtDocumentos.Columns("Descripcion").ToString
            cmbIdSerieImp.SelectedIndex = 0
            dtDocumentos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biRefrescar.Click
        Actualizar()

    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbIdSerieImp.ValueChanged
        listaDatos()
    End Sub
    Private Sub txtFecIni_NoneButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecIni.NoneButtonClick
        listaDatos()
    End Sub
    Private Sub txtFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecIni.ValueChanged
        listaDatos()
    End Sub
    Private Sub txtFecFin_NoneButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecFin.NoneButtonClick
        listaDatos()
    End Sub
    Private Sub txtFecFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecFin.ValueChanged
        listaDatos()
    End Sub
    Private Sub txtIdCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCliente.ButtonClick
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            listaDatos()
        End If
    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.Dispose()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpFacturaImportacion
            Dim dtReporte As New DataTable
            Dim IdFactura As Integer = dgvDatos.CurrentRow.Cells("IdFactura").Text
            Dim IdSerieImp As Integer = dgvDatos.CurrentRow.Cells("IdSerieImp").Text
            Dim IdClienteSold As Integer = dgvDatos.CurrentRow.Cells("IdClienteSold").Text
            Dim Medio As String = dgvDatos.CurrentRow.Cells("Medio").Text
            dtReporte = oFacturaImportService.ReporteFacturaImport(IdFactura).Tables(0)

            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                forma.crvReportes.DisplayGroupTree = False
                'forma.crvReportes.RefreshReport = False
                forma.Text = "Reporte de Factura de Importacion"

                'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                'dtReporte.WriteXmlSchema("C:\FacturaImportacion.xml")
                reporte.SetParameterValue("Marcas", oFacturaImportService.MostrarMarcas(IdFactura))
                reporte.SetParameterValue("Paises", oFacturaImportService.MostrarPaises(IdFactura))

                reporte.SetParameterValue("Mensaje1", oFacturaImportService.Mensaje(1, IdSerieImp, Medio, IdClienteSold))
                reporte.SetParameterValue("Mensaje2", oFacturaImportService.Mensaje(2, IdSerieImp, Medio, IdClienteSold))
                reporte.SetParameterValue("Mensaje3", oFacturaImportService.Mensaje(3, IdSerieImp, Medio, IdClienteSold))
                reporte.SetParameterValue("Mensaje4", oFacturaImportService.Mensaje(4, IdSerieImp, Medio, IdClienteSold))
                reporte.SetParameterValue("Mensaje5", oFacturaImportService.Mensaje(5, IdSerieImp, Medio, IdClienteSold))
                reporte.SetParameterValue("Mensaje6", oFacturaImportService.Mensaje(6, IdSerieImp, Medio, IdClienteSold))
                reporte.SetParameterValue("Mensaje7", oFacturaImportService.Mensaje(7, IdSerieImp, Medio, IdClienteSold))

                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biGenerarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarDocumento.Click
        GenerarDocumento()

    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Documento Actual."
    End Sub

    Private Sub GenerarDocumento_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarDocumento.MouseEnter, miGenerarDocumento.MouseEnter
        sslError.Text = "Generar Documento ."
    End Sub

    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Documento."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Documento Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Documento Actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRefrescar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biImprimir.MouseLeave, _
                                    biGenerarDocumento.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                    biEliminar.MouseLeave, biRefrescar.MouseLeave, biSalir.MouseLeave, _
                                    miImprimir.MouseLeave, _
                                    miGenerarDocumento.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                    miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub miGenerarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGenerarDocumento.Click
        GenerarDocumento()

    End Sub
End Class
