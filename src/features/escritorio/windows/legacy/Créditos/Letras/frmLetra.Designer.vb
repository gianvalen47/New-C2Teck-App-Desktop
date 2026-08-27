<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLetra
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
        Dim cmbIdFiscal_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLetra))
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodPag_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.txtDniAval = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtRucAval = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDirAval2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtDirAval1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTelAval = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtDesAval3 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtDesAval2 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtDesAval1 = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbIdFiscal = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCliente = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVencimiento = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGiro = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtReferencia = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumLet = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCancelar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTipCam = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblCodPago = New System.Windows.Forms.Label()
        Me.txtCodPago = New System.Windows.Forms.TextBox()
        Me.cmbCodPag = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        CType(Me.cmbIdFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDniAval
        '
        Me.txtDniAval.Location = New System.Drawing.Point(216, 342)
        Me.txtDniAval.MaxLength = 15
        Me.txtDniAval.Name = "txtDniAval"
        Me.txtDniAval.Size = New System.Drawing.Size(100, 20)
        Me.txtDniAval.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(173, 346)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "DNI :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(325, 345)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Teléfono :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(502, 346)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 13)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "Tipo de Cambio :"
        '
        'txtRucAval
        '
        Me.txtRucAval.Location = New System.Drawing.Point(56, 342)
        Me.txtRucAval.MaxLength = 15
        Me.txtRucAval.Name = "txtRucAval"
        Me.txtRucAval.Size = New System.Drawing.Size(100, 20)
        Me.txtRucAval.TabIndex = 26
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 346)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "RUC :"
        '
        'txtDirAval2
        '
        Me.txtDirAval2.Location = New System.Drawing.Point(371, 312)
        Me.txtDirAval2.MaxLength = 60
        Me.txtDirAval2.Name = "txtDirAval2"
        Me.txtDirAval2.Size = New System.Drawing.Size(350, 20)
        Me.txtDirAval2.TabIndex = 24
        '
        'txtDirAval1
        '
        Me.txtDirAval1.Location = New System.Drawing.Point(11, 312)
        Me.txtDirAval1.MaxLength = 50
        Me.txtDirAval1.Name = "txtDirAval1"
        Me.txtDirAval1.Size = New System.Drawing.Size(350, 20)
        Me.txtDirAval1.TabIndex = 23
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 293)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 13)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Dirección Aval :"
        '
        'txtTelAval
        '
        Me.txtTelAval.Location = New System.Drawing.Point(396, 342)
        Me.txtTelAval.MaxLength = 15
        Me.txtTelAval.Name = "txtTelAval"
        Me.txtTelAval.Size = New System.Drawing.Size(100, 20)
        Me.txtTelAval.TabIndex = 30
        '
        'txtDesAval3
        '
        Me.txtDesAval3.Location = New System.Drawing.Point(371, 267)
        Me.txtDesAval3.MaxLength = 60
        Me.txtDesAval3.Name = "txtDesAval3"
        Me.txtDesAval3.Size = New System.Drawing.Size(350, 20)
        Me.txtDesAval3.TabIndex = 21
        '
        'txtDesAval2
        '
        Me.txtDesAval2.Location = New System.Drawing.Point(11, 267)
        Me.txtDesAval2.MaxLength = 60
        Me.txtDesAval2.Name = "txtDesAval2"
        Me.txtDesAval2.Size = New System.Drawing.Size(350, 20)
        Me.txtDesAval2.TabIndex = 20
        '
        'txtDesAval1
        '
        Me.txtDesAval1.Location = New System.Drawing.Point(11, 242)
        Me.txtDesAval1.MaxLength = 50
        Me.txtDesAval1.Name = "txtDesAval1"
        Me.txtDesAval1.Size = New System.Drawing.Size(500, 20)
        Me.txtDesAval1.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 221)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Avales :"
        '
        'cmbIdFiscal
        '
        Me.cmbIdFiscal.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdFiscal_DesignTimeLayout.LayoutString = resources.GetString("cmbIdFiscal_DesignTimeLayout.LayoutString")
        Me.cmbIdFiscal.DesignTimeLayout = cmbIdFiscal_DesignTimeLayout
        Me.cmbIdFiscal.Location = New System.Drawing.Point(406, 192)
        Me.cmbIdFiscal.Name = "cmbIdFiscal"
        Me.cmbIdFiscal.SelectedIndex = -1
        Me.cmbIdFiscal.SelectedItem = Nothing
        Me.cmbIdFiscal.Size = New System.Drawing.Size(301, 20)
        Me.cmbIdFiscal.TabIndex = 17
        Me.cmbIdFiscal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(406, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Dirección :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Cliente :"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Control
        Me.txtCliente.ButtonImage = CType(resources.GetObject("txtCliente.ButtonImage"), System.Drawing.Image)
        Me.txtCliente.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(11, 192)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(385, 20)
        Me.txtCliente.TabIndex = 15
        Me.txtCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtImporte
        '
        Me.txtImporte.DecimalDigits = 2
        Me.txtImporte.EditMode = Janus.Windows.GridEX.NumericEditMode.Value
        Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.FormatString = "#,###,##0.00"
        Me.txtImporte.Location = New System.Drawing.Point(472, 142)
        Me.txtImporte.MaxLength = 10
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(120, 20)
        Me.txtImporte.TabIndex = 13
        Me.txtImporte.Text = "0.00"
        Me.txtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtImporte.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(409, 146)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Importe :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Enabled = False
        Me.cmbMoneda.Location = New System.Drawing.Point(324, 142)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(60, 20)
        Me.cmbMoneda.TabIndex = 11
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(258, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Moneda :"
        '
        'txtVencimiento
        '
        '
        '
        '
        Me.txtVencimiento.DropDownCalendar.Name = ""
        Me.txtVencimiento.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtVencimiento.Location = New System.Drawing.Point(136, 142)
        Me.txtVencimiento.Name = "txtVencimiento"
        Me.txtVencimiento.Size = New System.Drawing.Size(102, 20)
        Me.txtVencimiento.TabIndex = 10
        Me.txtVencimiento.Value = New Date(2009, 10, 6, 0, 0, 0, 0)
        Me.txtVencimiento.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fecha Vencimiento :"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(108, 111)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(102, 20)
        Me.txtFecha.TabIndex = 7
        Me.txtFecha.Value = New Date(2009, 10, 6, 0, 0, 0, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Fecha Emisión :"
        '
        'txtGiro
        '
        Me.txtGiro.Location = New System.Drawing.Point(526, 51)
        Me.txtGiro.MaxLength = 10
        Me.txtGiro.Name = "txtGiro"
        Me.txtGiro.Size = New System.Drawing.Size(125, 20)
        Me.txtGiro.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(446, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Lugar Giro :"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(296, 51)
        Me.txtReferencia.MaxLength = 10
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(125, 20)
        Me.txtReferencia.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(216, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Referencia :"
        '
        'txtNumLet
        '
        Me.txtNumLet.BackColor = System.Drawing.Color.Beige
        Me.txtNumLet.DecimalDigits = 0
        Me.txtNumLet.EditMode = Janus.Windows.GridEX.NumericEditMode.Value
        Me.txtNumLet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumLet.FormatString = "##########"
        Me.txtNumLet.Location = New System.Drawing.Point(81, 51)
        Me.txtNumLet.MaxLength = 10
        Me.txtNumLet.Name = "txtNumLet"
        Me.txtNumLet.ReadOnly = True
        Me.txtNumLet.Size = New System.Drawing.Size(100, 20)
        Me.txtNumLet.TabIndex = 1
        Me.txtNumLet.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtNumLet.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtNumLet.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.ssBarra)
        Me.UiGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox2.Location = New System.Drawing.Point(0, 437)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(765, 25)
        Me.UiGroupBox2.TabIndex = 1
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(3, 0)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(759, 22)
        Me.ssBarra.TabIndex = 4
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 17)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(150, 17)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miGuardar, Me.miEliminar, Me.miCancelar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(121, 70)
        '
        'miGuardar
        '
        Me.miGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.miGuardar.Name = "miGuardar"
        Me.miGuardar.Size = New System.Drawing.Size(120, 22)
        Me.miGuardar.Text = "&Guardar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(120, 22)
        Me.miEliminar.Text = "&Eliminar"
        '
        'miCancelar
        '
        Me.miCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miCancelar.Name = "miCancelar"
        Me.miCancelar.Size = New System.Drawing.Size(120, 22)
        Me.miCancelar.Text = "&Cancelar"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(25, 25)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biEditar, Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biDeshacer, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.MinimumSize = New System.Drawing.Size(0, 35)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(765, 35)
        Me.ToolStrip.TabIndex = 34
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(29, 32)
        Me.biEditar.Text = "Editar los Datos Seleccionados "
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 35)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(29, 32)
        Me.biGuardar.Text = "Guardar los Cambios Realizados"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 35)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(29, 32)
        Me.biDeshacer.Text = "Deshacer los Cambios Realizados"
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(29, 32)
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbIdLocacion)
        Me.GroupBox1.Controls.Add(Me.cmbOficinas)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtTipCam)
        Me.GroupBox1.Controls.Add(Me.lblCodPago)
        Me.GroupBox1.Controls.Add(Me.txtCodPago)
        Me.GroupBox1.Controls.Add(Me.cmbCodPag)
        Me.GroupBox1.Controls.Add(Me.gbEstado)
        Me.GroupBox1.Controls.Add(Me.txtNumLet)
        Me.GroupBox1.Controls.Add(Me.txtDniAval)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cmbIdFiscal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtImporte)
        Me.GroupBox1.Controls.Add(Me.txtDesAval1)
        Me.GroupBox1.Controls.Add(Me.txtReferencia)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtDesAval2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbMoneda)
        Me.GroupBox1.Controls.Add(Me.txtRucAval)
        Me.GroupBox1.Controls.Add(Me.txtDesAval3)
        Me.GroupBox1.Controls.Add(Me.txtGiro)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtTelAval)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtVencimiento)
        Me.GroupBox1.Controls.Add(Me.txtDirAval2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDirAval1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(737, 374)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Location = New System.Drawing.Point(296, 80)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(129, 20)
        Me.cmbIdLocacion.TabIndex = 44
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(81, 80)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(77, 20)
        Me.cmbOficinas.TabIndex = 40
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(230, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Almacén :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "Oficina :"
        '
        'txtTipCam
        '
        Me.txtTipCam.BackColor = System.Drawing.SystemColors.Control
        Me.txtTipCam.DecimalDigits = 3
        Me.txtTipCam.EditMode = Janus.Windows.GridEX.NumericEditMode.Value
        Me.txtTipCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCam.Location = New System.Drawing.Point(607, 342)
        Me.txtTipCam.MaxLength = 12
        Me.txtTipCam.Name = "txtTipCam"
        Me.txtTipCam.ReadOnly = True
        Me.txtTipCam.Size = New System.Drawing.Size(100, 20)
        Me.txtTipCam.TabIndex = 39
        Me.txtTipCam.TabStop = False
        Me.txtTipCam.Text = "0.000"
        Me.txtTipCam.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTipCam.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtTipCam.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblCodPago
        '
        Me.lblCodPago.AutoSize = True
        Me.lblCodPago.Location = New System.Drawing.Point(216, 115)
        Me.lblCodPago.Name = "lblCodPago"
        Me.lblCodPago.Size = New System.Drawing.Size(118, 13)
        Me.lblCodPago.TabIndex = 38
        Me.lblCodPago.Text = "Condición de Pago:"
        '
        'txtCodPago
        '
        Me.txtCodPago.BackColor = System.Drawing.Color.Beige
        Me.txtCodPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodPago.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodPago.Location = New System.Drawing.Point(343, 111)
        Me.txtCodPago.MaxLength = 200
        Me.txtCodPago.Name = "txtCodPago"
        Me.txtCodPago.Size = New System.Drawing.Size(41, 20)
        Me.txtCodPago.TabIndex = 8
        Me.txtCodPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbCodPag
        '
        Me.cmbCodPag.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodPag_DesignTimeLayout.LayoutString = resources.GetString("cmbCodPag_DesignTimeLayout.LayoutString")
        Me.cmbCodPag.DesignTimeLayout = cmbCodPag_DesignTimeLayout
        Me.cmbCodPag.Location = New System.Drawing.Point(386, 111)
        Me.cmbCodPag.Name = "cmbCodPag"
        Me.cmbCodPag.SelectedIndex = -1
        Me.cmbCodPag.SelectedItem = Nothing
        Me.cmbCodPag.Size = New System.Drawing.Size(140, 20)
        Me.cmbCodPag.TabIndex = 9
        Me.cmbCodPag.TabStop = False
        Me.cmbCodPag.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(580, 13)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(150, 28)
        Me.gbEstado.TabIndex = 35
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(8, 10)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(136, 16)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmLetra
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(765, 462)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLetra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmLetra"
        CType(Me.cmbIdFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNumLet As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGiro As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVencimiento As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtRucAval As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDirAval2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtDirAval1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTelAval As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtDesAval3 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtDesAval2 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtDesAval1 As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbIdFiscal As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCancelar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDniAval As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblCodPago As System.Windows.Forms.Label
    Friend WithEvents txtCodPago As System.Windows.Forms.TextBox
    Friend WithEvents cmbCodPag As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtTipCam As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
