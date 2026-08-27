Imports System.ServiceModel
Public Class frmPlanillaSueldos_HrsExt

    '===========================Servicios====================================================
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================================    
    Public IdHoraExtra As Integer
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdPersona As Integer
    Public IdPlanilla As Integer
    Private dtHorasExtras As DataTable
    Public iEstado As Integer

    Private Sub frmPlanillasSueldos_HrsExt_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaSueldosDetService.Close()
            oPlanillaSueldosService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oPlanillaSueldosDetService.Abort()
            oPlanillaSueldosService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oPlanillaSueldosDetService.Abort()
            oPlanillaSueldosService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub frmPlanillasSueldos_HrsExt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        '==============Datos de Planilla=================        
        iEstado = oPlanillaSueldosService.ObtenerIdEstado(IdPlanilla)
        '============================================

        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            txtHoras.Focus()
            desactivar()
        Else                                      'Nuevo
            activar()
        End If
        EnableOptions()
    End Sub

    Private Sub frmPlanillasSueldos_HrsExt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            ''========================================== DESCUENTO ===============================================
            dtHorasExtras = oPlanillaSueldosDetService.MostrarTipoHoraExtra(Session.sCodEmp).Tables(0)
            cmbHoraExtra.DataSource = dtHorasExtras
            cmbHoraExtra.DropDownList.DataMember = dtHorasExtras.Columns("DesHoraExtra").ToString
            cmbHoraExtra.DropDownList.DisplayMember = dtHorasExtras.Columns("DesHoraExtra").ToString
            cmbHoraExtra.DropDownList.ValueMember = dtHorasExtras.Columns("IdHoraExtra").ToString
            cmbHoraExtra.DropDownList.Columns(0).DataMember = dtHorasExtras.Columns("IdHoraExtra").ToString
            cmbHoraExtra.DropDownList.Columns(1).DataMember = dtHorasExtras.Columns("DesHoraExtra").ToString
            cmbHoraExtra.SelectedIndex = 0
            dtHorasExtras = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As PlanillaSueldosDetService.PlanillaSueldosDetHoraExtra
            registro = oPlanillaSueldosDetService.ObtenerHoraExtra(IdPlanilla, IdPersona, IdHoraExtra)

            cmbHoraExtra.Value = registro.TipoHoraExtra.IdHoraExtra
            txtHoras.Value = registro.Horas

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        'If estado = 1 Or estado = 2 Or estado = 3 Then
        '    btnGuardar.Enabled = True
        'Else
        '    btnGuardar.Enabled = False
        '    desactivar()
        'End If
    End Sub

    Private Sub desactivar()
        cmbHoraExtra.ReadOnly = True
        cmbHoraExtra.BackColor = System.Drawing.SystemColors.Control
        txtHoras.ReadOnly = False
        txtHoras.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Sub activar()
        cmbHoraExtra.ReadOnly = False
        cmbHoraExtra.BackColor = System.Drawing.SystemColors.Window
        txtHoras.ReadOnly = False
        txtHoras.BackColor = System.Drawing.SystemColors.Window
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbHoraExtra.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de Hora Extra.", MsgBoxStyle.Information, "Información")
                cmbHoraExtra.Focus()
                Return False
            ElseIf toDouble(txtHoras.Value) = 0 Then
                MsgBox("Debe Ingresar la Cantidad de Horas Extras.", MsgBoxStyle.Information, "Información")
                txtHoras.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
       And ValidaCampos() Then
            Dim registro As New PlanillaSueldosDetService.PlanillaSueldosDetHoraExtra
            Dim PlanillaSueldo As New PlanillaSueldosDetService.PlanillaSueldos
            Dim Persona As New PlanillaSueldosDetService.Persona
            Dim PlanillaSueldoDet As New PlanillaSueldosDetService.PlanillaSueldosDet
            Dim TipoHoraExtra As New PlanillaSueldosDetService.TipoHoraExtra

            Persona.IdPer = IdPersona
            PlanillaSueldo.IdPlanilla = IdPlanilla
            PlanillaSueldoDet.PlanillaSueldos = PlanillaSueldo
            PlanillaSueldoDet.Persona = Persona
            registro.PlanillaSueldosDet = PlanillaSueldoDet

            TipoHoraExtra.IdHoraExtra = cmbHoraExtra.Value
            registro.TipoHoraExtra = TipoHoraExtra

            registro.Horas = txtHoras.Value

            registro.CodUsu = Session.sCodUsu
            registro.DirIp = Session.sDirIp
            registro.NomPc = Session.sNomPc
            registro.FecReg = Today

            If state_button Then        'Modificar
                Modificar(registro)
            Else                              'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Insertar(ByVal registro As PlanillaSueldosDetService.PlanillaSueldosDetHoraExtra)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.InsertarHoraExtra(registro)
            type_process = "insert"
            If estado_process = True Then
                IdHoraExtra = toNumber(cmbHoraExtra.Value)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR HRS EXTRAS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaSueldosDetService.PlanillaSueldosDetHoraExtra)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.ActualizarHoraExtra(registro)
            type_process = "update"
            If estado_process = True Then
                IdHoraExtra = toNumber(cmbHoraExtra.Value)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR HRS EXTRAS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class