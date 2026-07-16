Imports System.ServiceModel
Imports System.IO
Imports System.Xml

Public Class frmCuentasPorPagar_Nuevo

    '===========================Servicios====================================
    Private oCtasPorPagarService As New CtasPorPagarService.CtasPorPagarServiceClient
    Private oPagosCtasPorPagarService As New PagosCtasPorPagarService.PagosCtasPorPagarServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient

    '======================Declaración de Variables==============================   
    Public IdCuenta As Int64
    Public IdGasto As Int64
    Public IdProveedor As Integer
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public edicion As Boolean = True        'True: Edición      False: Vista
    Public editable As Boolean = True       'True: Editable     False: No Editable 
    Public iEstado As Integer
    Private dtTipDoc As DataTable
    Private dtCondPago As DataTable
    Private dtMonedas As DataTable
    Private dtDatos As DataTable
    Private dtPersonaPosesion As DataTable
    Private NombreArchivo As String
    Private DocumentoXml As String = ""
    Private DocumentoPdf As Byte() = Nothing
    'Private IdGastoDet As Integer
    'Private IdGasto As Integer

    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                        txtIdCuenta.KeyPress _
                      , txtIdGasto.KeyPress _
                      , txtFecEmision.KeyPress _
                      , txtTipoCambio.KeyPress _
                      , cmbMoneda.KeyPress _
                      , txtTotal.KeyPress _
                      , txtTotalPago.KeyPress _
                      , cmbTipoDoc.KeyPress _
                      , txtProveedor.KeyPress _
                      , cbRecibioCheque.KeyPress _
                      , cbPagoCaja.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            listaDatos()
        End If
    End Sub

    Private Sub frmCuentasPorPagar_Nuevo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub Finalizar()
        Try
            oCtasPorPagarService.Close()
            oMaestroService.Close()
            oOrdenesCompraService.Close()
            oPagosCtasPorPagarService.Close()
        Catch ex As TimeoutException
            oCtasPorPagarService.Abort()
            oMaestroService.Abort()
            oOrdenesCompraService.Abort()
            oPagosCtasPorPagarService.Abort()
        Catch ex As CommunicationException
            oCtasPorPagarService.Abort()
            oMaestroService.Abort()
            oOrdenesCompraService.Abort()
            oPagosCtasPorPagarService.Abort()
        End Try
    End Sub

    Private Function ValidarDetalles() As Boolean
        Try
            If dgvDatosCentroCosto.RowCount > 0 Then
                Dim Monto As Double = 0
                Dim MontoNoAfecto As Double = 0
                Dim row As Janus.Windows.GridEX.GridEXRow

                For i = 0 To Me.dgvDatosCentroCosto.RowCount - 1
                    Me.dgvDatosCentroCosto.Row = i
                    row = Me.dgvDatosCentroCosto.GetRow()
                    Monto = Monto + CDbl(Me.dgvDatosCentroCosto.CurrentRow.Cells("Monto").Value)
                Next

                If Not (txtTotal.Value = Math.Round(Monto, 2)) Then
                    MsgBox("Los montos de los centros de costo asignados no coinciden con el documento.", MsgBoxStyle.Information, "Información")
                    Return False

                Else
                    Return True
                End If
            Else
                MsgBox("Debe ingresar al menos un Centro de Costo", MsgBoxStyle.Information, "Información")
                dgvDatosCentroCosto.Focus()
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS DETALLES" + ex.Message)
        End Try
    End Function

    Private Sub frmCuentasPorPagar_Nuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If state_button Then
                If ValidarDetalles() Then
                    Finalizar()
                    Me.Close()
                End If
            Else
                Finalizar()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmCuentasPorPagar_Nuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)

        estilo.cargaEstiloGridExt(dgvDatosCentroCosto)
        llenarCombos()
        If state_button Then    'Modificar 
            ObtenerRegistro()
            desactivar()
            gbEstado.Visible = True
            gbDetalle.Visible = True
            actualizarDetalles()
            Me.Text = "CUENTA POR PAGAR Nº " + Chr(34) + txtIdCuenta.Text.ToString + Chr(34)
            dgvDatos.Select()
            dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(740, 400)
            gbEstado.Visible = False
            gbDetalle.Visible = False
            cmbMoneda.Value = "NS"
            Me.Text = "Registrar nueva Cuenta Por Pagar"
            activar()
            cbRecibioCheque.Checked = True
        End If
    End Sub

    Private Sub RowPossesion(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If CInt(row.Cells("IdCuentaDet").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function getRowTodos(ByVal data As DataTable)
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
        End Try
        Return fila
    End Function

    Private Sub llenarCombos()
        Try

            '===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("Nombre").ToString
            dtTipDoc = Nothing

            '================================CONDICION DE PAGO PROVEEDOR===================================
            dtCondPago = oProveedorService.MostrarCondicionPago.Tables(0)
            cmbCodPago.DataSource = dtCondPago
            cmbCodPago.DropDownList.DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCodPago.DropDownList.DisplayMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCodPago.DropDownList.ValueMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCodPago.DropDownList.Columns(0).DataMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCodPago.DropDownList.Columns(1).DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCodPago.DropDownList.Columns(2).DataMember = dtCondPago.Columns("DiasPago").ToString
            dtCondPago = Nothing

            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing


            '====================================PERSONA POSESIÓN===========================================
            dtPersonaPosesion = oCtasPorPagarService.MostrarPosesion(Session.sCodEmp).Tables(0)
            dtPersonaPosesion.Rows.InsertAt(getRowTodos3(dtPersonaPosesion), 0)
            cmbPersonaPosesion.DataSource = dtPersonaPosesion
            cmbPersonaPosesion.DropDownList.DataMember = dtPersonaPosesion.Columns("ApeNom").ToString
            cmbPersonaPosesion.DropDownList.DisplayMember = dtPersonaPosesion.Columns("ApeNom").ToString
            cmbPersonaPosesion.DropDownList.ValueMember = dtPersonaPosesion.Columns("IdPer").ToString
            cmbPersonaPosesion.DropDownList.Columns(0).DataMember = dtPersonaPosesion.Columns("IdPer").ToString
            cmbPersonaPosesion.DropDownList.Columns(1).DataMember = dtPersonaPosesion.Columns("ApeNom").ToString
            cmbPersonaPosesion.SelectedIndex = 0
            dtPersonaPosesion = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub enableOpciones()
        iEstado = oCtasPorPagarService.ObtenerEstado(toNumber(txtIdCuenta.Text))
        If dgvDatos.RowCount < 1 Then
            miMostrar.Enabled = False
            miEliminar.Enabled = False
        Else
            miMostrar.Enabled = True
            miEliminar.Enabled = True
        End If
        If dgvDatosCentroCosto.RowCount < 1 Then
            miMostrarCentroCosto.Enabled = False
        Else
            miMostrarCentroCosto.Enabled = True
        End If
        miNuevo.Enabled = IIf(editable And iEstado = 1, True, False)
        biEditar.Enabled = IIf(editable, Not edicion, False)
        'biVerDetalle.Enabled = IIf(state_button And txtIdMesa.Text <> "", True, False)
        biSalir.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        'cmOpciones.Enabled = IIf(Not edicion And iEstado = "GN", True, False)
        miAsignarCentroCosto.Enabled = IIf(iEstado <> 2, True, False)

        cmOpciones.Enabled = IIf(Not edicion, True, False)
        cmOpcionesCentrosCosto.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub activar()
        If state_button Then
            txtIdGasto.ReadOnly = True
            txtIdGasto.BackColor = System.Drawing.SystemColors.Control
            txtFecEmision.ReadOnly = True
            txtFecEmision.BackColor = System.Drawing.SystemColors.Control
            If iEstado = 2 Then
                txtFecRecepcion.ReadOnly = True
                txtFecRecepcion.BackColor = System.Drawing.SystemColors.Control
                cmbCodPago.ReadOnly = True
                cmbCodPago.BackColor = System.Drawing.SystemColors.Control
            Else
                txtFecRecepcion.ReadOnly = False
                txtFecRecepcion.BackColor = System.Drawing.SystemColors.Window
                cmbCodPago.ReadOnly = False
                cmbCodPago.BackColor = System.Drawing.SystemColors.Window
            End If
            txtFecVencimiento.ReadOnly = True
            txtFecVencimiento.BackColor = System.Drawing.SystemColors.Control
            txtTipoCambio.ReadOnly = True
            txtTipoCambio.BackColor = System.Drawing.SystemColors.Control
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            txtTotal.ReadOnly = True
            txtTotal.BackColor = System.Drawing.SystemColors.Control
            txtTotalPago.ReadOnly = True
            txtTotalPago.BackColor = System.Drawing.SystemColors.Control
            cbRecibioCheque.Enabled = True
            cbRecibioCheque.BackColor = System.Drawing.SystemColors.Window
            cmbPersonaPosesion.ReadOnly = False
            cmbPersonaPosesion.BackColor = System.Drawing.SystemColors.Window
            cbPagoCaja.Enabled = True
            cbPagoCaja.BackColor = System.Drawing.SystemColors.Window
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            btnObservacion.Enabled = True
            btnBuscarProveedor.Enabled = False
            cmbTipoDoc.ReadOnly = True
            cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
            txtNumDoc.ReadOnly = True
            txtNumDoc.BackColor = System.Drawing.SystemColors.Control
            txtSerieDoc.ReadOnly = True
            txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
            btnBuscarXml.Enabled = False
            btnBuscarPdf.Enabled = False
            btnLimpiarXml.Enabled = False
            btnLimpiarPdf.Enabled = False
            txtFecRecepcion.Focus()

        Else
            txtIdGasto.ReadOnly = True
            txtIdGasto.BackColor = System.Drawing.SystemColors.Control
            txtFecEmision.ReadOnly = False
            txtFecEmision.BackColor = System.Drawing.SystemColors.Window
            txtFecRecepcion.ReadOnly = False
            txtFecRecepcion.BackColor = System.Drawing.SystemColors.Window
            txtFecVencimiento.ReadOnly = True
            txtFecVencimiento.BackColor = System.Drawing.SystemColors.Control
            txtTipoCambio.ReadOnly = False
            txtTipoCambio.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            txtTotal.ReadOnly = False
            txtTotal.BackColor = System.Drawing.SystemColors.Window
            txtTotalPago.ReadOnly = True
            txtTotalPago.BackColor = System.Drawing.SystemColors.Control
            txtObservacion.ReadOnly = False
            txtObservacion.BackColor = System.Drawing.SystemColors.Window
            btnObservacion.Enabled = True
            btnBuscarProveedor.Enabled = True
            cmbCodPago.ReadOnly = False
            cmbCodPago.BackColor = System.Drawing.SystemColors.Window
            cmbTipoDoc.ReadOnly = False
            cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
            txtNumDoc.ReadOnly = False
            txtNumDoc.BackColor = System.Drawing.SystemColors.Window
            txtSerieDoc.ReadOnly = False
            txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
            cbRecibioCheque.Enabled = True
            cbRecibioCheque.BackColor = System.Drawing.SystemColors.Window
            cmbPersonaPosesion.ReadOnly = False
            cmbPersonaPosesion.BackColor = System.Drawing.SystemColors.Window
            cbPagoCaja.Enabled = True
            cbPagoCaja.BackColor = System.Drawing.SystemColors.Window
            btnBuscarXml.Enabled = True
            btnBuscarPdf.Enabled = True
            btnLimpiarXml.Enabled = True
            btnLimpiarPdf.Enabled = True
            txtFecEmision.Focus()
        End If
        edicion = True
        enableOpciones()
    End Sub

    Private Sub desactivar()
        txtIdGasto.ReadOnly = True
        txtIdGasto.BackColor = System.Drawing.SystemColors.Control
        txtFecEmision.ReadOnly = True
        txtFecEmision.BackColor = System.Drawing.SystemColors.Control
        txtFecRecepcion.ReadOnly = True
        txtFecRecepcion.BackColor = System.Drawing.SystemColors.Control
        txtFecVencimiento.ReadOnly = True
        txtFecVencimiento.BackColor = System.Drawing.SystemColors.Control
        txtTipoCambio.ReadOnly = True
        txtTipoCambio.BackColor = System.Drawing.SystemColors.Control
        cmbMoneda.ReadOnly = True
        cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        txtTotal.ReadOnly = True
        txtTotal.BackColor = System.Drawing.SystemColors.Control
        txtTotalPago.ReadOnly = True
        txtTotalPago.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        btnObservacion.Enabled = False
        btnBuscarProveedor.Enabled = False
        cmbCodPago.ReadOnly = True
        cmbCodPago.BackColor = System.Drawing.SystemColors.Control
        cmbTipoDoc.ReadOnly = True
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        txtSerieDoc.ReadOnly = True
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
        cbRecibioCheque.Enabled = False
        cbRecibioCheque.BackColor = System.Drawing.SystemColors.Control
        cbPagoCaja.Enabled = False
        cbPagoCaja.BackColor = System.Drawing.SystemColors.Control
        cmbPersonaPosesion.ReadOnly = True
        cmbPersonaPosesion.BackColor = System.Drawing.SystemColors.Control
        btnBuscarXml.Enabled = False
        btnBuscarPdf.Enabled = False
        btnLimpiarXml.Enabled = False
        btnLimpiarPdf.Enabled = False
        edicion = False
        enableOpciones()
        txtIdGasto.Focus()
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe de Ingresar la Moneda.", MsgBoxStyle.Information, "Información")
                'cmbArea.BackColor = Color.Red
                cmbMoneda.Focus()
                Return False
            ElseIf toDouble(txtTotal.Value) < 0 Then
                MsgBox("El monto no debe ser menor a CERO.", MsgBoxStyle.Information, "Información")
                'txtMonto.BackColor = Color.Red
                txtTotal.Focus()
                Return False
            ElseIf cmbPersonaPosesion.SelectedIndex = 0 Then
                MsgBox("Debe de Ingresar la Posesión.", MsgBoxStyle.Information, "Información")
                'cmbCodPago.BackColor = Color.Red
                cmbPersonaPosesion.Focus()
                Return False
            ElseIf toNumber(IdProveedor) = 0 Then
                MsgBox("Debe Ingresar el Proveedor", MsgBoxStyle.Information, "Información")
                'txtProveedor.BackColor = Color.Red
                btnBuscarProveedor.Focus()
                Return False
            ElseIf toBlank(cmbCodPago.Value) = "" Then
                MsgBox("Debe Ingresar de la condicion de Pago de Proveedor.", MsgBoxStyle.Information, "Información")
                'cmbCodPago.BackColor = Color.Red
                cmbCodPago.Focus()
                Return False
            ElseIf toBlank(cmbTipoDoc.Value) = "" Then
                MsgBox("Debe de el Tipo de Documento.", MsgBoxStyle.Information, "Información")
                'cmbTipoDoc.BackColor = Color.Red
                cmbTipoDoc.Focus()
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
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function getRowTodos3(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = ""
        Catch ex As Exception

        End Try
        Try
            fila(2) = ""
        Catch ex As Exception

        End Try
        Try
            fila(3) = ""
        Catch ex As Exception

        End Try
        Try
            fila(4) = ""
        Catch ex As Exception

        End Try

        Return fila
    End Function

    Private Function ValidaCodigoSeleccionado() As Boolean
        Try
            If dgvDatos.RowCount < 1 Then
                MsgBox("Lista de registros esta vacío, verificar...!!!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatos.CurrentRow.RowIndex < 0 Then
                MsgBox("Seleccione un registro ...!!!", MsgBoxStyle.Information, "Información")
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

    Private Sub ObtenerRegistro()
        Try
            Dim registro As CtasPorPagarService.CtasPorPagar
            registro = oCtasPorPagarService.Obtener(IdCuenta)

            IdCuenta = registro.IdCuenta
            txtIdCuenta.Text = registro.IdCuenta
            IdGasto = registro.SolicitudGasto.IdGasto
            If IdGasto <> 0 Then
                txtIdGasto.Text = registro.SolicitudGasto.IdGasto
            Else
                txtIdGasto.Text = ""
            End If
            lblEstado.Text = registro.EstadosCtasPorPagar.DesEstado
            txtFecEmision.Value = registro.FecEmision
            txtFecRecepcion.Value = registro.FecRecepcion
            txtFecVencimiento.Value = registro.FecVencimiento
            txtFecVencimiento.Text = registro.FecVencimiento.ToString
            txtTipoCambio.Value = registro.TipCam
            cmbMoneda.Value = toNull(registro.Moneda.CodMon)
            txtTotal.Value = registro.Total
            txtTotalPago.Value = registro.TotalPago
            txtObservacion.Text = registro.Observacion
            cmbTipoDoc.Value = registro.TipoDocumento.IdDocumento
            txtNumDoc.Text = registro.NumDoc
            txtSerieDoc.Text = registro.SerDoc
            IdProveedor = registro.Proveedor.IdProveedor
            txtProveedor.Text = registro.Proveedor.DesProv
            cmbCodPago.Value = registro.CondicionPagoProveedor.IdCondicion
            cbRecibioCheque.Checked = registro.RecibioCheque
            cbPagoCaja.Checked = registro.PagoCaja
            If registro.Persona.IdPer = Nothing Then
                cmbPersonaPosesion.SelectedIndex = 0
            Else
                cmbPersonaPosesion.Value = registro.Persona.IdPer
            End If
            DocumentoXml = registro.DocumentoXml
            DocumentoPdf = registro.DocumentoPdf
            NombreArchivo = registro.NombreArchivo
            txtXmlFE.Text = registro.NombreArchivo
            txtPdfFE.Text = registro.NombreArchivo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                iEstado = oCtasPorPagarService.ObtenerEstado(IdCuenta)
                If iEstado = 1 Then
                    Dim frm As New frmCuentasPorPagar_Detalle
                    frm.state_button = False
                    frm.IdCuenta = IdCuenta
                    frm.txtTipoCambio.Value = Format(toDouble(oMaestroService.MostrarTipoCambio("US", Today)), "#0.000")
                    frm.Total = txtTotal.Value
                    frm.TotalPago = txtTotalPago.Value
                    frm.iEstado = iEstado
                    If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        dtDatos = Nothing
                        ObtenerRegistro()
                        enableOpciones()
                        listaDatos()
                        If frm.type_process = "insert" Then
                            RowPossesion(dgvDatos, frm.IdCuentaDet)
                        End If
                    Else
                        enableOpciones()
                        lLog = False
                    End If
                Else
                    enableOpciones()
                    lLog = False
                End If

            End While
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR NUEVO DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("IdCuentaDet").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oPagosCtasPorPagarService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdCuentaDet").Text), toNumber(txtIdCuenta.Text), Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtDatos = Nothing
                    ObtenerRegistro()
                    enableOpciones()
                    listaDatos()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR DETALLE:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmCuentasPorPagar_Detalle
            frm.state_button = True
            frm.IdCuentaDet = dgvDatos.CurrentRow.Cells("IdCuentaDet").Text
            frm.IdCuenta = IdCuenta
            frm.iEstado = oCtasPorPagarService.ObtenerEstado(IdCuenta)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerRegistro()
                enableOpciones()
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdCuentaDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
            RowPossesion(dgvDatos, frm.IdCuentaDet)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub actualizarDetalles()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdCuentaDet").Text
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

    Private Sub Insertar(ByVal registro As CtasPorPagarService.CtasPorPagar)
        Try
            Dim estado_process As Integer
            estado_process = oCtasPorPagarService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdCuenta = estado_process
                MsgBox("Se insertó la Cuenta Por Pagar Correctamente")
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR CUENTA POR PAGAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As CtasPorPagarService.CtasPorPagar)
        Try
            Dim estado_process As Boolean
            estado_process = oCtasPorPagarService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                MsgBox("Se modificó la Cuenta Por Pagar Correctamente")
                desactivar()
                ObtenerRegistro()
                actualizarDetalles()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR CUENTA POR PAGAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oCtasPorPagarService.Borrar(IdCuenta, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR CUENTA POR PAGAR: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oPagosCtasPorPagarService.Mostrar(toNumber(txtIdCuenta.Text)).Tables(0)
            dgvDatos.DataSource = dtDatos


            dtDatos = oCtasPorPagarService.MostrarCentroCosto(toNumber(txtIdCuenta.Text)).Tables(0)
            dgvDatosCentroCosto.DataSource = dtDatos
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        Try
            Dim frm As New frmBuscarProveedor
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                If toNull(frm.codigo) <> Nothing Then
                    IdProveedor = frm.codigo
                    txtProveedor.Text = frm.descripcion
                    cmbCodPago.Focus()
                Else
                    IdProveedor = 0
                    txtProveedor.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub txtProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.TextChanged
        Dim proveedor As ProveedorService.Proveedor
        proveedor = oProveedorService.Obtener(IdProveedor)
        If proveedor.CondicionPagoProveedor.IdCondicion <> 0 Then
            cmbCodPago.Value = proveedor.CondicionPagoProveedor.IdCondicion
        End If
    End Sub

    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
            And ValidaCampos() Then

                Dim registro As New CtasPorPagarService.CtasPorPagar
                Dim moneda As New CtasPorPagarService.Moneda
                Dim tipoDocumento As New CtasPorPagarService.TipoDocumento
                Dim proveedor As New CtasPorPagarService.Proveedor
                Dim condicionPago As New CtasPorPagarService.CondicionPagoProveedor
                Dim empresa As New CtasPorPagarService.Empresa
                Dim PersonaPosesion As New CtasPorPagarService.Persona
                Dim estado As New CtasPorPagarService.EstadosCtasPorPagar

                registro.IdCuenta = IdCuenta
                registro.FecEmision = txtFecEmision.Value
                registro.FecRecepcion = txtFecRecepcion.Value
                registro.TipCam = txtTipoCambio.Value
                moneda.CodMon = cmbMoneda.Value
                registro.Moneda = moneda
                registro.Total = txtTotal.Value
                registro.TotalPago = txtTotalPago.Value
                registro.Observacion = txtObservacion.Text
                tipoDocumento.IdDocumento = cmbTipoDoc.Value
                registro.TipoDocumento = tipoDocumento
                registro.NumDoc = txtNumDoc.Text
                registro.SerDoc = txtSerieDoc.Text
                proveedor.IdProveedor = IdProveedor
                registro.Proveedor = proveedor
                condicionPago.IdCondicion = cmbCodPago.Value
                registro.CondicionPagoProveedor = condicionPago
                registro.RecibioCheque = cbRecibioCheque.Checked
                PersonaPosesion.IdPer = cmbPersonaPosesion.Value
                registro.PagoCaja = cbPagoCaja.Checked
                registro.Persona = PersonaPosesion
                empresa.CodEmp = Session.sCodEmp
                registro.Empresa = empresa

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

                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp
                registro.CodUsu = Session.sCodUsu
                If state_button Then            'Modificar                
                    Modificar(registro)
                Else                                  'Nuevo
                    estado.IdEstado = 1
                    registro.EstadosCtasPorPagar = estado
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR CUENTAS POR PAGAR : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
    End Sub

    Private Sub miNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        iEstado = oCtasPorPagarService.ObtenerEstado(IdCuenta)
        If state_button = True And iEstado = 1 Then
            NuevoDetalle()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdCuentaDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click, dgvDatos.DoubleClick
        If cmOpciones.Enabled = False Then
        Else
            If ValidaCodigoSeleccionado() Then
                mostrarDetalle()
            End If
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

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarProveedor.Enabled = True Then
                e.Handled = True
                btnBuscarProveedor_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btnObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObservacion.Click
        Dim frm As New frmCuentasPorPagar_Observacion
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = frm.txtObservacion.Text
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If state_button Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                cmbCodPago.Focus()
            End If
        Else
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                txtProveedor.Focus()
            End If
        End If
    End Sub

    Private Sub txtFecRecepcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecRecepcion.KeyPress
        If state_button Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                txtObservacion.Focus()
            End If
        Else
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                txtTipoCambio.Focus()
            End If
        End If
    End Sub

    Private Sub cmbCodPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodPago.KeyPress
        If state_button Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                txtFecRecepcion.Focus()
            End If
        Else
            If e.KeyChar = ChrW(Keys.Enter) Then
                e.Handled = True
                cmbTipoDoc.Focus()
            End If
        End If
    End Sub

    Private Sub txtFecRecepcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecRecepcion.TextChanged, cmbCodPago.ValueChanged
        txtFecVencimiento.Value = oCtasPorPagarService.ObtenerVencimiento(toNumber(cmbCodPago.Value), txtFecRecepcion.Value)
    End Sub

    'Private Sub biVerDetalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biVerDetalle.Click
    '    Try
    '        Dim frm As New frmComSolicitudGastoDet
    '        frm.state_button = True
    '        frm.IdGastoDet = IdGastoDet
    '        'frm.IdGasto = IdGasto
    '        frm.estado = 5
    '        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
    '            dtDatos = Nothing
    '            listaDatos()
    '            ObtenerRegistro()
    '            'If frm.type_process = "update" Then
    '            '    RowPossesion(dgvDatos, frm.IdGastoDet)
    '            'Else
    '            '    MsgBox("Se elimino el registro correctamente.", MsgBoxStyle.Information)
    '            'End If
    '        End If
    '        'RowPossesion(dgvDatos, frm.IdGastoDet)
    '    Catch ex As Exception
    '        MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub


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
            End If
            txtNumDoc.Focus()
        End If
    End Sub

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
            End If
            txtFecEmision.Focus()
        End If
    End Sub

    Private Sub txtSerieDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Validated
        Try
            If Len(Trim(txtSerieDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtSerieDoc.Text)
                Do While cant < 4
                    txtSerieDoc.Text = "0" & txtSerieDoc.Text
                    cant = cant + 1
                Loop
                txtNumDoc.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER LA SERIE DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtNumDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Validated
        Try
            If Len(Trim(txtNumDoc.Text)) > 0 Then
                Dim cant As Integer = Len(txtNumDoc.Text)
                Do While cant < 8
                    txtNumDoc.Text = "0" & txtNumDoc.Text
                    cant = cant + 1
                Loop
                txtFecEmision.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL NÚMERO DEL DOCUMENTO : " + ex.Message)
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

    Private Sub miAsignarCentroCosto_Click(sender As System.Object, e As System.EventArgs) Handles miAsignarCentroCosto.Click
        If state_button = True Then
            NuevoCentroCosto()
        End If
    End Sub

    Private Sub miMostrarCentroCosto_Click(sender As System.Object, e As System.EventArgs) Handles miMostrarCentroCosto.Click
        If ValidaCodigoSeleccionadoCentroCosto() Then
            mostrarCentroCosto()
        End If
    End Sub

    Private Sub miActualizarCentroCosto_Click(sender As System.Object, e As System.EventArgs) Handles miActualizarCentroCosto.Click
        ActualizarDetallesCentroCosto()
    End Sub

    Private Function ValidaCodigoSeleccionadoCentroCosto() As Boolean
        Try
            If dgvDatosCentroCosto.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosCentroCosto.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvDatosCentroCosto.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO CENTRO COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub NuevoCentroCosto()
        Try
            Dim frm As New frmAgregar_CentroCosto_CPagar
            frm.IdCuenta = IdCuenta
            'frm.Monto = txtMonto.Value
            'frm.MontoNoAfecto = txtMontoNoAfecto.Value
            frm.Monto = txtTotal.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                ObtenerRegistro()
                ActualizarDetallesCentroCosto()
            Else
                ObtenerRegistro()
                ActualizarDetallesCentroCosto()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR CENTROS DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarCentroCosto()
        Try
            Dim frm As New frmCuentasPorPagar_CentroCosto
            frm.IdCuenta = dgvDatosCentroCosto.CurrentRow.Cells("IdCuenta").Value
            frm.CodCentro = dgvDatosCentroCosto.CurrentRow.Cells("CodCentro").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtDatos = Nothing
                listaDatos()
                RowPossesionCentroCosto(dgvDatosCentroCosto, frm.CodCentro)
            End If
            RowPossesionCentroCosto(dgvDatosCentroCosto, frm.CodCentro)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarDetallesCentroCosto()
        Try
            Dim codigo As String = ""
            If dgvDatosCentroCosto.RowCount > 0 Then
                If IsDBNull(dgvDatosCentroCosto.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatosCentroCosto.CurrentRow.Cells("CodCentro").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatosCentroCosto.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionCentroCosto(dgvDatosCentroCosto, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RowPossesionCentroCosto(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("CodCentro").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] CENTRO COSTO: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub dgvDatosCentroCosto_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvDatosCentroCosto.DoubleClick
        If ValidaCodigoSeleccionadoCentroCosto() Then
            mostrarCentroCosto()
        End If
    End Sub


End Class