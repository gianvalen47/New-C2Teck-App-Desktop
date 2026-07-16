Imports System.ServiceModel

Public Class frmListaPrecioCliente_Aprobar

    '===========================Servicios====================================
    Private oListaPrecioClienteService As New ListaPrecioClienteService.ListaPrecioClienteServiceClient

    '======================Declaración de Variables==============================   
    Public IdLista As Integer
    Public IdEstado As Integer
    Public MensajeCodigosPrecio As String
    Private dtCorreos As DataTable

    Private Sub frmListaPrecioCliente_Aprobar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioClienteService.Close()
        Catch ex As TimeoutException
            oListaPrecioClienteService.Abort()
        Catch ex As CommunicationException
            oListaPrecioClienteService.Abort()
        End Try
    End Sub

    Private Sub frmListaPrecioCliente_Aprobar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioCliente_Aprobar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Aprobar la Lista de precio N°:" & IdLista
        btnAprobar.Focus() '------- Agregado el 30/05/2012 -------
        'If IdEstado = 2 Then
        Me.Size = New System.Drawing.Size(509, 236)
        'gbCorreos.Visible = True
        '    'listarCorreos()
        'Else
        '    Me.Size = New System.Drawing.Size(509, 236)
        '    gbCorreos.Visible = False
        'End If
    End Sub



    Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click

        Try
            Dim estado_process As Boolean
            '=====================================================APROBAR ===========================================
            If cbAprobar.Checked Then
                '=========================================== APROBACION JEFE DE AREA ===================================
                If IdEstado = 2 Then
                    If MsgBox("¿Está seguro de APROBAR la Lista de precio N°: " & IdLista & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                        '================================APROBAR CON CORREOS SELECCIONADOS================================
                        estado_process = oListaPrecioClienteService.Aprobar(IdLista, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process Then
                            MsgBox("Se Aprobó la Lista de precios correctamente ")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    End If
                    '========================================= APROBACION GERENCIA ==========================
                Else
                    If MensajeCodigosPrecio = "" Then
                        If MsgBox("¿Está seguro de APROBAR la Lista de precio N°: " & IdLista & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                            estado_process = oListaPrecioClienteService.Aprobar(IdLista, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                            MsgBox("Se Aprobó la Lista de precio correctamente ")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If

                    Else
                        If MsgBox("Estos codigos : " & MensajeCodigosPrecio & "tienen el precio menor que el costo" & Environment.NewLine &
                         Environment.NewLine &
                        "¿Está seguro de APROBAR la Lista de precio N°: " & IdLista & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                            estado_process = oListaPrecioClienteService.Aprobar(IdLista, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                            MsgBox("Se Aprobó la Lista de precio correctamente ")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If

                    End If

                End If
                '======================================================RECHAZAR ==========================================
            ElseIf cbRechazar.Checked Then
                If MsgBox("¿Está seguro de RECHAZAR la Lista de precio N°:" & IdLista & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    If txtObservacion.Text = "" Then
                        MsgBox("Debe ingresar la observación")
                        txtObservacion.Focus()
                    Else
                        estado_process = oListaPrecioClienteService.Rechazar(IdLista, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process Then
                            MsgBox("Se rechazó la lista de precio correctamente ")
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la Lista de precio : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbAprobar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAprobar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            txtObservacion.Focus() '----Agregado el 30/05/2012----
        ElseIf cbAprobar.Checked And IdEstado = 8 Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus() '----Agregado el 30/05/2012----
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus() '----Agregado el 30/05/2012----
        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRechazar.CheckedChanged
        If cbRechazar.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            txtObservacion.Focus() '------Agregado el 30/05/2012-------
        ElseIf cbAprobar.Checked And IdEstado = 8 Then
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus() '------Agregado el 30/05/2012-------
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            btnAprobar.Focus() '------Agregado el 30/05/2012-------
        End If
    End Sub
End Class