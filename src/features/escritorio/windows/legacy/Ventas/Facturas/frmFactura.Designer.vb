<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactura
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
        Dim cmbIdCotizacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFactura))
        Dim cmbIdFiscal_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodPag_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocCli_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMot_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoDetraccion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoAfectacionIgv_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmbIdCotizacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumGuis = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbIdFiscal = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbCodPag = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnModificarObservacion = New System.Windows.Forms.Button()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTotEmbarque = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotFlete = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbIdLocCli = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodMot = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSugerir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator101 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator102 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSugerir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator104 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biTransportista = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActMoneda = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.gbCabecera = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarCliente = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoDetraccion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbAfectoDetraccion = New System.Windows.Forms.CheckBox()
        Me.cmbTipoAfectacionIgv = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnAgregarDirFiscal = New System.Windows.Forms.Button()
        Me.btnAgregarLocacion = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtNum_Orden = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.btnGuias = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalNetoSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalIgvSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalNeto = New System.Windows.Forms.TextBox()
        Me.lbltotalIGV = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.TextBox()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalIGV = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblLocacion = New System.Windows.Forms.Label()
        CType(Me.cmbIdCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cmbIdLocCli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gbCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCabecera.SuspendLayout()
        CType(Me.cmbTipoDetraccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoAfectacionIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbIdCotizacion
        '
        Me.cmbIdCotizacion.BackColor = System.Drawing.SystemColors.Control
        Me.cmbIdCotizacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdCotizacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdCotizacion_DesignTimeLayout.LayoutString")
        Me.cmbIdCotizacion.DesignTimeLayout = cmbIdCotizacion_DesignTimeLayout
        Me.cmbIdCotizacion.Location = New System.Drawing.Point(585, 83)
        Me.cmbIdCotizacion.Name = "cmbIdCotizacion"
        Me.cmbIdCotizacion.ReadOnly = True
        Me.cmbIdCotizacion.SelectedIndex = -1
        Me.cmbIdCotizacion.SelectedItem = Nothing
        Me.cmbIdCotizacion.Size = New System.Drawing.Size(80, 20)
        Me.cmbIdCotizacion.TabIndex = 27
        Me.cmbIdCotizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumGuis
        '
        Me.txtNumGuis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumGuis.Enabled = False
        Me.txtNumGuis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumGuis.Location = New System.Drawing.Point(79, 83)
        Me.txtNumGuis.MaxLength = 30
        Me.txtNumGuis.Name = "txtNumGuis"
        Me.txtNumGuis.ReadOnly = True
        Me.txtNumGuis.Size = New System.Drawing.Size(169, 20)
        Me.txtNumGuis.TabIndex = 23
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Guías :"
        '
        'cmbIdFiscal
        '
        Me.cmbIdFiscal.BackColor = System.Drawing.SystemColors.Control
        Me.cmbIdFiscal.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdFiscal_DesignTimeLayout.LayoutString = resources.GetString("cmbIdFiscal_DesignTimeLayout.LayoutString")
        Me.cmbIdFiscal.DesignTimeLayout = cmbIdFiscal_DesignTimeLayout
        Me.cmbIdFiscal.Location = New System.Drawing.Point(79, 61)
        Me.cmbIdFiscal.Name = "cmbIdFiscal"
        Me.cmbIdFiscal.ReadOnly = True
        Me.cmbIdFiscal.SelectedIndex = -1
        Me.cmbIdFiscal.SelectedItem = Nothing
        Me.cmbIdFiscal.Size = New System.Drawing.Size(291, 20)
        Me.cmbIdFiscal.TabIndex = 19
        Me.cmbIdFiscal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Dir. Fiscal :"
        '
        'cmbCodPag
        '
        Me.cmbCodPag.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodPag.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodPag_DesignTimeLayout.LayoutString = resources.GetString("cmbCodPag_DesignTimeLayout.LayoutString")
        Me.cmbCodPag.DesignTimeLayout = cmbCodPag_DesignTimeLayout
        Me.cmbCodPag.Location = New System.Drawing.Point(343, 83)
        Me.cmbCodPag.Name = "cmbCodPag"
        Me.cmbCodPag.ReadOnly = True
        Me.cmbCodPag.SelectedIndex = -1
        Me.cmbCodPag.SelectedItem = Nothing
        Me.cmbCodPag.Size = New System.Drawing.Size(178, 20)
        Me.cmbCodPag.TabIndex = 25
        Me.cmbCodPag.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(275, 86)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Con.Pag. :"
        '
        'btnModificarObservacion
        '
        Me.btnModificarObservacion.Image = CType(resources.GetObject("btnModificarObservacion.Image"), System.Drawing.Image)
        Me.btnModificarObservacion.Location = New System.Drawing.Point(625, 105)
        Me.btnModificarObservacion.Name = "btnModificarObservacion"
        Me.btnModificarObservacion.Size = New System.Drawing.Size(25, 22)
        Me.btnModificarObservacion.TabIndex = 31
        Me.btnModificarObservacion.TabStop = False
        Me.btnModificarObservacion.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(93, 105)
        Me.txtObservacion.MaxLength = 250
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(532, 35)
        Me.txtObservacion.TabIndex = 29
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox2.Controls.Add(Me.txtTotEmbarque)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtTotFlete)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(679, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(156, 66)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gastos Adicionales"
        '
        'txtTotEmbarque
        '
        Me.txtTotEmbarque.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotEmbarque.Location = New System.Drawing.Point(76, 40)
        Me.txtTotEmbarque.MaxLength = 12
        Me.txtTotEmbarque.Name = "txtTotEmbarque"
        Me.txtTotEmbarque.ReadOnly = True
        Me.txtTotEmbarque.Size = New System.Drawing.Size(76, 20)
        Me.txtTotEmbarque.TabIndex = 35
        Me.txtTotEmbarque.Text = "0.00"
        Me.txtTotEmbarque.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotEmbarque.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Embarque :"
        '
        'txtTotFlete
        '
        Me.txtTotFlete.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotFlete.Location = New System.Drawing.Point(52, 15)
        Me.txtTotFlete.MaxLength = 12
        Me.txtTotFlete.Name = "txtTotFlete"
        Me.txtTotFlete.ReadOnly = True
        Me.txtTotFlete.Size = New System.Drawing.Size(76, 20)
        Me.txtTotFlete.TabIndex = 33
        Me.txtTotFlete.Text = "0.00"
        Me.txtTotFlete.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotFlete.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Flete :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(5, 109)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(86, 13)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "Observación :"
        '
        'cmbIdLocCli
        '
        Me.cmbIdLocCli.BackColor = System.Drawing.SystemColors.Control
        Me.cmbIdLocCli.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocCli_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocCli_DesignTimeLayout.LayoutString")
        Me.cmbIdLocCli.DesignTimeLayout = cmbIdLocCli_DesignTimeLayout
        Me.cmbIdLocCli.FlatBorderColor = System.Drawing.SystemColors.Desktop
        Me.cmbIdLocCli.Location = New System.Drawing.Point(476, 39)
        Me.cmbIdLocCli.Name = "cmbIdLocCli"
        Me.cmbIdLocCli.ReadOnly = True
        Me.cmbIdLocCli.SelectedIndex = -1
        Me.cmbIdLocCli.SelectedItem = Nothing
        Me.cmbIdLocCli.Size = New System.Drawing.Size(189, 20)
        Me.cmbIdLocCli.TabIndex = 15
        Me.cmbIdLocCli.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodMot
        '
        Me.cmbCodMot.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodMot.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMot_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMot_DesignTimeLayout.LayoutString")
        Me.cmbCodMot.DesignTimeLayout = cmbCodMot_DesignTimeLayout
        Me.cmbCodMot.FlatBorderColor = System.Drawing.SystemColors.Desktop
        Me.cmbCodMot.Location = New System.Drawing.Point(450, 61)
        Me.cmbCodMot.Name = "cmbCodMot"
        Me.cmbCodMot.ReadOnly = True
        Me.cmbCodMot.SelectedIndex = -1
        Me.cmbCodMot.SelectedItem = Nothing
        Me.cmbCodMot.Size = New System.Drawing.Size(215, 20)
        Me.cmbCodMot.TabIndex = 21
        Me.cmbCodMot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(394, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Motivo :"
        '
        'txtNumJob
        '
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtNumJob.Location = New System.Drawing.Point(740, 42)
        Me.txtNumJob.MaxLength = 7
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.ReadOnly = True
        Me.txtNumJob.Size = New System.Drawing.Size(70, 20)
        Me.txtNumJob.TabIndex = 17
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtIgv.Location = New System.Drawing.Point(479, 17)
        Me.txtIgv.MaxLength = 12
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(42, 20)
        Me.txtIgv.TabIndex = 7
        Me.txtIgv.TabStop = False
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(430, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "I.G.V. :"
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(810, 41)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 18
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'cmbCodMon
        '
        Me.cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(369, 17)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.ReadOnly = True
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(58, 20)
        Me.cmbCodMon.TabIndex = 5
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(693, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "# OT :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTipoCambio.Location = New System.Drawing.Point(602, 17)
        Me.txtTipoCambio.MaxLength = 20
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(47, 20)
        Me.txtTipoCambio.TabIndex = 9
        Me.txtTipoCambio.TabStop = False
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(66, 39)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(291, 20)
        Me.txtCliente.TabIndex = 11
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(161, 20)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(50, 13)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "Fecha :"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(356, 38)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 13
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtFecDoc
        '
        Me.txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Location = New System.Drawing.Point(211, 17)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.ReadOnly = True
        Me.txtFecDoc.Size = New System.Drawing.Size(92, 20)
        Me.txtFecDoc.TabIndex = 3
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(684, 10)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(150, 28)
        Me.gbEstado.TabIndex = 26
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(8, 9)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(136, 16)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(307, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Moneda :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Cliente :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(526, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Tip.Cam. :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(410, 42)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Loc.Clie. :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(523, 86)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Cotizas. :"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSugerir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 120)
        '
        'miSugerir
        '
        Me.miSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.miSugerir.Name = "miSugerir"
        Me.miSugerir.Size = New System.Drawing.Size(126, 22)
        Me.miSugerir.Text = "Sugerir"
        Me.miSugerir.ToolTipText = "Sugerir Precio/Dscto"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Modificar"
        Me.miMostrar.ToolTipText = "Editar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Detalle"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 648)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(877, 20)
        Me.ssBarra.TabIndex = 3
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
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator101, Me.biEditar, Me.ToolStripSeparator102, Me.biSugerir, Me.ToolStripSeparator1, Me.biGrabar, Me.ToolStripSeparator104, Me.biDeshacer, Me.ToolStripSeparator2, Me.biTransportista, Me.ToolStripSeparator3, Me.biActMoneda, Me.ToolStripSeparator4, Me.biSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(877, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator101
        '
        Me.ToolStripSeparator101.Name = "ToolStripSeparator101"
        Me.ToolStripSeparator101.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar"
        '
        'ToolStripSeparator102
        '
        Me.ToolStripSeparator102.Name = "ToolStripSeparator102"
        Me.ToolStripSeparator102.Size = New System.Drawing.Size(6, 31)
        '
        'biSugerir
        '
        Me.biSugerir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.biSugerir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSugerir.Name = "biSugerir"
        Me.biSugerir.Size = New System.Drawing.Size(28, 28)
        Me.biSugerir.ToolTipText = "Sugerir Precio"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biGrabar
        '
        Me.biGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGrabar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGrabar.Name = "biGrabar"
        Me.biGrabar.Size = New System.Drawing.Size(28, 28)
        Me.biGrabar.Text = "Grabar"
        '
        'ToolStripSeparator104
        '
        Me.ToolStripSeparator104.Name = "ToolStripSeparator104"
        Me.ToolStripSeparator104.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biTransportista
        '
        Me.biTransportista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biTransportista.Image = Global.SIGECOM.My.Resources.Resources.Transporte
        Me.biTransportista.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biTransportista.Name = "biTransportista"
        Me.biTransportista.Size = New System.Drawing.Size(28, 28)
        Me.biTransportista.Text = " Transportista"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biActMoneda
        '
        Me.biActMoneda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActMoneda.Image = Global.SIGECOM.My.Resources.Resources.Moneda
        Me.biActMoneda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActMoneda.Name = "biActMoneda"
        Me.biActMoneda.Size = New System.Drawing.Size(28, 28)
        Me.biActMoneda.Text = "Actualizar Moneda de Factura"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Salir"
        '
        'gbCabecera
        '
        Me.gbCabecera.Controls.Add(Me.btnAgregarCliente)
        Me.gbCabecera.Controls.Add(Me.Label19)
        Me.gbCabecera.Controls.Add(Me.cmbTipoDetraccion)
        Me.gbCabecera.Controls.Add(Me.cbAfectoDetraccion)
        Me.gbCabecera.Controls.Add(Me.cmbTipoAfectacionIgv)
        Me.gbCabecera.Controls.Add(Me.Label17)
        Me.gbCabecera.Controls.Add(Me.btnAgregarDirFiscal)
        Me.gbCabecera.Controls.Add(Me.btnAgregarLocacion)
        Me.gbCabecera.Controls.Add(Me.Label3)
        Me.gbCabecera.Controls.Add(Me.Label7)
        Me.gbCabecera.Controls.Add(Me.txtVendedor)
        Me.gbCabecera.Controls.Add(Me.txtNum_Orden)
        Me.gbCabecera.Controls.Add(Me.Label1)
        Me.gbCabecera.Controls.Add(Me.txtNumDoc)
        Me.gbCabecera.Controls.Add(Me.GroupBox2)
        Me.gbCabecera.Controls.Add(Me.btnGuias)
        Me.gbCabecera.Controls.Add(Me.cmbIdCotizacion)
        Me.gbCabecera.Controls.Add(Me.txtNumGuis)
        Me.gbCabecera.Controls.Add(Me.Label16)
        Me.gbCabecera.Controls.Add(Me.Label15)
        Me.gbCabecera.Controls.Add(Me.Label11)
        Me.gbCabecera.Controls.Add(Me.cmbIdFiscal)
        Me.gbCabecera.Controls.Add(Me.Label14)
        Me.gbCabecera.Controls.Add(Me.Label9)
        Me.gbCabecera.Controls.Add(Me.cmbCodPag)
        Me.gbCabecera.Controls.Add(Me.Label13)
        Me.gbCabecera.Controls.Add(Me.Label12)
        Me.gbCabecera.Controls.Add(Me.btnModificarObservacion)
        Me.gbCabecera.Controls.Add(Me.Label2)
        Me.gbCabecera.Controls.Add(Me.txtObservacion)
        Me.gbCabecera.Controls.Add(Me.gbEstado)
        Me.gbCabecera.Controls.Add(Me.Label21)
        Me.gbCabecera.Controls.Add(Me.cmbIdLocCli)
        Me.gbCabecera.Controls.Add(Me.txtFecDoc)
        Me.gbCabecera.Controls.Add(Me.cmbCodMot)
        Me.gbCabecera.Controls.Add(Me.btnBuscarCliente)
        Me.gbCabecera.Controls.Add(Me.Label5)
        Me.gbCabecera.Controls.Add(Me.lblFecha)
        Me.gbCabecera.Controls.Add(Me.txtCliente)
        Me.gbCabecera.Controls.Add(Me.txtTipoCambio)
        Me.gbCabecera.Controls.Add(Me.txtNumJob)
        Me.gbCabecera.Controls.Add(Me.Label4)
        Me.gbCabecera.Controls.Add(Me.txtIgv)
        Me.gbCabecera.Controls.Add(Me.cmbCodMon)
        Me.gbCabecera.Controls.Add(Me.Label10)
        Me.gbCabecera.Controls.Add(Me.btnBuscarJob)
        Me.gbCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbCabecera.Location = New System.Drawing.Point(0, 31)
        Me.gbCabecera.Name = "gbCabecera"
        Me.gbCabecera.Size = New System.Drawing.Size(877, 196)
        Me.gbCabecera.TabIndex = 1
        Me.gbCabecera.Text = " [  Cabecera  ] "
        Me.gbCabecera.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        '
        'btnAgregarCliente
        '
        Me.btnAgregarCliente.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnAgregarCliente.Location = New System.Drawing.Point(383, 38)
        Me.btnAgregarCliente.Name = "btnAgregarCliente"
        Me.btnAgregarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarCliente.TabIndex = 300
        Me.btnAgregarCliente.TabStop = False
        Me.btnAgregarCliente.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(167, 173)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 299
        Me.Label19.Text = "Tipo(%)"
        '
        'cmbTipoDetraccion
        '
        Me.cmbTipoDetraccion.BackColor = System.Drawing.SystemColors.Control
        Me.cmbTipoDetraccion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDetraccion_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDetraccion_DesignTimeLayout.LayoutString")
        Me.cmbTipoDetraccion.DesignTimeLayout = cmbTipoDetraccion_DesignTimeLayout
        Me.cmbTipoDetraccion.Location = New System.Drawing.Point(217, 170)
        Me.cmbTipoDetraccion.Name = "cmbTipoDetraccion"
        Me.cmbTipoDetraccion.ReadOnly = True
        Me.cmbTipoDetraccion.SelectedIndex = -1
        Me.cmbTipoDetraccion.SelectedItem = Nothing
        Me.cmbTipoDetraccion.Size = New System.Drawing.Size(62, 20)
        Me.cmbTipoDetraccion.TabIndex = 298
        Me.cmbTipoDetraccion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbAfectoDetraccion
        '
        Me.cbAfectoDetraccion.AutoSize = True
        Me.cbAfectoDetraccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbAfectoDetraccion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAfectoDetraccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbAfectoDetraccion.ForeColor = System.Drawing.Color.Black
        Me.cbAfectoDetraccion.Location = New System.Drawing.Point(13, 171)
        Me.cbAfectoDetraccion.Name = "cbAfectoDetraccion"
        Me.cbAfectoDetraccion.Size = New System.Drawing.Size(147, 17)
        Me.cbAfectoDetraccion.TabIndex = 297
        Me.cbAfectoDetraccion.Text = "Afecto a Detracción?"
        Me.cbAfectoDetraccion.UseVisualStyleBackColor = False
        '
        'cmbTipoAfectacionIgv
        '
        Me.cmbTipoAfectacionIgv.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoAfectacionIgv_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoAfectacionIgv_DesignTimeLayout.LayoutString")
        Me.cmbTipoAfectacionIgv.DesignTimeLayout = cmbTipoAfectacionIgv_DesignTimeLayout
        Me.cmbTipoAfectacionIgv.Location = New System.Drawing.Point(650, 142)
        Me.cmbTipoAfectacionIgv.Name = "cmbTipoAfectacionIgv"
        Me.cmbTipoAfectacionIgv.SelectedIndex = -1
        Me.cmbTipoAfectacionIgv.SelectedItem = Nothing
        Me.cmbTipoAfectacionIgv.Size = New System.Drawing.Size(162, 20)
        Me.cmbTipoAfectacionIgv.TabIndex = 47
        Me.cmbTipoAfectacionIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(522, 146)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(127, 13)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Tipo Afectacion Igv :"
        '
        'btnAgregarDirFiscal
        '
        Me.btnAgregarDirFiscal.Image = Global.SIGECOM.My.Resources.Resources.Office
        Me.btnAgregarDirFiscal.Location = New System.Drawing.Point(370, 60)
        Me.btnAgregarDirFiscal.Name = "btnAgregarDirFiscal"
        Me.btnAgregarDirFiscal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAgregarDirFiscal.Size = New System.Drawing.Size(23, 22)
        Me.btnAgregarDirFiscal.TabIndex = 45
        Me.btnAgregarDirFiscal.TabStop = False
        Me.btnAgregarDirFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarDirFiscal.UseVisualStyleBackColor = True
        '
        'btnAgregarLocacion
        '
        Me.btnAgregarLocacion.Image = Global.SIGECOM.My.Resources.Resources.Empresa
        Me.btnAgregarLocacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarLocacion.Location = New System.Drawing.Point(665, 38)
        Me.btnAgregarLocacion.Name = "btnAgregarLocacion"
        Me.btnAgregarLocacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAgregarLocacion.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarLocacion.TabIndex = 44
        Me.btnAgregarLocacion.TabStop = False
        Me.btnAgregarLocacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarLocacion.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(232, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Vendedor :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 146)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "O/C :"
        '
        'txtVendedor
        '
        Me.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtVendedor.Location = New System.Drawing.Point(304, 143)
        Me.txtVendedor.MaxLength = 20
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(208, 20)
        Me.txtVendedor.TabIndex = 41
        Me.txtVendedor.TabStop = False
        '
        'txtNum_Orden
        '
        Me.txtNum_Orden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNum_Orden.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtNum_Orden.Location = New System.Drawing.Point(65, 143)
        Me.txtNum_Orden.MaxLength = 70
        Me.txtNum_Orden.Name = "txtNum_Orden"
        Me.txtNum_Orden.ReadOnly = True
        Me.txtNum_Orden.Size = New System.Drawing.Size(154, 20)
        Me.txtNum_Orden.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Número :"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.Color.Beige
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(66, 17)
        Me.txtNumDoc.MaxLength = 200
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(93, 20)
        Me.txtNumDoc.TabIndex = 1
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGuias
        '
        Me.btnGuias.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnGuias.Location = New System.Drawing.Point(248, 82)
        Me.btnGuias.Name = "btnGuias"
        Me.btnGuias.Size = New System.Drawing.Size(25, 22)
        Me.btnGuias.TabIndex = 23
        Me.btnGuias.TabStop = False
        Me.btnGuias.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox1.Controls.Add(Me.dgvDatos)
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 227)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(833, 374)
        Me.UiGroupBox1.TabIndex = 4
        Me.UiGroupBox1.Text = "Detalles"
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(4, 19)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(821, 273)
        Me.dgvDatos.TabIndex = 8
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox2.Controls.Add(Me.txtTotalNetoSug)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalIgvSug)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalSug)
        Me.UiGroupBox2.Controls.Add(Me.lblTotalNeto)
        Me.UiGroupBox2.Controls.Add(Me.lbltotalIGV)
        Me.UiGroupBox2.Controls.Add(Me.lblTotal)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalNeto)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalIGV)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalPrecio)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalDescuento)
        Me.UiGroupBox2.Controls.Add(Me.txtTotal)
        Me.UiGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox2.Location = New System.Drawing.Point(3, 298)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(827, 73)
        Me.UiGroupBox2.TabIndex = 7
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalNetoSug
        '
        Me.txtTotalNetoSug.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNetoSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNetoSug.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNetoSug.Location = New System.Drawing.Point(715, 49)
        Me.txtTotalNetoSug.MaxLength = 5
        Me.txtTotalNetoSug.Name = "txtTotalNetoSug"
        Me.txtTotalNetoSug.ReadOnly = True
        Me.txtTotalNetoSug.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalNetoSug.TabIndex = 10
        Me.txtTotalNetoSug.TabStop = False
        Me.txtTotalNetoSug.Text = "0.00"
        Me.txtTotalNetoSug.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNetoSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNetoSug.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalIgvSug
        '
        Me.txtTotalIgvSug.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalIgvSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIgvSug.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalIgvSug.Location = New System.Drawing.Point(715, 30)
        Me.txtTotalIgvSug.MaxLength = 5
        Me.txtTotalIgvSug.Name = "txtTotalIgvSug"
        Me.txtTotalIgvSug.ReadOnly = True
        Me.txtTotalIgvSug.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalIgvSug.TabIndex = 9
        Me.txtTotalIgvSug.TabStop = False
        Me.txtTotalIgvSug.Text = "0.00"
        Me.txtTotalIgvSug.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalIgvSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIgvSug.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalSug
        '
        Me.txtTotalSug.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSug.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalSug.Location = New System.Drawing.Point(715, 11)
        Me.txtTotalSug.MaxLength = 5
        Me.txtTotalSug.Name = "txtTotalSug"
        Me.txtTotalSug.ReadOnly = True
        Me.txtTotalSug.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalSug.TabIndex = 8
        Me.txtTotalSug.TabStop = False
        Me.txtTotalSug.Text = "0.00"
        Me.txtTotalSug.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalSug.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalNeto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalNeto.Location = New System.Drawing.Point(24, 49)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(602, 20)
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
        Me.lbltotalIGV.Location = New System.Drawing.Point(24, 30)
        Me.lbltotalIGV.MaxLength = 20
        Me.lbltotalIGV.Name = "lbltotalIGV"
        Me.lbltotalIGV.ReadOnly = True
        Me.lbltotalIGV.Size = New System.Drawing.Size(602, 20)
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
        Me.lblTotal.Location = New System.Drawing.Point(24, 11)
        Me.lblTotal.MaxLength = 20
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.ReadOnly = True
        Me.lblTotal.Size = New System.Drawing.Size(433, 20)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNeto.Location = New System.Drawing.Point(626, 49)
        Me.txtTotalNeto.MaxLength = 5
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(90, 20)
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
        Me.txtTotalIGV.Location = New System.Drawing.Point(626, 30)
        Me.txtTotalIGV.MaxLength = 5
        Me.txtTotalIGV.Name = "txtTotalIGV"
        Me.txtTotalIGV.ReadOnly = True
        Me.txtTotalIGV.Size = New System.Drawing.Size(90, 20)
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
        Me.txtTotalPrecio.Location = New System.Drawing.Point(457, 11)
        Me.txtTotalPrecio.MaxLength = 5
        Me.txtTotalPrecio.Name = "txtTotalPrecio"
        Me.txtTotalPrecio.ReadOnly = True
        Me.txtTotalPrecio.Size = New System.Drawing.Size(91, 20)
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
        Me.txtTotalDescuento.Location = New System.Drawing.Point(547, 11)
        Me.txtTotalDescuento.MaxLength = 5
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(80, 20)
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
        Me.txtTotal.Location = New System.Drawing.Point(626, 11)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(90, 20)
        Me.txtTotal.TabIndex = 5
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblLocacion
        '
        Me.lblLocacion.AutoSize = True
        Me.lblLocacion.Location = New System.Drawing.Point(437, 12)
        Me.lblLocacion.Name = "lblLocacion"
        Me.lblLocacion.Size = New System.Drawing.Size(107, 13)
        Me.lblLocacion.TabIndex = 5
        Me.lblLocacion.Text = "Oficina - Almacen"
        '
        'frmFactura
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(877, 668)
        Me.Controls.Add(Me.lblLocacion)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gbCabecera)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ssBarra)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFactura"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmFactura"
        CType(Me.cmbIdCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cmbIdLocCli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gbCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCabecera.ResumeLayout(False)
        Me.gbCabecera.PerformLayout()
        CType(Me.cmbTipoDetraccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoAfectacionIgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnModificarObservacion As System.Windows.Forms.Button
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocCli As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCodMot As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotEmbarque As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotFlete As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbCodPag As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbIdFiscal As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNumGuis As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbIdCotizacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator101 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator102 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator104 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbCabecera As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnGuias As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents lblLocacion As System.Windows.Forms.Label
    Friend WithEvents biSugerir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miSugerir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalNetoSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalIgvSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalIGV As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalIGV As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents biTransportista As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtNum_Orden As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregarDirFiscal As System.Windows.Forms.Button
    Friend WithEvents btnAgregarLocacion As System.Windows.Forms.Button
    Friend WithEvents biActMoneda As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoAfectacionIgv As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label19 As Label
    Friend WithEvents cmbTipoDetraccion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbAfectoDetraccion As CheckBox
    Friend WithEvents btnAgregarCliente As Button
End Class
