Imports System.ServiceModel
Public Class frmAgregar_Job_OCompra

    '===========================Servicios====================================================
    Private oOrdenesCompraDetService As New OrdenesCompraDetService.OrdenesCompraDetServiceClient
    Private oJobService As New JobService.JobServiceClient
    Private oMaestroService As New MaestroService.MaestroClient

    '======================Declaración de Variables==============================================
    Private dtSeleccionados As DataTable
    Private dtJobs As DataTable

    Public IdOrdenDoc As Integer

    Public Monto As Double
    Public MontoNoAfecto As Double
    Public MontoTotal As Double

    Private CodJob As String

    Private dtLocaciones As DataTable
    Private dtTiposJob As DataTable
    Private state_Search As Boolean

    Private Sub frmAgregar_Job_OCompra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        listaDatos()
        txtanio.Focus()
    End Sub

    Private Sub frmAgregar_Job_OCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmAgregar_Job_OCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oOrdenesCompraDetService.Close()
            oMaestroService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraDetService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraDetService.Abort()
            oMaestroService.Abort()
            oJobService.Abort()
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

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, txtanio.ValueChanged, cmbLocacion.ValueChanged, cmbTipo.ValueChanged, txtcod_job.TextChanged
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                '===================================== LISTA JOB ======================================
                dtJobs = oJobService.FiltrarBuscador(Session.sCodEmp, txtanio.Value, cmbLocacion.Value, utils.toNumber(cmbTipo.Value), 0, toBlank(txtcod_job.Text)).Tables(0)
                dgvJobs.DataSource = dtJobs

                cCodJob.DataPropertyName = dtJobs.Columns("CodJob").ColumnName

                EnableOptions()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaSeleccionados()
        Try

            '=================================== LISTA SELECCIONADOS ===================================          
            dtSeleccionados = oOrdenesCompraDetService.MostrarJob(IdOrdenDoc).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cCodJob1.DataPropertyName = dtSeleccionados.Columns("CodJob").ColumnName
            cMonto.DataPropertyName = dtSeleccionados.Columns("Monto").ColumnName
            cMontoNoAfecto.DataPropertyName = dtSeleccionados.Columns("MontoNoAfecto").ColumnName
            cObservacion.DataPropertyName = dtSeleccionados.Columns("Observacion").ColumnName

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
            MsgBox("La OT ya fue seleccionada.", MsgBoxStyle.Exclamation)
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
                MsgBox("Debe seleccionar al menos una OT.", MsgBoxStyle.Information, "Información")
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
            MsgBox("Alguno(s) de los Job's ya han sido seleccionados.", MsgBoxStyle.Exclamation, "Error de Datos")
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
                Dim MontoNoAfectoP As Double

                Dim Cont As Integer = 0

                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    Cont = Cont + 1
                Next

                MontoP = Monto / Cont
                MontoNoAfectoP = MontoNoAfecto / Cont

                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    dgvSeleccionados.Rows(i).Cells("cMonto").Value = MontoP
                    dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value = MontoNoAfectoP
                Next

            Else
                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    dgvSeleccionados.Rows(i).Cells("cMonto").Value = 0.0
                    dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value = 0.0
                Next
            End If
            SumarMontos()
        End If
    End Sub

    Private Sub SumarMontos()
        Try
            If dgvSeleccionados.Rows.Count > 0 Then
                txtMonto.Value = 0.0
                txtMontoNoAfecto.Value = 0.0
                txtMontoTotal.Value = 0.0

                Dim MontoAcum As Double = 0
                Dim MontoNoAfectoAcum As Double = 0

                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    MontoAcum = MontoAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMonto").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMonto").Value)
                    MontoNoAfectoAcum = MontoNoAfectoAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value)
                Next

                txtMonto.Value = Math.Round(MontoAcum, 2)
                txtMontoNoAfecto.Value = Math.Round(MontoNoAfectoAcum, 2)
                txtMontoTotal.Value = Math.Round((txtMonto.Value + txtMontoNoAfecto.Value), 2)

            Else
                txtMonto.Value = 0.0
                txtMontoNoAfecto.Value = 0.0
                txtMontoTotal.Value = 0.0
            End If
        Catch ex As Exception
            MsgBox("Error al Sumar Montos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaBalanceMontos() As Boolean
        Try
            Dim ContCero As Integer = 0
            For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                If IsDBNull(dgvSeleccionados.Rows(i).Cells("cMonto").Value) Then
                    ContCero = ContCero + 1
                Else
                    If CDbl(dgvSeleccionados.Rows(i).Cells("cMonto").Value) = 0 Then
                        ContCero = ContCero + 1
                    End If
                End If
            Next

            If ContCero > 0 Then
                MsgBox("Los montos ingresados por OT deben ser mayor a cero.", MsgBoxStyle.Information, "Información")
                dgvSeleccionados.Focus()
                Return False
            ElseIf txtMonto.Value <> Math.Round(Monto, 2) Then
                MsgBox("Los montos deben ser iguales a los montos de los Centros de Costos de Servicio Técnico.", MsgBoxStyle.Information, "Información")
                dgvJobs.Focus()
                Return False       
            ElseIf txtMontoNoAfecto.Value <> Math.Round(MontoNoAfecto, 2) Then
                MsgBox("Los montos deben ser iguales a los montos de los Centros de Costos de Servicio Técnico.", MsgBoxStyle.Information, "Información")
                dgvJobs.Focus()
                Return False
            ElseIf txtMontoTotal.Value > MontoTotal Then
                MsgBox("El monto total no debe ser mayor al monto total del documento.", MsgBoxStyle.Information, "Información")
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
        SumarMontos()
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
                            rows(1) = dgvSeleccionados.Rows(i).Cells("cCodJob1").Value
                            If IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value) Then
                                rows(2) = 0
                            Else
                                rows(2) = dgvSeleccionados.Rows(i).Cells("cMontoNoAfecto").Value
                            End If
                            rows(3) = dgvSeleccionados.Rows(i).Cells("cMonto").Value
                            rows(4) = dgvSeleccionados.Rows(i).Cells("cObservacion").Value
                            rows(5) = Today
                            rows(6) = Session.sCodUsu
                            rows(7) = Session.sNomPc
                            rows(8) = Session.sDirIp

                            dtTable.Rows.Add(rows)
                        Next

                        Dim state_process As Boolean
                        state_process = oOrdenesCompraDetService.InsertarJob(IdOrdenDoc, dtTable, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

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