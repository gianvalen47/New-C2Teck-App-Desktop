Imports System.ServiceModel
Public Class frmRubrosxEmpresa

    Private oSeguridadService As New EmpresaUsuarioService.EmpresaUsuarioServiceClient   'EmpresaService.EmpresaServiceClient
    Private dtDatos As DataTable
    Public CodEmp As String
    Public DesEmp As String
    Public Salir As Boolean
    Public CodUsu As String

    Private Sub Finalizar()
        Try
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oSeguridadService.Abort()
        End Try
        'Me.Dispose(True)
        Me.Hide()

    End Sub

    Private Sub frmRubrosxEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        listaDatos()
        dgvDatos.Select()
        Me.Size = New System.Drawing.Size(479, 308)

    End Sub

    Private Sub frmRubrosxEmpresa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oSeguridadService.Mostrar(Session.sCodUsu).Tables(0) 'oSeguridadService.Filtrar.Tables(0)
            'dtDatos = oSeguridadService.MostrarMultiEmpresa(CodUsu).Tables(0)
            dgvDatos.DataSource = dtDatos

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmRubrosxEmpresa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
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

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows
        For Each row In rows
            If row.Cells("CodEmp").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click
        mostrar()
    End Sub

    Private Sub mostrar()

        Try
            Dim frm As New frmRubrosxEmpresa_Nuevo
            frm.state_button = True
            frm.CodEmp = dgvDatos.CurrentRow.Cells("CodEmp").Text
            frm.DesEmp = dgvDatos.CurrentRow.Cells("DesEmp").Text
            frm.Text = "EMPRESA : " & dgvDatos.CurrentRow.Cells("DesEmp").Text
            frm.editable = True
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtNumGasto.Text)
                    listaDatos()
                    'RowPossesion(dgvDatos, frm.IdEncuesta)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            'Actualizar()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA EMPRESA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biActualizar_Click(sender As Object, e As EventArgs) Handles biActualizar.Click
        listaDatos()
    End Sub

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub
End Class