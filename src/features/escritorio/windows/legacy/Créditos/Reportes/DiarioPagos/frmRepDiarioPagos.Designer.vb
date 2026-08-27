<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepDiarioPagos
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
        Dim cmbDocu_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbTipoPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbBanco_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepDiarioPagos))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmbDocu = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbTipoPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cbMonedaDolares = New System.Windows.Forms.CheckBox()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.rbBuscarCliente = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbCastigos = New System.Windows.Forms.RadioButton()
        Me.rbProvisiones = New System.Windows.Forms.RadioButton()
        Me.rbCtasCtes = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbExportExcel = New System.Windows.Forms.RadioButton()
        Me.rbPantalla = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox7 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rcEfectivo = New System.Windows.Forms.CheckBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.UiGroupBox8 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDocu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTipoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        CType(Me.UiGroupBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox7.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.UiGroupBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox8.SuspendLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmbDocu
        '
        Me.cmbDocu.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbDocu_DesignTimeLayout.LayoutString = resources.GetString("cmbDocu_DesignTimeLayout.LayoutString")
        Me.cmbDocu.DesignTimeLayout = cmbDocu_DesignTimeLayout
        Me.cmbDocu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDocu.Location = New System.Drawing.Point(110, 26)
        Me.cmbDocu.Name = "cmbDocu"
        Me.cmbDocu.SelectedIndex = -1
        Me.cmbDocu.SelectedItem = Nothing
        Me.cmbDocu.Size = New System.Drawing.Size(194, 20)
        Me.cmbDocu.TabIndex = 9
        Me.cmbDocu.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbDocu.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbTipoPago
        '
        Me.cbTipoPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbTipoPago_DesignTimeLayout.LayoutString = resources.GetString("cbTipoPago_DesignTimeLayout.LayoutString")
        Me.cbTipoPago.DesignTimeLayout = cbTipoPago_DesignTimeLayout
        Me.cbTipoPago.Location = New System.Drawing.Point(36, 43)
        Me.cbTipoPago.MaximumSize = New System.Drawing.Size(250, 0)
        Me.cbTipoPago.MinimumSize = New System.Drawing.Size(250, 0)
        Me.cbTipoPago.Name = "cbTipoPago"
        Me.cbTipoPago.SelectedIndex = -1
        Me.cbTipoPago.SelectedItem = Nothing
        Me.cbTipoPago.Size = New System.Drawing.Size(250, 21)
        Me.cbTipoPago.TabIndex = 11
        Me.cbTipoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(295, 24)
        Me.cbFecFinal.MinDate = New Date(1992, 2, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 34
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
        Me.cbFecInicio.Location = New System.Drawing.Point(97, 24)
        Me.cbFecInicio.MinDate = New Date(1992, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 33
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(383, 470)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(25, 20)
        Me.DataGridView1.TabIndex = 49
        Me.DataGridView1.Visible = False
        '
        'cbMonedaDolares
        '
        Me.cbMonedaDolares.AutoSize = True
        Me.cbMonedaDolares.BackColor = System.Drawing.SystemColors.Window
        Me.cbMonedaDolares.Location = New System.Drawing.Point(59, 25)
        Me.cbMonedaDolares.Name = "cbMonedaDolares"
        Me.cbMonedaDolares.Size = New System.Drawing.Size(197, 19)
        Me.cbMonedaDolares.TabIndex = 110
        Me.cbMonedaDolares.Text = "Mantener Moneda Dolares"
        Me.cbMonedaDolares.UseVisualStyleBackColor = False
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.Label1)
        Me.UiGroupBox4.Controls.Add(Me.Label2)
        Me.UiGroupBox4.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox4.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(460, 59)
        Me.UiGroupBox4.TabIndex = 125
        Me.UiGroupBox4.Text = "FECHAS DE PAGO"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(54, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 15)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Del :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(262, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 15)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "Al :"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.UiGroupBox1.Controls.Add(Me.txtCliente)
        Me.UiGroupBox1.Controls.Add(Me.lblCliente)
        Me.UiGroupBox1.Controls.Add(Me.rbBuscarCliente)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 136)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(460, 73)
        Me.UiGroupBox1.TabIndex = 126
        Me.UiGroupBox1.Text = "CLIENTE"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(390, 38)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 154
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtCliente.Location = New System.Drawing.Point(101, 40)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(288, 20)
        Me.txtCliente.TabIndex = 152
        Me.txtCliente.TabStop = False
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.BackColor = System.Drawing.SystemColors.Window
        Me.lblCliente.Location = New System.Drawing.Point(43, 41)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(52, 15)
        Me.lblCliente.TabIndex = 153
        Me.lblCliente.Text = "Cliente"
        '
        'rbBuscarCliente
        '
        Me.rbBuscarCliente.AutoSize = True
        Me.rbBuscarCliente.BackColor = System.Drawing.SystemColors.Window
        Me.rbBuscarCliente.Checked = True
        Me.rbBuscarCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbBuscarCliente.Location = New System.Drawing.Point(207, 18)
        Me.rbBuscarCliente.Name = "rbBuscarCliente"
        Me.rbBuscarCliente.Size = New System.Drawing.Size(65, 19)
        Me.rbBuscarCliente.TabIndex = 151
        Me.rbBuscarCliente.TabStop = False
        Me.rbBuscarCliente.Text = "Todos"
        Me.rbBuscarCliente.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Location = New System.Drawing.Point(17, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Banco"
        '
        'cmbBanco
        '
        Me.cmbBanco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbBanco_DesignTimeLayout.LayoutString = resources.GetString("cmbBanco_DesignTimeLayout.LayoutString")
        Me.cmbBanco.DesignTimeLayout = cmbBanco_DesignTimeLayout
        Me.cmbBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBanco.Location = New System.Drawing.Point(87, 55)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.SelectedIndex = -1
        Me.cmbBanco.SelectedItem = Nothing
        Me.cmbBanco.Size = New System.Drawing.Size(217, 19)
        Me.cmbBanco.TabIndex = 10
        Me.cmbBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.cbMonedaDolares)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(152, 300)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(320, 60)
        Me.UiGroupBox2.TabIndex = 127
        Me.UiGroupBox2.Text = "MONEDA"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.rbCastigos)
        Me.UiGroupBox3.Controls.Add(Me.rbProvisiones)
        Me.UiGroupBox3.Controls.Add(Me.rbCtasCtes)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(12, 220)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(125, 126)
        Me.UiGroupBox3.TabIndex = 127
        Me.UiGroupBox3.Text = "TIP CTA"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbCastigos
        '
        Me.rbCastigos.AutoSize = True
        Me.rbCastigos.BackColor = System.Drawing.SystemColors.Window
        Me.rbCastigos.Location = New System.Drawing.Point(15, 84)
        Me.rbCastigos.Name = "rbCastigos"
        Me.rbCastigos.Size = New System.Drawing.Size(80, 19)
        Me.rbCastigos.TabIndex = 6
        Me.rbCastigos.TabStop = True
        Me.rbCastigos.Text = "Castigos"
        Me.rbCastigos.UseVisualStyleBackColor = False
        '
        'rbProvisiones
        '
        Me.rbProvisiones.AutoSize = True
        Me.rbProvisiones.BackColor = System.Drawing.SystemColors.Window
        Me.rbProvisiones.Location = New System.Drawing.Point(15, 56)
        Me.rbProvisiones.Name = "rbProvisiones"
        Me.rbProvisiones.Size = New System.Drawing.Size(99, 19)
        Me.rbProvisiones.TabIndex = 5
        Me.rbProvisiones.TabStop = True
        Me.rbProvisiones.Text = "Provisiones"
        Me.rbProvisiones.UseVisualStyleBackColor = False
        '
        'rbCtasCtes
        '
        Me.rbCtasCtes.AutoSize = True
        Me.rbCtasCtes.BackColor = System.Drawing.SystemColors.Window
        Me.rbCtasCtes.Checked = True
        Me.rbCtasCtes.Location = New System.Drawing.Point(15, 28)
        Me.rbCtasCtes.Name = "rbCtasCtes"
        Me.rbCtasCtes.Size = New System.Drawing.Size(93, 19)
        Me.rbCtasCtes.TabIndex = 4
        Me.rbCtasCtes.TabStop = True
        Me.rbCtasCtes.Text = "Ctas. Ctes."
        Me.rbCtasCtes.UseVisualStyleBackColor = False
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.Controls.Add(Me.rbExportExcel)
        Me.UiGroupBox5.Controls.Add(Me.rbPantalla)
        Me.UiGroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox5.Location = New System.Drawing.Point(12, 357)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(125, 98)
        Me.UiGroupBox5.TabIndex = 127
        Me.UiGroupBox5.Text = "EXPORTAR"
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbExportExcel
        '
        Me.rbExportExcel.AutoSize = True
        Me.rbExportExcel.BackColor = System.Drawing.SystemColors.Window
        Me.rbExportExcel.Location = New System.Drawing.Point(17, 57)
        Me.rbExportExcel.Name = "rbExportExcel"
        Me.rbExportExcel.Size = New System.Drawing.Size(60, 19)
        Me.rbExportExcel.TabIndex = 3
        Me.rbExportExcel.TabStop = True
        Me.rbExportExcel.Text = "Excel"
        Me.rbExportExcel.UseVisualStyleBackColor = False
        '
        'rbPantalla
        '
        Me.rbPantalla.AutoSize = True
        Me.rbPantalla.BackColor = System.Drawing.SystemColors.Window
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(17, 28)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(78, 19)
        Me.rbPantalla.TabIndex = 2
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.UseVisualStyleBackColor = False
        '
        'UiGroupBox7
        '
        Me.UiGroupBox7.Controls.Add(Me.rcEfectivo)
        Me.UiGroupBox7.Controls.Add(Me.cbTipoPago)
        Me.UiGroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox7.Location = New System.Drawing.Point(152, 218)
        Me.UiGroupBox7.Name = "UiGroupBox7"
        Me.UiGroupBox7.Size = New System.Drawing.Size(320, 76)
        Me.UiGroupBox7.TabIndex = 128
        Me.UiGroupBox7.Text = "FORMA DE PAGO"
        Me.UiGroupBox7.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rcEfectivo
        '
        Me.rcEfectivo.AutoSize = True
        Me.rcEfectivo.BackColor = System.Drawing.SystemColors.Window
        Me.rcEfectivo.Checked = True
        Me.rcEfectivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rcEfectivo.Location = New System.Drawing.Point(101, 20)
        Me.rcEfectivo.Name = "rcEfectivo"
        Me.rcEfectivo.Size = New System.Drawing.Size(120, 19)
        Me.rcEfectivo.TabIndex = 152
        Me.rcEfectivo.TabStop = False
        Me.rcEfectivo.Text = "Pagos Efectivo"
        Me.rcEfectivo.UseVisualStyleBackColor = False
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.Controls.Add(Me.Label3)
        Me.UiGroupBox6.Controls.Add(Me.cmbDocu)
        Me.UiGroupBox6.Controls.Add(Me.cmbBanco)
        Me.UiGroupBox6.Controls.Add(Me.Label5)
        Me.UiGroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox6.Location = New System.Drawing.Point(152, 366)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(320, 89)
        Me.UiGroupBox6.TabIndex = 129
        Me.UiGroupBox6.Text = "Datos de Búsqueda"
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Location = New System.Drawing.Point(17, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "Documentos"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(161, 470)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 27)
        Me.btnAceptar.TabIndex = 130
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(245, 470)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 131
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'UiGroupBox8
        '
        Me.UiGroupBox8.Controls.Add(Me.cmbUnidad)
        Me.UiGroupBox8.Controls.Add(Me.Label4)
        Me.UiGroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox8.Location = New System.Drawing.Point(12, 77)
        Me.UiGroupBox8.Name = "UiGroupBox8"
        Me.UiGroupBox8.Size = New System.Drawing.Size(460, 53)
        Me.UiGroupBox8.TabIndex = 132
        Me.UiGroupBox8.Text = "UNIDAD DE NEGOCIO"
        Me.UiGroupBox8.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(179, 22)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(145, 20)
        Me.cmbUnidad.TabIndex = 154
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Location = New System.Drawing.Point(43, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 15)
        Me.Label4.TabIndex = 153
        Me.Label4.Text = "Unidad de Negocio"
        '
        'frmRepDiarioPagos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(484, 507)
        Me.Controls.Add(Me.UiGroupBox8)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.UiGroupBox7)
        Me.Controls.Add(Me.UiGroupBox5)
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepDiarioPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Diario de Pagos"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDocu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTipoPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.UiGroupBox5.PerformLayout()
        CType(Me.UiGroupBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox7.ResumeLayout(False)
        Me.UiGroupBox7.PerformLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.UiGroupBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox8.ResumeLayout(False)
        Me.UiGroupBox8.PerformLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmbDocu As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbTipoPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cbMonedaDolares As System.Windows.Forms.CheckBox
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents rbBuscarCliente As System.Windows.Forms.CheckBox
    Friend WithEvents rbCastigos As System.Windows.Forms.RadioButton
    Friend WithEvents rbProvisiones As System.Windows.Forms.RadioButton
    Friend WithEvents rbCtasCtes As System.Windows.Forms.RadioButton
    Friend WithEvents rbExportExcel As System.Windows.Forms.RadioButton
    Friend WithEvents rbPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox7 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rcEfectivo As System.Windows.Forms.CheckBox
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox8 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
