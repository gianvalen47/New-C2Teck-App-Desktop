Imports System.ServiceModel
Imports System.IO
Imports System.Xml

Public Class frmRegCompras

    '===========================Servicios====================================
    Private oMaestroService As New MaestroService.MaestroClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient
    Private oRegistroCompraService As New RegistroCompraService.RegistroCompraServiceClient
    Private oRegistroCompraDetService As New RegistroCompraDetService.RegistroCompraDetServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient

    '======================Declaración de Variables==============================   
    Public IdProveedor As Integer
    Public IdCompra As Integer                ' Id del Registro de Compra          
    Private dtMonedas As DataTable
    Private dtCondPago As DataTable
    Private dtTipDoc As DataTable
    Private dtDatos As DataTable
    Private NombreArchivo As String
    Private dtTipoDetraccion As DataTable

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean = True                   'True: Edición      False: Vista
    Public editable As Boolean = True                'True: Editable     False: No Editable 
    Public Solicitud As Boolean                        'Valor que devuelve el método BuscarSolicitud
    Private DocumentoXml As String = ""
    Private DocumentoPdf As Byte() = Nothing

    Private Sub frmRegCompras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Finalizar()
    End Sub

    Private Sub Finalizar()
        Try
            oMaestroService.Close()
            oProveedorService.Close()
            oRegistroCompraService.Close()
            oRegistroCompraDetService.Close()
            oSeguridadService.Close()
            oSolicitudGastoDetService.Close()
        Catch ex As TimeoutException
            oMaestroService.Close()
            oProveedorService.Close()
            oRegistroCompraService.Close()
            oRegistroCompraDetService.Close()
            oSeguridadService.Close()
            oSolicitudGastoDetService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Close()
            oProveedorService.Close()
            oRegistroCompraService.Close()
            oRegistroCompraDetService.Close()
            oSeguridadService.Close()
            oSolicitudGastoDetService.Abort()
        End Try
    End Sub

    Private Sub frmRegistroCompras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Finalizar()
            Me.Close()
        End If
    End Sub

    Private Sub frmRegistroCompras_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '/************************** Insertar Opciones de Session ************************/
        oSeguridadService.InsertarSesionOpciones(Session.sIdSesion, 173)
        '/*************************************************************************************/

        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        'txtDesCuenta.Text = ""

        'txtPeriodo.Value = Today.Year
        'txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "igv", "CodEmp", Session.sCodEmp))
        'txtMesRegistro.Text = Format(Month(Today), "00")
        'ObtenerNumRegistro()
        'LlenarCombos()
        'state_button = False
        'Desactivar()



        If state_button Then    'Modificar
            'ObtenerNumRegistro()
            LlenarCombos()
            'ObtenerRegistro()
            'Desactivar()

            txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "igv", "CodEmp", Session.sCodEmp))

            ObtenerRegistro()
            actualizarDetalles()
            state_button = True
            edicion = False
            Desactivar()


        Else

            txtDesCuenta.Text = ""

            txtPeriodo.Value = Today.Year
            txtIgv.Text = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Empresas", "igv", "CodEmp", Session.sCodEmp))
            txtMesRegistro.Text = Format(Month(Today), "00")
            ObtenerNumRegistro()
            LlenarCombos()
            state_button = False
            'Desactivar()

        End If

    End Sub

    Private Function getRowTodos2(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(3) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(4) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Return fila
    End Function

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCompraDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdCompraDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Desactivar()
        txtMesRegistro.ReadOnly = False
        txtMesRegistro.BackColor = System.Drawing.SystemColors.Window
        txtNumRegistro.ReadOnly = False
        txtNumRegistro.BackColor = System.Drawing.SystemColors.Window
        txtPeriodo.ReadOnly = False
        txtPeriodo.BackColor = System.Drawing.SystemColors.Window
        btnBuscarRegistro.Enabled = True
        txtCodTipoDoc.ReadOnly = True
        txtCodTipoDoc.BackColor = System.Drawing.SystemColors.Control
        cmbTipoDoc.ReadOnly = True
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
        txtSerieDoc.ReadOnly = True
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control

        txtCodTipoRef.ReadOnly = True
        txtCodTipoRef.BackColor = System.Drawing.SystemColors.Control
        cmbTipoRef.ReadOnly = True
        cmbTipoRef.BackColor = System.Drawing.SystemColors.Control
        txtSerieRef.ReadOnly = True
        txtSerieRef.BackColor = System.Drawing.SystemColors.Control
        txtNumRef.ReadOnly = True
        txtNumRef.BackColor = System.Drawing.SystemColors.Control
        txtFecDocRef.ReadOnly = True
        txtFecDocRef.BackColor = System.Drawing.SystemColors.Control

        btnBuscarProveedor.Enabled = False
        btnAgregarProveedor.Enabled = False
        cmbCondPago.ReadOnly = True
        cmbCondPago.BackColor = System.Drawing.SystemColors.Control
        btnBuscarXml.Enabled = False
        btnBuscarPdf.Enabled = False
        txtFecha.ReadOnly = True
        txtFecha.BackColor = System.Drawing.SystemColors.Control
        txtFecEmision.ReadOnly = True
        txtFecEmision.BackColor = System.Drawing.SystemColors.Control
        txtFecVencimiento.ReadOnly = True
        txtFecVencimiento.BackColor = System.Drawing.SystemColors.Control
        txtTipCambio.ReadOnly = True
        txtTipCambio.BackColor = System.Drawing.SystemColors.Control
        txtGlosa.ReadOnly = True
        txtGlosa.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        rbAnulado.Enabled = False
        cbAfectoIgv.Enabled = False
        btnLimpiarXml.Enabled = False
        btnLimpiarPdf.Enabled = False
        'btnDescargarXml.Enabled = False
        'btnDescargarPdf.Enabled = False

        cbAfectoDetraccion.Enabled = False
        cmbTipoDetraccion.ReadOnly = True
        cmbTipoDetraccion.BackColor = System.Drawing.SystemColors.Control
        txtNroPagoDetraccion.ReadOnly = True
        txtNroPagoDetraccion.BackColor = System.Drawing.SystemColors.Control
        txtFechaPagoDetraccion.ReadOnly = True
        txtFechaPagoDetraccion.BackColor = System.Drawing.SystemColors.Control

        edicion = False
        enableOpciones()
    End Sub

    Private Sub Activar()
        If state_button Then
            txtPeriodo.ReadOnly = True
            txtPeriodo.BackColor = System.Drawing.SystemColors.Control
            txtMesRegistro.ReadOnly = True
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
            txtNumRegistro.ReadOnly = True
            txtNumRegistro.BackColor = System.Drawing.SystemColors.Control
            btnBuscarRegistro.Enabled = True
            txtCodTipoDoc.ReadOnly = False
            txtCodTipoDoc.BackColor = System.Drawing.SystemColors.Window
            cmbTipoDoc.ReadOnly = False
            cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
            txtSerieDoc.ReadOnly = False
            txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
            txtNumDoc.ReadOnly = False
            txtNumDoc.BackColor = System.Drawing.SystemColors.Window

            If cmbTipoDoc.Value = 5 Or cmbTipoDoc.Value = 6 Then
                txtCodTipoRef.ReadOnly = False
                txtCodTipoRef.BackColor = System.Drawing.SystemColors.Window
                cmbTipoRef.ReadOnly = False
                cmbTipoRef.BackColor = System.Drawing.SystemColors.Window
                txtSerieRef.ReadOnly = False
                txtSerieRef.BackColor = System.Drawing.SystemColors.Window
                txtNumRef.ReadOnly = False
                txtNumRef.BackColor = System.Drawing.SystemColors.Window
                txtFecDocRef.ReadOnly = False
                txtFecDocRef.BackColor = System.Drawing.SystemColors.Window
            Else
                txtCodTipoRef.ReadOnly = True
                txtCodTipoRef.BackColor = System.Drawing.SystemColors.Control
                cmbTipoRef.ReadOnly = True
                cmbTipoRef.BackColor = System.Drawing.SystemColors.Control
                txtSerieRef.ReadOnly = True
                txtSerieRef.BackColor = System.Drawing.SystemColors.Control
                txtNumRef.ReadOnly = True
                txtNumRef.BackColor = System.Drawing.SystemColors.Control
                txtFecDocRef.ReadOnly = True
                txtFecDocRef.BackColor = System.Drawing.SystemColors.Control
            End If

            btnBuscarProveedor.Enabled = True
            btnAgregarProveedor.Enabled = True
            cmbCondPago.ReadOnly = False
            cmbCondPago.BackColor = System.Drawing.SystemColors.Window
            btnBuscarXml.Enabled = True
            btnBuscarPdf.Enabled = True
            btnLimpiarXml.Enabled = True
            btnLimpiarPdf.Enabled = True
            'btnDescargarXml.Enabled = True
            'btnDescargarPdf.Enabled = True
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtFecEmision.ReadOnly = False
            txtFecEmision.BackColor = System.Drawing.SystemColors.Window
            txtFecVencimiento.ReadOnly = False
            txtFecVencimiento.BackColor = System.Drawing.SystemColors.Window
            txtGlosa.ReadOnly = False
            txtGlosa.BackColor = System.Drawing.SystemColors.Window
            rbAnulado.Enabled = True

            If dgvDatos.RowCount > 0 Then
                txtTipCambio.ReadOnly = True
                txtTipCambio.BackColor = System.Drawing.SystemColors.Control
                cmbMoneda.ReadOnly = True
                cmbMoneda.BackColor = System.Drawing.SystemColors.Control
                cbAfectoIgv.Enabled = False
            Else
                txtTipCambio.ReadOnly = False
                txtTipCambio.BackColor = System.Drawing.SystemColors.Window
                cmbMoneda.ReadOnly = False
                cmbMoneda.BackColor = System.Drawing.SystemColors.Window
                cbAfectoIgv.Enabled = True
            End If

            cbAfectoDetraccion.Enabled = True
            If cbAfectoDetraccion.Checked Then
                cmbTipoDetraccion.ReadOnly = False
                cmbTipoDetraccion.BackColor = System.Drawing.SystemColors.Window
                txtNroPagoDetraccion.ReadOnly = False
                txtNroPagoDetraccion.BackColor = System.Drawing.SystemColors.Window
                txtFechaPagoDetraccion.ReadOnly = False
                txtFechaPagoDetraccion.BackColor = System.Drawing.SystemColors.Window
            End If

        Else
            txtPeriodo.ReadOnly = True
            txtPeriodo.BackColor = System.Drawing.SystemColors.Control
            txtMesRegistro.ReadOnly = True
            txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
            txtNumRegistro.ReadOnly = True
            txtNumRegistro.BackColor = System.Drawing.SystemColors.Control
            btnBuscarRegistro.Enabled = True
            txtCodTipoDoc.ReadOnly = False
            txtCodTipoDoc.BackColor = System.Drawing.SystemColors.Window
            cmbTipoDoc.ReadOnly = False
            cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
            txtSerieDoc.ReadOnly = False
            txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
            txtNumDoc.ReadOnly = False
            txtNumDoc.BackColor = System.Drawing.SystemColors.Window

            btnBuscarProveedor.Enabled = True
            btnAgregarProveedor.Enabled = True
            cmbCondPago.ReadOnly = False
            cmbCondPago.BackColor = System.Drawing.SystemColors.Window
            btnBuscarXml.Enabled = True
            btnBuscarPdf.Enabled = True
            btnLimpiarXml.Enabled = True
            btnLimpiarPdf.Enabled = True
            'btnDescargarXml.Enabled = True
            'btnDescargarPdf.Enabled = True
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            txtFecEmision.ReadOnly = False
            txtFecEmision.BackColor = System.Drawing.SystemColors.Window
            txtFecVencimiento.ReadOnly = False
            txtFecVencimiento.BackColor = System.Drawing.SystemColors.Window
            txtTipCambio.ReadOnly = False
            txtTipCambio.BackColor = System.Drawing.SystemColors.Window
            txtGlosa.ReadOnly = False
            txtGlosa.BackColor = System.Drawing.SystemColors.Window

            If toNumber(txtMesRegistro.Text) = Month(Today) And txtPeriodo.Value = Year(Today) Then
                txtFecha.Value = Today
                txtFecha.Text = Today
            Else
                txtFecha.Value = DateSerial(txtPeriodo.Value, toNumber(txtMesRegistro.Text) + 1, 0)
                txtFecha.Text = CStr(DateSerial(txtPeriodo.Value, toNumber(txtMesRegistro.Text) + 1, 0))
            End If

            'txtFecha.Value = Today
            'txtFecha.Text = Today
            txtFecEmision.Value = Today
            txtFecEmision.Text = Today
            txtFecVencimiento.Value = Today
            txtFecVencimiento.Text = Today

            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window

            cmbMoneda.Value = "NS"
            rbAnulado.Enabled = True
            rbAnulado.Checked = False
            cbAfectoIgv.Enabled = True
            cbAfectoIgv.Checked = True
            cbAfectoDetraccion.Enabled = True

            txtTipCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbMoneda.Value, txtFecha.Value)), "#0.000")
        End If

        txtCodTipoDoc.Focus()
        edicion = True
        enableOpciones()
    End Sub

    Private Sub enableOpciones()
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
            miDuplicar.Enabled = False
        Else
            miMostrar.Enabled = True
            'miEliminar.Enabled = IIf(editable And (state_button = True And Solicitud = False), True, False)
            miEliminar.Enabled = IIf(editable And (state_button = True), True, False)
            'miDuplicar.Enabled = IIf(editable And (state_button = True And Solicitud = False), True, False)
            miDuplicar.Enabled = IIf(editable And (state_button = True), True, False)
        End If
        'miNuevo.Enabled = IIf(editable And (state_button = True And Solicitud = False), True, False)
        miNuevo.Enabled = IIf(editable And (state_button = True), True, False)

        biEditar.Enabled = IIf(editable, Not edicion And IdCompra <> 0, False)
        biSalir.Enabled = Not edicion
        biImprimir.Enabled = IIf(Not edicion, True, False)
        biImportar.Enabled = IIf(edicion And IdCompra = 0, True, False)  'IIf(Not edicion And IdCompra = 0, True, False)
        biEliminar.Enabled = IIf(Not edicion And IdCompra <> 0, True, False)
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpciones.Enabled = IIf(Not edicion And IdCompra <> 0, True, False)
        btnDescargarXml.Enabled = IIf(Not edicion And IdCompra <> 0, True, False)
        btnDescargarPdf.Enabled = IIf(Not edicion And IdCompra <> 0, True, False)
    End Sub

    Private Sub ObtenerNumRegistro()
        Try
            txtNumRegistro.Text = oRegistroCompraService.ObtenerRegistro(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text)
            txtNumRegistro.Focus()
            txtNumRegistro.SelectAll()
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER Nº  DE REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As New RegistroCompraService.RegistroCompra
            registro = oRegistroCompraService.Obtener(IdCompra)

            IdCompra = registro.IdCompra
            txtPeriodo.Value = registro.Periodo
            txtMesRegistro.Text = registro.Mes
            txtNumRegistro.Text = registro.NumRegistro
            cmbTipoDoc.Value = registro.TipoDocumento.IdDocumento
            txtCodTipoDoc.Text = registro.TipoDocumento.CodSunat
            txtSerieDoc.Text = registro.SerDoc
            txtNumDoc.Text = registro.NumDoc

            If IsDBNull(registro.TipoDocumentoRef.IdDocumento) Then
                cmbTipoDoc.SelectedIndex = 0
            Else
                cmbTipoRef.Value = registro.TipoDocumentoRef.IdDocumento
            End If

            If IsDBNull(registro.TipoDocumentoRef.IdDocumento) Then
                txtCodTipoRef.Text = ""
            Else
                txtCodTipoRef.Text = registro.TipoDocumentoRef.CodSunat
            End If

            txtSerieRef.Text = registro.SerDocRef
            txtNumRef.Text = registro.NumDocRef

            If Not (registro.FecDocRef.ToString = "") Then
                txtFecDocRef.Value = CDate(registro.FecDocRef)
                txtFecDocRef.Text = registro.FecDocRef.ToString
            End If

            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            cmbCondPago.Value = registro.CondicionPagoProveedor.IdCondicion

            DocumentoXml = registro.DocumentoXml
            DocumentoPdf = registro.DocumentoPdf
            NombreArchivo = registro.NombreArchivo
            txtXmlFE.Text = registro.NombreArchivo
            txtPdfFE.Text = registro.NombreArchivo

            txtFecha.Value = registro.Fecha
            txtFecha.Text = registro.Fecha
            txtFecEmision.Value = registro.FecDoc
            txtFecEmision.Text = registro.FecDoc
            txtFecVencimiento.Value = registro.FecVen
            txtFecVencimiento.Text = registro.FecVen
            txtTipCambio.Value = registro.TipCam

            txtGlosa.Text = registro.Glosa

            cmbMoneda.Value = registro.Moneda.CodMon
            rbAnulado.Checked = registro.Anulado
            cbAfectoIgv.Checked = registro.AfectoIgv

            If state_button Then
                lblMontoTotal.Text = "Monto Total  " + cmbMoneda.Text
                lblMontoTotalIgv.Text = "Monto Total I.G.V.  " + cmbMoneda.Text
                lblMontoTotalNoAfecto.Text = "Monto Total No Afecto I.G.V.  " + cmbMoneda.Text
                lblMontoTotalNeto.Text = "Monto Total Neto " + cmbMoneda.Text
            End If
            Solicitud = oRegistroCompraDetService.BuscarSolicitud(IdCompra)

            cbAfectoDetraccion.Checked = registro.AplicaDetraccion
            cmbTipoDetraccion.Value = registro.TipoDetraccion.CodDetraccion
            txtNroPagoDetraccion.Text = registro.NroPagoDetraccion
            If Not (registro.FecPagoDetraccion.ToString = "") Then
                txtFechaPagoDetraccion.Value = CDate(registro.FecPagoDetraccion)
                txtFechaPagoDetraccion.Text = registro.FecPagoDetraccion.ToString
            End If
            If registro.FecPagoDetraccion Is Nothing Then
                txtFechaPagoDetraccion.Text = ""
            End If

            txtNumGasto.Text = IIf(oRegistroCompraDetService.ObtenerIdGasto(IdCompra) = 0, "", oRegistroCompraDetService.ObtenerIdGasto(IdCompra))

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = "(Ninguno)"
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = ""
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Function getRowTodos1(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = ""
        Catch ex As Exception
            fila(2) = ""
        End Try
        Try
            fila(2) = ""
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

    Private Sub LlenarCombos()
        Try

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            dtMonedas.Rows.InsertAt(getRowTodos1(dtMonedas), 0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.SelectedIndex = 0
            dtMonedas = Nothing

            '================================CONDICION DE PAGO PROVEEDOR===================================
            dtCondPago = oProveedorService.MostrarCondicionPago.Tables(0)
            dtCondPago.Rows.InsertAt(getRowTodos1(dtCondPago), 0)
            cmbCondPago.DataSource = dtCondPago
            cmbCondPago.DropDownList.DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCondPago.DropDownList.DisplayMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCondPago.DropDownList.ValueMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCondPago.DropDownList.Columns(0).DataMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCondPago.DropDownList.Columns(1).DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCondPago.DropDownList.Columns(2).DataMember = dtCondPago.Columns("DiasPago").ToString
            cmbCondPago.SelectedIndex = 0
            dtCondPago = Nothing

            '===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oRegistroCompraService.MostrarTipoDocumento().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("CodSunat").ToString
            dtTipDoc = Nothing

            '================================ TIPO DE DOCUMENTO  (REFERENCIA)==================================
            dtTipDoc = oRegistroCompraService.MostrarTipoDocumento().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowTodos(dtTipDoc), 0)
            cmbTipoRef.DataSource = dtTipDoc
            cmbTipoRef.DropDownList.DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoRef.DropDownList.DisplayMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoRef.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoRef.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoRef.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("AbrDoc").ToString
            cmbTipoRef.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoRef.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("CodSunat").ToString
            dtTipDoc = Nothing

            ''===================================== TIPO DETRACCION ============================================
            dtTipoDetraccion = oSolicitudGastoDetService.MostrarTipoDetraccion.Tables(0)
            dtTipoDetraccion.Rows.InsertAt(getRowTodos2(dtTipoDetraccion), 0)
            cmbTipoDetraccion.DataSource = dtTipoDetraccion
            cmbTipoDetraccion.DropDownList.DataMember = dtTipoDetraccion.Columns("Porcentaje").ToString
            cmbTipoDetraccion.DropDownList.DisplayMember = dtTipoDetraccion.Columns("Porcentaje").ToString
            cmbTipoDetraccion.DropDownList.ValueMember = dtTipoDetraccion.Columns("CodDetraccion").ToString
            cmbTipoDetraccion.DropDownList.Columns(0).DataMember = dtTipoDetraccion.Columns("CodDetraccion").ToString
            cmbTipoDetraccion.DropDownList.Columns(1).DataMember = dtTipoDetraccion.Columns("Nombre").ToString
            cmbTipoDetraccion.DropDownList.Columns(2).DataMember = dtTipoDetraccion.Columns("Porcentaje").ToString
            cmbTipoDetraccion.SelectedIndex = 0
            dtTipoDetraccion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Limpiar()
        IdCompra = 0

        cmbTipoDoc.Value = 0
        txtCodTipoDoc.Text = ""
        txtSerieDoc.Text = ""
        txtNumDoc.Text = ""

        cmbTipoRef.Value = 0
        txtCodTipoRef.Text = ""
        txtSerieRef.Text = ""
        txtNumRef.Text = ""
        txtFecDocRef.IsNullDate = True

        IdProveedor = 0
        txtProveedor.Text = ""
        cmbCondPago.SelectedIndex = 0
        txtXmlFE.Text = ""
        txtPdfFE.Text = ""

        txtFecha.IsNullDate = True
        txtFecEmision.IsNullDate = True
        txtFecVencimiento.IsNullDate = True
        txtTipCambio.Value = 0
        txtGlosa.Text = ""

        cmbMoneda.SelectedIndex = 0
        rbAnulado.Checked = False
        cbAfectoIgv.Checked = False

        dgvDatos.DataSource = Nothing
        txtDesCuenta.Text = ""

        txtMontoTotal.Value = 0
        txtMontoTotalIgv.Value = 0
        txtMontoTotalNeto.Value = 0
        txtMontoTotalNoAfecto.Value = 0

        cbAfectoDetraccion.Checked = False
        cmbTipoDetraccion.Value = ""
        txtNroPagoDetraccion.Text = ""
        txtFechaPagoDetraccion.Text = ""

        txtNumGasto.Text = ""

    End Sub

    Private Sub eliminar()
        Try
            If MsgBox("¿Está seguro de ELIMINAR el Registro de Compra Nº : " + txtMesRegistro.Text + " - " + txtNumRegistro.Text + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oRegistroCompraService.Borrar(IdCompra, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Limpiar()
                    ObtenerNumRegistro()
                    state_button = False
                    Desactivar()
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR EL REGISTRO DE COMPRAS :" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As RegistroCompraService.RegistroCompra)
        Try
            Dim estado_process As Integer
            estado_process = oRegistroCompraService.Insertar(registro)
            If estado_process > 0 Then
                IdCompra = estado_process
                'MsgBox("Se inserto el Registro de Compra Correctamente")  ---- Sr. Jesus Alba
                Desactivar()
                ObtenerRegistro()
                state_button = True
                enableOpciones()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR REGISTRO DE COMPRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As RegistroCompraService.RegistroCompra)
        Try
            Dim estado_process As Boolean
            estado_process = oRegistroCompraService.Actualizar(registro)
            If estado_process = True Then
                ObtenerRegistro()
                Desactivar()
                state_button = True
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR REGISTRO DE COMPRA: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(txtMesRegistro.Text) = 0 Then
                MsgBox("Debe Ingresar el número de registro.", MsgBoxStyle.Information, "Información")
                txtMesRegistro.Focus()
                Return False
            ElseIf toNumber(txtNumRegistro.Text) = 0 Then
                MsgBox("Debe Ingresar el número de registro.", MsgBoxStyle.Information, "Información")
                txtNumRegistro.Focus()
                Return False
            ElseIf toNumber(txtCodTipoDoc.Text) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                txtCodTipoDoc.Focus()
                Return False
            ElseIf toNumber(cmbTipoDoc.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.Focus()
                Return False
                'ElseIf txtSerieDoc.Text = "" Then
                '    MsgBox("Debe Ingresar la Serie de Documento.", MsgBoxStyle.Information, "Información")
                '    txtSerieDoc.Focus()
                '    Return False
            ElseIf txtNumDoc.Text = "" Then
                MsgBox("Debe Ingresar el Número de Documento.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf (cmbTipoDoc.Value = 5 Or cmbTipoDoc.Value = 6) And toNumber(txtCodTipoRef.Text) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Documento de la Referencia.", MsgBoxStyle.Information, "Información")
                txtCodTipoRef.Focus()
                Return False
            ElseIf (cmbTipoDoc.Value = 5 Or cmbTipoDoc.Value = 6) And toNumber(cmbTipoRef.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Documento de la Referencia.", MsgBoxStyle.Information, "Información")
                cmbTipoRef.Focus()
                Return False
            ElseIf (cmbTipoDoc.Value = 5 Or cmbTipoDoc.Value = 6) And txtSerieRef.Text = "" Then
                MsgBox("Debe Ingresar la Serie de Documento de la Referencia.", MsgBoxStyle.Information, "Información")
                txtSerieRef.Focus()
                Return False
            ElseIf (cmbTipoDoc.Value = 5 Or cmbTipoDoc.Value = 6) And txtNumRef.Text = "" Then
                MsgBox("Debe Ingresar el Número de Documento de la Referencia.", MsgBoxStyle.Information, "Información")
                txtNumRef.Focus()
                Return False
            ElseIf (cmbTipoDoc.Value = 5 Or cmbTipoDoc.Value = 6) And toBlank(txtFecDocRef.Value) = "" Then
                MsgBox("Debe Ingresar la Fecha de Documento de la Referencia.", MsgBoxStyle.Information, "Información")
                txtFecDocRef.Focus()
                Return False
            ElseIf IdProveedor = 0 Then
                MsgBox("Debe Ingresar el Proveedor.", MsgBoxStyle.Information, "Información")
                txtProveedor.Focus()
                Return False
            ElseIf toNumber(cmbCondPago.Value) = 0 Then
                MsgBox("Debe Ingresar la Condición de Pago.", MsgBoxStyle.Information, "Información")
                cmbCondPago.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(txtFecEmision.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Emisión.", MsgBoxStyle.Information, "Información")
                txtFecEmision.Focus()
                Return False
            ElseIf toBlank(txtFecVencimiento.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Vencimiento.", MsgBoxStyle.Information, "Información")
                txtFecVencimiento.Focus()
                Return False
            ElseIf toDouble(txtTipCambio.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCambio.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.Focus()
                Return False
                'ElseIf rbActivo.Checked = False And rbAnulado.Checked = False Then
                '    MsgBox("Debe Ingresar el Estado.", MsgBoxStyle.Information, "Información")
                '    rbActivo.Focus()
                '    Return False
                'ElseIf toNumber(cmbTipoCompra.Value) = 0 Then
                '    MsgBox("Debe Ingresar el Tipo de Compra.", MsgBoxStyle.Information, "Información")
                '    cmbTipoCompra.Focus()
                '    Return False
            ElseIf oMaestroService.MostrarTipoCambio("US", txtFecha.Text) = 0 Then
                MsgBox("Esta Fecha no tiene Tipo de Cambio, Verifique", MsgBoxStyle.Information, "Información")
                txtFecha.Focus()
                Return False
            ElseIf toBlank(txtXmlFE.Text) = "" And toBlank(txtPdfFE.Text) <> "" Then
                MsgBox("Debe Ingresar el Documento Xml y el Documento Pdf.", MsgBoxStyle.Information, "Información")
                txtXmlFE.Focus()
                Return False
            ElseIf toBlank(txtXmlFE.Text) <> "" And toBlank(txtPdfFE.Text) = "" Then
                MsgBox("Debe Ingresar el Documento Xml y el Documento Pdf.", MsgBoxStyle.Information, "Información")
                txtPdfFE.Focus()
                Return False
            ElseIf oProveedorService.ObtenerEmiteFacturaDigital(IdProveedor) And (toBlank(txtXmlFE.Text) = "" And toBlank(txtPdfFE.Text) = "") Then
                'ElseIf False And (toBlank(txtXmlFE.Text) = "" Or toBlank(txtPdfFE.Text) = "") Then
                MsgBox("Debe Ingresar el Documento Xml y el Documento Pdf.", MsgBoxStyle.Information, "Información")
                txtPdfFE.Focus()
                Return False
            ElseIf toBlank(txtNroPagoDetraccion.Text) = "" And cbAfectoDetraccion.Checked = True Then
                MsgBox("Debe Ingresar el Número de pago de la detracción.", MsgBoxStyle.Information, "Información")
                txtNroPagoDetraccion.Focus()
                Return False
            ElseIf cmbTipoDetraccion.Value = "" And cbAfectoDetraccion.Checked = True Then
                MsgBox("Debe Ingresar el tipo de detracción", MsgBoxStyle.Information, "Información")
                txtNroPagoDetraccion.Focus()
                Return False
            ElseIf toBlank(txtFechaPagoDetraccion.Text) = "" And cbAfectoDetraccion.Checked = True Then
                MsgBox("Debe Ingresar la fecha de pago de la detracción.", MsgBoxStyle.Information, "Información")
                txtNroPagoDetraccion.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub txtMesRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMesRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If Len(Trim(txtMesRegistro.Text)) > 0 Then
                Dim cant As Integer = Len(txtMesRegistro.Text)
                If cant < 2 Then
                    txtMesRegistro.Text = "0" & txtMesRegistro.Text
                End If
                If toNumber(txtMesRegistro.Text) < 0 Or toNumber(txtMesRegistro.Text) > 12 Then
                    MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
                    txtMesRegistro.Text = ""
                    txtMesRegistro.Focus()
                Else
                    ObtenerNumRegistro()
                End If
            Else
                MsgBox("Debe ingresar el Mes de Registro", MsgBoxStyle.Critical, "No Existe")
                txtMesRegistro.Focus()
            End If
        End If
    End Sub

    Private Sub txtNumRegistro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumRegistro.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarRegistro.Enabled = True Then
                e.Handled = True
                btnBuscarRegistro_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtMesRegistro_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Validated
        If Len(Trim(txtMesRegistro.Text)) > 0 Then
            Dim cant As Integer = Len(txtMesRegistro.Text)
            If cant < 2 Then
                txtMesRegistro.Text = "0" & txtMesRegistro.Text
            End If
            If toNumber(txtMesRegistro.Text) = 0 Or toNumber(txtMesRegistro.Text) > 12 Then
                MsgBox("Rango del Mes de Registro [01 - 12]", MsgBoxStyle.Critical, "Error de Datos")
            Else
                ObtenerNumRegistro()
            End If
        Else
            MsgBox("Debe ingresar el Mes de Registro", MsgBoxStyle.Critical, "No Existe")
            txtMesRegistro.Focus()
        End If
    End Sub

    Private Sub txtNumRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRegistro.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If Len(Trim(txtNumRegistro.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumRegistro.Text)
                Do While cant < 6
                    txtNumRegistro.Text = "0" & txtNumRegistro.Text
                    cant = cant + 1
                Loop
                If oRegistroCompraService.Buscar(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistro.Text) Then   'If BuscarNumRegistro(txtMesRegistro,txtNumRegistro) Then  
                    IdCompra = oRegistroCompraService.ObtenerIdCompra(Session.sCodEmp, txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistro.Text)
                    state_button = True 'Modificar
                    edicion = False
                    ObtenerRegistro()
                    actualizarDetalles()
                    Desactivar()
                    txtNumRegistro.SelectAll()
                Else
                    state_button = False 'Nuevo 
                    edicion = True
                    Limpiar()
                    Activar()
                    txtCodTipoDoc.Focus()
                End If
            Else
                MsgBox("Debe ingresar el Numero de Registro", MsgBoxStyle.Critical, "No Existe")
                txtNumRegistro.Focus()
            End If
        End If
    End Sub

    'Private Sub txtNumRegistro_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumRegistro.Validated
    '    If Len(Trim(txtNumRegistro.Text)) > 0 Then
    '        Dim cant As Integer = Len(txtNumRegistro.Text)
    '        Do While cant < 6
    '            txtNumRegistro.Text = "0" & txtNumRegistro.Text
    '            cant = cant + 1
    '        Loop
    '        If oRegistroCompraService.Buscar(Today.Year, txtMesRegistro.Text, txtNumRegistro.Text) Then   'If BuscarNumRegistro(txtMesRegistro,txtNumRegistro) Then  
    '            IdCompra = oRegistroCompraService.ObtenerIdCompra(txtPeriodo.Value, txtMesRegistro.Text, txtNumRegistro.Text)
    '            state_button = True 'Modificar
    '            edicion = False
    '            ObtenerRegistro()
    '            actualizarDetalles()
    '            Desactivar()
    '            txtNumRegistro.SelectAll()
    '        Else
    '            state_button = False 'Nuevo 
    '            edicion = True
    '            Limpiar()
    '            Activar()
    '            txtCodTipoDoc.Focus()
    '        End If
    '    Else
    '        MsgBox("Debe ingresar el Numero de Registro", MsgBoxStyle.Critical, "No Existe")
    '        txtNumRegistro.Focus()
    '    End If
    'End Sub

    Private Sub txtCodTipoDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodTipoDoc.Click
        txtCodTipoDoc.SelectAll()
    End Sub

    Private Sub txtCodTipoDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodTipoDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            Try
                If Len(Trim(txtCodTipoDoc.Text)) > 0 Then
                    Dim cant As Integer = Len(txtCodTipoDoc.Text)
                    Do While cant < 2
                        txtCodTipoDoc.Text = "0" & txtCodTipoDoc.Text
                        cant = cant + 1
                    Loop

                    Dim IdDocumento As Integer
                    Dim TipoDoc As String = txtCodTipoDoc.Text
                    IdDocumento = CInt(oMaestroService.MostrarDato("Maestro.TipoDocumento", "IdDocumento", "CodSunat", Trim(txtCodTipoDoc.Text)))
                    If IdDocumento <> 0 Then
                        cmbTipoDoc.Value = IdDocumento
                        txtCodTipoDoc.Text = TipoDoc
                        txtSerieDoc.Focus()
                    Else
                        MsgBox("¡Codigo no Existe, Verifique...!", MsgBoxStyle.Critical, "No Existe")
                        cmbTipoDoc.SelectedIndex = 0
                        txtCodTipoDoc.Text = ""
                        txtCodTipoDoc.Focus()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    'Private Sub txtCodTipoDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodTipoDoc.Validated
    '    Try
    '        If Len(Trim(txtCodTipoDoc.Text)) > 0 Then
    '            Dim cant As Integer = Len(txtCodTipoDoc.Text)
    '            Do While cant < 2
    '                txtCodTipoDoc.Text = "0" & txtCodTipoDoc.Text
    '                cant = cant + 1
    '            Loop

    '            Dim IdDocumento As Integer
    '            IdDocumento = CInt(oMaestroService.MostrarDato("Maestro.TipoDocumento", "IdDocumento", "CodSunat", Trim(txtCodTipoDoc.Text)))
    '            If IdDocumento <> 0 Then
    '                cmbTipoDoc.Value = IdDocumento
    '                txtSerieDoc.Focus()
    '            Else
    '                MsgBox("Codigo no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
    '                cmbTipoDoc.SelectedIndex = 0
    '                txtCodTipoDoc.Text = ""
    '                txtCodTipoDoc.Focus()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    Private Sub txtProveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProveedor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbCondPago.Focus()
        End If
    End Sub

    Private Sub txtSerieDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Click
        txtSerieDoc.SelectAll()
    End Sub

    Private Sub txtSerieDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtSerieDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtSerieDoc.Text)
                Do While cant < 4
                    txtSerieDoc.Text = "0" & txtSerieDoc.Text
                    cant = cant + 1
                Loop
                txtNumDoc.Focus()
            End If
        End If
    End Sub

    'Private Sub txtSerieDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Validated
    '    If Len(Trim(txtSerieDoc.Text)) > 0 Then
    '        Dim cant As Integer = Len(txtSerieDoc.Text)
    '        Do While cant < 4
    '            txtSerieDoc.Text = "0" & txtSerieDoc.Text
    '            cant = cant + 1
    '        Loop
    '        txtNumDoc.Focus()
    '    End If
    'End Sub

    Private Sub txtNumDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Click
        txtNumDoc.SelectAll()
    End Sub

    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumDoc.Text)
                Do While cant < 8
                    txtNumDoc.Text = "0" & txtNumDoc.Text
                    cant = cant + 1
                Loop
                If cmbTipoDoc.Value = 5 Or cmbTipoDoc.Value = 6 Then
                    txtCodTipoRef.Focus()
                Else
                    txtProveedor.Focus()
                End If
            End If
        End If
    End Sub

    'Private Sub txtNumDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Validated
    '    If Len(Trim(txtNumDoc.Text)) > 0 Then
    '        Dim cant As Integer = Len(txtNumDoc.Text)
    '        Do While cant < 10
    '            txtNumDoc.Text = "0" & txtNumDoc.Text
    '            cant = cant + 1
    '        Loop
    '        If cmbTipoDoc.Value = 5 Or cmbTipoDoc.Value = 6 Then
    '            txtCodTipoRef.Focus()
    '        Else
    '            txtProveedor.Focus()
    '        End If
    '    End If
    'End Sub

    Private Sub txtCodTipoRef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodTipoRef.Click
        txtCodTipoRef.SelectAll()
    End Sub

    Private Sub txtCodTipoRef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodTipoRef.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            Try
                If Len(Trim(txtCodTipoRef.Text)) > 0 Then
                    Dim cant As Integer = Len(txtCodTipoRef.Text)
                    Do While cant < 2
                        txtCodTipoRef.Text = "0" & txtCodTipoRef.Text
                        cant = cant + 1
                    Loop

                    Dim IdDocumento As Integer
                    Dim CodTipoRef As String = txtCodTipoRef.Text
                    IdDocumento = CInt(oMaestroService.MostrarDato("Maestro.TipoDocumento", "IdDocumento", "CodSunat", Trim(txtCodTipoRef.Text)))
                    If IdDocumento <> 0 Then
                        cmbTipoRef.Value = IdDocumento
                        txtCodTipoRef.Text = CodTipoRef
                        txtSerieRef.Focus()
                    Else
                        MsgBox("¡Codigo no Existe, Verifique...!", MsgBoxStyle.Critical, "No Existe")
                        cmbTipoRef.SelectedIndex = 0
                        txtCodTipoRef.Text = ""
                        txtCodTipoRef.Focus()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    'Private Sub txtCodTipoRef_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodTipoRef.Validated
    '    Try
    '        If Len(Trim(txtCodTipoRef.Text)) > 0 Then
    '            Dim cant As Integer = Len(txtCodTipoRef.Text)
    '            Do While cant < 2
    '                txtCodTipoRef.Text = "0" & txtCodTipoRef.Text
    '                cant = cant + 1
    '            Loop

    '            Dim IdDocumento As Integer
    '            IdDocumento = CInt(oMaestroService.MostrarDato("Maestro.TipoDocumento", "IdDocumento", "CodSunat", Trim(txtCodTipoRef.Text)))
    '            If IdDocumento <> 0 Then
    '                cmbTipoRef.Value = IdDocumento
    '                txtSerieRef.Focus()
    '            Else
    '                MsgBox("Codigo no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
    '                cmbTipoRef.SelectedIndex = 0
    '                txtCodTipoRef.Text = ""
    '                txtCodTipoRef.Focus()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    Private Sub txtSerieRef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieRef.Click
        txtSerieRef.SelectAll()
    End Sub

    Private Sub txtSerieRef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerieRef.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtSerieRef.Text)) > 0 Then
                Dim cant As Integer = Len(txtSerieRef.Text)
                Do While cant < 4
                    txtSerieRef.Text = "0" & txtSerieRef.Text
                    cant = cant + 1
                Loop
                txtNumRef.Focus()
            End If
        End If
    End Sub

    'Private Sub txtSerieRef_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieRef.Validated
    '    If Len(Trim(txtSerieRef.Text)) > 0 Then
    '        Dim cant As Integer = Len(txtSerieRef.Text)
    '        Do While cant < 4
    '            txtSerieRef.Text = "0" & txtSerieRef.Text
    '            cant = cant + 1
    '        Loop
    '        txtNumRef.Focus()
    '    End If
    'End Sub

    Private Sub txtNumRef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumRef.Click
        txtNumRef.SelectAll()
    End Sub

    Private Sub txtNumRef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRef.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            If Len(Trim(txtNumRef.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumRef.Text)
                Do While cant < 8
                    txtNumRef.Text = "0" & txtNumRef.Text
                    cant = cant + 1
                Loop
                txtFecDocRef.Value = Today
                txtFecDocRef.Text = Today
                txtFecDocRef.Focus()
            End If
        End If
    End Sub

    'Private Sub txtNumRef_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumRef.Validated
    '    If Len(Trim(txtNumRef.Text)) > 0 Then
    '        Dim cant As Integer = Len(txtNumRef.Text)
    '        Do While cant < 10
    '            txtNumRef.Text = "0" & txtNumRef.Text
    '            cant = cant + 1
    '        Loop
    '        txtFecDocRef.Value = Today
    '        txtFecDocRef.Text = Today
    '        txtFecDocRef.Focus()
    '    End If
    'End Sub

    Private Sub txtFecDocRef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecDocRef.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub cmbCondPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCondPago.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtFecha.Focus()
        End If
    End Sub

    Private Sub txtFecha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtFecEmision.Focus()
        End If
    End Sub

    Private Sub txtFecEmision_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecEmision.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtFecVencimiento.Focus()
        End If
    End Sub

    Private Sub txtFecVencimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecVencimiento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtTipCambio.Focus()
        End If
    End Sub

    Private Sub txtTipCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipCambio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtGlosa.Focus()
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                e.Handled = True
                btnBuscarProveedor_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oRegistroCompraDetService.Mostrar(toNumber(IdCompra)).Tables(0)
            dgvDatos.DataSource = dtDatos
            enableOpciones()
            If dgvDatos.RowCount > 0 Then
                If cmbMoneda.Value = "NS" Then
                    SumarMontos("Sol")
                ElseIf cmbMoneda.Value = "US" Then
                    SumarMontos("Dol")
                End If
                txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
                InhabilitarColumnas()
            Else
                txtDesCuenta.Text = ""
            End If
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SumarMontos(ByVal Moneda As String)
        Try
            Dim MontoTotal As Double = 0
            Dim row As Janus.Windows.GridEX.GridEXRow
            Dim Monto As Boolean

            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row = Me.dgvDatos.GetRow()
                Monto = row.Cells("Monto" + Moneda).Value
                If Monto Then
                    MontoTotal = MontoTotal + CDbl(Me.dgvDatos.CurrentRow.Cells("Monto" + Moneda).Value)
                End If
            Next
            txtMontoTotal.Value = MontoTotal

            Dim MontoTotalIgv As Double = 0
            Dim row1 As Janus.Windows.GridEX.GridEXRow
            Dim MontoIgv As Boolean

            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row1 = Me.dgvDatos.GetRow()
                MontoIgv = row1.Cells("MontoIgv" + Moneda).Value
                If MontoIgv Then
                    MontoTotalIgv = MontoTotalIgv + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoIgv" + Moneda).Value)
                End If
            Next
            txtMontoTotalIgv.Value = MontoTotalIgv

            Dim MontoTotalNoAfecto As Double = 0
            Dim row2 As Janus.Windows.GridEX.GridEXRow
            Dim MontoNoAfecto As Boolean

            For i = 0 To Me.dgvDatos.RowCount - 1
                Me.dgvDatos.Row = i
                row2 = Me.dgvDatos.GetRow()
                MontoNoAfecto = row2.Cells("MontoNoAfecto" + Moneda).Value
                If MontoNoAfecto Then
                    MontoTotalNoAfecto = MontoTotalNoAfecto + CDbl(Me.dgvDatos.CurrentRow.Cells("MontoNoAfecto" + Moneda).Value)
                End If
            Next
            txtMontoTotalNoAfecto.Value = MontoTotalNoAfecto

            txtMontoTotalNeto.Value = MontoTotal + MontoTotalIgv + MontoTotalNoAfecto

        Catch ex As Exception
            MsgBox("ERROR AL SUMAR MONTOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub InhabilitarColumnas()
        Try
            If cmbMoneda.Value = "NS" Then
                dgvDatos.RootTable.Columns(4).Visible = True
                dgvDatos.RootTable.Columns(5).Visible = True
                dgvDatos.RootTable.Columns(6).Visible = True
                dgvDatos.RootTable.Columns(7).Visible = True

                dgvDatos.RootTable.Columns(8).Visible = False
                dgvDatos.RootTable.Columns(9).Visible = False
                dgvDatos.RootTable.Columns(10).Visible = False
                dgvDatos.RootTable.Columns(11).Visible = False
            ElseIf cmbMoneda.Value = "US" Then
                dgvDatos.RootTable.Columns(4).Visible = False
                dgvDatos.RootTable.Columns(5).Visible = False
                dgvDatos.RootTable.Columns(6).Visible = False
                dgvDatos.RootTable.Columns(7).Visible = False

                dgvDatos.RootTable.Columns(8).Visible = True
                dgvDatos.RootTable.Columns(9).Visible = True
                dgvDatos.RootTable.Columns(10).Visible = True
                dgvDatos.RootTable.Columns(11).Visible = True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INHABILITAR COLUMNAS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            'If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then  --- Sr. Jesus Alba
            If ValidaCampos() Then
                Dim registro As New RegistroCompraService.RegistroCompra
                Dim TipoDocumento As New RegistroCompraService.TipoDocumento
                Dim TipoDocumentoRef As New RegistroCompraService.TipoDocumento
                Dim proveedor As New RegistroCompraService.Proveedor
                Dim CondicionPago As New RegistroCompraService.CondicionPagoProveedor
                Dim Moneda As New RegistroCompraService.Moneda
                Dim empresa As New RegistroCompraService.Empresa
                Dim tipoDetraccion As New RegistroCompraService.TipoDetraccion

                registro.IdCompra = IdCompra
                registro.Mes = txtMesRegistro.Text
                registro.NumRegistro = txtNumRegistro.Text
                registro.Igv = txtIgv.Value
                TipoDocumento.IdDocumento = cmbTipoDoc.Value
                registro.TipoDocumento = TipoDocumento
                registro.SerDoc = IIf(txtSerieDoc.Text = "", Nothing, txtSerieDoc.Text)
                registro.NumDoc = txtNumDoc.Text

                TipoDocumentoRef.IdDocumento = IIf(cmbTipoRef.SelectedIndex = 0, Nothing, cmbTipoRef.Value)
                registro.TipoDocumentoRef = TipoDocumentoRef
                registro.SerDocRef = IIf(txtSerieRef.Text = "", Nothing, txtSerieRef.Text)
                registro.NumDocRef = IIf(txtNumRef.Text = "", Nothing, txtNumRef.Text)
                registro.FecDocRef = IIf(txtFecDocRef.Text = "", Nothing, txtFecDocRef.Value)
                proveedor.IdProveedor = IdProveedor
                registro.Proveedor = proveedor
                CondicionPago.IdCondicion = cmbCondPago.Value
                registro.CondicionPagoProveedor = CondicionPago
                registro.Fecha = txtFecha.Value
                registro.FecDoc = txtFecEmision.Value
                registro.FecVen = txtFecVencimiento.Value
                registro.TipCam = txtTipCambio.Value
                registro.Glosa = txtGlosa.Text
                Moneda.CodMon = cmbMoneda.Value
                registro.Moneda = Moneda
                registro.Anulado = IIf(rbAnulado.Checked = True, True, False)
                registro.AfectoIgv = cbAfectoIgv.Checked

                '----------------------------------------------------------------------------------------------------
                Dim xmlDoc As New XmlDocument

                Dim count As Integer
                count = txtXmlFE.Text.Split("\").Length - 1
                If count < 1 Then

                    registro.DocumentoXml = IIf(txtXmlFE.Text = "", Nothing, DocumentoXml)
                    registro.DocumentoPdf = IIf(txtPdfFE.Text = "", Nothing, DocumentoPdf)
                    registro.NombreArchivo = IIf(txtXmlFE.Text = "", Nothing, NombreArchivo)
                Else
                    If txtXmlFE.Text <> "" Then
                        xmlDoc.Load(txtXmlFE.Text)
                    End If

                    If txtPdfFE.Text <> "" Then
                        Dim rutapdf As New FileStream(txtPdfFE.Text, FileMode.Open, FileAccess.Read)
                        Dim binarioPDF(rutapdf.Length) As Byte
                        rutapdf.Read(binarioPDF, 0, rutapdf.Length) 'Leo el archivo y lo convierto a binario
                        rutapdf.Close()
                        registro.DocumentoPdf = IIf(txtPdfFE.Text = "", Nothing, binarioPDF)
                    End If
                    registro.DocumentoXml = IIf(txtXmlFE.Text = "", Nothing, xmlDoc.OuterXml)
                    registro.NombreArchivo = NombreArchivo
                End If
                '-------------------------------------------------------------------------------------------

                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa
                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.FecReg = Today
                registro.Periodo = txtPeriodo.Value

                registro.AplicaDetraccion = cbAfectoDetraccion.Checked
                tipoDetraccion.CodDetraccion = IIf(cmbTipoDetraccion.Value = "", Nothing, cmbTipoDetraccion.Value)
                registro.TipoDetraccion = tipoDetraccion
                registro.NroPagoDetraccion = toNull(txtNroPagoDetraccion.Text)
                registro.FecPagoDetraccion = IIf(txtFechaPagoDetraccion.Text = "", Nothing, txtFechaPagoDetraccion.Value)



                If state_button Then        'Modificar
                    Modificar(registro)
                Else                              'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biEditarr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Sub biEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminar()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        Limpiar()
        ObtenerNumRegistro()
        Desactivar()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAgregarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarProveedor.Click
        Try
            Dim frm As New frmProveedor
            frm.state_button = False
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdProveedor = frm.IdProveedor
                txtProveedor.Text = frm.DesProv
            End If
        Catch ex As Exception
            MsgBox("Error al agregar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    cmbCondPago.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar el Proveedor : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarRegistro.Click
        Try
            Dim frm As New frmBuscarRegCompras
            frm.txtMesRegistro.Text = txtMesRegistro.Text
            frm.txtPeriodo.Value = txtPeriodo.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.IdCompra) <> Nothing Then
                    IdCompra = frm.IdCompra
                    ObtenerRegistro()
                    actualizarDetalles()
                    state_button = True
                    edicion = False
                    Desactivar()
                Else
                    IdCompra = 0
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar el Registro de Compra : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtMesRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMesRegistro.Click
        txtMesRegistro.SelectAll()
    End Sub

    Private Sub txtNumRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumRegistro.Click
        ObtenerNumRegistro()
        state_button = False
        Limpiar()
        Desactivar()
    End Sub

    Private Sub txtProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProveedor.TextChanged
        If txtProveedor.Text <> "" Then
            Dim proveedor As ProveedorService.Proveedor
            proveedor = oProveedorService.Obtener(IdProveedor)
            If proveedor.CondicionPagoProveedor.IdCondicion <> 0 Then
                cmbCondPago.Value = proveedor.CondicionPagoProveedor.IdCondicion
            End If
        End If
    End Sub

    Private Sub cmbTipoDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtSerieDoc.Focus()
        End If
    End Sub

    Private Sub cmbTipoDoc_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoDoc.ValueChanged
        txtCodTipoDoc.Text = IIf(cmbTipoDoc.Value = 0, "", cmbTipoDoc.DropDownList.GetRow.Cells(3).Text)
        If cmbTipoDoc.Value = 5 Or cmbTipoDoc.Value = 6 Then
            txtCodTipoRef.ReadOnly = False
            txtCodTipoRef.BackColor = System.Drawing.SystemColors.Window
            cmbTipoRef.ReadOnly = False
            cmbTipoRef.BackColor = System.Drawing.SystemColors.Window
            txtSerieRef.ReadOnly = False
            txtSerieRef.BackColor = System.Drawing.SystemColors.Window
            txtNumRef.ReadOnly = False
            txtNumRef.BackColor = System.Drawing.SystemColors.Window
            txtFecDocRef.ReadOnly = False
            txtFecDocRef.BackColor = System.Drawing.SystemColors.Window
        Else
            txtCodTipoRef.ReadOnly = True
            txtCodTipoRef.BackColor = System.Drawing.SystemColors.Control
            txtCodTipoRef.Text = ""
            cmbTipoRef.ReadOnly = True
            cmbTipoRef.BackColor = System.Drawing.SystemColors.Control
            cmbTipoRef.SelectedIndex = 0
            txtSerieRef.ReadOnly = True
            txtSerieRef.BackColor = System.Drawing.SystemColors.Control
            txtSerieRef.Text = ""
            txtNumRef.ReadOnly = True
            txtNumRef.BackColor = System.Drawing.SystemColors.Control
            txtNumRef.Text = ""
            txtFecDocRef.IsNullDate = True
            txtFecDocRef.ReadOnly = True
            txtFecDocRef.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If IdCompra = 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub Nuevo()
        Try
            Dim frm As New frmRegComprasDet
            frm.state_button = False
            frm.editable = True
            frm.edicion = True
            frm.IdCompra = IdCompra
            frm.iSolicitud = oRegistroCompraDetService.BuscarSolicitud(IdCompra)
            frm.CodMon = cmbMoneda.Value
            frm.AfectoIgv = cbAfectoIgv.Checked
            frm.TipoCambio = txtTipCambio.Value
            frm.Igv = txtIgv.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                If frm.type_process = "insert" Then
                    RowPossesion(dgvDatos, frm.IdCompraDet)
                    Mostrar()
                    actualizarDetalles()
                End If
                enableOpciones()
            End If


            'Dim lLog As Boolean = True
            'While lLog
            '    Dim frm As New frmRegComprasDet
            '    frm.state_button = False
            '    frm.IdCompra = IdCompra
            '    frm.iSolicitud = oRegistroCompraDetService.BuscarSolicitud(IdCompra)
            '    frm.CodMon = cmbMoneda.Value
            '    frm.AfectoIgv = cbAfectoIgv.Checked
            '    frm.TipoCambio = txtTipCambio.Value
            '    frm.Igv = txtIgv.Value
            '    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            '        dtDatos = Nothing
            '        listaDatos()
            '        If frm.type_process = "insert" Then
            '            RowPossesion(dgvDatos, frm.IdCompraDet)
            '        End If
            '    Else
            '        lLog = False
            '    End If
            'End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Mostrar()
        Try
            Dim frm As New frmRegComprasDet
            frm.state_button = True
            frm.editable = True
            frm.edicion = False
            frm.iSolicitud = oRegistroCompraDetService.BuscarSolicitud(IdCompra)
            frm.IdCompraDet = dgvDatos.CurrentRow.Cells("IdCompraDet").Text
            frm.IdCompra = IdCompra
            frm.CodMon = cmbMoneda.Value
            frm.AfectoIgv = cbAfectoIgv.Checked
            frm.TipoCambio = txtTipCambio.Value
            frm.Igv = txtIgv.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                If frm.type_process = "update" Then
                    listaDatos()
                    RowPossesion(dgvDatos, frm.IdCompraDet)
                Else
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            actualizarDetalles()
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oRegistroCompraDetService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdCompraDet").Text), IdCompra, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        Nuevo()
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizarDetalles()
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionadoDet() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub miDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDuplicar.Click
        If ValidaCodigoSeleccionadoDet() Then
            Duplicar()
        End If
    End Sub

    Private Sub Duplicar()
        Try
            Dim estado_process As Integer
            Dim IdCompraDet As Integer
            estado_process = oRegistroCompraDetService.Duplicar(toNumber(dgvDatos.CurrentRow.Cells("IdCompraDet").Value), IdCompra, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            If estado_process > 0 Then
                IdCompraDet = estado_process
                ObtenerRegistro()
                listaDatos()
                RowPossesion(dgvDatos, IdCompraDet)
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DUPLICAR DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If ValidaCodigoSeleccionadoDet() Then
            Mostrar()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDatos.RowCount > 0 Then
                miMostrar_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Function ValidaCodigoSeleccionadoDet() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro ...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.SelectionChanged
        If dgvDatos.RowCount > 0 Then
            txtDesCuenta.Text = Trim(dgvDatos.CurrentRow.Cells("NomCuenta").Text)
        Else
            txtDesCuenta.Text = ""
        End If
    End Sub

    Private Sub cmbTipoRef_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoRef.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtSerieRef.Focus()
        End If
    End Sub

    Private Sub cmbTipoRef_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoRef.ValueChanged
        txtCodTipoRef.Text = IIf(cmbTipoRef.Value = 0, "", cmbTipoRef.DropDownList.GetRow.Cells(3).Text)
    End Sub

    Private Sub cmbMoneda_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMoneda.ValueChanged
        InhabilitarColumnas()
    End Sub

    Private Sub biImportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImportar.Click
        Try
            Dim frm As New frmRegComprasImpDoc
            frm.Periodo = txtPeriodo.Value
            frm.MesRegistro = txtMesRegistro.Text
            frm.NumRegistro = txtNumRegistro.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.IdCompra) <> Nothing Then
                    IdCompra = frm.IdCompra
                    ObtenerRegistro()
                    actualizarDetalles()
                    state_button = True
                    edicion = False
                    Desactivar()
                Else
                    IdCompra = 0
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al Importar el Documento : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtGlosa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGlosa.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            cmbMoneda.Focus()
        End If
    End Sub

    Private Sub txtPeriodo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeriodo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            e.Handled = True
            txtMesRegistro.Focus()
        End If
    End Sub

    Private Sub txtFecEmision_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecEmision.ValueChanged
        If toBlank(txtFecEmision.Text) <> "" Then
            txtTipCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbMoneda.Value, txtFecEmision.Value)), "#0.000")
        End If
    End Sub

    Private Sub biImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biImprimir.Click
        Try
            Dim forma As New frmReportes
            Dim dtReporte As New DataTable
            Dim reporte As New rptRegistroCompras

            If IdCompra <> 0 Then
                dtReporte = oRegistroCompraService.Imprimir(IdCompra).Tables(0)

                If dtReporte.Rows.Count = 0 Then
                    MsgBox("No hay datos a mostrar")
                Else
                    reporte.SetDataSource(dtReporte)
                    forma.crvReportes.ReportSource = reporte
                    ' Validar Usuario - Exportar Excel
                    If oSeguridadService.ObtenerExpDatos(Session.sCodUsu) Then
                        forma.crvReportes.ShowExportButton = True
                    Else
                        forma.crvReportes.ShowExportButton = False
                    End If
                    forma.crvReportes.DisplayGroupTree = False
                    'reporte.SetParameterValue("pIdMesa", 0)
                    forma.Text = "Reporte de Registro de Compra"
                    forma.ShowDialog()
                End If
            Else
                MsgBox("Número de Registro de Compra Invalido.!!!!!!", MsgBoxStyle.Information, "No hay datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Reporte")
        End Try

    End Sub

    Private Sub btnBuscarXml_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarXml.Click
        Dim file As New OpenFileDialog()
        file.Filter = "XML|*.xml"
        If file.ShowDialog() = DialogResult.OK Then
            txtXmlFE.Text = file.FileName
            NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
        End If
    End Sub

    Private Sub btnBuscarPdf_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarPdf.Click
        Dim file As New OpenFileDialog()
        file.Filter = "PDF|*.pdf"
        If file.ShowDialog() = DialogResult.OK Then
            txtPdfFE.Text = file.FileName
        End If
    End Sub

    Private Sub btnLimpiarXml_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarXml.Click
        txtXmlFE.Text = ""
    End Sub

    Private Sub btnLimpiarPdf_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarPdf.Click
        txtPdfFE.Text = ""
    End Sub

    Private Sub btnDescargarXml_Click(sender As System.Object, e As System.EventArgs) Handles btnDescargarXml.Click
        Try

            If oRegistroCompraService.BuscarXml(IdCompra) = True Then
                Dim xmlDoc As New XmlDocument
                xmlDoc.Load(New StringReader(oRegistroCompraService.DescargarXml(IdCompra)))

                Dim NombreXMLPDF As String = oRegistroCompraService.ObtenerNombre(IdCompra)
                Dim Ubicacion As String

                Dim file As New SaveFileDialog()
                file.FileName = NombreXMLPDF
                file.Filter = "XML|*.xml"
                If file.ShowDialog() = DialogResult.OK Then
                    Ubicacion = file.FileName

                End If

                xmlDoc.Save(Ubicacion)
            Else
                MsgBox("No existe Documento XML, verifique...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DESCARGAR XML:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnDescargarPdf_Click(sender As System.Object, e As System.EventArgs) Handles btnDescargarPdf.Click
        Try
            If oRegistroCompraService.BuscarXml(IdCompra) = True Then
                Dim PdfByte As Byte() = oRegistroCompraService.DescargarPdf(IdCompra)

                Dim NombreXMLPDF As String = oRegistroCompraService.ObtenerNombre(IdCompra)
                Dim Ubicacion As String

                Dim file As New SaveFileDialog()
                file.FileName = NombreXMLPDF
                file.Filter = "PDF|*.pdf"
                If file.ShowDialog() = DialogResult.OK Then
                    Ubicacion = file.FileName
                End If
                System.IO.File.WriteAllBytes(Ubicacion, PdfByte)
            Else
                MsgBox("No existe Documento XML, verifique...", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL DESCARGAR PDF:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cbAfectoDetraccion_CheckedChanged(sender As Object, e As EventArgs) Handles cbAfectoDetraccion.CheckedChanged
        If cbAfectoDetraccion.Checked Then

            cmbTipoDetraccion.ReadOnly = False
            cmbTipoDetraccion.BackColor = System.Drawing.SystemColors.Window

            'txtNroPagoDetraccion.Text = ""
            txtNroPagoDetraccion.ReadOnly = False
            txtNroPagoDetraccion.BackColor = System.Drawing.SystemColors.Window

            'txtFechaPagoDetraccion.Value = Today
            txtFechaPagoDetraccion.ReadOnly = False
            txtFechaPagoDetraccion.BackColor = System.Drawing.SystemColors.Window

        Else
            cmbTipoDetraccion.ReadOnly = True
            cmbTipoDetraccion.BackColor = System.Drawing.SystemColors.Control
            cmbTipoDetraccion.Value = ""

            txtNroPagoDetraccion.Text = ""
            txtNroPagoDetraccion.ReadOnly = True
            txtNroPagoDetraccion.BackColor = System.Drawing.SystemColors.Control

            txtFechaPagoDetraccion.Text = ""
            txtFechaPagoDetraccion.ReadOnly = True
            txtFechaPagoDetraccion.BackColor = System.Drawing.SystemColors.Control


        End If
    End Sub

    Private Sub txtNumDoc_Validated(sender As Object, e As EventArgs) Handles txtNumDoc.Validated
        If Len(Trim(txtNumDoc.Text)) > 0 Then
            Dim cant As Integer = Len(txtNumDoc.Text)
            Do While cant < 8
                txtNumDoc.Text = "0" & txtNumDoc.Text
                cant = cant + 1
            Loop
            If cmbTipoDoc.Value = 5 Or cmbTipoDoc.Value = 6 Then
                txtCodTipoRef.Focus()
            Else
                txtProveedor.Focus()
            End If
        End If
    End Sub

    Private Sub cmbMoneda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMoneda.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            End If
        End If
    End Sub
End Class