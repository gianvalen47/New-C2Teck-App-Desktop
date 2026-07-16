<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAtenderJob_Detalles
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
        Dim cmbAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim cmbIdSerieDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAtenderJob_Detalles))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.biDespachar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.biSeparar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerarTransferencia = New System.Windows.Forms.ToolStripButton()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cCodMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCanPed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCanAte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCanPen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAtender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPreSeleccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTransito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbSeleccionrTodos = New Janus.Windows.EditControls.UICheckBox()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtPersonal = New System.Windows.Forms.TextBox()
        Me.btnBuscarPersonal = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbIdSerieDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbTipo = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbProvisional = New System.Windows.Forms.RadioButton()
        Me.rbVale = New System.Windows.Forms.RadioButton()
        Me.rbTransInt = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbVale = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnPreSeleccionar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdSerieDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipo.SuspendLayout()
        CType(Me.gbVale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbVale.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cmbAlmacen_DesignTimeLayout.LayoutString")
        Me.cmbAlmacen.DesignTimeLayout = cmbAlmacen_DesignTimeLayout
        Me.cmbAlmacen.Location = New System.Drawing.Point(73, 55)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.SelectedIndex = -1
        Me.cmbAlmacen.SelectedItem = Nothing
        Me.cmbAlmacen.Size = New System.Drawing.Size(168, 20)
        Me.cmbAlmacen.TabIndex = 1
        Me.cmbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biImprimir, Me.biDespachar, Me.ToolStripSeparator1, Me.biDeshacer, Me.biSeparar, Me.ToolStripSeparator2, Me.biGenerarTransferencia, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(705, 31)
        Me.ToolStrip.TabIndex = 28
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Listado"
        '
        'biDespachar
        '
        Me.biDespachar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDespachar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biDespachar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDespachar.Name = "biDespachar"
        Me.biDespachar.Size = New System.Drawing.Size(28, 28)
        Me.biDespachar.Text = "Despachar Mercadería"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios Realizados"
        '
        'biSeparar
        '
        Me.biSeparar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSeparar.Image = Global.SIGECOM.My.Resources.Resources.CrdFle04
        Me.biSeparar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSeparar.Name = "biSeparar"
        Me.biSeparar.Size = New System.Drawing.Size(28, 28)
        Me.biSeparar.Text = "Separar Mercadería"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerarTransferencia
        '
        Me.biGenerarTransferencia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarTransferencia.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.biGenerarTransferencia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarTransferencia.Name = "biGenerarTransferencia"
        Me.biGenerarTransferencia.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarTransferencia.Text = "Generar Documento"
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
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(12, 59)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(55, 13)
        Me.lblAlmacen.TabIndex = 29
        Me.lblAlmacen.Text = "Almacén"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 534)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(705, 20)
        Me.ssBarra.TabIndex = 31
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(350, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(141, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 383)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Número"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(172, 383)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Fecha"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(66, 380)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(80, 20)
        Me.txtNumero.TabIndex = 2
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodMer, Me.cDesMer, Me.cCanPed, Me.cCanAte, Me.cCanPen, Me.cAtender, Me.cStock, Me.cPreSeleccion, Me.CTransito})
        Me.dgvDatos.Location = New System.Drawing.Point(6, 94)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(675, 288)
        Me.dgvDatos.TabIndex = 34
        '
        'cCodMer
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodMer.DefaultCellStyle = DataGridViewCellStyle2
        Me.cCodMer.HeaderText = "Código"
        Me.cCodMer.Name = "cCodMer"
        Me.cCodMer.ReadOnly = True
        Me.cCodMer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cCodMer.Width = 90
        '
        'cDesMer
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.cDesMer.DefaultCellStyle = DataGridViewCellStyle3
        Me.cDesMer.HeaderText = "Descripción"
        Me.cDesMer.Name = "cDesMer"
        Me.cDesMer.ReadOnly = True
        Me.cDesMer.Width = 175
        '
        'cCanPed
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCanPed.DefaultCellStyle = DataGridViewCellStyle4
        Me.cCanPed.HeaderText = "Can.Ped."
        Me.cCanPed.Name = "cCanPed"
        Me.cCanPed.ReadOnly = True
        Me.cCanPed.Width = 60
        '
        'cCanAte
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCanAte.DefaultCellStyle = DataGridViewCellStyle5
        Me.cCanAte.HeaderText = "Can.Ate."
        Me.cCanAte.Name = "cCanAte"
        Me.cCanAte.ReadOnly = True
        Me.cCanAte.Width = 55
        '
        'cCanPen
        '
        Me.cCanPen.HeaderText = "Can.Pen."
        Me.cCanPen.Name = "cCanPen"
        Me.cCanPen.ReadOnly = True
        Me.cCanPen.Width = 60
        '
        'cAtender
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.cAtender.DefaultCellStyle = DataGridViewCellStyle6
        Me.cAtender.HeaderText = "Atender"
        Me.cAtender.Name = "cAtender"
        Me.cAtender.ReadOnly = True
        Me.cAtender.Width = 55
        '
        'cStock
        '
        Me.cStock.HeaderText = "Stock"
        Me.cStock.Name = "cStock"
        Me.cStock.ReadOnly = True
        Me.cStock.Width = 55
        '
        'cPreSeleccion
        '
        Me.cPreSeleccion.HeaderText = "PreSeleccion"
        Me.cPreSeleccion.Name = "cPreSeleccion"
        Me.cPreSeleccion.ReadOnly = True
        Me.cPreSeleccion.Visible = False
        '
        'CTransito
        '
        Me.CTransito.HeaderText = "Transito"
        Me.CTransito.Name = "CTransito"
        Me.CTransito.ReadOnly = True
        Me.CTransito.Width = 55
        '
        'rbSeleccionrTodos
        '
        Me.rbSeleccionrTodos.Enabled = False
        Me.rbSeleccionrTodos.Location = New System.Drawing.Point(492, 68)
        Me.rbSeleccionrTodos.Name = "rbSeleccionrTodos"
        Me.rbSeleccionrTodos.Size = New System.Drawing.Size(20, 23)
        Me.rbSeleccionrTodos.TabIndex = 35
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(220, 380)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.ShowNullButton = True
        Me.txtFecha.Size = New System.Drawing.Size(85, 20)
        Me.txtFecha.TabIndex = 3
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtPersonal
        '
        Me.txtPersonal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonal.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersonal.Location = New System.Drawing.Point(292, 14)
        Me.txtPersonal.MaxLength = 3
        Me.txtPersonal.Name = "txtPersonal"
        Me.txtPersonal.ReadOnly = True
        Me.txtPersonal.Size = New System.Drawing.Size(257, 20)
        Me.txtPersonal.TabIndex = 67
        Me.txtPersonal.TabStop = False
        '
        'btnBuscarPersonal
        '
        Me.btnBuscarPersonal.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersonal.Location = New System.Drawing.Point(553, 13)
        Me.btnBuscarPersonal.Name = "btnBuscarPersonal"
        Me.btnBuscarPersonal.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersonal.TabIndex = 68
        Me.btnBuscarPersonal.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Doc."
        '
        'cmbIdSerieDoc
        '
        Me.cmbIdSerieDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdSerieDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbIdSerieDoc_DesignTimeLayout.LayoutString")
        Me.cmbIdSerieDoc.DesignTimeLayout = cmbIdSerieDoc_DesignTimeLayout
        Me.cmbIdSerieDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdSerieDoc.Location = New System.Drawing.Point(44, 13)
        Me.cmbIdSerieDoc.Name = "cmbIdSerieDoc"
        Me.cmbIdSerieDoc.SelectedIndex = -1
        Me.cmbIdSerieDoc.SelectedItem = Nothing
        Me.cmbIdSerieDoc.Size = New System.Drawing.Size(168, 20)
        Me.cmbIdSerieDoc.TabIndex = 70
        Me.cmbIdSerieDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbTipo
        '
        Me.gbTipo.Controls.Add(Me.rbProvisional)
        Me.gbTipo.Controls.Add(Me.rbVale)
        Me.gbTipo.Controls.Add(Me.rbTransInt)
        Me.gbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipo.Location = New System.Drawing.Point(12, 416)
        Me.gbTipo.Name = "gbTipo"
        Me.gbTipo.Size = New System.Drawing.Size(586, 40)
        Me.gbTipo.TabIndex = 112
        Me.gbTipo.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbTipo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbProvisional
        '
        Me.rbProvisional.AutoSize = True
        Me.rbProvisional.Location = New System.Drawing.Point(385, 15)
        Me.rbProvisional.Name = "rbProvisional"
        Me.rbProvisional.Size = New System.Drawing.Size(186, 17)
        Me.rbProvisional.TabIndex = 16
        Me.rbProvisional.Text = "Vale de Almacen Provisional"
        Me.rbProvisional.UseVisualStyleBackColor = True
        '
        'rbVale
        '
        Me.rbVale.AutoSize = True
        Me.rbVale.Location = New System.Drawing.Point(218, 15)
        Me.rbVale.Name = "rbVale"
        Me.rbVale.Size = New System.Drawing.Size(120, 17)
        Me.rbVale.TabIndex = 1
        Me.rbVale.Text = "Vale de Almacen"
        Me.rbVale.UseVisualStyleBackColor = True
        '
        'rbTransInt
        '
        Me.rbTransInt.AutoSize = True
        Me.rbTransInt.Checked = True
        Me.rbTransInt.Location = New System.Drawing.Point(15, 15)
        Me.rbTransInt.Name = "rbTransInt"
        Me.rbTransInt.Size = New System.Drawing.Size(147, 17)
        Me.rbTransInt.TabIndex = 15
        Me.rbTransInt.TabStop = True
        Me.rbTransInt.Text = "Transferencia Interna"
        Me.rbTransInt.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(230, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Personal"
        '
        'gbVale
        '
        Me.gbVale.Controls.Add(Me.cmbIdSerieDoc)
        Me.gbVale.Controls.Add(Me.Label3)
        Me.gbVale.Controls.Add(Me.btnBuscarPersonal)
        Me.gbVale.Controls.Add(Me.txtPersonal)
        Me.gbVale.Controls.Add(Me.Label8)
        Me.gbVale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbVale.Location = New System.Drawing.Point(12, 462)
        Me.gbVale.Name = "gbVale"
        Me.gbVale.Size = New System.Drawing.Size(586, 40)
        Me.gbVale.TabIndex = 114
        Me.gbVale.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbVale.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnPreSeleccionar
        '
        Me.btnPreSeleccionar.Enabled = False
        Me.btnPreSeleccionar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreSeleccionar.Image = CType(resources.GetObject("btnPreSeleccionar.Image"), System.Drawing.Image)
        Me.btnPreSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreSeleccionar.Location = New System.Drawing.Point(354, 65)
        Me.btnPreSeleccionar.Name = "btnPreSeleccionar"
        Me.btnPreSeleccionar.Size = New System.Drawing.Size(109, 25)
        Me.btnPreSeleccionar.TabIndex = 194
        Me.btnPreSeleccionar.Text = "Pre Selección"
        Me.btnPreSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreSeleccionar.UseVisualStyleBackColor = True
        '
        'frmAtenderJob_Detalles
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(705, 554)
        Me.Controls.Add(Me.btnPreSeleccionar)
        Me.Controls.Add(Me.gbVale)
        Me.Controls.Add(Me.gbTipo)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.rbSeleccionrTodos)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.lblAlmacen)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.cmbAlmacen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAtenderJob_Detalles"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAtenderJob_Detalles"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdSerieDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipo.ResumeLayout(False)
        Me.gbTipo.PerformLayout()
        CType(Me.gbVale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbVale.ResumeLayout(False)
        Me.gbVale.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biDespachar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSeparar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents biGenerarTransferencia As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents rbSeleccionrTodos As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtPersonal As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarPersonal As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbIdSerieDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbTipo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbVale As System.Windows.Forms.RadioButton
    Friend WithEvents rbTransInt As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbVale As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnPreSeleccionar As System.Windows.Forms.Button
    Friend WithEvents rbProvisional As RadioButton
    Friend WithEvents cCodMer As DataGridViewTextBoxColumn
    Friend WithEvents cDesMer As DataGridViewTextBoxColumn
    Friend WithEvents cCanPed As DataGridViewTextBoxColumn
    Friend WithEvents cCanAte As DataGridViewTextBoxColumn
    Friend WithEvents cCanPen As DataGridViewTextBoxColumn
    Friend WithEvents cAtender As DataGridViewTextBoxColumn
    Friend WithEvents cStock As DataGridViewTextBoxColumn
    Friend WithEvents cPreSeleccion As DataGridViewTextBoxColumn
    Friend WithEvents CTransito As DataGridViewTextBoxColumn
End Class
