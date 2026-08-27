Imports System.Data.OleDb
Imports System.ServiceModel
Public Class frmMotores

    '=========================== Servicios ====================================
    Private oMotorService As New MotorService.MotorServiceClient
    Private oMercaderiaService As New MercaderiaService.MercaderiaServiceClient
    Private oModeloService As New ModeloService.ModeloServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '====================== Declaración de Variables ==============================
    Public state_Search As Boolean
    Private dtDatos As DataTable
    Public IdCliente As Integer

    Private UbicPers As String
    Private dtRubro As DataTable
    Private dtModeloMer As DataTable
    Private dtSerie As DataTable
    Private dtUbicacion As DataTable
    Private dtFabricante As DataTable
    Private dtModeloEquipo As DataTable
    Private dtTipoEquipo As DataTable

    '==========================Evento Load===================================================
    Private Sub frmEquipos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 244)
        '/*************************************************************************************/

        'chkCliente.Enabled = False
        'pboxLimpiarCliente.Enabled = True
        'ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        'ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        llenarCombos()
        ObtenerCodUbicacion()
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub


    Private Sub ObtenerCodUbicacion()

        UbicPers = oMotorService.ObtenerCodUbicacion(Session.sCodUsu)

        If UbicPers = "" Then
            cmbUbicacion.SelectedIndex = 0
        Else
            cmbUbicacion.Value = UbicPers
        End If

    End Sub

    '=============================Evento KeyPress============================================
    Private Sub frmCapacitaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              txtCodMer.KeyPress _
                            , cmbUbicacion.KeyPress _
                            , txtNomEquipo.KeyPress _
                            , cmbModeloEquipo.KeyPress _
                            , cmbTipoEquipo.KeyPress _
                            , cmbModeloMer.KeyPress _
                            , cmbFabricante.KeyPress
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

    '==========================Evento FormClosed=============================================
    Private Sub frmCapacitaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMotorService.Close()
            oMaestroService.Close()
            oMercaderiaService.Close()
            oModeloService.Close()
            oJobService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oMotorService.Abort()
            oMaestroService.Abort()
            oMercaderiaService.Abort()
            oModeloService.Abort()
            oJobService.Abort()
            oSeguridadService.abort()
        Catch ex As CommunicationException
            oMotorService.Abort()
            oMaestroService.Abort()
            oMercaderiaService.Abort()
            oModeloService.Abort()
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmCapacitaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

                miImprimir.Enabled = False
                miMostrar.Enabled = False
                miEliminar.Enabled = False
            Else

                biImprimir.Enabled = True
                biMostrar.Enabled = True
                biEliminar.Enabled = True

                miImprimir.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = True
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

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
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
            If row.Cells("NumSerie").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmMotor
            frm.state_button = True
            frm.codMer = dgvDatos.CurrentRow.Cells("NumSerie").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.codMer)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.codMer)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el motor seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oMotorService.Borrar(toBlank(dgvDatos.CurrentRow.Cells("NumSerie").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmMotor
                frm.state_button = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()
                    If frm.type_process = "insert" Then
                        cmbUbicacion.Value = frm.iUbicacion
                        cmbFabricante.SelectedIndex = 0
                        cmbModeloEquipo.SelectedIndex = 0
                        cmbModeloMer.SelectedIndex = 0
                        cmbTipoEquipo.SelectedIndex = 0
                        RowPossesion(dgvDatos, frm.codMer)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVO MOTOR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''======================================= RUBRO ================================================
            'dtRubro = oMaestroService.MostrarRubroMotor().Tables(0)
            'dtRubro.Rows.InsertAt(getRowTodos(dtRubro), 0)
            'cmbRubroMot.DataSource = dtRubro
            'cmbRubroMot.DropDownList.DataMember = dtRubro.Columns("DesRubMot").ToString
            'cmbRubroMot.DropDownList.DisplayMember = dtRubro.Columns("DesRubMot").ToString
            'cmbRubroMot.DropDownList.ValueMember = dtRubro.Columns("CodRubMot").ToString
            'cmbRubroMot.DropDownList.Columns(0).DataMember = dtRubro.Columns("CodRubMot").ToString
            'cmbRubroMot.DropDownList.Columns(1).DataMember = dtRubro.Columns("DesRubMot").ToString
            'cmbRubroMot.SelectedIndex = 0
            'dtRubro = Nothing

            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

            '=================================== MODELO MOTOR ============================================
            dtModeloMer = oModeloService.Mostrar.Tables(0)
            dtModeloMer.Rows.InsertAt(getRowTodos1(dtModeloMer), 0)
            cmbModeloMer.DataSource = dtModeloMer
            cmbModeloMer.DropDownList.DataMember = dtModeloMer.Columns("Descripcion").ToString
            cmbModeloMer.DropDownList.DisplayMember = dtModeloMer.Columns("Descripcion").ToString
            cmbModeloMer.DropDownList.ValueMember = dtModeloMer.Columns("ModMer").ToString
            cmbModeloMer.DropDownList.Columns(0).DataMember = dtModeloMer.Columns("ModMer").ToString
            cmbModeloMer.DropDownList.Columns(1).DataMember = dtModeloMer.Columns("Descripcion").ToString
            cmbModeloMer.SelectedIndex = 0
            dtModeloMer = Nothing

            ''======================================== SERIE ================================================
            'dtSerie = oMotorService.MostrarSeries().Tables(0)
            'dtSerie.Rows.InsertAt(getRowTodos(dtSerie), 0)
            'cmbSerie.DataSource = dtSerie
            'cmbSerie.DropDownList.DataMember = dtSerie.Columns("Descripcion").ToString
            'cmbSerie.DropDownList.DisplayMember = dtSerie.Columns("Descripcion").ToString
            'cmbSerie.DropDownList.ValueMember = dtSerie.Columns("CodSerie").ToString
            'cmbSerie.DropDownList.Columns(0).DataMember = dtSerie.Columns("CodSerie").ToString
            'cmbSerie.DropDownList.Columns(1).DataMember = dtSerie.Columns("Descripcion").ToString
            'cmbSerie.SelectedIndex = 0
            'dtSerie = Nothing

            '==================================== FABRICANTE =============================================
            dtFabricante = oMotorService.MostrarFabricanteEquipo().Tables(0)
            dtFabricante.Rows.InsertAt(getRowTodos(dtFabricante), 0)
            cmbFabricante.DataSource = dtFabricante
            cmbFabricante.DropDownList.DataMember = dtFabricante.Columns("DesFabricante").ToString
            cmbFabricante.DropDownList.DisplayMember = dtFabricante.Columns("DesFabricante").ToString
            cmbFabricante.DropDownList.ValueMember = dtFabricante.Columns("IdFabricante").ToString
            cmbFabricante.DropDownList.Columns(0).DataMember = dtFabricante.Columns("IdFabricante").ToString
            cmbFabricante.DropDownList.Columns(1).DataMember = dtFabricante.Columns("DesFabricante").ToString
            cmbFabricante.SelectedIndex = 0
            dtFabricante = Nothing

            '=================================== MODELO EQUIPO ========================================
            dtModeloEquipo = oMotorService.MostrarModeloEquipo(0).Tables(0)
            dtModeloEquipo.Rows.InsertAt(getRowTodos1(dtModeloEquipo), 0)
            cmbModeloEquipo.DataSource = dtModeloEquipo
            cmbModeloEquipo.DropDownList.DataMember = dtModeloEquipo.Columns("Descripcion").ToString
            cmbModeloEquipo.DropDownList.DisplayMember = dtModeloEquipo.Columns("Descripcion").ToString
            cmbModeloEquipo.DropDownList.ValueMember = dtModeloEquipo.Columns("ModEquipo").ToString
            cmbModeloEquipo.DropDownList.Columns(0).DataMember = dtModeloEquipo.Columns("ModEquipo").ToString
            cmbModeloEquipo.DropDownList.Columns(1).DataMember = dtModeloEquipo.Columns("Descripcion").ToString
            cmbModeloEquipo.SelectedIndex = 0

            '===================================== TIPO EQUIPO ==============================================
            dtTipoEquipo = oMotorService.MostrarTipoEquipo().Tables(0)
            dtTipoEquipo.Rows.InsertAt(getRowTodos(dtTipoEquipo), 0)
            cmbTipoEquipo.DataSource = dtTipoEquipo
            cmbTipoEquipo.DropDownList.DataMember = dtTipoEquipo.Columns("Descripcion").ToString
            cmbTipoEquipo.DropDownList.DisplayMember = dtTipoEquipo.Columns("Descripcion").ToString
            cmbTipoEquipo.DropDownList.ValueMember = dtTipoEquipo.Columns("IdTipo").ToString
            cmbTipoEquipo.DropDownList.Columns(0).DataMember = dtTipoEquipo.Columns("IdTipo").ToString
            cmbTipoEquipo.DropDownList.Columns(1).DataMember = dtTipoEquipo.Columns("Descripcion").ToString
            cmbTipoEquipo.SelectedIndex = 0
            dtTipoEquipo = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbFabricante_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFabricante.ValueChanged
        'Try

        '    '=================================== MODELO EQUIPO ========================================
        '    dtModeloEquipo = oMotorService.MostrarModeloEquipo(toNumber(cmbFabricante.Value)).Tables(0)
        '    dtModeloEquipo.Rows.InsertAt(getRowTodos1(dtModeloEquipo), 0)
        '    cmbModeloEquipo.DataSource = dtModeloEquipo
        '    cmbModeloEquipo.DropDownList.DataMember = dtModeloEquipo.Columns("ModEquipo").ToString
        '    cmbModeloEquipo.DropDownList.DisplayMember = dtModeloEquipo.Columns("ModEquipo").ToString
        '    cmbModeloEquipo.DropDownList.ValueMember = dtModeloEquipo.Columns("ModEquipo").ToString
        '    cmbModeloEquipo.DropDownList.Columns(0).DataMember = dtModeloEquipo.Columns("ModEquipo").ToString
        '    cmbModeloEquipo.DropDownList.Columns(1).DataMember = dtModeloEquipo.Columns("Descripcion").ToString
        '    cmbModeloEquipo.SelectedIndex = 0
        '    listaDatos()

        'Catch ex As Exception
        '    MsgBox("ERROR AL LLENAR MODELO EQUIPO: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oMotorService.Filtrar(Session.sCodEmp, txtNomEquipo.Text, txtCodMer.Text, toNumber(cmbFabricante.Value), IIf(cmbModeloMer.SelectedIndex = 0, "", cmbModeloMer.Value),
                                                                toBlank(cmbUbicacion.Value), IIf(cmbModeloEquipo.SelectedIndex = 0, "",
                                                                cmbModeloEquipo.Value), toNumber(cmbTipoEquipo.Value), 0).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodMer.TextChanged, _
                                                                                    cmbModeloMer.ValueChanged, cmbFabricante.ValueChanged, _
                                                                                    cmbUbicacion.ValueChanged, txtNomEquipo.TextChanged, cmbModeloEquipo.ValueChanged, _
                                                                                    cmbTipoEquipo.ValueChanged
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
            codigo = dgvDatos.CurrentRow.Cells("NumSerie").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
                'ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                '    MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                '    Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    'Private Sub btnBuscarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim frm As New frmBuscarCliente
    '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '            chkCliente.Checked = False
    '            If toNull(frm.codigo) <> Nothing Then
    '                txtCliente.Text = frm.descripcion
    '                IdCliente = frm.codigo
    '            Else
    '                txtCliente.Text = "(Todos)"
    '                IdCliente = 0
    '            End If
    '            listaDatos()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Sub chkCliente_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If txtCliente.Text <> "(Todos)" Then
    '        chkCliente.Enabled = False
    '        txtCliente.Text = "(Todos)"
    '        IdCliente = 0
    '        listaDatos()
    '    Else
    '        chkCliente.Enabled = True
    '        pboxLimpiarCliente.Enabled = True
    '    End If
    'End Sub

    'Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F12 Then
    '        If btnBuscarCliente.Enabled = True Then
    '            e.Handled = True
    '            btnBuscarCliente_Click(sender, e)
    '        End If
    '    End If
    'End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                        biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave, _
                        biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave, _
                        biEliminar.MouseLeave, miEliminar.MouseLeave, _
                        biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Motor actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Motor."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Motor actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Motor actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub biImprimir_Click(sender As System.Object, e As System.EventArgs) Handles biImprimir.Click
        MostrarReporte()
    End Sub

    Private Sub MostrarReporte()
        Try
            If ValidaCodigoSeleccionado() Then
                Dim frm As New frmMotor_Imprimir
                frm.pNumSerie = txtCodMer.Text
                frm.pNomEquipo = txtNomEquipo.Text
                frm.pCodUbicacion = cmbUbicacion.Value
                frm.pDesUbicacion = cmbUbicacion.Text
                frm.pModEquipo = IIf(cmbModeloEquipo.SelectedIndex = 0, "",cmbModeloEquipo.Value)
                frm.pIdFabricante = toNumber(cmbFabricante.Value)
                frm.DesFabricante = cmbFabricante.Text
                frm.pModMer = IIf(cmbModeloMer.SelectedIndex = 0, "", cmbModeloMer.Value)
                frm.pIdTipo = toNumber(cmbTipoEquipo.Value)
                frm.DesTipo = cmbTipoEquipo.Text
                frm.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class