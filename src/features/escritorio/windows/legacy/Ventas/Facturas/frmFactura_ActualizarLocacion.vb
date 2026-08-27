Imports System.ServiceModel

Public Class frmFactura_ActualizarLocacion

    Private oFacturaService As New FacturaService.FacturaServiceClient

    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient

    Public IdFactura As Integer
    Public NumDoc As Integer
    Public Cliente As String
    Public Oficina As String
    Public IdCliente As String
    Private dtLocaciones As DataTable
    Private Actualizar As Boolean

    Private Sub frmFactura_ActualizarLocacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oFacturaService.Close()
            oLocacionClienteService.Close()
        Catch ex As TimeoutException
            oFacturaService.Abort()
            oLocacionClienteService.Abort()
        Catch ex As CommunicationException
            oFacturaService.Abort()
            oLocacionClienteService.Abort()
        End Try

    End Sub

    Private Sub frmFactura_ActualizarLocacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFactura_ActualizarLocacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenarCombos()

        txtNumDoc.Text = NumDoc
        txtCliente.Text = Cliente
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Actualizar = oFacturaService.ActualizarLocacionCliente(IdFactura, cmbIdLocCli.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            If Actualizar = True Then
                MsgBox("Se Actualizó la Locación correctamente.!")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ================================================
            dtLocaciones = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
            'dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
            cmbIdLocCli.DataSource = dtLocaciones
            cmbIdLocCli.DropDownList.DataMember = dtLocaciones.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.DisplayMember = dtLocaciones.Columns("Nombre").ToString
            cmbIdLocCli.DropDownList.ValueMember = dtLocaciones.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdLocCli").ToString
            cmbIdLocCli.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Nombre").ToString
            'ConLocCli = dtLocaciones.Rows.Count
            'cmbIdLocCli.SelectedIndex = 0
            dtLocaciones = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class