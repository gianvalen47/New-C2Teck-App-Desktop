<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManteEmpresas_Nuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManteEmpresas_Nuevo))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditarr = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacerr = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAprobar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txturldoc = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtIR = New System.Windows.Forms.TextBox()
        Me.txtOrden = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodEmp = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIgv = New System.Windows.Forms.TextBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtClaveAPISunat = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtIDAPISunat = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtUrlAPI = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtMailHost = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtClaveCorEmisor = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtCorEmisor = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtClaveCert = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtNomCert = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtClaveOSE = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtUsuarioOSE = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbAplicaOSE = New System.Windows.Forms.CheckBox()
        Me.txtClaveSOL = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtUsuarioSOL = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtWebEmp = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCorEmp = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTelEmp = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFaxEmp = New System.Windows.Forms.TextBox()
        Me.txtCodPais = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRucEmp = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCodEstablecimiento = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUrbEmp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDirEmp = New System.Windows.Forms.TextBox()
        Me.btnUbigeo = New System.Windows.Forms.Button()
        Me.txtUbigeo = New System.Windows.Forms.TextBox()
        Me.txtAbvEmp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.cbActivo = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biEditarr, Me.ToolStripSeparator4, Me.biDeshacerr, Me.ToolStripSeparator7, Me.biAprobar, Me.ToolStripSeparator6, Me.biCerrar, Me.ToolStripSeparator5})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(659, 31)
        Me.ToolStrip.TabIndex = 188
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEditarr
        '
        Me.biEditarr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditarr.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditarr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditarr.Name = "biEditarr"
        Me.biEditarr.Size = New System.Drawing.Size(28, 28)
        Me.biEditarr.Text = "Editar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacerr
        '
        Me.biDeshacerr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacerr.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacerr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacerr.Name = "biDeshacerr"
        Me.biDeshacerr.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacerr.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator7.Visible = False
        '
        'biAprobar
        '
        Me.biAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.biAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAprobar.Name = "biAprobar"
        Me.biAprobar.Size = New System.Drawing.Size(28, 28)
        Me.biAprobar.Text = "Aprobar"
        Me.biAprobar.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.Label26)
        Me.UiGroupBox2.Controls.Add(Me.txturldoc)
        Me.UiGroupBox2.Controls.Add(Me.Label25)
        Me.UiGroupBox2.Controls.Add(Me.txtIR)
        Me.UiGroupBox2.Controls.Add(Me.txtOrden)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.txtCodEmp)
        Me.UiGroupBox2.Controls.Add(Me.Label24)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.txtIgv)
        Me.UiGroupBox2.Controls.Add(Me.UiGroupBox1)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.txtWebEmp)
        Me.UiGroupBox2.Controls.Add(Me.Label12)
        Me.UiGroupBox2.Controls.Add(Me.txtCorEmp)
        Me.UiGroupBox2.Controls.Add(Me.Label14)
        Me.UiGroupBox2.Controls.Add(Me.txtTelEmp)
        Me.UiGroupBox2.Controls.Add(Me.Label15)
        Me.UiGroupBox2.Controls.Add(Me.txtFaxEmp)
        Me.UiGroupBox2.Controls.Add(Me.txtCodPais)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.txtRucEmp)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtCodEstablecimiento)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.Label6)
        Me.UiGroupBox2.Controls.Add(Me.txtUrbEmp)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtDirEmp)
        Me.UiGroupBox2.Controls.Add(Me.btnUbigeo)
        Me.UiGroupBox2.Controls.Add(Me.txtUbigeo)
        Me.UiGroupBox2.Controls.Add(Me.txtAbvEmp)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.txtEmpresa)
        Me.UiGroupBox2.Controls.Add(Me.cbActivo)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(12, 34)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(616, 498)
        Me.UiGroupBox2.TabIndex = 198
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(22, 229)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(61, 13)
        Me.Label26.TabIndex = 241
        Me.Label26.Text = "URL Doc : "
        '
        'txturldoc
        '
        Me.txturldoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txturldoc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txturldoc.Location = New System.Drawing.Point(117, 226)
        Me.txturldoc.MaxLength = 50
        Me.txturldoc.Name = "txturldoc"
        Me.txturldoc.Size = New System.Drawing.Size(246, 20)
        Me.txturldoc.TabIndex = 240
        Me.txturldoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(23, 277)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(27, 13)
        Me.Label25.TabIndex = 239
        Me.Label25.Text = "IR : "
        '
        'txtIR
        '
        Me.txtIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIR.Location = New System.Drawing.Point(117, 274)
        Me.txtIR.MaxLength = 20
        Me.txtIR.Name = "txtIR"
        Me.txtIR.Size = New System.Drawing.Size(77, 20)
        Me.txtIR.TabIndex = 238
        '
        'txtOrden
        '
        Me.txtOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrden.Location = New System.Drawing.Point(464, 226)
        Me.txtOrden.Maximum = 300
        Me.txtOrden.MaxLength = 200
        Me.txtOrden.Minimum = 1
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(43, 20)
        Me.txtOrden.TabIndex = 236
        Me.txtOrden.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtOrden.Value = 1
        Me.txtOrden.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(393, 229)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Orden"
        '
        'txtCodEmp
        '
        Me.txtCodEmp.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmp.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodEmp.Location = New System.Drawing.Point(117, 16)
        Me.txtCodEmp.MaxLength = 20
        Me.txtCodEmp.Name = "txtCodEmp"
        Me.txtCodEmp.Size = New System.Drawing.Size(77, 20)
        Me.txtCodEmp.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(23, 19)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 13)
        Me.Label24.TabIndex = 235
        Me.Label24.Text = "Cod. Emp. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "Igv : "
        '
        'txtIgv
        '
        Me.txtIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIgv.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIgv.Location = New System.Drawing.Point(117, 250)
        Me.txtIgv.MaxLength = 20
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.Size = New System.Drawing.Size(77, 20)
        Me.txtIgv.TabIndex = 17
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtClaveAPISunat)
        Me.UiGroupBox1.Controls.Add(Me.Label29)
        Me.UiGroupBox1.Controls.Add(Me.txtIDAPISunat)
        Me.UiGroupBox1.Controls.Add(Me.Label28)
        Me.UiGroupBox1.Controls.Add(Me.txtUrlAPI)
        Me.UiGroupBox1.Controls.Add(Me.Label27)
        Me.UiGroupBox1.Controls.Add(Me.txtMailHost)
        Me.UiGroupBox1.Controls.Add(Me.Label23)
        Me.UiGroupBox1.Controls.Add(Me.txtClaveCorEmisor)
        Me.UiGroupBox1.Controls.Add(Me.Label21)
        Me.UiGroupBox1.Controls.Add(Me.txtCorEmisor)
        Me.UiGroupBox1.Controls.Add(Me.Label22)
        Me.UiGroupBox1.Controls.Add(Me.txtClaveCert)
        Me.UiGroupBox1.Controls.Add(Me.Label19)
        Me.UiGroupBox1.Controls.Add(Me.txtNomCert)
        Me.UiGroupBox1.Controls.Add(Me.Label20)
        Me.UiGroupBox1.Controls.Add(Me.txtClaveOSE)
        Me.UiGroupBox1.Controls.Add(Me.Label17)
        Me.UiGroupBox1.Controls.Add(Me.txtUsuarioOSE)
        Me.UiGroupBox1.Controls.Add(Me.Label18)
        Me.UiGroupBox1.Controls.Add(Me.cbAplicaOSE)
        Me.UiGroupBox1.Controls.Add(Me.txtClaveSOL)
        Me.UiGroupBox1.Controls.Add(Me.Label16)
        Me.UiGroupBox1.Controls.Add(Me.txtUsuarioSOL)
        Me.UiGroupBox1.Controls.Add(Me.Label13)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 302)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(592, 183)
        Me.UiGroupBox1.TabIndex = 228
        Me.UiGroupBox1.Text = "Datos Sunat"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtClaveAPISunat
        '
        Me.txtClaveAPISunat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveAPISunat.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClaveAPISunat.Location = New System.Drawing.Point(357, 149)
        Me.txtClaveAPISunat.MaxLength = 0
        Me.txtClaveAPISunat.Name = "txtClaveAPISunat"
        Me.txtClaveAPISunat.Size = New System.Drawing.Size(228, 20)
        Me.txtClaveAPISunat.TabIndex = 341
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(289, 152)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(60, 13)
        Me.Label29.TabIndex = 342
        Me.Label29.Text = "Clave API :"
        '
        'txtIDAPISunat
        '
        Me.txtIDAPISunat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDAPISunat.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIDAPISunat.Location = New System.Drawing.Point(90, 149)
        Me.txtIDAPISunat.MaxLength = 0
        Me.txtIDAPISunat.Name = "txtIDAPISunat"
        Me.txtIDAPISunat.Size = New System.Drawing.Size(190, 20)
        Me.txtIDAPISunat.TabIndex = 339
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(14, 152)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 13)
        Me.Label28.TabIndex = 340
        Me.Label28.Text = "ID API:"
        '
        'txtUrlAPI
        '
        Me.txtUrlAPI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUrlAPI.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUrlAPI.Location = New System.Drawing.Point(357, 123)
        Me.txtUrlAPI.MaxLength = 0
        Me.txtUrlAPI.Name = "txtUrlAPI"
        Me.txtUrlAPI.Size = New System.Drawing.Size(228, 20)
        Me.txtUrlAPI.TabIndex = 337
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(289, 126)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(46, 13)
        Me.Label27.TabIndex = 338
        Me.Label27.Text = "Url API :"
        '
        'txtMailHost
        '
        Me.txtMailHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMailHost.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMailHost.Location = New System.Drawing.Point(90, 123)
        Me.txtMailHost.MaxLength = 50
        Me.txtMailHost.Name = "txtMailHost"
        Me.txtMailHost.Size = New System.Drawing.Size(190, 20)
        Me.txtMailHost.TabIndex = 23
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(11, 126)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(57, 13)
        Me.Label23.TabIndex = 336
        Me.Label23.Text = "Mail Host :"
        '
        'txtClaveCorEmisor
        '
        Me.txtClaveCorEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveCorEmisor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClaveCorEmisor.Location = New System.Drawing.Point(357, 97)
        Me.txtClaveCorEmisor.MaxLength = 50
        Me.txtClaveCorEmisor.Name = "txtClaveCorEmisor"
        Me.txtClaveCorEmisor.Size = New System.Drawing.Size(128, 20)
        Me.txtClaveCorEmisor.TabIndex = 22
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(287, 100)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 13)
        Me.Label21.TabIndex = 334
        Me.Label21.Text = "Clave Correo:"
        '
        'txtCorEmisor
        '
        Me.txtCorEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorEmisor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCorEmisor.Location = New System.Drawing.Point(90, 97)
        Me.txtCorEmisor.MaxLength = 50
        Me.txtCorEmisor.Name = "txtCorEmisor"
        Me.txtCorEmisor.Size = New System.Drawing.Size(190, 20)
        Me.txtCorEmisor.TabIndex = 21
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(11, 100)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 13)
        Me.Label22.TabIndex = 332
        Me.Label22.Text = "Correo Emisor :"
        '
        'txtClaveCert
        '
        Me.txtClaveCert.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveCert.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClaveCert.Location = New System.Drawing.Point(357, 71)
        Me.txtClaveCert.MaxLength = 50
        Me.txtClaveCert.Name = "txtClaveCert"
        Me.txtClaveCert.Size = New System.Drawing.Size(128, 20)
        Me.txtClaveCert.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(287, 74)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 13)
        Me.Label19.TabIndex = 330
        Me.Label19.Text = "Clave Cert. :"
        '
        'txtNomCert
        '
        Me.txtNomCert.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomCert.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNomCert.Location = New System.Drawing.Point(90, 71)
        Me.txtNomCert.MaxLength = 50
        Me.txtNomCert.Name = "txtNomCert"
        Me.txtNomCert.Size = New System.Drawing.Size(190, 20)
        Me.txtNomCert.TabIndex = 19
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(11, 74)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 13)
        Me.Label20.TabIndex = 328
        Me.Label20.Text = "Nombre Cert. :"
        '
        'txtClaveOSE
        '
        Me.txtClaveOSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveOSE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClaveOSE.Location = New System.Drawing.Point(357, 45)
        Me.txtClaveOSE.MaxLength = 50
        Me.txtClaveOSE.Name = "txtClaveOSE"
        Me.txtClaveOSE.Size = New System.Drawing.Size(128, 20)
        Me.txtClaveOSE.TabIndex = 18
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(287, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 13)
        Me.Label17.TabIndex = 326
        Me.Label17.Text = "Clave OSE :"
        '
        'txtUsuarioOSE
        '
        Me.txtUsuarioOSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuarioOSE.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUsuarioOSE.Location = New System.Drawing.Point(90, 45)
        Me.txtUsuarioOSE.MaxLength = 50
        Me.txtUsuarioOSE.Name = "txtUsuarioOSE"
        Me.txtUsuarioOSE.Size = New System.Drawing.Size(190, 20)
        Me.txtUsuarioOSE.TabIndex = 17
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 13)
        Me.Label18.TabIndex = 324
        Me.Label18.Text = "Usuario OSE :"
        '
        'cbAplicaOSE
        '
        Me.cbAplicaOSE.AutoSize = True
        Me.cbAplicaOSE.Enabled = False
        Me.cbAplicaOSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAplicaOSE.Location = New System.Drawing.Point(506, 21)
        Me.cbAplicaOSE.Name = "cbAplicaOSE"
        Me.cbAplicaOSE.Size = New System.Drawing.Size(80, 17)
        Me.cbAplicaOSE.TabIndex = 322
        Me.cbAplicaOSE.Text = "Aplica OSE"
        Me.cbAplicaOSE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAplicaOSE.UseVisualStyleBackColor = True
        '
        'txtClaveSOL
        '
        Me.txtClaveSOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveSOL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClaveSOL.Location = New System.Drawing.Point(357, 19)
        Me.txtClaveSOL.MaxLength = 50
        Me.txtClaveSOL.Name = "txtClaveSOL"
        Me.txtClaveSOL.Size = New System.Drawing.Size(128, 20)
        Me.txtClaveSOL.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(287, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 13)
        Me.Label16.TabIndex = 321
        Me.Label16.Text = "Clave SOL :"
        '
        'txtUsuarioSOL
        '
        Me.txtUsuarioSOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuarioSOL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUsuarioSOL.Location = New System.Drawing.Point(90, 19)
        Me.txtUsuarioSOL.MaxLength = 50
        Me.txtUsuarioSOL.Name = "txtUsuarioSOL"
        Me.txtUsuarioSOL.Size = New System.Drawing.Size(190, 20)
        Me.txtUsuarioSOL.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 13)
        Me.Label13.TabIndex = 319
        Me.Label13.Text = "Usuario SOL :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(22, 205)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 227
        Me.Label11.Text = "Web : "
        '
        'txtWebEmp
        '
        Me.txtWebEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebEmp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWebEmp.Location = New System.Drawing.Point(117, 202)
        Me.txtWebEmp.MaxLength = 50
        Me.txtWebEmp.Name = "txtWebEmp"
        Me.txtWebEmp.Size = New System.Drawing.Size(246, 20)
        Me.txtWebEmp.TabIndex = 13
        Me.txtWebEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(393, 205)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 226
        Me.Label12.Text = "Correo : "
        '
        'txtCorEmp
        '
        Me.txtCorEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorEmp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCorEmp.Location = New System.Drawing.Point(464, 202)
        Me.txtCorEmp.MaxLength = 50
        Me.txtCorEmp.Name = "txtCorEmp"
        Me.txtCorEmp.Size = New System.Drawing.Size(139, 20)
        Me.txtCorEmp.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(22, 181)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 223
        Me.Label14.Text = "Teléfono : "
        '
        'txtTelEmp
        '
        Me.txtTelEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelEmp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTelEmp.Location = New System.Drawing.Point(117, 178)
        Me.txtTelEmp.MaxLength = 40
        Me.txtTelEmp.Name = "txtTelEmp"
        Me.txtTelEmp.Size = New System.Drawing.Size(128, 20)
        Me.txtTelEmp.TabIndex = 11
        Me.txtTelEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(393, 181)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 13)
        Me.Label15.TabIndex = 221
        Me.Label15.Text = "Fax :"
        '
        'txtFaxEmp
        '
        Me.txtFaxEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxEmp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFaxEmp.Location = New System.Drawing.Point(464, 178)
        Me.txtFaxEmp.MaxLength = 40
        Me.txtFaxEmp.Name = "txtFaxEmp"
        Me.txtFaxEmp.Size = New System.Drawing.Size(139, 20)
        Me.txtFaxEmp.TabIndex = 12
        '
        'txtCodPais
        '
        Me.txtCodPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodPais.Location = New System.Drawing.Point(464, 155)
        Me.txtCodPais.MaxLength = 5
        Me.txtCodPais.Name = "txtCodPais"
        Me.txtCodPais.Size = New System.Drawing.Size(52, 20)
        Me.txtCodPais.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(393, 158)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 216
        Me.Label10.Text = "Cod. Pais :"
        '
        'txtRucEmp
        '
        Me.txtRucEmp.BackColor = System.Drawing.SystemColors.Window
        Me.txtRucEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRucEmp.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtRucEmp.Location = New System.Drawing.Point(494, 63)
        Me.txtRucEmp.MaxLength = 20
        Me.txtRucEmp.Name = "txtRucEmp"
        Me.txtRucEmp.Size = New System.Drawing.Size(109, 20)
        Me.txtRucEmp.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(448, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 214
        Me.Label9.Text = "Ruc :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 213
        Me.Label8.Text = "Ubicación :"
        '
        'txtCodEstablecimiento
        '
        Me.txtCodEstablecimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEstablecimiento.Location = New System.Drawing.Point(117, 155)
        Me.txtCodEstablecimiento.MaxLength = 10
        Me.txtCodEstablecimiento.Name = "txtCodEstablecimiento"
        Me.txtCodEstablecimiento.Size = New System.Drawing.Size(77, 20)
        Me.txtCodEstablecimiento.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 211
        Me.Label7.Text = "Cod. Est. :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 210
        Me.Label6.Text = "Urbanización :"
        '
        'txtUrbEmp
        '
        Me.txtUrbEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUrbEmp.Location = New System.Drawing.Point(117, 109)
        Me.txtUrbEmp.MaxLength = 150
        Me.txtUrbEmp.Multiline = True
        Me.txtUrbEmp.Name = "txtUrbEmp"
        Me.txtUrbEmp.Size = New System.Drawing.Size(486, 20)
        Me.txtUrbEmp.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 208
        Me.Label3.Text = "Dirección :"
        '
        'txtDirEmp
        '
        Me.txtDirEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirEmp.Location = New System.Drawing.Point(117, 86)
        Me.txtDirEmp.MaxLength = 150
        Me.txtDirEmp.Multiline = True
        Me.txtDirEmp.Name = "txtDirEmp"
        Me.txtDirEmp.Size = New System.Drawing.Size(486, 20)
        Me.txtDirEmp.TabIndex = 5
        '
        'btnUbigeo
        '
        Me.btnUbigeo.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnUbigeo.Location = New System.Drawing.Point(363, 131)
        Me.btnUbigeo.Name = "btnUbigeo"
        Me.btnUbigeo.Size = New System.Drawing.Size(29, 21)
        Me.btnUbigeo.TabIndex = 7
        Me.btnUbigeo.UseVisualStyleBackColor = True
        '
        'txtUbigeo
        '
        Me.txtUbigeo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUbigeo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbigeo.Location = New System.Drawing.Point(117, 132)
        Me.txtUbigeo.MaxLength = 3
        Me.txtUbigeo.Name = "txtUbigeo"
        Me.txtUbigeo.ReadOnly = True
        Me.txtUbigeo.Size = New System.Drawing.Size(246, 20)
        Me.txtUbigeo.TabIndex = 8
        '
        'txtAbvEmp
        '
        Me.txtAbvEmp.BackColor = System.Drawing.SystemColors.Window
        Me.txtAbvEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbvEmp.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtAbvEmp.Location = New System.Drawing.Point(117, 63)
        Me.txtAbvEmp.MaxLength = 50
        Me.txtAbvEmp.Name = "txtAbvEmp"
        Me.txtAbvEmp.Size = New System.Drawing.Size(196, 20)
        Me.txtAbvEmp.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 203
        Me.Label4.Text = "Abreviatura :"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresa.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtEmpresa.Location = New System.Drawing.Point(117, 40)
        Me.txtEmpresa.MaxLength = 100
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(399, 20)
        Me.txtEmpresa.TabIndex = 2
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbActivo.Location = New System.Drawing.Point(548, 42)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(56, 17)
        Me.cbActivo.TabIndex = 196
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 189
        Me.Label5.Text = "Empresa :"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmManteEmpresas_Nuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(659, 559)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManteEmpresas_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Empresa"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents biGuardar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents biEditarr As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents biDeshacerr As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents biAprobar As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents biCerrar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbActivo As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEmpresa As TextBox
    Friend WithEvents txtAbvEmp As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCodPais As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtRucEmp As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCodEstablecimiento As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtUrbEmp As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDirEmp As TextBox
    Friend WithEvents btnUbigeo As Button
    Friend WithEvents txtUbigeo As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtWebEmp As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCorEmp As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtTelEmp As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtFaxEmp As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtIgv As TextBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtUsuarioSOL As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtMailHost As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtClaveCorEmisor As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtCorEmisor As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtClaveCert As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtNomCert As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtClaveOSE As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtUsuarioOSE As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cbAplicaOSE As CheckBox
    Friend WithEvents txtClaveSOL As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtCodEmp As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtOrden As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txturldoc As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtIR As TextBox
    Friend WithEvents txtClaveAPISunat As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtIDAPISunat As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtUrlAPI As TextBox
    Friend WithEvents Label27 As Label
End Class
