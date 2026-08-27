Imports System.ServiceModel
Public Class frmAgregar_CentroCosto_OCompra

    '===========================Servicios====================================================
    Private oOrdenesCompraDetService As New OrdenesCompraDetService.OrdenesCompraDetServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================================
    Private dtAreas As DataTable
    Private dtUnidades As DataTable

    Private dtSeleccionados As DataTable
    Private dtCentroCosto As DataTable

    Public IdOrdenDoc As Integer

    Public Monto As Double
    Public MontoNoAfecto As Double
    Public MontoTotal As Double

    Private CodCentro As String
    Private DesCentro As String

    Private Sub frmAgregar_CentroCosto_OCompra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvCentroCosto.BackgroundColor = Color.Beige
        dgvCentroCosto.BackColor = Color.Beige
        dgvCentroCosto.ForeColor = Color.MidnightBlue
        dgvCentroCosto.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False

        LlenarCombos()
        listaSeleccionados()
        listaDatos()
        cmbUnidad.Focus()
    End Sub

    Private Sub frmAgregar_CentroCosto_OCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmAgregar_CentroCosto_OCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oOrdenesCompraDetService.Close()
            oCentroCostoService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraDetService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraDetService.Abort()
            oCentroCostoService.Abort()
            oPersonaService.Abort()
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

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbUnidad_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbUnidad.ValueChanged
        Try

            '======================================= AREA ===============================================
            dtAreas = oCentroCostoService.MostrarAreas(Session.sCodEmp, toNumber(cmbUnidad.Value), Session.sCodUsu).Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtAreas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbArea.ValueChanged
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try

            '=============================== LISTA CENTRO DE COSTO ================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, Session.sCodUsu).Tables(0)
            dgvCentroCosto.DataSource = dtCentroCosto

            cCodCentro.DataPropertyName = dtCentroCosto.Columns("CodCentro").ColumnName
            cDesCentro.DataPropertyName = dtCentroCosto.Columns("DesCentro").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaSeleccionados()
        Try

            '=================================== LISTA SELECCIONADOS ===================================          
            dtSeleccionados = oOrdenesCompraDetService.MostrarCentroCosto(IdOrdenDoc).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cCodCentro1.DataPropertyName = dtSeleccionados.Columns("CodCentro").ColumnName
            cDesCentro1.DataPropertyName = dtSeleccionados.Columns("DesCentro").ColumnName
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
            If dgvCentroCosto.RowCount > 0 Then
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
        CodCentro = dgvCentroCosto.Rows(dgvCentroCosto.CurrentRow.Index).Cells("cCodCentro").Value.ToString
        If ValidarCentroCosto(dgvSeleccionados, CodCentro) Then
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvCentroCosto)
            EnableOptions()
        Else
            MsgBox("El Centro de Costo ya fue seleccionado.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            CodCentro = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cCodCentro").Value.ToString
            DesCentro = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesCentro").Value.ToString

            dr("CodCentro") = CodCentro
            dr("DesCentro") = DesCentro

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
                MsgBox("Debe seleccionar al menos un Centro de Costo.", MsgBoxStyle.Information, "Información")
                dgvCentroCosto.Focus()
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
        For i As Integer = 0 To dgvCentroCosto.RowCount - 1
            CodCentro = dgvCentroCosto.Item("cCodCentro".ToLower, i).Value
            If Not (ValidarCentroCosto(dgvSeleccionados, CodCentro)) Then
                Cont = Cont + 1
            End If
        Next

        If Cont > 1 Then
            MsgBox("Alguno(s) de los Centros de Costo ya han sido seleccionados.", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            For i As Integer = 0 To dgvCentroCosto.RowCount - 1
                AgregarFila(dtSeleccionados, dgvSeleccionados, dgvCentroCosto)
            Next
            EnableOptions()
        End If
        SumarMontos()
    End Sub

    Private Function ValidarCentroCosto(ByVal dgvDatos As DataGridView, ByVal CodCentro As String) As Boolean
        Try
            If dgvDatos.RowCount > 0 Then
                Dim cont As Integer = 0
                For i As Integer = 0 To dgvDatos.RowCount - 1
                    If CodCentro = dgvDatos.Item("cCodCentro1".ToLower, i).Value Then
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
            MsgBox("Error al Validar Centro de Costo: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub miEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        EliminarFila(dgvSeleccionados)
    End Sub

    Private Sub cbProrratear_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProrratear.CheckedChanged
        If dgvSeleccionados.Rows.Count < 1 Then
            MsgBox("Debe seleccionar al menos un Centro de Costo.", MsgBoxStyle.Information, "Información")
            cbProrratear.Checked = False
            dgvCentroCosto.Focus()
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
                MsgBox("Los montos ingresados por Centro de Costo deben ser mayor a cero.", MsgBoxStyle.Information, "Información")
                dgvSeleccionados.Focus()
                Return False
            ElseIf txtMonto.Value <> Monto Then
                MsgBox("Los Montos seleccionados deben ser iguales a los Montos del Detalle.", MsgBoxStyle.Information, "Información")
                dgvCentroCosto.Focus()
                Return False
            ElseIf txtMontoNoAfecto.Value <> MontoNoAfecto Then
                MsgBox("Los Montos seleccionados deben ser iguales a los Montos del Detalle.", MsgBoxStyle.Information, "Información")
                dgvCentroCosto.Focus()
                Return False
            ElseIf txtMontoTotal.Value <> MontoTotal Then
                MsgBox("Los Montos seleccionados deben ser iguales a los Montos del Detalle.", MsgBoxStyle.Information, "Información")
                dgvCentroCosto.Focus()
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
                            rows(1) = dgvSeleccionados.Rows(i).Cells("cCodCentro1").Value
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
                            rows(9) = ""
                            rows(10) = dgvSeleccionados.Rows(i).Cells("cDesCentro1").Value

                            dtTable.Rows.Add(rows)
                        Next

                        Dim state_process As Boolean
                        state_process = oOrdenesCompraDetService.InsertarCentroCosto(IdOrdenDoc, dtTable, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        If state_process = True Then
                            MsgBox("Se insertó el(los) Centro(s) de Costo Correctamente.")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Else
                            MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CENTROS DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class