Imports System.ServiceModel

Public Class frmSeguimiento_Fotos

    Private oSeguimientoService As New SeguimientoService.SeguimientoServiceClient

    Private dtDatos As DataTable
    Public IdSeguimiento As Integer

    Private Sub frmSeguimiento_Fotos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oSeguimientoService.Close()
        Catch ex As TimeoutException
            oSeguimientoService.Abort()
        Catch ex As CommunicationException
            oSeguimientoService.Abort()
        End Try
    End Sub

    Private Sub frmSeguimiento_Fotos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSeguimiento_Fotos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listaDatos()
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSeguimientoService.MostrarFotos(IdSeguimiento).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click

        Dim lLog As Boolean = True
        While lLog
            Dim frm As New frmSeguimiento_Fotos_Nuevo
            frm.state_button = False

            frm.IdSeguimiento = IdSeguimiento

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdSeguimientoFoto)
                End If
            Else
                lLog = False
            End If
        End While

    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click

        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If

    End Sub

    Private Sub mostrar()

        Dim frm As New frmSeguimiento_Fotos_Nuevo
        frm.state_button = True

        frm.IdSeguimiento = dgvDatos.CurrentRow.Cells("IdSeguimiento").Text
        frm.IdSeguimientoFoto = dgvDatos.CurrentRow.Cells("IdSeguimientoFoto").Text

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            Actualizar()
        End If

    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click

        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If

    End Sub

    Private Sub eliminar()
        Try
            'cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la foto seleccionada?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oSeguimientoService.BorrarFoto(toNumber(dgvDatos.CurrentRow.Cells("IdSeguimientoFoto").Value), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de TI!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA FOTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Actualizar()
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

    Private Sub Actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdSeguimientoFoto").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("IdSeguimientoFoto").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

End Class