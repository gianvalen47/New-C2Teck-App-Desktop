Imports System.Net
Imports System.ServiceModel
Public Class frmTrasladarCostos

    Private dtOficinasOri As DataTable
    Private dtAlmacenesOri As DataTable
    Private dtOficinasDes As DataTable
    Private dtAlmacenesDes As DataTable
    Private oMaestro As New MaestroService.MaestroClient
    Private oDocumentoCostoService As New DocumentoCostoService.DocumentoCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient

    Private Sub frmTrasladarCostos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cbFecInicio.KeyPress _
            , cbFecFinal.KeyPress _
            , cmbIdLocacionOri.KeyPress _
            , cmbOficinasOri.KeyPress _
            , cmbOficinasDes.KeyPress _
            , rbPorOficina.KeyPress _
            , rbPorLima.KeyPress
        ' , cmbIdLocacionDes.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmTrasladarCostos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestro.Close()
            oDocumentoCostoService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestro.Abort()
            oDocumentoCostoService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestro.Abort()
            oDocumentoCostoService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmTrasladarCostos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub cmbIdLocacionDes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbIdLocacionDes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnAceptar.Select()
        End If
    End Sub

    Private Sub rbPorOficina_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            cmbOficinasOri.Focus()

        End If
    End Sub

    Private Sub frmTrasladarCostos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 82)
        '/*************************************************************************************/

        Dim Mes, Anio, meses As Integer
        Dim Fecha As Date

        Fecha = Today
        meses = Month(Today)
        If meses = 1 Then
            Mes = Month(Today)
            Anio = Year(Today)
        Else
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        End If
        cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
        cbFecFinal.Value = Fecha
        llenarCombos()
        cbFecInicio.Select()
        lblMensaje.Visible = False
        ProgressBar1.Visible = False

    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= Oficinas ================================================
            dtOficinasOri = oMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbOficinasOri.DataSource = dtOficinasOri
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinasOri.DropDownList.DisplayMember = dtOficinasOri.Columns("DesOfi").ToString
            cmbOficinasOri.DropDownList.ValueMember = dtOficinasOri.Columns("CodOfi").ToString
            cmbOficinasOri.DropDownList.Columns(0).DataMember = dtOficinasOri.Columns("CodOfi").ToString
            cmbOficinasOri.DropDownList.Columns(1).DataMember = dtOficinasOri.Columns("DesOfi").ToString
            cmbOficinasOri.SelectedIndex = 0
            dtOficinasOri = Nothing

            '======================================= Oficinas ================================================
            dtOficinasDes = oMaestro.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbOficinasDes.DataSource = dtOficinasDes
            'cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinasDes.DropDownList.DisplayMember = dtOficinasDes.Columns("DesOfi").ToString
            cmbOficinasDes.DropDownList.ValueMember = dtOficinasDes.Columns("CodOfi").ToString
            cmbOficinasDes.DropDownList.Columns(0).DataMember = dtOficinasDes.Columns("CodOfi").ToString
            cmbOficinasDes.DropDownList.Columns(1).DataMember = dtOficinasDes.Columns("DesOfi").ToString
            cmbOficinasDes.SelectedIndex = 0
            dtOficinasDes = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub
    Private Function ValidaCampos() As Boolean
        Try
            If (cmbIdLocacionOri.Value = cmbIdLocacionDes.Value) And rbPorOficina.Checked Then
                MsgBox("No puede trasladar al mismo almacén...!!!", MsgBoxStyle.Information, "Información")
                cmbOficinasOri.Select()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        lblMensaje.Visible = False
        lblMensaje.Enabled = False
        Try
            If MsgBox("¿Está seguro de TRASLADAR los costos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then

                Dim NomPc As String = Dns.GetHostName
                Dim DirIp As IPHostEntry = Dns.GetHostEntry(NomPc)

                Dim estado_process As Boolean
                lblMensaje.Visible = True
                lblMensaje.Enabled = True
                oDocumentoCostoService.InnerChannel.OperationTimeout = TimeSpan.FromMinutes(10)
                estado_process = oDocumentoCostoService.TrasladarCostos(Session.sCodEmp, cbFecInicio.Value, cbFecFinal.Value, IIf(gbOrigen.Enabled = False, 0, cmbIdLocacionOri.Value), IIf(gbDestino.Enabled = False, 0, cmbIdLocacionDes.Value), Session.sCodUsu, NomPc, DirIp.AddressList(0).ToString)
                If estado_process Then
                    '    MsgBox("Se realizo correctamente el traslado")
                    Timer1.Start()
                Else
                    MsgBox("No se realizó el traslado")
                    cbFecInicio.Select()
                End If
            Else
                lblMensaje.Text = ""
                lblProgreso.Text = ""
                lblMensaje.Visible = False
                ProgressBar1.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub cmbOficinasOri_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinasOri.ValueChanged
        Try

            '======================================= ALMACENES ================================================
            dtAlmacenesOri = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinasOri.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacionOri.DataSource = dtAlmacenesOri
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacionOri.DropDownList.DisplayMember = dtAlmacenesOri.Columns("DesAlm").ToString
            cmbIdLocacionOri.DropDownList.ValueMember = dtAlmacenesOri.Columns("IdLocacion").ToString
            cmbIdLocacionOri.DropDownList.Columns(0).DataMember = dtAlmacenesOri.Columns("IdLocacion").ToString
            cmbIdLocacionOri.DropDownList.Columns(1).DataMember = dtAlmacenesOri.Columns("DesAlm").ToString
            If dtAlmacenesOri.Rows.Count > 0 Then
                cmbIdLocacionOri.SelectedIndex = 0
            Else
                cmbIdLocacionOri.Value = ""
            End If
            dtAlmacenesOri = Nothing

        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub cmbOficinasDes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinasDes.ValueChanged
        Try
            '======================================= ALMACENES ================================================
            dtAlmacenesDes = oMaestro.MostrarLocaciones(Session.sCodEmp, cmbOficinasDes.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacionDes.DataSource = dtAlmacenesDes
            'cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacionDes.DropDownList.DisplayMember = dtAlmacenesDes.Columns("DesAlm").ToString
            cmbIdLocacionDes.DropDownList.ValueMember = dtAlmacenesDes.Columns("IdLocacion").ToString
            cmbIdLocacionDes.DropDownList.Columns(0).DataMember = dtAlmacenesDes.Columns("IdLocacion").ToString
            cmbIdLocacionDes.DropDownList.Columns(1).DataMember = dtAlmacenesDes.Columns("DesAlm").ToString
            If dtAlmacenesDes.Rows.Count > 0 Then
                cmbIdLocacionDes.SelectedIndex = 0
            Else
                cmbIdLocacionDes.Value = ""
            End If
            dtAlmacenesDes = Nothing
        Catch ex As Exception
            MsgBox("Error al Cargar Almacenes", MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub rbArmado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPorLima.CheckedChanged, rbPorOficina.CheckedChanged
        If rbPorLima.Checked Then
            gbOrigen.Enabled = False
            gbDestino.Enabled = False
        ElseIf rbPorOficina.Checked Then
            gbOrigen.Enabled = True
            gbDestino.Enabled = True
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
            MsgBox("Se realizó el traslado correctamente ", MsgBoxStyle.Information, "Final Exitoso")
        End If
    End Sub
End Class