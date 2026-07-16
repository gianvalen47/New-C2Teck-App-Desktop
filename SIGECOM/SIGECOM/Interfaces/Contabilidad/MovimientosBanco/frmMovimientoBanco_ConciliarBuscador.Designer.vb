<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientoBanco_ConciliarBuscador
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
        Dim cmbNumCuenta_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientoBanco_ConciliarBuscador))
        Dim cmbBanco_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim datagridview3_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbNumCuenta = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtIdMovimiento = New System.Windows.Forms.TextBox()
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdMovimientoDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdMovimiento1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FecBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AbrTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipMov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtAnio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cIdMovimientoDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecBanco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAbrTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTipMov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoDebe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoHaber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbAtender = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNinguno = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biIngresar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.datagridview3 = New Janus.Windows.GridEX.GridEX()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbNumCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.datagridview3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cmbNumCuenta)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.lblPersona)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.cmbBanco)
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 96)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(703, 54)
        Me.UiGroupBox1.TabIndex = 248
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbNumCuenta
        '
        Me.cmbNumCuenta.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbNumCuenta_DesignTimeLayout.LayoutString = resources.GetString("cmbNumCuenta_DesignTimeLayout.LayoutString")
        Me.cmbNumCuenta.DesignTimeLayout = cmbNumCuenta_DesignTimeLayout
        Me.cmbNumCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNumCuenta.Location = New System.Drawing.Point(441, 20)
        Me.cmbNumCuenta.Name = "cmbNumCuenta"
        Me.cmbNumCuenta.ReadOnly = True
        Me.cmbNumCuenta.SelectedIndex = -1
        Me.cmbNumCuenta.SelectedItem = Nothing
        Me.cmbNumCuenta.Size = New System.Drawing.Size(149, 19)
        Me.cmbNumCuenta.TabIndex = 5
        Me.cmbNumCuenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nº Movimiento"
        Me.Label1.Visible = False
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersona.Location = New System.Drawing.Point(106, 23)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(43, 13)
        Me.lblPersona.TabIndex = 228
        Me.lblPersona.Text = "Banco"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(356, 24)
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
        Me.cmbBanco.Location = New System.Drawing.Point(154, 20)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.ReadOnly = True
        Me.cmbBanco.SelectedIndex = -1
        Me.cmbBanco.SelectedItem = Nothing
        Me.cmbBanco.Size = New System.Drawing.Size(177, 19)
        Me.cmbBanco.TabIndex = 4
        Me.cmbBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIdMovimiento
        '
        Me.txtIdMovimiento.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdMovimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdMovimiento.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdMovimiento.Location = New System.Drawing.Point(33, 65)
        Me.txtIdMovimiento.MaxLength = 20
        Me.txtIdMovimiento.Name = "txtIdMovimiento"
        Me.txtIdMovimiento.ReadOnly = True
        Me.txtIdMovimiento.Size = New System.Drawing.Size(67, 20)
        Me.txtIdMovimiento.TabIndex = 3
        Me.txtIdMovimiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdMovimiento.Visible = False
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(210, 28)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(122, 20)
        Me.cmbMes.TabIndex = 2
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdMovimientoDet, Me.IdMovimiento1, Me.FecPlanilla, Me.FecBanco, Me.Cheque, Me.AbrTipo, Me.Descripcion, Me.TipMov, Me.Monto})
        Me.DataGridView1.Location = New System.Drawing.Point(676, 48)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(37, 36)
        Me.DataGridView1.TabIndex = 248
        Me.DataGridView1.Visible = False
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
        'AbrTipo
        '
        Me.AbrTipo.DataPropertyName = "AbrTipo"
        Me.AbrTipo.HeaderText = "AbrTipo"
        Me.AbrTipo.Name = "AbrTipo"
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
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
        'txtAnio
        '
        Me.txtAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnio.Location = New System.Drawing.Point(135, 28)
        Me.txtAnio.Maximum = 2020
        Me.txtAnio.Minimum = 2006
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(53, 20)
        Me.txtAnio.TabIndex = 1
        Me.txtAnio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtAnio.Value = 2006
        Me.txtAnio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(12, 261)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(703, 336)
        Me.gbDetalle.TabIndex = 249
        Me.gbDetalle.Text = "Detalles"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdMovimientoDet, Me.cIdMovimiento, Me.cFecPlanilla, Me.cFecBanco, Me.cCheque, Me.cAbrTipo, Me.cDescripcion, Me.cTipMov, Me.cMonto, Me.cMontoDebe, Me.cMontoHaber, Me.cbAtender})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDatos.Location = New System.Drawing.Point(13, 19)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDatos.RowHeadersVisible = False
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(676, 296)
        Me.dgvDatos.TabIndex = 253
        '
        'cIdMovimientoDet
        '
        Me.cIdMovimientoDet.HeaderText = "IdMovDet"
        Me.cIdMovimientoDet.Name = "cIdMovimientoDet"
        Me.cIdMovimientoDet.ReadOnly = True
        Me.cIdMovimientoDet.Visible = False
        '
        'cIdMovimiento
        '
        Me.cIdMovimiento.HeaderText = "IdMov"
        Me.cIdMovimiento.Name = "cIdMovimiento"
        Me.cIdMovimiento.ReadOnly = True
        Me.cIdMovimiento.Visible = False
        Me.cIdMovimiento.Width = 50
        '
        'cFecPlanilla
        '
        DataGridViewCellStyle2.Format = "d"
        Me.cFecPlanilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.cFecPlanilla.HeaderText = "Fecha"
        Me.cFecPlanilla.Name = "cFecPlanilla"
        Me.cFecPlanilla.ReadOnly = True
        Me.cFecPlanilla.Width = 80
        '
        'cFecBanco
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cFecBanco.DefaultCellStyle = DataGridViewCellStyle3
        Me.cFecBanco.HeaderText = "FecBanco"
        Me.cFecBanco.Name = "cFecBanco"
        Me.cFecBanco.ReadOnly = True
        Me.cFecBanco.Visible = False
        Me.cFecBanco.Width = 80
        '
        'cCheque
        '
        Me.cCheque.HeaderText = "Cheque"
        Me.cCheque.Name = "cCheque"
        Me.cCheque.ReadOnly = True
        Me.cCheque.Width = 80
        '
        'cAbrTipo
        '
        Me.cAbrTipo.HeaderText = "Tipo"
        Me.cAbrTipo.Name = "cAbrTipo"
        Me.cAbrTipo.ReadOnly = True
        Me.cAbrTipo.Width = 50
        '
        'cDescripcion
        '
        Me.cDescripcion.HeaderText = "Descripcion"
        Me.cDescripcion.Name = "cDescripcion"
        Me.cDescripcion.ReadOnly = True
        Me.cDescripcion.Width = 200
        '
        'cTipMov
        '
        Me.cTipMov.HeaderText = "TipMov"
        Me.cTipMov.Name = "cTipMov"
        Me.cTipMov.Visible = False
        '
        'cMonto
        '
        Me.cMonto.HeaderText = "Monto"
        Me.cMonto.Name = "cMonto"
        Me.cMonto.Visible = False
        '
        'cMontoDebe
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cMontoDebe.DefaultCellStyle = DataGridViewCellStyle4
        Me.cMontoDebe.HeaderText = "Debe"
        Me.cMontoDebe.Name = "cMontoDebe"
        Me.cMontoDebe.ReadOnly = True
        Me.cMontoDebe.Width = 95
        '
        'cMontoHaber
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cMontoHaber.DefaultCellStyle = DataGridViewCellStyle5
        Me.cMontoHaber.HeaderText = "Haber"
        Me.cMontoHaber.Name = "cMontoHaber"
        Me.cMontoHaber.ReadOnly = True
        Me.cMontoHaber.Width = 95
        '
        'cbAtender
        '
        Me.cbAtender.FalseValue = ""
        Me.cbAtender.HeaderText = "Imp"
        Me.cbAtender.Name = "cbAtender"
        Me.cbAtender.Width = 40
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodos, Me.ToolStripSeparator5, Me.miNinguno, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(169, 82)
        '
        'miSeleccionarTodos
        '
        Me.miSeleccionarTodos.Image = CType(resources.GetObject("miSeleccionarTodos.Image"), System.Drawing.Image)
        Me.miSeleccionarTodos.Name = "miSeleccionarTodos"
        Me.miSeleccionarTodos.Size = New System.Drawing.Size(168, 22)
        Me.miSeleccionarTodos.Text = "Seleccionar Todos"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(165, 6)
        '
        'miNinguno
        '
        Me.miNinguno.Image = CType(resources.GetObject("miNinguno.Image"), System.Drawing.Image)
        Me.miNinguno.Name = "miNinguno"
        Me.miNinguno.Size = New System.Drawing.Size(168, 22)
        Me.miNinguno.Text = "Ninguno"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(168, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biIngresar, Me.ToolStripSeparator1, Me.biCerrar})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(725, 31)
        Me.ToolStrip.TabIndex = 250
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biIngresar
        '
        Me.biIngresar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biIngresar.Image = CType(resources.GetObject("biIngresar.Image"), System.Drawing.Image)
        Me.biIngresar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biIngresar.Name = "biIngresar"
        Me.biIngresar.Size = New System.Drawing.Size(28, 28)
        Me.biIngresar.Text = "Agregar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
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
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.Label26)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.cmbMes)
        Me.gbDatos.Controls.Add(Me.btnBuscar)
        Me.gbDatos.Controls.Add(Me.txtAnio)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(110, 36)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(501, 54)
        Me.gbDatos.TabIndex = 251
        Me.gbDatos.Text = "Datos de Busqueda"
        Me.gbDatos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(255, 12)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(30, 13)
        Me.Label26.TabIndex = 232
        Me.Label26.Text = "Mes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(147, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 231
        Me.Label4.Text = "Año"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(343, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.datagridview3)
        Me.UiGroupBox2.Controls.Add(Me.txtFecha)
        Me.UiGroupBox2.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Location = New System.Drawing.Point(12, 156)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(703, 99)
        Me.UiGroupBox2.TabIndex = 252
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'datagridview3
        '
        Me.datagridview3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.datagridview3.ContextMenuStrip = Me.cmOpciones
        datagridview3_DesignTimeLayout.LayoutString = resources.GetString("datagridview3_DesignTimeLayout.LayoutString")
        Me.datagridview3.DesignTimeLayout = datagridview3_DesignTimeLayout
        Me.datagridview3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.datagridview3.GroupByBoxVisible = False
        Me.datagridview3.Location = New System.Drawing.Point(638, 9)
        Me.datagridview3.Name = "datagridview3"
        Me.datagridview3.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.datagridview3.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.datagridview3.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.datagridview3.Size = New System.Drawing.Size(43, 39)
        Me.datagridview3.TabIndex = 254
        Me.datagridview3.TabStop = False
        Me.datagridview3.Visible = False
        Me.datagridview3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.Location = New System.Drawing.Point(101, 16)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(102, 20)
        Me.txtFecha.TabIndex = 251
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.Value = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(101, 50)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(582, 36)
        Me.txtObservacion.TabIndex = 250
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 244
        Me.Label3.Text = "Observación"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(53, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 236
        Me.Label9.Text = "Fecha"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.DataGridView2.Location = New System.Drawing.Point(632, 48)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(38, 36)
        Me.DataGridView2.TabIndex = 253
        Me.DataGridView2.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IdMovimientoDet"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IdMovimientoDet"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IdMovimiento"
        Me.DataGridViewTextBoxColumn2.HeaderText = "IdMovimiento"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'frmMovimientoBanco_ConciliarBuscador
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(725, 610)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.txtIdMovimiento)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovimientoBanco_ConciliarBuscador"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conciliar Buscador"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbNumCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.datagridview3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbNumCuenta As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdMovimiento As System.Windows.Forms.TextBox
    Friend WithEvents txtAnio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents biIngresar As System.Windows.Forms.ToolStripButton
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents IdMovimientoDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdMovimiento1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecBanco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AbrTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipMov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miNinguno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datagridview3 As Janus.Windows.GridEX.GridEX
    Friend WithEvents cIdMovimientoDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecPlanilla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecBanco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cAbrTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTipMov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMontoDebe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMontoHaber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbAtender As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
