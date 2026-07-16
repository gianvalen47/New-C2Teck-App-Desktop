Public Class frmVisitasClientes
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oVisitaClienteService As New VisitaClienteService.VisitaClienteServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient

    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    Private IdPersona As Integer
    'Private dtGruposVenta As DataTable        
    Private dtEstados As DataTable
    Private dtVendedor As DataTable
    Private dtUnidades As DataTable
    Public iEstado As Integer

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        dgvDatos.KeyPress,
        cmbUnidad.KeyPress,
        txtPersona.KeyPress,
        txtCliente.KeyPress,
        txtFecInicio.KeyPress,
        txtFecFin.KeyPress,
        cmbEstado.KeyPress
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
                          dgvDatos.KeyPress,
                          cmbUnidad.KeyPress,
                          txtCliente.KeyPress,
                          txtPersona.KeyPress,
                          txtFecInicio.KeyPress,
                          txtFecFin.KeyPress,
                          cmbEstado.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows
                If CInt(row.Cells("IdVisita").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmVisitasClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 26)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")

        chkPersona.Enabled = False
        pboxLimpiarPersona.Enabled = True
        ToolTip2.SetToolTip(chkPersona, "Limpiar Colaborador")

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()

        txtFecInicio.Value = "01/" & Month(Today) & "/" & Year(Today)
        txtFecFin.Value = Today.Date

        IdCliente = 0
        txtCliente.Text = "(Todos)"
        IdPersona = 0
        txtPersona.Text = "(Todos)"
        state_Search = True
        listaDatos()
        dgvDatos.Select()

    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oVisitaClienteService) = False Then
                oVisitaClienteService.Close()
            End If            
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
            If isClosed(oPersonaService) = False Then
                oPersonaService.Close()
            End If
            If isClosed(oCentroCostoService) = False Then
                oCentroCostoService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal tipo_venta As Integer)
        If type_process = "update" Or type_process = "insert" Then

        End If
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miActualizar.Enabled = False
            miCancelar.Enabled = False

            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biActualizar.Enabled = False
            biCancelar.Enabled = False

        Else
            iEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
            miMostrar.Enabled = True
            miActualizar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = 1, True, False)
            miCancelar.Enabled = IIf(iEstado = 1, True, False)

            biMostrar.Enabled = True
            biActualizar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = 1, True, False)
            biCancelar.Enabled = IIf(iEstado = 1, True, False)
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
    Private Function getRowVendedor(ByVal data As DataTable)
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
    Private Sub mostrar()
        Try
            Dim frm As New frmVisitaCliente
            frm.state_button = True
            frm.IdVisita = toNumber(dgvDatos.CurrentRow.Cells("IdVisita").Text)
            frm.IdEstado = toNumber(dgvDatos.CurrentRow.Cells("IdEstado").Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdVisita)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdVisita)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA VISITA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdVisita").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oVisitaClienteService.Borrar(dgvDatos.CurrentRow.Cells("IdVisita").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR VISITA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oVisitaClienteService.Filtrar(Session.sCodEmp, toNumber(cmbUnidad.Value), IdPersona, IdCliente, txtFecInicio.Value, txtFecFin.Value, toNumber(cmbEstado.Value)).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmVisitaCliente
                frm.state_button = False
                'frm.IdEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdVisita)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA VISITA: " + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells("IdVisita").Text = Nothing Then
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

            ' ''===================================== TIPO DE VISITA ============================================
            'dtTipoVisita = oVisitaOportunidadService.MostrarTipoVisita().Tables(0)
            'dtTipoVisita.Rows.InsertAt(getRowTodos(dtTipoVisita), 0)
            'cmbTipoVisita.DataSource = dtTipoVisita
            'cmbTipoVisita.DropDownList.DataMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            'cmbTipoVisita.DropDownList.DisplayMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            'cmbTipoVisita.DropDownList.ValueMember = dtTipoVisita.Columns("IdTipoVisita").ToString
            'cmbTipoVisita.DropDownList.Columns(0).DataMember = dtTipoVisita.Columns("IdTipoVisita").ToString
            'cmbTipoVisita.DropDownList.Columns(1).DataMember = dtTipoVisita.Columns("DesTipoVisita").ToString
            'cmbTipoVisita.SelectedIndex = 0
            'dtTipoVisita = Nothing

            '======================================= ESTADO ================================================
            dtEstados = oVisitaClienteService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

            ''======================================= VENDEDOR ===========================================
            'dtVendedor = oPersonaService.MostrarVendedoresVigente.Tables(0)
            'dtVendedor.Rows.InsertAt(getRowVendedor(dtVendedor), 0)
            'cmbVendedor.DataSource = dtVendedor
            'cmbVendedor.DropDownList.DataMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.DropDownList.DisplayMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.DropDownList.ValueMember = dtVendedor.Columns("IdPer").ToString
            'cmbVendedor.DropDownList.Columns(0).DataMember = dtVendedor.Columns("IdPer").ToString
            'cmbVendedor.DropDownList.Columns(1).DataMember = dtVendedor.Columns("ApeNom").ToString
            'cmbVendedor.SelectedIndex = 0
            'dtVendedor = Nothing

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, Session.sCodUsu).Tables(0)
            'dtUnidades.Rows.InsertAt(getRowTodos(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click,
                                                                                                                                                          cmbEstado.ValueChanged, cmbUnidad.ValueChanged,
                                                                                                                                                           txtCliente.TextChanged, txtPersona.TextChanged,
                                                                                                                                                           txtFecInicio.ValueChanged, txtFecFin.ValueChanged
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
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
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
    Private Sub btnBuscarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Try
            Dim frm As New frmBuscarCliente
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkCliente.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtCliente.Text = frm.descripcion
                    IdCliente = frm.codigo
                Else
                    txtCliente.Text = "(Todos)"
                    IdCliente = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtPersona.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtPersona.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub chkCliente_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub
    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPersona.CheckedChanged
        If txtPersona.Text <> "(Todos)" Then
            chkPersona.Enabled = False
            txtPersona.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkPersona.Enabled = True
            pboxLimpiarPersona.Enabled = True
        End If
    End Sub
    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub
    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.Click, miCancelar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmVisitaCliente_Cancelar
                frm.IdVisita = dgvDatos.CurrentRow.Cells("IdVisita").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biActualizar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al CANCELAR la Visita: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Listado de visitas."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear nueva visita."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar visita actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar visita actual actual."
    End Sub
    Private Sub Cancelar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCancelar.MouseEnter, miCancelar.MouseEnter
        sslError.Text = "Cancelar visita actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar formulario actual."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Actualizar formulario actual."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                     biNuevo.MouseLeave, biMostrar.MouseLeave, biCancelar.MouseLeave, biActualizar.MouseLeave,
                                     biEliminar.MouseLeave, biSalir.MouseLeave, biImprimir.MouseLeave, miImprimir.MouseLeave,
                                     miNuevo.MouseLeave, miMostrar.MouseLeave, miCancelar.MouseLeave, miActualizar.MouseLeave,
                                     miEliminar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdVisita").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub biImprimir_Click(sender As Object, e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataView
            Dim reporte As New rptListado_VisitaCliente
            dtReporte = oVisitaClienteService.Filtrar(Session.sCodEmp, toNumber(cmbUnidad.Value), IdPersona, IdCliente, txtFecInicio.Value, txtFecFin.Value, toNumber(cmbEstado.Value)).Tables(0).DefaultView
            If dtReporte.Count = 0 Then
                MsgBox("No existen datos a imprimir ")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.Text = "Listado de Visita de Clientes"                
                reporte.SetParameterValue("pUnidadNegocio", cmbUnidad.Text)
                reporte.SetParameterValue("pCliente", txtCliente.Text)
                reporte.SetParameterValue("pFechaInicio", txtFecInicio.Value)
                reporte.SetParameterValue("pFechaFin", txtFecFin.Value)
                reporte.SetParameterValue("pPersona", txtPersona.Text)
                reporte.SetParameterValue("pEstado", cmbEstado.Text)
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL IMPRIMIR LISTADO DE VISITAS:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class