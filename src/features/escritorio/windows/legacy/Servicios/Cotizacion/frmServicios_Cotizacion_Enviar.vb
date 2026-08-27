Imports System.ServiceModel

Public Class frmServicios_Cotizacion_Enviar

    Private oCotizacionServicioService As New CotizacionServicioService.CotizacionServicioServiceClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient

    Private dtCorreos As DataTable
    Public IdCotizacionSer As Integer
    Public NumCotizacion As String
    Public CodCentro As String

    Private Sub frmServicios_Cotizacion_Enviar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oCotizacionServicioService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oCotizacionServicioService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oCotizacionServicioService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub

    Private Sub frmServicios_Cotizacion_Enviar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmServicios_Cotizacion_Enviar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listaCorreos()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub listaCorreos()
        Try
            dtCorreos = oAsignacionJefesService.MostrarJefeArea(CodCentro).Tables(0)
            dgvCorreos.DataSource = dtCorreos

        Catch ex As Exception
            MsgBox("Error al listar correos : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            If MsgBox("¿Está seguro de ENVIAR la cotización Nº " & NumCotizacion & " para su aprobación?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                Dim rows() As Janus.Windows.GridEX.GridEXRow
                Dim Cadena As String = ""
                rows = dgvCorreos.GetCheckedRows()
                Dim row As Janus.Windows.GridEX.GridEXRow

                If rows.Count <> 0 Then
                    For Each row In rows
                        If Cadena = "" Then
                            Cadena = row.Cells("Email").Text
                        Else
                            Cadena = Cadena + ";" + row.Cells("Email").Text
                        End If
                    Next
                    '=================================Enviar a Correos Seleccionados=================================
                    Dim estado_process As Boolean
                    estado_process = oCotizacionServicioService.Enviar(IdCotizacionSer, toNull(txtObservacion.Text), Cadena, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                    If estado_process Then
                        MsgBox("La cotización fue enviada correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("Debe seleccionar alguno de los correos")
                End If




                'Dim estado_process As Boolean
                'estado_process = oCotizacionServicioService.Enviar(IdCotizacionSer, Session.sCodUsu, Session.sDirIp, Session.sNomPc)
                'If estado_process Then
                '    MsgBox("La cotización fue enviada correctamente.")
                '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'Else
                '    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                'End If
            End If
        Catch ex As Exception
            MsgBox("Error al Enviar la Cotización  " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub




End Class