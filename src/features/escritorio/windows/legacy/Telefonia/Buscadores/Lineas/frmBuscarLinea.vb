Imports System.ServiceModel
Public Class frmBuscarLinea

    Private oLineasService As New LineasService.LineasServiceClient

    Private dtDatos As DataTable
    Private state_Search As Boolean

    Private dtRegion As DataTable
    Public IdPlan As Integer

    Public codigo As String
    Public descripcion As String

    Private Sub frmBuscarLinea_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oLineasService.Close()
        Catch ex As TimeoutException
            oLineasService.Abort()
        Catch ex As CommunicationException
            oLineasService.Abort()
        End Try
    End Sub

    Private Sub frmBuscarLinea_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarLinea_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        state_Search = False
        llenarCombos()
        state_Search = True
        listaDatos()
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= REGION ================================================
            dtRegion = oLineasService.MostrarRegiones().Tables(0)
            dtRegion.Rows.InsertAt(getRowTodos(dtRegion), 0)
            cmbRegion.DataSource = dtRegion
            cmbRegion.DropDownList.DataMember = dtRegion.Columns("DesRegion").ToString
            cmbRegion.DropDownList.DisplayMember = dtRegion.Columns("DesRegion").ToString
            cmbRegion.DropDownList.ValueMember = dtRegion.Columns("CodRegion").ToString
            cmbRegion.DropDownList.Columns(0).DataMember = dtRegion.Columns("CodRegion").ToString
            cmbRegion.DropDownList.Columns(1).DataMember = dtRegion.Columns("DesRegion").ToString
            cmbRegion.SelectedIndex = 0
            dtRegion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click, cmbRegion.ValueChanged, txtPlan.TextChanged, txtNumLinea.TextChanged
        listaDatos()
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then

                dtDatos = oLineasService.Filtrar(toBlank(cmbRegion.Value), IdPlan, toBlank(txtNumLinea.Text)).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Seleccionar()
        Try
            codigo = dgvDatos.CurrentRow.Cells("IdLinea").Text
            descripcion = dgvDatos.CurrentRow.Cells("NumLinea").Text


            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionar.Enabled = False
        Else
            miSeleccionar.Enabled = True
        End If
    End Sub

    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                 cmbRegion.KeyPress _
              , btnBuscar.KeyPress _
              , txtPlan.KeyPress _
              , txtNumLinea.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
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
            ElseIf dgvDatos.CurrentRow.Cells("IdLinea").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnBuscarPlan_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarPlan.Click
        Try
            Dim frm As New frmBuscarPlan
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkPlan.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtPlan.Text = frm.descripcion
                    IdPlan = frm.codigo
                Else
                    txtPlan.Text = "(Todos)"
                    IdPlan = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miSeleccionar_Click(sender As System.Object, e As System.EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub
End Class