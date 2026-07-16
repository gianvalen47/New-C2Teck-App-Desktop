Imports System.ServiceModel
Public Class frmMantRubros

    Private oRubrosService As New RubrosService.RubrosServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient

    Private dtDatos As DataTable
    Private dtAreas As DataTable

    Private state_Search As Boolean

    Private Sub frmMantRubros_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oRubrosService.Close()
        Catch ex As TimeoutException
            oRubrosService.Abort()
        Catch ex As CommunicationException
            oRubrosService.Abort()
        End Try
    End Sub

    Private Sub frmMantRubros_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmMantRubros_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        state_Search = False
        'llenarCombos()
        state_Search = True
        listaDatos()


    End Sub

    Private Sub listaDatos()

        Try
            If state_Search = True Then

                dtDatos = oRubrosService.Filtrar().Tables(0)
                dgvDatos.DataSource = dtDatos

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                'enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub dgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
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

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub mostrar()

        Try
            Dim frm As New frmMantRubro
            frm.state_button = True
            frm.CodRub = dgvDatos.CurrentRow.Cells("CodRub").Text
            'frm.Text = "EMPRESA : " & dgvDatos.CurrentRow.Cells("DesEmp").Text
            frm.editable = True
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.CodRub)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            'Actualizar()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL RUBRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()

        Try
            If MsgBox("¿Está seguro de ELIMINAR el Rubro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oRubrosService.Borrar(dgvDatos.CurrentRow.Cells("CodRub").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI ...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL RUBRO:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biactualizar_Click(sender As Object, e As EventArgs) Handles biactualizar.Click, miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("CodRub").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()

        Try
            Dim frm As New frmMantRubro
            frm.state_button = False
            frm.CodRub = ""
            'frm.btnEditar.Enabled = False
            'frm.btnCancelar.Enabled = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.IdProveedor)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.CodRub)
                    mostrar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GENERAR UN RUBRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("CodRub").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

End Class