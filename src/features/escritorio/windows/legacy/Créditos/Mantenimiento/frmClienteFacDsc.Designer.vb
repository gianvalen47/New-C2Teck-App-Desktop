<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClienteFacDsc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClienteFacDsc))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miGuardar = New System.Windows.Forms.ToolStripMenuItem
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.miCancelar = New System.Windows.Forms.ToolStripMenuItem
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCliente = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRucCliente = New Janus.Windows.GridEX.EditControls.EditBox
        Me.txtDniCliente = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFactorCliente = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDsctoCliente = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkbDNCliente = New Janus.Windows.EditControls.UICheckBox
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miGuardar, Me.miEliminar, Me.miCancelar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(117, 70)
        '
        'miGuardar
        '
        Me.miGuardar.Image = CType(resources.GetObject("miGuardar.Image"), System.Drawing.Image)
        Me.miGuardar.Name = "miGuardar"
        Me.miGuardar.Size = New System.Drawing.Size(116, 22)
        Me.miGuardar.Text = "&Guandar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = CType(resources.GetObject("miEliminar.Image"), System.Drawing.Image)
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(116, 22)
        Me.miEliminar.Text = "&Eliminar"
        '
        'miCancelar
        '
        Me.miCancelar.Image = CType(resources.GetObject("miCancelar.Image"), System.Drawing.Image)
        Me.miCancelar.Name = "miCancelar"
        Me.miCancelar.Size = New System.Drawing.Size(116, 22)
        Me.miCancelar.Text = "&Cancelar"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Cliente :"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Control
        Me.txtCliente.ButtonImage = CType(resources.GetObject("txtCliente.ButtonImage"), System.Drawing.Image)
        Me.txtCliente.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtCliente.Location = New System.Drawing.Point(30, 59)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(385, 20)
        Me.txtCliente.TabIndex = 1
        Me.txtCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "R.U.C.  :"
        '
        'txtRucCliente
        '
        Me.txtRucCliente.Enabled = False
        Me.txtRucCliente.Location = New System.Drawing.Point(100, 97)
        Me.txtRucCliente.Name = "txtRucCliente"
        Me.txtRucCliente.Size = New System.Drawing.Size(125, 20)
        Me.txtRucCliente.TabIndex = 3
        Me.txtRucCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDniCliente
        '
        Me.txtDniCliente.Enabled = False
        Me.txtDniCliente.Location = New System.Drawing.Point(290, 97)
        Me.txtDniCliente.Name = "txtDniCliente"
        Me.txtDniCliente.Size = New System.Drawing.Size(125, 20)
        Me.txtDniCliente.TabIndex = 5
        Me.txtDniCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(235, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "D.N.I. :"
        '
        'txtFactorCliente
        '
        Me.txtFactorCliente.DecimalDigits = 2
        Me.txtFactorCliente.EditMode = Janus.Windows.GridEX.NumericEditMode.Value
        Me.txtFactorCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactorCliente.FormatString = "#0.00"
        Me.txtFactorCliente.Location = New System.Drawing.Point(130, 138)
        Me.txtFactorCliente.MaxLength = 10
        Me.txtFactorCliente.Name = "txtFactorCliente"
        Me.txtFactorCliente.Size = New System.Drawing.Size(60, 20)
        Me.txtFactorCliente.TabIndex = 7
        Me.txtFactorCliente.Text = "0.00"
        Me.txtFactorCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtFactorCliente.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtFactorCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Factor :"
        '
        'txtDsctoCliente
        '
        Me.txtDsctoCliente.DecimalDigits = 2
        Me.txtDsctoCliente.EditMode = Janus.Windows.GridEX.NumericEditMode.Value
        Me.txtDsctoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsctoCliente.FormatString = "#0.00"
        Me.txtDsctoCliente.Location = New System.Drawing.Point(330, 141)
        Me.txtDsctoCliente.MaxLength = 10
        Me.txtDsctoCliente.Name = "txtDsctoCliente"
        Me.txtDsctoCliente.Size = New System.Drawing.Size(60, 20)
        Me.txtDsctoCliente.TabIndex = 9
        Me.txtDsctoCliente.Text = "0.00"
        Me.txtDsctoCliente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDsctoCliente.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDsctoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(235, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Descuento :"
        '
        'chkbDNCliente
        '
        Me.chkbDNCliente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkbDNCliente.Location = New System.Drawing.Point(30, 191)
        Me.chkbDNCliente.Name = "chkbDNCliente"
        Me.chkbDNCliente.Size = New System.Drawing.Size(100, 17)
        Me.chkbDNCliente.TabIndex = 10
        Me.chkbDNCliente.Text = "Deale Net :"
        Me.chkbDNCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.chkbDNCliente)
        Me.UiGroupBox1.Controls.Add(Me.txtCliente)
        Me.UiGroupBox1.Controls.Add(Me.txtDsctoCliente)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtRucCliente)
        Me.UiGroupBox1.Controls.Add(Me.txtFactorCliente)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtDniCliente)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(492, 266)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "  [ Detalles ]  "
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.btnGuardar)
        Me.UiGroupBox2.Controls.Add(Me.btnEliminar)
        Me.UiGroupBox2.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox2.Location = New System.Drawing.Point(0, 231)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(492, 35)
        Me.UiGroupBox2.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(270, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 24)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(343, 8)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(73, 24)
        Me.btnEliminar.TabIndex = 1
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(416, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 24)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmClienteFacDsc
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(492, 266)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClienteFacDsc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmClienteFacDsc"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
  Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
  Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents miGuardar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents miCancelar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtCliente As Janus.Windows.GridEX.EditControls.EditBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtRucCliente As Janus.Windows.GridEX.EditControls.EditBox
  Friend WithEvents txtDniCliente As Janus.Windows.GridEX.EditControls.EditBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents chkbDNCliente As Janus.Windows.EditControls.UICheckBox
  Friend WithEvents txtDsctoCliente As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtFactorCliente As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
  Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
  Friend WithEvents btnGuardar As System.Windows.Forms.Button
  Friend WithEvents btnEliminar As System.Windows.Forms.Button
  Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
