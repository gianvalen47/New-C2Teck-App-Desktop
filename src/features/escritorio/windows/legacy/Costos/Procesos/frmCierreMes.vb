Imports System.Net
Imports System.ServiceModel
Public Class frmCierreMes
    Dim ObjCierre As New CierreMesService.CierreMesServiceClient
    Dim Cierre As New CierreMesService.CierreMes
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private Sub frmCierreMes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Focus()
        End If
    End Sub

    Private Sub frmCierreMes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjCierre) = False Then
                ObjCierre.Close()
            End If
            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmCierreMes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmCierreMes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 58)
        '/*************************************************************************************/

        ' txtFecCierre.ValidatingType = GetType(System.DateTime)
        ' txtFecCierre.Text = DateSerial(Year(Today), (Month(Today) - 1) + 1, 0)
        dtFecCierre.Value = DateSerial(Year(Today), (Month(Today) - 1) + 1, 0)
        rbDocumento.Select()
        lblMensaje.Visible = False
        ProgressBar1.Visible = False


        '/*************************************************************************************/
        'Se realiza cambio a pedido de Sr. Guiliano y con aprobación de Yudith Tenorio 
        'se le da acceso al perfil Asistente Comercial (Equimap) pero solo al cierre de Documentos        
        If Session.CodPerfil = "14" And Session.sCodEmp = "05" Then
            rbDocumento.Visible = True
            rbCostos.Visible = False
            rbImportaciones.Visible = False
        Else
            rbDocumento.Visible = True
            rbCostos.Visible = True
            rbImportaciones.Visible = True
        End If
        '/*************************************************************************************/

    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        lblMensaje.Visible = False
        lblMensaje.Enabled = False
        If MsgBox("¿Está seguro de CERRAR los movimientos del mes?", MsgBoxStyle.YesNo, "Cerrar") = MsgBoxResult.Yes Then
            Try
                Dim empresa As New CierreMesService.Empresa
                Dim Tipo As Integer
                'Dim NomPc As String = Dns.GetHostName
                'Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
                Cierre.Periodo = Year(dtFecCierre.Value)
                Cierre.Mes = Month(dtFecCierre.Value)
                lblMensaje.Visible = True
                lblMensaje.Enabled = True
                If rbDocumento.Checked Then
                    Tipo = 1
                ElseIf rbCostos.Checked Then
                    Tipo = 2
                ElseIf rbImportaciones.Checked Then
                    Tipo = 3
                End If
                Cierre.Tipo = Tipo
                Cierre.FecCierre = dtFecCierre.Value
                Cierre.CodUsu = Session.sCodUsu
                Cierre.Estacion = Session.sNomPc
                Cierre.DirIp = Session.sDirIp
                empresa.CodEmp = Session.sCodEmp
                Cierre.Empresa = empresa
                ObjCierre.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(30)
                If rbCerrar.Checked Then
                    If ObjCierre.Insertar(Cierre) Then
                        'MsgBox("Se Cerro el Mes con exito", MsgBoxStyle.Information, "Exito")
                        Timer1.Start()
                        Close()
                    End If
                Else
                    If ObjCierre.RevertirCierre(Session.sCodEmp, Cierre.Periodo, Cierre.Mes, Tipo, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                        Timer1.Start()
                        'MsgBox("Se a revertido el cierre", MsgBoxStyle.Information, "Exito")
                        Close()
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            lblMensaje.Text = ""
            lblProgreso.Text = ""
            lblMensaje.Visible = False
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rbDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbDocumento.KeyPress, rbCostos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            dtFecCierre.Focus()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblMensaje.Visible = False
        ProgressBar1.Visible = True
        ProgressBar1.Value += 20
        lblProgreso.Text = CLng((ProgressBar1.Value * 100) / ProgressBar1.Maximum) & "%"
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            ProgressBar1.Value = 0
            lblProgreso.Text = ""
            ProgressBar1.Visible = False
            If rbCerrar.Checked Then
                MsgBox("Se Cerró el Mes con exito", MsgBoxStyle.Information, "Final Exitoso")
            Else
                MsgBox("Se Revertio el Mes con exito", MsgBoxStyle.Information, "Final Exitoso")
            End If

        End If
    End Sub

   
End Class