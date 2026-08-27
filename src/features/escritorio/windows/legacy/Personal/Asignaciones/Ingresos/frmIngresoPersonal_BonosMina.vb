Imports System.ServiceModel
Public Class frmIngresoPersonal_BonosMina

    '=========================== Servicios ===================================================
    Private oIngresoPersonalService As New IngresoPersonalService.IngresoPersonalServiceClient

    '======================Declaración de Variables==============================
    '==========================Evento Load===================================================

    Private Sub frmIngresoPersonal_BonosMina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        txtFecFinal.Value = Today
        txtFecRegistro.Value = Today
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()        
    End Sub

    Private Sub Finalizar()
        Try
            oIngresoPersonalService.Close()
        Catch ex As TimeoutException
           oIngresoPersonalService.Abort()
        Catch ex As CommunicationException
           oIngresoPersonalService.Abort()
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If rbBonos.Checked = True Then

                If MsgBox("¿Está seguro de INSERTAR los Bonos de Mina?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oIngresoPersonalService.ProcesarBonosMina(txtFecRegistro.Value, txtFecInicio.Value, txtFecFinal.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("Se Insertó los Bonos de Mina correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
                    End If
                End If

            ElseIf rbValeAlimentos.Checked = True Then

                If MsgBox("¿Está seguro de INSERTAR los Vales de Alimentos de Mina?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oIngresoPersonalService.ProcesarValeAlimentosMina(txtFecRegistro.Value, txtFecInicio.Value, txtFecFinal.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        MsgBox("Se Insertó los Vales de Alminentos de Mina correctamente.")
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        MsgBox("¡Error en el proceso,comuniquese con el departamento de sistemas...!")
                    End If
                End If

            End If
            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Insertar Bonos / Vales de Alimentos de Mina")
        End Try
    End Sub

    Private Sub frmIngresoPersonal_BonosMina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub
End Class