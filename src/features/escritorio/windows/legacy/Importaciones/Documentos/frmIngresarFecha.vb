Public Class frmIngresarFecha
    Private oFacturaImportService As New FacturaImportService.FacturaImportServiceClient
    Public IdFactura As Integer
    Public NumDoc As String

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmIngresarFecha_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oFacturaImportService) = False Then
                oFacturaImportService.Close()
            End If
           
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmIngresarFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmIngresarFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
           
    End Sub


    Private Sub frmIngresarFecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtInvoice.Text = NumDoc
        ObtenerRegistro()
        txtFecDoc.Select()
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As FacturaImportService.FacturaImport
            registro = oFacturaImportService.MostrarPorId(toNumber(IdFactura))

            If Not (registro.FecPro.ToString = "") Then
                txtFecDoc.Value = CDate(registro.FecPro)
                txtFecDoc.Text = registro.FecPro.ToString
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        If txtFecDoc.Text = "" Then
            MsgBox("Debe Ingresar la Fecha Probable...")
            txtFecDoc.Select()
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub IngresarFecha()
        Try
            If ValidaCampos Then
                Dim estado_process As Integer
                estado_process = oFacturaImportService.ActualizarFechaProbable(IdFactura, IIf(txtFecDoc.Text = "", Nothing, txtFecDoc.Value))
                If estado_process Then
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
           
        Catch ex As Exception
            MsgBox("ERROR [AGRE-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        IngresarFecha()
    End Sub
End Class