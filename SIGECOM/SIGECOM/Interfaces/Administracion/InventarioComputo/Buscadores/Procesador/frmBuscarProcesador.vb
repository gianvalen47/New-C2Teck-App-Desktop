Imports System.ServiceModel

Public Class frmBuscarProcesador

    Private oComputadoraService As New ComputadoraService.ComputadoraServiceClient

    Private dtDatos As DataTable
    Private state_Search As Boolean

    Private dtRegion As DataTable
    Public IdPlan As Integer

    Public codigo As String
    Public descripcion As String

    Private Sub frmBuscarProcesador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        state_Search = False
        'llenarCombos()
        state_Search = True
        listaDatos()
    End Sub

    Private Sub frmBuscarProcesador_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarProcesador_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oComputadoraService.Close()
        Catch ex As TimeoutException
            oComputadoraService.Abort()
        Catch ex As CommunicationException
            oComputadoraService.Abort()
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, txtDesProcesador.TextChanged, txtMarca.TextChanged, txtModelo.TextChanged, txtSerie.TextChanged, txtTipoProcesador.TextChanged
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then

                'dtDatos = oComputadoraService.FiltrarProcesador(toBlank(txtDesProcesador.Text), toBlank(txtMarca.Text), toBlank(txtModelo.Text), toBlank(txtSerie.Text), toBlank(txtTipoProcesador.Text)).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionar.Enabled = False
        Else
            miSeleccionar.Enabled = True
        End If
    End Sub

    Private Sub Seleccionar()
        Try
            codigo = dgvDatos.CurrentRow.Cells("IdProcesador").Text
            descripcion = dgvDatos.CurrentRow.Cells("DesProcesador").Text


            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                 txtDesProcesador.KeyPress _
              , txtMarca.KeyPress _
              , txtModelo.KeyPress _
              , txtSerie.KeyPress _
              , txtTipoProcesador.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDatos_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdProcesador").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub miSeleccionar_Click(sender As Object, e As EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub
End Class