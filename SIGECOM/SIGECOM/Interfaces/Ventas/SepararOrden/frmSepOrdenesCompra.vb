Imports System.ServiceModel
Imports System.Net

Public Class frmSepOrdenesCompra

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


    Private Sub frmSepOrdenesCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oOrdenCompraService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oOrdenCompraService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oOrdenCompraService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmSepOrdenesCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSepOrdenesCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 155)
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

    Private Sub llenarCombos()
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

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                'dtDatos = oOrdenCompraService.Filtrar(txtanio.Value _
                '                                     , cmbMes.Value _
                '                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                '                                     , toNumber(IdCliente) _
                '                                     , cmbEstado.Value _
                '                                     , toBlank(txtNumOrden.Text)).Tables(0)
                If ckSeparados.Checked Then
                    dtDatos = oOrdenCompraService.MostrarOrdenesAprobadoSeparar(Session.sCodEmp, txtanio.Value _
                                                     , cmbMes.Value _
                                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                     , toNumber(IdCliente) _
                                                     , toBlank(txtNumOrden.Text)).Tables(0)
                Else
                    dtDatos = oOrdenCompraService.MostrarOrdenesPorAprobar(Session.sCodEmp, txtanio.Value _
                                                     , cmbMes.Value _
                                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                     , toNumber(IdCliente) _
                                                     , toBlank(txtNumOrden.Text)).Tables(0)
                End If


                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                AprOrden = oMaestroService.MostrarDato("Maestro.Parametros ", "AprOrden", "IdLocacion", cmbIdLocacion.Value)
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtNumOrden.TextChanged, txtanio.TextChanged, cmbMes.ValueChanged, cmbOficinas.ValueChanged, cmbIdLocacion.ValueChanged, cmbEstado.ValueChanged, txtIdCliente.TextChanged
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

    Private Sub enableOpciones()

        If dgvDatos.RowCount < 1 Then
            biMostrar.Enabled = False
            miMostrar.Enabled = False
            biAprobar.Enabled = False
        Else
            biMostrar.Enabled = True
            miMostrar.Enabled = True
            biAprobar.Enabled = True
        End If

    End Sub

    Private Sub txtanio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtanio.Click
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

    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Orden de Compra actual."
    End Sub

    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
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

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                  biMostrar.MouseLeave, biSalir.MouseLeave, miMostrar.MouseLeave
        sslError.Text = ""
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

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmSepOrdenCompra
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

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal nro_Orden As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEstado.Value = ""
            txtNumOrden.Text = nro_Orden
        End If
    End Sub

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

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAprobar_Click(sender As Object, e As EventArgs) Handles biAprobar.Click
        If ValidaCodigoSeleccionado() Then
            Dim frm As New frmSepararOrden_Aprobar
            frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Text
            frm.NumOrden = dgvDatos.CurrentRow.Cells("NumOrden").Text
            'frm.ShowDialog()
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
            End If


        End If
    End Sub

    Private Sub ckSeparados_CheckedChanged(sender As Object, e As EventArgs) Handles ckSeparados.CheckedChanged
        listaDatos()

    End Sub
End Class