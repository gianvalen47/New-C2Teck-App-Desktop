Imports System.ServiceModel
Public Class frmCronogramaMina_Masivo

    '===========================Servicios====================================================
    Private oAsignacionHorarioService As New AsignacionHorarioService.AsignacionHorarioServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================================
    Private dtTipo As DataTable
    Private dtUbicacion As DataTable
    Private dtClase As DataTable
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable
    Private dtSeleccionados As DataTable
    Private dtPersonal As DataTable

    Public IdCronograma As Integer
    Private IdPer As Integer
    Private ApeNom As String

    Private Sub frmCronogramaMina_Masivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvPersonal.BackgroundColor = Color.Beige
        dgvPersonal.BackColor = Color.Beige
        dgvPersonal.ForeColor = Color.MidnightBlue
        dgvPersonal.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False
        llenarCombos()

        txtFechaInicio.Value = Today
        txtFechaFinal.Value = Today
    End Sub

    Private Sub frmCronogramaMina_Masivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmDescuentosPersonal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oPersonaService.Close()
            oMaestroService.Close()
            oAsignacionHorarioService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oPersonaService.Abort()
            oMaestroService.Abort()
            oAsignacionHorarioService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oPersonaService.Abort()
            oMaestroService.Abort()
            oAsignacionHorarioService.Abort()
            oJobService.Abort()
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

    Private Sub llenarCombos()
        Try

            '======================================== AREAS ================================================
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
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

            '======================================== TIPO ================================================
            dtTipo = oAsignacionHorarioService.MostrarTipoCronograma().Tables(0)
            'dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cmbTipo.DataSource = dtTipo
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("IdTipo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("IdTipo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("DesTipo").ToString
            cmbTipo.SelectedIndex = 0
            dtTipo = Nothing

            '===================================== UBICACIÓN ===============================================
            dtUbicacion = oJobService.MostrarUbicacionEquipo.Tables(0)
            'dtUbicacion.Rows.InsertAt(getRowTodos(dtUbicacion), 0)
            cmbUbicacion.DataSource = dtUbicacion
            cmbUbicacion.DropDownList.DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.DisplayMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.DropDownList.ValueMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(0).DataMember = dtUbicacion.Columns("CodUbicacion").ToString
            cmbUbicacion.DropDownList.Columns(1).DataMember = dtUbicacion.Columns("DesUbicacion").ToString
            cmbUbicacion.SelectedIndex = 0
            dtUbicacion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
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

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbClase.ValueChanged, cmbCentroCosto.ValueChanged
        listaDatos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvSeleccionados.RowCount < 1 Then
                MsgBox("Debe seleccionar al menos un Colaborador.", MsgBoxStyle.Information, "Información")
                dgvPersonal.Focus()
                Return False
            ElseIf toBlank(cmbUbicacion.Value) = "" Then
                MsgBox("Debe Ingresar la Ubicación del Cronograma de Mina.", MsgBoxStyle.Information, "Información")
                cmbUbicacion.Focus()
                Return False
            ElseIf toBlank(cmbTipo.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo del Cronograma de Mina.", MsgBoxStyle.Information, "Información")
                cmbTipo.Focus()
                Return False
            ElseIf toBlank(txtFechaInicio.Value) = "" Or toBlank(txtFechaFinal.Value) = "" Then
                MsgBox("Debe de Ingresar las fechas de duración.", MsgBoxStyle.Information, "Información")
                txtFechaInicio.Focus()
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

                        Dim registro As New AsignacionHorarioService.CronogramaMinas
                        Dim Colaborador As New AsignacionHorarioService.Persona
                        Dim Ubicacion As New AsignacionHorarioService.UbicacionEquipo
                        Dim Tipo As New AsignacionHorarioService.TipoCronograma

                        registro.IdCronograma = IdCronograma
                        Colaborador.IdPer = dgvSeleccionados.Item("cIdPer1".ToLower, i).Value
                        registro.Persona = Colaborador
                        Ubicacion.CodUbicacion = cmbUbicacion.Value
                        registro.UbicacionEquipo = Ubicacion
                        Tipo.IdTipo = cmbTipo.Value
                        registro.TipoCronograma = Tipo
                        registro.FecInicio = txtFechaInicio.Value
                        registro.FecFinal = txtFechaFinal.Value
                        registro.Observacion = IIf(txtObservacion.Text = "", Nothing, txtObservacion.Text)
                        registro.NomPc = Session.sNomPc
                        registro.DirIp = Session.sDirIp
                        registro.CodUsu = Session.sCodUsu

                        'Try
                        Dim estado_process As Integer
                        estado_process = oAsignacionHorarioService.InsertarCronograma(registro)
                        If estado_process > 0 Then
                            Cont = Cont + 1
                        End If
                        'Catch ex As Exception
                        'MsgBox("ERROR AL INSERTAR FALTA : " + ex.Message, MsgBoxStyle.Exclamation)
                        'End Try
                    Next

                    If Cont > 0 Then
                        MsgBox("Se insertó el(los) Cronograma(s) de Mina Correctamente.")
                        LimpiarDatos()
                        listaDatos()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR CRONOGRAMA(S) DE MINA MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        cmbArea.SelectedIndex = 0
        cmbCentroCosto.SelectedIndex = 0
        cmbClase.SelectedIndex = 0
        cmbTipo.SelectedIndex = 0
        cmbUbicacion.SelectedIndex = 0
        txtFechaInicio.Value = Today
        txtFechaFinal.Value = Today
        txtObservacion.Text = ""
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             cmbArea.KeyPress _
                           , cmbCentroCosto.KeyPress _
                           , cmbClase.KeyPress _
                           , txtFechaInicio.KeyPress _
                           , txtFechaFinal.KeyPress _
                           , cmbTipo.KeyPress _
                           , cmbUbicacion.KeyPress
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