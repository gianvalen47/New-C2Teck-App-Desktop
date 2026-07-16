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
                cbTipoPago.Value = registro.TipoPago.CodPago
                cbSerie.Value = registro.SerieDocumento.IdSerieDoc
                txtNumDoc.Text = registro.NumDocRef
                cbFecha.Value = registro.Fecha
                txtMoneda.Text = registro.DocumentoCtaCte.VDocumentoCredito.Moneda.CodMon
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
            End If 
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Registro")
        End Try
    End Sub

    Private Sub Activar()
        Select Case Transa
            Case "I"
                cbTipoPago.ReadOnly = False
                cbSerie.ReadOnly = False
                txtNumDoc.ReadOnly = False
                txtTotalaPagarUS.Enabled = True
                txtTotalaPagarNS.Enabled = True

            Case "U"
                cbTipoPago.ReadOnly = False
                cbSerie.ReadOnly = False
                txtNumDoc.ReadOnly = False
                txtTotalaPagarUS.Enabled = True
                txtTotalaPagarNS.Enabled = True
            Case "M"
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

            dtSerie = oDocumentoCtaCteService.MostrarSerieDocumentoCtaCtePago.Tables(0)
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
            Dim DocumentoRef As New DocumentoCtaCtesService.VDocumentoCredito
            DocumentoRef = oDocumentoCtaCteService.MostrarPorDoc(cbSerie.Value, txtNumDoc.Text)
            Dim Documento As New DocumentoCtaCtesService.DocumentoCtaCte
            Documento = oDocumentoCtaCteService.MostrarPorId(IdDocCtaCte)
            If oDocumentoCtaCteService.Buscar(DocumentoRef.TipDoc, DocumentoRef.IdVenta, Documento.TipCta) Then
                If DocumentoRef.Cliente.IdCliente <> Documento.VDocumentoCredito.Cliente.IdCliente Then
                    MsgBox("Este Documento tiene diferente cliente, Verifique.!!!!!", MsgBoxStyle.Information, "Otro Cliente")
                Else
                    txtMoneda.Text = Documento.VDocumentoCredito.Moneda.CodMon
                    TC = oMaestroService.MostrarTipoCambio("US", DocumentoRef.FecDoc)
                    txtTipCam.Text = TC
                    txtTotalDocUS.Text = Documento.TotDol
                    txtTotalDocNS.Text = Documento.TotSol
                    txtTotalPagUS.Text = Documento.DolPag
                    txtTotalPagNS.Text = Documento.SolPag
                    If Documento.VDocumentoCredito.Moneda.CodMon = "US" Then
                        txtTotalaPagarUS.Text = DocumentoRef.TotNeto - Documento.DolPag
                        txtTotalaPagarNS.Text = Math.Round(DocumentoRef.TotNeto * TC, 2) - Documento.SolPag
                    Else
                        txtTotalaPagarUS.Text = IIf(Documento.VDocumentoCredito.Moneda.CodMon = "US", DocumentoRef.TotNeto - Documento.DolPag, 0)
                        txtTotalaPagarNS.Text = DocumentoRef.TotNeto - Documento.SolPag
                    End If
                    txtObservacion.Text = "PAGO " & IIf(cbTipoPago.Value = "N/A", "NOTA DE ABONO", IIf(cbTipoPago.Value = "ANT", "ANTICIPO", IIf(cbTipoPago.Value = "INA", "INGRESO NOTA DE ABONO", "INGRESO DE ANTICIPO"))) & _
                                          " Nro. " & IIf(cbTipoPago.Value = "N/A", Serie & "-", "") & Trim(txtNumDoc.Text)
                    btnAceptar.Enabled = True
                End If

            Else
                MsgBox("Este Documento no Existe, Verifique.!!!!!", MsgBoxStyle.Information, "No Existe")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If MsgBox("Seguro de Grabar los datos....?", MsgBoxStyle.YesNo, "Grabar") = MsgBoxResult.Yes Then
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

    Private Sub cbSerie_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSerie.ValueChanged

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
                    btnAceptar.Enabled = False

                    txtMoneda.Text = ""
                    txtTipCam.Text = 0
                    txtTotalDocUS.Text = 0
                    txtTotalDocNS.Text = 0
                    txtTotalPagUS.Text = 0
                    txtTotalPagNS.Text = 0

                Else

                    Dim Documento As New DocumentoCtaCtesService.DocumentoCtaCte
                    Documento = oDocumentoCtaCteService.MostrarPorId(IdDocCtaCte)
                    txtMoneda.Text = Documento.VDocumentoCredito.Moneda.CodMon
                    txtTipCam.Text = oMaestroService.MostrarTipoCambio("US", Documento.VDocumentoCredito.FecDoc)
                    txtTotalDocUS.Text = Documento.TotDol
                    txtTotalDocNS.Text = Documento.TotSol
                    txtTotalPagUS.Text = Documento.DolPag
                    txtTotalPagNS.Text = Documento.SolPag

                    lblDocumento.Visible = False
                    lblNumero.Visible = False
                    cbSerie.Visible = False
                    txtNumDoc.Visible = False
                    txtObservacion.ReadOnly = False
                    btnAceptar.Enabled = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al mostrar Datos")
        End Try
        
    End Sub

    Private Sub txtNumDoc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumDoc.KeyUp
        If e.KeyCode = Keys.Enter Then
            MostrarDocumento()
            ' OK_Button.Enabled = True
        End If
    End Sub

   
End Class