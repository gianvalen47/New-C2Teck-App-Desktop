Imports System.ServiceModel
Public Class frmLocaciones

    Private oLocacionService As New LocacionService.LocacionServiceClient
    Private dtDatos As DataTable

    Private Sub frmLocaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        listaDatos()
        dgvDatos.Select()
    End Sub

    Private Sub frmLocaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmLocaciones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oLocacionService.Close()
        Catch ex As TimeoutException
            oLocacionService.Abort()
        Catch ex As CommunicationException
            oLocacionService.Abort()
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oLocacionService.Filtrar(Session.sCodEmp).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()

        Try
            Dim frm As New frmLocaciones_Nuevo
            frm.state_button = False
            'frm.IdLocacion = ""
            'frm.btnEditar.Enabled = False
            'frm.btnCancelar.Enabled = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.IdProveedor)
                listaDatos()
                If frm.type_process = "insert" Then
                    'RowPossesion(dgvDatos, frm.CodEmp)
                    'mostrar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR NUEVA LOCACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click
        mostrar()
    End Sub

    Private Sub mostrar()

        Try
            Dim frm As New frmLocaciones_Nuevo
            frm.state_button = True
            frm.IdLocacion = dgvDatos.CurrentRow.Cells("IdLocacion").Text
            frm.Text = "LOCACION : " & dgvDatos.CurrentRow.Cells("DesOfi").Text & "-" & dgvDatos.CurrentRow.Cells("DesOfi").Text & "/" & dgvDatos.CurrentRow.Cells("CodAlm").Text & "-" & dgvDatos.CurrentRow.Cells("DesAlm").Text
            frm.editable = True
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdLocacion)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            actualizar()
            enableOpciones()
            'Actualizar()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA LOCACION: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Public Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdLocacion").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False

            miImprimir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            biImprimir.Enabled = True
            biMostrar.Enabled = True
            biEliminar.Enabled = True

            miImprimir.Enabled = True
            miMostrar.Enabled = True
            miEliminar.Enabled = True
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("IdLocacion").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
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

    Private Sub eliminar()

        Try
            If MsgBox("¿Está seguro de ELIMINAR la Locacion seleccionada?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oLocacionService.Borrar(CInt(dgvDatos.CurrentRow.Cells("IdLocacion").Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA LOCACION:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub biActualizar_Click(sender As Object, e As EventArgs) Handles biActualizar.Click
        listaDatos()
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
End Class