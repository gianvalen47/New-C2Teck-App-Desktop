Imports System.ServiceModel
Imports System.Windows.Forms

Public Class frmPlanillaPago

    Protected Friend pIdPlanillaDet As Int64
    Protected Friend pIdPlanilla As Int64
    Protected Friend pIdPago As Int64
    Private ObjPago As New PagoPlanillaService.PagoPlanillaServiceClient
    Private ObjPlanilla As New PlanillaService.PlanillaServiceClient
    Private ObjPlanillaDet As New PlanillaDetalleService.PlanillaDetalleServiceClient
    Private ObjMaestro As New MaestroService.MaestroClient
    Private ObjCtaCte As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private dtMoneda As New DataTable
    Private dtTipo As New DataTable
    Private dtBanco As New DataTable
    Private Transa As String = "" '(I = Insertar, U = Actualizar)
    Private PlanillaDetalle As New PlanillaDetalleService.PlanillaDetalle

    Private Sub frmPlanillaPago_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjMaestro.Close()
            ObjPago.Close()
            ObjPlanilla.Close()
            ObjPlanillaDet.Close()
            ObjCtaCte.Close()
        Catch ex As TimeoutException
            ObjMaestro.Abort()
            ObjPago.Abort()
            ObjPlanilla.Abort()
            ObjPlanillaDet.Abort()
            ObjCtaCte.Abort()
        Catch ex As CommunicationException
            ObjMaestro.Abort()
            ObjPago.Abort()
            ObjPlanilla.Abort()
            ObjPlanillaDet.Abort()
            ObjCtaCte.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmPlanillaPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub

    'Private Sub cbMoneda_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbMoneda.GotFocus
    '    If Transa <> "" Then
    '        If cbMoneda.Value = "US" Then
    '            txtTotalaPagarDol.Enabled = True
    '            txtTotalaPagarSol.Enabled = False
    '            btnAceptar.Enabled = True
    '        Else
    '            txtTipoCambio.Enabled = IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "US", True, False)
    '            txtTotalaPagarDol.Enabled = False
    '            txtTotalaPagarSol.Enabled = True
    '            btnAceptar.Enabled = True
    '        End If
    '    End If
    'End Sub

    Private Sub frmPlanillaPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                cbTipoPago.KeyPress _
                , cbBanco.KeyPress _
                , cbMoneda.KeyPress _
                , txtTipoCambio.KeyPress _
                , txtObservacion.KeyPress _
                , txtTotalDocDol.KeyPress _
                , txtTotalDocSol.KeyPress _
                , txtTotalGastosDol.KeyPress _
                , txtTotalGastosSol.KeyPress _
                , txtTotalPagoDol.KeyPress _
                , txtTotalPagoSol.KeyPress _
                , txtFecDoc.KeyPress _
                , txtMontoBanco.KeyPress _
                , txtNroOperacion.KeyPress
        ', txtTotalaPagarDol.KeyPress _
        ', txtTotalaPagarSol.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtTotalaPagarDol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalaPagarDol.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtTotalaPagarSol.Enabled = True Then
                txtTotalaPagarSol.Focus()
            Else
                If txtTotalGastosDol.Enabled = True Then
                    txtTotalGastosDol.Focus()
                Else
                    txtObservacion.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub txtTotalaPagarSol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalaPagarSol.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtTotalGastosDol.Enabled = True Then
                txtTotalGastosDol.Focus()
            Else
                txtObservacion.Focus()
            End If
        End If
    End Sub

    Private Sub frmPlanillaPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombos()
        MostrarDatos()

    End Sub

    Private Sub LlenarCombos()

        Try

            dtTipo = ObjPago.MostrarTipoPago.Tables(0)
            cbTipoPago.DataSource = dtTipo
            cbTipoPago.DisplayMember = "DesPag"
            cbTipoPago.ValueMember = "CodPago"
            cbTipoPago.DropDownList.Columns(0).DataMember = "CodPago"
            cbTipoPago.DropDownList.Columns(1).DataMember = "DesPag"
            dtTipo = Nothing

            dtBanco = ObjMaestro.MostrarBancos.Tables(0)
            cbBanco.DataSource = dtBanco
            cbBanco.DisplayMember = "DesBan"
            cbBanco.ValueMember = "CodBan"
            cbBanco.DropDownList.Columns(0).DataMember = "CodBan"
            cbBanco.DropDownList.Columns(1).DataMember = "DesBan"
            dtBanco = Nothing

            dtMoneda = ObjMaestro.MostrarMonedas.Tables(0)
            cbMoneda.DataSource = dtMoneda
            cbMoneda.DisplayMember = "DesMon"
            cbMoneda.ValueMember = "CodMon"
            cbMoneda.DropDownList.Columns(0).DataMember = "CodMon"
            cbMoneda.DropDownList.Columns(1).DataMember = "DesMon"
            dtMoneda = Nothing


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If PlanillaDetalle.VDocumentoCredito.Moneda.CodMon = "US" And txtTotalaPagarDol.Text > txtTotalDocDol.Text - txtTotalPagoDol.Text Then
                MsgBox("El monto a pagar en dólares es mayor a lo pendiente por pagar", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf PlanillaDetalle.VDocumentoCredito.Moneda.CodMon = "NS" And txtTotalaPagarSol.Text > txtTotalDocSol.Text - txtTotalPagoSol.Text Then
                MsgBox("El monto a pagar en soles es mayor a lo pendiente por pagar", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error de Validacion")
        End Try
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function ValidaCamposBanco() As Boolean
        Try
            'If ((cbTipoPago.Value = "CHE" And (cbBanco.Text = "" Or txtFecDoc.Text = "" Or toDouble(txtMontoBanco.Value) = 0)) Or (cbTipoPago.Value = "T.T" And (cbBanco.Text = "" Or txtFecDoc.Text = "" Or toDouble(txtMontoBanco.Value) = 0))) Then
            If (cbTipoPago.Value = "CHE" Or cbTipoPago.Value = "T.T") And (cbBanco.Text = "") Then
                MsgBox("Debe de seleccionar el banco.", MsgBoxStyle.Information, "Información")
                cbBanco.Focus()
                Return False
            ElseIf txtFecDoc.Text = "" Then
                MsgBox("Debe de seleccionar la fecha Banco.", MsgBoxStyle.Information, "Información")
                txtFecDoc.Focus()
                Return False
            ElseIf txtMontoBanco.Value = 0 Then
                MsgBox("Debe de ingresar el monto Banco.", MsgBoxStyle.Information, "Información")
                txtFecDoc.Focus()
                Return False
            ElseIf txtNroOperacion.Text = "" Then
                MsgBox("Debe de ingresar el Nro de Operación.", MsgBoxStyle.Information, "Información")
                txtNroOperacion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error de Validacion")
        End Try
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If ValidaCamposBanco() Then

            If MsgBox("¿Está seguro de GRABAR los datos?", MsgBoxStyle.YesNo, "Grabar") = MsgBoxResult.Yes And ValidaCampos() Then

                Try

                    Dim Registro As New PagoPlanillaService.PagoPlanilla
                    Dim TipoPago As New PagoPlanillaService.TipoPago
                    Dim Banco As New PagoPlanillaService.Banco
                    Dim Moneda As New PagoPlanillaService.Moneda
                    Dim PlanillaDetalle As New PagoPlanillaService.PlanillaDetalle
                    Dim Planilla As New PagoPlanillaService.Planilla
                    Select Case Transa
                        Case "I"

                            TipoPago.CodPago = cbTipoPago.Value
                            Registro.TipoPago = TipoPago
                            Registro.NumDoc = toNull(txtNumDoc.Text)
                            Banco.CodBan = toNull(cbBanco.Value)
                            Registro.Banco = Banco
                            Registro.FecBanco = IIf(txtFecDoc.Text = "", Nothing, txtFecDoc.Value)
                            Registro.MontoBanco = txtMontoBanco.Value
                            Registro.OperacionBanco = IIf(txtNroOperacion.Text = "", Nothing, txtNroOperacion.Text)
                            Moneda.CodMon = cbMoneda.Value
                            Registro.Moneda = Moneda
                            Registro.TCPag = txtTipoCambio.Text
                            Registro.PagDol = txtTotalaPagarDol.Text
                            Registro.PagSol = txtTotalaPagarSol.Text
                            Registro.GasDol = txtTotalGastosDol.Text
                            Registro.GasSol = txtTotalGastosSol.Text
                            Registro.DifCam = txtDifCambio.Text
                            Registro.ObsPag = txtObservacion.Text
                            Planilla.IdPlanilla = pIdPlanilla
                            PlanillaDetalle.Planilla = Planilla
                            PlanillaDetalle.IdPlanillaDet = pIdPlanillaDet
                            Registro.PlanillaDetalle = PlanillaDetalle

                            Registro.CodUsu = Session.sCodUsu
                            Registro.NomPc = Session.sNomPc
                            Registro.DirIp = Session.sDirIp

                            pIdPago = ObjPago.Insertar(Registro)
                        Case "U"
                            Registro.IdPago = pIdPago
                            TipoPago.CodPago = cbTipoPago.Value
                            Registro.TipoPago = TipoPago
                            Registro.NumDoc = toNull(txtNumDoc.Text)
                            Banco.CodBan = toNull(cbBanco.Value)
                            Registro.Banco = Banco
                            Registro.FecBanco = IIf(txtFecDoc.Text = "", Nothing, txtFecDoc.Value)
                            Registro.MontoBanco = txtMontoBanco.Value
                            Registro.OperacionBanco = IIf(txtNroOperacion.Text = "", Nothing, txtNroOperacion.Text)
                            Moneda.CodMon = cbMoneda.Value
                            Registro.Moneda = Moneda
                            Registro.TCPag = txtTipoCambio.Text
                            Registro.PagDol = txtTotalaPagarDol.Text
                            Registro.PagSol = txtTotalaPagarSol.Text
                            Registro.GasDol = txtTotalGastosDol.Text
                            Registro.GasSol = txtTotalGastosSol.Text
                            Registro.DifCam = txtDifCambio.Text
                            Registro.ObsPag = txtObservacion.Text
                            Planilla.IdPlanilla = pIdPlanilla
                            PlanillaDetalle.Planilla = Planilla
                            PlanillaDetalle.IdPlanillaDet = pIdPlanillaDet
                            Registro.PlanillaDetalle = PlanillaDetalle

                            Registro.CodUsu = Session.sCodUsu
                            Registro.NomPc = Session.sNomPc
                            Registro.DirIp = Session.sDirIp

                            ObjPago.Actualizar(Registro)
                    End Select
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Grabar")
                End Try
            End If
        End If
    End Sub

    Protected Friend Sub MostrarDatos()
        Try
            PlanillaDetalle = ObjPlanillaDet.MostrarPorId(pIdPlanillaDet)
            Me.Text = "Pagar Documento : " & PlanillaDetalle.DocumentoCtaCte.SerieDocumento.TipoDocumento.AbrDoc & " " & PlanillaDetalle.VDocumentoCredito.SerieDocumento.CodSerie & "-" & PlanillaDetalle.VDocumentoCredito.NumDoc

            If Transa <> "I" Then
                Dim PagoPlanilla As New PagoPlanillaService.PagoPlanilla
                PagoPlanilla = ObjPago.MostrarPorId(pIdPago)
                cbTipoPago.Value = PagoPlanilla.TipoPago.CodPago
                cbBanco.Value = PagoPlanilla.Banco.CodBan
                If Not (PagoPlanilla.FecBanco.ToString = "") Then
                    txtFecDoc.Value = CDate(PagoPlanilla.FecBanco)
                    txtFecDoc.Text = PagoPlanilla.FecBanco.ToString
                End If
                txtMontoBanco.Value = PagoPlanilla.MontoBanco
                txtNroOperacion.Text = PagoPlanilla.OperacionBanco
                cbMoneda.Value = PagoPlanilla.Moneda.CodMon
                txtNumDoc.Text = PagoPlanilla.NumDoc
                txtTipoCambio.Text = PagoPlanilla.TCPag

                txtTotalaPagarDol.Text = PagoPlanilla.PagDol
                txtTotalaPagarSol.Text = PagoPlanilla.PagSol
                txtDifCambio.Text = PagoPlanilla.DifCam
                txtObservacion.Text = PagoPlanilla.ObsPag
            Else
                Dim Planilla As New PlanillaService.Planilla
                Planilla = ObjPlanilla.MostrarPorId(pIdPlanilla)
                txtTipoCambio.Text = Planilla.TipCam
                txtTotalaPagarDol.Text = PlanillaDetalle.PagDol
                txtTotalaPagarSol.Text = PlanillaDetalle.PagSol
                txtDifCambio.Text = PlanillaDetalle.DifCam
                ' cbMoneda.Value = PlanillaDetalle.VDocumentoCredito.Moneda.CodMon
                cbTipoPago.Value = "EFE"
            End If

            Dim DocumentoCtaCte As New DocumentoCtaCtesService.DocumentoCtaCte
            DocumentoCtaCte = ObjCtaCte.MostrarPorId(PlanillaDetalle.DocumentoCtaCte.IdDocCtaCte)
            txtTotalDocDol.Text = DocumentoCtaCte.TotDol
            txtTotalDocSol.Text = DocumentoCtaCte.TotSol
            txtTotalPagoDol.Text = DocumentoCtaCte.DolPag
            txtTotalPagoSol.Text = DocumentoCtaCte.SolPag

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Protected Friend Sub NuevoRegistro()
        Transa = "I"
        Activar()
    End Sub

    Protected Friend Sub ModificarRegistro()
        Transa = "U"
        Activar()
    End Sub

    Private Sub Activar()
        cbTipoPago.Enabled = True
        cbBanco.Enabled = True
        txtFecDoc.Enabled = True
        txtMontoBanco.Enabled = True
        txtNroOperacion.Enabled = True
        cbMoneda.Enabled = True
        txtNumDoc.ReadOnly = False
        txtTipoCambio.Enabled = True
        'txtTotalaPagarDol.ReadOnly = False         'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
        'txtTotalaPagarDol.BackColor = System.Drawing.SystemColors.Window
        txtTotalaPagarDol.Enabled = True
        'txtTotalaPagarSol.ReadOnly = False         'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
        'txtTotalaPagarSol.BackColor = System.Drawing.SystemColors.Window
        txtTotalaPagarSol.Enabled = True
        txtTotalGastosDol.Enabled = True
        txtTotalGastosSol.Enabled = True
        'txtDifCambio.Enabled = True
        txtObservacion.ReadOnly = False
        btnAceptar.Visible = True
        'btnAceptar.Enabled = True
    End Sub

    Private Sub cbMoneda_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbMoneda.Validating
        If Transa <> "" Then
            If cbMoneda.Value = "US" Then
                txtTipoCambio.Enabled = IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "NS", False, True) 'IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "NS", True, False) 'Se comento a pedido de Angelica ya que  cuando la factura es en soles y el pago es en dolares no se debe modifcar el tipo de cambio.
                'txtTotalaPagarDol.ReadOnly = False      'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarDol.BackColor = System.Drawing.SystemColors.Window
                txtTotalaPagarDol.Enabled = True
                'txtTotalaPagarSol.ReadOnly = True           'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarSol.BackColor = System.Drawing.SystemColors.Control
                txtTotalaPagarSol.Enabled = False
                btnAceptar.Enabled = True
            ElseIf cbMoneda.Value = "EU" Then
                txtTipoCambio.Enabled = True  'IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "NS", True, False)
                'txtTotalaPagarDol.ReadOnly = False       'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarDol.BackColor = System.Drawing.SystemColors.Window
                txtTotalaPagarDol.Enabled = True
                'txtTotalaPagarSol.ReadOnly = True           'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarSol.BackColor = System.Drawing.SystemColors.Control
                txtTotalaPagarSol.Enabled = False
                btnAceptar.Enabled = True
            Else
                txtTipoCambio.Enabled = IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "US", True, False)
                'txtTotalaPagarDol.ReadOnly = True       'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarDol.BackColor = System.Drawing.SystemColors.Control
                txtTotalaPagarDol.Enabled = False
                'txtTotalaPagarSol.ReadOnly = False         'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarSol.BackColor = System.Drawing.SystemColors.Window
                txtTotalaPagarSol.Enabled = True
                btnAceptar.Enabled = True
            End If
        End If
    End Sub

    Private Sub cbMoneda_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMoneda.ValueChanged
        If Transa <> "" Then
            If cbMoneda.Value = "US" Then
                txtTipoCambio.Enabled = IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "NS", False, True) 'IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "NS", True, False) 'Se comento a pedido de Angelica ya que  cuando la factura es en soles y el pago es en dolares no se debe modifcar el tipo de cambio.
                'txtTotalaPagarDol.ReadOnly = False       'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarDol.BackColor = System.Drawing.SystemColors.Window
                txtTotalaPagarDol.Enabled = True
                'txtTotalaPagarSol.ReadOnly = True           'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarSol.BackColor = System.Drawing.SystemColors.Control
                txtTotalaPagarSol.Enabled = False
                btnAceptar.Enabled = True
            ElseIf cbMoneda.Value = "EU" Then
                txtTipoCambio.Enabled = True  'IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "NS", True, False)
                'txtTotalaPagarDol.ReadOnly = False       'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarDol.BackColor = System.Drawing.SystemColors.Window
                txtTotalaPagarDol.Enabled = True
                'txtTotalaPagarSol.ReadOnly = True           'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarSol.BackColor = System.Drawing.SystemColors.Control
                txtTotalaPagarSol.Enabled = False
                btnAceptar.Enabled = True
            Else
                txtTipoCambio.Enabled = IIf(PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "US", True, False)
                'txtTotalaPagarDol.ReadOnly = True       'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarDol.BackColor = System.Drawing.SystemColors.Control
                txtTotalaPagarDol.Enabled = False
                'txtTotalaPagarSol.ReadOnly = False         'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
                'txtTotalaPagarSol.BackColor = System.Drawing.SystemColors.Window
                txtTotalaPagarSol.Enabled = True
                btnAceptar.Enabled = True
            End If
        End If
    End Sub

    'Private Sub txtTotalaPagarDol_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalaPagarDol.KeyUp
    '    If e.KeyCode = Keys.Enter Then
    '        txtObservacion.Focus()
    '    End If
    'End Sub

        Private Sub txtTotalaPagarDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalaPagarDol.Validating
        Dim valor As Double

        valor = txtTotalaPagarDol.Value
        txtDifCambio.Text = 0
        Dim Moneda As String = PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon
        Dim TCDoc As Double = PlanillaDetalle.DocumentoCtaCte.TipCam        'ObjMaestro.MostrarTipoCambio("US", PlanillaDetalle.DocumentoCtaCte.FecDoc)

        'If valor > 0 Then
        'If valor > txtTotalDocDol.Text - txtTotalPagoDol.Text And Moneda = "US" Then
        '    MsgBox("No puede pagar mas del disponible, tenga cuidado", MsgBoxStyle.Information, "Cuidado")
        '    btnAceptar.Enabled = False
        '    Return
        'End If
        'Else
        '    MsgBox("Valor no permitido, verifique.......", MsgBoxStyle.Information, "Cuidado")
        '    btnAceptar.Enabled = False
        '    txtTotalaPagarDol.Text = 0
        '    txtTotalaPagarSol.Text = 0
        '    Return
        'End If


        txtTotalaPagarSol.Text = Math.Round(valor * txtTipoCambio.Text, 2)

        If Moneda = "US" Or Moneda = "EU" Then
            'If valor >= (PlanillaDetalle.DolPag - (txtTotalaPagarDol.Text - PlanillaDetalle.PagDol)) Then  '(PlanillaDetalle.DolPag - (PlanillaDetalle.PagDol - PlanillaDetalle.PagDol)) Then
            '    'txtDifCambio.Text = Math.Round(valor * txtTipoCambio.Text, 2) - (PlanillaDetalle.SolPag - (PlanillaDetalle.PagSol - PlanillaDetalle.PagSol) + (PlanillaDetalle.DifCam - PlanillaDetalle.DifCam))
            '    txtDifCambio.Value = Math.Round(valor * txtTipoCambio.Text, 2) - (PlanillaDetalle.SolPag - PlanillaDetalle.PagSol + PlanillaDetalle.DifCam) '----- Se comenta 07/08/2014 /Luego se regreso a los mismo por pedido de angelica y villalobos si pide algo que hable con ella 17/10/2014
            '    'Se vuelve a comentar la linea anterior a pedido de Angélica pide que la dif de cambio sea guardado en 4 decimales 17/11/2014 Solicitud de usuario 4325
            '    'PERO NO PROCEDIO PORQUE EL DOCUMENTO ES DE DOS DECIMALES
            'Else
            '    txtDifCambio.Value = Math.Round(valor * txtTipoCambio.Text, 2) - Math.Round(valor * TCDoc, 2) '----- Se comenta 07/08/2014 /Luego se regreso a los mismo por pedido de angelica y villalobos si pide algo que hable con ella 17/10/2014
            '    'Se vuelve a comentar la linea anterior a pedido de Angélica pide que la dif de cambio sea guardado en 4 decimales 17/11/2014 Solicitud de usuario 4325
            '    '  txtDifCambio.Value = Math.Round((valor * txtTipoCambio.Text) - (valor * TCDoc), 4) -NO PROCEDE LO DE  4 DECIMALES PORQUE EL DOUMENTO ESTA CON DOS AL COMPARAR SE CAE.
            'End If

            txtDifCambio.Value = Math.Round(valor * txtTipoCambio.Text, 2) - Math.Round(valor * TCDoc, 2)
        Else
            '--------------------Se modifico porque ahora se sacara la diferencia de cambio asi el documento este en soles------------
            'If txtTotalaPagarSol.Text > PlanillaDetalle.SolPag - (PlanillaDetalle.PagSol - PlanillaDetalle.PagSol) + (PlanillaDetalle.DifCam - PlanillaDetalle.DifCam) Then
            '    txtDifCambio.Text = txtTotalaPagarSol.Text - (PlanillaDetalle.SolPag - (PlanillaDetalle.PagSol - PlanillaDetalle.PagSol) + (PlanillaDetalle.DifCam - PlanillaDetalle.DifCam))
            'Else
            '    txtDifCambio.Text = 0
            'End If
            '-------------------------------------------------------------------------------------------------------------------------

            If txtTotalaPagarSol.Text > PlanillaDetalle.SolPag - (PlanillaDetalle.PagSol - PlanillaDetalle.PagSol) + (PlanillaDetalle.DifCam - PlanillaDetalle.DifCam) Then
                txtDifCambio.Value = txtTotalaPagarSol.Value - (PlanillaDetalle.SolPag - (PlanillaDetalle.PagSol - PlanillaDetalle.PagSol) + (PlanillaDetalle.DifCam - PlanillaDetalle.DifCam))
            Else
                txtDifCambio.Value = txtTotalaPagarSol.Value - (PlanillaDetalle.SolPag - PlanillaDetalle.PagSol + PlanillaDetalle.DifCam)
            End If

        End If

            btnAceptar.Enabled = True
    End Sub

    'Private Sub txtTotalaPagarSol_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalaPagarSol.KeyUp
    '    If e.KeyCode = Keys.Enter Then
    '        txtObservacion.Focus()
    '    End If
    'End Sub

    Private Sub txtTotalaPagarSol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalaPagarSol.Validating
        Dim valor As Double
        valor = txtTotalaPagarSol.Text
        txtDifCambio.Text = 0
        Dim Moneda As String = PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon

        'If valor > 0 Then
        'If valor > txtTotalDocSol.Text - txtTotalPagoSol.Text And Moneda = "NS" Then
        '    MsgBox("No puede pagar mas del disponible, tenga cuidado", MsgBoxStyle.Information, "Cuidado")
        '    btnAceptar.Enabled = False
        '    Return
        'End If
        'Else
        '    MsgBox("Valor no permitido, verifique.......", MsgBoxStyle.Information, "Cuidado")
        '    btnAceptar.Enabled = False
        '    txtTotalaPagarDol.Text = 0
        '    txtTotalaPagarSol.Text = 0
        '    Return
        'End If


        If Moneda = "US" Or Moneda = "EU" Then            
            txtTotalaPagarDol.Value = Math.Round(valor / txtTipoCambio.Text, 2)            


            'If txtTotalaPagarDol.Text >= PlanillaDetalle.DolPag - (PlanillaDetalle.PagDol - PlanillaDetalle.PagDol) Then
            '    txtDifCambio.Text = valor - (PlanillaDetalle.SolPag - (PlanillaDetalle.PagSol - PlanillaDetalle.PagSol) + (PlanillaDetalle.DifCam - PlanillaDetalle.DifCam))
            'Else
            '    txtDifCambio.Text = valor - (txtTotalaPagarDol.Text * ObjMaestro.MostrarTipoCambio("US", PlanillaDetalle.DocumentoCtaCte.FecDoc))
            'End If

            If txtTotalaPagarDol.Text >= PlanillaDetalle.DolPag - PlanillaDetalle.PagDol Then
                txtDifCambio.Value = valor - (PlanillaDetalle.SolPag - PlanillaDetalle.PagSol + PlanillaDetalle.DifCam)
            Else
                txtDifCambio.Value = valor - (txtTotalaPagarDol.Value * ObjMaestro.MostrarTipoCambio("US", PlanillaDetalle.DocumentoCtaCte.FecDoc))
            End If

        Else
            txtTotalaPagarDol.Text = 0

            'If valor > PlanillaDetalle.SolPag - (PlanillaDetalle.PagSol - PlanillaDetalle.PagSol) + (PlanillaDetalle.DifCam - PlanillaDetalle.DifCam) Then
            '    txtDifCambio.Text = valor - (PlanillaDetalle.SolPag - (PlanillaDetalle.PagSol - PlanillaDetalle.PagSol) + (PlanillaDetalle.DifCam - PlanillaDetalle.DifCam))

            'Else
            '    txtDifCambio.Text = 0
            'End If

            If valor > (PlanillaDetalle.SolPag - PlanillaDetalle.PagSol + PlanillaDetalle.DifCam) Then
                txtDifCambio.Text = valor - (PlanillaDetalle.SolPag - PlanillaDetalle.PagSol + PlanillaDetalle.DifCam)
            Else
                txtDifCambio.Text = 0
            End If

        End If

        btnAceptar.Enabled = True
    End Sub

    Private Sub cbTipoPago_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoPago.ValueChanged
        If Transa <> "" Then
            btnAceptar.Enabled = False
            If cbTipoPago.Value = "N/A" Or cbTipoPago.Value = "ANT" Or cbTipoPago.Value = "IA" Then
                lblNumero.Visible = True
                txtNumDoc.Visible = True
                cbMoneda.Enabled = False
            Else
                lblNumero.Visible = False
                txtNumDoc.Text = ""
                txtNumDoc.Visible = False
                cbMoneda.Enabled = True
            End If

            If cbTipoPago.Value = "CHE" Or cbTipoPago.Value = "T.T" Then
                cbBanco.Enabled = True
                'txtFecDoc.Enabled = True
                'txtMontoBanco.Enabled = True
                txtTotalGastosDol.Enabled = True
                txtTotalGastosSol.Enabled = True
            Else
                cbBanco.Value = ""
                cbBanco.Enabled = False
                'txtFecDoc.Text = ""
                'txtFecDoc.Enabled = False
                'txtMontoBanco.Enabled = False
                'txtMontoBanco.Value = 0
                txtTotalGastosDol.Enabled = False
                txtTotalGastosSol.Enabled = False
            End If

            'txtTotalaPagarDol.ReadOnly = True       'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
            'txtTotalaPagarDol.BackColor = System.Drawing.SystemColors.Control
            txtTotalaPagarDol.Enabled = False
            'txtTotalaPagarSol.ReadOnly = True           'Se regresa a poner enabled a las cajas de total a pagar Angelica 14/01/2015
            'txtTotalaPagarSol.BackColor = System.Drawing.SystemColors.Control
            txtTotalaPagarSol.Enabled = False
            txtTipoCambio.Enabled = False
        End If
    End Sub

    Private Sub txtTipoCambio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoCambio.ValueChanged
        If PlanillaDetalle.DocumentoCtaCte.Moneda.CodMon = "US" And cbMoneda.Value = "NS" Then
            txtTotalaPagarDol.Text = Math.Round(txtTotalaPagarSol.Text / txtTipoCambio.Text, 2)            
        End If
    End Sub
End Class