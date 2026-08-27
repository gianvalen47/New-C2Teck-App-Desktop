<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentoCostoDatos
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
        Dim dgDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentoCostoDatos))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecDoc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTipCam = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgDetalle = New Janus.Windows.GridEX.GridEX()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmRefrescar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnProrratear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparatorProrratear = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizarCosto = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizarCostosMTI = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.gpMti = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTodos = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbSalida = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbIngreso = New Janus.Windows.EditControls.UIRadioButton()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCodMot = New System.Windows.Forms.TextBox()
        Me.txtCondicionPago = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtGuias = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtPersona = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMotivoMTD = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMotorDestino = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMotorOrigen = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotCosDol = New System.Windows.Forms.TextBox()
        Me.txtTotCosSol = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gpMti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpMti.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
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
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Numero :"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(67, 32)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(91, 20)
        Me.txtNumero.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(165, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha :"
        '
        'txtFecDoc
        '
        Me.txtFecDoc.Location = New System.Drawing.Point(218, 32)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.ReadOnly = True
        Me.txtFecDoc.Size = New System.Drawing.Size(67, 20)
        Me.txtFecDoc.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(445, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Tipo Cambio :"
        '
        'txtTipCam
        '
        Me.txtTipCam.Location = New System.Drawing.Point(522, 32)
        Me.txtTipCam.Name = "txtTipCam"
        Me.txtTipCam.ReadOnly = True
        Me.txtTipCam.Size = New System.Drawing.Size(53, 20)
        Me.txtTipCam.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Cliente :"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(67, 55)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(399, 20)
        Me.txtCliente.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(473, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Factura :"
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(522, 55)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.ReadOnly = True
        Me.txtFactura.Size = New System.Drawing.Size(101, 20)
        Me.txtFactura.TabIndex = 12
        '
        'txtMoneda
        '
        Me.txtMoneda.Location = New System.Drawing.Point(349, 32)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(89, 20)
        Me.txtMoneda.TabIndex = 30
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(294, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Moneda :"
        '
        'dgDetalle
        '
        Me.dgDetalle.AllowCardSizing = False
        Me.dgDetalle.AllowColumnDrag = False
        Me.dgDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgDetalle.AlternatingColors = True
        Me.dgDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDetalle.ContextMenuStrip = Me.ContextMenuStrip1
        dgDetalle_DesignTimeLayout.LayoutString = resources.GetString("dgDetalle_DesignTimeLayout.LayoutString")
        Me.dgDetalle.DesignTimeLayout = dgDetalle_DesignTimeLayout
        Me.dgDetalle.EmptyRows = True
        Me.dgDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgDetalle.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgDetalle.GroupByBoxVisible = False
        Me.dgDetalle.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgDetalle.Location = New System.Drawing.Point(9, 235)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgDetalle.Size = New System.Drawing.Size(664, 189)
        Me.dgDetalle.TabIndex = 31
        Me.dgDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmMostrar, Me.cmModificar, Me.ToolStripSeparator1, Me.cmRefrescar})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(186, 76)
        '
        'cmMostrar
        '
        Me.cmMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.cmMostrar.Name = "cmMostrar"
        Me.cmMostrar.Size = New System.Drawing.Size(185, 22)
        Me.cmMostrar.Text = "Mostrar Detalle"
        '
        'cmModificar
        '
        Me.cmModificar.Image = CType(resources.GetObject("cmModificar.Image"), System.Drawing.Image)
        Me.cmModificar.Name = "cmModificar"
        Me.cmModificar.Size = New System.Drawing.Size(185, 22)
        Me.cmModificar.Text = "Modificar Costo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(182, 6)
        '
        'cmRefrescar
        '
        Me.cmRefrescar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.cmRefrescar.Name = "cmRefrescar"
        Me.cmRefrescar.Size = New System.Drawing.Size(185, 22)
        Me.cmRefrescar.Text = "Actualizar / Refrescar"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(21, 21)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btnMostrar, Me.ToolStripSeparator3, Me.btnModificar, Me.ToolStripSeparator4, Me.btnProrratear, Me.ToolStripSeparatorProrratear, Me.biActualizarCosto, Me.ToolStripSeparator7, Me.biActualizarCostosMTI, Me.ToolStripSeparator6, Me.btnSalir, Me.ToolStripSeparator5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(707, 28)
        Me.ToolStrip1.TabIndex = 32
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
        '
        'btnMostrar
        '
        Me.btnMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.btnMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(25, 25)
        Me.btnMostrar.Text = "ToolStripButton1"
        Me.btnMostrar.ToolTipText = "Mostrar Detalle Seleccionado"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 28)
        '
        'btnModificar
        '
        Me.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(25, 25)
        Me.btnModificar.Text = "ToolStripButton1"
        Me.btnModificar.ToolTipText = "Modificar Costos"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 28)
        '
        'btnProrratear
        '
        Me.btnProrratear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnProrratear.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.btnProrratear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProrratear.Name = "btnProrratear"
        Me.btnProrratear.Size = New System.Drawing.Size(25, 25)
        Me.btnProrratear.Text = "Prorratear Costos"
        Me.btnProrratear.Visible = False
        '
        'ToolStripSeparatorProrratear
        '
        Me.ToolStripSeparatorProrratear.Name = "ToolStripSeparatorProrratear"
        Me.ToolStripSeparatorProrratear.Size = New System.Drawing.Size(6, 28)
        Me.ToolStripSeparatorProrratear.Visible = False
        '
        'biActualizarCosto
        '
        Me.biActualizarCosto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizarCosto.Enabled = False
        Me.biActualizarCosto.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.biActualizarCosto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizarCosto.Name = "biActualizarCosto"
        Me.biActualizarCosto.Size = New System.Drawing.Size(25, 25)
        Me.biActualizarCosto.Text = "Actualizar Costo"
        Me.biActualizarCosto.ToolTipText = "Actualizar costo desde documento origen"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 28)
        '
        'biActualizarCostosMTI
        '
        Me.biActualizarCostosMTI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizarCostosMTI.Enabled = False
        Me.biActualizarCostosMTI.Image = CType(resources.GetObject("biActualizarCostosMTI.Image"), System.Drawing.Image)
        Me.biActualizarCostosMTI.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizarCostosMTI.Name = "biActualizarCostosMTI"
        Me.biActualizarCostosMTI.Size = New System.Drawing.Size(25, 25)
        Me.biActualizarCostosMTI.Text = "Actualizar Costos de Ingresos MTI"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 28)
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(25, 25)
        Me.btnSalir.Text = "ToolStripButton1"
        Me.btnSalir.ToolTipText = "Salir de la Ventana"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 28)
        '
        'gpMti
        '
        Me.gpMti.Controls.Add(Me.rbTodos)
        Me.gpMti.Controls.Add(Me.rbSalida)
        Me.gpMti.Controls.Add(Me.rbIngreso)
        Me.gpMti.Location = New System.Drawing.Point(7, 188)
        Me.gpMti.Name = "gpMti"
        Me.gpMti.Size = New System.Drawing.Size(196, 38)
        Me.gpMti.TabIndex = 33
        Me.gpMti.Text = "Movimiento"
        Me.gpMti.Visible = False
        Me.gpMti.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTodos
        '
        Me.rbTodos.Checked = True
        Me.rbTodos.Location = New System.Drawing.Point(8, 16)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(54, 17)
        Me.rbTodos.TabIndex = 2
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbSalida
        '
        Me.rbSalida.Location = New System.Drawing.Point(135, 16)
        Me.rbSalida.Name = "rbSalida"
        Me.rbSalida.Size = New System.Drawing.Size(54, 17)
        Me.rbSalida.TabIndex = 1
        Me.rbSalida.Text = "Salida"
        Me.rbSalida.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbIngreso
        '
        Me.rbIngreso.Location = New System.Drawing.Point(73, 17)
        Me.rbIngreso.Name = "rbIngreso"
        Me.rbIngreso.Size = New System.Drawing.Size(64, 15)
        Me.rbIngreso.TabIndex = 0
        Me.rbIngreso.Text = "Ingreso"
        Me.rbIngreso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtCodMot)
        Me.UiGroupBox2.Controls.Add(Me.txtCondicionPago)
        Me.UiGroupBox2.Controls.Add(Me.Label14)
        Me.UiGroupBox2.Controls.Add(Me.txtGuias)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtMotivo)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Location = New System.Drawing.Point(3, 78)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(655, 41)
        Me.UiGroupBox2.TabIndex = 34
        Me.UiGroupBox2.Text = "Datos de Venta"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCodMot
        '
        Me.txtCodMot.Location = New System.Drawing.Point(310, 15)
        Me.txtCodMot.Name = "txtCodMot"
        Me.txtCodMot.ReadOnly = True
        Me.txtCodMot.Size = New System.Drawing.Size(25, 20)
        Me.txtCodMot.TabIndex = 35
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
        Me.Label7.Location = New System.Drawing.Point(457, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Numero Guias :"
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(336, 15)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.ReadOnly = True
        Me.txtMotivo.Size = New System.Drawing.Size(116, 20)
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
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.txtPersona)
        Me.UiGroupBox3.Controls.Add(Me.Label13)
        Me.UiGroupBox3.Controls.Add(Me.txtArea)
        Me.UiGroupBox3.Controls.Add(Me.Label12)
        Me.UiGroupBox3.Controls.Add(Me.txtMotivoMTD)
        Me.UiGroupBox3.Controls.Add(Me.Label11)
        Me.UiGroupBox3.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox3.Controls.Add(Me.Label10)
        Me.UiGroupBox3.Controls.Add(Me.txtMotorDestino)
        Me.UiGroupBox3.Controls.Add(Me.Label9)
        Me.UiGroupBox3.Controls.Add(Me.txtMotorOrigen)
        Me.UiGroupBox3.Controls.Add(Me.Label8)
        Me.UiGroupBox3.Location = New System.Drawing.Point(3, 123)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(655, 64)
        Me.UiGroupBox3.TabIndex = 35
        Me.UiGroupBox3.Text = "Datos de Almacen"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtPersona
        '
        Me.txtPersona.Location = New System.Drawing.Point(259, 39)
        Me.txtPersona.Name = "txtPersona"
        Me.txtPersona.ReadOnly = True
        Me.txtPersona.Size = New System.Drawing.Size(207, 20)
        Me.txtPersona.TabIndex = 38
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(203, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Personal :"
        '
        'txtArea
        '
        Me.txtArea.Location = New System.Drawing.Point(51, 39)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(149, 20)
        Me.txtArea.TabIndex = 36
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Area :"
        '
        'txtMotivoMTD
        '
        Me.txtMotivoMTD.Location = New System.Drawing.Point(542, 39)
        Me.txtMotivoMTD.Name = "txtMotivoMTD"
        Me.txtMotivoMTD.ReadOnly = True
        Me.txtMotivoMTD.Size = New System.Drawing.Size(107, 20)
        Me.txtMotivoMTD.TabIndex = 34
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(468, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Motivo MTD :"
        '
        'txtNumJob
        '
        Me.txtNumJob.Location = New System.Drawing.Point(51, 16)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.ReadOnly = True
        Me.txtNumJob.Size = New System.Drawing.Size(71, 20)
        Me.txtNumJob.TabIndex = 32
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "# OT :"
        '
        'txtMotorDestino
        '
        Me.txtMotorDestino.Location = New System.Drawing.Point(463, 16)
        Me.txtMotorDestino.Name = "txtMotorDestino"
        Me.txtMotorDestino.ReadOnly = True
        Me.txtMotorDestino.Size = New System.Drawing.Size(186, 20)
        Me.txtMotorDestino.TabIndex = 30
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(381, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Motor Destino :"
        '
        'txtMotorOrigen
        '
        Me.txtMotorOrigen.Location = New System.Drawing.Point(201, 16)
        Me.txtMotorOrigen.Name = "txtMotorOrigen"
        Me.txtMotorOrigen.ReadOnly = True
        Me.txtMotorOrigen.Size = New System.Drawing.Size(176, 20)
        Me.txtMotorOrigen.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(126, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Motor Origen :"
        '
        'txtTotCosDol
        '
        Me.txtTotCosDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotCosDol.Location = New System.Drawing.Point(210, 442)
        Me.txtTotCosDol.Name = "txtTotCosDol"
        Me.txtTotCosDol.ReadOnly = True
        Me.txtTotCosDol.Size = New System.Drawing.Size(105, 20)
        Me.txtTotCosDol.TabIndex = 36
        Me.txtTotCosDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotCosSol
        '
        Me.txtTotCosSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotCosSol.Location = New System.Drawing.Point(458, 442)
        Me.txtTotCosSol.Name = "txtTotCosSol"
        Me.txtTotCosSol.ReadOnly = True
        Me.txtTotCosSol.Size = New System.Drawing.Size(105, 20)
        Me.txtTotCosSol.TabIndex = 37
        Me.txtTotCosSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(81, 445)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(127, 13)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Total Costo Dólares :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(340, 445)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(115, 13)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Total Costo Sóles :"
        '
        'frmDocumentoCostoDatos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(707, 501)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtTotCosSol)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtTotCosDol)
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgDetalle)
        Me.Controls.Add(Me.gpMti)
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
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDocumentoCostoDatos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Documento de Movimiento de Inventario"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gpMti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpMti.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtFecDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTipCam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dgDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmRefrescar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gpMti As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbSalida As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbIngreso As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtPersona As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMotivoMTD As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMotorDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMotorOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCondicionPago As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtGuias As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotCosSol As System.Windows.Forms.TextBox
    Friend WithEvents txtTotCosDol As System.Windows.Forms.TextBox
    Friend WithEvents rbTodos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnProrratear As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCodMot As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparatorProrratear As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizarCosto As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents biActualizarCostosMTI As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
End Class
