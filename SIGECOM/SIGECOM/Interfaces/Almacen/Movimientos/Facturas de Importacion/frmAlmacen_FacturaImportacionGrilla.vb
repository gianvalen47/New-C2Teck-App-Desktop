Public Class frmAlmacen_FacturaImportacionGrilla
    Public resultadoGrilla As Boolean
    Private oFacturaImportacionDet As New FacturaImportDetService.FacturaImportDetServiceClient
    Private dtimportacion As DataTable
    Public NumDocum As Integer
    Private actualiza As Boolean

    Dim idDetFactura As Integer
    Dim codmerAlm As String
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oFacturaImportacionDet) = False Then
                oFacturaImportacionDet.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAlmacen_FacturaImportacionGrilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dtimportacion = oFacturaImportacionDet.MostrarCodigoSinTarjeta(NumDocum).Tables(0)
            dgvDatos.DataSource = dtimportacion
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        
    End Sub
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click


        idDetFactura = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells(0).Value
        codmerAlm = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells(4).Value.ToString
        Try
            For i As Integer = 0 To dgvDatos.Rows.Count - 1
                actualiza = oFacturaImportacionDet.ActualizarCodigoAlmacen(NumDocum, idDetFactura, codmerAlm)
            Next
            If actualiza = True Then
                resultadoGrilla = actualiza
                MessageBox.Show("Los datos fueron ingresados correctamente!!!")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class