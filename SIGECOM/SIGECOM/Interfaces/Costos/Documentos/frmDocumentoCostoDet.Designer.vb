<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentoCostoDet
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
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCosDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCosSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalCosDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalCosSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo :"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(53, 5)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(140, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.TabStop = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(77, 28)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(328, 20)
        Me.txtDescripcion.TabIndex = 2
        Me.txtDescripcion.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripcion :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Precio :"
        '
        'txtPrecio
        '
        Me.txtPrecio.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPrecio.Enabled = False
        Me.txtPrecio.Location = New System.Drawing.Point(70, 39)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(102, 20)
        Me.txtPrecio.TabIndex = 4
        Me.txtPrecio.TabStop = False
        Me.txtPrecio.Text = "0.00"
        Me.txtPrecio.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtDescuento
        '
        Me.txtDescuento.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDescuento.Enabled = False
        Me.txtDescuento.Location = New System.Drawing.Point(250, 39)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(53, 20)
        Me.txtDescuento.TabIndex = 5
        Me.txtDescuento.TabStop = False
        Me.txtDescuento.Text = "0.00"
        Me.txtDescuento.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(181, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Descuento :"
        '
        'txtCosDol
        '
        Me.txtCosDol.BackColor = System.Drawing.SystemColors.Control
        Me.txtCosDol.DecimalDigits = 10
        Me.txtCosDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCosDol.Location = New System.Drawing.Point(70, 15)
        Me.txtCosDol.Name = "txtCosDol"
        Me.txtCosDol.ReadOnly = True
        Me.txtCosDol.Size = New System.Drawing.Size(126, 20)
        Me.txtCosDol.TabIndex = 7
        Me.txtCosDol.Text = "0.0000000000"
        Me.txtCosDol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Costo $ :"
        '
        'txtCosSol
        '
        Me.txtCosSol.BackColor = System.Drawing.SystemColors.Control
        Me.txtCosSol.DecimalDigits = 10
        Me.txtCosSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCosSol.Location = New System.Drawing.Point(265, 15)
        Me.txtCosSol.Name = "txtCosSol"
        Me.txtCosSol.ReadOnly = True
        Me.txtCosSol.Size = New System.Drawing.Size(126, 20)
        Me.txtCosSol.TabIndex = 8
        Me.txtCosSol.Text = "0.0000000000"
        Me.txtCosSol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(200, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Costo S/.  :"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtTotalCosDol)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalCosSol)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.txtCosDol)
        Me.UiGroupBox1.Controls.Add(Me.txtCosSol)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 143)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(399, 69)
        Me.UiGroupBox1.TabIndex = 13
        Me.UiGroupBox1.Text = "Costos"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalCosDol
        '
        Me.txtTotalCosDol.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalCosDol.DecimalDigits = 10
        Me.txtTotalCosDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalCosDol.Location = New System.Drawing.Point(70, 41)
        Me.txtTotalCosDol.Name = "txtTotalCosDol"
        Me.txtTotalCosDol.ReadOnly = True
        Me.txtTotalCosDol.Size = New System.Drawing.Size(126, 20)
        Me.txtTotalCosDol.TabIndex = 9
        Me.txtTotalCosDol.Text = "0.0000000000"
        Me.txtTotalCosDol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'txtTotalCosSol
        '
        Me.txtTotalCosSol.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalCosSol.DecimalDigits = 10
        Me.txtTotalCosSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalCosSol.Location = New System.Drawing.Point(265, 41)
        Me.txtTotalCosSol.Name = "txtTotalCosSol"
        Me.txtTotalCosSol.ReadOnly = True
        Me.txtTotalCosSol.Size = New System.Drawing.Size(126, 20)
        Me.txtTotalCosSol.TabIndex = 10
        Me.txtTotalCosSol.Text = "0.0000000000"
        Me.txtTotalCosSol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Total $ :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(203, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Total S/.  :"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(70, 16)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(73, 20)
        Me.txtCantidad.TabIndex = 3
        Me.txtCantidad.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Cantidad :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtTotal)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtCantidad)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtPrecio)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.txtDescuento)
        Me.UiGroupBox2.Location = New System.Drawing.Point(7, 52)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(399, 87)
        Me.UiGroupBox2.TabIndex = 16
        Me.UiGroupBox2.Text = "Precio"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Total :"
        '
        'txtTotal
        '
        Me.txtTotal.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(70, 62)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(102, 20)
        Me.txtTotal.TabIndex = 6
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'btnAceptar
        '
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(231, 219)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(84, 28)
        Me.btnAceptar.TabIndex = 17
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        Me.btnAceptar.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.ImgApptRecur
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(324, 219)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(83, 28)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmDocumentoCostoDet
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(419, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(420, 285)
        Me.Name = "frmDocumentoCostoDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalles"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCosDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCosSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalCosDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalCosSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button

End Class
