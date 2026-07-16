Imports System.ServiceModel
Public Class frmReciboHonorario_AgregarCC

    '===========================Servicios====================================================
    Private oReciboHonorarioDetService As New ReciboHonorarioDetService.ReciboHonorarioDetServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================================
    Private dtArea As DataTable

    Private dtSeleccionados As DataTable
    Private dtCentroCosto As DataTable

    Public IdHonorario As Integer
    Public IdHonorarioDet As Integer

    Public MontoSoles As Double
    Public MontoIRSol As Double
    Public TotalSoles As Double

    Public MontoDolares As Double
    Public MontoIRDol As Double
    Public TotalDolares As Double

    Private CodCentro As String
    Private DesCentro As String

    Private Sub frmReciboHonorario_AgregarCC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oReciboHonorarioDetService.Close()
            oMaestroService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oReciboHonorarioDetService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oReciboHonorarioDetService.Abort()
            oMaestroService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub frmReciboHonorario_AgregarCC_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmReciboHonorario_AgregarCC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        cmbArea.Focus()
    End Sub

    Private Sub listaSeleccionados()
        Try

            '=================================== LISTA SELECCIONADOS ===================================          
            dtSeleccionados = oReciboHonorarioDetService.MostrarCentroCosto(IdHonorarioDet).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cCodCentro1.DataPropertyName = dtSeleccionados.Columns("CodCentro").ColumnName
            cDesCentro1.DataPropertyName = dtSeleccionados.Columns("DesCentro").ColumnName
            cMontoSol.DataPropertyName = dtSeleccionados.Columns("MontoSol").ColumnName
            cMontoIRSol.DataPropertyName = dtSeleccionados.Columns("MontoIRSol").ColumnName
            cMontoDol.DataPropertyName = dtSeleccionados.Columns("MontoDol").ColumnName
            cMontoIRDol.DataPropertyName = dtSeleccionados.Columns("MontoIRDol").ColumnName
            cObservacion.DataPropertyName = dtSeleccionados.Columns("Observacion").ColumnName

            SumarMontos()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS SELECCIONADOS: " + ex.Message, MsgBoxStyle.Exclamation)
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

            '======================================== AREAS ================================================
            dtArea = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            cmbArea.DataSource = dtArea
            cmbArea.DropDownList.DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtArea.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtArea.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtArea.Columns("DesArea").ToString
            cmbArea.SelectedIndex = 0
            dtArea = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try

            '===================================== LISTA PERSONAL ======================================
            dtCentroCosto = oPersonaService.MostrarCentroCosto(cmbArea.Value, "").Tables(0)
            dgvCentroCosto.DataSource = dtCentroCosto

            cCodCentro.DataPropertyName = dtCentroCosto.Columns("CodCentro").ColumnName
            cDesCentro.DataPropertyName = dtCentroCosto.Columns("DesCentro").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
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

    Private Sub btnAgregarTodos_Click(sender As Object, e As EventArgs) Handles btnAgregarTodos.Click
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

    Private Function ValidarCentroCosto(ByVal dgvDatos As DataGridView, ByVal IdGastoDet As Integer) As Boolean
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

    Private Sub miEliminar_Click(sender As Object, e As EventArgs) Handles miEliminar.Click
        EliminarFila(dgvSeleccionados)
    End Sub

    Private Sub cbProrratear_CheckedChanged(sender As Object, e As EventArgs) Handles cbProrratear.CheckedChanged
        If dgvSeleccionados.Rows.Count < 1 Then
            MsgBox("Debe seleccionar al menos un Centro de Costo.", MsgBoxStyle.Information, "Información")
            cbProrratear.Checked = False
            dgvCentroCosto.Focus()
        Else
            If cbProrratear.Checked = True Then

                Dim MontoPSol As Double
                Dim MontoPIRSol As Double

                Dim MontoPDol As Double
                Dim MontoPIRDol As Double
                Dim Cont As Integer = 0

                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    Cont = Cont + 1
                Next

                MontoPSol = MontoSoles / Cont
                MontoPIRSol = MontoIRSol / Cont

                MontoPDol = MontoDolares / Cont
                MontoPIRDol = MontoIRDol / Cont

                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    dgvSeleccionados.Rows(i).Cells("cMontoSol").Value = MontoPSol
                    dgvSeleccionados.Rows(i).Cells("cMontoIRSol").Value = MontoPIRSol

                    dgvSeleccionados.Rows(i).Cells("cMontoDol").Value = MontoPDol
                    dgvSeleccionados.Rows(i).Cells("cMontoIRDol").Value = MontoPIRDol
                Next

            Else
                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    dgvSeleccionados.Rows(i).Cells("cMontoSol").Value = 0.0
                    dgvSeleccionados.Rows(i).Cells("cMontoIRSol").Value = 0.0

                    dgvSeleccionados.Rows(i).Cells("cMontoDol").Value = 0.0
                    dgvSeleccionados.Rows(i).Cells("cMontoIRDol").Value = 0.0
                Next
            End If
            SumarMontos()
        End If
    End Sub

    Private Sub SumarMontos()
        Try
            If dgvSeleccionados.Rows.Count > 0 Then
                txtMontoSoles.Value = 0.0
                txtMontoIRSol.Value = 0.0

                txtMontoDolares.Value = 0.0
                txtMontoIRDol.Value = 0.0

                Dim MontoSolesAcum As Double = 0
                Dim MontoIRSolAcum As Double = 0

                Dim MontoDolaresAcum As Double = 0
                Dim MontoIRDolAcum As Double = 0

                For i As Integer = 0 To dgvSeleccionados.RowCount - 1
                    MontoSolesAcum = MontoSolesAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoSol").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMontoSol").Value)
                    MontoIRSolAcum = MontoIRSolAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoIRSol").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMontoIRSol").Value)

                    MontoDolaresAcum = MontoDolaresAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoDol").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMontoDol").Value)
                    MontoIRDolAcum = MontoIRDolAcum + IIf(IsDBNull(dgvSeleccionados.Rows(i).Cells("cMontoIRDol").Value), 0.0, dgvSeleccionados.Rows(i).Cells("cMontoIRDol").Value)
                Next

                txtMontoSoles.Value = Math.Round(MontoSolesAcum, 2)
                txtMontoIRSol.Value = Math.Round(MontoIRSolAcum, 2)
                txtMontoTotalSol.Value = Math.Round((txtMontoSoles.Value - txtMontoIRSol.Value), 2)

                txtMontoDolares.Value = Math.Round(MontoDolaresAcum, 2)
                txtMontoIRDol.Value = Math.Round(MontoIRDolAcum, 2)
                txtMontoTotalDol.Value = Math.Round((txtMontoDolares.Value - txtMontoIRDol.Value), 2)
            Else
                txtMontoSoles.Value = 0.0
                txtMontoIRSol.Value = 0.0
                txtMontoTotalSol.Value = 0.0

                txtMontoDolares.Value = 0.0
                txtMontoIRDol.Value = 0.0
                txtMontoTotalDol.Value = 0.0
            End If
        Catch ex As Exception
            MsgBox("Error al Sumar Montos: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaBalanceMontos() As Boolean
        Try
            If txtMontoSoles.Value <> MontoSoles Or txtMontoDolares.Value <> MontoDolares Then
                MsgBox("Los Montos seleccionados deben ser iguales a los Montos del Detalle.", MsgBoxStyle.Information, "Información")
                dgvCentroCosto.Focus()
                Return False
            ElseIf txtMontoIRSol.Value <> MontoIRSol Or txtMontoIRDol.Value <> MontoIRDol Then
                MsgBox("Los Montos seleccionados deben ser iguales a los Montos del Detalle.", MsgBoxStyle.Information, "Información")
                dgvCentroCosto.Focus()
                Return False
            ElseIf txtMontoTotalSol.Value <> TotalSoles Or txtMontoTotalDol.Value <> TotalDolares Then
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

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
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
                            rows(2) = ""
                            rows(3) = ""
                            rows(4) = dgvSeleccionados.Rows(i).Cells(0).Value
                            rows(5) = dgvSeleccionados.Rows(i).Cells(1).Value
                            rows(6) = dgvSeleccionados.Rows(i).Cells(2).Value
                            rows(7) = dgvSeleccionados.Rows(i).Cells(3).Value
                            rows(8) = dgvSeleccionados.Rows(i).Cells(4).Value
                            rows(9) = dgvSeleccionados.Rows(i).Cells(5).Value
                            rows(10) = dgvSeleccionados.Rows(i).Cells(6).Value

                            dtTable.Rows.Add(rows)
                        Next

                        Dim state_process As Boolean
                        state_process = oReciboHonorarioDetService.InsertarCentroCosto(IdHonorarioDet, IdHonorario, dtTable, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

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