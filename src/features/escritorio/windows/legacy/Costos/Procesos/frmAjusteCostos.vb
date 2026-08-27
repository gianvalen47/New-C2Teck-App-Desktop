Imports System.ServiceModel
Imports System.Net
Public Class frmAjusteCostos
    Private ObjCierre As New CierreMesService.CierreMesServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjLocMerca As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtOficina As New DataTable
    Private dtAlmacen As New DataTable

    Private Sub LlenarCombos()

        Try
            dtOficina = ObjMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cbOficina.DataSource = dtOficina
            cbOficina.DisplayMember = "DesOfi"
            cbOficina.ValueMember = "CodOfi"
            cbOficina.DropDownList.Columns(0).DataMember = "CodOfi"
            cbOficina.DropDownList.Columns(1).DataMember = "DesOfi"
            cbOficina.SelectedIndex = 0
            dtOficina = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub cbOficina_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOficina.ValueChanged
        Try
            dtAlmacen = ObjMaestro.MostrarLocaciones(Session.sCodEmp, cbOficina.Value, Session.sCodUsu).Tables(0)
            cbAlmacen.DataSource = dtAlmacen
            cbAlmacen.DisplayMember = "DesAlm"
            cbAlmacen.ValueMember = "IdLocacion"
            cbAlmacen.DropDownList.Columns(0).DataMember = "CodAlm"
            cbAlmacen.DropDownList.Columns(1).DataMember = "DesAlm"
            cbAlmacen.SelectedIndex = 0
            dtAlmacen = Nothing
        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub


    Private Sub frmAjusteCostos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtMonto.KeyPress _
            , cbAlmacen.KeyPress _
            , cbOficina.KeyPress _
            , ccFecCierre.KeyPress _
            , rtObservacion.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmAjusteCostos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(ObjCierre) = False Then
                ObjCierre.Close()
            End If
            If isClosed(ObjMaestro) = False Then
                ObjMaestro.Close()
            End If
            If isClosed(ObjLocMerca) = False Then
                ObjLocMerca.Close()
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
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 57)
        '/*************************************************************************************/

        ccFecCierre.Value = DateSerial(Year(Today), (Month(Today) - 1) + 1, 0)
        LlenarCombos()
        rbInsertar.Select()
        lblMensaje.Visible = False
        ProgressBar1.Visible = False
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Dim NomPc As String = Dns.GetHostName
        'Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)
        lblMensaje.Visible = False
        lblMensaje.Enabled = False

        If MsgBox("¿Está seguro de REALIZAR el proceso de Ajuste?", MsgBoxStyle.YesNo, "Ajustar Costos") = MsgBoxResult.Yes Then
            Try

                If rbInsertar.Checked Then
                    lblMensaje.Visible = True
                    lblMensaje.Enabled = True
                    Timer1.Start()
                    ObjCierre.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                    ObjCierre.InsertarAjuste(ccFecCierre.Value, cbAlmacen.Value, txtMonto.Text, rtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                ElseIf rbActualizar.Checked Then
                    lblMensaje.Visible = True
                    lblMensaje.Enabled = True
                    Timer1.Start()
                    ObjCierre.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                    ObjCierre.ActualizarAjuste(ccFecCierre.Value, cbAlmacen.Value, txtMonto.Text, rtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                ElseIf rbBorrar.Checked Then
                    lblMensaje.Visible = True
                    lblMensaje.Enabled = True
                    Timer1.Start()
                    ObjCierre.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                    ObjCierre.BorrarAjuste(ccFecCierre.Value, cbAlmacen.Value, rtObservacion.Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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

    Private Sub rbInsertar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbInsertar.KeyPress, rbActualizar.KeyPress, rbBorrar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cbOficina.Focus()
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