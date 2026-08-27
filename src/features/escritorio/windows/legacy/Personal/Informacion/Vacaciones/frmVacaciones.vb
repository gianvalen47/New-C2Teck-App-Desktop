Imports System.ServiceModel
Public Class frmVacaciones

    '=========================== Servicios ====================================================
    Private oVacacionesService As New VacacionesService.VacacionesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public IdPersona As Integer
    Private dtDatos As New DataTable
    Private dtAreas As DataTable
    Private dtEstados As DataTable
    Private dtCentroCosto As New DataTable
    Private dtPeriodos As New DataTable
    Public iEstado As String


    '==========================Evento Load===================================================
    Private Sub frmVacaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 208)
        '/*************************************************************************************/

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
        cmbAnio.Value = Today.Year
        listaDatos()
        dgvDatos.Select()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              cmbCodArea.KeyPress _
                           , cmbCentroCosto.KeyPress _
                           , txtColaborador.KeyPress _
                           , cmbEstado.KeyPress _
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

    '==============================Evento FormClosed==========================================
    Private Sub frmVacaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVacacionesService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oVacacionesService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oVacacionesService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmVacaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                biComprar.Enabled = False

                miImprimir.Enabled = False
                miMostrar.Enabled = False
                miEliminar.Enabled = False
                miComprar.Enabled = False
            Else
                iEstado = oVacacionesService.ObtenerEstado(toNumber(dgvDatos.CurrentRow.Cells("IdVacaciones").Value))
                biImprimir.Enabled = True
                biMostrar.Enabled = True
                biEliminar.Enabled = IIf(iEstado = "P", True, False)
                biComprar.Enabled = IIf(iEstado = "P", True, False)
                biActualizarFecPago.Enabled = IIf(iEstado = "S", True, False)

                miImprimir.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = IIf(iEstado = "P", True, False)
                miComprar.Enabled = IIf(iEstado = "P", True, False)
                miActualizarFecPago.Enabled = IIf(iEstado = "S", True, False)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdVacaciones").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmVacaciones_Nuevo
            Dim lEstado As String
            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            frm.state_button = True
            frm.IdVacaciones = dgvDatos.CurrentRow.Cells("IdVacaciones").Text
            frm.editable = IIf(lEstado = "P", True, False)
            frm.edicion = False
            frm.ApeNom = dgvDatos.CurrentRow.Cells("ApeNom").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    LlenarPeriodos()
                    cmbAnio.Value = frm.Anio
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdVacaciones)
                Else
                    LlenarPeriodos()
                    cmbAnio.Value = frm.Anio
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            LlenarPeriodos()
            cmbAnio.Value = frm.Anio
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL REGISTRO DE VACACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oVacacionesService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdVacaciones").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    llenarCombos()
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL REGISTRO DE VACACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmVacaciones_Nuevo
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.iIdPersona = IdPersona
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    LlenarPeriodos()
                    cmbAnio.Value = frm.Anio
                    Actualizar()
                    RowPossesion(dgvDatos, frm.IdVacaciones)
                    mostrar()
                End If
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR EL NUEVO REGISTRO DE VACACIONES: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub llenarCombos()
        Try

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing
        
            ''=========================================== ESTADOS ==========================================
            dtEstados = oVacacionesService.MostrarEstados()
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

            LlenarPeriodos()
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LlenarPeriodos()
        Try

            ''====================================== PERIODOS ===============================================
            dtPeriodos = oVacacionesService.MostrarPeriodos().Tables(0)
            'dtPeriodos.Rows.InsertAt(getRowTodos(dtPeriodos), 0)
            cmbAnio.DataSource = dtPeriodos
            cmbAnio.DropDownList.DataMember = dtPeriodos.Columns("Descripcion").ToString
            cmbAnio.DropDownList.DisplayMember = dtPeriodos.Columns("Descripcion").ToString
            cmbAnio.DropDownList.ValueMember = dtPeriodos.Columns("Periodo").ToString
            cmbAnio.DropDownList.Columns(0).DataMember = dtPeriodos.Columns("Periodo").ToString
            cmbAnio.DropDownList.Columns(1).DataMember = dtPeriodos.Columns("Descripcion").ToString
            dtPeriodos = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBO PERIODO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, "").Tables(0)
            dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
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
                Dim anio As Integer
                anio = toNumber(cmbAnio.Value)
                dtDatos = oVacacionesService.Filtrar(Session.sCodEmp, toNumber(cmbAnio.Value), cmbCodArea.Value, cmbCentroCosto.Value, IdPersona, toBlank(cmbEstado.Value), IIf(cbVigente.Checked = True, True, False)).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros: " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbCentroCosto.ValueChanged, txtColaborador.TextChanged, cmbEstado.ValueChanged, cmbAnio.ValueChanged, cbVigente.CheckedChanged
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
    Private Sub biComprar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biComprar.Click, miComprar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de COMPRAR registro de Vacaciones N° " & dgvDatos.CurrentRow.Cells("IdVacaciones").Value.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oVacacionesService.Comprar(toNumber(dgvDatos.CurrentRow.Cells("IdVacaciones").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("Se compró el registro de vacaciones correctamente.")
                        Actualizar()
                    Else
                        MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
                    End If
                End If
            Else
                MsgBox("¡No existen datos, Verifique...!")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL COMPRAR REGISTRO DE VACACIONES : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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
            codigo = dgvDatos.CurrentRow.Cells("IdVacaciones").Text
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

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                           biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave, _
                           biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave, _
                           biEliminar.MouseLeave, miEliminar.MouseLeave, biComprar.MouseLeave, miComprar.MouseLeave, _
                           biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave, _
                           biIngresoMasivo.MouseLeave, miIngresoMasivo.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir registro de Vacaciones actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo registro de Vacaciones."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar registro de Vacaciones actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar registro de Vacaciones actual."
    End Sub
    Private Sub Comprar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biComprar.MouseEnter, miComprar.MouseEnter
        sslError.Text = "Comprar registro de Vacaciones actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub IngresoMasivo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biIngresoMasivo.MouseEnter, miIngresoMasivo.MouseEnter
        sslError.Text = "Ingresar Vacaciones de Personal Masivo."
    End Sub

    Private Sub biIngresoMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biIngresoMasivo.Click, miIngresoMasivo.Click
        Try
            Dim frm As New frmVacaciones_masivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al generar VACACIONES MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizarFecPago_Click(sender As Object, e As EventArgs) Handles biActualizarFecPago.Click, miActualizarFecPago.Click
        Try
            Dim frm As New frmVacaciones_ActualizarFecha
            frm.IdVacaciones = dgvDatos.CurrentRow.Cells("IdVacaciones").Text
            frm.Colaborador = dgvDatos.CurrentRow.Cells("ApeNom").Value
            'frm.FecPago = dgvDatos.CurrentRow.Cells("FecPago").Value
            'frm.Observacion = dgvDatos.CurrentRow.Cells("Observacion").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
        Catch ex As Exception
            MsgBox("Error al ACTUALIZAR el Job: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class