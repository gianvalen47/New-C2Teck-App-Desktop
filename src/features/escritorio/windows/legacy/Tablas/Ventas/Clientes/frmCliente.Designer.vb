<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCliente
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
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCliente))
        Dim cmbMedioContacto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodSec_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdTipoCon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdTipoCliente_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbPrecios = New System.Windows.Forms.GroupBox()
        Me.txtHoraPago = New System.Windows.Forms.TextBox()
        Me.txtDiaPago = New System.Windows.Forms.TextBox()
        Me.txtNumCta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbSubDatos1 = New System.Windows.Forms.GroupBox()
        Me.cbAprCli = New System.Windows.Forms.CheckBox()
        Me.cbListaCli = New System.Windows.Forms.CheckBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.txtDesCli = New System.Windows.Forms.TextBox()
        Me.txtAbrCli = New System.Windows.Forms.TextBox()
        Me.txtNroDoc = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDueCli = New System.Windows.Forms.TextBox()
        Me.txtTelCli = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFaxCli = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtUrlCli = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtObsCli = New System.Windows.Forms.TextBox()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.btnConsultaSunat = New System.Windows.Forms.Button()
        Me.cbAgente = New System.Windows.Forms.CheckBox()
        Me.lblAstTipDoc = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtDniCli = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMedioContacto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gbcredito = New System.Windows.Forms.GroupBox()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtLimitecredito = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lbllimitecredito = New System.Windows.Forms.Label()
        Me.lblAstTelef = New System.Windows.Forms.Label()
        Me.txtFecIng = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblAstApeMat = New System.Windows.Forms.Label()
        Me.lblAstApePat = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblAstDni = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblAstRazSoc = New System.Windows.Forms.Label()
        Me.lblAstNombre = New System.Windows.Forms.Label()
        Me.lblAstTipCon = New System.Windows.Forms.Label()
        Me.lblAstRuc = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblApeMat = New System.Windows.Forms.Label()
        Me.lblApePat = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtApeMat = New System.Windows.Forms.TextBox()
        Me.txtApePat = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.cmbCodSec = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbIdTipoCon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbIdTipoCliente = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.tabVentanas = New Janus.Windows.UI.Tab.UITab()
        Me.tabpContactos = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAgregarContacto = New System.Windows.Forms.Button()
        Me.dgvContactos = New System.Windows.Forms.DataGridView()
        Me.cIdContacto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApellidos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabpDireccionesFiscales = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAgregarDireccionFiscal = New System.Windows.Forms.Button()
        Me.dgvDireccionesFiscales = New System.Windows.Forms.DataGridView()
        Me.cIdFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDireccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabpLocaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAgregarLocacion = New System.Windows.Forms.Button()
        Me.dgvLocaciones = New System.Windows.Forms.DataGridView()
        Me.cIdLocCli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabpCondicionesPago = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAgregarCondicionPago = New System.Windows.Forms.Button()
        Me.dgvCondicionesPago = New System.Windows.Forms.DataGridView()
        Me.cDesRub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesPag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDiaPag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodRub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodPag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabpVendedores = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvVendedores = New System.Windows.Forms.DataGridView()
        Me.cIdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesVen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecAsig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabMoneda = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvMoneda = New System.Windows.Forms.DataGridView()
        Me.DesOfi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdLocacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesAlm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbOpciones2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminarLocMoneda = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnActivar = New System.Windows.Forms.Button()
        Me.TabUsuario = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnActCorreo = New System.Windows.Forms.Button()
        Me.btnGenerarUsuario = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPrecios.SuspendLayout()
        Me.gbSubDatos1.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMedioContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbcredito.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodSec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdTipoCon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdTipoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabVentanas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabVentanas.SuspendLayout()
        Me.tabpContactos.SuspendLayout()
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.tabpDireccionesFiscales.SuspendLayout()
        CType(Me.dgvDireccionesFiscales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpLocaciones.SuspendLayout()
        CType(Me.dgvLocaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpCondicionesPago.SuspendLayout()
        CType(Me.dgvCondicionesPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpVendedores.SuspendLayout()
        CType(Me.dgvVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMoneda.SuspendLayout()
        CType(Me.dgvMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones2.SuspendLayout()
        Me.TabUsuario.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbPrecios
        '
        Me.gbPrecios.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbPrecios.Controls.Add(Me.txtHoraPago)
        Me.gbPrecios.Controls.Add(Me.txtDiaPago)
        Me.gbPrecios.Controls.Add(Me.txtNumCta)
        Me.gbPrecios.Controls.Add(Me.Label8)
        Me.gbPrecios.Controls.Add(Me.Label6)
        Me.gbPrecios.Controls.Add(Me.Label5)
        Me.gbPrecios.Location = New System.Drawing.Point(6, 305)
        Me.gbPrecios.Name = "gbPrecios"
        Me.gbPrecios.Size = New System.Drawing.Size(641, 42)
        Me.gbPrecios.TabIndex = 17
        Me.gbPrecios.TabStop = False
        Me.gbPrecios.Text = "Condiciones de Pago"
        Me.gbPrecios.Visible = False
        '
        'txtHoraPago
        '
        Me.txtHoraPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHoraPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraPago.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtHoraPago.Location = New System.Drawing.Point(503, 16)
        Me.txtHoraPago.MaxLength = 20
        Me.txtHoraPago.Name = "txtHoraPago"
        Me.txtHoraPago.Size = New System.Drawing.Size(131, 20)
        Me.txtHoraPago.TabIndex = 3
        '
        'txtDiaPago
        '
        Me.txtDiaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiaPago.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtDiaPago.Location = New System.Drawing.Point(292, 16)
        Me.txtDiaPago.MaxLength = 20
        Me.txtDiaPago.Name = "txtDiaPago"
        Me.txtDiaPago.Size = New System.Drawing.Size(141, 20)
        Me.txtDiaPago.TabIndex = 2
        '
        'txtNumCta
        '
        Me.txtNumCta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumCta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCta.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtNumCta.Location = New System.Drawing.Point(74, 16)
        Me.txtNumCta.MaxLength = 20
        Me.txtNumCta.Name = "txtNumCta"
        Me.txtNumCta.Size = New System.Drawing.Size(150, 20)
        Me.txtNumCta.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Nº Cuenta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(439, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Hora Pago"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(233, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Día Pago"
        '
        'gbSubDatos1
        '
        Me.gbSubDatos1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbSubDatos1.Controls.Add(Me.cbAprCli)
        Me.gbSubDatos1.Location = New System.Drawing.Point(499, 184)
        Me.gbSubDatos1.Name = "gbSubDatos1"
        Me.gbSubDatos1.Size = New System.Drawing.Size(177, 31)
        Me.gbSubDatos1.TabIndex = 16
        Me.gbSubDatos1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.gbSubDatos1, "Si la opción esta habilitada el cliente" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "tiene aprobación automática")
        Me.gbSubDatos1.Visible = False
        '
        'cbAprCli
        '
        Me.cbAprCli.AutoSize = True
        Me.cbAprCli.Location = New System.Drawing.Point(7, 9)
        Me.cbAprCli.Name = "cbAprCli"
        Me.cbAprCli.Size = New System.Drawing.Size(176, 17)
        Me.cbAprCli.TabIndex = 0
        Me.cbAprCli.TabStop = False
        Me.cbAprCli.Text = "¿Tiene aprobación de créditos?"
        Me.ToolTip1.SetToolTip(Me.cbAprCli, "Si la opción esta habilitada el cliente" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "tiene aprobación automática")
        Me.cbAprCli.UseVisualStyleBackColor = True
        '
        'cbListaCli
        '
        Me.cbListaCli.AutoSize = True
        Me.cbListaCli.Location = New System.Drawing.Point(311, 271)
        Me.cbListaCli.Name = "cbListaCli"
        Me.cbListaCli.Size = New System.Drawing.Size(111, 17)
        Me.cbListaCli.TabIndex = 1
        Me.cbListaCli.TabStop = False
        Me.cbListaCli.Text = "Tiene lista precios"
        Me.cbListaCli.UseVisualStyleBackColor = True
        Me.cbListaCli.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(492, 61)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 13)
        Me.Label24.TabIndex = 29
        Me.Label24.Text = "Abreviatura"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(492, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Nro. Doc."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(492, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "D.N.I."
        Me.Label13.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(492, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Teléfono"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(492, 124)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Página Web"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Tipo Contribuyente"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Tipo Cliente"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 169)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Email"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Código"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(4, 61)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblRazonSocial.TabIndex = 23
        Me.lblRazonSocial.Text = "Razón Social"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(4, 209)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 13)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Observación"
        '
        'txtIdCliente
        '
        Me.txtIdCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdCliente.Location = New System.Drawing.Point(110, 16)
        Me.txtIdCliente.MaxLength = 30
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(123, 20)
        Me.txtIdCliente.TabIndex = 0
        Me.txtIdCliente.TabStop = False
        '
        'txtDesCli
        '
        Me.txtDesCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesCli.Location = New System.Drawing.Point(110, 58)
        Me.txtDesCli.MaxLength = 120
        Me.txtDesCli.Name = "txtDesCli"
        Me.txtDesCli.Size = New System.Drawing.Size(368, 20)
        Me.txtDesCli.TabIndex = 3
        '
        'txtAbrCli
        '
        Me.txtAbrCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbrCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbrCli.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtAbrCli.Location = New System.Drawing.Point(561, 58)
        Me.txtAbrCli.MaxLength = 20
        Me.txtAbrCli.Name = "txtAbrCli"
        Me.txtAbrCli.Size = New System.Drawing.Size(115, 20)
        Me.txtAbrCli.TabIndex = 4
        Me.txtAbrCli.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNroDoc
        '
        Me.txtNroDoc.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtNroDoc.Location = New System.Drawing.Point(561, 37)
        Me.txtNroDoc.MaxLength = 11
        Me.txtNroDoc.Name = "txtNroDoc"
        Me.txtNroDoc.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull
        Me.txtNroDoc.Size = New System.Drawing.Size(115, 20)
        Me.txtNroDoc.TabIndex = 2
        Me.txtNroDoc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtNroDoc.UseCompatibleTextRendering = False
        Me.txtNroDoc.Value = CType(resources.GetObject("txtNroDoc.Value"), Object)
        Me.txtNroDoc.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Dueño"
        '
        'txtDueCli
        '
        Me.txtDueCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDueCli.Location = New System.Drawing.Point(110, 142)
        Me.txtDueCli.MaxLength = 50
        Me.txtDueCli.Name = "txtDueCli"
        Me.txtDueCli.Size = New System.Drawing.Size(253, 20)
        Me.txtDueCli.TabIndex = 14
        '
        'txtTelCli
        '
        Me.txtTelCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelCli.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTelCli.Location = New System.Drawing.Point(561, 79)
        Me.txtTelCli.MaxLength = 20
        Me.txtTelCli.Name = "txtTelCli"
        Me.txtTelCli.Size = New System.Drawing.Size(115, 20)
        Me.txtTelCli.TabIndex = 6
        Me.txtTelCli.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(367, 146)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Fax"
        '
        'txtFaxCli
        '
        Me.txtFaxCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFaxCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxCli.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtFaxCli.Location = New System.Drawing.Point(421, 142)
        Me.txtFaxCli.MaxLength = 20
        Me.txtFaxCli.Name = "txtFaxCli"
        Me.txtFaxCli.Size = New System.Drawing.Size(87, 20)
        Me.txtFaxCli.TabIndex = 15
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtEmail.Location = New System.Drawing.Point(110, 163)
        Me.txtEmail.MaxLength = 20
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(253, 20)
        Me.txtEmail.TabIndex = 16
        '
        'txtUrlCli
        '
        Me.txtUrlCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUrlCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUrlCli.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtUrlCli.Location = New System.Drawing.Point(561, 121)
        Me.txtUrlCli.MaxLength = 20
        Me.txtUrlCli.Name = "txtUrlCli"
        Me.txtUrlCli.Size = New System.Drawing.Size(115, 20)
        Me.txtUrlCli.TabIndex = 10
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(367, 166)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Sector"
        '
        'txtObsCli
        '
        Me.txtObsCli.Location = New System.Drawing.Point(110, 206)
        Me.txtObsCli.Multiline = True
        Me.txtObsCli.Name = "txtObsCli"
        Me.txtObsCli.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObsCli.Size = New System.Drawing.Size(380, 39)
        Me.txtObsCli.TabIndex = 20
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.lblMensaje)
        Me.gbDatos.Controls.Add(Me.btnConsultaSunat)
        Me.gbDatos.Controls.Add(Me.cbAgente)
        Me.gbDatos.Controls.Add(Me.cbListaCli)
        Me.gbDatos.Controls.Add(Me.lblAstTipDoc)
        Me.gbDatos.Controls.Add(Me.Label25)
        Me.gbDatos.Controls.Add(Me.cmbTipoDoc)
        Me.gbDatos.Controls.Add(Me.txtDniCli)
        Me.gbDatos.Controls.Add(Me.txtTelCli)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.cmbMedioContacto)
        Me.gbDatos.Controls.Add(Me.Label12)
        Me.gbDatos.Controls.Add(Me.gbcredito)
        Me.gbDatos.Controls.Add(Me.lblAstTelef)
        Me.gbDatos.Controls.Add(Me.txtFecIng)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.lblAstApeMat)
        Me.gbDatos.Controls.Add(Me.lblAstApePat)
        Me.gbDatos.Controls.Add(Me.lblEstado)
        Me.gbDatos.Controls.Add(Me.cmbEstado)
        Me.gbDatos.Controls.Add(Me.Label23)
        Me.gbDatos.Controls.Add(Me.lblAstDni)
        Me.gbDatos.Controls.Add(Me.Label22)
        Me.gbDatos.Controls.Add(Me.lblAstRazSoc)
        Me.gbDatos.Controls.Add(Me.lblAstNombre)
        Me.gbDatos.Controls.Add(Me.lblAstTipCon)
        Me.gbDatos.Controls.Add(Me.lblAstRuc)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.lblApeMat)
        Me.gbDatos.Controls.Add(Me.lblApePat)
        Me.gbDatos.Controls.Add(Me.lblNombre)
        Me.gbDatos.Controls.Add(Me.txtApeMat)
        Me.gbDatos.Controls.Add(Me.txtApePat)
        Me.gbDatos.Controls.Add(Me.txtNombre)
        Me.gbDatos.Controls.Add(Me.cmbCodSec)
        Me.gbDatos.Controls.Add(Me.cmbIdTipoCon)
        Me.gbDatos.Controls.Add(Me.cmbIdTipoCliente)
        Me.gbDatos.Controls.Add(Me.txtObsCli)
        Me.gbDatos.Controls.Add(Me.Label18)
        Me.gbDatos.Controls.Add(Me.txtUrlCli)
        Me.gbDatos.Controls.Add(Me.txtEmail)
        Me.gbDatos.Controls.Add(Me.txtFaxCli)
        Me.gbDatos.Controls.Add(Me.Label15)
        Me.gbDatos.Controls.Add(Me.txtDueCli)
        Me.gbDatos.Controls.Add(Me.Label11)
        Me.gbDatos.Controls.Add(Me.txtNroDoc)
        Me.gbDatos.Controls.Add(Me.txtAbrCli)
        Me.gbDatos.Controls.Add(Me.txtDesCli)
        Me.gbDatos.Controls.Add(Me.txtIdCliente)
        Me.gbDatos.Controls.Add(Me.Label21)
        Me.gbDatos.Controls.Add(Me.lblRazonSocial)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label16)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.Label17)
        Me.gbDatos.Controls.Add(Me.Label14)
        Me.gbDatos.Controls.Add(Me.Label13)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Controls.Add(Me.Label24)
        Me.gbDatos.Controls.Add(Me.gbSubDatos1)
        Me.gbDatos.Controls.Add(Me.gbPrecios)
        Me.gbDatos.Location = New System.Drawing.Point(6, 33)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(683, 298)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Cliente"
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.ForeColor = System.Drawing.Color.Red
        Me.lblMensaje.Location = New System.Drawing.Point(364, 11)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(0, 13)
        Me.lblMensaje.TabIndex = 75
        '
        'btnConsultaSunat
        '
        Me.btnConsultaSunat.Location = New System.Drawing.Point(564, 8)
        Me.btnConsultaSunat.Name = "btnConsultaSunat"
        Me.btnConsultaSunat.Size = New System.Drawing.Size(108, 23)
        Me.btnConsultaSunat.TabIndex = 74
        Me.btnConsultaSunat.Text = "Consulta en Linea"
        Me.btnConsultaSunat.UseVisualStyleBackColor = True
        Me.btnConsultaSunat.Visible = False
        '
        'cbAgente
        '
        Me.cbAgente.AutoSize = True
        Me.cbAgente.Location = New System.Drawing.Point(139, 270)
        Me.cbAgente.Name = "cbAgente"
        Me.cbAgente.Size = New System.Drawing.Size(113, 17)
        Me.cbAgente.TabIndex = 71
        Me.cbAgente.TabStop = False
        Me.cbAgente.Text = "Agente Retenedor"
        Me.cbAgente.UseVisualStyleBackColor = True
        '
        'lblAstTipDoc
        '
        Me.lblAstTipDoc.AutoSize = True
        Me.lblAstTipDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstTipDoc.ForeColor = System.Drawing.Color.Red
        Me.lblAstTipDoc.Location = New System.Drawing.Point(386, 40)
        Me.lblAstTipDoc.Name = "lblAstTipDoc"
        Me.lblAstTipDoc.Size = New System.Drawing.Size(12, 13)
        Me.lblAstTipDoc.TabIndex = 70
        Me.lblAstTipDoc.Text = "*"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(329, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(54, 13)
        Me.Label25.TabIndex = 69
        Me.Label25.Text = "Tipo Doc."
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDoc.Location = New System.Drawing.Point(399, 37)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(79, 19)
        Me.cmbTipoDoc.TabIndex = 68
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDniCli
        '
        Me.txtDniCli.Location = New System.Drawing.Point(561, 100)
        Me.txtDniCli.MaxLength = 20
        Me.txtDniCli.Name = "txtDniCli"
        Me.txtDniCli.Size = New System.Drawing.Size(115, 20)
        Me.txtDniCli.TabIndex = 8
        Me.txtDniCli.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDniCli.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(332, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "*"
        '
        'cmbMedioContacto
        '
        Me.cmbMedioContacto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMedioContacto_DesignTimeLayout.LayoutString = resources.GetString("cmbMedioContacto_DesignTimeLayout.LayoutString")
        Me.cmbMedioContacto.DesignTimeLayout = cmbMedioContacto_DesignTimeLayout
        Me.cmbMedioContacto.Location = New System.Drawing.Point(344, 184)
        Me.cmbMedioContacto.Name = "cmbMedioContacto"
        Me.cmbMedioContacto.SelectedIndex = -1
        Me.cmbMedioContacto.SelectedItem = Nothing
        Me.cmbMedioContacto.Size = New System.Drawing.Size(134, 20)
        Me.cmbMedioContacto.TabIndex = 19
        Me.cmbMedioContacto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(238, 188)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 13)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Medio de contacto"
        '
        'gbcredito
        '
        Me.gbcredito.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbcredito.Controls.Add(Me.cmbMoneda)
        Me.gbcredito.Controls.Add(Me.txtLimitecredito)
        Me.gbcredito.Controls.Add(Me.lbllimitecredito)
        Me.gbcredito.Location = New System.Drawing.Point(428, 251)
        Me.gbcredito.Name = "gbcredito"
        Me.gbcredito.Size = New System.Drawing.Size(248, 41)
        Me.gbcredito.TabIndex = 58
        Me.gbcredito.TabStop = False
        Me.gbcredito.Visible = False
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(186, 13)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(50, 20)
        Me.cmbMoneda.TabIndex = 59
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.Visible = False
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtLimitecredito
        '
        Me.txtLimitecredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimitecredito.Location = New System.Drawing.Point(89, 13)
        Me.txtLimitecredito.MaxLength = 10
        Me.txtLimitecredito.Name = "txtLimitecredito"
        Me.txtLimitecredito.Size = New System.Drawing.Size(95, 20)
        Me.txtLimitecredito.TabIndex = 56
        Me.txtLimitecredito.Text = "0.00"
        Me.txtLimitecredito.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtLimitecredito.Visible = False
        Me.txtLimitecredito.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbllimitecredito
        '
        Me.lbllimitecredito.AutoSize = True
        Me.lbllimitecredito.Location = New System.Drawing.Point(12, 16)
        Me.lbllimitecredito.Name = "lbllimitecredito"
        Me.lbllimitecredito.Size = New System.Drawing.Size(75, 13)
        Me.lbllimitecredito.TabIndex = 57
        Me.lbllimitecredito.Text = "Limite crédito :"
        Me.lbllimitecredito.Visible = False
        '
        'lblAstTelef
        '
        Me.lblAstTelef.AutoSize = True
        Me.lblAstTelef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstTelef.ForeColor = System.Drawing.Color.Red
        Me.lblAstTelef.Location = New System.Drawing.Point(550, 79)
        Me.lblAstTelef.Name = "lblAstTelef"
        Me.lblAstTelef.Size = New System.Drawing.Size(12, 13)
        Me.lblAstTelef.TabIndex = 50
        Me.lblAstTelef.Text = "*"
        '
        'txtFecIng
        '
        Me.txtFecIng.BackColor = System.Drawing.SystemColors.Window
        Me.txtFecIng.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFecIng.Enabled = False
        Me.txtFecIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecIng.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txtFecIng.Location = New System.Drawing.Point(609, 142)
        Me.txtFecIng.MaxLength = 20
        Me.txtFecIng.Name = "txtFecIng"
        Me.txtFecIng.ReadOnly = True
        Me.txtFecIng.Size = New System.Drawing.Size(67, 20)
        Me.txtFecIng.TabIndex = 55
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(530, 147)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Fecha Ingreso"
        '
        'lblAstApeMat
        '
        Me.lblAstApeMat.AutoSize = True
        Me.lblAstApeMat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstApeMat.ForeColor = System.Drawing.Color.Red
        Me.lblAstApeMat.Location = New System.Drawing.Point(98, 125)
        Me.lblAstApeMat.Name = "lblAstApeMat"
        Me.lblAstApeMat.Size = New System.Drawing.Size(12, 13)
        Me.lblAstApeMat.TabIndex = 47
        Me.lblAstApeMat.Text = "*"
        '
        'lblAstApePat
        '
        Me.lblAstApePat.AutoSize = True
        Me.lblAstApePat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstApePat.ForeColor = System.Drawing.Color.Red
        Me.lblAstApePat.Location = New System.Drawing.Point(98, 103)
        Me.lblAstApePat.Name = "lblAstApePat"
        Me.lblAstApePat.Size = New System.Drawing.Size(12, 13)
        Me.lblAstApePat.TabIndex = 53
        Me.lblAstApePat.Text = "*"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(511, 229)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(46, 13)
        Me.lblEstado.TabIndex = 52
        Me.lblEstado.Text = "Estado :"
        Me.lblEstado.Visible = False
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(563, 225)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(113, 20)
        Me.cmbEstado.TabIndex = 51
        Me.cmbEstado.TabStop = False
        Me.cmbEstado.Visible = False
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(406, 167)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(12, 13)
        Me.Label23.TabIndex = 50
        Me.Label23.Text = "*"
        '
        'lblAstDni
        '
        Me.lblAstDni.AutoSize = True
        Me.lblAstDni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstDni.ForeColor = System.Drawing.Color.Red
        Me.lblAstDni.Location = New System.Drawing.Point(550, 102)
        Me.lblAstDni.Name = "lblAstDni"
        Me.lblAstDni.Size = New System.Drawing.Size(12, 13)
        Me.lblAstDni.TabIndex = 49
        Me.lblAstDni.Text = "*"
        Me.lblAstDni.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(98, 189)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(12, 13)
        Me.Label22.TabIndex = 48
        Me.Label22.Text = "*"
        '
        'lblAstRazSoc
        '
        Me.lblAstRazSoc.AutoSize = True
        Me.lblAstRazSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstRazSoc.ForeColor = System.Drawing.Color.Red
        Me.lblAstRazSoc.Location = New System.Drawing.Point(98, 61)
        Me.lblAstRazSoc.Name = "lblAstRazSoc"
        Me.lblAstRazSoc.Size = New System.Drawing.Size(12, 13)
        Me.lblAstRazSoc.TabIndex = 46
        Me.lblAstRazSoc.Text = "*"
        '
        'lblAstNombre
        '
        Me.lblAstNombre.AutoSize = True
        Me.lblAstNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstNombre.ForeColor = System.Drawing.Color.Red
        Me.lblAstNombre.Location = New System.Drawing.Point(98, 82)
        Me.lblAstNombre.Name = "lblAstNombre"
        Me.lblAstNombre.Size = New System.Drawing.Size(12, 13)
        Me.lblAstNombre.TabIndex = 46
        Me.lblAstNombre.Text = "*"
        '
        'lblAstTipCon
        '
        Me.lblAstTipCon.AutoSize = True
        Me.lblAstTipCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstTipCon.ForeColor = System.Drawing.Color.Red
        Me.lblAstTipCon.Location = New System.Drawing.Point(97, 40)
        Me.lblAstTipCon.Name = "lblAstTipCon"
        Me.lblAstTipCon.Size = New System.Drawing.Size(12, 13)
        Me.lblAstTipCon.TabIndex = 45
        Me.lblAstTipCon.Text = "*"
        '
        'lblAstRuc
        '
        Me.lblAstRuc.AutoSize = True
        Me.lblAstRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstRuc.ForeColor = System.Drawing.Color.Red
        Me.lblAstRuc.Location = New System.Drawing.Point(548, 40)
        Me.lblAstRuc.Name = "lblAstRuc"
        Me.lblAstRuc.Size = New System.Drawing.Size(12, 13)
        Me.lblAstRuc.TabIndex = 44
        Me.lblAstRuc.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(6, 271)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "* Campos Obligatorios"
        '
        'lblApeMat
        '
        Me.lblApeMat.AutoSize = True
        Me.lblApeMat.Location = New System.Drawing.Point(4, 124)
        Me.lblApeMat.Name = "lblApeMat"
        Me.lblApeMat.Size = New System.Drawing.Size(44, 13)
        Me.lblApeMat.TabIndex = 42
        Me.lblApeMat.Text = "ApeMat"
        '
        'lblApePat
        '
        Me.lblApePat.AutoSize = True
        Me.lblApePat.Location = New System.Drawing.Point(4, 104)
        Me.lblApePat.Name = "lblApePat"
        Me.lblApePat.Size = New System.Drawing.Size(42, 13)
        Me.lblApePat.TabIndex = 41
        Me.lblApePat.Text = "ApePat"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(4, 83)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(49, 13)
        Me.lblNombre.TabIndex = 40
        Me.lblNombre.Text = "Nombres"
        '
        'txtApeMat
        '
        Me.txtApeMat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApeMat.Location = New System.Drawing.Point(110, 121)
        Me.txtApeMat.MaxLength = 50
        Me.txtApeMat.Name = "txtApeMat"
        Me.txtApeMat.Size = New System.Drawing.Size(280, 20)
        Me.txtApeMat.TabIndex = 9
        '
        'txtApePat
        '
        Me.txtApePat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApePat.Location = New System.Drawing.Point(110, 100)
        Me.txtApePat.MaxLength = 50
        Me.txtApePat.Name = "txtApePat"
        Me.txtApePat.Size = New System.Drawing.Size(280, 20)
        Me.txtApePat.TabIndex = 7
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(110, 79)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(280, 20)
        Me.txtNombre.TabIndex = 5
        '
        'cmbCodSec
        '
        Me.cmbCodSec.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodSec_DesignTimeLayout.LayoutString = resources.GetString("cmbCodSec_DesignTimeLayout.LayoutString")
        Me.cmbCodSec.DesignTimeLayout = cmbCodSec_DesignTimeLayout
        Me.cmbCodSec.Location = New System.Drawing.Point(421, 163)
        Me.cmbCodSec.Name = "cmbCodSec"
        Me.cmbCodSec.SelectedIndex = -1
        Me.cmbCodSec.SelectedItem = Nothing
        Me.cmbCodSec.Size = New System.Drawing.Size(141, 20)
        Me.cmbCodSec.TabIndex = 17
        Me.cmbCodSec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbIdTipoCon
        '
        Me.cmbIdTipoCon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdTipoCon_DesignTimeLayout.LayoutString = resources.GetString("cmbIdTipoCon_DesignTimeLayout.LayoutString")
        Me.cmbIdTipoCon.DesignTimeLayout = cmbIdTipoCon_DesignTimeLayout
        Me.cmbIdTipoCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdTipoCon.Location = New System.Drawing.Point(110, 37)
        Me.cmbIdTipoCon.Name = "cmbIdTipoCon"
        Me.cmbIdTipoCon.SelectedIndex = -1
        Me.cmbIdTipoCon.SelectedItem = Nothing
        Me.cmbIdTipoCon.Size = New System.Drawing.Size(182, 20)
        Me.cmbIdTipoCon.TabIndex = 1
        Me.cmbIdTipoCon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbIdTipoCliente
        '
        Me.cmbIdTipoCliente.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdTipoCliente_DesignTimeLayout.LayoutString = resources.GetString("cmbIdTipoCliente_DesignTimeLayout.LayoutString")
        Me.cmbIdTipoCliente.DesignTimeLayout = cmbIdTipoCliente_DesignTimeLayout
        Me.cmbIdTipoCliente.Location = New System.Drawing.Point(110, 184)
        Me.cmbIdTipoCliente.Name = "cmbIdTipoCliente"
        Me.cmbIdTipoCliente.SelectedIndex = -1
        Me.cmbIdTipoCliente.SelectedItem = Nothing
        Me.cmbIdTipoCliente.Size = New System.Drawing.Size(123, 20)
        Me.cmbIdTipoCliente.TabIndex = 18
        Me.cmbIdTipoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tabVentanas
        '
        Me.tabVentanas.Location = New System.Drawing.Point(6, 335)
        Me.tabVentanas.Name = "tabVentanas"
        Me.tabVentanas.Size = New System.Drawing.Size(683, 216)
        Me.tabVentanas.TabIndex = 23
        Me.tabVentanas.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tabpContactos, Me.tabpDireccionesFiscales, Me.tabpLocaciones, Me.tabpCondicionesPago, Me.tabpVendedores, Me.tabMoneda, Me.TabUsuario})
        Me.tabVentanas.TabStop = False
        '
        'tabpContactos
        '
        Me.tabpContactos.Controls.Add(Me.btnAgregarContacto)
        Me.tabpContactos.Controls.Add(Me.dgvContactos)
        Me.tabpContactos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabpContactos.Location = New System.Drawing.Point(1, 21)
        Me.tabpContactos.Name = "tabpContactos"
        Me.tabpContactos.Size = New System.Drawing.Size(679, 192)
        Me.tabpContactos.TabStop = True
        Me.tabpContactos.Text = "Contactos"
        '
        'btnAgregarContacto
        '
        Me.btnAgregarContacto.Image = CType(resources.GetObject("btnAgregarContacto.Image"), System.Drawing.Image)
        Me.btnAgregarContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarContacto.Location = New System.Drawing.Point(530, 3)
        Me.btnAgregarContacto.Name = "btnAgregarContacto"
        Me.btnAgregarContacto.Size = New System.Drawing.Size(127, 25)
        Me.btnAgregarContacto.TabIndex = 0
        Me.btnAgregarContacto.Text = "Agregar Contacto"
        Me.btnAgregarContacto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarContacto.UseVisualStyleBackColor = True
        '
        'dgvContactos
        '
        Me.dgvContactos.AllowUserToAddRows = False
        Me.dgvContactos.AllowUserToDeleteRows = False
        Me.dgvContactos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContactos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvContactos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdContacto, Me.cNombres, Me.cApellidos})
        Me.dgvContactos.ContextMenuStrip = Me.cmOpciones
        Me.dgvContactos.Location = New System.Drawing.Point(22, 29)
        Me.dgvContactos.MultiSelect = False
        Me.dgvContactos.Name = "dgvContactos"
        Me.dgvContactos.ReadOnly = True
        Me.dgvContactos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvContactos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvContactos.Size = New System.Drawing.Size(634, 157)
        Me.dgvContactos.TabIndex = 1
        '
        'cIdContacto
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdContacto.DefaultCellStyle = DataGridViewCellStyle2
        Me.cIdContacto.HeaderText = "Código"
        Me.cIdContacto.Name = "cIdContacto"
        Me.cIdContacto.ReadOnly = True
        Me.cIdContacto.Width = 80
        '
        'cNombres
        '
        Me.cNombres.HeaderText = "Nombres"
        Me.cNombres.Name = "cNombres"
        Me.cNombres.ReadOnly = True
        Me.cNombres.Width = 240
        '
        'cApellidos
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cApellidos.DefaultCellStyle = DataGridViewCellStyle3
        Me.cApellidos.HeaderText = "Apellidos"
        Me.cApellidos.Name = "cApellidos"
        Me.cApellidos.ReadOnly = True
        Me.cApellidos.Width = 270
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miModificar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevo
        '
        Me.miNuevo.Image = CType(resources.GetObject("miNuevo.Image"), System.Drawing.Image)
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miModificar
        '
        Me.miModificar.Image = CType(resources.GetObject("miModificar.Image"), System.Drawing.Image)
        Me.miModificar.Name = "miModificar"
        Me.miModificar.Size = New System.Drawing.Size(126, 22)
        Me.miModificar.Text = "Modificar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = CType(resources.GetObject("miEliminar.Image"), System.Drawing.Image)
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'tabpDireccionesFiscales
        '
        Me.tabpDireccionesFiscales.Controls.Add(Me.btnAgregarDireccionFiscal)
        Me.tabpDireccionesFiscales.Controls.Add(Me.dgvDireccionesFiscales)
        Me.tabpDireccionesFiscales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabpDireccionesFiscales.Location = New System.Drawing.Point(1, 21)
        Me.tabpDireccionesFiscales.Name = "tabpDireccionesFiscales"
        Me.tabpDireccionesFiscales.Size = New System.Drawing.Size(679, 192)
        Me.tabpDireccionesFiscales.TabStop = True
        Me.tabpDireccionesFiscales.Text = "Direcciones Fiscales"
        '
        'btnAgregarDireccionFiscal
        '
        Me.btnAgregarDireccionFiscal.Image = CType(resources.GetObject("btnAgregarDireccionFiscal.Image"), System.Drawing.Image)
        Me.btnAgregarDireccionFiscal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarDireccionFiscal.Location = New System.Drawing.Point(490, 3)
        Me.btnAgregarDireccionFiscal.Name = "btnAgregarDireccionFiscal"
        Me.btnAgregarDireccionFiscal.Size = New System.Drawing.Size(167, 25)
        Me.btnAgregarDireccionFiscal.TabIndex = 13
        Me.btnAgregarDireccionFiscal.Text = "Agregar Dirección Fiscal"
        Me.btnAgregarDireccionFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarDireccionFiscal.UseVisualStyleBackColor = True
        '
        'dgvDireccionesFiscales
        '
        Me.dgvDireccionesFiscales.AllowUserToAddRows = False
        Me.dgvDireccionesFiscales.AllowUserToDeleteRows = False
        Me.dgvDireccionesFiscales.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDireccionesFiscales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDireccionesFiscales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdFiscal, Me.cDireccion})
        Me.dgvDireccionesFiscales.ContextMenuStrip = Me.cmOpciones
        Me.dgvDireccionesFiscales.Location = New System.Drawing.Point(22, 29)
        Me.dgvDireccionesFiscales.MultiSelect = False
        Me.dgvDireccionesFiscales.Name = "dgvDireccionesFiscales"
        Me.dgvDireccionesFiscales.ReadOnly = True
        Me.dgvDireccionesFiscales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDireccionesFiscales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDireccionesFiscales.Size = New System.Drawing.Size(634, 157)
        Me.dgvDireccionesFiscales.TabIndex = 12
        '
        'cIdFiscal
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdFiscal.DefaultCellStyle = DataGridViewCellStyle5
        Me.cIdFiscal.HeaderText = "Código"
        Me.cIdFiscal.Name = "cIdFiscal"
        Me.cIdFiscal.ReadOnly = True
        Me.cIdFiscal.Width = 120
        '
        'cDireccion
        '
        Me.cDireccion.HeaderText = "Dirección"
        Me.cDireccion.Name = "cDireccion"
        Me.cDireccion.ReadOnly = True
        Me.cDireccion.Width = 470
        '
        'tabpLocaciones
        '
        Me.tabpLocaciones.Controls.Add(Me.btnAgregarLocacion)
        Me.tabpLocaciones.Controls.Add(Me.dgvLocaciones)
        Me.tabpLocaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabpLocaciones.Location = New System.Drawing.Point(1, 21)
        Me.tabpLocaciones.Name = "tabpLocaciones"
        Me.tabpLocaciones.Size = New System.Drawing.Size(679, 192)
        Me.tabpLocaciones.TabStop = True
        Me.tabpLocaciones.Text = "Locaciones"
        '
        'btnAgregarLocacion
        '
        Me.btnAgregarLocacion.Image = CType(resources.GetObject("btnAgregarLocacion.Image"), System.Drawing.Image)
        Me.btnAgregarLocacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarLocacion.Location = New System.Drawing.Point(504, 3)
        Me.btnAgregarLocacion.Name = "btnAgregarLocacion"
        Me.btnAgregarLocacion.Size = New System.Drawing.Size(153, 25)
        Me.btnAgregarLocacion.TabIndex = 13
        Me.btnAgregarLocacion.Text = "Agregar Locación"
        Me.btnAgregarLocacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarLocacion.UseVisualStyleBackColor = True
        '
        'dgvLocaciones
        '
        Me.dgvLocaciones.AllowUserToAddRows = False
        Me.dgvLocaciones.AllowUserToDeleteRows = False
        Me.dgvLocaciones.AllowUserToResizeRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLocaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvLocaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdLocCli, Me.cNombre, Me.cEmail})
        Me.dgvLocaciones.ContextMenuStrip = Me.cmOpciones
        Me.dgvLocaciones.Location = New System.Drawing.Point(22, 29)
        Me.dgvLocaciones.MultiSelect = False
        Me.dgvLocaciones.Name = "dgvLocaciones"
        Me.dgvLocaciones.ReadOnly = True
        Me.dgvLocaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvLocaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvLocaciones.Size = New System.Drawing.Size(634, 157)
        Me.dgvLocaciones.TabIndex = 12
        '
        'cIdLocCli
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdLocCli.DefaultCellStyle = DataGridViewCellStyle7
        Me.cIdLocCli.HeaderText = "Código"
        Me.cIdLocCli.Name = "cIdLocCli"
        Me.cIdLocCli.ReadOnly = True
        Me.cIdLocCli.Width = 120
        '
        'cNombre
        '
        Me.cNombre.HeaderText = "Nombre"
        Me.cNombre.Name = "cNombre"
        Me.cNombre.ReadOnly = True
        Me.cNombre.Width = 250
        '
        'cEmail
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cEmail.DefaultCellStyle = DataGridViewCellStyle8
        Me.cEmail.HeaderText = "Email"
        Me.cEmail.Name = "cEmail"
        Me.cEmail.ReadOnly = True
        Me.cEmail.Width = 220
        '
        'tabpCondicionesPago
        '
        Me.tabpCondicionesPago.Controls.Add(Me.btnAgregarCondicionPago)
        Me.tabpCondicionesPago.Controls.Add(Me.dgvCondicionesPago)
        Me.tabpCondicionesPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabpCondicionesPago.Location = New System.Drawing.Point(1, 21)
        Me.tabpCondicionesPago.Name = "tabpCondicionesPago"
        Me.tabpCondicionesPago.Size = New System.Drawing.Size(679, 192)
        Me.tabpCondicionesPago.TabStop = True
        Me.tabpCondicionesPago.Text = "Condiciones de Pago"
        '
        'btnAgregarCondicionPago
        '
        Me.btnAgregarCondicionPago.Image = CType(resources.GetObject("btnAgregarCondicionPago.Image"), System.Drawing.Image)
        Me.btnAgregarCondicionPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarCondicionPago.Location = New System.Drawing.Point(474, 3)
        Me.btnAgregarCondicionPago.Name = "btnAgregarCondicionPago"
        Me.btnAgregarCondicionPago.Size = New System.Drawing.Size(183, 25)
        Me.btnAgregarCondicionPago.TabIndex = 13
        Me.btnAgregarCondicionPago.Text = "Agregar Condición de Pago"
        Me.btnAgregarCondicionPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarCondicionPago.UseVisualStyleBackColor = True
        '
        'dgvCondicionesPago
        '
        Me.dgvCondicionesPago.AllowUserToAddRows = False
        Me.dgvCondicionesPago.AllowUserToDeleteRows = False
        Me.dgvCondicionesPago.AllowUserToResizeRows = False
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCondicionesPago.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvCondicionesPago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cDesRub, Me.cDesPag, Me.cDiaPag, Me.cCodRub, Me.cCodPag})
        Me.dgvCondicionesPago.ContextMenuStrip = Me.cmOpciones
        Me.dgvCondicionesPago.Location = New System.Drawing.Point(22, 29)
        Me.dgvCondicionesPago.MultiSelect = False
        Me.dgvCondicionesPago.Name = "dgvCondicionesPago"
        Me.dgvCondicionesPago.ReadOnly = True
        Me.dgvCondicionesPago.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvCondicionesPago.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCondicionesPago.Size = New System.Drawing.Size(634, 157)
        Me.dgvCondicionesPago.TabIndex = 12
        '
        'cDesRub
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cDesRub.DefaultCellStyle = DataGridViewCellStyle10
        Me.cDesRub.HeaderText = "Rubro"
        Me.cDesRub.Name = "cDesRub"
        Me.cDesRub.ReadOnly = True
        Me.cDesRub.Width = 220
        '
        'cDesPag
        '
        Me.cDesPag.HeaderText = "Condición Pago"
        Me.cDesPag.Name = "cDesPag"
        Me.cDesPag.ReadOnly = True
        Me.cDesPag.Width = 250
        '
        'cDiaPag
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cDiaPag.DefaultCellStyle = DataGridViewCellStyle11
        Me.cDiaPag.HeaderText = "Día Pago"
        Me.cDiaPag.Name = "cDiaPag"
        Me.cDiaPag.ReadOnly = True
        Me.cDiaPag.Width = 120
        '
        'cCodRub
        '
        Me.cCodRub.HeaderText = "CodRub"
        Me.cCodRub.Name = "cCodRub"
        Me.cCodRub.ReadOnly = True
        Me.cCodRub.Visible = False
        '
        'cCodPag
        '
        Me.cCodPag.HeaderText = "CodPag"
        Me.cCodPag.Name = "cCodPag"
        Me.cCodPag.ReadOnly = True
        Me.cCodPag.Visible = False
        '
        'tabpVendedores
        '
        Me.tabpVendedores.Controls.Add(Me.dgvVendedores)
        Me.tabpVendedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabpVendedores.Location = New System.Drawing.Point(1, 21)
        Me.tabpVendedores.Name = "tabpVendedores"
        Me.tabpVendedores.Size = New System.Drawing.Size(679, 192)
        Me.tabpVendedores.TabStop = True
        Me.tabpVendedores.Text = "Vendedores"
        '
        'dgvVendedores
        '
        Me.dgvVendedores.AllowUserToAddRows = False
        Me.dgvVendedores.AllowUserToDeleteRows = False
        Me.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVendedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdPer, Me.cApeNom, Me.cDesVen, Me.cFecAsig, Me.cObservacion})
        Me.dgvVendedores.Location = New System.Drawing.Point(22, 29)
        Me.dgvVendedores.Name = "dgvVendedores"
        Me.dgvVendedores.ReadOnly = True
        Me.dgvVendedores.Size = New System.Drawing.Size(634, 157)
        Me.dgvVendedores.TabIndex = 0
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
        Me.cApeNom.HeaderText = "Vendedor"
        Me.cApeNom.Name = "cApeNom"
        Me.cApeNom.ReadOnly = True
        Me.cApeNom.Width = 440
        '
        'cDesVen
        '
        Me.cDesVen.HeaderText = "Grupo de Venta"
        Me.cDesVen.Name = "cDesVen"
        Me.cDesVen.ReadOnly = True
        Me.cDesVen.Width = 150
        '
        'cFecAsig
        '
        Me.cFecAsig.HeaderText = "FecAsig"
        Me.cFecAsig.Name = "cFecAsig"
        Me.cFecAsig.ReadOnly = True
        Me.cFecAsig.Visible = False
        '
        'cObservacion
        '
        Me.cObservacion.HeaderText = "Observacion"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.ReadOnly = True
        Me.cObservacion.Visible = False
        '
        'tabMoneda
        '
        Me.tabMoneda.Controls.Add(Me.dgvMoneda)
        Me.tabMoneda.Controls.Add(Me.btnActivar)
        Me.tabMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabMoneda.Location = New System.Drawing.Point(1, 21)
        Me.tabMoneda.Name = "tabMoneda"
        Me.tabMoneda.Size = New System.Drawing.Size(679, 192)
        Me.tabMoneda.TabStop = True
        Me.tabMoneda.Text = "Moneda"
        '
        'dgvMoneda
        '
        Me.dgvMoneda.AllowUserToAddRows = False
        Me.dgvMoneda.AllowUserToDeleteRows = False
        Me.dgvMoneda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMoneda.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DesOfi, Me.IdLocacion, Me.DesAlm, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.dgvMoneda.ContextMenuStrip = Me.cmbOpciones2
        Me.dgvMoneda.GridColor = System.Drawing.SystemColors.ButtonShadow
        Me.dgvMoneda.Location = New System.Drawing.Point(22, 46)
        Me.dgvMoneda.Name = "dgvMoneda"
        Me.dgvMoneda.ReadOnly = True
        Me.dgvMoneda.Size = New System.Drawing.Size(619, 129)
        Me.dgvMoneda.TabIndex = 15
        '
        'DesOfi
        '
        Me.DesOfi.DataPropertyName = "DesOfi"
        Me.DesOfi.HeaderText = "Oficina"
        Me.DesOfi.Name = "DesOfi"
        Me.DesOfi.ReadOnly = True
        Me.DesOfi.Width = 160
        '
        'IdLocacion
        '
        Me.IdLocacion.DataPropertyName = "IdLocacion"
        Me.IdLocacion.HeaderText = "IdLocacion"
        Me.IdLocacion.Name = "IdLocacion"
        Me.IdLocacion.ReadOnly = True
        Me.IdLocacion.Visible = False
        '
        'DesAlm
        '
        Me.DesAlm.DataPropertyName = "DesAlm"
        Me.DesAlm.HeaderText = "Almacen"
        Me.DesAlm.Name = "DesAlm"
        Me.DesAlm.ReadOnly = True
        Me.DesAlm.Width = 180
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "FecReg"
        DataGridViewCellStyle12.Format = "d"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn4.HeaderText = "Fecha Reg."
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "CodUsu"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Usuario"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 110
        '
        'cmbOpciones2
        '
        Me.cmbOpciones2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEliminarLocMoneda})
        Me.cmbOpciones2.Name = "cmOpciones"
        Me.cmbOpciones2.Size = New System.Drawing.Size(118, 26)
        '
        'miEliminarLocMoneda
        '
        Me.miEliminarLocMoneda.Image = CType(resources.GetObject("miEliminarLocMoneda.Image"), System.Drawing.Image)
        Me.miEliminarLocMoneda.Name = "miEliminarLocMoneda"
        Me.miEliminarLocMoneda.Size = New System.Drawing.Size(117, 22)
        Me.miEliminarLocMoneda.Text = "Eliminar"
        '
        'btnActivar
        '
        Me.btnActivar.Image = CType(resources.GetObject("btnActivar.Image"), System.Drawing.Image)
        Me.btnActivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActivar.Location = New System.Drawing.Point(570, 17)
        Me.btnActivar.Name = "btnActivar"
        Me.btnActivar.Size = New System.Drawing.Size(72, 25)
        Me.btnActivar.TabIndex = 14
        Me.btnActivar.Text = "Activar"
        Me.btnActivar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActivar.UseVisualStyleBackColor = True
        '
        'TabUsuario
        '
        Me.TabUsuario.Controls.Add(Me.btnActCorreo)
        Me.TabUsuario.Controls.Add(Me.btnGenerarUsuario)
        Me.TabUsuario.Controls.Add(Me.UiGroupBox1)
        Me.TabUsuario.Location = New System.Drawing.Point(1, 21)
        Me.TabUsuario.Name = "TabUsuario"
        Me.TabUsuario.Size = New System.Drawing.Size(679, 192)
        Me.TabUsuario.TabStop = True
        Me.TabUsuario.Text = "Usuario"
        '
        'btnActCorreo
        '
        Me.btnActCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActCorreo.Image = CType(resources.GetObject("btnActCorreo.Image"), System.Drawing.Image)
        Me.btnActCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActCorreo.Location = New System.Drawing.Point(510, 13)
        Me.btnActCorreo.Name = "btnActCorreo"
        Me.btnActCorreo.Size = New System.Drawing.Size(125, 25)
        Me.btnActCorreo.TabIndex = 206
        Me.btnActCorreo.Text = "Actualizar Correo"
        Me.btnActCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActCorreo.UseVisualStyleBackColor = True
        '
        'btnGenerarUsuario
        '
        Me.btnGenerarUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerarUsuario.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnGenerarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerarUsuario.Location = New System.Drawing.Point(380, 13)
        Me.btnGenerarUsuario.Name = "btnGenerarUsuario"
        Me.btnGenerarUsuario.Size = New System.Drawing.Size(124, 25)
        Me.btnGenerarUsuario.TabIndex = 205
        Me.btnGenerarUsuario.Text = "Generar Usuario"
        Me.btnGenerarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerarUsuario.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtCorreo)
        Me.UiGroupBox1.Controls.Add(Me.txtUsuario)
        Me.UiGroupBox1.Controls.Add(Me.Label20)
        Me.UiGroupBox1.Controls.Add(Me.Label19)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(42, 47)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(591, 118)
        Me.UiGroupBox1.TabIndex = 204
        Me.UiGroupBox1.Text = "Datos de Usuario Cliente"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(147, 72)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.ReadOnly = True
        Me.txtCorreo.Size = New System.Drawing.Size(384, 20)
        Me.txtCorreo.TabIndex = 28
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(147, 38)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(152, 20)
        Me.txtUsuario.TabIndex = 27
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(83, 73)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 15)
        Me.Label20.TabIndex = 26
        Me.Label20.Text = "Correo :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(76, 38)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 15)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Usuario :"
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator13, Me.btnGuardar, Me.ToolStripSeparator14, Me.btnDeshacer, Me.ToolStripSeparator15, Me.btnEditar, Me.ToolStripSeparator1, Me.btnCancelar})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(718, 31)
        Me.ToolStrip.TabIndex = 23
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'btnDeshacer
        '
        Me.btnDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDeshacer.Image = CType(resources.GetObject("btnDeshacer.Image"), System.Drawing.Image)
        Me.btnDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.btnDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
        '
        'btnEditar
        '
        Me.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(28, 28)
        Me.btnEditar.Text = "Editar Detalles"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(28, 28)
        Me.btnCancelar.Text = "Cerrar el Formulario"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 578)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(718, 20)
        Me.ssBarra.TabIndex = 25
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        '
        'frmCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(718, 598)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.tabVentanas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cliente"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPrecios.ResumeLayout(False)
        Me.gbPrecios.PerformLayout()
        Me.gbSubDatos1.ResumeLayout(False)
        Me.gbSubDatos1.PerformLayout()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMedioContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbcredito.ResumeLayout(False)
        Me.gbcredito.PerformLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodSec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdTipoCon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdTipoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabVentanas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabVentanas.ResumeLayout(False)
        Me.tabpContactos.ResumeLayout(False)
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.tabpDireccionesFiscales.ResumeLayout(False)
        CType(Me.dgvDireccionesFiscales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpLocaciones.ResumeLayout(False)
        CType(Me.dgvLocaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpCondicionesPago.ResumeLayout(False)
        CType(Me.dgvCondicionesPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpVendedores.ResumeLayout(False)
        CType(Me.dgvVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMoneda.ResumeLayout(False)
        CType(Me.dgvMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones2.ResumeLayout(False)
        Me.TabUsuario.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtObsCli As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtUrlCli As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtFaxCli As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTelCli As System.Windows.Forms.TextBox
    Friend WithEvents txtDueCli As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNroDoc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtAbrCli As System.Windows.Forms.TextBox
    Friend WithEvents txtDesCli As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents gbSubDatos1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbListaCli As System.Windows.Forms.CheckBox
    Friend WithEvents cbAprCli As System.Windows.Forms.CheckBox
    Friend WithEvents gbPrecios As System.Windows.Forms.GroupBox
    Friend WithEvents txtHoraPago As System.Windows.Forms.TextBox
    Friend WithEvents txtDiaPago As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tabVentanas As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tabpContactos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tabpDireccionesFiscales As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tabpLocaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tabpCondicionesPago As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents btnAgregarContacto As System.Windows.Forms.Button
    Friend WithEvents btnAgregarDireccionFiscal As System.Windows.Forms.Button
    Friend WithEvents dgvDireccionesFiscales As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregarLocacion As System.Windows.Forms.Button
    Friend WithEvents dgvLocaciones As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregarCondicionPago As System.Windows.Forms.Button
    Friend WithEvents dgvCondicionesPago As System.Windows.Forms.DataGridView
    Friend WithEvents cmbIdTipoCliente As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbIdTipoCon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCodSec As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumCta As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cIdFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDireccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdLocCli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesRub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesPag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDiaPag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodRub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodPag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblApeMat As System.Windows.Forms.Label
    Friend WithEvents lblApePat As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtApeMat As System.Windows.Forms.TextBox
    Friend WithEvents txtApePat As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtDniCli As System.Windows.Forms.TextBox
    Friend WithEvents lblAstRuc As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAstTipCon As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblAstRazSoc As System.Windows.Forms.Label
    Friend WithEvents lblAstNombre As System.Windows.Forms.Label
    Friend WithEvents lblAstDni As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblAstApeMat As System.Windows.Forms.Label
    Friend WithEvents lblAstApePat As System.Windows.Forms.Label
    Friend WithEvents tabpVendedores As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvVendedores As System.Windows.Forms.DataGridView
    Friend WithEvents cIdPer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesVen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecAsig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabMoneda As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents cmbOpciones2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miEliminarLocMoneda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnActivar As System.Windows.Forms.Button
    Friend WithEvents dgvMoneda As System.Windows.Forms.DataGridView
    Friend WithEvents DesOfi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdLocacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesAlm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFecIng As System.Windows.Forms.TextBox
    Friend WithEvents lbllimitecredito As System.Windows.Forms.Label
    Friend WithEvents txtLimitecredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblAstTelef As System.Windows.Forms.Label
    Friend WithEvents gbcredito As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cIdContacto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNombres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApellidos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMedioContacto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvContactos As System.Windows.Forms.DataGridView
    Friend WithEvents TabUsuario As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnGenerarUsuario As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents btnActCorreo As System.Windows.Forms.Button
    Friend WithEvents lblAstTipDoc As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbAgente As CheckBox
    Friend WithEvents lblMensaje As Label
    Friend WithEvents btnConsultaSunat As Button
End Class
