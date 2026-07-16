<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregar_CentroCosto_SolGastosNew
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
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregar_CentroCosto_SolGastosNew))
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGenerar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.cbProrratear = New System.Windows.Forms.CheckBox()
        Me.txtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMontoSinIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvCentroCosto = New System.Windows.Forms.DataGridView()
        Me.cCodCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cCodCentro1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCentro1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoSinIgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoNoAfecto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotSubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotIgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotNoAfecto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotOtroCargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMontoNoAfecto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMontoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalNoAfecto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtSubTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalOtroCargo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.btnGenerar, Me.ToolStripSeparator2, Me.btnCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(864, 27)
        Me.ToolStrip1.TabIndex = 302
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'btnGenerar
        '
        Me.btnGenerar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(24, 24)
        Me.btnGenerar.Text = "Asignar Centros de Costo Seleccionados"
        Me.btnGenerar.ToolTipText = "Asignar Centros de Costo Seleccionados"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'btnCerrar
        '
        Me.btnCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(24, 24)
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEliminar})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(118, 26)
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(117, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.Label5)
        Me.gbDatosBusqueda.Controls.Add(Me.Label6)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbArea)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbUnidad)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(7, 24)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(846, 56)
        Me.gbDatosBusqueda.TabIndex = 0
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(455, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 263
        Me.Label5.Text = "Area"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(124, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Unidad de Negocio"
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(372, 31)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(193, 20)
        Me.cmbArea.TabIndex = 2
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(113, 31)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(146, 20)
        Me.cmbUnidad.TabIndex = 1
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(674, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 25)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(226, 213)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregarTodos.TabIndex = 309
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'cbProrratear
        '
        Me.cbProrratear.AutoSize = True
        Me.cbProrratear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProrratear.Location = New System.Drawing.Point(558, 88)
        Me.cbProrratear.Name = "cbProrratear"
        Me.cbProrratear.Size = New System.Drawing.Size(82, 17)
        Me.cbProrratear.TabIndex = 310
        Me.cbProrratear.Text = "Prorratear"
        Me.cbProrratear.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.SystemColors.Control
        Me.txtMonto.DisabledForeColor = System.Drawing.SystemColors.MenuText
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.FormatString = "#0.00"
        Me.txtMonto.Location = New System.Drawing.Point(6, 344)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(106, 20)
        Me.txtMonto.TabIndex = 312
        Me.txtMonto.TabStop = False
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMonto.Visible = False
        Me.txtMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(40, 328)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 314
        Me.Label8.Text = "Monto"
        Me.Label8.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(138, 328)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 313
        Me.Label2.Text = "Monto Sin Igv"
        Me.Label2.Visible = False
        '
        'txtMontoSinIgv
        '
        Me.txtMontoSinIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoSinIgv.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtMontoSinIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSinIgv.FormatString = "#0.00"
        Me.txtMontoSinIgv.Location = New System.Drawing.Point(122, 344)
        Me.txtMontoSinIgv.Name = "txtMontoSinIgv"
        Me.txtMontoSinIgv.ReadOnly = True
        Me.txtMontoSinIgv.Size = New System.Drawing.Size(106, 20)
        Me.txtMontoSinIgv.TabIndex = 311
        Me.txtMontoSinIgv.TabStop = False
        Me.txtMontoSinIgv.Text = "0.00"
        Me.txtMontoSinIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoSinIgv.Visible = False
        Me.txtMontoSinIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(271, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 307
        Me.Label1.Text = "Seleccionados"
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(4, 87)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(116, 15)
        Me.lblPersonal.TabIndex = 305
        Me.lblPersonal.Text = "Centros de Costo"
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(226, 169)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregar.TabIndex = 308
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvCentroCosto
        '
        Me.dgvCentroCosto.AllowUserToAddRows = False
        Me.dgvCentroCosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCentroCosto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodCentro, Me.cDesCentro})
        Me.dgvCentroCosto.Location = New System.Drawing.Point(7, 108)
        Me.dgvCentroCosto.Name = "dgvCentroCosto"
        Me.dgvCentroCosto.RowHeadersVisible = False
        Me.dgvCentroCosto.Size = New System.Drawing.Size(213, 177)
        Me.dgvCentroCosto.TabIndex = 304
        '
        'cCodCentro
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodCentro.DefaultCellStyle = DataGridViewCellStyle1
        Me.cCodCentro.HeaderText = "Cod."
        Me.cCodCentro.Name = "cCodCentro"
        Me.cCodCentro.ReadOnly = True
        Me.cCodCentro.Width = 35
        '
        'cDesCentro
        '
        Me.cDesCentro.HeaderText = "Centro Costo"
        Me.cDesCentro.Name = "cDesCentro"
        Me.cDesCentro.ReadOnly = True
        Me.cDesCentro.Width = 175
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodCentro1, Me.cDesCentro1, Me.cMonto, Me.cMontoSinIgv, Me.cMontoNoAfecto, Me.cObservacion, Me.cTotSubTotal, Me.cTotIgv, Me.cTotNoAfecto, Me.cTotOtroCargo})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmbOpciones
        Me.dgvSeleccionados.Location = New System.Drawing.Point(274, 108)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(579, 177)
        Me.dgvSeleccionados.TabIndex = 306
        '
        'cCodCentro1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodCentro1.DefaultCellStyle = DataGridViewCellStyle2
        Me.cCodCentro1.HeaderText = "Cod."
        Me.cCodCentro1.Name = "cCodCentro1"
        Me.cCodCentro1.ReadOnly = True
        Me.cCodCentro1.Width = 35
        '
        'cDesCentro1
        '
        Me.cDesCentro1.HeaderText = "Centro Costo"
        Me.cDesCentro1.Name = "cDesCentro1"
        Me.cDesCentro1.ReadOnly = True
        Me.cDesCentro1.Width = 160
        '
        'cMonto
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N5"
        DataGridViewCellStyle3.NullValue = "0.00000"
        Me.cMonto.DefaultCellStyle = DataGridViewCellStyle3
        Me.cMonto.HeaderText = "Monto"
        Me.cMonto.Name = "cMonto"
        Me.cMonto.Visible = False
        Me.cMonto.Width = 90
        '
        'cMontoSinIgv
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N5"
        DataGridViewCellStyle4.NullValue = "0.00000"
        Me.cMontoSinIgv.DefaultCellStyle = DataGridViewCellStyle4
        Me.cMontoSinIgv.HeaderText = "MontoSinIgv"
        Me.cMontoSinIgv.Name = "cMontoSinIgv"
        Me.cMontoSinIgv.ReadOnly = True
        Me.cMontoSinIgv.Visible = False
        Me.cMontoSinIgv.Width = 90
        '
        'cMontoNoAfecto
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N5"
        DataGridViewCellStyle5.NullValue = "0.00000"
        Me.cMontoNoAfecto.DefaultCellStyle = DataGridViewCellStyle5
        Me.cMontoNoAfecto.HeaderText = "MontoNoAfecto"
        Me.cMontoNoAfecto.Name = "cMontoNoAfecto"
        Me.cMontoNoAfecto.Visible = False
        Me.cMontoNoAfecto.Width = 85
        '
        'cObservacion
        '
        Me.cObservacion.HeaderText = "Observación"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.Visible = False
        Me.cObservacion.Width = 115
        '
        'cTotSubTotal
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N4"
        DataGridViewCellStyle6.NullValue = "00.0000"
        Me.cTotSubTotal.DefaultCellStyle = DataGridViewCellStyle6
        Me.cTotSubTotal.HeaderText = "TotSubTotal"
        Me.cTotSubTotal.Name = "cTotSubTotal"
        '
        'cTotIgv
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.Format = "N4"
        DataGridViewCellStyle7.NullValue = "00.0000"
        Me.cTotIgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.cTotIgv.HeaderText = "TotIgv"
        Me.cTotIgv.Name = "cTotIgv"
        '
        'cTotNoAfecto
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle8.Format = "N4"
        DataGridViewCellStyle8.NullValue = "00.0000"
        Me.cTotNoAfecto.DefaultCellStyle = DataGridViewCellStyle8
        Me.cTotNoAfecto.HeaderText = "TotNoAfecto"
        Me.cTotNoAfecto.Name = "cTotNoAfecto"
        '
        'cTotOtroCargo
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle9.Format = "N4"
        DataGridViewCellStyle9.NullValue = "00.0000"
        Me.cTotOtroCargo.DefaultCellStyle = DataGridViewCellStyle9
        Me.cTotOtroCargo.HeaderText = "TotOtroCargo"
        Me.cTotOtroCargo.Name = "cTotOtroCargo"
        Me.cTotOtroCargo.Width = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(247, 328)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 316
        Me.Label3.Text = "Monto No Afecto"
        Me.Label3.Visible = False
        '
        'txtMontoNoAfecto
        '
        Me.txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoNoAfecto.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtMontoNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNoAfecto.FormatString = "#0.00"
        Me.txtMontoNoAfecto.Location = New System.Drawing.Point(238, 344)
        Me.txtMontoNoAfecto.Name = "txtMontoNoAfecto"
        Me.txtMontoNoAfecto.ReadOnly = True
        Me.txtMontoNoAfecto.Size = New System.Drawing.Size(106, 20)
        Me.txtMontoNoAfecto.TabIndex = 315
        Me.txtMontoNoAfecto.TabStop = False
        Me.txtMontoNoAfecto.Text = "0.00"
        Me.txtMontoNoAfecto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNoAfecto.Visible = False
        Me.txtMontoNoAfecto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(371, 328)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 318
        Me.Label4.Text = "Monto Total"
        Me.Label4.Visible = False
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoTotal.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotal.FormatString = "#0.00"
        Me.txtMontoTotal.Location = New System.Drawing.Point(354, 344)
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(110, 20)
        Me.txtMontoTotal.TabIndex = 317
        Me.txtMontoTotal.TabStop = False
        Me.txtMontoTotal.Text = "0.00"
        Me.txtMontoTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotal.Visible = False
        Me.txtMontoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(768, 289)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 326
        Me.Label7.Text = "Total Neto"
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalNeto.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.FormatString = "#0.00"
        Me.txtTotalNeto.Location = New System.Drawing.Point(744, 305)
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(110, 20)
        Me.txtTotalNeto.TabIndex = 325
        Me.txtTotalNeto.TabStop = False
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(525, 289)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 324
        Me.Label9.Text = "Total No Afecto"
        '
        'txtTotalNoAfecto
        '
        Me.txtTotalNoAfecto.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalNoAfecto.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotalNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNoAfecto.FormatString = "#0.00"
        Me.txtTotalNoAfecto.Location = New System.Drawing.Point(510, 305)
        Me.txtTotalNoAfecto.Name = "txtTotalNoAfecto"
        Me.txtTotalNoAfecto.ReadOnly = True
        Me.txtTotalNoAfecto.Size = New System.Drawing.Size(106, 20)
        Me.txtTotalNoAfecto.TabIndex = 323
        Me.txtTotalNoAfecto.TabStop = False
        Me.txtTotalNoAfecto.Text = "0.00"
        Me.txtTotalNoAfecto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNoAfecto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtSubTotal.DisabledForeColor = System.Drawing.SystemColors.MenuText
        Me.txtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.FormatString = "#0.00"
        Me.txtSubTotal.Location = New System.Drawing.Point(311, 305)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(106, 20)
        Me.txtSubTotal.TabIndex = 320
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSubTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(324, 289)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 322
        Me.Label10.Text = "Total Sub Total"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(443, 289)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 321
        Me.Label11.Text = "Total Igv"
        '
        'txtTotalIgv
        '
        Me.txtTotalIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalIgv.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotalIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIgv.FormatString = "#0.00"
        Me.txtTotalIgv.Location = New System.Drawing.Point(427, 305)
        Me.txtTotalIgv.Name = "txtTotalIgv"
        Me.txtTotalIgv.ReadOnly = True
        Me.txtTotalIgv.Size = New System.Drawing.Size(72, 20)
        Me.txtTotalIgv.TabIndex = 319
        Me.txtTotalIgv.TabStop = False
        Me.txtTotalIgv.Text = "0.00"
        Me.txtTotalIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(632, 289)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 13)
        Me.Label12.TabIndex = 328
        Me.Label12.Text = "Total Otros Cargos"
        '
        'txtTotalOtroCargo
        '
        Me.txtTotalOtroCargo.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalOtroCargo.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotalOtroCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalOtroCargo.FormatString = "#0.00"
        Me.txtTotalOtroCargo.Location = New System.Drawing.Point(627, 305)
        Me.txtTotalOtroCargo.Name = "txtTotalOtroCargo"
        Me.txtTotalOtroCargo.ReadOnly = True
        Me.txtTotalOtroCargo.Size = New System.Drawing.Size(106, 20)
        Me.txtTotalOtroCargo.TabIndex = 327
        Me.txtTotalOtroCargo.TabStop = False
        Me.txtTotalOtroCargo.Text = "0.00"
        Me.txtTotalOtroCargo.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalOtroCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmAgregar_CentroCosto_SolGastosNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 381)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTotalOtroCargo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTotalNeto)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTotalNoAfecto)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTotalIgv)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMontoTotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMontoNoAfecto)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.cbProrratear)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMontoSinIgv)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvCentroCosto)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregar_CentroCosto_SolGastosNew"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Centro de Costo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGenerar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents cbProrratear As System.Windows.Forms.CheckBox
    Friend WithEvents txtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMontoSinIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvCentroCosto As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents cCodCentro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMontoNoAfecto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTotalOtroCargo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTotalNoAfecto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtSubTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTotalIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cCodCentro1 As DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro1 As DataGridViewTextBoxColumn
    Friend WithEvents cMonto As DataGridViewTextBoxColumn
    Friend WithEvents cMontoSinIgv As DataGridViewTextBoxColumn
    Friend WithEvents cMontoNoAfecto As DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As DataGridViewTextBoxColumn
    Friend WithEvents cTotSubTotal As DataGridViewTextBoxColumn
    Friend WithEvents cTotIgv As DataGridViewTextBoxColumn
    Friend WithEvents cTotNoAfecto As DataGridViewTextBoxColumn
    Friend WithEvents cTotOtroCargo As DataGridViewTextBoxColumn
End Class
