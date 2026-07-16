<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignacionHE_Masivo
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
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbClase_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim cmbPerAutoriza_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignacionHE_Masivo))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGenerar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbClase = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnRegresarTodos = New System.Windows.Forms.Button()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cIdPer1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApeNom1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.dgvPersonal = New System.Windows.Forms.DataGridView()
        Me.cIdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtHoraFinal = New System.Windows.Forms.MaskedTextBox()
        Me.txtHoraInicio = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbPerAutoriza = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbPerAutoriza, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip1.Size = New System.Drawing.Size(720, 27)
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
        Me.btnGenerar.Text = "Generar Asignación de HE Masivo"
        Me.btnGenerar.ToolTipText = "Generar Faltas Masivo"
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
        Me.gbDatosBusqueda.TabIndex = 10
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
        'btnRegresarTodos
        '
        Me.btnRegresarTodos.Image = Global.SIGECOM.My.Resources.Resources.Izquierda
        Me.btnRegresarTodos.Location = New System.Drawing.Point(339, 251)
        Me.btnRegresarTodos.Name = "btnRegresarTodos"
        Me.btnRegresarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnRegresarTodos.TabIndex = 25
        Me.btnRegresarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(339, 213)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregarTodos.TabIndex = 24
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.SIGECOM.My.Resources.Resources.Regresar
        Me.btnRegresar.Location = New System.Drawing.Point(339, 175)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(42, 23)
        Me.btnRegresar.TabIndex = 23
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(339, 137)
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
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtHoraFinal)
        Me.UiGroupBox1.Controls.Add(Me.txtHoraInicio)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarJob)
        Me.UiGroupBox1.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.cmbPerAutoriza)
        Me.UiGroupBox1.Controls.Add(Me.txtFecha)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(10, 300)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(700, 100)
        Me.UiGroupBox1.TabIndex = 26
        Me.UiGroupBox1.Text = "Datos de Falta"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtHoraFinal
        '
        Me.txtHoraFinal.Location = New System.Drawing.Point(223, 46)
        Me.txtHoraFinal.Mask = "00:00"
        Me.txtHoraFinal.Name = "txtHoraFinal"
        Me.txtHoraFinal.Size = New System.Drawing.Size(88, 20)
        Me.txtHoraFinal.TabIndex = 262
        Me.txtHoraFinal.ValidatingType = GetType(Date)
        '
        'txtHoraInicio
        '
        Me.txtHoraInicio.Location = New System.Drawing.Point(69, 46)
        Me.txtHoraInicio.Mask = "00:00"
        Me.txtHoraInicio.Name = "txtHoraInicio"
        Me.txtHoraInicio.Size = New System.Drawing.Size(88, 20)
        Me.txtHoraInicio.TabIndex = 261
        Me.txtHoraInicio.ValidatingType = GetType(Date)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(199, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 13)
        Me.Label7.TabIndex = 264
        Me.Label7.Text = "Al"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 263
        Me.Label6.Text = "Horas"
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(303, 18)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 259
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'txtNumJob
        '
        Me.txtNumJob.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumJob.Location = New System.Drawing.Point(223, 19)
        Me.txtNumJob.MaxLength = 20
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(78, 20)
        Me.txtNumJob.TabIndex = 258
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(172, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 260
        Me.Label14.Text = "Nº Job"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(376, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 257
        Me.Label9.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(460, 21)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(232, 65)
        Me.txtObservacion.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 256
        Me.Label8.Text = "Autoriza"
        '
        'cmbPerAutoriza
        '
        Me.cmbPerAutoriza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbPerAutoriza.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPerAutoriza_DesignTimeLayout.LayoutString = resources.GetString("cmbPerAutoriza_DesignTimeLayout.LayoutString")
        Me.cmbPerAutoriza.DesignTimeLayout = cmbPerAutoriza_DesignTimeLayout
        Me.cmbPerAutoriza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPerAutoriza.Location = New System.Drawing.Point(69, 73)
        Me.cmbPerAutoriza.Name = "cmbPerAutoriza"
        Me.cmbPerAutoriza.SelectedIndex = -1
        Me.cmbPerAutoriza.SelectedItem = Nothing
        Me.cmbPerAutoriza.Size = New System.Drawing.Size(295, 20)
        Me.cmbPerAutoriza.TabIndex = 11
        Me.cmbPerAutoriza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbPerAutoriza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(69, 19)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(91, 20)
        Me.txtFecha.TabIndex = 7
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 252
        Me.Label10.Text = "Fecha"
        '
        'frmAsignacionHE_Masivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(720, 411)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnRegresarTodos)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.btnRegresar)
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
        Me.Name = "frmAsignacionHE_Masivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación de Horas Extra Masivo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbPerAutoriza, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbClase As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnRegresarTodos As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents cIdPer1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents dgvPersonal As System.Windows.Forms.DataGridView
    Friend WithEvents cIdPer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbPerAutoriza As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtHoraFinal As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHoraInicio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
