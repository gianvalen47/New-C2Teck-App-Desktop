Imports System.ServiceModel
Public Class frmAgregar_Job_SolGastosNew

    '===========================Servicios====================================================
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================================
    Private dtSeleccionados As DataTable
    Private dtJobs As DataTable

    Public IdGasto As Integer
    Public IdGastoDet As Integer

    Public Monto As Double
    Public MontoSinIgv As Double
    Public MontoNoAfecto As Double
    Public MontoTotal As Double

    Public SubTotal As Double
    Public totalIgv As Double
    Public totalNoAfecto As Double
    Public totalOtroCargo As Double
    Public totalNeto As Double
    Public IdDocumento As Integer

    Public AfectoIgv As Boolean        'Devuelve el valor AfectoIgv de la cabecera del detalle para poder calcular el monto sin Igv 25/04/2014
    Public Igv As Double               'Devuelve el valor del Igv de la cabecera del detalle para poder calcular el monto sin Igv 25/04/2014

    Private CodJob As String    

    Private dtLocaciones As DataTable
    Private dtTiposJob As DataTable
    Private state_Search As Boolean

    Private dtAreas As DataTable
    Private dtCentroCosto As New DataTable

    Private Sub frmAgregar_Job_SolGastos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvJobs.BackgroundColor = Color.Beige
        dgvJobs.BackColor = Color.Beige
        dgvJobs.ForeColor = Color.MidnightBlue
        dgvJobs.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False

        LlenarCombos()
        listaSeleccionados()
        state_Search = False
        txtanio.Value = Today.Year
        state_Search = True
        'cmbCodArea.Value = "05"
        listaDatos()
        txtanio.Focus()
    End Sub

    Private Sub frmAgregar_Job_SolGastos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmAgregar_Job_SolGastos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oSolicitudGastoDetService.Close()
            oMaestroService.Close()
            oJobService.Close()
            oPersonaService.close()
        Catch ex As TimeoutException
            oSolicitudGastoDetService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oPersonaService.abort()
        Catch ex As CommunicationException
            oSolicitudGastoDetService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
            oPersonaService.abort()
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

    Private Sub LlenarCombos()
        Try

            '======================================= OFICINAS ===========================================
            dtLocaciones = oMaestroService.MostrarOficinas("").Tables(0)
            dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
            cmbLocacion.DataSource = dtLocaciones
            cmbLocacion.DropDownList.DataMember = dtLocaciones.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.DisplayMember = dtLocaciones.Columns("DesOfi").ToString
            cmbLocacion.DropDownList.ValueMember = dtLocaciones.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("CodOfi").ToString
            cmbLocacion.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("DesOfi").ToString
            cmbLocacion.SelectedIndex = 1
            dtLocaciones = Nothing

            '======================================= TIPOS DE JOB ===========================================
            dtTiposJob = oJobService.MostrarTipo.Tables(0)
            dtTiposJob.Rows.InsertAt(getRowTodos(dtTiposJob), 0)
            cmbTipo.DataSource = dtTiposJob
            cmbTipo.DropDownList.DataMember = dtTiposJob.Columns("AbrTipo").ToString
            cmbTipo.DropDownList.DisplayMember = dtTiposJob.Columns("AbrTipo").ToString
            cmbTipo.DropDownList.ValueMember = dtTiposJob.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(0).DataMember = dtTiposJob.Columns("IdTipoJob").ToString
            cmbTipo.DropDownList.Columns(1).DataMember = dtTiposJob.Columns("AbrTipo").ToString
            cmbTipo.SelectedIndex = 0
            dtTiposJob = Nothing

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, Session.sCodUsu).Tables(0)
            If dtAreas.Rows.Count > 1 Then
                dtAreas.Rows.InsertAt(getRowTodos(dtAreas), 0)
            End If
            cmbCodArea.DataSource = dtAreas
            cmbCodArea.DropDownList.DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbCodArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbCodArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString            
            cmbCodArea.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbCodArea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodArea.ValueChanged
        Try

            '====================================== CENTRO COSTO ===========================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, Session.sCodUsu).Tables(0)
            If dtCentroCosto.Rows.Count > 1 Or cmbCodArea.Value = "" Then
                dtCentroCosto.Rows.InsertAt(getRowTodos(dtCentroCosto), 0)
            End If
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

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtanio.ValueChanged, cmbLocacion.ValueChanged, cmbTipo.ValueChanged, txtcod_job.TextChanged, cmbCentroCosto.ValueChanged
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                '===================================== LISTA JOB ======================================
                'dtJobs = oJobService.FiltrarBuscador(txtanio.Value, cmbLocacion.Value, utils.toNumber(cmbTipo.Value), 0, toBlank(txtcod_job.Text)).Tables(0)
                dtJobs = oJobService.Filtrar(Session.sCodEmp, txtanio.Value, cmbLocacion.Value, utils.toNumber(cmbTipo.Value), 0, "", "", 0, 0, txtcod_job.Text, cmbCodArea.Value, cmbCentroCosto.Value).Tables(0)
                dgvJobs.DataSource = dtJobs
                'DataGridView1.DataSource = dtJobs

                cCodJob.DataPropertyName = dtJobs.Columns("CodJob").ColumnName
                Observacion.DataPropertyName = dtJobs.Columns("Observacion").ColumnName

                EnableOptions()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaSeleccionados()
        Try

            '=================================== LISTA SELECCIONADOS ===================================          
            dtSeleccionados = oSolicitudGastoDetService.MostrarJob(IdGastoDet).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cCodJob1.DataPropertyName = dtSeleccionados.Columns("CodJob").ColumnName            
            cMonto.DataPropertyName = dtSeleccionados.Columns("Monto").ColumnName
            cMontoSinIgv.DataPropertyName = dtSeleccionados.Columns("MontoSinIgv").ColumnName
            cMontoNoAfecto.DataPropertyName = dtSeleccionados.Columns("MontoNoAfecto").ColumnName
            cObservacion.DataPropertyName = dtSeleccionados.Columns("Observacion").ColumnName

            cTotSubTotal.DataPropertyName = dtSeleccionados.Columns("TotSubTotal").ColumnName
            cTotIgv.DataPropertyName = dtSeleccionados.Columns("TotIgv").ColumnName
            cTotNoAfecto.DataPropertyName = dtSeleccionados.Columns("TotNoAfecto").ColumnName
            cTotOtroCargo.DataPropertyName = dtSeleccionados.Columns("TotOtroCargo").ColumnName


            SumarMontos()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS SELECCIONADOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvJobs.RowCount > 0 Then
                btnAgregar.Enabled = True
                btnAgregarTodos.Enabled = True
            Else
                btnAgregar.Enabled = False
                btnAgregarTodos.Enabled = False
            End If

            If dgvSeleccionados.RowCount > 0 Then
                miEliminar.Enabled = True
            Else
                miEliminar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        CodJob = dgvJobs.Rows(dgvJobs.CurrentRow.Index).Cells("cCodJob").Value.ToString
        If ValidarJob(dgvSeleccionados, CodJob) Then
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvJobs)
            EnableOptions()
        Else
            MsgBox("El Job ya fue seleccionado.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            CodJob = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cCodJob").Value.ToString

            dr("CodJob") = CodJob            

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        SumarMontos()
    End Sub

    Private Sub EliminarFila(ByVal dgvDatos As DataGridView)
        dgvDatos.Rows.Remove(dgvDatos.CurrentRow)
        SumarMontos()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvSeleccionados.RowCount < 1 Then
                MsgBox("Debe seleccionar al menos un Job.", MsgBoxStyle.Information, "Información")
                dgvJobs.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        Dim Cont As Integer = 0
        For i As Integer = 0 To dgvJobs.RowCount - 1
            CodJob = dgvJobs.Item("cCodJob".ToLower, i).Value
            If Not (ValidarJob(dgvSeleccionados, CodJob)) Then
                Cont = Cont + 1
            End If
        Next

        If Cont > 1 Then
            MsgBox("Alguno(s) de las OT's ya han sido seleccionados.", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            For i As Integer = 0 To dgvJobs.RowCount - 1
                AgregarFila(dtSeleccionados, dgvSeleccionados, dgvJobs)
            Next
            EnableOptions()
        End If
        SumarMontos()
    End Sub

    Private Function ValidarJob(ByVal dgvDatos As DataGridView, ByVal CodJob As String) As Boolean
        Try
            If dgvDatos.RowCount > 0 Then
                Dim cont As Integer = 0
                For i As Integer = 0 To dgvDatos.RowCount - 1
                    If CodJob = dgvDatos.Item("cCodJob1".ToLower, i).Value Then
                        cont = cont + 1
                    End If
                Next

                If cont > 0 Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error al Validar la OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub miEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        EliminarFila(dgvSeleccionados)
    End Sub

    Private Sub cbProrratear_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProrratear.CheckedChanged
        If dgvSeleccionados.Rows.Count < 1 Then
            MsgBox("Debe seleccionar al menos un Centro de Costo.", MsgBoxStyle.Information, "Información")
            cbProrratear.Checked = False
            dgvJobs.Focus()
        Else
            If cbProrratear.Checked = True Then

                Dim MontoP As Double
                Dim MontoSinIgvP As Double
                Dim MontoNoAfectoP As Double

                Dim SubTotalP As Double
                Dim TotalIgvP As Double
                Dim TotalNoAfectoP As Double
                Dim TotalOtroCargoP As Double

                Dim Cont As Integer = 0

                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    Cont = Cont + 1
                Next

                MontoP = Monto / Cont
                MontoSinIgvP = MontoSinIgv / Cont
                MontoNoAfectoP = MontoNoAfecto / Cont

                SubTotalP = SubTotal / Cont
                TotalIgvP = totalIgv / Cont
                TotalNoAfectoP = totalNoAfecto / Cont
                TotalOtroCargoP = totalOtroCargo / Cont

                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    dgvSeleccionados.Rows(i).Cells("cMonto").Value = MontoP
                    dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value = MontoSinIgvP
                    dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value = MontoNoAfectoP

                    dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value = SubTotalP
                    dgvSeleccionados.Rows(i).Cells("cTotIgv").Value = TotalIgvP
                    dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value = TotalNoAfectoP
                    dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value = TotalOtroCargoP
                Next

            Else
                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    dgvSeleccionados.Rows(i).Cells("cMonto").Value = 0.0
                    dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value = 0.0
                    dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value = 0.0

                    dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value = 0.00
                    dgvSeleccionados.Rows(i).Cells("cTotIgv").Value = 0.00
                    dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value = 0.00
                    dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value = 0.00

                Next
            End If
            SumarMontos()
        End If
    End Sub

    Private Sub SumarMontos()
        Try
            If dgvSeleccionados.Rows.Count > 0 Then
                txtMonto.Value = 0.0
                txtMontoSinIgv.Value = 0.0
                txtMontoNoAfecto.Value = 0.0
                txtMontoTotal.Value = 0.0

                txtSubTotal.Value = 0.0
                txtTotalIgv.Value = 0.0
                txtTotalNoAfecto.Value = 0.0
                txtTotalOtroCargo.Value = 0.00
                txtTotalNeto.Value = 0.0


                Dim MontoAcum As Double = 0
                Dim MontoSinIgvAcum As Double = 0
                Dim MontoNoAfectoAcum As Double = 0

                Dim SubTotalAcum As Double = 0
                Dim TotalIgvAcum As Double = 0
                Dim TotalNoAfectoAcum As Double = 0
                Dim TotalOtroCargoAcum As Double = 0

                Igv = IIf(IdDocumento = 38, 8, Igv)

                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    If AfectoIgv Then
                        If IsDBNull(dgvSeleccionados.Rows(i).Cells("cMonto").Value) Then
                            dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value = 0.0 / ((Igv + 100) / 100)
                            dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value = 0.0
                        Else
                            dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value = (dgvSeleccionados.Rows(i).Cells("cMonto").Value - dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value) / ((Igv + 100) / 100) + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value), 0, dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value)
                            'dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value = dgvSeleccionados.Rows(i).Cells("cMonto").Value / ((Igv + 100) / 100) + dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value
                        End If

                        If IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value) Then
                            dgvSeleccionados.Rows(i).Cells("cTotIgv").Value = 0.00
                            dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value = 0.00
                            dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value = 0.00
                        Else
                            dgvSeleccionados.Rows(i).Cells("cTotIgv").Value = Math.Round(dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value * (Igv / 100), 2)
                        End If

                    Else
                        If IsDBNull(dgvSeleccionados.Rows(i).Cells("cMonto").Value) Then
                            dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value = 0.0
                            dgvSeleccionados.Rows(i).Cells("cMonto").Value = 0.0
                            dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value = 0.0
                        Else
                            dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value = dgvSeleccionados.Rows(i).Cells("cMonto").Value + dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value
                        End If

                        If IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value) Then
                            dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value = 0.00
                            dgvSeleccionados.Rows(i).Cells("cTotIgv").Value = 0.00
                            dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value = 0.00
                            dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value = 0.00
                        Else
                            dgvSeleccionados.Rows(i).Cells("cTotIgv").Value = 0.00
                        End If

                    End If
                Next

                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    MontoAcum = MontoAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMonto").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMonto").Value)
                    MontoSinIgvAcum = MontoSinIgvAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value)
                    MontoNoAfectoAcum = MontoNoAfectoAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value)

                    SubTotalAcum = SubTotalAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value)
                    TotalIgvAcum = TotalIgvAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotIgv").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotIgv").Value)
                    TotalNoAfectoAcum = TotalNoAfectoAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value)
                    TotalOtroCargoAcum = TotalOtroCargoAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value)
                Next

                txtMonto.Value = Math.Round(MontoAcum, 2)
                txtMontoSinIgv.Value = Math.Round(MontoSinIgvAcum, 2)
                txtMontoNoAfecto.Value = Math.Round(MontoNoAfectoAcum, 2)
                txtMontoTotal.Value = Math.Round((txtMonto.Value + txtMontoNoAfecto.Value), 2)

                txtSubTotal.Value = Math.Round(SubTotalAcum, 2)
                txtTotalIgv.Value = Math.Round(TotalIgvAcum, 2)
                txtTotalNoAfecto.Value = Math.Round(TotalNoAfectoAcum, 2)
                txtTotalOtroCargo.Value = Math.Round((TotalOtroCargoAcum), 2)
                txtTotalNeto.Value = Math.Round((txtSubTotal.Value + (txtTotalIgv.Value * IIf(IdDocumento = 38, -1, 1)) + txtTotalNoAfecto.Value + txtTotalOtroCargo.Value), 2)
            Else
                txtMonto.Value = 0.0
                txtMontoSinIgv.Value = 0.0
                txtMontoNoAfecto.Value = 0.0
                txtMontoTotal.Value = 0.0

                txtSubTotal.Value = 0.00
                txtTotalIgv.Value = 0.00
                txtTotalNoAfecto.Value = 0.00
                txtTotalOtroCargo.Value = 0.00
                txtTotalNeto.Value = 0.00
            End If
        Catch ex As Exception
            MsgBox("Error al Sumar Montos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaBalanceMontos() As Boolean
        Try
            Dim ContCero As Integer = 0
            Dim ContCeroIgv As Integer = 0
            'Dim ContCeroNoAfecto As Integer = 0
            'Dim ContCeroOtro As Integer = 0
            For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                'If IsDBNull(dgvSeleccionados.Rows(i).Cells("cMonto").Value) Then
                '    ContCero = ContCero + 1
                'Else
                '    If CDbl(dgvSeleccionados.Rows(i).Cells("cMonto").Value) = 0 Then
                '        ContCero = ContCero + 1
                '    End If
                'End If
                'If IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value) Then
                '    ContCero = ContCero + 1
                'Else
                '    If CDbl(dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value) = 0 Then
                '        ContCero = ContCero + 1
                '    End If
                'End If
                'If IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value) Then
                '    ContCeroNoAfecto = ContCeroNoAfecto + 1
                'Else
                '    If CDbl(dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value) = 0 Then
                '        ContCeroNoAfecto = ContCeroNoAfecto + 1
                '    End If
                'End If


                If IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value) Then
                    ContCero = ContCero + 1
                Else
                    If CDbl(dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value) = 0 Then
                        ContCero = ContCero + 1
                    End If
                End If
                If IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotIgv").Value) Then
                    ContCeroIgv = ContCeroIgv + 1
                Else
                    If CDbl(dgvSeleccionados.Rows(i).Cells("cTotIgv").Value) = 0 Then
                        ContCeroIgv = ContCeroIgv + 1
                    End If
                End If
                'If IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value) Then
                '    ContCeroNoAfecto = ContCeroNoAfecto + 1
                'Else
                '    If CDbl(dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value) = 0 Then
                '        ContCeroNoAfecto = ContCeroNoAfecto + 1
                '    End If
                'End If
                'If IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value) Then
                '    ContCeroOtro = ContCeroOtro + 1
                'Else
                '    If CDbl(dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value) = 0 Then
                '        ContCeroOtro = ContCeroOtro + 1
                '    End If
                'End If

            Next

            'If ContCero > 0 And AfectoIgv = True Then
            '    MsgBox("Los montos ingresados por Job deben ser mayor a cero.", MsgBoxStyle.Information, "Información")
            '    dgvSeleccionados.Focus()
            '    Return False
            '    'ElseIf ContCeroNoAfecto > 0 And AfectoIgv = False Then
            '    '    MsgBox("Los montos no afectos ingresados por Centro de Costo deben ser mayor a cero.", MsgBoxStyle.Information, "Información")
            '    '    dgvSeleccionados.Focus()
            '    '    Return False
            'ElseIf txtMonto.Value <> Math.Round(Monto, 2) Then
            '    MsgBox("Los montos deben ser iguales a los montos de los Centros de Costos de Servicio Técnico.", MsgBoxStyle.Information, "Información")
            '    dgvJobs.Focus()
            '    Return False
            'ElseIf txtMontoSinIgv.Value <> Math.Round(MontoSinIgv, 2) Then
            '    MsgBox("Los montos deben ser iguales a los montos de los Centros de Costos de Servicio Técnico.", MsgBoxStyle.Information, "Información")
            '    dgvJobs.Focus()
            '    Return False
            'ElseIf txtMontoNoAfecto.Value <> Math.Round(MontoNoAfecto, 2) Then
            '    MsgBox("Los montos deben ser iguales a los montos de los Centros de Costos de Servicio Técnico.", MsgBoxStyle.Information, "Información")
            '    dgvJobs.Focus()
            '    Return False
            'ElseIf txtMontoTotal.Value > MontoTotal Then
            '    MsgBox("El monto total no debe ser mayor al monto total del documento.", MsgBoxStyle.Information, "Información")
            '    dgvJobs.Focus()
            '    Return False
            'Else
            '    Return True
            'End If

            If ContCeroIgv > 0 And AfectoIgv = True Then
                MsgBox("Los montos ingresados por Centro de Costo deben ser mayor a cero.", MsgBoxStyle.Information, "Información")
                dgvSeleccionados.Focus()
                Return False
            ElseIf ContCero > 0 And AfectoIgv = True Then
                MsgBox("Los montos no afectos ingresados por Centro de Costo deben ser mayor a cero.", MsgBoxStyle.Information, "Información")
                dgvSeleccionados.Focus()
                Return False

            ElseIf txtSubTotal.Value <> Math.Round(SubTotal, 2) Then
                MsgBox("Los Montos seleccionados deben ser iguales a los Montos del Detalle.", MsgBoxStyle.Information, "Información")
                dgvJobs.Focus()
                Return False
            ElseIf txtTotalIgv.Value <> Math.Round(totalIgv, 2) Then
                MsgBox("Los Montos seleccionados deben ser iguales a los Montos del Detalle.", MsgBoxStyle.Information, "Información")
                dgvJobs.Focus()
                Return False
            ElseIf txtTotalNoAfecto.Value <> Math.Round(totalNoAfecto, 2) Then
                MsgBox("Los Montos seleccionados deben ser iguales a los Montos del Detalle.", MsgBoxStyle.Information, "Información")
                dgvJobs.Focus()
                Return False
            ElseIf txtTotalOtroCargo.Value <> Math.Round(totalOtroCargo, 2) Then
                MsgBox("Los Montos seleccionados deben ser iguales a los Montos del Detalle.", MsgBoxStyle.Information, "Información")
                dgvJobs.Focus()
                Return False
            ElseIf txtTotalNeto.Value <> Math.Round(totalNeto, 2) Then
                MsgBox("Los Montos seleccionados deben ser iguales a los Montos del Detalle.", MsgBoxStyle.Information, "Información")
                dgvJobs.Focus()
                Return False
            Else
                Return True
            End If



        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR BALANCE DE MONTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvSeleccionados_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeleccionados.CellEndEdit

        If e.ColumnIndex <> 6 Then
            SumarMontos()
        Else
            SumarMontos2()
        End If

    End Sub

    Private Sub SumarMontos2()
        Try
            If dgvSeleccionados.Rows.Count > 0 Then
                txtMonto.Value = 0.0
                txtMontoSinIgv.Value = 0.0
                txtMontoNoAfecto.Value = 0.0
                txtMontoTotal.Value = 0.0

                txtSubTotal.Value = 0.0
                txtTotalIgv.Value = 0.0
                txtTotalNoAfecto.Value = 0.0
                txtTotalOtroCargo.Value = 0.00
                txtTotalNeto.Value = 0.0


                Dim MontoAcum As Double = 0
                Dim MontoSinIgvAcum As Double = 0
                Dim MontoNoAfectoAcum As Double = 0

                Dim SubTotalAcum As Double = 0
                Dim TotalIgvAcum As Double = 0
                Dim TotalNoAfectoAcum As Double = 0
                Dim TotalOtroCargoAcum As Double = 0



                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    MontoAcum = MontoAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMonto").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMonto").Value)
                    MontoSinIgvAcum = MontoSinIgvAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value)
                    MontoNoAfectoAcum = MontoNoAfectoAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value)

                    SubTotalAcum = SubTotalAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value)
                    TotalIgvAcum = TotalIgvAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotIgv").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotIgv").Value)
                    TotalNoAfectoAcum = TotalNoAfectoAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value)
                    TotalOtroCargoAcum = TotalOtroCargoAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value)
                Next

                txtMonto.Value = Math.Round(MontoAcum, 2)
                txtMontoSinIgv.Value = Math.Round(MontoSinIgvAcum, 2)
                txtMontoNoAfecto.Value = Math.Round(MontoNoAfectoAcum, 2)
                'txtMontoTotal.Value = Math.Round((txtMonto.Value), 2) 'Math.Round((txtMonto.Value + txtMontoNoAfecto.Value), 2)
                txtMontoTotal.Value = Math.Round((txtMonto.Value + txtMontoNoAfecto.Value), 2)

                txtSubTotal.Value = Math.Round(SubTotalAcum, 2)
                txtTotalIgv.Value = Math.Round(TotalIgvAcum, 2)
                txtTotalNoAfecto.Value = Math.Round(TotalNoAfectoAcum, 2)
                txtTotalOtroCargo.Value = Math.Round((TotalOtroCargoAcum), 2)
                txtTotalNeto.Value = Math.Round((txtSubTotal.Value + (txtTotalIgv.Value * IIf(IdDocumento = 38, -1, 1)) + txtTotalNoAfecto.Value + txtTotalOtroCargo.Value), 2)
            Else
                txtMonto.Value = 0.00
                txtMontoSinIgv.Value = 0.00
                txtMontoNoAfecto.Value = 0.00
                txtMontoTotal.Value = 0.00

                txtSubTotal.Value = 0.00
                txtTotalIgv.Value = 0.00
                txtTotalNoAfecto.Value = 0.00
                txtTotalOtroCargo.Value = 0.00
                txtTotalNeto.Value = 0.00
            End If
        Catch ex As Exception
            MsgBox("Error al Sumar Montos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    If ValidaBalanceMontos() Then
                        dgvSeleccionados.Update()
                        Dim dtTable As New DataTable
                        Dim rows As DataRow

                        dtTable = dtSeleccionados.Copy
                        dtTable.Clear()

                        For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                            rows = dtTable.NewRow
                            rows(0) = 0
                            rows(1) = 0
                            rows(2) = dgvSeleccionados.Rows(i).Cells("cCodJob1").Value
                            rows(3) = dgvSeleccionados.Rows(i).Cells("cMonto").Value
                            rows(4) = dgvSeleccionados.Rows(i).Cells("cMontoSinIgv").Value
                            rows(5) = IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value)
                            rows(6) = dgvSeleccionados.Rows(i).Cells("cObservacion").Value
                            rows(7) = False

                            rows(8) = dgvSeleccionados.Rows(i).Cells("cTotSubTotal").Value
                            rows(9) = IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotIgv").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotIgv").Value)
                            rows(10) = IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotOtroCargo").Value)
                            rows(11) = IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cTotNoAfecto").Value)



                            dtTable.Rows.Add(rows)
                        Next

                        Dim state_process As Boolean
                        state_process = oSolicitudGastoDetService.InsertarJob(IdGastoDet, IdGasto, dtTable, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If state_process = True Then
                            MsgBox("Se insertó la(las) OT(s) Correctamente.")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Else
                            MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class