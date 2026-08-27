<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiarioBuscarDocTesoreria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiarioBuscarDocTesoreria))
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biInsertar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotalSaldoNS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotalSaldoUS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miInsertar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeleccionarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNinguno = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.btnBuscarCuenta = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtSerieDoc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodCuenta = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cIdTesoreria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdTesoreriaDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTipMov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSerDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesProv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoDol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSeleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cbInsertar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cIdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbSeleccionarTodos = New System.Windows.Forms.CheckBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator8, Me.biActualizar, Me.ToolStripSeparator3, Me.biInsertar, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator5})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(874, 31)
        Me.ToolStrip.TabIndex = 230
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
        Me.biInsertar.Text = "Insertar Pendientes Seleccionado(s)"
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.sslTotalSaldoNS, Me.sslTotalSaldoUS, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 562)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(874, 20)
        Me.ssBarra.TabIndex = 229
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.AutoSize = False
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(100, 15)
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sslTotalSaldoNS
        '
        Me.sslTotalSaldoNS.AutoSize = False
        Me.sslTotalSaldoNS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotalSaldoNS.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotalSaldoNS.Name = "sslTotalSaldoNS"
        Me.sslTotalSaldoNS.Size = New System.Drawing.Size(250, 15)
        Me.sslTotalSaldoNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sslTotalSaldoUS
        '
        Me.sslTotalSaldoUS.AutoSize = False
        Me.sslTotalSaldoUS.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotalSaldoUS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotalSaldoUS.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotalSaldoUS.Name = "sslTotalSaldoUS"
        Me.sslTotalSaldoUS.Size = New System.Drawing.Size(250, 15)
        Me.sslTotalSaldoUS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miInsertar, Me.miSeleccionarTodos, Me.miNinguno, Me.ToolStripSeparator1, Me.ToolStripMenuItem1, Me.miActualizar, Me.miSalir})
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(224, 6)
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
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.txtProveedor)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarCuenta)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Controls.Add(Me.txtSerieDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipoDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtCodCuenta)
        Me.UiGroupBox1.Controls.Add(Me.txtPeriodo)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(830, 60)
        Me.UiGroupBox1.TabIndex = 231
        Me.UiGroupBox1.Text = "Datos de Busqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(362, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 241
        Me.Label6.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(276, 34)
        Me.txtProveedor.MaxLength = 0
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtProveedor.Size = New System.Drawing.Size(247, 20)
        Me.txtProveedor.TabIndex = 240
        '
        'btnBuscarCuenta
        '
        Me.btnBuscarCuenta.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCuenta.Location = New System.Drawing.Point(140, 33)
        Me.btnBuscarCuenta.Name = "btnBuscarCuenta"
        Me.btnBuscarCuenta.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCuenta.TabIndex = 237
        Me.btnBuscarCuenta.TabStop = False
        Me.btnBuscarCuenta.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(595, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 231
        Me.Label5.Text = "Documento"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(538, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 230
        Me.Label4.Text = "Serie"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(587, 34)
        Me.txtNumDoc.MaxLength = 10
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Numeric = True
        Me.txtNumDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumDoc.Size = New System.Drawing.Size(88, 20)
        Me.txtNumDoc.TabIndex = 6
        '
        'txtSerieDoc
        '
        Me.txtSerieDoc.Location = New System.Drawing.Point(531, 34)
        Me.txtSerieDoc.MaxLength = 4
        Me.txtSerieDoc.Name = "txtSerieDoc"
        Me.txtSerieDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSerieDoc.Size = New System.Drawing.Size(50, 20)
        Me.txtSerieDoc.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(169, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 227
        Me.Label3.Text = "Tipo Documento"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Location = New System.Drawing.Point(171, 34)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(96, 20)
        Me.cmbTipoDoc.TabIndex = 4
        Me.cmbTipoDoc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(83, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 225
        Me.Label2.Text = "Cuenta"
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.Location = New System.Drawing.Point(72, 34)
        Me.txtCodCuenta.MaxLength = 6
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCodCuenta.Size = New System.Drawing.Size(66, 20)
        Me.txtCodCuenta.TabIndex = 3
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(6, 34)
        Me.txtPeriodo.Maximum = 2059
        Me.txtPeriodo.Minimum = 2006
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
        Me.txtPeriodo.TabIndex = 1
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.Value = 2006
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 221
        Me.Label7.Text = "Periodo"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(680, 31)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 23)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
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
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdTesoreria, Me.cIdTesoreriaDet, Me.cIdCuenta, Me.cCodCuenta, Me.cIdDocumento, Me.cTipMov, Me.cSerDoc, Me.cNumDoc, Me.cIdProveedor, Me.cDocumento, Me.cDesProv, Me.cFecDoc, Me.cCodMon, Me.cMontoSol, Me.cMontoDol, Me.cSeleccion, Me.cbInsertar, Me.cIdCliente, Me.cIdPer})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.Location = New System.Drawing.Point(12, 100)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(826, 432)
        Me.dgvDatos.TabIndex = 232
        '
        'cIdTesoreria
        '
        Me.cIdTesoreria.HeaderText = "IdTesoreria"
        Me.cIdTesoreria.Name = "cIdTesoreria"
        Me.cIdTesoreria.ReadOnly = True
        Me.cIdTesoreria.Visible = False
        '
        'cIdTesoreriaDet
        '
        Me.cIdTesoreriaDet.DataPropertyName = "(none)"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cIdTesoreriaDet.DefaultCellStyle = DataGridViewCellStyle2
        Me.cIdTesoreriaDet.HeaderText = "IdTesoreriaDet"
        Me.cIdTesoreriaDet.Name = "cIdTesoreriaDet"
        Me.cIdTesoreriaDet.ReadOnly = True
        Me.cIdTesoreriaDet.Visible = False
        '
        'cIdCuenta
        '
        Me.cIdCuenta.HeaderText = "IdCuenta"
        Me.cIdCuenta.Name = "cIdCuenta"
        Me.cIdCuenta.Visible = False
        '
        'cCodCuenta
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cCodCuenta.DefaultCellStyle = DataGridViewCellStyle3
        Me.cCodCuenta.HeaderText = "Cuenta"
        Me.cCodCuenta.Name = "cCodCuenta"
        Me.cCodCuenta.ReadOnly = True
        Me.cCodCuenta.Width = 60
        '
        'cIdDocumento
        '
        Me.cIdDocumento.HeaderText = "IdDocumento"
        Me.cIdDocumento.Name = "cIdDocumento"
        Me.cIdDocumento.ReadOnly = True
        Me.cIdDocumento.Visible = False
        Me.cIdDocumento.Width = 80
        '
        'cTipMov
        '
        Me.cTipMov.HeaderText = "Mov"
        Me.cTipMov.Name = "cTipMov"
        Me.cTipMov.Width = 30
        '
        'cSerDoc
        '
        Me.cSerDoc.HeaderText = "SerDoc"
        Me.cSerDoc.Name = "cSerDoc"
        Me.cSerDoc.ReadOnly = True
        Me.cSerDoc.Visible = False
        '
        'cNumDoc
        '
        Me.cNumDoc.HeaderText = "NumDoc"
        Me.cNumDoc.Name = "cNumDoc"
        Me.cNumDoc.ReadOnly = True
        Me.cNumDoc.Visible = False
        '
        'cIdProveedor
        '
        Me.cIdProveedor.HeaderText = "IdProveedor"
        Me.cIdProveedor.Name = "cIdProveedor"
        Me.cIdProveedor.ReadOnly = True
        Me.cIdProveedor.Visible = False
        '
        'cDocumento
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cDocumento.DefaultCellStyle = DataGridViewCellStyle4
        Me.cDocumento.HeaderText = "Documento"
        Me.cDocumento.Name = "cDocumento"
        Me.cDocumento.ReadOnly = True
        Me.cDocumento.Width = 135
        '
        'cDesProv
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cDesProv.DefaultCellStyle = DataGridViewCellStyle5
        Me.cDesProv.HeaderText = "Proveedor"
        Me.cDesProv.Name = "cDesProv"
        Me.cDesProv.ReadOnly = True
        Me.cDesProv.Width = 205
        '
        'cFecDoc
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cFecDoc.DefaultCellStyle = DataGridViewCellStyle6
        Me.cFecDoc.HeaderText = "Fec Doc"
        Me.cFecDoc.Name = "cFecDoc"
        Me.cFecDoc.ReadOnly = True
        Me.cFecDoc.Width = 75
        '
        'cCodMon
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cCodMon.DefaultCellStyle = DataGridViewCellStyle7
        Me.cCodMon.HeaderText = "Mon."
        Me.cCodMon.Name = "cCodMon"
        Me.cCodMon.ReadOnly = True
        Me.cCodMon.Width = 40
        '
        'cMontoSol
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cMontoSol.DefaultCellStyle = DataGridViewCellStyle8
        Me.cMontoSol.HeaderText = "Monto NS"
        Me.cMontoSol.Name = "cMontoSol"
        Me.cMontoSol.ReadOnly = True
        Me.cMontoSol.Width = 80
        '
        'cMontoDol
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cMontoDol.DefaultCellStyle = DataGridViewCellStyle9
        Me.cMontoDol.HeaderText = "Monto US"
        Me.cMontoDol.Name = "cMontoDol"
        Me.cMontoDol.ReadOnly = True
        Me.cMontoDol.Width = 80
        '
        'cSeleccion
        '
        Me.cSeleccion.HeaderText = "Seleccion"
        Me.cSeleccion.Name = "cSeleccion"
        Me.cSeleccion.ReadOnly = True
        Me.cSeleccion.Visible = False
        '
        'cbInsertar
        '
        Me.cbInsertar.FalseValue = ""
        Me.cbInsertar.HeaderText = ""
        Me.cbInsertar.Name = "cbInsertar"
        Me.cbInsertar.Width = 35
        '
        'cIdCliente
        '
        Me.cIdCliente.HeaderText = "IdCliente"
        Me.cIdCliente.Name = "cIdCliente"
        Me.cIdCliente.Visible = False
        '
        'cIdPer
        '
        Me.cIdPer.HeaderText = "IdPer"
        Me.cIdPer.Name = "cIdPer"
        Me.cIdPer.Visible = False
        '
        'cbSeleccionarTodos
        '
        Me.cbSeleccionarTodos.AutoSize = True
        Me.cbSeleccionarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSeleccionarTodos.Location = New System.Drawing.Point(770, 105)
        Me.cbSeleccionarTodos.Name = "cbSeleccionarTodos"
        Me.cbSeleccionarTodos.Size = New System.Drawing.Size(15, 14)
        Me.cbSeleccionarTodos.TabIndex = 233
        Me.cbSeleccionarTodos.UseVisualStyleBackColor = True
        '
        'frmDiarioBuscarDocTesoreria
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(874, 582)
        Me.Controls.Add(Me.cbSeleccionarTodos)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiarioBuscarDocTesoreria"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Documentos Tesoreria"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents biActualizar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents biInsertar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents biSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ssBarra As StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents sslTotalSaldoNS As ToolStripStatusLabel
    Friend WithEvents sslTotalSaldoUS As ToolStripStatusLabel
    Friend WithEvents sslTotal As ToolStripStatusLabel
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miInsertar As ToolStripMenuItem
    Friend WithEvents miSeleccionarTodos As ToolStripMenuItem
    Friend WithEvents miNinguno As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents miActualizar As ToolStripMenuItem
    Friend WithEvents miSalir As ToolStripMenuItem
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents btnBuscarCuenta As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNumDoc As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtSerieDoc As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCodCuenta As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents dgvDatos As DataGridView
    Friend WithEvents cbSeleccionarTodos As CheckBox
    Friend WithEvents cIdTesoreria As DataGridViewTextBoxColumn
    Friend WithEvents cIdTesoreriaDet As DataGridViewTextBoxColumn
    Friend WithEvents cIdCuenta As DataGridViewTextBoxColumn
    Friend WithEvents cCodCuenta As DataGridViewTextBoxColumn
    Friend WithEvents cIdDocumento As DataGridViewTextBoxColumn
    Friend WithEvents cTipMov As DataGridViewTextBoxColumn
    Friend WithEvents cSerDoc As DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc As DataGridViewTextBoxColumn
    Friend WithEvents cIdProveedor As DataGridViewTextBoxColumn
    Friend WithEvents cDocumento As DataGridViewTextBoxColumn
    Friend WithEvents cDesProv As DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc As DataGridViewTextBoxColumn
    Friend WithEvents cCodMon As DataGridViewTextBoxColumn
    Friend WithEvents cMontoSol As DataGridViewTextBoxColumn
    Friend WithEvents cMontoDol As DataGridViewTextBoxColumn
    Friend WithEvents cSeleccion As DataGridViewCheckBoxColumn
    Friend WithEvents cbInsertar As DataGridViewCheckBoxColumn
    Friend WithEvents cIdCliente As DataGridViewTextBoxColumn
    Friend WithEvents cIdPer As DataGridViewTextBoxColumn
End Class
