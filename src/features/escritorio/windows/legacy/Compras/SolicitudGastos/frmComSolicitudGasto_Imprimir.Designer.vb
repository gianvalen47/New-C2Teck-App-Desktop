<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudGasto_Imprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudGasto_Imprimir))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.rbGastoViaje = New System.Windows.Forms.RadioButton()
        Me.rbPrincipal = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cbResumenProvisional = New System.Windows.Forms.CheckBox()
        Me.rbListado = New System.Windows.Forms.RadioButton()
        Me.rbDeclaracionJurada = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbResumenProvisionalGen = New System.Windows.Forms.CheckBox()
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
        'rbGastoViaje
        '
        Me.rbGastoViaje.AutoSize = True
        Me.rbGastoViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGastoViaje.ForeColor = System.Drawing.SystemColors.Desktop
        Me.rbGastoViaje.Location = New System.Drawing.Point(46, 68)
        Me.rbGastoViaje.Name = "rbGastoViaje"
        Me.rbGastoViaje.Size = New System.Drawing.Size(190, 17)
        Me.rbGastoViaje.TabIndex = 1
        Me.rbGastoViaje.TabStop = True
        Me.rbGastoViaje.Text = "Formato Gasto Viaje - Viatico"
        Me.rbGastoViaje.UseVisualStyleBackColor = True
        '
        'rbPrincipal
        '
        Me.rbPrincipal.AutoSize = True
        Me.rbPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPrincipal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.rbPrincipal.Location = New System.Drawing.Point(46, 22)
        Me.rbPrincipal.Name = "rbPrincipal"
        Me.rbPrincipal.Size = New System.Drawing.Size(123, 17)
        Me.rbPrincipal.TabIndex = 0
        Me.rbPrincipal.TabStop = True
        Me.rbPrincipal.Text = "Formato Principal"
        Me.rbPrincipal.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(61, 198)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 27)
        Me.btnAceptar.TabIndex = 26
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
        Me.btnCancelar.Location = New System.Drawing.Point(145, 198)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 27
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cbResumenProvisional
        '
        Me.cbResumenProvisional.AutoSize = True
        Me.cbResumenProvisional.Location = New System.Drawing.Point(67, 92)
        Me.cbResumenProvisional.Name = "cbResumenProvisional"
        Me.cbResumenProvisional.Size = New System.Drawing.Size(144, 17)
        Me.cbResumenProvisional.TabIndex = 29
        Me.cbResumenProvisional.Text = "Resumen Provisional"
        Me.cbResumenProvisional.UseVisualStyleBackColor = True
        '
        'rbListado
        '
        Me.rbListado.AutoSize = True
        Me.rbListado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbListado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.rbListado.Location = New System.Drawing.Point(46, 144)
        Me.rbListado.Name = "rbListado"
        Me.rbListado.Size = New System.Drawing.Size(115, 17)
        Me.rbListado.TabIndex = 28
        Me.rbListado.TabStop = True
        Me.rbListado.Text = "Formato Listado"
        Me.rbListado.UseVisualStyleBackColor = True
        '
        'rbDeclaracionJurada
        '
        Me.rbDeclaracionJurada.AutoSize = True
        Me.rbDeclaracionJurada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDeclaracionJurada.ForeColor = System.Drawing.SystemColors.Desktop
        Me.rbDeclaracionJurada.Location = New System.Drawing.Point(46, 116)
        Me.rbDeclaracionJurada.Name = "rbDeclaracionJurada"
        Me.rbDeclaracionJurada.Size = New System.Drawing.Size(135, 17)
        Me.rbDeclaracionJurada.TabIndex = 30
        Me.rbDeclaracionJurada.TabStop = True
        Me.rbDeclaracionJurada.Text = "Declaración Jurada"
        Me.rbDeclaracionJurada.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cbResumenProvisionalGen)
        Me.UiGroupBox1.Controls.Add(Me.rbDeclaracionJurada)
        Me.UiGroupBox1.Controls.Add(Me.rbPrincipal)
        Me.UiGroupBox1.Controls.Add(Me.cbResumenProvisional)
        Me.UiGroupBox1.Controls.Add(Me.rbGastoViaje)
        Me.UiGroupBox1.Controls.Add(Me.rbListado)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(247, 175)
        Me.UiGroupBox1.TabIndex = 112
        Me.UiGroupBox1.Text = "Imprimir"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbResumenProvisionalGen
        '
        Me.cbResumenProvisionalGen.AutoSize = True
        Me.cbResumenProvisionalGen.Location = New System.Drawing.Point(67, 45)
        Me.cbResumenProvisionalGen.Name = "cbResumenProvisionalGen"
        Me.cbResumenProvisionalGen.Size = New System.Drawing.Size(144, 17)
        Me.cbResumenProvisionalGen.TabIndex = 31
        Me.cbResumenProvisionalGen.Text = "Resumen Provisional"
        Me.cbResumenProvisionalGen.UseVisualStyleBackColor = True
        '
        'frmComSolicitudGasto_Imprimir
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(272, 235)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudGasto_Imprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir Solicitud de Gasto"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rbPrincipal As System.Windows.Forms.RadioButton
    Friend WithEvents rbGastoViaje As System.Windows.Forms.RadioButton
    Friend WithEvents rbListado As System.Windows.Forms.RadioButton
    Friend WithEvents cbResumenProvisional As System.Windows.Forms.CheckBox
    Friend WithEvents rbDeclaracionJurada As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbResumenProvisionalGen As CheckBox
End Class
