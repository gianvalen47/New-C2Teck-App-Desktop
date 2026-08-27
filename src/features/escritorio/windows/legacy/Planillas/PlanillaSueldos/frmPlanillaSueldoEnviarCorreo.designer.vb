<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillaSueldoEnviarCorreo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillaSueldoEnviarCorreo))
        Dim dgvArchivosDirectorio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.gbProcesoJob = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCopia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPara = New System.Windows.Forms.TextBox()
        Me.btnVerPublicidad = New Janus.Windows.EditControls.UIButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.biLimpiar = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarPublicidad = New System.Windows.Forms.Button()
        Me.txtPublicidad = New System.Windows.Forms.TextBox()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Nombre1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tamano1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Direccion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMensaje2 = New System.Windows.Forms.RichTextBox()
        Me.cbVineta = New System.Windows.Forms.CheckBox()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biColorFuente = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biFuente = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biVinetas = New System.Windows.Forms.ToolStripButton()
        Me.biNegrita = New System.Windows.Forms.ToolStripButton()
        Me.biSubrayado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnEnviarCorreo = New System.Windows.Forms.Button()
        Me.dgvArchivosDirectorio = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miVer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtDe = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProcesoJob.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgvArchivosDirectorio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbProcesoJob
        '
        Me.gbProcesoJob.Controls.Add(Me.txtCopia)
        Me.gbProcesoJob.Controls.Add(Me.Label7)
        Me.gbProcesoJob.Controls.Add(Me.txtPara)
        Me.gbProcesoJob.Controls.Add(Me.btnVerPublicidad)
        Me.gbProcesoJob.Controls.Add(Me.Label5)
        Me.gbProcesoJob.Controls.Add(Me.biLimpiar)
        Me.gbProcesoJob.Controls.Add(Me.btnBuscarPublicidad)
        Me.gbProcesoJob.Controls.Add(Me.txtPublicidad)
        Me.gbProcesoJob.Controls.Add(Me.txtMensaje)
        Me.gbProcesoJob.Controls.Add(Me.DataGridView1)
        Me.gbProcesoJob.Controls.Add(Me.Label1)
        Me.gbProcesoJob.Controls.Add(Me.UiGroupBox2)
        Me.gbProcesoJob.Controls.Add(Me.Panel1)
        Me.gbProcesoJob.Controls.Add(Me.UiGroupBox1)
        Me.gbProcesoJob.Controls.Add(Me.dgvArchivosDirectorio)
        Me.gbProcesoJob.Controls.Add(Me.txtDe)
        Me.gbProcesoJob.Controls.Add(Me.Label6)
        Me.gbProcesoJob.Controls.Add(Me.txtAsunto)
        Me.gbProcesoJob.Controls.Add(Me.Label4)
        Me.gbProcesoJob.Controls.Add(Me.Label2)
        Me.gbProcesoJob.Controls.Add(Me.Label3)
        Me.gbProcesoJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProcesoJob.Location = New System.Drawing.Point(12, 12)
        Me.gbProcesoJob.Name = "gbProcesoJob"
        Me.gbProcesoJob.Size = New System.Drawing.Size(663, 435)
        Me.gbProcesoJob.TabIndex = 113
        Me.gbProcesoJob.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCopia
        '
        Me.txtCopia.BackColor = System.Drawing.SystemColors.Window
        Me.txtCopia.Location = New System.Drawing.Point(75, 77)
        Me.txtCopia.Name = "txtCopia"
        Me.txtCopia.Size = New System.Drawing.Size(261, 20)
        Me.txtCopia.TabIndex = 269
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 268
        Me.Label7.Text = "Copia :"
        '
        'txtPara
        '
        Me.txtPara.BackColor = System.Drawing.SystemColors.Window
        Me.txtPara.Location = New System.Drawing.Point(75, 46)
        Me.txtPara.Name = "txtPara"
        Me.txtPara.Size = New System.Drawing.Size(261, 20)
        Me.txtPara.TabIndex = 267
        '
        'btnVerPublicidad
        '
        Me.btnVerPublicidad.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.btnVerPublicidad.Location = New System.Drawing.Point(319, 247)
        Me.btnVerPublicidad.Name = "btnVerPublicidad"
        Me.btnVerPublicidad.Size = New System.Drawing.Size(25, 22)
        Me.btnVerPublicidad.TabIndex = 265
        Me.btnVerPublicidad.TabStop = False
        Me.btnVerPublicidad.ToolTipText = "Ver Publicidad"
        Me.btnVerPublicidad.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 256
        Me.Label5.Text = "Publicidad : "
        Me.Label5.Visible = False
        '
        'biLimpiar
        '
        Me.biLimpiar.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.biLimpiar.Location = New System.Drawing.Point(348, 248)
        Me.biLimpiar.Name = "biLimpiar"
        Me.biLimpiar.Size = New System.Drawing.Size(25, 22)
        Me.biLimpiar.TabIndex = 266
        Me.biLimpiar.TabStop = False
        Me.biLimpiar.ToolTipText = "Limpiar Publicidad"
        Me.biLimpiar.Visible = False
        '
        'btnBuscarPublicidad
        '
        Me.btnBuscarPublicidad.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPublicidad.Location = New System.Drawing.Point(290, 247)
        Me.btnBuscarPublicidad.Name = "btnBuscarPublicidad"
        Me.btnBuscarPublicidad.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPublicidad.TabIndex = 254
        Me.btnBuscarPublicidad.TabStop = False
        Me.btnBuscarPublicidad.UseVisualStyleBackColor = True
        Me.btnBuscarPublicidad.Visible = False
        '
        'txtPublicidad
        '
        Me.txtPublicidad.BackColor = System.Drawing.SystemColors.Control
        Me.txtPublicidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPublicidad.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPublicidad.Location = New System.Drawing.Point(86, 248)
        Me.txtPublicidad.MaxLength = 10
        Me.txtPublicidad.Name = "txtPublicidad"
        Me.txtPublicidad.ReadOnly = True
        Me.txtPublicidad.Size = New System.Drawing.Size(198, 20)
        Me.txtPublicidad.TabIndex = 253
        Me.txtPublicidad.TabStop = False
        Me.txtPublicidad.Visible = False
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(75, 140)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(576, 100)
        Me.txtMensaje.TabIndex = 123
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nombre1, Me.Tamano1, Me.Direccion1})
        Me.DataGridView1.Location = New System.Drawing.Point(489, 275)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(163, 95)
        Me.DataGridView1.TabIndex = 122
        Me.DataGridView1.Visible = False
        '
        'Nombre1
        '
        Me.Nombre1.DataPropertyName = "Nombre1"
        Me.Nombre1.HeaderText = "Nombre1"
        Me.Nombre1.Name = "Nombre1"
        '
        'Tamano1
        '
        Me.Tamano1.DataPropertyName = "Tamano1"
        Me.Tamano1.HeaderText = "Tamano1"
        Me.Tamano1.Name = "Tamano1"
        '
        'Direccion1
        '
        Me.Direccion1.DataPropertyName = "Direccion1"
        Me.Direccion1.HeaderText = "Direccion1"
        Me.Direccion1.Name = "Direccion1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Para :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(340, 378)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(94, 50)
        Me.UiGroupBox2.TabIndex = 118
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(5, 11)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(84, 36)
        Me.btnCancelar.TabIndex = 126
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtMensaje2)
        Me.Panel1.Controls.Add(Me.cbVineta)
        Me.Panel1.Controls.Add(Me.ToolStrip)
        Me.Panel1.Location = New System.Drawing.Point(585, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(61, 51)
        Me.Panel1.TabIndex = 117
        Me.Panel1.Visible = False
        '
        'txtMensaje2
        '
        Me.txtMensaje2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje2.Location = New System.Drawing.Point(8, 34)
        Me.txtMensaje2.Name = "txtMensaje2"
        Me.txtMensaje2.Size = New System.Drawing.Size(688, 63)
        Me.txtMensaje2.TabIndex = 26
        Me.txtMensaje2.Text = ""
        '
        'cbVineta
        '
        Me.cbVineta.AutoSize = True
        Me.cbVineta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVineta.Location = New System.Drawing.Point(78, 8)
        Me.cbVineta.Name = "cbVineta"
        Me.cbVineta.Size = New System.Drawing.Size(62, 17)
        Me.cbVineta.TabIndex = 25
        Me.cbVineta.Text = "Viñeta"
        Me.cbVineta.UseVisualStyleBackColor = True
        Me.cbVineta.Visible = False
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator14, Me.btnGuardar, Me.ToolStripSeparator4, Me.biColorFuente, Me.ToolStripSeparator5, Me.biFuente, Me.ToolStripSeparator2, Me.biVinetas, Me.biNegrita, Me.biSubrayado, Me.ToolStripButton1})
        Me.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(61, 31)
        Me.ToolStrip.TabIndex = 19
        Me.ToolStrip.Text = "Actualiza"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.Text = "Grabar Cambios"
        Me.btnGuardar.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator4.Visible = False
        '
        'biColorFuente
        '
        Me.biColorFuente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biColorFuente.Image = CType(resources.GetObject("biColorFuente.Image"), System.Drawing.Image)
        Me.biColorFuente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biColorFuente.Name = "biColorFuente"
        Me.biColorFuente.Size = New System.Drawing.Size(28, 28)
        Me.biColorFuente.Text = "Color Fuente"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biFuente
        '
        Me.biFuente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biFuente.Image = CType(resources.GetObject("biFuente.Image"), System.Drawing.Image)
        Me.biFuente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biFuente.Name = "biFuente"
        Me.biFuente.Size = New System.Drawing.Size(28, 28)
        Me.biFuente.Text = "Fuente"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biVinetas
        '
        Me.biVinetas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biVinetas.Image = CType(resources.GetObject("biVinetas.Image"), System.Drawing.Image)
        Me.biVinetas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biVinetas.Name = "biVinetas"
        Me.biVinetas.Size = New System.Drawing.Size(28, 28)
        Me.biVinetas.Text = "Generar G/F/B/O.C."
        Me.biVinetas.Visible = False
        '
        'biNegrita
        '
        Me.biNegrita.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNegrita.Image = CType(resources.GetObject("biNegrita.Image"), System.Drawing.Image)
        Me.biNegrita.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNegrita.Name = "biNegrita"
        Me.biNegrita.Size = New System.Drawing.Size(28, 28)
        Me.biNegrita.Text = "Generar G/F/B/O.C."
        Me.biNegrita.Visible = False
        '
        'biSubrayado
        '
        Me.biSubrayado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSubrayado.Image = CType(resources.GetObject("biSubrayado.Image"), System.Drawing.Image)
        Me.biSubrayado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSubrayado.Name = "biSubrayado"
        Me.biSubrayado.Size = New System.Drawing.Size(28, 28)
        Me.biSubrayado.Text = "Generar G/F/B/O.C."
        Me.biSubrayado.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton1.Text = "Cerrar el Formulario"
        Me.ToolStripButton1.Visible = False
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnEnviarCorreo)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(214, 378)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(120, 50)
        Me.UiGroupBox1.TabIndex = 113
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnEnviarCorreo
        '
        Me.btnEnviarCorreo.Image = CType(resources.GetObject("btnEnviarCorreo.Image"), System.Drawing.Image)
        Me.btnEnviarCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnviarCorreo.Location = New System.Drawing.Point(5, 10)
        Me.btnEnviarCorreo.Name = "btnEnviarCorreo"
        Me.btnEnviarCorreo.Size = New System.Drawing.Size(110, 36)
        Me.btnEnviarCorreo.TabIndex = 125
        Me.btnEnviarCorreo.Text = "Enviar Correo"
        Me.btnEnviarCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviarCorreo.UseVisualStyleBackColor = True
        '
        'dgvArchivosDirectorio
        '
        Me.dgvArchivosDirectorio.ContextMenuStrip = Me.cmOpciones
        dgvArchivosDirectorio_DesignTimeLayout.LayoutString = resources.GetString("dgvArchivosDirectorio_DesignTimeLayout.LayoutString")
        Me.dgvArchivosDirectorio.DesignTimeLayout = dgvArchivosDirectorio_DesignTimeLayout
        Me.dgvArchivosDirectorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvArchivosDirectorio.GroupByBoxVisible = False
        Me.dgvArchivosDirectorio.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvArchivosDirectorio.Location = New System.Drawing.Point(86, 275)
        Me.dgvArchivosDirectorio.Name = "dgvArchivosDirectorio"
        Me.dgvArchivosDirectorio.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvArchivosDirectorio.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvArchivosDirectorio.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvArchivosDirectorio.Size = New System.Drawing.Size(388, 95)
        Me.dgvArchivosDirectorio.TabIndex = 32
        Me.dgvArchivosDirectorio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miVer, Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.miNuevo, Me.miEliminar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(118, 82)
        '
        'miVer
        '
        Me.miVer.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miVer.Name = "miVer"
        Me.miVer.Size = New System.Drawing.Size(117, 22)
        Me.miVer.Text = "Ver"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(114, 6)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(114, 6)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(117, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(117, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'txtDe
        '
        Me.txtDe.BackColor = System.Drawing.SystemColors.Window
        Me.txtDe.Location = New System.Drawing.Point(75, 16)
        Me.txtDe.Name = "txtDe"
        Me.txtDe.ReadOnly = True
        Me.txtDe.Size = New System.Drawing.Size(261, 20)
        Me.txtDe.TabIndex = 30
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "De :"
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(75, 109)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(576, 20)
        Me.txtAsunto.TabIndex = 122
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 295)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Adjuntos :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Asunto :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Mensaje :"
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'FontDialog1
        '
        Me.FontDialog1.Color = System.Drawing.SystemColors.ControlText
        '
        'frmPlanillaSueldoEnviarCorreo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(690, 462)
        Me.Controls.Add(Me.gbProcesoJob)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanillaSueldoEnviarCorreo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envio de Correo"
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProcesoJob.ResumeLayout(False)
        Me.gbProcesoJob.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.dgvArchivosDirectorio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbProcesoJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnEnviarCorreo As System.Windows.Forms.Button
    Friend WithEvents dgvArchivosDirectorio As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtDe As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biColorFuente As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biFuente As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biVinetas As System.Windows.Forms.ToolStripButton
    Friend WithEvents biNegrita As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSubrayado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents cbVineta As System.Windows.Forms.CheckBox
    Friend WithEvents txtMensaje2 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents miVer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Nombre1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tamano1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Direccion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents biLimpiar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarPublicidad As System.Windows.Forms.Button
    Friend WithEvents txtPublicidad As System.Windows.Forms.TextBox
    Friend WithEvents btnVerPublicidad As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtCopia As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPara As TextBox
End Class
