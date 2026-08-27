<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanTelefonia
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
        Dim cmbTipoServicio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanTelefonia))
        Dim cmbOperador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbDatosTipoHoraExtra = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtSms = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMebInternet = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMinTelefono = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMinRepPrivada = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTipoServicio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbOperador = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbActivo = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdPlan = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDesPlan = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.gbDatosTipoHoraExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosTipoHoraExtra.SuspendLayout()
        CType(Me.cmbTipoServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOperador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(238, 303)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 13
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
        Me.btnGuardar.Location = New System.Drawing.Point(154, 303)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbDatosTipoHoraExtra
        '
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label7)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtSms)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtMebInternet)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtMinTelefono)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtMinRepPrivada)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label5)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cmbTipoServicio)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label6)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label8)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label3)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cmbOperador)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cbActivo)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label2)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtIdPlan)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label1)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label4)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label9)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtDesPlan)
        Me.gbDatosTipoHoraExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosTipoHoraExtra.Location = New System.Drawing.Point(12, 12)
        Me.gbDatosTipoHoraExtra.Name = "gbDatosTipoHoraExtra"
        Me.gbDatosTipoHoraExtra.Size = New System.Drawing.Size(444, 278)
        Me.gbDatosTipoHoraExtra.TabIndex = 11
        Me.gbDatosTipoHoraExtra.Text = "Datos de Plan"
        Me.gbDatosTipoHoraExtra.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtSms
        '
        Me.txtSms.Location = New System.Drawing.Point(99, 217)
        Me.txtSms.MaxLength = 12
        Me.txtSms.Name = "txtSms"
        Me.txtSms.Size = New System.Drawing.Size(93, 20)
        Me.txtSms.TabIndex = 8
        Me.txtSms.Text = "0"
        Me.txtSms.Value = 0
        Me.txtSms.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtSms.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMebInternet
        '
        Me.txtMebInternet.Location = New System.Drawing.Point(99, 189)
        Me.txtMebInternet.MaxLength = 12
        Me.txtMebInternet.Name = "txtMebInternet"
        Me.txtMebInternet.Size = New System.Drawing.Size(93, 20)
        Me.txtMebInternet.TabIndex = 7
        Me.txtMebInternet.Text = "0"
        Me.txtMebInternet.Value = 0
        Me.txtMebInternet.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtMebInternet.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMinTelefono
        '
        Me.txtMinTelefono.Location = New System.Drawing.Point(100, 161)
        Me.txtMinTelefono.MaxLength = 12
        Me.txtMinTelefono.Name = "txtMinTelefono"
        Me.txtMinTelefono.Size = New System.Drawing.Size(93, 20)
        Me.txtMinTelefono.TabIndex = 6
        Me.txtMinTelefono.Text = "0"
        Me.txtMinTelefono.Value = 0
        Me.txtMinTelefono.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtMinTelefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMinRepPrivada
        '
        Me.txtMinRepPrivada.Location = New System.Drawing.Point(120, 133)
        Me.txtMinRepPrivada.MaxLength = 12
        Me.txtMinRepPrivada.Name = "txtMinRepPrivada"
        Me.txtMinRepPrivada.Size = New System.Drawing.Size(93, 20)
        Me.txtMinRepPrivada.TabIndex = 5
        Me.txtMinRepPrivada.Text = "0"
        Me.txtMinRepPrivada.Value = 0
        Me.txtMinRepPrivada.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtMinRepPrivada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 273
        Me.Label5.Text = "Min Red Privada"
        '
        'cmbTipoServicio
        '
        Me.cmbTipoServicio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoServicio_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoServicio_DesignTimeLayout.LayoutString")
        Me.cmbTipoServicio.DesignTimeLayout = cmbTipoServicio_DesignTimeLayout
        Me.cmbTipoServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoServicio.Location = New System.Drawing.Point(99, 106)
        Me.cmbTipoServicio.Name = "cmbTipoServicio"
        Me.cmbTipoServicio.SelectedIndex = -1
        Me.cmbTipoServicio.SelectedItem = Nothing
        Me.cmbTipoServicio.Size = New System.Drawing.Size(224, 20)
        Me.cmbTipoServicio.TabIndex = 4
        Me.cmbTipoServicio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 271
        Me.Label6.Text = "Tipo Servicio"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(60, 221)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 267
        Me.Label8.Text = "SMS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "Meb Internet"
        '
        'cmbOperador
        '
        Me.cmbOperador.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOperador_DesignTimeLayout.LayoutString = resources.GetString("cmbOperador_DesignTimeLayout.LayoutString")
        Me.cmbOperador.DesignTimeLayout = cmbOperador_DesignTimeLayout
        Me.cmbOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperador.Location = New System.Drawing.Point(99, 78)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.SelectedIndex = -1
        Me.cmbOperador.SelectedItem = Nothing
        Me.cmbOperador.Size = New System.Drawing.Size(224, 20)
        Me.cmbOperador.TabIndex = 3
        Me.cmbOperador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.Location = New System.Drawing.Point(52, 246)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(62, 17)
        Me.cbActivo.TabIndex = 6
        Me.cbActivo.TabStop = False
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 258
        Me.Label2.Text = "Operador"
        '
        'txtIdPlan
        '
        Me.txtIdPlan.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdPlan.ForeColor = System.Drawing.Color.Navy
        Me.txtIdPlan.Location = New System.Drawing.Point(99, 24)
        Me.txtIdPlan.MaxLength = 5
        Me.txtIdPlan.Name = "txtIdPlan"
        Me.txtIdPlan.ReadOnly = True
        Me.txtIdPlan.Size = New System.Drawing.Size(63, 20)
        Me.txtIdPlan.TabIndex = 1
        Me.txtIdPlan.TabStop = False
        Me.txtIdPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 254
        Me.Label4.Text = "Min Telefono"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "Descripción"
        '
        'txtDesPlan
        '
        Me.txtDesPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesPlan.Location = New System.Drawing.Point(99, 51)
        Me.txtDesPlan.Name = "txtDesPlan"
        Me.txtDesPlan.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesPlan.Size = New System.Drawing.Size(331, 20)
        Me.txtDesPlan.TabIndex = 2
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(219, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 274
        Me.Label7.Text = "( 0 = ilimitado )"
        '
        'frmPlanTelefonia
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(464, 336)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatosTipoHoraExtra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanTelefonia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plan"
        CType(Me.gbDatosTipoHoraExtra,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbDatosTipoHoraExtra.ResumeLayout(false)
        Me.gbDatosTipoHoraExtra.PerformLayout
        CType(Me.cmbTipoServicio,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbOperador,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ofEstiloForm,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbDatosTipoHoraExtra As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoServicio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbOperador As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdPlan As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDesPlan As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtSms As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMebInternet As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMinTelefono As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMinRepPrivada As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As Label
End Class
