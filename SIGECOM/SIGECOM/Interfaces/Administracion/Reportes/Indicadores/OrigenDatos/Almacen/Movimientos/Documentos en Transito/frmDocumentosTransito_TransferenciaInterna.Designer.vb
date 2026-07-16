<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferenciasInterna
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
        Me.components = New System.ComponentModel.Container
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferenciasInterna))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.dgvPrueba = New System.Windows.Forms.DataGridView
        Me.cmOpcionesAtender = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodo = New System.Windows.Forms.ToolStripMenuItem
        Me.miSeterCEROTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblJOb = New System.Windows.Forms.Label
        Me.lblFecha = New System.Windows.Forms.Label
        Me.lblMoneda = New System.Windows.Forms.Label
        Me.lblCliente = New System.Windows.Forms.Label
        Me.lblAlmacen = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNumDoc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.txtTotalPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotalDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lblTotal = New System.Windows.Forms.TextBox
        Me.gbTotal = New System.Windows.Forms.GroupBox
        Me.txtObservacion = New System.Windows.Forms.TextBox
        Me.txtFecIng = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.txtUsuRec = New System.Windows.Forms.TextBox
        Me.lblRecibidoPor = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RadToolStripItem1 = New Telerik.WinControls.UI.RadToolStripItem
        Me.btnGrabar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripElement1 = New Telerik.WinControls.UI.RadToolStripElement
        Me.RadToolStripItem2 = New Telerik.WinControls.UI.RadToolStripItem
        Me.RadButtonElement1 = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripItem3 = New Telerik.WinControls.UI.RadToolStripItem
        Me.biEditar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripItem4 = New Telerik.WinControls.UI.RadToolStripItem
        Me.biDeshacer = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripElement2 = New Telerik.WinControls.UI.RadToolStripElement
        Me.RadToolStrip1 = New Telerik.WinControls.UI.RadToolStrip
        Me.RadToolStripElement3 = New Telerik.WinControls.UI.RadToolStripElement
        Me.RadToolStripItem5 = New Telerik.WinControls.UI.RadToolStripItem
        Me.btnEditar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem1 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.btnGuardar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem3 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.btnDeshacer = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem5 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.btnTrasladar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem2 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.btnSalir = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem4 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.RadButtonElement10 = New Telerik.WinControls.UI.RadButtonElement
        Me.RadButtonElement15 = New Telerik.WinControls.UI.RadButtonElement
        Me.IdTransitoDet = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodMer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DesMer1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CanMer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CanRec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PreMer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DscMer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalFila = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdTransito1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdTransferencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdTransferenciaDet = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.dgvPrueba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesAtender.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.gbTotal.SuspendLayout()
        CType(Me.RadToolStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.dgvPrueba)
        Me.gbDatos.Controls.Add(Me.ssBarra)
        Me.gbDatos.Controls.Add(Me.dgvDatos)
        Me.gbDatos.Controls.Add(Me.Label14)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.lblJOb)
        Me.gbDatos.Controls.Add(Me.lblFecha)
        Me.gbDatos.Controls.Add(Me.lblMoneda)
        Me.gbDatos.Controls.Add(Me.lblCliente)
        Me.gbDatos.Controls.Add(Me.lblAlmacen)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.txtNumDoc)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.Label12)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label15)
        Me.gbDatos.Controls.Add(Me.UiGroupBox1)
        Me.gbDatos.Controls.Add(Me.gbTotal)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(1, 51)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(713, 418)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Documento"
        '
        'dgvPrueba
        '
        Me.dgvPrueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrueba.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTransitoDet, Me.CodMer, Me.DesMer1, Me.CanMer, Me.CanRec, Me.PreMer, Me.DscMer, Me.TotalFila, Me.IdTransito1, Me.IdTransferencia, Me.IdTransferenciaDet})
        Me.dgvPrueba.ContextMenuStrip = Me.cmOpcionesAtender
        Me.dgvPrueba.Location = New System.Drawing.Point(14, 127)
        Me.dgvPrueba.Name = "dgvPrueba"
        Me.dgvPrueba.Size = New System.Drawing.Size(684, 221)
        Me.dgvPrueba.TabIndex = 23
        '
        'cmOpcionesAtender
        '
        Me.cmOpcionesAtender.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodo, Me.miSeterCEROTodos, Me.miActualizar})
        Me.cmOpcionesAtender.Name = "cmOpciones"
        Me.cmOpcionesAtender.Size = New System.Drawing.Size(176, 70)
        '
        'miSeleccionarTodo
        '
        Me.miSeleccionarTodo.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miSeleccionarTodo.Name = "miSeleccionarTodo"
        Me.miSeleccionarTodo.Size = New System.Drawing.Size(175, 22)
        Me.miSeleccionarTodo.Text = "Seleccionar Todos"
        '
        'miSeterCEROTodos
        '
        Me.miSeterCEROTodos.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miSeterCEROTodos.Name = "miSeterCEROTodos"
        Me.miSeterCEROTodos.Size = New System.Drawing.Size(175, 22)
        Me.miSeterCEROTodos.Text = "Poner en ""0"" todos"
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(175, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(3, 390)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(707, 25)
        Me.ssBarra.TabIndex = 22
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(550, 20)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 16)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpcionesAtender
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(664, 18)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(34, 31)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.Visible = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label14.Location = New System.Drawing.Point(337, 36)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label7.Location = New System.Drawing.Point(457, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = ":"
        '
        'lblJOb
        '
        Me.lblJOb.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblJOb.Location = New System.Drawing.Point(66, 36)
        Me.lblJOb.Name = "lblJOb"
        Me.lblJOb.Size = New System.Drawing.Size(48, 13)
        Me.lblJOb.TabIndex = 12
        Me.lblJOb.Text = "......"
        '
        'lblFecha
        '
        Me.lblFecha.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblFecha.Location = New System.Drawing.Point(213, 17)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(77, 14)
        Me.lblFecha.TabIndex = 6
        Me.lblFecha.Text = "......"
        '
        'lblMoneda
        '
        Me.lblMoneda.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblMoneda.Location = New System.Drawing.Point(348, 17)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(65, 14)
        Me.lblMoneda.TabIndex = 13
        Me.lblMoneda.Text = "......"
        '
        'lblCliente
        '
        Me.lblCliente.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblCliente.Location = New System.Drawing.Point(468, 18)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(237, 13)
        Me.lblCliente.TabIndex = 19
        Me.lblCliente.Text = "......"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblAlmacen.Location = New System.Drawing.Point(349, 36)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(321, 13)
        Me.lblAlmacen.TabIndex = 16
        Me.lblAlmacen.Text = "......"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(7, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "# Job    :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Location = New System.Drawing.Point(286, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Almacén"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(65, 15)
        Me.txtNumDoc.MaxLength = 200
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(89, 20)
        Me.txtNumDoc.TabIndex = 4
        Me.txtNumDoc.TabStop = False
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(286, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Moneda :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label12.Location = New System.Drawing.Point(411, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Número"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label15.Location = New System.Drawing.Point(163, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Fecha :"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPrecio)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDescuento)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalNeto)
        Me.UiGroupBox1.Controls.Add(Me.lblTotal)
        Me.UiGroupBox1.Location = New System.Drawing.Point(14, 354)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(684, 33)
        Me.UiGroupBox1.TabIndex = 2
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalPrecio
        '
        Me.txtTotalPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrecio.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalPrecio.Location = New System.Drawing.Point(428, 8)
        Me.txtTotalPrecio.MaxLength = 5
        Me.txtTotalPrecio.Name = "txtTotalPrecio"
        Me.txtTotalPrecio.ReadOnly = True
        Me.txtTotalPrecio.Size = New System.Drawing.Size(81, 20)
        Me.txtTotalPrecio.TabIndex = 10
        Me.txtTotalPrecio.TabStop = False
        Me.txtTotalPrecio.Text = "0.00"
        Me.txtTotalPrecio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalPrecio.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDescuento.Location = New System.Drawing.Point(508, 8)
        Me.txtTotalDescuento.MaxLength = 5
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(61, 20)
        Me.txtTotalDescuento.TabIndex = 11
        Me.txtTotalDescuento.TabStop = False
        Me.txtTotalDescuento.Text = "0.00"
        Me.txtTotalDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalDescuento.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNeto.Location = New System.Drawing.Point(568, 8)
        Me.txtTotalNeto.MaxLength = 5
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(97, 20)
        Me.txtTotalNeto.TabIndex = 12
        Me.txtTotalNeto.TabStop = False
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotal.Location = New System.Drawing.Point(13, 8)
        Me.lblTotal.MaxLength = 20
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.ReadOnly = True
        Me.lblTotal.Size = New System.Drawing.Size(416, 20)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.TabStop = False
        Me.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbTotal
        '
        Me.gbTotal.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbTotal.Controls.Add(Me.txtObservacion)
        Me.gbTotal.Controls.Add(Me.txtFecIng)
        Me.gbTotal.Controls.Add(Me.txtUsuRec)
        Me.gbTotal.Controls.Add(Me.lblRecibidoPor)
        Me.gbTotal.Controls.Add(Me.Label18)
        Me.gbTotal.Controls.Add(Me.Label21)
        Me.gbTotal.Location = New System.Drawing.Point(7, 55)
        Me.gbTotal.Name = "gbTotal"
        Me.gbTotal.Size = New System.Drawing.Size(698, 66)
        Me.gbTotal.TabIndex = 0
        Me.gbTotal.TabStop = False
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(80, 31)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(612, 33)
        Me.txtObservacion.TabIndex = 2
        '
        'txtFecIng
        '
        '
        '
        '
        Me.txtFecIng.DropDownCalendar.Name = ""
        Me.txtFecIng.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIng.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free
        Me.txtFecIng.Location = New System.Drawing.Point(80, 9)
        Me.txtFecIng.Name = "txtFecIng"
        Me.txtFecIng.NullButtonText = "Ninguno"
        Me.txtFecIng.Size = New System.Drawing.Size(86, 20)
        Me.txtFecIng.TabIndex = 0
        Me.txtFecIng.TodayButtonText = "Hoy"
        Me.txtFecIng.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtUsuRec
        '
        Me.txtUsuRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuRec.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtUsuRec.Location = New System.Drawing.Point(322, 9)
        Me.txtUsuRec.MaxLength = 50
        Me.txtUsuRec.Name = "txtUsuRec"
        Me.txtUsuRec.Size = New System.Drawing.Size(370, 20)
        Me.txtUsuRec.TabIndex = 1
        '
        'lblRecibidoPor
        '
        Me.lblRecibidoPor.AutoSize = True
        Me.lblRecibidoPor.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblRecibidoPor.Location = New System.Drawing.Point(236, 13)
        Me.lblRecibidoPor.Name = "lblRecibidoPor"
        Me.lblRecibidoPor.Size = New System.Drawing.Size(80, 13)
        Me.lblRecibidoPor.TabIndex = 6
        Me.lblRecibidoPor.Text = "Recibido Por"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label18.Location = New System.Drawing.Point(17, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Fecha"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label21.Location = New System.Drawing.Point(1, 38)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Observación"
        '
        'Timer1
        '
        '
        'RadToolStripItem1
        '
        Me.RadToolStripItem1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnGrabar})
        Me.RadToolStripItem1.Key = "0"
        Me.RadToolStripItem1.Name = "RadToolStripItem1"
        Me.RadToolStripItem1.Text = "RadToolStripItem1"
        '
        'btnGrabar
        '
        Me.btnGrabar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Text = "RadButtonElement1"
        '
        'RadToolStripElement1
        '
        Me.RadToolStripElement1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadToolStripItem1})
        Me.RadToolStripElement1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.RadToolStripElement1.Name = "RadToolStripElement1"
        Me.RadToolStripElement1.Text = "RadToolStripElement1"
        '
        'RadToolStripItem2
        '
        Me.RadToolStripItem2.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadButtonElement1})
        Me.RadToolStripItem2.Key = "0"
        Me.RadToolStripItem2.Name = "RadToolStripItem2"
        Me.RadToolStripItem2.Text = "RadToolStripItem2"
        '
        'RadButtonElement1
        '
        Me.RadButtonElement1.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadButtonElement1.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.RadButtonElement1.Name = "RadButtonElement1"
        '
        'RadToolStripItem3
        '
        Me.RadToolStripItem3.Items.AddRange(New Telerik.WinControls.RadItem() {Me.biEditar})
        Me.RadToolStripItem3.Key = "1"
        Me.RadToolStripItem3.Name = "RadToolStripItem3"
        Me.RadToolStripItem3.Text = "RadToolStripItem3"
        '
        'biEditar
        '
        Me.biEditar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.Name = "biEditar"
        '
        'RadToolStripItem4
        '
        Me.RadToolStripItem4.Items.AddRange(New Telerik.WinControls.RadItem() {Me.biDeshacer})
        Me.RadToolStripItem4.Key = "2"
        Me.RadToolStripItem4.Name = "RadToolStripItem4"
        Me.RadToolStripItem4.Text = "RadToolStripItem4"
        '
        'biDeshacer
        '
        Me.biDeshacer.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.Name = "biDeshacer"
        '
        'RadToolStripElement2
        '
        Me.RadToolStripElement2.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadToolStripItem2, Me.RadToolStripItem3, Me.RadToolStripItem4})
        Me.RadToolStripElement2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.RadToolStripElement2.Name = "RadToolStripElement2"
        '
        'RadToolStrip1
        '
        Me.RadToolStrip1.AllowDragging = False
        Me.RadToolStrip1.AllowFloating = False
        Me.RadToolStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadToolStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadToolStripElement3})
        Me.RadToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.RadToolStrip1.MinimumSize = New System.Drawing.Size(5, 5)
        Me.RadToolStrip1.Name = "RadToolStrip1"
        Me.RadToolStrip1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        '
        '
        Me.RadToolStrip1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.RadToolStrip1.RootElement.MinSize = New System.Drawing.Size(5, 5)
        Me.RadToolStrip1.ShowOverFlowButton = True
        Me.RadToolStrip1.Size = New System.Drawing.Size(714, 45)
        Me.RadToolStrip1.TabIndex = 1
        Me.RadToolStrip1.Text = "RadToolStrip1"
        '
        'RadToolStripElement3
        '
        Me.RadToolStripElement3.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadToolStripItem5})
        Me.RadToolStripElement3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.RadToolStripElement3.MinSize = New System.Drawing.Size(0, 42)
        Me.RadToolStripElement3.Name = "RadToolStripElement3"
        '
        'RadToolStripItem5
        '
        Me.RadToolStripItem5.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnEditar, Me.RadToolStripSeparatorItem1, Me.btnGuardar, Me.RadToolStripSeparatorItem3, Me.btnDeshacer, Me.RadToolStripSeparatorItem5, Me.btnTrasladar, Me.RadToolStripSeparatorItem2, Me.btnSalir, Me.RadToolStripSeparatorItem4})
        Me.RadToolStripItem5.Key = "0"
        Me.RadToolStripItem5.MinSize = New System.Drawing.Size(714, 42)
        Me.RadToolStripItem5.Name = "RadToolStripItem5"
        Me.RadToolStripItem5.Text = "RadToolStripItem5"
        CType(Me.RadToolStripItem5.GetChildAt(4), Telerik.WinControls.UI.RadToolStripOverFlowButtonElement).Enabled = False
        CType(Me.RadToolStripItem5.GetChildAt(4), Telerik.WinControls.UI.RadToolStripOverFlowButtonElement).Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'btnEditar
        '
        Me.btnEditar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnEditar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.btnEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnEditar.MinSize = New System.Drawing.Size(36, 36)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.ShouldPaint = True
        Me.btnEditar.ShowBorder = False
        Me.btnEditar.Text = "newToolStripButtonItem"
        Me.btnEditar.ToolTipText = "Editar Cabecera"
        CType(Me.btnEditar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.btnEditar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem1
        '
        Me.RadToolStripSeparatorItem1.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RadToolStripSeparatorItem1.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem1.Name = "RadToolStripSeparatorItem1"
        Me.RadToolStripSeparatorItem1.ShouldPaint = True
        Me.RadToolStripSeparatorItem1.Text = "RadToolStripSeparatorItem1"
        '
        'btnGuardar
        '
        Me.btnGuardar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnGuardar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.MinSize = New System.Drawing.Size(36, 36)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.ShouldPaint = True
        Me.btnGuardar.ShowBorder = False
        Me.btnGuardar.Text = "openToolStripButtonItem"
        Me.btnGuardar.ToolTipText = "Guardar Cambios Realizados"
        CType(Me.btnGuardar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.btnGuardar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem3
        '
        Me.RadToolStripSeparatorItem3.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RadToolStripSeparatorItem3.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem3.Name = "RadToolStripSeparatorItem3"
        Me.RadToolStripSeparatorItem3.ShouldPaint = True
        Me.RadToolStripSeparatorItem3.Text = "RadToolStripSeparatorItem3"
        '
        'btnDeshacer
        '
        Me.btnDeshacer.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeshacer.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnDeshacer.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.btnDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnDeshacer.MinSize = New System.Drawing.Size(36, 36)
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.ShouldPaint = True
        Me.btnDeshacer.ShowBorder = False
        Me.btnDeshacer.Text = "saveToolStripButtonItem"
        Me.btnDeshacer.ToolTipText = "Deshacer Cambios Realizados"
        CType(Me.btnDeshacer.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.btnDeshacer.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem5
        '
        Me.RadToolStripSeparatorItem5.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem5.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RadToolStripSeparatorItem5.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem5.Name = "RadToolStripSeparatorItem5"
        Me.RadToolStripSeparatorItem5.ShouldPaint = True
        Me.RadToolStripSeparatorItem5.Text = "RadToolStripSeparatorItem5"
        '
        'btnTrasladar
        '
        Me.btnTrasladar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTrasladar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnTrasladar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.btnTrasladar.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.btnTrasladar.MinSize = New System.Drawing.Size(36, 36)
        Me.btnTrasladar.Name = "btnTrasladar"
        Me.btnTrasladar.ShouldPaint = True
        Me.btnTrasladar.ShowBorder = False
        Me.btnTrasladar.Text = "printToolStripButtonItem"
        Me.btnTrasladar.ToolTipText = "Trasladar a Otro Almacén"
        CType(Me.btnTrasladar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.btnTrasladar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem2
        '
        Me.RadToolStripSeparatorItem2.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RadToolStripSeparatorItem2.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem2.Name = "RadToolStripSeparatorItem2"
        Me.RadToolStripSeparatorItem2.ShouldPaint = True
        Me.RadToolStripSeparatorItem2.Text = "RadToolStripSeparatorItem2"
        '
        'btnSalir
        '
        Me.btnSalir.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnSalir.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.MinSize = New System.Drawing.Size(36, 36)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.ShouldPaint = True
        Me.btnSalir.ShowBorder = False
        Me.btnSalir.Text = "newToolStripButtonItem"
        Me.btnSalir.ToolTipText = "Salir del Formulario"
        CType(Me.btnSalir.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.btnSalir.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem4
        '
        Me.RadToolStripSeparatorItem4.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem4.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RadToolStripSeparatorItem4.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem4.Name = "RadToolStripSeparatorItem4"
        Me.RadToolStripSeparatorItem4.ShouldPaint = True
        Me.RadToolStripSeparatorItem4.Text = "RadToolStripSeparatorItem4"
        '
        'RadButtonElement10
        '
        Me.RadButtonElement10.Name = "RadButtonElement10"
        Me.RadButtonElement10.Text = "RadButtonElement10"
        '
        'RadButtonElement15
        '
        Me.RadButtonElement15.Name = "RadButtonElement15"
        Me.RadButtonElement15.Text = "RadButtonElement15"
        '
        'IdTransitoDet
        '
        Me.IdTransitoDet.DataPropertyName = "IdTransitoDet"
        Me.IdTransitoDet.HeaderText = "IdTransitoDet"
        Me.IdTransitoDet.Name = "IdTransitoDet"
        Me.IdTransitoDet.ReadOnly = True
        Me.IdTransitoDet.Visible = False
        '
        'CodMer
        '
        Me.CodMer.DataPropertyName = "CodMer"
        Me.CodMer.HeaderText = "Código"
        Me.CodMer.Name = "CodMer"
        Me.CodMer.ReadOnly = True
        Me.CodMer.Width = 90
        '
        'DesMer1
        '
        Me.DesMer1.DataPropertyName = "DesMer1"
        Me.DesMer1.HeaderText = "Descripción"
        Me.DesMer1.Name = "DesMer1"
        Me.DesMer1.ReadOnly = True
        Me.DesMer1.Width = 210
        '
        'CanMer
        '
        Me.CanMer.DataPropertyName = "CanMer"
        Me.CanMer.HeaderText = "Cant."
        Me.CanMer.Name = "CanMer"
        Me.CanMer.ReadOnly = True
        Me.CanMer.Width = 50
        '
        'CanRec
        '
        Me.CanRec.DataPropertyName = "CanRec"
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.CanRec.DefaultCellStyle = DataGridViewCellStyle1
        Me.CanRec.HeaderText = "C. Lle."
        Me.CanRec.Name = "CanRec"
        Me.CanRec.Width = 50
        '
        'PreMer
        '
        Me.PreMer.DataPropertyName = "PreMer"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "0.00"
        Me.PreMer.DefaultCellStyle = DataGridViewCellStyle2
        Me.PreMer.HeaderText = "Precio"
        Me.PreMer.Name = "PreMer"
        Me.PreMer.ReadOnly = True
        Me.PreMer.Width = 75
        '
        'DscMer
        '
        Me.DscMer.DataPropertyName = "DscMer"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "0.00"
        Me.DscMer.DefaultCellStyle = DataGridViewCellStyle3
        Me.DscMer.HeaderText = "Dscto."
        Me.DscMer.Name = "DscMer"
        Me.DscMer.ReadOnly = True
        Me.DscMer.Width = 60
        '
        'TotalFila
        '
        Me.TotalFila.DataPropertyName = "TotalFila"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "0.00"
        Me.TotalFila.DefaultCellStyle = DataGridViewCellStyle4
        Me.TotalFila.HeaderText = "Total"
        Me.TotalFila.Name = "TotalFila"
        Me.TotalFila.ReadOnly = True
        Me.TotalFila.Width = 96
        '
        'IdTransito1
        '
        Me.IdTransito1.DataPropertyName = "IdTransito"
        Me.IdTransito1.HeaderText = "IdTransito1"
        Me.IdTransito1.Name = "IdTransito1"
        Me.IdTransito1.Visible = False
        '
        'IdTransferencia
        '
        Me.IdTransferencia.DataPropertyName = "IdTransferencia"
        Me.IdTransferencia.HeaderText = "IdTransferencia"
        Me.IdTransferencia.Name = "IdTransferencia"
        Me.IdTransferencia.Visible = False
        '
        'IdTransferenciaDet
        '
        Me.IdTransferenciaDet.DataPropertyName = "IdTransferenciaDet"
        Me.IdTransferenciaDet.HeaderText = "IdTransferenciaDet"
        Me.IdTransferenciaDet.Name = "IdTransferenciaDet"
        Me.IdTransferenciaDet.Visible = False
        '
        'frmTransferenciasInterna
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(714, 470)
        Me.Controls.Add(Me.RadToolStrip1)
        Me.Controls.Add(Me.gbDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(722, 504)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(722, 504)
        Me.Name = "frmTransferenciasInterna"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "                           "
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.dgvPrueba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesAtender.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.gbTotal.ResumeLayout(False)
        Me.gbTotal.PerformLayout()
        CType(Me.RadToolStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents miSeterCEROTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpcionesAtender As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblJOb As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbTotal As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecibidoPor As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFecIng As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtUsuRec As System.Windows.Forms.TextBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents RadToolStripItem1 As Telerik.WinControls.UI.RadToolStripItem
    Friend WithEvents btnGrabar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripElement1 As Telerik.WinControls.UI.RadToolStripElement
    Friend WithEvents RadToolStripItem2 As Telerik.WinControls.UI.RadToolStripItem
    Friend WithEvents RadButtonElement1 As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripItem3 As Telerik.WinControls.UI.RadToolStripItem
    Friend WithEvents biEditar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripItem4 As Telerik.WinControls.UI.RadToolStripItem
    Friend WithEvents biDeshacer As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripElement2 As Telerik.WinControls.UI.RadToolStripElement
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadToolStrip1 As Telerik.WinControls.UI.RadToolStrip
    Friend WithEvents RadToolStripElement3 As Telerik.WinControls.UI.RadToolStripElement
    Friend WithEvents RadToolStripItem5 As Telerik.WinControls.UI.RadToolStripItem
    Friend WithEvents btnEditar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents btnGuardar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents btnDeshacer As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents btnTrasladar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem2 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents btnSalir As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem4 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadButtonElement10 As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadButtonElement15 As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem1 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadToolStripSeparatorItem3 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadToolStripSeparatorItem5 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvPrueba As System.Windows.Forms.DataGridView
    Friend WithEvents IdTransitoDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesMer1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CanMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CanRec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DscMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalFila As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdTransito1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdTransferencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdTransferenciaDet As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
