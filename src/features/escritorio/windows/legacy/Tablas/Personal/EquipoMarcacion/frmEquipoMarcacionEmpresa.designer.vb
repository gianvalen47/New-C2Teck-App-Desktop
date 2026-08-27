<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEquipoMarcacionEmpresa
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
        Dim cmbHorario_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEquipoMarcacionEmpresa))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosEquipo = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtModelo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMarca = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cbActivo = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPuerto = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDireccionIp = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtIdEquipo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbHorario = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDesEquipo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBuscarLector = New System.Windows.Forms.Button()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosEquipo.SuspendLayout()
        CType(Me.cmbHorario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosEquipo
        '
        Me.gbDatosEquipo.Controls.Add(Me.btnBuscarLector)
        Me.gbDatosEquipo.Controls.Add(Me.Label6)
        Me.gbDatosEquipo.Controls.Add(Me.txtModelo)
        Me.gbDatosEquipo.Controls.Add(Me.Label5)
        Me.gbDatosEquipo.Controls.Add(Me.txtMarca)
        Me.gbDatosEquipo.Controls.Add(Me.cbActivo)
        Me.gbDatosEquipo.Controls.Add(Me.Label3)
        Me.gbDatosEquipo.Controls.Add(Me.txtPuerto)
        Me.gbDatosEquipo.Controls.Add(Me.Label2)
        Me.gbDatosEquipo.Controls.Add(Me.txtDireccionIp)
        Me.gbDatosEquipo.Controls.Add(Me.txtIdEquipo)
        Me.gbDatosEquipo.Controls.Add(Me.Label1)
        Me.gbDatosEquipo.Controls.Add(Me.Label4)
        Me.gbDatosEquipo.Controls.Add(Me.cmbHorario)
        Me.gbDatosEquipo.Controls.Add(Me.Label9)
        Me.gbDatosEquipo.Controls.Add(Me.txtDesEquipo)
        Me.gbDatosEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosEquipo.Location = New System.Drawing.Point(8, 4)
        Me.gbDatosEquipo.Name = "gbDatosEquipo"
        Me.gbDatosEquipo.Size = New System.Drawing.Size(417, 169)
        Me.gbDatosEquipo.TabIndex = 0
        Me.gbDatosEquipo.Text = "Datos de Equipo de Marcación"
        Me.gbDatosEquipo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(235, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 264
        Me.Label6.Text = "Modelo"
        '
        'txtModelo
        '
        Me.txtModelo.BackColor = System.Drawing.SystemColors.Control
        Me.txtModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelo.Location = New System.Drawing.Point(289, 109)
        Me.txtModelo.MaxLength = 50
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtModelo.Size = New System.Drawing.Size(116, 20)
        Me.txtModelo.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(41, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 262
        Me.Label5.Text = "Marca"
        '
        'txtMarca
        '
        Me.txtMarca.BackColor = System.Drawing.SystemColors.Control
        Me.txtMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.Location = New System.Drawing.Point(89, 109)
        Me.txtMarca.MaxLength = 50
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMarca.Size = New System.Drawing.Size(125, 20)
        Me.txtMarca.TabIndex = 7
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.Enabled = False
        Me.cbActivo.Location = New System.Drawing.Point(342, 27)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(62, 17)
        Me.cbActivo.TabIndex = 6
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(269, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Puerto"
        '
        'txtPuerto
        '
        Me.txtPuerto.BackColor = System.Drawing.SystemColors.Control
        Me.txtPuerto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuerto.Location = New System.Drawing.Point(319, 80)
        Me.txtPuerto.MaxLength = 20
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.ReadOnly = True
        Me.txtPuerto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPuerto.Size = New System.Drawing.Size(86, 20)
        Me.txtPuerto.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 258
        Me.Label2.Text = "Dirección Ip"
        '
        'txtDireccionIp
        '
        Me.txtDireccionIp.BackColor = System.Drawing.SystemColors.Control
        Me.txtDireccionIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccionIp.Location = New System.Drawing.Point(89, 80)
        Me.txtDireccionIp.MaxLength = 20
        Me.txtDireccionIp.Name = "txtDireccionIp"
        Me.txtDireccionIp.ReadOnly = True
        Me.txtDireccionIp.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDireccionIp.Size = New System.Drawing.Size(143, 20)
        Me.txtDireccionIp.TabIndex = 3
        '
        'txtIdEquipo
        '
        Me.txtIdEquipo.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdEquipo.ForeColor = System.Drawing.Color.Navy
        Me.txtIdEquipo.Location = New System.Drawing.Point(89, 22)
        Me.txtIdEquipo.MaxLength = 5
        Me.txtIdEquipo.Name = "txtIdEquipo"
        Me.txtIdEquipo.ReadOnly = True
        Me.txtIdEquipo.Size = New System.Drawing.Size(63, 20)
        Me.txtIdEquipo.TabIndex = 1
        Me.txtIdEquipo.TabStop = False
        Me.txtIdEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 254
        Me.Label4.Text = "Horario"
        '
        'cmbHorario
        '
        Me.cmbHorario.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbHorario_DesignTimeLayout.LayoutString = resources.GetString("cmbHorario_DesignTimeLayout.LayoutString")
        Me.cmbHorario.DesignTimeLayout = cmbHorario_DesignTimeLayout
        Me.cmbHorario.Location = New System.Drawing.Point(89, 139)
        Me.cmbHorario.Name = "cmbHorario"
        Me.cmbHorario.SelectedIndex = -1
        Me.cmbHorario.SelectedItem = Nothing
        Me.cmbHorario.Size = New System.Drawing.Size(220, 20)
        Me.cmbHorario.TabIndex = 5
        Me.cmbHorario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "Descripción"
        '
        'txtDesEquipo
        '
        Me.txtDesEquipo.BackColor = System.Drawing.SystemColors.Control
        Me.txtDesEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesEquipo.Location = New System.Drawing.Point(89, 51)
        Me.txtDesEquipo.Name = "txtDesEquipo"
        Me.txtDesEquipo.ReadOnly = True
        Me.txtDesEquipo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesEquipo.Size = New System.Drawing.Size(316, 20)
        Me.txtDesEquipo.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(219, 179)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(135, 179)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnBuscarLector
        '
        Me.btnBuscarLector.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarLector.Location = New System.Drawing.Point(154, 20)
        Me.btnBuscarLector.Name = "btnBuscarLector"
        Me.btnBuscarLector.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarLector.TabIndex = 265
        Me.btnBuscarLector.UseVisualStyleBackColor = True
        '
        'frmEquipoMarcacionEmpresa
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(458, 218)
        Me.Controls.Add(Me.gbDatosEquipo)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEquipoMarcacionEmpresa"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Equipo de Marcación"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosEquipo.ResumeLayout(False)
        Me.gbDatosEquipo.PerformLayout()
        CType(Me.cmbHorario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosEquipo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDireccionIp As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtIdEquipo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbHorario As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDesEquipo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPuerto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMarca As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtModelo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnBuscarLector As Button
End Class
