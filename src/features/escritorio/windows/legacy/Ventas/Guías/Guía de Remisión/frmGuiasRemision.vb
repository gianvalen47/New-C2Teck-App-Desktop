Imports CrystalDecisions.CrystalReports
Imports System.IO
Imports System.Xml
Imports FacturarSunat21.aplicacion
Imports System.Security.Cryptography

Public Class frmGuiasRemision
    Private oMaestroService As New MaestroService.MaestroClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oGuiaRemisionDetService As New GuiaRemisionDetService.GuiaRemisionDetServiceClient
    Private oGuiaRemisionDigitalService As New GuiaRemisionDigitalService.GuiaRemisionDigitalServiceClient
    Private oTransportistaService As New TransportistaService.TransportistaServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    Dim lAprobacion As Boolean

    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    Private IdClienteGuia As Integer
    Private IdSerieDoc As Integer
    Public CondPago As String

    Dim NombreXMLPDF As String = ""
    Dim DocumentoFac As String
    Dim CodSerieFac As String
    Dim NumDocFac As String

    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClientes As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress, cmbOficinas.KeyPress, cmbIdLocacion.KeyPress, cmbEstado.KeyPress,
                         txtanio.KeyPress, cmbMes.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                mostrar()
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
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

    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress, cmbOficinas.KeyPress, cmbIdLocacion.KeyPress, cmbEstado.KeyPress,
                         txtanio.KeyPress, txtIdCliente.KeyPress, cmbMes.KeyPress, btnBuscar.KeyPress ', dgvDatos.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    'Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal tabla As DataTable, ByVal nombreCampo As String, ByVal codigo As String)
    '    Try
    '        tabla.DefaultView.Sort = nombreCampo
    '        lista.FirstRow = dtDatos.DefaultView.Find(codigo)
    '        lista.Row = dtDatos.DefaultView.Find(codigo)
    '    Catch ex As Exception
    '        MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub
    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows

            For Each row In rows

                If CInt(row.Cells("IdGuia").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub frmGuiasRemision_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 16)
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
        cmbEstado.Value = ""
        state_Search = True
        oGuiaRemisionService.BorrarGuiasGeneradas()
        listaDatos()

        dgvDatos.Select()

    End Sub

    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oGuiaRemisionService) = False Then
                oGuiaRemisionService.Close()
            End If
            If isClosed(oGuiaRemisionDetService) Then
                oGuiaRemisionDetService.Close()
            End If
            If isClosed(oSeguridadService) Then
                oSeguridadService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub limpiaOpcionesBusqueda(ByVal type_process As String, ByVal numero As String)
        If type_process = "update" Or type_process = "insert" Then
            cmbEstado.Value = ""
            txtNumDoc.Text = numero
        End If
    End Sub
    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            biImprimir.Enabled = False
            biTicket.Enabled = False
            biEnviar.Enabled = False
            biGenerar.Enabled = False
            biTrasladar.Enabled = False
            biB2Mining.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biAnular.Enabled = False
            biSugerir.Enabled = False
            biEstado.Enabled = False

            miImprimir.Enabled = False
            miTicket.Enabled = False
            miEnviar.Enabled = False
            miGenerar.Enabled = False
            miTrasladar.Enabled = False
            miB2Mining.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miAnular.Enabled = False
            miSugerir.Enabled = False
            miEstado.Enabled = False
        Else

            Dim lEstado, lMotivo As String
            Dim lTotal As Decimal
            Dim lAproImp As Boolean
            Dim lTotalSug As Decimal

            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            lMotivo = dgvDatos.CurrentRow.Cells("CodMot").Text
            lTotal = dgvDatos.CurrentRow.Cells("TotNeto").Value
            lTotalSug = dgvDatos.CurrentRow.Cells("TotNetoSug").Value
            lAproImp = dgvDatos.CurrentRow.Cells("AprobarImp").Value

            'biImprimir.Enabled = IIf((lEstado = "AP" Or lEstado = "IM" Or lEstado = "FC"), True, IIf(lEstado = "GN" And lMotivo <> "1", True, IIf(lEstado = "GN" And lMotivo = "1" And lAprobacion = False, True, False)))
            biImprimir.Enabled = IIf((lEstado = "AP" Or lEstado = "IM" Or lEstado = "FC"), True, IIf(lAprobacion = False, True, IIf(lEstado = "GN" And lAproImp = False, True, False)))
            biTicket.Enabled = IIf(lEstado = "AN", False, True)
            biEnviar.Enabled = IIf((lEstado = "GN" Or lEstado = "AP") And (lTotal > 0 Or lTotalSug > 0), True, False)
            biGenerar.Enabled = IIf(lEstado = "IM" And (Val(lMotivo) <= 5 Or Val(lMotivo) = 10), True, False)
            biTrasladar.Enabled = IIf(lEstado = "IM" And (lMotivo = "6" Or lMotivo = "7" Or lMotivo = "T"), True, False)
            biB2Mining.Enabled = False
            biMostrar.Enabled = IIf(lEstado = "AN", False, True)
            biEliminar.Enabled = IIf(lEstado = "GN" Or lEstado = "AP" Or lEstado = "IN", True, False)
            biAnular.Enabled = IIf(lEstado = "IM", True, False)
            biSugerir.Enabled = IIf(lEstado = "GN" And lTotal > 0 And dgvDatos.CurrentRow.Cells("Aprobar").Text = True, True, False)
            biEstado.Enabled = True
            biBajarNivel.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05"), True, False)   '------ Se agrega el Perfil de Costos 02/08/2016
            biBajarNivel.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05") And (lEstado = "IM"), True, False)   '------ Se agrega el Perfil de Costos 02/08/2016

            'miImprimir.Enabled = IIf((lEstado = "AP" Or lEstado = "IM" Or lEstado = "FC"), True, IIf(lEstado = "GN" And lMotivo <> "1", True, IIf(lEstado = "GN" And lMotivo = "1" And lAprobacion = False, True, False)))
            miImprimir.Enabled = IIf((lEstado = "AP" Or lEstado = "IM" Or lEstado = "FC"), True, IIf(lAprobacion = False, True, IIf(lEstado = "GN" And lAproImp = False, True, False)))
            miTicket.Enabled = IIf(lEstado = "AN", False, True)
            miEnviar.Enabled = IIf((lEstado = "GN" Or lEstado = "AP") And (lTotal > 0 Or lTotalSug > 0), True, False)
            miGenerar.Enabled = IIf(lEstado = "IM" And (Val(lMotivo) <= 5 Or Val(lMotivo) = 10), True, False)
            miTrasladar.Enabled = IIf(lEstado = "IM" And (lMotivo = "6" Or lMotivo = "7" Or lMotivo = "T"), True, False)
            miB2Mining.Enabled = False
            miMostrar.Enabled = IIf(lEstado = "AN", False, True)
            miEliminar.Enabled = IIf(lEstado = "GN" Or lEstado = "AP" Or lEstado = "IN", True, False)
            miAnular.Enabled = IIf(lEstado = "IM", True, False)
            miSugerir.Enabled = IIf(lEstado = "GN" And lTotal > 0 And dgvDatos.CurrentRow.Cells("Aprobar").Text = True, True, False)
            miEstado.Enabled = True
            miBajarNivel.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05"), True, False)   '------ Se agrega el Perfil de Costos 02/08/2016
            miBajarNivel.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05") And (lEstado = "IM"), True, False)   '------ Se agrega el Perfil de Costos 02/08/2016


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
            fila(2) = "(Todos)"
        End Try

        Return fila
    End Function

    Private Sub Imprimir_Mina()
        Try
            Dim forma As New frmReportes
            Dim reporteMina As New rpImprimirGuiaMina
            Dim dtReporte As New DataTable
            Dim dtDetalles As New DataTable
            Dim IdGuia As Integer = dgvDatos.CurrentRow.Cells("IdGuia").Text
            Dim CodMot As String = dgvDatos.CurrentRow.Cells("CodMot").Text
            dtReporte = oGuiaRemisionService.Imprimir(IdGuia).Tables(0)
            dtDetalles = oGuiaRemisionDetService.Mostrar(toNumber(IdGuia)).Tables(0)

            Dim frm As New frmGuiaRemision_ImprimirPrecio

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                Dim Impresora As String = SeleccionarImpresora()
                If Impresora <> "" Then

                    reporteMina.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporteMina

                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    'forma.crvReportes.RefreshReport = False
                    'forma.crvReportes.DisplayGroupTree = False

                    forma.Text = "Imprimir Guia de Remision"

                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    'dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")
                    reporteMina.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                    reporteMina.SetParameterValue("MostrarPrecio", frm.ImprimirPrecio)

                    'Debido al nuevo formato de Guia de Remision con 6 motivos
                    'Se hace cambio en las guias de remision. Solicitud de Usuario 3757 -14
                    Select Case CodMot
                        Case "1" And "5"   ' Venta y Adelantos
                            reporteMina.SetParameterValue("Motivo1", "X")
                            reporteMina.SetParameterValue("Motivo2", "")
                            reporteMina.SetParameterValue("Motivo3", "")
                            reporteMina.SetParameterValue("Motivo4", "")
                            reporteMina.SetParameterValue("Motivo5", "")
                            reporteMina.SetParameterValue("Motivo6", "")
                            reporteMina.SetParameterValue("MotivoT1", "")
                            reporteMina.SetParameterValue("MotivoT2", "")
                            reporteMina.SetParameterValue("OtroMotivo", "")
                        Case "C"        ' Venta Sujeta a confirmacion del comprador
                            reporteMina.SetParameterValue("Motivo1", "")
                            reporteMina.SetParameterValue("Motivo2", "X")
                            reporteMina.SetParameterValue("Motivo3", "")
                            reporteMina.SetParameterValue("Motivo4", "")
                            reporteMina.SetParameterValue("Motivo5", "")
                            reporteMina.SetParameterValue("Motivo6", "")
                            reporteMina.SetParameterValue("MotivoT1", "")
                            reporteMina.SetParameterValue("MotivoT2", "")
                            reporteMina.SetParameterValue("OtroMotivo", "")
                        Case "7"        ' Consignacion
                            reporteMina.SetParameterValue("Motivo1", "")
                            reporteMina.SetParameterValue("Motivo2", "")
                            reporteMina.SetParameterValue("Motivo3", "X")
                            reporteMina.SetParameterValue("Motivo4", "")
                            reporteMina.SetParameterValue("Motivo5", "")
                            reporteMina.SetParameterValue("Motivo6", "")
                            reporteMina.SetParameterValue("MotivoT1", "")
                            reporteMina.SetParameterValue("MotivoT2", "")
                            reporteMina.SetParameterValue("OtroMotivo", "")
                        Case "3"        ' Exportacion
                            reporteMina.SetParameterValue("Motivo1", "")
                            reporteMina.SetParameterValue("Motivo2", "")
                            reporteMina.SetParameterValue("Motivo3", "")
                            reporteMina.SetParameterValue("Motivo4", "X")
                            reporteMina.SetParameterValue("Motivo5", "")
                            reporteMina.SetParameterValue("Motivo6", "")
                            reporteMina.SetParameterValue("MotivoT1", "")
                            reporteMina.SetParameterValue("MotivoT2", "")
                            reporteMina.SetParameterValue("OtroMotivo", "")
                        Case "6"        ' Traslado entre establecimientos de la misma empresa
                            reporteMina.SetParameterValue("Motivo1", "")
                            reporteMina.SetParameterValue("Motivo2", "")
                            reporteMina.SetParameterValue("Motivo3", "")
                            reporteMina.SetParameterValue("Motivo4", "")
                            reporteMina.SetParameterValue("Motivo5", "X")
                            reporteMina.SetParameterValue("Motivo6", "")
                            reporteMina.SetParameterValue("MotivoT1", "")
                            reporteMina.SetParameterValue("MotivoT2", "")
                            reporteMina.SetParameterValue("OtroMotivo", "")
                        Case "9"        'otros
                            reporteMina.SetParameterValue("Motivo1", "")
                            reporteMina.SetParameterValue("Motivo2", "")
                            reporteMina.SetParameterValue("Motivo3", "")
                            reporteMina.SetParameterValue("Motivo4", "")
                            reporteMina.SetParameterValue("Motivo5", "")
                            reporteMina.SetParameterValue("Motivo6", "X")
                            reporteMina.SetParameterValue("MotivoT1", "")
                            reporteMina.SetParameterValue("MotivoT2", "")
                            reporteMina.SetParameterValue("OtroMotivo", "")
                        Case "T"
                            reporteMina.SetParameterValue("Motivo1", "")
                            reporteMina.SetParameterValue("Motivo2", "")
                            reporteMina.SetParameterValue("Motivo3", "")
                            reporteMina.SetParameterValue("Motivo4", "")
                            reporteMina.SetParameterValue("Motivo5", "")
                            reporteMina.SetParameterValue("Motivo6", "")
                            reporteMina.SetParameterValue("MotivoT1", "Condolidado de ")
                            reporteMina.SetParameterValue("MotivoT2", "Mercaderia en el Almacen de Transporte")
                            reporteMina.SetParameterValue("OtroMotivo", "")
                        Case Else
                            reporteMina.SetParameterValue("Motivo1", "")
                            reporteMina.SetParameterValue("Motivo2", "")
                            reporteMina.SetParameterValue("Motivo3", "")
                            reporteMina.SetParameterValue("Motivo4", "")
                            reporteMina.SetParameterValue("Motivo5", "")
                            reporteMina.SetParameterValue("Motivo6", "X")
                            reporteMina.SetParameterValue("MotivoT1", "")
                            reporteMina.SetParameterValue("MotivoT2", "")
                            reporteMina.SetParameterValue("OtroMotivo", dgvDatos.CurrentRow.Cells("DesMot").Text)

                    End Select

                    '/////////////////////////////////////////////////////////////////////////////////////////
                    Dim i As Integer
                    For i = 0 To 1
                        If i = 1 Then

                            reporteMina.SetParameterValue("Transferencia", "")
                            reporteMina.PrintOptions.PrinterName = Impresora
                            reporteMina.PrintToPrinter(1, False, 0, 0)
                            GoTo 2
                        ElseIf i = 0 Then

                            If dgvDatos.CurrentRow.Cells("CodMot").Text = "6" Or dgvDatos.CurrentRow.Cells("CodMot").Text = "T" Then
                                reporteMina.SetParameterValue("Transferencia", "T")
                                reporteMina.PrintOptions.PrinterName = Impresora
                                reporteMina.PrintToPrinter(1, False, 0, 0)
                            Else
                                reporteMina.SetParameterValue("Transferencia", "")
                                reporteMina.PrintOptions.PrinterName = Impresora
                                reporteMina.PrintToPrinter(1, False, 0, 0)
                            End If

                        End If
                    Next
                    'reporte.PrintOptions.PrinterName = Impresora
                    'reporte.PrintToPrinter(2, False, 0, 0)
