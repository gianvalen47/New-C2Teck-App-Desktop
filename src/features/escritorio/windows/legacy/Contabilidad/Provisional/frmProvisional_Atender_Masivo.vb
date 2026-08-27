Imports System.ServiceModel
Public Class frmProvisional_Atender_Masivo

    '===========================Servicios====================================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtDatos As DataTable
    Private dtMonedas As DataTable

    Private Sub frmProvisional_Atender_Masivo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oProvisionalService.Close()
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmProvisional_Atender_Masivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProvisional_Atender_Masivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDatos.BackgroundColor = Color.Beige
        dgvDatos.BackColor = Color.Beige
        dgvDatos.ForeColor = Color.MidnightBlue
        dgvDatos.AutoGenerateColumns = False
        llenarCombos()
        cmbMoneda.Value = "NS"
        listaDatos()
        enableOpciones()
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
            fila(2) = "(Todos)"
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function


    Private Sub llenarCombos()
        Try

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            dtMonedas.Rows.InsertAt(getRowTodos(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listaDatos()
        Try
            'dtDatos = oProvisionalService.MostrarViaticoAprobado().Tables(0)   oProvisionalService.ObtenerIdUbicacion(Session.sCodUsu)
            dtDatos = oProvisionalService.MostrarViaticoAprobado(oProvisionalService.ObtenerIdUbicacion(Session.sCodUsu, Session.sCodEmp), cmbMoneda.Value).Tables(0)
            dgvDatos.DataSource = dtDatos

            cIdProvisional.DataPropertyName = dtDatos.Columns("IdProvisional").ColumnName
            cIdUbicacion.DataPropertyName = dtDatos.Columns("IdUbicacion").ColumnName
            cNomUbicacion.DataPropertyName = dtDatos.Columns("NomUbicacion").ColumnName
            cCodArea.DataPropertyName = dtDatos.Columns("CodArea").ColumnName
            cDesArea.DataPropertyName = dtDatos.Columns("DesArea").ColumnName
            cIdPer.DataPropertyName = dtDatos.Columns("IdPer").ColumnName
            cApeNom.DataPropertyName = dtDatos.Columns("ApeNom").ColumnName
            cFecha.DataPropertyName = dtDatos.Columns("Fecha").ColumnName
            cCodJob.DataPropertyName = dtDatos.Columns("CodJob").ColumnName
            cMotivo.DataPropertyName = dtDatos.Columns("Motivo").ColumnName
            cCodMon.DataPropertyName = dtDatos.Columns("CodMon").ColumnName
            cDesMon.DataPropertyName = dtDatos.Columns("DesMon").ColumnName
            cAbrMon.DataPropertyName = dtDatos.Columns("AbrMon").ColumnName
            cTotEntega.DataPropertyName = dtDatos.Columns("TotEntrega").ColumnName
            cObservacion.DataPropertyName = dtDatos.Columns("Observacion").ColumnName
            cViatico.DataPropertyName = dtDatos.Columns("Viatico").ColumnName
            cIdEstado.DataPropertyName = dtDatos.Columns("IdEstado").ColumnName
            cDesEstado.DataPropertyName = dtDatos.Columns("DesEstado").ColumnName
            cCodUsu.DataPropertyName = dtDatos.Columns("CodUsu").ColumnName

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

            miNinguno.Enabled = False
            miSeleccionarTodos.Enabled = False
        Else
            biImprimir.Enabled = True
            biAtender.Enabled = True

            miNinguno.Enabled = True
            miSeleccionarTodos.Enabled = True
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biAtender_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biAtender.Click
        Try
            If MsgBox("¿Está seguro de ATENDER el(los) Provisional(es) seleccionado(s)?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                dgvDatos.Update()
                Dim dtTable As DataTable
                ' Dim rows As DataRow
                Dim Cont As Integer = 0
                Dim cProvisional As Integer
                dtTable = dtDatos.Copy
                dtTable.Clear()
                For i As Integer = 0 To dtDatos.Rows.Count - 1
                    Dim row As DataGridViewRow = dgvDatos.Rows(i)
                    Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("cbAtender"), DataGridViewCheckBoxCell)
                    If toBoolean(cellSelecion.Value) = True Then
                        Cont = Cont + 1
                        cProvisional = toNumber(row.Cells("cIdProvisional").Value)
                        oProvisionalService.Atender(cProvisional, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    End If
                Next
                If Cont < 1 Then
                    MsgBox("Debe seleccionar uno de los provisionales")
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    MsgBox("Se atendió el(los) provisional(es) correctamente")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al ATENDER el(los) provisionales")
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
                    rows(18) = dtDatos.Rows(i).Item(18)
                    rows(19) = dtDatos.Rows(i).Item(19)
                    rows(20) = dtDatos.Rows(i).Item(20)

                    dtTable.Rows.Add(rows)
                End If

            Next
            Dim forma As New frmReportes
            Dim reporte As New rptProvisional_Aprobado_Listado
            Dim dtReporte As New DataTable

            dtReporte = dtTable

            If dtReporte.Rows.Count = 0 Then
                MsgBox("!Debe seleccionar un provisional...!", MsgBoxStyle.Information, "No hay datos")
            Else
                reporte.SetDataSource(dtReporte)
                forma.crvReportes.ReportSource = reporte
                ' Validar Usuario - Exportar Excel
                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                    forma.crvReportes.ShowExportButton = True
                Else
                    forma.crvReportes.ShowExportButton = False
                End If
                ' forma.crvReportes.DisplayGroupTree = False
                forma.Text = "Listado de Provisionales Aprobados"
                forma.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub dgvDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
        TextBox1.Select()
    End Sub

    Private Sub miSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSeleccionarTodos.Click

        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(19).Value = True
        Next

    End Sub

    Private Sub miNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNinguno.Click

        For Each fila As DataGridViewRow In dgvDatos.Rows
            fila.Cells(19).Value = False
        Next

    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbMoneda.ValueChanged
        listaDatos()
    End Sub


End Class