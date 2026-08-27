Imports System.ServiceModel
Imports LibreriaFacturacion
Imports System.Xml
Imports System.Text
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
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


Public Class frmFacturas
    Private oMaestroService As New MaestroService.MaestroClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oFacturaDetService As New FacturaDetalleService.FacturaDetalleServiceClient
    Private oFacturaDigitalService As New FacturaDigitalService.FacturaDigitalServiceClient
    Private oComunicacionBajaDigitalService As New ComunicacionBajaDigitalService.ComunicacionBajaDigitalServiceClient
    Private oValeMaterialService As New ValeMaterialService.ValeMaterialServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oContabilidad As New ContabilidadService.ContabilidadServiceClient
    Private oDocCtaCte As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private dtDatos As DataTable
    Private state_Search As Boolean
    Dim laprobacion As Boolean
    '====================================================================================================================
    '============================================ LOCAL PARAMETERS ======================================================
    '====================================================================================================================
    Private IdCliente As Integer
    Private Motivo As String
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable
    Private dtClientes As DataTable
    Private dtEstados As DataTable
    Private dtMeses As DataTable
    Private dtTipos As DataTable
    Private dtSerieFacturas As DataTable
    Private dtDetalles As DataTable
    Dim Cuenta As Boolean = False  '------PARA IMPRIMIR EN LA FACTURA LA CTA DEL BANCO A PAGAR
    Dim NombreXMLPDF As String = ""
    Dim UbicacionCodBarra As String
    '==================================== CAMPOS EVENTO DESCARGAR FACTURA ELECTRONICA
    Dim CodMot As String
    Dim LegalMonetaryTotal As Double
    Dim CurrencyId As String
    Dim TipoDoc As String
    Dim TaxAmount As Double
    Dim CodSerieFac As String
    Dim NumDocFac As String
    Dim DocumentoFac As String
    Dim IdClienteFac As Integer

    Dim FecDoc As Date
    Dim RucCli As String
    Dim RucEmp As String
    Dim CodMon As String

    Dim ValorResumen As String
    Dim ValorFirma As String

    Public OpcionImp As String      'Agregado para el cambio de Nro Cuenta   27-03-14
    Public MonedaImp As String      'Agregado para el cambio de Nro Cuenta  27-03-14
    Dim NumDoc As String

    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
                      , cmbSerieFactura.KeyPress _
                      , cmbMes.KeyPress _
                      , cmbTipFac.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub dgvDatos_GetChildList(sender As Object, e As Janus.Windows.GridEX.GetChildListEventArgs) Handles dgvDatos.GetChildList

    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                Mostrar_Click(sender, e)
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()
        End If
    End Sub
    Private Sub Salir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                         txtNumDoc.KeyPress _
                      , cmbOficinas.KeyPress _
                      , cmbIdLocacion.KeyPress _
                      , cmbEstado.KeyPress _
                      , txtanio.KeyPress _
                      , txtIdCliente.KeyPress _
                      , cmbSerieFactura.KeyPress _
                      , cmbMes.KeyPress _
                      , btnBuscar.KeyPress _
                      , cmbTipFac.KeyPress
        ', dgvDatos.KeyPress _
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
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
    Private Sub frmFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                If CInt(row.Cells("IdFactura").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 17)
        '/*************************************************************************************/

        chkCliente.Enabled = False
        pboxLimpiarCliente.Enabled = True
        ToolTip1.SetToolTip(chkCliente, "Limpiar Cliente")
        ToolTip1.SetToolTip(pboxLimpiarCliente, "Limpiar Cliente")

        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
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
        'Try
        '    If isClosed(oMaestroService) = False Then
        '        oMaestroService.Close()
        '    End If
        '    If isClosed(oFacturaService) = False Then
        '        oFacturaService.Close()
        '    End If
        'Catch ex As Exception
        '    MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

        Try
            oMaestroService.Close()
            oFacturaService.Close()
            oFacturaDetService.Close()
            oFacturaDigitalService.Close()
            oComunicacionBajaDigitalService.Close()
            oValeMaterialService.Close()
            oSeguridadService.Close()
            oContabilidad.Close()
            oDocCtaCte.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oFacturaService.Abort()
            oFacturaDetService.Abort()
            oFacturaDigitalService.Abort()
            oComunicacionBajaDigitalService.Abort()
            oValeMaterialService.Abort()
            oSeguridadService.Abort()
            oContabilidad.Abort()
            oDocCtaCte.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oFacturaService.Abort()
            oFacturaDetService.Abort()
            oFacturaDigitalService.Abort()
            oComunicacionBajaDigitalService.Abort()
            oValeMaterialService.Abort()
            oSeguridadService.Abort()
            oContabilidad.Abort()
            oDocCtaCte.Abort()
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
            biEnviar.Enabled = False
            biB2Mining.Enabled = False
            biMostrar.Enabled = False
            biEliminar.Enabled = False
            biAnular.Enabled = False
            biSugerir.Enabled = False
            biConsultarSugerido.Enabled = False
            biActualizarLocacion.Enabled = False
            biCuotas.Enabled = False
            biGenerarNotaCredito.Enabled = False
            'Se comenta ya que ahora se permitira generar una F/ partir de una liquidación en cualquier almacen 19/05/2021 Cesar Cueto
            'If cmbIdLocacion.DropDownList.GetRow.Cells(2).Text = "003" Or cmbIdLocacion.DropDownList.GetRow.Cells(2).Text = "009" Then
            biFacturarJob.Enabled = True
            miFacturarJob.Enabled = True
            'Else
            '    biFacturarJob.Enabled = False
            '    miFacturarJob.Enabled = False
            'End If


            ' biFacturarJob.Enabled = False
            biEstados.Enabled = False

            miImprimir.Enabled = False
            miTicket.Enabled = False
            miEnviar.Enabled = False
            miB2Mining.Enabled = False
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miAnular.Enabled = False
            miSugerir.Enabled = False
            miEstados.Enabled = False
            miConsultarSugerido.Enabled = False
            miActualizarLocacion.Enabled = False
            'miFacturarJob.Enabled = False
            miGenerarAsiento.Enabled = False
            miVerAsiento.Enabled = False
            miCuotas.Enabled = False
            miGenerarNotaCredito.Enabled = False
        Else
            Dim lEstado As String
            Dim lTotal As Decimal
            Dim lIdSugerido As Integer
            'Dim IBuscarGuia As Boolean

            lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
            lTotal = dgvDatos.CurrentRow.Cells("TotNeto").Value
            lIdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Value

            biImprimir.Enabled = IIf(lEstado = "AN" Or lIdSugerido > 0, False, True)
            biTicket.Enabled = IIf(lEstado = "AN", False, True)
            biEnviar.Enabled = IIf(lEstado = "GN" And (lTotal > 0 Or lIdSugerido > 0), True, False)
            biB2Mining.Enabled = False
            biMostrar.Enabled = IIf(lEstado = "AN", False, True)
            biEliminar.Enabled = IIf(lEstado = "GN" Or lEstado = "AP", True, False)
            biAnular.Enabled = IIf(lEstado = "IM", True, False)
            'biBajarnivel.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12"), True, False)
            biBajarnivel.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05") And (lEstado = "IM"), True, False)  '------ Se agrega el Perfil de Costos 02/08/2016

            'Se comento segun Solicitud de Usuario 3451
            'IBuscarGuia = oFacturaService.BuscarGuia(dgvDatos.CurrentRow.Cells("IdFactura").Text)
            'If IBuscarGuia = True Then
            '    biSugerir.Enabled = False
            'Else
            biSugerir.Enabled = IIf((lEstado = "GN" Or lEstado = "AP") And lTotal > 0 And dgvDatos.CurrentRow.Cells("Aprobar").Text = True, True, False)
            'End If
            'biFacturarJob.Enabled = IIf(lEstado = "GN" And (cmbIdLocacion.Value = "3" Or cmbIdLocacion.Value = "16"), True, False)
            biEstados.Enabled = True
            biCuotas.Enabled = IIf(lEstado = "IM" Or lEstado = "AN", False, True)
            biGenerarNotaCredito.Enabled = If(lEstado = "IM", True, False)

            miImprimir.Enabled = IIf(lEstado = "AN" Or lIdSugerido > 0, False, True)
            miTicket.Enabled = IIf(lEstado = "AN", False, True)
            miEnviar.Enabled = IIf(lEstado = "GN" And (lTotal > 0 Or lIdSugerido > 0), True, False)
            miB2Mining.Enabled = False
            miMostrar.Enabled = IIf(lEstado = "AN", False, True)
            miEliminar.Enabled = IIf(lEstado = "GN" Or lEstado = "AP", True, False)
            miAnular.Enabled = IIf(lEstado = "IM", True, False)
            'miBajarNivel.Visible = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12"), True, False)
            miBajarNivel.Enabled = IIf((Session.CodPerfil = "01" Or Session.CodPerfil = "42" Or Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05") And (lEstado = "IM"), True, False)  '------ Se agrega el Perfil de Costos 02/08/2016

            'Se comento segun Solicitud de Usuario 3451
            'If IBuscarGuia = True Then
            '    miSugerir.Enabled = False
            'Else
            miSugerir.Enabled = IIf((lEstado = "GN" Or lEstado = "AP") And lTotal > 0 And dgvDatos.CurrentRow.Cells("Aprobar").Text = True, True, False)
            'End If
            miEstados.Enabled = True
            'miFacturarJob.Enabled = IIf(lEstado = "GN" And (cmbIdLocacion.Value = "3" Or cmbIdLocacion.Value = "16"), True, False)


            'Se comenta ya que ahora se permitira generar una F/ partir de una liquidación en cualquier almacen 19/05/2021 Cesar Cueto
            'If cmbIdLocacion.DropDownList.GetRow.Cells(2).Text = "003" Or cmbIdLocacion.DropDownList.GetRow.Cells(2).Text = "009" Then
            biFacturarJob.Enabled = True
            miFacturarJob.Enabled = True
            'Else
            '    biFacturarJob.Enabled = False
            '    miFacturarJob.Enabled = False
            'End If

            If Session.CodPerfil = "14" Or Session.CodPerfil = "11" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05" Then   '------ Se agrega el Perfil de Costos 02/08/2016
                miActualizarLocacion.Enabled = True
                biActualizarLocacion.Enabled = True
            Else
                miActualizarLocacion.Enabled = False
                biActualizarLocacion.Enabled = False
            End If

            miGenerarAsiento.Enabled = True
            miVerAsiento.Enabled = True
            miCuotas.Enabled = IIf(lEstado = "IM", False, True)
            miGenerarNotaCredito.Enabled = If(lEstado = "IM", True, False)

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
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells("IdFactura").Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub listaDatos()
        'Try
        '    If state_Search = True Then
        '        dtDatos = oFacturaService.Filtrar(txtanio.Value _
        '                                             , cmbMes.Value _
        '                                             , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
        '                                             , toBlank(cmbTipFac.Value) _
        '                                             , toNumber(IdCliente) _
        '                                             , cmbEstado.Value _
        '                                             , toNumber(txtNumDoc.Text)).Tables(0)
        '        dgvDatos.SetDataBinding(dtDatos, 0)

        '        sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
        '        enableOpciones()
        '    End If
        '    'Catch ex As TimeoutException
        '    '    MsgBox("El tiempo de Inactividad a superado el tiempo permitido, vuelva a ingresar a la ventana", MsgBoxStyle.Information, "Lo Sentimos")
        '    'Catch ex As CommunicationException
        '    '    MsgBox("Existe Problemas de comunicacion, comuniquese con el administrador del sistema", MsgBoxStyle.Information, "No hay Comunicacion")
        'Catch ex As Exception
        '    MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        'End Try

        Try
            If state_Search = True Then
                dtDatos = oFacturaService.Filtrar(txtanio.Value _
                                                     , cmbMes.Value _
                                                     , IIf(toNumber(cmbIdLocacion.Value) = 0, -1, cmbIdLocacion.Value) _
                                                     , toBlank(cmbTipFac.Value) _
                                                     , toNumber(cmbSerieFactura.Value) _
                                                     , toNumber(IdCliente) _
                                                     , cmbEstado.Value _
                                                     , toNumber(txtNumDoc.Text)).Tables(0)
                dgvDatos.SetDataBinding(dtDatos, 0)
                'DataGridView1.DataSource = dtDatos

                sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
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
            dtEstados = oFacturaService.MostrarEstados
            dtEstados.Rows.InsertAt(getRowTodos(dtEstados), 0)
            cmbEstado.DataSource = dtEstados
            cmbEstado.DropDownList.DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.DisplayMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.DropDownList.ValueMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(0).DataMember = dtEstados.Columns("Estado").ToString
            cmbEstado.DropDownList.Columns(1).DataMember = dtEstados.Columns("Descripcion").ToString
            cmbEstado.SelectedIndex = 0
            dtEstados = Nothing
            '======================================= ESTADOS ================================================
            dtSerieFacturas = oFacturaService.MostrarSerieFacturas(Session.sCodEmp).Tables(0)
            dtSerieFacturas.Rows.InsertAt(getRowTodos1(dtSerieFacturas), 0)
            cmbSerieFactura.DataSource = dtSerieFacturas
            cmbSerieFactura.DropDownList.DataMember = dtSerieFacturas.Columns("Descripcion").ToString
            cmbSerieFactura.DropDownList.DisplayMember = dtSerieFacturas.Columns("Descripcion").ToString
            cmbSerieFactura.DropDownList.ValueMember = dtSerieFacturas.Columns("IdSerieDoc").ToString
            cmbSerieFactura.DropDownList.Columns(0).DataMember = dtSerieFacturas.Columns("IdSerieDoc").ToString
            cmbSerieFactura.DropDownList.Columns(1).DataMember = dtSerieFacturas.Columns("CodSerie").ToString
            cmbSerieFactura.DropDownList.Columns(2).DataMember = dtSerieFacturas.Columns("Descripcion").ToString
            cmbSerieFactura.SelectedIndex = 0
            dtSerieFacturas = Nothing
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

            dtTipos = oFacturaService.MostrarTipo(Session.sCodUsu)
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

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Todos)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = 0
        Catch ex As Exception
            fila(2) = 0
        End Try
        Try
            fila(2) = "(Todos)"
        Catch ex As Exception
            fila(3) = 0
        End Try
        Try
            fila(3) = "(Todos)"
        Catch ex As Exception
            fila(4) = 0
        End Try
        Try
            fila(4) = "(Todos)"
        Catch ex As Exception
            fila(5) = 0
        End Try
        Return fila
    End Function

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        Mostrar_Click(sender, e)
    End Sub
    Private Sub dgvDatos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        enableOpciones()
    End Sub
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDatos()
    End Sub
    Private Sub EjecutaCombos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                    cmbIdLocacion.ValueChanged _
                  , cmbEstado.ValueChanged _
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
            'dtAlmacenes = Nothing
        Else
            cmbIdLocacion.Value = ""
        End If
    End Sub
    Private Sub cmbIdLocacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIdLocacion.ValueChanged
        If dtAlmacenes.Rows.Count > 0 Then
            laprobacion = dtAlmacenes.Rows(cmbIdLocacion.SelectedIndex).Item("AproDoc")
        Else
            laprobacion = False
        End If
        listaDatos()
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
    'Private Sub txtIdCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim frm As New frmBuscarCliente
    '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '        If toNull(frm.codigo) <> Nothing Then
    '            chkCliente.Checked = False
    '            txtIdCliente.Text = frm.descripcion
    '            IdCliente = frm.codigo
    '        Else
    '            txtIdCliente.Text = "(Todos)"
    '            IdCliente = 0
    '        End If
    '        listaDatos()
    '    End If
    'End Sub
    Private Sub Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.Click, miImprimir.Click
        If Session.sCodEmp = "03" Then
            ImpresionCairo()
        Else
            Impresion()
        End If
    End Sub
    Private Sub ImpresionCairo()
        Try
            If ValidaCodigoSeleccionado() Then
                Dim forma As New frmReportes
                Dim reporte As New rpImprimirFacturaCairo

                Dim dtReporte As New DataTable
                Dim dtDetalles As New DataTable
                Dim IdFactura As Integer = dgvDatos.CurrentRow.Cells("IdFactura").Text
                Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Value
                Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
                Dim TipoCambio As Decimal
                Dim TotNeto As Decimal
                Dim Igv As String

                Dim Detalles As Integer
                Dim A() As String
                Dim registro As FacturaService.Factura
                registro = oFacturaService.MostrarPorId(IdFactura)
                txtObservacion.Text = toBlank(registro.Observacion)
                A = Split(txtObservacion.Text, vbCrLf, -1, vbTextCompare)
                Detalles = dtDetalles.Rows.Count

                dtReporte = oFacturaService.Imprimir(IdFactura).Tables(0)
                dtDetalles = oFacturaDetService.Mostrar(toNumber(IdFactura)).Tables(0)
                TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
                TotNeto = Math.Round(dgvDatos.CurrentRow.Cells("TotNeto").Value, 2)
                Igv = registro.Igv
                '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                If (UBound(A) + 1) + Detalles > 26 Then
                    MsgBox("No puede imprimir por exceso de líneas,Verificar")
                Else

                    If dtReporte.Rows.Count = 0 Then
                        MsgBox("No hay datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
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

                            forma.Text = "Imprimir Factura"

                            'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                            'dtReporte.WriteXmlSchema("C:\Factura.xml")
                            reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                            reporte.SetParameterValue("Igv", "\ " & Igv & "%")

                            '-------------------------------Se comenta para que imprima solo una hoja------------------------------------
                            'Dim i As Integer
                            'For i = 0 To 1
                            '    If i = 1 Then
                            '        Select Case CodMon
                            '            Case "US"
                            '                reporte.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                            '            Case "EU"
                            '                reporte.SetParameterValue("TotalSoles", "")
                            '            Case "NS"
                            '                reporte.SetParameterValue("TotalSoles", "")
                            '        End Select
                            '        reporte.PrintOptions.PrinterName = Impresora
                            '        reporte.PrintToPrinter(1, False, 0, 0)
                            '        GoTo 3
                            '    ElseIf i = 0 Then
                            '        Select Case CodMon
                            '            Case "US"
                            '                reporte.SetParameterValue("TotalSoles", "")
                            '            Case "EU"
                            '                reporte.SetParameterValue("TotalSoles", "")
                            '            Case "NS"
                            '                reporte.SetParameterValue("TotalSoles", "")
                            '        End Select
                            '        reporte.PrintOptions.PrinterName = Impresora
                            '        reporte.PrintToPrinter(1, False, 0, 0)
                            '    End If
                            'Next
                            '3:                          oFacturaService.ActualizarEstadoImpreso(IdFactura, Session.sCodUsu)
                            'oFacturaService.ActualizarEstadoImpreso(IdFactura, Session.sCodUsu) '---Se agre
                            'actualizar()
                            '----------------------------------------------------------------------------------------------------------------------
                            Select Case CodMon
                                Case "US"
                                    reporte.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Format(Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero), "#,0.00"))
                                Case "EU"
                                    reporte.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Euro = S/. " & Format(Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero), "#,0.00"))
                                Case "NS"
                                    reporte.SetParameterValue("TotalSoles", "")
                            End Select
                            reporte.PrintOptions.PrinterName = Impresora
                            reporte.PrintToPrinter(1, False, 0, 0)
                            If Session.sCodEmp <> "01" Then
                                oFacturaService.ActualizarEstadoImpreso(IdFactura, Session.sCodUsu) '---Se agre
                            End If
                            actualizar()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try
    End Sub
    Private Sub Impresion()
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está Seguro de IMPRIMIR la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                    Dim frm As New frmFactura_Imprimir
                    Dim registro As New FacturaService.Factura
                    registro = oFacturaService.MostrarPorId(dgvDatos.CurrentRow.Cells("IdFactura").Text)
                    Motivo = registro.Motivos.CodMot
                    'Comentado por Mateu solamente Locacion Servicios, Equipos y Garantia Servicios tendran la opcion de resumen
                    'Solicitud de Usuario 3948 de Angelica Vega
                    ''If oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) = "003" Then
                    If Not (oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) <> "003" And oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) <> "004" And oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) <> "067" And oMaestroService.MostrarDato("SIGECOM.Maestro.Locaciones", "CodAlm", "IdLocacion", cmbIdLocacion.Value) <> "009") Then
                        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                            Cuenta = frm.cbMostrarMensaje.Checked
                            If frm.Imprimir = True Then
                                ''Imprimir_Detalle()
                                If frm.cbMostrarNroCuenta.Checked Then
                                    OpcionImp = "1"
                                    MonedaImp = frm.Moneda
                                Else
                                    OpcionImp = "0"
                                End If
                                ImprimirDetalleNroCta()
                            Else

                                Dim forma As New frmReportes
                                Dim reporte As New rpImprimirFacturaServicios
                                Dim reporteAct As New rpImprimirFacturaActServicios
                                Dim dtReporte As New DataTable
                                Dim dtDetalles As New DataTable
                                Dim IdFactura As Integer = dgvDatos.CurrentRow.Cells("IdFactura").Text
                                Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Text
                                Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
                                Dim TipoCambio As Decimal
                                Dim TotNeto As Decimal
                                Dim Igv As String

                                Dim Opcion As String
                                Dim MonedaRep As String

                                If frm.cbMostrarNroCuenta.Checked Then
                                    Opcion = "1"
                                    MonedaRep = frm.Moneda
                                Else
                                    Opcion = "0"
                                End If

                                dtReporte = oFacturaService.Imprimir(IdFactura).Tables(0)
                                dtDetalles = oFacturaDetService.Mostrar(toNumber(IdFactura)).Tables(0)
                                TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
                                Igv = registro.Igv

                                TotNeto = dgvDatos.CurrentRow.Cells("TotNeto").Text
                                '/////////////////////////////////////////////////////////////////////////////
                                Dim Detalles As Integer
                                Dim A() As String

                                txtObservacion.Text = toBlank(registro.Observacion)
                                A = Split(txtObservacion.Text, vbCrLf, -1, vbTextCompare)
                                Detalles = dtDetalles.Rows.Count
                                If (UBound(A) + 1) + Detalles > 26 Then
                                    MsgBox("No puede imprimir por exceso de líneas,Verificar")
                                Else
                                    If dtReporte.Rows.Count = 0 Then
                                        MsgBox("No hay datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                                    Else
                                        Dim Impresora As String = SeleccionarImpresora()
                                        ' If cmbOficinas.Value <> "02" Then ----------------------------Comentado por Oficina Chimbote
                                        If Impresora <> "" Then
                                            reporteAct.SetDataSource(dtReporte)
                                            forma.crvReportes.ReportSource = reporteAct

                                            If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                                                forma.crvReportes.ShowExportButton = True
                                            Else
                                                forma.crvReportes.ShowExportButton = False
                                            End If
                                            'forma.crvReportes.RefreshReport = False
                                            'forma.crvReportes.DisplayGroupTree = False

                                            forma.Text = "Imprimir Factura"

                                            'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                            'dtReporte.WriteXmlSchema("C:\Factura.xml")
                                            reporteAct.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                                            reporteAct.SetParameterValue("Transferencia", IIf(registro.Motivos.CodMot = "2", "TRANSFERENCIA GRATUITA", ""))
                                            reporteAct.SetParameterValue("TotTran", IIf(registro.Motivos.CodMot = "2", "0.00", ""))
                                            reporteAct.SetParameterValue("Igv", " " & Igv & "%")
                                            'Se saco el signo de \ por pedido de avega
                                            'reporteAct.SetParameterValue("Igv", "\ " & Igv & "%")
                                            reporteAct.SetParameterValue("Cuenta", Cuenta)

                                            'agregada para ver el cambio de Nro Cuenta 27-04-14
                                            If Opcion = 1 And MonedaRep = "NS" Then
                                                'reporteAct.SetParameterValue("NroCuenta", "Nº Cta. Cte. BCP en Soles 191-0715400-0-62")
                                                'Cambio pedido por angelica 04-11-14
                                                reporteAct.SetParameterValue("NroCuenta", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18")
                                            ElseIf Opcion = 1 And MonedaRep = "US" Then
                                                'reporteAct.SetParameterValue("NroCuenta", "Nº Cta. Cte. BCP en Dólares 191-0735547-1-76")
                                                'Cambio pedido por angelica 04-11-14
                                                reporteAct.SetParameterValue("NroCuenta", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57")
                                            ElseIf Opcion = 0 Then
                                                reporteAct.SetParameterValue("NroCuenta", "")
                                            End If

                                            Dim i As Integer

                                            For i = 0 To 1
                                                If i = 1 Then
                                                    Select Case CodMon
                                                        Case "US"
                                                            reporteAct.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Format(Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero), "#,0.00"))
                                                        Case "EU"
                                                            reporteAct.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Euro = S/. " & Format(Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero), "#,0.00"))
                                                        Case "NS"
                                                            reporteAct.SetParameterValue("TotalSoles", "")
                                                    End Select
                                                    reporteAct.PrintOptions.PrinterName = Impresora
                                                    reporteAct.PrintToPrinter(1, False, 0, 0)
                                                    GoTo 2
                                                ElseIf i = 0 Then
                                                    Select Case CodMon
                                                        Case "US"
                                                            reporteAct.SetParameterValue("TotalSoles", "")
                                                        Case "EU"
                                                            reporteAct.SetParameterValue("TotalSoles", "")
                                                        Case "NS"
                                                            reporteAct.SetParameterValue("TotalSoles", "")
                                                    End Select
                                                    reporteAct.PrintOptions.PrinterName = Impresora
                                                    reporteAct.PrintToPrinter(1, False, 0, 0)
                                                End If
                                            Next
2:                                          If Session.sCodEmp <> "01" Then
                                                oFacturaService.ActualizarEstadoImpreso(IdFactura, Session.sCodUsu)
                                            End If
                                            actualizar()
                                        End If
                                        '----------------------------Comentado por Oficina Chimbote
                                        ' Else
                                        '                                        If Impresora <> "" Then
                                        '                                            reporte.SetDataSource(dtReporte)
                                        '                                            forma.crvReportes.ReportSource = reporte
                                        '                                            forma.crvReportes.DisplayGroupTree = False
                                        '                                            'forma.crvReportes.RefreshReport = False
                                        '                                            forma.Text = "Imprimir Factura"

                                        '                                            'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                                        '                                            'dtReporte.WriteXmlSchema("C:\Factura.xml")
                                        '                                            reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                                        '                                            reporte.SetParameterValue("Igv", "\ " & Igv & "%")
                                        '                                            reporte.SetParameterValue("Cuenta", Cuenta)
                                        '                                            Dim i As Integer

                                        '                                            For i = 0 To 1
                                        '                                                If i = 1 Then
                                        '                                                    Select Case CodMon
                                        '                                                        Case "US"
                                        '                                                            reporte.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                                        '                                                        Case "EU"
                                        '                                                            reporte.SetParameterValue("TotalSoles", "")
                                        '                                                        Case "NS"
                                        '                                                            reporte.SetParameterValue("TotalSoles", "")
                                        '                                                    End Select
                                        '                                                    reporte.PrintOptions.PrinterName = Impresora
                                        '                                                    reporte.PrintToPrinter(1, False, 0, 0)
                                        '                                                    GoTo 3
                                        '                                                ElseIf i = 0 Then
                                        '                                                    Select Case CodMon
                                        '                                                        Case "US"
                                        '                                                            reporte.SetParameterValue("TotalSoles", "")
                                        '                                                        Case "EU"
                                        '                                                            reporte.SetParameterValue("TotalSoles", "")
                                        '                                                        Case "NS"
                                        '                                                            reporte.SetParameterValue("TotalSoles", "")
                                        '                                                    End Select
                                        '                                                    reporte.PrintOptions.PrinterName = Impresora
                                        '                                                    reporte.PrintToPrinter(1, False, 0, 0)
                                        '                                                End If
                                        '                                            Next
                                        '3:                                          oFacturaService.ActualizarEstadoImpreso(IdFactura, Session.sCodUsu)
                                        '                                            actualizar()
                                        '                                        End If

                                        '                                    End If
                                        '----------------------------Comentado por Oficina Chimbote
                                    End If
                                End If
                            End If
                        End If
                    Else
                        Imprimir_Detalle()
                    End If

                Else
                    Cuenta = False
                    dgvDatos.Focus()
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try

        End If
    End Sub
    Private Sub Imprimir_Detalle()
        Try
            Dim Opcion As String
            Dim MonedaRep As String

            If cmbTipFac.Value = "1" Then
                'comentado lo de abajo porque solo sera necesario el tipfactura 1
                ''If cmbOficinas.Value = "01" And cmbTipFac.Value = "1" And (cmbIdLocacion.Value <> 3 And cmbIdLocacion.Value <> 4) Then
                Dim frm As New frmFactura_Electronica
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    If frm.state = True Then

                        If frm.cbMostrarNroCuenta.Checked Then
                            Opcion = "1"
                            MonedaRep = frm.Moneda
                        Else
                            Opcion = "0"
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                Opcion = "0"
            End If

            Dim forma As New frmReportes
            Dim reporte As New rpImprimirFactura
            Dim reporteAct As New rpImprimirFacturaAct
            Dim dtReporte As New DataTable
            Dim dtDetalles As New DataTable
            Dim IdFactura As Integer = dgvDatos.CurrentRow.Cells("IdFactura").Text
            Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Value
            Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
            Dim TipoCambio As Decimal
            Dim TotNeto As Decimal
            Dim Igv As String

            Dim Detalles As Integer
            Dim A() As String
            Dim registro As FacturaService.Factura
            registro = oFacturaService.MostrarPorId(IdFactura)
            txtObservacion.Text = toBlank(registro.Observacion)
            A = Split(txtObservacion.Text, vbCrLf, -1, vbTextCompare)
            Detalles = dtDetalles.Rows.Count

            dtReporte = oFacturaService.Imprimir(IdFactura).Tables(0)
            dtDetalles = oFacturaDetService.Mostrar(toNumber(IdFactura)).Tables(0)
            TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
            TotNeto = Math.Round(dgvDatos.CurrentRow.Cells("TotNeto").Value, 2)
            Igv = registro.Igv
            '/////////////////////////////////////////////////////////////////////////////

            If (UBound(A) + 1) + Detalles > 26 Then
                MsgBox("No puede imprimir por exceso de líneas,Verificar")
            Else

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    Dim Impresora As String = SeleccionarImpresora()
                    ' If cmbOficinas.Value <> "02" Then----------------------------Comentado por Oficina Chimbote
                    If Impresora <> "" Then
                        reporteAct.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteAct

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        'forma.crvReportes.RefreshReport = False
                        forma.Text = "Imprimir Factura"

                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                        'dtReporte.WriteXmlSchema("C:\Factura.xml")
                        reporteAct.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                        reporteAct.SetParameterValue("Transferencia", IIf(registro.Motivos.CodMot = "2", "TRANSFERENCIA GRATUITA", ""))
                        reporteAct.SetParameterValue("TotTran", IIf(registro.Motivos.CodMot = "2", "0.00", ""))
                        reporteAct.SetParameterValue("Igv", " " & Igv & "%")
                        'Se saco el signo de \ por pedido de avega
                        'reporteAct.SetParameterValue("Igv", "\ " & Igv & "%")
                        reporteAct.SetParameterValue("Cuenta", Cuenta)

                        'agregada para ver el cambio de Nro Cuenta 27-04-14
                        If Opcion = 1 And MonedaRep = "NS" Then
                            reporteAct.SetParameterValue("NroCuenta", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18")
                        ElseIf Opcion = 1 And MonedaRep = "US" Then
                            reporteAct.SetParameterValue("NroCuenta", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57")
                        ElseIf Opcion = 0 Then
                            reporteAct.SetParameterValue("NroCuenta", "")
                        End If

                        Dim i As Integer

                        For i = 0 To 1
                            If i = 1 Then
                                Select Case CodMon
                                    Case "US"
                                        reporteAct.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Format(Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero), "#,0.00"))
                                    Case "EU"
                                        reporteAct.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Euro = S/. " & Format(Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero), "#,0.00"))
                                    Case "NS"
                                        reporteAct.SetParameterValue("TotalSoles", "")
                                End Select
                                reporteAct.PrintOptions.PrinterName = Impresora
                                reporteAct.PrintToPrinter(1, False, 0, 0)
                                GoTo 2
                            ElseIf i = 0 Then
                                Select Case CodMon
                                    Case "US"
                                        reporteAct.SetParameterValue("TotalSoles", "")
                                    Case "EU"
                                        reporteAct.SetParameterValue("TotalSoles", "")
                                    Case "NS"
                                        reporteAct.SetParameterValue("TotalSoles", "")
                                End Select
                                reporteAct.PrintOptions.PrinterName = Impresora
                                reporteAct.PrintToPrinter(1, False, 0, 0)
                            End If
                        Next
2:                      If Session.sCodEmp <> "01" Then
                            oFacturaService.ActualizarEstadoImpreso(IdFactura, Session.sCodUsu)
                        End If
                        actualizar()
                    End If
                    '-------------------------------------------------------------Comentado por Oficina Chimbote
                    'Else
                    '                    If Impresora <> "" Then
                    '                        reporte.SetDataSource(dtReporte)
                    '                        forma.crvReportes.ReportSource = reporte
                    '                        forma.crvReportes.DisplayGroupTree = False
                    '                        'forma.crvReportes.RefreshReport = False
                    '                        forma.Text = "Imprimir Factura"

                    '                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    '                        'dtReporte.WriteXmlSchema("C:\Factura.xml")
                    '                        reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                    '                        reporte.SetParameterValue("Igv", "\ " & Igv & "%")
                    '                        reporte.SetParameterValue("Cuenta", Cuenta)

                    '                        Dim i As Integer

                    '                        For i = 0 To 1
                    '                            If i = 1 Then
                    '                                Select Case CodMon
                    '                                    Case "US"
                    '                                        reporte.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                    '                                    Case "EU"
                    '                                        reporte.SetParameterValue("TotalSoles", "")
                    '                                    Case "NS"
                    '                                        reporte.SetParameterValue("TotalSoles", "")
                    '                                End Select
                    '                                reporte.PrintOptions.PrinterName = Impresora
                    '                                reporte.PrintToPrinter(1, False, 0, 0)
                    '                                GoTo 3
                    '                            ElseIf i = 0 Then
                    '                                Select Case CodMon
                    '                                    Case "US"
                    '                                        reporte.SetParameterValue("TotalSoles", "")
                    '                                    Case "EU"
                    '                                        reporte.SetParameterValue("TotalSoles", "")
                    '                                    Case "NS"
                    '                                        reporte.SetParameterValue("TotalSoles", "")
                    '                                End Select
                    '                                reporte.PrintOptions.PrinterName = Impresora
                    '                                reporte.PrintToPrinter(1, False, 0, 0)
                    '                            End If
                    '                        Next
                    '                        Cuenta = False
                    '3:                      oFacturaService.ActualizarEstadoImpreso(IdFactura, Session.sCodUsu)
                    '                        actualizar()
                    '                    End If

                    '                End If
                    '----------------------------Comentado por Oficina Chimbote
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    'Toda esta funcion agregada para ver el cambio de Nro Cuenta 27-04-14
    Private Sub ImprimirDetalleNroCta()

        Try
            Dim Opcion As String
            Dim MonedaRep As String

            If cmbTipFac.Value = "1" Then

                Opcion = OpcionImp
                MonedaRep = MonedaImp
            Else
                Opcion = "0"
            End If

            Dim forma As New frmReportes
            Dim reporte As New rpImprimirFactura
            Dim reporteAct As New rpImprimirFacturaAct
            Dim dtReporte As New DataTable
            Dim dtDetalles As New DataTable
            Dim IdFactura As Integer = dgvDatos.CurrentRow.Cells("IdFactura").Text
            Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Value
            Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
            Dim TipoCambio As Decimal
            Dim TotNeto As Decimal
            Dim Igv As String

            Dim Detalles As Integer
            Dim A() As String
            Dim registro As FacturaService.Factura
            registro = oFacturaService.MostrarPorId(IdFactura)
            txtObservacion.Text = toBlank(registro.Observacion)
            A = Split(txtObservacion.Text, vbCrLf, -1, vbTextCompare)
            Detalles = dtDetalles.Rows.Count

            dtReporte = oFacturaService.Imprimir(IdFactura).Tables(0)
            dtDetalles = oFacturaDetService.Mostrar(toNumber(IdFactura)).Tables(0)
            TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
            TotNeto = Math.Round(dgvDatos.CurrentRow.Cells("TotNeto").Value, 2)
            Igv = registro.Igv
            '/////////////////////////////////////////////////////////////////////////////

            If (UBound(A) + 1) + Detalles > 26 Then
                MsgBox("No puede imprimir por exceso de líneas,Verificar")
            Else

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos que mostrar, verifique.!!!!!!", MsgBoxStyle.Information, "No hay datos")
                Else
                    Dim Impresora As String = SeleccionarImpresora()
                    ' If cmbOficinas.Value <> "02" Then----------------------------Comentado por Oficina Chimbote
                    If Impresora <> "" Then
                        reporteAct.SetDataSource(dtReporte)
                        forma.crvReportes.ReportSource = reporteAct

                        If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                            forma.crvReportes.ShowExportButton = True
                        Else
                            forma.crvReportes.ShowExportButton = False
                        End If
                        'forma.crvReportes.RefreshReport = False
                        'forma.crvReportes.DisplayGroupTree = False

                        'forma.crvReportes.RefreshReport = False
                        forma.Text = "Imprimir Factura"

                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                        'dtReporte.WriteXmlSchema("C:\Factura.xml")
                        reporteAct.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                        reporteAct.SetParameterValue("Transferencia", IIf(registro.Motivos.CodMot = "2", "TRANSFERENCIA GRATUITA", ""))
                        reporteAct.SetParameterValue("TotTran", IIf(registro.Motivos.CodMot = "2", "0.00", ""))
                        reporteAct.SetParameterValue("Igv", " " & Igv & "%")
                        'Se saco el signo de \ por pedido de avega
                        'reporteAct.SetParameterValue("Igv", "\ " & Igv & "%")
                        reporteAct.SetParameterValue("Cuenta", Cuenta)

                        If Opcion = 1 And MonedaRep = "NS" Then
                            reporteAct.SetParameterValue("NroCuenta", "Nº Cta. Cte. en Soles :  BCP 191-0715400-0-62  /  SCOTIABANK 00-001-103-0082-18")
                        ElseIf Opcion = 1 And MonedaRep = "US" Then
                            reporteAct.SetParameterValue("NroCuenta", "Nº Cta. Cte. en Dólares : BCP 191-0735547-1-76  /  SCOTIABANK 01-001-109-0261-57")
                        ElseIf Opcion = 0 Then
                            reporteAct.SetParameterValue("NroCuenta", "")
                        End If

                        Dim i As Integer

                        For i = 0 To 1
                            If i = 1 Then
                                Select Case CodMon
                                    Case "US"
                                        reporteAct.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Format(Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero), "#,0.00"))
                                    Case "EU"
                                        reporteAct.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Euro = S/. " & Format(Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero), "#,0.00"))
                                    Case "NS"
                                        reporteAct.SetParameterValue("TotalSoles", "")
                                End Select
                                reporteAct.PrintOptions.PrinterName = Impresora
                                reporteAct.PrintToPrinter(1, False, 0, 0)
                                GoTo 2
                            ElseIf i = 0 Then
                                Select Case CodMon
                                    Case "US"
                                        reporteAct.SetParameterValue("TotalSoles", "")
                                    Case "EU"
                                        reporteAct.SetParameterValue("TotalSoles", "")
                                    Case "NS"
                                        reporteAct.SetParameterValue("TotalSoles", "")
                                End Select
                                reporteAct.PrintOptions.PrinterName = Impresora
                                reporteAct.PrintToPrinter(1, False, 0, 0)
                            End If
                        Next