2:                  oGuiaRemisionService.ActualizarEstadoImpreso(IdGuia, Session.sCodUsu)
                    actualizar()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL IMPRIMIR MINA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Sub imprimir()
        If ValidaCodigoSeleccionado() Then
            Try
                'If MsgBox("¿Está Seguro de IMPRIMIR la Guía Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                Dim forma As New frmReportes
                Dim reporte As New rpImprimirGuia
                Dim reporteServicios As New rpImprimirGuiaServicios
                Dim reporteResumen As New rpImprimirGuiaResumen
                'Dim reporteMina As New rpImprimirGuiaMina
                Dim dtReporte As New DataTable
                Dim dtDetalles As New DataTable
                Dim IdGuia As Integer = dgvDatos.CurrentRow.Cells("IdGuia").Text
                Dim CodMot As String = dgvDatos.CurrentRow.Cells("CodMot").Text
                dtReporte = oGuiaRemisionService.Imprimir(IdGuia).Tables(0)
                dtDetalles = oGuiaRemisionDetService.Mostrar(toNumber(IdGuia)).Tables(0)
                '//////////////////////////////////////////////////////////////////////////
                Dim Detalles As Integer
                Dim A() As String
                Dim registro As GuiaRemisionService.GuiaRemision
                registro = oGuiaRemisionService.MostrarPorId(IdGuia)
                txtObservacion.Text = toBlank(registro.Observacion)
                A = Split(txtObservacion.Text, vbCrLf, -1, vbTextCompare)
                Detalles = dtDetalles.Rows.Count
                If (UBound(A) + 1) + Detalles > 27 Then
                    MsgBox("No puede imprimir por exceso de líneas,Verificar")
                Else

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                    Else

                        '////////////////////////////////////////////////////// TOQUEPALA Y CUAJONE /////////////////////////////////////////////////////////////
                        If cmbOficinas.Value = "03" Or cmbOficinas.Value = "04" Then

                            'If toBlank(cmbIdLocacion.Value) = "24" Then '--------------------- EQUIPOS -------------------- ' Se comenta a pedido de Angélica 31/01/2018
                            Dim frm As New frmGuiaRemision_Imprimir

                            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                                If frm.Imprimir = True Then
                                    Imprimir_Mina()
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


                                        forma.Text = "Imprimir Guia de Remisión"

                                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                        'dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")
                                        reporteResumen.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))


                                        'Debido al nuevo formato de Guia de Remision con 6 motivos
                                        'Se hace cambio en las guias de remision. Solicitud de Usuario 3757 -14
                                        Select Case CodMot
                                            Case "1" And "5"   ' Venta y Adelantos
                                                reporteResumen.SetParameterValue("Motivo1", "X")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "C"        ' Venta Sujeta a confirmacion del comprador
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "X")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "7"        ' Consignacion
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "X")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "3"        ' Exportacion
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "X")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "6"        ' Traslado entre establecimientos de la misma empresa
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "X")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "9"        'otros
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "X")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "T"
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "Condolidado de ")
                                                reporteResumen.SetParameterValue("MotivoT2", "Mercaderia en el Almacen de Transporte")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case Else
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "X")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", dgvDatos.CurrentRow.Cells("DesMot").Text)

                                        End Select

                                        '/////////////////////////////////////////////////////////////////////////////////////////
                                        Dim i As Integer
                                        For i = 0 To 1
                                            If i = 1 Then

                                                reporteResumen.SetParameterValue("Transferencia", "")
                                                reporteResumen.PrintOptions.PrinterName = Impresora
                                                reporteResumen.PrintToPrinter(1, False, 0, 0)
                                                GoTo 2
                                            ElseIf i = 0 Then

                                                If dgvDatos.CurrentRow.Cells("CodMot").Text = "6" Or dgvDatos.CurrentRow.Cells("CodMot").Text = "T" Then
                                                    reporteResumen.SetParameterValue("Transferencia", "T")
                                                    reporteResumen.PrintOptions.PrinterName = Impresora
                                                    reporteResumen.PrintToPrinter(1, False, 0, 0)
                                                Else
                                                    reporteResumen.SetParameterValue("Transferencia", "")
                                                    reporteResumen.PrintOptions.PrinterName = Impresora
                                                    reporteResumen.PrintToPrinter(1, False, 0, 0)
                                                End If

                                            End If
                                        Next

                                        'reporte.PrintOptions.PrinterName = Impresora
                                        'reporte.PrintToPrinter(2, False, 0, 0)
