Imports System.ServiceModel
Public Class frmComSolicitudGastosNew

    '===========================Servicios====================================================
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oUsuario As New SeguridadService.Usuario
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oEmpresaUsuario As New EmpresaUsuarioService.EmpresaUsuarioServiceClient
    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public IdPersona As Integer
    Private dtEstados As DataTable
    Private dtAreas As DataTable
    Private dtDatos As New DataTable
    Private dtMeses As New DataTable
    Private dtCentroCosto As New DataTable
    Private iEstado As Integer
    Private empresaUsuario As New EmpresaUsuarioService.EmpresaUsuario

    '==========================Evento Load===================================================
    Private Sub frmComSolicitudGastos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 136)
        '/*************************************************************************************/

        chkPersona.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkPersona, "Limpiar Solicitante")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Solicitante")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        poCargarArea()
        txtAnio.Value = Today.Year
        cmbMes.Value = Today.Month
        IdPersona = 0
        txtSolicitante.Text = "(Todos)"
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtAnio.KeyPress _
                      , cmbCodArea.KeyPress _
                      , cmbCentroCosto.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtIdGasto.KeyPress _
                      , txtSolicitante.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '=============================Evento FormClosed==========================================
    Private Sub frmComSolicitudGastos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudGastoService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
            oAsignacionJefesService.Close()
            oCentroCostoService.Close()
            oEmpresaUsuario.Close()
        Catch ex As TimeoutException
            oSolicitudGastoService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
            oCentroCostoService.Abort()
            oEmpresaUsuario.Abort()
        Catch ex As CommunicationException
            oSolicitudGastoService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
            oCentroCostoService.Abort()
            oEmpresaUsuario.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmComOrdenesCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        End If
    End Sub

    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal nro_Orden As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEstado.Value = ""
            txtIdGasto.Text = nro_Orden
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biVerEstados.Enabled = False
            biAprobar.Enabled = False
            biEnviar.Enabled = False
            biAnular.Enabled = False
            biRechazar.Visible = False
            biRegistrarArchivos.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miVerEstados.Enabled = False
            miAprobar.Enabled = False
            miEnviar.Enabled = False
            miAnular.Enabled = False
            miRechazar.Visible = False
            miRegistrarArchivos.Enabled = False
            miExportarGasto.Enabled = False
            miExportarCtasPorPagar.Enabled = False
        Else
            iEstado = oSolicitudGastoService.ObtenerEstado(dgvDatos.CurrentRow.Cells("IdGasto").Value)
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(iEstado = 1, True, False)
            biVerEstados.Enabled = True
            biAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 8, True, False)
            biEnviar.Enabled = IIf(iEstado = 1, True, False)
            biAnular.Enabled = IIf(iEstado <> 1 And iEstado <> 5 And iEstado <> 9, True, False)
            biExportarGasto.Enabled = IIf(iEstado = 3 Or iEstado = 5, True, False)
            biRechazar.Visible = IIf((Session.CodPerfil = "12" Or Session.CodPerfil = "22" Or Session.CodPerfil = "49" Or Session.CodPerfil = "01"), True, False)
            biRechazar.Enabled = IIf(iEstado = 3, True, False)
            biRegistrarArchivos.Enabled = True 'IIf(iEstado = 1, True, False)

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(iEstado = 1, True, False)
            miVerEstados.Enabled = True
            miAprobar.Enabled = IIf(iEstado = 2 Or iEstado = 8, True, False)
            miEnviar.Enabled = IIf(iEstado = 1, True, False)
            miAnular.Enabled = IIf(iEstado <> 1 And iEstado <> 5 And iEstado <> 9, True, False)
            miExportarGasto.Enabled = IIf(iEstado = 3 Or iEstado = 5, True, False)
            miRechazar.Visible = IIf((Session.CodPerfil = "12" Or Session.CodPerfil = "22" Or Session.CodPerfil = "49" Or Session.CodPerfil = "01"), True, False)
            miRechazar.Enabled = IIf(iEstado = 3, True, False)
            miRegistrarArchivos.Enabled = True 'IIf(iEstado = 1, True, False)
            miExportarCtasPorPagar.Enabled = IIf(iEstado = 3 Or iEstado = 10, True, False)
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdGasto").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmComSolicitudGastoNew
            Dim lEstado As String
            lEstado = dgvDatos.CurrentRow.Cells("DesEstado").Text
            frm.state_button = True
            frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Text
            frm.editable = IIf(lEstado = "Generado", True, False)
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdGasto)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA SOLICITUD DE GASTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Solicitud de Gastos Nº " + dgvDatos.CurrentRow.Cells("IdGasto").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oSolicitudGastoService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdGasto").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA SOLICITUD DE GASTOS:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmComSolicitudGastoNew
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdGasto)
                    mostrar()
                    Actualizar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA SOLICITUD DE GASTOS: " + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub llenarCombos()
        Try

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            If dtAreas.Rows.Count > 1 Then
                dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            End If
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

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
            dtEstados = oSolicitudGastoService.MostrarEstados().Tables(0)
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("IdEstado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("DesEstado").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub poCargarArea()

        Try


            '----- Se comenta a pedido del Sr. Carlos Salhuana 25/09/2018 -----
            'oUsuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
            empresaUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp)
            'If Session.CodPerfil = "13" Then
            '    cmbEstado.Value = 2
            'Else
            cmbEstado.SelectedIndex = 0
            'End If
            If Session.CodPerfil = "13" Then
                cmbCodArea.SelectedIndex = 0
            Else
                If empresaUsuario.Persona.CentroCosto.Area.CodArea Is Nothing Then
                    cmbCodArea.SelectedIndex = 0 'oUsuario.Persona.CentroCosto.Area.CodArea
                Else
                    cmbCodArea.Value = empresaUsuario.Persona.CentroCosto.Area.CodArea
                End If


                'cmbCodArea.Value = empresaUsuario.Persona.CentroCosto.Area.CodArea    'oUsuario.Persona.CentroCosto.Area.CodArea
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oSolicitudGastoService.Filtrar(Session.sCodEmp, CInt(txtAnio.Value), toNumber(cmbMes.Value), CStr(cmbCodArea.Value), CStr(cmbCentroCosto.Value), IdPersona, IIf(toBlank(txtIdGasto.Text) = "", 0, txtIdGasto.Text), cmbEstado.Value, Session.sCodUsu).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtAnio.ValueChanged, cmbMes.ValueChanged, cmbEstado.ValueChanged, txtIdGasto.TextChanged, cmbCentroCosto.ValueChanged
        listaDatos()
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtSolicitante.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPersona.CheckedChanged
        If txtSolicitante.Text <> "(Todos)" Then
            chkPersona.Enabled = False
            txtSolicitante.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkPersona.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub biVerEstados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComSolicitudGasto_Estados
                frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Value
                frm.Text = "Estados de la Solicitud de Gastos Nº " & dgvDatos.CurrentRow.Cells("IdGasto").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                If dgvDatos.CurrentRow.Cells("GastoViaje").Value = True And oSolicitudGastoDetService.BuscarNoAplicaTarifa(dgvDatos.CurrentRow.Cells("IdGasto").Value) = True Then
                    If MsgBox("La Solicitud de Gastos N°:" & dgvDatos.CurrentRow.Cells("IdGasto").Text & " presenta detalles donde No Aplica Tarifa ¿Está seguro de Continuar?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim frm As New frmComSolicitudGasto_Aprobar
                        frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Text
                        frm.IdEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                        frm.IdPersonaSolicita = dgvDatos.CurrentRow.Cells("IdPerSolicita").Value
                        frm.IdUnidad = dgvDatos.CurrentRow.Cells("IdUnidad").Value
                        'frm.GastoViaje = toBoolean(dgvDatos.CurrentRow.Cells("GastoViaje").Value) '----Agregado el 30/05/2012----
                        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                            biRefrescar_Click(sender, e)
                        End If
                    End If
                Else
                    Dim frm As New frmComSolicitudGasto_Aprobar
                    frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Text
                    frm.IdEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                    frm.IdPersonaSolicita = dgvDatos.CurrentRow.Cells("IdPerSolicita").Value
                    frm.IdUnidad = dgvDatos.CurrentRow.Cells("IdUnidad").Value
                    'frm.GastoViaje = toBoolean(dgvDatos.CurrentRow.Cells("GastoViaje").Value) '----Agregado el 30/05/2012----
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        biRefrescar_Click(sender, e)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al APROBAR la Solicitud de Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdGasto").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                 biNuevo.MouseLeave, biMostrar.MouseLeave, _
                                biEliminar.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                miImprimir.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, _
                                miEliminar.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, _
                                miAnular.MouseLeave, biAnular.MouseLeave, miVerEstados.MouseLeave, _
                                biVerEstados.MouseLeave, miAprobar.MouseLeave, biAprobar.MouseLeave, _
                                miEnviar.MouseLeave, biEnviar.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Solicitud de Gastos actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Solicitud de Gastos."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Solicitud de Gastos actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Solicitud de Gastos actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Enviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar Solicitud de Gastos Actual."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Aprobar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar Solicitud de Gastos actual."
    End Sub
    Private Sub Anular_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.MouseEnter, miAnular.MouseEnter
        sslError.Text = "Anular Solicitud de Gastos actual."
    End Sub
    Private Sub VerEstados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVerEstados.MouseEnter, miVerEstados.MouseEnter
        sslError.Text = "Ver Estados de Solicitud de Gastos actual."
    End Sub
    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            If ValidaCodigoSeleccionado() Then

                Dim registro As SolicitudGastoService.SolicitudGasto
                Dim idtipo As String = ""
                oSolicitudGastoService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
                registro = oSolicitudGastoService.Obtener(dgvDatos.CurrentRow.Cells("IdGasto").Value)
                idtipo = registro.Provisional.TipoProvisional.IdTipo

                Dim frm As New frmComSolicitudGasto_Imprimir
                frm.idGasto = dgvDatos.CurrentRow.Cells("IdGasto").Value
                frm.iAnio = toNumber(txtAnio.Value)
                frm.iMes = toNumber(cmbMes.Value)
                frm.iCodArea = toBlank(cmbCodArea.Value)
                frm.iCodCentro = toBlank(cmbCentroCosto.Value)
                frm.iIdPer = IdPersona
                frm.iIdGasto = toNumber(txtIdGasto.Text)
                frm.iIdEstado = toNumber(cmbEstado.Value)
                frm.iSolicitante = txtSolicitante.Text
                frm.iDesArea = cmbCodArea.Text
                frm.iDesEstado = cmbEstado.Text
                frm.iDesMes = cmbMes.Text
                frm.GastoViaje = toBoolean(dgvDatos.CurrentRow.Cells("GastoViaje").Value)
                frm.IdProvisional = IIf(IsDBNull(dgvDatos.CurrentRow.Cells("IdProvisional").Value), 0, dgvDatos.CurrentRow.Cells("IdProvisional").Value)
                frm.IdTipo = idtipo
                frm.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        'mostrarReporte()
    End Sub

    Private Sub mostrarReporte()
        'Try
        '    Dim forma As New frmReportes
        '    Dim dtReporte As New DataTable
        '    Dim reporte As New rptComSolicitudGastos
        '    Dim subreporte As New rptComSolicitudGastos1
        '    If dgvDatos.RowCount > 0 Then
        '        dtReporte = oSolicitudGastoService.Imprimir(dgvDatos.CurrentRow.Cells("IdGasto").Value).Tables(0)
        '        If dtReporte.Rows.Count = 0 Then
        '            MsgBox("No hay datos a mostrar")
        '        Else
        '            reporte.SetDataSource(dtReporte)
        '            subreporte.SetDataSource(dtReporte)
        '            forma.crvReportes.ReportSource = reporte
        '            forma.crvReportes.DisplayGroupTree = False
        '            reporte.SetParameterValue("pIdMesa", 0)
        '            forma.Text = "Reporte de Solicitud de Gastos"
        '            forma.ShowDialog()
        '        End If
        '    Else
        '        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        'End Try
    End Sub

    Private Sub biEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        Try
            'If dgvDatos.RowCount > 0 Then
            '    If MsgBox("¿Estas seguro de ENVIAR la Solicitud e Gastos N° " & dgvDatos.CurrentRow.Cells("IdGasto").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            '        Dim estado_process As Boolean
            '        estado_process = oSolicitudGastoService.Enviar(dgvDatos.CurrentRow.Cells("IdGasto").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            '        If estado_process Then
            '            MsgBox("Se Envio correctamente la Solicitud de Gastos")
            '            Actualizar()
            '        Else
            '            MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
            '        End If
            '    End If
            'Else
            '    MsgBox("No existen datos, Verifique...")
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.Click, miAnular.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComSolicitudGasto_Anular
                frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Text
                'frm.IdEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ANULAR la Solicitud de Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRechazar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                If (Session.CodPerfil = "22" Or Session.CodPerfil = "49" Or Session.CodPerfil = "01") Then

                    Dim frm As New frmComSolicitudGasto_Rechazar
                    frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Text
                    'frm.IdEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
                    'frm.GastoViaje = toBoolean(dgvDatos.CurrentRow.Cells("GastoViaje").Value) '----Agregado el 30/05/2012----
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        biRefrescar_Click(sender, e)
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al APROBAR la Solicitud de Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            'If dtCentroCosto.Rows.Count > 1 Or cmbCodArea.Value = "" Then
            dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            'End If
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            listaDatos()

            If cmbCodArea.Value = "" Then
                lblUnidadNegocio.Text = ""
            Else
                lblUnidadNegocio.Text = "Unidad de Negocio: " & oCentroCostoService.ObtenerDesUnidad(cmbCodArea.Value)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biExportarGasto_Click(sender As System.Object, e As System.EventArgs) Handles biExportarGasto.Click, miExportarGasto.Click
        Try
            Dim frm As New frmComSolicitudGasto_Exportar
            frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                biRefrescar_Click(sender, e)
            End If

        Catch ex As Exception
            MsgBox("ERROR AL EXPORTAR EL GASTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biVerAprobacion_Click(sender As Object, e As EventArgs) Handles biVerAprobacion.Click, miAprobaciones.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComSolicitudGasto_Aprobaciones
                frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Value
                frm.Text = "Aprobaciones de Gerencia de la Solicitud de Gastos Nº " & dgvDatos.CurrentRow.Cells("IdGasto").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biRegistrarArchivos_Click(sender As Object, e As EventArgs) Handles biRegistrarArchivos.Click, miRegistrarArchivos.Click
        Try
            Dim frm As New frmComSolicitudGastos_Archivos
            frm.IdGasto = dgvDatos.CurrentRow.Cells("IdGasto").Value
            frm.estado = dgvDatos.CurrentRow.Cells("IdEstado").Value
            'frm.Nombre = dgvDatos.CurrentRow.Cells("Nombre").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LOS ARCHIVOS DEL JOB: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miExportarCtasPorPagar_Click(sender As Object, e As EventArgs) Handles miExportarCtasPorPagar.Click
        Try
            Dim idGasto As Int64
            idGasto = dgvDatos.CurrentRow.Cells("IdGasto").Text
            If MsgBox("¿Estas seguro de EXPORTAR a cuentas por pagar la Solicitud de Gastos N° " & idGasto, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If oSolicitudGastoService.ExportarCtasPorPagar(idGasto, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                    MsgBox("Se registraron los documentos en Cuentas por Pagar con exito!!!!!!", MsgBoxStyle.Information)
                    biRefrescar_Click(sender, e)
                End If
            End If

        Catch ex As Exception
            MsgBox("ERROR AL EXPORTAR EL GASTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class