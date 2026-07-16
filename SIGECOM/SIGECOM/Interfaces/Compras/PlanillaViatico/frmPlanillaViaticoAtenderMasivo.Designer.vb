<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillaViaticoAtenderMasivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillaViaticoAtenderMasivo))
        Dim cmbCodArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAtender = New System.Windows.Forms.ToolStripButton()
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
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCodArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkPersona = New System.Windows.Forms.CheckBox()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cIdPlanilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAbrPer2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecReg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbAtender = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cProcesado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biImprimir, Me.ToolStripSeparator1, Me.biAtender, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator3})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(819, 31)
        Me.ToolStrip.TabIndex = 47
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator4.Visible = False
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Listado de Provisionales"
        Me.biImprimir.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biAtender
        '
        Me.biAtender.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAtender.Image = Global.SIGECOM.My.Resources.Resources.Pagos
        Me.biAtender.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAtender.Name = "biAtender"
        Me.biAtender.Size = New System.Drawing.Size(28, 28)
        Me.biAtender.Text = "Atender Planillas de Viático Seleccionadas"
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
        Me.ssBarra.Location = New System.Drawing.Point(0, 341)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(819, 20)
        Me.ssBarra.TabIndex = 46
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
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
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.TextBox1)
        Me.UiGroupBox1.Controls.Add(Me.Label12)
        Me.UiGroupBox1.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox1.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox1.Controls.Add(Me.Label13)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.cmbCodArea)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipo)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.chkPersona)
        Me.UiGroupBox1.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox1.Controls.Add(Me.txtNumero)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.lblPersona)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtSolicitante)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPersona)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(788, 60)
        Me.UiGroupBox1.TabIndex = 194
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(716, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(66, 20)
        Me.TextBox1.TabIndex = 196
        Me.TextBox1.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(107, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 231
        Me.Label12.Text = "Fecha Fin"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(93, 33)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.NullButtonText = "Ninguno"
        Me.cbFecFinal.ShowNullButton = True
        Me.cbFecFinal.Size = New System.Drawing.Size(82, 20)
        Me.cbFecFinal.TabIndex = 2
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
        Me.cbFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicio.Location = New System.Drawing.Point(7, 33)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.NullButtonText = "Ninguno"
        Me.cbFecInicio.ShowNullButton = True
        Me.cbFecInicio.Size = New System.Drawing.Size(82, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.TodayButtonText = "Hoy"
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 230
        Me.Label13.Text = "Fecha Inicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(573, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 227
        Me.Label3.Text = "Tipo"
        '
        'cmbCodArea
        '
        Me.cmbCodArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodArea_DesignTimeLayout.LayoutString = resources.GetString("cmbCodArea_DesignTimeLayout.LayoutString")
        Me.cmbCodArea.DesignTimeLayout = cmbCodArea_DesignTimeLayout
        Me.cmbCodArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodArea.Location = New System.Drawing.Point(179, 33)
        Me.cmbCodArea.Name = "cmbCodArea"
        Me.cmbCodArea.SelectedIndex = -1
        Me.cmbCodArea.SelectedItem = Nothing
        Me.cmbCodArea.Size = New System.Drawing.Size(108, 20)
        Me.cmbCodArea.TabIndex = 4
        Me.cmbCodArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbTipo
        '
        Me.cmbTipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipo_DesignTimeLayout.LayoutString")
        Me.cmbTipo.DesignTimeLayout = cmbTipo_DesignTimeLayout
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(539, 33)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.SelectedIndex = -1
        Me.cmbTipo.SelectedItem = Nothing
        Me.cmbTipo.Size = New System.Drawing.Size(98, 20)
        Me.cmbTipo.TabIndex = 7
        Me.cmbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(490, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 13)
        Me.Label9.TabIndex = 118
        Me.Label9.Text = "OT"
        '
        'chkPersona
        '
        Me.chkPersona.AutoSize = True
        Me.chkPersona.Checked = True
        Me.chkPersona.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPersona.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPersona.Location = New System.Drawing.Point(380, 17)
        Me.chkPersona.Name = "chkPersona"
        Me.chkPersona.Size = New System.Drawing.Size(15, 14)
        Me.chkPersona.TabIndex = 222
        Me.chkPersona.Tag = ""
        Me.chkPersona.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkPersona.UseVisualStyleBackColor = True
        '
        'txtNumJob
        '
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.Location = New System.Drawing.Point(467, 33)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(68, 20)
        Me.txtNumJob.TabIndex = 6
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(641, 32)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(72, 20)
        Me.txtNumero.TabIndex = 8
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(716, 30)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(66, 23)
        Me.btnBuscar.TabIndex = 10
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersona.Location = New System.Drawing.Point(324, 17)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(56, 13)
        Me.lblPersona.TabIndex = 221
        Me.lblPersona.Text = "Solicitante"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "Año"
        '
        'txtSolicitante
        '
        Me.txtSolicitante.BackColor = System.Drawing.SystemColors.Window
        Me.txtSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicitante.Location = New System.Drawing.Point(291, 33)
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.ReadOnly = True
        Me.txtSolicitante.Size = New System.Drawing.Size(147, 20)
        Me.txtSolicitante.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(655, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "Numero"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(215, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 218
        Me.Label7.Text = "Area"
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(398, 13)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 223
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(439, 31)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarPersona.TabIndex = 220
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
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
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdPlanilla, Me.cIdPer, Me.cAbrPer2, Me.cCodJob, Me.cCodArea, Me.cDesArea, Me.cFecha, Me.cFecReg, Me.cDescripcion, Me.cCodMon, Me.cMonto, Me.cTipo, Me.cDesTipo, Me.cbAtender, Me.cProcesado})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.Location = New System.Drawing.Point(0, 99)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidth = 25
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(802, 225)
        Me.dgvDatos.TabIndex = 195
        '
        'cIdPlanilla
        '
        Me.cIdPlanilla.HeaderText = "Cod."
        Me.cIdPlanilla.Name = "cIdPlanilla"
        Me.cIdPlanilla.ReadOnly = True
        Me.cIdPlanilla.Width = 50
        '
        'cIdPer
        '
        Me.cIdPer.HeaderText = "IdPer"
        Me.cIdPer.Name = "cIdPer"
        Me.cIdPer.ReadOnly = True
        Me.cIdPer.Visible = False
        '
        'cAbrPer2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cAbrPer2.DefaultCellStyle = DataGridViewCellStyle2
        Me.cAbrPer2.HeaderText = "Colaborador"
        Me.cAbrPer2.Name = "cAbrPer2"
        Me.cAbrPer2.ReadOnly = True
        Me.cAbrPer2.Width = 140
        '
        'cCodJob
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodJob.DefaultCellStyle = DataGridViewCellStyle3
        Me.cCodJob.HeaderText = "OT"
        Me.cCodJob.Name = "cCodJob"
        Me.cCodJob.ReadOnly = True
        Me.cCodJob.Width = 60
        '
        'cCodArea
        '
        Me.cCodArea.HeaderText = "CodArea"
        Me.cCodArea.Name = "cCodArea"
        Me.cCodArea.Visible = False
        Me.cCodArea.Width = 110
        '
        'cDesArea
        '
        Me.cDesArea.HeaderText = "Area"
        Me.cDesArea.Name = "cDesArea"
        Me.cDesArea.Visible = False
        '
        'cFecha
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cFecha.DefaultCellStyle = DataGridViewCellStyle4
        Me.cFecha.HeaderText = "Fecha"
        Me.cFecha.Name = "cFecha"
        Me.cFecha.ReadOnly = True
        Me.cFecha.Width = 73
        '
        'cFecReg
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "d"
        Me.cFecReg.DefaultCellStyle = DataGridViewCellStyle5
        Me.cFecReg.HeaderText = "Fec. Reg."
        Me.cFecReg.Name = "cFecReg"
        Me.cFecReg.Width = 73
        '
        'cDescripcion
        '
        Me.cDescripcion.HeaderText = "Descripción"
        Me.cDescripcion.Name = "cDescripcion"
        Me.cDescripcion.Width = 180
        '
        'cCodMon
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodMon.DefaultCellStyle = DataGridViewCellStyle6
        Me.cCodMon.HeaderText = "Mon"
        Me.cCodMon.Name = "cCodMon"
        Me.cCodMon.Width = 40
        '
        'cMonto
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.cMonto.DefaultCellStyle = DataGridViewCellStyle7
        Me.cMonto.HeaderText = "Monto"
        Me.cMonto.Name = "cMonto"
        Me.cMonto.Width = 80
        '
        'cTipo
        '
        Me.cTipo.HeaderText = "Tipo"
        Me.cTipo.Name = "cTipo"
        Me.cTipo.Visible = False
        Me.cTipo.Width = 85
        '
        'cDesTipo
        '
        Me.cDesTipo.HeaderText = "Tipo"
        Me.cDesTipo.Name = "cDesTipo"
        Me.cDesTipo.Visible = False
        '
        'cbAtender
        '
        Me.cbAtender.FalseValue = ""
        Me.cbAtender.HeaderText = "Atender"
        Me.cbAtender.Name = "cbAtender"
        Me.cbAtender.Width = 60
        '
        'cProcesado
        '
        Me.cProcesado.HeaderText = "Procesado"
        Me.cProcesado.Name = "cProcesado"
        Me.cProcesado.Visible = False
        '
        'frmPlanillaViaticoAtenderMasivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(819, 361)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanillaViaticoAtenderMasivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atender Planilla de Viático Masivo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biAtender As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCodArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkPersona As System.Windows.Forms.CheckBox
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cIdPlanilla As DataGridViewTextBoxColumn
    Friend WithEvents cIdPer As DataGridViewTextBoxColumn
    Friend WithEvents cAbrPer2 As DataGridViewTextBoxColumn
    Friend WithEvents cCodJob As DataGridViewTextBoxColumn
    Friend WithEvents cCodArea As DataGridViewTextBoxColumn
    Friend WithEvents cDesArea As DataGridViewTextBoxColumn
    Friend WithEvents cFecha As DataGridViewTextBoxColumn
    Friend WithEvents cFecReg As DataGridViewTextBoxColumn
    Friend WithEvents cDescripcion As DataGridViewTextBoxColumn
    Friend WithEvents cCodMon As DataGridViewTextBoxColumn
    Friend WithEvents cMonto As DataGridViewTextBoxColumn
    Friend WithEvents cTipo As DataGridViewTextBoxColumn
    Friend WithEvents cDesTipo As DataGridViewTextBoxColumn
    Friend WithEvents cbAtender As DataGridViewCheckBoxColumn
    Friend WithEvents cProcesado As DataGridViewCheckBoxColumn
End Class