2:                                      oGuiaRemisionService.ActualizarEstadoImpreso(IdGuia, Session.sCodUsu)
                                        actualizar()
                                    End If
                                End If
                            End If

                            '------------ Se comenta a pedido de Angélica 31/01/2018 ---------
                            'Else

                            '    Imprimir_Mina()

                            'End If
                            '----------------------------------------------------------------------------------------

                            '////////////////////////////////////////////////<> TOQUEPALA Y CUAJONE ////////////////////////////////////////////////////////
                        ElseIf cmbIdLocacion.Value = "003" Then  '----------------- SERVICIOS -----------------
                            ' Reporte creado para modificar el nuevo formato de impresion 2014
                            ' Se agrego un motivo mas 

                            Dim frm As New frmGuiaRemision_ImprimirPrecio

                            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                                Dim Impresora As String = SeleccionarImpresora()
                                If Impresora <> "" Then

                                    reporteServicios.SetDataSource(dtReporte)
                                    forma.crvReportes.ReportSource = reporteServicios

                                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                        forma.crvReportes.ShowExportButton = True
                                    Else
                                        forma.crvReportes.ShowExportButton = False
                                    End If
                                    'forma.crvReportes.RefreshReport = False
                                    'forma.crvReportes.DisplayGroupTree = False


                                    forma.Text = "Imprimir Guia de Remisión"

                                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                    'dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")
                                    reporteServicios.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                                    reporteServicios.SetParameterValue("MostrarPrecio", frm.ImprimirPrecio)

                                    'Debido al nuevo formato de Guia de Remision con 6 motivos
                                    'Se hace cambio en las guias de remision. Solicitud de Usuario 3757 -14
                                    Select Case CodMot
                                        Case "1" And "5" ' Venta y Adelantos
                                            reporteServicios.SetParameterValue("Motivo1", "X")
                                            reporteServicios.SetParameterValue("Motivo2", "")
                                            reporteServicios.SetParameterValue("Motivo3", "")
                                            reporteServicios.SetParameterValue("Motivo4", "")
                                            reporteServicios.SetParameterValue("Motivo5", "")
                                            reporteServicios.SetParameterValue("Motivo6", "")
                                            reporteServicios.SetParameterValue("MotivoT1", "")
                                            reporteServicios.SetParameterValue("MotivoT2", "")
                                            reporteServicios.SetParameterValue("OtroMotivo", "")
                                        Case "C"        ' Venta Sujeta a confirmacion del comprador
                                            reporteServicios.SetParameterValue("Motivo1", "")
                                            reporteServicios.SetParameterValue("Motivo2", "X")
                                            reporteServicios.SetParameterValue("Motivo3", "")
                                            reporteServicios.SetParameterValue("Motivo4", "")
                                            reporteServicios.SetParameterValue("Motivo5", "")
                                            reporteServicios.SetParameterValue("Motivo6", "")
                                            reporteServicios.SetParameterValue("MotivoT1", "")
                                            reporteServicios.SetParameterValue("MotivoT2", "")
                                            reporteServicios.SetParameterValue("OtroMotivo", "")
                                        Case "7"        ' Consignacion
                                            reporteServicios.SetParameterValue("Motivo1", "")
                                            reporteServicios.SetParameterValue("Motivo2", "")
                                            reporteServicios.SetParameterValue("Motivo3", "X")
                                            reporteServicios.SetParameterValue("Motivo4", "")
                                            reporteServicios.SetParameterValue("Motivo5", "")
                                            reporteServicios.SetParameterValue("Motivo6", "")
                                            reporteServicios.SetParameterValue("MotivoT1", "")
                                            reporteServicios.SetParameterValue("MotivoT2", "")
                                            reporteServicios.SetParameterValue("OtroMotivo", "")
                                        Case "3"        ' Exportacion
                                            reporteServicios.SetParameterValue("Motivo1", "")
                                            reporteServicios.SetParameterValue("Motivo2", "")
                                            reporteServicios.SetParameterValue("Motivo3", "")
                                            reporteServicios.SetParameterValue("Motivo4", "X")
                                            reporteServicios.SetParameterValue("Motivo5", "")
                                            reporteServicios.SetParameterValue("Motivo6", "")
                                            reporteServicios.SetParameterValue("MotivoT1", "")
                                            reporteServicios.SetParameterValue("MotivoT2", "")
                                            reporteServicios.SetParameterValue("OtroMotivo", "")
                                        Case "6"        ' Traslado entre establecimientos de la misma empresa
                                            reporteServicios.SetParameterValue("Motivo1", "")
                                            reporteServicios.SetParameterValue("Motivo2", "")
                                            reporteServicios.SetParameterValue("Motivo3", "")
                                            reporteServicios.SetParameterValue("Motivo4", "")
                                            reporteServicios.SetParameterValue("Motivo5", "X")
                                            reporteServicios.SetParameterValue("Motivo6", "")
                                            reporteServicios.SetParameterValue("MotivoT1", "")
                                            reporteServicios.SetParameterValue("MotivoT2", "")
                                            reporteServicios.SetParameterValue("OtroMotivo", "")
                                        Case "9"        ' Otros
                                            reporteServicios.SetParameterValue("Motivo1", "")
                                            reporteServicios.SetParameterValue("Motivo2", "")
                                            reporteServicios.SetParameterValue("Motivo3", "")
                                            reporteServicios.SetParameterValue("Motivo4", "")
                                            reporteServicios.SetParameterValue("Motivo5", "")
                                            reporteServicios.SetParameterValue("Motivo6", "X")
                                            reporteServicios.SetParameterValue("MotivoT1", "")
                                            reporteServicios.SetParameterValue("MotivoT2", "")
                                            reporteServicios.SetParameterValue("OtroMotivo", "")
                                        Case "T"
                                            reporteServicios.SetParameterValue("Motivo1", "")
                                            reporteServicios.SetParameterValue("Motivo2", "")
                                            reporteServicios.SetParameterValue("Motivo3", "")
                                            reporteServicios.SetParameterValue("Motivo4", "")
                                            reporteServicios.SetParameterValue("Motivo5", "")
                                            reporteServicios.SetParameterValue("Motivo6", "")
                                            reporteServicios.SetParameterValue("MotivoT1", "Condolidado de ")
                                            reporteServicios.SetParameterValue("MotivoT2", "Mercaderia en el Almacen de Transporte")
                                            reporteServicios.SetParameterValue("OtroMotivo", "")
                                        Case Else
                                            reporteServicios.SetParameterValue("Motivo1", "")
                                            reporteServicios.SetParameterValue("Motivo2", "")
                                            reporteServicios.SetParameterValue("Motivo3", "")
                                            reporteServicios.SetParameterValue("Motivo4", "")
                                            reporteServicios.SetParameterValue("Motivo5", "")
                                            reporteServicios.SetParameterValue("Motivo6", "X")
                                            reporteServicios.SetParameterValue("MotivoT1", "")
                                            reporteServicios.SetParameterValue("MotivoT2", "")
                                            reporteServicios.SetParameterValue("OtroMotivo", dgvDatos.CurrentRow.Cells("DesMot").Text)

                                    End Select

                                    '/////////////////////////////////////////////////////////////////////////////////////////
                                    Dim i As Integer
                                    For i = 0 To 1
                                        If i = 1 Then

                                            reporteServicios.SetParameterValue("Transferencia", "")
                                            reporteServicios.PrintOptions.PrinterName = Impresora
                                            reporteServicios.PrintToPrinter(1, False, 0, 0)
                                            GoTo 3
                                        ElseIf i = 0 Then

                                            If dgvDatos.CurrentRow.Cells("CodMot").Text = "6" Or dgvDatos.CurrentRow.Cells("CodMot").Text = "T" Then
                                                reporteServicios.SetParameterValue("Transferencia", "T")
                                                reporteServicios.PrintOptions.PrinterName = Impresora
                                                reporteServicios.PrintToPrinter(1, False, 0, 0)
                                            Else
                                                reporteServicios.SetParameterValue("Transferencia", "")
                                                reporteServicios.PrintOptions.PrinterName = Impresora
                                                reporteServicios.PrintToPrinter(1, False, 0, 0)
                                            End If

                                        End If
                                    Next

                                    'reporte.PrintOptions.PrinterName = Impresora
                                    'reporte.PrintToPrinter(2, False, 0, 0)
3:                                  oGuiaRemisionService.ActualizarEstadoImpreso(IdGuia, Session.sCodUsu)
                                    actualizar()
                                End If
                            End If
                        ElseIf cmbIdLocacion.Value = "004" Then  '--------------------- EQUIPOS --------------------

                            Dim frm As New frmGuiaRemision_Imprimir

                            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                                If frm.Imprimir = True Then
                                    Imprimir_Detalle()
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

                                        forma.Text = "Imprimir Guia de Remisión"

                                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                        'dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")
                                        reporteResumen.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))


                                        'Debido al nuevo formato de Guia de Remision con 6 motivos
                                        'Se hace cambio en las guias de remision. Solicitud de Usuario 3757 -14
                                        Select Case CodMot
                                            Case "1" And "5"   ' Venta y Adelantos
                                                reporteResumen.SetParameterValue("Motivo1", "X")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "C"        ' Venta Sujeta a confirmacion del comprador
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "X")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "7"        ' Consignacion
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "X")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "3"        ' Exportacion
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "X")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "6"        ' Traslado entre establecimientos de la misma empresa
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "X")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "9"        'otros
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "X")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case "T"
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "")
                                                reporteResumen.SetParameterValue("MotivoT1", "Condolidado de ")
                                                reporteResumen.SetParameterValue("MotivoT2", "Mercaderia en el Almacen de Transporte")
                                                reporteResumen.SetParameterValue("OtroMotivo", "")
                                            Case Else
                                                reporteResumen.SetParameterValue("Motivo1", "")
                                                reporteResumen.SetParameterValue("Motivo2", "")
                                                reporteResumen.SetParameterValue("Motivo3", "")
                                                reporteResumen.SetParameterValue("Motivo4", "")
                                                reporteResumen.SetParameterValue("Motivo5", "")
                                                reporteResumen.SetParameterValue("Motivo6", "X")
                                                reporteResumen.SetParameterValue("MotivoT1", "")
                                                reporteResumen.SetParameterValue("MotivoT2", "")
                                                reporteResumen.SetParameterValue("OtroMotivo", dgvDatos.CurrentRow.Cells("DesMot").Text)

                                        End Select

                                        '/////////////////////////////////////////////////////////////////////////////////////////
                                        Dim i As Integer
                                        For i = 0 To 1
                                            If i = 1 Then

                                                reporteResumen.SetParameterValue("Transferencia", "")
                                                reporteResumen.PrintOptions.PrinterName = Impresora
                                                reporteResumen.PrintToPrinter(1, False, 0, 0)
                                                GoTo 4
                                            ElseIf i = 0 Then

                                                If dgvDatos.CurrentRow.Cells("CodMot").Text = "6" Or dgvDatos.CurrentRow.Cells("CodMot").Text = "T" Then
                                                    reporteResumen.SetParameterValue("Transferencia", "T")
                                                    reporteResumen.PrintOptions.PrinterName = Impresora
                                                    reporteResumen.PrintToPrinter(1, False, 0, 0)
                                                Else
                                                    reporteResumen.SetParameterValue("Transferencia", "")
                                                    reporteResumen.PrintOptions.PrinterName = Impresora
                                                    reporteResumen.PrintToPrinter(1, False, 0, 0)
                                                End If

                                            End If
                                        Next

                                        'reporte.PrintOptions.PrinterName = Impresora
                                        'reporte.PrintToPrinter(2, False, 0, 0)
