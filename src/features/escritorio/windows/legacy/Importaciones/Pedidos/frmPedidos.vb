Public Class frmPedidos

    Private oMaestroService As New MaestroService.MaestroClient
    Private oPedidoService As New PedidoService.PedidoServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oPedidoDetService As New PedidoDetService.PedidoDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    Private IdLocacion As String
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClientes As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtIdPedido.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , txtFecIni.KeyPress _
                      , txtNumJob.KeyPress _
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
                mostrar()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtIdPedido.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , txtIdCliente.KeyPress _
                      , txtFecIni.KeyPress _
                      , txtFecFin.KeyPress _
                      , txtNumJob.KeyPress _
                      , btnBuscar.KeyPress _
                      , dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdPedido.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdPedido").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmPedidos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 53)
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
        state_Search = True
        listaDatos()
        dgvDatos.Select()

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oPedidoService) = False Then
                oPedidoService.Close()
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
    'Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal codigoCampo As String, ByVal cod_cliente As String)
    '    If type_process = "update" Or type_process = "insert" Then
    '        IdCliente = toNumber(cod_cliente)
    '        txtIdCliente.Text = oMaestroService.MostrarDato("SIGECOM.Maestro.Clientes", "DesCli", "IdCliente", IdCliente)
    '        txtFecIni.Text = ""
    '        txtFecFin.Text = ""
    '        txtIdPedido.Text = codigoCampo
    '    End If
    'End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miImprimir.Enabled = False
            miCambiarEstado.Enabled = False
            miActualizar.Enabled = False
            miDuplicar.Enabled = False
            miAtenderManual.Enabled = False

            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biImprimir.Enabled = False
            biCambiarEstado.Enabled = False
            biActualizar.Enabled = False
            biDuplicar.Enabled = False
            biAtenderManual.Enabled = False
        Else
            
            miMostrar.Enabled = True
            miEliminar.Enabled = False
            miImprimir.Enabled = True
            miCambiarEstado.Enabled = True
            miActualizar.Enabled = True
            miDuplicar.Enabled = True

            biMostrar.Enabled = True
            biEliminar.Enabled = False
            biImprimir.Enabled = True
            biCambiarEstado.Enabled = True
            biActualizar.Enabled = True
            biDuplicar.Enabled = True

            If (toBlank(dgvDatos.CurrentRow.Cells("Estado").Text) = "VISUALIZADO" Or toBlank(dgvDatos.CurrentRow.Cells("Estado").Text) = "PEDIDO" Or toBlank(dgvDatos.CurrentRow.Cells("Estado").Text) = "RECHAZADO" Or toBlank(dgvDatos.CurrentRow.Cells("TotNeto").Text) = 0) Then
                biCambiarEstado.Enabled = False
                miCambiarEstado.Enabled = False
            End If

            If (toBlank(dgvDatos.CurrentRow.Cells("Estado").Text) = "GENERADO" Or toBlank(dgvDatos.CurrentRow.Cells("Estado").Text) = "GN") Then
                biEliminar.Enabled = True
                miEliminar.Enabled = True
            End If

            If dgvDatos.CurrentRow.Cells("Estado").Text = "VISUALIZADO" And (Session.CodPerfil = "06" Or Session.CodPerfil = "42" Or Session.CodPerfil = "01") Then
                biAtenderManual.Enabled = True
                miAtenderManual.Enabled = True
            Else
                biAtenderManual.Enabled = False
                miAtenderManual.Enabled = False
            End If

            If dgvDatos.CurrentRow.Cells("Estado").Text = "GENERADO" Then
                sslError.Text = "Enviar el Pedido Actual"
                biCambiarEstado.Text = "Enviar"
                biCambiarEstado.Image = SIGECOM.My.Resources.Resources.Enviar_Pr
                biCambiarEstado.ToolTipText = "Enviar"
            ElseIf dgvDatos.CurrentRow.Cells("Estado").Text = "ENVIADO" Then
                sslError.Text = "Aprobar el Pedido Actual"
                biCambiarEstado.Text = "Aprobar"
                biCambiarEstado.Image = SIGECOM.My.Resources.Resources.Aceptar
                biCambiarEstado.ToolTipText = "Aprobar"
            Else
                sslError.Text = ""
                biCambiarEstado.Text = ""
                biCambiarEstado.Image = SIGECOM.My.Resources.Resources.Aceptar
                biCambiarEstado.ToolTipText = ""
            End If

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
            Dim frm As New frmPedido
            frm.state_button = True
            frm.txtIdPedido.Text = dgvDatos.CurrentRow.Cells("IdPedido").Text
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.IdLocacion = cmbIdLocacion.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtIdPedido.Text, frm.IdCliente)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.txtIdPedido.Text)

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
    Private Sub CambiarEstado()
        Try
            Dim frm As New frmCambiarEstado_PedidoInterno
            frm.IdPedido = toNumber(dgvDatos.CurrentRow.Cells("IdPedido").Text)
            frm.estado = dgvDatos.CurrentRow.Cells("Estado").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dgvDatos.CurrentRow.Cells("Estado").Text = frm.estado
                listaDatos()
                RowPossesion(dgvDatos, frm.IdPedido)
            Else
                dgvDatos.CurrentRow.Cells("Estado").Text = frm.estado
                listaDatos()
                RowPossesion(dgvDatos, frm.IdPedido)
            End If
        Catch ex As Exception
            MsgBox("ERROR [CAMBIAR ESTADO]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Generar()
        Try
            If ActualizaLista() Then
                Dim frm As New frmGenerarPedido_PedidoInterno
                frm.dtListaDetalles = dtDatos
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            Else
                MsgBox("Debe de pedir por lo menos un detalle del pedido ", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdPedido").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                Dim registro As New PedidoService.Pedido
                registro.IdPedido = toNumber(dgvDatos.CurrentRow.Cells("IdPedido").Text)
                estado_process = oPedidoService.Borrar(registro)

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
    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdPedido").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                Dim registro As New PedidoService.Pedido
                Dim locacion As New PedidoService.Locacion
                Dim cliente As New PedidoService.Cliente

                If toNumber(cmbIdLocacion.Value) = 0 Then
                    locacion.IdLocacion = -1
                    registro.Locacion = locacion
                Else
                    locacion.IdLocacion = toNumber(cmbIdLocacion.Value)
                    registro.Locacion = locacion
                End If
                cliente.IdCliente = toNumber(IdCliente)
                registro.Cliente = cliente
                registro.IdPedido = toNumber(txtIdPedido.Text)
                registro.NumOrden = txtNumOrden.Text
                registro.NumJob = toBlank(txtNumJob.Text)
                If toNull(txtFecIni.Text) <> Nothing Then
                    registro.FecIni = txtFecIni.Text
                End If
                If toNull(txtFecFin.Text) <> Nothing Then
                    registro.FecFin = txtFecFin.Text
                End If


                dtDatos = oPedidoService.Filtrar(registro).Tables(0)
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
            Dim frm As New frmPedido
            frm.state_button = False
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.IdLocacion = cmbIdLocacion.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ' limpiaOpcionesBusqueda("insert", frm.txtIdPedido.Text, frm.IdCliente)
                listaDatos()
                'mostrar
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.txtIdPedido.Text)
                    Actualizar()

                End If
                mostrar()
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
            ElseIf dgvDatos.CurrentRow.Cells("IdPedido").Text = Nothing Then
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
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Actualizar()

    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                  cmbIdLocacion.ValueChanged
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

    Private Sub txtFecFin_NoneButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecFin.NoneButtonClick
        listaDatos()
    End Sub
    Private Sub txtFecFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecFin.ValueChanged
        listaDatos()
    End Sub

    Private Sub txtFecIni_NoneButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecIni.NoneButtonClick
        listaDatos()
    End Sub
    Private Sub txtFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecIni.ValueChanged
        listaDatos()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Nuevo()

    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click, biImprimir.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmPedido_Imprimir
                frm.IdPedido = dgvDatos.CurrentRow.Cells("IdPedido").Value
                frm.IdLocacion = toNumber(cmbIdLocacion.Value)
                frm.IdCliente = toNumber(IdCliente)
                frm.NumOrden = toBlank(txtNumOrden.Text)
                frm.NumJob = toBlank(txtNumJob.Text)
                frm.FecIni = toBlank(txtFecIni.Text)
                frm.FecFin = toBlank(txtFecFin.Text)               
                frm.DesOfi = cmbOficinas.Text
                frm.DesAlm = cmbIdLocacion.Text
                frm.DesCli = txtIdCliente.Text
                frm.NumPedido = toNumber(txtIdPedido.Text)
                frm.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        'mostrarReporte()
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        Me.Dispose()
    End Sub
   
    Private Function ActualizaLista() As Boolean
        Try
            Dim dtDetalles As New DataTable
            dtDetalles = oPedidoDetService.Mostrar(dgvDatos.CurrentRow.Cells("IdPedido").Text).Tables(0)
            Dim Contador As Integer = 0
            For Each Fila As DataRow In dtDetalles.Rows
                Contador = Contador + Fila.Item("cAtender")
            Next
            If Contador > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR [TRANSFERIR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biCambiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCambiarEstado.Click
        CambiarEstado()

    End Sub

    Private Sub miCambiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCambiarEstado.Click
        CambiarEstado()

    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        Actualizar()

    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        biImprimir.MouseLeave, miImprimir.MouseLeave, miCambiarEstado.MouseLeave, biCambiarEstado.MouseLeave, _
        biNuevo.MouseLeave, miNuevo.MouseLeave, biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, _
        miEliminar.MouseLeave, miEstado.MouseLeave, biEstados.MouseLeave, biActualizar.MouseLeave, miActualizar.MouseLeave, _
        miDuplicar.MouseLeave, biDuplicar.MouseLeave, miSalir.MouseLeave, biCerrar.MouseLeave        
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Pedido Actual."
    End Sub

    Private Sub CambiarEstado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCambiarEstado.MouseEnter, biCambiarEstado.MouseEnter
        'sslError.Text = "Cambiar Estado al Pedido Actual."
        If dgvDatos.CurrentRow.Cells("Estado").Text = "GENERADO" Then
            sslError.Text = "Enviar el Pedido Actual"
            biCambiarEstado.Text = "Enviar"
            biCambiarEstado.Image = SIGECOM.My.Resources.Resources.Enviar_
        Else
            sslError.Text = "Aprobar el Pedido Actual"
            biCambiarEstado.Text = "Aprobar"
            biCambiarEstado.Image = SIGECOM.My.Resources.Resources.Aceptar
        End If
    End Sub

    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter, biNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Pedido."
    End Sub  
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter, biMostrar.MouseEnter
        sslError.Text = "Mostrar Pedido Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter, biEliminar.MouseEnter
        sslError.Text = "Eliminar Pedido Actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter, biActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.MouseEnter, biCerrar.MouseDown
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEstado.Click, biEstados.Click
        Try
            Dim frm As New frmPedidos_Estados

            frm.IdPedido = dgvDatos.CurrentRow.Cells("IdPedido").Text
            frm.Text = "Estados del pedido Nº : " + dgvDatos.CurrentRow.Cells("IdPedido").Text.ToString
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub biDuplicar_Click(sender As System.Object, e As System.EventArgs) Handles biDuplicar.Click, miDuplicar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmPedido_Duplicar
                frm.IdPedido = dgvDatos.CurrentRow.Cells("IdPedido").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al DUPLICAR Pedido Interno : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAtenderManual_Click(sender As System.Object, e As System.EventArgs) Handles biAtenderManual.Click, miAtenderManual.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmPedido_EstadoPedidoManual
                frm.IdPedido = toNumber(dgvDatos.CurrentRow.Cells("IdPedido").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al asignar Estado Pedido Manual al Pedido Interno : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class