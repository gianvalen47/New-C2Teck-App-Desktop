<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReciboHonorario_AgregarCC
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReciboHonorario_AgregarCC))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGenerar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMontoTotalDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoTotalSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMontoIRSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.cbProrratear = New System.Windows.Forms.CheckBox()
        Me.txtMontoIRDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMontoSoles = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoDolares = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvCentroCosto = New System.Windows.Forms.DataGridView()
        Me.cCodCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cCodCentro1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCentro1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoIRSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoDol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoIRDol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
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
        Me.ToolStrip1.Size = New System.Drawing.Size(793, 27)
        Me.ToolStrip1.TabIndex = 303
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(665, 354)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 350
        Me.Label9.Text = "Monto Total Dol"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(666, 303)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 348
        Me.Label10.Text = "Monto Total Sol"
        '
        'txtMontoTotalDol
        '
        Me.txtMontoTotalDol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoTotalDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotalDol.Location = New System.Drawing.Point(660, 369)
        Me.txtMontoTotalDol.MaxLength = 30
        Me.txtMontoTotalDol.Name = "txtMontoTotalDol"
        Me.txtMontoTotalDol.ReadOnly = True
        Me.txtMontoTotalDol.Size = New System.Drawing.Size(108, 20)
        Me.txtMontoTotalDol.TabIndex = 349
        Me.txtMontoTotalDol.TabStop = False
        Me.txtMontoTotalDol.Text = "0.00"
        Me.txtMontoTotalDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotalDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoTotalSol
        '
        Me.txtMontoTotalSol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoTotalSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotalSol.Location = New System.Drawing.Point(660, 318)
        Me.txtMontoTotalSol.MaxLength = 30
        Me.txtMontoTotalSol.Name = "txtMontoTotalSol"
        Me.txtMontoTotalSol.ReadOnly = True
        Me.txtMontoTotalSol.Size = New System.Drawing.Size(108, 20)
        Me.txtMontoTotalSol.TabIndex = 347
        Me.txtMontoTotalSol.TabStop = False
        Me.txtMontoTotalSol.Text = "0.00"
        Me.txtMontoTotalSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotalSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(557, 354)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 345
        Me.Label4.Text = "Monto IR Dol"
        '
        'txtMontoIRSol
        '
        Me.txtMontoIRSol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoIRSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIRSol.Location = New System.Drawing.Point(550, 318)
        Me.txtMontoIRSol.MaxLength = 30
        Me.txtMontoIRSol.Name = "txtMontoIRSol"
        Me.txtMontoIRSol.ReadOnly = True
        Me.txtMontoIRSol.Size = New System.Drawing.Size(90, 20)
        Me.txtMontoIRSol.TabIndex = 343
        Me.txtMontoIRSol.TabStop = False
        Me.txtMontoIRSol.Text = "0.00"
        Me.txtMontoIRSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIRSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(557, 303)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 341
        Me.Label6.Text = "Monto IR Sol"
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(248, 222)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregarTodos.TabIndex = 333
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'cbProrratear
        '
        Me.cbProrratear.AutoSize = True
        Me.cbProrratear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProrratear.Location = New System.Drawing.Point(593, 96)
        Me.cbProrratear.Name = "cbProrratear"
        Me.cbProrratear.Size = New System.Drawing.Size(82, 17)
        Me.cbProrratear.TabIndex = 334
        Me.cbProrratear.Text = "Prorratear"
        Me.cbProrratear.UseVisualStyleBackColor = True
        '
        'txtMontoIRDol
        '
        Me.txtMontoIRDol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoIRDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIRDol.Location = New System.Drawing.Point(550, 369)
        Me.txtMontoIRDol.MaxLength = 30
        Me.txtMontoIRDol.Name = "txtMontoIRDol"
        Me.txtMontoIRDol.ReadOnly = True
        Me.txtMontoIRDol.Size = New System.Drawing.Size(90, 20)
        Me.txtMontoIRDol.TabIndex = 339
        Me.txtMontoIRDol.TabStop = False
        Me.txtMontoIRDol.Text = "0.00"
        Me.txtMontoIRDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIRDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(448, 303)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 338
        Me.Label8.Text = "Monto Soles"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(444, 354)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 337
        Me.Label2.Text = "Monto Dolares"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(298, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 331
        Me.Label1.Text = "Seleccionados"
        '
        'txtMontoSoles
        '
        Me.txtMontoSoles.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoSoles.DisabledForeColor = System.Drawing.SystemColors.MenuText
        Me.txtMontoSoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSoles.FormatString = "#0.00"
        Me.txtMontoSoles.Location = New System.Drawing.Point(434, 318)
        Me.txtMontoSoles.Name = "txtMontoSoles"
        Me.txtMontoSoles.ReadOnly = True
        Me.txtMontoSoles.Size = New System.Drawing.Size(95, 20)
        Me.txtMontoSoles.TabIndex = 336
        Me.txtMontoSoles.TabStop = False
        Me.txtMontoSoles.Text = "0.00"
        Me.txtMontoSoles.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoSoles.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoDolares
        '
        Me.txtMontoDolares.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoDolares.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtMontoDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoDolares.FormatString = "#0.00"
        Me.txtMontoDolares.Location = New System.Drawing.Point(434, 369)
        Me.txtMontoDolares.Name = "txtMontoDolares"
        Me.txtMontoDolares.ReadOnly = True
        Me.txtMontoDolares.Size = New System.Drawing.Size(95, 20)
        Me.txtMontoDolares.TabIndex = 335
        Me.txtMontoDolares.TabStop = False
        Me.txtMontoDolares.Text = "0.00"
        Me.txtMontoDolares.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoDolares.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(12, 96)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(116, 15)
        Me.lblPersonal.TabIndex = 329
        Me.lblPersonal.Text = "Centros de Costo"
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(248, 178)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregar.TabIndex = 332
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvCentroCosto
        '
        Me.dgvCentroCosto.AllowUserToAddRows = False
        Me.dgvCentroCosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCentroCosto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodCentro, Me.cDesCentro})
        Me.dgvCentroCosto.Location = New System.Drawing.Point(15, 117)
        Me.dgvCentroCosto.Name = "dgvCentroCosto"
        Me.dgvCentroCosto.RowHeadersVisible = False
        Me.dgvCentroCosto.Size = New System.Drawing.Size(221, 177)
        Me.dgvCentroCosto.TabIndex = 328
        '
        'cCodCentro
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodCentro.DefaultCellStyle = DataGridViewCellStyle1
        Me.cCodCentro.HeaderText = "Cod."
        Me.cCodCentro.Name = "cCodCentro"
        Me.cCodCentro.ReadOnly = True
        Me.cCodCentro.Width = 43
        '
        'cDesCentro
        '
        Me.cDesCentro.HeaderText = "Centro Costo"
        Me.cDesCentro.Name = "cDesCentro"
        Me.cDesCentro.ReadOnly = True
        Me.cDesCentro.Width = 175
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.cmbArea)
        Me.gbDatosBusqueda.Controls.Add(Me.Label7)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(15, 30)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(758, 56)
        Me.gbDatosBusqueda.TabIndex = 327
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(177, 30)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(166, 20)
        Me.cmbArea.TabIndex = 192
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(240, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 193
        Me.Label7.Text = "Area"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(496, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 25)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodCentro1, Me.cDesCentro1, Me.cMontoSol, Me.cMontoIRSol, Me.cMontoDol, Me.cMontoIRDol, Me.cObservacion})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmbOpciones
        Me.dgvSeleccionados.Location = New System.Drawing.Point(301, 117)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(472, 177)
        Me.dgvSeleccionados.TabIndex = 330
        '
        'cCodCentro1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodCentro1.DefaultCellStyle = DataGridViewCellStyle2
        Me.cCodCentro1.HeaderText = "Cod."
        Me.cCodCentro1.Name = "cCodCentro1"
        Me.cCodCentro1.ReadOnly = True
        Me.cCodCentro1.Width = 43
        '
        'cDesCentro1
        '
        Me.cDesCentro1.HeaderText = "Centro Costo"
        Me.cDesCentro1.Name = "cDesCentro1"
        Me.cDesCentro1.ReadOnly = True
        Me.cDesCentro1.Width = 155
        '
        'cMontoSol
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N5"
        DataGridViewCellStyle3.NullValue = "0.00000"
        Me.cMontoSol.DefaultCellStyle = DataGridViewCellStyle3
        Me.cMontoSol.HeaderText = "MontoSol"
        Me.cMontoSol.Name = "cMontoSol"
        Me.cMontoSol.Width = 90
        '
        'cMontoIRSol
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N5"
        DataGridViewCellStyle4.NullValue = "0.00000"
        Me.cMontoIRSol.DefaultCellStyle = DataGridViewCellStyle4
        Me.cMontoIRSol.HeaderText = "IRSol"
        Me.cMontoIRSol.Name = "cMontoIRSol"
        Me.cMontoIRSol.Width = 90
        '
        'cMontoDol
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N5"
        DataGridViewCellStyle5.NullValue = "0.00000"
        Me.cMontoDol.DefaultCellStyle = DataGridViewCellStyle5
        Me.cMontoDol.HeaderText = "MontoDol"
        Me.cMontoDol.Name = "cMontoDol"
        Me.cMontoDol.Width = 90
        '
        'cMontoIRDol
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N5"
        DataGridViewCellStyle6.NullValue = "0.00000"
        Me.cMontoIRDol.DefaultCellStyle = DataGridViewCellStyle6
        Me.cMontoIRDol.HeaderText = "IRDol"
        Me.cMontoIRDol.Name = "cMontoIRDol"
        Me.cMontoIRDol.Width = 90
        '
        'cObservacion
        '
        Me.cObservacion.HeaderText = "Observación"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.Width = 90
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
        'frmReciboHonorario_AgregarCC
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(793, 413)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtMontoTotalDol)
        Me.Controls.Add(Me.txtMontoTotalSol)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMontoIRSol)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.cbProrratear)
        Me.Controls.Add(Me.txtMontoIRDol)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMontoSoles)
        Me.Controls.Add(Me.txtMontoDolares)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvCentroCosto)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReciboHonorario_AgregarCC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Centro Costo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnGenerar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtMontoTotalDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoTotalSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMontoIRSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAgregarTodos As Button
    Friend WithEvents cbProrratear As CheckBox
    Friend WithEvents txtMontoIRDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMontoSoles As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoDolares As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblPersonal As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents dgvCentroCosto As DataGridView
    Friend WithEvents cCodCentro As DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro As DataGridViewTextBoxColumn
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents dgvSeleccionados As DataGridView
    Friend WithEvents cCodCentro1 As DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro1 As DataGridViewTextBoxColumn
    Friend WithEvents cMontoSol As DataGridViewTextBoxColumn
    Friend WithEvents cMontoIRSol As DataGridViewTextBoxColumn
    Friend WithEvents cMontoDol As DataGridViewTextBoxColumn
    Friend WithEvents cMontoIRDol As DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As DataGridViewTextBoxColumn
    Friend WithEvents cmbOpciones As ContextMenuStrip
    Friend WithEvents miEliminar As ToolStripMenuItem
End Class
