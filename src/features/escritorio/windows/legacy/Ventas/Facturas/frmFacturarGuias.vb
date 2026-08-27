Imports System.Windows.Forms
Imports System.ServiceModel
Public Class frmFacturarGuias
    Private ObjFactura As New FacturaService.FacturaServiceClient
    Private dtGuias As New DataTable
    Public NumJob As String
    Public IdCliente As Integer
    Public guia As String

    Private Sub frmFacturarGuias_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjFactura.Close()
        Catch ex As TimeoutException
            ObjFactura.Abort()
        Catch ex As CommunicationException
            ObjFactura.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
  
    Private Sub frmFacturarGuias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListaDatos()
    End Sub

    Private Sub ListaDatos()
        Try
        dtGuias = ObjFactura.MostrarGuiasPorJob(NumJob, IdCliente).Tables(0)
        dgvDatos.SetDataBinding(dtGuias, 0)

        sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        EnableOpciones()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error de Data")
        End Try
    End Sub

    Private Sub EnableOpciones()
        If dgvDatos.RowCount < 1 Then
            btnAceptar.Enabled = False
        Else
            btnAceptar.Enabled = True
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ckFacturarGuias.Checked Then
            guia = ""
            For i As Integer = 0 To dtGuias.Rows.Count - 1
                If guia = "" Then
                    guia = guia + dtGuias.Rows(i).Item(2).ToString
                Else
                    guia = guia + "," + dtGuias.Rows(i).Item(2).ToString
                End If
            Next
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown

        If e.KeyCode = Keys.Delete Then
            ListaDatos()
        End If

    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

End Class
