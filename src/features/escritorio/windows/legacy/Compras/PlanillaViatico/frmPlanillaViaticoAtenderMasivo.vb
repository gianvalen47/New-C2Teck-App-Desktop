Imports System.ServiceModel

Public Class frmPlanillaViaticoAtenderMasivo

    '===========================Servicios====================================================
    Private oMaestroService As New MaestroService.MaestroClient    
    Private oPlanillaViaticoService As New PlanillaViaticoService.PlanillaViaticoServiceClient    

    Public IdPersona As Integer
    Public IdUbicacion As Integer   'Ubicacion de caja seleccionada de frmPlanillasViatico
    Private dtAreas As DataTable    
    Private dtTipo As DataTable
    Private dtDatos As New DataTable
    Private dtUbicacion As DataTable

    Private Sub frmPlanillaViaticoAtenderMasivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oMaestroService.Close()            
            oPlanillaViaticoService.Close()            
        Catch ex As TimeoutException
            oMaestroService.Abort()            
            oPlanillaViaticoService.Abort()            
        Catch ex As CommunicationException
            oMaestroService.Abort()            
            oPlanillaViaticoService.Abort()            
        End Try
    End Sub

    Private Sub frmPlanillaViaticoAtenderMasivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmPlanillaViaticoAtenderMasivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.AutoGenerateColumns = False
        llenarCombos()

        Dim Anio, meses As Integer
        Dim Fecha As Date

        Fecha = Today
        meses = Month(Today)
        If meses = 1 Then            
            Anio = Year(Today)
        Else            
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If        
        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Fecha

        listaDatos()
        enableOpciones()
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            If dtAreas.Rows.Count > 1 Then
                dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            End If
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

            '======================================= TIPO : REFRIG-MOVIL ================================================
            dtTipo = New DataTable
            dtTipo.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipo.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipo.Rows.Add(New Object() {"0", "(Todos)"})
            dtTipo.Rows.Add(New Object() {"1", "Movilidad"})
            dtTipo.Rows.Add(New Object() {"2", "Refrigerio"})

            cmbTipo.DataSource = dtTipo
            cmbTipo.DropDownList.DataMember = dtTipo.Columns("nombre").ToString
            cmbTipo.DropDownList.DisplayMember = dtTipo.Columns("nombre").ToString
            cmbTipo.DropDownList.ValueMember = dtTipo.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTipo.Columns("codigo").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTipo.Columns("nombre").ToString
            cmbTipo.SelectedIndex = 0
            dtTipo = Nothing

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

    Private Sub listaDatos()
        Try
            dgvDatos.AutoGenerateColumns = False
            dtDatos = oPlanillaViaticoService.MostrarPendientesAtencion(cbFecInicio.Value, cbFecFinal.Value, IdPersona, CStr(cmbCodArea.Value), txtNumJob.Text, toNumber(txtNumero.Text), toNumber(cmbTipo.Value), IdUbicacion).Tables(0)
            dgvDatos.DataSource = dtDatos

            cIdPlanilla.DataPropertyName = dtDatos.Columns("IdPlanilla").ColumnName
            cIdPer.DataPropertyName = dtDatos.Columns("IdPer").ColumnName
            cAbrPer2.DataPropertyName = dtDatos.Columns("AbrPer2").ColumnName
            cCodJob.DataPropertyName = dtDatos.Columns("CodJob").ColumnName
            cCodArea.DataPropertyName = dtDatos.Columns("CodArea").ColumnName
            cDesArea.DataPropertyName = dtDatos.Columns("DesArea").ColumnName
            cFecha.DataPropertyName = dtDatos.Columns("Fecha").ColumnName
            cFecReg.DataPropertyName = dtDatos.Columns("FecReg").ColumnName
            cDescripcion.DataPropertyName = dtDatos.Columns("Descripcion").ColumnName
            cCodMon.DataPropertyName = dtDatos.Columns("CodMon").ColumnName
            cMonto.DataPropertyName = dtDatos.Columns("Monto").ColumnName
            cTipo.DataPropertyName = dtDatos.Columns("Tipo").ColumnName
            cDesTipo.DataPropertyName = dtDatos.Columns("DesTipo").ColumnName
            cProcesado.DataPropertyName = dtDatos.Columns("Procesado").ColumnName

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biAtender.Enabled = False
        Else
            biImprimir.Enabled = True
            biAtender.Enabled = True
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAtender_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAtender.Click
        Try
            If MsgBox("¿Está seguro de APROBAR la(s) Planilla(s) de Viático Seleccionada(s)", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvDatos.Update()
                Dim dtTable As DataTable
                'Dim rows As DataRow
                Dim Cont As Integer = 0
                Dim cPlanilla As Integer

                dtTable = dtDatos.Copy
                dtTable.Clear()

                For i As Integer = 0 To dtDatos.Rows.Count - 1

                    Dim row As DataGridViewRow = dgvDatos.Rows(i)
                    Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbAtender"), DataGridViewCheckBoxCell)

                    If toBoolean(cellSelecion.Value) = True Then
                        Cont = Cont + 1
                        cPlanilla = toNumber(row.Cells("cIdPlanilla").Value)
                        oPlanillaViaticoService.Atender(cPlanilla, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    End If
                Next
                If Cont < 1 Then
                    MsgBox("Debe seleccionar una de las Planillas de Viático")
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    MsgBox("Se Atendió la(s) Planilla(s) de Viático correctamente")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al APROBAR la(s) Planilla(s) de Viático")
        End Try
    End Sub

    Private Sub dgvDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        TextBox1.Select()
    End Sub

    Private Sub miSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodos.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells("cbAtender").Value = True
        Next
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells("cbAtender").Value = False
        Next
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtSolicitante.TextChanged, txtNumJob.TextChanged, cbFecInicio.ValueChanged, cbFecFinal.ValueChanged, cmbCodArea.ValueChanged, txtNumero.TextChanged, cmbTipo.ValueChanged
        listaDatos()
    End Sub

    Private Sub btnBuscarPersona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarPersona.Click
        Try
            Dim frm As New frmBuscarPersonal
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                chkPersona.Checked = False
                If toNull(frm.codigo) <> Nothing Then
                    txtSolicitante.Text = frm.descripcion
                    IdPersona = frm.codigo
                Else
                    txtSolicitante.Text = "(Todos)"
                    IdPersona = 0
                End If
                listaDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkPersona_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPersona.CheckedChanged
        If txtSolicitante.Text <> "(Todos)" Then
            chkPersona.Enabled = False
            txtSolicitante.Text = "(Todos)"
            IdPersona = 0
            listaDatos()
        Else
            chkPersona.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub txtColaborador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSolicitante.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarPersona.Enabled = True Then
                e.Handled = True
                btnBuscarPersona_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                             biAtender.MouseLeave, biSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Atender_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAtender.MouseEnter
        sslError.Text = "Atender Planilla(s) de Viático seleccionada(s)."
    End Sub
End Class