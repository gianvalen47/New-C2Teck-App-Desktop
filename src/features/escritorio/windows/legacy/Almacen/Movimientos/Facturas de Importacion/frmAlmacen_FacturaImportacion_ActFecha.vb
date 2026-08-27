Imports System.Windows.Forms
Public Class frmAlmacen_FacturaImportacion_ActFecha

    Private oImportacionService As New ImportacionService.ImportacionServiceClient
    Private oEmbarqueService As New EmbarqueService.EmbarqueServiceClient

    Public estado_process As String

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oImportacionService) = False Then
                oImportacionService.Close()
            End If
            If isClosed(oEmbarqueService) = False Then
                oEmbarqueService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAlmacen_FacturaImportacion_ActFecha_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtCodEmbarque.Focus()
        Me.Text = "Actualizar la fecha de las F/I es estado GENERADO"
        txtFecDoc.Value = Today        
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Estás seguro de actualizar la fecha de las F/I del Embarque:" & txtCodEmbarque.Text.ToString & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    estado_process = oImportacionService.ActualizarFecha(Session.sCodEmp, toBlank(txtCodEmbarque.Text), txtFecDoc.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("Se actualizó la Fecha de la(s) F/I del embarque ingresado")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR FECHA DE LA(S) F/I: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtCodEmbarque.Text) = "" Then
                MsgBox("Debe Ingresar el código de Embarque.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf oEmbarqueService.Buscar(Session.sCodEmp, toBlank(txtCodEmbarque.Text)) = False Then
                MsgBox("El código de Embarque ingresado es incorrecto.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar el la fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CAMPOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
End Class