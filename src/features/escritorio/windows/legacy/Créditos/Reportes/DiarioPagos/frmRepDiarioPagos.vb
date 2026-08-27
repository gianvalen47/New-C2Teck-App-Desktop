Imports System.ServiceModel
Public Class frmRepDiarioPagos
    Private oDocumentoCtaCtesService As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private ObjPago As New PagoPlanillaService.PagoPlanillaServiceClient
    Private oCentroCostoService As New CentroCostoService.CentroCostoServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtUnidades As DataTable
    Private dtTipoDocumentos As DataTable
    Private dtBancos As DataTable
    Private dtTipo As DataTable
    Private IdCliente As String
    Private TipCta As String
    Private Efectivo As Boolean

    Private Sub frmRepDiarioPagos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub frmRepDiarioPagos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            cbFecInicio.KeyPress _
            , cbFecFinal.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmRepDiarioPagos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 46)
        '/*************************************************************************************/

        'Comentado por Pedido de Angelica
        'Dim Mes, Anio As Integer
        'Dim Fecha As Date
        'Fecha = Today
        'Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
        'Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
        cbFecInicio.Value = CDate("01/" & utils.toBlank(Month(Today)) & "/" & utils.toBlank(Year(Today)))
        cbFecFinal.Value = Date.Today
        llenarCombos()
        cbMonedaDolares.Checked = True
        cbFecInicio.Select()

        rbExportExcel.Enabled = IIf(oSeguridadService.ObtenerExpDatos(Session.sCodUsu) = True, True, False)
    End Sub

    Private Sub frmRepPlanilla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            oDocumentoCtaCtesService.Close()
            oMaestroService.Close()
            ObjPago.Close()
            oCentroCostoService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oCentroCostoService.Abort()
            oDocumentoCtaCtesService.Abort()
            oMaestroService.Abort()
            ObjPago.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oCentroCostoService.Abort()
            oDocumentoCtaCtesService.Abort()
            oMaestroService.Abort()
            ObjPago.Abort()
            oSeguridadService.Abort()
        End Try
        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Todos)"
        Catch ex As Exception

        End Try

        'Try
        '    fila(5) = "(Todos)"
        'Catch ex As Exception

        'End Try

        Return fila
    End Function
    Private Sub llenarCombos()
        Try
            dtTipo = oDocumentoCtaCtesService.MostrarTipoPagoGen.Tables(0)
            dtTipo.Rows.InsertAt(getRowTodos(dtTipo), 0)
            cbTipoPago.DataSource = dtTipo
            cbTipoPago.DisplayMember = "DesPag"
            cbTipoPago.ValueMember = "CodPago"
            cbTipoPago.DropDownList.Columns(0).DataMember = "CodPago"
            cbTipoPago.DropDownList.Columns(1).DataMember = "DesPag"
            dtTipo = Nothing

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

            '======================================= BANCOS =================================================
            dtBancos = oMaestroService.MostrarBancos.Tables(0)
            dtBancos.Rows.InsertAt(getRowTodos(dtBancos), 0)
            cmbBanco.DataSource = dtBancos
            cmbBanco.DropDownList.DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.DisplayMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.ValueMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(0).DataMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(1).DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.SelectedIndex = 0
            dtBancos = Nothing

            '================================= UNIDADES DE NEGOCIO =========================================
            dtUnidades = oCentroCostoService.MostrarUnidadNegocio(Session.sCodEmp, "").Tables(0)
            dtUnidades.Rows.InsertAt(getRowTodos(dtUnidades), 0)
            cmbUnidad.DataSource = dtUnidades
            cmbUnidad.DropDownList.DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.DisplayMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.DropDownList.ValueMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(0).DataMember = dtUnidades.Columns("IdUnidad").ToString
            cmbUnidad.DropDownList.Columns(1).DataMember = dtUnidades.Columns("DesUnidad").ToString
            cmbUnidad.SelectedIndex = 0
            dtUnidades = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub MostrarReporte()
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rpRepDiarioPago
            Dim Tipo As Integer

            If cbMonedaDolares.Checked = True Then
                Tipo = 2
            Else
                Tipo = 1
            End If

            dtReporte = oDocumentoCtaCtesService.DiarioPagos(Session.sCodEmp, TipCta, cbFecInicio.Value, cbFecFinal.Value, cmbDocu.Value, Efectivo, IIf(cbTipoPago.Text = "(Todos)", "", cbTipoPago.Value), IIf(txtCliente.Text = "", 0, IdCliente), Tipo, toBlank(cmbBanco.Value), IIf(cmbUnidad.Text = "(Todos)", 0, cmbUnidad.Value)).Tables(0)
            DataGridView1.DataSource = dtReporte
            If dtReporte.Rows.Count = 0 Then
                MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            Else
                If rbExportExcel.Checked Then
                    Dim Export As Boolean = ExportarExcel(DataGridView1)
                    If Export Then
                        MsgBox("Se realizó la exportación correctamente ")
                    End If
                ElseIf rbPantalla.Checked Then
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Reporte de Diario de Pagos de Cuentas Corrientes"
                    reporte.SetParameterValue("FecInicio", cbFecInicio.Value)
                    reporte.SetParameterValue("FecFinal", cbFecFinal.Value)
                    If cmbDocu.Value = 0 Then
                        reporte.SetParameterValue("Documento", "Todos los Documentos")
                    Else
                        reporte.SetParameterValue("Documento", cmbDocu.Text)
                    End If
                    If cbTipoPago.Text = "(Todos)" Then
                        reporte.SetParameterValue("TipPago", "Pagos en Efectivo")
                    Else
                        reporte.SetParameterValue("TipPago", "Forma de Pago:" & cbTipoPago.Text)
                    End If
                    If txtCliente.Text = "" Then
                        reporte.SetParameterValue("Cliente", "")
                    Else
                        reporte.SetParameterValue("Cliente", txtCliente.Text)
                    End If
                    reporte.SetParameterValue("UnidadNegocio", cmbUnidad.Text)
                    If TipCta = 1 Then
                        reporte.SetParameterValue("TipCta", "Cuentas Corrientes")
                    ElseIf TipCta = 2 Then
                        reporte.SetParameterValue("TipCta", "Provisiones")
                    ElseIf TipCta = 3 Then
                        reporte.SetParameterValue("TipCta", "Castigos")
                    End If
                    'dtReporte.WriteXmlSchema("C:\DiarioPago.xml")

                    forma.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            ' txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
        End If
    End Sub

    Private Sub biAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        oSeguridadService.RegistrarVisitaOpciones(46, "SIGECOM", Session.sCodUsu, Session.sNomPc, Session.sDirIp)
        MostrarReporte()
    End Sub

    Private Sub biCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub rcEfectivo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rcEfectivo.CheckedChanged
        If rcEfectivo.Checked Then
            cbTipoPago.Enabled = False
            cbTipoPago.Value = "(Todos)"
            Efectivo = True
        Else
            cbTipoPago.Enabled = True
            Efectivo = False
        End If
    End Sub

    Private Sub rbBuscarCliente_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBuscarCliente.CheckedChanged
        If rbBuscarCliente.Checked Then
            lblCliente.Enabled = False
            txtCliente.Enabled = False
            btnBuscarCliente.Enabled = False
            txtCliente.Text = ""
            IdCliente = 0
        Else
            lblCliente.Enabled = True
            txtCliente.Enabled = True
            btnBuscarCliente.Enabled = True
        End If
    End Sub

    Private Sub rbCtasCtes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCtasCtes.CheckedChanged, rbCastigos.CheckedChanged, rbProvisiones.CheckedChanged
        If rbCtasCtes.Checked Then
            TipCta = 1
        ElseIf rbProvisiones.Checked Then
            TipCta = 2
        ElseIf rbCastigos.Checked Then
            TipCta = 3
        End If
    End Sub
End Class