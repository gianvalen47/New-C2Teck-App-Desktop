Public Class frmMovimientosAlmacen

    Private oMaestroService As New MaestroService.MaestroClient
    Private oMoviAlmacenService As New MoviAlmacenService.MoviAlmacenServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    Public IdLocacion As String
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtTipoDocumentos As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbIdSerieDoc.KeyPress _
                      , cmbEstado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbIdSerieDoc.KeyPress _
                      , cmbEstado.KeyPress _
                      , btnBuscar.KeyPress _
                      , txtanio.KeyPress _
                      , cmbMes.KeyPress
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

                If CInt(row.Cells("IdMovimiento").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmMovimientosAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
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
   
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chkCliente.Enabled = False
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(PictureBox1, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        state_Search = False
        llenarCombos()
        txtIdCliente.Text = "(Todos)"
        txtanio.Value = Today.Year
        cmbMes.Value = Today.Month
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oMoviAlmacenService) = False Then
                oMoviAlmacenService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    'Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal codigoCampo As String, ByVal tipodoc As Integer)
    '    If type_process = "update" Or type_process = "insert" Then
    '        state_Search = False
    '        cmbIdSerieDoc.Value = tipodoc
    '        txtanio.Value = Today.Year
    '        cmbMes.Value = Today.Month
    '        state_Search = True
    '        cmbEstado.Value = ""
    '        txtNumDoc.Text = codigoCampo
    '    End If
    'End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then

            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miActualizar.Enabled = False
            miimprimir.Enabled = False

            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biActualizar.Enabled = False
            biimprimir.Enabled = False

        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
            miActualizar.Enabled = True
            miimprimir.Enabled = True

            biMostrar.Enabled = True
            biEliminar.Enabled = True
            biActualizar.Enabled = True
            biimprimir.Enabled = True

            Dim lestado As String

            lestado = dgvDatos.CurrentRow.Cells("Estado").Text

            biEliminar.Enabled = IIf(lestado = "IMPRESO", False, True)
            miEliminar.Enabled = IIf(lestado = "IMPRESO", False, True)
            biActualizar.Enabled = IIf(lestado = "IMPRESO", False, True)
            miActualizar.Enabled = IIf(lestado = "IMPRESO", False, True)

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
            Dim frm As New frmMovimientoAlmacen
            Dim lEstado As String

            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text

            frm.state_button = True
            frm.IdMovimiento = dgvDatos.CurrentRow.Cells("IdMovimiento").Text
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                actualizar()
                dtDatos = Nothing

                If frm.type_process = "update" Then
                    ' limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text, frm.cmbIdSerieDoc.Value)
                    actualizar()
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
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdMovimiento").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oMoviAlmacenService.Borrar(dgvDatos.CurrentRow.Cells("IdMovimiento").Text, Session.sCodUsu)

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
                dtDatos = oMoviAlmacenService.Filtrar(txtanio.Value _
                                                     , cmbMes.Value _
                                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                     , cmbIdSerieDoc.Value _
                                                     , toNumber(IdCliente) _
                                                     , cmbEstado.Value _
                                                     , toNumber(txtNumDoc.Text)).Tables(0)
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
            Dim frm As New frmMovimientoAlmacen
            frm.state_button = False
            frm.IdLocacion = cmbIdLocacion.Value
            frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", frm.IdLocacion)) / 100

            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text, frm.cmbIdSerieDoc.Value)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdMovimiento)
                    mostrar()
                    actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdMovimiento").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Private Sub imprimir()
        If ValidaCodigoSeleccionado() Then

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
            ElseIf dgvDatos.CurrentRow.Cells("IdMovimiento").Text = Nothing Then
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
            ''======================================= TIPOS DE DOCUMENTOS ================================================
            'dtTipoDocumentos = oMaestroService.MostrarSerieDocumento(cmbIdLocacion.Value, 2, "").Tables(0)
            'dtTipoDocumentos.Rows.InsertAt(getRowTodos(dtTipoDocumentos), 0)
            'cmbIdSerieDoc.DataSource = dtTipoDocumentos
            'cmbIdSerieDoc.DropDownList.DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
            'cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
            'cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
            'cmbIdSerieDoc.SelectedIndex = 0
            'dtTipoDocumentos = Nothing
            '======================================= ESTADOS ================================================
            dtEstados = oMoviAlmacenService.MostrarEstados
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtNumDoc.TextChanged
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
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()

    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub

    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                   cmbIdSerieDoc.ValueChanged _
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
    Private Sub txtFecIni_NoneButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub txtFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub txtFecFin_NoneButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub txtFecFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            PictureBox1.Enabled = False
            txtIdCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            PictureBox1.Enabled = True
        End If
    End Sub
    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        actualizar()

    End Sub


    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.Dispose()

    End Sub

    Private Sub txtanio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtanio.Click
        listaDatos()
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

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                    biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                    miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                    miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub


    Private Sub cmbIdLocacion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbIdLocacion.ValueChanged

        dtTipoDocumentos = oMaestroService.MostrarSerieDocumento(cmbIdLocacion.Value, 2, "").Tables(0)
        dtTipoDocumentos.Rows.InsertAt(getRowTodos(dtTipoDocumentos), 0)
        cmbIdSerieDoc.DataSource = dtTipoDocumentos
        cmbIdSerieDoc.DropDownList.DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
        cmbIdSerieDoc.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Descripcion").ToString
        cmbIdSerieDoc.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
        cmbIdSerieDoc.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdSerieDoc").ToString
        cmbIdSerieDoc.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Descripcion").ToString
        cmbIdSerieDoc.SelectedIndex = 0
        dtTipoDocumentos = Nothing

        listaDatos()
    End Sub

    Private Sub biimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biimprimir.Click
        imprimir()
    End Sub

    Private Sub miimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miimprimir.Click
        imprimir()
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

    Private Sub txtNumDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumDoc.TextChanged
        listaDatos()
    End Sub

End Class