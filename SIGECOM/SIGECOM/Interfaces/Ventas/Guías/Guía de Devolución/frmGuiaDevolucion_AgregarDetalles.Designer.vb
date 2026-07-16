<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaDevolucion_AgregarDetalles
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
        Dim cmbIdClienteSold_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaDevolucion_AgregarDetalles))
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAgregarDetalles = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.cmbIdClienteSold = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator101 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAgregarDetalles = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator102 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator103 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator104 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.cmbIdClienteSold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAgregarDetalles, Me.ToolStripMenuItem1, Me.miActualizar, Me.ToolStripSeparator1, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(161, 82)
        '
        'miAgregarDetalles
        '
        Me.miAgregarDetalles.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.miAgregarDetalles.Name = "miAgregarDetalles"
        Me.miAgregarDetalles.Size = New System.Drawing.Size(160, 22)
        Me.miAgregarDetalles.Text = "Agregar Detalles"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(157, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(160, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(157, 6)
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(160, 22)
        Me.miSalir.Text = "Salir"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(150, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(450, 15)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 314)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(690, 20)
        Me.ssBarra.TabIndex = 2
        '
        'cmbIdClienteSold
        '
        Me.cmbIdClienteSold.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdClienteSold_DesignTimeLayout.LayoutString = resources.GetString("cmbIdClienteSold_DesignTimeLayout.LayoutString")
        Me.cmbIdClienteSold.DesignTimeLayout = cmbIdClienteSold_DesignTimeLayout
        Me.cmbIdClienteSold.Location = New System.Drawing.Point(5, 30)
        Me.cmbIdClienteSold.Name = "cmbIdClienteSold"
        Me.cmbIdClienteSold.SelectedIndex = -1
        Me.cmbIdClienteSold.SelectedItem = Nothing
        Me.cmbIdClienteSold.Size = New System.Drawing.Size(216, 20)
        Me.cmbIdClienteSold.TabIndex = 21
        Me.cmbIdClienteSold.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(0, 31)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(690, 303)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator101, Me.biAgregarDetalles, Me.ToolStripSeparator102, Me.biActualizar, Me.ToolStripSeparator103, Me.biSalir, Me.ToolStripSeparator104})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(690, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator101
        '
        Me.ToolStripSeparator101.Name = "ToolStripSeparator101"
        Me.ToolStripSeparator101.Size = New System.Drawing.Size(6, 31)
        '
        'biAgregarDetalles
        '
        Me.biAgregarDetalles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAgregarDetalles.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.biAgregarDetalles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAgregarDetalles.Name = "biAgregarDetalles"
        Me.biAgregarDetalles.Size = New System.Drawing.Size(28, 28)
        Me.biAgregarDetalles.Text = "Agregar Detalles"
        '
        'ToolStripSeparator102
        '
        Me.ToolStripSeparator102.Name = "ToolStripSeparator102"
        Me.ToolStripSeparator102.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator103
        '
        Me.ToolStripSeparator103.Name = "ToolStripSeparator103"
        Me.ToolStripSeparator103.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Salir"
        '
        'ToolStripSeparator104
        '
        Me.ToolStripSeparator104.Name = "ToolStripSeparator104"
        Me.ToolStripSeparator104.Size = New System.Drawing.Size(6, 31)
        '
        'frmGuiaDevolucion_AgregarDetalles
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(690, 334)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaDevolucion_AgregarDetalles"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Lista de detalles"
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.cmbIdClienteSold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
  Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
  Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents cmbIdClienteSold As Janus.Windows.GridEX.EditControls.MultiColumnCombo
  Friend WithEvents miAgregarDetalles As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
  Friend WithEvents biAgregarDetalles As System.Windows.Forms.ToolStripButton
  Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator101 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator102 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator103 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator104 As System.Windows.Forms.ToolStripSeparator

End Class
