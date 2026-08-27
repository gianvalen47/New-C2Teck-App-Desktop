<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPc
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
        Dim cmbTipoComputadora_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPc))
        Dim cmbMonCapac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoCapac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvCapacitaciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvSoftwares_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.gbDatosComputadora = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtComputadora = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.txtIdComputadora = New System.Windows.Forms.TextBox()
        Me.lblIdPer = New System.Windows.Forms.Label()
        Me.lblComputadora = New System.Windows.Forms.Label()
        Me.cmbTipoComputadora = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.tpCapacitaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.gbCapacitacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbMonCapac = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDuracionCapac = New System.Windows.Forms.TextBox()
        Me.cbEvaluadoCapac = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDuracionCapac = New System.Windows.Forms.Label()
        Me.txtMesesEvaluarCapac = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecEvaluacionCapac = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.biDeshacerCapac = New System.Windows.Forms.Button()
        Me.biGrabarCapac = New System.Windows.Forms.Button()
        Me.txtObsCapacitacion = New System.Windows.Forms.TextBox()
        Me.txtCostoCapac = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblObsvCapac = New System.Windows.Forms.Label()
        Me.lblCostoCapac = New System.Windows.Forms.Label()
        Me.btnAgregarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.lblProveedorCapac = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.cbProgramadoCapac = New System.Windows.Forms.CheckBox()
        Me.txtFecInicioCapac = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecInicioCapac = New System.Windows.Forms.Label()
        Me.txtFecFinalCapac = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecFinalCapac = New System.Windows.Forms.Label()
        Me.lblCursoCapac = New System.Windows.Forms.Label()
        Me.txtCursoCapac = New System.Windows.Forms.TextBox()
        Me.cmbTipoCapac = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblTipoCapac = New System.Windows.Forms.Label()
        Me.dgvCapacitaciones = New Janus.Windows.GridEX.GridEX()
        Me.tpSoftware = New Janus.Windows.UI.Tab.UITabPage()
        Me.gbEstudios = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarSoftware = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarSoftware = New System.Windows.Forms.Button()
        Me.txtSoftware = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvSoftwares = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminarSoftware = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarSoftware = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpHardware = New Janus.Windows.UI.Tab.UITabPage()
        Me.biDeshacerHardware = New System.Windows.Forms.Button()
        Me.biGrabaHardware = New System.Windows.Forms.Button()
        Me.gbFam1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbVigenteH = New System.Windows.Forms.CheckBox()
        Me.btnLimpiarMonitor = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarCargador = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarLectora = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarDiscoDuro = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarTarjetaVideo = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarMemRam = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarPlacaMadre = New Janus.Windows.EditControls.UIButton()
        Me.biLimpiarProcesador = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarPlacaMadre = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarMemRam = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarTarjetaVideo = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarDiscoDuro = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarLectora = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarCargador = New Janus.Windows.EditControls.UIButton()
        Me.frmAgregarMonitor = New Janus.Windows.EditControls.UIButton()
        Me.btnAgregarProcesador = New Janus.Windows.EditControls.UIButton()
        Me.txtNotaHardware = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtMotivoFinUso = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtFecFinUso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecIniUso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtMouse = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtTeclado = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnBuscarMonitor = New System.Windows.Forms.Button()
        Me.txtMonitor = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnBuscarCargador = New System.Windows.Forms.Button()
        Me.txtCargador = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnBuscarLectora = New System.Windows.Forms.Button()
        Me.txtLectora = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnBuscarDiscoDuro = New System.Windows.Forms.Button()
        Me.txtDiscoDuro = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnBuscarTarjetaVideo = New System.Windows.Forms.Button()
        Me.txtTarjetaVideo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBuscarMemoriaRam = New System.Windows.Forms.Button()
        Me.txtMemoriaRam = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnBuscarPlacaMadre = New System.Windows.Forms.Button()
        Me.txtPlacaMadre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnBuscarProcesador = New System.Windows.Forms.Button()
        Me.txtProcesador = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbUbicacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbEmpresa = New Janus.Windows.EditControls.UIGroupBox()
        Me.biGrabar = New System.Windows.Forms.Button()
        Me.biEditar = New System.Windows.Forms.Button()
        Me.biDeshacer = New System.Windows.Forms.Button()
        Me.TabPestañas = New Janus.Windows.UI.Tab.UITab()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacerr = New System.Windows.Forms.ToolStripButton()
        Me.biEditarr = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.gbDatosComputadora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosComputadora.SuspendLayout()
        CType(Me.cmbTipoComputadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCapacitaciones.SuspendLayout()
        CType(Me.gbCapacitacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCapacitacion.SuspendLayout()
        CType(Me.cmbMonCapac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoCapac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCapacitaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpSoftware.SuspendLayout()
        CType(Me.gbEstudios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstudios.SuspendLayout()
        CType(Me.dgvSoftwares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.tpHardware.SuspendLayout()
        CType(Me.gbFam1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFam1.SuspendLayout()
        CType(Me.gbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabPestañas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPestañas.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDatosComputadora
        '
        Me.gbDatosComputadora.BackColor = System.Drawing.Color.Transparent
        Me.gbDatosComputadora.Controls.Add(Me.txtComputadora)
        Me.gbDatosComputadora.Controls.Add(Me.Label2)
        Me.gbDatosComputadora.Controls.Add(Me.Label33)
        Me.gbDatosComputadora.Controls.Add(Me.cbVigente)
        Me.gbDatosComputadora.Controls.Add(Me.txtIdComputadora)
        Me.gbDatosComputadora.Controls.Add(Me.lblIdPer)
        Me.gbDatosComputadora.Controls.Add(Me.lblComputadora)
        Me.gbDatosComputadora.Controls.Add(Me.cmbTipoComputadora)
        Me.gbDatosComputadora.Location = New System.Drawing.Point(13, 45)
        Me.gbDatosComputadora.Name = "gbDatosComputadora"
        Me.gbDatosComputadora.Size = New System.Drawing.Size(575, 101)
        Me.gbDatosComputadora.TabIndex = 0
        Me.gbDatosComputadora.Text = "Datos Personales"
        Me.gbDatosComputadora.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtComputadora
        '
        Me.txtComputadora.BackColor = System.Drawing.SystemColors.Window
        Me.txtComputadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComputadora.Location = New System.Drawing.Point(94, 42)
        Me.txtComputadora.Name = "txtComputadora"
        Me.txtComputadora.Size = New System.Drawing.Size(381, 20)
        Me.txtComputadora.TabIndex = 412
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(44, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 411
        Me.Label2.Text = "Nombre"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(394, 75)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(43, 13)
        Me.Label33.TabIndex = 409
        Me.Label33.Text = "Vigente"
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.BackColor = System.Drawing.Color.Transparent
        Me.cbVigente.Checked = True
        Me.cbVigente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbVigente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVigente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigente.Location = New System.Drawing.Point(443, 75)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(15, 14)
        Me.cbVigente.TabIndex = 408
        Me.cbVigente.Tag = ""
        Me.cbVigente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbVigente.UseVisualStyleBackColor = False
        '
        'txtIdComputadora
        '
        Me.txtIdComputadora.BackColor = System.Drawing.Color.PowderBlue
        Me.txtIdComputadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdComputadora.Location = New System.Drawing.Point(95, 15)
        Me.txtIdComputadora.Name = "txtIdComputadora"
        Me.txtIdComputadora.ReadOnly = True
        Me.txtIdComputadora.Size = New System.Drawing.Size(75, 20)
        Me.txtIdComputadora.TabIndex = 1
        Me.txtIdComputadora.TabStop = False
        '
        'lblIdPer
        '
        Me.lblIdPer.AutoSize = True
        Me.lblIdPer.BackColor = System.Drawing.Color.Transparent
        Me.lblIdPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdPer.Location = New System.Drawing.Point(49, 18)
        Me.lblIdPer.Name = "lblIdPer"
        Me.lblIdPer.Size = New System.Drawing.Size(40, 13)
        Me.lblIdPer.TabIndex = 324
        Me.lblIdPer.Text = "Código"
        '
        'lblComputadora
        '
        Me.lblComputadora.AutoSize = True
        Me.lblComputadora.BackColor = System.Drawing.Color.Transparent
        Me.lblComputadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComputadora.Location = New System.Drawing.Point(19, 75)
        Me.lblComputadora.Name = "lblComputadora"
        Me.lblComputadora.Size = New System.Drawing.Size(70, 13)
        Me.lblComputadora.TabIndex = 316
        Me.lblComputadora.Text = "Computadora"
        '
        'cmbTipoComputadora
        '
        Me.cmbTipoComputadora.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoComputadora_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoComputadora_DesignTimeLayout.LayoutString")
        Me.cmbTipoComputadora.DesignTimeLayout = cmbTipoComputadora_DesignTimeLayout
        Me.cmbTipoComputadora.Location = New System.Drawing.Point(95, 71)
        Me.cmbTipoComputadora.Name = "cmbTipoComputadora"
        Me.cmbTipoComputadora.SelectedIndex = -1
        Me.cmbTipoComputadora.SelectedItem = Nothing
        Me.cmbTipoComputadora.Size = New System.Drawing.Size(153, 20)
        Me.cmbTipoComputadora.TabIndex = 2
        Me.cmbTipoComputadora.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'tpCapacitaciones
        '
        Me.tpCapacitaciones.Controls.Add(Me.gbCapacitacion)
        Me.tpCapacitaciones.Controls.Add(Me.dgvCapacitaciones)
        Me.tpCapacitaciones.Icon = CType(resources.GetObject("tpCapacitaciones.Icon"), System.Drawing.Icon)
        Me.tpCapacitaciones.Location = New System.Drawing.Point(1, 23)
        Me.tpCapacitaciones.Name = "tpCapacitaciones"
        Me.tpCapacitaciones.Size = New System.Drawing.Size(599, 526)
        Me.tpCapacitaciones.TabStop = True
        Me.tpCapacitaciones.TabVisible = False
        Me.tpCapacitaciones.Text = "CAPACITACIONES"
        '
        'gbCapacitacion
        '
        Me.gbCapacitacion.BackColor = System.Drawing.Color.Transparent
        Me.gbCapacitacion.Controls.Add(Me.cmbMonCapac)
        Me.gbCapacitacion.Controls.Add(Me.Label5)
        Me.gbCapacitacion.Controls.Add(Me.txtDuracionCapac)
        Me.gbCapacitacion.Controls.Add(Me.cbEvaluadoCapac)
        Me.gbCapacitacion.Controls.Add(Me.Label4)
        Me.gbCapacitacion.Controls.Add(Me.lblDuracionCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtMesesEvaluarCapac)
        Me.gbCapacitacion.Controls.Add(Me.Label3)
        Me.gbCapacitacion.Controls.Add(Me.txtFecEvaluacionCapac)
        Me.gbCapacitacion.Controls.Add(Me.Label1)
        Me.gbCapacitacion.Controls.Add(Me.biDeshacerCapac)
        Me.gbCapacitacion.Controls.Add(Me.biGrabarCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtObsCapacitacion)
        Me.gbCapacitacion.Controls.Add(Me.txtCostoCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblObsvCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblCostoCapac)
        Me.gbCapacitacion.Controls.Add(Me.btnAgregarProveedor)
        Me.gbCapacitacion.Controls.Add(Me.lblProveedorCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtProveedor)
        Me.gbCapacitacion.Controls.Add(Me.btnBuscarProveedor)
        Me.gbCapacitacion.Controls.Add(Me.cbProgramadoCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtFecInicioCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblFecInicioCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtFecFinalCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblFecFinalCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblCursoCapac)
        Me.gbCapacitacion.Controls.Add(Me.txtCursoCapac)
        Me.gbCapacitacion.Controls.Add(Me.cmbTipoCapac)
        Me.gbCapacitacion.Controls.Add(Me.lblTipoCapac)
        Me.gbCapacitacion.Location = New System.Drawing.Point(12, 76)
        Me.gbCapacitacion.Name = "gbCapacitacion"
        Me.gbCapacitacion.Size = New System.Drawing.Size(575, 210)
        Me.gbCapacitacion.TabIndex = 342
        Me.gbCapacitacion.Text = "Datos de Capacitación"
        Me.gbCapacitacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbMonCapac
        '
        Me.cmbMonCapac.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMonCapac_DesignTimeLayout.LayoutString = resources.GetString("cmbMonCapac_DesignTimeLayout.LayoutString")
        Me.cmbMonCapac.DesignTimeLayout = cmbMonCapac_DesignTimeLayout
        Me.cmbMonCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonCapac.Location = New System.Drawing.Point(340, 112)
        Me.cmbMonCapac.Name = "cmbMonCapac"
        Me.cmbMonCapac.SelectedIndex = -1
        Me.cmbMonCapac.SelectedItem = Nothing
        Me.cmbMonCapac.Size = New System.Drawing.Size(54, 20)
        Me.cmbMonCapac.TabIndex = 10
        Me.cmbMonCapac.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMonCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(310, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 352
        Me.Label5.Text = "Mon."
        '
        'txtDuracionCapac
        '
        Me.txtDuracionCapac.BackColor = System.Drawing.SystemColors.Window
        Me.txtDuracionCapac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDuracionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuracionCapac.Location = New System.Drawing.Point(77, 112)
        Me.txtDuracionCapac.Name = "txtDuracionCapac"
        Me.txtDuracionCapac.Size = New System.Drawing.Size(200, 20)
        Me.txtDuracionCapac.TabIndex = 9
        '
        'cbEvaluadoCapac
        '
        Me.cbEvaluadoCapac.AutoSize = True
        Me.cbEvaluadoCapac.BackColor = System.Drawing.Color.Transparent
        Me.cbEvaluadoCapac.Location = New System.Drawing.Point(266, 145)
        Me.cbEvaluadoCapac.Name = "cbEvaluadoCapac"
        Me.cbEvaluadoCapac.Size = New System.Drawing.Size(71, 17)
        Me.cbEvaluadoCapac.TabIndex = 13
        Me.cbEvaluadoCapac.Text = "Evaluado"
        Me.cbEvaluadoCapac.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(175, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 350
        Me.Label4.Text = "meses"
        '
        'lblDuracionCapac
        '
        Me.lblDuracionCapac.AutoSize = True
        Me.lblDuracionCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblDuracionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuracionCapac.Location = New System.Drawing.Point(24, 116)
        Me.lblDuracionCapac.Name = "lblDuracionCapac"
        Me.lblDuracionCapac.Size = New System.Drawing.Size(50, 13)
        Me.lblDuracionCapac.TabIndex = 336
        Me.lblDuracionCapac.Text = "Duración"
        '
        'txtMesesEvaluarCapac
        '
        Me.txtMesesEvaluarCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesesEvaluarCapac.Location = New System.Drawing.Point(115, 142)
        Me.txtMesesEvaluarCapac.Maximum = 90
        Me.txtMesesEvaluarCapac.MaxLength = 2
        Me.txtMesesEvaluarCapac.Name = "txtMesesEvaluarCapac"
        Me.txtMesesEvaluarCapac.Size = New System.Drawing.Size(54, 20)
        Me.txtMesesEvaluarCapac.TabIndex = 12
        Me.txtMesesEvaluarCapac.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtMesesEvaluarCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 349
        Me.Label3.Text = "Evaluar dentro de"
        '
        'txtFecEvaluacionCapac
        '
        '
        '
        '
        Me.txtFecEvaluacionCapac.DropDownCalendar.Name = ""
        Me.txtFecEvaluacionCapac.DropDownCalendar.Visible = False
        Me.txtFecEvaluacionCapac.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecEvaluacionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecEvaluacionCapac.IsNullDate = True
        Me.txtFecEvaluacionCapac.Location = New System.Drawing.Point(464, 142)
        Me.txtFecEvaluacionCapac.Name = "txtFecEvaluacionCapac"
        Me.txtFecEvaluacionCapac.NullButtonText = "Ninguno"
        Me.txtFecEvaluacionCapac.ShowNullButton = True
        Me.txtFecEvaluacionCapac.Size = New System.Drawing.Size(82, 20)
        Me.txtFecEvaluacionCapac.TabIndex = 14
        Me.txtFecEvaluacionCapac.TodayButtonText = "Hoy"
        Me.txtFecEvaluacionCapac.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(374, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 347
        Me.Label1.Text = "Fec. Evaluación"
        '
        'biDeshacerCapac
        '
        Me.biDeshacerCapac.BackColor = System.Drawing.Color.Transparent
        Me.biDeshacerCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biDeshacerCapac.Image = CType(resources.GetObject("biDeshacerCapac.Image"), System.Drawing.Image)
        Me.biDeshacerCapac.Location = New System.Drawing.Point(536, 172)
        Me.biDeshacerCapac.Name = "biDeshacerCapac"
        Me.biDeshacerCapac.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacerCapac.TabIndex = 17
        Me.biDeshacerCapac.TabStop = False
        Me.biDeshacerCapac.UseVisualStyleBackColor = False
        '
        'biGrabarCapac
        '
        Me.biGrabarCapac.BackColor = System.Drawing.Color.Transparent
        Me.biGrabarCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biGrabarCapac.Image = CType(resources.GetObject("biGrabarCapac.Image"), System.Drawing.Image)
        Me.biGrabarCapac.Location = New System.Drawing.Point(502, 172)
        Me.biGrabarCapac.Name = "biGrabarCapac"
        Me.biGrabarCapac.Size = New System.Drawing.Size(28, 28)
        Me.biGrabarCapac.TabIndex = 16
        Me.biGrabarCapac.UseVisualStyleBackColor = False
        '
        'txtObsCapacitacion
        '
        Me.txtObsCapacitacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtObsCapacitacion.Location = New System.Drawing.Point(77, 172)
        Me.txtObsCapacitacion.Multiline = True
        Me.txtObsCapacitacion.Name = "txtObsCapacitacion"
        Me.txtObsCapacitacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObsCapacitacion.Size = New System.Drawing.Size(413, 30)
        Me.txtObsCapacitacion.TabIndex = 15
        '
        'txtCostoCapac
        '
        Me.txtCostoCapac.DecimalDigits = 2
        Me.txtCostoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoCapac.Location = New System.Drawing.Point(461, 112)
        Me.txtCostoCapac.MaxLength = 10
        Me.txtCostoCapac.Name = "txtCostoCapac"
        Me.txtCostoCapac.Size = New System.Drawing.Size(82, 20)
        Me.txtCostoCapac.TabIndex = 11
        Me.txtCostoCapac.Text = "0.00"
        Me.txtCostoCapac.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostoCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblObsvCapac
        '
        Me.lblObsvCapac.AutoSize = True
        Me.lblObsvCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblObsvCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObsvCapac.Location = New System.Drawing.Point(4, 180)
        Me.lblObsvCapac.Name = "lblObsvCapac"
        Me.lblObsvCapac.Size = New System.Drawing.Size(67, 13)
        Me.lblObsvCapac.TabIndex = 345
        Me.lblObsvCapac.Text = "Observación"
        '
        'lblCostoCapac
        '
        Me.lblCostoCapac.AutoSize = True
        Me.lblCostoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblCostoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoCapac.Location = New System.Drawing.Point(421, 115)
        Me.lblCostoCapac.Name = "lblCostoCapac"
        Me.lblCostoCapac.Size = New System.Drawing.Size(34, 13)
        Me.lblCostoCapac.TabIndex = 343
        Me.lblCostoCapac.Text = "Costo"
        '
        'btnAgregarProveedor
        '
        Me.btnAgregarProveedor.Image = CType(resources.GetObject("btnAgregarProveedor.Image"), System.Drawing.Image)
        Me.btnAgregarProveedor.Location = New System.Drawing.Point(465, 82)
        Me.btnAgregarProveedor.Name = "btnAgregarProveedor"
        Me.btnAgregarProveedor.Size = New System.Drawing.Size(23, 21)
        Me.btnAgregarProveedor.TabIndex = 8
        Me.btnAgregarProveedor.TabStop = False
        '
        'lblProveedorCapac
        '
        Me.lblProveedorCapac.AutoSize = True
        Me.lblProveedorCapac.Location = New System.Drawing.Point(18, 86)
        Me.lblProveedorCapac.Name = "lblProveedorCapac"
        Me.lblProveedorCapac.Size = New System.Drawing.Size(56, 13)
        Me.lblProveedorCapac.TabIndex = 338
        Me.lblProveedorCapac.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.PowderBlue
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProveedor.Location = New System.Drawing.Point(77, 82)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(358, 20)
        Me.txtProveedor.TabIndex = 6
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = CType(resources.GetObject("btnBuscarProveedor.Image"), System.Drawing.Image)
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(438, 81)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 7
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'cbProgramadoCapac
        '
        Me.cbProgramadoCapac.AutoSize = True
        Me.cbProgramadoCapac.BackColor = System.Drawing.Color.Transparent
        Me.cbProgramadoCapac.Location = New System.Drawing.Point(79, 53)
        Me.cbProgramadoCapac.Name = "cbProgramadoCapac"
        Me.cbProgramadoCapac.Size = New System.Drawing.Size(83, 17)
        Me.cbProgramadoCapac.TabIndex = 3
        Me.cbProgramadoCapac.Text = "Programado"
        Me.cbProgramadoCapac.UseVisualStyleBackColor = False
        '
        'txtFecInicioCapac
        '
        '
        '
        '
        Me.txtFecInicioCapac.DropDownCalendar.Name = ""
        Me.txtFecInicioCapac.DropDownCalendar.Visible = False
        Me.txtFecInicioCapac.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicioCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecInicioCapac.IsNullDate = True
        Me.txtFecInicioCapac.Location = New System.Drawing.Point(253, 52)
        Me.txtFecInicioCapac.Name = "txtFecInicioCapac"
        Me.txtFecInicioCapac.NullButtonText = "Ninguno"
        Me.txtFecInicioCapac.Size = New System.Drawing.Size(82, 20)
        Me.txtFecInicioCapac.TabIndex = 4
        Me.txtFecInicioCapac.TodayButtonText = "Hoy"
        Me.txtFecInicioCapac.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lblFecInicioCapac
        '
        Me.lblFecInicioCapac.AutoSize = True
        Me.lblFecInicioCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblFecInicioCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecInicioCapac.Location = New System.Drawing.Point(191, 56)
        Me.lblFecInicioCapac.Name = "lblFecInicioCapac"
        Me.lblFecInicioCapac.Size = New System.Drawing.Size(56, 13)
        Me.lblFecInicioCapac.TabIndex = 334
        Me.lblFecInicioCapac.Text = "Fec. Inicio"
        '
        'txtFecFinalCapac
        '
        '
        '
        '
        Me.txtFecFinalCapac.DropDownCalendar.Name = ""
        Me.txtFecFinalCapac.DropDownCalendar.Visible = False
        Me.txtFecFinalCapac.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinalCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecFinalCapac.IsNullDate = True
        Me.txtFecFinalCapac.Location = New System.Drawing.Point(459, 52)
        Me.txtFecFinalCapac.Name = "txtFecFinalCapac"
        Me.txtFecFinalCapac.NullButtonText = "Ninguno"
        Me.txtFecFinalCapac.Size = New System.Drawing.Size(82, 20)
        Me.txtFecFinalCapac.TabIndex = 5
        Me.txtFecFinalCapac.TodayButtonText = "Hoy"
        Me.txtFecFinalCapac.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lblFecFinalCapac
        '
        Me.lblFecFinalCapac.AutoSize = True
        Me.lblFecFinalCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblFecFinalCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecFinalCapac.Location = New System.Drawing.Point(402, 56)
        Me.lblFecFinalCapac.Name = "lblFecFinalCapac"
        Me.lblFecFinalCapac.Size = New System.Drawing.Size(53, 13)
        Me.lblFecFinalCapac.TabIndex = 333
        Me.lblFecFinalCapac.Text = "Fec. Final"
        '
        'lblCursoCapac
        '
        Me.lblCursoCapac.AutoSize = True
        Me.lblCursoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblCursoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCursoCapac.Location = New System.Drawing.Point(172, 26)
        Me.lblCursoCapac.Name = "lblCursoCapac"
        Me.lblCursoCapac.Size = New System.Drawing.Size(34, 13)
        Me.lblCursoCapac.TabIndex = 330
        Me.lblCursoCapac.Text = "Curso"
        '
        'txtCursoCapac
        '
        Me.txtCursoCapac.BackColor = System.Drawing.SystemColors.Window
        Me.txtCursoCapac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCursoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCursoCapac.Location = New System.Drawing.Point(208, 22)
        Me.txtCursoCapac.Name = "txtCursoCapac"
        Me.txtCursoCapac.Size = New System.Drawing.Size(356, 20)
        Me.txtCursoCapac.TabIndex = 2
        '
        'cmbTipoCapac
        '
        Me.cmbTipoCapac.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoCapac_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoCapac_DesignTimeLayout.LayoutString")
        Me.cmbTipoCapac.DesignTimeLayout = cmbTipoCapac_DesignTimeLayout
        Me.cmbTipoCapac.Location = New System.Drawing.Point(77, 22)
        Me.cmbTipoCapac.Name = "cmbTipoCapac"
        Me.cmbTipoCapac.SelectedIndex = -1
        Me.cmbTipoCapac.SelectedItem = Nothing
        Me.cmbTipoCapac.Size = New System.Drawing.Size(82, 20)
        Me.cmbTipoCapac.TabIndex = 1
        Me.cmbTipoCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTipoCapac
        '
        Me.lblTipoCapac.AutoSize = True
        Me.lblTipoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCapac.Location = New System.Drawing.Point(43, 25)
        Me.lblTipoCapac.Name = "lblTipoCapac"
        Me.lblTipoCapac.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoCapac.TabIndex = 328
        Me.lblTipoCapac.Text = "Tipo"
        '
        'dgvCapacitaciones
        '
        dgvCapacitaciones_DesignTimeLayout.LayoutString = resources.GetString("dgvCapacitaciones_DesignTimeLayout.LayoutString")
        Me.dgvCapacitaciones.DesignTimeLayout = dgvCapacitaciones_DesignTimeLayout
        Me.dgvCapacitaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvCapacitaciones.GroupByBoxVisible = False
        Me.dgvCapacitaciones.Location = New System.Drawing.Point(13, 292)
        Me.dgvCapacitaciones.Name = "dgvCapacitaciones"
        Me.dgvCapacitaciones.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCapacitaciones.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCapacitaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCapacitaciones.Size = New System.Drawing.Size(574, 163)
        Me.dgvCapacitaciones.TabIndex = 341
        Me.dgvCapacitaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tpSoftware
        '
        Me.tpSoftware.Controls.Add(Me.gbEstudios)
        Me.tpSoftware.Icon = CType(resources.GetObject("tpSoftware.Icon"), System.Drawing.Icon)
        Me.tpSoftware.Location = New System.Drawing.Point(1, 23)
        Me.tpSoftware.Name = "tpSoftware"
        Me.tpSoftware.Size = New System.Drawing.Size(573, 464)
        Me.tpSoftware.TabStop = True
        Me.tpSoftware.Text = "SOFTWARE"
        '
        'gbEstudios
        '
        Me.gbEstudios.BackColor = System.Drawing.Color.Transparent
        Me.gbEstudios.Controls.Add(Me.btnAgregarSoftware)
        Me.gbEstudios.Controls.Add(Me.btnBuscarSoftware)
        Me.gbEstudios.Controls.Add(Me.txtSoftware)
        Me.gbEstudios.Controls.Add(Me.Label6)
        Me.gbEstudios.Controls.Add(Me.dgvSoftwares)
        Me.gbEstudios.Location = New System.Drawing.Point(12, 8)
        Me.gbEstudios.Name = "gbEstudios"
        Me.gbEstudios.Size = New System.Drawing.Size(552, 424)
        Me.gbEstudios.TabIndex = 0
        Me.gbEstudios.Text = "Software"
        Me.gbEstudios.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarSoftware
        '
        Me.btnAgregarSoftware.Image = CType(resources.GetObject("btnAgregarSoftware.Image"), System.Drawing.Image)
        Me.btnAgregarSoftware.Location = New System.Drawing.Point(472, 38)
        Me.btnAgregarSoftware.Name = "btnAgregarSoftware"
        Me.btnAgregarSoftware.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarSoftware.TabIndex = 383
        Me.btnAgregarSoftware.TabStop = False
        '
        'btnBuscarSoftware
        '
        Me.btnBuscarSoftware.Image = CType(resources.GetObject("btnBuscarSoftware.Image"), System.Drawing.Image)
        Me.btnBuscarSoftware.Location = New System.Drawing.Point(440, 37)
        Me.btnBuscarSoftware.Name = "btnBuscarSoftware"
        Me.btnBuscarSoftware.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarSoftware.TabIndex = 381
        Me.btnBuscarSoftware.TabStop = False
        Me.btnBuscarSoftware.UseVisualStyleBackColor = True
        '
        'txtSoftware
        '
        Me.txtSoftware.BackColor = System.Drawing.Color.PowderBlue
        Me.txtSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSoftware.Location = New System.Drawing.Point(126, 39)
        Me.txtSoftware.Name = "txtSoftware"
        Me.txtSoftware.ReadOnly = True
        Me.txtSoftware.Size = New System.Drawing.Size(308, 20)
        Me.txtSoftware.TabIndex = 380
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(71, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 382
        Me.Label6.Text = "Software"
        '
        'dgvSoftwares
        '
        Me.dgvSoftwares.ContextMenuStrip = Me.cmOpciones
        dgvSoftwares_DesignTimeLayout.LayoutString = resources.GetString("dgvSoftwares_DesignTimeLayout.LayoutString")
        Me.dgvSoftwares.DesignTimeLayout = dgvSoftwares_DesignTimeLayout
        Me.dgvSoftwares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvSoftwares.GroupByBoxVisible = False
        Me.dgvSoftwares.Location = New System.Drawing.Point(18, 83)
        Me.dgvSoftwares.Name = "dgvSoftwares"
        Me.dgvSoftwares.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvSoftwares.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvSoftwares.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvSoftwares.Size = New System.Drawing.Size(518, 321)
        Me.dgvSoftwares.TabIndex = 336
        Me.dgvSoftwares.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEliminarSoftware, Me.ToolStripSeparator1, Me.miActualizarSoftware})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(176, 54)
        '
        'miEliminarSoftware
        '
        Me.miEliminarSoftware.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarSoftware.Name = "miEliminarSoftware"
        Me.miEliminarSoftware.Size = New System.Drawing.Size(175, 22)
        Me.miEliminarSoftware.Text = "Eliminar Software"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(172, 6)
        '
        'miActualizarSoftware
        '
        Me.miActualizarSoftware.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarSoftware.Name = "miActualizarSoftware"
        Me.miActualizarSoftware.Size = New System.Drawing.Size(175, 22)
        Me.miActualizarSoftware.Text = "Actualizar Software"
        '
        'tpHardware
        '
        Me.tpHardware.Controls.Add(Me.biDeshacerHardware)
        Me.tpHardware.Controls.Add(Me.biGrabaHardware)
        Me.tpHardware.Controls.Add(Me.gbFam1)
        Me.tpHardware.Icon = CType(resources.GetObject("tpHardware.Icon"), System.Drawing.Icon)
        Me.tpHardware.Location = New System.Drawing.Point(1, 23)
        Me.tpHardware.Name = "tpHardware"
        Me.tpHardware.Size = New System.Drawing.Size(573, 464)
        Me.tpHardware.TabStop = True
        Me.tpHardware.Text = "HARDWARE"
        '
        'biDeshacerHardware
        '
        Me.biDeshacerHardware.BackColor = System.Drawing.Color.Transparent
        Me.biDeshacerHardware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biDeshacerHardware.Image = CType(resources.GetObject("biDeshacerHardware.Image"), System.Drawing.Image)
        Me.biDeshacerHardware.Location = New System.Drawing.Point(43, 6)
        Me.biDeshacerHardware.Name = "biDeshacerHardware"
        Me.biDeshacerHardware.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacerHardware.TabIndex = 378
        Me.biDeshacerHardware.TabStop = False
        Me.biDeshacerHardware.UseVisualStyleBackColor = False
        '
        'biGrabaHardware
        '
        Me.biGrabaHardware.Image = CType(resources.GetObject("biGrabaHardware.Image"), System.Drawing.Image)
        Me.biGrabaHardware.Location = New System.Drawing.Point(9, 6)
        Me.biGrabaHardware.Name = "biGrabaHardware"
        Me.biGrabaHardware.Size = New System.Drawing.Size(28, 28)
        Me.biGrabaHardware.TabIndex = 377
        Me.biGrabaHardware.UseVisualStyleBackColor = True
        '
        'gbFam1
        '
        Me.gbFam1.BackColor = System.Drawing.Color.Transparent
        Me.gbFam1.Controls.Add(Me.Label8)
        Me.gbFam1.Controls.Add(Me.cbVigenteH)
        Me.gbFam1.Controls.Add(Me.btnLimpiarMonitor)
        Me.gbFam1.Controls.Add(Me.btnLimpiarCargador)
        Me.gbFam1.Controls.Add(Me.btnLimpiarLectora)
        Me.gbFam1.Controls.Add(Me.btnLimpiarDiscoDuro)
        Me.gbFam1.Controls.Add(Me.btnLimpiarTarjetaVideo)
        Me.gbFam1.Controls.Add(Me.btnLimpiarMemRam)
        Me.gbFam1.Controls.Add(Me.btnLimpiarPlacaMadre)
        Me.gbFam1.Controls.Add(Me.biLimpiarProcesador)
        Me.gbFam1.Controls.Add(Me.frmAgregarPlacaMadre)
        Me.gbFam1.Controls.Add(Me.frmAgregarMemRam)
        Me.gbFam1.Controls.Add(Me.frmAgregarTarjetaVideo)
        Me.gbFam1.Controls.Add(Me.frmAgregarDiscoDuro)
        Me.gbFam1.Controls.Add(Me.frmAgregarLectora)
        Me.gbFam1.Controls.Add(Me.frmAgregarCargador)
        Me.gbFam1.Controls.Add(Me.frmAgregarMonitor)
        Me.gbFam1.Controls.Add(Me.btnAgregarProcesador)
        Me.gbFam1.Controls.Add(Me.txtNotaHardware)
        Me.gbFam1.Controls.Add(Me.Label31)
        Me.gbFam1.Controls.Add(Me.txtMotivoFinUso)
        Me.gbFam1.Controls.Add(Me.Label30)
        Me.gbFam1.Controls.Add(Me.txtFecFinUso)
        Me.gbFam1.Controls.Add(Me.txtFecIniUso)
        Me.gbFam1.Controls.Add(Me.Label19)
        Me.gbFam1.Controls.Add(Me.Label20)
        Me.gbFam1.Controls.Add(Me.txtMouse)
        Me.gbFam1.Controls.Add(Me.Label28)
        Me.gbFam1.Controls.Add(Me.txtTeclado)
        Me.gbFam1.Controls.Add(Me.Label29)
        Me.gbFam1.Controls.Add(Me.btnBuscarMonitor)
        Me.gbFam1.Controls.Add(Me.txtMonitor)
        Me.gbFam1.Controls.Add(Me.Label16)
        Me.gbFam1.Controls.Add(Me.btnBuscarCargador)
        Me.gbFam1.Controls.Add(Me.txtCargador)
        Me.gbFam1.Controls.Add(Me.Label17)
        Me.gbFam1.Controls.Add(Me.btnBuscarLectora)
        Me.gbFam1.Controls.Add(Me.txtLectora)
        Me.gbFam1.Controls.Add(Me.Label14)
        Me.gbFam1.Controls.Add(Me.btnBuscarDiscoDuro)
        Me.gbFam1.Controls.Add(Me.txtDiscoDuro)
        Me.gbFam1.Controls.Add(Me.Label15)
        Me.gbFam1.Controls.Add(Me.btnBuscarTarjetaVideo)
        Me.gbFam1.Controls.Add(Me.txtTarjetaVideo)
        Me.gbFam1.Controls.Add(Me.Label12)
        Me.gbFam1.Controls.Add(Me.btnBuscarMemoriaRam)
        Me.gbFam1.Controls.Add(Me.txtMemoriaRam)
        Me.gbFam1.Controls.Add(Me.Label13)
        Me.gbFam1.Controls.Add(Me.btnBuscarPlacaMadre)
        Me.gbFam1.Controls.Add(Me.txtPlacaMadre)
        Me.gbFam1.Controls.Add(Me.Label11)
        Me.gbFam1.Controls.Add(Me.btnBuscarProcesador)
        Me.gbFam1.Controls.Add(Me.txtProcesador)
        Me.gbFam1.Controls.Add(Me.Label7)
        Me.gbFam1.Location = New System.Drawing.Point(9, 35)
        Me.gbFam1.Name = "gbFam1"
        Me.gbFam1.Size = New System.Drawing.Size(526, 415)
        Me.gbFam1.TabIndex = 0
        Me.gbFam1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 384)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 423
        Me.Label8.Text = "Vigente"
        '
        'cbVigenteH
        '
        Me.cbVigenteH.AutoSize = True
        Me.cbVigenteH.BackColor = System.Drawing.Color.Transparent
        Me.cbVigenteH.Checked = True
        Me.cbVigenteH.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbVigenteH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVigenteH.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigenteH.Location = New System.Drawing.Point(97, 384)
        Me.cbVigenteH.Name = "cbVigenteH"
        Me.cbVigenteH.Size = New System.Drawing.Size(15, 14)
        Me.cbVigenteH.TabIndex = 422
        Me.cbVigenteH.Tag = ""
        Me.cbVigenteH.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbVigenteH.UseVisualStyleBackColor = False
        '
        'btnLimpiarMonitor
        '
        Me.btnLimpiarMonitor.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarMonitor.Location = New System.Drawing.Point(471, 205)
        Me.btnLimpiarMonitor.Name = "btnLimpiarMonitor"
        Me.btnLimpiarMonitor.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarMonitor.TabIndex = 421
        Me.btnLimpiarMonitor.TabStop = False
        '
        'btnLimpiarCargador
        '
        Me.btnLimpiarCargador.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarCargador.Location = New System.Drawing.Point(471, 180)
        Me.btnLimpiarCargador.Name = "btnLimpiarCargador"
        Me.btnLimpiarCargador.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarCargador.TabIndex = 420
        Me.btnLimpiarCargador.TabStop = False
        '
        'btnLimpiarLectora
        '
        Me.btnLimpiarLectora.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarLectora.Location = New System.Drawing.Point(471, 155)
        Me.btnLimpiarLectora.Name = "btnLimpiarLectora"
        Me.btnLimpiarLectora.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarLectora.TabIndex = 419
        Me.btnLimpiarLectora.TabStop = False
        '
        'btnLimpiarDiscoDuro
        '
        Me.btnLimpiarDiscoDuro.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarDiscoDuro.Location = New System.Drawing.Point(471, 128)
        Me.btnLimpiarDiscoDuro.Name = "btnLimpiarDiscoDuro"
        Me.btnLimpiarDiscoDuro.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarDiscoDuro.TabIndex = 418
        Me.btnLimpiarDiscoDuro.TabStop = False
        '
        'btnLimpiarTarjetaVideo
        '
        Me.btnLimpiarTarjetaVideo.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarTarjetaVideo.Location = New System.Drawing.Point(471, 102)
        Me.btnLimpiarTarjetaVideo.Name = "btnLimpiarTarjetaVideo"
        Me.btnLimpiarTarjetaVideo.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarTarjetaVideo.TabIndex = 417
        Me.btnLimpiarTarjetaVideo.TabStop = False
        '
        'btnLimpiarMemRam
        '
        Me.btnLimpiarMemRam.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarMemRam.Location = New System.Drawing.Point(471, 77)
        Me.btnLimpiarMemRam.Name = "btnLimpiarMemRam"
        Me.btnLimpiarMemRam.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarMemRam.TabIndex = 416
        Me.btnLimpiarMemRam.TabStop = False
        '
        'btnLimpiarPlacaMadre
        '
        Me.btnLimpiarPlacaMadre.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarPlacaMadre.Location = New System.Drawing.Point(471, 50)
        Me.btnLimpiarPlacaMadre.Name = "btnLimpiarPlacaMadre"
        Me.btnLimpiarPlacaMadre.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarPlacaMadre.TabIndex = 416
        Me.btnLimpiarPlacaMadre.TabStop = False
        '
        'biLimpiarProcesador
        '
        Me.biLimpiarProcesador.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.biLimpiarProcesador.Location = New System.Drawing.Point(471, 24)
        Me.biLimpiarProcesador.Name = "biLimpiarProcesador"
        Me.biLimpiarProcesador.Size = New System.Drawing.Size(25, 22)
        Me.biLimpiarProcesador.TabIndex = 415
        Me.biLimpiarProcesador.TabStop = False
        '
        'frmAgregarPlacaMadre
        '
        Me.frmAgregarPlacaMadre.Image = CType(resources.GetObject("frmAgregarPlacaMadre.Image"), System.Drawing.Image)
        Me.frmAgregarPlacaMadre.Location = New System.Drawing.Point(440, 50)
        Me.frmAgregarPlacaMadre.Name = "frmAgregarPlacaMadre"
        Me.frmAgregarPlacaMadre.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarPlacaMadre.TabIndex = 414
        Me.frmAgregarPlacaMadre.TabStop = False
        '
        'frmAgregarMemRam
        '
        Me.frmAgregarMemRam.Image = CType(resources.GetObject("frmAgregarMemRam.Image"), System.Drawing.Image)
        Me.frmAgregarMemRam.Location = New System.Drawing.Point(440, 77)
        Me.frmAgregarMemRam.Name = "frmAgregarMemRam"
        Me.frmAgregarMemRam.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarMemRam.TabIndex = 413
        Me.frmAgregarMemRam.TabStop = False
        '
        'frmAgregarTarjetaVideo
        '
        Me.frmAgregarTarjetaVideo.Image = CType(resources.GetObject("frmAgregarTarjetaVideo.Image"), System.Drawing.Image)
        Me.frmAgregarTarjetaVideo.Location = New System.Drawing.Point(440, 103)
        Me.frmAgregarTarjetaVideo.Name = "frmAgregarTarjetaVideo"
        Me.frmAgregarTarjetaVideo.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarTarjetaVideo.TabIndex = 412
        Me.frmAgregarTarjetaVideo.TabStop = False
        '
        'frmAgregarDiscoDuro
        '
        Me.frmAgregarDiscoDuro.Image = CType(resources.GetObject("frmAgregarDiscoDuro.Image"), System.Drawing.Image)
        Me.frmAgregarDiscoDuro.Location = New System.Drawing.Point(440, 128)
        Me.frmAgregarDiscoDuro.Name = "frmAgregarDiscoDuro"
        Me.frmAgregarDiscoDuro.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarDiscoDuro.TabIndex = 411
        Me.frmAgregarDiscoDuro.TabStop = False
        '
        'frmAgregarLectora
        '
        Me.frmAgregarLectora.Image = CType(resources.GetObject("frmAgregarLectora.Image"), System.Drawing.Image)
        Me.frmAgregarLectora.Location = New System.Drawing.Point(440, 154)
        Me.frmAgregarLectora.Name = "frmAgregarLectora"
        Me.frmAgregarLectora.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarLectora.TabIndex = 410
        Me.frmAgregarLectora.TabStop = False
        '
        'frmAgregarCargador
        '
        Me.frmAgregarCargador.Image = CType(resources.GetObject("frmAgregarCargador.Image"), System.Drawing.Image)
        Me.frmAgregarCargador.Location = New System.Drawing.Point(440, 179)
        Me.frmAgregarCargador.Name = "frmAgregarCargador"
        Me.frmAgregarCargador.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarCargador.TabIndex = 409
        Me.frmAgregarCargador.TabStop = False
        '
        'frmAgregarMonitor
        '
        Me.frmAgregarMonitor.Image = CType(resources.GetObject("frmAgregarMonitor.Image"), System.Drawing.Image)
        Me.frmAgregarMonitor.Location = New System.Drawing.Point(440, 205)
        Me.frmAgregarMonitor.Name = "frmAgregarMonitor"
        Me.frmAgregarMonitor.Size = New System.Drawing.Size(25, 22)
        Me.frmAgregarMonitor.TabIndex = 408
        Me.frmAgregarMonitor.TabStop = False
        '
        'btnAgregarProcesador
        '
        Me.btnAgregarProcesador.Image = CType(resources.GetObject("btnAgregarProcesador.Image"), System.Drawing.Image)
        Me.btnAgregarProcesador.Location = New System.Drawing.Point(440, 24)
        Me.btnAgregarProcesador.Name = "btnAgregarProcesador"
        Me.btnAgregarProcesador.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarProcesador.TabIndex = 379
        Me.btnAgregarProcesador.TabStop = False
        '
        'txtNotaHardware
        '
        Me.txtNotaHardware.Location = New System.Drawing.Point(94, 346)
        Me.txtNotaHardware.Multiline = True
        Me.txtNotaHardware.Name = "txtNotaHardware"
        Me.txtNotaHardware.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNotaHardware.Size = New System.Drawing.Size(415, 30)
        Me.txtNotaHardware.TabIndex = 406
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(57, 354)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(30, 13)
        Me.Label31.TabIndex = 407
        Me.Label31.Text = "Nota"
        '
        'txtMotivoFinUso
        '
        Me.txtMotivoFinUso.Location = New System.Drawing.Point(94, 310)
        Me.txtMotivoFinUso.Multiline = True
        Me.txtMotivoFinUso.Name = "txtMotivoFinUso"
        Me.txtMotivoFinUso.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMotivoFinUso.Size = New System.Drawing.Size(415, 30)
        Me.txtMotivoFinUso.TabIndex = 404
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(10, 317)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(78, 13)
        Me.Label30.TabIndex = 405
        Me.Label30.Text = "Motivo Fin Uso"
        '
        'txtFecFinUso
        '
        '
        '
        '
        Me.txtFecFinUso.DropDownCalendar.Name = ""
        Me.txtFecFinUso.DropDownCalendar.Visible = False
        Me.txtFecFinUso.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecFinUso.IsNullDate = True
        Me.txtFecFinUso.Location = New System.Drawing.Point(327, 284)
        Me.txtFecFinUso.Name = "txtFecFinUso"
        Me.txtFecFinUso.NullButtonText = "Ninguno"
        Me.txtFecFinUso.ShowNullButton = True
        Me.txtFecFinUso.Size = New System.Drawing.Size(82, 20)
        Me.txtFecFinUso.TabIndex = 399
        Me.txtFecFinUso.TodayButtonText = "Hoy"
        Me.txtFecFinUso.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecIniUso
        '
        '
        '
        '
        Me.txtFecIniUso.DropDownCalendar.Name = ""
        Me.txtFecIniUso.DropDownCalendar.Visible = False
        Me.txtFecIniUso.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIniUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecIniUso.IsNullDate = True
        Me.txtFecIniUso.Location = New System.Drawing.Point(94, 284)
        Me.txtFecIniUso.Name = "txtFecIniUso"
        Me.txtFecIniUso.NullButtonText = "Ninguno"
        Me.txtFecIniUso.Size = New System.Drawing.Size(82, 20)
        Me.txtFecIniUso.TabIndex = 398
        Me.txtFecIniUso.TodayButtonText = "Hoy"
        Me.txtFecIniUso.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(254, 288)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 403
        Me.Label19.Text = "Fec. Fin Uso"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(21, 288)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 13)
        Me.Label20.TabIndex = 402
        Me.Label20.Text = "Fec. Ini. Uso"
        '
        'txtMouse
        '
        Me.txtMouse.BackColor = System.Drawing.SystemColors.Window
        Me.txtMouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMouse.Location = New System.Drawing.Point(94, 258)
        Me.txtMouse.Name = "txtMouse"
        Me.txtMouse.Size = New System.Drawing.Size(315, 20)
        Me.txtMouse.TabIndex = 397
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(48, 261)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 401
        Me.Label28.Text = "Mouse"
        '
        'txtTeclado
        '
        Me.txtTeclado.BackColor = System.Drawing.SystemColors.Window
        Me.txtTeclado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeclado.Location = New System.Drawing.Point(94, 232)
        Me.txtTeclado.Name = "txtTeclado"
        Me.txtTeclado.Size = New System.Drawing.Size(315, 20)
        Me.txtTeclado.TabIndex = 396
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(41, 235)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(46, 13)
        Me.Label29.TabIndex = 400
        Me.Label29.Text = "Teclado"
        '
        'btnBuscarMonitor
        '
        Me.btnBuscarMonitor.Image = CType(resources.GetObject("btnBuscarMonitor.Image"), System.Drawing.Image)
        Me.btnBuscarMonitor.Location = New System.Drawing.Point(408, 204)
        Me.btnBuscarMonitor.Name = "btnBuscarMonitor"
        Me.btnBuscarMonitor.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarMonitor.TabIndex = 394
        Me.btnBuscarMonitor.TabStop = False
        Me.btnBuscarMonitor.UseVisualStyleBackColor = True
        '
        'txtMonitor
        '
        Me.txtMonitor.BackColor = System.Drawing.Color.PowderBlue
        Me.txtMonitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonitor.Location = New System.Drawing.Point(94, 206)
        Me.txtMonitor.Name = "txtMonitor"
        Me.txtMonitor.ReadOnly = True
        Me.txtMonitor.Size = New System.Drawing.Size(308, 20)
        Me.txtMonitor.TabIndex = 393
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(45, 209)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 395
        Me.Label16.Text = "Monitor"
        '
        'btnBuscarCargador
        '
        Me.btnBuscarCargador.Image = CType(resources.GetObject("btnBuscarCargador.Image"), System.Drawing.Image)
        Me.btnBuscarCargador.Location = New System.Drawing.Point(408, 178)
        Me.btnBuscarCargador.Name = "btnBuscarCargador"
        Me.btnBuscarCargador.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarCargador.TabIndex = 391
        Me.btnBuscarCargador.TabStop = False
        Me.btnBuscarCargador.UseVisualStyleBackColor = True
        '
        'txtCargador
        '
        Me.txtCargador.BackColor = System.Drawing.Color.PowderBlue
        Me.txtCargador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargador.Location = New System.Drawing.Point(94, 180)
        Me.txtCargador.Name = "txtCargador"
        Me.txtCargador.ReadOnly = True
        Me.txtCargador.Size = New System.Drawing.Size(308, 20)
        Me.txtCargador.TabIndex = 390
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(39, 183)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 392
        Me.Label17.Text = "Cargador"
        '
        'btnBuscarLectora
        '
        Me.btnBuscarLectora.Image = CType(resources.GetObject("btnBuscarLectora.Image"), System.Drawing.Image)
        Me.btnBuscarLectora.Location = New System.Drawing.Point(408, 153)
        Me.btnBuscarLectora.Name = "btnBuscarLectora"
        Me.btnBuscarLectora.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarLectora.TabIndex = 388
        Me.btnBuscarLectora.TabStop = False
        Me.btnBuscarLectora.UseVisualStyleBackColor = True
        '
        'txtLectora
        '
        Me.txtLectora.BackColor = System.Drawing.Color.PowderBlue
        Me.txtLectora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLectora.Location = New System.Drawing.Point(94, 155)
        Me.txtLectora.Name = "txtLectora"
        Me.txtLectora.ReadOnly = True
        Me.txtLectora.Size = New System.Drawing.Size(308, 20)
        Me.txtLectora.TabIndex = 387
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(45, 158)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 389
        Me.Label14.Text = "Lectora"
        '
        'btnBuscarDiscoDuro
        '
        Me.btnBuscarDiscoDuro.Image = CType(resources.GetObject("btnBuscarDiscoDuro.Image"), System.Drawing.Image)
        Me.btnBuscarDiscoDuro.Location = New System.Drawing.Point(408, 127)
        Me.btnBuscarDiscoDuro.Name = "btnBuscarDiscoDuro"
        Me.btnBuscarDiscoDuro.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarDiscoDuro.TabIndex = 385
        Me.btnBuscarDiscoDuro.TabStop = False
        Me.btnBuscarDiscoDuro.UseVisualStyleBackColor = True
        '
        'txtDiscoDuro
        '
        Me.txtDiscoDuro.BackColor = System.Drawing.Color.PowderBlue
        Me.txtDiscoDuro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscoDuro.Location = New System.Drawing.Point(94, 129)
        Me.txtDiscoDuro.Name = "txtDiscoDuro"
        Me.txtDiscoDuro.ReadOnly = True
        Me.txtDiscoDuro.Size = New System.Drawing.Size(308, 20)
        Me.txtDiscoDuro.TabIndex = 384
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(28, 132)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 386
        Me.Label15.Text = "Disco Duro"
        '
        'btnBuscarTarjetaVideo
        '
        Me.btnBuscarTarjetaVideo.Image = CType(resources.GetObject("btnBuscarTarjetaVideo.Image"), System.Drawing.Image)
        Me.btnBuscarTarjetaVideo.Location = New System.Drawing.Point(408, 102)
        Me.btnBuscarTarjetaVideo.Name = "btnBuscarTarjetaVideo"
        Me.btnBuscarTarjetaVideo.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarTarjetaVideo.TabIndex = 382
        Me.btnBuscarTarjetaVideo.TabStop = False
        Me.btnBuscarTarjetaVideo.UseVisualStyleBackColor = True
        '
        'txtTarjetaVideo
        '
        Me.txtTarjetaVideo.BackColor = System.Drawing.Color.PowderBlue
        Me.txtTarjetaVideo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarjetaVideo.Location = New System.Drawing.Point(94, 104)
        Me.txtTarjetaVideo.Name = "txtTarjetaVideo"
        Me.txtTarjetaVideo.ReadOnly = True
        Me.txtTarjetaVideo.Size = New System.Drawing.Size(308, 20)
        Me.txtTarjetaVideo.TabIndex = 381
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(19, 107)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 383
        Me.Label12.Text = "Tarjeta Video"
        '
        'btnBuscarMemoriaRam
        '
        Me.btnBuscarMemoriaRam.Image = CType(resources.GetObject("btnBuscarMemoriaRam.Image"), System.Drawing.Image)
        Me.btnBuscarMemoriaRam.Location = New System.Drawing.Point(408, 76)
        Me.btnBuscarMemoriaRam.Name = "btnBuscarMemoriaRam"
        Me.btnBuscarMemoriaRam.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarMemoriaRam.TabIndex = 379
        Me.btnBuscarMemoriaRam.TabStop = False
        Me.btnBuscarMemoriaRam.UseVisualStyleBackColor = True
        '
        'txtMemoriaRam
        '
        Me.txtMemoriaRam.BackColor = System.Drawing.Color.PowderBlue
        Me.txtMemoriaRam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemoriaRam.Location = New System.Drawing.Point(94, 78)
        Me.txtMemoriaRam.Name = "txtMemoriaRam"
        Me.txtMemoriaRam.ReadOnly = True
        Me.txtMemoriaRam.Size = New System.Drawing.Size(308, 20)
        Me.txtMemoriaRam.TabIndex = 378
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 13)
        Me.Label13.TabIndex = 380
        Me.Label13.Text = "Memoria Ram"
        '
        'btnBuscarPlacaMadre
        '
        Me.btnBuscarPlacaMadre.Image = CType(resources.GetObject("btnBuscarPlacaMadre.Image"), System.Drawing.Image)
        Me.btnBuscarPlacaMadre.Location = New System.Drawing.Point(408, 49)
        Me.btnBuscarPlacaMadre.Name = "btnBuscarPlacaMadre"
        Me.btnBuscarPlacaMadre.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarPlacaMadre.TabIndex = 376
        Me.btnBuscarPlacaMadre.TabStop = False
        Me.btnBuscarPlacaMadre.UseVisualStyleBackColor = True
        '
        'txtPlacaMadre
        '
        Me.txtPlacaMadre.BackColor = System.Drawing.Color.PowderBlue
        Me.txtPlacaMadre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacaMadre.Location = New System.Drawing.Point(94, 51)
        Me.txtPlacaMadre.Name = "txtPlacaMadre"
        Me.txtPlacaMadre.ReadOnly = True
        Me.txtPlacaMadre.Size = New System.Drawing.Size(308, 20)
        Me.txtPlacaMadre.TabIndex = 375
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(21, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 377
        Me.Label11.Text = "Placa Madre"
        '
        'btnBuscarProcesador
        '
        Me.btnBuscarProcesador.Image = CType(resources.GetObject("btnBuscarProcesador.Image"), System.Drawing.Image)
        Me.btnBuscarProcesador.Location = New System.Drawing.Point(408, 23)
        Me.btnBuscarProcesador.Name = "btnBuscarProcesador"
        Me.btnBuscarProcesador.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarProcesador.TabIndex = 373
        Me.btnBuscarProcesador.TabStop = False
        Me.btnBuscarProcesador.UseVisualStyleBackColor = True
        '
        'txtProcesador
        '
        Me.txtProcesador.BackColor = System.Drawing.Color.PowderBlue
        Me.txtProcesador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcesador.Location = New System.Drawing.Point(94, 25)
        Me.txtProcesador.Name = "txtProcesador"
        Me.txtProcesador.ReadOnly = True
        Me.txtProcesador.Size = New System.Drawing.Size(308, 20)
        Me.txtProcesador.TabIndex = 372
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 374
        Me.Label7.Text = "Procesador"
        '
        'gbUbicacion
        '
        Me.gbUbicacion.BackColor = System.Drawing.Color.Transparent
        Me.gbUbicacion.Location = New System.Drawing.Point(12, 213)
        Me.gbUbicacion.Name = "gbUbicacion"
        Me.gbUbicacion.Size = New System.Drawing.Size(575, 95)
        Me.gbUbicacion.TabIndex = 16
        Me.gbUbicacion.Text = "Ubicación"
        Me.gbUbicacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbEmpresa
        '
        Me.gbEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.gbEmpresa.Location = New System.Drawing.Point(12, 312)
        Me.gbEmpresa.Name = "gbEmpresa"
        Me.gbEmpresa.Size = New System.Drawing.Size(575, 125)
        Me.gbEmpresa.TabIndex = 26
        Me.gbEmpresa.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'biGrabar
        '
        Me.biGrabar.BackColor = System.Drawing.Color.Transparent
        Me.biGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biGrabar.Image = CType(resources.GetObject("biGrabar.Image"), System.Drawing.Image)
        Me.biGrabar.Location = New System.Drawing.Point(59, 5)
        Me.biGrabar.Name = "biGrabar"
        Me.biGrabar.Size = New System.Drawing.Size(28, 28)
        Me.biGrabar.TabIndex = 44
        Me.biGrabar.UseVisualStyleBackColor = False
        '
        'biEditar
        '
        Me.biEditar.BackColor = System.Drawing.Color.Transparent
        Me.biEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biEditar.Image = CType(resources.GetObject("biEditar.Image"), System.Drawing.Image)
        Me.biEditar.Location = New System.Drawing.Point(12, 5)
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.TabIndex = 225
        Me.biEditar.TabStop = False
        Me.biEditar.UseVisualStyleBackColor = False
        '
        'biDeshacer
        '
        Me.biDeshacer.BackColor = System.Drawing.Color.Transparent
        Me.biDeshacer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biDeshacer.Image = CType(resources.GetObject("biDeshacer.Image"), System.Drawing.Image)
        Me.biDeshacer.Location = New System.Drawing.Point(107, 5)
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.TabIndex = 226
        Me.biDeshacer.TabStop = False
        Me.biDeshacer.UseVisualStyleBackColor = False
        '
        'TabPestañas
        '
        Me.TabPestañas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPestañas.Location = New System.Drawing.Point(13, 157)
        Me.TabPestañas.Name = "TabPestañas"
        Me.TabPestañas.Size = New System.Drawing.Size(575, 488)
        Me.TabPestañas.TabIndex = 1
        Me.TabPestañas.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tpHardware, Me.tpSoftware, Me.tpCapacitaciones})
        Me.TabPestañas.TabStop = False
        Me.TabPestañas.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biDeshacerr, Me.biEditarr, Me.ToolStripSeparator4, Me.ToolStripSeparator7, Me.biCerrar, Me.ToolStripSeparator5})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(603, 31)
        Me.ToolStrip.TabIndex = 187
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacerr
        '
        Me.biDeshacerr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacerr.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacerr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacerr.Name = "biDeshacerr"
        Me.biDeshacerr.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacerr.Text = "Deshacer Cambios"
        '
        'biEditarr
        '
        Me.biEditarr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditarr.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditarr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditarr.Name = "biEditarr"
        Me.biEditarr.Size = New System.Drawing.Size(28, 28)
        Me.biEditarr.Text = "Editar Cabecera"
        Me.biEditarr.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator4.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'frmPc
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(603, 657)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.TabPestañas)
        Me.Controls.Add(Me.gbDatosComputadora)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(611, 691)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(611, 691)
        Me.Name = "frmPc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Computadora"
        CType(Me.gbDatosComputadora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosComputadora.ResumeLayout(False)
        Me.gbDatosComputadora.PerformLayout()
        CType(Me.cmbTipoComputadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCapacitaciones.ResumeLayout(False)
        CType(Me.gbCapacitacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCapacitacion.ResumeLayout(False)
        Me.gbCapacitacion.PerformLayout()
        CType(Me.cmbMonCapac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoCapac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCapacitaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpSoftware.ResumeLayout(False)
        CType(Me.gbEstudios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstudios.ResumeLayout(False)
        Me.gbEstudios.PerformLayout()
        CType(Me.dgvSoftwares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.tpHardware.ResumeLayout(False)
        CType(Me.gbFam1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFam1.ResumeLayout(False)
        Me.gbFam1.PerformLayout()
        CType(Me.gbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabPestañas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPestañas.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDatosComputadora As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtIdComputadora As TextBox
    Friend WithEvents lblIdPer As Label
    Friend WithEvents lblComputadora As Label
    Friend WithEvents cmbTipoComputadora As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label33 As Label
    Friend WithEvents cbVigente As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtComputadora As TextBox
    Friend WithEvents biDeshacer As Button
    Friend WithEvents biEditar As Button
    Friend WithEvents biGrabar As Button
    Friend WithEvents gbEmpresa As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbUbicacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvCapacitaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblTipoCapac As Label
    Friend WithEvents cmbTipoCapac As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtCursoCapac As TextBox
    Friend WithEvents lblCursoCapac As Label
    Friend WithEvents lblFecFinalCapac As Label
    Friend WithEvents txtFecFinalCapac As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblFecInicioCapac As Label
    Friend WithEvents txtFecInicioCapac As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbProgramadoCapac As CheckBox
    Friend WithEvents btnBuscarProveedor As Button
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents lblProveedorCapac As Label
    Friend WithEvents btnAgregarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblCostoCapac As Label
    Friend WithEvents lblObsvCapac As Label
    Friend WithEvents txtCostoCapac As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtObsCapacitacion As TextBox
    Friend WithEvents biGrabarCapac As Button
    Friend WithEvents biDeshacerCapac As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFecEvaluacionCapac As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMesesEvaluarCapac As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents lblDuracionCapac As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbEvaluadoCapac As CheckBox
    Friend WithEvents txtDuracionCapac As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbMonCapac As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbCapacitacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents tpCapacitaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvSoftwares As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbEstudios As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents tpSoftware As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents Label7 As Label
    Friend WithEvents txtProcesador As TextBox
    Friend WithEvents btnBuscarProcesador As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPlacaMadre As TextBox
    Friend WithEvents btnBuscarPlacaMadre As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents txtMemoriaRam As TextBox
    Friend WithEvents btnBuscarMemoriaRam As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTarjetaVideo As TextBox
    Friend WithEvents btnBuscarTarjetaVideo As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents txtDiscoDuro As TextBox
    Friend WithEvents btnBuscarDiscoDuro As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents txtLectora As TextBox
    Friend WithEvents btnBuscarLectora As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents txtCargador As TextBox
    Friend WithEvents btnBuscarCargador As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents txtMonitor As TextBox
    Friend WithEvents btnBuscarMonitor As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents txtTeclado As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtMouse As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtFecIniUso As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecFinUso As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label30 As Label
    Friend WithEvents txtMotivoFinUso As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtNotaHardware As TextBox
    Friend WithEvents btnAgregarProcesador As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarMonitor As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarCargador As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarLectora As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarDiscoDuro As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarTarjetaVideo As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarMemRam As Janus.Windows.EditControls.UIButton
    Friend WithEvents frmAgregarPlacaMadre As Janus.Windows.EditControls.UIButton
    Friend WithEvents biLimpiarProcesador As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarPlacaMadre As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarMemRam As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarTarjetaVideo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarDiscoDuro As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarLectora As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarCargador As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarMonitor As Janus.Windows.EditControls.UIButton
    Friend WithEvents gbFam1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents biGrabaHardware As Button
    Friend WithEvents biDeshacerHardware As Button
    Friend WithEvents tpHardware As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents TabPestañas As Janus.Windows.UI.Tab.UITab
    Friend WithEvents btnAgregarSoftware As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarSoftware As Button
    Friend WithEvents txtSoftware As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents biGuardar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents biEditarr As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents biDeshacerr As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents biCerrar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents Label8 As Label
    Friend WithEvents cbVigenteH As CheckBox
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miEliminarSoftware As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miActualizarSoftware As ToolStripMenuItem
End Class
