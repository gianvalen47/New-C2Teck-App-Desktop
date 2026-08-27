Imports System.ServiceModel

Public Class frmListaPrecioCliente_Darbaja

    '===========================Servicios====================================
    Private oListaPrecioClienteService As New ListaPrecioClienteService.ListaPrecioClienteServiceClient

    '======================Declaración de Variables==============================   
    Public IdLista As Integer
    Public IdCliente As Integer

    Private Sub frmListaPrecioCliente_Darbaja_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioClienteService.Close()
        Catch ex As TimeoutException
            oListaPrecioClienteService.Abort()
        Catch ex As CommunicationException
            oListaPrecioClienteService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioCliente_Darbaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioCliente_Darbaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Dar de baja la Lista de precio N°:" & IdLista

    End Sub

    Private Sub btnDarBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDarBaja.Click

        If MsgBox("¿Está seguro de DAR DE BAJA la Lista de Precio N° " & IdLista, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            Dim estado_process As Boolean
            estado_process = oListaPrecioClienteService.VencimientoLista(Session.sCodEmp, IdLista, IdCliente, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process Then
                MsgBox("Se dio de baja la lista de precio correctamente.")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
            End If
        End If

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class