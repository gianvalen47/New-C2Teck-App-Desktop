Public Class frmDocumentosTransito

    Private oMaestroService As New MaestroService.MaestroClient
    Private oDocumentoTransitoService As New DocumentoTransitoService.DocumentoTransitoServiceClient
    Private oDocumentoTransitoDetService As New DocumentoTransitoDetService.DocumentoTransitoDetServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtTipoDocumentos As DataTable


    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumFac.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbTipoDocumento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumFac.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbTipoDocumento.KeyPress _
                      , btnBuscar.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumFac.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdTransito").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmDocumentosTransito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            txtNumFac.Select()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        state_Search = False
        txtanio.Value = Date.Today.Year
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
            If isClosed(oDocumentoTransitoService) = False Then
                oDocumentoTransitoService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal codigoCampo As String, ByVal TipoDoc As Integer)
        If type_process = "update" Or type_process = "insert" Then
            cmbTipoDocumento.Value = TipoDoc
            txtNumFac.Text = codigoCampo
        End If
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miTrasladar.Enabled = False
            miEliminar.Enabled = False
            biMostrar.Enabled = False
            biTrasladar.Enabled = False
            biEliminar.Enabled = False

        Else
            If cbRecepcionado.Checked Then
                biTrasladar.Enabled = False
                biEliminar.Enabled = False
                biMostrar.Enabled = True
                miTrasladar.Enabled = False
                miEliminar.Enabled = False
                miMostrar.Enabled = True

            Else
                biTrasladar.Enabled = True
                biEliminar.Enabled = True
                biMostrar.Enabled = True
                miTrasladar.Enabled = True
                miEliminar.Enabled = True
                miMostrar.Enabled = True

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
    Private Sub mostrarTransferenciaInterna()
        Try
            Dim frm As New frmTransferenciasInterna
            frm.state_button = True
            frm.IdTransito = dgvDatos.CurrentRow.Cells("IdTransito").Text

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing

                If frm.type_process = "update" Then
                    listaDatos()
                End If
            Else
                If frm.type_process = "update" Then
                    listaDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarGUIA()
        Try
            Dim frm As New frmMovimientoAlmacen
            frm.state_button = True
            frm.IdMovimiento = dgvDatos.CurrentRow.Cells("IdMovimiento").Text

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing

                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text, frm.cmbIdSerieDoc.Value)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdMovimiento)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then

                dtDatos = oDocumentoTransitoService.Filtrar(cmbIdLocacion.Value, cmbTipoDocumento.Value, toNumber(txtNumFac.Text), cbRecepcionado.Checked, txtanio.Value).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            Dim frm As New frmTransferenciasInterna
            estado_process = oDocumentoTransitoService.Borrar(dgvDatos.CurrentRow.Cells("IdTransito").Text)
            frm.type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdTransito").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Private Sub Trasladar()
        Try
            Dim frm As New frmTransferenciasInterna
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de Trasladar el documento Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text + " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If oDocumentoTransitoService.ValidarIngreso(dgvDatos.CurrentRow.Cells("IdTransito").Text) Then
                        If ActualizaLista() Then
                            oDocumentoTransitoService.TrasladarDocumento(dgvDatos.CurrentRow.Cells("IdTransito").Text, Session.sCodUsu)
                            frm.state_button = toBoolean(oMaestroService.MostrarDato("SIGECOM.Almacen.DocumentoTransito", "Recibido", "IdTransito", frm.IdTransito))
                            frm.stateButton()
                            frm.type_process = "update"
                            MsgBox("Se Trasladó el documento correctamente de Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text, MsgBoxStyle.Information)
                            listaDatos()
                        Else
                            MsgBox("Debe recepcionar por lo menos un item.", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("Debe de registrar la fecha y quien recepciono el documento.", MsgBoxStyle.Exclamation)
                    End If
                End If
            Else
                MsgBox(frm.gbDatos.Text + ", no tienes ningún ítem como detalle, verificar…!!!", MsgBoxStyle.Information, "Información")
            End If
        Catch ex As Exception
            MsgBox("ERROR [TRANSFERIR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ActualizaLista() As Boolean
        Try
            Dim dtDetalles As New DataTable
            dtDetalles = oDocumentoTransitoDetService.Mostrar(dgvDatos.CurrentRow.Cells("IdTransito").Text).Tables(0)
            Dim Contador As Integer = 0
            For Each Fila As DataRow In dtDetalles.Rows
                Contador = Contador + Fila.Item("CanRec")
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
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
            '======================================= TIPOS DE DOCUMENTOS ================================================
            dtTipoDocumentos = New DataTable
            dtTipoDocumentos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipoDocumentos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipoDocumentos.Rows.Add(New Object() {"1", "Transferencias Internas"})
            dtTipoDocumentos.Rows.Add(New Object() {"2", "Guías de Remisión"})

            cmbTipoDocumento.DataSource = dtTipoDocumentos
            cmbTipoDocumento.DropDownList.DataMember = dtTipoDocumentos.Columns("nombre").ToString
            cmbTipoDocumento.DropDownList.DisplayMember = dtTipoDocumentos.Columns("nombre").ToString
            cmbTipoDocumento.DropDownList.ValueMember = dtTipoDocumentos.Columns("codigo").ToString
            cmbTipoDocumento.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("codigo").ToString
            cmbTipoDocumento.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("nombre").ToString
            cmbTipoDocumento.SelectedIndex = 0
            dtTipoDocumentos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarTransferenciaInterna()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub


    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarTransferenciaInterna()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Actualizar()

    End Sub

    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbIdLocacion.ValueChanged _
                  , cmbTipoDocumento.ValueChanged
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
    Private Sub cbRecepcionado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRecepcionado.CheckedChanged
        listaDatos()
    End Sub


    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
    Private Sub Trasladar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTrasladar.MouseEnter, miTrasladar.MouseEnter
        sslError.Text = "Trasladar a Otro Almacén."
    End Sub

    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Documento en Tránsito Actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter, biEliminar.MouseEnter
        sslError.Text = "Eliminar Documento en Tránsito Actual."
    End Sub

    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.MouseEnter, biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter, biActualizar.MouseEnter
        sslError.Text = "Actualizar Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
 _
 _
                                   miTrasladar.MouseLeave, biTrasladar.MouseLeave, miMostrar.MouseLeave, biMostrar.MouseLeave, miEliminar.MouseLeave, biEliminar.MouseLeave, _
                                   miActualizar.MouseLeave, biActualizar.MouseLeave, miSalir.MouseLeave, biSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

            If toNumber(dgvDatos.CurrentRow.Cells("IdTransito").Text) <> 0 Then
                Eliminar()
                listaDatos()
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
            End If
        End If

    End Sub

    Private Sub miTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTrasladar.Click
        Trasladar()
    End Sub


    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarTransferenciaInterna()
        End If
    End Sub

    Private Sub biTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladar.Click
        Trasladar()
    End Sub


    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

            If toNumber(dgvDatos.CurrentRow.Cells("IdTransito").Text) <> 0 Then
                Eliminar()
                listaDatos()
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
            End If
        End If
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        Actualizar()
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