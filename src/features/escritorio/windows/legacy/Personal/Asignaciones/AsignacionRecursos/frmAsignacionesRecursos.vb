Imports System.ServiceModel
Public Class frmAsignacionesRecursos

    '=========================== Servicios ====================================================
    Private oRecursoService As New RecursoService.RecursoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public IdPersona As Integer
    Private dtDatos As New DataTable
    Private dtAreas As DataTable
    Private dtRubros As DataTable
    Private dtCentroCosto As New DataTable
    Private dtEstados As New DataTable
    Private dtPeriodos As DataTable
    Public iEstado As String


    '==========================Evento Load===================================================
    Private Sub frmAsignacionesRecursos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chkColaborador.Enabled = False
        pboxLimpiarColaborador.Enabled = True
        ToolTip1.SetToolTip(chkColaborador, "Limpiar Colaborador")
        ToolTip1.SetToolTip(pboxLimpiarColaborador, "Limpiar Colaborador")

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()

        state_Search = True
        cmbAnio.Value = Year(Today)
        listaDatos()
        dgvDatos.Select()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             cmbCodArea.KeyPress _
                          , cmbCentroCosto.KeyPress _
                          , cmbRubro.KeyPress _
                          , txtColaborador.KeyPress _
                          , txtNumDoc.KeyPress _
                          , cmbAnio.KeyPress
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

    '=============================Evento FormClosed=============================================
    Private Sub frmAsignacionesRecursos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRecursoService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oRecursoService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oRecursoService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    '==============================Evento KeyDown==============================================
    Private Sub frmAsignacionesRecursos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub enableOpciones()
        Try
            If dgvDatos.RowCount < 1 Then
                biImprimir.Enabled = False
                biMostrar.Enabled = False
                biEliminar.Enabled = False
                biEntregar.Enabled = False
                biCopiar.Enabled = False

                miImprimir.Enabled = False
                miMostrar.Enabled = False
                miEliminar.Enabled = False
                miEntregar.Enabled = False
                miCopiar.Enabled = False
            Else
                iEstado = toBlank(dgvDatos.CurrentRow.Cells("Estado").Value)
                biImprimir.Enabled = True
                biMostrar.Enabled = True
                biEliminar.Enabled = IIf(iEstado = "GN", True, False)
                biEntregar.Enabled = IIf(iEstado = "GN", True, False)
                biCopiar.Enabled = True

                miImprimir.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = IIf(iEstado = "GN", True, False)
                miEntregar.Enabled = IIf(iEstado = "GN", True, False)
                miCopiar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
            If row.Cells("IdRecurso").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmAsignacionRecurso_Nuevo
            iEstado = toBlank(dgvDatos.CurrentRow.Cells("Estado").Value)
            frm.iEstado = toBlank(dgvDatos.CurrentRow.Cells("Estado").Value)
            frm.state_button = True
            frm.IdRecurso = dgvDatos.CurrentRow.Cells("IdRecurso").Text
            frm.editable = IIf(iEstado = "GN", True, False)
            frm.edicion = False
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdRecurso)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oRecursoService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdRecurso").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            If cmbAnio.Value = 0 Then
                MsgBox("Selecccione una Año.")
            Else
                If cmbCodArea.Value = "" Then
                    MsgBox("Selecccione una Area.")
                Else

                    Dim frm As New frmAsignacionRecurso_Nuevo
                    frm.state_button = False
                    frm.edicion = True
                    frm.editable = True
                    frm.iIdPersona = IdPersona
                    frm.CodArea = cmbCodArea.Value
                    frm.CodAnio = cmbAnio.Value
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        dtDatos = Nothing
                        listaDatos()
                        If frm.type_process = "insert" Then
                            RowPossesion(dgvDatos, frm.IdRecurso)
                            mostrar()
                            Actualizar()
                        End If
                        enableOpciones()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
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

            ''====================================== PERIODOS ===============================================
            dtPeriodos = oRecursoService.MostrarPeriodos().Tables(0)
            dtPeriodos.Rows.InsertAt(getRowTodos(dtPeriodos), 0)
            cmbAnio.DataSource = dtPeriodos
            cmbAnio.DropDownList.DataMember = dtPeriodos.Columns("Descripcion").ToString
            cmbAnio.DropDownList.DisplayMember = dtPeriodos.Columns("Descripcion").ToString
            cmbAnio.DropDownList.ValueMember = dtPeriodos.Columns("Periodo").ToString
            cmbAnio.DropDownList.Columns(0).DataMember = dtPeriodos.Columns("Periodo").ToString
            cmbAnio.DropDownList.Columns(1).DataMember = dtPeriodos.Columns("Descripcion").ToString
            dtPeriodos = Nothing

            '======================================= RUBRO ================================================
            dtRubros = oRecursoService.MostrarRubros(Session.sCodUsu).Tables(0)
            dtRubros.Rows.InsertAt(getRowTodos(dtRubros), 0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("IdRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

            '====================================== ESTADOS ===============================================
            dtEstados = oRecursoService.MostrarEstados()
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            If dtCentroCosto.Rows.Count > 1 Or cmbCodArea.Value = "" Then
                dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            End If
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            listaDatos()

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oRecursoService.Filtrar(Session.sCodEmp, IIf(cmbAnio.SelectedIndex = 0, 0, toNumber(cmbAnio.Value)), cmbCodArea.Value, cmbCentroCosto.Value, toNumber(cmbRubro.Value), IdPersona, txtNumDoc.Text, toBlank(cmbEstado.Value)).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros: " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbRubro.ValueChanged, cmbCentroCosto.ValueChanged, txtColaborador.TextChanged, txtNumDoc.TextChanged, cmbEstado.ValueChanged, cmbAnio.ValueChanged
        listaDatos()
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
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdRecurso").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColaborador.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarColaborador.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkColaborador.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtColaborador.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtColaborador.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkColaborador.CheckedChanged
        If txtColaborador.Text <> "(Todos)" Then
            chkColaborador.Enabled = False
            txtColaborador.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkColaborador.Enabled = True
            pboxLimpiarColaborador.Enabled = True
        End If
    End Sub

    Private Sub biEntregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEntregar.Click, miEntregar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de ENTREGAR el Recurso N°: " & dgvDatos.CurrentRow.Cells("IdRecurso").Value.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oRecursoService.Entregar(toNumber(dgvDatos.CurrentRow.Cells("IdRecurso").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Entregó correctamente el Recurso.")
                        Actualizar()
                    Else
                        MsgBox("Error en el proceso,comuniquese con el departamento de sistemas.")
                    End If
                End If
            Else
                MsgBox("¡No existen datos, Verifique...!")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ENTREGAR RECURSO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                         biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave,
                         biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave,
                         biEliminar.MouseLeave, miEliminar.MouseLeave, biEntregar.MouseLeave, miEntregar.MouseLeave,
                         biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Memo de Asignación de Recurso actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Asignación deRecurso."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Asignación de Recurso actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Asignación de Recurso actual."
    End Sub
    Private Sub Entregar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEntregar.MouseEnter, miEntregar.MouseEnter
        sslError.Text = "Entregar Recurso actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click

        iEstado = toBlank(dgvDatos.CurrentRow.Cells("Estado").Value)

        If iEstado = "DE" Then
            Try
                If ValidaCodigoSeleccionado() Then
                    Dim frm As New frmAsignacionRecurso_Imp
                    frm.IdRecurso = dgvDatos.CurrentRow.Cells("IdRecurso").Value
                    frm.ShowDialog()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
        Else
            ImprimirReporte()
        End If
    End Sub

    Private Sub ImprimirReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptAsignacionRecurso
            If dgvDatos.RowCount > 0 Then
                dtReporte = oRecursoService.Imprimir(toNumber(dgvDatos.CurrentRow.Cells("IdRecurso").Value)).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Asignación de Recurso Nº" + dgvDatos.CurrentRow.Cells("IdRecurso").Text
                    forma.ShowDialog()
                End If
            Else
                MsgBox("!No hay Datos que mostrar, verifique...!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biCopiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biCopiar.Click, miCopiar.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmCopiar_Recurso
                frm.IdRecurso = dgvDatos.CurrentRow.Cells("IdRecurso").Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    biRefrescar_Click(sender, e)
                    RowPossesion(dgvDatos, frm.IdRecurso)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al COPIAR Asignación de Recurso: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class