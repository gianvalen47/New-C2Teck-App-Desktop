Imports System.ServiceModel

Public Class frmDocVenta_ActualizarEstado

    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oGuiaDevolucionService As New GuiaDevolucionService.GuiaDevolucionServiceClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oNotaCreditoService As New NotaCreditoService.NotaCreditoServiceClient


    Public IdDocVenta As Int64
    Public TipoDoc As String
    Public NumDoc As Int64

    Private Sub frmDocVenta_ActualizarEstado_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oFacturaService.Close()
            oBoletaService.Close()
            oGuiaDevolucionService.Close()
            oGuiaRemisionService.Close()
            oNotaCreditoService.Close()
        Catch ex As TimeoutException
            oFacturaService.Abort()
            oBoletaService.Abort()
            oGuiaDevolucionService.Abort()
            oGuiaRemisionService.Abort()
            oNotaCreditoService.Abort()
        Catch ex As CommunicationException
            oFacturaService.Abort()
            oBoletaService.Abort()
            oGuiaDevolucionService.Abort()
            oGuiaRemisionService.Abort()
            oNotaCreditoService.Abort()
        End Try
    End Sub

    Private Sub frmDocVenta_ActualizarEstado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDocVenta_ActualizarEstado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblTipoDoc.Text = TipoDoc & " : " & NumDoc
        'lblNumDoc.Text = NumDoc

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtObservacion.Text = "" And TipoDoc <> "Nota" Then
            MsgBox("Debe ingresar una observación, tenga cuidado", MsgBoxStyle.Information)
        Else
            If MsgBox("¿Está seguro de actualizar al estado inicial?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                BajarNivel()
            End If
        End If
    End Sub

    Private Sub BajarNivel()

        If TipoDoc = "Factura" Then

            If oFacturaService.ActualizarEstadoInicial(IdDocVenta, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                MsgBox("Se actualizo al estado inicial", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comunicarse con el área de sistemas")
            End If

        ElseIf TipoDoc = "Boleta" Then

            If oBoletaService.ActualizarEstadoInicial(IdDocVenta, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                MsgBox("Se actualizo al estado inicial", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comunicarse con el área de sistemas")
            End If

        ElseIf TipoDoc = "Guia de Remisión" Then

            If oGuiaRemisionService.ActualizarEstadoInicial(IdDocVenta, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                MsgBox("Se actualizo al estado inicial", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comunicarse con el área de sistemas")
            End If

        ElseIf TipoDoc = "Nota" Then

            If oNotaCreditoService.ActualizarEstadoInicial(IdDocVenta, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                MsgBox("Se actualizo al estado inicial", MsgBoxStyle.Information)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comunicarse con el área de sistemas")
            End If

        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class