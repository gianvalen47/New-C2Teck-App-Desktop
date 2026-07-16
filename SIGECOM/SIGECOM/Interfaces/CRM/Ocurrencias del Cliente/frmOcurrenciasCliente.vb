Public Class frmOcurrenciasCliente

    Private oMaestroService As New MaestroService.MaestroClient
    Private oOcurrenciaClienteService As New OcurrenciaClienteService.OcurrenciaClienteServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer

    Private dtUnidades As DataTable
    Private dtClientes As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtFecha.KeyPress _
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
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                          cmbUnidad.KeyPress _
                        , txtFecha.KeyPress _
                        , txtIdCliente.KeyPress _
                        , btnBuscar.KeyPress _
                        , dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdOcurrencia").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmOcurrenciasCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 25)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        txtFecha.Value = Today
        state_Search = True
        listaDatos()
        dgvDatos.Select()

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oOcurrenciaClienteService) = False Then
                oOcurrenciaClienteService.Close()
            End If
            If isClosed(oCentroCostoService) = False Then
                oOcurrenciaClienteService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal cod_grupo As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbUnidad.Value = toNumber(cod_grupo)
            'txtFecha.Text = ""
        End If
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
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub mostrar()
        Try
            Dim frm As New frmOcurrenciaCliente
            frm.state_button = True
            frm.IdOcurrencia = dgvDatos.CurrentRow.Cells("IdOcurrencia").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.cmbUnidad.Value)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdOcurrencia)
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
                dtDatos = oOcurrenciaClienteService.Filtrar(cmbUnidad.Value, IIf(toBlank(txtFecha.Text) = "", Nothing, txtFecha.Text), toNumber(IdCliente)).Tables(0)
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
            Dim frm As New frmOcurrenciaCliente
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                limpiaOpcionesBusqueda("insert", frm.cmbUnidad.Value)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdOcurrencia)
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
            ElseIf dgvDatos.CurrentRow.Cells("IdOcurrencia").Text = Nothing Then
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
             '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, Session.sCodUsu).Tables(0)
            dtUnidades.Rows.InsertAt(getRowTodos(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

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
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbUnidad.ValueChanged
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
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
   
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub txtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
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

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdOcurrencia").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
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
End Class