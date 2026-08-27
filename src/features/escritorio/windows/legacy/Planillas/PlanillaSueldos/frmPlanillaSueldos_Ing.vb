Imports System.ServiceModel
Public Class frmPlanillaSueldos_Ing

    '===========================Servicios====================================================
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient

    '======================Declaración de Variables==============================================    
    Public IdRubroIng As Integer
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdPersona As Integer
    Public IdPlanilla As Integer
    Public CodMon As String                    'Moneda de la Planilla
    Public TipoCambio As Double             'Tipo de Cambio de la Planilla
    Private dtRubroIng As DataTable
    Private dtMonedas As DataTable
    Private iEstado As Integer

    Private Sub frmPlanillaSueldos_Ing_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaSueldosDetService.Close()
            oMaestroService.Close()
            oPlanillaSueldosService.Close()
        Catch ex As TimeoutException
            oPlanillaSueldosDetService.Abort()
            oMaestroService.Abort()
            oPlanillaSueldosService.Abort()
        Catch ex As CommunicationException
            oPlanillaSueldosDetService.Abort()
            oMaestroService.Abort()
            oPlanillaSueldosService.Abort()
        End Try
    End Sub

    Private Sub frmPlanillaSueldos_Ing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar

        '==============Datos de Planilla=================
        Dim registro As New PlanillaSueldosService.PlanillaSueldos
        registro = oPlanillaSueldosService.Obtener(IdPlanilla)
        CodMon = registro.Moneda.CodMon
        TipoCambio = registro.TipCam
        iEstado = registro.EstadosPlanillaSueldos.IdEstado
        '============================================

        llenarCombos()

        If state_button Then                'Modificar
            ObtenerRegistro()
            If cmbMoneda.Value = "NS" Then
                txtMontoSol.Focus()
            ElseIf cmbMoneda.Value = "US" Then
                txtMontoSol.Focus()
            End If
            desactivar()
        Else                                      'Nuevo
            cmbMoneda.Value = CodMon
            activar()
        End If
        EnableOptions()
    End Sub

    Private Sub frmPlanillaSueldos_Ing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            ''=========================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            ''========================================== INGRESO ===============================================
            dtRubroIng = oPlanillaSueldosDetService.MostrarRubroIngreso(Session.sCodEmp).Tables(0)
            cmbIngreso.DataSource = dtRubroIng
            cmbIngreso.DropDownList.DataMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.DropDownList.DisplayMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.DropDownList.ValueMember = dtRubroIng.Columns("IdRubroIng").ToString
            cmbIngreso.DropDownList.Columns(0).DataMember = dtRubroIng.Columns("IdRubroIng").ToString
            cmbIngreso.DropDownList.Columns(1).DataMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.SelectedIndex = 0
            dtRubroIng = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As PlanillaSueldosDetService.PlanillaSueldosDetIngreso
            registro = oPlanillaSueldosDetService.ObtenerIngreso(IdPlanilla, IdPersona, IdRubroIng)

            cmbIngreso.Value = registro.RubroIngresoPlanilla.IdRubroIng
            cmbMoneda.Value = registro.Moneda.CodMon
            txtMontoSol.Value = registro.MontoSol
            txtMontoDol.Value = registro.MontoDol

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbMoneda_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMoneda.ValueChanged
        If cmbMoneda.Value = "NS" Then
            txtMontoSol.ReadOnly = False
            txtMontoSol.BackColor = System.Drawing.SystemColors.Window
            txtMontoDol.ReadOnly = True
            txtMontoDol.BackColor = System.Drawing.SystemColors.Control
        ElseIf cmbMoneda.Value = "US" Then
            txtMontoSol.ReadOnly = True
            txtMontoSol.BackColor = System.Drawing.SystemColors.Control
            txtMontoDol.ReadOnly = False
            txtMontoDol.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

    Private Sub EnableOptions()
        'If estado = 1 Or estado = 2 Or estado = 3 Then
        '    btnGuardar.Enabled = True
        'Else
        '    btnGuardar.Enabled = False
        '    desactivar()
        'End If
    End Sub

    Private Sub txtMontoSol_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMontoSol.ValueChanged, txtMontoDol.ValueChanged
        If cmbMoneda.Value = "NS" Then
            txtMontoDol.Value = Math.Round((txtMontoSol.Value / TipoCambio), 2)
        ElseIf cmbMoneda.Value = "US" Then
            txtMontoSol.Value = Math.Round((txtMontoDol.Value * TipoCambio), 2)
        End If
    End Sub

    Private Sub desactivar()
        cmbIngreso.ReadOnly = True
        cmbIngreso.BackColor = System.Drawing.SystemColors.Control
        If CodMon = "NS" Then
            txtMontoSol.ReadOnly = False
            txtMontoSol.BackColor = System.Drawing.SystemColors.Window

            txtMontoDol.ReadOnly = True
            txtMontoDol.BackColor = System.Drawing.SystemColors.Control

        ElseIf CodMon = "US" Then
            txtMontoDol.ReadOnly = False
            txtMontoDol.BackColor = System.Drawing.SystemColors.Window

            txtMontoSol.ReadOnly = True
            txtMontoSol.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub activar()
        cmbIngreso.ReadOnly = False
        cmbIngreso.BackColor = System.Drawing.SystemColors.Window
        If CodMon = "NS" Then
            txtMontoSol.ReadOnly = False
            txtMontoSol.BackColor = System.Drawing.SystemColors.Window

            txtMontoDol.ReadOnly = True
            txtMontoDol.BackColor = System.Drawing.SystemColors.Control

        ElseIf CodMon = "US" Then
            txtMontoDol.ReadOnly = False
            txtMontoDol.BackColor = System.Drawing.SystemColors.Window

            txtMontoSol.ReadOnly = True
            txtMontoSol.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try

            If toBlank(cmbIngreso.Value) = "" Then
                MsgBox("Debe Ingresar el Rubro de Ingreso.", MsgBoxStyle.Information, "Información")
                cmbIngreso.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
                'ElseIf CodMon = "NS" And txtMontoSol.Value = 0 Then
                '    MsgBox("Debe Ingresar el Monto.", MsgBoxStyle.Information, "Información")
                '    txtMontoSol.Focus()
                '    Return False
                'ElseIf CodMon = "US" And txtMontoDol.Value = 0 Then
                '    MsgBox("Debe Ingresar el Monto.", MsgBoxStyle.Information, "Información")
                '    txtMontoDol.Focus()
                '    Return False
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
            Dim registro As New PlanillaSueldosDetService.PlanillaSueldosDetIngreso
            Dim PlanillaSueldo As New PlanillaSueldosDetService.PlanillaSueldos
            Dim Persona As New PlanillaSueldosDetService.Persona
            Dim PlanillaSueldoDet As New PlanillaSueldosDetService.PlanillaSueldosDet
            Dim RubroIngresoPlanilla As New PlanillaSueldosDetService.RubroIngresoPlanilla
            Dim Moneda As New PlanillaSueldosDetService.Moneda

            Persona.IdPer = IdPersona
            PlanillaSueldo.IdPlanilla = IdPlanilla
            PlanillaSueldoDet.PlanillaSueldos = PlanillaSueldo
            PlanillaSueldoDet.Persona = Persona
            registro.PlanillaSueldosDet = PlanillaSueldoDet

            RubroIngresoPlanilla.IdRubroIng = cmbIngreso.Value
            registro.RubroIngresoPlanilla = RubroIngresoPlanilla

            Moneda.CodMon = cmbMoneda.Value
            registro.Moneda = Moneda

            registro.MontoSol = txtMontoSol.Value
            registro.MontoDol = txtMontoDol.Value
        
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

    Private Sub Insertar(ByVal registro As PlanillaSueldosDetService.PlanillaSueldosDetIngreso)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.InsertarIngreso(registro)
            type_process = "insert"
            If estado_process = True Then
                IdRubroIng = toNumber(cmbIngreso.Value)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR ING : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaSueldosDetService.PlanillaSueldosDetIngreso)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.ActualizarIngreso(registro)
            type_process = "update"
            If estado_process = True Then
                IdRubroIng = toNumber(cmbIngreso.Value)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR ING : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class