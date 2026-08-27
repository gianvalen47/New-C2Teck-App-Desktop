Imports System.ServiceModel
Public Class frmImpHorasServicio

    '=========================== Servicios ====================================================
    Private oHoraExtraService As New HoraExtraService.HoraExtraServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    Private oJobService As New JobService.JobServiceClient

    '======================Declaración de Variables==============================================
    Public IdPersona As Integer = 0
    Private dtPerAutoriza As DataTable
    Private dtDatos As DataTable

    Private Sub frmImpHorasServicio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        LlenarCombos()
        txtFecInicio.Focus()
    End Sub

    Private Sub frmImpHorasServicio_Masivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmAsignacionHE_Masivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    cmbPerAutoriza.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Finalizar()
        Try
            oHoraExtraService.Close()
            oAsignacionJefesService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oHoraExtraService.Abort()
            oAsignacionJefesService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oHoraExtraService.Abort()
            oAsignacionJefesService.Abort()
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

    Private Sub LlenarCombos()
        Try
            '=================================== PERSONA AUTORIZA ==========================================
            dtPerAutoriza = oAsignacionJefesService.MostrarJefeAreaEmpresa(Session.sCodEmp).Tables(0)
            'dtPerAutoriza.Rows.InsertAt(getRowNinguno(dtPerAutoriza), 0)
            cmbPerAutoriza.DataSource = dtPerAutoriza
            cmbPerAutoriza.DropDownList.DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.DisplayMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.ValueMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(0).DataMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(1).DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.SelectedIndex = 0
            dtPerAutoriza = Nothing
        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtColaborador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColaborador.TextChanged
        If txtColaborador.Text <> "" Then
            Persona = oPersonaService.Obtener(IdPersona)

            '=================================== PERSONA AUTORIZA ==========================================
            dtPerAutoriza = oAsignacionJefesService.MostrarJefeArea(Persona.CentroCosto.CodCentro).Tables(0)
            'dtPerAutoriza.Rows.InsertAt(getRowNinguno(dtPerAutoriza), 0)
            cmbPerAutoriza.DataSource = dtPerAutoriza
            cmbPerAutoriza.DropDownList.DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.DisplayMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.ValueMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(0).DataMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(1).DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.SelectedIndex = 0
            dtPerAutoriza = Nothing

            ListaDatos()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("No existen horas que importar.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf txtFecInicio.Value > txtFecFinal.Value Then
                MsgBox("La fecha de inicio no debe ser mayor a la fecha final.", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
                'ElseIf toNumber(IdPersona) = 0 Then
                '    MsgBox("Debe ingresar el Colaborador. ", MsgBoxStyle.Information, "Información")
                '    txtColaborador.Focus()
                '    Return False
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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim estado_process As Boolean
                    estado_process = oHoraExtraService.ImportarHoraServicios(Session.sCodEmp, IdPersona, txtFecInicio.Value, txtFecFinal.Value, toNumber(cmbPerAutoriza.Value), txtObservacion.Text, txtNumJob.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("Se importó los datos correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR ASIGNACIÓN DE HORAS EXTRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                             txtFecInicio.KeyPress _
                             , txtFecFinal.KeyPress _
                           , txtColaborador.KeyPress _
                           , cmbPerAutoriza.KeyPress _
                           , txtObservacion.KeyPress _
                           , txtNumJob.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFecInicio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecInicio.ValueChanged, txtFecFinal.ValueChanged
        If Not (txtFecInicio.Value > txtFecFinal.Value) Then
            ListaDatos()
        End If
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oHoraExtraService.MostrarHoraServicios(Session.sCodEmp, IdPersona, txtFecInicio.Value, txtFecFinal.Value, txtNumJob.Text).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de Job no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                    'ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    '    MsgBox("Número de Job Liquidado o Facturado")
                    '    txtNumJob.Text = ""
                    '    txtNumJob.Focus()
                Else
                    txtObservacion.Focus()
                End If
            Else
                txtObservacion.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL JOB : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                e.Handled = True
                btnBuscarJob_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de Job no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                    'ElseIf (oJobService.Estado(txtNumJob.Text) = 16 Or oJobService.Estado(txtNumJob.Text) = 25) And oJobService.Regularizar(txtNumJob.Text) = False Then
                    '    MsgBox("Número de Job Liquidado o Facturado")
                    '    txtNumJob.Text = ""
                    '    txtNumJob.Focus()
                Else
                    txtObservacion.Focus()
                End If
            Else
                txtObservacion.Focus()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, txtColaborador.TextChanged, txtNumJob.TextChanged, cmbPerAutoriza.ValueChanged, txtFecInicio.ValueChanged, txtFecFinal.ValueChanged
        ListaDatos()
    End Sub
End Class