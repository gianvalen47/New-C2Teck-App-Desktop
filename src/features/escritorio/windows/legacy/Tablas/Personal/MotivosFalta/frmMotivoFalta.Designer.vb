<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotivoFalta
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
        Dim cmbMotivo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMotivoFalta))
        Dim cmbValorTiempo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosAsignacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMotivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbActivo = New System.Windows.Forms.CheckBox()
        Me.cbPermisoArea = New System.Windows.Forms.CheckBox()
        Me.cbAplicaDscto = New System.Windows.Forms.CheckBox()
        Me.cbAplicaAsistencia = New System.Windows.Forms.CheckBox()
        Me.txtCodMotivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbValorTiempo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDesMotivo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosAsignacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosAsignacion.SuspendLayout()
        CType(Me.cmbMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbValorTiempo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosAsignacion
        '
        Me.gbDatosAsignacion.Controls.Add(Me.Label2)
        Me.gbDatosAsignacion.Controls.Add(Me.cmbMotivo)
        Me.gbDatosAsignacion.Controls.Add(Me.cbActivo)
        Me.gbDatosAsignacion.Controls.Add(Me.cbPermisoArea)
        Me.gbDatosAsignacion.Controls.Add(Me.cbAplicaDscto)
        Me.gbDatosAsignacion.Controls.Add(Me.cbAplicaAsistencia)
        Me.gbDatosAsignacion.Controls.Add(Me.txtCodMotivo)
        Me.gbDatosAsignacion.Controls.Add(Me.Label1)
        Me.gbDatosAsignacion.Controls.Add(Me.Label4)
        Me.gbDatosAsignacion.Controls.Add(Me.cmbValorTiempo)
        Me.gbDatosAsignacion.Controls.Add(Me.Label9)
        Me.gbDatosAsignacion.Controls.Add(Me.txtDesMotivo)
        Me.gbDatosAsignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosAsignacion.Location = New System.Drawing.Point(8, 4)
        Me.gbDatosAsignacion.Name = "gbDatosAsignacion"
        Me.gbDatosAsignacion.Size = New System.Drawing.Size(532, 150)
        Me.gbDatosAsignacion.TabIndex = 0
        Me.gbDatosAsignacion.Text = "Datos de Feriado"
        Me.gbDatosAsignacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 258
        Me.Label2.Text = "Tipo Suspensión"
        '
        'cmbMotivo
        '
        Me.cmbMotivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMotivo_DesignTimeLayout.LayoutString = resources.GetString("cmbMotivo_DesignTimeLayout.LayoutString")
        Me.cmbMotivo.DesignTimeLayout = cmbMotivo_DesignTimeLayout
        Me.cmbMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMotivo.Location = New System.Drawing.Point(114, 115)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.SelectedIndex = -1
        Me.cmbMotivo.SelectedItem = Nothing
        Me.cmbMotivo.Size = New System.Drawing.Size(370, 20)
        Me.cmbMotivo.TabIndex = 257
        Me.cmbMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.Location = New System.Drawing.Point(422, 23)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(62, 17)
        Me.cbActivo.TabIndex = 256
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'cbPermisoArea
        '
        Me.cbPermisoArea.AutoSize = True
        Me.cbPermisoArea.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbPermisoArea.Location = New System.Drawing.Point(280, 85)
        Me.cbPermisoArea.Name = "cbPermisoArea"
        Me.cbPermisoArea.Size = New System.Drawing.Size(240, 17)
        Me.cbPermisoArea.TabIndex = 6
        Me.cbPermisoArea.Text = "Habilitar Permiso de Ingreso de Datos"
        Me.cbPermisoArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbPermisoArea.UseVisualStyleBackColor = True
        '
        'cbAplicaDscto
        '
        Me.cbAplicaDscto.AutoSize = True
        Me.cbAplicaDscto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAplicaDscto.Location = New System.Drawing.Point(159, 85)
        Me.cbAplicaDscto.Name = "cbAplicaDscto"
        Me.cbAplicaDscto.Size = New System.Drawing.Size(98, 17)
        Me.cbAplicaDscto.TabIndex = 5
        Me.cbAplicaDscto.Text = "Aplica Dscto"
        Me.cbAplicaDscto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAplicaDscto.UseVisualStyleBackColor = True
        '
        'cbAplicaAsistencia
        '
        Me.cbAplicaAsistencia.AutoSize = True
        Me.cbAplicaAsistencia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAplicaAsistencia.Location = New System.Drawing.Point(11, 85)
        Me.cbAplicaAsistencia.Name = "cbAplicaAsistencia"
        Me.cbAplicaAsistencia.Size = New System.Drawing.Size(123, 17)
        Me.cbAplicaAsistencia.TabIndex = 4
        Me.cbAplicaAsistencia.Text = "Aplica Asistencia"
        Me.cbAplicaAsistencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAplicaAsistencia.UseVisualStyleBackColor = True
        '
        'txtCodMotivo
        '
        Me.txtCodMotivo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodMotivo.ForeColor = System.Drawing.Color.Navy
        Me.txtCodMotivo.Location = New System.Drawing.Point(90, 21)
        Me.txtCodMotivo.MaxLength = 2
        Me.txtCodMotivo.Name = "txtCodMotivo"
        Me.txtCodMotivo.Size = New System.Drawing.Size(84, 20)
        Me.txtCodMotivo.TabIndex = 1
        Me.txtCodMotivo.TabStop = False
        Me.txtCodMotivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 254
        Me.Label4.Text = "Valor Tiempo"
        '
        'cmbValorTiempo
        '
        Me.cmbValorTiempo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbValorTiempo_DesignTimeLayout.LayoutString = resources.GetString("cmbValorTiempo_DesignTimeLayout.LayoutString")
        Me.cmbValorTiempo.DesignTimeLayout = cmbValorTiempo_DesignTimeLayout
        Me.cmbValorTiempo.Location = New System.Drawing.Point(293, 21)
        Me.cmbValorTiempo.Name = "cmbValorTiempo"
        Me.cmbValorTiempo.SelectedIndex = -1
        Me.cmbValorTiempo.SelectedItem = Nothing
        Me.cmbValorTiempo.Size = New System.Drawing.Size(87, 20)
        Me.cmbValorTiempo.TabIndex = 2
        Me.cmbValorTiempo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "Descripción"
        '
        'txtDesMotivo
        '
        Me.txtDesMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesMotivo.Location = New System.Drawing.Point(90, 52)
        Me.txtDesMotivo.Name = "txtDesMotivo"
        Me.txtDesMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesMotivo.Size = New System.Drawing.Size(432, 20)
        Me.txtDesMotivo.TabIndex = 3
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(277, 167)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 8
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
        Me.btnGuardar.Location = New System.Drawing.Point(193, 167)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmMotivoFalta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(576, 223)
        Me.Controls.Add(Me.gbDatosAsignacion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMotivoFalta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motivo de Falta"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosAsignacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosAsignacion.ResumeLayout(False)
        Me.gbDatosAsignacion.PerformLayout()
        CType(Me.cmbMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbValorTiempo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosAsignacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCodMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbValorTiempo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDesMotivo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cbPermisoArea As System.Windows.Forms.CheckBox
    Friend WithEvents cbAplicaDscto As System.Windows.Forms.CheckBox
    Friend WithEvents cbAplicaAsistencia As System.Windows.Forms.CheckBox
    Friend WithEvents cbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbMotivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
