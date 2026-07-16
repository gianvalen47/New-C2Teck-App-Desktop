<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAfp_Nuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAfp_Nuevo))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.gbDatosAfp = New Janus.Windows.EditControls.UIGroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTopePrima = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAbrvAfp = New System.Windows.Forms.TextBox
        Me.cbActivo = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIdAfp = New System.Windows.Forms.TextBox
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosAfp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosAfp.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(219, 134)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 25)
        Me.btnCancelar.TabIndex = 7
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
        Me.btnGuardar.Location = New System.Drawing.Point(133, 134)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 25)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbDatosAfp
        '
        Me.gbDatosAfp.Controls.Add(Me.Label8)
        Me.gbDatosAfp.Controls.Add(Me.txtTopePrima)
        Me.gbDatosAfp.Controls.Add(Me.Label3)
        Me.gbDatosAfp.Controls.Add(Me.txtAbrvAfp)
        Me.gbDatosAfp.Controls.Add(Me.cbActivo)
        Me.gbDatosAfp.Controls.Add(Me.Label2)
        Me.gbDatosAfp.Controls.Add(Me.txtDescripcion)
        Me.gbDatosAfp.Controls.Add(Me.Label1)
        Me.gbDatosAfp.Controls.Add(Me.txtIdAfp)
        Me.gbDatosAfp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosAfp.Location = New System.Drawing.Point(8, 6)
        Me.gbDatosAfp.Name = "gbDatosAfp"
        Me.gbDatosAfp.Size = New System.Drawing.Size(415, 121)
        Me.gbDatosAfp.TabIndex = 0
        Me.gbDatosAfp.Text = "Datos de AFP"
        Me.gbDatosAfp.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 357
        Me.Label8.Text = "Tope Prima"
        '
        'txtTopePrima
        '
        Me.txtTopePrima.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTopePrima.Location = New System.Drawing.Point(89, 89)
        Me.txtTopePrima.MaxLength = 10
        Me.txtTopePrima.Name = "txtTopePrima"
        Me.txtTopePrima.Size = New System.Drawing.Size(101, 20)
        Me.txtTopePrima.TabIndex = 4
        Me.txtTopePrima.Text = "0.00"
        Me.txtTopePrima.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTopePrima.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(210, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Abrv."
        '
        'txtAbrvAfp
        '
        Me.txtAbrvAfp.BackColor = System.Drawing.SystemColors.Window
        Me.txtAbrvAfp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbrvAfp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbrvAfp.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtAbrvAfp.Location = New System.Drawing.Point(253, 22)
        Me.txtAbrvAfp.MaxLength = 5
        Me.txtAbrvAfp.Name = "txtAbrvAfp"
        Me.txtAbrvAfp.Size = New System.Drawing.Size(88, 20)
        Me.txtAbrvAfp.TabIndex = 2
        Me.txtAbrvAfp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.Location = New System.Drawing.Point(264, 92)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(62, 17)
        Me.cbActivo.TabIndex = 5
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(89, 48)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(316, 35)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Código"
        '
        'txtIdAfp
        '
        Me.txtIdAfp.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdAfp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdAfp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdAfp.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdAfp.Location = New System.Drawing.Point(89, 22)
        Me.txtIdAfp.MaxLength = 5
        Me.txtIdAfp.Name = "txtIdAfp"
        Me.txtIdAfp.Size = New System.Drawing.Size(78, 20)
        Me.txtIdAfp.TabIndex = 1
        Me.txtIdAfp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmAfp_Nuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(431, 165)
        Me.Controls.Add(Me.gbDatosAfp)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAfp_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo AFP"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosAfp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosAfp.ResumeLayout(False)
        Me.gbDatosAfp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbDatosAfp As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAbrvAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTopePrima As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
