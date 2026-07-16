Public Class frmMaximoMinimo


    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient

    Public IdLocacion As Integer
    Public IdMinMax As Integer
    Private dtDatos As DataTable

    Private Sub frmMaximoMinimo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMaximoMinimo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        listaDatos()
        dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[True]

    End Sub

    Private Sub listaDatos()
        Try

            dtDatos = oLocacionMercaderiaService.MostrarHistoryMinMaxDet(IdMinMax).Tables(0)
            dgvDatos.DataSource = dtDatos
            dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biBuscar.Click, miBuscar.Click
        Try
            Dim frm As New frmBuscarDetalle
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'MessageBox.Show(" " & frm.codigoDetalle)
                Dim rows() As Janus.Windows.GridEX.GridEXRow
                rows = dgvDatos.GetRows

                For Each row In rows

                    If CStr(row.Cells("CodMer").Value) = frm.codigoDetalle Then

                        dgvDatos.Row = row.Position
                        dgvDatos.Col = 1

                        Exit For
                    End If

                Next
                'RowPossesion(dgvDatos, dtDatos, "CodMer", frm.codigoDetalle)
            End If
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

 
End Class