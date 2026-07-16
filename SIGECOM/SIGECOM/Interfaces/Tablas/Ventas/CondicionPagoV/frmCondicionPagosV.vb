Imports System.ServiceModel
Imports System.Net.Mail
Public Class frmCondicionPagosV

    Private oClienteService As New ClienteService.ClienteServiceClient
    'Private oMaestroService As New MaestroService.MaestroClient

    Private dtDatos As DataTable
    Private dtAreas As DataTable

    Private state_Search As Boolean
    Private Sub frmCondicionPagosV_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        'txtDiasPago.Value = 0
        state_Search = False
        'llenarCombos()
        state_Search = True
        listaDatos()

    End Sub

    Private Sub frmCondicionPagosV_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCondicionPagosV_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oClienteService.Close()
        Catch ex As TimeoutException
            oClienteService.Abort()
        Catch ex As CommunicationException
            oClienteService.Abort()
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then

                dtDatos = oClienteService.FiltrarCondicionPago(txtDescripcion.Text, txtDiasPago.Value, txtCodigo.Text).Tables(0)
                dgvDatos.DataSource = dtDatos

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                'enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(sender As Object, e As EventArgs) Handles biNuevo.Click, miNuevo.Click
        Nuevo()
    End Sub

    Private Sub Nuevo()

        Dim frm As New frmCondicionPagoV
        frm.state_button = False
        frm.edicion = True
        frm.editable = True
        frm.CodPag = ""
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            dtDatos = Nothing
            listaDatos()
            If frm.type_process = "insert" Then
                RowPossesion(dgvDatos, frm.CodPag)
                mostrar()
            End If
        End If

    End Sub

    Private Sub mostrar()
        Try
            Dim frm As New frmCondicionPagoV
            frm.state_button = True
            frm.CodPag = toBlank(dgvDatos.CurrentRow.Cells("CodPag").Value)
            frm.editable = True
            frm.edicion = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    'limpiaOpcionesBusqueda("update", frm.txtPlaca.Text.Trim)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.CodPag)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
                'listaDatos()
            End If
            actualizar()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

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

    Public Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("CodPag").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If row.Cells("CodPag").Value = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, txtCodigo.TextChanged, txtDescripcion.TextChanged, txtDiasPago.TextChanged
        listaDatos()
    End Sub

    Private Sub biactualizar_Click(sender As Object, e As EventArgs) Handles biactualizar.Click, miActualizar.Click
        listaDatos()
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub eliminar()
        Try
            cmbOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Condicion de Pago = " + dgvDatos.CurrentRow.Cells("CodPag").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oClienteService.BorrarCondicionPago(dgvDatos.CurrentRow.Cells("CodPag").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de T.I. ...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA CONDICION DE PAGO :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biMostrar_Click(sender As Object, e As EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
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
            ElseIf dgvDatos.CurrentRow.Cells("DesPag").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biSalir_Click(sender As Object, e As EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class