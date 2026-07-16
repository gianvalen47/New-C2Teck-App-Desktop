<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactura_AtenderJob
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
        Dim cmbCodMot_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodPag_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbNumJob_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFactura_AtenderJob))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmbCodMot = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodPag = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbNumJob = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.txtNumOrden = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalBruto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalBruto = New System.Windows.Forms.TextBox()
        Me.txtMontoIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoDscto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoDscto = New System.Windows.Forms.TextBox()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtValorVenta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoVenta = New System.Windows.Forms.TextBox()
        Me.lblMontoIgv = New System.Windows.Forms.TextBox()
        Me.lblTotalNeto = New System.Windows.Forms.TextBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbNumJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmbCodMot
        '
        Me.cmbCodMot.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMot_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMot_DesignTimeLayout.LayoutString")
        Me.cmbCodMot.DesignTimeLayout = cmbCodMot_DesignTimeLayout
        Me.cmbCodMot.FlatBorderColor = System.Drawing.SystemColors.Desktop
        Me.cmbCodMot.Location = New System.Drawing.Point(390, 100)
        Me.cmbCodMot.Name = "cmbCodMot"
        Me.cmbCodMot.SelectedIndex = -1
        Me.cmbCodMot.SelectedItem = Nothing
        Me.cmbCodMot.Size = New System.Drawing.Size(137, 20)
        Me.cmbCodMot.TabIndex = 8
        Me.cmbCodMot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodPag
        '
        Me.cmbCodPag.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodPag_DesignTimeLayout.LayoutString = resources.GetString("cmbCodPag_DesignTimeLayout.LayoutString")
        Me.cmbCodPag.DesignTimeLayout = cmbCodPag_DesignTimeLayout
        Me.cmbCodPag.Location = New System.Drawing.Point(94, 74)
        Me.cmbCodPag.Name = "cmbCodPag"
        Me.cmbCodPag.SelectedIndex = -1
        Me.cmbCodPag.SelectedItem = Nothing
        Me.cmbCodPag.Size = New System.Drawing.Size(184, 20)
        Me.cmbCodPag.TabIndex = 5
        Me.cmbCodPag.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbNumJob
        '
        Me.cmbNumJob.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbNumJob_DesignTimeLayout.LayoutString = resources.GetString("cmbNumJob_DesignTimeLayout.LayoutString")
        Me.cmbNumJob.DesignTimeLayout = cmbNumJob_DesignTimeLayout
        Me.cmbNumJob.Location = New System.Drawing.Point(450, 22)
        Me.cmbNumJob.Name = "cmbNumJob"
        Me.cmbNumJob.SelectedIndex = -1
        Me.cmbNumJob.SelectedItem = Nothing
        Me.cmbNumJob.Size = New System.Drawing.Size(77, 20)
        Me.cmbNumJob.TabIndex = 3
        Me.cmbNumJob.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbNumJob.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCancelar.Location = New System.Drawing.Point(269, 113)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 25)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAceptar.Location = New System.Drawing.Point(184, 113)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 25)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Location = New System.Drawing.Point(251, 22)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.Size = New System.Drawing.Size(93, 20)
        Me.txtFecDoc.TabIndex = 2
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "Descripción :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 73
        Me.Label7.Text = "For.Pago :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(55, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "O/C :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(336, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Motivo :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(304, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Tipo Cambio :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(368, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Numero OT :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(201, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Fecha :"
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumero.Location = New System.Drawing.Point(35, 25)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(58, 13)
        Me.lblNumero.TabIndex = 66
        Me.lblNumero.Text = "Numero :"
        '
        'txtNumOrden
        '
        Me.txtNumOrden.Location = New System.Drawing.Point(94, 100)
        Me.txtNumOrden.MaxLength = 30
        Me.txtNumOrden.Name = "txtNumOrden"
        Me.txtNumOrden.ReadOnly = True
        Me.txtNumOrden.Size = New System.Drawing.Size(175, 20)
        Me.txtNumOrden.TabIndex = 7
        Me.txtNumOrden.TabStop = False
        Me.txtNumOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(94, 48)
        Me.txtDescripcion.MaxLength = 30
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(433, 20)
        Me.txtDescripcion.TabIndex = 4
        Me.txtDescripcion.TabStop = False
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(390, 74)
        Me.txtTipoCambio.MaxLength = 30
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(69, 20)
        Me.txtTipoCambio.TabIndex = 6
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(94, 22)
        Me.txtNumDoc.MaxLength = 30
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(83, 20)
        Me.txtNumDoc.TabIndex = 1
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox1.Controls.Add(Me.dgvDatos)
        Me.UiGroupBox1.Controls.Add(Me.cmbCodMot)
        Me.UiGroupBox1.Controls.Add(Me.cmbCodPag)
        Me.UiGroupBox1.Controls.Add(Me.cmbNumJob)
        Me.UiGroupBox1.Controls.Add(Me.txtFecDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.lblNumero)
        Me.UiGroupBox1.Controls.Add(Me.txtNumOrden)
        Me.UiGroupBox1.Controls.Add(Me.txtDescripcion)
        Me.UiGroupBox1.Controls.Add(Me.txtTipoCambio)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 5)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(552, 303)
        Me.UiGroupBox1.TabIndex = 81
        Me.UiGroupBox1.Text = "Datos de la OT"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.DataSource = Me.dgvDatos.Layouts
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(6, 128)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(540, 168)
        Me.dgvDatos.TabIndex = 271
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtTotalBruto)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalBruto)
        Me.UiGroupBox6.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox6.Controls.Add(Me.btnAceptar)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoIgv)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoDscto)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoDscto)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalNeto)
        Me.UiGroupBox6.Controls.Add(Me.txtValorVenta)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoVenta)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoIgv)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalNeto)
        Me.UiGroupBox6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox6.Location = New System.Drawing.Point(0, 324)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(587, 146)
        Me.UiGroupBox6.TabIndex = 273
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalBruto
        '
        Me.txtTotalBruto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBruto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalBruto.Location = New System.Drawing.Point(411, 11)
        Me.txtTotalBruto.MaxLength = 5
        Me.txtTotalBruto.Name = "txtTotalBruto"
        Me.txtTotalBruto.ReadOnly = True
        Me.txtTotalBruto.Size = New System.Drawing.Size(104, 20)
        Me.txtTotalBruto.TabIndex = 10
        Me.txtTotalBruto.TabStop = False
        Me.txtTotalBruto.Text = "0.00"
        Me.txtTotalBruto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalBruto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBruto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotalBruto
        '
        Me.lblTotalBruto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalBruto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalBruto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBruto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalBruto.Location = New System.Drawing.Point(16, 11)
        Me.lblTotalBruto.MaxLength = 20
        Me.lblTotalBruto.Name = "lblTotalBruto"
        Me.lblTotalBruto.ReadOnly = True
        Me.lblTotalBruto.Size = New System.Drawing.Size(396, 20)
        Me.lblTotalBruto.TabIndex = 9
        Me.lblTotalBruto.TabStop = False
        Me.lblTotalBruto.Text = "TOTAL MONTO BRUTO:"
        Me.lblTotalBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoIgv
        '
        Me.txtMontoIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIgv.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoIgv.Location = New System.Drawing.Point(411, 68)
        Me.txtMontoIgv.MaxLength = 5
        Me.txtMontoIgv.Name = "txtMontoIgv"
        Me.txtMontoIgv.ReadOnly = True
        Me.txtMontoIgv.Size = New System.Drawing.Size(104, 20)
        Me.txtMontoIgv.TabIndex = 16
        Me.txtMontoIgv.TabStop = False
        Me.txtMontoIgv.Text = "0.00"
        Me.txtMontoIgv.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoDscto
        '
        Me.txtMontoDscto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoDscto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoDscto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoDscto.Location = New System.Drawing.Point(411, 30)
        Me.txtMontoDscto.MaxLength = 5
        Me.txtMontoDscto.Name = "txtMontoDscto"
        Me.txtMontoDscto.ReadOnly = True
        Me.txtMontoDscto.Size = New System.Drawing.Size(104, 20)
        Me.txtMontoDscto.TabIndex = 14
        Me.txtMontoDscto.TabStop = False
        Me.txtMontoDscto.Text = "0.00"
        Me.txtMontoDscto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoDscto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoDscto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoDscto
        '
        Me.lblMontoDscto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoDscto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoDscto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoDscto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoDscto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoDscto.Location = New System.Drawing.Point(16, 30)
        Me.lblMontoDscto.MaxLength = 20
        Me.lblMontoDscto.Name = "lblMontoDscto"
        Me.lblMontoDscto.ReadOnly = True
        Me.lblMontoDscto.Size = New System.Drawing.Size(396, 20)
        Me.lblMontoDscto.TabIndex = 13
        Me.lblMontoDscto.TabStop = False
        Me.lblMontoDscto.Text = "TOTAL MONTO DSCTO:"
        Me.lblMontoDscto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNeto.Location = New System.Drawing.Point(411, 87)
        Me.txtTotalNeto.MaxLength = 5
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(104, 20)
        Me.txtTotalNeto.TabIndex = 12
        Me.txtTotalNeto.TabStop = False
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtValorVenta
        '
        Me.txtValorVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtValorVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorVenta.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtValorVenta.Location = New System.Drawing.Point(411, 49)
        Me.txtValorVenta.MaxLength = 5
        Me.txtValorVenta.Name = "txtValorVenta"
        Me.txtValorVenta.ReadOnly = True
        Me.txtValorVenta.Size = New System.Drawing.Size(104, 20)
        Me.txtValorVenta.TabIndex = 3
        Me.txtValorVenta.TabStop = False
        Me.txtValorVenta.Text = "0.00"
        Me.txtValorVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtValorVenta.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtValorVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoVenta
        '
        Me.lblMontoVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoVenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoVenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoVenta.Location = New System.Drawing.Point(16, 49)
        Me.lblMontoVenta.MaxLength = 20
        Me.lblMontoVenta.Name = "lblMontoVenta"
        Me.lblMontoVenta.ReadOnly = True
        Me.lblMontoVenta.Size = New System.Drawing.Size(396, 20)
        Me.lblMontoVenta.TabIndex = 8
        Me.lblMontoVenta.TabStop = False
        Me.lblMontoVenta.Text = "TOTAL VALOR VENTA:"
        Me.lblMontoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMontoIgv
        '
        Me.lblMontoIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoIgv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoIgv.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoIgv.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoIgv.Location = New System.Drawing.Point(16, 68)
        Me.lblMontoIgv.MaxLength = 20
        Me.lblMontoIgv.Name = "lblMontoIgv"
        Me.lblMontoIgv.ReadOnly = True
        Me.lblMontoIgv.Size = New System.Drawing.Size(396, 20)
        Me.lblMontoIgv.TabIndex = 15
        Me.lblMontoIgv.TabStop = False
        Me.lblMontoIgv.Text = "TOTAL MONTO IGV:"
        Me.lblMontoIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalNeto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalNeto.Location = New System.Drawing.Point(16, 87)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(396, 20)
        Me.lblTotalNeto.TabIndex = 11
        Me.lblTotalNeto.TabStop = False
        Me.lblTotalNeto.Text = "TOTAL MONTO NETO:"
        Me.lblTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmFactura_AtenderJob
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(587, 470)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(999, 999)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(479, 283)
        Me.Name = "frmFactura_AtenderJob"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturar OT"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbNumJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmbCodMot As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCodPag As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbNumJob As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents txtNumOrden As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalBruto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoVenta As System.Windows.Forms.TextBox
    Friend WithEvents txtValorVenta As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalBruto As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoIgv As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoDscto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoDscto As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalNeto As System.Windows.Forms.TextBox
End Class
