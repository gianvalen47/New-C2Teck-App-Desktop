<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAgregar_Job_SolGastosNew
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregar_Job_SolGastosNew))
        Dim cmbCodArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
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
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtcod_job = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMontoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMontoNoAfecto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cbProrratear = New System.Windows.Forms.CheckBox()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMontoSinIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dgvJobs = New System.Windows.Forms.DataGridView()
        Me.cCodJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cCodJob1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoSinIgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoNoAfecto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotSubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotIgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotNoAfecto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotOtroCargo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalOtroCargo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalNoAfecto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtSubTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotalIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvJobs, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip1.Size = New System.Drawing.Size(898, 27)
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
        Me.btnGenerar.Text = "Asignar Job's seleccionados"
        Me.btnGenerar.ToolTipText = "Asignar Job's seleccionados"
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
        Me.gbDatosBusqueda.Controls.Add(Me.Label26)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbCentroCosto)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbCodArea)
        Me.gbDatosBusqueda.Controls.Add(Me.Label10)
        Me.gbDatosBusqueda.Controls.Add(Me.txtanio)
        Me.gbDatosBusqueda.Controls.Add(Me.Label4)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbLocacion)
        Me.gbDatosBusqueda.Controls.Add(Me.Label1)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbTipo)
        Me.gbDatosBusqueda.Controls.Add(Me.txtcod_job)
        Me.gbDatosBusqueda.Controls.Add(Me.Label3)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(7, 24)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(874, 56)
        Me.gbDatosBusqueda.TabIndex = 304
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(273, 13)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 13)
        Me.Label26.TabIndex = 208
        Me.Label26.Text = "Centro Costo"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(243, 29)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(142, 20)
        Me.cmbCentroCosto.TabIndex = 206
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodArea
        '
        Me.cmbCodArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodArea_DesignTimeLayout.LayoutString = resources.GetString("cmbCodArea_DesignTimeLayout.LayoutString")
        Me.cmbCodArea.DesignTimeLayout = cmbCodArea_DesignTimeLayout
        Me.cmbCodArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodArea.Location = New System.Drawing.Point(94, 29)
        Me.cmbCodArea.Name = "cmbCodArea"
        Me.cmbCodArea.SelectedIndex = -1
        Me.cmbCodArea.SelectedItem = Nothing
        Me.cmbCodArea.Size = New System.Drawing.Size(122, 20)
        Me.cmbCodArea.TabIndex = 205
        Me.cmbCodArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(140, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 207
        Me.Label10.Text = "Area"
        '
        'txtanio
        '
        Me.txtanio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtanio.Location = New System.Drawing.Point(19, 29)
        Me.txtanio.Maximum = 2039
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2006
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(49, 20)
        Me.txtanio.TabIndex = 121
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2006
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(447, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Locación"
        '
        'cmbLocacion
        '
        Me.cmbLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbLocacion_DesignTimeLayout.LayoutString")
        Me.cmbLocacion.DesignTimeLayout = cmbLocacion_DesignTimeLayout
        Me.cmbLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLocacion.Location = New System.Drawing.Point(415, 29)
        Me.cmbLocacion.Name = "cmbLocacion"
        Me.cmbLocacion.SelectedIndex = -1
        Me.cmbLocacion.SelectedItem = Nothing
        Me.cmbLocacion.Size = New System.Drawing.Size(123, 20)
        Me.cmbLocacion.TabIndex = 119
        Me.cmbLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Año"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(597, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipo_DesignTimeLayout.LayoutString")
        Me.cmbTipo.DesignTimeLayout = cmbTipo_DesignTimeLayout
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(569, 29)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.SelectedIndex = -1
        Me.cmbTipo.SelectedItem = Nothing
        Me.cmbTipo.Size = New System.Drawing.Size(89, 20)
        Me.cmbTipo.TabIndex = 116
        Me.cmbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtcod_job
        '
        Me.txtcod_job.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcod_job.Location = New System.Drawing.Point(687, 30)
        Me.txtcod_job.MaxLength = 7
        Me.txtcod_job.Name = "txtcod_job"
        Me.txtcod_job.Size = New System.Drawing.Size(73, 20)
        Me.txtcod_job.TabIndex = 114
        Me.txtcod_job.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(701, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "# OT"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(784, 27)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 25)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(378, 330)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 333
        Me.Label5.Text = "Monto Total"
        Me.Label5.Visible = False
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoTotal.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotal.FormatString = "#0.00"
        Me.txtMontoTotal.Location = New System.Drawing.Point(361, 346)
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(110, 20)
        Me.txtMontoTotal.TabIndex = 332
        Me.txtMontoTotal.TabStop = False
        Me.txtMontoTotal.Text = "0.00"
        Me.txtMontoTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotal.Visible = False
        Me.txtMontoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(254, 330)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 331
        Me.Label6.Text = "Monto No Afecto"
        Me.Label6.Visible = False
        '
        'txtMontoNoAfecto
        '
        Me.txtMontoNoAfecto.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoNoAfecto.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtMontoNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNoAfecto.FormatString = "#0.00"
        Me.txtMontoNoAfecto.Location = New System.Drawing.Point(245, 346)
        Me.txtMontoNoAfecto.Name = "txtMontoNoAfecto"
        Me.txtMontoNoAfecto.ReadOnly = True
        Me.txtMontoNoAfecto.Size = New System.Drawing.Size(106, 20)
        Me.txtMontoNoAfecto.TabIndex = 330
        Me.txtMontoNoAfecto.TabStop = False
        Me.txtMontoNoAfecto.Text = "0.00"
        Me.txtMontoNoAfecto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNoAfecto.Visible = False
        Me.txtMontoNoAfecto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.SystemColors.Control
        Me.txtMonto.DisabledForeColor = System.Drawing.SystemColors.MenuText
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.FormatString = "#0.00"
        Me.txtMonto.Location = New System.Drawing.Point(13, 346)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(106, 20)
        Me.txtMonto.TabIndex = 327
        Me.txtMonto.TabStop = False
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMonto.Visible = False
        Me.txtMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbProrratear
        '
        Me.cbProrratear.AutoSize = True
        Me.cbProrratear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProrratear.Location = New System.Drawing.Point(582, 89)
        Me.cbProrratear.Name = "cbProrratear"
        Me.cbProrratear.Size = New System.Drawing.Size(82, 17)
        Me.cbProrratear.TabIndex = 325
        Me.cbProrratear.Text = "Prorratear"
        Me.cbProrratear.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(306, 214)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(50, 23)
        Me.btnAgregarTodos.TabIndex = 324
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(47, 330)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 329
        Me.Label8.Text = "Monto"
        Me.Label8.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(145, 330)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 328
        Me.Label7.Text = "Monto Sin Igv"
        Me.Label7.Visible = False
        '
        'txtMontoSinIgv
        '
        Me.txtMontoSinIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoSinIgv.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtMontoSinIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSinIgv.FormatString = "#0.00"
        Me.txtMontoSinIgv.Location = New System.Drawing.Point(129, 346)
        Me.txtMontoSinIgv.Name = "txtMontoSinIgv"
        Me.txtMontoSinIgv.ReadOnly = True
        Me.txtMontoSinIgv.Size = New System.Drawing.Size(106, 20)
        Me.txtMontoSinIgv.TabIndex = 326
        Me.txtMontoSinIgv.TabStop = False
        Me.txtMontoSinIgv.Text = "0.00"
        Me.txtMontoSinIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoSinIgv.Visible = False
        Me.txtMontoSinIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(4, 88)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(36, 15)
        Me.lblPersonal.TabIndex = 320
        Me.lblPersonal.Text = "OT's"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label9.Location = New System.Drawing.Point(368, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 15)
        Me.Label9.TabIndex = 322
        Me.Label9.Text = "Seleccionados"
        '
        'dgvJobs
        '
        Me.dgvJobs.AllowUserToAddRows = False
        Me.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJobs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodJob, Me.Observacion})
        Me.dgvJobs.Location = New System.Drawing.Point(7, 109)
        Me.dgvJobs.Name = "dgvJobs"
        Me.dgvJobs.RowHeadersVisible = False
        Me.dgvJobs.Size = New System.Drawing.Size(283, 177)
        Me.dgvJobs.TabIndex = 319
        '
        'cCodJob
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodJob.DefaultCellStyle = DataGridViewCellStyle1
        Me.cCodJob.HeaderText = "OT"
        Me.cCodJob.Name = "cCodJob"
        Me.cCodJob.ReadOnly = True
        Me.cCodJob.Width = 80
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.Width = 180
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(306, 170)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(50, 23)
        Me.btnAgregar.TabIndex = 323
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodJob1, Me.cMonto, Me.cMontoSinIgv, Me.cMontoNoAfecto, Me.cObservacion, Me.cTotSubTotal, Me.cTotIgv, Me.cTotNoAfecto, Me.cTotOtroCargo})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmbOpciones
        Me.dgvSeleccionados.Location = New System.Drawing.Point(371, 109)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(512, 177)
        Me.dgvSeleccionados.TabIndex = 321
        '
        'cCodJob1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodJob1.DefaultCellStyle = DataGridViewCellStyle2
        Me.cCodJob1.HeaderText = "OT"
        Me.cCodJob1.Name = "cCodJob1"
        Me.cCodJob1.ReadOnly = True
        Me.cCodJob1.Width = 110
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(662, 290)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 13)
        Me.Label12.TabIndex = 343
        Me.Label12.Text = "Total Otros Cargos"
        '
        'txtTotalOtroCargo
        '
        Me.txtTotalOtroCargo.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalOtroCargo.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotalOtroCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalOtroCargo.FormatString = "#0.00"
        Me.txtTotalOtroCargo.Location = New System.Drawing.Point(657, 306)
        Me.txtTotalOtroCargo.Name = "txtTotalOtroCargo"
        Me.txtTotalOtroCargo.ReadOnly = True
        Me.txtTotalOtroCargo.Size = New System.Drawing.Size(106, 20)
        Me.txtTotalOtroCargo.TabIndex = 342
        Me.txtTotalOtroCargo.TabStop = False
        Me.txtTotalOtroCargo.Text = "0.00"
        Me.txtTotalOtroCargo.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalOtroCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(798, 290)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 341
        Me.Label11.Text = "Total Neto"
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalNeto.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.FormatString = "#0.00"
        Me.txtTotalNeto.Location = New System.Drawing.Point(774, 306)
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(110, 20)
        Me.txtTotalNeto.TabIndex = 340
        Me.txtTotalNeto.TabStop = False
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(555, 290)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 339
        Me.Label13.Text = "Total No Afecto"
        '
        'txtTotalNoAfecto
        '
        Me.txtTotalNoAfecto.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalNoAfecto.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotalNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNoAfecto.FormatString = "#0.00"
        Me.txtTotalNoAfecto.Location = New System.Drawing.Point(540, 306)
        Me.txtTotalNoAfecto.Name = "txtTotalNoAfecto"
        Me.txtTotalNoAfecto.ReadOnly = True
        Me.txtTotalNoAfecto.Size = New System.Drawing.Size(106, 20)
        Me.txtTotalNoAfecto.TabIndex = 338
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
        Me.txtSubTotal.Location = New System.Drawing.Point(341, 306)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(106, 20)
        Me.txtSubTotal.TabIndex = 335
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSubTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(354, 290)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 337
        Me.Label14.Text = "Total Sub Total"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(473, 290)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 336
        Me.Label15.Text = "Total Igv"
        '
        'txtTotalIgv
        '
        Me.txtTotalIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalIgv.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotalIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIgv.FormatString = "#0.00"
        Me.txtTotalIgv.Location = New System.Drawing.Point(457, 306)
        Me.txtTotalIgv.Name = "txtTotalIgv"
        Me.txtTotalIgv.ReadOnly = True
        Me.txtTotalIgv.Size = New System.Drawing.Size(72, 20)
        Me.txtTotalIgv.TabIndex = 334
        Me.txtTotalIgv.TabStop = False
        Me.txtTotalIgv.Text = "0.00"
        Me.txtTotalIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmAgregar_Job_SolGastosNew
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(898, 382)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTotalOtroCargo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTotalNeto)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtTotalNoAfecto)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtTotalIgv)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Controls.Add(Me.txtMontoTotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtMontoNoAfecto)
        Me.Controls.Add(Me.dgvJobs)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.cbProrratear)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMontoSinIgv)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregar_Job_SolGastosNew"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar OT"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvJobs, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtcod_job As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMontoNoAfecto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cbProrratear As System.Windows.Forms.CheckBox
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMontoSinIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvJobs As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCodArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTotalOtroCargo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtTotalNoAfecto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtSubTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtTotalIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cCodJob As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents cCodJob1 As DataGridViewTextBoxColumn
    Friend WithEvents cMonto As DataGridViewTextBoxColumn
    Friend WithEvents cMontoSinIgv As DataGridViewTextBoxColumn
    Friend WithEvents cMontoNoAfecto As DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As DataGridViewTextBoxColumn
    Friend WithEvents cTotSubTotal As DataGridViewTextBoxColumn
    Friend WithEvents cTotIgv As DataGridViewTextBoxColumn
    Friend WithEvents cTotNoAfecto As DataGridViewTextBoxColumn
    Friend WithEvents cTotOtroCargo As DataGridViewTextBoxColumn
End Class
