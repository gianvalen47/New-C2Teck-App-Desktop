Imports System.ServiceModel
Public Class frmUsuarioRubrosRecursos

    '===========================Servicios====================================================
    Private oRecursoService As New RecursoService.RecursoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================   
    Private dtRubros As DataTable
    Private dtSeleccionados As DataTable

    Private IdRubro As Integer
    Private DesRubro As String
    Public CodUsu As String

    Private Sub frmUsuarioRubrosRecursos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvRubros.BackgroundColor = Color.Beige
        dgvRubros.BackColor = Color.Beige
        dgvRubros.ForeColor = Color.MidnightBlue
        dgvRubros.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False
        listaDatos()
    End Sub

    Private Sub frmUsuarioRubrosRecursos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmUsuarioRubrosRecursos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRecursoService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oRecursoService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oRecursoService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            '===================================== LISTA RUBROS ======================================
            dtRubros = oRecursoService.MostrarRubros("").Tables(0)
            dgvRubros.DataSource = dtRubros

            cIdRubro.DataPropertyName = dtRubros.Columns("IdRubro").ColumnName
            cDesRubro.DataPropertyName = dtRubros.Columns("DesRubro").ColumnName

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oSeguridadService.MostrarRubroRecurso("").Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdRubro1.DataPropertyName = dtSeleccionados.Columns("IdRubro").ColumnName
            cDesRubro1.DataPropertyName = dtSeleccionados.Columns("DesRubro").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvRubros.RowCount > 0 Then
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
        IdRubro = dgvRubros.Rows(dgvRubros.CurrentRow.Index).Cells("cIdRubro").Value.ToString
        If oSeguridadService.BuscarRubroRecurso(CodUsu, IdRubro) Then
            MsgBox("El Rubro Seleccionado ya ha sido asignado al usuario", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvRubros)
            EnableOptions()
        End If
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdRubro = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdRubro").Value.ToString
            DesRubro = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesRubro").Value.ToString

            dr("IdRubro") = IdRubro
            dr("DesRubro") = DesRubro

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        DesagregarFila(dtRubros, dgvRubros, dgvSeleccionados)
        EnableOptions()
    End Sub

    Private Sub DesagregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdRubro = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdRubro1").Value.ToString
            DesRubro = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesRubro1").Value.ToString

            dr("IdRubro") = IdRubro
            dr("DesRubro") = DesRubro

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        Dim Cont As Integer = 0         'Cantidad de Sistemas que ya estan asignadas al usuario
        For i As Integer = 0 To dgvRubros.RowCount - 1
            IdRubro = dgvRubros.Rows(dgvRubros.CurrentRow.Index).Cells("cIdRubro").Value.ToString
            If oSeguridadService.BuscarRubroRecurso(CodUsu, IdRubro) Then
                Cont = Cont + 1
            End If
        Next

        If Cont > 1 Then
            MsgBox("Alguno(s) de los Rubros seleccionados ya han sido asignados al usuario ", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            For i As Integer = 0 To dgvRubros.RowCount - 1
                AgregarFila(dtSeleccionados, dgvSeleccionados, dgvRubros)
            Next
            EnableOptions()
        End If
    End Sub

    Private Sub btnRegresarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresarTodos.Click
        For i As Integer = 0 To dgvSeleccionados.RowCount - 1
            DesagregarFila(dtRubros, dgvRubros, dgvSeleccionados)
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
                MsgBox("Debe seleccionar al menos un Rubro.", MsgBoxStyle.Information, "Información")
                dgvRubros.Focus()
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
            If MsgBox("¿Está seguro de ASIGNAR los rubros seleccionados al usuario: " & CodUsu & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim estado_process As Boolean
                    For Each fila As DataRow In dtSeleccionados.Rows
                        estado_process = oSeguridadService.InsertarRubroRecurso(CodUsu, fila.Item("IdRubro"))
                    Next

                    If estado_process Then
                        MsgBox("Se agregó correctamente los rubros")
                        dtSeleccionados.Clear()
                        'Me.DialogResult = Windows.Forms.DialogResult.OK
                        listaDatos()
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR RUBRO(S): " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class