<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBuscarPendientesMasivo
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
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarPendientesMasivo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotalSaldoNS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotalSaldoUS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarCuenta = New System.Windows.Forms.Button()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox()
        Me.chkProveedor = New System.Windows.Forms.CheckBox()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtSerieDoc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodCuenta = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMesRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biInsertar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNinguno = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbSeleccionarTodos = New System.Windows.Forms.CheckBox()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cmOpSeleccionados = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAgregarSeleccionados = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarSeleccionado = New System.Windows.Forms.ToolStripMenuItem()
        Me.miVaciarSeleccionados = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.miProcesarDocs = New System.Windows.Forms.ToolStripMenuItem()
        Me.cIdCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.cSaldoSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSaldoDol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecVen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSeleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cbInsertar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cIdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdHonorario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdCompra2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdCuenta2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodCuenta2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdDocumento2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTipMov2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSerDoc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdProveedor2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDocumento2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesProv2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecDoc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSaldoSol2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSaldoDol2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecVen2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdCliente2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdHonorario2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpSeleccionados.SuspendLayout()
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
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.sslTotalSaldoNS, Me.sslTotalSaldoUS, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 578)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(906, 20)
        Me.ssBarra.TabIndex = 177
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
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarCuenta)
        Me.UiGroupBox1.Controls.Add(Me.txtProveedor)
        Me.UiGroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.UiGroupBox1.Controls.Add(Me.chkProveedor)
        Me.UiGroupBox1.Controls.Add(Me.lblPersona)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarProveedor)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Controls.Add(Me.txtSerieDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipoDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtCodCuenta)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtMesRegistro)
        Me.UiGroupBox1.Controls.Add(Me.txtPeriodo)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.TextBox1)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 33)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(830, 60)
        Me.UiGroupBox1.TabIndex = 227
        Me.UiGroupBox1.Text = "Datos de Busqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarCuenta
        '
        Me.btnBuscarCuenta.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCuenta.Location = New System.Drawing.Point(182, 33)
        Me.btnBuscarCuenta.Name = "btnBuscarCuenta"
        Me.btnBuscarCuenta.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCuenta.TabIndex = 237
        Me.btnBuscarCuenta.TabStop = False
        Me.btnBuscarCuenta.UseVisualStyleBackColor = True
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Window
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(465, 34)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(260, 20)
        Me.txtProveedor.TabIndex = 7
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(633, 16)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 236
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'chkProveedor
        '
        Me.chkProveedor.AutoSize = True
        Me.chkProveedor.Checked = True
        Me.chkProveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkProveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkProveedor.Location = New System.Drawing.Point(612, 18)
        Me.chkProveedor.Name = "chkProveedor"
        Me.chkProveedor.Size = New System.Drawing.Size(15, 14)
        Me.chkProveedor.TabIndex = 235
        Me.chkProveedor.Tag = ""
        Me.chkProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkProveedor.UseVisualStyleBackColor = True
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Location = New System.Drawing.Point(542, 19)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(65, 13)
        Me.lblPersona.TabIndex = 234
        Me.lblPersona.Text = "Proveedor"
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(726, 33)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarProveedor.TabIndex = 233
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(379, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 231
        Me.Label5.Text = "Documento"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(322, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 230
        Me.Label4.Text = "Serie"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(371, 34)
        Me.txtNumDoc.MaxLength = 10
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Numeric = True
        Me.txtNumDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumDoc.Size = New System.Drawing.Size(88, 20)
        Me.txtNumDoc.TabIndex = 6
        '
        'txtSerieDoc
        '
        Me.txtSerieDoc.Location = New System.Drawing.Point(315, 34)
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
        Me.Label3.Location = New System.Drawing.Point(211, 18)
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
        Me.cmbTipoDoc.Location = New System.Drawing.Point(213, 34)
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
        Me.Label2.Location = New System.Drawing.Point(125, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 225
        Me.Label2.Text = "Cuenta"
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.Location = New System.Drawing.Point(114, 34)
        Me.txtCodCuenta.MaxLength = 6
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCodCuenta.Size = New System.Drawing.Size(66, 20)
        Me.txtCodCuenta.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 223
        Me.Label1.Text = "Mes"
        '
        'txtMesRegistro
        '
        Me.txtMesRegistro.Location = New System.Drawing.Point(70, 34)
        Me.txtMesRegistro.MaxLength = 2
        Me.txtMesRegistro.Name = "txtMesRegistro"
        Me.txtMesRegistro.Numeric = True
        Me.txtMesRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMesRegistro.Size = New System.Drawing.Size(38, 20)
        Me.txtMesRegistro.TabIndex = 2
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
        Me.btnBuscar.Location = New System.Drawing.Point(756, 31)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 23)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(756, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(67, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Visible = False
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator8, Me.biActualizar, Me.ToolStripSeparator3, Me.biInsertar, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator5})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(906, 31)
        Me.ToolStrip.TabIndex = 228
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
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdCompra, Me.cIdCuenta, Me.cCodCuenta, Me.cIdDocumento, Me.cTipMov, Me.cSerDoc, Me.cNumDoc, Me.cIdProveedor, Me.cDocumento, Me.cDesProv, Me.cFecDoc, Me.cCodMon, Me.cSaldoSol, Me.cSaldoDol, Me.cFecVen, Me.cSeleccion, Me.cbInsertar, Me.cIdCliente, Me.cIdHonorario})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.Location = New System.Drawing.Point(0, 99)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(834, 261)
        Me.dgvDatos.TabIndex = 230
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodos, Me.miNinguno, Me.ToolStripSeparator1, Me.ToolStripMenuItem1, Me.miActualizar, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(169, 104)
        '
        'miSeleccionarTodos
        '
        Me.miSeleccionarTodos.Image = CType(resources.GetObject("miSeleccionarTodos.Image"), System.Drawing.Image)
        Me.miSeleccionarTodos.Name = "miSeleccionarTodos"
        Me.miSeleccionarTodos.Size = New System.Drawing.Size(168, 22)
        Me.miSeleccionarTodos.Text = "Seleccionar Todos"
        '
        'miNinguno
        '
        Me.miNinguno.Image = CType(resources.GetObject("miNinguno.Image"), System.Drawing.Image)
        Me.miNinguno.Name = "miNinguno"
        Me.miNinguno.Size = New System.Drawing.Size(168, 22)
        Me.miNinguno.Text = "Ninguno"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(165, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(168, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(168, 22)
        Me.miSalir.Text = "Salir"
        '
        'cbSeleccionarTodos
        '
        Me.cbSeleccionarTodos.AutoSize = True
        Me.cbSeleccionarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSeleccionarTodos.Location = New System.Drawing.Point(802, 104)
        Me.cbSeleccionarTodos.Name = "cbSeleccionarTodos"
        Me.cbSeleccionarTodos.Size = New System.Drawing.Size(15, 14)
        Me.cbSeleccionarTodos.TabIndex = 231
        Me.cbSeleccionarTodos.UseVisualStyleBackColor = True
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.AllowUserToDeleteRows = False
        Me.dgvSeleccionados.AllowUserToResizeRows = False
        Me.dgvSeleccionados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSeleccionados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdCompra2, Me.cIdCuenta2, Me.cCodCuenta2, Me.cIdDocumento2, Me.cTipMov2, Me.cSerDoc2, Me.cNumDoc2, Me.cIdProveedor2, Me.cDocumento2, Me.cDesProv2, Me.cFecDoc2, Me.cCodMon2, Me.cSaldoSol2, Me.cSaldoDol2, Me.cFecVen2, Me.cIdCliente2, Me.cIdHonorario2})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmOpSeleccionados
        Me.dgvSeleccionados.Location = New System.Drawing.Point(0, 357)
        Me.dgvSeleccionados.MultiSelect = False
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvSeleccionados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvSeleccionados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSeleccionados.Size = New System.Drawing.Size(834, 211)
        Me.dgvSeleccionados.TabIndex = 232
        '
        'cmOpSeleccionados
        '
        Me.cmOpSeleccionados.Enabled = False
        Me.cmOpSeleccionados.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAgregarSeleccionados, Me.miEliminarSeleccionado, Me.miVaciarSeleccionados, Me.ToolStripSeparator4, Me.miProcesarDocs})
        Me.cmOpSeleccionados.Name = "cmOpciones"
        Me.cmOpSeleccionados.Size = New System.Drawing.Size(231, 98)
        '
        'miAgregarSeleccionados
        '
        Me.miAgregarSeleccionados.Enabled = False
        Me.miAgregarSeleccionados.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.miAgregarSeleccionados.Name = "miAgregarSeleccionados"
        Me.miAgregarSeleccionados.Size = New System.Drawing.Size(230, 22)
        Me.miAgregarSeleccionados.Text = "Agregar Doc(s) seleccionados"
        '
        'miEliminarSeleccionado
        '
        Me.miEliminarSeleccionado.Enabled = False
        Me.miEliminarSeleccionado.Image = Global.SIGECOM.My.Resources.Resources.Borrar
        Me.miEliminarSeleccionado.Name = "miEliminarSeleccionado"
        Me.miEliminarSeleccionado.Size = New System.Drawing.Size(230, 22)
        Me.miEliminarSeleccionado.Text = "Eliminar Documento"
        '
        'miVaciarSeleccionados
        '
        Me.miVaciarSeleccionados.Enabled = False
        Me.miVaciarSeleccionados.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.miVaciarSeleccionados.Name = "miVaciarSeleccionados"
        Me.miVaciarSeleccionados.Size = New System.Drawing.Size(230, 22)
        Me.miVaciarSeleccionados.Text = "Vaciar Listado"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(227, 6)
        '
        'miProcesarDocs
        '
        Me.miProcesarDocs.Enabled = False
        Me.miProcesarDocs.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.miProcesarDocs.Name = "miProcesarDocs"
        Me.miProcesarDocs.Size = New System.Drawing.Size(230, 22)
        Me.miProcesarDocs.Text = "Registrar Documentos"
        '
        'cIdCompra
        '
        Me.cIdCompra.DataPropertyName = "(none)"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cIdCompra.DefaultCellStyle = DataGridViewCellStyle12
        Me.cIdCompra.HeaderText = "IdCompra"
        Me.cIdCompra.Name = "cIdCompra"
        Me.cIdCompra.ReadOnly = True
        Me.cIdCompra.Visible = False
        '
        'cIdCuenta
        '
        Me.cIdCuenta.HeaderText = "IdCuenta"
        Me.cIdCuenta.Name = "cIdCuenta"
        Me.cIdCuenta.Visible = False
        '
        'cCodCuenta
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cCodCuenta.DefaultCellStyle = DataGridViewCellStyle13
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
        Me.cTipMov.HeaderText = "TipMov"
        Me.cTipMov.Name = "cTipMov"
        Me.cTipMov.Visible = False
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
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cDocumento.DefaultCellStyle = DataGridViewCellStyle14
        Me.cDocumento.HeaderText = "Documento"
        Me.cDocumento.Name = "cDocumento"
        Me.cDocumento.ReadOnly = True
        Me.cDocumento.Width = 135
        '
        'cDesProv
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cDesProv.DefaultCellStyle = DataGridViewCellStyle15
        Me.cDesProv.HeaderText = "Proveedor"
        Me.cDesProv.Name = "cDesProv"
        Me.cDesProv.ReadOnly = True
        Me.cDesProv.Width = 205
        '
        'cFecDoc
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cFecDoc.DefaultCellStyle = DataGridViewCellStyle16
        Me.cFecDoc.HeaderText = "Fec Doc"
        Me.cFecDoc.Name = "cFecDoc"
        Me.cFecDoc.ReadOnly = True
        Me.cFecDoc.Width = 75
        '
        'cCodMon
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cCodMon.DefaultCellStyle = DataGridViewCellStyle17
        Me.cCodMon.HeaderText = "Mon."
        Me.cCodMon.Name = "cCodMon"
        Me.cCodMon.ReadOnly = True
        Me.cCodMon.Width = 40
        '
        'cSaldoSol
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cSaldoSol.DefaultCellStyle = DataGridViewCellStyle18
        Me.cSaldoSol.HeaderText = "Saldo NS"
        Me.cSaldoSol.Name = "cSaldoSol"
        Me.cSaldoSol.ReadOnly = True
        Me.cSaldoSol.Width = 80
        '
        'cSaldoDol
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cSaldoDol.DefaultCellStyle = DataGridViewCellStyle19
        Me.cSaldoDol.HeaderText = "Saldo US"
        Me.cSaldoDol.Name = "cSaldoDol"
        Me.cSaldoDol.ReadOnly = True
        Me.cSaldoDol.Width = 80
        '
        'cFecVen
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cFecVen.DefaultCellStyle = DataGridViewCellStyle20
        Me.cFecVen.HeaderText = "Fec Venc"
        Me.cFecVen.Name = "cFecVen"
        Me.cFecVen.ReadOnly = True
        Me.cFecVen.Width = 75
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
        'cIdHonorario
        '
        Me.cIdHonorario.HeaderText = "IdHonorario"
        Me.cIdHonorario.Name = "cIdHonorario"
        Me.cIdHonorario.Visible = False
        '
        'cIdCompra2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cIdCompra2.DefaultCellStyle = DataGridViewCellStyle2
        Me.cIdCompra2.HeaderText = "IdCompra"
        Me.cIdCompra2.Name = "cIdCompra2"
        Me.cIdCompra2.ReadOnly = True
        Me.cIdCompra2.Visible = False
        '
        'cIdCuenta2
        '
        Me.cIdCuenta2.HeaderText = "IdCuenta"
        Me.cIdCuenta2.Name = "cIdCuenta2"
        Me.cIdCuenta2.Visible = False
        '
        'cCodCuenta2
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cCodCuenta2.DefaultCellStyle = DataGridViewCellStyle3
        Me.cCodCuenta2.HeaderText = "Cuenta"
        Me.cCodCuenta2.Name = "cCodCuenta2"
        Me.cCodCuenta2.ReadOnly = True
        Me.cCodCuenta2.Width = 60
        '
        'cIdDocumento2
        '
        Me.cIdDocumento2.DataPropertyName = "cIdDocumento2"
        Me.cIdDocumento2.HeaderText = "IdDocumento"
        Me.cIdDocumento2.Name = "cIdDocumento2"
        Me.cIdDocumento2.ReadOnly = True
        Me.cIdDocumento2.Visible = False
        Me.cIdDocumento2.Width = 80
        '
        'cTipMov2
        '
        Me.cTipMov2.HeaderText = "TipMov"
        Me.cTipMov2.Name = "cTipMov2"
        Me.cTipMov2.Visible = False
        '
        'cSerDoc2
        '
        Me.cSerDoc2.HeaderText = "SerDoc"
        Me.cSerDoc2.Name = "cSerDoc2"
        Me.cSerDoc2.ReadOnly = True
        Me.cSerDoc2.Visible = False
        '
        'cNumDoc2
        '
        Me.cNumDoc2.HeaderText = "NumDoc"
        Me.cNumDoc2.Name = "cNumDoc2"
        Me.cNumDoc2.ReadOnly = True
        Me.cNumDoc2.Visible = False
        '
        'cIdProveedor2
        '
        Me.cIdProveedor2.HeaderText = "IdProveedor"
        Me.cIdProveedor2.Name = "cIdProveedor2"
        Me.cIdProveedor2.ReadOnly = True
        Me.cIdProveedor2.Visible = False
        '
        'cDocumento2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cDocumento2.DefaultCellStyle = DataGridViewCellStyle4
        Me.cDocumento2.HeaderText = "Documento"
        Me.cDocumento2.Name = "cDocumento2"
        Me.cDocumento2.ReadOnly = True
        Me.cDocumento2.Width = 135
        '
        'cDesProv2
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cDesProv2.DefaultCellStyle = DataGridViewCellStyle5
        Me.cDesProv2.HeaderText = "Proveedor"
        Me.cDesProv2.Name = "cDesProv2"
        Me.cDesProv2.ReadOnly = True
        Me.cDesProv2.Width = 205
        '
        'cFecDoc2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cFecDoc2.DefaultCellStyle = DataGridViewCellStyle6
        Me.cFecDoc2.HeaderText = "Fec Doc"
        Me.cFecDoc2.Name = "cFecDoc2"
        Me.cFecDoc2.ReadOnly = True
        Me.cFecDoc2.Width = 75
        '
        'cCodMon2
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cCodMon2.DefaultCellStyle = DataGridViewCellStyle7
        Me.cCodMon2.HeaderText = "Mon."
        Me.cCodMon2.Name = "cCodMon2"
        Me.cCodMon2.ReadOnly = True
        Me.cCodMon2.Width = 40
        '
        'cSaldoSol2
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cSaldoSol2.DefaultCellStyle = DataGridViewCellStyle8
        Me.cSaldoSol2.HeaderText = "Saldo NS"
        Me.cSaldoSol2.Name = "cSaldoSol2"
        Me.cSaldoSol2.ReadOnly = True
        Me.cSaldoSol2.Width = 80
        '
        'cSaldoDol2
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cSaldoDol2.DefaultCellStyle = DataGridViewCellStyle9
        Me.cSaldoDol2.HeaderText = "Saldo US"
        Me.cSaldoDol2.Name = "cSaldoDol2"
        Me.cSaldoDol2.ReadOnly = True
        Me.cSaldoDol2.Width = 80
        '
        'cFecVen2
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cFecVen2.DefaultCellStyle = DataGridViewCellStyle10
        Me.cFecVen2.HeaderText = "Fec Venc"
        Me.cFecVen2.Name = "cFecVen2"
        Me.cFecVen2.ReadOnly = True
        Me.cFecVen2.Width = 75
        '
        'cIdCliente2
        '
        Me.cIdCliente2.HeaderText = "IdCliente"
        Me.cIdCliente2.Name = "cIdCliente2"
        Me.cIdCliente2.Visible = False
        '
        'cIdHonorario2
        '
        Me.cIdHonorario2.HeaderText = "IdHonorario"
        Me.cIdHonorario2.Name = "cIdHonorario2"
        Me.cIdHonorario2.Visible = False
        '
        'frmBuscarPendientesMasivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(906, 598)
        Me.ContextMenuStrip = Me.cmOpciones
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.cbSeleccionarTodos)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarPendientesMasivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Documentos Pendientes"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpSeleccionados.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chkProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtSerieDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodCuenta As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMesRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarCuenta As System.Windows.Forms.Button
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biInsertar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miNinguno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cbSeleccionarTodos As CheckBox
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents sslTotalSaldoNS As ToolStripStatusLabel
    Friend WithEvents sslTotalSaldoUS As ToolStripStatusLabel
    Friend WithEvents dgvSeleccionados As DataGridView
    Friend WithEvents cmOpSeleccionados As ContextMenuStrip
    Friend WithEvents miAgregarSeleccionados As ToolStripMenuItem
    Friend WithEvents miEliminarSeleccionado As ToolStripMenuItem
    Friend WithEvents miVaciarSeleccionados As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents miProcesarDocs As ToolStripMenuItem
    Friend WithEvents cIdCompra2 As DataGridViewTextBoxColumn
    Friend WithEvents cIdCuenta2 As DataGridViewTextBoxColumn
    Friend WithEvents cCodCuenta2 As DataGridViewTextBoxColumn
    Friend WithEvents cIdDocumento2 As DataGridViewTextBoxColumn
    Friend WithEvents cTipMov2 As DataGridViewTextBoxColumn
    Friend WithEvents cSerDoc2 As DataGridViewTextBoxColumn
    Friend WithEvents cNumDoc2 As DataGridViewTextBoxColumn
    Friend WithEvents cIdProveedor2 As DataGridViewTextBoxColumn
    Friend WithEvents cDocumento2 As DataGridViewTextBoxColumn
    Friend WithEvents cDesProv2 As DataGridViewTextBoxColumn
    Friend WithEvents cFecDoc2 As DataGridViewTextBoxColumn
    Friend WithEvents cCodMon2 As DataGridViewTextBoxColumn
    Friend WithEvents cSaldoSol2 As DataGridViewTextBoxColumn
    Friend WithEvents cSaldoDol2 As DataGridViewTextBoxColumn
    Friend WithEvents cFecVen2 As DataGridViewTextBoxColumn
    Friend WithEvents cIdCliente2 As DataGridViewTextBoxColumn
    Friend WithEvents cIdHonorario2 As DataGridViewTextBoxColumn
    Friend WithEvents cIdCompra As DataGridViewTextBoxColumn
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
    Friend WithEvents cSaldoSol As DataGridViewTextBoxColumn
    Friend WithEvents cSaldoDol As DataGridViewTextBoxColumn
    Friend WithEvents cFecVen As DataGridViewTextBoxColumn
    Friend WithEvents cSeleccion As DataGridViewCheckBoxColumn
    Friend WithEvents cbInsertar As DataGridViewCheckBoxColumn
    Friend WithEvents cIdCliente As DataGridViewTextBoxColumn
    Friend WithEvents cIdHonorario As DataGridViewTextBoxColumn
End Class
