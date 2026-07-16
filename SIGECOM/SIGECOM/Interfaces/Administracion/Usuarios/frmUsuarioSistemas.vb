Imports System.ServiceModel
Public Class frmUsuarioSistemas

    '===========================Servicios====================================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtSistemas As DataTable
    Private dtSeleccionados As DataTable

    Private IdSistema As Integer
    Private NomSis As String
    Public CodUsu As String

    Private Sub frmUsuarioSistemas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSistemas.BackgroundColor = Color.Beige
        dgvSistemas.BackColor = Color.Beige
        dgvSistemas.ForeColor = Color.MidnightBlue
        dgvSistemas.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False
        listaDatos()
    End Sub

    Private Sub frmUsuarioSistemas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmUsuarioSistemas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub listaDatos()
        Try

            '===================================== LISTA SISTEMAS ======================================
            dtSistemas = oSeguridadService.MostrarSistemas().Tables(0)
            dgvSistemas.DataSource = dtSistemas

            cIdSistema.DataPropertyName = dtSistemas.Columns("IdSistema").ColumnName
            cNomSis.DataPropertyName = dtSistemas.Columns("NomSis").ColumnName

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oSeguridadService.MostrarUsuarioSistema("").Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdSistema1.DataPropertyName = dtSeleccionados.Columns("IdSistema").ColumnName
            cNomSis1.DataPropertyName = dtSeleccionados.Columns("NomSis").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvSistemas.RowCount > 0 Then
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
        IdSistema = dgvSistemas.Rows(dgvSistemas.CurrentRow.Index).Cells("cIdSistema").Value.ToString
        If oSeguridadService.BuscarUsuarioSistema(CodUsu, IdSistema) Then
            MsgBox("El Sistema Seleccionado ya ha sido asignado al usuario", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvSistemas)
            EnableOptions()
        End If
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdSistema = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdSistema").Value.ToString
            NomSis = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNomSis").Value.ToString

            dr("IdSistema") = IdSistema
            dr("NomSis") = NomSis

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        DesagregarFila(dtSistemas, dgvSistemas, dgvSeleccionados)
        EnableOptions()
    End Sub

    Private Sub DesagregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdSistema = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdSistema1").Value.ToString
            NomSis = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cNomSis1").Value.ToString

            dr("IdSistema") = IdSistema
            dr("NomSis") = NomSis

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        Dim Cont As Integer = 0         'Cantidad de Sistemas que ya estan asignadas al usuario
        For i As Integer = 0 To dgvSistemas.RowCount - 1
            IdSistema = dgvSistemas.Rows(dgvSistemas.CurrentRow.Index).Cells("cIdSistema").Value.ToString
            If oSeguridadService.BuscarUsuarioSistema(CodUsu, IdSistema) Then
                Cont = Cont + 1
            End If
        Next

        If Cont > 1 Then
            MsgBox("Alguno(s) de los Sistemas seleccionados ya han sido asignados al usuario ", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            For i As Integer = 0 To dgvSistemas.RowCount - 1
                AgregarFila(dtSeleccionados, dgvSeleccionados, dgvSistemas)
            Next
            EnableOptions()
        End If
    End Sub

    Private Sub btnRegresarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresarTodos.Click
        For i As Integer = 0 To dgvSeleccionados.RowCount - 1
            DesagregarFila(dtSistemas, dgvSistemas, dgvSeleccionados)
        Next
        EnableOptions()
    End Sub

    Private Sub EliminarFila(ByVal dgvDatos As DataGridView)
        dgvDatos.Rows.Remove(dgvDatos.CurrentRow)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If dgvSeleccionados.RowCount < 1 Then
                MsgBox("Debe seleccionar al menos un Sistema.", MsgBoxStyle.Information, "Información")
                dgvSistemas.Focus()
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
            If MsgBox("¿Está seguro de ASIGNAR los sistemas seleccionados al usuario: " & CodUsu & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim estado_process As Boolean
                    For Each fila As DataRow In dtSeleccionados.Rows
                        estado_process = oSeguridadService.InsertarUsuarioSistema(CodUsu, fila.Item("IdSistema"))
                    Next

                    If estado_process Then
                        MsgBox("Se agregó correctamente los sistemas")
                        dtSeleccionados.Clear()
                        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        listaDatos()
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR SISTEMA(S): " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class