<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatosImportacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDatosImportacion))
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.txtFecDoc = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtIngreso = New System.Windows.Forms.TextBox()
        Me.txtAduana = New System.Windows.Forms.TextBox()
        Me.txtTransporte = New System.Windows.Forms.TextBox()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmRecalcular = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmRefrescar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgDetalle = New Janus.Windows.GridEX.GridEX()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.mkFactorDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkFactorSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkPeso = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRecostear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRecalcular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.mkTotFacturaSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkTotFacturaDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkDerAduSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkDerAduDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkTotFleteSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkTotFleteDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkTotFobGenSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkTotFobGenDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkOtroGastoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkOtroGastoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkNucleoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkNucleoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkGescomSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkGescomDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkFleIntSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkFleIntDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkTotFobSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkTotFobDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnMostrarGastos = New System.Windows.Forms.Button()
        Me.mkMultas = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.mkPercepcion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.mkAdvalorem = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkTotalIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkIpm = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.txtPoliza = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtSeguro = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ckApliSeg = New System.Windows.Forms.CheckBox()
        Me.mkSeguro = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkSobretasa = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkServicio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkIgvAdu = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnBuscarPais = New System.Windows.Forms.Button()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.mkPtoEmb = New System.Windows.Forms.TextBox()
        Me.mkVia = New System.Windows.Forms.ComboBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.mkPagosExt = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.mkTotalAgencia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.mkOtrosServ = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkHandling = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkResguardo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.mkOtroGastos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkTranspLocal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkGastoAgencia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkTerminal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkCarga = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(61, 34)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(128, 20)
        Me.txtNumDoc.TabIndex = 1
        Me.txtNumDoc.TabStop = False
        '
        'txtFecDoc
        '
        Me.txtFecDoc.Location = New System.Drawing.Point(240, 34)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.ReadOnly = True
        Me.txtFecDoc.Size = New System.Drawing.Size(74, 20)
        Me.txtFecDoc.TabIndex = 2
        Me.txtFecDoc.TabStop = False
        Me.txtFecDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProveedor
        '
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(387, 33)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(392, 20)
        Me.txtProveedor.TabIndex = 3
        Me.txtProveedor.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Numero :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(319, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Proveedor :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(790, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "# Ingreso :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Agencia Aduana :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(323, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Agencia Transp. :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(634, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Pais Origen :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Fact. Aduana :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(601, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Tipo Cambio :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(756, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Peso Bruto :"
        '
        'txtIngreso
        '
        Me.txtIngreso.Location = New System.Drawing.Point(848, 34)
        Me.txtIngreso.Name = "txtIngreso"
        Me.txtIngreso.Size = New System.Drawing.Size(67, 20)
        Me.txtIngreso.TabIndex = 4
        '
        'txtAduana
        '
        Me.txtAduana.Location = New System.Drawing.Point(101, 55)
        Me.txtAduana.Name = "txtAduana"
        Me.txtAduana.ReadOnly = True
        Me.txtAduana.Size = New System.Drawing.Size(192, 20)
        Me.txtAduana.TabIndex = 5
        '
        'txtTransporte
        '
        Me.txtTransporte.Location = New System.Drawing.Point(415, 55)
        Me.txtTransporte.Name = "txtTransporte"
        Me.txtTransporte.Size = New System.Drawing.Size(218, 20)
        Me.txtTransporte.TabIndex = 6
        '
        'txtOrigen
        '
        Me.txtOrigen.Location = New System.Drawing.Point(702, 55)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.ReadOnly = True
        Me.txtOrigen.Size = New System.Drawing.Size(187, 20)
        Me.txtOrigen.TabIndex = 7
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(90, 76)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(124, 20)
        Me.txtFactura.TabIndex = 9
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmModificar, Me.cmRecalcular, Me.ToolStripMenuItem2, Me.cmMostrar, Me.cmRefrescar})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(186, 98)
        '
        'cmModificar
        '
        Me.cmModificar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.cmModificar.Name = "cmModificar"
        Me.cmModificar.Size = New System.Drawing.Size(185, 22)
        Me.cmModificar.Text = "Modificar"
        '
        'cmRecalcular
        '
        Me.cmRecalcular.Image = Global.SIGECOM.My.Resources.Resources.Recalcular
        Me.cmRecalcular.Name = "cmRecalcular"
        Me.cmRecalcular.Size = New System.Drawing.Size(185, 22)
        Me.cmRecalcular.Text = "Recalcular"
        Me.cmRecalcular.ToolTipText = "Recalculo precio de los costos"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(182, 6)
        '
        'cmMostrar
        '
        Me.cmMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.cmMostrar.Name = "cmMostrar"
        Me.cmMostrar.Size = New System.Drawing.Size(185, 22)
        Me.cmMostrar.Text = "Mostrar"
        Me.cmMostrar.ToolTipText = "Mostrar el detalle del registro"
        '
        'cmRefrescar
        '
        Me.cmRefrescar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.cmRefrescar.Name = "cmRefrescar"
        Me.cmRefrescar.Size = New System.Drawing.Size(185, 22)
        Me.cmRefrescar.Text = "Actualizar / Refrescar"
        Me.cmRefrescar.ToolTipText = "Actualizar / Refrescar los datos"
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
        Me.dgDetalle.Location = New System.Drawing.Point(5, 242)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgDetalle.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgDetalle.Size = New System.Drawing.Size(914, 246)
        Me.dgDetalle.TabIndex = 76
        Me.ToolTip1.SetToolTip(Me.dgDetalle, "Listado de Facturas de Importacion")
        Me.dgDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(588, 508)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(52, 13)
        Me.Label40.TabIndex = 62
        Me.Label40.Text = "Factor $ :"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(749, 508)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(61, 13)
        Me.Label41.TabIndex = 63
        Me.Label41.Text = "Factor S/. :"
        Me.Label41.Visible = False
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'mkFactorDol
        '
        Me.mkFactorDol.DecimalDigits = 10
        Me.mkFactorDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkFactorDol.Enabled = False
        Me.mkFactorDol.Location = New System.Drawing.Point(642, 505)
        Me.mkFactorDol.Name = "mkFactorDol"
        Me.mkFactorDol.Size = New System.Drawing.Size(104, 20)
        Me.mkFactorDol.TabIndex = 67
        Me.mkFactorDol.Text = "0.0000000000"
        Me.mkFactorDol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'mkFactorSol
        '
        Me.mkFactorSol.DecimalDigits = 10
        Me.mkFactorSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkFactorSol.Enabled = False
        Me.mkFactorSol.Location = New System.Drawing.Point(812, 505)
        Me.mkFactorSol.Name = "mkFactorSol"
        Me.mkFactorSol.Size = New System.Drawing.Size(103, 20)
        Me.mkFactorSol.TabIndex = 68
        Me.mkFactorSol.Text = "0.0000000000"
        Me.mkFactorSol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        Me.mkFactorSol.Visible = False
        '
        'mkCambio
        '
        Me.mkCambio.DecimalDigits = 3
        Me.mkCambio.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkCambio.Location = New System.Drawing.Point(677, 76)
        Me.mkCambio.Name = "mkCambio"
        Me.mkCambio.Size = New System.Drawing.Size(57, 20)
        Me.mkCambio.TabIndex = 12
        Me.mkCambio.Text = "0.000"
        Me.mkCambio.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'mkPeso
        '
        Me.mkPeso.DecimalDigits = 4
        Me.mkPeso.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkPeso.Location = New System.Drawing.Point(824, 76)
        Me.mkPeso.Name = "mkPeso"
        Me.mkPeso.Size = New System.Drawing.Size(91, 20)
        Me.mkPeso.TabIndex = 13
        Me.mkPeso.Text = "0.0000"
        Me.mkPeso.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnModificar, Me.ToolStripSeparator6, Me.btnGuardar, Me.ToolStripSeparator5, Me.btnCancelar, Me.ToolStripSeparator4, Me.btnRecostear, Me.ToolStripSeparator3, Me.btnRecalcular, Me.ToolStripSeparator1, Me.btnImprimir, Me.ToolStripSeparator2, Me.btnExcel, Me.ToolStripSeparator7, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(950, 31)
        Me.ToolStrip1.TabIndex = 73
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnModificar
        '
        Me.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnModificar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(28, 28)
        Me.btnModificar.Text = "ToolStripButton1"
        Me.btnModificar.ToolTipText = "Modificar"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.Text = "ToolStripButton2"
        Me.btnGuardar.ToolTipText = "Guardar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(28, 28)
        Me.btnCancelar.Text = "ToolStripButton3"
        Me.btnCancelar.ToolTipText = "Cancelar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'btnRecostear
        '
        Me.btnRecostear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRecostear.Image = CType(resources.GetObject("btnRecostear.Image"), System.Drawing.Image)
        Me.btnRecostear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRecostear.Name = "btnRecostear"
        Me.btnRecostear.Size = New System.Drawing.Size(28, 28)
        Me.btnRecostear.Text = "ToolStripButton4"
        Me.btnRecostear.ToolTipText = "Procesar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'btnRecalcular
        '
        Me.btnRecalcular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRecalcular.Image = Global.SIGECOM.My.Resources.Resources.Recalcular
        Me.btnRecalcular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(28, 28)
        Me.btnRecalcular.Text = "ToolStripButton1"
        Me.btnRecalcular.ToolTipText = "Recalculo Previo de Costos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(28, 28)
        Me.btnImprimir.Text = "ToolStripButton1"
        Me.btnImprimir.ToolTipText = "Imprimir Factura"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'btnExcel
        '
        Me.btnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExcel.Image = Global.SIGECOM.My.Resources.Resources.excel_ico
        Me.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(28, 28)
        Me.btnExcel.Text = "Exportar Datos"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(28, 28)
        Me.btnSalir.Text = "ToolStripButton5"
        Me.btnSalir.ToolTipText = "Cerrar"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.mkTotFacturaSol)
        Me.UiGroupBox1.Controls.Add(Me.mkTotFacturaDol)
        Me.UiGroupBox1.Controls.Add(Me.mkDerAduSol)
        Me.UiGroupBox1.Controls.Add(Me.mkDerAduDol)
        Me.UiGroupBox1.Controls.Add(Me.mkTotFleteSol)
        Me.UiGroupBox1.Controls.Add(Me.mkTotFleteDol)
        Me.UiGroupBox1.Controls.Add(Me.mkTotFobGenSol)
        Me.UiGroupBox1.Controls.Add(Me.mkTotFobGenDol)
        Me.UiGroupBox1.Controls.Add(Me.mkOtroGastoSol)
        Me.UiGroupBox1.Controls.Add(Me.mkOtroGastoDol)
        Me.UiGroupBox1.Controls.Add(Me.mkNucleoSol)
        Me.UiGroupBox1.Controls.Add(Me.mkNucleoDol)
        Me.UiGroupBox1.Controls.Add(Me.mkGescomSol)
        Me.UiGroupBox1.Controls.Add(Me.mkGescomDol)
        Me.UiGroupBox1.Controls.Add(Me.mkFleIntSol)
        Me.UiGroupBox1.Controls.Add(Me.mkFleIntDol)
        Me.UiGroupBox1.Controls.Add(Me.mkTotFobSol)
        Me.UiGroupBox1.Controls.Add(Me.mkTotFobDol)
        Me.UiGroupBox1.Controls.Add(Me.Label23)
        Me.UiGroupBox1.Controls.Add(Me.Label22)
        Me.UiGroupBox1.Controls.Add(Me.Label21)
        Me.UiGroupBox1.Controls.Add(Me.Label20)
        Me.UiGroupBox1.Controls.Add(Me.Label19)
        Me.UiGroupBox1.Controls.Add(Me.Label18)
        Me.UiGroupBox1.Controls.Add(Me.Label17)
        Me.UiGroupBox1.Controls.Add(Me.Label16)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.Label13)
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 168)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(909, 68)
        Me.UiGroupBox1.TabIndex = 74
        Me.UiGroupBox1.Text = "Totales"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'mkTotFacturaSol
        '
        Me.mkTotFacturaSol.DecimalDigits = 3
        Me.mkTotFacturaSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTotFacturaSol.Enabled = False
        Me.mkTotFacturaSol.Location = New System.Drawing.Point(813, 45)
        Me.mkTotFacturaSol.Name = "mkTotFacturaSol"
        Me.mkTotFacturaSol.Size = New System.Drawing.Size(93, 20)
        Me.mkTotFacturaSol.TabIndex = 129
        Me.mkTotFacturaSol.Text = "0.000"
        Me.mkTotFacturaSol.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'mkTotFacturaDol
        '
        Me.mkTotFacturaDol.DecimalDigits = 3
        Me.mkTotFacturaDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTotFacturaDol.Enabled = False
        Me.mkTotFacturaDol.Location = New System.Drawing.Point(813, 24)
        Me.mkTotFacturaDol.Name = "mkTotFacturaDol"
        Me.mkTotFacturaDol.Size = New System.Drawing.Size(93, 20)
        Me.mkTotFacturaDol.TabIndex = 38
        Me.mkTotFacturaDol.Text = "0.000"
        Me.mkTotFacturaDol.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'mkDerAduSol
        '
        Me.mkDerAduSol.DecimalDigits = 3
        Me.mkDerAduSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkDerAduSol.Location = New System.Drawing.Point(720, 45)
        Me.mkDerAduSol.Name = "mkDerAduSol"
        Me.mkDerAduSol.Size = New System.Drawing.Size(91, 20)
        Me.mkDerAduSol.TabIndex = 127
        Me.mkDerAduSol.Text = "0.000"
        Me.mkDerAduSol.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'mkDerAduDol
        '
        Me.mkDerAduDol.DecimalDigits = 3
        Me.mkDerAduDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkDerAduDol.Location = New System.Drawing.Point(720, 24)
        Me.mkDerAduDol.Name = "mkDerAduDol"
        Me.mkDerAduDol.Size = New System.Drawing.Size(91, 20)
        Me.mkDerAduDol.TabIndex = 37
        Me.mkDerAduDol.Text = "0.000"
        Me.mkDerAduDol.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'mkTotFleteSol
        '
        Me.mkTotFleteSol.DecimalDigits = 3
        Me.mkTotFleteSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTotFleteSol.Enabled = False
        Me.mkTotFleteSol.Location = New System.Drawing.Point(628, 45)
        Me.mkTotFleteSol.Name = "mkTotFleteSol"
        Me.mkTotFleteSol.Size = New System.Drawing.Size(91, 20)
        Me.mkTotFleteSol.TabIndex = 125
        Me.mkTotFleteSol.Text = "0.000"
        Me.mkTotFleteSol.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'mkTotFleteDol
        '
        Me.mkTotFleteDol.DecimalDigits = 3
        Me.mkTotFleteDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTotFleteDol.Location = New System.Drawing.Point(628, 24)
        Me.mkTotFleteDol.Name = "mkTotFleteDol"
        Me.mkTotFleteDol.Size = New System.Drawing.Size(91, 20)
        Me.mkTotFleteDol.TabIndex = 36
        Me.mkTotFleteDol.Text = "0.000"
        Me.mkTotFleteDol.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'mkTotFobGenSol
        '
        Me.mkTotFobGenSol.DecimalDigits = 2
        Me.mkTotFobGenSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTotFobGenSol.Enabled = False
        Me.mkTotFobGenSol.Location = New System.Drawing.Point(531, 45)
        Me.mkTotFobGenSol.Name = "mkTotFobGenSol"
        Me.mkTotFobGenSol.Size = New System.Drawing.Size(95, 20)
        Me.mkTotFobGenSol.TabIndex = 123
        Me.mkTotFobGenSol.Text = "0.00"
        Me.mkTotFobGenSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'mkTotFobGenDol
        '
        Me.mkTotFobGenDol.DecimalDigits = 2
        Me.mkTotFobGenDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTotFobGenDol.Enabled = False
        Me.mkTotFobGenDol.Location = New System.Drawing.Point(531, 24)
        Me.mkTotFobGenDol.Name = "mkTotFobGenDol"
        Me.mkTotFobGenDol.Size = New System.Drawing.Size(95, 20)
        Me.mkTotFobGenDol.TabIndex = 35
        Me.mkTotFobGenDol.Text = "0.00"
        Me.mkTotFobGenDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'mkOtroGastoSol
        '
        Me.mkOtroGastoSol.DecimalDigits = 10
        Me.mkOtroGastoSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkOtroGastoSol.Enabled = False
        Me.mkOtroGastoSol.Location = New System.Drawing.Point(420, 45)
        Me.mkOtroGastoSol.Name = "mkOtroGastoSol"
        Me.mkOtroGastoSol.Size = New System.Drawing.Size(109, 20)
        Me.mkOtroGastoSol.TabIndex = 121
        Me.mkOtroGastoSol.Text = "0.0000000000"
        Me.mkOtroGastoSol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'mkOtroGastoDol
        '
        Me.mkOtroGastoDol.DecimalDigits = 10
        Me.mkOtroGastoDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkOtroGastoDol.Location = New System.Drawing.Point(420, 24)
        Me.mkOtroGastoDol.Name = "mkOtroGastoDol"
        Me.mkOtroGastoDol.Size = New System.Drawing.Size(109, 20)
        Me.mkOtroGastoDol.TabIndex = 34
        Me.mkOtroGastoDol.Text = "0.0000000000"
        Me.mkOtroGastoDol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'mkNucleoSol
        '
        Me.mkNucleoSol.DecimalDigits = 4
        Me.mkNucleoSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkNucleoSol.Enabled = False
        Me.mkNucleoSol.Location = New System.Drawing.Point(327, 45)
        Me.mkNucleoSol.Name = "mkNucleoSol"
        Me.mkNucleoSol.Size = New System.Drawing.Size(91, 20)
        Me.mkNucleoSol.TabIndex = 119
        Me.mkNucleoSol.Text = "0.0000"
        Me.mkNucleoSol.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkNucleoDol
        '
        Me.mkNucleoDol.DecimalDigits = 4
        Me.mkNucleoDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkNucleoDol.Location = New System.Drawing.Point(327, 24)
        Me.mkNucleoDol.Name = "mkNucleoDol"
        Me.mkNucleoDol.Size = New System.Drawing.Size(91, 20)
        Me.mkNucleoDol.TabIndex = 33
        Me.mkNucleoDol.Text = "0.0000"
        Me.mkNucleoDol.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkGescomSol
        '
        Me.mkGescomSol.DecimalDigits = 10
        Me.mkGescomSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkGescomSol.Enabled = False
        Me.mkGescomSol.Location = New System.Drawing.Point(222, 45)
        Me.mkGescomSol.Name = "mkGescomSol"
        Me.mkGescomSol.Size = New System.Drawing.Size(103, 20)
        Me.mkGescomSol.TabIndex = 117
        Me.mkGescomSol.Text = "0.0000000000"
        Me.mkGescomSol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'mkGescomDol
        '
        Me.mkGescomDol.DecimalDigits = 10
        Me.mkGescomDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkGescomDol.Location = New System.Drawing.Point(222, 24)
        Me.mkGescomDol.Name = "mkGescomDol"
        Me.mkGescomDol.Size = New System.Drawing.Size(102, 20)
        Me.mkGescomDol.TabIndex = 32
        Me.mkGescomDol.Text = "0.0000000000"
        Me.mkGescomDol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'mkFleIntSol
        '
        Me.mkFleIntSol.DecimalDigits = 10
        Me.mkFleIntSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkFleIntSol.Enabled = False
        Me.mkFleIntSol.Location = New System.Drawing.Point(121, 45)
        Me.mkFleIntSol.Name = "mkFleIntSol"
        Me.mkFleIntSol.Size = New System.Drawing.Size(98, 20)
        Me.mkFleIntSol.TabIndex = 115
        Me.mkFleIntSol.Text = "0.0000000000"
        Me.mkFleIntSol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'mkFleIntDol
        '
        Me.mkFleIntDol.DecimalDigits = 10
        Me.mkFleIntDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkFleIntDol.Location = New System.Drawing.Point(121, 24)
        Me.mkFleIntDol.Name = "mkFleIntDol"
        Me.mkFleIntDol.Size = New System.Drawing.Size(98, 20)
        Me.mkFleIntDol.TabIndex = 31
        Me.mkFleIntDol.Text = "0.0000000000"
        Me.mkFleIntDol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'mkTotFobSol
        '
        Me.mkTotFobSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTotFobSol.Enabled = False
        Me.mkTotFobSol.Location = New System.Drawing.Point(27, 45)
        Me.mkTotFobSol.Name = "mkTotFobSol"
        Me.mkTotFobSol.Size = New System.Drawing.Size(91, 20)
        Me.mkTotFobSol.TabIndex = 39
        Me.mkTotFobSol.Text = "0.00"
        Me.mkTotFobSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'mkTotFobDol
        '
        Me.mkTotFobDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTotFobDol.Enabled = False
        Me.mkTotFobDol.Location = New System.Drawing.Point(27, 24)
        Me.mkTotFobDol.Name = "mkTotFobDol"
        Me.mkTotFobDol.Size = New System.Drawing.Size(91, 20)
        Me.mkTotFobDol.TabIndex = 30
        Me.mkTotFobDol.Text = "0.00"
        Me.mkTotFobDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(4, 49)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(25, 13)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "S/."
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(8, 27)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(14, 13)
        Me.Label22.TabIndex = 110
        Me.Label22.Text = "$"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(824, 10)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 13)
        Me.Label21.TabIndex = 109
        Me.Label21.Text = "Total Factura"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(725, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(82, 13)
        Me.Label20.TabIndex = 108
        Me.Label20.Text = "Nacionalización"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(644, 10)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 13)
        Me.Label19.TabIndex = 107
        Me.Label19.Text = "Total Flete"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(533, 10)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 13)
        Me.Label18.TabIndex = 106
        Me.Label18.Text = "Total Fob General"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(440, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 13)
        Me.Label17.TabIndex = 105
        Me.Label17.Text = "Otros Gastos"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(334, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 104
        Me.Label16.Text = "Dpto. x Nucleo"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(231, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 103
        Me.Label15.Text = "Gestion Compra"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(135, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 102
        Me.Label14.Text = "Flete Interno"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(46, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 101
        Me.Label13.Text = "Total Fob"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.btnMostrarGastos)
        Me.UiGroupBox2.Controls.Add(Me.mkMultas)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.mkPercepcion)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.GroupBox4)
        Me.UiGroupBox2.Controls.Add(Me.mkAdvalorem)
        Me.UiGroupBox2.Controls.Add(Me.mkTotalIgv)
        Me.UiGroupBox2.Controls.Add(Me.mkIpm)
        Me.UiGroupBox2.Controls.Add(Me.mkIgv)
        Me.UiGroupBox2.Controls.Add(Me.Label39)
        Me.UiGroupBox2.Controls.Add(Me.txtGuia)
        Me.UiGroupBox2.Controls.Add(Me.txtPoliza)
        Me.UiGroupBox2.Controls.Add(Me.Label29)
        Me.UiGroupBox2.Controls.Add(Me.Label27)
        Me.UiGroupBox2.Controls.Add(Me.Label26)
        Me.UiGroupBox2.Controls.Add(Me.Label25)
        Me.UiGroupBox2.Controls.Add(Me.Label24)
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 98)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(911, 67)
        Me.UiGroupBox2.TabIndex = 75
        Me.UiGroupBox2.Text = "Otros Datos"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnMostrarGastos
        '
        Me.btnMostrarGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarGastos.Image = CType(resources.GetObject("btnMostrarGastos.Image"), System.Drawing.Image)
        Me.btnMostrarGastos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMostrarGastos.Location = New System.Drawing.Point(476, 36)
        Me.btnMostrarGastos.Name = "btnMostrarGastos"
        Me.btnMostrarGastos.Size = New System.Drawing.Size(165, 23)
        Me.btnMostrarGastos.TabIndex = 134
        Me.btnMostrarGastos.TabStop = False
        Me.btnMostrarGastos.Text = "Mostrar Gastos"
        Me.btnMostrarGastos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMostrarGastos.UseVisualStyleBackColor = True
        '
        'mkMultas
        '
        Me.mkMultas.DecimalDigits = 4
        Me.mkMultas.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkMultas.Location = New System.Drawing.Point(392, 37)
        Me.mkMultas.Name = "mkMultas"
        Me.mkMultas.Size = New System.Drawing.Size(74, 20)
        Me.mkMultas.TabIndex = 101
        Me.mkMultas.Text = "0.0000"
        Me.mkMultas.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(327, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 102
        Me.Label10.Text = "Multas S/. :"
        '
        'mkPercepcion
        '
        Me.mkPercepcion.DecimalDigits = 4
        Me.mkPercepcion.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkPercepcion.Location = New System.Drawing.Point(247, 37)
        Me.mkPercepcion.Name = "mkPercepcion"
        Me.mkPercepcion.Size = New System.Drawing.Size(74, 20)
        Me.mkPercepcion.TabIndex = 99
        Me.mkPercepcion.Text = "0.0000"
        Me.mkPercepcion.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(161, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Percepción S/. :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblEstado)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(744, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(162, 43)
        Me.GroupBox4.TabIndex = 98
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Estado"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Maroon
        Me.lblEstado.Location = New System.Drawing.Point(18, 13)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(0, 24)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mkAdvalorem
        '
        Me.mkAdvalorem.DecimalDigits = 4
        Me.mkAdvalorem.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkAdvalorem.Location = New System.Drawing.Point(81, 37)
        Me.mkAdvalorem.Name = "mkAdvalorem"
        Me.mkAdvalorem.Size = New System.Drawing.Size(74, 20)
        Me.mkAdvalorem.TabIndex = 19
        Me.mkAdvalorem.Text = "0.0000"
        Me.mkAdvalorem.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkTotalIgv
        '
        Me.mkTotalIgv.DecimalDigits = 4
        Me.mkTotalIgv.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTotalIgv.Enabled = False
        Me.mkTotalIgv.Location = New System.Drawing.Point(664, 13)
        Me.mkTotalIgv.Name = "mkTotalIgv"
        Me.mkTotalIgv.Size = New System.Drawing.Size(76, 20)
        Me.mkTotalIgv.TabIndex = 18
        Me.mkTotalIgv.Text = "0.0000"
        Me.mkTotalIgv.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkIpm
        '
        Me.mkIpm.DecimalDigits = 4
        Me.mkIpm.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkIpm.Location = New System.Drawing.Point(480, 13)
        Me.mkIpm.Name = "mkIpm"
        Me.mkIpm.Size = New System.Drawing.Size(78, 20)
        Me.mkIpm.TabIndex = 16
        Me.mkIpm.Text = "0.0000"
        Me.mkIpm.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkIgv
        '
        Me.mkIgv.DecimalDigits = 4
        Me.mkIgv.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkIgv.Location = New System.Drawing.Point(344, 13)
        Me.mkIgv.Name = "mkIgv"
        Me.mkIgv.Size = New System.Drawing.Size(81, 20)
        Me.mkIgv.TabIndex = 15
        Me.mkIgv.Text = "0.0000"
        Me.mkIgv.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(562, 17)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(97, 13)
        Me.Label39.TabIndex = 84
        Me.Label39.Text = "Total Impuestos $ :"
        '
        'txtGuia
        '
        Me.txtGuia.Location = New System.Drawing.Point(200, 13)
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.Size = New System.Drawing.Size(87, 20)
        Me.txtGuia.TabIndex = 23
        '
        'txtPoliza
        '
        Me.txtPoliza.Location = New System.Drawing.Point(50, 13)
        Me.txtPoliza.Name = "txtPoliza"
        Me.txtPoliza.Size = New System.Drawing.Size(106, 20)
        Me.txtPoliza.TabIndex = 14
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(7, 42)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(72, 13)
        Me.Label29.TabIndex = 77
        Me.Label29.Text = "Advalorem $ :"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(430, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(47, 13)
        Me.Label27.TabIndex = 75
        Me.Label27.Text = "I.P.M $ :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(292, 17)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(49, 13)
        Me.Label26.TabIndex = 74
        Me.Label26.Text = "I.G.V. $ :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(161, 17)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(35, 13)
        Me.Label25.TabIndex = 73
        Me.Label25.Text = "Guia :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(8, 17)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(44, 13)
        Me.Label24.TabIndex = 72
        Me.Label24.Text = "Poliza : "
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(466, 520)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(15, 13)
        Me.Label42.TabIndex = 97
        Me.Label42.Text = "%"
        Me.Label42.Visible = False
        '
        'txtSeguro
        '
        Me.txtSeguro.DecimalDigits = 5
        Me.txtSeguro.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSeguro.Location = New System.Drawing.Point(389, 517)
        Me.txtSeguro.Name = "txtSeguro"
        Me.txtSeguro.Size = New System.Drawing.Size(77, 20)
        Me.txtSeguro.TabIndex = 96
        Me.txtSeguro.Text = "0.00000"
        Me.txtSeguro.Value = New Decimal(New Integer() {0, 0, 0, 327680})
        Me.txtSeguro.Visible = False
        '
        'ckApliSeg
        '
        Me.ckApliSeg.AutoSize = True
        Me.ckApliSeg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ckApliSeg.Location = New System.Drawing.Point(303, 519)
        Me.ckApliSeg.Name = "ckApliSeg"
        Me.ckApliSeg.Size = New System.Drawing.Size(83, 17)
        Me.ckApliSeg.TabIndex = 95
        Me.ckApliSeg.Text = "Apli. Seguro"
        Me.ckApliSeg.UseVisualStyleBackColor = True
        Me.ckApliSeg.Visible = False
        '
        'mkSeguro
        '
        Me.mkSeguro.DecimalDigits = 4
        Me.mkSeguro.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkSeguro.Location = New System.Drawing.Point(486, 494)
        Me.mkSeguro.Name = "mkSeguro"
        Me.mkSeguro.Size = New System.Drawing.Size(63, 20)
        Me.mkSeguro.TabIndex = 22
        Me.mkSeguro.Text = "0.0000"
        Me.mkSeguro.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.mkSeguro.Visible = False
        '
        'mkSobretasa
        '
        Me.mkSobretasa.DecimalDigits = 4
        Me.mkSobretasa.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkSobretasa.Location = New System.Drawing.Point(345, 496)
        Me.mkSobretasa.Name = "mkSobretasa"
        Me.mkSobretasa.Size = New System.Drawing.Size(78, 20)
        Me.mkSobretasa.TabIndex = 21
        Me.mkSobretasa.Text = "0.0000"
        Me.mkSobretasa.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.mkSobretasa.Visible = False
        '
        'mkServicio
        '
        Me.mkServicio.DecimalDigits = 4
        Me.mkServicio.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkServicio.Location = New System.Drawing.Point(185, 496)
        Me.mkServicio.Name = "mkServicio"
        Me.mkServicio.Size = New System.Drawing.Size(65, 20)
        Me.mkServicio.TabIndex = 20
        Me.mkServicio.Text = "0.0000"
        Me.mkServicio.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.mkServicio.Visible = False
        '
        'mkIgvAdu
        '
        Me.mkIgvAdu.DecimalDigits = 4
        Me.mkIgvAdu.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkIgvAdu.Location = New System.Drawing.Point(190, 517)
        Me.mkIgvAdu.Name = "mkIgvAdu"
        Me.mkIgvAdu.Size = New System.Drawing.Size(100, 20)
        Me.mkIgvAdu.TabIndex = 17
        Me.mkIgvAdu.Text = "0.0000"
        Me.mkIgvAdu.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.mkIgvAdu.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(428, 499)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(56, 13)
        Me.Label32.TabIndex = 80
        Me.Label32.Text = "Seguro $ :"
        Me.Label32.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(256, 501)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(86, 13)
        Me.Label31.TabIndex = 79
        Me.Label31.Text = "Sobre Tasa S/. :"
        Me.Label31.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(108, 501)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(74, 13)
        Me.Label30.TabIndex = 78
        Me.Label30.Text = "Servicios S/. :"
        Me.Label30.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(108, 521)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(79, 13)
        Me.Label28.TabIndex = 76
        Me.Label28.Text = "I.G.V. AD. S/. :"
        Me.Label28.Visible = False
        '
        'btnBuscarPais
        '
        Me.btnBuscarPais.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPais.Location = New System.Drawing.Point(890, 54)
        Me.btnBuscarPais.Name = "btnBuscarPais"
        Me.btnBuscarPais.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarPais.TabIndex = 8
        Me.btnBuscarPais.TabStop = False
        Me.btnBuscarPais.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Location = New System.Drawing.Point(486, 519)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Size = New System.Drawing.Size(88, 17)
        Me.dgvDatos.TabIndex = 77
        Me.dgvDatos.Visible = False
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(219, 81)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(30, 13)
        Me.Label43.TabIndex = 78
        Me.Label43.Text = "Vía :"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(383, 81)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(83, 13)
        Me.Label44.TabIndex = 79
        Me.Label44.Text = "Pto. Embarque :"
        '
        'mkPtoEmb
        '
        Me.mkPtoEmb.Location = New System.Drawing.Point(470, 76)
        Me.mkPtoEmb.Name = "mkPtoEmb"
        Me.mkPtoEmb.Size = New System.Drawing.Size(129, 20)
        Me.mkPtoEmb.TabIndex = 81
        '
        'mkVia
        '
        Me.mkVia.FormattingEnabled = True
        Me.mkVia.Items.AddRange(New Object() {"Maritima", "Aerea"})
        Me.mkVia.Location = New System.Drawing.Point(254, 76)
        Me.mkVia.Name = "mkVia"
        Me.mkVia.Size = New System.Drawing.Size(121, 21)
        Me.mkVia.TabIndex = 82
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(730, 0)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(169, 31)
        Me.txtObservacion.TabIndex = 83
        Me.txtObservacion.Visible = False
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(294, 53)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 84
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.mkPagosExt)
        Me.UiGroupBox3.Controls.Add(Me.Label48)
        Me.UiGroupBox3.Controls.Add(Me.mkTotalAgencia)
        Me.UiGroupBox3.Controls.Add(Me.Label38)
        Me.UiGroupBox3.Controls.Add(Me.Label47)
        Me.UiGroupBox3.Controls.Add(Me.Label46)
        Me.UiGroupBox3.Controls.Add(Me.mkOtrosServ)
        Me.UiGroupBox3.Controls.Add(Me.mkHandling)
        Me.UiGroupBox3.Controls.Add(Me.mkResguardo)
        Me.UiGroupBox3.Controls.Add(Me.Label45)
        Me.UiGroupBox3.Controls.Add(Me.mkOtroGastos)
        Me.UiGroupBox3.Controls.Add(Me.mkTranspLocal)
        Me.UiGroupBox3.Controls.Add(Me.mkGastoAgencia)
        Me.UiGroupBox3.Controls.Add(Me.mkTerminal)
        Me.UiGroupBox3.Controls.Add(Me.mkCarga)
        Me.UiGroupBox3.Controls.Add(Me.Label37)
        Me.UiGroupBox3.Controls.Add(Me.Label36)
        Me.UiGroupBox3.Controls.Add(Me.Label35)
        Me.UiGroupBox3.Controls.Add(Me.Label34)
        Me.UiGroupBox3.Controls.Add(Me.Label33)
        Me.UiGroupBox3.Location = New System.Drawing.Point(9, 488)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(96, 48)
        Me.UiGroupBox3.TabIndex = 94
        Me.UiGroupBox3.Visible = False
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'mkPagosExt
        '
        Me.mkPagosExt.DecimalDigits = 4
        Me.mkPagosExt.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkPagosExt.Location = New System.Drawing.Point(109, 51)
        Me.mkPagosExt.Name = "mkPagosExt"
        Me.mkPagosExt.Size = New System.Drawing.Size(94, 20)
        Me.mkPagosExt.TabIndex = 32
        Me.mkPagosExt.Text = "0.0000"
        Me.mkPagosExt.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(392, 56)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(102, 13)
        Me.Label48.TabIndex = 37
        Me.Label48.Text = "Otros Servicios S/. :"
        '
        'mkTotalAgencia
        '
        Me.mkTotalAgencia.DecimalDigits = 4
        Me.mkTotalAgencia.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTotalAgencia.Enabled = False
        Me.mkTotalAgencia.Location = New System.Drawing.Point(753, 52)
        Me.mkTotalAgencia.Name = "mkTotalAgencia"
        Me.mkTotalAgencia.Size = New System.Drawing.Size(142, 20)
        Me.mkTotalAgencia.TabIndex = 29
        Me.mkTotalAgencia.Text = "0.0000"
        Me.mkTotalAgencia.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(601, 56)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(152, 13)
        Me.Label38.TabIndex = 24
        Me.Label38.Text = "Total Gastos AG.Aduana. S/. :"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(212, 56)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(73, 13)
        Me.Label47.TabIndex = 36
        Me.Label47.Text = "Handling S/. :"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(2, 56)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(110, 13)
        Me.Label46.TabIndex = 35
        Me.Label46.Text = "Pagos al Exterior S/. :"
        '
        'mkOtrosServ
        '
        Me.mkOtrosServ.DecimalDigits = 4
        Me.mkOtrosServ.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkOtrosServ.Location = New System.Drawing.Point(496, 51)
        Me.mkOtrosServ.Name = "mkOtrosServ"
        Me.mkOtrosServ.Size = New System.Drawing.Size(97, 20)
        Me.mkOtrosServ.TabIndex = 34
        Me.mkOtrosServ.Text = "0.0000"
        Me.mkOtrosServ.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkHandling
        '
        Me.mkHandling.DecimalDigits = 4
        Me.mkHandling.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkHandling.Location = New System.Drawing.Point(287, 51)
        Me.mkHandling.Name = "mkHandling"
        Me.mkHandling.Size = New System.Drawing.Size(97, 20)
        Me.mkHandling.TabIndex = 33
        Me.mkHandling.Text = "0.0000"
        Me.mkHandling.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkResguardo
        '
        Me.mkResguardo.DecimalDigits = 4
        Me.mkResguardo.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkResguardo.Location = New System.Drawing.Point(592, 30)
        Me.mkResguardo.Name = "mkResguardo"
        Me.mkResguardo.Size = New System.Drawing.Size(97, 20)
        Me.mkResguardo.TabIndex = 31
        Me.mkResguardo.Text = "0.0000"
        Me.mkResguardo.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(507, 32)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(83, 13)
        Me.Label45.TabIndex = 30
        Me.Label45.Text = "Resguardo S/. :"
        '
        'mkOtroGastos
        '
        Me.mkOtroGastos.DecimalDigits = 4
        Me.mkOtroGastos.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkOtroGastos.Location = New System.Drawing.Point(340, 30)
        Me.mkOtroGastos.Name = "mkOtroGastos"
        Me.mkOtroGastos.Size = New System.Drawing.Size(101, 20)
        Me.mkOtroGastos.TabIndex = 28
        Me.mkOtroGastos.Text = "0.0000"
        Me.mkOtroGastos.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkTranspLocal
        '
        Me.mkTranspLocal.DecimalDigits = 4
        Me.mkTranspLocal.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTranspLocal.Location = New System.Drawing.Point(103, 30)
        Me.mkTranspLocal.Name = "mkTranspLocal"
        Me.mkTranspLocal.Size = New System.Drawing.Size(97, 20)
        Me.mkTranspLocal.TabIndex = 27
        Me.mkTranspLocal.Text = "0.0000"
        Me.mkTranspLocal.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkGastoAgencia
        '
        Me.mkGastoAgencia.DecimalDigits = 4
        Me.mkGastoAgencia.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkGastoAgencia.Location = New System.Drawing.Point(592, 9)
        Me.mkGastoAgencia.Name = "mkGastoAgencia"
        Me.mkGastoAgencia.Size = New System.Drawing.Size(109, 20)
        Me.mkGastoAgencia.TabIndex = 26
        Me.mkGastoAgencia.Text = "0.0000"
        Me.mkGastoAgencia.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkTerminal
        '
        Me.mkTerminal.DecimalDigits = 4
        Me.mkTerminal.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkTerminal.Location = New System.Drawing.Point(340, 9)
        Me.mkTerminal.Name = "mkTerminal"
        Me.mkTerminal.Size = New System.Drawing.Size(103, 20)
        Me.mkTerminal.TabIndex = 25
        Me.mkTerminal.Text = "0.0000"
        Me.mkTerminal.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkCarga
        '
        Me.mkCarga.DecimalDigits = 4
        Me.mkCarga.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkCarga.Location = New System.Drawing.Point(125, 9)
        Me.mkCarga.Name = "mkCarga"
        Me.mkCarga.Size = New System.Drawing.Size(95, 20)
        Me.mkCarga.TabIndex = 24
        Me.mkCarga.Text = "0.0000"
        Me.mkCarga.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(246, 35)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(92, 13)
        Me.Label37.TabIndex = 23
        Me.Label37.Text = "Otros Gastos S/. :"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(2, 35)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(96, 13)
        Me.Label36.TabIndex = 22
        Me.Label36.Text = "Transp. Local S/. :"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(449, 12)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(141, 13)
        Me.Label35.TabIndex = 21
        Me.Label35.Text = "Gasto Agencia Aduana S/. :"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(222, 12)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(115, 13)
        Me.Label34.TabIndex = 20
        Me.Label34.Text = "Terminal Almacen S/. :"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(3, 10)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(119, 13)
        Me.Label33.TabIndex = 19
        Me.Label33.Text = "Carga / Descarga S/.  :"
        '
        'frmDatosImportacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(950, 591)
        Me.ControlBox = False
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.txtSeguro)
        Me.Controls.Add(Me.btnBuscarProveedor)
        Me.Controls.Add(Me.ckApliSeg)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.mkSeguro)
        Me.Controls.Add(Me.mkVia)
        Me.Controls.Add(Me.mkSobretasa)
        Me.Controls.Add(Me.mkServicio)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.mkPtoEmb)
        Me.Controls.Add(Me.dgDetalle)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.mkIgvAdu)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.btnBuscarPais)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.mkFactorSol)
        Me.Controls.Add(Me.txtFactura)
        Me.Controls.Add(Me.mkCambio)
        Me.Controls.Add(Me.mkFactorDol)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.mkPeso)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.txtOrigen)
        Me.Controls.Add(Me.txtTransporte)
        Me.Controls.Add(Me.txtAduana)
        Me.Controls.Add(Me.txtIngreso)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFecDoc)
        Me.Controls.Add(Me.txtNumDoc)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDatosImportacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Factura de Importacion"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtFecDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtIngreso As System.Windows.Forms.TextBox
    Friend WithEvents txtAduana As System.Windows.Forms.TextBox
    Friend WithEvents txtTransporte As System.Windows.Forms.TextBox
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnBuscarPais As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmRefrescar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents mkFactorDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkFactorSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkPeso As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRecostear As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents mkTotFacturaSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkTotFacturaDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkDerAduSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkDerAduDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkTotFleteSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkTotFleteDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkTotFobGenSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkTotFobGenDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkOtroGastoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkOtroGastoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkNucleoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkNucleoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkGescomSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkGescomDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkFleIntSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkFleIntDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkTotFobSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkTotFobDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents mkSeguro As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkSobretasa As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkServicio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkAdvalorem As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkTotalIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkIgvAdu As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkIpm As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents txtPoliza As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dgDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRecalcular As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmRecalcular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ckApliSeg As System.Windows.Forms.CheckBox
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtSeguro As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents mkPtoEmb As System.Windows.Forms.TextBox
    Friend WithEvents mkVia As System.Windows.Forms.ComboBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents mkPagosExt As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label48 As Label
    Friend WithEvents mkTotalAgencia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents mkOtrosServ As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkHandling As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkResguardo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label45 As Label
    Friend WithEvents mkOtroGastos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkTranspLocal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkGastoAgencia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkTerminal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkCarga As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents mkMultas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As Label
    Friend WithEvents mkPercepcion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents btnMostrarGastos As Button
End Class
