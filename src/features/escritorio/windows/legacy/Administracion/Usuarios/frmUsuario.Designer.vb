<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUsuario
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuario))
        Dim dgvEmpresas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvSistemas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvLocaciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvRubroRecurso_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvEquipos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbVigente = New Janus.Windows.EditControls.UICheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.txtCodUsu = New System.Windows.Forms.TextBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblFecModificacion = New System.Windows.Forms.Label()
        Me.cbSeteo = New Janus.Windows.EditControls.UICheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.TabOpciones = New Janus.Windows.UI.Tab.UITab()
        Me.tbEmpresas = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAsigEmpresa = New System.Windows.Forms.Button()
        Me.dgvEmpresas = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpEmpresa = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnIngresarEmpresa = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBorrarEmpresa = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbSistemas = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAsignarSistemas = New System.Windows.Forms.Button()
        Me.dgvSistemas = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpSistemas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoSis = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarSis = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbPermisos = New Janus.Windows.UI.Tab.UITabPage()
        Me.cmbOpPermisos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoPer = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarPer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ckLibreLicencia = New Janus.Windows.EditControls.UICheckBox()
        Me.ckAprobacionUnica = New Janus.Windows.EditControls.UICheckBox()
        Me.ckExportarDatos = New Janus.Windows.EditControls.UICheckBox()
        Me.ckVerPrecios = New Janus.Windows.EditControls.UICheckBox()
        Me.ckVendeOficina = New Janus.Windows.EditControls.UICheckBox()
        Me.ckGastoGerencia = New Janus.Windows.EditControls.UICheckBox()
        Me.ckPrecioFlete = New Janus.Windows.EditControls.UICheckBox()
        Me.ckVerGastos = New Janus.Windows.EditControls.UICheckBox()
        Me.txtPerfil = New System.Windows.Forms.TextBox()
        Me.gbFacturacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTipFacTodos = New System.Windows.Forms.RadioButton()
        Me.rbTipFacCon = New System.Windows.Forms.RadioButton()
        Me.rbTipFacCre = New System.Windows.Forms.RadioButton()
        Me.ckPerPrecioFOB = New Janus.Windows.EditControls.UICheckBox()
        Me.ckPerPrecio = New Janus.Windows.EditControls.UICheckBox()
        Me.ckCartera = New Janus.Windows.EditControls.UICheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ckTipCam = New Janus.Windows.EditControls.UICheckBox()
        Me.tbLocaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAsignarLocaciones = New System.Windows.Forms.Button()
        Me.dgvLocaciones = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpLocacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoLoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarLoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbCentroCostos = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAsignarCentrosCosto = New System.Windows.Forms.Button()
        Me.dgvCentroCosto = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpCentroCostos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoCentro = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarCentro = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbRubroRecurso = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAsignarRubroRecurso = New System.Windows.Forms.Button()
        Me.dgvRubroRecurso = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpRubRecurso = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoRubRecurso = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarRubRecurso = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbEquipoUsuario = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAsignarEquipo = New System.Windows.Forms.Button()
        Me.dgvEquipos = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpEquipos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoEquipo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarEquipo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCodbarra = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtFechaCreacion = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecMod = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbMarcaSoloJob = New Janus.Windows.EditControls.UICheckBox()
        Me.cbAlertas = New Janus.Windows.EditControls.UICheckBox()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtTelefonos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabOpciones.SuspendLayout()
        Me.tbEmpresas.SuspendLayout()
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpEmpresa.SuspendLayout()
        Me.tbSistemas.SuspendLayout()
        CType(Me.dgvSistemas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpSistemas.SuspendLayout()
        Me.tbPermisos.SuspendLayout()
        Me.cmbOpPermisos.SuspendLayout()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFacturacion.SuspendLayout()
        Me.tbLocaciones.SuspendLayout()
        CType(Me.dgvLocaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpLocacion.SuspendLayout()
        Me.tbCentroCostos.SuspendLayout()
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpCentroCostos.SuspendLayout()
        Me.tbRubroRecurso.SuspendLayout()
        CType(Me.dgvRubroRecurso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpRubRecurso.SuspendLayout()
        Me.tbEquipoUsuario.SuspendLayout()
        CType(Me.dgvEquipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpEquipos.SuspendLayout()
        CType(Me.cmbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Colaborador :"
        '
        'cbVigente
        '
        Me.cbVigente.Enabled = False
        Me.cbVigente.Location = New System.Drawing.Point(257, 109)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(67, 15)
        Me.cbVigente.TabIndex = 11
        Me.cbVigente.Text = "Vigente ?"
        Me.cbVigente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.biGuardar, Me.ToolStripSeparator2, Me.biEditar, Me.ToolStripSeparator3, Me.biDeshacer, Me.ToolStripSeparator4, Me.biSalir, Me.ToolStripSeparator5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(849, 25)
        Me.ToolStrip1.TabIndex = 59
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Enabled = False
        Me.biGuardar.Image = CType(resources.GetObject("biGuardar.Image"), System.Drawing.Image)
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(23, 22)
        Me.biGuardar.Text = "ToolStripButton1"
        Me.biGuardar.ToolTipText = "Guardar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(23, 22)
        Me.biEditar.Text = "ToolStripButton1"
        Me.biEditar.ToolTipText = "Modificar Costos"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Enabled = False
        Me.biDeshacer.Image = CType(resources.GetObject("biDeshacer.Image"), System.Drawing.Image)
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(23, 22)
        Me.biDeshacer.Text = "ToolStripButton1"
        Me.biDeshacer.ToolTipText = "Cancelar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(23, 22)
        Me.biSalir.Text = "ToolStripButton1"
        Me.biSalir.ToolTipText = "Salir de la Ventana"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Usuario :"
        '
        'txtColaborador
        '
        Me.txtColaborador.Location = New System.Drawing.Point(90, 48)
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(302, 20)
        Me.txtColaborador.TabIndex = 4
        '
        'txtCodUsu
        '
        Me.txtCodUsu.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodUsu.Location = New System.Drawing.Point(90, 19)
        Me.txtCodUsu.Name = "txtCodUsu"
        Me.txtCodUsu.Size = New System.Drawing.Size(132, 20)
        Me.txtCodUsu.TabIndex = 1
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(288, 19)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(131, 20)
        Me.txtClave.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(242, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 57
        Me.Label15.Text = "Clave :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Fec.Creacion :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(179, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Email :"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(223, 77)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(208, 20)
        Me.txtEmail.TabIndex = 8
        '
        'lblFecModificacion
        '
        Me.lblFecModificacion.AutoSize = True
        Me.lblFecModificacion.Location = New System.Drawing.Point(13, 110)
        Me.lblFecModificacion.Name = "lblFecModificacion"
        Me.lblFecModificacion.Size = New System.Drawing.Size(71, 13)
        Me.lblFecModificacion.TabIndex = 68
        Me.lblFecModificacion.Text = "Fec.Modific. :"
        '
        'cbSeteo
        '
        Me.cbSeteo.Enabled = False
        Me.cbSeteo.Location = New System.Drawing.Point(340, 109)
        Me.cbSeteo.Name = "cbSeteo"
        Me.cbSeteo.Size = New System.Drawing.Size(159, 15)
        Me.cbSeteo.TabIndex = 12
        Me.cbSeteo.Text = "Cambiar Clave en Proximo ?"
        Me.cbSeteo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(611, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "Area :"
        '
        'txtArea
        '
        Me.txtArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtArea.Location = New System.Drawing.Point(652, 48)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(156, 20)
        Me.txtArea.TabIndex = 9
        Me.txtArea.TabStop = False
        '
        'TabOpciones
        '
        Me.TabOpciones.Location = New System.Drawing.Point(9, 173)
        Me.TabOpciones.Name = "TabOpciones"
        Me.TabOpciones.Size = New System.Drawing.Size(822, 365)
        Me.TabOpciones.TabIndex = 73
        Me.TabOpciones.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tbEmpresas, Me.tbSistemas, Me.tbPermisos, Me.tbLocaciones, Me.tbCentroCostos, Me.tbRubroRecurso, Me.tbEquipoUsuario})
        Me.TabOpciones.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003
        '
        'tbEmpresas
        '
        Me.tbEmpresas.Controls.Add(Me.btnAsigEmpresa)
        Me.tbEmpresas.Controls.Add(Me.dgvEmpresas)
        Me.tbEmpresas.Image = CType(resources.GetObject("tbEmpresas.Image"), System.Drawing.Image)
        Me.tbEmpresas.Location = New System.Drawing.Point(1, 23)
        Me.tbEmpresas.Name = "tbEmpresas"
        Me.tbEmpresas.Size = New System.Drawing.Size(820, 341)
        Me.tbEmpresas.TabStop = True
        Me.tbEmpresas.Text = "EMPRESAS"
        '
        'btnAsigEmpresa
        '
        Me.btnAsigEmpresa.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnAsigEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsigEmpresa.Location = New System.Drawing.Point(537, 7)
        Me.btnAsigEmpresa.Name = "btnAsigEmpresa"
        Me.btnAsigEmpresa.Size = New System.Drawing.Size(124, 27)
        Me.btnAsigEmpresa.TabIndex = 54
        Me.btnAsigEmpresa.Text = "Asignar Empresas"
        Me.btnAsigEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsigEmpresa.UseVisualStyleBackColor = True
        '
        'dgvEmpresas
        '
        Me.dgvEmpresas.AllowCardSizing = False
        Me.dgvEmpresas.AllowColumnDrag = False
        Me.dgvEmpresas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvEmpresas.AlternatingColors = True
        Me.dgvEmpresas.ContextMenuStrip = Me.cmbOpEmpresa
        dgvEmpresas_DesignTimeLayout.LayoutString = resources.GetString("dgvEmpresas_DesignTimeLayout.LayoutString")
        Me.dgvEmpresas.DesignTimeLayout = dgvEmpresas_DesignTimeLayout
        Me.dgvEmpresas.EmptyRows = True
        Me.dgvEmpresas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvEmpresas.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvEmpresas.GroupByBoxVisible = False
        Me.dgvEmpresas.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvEmpresas.Location = New System.Drawing.Point(44, 35)
        Me.dgvEmpresas.Name = "dgvEmpresas"
        Me.dgvEmpresas.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvEmpresas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvEmpresas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvEmpresas.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvEmpresas.Size = New System.Drawing.Size(623, 249)
        Me.dgvEmpresas.TabIndex = 53
        Me.dgvEmpresas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOpEmpresa
        '
        Me.cmbOpEmpresa.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnIngresarEmpresa, Me.btnBorrarEmpresa})
        Me.cmbOpEmpresa.Name = "ContextMenuStrip1"
        Me.cmbOpEmpresa.Size = New System.Drawing.Size(118, 48)
        '
        'btnIngresarEmpresa
        '
        Me.btnIngresarEmpresa.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.btnIngresarEmpresa.Name = "btnIngresarEmpresa"
        Me.btnIngresarEmpresa.Size = New System.Drawing.Size(117, 22)
        Me.btnIngresarEmpresa.Text = "Nuevo"
        '
        'btnBorrarEmpresa
        '
        Me.btnBorrarEmpresa.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.btnBorrarEmpresa.Name = "btnBorrarEmpresa"
        Me.btnBorrarEmpresa.Size = New System.Drawing.Size(117, 22)
        Me.btnBorrarEmpresa.Text = "Eliminar"
        '
        'tbSistemas
        '
        Me.tbSistemas.Controls.Add(Me.btnAsignarSistemas)
        Me.tbSistemas.Controls.Add(Me.dgvSistemas)
        Me.tbSistemas.Icon = CType(resources.GetObject("tbSistemas.Icon"), System.Drawing.Icon)
        Me.tbSistemas.Location = New System.Drawing.Point(1, 23)
        Me.tbSistemas.Name = "tbSistemas"
        Me.tbSistemas.Size = New System.Drawing.Size(820, 290)
        Me.tbSistemas.TabStop = True
        Me.tbSistemas.Text = "SISTEMAS"
        '
        'btnAsignarSistemas
        '
        Me.btnAsignarSistemas.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnAsignarSistemas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignarSistemas.Location = New System.Drawing.Point(515, 16)
        Me.btnAsignarSistemas.Name = "btnAsignarSistemas"
        Me.btnAsignarSistemas.Size = New System.Drawing.Size(114, 27)
        Me.btnAsignarSistemas.TabIndex = 51
        Me.btnAsignarSistemas.Text = "Asignar Sistemas"
        Me.btnAsignarSistemas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignarSistemas.UseVisualStyleBackColor = True
        '
        'dgvSistemas
        '
        Me.dgvSistemas.AllowCardSizing = False
        Me.dgvSistemas.AllowColumnDrag = False
        Me.dgvSistemas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvSistemas.AlternatingColors = True
        Me.dgvSistemas.ContextMenuStrip = Me.cmbOpSistemas
        dgvSistemas_DesignTimeLayout.LayoutString = resources.GetString("dgvSistemas_DesignTimeLayout.LayoutString")
        Me.dgvSistemas.DesignTimeLayout = dgvSistemas_DesignTimeLayout
        Me.dgvSistemas.EmptyRows = True
        Me.dgvSistemas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSistemas.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvSistemas.GroupByBoxVisible = False
        Me.dgvSistemas.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvSistemas.Location = New System.Drawing.Point(27, 25)
        Me.dgvSistemas.Name = "dgvSistemas"
        Me.dgvSistemas.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvSistemas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvSistemas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvSistemas.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvSistemas.Size = New System.Drawing.Size(467, 249)
        Me.dgvSistemas.TabIndex = 50
        Me.dgvSistemas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOpSistemas
        '
        Me.cmbOpSistemas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoSis, Me.miEliminarSis})
        Me.cmbOpSistemas.Name = "ContextMenuStrip1"
        Me.cmbOpSistemas.Size = New System.Drawing.Size(118, 48)
        '
        'miNuevoSis
        '
        Me.miNuevoSis.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoSis.Name = "miNuevoSis"
        Me.miNuevoSis.Size = New System.Drawing.Size(117, 22)
        Me.miNuevoSis.Text = "Nuevo"
        '
        'miEliminarSis
        '
        Me.miEliminarSis.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarSis.Name = "miEliminarSis"
        Me.miEliminarSis.Size = New System.Drawing.Size(117, 22)
        Me.miEliminarSis.Text = "Eliminar"
        '
        'tbPermisos
        '
        Me.tbPermisos.ContextMenuStrip = Me.cmbOpPermisos
        Me.tbPermisos.Controls.Add(Me.ckLibreLicencia)
        Me.tbPermisos.Controls.Add(Me.ckAprobacionUnica)
        Me.tbPermisos.Controls.Add(Me.ckExportarDatos)
        Me.tbPermisos.Controls.Add(Me.ckVerPrecios)
        Me.tbPermisos.Controls.Add(Me.ckVendeOficina)
        Me.tbPermisos.Controls.Add(Me.ckGastoGerencia)
        Me.tbPermisos.Controls.Add(Me.ckPrecioFlete)
        Me.tbPermisos.Controls.Add(Me.ckVerGastos)
        Me.tbPermisos.Controls.Add(Me.txtPerfil)
        Me.tbPermisos.Controls.Add(Me.gbFacturacion)
        Me.tbPermisos.Controls.Add(Me.ckPerPrecioFOB)
        Me.tbPermisos.Controls.Add(Me.ckPerPrecio)
        Me.tbPermisos.Controls.Add(Me.ckCartera)
        Me.tbPermisos.Controls.Add(Me.Label7)
        Me.tbPermisos.Controls.Add(Me.ckTipCam)
        Me.tbPermisos.Icon = CType(resources.GetObject("tbPermisos.Icon"), System.Drawing.Icon)
        Me.tbPermisos.Location = New System.Drawing.Point(1, 23)
        Me.tbPermisos.Name = "tbPermisos"
        Me.tbPermisos.Size = New System.Drawing.Size(820, 290)
        Me.tbPermisos.TabStop = True
        Me.tbPermisos.Text = "PERMISOS"
        '
        'cmbOpPermisos
        '
        Me.cmbOpPermisos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoPer, Me.miMostrarPer})
        Me.cmbOpPermisos.Name = "ContextMenuStrip1"
        Me.cmbOpPermisos.Size = New System.Drawing.Size(116, 48)
        '
        'miNuevoPer
        '
        Me.miNuevoPer.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoPer.Name = "miNuevoPer"
        Me.miNuevoPer.Size = New System.Drawing.Size(115, 22)
        Me.miNuevoPer.Text = "Nuevo"
        '
        'miMostrarPer
        '
        Me.miMostrarPer.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarPer.Name = "miMostrarPer"
        Me.miMostrarPer.Size = New System.Drawing.Size(115, 22)
        Me.miMostrarPer.Text = "Mostrar"
        '
        'ckLibreLicencia
        '
        Me.ckLibreLicencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckLibreLicencia.Enabled = False
        Me.ckLibreLicencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckLibreLicencia.Location = New System.Drawing.Point(376, 209)
        Me.ckLibreLicencia.Name = "ckLibreLicencia"
        Me.ckLibreLicencia.Size = New System.Drawing.Size(172, 16)
        Me.ckLibreLicencia.TabIndex = 19
        Me.ckLibreLicencia.Text = "Libre Licencia de Equipos"
        Me.ckLibreLicencia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckAprobacionUnica
        '
        Me.ckAprobacionUnica.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckAprobacionUnica.Enabled = False
        Me.ckAprobacionUnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckAprobacionUnica.Location = New System.Drawing.Point(120, 223)
        Me.ckAprobacionUnica.Name = "ckAprobacionUnica"
        Me.ckAprobacionUnica.Size = New System.Drawing.Size(204, 16)
        Me.ckAprobacionUnica.TabIndex = 18
        Me.ckAprobacionUnica.Text = "Aprobación Unica para Compras"
        Me.ckAprobacionUnica.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckExportarDatos
        '
        Me.ckExportarDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckExportarDatos.Enabled = False
        Me.ckExportarDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckExportarDatos.Location = New System.Drawing.Point(120, 199)
        Me.ckExportarDatos.Name = "ckExportarDatos"
        Me.ckExportarDatos.Size = New System.Drawing.Size(148, 16)
        Me.ckExportarDatos.TabIndex = 17
        Me.ckExportarDatos.Text = "Puede Exportar Datos"
        Me.ckExportarDatos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckVerPrecios
        '
        Me.ckVerPrecios.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckVerPrecios.Enabled = False
        Me.ckVerPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerPrecios.Location = New System.Drawing.Point(376, 163)
        Me.ckVerPrecios.Name = "ckVerPrecios"
        Me.ckVerPrecios.Size = New System.Drawing.Size(87, 16)
        Me.ckVerPrecios.TabIndex = 16
        Me.ckVerPrecios.Text = "Ver Precios"
        Me.ckVerPrecios.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckVendeOficina
        '
        Me.ckVendeOficina.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckVendeOficina.Enabled = False
        Me.ckVendeOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVendeOficina.Location = New System.Drawing.Point(120, 175)
        Me.ckVendeOficina.Name = "ckVendeOficina"
        Me.ckVendeOficina.Size = New System.Drawing.Size(127, 16)
        Me.ckVendeOficina.TabIndex = 15
        Me.ckVendeOficina.Text = "Venta Solo Oficina"
        Me.ckVendeOficina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckGastoGerencia
        '
        Me.ckGastoGerencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckGastoGerencia.Enabled = False
        Me.ckGastoGerencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckGastoGerencia.Location = New System.Drawing.Point(120, 151)
        Me.ckGastoGerencia.Name = "ckGastoGerencia"
        Me.ckGastoGerencia.Size = New System.Drawing.Size(161, 16)
        Me.ckGastoGerencia.TabIndex = 14
        Me.ckGastoGerencia.Text = "Procesa Gasto Gerencia"
        Me.ckGastoGerencia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckPrecioFlete
        '
        Me.ckPrecioFlete.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckPrecioFlete.Enabled = False
        Me.ckPrecioFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPrecioFlete.Location = New System.Drawing.Point(120, 127)
        Me.ckPrecioFlete.Name = "ckPrecioFlete"
        Me.ckPrecioFlete.Size = New System.Drawing.Size(139, 16)
        Me.ckPrecioFlete.TabIndex = 13
        Me.ckPrecioFlete.Text = "Ingresa Precio Flete"
        Me.ckPrecioFlete.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckVerGastos
        '
        Me.ckVerGastos.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckVerGastos.Enabled = False
        Me.ckVerGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerGastos.Location = New System.Drawing.Point(376, 187)
        Me.ckVerGastos.Name = "ckVerGastos"
        Me.ckVerGastos.Size = New System.Drawing.Size(87, 16)
        Me.ckVerGastos.TabIndex = 12
        Me.ckVerGastos.Text = "Ver Gastos"
        Me.ckVerGastos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtPerfil
        '
        Me.txtPerfil.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtPerfil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPerfil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPerfil.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtPerfil.Location = New System.Drawing.Point(178, 9)
        Me.txtPerfil.Name = "txtPerfil"
        Me.txtPerfil.Size = New System.Drawing.Size(350, 20)
        Me.txtPerfil.TabIndex = 11
        '
        'gbFacturacion
        '
        Me.gbFacturacion.BackColor = System.Drawing.Color.Transparent
        Me.gbFacturacion.Controls.Add(Me.rbTipFacTodos)
        Me.gbFacturacion.Controls.Add(Me.rbTipFacCon)
        Me.gbFacturacion.Controls.Add(Me.rbTipFacCre)
        Me.gbFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFacturacion.Location = New System.Drawing.Point(356, 46)
        Me.gbFacturacion.Name = "gbFacturacion"
        Me.gbFacturacion.Size = New System.Drawing.Size(172, 105)
        Me.gbFacturacion.TabIndex = 9
        Me.gbFacturacion.Text = "Tipo de Facturación"
        Me.gbFacturacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTipFacTodos
        '
        Me.rbTipFacTodos.AutoSize = True
        Me.rbTipFacTodos.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.rbTipFacTodos.Enabled = False
        Me.rbTipFacTodos.Location = New System.Drawing.Point(20, 22)
        Me.rbTipFacTodos.Name = "rbTipFacTodos"
        Me.rbTipFacTodos.Size = New System.Drawing.Size(60, 17)
        Me.rbTipFacTodos.TabIndex = 2
        Me.rbTipFacTodos.TabStop = True
        Me.rbTipFacTodos.Text = "Todos"
        Me.rbTipFacTodos.UseVisualStyleBackColor = False
        '
        'rbTipFacCon
        '
        Me.rbTipFacCon.AutoSize = True
        Me.rbTipFacCon.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.rbTipFacCon.Enabled = False
        Me.rbTipFacCon.Location = New System.Drawing.Point(20, 76)
        Me.rbTipFacCon.Name = "rbTipFacCon"
        Me.rbTipFacCon.Size = New System.Drawing.Size(133, 17)
        Me.rbTipFacCon.TabIndex = 1
        Me.rbTipFacCon.TabStop = True
        Me.rbTipFacCon.Text = "Factura al Contado"
        Me.rbTipFacCon.UseVisualStyleBackColor = False
        '
        'rbTipFacCre
        '
        Me.rbTipFacCre.AutoSize = True
        Me.rbTipFacCre.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.rbTipFacCre.Enabled = False
        Me.rbTipFacCre.Location = New System.Drawing.Point(20, 49)
        Me.rbTipFacCre.Name = "rbTipFacCre"
        Me.rbTipFacCre.Size = New System.Drawing.Size(126, 17)
        Me.rbTipFacCre.TabIndex = 0
        Me.rbTipFacCre.TabStop = True
        Me.rbTipFacCre.Text = "Factura al Crédito"
        Me.rbTipFacCre.UseVisualStyleBackColor = False
        '
        'ckPerPrecioFOB
        '
        Me.ckPerPrecioFOB.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckPerPrecioFOB.Enabled = False
        Me.ckPerPrecioFOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPerPrecioFOB.Location = New System.Drawing.Point(120, 103)
        Me.ckPerPrecioFOB.Name = "ckPerPrecioFOB"
        Me.ckPerPrecioFOB.Size = New System.Drawing.Size(193, 16)
        Me.ckPerPrecioFOB.TabIndex = 8
        Me.ckPerPrecioFOB.Text = "Puede Modificar Precio FOB?"
        Me.ckPerPrecioFOB.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckPerPrecio
        '
        Me.ckPerPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckPerPrecio.Enabled = False
        Me.ckPerPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPerPrecio.Location = New System.Drawing.Point(120, 80)
        Me.ckPerPrecio.Name = "ckPerPrecio"
        Me.ckPerPrecio.Size = New System.Drawing.Size(170, 15)
        Me.ckPerPrecio.TabIndex = 7
        Me.ckPerPrecio.Text = "Puede Modificar Precios?"
        Me.ckPerPrecio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckCartera
        '
        Me.ckCartera.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckCartera.Enabled = False
        Me.ckCartera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCartera.Location = New System.Drawing.Point(120, 57)
        Me.ckCartera.Name = "ckCartera"
        Me.ckCartera.Size = New System.Drawing.Size(107, 15)
        Me.ckCartera.TabIndex = 3
        Me.ckCartera.Text = "Tiene Cartera?"
        Me.ckCartera.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(117, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "PERFIL :"
        '
        'ckTipCam
        '
        Me.ckTipCam.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckTipCam.Enabled = False
        Me.ckTipCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckTipCam.Location = New System.Drawing.Point(120, 34)
        Me.ckTipCam.Name = "ckTipCam"
        Me.ckTipCam.Size = New System.Drawing.Size(170, 15)
        Me.ckTipCam.TabIndex = 0
        Me.ckTipCam.Text = "Ingresa Tipo de Cambio ?"
        Me.ckTipCam.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'tbLocaciones
        '
        Me.tbLocaciones.Controls.Add(Me.btnAsignarLocaciones)
        Me.tbLocaciones.Controls.Add(Me.dgvLocaciones)
        Me.tbLocaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLocaciones.Icon = CType(resources.GetObject("tbLocaciones.Icon"), System.Drawing.Icon)
        Me.tbLocaciones.Location = New System.Drawing.Point(1, 23)
        Me.tbLocaciones.Name = "tbLocaciones"
        Me.tbLocaciones.Size = New System.Drawing.Size(820, 290)
        Me.tbLocaciones.TabStop = True
        Me.tbLocaciones.Text = "LOCACIONES"
        '
        'btnAsignarLocaciones
        '
        Me.btnAsignarLocaciones.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnAsignarLocaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignarLocaciones.Location = New System.Drawing.Point(537, 3)
        Me.btnAsignarLocaciones.Name = "btnAsignarLocaciones"
        Me.btnAsignarLocaciones.Size = New System.Drawing.Size(124, 27)
        Me.btnAsignarLocaciones.TabIndex = 52
        Me.btnAsignarLocaciones.Text = "Asignar Locaciones"
        Me.btnAsignarLocaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignarLocaciones.UseVisualStyleBackColor = True
        '
        'dgvLocaciones
        '
        Me.dgvLocaciones.AllowCardSizing = False
        Me.dgvLocaciones.AllowColumnDrag = False
        Me.dgvLocaciones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvLocaciones.AlternatingColors = True
        Me.dgvLocaciones.ContextMenuStrip = Me.cmbOpLocacion
        dgvLocaciones_DesignTimeLayout.LayoutString = resources.GetString("dgvLocaciones_DesignTimeLayout.LayoutString")
        Me.dgvLocaciones.DesignTimeLayout = dgvLocaciones_DesignTimeLayout
        Me.dgvLocaciones.EmptyRows = True
        Me.dgvLocaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvLocaciones.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvLocaciones.GroupByBoxVisible = False
        Me.dgvLocaciones.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvLocaciones.Location = New System.Drawing.Point(11, 34)
        Me.dgvLocaciones.Name = "dgvLocaciones"
        Me.dgvLocaciones.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvLocaciones.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvLocaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvLocaciones.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvLocaciones.Size = New System.Drawing.Size(649, 250)
        Me.dgvLocaciones.TabIndex = 51
        Me.dgvLocaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOpLocacion
        '
        Me.cmbOpLocacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoLoc, Me.miEliminarLoc})
        Me.cmbOpLocacion.Name = "ContextMenuStrip1"
        Me.cmbOpLocacion.Size = New System.Drawing.Size(118, 48)
        '
        'miNuevoLoc
        '
        Me.miNuevoLoc.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoLoc.Name = "miNuevoLoc"
        Me.miNuevoLoc.Size = New System.Drawing.Size(117, 22)
        Me.miNuevoLoc.Text = "Nuevo"
        '
        'miEliminarLoc
        '
        Me.miEliminarLoc.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarLoc.Name = "miEliminarLoc"
        Me.miEliminarLoc.Size = New System.Drawing.Size(117, 22)
        Me.miEliminarLoc.Text = "Eliminar"
        '
        'tbCentroCostos
        '
        Me.tbCentroCostos.Controls.Add(Me.btnAsignarCentrosCosto)
        Me.tbCentroCostos.Controls.Add(Me.dgvCentroCosto)
        Me.tbCentroCostos.Icon = CType(resources.GetObject("tbCentroCostos.Icon"), System.Drawing.Icon)
        Me.tbCentroCostos.Location = New System.Drawing.Point(1, 23)
        Me.tbCentroCostos.Name = "tbCentroCostos"
        Me.tbCentroCostos.Size = New System.Drawing.Size(820, 290)
        Me.tbCentroCostos.TabStop = True
        Me.tbCentroCostos.Text = "CENTRO COSTOS"
        '
        'btnAsignarCentrosCosto
        '
        Me.btnAsignarCentrosCosto.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnAsignarCentrosCosto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignarCentrosCosto.Location = New System.Drawing.Point(515, 4)
        Me.btnAsignarCentrosCosto.Name = "btnAsignarCentrosCosto"
        Me.btnAsignarCentrosCosto.Size = New System.Drawing.Size(150, 27)
        Me.btnAsignarCentrosCosto.TabIndex = 52
        Me.btnAsignarCentrosCosto.Text = "Asignar Centros de Costo"
        Me.btnAsignarCentrosCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignarCentrosCosto.UseVisualStyleBackColor = True
        '
        'dgvCentroCosto
        '
        Me.dgvCentroCosto.AllowCardSizing = False
        Me.dgvCentroCosto.AllowColumnDrag = False
        Me.dgvCentroCosto.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvCentroCosto.AlternatingColors = True
        Me.dgvCentroCosto.ContextMenuStrip = Me.cmbOpCentroCostos
        dgvCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("dgvCentroCosto_DesignTimeLayout.LayoutString")
        Me.dgvCentroCosto.DesignTimeLayout = dgvCentroCosto_DesignTimeLayout
        Me.dgvCentroCosto.EmptyRows = True
        Me.dgvCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCentroCosto.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvCentroCosto.GroupByBoxVisible = False
        Me.dgvCentroCosto.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvCentroCosto.Location = New System.Drawing.Point(4, 34)
        Me.dgvCentroCosto.Name = "dgvCentroCosto"
        Me.dgvCentroCosto.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCentroCosto.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCentroCosto.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCentroCosto.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCentroCosto.Size = New System.Drawing.Size(660, 249)
        Me.dgvCentroCosto.TabIndex = 51
        Me.dgvCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOpCentroCostos
        '
        Me.cmbOpCentroCostos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoCentro, Me.miEliminarCentro})
        Me.cmbOpCentroCostos.Name = "ContextMenuStrip1"
        Me.cmbOpCentroCostos.Size = New System.Drawing.Size(118, 48)
        '
        'miNuevoCentro
        '
        Me.miNuevoCentro.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoCentro.Name = "miNuevoCentro"
        Me.miNuevoCentro.Size = New System.Drawing.Size(117, 22)
        Me.miNuevoCentro.Text = "Nuevo"
        '
        'miEliminarCentro
        '
        Me.miEliminarCentro.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarCentro.Name = "miEliminarCentro"
        Me.miEliminarCentro.Size = New System.Drawing.Size(117, 22)
        Me.miEliminarCentro.Text = "Eliminar"
        '
        'tbRubroRecurso
        '
        Me.tbRubroRecurso.Controls.Add(Me.btnAsignarRubroRecurso)
        Me.tbRubroRecurso.Controls.Add(Me.dgvRubroRecurso)
        Me.tbRubroRecurso.Icon = CType(resources.GetObject("tbRubroRecurso.Icon"), System.Drawing.Icon)
        Me.tbRubroRecurso.Location = New System.Drawing.Point(1, 23)
        Me.tbRubroRecurso.Name = "tbRubroRecurso"
        Me.tbRubroRecurso.Size = New System.Drawing.Size(820, 290)
        Me.tbRubroRecurso.TabStop = True
        Me.tbRubroRecurso.Text = "RUBRO RECURSO"
        '
        'btnAsignarRubroRecurso
        '
        Me.btnAsignarRubroRecurso.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnAsignarRubroRecurso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignarRubroRecurso.Location = New System.Drawing.Point(476, 16)
        Me.btnAsignarRubroRecurso.Name = "btnAsignarRubroRecurso"
        Me.btnAsignarRubroRecurso.Size = New System.Drawing.Size(146, 27)
        Me.btnAsignarRubroRecurso.TabIndex = 53
        Me.btnAsignarRubroRecurso.Text = "Asignar Rubros Recurso"
        Me.btnAsignarRubroRecurso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignarRubroRecurso.UseVisualStyleBackColor = True
        '
        'dgvRubroRecurso
        '
        Me.dgvRubroRecurso.AllowCardSizing = False
        Me.dgvRubroRecurso.AllowColumnDrag = False
        Me.dgvRubroRecurso.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvRubroRecurso.AlternatingColors = True
        Me.dgvRubroRecurso.ContextMenuStrip = Me.cmbOpRubRecurso
        dgvRubroRecurso_DesignTimeLayout.LayoutString = resources.GetString("dgvRubroRecurso_DesignTimeLayout.LayoutString")
        Me.dgvRubroRecurso.DesignTimeLayout = dgvRubroRecurso_DesignTimeLayout
        Me.dgvRubroRecurso.EmptyRows = True
        Me.dgvRubroRecurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvRubroRecurso.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvRubroRecurso.GroupByBoxVisible = False
        Me.dgvRubroRecurso.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvRubroRecurso.Location = New System.Drawing.Point(98, 25)
        Me.dgvRubroRecurso.Name = "dgvRubroRecurso"
        Me.dgvRubroRecurso.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvRubroRecurso.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvRubroRecurso.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvRubroRecurso.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvRubroRecurso.Size = New System.Drawing.Size(334, 179)
        Me.dgvRubroRecurso.TabIndex = 52
        Me.dgvRubroRecurso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOpRubRecurso
        '
        Me.cmbOpRubRecurso.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoRubRecurso, Me.miEliminarRubRecurso})
        Me.cmbOpRubRecurso.Name = "ContextMenuStrip1"
        Me.cmbOpRubRecurso.Size = New System.Drawing.Size(118, 48)
        '
        'miNuevoRubRecurso
        '
        Me.miNuevoRubRecurso.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoRubRecurso.Name = "miNuevoRubRecurso"
        Me.miNuevoRubRecurso.Size = New System.Drawing.Size(117, 22)
        Me.miNuevoRubRecurso.Text = "Nuevo"
        '
        'miEliminarRubRecurso
        '
        Me.miEliminarRubRecurso.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarRubRecurso.Name = "miEliminarRubRecurso"
        Me.miEliminarRubRecurso.Size = New System.Drawing.Size(117, 22)
        Me.miEliminarRubRecurso.Text = "Eliminar"
        '
        'tbEquipoUsuario
        '
        Me.tbEquipoUsuario.Controls.Add(Me.btnAsignarEquipo)
        Me.tbEquipoUsuario.Controls.Add(Me.dgvEquipos)
        Me.tbEquipoUsuario.Icon = CType(resources.GetObject("tbEquipoUsuario.Icon"), System.Drawing.Icon)
        Me.tbEquipoUsuario.Location = New System.Drawing.Point(1, 23)
        Me.tbEquipoUsuario.Name = "tbEquipoUsuario"
        Me.tbEquipoUsuario.Size = New System.Drawing.Size(820, 290)
        Me.tbEquipoUsuario.TabStop = True
        Me.tbEquipoUsuario.Text = "Equipos"
        '
        'btnAsignarEquipo
        '
        Me.btnAsignarEquipo.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnAsignarEquipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignarEquipo.Location = New System.Drawing.Point(704, 15)
        Me.btnAsignarEquipo.Name = "btnAsignarEquipo"
        Me.btnAsignarEquipo.Size = New System.Drawing.Size(105, 27)
        Me.btnAsignarEquipo.TabIndex = 56
        Me.btnAsignarEquipo.Text = "Asignar Equipo"
        Me.btnAsignarEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignarEquipo.UseVisualStyleBackColor = True
        '
        'dgvEquipos
        '
        Me.dgvEquipos.AllowCardSizing = False
        Me.dgvEquipos.AllowColumnDrag = False
        Me.dgvEquipos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvEquipos.AlternatingColors = True
        Me.dgvEquipos.ContextMenuStrip = Me.cmbOpEquipos
        dgvEquipos_DesignTimeLayout.LayoutString = resources.GetString("dgvEquipos_DesignTimeLayout.LayoutString")
        Me.dgvEquipos.DesignTimeLayout = dgvEquipos_DesignTimeLayout
        Me.dgvEquipos.EmptyRows = True
        Me.dgvEquipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvEquipos.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvEquipos.GroupByBoxVisible = False
        Me.dgvEquipos.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvEquipos.Location = New System.Drawing.Point(10, 47)
        Me.dgvEquipos.Name = "dgvEquipos"
        Me.dgvEquipos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvEquipos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvEquipos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvEquipos.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvEquipos.Size = New System.Drawing.Size(802, 211)
        Me.dgvEquipos.TabIndex = 55
        Me.dgvEquipos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOpEquipos
        '
        Me.cmbOpEquipos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoEquipo, Me.miEliminarEquipo})
        Me.cmbOpEquipos.Name = "ContextMenuStrip1"
        Me.cmbOpEquipos.Size = New System.Drawing.Size(118, 48)
        '
        'miNuevoEquipo
        '
        Me.miNuevoEquipo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoEquipo.Name = "miNuevoEquipo"
        Me.miNuevoEquipo.Size = New System.Drawing.Size(117, 22)
        Me.miNuevoEquipo.Text = "Nuevo"
        '
        'miEliminarEquipo
        '
        Me.miEliminarEquipo.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarEquipo.Name = "miEliminarEquipo"
        Me.miEliminarEquipo.Size = New System.Drawing.Size(117, 22)
        Me.miEliminarEquipo.Text = "Eliminar"
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Enabled = False
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(394, 46)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersona.TabIndex = 5
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(446, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Cod. Barra :"
        '
        'txtCodbarra
        '
        Me.txtCodbarra.Location = New System.Drawing.Point(515, 19)
        Me.txtCodbarra.Name = "txtCodbarra"
        Me.txtCodbarra.Size = New System.Drawing.Size(127, 20)
        Me.txtCodbarra.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(426, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 116
        Me.Label9.Text = "Oficina :"
        '
        'cmbOficina
        '
        Me.cmbOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficina_DesignTimeLayout.LayoutString = resources.GetString("cmbOficina_DesignTimeLayout.LayoutString")
        Me.cmbOficina.DesignTimeLayout = cmbOficina_DesignTimeLayout
        Me.cmbOficina.Location = New System.Drawing.Point(478, 48)
        Me.cmbOficina.Name = "cmbOficina"
        Me.cmbOficina.SelectedIndex = -1
        Me.cmbOficina.SelectedItem = Nothing
        Me.cmbOficina.Size = New System.Drawing.Size(127, 20)
        Me.cmbOficina.TabIndex = 6
        Me.cmbOficina.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtFechaCreacion
        '
        Me.txtFechaCreacion.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFechaCreacion.DropDownCalendar.Name = ""
        Me.txtFechaCreacion.DropDownCalendar.Visible = False
        Me.txtFechaCreacion.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaCreacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaCreacion.Location = New System.Drawing.Point(90, 77)
        Me.txtFechaCreacion.Name = "txtFechaCreacion"
        Me.txtFechaCreacion.NullButtonText = "Ninguno"
        Me.txtFechaCreacion.ReadOnly = True
        Me.txtFechaCreacion.Size = New System.Drawing.Size(82, 20)
        Me.txtFechaCreacion.TabIndex = 7
        Me.txtFechaCreacion.TabStop = False
        Me.txtFechaCreacion.TodayButtonText = "Hoy"
        Me.txtFechaCreacion.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecMod
        '
        Me.txtFecMod.BackColor = System.Drawing.SystemColors.Control
        Me.txtFecMod.DateFormat = Janus.Windows.CalendarCombo.DateFormat.DateTime
        '
        '
        '
        Me.txtFecMod.DropDownCalendar.Name = ""
        Me.txtFecMod.DropDownCalendar.Visible = False
        Me.txtFecMod.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecMod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecMod.Location = New System.Drawing.Point(90, 106)
        Me.txtFecMod.Name = "txtFecMod"
        Me.txtFecMod.NullButtonText = "Ninguno"
        Me.txtFecMod.ReadOnly = True
        Me.txtFecMod.Size = New System.Drawing.Size(158, 20)
        Me.txtFecMod.TabIndex = 10
        Me.txtFecMod.TabStop = False
        Me.txtFecMod.TodayButtonText = "Hoy"
        Me.txtFecMod.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtTelefonos)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.cbMarcaSoloJob)
        Me.UiGroupBox1.Controls.Add(Me.cbAlertas)
        Me.UiGroupBox1.Controls.Add(Me.txtCodUsu)
        Me.UiGroupBox1.Controls.Add(Me.txtFecMod)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.txtClave)
        Me.UiGroupBox1.Controls.Add(Me.cmbOficina)
        Me.UiGroupBox1.Controls.Add(Me.txtColaborador)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaCreacion)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.cbVigente)
        Me.UiGroupBox1.Controls.Add(Me.txtCodbarra)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPersona)
        Me.UiGroupBox1.Controls.Add(Me.txtEmail)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.lblFecModificacion)
        Me.UiGroupBox1.Controls.Add(Me.txtArea)
        Me.UiGroupBox1.Controls.Add(Me.cbSeteo)
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 28)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(822, 137)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Datos de Usuario"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cbMarcaSoloJob
        '
        Me.cbMarcaSoloJob.Enabled = False
        Me.cbMarcaSoloJob.Location = New System.Drawing.Point(590, 109)
        Me.cbMarcaSoloJob.Name = "cbMarcaSoloJob"
        Me.cbMarcaSoloJob.Size = New System.Drawing.Size(110, 15)
        Me.cbMarcaSoloJob.TabIndex = 118
        Me.cbMarcaSoloJob.Text = "Marca Solo Job ?"
        Me.cbMarcaSoloJob.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbAlertas
        '
        Me.cbAlertas.Enabled = False
        Me.cbAlertas.Location = New System.Drawing.Point(512, 109)
        Me.cbAlertas.Name = "cbAlertas"
        Me.cbAlertas.Size = New System.Drawing.Size(67, 15)
        Me.cbAlertas.TabIndex = 117
        Me.cbAlertas.Text = "Alertas ?"
        Me.cbAlertas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 597)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(849, 20)
        Me.ssBarra.TabIndex = 193
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(450, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTelefonos
        '
        Me.txtTelefonos.Location = New System.Drawing.Point(502, 77)
        Me.txtTelefonos.Name = "txtTelefonos"
        Me.txtTelefonos.Size = New System.Drawing.Size(307, 20)
        Me.txtTelefonos.TabIndex = 119
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(437, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "Telefonos :"
        '
        'frmUsuario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(849, 617)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabOpciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mantenimiento de Usuarios"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabOpciones.ResumeLayout(False)
        Me.tbEmpresas.ResumeLayout(False)
        CType(Me.dgvEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpEmpresa.ResumeLayout(False)
        Me.tbSistemas.ResumeLayout(False)
        CType(Me.dgvSistemas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpSistemas.ResumeLayout(False)
        Me.tbPermisos.ResumeLayout(False)
        Me.tbPermisos.PerformLayout()
        Me.cmbOpPermisos.ResumeLayout(False)
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFacturacion.ResumeLayout(False)
        Me.gbFacturacion.PerformLayout()
        Me.tbLocaciones.ResumeLayout(False)
        CType(Me.dgvLocaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpLocacion.ResumeLayout(False)
        Me.tbCentroCostos.ResumeLayout(False)
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpCentroCostos.ResumeLayout(False)
        Me.tbRubroRecurso.ResumeLayout(False)
        CType(Me.dgvRubroRecurso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpRubRecurso.ResumeLayout(False)
        Me.tbEquipoUsuario.ResumeLayout(False)
        CType(Me.dgvEquipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpEquipos.ResumeLayout(False)
        CType(Me.cmbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbVigente As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents txtCodUsu As System.Windows.Forms.TextBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cbSeteo As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents lblFecModificacion As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents TabOpciones As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tbSistemas As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tbLocaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tbPermisos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvSistemas As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgvLocaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents ckTipCam As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ckCartera As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents rbTipFacCon As System.Windows.Forms.RadioButton
    Friend WithEvents rbTipFacCre As System.Windows.Forms.RadioButton
    Friend WithEvents ckPerPrecio As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents btnAsignarSistemas As System.Windows.Forms.Button
    Friend WithEvents btnAsignarLocaciones As System.Windows.Forms.Button
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCodbarra As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ckPerPrecioFOB As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents tbCentroCostos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tbRubroRecurso As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents gbFacturacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTipFacTodos As System.Windows.Forms.RadioButton
    Friend WithEvents txtPerfil As System.Windows.Forms.TextBox
    Friend WithEvents ckVerGastos As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents txtFechaCreacion As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecMod As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbOpSistemas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoSis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarSis As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbOpLocacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoLoc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarLoc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbOpPermisos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoPer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarPer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvCentroCosto As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgvRubroRecurso As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbOpCentroCostos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoCentro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarCentro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbOpRubRecurso As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoRubRecurso As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarRubRecurso As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAsignarCentrosCosto As System.Windows.Forms.Button
    Friend WithEvents btnAsignarRubroRecurso As System.Windows.Forms.Button
    Friend WithEvents ckGastoGerencia As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckPrecioFlete As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckVerPrecios As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckVendeOficina As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cbAlertas As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents tbEmpresas As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents btnAsigEmpresa As Button
    Friend WithEvents dgvEmpresas As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbOpEmpresa As ContextMenuStrip
    Friend WithEvents btnIngresarEmpresa As ToolStripMenuItem
    Friend WithEvents btnBorrarEmpresa As ToolStripMenuItem
    Friend WithEvents ckExportarDatos As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckAprobacionUnica As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents tbEquipoUsuario As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents btnAsignarEquipo As Button
    Friend WithEvents dgvEquipos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbOpEquipos As ContextMenuStrip
    Friend WithEvents miNuevoEquipo As ToolStripMenuItem
    Friend WithEvents miEliminarEquipo As ToolStripMenuItem
    Friend WithEvents cbMarcaSoloJob As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckLibreLicencia As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents txtTelefonos As TextBox
    Friend WithEvents Label5 As Label
End Class
