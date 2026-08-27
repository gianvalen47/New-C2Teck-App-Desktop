Imports System.ServiceModel
Public Class frmBuscarDiario

    '===========================Servicios====================================================
    Private oContabilidadService As New ContabilidadService.ContabilidadServiceClient

    '======================Declaración de Variables==============================   
    Public IdContabilidad As Integer
    Private state_Search As Boolean
    Private dtDatos As DataTable
    Private dtTipDocumento As DataTable

    Private Sub frmBuscarDiario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oContabilidadService.Close()
        Catch ex As TimeoutException
            oContabilidadService.Abort()
        Catch ex As CommunicationException
            oContabilidadService.Abort()
        End Try
    End Sub

    Private Sub frmBuscarDiario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmBuscarRegCompras_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        LlenarCombos()
        state_Search = True
        listaDatos()
        'txtPeriodo.Value = Today.Year
        txtPeriodo.Select()
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
                e.Handled = True
            End If
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

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
            fila(3) = 0
        End Try  
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try
            '===================================TIPO DE DOCUMENTO ===========================================
            dtTipDocumento = oContabilidadService.MostrarTipoLibros.Tables(0)
            dtTipDocumento.Rows.InsertAt(getRowTodos(dtTipDocumento), 0)
            cmbTipoDocumento.DataSource = dtTipDocumento
            cmbTipoDocumento.DropDownList.DataMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoDocumento.DropDownList.DisplayMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoDocumento.DropDownList.ValueMember = dtTipDocumento.Columns("IdLibro").ToString
            cmbTipoDocumento.DropDownList.Columns(0).DataMember = dtTipDocumento.Columns("IdLibro").ToString
            cmbTipoDocumento.DropDownList.Columns(1).DataMember = dtTipDocumento.Columns("AbrLibro").ToString
            cmbTipoDocumento.DropDownList.Columns(2).DataMember = dtTipDocumento.Columns("DesLibro").ToString
            cmbTipoDocumento.SelectedIndex = 0
            dtTipDocumento = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdContabilidad").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Seleccionar()
        Try
            IdContabilidad = dgvDatos.CurrentRow.Cells("IdContabilidad").Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox("ERROR [BUSC-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oContabilidadService.Filtrar(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, cmbTipoDocumento.Value, txtNumRegistro.Text, txtGlosa.Text).Tables(0) 
                dgvDatos.DataSource = dtDatos
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [BUSC-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionar.Enabled = False
        Else
            miSeleccionar.Enabled = True
        End If
    End Sub

    Private Sub miSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionar.Click
        If ValidaCodigoSeleccionado() Then
            Seleccionar()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdContabilidad").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "IdContabilidad", codigo)
        End If
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        IdContabilidad = 0
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtMesRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Click
        txtMesRegistro.SelectAll()
    End Sub

    Private Sub txtMesRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMesRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtMesRegistro.Text)) > 0 Then
                If toNumber(txtMesRegistro.Text) < 13 And toNumber(txtMesRegistro.Text) > 0 Then
                    Dim cant As Integer = Len(txtMesRegistro.Text)
                    If cant < 2 Then
                        txtMesRegistro.Text = "0" & txtMesRegistro.Text
                    End If
                    txtNumRegistro.Focus()
                Else
                    MsgBox("Rango de Mes [01 - 12]")
                    txtMesRegistro.Focus()
                End If
            End If
            txtNumRegistro.Focus()
        End If
    End Sub

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                           txtPeriodo.KeyPress _
                         , txtNumRegistro.KeyPress _
                         , cmbTipoDocumento.KeyPress _
                         , txtGlosa.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            'listaDatos()
            If dgvDatos.RowCount > 0 Then
                dgvDatos.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtPeriodo.TextChanged, txtMesRegistro.TextChanged, txtNumRegistro.TextChanged, _
                                                                                                                            cmbTipoDocumento.ValueChanged, txtGlosa.TextChanged
        listaDatos()
    End Sub
End Class