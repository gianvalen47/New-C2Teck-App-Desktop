<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImprimirReporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImprimirReporte))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbtnConCodigo = New System.Windows.Forms.RadioButton()
        Me.rbtnSinCodigo = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cbMostrarDscto = New System.Windows.Forms.CheckBox()
        Me.gbStock = New System.Windows.Forms.GroupBox()
        Me.UiRadioButton3 = New Janus.Windows.EditControls.UIRadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.UiRadioButton7 = New Janus.Windows.EditControls.UIRadioButton()
        Me.UiRadioButton8 = New Janus.Windows.EditControls.UIRadioButton()
        Me.UiRadioButton9 = New Janus.Windows.EditControls.UIRadioButton()
        Me.UiRadioButton2 = New Janus.Windows.EditControls.UIRadioButton()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.UiRadioButton1 = New Janus.Windows.EditControls.UIRadioButton()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbStockNinguno = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbStockAlmCoti = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbStockAlmPrin = New Janus.Windows.EditControls.UIRadioButton()
        Me.UiRadioButton5 = New Janus.Windows.EditControls.UIRadioButton()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.UiRadioButton6 = New Janus.Windows.EditControls.UIRadioButton()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnEnviarCorreo = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbStock.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Opciones de Impresión"
        '
        'rbtnConCodigo
        '
        Me.rbtnConCodigo.AutoSize = True
        Me.rbtnConCodigo.Location = New System.Drawing.Point(41, 36)
        Me.rbtnConCodigo.Name = "rbtnConCodigo"
        Me.rbtnConCodigo.Size = New System.Drawing.Size(80, 17)
        Me.rbtnConCodigo.TabIndex = 1
        Me.rbtnConCodigo.TabStop = True
        Me.rbtnConCodigo.Text = "Con Código"
        Me.rbtnConCodigo.UseVisualStyleBackColor = True
        '
        'rbtnSinCodigo
        '
        Me.rbtnSinCodigo.AutoSize = True
        Me.rbtnSinCodigo.Location = New System.Drawing.Point(41, 59)
        Me.rbtnSinCodigo.Name = "rbtnSinCodigo"
        Me.rbtnSinCodigo.Size = New System.Drawing.Size(76, 17)
        Me.rbtnSinCodigo.TabIndex = 2
        Me.rbtnSinCodigo.TabStop = True
        Me.rbtnSinCodigo.Text = "Sin Código"
        Me.rbtnSinCodigo.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(13, 164)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(99, 164)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cbMostrarDscto
        '
        Me.cbMostrarDscto.AutoSize = True
        Me.cbMostrarDscto.Location = New System.Drawing.Point(68, 135)
        Me.cbMostrarDscto.Name = "cbMostrarDscto"
        Me.cbMostrarDscto.Size = New System.Drawing.Size(116, 17)
        Me.cbMostrarDscto.TabIndex = 5
        Me.cbMostrarDscto.Text = "Mostrar Descuento"
        Me.cbMostrarDscto.UseVisualStyleBackColor = True
        '
        'gbStock
        '
        Me.gbStock.Controls.Add(Me.UiRadioButton3)
        Me.gbStock.Controls.Add(Me.GroupBox2)
        Me.gbStock.Controls.Add(Me.UiRadioButton2)
        Me.gbStock.Controls.Add(Me.CheckBox2)
        Me.gbStock.Controls.Add(Me.UiRadioButton1)
        Me.gbStock.Controls.Add(Me.Button3)
        Me.gbStock.Controls.Add(Me.Button4)
        Me.gbStock.Location = New System.Drawing.Point(129, 33)
        Me.gbStock.Name = "gbStock"
        Me.gbStock.Size = New System.Drawing.Size(133, 92)
        Me.gbStock.TabIndex = 7
        Me.gbStock.TabStop = False
        Me.gbStock.Text = "Stock Almacen"
        '
        'UiRadioButton3
        '
        Me.UiRadioButton3.Location = New System.Drawing.Point(12, 63)
        Me.UiRadioButton3.Name = "UiRadioButton3"
        Me.UiRadioButton3.Size = New System.Drawing.Size(104, 23)
        Me.UiRadioButton3.TabIndex = 2
        Me.UiRadioButton3.Text = "UiRadioButton3"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.UiRadioButton7)
        Me.GroupBox2.Controls.Add(Me.UiRadioButton8)
        Me.GroupBox2.Controls.Add(Me.UiRadioButton9)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(133, 92)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stock Almacen"
        '
        'UiRadioButton7
        '
        Me.UiRadioButton7.Location = New System.Drawing.Point(12, 63)
        Me.UiRadioButton7.Name = "UiRadioButton7"
        Me.UiRadioButton7.Size = New System.Drawing.Size(104, 23)
        Me.UiRadioButton7.TabIndex = 2
        Me.UiRadioButton7.Text = "UiRadioButton3"
        '
        'UiRadioButton8
        '
        Me.UiRadioButton8.Location = New System.Drawing.Point(12, 40)
        Me.UiRadioButton8.Name = "UiRadioButton8"
        Me.UiRadioButton8.Size = New System.Drawing.Size(104, 23)
        Me.UiRadioButton8.TabIndex = 1
        Me.UiRadioButton8.Text = "UiRadioButton2"
        '
        'UiRadioButton9
        '
        Me.UiRadioButton9.Location = New System.Drawing.Point(12, 19)
        Me.UiRadioButton9.Name = "UiRadioButton9"
        Me.UiRadioButton9.Size = New System.Drawing.Size(104, 23)
        Me.UiRadioButton9.TabIndex = 0
        Me.UiRadioButton9.Text = "UiRadioButton1"
        '
        'UiRadioButton2
        '
        Me.UiRadioButton2.Location = New System.Drawing.Point(12, 40)
        Me.UiRadioButton2.Name = "UiRadioButton2"
        Me.UiRadioButton2.Size = New System.Drawing.Size(104, 23)
        Me.UiRadioButton2.TabIndex = 1
        Me.UiRadioButton2.Text = "UiRadioButton2"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(-60, 75)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(116, 17)
        Me.CheckBox2.TabIndex = 5
        Me.CheckBox2.Text = "Mostrar Descuento"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'UiRadioButton1
        '
        Me.UiRadioButton1.Location = New System.Drawing.Point(12, 19)
        Me.UiRadioButton1.Name = "UiRadioButton1"
        Me.UiRadioButton1.Size = New System.Drawing.Size(104, 23)
        Me.UiRadioButton1.TabIndex = 0
        Me.UiRadioButton1.Text = "UiRadioButton1"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(-74, 105)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Aceptar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 105)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Cancelar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 164)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(99, 164)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.UiRadioButton5)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.UiRadioButton6)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Location = New System.Drawing.Point(129, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(133, 92)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stock Almacen"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbStockNinguno)
        Me.GroupBox3.Controls.Add(Me.rbStockAlmCoti)
        Me.GroupBox3.Controls.Add(Me.rbStockAlmPrin)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(133, 92)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Stock Almacen"
        '
        'rbStockNinguno
        '
        Me.rbStockNinguno.Checked = True
        Me.rbStockNinguno.Location = New System.Drawing.Point(6, 17)
        Me.rbStockNinguno.Name = "rbStockNinguno"
        Me.rbStockNinguno.Size = New System.Drawing.Size(104, 23)
        Me.rbStockNinguno.TabIndex = 2
        Me.rbStockNinguno.TabStop = True
        Me.rbStockNinguno.Text = "Ninguno"
        '
        'rbStockAlmCoti
        '
        Me.rbStockAlmCoti.Location = New System.Drawing.Point(6, 63)
        Me.rbStockAlmCoti.Name = "rbStockAlmCoti"
        Me.rbStockAlmCoti.Size = New System.Drawing.Size(104, 23)
        Me.rbStockAlmCoti.TabIndex = 1
        Me.rbStockAlmCoti.Text = "Cotizacion"
        '
        'rbStockAlmPrin
        '
        Me.rbStockAlmPrin.Location = New System.Drawing.Point(6, 41)
        Me.rbStockAlmPrin.Name = "rbStockAlmPrin"
        Me.rbStockAlmPrin.Size = New System.Drawing.Size(104, 23)
        Me.rbStockAlmPrin.TabIndex = 0
        Me.rbStockAlmPrin.Text = "Principal"
        '
        'UiRadioButton5
        '
        Me.UiRadioButton5.Location = New System.Drawing.Point(12, 40)
        Me.UiRadioButton5.Name = "UiRadioButton5"
        Me.UiRadioButton5.Size = New System.Drawing.Size(104, 23)
        Me.UiRadioButton5.TabIndex = 1
        Me.UiRadioButton5.Text = "UiRadioButton2"
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(-60, 75)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(116, 17)
        Me.CheckBox3.TabIndex = 5
        Me.CheckBox3.Text = "Mostrar Descuento"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'UiRadioButton6
        '
        Me.UiRadioButton6.Location = New System.Drawing.Point(12, 19)
        Me.UiRadioButton6.Name = "UiRadioButton6"
        Me.UiRadioButton6.Size = New System.Drawing.Size(104, 23)
        Me.UiRadioButton6.TabIndex = 0
        Me.UiRadioButton6.Text = "UiRadioButton1"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(12, 105)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Cancelar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(-74, 105)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 3
        Me.Button6.Text = "Aceptar"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btnEnviarCorreo
        '
        Me.btnEnviarCorreo.Image = CType(resources.GetObject("btnEnviarCorreo.Image"), System.Drawing.Image)
        Me.btnEnviarCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviarCorreo.Location = New System.Drawing.Point(180, 164)
        Me.btnEnviarCorreo.Name = "btnEnviarCorreo"
        Me.btnEnviarCorreo.Size = New System.Drawing.Size(105, 23)
        Me.btnEnviarCorreo.TabIndex = 5
        Me.btnEnviarCorreo.Text = "Enviar  x Correo"
        Me.btnEnviarCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnviarCorreo.UseVisualStyleBackColor = True
        '
        'frmImprimirReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 199)
        Me.Controls.Add(Me.btnEnviarCorreo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbStock)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cbMostrarDscto)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.rbtnSinCodigo)
        Me.Controls.Add(Me.rbtnConCodigo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImprimirReporte"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir Reporte"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbStock.ResumeLayout(False)
        Me.gbStock.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtnConCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSinCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cbMostrarDscto As System.Windows.Forms.CheckBox
    Friend WithEvents gbStock As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbStockNinguno As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbStockAlmCoti As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbStockAlmPrin As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents UiRadioButton5 As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents UiRadioButton6 As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents UiRadioButton3 As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents UiRadioButton7 As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents UiRadioButton8 As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents UiRadioButton9 As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents UiRadioButton2 As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents UiRadioButton1 As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnEnviarCorreo As Button
End Class
