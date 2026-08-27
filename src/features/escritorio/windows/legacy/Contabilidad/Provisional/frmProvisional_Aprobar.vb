Imports System.ServiceModel
Public Class frmProvisional_Aprobar

    '===========================Servicios====================================
    Private oProvisionalService As New ProvisionalService.ProvisionalServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oAsignacionJefesService As New AsignacionJefesService.AsignacionJefesServiceClient
    Private oUsuario As New SeguridadService.Usuario


    '======================Declaración de Variables==============================   
    Public IdProvisional As Integer
    Private iTotEntrega As Double
    Private iMoneda As String
    Public iViatico As Boolean

    Private Sub frmComProvisional_Aprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmComProvisional_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmComProvisional_Aprobar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim totalpendiente As Double
        totalpendiente = oProvisionalService.ObtenerMontoPendienteAprobacion(IdProvisional)

        txtMontoPendiente.Value = totalpendiente

        Me.Text = "Aprobar el Provisional N°:" & IdProvisional.ToString
        Dim registro As ProvisionalService.Provisional
        registro = oProvisionalService.Obtener(IdProvisional)
        iTotEntrega = registro.TotEntrega
        iMoneda = registro.Moneda.CodMon
        iViatico = registro.Viatico
        'Activar()
    End Sub

    Private Sub btnAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        oUsuario = oSeguridadService.MostrarUsuarioPorCodigo(Session.sCodUsu)
        Try
            Dim estado_process As Boolean
            '======================================================================================
            '===========================CON PERMISO DE APROB/DESPROB PROVISIONAL===================
            '======================================================================================
            If oAsignacionJefesService.BuscarJefeArea(oUsuario.Persona.IdPer, oUsuario.Persona.CentroCosto.CodCentro) Then
                '===================================================================================
                '=================================APROBAR PROVISIONAL==============================
                '===================================================================================
                If cbAprobar.Checked Then
                    '==============================PROVISIONAL DE VIATICO================================
                    If iViatico Then
                        '===========================CON LÍMITE DE APROBACIÓN==============================
                        If oAsignacionJefesService.BuscarLimiteViatico(oUsuario.Persona.CentroCosto.CodCentro, oUsuario.Persona.IdPer) Then
                            If oAsignacionJefesService.ObtenerMontoViatico(oUsuario.Persona.CentroCosto.CodCentro, oUsuario.Persona.IdPer) >= iTotEntrega Then
                                If MsgBox("¿Está seguro de APROBAR el Provisional N°: " & IdProvisional.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                                    estado_process = oProvisionalService.Aprobar(IdProvisional, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                    MsgBox("Se Aprobó el Provisional correctamente ")
                                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                End If
                            Else
                                MsgBox("El monto del Provisional supera el límite de Aprobación")
                            End If
                            '============================SIN LÍMITE DE APROBACIÓN============================
                        Else
                            If MsgBox("¿Está seguro de APROBAR el Provisional N°: " & IdProvisional & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                                estado_process = oProvisionalService.Aprobar(IdProvisional, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                MsgBox("Se Aprobó el Provisional correctamente ")
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            End If
                        End If
                        '==============================PROVISIONAL DE COMPRA=============================
                    Else
                        '=============================CON LÍMITE DE APROBACIÓN============================
                        If oAsignacionJefesService.BuscarLimiteCompra(oUsuario.Persona.CentroCosto.CodCentro, oUsuario.Persona.IdPer) Then
                            If oAsignacionJefesService.ObtenerMontoCompra(oUsuario.Persona.CentroCosto.CodCentro, oUsuario.Persona.IdPer) >= iTotEntrega Then
                                If MsgBox("¿Está seguro de APROBAR el Provisional N°: " & IdProvisional.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                                    estado_process = oProvisionalService.Aprobar(IdProvisional, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                    MsgBox("Se Aprobó el Provisional correctamente ")
                                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                End If
                            Else
                                MsgBox("El monto del Provisional supera el límite de Aprobación")
                            End If
                            '============================SIN LÍMITE DE APROBACIÓN===========================
                        Else
                            If MsgBox("¿Está seguro de APROBAR el Provisional N°: " & IdProvisional.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                                estado_process = oProvisionalService.Aprobar(IdProvisional, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                                MsgBox("Se Aprobó el Provisional correctamente ")
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            End If
                        End If
                    End If
                    '================================================================================
                    '=================================RECHAZAR PROVISIONAL===========================
                    '================================================================================
                ElseIf cbRechazar.Checked Then
                    If MsgBox("¿Está seguro de RECHAZAR el Provisional N°: " & IdProvisional.ToString & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        If txtObservacion.Text = "" Then
                            MsgBox("Debe ingresar la Observación")
                            txtObservacion.Focus()
                        Else
                            estado_process = oProvisionalService.Rechazar(IdProvisional, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                            MsgBox("Se rechazó el Provisional correctamente.")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    End If
                End If
                '======================================================================================
                '===========================SIN PERMISO DE APROB/DESPROB PROVISIONAL===================
                '======================================================================================
            Else
                MsgBox("Usted no cuenta con permiso para Aprobar/Desaprobar un Provisional")
            End If
        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar el Provisional : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oProvisionalService.Close()
            oSeguridadService.Close()
            oAsignacionJefesService.Close()
        Catch ex As TimeoutException
            oProvisionalService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
        Catch ex As CommunicationException
            oProvisionalService.Abort()
            oSeguridadService.Abort()
            oAsignacionJefesService.Abort()
        End Try
    End Sub

    Private Sub cbAprobar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAprobar.CheckedChanged
        If cbAprobar.Checked Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
        Else
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRechazar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
        End If
    End Sub
End Class