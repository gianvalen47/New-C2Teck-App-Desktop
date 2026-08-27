Imports System.ServiceModel
Public Class frmProvisional_FechaTerminoMant_Nuevo

    '===========================Servicios====================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient

    Public IdProvisional As Integer
    Public IdFechas As Integer
    Public state_button As Boolean
    Public type_process As String

    Private Sub frmProvisional_FechaTerminoMant_Nuevo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oProvisionalService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
        End Try
    End Sub

    Private Sub frmProvisional_FechaTerminoMant_Nuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmProvisional_FechaTerminoMant_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProvisional.Text = IdProvisional
        Me.Text = "Actualizar Fecha Termino"

        If state_button Then

            ObtenerRegistro()
            txtObservacion.Focus()
        Else

            txtFecDoc.Value = Today
            txtFecDoc.Focus()
        End If


    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As ProvisionalService.ProvisionalExtensionFechas
            registro = oProvisionalService.ObtenerExtensionFecha(IdFechas)

            IdProvisional = registro.Provisional.IdProvisional
            IdFechas = registro.IdFechas
            txtFecDoc.Value = registro.FecFinal
            txtObservacion.Text = registro.Observacion

            'Me.Text = "Provisional Nº " + registro.IdProvisional.ToString
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            If txtObservacion.Text <> "" Then

                'Dim estado_process As Boolean

                Dim registro As New ProvisionalService.ProvisionalExtensionFechas
                Dim prov As New ProvisionalService.Provisional

                prov.IdProvisional = IdProvisional
                registro.Provisional = prov

                registro.IdFechas = IIf(state_button = False, 0, IdFechas)
                registro.FecFinal = txtFecDoc.Value
                registro.Observacion = txtObservacion.Text
                '                registro.FecReg = Date.Today
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp


                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo

                    Insertar(registro)
                End If

                'estado_process = oProvisionalService.InsertarExtensionFecha(registro)

                'If estado_process Then
                '    MsgBox("Se actualizo la fecha de termino correctamente ")
                '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                'End If

            Else
                MsgBox("Debe ingresar la Observación")
                txtObservacion.Focus()


            End If



        Catch ex As Exception
            MsgBox("Error al Actualizar la fecha de termino : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As ProvisionalService.ProvisionalExtensionFechas)
        Try
            Dim estado_process As Integer
            estado_process = oProvisionalService.InsertarExtensionFecha(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdFechas = estado_process
                'iUbicacion = toNumber(cmbUbicacion.Value)
                'iViatico = cbViatico.Checked
                MsgBox("Se insertó la extension de fecha correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("!Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR LA EXTENSION FECHA TERMINO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As ProvisionalService.ProvisionalExtensionFechas)
        Try
            Dim estado_process As Boolean
            estado_process = oProvisionalService.ActualizarExtensionFecha(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la extension de fecha correctamente")
                'desactivar()
                'ObtenerRegistro()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("!Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR LA EXTENSION FECHA TERMINO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class