Imports System.ServiceModel
Public Class frmVacaciones_masivo

    '===========================Servicios====================================================
    Private oVacacionesService As New VacacionesService.VacacionesServiceClient
    Private oVacacionesDetService As New VacacionesDetService.VacacionesDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables============================================
    Private dtPeriodos As New DataTable
    Private dtClase As DataTable
    Private dtArea As DataTable
    Private dtCentroCosto As DataTable

    Private dtSeleccionados As DataTable
    Private dtPersonal As DataTable

    Private IdVacaciones As Integer
    Private IdPer As Integer
    Private ApeNom As String
    Private DiasPen As Integer

    Private Sub frmVacaciones_masivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvPersonal.BackgroundColor = Color.Beige
        dgvPersonal.BackColor = Color.Beige
        dgvPersonal.ForeColor = Color.MidnightBlue
        dgvPersonal.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False

        LlenarCombos()
        cmbAnio.Value = Today.Year
        txtFechaInicio.Value = Today
        txtFechaFinal.Value = Today
        listaDatos()
    End Sub

    Private Sub frmVacaciones_masivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmVacaciones_masivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oVacacionesService.Close()
            oVacacionesDetService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oVacacionesService.Abort()
            oVacacionesDetService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oVacacionesService.Abort()
            oVacacionesDetService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
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
            'dtClase.Rows.InsertAt(getRowTodos(dtClase), 0)
            cmbClase.DataSource = dtClase
            cmbClase.DropDownList.DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.DisplayMember = dtClase.Columns("DesClas").ToString
            cmbClase.DropDownList.ValueMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(0).DataMember = dtClase.Columns("CodClas").ToString
            cmbClase.DropDownList.Columns(1).DataMember = dtClase.Columns("DesClas").ToString
            cmbClase.SelectedIndex = 0
            dtClase = Nothing
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

  
    Private Sub listaDatos()
        Try

            '===================================== LISTA DATOS =====================================       
            dtPersonal = oVacacionesService.MostrarPendientes(Session.sCodEmp, toBlank(cmbCentroCosto.Value), toBlank(cmbClase.Value), toNumber(cmbAnio.Value)).Tables(0)
            dgvPersonal.DataSource = dtPersonal

            cIdVacaciones.DataPropertyName = dtPersonal.Columns("IdVacaciones").ColumnName
            cIdPer.DataPropertyName = dtPersonal.Columns("IdPer").ColumnName
            cApeNom.DataPropertyName = dtPersonal.Columns("ApeNom").ColumnName            
            cDiasPen.DataPropertyName = dtPersonal.Columns("DiasPen").ColumnName

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oVacacionesService.MostrarPendientes("", "", "", toNumber(cmbAnio.Value)).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdVacaciones1.DataPropertyName = dtSeleccionados.Columns("IdVacaciones").ColumnName
            cIdPer1.DataPropertyName = dtSeleccionados.Columns("IdPer").ColumnName
            cApeNom1.DataPropertyName = dtSeleccionados.Columns("ApeNom").ColumnName
            cDiasPen1.DataPropertyName = dtSeleccionados.Columns("DiasPen").ColumnName

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

            IdVacaciones = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdVacaciones").Value.ToString
            IdPer = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdPer").Value.ToString
            ApeNom = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cApeNom").Value.ToString
            DiasPen = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDiasPen").Value.ToString

            dr("IdVacaciones") = IdVacaciones
            dr("IdPer") = IdPer
            dr("ApeNom") = ApeNom
            dr("DiasPen") = DiasPen

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

            IdVacaciones = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdVacaciones1").Value.ToString
            IdPer = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdPer1").Value.ToString
            ApeNom = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cApeNom1").Value.ToString
            DiasPen = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDiasPen1").Value.ToString

            dr("IdVacaciones") = IdVacaciones
            dr("IdPer") = IdPer
            dr("ApeNom") = ApeNom
            dr("DiasPen") = DiasPen

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

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbClase.ValueChanged, cmbAnio.ValueChanged, cmbCentroCosto.ValueChanged
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
            ElseIf toBlank(txtFechaInicio.Value) = "" Then
                MsgBox("Debe ingresar la fecha inicio.", MsgBoxStyle.Information, "Información")
                txtFechaInicio.Focus()
                Return False
            ElseIf toBlank(txtFechaFinal.Value) = "" Then
                MsgBox("Debe ingresar la fecha final.", MsgBoxStyle.Information, "Información")
                txtFechaFinal.Focus()
                Return False
            ElseIf txtFechaInicio.Value > txtFechaFinal.Value Then
                MsgBox("La fecha de inicio no debe ser mayor que la fecha final.", MsgBoxStyle.Information, "Información")
                txtFechaInicio.Focus()
                Return False
            ElseIf txtFechaFinal.Value < txtFechaInicio.Value Then
                MsgBox("La fecha final no debe ser menor que la fecha de inicio.", MsgBoxStyle.Information, "Información")
                txtFechaFinal.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim Dias As Integer = 0
                    Dim Colaborador As String = ""
                    Dias = DateDiff(DateInterval.Day, txtFechaInicio.Value, txtFechaFinal.Value) + 1
                    For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                        If Dias > toNumber(dgvSeleccionados.Item("cDiasPen1".ToLower, i).Value) Then
                            Colaborador = Colaborador & dgvSeleccionados.Item("cApeNom1".ToLower, i).Value & vbCrLf
                        Else
                            Dim registro As New VacacionesDetService.VacacionesDet
                            Dim Vacaciones As New VacacionesDetService.Vacaciones

                            IdVacaciones = toNumber(dgvSeleccionados.Item("cIdVacaciones1".ToLower, i).Value)
                            Vacaciones.IdVacaciones = IdVacaciones
                            registro.Vacaciones = Vacaciones
                            registro.FecInicio = txtFechaInicio.Value
                            registro.FecFinal = txtFechaFinal.Value
                            registro.Observacion = txtObservacion.Text

                            registro.CodUsu = Session.sCodUsu
                            registro.NomPc = Session.sNomPc
                            registro.DirIp = Session.sDirIp

                            Dim estado_process As Integer
                            estado_process = oVacacionesDetService.Insertar(registro)
                        End If
                    Next

                    If Colaborador = "" Then
                        MsgBox("Se registró el(los) detalle(s) correctamente.", MsgBoxStyle.Information, "Información")
                        listaDatos()
                    Else
                        MsgBox("Los siguientes colaboradores no presentan sifucientes días pendientes:" & vbCrLf & ApeNom, MsgBoxStyle.Information, "Información")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR MASIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        cmbArea.SelectedIndex = 0
        cmbCentroCosto.SelectedIndex = 0
        cmbClase.SelectedIndex = 0
        cmbAnio.SelectedIndex = 0
        txtObservacion.Text = ""
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              cmbArea.KeyPress _
                            , cmbCentroCosto.KeyPress _
                            , cmbClase.KeyPress _
                            , cmbAnio.KeyPress _
                            , txtFechaInicio.KeyPress _
                            , txtFechaFinal.KeyPress
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