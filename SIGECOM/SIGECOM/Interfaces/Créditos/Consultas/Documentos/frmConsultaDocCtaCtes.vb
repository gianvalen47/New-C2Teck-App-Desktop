Imports System.ServiceModel

Public Class frmConsultaDocCtaCtes

    Private oMaestroService As New MaestroService.MaestroClient
    Private oDocumentoCtaCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    '====================================================================================================================
    '============================================ Parametros Locales ====================================================
    '====================================================================================================================
    Private lMostrar As Boolean
    Private dtTipoDocumentos As DataTable
    Private dtDatos As DataTable
    Private IdCliente, IdDocumento As String
    Private NumDocumento As Integer
    Private dtAlmacenes As DataTable
    Private dtMonedas As DataTable

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
         txtCliente.KeyPress, cmbDocu.KeyPress, txtNumDoc.KeyPress, cbFecFin.KeyPress, cbFecIni.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.KeyCode = Keys.Enter Then
                If dgvDatos.RowCount > 0 Then
                    biMostrar_Click(sender, e)
                    e.Handled = True
                End If
            End If
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
          txtCliente.KeyPress, cmbDocu.KeyPress, txtNumDoc.KeyPress, btnBuscar.KeyPress, dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
        End If
    End Sub
    Private Sub frmDocs_Creditos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oDocumentoCtaCtesService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oDocumentoCtaCtesService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oDocumentoCtaCtesService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmConsultaDocCtaCtes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
            e.Handled = True
        End If
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 43)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        cbFecIni.Value = "01/01/" & Year(Today)
        listaDatos()
        refrescarMenus()
        dgvDatos.Select()

    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdDocCtaCte").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub refrescarMenus()
        lMostrar = IIf(dgvDatos.RowCount > 0, True, False)
        Me.biMostrar.Enabled = lMostrar
        Me.biActualizar.Enabled = lMostrar
        Me.miMostrar.Enabled = lMostrar
        Me.miActualizar.Enabled = lMostrar
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= DOCUMENTOS ==============================================
            dtTipoDocumentos = oMaestroService.MostrarTipDocCtaCte.Tables(0)
            Dim row As DataRow = dtTipoDocumentos.NewRow
            row(0) = 0
            row(1) = "(Todos)"
            dtTipoDocumentos.Rows.InsertAt(row, 0)
            cmbDocu.DataSource = dtTipoDocumentos
            cmbDocu.DropDownList.DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.DisplayMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.ValueMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(0).DataMember = dtTipoDocumentos.Columns("IdDocumento").ToString
            cmbDocu.DropDownList.Columns(1).DataMember = dtTipoDocumentos.Columns("Nombre").ToString
            cmbDocu.DropDownList.Columns(2).DataMember = dtTipoDocumentos.Columns("AbrDoc").ToString
            cmbDocu.SelectedIndex = 0
            dtTipoDocumentos = Nothing
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarAlmacenes().Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("CodAlm").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            'If dtAlmacenes.Rows.Count > 0 Then
            '    cmbIdLocacion.SelectedIndex = 0
            'Else
            '    cmbIdLocacion.Value = ""
            'End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oDocumentoCtaCtesService.Filtrar(Session.sCodEmp, cmbIdLocacion.Value, cmbCodMon.Value, cbFecIni.Value, cbFecFin.Value, IdCliente, cmbDocu.Value, IIf(Trim(txtNumDoc.Text) = "", 0, txtNumDoc.Text)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString


            '////////SUMAR MONTOS TOTALES DE VENCIMIENTOS////////
            If dtDatos.Rows.Count > 0 Then
                Dim lPorVencerSol, lVencidoSol, lPorVencerDol, lVencidoDol As Decimal
                For Each Fila As DataRow In dtDatos.Rows
                    If Fila.Item("CodMon") = "US" Then
                        If Fila.Item("VenDoc") <= Today Then
                            lVencidoDol = lVencidoDol + (Fila.Item("Saldo")) '* (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                        Else
                            lPorVencerDol = lPorVencerDol + (Fila.Item("Saldo")) '* (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                        End If
                    Else
                        If Fila.Item("VenDoc") <= Today Then
                            lVencidoSol = lVencidoSol + (Fila.Item("Saldo")) '* (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                        Else
                            lPorVencerSol = lPorVencerSol + (Fila.Item("Saldo")) ' * (IIf(Fila.Item("TipMov") = "D", 1, -1)))
                        End If
                    End If

                Next
                txtPorVencerSol.Text = lPorVencerSol
                txtVencidoSol.Text = lVencidoSol
                txtPorVencerDol.Text = lPorVencerDol
                txtVencidoDol.Text = lVencidoDol
                txtSaldoSol.Text = lPorVencerSol + lVencidoSol
                txtSaldoDol.Text = lPorVencerDol + lVencidoDol
            Else
                txtPorVencerSol.Text = 0.0
                txtVencidoSol.Text = 0.0
                txtPorVencerDol.Text = 0.0
                txtVencidoDol.Text = 0.0
                txtSaldoSol.Text = 0.0
                txtSaldoDol.Text = 0.0
            End If
            '/////////////////////////////////////////////////////

        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
        refrescarMenus()
    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click, dgvDatos.DoubleClick
        If dgvDatos.RecordCount > 0 Then
            Dim forma As New frmConsultaDocCtaCte
            forma.IdDocCtaCte = dgvDatos.CurrentRow.Cells(0).Text
            forma.ShowDialog()
        End If

    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdDocCtaCte").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close 
    End Sub

    Private Sub cmbDocu_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDocu.ValueChanged
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged
        btnBuscar.Focus()
    End Sub

    Private Sub txtCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.ButtonClick
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            chkCliente.Checked = False
            txtCliente.Text = frm.descripcion
            ' txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            txtNumDoc.Text = ""
            listaDatos()
        End If
    End Sub

    Private Sub txtNumDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtNumDoc.Text <> "" Then
            txtCliente.Text = ""
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click, cmbDocu.ValueChanged, cbFecIni.ValueChanged, cbFecFin.ValueChanged, txtNumDoc.TextChanged, cmbIdLocacion.ValueChanged, cmbCodMon.ValueChanged
        listaDatos()
    End Sub

    Private Sub miImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click

    End Sub
    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Documento Actual."
    End Sub

    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Documento Actual."
    End Sub

    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                    biImprimir.MouseLeave, _
                                    biMostrar.MouseLeave, _
                                    biActualizar.MouseLeave, biSalir.MouseLeave, _
                                    miImprimir.MouseLeave, _
                                    miMostrar.MouseLeave, _
                                    miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                   cbFecIni.ValueChanged, cbFecFin.ValueChanged, cmbDocu.ValueChanged, txtCliente.Validating, cmbIdLocacion.ValueChanged
        listaDatos()
    End Sub
 
    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged

        If txtCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If

    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click

        Try
            Dim forma As New frmReportes
            Dim reporte As New rptListadoDocCtaCte
            'Dim registro As CotizacionServicioService.CotizacionServicio

            'Dim dtDatosListado As DataTable

            'dtDatosListado = oJobService.Filtrar(txtanio.Text, cmbOficinas.Value, utils.toNumber(cmbTipo.Value), utils.toNumber(txtBuscarCliente.Text), txtSerie.Text, txtDescripcion.Text, utils.toNumber(cmbSupervisor.Value), utils.toNumber(cmbEstados.Value), txtNumJob.Text).Tables(0)
            'dgvDatos.DataSource = dtDatos

            reporte.SetDataSource(dtDatos)
            forma.crvReportes.ReportSource = reporte

            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                forma.crvReportes.ShowExportButton = True
            Else
                forma.crvReportes.ShowExportButton = False
            End If
            'forma.crvReportes.RefreshReport = False
            'forma.crvReportes.DisplayGroupTree = False

            reporte.SetParameterValue("PorVencerSol", txtPorVencerSol.Text)
            reporte.SetParameterValue("PorVencerDol", txtPorVencerDol.Text)
            reporte.SetParameterValue("VencidoSol", txtVencidoSol.Text)
            reporte.SetParameterValue("VencidoDol", txtVencidoDol.Text)
            reporte.SetParameterValue("SaldoSol", txtSaldoSol.Text)
            reporte.SetParameterValue("SaldoDol", txtSaldoDol.Text)

            forma.Text = "Listado de Documentos de Cuentas Corrientes"
            forma.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al Imprimir" + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class

