Imports System.ServiceModel
Public Class frmVacaciones_ActualizarFecha

    '=========================== Servicios ====================================================
    Private oVacacionesService As New VacacionesService.VacacionesServiceClient

    Public IdVacaciones As Integer
    Public Colaborador As String
    Public FecPago As String
    Public Observacion As String

    Private Sub frmVacaciones_ActualizarFecha_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oVacacionesService.Close()
        Catch ex As TimeoutException
            oVacacionesService.Abort()
        Catch ex As CommunicationException
            oVacacionesService.Abort()
        End Try
    End Sub

    Private Sub frmVacaciones_ActualizarFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmVacaciones_ActualizarFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblColaborador.Text = "Colaborador : " + Colaborador
        ObtenerRegistro()
        'txtFecPago.Text = FecPago
        'txtObservacion.Text = Observacion

    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As VacacionesService.Vacaciones
            registro = oVacacionesService.Obtener(IdVacaciones)

            If Not (registro.FecPago.ToString = "") Then
                txtFecPago.Value = CDate(registro.FecPago)
                txtFecPago.Text = registro.FecPago.ToString
            End If
            txtObservacion.Text = registro.Observacion

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If txtFecPago.Text = "" Then
                MsgBox("Debe Ingresar la Fecha de Pago", MsgBoxStyle.Information)
            Else
                Dim estado_process As Boolean
                estado_process = oVacacionesService.ActualizarFechaPago(IdVacaciones, txtFecPago.Value, txtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                'If estado_process Then
                MsgBox("Se actualizo correctamente la Fecha de Pago")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK

            End If



        Catch ex As Exception
            MsgBox("Error al Actualizar la Fecha de Pago  : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub
End Class