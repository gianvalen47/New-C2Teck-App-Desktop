Imports System.ServiceModel

Public Class frmGuiaRemision_MotivoBaja

    '===========================Servicios====================================
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient

    '======================Declaración de Variables==============================   
    Public IdGuia As String
    Public NumDoc As String
    Public TipMov As String
    Public Oficina As String
    Public IdLocacion As String

    Private Sub frmGuiaRemision_MotivoBaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Anular la Guia de Remision N°:" & NumDoc
    End Sub

    Private Sub frmGuiaRemision_MotivoBaja_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGuiaRemision_MotivoBaja_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout
        Try
            oGuiaRemisionService.Close()
        Catch ex As TimeoutException
            oGuiaRemisionService.Abort()
        Catch ex As CommunicationException
            oGuiaRemisionService.Abort()
        End Try
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click

        Try
            If txtObservacion.Text = "" Then
                MsgBox("Debe ingresar la Observación")
                txtObservacion.Focus()
            Else
                If MsgBox("¿Está seguro de ANULAR la Guía Nº " + NumDoc + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    'estado_process = oGuiaRemisionService.Anular(dgvDatos.CurrentRow.Cells("IdGuia").Text, Session.sCodUsu)
                    'cambio realizado por perdido del Sr. Camacho al anular que vaya a consulta lo de almacen servicios
                    If TipMov <> "O" And Oficina = "01" And IdLocacion <> 10 Then
                        '    If dgvDatos.CurrentRow.Cells("TipMov").Text <> "O" And cmbOficinas.Value = "01" And cmbIdLocacion.Value <> 3 And cmbIdLocacion.Value <> 10 Then
                        estado_process = oGuiaRemisionService.AnulacionConsulta(IdGuia, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("La Guía fue enviada a CONSULTA para su anulación, Comuníquese con Almacén  ...!!!", MsgBoxStyle.Information)
                    Else
                        estado_process = oGuiaRemisionService.Anular(IdGuia, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("La Guía fue Anulada correctamente.", MsgBoxStyle.Information)
                    End If

                    If estado_process = True Then
                        MsgBox(" Se anulo la Guia Nº: " + NumDoc + " :", MsgBoxStyle.Information)
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al Anular Solicitud de Gastos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class