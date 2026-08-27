<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepVencimientos
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
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbDocu_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCobrador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepVencimientos))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbDocu = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.rcTodoCobrador = New System.Windows.Forms.CheckBox()
        Me.cmbCobrador = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblCobrador = New System.Windows.Forms.Label()
        Me.rcCliente = New System.Windows.Forms.CheckBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbCastigos = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbProvisiones = New System.Windows.Forms.RadioButton()
        Me.rbCtasCtes = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbFecVen = New System.Windows.Forms.RadioButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rbDescendente = New System.Windows.Forms.RadioButton()
        Me.rbAscendente = New System.Windows.Forms.RadioButton()
        Me.rbFecEmision = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.rcTodos = New System.Windows.Forms.RadioButton()
        Me.rcPendientes = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDocu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCobrador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(208, 28)
        Me.cbFecFinal.MinDate = New Date(1992, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 38
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
        Me.cbFecInicio.Location = New System.Drawing.Point(56, 29)
        Me.cbFecInicio.MinDate = New Date(1992, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 37
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(174, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 16)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Al :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 16)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Del :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(218, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Moneda:"
        Me.Label1.Visible = False
        '
        'cmbCodMon
        '
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodMon.Location = New System.Drawing.Point(221, 164)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(65, 20)
        Me.cmbCodMon.TabIndex = 111
        Me.cmbCodMon.Visible = False
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbDocu
        '
        Me.cmbDocu.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbDocu_DesignTimeLayout.LayoutString = resources.GetString("cmbDocu_DesignTimeLayout.LayoutString")
        Me.cmbDocu.DesignTimeLayout = cmbDocu_DesignTimeLayout
        Me.cmbDocu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDocu.Location = New System.Drawing.Point(10, 164)
        Me.cmbDocu.Name = "cmbDocu"
        Me.cmbDocu.SelectedIndex = -1
        Me.cmbDocu.SelectedItem = Nothing
        Me.cmbDocu.Size = New System.Drawing.Size(194, 20)
        Me.cmbDocu.TabIndex = 119
        Me.cmbDocu.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbDocu.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'rcTodoCobrador
        '
        Me.rcTodoCobrador.AutoSize = True
        Me.rcTodoCobrador.BackColor = System.Drawing.SystemColors.Window
        Me.rcTodoCobrador.Checked = True
        Me.rcTodoCobrador.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rcTodoCobrador.Location = New System.Drawing.Point(169, 20)
        Me.rcTodoCobrador.Name = "rcTodoCobrador"
        Me.rcTodoCobrador.Size = New System.Drawing.Size(65, 19)
        Me.rcTodoCobrador.TabIndex = 105
        Me.rcTodoCobrador.Text = "Todos"
        Me.rcTodoCobrador.UseVisualStyleBackColor = False
        '
        'cmbCobrador
        '
        Me.cmbCobrador.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCobrador_DesignTimeLayout.LayoutString = resources.GetString("cmbCobrador_DesignTimeLayout.LayoutString")
        Me.cmbCobrador.DesignTimeLayout = cmbCobrador_DesignTimeLayout
        Me.cmbCobrador.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbCobrador.Location = New System.Drawing.Point(93, 45)
        Me.cmbCobrador.Name = "cmbCobrador"
        Me.cmbCobrador.SelectedIndex = -1
        Me.cmbCobrador.SelectedItem = Nothing
        Me.cmbCobrador.Size = New System.Drawing.Size(348, 21)
        Me.cmbCobrador.TabIndex = 104
        Me.cmbCobrador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblCobrador
        '
        Me.lblCobrador.AutoSize = True
        Me.lblCobrador.BackColor = System.Drawing.SystemColors.Window
        Me.lblCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobrador.Location = New System.Drawing.Point(10, 49)
        Me.lblCobrador.Name = "lblCobrador"
        Me.lblCobrador.Size = New System.Drawing.Size(81, 16)
        Me.lblCobrador.TabIndex = 103
        Me.lblCobrador.Text = "Cobrador :"
        '
        'rcCliente
        '
        Me.rcCliente.AutoSize = True
        Me.rcCliente.BackColor = System.Drawing.SystemColors.Window
        Me.rcCliente.Checked = True
        Me.rcCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rcCliente.Location = New System.Drawing.Point(169, 19)
        Me.rcCliente.Name = "rcCliente"
        Me.rcCliente.Size = New System.Drawing.Size(61, 17)
        Me.rcCliente.TabIndex = 18
        Me.rcCliente.Text = "Todos"
        Me.rcCliente.UseVisualStyleBackColor = False
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(10, 46)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(56, 16)
        Me.lblCliente.TabIndex = 17
        Me.lblCliente.Text = "Cliente"
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(12, 115)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(160, 20)
        Me.cmbUnidad.TabIndex = 162
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbFecFinal)
        Me.GroupBox1.Controls.Add(Me.cbFecInicio)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 71)
        Me.GroupBox1.TabIndex = 163
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FECHAS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbCastigos)
        Me.GroupBox2.Controls.Add(Me.rbTodos)
        Me.GroupBox2.Controls.Add(Me.rbProvisiones)
        Me.GroupBox2.Controls.Add(Me.rbCtasCtes)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(343, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(122, 130)
        Me.GroupBox2.TabIndex = 164
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TIP CTA"
        '
        'rbCastigos
        '
        Me.rbCastigos.AutoSize = True
        Me.rbCastigos.Location = New System.Drawing.Point(15, 98)
        Me.rbCastigos.Name = "rbCastigos"
        Me.rbCastigos.Size = New System.Drawing.Size(80, 19)
        Me.rbCastigos.TabIndex = 174
        Me.rbCastigos.Text = "Castigos"
        Me.rbCastigos.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(15, 23)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(64, 19)
        Me.rbTodos.TabIndex = 171
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbProvisiones
        '
        Me.rbProvisiones.AutoSize = True
        Me.rbProvisiones.Location = New System.Drawing.Point(15, 73)
        Me.rbProvisiones.Name = "rbProvisiones"
        Me.rbProvisiones.Size = New System.Drawing.Size(99, 19)
        Me.rbProvisiones.TabIndex = 173
        Me.rbProvisiones.Text = "Provisiones"
        Me.rbProvisiones.UseVisualStyleBackColor = True
        '
        'rbCtasCtes
        '
        Me.rbCtasCtes.AutoSize = True
        Me.rbCtasCtes.Checked = True
        Me.rbCtasCtes.Location = New System.Drawing.Point(15, 48)
        Me.rbCtasCtes.Name = "rbCtasCtes"
        Me.rbCtasCtes.Size = New System.Drawing.Size(85, 19)
        Me.rbCtasCtes.TabIndex = 172
        Me.rbCtasCtes.TabStop = True
        Me.rbCtasCtes.Text = "Ctas Ctes"
        Me.rbCtasCtes.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 16)
        Me.Label2.TabIndex = 165
        Me.Label2.Text = "Unidad Negocio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 16)
        Me.Label3.TabIndex = 166
        Me.Label3.Text = "Documentos:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rcTodoCobrador)
        Me.GroupBox3.Controls.Add(Me.lblCobrador)
        Me.GroupBox3.Controls.Add(Me.cmbCobrador)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 194)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 81)
        Me.GroupBox3.TabIndex = 167
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "COBRADOR"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rcCliente)
        Me.GroupBox4.Controls.Add(Me.btnCliente)
        Me.GroupBox4.Controls.Add(Me.lblCliente)
        Me.GroupBox4.Controls.Add(Me.txtCliente)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 281)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(455, 83)
        Me.GroupBox4.TabIndex = 168
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "CLIENTE"
        '
        'btnCliente
        '
        Me.btnCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnCliente.Location = New System.Drawing.Point(380, 43)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnCliente.TabIndex = 161
        Me.btnCliente.TabStop = False
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtCliente.Location = New System.Drawing.Point(91, 45)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(288, 20)
        Me.txtCliente.TabIndex = 160
        Me.txtCliente.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rbFecVen)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.rbFecEmision)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 370)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(337, 100)
        Me.GroupBox5.TabIndex = 169
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "ORDENAMIENTO"
        '
        'rbFecVen
        '
        Me.rbFecVen.AutoSize = True
        Me.rbFecVen.Location = New System.Drawing.Point(13, 57)
        Me.rbFecVen.Name = "rbFecVen"
        Me.rbFecVen.Size = New System.Drawing.Size(173, 19)
        Me.rbFecVen.TabIndex = 171
        Me.rbFecVen.Text = "Por Fecha Vencimiento"
        Me.rbFecVen.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rbDescendente)
        Me.GroupBox6.Controls.Add(Me.rbAscendente)
        Me.GroupBox6.Location = New System.Drawing.Point(202, 20)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(122, 65)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        '
        'rbDescendente
        '
        Me.rbDescendente.AutoSize = True
        Me.rbDescendente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDescendente.Location = New System.Drawing.Point(8, 38)
        Me.rbDescendente.Name = "rbDescendente"
        Me.rbDescendente.Size = New System.Drawing.Size(109, 19)
        Me.rbDescendente.TabIndex = 171
        Me.rbDescendente.Text = "Descendente"
        Me.rbDescendente.UseVisualStyleBackColor = True
        '
        'rbAscendente
        '
        Me.rbAscendente.AutoSize = True
        Me.rbAscendente.Checked = True
        Me.rbAscendente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAscendente.Location = New System.Drawing.Point(8, 14)
        Me.rbAscendente.Name = "rbAscendente"
        Me.rbAscendente.Size = New System.Drawing.Size(99, 19)
        Me.rbAscendente.TabIndex = 170
        Me.rbAscendente.TabStop = True
        Me.rbAscendente.Text = "Ascendente"
        Me.rbAscendente.UseVisualStyleBackColor = True
        '
        'rbFecEmision
        '
        Me.rbFecEmision.AutoSize = True
        Me.rbFecEmision.Checked = True
        Me.rbFecEmision.Location = New System.Drawing.Point(13, 34)
        Me.rbFecEmision.Name = "rbFecEmision"
        Me.rbFecEmision.Size = New System.Drawing.Size(124, 19)
        Me.rbFecEmision.TabIndex = 170
        Me.rbFecEmision.TabStop = True
        Me.rbFecEmision.Text = "Por Documento"
        Me.rbFecEmision.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rcTodos)
        Me.GroupBox7.Controls.Add(Me.rcPendientes)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(355, 370)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(112, 100)
        Me.GroupBox7.TabIndex = 170
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "CONDICION"
        '
        'rcTodos
        '
        Me.rcTodos.AutoSize = True
        Me.rcTodos.Location = New System.Drawing.Point(10, 59)
        Me.rcTodos.Name = "rcTodos"
        Me.rcTodos.Size = New System.Drawing.Size(64, 19)
        Me.rcTodos.TabIndex = 1
        Me.rcTodos.Text = "Todos"
        Me.rcTodos.UseVisualStyleBackColor = True
        '
        'rcPendientes
        '
        Me.rcPendientes.AutoSize = True
        Me.rcPendientes.Checked = True
        Me.rcPendientes.Location = New System.Drawing.Point(10, 34)
        Me.rcPendientes.Name = "rcPendientes"
        Me.rcPendientes.Size = New System.Drawing.Size(97, 19)
        Me.rcPendientes.TabIndex = 0
        Me.rcPendientes.TabStop = True
        Me.rcPendientes.Text = "Pendientes"
        Me.rcPendientes.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(160, 479)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 27)
        Me.btnAceptar.TabIndex = 171
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
        Me.btnCancelar.Location = New System.Drawing.Point(244, 479)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 172
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepVencimientos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(476, 513)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbUnidad)
        Me.Controls.Add(Me.cmbDocu)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbCodMon)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmRepVencimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Vencimientos "
        CType(Me.OfficeFormAdorner1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbCodMon,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbDocu,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbCobrador,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbUnidad,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        Me.GroupBox5.ResumeLayout(false)
        Me.GroupBox5.PerformLayout
        Me.GroupBox6.ResumeLayout(false)
        Me.GroupBox6.PerformLayout
        Me.GroupBox7.ResumeLayout(false)
        Me.GroupBox7.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbDocu As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents rcTodoCobrador As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCobrador As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblCobrador As System.Windows.Forms.Label
    Friend WithEvents rcCliente As System.Windows.Forms.CheckBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents rcTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rcPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rbFecVen As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDescendente As System.Windows.Forms.RadioButton
    Friend WithEvents rbAscendente As System.Windows.Forms.RadioButton
    Friend WithEvents rbFecEmision As System.Windows.Forms.RadioButton
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents rbCastigos As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbProvisiones As System.Windows.Forms.RadioButton
    Friend WithEvents rbCtasCtes As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
