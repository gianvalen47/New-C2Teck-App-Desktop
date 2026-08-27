<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarContacto
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
        Dim cmbSexo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregarContacto))
        Dim cmbIdTipoContacto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.gbVigente = New System.Windows.Forms.GroupBox
        Me.cbVigente = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.txtTelMovil = New System.Windows.Forms.TextBox
        Me.txtTelefonos = New System.Windows.Forms.TextBox
        Me.txtFecNac = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbSexo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtApellidos = New System.Windows.Forms.TextBox
        Me.cmbTitulo = New System.Windows.Forms.ComboBox
        Me.cmbIdTipoContacto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNombres = New System.Windows.Forms.TextBox
        Me.txtIdContacto = New System.Windows.Forms.TextBox
        Me.gbSubDatos1 = New System.Windows.Forms.GroupBox
        Me.cbEmailProm = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label15 = New System.Windows.Forms.Label
        Me.gbDatos.SuspendLayout()
        Me.gbVigente.SuspendLayout()
        CType(Me.cmbSexo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdTipoContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSubDatos1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.gbVigente)
        Me.gbDatos.Controls.Add(Me.Label14)
        Me.gbDatos.Controls.Add(Me.Label13)
        Me.gbDatos.Controls.Add(Me.Label12)
        Me.gbDatos.Controls.Add(Me.Label11)
        Me.gbDatos.Controls.Add(Me.txtEmail)
        Me.gbDatos.Controls.Add(Me.txtDireccion)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.txtFax)
        Me.gbDatos.Controls.Add(Me.txtTelMovil)
        Me.gbDatos.Controls.Add(Me.txtTelefonos)
        Me.gbDatos.Controls.Add(Me.txtFecNac)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.cmbSexo)
        Me.gbDatos.Controls.Add(Me.txtApellidos)
        Me.gbDatos.Controls.Add(Me.cmbTitulo)
        Me.gbDatos.Controls.Add(Me.cmbIdTipoContacto)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.txtNombres)
        Me.gbDatos.Controls.Add(Me.txtIdContacto)
        Me.gbDatos.Controls.Add(Me.gbSubDatos1)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Location = New System.Drawing.Point(4, 3)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(522, 155)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Contacto"
        '
        'gbVigente
        '
        Me.gbVigente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbVigente.Controls.Add(Me.cbVigente)
        Me.gbVigente.Location = New System.Drawing.Point(365, 109)
        Me.gbVigente.Name = "gbVigente"
        Me.gbVigente.Size = New System.Drawing.Size(146, 36)
        Me.gbVigente.TabIndex = 13
        Me.gbVigente.TabStop = False
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.Location = New System.Drawing.Point(46, 13)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(62, 17)
        Me.cbVigente.TabIndex = 0
        Me.cbVigente.Text = "Vigente"
        Me.cbVigente.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(53, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 13)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(53, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(213, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 13)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 133)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(66, 130)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(124, 20)
        Me.txtEmail.TabIndex = 10
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(66, 107)
        Me.txtDireccion.MaxLength = 50
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(280, 20)
        Me.txtDireccion.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(203, 133)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Fax"
        '
        'txtFax
        '
        Me.txtFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFax.Location = New System.Drawing.Point(233, 130)
        Me.txtFax.MaxLength = 50
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(113, 20)
        Me.txtFax.TabIndex = 11
        '
        'txtTelMovil
        '
        Me.txtTelMovil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelMovil.Location = New System.Drawing.Point(233, 84)
        Me.txtTelMovil.MaxLength = 50
        Me.txtTelMovil.Name = "txtTelMovil"
        Me.txtTelMovil.Size = New System.Drawing.Size(113, 20)
        Me.txtTelMovil.TabIndex = 8
        '
        'txtTelefonos
        '
        Me.txtTelefonos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefonos.Location = New System.Drawing.Point(66, 84)
        Me.txtTelefonos.MaxLength = 50
        Me.txtTelefonos.Name = "txtTelefonos"
        Me.txtTelefonos.Size = New System.Drawing.Size(124, 20)
        Me.txtTelefonos.TabIndex = 7
        '
        'txtFecNac
        '
        Me.txtFecNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecNac.Location = New System.Drawing.Point(415, 38)
        Me.txtFecNac.Name = "txtFecNac"
        Me.txtFecNac.Size = New System.Drawing.Size(101, 20)
        Me.txtFecNac.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(357, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Sexo"
        '
        'cmbSexo
        '
        Me.cmbSexo.BackColor = System.Drawing.SystemColors.Control
        Me.cmbSexo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSexo_DesignTimeLayout.LayoutString = resources.GetString("cmbSexo_DesignTimeLayout.LayoutString")
        Me.cmbSexo.DesignTimeLayout = cmbSexo_DesignTimeLayout
        Me.cmbSexo.Location = New System.Drawing.Point(415, 15)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.ReadOnly = True
        Me.cmbSexo.SelectedIndex = -1
        Me.cmbSexo.SelectedItem = Nothing
        Me.cmbSexo.Size = New System.Drawing.Size(101, 20)
        Me.cmbSexo.TabIndex = 2
        Me.cmbSexo.TabStop = False
        Me.cmbSexo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtApellidos
        '
        Me.txtApellidos.Location = New System.Drawing.Point(66, 61)
        Me.txtApellidos.MaxLength = 50
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.Size = New System.Drawing.Size(280, 20)
        Me.txtApellidos.TabIndex = 6
        '
        'cmbTitulo
        '
        Me.cmbTitulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTitulo.FormattingEnabled = True
        Me.cmbTitulo.Items.AddRange(New Object() {"Sr.", "Sra.", "Srta.", "Ms.", "Mr.", "Ing."})
        Me.cmbTitulo.Location = New System.Drawing.Point(66, 37)
        Me.cmbTitulo.Name = "cmbTitulo"
        Me.cmbTitulo.Size = New System.Drawing.Size(44, 21)
        Me.cmbTitulo.TabIndex = 3
        '
        'cmbIdTipoContacto
        '
        Me.cmbIdTipoContacto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdTipoContacto_DesignTimeLayout.LayoutString = resources.GetString("cmbIdTipoContacto_DesignTimeLayout.LayoutString")
        Me.cmbIdTipoContacto.DesignTimeLayout = cmbIdTipoContacto_DesignTimeLayout
        Me.cmbIdTipoContacto.Location = New System.Drawing.Point(226, 15)
        Me.cmbIdTipoContacto.Name = "cmbIdTipoContacto"
        Me.cmbIdTipoContacto.SelectedIndex = -1
        Me.cmbIdTipoContacto.SelectedItem = Nothing
        Me.cmbIdTipoContacto.Size = New System.Drawing.Size(120, 20)
        Me.cmbIdTipoContacto.TabIndex = 1
        Me.cmbIdTipoContacto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(186, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Tipo"
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(116, 38)
        Me.txtNombres.MaxLength = 50
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(230, 20)
        Me.txtNombres.TabIndex = 4
        '
        'txtIdContacto
        '
        Me.txtIdContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdContacto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdContacto.Location = New System.Drawing.Point(66, 15)
        Me.txtIdContacto.MaxLength = 18
        Me.txtIdContacto.Name = "txtIdContacto"
        Me.txtIdContacto.ReadOnly = True
        Me.txtIdContacto.Size = New System.Drawing.Size(106, 20)
        Me.txtIdContacto.TabIndex = 0
        Me.txtIdContacto.TabStop = False
        '
        'gbSubDatos1
        '
        Me.gbSubDatos1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbSubDatos1.Controls.Add(Me.cbEmailProm)
        Me.gbSubDatos1.Location = New System.Drawing.Point(365, 67)
        Me.gbSubDatos1.Name = "gbSubDatos1"
        Me.gbSubDatos1.Size = New System.Drawing.Size(146, 36)
        Me.gbSubDatos1.TabIndex = 12
        Me.gbSubDatos1.TabStop = False
        '
        'cbEmailProm
        '
        Me.cbEmailProm.AutoSize = True
        Me.cbEmailProm.Location = New System.Drawing.Point(16, 13)
        Me.cbEmailProm.Name = "cbEmailProm"
        Me.cbEmailProm.Size = New System.Drawing.Size(116, 17)
        Me.cbEmailProm.TabIndex = 0
        Me.cbEmailProm.Text = "Recibir información"
        Me.cbEmailProm.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(352, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Fec. Nac."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(194, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Celular"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Dirección"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Teléfono"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Apellidos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Nombres"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Código"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(363, 160)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(442, 160)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(10, 166)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(110, 13)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "* Campos Obligatorios"
        '
        'frmAgregarContacto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 187)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregarContacto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar Contacto"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.gbVigente.ResumeLayout(False)
        Me.gbVigente.PerformLayout()
        CType(Me.cmbSexo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdTipoContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSubDatos1.ResumeLayout(False)
        Me.gbSubDatos1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbIdTipoContacto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdContacto As System.Windows.Forms.TextBox
    Friend WithEvents gbSubDatos1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbEmailProm As System.Windows.Forms.CheckBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtApellidos As System.Windows.Forms.TextBox
    Friend WithEvents cmbTitulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbSexo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtFecNac As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTelMovil As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTelefonos As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gbVigente As System.Windows.Forms.GroupBox
    Friend WithEvents cbVigente As System.Windows.Forms.CheckBox

End Class
