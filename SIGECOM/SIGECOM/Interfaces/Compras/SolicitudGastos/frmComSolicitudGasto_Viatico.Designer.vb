<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudGasto_Viatico
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
        Dim cmbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudGasto_Viatico))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.CCodEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cRucEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNomUbicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAbrPer2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecReg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesArea1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEnviado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cFechaEnv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodUsuEnv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAprobado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cFechaApro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodUsuApro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cProcesado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cAtendido = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cbInsertar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miInsertar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeleccionarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNinguno = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biInsertar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 344)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(761, 20)
        Me.ssBarra.TabIndex = 46
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(350, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(141, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(233, 30)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.NullButtonText = "Ninguno"
        Me.cbFecFinal.ShowNullButton = True
        Me.cbFecFinal.Size = New System.Drawing.Size(102, 20)
        Me.cbFecFinal.TabIndex = 50
        Me.cbFecFinal.TodayButtonText = "Hoy"
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicio.Location = New System.Drawing.Point(47, 30)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.NullButtonText = "Ninguno"
        Me.cbFecInicio.ShowNullButton = True
        Me.cbFecInicio.Size = New System.Drawing.Size(103, 20)
        Me.cbFecInicio.TabIndex = 49
        Me.cbFecInicio.TodayButtonText = "Hoy"
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(252, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Fecha Fin"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(59, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "Fecha Inicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(465, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 229
        Me.Label3.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipo_DesignTimeLayout.LayoutString")
        Me.cmbTipo.DesignTimeLayout = cmbTipo_DesignTimeLayout
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(418, 30)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.SelectedIndex = -1
        Me.cmbTipo.SelectedItem = Nothing
        Me.cmbTipo.Size = New System.Drawing.Size(125, 20)
        Me.cmbTipo.TabIndex = 228
        Me.cmbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(613, 27)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 23)
        Me.btnBuscar.TabIndex = 230
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.TextBox1)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipo)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox1.Controls.Add(Me.Label12)
        Me.UiGroupBox1.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox1.Controls.Add(Me.Label13)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(11, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(727, 56)
        Me.UiGroupBox1.TabIndex = 231
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(613, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(67, 20)
        Me.TextBox1.TabIndex = 231
        Me.TextBox1.Visible = False
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CCodEmp, Me.cDesEmp, Me.cRucEmp, Me.cIdPlanilla, Me.cNomUbicacion, Me.cIdPer, Me.cAbrPer2, Me.cApeNom, Me.cNumDoc, Me.cCodCentro, Me.cCodArea, Me.cDesArea, Me.cCodJob, Me.cFecha, Me.cFecReg, Me.cDescripcion, Me.cCodMon, Me.cMonto, Me.cTipo, Me.cDesTipo, Me.cDesArea1, Me.cEnviado, Me.cFechaEnv, Me.cCodUsuEnv, Me.cAprobado, Me.cFechaApro, Me.cCodUsuApro, Me.cProcesado, Me.cAtendido, Me.cbInsertar})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.Location = New System.Drawing.Point(2, 96)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidth = 25
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(745, 233)
        Me.dgvDatos.TabIndex = 232
        '
        'CCodEmp
        '
        Me.CCodEmp.HeaderText = "CodEmp"
        Me.CCodEmp.Name = "CCodEmp"
        Me.CCodEmp.Visible = False
        '
        'cDesEmp
        '
        Me.cDesEmp.HeaderText = "DesEmp"
        Me.cDesEmp.Name = "cDesEmp"
        Me.cDesEmp.Visible = False
        '
        'cRucEmp
        '
        Me.cRucEmp.HeaderText = "RucEmp"
        Me.cRucEmp.Name = "cRucEmp"
        Me.cRucEmp.Visible = False
        '
        'cIdPlanilla
        '
        Me.cIdPlanilla.DataPropertyName = "(none)"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cIdPlanilla.DefaultCellStyle = DataGridViewCellStyle2
        Me.cIdPlanilla.HeaderText = "Código"
        Me.cIdPlanilla.Name = "cIdPlanilla"
        Me.cIdPlanilla.Width = 52
        '
        'cNomUbicacion
        '
        Me.cNomUbicacion.HeaderText = "NomUbicacion"
        Me.cNomUbicacion.Name = "cNomUbicacion"
        Me.cNomUbicacion.Visible = False
        '
        'cIdPer
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cIdPer.DefaultCellStyle = DataGridViewCellStyle3
        Me.cIdPer.HeaderText = "IdPer"
        Me.cIdPer.Name = "cIdPer"
        Me.cIdPer.Visible = False
        Me.cIdPer.Width = 60
        '
        'cAbrPer2
        '
        Me.cAbrPer2.HeaderText = "Colaborador"
        Me.cAbrPer2.Name = "cAbrPer2"
        Me.cAbrPer2.Width = 135
        '
        'cApeNom
        '
        Me.cApeNom.HeaderText = "ApeNom"
        Me.cApeNom.Name = "cApeNom"
        Me.cApeNom.Visible = False
        '
        'cNumDoc
        '
        Me.cNumDoc.HeaderText = "NumDoc"
        Me.cNumDoc.Name = "cNumDoc"
        Me.cNumDoc.Visible = False
        '
        'cCodCentro
        '
        Me.cCodCentro.HeaderText = "CodCentro"
        Me.cCodCentro.Name = "cCodCentro"
        Me.cCodCentro.Visible = False
        '
        'cCodArea
        '
        Me.cCodArea.HeaderText = "CodArea"
        Me.cCodArea.Name = "cCodArea"
        Me.cCodArea.Visible = False
        Me.cCodArea.Width = 80
        '
        'cDesArea
        '
        Me.cDesArea.HeaderText = "Área"
        Me.cDesArea.Name = "cDesArea"
        Me.cDesArea.Width = 90
        '
        'cCodJob
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cCodJob.DefaultCellStyle = DataGridViewCellStyle4
        Me.cCodJob.HeaderText = "OT"
        Me.cCodJob.Name = "cCodJob"
        Me.cCodJob.Width = 55
        '
        'cFecha
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cFecha.DefaultCellStyle = DataGridViewCellStyle5
        Me.cFecha.HeaderText = "Fecha"
        Me.cFecha.Name = "cFecha"
        Me.cFecha.Width = 74
        '
        'cFecReg
        '
        Me.cFecReg.HeaderText = "FecReg"
        Me.cFecReg.Name = "cFecReg"
        Me.cFecReg.Visible = False
        '
        'cDescripcion
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.cDescripcion.DefaultCellStyle = DataGridViewCellStyle6
        Me.cDescripcion.HeaderText = "Descripción"
        Me.cDescripcion.Name = "cDescripcion"
        Me.cDescripcion.Width = 155
        '
        'cCodMon
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cCodMon.DefaultCellStyle = DataGridViewCellStyle7
        Me.cCodMon.HeaderText = "Mon."
        Me.cCodMon.Name = "cCodMon"
        Me.cCodMon.Width = 40
        '
        'cMonto
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cMonto.DefaultCellStyle = DataGridViewCellStyle8
        Me.cMonto.HeaderText = "Monto"
        Me.cMonto.Name = "cMonto"
        Me.cMonto.Width = 70
        '
        'cTipo
        '
        Me.cTipo.HeaderText = "Tipo"
        Me.cTipo.Name = "cTipo"
        Me.cTipo.Visible = False
        '
        'cDesTipo
        '
        Me.cDesTipo.HeaderText = "DesTipo"
        Me.cDesTipo.Name = "cDesTipo"
        Me.cDesTipo.Visible = False
        '
        'cDesArea1
        '
        Me.cDesArea1.HeaderText = "DesArea1"
        Me.cDesArea1.Name = "cDesArea1"
        Me.cDesArea1.Visible = False
        '
        'cEnviado
        '
        Me.cEnviado.HeaderText = "Enviado"
        Me.cEnviado.Name = "cEnviado"
        Me.cEnviado.Visible = False
        '
        'cFechaEnv
        '
        Me.cFechaEnv.HeaderText = "FechaEnv"
        Me.cFechaEnv.Name = "cFechaEnv"
        Me.cFechaEnv.Visible = False
        '
        'cCodUsuEnv
        '
        Me.cCodUsuEnv.HeaderText = "CodUsuEnv"
        Me.cCodUsuEnv.Name = "cCodUsuEnv"
        Me.cCodUsuEnv.Visible = False
        '
        'cAprobado
        '
        Me.cAprobado.HeaderText = "Aprobado"
        Me.cAprobado.Name = "cAprobado"
        Me.cAprobado.Visible = False
        '
        'cFechaApro
        '
        Me.cFechaApro.HeaderText = "FechaApro"
        Me.cFechaApro.Name = "cFechaApro"
        Me.cFechaApro.Visible = False
        '
        'cCodUsuApro
        '
        Me.cCodUsuApro.HeaderText = "CodUsuApro"
        Me.cCodUsuApro.Name = "cCodUsuApro"
        Me.cCodUsuApro.Visible = False
        '
        'cProcesado
        '
        Me.cProcesado.HeaderText = "Procesado"
        Me.cProcesado.Name = "cProcesado"
        Me.cProcesado.Visible = False
        '
        'cAtendido
        '
        Me.cAtendido.HeaderText = "Atendido"
        Me.cAtendido.Name = "cAtendido"
        Me.cAtendido.Visible = False
        '
        'cbInsertar
        '
        Me.cbInsertar.FalseValue = ""
        Me.cbInsertar.HeaderText = ""
        Me.cbInsertar.Name = "cbInsertar"
        Me.cbInsertar.Width = 30
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miInsertar, Me.miSeleccionarTodos, Me.miNinguno, Me.ToolStripSeparator5, Me.ToolStripMenuItem1, Me.miActualizar, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(228, 126)
        '
        'miInsertar
        '
        Me.miInsertar.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.miInsertar.Name = "miInsertar"
        Me.miInsertar.Size = New System.Drawing.Size(227, 22)
        Me.miInsertar.Text = "Insertar Doc(s) seleccionados"
        '
        'miSeleccionarTodos
        '
        Me.miSeleccionarTodos.Image = CType(resources.GetObject("miSeleccionarTodos.Image"), System.Drawing.Image)
        Me.miSeleccionarTodos.Name = "miSeleccionarTodos"
        Me.miSeleccionarTodos.Size = New System.Drawing.Size(227, 22)
        Me.miSeleccionarTodos.Text = "Seleccionar Todos"
        '
        'miNinguno
        '
        Me.miNinguno.Image = CType(resources.GetObject("miNinguno.Image"), System.Drawing.Image)
        Me.miNinguno.Name = "miNinguno"
        Me.miNinguno.Size = New System.Drawing.Size(227, 22)
        Me.miNinguno.Text = "Ninguno"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(224, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(224, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(227, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(227, 22)
        Me.miSalir.Text = "Salir"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator8, Me.biActualizar, Me.ToolStripSeparator3, Me.biInsertar, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(761, 31)
        Me.ToolStrip.TabIndex = 233
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Datos"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biInsertar
        '
        Me.biInsertar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biInsertar.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.biInsertar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biInsertar.Name = "biInsertar"
        Me.biInsertar.Size = New System.Drawing.Size(28, 28)
        Me.biInsertar.Text = "Insertar Planilla(s) Seleccionada(s)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'frmComSolicitudGasto_Viatico
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(761, 364)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudGasto_Viatico"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Viaticos a Solicitud de Gastos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miInsertar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeleccionarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNinguno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biInsertar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CCodEmp As DataGridViewTextBoxColumn
    Friend WithEvents cDesEmp As DataGridViewTextBoxColumn
    Friend WithEvents cRucEmp As DataGridViewTextBoxColumn
    Friend WithEvents cIdPlanilla As DataGridViewTextBoxColumn
    Friend WithEvents cNomUbicacion As DataGridViewTextBoxColumn
    Friend WithEvents cIdPer As DataGridViewTextBoxColumn
    Friend WithEvents cAbrPer2 As DataGridViewTextBoxColumn
    Friend WithEvents cApeNom As DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc As DataGridViewTextBoxColumn
    Friend WithEvents cCodCentro As DataGridViewTextBoxColumn
    Friend WithEvents cCodArea As DataGridViewTextBoxColumn
    Friend WithEvents cDesArea As DataGridViewTextBoxColumn
    Friend WithEvents cCodJob As DataGridViewTextBoxColumn
    Friend WithEvents cFecha As DataGridViewTextBoxColumn
    Friend WithEvents cFecReg As DataGridViewTextBoxColumn
    Friend WithEvents cDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents cCodMon As DataGridViewTextBoxColumn
    Friend WithEvents cMonto As DataGridViewTextBoxColumn
    Friend WithEvents cTipo As DataGridViewTextBoxColumn
    Friend WithEvents cDesTipo As DataGridViewTextBoxColumn
    Friend WithEvents cDesArea1 As DataGridViewTextBoxColumn
    Friend WithEvents cEnviado As DataGridViewCheckBoxColumn
    Friend WithEvents cFechaEnv As DataGridViewTextBoxColumn
    Friend WithEvents cCodUsuEnv As DataGridViewTextBoxColumn
    Friend WithEvents cAprobado As DataGridViewCheckBoxColumn
    Friend WithEvents cFechaApro As DataGridViewTextBoxColumn
    Friend WithEvents cCodUsuApro As DataGridViewTextBoxColumn
    Friend WithEvents cProcesado As DataGridViewCheckBoxColumn
    Friend WithEvents cAtendido As DataGridViewCheckBoxColumn
    Friend WithEvents cbInsertar As DataGridViewCheckBoxColumn
End Class
