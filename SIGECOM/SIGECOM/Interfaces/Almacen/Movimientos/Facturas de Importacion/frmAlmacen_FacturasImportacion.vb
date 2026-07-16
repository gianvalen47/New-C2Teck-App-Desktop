Imports System.Data.OleDb
Imports System.IO
Imports System.IO.FileInfo

Public Class frmAlmacen_FacturasImportacion

    Private oMaestroService As New MaestroService.MaestroClient
    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    Private oPedidoImportService As New PedidoImportService.PedidoImportServiceClient
    Private oImportacionDetService As New ImportacionDetService.ImportacionDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtProveedores As DataTable
    Private dtEstados As DataTable
    Private dtDescargar As DataTable
    Public IdImportacion As Integer


    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbIdCliente.KeyPress _
                      , txtFecIni.KeyPress _
                      , txtCodEmbarque.KeyPress _
                      , cmbEstados.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbIdCliente.KeyPress _
                      , txtFecIni.KeyPress _
                      , btnBuscar.KeyPress _
                      , cmbEstados.KeyPress _
                      , txtCodEmbarque.KeyPress
        ', dgvDatos.KeyPress
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
                If CInt(row.Cells("IdImportacion").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub frmAlmacen_FacturasImportacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 5)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        'state_Search = False
        llenarCombos()
        state_Search = True
        txtFecIni.Value = "01/" & Month(Today) & "/" & Year(Today)
        txtFecFin.Value = Today.Date
        listaDatos()
        dgvDatos.Select()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oImportacionService) = False Then
                oImportacionService.Close()
            End If
            If isClosed(oPedidoImportService) = False Then
                oPedidoImportService.Close()
            End If
            If isClosed(oImportacionDetService) = False Then
                oPedidoImportService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal codigoCampo As String, ByVal cod_proveedor As Integer, ByVal cod_locacion As Integer)
    '    If type_process = "update" Or type_process = "insert" Then
    '        '*****************************
    '        'state_Search = False
    '        cmbOficinas.Value = toBlank(oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", cod_locacion))
    '        cmbIdLocacion.Value = cod_locacion
    '        cmbIdCliente.Value = cod_proveedor
    '        txtFecIni.Text = ""
    '        txtFecFin.Text = ""
    '        txtNumDoc.Text = codigoCampo
    '        state_Search = True
    '    End If
    'End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miTrasladar.Enabled = False
            miImprimir.Enabled = False
            miActualizar.Enabled = False
            miChequear.Enabled = False
            miGenerarMTI.Enabled = False

            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biTrasladar.Enabled = False
            biImprimir.Enabled = False
            biActualizar.Enabled = False
            biChequear.Enabled = False
            biGenerarMTI.Enabled = False
        Else
            Dim lestado As String
            lestado = dgvDatos.CurrentRow.Cells("Estado").Text

            biTrasladar.Enabled = IIf(lestado = "GENERADO", True, False)
            biEliminar.Enabled = IIf(lestado = "GENERADO", True, False)
            biMostrar.Enabled = True
            biImprimir.Enabled = True
            biActualizar.Enabled = True
            biChequear.Enabled = IIf(lestado = "TRANSITO", True, False)
            biGenerarMTI.Enabled = IIf(lestado = "GENERADO", False, True)

            miTrasladar.Enabled = IIf(lestado = "GENERADO", True, False)
            miEliminar.Enabled = IIf(lestado = "GENERADO", True, False)
            miMostrar.Enabled = True
            miImprimir.Enabled = True
            miActualizar.Enabled = True
            miChequear.Enabled = IIf(lestado = "TRANSITO", True, False)
            miGenerarMTI.Enabled = IIf(lestado = "GENERADO", False, True)
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
            Dim frm As New frmAlmacen_FacturaImportacion
            frm.state_button = True
            frm.IdImportacion = dgvDatos.CurrentRow.Cells("IdImportacion").Text
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.IdLocacion = cmbIdLocacion.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text, frm.IdCliente, frm.IdLocacion)
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdImportacion)
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
            If MsgBox("¿Está seguro de ELIMINAR el registro con Nº = " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oImportacionService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdImportacion").Text), Session.sCodUsu)

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
                dtDatos = oImportacionService.Filtrar(IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                      , cmbIdCliente.Value _
                                                      , IIf(toBlank(txtFecIni.Text) = "", Nothing, txtFecIni.Value) _
                                                      , IIf(toBlank(txtFecFin.Text) = "", Nothing, txtFecFin.Value) _
                                                      , txtNumDoc.Text _
                                                      , cmbEstados.Value, "", txtCodEmbarque.Text).Tables(0)
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
            Dim frm As New frmAlmacen_FacturaImportacion
            frm.state_button = False
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.IdLocacion = cmbIdLocacion.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text, frm.IdCliente, frm.IdLocacion)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdImportacion)
                    mostrar()
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
            codigo = dgvDatos.CurrentRow.Cells("IdImportacion").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
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
            '======================================= PROVEEDORES ================================================
            dtProveedores = oPedidoImportService.MostrarProveedores(Session.sCodEmp).Tables(0)
            dtProveedores.Rows.InsertAt(getRowTodos(dtProveedores), 0)
            cmbIdCliente.DataSource = dtProveedores
            cmbIdCliente.DropDownList.DataMember = dtProveedores.Columns("DesProv").ToString
            cmbIdCliente.DropDownList.DisplayMember = dtProveedores.Columns("DesProv").ToString
            cmbIdCliente.DropDownList.ValueMember = dtProveedores.Columns("IdProveedor").ToString
            cmbIdCliente.DropDownList.Columns(0).DataMember = dtProveedores.Columns("IdProveedor").ToString
            cmbIdCliente.DropDownList.Columns(1).DataMember = dtProveedores.Columns("DesProv").ToString
            cmbIdCliente.SelectedIndex = 0
            dtProveedores = Nothing
            '======================================= ESTADOS ================================================
            dtEstados = oImportacionService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstados.DataSource = dtEstados
            cmbEstados.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstados.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstados.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstados.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstados.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstados.SelectedIndex = 0
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
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
        Actualizar()
    End Sub

    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                  cmbIdLocacion.ValueChanged _
                , cmbIdCliente.ValueChanged _
                , cmbEstados.ValueChanged
        listaDatos()
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

    Private Sub txtFecIni_NoneButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecIni.NoneButtonClick
        listaDatos()
    End Sub
    Private Sub txtFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecIni.ValueChanged
        listaDatos()
    End Sub

    Private Sub txtFecFin_NoneButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub

    Private Sub txtFecFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Dim forma As New frmAlmacen_FacturaImportacionImprimir
        forma.IdImportacion = toNumber(dgvDatos.CurrentRow.Cells("IdImportacion").Value)
        forma.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
        forma.IdLocacion = cmbIdLocacion.Value
        forma.FecInicio = txtFecIni.Value
        forma.FecFinal = txtFecFin.Value
        forma.ShowDialog()
    End Sub

    Private Sub biChequear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biChequear.Click, miChequear.Click
        Try
            If ValidaCodigoSeleccionado() Then
                If MsgBox("¿Está seguro de Chequear la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oImportacionService.ChequearFactura(dgvDatos.CurrentRow.Cells("IdImportacion").Value, Session.sCodUsu)
                    If estado_process Then
                        MsgBox("Se Chequeó la Factura correctamente.")
                        Actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de sistemas.")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [CHEQUEAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                     biImprimir.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                     biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                     biTrasladar.MouseLeave, biChequear.MouseLeave, biIngresoMasivo.MouseLeave, _
                                     biImpresionMasiva.MouseLeave, biActualizarFecha.MouseLeave, miActualizarFecha.MouseLeave, _
                                     miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                     miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, _
                                     miTrasladar.MouseLeave, miChequear.MouseLeave, miIngresoMasivo.MouseLeave, _
                                     miImpresionMasiva.MouseLeave, miSeleccionMasiva.MouseMove, biSeleccionMasiva.MouseLeave, _
                                     miGenerarMTI.MouseLeave, biGenerarMTI.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Factura de Importación actual."
    End Sub
    Private Sub Trasladar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladar.MouseEnter, miTrasladar.MouseEnter
        sslError.Text = "Trasladar la Factura de Importación actual."
    End Sub
    Private Sub Chequear_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biChequear.MouseEnter, miChequear.MouseEnter
        sslError.Text = "Chequear la Factura de Importación actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Factura de Importación."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Factura de Importación actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Factura de Importación actual."
    End Sub
    Private Sub IngresarMasivo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biIngresoMasivo.MouseEnter, miIngresoMasivo.MouseEnter
        sslError.Text = "Ingresar Facturas de Importación Masivo."
    End Sub
    Private Sub SeleccionMasiva_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSeleccionMasiva.MouseEnter, miSeleccionMasiva.MouseEnter
        sslError.Text = "Cantidades de Detalles Conformes."
    End Sub
    Private Sub ImprimirMasivo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImpresionMasiva.MouseEnter, miImpresionMasiva.MouseEnter
        sslError.Text = "Imprimir Facturas de Importación Masivo."
    End Sub
    Private Sub GenerarMTI_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarMTI.MouseEnter, miGenerarMTI.MouseEnter
        sslError.Text = "Generar MTI de Factura de Importación actual."
    End Sub
    Private Sub ActualizarFecha_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizarFecha.MouseEnter, miActualizarFecha.MouseEnter
        sslError.Text = "Actualizar Fecha de las F/I en estado GENERADO."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub biTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladar.Click, miTrasladar.Click
        Try
            If MsgBox("¿Está seguro de Trasladar la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim frm As New frmAlmacen_FacturaImportacion
                IdImportacion = dgvDatos.CurrentRow.Cells("IdImportacion").Text

                If ValidaCantidades() Then
                    If (oImportacionService.TransferirStock(IdImportacion, Session.sCodUsu)) Then
                        biTrasladar.Enabled = False
                        'btnGuardar.Enabled = False
                        'btnEliminar.Enabled = False
                        MsgBox("Se Traslado la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text + ". correctamente", MsgBoxStyle.Information)
                        miActualizar_Click(sender, e)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                    frm.type_process = "update"
                Else
                    'MsgBox("Debe recepcionar por lo menos un item.", MsgBoxStyle.Exclamation)
                    '------------------ Se agregó para que se puedan trasladar cantidades iguales a cero, pero confirmando el traslado 25/03/2014 ---------
                    If MsgBox("Las cantidades recibidas estan en cero. ¿Está seguro de Trasladar la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        If (oImportacionService.TransferirStock(IdImportacion, Session.sCodUsu)) Then
                            biTrasladar.Enabled = False
                            'btnGuardar.Enabled = False
                            'btnEliminar.Enabled = False
                            MsgBox("Se Traslado la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text + ". correctamente", MsgBoxStyle.Information)
                            miActualizar_Click(sender, e)
                        Else
                            MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                        End If
                        frm.type_process = "update"
                    End If
                    '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [TRASLADAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCantidades() As Boolean
        Try
            Dim dtDetalles As New DataTable
            dtDetalles = oImportacionDetService.Mostrar(dgvDatos.CurrentRow.Cells("IdImportacion").Text).Tables(0)

            Dim Contador As Integer = 0
            For Each Fila As DataRow In dtDetalles.Rows
                Contador = Contador + Fila.Item("CanMer")
            Next
            If Contador > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR [TRASLADAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

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

    Private Sub Descargar()
        Try
            dtDescargar = oImportacionDetService.MostrarCodigoBarras(dgvDatos.CurrentRow.Cells("IdImportacion").Value).Tables(0)
            ExportaDT_DBF(dtDescargar)

        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR CODIGO BARRAS : " + ex.Message)
        End Try
    End Sub

    Public Function ExportaDT_DBF(ByVal dt As DataTable) As Integer
        ' Comprobación de parámetros
        If (dt Is Nothing) Then _
            Throw New ArgumentNullException()
        ' Indicamos el atributo 'añadido' a todos los registros
        ' del objeto DataTable.
        For Each row As DataRow In dt.Rows
            row.SetAdded()
        Next

        Try
            Dim cnn As New OleDbConnection( _
                "Provider=VFPOLEDB.1;" & "Data Source=D:\PSION;" & _
                "Extended Properties='dBASE IV;'")

            'Dim cnn As New OleDbConnection( _
            '    "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=D:\PSION;" & _
            '    "Extended Properties='dBASE IV;'")

            Dim n As Integer = CreateDbf(dt, dt.TableName, cnn)

            If n > 0 Then
                MsgBox("Se realizó la exportación correctamente ")
            End If

            Return n

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Exportar los Datos")
        End Try

    End Function

    Private Function GetDataTypeSql(ByVal dc As DataColumn) As String

        Dim columnName As String = dc.ColumnName
        Dim dataType As String
        Dim maxLength As Int32

        Select Case dc.DataType.Name
            Case "Boolean"
                dataType = "bit"

            Case "Byte", "SByte"
                dataType = "tinyint"

            Case "Char"
                dataType = "char"
                'maxLength = 30
                maxLength = dc.MaxLength

            Case "DateTime"
                dataType = "datetime"

            Case "Decimal"
                dataType = "decimal (18, 2)"

            Case "Double"
                dataType = "real"

            Case "Int16", "UInt16"
                dataType = "smallint"

            Case "Numeric"
                dataType = "NUMERIC (10,0)"

            Case "Int32", "UInt32"
                dataType = "int"

            Case "Int64", "UInt64"
                dataType = "bigint"

            Case "Object", "Byte[]"
                dataType = "image"

            Case "Single"
                dataType = "float"

            Case Else   ' String
                If (dc.MaxLength = 536870910) Then
                    dataType = "memo"

                Else
                    dataType = "nvarchar"
                    maxLength = dc.MaxLength

                End If

        End Select

        If (maxLength > 0) Then
            Return String.Format("[{0}] {1} ({2}),", columnName, dataType, maxLength)

        Else
            Return String.Format("[{0}] {1},", columnName, dataType)

        End If

    End Function

    Private Function CreateDbf(ByVal dt As DataTable, _
                              ByVal tableName As String, _
                              ByVal cnn As OleDbConnection) As Integer

        ' Verifico los valores pasados.
        '
        If (dt Is Nothing) Then _
            Throw New ArgumentNullException("dt", _
                "El objeto no es válido")

        If (String.IsNullOrEmpty(tableName)) Then _
            Throw New ArgumentNullException("tableName", _
                "No se ha especificado el nombre de la tabla.")

        If (cnn Is Nothing) Then _
            Throw New ArgumentNullException("cnn", _
                "El objeto Connection no es válido.")

        Dim sql As New System.Text.StringBuilder(256)

        Try
            '' ''sql.Append("CREATE TABLE " & tableName & "(")

            '' ''For Each dc As DataColumn In dt.Columns
            '' ''    ' obtenemos el tipo de dato de la columna
            '' ''    sql.Append(GetDataTypeSql(dc))
            '' ''Next

            ' '' '' Reemplazo la última coma por el cierre de paréntesis
            ' '' ''
            '' ''sql.Replace(","c, ")"c, sql.Length - 1, 1)

            ''sql.Append("CREATE TABLE DESCARGAR([CODIGO] bigint, [CONCEPTO] int, [IMPORTE] Double)")

            DeleteTable()

            Using cnn

                Dim cmd As OleDbCommand = cnn.CreateCommand()
             
                cmd.CommandText = ("CREATE TABLE CODIGOS([CodMer] char(40), [Codigo] char(40), [Descrip] char(40), [CanFac] Numeric )")

                cnn.Open()

                cmd.ExecuteNonQuery()

                'cmd.CommandText = String.Format("SELECT * FROM [{0}]", tableName)

                cmd.CommandText = String.Format("SELECT * FROM CODIGOS")

                Dim da As New OleDbDataAdapter(cmd)

                Dim cb As New OleDbCommandBuilder(da)

                cb.QuotePrefix = "["
                cb.QuoteSuffix = "]"

                da.InsertCommand = cb.GetInsertCommand()

                Return da.Update(dt)

            End Using

        Catch ex As Exception
            Throw

        Finally
            sql = Nothing

        End Try

    End Function

    Private Sub biDescargar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDescargar.Click, miDescargar.Click
        If dgvDatos.CurrentRow.Cells("IdImportacion").Value = 0 Then
            MsgBox("¡Selecccione un registro, tenga cuidado...!")
        Else
            Descargar()
            dgvDatos.Select()
        End If
    End Sub

    Private Sub DeleteTable()
        Dim FileToDelete As String
        FileToDelete = "D:\PSION\CODIGOS.DBF"

        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
    End Sub

    Private Sub biIngresoMasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biIngresoMasivo.Click, miIngresoMasivo.Click
        Try
            Dim frm As New frmAlmacen_FacturaImportacion_IngMas
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al generar Facturas de Importación MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImpresionMasiva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImpresionMasiva.Click
        Try
            Dim frm As New frmAlmacen_FacturaImportacion_ImpMas
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()      
        Catch ex As Exception
            MsgBox("Error al imprimir conformidad de Facturas de Importación MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biChequearMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biChequearMasivo.Click, miChequearMasivo.Click
        Try
            Dim frm As New frmAlmacen_FacturaImportacion_TrasCheqMas
            frm.Opcion = False
            frm.Seleccion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al Chequear Facturas de Importación MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biTrasladarMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biTrasladarMasivo.Click, miTrasladarMasivo.Click
        Try
            Dim frm As New frmAlmacen_FacturaImportacion_TrasCheqMas
            frm.Opcion = True
            frm.Seleccion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al Trasladar Facturas de Importación MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSeleccionMasiva_Click(sender As Object, e As System.EventArgs) Handles biSeleccionMasiva.Click
        Try
            Dim frm As New frmAlmacen_FacturaImportacion_TrasCheqMas
            frm.Opcion = False
            frm.Seleccion = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al Chequear Detalles de Facturas de Importación: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGenerarMTI_Click(sender As Object, e As System.EventArgs) Handles biGenerarMTI.Click, miGenerarMTI.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmAlmacen_FacturaImportacion_GenerarMTI
                frm.IdImportacion = dgvDatos.CurrentRow.Cells("IdImportacion").Text
                frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Actualizar()
                End If                
            End If
        Catch ex As Exception
            MsgBox("Error al Generar MTI de Factura de Importación: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizarFecha_Click(sender As System.Object, e As System.EventArgs) Handles biActualizarFecha.Click, miActualizarFecha.Click
        Try
            Dim frm As New frmAlmacen_FacturaImportacion_ActFecha
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al actualizar la Fecha de las F/I en estado GENERADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class