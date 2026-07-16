Public Class frmLetra

    Public state_button As Boolean              'True: Modificar    False: nuevo
    Public type_process As String               'update     insert      delete
    Private oMaestroService As New MaestroService.MaestroClient
    Private oLetraService As New LetraService.LetraServiceClient
    Private oDocumentoCtaCtes As New DocumentoCtaCtesService.DocumentoCtaCtesServiceClient
    Private oDireccionFiscalService As New DireccionFiscalService.DireccionFiscalServiceClient
    Private dtDatos As DataTable
    Private dtCondicion As DataTable
    '====================================================================================================================
    '============================================ PARAMETROS LOCALES ====================================================
    '====================================================================================================================
    Public IdLetra As Integer
    Private IdCliente As Integer
    Private dtMonedas As DataTable
    Private dtLocaciones As DataTable
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable

    Private Sub frmLetra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            biSalir_Click(sender, e)
            e.Handled = True
        End If
    End Sub
    '====================================================================================================================
    '============================================ CONTROL'S METHOD ======================================================
    '====================================================================================================================
    Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.CancelButton = Me.biSalir
        llenarCombos()
        txtFecha.Enabled = True
        cmbMoneda.Enabled = True

        If state_button Then    'Modificar Registro
            ObtenerRegistro()
            Me.Text = "Modificar Letra N° " + txtNumLet.Text.ToString
            txtNumLet.ReadOnly = True
            gbEstado.Visible = True
            txtCodPago.Visible = False
            cmbCodPag.Visible = False
            lblCodPago.Visible = False
            desactivar()
            enableOpciones()
            txtReferencia.Focus()
        Else                    'Nuevo Registro
            Me.Text = "Agregar Nuevo Letra"
            txtNumLet.Value = oLetraService.SugerirNumero(Session.sCodEmp)
            txtNumLet.ReadOnly = False
            txtFecha.Value = Today.Date
            txtVencimiento.Value = Today.Date
            miEliminar.Visible = False
            'btnEliminar.Visible = False
            cmbMoneda.Value = "US"
            txtTipCam.Value = toDouble(oMaestroService.MostrarTipoCambio("US", txtFecha.Text))
            gbEstado.Visible = False
            txtCodPago.Visible = True
            cmbCodPag.Visible = True
            lblCodPago.Visible = True
            biEditar.Enabled = False
            biSalir.Enabled = False
            txtNumLet.Focus()
        End If

    End Sub

    Private Sub txtTelAval_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelAval.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If biGuardar.Enabled = True Then
                biGuardar.Select()
                biGuardar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.F12 Then
            If txtCliente.ButtonEnabled = True Then
                txtCliente_ButtonClick(sender, e)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
                txtNumLet.KeyPress, txtReferencia.KeyPress, txtGiro.KeyPress, txtFecha.KeyPress, txtVencimiento.KeyPress, _
                cmbMoneda.KeyPress, txtImporte.KeyPress, txtCliente.KeyPress, cmbIdFiscal.KeyPress, _
                txtDesAval1.KeyPress, txtDesAval2.KeyPress, txtDesAval3.KeyPress, txtDirAval1.KeyPress, txtDirAval2.KeyPress, _
                txtRucAval.KeyPress, txtDniAval.KeyPress, txtCodPago.KeyPress, cmbCodPag.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub FinallyObjects_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            If isClosed(oMaestroService) = False Then
                oMaestroService.Close()
            End If
            If isClosed(oLetraService) = False Then
                oLetraService.Close()
            End If
            If isClosed(oDocumentoCtaCtes) = False Then
                oDocumentoCtaCtes.Close()
            End If
            If isClosed(oDireccionFiscalService) = False Then
                oDireccionFiscalService.Close()
            End If
        Catch ex As Exception
            MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                txtNumLet.KeyUp, txtFecha.KeyUp, txtVencimiento.KeyUp, txtImporte.KeyUp, txtCliente.KeyUp
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
                    campo.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub setColor_BlankCombo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                            cmbMoneda.ValueChanged, cmbIdFiscal.ValueChanged
        Try
            Dim campo As New Object
            If sender.GetType.ToString = "Janus.Windows.GridEX.EditControls.MultiColumnCombo" Then
                campo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
            End If
            campo = sender
            If toNumber(campo.value) <> 0 Or toNull(campo.Value) <> Nothing Then
                campo.BackColor = Color.White
            Else
                campo.BackColor = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumLet.KeyPress
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub enableOpciones()
        biEditar.Enabled = IIf(lblEstado.Text = "GENERADO", True, False)
        biGuardar.Enabled = False
        biDeshacer.Enabled = False
    End Sub
    '====================================================================================================================
    '============================================ TASK'S METHOD =========================================================
    '====================================================================================================================
    Private Function ValidaCampos() As Boolean
        Try
            If IdLetra = 0 And state_button Then
                MsgBox("Debe Ingresar el Código de la Letra.", MsgBoxStyle.Information, "Información")
                txtNumLet.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar el la Fecha de Emisión.", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toNumber(txtTipCam.Value) = 0 Then
                MsgBox("Debe Ingresar el Tipo de Cambio.", MsgBoxStyle.Information, "Información")
                txtTipCam.BackColor = Color.Red
                txtTipCam.Focus()
                Return False
            ElseIf toBlank(txtVencimiento.Text) = "" Then
                MsgBox("Debe Ingresar el la Fecha de Vencimiento.", MsgBoxStyle.Information, "Información")
                txtVencimiento.BackColor = Color.Red
                txtVencimiento.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar La Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.BackColor = Color.Red
                cmbMoneda.Focus()
            ElseIf txtImporte.Value = 0 Then
                MsgBox("Debe Ingresar El Importe de la Letra.", MsgBoxStyle.Information, "Información")
                txtImporte.BackColor = Color.Red
                txtImporte.Focus()
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el Cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf toNumber(cmbIdFiscal.Value) = 0 Then
                MsgBox("Debe una dirección Fiscal del Cliente.", MsgBoxStyle.Information, "Información")
                cmbIdFiscal.BackColor = Color.Red
                cmbIdFiscal.Focus()
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Function
    Private Sub Insertar(ByVal registro As LetraService.Letra)
        Try
            Dim estado_process As Integer
            estado_process = oLetraService.Insertar(registro)
            type_process = "insert"
            If estado_process > 0 Then
                IdLetra = estado_process
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Modificar(ByVal registro As LetraService.Letra)
        Try
            Dim estado_process As Boolean
            estado_process = oLetraService.Actualizar(registro)
            type_process = "update"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-003]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub Eliminar()
        Try
            Dim estado_process As Boolean
            estado_process = oLetraService.Borrar(IdLetra, Session.sCodUsu)
            type_process = "delete"
            If estado_process = True Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("ERROR [INFO-004]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub ObtenerRegistro()
        Try
            Dim registro As LetraService.Letra
            registro = oLetraService.MostrarPorId(IdLetra)

            IdLetra = registro.IdLetra
            txtNumLet.Value = registro.NumLet
            txtReferencia.Text = registro.RefLet
            txtGiro.Text = registro.GirLet
            cmbOficinas.Value = registro.Locacion.Oficina.CodOfi
            cmbIdLocacion.Value = registro.Locacion.IdLocacion
            txtFecha.Text = registro.FecLet
            txtVencimiento.Value = registro.VenLet
            cmbMoneda.Value = registro.Moneda.CodMon
            cmbMoneda.Text = registro.Moneda.AbrMon
            txtImporte.Value = registro.Importe
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            listarCombosPorCliente()
            cmbIdFiscal.Value = registro.DireccionFiscal.IdFiscal
            cmbIdFiscal.Text = registro.DireccionFiscal.Direccion
            txtDesAval1.Text = registro.DesAval1
            txtDesAval2.Text = registro.DesAval2
            txtDesAval3.Text = registro.DesAval3
            txtDirAval1.Text = registro.DirAval1
            txtDirAval2.Text = registro.DirAval2
            txtRucAval.Text = registro.RucAval
            txtDniAval.Text = registro.DniAval
            txtTelAval.Text = registro.TelAval
            txtTipCam.Value = oMaestroService.MostrarTipoCambio(registro.Moneda.CodMon, registro.FecLet)
            lblEstado.Text = registro.Estado
        Catch ex As Exception
            MsgBox("ERROR [INFO-005]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub llenarCombos()
        Try
            '======================================= MONEDAS ================================================
            dtMonedas = oMaestroService.MostrarMonedas.Tables(0)
            cmbMoneda.DataSource = dtMonedas
            cmbMoneda.DropDownList.DataMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.DisplayMember = dtMonedas.Columns("AbrMon").ToString
            cmbMoneda.DropDownList.ValueMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(0).DataMember = dtMonedas.Columns("CodMon").ToString
            cmbMoneda.DropDownList.Columns(1).DataMember = dtMonedas.Columns("DesMon").ToString
            cmbMoneda.DropDownList.Columns(2).DataMember = dtMonedas.Columns("AbrMon").ToString
            dtMonedas = Nothing
            '====================================CONDICION DE PAGO ==========================================
            dtCondicion = oMaestroService.MostrarCondicionPago.Tables(0)
            cmbCodPag.DataSource = dtCondicion
            cmbCodPag.DisplayMember = "DesPag"
            cmbCodPag.ValueMember = "CodPag"
            cmbCodPag.DropDownList.Columns(0).DataMember = "CodPag"
            cmbCodPag.DropDownList.Columns(1).DataMember = "DesPag"
            ' cmbCodPag.SelectedIndex = 0
            dtCondicion = Nothing
            '======================================= OFICINAS ================================================
            dtOficinas = oMaestroService.MostrarOficinas(Session.sCodUsu).Tables(0)
            cmbOficinas.DataSource = dtOficinas
            cmbOficinas.DropDownList.DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.DisplayMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.DropDownList.ValueMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(0).DataMember = dtOficinas.Columns("CodOfi").ToString
            cmbOficinas.DropDownList.Columns(1).DataMember = dtOficinas.Columns("DesOfi").ToString
            cmbOficinas.SelectedIndex = 0
            dtOficinas = Nothing
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub listarCombosPorCliente()
        '======================================= DIRECCIONES FISCALES ================================================
        dtLocaciones = oDireccionFiscalService.Mostrar(IdCliente).Tables(0)
        cmbIdFiscal.DataSource = dtLocaciones
        cmbIdFiscal.DropDownList.DataMember = dtLocaciones.Columns("Direccion").ToString
        cmbIdFiscal.DropDownList.DisplayMember = dtLocaciones.Columns("Direccion").ToString
        cmbIdFiscal.DropDownList.ValueMember = dtLocaciones.Columns("IdFiscal").ToString
        cmbIdFiscal.DropDownList.Columns(0).DataMember = dtLocaciones.Columns("IdFiscal").ToString
        cmbIdFiscal.DropDownList.Columns(1).DataMember = dtLocaciones.Columns("Direccion").ToString
        dtLocaciones = Nothing
    End Sub
    Private Sub GuardarDatos()
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
            Dim registro As New LetraService.Letra
            Dim cliente As New LetraService.Cliente
            Dim direccion As New LetraService.DireccionFiscal
            Dim moneda As New LetraService.Moneda
            Dim empresa As New LetraService.Empresa
            Dim locacion As New LetraService.Locacion

            registro.IdLetra = IdLetra
            locacion.IdLocacion = cmbIdLocacion.Value
            empresa.CodEmp = Session.sCodEmp
            locacion.Empresa = empresa

            registro.Locacion = locacion
            registro.NumLet = txtNumLet.Value
            registro.RefLet = txtReferencia.Text
            registro.GirLet = txtGiro.Text
            registro.FecLet = txtFecha.Text
            registro.VenLet = txtVencimiento.Text
            moneda.CodMon = cmbMoneda.Value
            registro.Moneda = moneda
            registro.Importe = txtImporte.Value
            cliente.IdCliente = IIf(toNumber(IdCliente) = 0, Nothing, IdCliente)
            registro.Cliente = cliente
            direccion.IdFiscal = IIf(toNumber(cmbIdFiscal.Value) = 0, Nothing, cmbIdFiscal.Value)
            registro.DireccionFiscal = direccion
            registro.DesAval1 = txtDesAval1.Text
            registro.DesAval2 = txtDesAval2.Text
            registro.DesAval3 = txtDesAval3.Text
            registro.DirAval1 = txtDirAval1.Text
            registro.DirAval2 = txtDirAval2.Text
            registro.RucAval = txtRucAval.Text
            registro.DniAval = txtDniAval.Text
            registro.TelAval = txtTelAval.Text

          
            registro.NomPc = Session.sNomPc
            registro.DirIp = Session.sDirIp
            registro.CodUsu = Session.sCodUsu

            If state_button Then        'Modificar
                Modificar(registro)
            Else                        'Nuevo
                Insertar(registro)
            End If
        End If
    End Sub
    Private Sub EliminarDatos()
        If MsgBox("¿Está seguro de ELIMINAR el registro?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes Then
            If toNumber(IdLetra) = 0 Then
                Eliminar()
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
                txtNumLet.Focus()
            End If
        End If
    End Sub
    Private Sub CancelarDatos()
        If MsgBox("¿Desea Cerrar y Salir del Formulario ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End If
    End Sub
    Private Sub activar()
        txtCliente.ReadOnly = False
        txtDesAval1.ReadOnly = False
        txtDesAval2.ReadOnly = False
        txtDesAval3.ReadOnly = False
        txtDirAval1.ReadOnly = False
        txtDirAval2.ReadOnly = False
        txtDniAval.ReadOnly = False
        txtFecha.ReadOnly = False
        txtCodPago.ReadOnly = False
        cmbCodPag.ReadOnly = False
        txtCodPago.Clear()
        cmbCodPag.Clear()
        txtGiro.ReadOnly = False
        txtImporte.ReadOnly = False
        txtReferencia.ReadOnly = False
        txtRucAval.ReadOnly = False
        txtTelAval.ReadOnly = False
        txtTipCam.ReadOnly = False
        txtVencimiento.ReadOnly = False
        cmbIdFiscal.ReadOnly = False
        cmbMoneda.ReadOnly = False
        cmbOficinas.ReadOnly = False
        cmbIdLocacion.ReadOnly = False
        txtCliente.ButtonEnabled = True
        biEditar.Enabled = False
        biDeshacer.Enabled = True
        biGuardar.Enabled = True

        txtCodPago.Visible = True
        cmbCodPag.Visible = True
        lblCodPago.Visible = True

    End Sub
    Private Sub desactivar()
        txtCliente.ReadOnly = True
        txtDesAval1.ReadOnly = True
        txtDesAval2.ReadOnly = True
        txtDesAval3.ReadOnly = True
        txtDirAval1.ReadOnly = True
        txtDirAval2.ReadOnly = True
        txtDniAval.ReadOnly = True
        txtFecha.ReadOnly = True
        txtCodPago.ReadOnly = True
        cmbCodPag.ReadOnly = True
        txtGiro.ReadOnly = True
        txtImporte.ReadOnly = True
        txtReferencia.ReadOnly = True
        txtRucAval.ReadOnly = True
        txtTelAval.ReadOnly = True
        txtTipCam.ReadOnly = True
        txtVencimiento.ReadOnly = True
        cmbIdFiscal.ReadOnly = True
        cmbMoneda.ReadOnly = True
        cmbOficinas.ReadOnly = True
        cmbIdLocacion.ReadOnly = True
        txtCliente.ButtonEnabled = False

        txtCodPago.Visible = False
        cmbCodPag.Visible = False
        lblCodPago.Visible = False
        enableOpciones()
        'biEditar.Enabled = False
        'biDeshacer.Enabled = True
        'biGuardar.Enabled = True
    End Sub
    '====================================================================================================================
    '============================================ INTERFACE'S METHOD ====================================================
    '====================================================================================================================
    Private Sub txtCliente_ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.ButtonClick
        Dim frm As New frmBuscarCliente
        If frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            txtCliente.Text = frm.descripcion
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            IdCliente = frm.codigo
            listarCombosPorCliente()
        End If
    End Sub

    Private Sub miGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGuardar.Click
        GuardarDatos()
    End Sub

    Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
        EliminarDatos()
    End Sub

    Private Sub miCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCancelar.Click
        CancelarDatos()
    End Sub
    Private Sub txtFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
        txtTipCam.Text = oMaestroService.MostrarTipoCambio("US", txtFecha.Value)
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged

    End Sub
    Private Sub biGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biGuardar.Click

        GuardarDatos()

    End Sub
    Private Sub biSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biSalir.Click

        CancelarDatos()

    End Sub

    Private Sub biEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles biEditar.Click

        activar()
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

    Private Sub cmbCodPag_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCodPag.ValueChanged
        Try
            txtCodPago.Text = cmbCodPag.Value
            If txtFecha.Text <> "" Then
                txtVencimiento.Text = oDocumentoCtaCtes.CalcularFecVen(cmbCodPag.Value, txtFecha.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub txtCodPago_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodPago.Validating
        Try
            If Len(Trim(txtCodPago.Text)) > 0 Then
                Dim CodPago As String
                CodPago = oMaestroService.MostrarDato("Maestro.CondicionPago", "CodPag", "CodPag", Trim(txtCodPago.Text))
                If CodPago <> "" Then
                    cmbCodPag.Value = CodPago
                    If txtFecha.Text <> "" Then
                        txtVencimiento.Text = oDocumentoCtaCtes.CalcularFecVen(cmbCodPag.Value, txtFecha.Text)
                    End If
                Else
                    MsgBox("Código no Existe, Verifique...", MsgBoxStyle.Critical, "No Existe")
                    txtCodPago.Clear()
                    cmbCodPag.Clear()
                    txtCodPago.Select()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbOficinas_ValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbOficinas.ValueChanged
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
End Class