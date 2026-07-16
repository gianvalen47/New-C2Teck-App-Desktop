Imports System.Windows.Forms
Imports System.ServiceModel
Public Class frmDocsCredito
    Private oMaestroService As New MaestroService.MaestroClient
    Private oDocumentoCtaCtes As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oPlanillaDetalleService As New PlanillaDetalleService.PlanillaDetalleServiceClient
    Private ObjPlanilla As New PlanillaService.PlanillaServiceClient
    Private dtDocumento As New DataTable
    Private dtCondicion As New DataTable
    Private dtEstado As New DataTable
    Private dtPagos As New DataTable
    Private dtCobrador As New DataTable
    Private dtMoneda As New DataTable
    Private TipDoc As Integer
    Private IdVenta As Int64
    Private IdCliente As Int64
    Public IdDocCtaCte As Int64
    Public Transa As String   '(I = INGRESAR, U = ACTUALIZAR, M = MOSTRAR)

    Private Sub frmDocsCredito_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            oMaestroService.Close()
            oDocumentoCtaCtes.Close()
            ObjPlanilla.Close()
            oPlanillaDetalleService.Close()
        Catch ex As TimeoutException
            oMaestroService.Abort()
            oDocumentoCtaCtes.Abort()
            ObjPlanilla.Abort()
            oPlanillaDetalleService.Abort()
        Catch ex As CommunicationException
            oMaestroService.Abort()
            oDocumentoCtaCtes.Abort()
            ObjPlanilla.Abort()
            oPlanillaDetalleService.Abort()
        End Try

        'Me.Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Private Function getRowAsignado(ByVal data As DataTable)
        Dim fila As DataRow = data.NewRow
        Try
            fila(0) = ""
        Catch ex As Exception

        End Try
        Try
            fila(1) = "Ninguno"
        Catch ex As Exception

        End Try

        Return fila
    End Function
    Private Sub frmDocsCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub frmDocsCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                 txtAlmacen.KeyPress _
                 , txtApeMat.KeyPress _
                 , cbDocumento.KeyPress _
                 , txtApePat.KeyPress _
                 , txtDni.KeyPress _
                 , txtFechaEmision.KeyPress _
                 , txtFechaRecepcion.KeyPress _
                 , txtFechaVencimiento.KeyPress _
                 , cbCondicionPago.KeyPress _
                 , txtImporteNS.KeyPress _
                 , txtImporteUS.KeyPress _
                 , txtNombres.KeyPress _
                 , txtNumDoc.KeyPress _
                 , txtObservacion.KeyPress _
                 , txtOficina.KeyPress _
                 , txtRuc.KeyPress _
                 , cbCobrador.KeyPress _
                 , cbCodMon.KeyPress
        ', txtGuia.KeyPress _
        ', txtRenovacion.KeyPress _
        '  , txtCliente.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub frmDocsCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExtAlternating(dgvDatos)
        dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        dgvDatos.RowFormatStyle.FontSize = 7.5!
        LlenarCombos()
        ObtenerDatos()
        MostrarPagos()
        Activar()
    End Sub

    Private Sub Activar()
        Select Case Transa
            Case "I"
                cbDocumento.ReadOnly = False
                txtNumDoc.ReadOnly = False
                btnModificar.Enabled = False
                btnGrabar.Enabled = True
                btnCancelar.Enabled = True
                lblEstado.Visible = False
                cbEstado.Visible = False
                cbCondicionPago.ReadOnly = False
                cbCodMon.Value = "US"
                CMenu.Enabled = False
                btnCliente.Enabled = True
                cbCodMon.ReadOnly = False
                txtFechaEmision.ReadOnly = False
                txtFechaVencimiento.ReadOnly = False
                txtImporteNS.ReadOnly = False
                txtImporteUS.ReadOnly = False
                txtObservacion.ReadOnly = False
                cbCobrador.ReadOnly = False
                txtTipoCambio.ReadOnly = False
            Case "U"
                btnModificar.Enabled = False
                btnGrabar.Enabled = True
                btnCancelar.Enabled = True
                lblEstado.Visible = True
                cbEstado.Visible = True
                'lblCobrador.Visible = True
                'cbCobrador.Visible = True
                txtFechaRecepcion.ReadOnly = False
                txtFechaVencimiento.ReadOnly = False
                cbEstado.ReadOnly = False
                '=============== Solicitud de Usuario 4965 ================== 
                '------ Se agrega el Perfil de Costos 02/08/2016
                '----------------Se agrega el perfil de Cobrador 12/09/2016 (Sr Erick)-------------
                '----------------Se quito el perfil de Cobrador 18/06/2019 (Nro solicitud: 65749) (Sr Erick)-------------
                If Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "14" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05" Or Session.CodPerfil = "57" Or Session.CodPerfil = "28" Then
                    cbCondicionPago.ReadOnly = False
                Else
                    cbCondicionPago.ReadOnly = True
                End If
                '====================================================
                cbCobrador.ReadOnly = False
                txtObservacion.ReadOnly = False
                CMenu.Enabled = False
            Case "M"
                btnModificar.Enabled = True
                btnCancelar.Enabled = False
                btnGrabar.Enabled = False
                txtObservacion.ReadOnly = True
                txtFechaRecepcion.ReadOnly = True
                txtFechaVencimiento.ReadOnly = True
                cbEstado.ReadOnly = True
                cbCondicionPago.ReadOnly = True
                cbCobrador.ReadOnly = True
                If Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "14" Or Session.CodPerfil = "01" Or Session.CodPerfil = "05" Or Session.CodPerfil = "57" Or Session.CodPerfil = "28" Or Session.CodPerfil = "22" Then      '------ Se agrega el Perfil de Costos 02/08/2016 ' Agregado perfil 22 contabilidad
                    CMenu.Enabled = True
                Else
                    CMenu.Enabled = False
                End If

        End Select
    End Sub

    Private Sub MostrarDocumento()
        Dim TC As Double = 0
        Try

            If oDocumentoCtaCtes.Buscar(cbDocumento.Value, txtNumDoc.Text) Then
                MsgBox("Este Documento ya Existe, Verifique.!!!!!", MsgBoxStyle.Information, "Ya Existe")
            Else
                If oDocumentoCtaCtes.BuscarDocumento(cbDocumento.Value, txtNumDoc.Text) Then
                    Dim Documento As New DocumentoCtaCtesService.VDocumentoCredito
                    Documento = oDocumentoCtaCtes.MostrarPorDoc(cbDocumento.Value, txtNumDoc.Text)
                    TipDoc = Documento.TipDoc
                    IdVenta = Documento.IdVenta
                    IdCliente = Documento.Cliente.IdCliente
                    txtCliente.Text = Documento.Cliente.DesCli
                    txtRuc.Text = Documento.Cliente.RucCli
                    txtDni.Text = Documento.Cliente.DniCli
                    txtNombres.Text = Documento.Cliente.Nombres
                    txtApePat.Text = Documento.Cliente.ApePat
                    txtApeMat.Text = Documento.Cliente.ApeMat
                    txtFechaEmision.Text = Documento.FecDoc
                    txtFechaRecepcion.Text = Documento.FecDoc
                    cbCodMon.Value = Documento.Moneda.CodMon
                    txtOficina.Text = Documento.Locacion.Oficina.DesOfi
                    txtAlmacen.Text = Documento.Locacion.Almacen.DesAlm
                    TC = oMaestroService.MostrarTipoCambio("US", Documento.FecDoc)
                    txtTipoCambio.Text = TC
                    txtImporteUS.Text = IIf(Documento.Moneda.CodMon = "US", Documento.TotNeto, 0)
                    txtImporteNS.Text = IIf(Documento.Moneda.CodMon = "US", Documento.TotNeto * TC, Documento.TotNeto)
                    txtGuia.Text = Documento.NumGuis
                    cbCondicionPago.Value = IIf(Documento.CondicionPago.CodPag Is Nothing, "00", Documento.CondicionPago.CodPag)
                    txtFechaVencimiento.Text = oDocumentoCtaCtes.CalcularFecVen(cbCondicionPago.Value, Documento.FecDoc)
                Else
                    cbCodMon.ReadOnly = False
                    btnCliente.Enabled = True
                    txtFechaEmision.ReadOnly = False
                    txtFechaVencimiento.ReadOnly = False
                    txtFechaEmision.Text = Today
                    txtFechaRecepcion.Text = Today
                    txtFechaVencimiento.Text = Today
                    txtTipoCambio.Text = oMaestroService.MostrarTipoCambio("US", Today)
                End If
            End If
            txtImporteUS.ReadOnly = False
            txtImporteNS.ReadOnly = False
            txtObservacion.ReadOnly = False
            cbCondicionPago.ReadOnly = False


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
        End If
    End Sub

    Private Sub LlenarCombos()

        Try
            dtDocumento = oPlanillaDetalleService.MostrarSerieDocumentoCtaCte(Session.sCodEmp).Tables(0)
            cbDocumento.DataSource = dtDocumento
            cbDocumento.DisplayMember = "Descripcion"
            cbDocumento.ValueMember = "IdSerieDoc"
            cbDocumento.DropDownList.Columns(0).DataMember = "IdSerieDoc"
            cbDocumento.DropDownList.Columns(1).DataMember = "Descripcion"
            cbDocumento.SelectedIndex = 0
            ' dtDocumento = Nothing

            dtCondicion = oMaestroService.MostrarCondicionPago.Tables(0)
            cbCondicionPago.DataSource = dtCondicion
            cbCondicionPago.DisplayMember = "DesPag"
            cbCondicionPago.ValueMember = "CodPag"
            cbCondicionPago.DropDownList.Columns(0).DataMember = "CodPag"
            cbCondicionPago.DropDownList.Columns(1).DataMember = "DesPag"
            cbCondicionPago.SelectedIndex = 0
            dtCondicion = Nothing

            dtEstado = oDocumentoCtaCtes.MostrarEstados.Tables(0)
            cbEstado.DataSource = dtEstado
            cbEstado.DisplayMember = "DesEst"
            cbEstado.ValueMember = "CodEst"
            cbEstado.DropDownList.Columns(0).DataMember = "CodEst"
            cbEstado.DropDownList.Columns(1).DataMember = "DesEst"
            cbEstado.SelectedIndex = 0
            dtEstado = Nothing

            'dtCobrador = oMaestroService.MostrarCobradores.Tables(0)
            'dtCobrador.Rows.InsertAt(getRowAsignado(dtCobrador), 0)
            'cbCobrador.DataSource = dtCobrador
            'cbCobrador.DisplayMember = "ApeNom"
            'cbCobrador.ValueMember = "IdPer"
            'cbCobrador.DropDownList.Columns(0).DataMember = "IdPer"
            'cbCobrador.DropDownList.Columns(1).DataMember = "ApeNom"
            'cbCobrador.SelectedIndex = 1
            'dtCobrador = Nothing

            dtCobrador = ObjPlanilla.MostrarCobradores(Session.sCodEmp).Tables(0) 'ObjMaestro.MostrarCobradores.Tables(0)
            dtCobrador.Rows.InsertAt(getRowAsignado(dtCobrador), 0)
            cbCobrador.DataSource = dtCobrador
            cbCobrador.DisplayMember = "ApeNom"
            cbCobrador.ValueMember = "IdPer"
            cbCobrador.DropDownList.Columns(0).DataMember = "IdPer"
            cbCobrador.DropDownList.Columns(1).DataMember = "ApeNom"
            cbCobrador.SelectedIndex = 0
            dtCobrador = Nothing

            dtMoneda = oMaestroService.MostrarMonedas.Tables(0)
            cbCodMon.DataSource = dtMoneda
            cbCodMon.DisplayMember = "CodMon"
            cbCodMon.ValueMember = "CodMon"
            cbCodMon.DropDownList.Columns(0).DataMember = "CodMon"
            cbCodMon.DropDownList.Columns(1).DataMember = "AbrMon"
            cbCodMon.SelectedIndex = 0
            dtMoneda = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Combos")
        End Try
    End Sub

    Private Sub ObtenerDatos()
        If Transa <> "I" Then
            Try
                Dim documentoCtaCte As New DocumentoCtaCtesService.DocumentoCtaCte
                documentoCtaCte = oDocumentoCtaCtes.MostrarPorId(IdDocCtaCte)
                TipDoc = documentoCtaCte.TipDoc
                IdVenta = documentoCtaCte.VDocumentoCredito.IdVenta
                cbDocumento.Value = documentoCtaCte.SerieDocumento.IdSerieDoc
                txtSerie.Text = documentoCtaCte.SerieDocumento.CodSerie
                txtNumDoc.Text = documentoCtaCte.NumDoc
                cbCodMon.Value = documentoCtaCte.Moneda.CodMon
                txtTipoCambio.Text = documentoCtaCte.TipCam
                txtNumJob.Text = documentoCtaCte.VDocumentoCredito.NumJob
                IdCliente = documentoCtaCte.Cliente.IdCliente
                txtCliente.Text = documentoCtaCte.Cliente.DesCli
                txtRuc.Text = documentoCtaCte.Cliente.RucCli
                txtDni.Text = documentoCtaCte.Cliente.DniCli
                txtNombres.Text = documentoCtaCte.Cliente.Nombres
                txtApePat.Text = documentoCtaCte.Cliente.ApePat
                txtApeMat.Text = documentoCtaCte.Cliente.ApeMat
                txtOficina.Text = documentoCtaCte.VDocumentoCredito.Locacion.Oficina.DesOfi
                txtAlmacen.Text = documentoCtaCte.VDocumentoCredito.Locacion.Almacen.DesAlm
                txtGuia.Text = documentoCtaCte.VDocumentoCredito.NumGuis
                txtFechaEmision.Text = documentoCtaCte.FecDoc
                txtFechaRecepcion.Text = documentoCtaCte.FecRec
                txtFechaVencimiento.Text = documentoCtaCte.VenDoc
                txtImporteUS.Text = documentoCtaCte.TotDol
                txtImporteNS.Text = documentoCtaCte.TotSol
                txtObservacion.Text = documentoCtaCte.Observacion
                cbCondicionPago.Value = documentoCtaCte.CondicionPago.CodPag
                cbEstado.Value = documentoCtaCte.Estado.CodEst
                cbCobrador.Value = documentoCtaCte.Persona.IdPer
                txtRenovacion.Text = documentoCtaCte.Renova
                txtSaldoUS.Text = documentoCtaCte.TotDol - documentoCtaCte.DolPag
                txtSaldoNS.Text = documentoCtaCte.TotSol - documentoCtaCte.SolPag
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Obtener Datos")
            End Try
        End If
    End Sub

    Private Sub MostrarPagos()
        Try
            dtPagos = oDocumentoCtaCtes.MostrarPagos(IdDocCtaCte).Tables(0)
            dgvDatos.SetDataBinding(dtPagos, 0)
            HabilitarOpciones()
            sslTotal.Text = "Registros : " + dgvDatos.RowCount.ToString

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al Cargar Pagos")
        End Try

    End Sub

    Private Sub HabilitarOpciones()
        If dtPagos.Rows.Count > 0 Then
            cmNuevo.Enabled = True
            cmMostrar.Enabled = True
            cmModificar.Enabled = True
            cmActualizar.Enabled = True
            cmEliminar.Enabled = True
        Else
            cmModificar.Enabled = False
            cmEliminar.Enabled = False
            cmMostrar.Enabled = False
        End If
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Transa = "U"
        Activar()
    End Sub

    Private Sub cmMostrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmMostrar.Click, dgvDatos.DoubleClick
        If dgvDatos.RecordCount > 0 Then
            Dim forma As New frmDocsCreditoPago
            forma.IdDocCtaCte = IdDocCtaCte
            forma.IdPagoCtaCte = dgvDatos.CurrentRow.Cells("IdPagoCtaCte").Text
            forma.Transa = "M"
            forma.ShowDialog()
        End If

    End Sub

    Private Sub cmNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmNuevo.Click
        Try
            Dim forma As New frmDocsCreditoPago
            forma.IdDocCtaCte = IdDocCtaCte
            forma.Transa = "I"
            If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtPagos = Nothing
                MostrarPagos()
                ObtenerDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al abrir Formulario")
        End Try

    End Sub

    Private Sub cbDocumento_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbDocumento.Validating
        Try
            If Transa = "I" Then
                txtSerie.Text = IIf(IsDBNull(dtDocumento.Rows(cbDocumento.SelectedIndex).Item("CodSerie")), Nothing, dtDocumento.Rows(cbDocumento.SelectedIndex).Item("CodSerie"))
                Activar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de combo")
        End Try
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            If MsgBox("¿Está seguro de GRABAR los datos?", MsgBoxStyle.YesNo, "Grabar") = MsgBoxResult.Yes And ValidaCampos() Then
                Dim registro As New DocumentoCtaCtesService.DocumentoCtaCte
                Dim vDocumentoCredito As New DocumentoCtaCtesService.VDocumentoCredito
                Dim condicion As New DocumentoCtaCtesService.CondicionPago
                Dim cobrador As New DocumentoCtaCtesService.Persona
                Dim estado As New DocumentoCtaCtesService.Estado
                Dim Serie As New DocumentoCtaCtesService.SerieDocumento
                Dim cliente As New DocumentoCtaCtesService.Cliente
                Dim moneda As New DocumentoCtaCtesService.Moneda


                registro.IdDocCtaCte = IdDocCtaCte
                registro.TipCta = "1"
                registro.TipDoc = TipDoc
                vDocumentoCredito.IdVenta = IdVenta
                registro.VDocumentoCredito = vDocumentoCredito
                Serie.IdSerieDoc = cbDocumento.Value
                registro.SerieDocumento = Serie
                registro.NumDoc = txtNumDoc.Text
                cliente.IdCliente = IdCliente
                registro.Cliente = cliente
                registro.FecDoc = txtFechaEmision.Text
                registro.FecRec = txtFechaRecepcion.Text
                registro.VenDoc = txtFechaVencimiento.Text
                moneda.CodMon = cbCodMon.Value
                registro.Moneda = moneda
                registro.TipCam = txtTipoCambio.Text
                condicion.CodPag = cbCondicionPago.Value
                registro.CondicionPago = condicion
                cobrador.IdPer = IIf(cbCobrador.Text = "Ninguno", Nothing, cbCobrador.Value)
                registro.Persona = cobrador
                registro.TotDol = txtImporteUS.Text
                registro.TotSol = txtImporteNS.Text
                estado.CodEst = cbEstado.Value
                registro.Estado = estado
                registro.Observacion = txtObservacion.Text

                registro.CodUsu = Session.sCodUsu
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If Transa = "I" Then
                    IdDocCtaCte = oDocumentoCtaCtes.Insertar(registro)
                Else
                    oDocumentoCtaCtes.Actualizar(registro)
                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Ingreso")
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("¿Desea Deshacer los Cambios realizados ... ?", MsgBoxStyle.YesNo, "Cancelar") = MsgBoxResult.Yes Then
            If Transa = "I" Then
                Close()
            Else
                ObtenerDatos()
                Transa = "M"
                Activar()
            End If
        End If

    End Sub

    Private Sub cmModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmModificar.Click
        Try
            Dim forma As New frmDocsCreditoPago
            forma.IdDocCtaCte = IdDocCtaCte
            forma.IdPagoCtaCte = dgvDatos.CurrentRow.Cells("IdPagoCtaCte").Text
            forma.Transa = "U"
            If forma.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                dtPagos = Nothing
                MostrarPagos()
                ObtenerDatos()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Al abrir Formulario")
        End Try
    End Sub

    Private Sub cmEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmEliminar.Click
        Try
            If MsgBox("¿Está seguro de ELIMINAR el pago seleccionado?".ToString, MsgBoxStyle.YesNo, "Eliminar") = MsgBoxResult.Yes Then
                Dim estado_process As Boolean
                estado_process = oDocumentoCtaCtes.BorrarPago(dgvDatos.CurrentRow.Cells("IdPagoCtaCte").Text, IdDocCtaCte, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
                If estado_process Then
                    MsgBox("Se eliminó el pago correctamente")
                    MostrarPagos()
                    ObtenerDatos()
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-002]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            IdCliente = frm.codigo
            Dim oClienteService As New ClienteService.ClienteServiceClient
            Dim cliente As New ClienteService.Cliente
            cliente = oClienteService.MostrarPorID(IdCliente)
            txtCliente.Text = cliente.DesCli
            txtRuc.Text = cliente.RucCli
            txtDni.Text = cliente.DniCli
            txtNombres.Text = cliente.Nombres
            txtApePat.Text = cliente.ApePat
            txtApeMat.Text = cliente.ApeMat
            txtCliente.Select()
        End If
    End Sub

    Private Function ValidaCampos() As Boolean
        Try
            If toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el Cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf cbCodMon.Value = "US" And txtImporteUS.Text <= 0 Then
                MsgBox("Debe Ingresar el Monto en Dolares ", MsgBoxStyle.Information, "Información")
                txtImporteUS.BackColor = Color.Red
                txtImporteUS.Focus()
                Return False
            ElseIf cbCodMon.Value = "NS" And txtImporteNS.Text < 0 Then
                MsgBox("Debe Ingresar el Monto en Soles ", MsgBoxStyle.Information, "Información")
                txtImporteNS.BackColor = Color.Red
                txtImporteNS.Focus()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error de Ingreso")
        End Try
    End Function

    'Private Sub txtFechaEmision_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaEmision.ValueChanged
    '    Try
    '        Dim TC As Double = oMaestroService.MostrarTipoCambio("US", txtFechaEmision.Text)
    '        If TC Then
    '            txtTipoCambio.Text = TC
    '        Else
    '            MsgBox("No hay tipo de cambio para esta fecha, tenga cuidado")
    '            txtFechaEmision.Select()
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Tipo de Cambio")
    '    End Try
    'End Sub

    Private Sub txtTipoCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnCliente.Select()
        End If
    End Sub

    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtFechaEmision.Focus()
        End If
    End Sub
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnGrabar.Enabled = True Then
                btnGrabar.Select()
                btnGrabar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtNumDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumDoc.Validating
        If Transa = "I" Then
            MostrarDocumento()
        End If
        ' OK_Button.Enabled = True
    End Sub

    Private Sub txtImporteUS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtImporteUS.Validating
        If txtImporteNS.ReadOnly = False Then
            txtImporteNS.Text = Math.Round(txtImporteUS.Text * txtTipoCambio.Text, 2)
        End If
    End Sub

    Private Sub cbCondicionPago_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCondicionPago.ValueChanged
        Try
            If Transa = "U" Then
                If txtFechaRecepcion.Text <> "" Then
                    txtFechaVencimiento.Text = oDocumentoCtaCtes.CalcularFecVen(cbCondicionPago.Value, txtFechaRecepcion.Text)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub

    Private Sub txtFechaRecepcion_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFechaRecepcion.Validating
        Try
            If Transa = "U" Then
                If txtFechaRecepcion.Text <> "" Then
                    txtFechaVencimiento.Text = oDocumentoCtaCtes.CalcularFecVen(cbCondicionPago.Value, txtFechaRecepcion.Text)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Data")
        End Try
    End Sub
End Class