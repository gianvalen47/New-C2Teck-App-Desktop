Public Class frmServicios_Cotizacion_Desvincular

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oCotizacionServicioDetService As New CotizacionServicioDetService.CotizacionServicioDetServiceClient
    Private dtDatos As DataTable
    Public IdCotizacionSer As Integer
    Public NumCotizacion As String

    Private Sub frmServicios_Cotizacion_Desvincular_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionServicioService) = False Then
                oCotizacionServicioService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmServicios_Cotizacion_Desvincular_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmServicios_Cotizacion_Desvincular_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listaDatos()
        VerificarCot()
    End Sub
    Private Sub listaDatos()
        Try
            dtDatos = oCotizacionServicioService.MostrarCotizacionAdjuntada(IdCotizacionSer).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub VerificarCot()
        If dgvDatos.RowCount < 1 Then
            btnDesvincular.Enabled = False
        Else
            btnDesvincular.Enabled = True
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnDesvincular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesvincular.Click
        Try
            If MsgBox("¿Está seguro de DESVINCULAR la cotizacion Nº " & dgvDatos.CurrentRow.Cells("NumCot").Value & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oCotizacionServicioService.BorrarCotizacionRepuestos(IdCotizacionSer, dgvDatos.CurrentRow.Cells("IdCotizacion").Value, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                If estado_process Then
                    'Dim estado_process2 As Boolean
                    'estado_process2 = oCotizacionServicioDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSerDet").Value), toNumber(dgvDatos.CurrentRow.Cells("IdCotizacionSer").Value))
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class