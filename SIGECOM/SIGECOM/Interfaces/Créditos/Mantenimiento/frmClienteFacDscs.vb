Public Class frmClienteFacDscs
  Private oMaestroService As New MaestroService.MaestroClient
  Private oClienteFacDscService As New ClienteFacDscService.ClienteFacDscServiceClient
  Private dtDatos As DataTable
  Private state_Search As Boolean
  '====================================================================================================================
  '============================================ LOCAL PARAMETERS ======================================================
  '====================================================================================================================
  Private lCodEmp
  Private lGruAlm
  Private IdCliente
  Private dtGrupos As DataTable
  '====================================================================================================================
  '============================================ CONTROL'S METHOD ======================================================
  '====================================================================================================================
  Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
              cmbGrupo.KeyPress, txtCliente.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{TAB}")
      listaDatos()
    End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.KeyCode = Keys.Enter Then
                If dgvDatos.RowCount > 0 Then
                    mostrar()
                    e.Handled = True
                End If
            End If
        End If
    End Sub
  Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
              cmbGrupo.KeyPress, txtCliente.KeyPress, _
              btnBuscar.KeyPress, btnLimpiar.KeyPress, dgvDatos.KeyPress
    If e.KeyChar = ChrW(Keys.Escape) Then
      Me.Dispose()
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

    Private Sub frmClienteFacDscs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim estilo As New Estilo
    estilo.cargaEstiloGridExtAlternating(dgvDatos)
    state_Search = False
    llenarCombos()
    IdCliente = 0
    state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub
  Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Try
      If isClosed(oMaestroService) = False Then
        oMaestroService.Close()
      End If
      If isClosed(oClienteFacDscService) = False Then
        oClienteFacDscService.Close()
      End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal numero As String)
    If type_process = "update" Then
      cmbGrupo.SelectedIndex = 0
      txtCliente.Text = ""
    ElseIf type_process = "insert" Then
      cmbGrupo.SelectedIndex = 0
      txtCliente.Text = ""
    End If
  End Sub
  Private Sub enableOpciones()
    If dgvDatos.RowCount < 1 Then
      miMostrar.Enabled = False
      miEliminar.Enabled = False
      miImprimir.Enabled = False
      biMostrar.Enabled = False
      biEliminar.Enabled = False
      biImprimir.Enabled = False
    Else
      miMostrar.Enabled = True
      miEliminar.Enabled = True
      miImprimir.Enabled = True
      biMostrar.Enabled = True
      biEliminar.Enabled = True
      biImprimir.Enabled = True
    End If
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

    Return fila
  End Function
  '==================================================================================================================== 
  '============================================ TASK'S METHOD =========================================================
  '====================================================================================================================
  Private Sub mostrar()
    Try
      Dim frm As New frmClienteFacDsc
      frm.state_button = True
      frm.lGruAlm = cmbGrupo.Value
      frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
      If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
        dtDatos = Nothing
        If frm.type_process = "update" Then
          limpiaOpcionesBusqueda("update", 0)
          listaDatos()
          RowPossesion(dgvDatos, dtDatos, "IdCliente", frm.IdCliente)
        Else
          listaDatos()
          MsgBox("Se elimino el registro correctamente...!!!", MsgBoxStyle.Information)
        End If
      End If
    Catch ex As Exception
      MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub eliminar()
    Try
      cmOpciones.Visible = False
      If MsgBox("Está seguro de ELIMINAR el Cliente " + dgvDatos.CurrentRow.Cells("DesCli").Text.ToString, MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
        Dim estado_process As Boolean
                estado_process = oClienteFacDscService.Borrar(Session.sCodEmp, dgvDatos.CurrentRow.Cells("GruAlm").Value, _
                                                              dgvDatos.CurrentRow.Cells("IdCliente").Value, Session.sCodUsu)
        If estado_process = True Then
          dtDatos = Nothing
          listaDatos()
          MsgBox("Se elimino correctamente el registro...!!!", MsgBoxStyle.Information)
        Else
          MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
        End If
      End If
    Catch ex As Exception
      MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub Nuevo()
    Try
      Dim frm As New frmClienteFacDsc
      frm.state_button = False
      frm.lGruAlm = cmbGrupo.Value
      frm.IdCliente = 0
      If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
        dtDatos = Nothing
        limpiaOpcionesBusqueda("insert", 0)
        listaDatos()
        'If frm.type_process = "insert" Then
        RowPossesion(dgvDatos, dtDatos, "IdCliente", frm.IdCliente)
        '  mostrar()
        'End If
      End If
    Catch ex As Exception
      MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub listaDatos()
    Try
      If state_Search = True Then
        dtDatos = oClienteFacDscService.Filtrar(Session.sCodEmp, cmbGrupo.Value, IdCliente, 0, 0).Tables(0)
        dgvDatos.SetDataBinding(dtDatos, 0)
        sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        enableOpciones()
      End If
    Catch ex As Exception
      MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
    dgvDatos.Focus()
  End Sub
  Private Sub llenarCombos()
    Try
      '======================================= GRUPOS ================================================
      dtGrupos = oMaestroService.MostrarGrupoAlmacen.Tables(0)
      'dtGrupos.Rows.InsertAt(getRowTodos(dtMeses), 0)
      cmbGrupo.DataSource = dtGrupos
      cmbGrupo.DropDownList.DataMember = dtGrupos.Columns("DesGru").ToString
      cmbGrupo.DropDownList.DisplayMember = dtGrupos.Columns("DesGru").ToString
      cmbGrupo.DropDownList.ValueMember = dtGrupos.Columns("GruAlm").ToString
      cmbGrupo.DropDownList.Columns(0).DataMember = dtGrupos.Columns("GruAlm").ToString
      cmbGrupo.DropDownList.Columns(1).DataMember = dtGrupos.Columns("DesGru").ToString
      cmbGrupo.SelectedIndex = 0
      dtGrupos = Nothing
    Catch ex As Exception
      MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
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
      ElseIf dgvDatos.CurrentRow.Cells("IdCliente").Text = Nothing Then
        MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
        Return False
      Else
        Return True
      End If
    Catch ex As Exception
      MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Function
  '====================================================================================================================
  '============================================ INTERFACE'S METHOD ====================================================
  '====================================================================================================================
  Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
    If ValidaCodigoSeleccionado() Then
      mostrar()
    End If
  End Sub
  Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
    listaDatos()
  End Sub
  Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
    txtCliente.Text = ""
    cmbGrupo.SelectedIndex = 0
    listaDatos()
  End Sub
  Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
    Nuevo()
  End Sub
  Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
    If ValidaCodigoSeleccionado() Then
      mostrar()
    End If
  End Sub
  Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
    If ValidaCodigoSeleccionado() Then
      eliminar()
    End If
  End Sub
  Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
    Me.Dispose()
  End Sub
  Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
    If ValidaCodigoSeleccionado() Then
      mostrar()
    End If
  End Sub
  Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
    If ValidaCodigoSeleccionado() Then
      eliminar()
    End If
  End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
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
  Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
    Nuevo()
  End Sub
  Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                  cmbGrupo.ValueChanged
    listaDatos()
  End Sub
  Private Sub txtCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.ButtonClick
    Dim frm As New frmBuscarCliente
    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
      If toNull(frm.codigo) <> Nothing Then
        txtCliente.Text = frm.descripcion
        IdCliente = frm.codigo
      Else
        txtCliente.Text = ""
        IdCliente = 0
      End If
      listaDatos()
    End If
  End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click

    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.Dispose()
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear un Nuevo Registro."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar los Datos del Registro Seleccionado."
    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Registro Seleccionado."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Registro Seleccionado."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
       biImprimir.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, biNuevo.MouseLeave, miEliminar.MouseLeave, miMostrar.MouseLeave, _
       miImprimir.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave, miNuevo.MouseLeave, miEliminar.MouseLeave, miMostrar.MouseLeave
        sslError.Text = ""
    End Sub
End Class