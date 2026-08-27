<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComOrdenCompra_Factura
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
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComOrdenCompra_Factura))
        Dim dgvCentrosCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvJos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbAplicaCosto = New System.Windows.Forms.CheckBox()
        Me.btnLimpiarPdf = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarXml = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarPdf = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPdfFE = New System.Windows.Forms.TextBox()
        Me.btnBuscarXml = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtXmlFE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMontoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMontoNoAfecto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cbProcesado = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtSerieDoc = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbCentroCosto = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvCentrosCosto = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesCentrosCosto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAsignarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbJobs = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvJos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesJobs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAsignarJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCentroCosto.SuspendLayout()
        CType(Me.dgvCentrosCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesCentrosCosto.SuspendLayout()
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
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cbAplicaCosto)
        Me.UiGroupBox1.Controls.Add(Me.btnLimpiarPdf)
        Me.UiGroupBox1.Controls.Add(Me.btnLimpiarXml)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPdf)
        Me.UiGroupBox1.Controls.Add(Me.Label26)
        Me.UiGroupBox1.Controls.Add(Me.txtPdfFE)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarXml)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.txtXmlFE)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtMontoTotal)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtMontoNoAfecto)
        Me.UiGroupBox1.Controls.Add(Me.cbProcesado)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtMonto)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtFecDoc)
        Me.UiGroupBox1.Controls.Add(Me.txtSerieDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label16)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipoDoc)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 33)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(628, 184)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.Text = "Datos de Facturación"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbAplicaCosto
        '
        Me.cbAplicaCosto.AutoSize = True
        Me.cbAplicaCosto.BackColor = System.Drawing.Color.White
        Me.cbAplicaCosto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAplicaCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbAplicaCosto.Location = New System.Drawing.Point(6, 110)
        Me.cbAplicaCosto.Name = "cbAplicaCosto"
        Me.cbAplicaCosto.Size = New System.Drawing.Size(134, 17)
        Me.cbAplicaCosto.TabIndex = 290
        Me.cbAplicaCosto.Text = "APLICA AL COSTO"
        Me.cbAplicaCosto.UseVisualStyleBackColor = False
        '
        'btnLimpiarPdf
        '
        Me.btnLimpiarPdf.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarPdf.Location = New System.Drawing.Point(596, 20)
        Me.btnLimpiarPdf.Name = "btnLimpiarPdf"
        Me.btnLimpiarPdf.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarPdf.TabIndex = 253
        Me.btnLimpiarPdf.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnLimpiarPdf, "Limpiar Pdf")
        '
        'btnLimpiarXml
        '
        Me.btnLimpiarXml.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarXml.Location = New System.Drawing.Point(276, 20)
        Me.btnLimpiarXml.Name = "btnLimpiarXml"
        Me.btnLimpiarXml.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarXml.TabIndex = 252
        Me.btnLimpiarXml.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnLimpiarXml, "Limpiar Xml")
        '
        'btnBuscarPdf
        '
        Me.btnBuscarPdf.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPdf.Location = New System.Drawing.Point(570, 20)
        Me.btnBuscarPdf.Name = "btnBuscarPdf"
        Me.btnBuscarPdf.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPdf.TabIndex = 63
        Me.btnBuscarPdf.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnBuscarPdf, "Buscar Pdf")
        Me.btnBuscarPdf.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(336, 24)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(66, 13)
        Me.Label26.TabIndex = 62
        Me.Label26.Text = "PDF (F.E.)"
        '
        'txtPdfFE
        '
        Me.txtPdfFE.BackColor = System.Drawing.SystemColors.Control
        Me.txtPdfFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPdfFE.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPdfFE.Location = New System.Drawing.Point(403, 21)
        Me.txtPdfFE.MaxLength = 10
        Me.txtPdfFE.Name = "txtPdfFE"
        Me.txtPdfFE.ReadOnly = True
        Me.txtPdfFE.Size = New System.Drawing.Size(165, 20)
        Me.txtPdfFE.TabIndex = 61
        '
        'btnBuscarXml
        '
        Me.btnBuscarXml.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarXml.Location = New System.Drawing.Point(250, 20)
        Me.btnBuscarXml.Name = "btnBuscarXml"
        Me.btnBuscarXml.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarXml.TabIndex = 60
        Me.btnBuscarXml.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnBuscarXml, "Buscar Xml")
        Me.btnBuscarXml.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "XML (F.E.)"
        '
        'txtXmlFE
        '
        Me.txtXmlFE.BackColor = System.Drawing.SystemColors.Control
        Me.txtXmlFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXmlFE.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtXmlFE.Location = New System.Drawing.Point(83, 21)
        Me.txtXmlFE.MaxLength = 10
        Me.txtXmlFE.Name = "txtXmlFE"
        Me.txtXmlFE.ReadOnly = True
        Me.txtXmlFE.Size = New System.Drawing.Size(165, 20)
        Me.txtXmlFE.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(461, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Monto Total"
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotal.Location = New System.Drawing.Point(538, 107)
        Me.txtMontoTotal.MaxLength = 10
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(82, 20)
        Me.txtMontoTotal.TabIndex = 56
        Me.txtMontoTotal.TabStop = False
        Me.txtMontoTotal.Text = "0.00"
        Me.txtMontoTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(285, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Monto No Afecto"
        '
        'txtMontoNoAfecto
        '
        Me.txtMontoNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNoAfecto.Location = New System.Drawing.Point(390, 108)
        Me.txtMontoNoAfecto.MaxLength = 10
        Me.txtMontoNoAfecto.Name = "txtMontoNoAfecto"
        Me.txtMontoNoAfecto.Size = New System.Drawing.Size(60, 20)
        Me.txtMontoNoAfecto.TabIndex = 6
        Me.txtMontoNoAfecto.Text = "0.00"
        Me.txtMontoNoAfecto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNoAfecto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbProcesado
        '
        Me.cbProcesado.AutoSize = True
        Me.cbProcesado.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbProcesado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbProcesado.Checked = True
        Me.cbProcesado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbProcesado.Enabled = False
        Me.cbProcesado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbProcesado.ForeColor = System.Drawing.Color.Black
        Me.cbProcesado.Location = New System.Drawing.Point(534, 146)
        Me.cbProcesado.Name = "cbProcesado"
        Me.cbProcesado.Size = New System.Drawing.Size(86, 17)
        Me.cbProcesado.TabIndex = 8
        Me.cbProcesado.Text = "Procesado"
        Me.cbProcesado.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Observación"
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(193, 108)
        Me.txtMonto.MaxLength = 10
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(82, 20)
        Me.txtMonto.TabIndex = 5
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(90, 137)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(438, 39)
        Me.txtObservacion.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(149, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Monto"
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.FirstMonth = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.Visible = False
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecDoc.Location = New System.Drawing.Point(495, 79)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.Size = New System.Drawing.Size(96, 20)
        Me.txtFecDoc.TabIndex = 4
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.Value = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtSerieDoc
        '
        Me.txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtSerieDoc.Location = New System.Drawing.Point(494, 50)
        Me.txtSerieDoc.MaxLength = 4
        Me.txtSerieDoc.Name = "txtSerieDoc"
        Me.txtSerieDoc.Size = New System.Drawing.Size(96, 20)
        Me.txtSerieDoc.TabIndex = 2
        Me.txtSerieDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(425, 53)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 13)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Serie Doc."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Tipo Documento"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Location = New System.Drawing.Point(112, 50)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(245, 20)
        Me.cmbTipoDoc.TabIndex = 1
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(112, 79)
        Me.txtNumDoc.MaxLength = 8
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(189, 20)
        Me.txtNumDoc.TabIndex = 3
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Nº Documento"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(383, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 13)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Fecha Documento"
        '
        'gbCentroCosto
        '
        Me.gbCentroCosto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCentroCosto.Controls.Add(Me.dgvCentrosCosto)
        Me.gbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCentroCosto.Location = New System.Drawing.Point(6, 222)
        Me.gbCentroCosto.Name = "gbCentroCosto"
        Me.gbCentroCosto.Size = New System.Drawing.Size(627, 98)
        Me.gbCentroCosto.TabIndex = 246
        Me.gbCentroCosto.Text = "Centros de Costo"
        Me.gbCentroCosto.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbCentroCosto.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvCentrosCosto
        '
        Me.dgvCentrosCosto.ContextMenuStrip = Me.cmOpcionesCentrosCosto
        dgvCentrosCosto_DesignTimeLayout.LayoutString = resources.GetString("dgvCentrosCosto_DesignTimeLayout.LayoutString")
        Me.dgvCentrosCosto.DesignTimeLayout = dgvCentrosCosto_DesignTimeLayout
        Me.dgvCentrosCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvCentrosCosto.GroupByBoxVisible = False
        Me.dgvCentrosCosto.Location = New System.Drawing.Point(6, 14)
        Me.dgvCentrosCosto.Name = "dgvCentrosCosto"
        Me.dgvCentrosCosto.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCentrosCosto.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCentrosCosto.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCentrosCosto.Size = New System.Drawing.Size(616, 78)
        Me.dgvCentrosCosto.TabIndex = 228
        Me.dgvCentrosCosto.TabStop = False
        Me.dgvCentrosCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        'gbJobs
        '
        Me.gbJobs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbJobs.Controls.Add(Me.dgvJos)
        Me.gbJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbJobs.Location = New System.Drawing.Point(6, 324)
        Me.gbJobs.Name = "gbJobs"
        Me.gbJobs.Size = New System.Drawing.Size(627, 98)
        Me.gbJobs.TabIndex = 247
        Me.gbJobs.Text = "OT's"
        Me.gbJobs.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbJobs.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvJos
        '
        Me.dgvJos.ContextMenuStrip = Me.cmOpcionesJobs
        dgvJos_DesignTimeLayout.LayoutString = resources.GetString("dgvJos_DesignTimeLayout.LayoutString")
        Me.dgvJos.DesignTimeLayout = dgvJos_DesignTimeLayout
        Me.dgvJos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvJos.GroupByBoxVisible = False
        Me.dgvJos.Location = New System.Drawing.Point(6, 14)
        Me.dgvJos.Name = "dgvJos"
        Me.dgvJos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvJos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvJos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvJos.Size = New System.Drawing.Size(616, 78)
        Me.dgvJos.TabIndex = 228
        Me.dgvJos.TabStop = False
        Me.dgvJos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesJobs
        '
        Me.cmOpcionesJobs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAsignarJobs, Me.miMostrarJob, Me.miEliminarJob, Me.ToolStripSeparator3, Me.ToolStripSeparator7, Me.miActualizarJobs})
        Me.cmOpcionesJobs.Name = "cmOpciones"
        Me.cmOpcionesJobs.Size = New System.Drawing.Size(156, 104)
        '
        'miAsignarJobs
        '
        Me.miAsignarJobs.Image = CType(resources.GetObject("miAsignarJobs.Image"), System.Drawing.Image)
        Me.miAsignarJobs.Name = "miAsignarJobs"
        Me.miAsignarJobs.Size = New System.Drawing.Size(155, 22)
        Me.miAsignarJobs.Text = "Asignar Job's"
        Me.miAsignarJobs.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarJob
        '
        Me.miMostrarJob.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarJob.Name = "miMostrarJob"
        Me.miMostrarJob.Size = New System.Drawing.Size(155, 22)
        Me.miMostrarJob.Text = "Mostrar Job"
        '
        'miEliminarJob
        '
        Me.miEliminarJob.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarJob.Name = "miEliminarJob"
        Me.miEliminarJob.Size = New System.Drawing.Size(155, 22)
        Me.miEliminarJob.Text = "Eliminar Job"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(152, 6)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(152, 6)
        '
        'miActualizarJobs
        '
        Me.miActualizarJobs.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarJobs.Name = "miActualizarJobs"
        Me.miActualizarJobs.Size = New System.Drawing.Size(155, 22)
        Me.miActualizarJobs.Text = "Actualizar Job's"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biGuardar, Me.ToolStripSeparator5, Me.biEditar, Me.ToolStripSeparator6, Me.biDeshacer, Me.ToolStripSeparator8, Me.biCerrar, Me.ToolStripSeparator9})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(644, 31)
        Me.ToolStrip1.TabIndex = 250
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'frmComOrdenCompra_Factura
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(644, 456)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gbCentroCosto)
        Me.Controls.Add(Me.gbJobs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComOrdenCompra_Factura"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documento"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCentroCosto.ResumeLayout(False)
        CType(Me.dgvCentrosCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesCentrosCosto.ResumeLayout(False)
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
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtSerieDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cbProcesado As System.Windows.Forms.CheckBox
    Friend WithEvents gbCentroCosto As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvCentrosCosto As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbJobs As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvJos As Janus.Windows.GridEX.GridEX
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
    Friend WithEvents cmOpcionesCentrosCosto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miAsignarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpcionesJobs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miAsignarJobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarJobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtMontoNoAfecto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnBuscarPdf As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPdfFE As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarXml As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtXmlFE As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiarPdf As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarXml As Janus.Windows.EditControls.UIButton
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents cbAplicaCosto As System.Windows.Forms.CheckBox
End Class
