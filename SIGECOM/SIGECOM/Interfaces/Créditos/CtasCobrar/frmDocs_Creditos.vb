Public Class frmDocs_Creditos
  Private oMaestroService As New MaestroService.MaestroClient

  '====================================================================================================================
  '============================================ Parametros Locales ====================================================
  '====================================================================================================================
  Private lMostrar As Boolean
  Private dtTipoDocumentos As DataTable
  Private dtDatos As DataTable
  Private IdCliente, IdDocumento As String
  Private NumDocumento As Integer
  '====================================================================================================================
  '============================================ Metodos de Control ====================================================
  '====================================================================================================================
  Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtCliente.KeyPress, cmbDocu.KeyPress, txtNumDoc.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{TAB}")
    End If
  End Sub

  Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtCliente.KeyPress, cmbDocu.KeyPress, txtNumDoc.KeyPress, btnBuscar.KeyPress, dgvDatos.KeyPress
    If e.KeyChar = ChrW(Keys.Escape) Then
      Me.Dispose()
    End If
  End Sub

  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    refrescarMenus()
    Dim estilo As New Estilo
    estilo.cargaEstiloGridExtAlternating(dgvDatos)
    llenarCombos()
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

  '====================================================================================================================
  '============================================ Metodos de Asignación =================================================
  '====================================================================================================================
  Private Sub refrescarMenus()
    lMostrar = IIf(dgvDatos.RowCount > 0, True, False)
    Me.biMostrar.Enabled = lMostrar
    Me.biActualizar.Enabled = lMostrar
    Me.miMostrar.Enabled = lMostrar
    Me.miActualizar.Enabled = lMostrar
  End Sub

  Private Sub llenarCombos()
    Try
      '======================================= DOCUMENTOS ==============================================
      dtTipoDocumentos = oMaestroService.MostrarTipDocCtaCte.Tables(0)
      cmbDocu.DataSource = dtTipoDocumentos
      cmbDocu.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
      cmbDocu.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
      cmbDocu.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
      cmbDocu.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
      cmbDocu.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
      cmbDocu.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
      cmbDocu.SelectedIndex = 0
      dtTipoDocumentos = Nothing
    Catch ex As Exception
      MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub

  Private Sub listaDatos()
    Try
      If IdCliente <> "" Then

      Else

      End If
      Dim lPorVencerSol, lVencidoSol, lPorVencerDol, lVencidoDol As Decimal
      lPorVencerSol = 12.7
      lVencidoSol = 13
      lPorVencerDol = 5
      lVencidoDol = 123.4
      txtPorVencerSol.Text = lPorVencerSol
      txtVencidoSol.Text = lVencidoSol
      txtPorVencerDol.Text = lPorVencerDol
      txtVencidoDol.Text = lVencidoDol
      txtSaldoSol.Text = lPorVencerSol + lVencidoSol
      txtSaldoDol.Text = lPorVencerDol + lVencidoDol
    Catch ex As Exception
      MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
    refrescarMenus()
  End Sub

  '====================================================================================================================
  '============================================ Metodos de Interface ==================================================
  '====================================================================================================================
  Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click

  End Sub

  Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
    Dim codigo As String = ""
    If dgvDatos.RowCount > 0 Then
      codigo = dgvDatos.CurrentRow.Cells("IdCliente").Text
    End If
    dtDatos = Nothing
    listaDatos()
    If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
      RowPossesion(dgvDatos, dtDatos, "IdCliente", codigo)
    End If
  End Sub

  Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
    Me.Dispose()
  End Sub

  Private Sub cmbDocu_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDocu.ValueChanged
    SendKeys.Send("{TAB}")
  End Sub

  Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
    btnBuscar.Focus()
  End Sub

  Private Sub txtCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.ButtonClick
    Dim frm As New frmBuscarCliente
    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
      txtCliente.Text = frm.descripcion
      txtCliente.BackColor = System.Drawing.SystemColors.Control
      IdCliente = frm.codigo
      txtNumDoc.Text = ""
    End If
  End Sub

  Private Sub txtNumDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    If txtNumDoc.Text <> "" Then
      txtCliente.Text = ""
    End If
  End Sub

  Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
    listaDatos()
  End Sub

End Class