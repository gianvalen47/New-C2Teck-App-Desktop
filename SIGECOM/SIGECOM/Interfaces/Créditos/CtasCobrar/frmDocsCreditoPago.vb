Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmDocsCreditoPago
    Private oDocumentoCtaCteService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Public IdPagoCtaCte As Int64
    Public IdDocCtaCte As Int64
    Private dtTipoPago As New DataTable
    Private dtSerie As New DataTable
    Public Transa As String '(I = Insertar, U = Actualizar, M = Mostrar)
    Private Documento As New DocumentoCtaCtesService.DocumentoCtaCte

    Private Sub frmDocsCreditoPago_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oDocumentoCtaCteService.Close()
            oMaestroService.Close()
        Catch ex As TimeoutException
            oDocumentoCtaCteService.Abort()
            oMaestroService.Abort()
        Catch ex As CommunicationException
            oDocumentoCtaCteService.Abort()
            oMaestroService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmDocsCreditoPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmDocsCreditoPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cbSerie.KeyPress _
            , cbTipoPago.KeyPress _
            , txtTotalaPagarUS.KeyPress _
            , txtTotalaPagarNS.KeyPress _
            , txtNumDoc.KeyPress
        ', txtObservacion.KeyPress
        ' , txtDifCam.KeyPress
        ' cbFecha.KeyPress _

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmDocsCreditoPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombos()
        Obtener()
        Activar()
    End Sub

    Private Sub Obtener()
        Try
            If Transa <> "I" Then
                Dim registro As New DocumentoCtaCtesService.PagoCtaCte
                registro = oDocumentoCtaCteService.ObtenerPago(IdPagoCtaCte)
                Documento = oDocumentoCtaCteService.MostrarPorId(IdDocCtaCte)

                cbTipoPago.Value = registro.TipoPago.CodPago
                cbSerie.Value = registro.SerieDocumento.IdSerieDoc
                txtNumDoc.Text = registro.NumDocRef
                cbFecha.Value = registro.Fecha
                txtMoneda.Text = Documento.Moneda.CodMon ' registro.DocumentoCtaCte.Moneda.CodMon
                txtTipCam.Text = registro.TipCam
                txtTotalDocUS.Text = registro.DocumentoCtaCte.TotDol
                txtTotalDocNS.Text = registro.DocumentoCtaCte.TotSol
                txtTotalPagUS.Text = registro.DocumentoCtaCte.DolPag
                txtTotalPagNS.Text = registro.DocumentoCtaCte.SolPag
                txtTotalaPagarUS.Text = registro.TotDol
                txtTotalaPagarNS.Text = registro.TotSol
                txtDifCam.Text = registro.DifCam
                txtObservacion.Text = registro.Observ
                If registro.SerieDocumento.IdSerieDoc > 0 Then
                    lblDocumento.Visible = True
                    lblNumero.Visible = True
                    cbSerie.Visible = True
                    txtNumDoc.Visible = True
                End If
            Else
                Documento = oDocumentoCtaCteService.MostrarPorId(IdDocCtaCte)
                txtTotalDocUS.Text = Documento.TotDol
                txtTotalDocNS.Text = Documento.TotSol
                txtTotalPagUS.Text = Documento.DolPag
                txtTotalPagNS.Text = Documento.SolPag
                txtTotalaPagarUS.Text = Documento.TotDol - Documento.DolPag
                txtTotalaPagarNS.Text = Documento.TotSol - Documento.SolPag
                txtTipCam.Text = Documento.TipCam
                txtMoneda.Text = Documento.Moneda.CodMon

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Registro")
        End Try
    End Sub

    Private Sub Activar()
        Select Case Transa
            Case "I"
                cbTipoPago.ReadOnly = False
                cbTipoPago.BackColor = System.Drawing.SystemColors.Window
                cbSerie.ReadOnly = False
                cbSerie.BackColor = System.Drawing.SystemColors.Window
                txtNumDoc.ReadOnly = False
                txtNumDoc.BackColor = System.Drawing.SystemColors.Window
                txtTotalaPagarUS.Enabled = True
                txtTotalaPagarNS.Enabled = True
                txtDifCam.Enabled = True
            Case "U"
                cbTipoPago.ReadOnly = True
                cbTipoPago.BackColor = System.Drawing.SystemColors.Control
                cbSerie.ReadOnly = True
                cbSerie.BackColor = System.Drawing.SystemColors.Control
                txtNumDoc.ReadOnly = True
                txtNumDoc.BackColor = System.Drawing.SystemColors.Control
                txtTotalaPagarUS.Enabled = True
                txtTotalaPagarNS.Enabled = True
                txtDifCam.Enabled = True
                cbFecha.Select()
            Case "M"
                cbTipoPago.ReadOnly = True
                cbTipoPago.BackColor = System.Drawing.SystemColors.Control
                cbSerie.ReadOnly = True
                cbSerie.BackColor = System.Drawing.SystemColors.Control
                txtNumDoc.ReadOnly = True
                txtNumDoc.BackColor = System.Drawing.SystemColors.Control
                txtTotalaPagarUS.Enabled = False
                txtTotalaPagarNS.Enabled = False
                txtDifCam.Enabled = False
                txtObservacion.ReadOnly = True
                txtObservacion.BackColor = System.Drawing.SystemColors.Control
                cbFecha.ReadOnly = True
                cbFecha.BackColor = System.Drawing.SystemColors.Control
                'txtTotalaPagarUS.ReadOnly = True

                btnAceptar.Enabled = False
                btnAceptar.Visible = False
        End Select
    End Sub

    Private Sub LlenarCombos()
        Try
            dtTipoPago = oDocumentoCtaCteService.MostrarTipoPago.Tables(0)
            cbTipoPago.DataSource = dtTipoPago
            cbTipoPago.DisplayMember = "DesPag"
            cbTipoPago.ValueMember = "CodPago"
            cbTipoPago.DropDownList.Columns(0).DataMember = "CodPago"
            cbTipoPago.DropDownList.Columns(1).DataMember = "DesPag"
            cbTipoPago.SelectedIndex = 0
            dtTipoPago = Nothing

            dtSerie = oDocumentoCtaCteService.MostrarSerieDocumentoCtaCtePagoEmpresa(Session.sCodEmp).Tables(0) 'oDocumentoCtaCteService.MostrarSerieDocumentoCtaCtePago.Tables(0)
            cbSerie.DataSource = dtSerie
            cbSerie.DisplayMember = "Descripcion"
            cbSerie.ValueMember = "IdSerieDoc"
            cbSerie.DropDownList.Columns(0).DataMember = "IdSerieDoc"
            cbSerie.DropDownList.Columns(1).DataMember = "Descripcion"
            cbSerie.SelectedIndex = 0
            dtSerie = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub MostrarDocumento()

        Dim Serie As String = cbSerie.SelectedItem(2).ToString
        Dim TC As Double
        Try
            If txtNumDoc.Text <> "" And txtNumDoc.ReadOnly = False Then

                If oDocumentoCtaCteService.Buscar(cbSerie.Value, txtNumDoc.Text) Then
                    Dim DocumentoRef As New DocumentoCtaCtesService.DocumentoCtaCte
                    DocumentoRef = oDocumentoCtaCteService.ObtenerDocumento(Documento.TipCta, cbSerie.Value, txtNumDoc.Text)

                    If DocumentoRef.Cliente.IdCliente <> Documento.Cliente.IdCliente Then
                        MsgBox("Este Documento tiene diferente cliente, Verifique.!!!!!", MsgBoxStyle.Information, "Otro Cliente")
                    Else
                        txtMoneda.Text = DocumentoRef.Moneda.CodMon
                        TC = oMaestroService.MostrarTipoCambio("US", DocumentoRef.FecDoc)
                        txtTipCam.Text = TC
                        txtTotalDocUS.Text = Documento.TotDol
                        txtTotalDocNS.Text = Documento.TotSol
                        txtTotalPagUS.Text = Documento.DolPag
                        txtTotalPagNS.Text = Documento.SolPag
                        If Documento.Moneda.CodMon = "US" Then
                            If (DocumentoRef.TotDol - DocumentoRef.DolPag) < (Math.Round(Documento.TotDol - Documento.DolPag, 2)) Then
                                txtTotalaPagarUS.Text = (DocumentoRef.TotDol - DocumentoRef.DolPag)
                                'txtTotalaPagarNS.Text = (DocumentoRef.TotSol - DocumentoRef.SolPag)
                            Else
                                txtTotalaPagarUS.Text = (Documento.TotDol - Documento.DolPag)
                                'txtTotalaPagarNS.Text = Documento.TotSol - Documento.SolPag
                            End If

                            If (DocumentoRef.TotSol - DocumentoRef.SolPag) < (Math.Round(Documento.TotSol - Documento.SolPag, 2)) Then
                                txtTotalaPagarNS.Text = (DocumentoRef.TotSol - DocumentoRef.SolPag)
                            Else
                                txtTotalaPagarNS.Text = (Documento.TotSol - Documento.SolPag)
                            End If

                        Else
                            If (DocumentoRef.TotSol - DocumentoRef.SolPag) < (Math.Round(Documento.TotSol - Documento.SolPag, 2)) Then
                                txtTotalaPagarUS.Text = 0
                                txtTotalaPagarNS.Text = (DocumentoRef.TotSol - DocumentoRef.SolPag)
                            Else
                                txtTotalaPagarUS.Text = 0
                                txtTotalaPagarNS.Text = (Documento.TotSol - Documento.SolPag)
                            End If
                            'txtTotalaPagarUS.Text = IIf(Documento.Moneda.CodMon = "US", DocumentoRef.TotDol - Documento.DolPag, 0)
                            'txtTotalaPagarNS.Text = DocumentoRef.TotSol - Documento.SolPag
                        End If
                        txtObservacion.Text = "PAGO " & IIf(cbTipoPago.Value = "N/A", "N/C", IIf(cbTipoPago.Value = "ANT", "ANTICIPO", IIf(cbTipoPago.Value = "INA", "INGRESO NOTA DE ABONO", "INGRESO DE ANTICIPO"))) & _
                                              " Nº " & IIf(cbTipoPago.Value = "N/A", Serie & "-", "") & Trim(txtNumDoc.Text)
                        btnAceptar.Enabled = True
                        cbFecha.Focus()
                    End If

                Else
                    MsgBox("Este Documento no Existe, Verifique.!!!!!", MsgBoxStyle.Information, "No Existe")
                    txtNumDoc.Clear()
                    txtNumDoc.Focus()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub cbTipoPago_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoPago.ValueChanged
        Try
            If Transa = "I" Then
                Dim TipMov As String = cbTipoPago.SelectedItem(2).ToString

                If TipMov = "H" Then
                    lblDocumento.Visible = True
                    lblNumero.Visible = True
                    cbSerie.Visible = True
                    txtNumDoc.Visible = True
                    txtObservacion.ReadOnly = True
                    txtObservacion.BackColor = System.Drawing.SystemColors.Control
                    btnAceptar.Enabled = False

                    'txtMoneda.Text = ""
                    'txtTipCam.Text = 0
                    'txtTotalDocUS.Text = 0
                    'txtTotalDocNS.Text = 0
                    'txtTotalPagUS.Text = 0
                    'txtTotalPagNS.Text = 0

                Else

                    'Dim Documento As New DocumentoCtaCtesService.DocumentoCtaCte
                    'Documento = oDocumentoCtaCteService.MostrarPorId(IdDocCtaCte)
                    'txtMoneda.Text = Documento.VDocumentoCredito.Moneda.CodMon
                    'txtTipCam.Text = oMaestroService.MostrarTipoCambio("US", Documento.VDocumentoCredito.FecDoc)
                    'txtTotalDocUS.Text = Documento.TotDol
                    'txtTotalDocNS.Text = Documento.TotSol
                    'txtTotalPagUS.Text = Documento.DolPag
                    'txtTotalPagNS.Text =  Documento.SolPag

                    lblDocumento.Visible = False
                    lblNumero.Visible = False
                    cbSerie.Visible = False
                    txtNumDoc.Visible = False
                    txtObservacion.ReadOnly = False
                    txtObservacion.BackColor = System.Drawing.SystemColors.Window
                    If cbTipoPago.Value = "DIF" Then
                        txtObservacion.Text = "REDONDEO"
                    ElseIf cbTipoPago.Value = "DEV" Then
                        txtObservacion.Text = "DEVOLUCION"
                    End If
                    btnAceptar.Enabled = True
                End If
            ElseIf Transa = "U" Then
                Dim TipMov As String = cbTipoPago.SelectedItem(2).ToString

                If TipMov = "H" Then
                    
                    txtObservacion.ReadOnly = True
                    txtObservacion.BackColor = System.Drawing.SystemColors.Control
                    btnAceptar.Enabled = True

                    'txtMoneda.Text = ""
                    'txtTipCam.Text = 0
                    'txtTotalDocUS.Text = 0
                    'txtTotalDocNS.Text = 0
                    'txtTotalPagUS.Text = 0
                    'txtTotalPagNS.Text = 0

                Else

                    'Dim Documento As New DocumentoCtaCtesService.DocumentoCtaCte
                    'Documento = oDocumentoCtaCteService.MostrarPorId(IdDocCtaCte)
                    'txtMoneda.Text = Documento.VDocumentoCredito.Moneda.CodMon
                    'txtTipCam.Text = oMaestroService.MostrarTipoCambio("US", Documento.VDocumentoCredito.FecDoc)
                    'txtTotalDocUS.Text = Documento.TotDol
                    'txtTotalDocNS.Text = Documento.TotSol
                    'txtTotalPagUS.Text = Documento.DolPag
                    'txtTotalPagNS.Text =  Documento.SolPag

                    txtObservacion.ReadOnly = False
                    txtObservacion.BackColor = System.Drawing.SystemColors.Window
                    btnAceptar.Enabled = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al mostrar Datos")
        End Try

    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("¿Está seguro de GRABAR los datos?", MsgBoxStyle.YesNo, "Grabar") = MsgBoxResult.Yes Then
                Dim registro As New DocumentoCtaCtesService.PagoCtaCte
                Dim Documento As New DocumentoCtaCtesService.DocumentoCtaCte
                Dim Tipo As New DocumentoCtaCtesService.TipoPago
                Dim Serie As New DocumentoCtaCtesService.SerieDocumento
                Dim DocumentoOrigen As New DocumentoCtaCtesService.DocumentoCtaCte
                DocumentoOrigen = oDocumentoCtaCteService.MostrarPorId(IdDocCtaCte)
                registro.IdPagoCtaCte = IdPagoCtaCte
                Documento.IdDocCtaCte = IdDocCtaCte
                registro.DocumentoCtaCte = Documento
                registro.TipCta = DocumentoOrigen.TipCta
                registro.Fecha = cbFecha.Value
                registro.TipCam = txtTipCam.Text
                Tipo.CodPago = cbTipoPago.Value
                registro.TipoPago = Tipo
                If cbTipoPago.SelectedItem(2).ToString = "H" Then
                    Serie.IdSerieDoc = cbSerie.Value
                    registro.SerieDocumento = Serie
                    registro.NumDocRef = toNumber(txtNumDoc.Text)
                End If
                registro.TotDol = txtTotalaPagarUS.Text
                registro.TotSol = txtTotalaPagarNS.Text
                registro.DifCam = txtDifCam.Text
                registro.Observ = txtObservacion.Text

                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu

                If Transa = "I" Then
                    IdPagoCtaCte = oDocumentoCtaCteService.InsertarPago(registro)
                Else
                    MsgBox("No es actualizable, consultar con el administrador del sistema", MsgBoxStyle.Information, "No actualizable en este momento")
                    '   oDocumentoCtaCteService.Actualizar(registro)
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Ingreso")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtTotalaPagarUS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalaPagarUS.Validating
        Try
            'Dim valor As Double
            'valor = txtTotalaPagarUS.Text
            If Transa = "I" Then
                If txtNumDoc.Text <> "" Then
                    Dim Moneda As String = Documento.Moneda.CodMon
                    If Moneda = "US" Then
                        Dim DocumentoRef As New DocumentoCtaCtesService.DocumentoCtaCte
                        DocumentoRef = oDocumentoCtaCteService.ObtenerDocumento(Documento.TipCta, cbSerie.Value, txtNumDoc.Text)
                        If txtTotalaPagarUS.Text > Math.Round(Documento.TotDol - Documento.DolPag, 2) Then
                            MsgBox("El monto en dólares no puede ser mayor al saldo")
                            If (DocumentoRef.TotDol - DocumentoRef.DolPag) < (Math.Round(Documento.TotDol - Documento.DolPag, 2)) Then
                                txtTotalaPagarUS.Text = (DocumentoRef.TotDol - DocumentoRef.DolPag)
                                'txtTotalaPagarNS.Text = (DocumentoRef.TotSol - DocumentoRef.SolPag)
                            Else
                                txtTotalaPagarUS.Text = (Documento.TotDol - Documento.DolPag)
                                'txtTotalaPagarNS.Text = Documento.TotSol - Documento.SolPag
                            End If
                            txtTotalaPagarUS.Focus()
                        ElseIf txtTotalaPagarUS.Text < Math.Round(Documento.TotDol - Documento.DolPag, 2) Then
                            txtTotalaPagarNS.Text = Math.Round(txtTotalaPagarUS.Text * txtTipCam.Text, 2)
                        End If

                        'If cbTipoPago.Value = "ANT" Or cbTipoPago.Value = "N/A" Or cbTipoPago.Value = "IA" Or cbTipoPago.Value = "INA" Then

                        'End If

                    End If
                End If
            ElseIf Transa = "U" Then
                Dim Moneda As String = Documento.Moneda.CodMon
                Dim registro As New DocumentoCtaCtesService.PagoCtaCte
                registro = oDocumentoCtaCteService.ObtenerPago(IdPagoCtaCte)
                If Moneda = "US" Then
                    If txtTotalaPagarUS.Text > Math.Round(Documento.TotDol - Documento.DolPag, 2) + registro.TotDol Then
                        MsgBox("El monto en dólares no puede ser mayor al saldo")
                        txtTotalaPagarUS.Text = registro.TotDol
                        txtTotalaPagarUS.Focus()
                    ElseIf txtTotalaPagarUS.Text <> registro.TotDol Then
                        txtTotalaPagarNS.Text = Math.Round(txtTotalaPagarUS.Text * txtTipCam.Text, 2)
                    End If
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error del Documento")
        End Try

    End Sub

    Private Sub txtTotalaPagarNS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalaPagarNS.Validating
        'Try
        '    If txtTotalaPagarNS.Text >= Math.Round(Documento.TotSol - Documento.SolPag, 2) Then
        '        txtDifCam.Text = Math.Round(Documento.TotSol - Documento.SolPag, 2) - txtTotalaPagarNS.Text
        '    Else
        '        txtDifCam.Text = 0
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error del Documento")
        'End Try
      
    End Sub


    Private Sub txtDifCam_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDifCam.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtObservacion.ReadOnly = True Then
                e.Handled = True
                btnAceptar.Focus()
            ElseIf txtObservacion.ReadOnly = False Then
                e.Handled = True
                txtObservacion.Focus()
            End If
        End If
    End Sub

    Private Sub cbFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtTotalaPagarUS.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnAceptar.Focus()
        End If
    End Sub
    Private Sub txtNumDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumDoc.Validating
        MostrarDocumento()
        ' OK_Button.Enabled = True
    End Sub


End Class