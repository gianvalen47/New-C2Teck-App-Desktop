Imports System.ServiceModel
Public Class frmGuiasDevolucion

    Private oMaestroService As New MaestroService.MaestroClient
    Private oGuiaDevolucionService As New GuiaDevolucionService.GuiaDevolucionServiceClient
    Private oGuiaDevolucionDetService As New GuiaDevolucionDetService.GuiaDevolucionDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    Private IdSerieDoc As Integer

    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClientes As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                   txtAnio.KeyPress, cmbMes.KeyPress, cmbOficinas.KeyPress, cmbIdLocacion.KeyPress, cmbEstado.KeyPress, txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrar()
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              txtAnio.KeyPress, cmbMes.KeyPress, cmbOficinas.KeyPress, cmbIdLocacion.KeyPress, txtIdCliente.KeyPress,
                              cmbEstado.KeyPress, txtNumDoc.KeyPress, btnBuscar.KeyPress ' dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdGuiaDev").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmGuiasDevolucion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        ElseIf e.KeyCode = Keys.End Then
            e.Handled = True
            dgvDatos.Select()
            dgvDatos.Row = dgvDatos.RowCount - 1
            dgvDatos.Col = 1
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 19)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        'txtAnio.Value = Today.Year
        'cmbMes.Value = Today.Month
        txtAnio.Value = Session.sFecha.Year
        cmbMes.Value = Session.sFecha.Month
        'IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        cmbEstado.Value = ""
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Try
        '  If isClosed(oMaestroService) = False Then
        '    oMaestroService.Close()
        '  End If
        '  If isClosed(oGuiaDevolucionService) = False Then
        '    oGuiaDevolucionService.Close()
        '  End If
        'Catch ex As Exception
        '  MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

        Try
            oMaestroService.Close()
            oGuiaDevolucionService.Close()
            oGuiaDevolucionDetService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oGuiaDevolucionService.Abort()
            oGuiaDevolucionDetService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oGuiaDevolucionService.Abort()
            oGuiaDevolucionDetService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)


    End Sub
    'Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal numero As String)
    '    If type_process = "update" Or type_process = "insert" Then
    '        cmbEstado.Value = ""
    '        txtNumDoc.Text = numero
    '    End If
    'End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biGenerar.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biAnular.Enabled = False
            biEstados.Enabled = False

            miImprimir.Enabled = False
            miGenerar.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miAnular.Enabled = False
            miEstados.Enabled = False
        Else
            Dim lEstado, lMotivo As String
            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            lMotivo = dgvDatos.CurrentRow.Cells("CodMot").Text

            biImprimir.Enabled = IIf(lEstado = "AN", False, True)
            biGenerar.Enabled = IIf(lEstado = "IM" And Val(lMotivo) <= 5, True, False)
            biMostrar.Enabled = IIf(lEstado = "AN", False, True)
            biEliminar.Enabled = IIf(lEstado = "GN", True, False)
            biAnular.Enabled = IIf(lEstado = "IM", True, False)
            biProcesar.Enabled = IIf(lEstado = "IM" And (Session.CodPerfil = "11" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05"), True, False)  '------ Se agrega el Perfil de Costos 02/08/2016
            biEstados.Enabled = True

            miImprimir.Enabled = IIf(lEstado = "AN", False, True)
            miGenerar.Enabled = IIf(lEstado = "IM" And Val(lMotivo) <= 5, True, False)
            miMostrar.Enabled = IIf(lEstado = "AN", False, True)
            miEliminar.Enabled = IIf(lEstado = "GN", True, False)
            miAnular.Enabled = IIf(lEstado = "IM", True, False)
            miProcesar.Enabled = IIf(lEstado = "IM" And (Session.CodPerfil = "11" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05"), True, False)   '------ Se agrega el Perfil de Costos 02/08/2016
            miEstados.Enabled = True
        End If
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

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub imprimir()
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está Seguro de IMPRIMIR la Guía de Devolucion Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then


                    Dim forma As New frmReportes
                    Dim reporte As New rpImprimirGuiaDevolucion
                    Dim reporteProvincia As New rpImprimirGuiaDevolucionProvincia
                    Dim dtReporte As New DataTable
                    Dim dtDetalles As New DataTable
                    Dim IdGuiaDev As Integer = dgvDatos.CurrentRow.Cells("IdGuiaDev").Text


                    dtReporte = oGuiaDevolucionService.Imprimir(IdGuiaDev).Tables(0)
                    dtDetalles = oGuiaDevolucionDetService.Mostrar(toNumber(IdGuiaDev)).Tables(0)
                    '/////////////////////////////////////////////////////////////////////////////
                    Dim Detalles As Integer
                    Dim A() As String
                    Dim registro As GuiaDevolucionService.GuiaDevolucion
                    registro = oGuiaDevolucionService.MostrarPorId(IdGuiaDev)
                    txtObservacion.Text = toBlank(registro.Observacion)
                    A = Split(txtObservacion.Text, vbCrLf, -1, vbTextCompare)
                    Detalles = dtDetalles.Rows.Count
                    If (UBound(A) + 1) + Detalles > 15 Then
                        MsgBox("No puede imprimir por exceso de líneas,Verificar")
                    Else
                        If dtReporte.Rows.Count = 0 Then
                            MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                        Else
                            Dim Impresora As String = SeleccionarImpresora()
                            If Impresora <> "" Then

                                If cmbOficinas.Value = 2 Then
                                    reporteProvincia.SetDataSource(dtReporte)
                                    forma.crvReportes.ReportSource = reporteProvincia

                                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                        forma.crvReportes.ShowExportButton = True
                                    Else
                                        forma.crvReportes.ShowExportButton = False
                                    End If
                                    'forma.crvReportes.RefreshReport = False
                                    'forma.crvReportes.DisplayGroupTree = False

                                    forma.Text = "Imprimir Guia de Devolucion"

                                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                    'dtReporte.WriteXmlSchema("C:\GuiaDevolucion.xml")
                                    reporteProvincia.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))

                                    reporteProvincia.PrintOptions.PrinterName = Impresora
                                    reporteProvincia.PrintToPrinter(1, False, 0, 0)
                                    oGuiaDevolucionService.ActualizarEstadoImpreso(IdGuiaDev, Session.sCodUsu)
                                    actualizar()
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

                                    forma.Text = "Imprimir Guia de Devolucion"

                                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                    'dtReporte.WriteXmlSchema("C:\GuiaDevolucion.xml")
                                    reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))

                                    reporte.PrintOptions.PrinterName = Impresora
                                    reporte.PrintToPrinter(1, False, 0, 0)
                                    oGuiaDevolucionService.ActualizarEstadoImpreso(IdGuiaDev, Session.sCodUsu)
                                    actualizar()
                                End If


                            End If
                        End If
                        'forma.crvReportes.PrintReport()
                        'forma.ShowDialog()
                    End If
                Else
                    dgvDatos.Focus()
                End If


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try

        End If
    End Sub
    Private Sub generar()
        If ValidaCodigoSeleccionado() Then
            Try
                Dim frm As New frmGuiaDevolucion_GenerarNotaCredito
                frm.Text = "Generar Nota Crédito de la Guía Nº " + txtNumDoc.Text.ToString
                frm.IdGuiaDev = dgvDatos.CurrentRow.Cells("IdGuiaDev").Text
                frm.IdLocacion = dgvDatos.CurrentRow.Cells("IdLocacion").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    actualizar()
                End If
            Catch ex As Exception
                MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub nuevo()
        Try
            Dim frm As New frmGuiaDevolucion_Generar
            frm.state_button = False
            frm.lblUbicacion.Text = ""
            frm.txtNumDoc.Text = oGuiaDevolucionService.SugerirNumero(cmbIdLocacion.Value)
            frm.IdLocacion = cmbIdLocacion.Value
            frm.txtNumDoc.Select()
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdGuiaDev)
                    mostrar()
                    actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [NUEVO]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrar()
        If ValidaCodigoSeleccionado() And dgvDatos.CurrentRow.Cells("Estado").Text <> "AN" Then
            Try
                Dim frm As New frmGuiaDevolucion
                Dim lEstado As String
                lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
                frm.state_button = True
                frm.IdGuiaDev = dgvDatos.CurrentRow.Cells("IdGuiaDev").Text
                frm.edicion = False
                frm.editable = IIf(lEstado = "GN", True, False)
                frm.lblUbicacion.Text = "OFICINA : " & cmbOficinas.Text & "  -  ALMACEN : " & cmbIdLocacion.Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    If frm.type_process = "update" Then
                        'limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text)
                        listaDatos()
                        RowPossesion(dgvDatos, frm.IdGuiaDev)
                    Else
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                actualizar()

            Catch ex As Exception
                MsgBox("ERROR [MOSTRAR]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub eliminar()
        If ValidaCodigoSeleccionado() Then
            Try
                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ELIMINAR la Guía de Devolución Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean

                    estado_process = oGuiaDevolucionService.Borrar(dgvDatos.CurrentRow.Cells("IdGuiaDev").Text, Session.sCodUsu)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("Se Eliminó la Guía de Devolución actual correctamente..!!!", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ELIMINAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub anular()
        If ValidaCodigoSeleccionado() Then
            Try
                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ANULAR la Guía de Devolución Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oGuiaDevolucionService.AnulacionConsulta(dgvDatos.CurrentRow.Cells("IdGuiaDev").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    'estado_process = oGuiaDevolucionService.Anular(dgvDatos.CurrentRow.Cells("IdGuiaDev").Text, Session.sCodUsu)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("La Guía fue enviada a CONSULTA para su anulación, Comuníquese con Almacén  ...!!!", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ANULAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdGuiaDev").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
        enableOpciones()
    End Sub
    Private Sub salir()
        Me.Dispose()
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oGuiaDevolucionService.Filtrar(txtAnio.Value _
                                                     , cmbMes.Value _
                                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                     , toNumber(IdCliente) _
                                                     , cmbEstado.Value _
                                                     , toNumber(txtNumDoc.Text)).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LISTA_DATOS]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        dgvDatos.Select()
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdGuiaDev").Text = Nothing Then
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
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
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
            '======================================= ESTADOS ================================================
            dtEstados = oGuiaDevolucionService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing
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
    Private Sub dgvDatos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub

    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbEstado.ValueChanged _
                  , cmbMes.ValueChanged _
                  , cmbIdLocacion.ValueChanged
        listaDatos()
    End Sub
    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
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
    Private Sub txtFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub txtFecFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub txtanio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAnio.Click
        listaDatos()
    End Sub
    Private Sub txtIdCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
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

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        imprimir()
    End Sub
    Private Sub biGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.Click
        generar()
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        mostrar()
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        eliminar()
    End Sub
    Private Sub biAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.Click
        anular()
    End Sub
    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        actualizar()
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        salir()
    End Sub
    Private Sub miImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click
        imprimir()
    End Sub
    Private Sub miGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGenerar.Click
        generar()
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        nuevo()
    End Sub
    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        mostrar()
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        eliminar()
    End Sub
    Private Sub miAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAnular.Click
        anular()
    End Sub
    Private Sub biProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biProcesar.Click, miProcesar.Click
        procesar()
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        salir()
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                  biImprimir.MouseLeave, biGenerar.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                  biEliminar.MouseLeave, biAnular.MouseLeave, biEstados.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                  miImprimir.MouseLeave, miGenerar.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                  miEliminar.MouseLeave, miGenerar.MouseLeave, miEstados.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave

        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Guía de Devolución actual."
    End Sub
    Private Sub Generar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.MouseEnter, miGenerar.MouseEnter
        sslError.Text = "Generar Nota de Crédito a partir de la Guía de Devolución actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Guía de Devolución."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Guía de Devolución actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Guía de Devolución actual."
    End Sub
    Private Sub Anular_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.MouseEnter, miAnular.MouseEnter
        sslError.Text = "Anular Guía de Devolución actual."
    End Sub

    Private Sub Estados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.MouseEnter, miEstados.MouseEnter
        sslError.Text = "Estados de la Guía de Devolución actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress

        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
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

    Private Sub biEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.Click, miEstados.Click
        Try
            Dim frm As New frmGuiaDevolucion_Estados

            frm.IdGuiaDev = dgvDatos.CurrentRow.Cells("IdGuiaDev").Text
            frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub procesar()
        If ValidaCodigoSeleccionado() Then
            Try
                Dim frm As New frmGuiaDevolucion_Procesar
                frm.IdGuiaDev = dgvDatos.CurrentRow.Cells("IdGuiaDev").Text
                frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    actualizar()
                End If
            Catch ex As Exception
                MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Sub txtIdCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdCliente.KeyDown
        If e.KeyCode = Keys.F12 Or Keys.Enter Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click

        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                chkCliente.Checked = False
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            cmbEstado.Select()
            listaDatos()
        End If

    End Sub

    'Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
    '                 txtNumDoc.KeyPress _
    '              , cmbOficinas.KeyPress _
    '              , cmbIdLocacion.KeyPress _
    '              , cmbEstado.KeyPress _
    '              , txtAnio.KeyPress _
    '              , txtIdCliente.KeyPress _
    '              , cmbMes.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '        listaDatos()
    '    End If
    'End Sub

End Class