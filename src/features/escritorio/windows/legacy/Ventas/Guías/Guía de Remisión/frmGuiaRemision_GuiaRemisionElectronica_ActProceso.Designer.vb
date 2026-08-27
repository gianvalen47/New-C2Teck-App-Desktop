<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaRemision_GuiaRemisionElectronica_ActProceso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaRemision_GuiaRemisionElectronica_ActProceso))
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbNoCodigo = New System.Windows.Forms.CheckBox()
        Me.rbObservacion = New System.Windows.Forms.RadioButton()
        Me.cbMostrarMensaje = New System.Windows.Forms.CheckBox()
        Me.rbDetalle = New System.Windows.Forms.RadioButton()
        Me.rbResumen = New System.Windows.Forms.RadioButton()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridEX1
        '
        GridEX1_DesignTimeLayout.LayoutString = resources.GetString("GridEX1_DesignTimeLayout.LayoutString")
        Me.GridEX1.DesignTimeLayout = GridEX1_DesignTimeLayout
        Me.GridEX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridEX1.GroupByBoxVisible = False
        Me.GridEX1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.GridEX1.Location = New System.Drawing.Point(240, 105)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX1.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.GridEX1.Size = New System.Drawing.Size(41, 34)
        Me.GridEX1.TabIndex = 179
        Me.GridEX1.Visible = False
        Me.GridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(65, 112)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(163, 27)
        Me.btnAceptar.TabIndex = 175
        Me.btnAceptar.Text = "Actualizar Guia en Proceso"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbNoCodigo)
        Me.GroupBox1.Controls.Add(Me.rbObservacion)
        Me.GroupBox1.Controls.Add(Me.cbMostrarMensaje)
        Me.GroupBox1.Controls.Add(Me.rbDetalle)
        Me.GroupBox1.Controls.Add(Me.rbResumen)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 89)
        Me.GroupBox1.TabIndex = 174
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Impresión"
        '
        'cbNoCodigo
        '
        Me.cbNoCodigo.AutoSize = True
        Me.cbNoCodigo.Location = New System.Drawing.Point(146, 18)
        Me.cbNoCodigo.Name = "cbNoCodigo"
        Me.cbNoCodigo.Size = New System.Drawing.Size(114, 17)
        Me.cbNoCodigo.TabIndex = 175
        Me.cbNoCodigo.Text = "No Mostrar Codigo"
        Me.cbNoCodigo.UseVisualStyleBackColor = True
        '
        'rbObservacion
        '
        Me.rbObservacion.AutoSize = True
        Me.rbObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbObservacion.Location = New System.Drawing.Point(15, 61)
        Me.rbObservacion.Name = "rbObservacion"
        Me.rbObservacion.Size = New System.Drawing.Size(126, 17)
        Me.rbObservacion.TabIndex = 174
        Me.rbObservacion.Text = "Generar Observación"
        Me.rbObservacion.UseVisualStyleBackColor = True
        '
        'cbMostrarMensaje
        '
        Me.cbMostrarMensaje.AutoSize = True
        Me.cbMostrarMensaje.Checked = True
        Me.cbMostrarMensaje.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMostrarMensaje.Location = New System.Drawing.Point(146, 41)
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
        Me.rbDetalle.Size = New System.Drawing.Size(99, 17)
        Me.rbDetalle.TabIndex = 2
        Me.rbDetalle.TabStop = True
        Me.rbDetalle.Text = "Generar Detalle"
        Me.rbDetalle.UseVisualStyleBackColor = True
        '
        'rbResumen
        '
        Me.rbResumen.AutoSize = True
        Me.rbResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbResumen.Location = New System.Drawing.Point(15, 40)
        Me.rbResumen.Name = "rbResumen"
        Me.rbResumen.Size = New System.Drawing.Size(111, 17)
        Me.rbResumen.TabIndex = 3
        Me.rbResumen.Text = "Generar Resumen"
        Me.rbResumen.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmGuiaRemision_GuiaRemisionElectronica_ActProceso
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(295, 151)
        Me.Controls.Add(Me.GridEX1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaRemision_GuiaRemisionElectronica_ActProceso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GRE - Actualizar Guia en Proceso"
        CType(Me.GridEX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnAceptar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbNoCodigo As CheckBox
    Friend WithEvents rbObservacion As RadioButton
    Friend WithEvents cbMostrarMensaje As CheckBox
    Friend WithEvents rbDetalle As RadioButton
    Friend WithEvents rbResumen As RadioButton
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
