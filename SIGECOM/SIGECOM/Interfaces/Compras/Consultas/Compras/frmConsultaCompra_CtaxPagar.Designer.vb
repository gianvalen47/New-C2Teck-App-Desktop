<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaCompra_CtaxPagar
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
        Dim cmbCodPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaCompra_CtaxPagar))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbProveedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.cmbCodPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbFacturacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtSerieDoc = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbCabecera = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbPagoCaja = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbPersonaPosesion = New Janus.Windows.EditControls.UIComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbRecibioCheque = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecVencimiento = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtTotalPago = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalPago = New System.Windows.Forms.Label()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblFecVencimiento = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecRecepcion = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecEmision = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIdCuenta = New System.Windows.Forms.TextBox()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        CType(Me.cmbCodPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFacturacion.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCabecera.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(756, 31)
        Me.ToolStrip.TabIndex = 189
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.gbProveedor)
        Me.UiGroupBox1.Controls.Add(Me.gbFacturacion)
        Me.UiGroupBox1.Controls.Add(Me.gbCabecera)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(4, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(736, 284)
        Me.UiGroupBox1.TabIndex = 196
        Me.UiGroupBox1.Text = "CUENTAS POR PAGAR"
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbProveedor
        '
        Me.gbProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.gbProveedor.Controls.Add(Me.Label12)
        Me.gbProveedor.Controls.Add(Me.txtProveedor)
        Me.gbProveedor.Controls.Add(Me.cmbCodPago)
        Me.gbProveedor.Controls.Add(Me.Label6)
        Me.gbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProveedor.ForeColor = System.Drawing.Color.Black
        Me.gbProveedor.Location = New System.Drawing.Point(6, 182)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(724, 44)
        Me.gbProveedor.TabIndex = 191
        Me.gbProveedor.Text = "Proveedor"
        Me.gbProveedor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(90, 16)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(336, 20)
        Me.txtProveedor.TabIndex = 14
        '
        'cmbCodPago
        '
        Me.cmbCodPago.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodPago_DesignTimeLayout.LayoutString = resources.GetString("cmbCodPago_DesignTimeLayout.LayoutString")
        Me.cmbCodPago.DesignTimeLayout = cmbCodPago_DesignTimeLayout
        Me.cmbCodPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodPago.Location = New System.Drawing.Point(545, 16)
        Me.cmbCodPago.Name = "cmbCodPago"
        Me.cmbCodPago.ReadOnly = True
        Me.cmbCodPago.SelectedIndex = -1
        Me.cmbCodPago.SelectedItem = Nothing
        Me.cmbCodPago.Size = New System.Drawing.Size(173, 19)
        Me.cmbCodPago.TabIndex = 16
        Me.cmbCodPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(444, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cond. de Pago "
        '
        'gbFacturacion
        '
        Me.gbFacturacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.gbFacturacion.Controls.Add(Me.txtSerieDoc)
        Me.gbFacturacion.Controls.Add(Me.Label16)
        Me.gbFacturacion.Controls.Add(Me.txtNumDoc)
        Me.gbFacturacion.Controls.Add(Me.cmbTipoDoc)
        Me.gbFacturacion.Controls.Add(Me.Label15)
        Me.gbFacturacion.Controls.Add(Me.Label7)
        Me.gbFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFacturacion.ForeColor = System.Drawing.Color.Black
        Me.gbFacturacion.Location = New System.Drawing.Point(6, 232)
        Me.gbFacturacion.Name = "gbFacturacion"
        Me.gbFacturacion.Size = New System.Drawing.Size(724, 43)
        Me.gbFacturacion.TabIndex = 192
        Me.gbFacturacion.Text = "Facturación"
        Me.gbFacturacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtSerieDoc
        '
        Me.txtSerieDoc.BackColor = System.Drawing.SystemColors.Control
        Me.txtSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtSerieDoc.Location = New System.Drawing.Point(419, 15)
        Me.txtSerieDoc.MaxLength = 20
        Me.txtSerieDoc.Name = "txtSerieDoc"
        Me.txtSerieDoc.ReadOnly = True
        Me.txtSerieDoc.Size = New System.Drawing.Size(78, 20)
        Me.txtSerieDoc.TabIndex = 18
        Me.txtSerieDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(309, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 13)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Serie Documento"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(598, 15)
        Me.txtNumDoc.MaxLength = 20
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(120, 20)
        Me.txtNumDoc.TabIndex = 19
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.BackColor = System.Drawing.SystemColors.Control
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Location = New System.Drawing.Point(90, 15)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.ReadOnly = True
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(205, 20)
        Me.cmbTipoDoc.TabIndex = 17
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Tipo Docum."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(503, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Nº Documento"
        '
        'gbCabecera
        '
        Me.gbCabecera.Controls.Add(Me.cbPagoCaja)
        Me.gbCabecera.Controls.Add(Me.Label14)
        Me.gbCabecera.Controls.Add(Me.cmbPersonaPosesion)
        Me.gbCabecera.Controls.Add(Me.Label11)
        Me.gbCabecera.Controls.Add(Me.cbRecibioCheque)
        Me.gbCabecera.Controls.Add(Me.Label4)
        Me.gbCabecera.Controls.Add(Me.txtFecVencimiento)
        Me.gbCabecera.Controls.Add(Me.Label13)
        Me.gbCabecera.Controls.Add(Me.cmbMoneda)
        Me.gbCabecera.Controls.Add(Me.txtTotalPago)
        Me.gbCabecera.Controls.Add(Me.lblTotalPago)
        Me.gbCabecera.Controls.Add(Me.txtTotal)
        Me.gbCabecera.Controls.Add(Me.Label9)
        Me.gbCabecera.Controls.Add(Me.txtTipoCambio)
        Me.gbCabecera.Controls.Add(Me.Label10)
        Me.gbCabecera.Controls.Add(Me.Label8)
        Me.gbCabecera.Controls.Add(Me.txtObservacion)
        Me.gbCabecera.Controls.Add(Me.lblFecVencimiento)
        Me.gbCabecera.Controls.Add(Me.Label3)
        Me.gbCabecera.Controls.Add(Me.Label2)
        Me.gbCabecera.Controls.Add(Me.txtFecRecepcion)
        Me.gbCabecera.Controls.Add(Me.txtFecEmision)
        Me.gbCabecera.Controls.Add(Me.Label1)
        Me.gbCabecera.Controls.Add(Me.txtIdCuenta)
        Me.gbCabecera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCabecera.Location = New System.Drawing.Point(6, 13)
        Me.gbCabecera.Name = "gbCabecera"
        Me.gbCabecera.Size = New System.Drawing.Size(724, 163)
        Me.gbCabecera.TabIndex = 190
        Me.gbCabecera.Text = "Datos de Cuenta"
        Me.gbCabecera.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbPagoCaja
        '
        Me.cbPagoCaja.AutoSize = True
        Me.cbPagoCaja.Enabled = False
        Me.cbPagoCaja.Location = New System.Drawing.Point(693, 85)
        Me.cbPagoCaja.Name = "cbPagoCaja"
        Me.cbPagoCaja.Size = New System.Drawing.Size(15, 14)
        Me.cbPagoCaja.TabIndex = 12
        Me.cbPagoCaja.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(600, 85)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 13)
        Me.Label14.TabIndex = 217
        Me.Label14.Text = "Pago por Caja"
        '
        'cmbPersonaPosesion
        '
        Me.cmbPersonaPosesion.BackColor = System.Drawing.SystemColors.Control
        Me.cmbPersonaPosesion.Location = New System.Drawing.Point(274, 81)
        Me.cmbPersonaPosesion.Name = "cmbPersonaPosesion"
        Me.cmbPersonaPosesion.ReadOnly = True
        Me.cmbPersonaPosesion.Size = New System.Drawing.Size(308, 20)
        Me.cmbPersonaPosesion.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(140, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 13)
        Me.Label11.TabIndex = 216
        Me.Label11.Text = "Doc. en posesión de:"
        '
        'cbRecibioCheque
        '
        Me.cbRecibioCheque.AutoSize = True
        Me.cbRecibioCheque.Enabled = False
        Me.cbRecibioCheque.Location = New System.Drawing.Point(108, 85)
        Me.cbRecibioCheque.Name = "cbRecibioCheque"
        Me.cbRecibioCheque.Size = New System.Drawing.Size(15, 14)
        Me.cbRecibioCheque.TabIndex = 10
        Me.cbRecibioCheque.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 214
        Me.Label4.Text = "Recibio Cheque"
        '
        'txtFecVencimiento
        '
        Me.txtFecVencimiento.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecVencimiento.DropDownCalendar.Name = ""
        Me.txtFecVencimiento.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecVencimiento.IsNullDate = True
        Me.txtFecVencimiento.Location = New System.Drawing.Point(628, 19)
        Me.txtFecVencimiento.Name = "txtFecVencimiento"
        Me.txtFecVencimiento.ReadOnly = True
        Me.txtFecVencimiento.Size = New System.Drawing.Size(90, 20)
        Me.txtFecVencimiento.TabIndex = 5
        Me.txtFecVencimiento.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(217, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 209
        Me.Label13.Text = "Moneda"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(275, 50)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.ReadOnly = True
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(65, 20)
        Me.cmbMoneda.TabIndex = 7
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalPago
        '
        Me.txtTotalPago.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalPago.Location = New System.Drawing.Point(616, 50)
        Me.txtTotalPago.MaxLength = 12
        Me.txtTotalPago.Name = "txtTotalPago"
        Me.txtTotalPago.ReadOnly = True
        Me.txtTotalPago.Size = New System.Drawing.Size(102, 20)
        Me.txtTotalPago.TabIndex = 9
        Me.txtTotalPago.TabStop = False
        Me.txtTotalPago.Text = "0.00"
        Me.txtTotalPago.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotalPago
        '
        Me.lblTotalPago.AutoSize = True
        Me.lblTotalPago.Location = New System.Drawing.Point(541, 55)
        Me.lblTotalPago.Name = "lblTotalPago"
        Me.lblTotalPago.Size = New System.Drawing.Size(69, 13)
        Me.lblTotalPago.TabIndex = 206
        Me.lblTotalPago.Text = "Total Pago"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotal.Location = New System.Drawing.Point(422, 50)
        Me.txtTotal.MaxLength = 12
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(97, 20)
        Me.txtTotal.TabIndex = 8
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(380, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 204
        Me.Label9.Text = "Total"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.SystemColors.Control
        Me.txtTipoCambio.DecimalDigits = 3
        Me.txtTipoCambio.Location = New System.Drawing.Point(89, 50)
        Me.txtTipoCambio.MaxLength = 12
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(85, 20)
        Me.txtTipoCambio.TabIndex = 6
        Me.txtTipoCambio.Text = "0.000"
        Me.txtTipoCambio.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtTipoCambio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 202
        Me.Label10.Text = "Tipo Cambio"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 200
        Me.Label8.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.BackColor = System.Drawing.SystemColors.Control
        Me.txtObservacion.Location = New System.Drawing.Point(90, 112)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(628, 42)
        Me.txtObservacion.TabIndex = 13
        '
        'lblFecVencimiento
        '
        Me.lblFecVencimiento.AutoSize = True
        Me.lblFecVencimiento.Location = New System.Drawing.Point(522, 22)
        Me.lblFecVencimiento.Name = "lblFecVencimiento"
        Me.lblFecVencimiento.Size = New System.Drawing.Size(105, 13)
        Me.lblFecVencimiento.TabIndex = 195
        Me.lblFecVencimiento.Text = "Fec. Vencimiento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(329, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 194
        Me.Label3.Text = "Fec. Recepción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(154, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 193
        Me.Label2.Text = "Fec. Emisión"
        '
        'txtFecRecepcion
        '
        Me.txtFecRecepcion.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecRecepcion.DropDownCalendar.Name = ""
        Me.txtFecRecepcion.DropDownCalendar.Visible = False
        Me.txtFecRecepcion.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecRecepcion.Location = New System.Drawing.Point(429, 19)
        Me.txtFecRecepcion.Name = "txtFecRecepcion"
        Me.txtFecRecepcion.NullButtonText = "Ninguno"
        Me.txtFecRecepcion.ReadOnly = True
        Me.txtFecRecepcion.Size = New System.Drawing.Size(90, 20)
        Me.txtFecRecepcion.TabIndex = 4
        Me.txtFecRecepcion.TodayButtonText = "Hoy"
        Me.txtFecRecepcion.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecEmision
        '
        Me.txtFecEmision.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecEmision.DropDownCalendar.Name = ""
        Me.txtFecEmision.DropDownCalendar.Visible = False
        Me.txtFecEmision.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecEmision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecEmision.Location = New System.Drawing.Point(236, 19)
        Me.txtFecEmision.Name = "txtFecEmision"
        Me.txtFecEmision.NullButtonText = "Ninguno"
        Me.txtFecEmision.ReadOnly = True
        Me.txtFecEmision.Size = New System.Drawing.Size(90, 20)
        Me.txtFecEmision.TabIndex = 3
        Me.txtFecEmision.TodayButtonText = "Hoy"
        Me.txtFecEmision.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 189
        Me.Label1.Text = "Nº Cuenta"
        '
        'txtIdCuenta
        '
        Me.txtIdCuenta.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdCuenta.Location = New System.Drawing.Point(76, 19)
        Me.txtIdCuenta.MaxLength = 20
        Me.txtIdCuenta.Name = "txtIdCuenta"
        Me.txtIdCuenta.ReadOnly = True
        Me.txtIdCuenta.Size = New System.Drawing.Size(65, 20)
        Me.txtIdCuenta.TabIndex = 1
        Me.txtIdCuenta.TabStop = False
        Me.txtIdCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbDetalle
        '
        Me.gbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(4, 324)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(740, 180)
        Me.gbDetalle.TabIndex = 197
        Me.gbDetalle.Text = "Detalle"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(6, 18)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(728, 155)
        Me.dgvDatos.TabIndex = 193
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMostrar, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(112, 48)
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(111, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(111, 22)
        Me.miSalir.Text = "Salir"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 513)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.ssBarra.Size = New System.Drawing.Size(756, 20)
        Me.ssBarra.TabIndex = 198
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(180, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmConsultaCompra_CtaxPagar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(756, 533)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaCompra_CtaxPagar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Compra y/o Gasto"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        CType(Me.cmbCodPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFacturacion.ResumeLayout(False)
        Me.gbFacturacion.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCabecera.ResumeLayout(False)
        Me.gbCabecera.PerformLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbProveedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents cmbCodPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbFacturacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtSerieDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbCabecera As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbPagoCaja As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbPersonaPosesion As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbRecibioCheque As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFecVencimiento As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtTotalPago As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalPago As System.Windows.Forms.Label
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblFecVencimiento As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFecRecepcion As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecEmision As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdCuenta As System.Windows.Forms.TextBox
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
End Class
