<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregar_CentroCosto_RegCom
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregar_CentroCosto_RegCom))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGenerar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.cbProrratear = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMontoSoles = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoDolares = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvCentroCosto = New System.Windows.Forms.DataGridView()
        Me.cCodCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cCodCentro1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCentro1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoIgvSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoNoAfectoSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoDol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoIgvDol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoNoAfectoDol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMontoNoAfectoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoIgvDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMontoNoAfectoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoIgvSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMontoTotalDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMontoTotalSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.btnGenerar, Me.ToolStripSeparator2, Me.btnCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(774, 27)
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
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.cmbArea)
        Me.gbDatosBusqueda.Controls.Add(Me.Label7)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(8, 24)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(758, 56)
        Me.gbDatosBusqueda.TabIndex = 303
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
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(241, 216)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregarTodos.TabIndex = 309
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'cbProrratear
        '
        Me.cbProrratear.AutoSize = True
        Me.cbProrratear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProrratear.Location = New System.Drawing.Point(586, 90)
        Me.cbProrratear.Name = "cbProrratear"
        Me.cbProrratear.Size = New System.Drawing.Size(82, 17)
        Me.cbProrratear.TabIndex = 310
        Me.cbProrratear.Text = "Prorratear"
        Me.cbProrratear.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(311, 297)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 314
        Me.Label8.Text = "Monto Soles"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(307, 348)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 313
        Me.Label2.Text = "Monto Dolares"
        '
        'txtMontoSoles
        '
        Me.txtMontoSoles.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoSoles.DisabledForeColor = System.Drawing.SystemColors.MenuText
        Me.txtMontoSoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSoles.FormatString = "#0.00"
        Me.txtMontoSoles.Location = New System.Drawing.Point(297, 312)
        Me.txtMontoSoles.Name = "txtMontoSoles"
        Me.txtMontoSoles.ReadOnly = True
        Me.txtMontoSoles.Size = New System.Drawing.Size(95, 20)
        Me.txtMontoSoles.TabIndex = 312
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
        Me.txtMontoDolares.Location = New System.Drawing.Point(297, 363)
        Me.txtMontoDolares.Name = "txtMontoDolares"
        Me.txtMontoDolares.ReadOnly = True
        Me.txtMontoDolares.Size = New System.Drawing.Size(95, 20)
        Me.txtMontoDolares.TabIndex = 311
        Me.txtMontoDolares.TabStop = False
        Me.txtMontoDolares.Text = "0.00"
        Me.txtMontoDolares.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoDolares.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(291, 90)
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
        Me.lblPersonal.Location = New System.Drawing.Point(5, 90)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(116, 15)
        Me.lblPersonal.TabIndex = 305
        Me.lblPersonal.Text = "Centros de Costo"
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(241, 172)
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
        Me.dgvCentroCosto.Location = New System.Drawing.Point(8, 111)
        Me.dgvCentroCosto.Name = "dgvCentroCosto"
        Me.dgvCentroCosto.RowHeadersVisible = False
        Me.dgvCentroCosto.Size = New System.Drawing.Size(221, 177)
        Me.dgvCentroCosto.TabIndex = 304
        '
        'cCodCentro
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodCentro.DefaultCellStyle = DataGridViewCellStyle16
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
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodCentro1, Me.cDesCentro1, Me.cMontoSol, Me.cMontoIgvSol, Me.cMontoNoAfectoSol, Me.cMontoDol, Me.cMontoIgvDol, Me.cMontoNoAfectoDol, Me.cObservacion})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmbOpciones
        Me.dgvSeleccionados.Location = New System.Drawing.Point(294, 111)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(472, 177)
        Me.dgvSeleccionados.TabIndex = 306
        '
        'cCodCentro1
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodCentro1.DefaultCellStyle = DataGridViewCellStyle9
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
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle10.Format = "N5"
        DataGridViewCellStyle10.NullValue = "0.00000"
        Me.cMontoSol.DefaultCellStyle = DataGridViewCellStyle10
        Me.cMontoSol.HeaderText = "MontoSol"
        Me.cMontoSol.Name = "cMontoSol"
        Me.cMontoSol.Width = 90
        '
        'cMontoIgvSol
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N5"
        DataGridViewCellStyle11.NullValue = "0.00000"
        Me.cMontoIgvSol.DefaultCellStyle = DataGridViewCellStyle11
        Me.cMontoIgvSol.HeaderText = "IgvSol"
        Me.cMontoIgvSol.Name = "cMontoIgvSol"
        Me.cMontoIgvSol.Width = 90
        '
        'cMontoNoAfectoSol
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N5"
        DataGridViewCellStyle12.NullValue = "0.0000"
        Me.cMontoNoAfectoSol.DefaultCellStyle = DataGridViewCellStyle12
        Me.cMontoNoAfectoSol.HeaderText = "NoAfectoSol"
        Me.cMontoNoAfectoSol.Name = "cMontoNoAfectoSol"
        Me.cMontoNoAfectoSol.Width = 90
        '
        'cMontoDol
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle13.Format = "N5"
        DataGridViewCellStyle13.NullValue = "0.00000"
        Me.cMontoDol.DefaultCellStyle = DataGridViewCellStyle13
        Me.cMontoDol.HeaderText = "MontoDol"
        Me.cMontoDol.Name = "cMontoDol"
        Me.cMontoDol.Width = 90
        '
        'cMontoIgvDol
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N5"
        DataGridViewCellStyle14.NullValue = "0.00000"
        Me.cMontoIgvDol.DefaultCellStyle = DataGridViewCellStyle14
        Me.cMontoIgvDol.HeaderText = "IgvDol"
        Me.cMontoIgvDol.Name = "cMontoIgvDol"
        Me.cMontoIgvDol.Width = 90
        '
        'cMontoNoAfectoDol
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N5"
        DataGridViewCellStyle15.NullValue = "0.00000"
        Me.cMontoNoAfectoDol.DefaultCellStyle = DataGridViewCellStyle15
        Me.cMontoNoAfectoDol.HeaderText = "NoAfectoDol"
        Me.cMontoNoAfectoDol.Name = "cMontoNoAfectoDol"
        Me.cMontoNoAfectoDol.Width = 90
        '
        'cObservacion
        '
        Me.cObservacion.HeaderText = "Observación"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.Width = 90
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(524, 297)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 318
        Me.Label5.Text = "Monto No Afecto Sol"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(420, 297)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 317
        Me.Label6.Text = "Monto Igv Sol"
        '
        'txtMontoNoAfectoDol
        '
        Me.txtMontoNoAfectoDol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoNoAfectoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNoAfectoDol.Location = New System.Drawing.Point(524, 363)
        Me.txtMontoNoAfectoDol.MaxLength = 30
        Me.txtMontoNoAfectoDol.Name = "txtMontoNoAfectoDol"
        Me.txtMontoNoAfectoDol.ReadOnly = True
        Me.txtMontoNoAfectoDol.Size = New System.Drawing.Size(108, 20)
        Me.txtMontoNoAfectoDol.TabIndex = 316
        Me.txtMontoNoAfectoDol.TabStop = False
        Me.txtMontoNoAfectoDol.Text = "0.00"
        Me.txtMontoNoAfectoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNoAfectoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoIgvDol
        '
        Me.txtMontoIgvDol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoIgvDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIgvDol.Location = New System.Drawing.Point(413, 363)
        Me.txtMontoIgvDol.MaxLength = 30
        Me.txtMontoIgvDol.Name = "txtMontoIgvDol"
        Me.txtMontoIgvDol.ReadOnly = True
        Me.txtMontoIgvDol.Size = New System.Drawing.Size(90, 20)
        Me.txtMontoIgvDol.TabIndex = 315
        Me.txtMontoIgvDol.TabStop = False
        Me.txtMontoIgvDol.Text = "0.00"
        Me.txtMontoIgvDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIgvDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(524, 348)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 322
        Me.Label3.Text = "Monto No Afecto Dol"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(420, 348)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 321
        Me.Label4.Text = "Monto Igv Dol"
        '
        'txtMontoNoAfectoSol
        '
        Me.txtMontoNoAfectoSol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoNoAfectoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNoAfectoSol.Location = New System.Drawing.Point(524, 312)
        Me.txtMontoNoAfectoSol.MaxLength = 30
        Me.txtMontoNoAfectoSol.Name = "txtMontoNoAfectoSol"
        Me.txtMontoNoAfectoSol.ReadOnly = True
        Me.txtMontoNoAfectoSol.Size = New System.Drawing.Size(108, 20)
        Me.txtMontoNoAfectoSol.TabIndex = 320
        Me.txtMontoNoAfectoSol.TabStop = False
        Me.txtMontoNoAfectoSol.Text = "0.00"
        Me.txtMontoNoAfectoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNoAfectoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoIgvSol
        '
        Me.txtMontoIgvSol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoIgvSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIgvSol.Location = New System.Drawing.Point(413, 312)
        Me.txtMontoIgvSol.MaxLength = 30
        Me.txtMontoIgvSol.Name = "txtMontoIgvSol"
        Me.txtMontoIgvSol.ReadOnly = True
        Me.txtMontoIgvSol.Size = New System.Drawing.Size(90, 20)
        Me.txtMontoIgvSol.TabIndex = 319
        Me.txtMontoIgvSol.TabStop = False
        Me.txtMontoIgvSol.Text = "0.00"
        Me.txtMontoIgvSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIgvSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(658, 348)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 326
        Me.Label9.Text = "Monto Total Dol"
        '
        'txtMontoTotalDol
        '
        Me.txtMontoTotalDol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoTotalDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotalDol.Location = New System.Drawing.Point(653, 363)
        Me.txtMontoTotalDol.MaxLength = 30
        Me.txtMontoTotalDol.Name = "txtMontoTotalDol"
        Me.txtMontoTotalDol.ReadOnly = True
        Me.txtMontoTotalDol.Size = New System.Drawing.Size(108, 20)
        Me.txtMontoTotalDol.TabIndex = 325
        Me.txtMontoTotalDol.TabStop = False
        Me.txtMontoTotalDol.Text = "0.00"
        Me.txtMontoTotalDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotalDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(659, 297)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 324
        Me.Label10.Text = "Monto Total Sol"
        '
        'txtMontoTotalSol
        '
        Me.txtMontoTotalSol.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoTotalSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotalSol.Location = New System.Drawing.Point(653, 312)
        Me.txtMontoTotalSol.MaxLength = 30
        Me.txtMontoTotalSol.Name = "txtMontoTotalSol"
        Me.txtMontoTotalSol.ReadOnly = True
        Me.txtMontoTotalSol.Size = New System.Drawing.Size(108, 20)
        Me.txtMontoTotalSol.TabIndex = 323
        Me.txtMontoTotalSol.TabStop = False
        Me.txtMontoTotalSol.Text = "0.00"
        Me.txtMontoTotalSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotalSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmAgregar_CentroCosto_RegCom
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(774, 397)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtMontoTotalDol)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMontoTotalSol)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtMontoNoAfectoSol)
        Me.Controls.Add(Me.txtMontoIgvSol)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.cbProrratear)
        Me.Controls.Add(Me.txtMontoNoAfectoDol)
        Me.Controls.Add(Me.txtMontoIgvDol)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregar_CentroCosto_RegCom"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Centros de Costo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents cbProrratear As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMontoSoles As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoDolares As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvCentroCosto As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents cCodCentro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMontoNoAfectoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoIgvDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMontoNoAfectoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoIgvSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotalDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotalSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cCodCentro1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMontoSol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMontoIgvSol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMontoNoAfectoSol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMontoDol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMontoIgvDol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMontoNoAfectoDol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
