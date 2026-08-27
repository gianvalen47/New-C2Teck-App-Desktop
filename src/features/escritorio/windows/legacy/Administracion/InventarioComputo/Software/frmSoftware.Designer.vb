<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSoftware
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
        Dim cmbTipoSoftware_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSoftware))
        Me.gbDatosTipoHoraExtra = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecFinLic = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecIniLic = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.cbLicenciaAplica = New System.Windows.Forms.CheckBox()
        Me.cmbTipoSoftware = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNomAplicacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtIdSoftware = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.gbDatosTipoHoraExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosTipoHoraExtra.SuspendLayout()
        CType(Me.cmbTipoSoftware, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatosTipoHoraExtra
        '
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtFecFinLic)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtFecIniLic)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cbVigente)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cbLicenciaAplica)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cmbTipoSoftware)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label5)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtNomAplicacion)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label10)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label11)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtIdSoftware)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label12)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label13)
        Me.gbDatosTipoHoraExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosTipoHoraExtra.Location = New System.Drawing.Point(12, 12)
        Me.gbDatosTipoHoraExtra.Name = "gbDatosTipoHoraExtra"
        Me.gbDatosTipoHoraExtra.Size = New System.Drawing.Size(565, 228)
        Me.gbDatosTipoHoraExtra.TabIndex = 19
        Me.gbDatosTipoHoraExtra.Text = "Datos del Software"
        Me.gbDatosTipoHoraExtra.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFecFinLic
        '
        '
        '
        '
        Me.txtFecFinLic.DropDownCalendar.Name = ""
        Me.txtFecFinLic.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinLic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinLic.IsNullDate = True
        Me.txtFecFinLic.Location = New System.Drawing.Point(125, 167)
        Me.txtFecFinLic.Name = "txtFecFinLic"
        Me.txtFecFinLic.Size = New System.Drawing.Size(96, 20)
        Me.txtFecFinLic.TabIndex = 8
        Me.txtFecFinLic.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecIniLic
        '
        '
        '
        '
        Me.txtFecIniLic.DropDownCalendar.Name = ""
        Me.txtFecIniLic.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIniLic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecIniLic.IsNullDate = True
        Me.txtFecIniLic.Location = New System.Drawing.Point(127, 139)
        Me.txtFecIniLic.Name = "txtFecIniLic"
        Me.txtFecIniLic.Size = New System.Drawing.Size(96, 20)
        Me.txtFecIniLic.TabIndex = 7
        Me.txtFecIniLic.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigente.Location = New System.Drawing.Point(72, 196)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(69, 17)
        Me.cbVigente.TabIndex = 9
        Me.cbVigente.Text = "Vigente"
        Me.cbVigente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigente.UseVisualStyleBackColor = True
        '
        'cbLicenciaAplica
        '
        Me.cbLicenciaAplica.AutoSize = True
        Me.cbLicenciaAplica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbLicenciaAplica.Location = New System.Drawing.Point(28, 114)
        Me.cbLicenciaAplica.Name = "cbLicenciaAplica"
        Me.cbLicenciaAplica.Size = New System.Drawing.Size(113, 17)
        Me.cbLicenciaAplica.TabIndex = 5
        Me.cbLicenciaAplica.Text = "Licencia Aplica"
        Me.cbLicenciaAplica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbLicenciaAplica.UseVisualStyleBackColor = True
        '
        'cmbTipoSoftware
        '
        Me.cmbTipoSoftware.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoSoftware_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoSoftware_DesignTimeLayout.LayoutString")
        Me.cmbTipoSoftware.DesignTimeLayout = cmbTipoSoftware_DesignTimeLayout
        Me.cmbTipoSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoSoftware.Location = New System.Drawing.Point(127, 56)
        Me.cmbTipoSoftware.Name = "cmbTipoSoftware"
        Me.cmbTipoSoftware.SelectedIndex = -1
        Me.cmbTipoSoftware.SelectedItem = Nothing
        Me.cmbTipoSoftware.Size = New System.Drawing.Size(159, 20)
        Me.cmbTipoSoftware.TabIndex = 3
        Me.cmbTipoSoftware.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(39, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 319
        Me.Label5.Text = "Fec. Fin Lic."
        '
        'txtNomAplicacion
        '
        Me.txtNomAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomAplicacion.Location = New System.Drawing.Point(126, 85)
        Me.txtNomAplicacion.Name = "txtNomAplicacion"
        Me.txtNomAplicacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNomAplicacion.Size = New System.Drawing.Size(417, 20)
        Me.txtNomAplicacion.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(69, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 318
        Me.Label10.Text = "Nombre"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(44, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 317
        Me.Label11.Text = "Fec. Ini. Lic"
        '
        'txtIdSoftware
        '
        Me.txtIdSoftware.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdSoftware.ForeColor = System.Drawing.Color.Navy
        Me.txtIdSoftware.Location = New System.Drawing.Point(127, 30)
        Me.txtIdSoftware.MaxLength = 5
        Me.txtIdSoftware.Name = "txtIdSoftware"
        Me.txtIdSoftware.ReadOnly = True
        Me.txtIdSoftware.Size = New System.Drawing.Size(63, 20)
        Me.txtIdSoftware.TabIndex = 313
        Me.txtIdSoftware.TabStop = False
        Me.txtIdSoftware.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(73, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 316
        Me.Label12.Text = "Código"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(34, 60)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 13)
        Me.Label13.TabIndex = 315
        Me.Label13.Text = "Tipo Software"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(299, 257)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 21
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
        Me.btnGuardar.Location = New System.Drawing.Point(215, 257)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmSoftware
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(586, 295)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatosTipoHoraExtra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(594, 329)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(594, 329)
        Me.Name = "frmSoftware"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Software"
        CType(Me.gbDatosTipoHoraExtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosTipoHoraExtra.ResumeLayout(False)
        Me.gbDatosTipoHoraExtra.PerformLayout()
        CType(Me.cmbTipoSoftware, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbDatosTipoHoraExtra As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecFinLic As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecIniLic As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbVigente As CheckBox
    Friend WithEvents cbLicenciaAplica As CheckBox
    Friend WithEvents cmbTipoSoftware As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNomAplicacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtIdSoftware As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
End Class
