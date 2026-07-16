<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoleta_BoletaElectronica_ObsSunat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBoleta_BoletaElectronica_ObsSunat))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biDescargar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.txtNotas = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTicket = New System.Windows.Forms.TextBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biDescargar, Me.ToolStripSeparator2, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(558, 31)
        Me.ToolStrip.TabIndex = 12
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biDescargar
        '
        Me.biDescargar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDescargar.Image = Global.SIGECOM.My.Resources.Resources.bajar_estado
        Me.biDescargar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDescargar.Name = "biDescargar"
        Me.biDescargar.Size = New System.Drawing.Size(28, 28)
        Me.biDescargar.Text = "Descargar"
        Me.biDescargar.ToolTipText = "Descargar"
        Me.biDescargar.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator2.Visible = False
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'txtNotas
        '
        Me.txtNotas.BackColor = System.Drawing.SystemColors.Window
        Me.txtNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotas.Location = New System.Drawing.Point(95, 147)
        Me.txtNotas.Multiline = True
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.ReadOnly = True
        Me.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotas.Size = New System.Drawing.Size(412, 55)
        Me.txtNotas.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(43, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Notas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Observacion"
        '
        'txtObservacion
        '
        Me.txtObservacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(95, 88)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(412, 44)
        Me.txtObservacion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Estado"
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.SystemColors.Window
        Me.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEstado.Location = New System.Drawing.Point(95, 55)
        Me.txtEstado.MaxLength = 3
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(142, 20)
        Me.txtEstado.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Ticket"
        '
        'txtTicket
        '
        Me.txtTicket.BackColor = System.Drawing.SystemColors.Window
        Me.txtTicket.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTicket.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTicket.Location = New System.Drawing.Point(95, 23)
        Me.txtTicket.MaxLength = 3
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.ReadOnly = True
        Me.txtTicket.Size = New System.Drawing.Size(142, 20)
        Me.txtTicket.TabIndex = 1
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtNotas)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtTicket)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtEstado)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 31)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(519, 216)
        Me.UiGroupBox1.TabIndex = 130
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmBoleta_BoletaElectronica_ObsSunat
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(558, 275)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBoleta_BoletaElectronica_ObsSunat"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Observaciones Sunat"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biDescargar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTicket As System.Windows.Forms.TextBox
    Friend WithEvents txtNotas As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
End Class
