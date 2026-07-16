Imports System.ServiceModel
Public Class frmFactura_AtenderJob

    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oBoletaService As New BoletaService.BoletaServiceClient                     '-----Agregado el 14/03/2013
    Private oMaestroService As New MaestroService.MaestroClient
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private dtNumJob As DataTable
    Private dtMotivos As DataTable
    Public CodOfi As String
    Public IdLocacion As Integer
    Public TipFac As Integer

    '----------------------------------- Agregado el 13/03/2013 ------------------------------------------
    Private oJobService As New JobService.JobServiceClient
    Private dtDetalles As DataTable
    Public IdFactura As Int64
    '----------------------------------- Agregado el 14/03/2013 ------------------------------------------
    Public IdBoleta As Int64
    Public Documento As Integer      ' 1 = Factura; 2 = Boleta
    '------------------------------------------------------------------------------------------------------------------

    Private Sub Finalizar()
        Try
            oFacturaService.Close()
            oBoletaService.Close()
            oMaestroService.Close()
            oReporteVentaService.Close()
            oJobService.Close()
        Catch ex As TimeoutException
            oFacturaService.Abort()
            oBoletaService.Abort()
            oMaestroService.Abort()
            oReporteVentaService.Abort()
            oJobService.Abort()
        Catch ex As CommunicationException
            oFacturaService.Abort()
            oBoletaService.Abort()
            oMaestroService.Abort()
            oReporteVentaService.Abort()
            oJobService.Abort()
        End Try
    End Sub

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub frmFactura_AtenderJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtNumDoc.KeyPress _
      , cmbCodMot.KeyPress _
      , cmbCodPag.KeyPress _
      , txtDescripcion.KeyPress _
      , txtFecDoc.KeyPress _
      , txtNumOrden.KeyPress _
      , txtTipoCambio.KeyPress _
      , cmbNumJob.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmFactura_AtenderJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmFactura_AtenderJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        llenarCombos()
        'txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio("US", txtFecDoc.Text))
        cmbCodMot.Value = "1"
    End Sub

    Private Sub llenarCombos()
        '======================================= JOB ================================================
        '----------------------------------------------------------------Se modificó el 13/03/2013---------------------------------------------------------------------------------
        dtNumJob = oFacturaService.MostrarLiquidacionJob(CodOfi).Tables(0)
        cmbNumJob.DataSource = dtNumJob
        cmbNumJob.DropDownList.DataMember = dtNumJob.Columns("DesCli").ToString
        cmbNumJob.DropDownList.DisplayMember = dtNumJob.Columns("CodJob").ToString
        cmbNumJob.DropDownList.ValueMember = dtNumJob.Columns("CodJob").ToString
        cmbNumJob.DropDownList.Columns(0).DataMember = dtNumJob.Columns("CodJob").ToString
        cmbNumJob.DropDownList.Columns(1).DataMember = dtNumJob.Columns("DesCli").ToString
        cmbNumJob.DropDownList.Columns(2).DataMember = dtNumJob.Columns("IdLiquidacion").ToString
        cmbNumJob.DropDownList.Columns(3).DataMember = dtNumJob.Columns("CodJob").ToString
        cmbNumJob.DropDownList.Columns(4).DataMember = dtNumJob.Columns("NumCotizacion").ToString
        cmbNumJob.DropDownList.Columns(5).DataMember = dtNumJob.Columns("IdClienteSolicita").ToString
        cmbNumJob.DropDownList.Columns(6).DataMember = dtNumJob.Columns("IdClienteBeneficiado").ToString
        cmbNumJob.DropDownList.Columns(7).DataMember = dtNumJob.Columns("IdCliente").ToString
        cmbNumJob.DropDownList.Columns(8).DataMember = dtNumJob.Columns("DesCli").ToString
        cmbNumJob.DropDownList.Columns(9).DataMember = dtNumJob.Columns("CodMon").ToString
        cmbNumJob.DropDownList.Columns(10).DataMember = dtNumJob.Columns("NumOrden").ToString
        cmbNumJob.DropDownList.Columns(11).DataMember = dtNumJob.Columns("CodPag").ToString
        cmbNumJob.DropDownList.Columns(12).DataMember = dtNumJob.Columns("TotBruto").ToString
        cmbNumJob.DropDownList.Columns(13).DataMember = dtNumJob.Columns("TotDscto").ToString
        cmbNumJob.DropDownList.Columns(14).DataMember = dtNumJob.Columns("TotVenta").ToString
        cmbNumJob.DropDownList.Columns(15).DataMember = dtNumJob.Columns("TotIgv").ToString
        cmbNumJob.DropDownList.Columns(16).DataMember = dtNumJob.Columns("TotNeto").ToString
        'cmbNumJob.SelectedIndex = 0
        dtNumJob = Nothing
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        '================================== CONDICIONES DE PAGO =========================================
        dtMotivos = oMaestroService.MostrarCondicionPago.Tables(0)
        cmbCodPag.DataSource = dtMotivos
        cmbCodPag.DropDownList.DataMember = dtMotivos.Columns("DesPag").ToString
        cmbCodPag.DropDownList.DisplayMember = dtMotivos.Columns("DesPag").ToString
        cmbCodPag.DropDownList.ValueMember = dtMotivos.Columns("CodPag").ToString
        cmbCodPag.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodPag").ToString
        cmbCodPag.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesPag").ToString
        dtMotivos = Nothing

        '======================================= MOTIVOS ================================================
        dtMotivos = oReporteVentaService.MostrarMotivosVenta.Tables(0)
        cmbCodMot.DataSource = dtMotivos
        cmbCodMot.DropDownList.DataMember = dtMotivos.Columns("DesMot").ToString
        cmbCodMot.DropDownList.DisplayMember = dtMotivos.Columns("DesMot").ToString
        cmbCodMot.DropDownList.ValueMember = dtMotivos.Columns("CodMot").ToString
        cmbCodMot.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodMot").ToString
        cmbCodMot.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesMot").ToString
        dtMotivos = Nothing
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe ingresar en número de la factura")
                txtNumDoc.Focus()
                Return False
            ElseIf toNumber(IdLocacion = 0) Then
                MsgBox("Debe ingresar la Locación del documento")
                Return False
            ElseIf toBlank(txtFecDoc.Text = "") Then
                MsgBox("Debe ingresar la fecha del documento")
                Return False
            ElseIf toBlank(cmbNumJob.Text) = "" Then
                MsgBox("Debe ingresar el numero de la OT del documento")
                Return False
            ElseIf toBlank(cmbCodPag.Value) = "" Then
                MsgBox("Debe ingresar la condición de pago del documento")
                Return False
            ElseIf oFacturaService.Buscar(TipFac, toNumber(txtNumDoc.Text)) Then
                MsgBox("El Número " + txtNumDoc.Text + " de la factura ya existe...!", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub cmbNumJob_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbNumJob.Validating
        Try
            If Len(Trim(cmbNumJob.Text)) > 0 Then

                '    txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbNumJob.DropDownList.GetRow.Cells(13).Text, txtFecDoc.Text))
                '    txtDescripcion.Text = cmbNumJob.DropDownList.GetRow.Cells(1).Text
                '    cmbCodPag.Value = cmbNumJob.DropDownList.GetRow.Cells(2).Text
                '    txtNumOrden.Text = cmbNumJob.DropDownList.GetRow.Cells(3).Text

                '    Dim repuestos As Decimal
                '    Dim manob As Decimal
                '    Dim viaticos As Decimal
                '    Dim materiales As Decimal
                '    Dim terceros As Decimal
                '    Dim gastos As Decimal
                '    Dim numigv As Decimal
                '    Dim numdesc As Decimal
                '    Dim totbruto As Decimal
                '    Dim valventa As Decimal
                '    Dim totigv As Decimal

                '    repuestos = cmbNumJob.DropDownList.GetRow.Cells(4).Text
                '    manob = cmbNumJob.DropDownList.GetRow.Cells(5).Text
                '    viaticos = cmbNumJob.DropDownList.GetRow.Cells(6).Text
                '    materiales = cmbNumJob.DropDownList.GetRow.Cells(7).Text
                '    terceros = cmbNumJob.DropDownList.GetRow.Cells(8).Text
                '    gastos = cmbNumJob.DropDownList.GetRow.Cells(9).Text
                '    numigv = cmbNumJob.DropDownList.GetRow.Cells(10).Text
                '    numdesc = cmbNumJob.DropDownList.GetRow.Cells(11).Text

                '    txtTotBruto.Text = Format(repuestos + manob + viaticos + materiales + terceros + gastos + numdesc, "##,##0.00")
                '    totbruto = txtTotBruto.Text
                '    txtDescuento.Text = Format(numdesc, "##,##0.00")
                '    txtValVenta.Text = Format((totbruto - numdesc), "##,##0.00")
                '    valventa = txtValVenta.Text
                '    txtigv.Text = Format(((numigv * valventa) / 100), "##,##0.00")
                '    totigv = txtigv.Text
                '    txtTotNeto.Text = Format((valventa + totigv), "##,##0.00")

                '========================== Se agregó el 13/03/2013 ===========================
                txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbNumJob.DropDownList.GetRow.Cells(9).Text, txtFecDoc.Text))
                txtDescripcion.Text = cmbNumJob.DropDownList.GetRow.Cells(1).Text
                cmbCodPag.Value = cmbNumJob.DropDownList.GetRow.Cells(11).Text
                txtNumOrden.Text = cmbNumJob.DropDownList.GetRow.Cells(10).Text

                txtTotalBruto.Value = cmbNumJob.DropDownList.GetRow.Cells(12).Value
                txtMontoDscto.Value = cmbNumJob.DropDownList.GetRow.Cells(13).Value
                txtValorVenta.Value = cmbNumJob.DropDownList.GetRow.Cells(14).Value
                txtMontoIgv.Value = cmbNumJob.DropDownList.GetRow.Cells(15).Value
                txtTotalNeto.Value = cmbNumJob.DropDownList.GetRow.Cells(16).Value
                ListaDatos()
                '=======================================================================
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al Obtener Datos")
        End Try
    End Sub

    '=================== DETALLES DE LIQUIDACION (13/03/2013) ===================
    Private Sub ListaDatos()
        Try
            dtDetalles = oJobService.MostrarLiquidacionDet(toNumber(cmbNumJob.DropDownList.GetRow.Cells(2).Text)).Tables(0)
            dgvDatos.DataSource = dtDetalles
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '======================================================================

    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        If Len(Trim(cmbNumJob.Text)) > 0 Then
            txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbNumJob.DropDownList.GetRow.Cells(9).Text, txtFecDoc.Text))
        Else
            txtTipoCambio.Text = 0
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            If Documento = 1 Then
                If MsgBox("¿Está seguro de CREAR la Factura Nº " + txtNumDoc.Text.ToString + " ?", MsgBoxStyle.YesNo, "Anular") = MsgBoxResult.Yes And ValidaCampos() Then
                    Dim estado_process As Int64
                    Dim CodLiq As Int64
                    CodLiq = cmbNumJob.DropDownList.GetRow.Cells(2).Text
                    estado_process = oFacturaService.FacturarJob(IdLocacion, CodLiq, toNumber(txtNumDoc.Text), txtFecDoc.Value, cmbNumJob.Value, cmbCodPag.Value, cmbCodMot.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process > 0 Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        IdFactura = estado_process
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            ElseIf Documento = 2 Then
                If MsgBox("¿Está seguro de CREAR la Boleta Nº " + txtNumDoc.Text.ToString + " ?", MsgBoxStyle.YesNo, "Anular") = MsgBoxResult.Yes And ValidaCampos() Then
                    Dim estado_process As Int64
                    Dim CodLiq As Int64
                    CodLiq = cmbNumJob.DropDownList.GetRow.Cells(2).Text
                    estado_process = oBoletaService.FacturarJob(IdLocacion, CodLiq, toNumber(txtNumDoc.Text), txtFecDoc.Value, cmbNumJob.Value, cmbCodPag.Value, cmbCodMot.Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process > 0 Then
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        IdBoleta = estado_process
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbNumJob_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNumJob.ValueChanged
        Try
            If Len(Trim(cmbNumJob.Text)) > 0 Then

                '    txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbNumJob.DropDownList.GetRow.Cells(13).Text, txtFecDoc.Text))
                '    txtDescripcion.Text = cmbNumJob.DropDownList.GetRow.Cells(1).Text
                '    cmbCodPag.Value = cmbNumJob.DropDownList.GetRow.Cells(2).Text
                '    txtNumOrden.Text = cmbNumJob.DropDownList.GetRow.Cells(3).Text

                '    Dim repuestos As Decimal
                '    Dim manob As Decimal
                '    Dim viaticos As Decimal
                '    Dim materiales As Decimal
                '    Dim terceros As Decimal
                '    Dim gastos As Decimal
                '    Dim numigv As Decimal
                '    Dim numdesc As Decimal
                '    Dim totbruto As Decimal
                '    Dim valventa As Decimal
                '    Dim totigv As Decimal

                '    repuestos = cmbNumJob.DropDownList.GetRow.Cells(4).Text
                '    manob = cmbNumJob.DropDownList.GetRow.Cells(5).Text
                '    viaticos = cmbNumJob.DropDownList.GetRow.Cells(6).Text
                '    materiales = cmbNumJob.DropDownList.GetRow.Cells(7).Text
                '    terceros = cmbNumJob.DropDownList.GetRow.Cells(8).Text
                '    gastos = cmbNumJob.DropDownList.GetRow.Cells(9).Text
                '    numigv = cmbNumJob.DropDownList.GetRow.Cells(10).Text
                '    numdesc = cmbNumJob.DropDownList.GetRow.Cells(11).Text

                '    txtTotBruto.Text = Format(repuestos + manob + viaticos + materiales + terceros + gastos + numdesc, "##,##0.00")
                '    totbruto = txtTotBruto.Text
                '    txtDescuento.Text = Format(numdesc, "##,##0.00")
                '    txtValVenta.Text = Format((totbruto - numdesc), "##,##0.00")
                '    valventa = txtValVenta.Text
                '    txtigv.Text = Format(((numigv * valventa) / 100), "##,##0.00")
                '    totigv = txtigv.Text
                '    txtTotNeto.Text = Format((valventa + totigv), "##,##0.00")

                '========================== Se agregó el 13/03/2013 ===========================
                txtTipoCambio.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbNumJob.DropDownList.GetRow.Cells(9).Text, txtFecDoc.Text))
                txtDescripcion.Text = cmbNumJob.DropDownList.GetRow.Cells(1).Text
                cmbCodPag.Value = cmbNumJob.DropDownList.GetRow.Cells(11).Text
                txtNumOrden.Text = cmbNumJob.DropDownList.GetRow.Cells(10).Text

                txtTotalBruto.Value = cmbNumJob.DropDownList.GetRow.Cells(12).Value
                txtMontoDscto.Value = cmbNumJob.DropDownList.GetRow.Cells(13).Value
                txtValorVenta.Value = cmbNumJob.DropDownList.GetRow.Cells(14).Value
                txtMontoIgv.Value = cmbNumJob.DropDownList.GetRow.Cells(15).Value
                txtTotalNeto.Value = cmbNumJob.DropDownList.GetRow.Cells(16).Value
                ListaDatos()
                '=======================================================================
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al Obtener Datos")
        End Try
    End Sub
End Class