Imports System.ServiceModel
Public Class frmHoraExtra_Multiple

    '=========================== Servicios ===================================================
    Private oHoraExtraService As New HoraExtraService.HoraExtraServiceClient
    Private oHoraExtraDetService As New HoraExtraDetService.HoraExtraDetServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oParametroPlanilla As New ParametrosPlanillaService.ParametrosPlanillaServiceClient

    '======================Declaración de Variables==============================================
    Public IdExtra As Integer = 0
    Public IdExtraDet As Integer = 0
    Public IdPersona As Integer = 0
    Private dtUbicacion As DataTable
    Private dtPerAutoriza As DataTable

    Private Sub frmHoraExtra_Multiple_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LlenarCombos()
    End Sub

    Private Sub frmHoraExtra_Multiple_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmHoraExtra_Multiple_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oHoraExtraService.Close()
            oHoraExtraDetService.Close()
            oJobService.Close()
            oPersonaService.Close()
            oAsignacionJefesService.Close()
            oParametroPlanilla.Close()
        Catch ex As TimeoutException
            oHoraExtraService.Abort()
            oHoraExtraDetService.Abort()
            oJobService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
            oParametroPlanilla.Abort()
        Catch ex As CommunicationException
            oHoraExtraService.Abort()
            oHoraExtraDetService.Abort()
            oJobService.Abort()
            oPersonaService.Abort()
            oAsignacionJefesService.Abort()
            oParametroPlanilla.Abort()
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
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try

            '============================================== UBICACIÓN ========================================
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
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If IdPersona = 0 Then
                MsgBox("Debe Ingresar el Colaborador.", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
                Return False
            ElseIf toBlank(txtFecha.Value) = "" Then
                MsgBox("Debe ingresar la fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
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

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub LimpiarDatos()
        'IdPersona = 0
        'txtColaborador.Text = ""
        'txtFecha.Value = Today
        txtNumJob.Text = ""
        cmbUbicacion.SelectedIndex = 0
        txtObservacion.Text = ""
        txtHorasViaje.Value = 0
        txtHoras25.Value = 0
        txtHoras35.Value = 0
        txtHoras100.Value = 0
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            txtColaborador.KeyPress _
                          , txtFecha.KeyPress _
                          , txtNumJob.KeyPress _
                          , cmbUbicacion.KeyPress _
                          , cmbPerAutoriza.KeyPress _
                          , txtObservacion.KeyPress _
                          , txtHorasViaje.KeyPress _
                          , txtHoras25.KeyPress _
                          , txtHoras35.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtHoras100_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoras100.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub

    Private Sub btnBuscarColaborador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                    txtFecha.Focus()
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
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
                Else
                    cmbUbicacion.Focus()
                End If
            Else
                cmbUbicacion.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumJob_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then

                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de Job no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    cmbUbicacion.Focus()
                End If
            Else
                cmbUbicacion.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL JOB: " + ex.Message)
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New HoraExtraService.HoraExtra
                    Dim Persona As New HoraExtraService.Persona
                    Dim Job As New HoraExtraService.Job
                    Dim PersonaAutoriza As New HoraExtraService.Persona
                    Dim UbicacionEquipo As New HoraExtraService.UbicacionEquipo
                    Dim AsignacionHE As New HoraExtraService.AsignacionHoraExtra
                    Dim regParametro As New ParametrosPlanillaService.ParametrosPlanilla
                    regParametro = oParametroPlanilla.Obtener(Session.sCodEmp)

                    registro.IdExtra = IdExtra
                    Persona.IdPer = IdPersona
                    registro.Persona = Persona
                    registro.Fecha = txtFecha.Value
                    Job.CodJob = IIf(txtNumJob.Text = "", Nothing, txtNumJob.Text)
                    registro.Job = Job
                    UbicacionEquipo.CodUbicacion = IIf(cmbUbicacion.SelectedIndex = 0, Nothing, cmbUbicacion.Value)
                    registro.UbicacionEquipo = UbicacionEquipo
                    PersonaAutoriza.IdPer = cmbPerAutoriza.Value
                    registro.PersonaAutoriza = PersonaAutoriza
                    registro.Observacion = txtObservacion.Text

                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp

                    Dim estado_process As Integer
                    estado_process = oHoraExtraService.Insertar(registro)
                    If estado_process > 0 Then
                        IdExtra = estado_process

                        If toDouble(txtHorasViaje.Value) > 0 Then
                            InsertarDetalle(IdExtra, regParametro.IdHoraExtraNormal, txtHorasViaje.Value)
                        End If

                        If toDouble(txtHoras25.Value) > 0 Then
                            InsertarDetalle(IdExtra, regParametro.IdHoraExtra25, txtHoras25.Value)
                        End If

                        If toDouble(txtHoras35.Value) > 0 Then
                            InsertarDetalle(IdExtra, regParametro.IdHoraExtra35, txtHoras35.Value)
                        End If

                        If toDouble(txtHoras100.Value) > 0 Then
                            InsertarDetalle(IdExtra, regParametro.IdHoraExtra100, txtHoras100.Value)
                        End If

                        MsgBox("Se insertó la(s) Hora(s) Extra Correctamente.")
                        LimpiarDatos()

                    Else
                        MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR HORA EXTRA: " + ex.Message)
        End Try
    End Sub

    Public Sub InsertarDetalle(ByVal IdExtra As Integer, ByVal IdTipoHoraExtra As Integer, ByVal Cantidad As Double)
        Try
            Dim registro As New HoraExtraDetService.HoraExtraDet
            Dim HoraExtra As New HoraExtraDetService.HoraExtra
            Dim TipoHoraExtra As New HoraExtraDetService.TipoHoraExtra

            registro.IdExtraDet = IdExtraDet
            HoraExtra.IdExtra = IdExtra
            registro.HoraExtra = HoraExtra
            TipoHoraExtra.IdHoraExtra = IdTipoHoraExtra
            registro.TipoHoraExtra = TipoHoraExtra
            registro.CanHoras = Cantidad
            registro.Observacion = Nothing

            registro.CodUsu = Session.sCodUsu
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp

            Dim estado_process As Integer
            estado_process = oHoraExtraDetService.Insertar(registro)
            If estado_process > 0 Then
                IdExtraDet = estado_process              
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR HORA EXTRA DETALLE: " + ex.Message)
        End Try 
    End Sub
End Class