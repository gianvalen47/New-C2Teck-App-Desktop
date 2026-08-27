Imports System.ServiceModel

Public Class frmDocumento_GenerarSolGasto

    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient

    '======================Declaración de Variables==============================   
    Public IdFactura As Integer
    Public FecDoc As DateTime
    Public IdPersonaSolicita As Integer
    Public IdPersonaAutoriza As Integer
    'Private dtTipDoc As DataTable

    Private Sub frmDocumento_GenerarSolGasto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oFacturaImportService.Close()
        Catch ex As TimeoutException
            oFacturaImportService.Abort()
        Catch ex As CommunicationException
            oFacturaImportService.Abort()
        End Try
    End Sub

    Private Sub frmDocumento_GenerarSolGasto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDocumento_GenerarSolGasto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.Text = "Procesar Orden de Compra N°:" & IdOrden
        txtFecDoc.Value = FecDoc



    End Sub

    Private Sub btnBuscarPersonaS_Click(sender As Object, e As EventArgs) Handles btnBuscarPersonaS.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdPersonaSolicita = frm.codigo
                    txtPersonaSolicita.Text = frm.descripcion
                Else
                    IdPersonaSolicita = 0
                    txtPersonaSolicita.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarPersonaA_Click(sender As Object, e As EventArgs) Handles btnBuscarPersonaA.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    txtPersonaAutoriza.Text = frm.descripcion
                    IdPersonaAutoriza = frm.codigo
                Else
                    txtPersonaAutoriza.Text = ""
                    IdPersonaAutoriza = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try
            Dim estado_process As Integer
            If MsgBox("¿Estás seguro de Generar la Solcitud de Gastos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
                estado_process = oFacturaImportService.GenerarSolicitudGasto(IdFactura, txtFecDoc.Value, IdPersonaSolicita, IdPersonaAutoriza, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                MsgBox("Se Generó la Solicitud de Gastos Nº " + estado_process.ToString)
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la Orden de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdPersonaSolicita) = 0 Then
                MsgBox("Debe Ingresar la Persona Solicita", MsgBoxStyle.Information, "Información")
                txtPersonaSolicita.Focus()
                Return False
            ElseIf toNumber(IdPersonaAutoriza) = 0 Then
                MsgBox("Debe Ingresar la Persona Autoriza", MsgBoxStyle.Information, "Información")
                txtPersonaAutoriza.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

End Class