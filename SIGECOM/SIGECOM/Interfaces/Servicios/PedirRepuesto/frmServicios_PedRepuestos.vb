Imports System.ServiceModel

Public Class frmServicios_PedRepuestos
    Private oMaestroService As New MaestroService.MaestroClient
    Private oTransferenciaService As New TransferenciaService.TransferenciaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private state_Search As Boolean
    Private IdCliente As Integer
    Private dtLocaciones As DataTable
    Private dtDatos As DataTable

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        fila(1) = "(Todos)"
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception

        End Try

        Return fila
    End Function
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
        Try
            tabla.DefaultView.Sort = nombreCampo
            lista.FirstRow = dtDatos.DefaultView.Find(codigo)
            lista.Row = dtDatos.DefaultView.Find(codigo)
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmServicios_PedRepuestos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oMaestroService.Close()
            oTransferenciaService.Close()
            oSeguridadService.close()
        Catch ex As TimeoutException
            oMaestroService.Close()
            oTransferenciaService.Abort()
            oSeguridadService.abort()
        Catch ex As CommunicationException
            oMaestroService.Close()
            oTransferenciaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub
    Private Sub frmServicios_PedRepuestos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            biMostrar_Click(sender, e)
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                dgvDatos_DoubleClick(sender, e)
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub

    Private Sub frmServicios_PedRepuestos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
         txtIdCliente.KeyPress _
        , txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmServicios_PedRepuestos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 102)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        Dim estilo As New Estilo
        estilo.cargaEstiloGrid_Bucadores(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        state_Search = True
        listaDatos()
        txtNumDoc.Select()
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 0 Then
            biactualizar.Enabled = False
            biMostrar.Enabled = False
        Else
            biactualizar.Enabled = True
            biMostrar.Enabled = True
        End If
    End Sub

    Private Sub llenarCombos()
        Try

            '====================================== OFICINAS ============================================
            dtLocaciones = oMaestroService.MostrarOficinas("").Tables(0)
            'dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
            cmbIdLocacion.DataSource = dtLocaciones
            cmbIdLocacion.DropDownList.DataMember = dtLocaciones.Columns("DesOfi").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtLocaciones.Columns("DesOfi").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtLocaciones.Columns("CodOfi").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("CodOfi").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("DesOfi").ToString
            cmbIdLocacion.SelectedIndex = 0
            dtLocaciones = Nothing

        Catch ex As Exception
            MsgBox("ERROR [BUSC-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            chkCliente.Checked = False
            If toNull(frm.codigo) <> Nothing Then
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            listaDatos()
        End If
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtIdCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            PictureBox1.Enabled = False
            txtIdCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            PictureBox1.Enabled = True
        End If
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oTransferenciaService.MostrarJobPendientes(Session.sCodEmp, cmbIdLocacion.Value, txtNumDoc.Text, IdCliente).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells("CodJob").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtNumDoc.TextChanged, txtIdCliente.TextChanged, cmbIdLocacion.ValueChanged
        listaDatos()
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        Try
            Dim frm As New frmServicios_PedRepuesto
            frm.NumJob = dgvDatos.CurrentRow.Cells("CodJob").Text
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
            frm.DesCli = dgvDatos.CurrentRow.Cells("DesCli").Text
            frm.Text = "Pedidos de Mercadería para Servicios OT :" & dgvDatos.CurrentRow.Cells("CodJob").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                MsgBox("Se realizó el despacho correctamente ")
                listaDatos()
                If frm.dgvDatos.RowCount = 0 Then
                    RowPossesion(dgvDatos, dtDatos, "NumJob", frm.NumJob)
                End If
            End If
            txtNumDoc.Select()
            txtNumDoc.Clear()
        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biactualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("CodJob").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, dtDatos, "CodJob", codigo)
        End If
        enableOpciones()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

End Class