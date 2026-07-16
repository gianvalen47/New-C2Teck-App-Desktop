<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocsCredito
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
        Dim cbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocsCredito))
        Dim cbCobrador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbCondicionPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbDocumento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtSaldoNS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtSaldoUS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtFechaVencimiento = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFechaRecepcion = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFechaEmision = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbCobrador = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblCobrador = New System.Windows.Forms.Label()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.txtApeMat = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtApePat = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDni = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.RichTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtImporteNS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtImporteUS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtRenovacion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbCondicionPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtGuia = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAlmacen = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOficina = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbDocumento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCobrador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.cbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCondicionPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnModificar, Me.ToolStripSeparator2, Me.btnGrabar, Me.ToolStripSeparator5, Me.btnCancelar, Me.ToolStripSeparator4, Me.btnSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(823, 31)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnModificar
        '
        Me.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnModificar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(28, 28)
        Me.btnModificar.Text = "ToolStripButton2"
        Me.btnModificar.ToolTipText = "Modificar Documento"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'btnGrabar
        '
        Me.btnGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGrabar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(28, 28)
        Me.btnGrabar.Text = "ToolStripButton1"
        Me.btnGrabar.ToolTipText = "Grabar"
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
        Me.btnCancelar.Text = "ToolStripButton1"
        Me.btnCancelar.ToolTipText = "Cancelar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(28, 28)
        Me.btnSalir.Text = "ToolStripButton1"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox1.Controls.Add(Me.Label23)
        Me.UiGroupBox1.Controls.Add(Me.txtSaldoNS)
        Me.UiGroupBox1.Controls.Add(Me.txtSaldoUS)
        Me.UiGroupBox1.Controls.Add(Me.Label22)
        Me.UiGroupBox1.Controls.Add(Me.Label18)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaVencimiento)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaRecepcion)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaEmision)
        Me.UiGroupBox1.Controls.Add(Me.cbCodMon)
        Me.UiGroupBox1.Controls.Add(Me.cbCobrador)
        Me.UiGroupBox1.Controls.Add(Me.lblCobrador)
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox3)
        Me.UiGroupBox1.Controls.Add(Me.cbEstado)
        Me.UiGroupBox1.Controls.Add(Me.lblEstado)
        Me.UiGroupBox1.Controls.Add(Me.Label17)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label16)
        Me.UiGroupBox1.Controls.Add(Me.txtImporteNS)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.txtImporteUS)
        Me.UiGroupBox1.Controls.Add(Me.txtRenovacion)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.cbCondicionPago)
        Me.UiGroupBox1.Controls.Add(Me.Label13)
        Me.UiGroupBox1.Controls.Add(Me.txtGuia)
        Me.UiGroupBox1.Controls.Add(Me.Label12)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.txtAlmacen)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.txtOficina)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.txtTipoCambio)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.cbDocumento)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Controls.Add(Me.txtSerie)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 31)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(783, 279)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNumJob
        '
        Me.txtNumJob.Location = New System.Drawing.Point(707, 18)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.ReadOnly = True
        Me.txtNumJob.Size = New System.Drawing.Size(64, 20)
        Me.txtNumJob.TabIndex = 108
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(654, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(42, 13)
        Me.Label23.TabIndex = 107
        Me.Label23.Text = "Nº OT"
        '
        'txtSaldoNS
        '
        Me.txtSaldoNS.Location = New System.Drawing.Point(299, 217)
        Me.txtSaldoNS.Name = "txtSaldoNS"
        Me.txtSaldoNS.ReadOnly = True
        Me.txtSaldoNS.Size = New System.Drawing.Size(108, 20)
        Me.txtSaldoNS.TabIndex = 25
        Me.txtSaldoNS.TabStop = False
        Me.txtSaldoNS.Text = "0.00"
        Me.txtSaldoNS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtSaldoUS
        '
        Me.txtSaldoUS.Location = New System.Drawing.Point(80, 217)
        Me.txtSaldoUS.Name = "txtSaldoUS"
        Me.txtSaldoUS.ReadOnly = True
        Me.txtSaldoUS.Size = New System.Drawing.Size(120, 20)
        Me.txtSaldoUS.TabIndex = 24
        Me.txtSaldoUS.TabStop = False
        Me.txtSaldoUS.Text = "0.00"
        Me.txtSaldoUS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(216, 220)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(75, 13)
        Me.Label22.TabIndex = 105
        Me.Label22.Text = "Saldos S/. :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 220)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 13)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "Saldos $ :"
        '
        'txtFechaVencimiento
        '
        '
        '
        '
        Me.txtFechaVencimiento.DropDownCalendar.Name = ""
        Me.txtFechaVencimiento.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(528, 142)
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.NullButtonText = "Ninguno"
        Me.txtFechaVencimiento.ReadOnly = True
        Me.txtFechaVencimiento.ShowNullButton = True
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(93, 20)
        Me.txtFechaVencimiento.TabIndex = 16
        Me.txtFechaVencimiento.TodayButtonText = "Hoy"
        Me.txtFechaVencimiento.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFechaRecepcion
        '
        '
        '
        '
        Me.txtFechaRecepcion.DropDownCalendar.Name = ""
        Me.txtFechaRecepcion.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaRecepcion.Location = New System.Drawing.Point(310, 142)
        Me.txtFechaRecepcion.Name = "txtFechaRecepcion"
        Me.txtFechaRecepcion.NullButtonText = "Ninguno"
        Me.txtFechaRecepcion.ReadOnly = True
        Me.txtFechaRecepcion.ShowNullButton = True
        Me.txtFechaRecepcion.Size = New System.Drawing.Size(92, 20)
        Me.txtFechaRecepcion.TabIndex = 15
        Me.txtFechaRecepcion.TodayButtonText = "Hoy"
        Me.txtFechaRecepcion.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFechaEmision
        '
        '
        '
        '
        Me.txtFechaEmision.DropDownCalendar.Name = ""
        Me.txtFechaEmision.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaEmision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaEmision.Location = New System.Drawing.Point(105, 142)
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.NullButtonText = "Ninguno"
        Me.txtFechaEmision.ReadOnly = True
        Me.txtFechaEmision.ShowNullButton = True
        Me.txtFechaEmision.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaEmision.TabIndex = 14
        Me.txtFechaEmision.TodayButtonText = "Hoy"
        Me.txtFechaEmision.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbCodMon
        '
        Me.cbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cbCodMon_DesignTimeLayout.LayoutString")
        Me.cbCodMon.DesignTimeLayout = cbCodMon_DesignTimeLayout
        Me.cbCodMon.Location = New System.Drawing.Point(486, 17)
        Me.cbCodMon.Name = "cbCodMon"
        Me.cbCodMon.ReadOnly = True
        Me.cbCodMon.SelectedIndex = -1
        Me.cbCodMon.SelectedItem = Nothing
        Me.cbCodMon.Size = New System.Drawing.Size(47, 20)
        Me.cbCodMon.TabIndex = 4
        Me.cbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbCobrador
        '
        Me.cbCobrador.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbCobrador_DesignTimeLayout.LayoutString = resources.GetString("cbCobrador_DesignTimeLayout.LayoutString")
        Me.cbCobrador.DesignTimeLayout = cbCobrador_DesignTimeLayout
        Me.cbCobrador.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.cbCobrador.Location = New System.Drawing.Point(481, 194)
        Me.cbCobrador.Name = "cbCobrador"
        Me.cbCobrador.SelectedIndex = -1
        Me.cbCobrador.SelectedItem = Nothing
        Me.cbCobrador.Size = New System.Drawing.Size(289, 20)
        Me.cbCobrador.TabIndex = 23
        Me.cbCobrador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblCobrador
        '
        Me.lblCobrador.AutoSize = True
        Me.lblCobrador.Location = New System.Drawing.Point(412, 197)
        Me.lblCobrador.Name = "lblCobrador"
        Me.lblCobrador.Size = New System.Drawing.Size(66, 13)
        Me.lblCobrador.TabIndex = 101
        Me.lblCobrador.Text = "Cobrador :"
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.btnCliente)
        Me.UiGroupBox3.Controls.Add(Me.txtApeMat)
        Me.UiGroupBox3.Controls.Add(Me.Label19)
        Me.UiGroupBox3.Controls.Add(Me.txtApePat)
        Me.UiGroupBox3.Controls.Add(Me.Label20)
        Me.UiGroupBox3.Controls.Add(Me.txtNombres)
        Me.UiGroupBox3.Controls.Add(Me.Label21)
        Me.UiGroupBox3.Controls.Add(Me.txtDni)
        Me.UiGroupBox3.Controls.Add(Me.Label7)
        Me.UiGroupBox3.Controls.Add(Me.txtRuc)
        Me.UiGroupBox3.Controls.Add(Me.Label1)
        Me.UiGroupBox3.Controls.Add(Me.txtCliente)
        Me.UiGroupBox3.Controls.Add(Me.Label3)
        Me.UiGroupBox3.Location = New System.Drawing.Point(6, 40)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(765, 69)
        Me.UiGroupBox3.TabIndex = 66
        Me.UiGroupBox3.Text = "Cliente"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnCliente
        '
        Me.btnCliente.Enabled = False
        Me.btnCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnCliente.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCliente.Location = New System.Drawing.Point(436, 15)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(27, 21)
        Me.btnCliente.TabIndex = 77
        Me.btnCliente.TabStop = False
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'txtApeMat
        '
        Me.txtApeMat.Location = New System.Drawing.Point(621, 41)
        Me.txtApeMat.Name = "txtApeMat"
        Me.txtApeMat.ReadOnly = True
        Me.txtApeMat.Size = New System.Drawing.Size(138, 20)
        Me.txtApeMat.TabIndex = 11
        Me.txtApeMat.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(511, 44)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(110, 13)
        Me.Label19.TabIndex = 76
        Me.Label19.Text = "Apellido Materno :"
        '
        'txtApePat
        '
        Me.txtApePat.Location = New System.Drawing.Point(377, 41)
        Me.txtApePat.Name = "txtApePat"
        Me.txtApePat.ReadOnly = True
        Me.txtApePat.Size = New System.Drawing.Size(133, 20)
        Me.txtApePat.TabIndex = 10
        Me.txtApePat.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(268, 44)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 13)
        Me.Label20.TabIndex = 74
        Me.Label20.Text = "Apellido Paterno :"
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(74, 41)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.ReadOnly = True
        Me.txtNombres.Size = New System.Drawing.Size(191, 20)
        Me.txtNombres.TabIndex = 9
        Me.txtNombres.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 44)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 13)
        Me.Label21.TabIndex = 72
        Me.Label21.Text = "Nombres :"
        '
        'txtDni
        '
        Me.txtDni.Location = New System.Drawing.Point(654, 16)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.ReadOnly = True
        Me.txtDni.Size = New System.Drawing.Size(105, 20)
        Me.txtDni.TabIndex = 8
        Me.txtDni.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(618, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "Dni :"
        '
        'txtRuc
        '
        Me.txtRuc.Location = New System.Drawing.Point(505, 16)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.ReadOnly = True
        Me.txtRuc.Size = New System.Drawing.Size(105, 20)
        Me.txtRuc.TabIndex = 7
        Me.txtRuc.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(464, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Ruc :"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(99, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(337, 20)
        Me.txtCliente.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Razon Social :"
        '
        'cbEstado
        '
        Me.cbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbEstado_DesignTimeLayout.LayoutString = resources.GetString("cbEstado_DesignTimeLayout.LayoutString")
        Me.cbEstado.DesignTimeLayout = cbEstado_DesignTimeLayout
        Me.cbEstado.Location = New System.Drawing.Point(575, 168)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.ReadOnly = True
        Me.cbEstado.SelectedIndex = -1
        Me.cbEstado.SelectedItem = Nothing
        Me.cbEstado.Size = New System.Drawing.Size(195, 20)
        Me.cbEstado.TabIndex = 20
        Me.cbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(518, 171)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(54, 13)
        Me.lblEstado.TabIndex = 58
        Me.lblEstado.Text = "Estado :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 247)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 13)
        Me.Label17.TabIndex = 57
        Me.Label17.Text = "Observacion :"
        '
        'txtObservacion
        '
        Me.txtObservacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservacion.Location = New System.Drawing.Point(105, 244)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.Size = New System.Drawing.Size(505, 20)
        Me.txtObservacion.TabIndex = 26
        Me.txtObservacion.Text = ""
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(216, 197)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 13)
        Me.Label16.TabIndex = 55
        Me.Label16.Text = "Importe S/. :"
        '
        'txtImporteNS
        '
        Me.txtImporteNS.Location = New System.Drawing.Point(299, 194)
        Me.txtImporteNS.Name = "txtImporteNS"
        Me.txtImporteNS.ReadOnly = True
        Me.txtImporteNS.Size = New System.Drawing.Size(108, 20)
        Me.txtImporteNS.TabIndex = 22
        Me.txtImporteNS.Text = "0.00"
        Me.txtImporteNS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 197)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "Importe $ :"
        '
        'txtImporteUS
        '
        Me.txtImporteUS.Location = New System.Drawing.Point(81, 194)
        Me.txtImporteUS.Name = "txtImporteUS"
        Me.txtImporteUS.ReadOnly = True
        Me.txtImporteUS.Size = New System.Drawing.Size(120, 20)
        Me.txtImporteUS.TabIndex = 21
        Me.txtImporteUS.Text = "0.00"
        Me.txtImporteUS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtRenovacion
        '
        Me.txtRenovacion.Location = New System.Drawing.Point(712, 142)
        Me.txtRenovacion.Name = "txtRenovacion"
        Me.txtRenovacion.ReadOnly = True
        Me.txtRenovacion.Size = New System.Drawing.Size(56, 20)
        Me.txtRenovacion.TabIndex = 17
        Me.txtRenovacion.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(624, 145)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Renovacion :"
        '
        'cbCondicionPago
        '
        Me.cbCondicionPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbCondicionPago_DesignTimeLayout.LayoutString = resources.GetString("cbCondicionPago_DesignTimeLayout.LayoutString")
        Me.cbCondicionPago.DesignTimeLayout = cbCondicionPago_DesignTimeLayout
        Me.cbCondicionPago.Location = New System.Drawing.Point(318, 168)
        Me.cbCondicionPago.Name = "cbCondicionPago"
        Me.cbCondicionPago.ReadOnly = True
        Me.cbCondicionPago.SelectedIndex = -1
        Me.cbCondicionPago.SelectedItem = Nothing
        Me.cbCondicionPago.Size = New System.Drawing.Size(194, 20)
        Me.cbCondicionPago.TabIndex = 19
        Me.cbCondicionPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(192, 171)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Condicion de Pago :"
        '
        'txtGuia
        '
        Me.txtGuia.Location = New System.Drawing.Point(57, 168)
        Me.txtGuia.Name = "txtGuia"
        Me.txtGuia.ReadOnly = True
        Me.txtGuia.Size = New System.Drawing.Size(126, 20)
        Me.txtGuia.TabIndex = 18
        Me.txtGuia.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 173)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Guia :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(404, 145)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 13)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Fecha Vencimiento :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(199, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Fecha Recepcion :"
        '
        'txtAlmacen
        '
        Me.txtAlmacen.Location = New System.Drawing.Point(364, 116)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(265, 20)
        Me.txtAlmacen.TabIndex = 13
        Me.txtAlmacen.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(299, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Almacen :"
        '
        'txtOficina
        '
        Me.txtOficina.Location = New System.Drawing.Point(71, 116)
        Me.txtOficina.Name = "txtOficina"
        Me.txtOficina.ReadOnly = True
        Me.txtOficina.Size = New System.Drawing.Size(222, 20)
        Me.txtOficina.TabIndex = 12
        Me.txtOficina.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Oficina :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(582, 18)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(64, 20)
        Me.txtTipoCambio.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(543, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "T.C. :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(427, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Moneda :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Fecha Emision :"
        '
        'cbDocumento
        '
        Me.cbDocumento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbDocumento_DesignTimeLayout.LayoutString = resources.GetString("cbDocumento_DesignTimeLayout.LayoutString")
        Me.cbDocumento.DesignTimeLayout = cbDocumento_DesignTimeLayout
        Me.cbDocumento.Location = New System.Drawing.Point(97, 18)
        Me.cbDocumento.Name = "cbDocumento"
        Me.cbDocumento.ReadOnly = True
        Me.cbDocumento.SelectedIndex = -1
        Me.cbDocumento.SelectedItem = Nothing
        Me.cbDocumento.Size = New System.Drawing.Size(194, 20)
        Me.cbDocumento.TabIndex = 1
        Me.cbDocumento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(336, 18)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(86, 20)
        Me.txtNumDoc.TabIndex = 3
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(293, 18)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(40, 20)
        Me.txtSerie.TabIndex = 2
        Me.txtSerie.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Documento :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox2.Controls.Add(Me.dgvDatos)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(7, 316)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(799, 190)
        Me.UiGroupBox2.TabIndex = 2
        Me.UiGroupBox2.Text = "Pagos"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvDatos.AutomaticSort = False
        Me.dgvDatos.ContextMenuStrip = Me.CMenu
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.EmptyRows = True
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(7, 19)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.Size = New System.Drawing.Size(769, 143)
        Me.dgvDatos.TabIndex = 3
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CMenu
        '
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmNuevo, Me.cmModificar, Me.cmEliminar, Me.ToolStripSeparator3, Me.cmMostrar, Me.cmActualizar})
        Me.CMenu.Name = "ContextMenuStrip1"
        Me.CMenu.Size = New System.Drawing.Size(127, 120)
        '
        'cmNuevo
        '
        Me.cmNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.cmNuevo.Name = "cmNuevo"
        Me.cmNuevo.Size = New System.Drawing.Size(126, 22)
        Me.cmNuevo.Text = "Nuevo"
        '
        'cmModificar
        '
        Me.cmModificar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.cmModificar.Name = "cmModificar"
        Me.cmModificar.Size = New System.Drawing.Size(126, 22)
        Me.cmModificar.Text = "Modificar"
        '
        'cmEliminar
        '
        Me.cmEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.cmEliminar.Name = "cmEliminar"
        Me.cmEliminar.Size = New System.Drawing.Size(126, 22)
        Me.cmEliminar.Text = "Eliminar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(123, 6)
        '
        'cmMostrar
        '
        Me.cmMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.cmMostrar.Name = "cmMostrar"
        Me.cmMostrar.Size = New System.Drawing.Size(126, 22)
        Me.cmMostrar.Text = "Mostrar"
        '
        'cmActualizar
        '
        Me.cmActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.cmActualizar.Name = "cmActualizar"
        Me.cmActualizar.Size = New System.Drawing.Size(126, 22)
        Me.cmActualizar.Text = "Actualizar"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 517)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.ssBarra.Size = New System.Drawing.Size(823, 20)
        Me.ssBarra.TabIndex = 4
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
        Me.sslTotal.Size = New System.Drawing.Size(180, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmDocsCredito
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(823, 537)
        Me.ControlBox = False
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ToolStrip)
        Me.KeyPreview = True
        Me.Name = "frmDocsCredito"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Documento de Credito"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCobrador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.cbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCondicionPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbDocumento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRenovacion As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbCondicionPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtGuia As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtOficina As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.RichTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtImporteNS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtImporteUS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtApeMat As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtApePat As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtDni As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbCobrador As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblCobrador As System.Windows.Forms.Label
    Friend WithEvents cbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents txtFechaVencimiento As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFechaRecepcion As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFechaEmision As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtSaldoUS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoNS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
End Class
