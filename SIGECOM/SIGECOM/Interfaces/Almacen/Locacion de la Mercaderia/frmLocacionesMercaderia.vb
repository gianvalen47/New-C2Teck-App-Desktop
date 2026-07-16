Public Class frmLocacionesMercaderia

    Private oMaestroService As New MaestroService.MaestroClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oMercaderia As New MercaderiaService.MercaderiaServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClases As DataTable
    Private dtRubros As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtCodMer.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbIdClase.KeyPress _
                      , cmbCodRub.KeyPress _
                      , txtDescripcion.KeyPress _
                      , txtUbiMer.KeyPress
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
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtCodMer.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbIdClase.KeyPress _
                      , cmbCodRub.KeyPress _
                      , btnBuscar.KeyPress _
                      , txtDescripcion.KeyPress _
                      , txtUbiMer.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CStr(row.Cells("CodMer").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmLocacionesMercaderia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 9)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

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
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
            If isClosed(oMercaderia) = False Then
                oMercaderia.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub    
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal codigoCampo As String, ByVal cod_almacen As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbOficinas.Value = cod_almacen
            cmbIdClase.Value = 0
            cmbCodRub.Value = ""
            txtCodMer.Text = codigoCampo
        End If
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miActualizar.Enabled = False
            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False

            biactualizar.Enabled = False
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
        Else
            miActualizar.Enabled = True
            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = True

            biactualizar.Enabled = True
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = True
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
            Dim frm As New frmLocacionMercaderia
            frm.state_button = True
            frm.btnGuardar.Enabled = False
            frm.btnDeshacer.Enabled = False
            frm.IdLocacion = dgvDatos.CurrentRow.Cells("IdLocacion").Text
            frm.txtCodMer.Text = dgvDatos.CurrentRow.Cells("CodMer").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtCodMer.Text, frm.Oficina)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.txtCodMer.Text)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oLocacionMercaderiaService.Borrar(toNull(dgvDatos.CurrentRow.Cells("IdLocacion").Text), toNull(dgvDatos.CurrentRow.Cells("CodMer").Text))
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
                Dim registro As New LocacionMercaderiaService.LocacionMercaderia
                Dim mercaderia As New LocacionMercaderiaService.Mercaderia
                Dim locacion As New LocacionMercaderiaService.Locacion
                Dim rubro As New LocacionMercaderiaService.Rubro
                Dim clase As New LocacionMercaderiaService.ClaseMerca

                If toNumber(cmbIdLocacion.Value) = 0 Then
                    locacion.IdLocacion = -1
                    registro.Locacion = locacion
                Else
                    locacion.IdLocacion = toNumber(cmbIdLocacion.Value)
                    registro.Locacion = locacion
                End If
                mercaderia.CodMer = toBlank(txtCodMer.Text)
                mercaderia.DesMer1 = toBlank(txtDescripcion.Text)
                rubro.CodRub = toBlank(cmbCodRub.Value)
                mercaderia.Rubro = rubro
                clase.IdClase = toNumber(cmbIdClase.Value)
                mercaderia.ClaseMerca = clase
                registro.Mercaderia = mercaderia
                registro.UbiMer = toBlank(txtUbiMer.Text)

                dtDatos = oLocacionMercaderiaService.Filtrar(registro).Tables(0)
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
            Dim frm As New frmLocacionMercaderia
            frm.state_button = False
            frm.btnEditar.Enabled = False
            frm.btnCancelar.Enabled = False
            frm.IdLocacion = cmbIdLocacion.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                limpiaOpcionesBusqueda("insert", frm.txtCodMer.Text, frm.Oficina)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.txtCodMer.Text)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("CodMer").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Private Sub Imprimir()
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
            ElseIf dgvDatos.CurrentRow.Cells("CodMer").Text = Nothing Then
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
            dtOficinas = oLocacionMercaderiaService.MostrarOficinasKardex(Session.sCodEmp, Session.sCodUsu).Tables(0) 'oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
            '======================================= CLASES ================================================
            dtClases = oMercaderia.MostrarClasePorEmpresa(Session.sCodEmp).Tables(0)
            dtClases.Rows.InsertAt(getRowTodos(dtClases), 0)
            cmbIdClase.DataSource = dtClases
            cmbIdClase.DropDownList.DataMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.DropDownList.DisplayMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.DropDownList.ValueMember = dtClases.Columns("IdClase").ToString
            cmbIdClase.DropDownList.Columns(0).DataMember = dtClases.Columns("IdClase").ToString
            cmbIdClase.DropDownList.Columns(1).DataMember = dtClases.Columns("NomClas").ToString
            cmbIdClase.SelectedIndex = 0
            dtClases = Nothing
            '======================================= RUBROS ================================================
            dtRubros = oMercaderia.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbCodRub.DataSource = dtRubros
            cmbCodRub.DropDownList.DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.DisplayMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.DropDownList.ValueMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRub").ToString
            cmbCodRub.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRub").ToString
            cmbCodRub.SelectedIndex = 0
            dtRubros = Nothing

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
        Me.Dispose()
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
                    cmbIdLocacion.ValueChanged _
                  , cmbIdClase.ValueChanged _
                  , cmbCodRub.ValueChanged
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

    Private Sub biactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.Click
        actualizar()

    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Imprimir()

    End Sub

    Private Sub miImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click
        Imprimir()
    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Mercaderia."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Documento Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Documento Actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Locacion Mercaderia ."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biNuevo.MouseLeave, biMostrar.MouseLeave, biImprimir.MouseLeave, _
                                    biEliminar.MouseLeave, biactualizar.MouseLeave, biSalir.MouseLeave, _
                                    miNuevo.MouseLeave, miMostrar.MouseLeave, miImprimir.MouseLeave, _
                                    miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged
        listaDatos()
    End Sub

    Private Sub txtCodMer_TextChanged(sender As Object, e As EventArgs) Handles txtCodMer.TextChanged
        listaDatos()
    End Sub

    Private Sub txtUbiMer_TextChanged(sender As Object, e As EventArgs) Handles txtUbiMer.TextChanged
        listaDatos()
    End Sub
End Class