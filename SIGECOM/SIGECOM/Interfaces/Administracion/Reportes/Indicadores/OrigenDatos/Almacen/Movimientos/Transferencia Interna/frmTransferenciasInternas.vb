Public Class frmTransferenciasInternas
    Private oMaestroService As New MaestroService.MaestroClient
    Private oTransferenciaService As New TransferenciaService.TransferenciaServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean


    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer

    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClientes As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
                      , txtIdCliente.KeyPress _
                      , cmbMes.KeyPress _
                      , txtNumJob.KeyPress

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
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
                      , txtIdCliente.KeyPress _
                      , cmbMes.KeyPress _
                      , txtNumJob.KeyPress _
                      , btnBuscar.KeyPress
        ' , dgvDatos.KeyPress _

        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
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

                If CInt(row.Cells("IdTransferencia").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmTransferenciasInternas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        state_Search = False
        llenarCombos()
        txtanio.Value = Today.Year
        cmbMes.Value = Today.Month
        IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        ' cmbEstado.Value = "GN"
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oTransferenciaService) = False Then
                oTransferenciaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    'Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal numero As String, ByVal codLocacion As Integer)
    '    state_Search = False
    '    If type_process = "update" Then
    '        cmbEstado.Value = ""
    '        txtNumDoc.Text = numero
    '    ElseIf type_process = "insert" Then
    '        'cmbEstado.Value = "GN"
    '        txtNumDoc.Text = numero
    '    End If
    '    cmbOficinas.Value = toNumber(oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodOfi", "IdLocacion", codLocacion))
    '    cmbIdLocacion.Value = codLocacion
    '    state_Search = True
    'End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            mitrasladar.Enabled = False
            miActualizar.Enabled = False

            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biImprimir.Enabled = False
            bitrasladar.Enabled = False
            biactualizar.Enabled = False

        Else

            miMostrar.Enabled = True
            miEliminar.Enabled = True
            miImprimir.Enabled = True
            miActualizar.Enabled = True
            mitrasladar.Enabled = True

            biMostrar.Enabled = True
            biEliminar.Enabled = True
            biImprimir.Enabled = True
            biactualizar.Enabled = True
            bitrasladar.Enabled = True

            Dim lestado As String
            Dim ltotal As Decimal

            lestado = dgvDatos.CurrentRow.Cells("Estado").Text
            ltotal = dgvDatos.CurrentRow.Cells("TotNeto").Value

            ' biEliminar.Enabled = IIf(lestado = "IN" Or lestado = "TR", False, True)
            'miEliminar.Enabled = IIf(lestado = "IN" Or lestado = "TR", False, True)
            biEliminar.Enabled = IIf(lestado = "TR", False, True)
            miEliminar.Enabled = IIf(lestado = "TR", False, True)
            'biactualizar.Enabled = IIf(lestado = "IN" Or lestado = "TR", False, True)
            'miActualizar.Enabled = IIf(lestado = "IN" Or lestado = "TR", False, True)
            bitrasladar.Enabled = IIf(lestado = "IN" Or lestado = "TR", False, True)
            mitrasladar.Enabled = IIf(lestado = "IN" Or lestado = "TR", False, True)


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
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try

        Return fila
    End Function
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub trasladar()
        If ValidaCodigoSeleccionado() Then
            Try
                Dim frm As New frmTransferenciaInterna_Transferir
                frm.Text = "Transferir Documento " + txtNumDoc.Text.ToString
                frm.IdTransferencia = dgvDatos.CurrentRow.Cells("IdTransferencia").Value
                frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Value
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    actualizar()
                End If
            Catch ex As Exception
                MsgBox("ERROR [TRASLADAR]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub mostrar()

        Try
            Dim frm As New frmTransferenciaInterna
            Dim lEstado As String

            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            frm.state_button = True
            frm.IdTransferencia = dgvDatos.CurrentRow.Cells("IdTransferencia").Text
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                actualizar()
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text, frm.IdLocacion)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdTransferencia)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If

            actualizar()

        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el T.I. Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oTransferenciaService.Borrar(dgvDatos.CurrentRow.Cells("IdTransferencia").Text, Session.sCodUsu)
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
                dtDatos = oTransferenciaService.Filtrar(txtanio.Value _
                                                     , cmbMes.Value _
                                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                     , toNumber(IdCliente) _
                                                     , cmbEstado.Value _
                                                     , toNumber(txtNumDoc.Text), txtNumJob.Text).Tables(0)

                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdTransferencia").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
        enableOpciones()
    End Sub
    Private Sub Nuevo()
        Try
            Dim frm As New frmTransferenciaInterna

            frm.state_button = False
            frm.btnEditar.Enabled = False
            frm.btnCancelar.Enabled = False
            frm.IdLocacion = cmbIdLocacion.Value
            frm.txtNumDoc.Text = oTransferenciaService.SugerirNumero(cmbIdLocacion.Value)
            frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", frm.IdLocacion))

            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text, frm.IdLocacion)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdTransferencia)
                    mostrar()
                    actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub imprimir()
        If ValidaCodigoSeleccionado() Then
            Try
                Dim forma As New frmReportes
                Dim reporte As New rpTransferenciaInterna
                Dim dtReporte As New DataTable
                Dim IdTransferencia As Integer = dgvDatos.CurrentRow.Cells("IdTransferencia").Text

                dtReporte = oTransferenciaService.ReporteTransferencia(IdTransferencia).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    'forma.crvReportes.RefreshReport = False
                    forma.Text = "Reporte de Pedidos Internos para Importar"

                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\TransferenciaInterna.xml")

                    forma.ShowDialog()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
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

            ElseIf dgvDatos.CurrentRow.Cells("IdTransferencia").Text = Nothing Then
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
            dtEstados = oTransferenciaService.MostrarEstados
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
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click

        mostrar()

    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click

        eliminar()

    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click

        mostrar()

    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()

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
    Private Sub txtIdCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCliente.ButtonClick
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
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
    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtIdCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            pboxLimpiarCliente.Enabled = True
            txtIdCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub bitrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bitrasladar.Click
        trasladar()

    End Sub


    Private Sub biactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.Click
        actualizar()

    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        imprimir()
    End Sub

    Private Sub mitrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mitrasladar.Click

        trasladar()

    End Sub

    Private Sub miImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click
        imprimir()

    End Sub
    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Transferencia Actual."
    End Sub

    Private Sub trasladar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bitrasladar.MouseEnter, mitrasladar.MouseEnter
        sslError.Text = "Trasladar a Otro Almacén."
    End Sub

    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Transferencia."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Transferencia Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Tranferencia Actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biImprimir.MouseLeave, bitrasladar.MouseLeave, biNuevo.MouseLeave, _
                                    biMostrar.MouseLeave, biEliminar.MouseLeave, biactualizar.MouseLeave, biSalir.MouseLeave, _
                                    miImprimir.MouseLeave, mitrasladar.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                    miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
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
End Class