Imports System.ServiceModel
Public Class frmFaltaPersonalMasivo

    '===========================Servicios====================================================
    Private oFaltasService As New FaltasService.FaltasServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient

    '======================Declaración de Variables==============================================
    Private dtClase As DataTable
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtMotivo As DataTable
    Private dtPerAutoriza As DataTable

    Private dtSeleccionados As DataTable
    Private dtPersonal As DataTable

    Public IdFalta As Integer
    Private IdPer As Integer
    Private ApeNom As String

    Private Sub frmFaltaPersonalMasivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvPersonal.BackgroundColor = Color.Beige
        dgvPersonal.BackColor = Color.Beige
        dgvPersonal.ForeColor = Color.MidnightBlue
        dgvPersonal.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False
        LlenarCombos()
        cmbMotivo.Value = "02"
    End Sub

    Private Sub frmFaltaPersonalMasivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmFaltaPersonalMasivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oFaltasService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oFaltasService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oFaltasService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
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

    Private Sub LlenarCombos()
        Try

            '======================================== AREAS ================================================
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtArea
            cmbArea.DropDownList.DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtArea = Nothing

            '======================================== CLASE ================================================
            dtClase = oPersonaService.MostrarClases.Tables(0)
            dtClase.Rows.InsertAt(getRowTodos(dtClase), 0)
            cmbClase.DataSource = dtClase
            cmbClase.DropDownList.DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.DisplayMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.ValueMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(0).DataMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(1).DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.SelectedIndex = 0
            dtClase = Nothing

            '======================================== MOTIVO ================================================
            dtMotivo = oFaltasService.MostrarMotivos(Session.sCodUsu).Tables(0)
            cmbMotivo.DataSource = dtMotivo
            cmbMotivo.DropDownList.DataMember = dtMotivo.Columns("DesMotivo").ToString
            cmbMotivo.DropDownList.DisplayMember = dtMotivo.Columns("DesMotivo").ToString
            cmbMotivo.DropDownList.ValueMember = dtMotivo.Columns("CodMotivo").ToString
            cmbMotivo.DropDownList.Columns(0).DataMember = dtMotivo.Columns("CodMotivo").ToString
            cmbMotivo.DropDownList.Columns(1).DataMember = dtMotivo.Columns("DesMotivo").ToString
            cmbMotivo.DropDownList.Columns(2).DataMember = dtMotivo.Columns("ValorTiempo").ToString
            cmbMotivo.SelectedIndex = 0
            dtMotivo = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, Session.sCodUsu).Tables(0)
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

    Private Sub cmbCentroCosto_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCentroCosto.ValueChanged
        Try
            If cmbCentroCosto.Value <> "" Then
                '==================================== PERSONA AUTORIZA ==========================================
                dtPerAutoriza = oAsignacionJefesService.MostrarJefeArea(toBlank(cmbCentroCosto.Value)).Tables(0)
                cmbPerAutoriza.DataSource = dtPerAutoriza
                cmbPerAutoriza.DropDownList.DataMember = dtPerAutoriza.Columns("ApeNom").ToString
                cmbPerAutoriza.DropDownList.DisplayMember = dtPerAutoriza.Columns("ApeNom").ToString
                cmbPerAutoriza.DropDownList.ValueMember = dtPerAutoriza.Columns("IdPer").ToString
                cmbPerAutoriza.DropDownList.Columns(0).DataMember = dtPerAutoriza.Columns("IdPer").ToString
                cmbPerAutoriza.DropDownList.Columns(1).DataMember = dtPerAutoriza.Columns("ApeNom").ToString
                If dtPerAutoriza.Rows.Count > 0 Then
                    cmbPerAutoriza.SelectedIndex = 0
                End If
                dtPerAutoriza = Nothing
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR PERSONA AUTORIZA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            '===================================== LISTA PERSONAL ======================================
            dtPersonal = oPersonaService.Filtrar(Session.sCodEmp, toBlank(cmbArea.Value), toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), "", True).Tables(0)
            dgvPersonal.DataSource = dtPersonal

            cIdPer.DataPropertyName = dtPersonal.Columns("IdPer").ColumnName
            cApeNom.DataPropertyName = dtPersonal.Columns("ApeNom").ColumnName

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oPersonaService.Filtrar("", "", "", "", "", True).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdPer1.DataPropertyName = dtSeleccionados.Columns("IdPer").ColumnName
            cApeNom1.DataPropertyName = dtSeleccionados.Columns("ApeNom").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvPersonal.RowCount > 0 Then
                btnAgregar.Enabled = True
                btnAgregarTodos.Enabled = True
            Else
                btnAgregar.Enabled = False
                btnAgregarTodos.Enabled = False
            End If

            If dgvSeleccionados.RowCount > 0 Then
                btnRegresar.Enabled = True
                btnRegresarTodos.Enabled = True
            Else
                btnRegresar.Enabled = False
                btnRegresarTodos.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click        
        AgregarFila(dtSeleccionados, dgvSeleccionados, dgvPersonal)
        EnableOptions()
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdPer = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdPer").Value.ToString
            ApeNom = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cApeNom").Value.ToString

            dr("IdPer") = IdPer
            dr("ApeNom") = ApeNom

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click       
        DesagregarFila(dtPersonal, dgvPersonal, dgvSeleccionados)
        EnableOptions()
    End Sub

    Private Sub DesagregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdPer = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdPer1").Value.ToString
            ApeNom = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cApeNom1").Value.ToString

            dr("IdPer") = IdPer
            dr("ApeNom") = ApeNom

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click       
        For i As Integer = 0 To dgvPersonal.RowCount - 1
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvPersonal)
        Next
        EnableOptions()
    End Sub

    Private Sub btnRegresarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresarTodos.Click
        For i As Integer = 0 To dgvSeleccionados.RowCount - 1
            DesagregarFila(dtPersonal, dgvPersonal, dgvSeleccionados)
        Next
        EnableOptions()
    End Sub

    Private Sub EliminarFila(ByVal dgvDatos As DataGridView)
        dgvDatos.Rows.Remove(dgvDatos.CurrentRow)
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbClase.ValueChanged
        listaDatos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbMotivo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMotivo.ValueChanged
        If cmbMotivo.ReadOnly = False Then
            If cmbMotivo.DropDownList.GetRow.Cells(2).Text = "Dias" Then
                txtHoraInicio.ReadOnly = True
                txtHoraInicio.BackColor = System.Drawing.SystemColors.Control
                txtHoraFinal.ReadOnly = True
                txtHoraFinal.BackColor = System.Drawing.SystemColors.Control
                txtHoraInicio.Text = ""
                txtHoraFinal.Text = ""
            Else
                txtHoraInicio.ReadOnly = False
                txtHoraInicio.BackColor = System.Drawing.SystemColors.Window
                txtHoraFinal.ReadOnly = False
                txtHoraFinal.BackColor = System.Drawing.SystemColors.Window
                txtHoraInicio.Text = Now().ToString("HH:mm:ss")
                txtHoraFinal.Text = Now().ToString("HH:mm:ss")
            End If
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvSeleccionados.RowCount < 1 Then
                MsgBox("Debe seleccionar al menos un Colaborador.", MsgBoxStyle.Information, "Información")
                dgvPersonal.Focus()
                Return False
            ElseIf toBlank(cmbMotivo.Value) = "" Then
                MsgBox("Debe Ingresar el motivo de la falta.", MsgBoxStyle.Information, "Información")
                cmbMotivo.Focus()
                Return False
            ElseIf toBlank(cmbMotivo.Value) = "01" Then
                MsgBox("El motivo vacaciones se ingresa por el módulo de vacaciones.", MsgBoxStyle.Information, "Información")
                cmbMotivo.Focus()
                Return False
            ElseIf toBlank(txtFechaInicio.Value) = "" Or toBlank(txtFechaFinal.Value) = "" Then
                MsgBox("Debe de Ingresar las fechas de duración.", MsgBoxStyle.Information, "Información")
                txtFechaInicio.Focus()
                Return False
            ElseIf cmbMotivo.DropDownList.GetRow.Cells(2).Text = "Horas" And (Not (txtHoraInicio.MaskFull) Or Not (txtHoraFinal.MaskFull)) Then
                MsgBox("Debe de Ingresar las horas.", MsgBoxStyle.Information, "Información")
                txtHoraInicio.Focus()
                Return False
            ElseIf toBlank(cmbPerAutoriza.Value) = "" Then
                MsgBox("Debe de Ingresar la persona que autoriza.", MsgBoxStyle.Information, "Información")
                cmbPerAutoriza.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim Cont As Integer = 0
                    For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                        Dim registro As New FaltasService.Faltas
                        Dim Colaborador As New FaltasService.Persona
                        Dim PersonaAutoriza As New FaltasService.Persona
                        Dim MotivoFalta As New FaltasService.MotivoFaltas
                        Dim VacacionesDet As New FaltasService.VacacionesDet    'Para faltas que vienen de Mantenimiento Vacaciones

                        registro.IdFalta = IdFalta
                        IdPer = dgvSeleccionados.Item("cIdPer1".ToLower, i).Value

                        Colaborador.IdPer = IdPer
                        registro.Persona = Colaborador
                        MotivoFalta.CodMotivo = cmbMotivo.Value
                        registro.MotivoFaltas = MotivoFalta
                        registro.FecInicio = txtFechaInicio.Value
                        registro.FecFinal = txtFechaFinal.Value
                        registro.HorInicio = IIf(Not (txtHoraInicio.MaskFull), Nothing, txtHoraInicio.Text)
                        registro.HorFinal = IIf(Not (txtHoraFinal.MaskFull), Nothing, txtHoraFinal.Text)
                        PersonaAutoriza.IdPer = cmbPerAutoriza.Value
                        registro.PersonaAutoriza = PersonaAutoriza
                        registro.Observacion = txtObservacion.Text
                        VacacionesDet.IdVacacionesDet = Nothing
                        registro.VacacionesDet = VacacionesDet
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp
                        registro.CodUsu = Session.sCodUsu
                        registro.FecReg = Today

                        'Try
                        Dim estado_process As Integer
                        estado_process = oFaltasService.Insertar(registro)
                        If estado_process > 0 Then
                            Cont = Cont + 1
                        End If
                        'Catch ex As Exception
                        'MsgBox("ERROR AL INSERTAR FALTA : " + ex.Message, MsgBoxStyle.Exclamation)
                        'End Try
                    Next

                    If Cont > 0 Then
                        MsgBox("Se insertó la(s) Falta(s) Correctamente.")
                        LimpiarDatos()
                        listaDatos()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR FALTA(S) MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        cmbArea.SelectedIndex = 0
        cmbCentroCosto.SelectedIndex = 0
        cmbClase.SelectedIndex = 0
        cmbMotivo.Value = "02"
        txtObservacion.Text = ""
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              cmbArea.KeyPress _
                            , cmbCentroCosto.KeyPress _
                            , cmbClase.KeyPress _
                            , cmbMotivo.KeyPress _
                            , txtFechaInicio.KeyPress _
                            , txtFechaFinal.KeyPress _
                            , cmbPerAutoriza.KeyPress _
                            , txtHoraInicio.KeyPress _
                            , txtHoraFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            cmbArea.Focus()
        End If
    End Sub
End Class