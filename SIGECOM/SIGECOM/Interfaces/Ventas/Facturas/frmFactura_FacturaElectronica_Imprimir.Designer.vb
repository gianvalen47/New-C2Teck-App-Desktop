<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactura_FacturaElectronica_Imprimir
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridEX1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFactura_FacturaElectronica_Imprimir))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbDetalle = New System.Windows.Forms.RadioButton()
        Me.rbResumen = New System.Windows.Forms.RadioButton()
        Me.cbMostrarMensaje = New System.Windows.Forms.CheckBox()
        Me.btnPreImpresion = New System.Windows.Forms.Button()
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(246, 109)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(167, 109)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(73, 27)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDetalle)
        Me.GroupBox1.Controls.Add(Me.rbResumen)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(137, 71)
        Me.GroupBox1.TabIndex = 156
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Impresión"
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
        Me.cbMostrarMensaje.Location = New System.Drawing.Point(176, 35)
        Me.cbMostrarMensaje.Name = "cbMostrarMensaje"
        Me.cbMostrarMensaje.Size = New System.Drawing.Size(145, 17)
        Me.cbMostrarMensaje.TabIndex = 4
        Me.cbMostrarMensaje.Text = "Mostrar Cta. Bco. Nación"
        Me.cbMostrarMensaje.UseVisualStyleBackColor = True
        '
        'btnPreImpresion
        '
        Me.btnPreImpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreImpresion.Image = Global.SIGECOM.My.Resources.Resources.Lupa_
        Me.btnPreImpresion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreImpresion.Location = New System.Drawing.Point(24, 109)
        Me.btnPreImpresion.Name = "btnPreImpresion"
        Me.btnPreImpresion.Size = New System.Drawing.Size(99, 27)
        Me.btnPreImpresion.TabIndex = 5
        Me.btnPreImpresion.Text = "Pre Impresion"
        Me.btnPreImpresion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreImpresion.UseVisualStyleBackColor = True
        '
        'GridEX1
        '
        GridEX1_DesignTimeLayout.LayoutString = resources.GetString("GridEX1_DesignTimeLayout.LayoutString")
        Me.GridEX1.DesignTimeLayout = GridEX1_DesignTimeLayout
        Me.GridEX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridEX1.GroupByBoxVisible = False
        Me.GridEX1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.GridEX1.Location = New System.Drawing.Point(176, 62)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX1.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.GridEX1.Size = New System.Drawing.Size(45, 39)
        Me.GridEX1.TabIndex = 176
        Me.GridEX1.Visible = False
        Me.GridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmFactura_FacturaElectronica_Imprimir
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(340, 167)
        Me.Controls.Add(Me.GridEX1)
        Me.Controls.Add(Me.btnPreImpresion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbMostrarMensaje)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFactura_FacturaElectronica_Imprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents rbResumen As System.Windows.Forms.RadioButton
    Friend WithEvents cbMostrarMensaje As System.Windows.Forms.CheckBox
    Friend WithEvents btnPreImpresion As Button
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
End Class
