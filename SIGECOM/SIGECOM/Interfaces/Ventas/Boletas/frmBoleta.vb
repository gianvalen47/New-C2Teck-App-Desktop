Imports System.Windows.Forms

Public Class frmBoleta

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Public edicion As Boolean                   'True: Edición      False: Vista
    Public editable As Boolean                  'True: Editable     False: No Editable
    Private oMaestroService As New MaestroService.MaestroClient
    Private oBoletaService As New BoletaService.BoletaServiceClient
    Private oBoletaDetalleService As New BoletaDetalleService.BoletaDetalleServiceClient
    Private oLocacionClienteService As New LocacionClienteService.LocacionClienteServiceClient
    Private oDireccionFiscalService As New DireccionFiscalService.DireccionFiscalServiceClient
    Private oReporteVentaService As New ReporteVentaService.ReporteVentaServiceClient
    Private oFacturaService As New FacturaService.FacturaServiceClient
    Private oClienteService As New ClienteService.ClienteServiceClient
    Private oSeguridadService As New SeguridadService.SeguridadClient
    Private dtDatos As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdBoleta As Integer
    Public IdLocacion As Integer
    Public IdSugerido As Integer
    Public TipFac As String
    Private IdCliente As Integer
    Private TipMov As String
    Private dtTipos As DataTable
    Private dtMotivos As DataTable
    Private dtMonedas As DataTable
    Private dtLocaciones As DataTable
    Private dtAfectacionIgv As DataTable
    Private FacturarGuia As Boolean
    Private IdSugeridoCab As Integer
    Private ConLocCli As Integer
    Private CodMon As String
    Private Permiso As Boolean
    Private MonNac As Boolean

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNumJob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumJob.KeyDown

        If e.KeyCode = Keys.F12 Then
            If btnBuscarJob.Enabled = True Then
                btnBuscarJob_Click(sender, e)
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub txtNumGuis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumGuis.KeyDown

        If e.KeyCode = Keys.F12 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtObservacionKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnModificarObservacion.Enabled = True Then
                btnModificarObservacion_Click(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cmbIdFiscal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbIdFiscal.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnAgregarDirFiscal.Enabled = True Then
                e.Handled = True
                btnAgregarDirFiscal_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub cmbIdLocCli_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbIdLocCli.KeyDown
        If e.KeyCode = Keys.F12 Then
            If btnAgregarLocacion.Enabled = True Then
                e.Handled = True
                btnAgregarLocacion_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    If biGrabar.Enabled = True Then
        '        biGrabar.Select()
        '        biGrabar_Click(sender, e)
        '    Else
        '        dgvDatos.Select()
        '    End If
        'End If
    End Sub

    Private Sub cmbTipoAfectacionIgv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoAfectacionIgv.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGrabar.Enabled = True Then
                biGrabar.Select()
                biGrabar_Click(sender, e)
            Else
                dgvDatos.Select()
            End If
        End If
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    If btnBuscarCliente.Enabled = True Then
        '        btnBuscarCliente.Select()
        '        e.Handled = True
        '    End If
        'End If
    End Sub

    Private Sub cmbCodMon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCodMon.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If btnBuscarCliente.Enabled = True Then
                btnBuscarCliente.Select()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvDatos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDatos.DoubleClick
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub

    Private Sub dgvDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDatos.KeyDown
        If e.KeyCode = Keys.Enter Then

            If dgvDatos.RowCount > 0 Then
                mostrarDetalle()
                e.Handled = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            txtNumDoc.Select()

        End If
    End Sub


    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                            cmbIdLocCli.KeyPress _
                          , cmbCodMot.KeyPress _
                          , txtNumJob.KeyPress _
                          , txtIgv.KeyPress _
                          , txtTipoCambio.KeyPress _
                          , txtCliente.KeyPress _
                          , txtFecDoc.KeyPress _
                          , txtNumDoc.KeyPress _
                          , cmbCodPag.KeyPress _
                          , cmbIdFiscal.KeyPress _
                          , txtNumGuis.KeyPress _
                          , cmbIdCotizacion.KeyPress _
                          , txtObservacion.KeyPress

        ', cmbCodMon.KeyPress _
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmBoleta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        ElseIf e.KeyCode = Keys.Insert Then
            If miNuevo.Enabled = True Then
                miNuevo_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.biSalir 
        Dim estilo As New Estilo
        estilo.cargaEstiloGridExt(dgvDatos)
        dgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Left

        llenarCombos()
        If state_button Then    'Modificar      
            desactivar()
            ObtenerRegistro()
            actualizardetalle()
            gbEstado.Visible = True
            btnBuscarCliente.Enabled = False
            btnAgregarCliente.Enabled = False
            cmbCodMon.ReadOnly = True
            cmbCodMon.BackColor = System.Drawing.SystemColors.Control
            txtNumDoc.ReadOnly = True
            enableOpciones()
            dgvDatos.Select()
        Else                    'Nuevo

            CodMon = oMaestroService.ObtenerMonedaNacional(IdLocacion)
            Permiso = oSeguridadService.BuscarPermisoTipCam(Session.sCodUsu)
            MonNac = oMaestroService.BuscarMonedaNacional(IdLocacion)

            txtNumDoc.ReadOnly = False
            txtNumDoc.BackColor = System.Drawing.SystemColors.Window
            txtFecDoc.ReadOnly = False
            txtFecDoc.BackColor = System.Drawing.SystemColors.Window
            btnBuscarCliente.Enabled = True
            btnAgregarCliente.Enabled = True
            cmbIdLocCli.ReadOnly = False
            cmbIdLocCli.BackColor = System.Drawing.SystemColors.Window
            cmbCodMot.Value = "1"
            cmbCodPag.Value = "00"
            cmbCodMon.Value = CodMon
            cmbTipoAfectacionIgv.Value = "10"
            txtFecDoc.Value = Session.sFecha
            If Permiso Then
                cmbCodMon.ReadOnly = False
                cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            Else
                If MonNac = True Then
                    cmbCodMon.ReadOnly = True
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Control
                Else
                    cmbCodMon.ReadOnly = False
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Window
                End If
            End If
            activar()
            Me.Size = New System.Drawing.Size(852, 237)
            txtNumDoc.Select()
        End If

    End Sub
    Private Sub activar()
        btnBuscarJob.Enabled = True
        btnGuias.Enabled = True
        btnAgregarLocacion.Enabled = True
        btnAgregarDirFiscal.Enabled = True
        If state_button Then
            cmbCodMot.ReadOnly = True
            cmbCodMot.BackColor = System.Drawing.SystemColors.Control
        Else
            cmbCodMot.ReadOnly = False
            cmbCodMot.BackColor = System.Drawing.SystemColors.Window
        End If
        'cmbCodMon.ReadOnly = True
        'cmbCodMot.BackColor = System.Drawing.SystemColors.Control
        'If dgvDatos.RowCount > 0 Then
        '    cmbCodMon.ReadOnly = True
        '    cmbCodMot.BackColor = System.Drawing.SystemColors.Control
        'Else
        '    cmbCodMon.ReadOnly = False
        '    cmbCodMot.BackColor = System.Drawing.SystemColors.Window
        'End If
        cmbIdCotizacion.ReadOnly = False
        cmbIdCotizacion.BackColor = System.Drawing.SystemColors.Window
        cmbCodPag.ReadOnly = False
        cmbCodPag.BackColor = System.Drawing.SystemColors.Window
        cmbIdFiscal.ReadOnly = False
        cmbIdFiscal.BackColor = System.Drawing.SystemColors.Window
        cmbIdLocCli.ReadOnly = False
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Window
        txtNumGuis.ReadOnly = False
        txtObservacion.ReadOnly = False
        txtObservacion.BackColor = System.Drawing.SystemColors.Window
        btnModificarObservacion.Enabled = True
        txtNumJob.ReadOnly = False
        txtNumJob.BackColor = System.Drawing.SystemColors.Window
        cmbTipoAfectacionIgv.ReadOnly = False
        cmbTipoAfectacionIgv.BackColor = System.Drawing.SystemColors.Window
        edicion = True
        enableOpciones()
        biSugerir.Enabled = False
        dgvDatos.Select()
    End Sub
    Private Sub desactivar()
        txtNumDoc.ReadOnly = True
        txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        txtFecDoc.ReadOnly = True
        txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        btnBuscarCliente.Enabled = False
        btnAgregarCliente.Enabled = False
        cmbIdLocCli.ReadOnly = True
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Control
        cmbCodMon.ReadOnly = True
        cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        cmbCodPag.ReadOnly = True
        cmbCodPag.BackColor = System.Drawing.SystemColors.Control
        cmbIdFiscal.ReadOnly = True
        cmbIdFiscal.BackColor = System.Drawing.SystemColors.Control
        cmbIdLocCli.ReadOnly = True
        cmbIdLocCli.BackColor = System.Drawing.SystemColors.Control
        ' *****************************************************
        btnBuscarJob.Enabled = False
        btnGuias.Enabled = False
        btnAgregarLocacion.Enabled = False
        btnAgregarDirFiscal.Enabled = False
        cmbCodMot.ReadOnly = True
        cmbCodMot.BackColor = System.Drawing.SystemColors.Control
        cmbIdCotizacion.ReadOnly = True
        cmbIdCotizacion.BackColor = System.Drawing.SystemColors.Control
        txtObservacion.ReadOnly = True
        txtObservacion.BackColor = System.Drawing.SystemColors.Control
        txtNumGuis.ReadOnly = True
        btnModificarObservacion.Enabled = False
        txtNumJob.ReadOnly = True
        txtNumJob.BackColor = System.Drawing.SystemColors.Control
        cmbTipoAfectacionIgv.ReadOnly = True
        cmbTipoAfectacionIgv.BackColor = System.Drawing.SystemColors.Control
        edicion = False
        enableOpciones()
        dgvDatos.Select()
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oBoletaService) = False Then
                oBoletaService.Close()
            End If
            If isClosed(oBoletaDetalleService) = False Then
                oBoletaDetalleService.Close()
            End If
            If isClosed(oLocacionClienteService) = False Then
                oLocacionClienteService.Close()
            End If
            If isClosed(oDireccionFiscalService) = False Then
                oDireccionFiscalService.Close()
            End If
            If isClosed(oReporteVentaService) = False Then
                oReporteVentaService.Close()
            End If
            If isClosed(oClienteService) = False Then
                oClienteService.Close()
            End If

            If isClosed(oSeguridadService) = False Then
                oSeguridadService.Close()
            End If
            If isClosed(oFacturaService) = False Then
                oFacturaService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                            txtObservacion.KeyUp _
                          , txtNumJob.KeyUp _
                          , txtIgv.KeyUp _
                          , txtTipoCambio.KeyUp _
                          , txtCliente.KeyUp _
                          , txtFecDoc.KeyUp _
                          , txtNumDoc.KeyUp _
                          , txtNumGuis.KeyUp
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.EditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.EditBox
            ElseIf sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.NumericEditBox" Then
                campo = New Janus.Windows.GridEX.EditControls.NumericEditBox
            ElseIf sender.GetType.ToString = "System.Windows.Forms.TextBox" Then
                campo = New TextBox
            End If
            campo = sender
            If campo.readonly = False Then
                If campo.Text.Trim.Length > 0 Then
                    campo.BackColor = Color.White
                Else
                    'campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                            cmbIdLocCli.ValueChanged _
                          , cmbCodMot.ValueChanged _
                          , cmbCodMon.ValueChanged _
                          , cmbCodPag.ValueChanged _
                          , cmbIdFiscal.ValueChanged
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.MultiColumnCombo" Then
                campo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
            End If
            campo = sender
            If toNumber(campo.value) <> 0 Or toNull(campo.Value) <> Nothing Then
                campo.BackColor = Color.White
            Else
                'campo.BackColor = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
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
            fila(1) = "(Ninguno)"
        Catch ex As Exception
        End Try
        Try
            fila(2) = "(Ninguno)"
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

                If CInt(row.Cells("IdBoletaDet").Value) = codigo Then

                    lista.Row = row.Position
                    lista.Col = 1

                    Exit For
                End If

            Next
        Catch ex As Exception
            MsgBox("ERROR [ROW_POSS]: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub enableOpciones()
        Try
            If state_button Then
                Dim aprobar As BoletaService.Boleta
                aprobar = oBoletaService.MostrarPorId(IdBoleta)
                'Dim IBuscarGuia As Boolean

                biEditar.Enabled = IIf(editable, Not edicion, False)
                biSalir.Enabled = Not edicion
                biTransportista.Enabled = IIf(editable, Not edicion, False)
                'biSugerir.Enabled = edicion
                biGrabar.Enabled = edicion
                biDeshacer.Enabled = edicion

                'Se comento segun Solicitud de Usuario 3451
                'IBuscarGuia = oBoletaService.BuscarGuia(IdBoleta)
                'If IBuscarGuia = True Then
                '    biSugerir.Enabled = False
                'Else
                biSugerir.Enabled = IIf((lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO") And txtTotalNeto.Text > 0 And aprobar.Motivos.Aprobar = True, True, False)
                'End If
                'biSugerir.Enabled = IIf((lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO") And txtTotalNeto.Text > 0 And aprobar.Motivos.Aprobar = True, True, False)
                biActMoneda.Enabled = IIf((Session.CodPerfil = "11" Or Session.CodPerfil = "12" Or Session.CodPerfil = "05") And lblEstado.Text = "GENERADO", True, False)   '------ Se agrega el Perfil de Costos 02/08/2016

                cmOpciones.Enabled = IIf(editable And lblEstado.Text <> "CREDITOS", Not edicion, False)
                miNuevo.Enabled = IIf(lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO", True, False)
                'miEditar.Enabled = IIf(dgvDatos.RowCount > 0, True, False)
                miEliminar.Enabled = IIf(dgvDatos.RowCount > 0 And (lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO"), True, False)
                'miSugerir.Enabled = IIf(dgvDatos.RowCount > 0, True, False)
                miMostrar.Enabled = IIf(dgvDatos.RowCount > 0, True, False)

                'Se comento segun Solicitud de Usuario 3451
                'If IBuscarGuia = True Then
                '    miSugerir.Enabled = False
                'Else
                miSugerir.Enabled = IIf((lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO") And txtTotalNeto.Text > 0 And aprobar.Motivos.Aprobar = True, True, False)
                'End If
                'miSugerir.Enabled = IIf((lblEstado.Text = "GENERADO" Or lblEstado.Text = "APROBADO") And txtTotalNeto.Text > 0 And aprobar.Motivos.Aprobar = True, True, False)
            Else
                biEditar.Enabled = False
                biDeshacer.Enabled = True
                biGrabar.Enabled = True
                biTransportista.Enabled = False
                biSalir.Enabled = False
                biSugerir.Enabled = False
                biActMoneda.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try


    End Sub

    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If state_button = True And toNumber(IdBoleta) = 0 Then
                MsgBox("Debe Ingresar el código de la boleta.", MsgBoxStyle.Information, "Información")
                txtNumDoc.Focus()
                Return False
            ElseIf toBlank(txtNumDoc.Text) = "" Then
                MsgBox("Debe ingresar el número del Documento..", MsgBoxStyle.Information, "Información")
                txtNumDoc.BackColor = Color.Red
                txtNumDoc.Focus()
                Return False
                'ElseIf toNumber(IdLocacion) = 0 Then
                '  MsgBox("Debe Ingresar la almacén del documento.", MsgBoxStyle.Information, "Información")
                '  txtalmacen.BackColor = Color.Red
                '  btnBuscarAlmacen.Focus()
                '  Return False
            ElseIf toBlank(txtFecDoc.Text) = "" Then
                MsgBox("Debe Ingresar el la fecha.", MsgBoxStyle.Information, "Información")
                txtFecDoc.BackColor = Color.Red
                txtFecDoc.Focus()
                Return False
                'ElseIf toNumber(cmbTipFac.Value) = 0 Then
                '  MsgBox("Debe el tipo de la boleta.", MsgBoxStyle.Information, "Información")
                '  cmbTipFac.BackColor = Color.Red
                '  cmbTipFac.Focus()
                '  Return False
            ElseIf toBlank(txtTipoCambio.Text) = 0 Then
                MsgBox("Tipo de cambio no puede ser CERO..", MsgBoxStyle.Information, "Información")
                txtTipoCambio.BackColor = Color.Red
                txtTipoCambio.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el cliente ", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                btnBuscarCliente.Focus()
                Return False
            ElseIf ConLocCli > 1 And toNumber(cmbIdLocCli.Value) = 0 Then
                MsgBox("Debe Ingresar una locación del Cliente.", MsgBoxStyle.Information, "Información")
                cmbIdLocCli.BackColor = Color.Red
                cmbIdLocCli.Focus()
                Return False
                'ElseIf toNumber(cmbIdFiscal.Value) = 0 Then
                '  MsgBox("Debe una dirección fiscal del cliente.", MsgBoxStyle.Information, "Información")
                '  cmbIdFiscal.BackColor = Color.Red
                '  cmbIdFiscal.Focus()
                '  Return False
                'ElseIf toNumber(cmbCodMot.Value) = 0 Then
                '    MsgBox("Debe ingresar el motivo de la boleta.", MsgBoxStyle.Information, "Información")
                '    cmbCodMot.BackColor = Color.Red
                '    cmbCodMot.Focus()
                '    Return False
            ElseIf toBlank(cmbTipoAfectacionIgv.Value) = "" Then
                MsgBox("Debe ingresar el tipo de afectacion al igv", MsgBoxStyle.Information, "Información")
                cmbTipoAfectacionIgv.BackColor = Color.Red
                cmbTipoAfectacionIgv.Focus()
            ElseIf toBlank(cmbCodMon.Value) = "" Then
                MsgBox("Debe ingresar el tipo de moneda.", MsgBoxStyle.Information, "Información")
                cmbCodMon.BackColor = Color.Red
                cmbCodMon.Focus()
                Return False
            ElseIf toBlank(cmbCodPag.Value) = "" Then
                MsgBox("Debe ingresar la Condición de pago.", MsgBoxStyle.Information, "Información")
                cmbCodPag.BackColor = Color.Red
                cmbCodPag.Focus()
                Return False
                'ElseIf state_button = False And oBoletaService.Buscar(TipFac, toNumber(txtNumDoc.Text)) Then
                '    MsgBox("El Número " + txtNumDoc.Text + " de la boleta ya existe...!", MsgBoxStyle.Information, "Información")
                '    Return False
            ElseIf state_button = True And oBoletaService.Estado(IdBoleta) <> "GENERADO" And oBoletaService.Estado(IdBoleta) <> "APROBADO" And oBoletaService.Estado(IdBoleta) <> "CREDITOS" Then
                MsgBox("Ya no se puede realizar modificaciones...!" + vbCr + "Debido que ya no se encuentra en el estado GENERADO...!!", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As BoletaService.Boleta)
        Try
            Dim estado_process As Integer
            estado_process = oBoletaService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdBoleta = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Size = New System.Drawing.Size(852, 535)
                state_button = True
                desactivar()
                listaDatos()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As BoletaService.Boleta)
        Try
            Dim estado_process As Boolean
            estado_process = oBoletaService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                'Me.DialogResult = System.Windows.Forms.DialogResult.OK
                desactivar()
                ObtenerRegistro()
                actualizardetalle()
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ObtenerRegistro()
        Try
            Dim registro As BoletaService.Boleta
            registro = oBoletaService.MostrarPorId(IdBoleta)

            IdBoleta = registro.IdBoleta
            IdLocacion = registro.Locacion.IdLocacion
            'txtalmacen.Text = registro.Locacion.Almacen.DesAlm + "-" + registro.Locacion.Oficina.DesOfi
            txtFecDoc.Text = registro.FecDoc
            txtNumDoc.Text = registro.NumDoc
            'cmbTipFac.Value = registro.TipFac
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            listarCombosPorCliente()

            cmbIdLocCli.Value = registro.LocacionCliente.IdLocCli
            cmbIdFiscal.Value = registro.DireccionFiscal.IdFiscal
            cmbCodMot.Value = registro.Motivos.CodMot
            cmbCodPag.Value = registro.CondicionPago.CodPag
            txtNumJob.Text = registro.NumJob
            txtNumGuis.Text = registro.NumGuis
            cmbCodMon.Value = registro.Moneda.CodMon
            txtIgv.Text = registro.Igv
            txtObservacion.Text = registro.Observacion
            txtVendedor.Text = registro.Persona.ApeNom
            cmbIdCotizacion.Value = CInt(IIf(registro.Cotizacion.IdCotizacion Is Nothing, 0, registro.Cotizacion.IdCotizacion))
            cmbTipoAfectacionIgv.Value = registro.TipoAfectacionIgv.CodTipoIgv
            lblEstado.Text = registro.Estado
            TipMov = registro.TipMov

        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= TIPOS DE BOLETAS ================================================
            dtTipos = New DataTable
            dtTipos.Columns.Add(New DataColumn("codigo", Type.GetType("System.String")))
            dtTipos.Columns.Add(New DataColumn("nombre", Type.GetType("System.String")))
            dtTipos.Rows.Add(New Object() {"1", "Crédito"})
            dtTipos.Rows.Add(New Object() {"2", "Contado"})

            'cmbTipFac.DataSource = dtTipos
            'cmbTipFac.DropDownList.DataMember = dtTipos.Columns("nombre").ToString
            'cmbTipFac.DropDownList.DisplayMember = dtTipos.Columns("nombre").ToString
            'cmbTipFac.DropDownList.ValueMember = dtTipos.Columns("codigo").ToString
            'cmbTipFac.DropDownList.Columns(0).DataMember = dtTipos.Columns("codigo").ToString
            'cmbTipFac.DropDownList.Columns(1).DataMember = dtTipos.Columns("nombre").ToString
            'cmbTipFac.SelectedIndex = 1
            dtTipos = Nothing
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbCodMon.DataSource = dtMonedas
            cmbCodMon.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbCodMon.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbCodMon.DropDownList.Columns(1).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
            '======================================= MOTIVOS ================================================
            dtMotivos = oReporteVentaService.MostrarMotivosVenta.Tables(0) 'oMaestroService.MostrarMotivos.Tables(0)
            cmbCodMot.DataSource = dtMotivos
            cmbCodMot.DropDownList.DataMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.DisplayMember = dtMotivos.Columns("DesMot").ToString
            cmbCodMot.DropDownList.ValueMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodMot").ToString
            cmbCodMot.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesMot").ToString
            dtMotivos = Nothing
            '======================================= CONDICIONES DE PAGO ================================================
            dtMotivos = oMaestroService.MostrarCondicionPago.Tables(0)
            cmbCodPag.DataSource = dtMotivos
            cmbCodPag.DropDownList.DataMember = dtMotivos.Columns("DesPag").ToString
            cmbCodPag.DropDownList.DisplayMember = dtMotivos.Columns("DesPag").ToString
            cmbCodPag.DropDownList.ValueMember = dtMotivos.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(0).DataMember = dtMotivos.Columns("CodPag").ToString
            cmbCodPag.DropDownList.Columns(1).DataMember = dtMotivos.Columns("DesPag").ToString
            dtMotivos = Nothing
            '======================================= TIPO AFECTACION IGV ================================================
            dtAfectacionIgv = oFacturaService.MostrarTipoAfectacionIgv().Tables(0)
            cmbTipoAfectacionIgv.DataSource = dtAfectacionIgv
            cmbTipoAfectacionIgv.DropDownList.DataMember = dtAfectacionIgv.Columns("DesTipo").ToString
            cmbTipoAfectacionIgv.DropDownList.DisplayMember = dtAfectacionIgv.Columns("DesTipo").ToString
            cmbTipoAfectacionIgv.DropDownList.ValueMember = dtAfectacionIgv.Columns("CodTipoIgv").ToString
            cmbTipoAfectacionIgv.DropDownList.Columns(0).DataMember = dtAfectacionIgv.Columns("CodTipoIgv").ToString
            cmbTipoAfectacionIgv.DropDownList.Columns(1).DataMember = dtAfectacionIgv.Columns("DesTipo").ToString
            dtAfectacionIgv = Nothing

        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listarCombosPorCliente()
        Try

            '======================================= COTIZACIONES DEL CLIENTE ================================================
            dtLocaciones = oBoletaService.MostrarCotizacion(IdCliente).Tables(0)
            dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
            cmbIdCotizacion.DataSource = dtLocaciones
            cmbIdCotizacion.DropDownList.DataMember = dtLocaciones.Columns("NumCot").ToString
            cmbIdCotizacion.DropDownList.DisplayMember = dtLocaciones.Columns("NumCot").ToString
            cmbIdCotizacion.DropDownList.ValueMember = dtLocaciones.Columns("IdCotizacion").ToString
            cmbIdCotizacion.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdCotizacion").ToString
            cmbIdCotizacion.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("NumCot").ToString
            dtLocaciones = Nothing
            cmbIdCotizacion.SelectedIndex = 0

            listarCombosLocacion()
            listarCombosDirFiscal()
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub listarCombosLocacion()
        '======================================= LOCACIONES DEL CLIENTE ================================================
        dtLocaciones = oLocacionClienteService.Mostrar(IdCliente).Tables(0)
        dtLocaciones.Rows.InsertAt(getRowTodos(dtLocaciones), 0)
        cmbIdLocCli.DataSource = dtLocaciones
        cmbIdLocCli.DropDownList.DataMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.DropDownList.DisplayMember = dtLocaciones.Columns("Nombre").ToString
        cmbIdLocCli.DropDownList.ValueMember = dtLocaciones.Columns("IdLocCli").ToString
        cmbIdLocCli.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdLocCli").ToString
        cmbIdLocCli.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Nombre").ToString
        ConLocCli = dtLocaciones.Rows.Count
        If ConLocCli = 2 Then
            cmbIdLocCli.SelectedIndex = 1
        Else
            cmbIdLocCli.SelectedIndex = 0
        End If
        dtLocaciones = Nothing
    End Sub
    Private Sub listarCombosDirFiscal()
        '======================================= DIRECCIONES FISCALES ================================================
        dtLocaciones = oDireccionFiscalService.Mostrar(IdCliente).Tables(0)
        cmbIdFiscal.DataSource = dtLocaciones
        cmbIdFiscal.DropDownList.DataMember = dtLocaciones.Columns("Direccion").ToString
        cmbIdFiscal.DropDownList.DisplayMember = dtLocaciones.Columns("Direccion").ToString
        cmbIdFiscal.DropDownList.ValueMember = dtLocaciones.Columns("IdFiscal").ToString
        cmbIdFiscal.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdFiscal").ToString
        cmbIdFiscal.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Direccion").ToString
        If dtLocaciones.Rows.Count > 0 Then
            cmbIdFiscal.SelectedIndex = 0
        Else
            cmbIdFiscal.Value = ""
        End If
    End Sub

    Private Sub listaDatos()
        Try
            dtDatos = oBoletaDetalleService.Mostrar(toNumber(IdBoleta)).Tables(0)
            dgvDatos.SetDataBinding(dtDatos, 0)

            If dgvDatos.RowCount > 0 Then
                IdSugeridoCab = IIf(dgvDatos.CurrentRow.Cells("IdSugeridoCab").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugeridoCab").Text)

                Dim registro2 As New BoletaService.SugeridoBoleta
                If IdSugeridoCab > 0 Then
                    registro2 = oBoletaService.MostrarSugeridoPorId(IdSugeridoCab)

                End If

                txtTotalPrecio.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Boleta", "TotBruto", "IdBoleta", IdBoleta)
                txtTotalDescuento.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Boleta", "TotDscto", "IdBoleta", IdBoleta)
                txtTotal.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Boleta", "TotVenta", "IdBoleta", IdBoleta)
                txtTotalIGV.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Boleta", "TotIgv", "IdBoleta", IdBoleta)
                txtTotalNeto.Text = oMaestroService.MostrarDato("SIGECOM.Ventas.Boleta", "TotNeto", "IdBoleta", IdBoleta)
                lblTotal.Text = "SUB TOTALES"
                lbltotalIGV.Text = "IGV"
                lblTotalNeto.Text = "TOTAL (" + oMaestroService.MostrarDato("SIGECOM.Maestro.Monedas", "AbrMon", "CodMon", oMaestroService.MostrarDato("SIGECOM.Ventas.Boleta", "CodMon", "IdBoleta", IdBoleta)) + ")"

                txtTotalSug.Text = IIf(IdSugeridoCab > 0, registro2.TotVentaSug, 0)
                txtTotalIgvSug.Text = IIf(IdSugeridoCab > 0, registro2.TotIgvSug, 0)
                txtTotalNetoSug.Text = IIf(IdSugeridoCab > 0, registro2.TotNetoSug, 0)

                If txtTotalNetoSug.Value > 0 Then
                    dgvDatos.RootTable.Columns(4).Width = 228
                    dgvDatos.RootTable.Columns(9).Visible = True
                    lblTotal.Size = New System.Drawing.Size(433, 20)
                    lbltotalIGV.Size = New System.Drawing.Size(602, 20)
                    lblTotalNeto.Size = New System.Drawing.Size(602, 20)
                    txtTotalPrecio.Location = New System.Drawing.Point(453, 11)
                    txtTotalDescuento.Location = New System.Drawing.Point(543, 11)
                    txtTotal.Location = New System.Drawing.Point(622, 11)
                    txtTotalIGV.Location = New System.Drawing.Point(622, 30)
                    txtTotalNeto.Location = New System.Drawing.Point(622, 49)
                    txtTotalSug.Visible = True
                    txtTotalIgvSug.Visible = True
                    txtTotalNetoSug.Visible = True
                Else
                    dgvDatos.RootTable.Columns(4).Width = 318
                    dgvDatos.RootTable.Columns(9).Visible = False
                    lblTotal.Size = New System.Drawing.Size(523, 20)
                    lbltotalIGV.Size = New System.Drawing.Size(692, 20)
                    lblTotalNeto.Size = New System.Drawing.Size(692, 20)
                    txtTotalPrecio.Location = New System.Drawing.Point(542, 11)
                    txtTotalDescuento.Location = New System.Drawing.Point(632, 11)
                    txtTotal.Location = New System.Drawing.Point(711, 11)
                    txtTotalIGV.Location = New System.Drawing.Point(711, 30)
                    txtTotalNeto.Location = New System.Drawing.Point(711, 49)
                    txtTotalSug.Visible = False
                    txtTotalIgvSug.Visible = False
                    txtTotalNetoSug.Visible = False
                End If
            End If
            enableOpciones()
        Catch ex As Exception
            MsgBox("ERROR [INFO-007]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub NuevoDetalle()
        Try
            Dim lLog As Boolean = True
            While lLog
                Dim frm As New frmBoleta_agregarDetalle
                frm.state_button = False
                frm.IdBoleta = IdBoleta
                frm.IdLocacion = IdLocacion
                frm.IdCliente = IdCliente
                frm.CodMon = cmbCodMon.Value
                frm.TipMov = TipMov
                frm.CodMot = cmbCodMot.Value

                If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    IdSugerido = frm.IdSugerido
                    dtDatos = Nothing
                    ObtenerRegistro()
                    listaDatos()
                    If frm.type_process = "insert" Then
                        RowPossesion(dgvDatos, frm.IdBoletaDet)
                    End If
                Else
                    lLog = False
                End If
            End While
        Catch ex As Exception
            MsgBox("ERROR [INFO-008]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub eliminarDetalle()
        Try
            cmOpciones.Visible = False
            If MsgBox("¿Está seguro de ELIMINAR el registro con CÓDIGO = " + dgvDatos.CurrentRow.Cells("CodMer").Text.ToString + " ?", MsgBoxStyle.YesNo, "Información") = MsgBoxResult.Yes Then

                If dgvDatos.CurrentRow.Cells("IdSugerido").Text = "" Then
                    Dim estado_process As Boolean
                    estado_process = oBoletaDetalleService.Borrar(toNumber(dgvDatos.CurrentRow.Cells("IdBoletaDet").Text), IdBoleta)
                    If estado_process = True Then
                        dtDatos = Nothing
                        listaDatos()
                        MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                    Else
                        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("Primero debe eliminar el Precio y/o Descuento sugerido")
                End If

            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-009]:" + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarDetalle()
        Try
            Dim frm As New frmBoleta_agregarDetalle
            frm.state_button = True
            frm.IdBoletaDet = dgvDatos.CurrentRow.Cells("IdBoletaDet").Text
            frm.IdBoleta = IdBoleta
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMon = cmbCodMon.Value
            frm.TipMov = TipMov
            frm.IdSugerido = IIf(dgvDatos.CurrentRow.Cells("IdSugerido").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugerido").Text)
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                If frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdBoletaDet)
                Else
                    MsgBox("Se eliminó el registro correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-010]: " + ex.Message, MsgBoxStyle.Exclamation)
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
            ElseIf dgvDatos.CurrentRow.Cells(0).Text = Nothing Then
                MsgBox("Registro Vacío", MsgBoxStyle.Information, "Información")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-011]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub actualizardetalle()
        Try
            Dim codigo As String = ""
            If dgvDatos.RowCount > 0 Then
                If IsDBNull(dgvDatos.CurrentRow.Cells(0).Text) = False Then
                    codigo = dgvDatos.CurrentRow.Cells("IdBoletaDet").Text
                End If
            End If
            dtDatos = Nothing
            listaDatos()
            If dgvDatos.RowCount > 0 And codigo.Trim.Length > 0 Then
                RowPossesion(dgvDatos, codigo)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-012]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub sugerirDetalle()
        Try
            If toNumber(IdSugeridoCab) > 0 Then
                Dim registro As New BoletaService.SugeridoBoleta
                registro = oBoletaService.MostrarSugeridoPorId(IdSugeridoCab)
                If registro.FactorSug + registro.DsctoSug > 0 Then
                    MsgBox("No puede hacer sugerencias por detalle, por que ya se hizo a nivel de Documento ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If
            Dim frm As New frmBoleta_SugerirDetalle
            frm.IdBoleta = IdBoleta
            frm.IdBoletaDet = toNumber(dgvDatos.CurrentRow.Cells("IdBoletaDet").Value)
            frm.IdSugerido = IIf(dgvDatos.CurrentRow.Cells("IdSugerido").Text = "", 0, dgvDatos.CurrentRow.Cells("IdSugerido").Text)
            frm.IdLocacion = IdLocacion
            frm.IdCliente = IdCliente
            frm.CodMer = dgvDatos.CurrentRow.Cells("CodMer").Text
            frm.CodMon = cmbCodMon.Value
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                If frm.type_process = "insert" Or frm.type_process = "update" Then
                    RowPossesion(dgvDatos, frm.IdBoletaDet)
                Else
                    MsgBox("Se eliminó la sugerencia correctamente.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub sugerirCabecera()
        Try
            If toNumber(IdSugeridoCab) > 0 Then
                Dim registro As New BoletaService.SugeridoBoleta
                registro = oBoletaService.MostrarSugeridoPorId(IdSugeridoCab)
                If registro.FactorSug + registro.DsctoSug = 0 And txtTotalSug.Text > 0 Then
                    MsgBox("No puede hacer sugerencias por Documento, por que ya se hizo a nivel de Detalle ... !!!", MsgBoxStyle.Critical)
                    Return
                End If
            End If
            Dim frm As New frmBoleta_SugerirCabecera
            frm.IdBoleta = IdBoleta
            frm.IdSugerido = IdSugerido
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdSugerido = frm.IdSugerido
                dtDatos = Nothing
                ObtenerRegistro()
                listaDatos()
                'If frm.type_process = "insert" Or frm.type_process = "update" Then
                '    RowPossesion(dgvDatos, dtDatos, "IdGuia", frm.IdGuia)
                'Else
                '    MsgBox("Se elimino la sugerencia correctamente.", MsgBoxStyle.Information)
                'End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub Guardar()
        Try
            If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes _
                      And ValidaCampos() Then

                Dim registro As New BoletaService.Boleta
                Dim locacion As New BoletaService.Locacion
                Dim clienete As New BoletaService.Cliente
                Dim locacionCliente As New BoletaService.LocacionCliente
                Dim direccion As New BoletaService.DireccionFiscal
                Dim moneda As New BoletaService.Moneda
                Dim motivo As New BoletaService.Motivos
                Dim condicionPago As New BoletaService.CondicionPago
                Dim cotizacion As New BoletaService.Cotizacion
                Dim tipoafectacionigv As New BoletaService.TipoAfectacionIgv

                registro.IdBoleta = IdBoleta
                locacion.IdLocacion = IdLocacion
                registro.Locacion = locacion
                registro.FecDoc = txtFecDoc.Text
                registro.NumDoc = txtNumDoc.Text
                registro.TipFac = TipFac
                clienete.IdCliente = IIf(toNumber(IdCliente) = 0, Nothing, IdCliente)
                registro.Cliente = clienete
                locacionCliente.IdLocCli = IIf(toNumber(cmbIdLocCli.Value) = 0, Nothing, cmbIdLocCli.Value)
                registro.LocacionCliente = locacionCliente
                direccion.IdFiscal = IIf(toNumber(cmbIdFiscal.Value) = 0, Nothing, cmbIdFiscal.Value)
                registro.DireccionFiscal = direccion
                motivo.CodMot = cmbCodMot.Value
                registro.Motivos = motivo
                condicionPago.CodPag = toNull(cmbCodPag.Value)
                registro.CondicionPago = condicionPago
                registro.NumJob = toNull(txtNumJob.Text)
                registro.NumGuis = toNull(txtNumGuis.Text)
                moneda.CodMon = cmbCodMon.Value
                registro.Moneda = moneda
                registro.Observacion = toNull(txtObservacion.Text)
                cotizacion.IdCotizacion = IIf(toNumber(cmbIdCotizacion.Value) = 0, Nothing, cmbIdCotizacion.Value)
                registro.Cotizacion = cotizacion
                registro.CodUsu = Session.sCodUsu
                registro.FacturarGuias = FacturarGuia
                tipoafectacionigv.CodTipoIgv = toNull(cmbTipoAfectacionIgv.Value)
                registro.TipoAfectacionIgv = tipoafectacionigv
                registro.NomPc = Session.sNomPc
                registro.DirIp = Session.sDirIp

                If state_button Then        'Modificar
                    Modificar(registro)
                Else                        'Nuevo
                    Insertar(registro)
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-014]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            txtCliente.Select()
            listarCombosPorCliente()
            If oClienteService.BuscarMonedaCliente(IdLocacion, IdCliente) = True Then
                cmbCodMon.ReadOnly = False
                cmbCodMon.BackColor = System.Drawing.SystemColors.Window
            Else
                If Permiso = False And MonNac = True Then
                    cmbCodMon.ReadOnly = True
                    cmbCodMon.BackColor = System.Drawing.SystemColors.Control
                    cmbCodMon.Value = CodMon
                End If

            End If
        End If
    End Sub

    Private Sub miMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.Click
        If ValidaCodigoSeleccionado() Then
            mostrarDetalle()
        End If
    End Sub
    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        If ValidaCodigoSeleccionado() Then
            eliminarDetalle()
        End If
    End Sub
    Private Sub miActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.Click
        actualizardetalle()
    End Sub
    Private Sub miNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.Click
        If state_button = True Or (toBlank(lblEstado.Text) = "GENERADO" Or toBlank(lblEstado.Text) = "GN" Or toBlank(lblEstado.Text) = "APROBADO" Or toBlank(lblEstado.Text) = "AP") Then
            NuevoDetalle()
        End If
    End Sub

    Private Sub cmbCodMon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodMon.ValueChanged
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text)), "#0.000")
    End Sub
    Private Sub btnBuscarJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJob.Click
        Dim frm As New frmBuscarJob
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtNumJob.BackColor = System.Drawing.SystemColors.Control
            txtNumJob.Text = frm.cod_job
            txtNumJob.Select()

        End If
    End Sub
    Private Sub btnModificarObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificarObservacion.Click
        Dim frm As New frmBoleta_ModificarObservacion
        frm.state_button = state_button
        frm.IdBoleta = IdBoleta
        frm.txtObservacion.Text = toBlank(txtObservacion.Text)
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtObservacion.Text = toBlank(frm.txtObservacion.Text)
        End If
        txtObservacion.Select()

    End Sub
    Private Sub txtFecDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecDoc.ValueChanged
        txtTipoCambio.Text = Format(toDouble(oMaestroService.MostrarTipoCambio(cmbCodMon.Value, txtFecDoc.Text)), "#0.000")
    End Sub

    Private Sub biGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.Click
        Guardar()
    End Sub

    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            dgvDatos.Focus()
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

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click
        ' If oBoletaService.PermisoBoleta(Session.sCodUsu, TipFac) Then
        activar()
        'Else
        'MsgBox("No tiene Permiso para modificar esta Boleta", MsgBoxStyle.Information, "No tiene Permiso")
        'End If

    End Sub

    Private Sub biTransportista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTransportista.Click
        Try
            Dim frm As New frmBoleta_Transportista
            frm.state_button = True
            frm.IdBoleta = IdBoleta
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                MsgBox("Se guardó los datos del Transportista")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Al cargar Transportista")
        End Try
    End Sub

    Private Sub Limpiar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                  biEditar.MouseLeave, biGrabar.MouseLeave, biDeshacer.MouseLeave, biSalir.MouseLeave, biSugerir.MouseLeave, biTransportista.MouseLeave, _
                                  miNuevo.MouseLeave, miMostrar.MouseLeave, miEliminar.MouseLeave, miActualizar.MouseLeave, miSugerir.MouseLeave
        sslError.Text = ""
    End Sub

    Private Sub biTransportista_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biTransportista.MouseEnter
        sslError.Text = "Ingresar el Transportista."
    End Sub
    Private Sub biGrabar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGrabar.MouseEnter
        sslError.Text = "Grabar los cambios hechos en la Boleta."
    End Sub
    Private Sub biDeshacer_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biDeshacer.MouseEnter
        sslError.Text = "Deshacer los cambios hechos en la Boleta."
    End Sub
    Private Sub biSalir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.MouseEnter
        sslError.Text = "Cerrar y Salir del Formulario Boleta."
    End Sub
    Private Sub biSugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.MouseEnter
        sslError.Text = "Sugerir Precio"
    End Sub
    Private Sub biEditar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.MouseEnter
        sslError.Text = "Editar la Cabecera de la Boleta ."
    End Sub
    Private Sub miSugerir_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSugerir.MouseEnter
        sslError.Text = "Sugerir Precio y/o Descuento para el Detalle actual."
    End Sub
    Private Sub miNuevo_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNuevo.MouseEnter
        sslError.Text = "Crear Nuevo Detalle de la Boleta."
    End Sub
    Private Sub miModificar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miMostrar.MouseEnter
        sslError.Text = "Modificar Detalle actual."
    End Sub
    Private Sub miEliminar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.MouseEnter
        sslError.Text = "Eliminar Detalle actual."
    End Sub
    Private Sub miActualizar_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miActualizar.MouseEnter
        sslError.Text = "Actualizar Datos del Formulario Boleta."
    End Sub
    Private Sub biSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSugerir.Click
        If ValidaCodigoSeleccionado() Then
            sugerirCabecera()
            ObtenerRegistro()
        End If
    End Sub

    Private Sub miSugerir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSugerir.Click
        If ValidaCodigoSeleccionado() Then
            sugerirDetalle()
            ObtenerRegistro()
        End If
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

    Private Sub btnGuias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuias.Click
        Try
            Dim frm As New frmFacturarGuias
            frm.IdCliente = IIf(txtCliente.Text = "", 0, IdCliente)
            frm.NumJob = txtNumJob.Text
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                FacturarGuia = frm.ckFacturarGuias.Checked
                txtNumGuis.Text = frm.guia
            End If
            txtNumGuis.Select()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Busqueda")
        End Try
    End Sub

    Private Sub btnAgregarLocacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarLocacion.Click
        If IdCliente > 0 Then
            Dim forma As New frmAgregarLocacionCliente
            forma.IdCliente = IdCliente
            If forma.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                listarCombosLocacion()
                ' cmbIdContacto.Text = forma.txtNombres.Text & " " & frmAgregarContacto.txtApellidos.Text
                'cmbIdLocCli.ReadOnly = True
            End If
            ' MsgBox(cmbIdContacto.Value)  
        End If
        cmbIdLocCli.Select()
    End Sub

    Private Sub btnAgregarDirFiscal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDirFiscal.Click
        If IdCliente > 0 Then
            Dim forma As New frmAgregarDireccionFiscal
            forma.IdCliente = IdCliente
            If forma.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                listarCombosDirFiscal()
                ' cmbIdContacto.Text = forma.txtNombres.Text & " " & frmAgregarContacto.txtApellidos.Text
                'cmbIdLocCli.ReadOnly = True
            End If
            ' MsgBox(cmbIdContacto.Value)  
        End If
        cmbIdFiscal.Select()
    End Sub

    Private Sub biActMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biActMoneda.Click
        Try
            Dim frm As New frmGuiaRemision_ActualizarMoneda

            frm.IdDoc = IdBoleta
            frm.CodMon = cmbCodMon.Value
            frm.state_button = 3
            frm.NumDoc = txtNumDoc.Text

            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                ObtenerRegistro()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error al Actualizar la moneda")
        End Try
    End Sub

    Private Sub cmbTipoAfectacionIgv_ValueChanged(sender As Object, e As EventArgs) Handles cmbTipoAfectacionIgv.ValueChanged

        If oFacturaService.ObtenerAplicaIgv(cmbTipoAfectacionIgv.Value) = False Then
            txtIgv.Value = 0.00
        Else
            txtIgv.Value = toDouble(oMaestroService.MostrarDato("SIGECOM.Maestro.Parametros", "igv", "IdLocacion", IdLocacion))
        End If

    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        Try
            Dim frm As New frmAgregarClienteSunat
            frm.IdCliente = 0
            frm.tipoBusqueda = 1
            If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                IdCliente = frm.IdCliente
                txtCliente.Text = frm.txtDesCli.Text
            End If
        Catch ex As Exception
            MsgBox("ERROR [LIST-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class
