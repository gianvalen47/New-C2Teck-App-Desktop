<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaRemision_Transportista
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaRemision_Transportista))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtLicencia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtConIns = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVehiculo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtChofer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblChofer = New System.Windows.Forms.Label()
        Me.lblLicencia = New System.Windows.Forms.Label()
        Me.lbloplaca = New System.Windows.Forms.Label()
        Me.lblonumdoc = New System.Windows.Forms.Label()
        Me.lblotipodoc = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.lbloruc = New System.Windows.Forms.Label()
        Me.lblodireccion = New System.Windows.Forms.Label()
        Me.lbloempresa = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbTransportista = New System.Windows.Forms.CheckBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtLicencia
        '
        Me.txtLicencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLicencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLicencia.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtLicencia.Location = New System.Drawing.Point(120, 78)
        Me.txtLicencia.MaxLength = 20
        Me.txtLicencia.Name = "txtLicencia"
        Me.txtLicencia.Size = New System.Drawing.Size(192, 20)
        Me.txtLicencia.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Lic. Conducir :"
        '
        'txtConIns
        '
        Me.txtConIns.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConIns.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConIns.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtConIns.Location = New System.Drawing.Point(90, 103)
        Me.txtConIns.MaxLength = 20
        Me.txtConIns.Name = "txtConIns"
        Me.txtConIns.Size = New System.Drawing.Size(200, 20)
        Me.txtConIns.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Const. Inc. :"
        '
        'txtVehiculo
        '
        Me.txtVehiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehiculo.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtVehiculo.Location = New System.Drawing.Point(394, 76)
        Me.txtVehiculo.MaxLength = 20
        Me.txtVehiculo.Name = "txtVehiculo"
        Me.txtVehiculo.Size = New System.Drawing.Size(196, 20)
        Me.txtVehiculo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(293, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tipo Vehículo :"
        '
        'txtPlaca
        '
        Me.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlaca.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPlaca.Location = New System.Drawing.Point(394, 78)
        Me.txtPlaca.MaxLength = 15
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(196, 20)
        Me.txtPlaca.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(335, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Placa :"
        '
        'txtRuc
        '
        Me.txtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuc.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtRuc.Location = New System.Drawing.Point(90, 76)
        Me.txtRuc.MaxLength = 11
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(200, 20)
        Me.txtRuc.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "RUC/DNI :"
        '
        'txtDireccion
        '
        Me.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtDireccion.Location = New System.Drawing.Point(90, 50)
        Me.txtDireccion.MaxLength = 30
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(500, 20)
        Me.txtDireccion.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Dirección :"
        '
        'txtChofer
        '
        Me.txtChofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChofer.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtChofer.Location = New System.Drawing.Point(90, 26)
        Me.txtChofer.MaxLength = 30
        Me.txtChofer.Name = "txtChofer"
        Me.txtChofer.Size = New System.Drawing.Size(500, 20)
        Me.txtChofer.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Chofer :"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresa.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtEmpresa.Location = New System.Drawing.Point(90, 24)
        Me.txtEmpresa.MaxLength = 30
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(482, 20)
        Me.txtEmpresa.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Empresa :"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(497, 308)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 25)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(397, 308)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(85, 25)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.GroupBox1)
        Me.UiGroupBox1.Controls.Add(Me.gbDatos)
        Me.UiGroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(623, 292)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = " [  Datos del Transportista  ] "
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblChofer)
        Me.GroupBox1.Controls.Add(Me.lblLicencia)
        Me.GroupBox1.Controls.Add(Me.lbloplaca)
        Me.GroupBox1.Controls.Add(Me.lblonumdoc)
        Me.GroupBox1.Controls.Add(Me.lblotipodoc)
        Me.GroupBox1.Controls.Add(Me.cmbTipoDoc)
        Me.GroupBox1.Controls.Add(Me.txtNumDoc)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtChofer)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtLicencia)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtPlaca)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 166)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(604, 113)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Chofer"
        '
        'lblChofer
        '
        Me.lblChofer.AutoSize = True
        Me.lblChofer.ForeColor = System.Drawing.Color.Red
        Me.lblChofer.Location = New System.Drawing.Point(76, 29)
        Me.lblChofer.Name = "lblChofer"
        Me.lblChofer.Size = New System.Drawing.Size(12, 13)
        Me.lblChofer.TabIndex = 29
        Me.lblChofer.Text = "*"
        '
        'lblLicencia
        '
        Me.lblLicencia.AutoSize = True
        Me.lblLicencia.ForeColor = System.Drawing.Color.Red
        Me.lblLicencia.Location = New System.Drawing.Point(107, 81)
        Me.lblLicencia.Name = "lblLicencia"
        Me.lblLicencia.Size = New System.Drawing.Size(12, 13)
        Me.lblLicencia.TabIndex = 28
        Me.lblLicencia.Text = "*"
        '
        'lbloplaca
        '
        Me.lbloplaca.AutoSize = True
        Me.lbloplaca.ForeColor = System.Drawing.Color.Red
        Me.lbloplaca.Location = New System.Drawing.Point(381, 81)
        Me.lbloplaca.Name = "lbloplaca"
        Me.lbloplaca.Size = New System.Drawing.Size(12, 13)
        Me.lbloplaca.TabIndex = 24
        Me.lbloplaca.Text = "*"
        '
        'lblonumdoc
        '
        Me.lblonumdoc.AutoSize = True
        Me.lblonumdoc.ForeColor = System.Drawing.Color.Red
        Me.lblonumdoc.Location = New System.Drawing.Point(447, 56)
        Me.lblonumdoc.Name = "lblonumdoc"
        Me.lblonumdoc.Size = New System.Drawing.Size(12, 13)
        Me.lblonumdoc.TabIndex = 27
        Me.lblonumdoc.Text = "*"
        '
        'lblotipodoc
        '
        Me.lblotipodoc.AutoSize = True
        Me.lblotipodoc.ForeColor = System.Drawing.Color.Red
        Me.lblotipodoc.Location = New System.Drawing.Point(106, 53)
        Me.lblotipodoc.Name = "lblotipodoc"
        Me.lblotipodoc.Size = New System.Drawing.Size(12, 13)
        Me.lblotipodoc.TabIndex = 26
        Me.lblotipodoc.Text = "*"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Location = New System.Drawing.Point(120, 52)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(230, 20)
        Me.cmbTipoDoc.TabIndex = 7
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtNumDoc.Location = New System.Drawing.Point(459, 53)
        Me.txtNumDoc.MaxLength = 15
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(131, 20)
        Me.txtNumDoc.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(360, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "N° Documento :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Tipo Documento :"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.btnBuscarProveedor)
        Me.gbDatos.Controls.Add(Me.lbloruc)
        Me.gbDatos.Controls.Add(Me.lblodireccion)
        Me.gbDatos.Controls.Add(Me.txtEmpresa)
        Me.gbDatos.Controls.Add(Me.Label12)
        Me.gbDatos.Controls.Add(Me.txtDireccion)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.txtRuc)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.lbloempresa)
        Me.gbDatos.Controls.Add(Me.txtConIns)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.txtVehiculo)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Location = New System.Drawing.Point(13, 19)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(604, 140)
        Me.gbDatos.TabIndex = 21
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos de la Empresa"
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(572, 23)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 28
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'lbloruc
        '
        Me.lbloruc.AutoSize = True
        Me.lbloruc.ForeColor = System.Drawing.Color.Red
        Me.lbloruc.Location = New System.Drawing.Point(76, 79)
        Me.lbloruc.Name = "lbloruc"
        Me.lbloruc.Size = New System.Drawing.Size(12, 13)
        Me.lbloruc.TabIndex = 23
        Me.lbloruc.Text = "*"
        '
        'lblodireccion
        '
        Me.lblodireccion.AutoSize = True
        Me.lblodireccion.ForeColor = System.Drawing.Color.Red
        Me.lblodireccion.Location = New System.Drawing.Point(76, 53)
        Me.lblodireccion.Name = "lblodireccion"
        Me.lblodireccion.Size = New System.Drawing.Size(12, 13)
        Me.lblodireccion.TabIndex = 21
        Me.lblodireccion.Text = "*"
        '
        'lbloempresa
        '
        Me.lbloempresa.AutoSize = True
        Me.lbloempresa.ForeColor = System.Drawing.Color.Red
        Me.lbloempresa.Location = New System.Drawing.Point(76, 25)
        Me.lbloempresa.Name = "lbloempresa"
        Me.lbloempresa.Size = New System.Drawing.Size(12, 13)
        Me.lbloempresa.TabIndex = 20
        Me.lbloempresa.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(29, 314)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "* Campos Obligatorios"
        '
        'cbTransportista
        '
        Me.cbTransportista.AutoSize = True
        Me.cbTransportista.Enabled = False
        Me.cbTransportista.Location = New System.Drawing.Point(175, 313)
        Me.cbTransportista.Name = "cbTransportista"
        Me.cbTransportista.Size = New System.Drawing.Size(186, 17)
        Me.cbTransportista.TabIndex = 22
        Me.cbTransportista.Text = "Tranportista Predeterminado"
        Me.cbTransportista.UseVisualStyleBackColor = True
        '
        'frmGuiaRemision_Transportista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 345)
        Me.Controls.Add(Me.cbTransportista)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(655, 379)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(655, 379)
        Me.Name = "frmGuiaRemision_Transportista"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guia Transportista"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
  Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtChofer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLicencia As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtConIns As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVehiculo As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbloempresa As System.Windows.Forms.Label
    Friend WithEvents cbTransportista As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtNumDoc As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents gbDatos As GroupBox
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblonumdoc As Label
    Friend WithEvents lblotipodoc As Label
    Friend WithEvents lbloruc As Label
    Friend WithEvents lblodireccion As Label
    Friend WithEvents lbloplaca As Label
    Friend WithEvents lblChofer As Label
    Friend WithEvents lblLicencia As Label
    Friend WithEvents btnBuscarProveedor As Button
End Class
