<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaDestino
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentaDestino))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtPorcentaje = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnBuscarCuentaTrans = New System.Windows.Forms.Button()
        Me.lblDesCuentaTrans = New System.Windows.Forms.TextBox()
        Me.txtCodCuentaTrans = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscarCuentaDest = New System.Windows.Forms.Button()
        Me.cbActivo = New System.Windows.Forms.CheckBox()
        Me.lblDesCuentaDest = New System.Windows.Forms.TextBox()
        Me.txtCodCuentaDest = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscarCuenta = New System.Windows.Forms.Button()
        Me.lblDesCuenta = New System.Windows.Forms.TextBox()
        Me.txtCodCuenta = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
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
        Me.UiGroupBox1.Controls.Add(Me.txtPorcentaje)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarCuentaTrans)
        Me.UiGroupBox1.Controls.Add(Me.lblDesCuentaTrans)
        Me.UiGroupBox1.Controls.Add(Me.txtCodCuentaTrans)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarCuentaDest)
        Me.UiGroupBox1.Controls.Add(Me.cbActivo)
        Me.UiGroupBox1.Controls.Add(Me.lblDesCuentaDest)
        Me.UiGroupBox1.Controls.Add(Me.txtCodCuentaDest)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarCuenta)
        Me.UiGroupBox1.Controls.Add(Me.lblDesCuenta)
        Me.UiGroupBox1.Controls.Add(Me.txtCodCuenta)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Location = New System.Drawing.Point(10, 5)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(485, 137)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentaje.Location = New System.Drawing.Point(141, 106)
        Me.txtPorcentaje.MaxLength = 10
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(76, 20)
        Me.txtPorcentaje.TabIndex = 7
        Me.txtPorcentaje.Text = "0.00"
        Me.txtPorcentaje.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPorcentaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(67, 110)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 13)
        Me.Label14.TabIndex = 369
        Me.Label14.Text = "Porcentaje"
        '
        'btnBuscarCuentaTrans
        '
        Me.btnBuscarCuentaTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarCuentaTrans.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCuentaTrans.Location = New System.Drawing.Point(160, 74)
        Me.btnBuscarCuentaTrans.Name = "btnBuscarCuentaTrans"
        Me.btnBuscarCuentaTrans.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCuentaTrans.TabIndex = 6
        Me.btnBuscarCuentaTrans.TabStop = False
        Me.btnBuscarCuentaTrans.UseVisualStyleBackColor = True
        '
        'lblDesCuentaTrans
        '
        Me.lblDesCuentaTrans.BackColor = System.Drawing.SystemColors.Control
        Me.lblDesCuentaTrans.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDesCuentaTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesCuentaTrans.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDesCuentaTrans.Location = New System.Drawing.Point(189, 78)
        Me.lblDesCuentaTrans.Name = "lblDesCuentaTrans"
        Me.lblDesCuentaTrans.ReadOnly = True
        Me.lblDesCuentaTrans.Size = New System.Drawing.Size(287, 12)
        Me.lblDesCuentaTrans.TabIndex = 367
        Me.lblDesCuentaTrans.TabStop = False
        Me.lblDesCuentaTrans.Text = "DESCRIPCIÓN DE CUENTA CONTABLE"
        '
        'txtCodCuentaTrans
        '
        Me.txtCodCuentaTrans.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodCuentaTrans.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCuentaTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuentaTrans.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodCuentaTrans.Location = New System.Drawing.Point(99, 75)
        Me.txtCodCuentaTrans.MaxLength = 20
        Me.txtCodCuentaTrans.Name = "txtCodCuentaTrans"
        Me.txtCodCuentaTrans.Size = New System.Drawing.Size(58, 20)
        Me.txtCodCuentaTrans.TabIndex = 5
        Me.txtCodCuentaTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 366
        Me.Label1.Text = "Cuenta Trans"
        '
        'btnBuscarCuentaDest
        '
        Me.btnBuscarCuentaDest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarCuentaDest.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCuentaDest.Location = New System.Drawing.Point(160, 46)
        Me.btnBuscarCuentaDest.Name = "btnBuscarCuentaDest"
        Me.btnBuscarCuentaDest.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCuentaDest.TabIndex = 4
        Me.btnBuscarCuentaDest.TabStop = False
        Me.btnBuscarCuentaDest.UseVisualStyleBackColor = True
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbActivo.Location = New System.Drawing.Point(314, 109)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(62, 17)
        Me.cbActivo.TabIndex = 8
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'lblDesCuentaDest
        '
        Me.lblDesCuentaDest.BackColor = System.Drawing.SystemColors.Control
        Me.lblDesCuentaDest.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDesCuentaDest.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesCuentaDest.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDesCuentaDest.Location = New System.Drawing.Point(189, 50)
        Me.lblDesCuentaDest.Name = "lblDesCuentaDest"
        Me.lblDesCuentaDest.ReadOnly = True
        Me.lblDesCuentaDest.Size = New System.Drawing.Size(287, 12)
        Me.lblDesCuentaDest.TabIndex = 363
        Me.lblDesCuentaDest.TabStop = False
        Me.lblDesCuentaDest.Text = "DESCRIPCIÓN DE CUENTA CONTABLE"
        '
        'txtCodCuentaDest
        '
        Me.txtCodCuentaDest.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodCuentaDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCuentaDest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuentaDest.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodCuentaDest.Location = New System.Drawing.Point(99, 47)
        Me.txtCodCuentaDest.MaxLength = 20
        Me.txtCodCuentaDest.Name = "txtCodCuentaDest"
        Me.txtCodCuentaDest.Size = New System.Drawing.Size(58, 20)
        Me.txtCodCuentaDest.TabIndex = 3
        Me.txtCodCuentaDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 362
        Me.Label2.Text = "Cuenta Dest"
        '
        'btnBuscarCuenta
        '
        Me.btnBuscarCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarCuenta.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCuenta.Location = New System.Drawing.Point(160, 17)
        Me.btnBuscarCuenta.Name = "btnBuscarCuenta"
        Me.btnBuscarCuenta.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCuenta.TabIndex = 2
        Me.btnBuscarCuenta.TabStop = False
        Me.btnBuscarCuenta.UseVisualStyleBackColor = True
        '
        'lblDesCuenta
        '
        Me.lblDesCuenta.BackColor = System.Drawing.SystemColors.Control
        Me.lblDesCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDesCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDesCuenta.Location = New System.Drawing.Point(189, 21)
        Me.lblDesCuenta.Name = "lblDesCuenta"
        Me.lblDesCuenta.ReadOnly = True
        Me.lblDesCuenta.Size = New System.Drawing.Size(287, 12)
        Me.lblDesCuenta.TabIndex = 361
        Me.lblDesCuenta.TabStop = False
        Me.lblDesCuenta.Text = "DESCRIPCIÓN DE CUENTA CONTABLE"
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodCuenta.Location = New System.Drawing.Point(99, 18)
        Me.txtCodCuenta.MaxLength = 20
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Size = New System.Drawing.Size(58, 20)
        Me.txtCodCuenta.TabIndex = 1
        Me.txtCodCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 360
        Me.Label10.Text = "Cuenta"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(275, 149)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 25)
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
        Me.btnGuardar.Location = New System.Drawing.Point(189, 149)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 25)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmCuentaDestino
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(505, 181)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCuentaDestino"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuenta Destino"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscarCuentaDest As System.Windows.Forms.Button
    Friend WithEvents lblDesCuentaDest As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCuentaDest As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCuenta As System.Windows.Forms.Button
    Friend WithEvents lblDesCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCuentaTrans As System.Windows.Forms.Button
    Friend WithEvents lblDesCuentaTrans As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCuentaTrans As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentaje As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
