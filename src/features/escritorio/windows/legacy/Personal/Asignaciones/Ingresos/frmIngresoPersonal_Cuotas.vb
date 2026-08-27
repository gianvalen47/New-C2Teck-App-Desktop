Imports System.ServiceModel

Public Class frmIngresoPersonal_Cuotas

    '=========================== Servicios ===================================================
    Private oIngresoPersonalService As New IngresoPersonalService.IngresoPersonalServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================
    Public IdPersona As Integer
    Private dtMonedas As DataTable
    Private dtRubroIng As New DataTable

    Private Sub frmIngresoPersonal_Cuotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        cmbMoneda.Value = "NS"
    End Sub

    Private Sub Finalizar()

        Try
            oIngresoPersonalService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oIngresoPersonalService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oIngresoPersonalService.Abort()
            oMaestroService.Abort()
        End Try

    End Sub

    Private Sub llenarCombos()
        Try

            ''====================================== INGRESOS ==============================================
            dtRubroIng = oIngresoPersonalService.MostrarRubros(Session.sCodEmp).Tables(0)
            cmbIngreso.DataSource = dtRubroIng
            cmbIngreso.DropDownList.DataMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.DropDownList.DisplayMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.DropDownList.ValueMember = dtRubroIng.Columns("IdRubroIng").ToString
            cmbIngreso.DropDownList.Columns(0).DataMember = dtRubroIng.Columns("IdRubroIng").ToString
            cmbIngreso.DropDownList.Columns(1).DataMember = dtRubroIng.Columns("DesIngreso").ToString
            cmbIngreso.SelectedIndex = 0
            dtRubroIng = Nothing

            '======================================= MONEDAS ==============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub frmIngresoPersonal_Cuotas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            Dim estado_process As Boolean

            If txtColaborador.Text <> "" Then

                If txtMonto.Value > 0 Then

                    estado_process = oIngresoPersonalService.InsertarCuotas(Session.sCodEmp, IdPersona, cmbIngreso.Value, txtFecha.Value, cmbMoneda.Value, txtMonto.Value, txtCuotas.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process Then
                        MsgBox("Se Insertaron las cuotas correctamente ")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    End If
                Else
                    MsgBox("Debe Ingresar el Monto ", MsgBoxStyle.Information, "Información")
                End If
            Else
                MsgBox("Debe Ingresar el Colaborador ", MsgBoxStyle.Information, "Información")
                txtColaborador.Focus()
            End If

        Catch ex As Exception
            MsgBox("Error al insertar las cuotas : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnBuscarColaborador_Click(sender As Object, e As EventArgs) Handles btnBuscarColaborador.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersona = frm.codigo
                    txtColaborador.Text = frm.descripcion
                Else
                    IdPersona = 0
                    txtColaborador.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub



End Class