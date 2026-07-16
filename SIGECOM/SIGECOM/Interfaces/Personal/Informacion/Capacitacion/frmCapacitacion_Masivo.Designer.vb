<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapacitacion_Masivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapacitacion_Masivo))
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbClase_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoCapac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGenerar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbClase = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cIdPer1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApeNom1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.dgvPersonal = New System.Windows.Forms.DataGridView()
        Me.cIdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbDatosCapacitacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtInstructor = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDuracionCapac = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMesesEvaluarCapac = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCostoCapac = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblCostoCapac = New System.Windows.Forms.Label()
        Me.lblDuracionCapac = New System.Windows.Forms.Label()
        Me.btnAgregarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.lblProveedorCapac = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.cbProgramadoCapac = New System.Windows.Forms.CheckBox()
        Me.lblCursoCapac = New System.Windows.Forms.Label()
        Me.txtCursoCapac = New System.Windows.Forms.TextBox()
        Me.cmbTipoCapac = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblTipoCapac = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFechaFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosCapacitacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosCapacitacion.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoCapac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.btnGenerar, Me.ToolStripSeparator2, Me.btnCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(719, 27)
        Me.ToolStrip1.TabIndex = 9
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
        Me.btnGenerar.Text = "Insertar Capacitaciones Masivo"
        Me.btnGenerar.ToolTipText = "Insertar Capacitaciones Masivo"
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
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Controls.Add(Me.Label4)
        Me.gbDatosBusqueda.Controls.Add(Me.Label3)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbArea)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbCentroCosto)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbClase)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(10, 30)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(700, 59)
        Me.gbDatosBusqueda.TabIndex = 0
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(608, 30)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(497, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Clase"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(260, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Centro de Costo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Área"
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Location = New System.Drawing.Point(27, 33)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(140, 20)
        Me.cmbArea.TabIndex = 1
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Location = New System.Drawing.Point(212, 33)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(200, 20)
        Me.cmbCentroCosto.TabIndex = 2
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbClase
        '
        Me.cmbClase.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbClase_DesignTimeLayout.LayoutString = resources.GetString("cmbClase_DesignTimeLayout.LayoutString")
        Me.cmbClase.DesignTimeLayout = cmbClase_DesignTimeLayout
        Me.cmbClase.Location = New System.Drawing.Point(458, 33)
        Me.cmbClase.Name = "cmbClase"
        Me.cmbClase.SelectedIndex = -1
        Me.cmbClase.SelectedItem = Nothing
        Me.cmbClase.Size = New System.Drawing.Size(113, 20)
        Me.cmbClase.TabIndex = 3
        Me.cmbClase.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(339, 215)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregarTodos.TabIndex = 24
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(339, 174)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregar.TabIndex = 22
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(387, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Seleccionados"
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdPer1, Me.cApeNom1})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmbOpciones
        Me.dgvSeleccionados.Location = New System.Drawing.Point(390, 116)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(320, 178)
        Me.dgvSeleccionados.TabIndex = 20
        '
        'cIdPer1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdPer1.DefaultCellStyle = DataGridViewCellStyle1
        Me.cIdPer1.HeaderText = "Codigo"
        Me.cIdPer1.Name = "cIdPer1"
        Me.cIdPer1.ReadOnly = True
        Me.cIdPer1.Width = 55
        '
        'cApeNom1
        '
        Me.cApeNom1.HeaderText = "Nombre"
        Me.cApeNom1.Name = "cApeNom1"
        Me.cApeNom1.ReadOnly = True
        Me.cApeNom1.Width = 262
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
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(7, 95)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(64, 15)
        Me.lblPersonal.TabIndex = 19
        Me.lblPersonal.Text = "Personal"
        '
        'dgvPersonal
        '
        Me.dgvPersonal.AllowUserToAddRows = False
        Me.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPersonal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdPer, Me.cApeNom})
        Me.dgvPersonal.Location = New System.Drawing.Point(10, 116)
        Me.dgvPersonal.Name = "dgvPersonal"
        Me.dgvPersonal.RowHeadersVisible = False
        Me.dgvPersonal.Size = New System.Drawing.Size(320, 178)
        Me.dgvPersonal.TabIndex = 18
        '
        'cIdPer
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdPer.DefaultCellStyle = DataGridViewCellStyle2
        Me.cIdPer.HeaderText = "Codigo"
        Me.cIdPer.Name = "cIdPer"
        Me.cIdPer.ReadOnly = True
        Me.cIdPer.Width = 55
        '
        'cApeNom
        '
        Me.cApeNom.HeaderText = "Nombre"
        Me.cApeNom.Name = "cApeNom"
        Me.cApeNom.ReadOnly = True
        Me.cApeNom.Width = 262
        '
        'gbDatosCapacitacion
        '
        Me.gbDatosCapacitacion.Controls.Add(Me.txtInstructor)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label12)
        Me.gbDatosCapacitacion.Controls.Add(Me.cmbMoneda)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label8)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtDuracionCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label6)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtMesesEvaluarCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label7)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtCostoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.lblCostoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.lblDuracionCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.btnAgregarProveedor)
        Me.gbDatosCapacitacion.Controls.Add(Me.lblProveedorCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtProveedor)
        Me.gbDatosCapacitacion.Controls.Add(Me.btnBuscarProveedor)
        Me.gbDatosCapacitacion.Controls.Add(Me.cbProgramadoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.lblCursoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtCursoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.cmbTipoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.lblTipoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label9)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtObservacion)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label5)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtFechaFinal)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtFechaInicio)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label10)
        Me.gbDatosCapacitacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosCapacitacion.Location = New System.Drawing.Point(20, 300)
        Me.gbDatosCapacitacion.Name = "gbDatosCapacitacion"
        Me.gbDatosCapacitacion.Size = New System.Drawing.Size(680, 213)
        Me.gbDatosCapacitacion.TabIndex = 5
        Me.gbDatosCapacitacion.Text = "Datos de Capacitación"
        Me.gbDatosCapacitacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtInstructor
        '
        Me.txtInstructor.BackColor = System.Drawing.SystemColors.Window
        Me.txtInstructor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInstructor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructor.Location = New System.Drawing.Point(90, 139)
        Me.txtInstructor.Name = "txtInstructor"
        Me.txtInstructor.Size = New System.Drawing.Size(339, 20)
        Me.txtInstructor.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(24, 142)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 364
        Me.Label12.Text = "Instructor"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(400, 79)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(60, 20)
        Me.cmbMoneda.TabIndex = 12
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(345, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 354
        Me.Label8.Text = "Moneda"
        '
        'txtDuracionCapac
        '
        Me.txtDuracionCapac.BackColor = System.Drawing.SystemColors.Window
        Me.txtDuracionCapac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDuracionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuracionCapac.Location = New System.Drawing.Point(90, 80)
        Me.txtDuracionCapac.Name = "txtDuracionCapac"
        Me.txtDuracionCapac.Size = New System.Drawing.Size(185, 20)
        Me.txtDuracionCapac.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(626, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 353
        Me.Label6.Text = "meses"
        '
        'txtMesesEvaluarCapac
        '
        Me.txtMesesEvaluarCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesesEvaluarCapac.Location = New System.Drawing.Point(570, 139)
        Me.txtMesesEvaluarCapac.Maximum = 90
        Me.txtMesesEvaluarCapac.MaxLength = 2
        Me.txtMesesEvaluarCapac.Name = "txtMesesEvaluarCapac"
        Me.txtMesesEvaluarCapac.Size = New System.Drawing.Size(50, 20)
        Me.txtMesesEvaluarCapac.TabIndex = 18
        Me.txtMesesEvaluarCapac.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtMesesEvaluarCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(460, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 13)
        Me.Label7.TabIndex = 352
        Me.Label7.Text = "Evaluar dentro de"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCostoCapac
        '
        Me.txtCostoCapac.DecimalDigits = 2
        Me.txtCostoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoCapac.Location = New System.Drawing.Point(570, 80)
        Me.txtCostoCapac.MaxLength = 10
        Me.txtCostoCapac.Name = "txtCostoCapac"
        Me.txtCostoCapac.Size = New System.Drawing.Size(65, 20)
        Me.txtCostoCapac.TabIndex = 13
        Me.txtCostoCapac.Text = "0.00"
        Me.txtCostoCapac.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostoCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblCostoCapac
        '
        Me.lblCostoCapac.AutoSize = True
        Me.lblCostoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblCostoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoCapac.Location = New System.Drawing.Point(525, 84)
        Me.lblCostoCapac.Name = "lblCostoCapac"
        Me.lblCostoCapac.Size = New System.Drawing.Size(39, 13)
        Me.lblCostoCapac.TabIndex = 347
        Me.lblCostoCapac.Text = "Costo"
        '
        'lblDuracionCapac
        '
        Me.lblDuracionCapac.AutoSize = True
        Me.lblDuracionCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblDuracionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuracionCapac.Location = New System.Drawing.Point(26, 84)
        Me.lblDuracionCapac.Name = "lblDuracionCapac"
        Me.lblDuracionCapac.Size = New System.Drawing.Size(58, 13)
        Me.lblDuracionCapac.TabIndex = 346
        Me.lblDuracionCapac.Text = "Duración"
        '
        'btnAgregarProveedor
        '
        Me.btnAgregarProveedor.Image = CType(resources.GetObject("btnAgregarProveedor.Image"), System.Drawing.Image)
        Me.btnAgregarProveedor.Location = New System.Drawing.Point(497, 108)
        Me.btnAgregarProveedor.Name = "btnAgregarProveedor"
        Me.btnAgregarProveedor.Size = New System.Drawing.Size(23, 21)
        Me.btnAgregarProveedor.TabIndex = 16
        Me.btnAgregarProveedor.TabStop = False
        '
        'lblProveedorCapac
        '
        Me.lblProveedorCapac.AutoSize = True
        Me.lblProveedorCapac.Location = New System.Drawing.Point(20, 113)
        Me.lblProveedorCapac.Name = "lblProveedorCapac"
        Me.lblProveedorCapac.Size = New System.Drawing.Size(65, 13)
        Me.lblProveedorCapac.TabIndex = 342
        Me.lblProveedorCapac.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProveedor.Location = New System.Drawing.Point(90, 109)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(378, 20)
        Me.txtProveedor.TabIndex = 14
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(471, 107)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 15
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'cbProgramadoCapac
        '
        Me.cbProgramadoCapac.AutoSize = True
        Me.cbProgramadoCapac.BackColor = System.Drawing.Color.Transparent
        Me.cbProgramadoCapac.Location = New System.Drawing.Point(91, 52)
        Me.cbProgramadoCapac.Name = "cbProgramadoCapac"
        Me.cbProgramadoCapac.Size = New System.Drawing.Size(93, 17)
        Me.cbProgramadoCapac.TabIndex = 8
        Me.cbProgramadoCapac.Text = "Programado"
        Me.cbProgramadoCapac.UseVisualStyleBackColor = False
        '
        'lblCursoCapac
        '
        Me.lblCursoCapac.AutoSize = True
        Me.lblCursoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblCursoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCursoCapac.Location = New System.Drawing.Point(216, 24)
        Me.lblCursoCapac.Name = "lblCursoCapac"
        Me.lblCursoCapac.Size = New System.Drawing.Size(39, 13)
        Me.lblCursoCapac.TabIndex = 333
        Me.lblCursoCapac.Text = "Curso"
        '
        'txtCursoCapac
        '
        Me.txtCursoCapac.BackColor = System.Drawing.SystemColors.Window
        Me.txtCursoCapac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCursoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCursoCapac.Location = New System.Drawing.Point(261, 21)
        Me.txtCursoCapac.Name = "txtCursoCapac"
        Me.txtCursoCapac.Size = New System.Drawing.Size(409, 20)
        Me.txtCursoCapac.TabIndex = 7
        '
        'cmbTipoCapac
        '
        Me.cmbTipoCapac.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoCapac_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoCapac_DesignTimeLayout.LayoutString")
        Me.cmbTipoCapac.DesignTimeLayout = cmbTipoCapac_DesignTimeLayout
        Me.cmbTipoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCapac.Location = New System.Drawing.Point(90, 21)
        Me.cmbTipoCapac.Name = "cmbTipoCapac"
        Me.cmbTipoCapac.SelectedIndex = -1
        Me.cmbTipoCapac.SelectedItem = Nothing
        Me.cmbTipoCapac.Size = New System.Drawing.Size(96, 20)
        Me.cmbTipoCapac.TabIndex = 6
        Me.cmbTipoCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTipoCapac
        '
        Me.lblTipoCapac.AutoSize = True
        Me.lblTipoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCapac.Location = New System.Drawing.Point(52, 24)
        Me.lblTipoCapac.Name = "lblTipoCapac"
        Me.lblTipoCapac.Size = New System.Drawing.Size(32, 13)
        Me.lblTipoCapac.TabIndex = 330
        Me.lblTipoCapac.Text = "Tipo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 179)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 257
        Me.Label9.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(90, 169)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(580, 34)
        Me.txtObservacion.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(494, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 253
        Me.Label5.Text = "Fec. Final"
        '
        'txtFechaFinal
        '
        '
        '
        '
        Me.txtFechaFinal.DropDownCalendar.Name = ""
        Me.txtFechaFinal.DropDownCalendar.Visible = False
        Me.txtFechaFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFinal.Location = New System.Drawing.Point(560, 50)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.NullButtonText = "Ninguno"
        Me.txtFechaFinal.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaFinal.TabIndex = 10
        Me.txtFechaFinal.TodayButtonText = "Hoy"
        Me.txtFechaFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFechaInicio
        '
        '
        '
        '
        Me.txtFechaInicio.DropDownCalendar.Name = ""
        Me.txtFechaInicio.DropDownCalendar.Visible = False
        Me.txtFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.Location = New System.Drawing.Point(347, 50)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.NullButtonText = "Ninguno"
        Me.txtFechaInicio.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaInicio.TabIndex = 9
        Me.txtFechaInicio.TodayButtonText = "Hoy"
        Me.txtFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(274, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 252
        Me.Label10.Text = "Fec. Inicio"
        '
        'frmCapacitacion_Masivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(719, 522)
        Me.Controls.Add(Me.gbDatosCapacitacion)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.dgvPersonal)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapacitacion_Masivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capacitaciones de Personal Masivo"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosCapacitacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosCapacitacion.ResumeLayout(False)
        Me.gbDatosCapacitacion.PerformLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoCapac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGenerar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbClase As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents cIdPer1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents dgvPersonal As System.Windows.Forms.DataGridView
    Friend WithEvents cIdPer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbDatosCapacitacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCapac As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblTipoCapac As System.Windows.Forms.Label
    Friend WithEvents cbProgramadoCapac As System.Windows.Forms.CheckBox
    Friend WithEvents lblCursoCapac As System.Windows.Forms.Label
    Friend WithEvents txtCursoCapac As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblProveedorCapac As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents txtCostoCapac As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblCostoCapac As System.Windows.Forms.Label
    Friend WithEvents lblDuracionCapac As System.Windows.Forms.Label
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMesesEvaluarCapac As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDuracionCapac As System.Windows.Forms.TextBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInstructor As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
