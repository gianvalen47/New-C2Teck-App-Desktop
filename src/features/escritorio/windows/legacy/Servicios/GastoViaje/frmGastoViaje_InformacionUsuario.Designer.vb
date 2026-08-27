<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGastoViaje_InformacionUsuario
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGastoViaje_InformacionUsuario))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtCarnet = New System.Windows.Forms.TextBox
        Me.txtNumDoc = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtEstCivil = New System.Windows.Forms.TextBox
        Me.txtTipoVia = New System.Windows.Forms.TextBox
        Me.txtNomVia = New System.Windows.Forms.TextBox
        Me.txtNroVia = New System.Windows.Forms.TextBox
        Me.txtTipoZona = New System.Windows.Forms.TextBox
        Me.txtNomZona = New System.Windows.Forms.TextBox
        Me.txtReferencia = New System.Windows.Forms.TextBox
        Me.txtInterior = New System.Windows.Forms.TextBox
        Me.txtUbigeo = New System.Windows.Forms.TextBox
        Me.txtTelefonos = New System.Windows.Forms.TextBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.txtEmpresa = New System.Windows.Forms.TextBox
        Me.txtArea = New System.Windows.Forms.TextBox
        Me.txtClase = New System.Windows.Forms.TextBox
        Me.txtCargo = New System.Windows.Forms.TextBox
        Me.chkVigente = New System.Windows.Forms.CheckBox
        Me.chkMarcaTarjeta = New System.Windows.Forms.CheckBox
        Me.txtFechaIngreso = New System.Windows.Forms.TextBox
        Me.txtFechaCese = New System.Windows.Forms.TextBox
        Me.txtFecIngContrato = New System.Windows.Forms.TextBox
        Me.txtFecCeseContrato = New System.Windows.Forms.TextBox
        Me.txtFecIngEstable = New System.Windows.Forms.TextBox
        Me.txtFecIniPlanilla = New System.Windows.Forms.TextBox
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox
        Me.rbFemenino = New System.Windows.Forms.RadioButton
        Me.rbMasculino = New System.Windows.Forms.RadioButton
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 436)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(705, 20)
        Me.ssBarra.TabIndex = 148
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
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(705, 31)
        Me.ToolStrip.TabIndex = 147
        Me.ToolStrip.Text = "ToolStrip"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Código"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(290, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Área"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(256, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 15)
        Me.Label3.TabIndex = 158
        Me.Label3.Text = "Teléfonos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(249, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 15)
        Me.Label4.TabIndex = 159
        Me.Label4.Text = "Nom. Zona"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(261, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 160
        Me.Label5.Text = "Nom. Vía"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(264, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 15)
        Me.Label6.TabIndex = 161
        Me.Label6.Text = "Est. Civil"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(277, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 15)
        Me.Label7.TabIndex = 162
        Me.Label7.Text = "Carnet"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(34, 234)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 15)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "Cargo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 208)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 15)
        Me.Label10.TabIndex = 164
        Me.Label10.Text = "Empresa"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(26, 182)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 15)
        Me.Label11.TabIndex = 165
        Me.Label11.Text = "Ubigeo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(2, 156)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 15)
        Me.Label12.TabIndex = 166
        Me.Label12.Text = "Referencia"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 130)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 15)
        Me.Label13.TabIndex = 167
        Me.Label13.Text = "Tipo Zona"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(20, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 15)
        Me.Label14.TabIndex = 168
        Me.Label14.Text = "Tipo Vía"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(40, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 15)
        Me.Label15.TabIndex = 169
        Me.Label15.Text = "Sexo"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(21, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 15)
        Me.Label16.TabIndex = 170
        Me.Label16.Text = "Nombre"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(469, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 15)
        Me.Label17.TabIndex = 176
        Me.Label17.Text = "Num. Doc"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(493, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 15)
        Me.Label18.TabIndex = 175
        Me.Label18.Text = "Nº Vía"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(486, 130)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 15)
        Me.Label19.TabIndex = 174
        Me.Label19.Text = "Interior"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(495, 182)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 15)
        Me.Label20.TabIndex = 173
        Me.Label20.Text = "Email"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(496, 208)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 15)
        Me.Label21.TabIndex = 172
        Me.Label21.Text = "Clase"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(86, 303)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 15)
        Me.Label22.TabIndex = 179
        Me.Label22.Text = "Fecha Ingreso"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(24, 329)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(160, 15)
        Me.Label23.TabIndex = 178
        Me.Label23.Text = "Fecha Ingreso Contrato "
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(34, 355)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(150, 15)
        Me.Label24.TabIndex = 177
        Me.Label24.Text = "Fecha Ingreso Estable"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(433, 303)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(82, 15)
        Me.Label25.TabIndex = 182
        Me.Label25.Text = "Fecha Cese"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(375, 329)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(140, 15)
        Me.Label26.TabIndex = 181
        Me.Label26.Text = "Fecha Cese Contrato"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(377, 355)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(138, 15)
        Me.Label27.TabIndex = 180
        Me.Label27.Text = "Fecha Inicio Planilla"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodigo.Location = New System.Drawing.Point(85, 25)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(119, 20)
        Me.txtCodigo.TabIndex = 183
        '
        'txtCarnet
        '
        Me.txtCarnet.BackColor = System.Drawing.SystemColors.Control
        Me.txtCarnet.Location = New System.Drawing.Point(332, 25)
        Me.txtCarnet.Name = "txtCarnet"
        Me.txtCarnet.ReadOnly = True
        Me.txtCarnet.Size = New System.Drawing.Size(120, 20)
        Me.txtCarnet.TabIndex = 184
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.SystemColors.Control
        Me.txtNumDoc.Location = New System.Drawing.Point(545, 25)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(93, 20)
        Me.txtNumDoc.TabIndex = 185
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Control
        Me.txtNombre.Location = New System.Drawing.Point(85, 51)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(367, 20)
        Me.txtNombre.TabIndex = 186
        '
        'txtEstCivil
        '
        Me.txtEstCivil.BackColor = System.Drawing.SystemColors.Control
        Me.txtEstCivil.Location = New System.Drawing.Point(332, 77)
        Me.txtEstCivil.Name = "txtEstCivil"
        Me.txtEstCivil.ReadOnly = True
        Me.txtEstCivil.Size = New System.Drawing.Size(120, 20)
        Me.txtEstCivil.TabIndex = 188
        '
        'txtTipoVia
        '
        Me.txtTipoVia.BackColor = System.Drawing.SystemColors.Control
        Me.txtTipoVia.Location = New System.Drawing.Point(85, 103)
        Me.txtTipoVia.Name = "txtTipoVia"
        Me.txtTipoVia.ReadOnly = True
        Me.txtTipoVia.Size = New System.Drawing.Size(119, 20)
        Me.txtTipoVia.TabIndex = 189
        '
        'txtNomVia
        '
        Me.txtNomVia.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomVia.Location = New System.Drawing.Point(332, 103)
        Me.txtNomVia.Name = "txtNomVia"
        Me.txtNomVia.ReadOnly = True
        Me.txtNomVia.Size = New System.Drawing.Size(120, 20)
        Me.txtNomVia.TabIndex = 190
        '
        'txtNroVia
        '
        Me.txtNroVia.BackColor = System.Drawing.SystemColors.Control
        Me.txtNroVia.Location = New System.Drawing.Point(545, 103)
        Me.txtNroVia.Name = "txtNroVia"
        Me.txtNroVia.ReadOnly = True
        Me.txtNroVia.Size = New System.Drawing.Size(98, 20)
        Me.txtNroVia.TabIndex = 191
        '
        'txtTipoZona
        '
        Me.txtTipoZona.BackColor = System.Drawing.SystemColors.Control
        Me.txtTipoZona.Location = New System.Drawing.Point(85, 129)
        Me.txtTipoZona.Name = "txtTipoZona"
        Me.txtTipoZona.ReadOnly = True
        Me.txtTipoZona.Size = New System.Drawing.Size(119, 20)
        Me.txtTipoZona.TabIndex = 192
        '
        'txtNomZona
        '
        Me.txtNomZona.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomZona.Location = New System.Drawing.Point(332, 130)
        Me.txtNomZona.Name = "txtNomZona"
        Me.txtNomZona.ReadOnly = True
        Me.txtNomZona.Size = New System.Drawing.Size(120, 20)
        Me.txtNomZona.TabIndex = 193
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.SystemColors.Control
        Me.txtReferencia.Location = New System.Drawing.Point(85, 155)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(367, 20)
        Me.txtReferencia.TabIndex = 194
        '
        'txtInterior
        '
        Me.txtInterior.BackColor = System.Drawing.SystemColors.Control
        Me.txtInterior.Location = New System.Drawing.Point(545, 129)
        Me.txtInterior.Name = "txtInterior"
        Me.txtInterior.ReadOnly = True
        Me.txtInterior.Size = New System.Drawing.Size(98, 20)
        Me.txtInterior.TabIndex = 195
        '
        'txtUbigeo
        '
        Me.txtUbigeo.BackColor = System.Drawing.SystemColors.Control
        Me.txtUbigeo.Location = New System.Drawing.Point(85, 181)
        Me.txtUbigeo.Name = "txtUbigeo"
        Me.txtUbigeo.ReadOnly = True
        Me.txtUbigeo.Size = New System.Drawing.Size(119, 20)
        Me.txtUbigeo.TabIndex = 196
        '
        'txtTelefonos
        '
        Me.txtTelefonos.BackColor = System.Drawing.SystemColors.Control
        Me.txtTelefonos.Location = New System.Drawing.Point(332, 181)
        Me.txtTelefonos.Name = "txtTelefonos"
        Me.txtTelefonos.ReadOnly = True
        Me.txtTelefonos.Size = New System.Drawing.Size(120, 20)
        Me.txtTelefonos.TabIndex = 197
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.SystemColors.Control
        Me.txtEmail.Location = New System.Drawing.Point(545, 181)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(134, 20)
        Me.txtEmail.TabIndex = 198
        '
        'txtEmpresa
        '
        Me.txtEmpresa.BackColor = System.Drawing.SystemColors.Control
        Me.txtEmpresa.Location = New System.Drawing.Point(85, 207)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(119, 20)
        Me.txtEmpresa.TabIndex = 199
        '
        'txtArea
        '
        Me.txtArea.BackColor = System.Drawing.SystemColors.Control
        Me.txtArea.Location = New System.Drawing.Point(332, 207)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(120, 20)
        Me.txtArea.TabIndex = 200
        '
        'txtClase
        '
        Me.txtClase.BackColor = System.Drawing.SystemColors.Control
        Me.txtClase.Location = New System.Drawing.Point(545, 207)
        Me.txtClase.Name = "txtClase"
        Me.txtClase.ReadOnly = True
        Me.txtClase.Size = New System.Drawing.Size(98, 20)
        Me.txtClase.TabIndex = 201
        '
        'txtCargo
        '
        Me.txtCargo.BackColor = System.Drawing.SystemColors.Control
        Me.txtCargo.Location = New System.Drawing.Point(85, 233)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.ReadOnly = True
        Me.txtCargo.Size = New System.Drawing.Size(119, 20)
        Me.txtCargo.TabIndex = 202
        '
        'chkVigente
        '
        Me.chkVigente.AutoSize = True
        Me.chkVigente.BackColor = System.Drawing.SystemColors.Control
        Me.chkVigente.Checked = True
        Me.chkVigente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVigente.Enabled = False
        Me.chkVigente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVigente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkVigente.Location = New System.Drawing.Point(200, 271)
        Me.chkVigente.Name = "chkVigente"
        Me.chkVigente.Size = New System.Drawing.Size(69, 17)
        Me.chkVigente.TabIndex = 203
        Me.chkVigente.Tag = ""
        Me.chkVigente.Text = "Vigente"
        Me.chkVigente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkVigente.UseVisualStyleBackColor = False
        '
        'chkMarcaTarjeta
        '
        Me.chkMarcaTarjeta.AutoSize = True
        Me.chkMarcaTarjeta.BackColor = System.Drawing.SystemColors.Control
        Me.chkMarcaTarjeta.Checked = True
        Me.chkMarcaTarjeta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMarcaTarjeta.Enabled = False
        Me.chkMarcaTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMarcaTarjeta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMarcaTarjeta.Location = New System.Drawing.Point(366, 271)
        Me.chkMarcaTarjeta.Name = "chkMarcaTarjeta"
        Me.chkMarcaTarjeta.Size = New System.Drawing.Size(105, 17)
        Me.chkMarcaTarjeta.TabIndex = 204
        Me.chkMarcaTarjeta.Tag = ""
        Me.chkMarcaTarjeta.Text = "Marca Tarjeta"
        Me.chkMarcaTarjeta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkMarcaTarjeta.UseVisualStyleBackColor = False
        '
        'txtFechaIngreso
        '
        Me.txtFechaIngreso.BackColor = System.Drawing.SystemColors.Control
        Me.txtFechaIngreso.Location = New System.Drawing.Point(190, 302)
        Me.txtFechaIngreso.Name = "txtFechaIngreso"
        Me.txtFechaIngreso.ReadOnly = True
        Me.txtFechaIngreso.Size = New System.Drawing.Size(125, 20)
        Me.txtFechaIngreso.TabIndex = 206
        '
        'txtFechaCese
        '
        Me.txtFechaCese.BackColor = System.Drawing.SystemColors.Control
        Me.txtFechaCese.Location = New System.Drawing.Point(521, 302)
        Me.txtFechaCese.Name = "txtFechaCese"
        Me.txtFechaCese.ReadOnly = True
        Me.txtFechaCese.Size = New System.Drawing.Size(122, 20)
        Me.txtFechaCese.TabIndex = 207
        '
        'txtFecIngContrato
        '
        Me.txtFecIngContrato.BackColor = System.Drawing.SystemColors.Control
        Me.txtFecIngContrato.Location = New System.Drawing.Point(190, 328)
        Me.txtFecIngContrato.Name = "txtFecIngContrato"
        Me.txtFecIngContrato.ReadOnly = True
        Me.txtFecIngContrato.Size = New System.Drawing.Size(125, 20)
        Me.txtFecIngContrato.TabIndex = 208
        '
        'txtFecCeseContrato
        '
        Me.txtFecCeseContrato.BackColor = System.Drawing.SystemColors.Control
        Me.txtFecCeseContrato.Location = New System.Drawing.Point(521, 328)
        Me.txtFecCeseContrato.Name = "txtFecCeseContrato"
        Me.txtFecCeseContrato.ReadOnly = True
        Me.txtFecCeseContrato.Size = New System.Drawing.Size(122, 20)
        Me.txtFecCeseContrato.TabIndex = 209
        '
        'txtFecIngEstable
        '
        Me.txtFecIngEstable.BackColor = System.Drawing.SystemColors.Control
        Me.txtFecIngEstable.Location = New System.Drawing.Point(190, 354)
        Me.txtFecIngEstable.Name = "txtFecIngEstable"
        Me.txtFecIngEstable.ReadOnly = True
        Me.txtFecIngEstable.Size = New System.Drawing.Size(125, 20)
        Me.txtFecIngEstable.TabIndex = 210
        '
        'txtFecIniPlanilla
        '
        Me.txtFecIniPlanilla.BackColor = System.Drawing.SystemColors.Control
        Me.txtFecIniPlanilla.Location = New System.Drawing.Point(521, 354)
        Me.txtFecIniPlanilla.Name = "txtFecIniPlanilla"
        Me.txtFecIniPlanilla.ReadOnly = True
        Me.txtFecIniPlanilla.Size = New System.Drawing.Size(122, 20)
        Me.txtFecIniPlanilla.TabIndex = 211
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Controls.Add(Me.txtFecCeseContrato)
        Me.UiGroupBox1.Controls.Add(Me.Label12)
        Me.UiGroupBox1.Controls.Add(Me.txtFecIniPlanilla)
        Me.UiGroupBox1.Controls.Add(Me.txtFecIngContrato)
        Me.UiGroupBox1.Controls.Add(Me.txtFecIngEstable)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaCese)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaIngreso)
        Me.UiGroupBox1.Controls.Add(Me.chkMarcaTarjeta)
        Me.UiGroupBox1.Controls.Add(Me.chkVigente)
        Me.UiGroupBox1.Controls.Add(Me.txtCargo)
        Me.UiGroupBox1.Controls.Add(Me.txtClase)
        Me.UiGroupBox1.Controls.Add(Me.txtArea)
        Me.UiGroupBox1.Controls.Add(Me.txtEmpresa)
        Me.UiGroupBox1.Controls.Add(Me.txtEmail)
        Me.UiGroupBox1.Controls.Add(Me.txtTelefonos)
        Me.UiGroupBox1.Controls.Add(Me.txtUbigeo)
        Me.UiGroupBox1.Controls.Add(Me.txtInterior)
        Me.UiGroupBox1.Controls.Add(Me.txtReferencia)
        Me.UiGroupBox1.Controls.Add(Me.txtNomZona)
        Me.UiGroupBox1.Controls.Add(Me.txtTipoZona)
        Me.UiGroupBox1.Controls.Add(Me.txtNroVia)
        Me.UiGroupBox1.Controls.Add(Me.txtNomVia)
        Me.UiGroupBox1.Controls.Add(Me.txtTipoVia)
        Me.UiGroupBox1.Controls.Add(Me.txtEstCivil)
        Me.UiGroupBox1.Controls.Add(Me.txtNombre)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Controls.Add(Me.txtCarnet)
        Me.UiGroupBox1.Controls.Add(Me.txtCodigo)
        Me.UiGroupBox1.Controls.Add(Me.Label25)
        Me.UiGroupBox1.Controls.Add(Me.Label26)
        Me.UiGroupBox1.Controls.Add(Me.Label27)
        Me.UiGroupBox1.Controls.Add(Me.Label22)
        Me.UiGroupBox1.Controls.Add(Me.Label23)
        Me.UiGroupBox1.Controls.Add(Me.Label24)
        Me.UiGroupBox1.Controls.Add(Me.Label17)
        Me.UiGroupBox1.Controls.Add(Me.Label18)
        Me.UiGroupBox1.Controls.Add(Me.Label19)
        Me.UiGroupBox1.Controls.Add(Me.Label20)
        Me.UiGroupBox1.Controls.Add(Me.Label21)
        Me.UiGroupBox1.Controls.Add(Me.Label16)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.Label13)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 37)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(685, 387)
        Me.UiGroupBox1.TabIndex = 212
        Me.UiGroupBox1.Text = "DATOS DEL USUARIO"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.rbFemenino)
        Me.UiGroupBox2.Controls.Add(Me.rbMasculino)
        Me.UiGroupBox2.Enabled = False
        Me.UiGroupBox2.Location = New System.Drawing.Point(85, 71)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(117, 28)
        Me.UiGroupBox2.TabIndex = 212
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbFemenino
        '
        Me.rbFemenino.AutoSize = True
        Me.rbFemenino.BackColor = System.Drawing.SystemColors.Window
        Me.rbFemenino.Location = New System.Drawing.Point(65, 9)
        Me.rbFemenino.Name = "rbFemenino"
        Me.rbFemenino.Size = New System.Drawing.Size(32, 17)
        Me.rbFemenino.TabIndex = 1
        Me.rbFemenino.TabStop = True
        Me.rbFemenino.Text = "F"
        Me.rbFemenino.UseVisualStyleBackColor = False
        '
        'rbMasculino
        '
        Me.rbMasculino.AutoSize = True
        Me.rbMasculino.BackColor = System.Drawing.SystemColors.Window
        Me.rbMasculino.Location = New System.Drawing.Point(20, 9)
        Me.rbMasculino.Name = "rbMasculino"
        Me.rbMasculino.Size = New System.Drawing.Size(35, 17)
        Me.rbMasculino.TabIndex = 0
        Me.rbMasculino.TabStop = True
        Me.rbMasculino.Text = "M"
        Me.rbMasculino.UseVisualStyleBackColor = False
        '
        'frmGastoViaje_InformacionUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 456)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGastoViaje_InformacionUsuario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Información de Usuario"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtCarnet As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoVia As System.Windows.Forms.TextBox
    Friend WithEvents txtEstCivil As System.Windows.Forms.TextBox
    Friend WithEvents txtNomVia As System.Windows.Forms.TextBox
    Friend WithEvents txtNroVia As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoZona As System.Windows.Forms.TextBox
    Friend WithEvents txtNomZona As System.Windows.Forms.TextBox
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtInterior As System.Windows.Forms.TextBox
    Friend WithEvents txtUbigeo As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefonos As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents txtClase As System.Windows.Forms.TextBox
    Friend WithEvents txtCargo As System.Windows.Forms.TextBox
    Friend WithEvents chkVigente As System.Windows.Forms.CheckBox
    Friend WithEvents chkMarcaTarjeta As System.Windows.Forms.CheckBox
    Friend WithEvents txtFechaCese As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaIngreso As System.Windows.Forms.TextBox
    Friend WithEvents txtFecCeseContrato As System.Windows.Forms.TextBox
    Friend WithEvents txtFecIngContrato As System.Windows.Forms.TextBox
    Friend WithEvents txtFecIniPlanilla As System.Windows.Forms.TextBox
    Friend WithEvents txtFecIngEstable As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbFemenino As System.Windows.Forms.RadioButton
    Friend WithEvents rbMasculino As System.Windows.Forms.RadioButton
End Class
