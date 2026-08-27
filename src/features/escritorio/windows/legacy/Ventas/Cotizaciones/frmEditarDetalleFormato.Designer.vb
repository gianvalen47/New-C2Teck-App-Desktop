<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarDetalleFormato
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarDetalleFormato))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biColorFuente = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biFuente = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biVinetas = New System.Windows.Forms.ToolStripButton()
        Me.biNegrita = New System.Windows.Forms.ToolStripButton()
        Me.biSubrayado = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbVineta = New System.Windows.Forms.CheckBox()
        Me.txtObsDet = New System.Windows.Forms.RichTextBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator14, Me.btnGuardar, Me.ToolStripSeparator4, Me.biColorFuente, Me.ToolStripSeparator5, Me.biFuente, Me.ToolStripSeparator2, Me.biVinetas, Me.biNegrita, Me.biSubrayado, Me.btnCancelar})
        Me.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(638, 31)
        Me.ToolStrip.TabIndex = 18
        Me.ToolStrip.Text = "Actualiza"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biColorFuente
        '
        Me.biColorFuente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biColorFuente.Image = CType(resources.GetObject("biColorFuente.Image"), System.Drawing.Image)
        Me.biColorFuente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biColorFuente.Name = "biColorFuente"
        Me.biColorFuente.Size = New System.Drawing.Size(28, 28)
        Me.biColorFuente.Text = "Color Fuente"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biFuente
        '
        Me.biFuente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biFuente.Image = CType(resources.GetObject("biFuente.Image"), System.Drawing.Image)
        Me.biFuente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biFuente.Name = "biFuente"
        Me.biFuente.Size = New System.Drawing.Size(28, 28)
        Me.biFuente.Text = "Fuente"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biVinetas
        '
        Me.biVinetas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biVinetas.Image = CType(resources.GetObject("biVinetas.Image"), System.Drawing.Image)
        Me.biVinetas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biVinetas.Name = "biVinetas"
        Me.biVinetas.Size = New System.Drawing.Size(28, 28)
        Me.biVinetas.Text = "Generar G/F/B/O.C."
        Me.biVinetas.Visible = False
        '
        'biNegrita
        '
        Me.biNegrita.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNegrita.Image = CType(resources.GetObject("biNegrita.Image"), System.Drawing.Image)
        Me.biNegrita.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNegrita.Name = "biNegrita"
        Me.biNegrita.Size = New System.Drawing.Size(28, 28)
        Me.biNegrita.Text = "Generar G/F/B/O.C."
        Me.biNegrita.Visible = False
        '
        'biSubrayado
        '
        Me.biSubrayado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSubrayado.Image = CType(resources.GetObject("biSubrayado.Image"), System.Drawing.Image)
        Me.biSubrayado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSubrayado.Name = "biSubrayado"
        Me.biSubrayado.Size = New System.Drawing.Size(28, 28)
        Me.biSubrayado.Text = "Generar G/F/B/O.C."
        Me.biSubrayado.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(28, 28)
        Me.btnCancelar.Text = "Cerrar el Formulario"
        Me.btnCancelar.Visible = False
        '
        'FontDialog1
        '
        Me.FontDialog1.Color = System.Drawing.SystemColors.ControlText
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(16, 40)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(47, 13)
        Me.Label21.TabIndex = 25
        Me.Label21.Text = "Detalle"
        '
        'cbVineta
        '
        Me.cbVineta.AutoSize = True
        Me.cbVineta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVineta.Location = New System.Drawing.Point(119, 7)
        Me.cbVineta.Name = "cbVineta"
        Me.cbVineta.Size = New System.Drawing.Size(62, 17)
        Me.cbVineta.TabIndex = 24
        Me.cbVineta.Text = "Viñeta"
        Me.cbVineta.UseVisualStyleBackColor = True
        Me.cbVineta.Visible = False
        '
        'txtObsDet
        '
        Me.txtObsDet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObsDet.Location = New System.Drawing.Point(6, 56)
        Me.txtObsDet.Name = "txtObsDet"
        Me.txtObsDet.Size = New System.Drawing.Size(626, 304)
        Me.txtObsDet.TabIndex = 23
        Me.txtObsDet.Text = ""
        '
        'frmEditarDetalleFormato
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(638, 367)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cbVineta)
        Me.Controls.Add(Me.txtObsDet)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditarDetalleFormato"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Observación del Detalle"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biColorFuente As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biFuente As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biVinetas As System.Windows.Forms.ToolStripButton
    Friend WithEvents biNegrita As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSubrayado As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbVineta As System.Windows.Forms.CheckBox
    Friend WithEvents txtObsDet As System.Windows.Forms.RichTextBox
End Class
