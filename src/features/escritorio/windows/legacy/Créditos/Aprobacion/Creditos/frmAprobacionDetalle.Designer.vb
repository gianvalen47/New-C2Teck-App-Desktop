<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAprobacionDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAprobacionDetalle))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAprobar = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecDoc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtDscto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtFactor = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtObservacion = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.dgDetalle = New System.Windows.Forms.DataGridView()
        Me.cIdMovimientoDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMer1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCanMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPreMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDscMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalFila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPreMerSug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDsctoSug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTipDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cListaPrecio = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUtilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPorcentajeUtilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miFactor_Dscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtTipCam = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtUtilidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalCosto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAprobar, Me.btnImprimir, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1110, 31)
        Me.ToolStrip1.TabIndex = 49
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAprobar
        '
        Me.btnAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAprobar.Image = CType(resources.GetObject("btnAprobar.Image"), System.Drawing.Image)
        Me.btnAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(28, 28)
        Me.btnAprobar.Text = "ToolStripButton1"
        Me.btnAprobar.ToolTipText = "Aprobar/Rechazar"
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(28, 28)
        Me.btnImprimir.Text = "ToolStripButton1"
        Me.btnImprimir.ToolTipText = "Imprimir"
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(28, 28)
        Me.btnSalir.Text = "ToolStripButton1"
        Me.btnSalir.ToolTipText = "Salir de la Ventana"
        '
        'txtMoneda
        '
        Me.txtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.Location = New System.Drawing.Point(417, 38)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(89, 20)
        Me.txtMoneda.TabIndex = 47
        '
        'txtOrden
        '
        Me.txtOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrden.Location = New System.Drawing.Point(632, 68)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.ReadOnly = True
        Me.txtOrden.Size = New System.Drawing.Size(122, 20)
        Me.txtOrden.TabIndex = 45
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(351, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Moneda :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(549, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Nro. Orden :"
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(76, 62)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(430, 20)
        Me.txtCliente.TabIndex = 43
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Cliente :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(542, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Tipo Cambio :"
        '
        'txtFecDoc
        '
        Me.txtFecDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecDoc.Location = New System.Drawing.Point(243, 38)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.ReadOnly = True
        Me.txtFecDoc.Size = New System.Drawing.Size(86, 20)
        Me.txtFecDoc.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(187, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Fecha :"
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(76, 38)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(91, 20)
        Me.txtNumero.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Numero :"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtDscto)
        Me.UiGroupBox1.Controls.Add(Me.txtFactor)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(15, 86)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(491, 87)
        Me.UiGroupBox1.TabIndex = 55
        Me.UiGroupBox1.Text = "Sugerido"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtDscto
        '
        Me.txtDscto.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDscto.Location = New System.Drawing.Point(184, 14)
        Me.txtDscto.Name = "txtDscto"
        Me.txtDscto.ReadOnly = True
        Me.txtDscto.Size = New System.Drawing.Size(54, 20)
        Me.txtDscto.TabIndex = 4
        Me.txtDscto.Text = "0.00"
        Me.txtDscto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtFactor
        '
        Me.txtFactor.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFactor.Location = New System.Drawing.Point(55, 14)
        Me.txtFactor.Name = "txtFactor"
        Me.txtFactor.ReadOnly = True
        Me.txtFactor.Size = New System.Drawing.Size(51, 20)
        Me.txtFactor.TabIndex = 3
        Me.txtFactor.Text = "0.00"
        Me.txtFactor.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(7, 37)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.Size = New System.Drawing.Size(476, 45)
        Me.txtObservacion.TabIndex = 2
        Me.txtObservacion.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(138, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Dscto :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Factor :"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.Location = New System.Drawing.Point(226, 8)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(61, 13)
        Me.lblVendedor.TabIndex = 56
        Me.lblVendedor.Text = "Vendedor"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(551, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Usuario:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtUsuario
        '
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(611, 97)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(143, 20)
        Me.txtUsuario.TabIndex = 58
        '
        'dgDetalle
        '
        Me.dgDetalle.AllowUserToAddRows = False
        Me.dgDetalle.AllowUserToDeleteRows = False
        Me.dgDetalle.AllowUserToResizeRows = False
        Me.dgDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdMovimientoDet, Me.cCodMer, Me.cDesMer1, Me.cCanMer, Me.cPreMer, Me.cDscMer, Me.cTotalFila, Me.cPreMerSug, Me.cDsctoSug, Me.cTipDoc, Me.cListaPrecio, Me.cProveedor, Me.cCosto, Me.cUtilidad, Me.cPorcentajeUtilidad})
        Me.dgDetalle.Location = New System.Drawing.Point(0, 179)
        Me.dgDetalle.MultiSelect = False
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.RowHeadersWidth = 5
        Me.dgDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgDetalle.Size = New System.Drawing.Size(1090, 459)
        Me.dgDetalle.TabIndex = 59
        '
        'cIdMovimientoDet
        '
        Me.cIdMovimientoDet.HeaderText = "IdMovimiento"
        Me.cIdMovimientoDet.Name = "cIdMovimientoDet"
        Me.cIdMovimientoDet.Visible = False
        '
        'cCodMer
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodMer.DefaultCellStyle = DataGridViewCellStyle2
        Me.cCodMer.HeaderText = "Codigo"
        Me.cCodMer.Name = "cCodMer"
        Me.cCodMer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cCodMer.Width = 80
        '
        'cDesMer1
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cDesMer1.DefaultCellStyle = DataGridViewCellStyle3
        Me.cDesMer1.HeaderText = "Descripción"
        Me.cDesMer1.Name = "cDesMer1"
        Me.cDesMer1.ReadOnly = True
        Me.cDesMer1.Width = 158
        '
        'cCanMer
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCanMer.DefaultCellStyle = DataGridViewCellStyle4
        Me.cCanMer.HeaderText = "Cant."
        Me.cCanMer.Name = "cCanMer"
        Me.cCanMer.ReadOnly = True
        Me.cCanMer.Width = 40
        '
        'cPreMer
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.cPreMer.DefaultCellStyle = DataGridViewCellStyle5
        Me.cPreMer.HeaderText = "Precio"
        Me.cPreMer.Name = "cPreMer"
        Me.cPreMer.Width = 70
        '
        'cDscMer
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.cDscMer.DefaultCellStyle = DataGridViewCellStyle6
        Me.cDscMer.HeaderText = "Dscto"
        Me.cDscMer.Name = "cDscMer"
        Me.cDscMer.Width = 70
        '
        'cTotalFila
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.cTotalFila.DefaultCellStyle = DataGridViewCellStyle7
        Me.cTotalFila.HeaderText = "Total"
        Me.cTotalFila.Name = "cTotalFila"
        Me.cTotalFila.ReadOnly = True
        Me.cTotalFila.Width = 80
        '
        'cPreMerSug
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.cPreMerSug.DefaultCellStyle = DataGridViewCellStyle8
        Me.cPreMerSug.FillWeight = 90.0!
        Me.cPreMerSug.HeaderText = "Precio Sug."
        Me.cPreMerSug.Name = "cPreMerSug"
        Me.cPreMerSug.ReadOnly = True
        Me.cPreMerSug.Width = 80
        '
        'cDsctoSug
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.cDsctoSug.DefaultCellStyle = DataGridViewCellStyle9
        Me.cDsctoSug.HeaderText = "Dscto Sug"
        Me.cDsctoSug.Name = "cDsctoSug"
        Me.cDsctoSug.Width = 80
        '
        'cTipDoc
        '
        Me.cTipDoc.HeaderText = "TipDoc"
        Me.cTipDoc.Name = "cTipDoc"
        Me.cTipDoc.Visible = False
        '
        'cListaPrecio
        '
        Me.cListaPrecio.HeaderText = "Lista Precio"
        Me.cListaPrecio.Name = "cListaPrecio"
        Me.cListaPrecio.ToolTipText = "Lista Precio Cliente"
        Me.cListaPrecio.Width = 80
        '
        'cProveedor
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cProveedor.DefaultCellStyle = DataGridViewCellStyle10
        Me.cProveedor.HeaderText = "Proveedor"
        Me.cProveedor.Name = "cProveedor"
        Me.cProveedor.Visible = False
        Me.cProveedor.Width = 105
        '
        'cCosto
        '
        Me.cCosto.HeaderText = "Costo"
        Me.cCosto.Name = "cCosto"
        '
        'cUtilidad
        '
        Me.cUtilidad.HeaderText = "Utilidad"
        Me.cUtilidad.Name = "cUtilidad"
        '
        'cPorcentajeUtilidad
        '
        Me.cPorcentajeUtilidad.HeaderText = "Porc. Utilidad%"
        Me.cPorcentajeUtilidad.Name = "cPorcentajeUtilidad"
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFactor_Dscto, Me.ToolStripMenuItem1})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(143, 32)
        '
        'miFactor_Dscto
        '
        Me.miFactor_Dscto.Image = Global.SIGECOM.My.Resources.Resources.Dscto
        Me.miFactor_Dscto.Name = "miFactor_Dscto"
        Me.miFactor_Dscto.Size = New System.Drawing.Size(142, 22)
        Me.miFactor_Dscto.Text = "Factor/Dscto"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(139, 6)
        '
        'txtTipCam
        '
        Me.txtTipCam.BackColor = System.Drawing.SystemColors.Control
        Me.txtTipCam.DecimalDigits = 3
        Me.txtTipCam.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTipCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCam.Location = New System.Drawing.Point(633, 42)
        Me.txtTipCam.Name = "txtTipCam"
        Me.txtTipCam.ReadOnly = True
        Me.txtTipCam.Size = New System.Drawing.Size(54, 20)
        Me.txtTipCam.TabIndex = 60
        Me.txtTipCam.Text = "0.000"
        Me.txtTipCam.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(549, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 13)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "Motivo : "
        '
        'txtMotivo
        '
        Me.txtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivo.Location = New System.Drawing.Point(611, 123)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ReadOnly = True
        Me.txtMotivo.Size = New System.Drawing.Size(182, 20)
        Me.txtMotivo.TabIndex = 62
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtUtilidad)
        Me.UiGroupBox6.Controls.Add(Me.Label13)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalCosto)
        Me.UiGroupBox6.Controls.Add(Me.Label12)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalSug)
        Me.UiGroupBox6.Controls.Add(Me.Label5)
        Me.UiGroupBox6.Controls.Add(Me.Label7)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalNeto)
        Me.UiGroupBox6.Location = New System.Drawing.Point(15, 644)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(1038, 42)
        Me.UiGroupBox6.TabIndex = 63
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtUtilidad
        '
        Me.txtUtilidad.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtUtilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUtilidad.Location = New System.Drawing.Point(824, 14)
        Me.txtUtilidad.Name = "txtUtilidad"
        Me.txtUtilidad.ReadOnly = True
        Me.txtUtilidad.Size = New System.Drawing.Size(107, 20)
        Me.txtUtilidad.TabIndex = 57
        Me.txtUtilidad.Text = "0.00"
        Me.txtUtilidad.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(762, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "Utilidad :"
        '
        'txtTotalCosto
        '
        Me.txtTotalCosto.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCosto.Location = New System.Drawing.Point(602, 14)
        Me.txtTotalCosto.Name = "txtTotalCosto"
        Me.txtTotalCosto.ReadOnly = True
        Me.txtTotalCosto.Size = New System.Drawing.Size(107, 20)
        Me.txtTotalCosto.TabIndex = 55
        Me.txtTotalCosto.Text = "0.00"
        Me.txtTotalCosto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(516, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 13)
        Me.Label12.TabIndex = 56
        Me.Label12.Text = "Total Costo :"
        '
        'txtTotalSug
        '
        Me.txtTotalSug.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSug.Location = New System.Drawing.Point(375, 14)
        Me.txtTotalSug.Name = "txtTotalSug"
        Me.txtTotalSug.ReadOnly = True
        Me.txtTotalSug.Size = New System.Drawing.Size(107, 20)
        Me.txtTotalSug.TabIndex = 51
        Me.txtTotalSug.Text = "0.00"
        Me.txtTotalSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Total Venta :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(271, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Total Sugerido :"
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.Location = New System.Drawing.Point(127, 14)
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalNeto.TabIndex = 52
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'frmAprobacionDetalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1110, 706)
        Me.ContextMenuStrip = Me.cmOpciones
        Me.ControlBox = False
        Me.Controls.Add(Me.txtMotivo)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTipCam)
        Me.Controls.Add(Me.dgDetalle)
        Me.Controls.Add(Me.lblVendedor)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtMoneda)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFecDoc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAprobacionDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documento de Venta"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAprobar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFecDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtDscto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtFactor As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtObservacion As System.Windows.Forms.RichTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miFactor_Dscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtTipCam As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalCosto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtUtilidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cIdMovimientoDet As DataGridViewTextBoxColumn
    Friend WithEvents cCodMer As DataGridViewTextBoxColumn
    Friend WithEvents cDesMer1 As DataGridViewTextBoxColumn
    Friend WithEvents cCanMer As DataGridViewTextBoxColumn
    Friend WithEvents cPreMer As DataGridViewTextBoxColumn
    Friend WithEvents cDscMer As DataGridViewTextBoxColumn
    Friend WithEvents cTotalFila As DataGridViewTextBoxColumn
    Friend WithEvents cPreMerSug As DataGridViewTextBoxColumn
    Friend WithEvents cDsctoSug As DataGridViewTextBoxColumn
    Friend WithEvents cTipDoc As DataGridViewTextBoxColumn
    Friend WithEvents cListaPrecio As DataGridViewCheckBoxColumn
    Friend WithEvents cProveedor As DataGridViewTextBoxColumn
    Friend WithEvents cCosto As DataGridViewTextBoxColumn
    Friend WithEvents cUtilidad As DataGridViewTextBoxColumn
    Friend WithEvents cPorcentajeUtilidad As DataGridViewTextBoxColumn
End Class
