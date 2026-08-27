Imports System.ServiceModel
Public Class frmRubrosEmpresa

    Private oRubrosService As New RubrosService.RubrosServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient

    Private dtDatos As DataTable

    '======================Declaración de Variables==============================   
    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String                'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    Public CodEmp As String
    Public DesEmp As String


    Private dtAreas As DataTable
    Private dtPersonal As DataTable

    Private Sub frmRubrosEmpresa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oRubrosService.Close()
        Catch ex As TimeoutException
            oRubrosService.Abort()
        Catch ex As CommunicationException
            oRubrosService.Abort()
        End Try
        'Me.Dispose(True)
        Me.Hide()

    End Sub

    Private Sub frmRubrosEmpresa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRubrosEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        listaDatos()
    End Sub

    Private Sub listaDatos()

        Try
            dtDatos = oRubrosService.MostrarRubrosEmpresa(Session.sCodEmp).Tables(0)
            dgvRubros.DataSource = dtDatos
            enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR AL LISTAR CONTACTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub enableOpciones()
        If dgvRubros.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
        End If

    End Sub

    Private Sub miNuevo_Click(sender As Object, e As EventArgs) Handles miNuevo.Click
        NuevoDetalle()
    End Sub

    Private Sub miMostrar_Click(sender As Object, e As EventArgs) Handles miMostrar.Click
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetalle()
            End If
        End If
    End Sub

    Private Sub miEliminar_Click(sender As Object, e As EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()

        Try
            If MsgBox("¿Está seguro de ELIMINAR el Rubro seleccionado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oRubrosService.BorrarRubrosEmpresa(dgvRubros.CurrentRow.Cells("CodRub").Text, Session.sCodEmp, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI ...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL RUBRO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        Dim codigo As String = ""
        If dgvRubros.RowCount > 0 Then
            codigo = dgvRubros.CurrentRow.Cells("CodRub").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvRubros.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvRubros, codigo)
        End If
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim frm As New frmRubrosEmpresa_Nuevo
            frm.CodEmpV = Session.sCodEmp
            'frm.Placa = toBlank(txtDesEmp.Text)

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesion(dgvRubros, frm.CodRubV)
            Else
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("Error al Ingresar un Rubro x Empresa: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvRubros.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvRubros.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvRubros.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmRubrosEmpresa_Nuevo
            frm.state_button = True
            frm.CodEmpV = Session.sCodEmp
            frm.CodRubV = dgvRubros.CurrentRow.Cells("CodRub").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                actualizarDetalles()
                'ObtenerRegistro()
            End If
            RowPossesion(dgvRubros, frm.CodRubV)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvRubros.RowCount > 0 Then
                If IsDBNull(dgvRubros.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvRubros.CurrentRow.Cells("CodRub").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvRubros.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvRubros, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("CodRub").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvRubros_DoubleClick(sender As Object, e As EventArgs) Handles dgvRubros.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub biCerrar_Click(sender As Object, e As EventArgs) Handles biCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class