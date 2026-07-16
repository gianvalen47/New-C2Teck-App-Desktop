Imports System.Windows.Forms

Public Class frmDocumentos

    Private oMaestroService As New MaestroService.MaestroClient
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

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
                      , txtIdCliente.KeyPress _
                      , txtCodEmbarque.KeyPress
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
                      , dgvDatos.KeyPress _
                      , txtCodEmbarque.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub
    'Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
    '    If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
    '        e.KeyChar = Chr(0)
    '    End If
    'End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdFactura").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub frmDocumentos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 52)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        state_Search = True
        'txtFecIni.Value = CDate("01/" + Month(Today).ToString + "/" + Year(Today).ToString)
        txtFecFin.Value = Today
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
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    'Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal codigoCampo As String, ByVal documento As String)
    '    If type_process = "update" Or type_process = "insert" Then
    '        cmbIdSerieImp.Value = toNumber(documento)
    '        IdCliente = 0
    '        txtIdCliente.Text = "(Todos)"
    '        txtFecIni.Text = ""
    '        txtFecFin.Text = ""
    '        txtNumDoc.Text = codigoCampo
    '    End If
    'End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miVerEstados.Enabled = False
            miGenerarDocumento.Enabled = False
            miImprimir.Enabled = False
            miFecha.Enabled = False
            miExcel.Enabled = False

            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biVerEstados.Enabled = False
            biGenerarDocumento.Enabled = False
            biImprimir.Enabled = False
            biFecha.Enabled = False
            biExcel.Enabled = False
        Else

            Dim lestado As String
            Dim ltotal As Decimal
            lestado = dgvDatos.CurrentRow.Cells("Estado").Text
            ltotal = dgvDatos.CurrentRow.Cells("TotalNeto").Text

            biEliminar.Enabled = IIf(lestado = "PR" Or lestado = "PROCESADO" Or lestado = "CH", False, True)
            biGenerarDocumento.Enabled = True  'IIf(lestado = "PR" Or lestado = "PROCESADO" Or lestado = "CH" Or ltotal = 0, False, True)
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biVerEstados.Enabled = True
            biExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
            biFecha.Enabled = True  'IIf(lestado = "PR" Or lestado = "PROCESADO" Or lestado = "CH", False, True)
            miEliminar.Enabled = IIf(lestado = "PR" Or lestado = "PROCESADO" Or lestado = "CH", False, True)
            miGenerarDocumento.Enabled = IIf(lestado = "PR" Or lestado = "PROCESADO" Or lestado = "CH" Or ltotal = 0, False, True)
            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miVerEstados.Enabled = True
            miExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
            miFecha.Enabled = IIf(lestado = "PR" Or lestado = "PROCESADO" Or lestado = "CH", False, True)


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
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text, frm.IdSerieImp)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdFactura)
                ElseIf frm.type_process = "generated" Then
                    'limpiaOpcionesBusqueda("update", frm.NumeroDocGenerated, frm.tipoDocGenerated)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.FacturaGenerated)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
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
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New FacturaImportService.FacturaImport
                registro.IdFactura = toNumber(dgvDatos.CurrentRow.Cells("IdFactura").Text)
                registro.CodUsu = Session.sCodUsu
                estado_process = oFacturaImportService.Borrar(registro)

                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
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
                registro.NumDoc = txtNumDoc.Text 'toNumber(txtNumDoc.Text)
                If toNull(txtFecIni.Text) <> Nothing Then
                    registro.FecIni = txtFecIni.Text
                End If
                If toNull(txtFecFin.Text) <> Nothing Then
                    registro.FecFin = txtFecFin.Text
                End If

                dtDatos = oFacturaImportService.Filtrar(registro, txtCodEmbarque.Text).Tables(0)
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
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text, frm.IdSerieImp)
                listaDatos()
                RowPossesion(dgvDatos, frm.IdFactura)
                mostrar()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdFactura)
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
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Private Sub GenerarDocumento()
        Try
            Dim frm As New frmGenerarDocumento
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.IdProveedor = dgvDatos.CurrentRow.Cells("IdProveedor").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                MsgBox("Se generó el Documento " + toBlank(frm.txtNumDoc.Text) + " ( " + oMaestroService.MostrarDato("SIGECOM.Maestro.SerieImportacion", "Descripcion", "IdSerieImp", frm.cmbDocaumentos.Value) + " ) ")
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
            'dtDocumentos = oMaestroService.MostrarSerieImportacion.Tables(0)
            dtDocumentos = oFacturaImportService.MostrarSerieImportacion(Session.sCodEmp).Tables(0)
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
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            chkCliente.Checked = False
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
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try          
            Dim forma As New frmReportes
            Dim reporte As New rpFacturaImportacion
            Dim reporte2 As New rpFacturaImportacion2
            Dim reporte3 As New rpFacturaImportacionAllison
            Dim reporte4 As New rpFacturaImportacionMtu
            Dim reporte5 As New rpFacturaImportacionDaimler
            Dim dtReporte As New DataTable
            Dim IdFactura As Integer = dgvDatos.CurrentRow.Cells("IdFactura").Text
            Dim IdSerieImp As Integer = dgvDatos.CurrentRow.Cells("IdSerieImp").Text
            Dim IdClienteSold As Integer = dgvDatos.CurrentRow.Cells("IdClienteSold").Text
            Dim Medio As String = dgvDatos.CurrentRow.Cells("Medio").Text
            Dim IdProveedor As Integer = dgvDatos.CurrentRow.Cells("IdProveedor").Text
            Dim frm As New frmImprimirOpcion

            If IdProveedor = 3 Or IdProveedor = 1407 Then

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtReporte = oFacturaImportService.ReporteFacturaImport(IdFactura).Tables(0)

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Reporte de Factura de Importacion"

                        Dim Fecha As Date
                        Fecha = dgvDatos.CurrentRow.Cells("FecDoc").Text

                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                        'dtReporte.WriteXmlSchema("C:\FacturaImportacion.xml")
                        If cmbIdSerieImp.Value = 1 Then
                            reporte.SetParameterValue("Invoice", "Invoice :")
                        ElseIf cmbIdSerieImp.Value = 2 Then
                            reporte.SetParameterValue("Invoice", "DP " & Fecha.ToString("yy") & "-")
                        ElseIf cmbIdSerieImp.Value = 3 Then
                            reporte.SetParameterValue("Invoice", "N/C-")
                        ElseIf cmbIdSerieImp.Value = 4 Then
                            reporte.SetParameterValue("Invoice", "N/D-")
                        End If
                        reporte.SetParameterValue("Marcas", oFacturaImportService.MostrarMarcas(IdFactura))
                        reporte.SetParameterValue("Paises", oFacturaImportService.MostrarPaises(IdFactura))                        

                        reporte.SetParameterValue("Mensaje1", oFacturaImportService.Mensaje(1, IdSerieImp, Medio, IdClienteSold))
                        reporte.SetParameterValue("Mensaje2", oFacturaImportService.Mensaje(2, IdSerieImp, Medio, IdClienteSold))
                        reporte.SetParameterValue("Mensaje3", oFacturaImportService.Mensaje(3, IdSerieImp, Medio, IdClienteSold))
                        reporte.SetParameterValue("Mensaje4", oFacturaImportService.Mensaje(4, IdSerieImp, Medio, IdClienteSold))
                        reporte.SetParameterValue("Mensaje5", oFacturaImportService.Mensaje(5, IdSerieImp, Medio, IdClienteSold))
                        reporte.SetParameterValue("Mensaje6", oFacturaImportService.Mensaje(6, IdSerieImp, Medio, IdClienteSold))
                        reporte.SetParameterValue("Mensaje7", oFacturaImportService.Mensaje(7, IdSerieImp, Medio, IdClienteSold))

                        If frm.state_button = True Then
                            reporte.SetParameterValue("pProveedor", "BF INVESTMENTS AND CONSULTING INC.")
                            reporte.SetParameterValue("pDireccion", "10800 NW 29 STREET")
                            reporte.SetParameterValue("pCiudad", "DORAL FL. 33172")
                            reporte.SetParameterValue("pTelefono", "PHONE 305-463-9478")
                            reporte.SetParameterValue("pFax", "FAX.      305-463-9481")

                        ElseIf frm.state_button = False Then

                            reporte.SetParameterValue("pProveedor", "BF DIESEL INC.")
                            reporte.SetParameterValue("pDireccion", "10800 N.W.  29 STREET")
                            reporte.SetParameterValue("pCiudad", "MIAMI FLA. 33172")
                            reporte.SetParameterValue("pTelefono", "PHONE 305-463-9478")
                            reporte.SetParameterValue("pFax", "FAX.    305-463-9481")

                        End If

                        forma.ShowDialog()

                    End If
                End If


            ElseIf IdProveedor = 8 Then   '=========================== ALLISON ==============================
                dtReporte = oFacturaImportService.ReporteFacturaImport(IdFactura).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte3.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte3

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Factura de Importacion"

                    Dim Fecha As Date
                    Fecha = dgvDatos.CurrentRow.Cells("FecDoc").Text

                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\FacturaImportacion.xml")
                    If cmbIdSerieImp.Value = 1 Then
                        reporte3.SetParameterValue("Invoice", "Invoice :")
                    ElseIf cmbIdSerieImp.Value = 2 Then
                        reporte3.SetParameterValue("Invoice", "DP " & Fecha.ToString("yy") & "-")
                    ElseIf cmbIdSerieImp.Value = 3 Then
                        reporte3.SetParameterValue("Invoice", "N/C-")
                    ElseIf cmbIdSerieImp.Value = 4 Then
                        reporte3.SetParameterValue("Invoice", "N/D-")
                    End If
                    reporte3.SetParameterValue("Marcas", oFacturaImportService.MostrarMarcas(IdFactura))
                    reporte3.SetParameterValue("Paises", oFacturaImportService.MostrarPaises(IdFactura))
                    reporte3.SetParameterValue("Medio", Medio)


                    forma.ShowDialog()

                End If

            ElseIf IdProveedor = 17 Then   '========================== DAIMLER ==============================
                dtReporte = oFacturaImportService.ReporteFacturaImport(IdFactura).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte5.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte5

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Factura de Importacion"

                    Dim Fecha As Date
                    Fecha = dgvDatos.CurrentRow.Cells("FecDoc").Text

                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\FacturaImportacion.xml")
                    If cmbIdSerieImp.Value = 1 Then
                        reporte5.SetParameterValue("Invoice", "Invoice :")
                    ElseIf cmbIdSerieImp.Value = 2 Then
                        reporte5.SetParameterValue("Invoice", "DP " & Fecha.ToString("yy") & "-")
                    ElseIf cmbIdSerieImp.Value = 3 Then
                        reporte5.SetParameterValue("Invoice", "N/C-")
                    ElseIf cmbIdSerieImp.Value = 4 Then
                        reporte5.SetParameterValue("Invoice", "N/D-")
                    End If
                    reporte5.SetParameterValue("Marcas", oFacturaImportService.MostrarMarcas(IdFactura))
                    reporte5.SetParameterValue("Paises", oFacturaImportService.MostrarPaises(IdFactura))
                    reporte5.SetParameterValue("Medio", Medio)

                    forma.ShowDialog()

                End If

            ElseIf IdProveedor = 1187 Then   '==================== TOGNUM AMERICA INC. ========================
                dtReporte = oFacturaImportService.ReporteFacturaImport(IdFactura).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte4.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte4

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Factura de Importacion"

                    Dim Fecha As Date
                    Fecha = dgvDatos.CurrentRow.Cells("FecDoc").Text

                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\FacturaImportacion.xml")
                    If cmbIdSerieImp.Value = 1 Then
                        reporte4.SetParameterValue("Invoice", "Invoice :")
                    ElseIf cmbIdSerieImp.Value = 2 Then
                        reporte4.SetParameterValue("Invoice", "DP " & Fecha.ToString("yy") & "-")
                    ElseIf cmbIdSerieImp.Value = 3 Then
                        reporte4.SetParameterValue("Invoice", "N/C-")
                    ElseIf cmbIdSerieImp.Value = 4 Then
                        reporte4.SetParameterValue("Invoice", "N/D-")
                    End If
                    reporte4.SetParameterValue("Marcas", oFacturaImportService.MostrarMarcas(IdFactura))
                    reporte4.SetParameterValue("Paises", oFacturaImportService.MostrarPaises(IdFactura))
                    reporte4.SetParameterValue("Medio", Medio)

                    forma.ShowDialog()

                End If

            Else
                dtReporte = oFacturaImportService.ReporteFacturaImport(IdFactura).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte2.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte2

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Factura de Importacion"

                    Dim Fecha As Date
                    Fecha = dgvDatos.CurrentRow.Cells("FecDoc").Text

                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\FacturaImportacion.xml")
                    If cmbIdSerieImp.Value = 1 Then
                        reporte2.SetParameterValue("Invoice", "Invoice :")
                    ElseIf cmbIdSerieImp.Value = 2 Then
                        reporte2.SetParameterValue("Invoice", "DP " & Fecha.ToString("yy") & "-")
                    ElseIf cmbIdSerieImp.Value = 3 Then
                        reporte2.SetParameterValue("Invoice", "N/C-")
                    ElseIf cmbIdSerieImp.Value = 4 Then
                        reporte2.SetParameterValue("Invoice", "N/D-")
                    ElseIf cmbIdSerieImp.Value = 5 Then
                        reporte2.SetParameterValue("Invoice", "Invoice :")
                    Else
                        reporte2.SetParameterValue("Invoice", "")
                    End If
                    reporte2.SetParameterValue("Marcas", oFacturaImportService.MostrarMarcas(IdFactura))
                    reporte2.SetParameterValue("Paises", oFacturaImportService.MostrarPaises(IdFactura))
                    reporte2.SetParameterValue("Medio", Medio)

                    forma.ShowDialog()

                End If
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

    Private Sub biFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biFecha.Click, miFecha.Click
        Try
            Dim frm As New frmIngresarFecha
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FECHA]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtIdCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtIdCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biExcel.Click, miExcel.Click
        Try
            If MsgBox("¿Está seguro de EXPORTAR a Excel el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim dtExcel As DataTable
                dtExcel = oFacturaImportService.ImpresionExcel(dgvDatos.CurrentRow.Cells("IdFactura").Text).Tables(0)
                DataGridView1.DataSource = dtExcel
                Dim Export As Boolean = ExportarExcel(DataGridView1)
                If Export Then
                    MsgBox("Se realizó la exportación correctamente")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biExportaCtasPorPagar_Click(sender As Object, e As EventArgs) Handles biExportaCtasPorPagar.Click, miExportarCtasPorPagar.Click
        Try
            'Dim idGasto As Int64
            'idGasto = dgvDatos.CurrentRow.Cells("IdFactura").Text
            'If MsgBox("¿Estas seguro de EXPORTAR a cuentas por pagar la Factura N° ", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            '    If oFacturaImportService.ExportarCtasPorPagar(idGasto, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
            '        MsgBox("Se registraron los documentos en Cuentas por Pagar con exito!!!!!!", MsgBoxStyle.Information)
            '        Actualizar_Click(sender, e)

            '    End If
            'End If

            Dim frm As New frmDocumento_GenerarSolGasto
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.FecDoc = dgvDatos.CurrentRow.Cells("FecDoc").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If

        Catch ex As Exception
            MsgBox("ERROR AL GENERAR LA SOLICITUD DE GASTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biVerEstados_Click(sender As Object, e As EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmDocumento_VerEstados
                frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Value
                frm.Text = "Estados de la Factura de Importacion Nº " & dgvDatos.CurrentRow.Cells("IdFactura").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class
