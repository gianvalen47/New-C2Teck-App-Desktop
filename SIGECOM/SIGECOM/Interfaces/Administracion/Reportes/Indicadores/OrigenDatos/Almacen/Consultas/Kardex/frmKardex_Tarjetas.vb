Public Class frmKardex_Tarjetas


    Private oMaestroService As New MaestroService.MaestroClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClases As DataTable
    Private dtRubros As DataTable

    Private Sub txtCodMer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMer.KeyDown
        If e.KeyCode = Keys.Enter Then
            Validar()
        End If
    End Sub

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtCodMer.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbIdClase.KeyPress _
                      , cmbCodRub.KeyPress _
                      , txtUbiMer.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
            txtCodMer.Select()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown

        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrar()
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtCodMer.Select()
        End If

    End Sub
    Private Sub frmKardex_Tarjetas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtCodMer.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbIdClase.KeyPress _
                      , cmbCodRub.KeyPress _
                      , btnBuscar.KeyPress _
                      , txtUbiMer.KeyPress
        ', dgvDatos.KeyPress
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


    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        state_Search = False
        llenarCombos()
        state_Search = True
        listaDatos()
        txtCodMer.Select()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            biMostrar.Enabled = False
        Else
            miMostrar.Enabled = True
            biMostrar.Enabled = True
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
            Dim frm As New frmKardex_Tarjeta
            frm.state_button = True
            frm.IdLocacion = dgvDatos.CurrentRow.Cells("IdLocacion").Text
            frm.txtCodMer.Text = dgvDatos.CurrentRow.Cells("CodMer").Text
            frm.Text = " CONSULTA DE TARJETAS DE INVENTARIO   -   OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, frm.txtCodMer.Text)
            End If
            txtCodMer.Select()
            txtCodMer.Clear()
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Actualizar()
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
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
            '======================================= CLASES ================================================
            dtClases = oMaestroService.MostrarClaseMerca.Tables(0)
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
            dtRubros = oMaestroService.MostrarRubros.Tables(0)
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
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtCodMer.TextChanged, txtUbiMer.TextChanged
        listaDatos()

    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
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
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Actualizar()

    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbIdLocacion.ValueChanged _
                  , cmbIdClase.ValueChanged _
                  , cmbCodRub.ValueChanged
        listaDatos()
        txtCodMer.Focus()
    End Sub
    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, "").Tables(0)
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
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Datos del Registro Actual."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del  Formulario Actual."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biMostrar.MouseLeave, _
                                    biSalir.MouseLeave, biActualizar.MouseLeave, _
                                    miMostrar.MouseLeave, _
                                    miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        Actualizar()
    End Sub
    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Validar()
        Try
            If Len(Trim(txtCodMer.Text)) > 0 Then

                If oLocacionMercaderiaService.Buscar(cmbIdLocacion.Value, txtCodMer.Text) Then
                    If ValidaCodigoSeleccionado() Then
                        mostrar()
                    End If
                Else
                    MsgBox("No existe el codigo ingresado en este Almacen, Verifique.!!!!", MsgBoxStyle.Information, "No Existe")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If


    End Sub

  
End Class