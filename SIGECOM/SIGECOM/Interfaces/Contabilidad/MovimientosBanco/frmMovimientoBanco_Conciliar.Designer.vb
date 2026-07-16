<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientoBanco_Conciliar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientoBanco_Conciliar))
        Dim cmbNumCuenta_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbBanco_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biConciliarDet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbNumCuenta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalDebe = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalHaber = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalHaber = New System.Windows.Forms.TextBox()
        Me.lblTotalDebe = New System.Windows.Forms.TextBox()
        Me.txtIdMovimiento = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdConciliacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdMovimientoDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdMovimiento1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AbrTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipMov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAnio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbNumCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biConciliarDet, Me.ToolStripSeparator6, Me.biActualizar, Me.ToolStripSeparator3, Me.biCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(717, 31)
        Me.ToolStrip.TabIndex = 190
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biConciliarDet
        '
        Me.biConciliarDet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biConciliarDet.Image = CType(resources.GetObject("biConciliarDet.Image"), System.Drawing.Image)
        Me.biConciliarDet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biConciliarDet.Name = "biConciliarDet"
        Me.biConciliarDet.Size = New System.Drawing.Size(28, 28)
        Me.biConciliarDet.Text = "Agregar"
        Me.biConciliarDet.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator6.Visible = False
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cmbNumCuenta)
        Me.UiGroupBox1.Controls.Add(Me.cmbMes)
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox6)
        Me.UiGroupBox1.Controls.Add(Me.txtIdMovimiento)
        Me.UiGroupBox1.Controls.Add(Me.DataGridView1)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.txtAnio)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.lblPersona)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.cmbBanco)
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(703, 85)
        Me.UiGroupBox1.TabIndex = 247
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbNumCuenta
        '
        Me.cmbNumCuenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbNumCuenta_DesignTimeLayout.LayoutString = resources.GetString("cmbNumCuenta_DesignTimeLayout.LayoutString")
        Me.cmbNumCuenta.DesignTimeLayout = cmbNumCuenta_DesignTimeLayout
        Me.cmbNumCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNumCuenta.Location = New System.Drawing.Point(444, 51)
        Me.cmbNumCuenta.Name = "cmbNumCuenta"
        Me.cmbNumCuenta.ReadOnly = True
        Me.cmbNumCuenta.SelectedIndex = -1
        Me.cmbNumCuenta.SelectedItem = Nothing
        Me.cmbNumCuenta.Size = New System.Drawing.Size(149, 19)
        Me.cmbNumCuenta.TabIndex = 5
        Me.cmbNumCuenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(362, 16)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.ReadOnly = True
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(122, 20)
        Me.cmbMes.TabIndex = 2
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtTotalDebe)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalHaber)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalHaber)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalDebe)
        Me.UiGroupBox6.Location = New System.Drawing.Point(617, 7)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(45, 38)
        Me.UiGroupBox6.TabIndex = 247
        Me.UiGroupBox6.Visible = False
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalDebe
        '
        Me.txtTotalDebe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDebe.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDebe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebe.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDebe.Location = New System.Drawing.Point(585, 11)
        Me.txtTotalDebe.MaxLength = 5
        Me.txtTotalDebe.Name = "txtTotalDebe"
        Me.txtTotalDebe.ReadOnly = True
        Me.txtTotalDebe.Size = New System.Drawing.Size(22, 20)
        Me.txtTotalDebe.TabIndex = 11
        Me.txtTotalDebe.TabStop = False
        Me.txtTotalDebe.Text = "0.00"
        Me.txtTotalDebe.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDebe.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDebe.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalHaber
        '
        Me.txtTotalHaber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalHaber.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalHaber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHaber.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalHaber.Location = New System.Drawing.Point(585, 29)
        Me.txtTotalHaber.MaxLength = 5
        Me.txtTotalHaber.Name = "txtTotalHaber"
        Me.txtTotalHaber.ReadOnly = True
        Me.txtTotalHaber.Size = New System.Drawing.Size(22, 20)
        Me.txtTotalHaber.TabIndex = 6
        Me.txtTotalHaber.TabStop = False
        Me.txtTotalHaber.Text = "0.00"
        Me.txtTotalHaber.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalHaber.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalHaber.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotalHaber
        '
        Me.lblTotalHaber.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalHaber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalHaber.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalHaber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHaber.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalHaber.Location = New System.Drawing.Point(6, 30)
        Me.lblTotalHaber.MaxLength = 20
        Me.lblTotalHaber.Name = "lblTotalHaber"
        Me.lblTotalHaber.ReadOnly = True
        Me.lblTotalHaber.Size = New System.Drawing.Size(35, 20)
        Me.lblTotalHaber.TabIndex = 10
        Me.lblTotalHaber.TabStop = False
        Me.lblTotalHaber.Text = "TOTAL HABER  "
        Me.lblTotalHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalDebe
        '
        Me.lblTotalDebe.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalDebe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalDebe.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalDebe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDebe.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalDebe.Location = New System.Drawing.Point(6, 6)
        Me.lblTotalDebe.MaxLength = 20
        Me.lblTotalDebe.Name = "lblTotalDebe"
        Me.lblTotalDebe.ReadOnly = True
        Me.lblTotalDebe.Size = New System.Drawing.Size(35, 20)
        Me.lblTotalDebe.TabIndex = 12
        Me.lblTotalDebe.TabStop = False
        Me.lblTotalDebe.Text = "TOTAL DEBE  "
        Me.lblTotalDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIdMovimiento
        '
        Me.txtIdMovimiento.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdMovimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMovimiento.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdMovimiento.Location = New System.Drawing.Point(8, 16)
        Me.txtIdMovimiento.MaxLength = 20
        Me.txtIdMovimiento.Name = "txtIdMovimiento"
        Me.txtIdMovimiento.ReadOnly = True
        Me.txtIdMovimiento.Size = New System.Drawing.Size(67, 20)
        Me.txtIdMovimiento.TabIndex = 3
        Me.txtIdMovimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdMovimiento.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdConciliacion, Me.IdMovimientoDet, Me.IdMovimiento1, Me.Fecha, Me.FecPlanilla, Me.FecBanco, Me.Cheque, Me.Descripcion, Me.CodTipo, Me.AbrTipo, Me.TipMov, Me.Monto})
        Me.DataGridView1.Location = New System.Drawing.Point(574, 9)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(37, 38)
        Me.DataGridView1.TabIndex = 248
        Me.DataGridView1.Visible = False
        '
        'IdConciliacion
        '
        Me.IdConciliacion.DataPropertyName = "IdConciliacion"
        Me.IdConciliacion.HeaderText = "IdConciliacion"
        Me.IdConciliacion.Name = "IdConciliacion"
        '
        'IdMovimientoDet
        '
        Me.IdMovimientoDet.DataPropertyName = "IdMovimientoDet"
        Me.IdMovimientoDet.HeaderText = "IdMovimientoDet"
        Me.IdMovimientoDet.Name = "IdMovimientoDet"
        '
        'IdMovimiento1
        '
        Me.IdMovimiento1.DataPropertyName = "IdMovimiento"
        Me.IdMovimiento1.HeaderText = "IdMovimiento"
        Me.IdMovimiento1.Name = "IdMovimiento1"
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        '
        'FecPlanilla
        '
        Me.FecPlanilla.DataPropertyName = "FecPlanilla"
        Me.FecPlanilla.HeaderText = "FecPlanilla"
        Me.FecPlanilla.Name = "FecPlanilla"
        '
        'FecBanco
        '
        Me.FecBanco.DataPropertyName = "FecBanco"
        Me.FecBanco.HeaderText = "FecBanco"
        Me.FecBanco.Name = "FecBanco"
        '
        'Cheque
        '
        Me.Cheque.DataPropertyName = "Cheque"
        Me.Cheque.HeaderText = "Cheque"
        Me.Cheque.Name = "Cheque"
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        '
        'CodTipo
        '
        Me.CodTipo.DataPropertyName = "CodTipo"
        Me.CodTipo.HeaderText = "CodTipo"
        Me.CodTipo.Name = "CodTipo"
        '
        'AbrTipo
        '
        Me.AbrTipo.DataPropertyName = "AbrTipo"
        Me.AbrTipo.HeaderText = "AbrTipo"
        Me.AbrTipo.Name = "AbrTipo"
        '
        'TipMov
        '
        Me.TipMov.DataPropertyName = "TipMov"
        Me.TipMov.HeaderText = "TipMov"
        Me.TipMov.Name = "TipMov"
        '
        'Monto
        '
        Me.Monto.DataPropertyName = "Monto"
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(209, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 213
        Me.Label9.Text = "Año"
        '
        'txtAnio
        '
        Me.txtAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnio.Location = New System.Drawing.Point(244, 16)
        Me.txtAnio.Maximum = 2020
        Me.txtAnio.Minimum = 2006
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.ReadOnly = True
        Me.txtAnio.Size = New System.Drawing.Size(53, 20)
        Me.txtAnio.TabIndex = 1
        Me.txtAnio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtAnio.Value = 2006
        Me.txtAnio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(329, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 211
        Me.Label3.Text = "Mes"
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersona.Location = New System.Drawing.Point(109, 54)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(43, 13)
        Me.lblPersona.TabIndex = 228
        Me.lblPersona.Text = "Banco"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(359, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 229
        Me.Label7.Text = "Num. Cuenta"
        '
        'cmbBanco
        '
        Me.cmbBanco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbBanco_DesignTimeLayout.LayoutString = resources.GetString("cmbBanco_DesignTimeLayout.LayoutString")
        Me.cmbBanco.DesignTimeLayout = cmbBanco_DesignTimeLayout
        Me.cmbBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBanco.Location = New System.Drawing.Point(157, 51)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.ReadOnly = True
        Me.cmbBanco.SelectedIndex = -1
        Me.cmbBanco.SelectedItem = Nothing
        Me.cmbBanco.Size = New System.Drawing.Size(177, 19)
        Me.cmbBanco.TabIndex = 4
        Me.cmbBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbDetalle
        '
        Me.gbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(6, 125)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(703, 336)
        Me.gbDetalle.TabIndex = 248
        Me.gbDetalle.Text = "Detalles"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(8, 16)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(686, 311)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripSeparator5, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmMovimientoBanco_Conciliar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(717, 468)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovimientoBanco_Conciliar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conciliar"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbNumCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biConciliarDet As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbNumCuenta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalDebe As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalHaber As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalHaber As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalDebe As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtIdMovimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAnio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents IdConciliacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdMovimientoDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdMovimiento1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecBanco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AbrTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipMov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
End Class
