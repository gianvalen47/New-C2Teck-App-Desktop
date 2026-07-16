Imports System.ServiceModel
Imports System.IO
Imports System.Xml

Public Class frmComOrdenCompra_Factura

    '===========================Servicios====================================
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oOrdenesCompraDetService As New OrdenesCompraDetService.OrdenesCompraDetServiceClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient

    '======================Declaración de Variables==============================   
    Public state_button As Boolean          'True: Modificar    False: nuevo
    Public type_process As String            'update     insert      delete
    Public edicion As Boolean = True            'True: Edición      False: Vista
    Public editable As Boolean = True           'True: Editable     False: No Editable

    Public IdOrden As Integer
    Public IdOrdenDoc As Integer
    Private dtTipDoc As DataTable
    Public iEstado As Integer
    Public IdProveedor As Integer

    Private DocumentoXml As String = ""
    Private DocumentoPdf As Byte() = Nothing

    Private dtCentrosCosto As DataTable
    Private dtJobs As DataTable
    Private NombreArchivo As String


    Private Sub frmComOrdenCompra_Procesar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estilo As New Estilo
        estilo.CargaEstiloGrid(dgvCentrosCosto)
        dgvCentrosCosto.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvCentrosCosto.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        estilo.CargaEstiloGrid(dgvJos)
        dgvJos.Anchor = AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left
        dgvJos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both

        iEstado = oOrdenesCompraService.ObtenerEstado(IdOrden)
        llenarCombos()

        If state_button Then    'Modificar
            ObtenerRegistro()
            Desactivar()
            gbCentroCosto.Visible = True
            gbJobs.Visible = True
            ActualizarDetallesCentroCosto()
            ActualizarDetallesJob()
            Me.Text = "Documento de Orden de Compra"
            dgvCentrosCosto.Select()
        Else                          'Nuevo
            Me.Size = New System.Drawing.Size(650, 256)
            gbCentroCosto.Visible = False
            gbJobs.Visible = False
            Me.Text = "Registrar nuevo Documento de Orden de Compra"
            Activar()
            txtFecDoc.Value = Today
            cmbTipoDoc.Focus()
        End If
    End Sub

    Private Sub frmComOrdenCompra_Procesar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub Finalizar()
        Try
            oOrdenesCompraService.Close()
            oOrdenesCompraDetService.Close()
            oProveedorService.Close()
            oSolicitudGastoDetService.Close()
        Catch ex As TimeoutException
            oOrdenesCompraService.Abort()
            oOrdenesCompraDetService.Abort()
            oProveedorService.Abort()
            oSolicitudGastoDetService.Abort()
        Catch ex As CommunicationException
            oOrdenesCompraService.Abort()
            oOrdenesCompraDetService.Abort()
            oProveedorService.Abort()
            oSolicitudGastoDetService.Abort()
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

    Private Sub RowPossesionJob(ByVal lista As Janus.Windows.GridEX.GridEX, ByVal codigo As String)
        Try
            Dim rows() As Janus.Windows.GridEX.GridEXRow
            rows = lista.GetRows
            For Each row In rows
                If toBlank(row.Cells("CodJob").Value) = codigo Then
                    lista.Row = row.Position
                    lista.Col = 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS] OT: " + ex.Message, MsgBoxStyle.Critical)
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
            fila(2) = "(Ninguno)"
        End Try
        Try
            fila(2) = "(Ninguno)"
        Catch ex As Exception
            fila(3) = 0
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
            cmbTipoDoc.SelectedIndex = 0
            dtTipDoc = Nothing

        Catch ex As Exception
            MsgBox("ERROR AL LLENAR COMBOS : " + ex.Message)
        End Try
    End Sub

    Private Sub enableOpciones()
        If dgvCentrosCosto.RowCount < 1 Then
            miMostrarCentroCosto.Enabled = False
        Else
            miMostrarCentroCosto.Enabled = True
        End If

        If dgvJos.RowCount < 1 Then
            miMostrarJob.Enabled = False
            miEliminarJob.Enabled = False
        Else
            miMostrarJob.Enabled = True
            miEliminarJob.Enabled = IIf(Not edicion And editable, True, False)
        End If

        miAsignarCentroCosto.Enabled = IIf(Not edicion And editable, True, False)
        miAsignarJobs.Enabled = IIf(Not edicion And editable, True, False)

        biEditar.Enabled = IIf(editable, Not edicion, False)
        biCerrar.Enabled = Not edicion
        biGuardar.Enabled = edicion
        biDeshacer.Enabled = edicion
        cmOpcionesCentrosCosto.Enabled = IIf(Not edicion, True, False)
    End Sub

    Private Sub dgvDatos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCentrosCosto.SelectionChanged
        enableOpciones()
    End Sub

    Private Sub Activar()
        Try
            If state_button Then
                cmbTipoDoc.ReadOnly = False
                cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
                txtSerieDoc.ReadOnly = False
                txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
                txtNumDoc.ReadOnly = False
                txtNumDoc.BackColor = System.Drawing.SystemColors.Window
                txtFecDoc.ReadOnly = False
                txtFecDoc.BackColor = System.Drawing.SystemColors.Window
                cbAplicaCosto.Enabled = True
                txtMonto.ReadOnly = False
                txtMonto.BackColor = System.Drawing.SystemColors.Window
                txtMontoNoAfecto.ReadOnly = False
                txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Window
                cbProcesado.Visible = True
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
                btnBuscarXml.Enabled = True
                btnBuscarPdf.Enabled = True
                btnLimpiarXml.Enabled = True
                btnLimpiarPdf.Enabled = True

                edicion = True
                enableOpciones()
                cmbTipoDoc.Focus()
            Else
                cmbTipoDoc.ReadOnly = False
                cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
                txtSerieDoc.ReadOnly = False
                txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
                txtNumDoc.ReadOnly = False
                txtNumDoc.BackColor = System.Drawing.SystemColors.Window
                txtFecDoc.ReadOnly = False
                txtFecDoc.BackColor = System.Drawing.SystemColors.Window
                cbAplicaCosto.Enabled = True
                txtMonto.ReadOnly = False
                txtMonto.BackColor = System.Drawing.SystemColors.Window
                txtMontoNoAfecto.ReadOnly = False
                txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Window
                cbProcesado.Visible = False
                txtObservacion.ReadOnly = False
                txtObservacion.BackColor = System.Drawing.SystemColors.Window
                btnBuscarXml.Enabled = True
                btnBuscarPdf.Enabled = True
                btnLimpiarXml.Enabled = True
                btnLimpiarPdf.Enabled = True

                edicion = True
                enableOpciones()
                cmbTipoDoc.Select()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Sub Desactivar()
        Try
            cmbTipoDoc.ReadOnly = True
            cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
            txtSerieDoc.ReadOnly = True
            txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
            txtNumDoc.ReadOnly = True
            txtNumDoc.BackColor = System.Drawing.SystemColors.Control
            txtFecDoc.ReadOnly = True
            txtFecDoc.BackColor = System.Drawing.SystemColors.Control
            cbAplicaCosto.Enabled = False
            txtMonto.ReadOnly = True
            txtMonto.BackColor = System.Drawing.SystemColors.Control
            txtMontoNoAfecto.ReadOnly = True
            txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
            cbProcesado.Visible = True
            txtObservacion.ReadOnly = True
            txtObservacion.BackColor = System.Drawing.SystemColors.Control
            btnBuscarXml.Enabled = False
            btnBuscarPdf.Enabled = False
            btnLimpiarXml.Enabled = False
            btnLimpiarPdf.Enabled = False

            edicion = False
            enableOpciones()
            cmbTipoDoc.Focus()
        Catch ex As Exception
            MsgBox("ERROR AL DESACTIVAR CAMPOS : " + ex.Message)
        End Try
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toBlank(cmbTipoDoc.Value) = "" Then
                MsgBox("Debe Ingresar el Tipo de Documento", MsgBoxStyle.Information, "Información")
                cmbTipoDoc.Focus()
                Return False
            ElseIf txtNumDoc.Text = "" Then
                MsgBox("Debe Ingresar el Número del Documento ", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar la fecha del Documento.", MsgBoxStyle.Information, "Información")
                txtFecDoc.Focus()
                Return False
            ElseIf toDouble(txtMonto.Value) <= 0 Then
                MsgBox("El Monto del documento debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMonto.Focus()
                Return False
            ElseIf toDouble(txtMontoTotal.Value) <= 0 Then
                MsgBox("El Monto Total del documento debe ser mayor a CERO.", MsgBoxStyle.Information, "Información")
                txtMontoTotal.Focus()
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

    Private Sub ObtenerRegistro()
        Try
            Dim registro As OrdenesCompraDetService.FacturaOrdenesCompra
            registro = oOrdenesCompraDetService.ObtenerFactura(IdOrdenDoc)

            IdOrden = registro.OrdenesCompra.IdOrden
            IdOrdenDoc = registro.IdOrdenDoc
            cmbTipoDoc.Value = registro.TipoDocumento.IdDocumento
            txtSerieDoc.Text = registro.SerDoc
            txtNumDoc.Text = registro.NumDoc
            txtFecDoc.Value = registro.FecDoc
            cbAplicaCosto.Checked = registro.AplicaCosto
            txtMonto.Value = registro.TotMonto
            txtMontoNoAfecto.Value = registro.TotNoAfecto
            txtMontoTotal.Value = registro.TotNeto
            cbProcesado.Checked = registro.Procesado
            txtObservacion.Text = registro.Observacion
            DocumentoXml = registro.DocumentoXml
            DocumentoPdf = registro.DocumentoPdf
            NombreArchivo = registro.NombreArchivo
            txtPdfFE.Text = registro.NombreArchivo
            txtXmlFE.Text = registro.NombreArchivo

        Catch ex As Exception
            MsgBox("ERROR AL OBTENER REGISTRO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoCentroCosto()
        Try
            Dim frm As New frmAgregar_CentroCosto_OCompra
            frm.IdOrdenDoc = IdOrdenDoc
            frm.Monto = txtMonto.Value
            frm.MontoNoAfecto = txtMontoNoAfecto.Value
            frm.MontoTotal = txtMontoTotal.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtCentrosCosto = Nothing
                ObtenerRegistro()
                ActualizarDetallesCentroCosto()
                ActualizarDetallesJob()
            Else
                ObtenerRegistro()
                ActualizarDetallesCentroCosto()
                ActualizarDetallesJob()
                enableOpciones()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR CENTROS DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarDetallesCentroCosto()
        Try
            Dim codigo As String = ""
            If dgvCentrosCosto.RowCount > 0 Then
                If IsDBNull(dgvCentrosCosto.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvCentrosCosto.CurrentRow.Cells("CodCentro").Text
                End If
            End If
            dtCentrosCosto = Nothing
            listaDatosCentroCosto()
            If dgvCentrosCosto.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionCentroCosto(dgvCentrosCosto, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub NuevoJob()
        Try
            'If oOrdenesCompraDetService.BuscarServicios(IdOrdenDoc) Then
            Dim MontoServicio As Double = 0.0
                Dim MontoNoAfectoServicio As Double = 0.0
                Dim row As Janus.Windows.GridEX.GridEXRow

            For i = 0 To Me.dgvCentrosCosto.RowCount - 1
                Me.dgvCentrosCosto.Row = i
                row = Me.dgvCentrosCosto.GetRow()
                'If row.Cells("CodArea").Value = "05" Or row.Cells("CodArea").Value = "20" Then
                MontoServicio = MontoServicio + toDouble(row.Cells("Monto").Value)
                MontoNoAfectoServicio = MontoNoAfectoServicio + toDouble(row.Cells("MontoNoAfecto").Value)
                'End If
            Next


            Dim frm As New frmAgregar_Job_OCompra
                frm.IdOrdenDoc = IdOrdenDoc
                frm.Monto = MontoServicio
                frm.MontoNoAfecto = MontoNoAfectoServicio
                frm.MontoTotal = txtMontoTotal.Value
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    dtJobs = Nothing
                    ObtenerRegistro()
                    ActualizarDetallesCentroCosto()
                    ActualizarDetallesJob()
                Else
                    ObtenerRegistro()
                    ActualizarDetallesCentroCosto()
                    ActualizarDetallesJob()
                    enableOpciones()
                End If
            'Else
            '    MsgBox("Debe ingresar un Centro de Costo de Servicio Técnico.", MsgBoxStyle.Information, "Información")
            'End If
        Catch ex As Exception
            MsgBox("ERROR AL ASIGNAR LA OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarDetallesJob()
        Try
            Dim codigo As String = ""
            If dgvJos.RowCount > 0 Then
                If IsDBNull(dgvJos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvJos.CurrentRow.Cells("CodJob").Text
                End If
            End If
            dtJobs = Nothing
            listaDatosJob()
            If dgvJos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesionJob(dgvJos, codigo)
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES LA OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Insertar(ByVal registro As OrdenesCompraDetService.FacturaOrdenesCompra)
        Try
            Dim estado_process As Integer
            estado_process = oOrdenesCompraDetService.InsertarFactura(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdOrdenDoc = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL INSERTAR DOCUMENTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub Modificar(ByVal registro As OrdenesCompraDetService.FacturaOrdenesCompra)
        Try
            Dim estado_process As Boolean
            estado_process = oOrdenesCompraDetService.ActualizarFactura(registro)
            type_process = "update"
            If estado_process = True Then
                Desactivar()
                ObtenerRegistro()
                ActualizarDetallesCentroCosto()
                ActualizarDetallesJob()
            Else
                MsgBox("¡Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR AL MODIFICAR DOCUMENTO : " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosCentroCosto()
        Try
            dtCentrosCosto = oOrdenesCompraDetService.MostrarCentroCosto(IdOrdenDoc).Tables(0)
            dgvCentrosCosto.DataSource = dtCentrosCosto
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatosJob()
        Try
            dtJobs = oOrdenesCompraDetService.MostrarJob(IdOrdenDoc).Tables(0)
            dgvJos.DataSource = dtJobs
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click
        Try
            If MsgBox("¿Está seguro que desea guardar los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
                If ValidaCampos() Then

                    Dim registro As New OrdenesCompraDetService.FacturaOrdenesCompra
                    Dim OrdenCompra As New OrdenesCompraDetService.OrdenesCompra
                    Dim TipoDocumento As New OrdenesCompraDetService.TipoDocumento

                    registro.IdOrdenDoc = IdOrdenDoc
                    OrdenCompra.IdOrden = IdOrden
                    registro.OrdenesCompra = OrdenCompra

                    TipoDocumento.IdDocumento = cmbTipoDoc.Value
                    registro.TipoDocumento = TipoDocumento

                    registro.SerDoc = IIf(txtSerieDoc.Text = "", Nothing, txtSerieDoc.Text)
                    registro.NumDoc = txtNumDoc.Text
                    registro.FecDoc = txtFecDoc.Value
                    registro.Observacion = txtObservacion.Text
                    registro.AplicaCosto = cbAplicaCosto.Checked
                    registro.TotMonto = txtMonto.Value
                    registro.TotNoAfecto = txtMontoNoAfecto.Value
                    registro.TotNeto = txtMontoTotal.Value


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

                    registro.CodUsu = Session.sCodUsu
                    registro.NomPc = Session.sNomPc
                    registro.DirIp = Session.sDirIp
                    registro.FecReg = Today

                    If state_button Then        'Modificar
                        Modificar(registro)
                    Else                        'Nuevo
                        Insertar(registro)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub biCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biCerrar.Click
        If ValidarDetalles() Then
            Finalizar()
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub biDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Deshacer") = MsgBoxResult.Yes Then
            If Not state_button Then
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Else
                Desactivar()
                ObtenerRegistro()
            End If
        End If
    End Sub

    Private Sub biEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles biEditar.Click
        Activar()
    End Sub

    Private Sub frmComOrdenCompra_Factura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                                cmbTipoDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtFecDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFecDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtMontoNoAfecto.Focus()
        End If
    End Sub

    Private Sub txtMontoNoAfecto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMontoNoAfecto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtMontoNoAfecto.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            biGuardar.Select()
        End If
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
            txtFecDoc.Focus()
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
                txtFecDoc.Focus()
            End If
        Catch ex As Exception
            MsgBox("ERROR AL OBTENER EL NÚMERO DEL DOCUMENTO : " + ex.Message)
        End Try
    End Sub

    Private Sub txtSerieDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerieDoc.Click
        txtSerieDoc.SelectAll()
    End Sub

    Private Sub txtNumDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumDoc.Click
        txtNumDoc.SelectAll()
    End Sub

    Private Sub miEliminarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miEliminarJob.Click
        If ValidaCodigoSeleccionadoJob() Then
            eliminarJob()
        End If
    End Sub

    Private Sub miMostrarCentroCosto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarCentroCosto.Click, dgvCentrosCosto.DoubleClick
        If ValidaCodigoSeleccionadoCentroCosto() Then
            mostrarCentroCosto()
        End If
    End Sub

    Private Sub miMostrarJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miMostrarJob.Click, dgvJos.DoubleClick
        If ValidaCodigoSeleccionadoJob() Then
            mostrarJob()
        End If
    End Sub

    Private Sub miAsignarJobs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAsignarJobs.Click
        If state_button = True Then
            NuevoJob()
        End If
    End Sub

    Private Sub miAsignar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miAsignarCentroCosto.Click
        If state_button = True Then
            NuevoCentroCosto()
        End If
    End Sub

    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizarCentroCosto.Click
        ActualizarDetallesCentroCosto()
    End Sub

    Private Sub miActualizarJobs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles miActualizarJobs.Click
        ActualizarDetallesJob()
    End Sub

    Private Sub eliminarJob()
        Try
            cmOpcionesJobs.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR la OT: " + dgvJos.CurrentRow.Cells("CodJob").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oOrdenesCompraDetService.BorrarJob(IdOrdenDoc, dgvJos.CurrentRow.Cells("CodJob").Value, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process = True Then
                    dtJobs = Nothing
                    listaDatosJob()
                    ObtenerRegistro()
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en el proceso, comuníquese con el departamento de TI...!", MsgBoxStyle.Critical)
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox("ERROR AL ELIMINAR LA OT:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidaCodigoSeleccionadoCentroCosto() As Boolean
        Try
            If dgvCentrosCosto.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvCentrosCosto.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvCentrosCosto.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO CENTRO COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Function ValidaCodigoSeleccionadoJob() As Boolean
        Try
            If dgvJos.RowCount < 1 Then
                MsgBox("¡Lista de registros esta vacío, verificar...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvJos.CurrentRow.RowIndex < 0 Then
                MsgBox("¡Seleccione un registro...!", MsgBoxStyle.Information, "Información")
                Return False
            ElseIf dgvJos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR CODIGO SELECCIONADO OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function

    Private Sub mostrarCentroCosto()
        Try
            Dim frm As New frmComOrdenCompra_CentroCosto
            frm.IdOrdenDoc = dgvCentrosCosto.CurrentRow.Cells("IdOrdenDoc").Value
            frm.CodCentro = dgvCentrosCosto.CurrentRow.Cells("CodCentro").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtCentrosCosto = Nothing
                listaDatosCentroCosto()
                RowPossesionCentroCosto(dgvCentrosCosto, frm.CodCentro)
            End If
            RowPossesionCentroCosto(dgvCentrosCosto, frm.CodCentro)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR CENTRO DE COSTO: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub mostrarJob()
        Try
            Dim frm As New frmComOrdenCompra_Job
            frm.IdOrdenDoc = dgvJos.CurrentRow.Cells("IdOrdenDoc").Value
            frm.CodJob = dgvJos.CurrentRow.Cells("CodJob").Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtJobs = Nothing
                listaDatosJob()
                RowPossesionJob(dgvJos, frm.CodJob)
            End If
            RowPossesionJob(dgvJos, frm.CodJob)
        Catch ex As Exception
            MsgBox("ERROR AL MOSTRAR LA OT: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ValidarDetalles() As Boolean
        Try
            If dgvCentrosCosto.RowCount > 0 Then
                Dim Monto As Double = 0
                Dim MontoNoAfecto As Double = 0
                Dim row As Janus.Windows.GridEX.GridEXRow

                For i = 0 To Me.dgvCentrosCosto.RowCount - 1
                    Me.dgvCentrosCosto.Row = i
                    row = Me.dgvCentrosCosto.GetRow()
                    Monto = Monto + CDbl(Me.dgvCentrosCosto.CurrentRow.Cells("Monto").Value)
                    MontoNoAfecto = MontoNoAfecto + CDbl(Me.dgvCentrosCosto.CurrentRow.Cells("MontoNoAfecto").Value)
                Next

                If Not (txtMonto.Value = Math.Round(Monto, 2)) And (txtMontoNoAfecto.Value = Math.Round(MontoNoAfecto, 2)) Then
                    MsgBox("Los montos de los centros de costo asignados no coinciden con el documento.", MsgBoxStyle.Information, "Información")
                    Return False
                    'ElseIf oOrdenesCompraDetService.BuscarServicios(IdOrdenDoc) And dgvJos.RowCount < 1 And cbAplicaCosto.Checked = False Then
                    '    MsgBox("Debe asignar una OT para los montos del centro de costo de Servicio Técnico asignado.", MsgBoxStyle.Information, "Información")
                    '    Return False
                    'ElseIf oOrdenesCompraDetService.BuscarServicios(IdOrdenDoc) = False And dgvJos.RowCount > 0 And cbAplicaCosto.Checked = False Then
                    '    MsgBox("Debe asignar un Centro de Costo de Servicio Técnico para los montos de la OT asignado.", MsgBoxStyle.Information, "Información")
                    '    Return False
                ElseIf ValidarServicioTecnicoJob() Then
                    Return False
                Else
                    Return True
                End If
            Else
                MsgBox("Debe ingresar al menos un Centro de Costo", MsgBoxStyle.Information, "Información")
                dgvCentrosCosto.Focus()
                Return False
            End If
        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS DETALLES" + ex.Message)
        End Try
    End Function

    Private Function ValidarServicioTecnicoJob() As Boolean
        Try
            Dim Monto As Double = 0
            Dim MontoJob As Double = 0

            Dim MontoNoAfecto As Double = 0
            Dim MontoNoAfectoJob As Double = 0

            Dim row As Janus.Windows.GridEX.GridEXRow

            If dgvCentrosCosto.RowCount > 0 Then
                For i = 0 To Me.dgvCentrosCosto.RowCount - 1
                    Me.dgvCentrosCosto.Row = i
                    row = Me.dgvCentrosCosto.GetRow()
                    'If row.Cells("CodArea").Value = "05" Or row.Cells("CodArea").Value = "20" Or row.Cells("CodArea").Value = "47" Then
                    Monto = Monto + toDouble(row.Cells("Monto").Value)
                        MontoNoAfecto = MontoNoAfecto + toDouble(row.Cells("MontoNoAfecto").Value)
                    'End If
                Next
            End If

            If dgvJos.RowCount > 0 Then
                For j = 0 To Me.dgvJos.RowCount - 1
                    Me.dgvJos.Row = j
                    row = Me.dgvJos.GetRow()
                    MontoJob = MontoJob + toDouble(row.Cells("Monto").Value)
                    MontoNoAfectoJob = MontoNoAfectoJob + toDouble(row.Cells("MontoNoAfecto").Value)
                Next
            End If


            If dgvJos.RowCount > 0 Then
                If Not (Math.Round(MontoJob, 2) = Math.Round(Monto, 2) And Math.Round(MontoNoAfectoJob, 2) = Math.Round(MontoNoAfecto, 2)) And cbAplicaCosto.Checked = False Then
                    MsgBox("Los montos de los centros de costo de Servicio Técnico no coinciden con los montos de el(los) OT(s).", MsgBoxStyle.Information, "Información")
                    Return True    'Se valida el total de los montos de los centros de costo de servicio técnico sean iguales a los montos de los job asignados
                Else
                    Return False
                End If
            Else
                Return False
            End If


            'Return False

        Catch ex As Exception
            MsgBox("ERROR AL VALIDAR LOS MONTOS DE CENTRO DE COSTO Y OT" + ex.Message)
        End Try
    End Function

    Private Sub txtMonto_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.ValueChanged, txtMontoNoAfecto.ValueChanged
        txtMontoTotal.Value = txtMonto.Value + txtMontoNoAfecto.Value
    End Sub

    Private Sub btnBuscarXml_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarXml.Click
        'Dim file As New OpenFileDialog()
        'file.Filter = "XML|*.xml"
        'If file.ShowDialog() = DialogResult.OK Then
        '    txtXmlFE.Text = file.FileName
        '    NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
        'End If

        Try

            '=============================================== OBTENER DATA DEL XML ==============================

            Dim file As New OpenFileDialog()
            Dim RutaArchivo As String = ""
            'file.Filter = "Archivo JPG|*.jpg"
            file.Filter = "XML|*.xml"
            If file.ShowDialog() = DialogResult.OK Then

                txtXmlFE.Text = file.FileName
                NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
                RutaArchivo = System.IO.Path.GetFullPath(file.FileName)

            End If

            If txtXmlFE.Text <> "" Then

                Dim xmlDocR As New XmlDocument
                xmlDocR.Load(RutaArchivo)

                '/////////OBTENER ESTADO E INFORMACION DEL CDR SUNAT/////////////////////////
                Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDocR.NameTable)
                namespaces.AddNamespace("ns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")
                namespaces.AddNamespace("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2")
                namespaces.AddNamespace("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2")
                namespaces.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")
                namespaces.AddNamespace("ccts", "urn:un:unece:uncefact:documentation:2")
                namespaces.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")
                namespaces.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#")
                namespaces.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2")

                '====================================================
                'Obtener Tipo de Documento

                Dim xPathInvoiceTypeString = "/ns:Invoice/cbc:InvoiceTypeCode"
                Dim oNodeInvoiceType = xmlDocR.SelectSingleNode(xPathInvoiceTypeString, namespaces)
                Dim InvoiceType As String = oNodeInvoiceType.InnerText

                cmbTipoDoc.Value = oSolicitudGastoDetService.ObtenerIdDocumentoSunat(InvoiceType)

                '====================================================
                'Obtener Serie - Numero del Documento

                Dim xPathIDString = "/ns:Invoice/cbc:ID"
                Dim oNodeSerieNum = xmlDocR.SelectSingleNode(xPathIDString, namespaces)
                Dim SerNumDoc As String = oNodeSerieNum.InnerText

                Dim contadorsernum As Integer = Len(SerNumDoc)
                Dim Serie As String = Mid(SerNumDoc, 1, 4)
                Dim NumDoc As String = Mid(SerNumDoc, 6, contadorsernum - 5)
                'Dim NumDoc As String = Mid(SerNumDoc, contadorsernum - 4)
                Dim cantnumdocfinal As Integer = 0
                cantnumdocfinal = Len(NumDoc)

                Do While cantnumdocfinal < 10
                    NumDoc = "0" & NumDoc
                    cantnumdocfinal = cantnumdocfinal + 1
                Loop

                txtSerieDoc.Text = Serie
                txtNumDoc.Text = NumDoc

                '===================================================
                'Obtener Fecha

                Dim xPathDateString = "/ns:Invoice/cbc:IssueDate"
                Dim oNodeDate = xmlDocR.SelectSingleNode(xPathDateString, namespaces)
                Dim Fecha As Date = CDate(oNodeDate.InnerText)

                txtFecDoc.Value = Fecha

                '===================================================
                'Obtener Monto Tax  - Payable Amount - LineExtensionAmount

                Dim xPathTaxAmountString = "/ns:Invoice/cac:TaxTotal/cbc:TaxAmount"
                Dim oNodeTaxAmount = xmlDocR.SelectSingleNode(xPathTaxAmountString, namespaces)
                Dim TaxAmount As Double = CDbl(oNodeTaxAmount.InnerText)

                Dim xPathPayableAmountString = "/ns:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount"
                Dim oNodePayableAmount = xmlDocR.SelectSingleNode(xPathPayableAmountString, namespaces)
                Dim PayableAmount As Double = CDbl(oNodePayableAmount.InnerText)

                Dim xPathLineExtensionAmountString = "/ns:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount"
                Dim oNodeLineExtensionAmount = xmlDocR.SelectSingleNode(xPathLineExtensionAmountString, namespaces)
                Dim LineExtensionAmount As Double = CDbl(oNodeLineExtensionAmount.InnerText)

                '===================================================
                'Calculando el MontoNoAfecto

                Dim MontoNoAfecto As Double = 0
                MontoNoAfecto = PayableAmount - (LineExtensionAmount + TaxAmount)

                If TaxAmount = 0 Then
                    txtMontoNoAfecto.Value = PayableAmount
                Else
                    txtMontoNoAfecto.Value = MontoNoAfecto
                    txtMonto.Value = PayableAmount - MontoNoAfecto
                End If

                'Dim MontoSinIgv As Double
                txtMontoTotal.Value = txtMonto.Value + txtMontoNoAfecto.Value

            End If

            DesactivarCampos()

        Catch ex As Exception
            MsgBox("Error al obtener los datos. El archivo xml no tiene el formato requerido : " + ex.Message, MsgBoxStyle.Information)
            ActivarCampos()
            LimpiarCamposXml()
        End Try


    End Sub

    Private Sub DesactivarCampos()

        cmbTipoDoc.ReadOnly = True
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
        txtSerieDoc.ReadOnly = True
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        'txtMonto.ReadOnly = True
        'txtMonto.BackColor = System.Drawing.SystemColors.Control
        'txtMontoNoAfecto.ReadOnly = True
        'txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control

    End Sub

    Private Sub ActivarCampos()

        cmbTipoDoc.ReadOnly = False
        cmbTipoDoc.BackColor = System.Drawing.SystemColors.Window
        txtSerieDoc.ReadOnly = False
        txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
        txtNumDoc.ReadOnly = False
        txtNumDoc.BackColor = System.Drawing.SystemColors.Window
        txtFecDoc.ReadOnly = False
        txtFecDoc.BackColor = System.Drawing.SystemColors.Window
        'txtMonto.ReadOnly = False
        'txtMonto.BackColor = System.Drawing.SystemColors.Window
        'txtMontoNoAfecto.ReadOnly = False
        'txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Window

    End Sub

    Private Sub LimpiarCamposXml()

        cmbTipoDoc.Value = 0
        txtSerieDoc.Text = ""
        txtNumDoc.Text = ""
        txtFecDoc.Value = Today.Date
        txtMonto.Value = 0.00
        txtMontoNoAfecto.Value = 0.00
        txtMontoTotal.Value = 0.00

    End Sub



    Private Sub btnBuscarPdf_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarPdf.Click
        Dim file As New OpenFileDialog()
        file.Filter = "PDF|*.pdf"
        If file.ShowDialog() = DialogResult.OK Then
            txtPdfFE.Text = file.FileName
            NombreArchivo = System.IO.Path.GetFileNameWithoutExtension(file.FileName)
        End If
    End Sub

    Private Sub btnLimpiarXml_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarXml.Click
        txtXmlFE.Text = ""
    End Sub

    Private Sub btnLimpiarPdf_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarPdf.Click
        txtPdfFE.Text = ""
    End Sub
End Class