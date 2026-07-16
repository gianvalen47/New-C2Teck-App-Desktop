Imports System.ServiceModel
Public Class frmRecalcular
    Private ObjCierre As New CierreMesService.CierreMesServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjLocMerca As New LocacionMercaderiaService.LocacionMercaderiaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private dtOficina As New DataTable
    Private dtAlmacen As New DataTable

    Private Sub rbAlmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbAlmacen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnProcesar.Focus()
        End If
    End Sub

    Private Sub rbMercaderia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles rbMercaderia.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtCodigo.Select()
        End If
    End Sub

    Private Sub cbAlmacen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbAlmacen.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            rbAlmacen.Focus()
        End If
    End Sub

    Private Sub frmRecalcular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtCodigo.KeyPress _
        , txtDescripcion.KeyPress _
        , cbOficina.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmRecalcular_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub frmRecalcular_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRecalcular_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 56)
        '/*************************************************************************************/

        ' ccFecCierre.Value = DateSerial(Year(Today), (Month(Today)), 0)
        ccFecCierre.Value = Today
        LlenarCombos()
        cbOficina.Select()
        lblMensaje.Visible = False
        ProgressBar1.Visible = False
        'para Progresbarr
        'With ProgressBar1
        '    .Value = 0
        '    .Minimum = 0
        '    .Maximum = 1000000
        'End With

    End Sub

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
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

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
    Private Sub rbArmado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAlmacen.CheckedChanged, rbMercaderia.CheckedChanged

        If rbMercaderia.Checked Then

            txtCodigo.Enabled = True
            btnBuscar.Enabled = True
        ElseIf rbAlmacen.Checked Then

            txtCodigo.Enabled = False
            btnBuscar.Enabled = False
            txtCodigo.Clear()
            txtDescripcion.Clear()
        End If
    End Sub
    Private Function ValidaCodigo() As Boolean
        Try
            If rbMercaderia.Checked And toBlank(txtCodigo.Text) = "" Then
                MsgBox("Debe Ingresar el código de la mercaderia...!!!", MsgBoxStyle.Information, "Información")
                txtCodigo.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If ValidaCodigo() Then
            If rbMercaderia.Checked Then
                If ObjLocMerca.Buscar(cbAlmacen.Value, txtCodigo.Text) = False Then
                    MsgBox("No existe el Código ingresado, verifique por favor", MsgBoxStyle.Critical, "No Existe")
                    Exit Sub
                End If
            End If
            lblMensaje.Visible = False
            lblMensaje.Enabled = False
            If MsgBox("¿Está Seguro de REALIZAR el proceso de Recalculo?", MsgBoxStyle.YesNo, "Recalcular") = MsgBoxResult.Yes Then
                Try
                    If rbAlmacen.Checked Then
                        lblMensaje.Visible = True
                        lblMensaje.Enabled = True
                        ObjCierre.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                        Timer1.Start()
                        ObjCierre.RecalcularAlmacen(cbAlmacen.Value, ccFecCierre.Value)
                        'Timer1.Enabled = True
                    ElseIf rbMercaderia.Checked Then
                        lblMensaje.Visible = True
                        lblMensaje.Enabled = True
                        ObjCierre.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(50)
                        Timer1.Start()
                        ObjCierre.RecalcularKardex(cbAlmacen.Value, txtCodigo.Text, ccFecCierre.Value)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Proceso")
                End Try
            Else
                lblMensaje.Text = ""
                lblProgreso.Text = ""
                lblMensaje.Visible = False
                ProgressBar1.Visible = False
            End If
        End If
    End Sub

    Private Sub txtCodigo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodigo.Validating
        If ObjLocMerca.Buscar(cbAlmacen.Value, txtCodigo.Text) Then
            Dim Registro As New LocacionMercaderiaService.LocacionMercaderia
            Registro = ObjLocMerca.MostrarPorCodigo(cbAlmacen.Value, txtCodigo.Text)
            txtCodigo.Text = Registro.Mercaderia.CodMer
            txtDescripcion.Text = Registro.Mercaderia.DesMer1
        Else
            txtDescripcion.Text = ""
            MsgBox("Código no existe, verifique por favor.....!!!!", MsgBoxStyle.Critical, "No Existe")
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

            MsgBox("Finalizó el recalculo con éxito", MsgBoxStyle.Information, "Final Exitoso")
        End If

        'If ProgressBar1.Value < 1000 Then
        '    ProgressBar1.Value = ProgressBar1.Value + 100
        'ElseIf ProgressBar1.Value = 1000 Then
        '    Timer1.Enabled = False
        'End If
        '****
        'Timer1.Enabled = True
        'For x = ProgressBar1.Minimum To ProgressBar1.Maximum
        '    lblProgreso.Text = CLng((ProgressBar1.Value * 100) / ProgressBar1.Maximum) & " %"
        '    Application.DoEvents()
        '    ProgressBar1.Value = x
        'Next x
    End Sub
End Class