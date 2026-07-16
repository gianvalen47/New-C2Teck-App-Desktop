Imports System.ServiceModel

Public Class frmBuscarUsuario

    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtArea As New DataTable
    Private dtUsuarios As New DataTable
    Public CodUsuario As String
    Public CodPerfil As String

    Private Sub frmBuscarUsuario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmBuscarUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                      txtUsuario.KeyPress _
                    , txtApeNom.KeyPress _
                    , cbArea.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            If dgvDatos.RowCount > 0 Then
                dgvDatos.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmBuscarUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()
        listaDatos()
        txtApeNom.Select()

    End Sub

    Private Sub llenarCombos()
        Try
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            Dim row As DataRow = dtArea.NewRow
            row(0) = ""
            row(2) = "(Todos)"
            dtArea.Rows.InsertAt(row, 0)

            cbArea.DataSource = dtArea
            cbArea.DataMember = "DesArea"
            cbArea.DisplayMember = "DesArea"
            cbArea.ValueMember = "CodArea"
            cbArea.DropDownList.Columns(0).DataMember = "CodArea"
            cbArea.DropDownList.Columns(1).DataMember = "DesArea"
            cbArea.SelectedIndex = 0
            dtArea = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
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
            ElseIf dgvDatos.CurrentRow.Cells("CodUsu").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub listaDatos()
        Try
            dtUsuarios = oSeguridadService.FiltrarUsuarios(txtUsuario.Text, txtApeNom.Text, cbArea.Value, cbVigente.Checked).Tables(0)
            Me.dgvDatos.SetDataBinding(dtUsuarios, 0)
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Datos")
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtUsuario.TextChanged, txtApeNom.TextChanged, cbVigente.CheckedChanged
        listaDatos()
    End Sub

    Private Sub dgDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub Seleccionar()
        Try
            CodUsuario = dgvDatos.CurrentRow.Cells("CodUsu").Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ValidaCodigoSeleccionado() Then
                Seleccionar()
            End If
        End If
    End Sub
End Class