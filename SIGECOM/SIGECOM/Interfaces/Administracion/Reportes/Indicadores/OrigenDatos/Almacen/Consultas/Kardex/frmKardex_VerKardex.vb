Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmKardex_VerKardex

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oLocacionMercaderiaService As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private dtDatos As DataTable

    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdLocacion As Integer
    Public CodMer As String
    Private Ajuste As Integer = 0

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                               txtanio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmKardex_VerKardex_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        Me.CancelButton = Me.btnCancelar
        'txtanio.Value = Today.Year
        listaDatos()
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
        dgvDatos.RowFormatStyle.FontSize = 9.0!
        Me.Text = "Lista de Kardex de la Mercadería ( " + CodMer + " )"
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oLocacionMercaderiaService) = False Then
                oLocacionMercaderiaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function getTotalIngreso(ByVal columna As String) As Double

        'Dim total As Double = 0
        'For i As Integer = 0 To dtDatos.Rows.Count - 1
        '    Dim r As DataRow
        '    r = dtDatos.Rows.Item(i)
        '    total = total + iidCDbl(r.Item(columna))
        'Next
        'Return total
        'dtDatos = dtDato.ToTable
        Dim total As Double = 0

        For Each Fila As DataRow In dtDatos.Rows
            If Fila.Item("AbrDoc").ToString <> "AJC" Then
                Dim contador As Double
                contador = IIf(Fila.Item("Ingreso") Is DBNull.Value, 0, Fila.Item("Ingreso"))
                total = total + contador
            End If
        Next
        Return total
    End Function
    Private Function getTotalSalida(ByVal columna As String) As Double
        'Dim total As Double = 0
        'For i As Integer = 0 To dtDatos.Rows.Count - 1
        '    Dim r As DataRow
        '    r = dtDatos.Rows.Item(i)
        '    total = total + iidCDbl(r.Item(columna))
        'Next
        'Return total
        Dim total As Double = 0

        For Each Fila As DataRow In dtDatos.Rows
            If Fila.Item("AbrDoc").ToString <> "AJC" Then
                Dim contador As Double
                contador = IIf(Fila.Item("Salida") Is DBNull.Value, 0, Fila.Item("Salida"))
                total = total + contador
            End If
        Next
        Return total
    End Function
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdLocacion) = 0 Then
                MsgBox("Debe Ingresar el almacén de la mercadería.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toBlank(CodMer) = "" Then
                MsgBox("Debe Ingresar el código de la mercadería.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf toNumber(txtanio.Value) = 0 Then
                MsgBox("Debe ingresar el año.", MsgBoxStyle.Information, "Información")
                txtanio.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub listaDatos()
        Try

            dtDatos = oLocacionMercaderiaService.MostrarKardex(IdLocacion, CodMer, toNumber(txtanio.Value), Ajuste).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            txtTotalIngresos.Text = getTotalIngreso("Ingreso")
            txtTotalEgresos.Text = getTotalSalida("Salida")

        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, chkAbre.TextChanged
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdKardex").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "IdKardex", codigo)
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, chkAbre.TextChanged
        listaDatos()
    End Sub
    Private Sub txtanio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtanio.Click
        listaDatos()
    End Sub

    Private Sub chkAbre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAbre.CheckedChanged
        If chkAbre.Checked = True Then
            Ajuste = 1
            listaDatos()
        ElseIf chkAbre.Checked = False Then
            Ajuste = 0
            listaDatos()
        End If
    End Sub
End Class
