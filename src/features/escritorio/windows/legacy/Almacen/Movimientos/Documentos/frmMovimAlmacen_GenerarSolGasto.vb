Imports System.ServiceModel

Public Class frmMovimAlmacen_GenerarSolGasto

    '===========================Servicios====================================================
    Private oMoviAlmacenService As New MoviAlmacenService.MoviAlmacenServiceClient

    Public IdMovimiento As Integer

    Private Sub frmMovimAlmacen_GenerarSolGasto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMoviAlmacenService) = False Then
                oMoviAlmacenService.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmMovimAlmacen_GenerarSolGasto_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmMovimAlmacen_GenerarSolGasto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rbResumido.Checked = True

    End Sub

    Private Sub Finalizar()
        Try
            oMoviAlmacenService.Close()
        Catch ex As TimeoutException
            oMoviAlmacenService.Abort()
        Catch ex As CommunicationException
            oMoviAlmacenService.Abort()
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If rbResumido.Checked = True Then

            If MsgBox("¿Está seguro de GENERAR la Solicitud de Gasto Resumido?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                Dim estado_process As Integer
                estado_process = oMoviAlmacenService.GenerarSolicitudGasto(IdMovimiento, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                'type_process = "insert"
                If estado_process > 0 Then
                    'dtDatos = Nothing
                    'listaDatos()
                    'actualizar()
                    MsgBox(" Se genero la Solicitud de Gasto N°: " & estado_process & ".", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If

        ElseIf rbDetallado.Checked = True

            If MsgBox("¿Está seguro de GENERAR la Solicitud de Gasto Detallado?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                Dim estado_process As Integer
                estado_process = oMoviAlmacenService.GenerarSolicitudGastoDetalle(IdMovimiento, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                'type_process = "insert"
                If estado_process > 0 Then
                    'dtDatos = Nothing
                    'listaDatos()
                    'actualizar()
                    MsgBox(" Se genero la Solicitud de Gasto N°: " & estado_process & ".", MsgBoxStyle.Information)
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            End If


        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class