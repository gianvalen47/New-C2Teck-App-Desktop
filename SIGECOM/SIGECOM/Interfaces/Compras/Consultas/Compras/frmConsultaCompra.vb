Imports System.ServiceModel
Public Class frmConsultaCompra

    '===========================Servicios====================================================
    Private oCtasPorPagarService As New CtasPorPagarService.CtasPorPagarServiceClient
    Private oMesaControlService As New MesaControlService.MesaControlServiceClient
    Private oSolicitudGastoService As New SolicitudGastoService.SolicitudGastoServiceClient
    Private oMaestroService As New MaestroService.MaestroClient
    Private oProveedorService As New ProveedorService.ProveedorServiceClient
    Private oOrdenesCompraService As New OrdenesCompraService.OrdenesCompraServiceClient
    Private oSolicitudGastoDetService As New SolicitudGastoDetService.SolicitudGastoDetServiceClient
    Private oPagosCtasPorPagarService As New PagosCtasPorPagarService.PagosCtasPorPagarServiceClient
    Private oTesoreriaDet As New TesoreriaDetService.TesoreriaDetServiceClient
    Private oTesoreriaService As New TesoreriaService.TesoreriaServiceClient

    '======================Declaración de Variables==============================================
    ' Public IdMesa As Integer
    Public IdGasto As Integer
    Public IdGastoDet As Integer
    Public IdCuenta As Integer
    Private dtDatos As DataTable
    Private dtAreas As DataTable
    Private dtMonedas As DataTable
    Private dtCondPago As DataTable
    Private dtTipDoc As DataTable
    Private dtPersonaPosesion As DataTable
    Private IdProveedor As Int64
    Private IdDocumento As Integer



    Private Sub frmConsultaCompra_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oCtasPorPagarService.Close()
            oMesaControlService.Close()
            oSolicitudGastoService.Close()
            oProveedorService.Close()
            oOrdenesCompraService.Close()
            oSolicitudGastoDetService.Close()
            oPagosCtasPorPagarService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oCtasPorPagarService.Abort()
            oMesaControlService.Abort()
            oSolicitudGastoService.Abort()
            oProveedorService.Abort()
            oOrdenesCompraService.Abort()
            oSolicitudGastoDetService.Abort()
            oPagosCtasPorPagarService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oCtasPorPagarService.Abort()
            oMesaControlService.Abort()
            oSolicitudGastoService.Abort()
            oProveedorService.Abort()
            oOrdenesCompraService.Abort()
            oSolicitudGastoDetService.Abort()
            oPagosCtasPorPagarService.Abort()
        End Try
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub frmConsultaCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
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

    Private Sub frmConsultaCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        LlenarCombos()

        If IdGasto <> 0 Then
            gbGasto.Visible = True
            ObtenerGasto()
        Else
            gbGasto.Visible = False
        End If
        If IdGastoDet <> 0 Then
            gbDetalleGasto.Visible = True
            ObtenerGastoDet()
        Else
            gbDetalleGasto.Visible = False
        End If
        'If IdMesa <> 0 Then
        '    gbMesaControl.Visible = True
        '    ObtenerMesa()
        'Else
        '    gbMesaControl.Visible = False
        'End If
        'If IdCuenta <> 0 Then
        listaDatos()
        gbCtasxPagar.Visible = True
        'ObtenerCuenta()
        'actualizarDetalles()
        'Else
        'gbCtasxPagar.Visible = False
        Me.Size = New System.Drawing.Size(768, 645)
        'End If

        If dgvDatos.RowCount = 0 Then
            miMostrar.Enabled = False
        Else
            miMostrar.Enabled = True
            dgvDatos.Select()
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click, miSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Function getRowNinguno(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception
            fila(0) = 0
        End Try
        Try
            fila(1) = "(Ninguno)"
        Catch ex As Exception
            fila(2) = False
        End Try
        Try
            fila(2) = False
        Catch ex As Exception
            fila(3) = 0
        End Try
        Return fila
    End Function

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

    Private Sub LlenarCombos()

        Try
            '=======================================MONEDAS ===============================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing

            '========================================== AREAS ===============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            cmbArea.DataSource = dtAreas
            cmbArea.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbArea.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbArea.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing

            '================================CONDICION DE PAGO PROVEEDOR===================================
            dtCondPago = oProveedorService.MostrarCondicionPago.Tables(0)
            dtCondPago.Rows.InsertAt(getRowNinguno(dtCondPago), 0)
            cmbCondPago.DataSource = dtCondPago
            cmbCondPago.DropDownList.DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCondPago.DropDownList.DisplayMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCondPago.DropDownList.ValueMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCondPago.DropDownList.Columns(0).DataMember = dtCondPago.Columns("IdCondicion").ToString
            cmbCondPago.DropDownList.Columns(1).DataMember = dtCondPago.Columns("NomCondicion").ToString
            cmbCondPago.DropDownList.Columns(2).DataMember = dtCondPago.Columns("DiasPago").ToString
            cmbCondPago.SelectedIndex = 0
            dtCondPago = Nothing

            ''===================================== TIPO DE DOCUMENTO=========================================
            dtTipDoc = oOrdenesCompraService.MostrarTipoDocumentoCompras().Tables(0)
            dtTipDoc.Rows.InsertAt(getRowNinguno(dtTipDoc), 0)
            cmbTipoDoc.DataSource = dtTipDoc
            cmbTipoDoc.DropDownList.DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.DisplayMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.ValueMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(0).DataMember = dtTipDoc.Columns("IdDocumento").ToString
            cmbTipoDoc.DropDownList.Columns(1).DataMember = dtTipDoc.Columns("CodSunat").ToString
            cmbTipoDoc.DropDownList.Columns(2).DataMember = dtTipDoc.Columns("Nombre").ToString
            cmbTipoDoc.DropDownList.Columns(3).DataMember = dtTipDoc.Columns("AplicaIgv").ToString
            cmbTipoDoc.SelectedIndex = 0
            dtTipDoc = Nothing

            '===================================== AREAS  DETALLE ============================================
            dtAreas = oMaestroService.MostrarAreas(Session.sCodEmp, "").Tables(0)
            cmbAreaDet.DataSource = dtAreas
            cmbAreaDet.DropDownList.DataMember = dtAreas.Columns("DesArea").ToString
            cmbAreaDet.DropDownList.DisplayMember = dtAreas.Columns("DesArea").ToString
            cmbAreaDet.DropDownList.ValueMember = dtAreas.Columns("CodArea").ToString
            cmbAreaDet.DropDownList.Columns(0).DataMember = dtAreas.Columns("CodArea").ToString
            cmbAreaDet.DropDownList.Columns(1).DataMember = dtAreas.Columns("DesArea").ToString
            dtAreas = Nothing

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

            ''====================================PERSONA POSESIÓN===========================================
            'dtPersonaPosesion = oCtasPorPagarService.MostrarPosesion().Tables(0)
            'dtPersonaPosesion.Rows.InsertAt(getRowTodos(dtPersonaPosesion), 0)
            'cmbPersonaPosesion.DisplayMember = dtPersonaPosesion.Columns("ApeNom").ToString()
            'cmbPersonaPosesion.ValueMember = dtPersonaPosesion.Columns("IdPer").ToString
            'cmbPersonaPosesion.DataSource = dtPersonaPosesion
            'cmbPersonaPosesion.SelectedIndex = 0
            'dtPersonaPosesion = Nothing




        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub ObtenerGasto()
        Try
            Dim registro As SolicitudGastoService.SolicitudGasto
            registro = oSolicitudGastoService.Obtener(IdGasto)

            IdGasto = registro.IdGasto
            txtNumGasto.Text = registro.IdGasto
            txtFecha.Value = registro.Fecha
            cmbArea.Value = registro.Area.CodArea
            cmbMoneda.Value = registro.Moneda.CodMon            
            txtPersonaSolicita.Text = registro.PersonaSolicita.ApeNom
            txtPersonaAutoriza.Text = registro.PersonaJefe.ApeNom
            txtObsGasto.Text = registro.Observacion
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Solicitud de Gasto")
        End Try
    End Sub

    Private Sub ObtenerGastoDet()
        Try
            Dim registro As SolicitudGastoDetService.SolicitudGastoDet
            registro = oSolicitudGastoDetService.Obtener(toNumber(IdGastoDet))

            IdGastoDet = registro.IdGastoDet
            IdGasto = registro.SolicitudGasto.IdGasto            
            txtCodCuenta.Text = toNull(registro.CuentaContable.CodCuenta)
            txtCantidad.Value = registro.Cantidad
            'cmbMoneda.Value = registro.Moneda.CodMon
            'txtNumJob.Text = registro.Job.CodJob
            'cmbAreaDet.Value = registro.CentroCosto.Area.CodArea
            txtIgv.Value = registro.Igv
            txtDescripcion.Text = registro.Descripcion
            txtProveedor.Text = registro.Proveedor.DesProv
            IdProveedor = registro.Proveedor.IdProveedor
            If registro.CondicionPagoProveedor.IdCondicion <> 0 Then
                cmbCondPago.Value = registro.CondicionPagoProveedor.IdCondicion
            Else
                cmbCondPago.SelectedIndex = 0
            End If
            If registro.TipoDocumento.IdDocumento <> 0 Then
                cmbTipoDoc.Value = registro.TipoDocumento.IdDocumento
            Else
                cmbTipoDoc.SelectedIndex = 0
            End If
            IdDocumento = registro.TipoDocumento.IdDocumento
            cbAfectoIgv.Checked = registro.Afecto
            txtMonto.Value = registro.Monto
            txtMontoSinIgv.Value = registro.MontoSinIgv
            txtMontoNoAfecto.Value = registro.MontoNoAfecto
            txtNumDoc.Text = registro.NumDoc
            txtSerieDoc.Text = registro.SerDoc
            If Not (registro.FecDoc.ToString = "") Then
                txtFecDoc.Value = CDate(registro.FecDoc)
                txtFecDoc.Text = registro.FecDoc.ToString
            End If
            txtJustificacion.Text = registro.Justificacion
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Detalle de Solicitud de Gasto")
        End Try
    End Sub

    Private Sub ObtenerMesa()
        Try
            'Dim registro As MesaControlService.MesaControl
            'registro = oMesaControlService.Obtener(IdMesa)

            'IdMesa = registro.IdMesa
            ''txtIdMesa.Text = registro.IdMesa                     
            ''cbProcesarCredito.Checked = registro.Credito
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Mesa de Control")
        End Try
    End Sub

    Private Sub ObtenerCuenta()
        Try
            Dim registro As CtasPorPagarService.CtasPorPagar
            registro = oCtasPorPagarService.Obtener(IdCuenta)

            IdCuenta = registro.IdCuenta
            'txtIdCuenta.Text = registro.IdCuenta           
            'txtFecRecepcion.Value = registro.FecRecepcion
            'txtFecVencimiento.Value = registro.FecVencimiento
            'txtFecVencimiento.Text = registro.FecVencimiento.ToString
            cmbCodPago.Value = registro.CondicionPagoProveedor.IdCondicion
            'txtTotal.Value = registro.Total
            'txtTotalPago.Value = registro.TotalPago
            'cbRecibioCheque.Checked = registro.RecibioCheque
            'cbPagoCaja.Checked = registro.PagoCaja
            'If registro.Persona.IdPer = Nothing Then
            '    cmbPersonaPosesion.SelectedIndex = 0
            'Else
            '    cmbPersonaPosesion.SelectedValue = registro.Persona.IdPer
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Cuenta Por Pagar")
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
        Catch ex As Exception
            MsgBox("ERROR AL ACTUALIZAR DETALLES: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oTesoreriaDet.MostrarPagosDocumento(IdProveedor, IdDocumento, txtSerieDoc.Text, txtNumDoc.Text).Tables(0)
            dgvDatos.DataSource = dtDatos            
        Catch ex As Exception
            MsgBox("ERROR AL LISTAR DATOS: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
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

    Private Sub cmMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick, miMostrar.Click
        If dgvDatos.RecordCount > 0 Then
            Try
                Dim frm As New frmAsientosDet
                Dim IdTesoreria As Int64 = dgvDatos.CurrentRow.Cells("IdTesoreria").Text
                Dim TC As Double = dgvDatos.CurrentRow.Cells("TipCam").Text
                frm.state_button = True
                frm.editable = True
                frm.edicion = False
                frm.iEditable = oTesoreriaService.BuscarEditable(IdTesoreria)
                frm.IdTesoreriaDet = dgvDatos.CurrentRow.Cells("IdTesoreriaDet").Text
                frm.IdTesoreria = IdTesoreria
                frm.CodMon = cmbMoneda.Value
                frm.TipoCambio = TC
                frm.biGuardar.Visible = False
                frm.biEditar.Visible = False
                frm.biAsignar.Visible = False
                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    listaDatos()
                End If
            Catch ex As Exception
                MsgBox("ERROR AL MOSTRAR EL DETALLE: " + ex.Message, MsgBoxStyle.Exclamation)
            End Try
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