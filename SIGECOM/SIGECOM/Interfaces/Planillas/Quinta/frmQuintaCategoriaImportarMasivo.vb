Imports System.ServiceModel
Public Class frmQuintaCategoriaImportarMasivo
    '===========================Servicios====================================================
    Private oQuintaCategoriaDetService As New QuintaCategoriaDetService.QuintaCategoriaDetServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private Persona As New PersonaService.Persona
    ' Private oMaestroService As New MaestroService.MaestroClient
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    '======================Declaración de Variables==============================================

    'Public type_process As String                'update     insert      delete

    Private dtTipoPlanilla As DataTable
    Private dtMonedas As DataTable



    Private Sub frmCronograMina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        txtAnio.Value = Today.Year
        ' cmbMoneda.Value = "NS"
        txtMesRegistro.Text = Format(Month(Today), "00")

        'Nuevo
        Me.Text = "Importar Planilla Ingresos/Retención Masivo"
        activar()

        EnableOptions()
    End Sub



    Private Sub frmCronograMinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub Finalizar()
        Try
            oQuintaCategoriaDetService.Close()
            oPersonaService.Close()
            ' oMaestroService.Close()
            oPlanillaSueldosService.Close()

        Catch ex As TimeoutException
            oQuintaCategoriaDetService.Abort()
            oPersonaService.Abort()
            '  oMaestroService.Abort()
            oPlanillaSueldosService.Abort()

        Catch ex As CommunicationException
            oQuintaCategoriaDetService.Abort()
            oPersonaService.Abort()
            ' oMaestroService.Abort()
            oPlanillaSueldosService.Abort()

        End Try
    End Sub

    Private Sub frmCronograMina_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub llenarCombos()
        Try

            ''=======================================MONEDAS ===============================================
            'dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            'cmbMoneda.DataSource = dtMonedas
            'cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            'cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            'cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            'cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            'cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            'dtMonedas = Nothing

            '==================================== TIPO PLANILLA ========================================
            dtTipoPlanilla = oPlanillaSueldosService.MostrarTipoPlanilla().Tables(0)
            cmbTipoPlanilla.DataSource = dtTipoPlanilla
            cmbTipoPlanilla.DropDownList.DataMember = dtTipoPlanilla.Columns("DesTipo").ToString
            cmbTipoPlanilla.DropDownList.DisplayMember = dtTipoPlanilla.Columns("DesTipo").ToString
            cmbTipoPlanilla.DropDownList.ValueMember = dtTipoPlanilla.Columns("IdTipo").ToString
            cmbTipoPlanilla.DropDownList.Columns(0).DataMember = dtTipoPlanilla.Columns("IdTipo").ToString
            cmbTipoPlanilla.DropDownList.Columns(1).DataMember = dtTipoPlanilla.Columns("DesTipo").ToString
            cmbTipoPlanilla.SelectedIndex = 0
            dtTipoPlanilla = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()

    End Sub

    Private Sub activar()

        btnGuardar.Enabled = True

    End Sub

    Private Sub desactivar()

        btnGuardar.Enabled = True

    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtMesRegistro.Text) = "" Then
                MsgBox("Debe Ingresar el Mes.", MsgBoxStyle.Information, "Información")
                txtMesRegistro.Focus()
                Return False
            ElseIf toBlank(txtAnio.Value) = "" Then
                MsgBox("Debe Ingresar el periodo.", MsgBoxStyle.Information, "Información")
                txtAnio.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function



    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim estado_process As Boolean
                    If rbIngresos.Checked Then
                        estado_process = oQuintaCategoriaDetService.ImportarIngresosPlanillaMasivo(Session.sCodEmp, txtAnio.Value, txtMesRegistro.Text, cmbTipoPlanilla.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    ElseIf rbRetencion.Checked
                        estado_process = oQuintaCategoriaDetService.ImportarRetenidoPlanillaMasivo(Session.sCodEmp, txtAnio.Value, txtMesRegistro.Text, cmbTipoPlanilla.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    End If

                    If estado_process Then
                        MsgBox("Se Importo la planilla Correctamente")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("¡Error en el proceso, comuníquese con TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL IMPORTAR PLANILLA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnGuardar.Focus()
        End If
    End Sub
End Class