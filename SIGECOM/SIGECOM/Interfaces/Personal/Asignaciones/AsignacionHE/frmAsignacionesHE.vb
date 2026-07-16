Imports System.ServiceModel
Public Class frmAsignacionesHE

    '=========================== Servicios ===================================================
    Private oAsignacionHoraExtraService As New AsignacionHoraExtraService.AsignacionHoraExtraServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Public state_Search As Boolean
    Public IdPersona As Integer
    Private dtDatos As New DataTable
    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable

    Private iProcesado As Boolean                'Check de procesado


    '==========================Evento Load===================================================
    Private Sub frmAsignacionesHE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 210)
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
        txtFecha.Value = Today
        listaDatos()
        dgvDatos.Select()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbCodArea.KeyPress _
                           , cmbCentroCosto.KeyPress _
                           , txtFecha.KeyPress _
                           , txtColaborador.KeyPress
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
    Private Sub frmAsignacionesHE_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oAsignacionHoraExtraService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oAsignacionHoraExtraService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oAsignacionHoraExtraService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmAsignacionesHE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                biProcesar.Enabled = False

                miImprimir.Enabled = False
                miMostrar.Enabled = False
                miEliminar.Enabled = False
                miProcesar.Enabled = False
            Else
                iProcesado = toBoolean(dgvDatos.CurrentRow.Cells("Procesado").Value)

                biImprimir.Enabled = True
                biMostrar.Enabled = True
                biEliminar.Enabled = IIf(iProcesado = True, False, True)
                biProcesar.Enabled = IIf(iProcesado = True, False, True)

                miImprimir.Enabled = True
                miMostrar.Enabled = True
                miEliminar.Enabled = IIf(iProcesado = True, False, True)
                miProcesar.Enabled = IIf(iProcesado = True, False, True)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdAsignacion").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
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
            If dtAreas.Rows.Count > 1 Then
                cmbCodArea.SelectedIndex = 1
            Else
                cmbCodArea.SelectedIndex = 0
            End If
            dtAreas = Nothing

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
                dtDatos = oAsignacionHoraExtraService.Filtrar(Session.sCodEmp, cmbCodArea.Value, cmbCentroCosto.Value, txtFecha.Value, IdPersona).Tables(0)
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros: " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtFecha.ValueChanged, cmbCentroCosto.ValueChanged, txtColaborador.TextChanged
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
            codigo = dgvDatos.CurrentRow.Cells("IdAsignacion").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub miProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biProcesar.Click, miProcesar.Click
        Try
            If dgvDatos.RowCount > 0 Then
                If MsgBox("¿Está seguro de PROCESAR la Asignación de Hora Extra seleccionada?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oAsignacionHoraExtraService.ProcesarHoraExtra(toNumber(dgvDatos.CurrentRow.Cells("IdAsignacion").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("Se  Procesó la Asignación de Hora Extra correctamente.")
                        Actualizar()
                    Else
                        MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
                    End If
                End If
            Else
                MsgBox("¡No existen datos, Verifique...!")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL PROCESAR ASIGNACIÓN DE HORA EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub Nuevo()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmAsignacionHE
                frm.state_button = False                
                frm.iIdPersona = IdPersona
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    listaDatos()                
                    If frm.type_process = "insert" Then
                        txtFecha.Value = frm.iFecha
                        RowPossesion(dgvDatos, frm.IdAsignacion)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVA ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oAsignacionHoraExtraService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdAsignacion").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmAsignacionHE
            frm.state_button = True
            frm.IdAsignacion = dgvDatos.CurrentRow.Cells("IdAsignacion").Text
            frm.iProcesado = toBoolean(dgvDatos.CurrentRow.Cells("Procesado").Value)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()                
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdAsignacion)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdAsignacion)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA ASIGNACIÓN: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        Try
            If ValidaCodigoSeleccionado() Then
                Dim forma As New frmReportes
                Dim dtReporte As New DataTable
                Dim reporte As New rptAsignacionHE

                dtReporte = oAsignacionHoraExtraService.Imprimir(toNumber(dgvDatos.CurrentRow.Cells("IdAsignacion").Value)).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("¡No hay Datos que mostrar, verifique.!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    '            forma.crvReportes.DisplayGroupTree = False
                    forma.Text = "Reporte de Asignación de HE de Personal"
                    forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub biAprobarMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAprobarMasivo.Click, miAprobarMasivo.Click
        Try
            Dim frm As New frmAsignacionHE_Masivo
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar()
            End If
            Actualizar()
        Catch ex As Exception
            MsgBox("Error al generar ASIGNACIONES DE HORAS EXTRA MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImprimirMasivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimirMasivo.Click, miImprimirMasivo.Click
        Try
            Dim frm As New frmAsignacionHE_Imprimir
            frm.iCodArea = cmbCodArea.Value
            frm.iCodCentro = cmbCentroCosto.Value
            frm.iFecha = txtFecha.Value
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                      biImprimir.MouseLeave, miImprimir.MouseLeave, biNuevo.MouseLeave, miNuevo.MouseLeave, _
                                      biMostrar.MouseLeave, miMostrar.MouseLeave, biEliminar.MouseLeave, miEliminar.MouseLeave, _
                                      biEliminar.MouseLeave, miEliminar.MouseLeave, biAprobarMasivo.MouseLeave, miAprobarMasivo.MouseLeave, _
                                      biActualizar.MouseLeave, miActualizar.MouseLeave, biSalir.MouseLeave, miSalir.MouseLeave, _
                                      biImprimirMasivo.MouseLeave, miImprimirMasivo.MouseLeave, biProcesar.MouseLeave, miProcesar.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.MouseEnter, biImprimir.MouseEnter
        sslError.Text = "Imprimir Asignación actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Asignación."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Asignación actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Asignación actual."
    End Sub
    Private Sub Procesa_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biProcesar.MouseEnter, miProcesar.MouseEnter
        sslError.Text = "Procesar Asignación actual."
    End Sub
    Private Sub Aprobar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAprobarMasivo.MouseEnter, miAprobarMasivo.MouseEnter
        sslError.Text = "Ingresar Asignación de HE Masivo."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub ImprimirMasivo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimirMasivo.MouseEnter, miImprimirMasivo.MouseEnter
        sslError.Text = "Imprimir Asignación de HE de Personal Masivo."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
End Class