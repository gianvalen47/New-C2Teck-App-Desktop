<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametroLocacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametroLocacion))
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
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
        Me.btnBuscarLocacion = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbVale = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbConsignacion = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbAproOrd = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLetra = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAnticipo = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtLiqMotor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtValeReq = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtComMotor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTraMotor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTraInt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNotaDebito = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNotaCredito = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtBoletaCredito = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtBoletaContado = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtFactCredito = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtFactContado = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtGuiaDevolucion = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtFactor = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDscto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbMoneda = New System.Windows.Forms.CheckBox()
        Me.txtIdLocacion = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtGuiaRemision = New System.Windows.Forms.TextBox()
        Me.cbAproDoc = New System.Windows.Forms.CheckBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip.Size = New System.Drawing.Size(457, 31)
        Me.ToolStrip.TabIndex = 189
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
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarLocacion)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.cbVale)
        Me.UiGroupBox2.Controls.Add(Me.Label12)
        Me.UiGroupBox2.Controls.Add(Me.cbConsignacion)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.cbAproOrd)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.txtLetra)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.txtAnticipo)
        Me.UiGroupBox2.Controls.Add(Me.Label36)
        Me.UiGroupBox2.Controls.Add(Me.txtLiqMotor)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtValeReq)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.txtComMotor)
        Me.UiGroupBox2.Controls.Add(Me.Label6)
        Me.UiGroupBox2.Controls.Add(Me.txtTraMotor)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtTraInt)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtNotaDebito)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.txtNotaCredito)
        Me.UiGroupBox2.Controls.Add(Me.Label34)
        Me.UiGroupBox2.Controls.Add(Me.txtBoletaCredito)
        Me.UiGroupBox2.Controls.Add(Me.Label35)
        Me.UiGroupBox2.Controls.Add(Me.txtBoletaContado)
        Me.UiGroupBox2.Controls.Add(Me.Label32)
        Me.UiGroupBox2.Controls.Add(Me.txtFactCredito)
        Me.UiGroupBox2.Controls.Add(Me.Label33)
        Me.UiGroupBox2.Controls.Add(Me.txtFactContado)
        Me.UiGroupBox2.Controls.Add(Me.Label31)
        Me.UiGroupBox2.Controls.Add(Me.txtGuiaDevolucion)
        Me.UiGroupBox2.Controls.Add(Me.Label30)
        Me.UiGroupBox2.Controls.Add(Me.Label29)
        Me.UiGroupBox2.Controls.Add(Me.txtFactor)
        Me.UiGroupBox2.Controls.Add(Me.txtDscto)
        Me.UiGroupBox2.Controls.Add(Me.Label25)
        Me.UiGroupBox2.Controls.Add(Me.Label26)
        Me.UiGroupBox2.Controls.Add(Me.txtIgv)
        Me.UiGroupBox2.Controls.Add(Me.Label27)
        Me.UiGroupBox2.Controls.Add(Me.cmbCodMon)
        Me.UiGroupBox2.Controls.Add(Me.txtTipoCambio)
        Me.UiGroupBox2.Controls.Add(Me.Label28)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.cbMoneda)
        Me.UiGroupBox2.Controls.Add(Me.txtIdLocacion)
        Me.UiGroupBox2.Controls.Add(Me.Label24)
        Me.UiGroupBox2.Controls.Add(Me.txtGuiaRemision)
        Me.UiGroupBox2.Controls.Add(Me.cbAproDoc)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(12, 34)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(431, 362)
        Me.UiGroupBox2.TabIndex = 199
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'btnBuscarLocacion
        '
        Me.btnBuscarLocacion.Image = CType(resources.GetObject("btnBuscarLocacion.Image"), System.Drawing.Image)
        Me.btnBuscarLocacion.Location = New System.Drawing.Point(194, 15)
        Me.btnBuscarLocacion.Name = "btnBuscarLocacion"
        Me.btnBuscarLocacion.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarLocacion.TabIndex = 285
        Me.btnBuscarLocacion.TabStop = False
        Me.btnBuscarLocacion.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(337, 326)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 284
        Me.Label11.Text = "Usa Vale"
        '
        'cbVale
        '
        Me.cbVale.AutoSize = True
        Me.cbVale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVale.Location = New System.Drawing.Point(396, 326)
        Me.cbVale.Name = "cbVale"
        Me.cbVale.Size = New System.Drawing.Size(15, 14)
        Me.cbVale.TabIndex = 25
        Me.cbVale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVale.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Location = New System.Drawing.Point(224, 326)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 282
        Me.Label12.Text = "Consignacion"
        '
        'cbConsignacion
        '
        Me.cbConsignacion.AutoSize = True
        Me.cbConsignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbConsignacion.Location = New System.Drawing.Point(301, 326)
        Me.cbConsignacion.Name = "cbConsignacion"
        Me.cbConsignacion.Size = New System.Drawing.Size(15, 14)
        Me.cbConsignacion.TabIndex = 24
        Me.cbConsignacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbConsignacion.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(126, 326)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "Apro. Ord."
        '
        'cbAproOrd
        '
        Me.cbAproOrd.AutoSize = True
        Me.cbAproOrd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAproOrd.Location = New System.Drawing.Point(185, 326)
        Me.cbAproOrd.Name = "cbAproOrd"
        Me.cbAproOrd.Size = New System.Drawing.Size(15, 14)
        Me.cbAproOrd.TabIndex = 23
        Me.cbAproOrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAproOrd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 278
        Me.Label1.Text = "Letra :"
        '
        'txtLetra
        '
        Me.txtLetra.BackColor = System.Drawing.SystemColors.Window
        Me.txtLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLetra.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtLetra.Location = New System.Drawing.Point(117, 283)
        Me.txtLetra.MaxLength = 50
        Me.txtLetra.Name = "txtLetra"
        Me.txtLetra.Size = New System.Drawing.Size(74, 20)
        Me.txtLetra.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(243, 260)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 276
        Me.Label10.Text = "Anticipo :"
        '
        'txtAnticipo
        '
        Me.txtAnticipo.BackColor = System.Drawing.SystemColors.Window
        Me.txtAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnticipo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtAnticipo.Location = New System.Drawing.Point(337, 257)
        Me.txtAnticipo.MaxLength = 50
        Me.txtAnticipo.Name = "txtAnticipo"
        Me.txtAnticipo.Size = New System.Drawing.Size(74, 20)
        Me.txtAnticipo.TabIndex = 20
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(23, 260)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(57, 13)
        Me.Label36.TabIndex = 274
        Me.Label36.Text = "Liq Motor :"
        '
        'txtLiqMotor
        '
        Me.txtLiqMotor.BackColor = System.Drawing.SystemColors.Window
        Me.txtLiqMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLiqMotor.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtLiqMotor.Location = New System.Drawing.Point(117, 257)
        Me.txtLiqMotor.MaxLength = 50
        Me.txtLiqMotor.Name = "txtLiqMotor"
        Me.txtLiqMotor.Size = New System.Drawing.Size(74, 20)
        Me.txtLiqMotor.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(243, 234)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 272
        Me.Label8.Text = "Val Req :"
        '
        'txtValeReq
        '
        Me.txtValeReq.BackColor = System.Drawing.SystemColors.Window
        Me.txtValeReq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValeReq.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtValeReq.Location = New System.Drawing.Point(337, 231)
        Me.txtValeReq.MaxLength = 50
        Me.txtValeReq.Name = "txtValeReq"
        Me.txtValeReq.Size = New System.Drawing.Size(74, 20)
        Me.txtValeReq.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(23, 234)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 270
        Me.Label9.Text = "Com. Mot :"
        '
        'txtComMotor
        '
        Me.txtComMotor.BackColor = System.Drawing.SystemColors.Window
        Me.txtComMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComMotor.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtComMotor.Location = New System.Drawing.Point(117, 231)
        Me.txtComMotor.MaxLength = 50
        Me.txtComMotor.Name = "txtComMotor"
        Me.txtComMotor.Size = New System.Drawing.Size(74, 20)
        Me.txtComMotor.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(243, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 268
        Me.Label6.Text = "Tra. Motor :"
        '
        'txtTraMotor
        '
        Me.txtTraMotor.BackColor = System.Drawing.SystemColors.Window
        Me.txtTraMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraMotor.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtTraMotor.Location = New System.Drawing.Point(337, 205)
        Me.txtTraMotor.MaxLength = 50
        Me.txtTraMotor.Name = "txtTraMotor"
        Me.txtTraMotor.Size = New System.Drawing.Size(74, 20)
        Me.txtTraMotor.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 266
        Me.Label7.Text = "Tra. Int :"
        '
        'txtTraInt
        '
        Me.txtTraInt.BackColor = System.Drawing.SystemColors.Window
        Me.txtTraInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraInt.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtTraInt.Location = New System.Drawing.Point(117, 205)
        Me.txtTraInt.MaxLength = 50
        Me.txtTraInt.Name = "txtTraInt"
        Me.txtTraInt.Size = New System.Drawing.Size(74, 20)
        Me.txtTraInt.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(243, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "Nota Debito :"
        '
        'txtNotaDebito
        '
        Me.txtNotaDebito.BackColor = System.Drawing.SystemColors.Window
        Me.txtNotaDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotaDebito.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNotaDebito.Location = New System.Drawing.Point(337, 179)
        Me.txtNotaDebito.MaxLength = 50
        Me.txtNotaDebito.Name = "txtNotaDebito"
        Me.txtNotaDebito.Size = New System.Drawing.Size(74, 20)
        Me.txtNotaDebito.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "Nota Credito :"
        '
        'txtNotaCredito
        '
        Me.txtNotaCredito.BackColor = System.Drawing.SystemColors.Window
        Me.txtNotaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotaCredito.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNotaCredito.Location = New System.Drawing.Point(117, 179)
        Me.txtNotaCredito.MaxLength = 50
        Me.txtNotaCredito.Name = "txtNotaCredito"
        Me.txtNotaCredito.Size = New System.Drawing.Size(74, 20)
        Me.txtNotaCredito.TabIndex = 13
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(243, 156)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(79, 13)
        Me.Label34.TabIndex = 260
        Me.Label34.Text = "Boleta Credito :"
        '
        'txtBoletaCredito
        '
        Me.txtBoletaCredito.BackColor = System.Drawing.SystemColors.Window
        Me.txtBoletaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoletaCredito.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtBoletaCredito.Location = New System.Drawing.Point(337, 153)
        Me.txtBoletaCredito.MaxLength = 50
        Me.txtBoletaCredito.Name = "txtBoletaCredito"
        Me.txtBoletaCredito.Size = New System.Drawing.Size(74, 20)
        Me.txtBoletaCredito.TabIndex = 12
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(23, 156)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(86, 13)
        Me.Label35.TabIndex = 258
        Me.Label35.Text = "Boleta Contado :"
        '
        'txtBoletaContado
        '
        Me.txtBoletaContado.BackColor = System.Drawing.SystemColors.Window
        Me.txtBoletaContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoletaContado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtBoletaContado.Location = New System.Drawing.Point(117, 153)
        Me.txtBoletaContado.MaxLength = 50
        Me.txtBoletaContado.Name = "txtBoletaContado"
        Me.txtBoletaContado.Size = New System.Drawing.Size(74, 20)
        Me.txtBoletaContado.TabIndex = 11
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(243, 130)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(73, 13)
        Me.Label32.TabIndex = 256
        Me.Label32.Text = "Fact. Credito :"
        '
        'txtFactCredito
        '
        Me.txtFactCredito.BackColor = System.Drawing.SystemColors.Window
        Me.txtFactCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactCredito.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtFactCredito.Location = New System.Drawing.Point(337, 127)
        Me.txtFactCredito.MaxLength = 50
        Me.txtFactCredito.Name = "txtFactCredito"
        Me.txtFactCredito.Size = New System.Drawing.Size(74, 20)
        Me.txtFactCredito.TabIndex = 10
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(23, 130)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(80, 13)
        Me.Label33.TabIndex = 254
        Me.Label33.Text = "Fact. Contado :"
        '
        'txtFactContado
        '
        Me.txtFactContado.BackColor = System.Drawing.SystemColors.Window
        Me.txtFactContado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactContado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtFactContado.Location = New System.Drawing.Point(117, 127)
        Me.txtFactContado.MaxLength = 50
        Me.txtFactContado.Name = "txtFactContado"
        Me.txtFactContado.Size = New System.Drawing.Size(74, 20)
        Me.txtFactContado.TabIndex = 9
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(243, 103)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(92, 13)
        Me.Label31.TabIndex = 252
        Me.Label31.Text = "Guia Devolucion :"
        '
        'txtGuiaDevolucion
        '
        Me.txtGuiaDevolucion.BackColor = System.Drawing.SystemColors.Window
        Me.txtGuiaDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuiaDevolucion.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtGuiaDevolucion.Location = New System.Drawing.Point(337, 100)
        Me.txtGuiaDevolucion.MaxLength = 50
        Me.txtGuiaDevolucion.Name = "txtGuiaDevolucion"
        Me.txtGuiaDevolucion.Size = New System.Drawing.Size(74, 20)
        Me.txtGuiaDevolucion.TabIndex = 8
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(23, 103)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(81, 13)
        Me.Label30.TabIndex = 250
        Me.Label30.Text = "Guia Remision :"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Location = New System.Drawing.Point(25, 326)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(58, 13)
        Me.Label29.TabIndex = 249
        Me.Label29.Text = "Apro. Doc."
        '
        'txtFactor
        '
        Me.txtFactor.Location = New System.Drawing.Point(229, 71)
        Me.txtFactor.MaxLength = 12
        Me.txtFactor.Name = "txtFactor"
        Me.txtFactor.Size = New System.Drawing.Size(57, 20)
        Me.txtFactor.TabIndex = 5
        Me.txtFactor.Text = "0.00"
        Me.txtFactor.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtDscto
        '
        Me.txtDscto.Location = New System.Drawing.Point(354, 71)
        Me.txtDscto.MaxLength = 12
        Me.txtDscto.Name = "txtDscto"
        Me.txtDscto.Size = New System.Drawing.Size(57, 20)
        Me.txtDscto.TabIndex = 6
        Me.txtDscto.Text = "0.00"
        Me.txtDscto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(291, 75)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(59, 13)
        Me.Label25.TabIndex = 248
        Me.Label25.Text = "Descuento"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Location = New System.Drawing.Point(186, 75)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(37, 13)
        Me.Label26.TabIndex = 247
        Me.Label26.Text = "Factor"
        '
        'txtIgv
        '
        Me.txtIgv.Location = New System.Drawing.Point(244, 43)
        Me.txtIgv.MaxLength = 12
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.Size = New System.Drawing.Size(42, 20)
        Me.txtIgv.TabIndex = 3
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(207, 46)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 246
        Me.Label27.Text = "I.G.V."
        '
        'cmbCodMon
        '
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(140, 43)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(51, 20)
        Me.cmbCodMon.TabIndex = 2
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTipoCambio.Location = New System.Drawing.Point(357, 43)
        Me.txtTipoCambio.MaxLength = 20
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(54, 20)
        Me.txtTipoCambio.TabIndex = 4
        Me.txtTipoCambio.Text = "0.0000"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(298, 47)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(52, 13)
        Me.Label28.TabIndex = 245
        Me.Label28.Text = "T.Cambio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 239
        Me.Label5.Text = "Moneda :"
        '
        'cbMoneda
        '
        Me.cbMoneda.AutoSize = True
        Me.cbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMoneda.Location = New System.Drawing.Point(117, 47)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(15, 14)
        Me.cbMoneda.TabIndex = 238
        Me.cbMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbMoneda.UseVisualStyleBackColor = True
        '
        'txtIdLocacion
        '
        Me.txtIdLocacion.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdLocacion.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdLocacion.Location = New System.Drawing.Point(117, 16)
        Me.txtIdLocacion.MaxLength = 20
        Me.txtIdLocacion.Name = "txtIdLocacion"
        Me.txtIdLocacion.ReadOnly = True
        Me.txtIdLocacion.Size = New System.Drawing.Size(74, 20)
        Me.txtIdLocacion.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(23, 19)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(69, 13)
        Me.Label24.TabIndex = 235
        Me.Label24.Text = "Id Locacion :"
        '
        'txtGuiaRemision
        '
        Me.txtGuiaRemision.BackColor = System.Drawing.SystemColors.Window
        Me.txtGuiaRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuiaRemision.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtGuiaRemision.Location = New System.Drawing.Point(117, 100)
        Me.txtGuiaRemision.MaxLength = 50
        Me.txtGuiaRemision.Name = "txtGuiaRemision"
        Me.txtGuiaRemision.Size = New System.Drawing.Size(74, 20)
        Me.txtGuiaRemision.TabIndex = 7
        '
        'cbAproDoc
        '
        Me.cbAproDoc.AutoSize = True
        Me.cbAproDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAproDoc.Location = New System.Drawing.Point(84, 326)
        Me.cbAproDoc.Name = "cbAproDoc"
        Me.cbAproDoc.Size = New System.Drawing.Size(15, 14)
        Me.cbAproDoc.TabIndex = 22
        Me.cbAproDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAproDoc.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmParametroLocacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(457, 413)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(465, 447)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(465, 447)
        Me.Name = "frmParametroLocacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parametro Locacion"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cbMoneda As CheckBox
    Friend WithEvents txtIdLocacion As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtGuiaRemision As TextBox
    Friend WithEvents cbAproDoc As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFactor As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDscto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label27 As Label
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label28 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents txtGuiaDevolucion As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbVale As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cbConsignacion As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbAproOrd As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLetra As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtAnticipo As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents txtLiqMotor As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtValeReq As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtComMotor As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTraMotor As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTraInt As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNotaDebito As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNotaCredito As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents txtBoletaCredito As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents txtBoletaContado As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtFactCredito As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txtFactContado As TextBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnBuscarLocacion As Button
    Friend WithEvents txtTipoCambio As TextBox
End Class
