<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactura_Imprimir
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
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.rbDetalle = New System.Windows.Forms.RadioButton
        Me.rbResumen = New System.Windows.Forms.RadioButton
        Me.cbMostrarMensaje = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.rbSoles = New System.Windows.Forms.RadioButton
        Me.rbDolares = New System.Windows.Forms.RadioButton
        Me.cbMostrarNroCuenta = New System.Windows.Forms.CheckBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'rbDetalle
        '
        Me.rbDetalle.AutoSize = True
        Me.rbDetalle.Checked = True
        Me.rbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDetalle.Location = New System.Drawing.Point(15, 19)
        Me.rbDetalle.Name = "rbDetalle"
        Me.rbDetalle.Size = New System.Drawing.Size(96, 17)
        Me.rbDetalle.TabIndex = 2
        Me.rbDetalle.TabStop = True
        Me.rbDetalle.Text = "Imprimir Detalle"
        Me.rbDetalle.UseVisualStyleBackColor = True
        '
        'rbResumen
        '
        Me.rbResumen.AutoSize = True
        Me.rbResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbResumen.Location = New System.Drawing.Point(15, 42)
        Me.rbResumen.Name = "rbResumen"
        Me.rbResumen.Size = New System.Drawing.Size(108, 17)
        Me.rbResumen.TabIndex = 3
        Me.rbResumen.Text = "Imprimir Resumen"
        Me.rbResumen.UseVisualStyleBackColor = True
        '
        'cbMostrarMensaje
        '
        Me.cbMostrarMensaje.AutoSize = True
        Me.cbMostrarMensaje.Checked = True
        Me.cbMostrarMensaje.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMostrarMensaje.Location = New System.Drawing.Point(183, 36)
        Me.cbMostrarMensaje.Name = "cbMostrarMensaje"
        Me.cbMostrarMensaje.Size = New System.Drawing.Size(108, 17)
        Me.cbMostrarMensaje.TabIndex = 4
        Me.cbMostrarMensaje.Text = "Mostrar Cta. Bco."
        Me.cbMostrarMensaje.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDetalle)
        Me.GroupBox1.Controls.Add(Me.rbResumen)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(149, 76)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Impresión"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbSoles)
        Me.UiGroupBox1.Controls.Add(Me.rbDolares)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(202, 75)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(89, 62)
        Me.UiGroupBox1.TabIndex = 7
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbSoles
        '
        Me.rbSoles.AutoSize = True
        Me.rbSoles.Checked = True
        Me.rbSoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSoles.Location = New System.Drawing.Point(10, 14)
        Me.rbSoles.Name = "rbSoles"
        Me.rbSoles.Size = New System.Drawing.Size(51, 17)
        Me.rbSoles.TabIndex = 1
        Me.rbSoles.TabStop = True
        Me.rbSoles.Text = "Soles"
        Me.rbSoles.UseVisualStyleBackColor = True
        '
        'rbDolares
        '
        Me.rbDolares.AutoSize = True
        Me.rbDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDolares.Location = New System.Drawing.Point(10, 37)
        Me.rbDolares.Name = "rbDolares"
        Me.rbDolares.Size = New System.Drawing.Size(61, 17)
        Me.rbDolares.TabIndex = 2
        Me.rbDolares.Text = "Dolares"
        Me.rbDolares.UseVisualStyleBackColor = True
        '
        'cbMostrarNroCuenta
        '
        Me.cbMostrarNroCuenta.AutoSize = True
        Me.cbMostrarNroCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMostrarNroCuenta.Location = New System.Drawing.Point(183, 60)
        Me.cbMostrarNroCuenta.Name = "cbMostrarNroCuenta"
        Me.cbMostrarNroCuenta.Size = New System.Drawing.Size(121, 17)
        Me.cbMostrarNroCuenta.TabIndex = 6
        Me.cbMostrarNroCuenta.Text = "Mostrar Nro. Cuenta"
        Me.cbMostrarNroCuenta.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(166, 148)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 154
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(87, 148)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(73, 27)
        Me.btnAceptar.TabIndex = 153
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmFactura_Imprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 187)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.cbMostrarNroCuenta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbMostrarMensaje)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFactura_Imprimir"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents rbResumen As System.Windows.Forms.RadioButton
    Friend WithEvents rbDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents cbMostrarMensaje As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbSoles As System.Windows.Forms.RadioButton
    Friend WithEvents rbDolares As System.Windows.Forms.RadioButton
    Friend WithEvents cbMostrarNroCuenta As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
