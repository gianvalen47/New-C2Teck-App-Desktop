<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsultaDocumento
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim dgDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaDocumento))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator101 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator107 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCondicionPago = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtGuias = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgDetalle = New Janus.Windows.GridEX.GridEX()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTipCam = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecDoc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblTotalNeto = New System.Windows.Forms.TextBox()
        Me.lbltotalIGV = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.TextBox()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalIGV = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtNumCoti = New System.Windows.Forms.TextBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtNumOrden = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator101, Me.biSalir, Me.ToolStripSeparator107, Me.biActualizar})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(699, 31)
        Me.ToolStrip.TabIndex = 7
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator101
        '
        Me.ToolStripSeparator101.Name = "ToolStripSeparator101"
        Me.ToolStripSeparator101.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar Formulario"
        '
        'ToolStripSeparator107
        '
        Me.ToolStripSeparator107.Name = "ToolStripSeparator107"
        Me.ToolStripSeparator107.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizr Datos del Formulario"
        '
        'txtNumJob
        '
        Me.txtNumJob.Location = New System.Drawing.Point(250, 111)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.ReadOnly = True
        Me.txtNumJob.Size = New System.Drawing.Size(71, 20)
        Me.txtNumJob.TabIndex = 32
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(205, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "# OT :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtCondicionPago)
        Me.UiGroupBox2.Controls.Add(Me.Label14)
        Me.UiGroupBox2.Controls.Add(Me.txtGuias)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtMotivo)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Location = New System.Drawing.Point(5, 138)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(655, 41)
        Me.UiGroupBox2.TabIndex = 50
        Me.UiGroupBox2.Text = "Datos de Venta"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCondicionPago
        '
        Me.txtCondicionPago.Location = New System.Drawing.Point(107, 15)
        Me.txtCondicionPago.Name = "txtCondicionPago"
        Me.txtCondicionPago.ReadOnly = True
        Me.txtCondicionPago.Size = New System.Drawing.Size(157, 20)
        Me.txtCondicionPago.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(2, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 13)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Condicion de Pago :"
        '
        'txtGuias
        '
        Me.txtGuias.Location = New System.Drawing.Point(538, 15)
        Me.txtGuias.Name = "txtGuias"
        Me.txtGuias.ReadOnly = True
        Me.txtGuias.Size = New System.Drawing.Size(112, 20)
        Me.txtGuias.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(455, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Numero Guias :"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(316, 15)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ReadOnly = True
        Me.txtMotivo.Size = New System.Drawing.Size(136, 20)
        Me.txtMotivo.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(267, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Motivo :"
        '
        'dgDetalle
        '
        Me.dgDetalle.AllowCardSizing = False
        Me.dgDetalle.AllowColumnDrag = False
        Me.dgDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgDetalle.AlternatingColors = True
        Me.dgDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgDetalle_DesignTimeLayout.LayoutString = resources.GetString("dgDetalle_DesignTimeLayout.LayoutString")
        Me.dgDetalle.DesignTimeLayout = dgDetalle_DesignTimeLayout
        Me.dgDetalle.EmptyRows = True
        Me.dgDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgDetalle.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgDetalle.GroupByBoxVisible = False
        Me.dgDetalle.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgDetalle.Location = New System.Drawing.Point(5, 187)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgDetalle.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgDetalle.Size = New System.Drawing.Size(667, 193)
        Me.dgDetalle.TabIndex = 48
        Me.dgDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMoneda
        '
        Me.txtMoneda.Location = New System.Drawing.Point(352, 36)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(89, 20)
        Me.txtMoneda.TabIndex = 47
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(297, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Moneda :"
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(525, 59)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.ReadOnly = True
        Me.txtFactura.Size = New System.Drawing.Size(101, 20)
        Me.txtFactura.TabIndex = 45
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(476, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Factura :"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(70, 59)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(399, 20)
        Me.txtCliente.TabIndex = 43
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Cliente :"
        '
        'txtTipCam
        '
        Me.txtTipCam.Location = New System.Drawing.Point(525, 36)
        Me.txtTipCam.Name = "txtTipCam"
        Me.txtTipCam.ReadOnly = True
        Me.txtTipCam.Size = New System.Drawing.Size(53, 20)
        Me.txtTipCam.TabIndex = 41
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(448, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Tipo Cambio :"
        '
        'txtFecDoc
        '
        Me.txtFecDoc.Location = New System.Drawing.Point(221, 36)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.ReadOnly = True
        Me.txtFecDoc.Size = New System.Drawing.Size(67, 20)
        Me.txtFecDoc.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Fecha :"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(70, 36)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(91, 20)
        Me.txtNumero.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Numero :"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox1.Controls.Add(Me.lblTotalNeto)
        Me.UiGroupBox1.Controls.Add(Me.lbltotalIGV)
        Me.UiGroupBox1.Controls.Add(Me.lblTotal)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalNeto)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalIGV)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPrecio)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDescuento)
        Me.UiGroupBox1.Controls.Add(Me.txtTotal)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 388)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(699, 73)
        Me.UiGroupBox1.TabIndex = 52
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalNeto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalNeto.Location = New System.Drawing.Point(20, 49)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(524, 20)
        Me.lblTotalNeto.TabIndex = 2
        Me.lblTotalNeto.TabStop = False
        Me.lblTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotalIGV
        '
        Me.lbltotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lbltotalIGV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lbltotalIGV.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbltotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalIGV.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltotalIGV.Location = New System.Drawing.Point(20, 30)
        Me.lbltotalIGV.MaxLength = 20
        Me.lbltotalIGV.Name = "lbltotalIGV"
        Me.lbltotalIGV.ReadOnly = True
        Me.lbltotalIGV.Size = New System.Drawing.Size(524, 20)
        Me.lbltotalIGV.TabIndex = 1
        Me.lbltotalIGV.TabStop = False
        Me.lbltotalIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotal.Location = New System.Drawing.Point(20, 11)
        Me.lblTotal.MaxLength = 20
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.ReadOnly = True
        Me.lblTotal.Size = New System.Drawing.Size(329, 20)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNeto.Location = New System.Drawing.Point(542, 49)
        Me.txtTotalNeto.MaxLength = 5
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(101, 20)
        Me.txtTotalNeto.TabIndex = 7
        Me.txtTotalNeto.TabStop = False
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalIGV
        '
        Me.txtTotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIGV.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalIGV.Location = New System.Drawing.Point(542, 30)
        Me.txtTotalIGV.MaxLength = 5
        Me.txtTotalIGV.Name = "txtTotalIGV"
        Me.txtTotalIGV.ReadOnly = True
        Me.txtTotalIGV.Size = New System.Drawing.Size(101, 20)
        Me.txtTotalIGV.TabIndex = 6
        Me.txtTotalIGV.TabStop = False
        Me.txtTotalIGV.Text = "0.00"
        Me.txtTotalIGV.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalIGV.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIGV.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalPrecio
        '
        Me.txtTotalPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrecio.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalPrecio.Location = New System.Drawing.Point(345, 11)
        Me.txtTotalPrecio.MaxLength = 5
        Me.txtTotalPrecio.Name = "txtTotalPrecio"
        Me.txtTotalPrecio.ReadOnly = True
        Me.txtTotalPrecio.Size = New System.Drawing.Size(101, 20)
        Me.txtTotalPrecio.TabIndex = 3
        Me.txtTotalPrecio.TabStop = False
        Me.txtTotalPrecio.Text = "0.00"
        Me.txtTotalPrecio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalPrecio.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDescuento.Location = New System.Drawing.Point(442, 11)
        Me.txtTotalDescuento.MaxLength = 5
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(102, 20)
        Me.txtTotalDescuento.TabIndex = 4
        Me.txtTotalDescuento.TabStop = False
        Me.txtTotalDescuento.Text = "0.00"
        Me.txtTotalDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDescuento.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotal.Location = New System.Drawing.Point(542, 11)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(101, 20)
        Me.txtTotal.TabIndex = 5
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumCoti
        '
        Me.txtNumCoti.Location = New System.Drawing.Point(525, 85)
        Me.txtNumCoti.Name = "txtNumCoti"
        Me.txtNumCoti.ReadOnly = True
        Me.txtNumCoti.Size = New System.Drawing.Size(101, 20)
        Me.txtNumCoti.TabIndex = 53
        '
        'txtVendedor
        '
        Me.txtVendedor.Location = New System.Drawing.Point(70, 85)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(229, 20)
        Me.txtVendedor.TabIndex = 54
        '
        'txtNumOrden
        '
        Me.txtNumOrden.Location = New System.Drawing.Point(346, 85)
        Me.txtNumOrden.Name = "txtNumOrden"
        Me.txtNumOrden.ReadOnly = True
        Me.txtNumOrden.Size = New System.Drawing.Size(101, 20)
        Me.txtNumOrden.TabIndex = 55
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(70, 111)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(101, 20)
        Me.txtUsuario.TabIndex = 56
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Vendedor :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(311, 88)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "O/C :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(463, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Cotización :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 114)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "Usuario :"
        '
        'frmConsultaDocumento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(699, 461)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtNumJob)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNumOrden)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.txtNumCoti)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.dgDetalle)
        Me.Controls.Add(Me.txtMoneda)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtFactura)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTipCam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFecDoc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaDocumento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documento de Inventario "
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator101 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator107 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCondicionPago As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtGuias As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTipCam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalIGV As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalIGV As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtNumOrden As System.Windows.Forms.TextBox
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtNumCoti As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
End Class
