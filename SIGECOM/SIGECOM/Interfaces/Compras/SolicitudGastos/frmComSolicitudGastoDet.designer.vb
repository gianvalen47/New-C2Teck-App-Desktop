<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmComSolicitudGastoDet
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
        Dim cmbTipoGasto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMedio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTarifaViaje_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCondPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbSubRubroViaje_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbRubroViaje_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbPlaca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudGastoDet))
        Dim dgvCentrosCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvJos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtObservTipoGasto = New System.Windows.Forms.TextBox()
        Me.lblTipoGasto = New System.Windows.Forms.Label()
        Me.cmbTipoGasto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbMedio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbFacturacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtTipCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.biLimpiarPdf = New Janus.Windows.EditControls.UIButton()
        Me.biLimpiarXml = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarPdf = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPdfFE = New System.Windows.Forms.TextBox()
        Me.btnBuscarXml = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtXmlFE = New System.Windows.Forms.TextBox()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtSerieDoc = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbProveedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbAplicaCosto = New System.Windows.Forms.CheckBox()
        Me.btnLimpiarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbTarifaViaje = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnAgregarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.txtItem = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbCondPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.txtCodEmbarque = New System.Windows.Forms.TextBox()
        Me.gbGastoViaje = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbNoAplicaPolitica = New System.Windows.Forms.CheckBox()
        Me.txtObservSubRubro = New System.Windows.Forms.TextBox()
        Me.cmbSubRubroViaje = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbRubroViaje = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbPlaca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.bgMontos = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtMontoIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtMontoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtMontoNoAfecto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbAfectoIgv = New System.Windows.Forms.CheckBox()
        Me.txtMontoSinIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.cmbRubro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtPersona = New System.Windows.Forms.TextBox()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.txtCodCuenta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtJustificacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmOpcionesCentrosCosto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAsignarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbCentroCosto = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvCentrosCosto = New Janus.Windows.GridEX.GridEX()
        Me.gbJobs = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvJos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesJobs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAsignarJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.miProcesarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarCompras = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.cmbTipoGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFacturacion.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        CType(Me.cmbTarifaViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCondPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGastoViaje.SuspendLayout()
        CType(Me.cmbSubRubroViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbRubroViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgMontos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bgMontos.SuspendLayout()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesCentrosCosto.SuspendLayout()
        CType(Me.gbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCentroCosto.SuspendLayout()
        CType(Me.dgvCentrosCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbJobs.SuspendLayout()
        CType(Me.dgvJos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesJobs.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.txtObservTipoGasto)
        Me.gbDetalle.Controls.Add(Me.lblTipoGasto)
        Me.gbDetalle.Controls.Add(Me.cmbTipoGasto)
        Me.gbDetalle.Controls.Add(Me.cmbMedio)
        Me.gbDetalle.Controls.Add(Me.Label13)
        Me.gbDetalle.Controls.Add(Me.UiGroupBox1)
        Me.gbDetalle.Controls.Add(Me.txtCodEmbarque)
        Me.gbDetalle.Controls.Add(Me.gbGastoViaje)
        Me.gbDetalle.Controls.Add(Me.bgMontos)
        Me.gbDetalle.Controls.Add(Me.lblRubro)
        Me.gbDetalle.Controls.Add(Me.cmbRubro)
        Me.gbDetalle.Controls.Add(Me.Label20)
        Me.gbDetalle.Controls.Add(Me.txtPersona)
        Me.gbDetalle.Controls.Add(Me.btnBuscarPersona)
        Me.gbDetalle.Controls.Add(Me.txtCodCuenta)
        Me.gbDetalle.Controls.Add(Me.Label3)
        Me.gbDetalle.Controls.Add(Me.txtJustificacion)
        Me.gbDetalle.Controls.Add(Me.Label2)
        Me.gbDetalle.Controls.Add(Me.txtDescripcion)
        Me.gbDetalle.Controls.Add(Me.txtCantidad)
        Me.gbDetalle.Controls.Add(Me.Label7)
        Me.gbDetalle.Controls.Add(Me.Label1)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(5, 25)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(658, 416)
        Me.gbDetalle.TabIndex = 185
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtObservTipoGasto
        '
        Me.txtObservTipoGasto.ForeColor = System.Drawing.Color.Brown
        Me.txtObservTipoGasto.Location = New System.Drawing.Point(5, 30)
        Me.txtObservTipoGasto.Multiline = True
        Me.txtObservTipoGasto.Name = "txtObservTipoGasto"
        Me.txtObservTipoGasto.ReadOnly = True
        Me.txtObservTipoGasto.Size = New System.Drawing.Size(648, 20)
        Me.txtObservTipoGasto.TabIndex = 288
        Me.txtObservTipoGasto.TabStop = False
        '
        'lblTipoGasto
        '
        Me.lblTipoGasto.AutoSize = True
        Me.lblTipoGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoGasto.Location = New System.Drawing.Point(235, 12)
        Me.lblTipoGasto.Name = "lblTipoGasto"
        Me.lblTipoGasto.Size = New System.Drawing.Size(69, 13)
        Me.lblTipoGasto.TabIndex = 286
        Me.lblTipoGasto.Text = "Tipo Gasto"
        '
        'cmbTipoGasto
        '
        Me.cmbTipoGasto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoGasto_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoGasto_DesignTimeLayout.LayoutString")
        Me.cmbTipoGasto.DesignTimeLayout = cmbTipoGasto_DesignTimeLayout
        Me.cmbTipoGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoGasto.Location = New System.Drawing.Point(306, 9)
        Me.cmbTipoGasto.Name = "cmbTipoGasto"
        Me.cmbTipoGasto.SelectedIndex = -1
        Me.cmbTipoGasto.SelectedItem = Nothing
        Me.cmbTipoGasto.Size = New System.Drawing.Size(120, 20)
        Me.cmbTipoGasto.TabIndex = 285
        Me.cmbTipoGasto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbMedio
        '
        Me.cmbMedio.BackColor = System.Drawing.SystemColors.Control
        Me.cmbMedio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMedio_DesignTimeLayout.LayoutString = resources.GetString("cmbMedio_DesignTimeLayout.LayoutString")
        Me.cmbMedio.DesignTimeLayout = cmbMedio_DesignTimeLayout
        Me.cmbMedio.Location = New System.Drawing.Point(587, 182)
        Me.cmbMedio.Name = "cmbMedio"
        Me.cmbMedio.ReadOnly = True
        Me.cmbMedio.SelectedIndex = -1
        Me.cmbMedio.SelectedItem = Nothing
        Me.cmbMedio.Size = New System.Drawing.Size(65, 20)
        Me.cmbMedio.TabIndex = 284
        Me.cmbMedio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(404, 184)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 283
        Me.Label13.Text = "Embarque"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.gbFacturacion)
        Me.UiGroupBox1.Controls.Add(Me.gbProveedor)
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 203)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(648, 148)
        Me.UiGroupBox1.TabIndex = 17
        Me.UiGroupBox1.Text = "DATOS DE FACTURACIÓN"
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbFacturacion
        '
        Me.gbFacturacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.gbFacturacion.Controls.Add(Me.Label28)
        Me.gbFacturacion.Controls.Add(Me.txtTipCambio)
        Me.gbFacturacion.Controls.Add(Me.biLimpiarPdf)
        Me.gbFacturacion.Controls.Add(Me.biLimpiarXml)
        Me.gbFacturacion.Controls.Add(Me.btnBuscarPdf)
        Me.gbFacturacion.Controls.Add(Me.Label26)
        Me.gbFacturacion.Controls.Add(Me.txtPdfFE)
        Me.gbFacturacion.Controls.Add(Me.btnBuscarXml)
        Me.gbFacturacion.Controls.Add(Me.Label14)
        Me.gbFacturacion.Controls.Add(Me.txtXmlFE)
        Me.gbFacturacion.Controls.Add(Me.txtFecDoc)
        Me.gbFacturacion.Controls.Add(Me.txtSerieDoc)
        Me.gbFacturacion.Controls.Add(Me.Label16)
        Me.gbFacturacion.Controls.Add(Me.txtNumDoc)
        Me.gbFacturacion.Controls.Add(Me.Label5)
        Me.gbFacturacion.Controls.Add(Me.Label15)
        Me.gbFacturacion.Controls.Add(Me.cmbTipoDoc)
        Me.gbFacturacion.Controls.Add(Me.Label6)
        Me.gbFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFacturacion.ForeColor = System.Drawing.Color.Black
        Me.gbFacturacion.Location = New System.Drawing.Point(4, 11)
        Me.gbFacturacion.Name = "gbFacturacion"
        Me.gbFacturacion.Size = New System.Drawing.Size(640, 78)
        Me.gbFacturacion.TabIndex = 21
        Me.gbFacturacion.Text = "Facturación"
        Me.gbFacturacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(565, 57)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(31, 13)
        Me.Label28.TabIndex = 255
        Me.Label28.Text = "T.C."
        '
        'txtTipCambio
        '
        Me.txtTipCambio.BackColor = System.Drawing.SystemColors.Control
        Me.txtTipCambio.DecimalDigits = 3
        Me.txtTipCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCambio.Location = New System.Drawing.Point(598, 54)
        Me.txtTipCambio.MaxLength = 10
        Me.txtTipCambio.Name = "txtTipCambio"
        Me.txtTipCambio.ReadOnly = True
        Me.txtTipCambio.Size = New System.Drawing.Size(38, 20)
        Me.txtTipCambio.TabIndex = 254
        Me.txtTipCambio.TabStop = False
        Me.txtTipCambio.Text = "0.000"
        Me.txtTipCambio.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtTipCambio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'biLimpiarPdf
        '
        Me.biLimpiarPdf.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.biLimpiarPdf.Location = New System.Drawing.Point(612, 9)
        Me.biLimpiarPdf.Name = "biLimpiarPdf"
        Me.biLimpiarPdf.Size = New System.Drawing.Size(25, 22)
        Me.biLimpiarPdf.TabIndex = 253
        Me.biLimpiarPdf.TabStop = False
        Me.Tooltip.SetToolTip(Me.biLimpiarPdf, "Limpiar Pdf")
        '
        'biLimpiarXml
        '
        Me.biLimpiarXml.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.biLimpiarXml.Location = New System.Drawing.Point(311, 9)
        Me.biLimpiarXml.Name = "biLimpiarXml"
        Me.biLimpiarXml.Size = New System.Drawing.Size(25, 22)
        Me.biLimpiarXml.TabIndex = 252
        Me.biLimpiarXml.TabStop = False
        Me.Tooltip.SetToolTip(Me.biLimpiarXml, "Limpiar Xml")
        '
        'btnBuscarPdf
        '
        Me.btnBuscarPdf.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPdf.Location = New System.Drawing.Point(586, 9)
        Me.btnBuscarPdf.Name = "btnBuscarPdf"
        Me.btnBuscarPdf.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPdf.TabIndex = 48
        Me.btnBuscarPdf.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnBuscarPdf, "Buscar Pdf")
        Me.btnBuscarPdf.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(343, 13)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(66, 13)
        Me.Label26.TabIndex = 47
        Me.Label26.Text = "PDF (F.E.)"
        '
        'txtPdfFE
        '
        Me.txtPdfFE.BackColor = System.Drawing.SystemColors.Control
        Me.txtPdfFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPdfFE.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPdfFE.Location = New System.Drawing.Point(409, 10)
        Me.txtPdfFE.MaxLength = 10
        Me.txtPdfFE.Name = "txtPdfFE"
        Me.txtPdfFE.ReadOnly = True
        Me.txtPdfFE.Size = New System.Drawing.Size(175, 20)
        Me.txtPdfFE.TabIndex = 46
        '
        'btnBuscarXml
        '
        Me.btnBuscarXml.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarXml.Location = New System.Drawing.Point(285, 9)
        Me.btnBuscarXml.Name = "btnBuscarXml"
        Me.btnBuscarXml.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarXml.TabIndex = 45
        Me.btnBuscarXml.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnBuscarXml, "Buscar Xml")
        Me.btnBuscarXml.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(37, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "XML (F.E.)"
        '
        'txtXmlFE
        '
        Me.txtXmlFE.BackColor = System.Drawing.SystemColors.Control
        Me.txtXmlFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXmlFE.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtXmlFE.Location = New System.Drawing.Point(108, 10)
        Me.txtXmlFE.MaxLength = 10
        Me.txtXmlFE.Name = "txtXmlFE"
        Me.txtXmlFE.ReadOnly = True
        Me.txtXmlFE.Size = New System.Drawing.Size(175, 20)
        Me.txtXmlFE.TabIndex = 43
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.FirstMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.IsNullDate = True
        Me.txtFecDoc.Location = New System.Drawing.Point(461, 54)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = ""
        Me.txtFecDoc.Size = New System.Drawing.Size(96, 20)
        Me.txtFecDoc.TabIndex = 25
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtSerieDoc
        '
        Me.txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtSerieDoc.Location = New System.Drawing.Point(461, 32)
        Me.txtSerieDoc.MaxLength = 4
        Me.txtSerieDoc.Name = "txtSerieDoc"
        Me.txtSerieDoc.Size = New System.Drawing.Size(96, 20)
        Me.txtSerieDoc.TabIndex = 23
        Me.txtSerieDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(388, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 13)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Serie Doc."
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(109, 54)
        Me.txtNumDoc.MaxLength = 10
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(158, 20)
        Me.txtNumDoc.TabIndex = 24
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Nº Documento"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Tipo Documento"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Location = New System.Drawing.Point(109, 32)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(256, 20)
        Me.cmbTipoDoc.TabIndex = 22
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(345, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Fecha Documento"
        '
        'gbProveedor
        '
        Me.gbProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.gbProveedor.Controls.Add(Me.cbAplicaCosto)
        Me.gbProveedor.Controls.Add(Me.btnLimpiarProveedor)
        Me.gbProveedor.Controls.Add(Me.Label24)
        Me.gbProveedor.Controls.Add(Me.cmbTarifaViaje)
        Me.gbProveedor.Controls.Add(Me.btnAgregarProveedor)
        Me.gbProveedor.Controls.Add(Me.txtItem)
        Me.gbProveedor.Controls.Add(Me.Label9)
        Me.gbProveedor.Controls.Add(Me.txtProveedor)
        Me.gbProveedor.Controls.Add(Me.Label11)
        Me.gbProveedor.Controls.Add(Me.cmbCondPago)
        Me.gbProveedor.Controls.Add(Me.btnBuscarProveedor)
        Me.gbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProveedor.ForeColor = System.Drawing.Color.Black
        Me.gbProveedor.Location = New System.Drawing.Point(4, 90)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(640, 55)
        Me.gbProveedor.TabIndex = 18
        Me.gbProveedor.Text = "Proveedor"
        Me.gbProveedor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbAplicaCosto
        '
        Me.cbAplicaCosto.AutoSize = True
        Me.cbAplicaCosto.BackColor = System.Drawing.Color.White
        Me.cbAplicaCosto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAplicaCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbAplicaCosto.Location = New System.Drawing.Point(387, 33)
        Me.cbAplicaCosto.Name = "cbAplicaCosto"
        Me.cbAplicaCosto.Size = New System.Drawing.Size(134, 17)
        Me.cbAplicaCosto.TabIndex = 289
        Me.cbAplicaCosto.Text = "APLICA AL COSTO"
        Me.cbAplicaCosto.UseVisualStyleBackColor = False
        '
        'btnLimpiarProveedor
        '
        Me.btnLimpiarProveedor.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarProveedor.Location = New System.Drawing.Point(595, 9)
        Me.btnLimpiarProveedor.Name = "btnLimpiarProveedor"
        Me.btnLimpiarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarProveedor.TabIndex = 251
        Me.btnLimpiarProveedor.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnLimpiarProveedor, "Limpiar Proveedor")
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(522, 35)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 13)
        Me.Label24.TabIndex = 250
        Me.Label24.Text = "Tarifa"
        Me.Label24.Visible = False
        '
        'cmbTarifaViaje
        '
        Me.cmbTarifaViaje.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTarifaViaje_DesignTimeLayout.LayoutString = resources.GetString("cmbTarifaViaje_DesignTimeLayout.LayoutString")
        Me.cmbTarifaViaje.DesignTimeLayout = cmbTarifaViaje_DesignTimeLayout
        Me.cmbTarifaViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTarifaViaje.Location = New System.Drawing.Point(568, 31)
        Me.cmbTarifaViaje.Name = "cmbTarifaViaje"
        Me.cmbTarifaViaje.SelectedIndex = -1
        Me.cmbTarifaViaje.SelectedItem = Nothing
        Me.cmbTarifaViaje.Size = New System.Drawing.Size(37, 20)
        Me.cmbTarifaViaje.TabIndex = 249
        Me.cmbTarifaViaje.TabStop = False
        Me.cmbTarifaViaje.Visible = False
        Me.cmbTarifaViaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnAgregarProveedor
        '
        Me.btnAgregarProveedor.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnAgregarProveedor.Location = New System.Drawing.Point(564, 9)
        Me.btnAgregarProveedor.Name = "btnAgregarProveedor"
        Me.btnAgregarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarProveedor.TabIndex = 187
        Me.btnAgregarProveedor.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnAgregarProveedor, "Agregar Proveedor")
        '
        'txtItem
        '
        Me.txtItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItem.Location = New System.Drawing.Point(607, 31)
        Me.txtItem.Maximum = 300
        Me.txtItem.MaxLength = 200
        Me.txtItem.Minimum = 1
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(29, 20)
        Me.txtItem.TabIndex = 186
        Me.txtItem.TabStop = False
        Me.txtItem.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtItem.Value = 1
        Me.txtItem.Visible = False
        Me.txtItem.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(108, 10)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(424, 20)
        Me.txtProveedor.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Forma de Pago"
        '
        'cmbCondPago
        '
        Me.cmbCondPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCondPago_DesignTimeLayout.LayoutString = resources.GetString("cmbCondPago_DesignTimeLayout.LayoutString")
        Me.cmbCondPago.DesignTimeLayout = cmbCondPago_DesignTimeLayout
        Me.cmbCondPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCondPago.Location = New System.Drawing.Point(108, 31)
        Me.cmbCondPago.Name = "cmbCondPago"
        Me.cmbCondPago.SelectedIndex = -1
        Me.cmbCondPago.SelectedItem = Nothing
        Me.cmbCondPago.Size = New System.Drawing.Size(231, 19)
        Me.cmbCondPago.TabIndex = 20
        Me.cmbCondPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(533, 9)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 8
        Me.btnBuscarProveedor.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnBuscarProveedor, "Buscar Proveedor")
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'txtCodEmbarque
        '
        Me.txtCodEmbarque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodEmbarque.Location = New System.Drawing.Point(469, 181)
        Me.txtCodEmbarque.Name = "txtCodEmbarque"
        Me.txtCodEmbarque.Size = New System.Drawing.Size(112, 20)
        Me.txtCodEmbarque.TabIndex = 17
        '
        'gbGastoViaje
        '
        Me.gbGastoViaje.Controls.Add(Me.cbNoAplicaPolitica)
        Me.gbGastoViaje.Controls.Add(Me.txtObservSubRubro)
        Me.gbGastoViaje.Controls.Add(Me.cmbSubRubroViaje)
        Me.gbGastoViaje.Controls.Add(Me.cmbRubroViaje)
        Me.gbGastoViaje.Controls.Add(Me.Label21)
        Me.gbGastoViaje.Controls.Add(Me.Label22)
        Me.gbGastoViaje.Controls.Add(Me.Label17)
        Me.gbGastoViaje.Controls.Add(Me.cmbPlaca)
        Me.gbGastoViaje.Location = New System.Drawing.Point(6, 50)
        Me.gbGastoViaje.Name = "gbGastoViaje"
        Me.gbGastoViaje.Size = New System.Drawing.Size(646, 59)
        Me.gbGastoViaje.TabIndex = 8
        Me.gbGastoViaje.Text = "Gasto de Viaje"
        Me.gbGastoViaje.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbNoAplicaPolitica
        '
        Me.cbNoAplicaPolitica.AutoSize = True
        Me.cbNoAplicaPolitica.BackColor = System.Drawing.Color.White
        Me.cbNoAplicaPolitica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbNoAplicaPolitica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbNoAplicaPolitica.Location = New System.Drawing.Point(9, 14)
        Me.cbNoAplicaPolitica.Name = "cbNoAplicaPolitica"
        Me.cbNoAplicaPolitica.Size = New System.Drawing.Size(159, 17)
        Me.cbNoAplicaPolitica.TabIndex = 9
        Me.cbNoAplicaPolitica.Text = "NO APLICA POLÍTICAS"
        Me.cbNoAplicaPolitica.UseVisualStyleBackColor = False
        '
        'txtObservSubRubro
        '
        Me.txtObservSubRubro.Location = New System.Drawing.Point(374, 33)
        Me.txtObservSubRubro.Name = "txtObservSubRubro"
        Me.txtObservSubRubro.ReadOnly = True
        Me.txtObservSubRubro.Size = New System.Drawing.Size(266, 20)
        Me.txtObservSubRubro.TabIndex = 250
        Me.txtObservSubRubro.TabStop = False
        '
        'cmbSubRubroViaje
        '
        Me.cmbSubRubroViaje.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSubRubroViaje_DesignTimeLayout.LayoutString = resources.GetString("cmbSubRubroViaje_DesignTimeLayout.LayoutString")
        Me.cmbSubRubroViaje.DesignTimeLayout = cmbSubRubroViaje_DesignTimeLayout
        Me.cmbSubRubroViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubRubroViaje.Location = New System.Drawing.Point(90, 33)
        Me.cmbSubRubroViaje.Name = "cmbSubRubroViaje"
        Me.cmbSubRubroViaje.SelectedIndex = -1
        Me.cmbSubRubroViaje.SelectedItem = Nothing
        Me.cmbSubRubroViaje.Size = New System.Drawing.Size(278, 20)
        Me.cmbSubRubroViaje.TabIndex = 12
        Me.cmbSubRubroViaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbRubroViaje
        '
        Me.cmbRubroViaje.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRubroViaje_DesignTimeLayout.LayoutString = resources.GetString("cmbRubroViaje_DesignTimeLayout.LayoutString")
        Me.cmbRubroViaje.DesignTimeLayout = cmbRubroViaje_DesignTimeLayout
        Me.cmbRubroViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRubroViaje.Location = New System.Drawing.Point(288, 11)
        Me.cmbRubroViaje.Name = "cmbRubroViaje"
        Me.cmbRubroViaje.SelectedIndex = -1
        Me.cmbRubroViaje.SelectedItem = Nothing
        Me.cmbRubroViaje.Size = New System.Drawing.Size(165, 20)
        Me.cmbRubroViaje.TabIndex = 11
        Me.cmbRubroViaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(7, 37)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 13)
        Me.Label21.TabIndex = 246
        Me.Label21.Text = "Sub Rubro"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(212, 15)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 13)
        Me.Label22.TabIndex = 245
        Me.Label22.Text = "Rubro Viaje"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(485, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 13)
        Me.Label17.TabIndex = 242
        Me.Label17.Text = "Placa"
        '
        'cmbPlaca
        '
        Me.cmbPlaca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPlaca_DesignTimeLayout.LayoutString = resources.GetString("cmbPlaca_DesignTimeLayout.LayoutString")
        Me.cmbPlaca.DesignTimeLayout = cmbPlaca_DesignTimeLayout
        Me.cmbPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlaca.Location = New System.Drawing.Point(527, 11)
        Me.cmbPlaca.Name = "cmbPlaca"
        Me.cmbPlaca.SelectedIndex = -1
        Me.cmbPlaca.SelectedItem = Nothing
        Me.cmbPlaca.Size = New System.Drawing.Size(113, 20)
        Me.cmbPlaca.TabIndex = 13
        Me.cmbPlaca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'bgMontos
        '
        Me.bgMontos.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.bgMontos.Controls.Add(Me.txtMontoIgv)
        Me.bgMontos.Controls.Add(Me.Label27)
        Me.bgMontos.Controls.Add(Me.txtMontoTotal)
        Me.bgMontos.Controls.Add(Me.Label19)
        Me.bgMontos.Controls.Add(Me.txtMontoNoAfecto)
        Me.bgMontos.Controls.Add(Me.Label18)
        Me.bgMontos.Controls.Add(Me.cbAfectoIgv)
        Me.bgMontos.Controls.Add(Me.txtMontoSinIgv)
        Me.bgMontos.Controls.Add(Me.Label12)
        Me.bgMontos.Controls.Add(Me.Label10)
        Me.bgMontos.Controls.Add(Me.txtIgv)
        Me.bgMontos.Controls.Add(Me.Label8)
        Me.bgMontos.Controls.Add(Me.txtMonto)
        Me.bgMontos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bgMontos.ForeColor = System.Drawing.Color.Black
        Me.bgMontos.Location = New System.Drawing.Point(7, 353)
        Me.bgMontos.Name = "bgMontos"
        Me.bgMontos.Size = New System.Drawing.Size(646, 58)
        Me.bgMontos.TabIndex = 4
        Me.bgMontos.Text = "Montos"
        Me.bgMontos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtMontoIgv
        '
        Me.txtMontoIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIgv.Location = New System.Drawing.Point(537, 33)
        Me.txtMontoIgv.MaxLength = 10
        Me.txtMontoIgv.Name = "txtMontoIgv"
        Me.txtMontoIgv.ReadOnly = True
        Me.txtMontoIgv.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoIgv.TabIndex = 58
        Me.txtMontoIgv.TabStop = False
        Me.txtMontoIgv.Text = "0.00"
        Me.txtMontoIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(464, 37)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 13)
        Me.Label27.TabIndex = 57
        Me.Label27.Text = "Monto IGV"
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotal.Location = New System.Drawing.Point(327, 33)
        Me.txtMontoTotal.MaxLength = 10
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoTotal.TabIndex = 56
        Me.txtMontoTotal.TabStop = False
        Me.txtMontoTotal.Text = "0.00"
        Me.txtMontoTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(246, 37)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(75, 13)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Monto Total"
        '
        'txtMontoNoAfecto
        '
        Me.txtMontoNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNoAfecto.Location = New System.Drawing.Point(109, 33)
        Me.txtMontoNoAfecto.MaxLength = 10
        Me.txtMontoNoAfecto.Name = "txtMontoNoAfecto"
        Me.txtMontoNoAfecto.Size = New System.Drawing.Size(98, 20)
        Me.txtMontoNoAfecto.TabIndex = 7
        Me.txtMontoNoAfecto.Text = "0.00"
        Me.txtMontoNoAfecto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNoAfecto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 13)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "Mont. No Afecto"
        '
        'cbAfectoIgv
        '
        Me.cbAfectoIgv.AutoSize = True
        Me.cbAfectoIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbAfectoIgv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAfectoIgv.Checked = True
        Me.cbAfectoIgv.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAfectoIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbAfectoIgv.ForeColor = System.Drawing.Color.Black
        Me.cbAfectoIgv.Location = New System.Drawing.Point(132, 13)
        Me.cbAfectoIgv.Name = "cbAfectoIgv"
        Me.cbAfectoIgv.Size = New System.Drawing.Size(96, 17)
        Me.cbAfectoIgv.TabIndex = 5
        Me.cbAfectoIgv.Text = "Afecto a Igv"
        Me.cbAfectoIgv.UseVisualStyleBackColor = False
        '
        'txtMontoSinIgv
        '
        Me.txtMontoSinIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoSinIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSinIgv.Location = New System.Drawing.Point(537, 11)
        Me.txtMontoSinIgv.MaxLength = 10
        Me.txtMontoSinIgv.Name = "txtMontoSinIgv"
        Me.txtMontoSinIgv.ReadOnly = True
        Me.txtMontoSinIgv.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoSinIgv.TabIndex = 6
        Me.txtMontoSinIgv.TabStop = False
        Me.txtMontoSinIgv.Text = "0.00"
        Me.txtMontoSinIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoSinIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(448, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 13)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Mont. Sin Igv"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "I.G.V."
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtIgv.Location = New System.Drawing.Point(53, 10)
        Me.txtIgv.MaxLength = 12
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(64, 20)
        Me.txtIgv.TabIndex = 4
        Me.txtIgv.TabStop = False
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(240, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Monto Afecto"
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(327, 11)
        Me.txtMonto.MaxLength = 10
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(100, 20)
        Me.txtMonto.TabIndex = 6
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRubro.Location = New System.Drawing.Point(436, 12)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(78, 13)
        Me.lblRubro.TabIndex = 192
        Me.lblRubro.Text = "Rubro Gasto"
        '
        'cmbRubro
        '
        Me.cmbRubro.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRubro_DesignTimeLayout.LayoutString = resources.GetString("cmbRubro_DesignTimeLayout.LayoutString")
        Me.cmbRubro.DesignTimeLayout = cmbRubro_DesignTimeLayout
        Me.cmbRubro.Location = New System.Drawing.Point(516, 9)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.SelectedIndex = -1
        Me.cmbRubro.SelectedItem = Nothing
        Me.cmbRubro.Size = New System.Drawing.Size(137, 20)
        Me.cmbRubro.TabIndex = 3
        Me.cmbRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 184)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 13)
        Me.Label20.TabIndex = 190
        Me.Label20.Text = "Colaborador"
        '
        'txtPersona
        '
        Me.txtPersona.BackColor = System.Drawing.SystemColors.Control
        Me.txtPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersona.Location = New System.Drawing.Point(96, 181)
        Me.txtPersona.Name = "txtPersona"
        Me.txtPersona.ReadOnly = True
        Me.txtPersona.Size = New System.Drawing.Size(252, 20)
        Me.txtPersona.TabIndex = 16
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(349, 180)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersona.TabIndex = 17
        Me.btnBuscarPersona.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnBuscarPersona, "Buscar Colaborador")
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodCuenta.Location = New System.Drawing.Point(83, 9)
        Me.txtCodCuenta.MaxLength = 20
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.ReadOnly = True
        Me.txtCodCuenta.Size = New System.Drawing.Size(57, 20)
        Me.txtCodCuenta.TabIndex = 0
        Me.txtCodCuenta.TabStop = False
        Me.txtCodCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 32)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Descripción Contable"
        '
        'txtJustificacion
        '
        Me.txtJustificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJustificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJustificacion.Location = New System.Drawing.Point(96, 147)
        Me.txtJustificacion.Multiline = True
        Me.txtJustificacion.Name = "txtJustificacion"
        Me.txtJustificacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtJustificacion.Size = New System.Drawing.Size(556, 32)
        Me.txtJustificacion.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(96, 113)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(556, 32)
        Me.txtDescripcion.TabIndex = 14
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(185, 9)
        Me.txtCantidad.Maximum = 300
        Me.txtCantidad.MaxLength = 200
        Me.txtCantidad.Minimum = 1
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(43, 20)
        Me.txtCantidad.TabIndex = 1
        Me.txtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCantidad.Value = 1
        Me.txtCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(145, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Cant."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº Cuenta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(234, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Moneda"
        Me.Label4.Visible = False
        '
        'cmbMoneda
        '
        Me.cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(286, 5)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(49, 20)
        Me.cmbMoneda.TabIndex = 3
        Me.cmbMoneda.Visible = False
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesCentrosCosto
        '
        Me.cmOpcionesCentrosCosto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAsignarCentroCosto, Me.miMostrarCentroCosto, Me.ToolStripSeparator2, Me.ToolStripSeparator1, Me.miActualizarCentroCosto})
        Me.cmOpcionesCentrosCosto.Name = "cmOpciones"
        Me.cmOpcionesCentrosCosto.Size = New System.Drawing.Size(221, 82)
        '
        'miAsignarCentroCosto
        '
        Me.miAsignarCentroCosto.Image = CType(resources.GetObject("miAsignarCentroCosto.Image"), System.Drawing.Image)
        Me.miAsignarCentroCosto.Name = "miAsignarCentroCosto"
        Me.miAsignarCentroCosto.Size = New System.Drawing.Size(220, 22)
        Me.miAsignarCentroCosto.Text = "Asignar Centros de Costo"
        Me.miAsignarCentroCosto.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarCentroCosto
        '
        Me.miMostrarCentroCosto.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarCentroCosto.Name = "miMostrarCentroCosto"
        Me.miMostrarCentroCosto.Size = New System.Drawing.Size(220, 22)
        Me.miMostrarCentroCosto.Text = "Mostrar Centro de Costo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(217, 6)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(217, 6)
        '
        'miActualizarCentroCosto
        '
        Me.miActualizarCentroCosto.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarCentroCosto.Name = "miActualizarCentroCosto"
        Me.miActualizarCentroCosto.Size = New System.Drawing.Size(220, 22)
        Me.miActualizarCentroCosto.Text = "Actualizar Centros de Costo"
        '
        'gbCentroCosto
        '
        Me.gbCentroCosto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCentroCosto.Controls.Add(Me.dgvCentrosCosto)
        Me.gbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCentroCosto.Location = New System.Drawing.Point(5, 443)
        Me.gbCentroCosto.Name = "gbCentroCosto"
        Me.gbCentroCosto.Size = New System.Drawing.Size(658, 95)
        Me.gbCentroCosto.TabIndex = 245
        Me.gbCentroCosto.Text = "Centros de Costo"
        Me.gbCentroCosto.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbCentroCosto.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvCentrosCosto
        '
        Me.dgvCentrosCosto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCentrosCosto.ContextMenuStrip = Me.cmOpcionesCentrosCosto
        dgvCentrosCosto_DesignTimeLayout.LayoutString = resources.GetString("dgvCentrosCosto_DesignTimeLayout.LayoutString")
        Me.dgvCentrosCosto.DesignTimeLayout = dgvCentrosCosto_DesignTimeLayout
        Me.dgvCentrosCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvCentrosCosto.GroupByBoxVisible = False
        Me.dgvCentrosCosto.Location = New System.Drawing.Point(6, 13)
        Me.dgvCentrosCosto.Name = "dgvCentrosCosto"
        Me.dgvCentrosCosto.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCentrosCosto.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCentrosCosto.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCentrosCosto.Size = New System.Drawing.Size(646, 78)
        Me.dgvCentrosCosto.TabIndex = 228
        Me.dgvCentrosCosto.TabStop = False
        Me.dgvCentrosCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbJobs
        '
        Me.gbJobs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbJobs.Controls.Add(Me.dgvJos)
        Me.gbJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbJobs.Location = New System.Drawing.Point(5, 537)
        Me.gbJobs.Name = "gbJobs"
        Me.gbJobs.Size = New System.Drawing.Size(658, 93)
        Me.gbJobs.TabIndex = 246
        Me.gbJobs.Text = "Job's"
        Me.gbJobs.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbJobs.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvJos
        '
        Me.dgvJos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvJos.ContextMenuStrip = Me.cmOpcionesJobs
        dgvJos_DesignTimeLayout.LayoutString = resources.GetString("dgvJos_DesignTimeLayout.LayoutString")
        Me.dgvJos.DesignTimeLayout = dgvJos_DesignTimeLayout
        Me.dgvJos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvJos.GroupByBoxVisible = False
        Me.dgvJos.Location = New System.Drawing.Point(6, 12)
        Me.dgvJos.Name = "dgvJos"
        Me.dgvJos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvJos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvJos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvJos.Size = New System.Drawing.Size(646, 78)
        Me.dgvJos.TabIndex = 228
        Me.dgvJos.TabStop = False
        Me.dgvJos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesJobs
        '
        Me.cmOpcionesJobs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAsignarJobs, Me.miMostrarJob, Me.miEliminarJob, Me.miProcesarJob, Me.miMostrarCompras, Me.ToolStripSeparator3, Me.ToolStripSeparator7, Me.miActualizarJobs})
        Me.cmOpcionesJobs.Name = "cmOpciones"
        Me.cmOpcionesJobs.Size = New System.Drawing.Size(167, 148)
        '
        'miAsignarJobs
        '
        Me.miAsignarJobs.Image = CType(resources.GetObject("miAsignarJobs.Image"), System.Drawing.Image)
        Me.miAsignarJobs.Name = "miAsignarJobs"
        Me.miAsignarJobs.Size = New System.Drawing.Size(166, 22)
        Me.miAsignarJobs.Text = "Asignar Job's"
        Me.miAsignarJobs.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarJob
        '
        Me.miMostrarJob.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarJob.Name = "miMostrarJob"
        Me.miMostrarJob.Size = New System.Drawing.Size(166, 22)
        Me.miMostrarJob.Text = "Mostrar Job"
        '
        'miEliminarJob
        '
        Me.miEliminarJob.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarJob.Name = "miEliminarJob"
        Me.miEliminarJob.Size = New System.Drawing.Size(166, 22)
        Me.miEliminarJob.Text = "Eliminar Job"
        '
        'miProcesarJob
        '
        Me.miProcesarJob.Image = CType(resources.GetObject("miProcesarJob.Image"), System.Drawing.Image)
        Me.miProcesarJob.Name = "miProcesarJob"
        Me.miProcesarJob.Size = New System.Drawing.Size(166, 22)
        Me.miProcesarJob.Text = "Procesar Job"
        Me.miProcesarJob.Visible = False
        '
        'miMostrarCompras
        '
        Me.miMostrarCompras.Image = CType(resources.GetObject("miMostrarCompras.Image"), System.Drawing.Image)
        Me.miMostrarCompras.Name = "miMostrarCompras"
        Me.miMostrarCompras.Size = New System.Drawing.Size(166, 22)
        Me.miMostrarCompras.Text = "Mostrar Compras"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(163, 6)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(163, 6)
        '
        'miActualizarJobs
        '
        Me.miActualizarJobs.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarJobs.Name = "miActualizarJobs"
        Me.miActualizarJobs.Size = New System.Drawing.Size(166, 22)
        Me.miActualizarJobs.Text = "Actualizar Job's"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Datos"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biGuardar, Me.ToolStripSeparator5, Me.biEditar, Me.ToolStripSeparator6, Me.biDeshacer, Me.ToolStripSeparator8, Me.biCerrar, Me.ToolStripSeparator9})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(674, 31)
        Me.ToolStrip1.TabIndex = 243
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'frmComSolicitudGastoDet
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(674, 655)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbMoneda)
        Me.Controls.Add(Me.gbCentroCosto)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbJobs)
        Me.Controls.Add(Me.gbDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudGastoDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Solicitud de Gastos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        CType(Me.cmbTipoGasto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFacturacion.ResumeLayout(False)
        Me.gbFacturacion.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        CType(Me.cmbTarifaViaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCondPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGastoViaje.ResumeLayout(False)
        Me.gbGastoViaje.PerformLayout()
        CType(Me.cmbSubRubroViaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbRubroViaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgMontos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bgMontos.ResumeLayout(False)
        Me.bgMontos.PerformLayout()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesCentrosCosto.ResumeLayout(False)
        CType(Me.gbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCentroCosto.ResumeLayout(False)
        CType(Me.dgvCentrosCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbJobs.ResumeLayout(False)
        CType(Me.dgvJos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesJobs.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtJustificacion As System.Windows.Forms.TextBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents txtCodCuenta As System.Windows.Forms.TextBox
    Friend WithEvents gbProveedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbCondPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbFacturacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtSerieDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtItem As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents txtMontoSinIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbAfectoIgv As System.Windows.Forms.CheckBox
    Friend WithEvents bgMontos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtMontoNoAfecto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtPersona As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbRubro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbGastoViaje As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbPlaca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbSubRubroViaje As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbRubroViaje As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbTarifaViaje As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtObservSubRubro As System.Windows.Forms.TextBox
    Friend WithEvents cbNoAplicaPolitica As System.Windows.Forms.CheckBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnLimpiarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtMontoIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmOpcionesCentrosCosto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miAsignarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbCentroCosto As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvCentrosCosto As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbJobs As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvJos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpcionesJobs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miAsignarJobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarJobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarCompras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miProcesarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCodEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents cmbMedio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarPdf As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPdfFE As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarXml As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtXmlFE As System.Windows.Forms.TextBox
    Friend WithEvents biLimpiarPdf As Janus.Windows.EditControls.UIButton
    Friend WithEvents biLimpiarXml As Janus.Windows.EditControls.UIButton
    Friend WithEvents Tooltip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtTipCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTipoGasto As System.Windows.Forms.Label
    Friend WithEvents cmbTipoGasto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblRubro As System.Windows.Forms.Label
    Friend WithEvents txtObservTipoGasto As System.Windows.Forms.TextBox
    Friend WithEvents cbAplicaCosto As System.Windows.Forms.CheckBox
End Class
