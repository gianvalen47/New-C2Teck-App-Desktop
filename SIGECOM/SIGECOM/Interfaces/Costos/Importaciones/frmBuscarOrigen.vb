Imports System.ServiceModel
Public Class frmBuscarOrigen
    Private ObjMaestro As New MaestroService.MaestroClient
    Private Pais As New MaestroService.Pais
    Private dtPais As New DataTable

    Private Sub frmBuscarOrigen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
          txtCodigo.KeyPress _
          , txtDescripcion.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            If dgPaises.RowCount > 0 Then
                dgPaises_DoubleClick(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmBuscarOrigen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub frmBuscarPais_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarPais_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDescripcion.Select()
        dgPaises.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgPaises.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

    End Sub


    Private Sub dgPaises_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPaises.DoubleClick
        Dim forma As New frmDatosImportacion
        forma = Me.Owner
        forma.txtOrigen.Text = Trim(dgPaises.CurrentRow.Cells(1).Value)
        forma.pCodPais = dgPaises.CurrentRow.Cells(0).Value
        Me.Close()

    End Sub

   
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, Me.Load, txtCodigo.TextChanged, txtDescripcion.TextChanged
        Try

            Pais.CodPais = txtCodigo.Text
            Pais.DesPais = txtDescripcion.Text
            dtPais = ObjMaestro.FiltrarPaises(Pais).Tables(0)
            Me.dgPaises.SetDataBinding(dtPais, 0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub

    
End Class