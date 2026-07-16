<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCondicionPagoV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCondicionPagoV))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtDiasPago = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtCodPag = New System.Windows.Forms.TextBox()
        Me.txtDescripción = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtAbreviatura = New System.Windows.Forms.TextBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biGuardar, Me.ToolStripSeparator5, Me.biEditar, Me.ToolStripSeparator6, Me.biDeshacer, Me.ToolStripSeparator8, Me.biCerrar, Me.ToolStripSeparator9})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(376, 31)
        Me.ToolStrip1.TabIndex = 344
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Datos"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtDiasPago)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.lblRazonSocial)
        Me.UiGroupBox2.Controls.Add(Me.Label21)
        Me.UiGroupBox2.Controls.Add(Me.txtCodPag)
        Me.UiGroupBox2.Controls.Add(Me.txtDescripción)
        Me.UiGroupBox2.Controls.Add(Me.lblNombre)
        Me.UiGroupBox2.Controls.Add(Me.txtAbreviatura)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(11, 34)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(351, 157)
        Me.UiGroupBox2.TabIndex = 345
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtDiasPago
        '
        Me.txtDiasPago.Location = New System.Drawing.Point(88, 118)
        Me.txtDiasPago.Maximum = 999
        Me.txtDiasPago.Name = "txtDiasPago"
        Me.txtDiasPago.Size = New System.Drawing.Size(49, 20)
        Me.txtDiasPago.TabIndex = 191
        Me.txtDiasPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDiasPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 192
        Me.Label8.Text = "Dias"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(19, 25)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(40, 13)
        Me.lblRazonSocial.TabIndex = 23
        Me.lblRazonSocial.Text = "Codigo"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(19, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Descripción"
        '
        'txtCodPag
        '
        Me.txtCodPag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodPag.Location = New System.Drawing.Point(88, 22)
        Me.txtCodPag.MaxLength = 300
        Me.txtCodPag.Name = "txtCodPag"
        Me.txtCodPag.Size = New System.Drawing.Size(73, 20)
        Me.txtCodPag.TabIndex = 3
        '
        'txtDescripción
        '
        Me.txtDescripción.Location = New System.Drawing.Point(88, 44)
        Me.txtDescripción.Multiline = True
        Me.txtDescripción.Name = "txtDescripción"
        Me.txtDescripción.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripción.Size = New System.Drawing.Size(242, 49)
        Me.txtDescripción.TabIndex = 19
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(19, 98)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(61, 13)
        Me.lblNombre.TabIndex = 40
        Me.lblNombre.Text = "Abreviatura"
        '
        'txtAbreviatura
        '
        Me.txtAbreviatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbreviatura.Location = New System.Drawing.Point(88, 95)
        Me.txtAbreviatura.MaxLength = 50
        Me.txtAbreviatura.Name = "txtAbreviatura"
        Me.txtAbreviatura.Size = New System.Drawing.Size(120, 20)
        Me.txtAbreviatura.TabIndex = 5
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmCondicionPagoV
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(376, 207)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(384, 241)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(384, 241)
        Me.Name = "frmCondicionPagoV"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Condicion Pago"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents biGuardar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents biEditar As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents biDeshacer As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents biCerrar As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtDiasPago As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents lblRazonSocial As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtCodPag As TextBox
    Friend WithEvents txtDescripción As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents txtAbreviatura As TextBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
