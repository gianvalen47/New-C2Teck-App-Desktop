<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOportunidadNegocio_Gastos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOportunidadNegocio_Gastos))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTipoProducto = New System.Windows.Forms.TextBox()
        Me.gbEtapa = New System.Windows.Forms.GroupBox()
        Me.lblEtapa = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtFecProbable = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecCierre = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtIdOportunidad = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblUtilidad = New System.Windows.Forms.TextBox()
        Me.lbltotalGasto = New System.Windows.Forms.TextBox()
        Me.lblTotalVenta = New System.Windows.Forms.TextBox()
        Me.txtUtilidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalGastos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevoMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEtapa.SuspendLayout()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.cmbCodMon)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtMonto)
        Me.UiGroupBox2.Controls.Add(Me.txtVendedor)
        Me.UiGroupBox2.Controls.Add(Me.txtDescripcion)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtTipoProducto)
        Me.UiGroupBox2.Controls.Add(Me.gbEtapa)
        Me.UiGroupBox2.Controls.Add(Me.txtNombre)
        Me.UiGroupBox2.Controls.Add(Me.Label19)
        Me.UiGroupBox2.Controls.Add(Me.Label6)
        Me.UiGroupBox2.Controls.Add(Me.Label12)
        Me.UiGroupBox2.Controls.Add(Me.txtCliente)
        Me.UiGroupBox2.Controls.Add(Me.txtFecProbable)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.lblFecha)
        Me.UiGroupBox2.Controls.Add(Me.txtFecCierre)
        Me.UiGroupBox2.Controls.Add(Me.txtIdOportunidad)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.Label21)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(12, 28)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(978, 186)
        Me.UiGroupBox2.TabIndex = 185
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cmbCodMon
        '
        Me.cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(727, 111)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.ReadOnly = True
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(48, 20)
        Me.cmbCodMon.TabIndex = 269
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(675, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 270
        Me.Label9.Text = "Moneda"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(646, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 266
        Me.Label8.Text = "Monto Total"
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.SystemColors.Control
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(727, 138)
        Me.txtMonto.MaxLength = 10
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(95, 20)
        Me.txtMonto.TabIndex = 9
        Me.txtMonto.TabStop = False
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtVendedor
        '
        Me.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtVendedor.Location = New System.Drawing.Point(96, 112)
        Me.txtVendedor.MaxLength = 20
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(215, 20)
        Me.txtVendedor.TabIndex = 6
        Me.txtVendedor.TabStop = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(96, 139)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(510, 32)
        Me.txtDescripcion.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 199
        Me.Label3.Text = "Vendedor"
        '
        'txtTipoProducto
        '
        Me.txtTipoProducto.Location = New System.Drawing.Point(414, 112)
        Me.txtTipoProducto.Name = "txtTipoProducto"
        Me.txtTipoProducto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTipoProducto.Size = New System.Drawing.Size(192, 20)
        Me.txtTipoProducto.TabIndex = 8
        '
        'gbEtapa
        '
        Me.gbEtapa.BackColor = System.Drawing.Color.Transparent
        Me.gbEtapa.Controls.Add(Me.lblEtapa)
        Me.gbEtapa.Location = New System.Drawing.Point(259, 10)
        Me.gbEtapa.Name = "gbEtapa"
        Me.gbEtapa.Size = New System.Drawing.Size(347, 40)
        Me.gbEtapa.TabIndex = 196
        Me.gbEtapa.TabStop = False
        '
        'lblEtapa
        '
        Me.lblEtapa.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEtapa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtapa.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEtapa.Location = New System.Drawing.Point(6, 11)
        Me.lblEtapa.Name = "lblEtapa"
        Me.lblEtapa.Size = New System.Drawing.Size(335, 23)
        Me.lblEtapa.TabIndex = 0
        Me.lblEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(96, 58)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNombre.Size = New System.Drawing.Size(510, 20)
        Me.txtNombre.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 61)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 195
        Me.Label19.Text = "Nombre"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(318, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tipo Producto"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Control
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtCliente.Location = New System.Drawing.Point(96, 85)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(510, 20)
        Me.txtCliente.TabIndex = 3
        '
        'txtFecProbable
        '
        '
        '
        '
        Me.txtFecProbable.DropDownCalendar.Name = ""
        Me.txtFecProbable.DropDownCalendar.Visible = False
        Me.txtFecProbable.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecProbable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecProbable.Location = New System.Drawing.Point(727, 57)
        Me.txtFecProbable.Name = "txtFecProbable"
        Me.txtFecProbable.NullButtonText = "Ninguno"
        Me.txtFecProbable.Size = New System.Drawing.Size(95, 20)
        Me.txtFecProbable.TabIndex = 5
        Me.txtFecProbable.TodayButtonText = "Hoy"
        Me.txtFecProbable.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(635, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fec. Probable"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(652, 88)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(69, 13)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "Fec. Cierre"
        '
        'txtFecCierre
        '
        '
        '
        '
        Me.txtFecCierre.DropDownCalendar.Name = ""
        Me.txtFecCierre.DropDownCalendar.Visible = False
        Me.txtFecCierre.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecCierre.Location = New System.Drawing.Point(727, 85)
        Me.txtFecCierre.Name = "txtFecCierre"
        Me.txtFecCierre.NullButtonText = "Ninguno"
        Me.txtFecCierre.Size = New System.Drawing.Size(95, 20)
        Me.txtFecCierre.TabIndex = 7
        Me.txtFecCierre.TodayButtonText = "Hoy"
        Me.txtFecCierre.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtIdOportunidad
        '
        Me.txtIdOportunidad.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdOportunidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdOportunidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdOportunidad.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdOportunidad.Location = New System.Drawing.Point(96, 30)
        Me.txtIdOportunidad.MaxLength = 20
        Me.txtIdOportunidad.Name = "txtIdOportunidad"
        Me.txtIdOportunidad.ReadOnly = True
        Me.txtIdOportunidad.Size = New System.Drawing.Size(112, 20)
        Me.txtIdOportunidad.TabIndex = 1
        Me.txtIdOportunidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 148)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Descripción"
        '
        'gbDetalle
        '
        Me.gbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalle.Controls.Add(Me.UiGroupBox6)
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(12, 220)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(986, 363)
        Me.gbDetalle.TabIndex = 186
        Me.gbDetalle.Text = "Gastos"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.lblUtilidad)
        Me.UiGroupBox6.Controls.Add(Me.lbltotalGasto)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalVenta)
        Me.UiGroupBox6.Controls.Add(Me.txtUtilidad)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalGastos)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalMonto)
        Me.UiGroupBox6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox6.Location = New System.Drawing.Point(3, 281)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(980, 79)
        Me.UiGroupBox6.TabIndex = 221
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblUtilidad
        '
        Me.lblUtilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblUtilidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblUtilidad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblUtilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUtilidad.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblUtilidad.Location = New System.Drawing.Point(6, 49)
        Me.lblUtilidad.MaxLength = 20
        Me.lblUtilidad.Name = "lblUtilidad"
        Me.lblUtilidad.ReadOnly = True
        Me.lblUtilidad.Size = New System.Drawing.Size(844, 20)
        Me.lblUtilidad.TabIndex = 10
        Me.lblUtilidad.TabStop = False
        Me.lblUtilidad.Text = "UTILIDAD :"
        Me.lblUtilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotalGasto
        '
        Me.lbltotalGasto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lbltotalGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lbltotalGasto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lbltotalGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalGasto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltotalGasto.Location = New System.Drawing.Point(6, 30)
        Me.lbltotalGasto.MaxLength = 20
        Me.lbltotalGasto.Name = "lbltotalGasto"
        Me.lbltotalGasto.ReadOnly = True
        Me.lbltotalGasto.Size = New System.Drawing.Size(844, 20)
        Me.lbltotalGasto.TabIndex = 9
        Me.lbltotalGasto.TabStop = False
        Me.lbltotalGasto.Text = "TOTAL GASTOS :"
        Me.lbltotalGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalVenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalVenta.Location = New System.Drawing.Point(6, 11)
        Me.lblTotalVenta.MaxLength = 20
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.ReadOnly = True
        Me.lblTotalVenta.Size = New System.Drawing.Size(844, 20)
        Me.lblTotalVenta.TabIndex = 8
        Me.lblTotalVenta.TabStop = False
        Me.lblTotalVenta.Text = "TOTAL VENTA :"
        Me.lblTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUtilidad
        '
        Me.txtUtilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtUtilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUtilidad.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtUtilidad.Location = New System.Drawing.Point(848, 49)
        Me.txtUtilidad.MaxLength = 5
        Me.txtUtilidad.Name = "txtUtilidad"
        Me.txtUtilidad.ReadOnly = True
        Me.txtUtilidad.Size = New System.Drawing.Size(90, 20)
        Me.txtUtilidad.TabIndex = 6
        Me.txtUtilidad.TabStop = False
        Me.txtUtilidad.Text = "0.00"
        Me.txtUtilidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtUtilidad.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtUtilidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalGastos
        '
        Me.txtTotalGastos.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalGastos.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalGastos.Location = New System.Drawing.Point(848, 30)
        Me.txtTotalGastos.MaxLength = 5
        Me.txtTotalGastos.Name = "txtTotalGastos"
        Me.txtTotalGastos.ReadOnly = True
        Me.txtTotalGastos.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalGastos.TabIndex = 5
        Me.txtTotalGastos.TabStop = False
        Me.txtTotalGastos.Text = "0.00"
        Me.txtTotalGastos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalGastos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalGastos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalMonto
        '
        Me.txtTotalMonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMonto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalMonto.Location = New System.Drawing.Point(848, 11)
        Me.txtTotalMonto.MaxLength = 5
        Me.txtTotalMonto.Name = "txtTotalMonto"
        Me.txtTotalMonto.ReadOnly = True
        Me.txtTotalMonto.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalMonto.TabIndex = 3
        Me.txtTotalMonto.TabStop = False
        Me.txtTotalMonto.Text = "0.00"
        Me.txtTotalMonto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalMonto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 18)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(974, 257)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miNuevoMasivo, Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(155, 126)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(154, 22)
        Me.miNuevo.Text = "Ingreso"
        Me.miNuevo.ToolTipText = "Ingreso Gasto"
        '
        'miNuevoMasivo
        '
        Me.miNuevoMasivo.Image = CType(resources.GetObject("miNuevoMasivo.Image"), System.Drawing.Image)
        Me.miNuevoMasivo.Name = "miNuevoMasivo"
        Me.miNuevoMasivo.Size = New System.Drawing.Size(154, 22)
        Me.miNuevoMasivo.Text = "Ingreso Masivo"
        Me.miNuevoMasivo.ToolTipText = "Ingreso Gasto Masivo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(154, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Gasto"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(154, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Gasto"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(151, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(151, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(154, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 603)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(1021, 20)
        Me.ssBarra.TabIndex = 188
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(300, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1021, 31)
        Me.ToolStrip.TabIndex = 237
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'frmOportunidadNegocio_Gastos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1021, 623)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOportunidadNegocio_Gastos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Proyecto y/o Oportunidad de Negocio - Gastos"
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEtapa.ResumeLayout(False)
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTipoProducto As TextBox
    Friend WithEvents gbEtapa As GroupBox
    Friend WithEvents lblEtapa As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents txtFecProbable As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label5 As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents txtFecCierre As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtIdOportunidad As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miNuevo As ToolStripMenuItem
    Friend WithEvents miMostrar As ToolStripMenuItem
    Friend WithEvents miEliminar As ToolStripMenuItem
    Friend WithEvents miSeparador1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents miActualizar As ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As StatusStrip
    Friend WithEvents sslError As ToolStripStatusLabel
    Friend WithEvents sslTotal As ToolStripStatusLabel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents miNuevoMasivo As ToolStripMenuItem
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents biSalir As ToolStripButton
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As Label
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblUtilidad As TextBox
    Friend WithEvents lbltotalGasto As TextBox
    Friend WithEvents lblTotalVenta As TextBox
    Friend WithEvents txtUtilidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalGastos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
