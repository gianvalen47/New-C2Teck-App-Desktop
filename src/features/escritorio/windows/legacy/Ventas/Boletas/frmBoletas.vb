Imports System.ServiceModel
Imports LibreriaFacturacion
Imports System.Xml
Imports System.Text
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports UblLarsen.Ubl2
Imports System.Xml.Serialization
Imports UblLarsen.Ubl2.Cac
Imports UblLarsen.Ubl2.Udt
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports UblLarsen.Ubl2.aplicacion
Imports Ionic.Zip
Imports ZXing
Imports ZXing.PDF417
Imports ZXing.PDF417.Internal

Public Class frmBoletas
    Private oMaestroService As New MaestroService.MaestroClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oBoletaDetalleService As New BoletaDetalleService.BoletaDetalleServiceClient
    Private oBoletaDigitalService As New BoletaDigitalService.BoletaDigitalServiceClient
    Private oResumenBoletaDigitalService As New ResumenBoletasDigitalService.ResumenBoletasDigitalServiceClient
    Private oCommunicationState As New ComunicacionSunat
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    Private oContabilidad As New ContabilidadService.ContabilidadServiceClient
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    Private IdClienteBol As Integer
    Private IdLocacion As Integer
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClientes As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable
    Private dtTipos As DataTable
    Private dtTipo As DataTable
    Private lAprobacion As Boolean
    Dim UbicacionCodBarra As String
    Dim NombreXMLPDF As String = ""
    '==================================== CAMPOS EVENTO DESCARGAR FACTURA ELECTRONICA
    Dim CodMot As String
    Dim LegalMonetaryTotal As Double
    Dim CurrencyId As String
    Dim TipoDoc As String
    Dim TaxAmount As Double
    Dim CodSerieFac As String
    Dim NumDocFac As String
    Dim DocumentoFac As String
    Dim FecDoc As Date
    Dim RucCli As String
    Dim DniCli As String
    Dim RucEmp As String
    Dim CodMon As String

    Dim ValorResumen As String
    Dim ValorFirma As String

    '====================================================================================================================
    '============================================= CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
 _
                      , cmbMes.KeyPress _
                      , cmbTipFac.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
                      , txtIdCliente.KeyPress _
                      , cmbMes.KeyPress _
                      , btnBuscar.KeyPress _
                      , cmbTipFac.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub txtIdCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdCliente.KeyDown
        If e.KeyCode = Keys.F12 Or Keys.Enter Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click

        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                chkCliente.Checked = False
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            cmbEstado.Select()
            listaDatos()
        End If

    End Sub

    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdBoleta").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmBoletas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        ElseIf e.KeyCode = Keys.End Then
            e.Handled = True
            dgvDatos.Select()
            dgvDatos.Row = dgvDatos.RowCount - 1
            dgvDatos.Col = 1
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                biMostrar_Click(sender, e)
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 18)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        state_Search = False
        llenarCombos()
        'txtanio.Value = Today.Year
        'cmbMes.Value = Today.Month
        txtanio.Value = Session.sFecha.Year
        cmbMes.Value = Session.sFecha.Month

        IdCliente = 0
        txtIdCliente.Text = "(Todos)"
        'cmbEstado.Value = "GN"
        state_Search = True
        listaDatos()
        dgvDatos.Select()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oBoletaService.Close()
            oBoletaDetalleService.Close()
            oResumenBoletaDigitalService.Close()
            oSeguridadService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oBoletaService.Abort()
            oBoletaDetalleService.Abort()
            oResumenBoletaDigitalService.Abort()
            oSeguridadService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oBoletaService.Abort()
            oBoletaDetalleService.Abort()
            oResumenBoletaDigitalService.Abort()
            oSeguridadService.Abort()
        End Try
        Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal numero As String)
        If type_process = "update" Then
            cmbEstado.Value = ""
            cmbTipFac.SelectedIndex = 0
            txtNumDoc.Text = numero
        ElseIf type_process = "insert" Then
            cmbEstado.Value = "GN"
            cmbTipFac.SelectedIndex = 0
            txtNumDoc.Text = numero
        End If
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biTicket.Enabled = False
            biSugerir.Enabled = False
            biEnviar.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biAnular.Enabled = False
            biEstados.Enabled = False

            miImprimir.Enabled = False
            miTicket.Enabled = False
            miEnviar.Enabled = False
            miSugerir.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miAnular.Enabled = False
            miEstados.Enabled = False
            miGenerarAsiento.Enabled = False
            miVerAsientoContable.Enabled = False
            '========================= Agregado el 14/03/2013 ==========================
            If cmbIdLocacion.DropDownList.GetRow.Cells(2).Text = "003" Or cmbIdLocacion.DropDownList.GetRow.Cells(2).Text = "009" Then
                biFacturarJob.Enabled = True
                miFacturarJob.Enabled = True
            Else
                biFacturarJob.Enabled = False
                miFacturarJob.Enabled = False
            End If
            '======================================================================
        Else
            Dim lEstado, lMotivo As String
            Dim lTotal As Decimal
            Dim lIdSugerido As Integer
            'Dim iBuscarGuia As Boolean

            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            lMotivo = dgvDatos.CurrentRow.Cells("CodMot").Text
            lTotal = dgvDatos.CurrentRow.Cells("TotNeto").Value
            lIdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Value

            biImprimir.Enabled = IIf(lEstado = "AN" Or lIdSugerido > 0, False, True)
            biTicket.Enabled = IIf(lEstado = "AN", False, True)
            biEnviar.Enabled = IIf(lEstado = "GN" And lTotal > 0 And lIdSugerido > 0, True, False)
            'biSugerir.Enabled = IIf(lEstado = "GN" And lMotivo = "1" And lTotal > 0 And lAprobacion, True, False)
            biMostrar.Enabled = IIf(lEstado = "AN", False, True)
            biEliminar.Enabled = IIf(lEstado = "GN" Or lEstado = "AP", True, False)
            biAnular.Enabled = IIf(lEstado = "IM", True, False)
            'biBajarNivel.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12"), True, False)
            biBajarNivel.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05") And (lEstado = "IM"), True, False)  '------ Se agrega el Perfil de Costos 02/08/2016

            'Se comento segun Solicitud de Usuario 3451
            'iBuscarGuia = oBoletaService.BuscarGuia(dgvDatos.CurrentRow.Cells("IdBoleta").Text)
            'If iBuscarGuia = True Then
            '    biSugerir.Enabled = False
            'Else
            biSugerir.Enabled = IIf((lEstado = "GN" Or lEstado = "AP") And lTotal > 0 And dgvDatos.CurrentRow.Cells("Aprobar").Text = True, True, False)
            'End If

            'biSugerir.Enabled = IIf((lEstado = "GN" Or lEstado = "AP") And lTotal > 0 And dgvDatos.CurrentRow.Cells("Aprobar").Text = True, True, False)
            biEstados.Enabled = True

            miImprimir.Enabled = IIf(lEstado = "AN" Or lIdSugerido > 0, False, True)
            'miImprimir.Enabled = IIf(lEstado = "AP" Or lEstado = "IM" Or lEstado = "FC", True, False)
            miTicket.Enabled = IIf(lEstado = "AN", False, True)
            miEnviar.Enabled = IIf(lEstado = "GN" And lTotal > 0 And lIdSugerido > 0, True, False)
            'miSugerir.Enabled = IIf(lEstado = "GN" And lMotivo = "1" And lTotal > 0 And lAprobacion, True, False)
            miMostrar.Enabled = IIf(lEstado = "AN", False, True)
            miEliminar.Enabled = IIf(lEstado = "GN" Or lEstado = "AP", True, False)
            miAnular.Enabled = IIf(lEstado = "IM", True, False)
            'miBajarNivel.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12"), True, False)
            miBajarNivel.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05") And (lEstado = "IM"), True, False)  '------ Se agrega el Perfil de Costos 02/08/2016

            'Se comento segun Solicitud de Usuario 3451
            'If iBuscarGuia = True Then
            '    miSugerir.Enabled = False
            'Else
            miSugerir.Enabled = IIf((lEstado = "GN" Or lEstado = "AP") And lTotal > 0 And dgvDatos.CurrentRow.Cells("Aprobar").Text = True, True, False)
            'End If
            'miSugerir.Enabled = IIf((lEstado = "GN" Or lEstado = "AP") And lTotal > 0 And dgvDatos.CurrentRow.Cells("Aprobar").Text = True, True, False)
            miEstados.Enabled = True

            '========================= Agregado el 14/03/2013 ==========================
            If cmbIdLocacion.DropDownList.GetRow.Cells(2).Text = "003" Or cmbIdLocacion.DropDownList.GetRow.Cells(2).Text = "009" Then
                biFacturarJob.Enabled = True
                miFacturarJob.Enabled = True
            Else
                biFacturarJob.Enabled = False
                miFacturarJob.Enabled = False
            End If
            '======================================================================

            miGenerarAsiento.Enabled = True
            miVerAsientoContable.Enabled = True

        End If
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
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdBoleta").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
        enableOpciones()
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub mostrar()
        If dgvDatos.CurrentRow.Cells("Estado").Text <> "AN" Then
            Try
                Dim frm As New frmBoleta
                Dim lEstado As String
                lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
                frm.state_button = True
                frm.IdBoleta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
                frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Value
                frm.TipFac = cmbTipFac.Value
                frm.edicion = False
                frm.editable = IIf(lEstado = "GN" Or lEstado = "AP" Or lEstado = "CR", True, False)
                frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
                frm.Text = "BOLETA AL " & cmbTipFac.Text & " N° : " & dgvDatos.CurrentRow.Cells("NumDoc").Text
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    If frm.type_process = "update" Then
                        '    limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text)
                        listaDatos()
                        RowPossesion(dgvDatos, frm.IdBoleta)
                    Else
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                actualizar()
            Catch ex As Exception
                MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub eliminar()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean

                estado_process = oBoletaService.Borrar(dgvDatos.CurrentRow.Cells("IdBoleta").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ImprimirCairo()
        Try
            If ValidaCodigoSeleccionado() Then
                If MsgBox("¿Está Seguro de IMPRIMIR la Boleta Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                    Dim frm As New frmBoleta_ImprimirCairo
                    frm.Text = "Imprimir"
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        If frm.Imprimir = True Then
                            '----------------------------------------------------------------------------------

                            Dim forma As New frmReportes
                            Dim reporteResumen As New rpImprimirBoletaCairoResumen
                            Dim dtReporte As New DataTable
                            Dim dtDetalles As New DataTable
                            Dim IdBoleta As Integer = dgvDatos.CurrentRow.Cells("IdBoleta").Text
                            Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Text
                            Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
                            Dim TipoCambio As Decimal
                            Dim TotNeto As Decimal

                            dtReporte = oBoletaService.Imprimir(IdBoleta).Tables(0)
                            dtDetalles = oBoletaDetalleService.Mostrar(toNumber(IdBoleta)).Tables(0)
                            TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
                            TotNeto = dgvDatos.CurrentRow.Cells("TotNeto").Text

                            '/////////////////////////////////////////////////////////////////////////////
                            Dim Detalles As Integer
                            Dim A() As String
                            Dim registro As BoletaService.Boleta
                            registro = oBoletaService.MostrarPorId(IdBoleta)
                            txtObservacion.Text = toBlank(registro.Observacion)
                            A = Split(txtObservacion.Text, vbCrLf, -1, vbTextCompare)
                            Detalles = dtDetalles.Rows.Count
                            If (UBound(A) + 1) + Detalles > 14 Then
                                MsgBox("No puede imprimir por exceso de líneas,Verificar")
                            Else

                                If dtReporte.Rows.Count = 0 Then
                                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                                Else
                                    Dim Impresora As String = SeleccionarImpresora()
                                    If Impresora <> "" Then
                                        reporteResumen.SetDataSource(dtReporte)
                                        forma.crvReportes.ReportSource = reporteResumen

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        forma.Text = "Imprimir Boleta"

                                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                        'dtReporte.WriteXmlSchema("C:\Boleta.xml")
                                        reporteResumen.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                                        'reporteResumen.SetParameterValue("Documento", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))

                                        Select Case CodMon
                                            Case "US"
                                                reporteResumen.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                                            Case "EU"
                                                reporteResumen.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Euro = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                                            Case "NS"
                                                reporteResumen.SetParameterValue("TotalSoles", "")
                                        End Select

                                        reporteResumen.SetParameterValue("Documento", frm.Documento)
                                        'End If

                                        reporteResumen.PrintOptions.PrinterName = Impresora
                                        reporteResumen.PrintToPrinter(1, False, 0, 0)
                                        If Session.sCodEmp <> "01" Then
                                            oBoletaService.ActualizarEstadoImpreso(IdBoleta, Session.sCodUsu)
                                        End If
                                        actualizar()
                                        '  forma.crvReportes.PrintReport()
                                    End If
                                    'forma.ShowDialog()
                                End If
                            End If

                        Else
                            '----------------------------------------------------------------------------------
                            Dim forma As New frmReportes
                            Dim reporteDetallado As New rpImprimirBoletaCairo
                            Dim dtReporte As New DataTable
                            Dim dtDetalles As New DataTable
                            Dim IdBoleta As Integer = dgvDatos.CurrentRow.Cells("IdBoleta").Text
                            Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Text
                            Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
                            Dim TipoCambio As Decimal
                            Dim TotNeto As Decimal

                            dtReporte = oBoletaService.Imprimir(IdBoleta).Tables(0)
                            dtDetalles = oBoletaDetalleService.Mostrar(toNumber(IdBoleta)).Tables(0)
                            TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
                            TotNeto = dgvDatos.CurrentRow.Cells("TotNeto").Text

                            '/////////////////////////////////////////////////////////////////////////////
                            Dim Detalles As Integer
                            Dim A() As String
                            Dim registro As BoletaService.Boleta
                            registro = oBoletaService.MostrarPorId(IdBoleta)
                            txtObservacion.Text = toBlank(registro.Observacion)
                            A = Split(txtObservacion.Text, vbCrLf, -1, vbTextCompare)
                            Detalles = dtDetalles.Rows.Count
                            If (UBound(A) + 1) + Detalles > 14 Then
                                MsgBox("No puede imprimir por exceso de líneas,Verificar")
                            Else

                                If dtReporte.Rows.Count = 0 Then
                                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                                Else
                                    Dim Impresora As String = SeleccionarImpresora()
                                    If Impresora <> "" Then
                                        reporteDetallado.SetDataSource(dtReporte)
                                        forma.crvReportes.ReportSource = reporteDetallado

                                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                            forma.crvReportes.ShowExportButton = True
                                        Else
                                            forma.crvReportes.ShowExportButton = False
                                        End If
                                        'forma.crvReportes.RefreshReport = False
                                        'forma.crvReportes.DisplayGroupTree = False

                                        forma.Text = "Imprimir Boleta"

                                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                        'dtReporte.WriteXmlSchema("C:\Boleta.xml")
                                        reporteDetallado.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))

                                        Select Case CodMon
                                            Case "US"
                                                reporteDetallado.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                                            Case "EU"
                                                reporteDetallado.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Euro = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                                            Case "NS"
                                                reporteDetallado.SetParameterValue("TotalSoles", "")
                                        End Select

                                        reporteDetallado.SetParameterValue("Documento", frm.Documento)

                                        reporteDetallado.PrintOptions.PrinterName = Impresora
                                        reporteDetallado.PrintToPrinter(1, False, 0, 0)
                                        If Session.sCodEmp <> "01" Then
                                            oBoletaService.ActualizarEstadoImpreso(IdBoleta, Session.sCodUsu)
                                        End If
                                        actualizar()
                                        '  forma.crvReportes.PrintReport()
                                    End If
                                    'forma.ShowDialog()
                                End If
                            End If
                        End If
                    End If
                Else
                    dgvDatos.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub Imprimir()
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está Seguro de IMPRIMIR la Boleta Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                    Dim frm As New frmBoleta_Imprimir

                    If oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) = "067" Or oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) = "003" Or oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) = "004" Then
                        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                            If frm.Imprimir = True Then
                                ImprimirDetalle()
                            Else
                                Dim forma As New frmReportes
                                Dim reporte As New rpImprimirBoletaServicios
                                Dim dtReporte As New DataTable
                                Dim dtDetalles As New DataTable
                                Dim IdBoleta As Integer = dgvDatos.CurrentRow.Cells("IdBoleta").Text
                                Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Text
                                Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
                                Dim TipoCambio As Decimal
                                Dim TotNeto As Decimal

                                dtReporte = oBoletaService.Imprimir(IdBoleta).Tables(0)
                                dtDetalles = oBoletaDetalleService.Mostrar(toNumber(IdBoleta)).Tables(0)
                                TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
                                TotNeto = dgvDatos.CurrentRow.Cells("TotNeto").Text

                                '/////////////////////////////////////////////////////////////////////////////
                                Dim Detalles As Integer
                                Dim A() As String
                                Dim registro As BoletaService.Boleta
                                registro = oBoletaService.MostrarPorId(IdBoleta)
                                txtObservacion.Text = toBlank(registro.Observacion)
                                A = Split(txtObservacion.Text, vbCrLf, -1, vbTextCompare)
                                Detalles = dtDetalles.Rows.Count
                                If (UBound(A) + 1) + Detalles > 14 Then
                                    MsgBox("No puede imprimir por exceso de líneas,Verificar")
                                Else

                                    If dtReporte.Rows.Count = 0 Then
                                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                                    Else
                                        Dim Impresora As String = SeleccionarImpresora()
                                        If Impresora <> "" Then
                                            reporte.SetDataSource(dtReporte)
                                            forma.crvReportes.ReportSource = reporte

                                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                                forma.crvReportes.ShowExportButton = True
                                            Else
                                                forma.crvReportes.ShowExportButton = False
                                            End If
                                            'forma.crvReportes.RefreshReport = False
                                            'forma.crvReportes.DisplayGroupTree = False

                                            forma.Text = "Imprimir Boleta"

                                            'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                            'dtReporte.WriteXmlSchema("C:\Boleta.xml")
                                            reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                                            reporte.SetParameterValue("Transferencia", IIf(registro.Motivos.CodMot = "2", "TRANSFERENCIA GRATUITA", ""))
                                            reporte.SetParameterValue("TotTran", IIf(registro.Motivos.CodMot = "2", "0.00", ""))

                                            Select Case CodMon
                                                Case "US"
                                                    reporte.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                                                Case "EU"
                                                    reporte.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Euro = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                                                Case "NS"
                                                    reporte.SetParameterValue("TotalSoles", "")
                                            End Select

                                            reporte.PrintOptions.PrinterName = Impresora
                                            reporte.PrintToPrinter(1, False, 0, 0)
                                            If Session.sCodEmp <> "01" Then
                                                oBoletaService.ActualizarEstadoImpreso(IdBoleta, Session.sCodUsu)
                                            End If
                                            actualizar()
                                            '  forma.crvReportes.PrintReport()
                                        End If
                                        'forma.ShowDialog()
                                    End If
                                End If
                            End If
                        End If
                        'ElseIf oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) = "004" Then

                    Else
                        ImprimirDetalle()
                    End If
                Else
                    dgvDatos.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        End If
    End Sub

    Private Sub ImprimirDetalle()
        Try
            Dim forma As New frmReportes
            Dim reporte As New rpImprimirBoleta
            Dim dtReporte As New DataTable
            Dim dtDetalles As New DataTable
            Dim IdBoleta As Integer = dgvDatos.CurrentRow.Cells("IdBoleta").Text
            Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Text
            Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
            Dim TipoCambio As Decimal
            Dim TotNeto As Decimal

            dtReporte = oBoletaService.Imprimir(IdBoleta).Tables(0)
            dtDetalles = oBoletaDetalleService.Mostrar(toNumber(IdBoleta)).Tables(0)
            TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
            TotNeto = dgvDatos.CurrentRow.Cells("TotNeto").Text

            '/////////////////////////////////////////////////////////////////////////////
            Dim Detalles As Integer
            Dim A() As String
            Dim registro As BoletaService.Boleta
            registro = oBoletaService.MostrarPorId(IdBoleta)
            txtObservacion.Text = toBlank(registro.Observacion)
            A = Split(txtObservacion.Text, vbCrLf, -1, vbTextCompare)
            Detalles = dtDetalles.Rows.Count
            If (UBound(A) + 1) + Detalles > 14 Then
                MsgBox("No puede imprimir por exceso de líneas,Verificar")
            Else

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    Dim Impresora As String = SeleccionarImpresora()
                    If Impresora <> "" Then
                        reporte.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Boleta"

                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                        'dtReporte.WriteXmlSchema("C:\Boleta.xml")
                        reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                        reporte.SetParameterValue("Transferencia", IIf(registro.Motivos.CodMot = "2", "TRANSFERENCIA GRATUITA", ""))
                        reporte.SetParameterValue("TotTran", IIf(registro.Motivos.CodMot = "2", "0.00", ""))

                        Select Case CodMon
                            Case "US"
                                reporte.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                            Case "EU"
                                reporte.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Euro = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                            Case "NS"
                                reporte.SetParameterValue("TotalSoles", "")
                        End Select

                        reporte.PrintOptions.PrinterName = Impresora
                        reporte.PrintToPrinter(1, False, 0, 0)                          'Segun la solicitud de usuario 4547 se oculta el subtotal cuando sea motivo "transferencia gratuita"
                        If Session.sCodEmp <> "01" Then
                            oBoletaService.ActualizarEstadoImpreso(IdBoleta, Session.sCodUsu)
                        End If
                        actualizar()
                        '  forma.crvReportes.PrintReport()
                    End If
                    'forma.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oBoletaService.Filtrar(txtanio.Value _
                                                     , cmbMes.Value _
                                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                     , toBlank(cmbTipFac.Value) _
                                                     , toNumber(IdCliente) _
                                                     , cmbEstado.Value _
                                                     , toNumber(txtNumDoc.Text)).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Nuevo()
        Try
            'If oBoletaService.PermisoBoleta(Session.sCodUsu, cmbTipFac.Value) = False Then
            '    MsgBox("No tiene Permiso para hacer boletas al " & cmbTipFac.Text, MsgBoxStyle.Information, "No tiene Permiso")
            '    Exit Sub
            'End If

            Dim frm As New frmBoleta
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.IdLocacion = cmbIdLocacion.Value
            frm.TipFac = cmbTipFac.Value
            frm.txtNumDoc.Text = oBoletaService.SugerirNumero(Session.sCodUsu, cmbIdLocacion.Value)
            'frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", cmbIdLocacion.Value))
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.Text = "Registrar Nueva Boleta al " & cmbTipFac.Text
            frm.IdSugerido = 0

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ' limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text)
                listaDatos()
                ' If frm.type_process = "insert" Then
                RowPossesion(dgvDatos, frm.IdBoleta)
                mostrar()
                actualizar()
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Ticket()
        If ValidaCodigoSeleccionado() Then
            Try
                Dim forma As New frmReportes
                Dim reporte As New rpImprimirTicket
                Dim reporte1 As New rpImprimirTicketNuevo
                Dim reporte2 As New rpImprimirTicketNuevo2
                Dim dtReporte As New DataTable
                Dim IdBoleta As Integer = dgvDatos.CurrentRow.Cells("IdBoleta").Text

                dtReporte = oBoletaService.Imprimir(IdBoleta).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    Dim Impresora As String = SeleccionarImpresora()
                    If dtReporte.Rows.Count < 5 Then

                        If Impresora <> "" Then
                            reporte.SetDataSource(dtReporte)
                            forma.crvReportes.ReportSource = reporte

                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                forma.crvReportes.ShowExportButton = True
                            Else
                                forma.crvReportes.ShowExportButton = False
                            End If
                            'forma.crvReportes.RefreshReport = False
                            'forma.crvReportes.DisplayGroupTree = False

                            forma.Text = "Imprimir Ticket"

                            reporte.PrintOptions.PrinterName = Impresora
                            reporte.PrintToPrinter(1, False, 0, 0)
                        End If
                    ElseIf dtReporte.Rows.Count >= 5 And dtReporte.Rows.Count < 14 Then

                        reporte1.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte1

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Ticket"

                        reporte1.PrintOptions.PrinterName = Impresora
                        reporte1.PrintToPrinter(1, False, 0, 0)

                    ElseIf dtReporte.Rows.Count >= 14 Then

                        reporte2.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporte2

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        forma.Text = "Imprimir Ticket"

                        reporte2.PrintOptions.PrinterName = Impresora
                        reporte2.PrintToPrinter(1, False, 0, 0)

                    End If

                    'reporte.SetDataSource(dtReporte)
                    'forma.crvReportes.ReportSource = reporte

                    'forma.Text = "Imprimir Ticket"

                    'forma.crvReportes.PrintReport()
                End If

                'If dtReporte.Rows.Count = 0 Then
                '    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                'Else
                '    reporte.SetDataSource(dtReporte)
                '    forma.crvReportes.ReportSource = reporte
                '    'forma.crvReportes.DisplayGroupTree = False
                '    'forma.crvReportes.RefreshReport = False
                '    forma.Text = "Imprimir Ticket"

                '    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                '    'dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")

                '    forma.crvReportes.PrintReport()
                'End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        End If
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdBoleta").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub llenarCombos()
        Try
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinasEmpresa(Session.sCodEmp, Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
            '======================================= MESES ================================================
            dtMeses = oMaestroService.MostrarMeses
            dtMeses.Rows.InsertAt(getRowTodos(dtMeses), 0)
            cmbMes.DataSource = dtMeses
            cmbMes.DropDownList.DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.DisplayMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.DropDownList.ValueMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(0).DataMember = dtMeses.Columns("Codigo").ToString
            cmbMes.DropDownList.Columns(1).DataMember = dtMeses.Columns("Descripcion").ToString
            cmbMes.SelectedIndex = 0
            dtMeses = Nothing
            '======================================= ESTADOS ================================================
            dtEstados = oBoletaService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing

            '======================================= TIPOS DE FACTURAS ================================================
            ' Comentado el 10/10/2013 para filtrar por usuario 
            'dtTipos = New DataTable
            'dtTipos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            'dtTipos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            ''dtTipos.Rows.Add(New Object() {"", "(Todos)"})
            'dtTipos.Rows.Add(New Object() {"1", "Crédito"})
            'dtTipos.Rows.Add(New Object() {"2", "Contado"})

            'cmbTipFac.DataSource = dtTipos
            'cmbTipFac.DropDownList.DataMember = dtTipos.Columns("nombre").ToString
            'cmbTipFac.DropDownList.DisplayMember = dtTipos.Columns("nombre").ToString
            'cmbTipFac.DropDownList.ValueMember = dtTipos.Columns("codigo").ToString
            'cmbTipFac.DropDownList.Columns(0).DataMember = dtTipos.Columns("codigo").ToString
            'cmbTipFac.DropDownList.Columns(1).DataMember = dtTipos.Columns("nombre").ToString
            'cmbTipFac.SelectedIndex = 1
            'dtTipos = Nothing

            dtTipos = oBoletaService.MostrarTipo(Session.sCodUsu)
            'dtTipos.Rows.InsertAt(getRowTodos(dtTipos), 0)
            cmbTipFac.DataSource = dtTipos
            cmbTipFac.DropDownList.DataMember = dtTipos.Columns("Descripcion").ToString
            cmbTipFac.DropDownList.DisplayMember = dtTipos.Columns("Descripcion").ToString
            cmbTipFac.DropDownList.ValueMember = dtTipos.Columns("TipFac").ToString
            cmbTipFac.DropDownList.Columns(0).DataMember = dtTipos.Columns("TipFac").ToString
            cmbTipFac.DropDownList.Columns(1).DataMember = dtTipos.Columns("Descripcion").ToString
            cmbTipFac.SelectedIndex = 0
            dtTipos = Nothing

        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub
    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        Nuevo()
    End Sub
    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        'If oBoletaService.PermisoBoleta(Session.sCodUsu, cmbTipFac.Value) = False Then
        '    MsgBox("No tiene Permiso para Eliminar esta Boleta", MsgBoxStyle.Information, "No tiene Permiso")
        '    Exit Sub
        'End If
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                   cmbEstado.ValueChanged _
                  , cmbMes.ValueChanged _
                  , cmbTipFac.ValueChanged
        listaDatos()
    End Sub
    Private Sub cmbOficinas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOficinas.ValueChanged
        If toBlank(cmbOficinas.Value) <> "" Then
            '======================================= ALMACENES ================================================
            dtAlmacenes = oMaestroService.MostrarLocaciones(Session.sCodEmp, cmbOficinas.Value, Session.sCodUsu).Tables(0)
            cmbIdLocacion.DataSource = dtAlmacenes
            cmbIdLocacion.DropDownList.DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.DisplayMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.ValueMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(0).DataMember = dtAlmacenes.Columns("IdLocacion").ToString
            cmbIdLocacion.DropDownList.Columns(1).DataMember = dtAlmacenes.Columns("DesAlm").ToString
            cmbIdLocacion.DropDownList.Columns(2).DataMember = dtAlmacenes.Columns("CodAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            ' dtAlmacenes = Nothing
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub
    Private Sub txtFecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub txtFecFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listaDatos()
    End Sub
    Private Sub txtanio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtanio.Click
        listaDatos()
    End Sub
    Private Sub txtIdCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If toNull(frm.codigo) <> Nothing Then
                chkCliente.Checked = False
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            listaDatos()
        End If
    End Sub

    Private Sub cmbIdLocacion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbIdLocacion.ValueChanged
        If dtAlmacenes.Rows.Count > 0 Then
            lAprobacion = dtAlmacenes.Rows(cmbIdLocacion.SelectedIndex).Item("AproDoc")
        Else
            lAprobacion = False
        End If
        listaDatos()
    End Sub

    Private Sub biAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.Click, miAnular.Click
        'If oBoletaService.PermisoBoleta(Session.sCodUsu, cmbTipFac.Value) = False Then
        '    MsgBox("No tiene Permiso para Anular esta Boleta", MsgBoxStyle.Information, "No tiene Permiso")
        '    Exit Sub
        'End If
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está seguro de ANULAR la Boleta Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                    Dim estado_process As Boolean
                    If dgvDatos.CurrentRow.Cells("TipMov").Text <> "O" And cmbOficinas.Value = "01" And cmbIdLocacion.Value <> 3 And cmbOficinas.Value <> 10 Then

                        dtDatos = oBoletaDetalleService.Mostrar(toNumber(dgvDatos.CurrentRow.Cells("IdBoleta").Text)).Tables(0)
                        Dim Contador As Integer = 0

                        For Each Fila As DataRow In dtDatos.Rows
                            If Mid(Trim(Fila.Item("CodMer")), 1, 3) = "AAA" Then
                                Contador = Contador + 0
                            Else
                                Contador = Contador + 1
                            End If
                        Next
                        If Contador > 0 Then
                            estado_process = oBoletaService.AnulacionConsulta(dgvDatos.CurrentRow.Cells("IdBoleta").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                            MsgBox("La Boleta fue enviada a CONSULTA para su anulación, Comuníquese con Almacén  ...!!!", MsgBoxStyle.Information)
                        Else
                            estado_process = oBoletaService.Anular(dgvDatos.CurrentRow.Cells("IdBoleta").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                            MsgBox("La Boleta fue Anulada correctamente.", MsgBoxStyle.Information)
                        End If
                    Else
                        estado_process = oBoletaService.Anular(dgvDatos.CurrentRow.Cells("IdBoleta").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("La Boleta fue Anulada correctamente.", MsgBoxStyle.Information)
                    End If
                    If estado_process = True Then
                        actualizar()
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ANULAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Sub biRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        actualizar()
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Boleta actual."
    End Sub
    Private Sub Ticket_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTicket.MouseEnter, miTicket.MouseEnter
        sslError.Text = "Imprimir Ticket de Almacén de la Boleta actual."
    End Sub
    Private Sub Enviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar a Créditos para su Aprobación la Boleta actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Boleta."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Boleta actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Boleta actual."
    End Sub
    Private Sub Sugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.MouseEnter, miSugerir.MouseEnter
        sslError.Text = "Sugerir Factor o Descuento al Documento."
    End Sub
    Private Sub Anular_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.MouseEnter
        sslError.Text = "Anular Boleta actual."
    End Sub
    Private Sub FacturarJob_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biFacturarJob.MouseEnter, miFacturarJob.MouseEnter
        sslError.Text = "Facturar Job."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Estados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.MouseEnter, miEstados.MouseEnter
        sslError.Text = "Mostrar Estados de la Boleta."
    End Sub
    Private Sub ConsultarSugerido_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConsultarSugerido.MouseEnter, miConsultarSugerido.MouseEnter
        sslError.Text = "Mostrar Precios Sugeridos."
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                     biImprimir.MouseLeave, biTicket.MouseLeave, biEnviar.MouseLeave, biConsultarSugerido.MouseLeave, _
                                     biNuevo.MouseLeave, biMostrar.MouseLeave, biSugerir.MouseLeave, biEstados.MouseLeave, _
                                     biEliminar.MouseLeave, biAnular.MouseLeave, biFacturarJob.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave, _
                                     miImprimir.MouseLeave, miTicket.MouseLeave, miEnviar.MouseLeave, miConsultarSugerido.MouseLeave, _
                                     miNuevo.MouseLeave, miMostrar.MouseLeave, miSugerir.MouseLeave, miEstados.MouseLeave, _
                                     miEliminar.MouseLeave, miFacturarJob.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        If Session.sCodEmp = "03" Then
            ImprimirCairo()
        Else
            Imprimir()
        End If
    End Sub

    Private Sub biTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTicket.Click
        Ticket()
    End Sub

    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub miTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTicket.Click
        Ticket()
    End Sub

    Private Sub miImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click
        If Session.sCodEmp = "03" Then
            ImprimirCairo()
        Else
            Imprimir()
        End If
    End Sub

    Private Sub biSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.Click, miSugerir.Click
        Try
            If toNumber(dgvDatos.CurrentRow.Cells("IdSugerido").Text) > 0 Then
                Dim factor As Double
                Dim dscto As Double
                factor = dgvDatos.CurrentRow.Cells("FactorSug").Text
                dscto = dgvDatos.CurrentRow.Cells("DsctoSug").Text
                If factor + dscto = 0 And dgvDatos.CurrentRow.Cells("TotNetoSug").Text Then
                    MsgBox("No puede hacer sugerencias por Documento, por que ya se hizo a nivel de Detalle ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If
            Dim frm As New frmBoleta_SugerirCabecera
            frm.IdBoleta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
            frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
        'If Not (Char.IsDigit(e.KeyChar)) Then
        '    e.Handled = True
        'End If
        If Asc(e.KeyChar) = 3 Then
            e.Handled = False
        Else
            e.Handled = Not (e.KeyChar = "")
        End If
    End Sub

    Private Sub biEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        If ValidaCodigoSeleccionado() Then
            Try
                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ENVIAR la Boleta Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " a Créditos para su aprobación ... ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean

                    estado_process = oBoletaService.EnviarCreditos(dgvDatos.CurrentRow.Cells("IdBoleta").Text, Session.sCodUsu)
                    If estado_process = True Then
                        dtDatos = Nothing
                        actualizar()
                        MsgBox("La Boleta fue Enviada a Créditos correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ENVIAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Sub chkCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCliente.CheckedChanged
        If txtIdCliente.Text <> "(Todos)" Then
            chkCliente.Enabled = False
            txtIdCliente.Text = "(Todos)"
            IdCliente = 0
            listaDatos()
        Else
            chkCliente.Enabled = True
            pboxLimpiarCliente.Enabled = True
        End If
    End Sub

    Private Sub biConsultarSugerido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConsultarSugerido.Click, miConsultarSugerido.Click
        Try
            Dim frm As New frmGuiaRemision_ConsultarSugerido

            frm.IdCodigo = dgvDatos.CurrentRow.Cells("IdBoleta").Text
            frm.TipoCodigo = "BO"
            frm.Text = "Precios Sugeridos de Boleta Nº : " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("Error al consultar precios sugeridos : " + ex.Message)
        End Try
    End Sub

    Private Sub biEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.Click, miEstados.Click
        Try
            Dim frm As New frmBoleta_Estados
            frm.IdBoleta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
            frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("Error al mostrar los estados : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biFacturarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biFacturarJob.Click, miFacturarJob.Click
        Try
            If ValidaFacturarJob() Then
                Dim frm As New frmFactura_AtenderJob
                frm.Documento = 2   '------ Agregado el 14/03/2013 (reutilizando frmAtenderJob en el módulo de Facturas y Boletas)
                frm.txtNumDoc.Text = oBoletaService.SugerirNumero(Session.sCodUsu, cmbIdLocacion.Value)
                frm.CodOfi = cmbOficinas.Value
                frm.IdLocacion = cmbIdLocacion.Value
                frm.TipFac = cmbTipFac.Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ' limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdBoleta)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL FACTURAR LA OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaFacturarJob() As Boolean
        Try
            If cmbIdLocacion.Value <> 3 And cmbIdLocacion.Value <> 16 And cmbIdLocacion.Value <> 54 Then 'Se agrega el almacen de componentes 12/12/2016
                MsgBox("No puede atender Job por esta Locación")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR FACTURAR JOB: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub biBajarNivel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biBajarNivel.Click, miBajarNivel.Click

        Try
            Dim frm As New frmDocVenta_ActualizarEstado

            frm.Text = "Actualizar a estado inicial"
            frm.TipoDoc = "Boleta"
            frm.IdDocVenta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
            frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biBoletaElectronica_Click(sender As System.Object, e As System.EventArgs) Handles biGenerarBoletaElectronica.Click, miGenerarBoletaElectronica.Click
        Try
            Dim existebolelec As Boolean
            Dim opcionimp As String
            Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Text
            Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
            Dim TipoCambio As Decimal
            Dim TotNeto As Decimal
            Dim TotalSoles As String

            TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
            TotNeto = dgvDatos.CurrentRow.Cells("TotNeto").Text
            TotalSoles = "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero)

            existebolelec = oBoletaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdBoleta").Text)
            'existebolelec = False

            If existebolelec = True Then
                MsgBox("Ya existe la boleta electronica, verifique.", MsgBoxStyle.Information)
            Else
                'If oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) = "067" Or oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) = "003" Or oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) = "004" Then

                Dim frm As New frmBoleta_BoletaElectronica_Imprimir
                frm.IdBoletaImpresion = dgvDatos.CurrentRow.Cells("IdBoleta").Text
                frm.TotalSoles = TotalSoles
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    opcionimp = frm.Imprimir
                    Dim frm1 As New frmBoleta_BoletaElectronica
                    frm1.IdBoleta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
                    frm1.opcionimp = opcionimp
                    frm1.TotalSoles = TotalSoles
                    If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        If frm1.EstadoSunat = True Then
                            listaDatos()
                            RowPossesion(dgvDatos, frm1.IdBoleta)
                        End If
                    End If
                Else
                    Exit Sub
                End If
                'Else
                '    If MsgBox("¿Está Seguro de GENERAR la Boleta Electrónica Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                '        Dim frm As New frmBoleta_BoletaElectronica
                '        frm.IdBoleta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
                '        frm.opcionimp = "Detallado"
                '        frm.TotalSoles = TotalSoles
                '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                '            If frm.EstadoSunat = True Then
                '                listaDatos()
                '                RowPossesion(dgvDatos, frm.IdBoleta)
                '            End If
                '        End If
                '    End If
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al generar la boleta electronica")
        End Try
    End Sub

    Private Sub biDarBajaBoletaElectronica_Click(sender As System.Object, e As System.EventArgs) Handles biDarBajaBoletaElectronica.Click, miDarBajaBoletaElectronica.Click
        Try
            Dim existebolelec As Boolean
            existebolelec = oBoletaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdBoleta").Text)
            'existebolelec = True
            If existebolelec = True Then
                Dim frm As New frmBoleta_BoletaElectronica_ComunicadoBaja
                frm.IdBoleta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
                frm.DesCli = dgvDatos.CurrentRow.Cells("DesCli").Text
                frm.CodMon = dgvDatos.CurrentRow.Cells("CodMon").Text
                frm.TotNeto = CDec(dgvDatos.CurrentRow.Cells("TotNeto").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdBoleta)
                End If
            Else
                MsgBox("No existe la boleta electronica, verifique.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al generar la factura electronica")
        End Try
    End Sub

    'Private Sub CrearCarpetaResumen()

    '    Dim FechaBoleta As Date = dgvDatos.CurrentRow.Cells("FecDoc").Text
    '    Dim FechaBoletaForm As String = FechaBoleta.ToString("yyyy-MM-dd")

    '    If Not Directory.Exists("D:\Documentos_Electronicos\Resumen_Boletas\" & FechaBoletaForm) Then
    '        Directory.CreateDirectory("D:\Documentos_Electronicos\Resumen_Boletas\" & FechaBoletaForm)
    '    End If

    'End Sub

    'Private Sub ResumenBoletasSerializado()

    '    Try
    '        Dim dtReporte As New DataTable
    '        dtReporte = oBoletaService.ImprimirResumenDigital(CDate(dgvDatos.CurrentRow.Cells("FecDoc").Text)).Tables(0)
    '        GridEx2.DataSource = dtReporte

    '        Dim FecDoc As Date
    '        Dim DesEmp As String
    '        Dim DirEmp As String
    '        Dim Urbanizacion As String
    '        Dim CodUbigeo As String
    '        Dim Departamento As String
    '        Dim Provincia As String
    '        Dim Distrito As String
    '        Dim CodPais As String
    '        Dim RucEmp As String
    '        Dim TipoDoc As String
    '        Dim NumDoc As String
    '        Dim TipoIdentidad As String
    '        Dim RucCli As String
    '        Dim DniCli As String
    '        Dim DesCli As String
    '        Dim unitCode As String
    '        Dim CanMer As String
    '        Dim DesMer1 As String
    '        Dim ValorUnitario As Double
    '        Dim DscMer As Double
    '        Dim PrecioVenta As Double
    '        Dim CodigoPrecio As String
    '        Dim MontoIgv As Double
    '        Dim CodAfectacion As String
    '        Dim CodTributo As String
    '        Dim NomTributo As String
    '        Dim CodTributoInt As String
    '        Dim CodOtroTributo As String
    '        Dim TotVenta As Double
    '        Dim CodMot As String
    '        Dim ValorVenta As Double
    '        Dim TotIgv As Double
    '        Dim TotGasto As Double
    '        Dim CodOtroTributoDesc As String
    '        Dim TotDscto As Double
    '        Dim TotNeto As Double
    '        Dim CodMon As String
    '        Dim DesMon As String
    '        Dim CurrencyId As String
    '        Dim NumGuis As String
    '        Dim CodGuia As String
    '        Dim Item As Integer
    '        Dim CodMer As String
    '        Dim Observacion As String

    '        FecDoc = GridEx2.CurrentRow.Cells("FecDoc").Text
    '        DesEmp = GridEx2.CurrentRow.Cells("DesEmp").Text
    '        DirEmp = GridEx2.CurrentRow.Cells("DirEmp").Text
    '        Urbanizacion = IIf(IsDBNull(GridEx2.CurrentRow.Cells("Urbanizacion").Text), "", GridEx2.CurrentRow.Cells("Urbanizacion").Text)
    '        CodUbigeo = GridEx2.CurrentRow.Cells("CodUbigeo").Text
    '        Departamento = GridEx2.CurrentRow.Cells("Departamento").Text
    '        Provincia = GridEx2.CurrentRow.Cells("Provincia").Text
    '        Distrito = GridEx2.CurrentRow.Cells("Distrito").Text
    '        CodPais = GridEx2.CurrentRow.Cells("CodPais").Text
    '        RucEmp = GridEx2.CurrentRow.Cells("RucEmp").Text
    '        TipoDoc = GridEx2.CurrentRow.Cells("TipoDoc").Text
    '        NumDoc = GridEx2.CurrentRow.Cells("NumDoc").Text
    '        TipoIdentidad = GridEx2.CurrentRow.Cells("TipoIdentidad").Text
    '        RucCli = GridEx2.CurrentRow.Cells("RucCli").Text
    '        DniCli = GridEx2.CurrentRow.Cells("DniCli").Text
    '        DesCli = GridEx2.CurrentRow.Cells("DesCli").Text
    '        CodigoPrecio = GridEx2.CurrentRow.Cells("CodigoPrecio").Text
    '        CodAfectacion = GridEx2.CurrentRow.Cells("CodAfectacion").Text
    '        CodTributo = GridEx2.CurrentRow.Cells("CodTributo").Text
    '        NomTributo = GridEx2.CurrentRow.Cells("NomTributo").Text
    '        CodTributoInt = GridEx2.CurrentRow.Cells("CodTributoInt").Text
    '        CodOtroTributo = GridEx2.CurrentRow.Cells("CodOtroTributo").Text
    '        TotVenta = GridEx2.CurrentRow.Cells("TotVenta").Text
    '        CodMot = GridEx2.CurrentRow.Cells("CodMot").Text
    '        TotIgv = GridEx2.CurrentRow.Cells("TotIgv").Text
    '        CodOtroTributoDesc = GridEx2.CurrentRow.Cells("CodOtroTributoDesc").Text
    '        TotDscto = GridEx2.CurrentRow.Cells("TotDscto").Text
    '        TotNeto = GridEx2.CurrentRow.Cells("TotNeto").Text
    '        CodMon = GridEx2.CurrentRow.Cells("CodMon").Text
    '        'DesMon = GridEx2.CurrentRow.Cells("DesMon").Text
    '        CurrencyId = GridEx2.CurrentRow.Cells("CurrencyId").Text
    '        NumGuis = GridEx2.CurrentRow.Cells("NumGuis").Text
    '        CodGuia = GridEx2.CurrentRow.Cells("CodGuia").Text
    '        Observacion = GridEx2.CurrentRow.Cells("Observacion").Text

    '        Dim FecDocForm As String = FecDoc.ToString("yyyy-MM-dd")
    '        Dim FecDocForm2 As String = FecDoc.ToString("yyyyMMdd")
    '        Dim xmlFilename As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & FecDocForm & "\20100020441-RA-" & FecDocForm2 & "-1" & ".xml"

    '        UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

    '        Dim line1 As SummaryDocumentsLineType() = Nothing

    '        Dim row As Janus.Windows.GridEX.GridEXRow

    '        If GridEX1.RowCount > 0 Then
    '            Dim cantline As Integer = GridEX1.RowCount
    '            line1 = New SummaryDocumentsLineType(cantline) {}

    '            For j = 0 To GridEX1.RowCount - 1
    '                Me.GridEX1.Row = j
    '                row = Me.GridEX1.GetRow()

    '                line1 = New SummaryDocumentsLineType() {New SummaryDocumentsLineType() With { _
    '               .LineID = j + 1, _
    '               .DocumentTypeCode = row.Cells("TipoDoc").Value, _
    '               .DocumentSerialID = row.Cells("NumDoc").Value, _
    '               .StartDocumentNumberID = "456", _
    '               .EndDocumentNumberID = "764", _
    '               .TotalAmount = row.Cells("TotNeto").Value, _
    '               .BillingPayment = New BillingPaymentType() {New BillingPaymentType() With { _
    '                   .PaidAmount = row.Cells("TotVenta").Value, _
    '                   .InstructionID = "01" _
    '               }, New BillingPaymentType() With { _
    '                   .PaidAmount = 0D, _
    '                   .InstructionID = "02" _
    '               }, New BillingPaymentType() With { _
    '                   .PaidAmount = 0D, _
    '                   .InstructionID = "03" _
    '               }}, _
    '               .AllowanceCharge = New AllowanceChargeType() {New AllowanceChargeType() With { _
    '                   .ChargeIndicator = True, _
    '                   .Amount = 5D _
    '               }}, _
    '               .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '                   .TaxAmount = 0D, _
    '                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                       .TaxAmount = 0D, _
    '                       .TaxCategory = New TaxCategoryType() With { _
    '                           .TaxScheme = New TaxSchemeType() With { _
    '                               .ID = CodTributo, _
    '                               .Name = NomTributo, _
    '                               .TaxTypeCode = CodTributoInt _
    '                           } _
    '                       } _
    '                   }} _
    '               }, New TaxTotalType() With { _
    '                   .TaxAmount = 17681.76D, _
    '                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                       .TaxAmount = 17681.76D, _
    '                       .TaxCategory = New TaxCategoryType() With { _
    '                           .TaxScheme = New TaxSchemeType() With { _
    '                               .ID = CodTributo, _
    '                               .Name = NomTributo, _
    '                               .TaxTypeCode = CodTributoInt _
    '                           } _
    '                       } _
    '                   }} _
    '               }, New TaxTotalType() With { _
    '                   .TaxAmount = 1200D, _
    '                   .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                       .TaxAmount = 1200D, _
    '                       .TaxCategory = New TaxCategoryType() With { _
    '                           .TaxScheme = New TaxSchemeType() With { _
    '                               .ID = "9999", _
    '                               .Name = "OTROS", _
    '                               .TaxTypeCode = "OTH" _
    '                           } _
    '                       } _
    '                   }} _
    '               }} _
    '           }
    '            }

    '            Next

    '        End If

    '        FacturacionElectronica.GenerarSummaryDocument(xmlFilename, CurrencyId, FecDocForm2 & "-1", FecDoc, FecDoc, line1)

    '        '===================================================================================================================== Firmar Documento

    '        Dim ObjLib As New FirmarDocumento

    '        Dim direccion As String
    '        Dim firmado As Boolean
    '        direccion = xmlFilename
    '        'direccion = "D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-01-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"

    '        Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\CertificadoFacturacion.pfx"
    '        'firmado = ObjLib.SignXmlFile("20100020441", "D:\Documentos_Electronicos\xadesnettest.p12", "xadesnet", direccion)
    '        'activar -------------------------------------------------------------------------------------------------------------------------------------------------------------
    '        firmado = ObjLib.SignXmlFile("20100020441", 4, ruta, "123456", direccion)

    '        If firmado = True Then
    '            'MsgBox("Se genero el firmado", MsgBoxStyle.Information)

    '            Dim xmlDoc As New XmlDocument
    '            xmlDoc.Load("D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-01-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml")

    '            'ValorResumen = xmlDoc.SelectSingleNode("/ext:UBLExtensions/ext:UBLExtension/ext:UBLExtensionContent/category[@name='a']/SubCategoryName").Value
    '            'ValorResumen = xmlDoc.SelectSingleNode("/DigestValue").InnerText
    '            'ValorFirma = xmlDoc.SelectSingleNode("/SignatureValue").InnerText

    '            'Comentado para pruebas ====================================================================================
    '            'Dim insertar As Boolean
    '            ''Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
    '            'Dim nombrexml As String = "20100020441-01-" & GridEX1.CurrentRow.Cells("NumDoc").Text '& ".xml"
    '            'insertar = oFacturaDigitalService.Insertar(IdFactura, nombrexml, xmlDoc.OuterXml, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

    '            'If insertar = True Then
    '            '    Comprimir()
    '            'End If

    '        End If

    '        '======================================================================================================================= Firmar Documento

    '    Catch ex As Exception
    '        MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try

    'End Sub

    '    Private Sub ResumenBoletasPrueba()

    '        Try
    '            Dim dtReporte As New DataTable
    '            dtReporte = oBoletaService.ImprimirResumenDigital(CDate(dgvDatos.CurrentRow.Cells("FecDoc").Text)).Tables(0)
    '            GridEx2.DataSource = dtReporte

    '            Dim FecDoc As Date
    '            Dim DesEmp As String
    '            Dim DirEmp As String
    '            Dim Urbanizacion As String
    '            Dim CodUbigeo As String
    '            Dim Departamento As String
    '            Dim Provincia As String
    '            Dim Distrito As String
    '            Dim CodPais As String
    '            Dim RucEmp As String
    '            Dim TipoDoc As String
    '            Dim NumDoc As String
    '            Dim TipoIdentidad As String
    '            Dim RucCli As String
    '            Dim DniCli As String
    '            Dim DesCli As String
    '            Dim unitCode As String
    '            Dim CanMer As String
    '            Dim DesMer1 As String
    '            Dim ValorUnitario As Double
    '            Dim DscMer As Double
    '            Dim PrecioVenta As Double
    '            Dim CodigoPrecio As String
    '            Dim MontoIgv As Double
    '            Dim CodAfectacion As String
    '            Dim CodTributo As String
    '            Dim NomTributo As String
    '            Dim CodTributoInt As String
    '            Dim CodOtroTributo As String
    '            Dim TotVenta As Double
    '            Dim CodMot As String
    '            Dim ValorVenta As Double
    '            Dim TotIgv As Double
    '            Dim TotGasto As Double
    '            Dim CodOtroTributoDesc As String
    '            Dim TotDscto As Double
    '            Dim TotNeto As Double
    '            Dim CodMon As String
    '            Dim DesMon As String
    '            Dim CurrencyId As String
    '            Dim NumGuis As String
    '            Dim CodGuia As String
    '            Dim Item As Integer
    '            Dim CodMer As String
    '            Dim Observacion As String

    '            FecDoc = GridEx2.CurrentRow.Cells("FecDoc").Text
    '            DesEmp = GridEx2.CurrentRow.Cells("DesEmp").Text
    '            DirEmp = GridEx2.CurrentRow.Cells("DirEmp").Text
    '            Urbanizacion = IIf(IsDBNull(GridEx2.CurrentRow.Cells("Urbanizacion").Text), "", GridEx2.CurrentRow.Cells("Urbanizacion").Text)
    '            CodUbigeo = GridEx2.CurrentRow.Cells("CodUbigeo").Text
    '            Departamento = GridEx2.CurrentRow.Cells("Departamento").Text
    '            Provincia = GridEx2.CurrentRow.Cells("Provincia").Text
    '            Distrito = GridEx2.CurrentRow.Cells("Distrito").Text
    '            CodPais = GridEx2.CurrentRow.Cells("CodPais").Text
    '            RucEmp = GridEx2.CurrentRow.Cells("RucEmp").Text
    '            TipoDoc = GridEx2.CurrentRow.Cells("TipoDoc").Text
    '            NumDoc = GridEx2.CurrentRow.Cells("NumDoc").Text
    '            TipoIdentidad = GridEx2.CurrentRow.Cells("TipoIdentidad").Text
    '            RucCli = GridEx2.CurrentRow.Cells("RucCli").Text
    '            DniCli = GridEx2.CurrentRow.Cells("DniCli").Text
    '            DesCli = GridEx2.CurrentRow.Cells("DesCli").Text
    '            CodigoPrecio = GridEx2.CurrentRow.Cells("CodigoPrecio").Text
    '            CodAfectacion = GridEx2.CurrentRow.Cells("CodAfectacion").Text
    '            CodTributo = GridEx2.CurrentRow.Cells("CodTributo").Text
    '            NomTributo = GridEx2.CurrentRow.Cells("NomTributo").Text
    '            CodTributoInt = GridEx2.CurrentRow.Cells("CodTributoInt").Text
    '            CodOtroTributo = GridEx2.CurrentRow.Cells("CodOtroTributo").Text
    '            TotVenta = GridEx2.CurrentRow.Cells("TotVenta").Text
    '            CodMot = GridEx2.CurrentRow.Cells("CodMot").Text
    '            TotIgv = GridEx2.CurrentRow.Cells("TotIgv").Text
    '            CodOtroTributoDesc = GridEx2.CurrentRow.Cells("CodOtroTributoDesc").Text
    '            TotDscto = GridEx2.CurrentRow.Cells("TotDscto").Text
    '            TotNeto = GridEx2.CurrentRow.Cells("TotNeto").Text
    '            CodMon = GridEx2.CurrentRow.Cells("CodMon").Text
    '            'DesMon = GridEx2.CurrentRow.Cells("DesMon").Text
    '            CurrencyId = GridEx2.CurrentRow.Cells("CurrencyId").Text
    '            NumGuis = GridEx2.CurrentRow.Cells("NumGuis").Text
    '            CodGuia = GridEx2.CurrentRow.Cells("CodGuia").Text
    '            Observacion = GridEx2.CurrentRow.Cells("Observacion").Text

    '            Dim FecDocForm As String = FecDoc.ToString("yyyy-MM-dd")
    '            Dim FecDocForm2 As String = FecDoc.ToString("yyyyMMdd")
    '            Dim xmlFilename As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & FecDocForm & "\20100020441-RC-" & "20150619" & "-2" & ".xml"
    '            'Dim xmlFilename As String = "D:\Documentos_Electronicos\Resumen_Boletas\" & FecDocForm & "\20100020441-RC-" & FecDocForm2 & "-1" & ".xml"

    '            UblLarsen.Ubl2.UblBaseDocumentType.GlbCustomizationID = "1.0"

    '            AmountType.TlsDefaultCurrencyID = CurrencyId

    '            Dim line1 As SummaryDocumentsLineType() = Nothing

    '            Dim row As Janus.Windows.GridEX.GridEXRow

    '            If GridEx2.RowCount > 0 Then
    '                Dim cantline As Integer = GridEX1.RowCount
    '                line1 = New SummaryDocumentsLineType(5) {}

    '                line1(0) = New SummaryDocumentsLineType() With { _
    '               .LineID = 1, _
    '               .DocumentTypeCode = "03", _
    '                   .DocumentSerialID = "BB14", _
    '                   .StartDocumentNumberID = "6922", _
    '                   .EndDocumentNumberID = "6926", _
    '                   .TotalAmount = CDec(FormatNumber("12118.22", 2)), _
    '                   .BillingPayment = New BillingPaymentType() {New BillingPaymentType() With { _
    '                       .PaidAmount = CDec(FormatNumber("10269.68", 2)), _
    '                       .InstructionID = "01" _
    '                   }, New BillingPaymentType() With { _
    '                       .PaidAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .InstructionID = "02" _
    '                   }, New BillingPaymentType() With { _
    '                       .PaidAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .InstructionID = "03" _
    '                   }}, _
    '                   .AllowanceCharge = New AllowanceChargeType() {New AllowanceChargeType() With { _
    '                       .ChargeIndicator = True, _
    '                       .Amount = CDec(FormatNumber("0.00", 2)) _
    '                   }}, _
    '                   .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber("1848.54", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("1848.54", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = "1000", _
    '                                   .Name = "IGV", _
    '                                   .TaxTypeCode = "VAT" _
    '                               } _
    '                           } _
    '                       }} _
    '                   }, New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = "2000", _
    '                                   .Name = "ISC", _
    '                                   .TaxTypeCode = "EXC" _
    '                               } _
    '                           } _
    '                       }} _
    '                   }, New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = "9999", _
    '                                   .Name = "OTROS", _
    '                                   .TaxTypeCode = "OTH" _
    '                               } _
    '                           } _
    '                       }} _
    '                   }} _
    '               }


    '                line1(1) = New SummaryDocumentsLineType() With { _
    '               .LineID = 2, _
    '               .DocumentTypeCode = "07", _
    '                   .DocumentSerialID = "BB14", _
    '                   .StartDocumentNumberID = "6919", _
    '                   .EndDocumentNumberID = "6921", _
    '                   .TotalAmount = CDec(FormatNumber("936.29", 2)), _
    '                   .BillingPayment = New BillingPaymentType() {New BillingPaymentType() With { _
    '                       .PaidAmount = CDec(FormatNumber("793.47", 2)), _
    '                       .InstructionID = "01" _
    '                   }, New BillingPaymentType() With { _
    '                       .PaidAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .InstructionID = "02" _
    '                   }, New BillingPaymentType() With { _
    '                       .PaidAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .InstructionID = "03" _
    '                   }}, _
    '                   .AllowanceCharge = New AllowanceChargeType() {New AllowanceChargeType() With { _
    '                       .ChargeIndicator = True, _
    '                       .Amount = CDec(FormatNumber("0.00", 2)) _
    '                   }}, _
    '                   .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber("142.82", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("142.82", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = "1000", _
    '                                   .Name = "IGV", _
    '                                   .TaxTypeCode = "VAT" _
    '                               } _
    '                           } _
    '                       }} _
    '                   }, New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = "2000", _
    '                                   .Name = "ISC", _
    '                                   .TaxTypeCode = "EXC" _
    '                               } _
    '                           } _
    '                       }} _
    '                   }, New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = "9999", _
    '                                   .Name = "OTROS", _
    '                                   .TaxTypeCode = "OTH" _
    '                               } _
    '                           } _
    '                       }} _
    '                   }} _
    '               }

    '                line1(2) = New SummaryDocumentsLineType() With { _
    '               .LineID = 3, _
    '               .DocumentTypeCode = "08", _
    '                   .DocumentSerialID = "BB14", _
    '                   .StartDocumentNumberID = "6678", _
    '                   .EndDocumentNumberID = "6680", _
    '                   .TotalAmount = CDec(FormatNumber("478.86", 2)), _
    '                   .BillingPayment = New BillingPaymentType() {New BillingPaymentType() With { _
    '                       .PaidAmount = CDec(FormatNumber("405.81", 2)), _
    '                       .InstructionID = "01" _
    '                   }, New BillingPaymentType() With { _
    '                       .PaidAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .InstructionID = "02" _
    '                   }, New BillingPaymentType() With { _
    '                       .PaidAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .InstructionID = "03" _
    '                   }}, _
    '                   .AllowanceCharge = New AllowanceChargeType() {New AllowanceChargeType() With { _
    '                       .ChargeIndicator = True, _
    '                       .Amount = CDec(FormatNumber("0.00", 2)) _
    '                   }}, _
    '                   .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '                        .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = "2000", _
    '                                   .Name = "ISC", _
    '                                   .TaxTypeCode = "EXC" _
    '                               } _
    '                           } _
    '                       }} _
    '                    }, New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber("73.05", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("73.05", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = "1000", _
    '                                   .Name = "IGV", _
    '                                   .TaxTypeCode = "VAT" _
    '                               } _
    '                           } _
    '                       }} _
    '                   }, New TaxTotalType() With { _
    '                       .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                       .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                           .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                           .TaxCategory = New TaxCategoryType() With { _
    '                               .TaxScheme = New TaxSchemeType() With { _
    '                                   .ID = "9999", _
    '                                   .Name = "OTROS", _
    '                                   .TaxTypeCode = "OTH" _
    '                               } _
    '                           } _
    '                       }} _
    '                   }} _
    '               }

    '                line1(3) = New SummaryDocumentsLineType() With { _
    '                .LineID = 4, _
    '                .DocumentTypeCode = "03", _
    '                    .DocumentSerialID = "BB11", _
    '                    .StartDocumentNumberID = "6901", _
    '                    .EndDocumentNumberID = "6901", _
    '                    .TotalAmount = CDec(FormatNumber("1025.07", 2)), _
    '                    .BillingPayment = New BillingPaymentType() {New BillingPaymentType() With { _
    '                        .PaidAmount = CDec(FormatNumber("868.70", 2)), _
    '                        .InstructionID = "01" _
    '                    }, New BillingPaymentType() With { _
    '                        .PaidAmount = CDec(FormatNumber("0.00", 2)), _
    '                        .InstructionID = "02" _
    '                    }, New BillingPaymentType() With { _
    '                        .PaidAmount = CDec(FormatNumber("0.00", 2)), _
    '                        .InstructionID = "03" _
    '                    }}, _
    '                    .AllowanceCharge = New AllowanceChargeType() {New AllowanceChargeType() With { _
    '                        .ChargeIndicator = True, _
    '                        .Amount = CDec(FormatNumber("0.00", 2)) _
    '                    }}, _
    '                    .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '                         .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                        .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                            .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                            .TaxCategory = New TaxCategoryType() With { _
    '                                .TaxScheme = New TaxSchemeType() With { _
    '                                    .ID = "2000", _
    '                                    .Name = "ISC", _
    '                                    .TaxTypeCode = "EXC" _
    '                                } _
    '                            } _
    '                        }} _
    '                    }, New TaxTotalType() With { _
    '                        .TaxAmount = CDec(FormatNumber("156.37", 2)), _
    '                        .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                            .TaxAmount = CDec(FormatNumber("156.37", 2)), _
    '                            .TaxCategory = New TaxCategoryType() With { _
    '                                .TaxScheme = New TaxSchemeType() With { _
    '                                    .ID = "1000", _
    '                                    .Name = "IGV", _
    '                                    .TaxTypeCode = "VAT" _
    '                                } _
    '                            } _
    '                        }} _
    '                    }, New TaxTotalType() With { _
    '                        .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                        .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '                            .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '                            .TaxCategory = New TaxCategoryType() With { _
    '                                .TaxScheme = New TaxSchemeType() With { _
    '                                    .ID = "9999", _
    '                                    .Name = "OTROS", _
    '                                    .TaxTypeCode = "OTH" _
    '                                } _
    '                            } _
    '                        }} _
    '                    }} _
    '                }

    '                line1(4) = New SummaryDocumentsLineType() With { _
    '.LineID = 5, _
    '.DocumentTypeCode = "03", _
    '    .DocumentSerialID = "BB12", _
    '    .StartDocumentNumberID = "6920", _
    '    .EndDocumentNumberID = "6920", _
    '    .TotalAmount = CDec(FormatNumber("110.22", 2)), _
    '    .BillingPayment = New BillingPaymentType() {New BillingPaymentType() With { _
    '        .PaidAmount = CDec(FormatNumber("0.00", 2)), _
    '        .InstructionID = "01" _
    '    }, New BillingPaymentType() With { _
    '        .PaidAmount = CDec(FormatNumber("0.00", 2)), _
    '        .InstructionID = "02" _
    '    }, New BillingPaymentType() With { _
    '        .PaidAmount = CDec(FormatNumber("110.22", 2)), _
    '        .InstructionID = "03" _
    '    }}, _
    '    .AllowanceCharge = New AllowanceChargeType() {New AllowanceChargeType() With { _
    '        .ChargeIndicator = True, _
    '        .Amount = CDec(FormatNumber("0.00", 2)) _
    '    }}, _
    '    .TaxTotal = New TaxTotalType() {New TaxTotalType() With { _
    '         .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '        .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '            .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '            .TaxCategory = New TaxCategoryType() With { _
    '                .TaxScheme = New TaxSchemeType() With { _
    '                    .ID = "2000", _
    '                    .Name = "ISC", _
    '                    .TaxTypeCode = "EXC" _
    '                } _
    '            } _
    '        }} _
    '    }, New TaxTotalType() With { _
    '        .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '        .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '            .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '            .TaxCategory = New TaxCategoryType() With { _
    '                .TaxScheme = New TaxSchemeType() With { _
    '                    .ID = "1000", _
    '                    .Name = "IGV", _
    '                    .TaxTypeCode = "VAT" _
    '                } _
    '            } _
    '        }} _
    '    }, New TaxTotalType() With { _
    '        .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '        .TaxSubtotal = New TaxSubtotalType() {New TaxSubtotalType() With { _
    '            .TaxAmount = CDec(FormatNumber("0.00", 2)), _
    '            .TaxCategory = New TaxCategoryType() With { _
    '                .TaxScheme = New TaxSchemeType() With { _
    '                    .ID = "9999", _
    '                    .Name = "OTROS", _
    '                    .TaxTypeCode = "OTH" _
    '                } _
    '            } _
    '        }} _
    '    }} _
    '}

    '            End If

    '            'FacturacionElectronica.GenerarSummaryDocument(xmlFilename, CurrencyId, FecDocForm2 & "-1", FecDoc, FecDoc, line1)
    '            FacturacionElectronica.GenerarSummaryDocument(xmlFilename, CurrencyId, "RC-20150619" & "-2", FecDoc, FecDoc, line1)

    '            '===================================================================================================================== Firmar Documento

    '            Dim ObjLib As New FirmarDocumento

    '            Dim direccion As String
    '            Dim firmado As Boolean
    '            direccion = xmlFilename
    '            'direccion = "D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-01-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"

    '            Dim ruta As String = System.AppDomain.CurrentDomain.BaseDirectory & "Certificado\CertificadoFacturacion.pfx"
    '            'firmado = ObjLib.SignXmlFile("20100020441", "D:\Documentos_Electronicos\xadesnettest.p12", "xadesnet", direccion)
    '            'activar -------------------------------------------------------------------------------------------------------------------------------------------------------------
    '            firmado = ObjLib.SignXmlFile("20100020441", 4, ruta, "123456", direccion)

    '            If firmado = True Then
    '                'MsgBox("Se genero el firmado", MsgBoxStyle.Information)

    '                Dim xmlDoc As New XmlDocument
    '                xmlDoc.Load("D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX1.CurrentRow.Cells("NumDoc").Text & "\20100020441-01-" & GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml")

    '                'ValorResumen = xmlDoc.SelectSingleNode("/ext:UBLExtensions/ext:UBLExtension/ext:UBLExtensionContent/category[@name='a']/SubCategoryName").Value
    '                'ValorResumen = xmlDoc.SelectSingleNode("/DigestValue").InnerText
    '                'ValorFirma = xmlDoc.SelectSingleNode("/SignatureValue").InnerText

    '                ''Comentado para pruebas ====================================================================================
    '                'Dim insertar As Boolean
    '                ''Dim nombrexml As String = GridEX1.CurrentRow.Cells("NumDoc").Text & ".xml"     'Comentado para que en el evento de descargar se obtenga el numdoc sin el ".xml"
    '                'Dim nombrexml As String = "20100020441-01-" & GridEX1.CurrentRow.Cells("NumDoc").Text '& ".xml"
    '                'insertar = oFacturaDigitalService.Insertar(IdFactura, nombrexml, xmlDoc.OuterXml, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

    '                'If insertar = True Then
    '                '    Comprimir()
    '                'End If

    '            End If

    '            '======================================================================================================================= Firmar Documento

    '        Catch ex As Exception
    '            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
    '        End Try

    '    End Sub

    Private Sub biDescargarBoletaElectronica_Click(sender As System.Object, e As System.EventArgs) Handles biDescargarBoletaElectronica.Click, miDescargarBoletaElectronica.Click
        Try

            Dim existebolelec As Boolean

            existebolelec = oBoletaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdBoleta").Text)

            If existebolelec = True Then
                Dim dtReporte As New DataTable
                Dim dtImprimirDigital As New DataTable

                dtImprimirDigital = oBoletaService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdBoleta").Text).Tables(0)
                GridEX2.DataSource = dtImprimirDigital

                CodMot = GridEX2.CurrentRow.Cells("CodMot").Text
                LegalMonetaryTotal = GridEX2.CurrentRow.Cells("LegalMonetaryTotal").Text
                CurrencyId = GridEX2.CurrentRow.Cells("CurrencyId").Text
                TipoDoc = GridEX2.CurrentRow.Cells("TipoDoc").Text
                TaxAmount = GridEX2.CurrentRow.Cells("TaxAmount").Text
                CodSerieFac = GridEX2.CurrentRow.Cells("CodSerie").Text
                NumDocFac = GridEX2.CurrentRow.Cells("NumDoc").Text
                DocumentoFac = GridEX2.CurrentRow.Cells("Documento").Text
                FecDoc = GridEX2.CurrentRow.Cells("FecDoc").Text
                RucEmp = GridEX2.CurrentRow.Cells("RucEmp").Text
                RucCli = GridEX2.CurrentRow.Cells("RucCli").Text
                DniCli = GridEX2.CurrentRow.Cells("DniCli").Text
                CodMon = GridEX2.CurrentRow.Cells("CodMon").Text

                CrearCarpeta()
                CrearXML()
                'ObtenerTagFirma()
                CrearPDF()
            Else
                MsgBox("No existe la factura electronica, verifique.", MsgBoxStyle.Information)
            End If
                Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al descargar la boleta electronica")
        End Try
    End Sub

    Private Sub CrearCarpeta()

        If Not Directory.Exists("D:\Documentos_Electronicos\Boletas_Electronicas\" & GridEx2.CurrentRow.Cells("Documento").Text) Then
            Directory.CreateDirectory("D:\Documentos_Electronicos\Boletas_Electronicas\" & GridEx2.CurrentRow.Cells("Documento").Text)
        End If

    End Sub

    Private Sub CrearXML()

        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(New StringReader(oBoletaDigitalService.Descargar(dgvDatos.CurrentRow.Cells("IdBoleta").Text)))

            NombreXMLPDF = oBoletaDigitalService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdBoleta").Text)

            xmlDoc.Save("D:\Documentos_Electronicos\Boletas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".xml")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el xml")
        End Try

    End Sub

    Private Sub CrearPDF()
        Try
            Dim pdfDoc() As Byte
            pdfDoc = oBoletaDigitalService.DescargarPdf(dgvDatos.CurrentRow.Cells("IdBoleta").Text)

            NombreXMLPDF = oBoletaDigitalService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdBoleta").Text)

            System.IO.File.WriteAllBytes("D:\Documentos_Electronicos\Boletas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".pdf", pdfDoc)

            MsgBox("Se descargo la boleta electronica correctamente", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el pdf")
        End Try
    End Sub

    'Private Sub ObtenerTagFirma()

    '    Try
    '        Dim xmlDoc As New XmlDocument
    '        Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDoc.NameTable)

    '        namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")
    '        namespaces.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
    '        namespaces.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema")
    '        namespaces.AddNamespace("sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1")
    '        namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
    '        namespaces.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
    '        namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")
    '        namespaces.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
    '        namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
    '        namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")

    '        xmlDoc.Load("D:\Documentos_Electronicos\Boletas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".xml")

    '        Dim xPathStringInfo = "/ns:Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignedInfo"
    '        Dim xPathStringValue = "/ns:Invoice/ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature[@Id='SignatureSP']/ds:SignatureValue"

    '        Dim oNodeInfo = xmlDoc.SelectSingleNode(xPathStringInfo, namespaces)
    '        ValorResumen = oNodeInfo.InnerText

    '        Dim oNodeValue = xmlDoc.SelectSingleNode(xPathStringValue, namespaces)
    '        ValorFirma = oNodeValue.InnerText

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener el Tag")
    '    End Try


    'End Sub

    'Private Sub CrearPDF()

    '    Try
    '        Dim qr As PDF417Writer = New PDF417Writer

    '        'Dim url As String = "20100022142|01|F106|611|783.00|5133.00|2015-03-20|6|20100020441|oWUMtPr6aTZltzrFFI6whBA8qdg=|QaBVEy1zRK7VXLM5va0by+mInYDN2fhZBsPbOHXQlBytjj0RZVgjLMkSBhKeUe1kTU5Fk7yZI2S/wAKm/V8W7scEEf7kc3X7WCJwk0lrLoiY0l+N0S0AVJjZcm6wmlN0QB4jh+rTiy+STdhDhx37Ye5QmHAJyR0nB2OYrff2FeegsDv+XY7opVC8jjqxfJXlhvjrklLtMt4w4ueJ+i/YNRIj3D3kYnuj4IXp1SIpwQ3GYJs95yALfn9IME6zXfVkRmjXTqYUS5yAFFYqAc6r01WzcZQSKHPUIPQtoNLN0AHaTT0qQ7gKgBozoDDK0gR5RJ7jEaFd85S4o0h7EaysMg==|"
    '        Dim url As String = RucEmp & "|" & TipoDoc & "|" & CodSerieFac & "|" & NumDocFac & "|" & IIf(CodMot <> "2", FormatNumber(TaxAmount, 2), FormatNumber("0.00", 2)) & "|" & IIf(CodMot <> "2", FormatNumber(LegalMonetaryTotal, 2), FormatNumber("0.00", 2)) & "|" & FecDoc.ToString("yyyy-MM-dd") & "|" & "1" & "|" & DniCli & "|" & ValorResumen & "|" & ValorFirma


    '        Dim hints As IDictionary(Of EncodeHintType, Object) = New Dictionary(Of EncodeHintType, Object)
    '        hints.Add(EncodeHintType.CHARACTER_SET, "ISO8859-1")
    '        'hints.Add(EncodeHintType.ERROR_CORRECTION, 5)
    '        hints.Add(EncodeHintType.ERROR_CORRECTION, PDF417ErrorCorrectionLevel.L5)
    '        hints.Add(EncodeHintType.MARGIN, 5)         '5 es a 1mm , 20 es a 4mm
    '        hints.Add(EncodeHintType.PDF417_COMPACTION, Compaction.BYTE)
    '        hints.Add(EncodeHintType.DISABLE_ECI, True)
    '        'hints.Add(EncodeHintType.PURE_BARCODE

    '        'Dim matrix As ZXing.Common.BitMatrix = qr.encode(url, ZXing.BarcodeFormat.PDF_417, 115, 65)
    '        Dim matrix As ZXing.Common.BitMatrix = qr.encode(url, ZXing.BarcodeFormat.PDF_417, 115, 65, hints)
    '        'Dim matrix As ZXing.Common.BitMatrix = qr.encode(url, ZXing.BarcodeFormat.PDF_417, 115, 65, hints)
    '        Dim w As ZXing.BarcodeWriter = New ZXing.BarcodeWriter
    '        w.Format = ZXing.BarcodeFormat.PDF_417

    '        Dim img As Bitmap = w.Write(matrix)
    '        'Dim img2 As Bitmap = ResizeBitmap(img, 240, 80)
    '        'Dim img2 As Bitmap = ResizeBitmap(img, 388, 118)
    '        UbicacionCodBarra = "D:\Documentos_Electronicos\Boletas_Electronicas\" & DocumentoFac & "\" & DocumentoFac & ".png"
    '        'img2.Save(UbicacionCodBarra, System.Drawing.Imaging.ImageFormat.Png)
    '        img.Save(UbicacionCodBarra, System.Drawing.Imaging.ImageFormat.Png)

    '        CrearPDF2()

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
    '    End Try



    'End Sub


    'Private Sub CrearPDF2()

    '    Try
    '        Dim forma As New frmReportes
    '        Dim dtReporte As New DataTable
    '        Dim reporte As New rpImprimirBoletaElectronica
    '        'Dim UbicacionCodBarra As String
    '        'UbicacionCodBarra = "D:\Documentos_Electronicos\Facturas_Electronicas\" & NombreXMLPDF & "\" & NombreXMLPDF & ".png"

    '        dtReporte = oBoletaService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdBoleta").Text).Tables(0)

    '        If dtReporte.Rows.Count = 0 Then
    '            MsgBox("No hay datos a mostrar")
    '        Else
    '            reporte.SetDataSource(dtReporte)
    '            reporte.SetParameterValue("NumeroLetra", "*** " & oMaestroService.ConvierteNumLetra(LegalMonetaryTotal, CodMon))
    '            reporte.SetParameterValue("CodMot", CodMot)
    '            reporte.SetParameterValue("NroCuenta", IIf(CurrencyId = "PEN", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57"))
    '            reporte.SetParameterValue("UbicacionCodBarra", UbicacionCodBarra)
    '            ExportToPDF(reporte, "miReporte.pdf", DocumentoFac, NombreXMLPDF)

    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el pdf")
    '    End Try

    'End Sub

    'Public Shared Function ExportToPDF(rpt As ReportDocument, NombreArchivo As String, DocumentoFac As String, NombreXMLPDF As String) As String
    '    Dim vFileName As String = Nothing
    '    Dim diskOpts As New DiskFileDestinationOptions()

    '    Try
    '        diskOpts.DiskFileName = "D:\Documentos_Electronicos\Boletas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".pdf"

    '        rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
    '        rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat

    '        If File.Exists(vFileName) Then
    '            File.Delete(vFileName)
    '        End If
    '        rpt.ExportOptions.DestinationOptions = diskOpts
    '        rpt.Export()

    '        MsgBox("Se descargo la boleta electronica correctamente", MsgBoxStyle.Information)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    '    Return vFileName
    'End Function

    Private Sub biListarBolElecxCliente_Click(sender As System.Object, e As System.EventArgs) Handles biListarBolElecxCliente.Click, miListarBolElecxCliente.Click

        Try
            Dim dtImprimirDigital As New DataTable

            dtImprimirDigital = oBoletaService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdBoleta").Text).Tables(0)
            GridEx2.DataSource = dtImprimirDigital

            CodSerieFac = GridEx2.CurrentRow.Cells("CodSerie").Text
            NumDocFac = GridEx2.CurrentRow.Cells("NumDoc").Text

            Dim frm As New frmBoleta_BoletaElectronicaxCliente
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
            frm.DesCli = dgvDatos.CurrentRow.Cells("DesCli").Text
            frm.CodSerie = CodSerieFac
            frm.NumDoc = NumDocFac
            frm.IdBoleta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al listar las boletas x cliente")
        End Try

    End Sub

    Private Sub biListarComunicadosBaja_Click(sender As System.Object, e As System.EventArgs) Handles biListarComunicadosBaja.Click, miListarComunicadoBaja.Click
        Try
            Dim frm As New frmFacturacionElectronica_ComunicadoBaja
            frm.TipoDoc = "2"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al listar los comunicados de baja")
        End Try
    End Sub

    Private Sub miObservacionesSunat_Click(sender As System.Object, e As System.EventArgs) Handles miObservacionesSunat.Click
        Try
            Dim frm As New frmBoleta_BoletaElectronica_ObsSunat
            frm.IdBoleta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar las observaciones")
        End Try
    End Sub

    Private Sub miObtenercdrdoc_Click(sender As System.Object, e As System.EventArgs) Handles miObtenercdrdoc.Click
        Try
            Dim frm As New frmFacturacionElectronica_ObtenerEstadoSunat
            frm.TipoDoc = "03"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar las observaciones")
        End Try
    End Sub

    Private Sub miGenerarAsiento_Click(sender As Object, e As EventArgs) Handles miGenerarAsiento.Click
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está Seguro de Generar el Asiento Contable de la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    If oBoletaService.GenerarAsiento(dgvDatos.CurrentRow.Cells("IdBoleta").Text.ToString, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                        MsgBox("Se genero el Asiento Contable con Exito.....!", MsgBoxStyle.Information, "Asiento Generado")

                        actualizar()
                        'Actualizar_Click(sender, e)
                    Else
                        MsgBox("Error en el proceso, comuníquese con TI...!", MsgBoxStyle.Critical, "Generar Asiento")
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Generar el Asiento")
            End Try
        End If
    End Sub

    Private Sub miVerAsientoContable_Click(sender As Object, e As EventArgs) Handles miVerAsientoContable.Click
        If ValidaCodigoSeleccionado() Then
            Try

                If oContabilidad.BuscarAsientoVenta(dgvDatos.CurrentRow.Cells("IdDocumento").Text.ToString, dgvDatos.CurrentRow.Cells("IdBoleta").Text.ToString) Then
                    Dim frm As New frmConsultaDiarioFactura
                    frm.IdContabilidad = oContabilidad.ObtenerIdContabilidadVenta(dgvDatos.CurrentRow.Cells("IdDocumento").Text.ToString, dgvDatos.CurrentRow.Cells("IdBoleta").Text.ToString)
                    frm.ShowDialog()
                Else
                    MsgBox("El Asiento Contable no existe", MsgBoxStyle.Information, "Vacio")
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Generar el Asiento")
            End Try
        End If

    End Sub

    Private Sub biEnviarCorreo_Click(sender As Object, e As EventArgs) Handles biEnviarCorreo.Click, miEnviarBoletaElectronica.Click

        If ValidaCodigoSeleccionado() Then

            Try

                Dim existefactelec As Boolean

                existefactelec = oBoletaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdBoleta").Text)

                If existefactelec = True Then


                    Dim dtImprimirDigital As New DataTable

                    dtImprimirDigital = oBoletaService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdBoleta").Text).Tables(0)
                    GridEX2.DataSource = dtImprimirDigital

                    CodSerieFac = GridEX2.CurrentRow.Cells("CodSerie").Text
                    NumDocFac = GridEX2.CurrentRow.Cells("NumDoc").Text
                    IdClienteBol = GridEX2.CurrentRow.Cells("IdCliente").Text

                    Dim frm As New frmBoleta_BoletaElectronica_EnviarCorreo

                    frm.CodSerie = CodSerieFac
                    frm.NumDoc = NumDocFac
                    frm.IdBoleta = dgvDatos.CurrentRow.Cells("IdBoleta").Text
                    frm.IdCliente = IdClienteBol
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    End If

                Else
                    MsgBox("No existe la boleta electronica, verifique.", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al enviar x correo")
            End Try

        End If

    End Sub

End Class