Public Class frmServicios_Cotizacion_Adjuntar

    Private oCotizacionServcioService As New CotizacionServicioService.CotizacionServicioServiceClient

    Public IdCotizacionSer As Integer
    Public NumCotizacion As String
    Public IdCliente As Integer
    Public IdCotizacion As Integer
    Public NumCotizacion2 As Integer
    Public MontoTotal As Decimal
    Public MontoDscto As Decimal

    Private dtDatos As DataTable

    Private Sub frmServicios_Cotizacion_Adjuntar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oCotizacionServcioService) = False Then
                oCotizacionServcioService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmServicios_Cotizacion_Adjuntar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmServicios_Cotizacion_Adjuntar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        listaDatos()
        VerificarCot()
    End Sub

    Private Sub VerificarCot()
        If dgvDatos.RowCount < 1 Then
            btnAceptar.Enabled = False
        Else
            btnAceptar.Enabled = True
        End If
    End Sub


    Private Sub listaDatos()
        Try
            dtDatos = oCotizacionServcioService.MostrarCotizacionRepuestos(IdCliente).Tables(0)
            dgvDatos.DataSource = dtDatos
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            'Dim frm As New frmServicios_Cotizacion_Nuevo
            'frm.IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Value
            'frm.NumCotizacion2 = dgvDatos.CurrentRow.Cells("NumCot").Value
            If dgvDatos.RowCount < 1 Then

            Else
                IdCotizacion = dgvDatos.CurrentRow.Cells("IdCotizacion").Value
                NumCotizacion2 = dgvDatos.CurrentRow.Cells("NumCot").Value
                MontoTotal = dgvDatos.CurrentRow.Cells("TotBruto").Value
                MontoDscto = dgvDatos.CurrentRow.Cells("TotDscto").Value
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

                'If MsgBox("¿Está seguro de ADJUNTAR la cotización Nº " & dgvDatos.CurrentRow.Cells("NumCot").Value & " a la cotización de servicios Nº " & NumCotizacion, MsgBoxStyle.YesNo, "Adevertencia") = MsgBoxResult.Yes Then
                '    Dim estado_process As Boolean
                '    estado_process = oCotizacionServcioService.AdjuntarRepuestos(IdCotizacionSer, dgvDatos.CurrentRow.Cells("IdCotizacion").Value, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                '    If estado_process Then
                '        MsgBox("Se Adjunto la Cotización correctamente")
                '        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                '    Else
                '        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                '    End If
                'End If
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