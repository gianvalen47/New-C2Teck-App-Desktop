<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaRemision_ElectronicaAnular_Imprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaRemision_ElectronicaAnular_Imprimir))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDarBaja = New System.Windows.Forms.GroupBox()
        Me.cbOpcion = New System.Windows.Forms.CheckBox()
        Me.txtNumGuia = New System.Windows.Forms.TextBox()
        Me.lblguia = New System.Windows.Forms.Label()
        Me.btnBuscarguia = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbMostrarMensaje = New System.Windows.Forms.CheckBox()
        Me.rbDetalle = New System.Windows.Forms.RadioButton()
        Me.rbResumen = New System.Windows.Forms.RadioButton()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDarBaja.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDarBaja
        '
        Me.gbDarBaja.Controls.Add(Me.cbOpcion)
        Me.gbDarBaja.Controls.Add(Me.txtNumGuia)
        Me.gbDarBaja.Controls.Add(Me.lblguia)
        Me.gbDarBaja.Controls.Add(Me.btnBuscarguia)
        Me.gbDarBaja.Location = New System.Drawing.Point(12, 12)
        Me.gbDarBaja.Name = "gbDarBaja"
        Me.gbDarBaja.Size = New System.Drawing.Size(269, 71)
        Me.gbDarBaja.TabIndex = 170
        Me.gbDarBaja.TabStop = False
        '
        'cbOpcion
        '
        Me.cbOpcion.AutoSize = True
        Me.cbOpcion.Location = New System.Drawing.Point(25, 16)
        Me.cbOpcion.Name = "cbOpcion"
        Me.cbOpcion.Size = New System.Drawing.Size(205, 17)
        Me.cbOpcion.TabIndex = 162
        Me.cbOpcion.Text = "¿Dara de baja una Guia preexistente?"
        Me.cbOpcion.UseVisualStyleBackColor = True
        '
        'txtNumGuia
        '
        Me.txtNumGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumGuia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNumGuia.Location = New System.Drawing.Point(104, 42)
        Me.txtNumGuia.MaxLength = 200
        Me.txtNumGuia.Name = "txtNumGuia"
        Me.txtNumGuia.ReadOnly = True
        Me.txtNumGuia.Size = New System.Drawing.Size(91, 20)
        Me.txtNumGuia.TabIndex = 164
        Me.txtNumGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblguia
        '
        Me.lblguia.AutoSize = True
        Me.lblguia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblguia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblguia.Location = New System.Drawing.Point(39, 45)
        Me.lblguia.Name = "lblguia"
        Me.lblguia.Size = New System.Drawing.Size(50, 13)
        Me.lblguia.TabIndex = 163
        Me.lblguia.Text = "Número :"
        '
        'btnBuscarguia
        '
        Me.btnBuscarguia.Image = CType(resources.GetObject("btnBuscarguia.Image"), System.Drawing.Image)
        Me.btnBuscarguia.Location = New System.Drawing.Point(196, 41)
        Me.btnBuscarguia.Name = "btnBuscarguia"
        Me.btnBuscarguia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarguia.TabIndex = 165
        Me.btnBuscarguia.TabStop = False
        Me.btnBuscarguia.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(152, 179)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 169
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(73, 179)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(73, 27)
        Me.btnAceptar.TabIndex = 168
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbMostrarMensaje)
        Me.GroupBox1.Controls.Add(Me.rbDetalle)
        Me.GroupBox1.Controls.Add(Me.rbResumen)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 71)
        Me.GroupBox1.TabIndex = 167
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Impresión"
        '
        'cbMostrarMensaje
        '
        Me.cbMostrarMensaje.AutoSize = True
        Me.cbMostrarMensaje.Checked = True
        Me.cbMostrarMensaje.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMostrarMensaje.Location = New System.Drawing.Point(158, 20)
        Me.cbMostrarMensaje.Name = "cbMostrarMensaje"
        Me.cbMostrarMensaje.Size = New System.Drawing.Size(94, 17)
        Me.cbMostrarMensaje.TabIndex = 157
        Me.cbMostrarMensaje.Text = "Mostrar Precio"
        Me.cbMostrarMensaje.UseVisualStyleBackColor = True
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
        'frmGuiaRemision_ElectronicaAnular_Imprimir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 225)
        Me.Controls.Add(Me.gbDarBaja)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaRemision_ElectronicaAnular_Imprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDarBaja.ResumeLayout(False)
        Me.gbDarBaja.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDarBaja As GroupBox
    Friend WithEvents cbOpcion As CheckBox
    Friend WithEvents txtNumGuia As TextBox
    Friend WithEvents lblguia As Label
    Friend WithEvents btnBuscarguia As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbMostrarMensaje As CheckBox
    Friend WithEvents rbDetalle As RadioButton
    Friend WithEvents rbResumen As RadioButton
End Class
