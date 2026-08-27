Public Class frmConsultaDocCtaCtePago
    Private oDocumentoCtaCteService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Public IdPagoCtaCte As Int64
    Public IdDocCtaCte As Int64
    Private dtTipoPago As New DataTable
    Private dtSerie As New DataTable
    Public Transa As String '(I = Insertar, U = Actualizar, M = Mostrar)
    Private Sub frmDocsCreditoPago_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oDocumentoCtaCteService.Close()

        Catch ex As TimeoutException
            oDocumentoCtaCteService.Abort()

            'Catch ex As CommunicationException
            '    oDocumentoCtaCteService.Abort()

        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmConsultaDocCtaCtePago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub frmConsultaDocCtaCtePagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombos()
        Obtener()
    End Sub
    Private Sub Obtener()

        Try
            If Transa <> "I" Then
                Dim registro As New DocumentoCtaCtesService.PagoCtaCte
                registro = oDocumentoCtaCteService.ObtenerPago(IdPagoCtaCte)
                cbTipoPago.Value = registro.TipoPago.CodPago
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
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Registro")
        End Try
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
    
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class