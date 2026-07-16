
Imports System.Windows.Forms
Imports System.ServiceModel

Public Class frmConsultaDocCtaCte
   
    Private oMaestroService As New MaestroService.MaestroClient
    Private oDocumentoCtaCtes As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oPlanillaDetalleService As New PlanillaDetalleService.PlanillaDetalleServiceClient
    Private dtDocumento As New DataTable
    Private dtCondicion As New DataTable
    Private dtEstado As New DataTable
    Private dtPagos As New DataTable
    Public IdDocCtaCte As Int64
    Private Sub frmDocsCredito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oDocumentoCtaCtes.Close()
            oPlanillaDetalleService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oDocumentoCtaCtes.Abort()
            oPlanillaDetalleService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oDocumentoCtaCtes.Abort()
            oPlanillaDetalleService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmConsultaDocCtaCte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                cmMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frmDocsCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombos()
        ObtenerDatos()
        MostrarPagos()
        If dgvDatos.RowCount = 0 Then
            miMostrar.Enabled = False
        Else
            miMostrar.Enabled = True
            dgvDatos.Select()
        End If

        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click, miSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub LlenarCombos()

        Try
            dtDocumento = oPlanillaDetalleService.MostrarSerieDocumentoCtaCte(Session.sCodEmp).Tables(0)
            cbDocumento.DataSource = dtDocumento
            cbDocumento.DisplayMember = "Descripcion"
            cbDocumento.ValueMember = "IdSerieDoc"
            cbDocumento.DropDownList.Columns(0).DataMember = "IdSerieDoc"
            cbDocumento.DropDownList.Columns(1).DataMember = "Descripcion"
            cbDocumento.SelectedIndex = 0
            dtDocumento = Nothing

            dtCondicion = oMaestroService.MostrarCondicionPago.Tables(0)
            cbCondicionPago.DataSource = dtCondicion
            cbCondicionPago.DisplayMember = "DesPag"
            cbCondicionPago.ValueMember = "CodPag"
            cbCondicionPago.DropDownList.Columns(0).DataMember = "CodPag"
            cbCondicionPago.DropDownList.Columns(1).DataMember = "DesPag"
            cbCondicionPago.SelectedIndex = 0
            dtCondicion = Nothing

            dtEstado = oDocumentoCtaCtes.MostrarEstados.Tables(0)
            cbEstado.DataSource = dtEstado
            cbEstado.DisplayMember = "DesEst"
            cbEstado.ValueMember = "CodEst"
            cbEstado.DropDownList.Columns(0).DataMember = "CodEst"
            cbEstado.DropDownList.Columns(1).DataMember = "DesEst"
            cbEstado.SelectedIndex = 0
            dtEstado = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub ObtenerDatos()
        Try
            Dim documentoCtaCte As New DocumentoCtaCtesService.DocumentoCtaCte
            documentoCtaCte = oDocumentoCtaCtes.MostrarPorId(IdDocCtaCte)
            cbDocumento.Value = documentoCtaCte.SerieDocumento.IdSerieDoc
            txtSerie.Text = documentoCtaCte.SerieDocumento.CodSerie
            txtNumDoc.Text = documentoCtaCte.NumDoc
            txtMoneda.Text = documentoCtaCte.Moneda.CodMon
            txtTipoCambio.Text = documentoCtaCte.TipCam
            txtNumJob.Text = documentoCtaCte.VDocumentoCredito.NumJob
            txtCliente.Text = documentoCtaCte.Cliente.DesCli
            txtRuc.Text = documentoCtaCte.Cliente.RucCli
            txtDni.Text = documentoCtaCte.Cliente.DniCli
            txtOficina.Text = documentoCtaCte.VDocumentoCredito.Locacion.Oficina.DesOfi
            txtAlmacen.Text = documentoCtaCte.VDocumentoCredito.Locacion.Almacen.DesAlm
            txtGuia.Text = documentoCtaCte.VDocumentoCredito.NumGuis
            txtFechaEmision.Text = documentoCtaCte.FecDoc
            txtFechaRecepcion.Text = documentoCtaCte.FecRec
            txtFechaVencimiento.Text = documentoCtaCte.VenDoc
            txtImporteUS.Text = documentoCtaCte.TotDol
            txtImporteNS.Text = documentoCtaCte.TotSol
            txtObservacion.Text = documentoCtaCte.Observacion
            cbCondicionPago.Value = documentoCtaCte.CondicionPago.CodPag
            txtCobrador.Text = documentoCtaCte.Persona.ApeNom
            cbEstado.Value = documentoCtaCte.Estado.CodEst

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Datos")
        End Try
    End Sub

    Private Sub MostrarPagos()
        Try
            dtPagos = oDocumentoCtaCtes.MostrarPagos(IdDocCtaCte).Tables(0)
            dgvDatos.SetDataBinding(dtPagos, 0)

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Pagos")
        End Try

    End Sub

    Private Sub cmMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If dgvDatos.RecordCount > 0 Then
            Dim forma As New frmConsultaDocCtaCtePago
            forma.IdDocCtaCte = IdDocCtaCte
            forma.IdPagoCtaCte = dgvDatos.CurrentRow.Cells("IdPagoCtaCte").Text
            forma.ShowDialog()
        End If

    End Sub

   
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = "Mostrar Detalles del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    btnSalir.MouseLeave, _
                                    miSalir.MouseLeave, miMostrar.MouseLeave
        sslError.Text = ""
    End Sub

End Class


