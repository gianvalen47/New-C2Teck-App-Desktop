<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresoPlanilla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoPlanilla))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBuscarCodRemun = New System.Windows.Forms.Button()
        Me.txtConRemu = New System.Windows.Forms.TextBox()
        Me.cbAutomatico = New System.Windows.Forms.CheckBox()
        Me.cbAfectoAporte = New System.Windows.Forms.CheckBox()
        Me.cbAfectoDscto = New System.Windows.Forms.CheckBox()
        Me.cbActivo = New System.Windows.Forms.CheckBox()
        Me.txtAbrv = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdRubroIng = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cbContrato = New System.Windows.Forms.CheckBox()
        Me.cbAfectoQuinta = New System.Windows.Forms.CheckBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cbContrato)
        Me.UiGroupBox1.Controls.Add(Me.cbAfectoQuinta)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarCodRemun)
        Me.UiGroupBox1.Controls.Add(Me.txtConRemu)
        Me.UiGroupBox1.Controls.Add(Me.cbAutomatico)
        Me.UiGroupBox1.Controls.Add(Me.cbAfectoAporte)
        Me.UiGroupBox1.Controls.Add(Me.cbAfectoDscto)
        Me.UiGroupBox1.Controls.Add(Me.cbActivo)
        Me.UiGroupBox1.Controls.Add(Me.txtAbrv)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtDescripcion)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtIdRubroIng)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 3)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(475, 197)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Datos de Ingreso"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 13)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Cod. Remuneración "
        '
        'btnBuscarCodRemun
        '
        Me.btnBuscarCodRemun.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCodRemun.Location = New System.Drawing.Point(201, 107)
        Me.btnBuscarCodRemun.Name = "btnBuscarCodRemun"
        Me.btnBuscarCodRemun.Size = New System.Drawing.Size(29, 21)
        Me.btnBuscarCodRemun.TabIndex = 10
        Me.btnBuscarCodRemun.UseVisualStyleBackColor = True
        '
        'txtConRemu
        '
        Me.txtConRemu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConRemu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConRemu.Location = New System.Drawing.Point(142, 107)
        Me.txtConRemu.MaxLength = 3
        Me.txtConRemu.Name = "txtConRemu"
        Me.txtConRemu.ReadOnly = True
        Me.txtConRemu.Size = New System.Drawing.Size(53, 20)
        Me.txtConRemu.TabIndex = 74
        '
        'cbAutomatico
        '
        Me.cbAutomatico.AutoSize = True
        Me.cbAutomatico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAutomatico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAutomatico.Location = New System.Drawing.Point(368, 139)
        Me.cbAutomatico.Name = "cbAutomatico"
        Me.cbAutomatico.Size = New System.Drawing.Size(89, 17)
        Me.cbAutomatico.TabIndex = 14
        Me.cbAutomatico.Text = "Automático"
        Me.cbAutomatico.UseVisualStyleBackColor = True
        '
        'cbAfectoAporte
        '
        Me.cbAfectoAporte.AutoSize = True
        Me.cbAfectoAporte.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAfectoAporte.Checked = True
        Me.cbAfectoAporte.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAfectoAporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAfectoAporte.Location = New System.Drawing.Point(238, 139)
        Me.cbAfectoAporte.Name = "cbAfectoAporte"
        Me.cbAfectoAporte.Size = New System.Drawing.Size(104, 17)
        Me.cbAfectoAporte.TabIndex = 13
        Me.cbAfectoAporte.Text = "Afecto Aporte"
        Me.cbAfectoAporte.UseVisualStyleBackColor = True
        '
        'cbAfectoDscto
        '
        Me.cbAfectoDscto.AutoSize = True
        Me.cbAfectoDscto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAfectoDscto.Checked = True
        Me.cbAfectoDscto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAfectoDscto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAfectoDscto.Location = New System.Drawing.Point(108, 139)
        Me.cbAfectoDscto.Name = "cbAfectoDscto"
        Me.cbAfectoDscto.Size = New System.Drawing.Size(100, 17)
        Me.cbAfectoDscto.TabIndex = 12
        Me.cbAfectoDscto.Text = "Afecto Dscto"
        Me.cbAfectoDscto.UseVisualStyleBackColor = True
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.Checked = True
        Me.cbActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbActivo.Location = New System.Drawing.Point(17, 139)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(62, 17)
        Me.cbActivo.TabIndex = 11
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'txtAbrv
        '
        Me.txtAbrv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbrv.Location = New System.Drawing.Point(95, 78)
        Me.txtAbrv.Name = "txtAbrv"
        Me.txtAbrv.Size = New System.Drawing.Size(335, 20)
        Me.txtAbrv.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Abrv."
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(95, 49)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(367, 20)
        Me.txtDescripcion.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción"
        '
        'txtIdRubroIng
        '
        Me.txtIdRubroIng.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdRubroIng.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdRubroIng.Location = New System.Drawing.Point(95, 20)
        Me.txtIdRubroIng.Name = "txtIdRubroIng"
        Me.txtIdRubroIng.ReadOnly = True
        Me.txtIdRubroIng.Size = New System.Drawing.Size(76, 20)
        Me.txtIdRubroIng.TabIndex = 1
        Me.txtIdRubroIng.TabStop = False
        Me.txtIdRubroIng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(236, 212)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 25)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(150, 212)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 25)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cbContrato
        '
        Me.cbContrato.AutoSize = True
        Me.cbContrato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbContrato.Location = New System.Drawing.Point(146, 168)
        Me.cbContrato.Name = "cbContrato"
        Me.cbContrato.Size = New System.Drawing.Size(120, 17)
        Me.cbContrato.TabIndex = 78
        Me.cbContrato.Text = "Ingreso Contrato"
        Me.cbContrato.UseVisualStyleBackColor = True
        '
        'cbAfectoQuinta
        '
        Me.cbAfectoQuinta.AutoSize = True
        Me.cbAfectoQuinta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAfectoQuinta.Checked = True
        Me.cbAfectoQuinta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAfectoQuinta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAfectoQuinta.Location = New System.Drawing.Point(16, 168)
        Me.cbAfectoQuinta.Name = "cbAfectoQuinta"
        Me.cbAfectoQuinta.Size = New System.Drawing.Size(104, 17)
        Me.cbAfectoQuinta.TabIndex = 77
        Me.cbAfectoQuinta.Text = "Afecto Quinta"
        Me.cbAfectoQuinta.UseVisualStyleBackColor = True
        '
        'frmIngresoPlanilla
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(496, 253)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIngresoPlanilla"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso Planilla"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAbrv As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdRubroIng As System.Windows.Forms.TextBox
    Friend WithEvents cbAutomatico As System.Windows.Forms.CheckBox
    Friend WithEvents cbAfectoAporte As System.Windows.Forms.CheckBox
    Friend WithEvents cbAfectoDscto As System.Windows.Forms.CheckBox
    Friend WithEvents cbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnBuscarCodRemun As Button
    Friend WithEvents txtConRemu As TextBox
    Friend WithEvents cbContrato As CheckBox
    Friend WithEvents cbAfectoQuinta As CheckBox
End Class
