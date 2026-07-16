Imports System.ServiceModel
Public Class frmAsientos_GenerarArchivo

    '===========================Servicios====================================================
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient

    '======================Declaración de Variables==============================================    
    Public IdTesoreria As Integer
    Public CodBan As String
    Public DesBanco As String
    Public CuentaBanco As String
    Public dtDatos As DataTable

    Private Sub frmAsientos_GenerarArchivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
           oTesoreriaService.Close()
        Catch ex As TimeoutException
           oTesoreriaService.Abort()
        Catch ex As CommunicationException
            oTesoreriaService.Abort()
        End Try
    End Sub

    Private Sub frmAsientos_GenerarArchivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CancelButton = Me.btnCancelar
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        txtDesBanco.Text = DesBanco
        txtNumCuenta.Text = CuentaBanco
        ListaDatos()
    End Sub

    Private Sub ListaDatos()
        dtDatos = oTesoreriaService.GenerarArchivoProveedores(IdTesoreria, cbFecha.Value, CodBan, CuentaBanco, 2).Tables(0)
        dgvDatos.DataSource = dtDatos        
        CalcularTotal()
    End Sub

    Private Sub frmAsientos_GenerarArchivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(cbFecha.Value) = "" Then
                MsgBox("Debe Ingresar la Fecha", MsgBoxStyle.Information, "Información")
                cbFecha.Focus()
            ElseIf toBlank(txtDesBanco.Text) = "" Then
                MsgBox("Debe Ingresar el banco", MsgBoxStyle.Information, "Información")
                txtDesBanco.Focus()
                Return False
            ElseIf toBlank(txtNumCuenta.Text) = "" Then
                MsgBox("Debe Ingresar la cuenta", MsgBoxStyle.Information, "Información")
                txtNumCuenta.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub CalcularTotal()
        Try
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim Monto As Double = 0.0

            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()

                Monto = Monto + toDouble(row.Cells("Monto").Value)
            Next
            txtTotalMonto.Value = Monto
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If ValidaCampos() Then
                Dim Seleccion As New SaveFileDialog
                Seleccion.Title = "Guardar archivo para el pago de proveedores masivo en el banco"
                Seleccion.Filter = "Archivos de texto |*.txt"
                If Seleccion.ShowDialog() = DialogResult.OK Then
                    Dim Ruta As String = Seleccion.FileName

                    Dim dtdetalle As New DataTable
                    dtdetalle = oTesoreriaService.GenerarArchivoProveedores(IdTesoreria, cbFecha.Value, CodBan, txtNumCuenta.Text, 1).Tables(0)

                    Dim fichero As String = Ruta
                    Dim texto As String = dtdetalle.Rows(0).Item("Cabecera")
                    Dim a As New System.IO.StreamWriter(fichero)
                    a.WriteLine(texto)
                    For Each Fila As DataRow In dtdetalle.Rows
                        texto = Fila.Item("Detalle")
                        a.WriteLine(texto)
                    Next
                    a.Close()

                    MsgBox("Se descargo exitosamente")
                    Finalizar()
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class