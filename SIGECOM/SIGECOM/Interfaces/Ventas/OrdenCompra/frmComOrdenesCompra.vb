Imports System.ServiceModel
Public Class frmComOrdenesCompra

    '===========================Servicios====================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oUsuario As New EmpresaUsuarioService.EmpresaUsuario
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oEmpresaUsuario As New EmpresaUsuarioService.EmpresaUsuarioServiceClient

    '======================Declaración de Variables==============================
    Private dtDatos As DataTable
    Public IdProveedor As Integer
    Public IdOrden As Integer
    Public Asignado As Boolean
    Public Procesado As Boolean
    Private dtEstados As DataTable
    Private dtAreas As DataTable
    Private state_Search As Boolean

    '==========================Evento Load===============================
    Private Sub frmComOrdenesCompra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 131)
        '/*************************************************************************************/

        chkProveedor.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkProveedor, "Limpiar Proveedor")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Proveedor")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        'poCargarArea()
        txtanio.Value = Today.Year
        IdProveedor = 0
        txtProveedor.Text = "(Todos)"
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub

    '=============================Evento KeyPress===================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtanio.KeyPress _
                      , cmbCodArea.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtProveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtanio.KeyPress _
                      , cmbCodArea.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtProveedor.KeyPress _
                      , txtIdOrden.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '==========================Evento FormClosed==================================
    Private Sub frmComOrdenesCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenesCompraService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
            oAsignacionJefesService.Close()
            oEmpresaUsuario.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
            oEmpresaUsuario.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
            oEmpresaUsuario.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================
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
            txtIdOrden.Text = nro_Orden
        End If        
    End Sub

    Private Sub enableOpciones()
        oUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp)
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biEnviar.Enabled = False
            biAprobar.Enabled = False
            biVerEstados.Enabled = False
            biProcesar.Enabled = False
            biAnular.Enabled = False
            biGenerar.Enabled = False
            biGenerarMasivo.Enabled = False
            biActualizarFecEntrega.Enabled = False
            biAsignarGastoManual.Enabled = False
            biEstadoSolicitudCompra.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miEnviar.Enabled = False
            miAprobar.Enabled = False
            miVerEstados.Enabled = False
            miProcesar.Enabled = False
            miAnular.Enabled = False
            miGenerar.Enabled = False
            miGenerarMasivo.Enabled = False
            miActualizarFecEntrega.Enabled = False
            miAsignarGastoManual.Enabled = False
            miEstadoSolicitudCompra.Enabled = False
            miBajarNivel.Enabled = False
        Else
            Dim lEstado As Integer
            lEstado = dgvDatos.CurrentRow.Cells("IdEstado").Value

            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(lEstado = 1, True, False)
            biEnviar.Enabled = IIf(lEstado = 1, True, False)
            biAprobar.Enabled = IIf((lEstado = 2 Or lEstado = 8) And (oAsignacionJefesService.BuscarAprobarCompra(oUsuario.Persona.IdPer, oUsuario.Persona.CentroCosto.CodCentro) Or Session.CodPerfil = "01"), True, False)
            biVerEstados.Enabled = True
            biProcesar.Enabled = True 'IIf((lEstado = 3), True, False)
            biGenerar.Enabled = IIf((lEstado = 5), True, False)
            biAnular.Enabled = IIf(lEstado = 3, True, False)
            biGenerarMasivo.Enabled = True
            biActualizarFecEntrega.Enabled = True
            biAsignarGastoManual.Enabled = IIf((lEstado = 6), False, True)
            biEstadoSolicitudCompra.Enabled = True

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(lEstado = 1, True, False)
            miEnviar.Enabled = IIf(lEstado = 1, True, False)
            miAprobar.Enabled = IIf((lEstado = 2 Or lEstado = 8) And (oAsignacionJefesService.BuscarAprobarCompra(oUsuario.Persona.IdPer, oUsuario.Persona.CentroCosto.CodCentro) Or Session.CodPerfil = "01"), True, False)
            miVerEstados.Enabled = True
            miProcesar.Enabled = True 'IIf((lEstado = 3), True, False)
            miGenerar.Enabled = IIf((lEstado = 5), True, False)
            miAnular.Enabled = IIf(lEstado = 3, True, False)
            miGenerarMasivo.Enabled = True
            miActualizarFecEntrega.Enabled = True
            miAsignarGastoManual.Enabled = IIf((lEstado = 6), False, True)
            miEstadoSolicitudCompra.Enabled = True
            miBajarNivel.Enabled = IIf(lEstado = 3 And (oAsignacionJefesService.BuscarAprobarCompra(oUsuario.Persona.IdPer, oUsuario.Persona.CentroCosto.CodCentro) Or Session.CodPerfil = "01"), True, False)
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
            If row.Cells("IdOrden").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmComOrdenCompra
            Dim lEstado As Integer
            lEstado = dgvDatos.CurrentRow.Cells("IdEstado").Text
            frm.state_button = True
            frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Text
            frm.editable = IIf(lEstado = 1, True, False) '-- se descomento 10/05/2012 se valido que solo en estado GN se pueda Editar los datos            
            frm.edicion = False
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
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR ORDEN DE COMPRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Orden de Compra Nº " + dgvDatos.CurrentRow.Cells("IdOrden").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oOrdenesCompraService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdOrden").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó  el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR ORDEN DE COMPRA:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmComOrdenCompra
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", 1))
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdOrden)
                    mostrar()
                    Actualizar()

                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO ORDEN DE COMPRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
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

            '======================================= ESTADOS ================================================
            dtEstados = oOrdenesCompraService.MostrarEstados()
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

    Private Sub mostrarReporte()
        'Try
        '    Dim forma As New frmReportes
        '    Dim dtReporte As New DataTable
        '    Dim reporte As New rptComOrdenCompra
        '    If dgvDatos.RowCount > 0 Then
        '        dtReporte = oOrdenesCompraService.Imprimir(dgvDatos.CurrentRow.Cells("IdOrden").Value).Tables(0)
        '        If dtReporte.Rows.Count = 0 Then
        '            MsgBox("No hay datos a mostrar")
        '        Else
        '            reporte.SetDataSource(dtReporte)
        '            forma.crvReportes.ReportSource = reporte
        '            forma.crvReportes.DisplayGroupTree = False
        '            forma.Text = "Reporte de Orden de Compra"
        '            forma.ShowDialog()
        '        End If
        '    Else
        '        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        'End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub poCargarArea()
        'oUsuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        oUsuario = oEmpresaUsuario.Obtener(Session.sCodUsu, Session.sCodEmp)
        cmbCodArea.Value = oUsuario.Persona.CentroCosto.Area.CodArea
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oOrdenesCompraService.Filtrar(Session.sCodEmp, CInt(txtanio.Value), CStr(cmbCodArea.Value), IdProveedor, IIf(toBlank(txtIdOrden.Text) = "", 0, txtIdOrden.Text), cmbEstado.Value, Session.sCodUsu).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtanio.ValueChanged, cmbCodArea.ValueChanged, cmbEstado.ValueChanged, txtIdOrden.TextChanged
        listaDatos()
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkProveedor.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtProveedor.Text = frm.descripcion
                    IdProveedor = frm.codigo
                Else
                    txtProveedor.Text = "(Todos)"
                    IdProveedor = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkProveedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkProveedor.CheckedChanged
        If txtProveedor.Text <> "(Todos)" Then
            chkProveedor.Enabled = False
            txtProveedor.Text = "(Todos)"
            IdProveedor = 0
            listaDatos()
        Else
            chkProveedor.Enabled = True
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
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave, _
                                    biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave, _
                                    biEnviar.MouseLeave, miEnviar.MouseLeave, biAprobar.MouseLeave, miAprobar.MouseLeave, _
                                    biAnular.MouseLeave, miAnular.MouseLeave, biGenerar.MouseLeave, miGenerar.MouseLeave, _
                                    biGenerarMasivo.MouseLeave, miGenerarMasivo.MouseLeave, biProcesar.MouseLeave, miProcesar.MouseLeave, _
                                    biVerEstados.MouseLeave, miVerEstados.MouseLeave, biActualizar.MouseLeave, miActualizar.MouseLeave, _
                                    biSalir.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Orden de Compra actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Orden de Compra."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Orden de Compra actual."
    End Sub
    Private Sub Enviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar Orden de Compra actual."
    End Sub
    Private Sub Anular_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.MouseEnter, miAnular.MouseEnter
        sslError.Text = "Anular Orden de Compra actual."
    End Sub
    Private Sub VerEstados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biVerEstados.MouseEnter, miVerEstados.MouseEnter
        sslError.Text = "Ver Estados de Orden de Compra actual."
    End Sub
    Private Sub Procesar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biProcesar.MouseEnter, miProcesar.MouseEnter
        sslError.Text = "Facturación Orden de Compra actual."
    End Sub
    Private Sub Aprobar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobar.MouseEnter, miAprobar.MouseEnter
        sslError.Text = "Aprobar Orden de Compra actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Orden de Compra actual."
    End Sub
    Private Sub Asignar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.MouseEnter, miGenerar.MouseEnter
        sslError.Text = "Asignar Solicitud de Gastos."
    End Sub
    Private Sub AsignarMasivo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerarMasivo.MouseEnter, miGenerarMasivo.MouseEnter
        sslError.Text = "Asignar Solicitud de Gastos Masivo."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComOrdenCompra_Imprimir
                frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Value
                frm.iAnio = toNumber(txtanio.Value)
                frm.iCodArea = toBlank(cmbCodArea.Value)
                frm.iIdPer = IdProveedor
                frm.iIdOrden = toNumber(txtIdOrden.Text)
                frm.iIdEstado = toNumber(cmbEstado.Value)
                frm.iProveedor = txtProveedor.Text
                frm.iDesArea = cmbCodArea.Text
                frm.iDesEstado = cmbEstado.Text
                frm.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        'mostrarReporte()
    End Sub

    Private Sub biEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                If toBlank(dgvDatos.CurrentRow.Cells("CodJob").Text) <> "" And toBlank(dgvDatos.CurrentRow.Cells("CodRubro").Text) = "" Then
                    MsgBox("La Orden de Compra no tiene Rubro actualizar los datos antes de Enviar.", MsgBoxStyle.Exclamation)
                Else
                    Dim frm As New frmComOrdenCompra_Enviar
                    frm.IdOrden = toNumber(dgvDatos.CurrentRow.Cells("IdOrden").Text)
                    Dim registro As OrdenesCompraService.OrdenesCompra
                    registro = oOrdenesCompraService.Obtener(dgvDatos.CurrentRow.Cells("IdOrden").Value)
                    frm.IdPersonaSolicita = registro.PersonaSolicita.IdPer
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        biRefrescar_Click(sender, e)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ENVIAR la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobar.Click, miAprobar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComOrdenCompra_Aprobar
                frm.IdOrden = toNumber(dgvDatos.CurrentRow.Cells("IdOrden").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al APROBAR la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biVerEstados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVerEstados.Click, miVerEstados.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComOrdenCompra_Estados
                frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Value
                frm.Text = "Estados de la Orden de Compra Nº " & dgvDatos.CurrentRow.Cells("IdOrden").Value.ToString
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biProcesar.Click, miProcesar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComOrdenCompra_Facturacion
                frm.IdOrden = toNumber(dgvDatos.CurrentRow.Cells("IdOrden").Value)
                frm.Estado = toNumber(dgvDatos.CurrentRow.Cells("IdEstado").Value)
                frm.IdProveedor = toNumber(dgvDatos.CurrentRow.Cells("IdProveedor").Value)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                End If
                biRefrescar_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Error al Mostrar Facturas la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGenerar.Click, miGenerar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If oOrdenesCompraService.BuscarAprobacion(dgvDatos.CurrentRow.Cells("IdOrden").Value) Then
                    If MsgBox("¿Estas seguro de GENERAR la Solicitud de Gastos de la Orden de Compra N° " & dgvDatos.CurrentRow.Cells("IdOrden").Value.ToString & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Dim estado_process As Integer
                        estado_process = oOrdenesCompraService.GenerarSolicitudGasto(dgvDatos.CurrentRow.Cells("IdOrden").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process > 0 Then
                            MsgBox("Se  Generó la Solicitud de Gastos Nº " + estado_process.ToString)
                            Actualizar()
                        Else
                            MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
                        End If
                    End If
                Else
                    MsgBox("¡Error en el Proceso, La Orden de Compra no ha sido Aprobada...!")
                End If
            Else
                MsgBox("No existen datos, Verifique...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGenerarMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGenerarMasivo.Click, miGenerarMasivo.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComOrdenCompra_Generar
                frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al GENERAR la Solicitud de Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAnular.Click, miAnular.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComOrdenCompra_Anular
                frm.IdOrden = toNumber(dgvDatos.CurrentRow.Cells("IdOrden").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ANULAR la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAsignarGastoManual_Click(sender As System.Object, e As System.EventArgs) Handles biAsignarGastoManual.Click, miAsignarGastoManual.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComOrdenCompra_AsignaraGastoManual
                frm.IdOrden = toNumber(dgvDatos.CurrentRow.Cells("IdOrden").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ANULAR la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizaFecEntrega_Click(sender As System.Object, e As System.EventArgs) Handles biActualizarFecEntrega.Click, miActualizarFecEntrega.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComOrdenCompra_ActFecEntrega
                frm.IdOrden = toNumber(dgvDatos.CurrentRow.Cells("IdOrden").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ANULAR la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEstadoSolicitudCompra_Click(sender As Object, e As System.EventArgs) Handles biEstadoSolicitudCompra.Click, miEstadoSolicitudCompra.Click
        Try
            If IsDBNull(dgvDatos.CurrentRow.Cells("IdSolicitud").Value) = True Then
                MsgBox("¡La Orden de Compra no presenta Solicitud de Compra asignada...!")
            Else
                Dim frm As New frmComSolicitudCompra_Estados
                frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ver los estados : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biArchivos_Click(sender As Object, e As EventArgs) Handles biArchivos.Click, miArchivos.Click
        Try
            Dim frm As New frmComOrdenCompra_Archivos
            frm.IdOrden = dgvDatos.CurrentRow.Cells("IdOrden").Value
            frm.NumOrden = dgvDatos.CurrentRow.Cells("IdOrden").Value

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LOS ARCHIVOS DE LA ORDEN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miBajarNivel_Click(sender As Object, e As EventArgs) Handles miBajarNivel.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmComOrdenCompra_BajarNivel
                frm.IdOrden = toNumber(dgvDatos.CurrentRow.Cells("IdOrden").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al ANULAR la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class