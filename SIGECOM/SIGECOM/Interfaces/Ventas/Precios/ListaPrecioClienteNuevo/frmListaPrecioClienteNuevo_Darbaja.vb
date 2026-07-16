Imports System.ServiceModel
Public Class frmListaPrecioClienteNuevo_Darbaja

    '===========================Servicios====================================
    Private oListaClienteCabService As New ListaClienteCabService.ListaClienteCabServiceClient

    '======================Declaración de Variables==============================   
    Public IdLista As Integer
    Public IdCliente As Integer

    Private Sub frmListaPrecioClienteNuevo_Darbaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Dar de baja la Lista cliente N°:" & IdLista
        Me.Size = New System.Drawing.Size(561, 224)
    End Sub

    Private Sub frmListaPrecioClienteNuevo_Darbaja_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioClienteNuevo_Darbaja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaClienteCabService.Close()
        Catch ex As TimeoutException
            oListaClienteCabService.Abort()
        Catch ex As CommunicationException
            oListaClienteCabService.Abort()
        End Try
    End Sub

    Private Sub btnDarBaja_Click(sender As Object, e As EventArgs) Handles btnDarBaja.Click
        Try
            If MsgBox("¿Está seguro de DAR DE BAJA la Lista de Precio N° " & IdLista, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oListaClienteCabService.VencimientoLista(IdLista, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se dio de baja la lista de precio correctamente.")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso,comuniquese con el departamento de TI")
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DAR DE BAJA LISTA CLIENTE : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            btnDarBaja.Select()
            btnDarBaja_Click(sender, e)
        End If
    End Sub

End Class