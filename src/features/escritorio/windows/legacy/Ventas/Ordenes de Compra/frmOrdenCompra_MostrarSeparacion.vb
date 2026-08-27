Imports System.ServiceModel

Public Class frmOrdenCompra_MostrarSeparacion

    Private oMaestroService As New MaestroService.MaestroClient
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient
    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Public IdOrden As Integer
    'Private AprOrden As Boolean
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClientes As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable

    Private Sub frmOrdenCompra_MostrarSeparacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listaDatos()

    End Sub

    Private Sub listaDatos()

        Try

            dtDatos = oOrdenCompraDetService.MostrarSeparar(IdOrden).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub frmOrdenCompra_MostrarSeparacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmOrdenCompra_MostrarSeparacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oOrdenCompraDetService.Close()

        Catch ex As TimeoutException
            oOrdenCompraDetService.Abort()
        Catch ex As CommunicationException
            oOrdenCompraDetService.Abort()
        End Try
    End Sub

    Private Sub miEliminarDet_Click(sender As Object, e As EventArgs) Handles miEliminarDet.Click

        If ValidaCodigoSeleccionado() Then
            eliminarSeparacion()
        End If

    End Sub

    Private Sub eliminarSeparacion()
        Try
            'cmOpciones.Visible = False
            'If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
            '    If dgvDatos.CurrentRow.Cells("IdSugerido").Text = "" Then
            Dim estado_process As Boolean
            estado_process = oOrdenCompraDetService.BorrarSeparar(toNumber(dgvDatos.CurrentRow.Cells("IdOrdenDet").Text), IdOrden, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process = True Then
                dtDatos = Nothing
                listaDatos()
                MsgBox("Se eliminó la separación correctamente.", MsgBoxStyle.Information)
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
            '    Else
            '        MsgBox("Primero debe eliminar el Precio y/o Descuento sugerido")
            '    End If
            'End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub EliminarSeparacionTotal()
        Try

            Dim estado_process As Boolean

            For i As Integer = 0 To dtDatos.Rows.Count - 1
                'If dgvPrueba.Rows(i).Cells("Despacho").Value > "0" Then
                estado_process = oOrdenCompraDetService.BorrarSeparar(toNumber(dgvDatos.GetRow(i).Cells("IdOrdenDet").Text), IdOrden, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

            Next

            If estado_process Then
                listaDatos()
                MsgBox("Se Eliminaron las Separaciones Correctamente.", MsgBoxStyle.Information)
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK

            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If


        Catch ex As Exception
            MsgBox("ERROR [AGRE-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEliminar_Click(sender As Object, e As EventArgs) Handles biEliminar.Click

        If ValidaCodigoSeleccionado() Then
            EliminarSeparacionTotal()
        End If
    End Sub

    Private Sub miActualizar_Click(sender As Object, e As EventArgs) Handles miActualizar.Click
        listaDatos()
    End Sub
End Class