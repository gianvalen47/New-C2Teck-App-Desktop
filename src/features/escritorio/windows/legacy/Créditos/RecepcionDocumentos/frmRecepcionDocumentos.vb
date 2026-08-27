Imports System.ServiceModel
Public Class frmRecepcionDocumentos

    Private oJobService As New JobService.JobServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private Sub frmRecepcionDocumentos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oJobService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oJobService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oJobService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmRecepcionDocumentos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRecepcionDocumentos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 273)
        '/*************************************************************************************/

        txtNumJob.Select()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            If toBlank(txtNumJob.Text) <> "" Then
                If MsgBox("¿Está seguro de recepcionar los documentos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    Dim estado As Integer
                    estado = oJobService.RecepcionDocumentacion(txtNumJob.Text, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado Then
                        MsgBox("Se recepcionaron los documentos correctamente", MsgBoxStyle.Information)
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        LimpiarDatos()
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            Else
                MsgBox("Debe ingresar un número de OT, tenga cuidado...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL RECEPCIONAR LOS DOCUMENTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub LimpiarDatos()
        txtNumJob.Text = ""
        txtObservacion.Text = ""
    End Sub

    Private Sub txtNumJob_Validated(sender As Object, e As System.EventArgs) Handles txtNumJob.Validated
        Try
            If Len(Trim(txtNumJob.Text)) > 0 Then
                If Not (oJobService.Buscar(txtNumJob.Text)) Then
                    MsgBox("Número de OT no existente, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) = 1 Then
                    MsgBox("Número de OT Anulado, Verifique")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                ElseIf oJobService.Estado(txtNumJob.Text) <> 16 And oJobService.Estado(txtNumJob.Text) <> 29 Then
                    MsgBox("El Número de OT no esta Liquidado o Liquidado Parcial ")
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                Else
                    txtObservacion.Focus()
                End If
            Else
                txtNumJob.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA OT : " + ex.Message)
        End Try
    End Sub

    Private Sub btnBuscarJob_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarJob.Click
        Try
            Dim frm As New frmBuscarJob
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.cod_job) <> Nothing Then
                    txtNumJob.Text = frm.cod_job
                    txtObservacion.Focus()
                Else
                    txtNumJob.Text = ""
                    txtNumJob.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class