2:                      If Session.sCodEmp <> "01" Then
                            oFacturaService.ActualizarEstadoImpreso(IdFactura, Session.sCodUsu)
                        End If
                        actualizar()
                    End If
                    '-------------------------------------------------------------Comentado por Oficina Chimbote
                    'Else
                    '                    If Impresora <> "" Then
                    '                        reporte.SetDataSource(dtReporte)
                    '                        forma.crvReportes.ReportSource = reporte
                    '                        forma.crvReportes.DisplayGroupTree = False
                    '                        'forma.crvReportes.RefreshReport = False
                    '                        forma.Text = "Imprimir Factura"

                    '                        'ObjImportacion.ReporteFactura(dgFacturas.CurrentRow.Cells(0).Text).WriteXmlSchema("C:\Importaciones.xml")
                    '                        'dtReporte.WriteXmlSchema("C:\Factura.xml")
                    '                        reporte.SetParameterValue("NumeroLetra", oMaestroService.ConvierteNumLetra(dgvDatos.CurrentRow.Cells("TotNeto").Text, dgvDatos.CurrentRow.Cells("CodMon").Text))
                    '                        reporte.SetParameterValue("Igv", "\ " & Igv & "%")
                    '                        reporte.SetParameterValue("Cuenta", Cuenta)

                    '                        Dim i As Integer

                    '                        For i = 0 To 1
                    '                            If i = 1 Then
                    '                                Select Case CodMon
                    '                                    Case "US"
                    '                                        reporte.SetParameterValue("TotalSoles", "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero))
                    '                                    Case "EU"
                    '                                        reporte.SetParameterValue("TotalSoles", "")
                    '                                    Case "NS"
                    '                                        reporte.SetParameterValue("TotalSoles", "")
                    '                                End Select
                    '                                reporte.PrintOptions.PrinterName = Impresora
                    '                                reporte.PrintToPrinter(1, False, 0, 0)
                    '                                GoTo 3
                    '                            ElseIf i = 0 Then
                    '                                Select Case CodMon
                    '                                    Case "US"
                    '                                        reporte.SetParameterValue("TotalSoles", "")
                    '                                    Case "EU"
                    '                                        reporte.SetParameterValue("TotalSoles", "")
                    '                                    Case "NS"
                    '                                        reporte.SetParameterValue("TotalSoles", "")
                    '                                End Select
                    '                                reporte.PrintOptions.PrinterName = Impresora
                    '                                reporte.PrintToPrinter(1, False, 0, 0)
                    '                            End If
                    '                        Next
                    '                        Cuenta = False
                    '3:                      oFacturaService.ActualizarEstadoImpreso(IdFactura, Session.sCodUsu)
                    '                        actualizar()
                    '                    End If

                    '                End If
                    '----------------------------Comentado por Oficina Chimbote
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub Ticket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTicket.Click, miTicket.Click
        If ValidaCodigoSeleccionado() Then
            Try
                Dim forma As New frmReportes
                Dim reporte As New rpImprimirTicket
                Dim reporte1 As New rpImprimirTicketNuevo
                Dim reporte2 As New rpImprimirTicketNuevo2
                Dim dtReporte As New DataTable
                Dim IdFactura As Integer = dgvDatos.CurrentRow.Cells("IdFactura").Text

                dtReporte = oFacturaService.Imprimir(IdFactura).Tables(0)

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

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
            End Try
        End If
    End Sub
    Private Sub Enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.Click, miEnviar.Click
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está seguro de ENVIAR a Créditos la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString +
                          vbCrLf + "para su aprobación?", MsgBoxStyle.YesNo, "Enviar a Créditos") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oFacturaService.EnviarCreditos(dgvDatos.CurrentRow.Cells("IdFactura").Text, Session.sCodUsu)
                    If estado_process Then
                        Actualizar_Click(sender, e)
                        MsgBox("Se Envió a Créditos la Factura actual correctamente. !!!", MsgBoxStyle.Information, "Enviar a Créditos")
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical, "Enviar a Créditos")
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ENVIAR]:" + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub B2Mining_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biB2Mining.Click, miB2Mining.Click

    End Sub
    Private Sub Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.Click, miNuevo.Click
        Try
            'If oFacturaService.PermisoFactura(Session.sCodUsu, cmbTipFac.Value) = False Then
            '    MsgBox("No tiene Permiso para Facturar al " & cmbTipFac.Text, MsgBoxStyle.Information, "No tiene Permiso")
            '    Exit Sub
            'End If
            Dim frm As New frmFactura
            frm.state_button = False
            frm.IdLocacion = cmbIdLocacion.Value
            frm.TipFac = cmbTipFac.Value
            frm.txtNumDoc.Text = oFacturaService.SugerirNumero(cmbIdLocacion.Value, Session.sCodUsu)
            ' frm.txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", frm.IdLocacion))
            frm.lblLocacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text
            frm.Text = "Registrar Nueva Factura al " & cmbTipFac.Text
            frm.IdSugerido = 0
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ' limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text)
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdFactura)
                    Mostrar_Click(sender, e)
                    Actualizar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.Click, miMostrar.Click
        If ValidaCodigoSeleccionado() And dgvDatos.CurrentRow.Cells("Estado").Text <> "AN" Then
            Try
                Dim frm As New frmFactura
                Dim lEstado As String
                lEstado = dgvDatos.CurrentRow.Cells("Estado").Text
                frm.state_button = True
                frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
                frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Text
                frm.edicion = False
                frm.TipFac = cmbTipFac.Value
                frm.editable = IIf(lEstado = "GN" Or lEstado = "AP" Or lEstado = "CR", True, False)
                frm.lblLocacion.Text = "OFICINA: " & cmbOficinas.Text & "  -  ALMACEN: " & cmbIdLocacion.Text

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    If frm.type_process = "update" Then
                        ' limpiaOpcionesBusqueda("update", frm.txtNumDoc.Text)
                        listaDatos()
                        RowPossesion(dgvDatos, frm.IdFactura)
                    Else
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    End If
                End If
                Actualizar_Click(sender, e)
            Catch ex As Exception
                MsgBox("ERROR [LIST-001]: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.Click, miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            Try
                'If oFacturaService.PermisoFactura(Session.sCodUsu, cmbTipFac.Value) = False Then
                '    MsgBox("No tiene Permiso para eliminar esta documento", MsgBoxStyle.Information, "No tiene Permiso")
                '    Exit Sub
                'End If

                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ELIMINAR la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    estado_process = oFacturaService.Borrar(dgvDatos.CurrentRow.Cells("IdFactura").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                    If estado_process = True Then
                        'dtDatos = Nothing
                        listaDatos()
                        'Actualizar_Click(sender, e)
                        MsgBox("Se Eliminó la Factura actual correctamente. !!!", MsgBoxStyle.Information, "Eliminar")
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical, "Eliminar")
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ELIMINAR]:" + ex.Message, MsgBoxStyle.Exclamation, "Eliminar")
            End Try
        End If
    End Sub
    Private Sub Anular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.Click, miAnular.Click
        If ValidaCodigoSeleccionado() Then
            Try
                '    If oFacturaService.PermisoFactura(Session.sCodUsu, cmbTipFac.Value) = False Then
                '        MsgBox("No tiene Permiso para anular esta documento", MsgBoxStyle.Information, "No tiene Permiso")
                '        Exit Sub
                '    End If

                cmOpciones.Visible = False
                If MsgBox("¿Está seguro de ANULAR la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + " ?", MsgBoxStyle.YesNo, "Anular") = MsgBoxResult.Yes Then
                    Dim estado_process As Boolean
                    If dgvDatos.CurrentRow.Cells("TipMov").Text <> "O" And cmbOficinas.Value = "01" And cmbIdLocacion.Value <> 3 And cmbOficinas.Value <> 10 Then

                        dtDatos = oFacturaDetService.Mostrar(toNumber(dgvDatos.CurrentRow.Cells("IdFactura").Text)).Tables(0)
                        Dim Contador As Integer = 0

                        For Each Fila As DataRow In dtDatos.Rows
                            If Mid(Trim(Fila.Item("CodMer")), 1, 3) = "AAA" Then
                                Contador = Contador + 0
                            Else
                                Contador = Contador + 1
                            End If
                        Next

                        If Contador > 0 Then
                            estado_process = oFacturaService.AnulacionConsulta(dgvDatos.CurrentRow.Cells("IdFactura").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                            MsgBox("La Factura fue enviada a CONSULTA para su anulación, Comuníquese con Almacén  ...!!!", MsgBoxStyle.Information)
                        Else
                            estado_process = oFacturaService.Anular(dgvDatos.CurrentRow.Cells("IdFactura").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                            MsgBox("Se Anuló la Factura Actual correctamente. !!!", MsgBoxStyle.Information, "Anular")
                        End If

                    Else
                        estado_process = oFacturaService.Anular(dgvDatos.CurrentRow.Cells("IdFactura").Text, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                        MsgBox("Se Anuló la Factura Actual correctamente. !!!", MsgBoxStyle.Information, "Anular")
                    End If

                    If estado_process = True Then
                        'dtDatos = Nothing
                        'listaDatos()
                        Actualizar_Click(sender, e)

                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical, "Anular")
                    End If
                End If
            Catch ex As Exception
                MsgBox("ERROR [ANULAR]:" + ex.Message, MsgBoxStyle.Exclamation, "Anular")
            End Try
        End If
    End Sub
    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.Click, miActualizar.Click
        actualizar()
    End Sub
    Private Sub actualizar()
        Dim codigo As String = ""
        If dgvDatos.RowCount > 0 Then
            codigo = dgvDatos.CurrentRow.Cells("IdFactura").Text
        End If
        dtDatos = Nothing
        listaDatos()
        If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
            RowPossesion(dgvDatos, codigo)
        End If
    End Sub
    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click, miSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Imprimir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biImprimir.MouseEnter, miImprimir.MouseEnter
        sslError.Text = "Imprimir Factura actual."
    End Sub
    Private Sub Ticket_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTicket.MouseEnter, miTicket.MouseEnter
        sslError.Text = "Imprimir Ticket de Almacén de la Factura actual."
    End Sub
    Private Sub Enviar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEnviar.MouseEnter, miEnviar.MouseEnter
        sslError.Text = "Enviar a Créditos para su Aprobación la Factura actual."
    End Sub
    Private Sub B2Mining_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biB2Mining.MouseEnter, miB2Mining.MouseEnter
        sslError.Text = "Enviar a la Integración B2Mining la Factura actual."
    End Sub
    Private Sub Nuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biNuevo.MouseEnter, miNuevo.MouseEnter
        sslError.Text = "Crear Nueva Factura."
    End Sub
    Private Sub Mostrar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biMostrar.MouseEnter, miMostrar.MouseEnter
        sslError.Text = "Mostrar Factura actual."
    End Sub
    Private Sub Eliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEliminar.MouseEnter, miEliminar.MouseEnter
        sslError.Text = "Eliminar Factura actual."
    End Sub
    Private Sub Sugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.MouseEnter, miSugerir.MouseEnter
        sslError.Text = "Sugerir Factor o Descuento."
    End Sub
    Private Sub Anular_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biAnular.MouseEnter, miAnular.MouseEnter
        sslError.Text = "Anular Factura actual."
    End Sub

    Private Sub FacturarJob_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biFacturarJob.MouseEnter, miFacturarJob.MouseEnter
        sslError.Text = "Facturar Job."
    End Sub
    Private Sub Salir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter, miSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario."
    End Sub
    Private Sub Actualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizar.MouseEnter, miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario."
    End Sub
    Private Sub FacturarPendiente_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturarPendiente.MouseEnter
        sslError.Text = "Facturar Grupo de Guias Pendientes ."
    End Sub
    Private Sub ConsultarSugerido_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biConsultarSugerido.MouseEnter, miConsultarSugerido.MouseEnter
        sslError.Text = "Consultar Sugerido."
    End Sub
    Private Sub Estados_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.MouseEnter, miEstados.MouseEnter
        sslError.Text = "Mostrar Estados de la Factura."
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                      biImprimir.MouseLeave, biTicket.MouseLeave, biEnviar.MouseLeave, biFacturarJob.MouseLeave,
                                      biB2Mining.MouseLeave, biNuevo.MouseLeave, biMostrar.MouseLeave, biSugerir.MouseLeave,
                                      biEliminar.MouseLeave, biAnular.MouseLeave, biActualizar.MouseLeave, biSalir.MouseLeave,
                                      biEstados.MouseLeave, FacturarPendiente.MouseLeave, biConsultarSugerido.MouseLeave,
                                      miImprimir.MouseLeave, miTicket.MouseLeave, miEnviar.MouseLeave, miFacturarJob.MouseLeave,
                                      miB2Mining.MouseLeave, miNuevo.MouseLeave, miMostrar.MouseLeave, miSugerir.MouseLeave,
                                      miEliminar.MouseLeave, miAnular.MouseLeave, miActualizar.MouseLeave, miSalir.MouseLeave,
                                      miEstados.MouseLeave, miConsultarSugerido.MouseLeave, biConsultarSugerido.MouseLeave,
                                      miActualizarLocacion.MouseLeave, biActualizarLocacion.MouseLeave
        sslError.Text = ""
    End Sub


    Private Sub biSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.Click, miSugerir.Click
        Try

            If toNumber(dgvDatos.CurrentRow.Cells("IdSugerido").Text) > 0 Then
                Dim factor As Double
                Dim dscto As Double
                factor = dgvDatos.CurrentRow.Cells("FactorSug").Text
                dscto = dgvDatos.CurrentRow.Cells("DsctoSug").Text
                If factor + dscto = 0 And dgvDatos.CurrentRow.Cells("TotNetoSug").Text Then
                    MsgBox("¡No puede hacer sugerencias por Documento, por que ya se hizo a nivel de Detalle...!", MsgBoxStyle.Critical)
                    Return
                End If
            End If
            Dim frm As New frmFacturaSugerirCabecera
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.IdSugerido = dgvDatos.CurrentRow.Cells("IdSugerido").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Actualizar_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biFacturarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biFacturarJob.Click, miFacturarJob.Click
        Try
            If ValidaFacturarJob() Then
                Dim frm As New frmFactura_AtenderJob
                frm.Documento = 1   '------ Agregado el 14/03/2013 (reutilizando frmAtenderJob en el módulo de Facturas y Boletas)
                frm.txtNumDoc.Text = oFacturaService.SugerirNumero(cmbIdLocacion.Value, Session.sCodUsu)
                frm.CodOfi = cmbOficinas.Value
                frm.IdLocacion = cmbIdLocacion.Value
                frm.TipFac = cmbTipFac.Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtDatos = Nothing
                    ' limpiaOpcionesBusqueda("insert", frm.txtNumDoc.Text)
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdFactura)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL FACTURAR LA OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Function ValidaFacturarJob() As Boolean
        Try
            'If cmbIdLocacion.Value <> 3 And cmbIdLocacion.Value <> 16 Then
            'Se comenta ya que ahora se permitira generar una F/ partir de una liquidación en cualquier almacen 19/05/2021 Cesar Cueto
            'If cmbIdLocacion.DropDownList.GetRow.Cells(2).Text <> "003" And cmbIdLocacion.DropDownList.GetRow.Cells(2).Text <> "009" Then
            'MsgBox("No puede atender Job por esta Locación")
            '    Return False
            'Else
            Return True
            'End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function


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

            frm.IdCodigo = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.TipoCodigo = "FA"
            frm.Text = "Precios Sugeridos de Factura Nº : " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If

        Catch ex As Exception
            MsgBox("Error al consultar precios sugeridos : " + ex.Message)
        End Try
    End Sub

    Private Sub FacturarPendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturarPendiente.Click
        Dim frm As New frmFacturarGrupoGuias
        'frm.state_button = False
        frm.IdLocacion = cmbIdLocacion.Value
        'frm.TipFac = cmbTipFac.Value
        frm.txtNumDoc.Text = oFacturaService.SugerirNumero(cmbIdLocacion.Value, Session.sCodUsu)
        'frm.txtNumDoc.Text = oValeMaterialService.SugerirNumero(11)
        frm.btnBuscarCliente.Focus()
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            listaDatos()
            RowPossesion(dgvDatos, frm.txtNumDoc.Text)
        End If

    End Sub

    Private Sub biEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEstados.Click, miEstados.Click
        Try
            Dim frm As New frmFacturaEstados
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox("Error al mostrar los estados : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biActualizarLocacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActualizarLocacion.Click, miActualizarLocacion.Click
        Try
            Dim frm As New frmFactura_ActualizarLocacion
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
            frm.Cliente = dgvDatos.CurrentRow.Cells("DesCli").Text
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm.IdFactura)
            End If
        Catch ex As Exception
            MsgBox("Error al mostrar los estados : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biBajarnivel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biBajarnivel.Click, miBajarNivel.Click

        Try
            Dim frm As New frmDocVenta_ActualizarEstado

            frm.Text = "Actualizar a estado inicial"
            frm.TipoDoc = "Factura"
            frm.IdDocVenta = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                actualizar()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR [GENERAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub biGenerarFacturaElectronica_Click(sender As System.Object, e As System.EventArgs) Handles biGenerarFacturaElectronica.Click, miGenerarFacturaElectronica.Click
        Try
            Dim existefactelec As Boolean
            Dim existecuotas As Double
            Dim MostrarBanco As Boolean
            Dim opcionimp As String
            Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Value
            Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
            Dim CodPag As String = dgvDatos.CurrentRow.Cells("CodPag").Text

            'Dim Estado As String = dgvDatos.CurrentRow.Cells("Estado").Text
            Dim fecVencimiento As Date = oDocCtaCte.CalcularFecVen(CodPag, FecDoc)
            Dim TotalSoles As String
            Dim TipoCambio As Decimal
            Dim TotNeto As Decimal

            TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
            TotNeto = Math.Round(dgvDatos.CurrentRow.Cells("TotNeto").Value, 2)
            TotalSoles = "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Format(Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero), "#,0.00")

            existefactelec = oFacturaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdFactura").Text)
            'existefactelec = False
            If existefactelec = True Then
                MsgBox("Ya existe la factura electronica, verifique.", MsgBoxStyle.Information)
            Else

                Dim frm As New frmFactura_FacturaElectronica_Imprimir
                frm.IdFacturaPreImpresion = dgvDatos.CurrentRow.Cells("IdFactura").Text
                frm.TotalSoles = TotalSoles
                frm.TotNeto = TotNeto
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdFactura)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al generar la factura electronica")
        End Try
    End Sub

    ' BACKUP DE FACTURA MENSAJE EN NUEVA VENTANA
    'Private Sub biGenerarFacturaElectronica_Click(sender As System.Object, e As System.EventArgs) Handles biGenerarFacturaElectronica.Click, miGenerarFacturaElectronica.Click
    '    Try
    '        Dim existefactelec As Boolean
    '        Dim existecuotas As Double
    '        Dim MostrarBanco As Boolean
    '        Dim opcionimp As String
    '        Dim FecDoc As Date = dgvDatos.CurrentRow.Cells("FecDoc").Value
    '        Dim CodMon As String = dgvDatos.CurrentRow.Cells("CodMon").Text
    '        Dim CodPag As String = dgvDatos.CurrentRow.Cells("CodPag").Text

    '        'Dim Estado As String = dgvDatos.CurrentRow.Cells("Estado").Text
    '        Dim fecVencimiento As Date = oDocCtaCte.CalcularFecVen(CodPag, FecDoc)
    '        Dim TotalSoles As String
    '        Dim TipoCambio As Decimal
    '        Dim TotNeto As Decimal

    '        TipoCambio = Format(oMaestroService.MostrarTipoCambio(CodMon, FecDoc), "#0.000")
    '        TotNeto = Math.Round(dgvDatos.CurrentRow.Cells("TotNeto").Value, 2)
    '        TotalSoles = "Al  T.C. de S/. " & TipoCambio & "  por  Dolar = S/. " & Format(Math.Round(TotNeto * TipoCambio, 2, MidpointRounding.AwayFromZero), "#,0.00")

    '        existefactelec = oFacturaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdFactura").Text)
    '        'existefactelec = False
    '        If existefactelec = True Then
    '            MsgBox("Ya existe la factura electronica, verifique.", MsgBoxStyle.Information)
    '        Else

    '            '======================================================= CODIGO ANTES DEL CAMBIO DE CUOTAS EN VENTANA DE IMPRIMIR ===============================

    '            'Ingreso de Cuotas 

    '            existecuotas = oFacturaService.ObtenerTotalCuota(dgvDatos.CurrentRow.Cells("IdFactura").Text)
    '            'existecuotas = 1 'oFacturaService.ObtenerTotalCuota(dgvDatos.CurrentRow.Cells("IdFactura").Text)

    '            '=============================================== CONTADO ===================================
    '            If CodPag = "00" Or CodPag = "25" Then

    '                Dim frm As New frmFactura_FacturaElectronica_Imprimir
    '                frm.IdFacturaPreImpresion = dgvDatos.CurrentRow.Cells("IdFactura").Text
    '                frm.TotalSoles = TotalSoles
    '                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '                    If frm.state = True Then
    '                        MostrarBanco = True
    '                    Else
    '                        MostrarBanco = False
    '                    End If
    '                    opcionimp = frm.opcion
    '                    Dim frm1 As New frmFactura_FacturaElectronica
    '                    frm1.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
    '                    frm1.MostrarBanco = MostrarBanco
    '                    frm1.opcionimp = opcionimp
    '                    frm1.TotalSoles = TotalSoles
    '                    If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '                        If frm1.EstadoSunat = True Then
    '                            listaDatos()
    '                            RowPossesion(dgvDatos, frm1.IdFactura)
    '                        End If
    '                    End If
    '                Else
    '                    Exit Sub
    '                End If

    '                '============================== CREDITO SIN CUOTAS ===========================================
    '            ElseIf existecuotas = 0 And CodPag <> "00" And CodPag <> "25" Then   'cmbTipFac.Value = 1
    '                'MsgBox("Debe ingresar las cuotas, verifique.", MsgBoxStyle.Information)

    '                If MsgBox("¿Desea insertar una cuota unica?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

    '                    Dim registro As New FacturaService.FacturaCuotas
    '                    Dim empresa As New FacturaService.Empresa
    '                    Dim factura As New FacturaService.Factura

    '                    registro.NumeroCuota = 1
    '                    registro.MontoCuota = TotNeto
    '                    registro.FecVencimiento = fecVencimiento

    '                    factura.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
    '                    registro.Factura = factura

    '                    registro.FecReg = Date.Today

    '                    registro.CodUsu = Session.sCodUsu
    '                    registro.NomPc = Session.sNomPc
    '                    registro.DirIp = Session.sDirIp

    '                    Dim estado_process As Boolean
    '                    estado_process = oFacturaService.InsertarCuota(registro)

    '                    'If estado_process Then

    '                    Dim frm1 As New frmFactura_FacturaElectronica_Imprimir
    '                    frm1.IdFacturaPreImpresion = dgvDatos.CurrentRow.Cells("IdFactura").Text
    '                    frm1.TotalSoles = TotalSoles
    '                    If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '                        If frm1.state = True Then
    '                            MostrarBanco = True
    '                        Else
    '                            MostrarBanco = False
    '                        End If
    '                        opcionimp = frm1.opcion
    '                        Dim frm2 As New frmFactura_FacturaElectronica
    '                        frm2.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
    '                        frm2.MostrarBanco = MostrarBanco
    '                        frm2.opcionimp = opcionimp
    '                        frm2.TotalSoles = TotalSoles
    '                        If frm2.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '                            If frm2.EstadoSunat = True Then
    '                                listaDatos()
    '                                RowPossesion(dgvDatos, frm1.IdFactura)
    '                            End If
    '                        End If
    '                    Else
    '                        Exit Sub
    '                    End If

    '                    'End If

    '                Else

    '                    'MsgBox("Debe ingresar las cuotas, verifique.", MsgBoxStyle.Information)

    '                    Dim frm4 As New frmFactura_Cuotas
    '                    frm4.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
    '                    frm4.FecDoc = CDate(dgvDatos.CurrentRow.Cells("FecDoc").Text)
    '                    frm4.TotNeto = CDbl(dgvDatos.CurrentRow.Cells("TotNeto").Text)
    '                    frm4.ShowDialog()

    '                End If

    '            Else
    '                '============================== CREDITO CON CUOTAS ===========================================
    '                'If existecuotas <> TotNeto Then
    '                '    MsgBox("Las cuotas no coinciden con el total, verifique.", MsgBoxStyle.Information)
    '                '    Exit Sub
    '                'End If

    '                Dim frm As New frmFactura_FacturaElectronica_Imprimir
    '                frm.IdFacturaPreImpresion = dgvDatos.CurrentRow.Cells("IdFactura").Text
    '                frm.TotalSoles = TotalSoles
    '                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '                    If frm.state = True Then
    '                        MostrarBanco = True
    '                    Else
    '                        MostrarBanco = False
    '                    End If
    '                    opcionimp = frm.opcion

    '                    If existecuotas <> TotNeto Then
    '                        MsgBox("Las cuotas no coinciden con el total, verifique.", MsgBoxStyle.Information)
    '                        Exit Sub
    '                    End If

    '                    Dim frm1 As New frmFactura_FacturaElectronica
    '                    frm1.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
    '                    frm1.MostrarBanco = MostrarBanco
    '                    frm1.opcionimp = opcionimp
    '                    frm1.TotalSoles = TotalSoles
    '                    If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '                        If frm1.EstadoSunat = True Then
    '                            listaDatos()
    '                            RowPossesion(dgvDatos, frm1.IdFactura)
    '                        End If
    '                    End If
    '                Else
    '                    Exit Sub
    '                End If




    '            End If


    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al generar la factura electronica")
    '    End Try
    'End Sub



    Private Sub biDarBajaElectronica_Click(sender As System.Object, e As System.EventArgs) Handles biDarBajaFacturaElectronica.Click, miDarBajaFacturaElectronica.Click
        Try
            Dim existefactelec As Boolean

            existefactelec = oFacturaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdFactura").Text)
            'existefactelec = True

            If existefactelec = True Then

                Dim frm As New frmFactura_FacturaElectronica_ComunicadoBaja
                frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
                frm.DesCli = dgvDatos.CurrentRow.Cells("DesCli").Text
                frm.CodMon = dgvDatos.CurrentRow.Cells("CodMon").Text
                frm.TotNeto = CDec(dgvDatos.CurrentRow.Cells("TotNeto").Text)
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdFactura)
                End If
            Else
                MsgBox("No existe la factura electronica, verifique.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al dar de baja la factura electronica")
        End Try
    End Sub

    Private Sub biDescargarFacturaElectronica_Click(sender As System.Object, e As System.EventArgs) Handles biDescargarFacturaElectronica.Click, miDescargarFacturaElectronica.Click
        Try

            Dim existefactelec As Boolean

            existefactelec = oFacturaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdFactura").Text)

            If existefactelec = True Then

                Dim dtImprimirDigital As New DataTable

                dtImprimirDigital = oFacturaService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdFactura").Text).Tables(0)
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
                CodMon = GridEX2.CurrentRow.Cells("CodMon").Text

                CrearCarpeta()
                CrearXML()
                'ObtenerTagFirma()
                CrearPDF()
            Else
                MsgBox("No existe la factura electronica, verifique.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al descargar la factura electronica")
        End Try
    End Sub

    Private Sub CrearCarpeta()

        If Not Directory.Exists("D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX2.CurrentRow.Cells("Documento").Text) Then
            Directory.CreateDirectory("D:\Documentos_Electronicos\Facturas_Electronicas\" & GridEX2.CurrentRow.Cells("Documento").Text)
        End If

    End Sub

    Private Sub CrearXML()

        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(New StringReader(oFacturaDigitalService.Descargar(dgvDatos.CurrentRow.Cells("IdFactura").Text)))

            NombreXMLPDF = oFacturaDigitalService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdFactura").Text)

            xmlDoc.Save("D:\Documentos_Electronicos\Facturas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".xml")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el xml")
        End Try

    End Sub

    Private Sub CrearPDF()
        Try
            Dim pdfDoc() As Byte
            pdfDoc = oFacturaDigitalService.DescargarPdf(dgvDatos.CurrentRow.Cells("IdFactura").Text)

            NombreXMLPDF = oFacturaDigitalService.ObtenerNombre(dgvDatos.CurrentRow.Cells("IdFactura").Text)

            System.IO.File.WriteAllBytes("D:\Documentos_Electronicos\Facturas_Electronicas\" & DocumentoFac & "\" & NombreXMLPDF & ".pdf", pdfDoc)

            MsgBox("Se descargo la factura electronica correctamente", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear el pdf")
        End Try
    End Sub

    Private Sub biListarFactElecxCliente_Click(sender As System.Object, e As System.EventArgs) Handles biListarFactElecxCliente.Click, miListarFactElecxCliente.Click
        Try

            Dim dtImprimirDigital As New DataTable

            dtImprimirDigital = oFacturaService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdFactura").Text).Tables(0)
            GridEX2.DataSource = dtImprimirDigital

            CodSerieFac = GridEX2.CurrentRow.Cells("CodSerie").Text
            NumDocFac = GridEX2.CurrentRow.Cells("NumDoc").Text

            Dim frm As New frmFactura_FacturaElectronicaxCliente
            frm.IdCliente = dgvDatos.CurrentRow.Cells("IdCliente").Text
            frm.DesCli = dgvDatos.CurrentRow.Cells("DesCli").Text
            frm.CodSerie = CodSerieFac
            frm.NumDoc = NumDocFac
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al listar las facturas x cliente")
        End Try
    End Sub

    Private Sub biComunicadosBaja_Click(sender As System.Object, e As System.EventArgs) Handles biListaComunicadosBaja.Click, miListarComunicadosBaja.Click
        Try
            Dim frm As New frmFacturacionElectronica_ComunicadoBaja
            frm.TipoDoc = "3"
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al listar los comunicados de baja")
        End Try
    End Sub


    Private Sub miObservacionesSunat_Click(sender As System.Object, e As System.EventArgs) Handles miObservacionesSunat.Click
        Try
            Dim frm As New frmFactura_FacturacionElectronica_ObsSunat
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al visualizar las observaciones")
        End Try
    End Sub

    Private Sub miObtenercdrdoc_Click(sender As System.Object, e As System.EventArgs) Handles miObtenercdrdoc.Click
        Try
            Dim frm As New frmFacturacionElectronica_ObtenerEstadoSunat
            frm.TipoDoc = "01"
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

            Dim frm1 As New frmFacturacionElectronica_ActualizarCDR
            frm1.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm1.CodSerie = dgvDatos.CurrentRow.Cells("CodSerie").Text
            frm1.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
            If frm1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                listaDatos()
                RowPossesion(dgvDatos, frm1.IdFactura)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al generar la factura electronica")
        End Try
    End Sub

    Private Sub miGenerarAsiento_Click(sender As Object, e As EventArgs) Handles miGenerarAsiento.Click
        If ValidaCodigoSeleccionado() Then
            Try
                If MsgBox("¿Está Seguro de Generar el Asiento Contable de la Factura Nº " + dgvDatos.CurrentRow.Cells("NumDoc").Text.ToString + "?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                    If oFacturaService.GenerarAsiento(dgvDatos.CurrentRow.Cells("IdFactura").Text.ToString, Session.sCodUsu, Session.sNomPc, Session.sDirIp) Then
                        MsgBox("Se genero el Asiento Contable con Exito.....!", MsgBoxStyle.Information, "Asiento Generado")

                        Actualizar_Click(sender, e)
                    Else
                        MsgBox("Error en el proceso, comuníquese con TI...!", MsgBoxStyle.Critical, "Generar Asiento")
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Generar el Asiento")
            End Try
        End If
    End Sub

    Private Sub miVerAsiento_Click(sender As Object, e As EventArgs) Handles miVerAsiento.Click
        If ValidaCodigoSeleccionado() Then
            Try

                If oContabilidad.BuscarAsientoVenta(dgvDatos.CurrentRow.Cells("IdDocumento").Text.ToString, dgvDatos.CurrentRow.Cells("IdFactura").Text.ToString) Then
                    Dim frm As New frmConsultaDiarioFactura
                    frm.IdContabilidad = oContabilidad.ObtenerIdContabilidadVenta(dgvDatos.CurrentRow.Cells("IdDocumento").Text.ToString, dgvDatos.CurrentRow.Cells("IdFactura").Text.ToString)
                    frm.ShowDialog()
                Else
                    MsgBox("El Asiento Contable no existe", MsgBoxStyle.Information, "Vacio")
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Generar el Asiento")
            End Try
        End If


    End Sub

    Private Sub biCuotas_Click(sender As Object, e As EventArgs) Handles biCuotas.Click, miCuotas.Click

        Try

            Dim Estado As String = dgvDatos.CurrentRow.Cells("Estado").Text

            'If cmbTipFac.Value = 1 And Estado = "GN" Then

            Dim frm As New frmFactura_Cuotas
            frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
            frm.FecDoc = CDate(dgvDatos.CurrentRow.Cells("FecDoc").Text)
            frm.TotNeto = CDbl(dgvDatos.CurrentRow.Cells("TotNeto").Text)
            'frm.NumDoc = dgvDatos.CurrentRow.Cells("NumDoc").Text
            frm.CodPag = dgvDatos.CurrentRow.Cells("CodPag").Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

            End If

            'End If

        Catch ex As Exception
            MsgBox("Error al mostrar los estados : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cmbSerieFactura_ValueChanged(sender As Object, e As EventArgs) Handles cmbSerieFactura.ValueChanged
        listaDatos()
    End Sub

    Private Sub biEnviarCorreo_Click(sender As Object, e As EventArgs) Handles biEnviarCorreo.Click, miEnviarFacturaElectronica.Click

        If ValidaCodigoSeleccionado() Then
            Try

                Dim existefactelec As Boolean

                existefactelec = oFacturaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdFactura").Text)

                If existefactelec = True Then


                    Dim dtImprimirDigital As New DataTable

                    dtImprimirDigital = oFacturaService.ImprimirDigital(dgvDatos.CurrentRow.Cells("IdFactura").Text).Tables(0)
                    GridEX2.DataSource = dtImprimirDigital

                    CodSerieFac = GridEX2.CurrentRow.Cells("CodSerie").Text
                    NumDocFac = GridEX2.CurrentRow.Cells("NumDoc").Text
                    IdClienteFac = GridEX2.CurrentRow.Cells("IdCliente").Text

                    Dim frm As New frmFactura_FacturaElectronica_EnviarCorreo

                    frm.CodSerie = CodSerieFac
                    frm.NumDoc = NumDocFac
                    frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text
                    frm.IdCliente = IdClienteFac
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    End If

                Else
                    MsgBox("No existe la factura electronica, verifique.", MsgBoxStyle.Information)
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

    Private Sub biGenerarNotaCredito_Click(sender As Object, e As EventArgs) Handles biGenerarNotaCredito.Click, miGenerarNotaCredito.Click

        Try
            Dim existefactelec As Boolean

            existefactelec = oFacturaDigitalService.Buscar(dgvDatos.CurrentRow.Cells("IdFactura").Text)
            'existefactelec = False
            If existefactelec = True Then

                Dim frm As New frmFactura_GenerarNotaCredito
                frm.IdFactura = dgvDatos.CurrentRow.Cells("IdFactura").Text

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                End If

            End If
        Catch ex As Exception
            MsgBox("Error al mostrar los estados : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
End Class