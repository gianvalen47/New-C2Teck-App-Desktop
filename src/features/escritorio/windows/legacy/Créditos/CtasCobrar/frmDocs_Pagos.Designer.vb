<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocs_Pagos
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocs_Pagos))
    Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
    Me.ssBarra = New System.Windows.Forms.StatusStrip
    Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
    Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
    Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
    Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStrip = New System.Windows.Forms.ToolStrip
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
    Me.biMostrar = New System.Windows.Forms.ToolStripButton
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
    Me.biActualizar = New System.Windows.Forms.ToolStripButton
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
    Me.biSalir = New System.Windows.Forms.ToolStripButton
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
    Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
    Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
    Me.dgvDatos = New Janus.Windows.GridEX.GridEX
    Me.ssBarra.SuspendLayout()
    Me.cmOpciones.SuspendLayout()
    Me.ToolStrip.SuspendLayout()
    CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ssBarra
    '
    Me.ssBarra.AutoSize = False
    Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
    Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
    Me.ssBarra.Location = New System.Drawing.Point(0, 396)
    Me.ssBarra.Name = "ssBarra"
    Me.ssBarra.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
    Me.ssBarra.Size = New System.Drawing.Size(792, 20)
    Me.ssBarra.TabIndex = 1
    '
    'sslError
    '
    Me.sslError.AutoSize = False
    Me.sslError.Name = "sslError"
    Me.sslError.Size = New System.Drawing.Size(500, 15)
    '
    'sslTotal
    '
    Me.sslTotal.AutoSize = False
    Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
    Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
    Me.sslTotal.Name = "sslTotal"
    Me.sslTotal.Size = New System.Drawing.Size(180, 15)
    Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'cmOpciones
    '
    Me.cmOpciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
    Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMostrar, Me.ToolStripMenuItem1, Me.miActualizar})
    Me.cmOpciones.Name = "cmOpciones"
    Me.cmOpciones.Size = New System.Drawing.Size(143, 54)
    '
    'miMostrar
    '
    Me.miMostrar.Image = CType(resources.GetObject("miMostrar.Image"), System.Drawing.Image)
    Me.miMostrar.Name = "miMostrar"
    Me.miMostrar.Size = New System.Drawing.Size(142, 22)
    Me.miMostrar.Text = "Mostrar"
    '
    'ToolStripMenuItem1
    '
    Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
    Me.ToolStripMenuItem1.Size = New System.Drawing.Size(139, 6)
    '
    'miActualizar
    '
    Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
    Me.miActualizar.Name = "miActualizar"
    Me.miActualizar.Size = New System.Drawing.Size(142, 22)
    Me.miActualizar.Text = "Actualizar"
    '
    'ToolStrip
    '
    Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
    Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biMostrar, Me.ToolStripSeparator1, Me.biActualizar, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator3})
    Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip.Name = "ToolStrip"
    Me.ToolStrip.Size = New System.Drawing.Size(792, 25)
    Me.ToolStrip.TabIndex = 0
    Me.ToolStrip.Text = "ToolStrip"
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
    '
    'biMostrar
    '
    Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.biMostrar.Image = CType(resources.GetObject("biMostrar.Image"), System.Drawing.Image)
    Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.biMostrar.Name = "biMostrar"
    Me.biMostrar.Size = New System.Drawing.Size(23, 22)
    Me.biMostrar.Text = "Mostrar los datos del registro seleccionado"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'biActualizar
    '
    Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.biActualizar.Image = CType(resources.GetObject("biActualizar.Image"), System.Drawing.Image)
    Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.biActualizar.Name = "biActualizar"
    Me.biActualizar.Size = New System.Drawing.Size(23, 22)
    Me.biActualizar.Text = "Actualizar Consulta"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'biSalir
    '
    Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.biSalir.Image = CType(resources.GetObject("biSalir.Image"), System.Drawing.Image)
    Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.biSalir.Name = "biSalir"
    Me.biSalir.Size = New System.Drawing.Size(23, 22)
    Me.biSalir.Text = "Cerrar la ventana actual"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
    '
    'ofEstiloForm
    '
    Me.ofEstiloForm.Form = Me
    Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
    '
    'UiGroupBox1
    '
    Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.UiGroupBox1.Location = New System.Drawing.Point(0, 25)
    Me.UiGroupBox1.Name = "UiGroupBox1"
    Me.UiGroupBox1.Size = New System.Drawing.Size(792, 100)
    Me.UiGroupBox1.TabIndex = 2
    Me.UiGroupBox1.Text = "UiGroupBox1"
    Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
    '
    'dgvDatos
    '
    Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
    dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
    Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
    Me.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dgvDatos.GroupByBoxVisible = False
    Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
    Me.dgvDatos.Location = New System.Drawing.Point(0, 125)
    Me.dgvDatos.Name = "dgvDatos"
    Me.dgvDatos.Size = New System.Drawing.Size(792, 271)
    Me.dgvDatos.TabIndex = 3
    Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'frmDocs_Pagos
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(792, 416)
    Me.Controls.Add(Me.dgvDatos)
    Me.Controls.Add(Me.UiGroupBox1)
    Me.Controls.Add(Me.ssBarra)
    Me.Controls.Add(Me.ToolStrip)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "frmDocs_Pagos"
    Me.Text = "frmDocs_Pagos"
    Me.ssBarra.ResumeLayout(False)
    Me.ssBarra.PerformLayout()
    Me.cmOpciones.ResumeLayout(False)
    Me.ToolStrip.ResumeLayout(False)
    Me.ToolStrip.PerformLayout()
    CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
  Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
  Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
  Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
  Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
End Class
