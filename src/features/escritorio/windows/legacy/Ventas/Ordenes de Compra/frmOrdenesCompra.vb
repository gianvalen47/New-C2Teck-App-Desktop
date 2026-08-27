Imports System.ServiceModel
Imports System.Net
Public Class frmOrdenesCompra
    Private oMaestroService As New MaestroService.MaestroClient
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    Private AprOrden As Boolean
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClientes As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable


    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
                      , cmbMes.KeyPress _
                      , txtNumOrden.KeyPress
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
            txtNumOrden.Select()

        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
 _
                      , cmbMes.KeyPress _
                      , btnBuscar.KeyPress
        ', dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    'Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumOrden.KeyPress
    '    If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
    '        e.KeyChar = Chr(0)
    '    End If
    'End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdOrden").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmOrdenesCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 22)
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
        'txtanio.Value = Today.Year
        'cmbMes.Value = Today.Month
        txtanio.Value = Session.sFecha.Year
        cmbMes.Value = Session.sFecha.Month


        IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        state_Search = True
        listaDatos()
        dgvDatos.Select()

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oOrdenCompraService) = False Then
                oOrdenCompraService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal nro_Orden As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEstado.Value = ""
            txtNumOrden.Text = nro_Orden
        End If
    End Sub
    Private Sub enableOpciones()

        biAprobar.Visible = IIf(Session.CodPerfil = "02", True, False)
        miAprobar.Visible = IIf(Session.CodPerfil = "02", True, False)

        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biEnviar.Enabled = False
            biGenerar.Enabled = False
            biAprobar.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biEnviarCre.Enabled = False
            biSugerir.Enabled = False
            biGenerarPedido.Enabled = False
            biActualizarOrden.Enabled = False

            miImprimir.Enabled = False
            miEnviar.Enabled = False
            miGenerar.Enabled = False
            miAprobar.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miEnviarCre.Enabled = False
            miSugerir.Enabled = False
            miGenerarPedido.Enabled = False
            miActualizarOrden.Enabled = False

        Else
            Dim lEstado
            Dim lTotal As Decimal
            Dim lSugerido As Integer

            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            lTotal = dgvDatos.CurrentRow.Cells("TotNeto").Value
            lSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Value

            biImprimir.Enabled = True 'IIf(lEstado <> "GENERADO", True, False)
            'biEnviar.Enabled = IIf(AprOrden, IIf(lEstado = "GENERADO" And lTotal > 0, True, False), False)
            biEnviar.Enabled = IIf(lEstado = "GENERADO" And lTotal > 0, True, False)
            biAprobar.Enabled = IIf(lEstado = "ENVIADO", True, False)
            biGenerar.Enabled = IIf(AprOrden, IIf((lEstado = "APROBADO" Or lEstado = "PARCIAL") And lTotal > 0 And lSugerido = 0, True, False), IIf(lEstado <> "ATENDIDO" And lEstado <> "RECHAZADO" And lEstado <> "CREDITOS" And lTotal > 0 And lSugerido = 0, True, False))
            biEliminar.Enabled = IIf(lEstado = "GENERADO", True, False)
            biEnviarCre.Enabled = IIf(lSugerido > 0 And lEstado <> "CREDITOS", True, False)
            biSugerir.Enabled = IIf(lEstado = "GENERADO", True, False)
            biGenerarPedido.Enabled = True
            biActualizarOrden.Enabled = IIf(lEstado <> "ATENDIDO", True, False)

            miImprimir.Enabled = True  'IIf(lEstado <> "GENERADO", True, False)
            'miEnviar.Enabled = IIf(AprOrden, IIf(lEstado = "GENERADO" And lTotal > 0, True, False), False)
            miEnviar.Enabled = IIf(lEstado = "GENERADO" And lTotal > 0, True, False)
            miAprobar.Enabled = IIf(lEstado = "ENVIADO", True, False)
            miGenerar.Enabled = IIf(AprOrden, IIf((lEstado = "APROBADO" Or lEstado = "PARCIAL") And lTotal > 0 And lSugerido = 0, True, False), IIf(lEstado <> "ATENDIDO" And lEstado <> "RECHAZADO" And lEstado <> "CREDITOS" And lTotal > 0 And lSugerido = 0, True, False))
            miEliminar.Enabled = IIf(lEstado = "GENERADO", True, False)
            miEnviarCre.Enabled = IIf(lSugerido > 0 And lEstado <> "CREDITOS", True, False)
            miSugerir.Enabled = IIf(lEstado = "GENERADO", True, False)
            miGenerarPedido.Enabled = True
            miActualizarOrden.Enabled = IIf(lEstado <> "ATENDIDO", True, False)

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
    Private Sub mostrar()
        Try
            Dim frm As New frmOrdenCompra
            Dim lEstado As String
            frm.AprOrden = AprOrden  'oMaestroService.MostrarDato("Maestro.Parametros ", "AprOrden", "IdLocacion", cmbIdLocacion.Value)
            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            frm.state_button = True
            frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Text
            frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Value
            frm.edicion = False
            frm.editable = IIf(lEstado = "GENERADO" Or lEstado = "CREDITOS", True, False)
            frm.lblLocacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtNumOrden.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdOrden)
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
            If MsgBox("¿Está seguro de ELIMINAR la Orden de Compra Nº " + dgvDatos.CurrentRow.Cells("NumOrden").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oOrdenCompraService.Borrar(dgvDatos.CurrentRow.Cells("IdOrden").Text, Session.sCodUsu)
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
                dtDatos = oOrdenCompraService.Filtrar(txtanio.Value _
                                                     , cmbMes.Value _
                                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                     , toNumber(IdCliente) _
                                                     , cmbEstado.Value _
                                                     , toBlank(txtNumOrden.Text)).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                AprOrden = oMaestroService.MostrarDato("Maestro.Parametros ", "AprOrden", "IdLocacion", cmbIdLocacion.Value)
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Nuevo()
        Try
            Dim frm As New frmOrdenCompra
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.IdLocacion = cmbIdLocacion.Value
            frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", frm.IdLocacion))
            frm.AprOrden = AprOrden  'oMaestroService.MostrarDato("Maestro.Parametros ", "AprOrden", "IdLocacion", cmbIdLocacion.Value)
            frm.lblLocacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumOrden.Text)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdOrden)
                    mostrar()
                    Actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            dtEstados = oOrdenCompraService.MostrarEstados
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
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtNumOrden.TextChanged
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

    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbIdLocacion.ValueChanged _
                  , cmbEstado.ValueChanged _
                  , cmbMes.ValueChanged
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
    Private Sub txtanio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtanio.Click
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

    Private Sub biEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        If MsgBox("¿Está seguro de ENVIAR la orden para ser aprobada?", MsgBoxStyle.YesNo, "Enviar Orden") = MsgBoxResult.Yes Then
            Try
                Dim IdOrden As Integer
                Dim estado_process As Boolean
                IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Text
                estado_process = oOrdenCompraService.Aprobar(IdOrden, "EN", Session.sCodUsu, "")
                If estado_process = True Then
                    listaDatos()
                    RowPossesion(dgvDatos, IdOrden)
                    enableOpciones()
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Catch ex As Exception
                MsgBox("ERROR [ENVIO]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Sub biAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        Try
            If Session.CodPerfil = "02" Then
                Dim frm As New frmAprobarOrdenCompra
                frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdOrden)
                    enableOpciones()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [APROB]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.Click, miGenerar.Click
        Try
            Dim frm As New frmOrdenCompra_GenerarDocumento
            frm.Text = "Generar G/F "
            frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Text
            frm.IdLocacion = cmbIdLocacion.Value
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm.IdOrden)
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdOrden").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRefrescar.Click, miActualizar.Click
        Actualizar()
    End Sub


    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biImprimir.MouseLeave, biAprobar.MouseLeave, biEnviar.MouseLeave, biGenerar.MouseLeave,
                                     biNuevo.MouseLeave, biMostrar.MouseLeave, biEnviarCre.MouseLeave, biSugerir.MouseLeave,
                                    biEliminar.MouseLeave, biRefrescar.MouseLeave, biSalir.MouseLeave,
                                    miImprimir.MouseLeave, miAprobar.MouseLeave, miEnviar.MouseLeave, miGenerar.MouseLeave,
                                     miNuevo.MouseLeave, miMostrar.MouseLeave, miEnviarCre.MouseLeave, miSugerir.MouseLeave,
                                    miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, miGenerarPedido.MouseLeave, biGenerarPedido.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Orden de Compra actual."
    End Sub

    Private Sub Enviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar al jefe de area para la Aprobación de la orden de compra actual."
    End Sub
    Private Sub Generar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.MouseEnter, miGenerar.MouseEnter
        sslError.Text = "Generar Guia de Remision/Factura al Contado a partir de la Orden de Compra actual."
    End Sub

    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Orden de Compra."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Orden de Compra actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Orden de Compra actual."
    End Sub

    Private Sub biAprobar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar/Rechazar Orden de Compra actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRefrescar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Sugerir_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biSugerir.MouseEnter, miSugerir.MouseEnter
        sslError.Text = "Sugerir Factor o Descuento a la Orden de Compra."
    End Sub
    Private Sub EnviarCreditos_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEnviarCre.MouseEnter, miEnviarCre.MouseEnter
        sslError.Text = "Enviar a Créditos"
    End Sub
    Private Sub GenerarPedido_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGenerarPedido.MouseEnter, miGenerarPedido.MouseEnter
        sslError.Text = "Generar Pedido Interno de la Orden de Compra"
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

    Private Sub biSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.Click, miSugerir.Click
        Try
            If toNumber(dgvDatos.CurrentRow.Cells("IdSugerido").Text) > 0 Then
                Dim factor As Double
                Dim dscto As Double
                factor = dgvDatos.CurrentRow.Cells("FactorSug").Text
                dscto = dgvDatos.CurrentRow.Cells("DsctoSug").Text
                If factor + dscto = 0 And dgvDatos.CurrentRow.Cells("TotNetoSug").Text Then
                    MsgBox("No puede hacer sugerencias por Documento, por que ya se hizo a nivel de Detalle ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If

            Dim frm As New frmOrdenCompra_SugerirCabecera
            frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Text
            frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biEnviarCre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviarCre.Click, miEnviarCre.Click
        If ValidaCodigoSeleccionado() Then
            Try
                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ENVIAR la Orden de Compra Nº " + dgvDatos.CurrentRow.Cells("NumOrden").Text.ToString + " a Créditos para su aprobación ... ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                    Dim NomPc As String = Dns.GetHostName
                    Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
                    Dim estado_process As Boolean
                    estado_process = oOrdenCompraService.EnviarCreditos(dgvDatos.CurrentRow.Cells("IdOrden").Text, Session.sCodUsu, NomPc, DirIp.AddressList(0).ToString())
                    If estado_process = True Then
                        dtDatos = Nothing
                        Actualizar()
                        MsgBox("Se envió la Orden de Compra a Créditos correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ENVIAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
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

    Private Sub biConsultarSugerido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConsultarSugerido.Click, miConsultarSugerido.Click
        Try
            Dim frm As New frmGuiaRemision_ConsultarSugerido

            frm.IdCodigo = dgvDatos.CurrentRow.Cells("IdOrden").Text
            frm.TipoCodigo = "OC"
            frm.Text = "Precios Sugeridos de Orden de Compra Nº : " + dgvDatos.CurrentRow.Cells("NumOrden").Text.ToString
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If

        Catch ex As Exception
            MsgBox("Error al consultar precios sugeridos : " + ex.Message)
        End Try
    End Sub

    Private Sub biImprimir_Click(sender As Object, e As EventArgs) Handles biImprimir.Click, miImprimir.Click

        Dim forma As New frmReportes
        Dim dtReporte As New DataTable
        Dim reporte As New rptVenOrdenCompra

        dtReporte = oOrdenCompraService.Imprimir(dgvDatos.CurrentRow.Cells("IdOrden").Text).Tables(0)

        If dtReporte.Rows.Count = 0 Then
            MsgBox("No hay datos a mostrar")
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


            forma.Text = "Reporte de Orden de Compra"
            forma.ShowDialog()
        End If

    End Sub

    Private Sub biGenerarPedido_Click(sender As System.Object, e As System.EventArgs) Handles biGenerarPedido.Click, miGenerarPedido.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmOrdenCompra_GenerarPedido
                frm.IdOrden = toNumber(dgvDatos.CurrentRow.Cells("IdOrden").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Generar Pedido Interno de la Orden de Compra: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biVerEstados_Click(sender As System.Object, e As System.EventArgs) Handles biVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmOrdenCompra_Estados
                frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Value
                frm.Text = "Estados de la Orden de Compra Nº " & dgvDatos.CurrentRow.Cells("NumOrden").Value.ToString
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biArchivos_Click(sender As Object, e As EventArgs) Handles biArchivos.Click, miArchivos.Click
        Try
            Dim frm As New frmOrdenCompra_Archivos
            frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Value
            frm.NumOrden = dgvDatos.CurrentRow.Cells("NumOrden").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LOS ARCHIVOS DE LA ORDEN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub txtIdCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdCliente.KeyDown
        If e.KeyCode = Keys.F12 Or Keys.Enter Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biMostrarSeparacion_Click(sender As Object, e As EventArgs) Handles biMostrarSeparacion.Click, miMostrarSeparacion.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmOrdenCompra_MostrarSeparacion
                frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Value
                frm.Text = "Separaciones de la Orden de Compra Nº " & dgvDatos.CurrentRow.Cells("NumOrden").Value.ToString
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizarOrden_Click(sender As Object, e As EventArgs) Handles biActualizarOrden.Click, miActualizarOrden.Click

        Try
            Dim frm As New frmOrdenCompra_ActualizarOrden
            frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Value
            frm.NumOrden = dgvDatos.CurrentRow.Cells("NumOrden").Value
            frm.Text = "Actualizar la orden de compra N°" & dgvDatos.CurrentRow.Cells("NumOrden").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class