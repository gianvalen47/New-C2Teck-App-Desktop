<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillaPago
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim cbTipoPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbBanco_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillaPago))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbTipoPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalGastosSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalGastosDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalaPagarSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalaPagarDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalPagoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPagoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalDocSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDocDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDifCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtMontoBanco = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNroOperacion = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTipoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo Pago :"
        '
        'cbTipoPago
        '
        Me.cbTipoPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbTipoPago_DesignTimeLayout.LayoutString = resources.GetString("cbTipoPago_DesignTimeLayout.LayoutString")
        Me.cbTipoPago.DesignTimeLayout = cbTipoPago_DesignTimeLayout
        Me.cbTipoPago.Enabled = False
        Me.cbTipoPago.Location = New System.Drawing.Point(77, 23)
        Me.cbTipoPago.Name = "cbTipoPago"
        Me.cbTipoPago.SelectedIndex = -1
        Me.cbTipoPago.SelectedItem = Nothing
        Me.cbTipoPago.Size = New System.Drawing.Size(216, 20)
        Me.cbTipoPago.TabIndex = 1
        Me.cbTipoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbBanco
        '
        Me.cbBanco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbBanco_DesignTimeLayout.LayoutString = resources.GetString("cbBanco_DesignTimeLayout.LayoutString")
        Me.cbBanco.DesignTimeLayout = cbBanco_DesignTimeLayout
        Me.cbBanco.Enabled = False
        Me.cbBanco.Location = New System.Drawing.Point(77, 59)
        Me.cbBanco.Name = "cbBanco"
        Me.cbBanco.SelectedIndex = -1
        Me.cbBanco.SelectedItem = Nothing
        Me.cbBanco.Size = New System.Drawing.Size(216, 20)
        Me.cbBanco.TabIndex = 2
        Me.cbBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Banco :"
        '
        'cbMoneda
        '
        Me.cbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cbMoneda_DesignTimeLayout.LayoutString")
        Me.cbMoneda.DesignTimeLayout = cbMoneda_DesignTimeLayout
        Me.cbMoneda.Enabled = False
        Me.cbMoneda.Location = New System.Drawing.Point(77, 105)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.SelectedIndex = -1
        Me.cbMoneda.SelectedItem = Nothing
        Me.cbMoneda.Size = New System.Drawing.Size(111, 20)
        Me.cbMoneda.TabIndex = 6
        Me.cbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Moneda :"
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(334, 15)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(50, 13)
        Me.lblNumero.TabIndex = 6
        Me.lblNumero.Text = "Numero :"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumDoc.Location = New System.Drawing.Point(390, 12)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(104, 20)
        Me.txtNumDoc.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(217, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tipo Cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.DecimalDigits = 3
        Me.txtTipoCambio.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(290, 105)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(57, 20)
        Me.txtTipoCambio.TabIndex = 7
        Me.txtTipoCambio.Text = "0.000"
        Me.txtTipoCambio.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalGastosSol)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalGastosDol)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalaPagarSol)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalaPagarDol)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPagoSol)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPagoDol)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDocSol)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDocDol)
        Me.UiGroupBox1.Location = New System.Drawing.Point(11, 133)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(484, 75)
        Me.UiGroupBox1.TabIndex = 8
        Me.UiGroupBox1.Text = "Totales"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Soles :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Dolares :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(387, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Gastos Banc."
        '
        'txtTotalGastosSol
        '
        Me.txtTotalGastosSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalGastosSol.Enabled = False
        Me.txtTotalGastosSol.FormatString = "n"
        Me.txtTotalGastosSol.Location = New System.Drawing.Point(377, 49)
        Me.txtTotalGastosSol.Name = "txtTotalGastosSol"
        Me.txtTotalGastosSol.Size = New System.Drawing.Size(95, 20)
        Me.txtTotalGastosSol.TabIndex = 15
        Me.txtTotalGastosSol.Text = "0.00"
        Me.txtTotalGastosSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalGastosDol
        '
        Me.txtTotalGastosDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalGastosDol.Enabled = False
        Me.txtTotalGastosDol.FormatString = "n"
        Me.txtTotalGastosDol.Location = New System.Drawing.Point(377, 27)
        Me.txtTotalGastosDol.Name = "txtTotalGastosDol"
        Me.txtTotalGastosDol.Size = New System.Drawing.Size(95, 20)
        Me.txtTotalGastosDol.TabIndex = 14
        Me.txtTotalGastosDol.Text = "0.00"
        Me.txtTotalGastosDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(291, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "A Pagar"
        '
        'txtTotalaPagarSol
        '
        Me.txtTotalaPagarSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalaPagarSol.Enabled = False
        Me.txtTotalaPagarSol.FormatString = "n2"
        Me.txtTotalaPagarSol.Location = New System.Drawing.Point(273, 49)
        Me.txtTotalaPagarSol.Name = "txtTotalaPagarSol"
        Me.txtTotalaPagarSol.Size = New System.Drawing.Size(95, 20)
        Me.txtTotalaPagarSol.TabIndex = 13
        Me.txtTotalaPagarSol.Text = "0.00"
        Me.txtTotalaPagarSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalaPagarDol
        '
        Me.txtTotalaPagarDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalaPagarDol.Enabled = False
        Me.txtTotalaPagarDol.FormatString = "n2"
        Me.txtTotalaPagarDol.Location = New System.Drawing.Point(273, 27)
        Me.txtTotalaPagarDol.Name = "txtTotalaPagarDol"
        Me.txtTotalaPagarDol.Size = New System.Drawing.Size(95, 20)
        Me.txtTotalaPagarDol.TabIndex = 12
        Me.txtTotalaPagarDol.Text = "0.00"
        Me.txtTotalaPagarDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(189, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Pagado"
        '
        'txtTotalPagoSol
        '
        Me.txtTotalPagoSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalPagoSol.Enabled = False
        Me.txtTotalPagoSol.FormatString = "n"
        Me.txtTotalPagoSol.Location = New System.Drawing.Point(169, 49)
        Me.txtTotalPagoSol.Name = "txtTotalPagoSol"
        Me.txtTotalPagoSol.Size = New System.Drawing.Size(95, 20)
        Me.txtTotalPagoSol.TabIndex = 11
        Me.txtTotalPagoSol.Text = "0.00"
        Me.txtTotalPagoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalPagoDol
        '
        Me.txtTotalPagoDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalPagoDol.Enabled = False
        Me.txtTotalPagoDol.FormatString = "n"
        Me.txtTotalPagoDol.Location = New System.Drawing.Point(169, 27)
        Me.txtTotalPagoDol.Name = "txtTotalPagoDol"
        Me.txtTotalPagoDol.Size = New System.Drawing.Size(95, 20)
        Me.txtTotalPagoDol.TabIndex = 10
        Me.txtTotalPagoDol.Text = "0.00"
        Me.txtTotalPagoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(76, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Documento"
        '
        'txtTotalDocSol
        '
        Me.txtTotalDocSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalDocSol.Enabled = False
        Me.txtTotalDocSol.FormatString = "n"
        Me.txtTotalDocSol.Location = New System.Drawing.Point(66, 49)
        Me.txtTotalDocSol.Name = "txtTotalDocSol"
        Me.txtTotalDocSol.Size = New System.Drawing.Size(95, 20)
        Me.txtTotalDocSol.TabIndex = 9
        Me.txtTotalDocSol.Text = "0.00"
        Me.txtTotalDocSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalDocDol
        '
        Me.txtTotalDocDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalDocDol.Enabled = False
        Me.txtTotalDocDol.FormatString = "n"
        Me.txtTotalDocDol.Location = New System.Drawing.Point(66, 27)
        Me.txtTotalDocDol.Name = "txtTotalDocDol"
        Me.txtTotalDocDol.Size = New System.Drawing.Size(95, 20)
        Me.txtTotalDocDol.TabIndex = 8
        Me.txtTotalDocDol.Text = "0.00"
        Me.txtTotalDocDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtDifCambio
        '
        Me.txtDifCambio.DecimalDigits = 2
        Me.txtDifCambio.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDifCambio.Enabled = False
        Me.txtDifCambio.Location = New System.Drawing.Point(170, 212)
        Me.txtDifCambio.Name = "txtDifCambio"
        Me.txtDifCambio.Size = New System.Drawing.Size(74, 20)
        Me.txtDifCambio.TabIndex = 16
        Me.txtDifCambio.TabStop = False
        Me.txtDifCambio.Text = "0.00"
        Me.txtDifCambio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDifCambio.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 215)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(155, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Diferencia del Tipo de Cambio :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 240)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Observaciones :"
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtObservacion.Location = New System.Drawing.Point(97, 237)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.Size = New System.Drawing.Size(398, 20)
        Me.txtObservacion.TabIndex = 17
        '
        'btnAceptar
        '
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(337, 262)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 25)
        Me.btnAceptar.TabIndex = 18
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        Me.btnAceptar.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(420, 262)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 25)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(307, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Fecha Banco :"
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Enabled = False
        Me.txtFecDoc.IsNullDate = True
        Me.txtFecDoc.Location = New System.Drawing.Point(390, 33)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.ShowNullButton = True
        Me.txtFecDoc.Size = New System.Drawing.Size(103, 20)
        Me.txtFecDoc.TabIndex = 3
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtMontoBanco
        '
        Me.txtMontoBanco.DecimalDigits = 2
        Me.txtMontoBanco.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMontoBanco.Enabled = False
        Me.txtMontoBanco.Location = New System.Drawing.Point(390, 54)
        Me.txtMontoBanco.Name = "txtMontoBanco"
        Me.txtMontoBanco.Size = New System.Drawing.Size(82, 20)
        Me.txtMontoBanco.TabIndex = 4
        Me.txtMontoBanco.Text = "0.00"
        Me.txtMontoBanco.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(307, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Monto Banco :"
        '
        'txtNroOperacion
        '
        Me.txtNroOperacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroOperacion.Enabled = False
        Me.txtNroOperacion.Location = New System.Drawing.Point(390, 75)
        Me.txtNroOperacion.Name = "txtNroOperacion"
        Me.txtNroOperacion.Size = New System.Drawing.Size(104, 20)
        Me.txtNroOperacion.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(307, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 252
        Me.Label15.Text = "Nro Operación :"
        '
        'frmPlanillaPago
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(510, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtNroOperacion)
        Me.Controls.Add(Me.txtMontoBanco)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtFecDoc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtDifCambio)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNumDoc)
        Me.Controls.Add(Me.lblNumero)
        Me.Controls.Add(Me.cbMoneda)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbBanco)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbTipoPago)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmPlanillaPago"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pagos de Documento"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTipoPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbTipoPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDocSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDocDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalGastosSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalGastosDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalaPagarSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalaPagarDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPagoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPagoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDifCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtMontoBanco As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNroOperacion As System.Windows.Forms.TextBox
End Class
