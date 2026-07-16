Imports System.ServiceModel
Public Class frmUsuarioCentrosCosto

    '===========================Servicios====================================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oPersonaService As New PersonaService.PersonaServiceClient

    '======================Declaración de Variables==============================================
    Private dtAreas As DataTable
    Private dtCentros As DataTable
    Private dtSeleccionados As DataTable

    Private CodCentro As String
    Private DesCentro As String
    Public CodUsu As String

    Private Sub frmUsuarioCentrosCostos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvCentros.BackgroundColor = Color.Beige
        dgvCentros.BackColor = Color.Beige
        dgvCentros.ForeColor = Color.MidnightBlue
        dgvCentros.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False
        llenarCombos()
        cmbCodArea.Value = "01"
    End Sub

    Private Sub frmUsuarioCentrosCostos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmUsuarioCentrosCostos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
            oPersonaService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
            oPersonaService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= AREAS ================================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
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
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try

            '===================================== LISTA CENTROS ======================================
            dtCentros = oPersonaService.MostrarCentroCosto(cmbCodArea.Value, "").Tables(0)
            dgvCentros.DataSource = dtCentros

            cCodCentro.DataPropertyName = dtCentros.Columns("CodCentro").ColumnName
            cDesCentro.DataPropertyName = dtCentros.Columns("DesCentro").ColumnName

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oPersonaService.MostrarCentroCosto("", "").Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cCodCentro1.DataPropertyName = dtSeleccionados.Columns("CodCentro").ColumnName
            cDesCentro1.DataPropertyName = dtSeleccionados.Columns("DesCentro").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvCentros.RowCount > 0 Then
                btnAgregar.Enabled = True
                btnAgregarTodos.Enabled = True
            Else
                btnAgregar.Enabled = False
                btnAgregarTodos.Enabled = False
            End If

            If dgvSeleccionados.RowCount > 0 Then
                btnRegresar.Enabled = True
                btnRegresarTodos.Enabled = True
            Else
                btnRegresar.Enabled = False
                btnRegresarTodos.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR OPCIONES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        CodCentro = dgvCentros.Rows(dgvCentros.CurrentRow.Index).Cells("cCodCentro").Value.ToString
        If oSeguridadService.BuscarCentroCosto(CodUsu, CodCentro) Then
            MsgBox("El Centro de Costo Seleccionado ya ha sido asignado al usuario", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvCentros)
            EnableOptions()
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
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        DesagregarFila(dtCentros, dgvCentros, dgvSeleccionados)
        EnableOptions()
    End Sub

    Private Sub DesagregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            CodCentro = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cCodCentro1").Value.ToString
            DesCentro = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesCentro1").Value.ToString

            dr("CodCentro") = CodCentro
            dr("DesCentro") = DesCentro

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        Dim Cont As Integer = 0         'Cantidad de Locaciones que ya estan asignadas al usuario
        For i As Integer = 0 To dgvCentros.RowCount - 1
            CodCentro = dgvCentros.Rows(dgvCentros.CurrentRow.Index).Cells("cCodCentro").Value.ToString
            If oSeguridadService.BuscarCentroCosto(CodUsu, CodCentro) Then
                Cont = Cont + 1
            End If
        Next

        If Cont > 1 Then
            MsgBox("Alguno(s) de los Centros de Costo seleccionados ya han sido asignados al usuario ", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            For i As Integer = 0 To dgvCentros.RowCount - 1
                AgregarFila(dtSeleccionados, dgvSeleccionados, dgvCentros)
            Next
            EnableOptions()
        End If
    End Sub

    Private Sub btnRegresarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresarTodos.Click
        For i As Integer = 0 To dgvSeleccionados.RowCount - 1
            DesagregarFila(dtCentros, dgvCentros, dgvSeleccionados)
        Next
        EnableOptions()
    End Sub

    Private Sub EliminarFila(ByVal dgvDatos As DataGridView)
        dgvDatos.Rows.Remove(dgvDatos.CurrentRow)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvSeleccionados.RowCount < 1 Then
                MsgBox("Debe seleccionar al menos un centro de costo.", MsgBoxStyle.Information, "Información")
                dgvCentros.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Está seguro de ASIGNAR los centros de costo seleccionados al usuario: " & CodUsu & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim estado_process As Boolean
                    For Each fila As DataRow In dtSeleccionados.Rows
                        estado_process = oSeguridadService.InsertarCentroCosto(CodUsu, fila.Item("CodCentro"))
                    Next

                    If estado_process Then
                        MsgBox("Se agregó correctamente los centros de costo")
                        dtSeleccionados.Clear()
                        llenarCombos()
                        listaDatos()
                        'Me.DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR CENTRO(S) DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class