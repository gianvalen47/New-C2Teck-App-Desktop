<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaMayor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentaMayor))
        Me.gbCuentaMayor = New Janus.Windows.EditControls.UIGroupBox
        Me.cbActivo = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCodCuentaMayor = New System.Windows.Forms.TextBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.gbCuentaMayor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCuentaMayor.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbCuentaMayor
        '
        Me.gbCuentaMayor.Controls.Add(Me.cbActivo)
        Me.gbCuentaMayor.Controls.Add(Me.Label2)
        Me.gbCuentaMayor.Controls.Add(Me.txtDescripcion)
        Me.gbCuentaMayor.Controls.Add(Me.Label1)
        Me.gbCuentaMayor.Controls.Add(Me.txtCodCuentaMayor)
        Me.gbCuentaMayor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCuentaMayor.Location = New System.Drawing.Point(7, 6)
        Me.gbCuentaMayor.Name = "gbCuentaMayor"
        Me.gbCuentaMayor.Size = New System.Drawing.Size(538, 97)
        Me.gbCuentaMayor.TabIndex = 185
        Me.gbCuentaMayor.Text = "Datos de Cuenta Mayor"
        Me.gbCuentaMayor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.Location = New System.Drawing.Point(261, 22)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(62, 17)
        Me.cbActivo.TabIndex = 2
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Nombre Cta"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(100, 46)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(430, 44)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cuenta Mayor"
        '
        'txtCodCuentaMayor
        '
        Me.txtCodCuentaMayor.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodCuentaMayor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCuentaMayor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuentaMayor.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodCuentaMayor.Location = New System.Drawing.Point(100, 20)
        Me.txtCodCuentaMayor.MaxLength = 2
        Me.txtCodCuentaMayor.Name = "txtCodCuentaMayor"
        Me.txtCodCuentaMayor.Size = New System.Drawing.Size(87, 20)
        Me.txtCodCuentaMayor.TabIndex = 1
        Me.txtCodCuentaMayor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(279, 109)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 25)
        Me.btnCancelar.TabIndex = 186
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
        Me.btnGuardar.Location = New System.Drawing.Point(193, 109)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 25)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Silver
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmCuentaMayor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(551, 138)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbCuentaMayor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCuentaMayor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuenta Mayor"
        CType(Me.gbCuentaMayor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCuentaMayor.ResumeLayout(False)
        Me.gbCuentaMayor.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbCuentaMayor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodCuentaMayor As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
