Imports System.ServiceModel
Public Class frmComSolicitudGasto_Viatico

    '===========================Servicios====================================================
    Private oPlanillaViaticoService As New PlanillaViaticoService.PlanillaViaticoServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient

    '======================Declaración de Variables==============================
    Private dtDatos As DataTable
    Public IdGasto As Integer
    Public CodMon As String
    Private dtTipo As DataTable
    Public state_process As Integer

    Private Sub frmComSolicitudGasto_Viatico_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oPlanillaViaticoService.Close()
            oSolicitudGastoDetService.Close()
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oPlanillaViaticoService.Abort()
            oSolicitudGastoDetService.Abort()
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oPlanillaViaticoService.Abort()
            oSolicitudGastoDetService.Abort()
            oProvisionalService.Abort()
        End Try
    End Sub

    Private Sub frmComSolicitudGasto_Viatico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.ScrollBars = ScrollBars.Both
        dgvDatos.AutoGenerateColumns = False

        llenarCombos()

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date

        Fecha = Today
        meses = Month(Today)
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        listaDatos()
        Me.Text = "Ingresar Planillas de Viático a la Solicitud de Gastos Nº " & IdGasto.ToString
    End Sub

    Private Sub frmComSolicitudGasto_Viatico_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            Dim UsuarioCaja As Boolean = oProvisionalService.BuscarUsuarioCaja(Session.sCodUsu)
            dtDatos = oPlanillaViaticoService.FiltrarAprobados(cbFecInicio.Value, cbFecFinal.Value, toNumber(cmbTipo.Value), CodMon, IIf(UsuarioCaja, oProvisionalService.ObtenerIdUbicacion(Session.sCodUsu, Session.sCodEmp), 0)).Tables(0)
            dgvDatos.DataSource = dtDatos

            CCodEmp.DataPropertyName = dtDatos.Columns("CodEmp").ColumnName
            cDesEmp.DataPropertyName = dtDatos.Columns("DesEmp").ColumnName
            cRucEmp.DataPropertyName = dtDatos.Columns("RucEmp").ColumnName
            cIdPlanilla.DataPropertyName = dtDatos.Columns("IdPlanilla").ColumnName
            cNomUbicacion.DataPropertyName = dtDatos.Columns("NomUbicacion").ColumnName
            cIdPer.DataPropertyName = dtDatos.Columns("IdPer").ColumnName
            cAbrPer2.DataPropertyName = dtDatos.Columns("AbrPer2").ColumnName
            cApeNom.DataPropertyName = dtDatos.Columns("ApeNom").ColumnName
            cNumDoc.DataPropertyName = dtDatos.Columns("NumDoc").ColumnName
            cCodCentro.DataPropertyName = dtDatos.Columns("CodCentro").ColumnName
            cCodArea.DataPropertyName = dtDatos.Columns("CodArea").ColumnName
            cDesArea.DataPropertyName = dtDatos.Columns("DesArea").ColumnName
            cCodJob.DataPropertyName = dtDatos.Columns("CodJob").ColumnName
            cFecha.DataPropertyName = dtDatos.Columns("Fecha").ColumnName
            cFecReg.DataPropertyName = dtDatos.Columns("FecReg").ColumnName
            cDescripcion.DataPropertyName = dtDatos.Columns("Descripcion").ColumnName
            cCodMon.DataPropertyName = dtDatos.Columns("CodMon").ColumnName
            cMonto.DefaultCellStyle.Format = "N2"
            cMonto.DataPropertyName = dtDatos.Columns("Monto").ColumnName
            cTipo.DataPropertyName = dtDatos.Columns("Tipo").ColumnName
            cDesTipo.DataPropertyName = dtDatos.Columns("DesTipo").ColumnName
            cDesArea1.DataPropertyName = dtDatos.Columns("DesArea1").ColumnName
            cEnviado.DataPropertyName = dtDatos.Columns("Enviado").ColumnName
            cFechaEnv.DataPropertyName = dtDatos.Columns("FechaEnv").ColumnName
            cCodUsuEnv.DataPropertyName = dtDatos.Columns("CodUsuEnv").ColumnName
            cAprobado.DataPropertyName = dtDatos.Columns("Aprobado").ColumnName
            cFechaApro.DataPropertyName = dtDatos.Columns("FechaApro").ColumnName
            cCodUsuApro.DataPropertyName = dtDatos.Columns("CodUsuApro").ColumnName
            cProcesado.DataPropertyName = dtDatos.Columns("Procesado").ColumnName
            cAtendido.DataPropertyName = dtDatos.Columns("Atendido").ColumnName

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================= TIPO : REFRIG-MOVIL ================================================
            dtTipo = New DataTable
            dtTipo.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipo.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            'dtTipo.Rows.Add(New Object() {"0", "(Todos)"})
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
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miSeleccionarTodos.Enabled = False
            miNinguno.Enabled = False
            miInsertar.Enabled = False
            biInsertar.Enabled = False
        Else
            miSeleccionarTodos.Enabled = True
            miNinguno.Enabled = True
            miInsertar.Enabled = True
            biInsertar.Enabled = True
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cbFecInicio.ValueChanged, cbFecFinal.ValueChanged, cmbTipo.ValueChanged
        listaDatos()
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

    Private Sub dgvDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        TextBox1.Select()
    End Sub

    Private Sub Insertar()
        Try
            If MsgBox("¿Está seguro de INSERTAR la(s) Planilla(s) seleccionada(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvDatos.Update()
                Dim dtTable As DataTable
                Dim rows As DataRow

                dtTable = dtDatos.Copy
                dtTable.Clear()

                For i As Integer = 0 To dtDatos.Rows.Count - 1
                    Dim row As DataGridViewRow = dgvDatos.Rows(i)
                    Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbInsertar"), DataGridViewCheckBoxCell)
                    If toBoolean(cellSelecion.Value) = True Then
                        rows = dtTable.NewRow
                        rows(0) = dgvDatos.Rows(i).Cells(0).Value
                        rows(1) = dgvDatos.Rows(i).Cells(1).Value
                        rows(2) = dgvDatos.Rows(i).Cells(2).Value
                        rows(3) = dgvDatos.Rows(i).Cells(3).Value
                        rows(4) = dgvDatos.Rows(i).Cells(4).Value
                        rows(5) = dgvDatos.Rows(i).Cells(5).Value
                        rows(6) = dgvDatos.Rows(i).Cells(6).Value
                        rows(7) = dgvDatos.Rows(i).Cells(7).Value
                        rows(8) = dgvDatos.Rows(i).Cells(8).Value
                        rows(9) = dgvDatos.Rows(i).Cells(9).Value
                        rows(10) = dgvDatos.Rows(i).Cells(10).Value
                        rows(11) = dgvDatos.Rows(i).Cells(11).Value
                        rows(12) = dgvDatos.Rows(i).Cells(12).Value
                        rows(13) = dgvDatos.Rows(i).Cells(13).Value
                        rows(14) = dgvDatos.Rows(i).Cells(14).Value
                        rows(15) = dgvDatos.Rows(i).Cells(15).Value
                        rows(16) = dgvDatos.Rows(i).Cells(16).Value
                        rows(17) = dgvDatos.Rows(i).Cells(17).Value
                        rows(18) = dgvDatos.Rows(i).Cells(18).Value
                        rows(19) = dgvDatos.Rows(i).Cells(19).Value
                        rows(20) = dgvDatos.Rows(i).Cells(20).Value
                        rows(21) = dgvDatos.Rows(i).Cells(21).Value
                        rows(22) = dgvDatos.Rows(i).Cells(22).Value
                        rows(23) = dgvDatos.Rows(i).Cells(23).Value
                        rows(24) = dgvDatos.Rows(i).Cells(24).Value
                        rows(25) = dgvDatos.Rows(i).Cells(25).Value
                        rows(26) = dgvDatos.Rows(i).Cells(26).Value
                        rows(27) = dgvDatos.Rows(i).Cells(27).Value
                        rows(28) = dgvDatos.Rows(i).Cells(28).Value

                        dtTable.Rows.Add(rows)
                    End If
                Next
                If dtTable.Rows.Count = 0 Then
                    MsgBox("Debe seleccionar alguna de las planillas.", MsgBoxStyle.Information, "No hay datos")
                Else
                    state_process = oSolicitudGastoDetService.InsertarPlanilla(IdGasto, dtTable, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If state_process > 0 Then
                        MsgBox("Se insertó la(s) planilla(s) seleccionada(s) Correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodos.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(29).Value = True
        Next
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(29).Value = False
        Next
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click, biActualizar.Click
        listaDatos()
    End Sub

    Private Sub biInsertar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biInsertar.Click, miInsertar.Click
        Insertar()
    End Sub

    Private Sub miSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miSalir.Click, biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class