4:                                      oGuiaRemisionService.ActualizarEstadoImpreso(IdGuia, Session.sCodUsu)
                                        actualizar()
                                    End If
                                End If
                            End If

                        Else

                            Dim frm As New frmGuiaRemision_ImprimirPrecio

                            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                                Dim Impresora As String = SeleccionarImpresora()
                                If Impresora <> "" Then

                                    'cambio pedido Sol 4030 Angelica Vega

                                    reporte.SetDataSource(dtReporte)
                                    forma.crvReportes.ReportSource = reporte

                                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                        forma.crvReportes.ShowExportButton = True
                                    Else
                                        forma.crvReportes.ShowExportButton = False
                                    End If
                                    'forma.crvReportes.RefreshReport = False
                                    'forma.crvReportes.DisplayGroupTree = False

                                    forma.Text = "Imprimir Guia de Remisión"

                                    'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                    'dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")
                                    reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                                    reporte.SetParameterValue("MostrarPrecio", frm.ImprimirPrecio)

                                    'Debido al nuevo formato de Guia de Remision con 6 motivos
                                    'Se hace cambio en las guias de remision. Solicitud de Usuario 3757 -14
                                    Select Case CodMot
                                        Case "1" And "5"   ' Venta y Adelantos
                                            reporte.SetParameterValue("Motivo1", "X")
                                            reporte.SetParameterValue("Motivo2", "")
                                            reporte.SetParameterValue("Motivo3", "")
                                            reporte.SetParameterValue("Motivo4", "")
                                            reporte.SetParameterValue("Motivo5", "")
                                            reporte.SetParameterValue("Motivo6", "")
                                            reporte.SetParameterValue("MotivoT1", "")
                                            reporte.SetParameterValue("MotivoT2", "")
                                            reporte.SetParameterValue("OtroMotivo", "")
                                        Case "C"        ' Venta Sujeta a confirmacion del comprador
                                            reporte.SetParameterValue("Motivo1", "")
                                            reporte.SetParameterValue("Motivo2", "X")
                                            reporte.SetParameterValue("Motivo3", "")
                                            reporte.SetParameterValue("Motivo4", "")
                                            reporte.SetParameterValue("Motivo5", "")
                                            reporte.SetParameterValue("Motivo6", "")
                                            reporte.SetParameterValue("MotivoT1", "")
                                            reporte.SetParameterValue("MotivoT2", "")
                                            reporte.SetParameterValue("OtroMotivo", "")
                                        Case "7"        ' Consignacion
                                            reporte.SetParameterValue("Motivo1", "")
                                            reporte.SetParameterValue("Motivo2", "")
                                            reporte.SetParameterValue("Motivo3", "X")
                                            reporte.SetParameterValue("Motivo4", "")
                                            reporte.SetParameterValue("Motivo5", "")
                                            reporte.SetParameterValue("Motivo6", "")
                                            reporte.SetParameterValue("MotivoT1", "")
                                            reporte.SetParameterValue("MotivoT2", "")
                                            reporte.SetParameterValue("OtroMotivo", "")
                                        Case "3"        ' Exportacion
                                            reporte.SetParameterValue("Motivo1", "")
                                            reporte.SetParameterValue("Motivo2", "")
                                            reporte.SetParameterValue("Motivo3", "")
                                            reporte.SetParameterValue("Motivo4", "X")
                                            reporte.SetParameterValue("Motivo5", "")
                                            reporte.SetParameterValue("Motivo6", "")
                                            reporte.SetParameterValue("MotivoT1", "")
                                            reporte.SetParameterValue("MotivoT2", "")
                                            reporte.SetParameterValue("OtroMotivo", "")
                                        Case "6"        ' Traslado entre establecimientos de la misma empresa
                                            reporte.SetParameterValue("Motivo1", "")
                                            reporte.SetParameterValue("Motivo2", "")
                                            reporte.SetParameterValue("Motivo3", "")
                                            reporte.SetParameterValue("Motivo4", "")
                                            reporte.SetParameterValue("Motivo5", "X")
                                            reporte.SetParameterValue("Motivo6", "")
                                            reporte.SetParameterValue("MotivoT1", "")
                                            reporte.SetParameterValue("MotivoT2", "")
                                            reporte.SetParameterValue("OtroMotivo", "")
                                        Case "9"        'otros
                                            reporte.SetParameterValue("Motivo1", "")
                                            reporte.SetParameterValue("Motivo2", "")
                                            reporte.SetParameterValue("Motivo3", "")
                                            reporte.SetParameterValue("Motivo4", "")
                                            reporte.SetParameterValue("Motivo5", "")
                                            reporte.SetParameterValue("Motivo6", "X")
                                            reporte.SetParameterValue("MotivoT1", "")
                                            reporte.SetParameterValue("MotivoT2", "")
                                            reporte.SetParameterValue("OtroMotivo", "")
                                        Case "T"
                                            reporte.SetParameterValue("Motivo1", "")
                                            reporte.SetParameterValue("Motivo2", "")
                                            reporte.SetParameterValue("Motivo3", "")
                                            reporte.SetParameterValue("Motivo4", "")
                                            reporte.SetParameterValue("Motivo5", "")
                                            reporte.SetParameterValue("Motivo6", "")
                                            reporte.SetParameterValue("MotivoT1", "Condolidado de ")
                                            reporte.SetParameterValue("MotivoT2", "Mercaderia en el Almacen de Transporte")
                                            reporte.SetParameterValue("OtroMotivo", "")
                                        Case Else
                                            reporte.SetParameterValue("Motivo1", "")
                                            reporte.SetParameterValue("Motivo2", "")
                                            reporte.SetParameterValue("Motivo3", "")
                                            reporte.SetParameterValue("Motivo4", "")
                                            reporte.SetParameterValue("Motivo5", "")
                                            reporte.SetParameterValue("Motivo6", "X")
                                            reporte.SetParameterValue("MotivoT1", "")
                                            reporte.SetParameterValue("MotivoT2", "")
                                            reporte.SetParameterValue("OtroMotivo", dgvDatos.CurrentRow.Cells("DesMot").Text)

                                    End Select

                                    '/////////////////////////////////////////////////////////////////////////////////////////
                                    Dim i As Integer
                                    For i = 0 To 1
                                        If i = 1 Then
                                            '====================== Cambio Angélica ======================
                                            If dgvDatos.CurrentRow.Cells("CodMot").Text = "6" Or dgvDatos.CurrentRow.Cells("CodMot").Text = "T" Then
                                                reporte.SetParameterValue("Transferencia", "T")
                                                reporte.PrintOptions.PrinterName = Impresora
                                                reporte.PrintToPrinter(1, False, 0, 0)
                                            Else
                                                reporte.SetParameterValue("Transferencia", "")
                                                reporte.PrintOptions.PrinterName = Impresora
                                                reporte.PrintToPrinter(1, False, 0, 0)
                                            End If
                                            '=========================================================
                                            '======================= SE COMENTA =========================
                                            'reporte.SetParameterValue("Transferencia", "")
                                            'reporte.PrintOptions.PrinterName = Impresora
                                            'reporte.PrintToPrinter(1, False, 0, 0)                                            
                                            '==========================================================
                                            GoTo 5
                                        ElseIf i = 0 Then
                                            ' ======================= SE COMENTA ========================
                                            'If dgvDatos.CurrentRow.Cells("CodMot").Text = "6" Or dgvDatos.CurrentRow.Cells("CodMot").Text = "T" Then
                                            '    reporte.SetParameterValue("Transferencia", "T")
                                            '    reporte.PrintOptions.PrinterName = Impresora
                                            '    reporte.PrintToPrinter(1, False, 0, 0)
                                            'Else
                                            '    reporte.SetParameterValue("Transferencia", "")
                                            '    reporte.PrintOptions.PrinterName = Impresora
                                            '    reporte.PrintToPrinter(1, False, 0, 0)
                                            'End If
                                            '==========================================================
                                            '====================== Cambio Angélica ======================
                                            reporte.SetParameterValue("Transferencia", "")
                                            reporte.PrintOptions.PrinterName = Impresora
                                            reporte.PrintToPrinter(1, False, 0, 0)
                                            '=========================================================
                                        End If
                                    Next

                                    'reporte.PrintOptions.PrinterName = Impresora
                                    'reporte.PrintToPrinter(2, False, 0, 0)
