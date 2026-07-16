<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVacaciones_masivo
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
        Me.components = New System.ComponentModel.Container
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVacaciones_masivo))
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbClase_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbAnio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnGenerar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbClase = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbAnio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFechaFinal = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.txtFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnRegresarTodos = New System.Windows.Forms.Button
        Me.btnAgregarTodos = New System.Windows.Forms.Button
        Me.btnRegresar = New System.Windows.Forms.Button
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView
        Me.cIdVacaciones1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cIdPer1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cApeNom1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cDiasPen1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblPersonal = New System.Windows.Forms.Label
        Me.dgvPersonal = New System.Windows.Forms.DataGridView
        Me.cIdVacaciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cIdPer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cDiasPen = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip1.Size = New System.Drawing.Size(827, 27)
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
        Me.btnGenerar.Text = "Generar Vacaciones Masivo"
        Me.btnGenerar.ToolTipText = "Generar Vacaciones Masivo"
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
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.cmbArea)
        Me.UiGroupBox1.Controls.Add(Me.cmbCentroCosto)
        Me.UiGroupBox1.Controls.Add(Me.cmbClase)
        Me.UiGroupBox1.Controls.Add(Me.cmbAnio)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 30)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(814, 59)
        Me.UiGroupBox1.TabIndex = 10
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(606, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 228
        Me.Label4.Text = "Clase"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(376, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 227
        Me.Label3.Text = "Centro de Costo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(201, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 226
        Me.Label2.Text = "Área"
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Location = New System.Drawing.Point(151, 29)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(140, 20)
        Me.cmbArea.TabIndex = 223
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Location = New System.Drawing.Point(329, 29)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(200, 20)
        Me.cmbCentroCosto.TabIndex = 224
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbClase
        '
        Me.cmbClase.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbClase_DesignTimeLayout.LayoutString = resources.GetString("cmbClase_DesignTimeLayout.LayoutString")
        Me.cmbClase.DesignTimeLayout = cmbClase_DesignTimeLayout
        Me.cmbClase.Location = New System.Drawing.Point(568, 29)
        Me.cmbClase.Name = "cmbClase"
        Me.cmbClase.SelectedIndex = -1
        Me.cmbClase.SelectedItem = Nothing
        Me.cmbClase.Size = New System.Drawing.Size(113, 20)
        Me.cmbClase.TabIndex = 225
        Me.cmbClase.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbAnio
        '
        Me.cmbAnio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAnio_DesignTimeLayout.LayoutString = resources.GetString("cmbAnio_DesignTimeLayout.LayoutString")
        Me.cmbAnio.DesignTimeLayout = cmbAnio_DesignTimeLayout
        Me.cmbAnio.Location = New System.Drawing.Point(32, 29)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.SelectedIndex = -1
        Me.cmbAnio.SelectedItem = Nothing
        Me.cmbAnio.Size = New System.Drawing.Size(78, 20)
        Me.cmbAnio.TabIndex = 1
        Me.cmbAnio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbAnio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(718, 26)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 222
        Me.Label1.Text = "Periodo"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.txtFechaFinal)
        Me.UiGroupBox2.Controls.Add(Me.txtFechaInicio)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 300)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(814, 86)
        Me.UiGroupBox2.TabIndex = 12
        Me.UiGroupBox2.Text = "Datos de Vacaciones"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(224, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 259
        Me.Label9.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(308, 22)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(487, 53)
        Me.txtObservacion.TabIndex = 258
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 257
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
        Me.txtFechaFinal.Location = New System.Drawing.Point(98, 55)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.NullButtonText = "Ninguno"
        Me.txtFechaFinal.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaFinal.TabIndex = 255
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
        Me.txtFechaInicio.Location = New System.Drawing.Point(98, 22)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.NullButtonText = "Ninguno"
        Me.txtFechaInicio.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaInicio.TabIndex = 254
        Me.txtFechaInicio.TodayButtonText = "Hoy"
        Me.txtFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(25, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 256
        Me.Label10.Text = "Fec. Inicio"
        '
        'btnRegresarTodos
        '
        Me.btnRegresarTodos.Image = Global.SIGECOM.My.Resources.Resources.Izquierda
        Me.btnRegresarTodos.Location = New System.Drawing.Point(392, 251)
        Me.btnRegresarTodos.Name = "btnRegresarTodos"
        Me.btnRegresarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnRegresarTodos.TabIndex = 237
        Me.btnRegresarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(392, 213)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregarTodos.TabIndex = 236
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.SIGECOM.My.Resources.Resources.Regresar
        Me.btnRegresar.Location = New System.Drawing.Point(392, 175)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(42, 23)
        Me.btnRegresar.TabIndex = 235
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(392, 137)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregar.TabIndex = 234
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(440, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 15)
        Me.Label6.TabIndex = 233
        Me.Label6.Text = "Seleccionados"
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdVacaciones1, Me.cIdPer1, Me.cApeNom1, Me.cDiasPen1})
        Me.dgvSeleccionados.Location = New System.Drawing.Point(440, 116)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.ReadOnly = True
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(380, 178)
        Me.dgvSeleccionados.TabIndex = 232
        '
        'cIdVacaciones1
        '
        Me.cIdVacaciones1.HeaderText = "IdVacaciones"
        Me.cIdVacaciones1.Name = "cIdVacaciones1"
        Me.cIdVacaciones1.ReadOnly = True
        Me.cIdVacaciones1.Visible = False
        '
        'cIdPer1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdPer1.DefaultCellStyle = DataGridViewCellStyle1
        Me.cIdPer1.HeaderText = "Cod"
        Me.cIdPer1.Name = "cIdPer1"
        Me.cIdPer1.ReadOnly = True
        Me.cIdPer1.Width = 47
        '
        'cApeNom1
        '
        Me.cApeNom1.HeaderText = "Nombre"
        Me.cApeNom1.Name = "cApeNom1"
        Me.cApeNom1.ReadOnly = True
        Me.cApeNom1.Width = 250
        '
        'cDiasPen1
        '
        Me.cDiasPen1.HeaderText = "DiasPen"
        Me.cDiasPen1.Name = "cDiasPen1"
        Me.cDiasPen1.ReadOnly = True
        Me.cDiasPen1.Width = 60
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(8, 98)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(64, 15)
        Me.lblPersonal.TabIndex = 231
        Me.lblPersonal.Text = "Personal"
        '
        'dgvPersonal
        '
        Me.dgvPersonal.AllowUserToAddRows = False
        Me.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPersonal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdVacaciones, Me.cIdPer, Me.cApeNom, Me.cDiasPen})
        Me.dgvPersonal.Location = New System.Drawing.Point(6, 116)
        Me.dgvPersonal.Name = "dgvPersonal"
        Me.dgvPersonal.ReadOnly = True
        Me.dgvPersonal.RowHeadersVisible = False
        Me.dgvPersonal.Size = New System.Drawing.Size(380, 178)
        Me.dgvPersonal.TabIndex = 230
        '
        'cIdVacaciones
        '
        Me.cIdVacaciones.HeaderText = "IdVacaciones"
        Me.cIdVacaciones.Name = "cIdVacaciones"
        Me.cIdVacaciones.ReadOnly = True
        Me.cIdVacaciones.Visible = False
        '
        'cIdPer
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdPer.DefaultCellStyle = DataGridViewCellStyle2
        Me.cIdPer.HeaderText = "Cod"
        Me.cIdPer.Name = "cIdPer"
        Me.cIdPer.ReadOnly = True
        Me.cIdPer.Width = 47
        '
        'cApeNom
        '
        Me.cApeNom.HeaderText = "Nombre"
        Me.cApeNom.Name = "cApeNom"
        Me.cApeNom.ReadOnly = True
        Me.cApeNom.Width = 250
        '
        'cDiasPen
        '
        Me.cDiasPen.HeaderText = "DiasPen"
        Me.cDiasPen.Name = "cDiasPen"
        Me.cDiasPen.ReadOnly = True
        Me.cDiasPen.Width = 60
        '
        'frmVacaciones_masivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(827, 394)
        Me.Controls.Add(Me.btnRegresarTodos)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.dgvPersonal)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVacaciones_masivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vacaciones de Personal Masivo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbAnio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents dgvPersonal As System.Windows.Forms.DataGridView
    Friend WithEvents cIdVacaciones1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdPer1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDiasPen1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdVacaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdPer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDiasPen As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
