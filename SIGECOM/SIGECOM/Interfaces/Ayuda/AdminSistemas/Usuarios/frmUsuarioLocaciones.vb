Imports System.ServiceModel
Public Class frmUsuarioLocaciones

    '===========================Servicios====================================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtOficinas As DataTable
    Private dtLocaciones As DataTable
    Private dtSeleccionados As DataTable

    Private IdLocacion As Integer
    Private DesAlm As String
    Public CodUsu As String

    Private Sub frmUsuarioLocaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvLocaciones.BackgroundColor = Color.Beige
        dgvLocaciones.BackColor = Color.Beige
        dgvLocaciones.ForeColor = Color.MidnightBlue
        dgvLocaciones.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False
        llenarCombos()
        cmdOficina.Value = "01"
    End Sub

    Private Sub frmUsuarioLocaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmUsuarioLocaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub llenarCombos()
        Try

            '======================================== OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas("").Tables(0)
            cmdOficina.DataSource = dtOficinas
            cmdOficina.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmdOficina.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmdOficina.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmdOficina.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmdOficina.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmdOficina.SelectedIndex = 0
            dtOficinas = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmdLocacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOficina.ValueChanged
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try

            '===================================== LISTA LOCACIONES ======================================
            dtLocaciones = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmdOficina.Value, "").Tables(0)
            dgvLocaciones.DataSource = dtLocaciones

            cIdLocacion.DataPropertyName = dtLocaciones.Columns("IdLocacion").ColumnName
            cDesAlm.DataPropertyName = dtLocaciones.Columns("DesAlm").ColumnName

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oMaestroService.MostrarLocaciones("", "", "").Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdLocacion1.DataPropertyName = dtSeleccionados.Columns("IdLocacion").ColumnName
            cDesAlm1.DataPropertyName = dtSeleccionados.Columns("DesAlm").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvLocaciones.RowCount > 0 Then
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
        IdLocacion = dgvLocaciones.Rows(dgvLocaciones.CurrentRow.Index).Cells("cIdLocacion").Value.ToString
        If oSeguridadService.BuscarLocacionUsuario(CodUsu, IdLocacion) Then
            MsgBox("La Locación Seleccionada ya ha sido asignada al usuario", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvLocaciones)
            EnableOptions()
        End If
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdLocacion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdLocacion").Value.ToString
            DesAlm = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesAlm").Value.ToString

            dr("IdLocacion") = IdLocacion
            dr("DesAlm") = DesAlm

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        DesagregarFila(dtLocaciones, dgvLocaciones, dgvSeleccionados)
        EnableOptions()
    End Sub

    Private Sub DesagregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdLocacion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdLocacion1").Value.ToString
            DesAlm = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesAlm1").Value.ToString

            dr("IdLocacion") = IdLocacion
            dr("DesAlm") = DesAlm

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        Dim Cont As Integer = 0         'Cantidad de Locaciones que ya estan asignadas al usuario
        For i As Integer = 0 To dgvLocaciones.RowCount - 1
            IdLocacion = dgvLocaciones.Rows(dgvLocaciones.CurrentRow.Index).Cells("cIdLocacion").Value.ToString
            If oSeguridadService.BuscarLocacionUsuario(CodUsu, IdLocacion) Then
                Cont = Cont + 1
            End If
        Next

        If Cont > 1 Then
            MsgBox("Alguna(s) de las Locaciones seleccionadas ya han sido asignadas al usuario ", MsgBoxStyle.Exclamation, "Error de Datos")
        Else
            For i As Integer = 0 To dgvLocaciones.RowCount - 1
                AgregarFila(dtSeleccionados, dgvSeleccionados, dgvLocaciones)
            Next
            EnableOptions()
        End If     
    End Sub

    Private Sub btnRegresarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresarTodos.Click
        For i As Integer = 0 To dgvSeleccionados.RowCount - 1
            DesagregarFila(dtLocaciones, dgvLocaciones, dgvSeleccionados)
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
                MsgBox("Debe seleccionar al menos una locación.", MsgBoxStyle.Information, "Información")
                dgvLocaciones.Focus()
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
            If MsgBox("¿Está seguro de ASIGNAR las locaciones seleccionadas al usuario: " & CodUsu & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim estado_process As Boolean
                    For Each fila As DataRow In dtSeleccionados.Rows
                        estado_process = oSeguridadService.InsertarLocacionUsuario(CodUsu, fila.Item("IdLocacion"))
                    Next

                    If estado_process Then
                        MsgBox("Se agregó correctamente las locaciones")
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
            MsgBox("ERROR AL GUARDAR LOCACION(ES): " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class