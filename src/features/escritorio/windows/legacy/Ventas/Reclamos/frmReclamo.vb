Public Class frmReclamo

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String
    Private oReclamo As New ReclamoService.ReclamoServiceClient
    Private oGuiaRemisionDetService As New GuiaRemisionDetService.GuiaRemisionDetServiceClient
    Private oGuiaRemisionService As New GuiaRemisionService.GuiaRemisionServiceClient
    Private oBoletaDetService As New BoletaDetalleService.BoletaDetalleServiceClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oFacturaDetService As New FacturaDetalleService.FacturaDetalleServiceClient
    Private oFacturaService As New FacturaService.FacturaServiceClient

    Private IdCliente As Integer
    Public IdReclamo As Integer
    Public IdLocacion As Integer
    Public Codigo As Int64
    Private IdVentaDet As Integer
    Private TipoDoc As Integer
    Private IntTer As String
    Private Casco As String
    Private Cubierta As String
    Private ColHidro As String
    Private MedDen As String
    Private NivElec As String
    Private Resultado As String
    Private LibMan As Boolean
    Private ConVen As Boolean
    Public Estado As String
    Private dtMercaderia As DataTable

    Private Sub frmReclamo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    Private Sub frmReclamo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
         txtDocInterno.KeyPress _
        , txtNumDoc.KeyPress _
        , cmbMercaderia.KeyPress _
        , cbFecFinal.KeyPress _
        , cbFecInicio.KeyPress, txtCliente.KeyPress, txtGuiaRemitente.KeyPress, txtCertificado.KeyPress, txtNumControl.KeyPress _
        , txtAplicación.KeyPress, txtVoltios.KeyPress, txtSimulacion.KeyPress, txtVoltajeI.KeyPress, txtDefectuosaI.KeyPress _
        , txtOptimaI.KeyPress, txtVoltajeII.KeyPress, txtDefectuosaII.KeyPress, txtOptimaII.KeyPress, txtOtros.KeyPress
        ', txtSimulacion.KeyPress _
        ', txtOtros.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub frmReclamo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If state_button Then
            ObtenerRegistro()
            desactivar()

            enableOpciones()

        Else

            Dim Mes, Anio As Integer
            Dim Fecha As Date
            Fecha = Today
            Mes = IIf(Month(Fecha) = 1, 12, Month(Fecha))
            Anio = IIf(Month(Fecha) = 1, Year(Fecha) - 1, Year(Fecha))
            cbFecInicio.Value = "01/" & Trim(Mes) & "/" & Trim(Anio)
            cbFecFinal.Value = Session.sFecha 'Fecha
            btnBuscarDoc.Select()
            biEditar.Enabled = False
            biSalir.Enabled = False
            txtCanMer.Text = 1
        End If

    End Sub
    Private Sub listarMercaderia()
        Try
            If toNumber(Codigo) > 0 Then
                If TipoDoc = 1 Then
                    dtMercaderia = oGuiaRemisionDetService.Mostrar(toNumber(Codigo)).Tables(0)
                    cmbMercaderia.DataSource = dtMercaderia
                    cmbMercaderia.DropDownList.DataMember = dtMercaderia.Columns("DesMer1").ToString
                    cmbMercaderia.DropDownList.DisplayMember = dtMercaderia.Columns("DesMer1").ToString
                    cmbMercaderia.DropDownList.ValueMember = dtMercaderia.Columns("IdGuiaDet").ToString
                    cmbMercaderia.DropDownList.Columns(0).DataMember = dtMercaderia.Columns("CodMer").ToString
                    cmbMercaderia.DropDownList.Columns(1).DataMember = dtMercaderia.Columns("DesMer1").ToString
                    cmbMercaderia.DropDownList.Columns(2).DataMember = dtMercaderia.Columns("IdGuiaDet").ToString
                    dtMercaderia = Nothing

                    Dim registro As New GuiaRemisionService.GuiaRemision
                    registro = oGuiaRemisionService.MostrarPorId(Codigo)
                    txtCliente.Text = registro.Cliente.DesCli
                    cbFecFinal.Text = registro.FecDoc
                    txtTelefono.Text = registro.Cliente.TelCli

                ElseIf TipoDoc = 2 Then
                    dtMercaderia = oFacturaDetService.Mostrar(toNumber(Codigo)).Tables(0)
                    cmbMercaderia.DataSource = dtMercaderia
                    cmbMercaderia.DropDownList.DataMember = dtMercaderia.Columns("DesMer1").ToString
                    cmbMercaderia.DropDownList.DisplayMember = dtMercaderia.Columns("DesMer1").ToString
                    cmbMercaderia.DropDownList.ValueMember = dtMercaderia.Columns("IdFacturaDet").ToString
                    cmbMercaderia.DropDownList.Columns(0).DataMember = dtMercaderia.Columns("CodMer").ToString
                    cmbMercaderia.DropDownList.Columns(1).DataMember = dtMercaderia.Columns("DesMer1").ToString
                    cmbMercaderia.DropDownList.Columns(2).DataMember = dtMercaderia.Columns("IdFacturaDet").ToString
                    dtMercaderia = Nothing

                    Dim registro As New FacturaService.Factura
                    registro = oFacturaService.MostrarPorId(Codigo)
                    txtCliente.Text = registro.Cliente.DesCli
                    cbFecFinal.Text = registro.FecDoc
                    txtTelefono.Text = registro.Cliente.TelCli

                ElseIf TipoDoc = 3 Then
                    dtMercaderia = oBoletaDetService.Mostrar(toNumber(Codigo)).Tables(0)
                    cmbMercaderia.DataSource = dtMercaderia
                    cmbMercaderia.DropDownList.DataMember = dtMercaderia.Columns("DesMer1").ToString
                    cmbMercaderia.DropDownList.DisplayMember = dtMercaderia.Columns("DesMer1").ToString
                    cmbMercaderia.DropDownList.ValueMember = dtMercaderia.Columns("IdBoletaDet").ToString
                    cmbMercaderia.DropDownList.Columns(0).DataMember = dtMercaderia.Columns("CodMer").ToString
                    cmbMercaderia.DropDownList.Columns(1).DataMember = dtMercaderia.Columns("DesMer1").ToString
                    cmbMercaderia.DropDownList.Columns(2).DataMember = dtMercaderia.Columns("IdBoletaDet").ToString
                    dtMercaderia = Nothing

                    Dim registro As New BoletaService.Boleta
                    registro = oBoletaService.MostrarPorId(Codigo)
                    txtCliente.Text = registro.Cliente.DesCli
                    cbFecFinal.Text = registro.FecDoc
                    txtTelefono.Text = registro.Cliente.TelCli
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-006]: " + ex.Message, MsgBoxStyle.Exclamation)

        End Try

    End Sub
    Private Sub activar()
        cmbMercaderia.ReadOnly = False
        cmbMercaderia.BackColor = System.Drawing.SystemColors.Control
        txtCliente.ReadOnly = True
        'txtCliente.BackColor = System.Drawing.SystemColors.Control
        txtAplicación.ReadOnly = False
        txtCanMer.ReadOnly = False
        txtCertificado.ReadOnly = False
        txtDefectuosaI.ReadOnly = False
        txtDefectuosaII.ReadOnly = False
        txtDocInterno.ReadOnly = False
        txtGuiaRemitente.ReadOnly = False
        txtModelo.ReadOnly = True
        txtNumControl.ReadOnly = False
        txtOptimaI.ReadOnly = False
        txtOptimaII.ReadOnly = False
        txtOtros.ReadOnly = False
        txtSimulacion.ReadOnly = False
        'txtTelefono.ReadOnly = False
        txtVoltajeI.ReadOnly = False
        txtVoltajeII.ReadOnly = False
        txtVoltioI.ReadOnly = False
        txtVoltios.ReadOnly = False
        'rb1.Enabled = True
        'rb2.Enabled = True
        'rb3.Enabled = True
        'rb4.Enabled = True
        'rb5.Enabled = True
        'rbBrilloso.Enabled = True
        'rbCorroides.Enabled = True
        'rbDebajoNivel.Enabled = True
        'rbDeformados.Enabled = True
        'rbEncimaNivel.Enabled = True
        'rbFiltracion.Enabled = True
        'rbGarantia.Enabled = True
        'rbGolpeadaCub.Enabled = True
        'rbGolpeadoCas.Enabled = True
        'rbNegro.Enabled = True
        'rbNoProcede.Enabled = True
        'rbNormal.Enabled = True
        'rbNormal.Enabled = True
        'rbOk.Enabled = True
        'rbOkCas.Enabled = True
        'rbOkCub.Enabled = True
        'rbOperativa.Enabled = True
        'rbReconstruidos.Enabled = True
        'rbVerde.Enabled = True
        gbCasco.Enabled = True
        gbColHidro.Enabled = True
        gbCubierta.Enabled = True
        gbIntTer.Enabled = True
        gbMedDen.Enabled = True
        gbNivElec.Enabled = True
        gbResultado.Enabled = True
        rcConvencional.Enabled = True
        rcLibreMantenimiento.Enabled = True
        cbFecInicio.ReadOnly = False
        cbFecFinal.ReadOnly = False
        biDeshacer.Enabled = True
        biEditar.Enabled = False
        biGrabar.Enabled = True
    End Sub
    Private Sub desactivar()
        cmbMercaderia.ReadOnly = True
        cmbMercaderia.BackColor = System.Drawing.SystemColors.Control
        txtCliente.ReadOnly = True
        'txtCliente.BackColor = System.Drawing.SystemColors.Control 
        txtAplicación.ReadOnly = True
        txtCanMer.ReadOnly = True
        txtCertificado.ReadOnly = True
        txtDefectuosaI.ReadOnly = True
        txtDefectuosaII.ReadOnly = True
        txtDocInterno.ReadOnly = True
        txtGuiaRemitente.ReadOnly = True
        txtModelo.ReadOnly = True
        txtNumControl.ReadOnly = True
        txtNumDoc.ReadOnly = True
        txtOptimaI.ReadOnly = True
        txtOptimaII.ReadOnly = True
        txtOtros.ReadOnly = True
        txtSimulacion.ReadOnly = True
        txtTelefono.ReadOnly = True
        txtVoltajeI.ReadOnly = True
        txtVoltajeII.ReadOnly = True
        txtVoltioI.ReadOnly = True
        txtVoltios.ReadOnly = True
        rb1.Enabled = False
        rb2.Enabled = False
        rb3.Enabled = False
        rb4.Enabled = False
        rb5.Enabled = False
        'rbBrilloso.Enabled = False
        'rbCorroides.Enabled = False
        'rbDebajoNivel.Enabled = False
        'rbDeformados.Enabled = False
        'rbEncimaNivel.Enabled = False
        'rbFiltracion.Enabled = False
        'rbGarantia.Enabled = False
        'rbGolpeadaCub.Enabled = False
        'rbGolpeadoCas.Enabled = False
        'rbNegro.Enabled = False
        'rbNoProcede.Enabled = False
        'rbNormal.Enabled = False
        'rbNormal.Enabled = False
        'rbOk.Enabled = False
        'rbOkCas.Enabled = False
        'rbOkCub.Enabled = False
        'rbOperativa.Enabled = False
        'rbReconstruidos.Enabled = False
        'rbVerde.Enabled = False

        gbCasco.Enabled = False
        gbColHidro.Enabled = False
        gbCubierta.Enabled = False
        gbIntTer.Enabled = False
        gbMedDen.Enabled = False
        gbNivElec.Enabled = False
        gbResultado.Enabled = False
        rcConvencional.Enabled = False
        rcLibreMantenimiento.Enabled = False
        cbFecInicio.ReadOnly = True
        cbFecInicio.BackColor = System.Drawing.SystemColors.Control
        cbFecFinal.ReadOnly = True
        cbFecFinal.BackColor = System.Drawing.SystemColors.Control
        biDeshacer.Enabled = False
        biEditar.Enabled = True
        biGrabar.Enabled = False
        btnBuscarDoc.Enabled = False
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oReclamo) = False Then
                oReclamo.Close()
            End If
            If isClosed(oGuiaRemisionService) = False Then
                oBoletaService.Close()
            End If
            If isClosed(oBoletaService) = False Then
                oBoletaService.Close()
            End If
            If isClosed(oFacturaService) = False Then
                oFacturaService.Close()
            End If
            If isClosed(oBoletaDetService) = False Then
                oBoletaDetService.Close()
            End If
            If isClosed(oGuiaRemisionDetService) = False Then
                oGuiaRemisionDetService.Close()
            End If
            If isClosed(oFacturaDetService) = False Then
                oFacturaDetService.Close()

            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub enableOpciones()
        If Estado = "GENERADO" Or Estado = "GN" Then
            biGrabar.Enabled = False
            biEditar.Enabled = True
            biDeshacer.Enabled = False
        Else
            biGrabar.Enabled = False
            biEditar.Enabled = False
            biDeshacer.Enabled = False

        End If
    End Sub
    Private Sub Insertar(ByVal registro As ReclamoService.Reclamo)

        Try
            Dim estado_process As Integer
            estado_process = oReclamo.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdReclamo = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Size = New System.Drawing.Size(850, 490)
                state_button = True
                'desactivar()
                'listaDatos()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INSERTAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As ReclamoService.Reclamo)
        Try
            Dim estado_process As Boolean
            estado_process = oReclamo.Actualizar(registro)
            type_process = "update"
            If estado_process Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                desactivar()
                ObtenerRegistro()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [MODIFICAR]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Limpiar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles biGrabar.MouseLeave, biDeshacer.MouseLeave, biEditar.MouseLeave, biSalir.MouseLeave
        sslError.Text = ""
    End Sub
    Private Function ValidaCampos() As Boolean
        Try

            If toBlank(txtDocInterno.Text) = "" Then
                MsgBox("Debe Ingresar el Numero de la G/B/F", MsgBoxStyle.Information, "Información")
                txtDocInterno.BackColor = Color.Red
                txtDocInterno.Focus()
                Return False
            ElseIf toNumber(cmbMercaderia.Value) = 0 Then
                MsgBox("Debe Ingresar la mercaderia.", MsgBoxStyle.Information, "Información")
                cmbMercaderia.BackColor = Color.Red
                cmbMercaderia.Focus()
                Return False
            ElseIf toBlank(cbFecInicio.Text) = "" Then
                MsgBox("Debe Ingresar la Fecha de Ingreso.", MsgBoxStyle.Information, "Información")
                cbFecInicio.BackColor = Color.Red
                cbFecInicio.Focus()
                Return False
            ElseIf toBlank(cbFecFinal.Text) = "" Then
                MsgBox("Debe Figurar la Fecha de Venta.", MsgBoxStyle.Information, "Información")
                cbFecFinal.BackColor = Color.Red
                cbFecFinal.Focus()
                Return False
            ElseIf toBlank(cbFecFinal.Text) = "" Then
                MsgBox("Debe Figurar el cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf toBlank(txtModelo.Text) = "" Then
                MsgBox("Debe Figurar el modelo de la mercaderia.", MsgBoxStyle.Information, "Información")
                txtModelo.BackColor = Color.Red
                txtModelo.Focus()
                Return False
            ElseIf toBlank(txtNumControl.Text) = "" Then
                MsgBox("Debe Ingresar el Número de Control.", MsgBoxStyle.Information, "Información")
                txtNumControl.BackColor = Color.Red
                txtNumControl.Focus()
                Return False
            ElseIf Resultado = 0 Then
                MsgBox("Debe marcar el Resultado .", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub ObtenerRegistro()
        Try
            Dim registro As New ReclamoService.Reclamo
            registro = oReclamo.Obtener(IdReclamo)
            IdReclamo = registro.IdReclamo
            txtNumDoc.Text = registro.IdReclamo
            IdLocacion = registro.Locacion.IdLocacion
            Codigo = registro.DocumentoVentaDet.DocumentoVenta.IdVenta
            txtDocInterno.Text = registro.DocumentoVentaDet.DocumentoVenta.SerieDocumento.TipoDocumento.AbrDoc & " " & registro.DocumentoVentaDet.DocumentoVenta.SerieDocumento.CodSerie & "-" & Trim(registro.DocumentoVentaDet.DocumentoVenta.NumDoc)
            IdVentaDet = registro.DocumentoVentaDet.IdVentaDet
            TipoDoc = registro.TipDoc
            listarMercaderia()
            cmbMercaderia.Value = registro.DocumentoVentaDet.Mercaderia.CodMer
            cmbMercaderia.Text = registro.DocumentoVentaDet.Mercaderia.DesMer1
            txtModelo.Text = registro.DocumentoVentaDet.Mercaderia.CodMer
            txtCanMer.Text = registro.CanMer
            cbFecInicio.Text = registro.FecIng
            txtAplicación.Text = registro.Aplica
            txtGuiaRemitente.Text = registro.GuiCli
            txtTelefono.Text = registro.DocumentoVentaDet.DocumentoVenta.Cliente.TelCli
            LibMan = registro.LibMan
            ConVen = registro.ConVen
            If LibMan = True Then
                rcLibreMantenimiento.Checked = True
            Else
                rcLibreMantenimiento.Checked = False
            End If
            If ConVen = True Then
                rcConvencional.Checked = True
            Else
                rcConvencional.Checked = False
            End If
            txtNumControl.Text = registro.Control
            txtCertificado.Text = registro.Certificado
            Cubierta = registro.Cubierta
            If Cubierta = 1 Then
                rbGolpeadaCub.Checked = True
            ElseIf Cubierta = 2 Then
                rbOkCub.Checked = True
            End If

            Casco = registro.Casco
            If Cubierta = 1 Then
                rbGolpeadoCas.Checked = True
            ElseIf Cubierta = 2 Then
                rbOkCas.Checked = True
            End If

            IntTer = registro.IntTer
            If Cubierta = 1 Then
                rbCorroides.Checked = True
            ElseIf Cubierta = 2 Then
                rbDeformados.Checked = True
            ElseIf IntTer = 3 Then
                rbFiltracion.Checked = True
            ElseIf IntTer = 4 Then
                rbReconstruidos.Checked = True
            ElseIf IntTer = 5 Then
                rbOk.Checked = True
            End If

            ColHidro = registro.ColHidro
            If ColHidro = 1 Then
                rbVerde.Checked = True
            ElseIf ColHidro = 2 Then
                rbNegro.Checked = True
            ElseIf ColHidro = 3 Then
                rbBrilloso.Checked = True
            End If

            txtVoltioI.Text = registro.Voltios
            MedDen = registro.MedDen
            If MedDen = 1 Then
                rb1.Checked = True
            ElseIf MedDen = 2 Then
                rb2.Checked = True
            ElseIf MedDen = 3 Then
                rb3.Checked = True
            ElseIf MedDen = 4 Then
                rb4.Checked = True
            ElseIf MedDen = 5 Then
                rb5.Checked = True
            End If

            NivElec = registro.NivElec
            If NivElec = 1 Then
                rbDebajoNivel.Checked = True
            ElseIf NivElec = 2 Then
                rbNormal.Checked = True
            ElseIf NivElec = 3 Then
                rbEncimaNivel.Checked = True
            End If

            txtVoltios.Text = registro.PVoltios
            txtSimulacion.Text = registro.SimAran
            txtVoltajeI.Text = registro.VolP1
            txtVoltajeII.Text = registro.VolP2
            txtDefectuosaI.Text = registro.ResCarDefP1
            txtDefectuosaII.Text = registro.ResCarDefP2
            txtOptimaI.Text = registro.ResCarOptP1
            txtOptimaII.Text = registro.ResCarOptP2
            txtOtros.Text = registro.Observacion
            Resultado = registro.Resultado
            If Resultado = 1 Then
                rbOperativa.Checked = True
            ElseIf Resultado = 2 Then
                rbNoProcede.Checked = True
            ElseIf Resultado = 3 Then
                rbGarantia.Checked = True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub biEditar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles biEditar.MouseMove
        sslError.Text = "Editar Cabecera del Reclamo de Garantía"
    End Sub
    'Private Sub biGuardar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles biGuardar.MouseMove
    '    sslError.Text = "Guardar Cambios Realizados en el Formulario"
    'End Sub
    Private Sub biDeshacer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles biDeshacer.MouseMove
        sslError.Text = "Deshacer Cambios Realizados en el Formulario"
    End Sub
    Private Sub biSalir_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles biSalir.MouseMove
        sslError.Text = "Salir de la Ventana Actual"
    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        activar()
    End Sub
    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click

        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
            Dim registro As New ReclamoService.Reclamo
            Dim cliente As New ReclamoService.Cliente
            Dim locacion As New ReclamoService.Locacion
            Dim mercaderia As New ReclamoService.Mercaderia
            Dim documentoVenta As New ReclamoService.DocumentoVenta
            Dim documentoVentaDet As New ReclamoService.DocumentoVentaDet

            registro.IdReclamo = IdReclamo
            documentoVentaDet.IdVentaDet = IdVentaDet
            registro.DocumentoVentaDet = documentoVentaDet
            registro.TipDoc = TipoDoc
            documentoVenta.IdVenta = Codigo
            registro.DocumentoVentaDet.DocumentoVenta = documentoVenta
            locacion.IdLocacion = IdLocacion
            registro.Locacion = locacion
            'cliente.IdCliente = IdCliente
            registro.FecIng = cbFecInicio.Text
            registro.Aplica = toNull(txtAplicación.Text)
            registro.CanMer = toNull(txtCanMer.Text)
            registro.GuiCli = toNull(txtGuiaRemitente.Text)
            cliente.TelCli = toNull(txtTelefono.Text)
            registro.LibMan = toNull(LibMan)
            registro.ConVen = toNull(ConVen)
            registro.Control = toNull(txtNumControl.Text)
            registro.Certificado = toNull(txtCertificado.Text)
            registro.Cubierta = toNull(Cubierta)
            registro.Casco = toNull(Casco)
            registro.IntTer = toNull(IntTer)
            registro.ColHidro = toNull(ColHidro)
            registro.MedDen = toNull(MedDen)
            registro.NivElec = toNull(NivElec)
            registro.Voltios = toNull(txtVoltioI.Text)
            registro.PVoltios = toNull(txtVoltios.Text)
            registro.SimAran = toNull(txtSimulacion.Text)
            registro.VolP1 = toNull(txtVoltajeI.Text)
            registro.VolP2 = toNull(txtVoltajeII.Text)
            registro.ResCarDefP1 = toNull(txtDefectuosaI.Text)
            registro.ResCarDefP2 = toNull(txtDefectuosaII.Text)
            registro.ResCarOptP1 = toNull(txtOptimaI.Text)
            registro.ResCarOptP2 = toNull(txtOptimaII.Text)
            registro.Observacion = toNull(txtOtros.Text)
            registro.Resultado = toNull(Resultado)
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If

    End Sub
    Private Sub Cubierta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGolpeadaCub.CheckedChanged, rbOkCub.CheckedChanged
        If rbGolpeadaCub.Checked Then
            Cubierta = 1
        ElseIf rbOkCub.Checked Then
            Cubierta = 2
        End If

    End Sub
    Private Sub Casco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGolpeadoCas.CheckedChanged, rbOkCas.CheckedChanged
        If rbGolpeadoCas.Checked Then
            Cubierta = 1
        ElseIf rbOkCas.Checked Then
            Cubierta = 2
        End If
    End Sub
    Private Sub Terminales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCorroides.CheckedChanged, rbDeformados.CheckedChanged, rbFiltracion.CheckedChanged, rbReconstruidos.CheckedChanged, rbOk.CheckedChanged
        If rbCorroides.Checked Then
            IntTer = 1
        ElseIf rbDeformados.Checked Then
            IntTer = 2
        ElseIf rbFiltracion.Checked Then
            IntTer = 3
        ElseIf rbReconstruidos.Checked Then
            IntTer = 4
        ElseIf rbOk.Checked Then
            IntTer = 5
        End If
    End Sub
    Private Sub Color_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVerde.CheckedChanged, rbNegro.CheckedChanged, rbBrilloso.CheckedChanged
        If rbVerde.Checked Then
            ColHidro = 1
        ElseIf rbNegro.Checked Then
            ColHidro = 2
        ElseIf rbBrilloso.Checked Then
            ColHidro = 3
        End If
    End Sub
    Private Sub Nivel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDebajoNivel.CheckedChanged, rbEncimaNivel.CheckedChanged, rbNormal.CheckedChanged
        If rbDebajoNivel.Checked Then
            NivElec = 1
        ElseIf rbNormal.Checked Then
            NivElec = 2
        ElseIf rbEncimaNivel.Checked Then
            NivElec = 3
        End If
    End Sub
    Private Sub Densidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged, rb2.CheckedChanged, rb3.CheckedChanged, rb4.CheckedChanged, rb5.CheckedChanged
        If rb1.Checked Then
            MedDen = 1
        ElseIf rb2.Checked Then
            MedDen = 2
        ElseIf rb3.Checked Then
            MedDen = 3
        ElseIf rb4.Checked Then
            MedDen = 4
        ElseIf rb5.Checked Then
            MedDen = 5
        End If
    End Sub
    Private Sub rbOperativa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOperativa.CheckedChanged, rbGarantia.CheckedChanged, rbNoProcede.CheckedChanged
        If rbOperativa.Checked Then
            Resultado = 1
        ElseIf rbNoProcede.Checked Then
            Resultado = 2
        ElseIf rbGarantia.Checked Then
            Resultado = 3
        End If

    End Sub


    Private Sub btnBuscarDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDoc.Click
        Dim frm As New frmBuscarTipoDocumentoGFB
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtDocInterno.BackColor = System.Drawing.SystemColors.Control
            txtDocInterno.Text = frm.numero
            Codigo = frm.codigo
            TipoDoc = frm.tipo
            txtDocInterno.Select()
            listarMercaderia()
            txtDocInterno.Select()
        End If
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

    Private Sub cmbMercaderia_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMercaderia.ValueChanged
        Try
            IdVentaDet = toNull(cmbMercaderia.DropDownList.GetRow.Cells("IdDetalle").Text)
            txtModelo.Text = cmbMercaderia.DropDownList.GetRow.Cells("CodMer").Text

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub rcLibreMantenimiento_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rcLibreMantenimiento.CheckedChanged
        If rcLibreMantenimiento.Checked Then
            LibMan = True
        Else
            LibMan = False
        End If

        If rcConvencional.Checked Then
            ConVen = True
        Else
            ConVen = False
        End If
    End Sub

    Private Sub Label24_Click(sender As System.Object, e As System.EventArgs) Handles Label24.Click

    End Sub
End Class