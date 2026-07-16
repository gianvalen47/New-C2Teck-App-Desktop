Imports System.ServiceModel

Public Class frmListaPrecioNuevo_Aprobar

    '===========================Servicios====================================
    Private oListaPrecioCabService As New ListaPrecioCabService.ListaPrecioCabServiceClient

    '======================Declaración de Variables==============================   
    Public IdLista As Integer
    Public IdEstado As Integer
    Public MensajeCodigosPrecio As String
    Private dtCorreos As DataTable
    Public tipoaprobacion As String = ""

    Private Sub frmListaPrecioNuevo_Aprobar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Aprobar la Lista de precio N°:" & IdLista
        btnAprobar.Focus() '------- Agregado el 30/05/2012 -------
        'If IdEstado = 2 Then
        '    Me.Size = New System.Drawing.Size(509, 236)
        '    gbCorreos.Visible = True
        '    'listarCorreos()
        'Else
        '    Me.Size = New System.Drawing.Size(509, 236)
        '    gbCorreos.Visible = False
        'End If
        Me.Size = New System.Drawing.Size(548, 261)
    End Sub

    Private Sub frmListaPrecioNuevo_Aprobar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmListaPrecioNuevo_Aprobar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            oListaPrecioCabService.Close()
        Catch ex As TimeoutException
            oListaPrecioCabService.Abort()
        Catch ex As CommunicationException
            oListaPrecioCabService.Abort()
        End Try
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click

        Try
            Dim estado_process As Boolean
            '=====================================================APROBAR ===========================================
            If cbAprobar.Checked Then
                '=========================================== APROBACION JEFE DE AREA ===================================
                If IdEstado = 2 Then
                    If MsgBox("¿Está seguro de APROBAR la Lista de precio N°: " & IdLista & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                        '================================APROBAR CON CORREOS SELECCIONADOS================================
                        estado_process = oListaPrecioCabService.AprobacionJefe(IdLista, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process Then
                            MsgBox("Se Aprobó la Lista de precios correctamente ")
                            tipoaprobacion = "aprobar"
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        End If
                    End If
                    '========================================= APROBACION GERENCIA ==========================
                Else
                    'If MensajeCodigosPrecio = "" Then
                    '    If MsgBox("¿Está seguro de APROBAR la Lista de precio N°: " & IdLista & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    '        'estado_process = oListaPrecioCabService.AprobacionGerencia(IdLista, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    '        MsgBox("Se Aprobó la Lista de precio correctamente ")
                    '        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    '    End If
                    'Else
                    '    If MsgBox("Estos codigos : " & MensajeCodigosPrecio & "tienen el precio menor que el costo" & Environment.NewLine &
                    '     Environment.NewLine &
                    '    "¿Está seguro de APROBAR la Lista de precio N°: " & IdLista & " ?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    '        'estado_process = oListaPrecioCabService.AprobacionGerencia(IdLista, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    '        MsgBox("Se Aprobó la Lista de precio correctamente ")
                    '        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    '    End If
                    'End If
                End If
                '======================================================RECHAZAR ==========================================
            ElseIf cbRechazar.Checked Then
                If txtObservacion.Text = "" Then
                    MsgBox("Debe ingresar la observación")
                    txtObservacion.Focus()
                Else
                    If MsgBox("¿Está seguro de RECHAZAR la Lista de precio N°:" & IdLista & "?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then

                    estado_process = oListaPrecioCabService.Rechazar(IdLista, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        If estado_process Then
                            MsgBox("Se rechazó la lista de precio correctamente ")
                            tipoaprobacion = "rechazar"
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al aprobar/desaprobar la Lista de precio : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cbAprobar_CheckedChanged(sender As Object, e As EventArgs) Handles cbAprobar.CheckedChanged
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

    Private Sub cbRechazar_CheckedChanged(sender As Object, e As EventArgs) Handles cbRechazar.CheckedChanged
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