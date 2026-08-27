<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAprobarServicios_Detalle
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosCot_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvcostos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAprobarServicios_Detalle))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAprobar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvDatosCot = New Janus.Windows.GridEX.GridEX()
        Me.lblTotalMontoSinIgv = New System.Windows.Forms.TextBox()
        Me.txtMontoSinIGV = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoBruto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoDscto = New System.Windows.Forms.TextBox()
        Me.txtTotalDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoTotalNeto = New System.Windows.Forms.TextBox()
        Me.lblMontoTotal = New System.Windows.Forms.TextBox()
        Me.txtMontoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCentroCosto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvcostos = New Janus.Windows.GridEX.GridEX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCostoTeorico = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtUtilidadteocrico = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtporcentajeteorico = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gbTipoReporte = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtventa = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatosCot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvcostos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoReporte.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(380, 40)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(294, 20)
        Me.txtCliente.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(327, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Cliente :"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(223, 40)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(83, 20)
        Me.txtFecha.TabIndex = 51
        Me.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(172, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Fecha :"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(71, 40)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(83, 20)
        Me.txtNumDoc.TabIndex = 49
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Número :"
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biAprobar, Me.ToolStripSeparator1, Me.biSalir, Me.ToolStripSeparator3})
        Me.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(848, 31)
        Me.ToolStrip.TabIndex = 55
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biAprobar
        '
        Me.biAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.biAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAprobar.Name = "biAprobar"
        Me.biAprobar.Size = New System.Drawing.Size(28, 28)
        Me.biAprobar.Text = "ToolStripButton1"
        Me.biAprobar.ToolTipText = "Aprobar Cotización de Servicios"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(10, 84)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(805, 169)
        Me.dgvDatos.TabIndex = 54
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(347, 264)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 13)
        Me.Label14.TabIndex = 108
        Me.Label14.Text = "Total Sugerido :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(113, 263)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 13)
        Me.Label15.TabIndex = 107
        Me.Label15.Text = "Total Repuestos :"
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.Location = New System.Drawing.Point(228, 260)
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalNeto.TabIndex = 106
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalSug
        '
        Me.txtTotalSug.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSug.Location = New System.Drawing.Point(451, 260)
        Me.txtTotalSug.Name = "txtTotalSug"
        Me.txtTotalSug.ReadOnly = True
        Me.txtTotalSug.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalSug.TabIndex = 105
        Me.txtTotalSug.Text = "0.00"
        Me.txtTotalSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'dgvDatosCot
        '
        Me.dgvDatosCot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvDatosCot_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosCot_DesignTimeLayout.LayoutString")
        Me.dgvDatosCot.DesignTimeLayout = dgvDatosCot_DesignTimeLayout
        Me.dgvDatosCot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatosCot.GroupByBoxVisible = False
        Me.dgvDatosCot.Location = New System.Drawing.Point(11, 296)
        Me.dgvDatosCot.Name = "dgvDatosCot"
        Me.dgvDatosCot.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosCot.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosCot.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosCot.Size = New System.Drawing.Size(805, 163)
        Me.dgvDatosCot.TabIndex = 109
        Me.dgvDatosCot.TabStop = False
        Me.dgvDatosCot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'lblTotalMontoSinIgv
        '
        Me.lblTotalMontoSinIgv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lblTotalMontoSinIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalMontoSinIgv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalMontoSinIgv.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalMontoSinIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMontoSinIgv.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalMontoSinIgv.Location = New System.Drawing.Point(11, 669)
        Me.lblTotalMontoSinIgv.MaxLength = 20
        Me.lblTotalMontoSinIgv.Name = "lblTotalMontoSinIgv"
        Me.lblTotalMontoSinIgv.ReadOnly = True
        Me.lblTotalMontoSinIgv.Size = New System.Drawing.Size(213, 20)
        Me.lblTotalMontoSinIgv.TabIndex = 118
        Me.lblTotalMontoSinIgv.TabStop = False
        Me.lblTotalMontoSinIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoSinIGV
        '
        Me.txtMontoSinIGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtMontoSinIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoSinIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSinIGV.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoSinIGV.Location = New System.Drawing.Point(223, 669)
        Me.txtMontoSinIGV.MaxLength = 5
        Me.txtMontoSinIGV.Name = "txtMontoSinIGV"
        Me.txtMontoSinIGV.ReadOnly = True
        Me.txtMontoSinIGV.Size = New System.Drawing.Size(94, 20)
        Me.txtMontoSinIGV.TabIndex = 110
        Me.txtMontoSinIGV.TabStop = False
        Me.txtMontoSinIGV.Text = "0.00"
        Me.txtMontoSinIGV.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoSinIGV.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoSinIGV.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoBruto
        '
        Me.txtMontoBruto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtMontoBruto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoBruto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoBruto.Location = New System.Drawing.Point(127, 631)
        Me.txtMontoBruto.MaxLength = 5
        Me.txtMontoBruto.Name = "txtMontoBruto"
        Me.txtMontoBruto.ReadOnly = True
        Me.txtMontoBruto.Size = New System.Drawing.Size(97, 20)
        Me.txtMontoBruto.TabIndex = 117
        Me.txtMontoBruto.TabStop = False
        Me.txtMontoBruto.Text = "0.00"
        Me.txtMontoBruto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoBruto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoBruto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoTotalNeto
        '
        Me.txtMontoTotalNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtMontoTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoTotalNeto.Location = New System.Drawing.Point(223, 688)
        Me.txtMontoTotalNeto.MaxLength = 5
        Me.txtMontoTotalNeto.Name = "txtMontoTotalNeto"
        Me.txtMontoTotalNeto.ReadOnly = True
        Me.txtMontoTotalNeto.Size = New System.Drawing.Size(94, 20)
        Me.txtMontoTotalNeto.TabIndex = 116
        Me.txtMontoTotalNeto.TabStop = False
        Me.txtMontoTotalNeto.Text = "0.00"
        Me.txtMontoTotalNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoDscto
        '
        Me.lblMontoDscto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lblMontoDscto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoDscto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoDscto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoDscto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoDscto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoDscto.Location = New System.Drawing.Point(11, 631)
        Me.lblMontoDscto.MaxLength = 20
        Me.lblMontoDscto.Name = "lblMontoDscto"
        Me.lblMontoDscto.ReadOnly = True
        Me.lblMontoDscto.Size = New System.Drawing.Size(117, 20)
        Me.lblMontoDscto.TabIndex = 111
        Me.lblMontoDscto.TabStop = False
        Me.lblMontoDscto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDescuento.Location = New System.Drawing.Point(223, 631)
        Me.txtTotalDescuento.MaxLength = 5
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(94, 20)
        Me.txtTotalDescuento.TabIndex = 112
        Me.txtTotalDescuento.TabStop = False
        Me.txtTotalDescuento.Text = "0.00"
        Me.txtTotalDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDescuento.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoTotalNeto
        '
        Me.lblMontoTotalNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lblMontoTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoTotalNeto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoTotalNeto.Location = New System.Drawing.Point(11, 688)
        Me.lblMontoTotalNeto.MaxLength = 20
        Me.lblMontoTotalNeto.Name = "lblMontoTotalNeto"
        Me.lblMontoTotalNeto.ReadOnly = True
        Me.lblMontoTotalNeto.Size = New System.Drawing.Size(213, 20)
        Me.lblMontoTotalNeto.TabIndex = 115
        Me.lblMontoTotalNeto.TabStop = False
        Me.lblMontoTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lblMontoTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoTotal.Location = New System.Drawing.Point(11, 650)
        Me.lblMontoTotal.MaxLength = 20
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.ReadOnly = True
        Me.lblMontoTotal.Size = New System.Drawing.Size(213, 20)
        Me.lblMontoTotal.TabIndex = 113
        Me.lblMontoTotal.TabStop = False
        Me.lblMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.txtMontoTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoTotal.Location = New System.Drawing.Point(223, 650)
        Me.txtMontoTotal.MaxLength = 5
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(94, 20)
        Me.txtMontoTotal.TabIndex = 114
        Me.txtMontoTotal.TabStop = False
        Me.txtMontoTotal.Text = "0.00"
        Me.txtMontoTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodMon
        '
        Me.cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(745, 39)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.ReadOnly = True
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(51, 20)
        Me.cmbCodMon.TabIndex = 131
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(689, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Moneda"
        '
        'txtCentroCosto
        '
        Me.txtCentroCosto.Location = New System.Drawing.Point(360, 62)
        Me.txtCentroCosto.Name = "txtCentroCosto"
        Me.txtCentroCosto.ReadOnly = True
        Me.txtCentroCosto.Size = New System.Drawing.Size(235, 20)
        Me.txtCentroCosto.TabIndex = 134
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(248, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Centro de Costo :"
        '
        'txtArea
        '
        Me.txtArea.Location = New System.Drawing.Point(71, 62)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(158, 20)
        Me.txtArea.TabIndex = 136
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "Área :"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(680, 62)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(116, 20)
        Me.txtUsuario.TabIndex = 138
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(616, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 137
        Me.Label7.Text = "Usuario :"
        '
        'dgvcostos
        '
        Me.dgvcostos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvcostos_DesignTimeLayout.LayoutString = resources.GetString("dgvcostos_DesignTimeLayout.LayoutString")
        Me.dgvcostos.DesignTimeLayout = dgvcostos_DesignTimeLayout
        Me.dgvcostos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvcostos.GroupByBoxVisible = False
        Me.dgvcostos.Location = New System.Drawing.Point(11, 490)
        Me.dgvcostos.Name = "dgvcostos"
        Me.dgvcostos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvcostos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvcostos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvcostos.Size = New System.Drawing.Size(805, 142)
        Me.dgvcostos.TabIndex = 139
        Me.dgvcostos.TabStop = False
        Me.dgvcostos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 473)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 13)
        Me.Label8.TabIndex = 140
        Me.Label8.Text = "Costos Involucrados :"
        '
        'txtCostoTeorico
        '
        Me.txtCostoTeorico.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCostoTeorico.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtCostoTeorico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoTeorico.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtCostoTeorico.Location = New System.Drawing.Point(129, 46)
        Me.txtCostoTeorico.MaxLength = 5
        Me.txtCostoTeorico.Name = "txtCostoTeorico"
        Me.txtCostoTeorico.ReadOnly = True
        Me.txtCostoTeorico.Size = New System.Drawing.Size(83, 20)
        Me.txtCostoTeorico.TabIndex = 141
        Me.txtCostoTeorico.TabStop = False
        Me.txtCostoTeorico.Text = "0.00"
        Me.txtCostoTeorico.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCostoTeorico.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostoTeorico.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(149, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 142
        Me.Label9.Text = "Costo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(256, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 144
        Me.Label10.Text = "Utilidad"
        '
        'txtUtilidadteocrico
        '
        Me.txtUtilidadteocrico.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtUtilidadteocrico.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtUtilidadteocrico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUtilidadteocrico.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtUtilidadteocrico.Location = New System.Drawing.Point(242, 46)
        Me.txtUtilidadteocrico.MaxLength = 5
        Me.txtUtilidadteocrico.Name = "txtUtilidadteocrico"
        Me.txtUtilidadteocrico.ReadOnly = True
        Me.txtUtilidadteocrico.Size = New System.Drawing.Size(73, 20)
        Me.txtUtilidadteocrico.TabIndex = 143
        Me.txtUtilidadteocrico.TabStop = False
        Me.txtUtilidadteocrico.Text = "0.00"
        Me.txtUtilidadteocrico.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtUtilidadteocrico.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtUtilidadteocrico.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(339, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 13)
        Me.Label11.TabIndex = 146
        Me.Label11.Text = "%"
        '
        'txtporcentajeteorico
        '
        Me.txtporcentajeteorico.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtporcentajeteorico.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtporcentajeteorico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtporcentajeteorico.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtporcentajeteorico.Location = New System.Drawing.Point(320, 46)
        Me.txtporcentajeteorico.MaxLength = 5
        Me.txtporcentajeteorico.Name = "txtporcentajeteorico"
        Me.txtporcentajeteorico.ReadOnly = True
        Me.txtporcentajeteorico.Size = New System.Drawing.Size(44, 20)
        Me.txtporcentajeteorico.TabIndex = 145
        Me.txtporcentajeteorico.TabStop = False
        Me.txtporcentajeteorico.Text = "0.00"
        Me.txtporcentajeteorico.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtporcentajeteorico.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtporcentajeteorico.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbTipoReporte
        '
        Me.gbTipoReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.gbTipoReporte.Controls.Add(Me.Label16)
        Me.gbTipoReporte.Controls.Add(Me.Label13)
        Me.gbTipoReporte.Controls.Add(Me.Label12)
        Me.gbTipoReporte.Controls.Add(Me.txtventa)
        Me.gbTipoReporte.Controls.Add(Me.Label9)
        Me.gbTipoReporte.Controls.Add(Me.txtCostoTeorico)
        Me.gbTipoReporte.Controls.Add(Me.Label10)
        Me.gbTipoReporte.Controls.Add(Me.txtUtilidadteocrico)
        Me.gbTipoReporte.Controls.Add(Me.Label11)
        Me.gbTipoReporte.Controls.Add(Me.txtporcentajeteorico)
        Me.gbTipoReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoReporte.Location = New System.Drawing.Point(389, 640)
        Me.gbTipoReporte.Name = "gbTipoReporte"
        Me.gbTipoReporte.Size = New System.Drawing.Size(409, 89)
        Me.gbTipoReporte.TabIndex = 286
        Me.gbTipoReporte.Text = "Total Costo Teorico"
        Me.gbTipoReporte.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(220, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(17, 17)
        Me.Label16.TabIndex = 150
        Me.Label16.Text = "="
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(111, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(14, 17)
        Me.Label13.TabIndex = 149
        Me.Label13.Text = "-"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(40, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 148
        Me.Label12.Text = "Venta"
        '
        'txtventa
        '
        Me.txtventa.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtventa.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtventa.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtventa.Location = New System.Drawing.Point(20, 46)
        Me.txtventa.MaxLength = 5
        Me.txtventa.Name = "txtventa"
        Me.txtventa.ReadOnly = True
        Me.txtventa.Size = New System.Drawing.Size(83, 20)
        Me.txtventa.TabIndex = 147
        Me.txtventa.TabStop = False
        Me.txtventa.Text = "0.00"
        Me.txtventa.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtventa.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtventa.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmAprobarServicios_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 757)
        Me.Controls.Add(Me.gbTipoReporte)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvcostos)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtArea)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCentroCosto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbCodMon)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTotalMontoSinIgv)
        Me.Controls.Add(Me.txtMontoSinIGV)
        Me.Controls.Add(Me.txtMontoBruto)
        Me.Controls.Add(Me.txtMontoTotalNeto)
        Me.Controls.Add(Me.lblMontoDscto)
        Me.Controls.Add(Me.txtTotalDescuento)
        Me.Controls.Add(Me.lblMontoTotalNeto)
        Me.Controls.Add(Me.lblMontoTotal)
        Me.Controls.Add(Me.txtMontoTotal)
        Me.Controls.Add(Me.dgvDatosCot)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtTotalNeto)
        Me.Controls.Add(Me.txtTotalSug)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumDoc)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAprobarServicios_Detalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AprobarServicios_Detalle"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatosCot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvcostos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoReporte.ResumeLayout(False)
        Me.gbTipoReporte.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dgvDatosCot As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblTotalMontoSinIgv As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoSinIGV As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoBruto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoDscto As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents lblMontoTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCentroCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dgvcostos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label11 As Label
    Friend WithEvents txtporcentajeteorico As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtUtilidadteocrico As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCostoTeorico As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents gbTipoReporte As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtventa As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents biAprobar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
End Class
