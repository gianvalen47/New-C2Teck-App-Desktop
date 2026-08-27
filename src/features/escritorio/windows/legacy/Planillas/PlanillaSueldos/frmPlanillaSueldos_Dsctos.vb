Imports System.ServiceModel
Public Class frmPlanillaSueldos_dsctos

    '===========================Servicios====================================================
    Private oPlanillaSueldosDetService As New PlanillaSueldosDetService.PlanillaSueldosDetServiceClient
    Private oPlanillaSueldosService As New PlanillaSueldosService.PlanillaSueldosServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================================    
    Public IdRubroDes As Integer
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public IdPersona As Integer
    Public IdPlanilla As Integer
    Private dtRubroDscto As DataTable
    Private dtMonedas As DataTable
    Public CodMon As String
    Public TipoCambio As Double
    Public iEstado As Integer

    Private Sub frmPlanillaSueldos_dsctos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmPlanillaSueldos_dsctos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub frmPlanillaSueldos_dsctos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

            ''========================================== DESCUENTO ===============================================
            dtRubroDscto = oPlanillaSueldosDetService.MostrarRubroDescuento(Session.sCodEmp).Tables(0)
            cmbDescuento.DataSource = dtRubroDscto
            cmbDescuento.DropDownList.DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.DisplayMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.ValueMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(0).DataMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(1).DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.SelectedIndex = 0
            dtRubroDscto = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As PlanillaSueldosDetService.PlanillaSueldosDetDescuento
            registro = oPlanillaSueldosDetService.ObtenerDescuento(IdPlanilla, IdPersona, IdRubroDes)

            cmbDescuento.Value = registro.RubroDescuentoPlanilla.IdRubroDes
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
        cmbDescuento.ReadOnly = True
        cmbDescuento.BackColor = System.Drawing.SystemColors.Control
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
        cmbDescuento.ReadOnly = False
        cmbDescuento.BackColor = System.Drawing.SystemColors.Window
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
            If toBlank(cmbDescuento.Value) = "" Then
                MsgBox("Debe Ingresar el Rubro de Descuento.", MsgBoxStyle.Information, "Información")
                cmbDescuento.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
            ElseIf CodMon = "NS" And txtMontoSol.Value = 0 Then
                MsgBox("Debe Ingresar el Monto.", MsgBoxStyle.Information, "Información")
                txtMontoSol.Focus()
                Return False
            ElseIf CodMon = "US" And txtMontoDol.Value = 0 Then
                MsgBox("Debe Ingresar el Monto.", MsgBoxStyle.Information, "Información")
                txtMontoDol.Focus()
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
            Dim registro As New PlanillaSueldosDetService.PlanillaSueldosDetDescuento
            Dim PlanillaSueldo As New PlanillaSueldosDetService.PlanillaSueldos
            Dim Persona As New PlanillaSueldosDetService.Persona
            Dim PlanillaSueldoDet As New PlanillaSueldosDetService.PlanillaSueldosDet
            Dim RubroDescuentoPlanilla As New PlanillaSueldosDetService.RubroDescuentoPlanilla
            Dim Moneda As New PlanillaSueldosDetService.Moneda

            Persona.IdPer = IdPersona
            PlanillaSueldo.IdPlanilla = IdPlanilla
            PlanillaSueldoDet.PlanillaSueldos = PlanillaSueldo
            PlanillaSueldoDet.Persona = Persona
            registro.PlanillaSueldosDet = PlanillaSueldoDet

            RubroDescuentoPlanilla.IdRubroDes = cmbDescuento.Value
            registro.RubroDescuentoPlanilla = RubroDescuentoPlanilla

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

    Private Sub Insertar(ByVal registro As PlanillaSueldosDetService.PlanillaSueldosDetDescuento)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.InsertarDescuento(registro)
            type_process = "insert"
            If estado_process = True Then
                IdRubroDes = toNumber(cmbDescuento.Value)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DSCTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As PlanillaSueldosDetService.PlanillaSueldosDetDescuento)
        Try
            Dim estado_process As Boolean
            estado_process = oPlanillaSueldosDetService.ActualizarDescuento(registro)
            type_process = "update"
            If estado_process = True Then
                IdRubroDes = toNumber(cmbDescuento.Value)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DSCTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class