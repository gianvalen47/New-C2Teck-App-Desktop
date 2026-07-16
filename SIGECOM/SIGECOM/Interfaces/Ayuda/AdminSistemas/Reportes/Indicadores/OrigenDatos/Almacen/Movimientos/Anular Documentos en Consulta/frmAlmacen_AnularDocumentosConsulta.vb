
Imports System.ServiceModel

Public Class frmAlmacen_AnularDocumentosConsulta

    Private oDocumentoTransitoService As New DocumentoTransitoService.DocumentoTransitoServiceClient

    Private dtDatos As DataTable
    Private IdSerieDoc As Integer

    Private Sub frmAlmacen_AnularDocumentosConsulta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oDocumentoTransitoService.Close()

        Catch ex As TimeoutException
            oDocumentoTransitoService.Abort()

        Catch ex As CommunicationException
            oDocumentoTransitoService.Abort()

        End Try
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmAlmacen_AnularDocumentosConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub frmAlmacen_AnularDocumentosConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)

        listaDatos()
        dgvDatos.Select()

    End Sub

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
            fila(2) = "(Todos)"
        End Try

        Return fila
    End Function

    Private Sub listaDatos()
        Try
            dtDatos = oDocumentoTransitoService.MostrarAnulacionConsulta().Tables(0)
            dgvDatos.DataSource = dtDatos
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.Click, miAnular.Click
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está seguro de ANULAR la documento Nº " + dgvDatos.CurrentRow.Cells("Documento").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oDocumentoTransitoService.AnularDocumentoConsulta(dgvDatos.CurrentRow.Cells("IdDocumento").Text, dgvDatos.CurrentRow.Cells("IdVenta").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                    If estado_process = True Then
                        actualizar()
                        MsgBox("El Documento fue Anulado correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ANULAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
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
            ElseIf dgvDatos.CurrentRow.Cells("IdDocumento").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdVenta").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Public Sub actualizar()
        listaDatos()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        actualizar()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub biRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biRechazar.Click, miRechazar.Click
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está seguro de RECHAZAR el documento Nº " + dgvDatos.CurrentRow.Cells("Documento").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oDocumentoTransitoService.RechazarAnulacionConsulta(dgvDatos.CurrentRow.Cells("IdDocumento").Text, dgvDatos.CurrentRow.Cells("IdVenta").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        actualizar()
                        MsgBox("El documento fue rechazado correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("Error al Rechazar la Guía : " + ex.Message)
            End Try
        End If

    End Sub

    Private Sub biMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        If dgvDatos.RowCount = 0 Then
            MsgBox("No hay datos que mostrar, verifique.!!!!", MsgBoxStyle.Information, "Error, Cuidado!!!!!!!")
        Else
            Dim forma As New frmConsultaDocumento
            forma.pIdMovimiento = dgvDatos.CurrentRow.Cells("IdVenta").Text
            forma.pTipDoc = IIf(dgvDatos.CurrentRow.Cells("IdDocumento").Text = "2", 3, IIf(dgvDatos.CurrentRow.Cells("IdDocumento").Text = "3", 2, dgvDatos.CurrentRow.Cells("IdDocumento").Text))
            forma.pTipo = 1
            If forma.ShowDialog = Windows.Forms.DialogResult.OK Then
            End If
        End If
    End Sub
End Class