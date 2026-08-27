Imports System.ServiceModel
Public Class frmListaOfertaNuevo_DarBaja

    '===========================Servicios====================================
    Private oListaOfertaCabService As New ListaOfertaCabService.ListaOfertaCabServiceClient

    '======================Declaración de Variables==============================   
    Public IdOferta As Integer

    Private Sub frmListaOfertaNuevo_DarBaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Dar de baja la Lista de oferta N°:" & IdOferta
        Me.Size = New System.Drawing.Size(555, 224)
    End Sub

    Private Sub frmListaOfertaNuevo_DarBaja_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaOfertaNuevo_DarBaja_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaOfertaCabService.Close()
        Catch ex As TimeoutException
            oListaOfertaCabService.Abort()
        Catch ex As CommunicationException
            oListaOfertaCabService.Abort()
        End Try
    End Sub

    Private Sub btnDarBaja_Click(sender As Object, e As EventArgs) Handles btnDarBaja.Click
        Try
            If MsgBox("¿Está seguro de DAR DE BAJA la Lista de Oferta N° " & IdOferta, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oListaOfertaCabService.VencimientoPrecio(IdOferta, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se dio de baja la lista de oferta correctamente.")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso,comuniquese con el departamento de TI.")
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DAR DE BAJA LISTA OFERTA : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Tab Or Keys.Enter) Then
            If btnDarBaja.Enabled = True Then
                btnDarBaja.Select()
                btnDarBaja_Click(sender, e)
            Else
                'dgvDatos.Select()
            End If
        End If
    End Sub

End Class