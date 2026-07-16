Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmPlanillaDet
    Protected Friend pIdPlanillaDet As Integer
    Protected Friend pIdPlanilla As Integer
    Private ObjPlanillaDet As New PlanillaDetalleService.PlanillaDetalleServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjCtaCte As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private PlanillaDetalle As New PlanillaDetalleService.PlanillaDetalle
    Private dtMotivo As New DataTable
    Private dtDocumento As New DataTable
    Private IdDocCtaCte As Int64 = 0
    Private IdVenta, TipDoc As Integer
    Private Transa As String = "" '(I = Insertar, U = Actualizar, M = Mostrar)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
       

        If MsgBox("¿Está seguro de GRABAR los datos?", MsgBoxStyle.YesNo, "Grabar") = MsgBoxResult.Yes Then

            Try

                Dim Registro As New PlanillaDetalleService.PlanillaDetalle
                Dim Planilla As New PlanillaDetalleService.Planilla
                Dim DocumentoCredito As New PlanillaDetalleService.VDocumentoCredito
                Dim DocumentoCtaCte As New PlanillaDetalleService.DocumentoCtaCte


                Select Case Transa
                    Case "I"
                        Dim MotivoPago As New PlanillaDetalleService.MotivoPago

                        Dim Serie As New PlanillaDetalleService.SerieDocumento
                        Planilla.IdPlanilla = pIdPlanilla
                        Registro.Planilla = Planilla
                        DocumentoCredito.IdVenta = IdVenta
                        DocumentoCredito.TipDoc = TipDoc
                        Registro.VDocumentoCredito = DocumentoCredito

                        Serie.IdSerieDoc = cbDocumento.Value
                        DocumentoCtaCte.IdDocCtaCte = IdDocCtaCte
                        DocumentoCtaCte.SerieDocumento = Serie
                        DocumentoCtaCte.NumDoc = txtNumDoc.Text
                        Registro.DocumentoCtaCte = DocumentoCtaCte
                        MotivoPago.IdMotPag = cbMotivo.Value
                        Registro.MotivoPago = MotivoPago
                        Registro.DolPag = txtPagarDol.Text
                        Registro.SolPag = txtPagarSol.Text

                        Registro.CodUsu = Session.sCodUsu
                        Registro.DirIp = Session.sDirIp
                        Registro.NomPc = Session.sNomPc

                        pIdPlanillaDet = ObjPlanillaDet.Insertar(Registro)
                    Case "U"
                        '   MostrarDocumento()
                        Registro.IdPlanillaDet = pIdPlanillaDet
                        Planilla.IdPlanilla = pIdPlanilla
                        Registro.Planilla = Planilla
                        DocumentoCredito.IdVenta = IdVenta
                        DocumentoCredito.TipDoc = TipDoc
                        Registro.VDocumentoCredito = DocumentoCredito
                        DocumentoCtaCte.IdDocCtaCte = IdDocCtaCte
                        Registro.DocumentoCtaCte = DocumentoCtaCte
                        Registro.DolPag = txtPagarDol.Text
                        Registro.SolPag = txtPagarSol.Text

                        Registro.CodUsu = Session.sCodUsu
                        Registro.DirIp = Session.sDirIp
                        Registro.NomPc = Session.sNomPc

                        ObjPlanillaDet.Actualizar(Registro)
                End Select
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Grabar")
            End Try
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmPlanillaDet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjMaestro.Close()
            ObjPlanillaDet.Close()
            ObjCtaCte.Close()
        Catch ex As TimeoutException
            ObjMaestro.Abort()
            ObjPlanillaDet.Abort()
            ObjCtaCte.Close()
        Catch ex As CommunicationException
            ObjMaestro.Abort()
            ObjPlanillaDet.Abort()
            ObjCtaCte.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmPlanillaDet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub

    Private Sub cbMotivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbMotivo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cbDocumento.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub cbDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbDocumento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtNumDoc.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtNumDoc.Text <> "" Then
                MostrarDocumento()
                ' OK_Button.Enabled = True
            End If
        End If
    End Sub
    Private Sub txtPagarDol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPagarDol.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            OK_Button.Select()
            e.Handled = True
        End If
    End Sub

    Private Sub frmPlanillaDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombos()
        MostrarDatos()
    End Sub

    Protected Friend Sub MostrarDatos()
        Dim TC As Double = 0
        Try
            If Transa <> "I" Then
                PlanillaDetalle = ObjPlanillaDet.MostrarPorId(pIdPlanillaDet)
                IdDocCtaCte = PlanillaDetalle.DocumentoCtaCte.IdDocCtaCte
                cbMotivo.Value = PlanillaDetalle.MotivoPago.IdMotPag
                cbDocumento.Value = PlanillaDetalle.DocumentoCtaCte.SerieDocumento.IdSerieDoc
                txtSerie.Text = PlanillaDetalle.DocumentoCtaCte.SerieDocumento.CodSerie
                txtNumDoc.Text = PlanillaDetalle.DocumentoCtaCte.NumDoc
                txtCliente.Text = PlanillaDetalle.DocumentoCtaCte.Cliente.DesCli
                txtFecha.Text = PlanillaDetalle.DocumentoCtaCte.FecDoc
                txtMoneda.Text = PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon
                TC = PlanillaDetalle.DocumentoCtaCte.TipCam  'ObjMaestro.MostrarTipoCambio("US", PlanillaDetalle.DocumentoCtaCte.FecDoc)
                txtTipoCambio.Text = TC
                txtTotalDocDol.Text = PlanillaDetalle.DocumentoCtaCte.TotDol
                txtTotalDocSol.Text = PlanillaDetalle.DocumentoCtaCte.TotSol
                txtTotalPagoDol.Text = PlanillaDetalle.DocumentoCtaCte.DolPag
                txtTotalPagoSol.Text = PlanillaDetalle.DocumentoCtaCte.SolPag
                txtPagarDol.Text = PlanillaDetalle.DolPag
                txtPagarSol.Text = PlanillaDetalle.SolPag
                txtPagarDol.Enabled = IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "US" Or PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "EU" And Transa <> "", True, False)
                txtPagarSol.Enabled = IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "NS" And Transa <> "", True, False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Protected Friend Sub NuevoRegistro()
        Transa = "I"
        cbMotivo.Enabled = True
        cbDocumento.Enabled = True
        txtNumDoc.ReadOnly = False
        cbDocumento.Focus()
        OK_Button.Visible = True
    End Sub

    Protected Friend Sub ModificarRegistro()
        Transa = "U"
        txtNumDoc.ReadOnly = False
        txtPagarDol.Enabled = True
        OK_Button.Enabled = True
        OK_Button.Visible = True
        txtPagarDol.Focus()
    End Sub

    Private Sub LlenarCombos()

        Try
            dtMotivo = ObjPlanillaDet.MostrarMotivoPago.Tables(0)
            cbMotivo.DataSource = dtMotivo
            cbMotivo.DisplayMember = "DesMot"
            cbMotivo.ValueMember = "IdMotPag"
            cbMotivo.DropDownList.Columns(0).DataMember = "IdMotPag"
            cbMotivo.DropDownList.Columns(1).DataMember = "DesMot"
            cbMotivo.SelectedIndex = 0
            dtMotivo = Nothing

            dtDocumento = ObjPlanillaDet.MostrarSerieDocumentoCtaCte(Session.sCodEmp).Tables(0)
            cbDocumento.DataSource = dtDocumento
            cbDocumento.DisplayMember = "Descripcion"
            cbDocumento.ValueMember = "IdSerieDoc"
            cbDocumento.DropDownList.Columns(0).DataMember = "IdSerieDoc"
            cbDocumento.DropDownList.Columns(1).DataMember = "Descripcion"
            'dtDocumento = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Protected Friend Sub MostrarDocumento()
        Dim TC As Double = 0
        Try

            If ObjPlanillaDet.BuscarDocCtaCte(cbMotivo.Value, cbDocumento.Value, IIf(txtNumDoc.Text = "", 0, txtNumDoc.Text)) Then
                Dim DocumentoCte As New DocumentoCtaCtesService.DocumentoCtaCte
                DocumentoCte = ObjCtaCte.ObtenerDocumento(cbMotivo.Value, cbDocumento.Value, txtNumDoc.Text)

                txtCliente.Text = DocumentoCte.Cliente.DesCli
                txtFecha.Text = DocumentoCte.FecDoc
                txtMoneda.Text = DocumentoCte.Moneda.CodMon
                TC = DocumentoCte.TipCam  'ObjMaestro.MostrarTipoCambio("US", DocumentoCte.FecDoc)
                txtTipoCambio.Text = TC
                txtTotalDocDol.Text = DocumentoCte.TotDol
                txtTotalDocSol.Text = DocumentoCte.TotSol
                txtTotalPagoDol.Text = DocumentoCte.DolPag
                txtTotalPagoSol.Text = DocumentoCte.SolPag
                IdDocCtaCte = DocumentoCte.IdDocCtaCte
                IdVenta = DocumentoCte.VDocumentoCredito.IdVenta
                TipDoc = DocumentoCte.TipDoc

                txtPagarDol.Text = txtTotalDocDol.Text - txtTotalPagoDol.Text
                txtPagarSol.Text = txtTotalDocSol.Text - txtTotalPagoSol.Text

                If DocumentoCte.Moneda.CodMon = "US" Or DocumentoCte.Moneda.CodMon = "EU" Then
                    txtPagarDol.Enabled = True
                    txtPagarSol.Enabled = False
                    txtPagarDol.Select()
                Else
                    txtPagarDol.Enabled = False
                    txtPagarSol.Enabled = True
                    txtPagarSol.Select()
                End If

            ElseIf ObjPlanillaDet.BuscarDocumento(cbDocumento.Value, IIf(txtNumDoc.Text = "", 0, txtNumDoc.Text)) And cbMotivo.Value = 4 Then
                Dim Documento As New PlanillaDetalleService.VDocumentoCredito
                Documento = ObjPlanillaDet.MostrarPorDoc(cbDocumento.Value, txtNumDoc.Text)
                IdVenta = Documento.IdVenta
                TipDoc = Documento.TipDoc
                txtCliente.Text = Documento.Cliente.DesCli
                txtFecha.Text = Documento.FecDoc
                txtMoneda.Text = Documento.Moneda.CodMon
                TC = ObjMaestro.MostrarTipoCambio("US", Documento.FecDoc)
                txtTipoCambio.Text = TC
                txtTotalDocDol.Text = IIf(Documento.Moneda.CodMon = "US" Or Documento.Moneda.CodMon = "EU", Documento.TotNeto, 0)
                txtTotalDocSol.Text = IIf(Documento.Moneda.CodMon = "US" Or Documento.Moneda.CodMon = "EU", Documento.TotNeto * TC, Documento.TotNeto)
                txtTotalPagoDol.Text = 0
                txtTotalPagoSol.Text = 0
                txtPagarDol.Text = IIf(Documento.Moneda.CodMon = "US" Or Documento.Moneda.CodMon = "EU", Documento.TotNeto, 0) '0
                txtPagarSol.Text = IIf(Documento.Moneda.CodMon = "US" Or Documento.Moneda.CodMon = "EU", Documento.TotNeto * TC, Documento.TotNeto) '0

                If Documento.Moneda.CodMon = "US" Or Documento.Moneda.CodMon = "EU" Then
                    txtPagarDol.Enabled = True
                    txtPagarSol.Enabled = False
                    txtPagarDol.Select()
                Else
                    txtPagarDol.Enabled = False
                    txtPagarSol.Enabled = True
                    txtPagarSol.Select()
                End If
            Else

                MsgBox("No Existe este documento, Verifique.!!!!!", MsgBoxStyle.Information, "No Existe")
            End If

         
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    'Private Sub txtNumDoc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumDoc.KeyUp
    '    If e.KeyCode = Keys.Enter Then
    '        If txtNumDoc.Text <> "" Then
    '            MostrarDocumento()
    '            ' OK_Button.Enabled = True
    '        End If
    '    End If
    'End Sub

    Private Sub cbDocumento_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDocumento.ValueChanged
        Try
            If Transa = "I" Then
                txtSerie.Text = IIf(IsDBNull(dtDocumento.Rows(cbDocumento.SelectedIndex).Item("CodSerie")), Nothing, dtDocumento.Rows(cbDocumento.SelectedIndex).Item("CodSerie"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de combo")
        End Try
    End Sub

    'Private Sub txtPagarDol_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPagarDol.KeyUp
    '    If e.KeyCode = Keys.Enter Then
    '        Cancel_Button.Focus()
    '    End If
    'End Sub

    Private Sub txtPagarDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPagarDol.Validating
        Dim valor As Double = txtPagarDol.Text
        If valor = 0 Then
            MsgBox("Ingrese el monto en Dolares....", MsgBoxStyle.Information, "Ingrese Monto")
            OK_Button.Enabled = False
        Else
            If cbMotivo.Value = "1" Or cbMotivo.Value = "2" Or cbMotivo.Value = "3" Then
                Dim total As Double = Math.Round(txtTotalDocDol.Text - txtTotalPagoDol.Text, 2)

                If total > valor Then
                    txtPagarSol.Text = Math.Round(valor * txtTipoCambio.Text, 2)
                    OK_Button.Enabled = True
                ElseIf total = valor Then
                    txtPagarSol.Text = Math.Round(txtTotalDocSol.Text - txtTotalPagoSol.Text, 2)
                    OK_Button.Enabled = True
                ElseIf valor > total Then
                    MsgBox("No puede asignar un monto mas de lo que se debe", MsgBoxStyle.Information, "Monto Mayor")
                    OK_Button.Enabled = False
                    txtPagarDol.Focus()
                End If
            Else
                txtPagarSol.Text = Math.Round(valor * txtTipoCambio.Text, 2)
                OK_Button.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtPagarSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPagarSol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            OK_Button.Select()
            e.Handled = True
        End If
    End Sub

    'Private Sub txtPagarSol_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPagarSol.KeyUp
    '    If e.KeyCode = Keys.Enter Then
    '        Cancel_Button.Focus()
    '    End If
    'End Sub

    '-----------Se comento el 09/01/2012 porque no estaba validando que no se puede ingresar un monto mayor al que se debe------------
    'Private Sub txtPagarSol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPagarSol.Validating
    '    Dim valor As Double = txtPagarSol.Text
    '    If valor = 0 Then
    '        MsgBox("Ingrese el monto en Soles....", MsgBoxStyle.Information, "Ingrese Monto")
    '        OK_Button.Enabled = False
    '    Else
    '        txtPagarDol.Text = 0
    '        OK_Button.Enabled = True
    '    End If
    'End Sub
    '---------------------------------------------------------------------------------------------------------------------------------

    Private Sub txtPagarSol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPagarSol.Validating
        Dim valor As Double = txtPagarSol.Text
        If valor = 0 Then
            MsgBox("Ingrese el monto en Soles....", MsgBoxStyle.Information, "Ingrese Monto")
            OK_Button.Enabled = False
        Else
            If cbMotivo.Value = "1" Or cbMotivo.Value = "2" Or cbMotivo.Value = "3" Then
                Dim total As Double = Math.Round(txtTotalDocSol.Text - txtTotalPagoSol.Text, 2)
                If valor > total Then
                    MsgBox("No puede asignar un monto mas de lo que se debe", MsgBoxStyle.Information, "Monto Mayor")
                    OK_Button.Enabled = False
                    txtPagarDol.Focus()
                Else
                    txtPagarDol.Text = 0
                    OK_Button.Enabled = True
                End If
            Else
                txtPagarDol.Text = 0
                OK_Button.Enabled = True
            End If
        End If

    End Sub



    
End Class
