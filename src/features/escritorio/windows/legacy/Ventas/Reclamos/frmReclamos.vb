Public Class frmReclamos
    Private oReclamos As New ReclamoService.ReclamoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtAlmacenes As DataTable
    Private dtEstados As DataTable
    Private dtOficinas As DataTable
    Private dtDatos As DataTable
    Private IdCliente As String


    Private Sub frmReclamos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
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

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oReclamos) = False Then
                oReclamos.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub frmReclamos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
              cmbEstado.KeyPress _
            , cmbIdLocacion.KeyPress _
            , txtCliente.KeyPress _
            , txtNumDoc.KeyPress _
            , cmbOficinas.KeyPress _
            , cbFecFinal.KeyPress _
            , cbFecInicio.KeyPress
        ', dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub frmReclamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 23)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        IdCliente = 0
        cmbEstado.Value = ""
        Dim Anio As Integer
        Dim Fecha As Date
        Fecha = Today
        ' Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
        Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = "01/01/" & Trim(Anio)
        'cbFecFinal.Value = Fecha
        cbFecFinal.Value = Session.sFecha
        listaDatos()
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
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdReclamo").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then

            biImprimir.Enabled = False
            biGenerar.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biActualizar.Enabled = False

            miImprimir.Enabled = False
            miGenerar.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miActualizar.Enabled = False

        Else
            Dim lEstado As String

            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text

            biImprimir.Enabled = True
            biGenerar.Enabled = IIf(lEstado = "ATENDIDO", False, True)
            biEliminar.Enabled = IIf(lEstado = "GENERADO", True, False)
            biActualizar.Enabled = True
            biMostrar.Enabled = True

            miImprimir.Enabled = True
            miGenerar.Enabled = IIf(lEstado = "ATENDIDO", False, True)
            miEliminar.Enabled = IIf(lEstado = "GENERADO", True, False)
            miActualizar.Enabled = True
            miMostrar.Enabled = True

        End If
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oReclamos.Filtrar(cbFecInicio.Value, cbFecFinal.Value, cmbIdLocacion.Value, toNumber(IdCliente), cmbEstado.Value, toNumber(txtNumDoc.Text)).Tables(0)
            'DataGridView1.DataSource = dtDatos
            dgvDatos.SetDataBinding(dtDatos, 0)

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub llenarCombos()
        Try
            dtEstados = oReclamos.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

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
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                txtCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            cmbOficinas.Select()
            listaDatos()
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Or Keys.Enter Then
            If btnCliente.Enabled = True Then
                btnCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizar.MouseLeave, biActualizar.MouseLeave, miEliminar.MouseLeave, biEliminar.MouseLeave, miGenerar.MouseLeave, biGenerar.MouseLeave, miImprimir.MouseLeave, biImprimir.MouseLeave, miMostrar.MouseLeave, biMostrar.MouseLeave, miNuevo.MouseLeave, biNuevo.MouseLeave, miSalir.MouseLeave, biSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biNuevo_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles miNuevo.MouseMove, biNuevo.MouseMove
        sslError.Text = "Crear Nuevo Reclamo de Garantía"
    End Sub

    Private Sub btnRefrescar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles miActualizar.MouseMove, biActualizar.MouseMove
        sslError.Text = "Actualizar los Datos del Formulario"
    End Sub

    Private Sub btnGenerar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles miGenerar.MouseMove, biGenerar.MouseMove
        sslError.Text = "Generar Documento Desde Reclamo"
    End Sub

    Private Sub btnSalir_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles miSalir.MouseMove, biSalir.MouseMove
        sslError.Text = "Salir de la Ventana Actual"
    End Sub

    Private Sub btnMostrar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles miMostrar.MouseMove, biMostrar.MouseMove
        sslError.Text = "Mostrar datos del Registro Seleccionado"
    End Sub

    Private Sub btnImprimir_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles miImprimir.MouseMove, biImprimir.MouseMove
        sslError.Text = "Imprimir Reclamo de Garantía Seleccionado"
    End Sub

    'Private Sub btnBorrar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles biSalir.MouseMove, miSalir.MouseMove
    '    sslError.Text = "Borrar Reclamo de Garantía Seleccionado"
    'End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtCliente.TextChanged, cbFecInicio.ValueChanged, cbFecFinal.ValueChanged, cmbIdLocacion.ValueChanged, cmbOficinas.ValueChanged, cmbEstado.ValueChanged, txtNumDoc.TextChanged
        listaDatos()
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click, miNuevo.Click
        Try
            Dim frm As New frmReclamo
            frm.IdLocacion = cmbIdLocacion.Value
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.Text = "Registrar Nuevo Reclamo de Garantía"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdReclamo)
                    biMostrar_Click(sender, e)
                    biActualizar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        Try
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
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmReclamo
                'Dim lEstado As String
                'lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
                frm.state_button = True
                frm.IdReclamo = dgvDatos.CurrentRow.Cells("IdReclamo").Text
                frm.Estado = dgvDatos.CurrentRow.Cells("Estado").Text
                frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
                frm.Text = "RECLAMO DE GARANTÍA N°: " & dgvDatos.CurrentRow.Cells("IdReclamo").Text

                'frm.edicion = False
                'frm.editable = IIf(lEstado = "GN" Or lEstado = "AP", True, False)
                'frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    If frm.type_process = "update" Then
                        '    limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text)
                        listaDatos()
                        RowPossesion(dgvDatos, frm.IdReclamo)
                    Else
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                biActualizar_Click(sender, e)
            End If

        Catch ex As Exception
            MsgBox("ERROR [MOSTRAR]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells("IdReclamo").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.Click, miGenerar.Click
        If ValidaCodigoSeleccionado() Then
            Try
                Dim frm As New frmReclamoGenerar
                frm.Text = "Generar Guía de Devolución/Guía de Remisión"
                frm.IdReclamo = dgvDatos.CurrentRow.Cells("IdReclamo").Text
                frm.IdLocacion = cmbIdLocacion.Value
                frm.Resultado = dgvDatos.CurrentRow.Cells("Resultado").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            Catch ex As Exception
                MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está seguro de ELIMINAR el Reclamo Nº " + dgvDatos.CurrentRow.Cells("IdReclamo").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oReclamos.Borrar(dgvDatos.CurrentRow.Cells("IdReclamo").Text, Session.sCodUsu)
                    If estado_process = True Then
                        listaDatos()
                        'actualizar()
                        MsgBox("El Reclamo fue Eliminada correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ELIMINAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdReclamo").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
        enableOpciones()
    End Sub
    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpReclamo

            dtReporte = oReclamos.Imprimir(dgvDatos.CurrentRow.Cells("IdReclamo").Text).Tables(0)

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

                forma.Text = "Reclamo de Garantia"
                forma.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        biMostrar_Click(sender, e)
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

    Private Sub biDocGenerados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDocGenerados.Click, miDocGenerados.Click
        Try
            Dim frm As New frmReclamo_Documentos
            frm.IdReclamo = dgvDatos.CurrentRow.Cells("IdReclamo").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class