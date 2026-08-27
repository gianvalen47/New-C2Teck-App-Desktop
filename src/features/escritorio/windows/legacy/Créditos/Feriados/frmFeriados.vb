Imports System.ServiceModel

Public Class frmFeriados

    Private oDocumentosCtasService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtDatos As DataTable

    Private Sub frmFeriados_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oDocumentosCtasService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oDocumentosCtasService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oDocumentosCtasService.Abort()
            oSeguridadService.Abort()
        End Try
    End Sub

    Private Sub frmFeriados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFeriados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 166)
        '/*************************************************************************************/
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        txtanio.Value = Today.Year
        ListaDatos()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.Close()
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        biMostrar_Click(sender, e)
    End Sub

    Private Sub ListaDatos()
        Try
            dtDatos = oDocumentosCtasService.FiltrarFeriados(txtanio.Value).Tables(0)
            dgvDatos.DataSource = dtDatos
          
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS : " + ex.Message)
        End Try
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Dim frm As New frmFeriado

        frm.state_button = False
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            ListaDatos()
            RowPossesion(dgvDatos, frm.FecFer)
        End If
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            Dim frm As New frmFeriado
            frm.DesFer = dgvDatos.CurrentRow.Cells("DesFer").Value
            frm.FecFer = dgvDatos.CurrentRow.Cells("FecFer").Value
            frm.state_button = True
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ListaDatos()
                RowPossesion(dgvDatos, frm.FecFer)
            End If
        End If
    End Sub

    Public Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)

        Dim rows() As Janus.Windows.GridEX.GridEXRow
        rows = lista.GetRows

        For Each row In rows

            If row.Cells("FecFer").Value = codigo Then
                lista.Row = row.Position
                lista.Col = 1
            End If
        Next
        
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        Try
            If MsgBox("¿Está seguro de ELIMINAR la Fecha de Feriado : " & dgvDatos.CurrentRow.Cells("FecFer").Value, MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oDocumentosCtasService.BorrarFeriado(dgvDatos.CurrentRow.Cells("FecFer").Value)
                If estado_process Then
                    MsgBox("Se eliminó correctamente la Fecha de feriado ", MsgBoxStyle.Information)
                    ListaDatos()
                Else
                    MsgBox("Error en el proceso,comuniquese con el departamento de sistemas")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If dgvDatos.RowCount > 0 Then
                    If biMostrar.Enabled = True Then
                        biMostrar_Click(sender, e)
                        e.Handled = True
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("FecFer").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click, txtanio.TextChanged
        ListaDatos()
    End Sub
End Class