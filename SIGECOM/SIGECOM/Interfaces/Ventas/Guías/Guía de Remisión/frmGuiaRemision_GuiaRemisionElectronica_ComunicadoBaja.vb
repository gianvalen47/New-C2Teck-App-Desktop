Imports System.ServiceModel
Imports LibreriaFacturacion
Imports System.Xml
Imports System.Text
Imports System.IO
Imports System
Imports UblLarsen.Ubl2
Imports System.Xml.Serialization
Imports UblLarsen.Ubl2.Cac
Imports UblLarsen.Ubl2.Udt
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports UblLarsen.Ubl2.aplicacion
Imports Ionic.Zip
Imports FacturarSunat.aplicacion

Public Class frmGuiaRemision_GuiaRemisionElectronica_ComunicadoBaja



    Private Sub frmGuiaRemision_GuiaRemisionElectronica_ComunicadoBaja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmGuiaRemision_GuiaRemisionElectronica_ComunicadoBaja_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmGuiaRemision_GuiaRemisionElectronica_ComunicadoBaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class