5:                                  oGuiaRemisionService.ActualizarEstadoImpreso(IdGuia, Session.sCodUsu)
                                    actualizar()

                                End If
                            End If
                        End If
                    End If
                    'forma.crvReportes.PrintReport()
                End If
                'Else
                '     dgvDatos.Focus()
                'End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try

        End If
    End Sub

    Private Sub Imprimir_Detalle()

        Dim forma As New frmReportes
        Dim reporte As New rpImprimirGuia
        Dim dtReporte As New DataTable

        Dim dtDetalles As New DataTable
        Dim IdGuia As Integer = dgvDatos.CurrentRow.Cells("IdGuia").Text
        Dim CodMot As String = dgvDatos.CurrentRow.Cells("CodMot").Text
        dtReporte = oGuiaRemisionService.Imprimir(IdGuia).Tables(0)
        dtDetalles = oGuiaRemisionDetService.Mostrar(toNumber(IdGuia)).Tables(0)


        Dim frm As New frmGuiaRemision_ImprimirPrecio

        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

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

                forma.Text = "Imprimir Guia de Remisión"

                'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                'dtReporte.WriteXmlSchema("C:\GuiaRemision.xml")
                reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                reporte.SetParameterValue("MostrarPrecio", frm.ImprimirPrecio)

                'Debido al nuevo formato de Guia de Remision con 6 motivos
                'Se hace cambio en las guias de remision. Solicitud de Usuario 3757 -14
                Select Case CodMot
                    Case "1" And "5"   ' Venta y Adelantos
                        reporte.SetParameterValue("Motivo1", "X")
                        reporte.SetParameterValue("Motivo2", "")
                        reporte.SetParameterValue("Motivo3", "")
                        reporte.SetParameterValue("Motivo4", "")
                        reporte.SetParameterValue("Motivo5", "")
                        reporte.SetParameterValue("Motivo6", "")
                        reporte.SetParameterValue("MotivoT1", "")
                        reporte.SetParameterValue("MotivoT2", "")
                        reporte.SetParameterValue("OtroMotivo", "")
                    Case "C"        ' Venta Sujeta a confirmacion del comprador
                        reporte.SetParameterValue("Motivo1", "")
                        reporte.SetParameterValue("Motivo2", "X")
                        reporte.SetParameterValue("Motivo3", "")
                        reporte.SetParameterValue("Motivo4", "")
                        reporte.SetParameterValue("Motivo5", "")
                        reporte.SetParameterValue("Motivo6", "")
                        reporte.SetParameterValue("MotivoT1", "")
                        reporte.SetParameterValue("MotivoT2", "")
                        reporte.SetParameterValue("OtroMotivo", "")
                    Case "7"        ' Consignacion
                        reporte.SetParameterValue("Motivo1", "")
                        reporte.SetParameterValue("Motivo2", "")
                        reporte.SetParameterValue("Motivo3", "X")
                        reporte.SetParameterValue("Motivo4", "")
                        reporte.SetParameterValue("Motivo5", "")
                        reporte.SetParameterValue("Motivo6", "")
                        reporte.SetParameterValue("MotivoT1", "")
                        reporte.SetParameterValue("MotivoT2", "")
                        reporte.SetParameterValue("OtroMotivo", "")
                    Case "3"        ' Exportacion
                        reporte.SetParameterValue("Motivo1", "")
                        reporte.SetParameterValue("Motivo2", "")
                        reporte.SetParameterValue("Motivo3", "")
                        reporte.SetParameterValue("Motivo4", "X")
                        reporte.SetParameterValue("Motivo5", "")
                        reporte.SetParameterValue("Motivo6", "")
                        reporte.SetParameterValue("MotivoT1", "")
                        reporte.SetParameterValue("MotivoT2", "")
                        reporte.SetParameterValue("OtroMotivo", "")
                    Case "6"        ' Traslado entre establecimientos de la misma empresa
                        reporte.SetParameterValue("Motivo1", "")
                        reporte.SetParameterValue("Motivo2", "")
                        reporte.SetParameterValue("Motivo3", "")
                        reporte.SetParameterValue("Motivo4", "")
                        reporte.SetParameterValue("Motivo5", "X")
                        reporte.SetParameterValue("Motivo6", "")
                        reporte.SetParameterValue("MotivoT1", "")
                        reporte.SetParameterValue("MotivoT2", "")
                        reporte.SetParameterValue("OtroMotivo", "")
                    Case "9"        'Otros
                        reporte.SetParameterValue("Motivo1", "")
                        reporte.SetParameterValue("Motivo2", "")
                        reporte.SetParameterValue("Motivo3", "")
                        reporte.SetParameterValue("Motivo4", "")
                        reporte.SetParameterValue("Motivo5", "")
                        reporte.SetParameterValue("Motivo6", "X")
                        reporte.SetParameterValue("MotivoT1", "")
                        reporte.SetParameterValue("MotivoT2", "")
                        reporte.SetParameterValue("OtroMotivo", "")
                    Case "T"
                        reporte.SetParameterValue("Motivo1", "")
                        reporte.SetParameterValue("Motivo2", "")
                        reporte.SetParameterValue("Motivo3", "")
                        reporte.SetParameterValue("Motivo4", "")
                        reporte.SetParameterValue("Motivo5", "")
                        reporte.SetParameterValue("Motivo6", "")
                        reporte.SetParameterValue("MotivoT1", "Condolidado de ")
                        reporte.SetParameterValue("MotivoT2", "Mercaderia en el Almacen de Transporte")
                        reporte.SetParameterValue("OtroMotivo", "")
                    Case Else
                        reporte.SetParameterValue("Motivo1", "")
                        reporte.SetParameterValue("Motivo2", "")
                        reporte.SetParameterValue("Motivo3", "")
                        reporte.SetParameterValue("Motivo4", "")
                        reporte.SetParameterValue("Motivo5", "")
                        reporte.SetParameterValue("Motivo6", "X")
                        reporte.SetParameterValue("MotivoT1", "")
                        reporte.SetParameterValue("MotivoT2", "")
                        reporte.SetParameterValue("OtroMotivo", dgvDatos.CurrentRow.Cells("DesMot").Text)

                End Select

                '/////////////////////////////////////////////////////////////////////////////////////////
                '//Comentado por el cambio de Angelica
                'Dim i As Integer
                'For i = 0 To 1
                '    If i = 1 Then

                '        reporte.SetParameterValue("Transferencia", "")
                '        reporte.PrintOptions.PrinterName = Impresora
                '        reporte.PrintToPrinter(1, False, 0, 0)
                '        GoTo 5
                '    ElseIf i = 0 Then

                '        If dgvDatos.CurrentRow.Cells("CodMot").Text = "6" Or dgvDatos.CurrentRow.Cells("CodMot").Text = "T" Then
                '            reporte.SetParameterValue("Transferencia", "T")
                '            reporte.PrintOptions.PrinterName = Impresora
                '            reporte.PrintToPrinter(1, False, 0, 0)
                '        Else
                '            reporte.SetParameterValue("Transferencia", "")
                '            reporte.PrintOptions.PrinterName = Impresora
                '            reporte.PrintToPrinter(1, False, 0, 0)
                '        End If

                '    End If
                'Next


                '//Agregado por el cambio de Angelica
                Dim i As Integer
                For i = 0 To 1
                    If i = 1 Then
                        '====================== Cambio Angélica ======================
                        If dgvDatos.CurrentRow.Cells("CodMot").Text = "6" Or dgvDatos.CurrentRow.Cells("CodMot").Text = "T" Then
                            reporte.SetParameterValue("Transferencia", "T")
                            reporte.PrintOptions.PrinterName = Impresora
                            reporte.PrintToPrinter(1, False, 0, 0)
                        Else
                            reporte.SetParameterValue("Transferencia", "")
                            reporte.PrintOptions.PrinterName = Impresora
                            reporte.PrintToPrinter(1, False, 0, 0)
                        End If
                        '=========================================================
                        '======================= SE COMENTA =========================
                        'reporte.SetParameterValue("Transferencia", "")
                        'reporte.PrintOptions.PrinterName = Impresora
                        'reporte.PrintToPrinter(1, False, 0, 0)                                            
                        '==========================================================
                        GoTo 5
                    ElseIf i = 0 Then
                        ' ======================= SE COMENTA ========================
                        'If dgvDatos.CurrentRow.Cells("CodMot").Text = "6" Or dgvDatos.CurrentRow.Cells("CodMot").Text = "T" Then
                        '    reporte.SetParameterValue("Transferencia", "T")
                        '    reporte.PrintOptions.PrinterName = Impresora
                        '    reporte.PrintToPrinter(1, False, 0, 0)
                        'Else
                        '    reporte.SetParameterValue("Transferencia", "")
                        '    reporte.PrintOptions.PrinterName = Impresora
                        '    reporte.PrintToPrinter(1, False, 0, 0)
                        'End If
                        '==========================================================
                        '====================== Cambio Angélica ======================
                        reporte.SetParameterValue("Transferencia", "")
                        reporte.PrintOptions.PrinterName = Impresora
                        reporte.PrintToPrinter(1, False, 0, 0)
                        '=========================================================
                    End If
                Next
                '//


                'reporte.PrintOptions.PrinterName = Impresora
                'reporte.PrintToPrinter(2, False, 0, 0)
