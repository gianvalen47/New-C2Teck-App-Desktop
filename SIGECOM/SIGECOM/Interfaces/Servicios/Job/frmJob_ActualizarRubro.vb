Imports System.ServiceModel

Public Class frmJob_ActualizarRubro

    Public CodJob As String
    Public CodRubro As Integer
    Public IdGastoReal As Integer
    Public NumDoc As String
    Private dtRubros As DataTable

    Private oGastosReal As New GastoRealService.GastoRealServiceClient


    Private Sub frmJob_ActualizarRubro_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oGastosReal.Close()
        Catch ex As TimeoutException
            oGastosReal.Abort()
        Catch ex As CommunicationException
            oGastosReal.Abort()
        End Try
    End Sub

    Private Sub frmJob_ActualizarRubro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmJob_ActualizarRubro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblNumJob.Text = CodJob
        lblNumDoc.Text = NumDoc
        llenarCombo()
        cmbRubro.Value = CodRubro
        cmbRubro.Text = ""

        If NumDoc = "" Then
            lblNumDoc.Visible = False
            lblNumDocl.Visible = False
        End If

    End Sub

    Private Sub llenarCombo()
        Try
            '-------------------------------Rubros-----------------------------
            dtRubros = oGastosReal.MostrarRubros.Tables(0)
            cmbRubro.DataSource = dtRubros
            cmbRubro.DropDownList.DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.DisplayMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.DropDownList.ValueMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(0).DataMember = dtRubros.Columns("CodRubro").ToString
            cmbRubro.DropDownList.Columns(1).DataMember = dtRubros.Columns("DesRubro").ToString
            cmbRubro.SelectedIndex = 0
            dtRubros = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If cmbRubro.Text = "" Then
            MsgBox("Debe seleccionar un Rubro, tenga cuidado", MsgBoxStyle.Information)
        Else
            If oGastosReal.ActualizarRubro(IdGastoReal, CodJob, cmbRubro.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                MsgBox("Se Actualizo el Rubro", MsgBoxStyle.Information)
                'Limpiar()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comunicarse con el área de TI")
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class