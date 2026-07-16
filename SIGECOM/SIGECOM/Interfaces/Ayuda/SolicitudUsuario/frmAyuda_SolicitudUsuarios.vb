Imports System.ServiceModel
Public Class frmAyuda_SolicitudUsuarios

    '=========================== Servicios ===================================================
    Private oSolicitudUsuarioService As New SolicitudUsuarioService.SolicitudUsuarioServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    '======================Declaración de Variables==============================================
    Private IdPerUsu As Integer
    Private dtDatos As DataTable

    '==========================Evento Load===================================================
    Private Sub frmAyuda_SolicitudUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        llenarCombos()
        listaDatos()
    End Sub

    '=============================Evento KeyPress============================================
    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    '==========================Evento FormClosed=============================================
    Private Sub frmAyuda_SolicitudUsuarios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSolicitudUsuarioService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSolicitudUsuarioService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSolicitudUsuarioService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    '==========================Evento KeyDown===============================================
    Private Sub frmAyuda_SolicitudUsuarios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            biMostrar_Click(sender, e)
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biMostrar.Enabled = False
            biConformidad.Enabled = False
            biactualizar.Enabled = False

            miMostrar.Enabled = False
            miConformidad.Enabled = False
            miActualizar.Enabled = False
        Else
            biMostrar.Enabled = True
            miMostrar.Enabled = True
            biactualizar.Enabled = True
            miActualizar.Enabled = True

            If dgvDatos.CurrentRow.Cells("Estado").Text = "ENTREGADO" Then
                biConformidad.Enabled = True
                miConformidad.Enabled = True
            Else
                biConformidad.Enabled = False
                miConformidad.Enabled = False
            End If
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdSolicitud").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    
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

    Private Sub llenarCombos()
        Try

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            IdPerUsu = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu).Persona.IdPer
            dtDatos = oSolicitudUsuarioService.Mostrar(IdPerUsu).Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros: " + dgvDatos.RowCount.ToString
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.Click, miActualizar.Click
        Actualizar()
    End Sub

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdSolicitud").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub Nuevo()
        Try
            Dim frm As New frmAyuda_SolicitudUsuario
            frm.IdPerUsu = IdPerUsu
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, frm.IdSolicitud)
                Actualizar()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA SOLICITUD DE USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmAyuda_SolicitudUsuario
            frm.Text = "Solicitud de Usuario - Numero : " & dgvDatos.CurrentRow.Cells("IdSolicitud").Text
            frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Text
            frm.state_button = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvDatos, frm.IdSolicitud)
            End If
            Actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA SOLICITUD DE USUARIO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                          biNuevo.MouseLeave, miNuevo.MouseLeave, biMostrar.MouseLeave, miMostrar.MouseLeave, _
                                          biConformidad.MouseLeave, miConformidad.MouseLeave, biactualizar.MouseLeave, miActualizar.MouseLeave, _
                                          biSalir.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Solicitud de Usuario."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Solicitud de Usuario actual."
    End Sub        
    Private Sub Conformidad_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConformidad.MouseEnter, miConformidad.MouseEnter
        sslError.Text = "Dar Conformidad a Solicitud de Usuario actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biactualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub    
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    Private Sub biConformidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConformidad.Click, miConformidad.Click
        Try
            Dim frm As New frmAyuda_Conformidad
            frm.IdSolicitud = dgvDatos.CurrentRow.Cells("IdSolicitud").Text
            frm.IdPer = dgvDatos.CurrentRow.Cells("IdPer").Text
            'frm.Motivo = dgvDatos.CurrentRow.Cells("Motivo").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                'MsgBox("Se realizo la conformidad correctamente", MsgBoxStyle.Information)
                biRefrescar_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DAR CONFORMIDAD: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class