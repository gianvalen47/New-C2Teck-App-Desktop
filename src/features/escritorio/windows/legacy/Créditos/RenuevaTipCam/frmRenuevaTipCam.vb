Imports System.ServiceModel
Imports System.Net
Public Class frmRenuevaTipCam
    Private ObjTC As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient

    Private oSeguridadService As New SeguridadService.SeguridadClient



    Private Sub frmAjusteCostos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtMonto.KeyPress _
 _
 _
            , ccFecCierre.KeyPress


        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmAjusteCostos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjTC) = False Then
                ObjTC.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmAjusteCostos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAjusteCostos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmAjusteCostos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 304)
        '/*************************************************************************************/

        ccFecCierre.Value = DateSerial(Year(Today), (Month(Today) - 1) + 1, 0)

        rbInsertar.Select()
        lblMensaje.Visible = False
        ProgressBar1.Visible = False
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Dim NomPc As String = Dns.GetHostName
        'Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
        lblMensaje.Visible = False
        lblMensaje.Enabled = False

        If MsgBox("¿Está seguro de REALIZAR el proceso?", MsgBoxStyle.YesNo, "Renovar Tipo de Cambio") = MsgBoxResult.Yes Then
            Try

                If rbInsertar.Checked Then
                    lblMensaje.Visible = True
                    lblMensaje.Enabled = True
                    Timer1.Start()
                    ObjTC.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                    ObjTC.RenuevaTipCam(Session.sCodEmp, ccFecCierre.Value, txtMonto.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp, 1)
                ElseIf rbActualizar.Checked Then
                    lblMensaje.Visible = True
                    lblMensaje.Enabled = True
                    Timer1.Start()
                    ObjTC.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                    ObjTC.RenuevaTipCam(ccFecCierre.Value, ccFecCierre.Value, txtMonto.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp, 2)

                End If
                'MsgBox("Finalizo el Proceso con exito", MsgBoxStyle.Information, "Final Exitoso")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Proceso")
            End Try
        Else
            lblMensaje.Text = ""
            lblProgreso.Text = ""
            lblMensaje.Visible = False
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbInsertar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbInsertar.KeyPress, rbActualizar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtMonto.Focus()
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblMensaje.Visible = False
        ProgressBar1.Visible = True
        ProgressBar1.Value += 20
        lblProgreso.Text = CLng((ProgressBar1.Value * 100) / ProgressBar1.Maximum) & " %"
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            ProgressBar1.Value = 0
            lblProgreso.Text = ""
            ProgressBar1.Visible = False
            MsgBox("Finalizó el Proceso con éxito", MsgBoxStyle.Information, "Final Exitoso")
        End If
    End Sub
End Class