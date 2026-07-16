Imports System.ServiceModel

Public Class frmDescuentosPersonal_Cuotas

    '=========================== Servicios ====================================
    Private oDescuentoPersonalService As New DescuentoPersonalService.DescuentoPersonalServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================
    Public IdPersona As Integer
    Private dtMonedas As DataTable
    Private dtRubroDscto As New DataTable

    Private Sub frmDescuentosPersonal_Cuotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnCancelar
        llenarCombos()
        cmbMoneda.Value = "NS"
    End Sub

    Private Sub frmDescuentosPersonal_Cuotas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmDescuentosPersonal_Cuotas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oDescuentoPersonalService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oDescuentoPersonalService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oDescuentoPersonalService.Abort()
            oMaestroService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            ''========================================== DESCUENTO ===============================================
            dtRubroDscto = oDescuentoPersonalService.MostrarRubros(Session.sCodEmp).Tables(0)
            cmbDescuento.DataSource = dtRubroDscto
            cmbDescuento.DropDownList.DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.DisplayMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.DropDownList.ValueMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(0).DataMember = dtRubroDscto.Columns("IdRubroDes").ToString
            cmbDescuento.DropDownList.Columns(1).DataMember = dtRubroDscto.Columns("DesDescuento").ToString
            cmbDescuento.SelectedIndex = 0
            dtRubroDscto = Nothing

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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            Dim estado_process As Boolean
            If txtColaborador.Text <> "" Then

                If txtMonto.Value > 0 Then

                    estado_process = oDescuentoPersonalService.InsertarCuotas(Session.sCodEmp, IdPersona, cmbDescuento.Value, txtFecha.Value, cmbMoneda.Value, txtMonto.Value, txtCuotas.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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