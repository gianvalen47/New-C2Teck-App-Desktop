Imports System.ServiceModel
Public Class frmAsignacionHE_Imprimir

    '=========================== Servicios ===================================================
    Private oAsignacionHoraExtraService As New AsignacionHoraExtraService.AsignacionHoraExtraServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Private dtAreas As DataTable
    Private dtMotivo As DataTable
    Private dtCentroCosto As DataTable
    Private dtPerAutoriza As DataTable

    Public iCodArea As String
    Public iCodCentro As String
    Public iFecha As Date

    Private Sub frmAsignacionHE_Imprimir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmAsignacionHE_Imprimir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.AutoGenerateColumns = False
        txtFecha.Value = Today
        llenarCombos()
        If iCodArea <> "" Then
            cmbCodArea.Value = iCodArea
        End If
        If iCodCentro <> "" Then
            cmbCentroCosto.Value = iCodCentro
        End If
        If iFecha <> Today Then
            txtFecha.Value = iFecha
        Else
            txtFecha.Value = Today
        End If
        listaDatos()
        enableOpciones()
    End Sub

    Private Sub Finalizar()
        Try
            oAsignacionHoraExtraService.Close()
            oAsignacionJefesService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oAsignacionHoraExtraService.Abort()
            oAsignacionJefesService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oAsignacionHoraExtraService.Abort()
            oAsignacionJefesService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmAsignacionHE_Imprimir_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                              txtFecha.KeyPress _
                            , cmbCodArea.KeyPress _
                            , cmbCentroCosto.KeyPress _
                            , cmbPerAutoriza.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub llenarCombos()
        Try
            '======================================== AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            cmbCentroCosto.DataSource = dtCentroCosto
            cmbCentroCosto.DropDownList.DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.DisplayMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.DropDownList.ValueMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(0).DataMember = dtCentroCosto.Columns("CodCentro").ToString
            cmbCentroCosto.DropDownList.Columns(1).DataMember = dtCentroCosto.Columns("DesCentro").ToString
            cmbCentroCosto.SelectedIndex = 0
            listaDatos()

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub cmbCentroCosto_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCentroCosto.ValueChanged
        If cmbCentroCosto.Value <> "" Then

            '=================================== PERSONA AUTORIZA ==========================================
            dtPerAutoriza = oAsignacionJefesService.MostrarJefeArea(cmbCentroCosto.Value).Tables(0)
            cmbPerAutoriza.DataSource = dtPerAutoriza
            cmbPerAutoriza.DropDownList.DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.DisplayMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.DropDownList.ValueMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(0).DataMember = dtPerAutoriza.Columns("IdPer").ToString
            cmbPerAutoriza.DropDownList.Columns(1).DataMember = dtPerAutoriza.Columns("ApeNom").ToString
            cmbPerAutoriza.SelectedIndex = 0
            dtPerAutoriza = Nothing
            listaDatos()

        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oAsignacionHoraExtraService.ImprimirGrupo(Session.sCodEmp, cmbCodArea.Value, cmbCentroCosto.Value, txtFecha.Value, toNumber(cmbPerAutoriza.Value)).Tables(0)
            dgvDatos.DataSource = dtDatos

            cDesEmp.DataPropertyName = dtDatos.Columns("DesEmp").ColumnName
            cRucEmp.DataPropertyName = dtDatos.Columns("RucEmp").ColumnName
            cDesArea.DataPropertyName = dtDatos.Columns("DesArea").ColumnName
            cDesCentro.DataPropertyName = dtDatos.Columns("DesCentro").ColumnName
            cIdAsignacion.DataPropertyName = dtDatos.Columns("IdAsignacion").ColumnName
            cIdPer.DataPropertyName = dtDatos.Columns("IdPer").ColumnName
            cApeNom.DataPropertyName = dtDatos.Columns("ApeNom").ColumnName
            cFecha.DataPropertyName = dtDatos.Columns("Fecha").ColumnName
            cHoraInicio.DataPropertyName = dtDatos.Columns("HoraInicio").ColumnName
            cHoraFinal.DataPropertyName = dtDatos.Columns("HoraFinal").ColumnName
            cCodJob.DataPropertyName = dtDatos.Columns("CodJob").ColumnName
            cObservacion.DataPropertyName = dtDatos.Columns("Observacion").ColumnName
            cProcesado.DataPropertyName = dtDatos.Columns("Procesado").ColumnName
            cIdPerAutoriza.DataPropertyName = dtDatos.Columns("IdPerAutoriza").ColumnName
            cApeNomAutoriza.DataPropertyName = dtDatos.Columns("ApeNomAutoriza").ColumnName
            cCodUsu.DataPropertyName = dtDatos.Columns("CodUsu").ColumnName
            cNomPc.DataPropertyName = dtDatos.Columns("NomPc").ColumnName            
            cDirIp.DataPropertyName = dtDatos.Columns("DirIp").ColumnName

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Try
            dgvDatos.Update()
            Dim dtTable As DataTable
            Dim rows As DataRow

            dtTable = dtDatos.Copy
            dtTable.Clear()

            For i As Integer = 0 To dtDatos.Rows.Count - 1

                Dim row As DataGridViewRow = dgvDatos.Rows(i)
                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbAtender"), DataGridViewCheckBoxCell)

                If toBoolean(cellSelecion.Value) = True Then
                    rows = dtTable.NewRow
                    rows(0) = dtDatos.Rows(i).Item(0)
                    rows(1) = dtDatos.Rows(i).Item(1)
                    rows(2) = dtDatos.Rows(i).Item(2)
                    rows(3) = dtDatos.Rows(i).Item(3)
                    rows(4) = dtDatos.Rows(i).Item(4)
                    rows(5) = dtDatos.Rows(i).Item(5)
                    rows(6) = dtDatos.Rows(i).Item(6)
                    rows(7) = dtDatos.Rows(i).Item(7)
                    rows(8) = dtDatos.Rows(i).Item(8)
                    rows(9) = dtDatos.Rows(i).Item(9)
                    rows(10) = dtDatos.Rows(i).Item(10)
                    rows(11) = dtDatos.Rows(i).Item(11)
                    rows(12) = dtDatos.Rows(i).Item(12)
                    rows(13) = dtDatos.Rows(i).Item(13)
                    rows(14) = dtDatos.Rows(i).Item(14)
                    rows(15) = dtDatos.Rows(i).Item(15)
                    rows(16) = dtDatos.Rows(i).Item(16)
                    rows(17) = dtDatos.Rows(i).Item(17)

                    dtTable.Rows.Add(rows)
                End If

            Next
            Dim forma As New frmReportes
            Dim reporte As New rptAsignacionHECentroCosto
            Dim dtReporte As New DataTable

            dtReporte = dtTable

            If dtReporte.Rows.Count = 0 Then
                MsgBox("!Debe seleccionar al menos un registro...!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                'forma.crvReportes.DisplayGroupTree = False
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                forma.Text = "Reporte de Asignaciones de HE por Centro de Costo"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False

            miNinguno.Enabled = False
            miSeleccionarTodos.Enabled = False
        Else
            biImprimir.Enabled = True

            miNinguno.Enabled = True
            miSeleccionarTodos.Enabled = True
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        TextBox1.Select()
    End Sub

    Private Sub miSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodos.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(18).Value = True
        Next
    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click
        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(18).Value = False
        Next
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtFecha.ValueChanged, cmbPerAutoriza.ValueChanged
        listaDatos()
    End Sub
End Class