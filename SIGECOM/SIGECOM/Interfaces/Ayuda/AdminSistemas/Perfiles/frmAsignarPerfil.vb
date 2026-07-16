Imports System.ServiceModel
Public Class frmAsignarPerfil

    '===========================Servicios====================================================
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private dtMenu As DataTable
    Private dtOpciones As DataTable
    Private dtSeleccionados As DataTable

    Private IdOpcion As Integer
    Private DesOpc1 As String
    Public CodPerfil As String

    Private Sub frmAsignarPerfil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvOpciones.BackgroundColor = Color.Beige
        dgvOpciones.BackColor = Color.Beige
        dgvOpciones.ForeColor = Color.MidnightBlue
        dgvOpciones.AutoGenerateColumns = False

        dgvSeleccionados.BackgroundColor = Color.Beige
        dgvSeleccionados.BackColor = Color.Beige
        dgvSeleccionados.ForeColor = Color.MidnightBlue
        dgvSeleccionados.AutoGenerateColumns = False
        llenarCombos()
        'cmbMenu.Value = "01"
    End Sub

    Private Sub frmAsignarPerfil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmAsignarPerfil_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub llenarCombos()
        Try

            '======================================= AREAS ================================================
            dtMenu = oSeguridadService.MostrarMenuSistema.Tables(0)
            cmbMenu.DataSource = dtMenu
            cmbMenu.DropDownList.DataMember = dtMenu.Columns("DesMenu").ToString
            cmbMenu.DropDownList.DisplayMember = dtMenu.Columns("DesMenu").ToString
            cmbMenu.DropDownList.ValueMember = dtMenu.Columns("IdMenu").ToString
            cmbMenu.DropDownList.Columns(0).DataMember = dtMenu.Columns("IdMenu").ToString
            cmbMenu.DropDownList.Columns(1).DataMember = dtMenu.Columns("DesMenu").ToString
            cmbMenu.SelectedIndex = 0
            dtMenu = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbMenu_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMenu.ValueChanged
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try

            '===================================== LISTA OPCIONES ======================================
            dtOpciones = oSeguridadService.MostrarMenuOpciones(toNumber(cmbMenu.Value)).Tables(0)
            dgvOpciones.DataSource = dtOpciones

            cIdOpcion.DataPropertyName = dtOpciones.Columns("IdOpcion").ColumnName
            cDesOpc1.DataPropertyName = dtOpciones.Columns("DesOpc1").ColumnName

            '=================================== LISTA SELECCIONADOS ===================================
            dtSeleccionados = oSeguridadService.MostrarMenuOpciones(0).Tables(0)
            dgvSeleccionados.DataSource = dtSeleccionados

            cIdOpcion1.DataPropertyName = dtSeleccionados.Columns("IdOpcion").ColumnName
            cDesOpc11.DataPropertyName = dtSeleccionados.Columns("DesOpc1").ColumnName

            EnableOptions()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub EnableOptions()
        Try
            If dgvOpciones.RowCount > 0 Then
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
        IdOpcion = dgvOpciones.Rows(dgvOpciones.CurrentRow.Index).Cells("cIdOpcion").Value.ToString
        'If oSeguridadService.Buscarm(CodUsu, CodCentro) Then
        '    MsgBox("El Centro de Costo Seleccionado ya ha sido asignado al usuario", MsgBoxStyle.Exclamation, "Error de Datos")
        'Else
        AgregarFila(dtSeleccionados, dgvSeleccionados, dgvOpciones)
        EnableOptions()
        'End If
    End Sub

    Private Sub AgregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdOpcion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdOpcion").Value.ToString
            DesOpc1 = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesOpc1").Value.ToString

            dr("IdOpcion") = IdOpcion
            dr("DesOpc1") = DesOpc1

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        DesagregarFila(dtOpciones, dgvOpciones, dgvSeleccionados)
        EnableOptions()
    End Sub

    Private Sub DesagregarFila(ByVal dtDatos As DataTable, ByVal dgvDatosAsignado As DataGridView, ByVal dgvDatos As DataGridView)
        Try
            Dim dr As DataRow
            dr = dtDatos.NewRow()

            IdOpcion = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cIdOpcion1").Value.ToString
            DesOpc1 = dgvDatos.Rows(dgvDatos.CurrentRow.Index).Cells("cDesOpc11").Value.ToString

            dr("IdOpcion") = IdOpcion
            dr("DesOpc1") = DesOpc1

            dtDatos.Rows.Add(dr)
            dgvDatosAsignado.DataSource = dtDatos
            EliminarFila(dgvDatos)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAgregarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarTodos.Click
        'Dim Cont As Integer = 0         'Cantidad de Locaciones que ya estan asignadas al usuario
        'For i As Integer = 0 To dgvCentros.RowCount - 1
        '    CodCentro = dgvCentros.Rows(dgvCentros.CurrentRow.Index).Cells("cCodCentro").Value.ToString
        '    If oSeguridadService.BuscarCentroCosto(CodUsu, CodCentro) Then
        '        Cont = Cont + 1
        '    End If
        'Next

        'If Cont > 1 Then
        '    MsgBox("Alguno(s) de los Centros de Costo seleccionados ya han sido asignados al usuario ", MsgBoxStyle.Exclamation, "Error de Datos")
        'Else
        For i As Integer = 0 To dgvOpciones.RowCount - 1
            AgregarFila(dtSeleccionados, dgvSeleccionados, dgvOpciones)
        Next
        EnableOptions()
        'End If
    End Sub

    Private Sub btnRegresarTodos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresarTodos.Click
        For i As Integer = 0 To dgvSeleccionados.RowCount - 1
            DesagregarFila(dtOpciones, dgvOpciones, dgvSeleccionados)
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
                MsgBox("Debe seleccionar al menos una opción.", MsgBoxStyle.Information, "Información")
                dgvOpciones.Focus()
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
            If MsgBox("¿Está seguro de ASIGNAR las opciones seleccionadas al perfil: " & CodPerfil & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then
                    Dim estado_process As Boolean
                    For Each fila As DataRow In dtSeleccionados.Rows
                        estado_process = oSeguridadService.InsertarPerfilOpciones(toNumber(fila.Item("IdOpcion")), CodPerfil, True)
                    Next

                    If estado_process Then
                        MsgBox("Se agregó correctamente las opciones")
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
            MsgBox("ERROR AL GUARDAR OPCION(ES): " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        'Try
        '    If MsgBox("¿Está seguro de ELIMINAR TODAS LAS OPCIONES SELECCIONADAS PARA EL PERFIL: " & CodPerfil & " ?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
        '        Dim estado_process As Boolean
        '        For Each Fila As DataRow In dtMenuOpcionAsignado.Rows
        '            estado_process = objSeguridad.BorrarPerfilOpciones(Fila.Item("IdOpcion"), CodPerfil)
        '        Next
        '        If estado_process Then
        '            MsgBox("Se eliminó las opciones correctamente ")
        '            dtMenuOpcionAsignado.Clear()
        '            'Me.DialogResult = Windows.Forms.DialogResult.OK
        '        Else
        '            MsgBox("Error en el Proceso, Comunicarse con el Area de Sistemas...", MsgBoxStyle.Critical)
        '        End If
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        'End Try
    End Sub

End Class