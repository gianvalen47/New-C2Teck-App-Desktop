Imports System.ServiceModel

Public Class frmSepararOrden_Aprobar


    Private oOrdenCompraDetService As New OrdenCompraDetService.OrdenCompraDetServiceClient
    Private oOrdenCompraService As New OrdenCompraService.OrdenCompraServiceClient

    Public IdOrden As Integer
    Public NumOrden As String
    Private dtDatos As DataTable

    Private estado As String

    Private Sub frmSepararOrden_Aprobar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmSepararOrden_Aprobar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmSepararOrden_Aprobar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        Me.Text = "Aprobar la Orden de Compra N°:" & NumOrden
        btnAprobar.Focus()

        ListaDatos()


    End Sub

    Private Sub ListaDatos()

        Try
            dtDatos = oOrdenCompraDetService.MostrarParaAprobarSeparar(toNumber(IdOrden)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            'enableOpciones()

        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Aprobar()
        Try
            Dim estado_process As Boolean
            estado_process = oOrdenCompraDetService.AprobarSeparar(IdOrden, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            'type_process = "update"
            If estado_process = True Then
                MsgBox("Se aprobo la separación en la Orden de Compra", MsgBoxStyle.Information, "Información")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Rechazar()
        Try

            Dim estado_process As Boolean
                estado_process = oOrdenCompraDetService.RechazarSeparar(IdOrden, toBlank(txtObservacion.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                'type_process = "update"
                If estado_process = True Then
                    MsgBox("Se rechazo la separación en la Orden de Compra", MsgBoxStyle.Information, "Información")
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If



        Catch ex As Exception
            MsgBox("ERROR [AGRE-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            estado = oOrdenCompraService.Estado(IdOrden)
            If toNumber(IdOrden) = 0 Then
                MsgBox("Debe Ingresar el código de la orden. ", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf estado = "GENERADO" Then
                MsgBox("Orden de Compra no esta enviado para aprobar.", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf estado = "APROBADO" Then
                MsgBox("Orden de Compra ya fue Aprobado.", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [AGRE-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub cbAprobar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbAprobado.CheckedChanged
        If rbRechazado.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            'Me.Size = New System.Drawing.Size(509, 236)
            txtObservacion.Focus()
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            'Me.Size = New System.Drawing.Size(509, 236)
            btnAprobar.Focus()
        End If
    End Sub

    Private Sub cbRechazar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbRechazado.CheckedChanged
        If rbRechazado.Checked Then
            btnAprobar.Text = "Rechazar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Rechazar_1
            'Me.Size = New System.Drawing.Size(509, 236)
            txtObservacion.Focus()
        Else
            btnAprobar.Text = "Aprobar"
            btnAprobar.Image = SIGECOM.My.Resources.Resources.Aceptar
            'Me.Size = New System.Drawing.Size(509, 236)
            btnAprobar.Focus()
        End If
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click

        If ValidaCampos() Then
            If rbAprobado.Checked = True Then

                If MsgBox("¿Está seguro de APROBAR la Orden de compra?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                    Aprobar()

                End If


            ElseIf rbRechazado.Checked = True Then

                If txtObservacion.Text = "" Then
                    MsgBox("Debe Ingresar la Observacion del Rechazo", MsgBoxStyle.Information, "Información")
                Else

                    If MsgBox("¿Está seguro de RECHAZAR la Orden de compra?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                        Rechazar()

                    End If
                End If
            End If
            'Aprobar()
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Finalizar()
        Me.Close()
    End Sub

    Private Sub Finalizar()
        Try
            oOrdenCompraService.Close()
            oOrdenCompraDetService.Close()
        Catch ex As TimeoutException
            oOrdenCompraService.Abort()
            oOrdenCompraDetService.Abort()
        Catch ex As CommunicationException
            oOrdenCompraService.Abort()
            oOrdenCompraDetService.Abort()
        End Try
    End Sub

End Class