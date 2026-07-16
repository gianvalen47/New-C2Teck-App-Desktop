<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFaltaPersonal_Imprimir
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
        Dim cmbPerAutoriza_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFaltaPersonal_Imprimir))
        Dim cmbMotivo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNinguno = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbPerAutoriza = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMotivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cDesEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cRucEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdFalta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cHorInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cHorFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPagado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cIdPerAutoriza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApeNomAutoriza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbAtender = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbPerAutoriza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biImprimir, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator3})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(771, 31)
        Me.ToolStrip.TabIndex = 45
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = CType(resources.GetObject("biImprimir.Image"), System.Drawing.Image)
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Listado de Faltas de Personal"
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 304)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(771, 20)
        Me.ssBarra.TabIndex = 44
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(550, 15)
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
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodos, Me.ToolStripSeparator5, Me.miNinguno, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(169, 82)
        '
        'miSeleccionarTodos
        '
        Me.miSeleccionarTodos.Image = CType(resources.GetObject("miSeleccionarTodos.Image"), System.Drawing.Image)
        Me.miSeleccionarTodos.Name = "miSeleccionarTodos"
        Me.miSeleccionarTodos.Size = New System.Drawing.Size(168, 22)
        Me.miSeleccionarTodos.Text = "Seleccionar Todos"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(165, 6)
        '
        'miNinguno
        '
        Me.miNinguno.Image = CType(resources.GetObject("miNinguno.Image"), System.Drawing.Image)
        Me.miNinguno.Name = "miNinguno"
        Me.miNinguno.Size = New System.Drawing.Size(168, 22)
        Me.miNinguno.Text = "Ninguno"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(168, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.lblFecha)
        Me.gbDatos.Controls.Add(Me.txtFecha)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.cmbPerAutoriza)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.cmbMotivo)
        Me.gbDatos.Controls.Add(Me.Label26)
        Me.gbDatos.Controls.Add(Me.cmbCentroCosto)
        Me.gbDatos.Controls.Add(Me.cmbCodArea)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.btnBuscar)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(5, 32)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(756, 54)
        Me.gbDatos.TabIndex = 195
        Me.gbDatos.Text = "Datos de Busqueda"
        Me.gbDatos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(30, 12)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 247
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(6, 28)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(92, 20)
        Me.txtFecha.TabIndex = 1
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(554, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 245
        Me.Label8.Text = "Autoriza"
        '
        'cmbPerAutoriza
        '
        Me.cmbPerAutoriza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbPerAutoriza.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPerAutoriza_DesignTimeLayout.LayoutString = resources.GetString("cmbPerAutoriza_DesignTimeLayout.LayoutString")
        Me.cmbPerAutoriza.DesignTimeLayout = cmbPerAutoriza_DesignTimeLayout
        Me.cmbPerAutoriza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPerAutoriza.Location = New System.Drawing.Point(475, 28)
        Me.cmbPerAutoriza.Name = "cmbPerAutoriza"
        Me.cmbPerAutoriza.SelectedIndex = -1
        Me.cmbPerAutoriza.SelectedItem = Nothing
        Me.cmbPerAutoriza.Size = New System.Drawing.Size(203, 20)
        Me.cmbPerAutoriza.TabIndex = 5
        Me.cmbPerAutoriza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbPerAutoriza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(378, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "Motivo"
        '
        'cmbMotivo
        '
        Me.cmbMotivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMotivo_DesignTimeLayout.LayoutString = resources.GetString("cmbMotivo_DesignTimeLayout.LayoutString")
        Me.cmbMotivo.DesignTimeLayout = cmbMotivo_DesignTimeLayout
        Me.cmbMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMotivo.Location = New System.Drawing.Point(336, 28)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.SelectedIndex = -1
        Me.cmbMotivo.SelectedItem = Nothing
        Me.cmbMotivo.Size = New System.Drawing.Size(133, 20)
        Me.cmbMotivo.TabIndex = 4
        Me.cmbMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(232, 12)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 13)
        Me.Label26.TabIndex = 232
        Me.Label26.Text = "Centro Costo"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(212, 28)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(118, 20)
        Me.cmbCentroCosto.TabIndex = 3
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodArea
        '
        Me.cmbCodArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodArea_DesignTimeLayout.LayoutString = resources.GetString("cmbCodArea_DesignTimeLayout.LayoutString")
        Me.cmbCodArea.DesignTimeLayout = cmbCodArea_DesignTimeLayout
        Me.cmbCodArea.Location = New System.Drawing.Point(104, 28)
        Me.cmbCodArea.Name = "cmbCodArea"
        Me.cmbCodArea.SelectedIndex = -1
        Me.cmbCodArea.SelectedItem = Nothing
        Me.cmbCodArea.Size = New System.Drawing.Size(102, 20)
        Me.cmbCodArea.TabIndex = 2
        Me.cmbCodArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(138, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 231
        Me.Label7.Text = "Area"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(684, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(655, 11)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 190
        Me.TextBox1.Visible = False
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cDesEmp, Me.cRucEmp, Me.cIdFalta, Me.cDesArea, Me.cDesCentro, Me.cCodMotivo, Me.cIdPer, Me.cApeNom, Me.cDesMotivo, Me.cFecInicio, Me.cFecFinal, Me.cHorInicio, Me.cHorFinal, Me.cObservacion, Me.cPagado, Me.cIdPerAutoriza, Me.cApeNomAutoriza, Me.cCodUsu, Me.cbAtender})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.Location = New System.Drawing.Point(5, 90)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersVisible = False
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(756, 194)
        Me.dgvDatos.TabIndex = 194
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
        'cIdFalta
        '
        Me.cIdFalta.HeaderText = "IdFalta"
        Me.cIdFalta.Name = "cIdFalta"
        Me.cIdFalta.ReadOnly = True
        Me.cIdFalta.Visible = False
        Me.cIdFalta.Width = 50
        '
        'cDesArea
        '
        Me.cDesArea.HeaderText = "DesArea"
        Me.cDesArea.Name = "cDesArea"
        Me.cDesArea.Visible = False
        '
        'cDesCentro
        '
        Me.cDesCentro.HeaderText = "DesCentro"
        Me.cDesCentro.Name = "cDesCentro"
        Me.cDesCentro.Visible = False
        '
        'cCodMotivo
        '
        Me.cCodMotivo.HeaderText = "CodMotivo"
        Me.cCodMotivo.Name = "cCodMotivo"
        Me.cCodMotivo.ReadOnly = True
        Me.cCodMotivo.Visible = False
        Me.cCodMotivo.Width = 80
        '
        'cIdPer
        '
        Me.cIdPer.HeaderText = "IdPer"
        Me.cIdPer.Name = "cIdPer"
        Me.cIdPer.ReadOnly = True
        Me.cIdPer.Visible = False
        '
        'cApeNom
        '
        Me.cApeNom.HeaderText = "Colaborador"
        Me.cApeNom.Name = "cApeNom"
        Me.cApeNom.ReadOnly = True
        Me.cApeNom.Width = 262
        '
        'cDesMotivo
        '
        Me.cDesMotivo.HeaderText = "Motivo"
        Me.cDesMotivo.Name = "cDesMotivo"
        Me.cDesMotivo.ReadOnly = True
        Me.cDesMotivo.Width = 130
        '
        'cFecInicio
        '
        Me.cFecInicio.HeaderText = "Fec. Inicio"
        Me.cFecInicio.Name = "cFecInicio"
        Me.cFecInicio.ReadOnly = True
        Me.cFecInicio.Width = 80
        '
        'cFecFinal
        '
        Me.cFecFinal.HeaderText = "Fec. Final"
        Me.cFecFinal.Name = "cFecFinal"
        Me.cFecFinal.Width = 80
        '
        'cHorInicio
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cHorInicio.DefaultCellStyle = DataGridViewCellStyle2
        Me.cHorInicio.HeaderText = "Hora Inicio"
        Me.cHorInicio.Name = "cHorInicio"
        Me.cHorInicio.ReadOnly = True
        Me.cHorInicio.Width = 75
        '
        'cHorFinal
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cHorFinal.DefaultCellStyle = DataGridViewCellStyle3
        Me.cHorFinal.HeaderText = "Hora Final"
        Me.cHorFinal.Name = "cHorFinal"
        Me.cHorFinal.ReadOnly = True
        Me.cHorFinal.Width = 75
        '
        'cObservacion
        '
        Me.cObservacion.HeaderText = "Observacion"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.ReadOnly = True
        Me.cObservacion.Visible = False
        '
        'cPagado
        '
        Me.cPagado.HeaderText = "Pagado"
        Me.cPagado.Name = "cPagado"
        Me.cPagado.Visible = False
        '
        'cIdPerAutoriza
        '
        Me.cIdPerAutoriza.HeaderText = "IdPerAutoriza"
        Me.cIdPerAutoriza.Name = "cIdPerAutoriza"
        Me.cIdPerAutoriza.Visible = False
        '
        'cApeNomAutoriza
        '
        Me.cApeNomAutoriza.HeaderText = "ApeNomAutoriza"
        Me.cApeNomAutoriza.Name = "cApeNomAutoriza"
        Me.cApeNomAutoriza.Visible = False
        '
        'cCodUsu
        '
        Me.cCodUsu.HeaderText = "CodUsu"
        Me.cCodUsu.Name = "cCodUsu"
        Me.cCodUsu.Visible = False
        '
        'cbAtender
        '
        Me.cbAtender.FalseValue = ""
        Me.cbAtender.HeaderText = "Imp"
        Me.cbAtender.Name = "cbAtender"
        Me.cbAtender.Width = 30
        '
        'frmFaltaPersonal_Imprimir
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(771, 324)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFaltaPersonal_Imprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir Faltas de Personal"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbPerAutoriza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miNinguno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMotivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCodArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbPerAutoriza As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cDesEmp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cRucEmp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdFalta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodMotivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdPer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesMotivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecFinal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cHorInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cHorFinal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cPagado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cIdPerAutoriza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNomAutoriza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbAtender As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
