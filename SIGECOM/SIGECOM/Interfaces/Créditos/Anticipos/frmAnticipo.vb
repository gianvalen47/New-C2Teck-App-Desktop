Public Class frmAnticipo
  Public state_button As Boolean              'True: Modificar    False: nuevo
  Public type_process As String               'update     insert      delete
  Private oMaestroService As New MaestroService.MaestroClient
  Private oAnticipoService As New AnticipoService.AnticipoServiceClient
  Private dtDatos As DataTable
  '====================================================================================================================
  '============================================ PARAMETROS LOCALES ====================================================
  '====================================================================================================================
  Public IdAnticipo As Integer
  Private IdCliente As Integer
  Private dtMonedas As DataTable
  Private dtPagos As DataTable
    Private dtBancos As DataTable
    Private estado As String
    Private dtOficinas As DataTable
    Private dtAlmacenes As DataTable

    Private Sub frmAnticipo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            If MsgBox("¿Está seguro de GUARDAR el Anticipo Creado ... ?", MsgBoxStyle.YesNo, "Salir") = MsgBoxResult.Yes Then
                If btnGuardar.Enabled = True Then
                    btnGuardar.Select()
                    btnGuardar_Click(sender, e)
                End If
            Else
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
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

  '====================================================================================================================
  '============================================ CONTROL'S METHOD ======================================================
  '====================================================================================================================
  Private Sub Initialize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.CancelButton = Me.btnCancelar
        llenarCombos()
     
        If state_button Then    'Modificar Registro
            ObtenerRegistro()
            Me.Text = "Modificar Anticipo N° " + txtNumAnt.Text.ToString
            txtNumAnt.ReadOnly = True
            txtFecha.Focus()
            enableOpciones()
        Else                    'Nuevo Registro
            Me.Text = "Agregar Nuevo Anticipo"
            txtNumAnt.Value = oAnticipoService.SugerirNumero(Session.sCodEmp)
            txtNumAnt.ReadOnly = False
            txtFecha.Value = Today.Date
            miEliminar.Visible = False
            btnEliminar.Visible = False
            cmbMoneda.Value = "US"
            cmbPago.SelectedIndex = 1
            txtTipCam.Value = toDouble(oMaestroService.MostrarTipoCambio(cmbMoneda.Value, txtFecha.Text))
            txtNumAnt.Focus()
        End If


    End Sub

    
  Private Sub SendFocus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
              txtNumAnt.KeyPress, txtFecha.KeyPress, txtTipCam.KeyPress, txtCliente.KeyPress, cmbMoneda.KeyPress, _
              cmbPago.KeyPress, cmbBanco.KeyPress, txtTotal.KeyPress
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
      If isClosed(oAnticipoService) = False Then
        oAnticipoService.Close()
      End If
    Catch ex As Exception
      MsgBox("ERROR [FINALLY]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
    End Sub

    Private Sub enableOpciones()
      
        If estado = "GN" Then
            txtFecha.ReadOnly = False
            txtFecha.BackColor = System.Drawing.SystemColors.Window
            cmbMoneda.ReadOnly = False
            cmbMoneda.BackColor = System.Drawing.SystemColors.Window
            cmbPago.ReadOnly = False
            cmbPago.BackColor = System.Drawing.SystemColors.Window
            mostrarBanco(cmbPago.Value)
            txtTotal.ReadOnly = False
            txtTotal.BackColor = System.Drawing.SystemColors.Window
            txtObsAnt.ReadOnly = False
            txtObsAnt.BackColor = System.Drawing.SystemColors.Window
            txtCliente.ReadOnly = False
            txtCliente.BackColor = System.Drawing.SystemColors.Window
            txtCliente.ButtonEnabled = True
            cmbBanco.ReadOnly = False
            cmbBanco.BackColor = System.Drawing.SystemColors.Window
            cmbOficinas.ReadOnly = False
            cmbOficinas.BackColor = System.Drawing.SystemColors.Window
            cmbIdLocacion.ReadOnly = False
            cmbIdLocacion.BackColor = System.Drawing.SystemColors.Window

            btnEliminar.Enabled = True
            btnGuardar.Enabled = True
        Else
            txtFecha.ReadOnly = True
            txtFecha.BackColor = System.Drawing.SystemColors.Control
            cmbMoneda.ReadOnly = True
            cmbMoneda.BackColor = System.Drawing.SystemColors.Control
            cmbPago.ReadOnly = True
            cmbPago.BackColor = System.Drawing.SystemColors.Control
            mostrarBanco(cmbPago.Value)
            txtTotal.ReadOnly = True
            txtTotal.BackColor = System.Drawing.SystemColors.Control
            txtObsAnt.ReadOnly = True
            txtObsAnt.BackColor = System.Drawing.SystemColors.Control
            txtCliente.ReadOnly = True
            txtCliente.BackColor = System.Drawing.SystemColors.Control
            txtCliente.ButtonEnabled = False
            cmbBanco.ReadOnly = True
            cmbBanco.BackColor = System.Drawing.SystemColors.Control
            cmbOficinas.ReadOnly = True
            cmbOficinas.BackColor = System.Drawing.SystemColors.Control
            cmbIdLocacion.ReadOnly = True
            cmbIdLocacion.BackColor = System.Drawing.SystemColors.Control

            btnEliminar.Enabled = False
            btnGuardar.Enabled = False
        End If
        
    End Sub
  Private Sub setColor_BlankCajaTexto(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
              txtNumAnt.KeyUp, txtFecha.KeyUp, txtTipCam.KeyUp, txtCliente.KeyUp, txtTotal.KeyUp
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
                          cmbMoneda.ValueChanged, cmbPago.ValueChanged, cmbBanco.ValueChanged
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
    'Private Sub OnlyNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumAnt.KeyPress
    '  If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And (e.KeyChar = ChrW(Keys.Enter)) = False Then
    '    e.KeyChar = Chr(0)
    '  End If
    'End Sub
  '====================================================================================================================
  '============================================ TASK'S METHOD =========================================================
  '====================================================================================================================
  Private Function ValidaCampos() As Boolean
    Try
            If toNumber(IdAnticipo = 0) Then
                MsgBox("Debe Ingresar el Código del Anticipo.", MsgBoxStyle.Information, "Información")
                txtNumAnt.Focus()
                Return False
            ElseIf toBlank(txtFecha.Text) = "" Then
                MsgBox("Debe Ingresar el la Fecha.", MsgBoxStyle.Information, "Información")
                txtFecha.BackColor = Color.Red
                txtFecha.Focus()
                Return False
            ElseIf toNumber(txtTipCam.Value) = 0 Then
                MsgBox("Debe Ingresar el tipo de cambio.", MsgBoxStyle.Information, "Información")
                txtTipCam.BackColor = Color.Red
                txtTipCam.Focus()
                Return False
            ElseIf toNumber(IdCliente) = 0 Then
                MsgBox("Debe Ingresar el Cliente.", MsgBoxStyle.Information, "Información")
                txtCliente.BackColor = Color.Red
                txtCliente.Focus()
                Return False
            ElseIf toBlank(cmbMoneda.Value) = "" Then
                MsgBox("Debe Ingresar La Moneda.", MsgBoxStyle.Information, "Información")
                cmbMoneda.BackColor = Color.Red
                cmbMoneda.Focus()
            ElseIf toBlank(cmbPago.Value) = "" Then
                MsgBox("Debe Ingresar La Forma de Pago.", MsgBoxStyle.Information, "Información")
                cmbPago.BackColor = Color.Red
                cmbPago.Focus()
            ElseIf (cmbPago.DropDownList.Columns(0).DataMember.ToString = "EFE" Or cmbPago.DropDownList.Columns(0).DataMember.ToString = "T.T") And _
                    toBlank(cmbBanco.Value) = "" Then
                MsgBox("Debe Ingresar El Banco.", MsgBoxStyle.Information, "Información")
                cmbBanco.BackColor = Color.Red
                cmbBanco.Focus()
            ElseIf txtTotal.Value = 0 Then
                MsgBox("Debe Ingresar El Monto del Anticipo.", MsgBoxStyle.Information, "Información")
                txtTotal.BackColor = Color.Red
                txtTotal.Focus()
            Else
                Return True
            End If
    Catch ex As Exception
      MsgBox("ERROR [INFO-001]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Function
  Private Sub Insertar(ByVal registro As AnticipoService.Anticipo)
    Try
      Dim estado_process As Integer
      estado_process = oAnticipoService.Insertar(registro)
      type_process = "insert"
      If estado_process > 0 Then
        IdAnticipo = estado_process
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Else
        MsgBox("Error en el proceso, comuníquese con el departamento de sistemas...!", MsgBoxStyle.Critical)
      End If
    Catch ex As Exception
      MsgBox("ERROR [INFO-002]: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub
  Private Sub Modificar(ByVal registro As AnticipoService.Anticipo)
    Try
      Dim estado_process As Boolean
      estado_process = oAnticipoService.Actualizar(registro)
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
            estado_process = oAnticipoService.Borrar(IdAnticipo, Session.sCodUsu, Session.sNomPc, Session.sDirIp)
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
            Dim registro As AnticipoService.Anticipo
            registro = oAnticipoService.MostrarPorId(IdAnticipo)

            IdAnticipo = registro.IdAnticipo
            txtNumAnt.Value = registro.NumAnt
            txtFecha.Text = registro.Fecha
            cmbOficinas.Value = registro.Locacion.Oficina.CodOfi
            cmbIdLocacion.Value = registro.Locacion.IdLocacion
            txtTipCam.Value = oMaestroService.MostrarTipoCambio(registro.Moneda.CodMon, registro.Fecha)
            IdCliente = registro.Cliente.IdCliente
            txtCliente.Text = registro.Cliente.DesCli
            cmbMoneda.Value = registro.Moneda.CodMon
            cmbMoneda.Text = registro.Moneda.AbrMon
            cmbPago.Value = registro.TipoPago.CodPago
            cmbPago.Text = registro.TipoPago.DesPag
            cmbBanco.Value = registro.Banco.CodBan
            cmbBanco.Text = registro.Banco.DesBan
            txtTotal.Value = registro.Total
            txtObsAnt.Text = registro.Descripcion
            estado = registro.Estado

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
            '======================================= TIPOS DE PAGO ================================================
            dtPagos = oAnticipoService.MostrarTipoPago.Tables(0)
            cmbPago.DataSource = dtPagos
            cmbPago.DropDownList.DataMember = dtPagos.Columns("DesPag").ToString
            cmbPago.DropDownList.DisplayMember = dtPagos.Columns("DesPag").ToString
            cmbPago.DropDownList.ValueMember = dtPagos.Columns("CodPago").ToString
            cmbPago.DropDownList.Columns(0).DataMember = dtPagos.Columns("CodPago").ToString
            cmbPago.DropDownList.Columns(1).DataMember = dtPagos.Columns("DesPag").ToString
            dtPagos = Nothing
            '======================================= BANCOS ================================================
            dtBancos = oMaestroService.MostrarBancos.Tables(0)
            cmbBanco.DataSource = dtBancos
            cmbBanco.DropDownList.DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.DisplayMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.ValueMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(0).DataMember = dtBancos.Columns("CodBan").ToString
            cmbBanco.DropDownList.Columns(1).DataMember = dtBancos.Columns("DesBan").ToString
            cmbBanco.DropDownList.Columns(2).DataMember = dtBancos.Columns("AbrBan").ToString
            dtBancos = Nothing
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
        Catch ex As Exception
            MsgBox("ERROR [INFO-006]: " + ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub mostrarBanco(ByVal xPago As String)
        If (xPago = "CHE" Or xPago = "T.T") Then
            Label7.Visible = True
            cmbBanco.Enabled = True
            cmbBanco.Visible = True
            'cmbBanco.SelectedIndex = 0
        Else
            Label7.Visible = False
            cmbBanco.Enabled = False
            cmbBanco.Visible = False
            cmbBanco.Value = Nothing
        End If
    End Sub
    Private Sub GuardarDatos()
        If MsgBox("¿Está seguro de GUARDAR los datos?", MsgBoxStyle.YesNo, "Advertencia") = MsgBoxResult.Yes And ValidaCampos() Then
            Dim registro As New AnticipoService.Anticipo
            Dim cliente As New AnticipoService.Cliente
            Dim moneda As New AnticipoService.Moneda
            Dim banco As New AnticipoService.Banco
            Dim pago As New AnticipoService.TipoPago
            Dim empresa As New AnticipoService.Empresa
            Dim locacion As New AnticipoService.Locacion

            registro.IdAnticipo = IdAnticipo
            registro.NumAnt = txtNumAnt.Value
            registro.Fecha = txtFecha.Text
            cliente.IdCliente = IIf(toNumber(IdCliente) = 0, Nothing, IdCliente)
            registro.Cliente = cliente
            moneda.CodMon = cmbMoneda.Value
            registro.Moneda = moneda
            pago.CodPago = cmbPago.Value
            registro.TipoPago = pago
            banco.CodBan = cmbBanco.Value
            registro.Banco = banco
            registro.Total = txtTotal.Value
            registro.Descripcion = txtObsAnt.Text

            empresa.CodEmp = Session.sCodEmp
            locacion.Empresa = empresa
            locacion.IdLocacion = cmbIdLocacion.Value
            registro.Locacion = locacion
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
            If toNumber(IdAnticipo) = 0 Then
                Eliminar()
            Else
                MsgBox("Debe Ingresar el Código...!!!", MsgBoxStyle.Information, "Información")
                txtNumAnt.Focus()
            End If
        End If
  End Sub
  Private Sub CancelarDatos()
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
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
        End If
        txtCliente.Select()

  End Sub
  Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
    GuardarDatos()
  End Sub
  Private Sub miGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miGuardar.Click
    GuardarDatos()
  End Sub
  Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
    EliminarDatos()
  End Sub
  Private Sub miEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miEliminar.Click
    EliminarDatos()
  End Sub
  Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
    CancelarDatos()
  End Sub
  Private Sub miCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCancelar.Click
    CancelarDatos()
  End Sub
  Private Sub cmbPago_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPago.ValueChanged
    mostrarBanco(cmbPago.Value)
  End Sub
  Private Sub txtFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.ValueChanged
    txtTipCam.Text = toDouble(oMaestroService.MostrarTipoCambio(cmbMoneda.Value, txtFecha.Value))
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