5:              oGuiaRemisionService.ActualizarEstadoImpreso(IdGuia, Session.sCodUsu)
                actualizar()
            End If
        End If
    End Sub

    Private Sub ticket()
        If ValidaCodigoSeleccionado() Then
            Try
                Dim forma As New frmReportes
                Dim reporte As New rpImprimirTicket
                Dim reporte1 As New rpImprimirTicketNuevo
                Dim reporte2 As New rpImprimirTicketNuevo2
                Dim reportePC As New rpImprimirTicketPC
                Dim reporte1PC As New rpImprimirTicketNuevoPC
                Dim reporte2PC As New rpImprimirTicketNuevo2PC
                Dim dtReporte As New DataTable
                Dim IdGuia As Integer = dgvDatos.CurrentRow.Cells("IdGuia").Text

                dtReporte = oGuiaRemisionService.Imprimir(IdGuia).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay Datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    If dtReporte.Rows.Count < 5 Then

                        Dim Impresora As String = SeleccionarImpresora()
                        If Impresora <> "" Then

                            If Session.sCodEmp = "05" Then

                                reportePC.SetDataSource(dtReporte)
                                forma.crvReportes.ReportSource = reportePC

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                forma.Text = "Imprimir Ticket"

                                reportePC.PrintOptions.PrinterName = Impresora
                                reportePC.PrintToPrinter(1, False, 0, 0)

                                oGuiaRemisionService.ActualizarEstadoTK(IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                            Else


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

                                oGuiaRemisionService.ActualizarEstadoTK(IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                            End If



                        End If

                    ElseIf dtReporte.Rows.Count >= 5 And dtReporte.Rows.Count < 14 Then

                        Dim Impresora As String = SeleccionarImpresora()
                        If Impresora <> "" Then

                            If Session.sCodEmp = "05" Then


                                reporte1PC.SetDataSource(dtReporte)
                                forma.crvReportes.ReportSource = reporte1PC

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                forma.Text = "Imprimir Ticket"

                                reporte1PC.PrintOptions.PrinterName = Impresora
                                reporte1PC.PrintToPrinter(1, False, 0, 0)

                                oGuiaRemisionService.ActualizarEstadoTK(IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                            Else

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

                                oGuiaRemisionService.ActualizarEstadoTK(IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)


                            End If



                        End If

                    ElseIf dtReporte.Rows.Count >= 14 Then

                        Dim Impresora As String = SeleccionarImpresora()
                        If Impresora <> "" Then

                            If Session.sCodEmp = "05" Then

                                reporte2PC.SetDataSource(dtReporte)
                                forma.crvReportes.ReportSource = reporte2PC

                                If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                    forma.crvReportes.ShowExportButton = True
                                Else
                                    forma.crvReportes.ShowExportButton = False
                                End If
                                'forma.crvReportes.RefreshReport = False
                                'forma.crvReportes.DisplayGroupTree = False

                                forma.Text = "Imprimir Ticket"

                                reporte2PC.PrintOptions.PrinterName = Impresora
                                reporte2PC.PrintToPrinter(1, False, 0, 0)

                                oGuiaRemisionService.ActualizarEstadoTK(IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                            Else

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

                                oGuiaRemisionService.ActualizarEstadoTK(IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)


                            End If



                        End If
                        'Dim Impresora As String = SeleccionarImpresora()
                        'If Impresora <> "" Then

                        '    reporte.SetDataSource(dtReporte)
                        '    forma.crvReportes.ReportSource = reporte

                        '    forma.Text = "Imprimir Ticket"



                        '    ' forma.crvReportes.PrintReport()


                        '    reporte.PrintOptions.PrinterName = Impresora
                        '    reporte.PrintToPrinter(1, False, 0, 0)

                        '    oGuiaRemisionService.ActualizarEstadoTK(IdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)

                        'End If


                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try

        End If
    End Sub

    Private Sub enviar()
        If ValidaCodigoSeleccionado() Then
            Try
                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ENVIAR la Guía Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " a Créditos para su aprobación ... ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean

                    estado_process = oGuiaRemisionService.EnviarCreditos(dgvDatos.CurrentRow.Cells("IdGuia").Text, dgvDatos.CurrentRow.Cells("IdSugerido").Text, Session.sCodUsu)
                    If estado_process = True Then
                        dtDatos = Nothing
                        actualizar()
                        MsgBox("La Guía fue Enviada a Créditos correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ENVIAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub generar()
        If ValidaCodigoSeleccionado() Then
            Try
                If oGuiaRemisionService.Estado(dgvDatos.CurrentRow.Cells("IdGuia").Value) = "IMPRESO" Then
                    Dim frm As New frmGuiaRemision_GenerarDocumento
                    frm.Text = "Generar Bol./Fac.  de la Guía Nº " + txtNumDoc.Text.ToString
                    frm.IdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Value
                    frm.IdLocacion = dgvDatos.CurrentRow.Cells("IdLocacion").Value
                    frm.CodPag = toNull(dgvDatos.CurrentRow.Cells("CodPag").Text)
                    frm.CodMon = dgvDatos.CurrentRow.Cells("CodMon").Value
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        actualizar()
                    End If
                Else
                    MsgBox("Debe de estar en estado IMPRESO para generar un documento, Verifique")
                End If

            Catch ex As Exception
                MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub trasladar()
        If ValidaCodigoSeleccionado() Then
            Try
                Dim frm As New frmGuiaRemision_Transferir

                frm.Text = "Transferir Guía de Remisión Nº " + txtNumDoc.Text.ToString
                frm.IdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Value
                frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Value

                If dgvDatos.CurrentRow.Cells("IdCliente").Text = "2217" Then
                    frm.txtAlmacen.Text = "LIMA" & " - " & cmbIdLocacion.Text
                    frm.IdLocacion = oMaestroService.ObtenerIdLocacion(Session.sCodEmp, "01", cmbIdLocacion.DropDownList.GetRow.Cells(3).Text)
                ElseIf dgvDatos.CurrentRow.Cells("IdCliente").Text = "2227" Then
                    frm.txtAlmacen.Text = "CHIMBOTE" & " - " & cmbIdLocacion.Text
                    frm.IdLocacion = oMaestroService.ObtenerIdLocacion(Session.sCodEmp, "02", cmbIdLocacion.DropDownList.GetRow.Cells(3).Text)
                ElseIf dgvDatos.CurrentRow.Cells("IdCliente").Text = "2239" Then
                    frm.txtAlmacen.Text = "TOQUEPALA" & " - " & cmbIdLocacion.Text
                    frm.IdLocacion = oMaestroService.ObtenerIdLocacion(Session.sCodEmp, "03", cmbIdLocacion.DropDownList.GetRow.Cells(3).Text)
                ElseIf dgvDatos.CurrentRow.Cells("IdCliente").Text = "2240" Then
                    frm.txtAlmacen.Text = "CUAJONE" & " - " & cmbIdLocacion.Text
                    frm.IdLocacion = oMaestroService.ObtenerIdLocacion(Session.sCodEmp, "04", cmbIdLocacion.DropDownList.GetRow.Cells(3).Text)
                ElseIf dgvDatos.CurrentRow.Cells("IdCliente").Text = "2276" Then
                    frm.txtAlmacen.Text = "LIMA" & " - " & "CONSIGNACION REPUESTOS VOLCAN"
                    frm.IdLocacion = 9
                    'frm.IdLocacion = oMaestroService.ObtenerIdLocacion(Session.sCodEmp, "01", cmbIdLocacion.DropDownList.GetRow.Cells(3).Text)
                ElseIf dgvDatos.CurrentRow.Cells("IdCliente").Text = "2277" Then
                    frm.txtAlmacen.Text = "TINTAYA" & " - " & cmbIdLocacion.Text
                    frm.IdLocacion = oMaestroService.ObtenerIdLocacion(Session.sCodEmp, "05", cmbIdLocacion.DropDownList.GetRow.Cells(3).Text)

                    '--------------------- EQUIMAP --------------------- 
                ElseIf dgvDatos.CurrentRow.Cells("IdCliente").Text = "56856" Then
                    frm.txtAlmacen.Text = "LIMA" & " - " & cmbIdLocacion.Text
                    frm.IdLocacion = oMaestroService.ObtenerIdLocacion(Session.sCodEmp, "01", cmbIdLocacion.DropDownList.GetRow.Cells(3).Text)

                ElseIf dgvDatos.CurrentRow.Cells("IdCliente").Text = "57372" Then
                    frm.txtAlmacen.Text = "CHIMBOTE" & " - " & cmbIdLocacion.Text
                    frm.IdLocacion = oMaestroService.ObtenerIdLocacion(Session.sCodEmp, "02", cmbIdLocacion.DropDownList.GetRow.Cells(3).Text)
                    '----------------------------------------------------
                End If

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    actualizar()
                End If
            Catch ex As Exception
                MsgBox("ERROR [TRASLADAR]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub b2minig()
        If ValidaCodigoSeleccionado() Then

        End If
    End Sub
    Private Sub nuevo()
        Try
            Dim frm As New frmGuiaRemision
            frm.state_button = False
            frm.edicion = True
            frm.editable = True
            frm.IdLocacion = cmbIdLocacion.Value
            frm.IdSerieDoc = oGuiaRemisionService.MostraIdSerie(cmbIdLocacion.Value)
            frm.txtNumDoc.Text = oGuiaRemisionService.SugerirNumero(frm.IdSerieDoc)
            frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", frm.IdLocacion))
            frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.CodOfi = cmbOficinas.Value        '--------- Se agregó el 09/05/2014 para que aparesca la direccion de oficina en el campo de punto de partida (Jacquelin)

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                'limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text)
                listaDatos()
                'If frm.type_process = "insert" Then
                RowPossesion(dgvDatos, frm.IdGuia)
                mostrar()
                'End If
            End If
            actualizar()
            'If dgvDatos.CurrentRow.Cells("TotNetoSug").Text > 0 Then
            '    dgvDatos.RootTable.Columns(9).Visible = True
            'Else
            '    dgvDatos.RootTable.Columns(9).Visible = False
            'End If
        Catch ex As Exception
            MsgBox("ERROR [AGREGAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrar()
        If ValidaCodigoSeleccionado() And dgvDatos.CurrentRow.Cells("Estado").Text <> "AN" Then
            Try
                Dim frm As New frmGuiaRemision
                Dim lEstado As String
                lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
                frm.state_button = True
                frm.IdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Value
                frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Value
                frm.edicion = False
                frm.editable = IIf(lEstado = "GN" Or lEstado = "AP" Or lEstado = "CR", True, False)
                frm.lblUbicacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
                frm.CodOfi = cmbOficinas.Value       '--------- Se agregó el 09/05/2014 para que aparesca la direccion de oficina en el campo de punto de partida (Jacquelin)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    actualizar()
                End If
                actualizar()
            Catch ex As Exception
                MsgBox("ERROR [MOSTRAR]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub eliminar()
        If ValidaCodigoSeleccionado() Then
            Try
                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ELIMINAR la Guía Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString, MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oGuiaRemisionService.Borrar(dgvDatos.CurrentRow.Cells("IdGuia").Text, Session.sCodUsu)
                    If estado_process = True Then
                        listaDatos()
                        'actualizar()
                        MsgBox("La Guía fue Eliminada correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ELIMINAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub anular()
        If ValidaCodigoSeleccionado() Then
            Try
                Dim frm As New frmGuiaRemision_MotivoBaja
                frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
                frm.IdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Text
                frm.TipMov = dgvDatos.CurrentRow.Cells("TipMov").Text
                frm.Oficina = cmbOficinas.Value
                frm.IdLocacion = cmbIdLocacion.Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    actualizar()
                End If

            Catch ex As Exception
                MsgBox("ERROR [ANULAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Public Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdGuia").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
        enableOpciones()
    End Sub
    Private Sub salir()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub listaDatos()
        Try
            If state_Search = True Then
                dtDatos = oGuiaRemisionService.Filtrar(txtanio.Value, cmbMes.Value, IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value),
                                                     IdSerieDoc, toNumber(IdCliente), cmbEstado.Value, toNumber(txtNumDoc.Text)).Tables(0)
                'dgvDatos.SetDataBinding(dtDatos, 0)
                dgvDatos.DataSource = dtDatos

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdGuia").Text = Nothing Then
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
            dtEstados = oGuiaRemisionService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbEstado.ValueChanged, cmbMes.ValueChanged
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
            cmbIdLocacion.DropDownList.Columns(2).DataMember = dtAlmacenes.Columns("AproDoc").ToString
            cmbIdLocacion.DropDownList.Columns(3).DataMember = dtAlmacenes.Columns("CodAlm").ToString
            If dtAlmacenes.Rows.Count > 0 Then
                cmbIdLocacion.SelectedIndex = 0
            Else
                cmbIdLocacion.Value = ""
            End If
            'dtAlmacenes = Nothing
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
            chkCliente.Checked = False
            If toNull(frm.codigo) <> Nothing Then
                txtIdCliente.Text = frm.descripcion
                IdCliente = frm.codigo
            Else
                txtIdCliente.Text = "(Todos)"
                IdCliente = 0
            End If
            listaDatos()
        End If
    End Sub
    Private Sub cmbIdLocacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdLocacion.ValueChanged
        Try
            IdSerieDoc = oGuiaRemisionService.MostraIdSerie(toNumber(cmbIdLocacion.Value)) '1: Guís de Remisión  '4:Guía de Devolución
            If dtAlmacenes.Rows.Count > 0 Then
                lAprobacion = dtAlmacenes.Rows(cmbIdLocacion.SelectedIndex).Item("AproDoc")
            Else
                lAprobacion = False
            End If
            listaDatos()
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub biImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        imprimir()
    End Sub
    Private Sub biTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTicket.Click
        ticket()
    End Sub
    Private Sub biEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click
        enviar()
    End Sub
    Private Sub biGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.Click
        generar()
    End Sub
    Private Sub biTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladar.Click
        trasladar()
    End Sub
    Private Sub biB2Mining_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biB2Mining.Click
        b2minig()
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

            Dim frm As New frmGuiaRemision_SugerirCabecera
            frm.IdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Text
            frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstado.Click, miEstado.Click
        Try
            Dim frm As New frmGuiaRemision_Estados

            frm.IdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Text
            frm.Text = "Estados de Guía de Remisión Nº : " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("ERROR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click
        nuevo()

    End Sub

    Private Sub biMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click
        mostrar()
    End Sub

    Private Sub biEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        eliminar()
    End Sub

    Private Sub biActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click
        actualizar()

    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        salir()
    End Sub
    Private Sub biAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.Click
        anular()
    End Sub
    Private Sub miImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miImprimir.Click
        imprimir()
    End Sub
    Private Sub miTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTicket.Click
        ticket()
    End Sub
    Private Sub miEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEnviar.Click
        enviar()
    End Sub
    Private Sub miGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGenerar.Click
        generar()
    End Sub
    Private Sub miTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTrasladar.Click
        trasladar()
    End Sub
    Private Sub miB2Mining_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miB2Mining.Click
        b2minig()
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        nuevo()
    End Sub
    Private Sub miMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrar()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        eliminar()
    End Sub
    Private Sub miAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAnular.Click
        anular()
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()

    End Sub
    Private Sub miSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                      biImprimir.MouseLeave, biTicket.MouseLeave, biEnviar.MouseLeave, biGenerar.MouseLeave,
                                      biTrasladar.MouseLeave, biB2Mining.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave, biEstado.MouseLeave,
                                      biEliminar.MouseLeave, biSugerir.MouseLeave, biAnular.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave,
                                      miImprimir.MouseLeave, miTicket.MouseLeave, miEnviar.MouseLeave, miGenerar.MouseLeave,
                                      miTrasladar.MouseLeave, miB2Mining.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, miEstado.MouseLeave,
                                      miEliminar.MouseLeave, miSugerir.MouseLeave, miAnular.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Guía de Remisión actual."
    End Sub
    Private Sub Ticket_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTicket.MouseEnter, miTicket.MouseEnter
        sslError.Text = "Imprimir Ticket de Almacén de la Guía de Remisión actual."
    End Sub
    Private Sub Enviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar a Créditos para su Aprobación la Guía de Remisión actual."
    End Sub
    Private Sub Generar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGenerar.MouseEnter, miGenerar.MouseEnter
        sslError.Text = "Generar Factura/Boleta a partir de la Guía de Remisión actual."
    End Sub
    Private Sub Trasladar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTrasladar.MouseEnter, miTrasladar.MouseEnter
        sslError.Text = "Trasladar a otro Almacén la Guía de Remisión actual."
    End Sub
    Private Sub B2Mining_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biB2Mining.MouseEnter, miB2Mining.MouseEnter
        sslError.Text = "Enviar a la Integración B2Mining la Guía de Remisión actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Guía de Remisión."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Guía de Remisión actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Guía de Remisión actual."
    End Sub
    Private Sub Sugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.MouseEnter, miSugerir.MouseEnter
        sslError.Text = "Sugerir Factor o Descuento al Documento."
    End Sub
    Private Sub Anular_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.MouseEnter, miAnular.MouseEnter
        sslError.Text = "Anular Guía de Remisión actual."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub Estado_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstado.MouseEnter, miEstado.MouseEnter
        sslError.Text = "Mostrar los Estados de la Guía de Remisión."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub

    'Private Sub dgvDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvDatos.KeyPress
    '    'If Not (Char.IsDigit(e.KeyChar) Then
    '    '    e.Handled = True
    '    'End If
    '    If Asc(e.KeyChar) = 3 Then
    '        e.Handled = False
    '    Else
    '        e.Handled = Not (e.KeyChar = "")
    '    End If

    'End Sub

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

    Private Sub biAgregarConsumoJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAgregarConsumoJob.Click, miAgregarConsumoJob.Click

        Try
            Dim frm As New frmGuiaRemision_AgregarConsumoJob

            frm.Locacion = cmbOficinas.Text
            frm.Almacen = cmbIdLocacion.Text
            frm.CodAlmacen = cmbIdLocacion.Value
            frm.IdSerieDoc = oGuiaRemisionService.MostraIdSerie(cmbIdLocacion.Value)
            frm.NumDoc = oGuiaRemisionService.SugerirNumero(frm.IdSerieDoc)
            'frm.Text = "Agregar Consumo de Job" & txtNumDoc.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)

        End Try

    End Sub

    Private Sub biConsultarSugerido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConsultarSugerido.Click, miConsultarSugerido.Click
        Try
            Dim frm As New frmGuiaRemision_ConsultarSugerido

            frm.IdCodigo = dgvDatos.CurrentRow.Cells("IdGuia").Text
            frm.TipoCodigo = "GR"
            frm.Text = "Precios Sugeridos de Guía de Remisión Nº : " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If

        Catch ex As Exception
            MsgBox("Error al consultar precios sugeridos : " + ex.Message)
        End Try
    End Sub

    Private Sub biBajarNivel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biBajarNivel.Click, miBajarNivel.Click

        Try
            Dim frm As New frmDocVenta_ActualizarEstado

            frm.Text = "Actualizar a estado inicial"
            frm.TipoDoc = "Guia de Remisión"
            frm.IdDocVenta = dgvDatos.CurrentRow.Cells("IdGuia").Text
            frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    Private Sub biGenerarGuiaElectronica_Click(sender As Object, e As EventArgs) Handles biGenerarGuiaElectronica.Click, miGenerarGuiaElectronica.Click

        Try
            Dim existefactelec As Boolean
            'Dim MostrarBanco As Boolean
            Dim opcionimp As String
            Dim dtDatosDetalles As DataTable
            Dim CodModo As String
            Dim Guia As String

            CodModo = dgvDatos.CurrentRow.Cells("CodModo").Text
            Guia = dgvDatos.CurrentRow.Cells("IdGuia").Text

            'If CodModo = "02" And ((oTransportistaService.BuscarGuia(Guia)) = False) Then
            If oTransportistaService.BuscarGuia(Guia) = False Then
                MsgBox("Debe de ingresar el transportista, verifique.", MsgBoxStyle.Information)
            Else
                existefactelec = oGuiaRemisionDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdGuia").Text)
                'existefactelec = False
                If existefactelec = True Then
                    MsgBox("Ya existe la guia de remision electronica, verifique.", MsgBoxStyle.Information)
                Else
                    'If Not (oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) <> "003" And oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) <> "004" And oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) <> "067" And oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) <> "009") Then
                    'Dim frm As New frmGuiaRemision_GuiaRemisionElectronica  'frmGuiaRemision_GuiaRemisionElectronica_Imprimir
                    'frm.IdGu = dgvDatos.CurrentRow.Cells("IdGuia").Text

                    dtDatosDetalles = oGuiaRemisionDetService.Mostrar(toNumber(dgvDatos.CurrentRow.Cells("IdGuia").Text)).Tables(0)

                    'If dtDatosDetalles.Rows.Count <= 40 Then

                    Dim frm As New frmGuiaRemision_Electronica_Imprimir
                        Dim MostrarPrecio As Boolean
                        Dim GuiaPreexis As Boolean
                        Dim idguiareg As Integer = 0
                        Dim numdocguiareg As String = ""
                        Dim docrefreg As String = ""
                        Dim codsunatrefreg As String = ""
                        Dim desdocrefreg As String = ""
                        frm.IdGuiaPreImpresion = toNumber(dgvDatos.CurrentRow.Cells("IdGuia").Text)
                        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                            idguiareg = frm.IdGuiaRem
                            numdocguiareg = frm.NumDocGuiaRem
                            docrefreg = frm.DocumentoRef
                            codsunatrefreg = frm.CodSunatRef
                            desdocrefreg = frm.DesDocRef
                            GuiaPreexis = frm.GuiaPreexistente
                            If frm.mostrarprecio = True Then
                                MostrarPrecio = True
                            Else
                                MostrarPrecio = False
                            End If
                            opcionimp = frm.opcion
                            MostrarPrecio = frm.mostrarprecio
                            Dim frm1 As New frmGuiaRemision_GuiaRemisionElectronica
                            frm1.IdGuiaReg = idguiareg
                            frm1.NumDocGuiaReg = numdocguiareg
                            frm1.DocumentoReferencia = docrefreg
                            frm1.CodSunatReferencia = codsunatrefreg
                            frm1.DesDocReferencia = desdocrefreg
                            frm1.GuiaPreexistente = GuiaPreexis
                            frm1.IdGu = dgvDatos.CurrentRow.Cells("IdGuia").Text
                            frm1.opcionimp = opcionimp
                            frm1.MostrarPrecio = MostrarPrecio
                            frm1.enProceso = False
                            If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                If frm1.EstadoSunat = True Then
                                    listaDatos()
                                    RowPossesion(dgvDatos, frm1.IdGu)
                                End If
                            End If
                        Else
                            Exit Sub
                        End If
                    'Else
                    '    MsgBox("No puede imprimir por exceso de líneas. Limite de lineas : 25. Verificar")
                    'End If
                End If

            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al generar la guia de remision electronica")
        End Try

    End Sub

    Private Sub biDarBajaGuiaElectronica_Click(sender As Object, e As EventArgs) Handles biDarBajaGuiaElectronica.Click
        Try
            'Dim existefactelec As Boolean

            'existefactelec = oGuiaRemisionDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdGuia").Text)
            ''existefactelec = True

            'If existefactelec = True Then

            '    'Dim frm As New frmGuiaRemision_GuiaRemisionElectronica_ComunicadoBaja
            '    'frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            '    'frm.DesCli = dgvDatos.CurrentRow.Cells("DesCli").Text
            '    'frm.CodMon = dgvDatos.CurrentRow.Cells("CodMon").Text
            '    'frm.TotNeto = CDec(dgvDatos.CurrentRow.Cells("TotNeto").Text)
            '    'If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            '    '    listaDatos()
            '    '    RowPossesion(dgvDatos, frm.IdGuia)
            '    'End If
            'Else
            '    MsgBox("No existe la factura electronica, verifique.", MsgBoxStyle.Information)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al dar de baja la factura electronica")
        End Try
    End Sub

    Private Sub biDescargarGuiaElectronica_Click(sender As Object, e As EventArgs) Handles biDescargarGuiaElectronica.Click, miDescargarGuiaElectronica.Click
        Try

            Dim existefactelec As Boolean

            existefactelec = oGuiaRemisionDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdGuia").Text)

            If existefactelec = True Then

                Dim dtImprimirDigital As New DataTable

                dtImprimirDigital = oGuiaRemisionService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdGuia").Text).Tables(0)
                GridEX2.DataSource = dtImprimirDigital

                'CodMot = GridEX2.CurrentRow.Cells("CodMot").Text
                'LegalMonetaryTotal = GridEX2.CurrentRow.Cells("LegalMonetaryTotal").Text
                'CurrencyId = GridEX2.CurrentRow.Cells("CurrencyId").Text
                'TipoDoc = GridEX2.CurrentRow.Cells("TipoDoc").Text
                'TaxAmount = GridEX2.CurrentRow.Cells("TaxAmount").Text
                'CodSerieFac = GridEX2.CurrentRow.Cells("CodSerie").Text
                'NumDocFac = GridEX2.CurrentRow.Cells("NumDoc").Text
                DocumentoFac = GridEX2.CurrentRow.Cells("Documento").Text
                'FecDoc = GridEX2.CurrentRow.Cells("FecDoc").Text
                'RucEmp = GridEX2.CurrentRow.Cells("RucEmp").Text
                'RucCli = GridEX2.CurrentRow.Cells("RucCli").Text
                'CodMon = GridEX2.CurrentRow.Cells("CodMon").Text

                CrearCarpeta()
                CrearXML()
                'ObtenerTagFirma()
                CrearPDF()
            Else
                MsgBox("No existe la factura electronica, verifique.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al descargar la guia de remision electronica")
        End Try
    End Sub


    Private Sub CrearCarpeta()

        If Not Directory.Exists("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & GridEX2.CurrentRow.Cells("Documento").Text) Then
            Directory.CreateDirectory("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & GridEX2.CurrentRow.Cells("Documento").Text)
        End If

    End Sub

    Private Sub CrearXML()

        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(New StringReader(oGuiaRemisionDigitalService.Descargar(dgvDatos.CurrentRow.Cells("IdGuia").Text)))

            NombreXMLPDF = oGuiaRemisionDigitalService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdGuia").Text)

            xmlDoc.Save("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".xml")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el xml")
        End Try

    End Sub

    Private Sub CrearPDF()
        Try
            Dim pdfDoc() As Byte
            pdfDoc = oGuiaRemisionDigitalService.DescargarPdf(dgvDatos.CurrentRow.Cells("IdGuia").Text)

            NombreXMLPDF = oGuiaRemisionDigitalService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdGuia").Text)

            System.IO.File.WriteAllBytes("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".pdf", pdfDoc)

            MsgBox("Se descargo la guia de remision electronica correctamente", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el pdf")
        End Try
    End Sub

    Private Sub biListarGuiaElecxCliente_Click(sender As Object, e As EventArgs) Handles biListarGuiaElecxCliente.Click
        Try

            Dim dtImprimirDigital As New DataTable

            dtImprimirDigital = oGuiaRemisionService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdGuia").Text).Tables(0)
            GridEX2.DataSource = dtImprimirDigital

            CodSerieFac = GridEX2.CurrentRow.Cells("CodSerie").Text
            NumDocFac = GridEX2.CurrentRow.Cells("NumDoc").Text

            Dim frm As New frmGuiaRemision_GuiaRemisionElectronicaxCliente
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
            frm.DesCli = dgvDatos.CurrentRow.Cells("DesCli").Text
            frm.CodSerie = CodSerieFac
            frm.NumDoc = NumDocFac
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdGuia").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al listar las guias de remision x cliente")
        End Try
    End Sub

    Private Sub miObservacionesSunat_Click(sender As Object, e As EventArgs) Handles miObservacionesSunat.Click
        Try
            Dim frm As New frmGuiaRemision_Electronica_ObsSunat
            frm.IdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar las observaciones")
        End Try
    End Sub

    Private Sub miObtenercdrdoc_Click(sender As Object, e As EventArgs) Handles miObtenercdrdoc.Click
        Try
            Dim frm As New frmFacturacionElectronica_ObtenerEstadoSunat
            frm.TipoDoc = "09"
            frm.CodSerie = dgvDatos.CurrentRow.Cells("CodSerie").Text
            frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar las observaciones")
        End Try
    End Sub

    Private Sub miActualizarCDR_Click(sender As Object, e As EventArgs) Handles miActualizarCDR.Click
        Try

            Dim frm1 As New frmGuiaRemision_Electronica_ActualizarCDR
            frm1.IdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Text
            frm1.CodSerie = dgvDatos.CurrentRow.Cells("CodSerie").Text
            frm1.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
            If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm1.IdGuia)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al generar la factura electronica")
        End Try
    End Sub

    Private Sub miProcesarGuiaElectronica_Click(sender As Object, e As EventArgs) Handles miProcesarGuiaElectronica.Click
        Try

            If dgvDatos.CurrentRow.Cells("EstadoSunat").Text <> "EN PROCESO" Then
                MsgBox("La guia no esta EN PROCESO, no puede utilizar esta opcion, tenga cuidado!!!!!!!!", MsgBoxStyle.Information, "NO ESTA EN PROCESO")
                Exit Sub
            End If

            '//////////ACTUALIZAR GUIA EN PROCESO - VENTANA/////////
            Dim frm2 As New frmGuiaRemision_GuiaRemisionElectronica_ActProceso
            frm2.pIdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Text
            frm2.pCodSerie = dgvDatos.CurrentRow.Cells("CodSerie").Text
            frm2.pNumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
            frm2.Documento = dgvDatos.CurrentRow.Cells("CodSerie").Text + "-" + dgvDatos.CurrentRow.Cells("NumDoc").Text
            frm2.ticket = oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaRemisionDigital", "NumTicket", "IdGuia", dgvDatos.CurrentRow.Cells("IdGuia").Text)

            If frm2.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm2.pIdGuia)
            End If




            '=====================================================================================
            'Dim pIdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Text
            'Dim pCodSerie = dgvDatos.CurrentRow.Cells("CodSerie").Text
            'Dim pNumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
            'Dim Documento As String = pCodSerie + "-" + pNumDoc
            'Dim ticket = oMaestroService.MostrarDato("SIGECOM.Ventas.GuiaRemisionDigital", "NumTicket", "IdGuia", pIdGuia)


            'Dim insertar As Boolean

            'Dim rutaenvio As String = "D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\"
            'Dim file As String = ""
            'file = Session.sRucEmp & "-09-" & Documento & ".zip"


            ''////////////GENERAR TOKEN///////////////
            'Dim respuesta As New ConectarAPISUNAT.RespuestaToken()
            'Dim userSOL As String = Session.sRucEmp & Session.sUsuarioSunat
            'respuesta = ConectarAPISUNAT.GenerarTokenSunat(Session.sUrlApiSunat, Session.sIdApiSunat, Session.sClaveApiSunat, userSOL, Session.sClaveSunat)
            ''////////////////////////////////////////


            ''/////////CONSULTAR EL NUMERO DE TICKET///////////////
            'Dim respuestaTicket As New ConectarAPISUNAT.ResponseConsultarGre()
            'Dim url As String = "https://api-cpe.sunat.gob.pe/v1/contribuyente/gem/comprobantes/envios/" & ticket
            'respuestaTicket = ConectarAPISUNAT.ObtenerCDR(file, url, respuesta.access_token, ticket)
            ''////////////////////////////////////////////////////////////////////////

            'If respuestaTicket.codRespuesta = "0" And respuestaTicket.indCdrGenerado = 1 Then
            '    Dim fileCDR As String = Session.sRucEmp & "-09-" & Documento
            '    ConectarAPISUNAT.ConvertirCDR(respuestaTicket.arcCdr, rutaenvio, fileCDR)


            '    Dim xmlDocR As New XmlDocument
            '    xmlDocR.Load("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\R-" & Session.sRucEmp & "-09-" & Documento & ".xml")
            '    'xmlDocR.Load("D:\Documentos_Electronicos\GuiaRemision_Electronicas\" & Documento & "\R-20100020441-09-" & Documento & ".xml")

            '    '/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
            '    Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDocR.NameTable)
            '    namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2")
            '    namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
            '    namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
            '    namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")
            '    namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")

            '    Dim notecompilado As String = ""
            '    Dim contador As Integer = 0
            '    Dim xnList As XmlNodeList = xmlDocR.SelectNodes("/ns:ApplicationResponse/cbc:Note", namespaces)
            '    For Each xn As XmlNode In xnList
            '        notecompilado = notecompilado & xnList.Item(contador).InnerText & ". " & Environment.NewLine
            '        contador = contador + 1
            '    Next
            '    Dim xPathString = "/ns:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:Description"
            '    Dim xPathString2 = "/ns:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:ResponseCode"
            '    Dim xPathString3 = "/ns:ApplicationResponse/cbc:ID"
            '    Dim xPathString4 = "/ns:ApplicationResponse/cac:DocumentResponse/cac:DocumentReference/cbc:DocumentDescription"
            '    Dim oNode = xmlDocR.SelectSingleNode(xPathString, namespaces)
            '    Dim oNode2 = xmlDocR.SelectSingleNode(xPathString2, namespaces)
            '    Dim oNode3 = xmlDocR.SelectSingleNode(xPathString3, namespaces)
            '    Dim oNode4 = xmlDocR.SelectSingleNode(xPathString4, namespaces)
            '    Dim Descripcioncdr As String = oNode.InnerText
            '    Dim Responsecode = oNode2.InnerText
            '    Dim NumTicket As String = oNode3.InnerText
            '    Dim UrlLink As String = oNode4.InnerText


            '    Dim registro As New GuiaRemisionDigitalService.GuiaRemisionDigital
            '    Dim guiaremision As New GuiaRemisionDigitalService.GuiaRemision

            '    registro.CDRxml = xmlDocR.OuterXml
            '    registro.CodUsu = Session.sCodUsu
            '    registro.DirIp = Session.sDirIp
            '    registro.DocumentoXml = Nothing
            '    registro.Estado = Responsecode
            '    guiaremision.IdGuia = pIdGuia
            '    registro.GuiaRemision = guiaremision
            '    registro.NombreXml = Nothing
            '    registro.NomPc = Session.sNomPc
            '    registro.NumTicket = NumTicket
            '    registro.Observacion = Descripcioncdr
            '    registro.Notas = toNull(notecompilado)
            '    registro.DocumentoPdf = Nothing
            '    registro.IdGuiaRef = Nothing
            '    registro.UrlLink = UrlLink
            '    insertar = oGuiaRemisionDigitalService.ActualizarProceso(registro)


            '    If insertar Then
            '        MsgBox("Se proceso la guia de remision electronica correctamente", MsgBoxStyle.Information)

            '        '//////////ENVIAR CORREO/////////
            '        Dim frm1 As New frmGuiaRemision_GuiaRemisionElectronica
            '        frm1.IdGuiaReg = pIdGuia
            '        frm1.Documento = Documento
            '        frm1.enProceso = True
            '        If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            '            listaDatos()
            '            RowPossesion(dgvDatos, pIdGuia)
            '        End If
            '        '////////////////////////////////
            '    End If


            'Else

            '    If respuestaTicket.codRespuesta = "99" Then 'ERROR

            '        MsgBox("Codigo Error: " + respuestaTicket.Error.numError + "     Descripcion: " + respuestaTicket.Error.desError, MsgBoxStyle.Information)

            '        oGuiaRemisionDigitalService.Borrar(pIdGuia, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            '        listaDatos()
            '        RowPossesion(dgvDatos, pIdGuia)
            '        Me.DialogResult = System.Windows.Forms.DialogResult.OK

            '    End If

            'End If




        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Actualizar Respuesta de Ticket")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub biEnviarCorreo_Click(sender As Object, e As EventArgs) Handles biEnviarCorreo.Click, miEnviarGuiaRemisionElectronica.Click

        If ValidaCodigoSeleccionado() Then
            Try

                Dim existefactelec As Boolean

                existefactelec = oGuiaRemisionDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdGuia").Text)

                If existefactelec = True Then


                    Dim dtImprimirDigital As New DataTable

                    dtImprimirDigital = oGuiaRemisionService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdGuia").Text).Tables(0)
                    GridEX2.DataSource = dtImprimirDigital

                    CodSerieFac = GridEX2.CurrentRow.Cells("CodSerie").Text
                    NumDocFac = GridEX2.CurrentRow.Cells("NumDoc").Text
                    IdClienteGuia = GridEX2.CurrentRow.Cells("IdCliente").Text

                    Dim frm As New frmGuiaRemision_GuiaRemisionElectronica_EnviarCorreo

                    frm.CodSerie = CodSerieFac
                    frm.NumDoc = NumDocFac
                    frm.IdGuia = dgvDatos.CurrentRow.Cells("IdGuia").Text
                    frm.IdCliente = IdClienteGuia
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    End If

                Else
                    MsgBox("No existe la guia de remision electronica, verifique.", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al enviar x correo")
            End Try
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
End Class