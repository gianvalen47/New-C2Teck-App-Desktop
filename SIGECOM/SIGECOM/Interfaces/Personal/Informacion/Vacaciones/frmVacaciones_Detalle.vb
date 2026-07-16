Imports System.ServiceModel
Public Class frmVacaciones_Detalle

    '============================Servicios===================================
    Private oVacacionesService As New VacacionesService.VacacionesServiceClient
    Private oVacacionesDetService As New VacacionesDetService.VacacionesDetServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient

    '======================Declaración de Variables==============================
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Private dtDatos As DataTable
    Private dtPerAutoriza As DataTable
    Public IdVacacionesDet As Integer
    Public IdVacaciones As Integer
    Public iEstado As String                     'Estado del registro de vacaciones


    Private Sub frmVacaciones_Detalle_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmVacaciones_Detalle_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        llenarCombos()

        txtFecInicio.Focus()
        If state_button Then                'Modificar
            ObtenerRegistro()
            desactivar()
            txtFecInicio.Focus()
        Else                                      'Nuevo
            activar()
            txtFecInicio.Focus()
        End If
        EnableOptions()
        txtFecInicio.Focus()
    End Sub

    Private Sub frmVacaciones_Detalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oVacacionesService.Close()
            oVacacionesDetService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oVacacionesService.Abort()
            oVacacionesDetService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oVacacionesService.Abort()
            oVacacionesDetService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtFecInicio.Value) = "" Then
                MsgBox("Debe ingresar la fecha inicio. ", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            ElseIf toBlank(txtFecFinal.Value) = "" Then
                MsgBox("Debe ingresar la fecha final", MsgBoxStyle.Information, "Información")
                txtFecFinal.Focus()
                Return False
            ElseIf txtFecInicio.Value > txtFecFinal.Value Then
                MsgBox("La fecha de inicio no debe ser mayor que la fecha final.", MsgBoxStyle.Information, "Información")
                txtFecInicio.Focus()
                Return False
            ElseIf txtFecFinal.Value < txtFecInicio.Value Then
                MsgBox("La fecha final no debe ser menor que la fecha de inicio.", MsgBoxStyle.Information, "Información")
                txtFecFinal.Focus()
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

    Private Sub EnableOptions()
        If iEstado = "P" Then
            btnGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            desactivar()
        End If
    End Sub

    Private Sub activar()          
        txtFecInicio.ReadOnly = False
        txtFecInicio.BackColor = System.Drawing.SystemColors.Window
        txtFecFinal.ReadOnly = False
        txtFecFinal.BackColor = System.Drawing.SystemColors.Window
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        cmbPerAutoriza.ReadOnly = False
        cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Window
        ckComprar.Enabled = True

    End Sub

    Private Sub desactivar()
        If iEstado = "P" Then
            activar()
        Else
            txtFecInicio.ReadOnly = True
            txtFecInicio.BackColor = System.Drawing.SystemColors.Control
            txtFecFinal.ReadOnly = True
            txtFecFinal.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            cmbPerAutoriza.ReadOnly = True
            cmbPerAutoriza.BackColor = System.Drawing.SystemColors.Control
            ckComprar.Enabled = False
        End If
    End Sub

    Private Sub Insertar(ByVal registro As VacacionesDetService.VacacionesDet)
        Try
            Dim estado_process As Integer
            estado_process = oVacacionesDetService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdVacacionesDet = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As VacacionesDetService.VacacionesDet)
        Try
            Dim estado_process As Boolean
            estado_process = oVacacionesDetService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As VacacionesDetService.VacacionesDet
            registro = oVacacionesDetService.Obtener(IdVacacionesDet)

            IdVacacionesDet = registro.IdVacacionesDet
            IdVacaciones = registro.Vacaciones.IdVacaciones
            txtFecInicio.Value = registro.FecInicio
            txtFecFinal.Value = registro.FecFinal
            txtObservacion.Text = registro.Observacion
            ckComprar.Checked = registro.Comprado
            cmbPerAutoriza.Value = registro.PersonaAutoriza.IdPer
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then
            Dim registro As New VacacionesDetService.VacacionesDet
            Dim Vacaciones As New VacacionesDetService.Vacaciones
            Dim personaAutoriza As New VacacionesDetService.Persona

            registro.IdVacacionesDet = IdVacacionesDet
            Vacaciones.IdVacaciones = IdVacaciones
            registro.Vacaciones = Vacaciones
            registro.FecInicio = txtFecInicio.Value
            registro.FecFinal = txtFecFinal.Value
            registro.Observacion = txtObservacion.Text
            registro.Comprado = ckComprar.Checked
            personaAutoriza.IdPer = cmbPerAutoriza.Value
            registro.PersonaAutoriza = personaAutoriza
            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            If state_button Then        'Modificar
                Modificar(registro)
            Else                              'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtFecInicio.KeyPress _
                           , txtFecFinal.KeyPress                           
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class