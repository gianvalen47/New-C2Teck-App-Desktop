Public Class frmAnticipos
  Private oMaestroService As New MaestroService.MaestroClient
    Private oAnticipoService As New AnticipoService.AnticipoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

  Private dtDatos As DataTable
  Private state_Search As Boolean
  '====================================================================================================================
  '============================================ LOCAL PARAMETERS ======================================================
  '====================================================================================================================
  Private IdCliente As Integer
  Private lNumAnt As Integer
  Private dtMeses As DataTable
  '====================================================================================================================
  '============================================ CONTROL'S METHOD ======================================================
  '====================================================================================================================
  Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
              txtAño.KeyPress, cmbMes.KeyPress, txtCliente.KeyPress, txtNumAnt.KeyPress
    If e.KeyChar = ChrW(Keys.Enter) Then
      e.Handled = True
      SendKeys.Send("{TAB}")
      listaDatos()
    End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrar()
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                txtAño.KeyPress, cmbMes.KeyPress, txtCliente.KeyPress, txtNumAnt.KeyPress, _
                btnBuscar.KeyPress, dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub
  Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumAnt.KeyPress
    If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
      e.KeyChar = Chr(0)
    End If
  End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdAnticipo").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmAnticipos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 37)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        txtAño.Value = Today.Year
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
            If isClosed(oAnticipoService) = False Then
                oAnticipoService.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
    'Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal numero As String)
    '  If type_process = "update" Then
    '    txtCliente.Text = ""
    '    txtNumAnt.Text = numero
    '  ElseIf type_process = "insert" Then
    '    txtCliente.Text = ""
    '    txtNumAnt.Text = numero
    '  End If
    'End Sub
    Private Sub enableOpciones()

        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biImprimir.Enabled = False
        Else
            Dim lestado As String
            lestado = dgvDatos.CurrentRow.Cells("EstAnt").Text

            miMostrar.Enabled = True
            miEliminar.Enabled = IIf(lestado = "GN", True, False)
            miImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = IIf(lestado = "GN", True, False)
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
            Dim frm As New frmAnticipo

            frm.state_button = True
            frm.IdAnticipo = dgvDatos.CurrentRow.Cells("IdAnticipo").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing

                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumAnt.Value)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdAnticipo)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If

            End If

        Catch ex As Exception
            MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el Anticipo Nº " + dgvDatos.CurrentRow.Cells("NumAnt").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oAnticipoService.Borrar(dgvDatos.CurrentRow.Cells("IdAnticipo").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
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
            Dim frm As New frmAnticipo

            frm.state_button = False
            frm.IdAnticipo = 0

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumAnt.Value)
                listaDatos()
                'If frm.type_process = "insert" Then
                RowPossesion(dgvDatos, frm.IdAnticipo)
                'mostrar()
                'End If
            End If

    Catch ex As Exception
      MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub listaDatos()
    Try
      If state_Search = True Then
        dtDatos = oAnticipoService.Filtrar(Session.sCodEmp, txtAño.Value, cmbMes.Value, IdCliente, "", txtNumAnt.Value).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)
                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        enableOpciones()
      End If
    Catch ex As Exception
      MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub llenarCombos()
    Try
      '======================================= MESES ================================================
      dtMeses = oMaestroService.MostrarMeses
      dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
      cmbMes.DataSource = dtMeses
      cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
      cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
      cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
      cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
      cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
      cmbMes.SelectedIndex = 0
      dtMeses = Nothing
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
      ElseIf dgvDatos.CurrentRow.Cells("IdAnticipo").Text = Nothing Then
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
    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtCliente.Text = ""
        txtNumAnt.Value = 0
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
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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
  Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
    Dim codigo As String = ""
    If dgvDatos.RowCount > 0 Then
      codigo = dgvDatos.CurrentRow.Cells("IdAnticipo").Text
    End If
    dtDatos = Nothing
    listaDatos()
    If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
    End If
  End Sub
  Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
    Nuevo()
  End Sub
  Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                  cmbMes.ValueChanged
    listaDatos()
  End Sub
  Private Sub txtAño_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAño.Click
    listaDatos()
  End Sub
  Private Sub txtCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.ButtonClick
    Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            chkCliente.Checked = False
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

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        If ValidaCodigoSeleccionado() Then
            Try
                Dim forma As New frmReportes
                Dim reporte As New rpAnticipo
                Dim dtReporte As New DataTable
                Dim IdAnticipo As Integer = dgvDatos.CurrentRow.Cells("IdAnticipo").Text

                dtReporte = oAnticipoService.Imprimir(IdAnticipo).Tables(0)
                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Anticipos"
                    reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotAnt").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                    forma.ShowDialog()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        End If
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged

        If txtCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdAnticipo").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
End Class