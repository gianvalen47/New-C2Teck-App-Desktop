<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobConsulta_MostrasGasto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobConsulta_MostrasGasto))
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.txtPrecioDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PrecioDol = New System.Windows.Forms.Label()
        Me.txtMontoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.MontoSol = New System.Windows.Forms.Label()
        Me.MontoDol = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 409)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(854, 20)
        Me.ssBarra.TabIndex = 111
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(550, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRubro.Location = New System.Drawing.Point(438, 53)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(54, 13)
        Me.lblRubro.TabIndex = 229
        Me.lblRubro.Text = "lblRubro"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(390, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "Rubro :"
        '
        'lblNumJob
        '
        Me.lblNumJob.AutoSize = True
        Me.lblNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumJob.Location = New System.Drawing.Point(212, 53)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(65, 13)
        Me.lblNumJob.TabIndex = 227
        Me.lblNumJob.Text = "lblNumJob"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(176, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "OT :"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(854, 31)
        Me.ToolStrip.TabIndex = 232
        Me.ToolStrip.Text = "ToolStrip"
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
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Location = New System.Drawing.Point(12, 84)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.Size = New System.Drawing.Size(834, 241)
        Me.dgvDatos.TabIndex = 233
        '
        'txtPrecioDol
        '
        Me.txtPrecioDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioDol.FormatString = "#0.00"
        Me.txtPrecioDol.Location = New System.Drawing.Point(499, 18)
        Me.txtPrecioDol.Name = "txtPrecioDol"
        Me.txtPrecioDol.ReadOnly = True
        Me.txtPrecioDol.Size = New System.Drawing.Size(105, 20)
        Me.txtPrecioDol.TabIndex = 269
        Me.txtPrecioDol.TabStop = False
        Me.txtPrecioDol.Text = "0.00"
        Me.txtPrecioDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'PrecioDol
        '
        Me.PrecioDol.AutoSize = True
        Me.PrecioDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioDol.Location = New System.Drawing.Point(357, 23)
        Me.PrecioDol.Name = "PrecioDol"
        Me.PrecioDol.Size = New System.Drawing.Size(45, 13)
        Me.PrecioDol.TabIndex = 268
        Me.PrecioDol.Text = "Label2"
        '
        'txtMontoSol
        '
        Me.txtMontoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSol.FormatString = "#0.00"
        Me.txtMontoSol.Location = New System.Drawing.Point(741, 44)
        Me.txtMontoSol.Name = "txtMontoSol"
        Me.txtMontoSol.ReadOnly = True
        Me.txtMontoSol.Size = New System.Drawing.Size(105, 20)
        Me.txtMontoSol.TabIndex = 267
        Me.txtMontoSol.TabStop = False
        Me.txtMontoSol.Text = "0.00"
        Me.txtMontoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtMontoDol
        '
        Me.txtMontoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoDol.FormatString = "#0.00"
        Me.txtMontoDol.Location = New System.Drawing.Point(741, 18)
        Me.txtMontoDol.Name = "txtMontoDol"
        Me.txtMontoDol.ReadOnly = True
        Me.txtMontoDol.Size = New System.Drawing.Size(105, 20)
        Me.txtMontoDol.TabIndex = 266
        Me.txtMontoDol.TabStop = False
        Me.txtMontoDol.Text = "0.00"
        Me.txtMontoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'MontoSol
        '
        Me.MontoSol.AutoSize = True
        Me.MontoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MontoSol.Location = New System.Drawing.Point(631, 47)
        Me.MontoSol.Name = "MontoSol"
        Me.MontoSol.Size = New System.Drawing.Size(45, 13)
        Me.MontoSol.TabIndex = 265
        Me.MontoSol.Text = "Label4"
        '
        'MontoDol
        '
        Me.MontoDol.AutoSize = True
        Me.MontoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MontoDol.Location = New System.Drawing.Point(631, 23)
        Me.MontoDol.Name = "MontoDol"
        Me.MontoDol.Size = New System.Drawing.Size(45, 13)
        Me.MontoDol.TabIndex = 264
        Me.MontoDol.Text = "Label2"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtMontoSol)
        Me.UiGroupBox1.Controls.Add(Me.txtPrecioDol)
        Me.UiGroupBox1.Controls.Add(Me.MontoDol)
        Me.UiGroupBox1.Controls.Add(Me.PrecioDol)
        Me.UiGroupBox1.Controls.Add(Me.MontoSol)
        Me.UiGroupBox1.Controls.Add(Me.txtMontoDol)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 330)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(854, 79)
        Me.UiGroupBox1.TabIndex = 317
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmJobConsulta_MostrasGasto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(854, 429)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.lblRubro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNumJob)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJobConsulta_MostrasGasto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Job Mostrar Gastos"
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRubro As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents txtPrecioDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PrecioDol As System.Windows.Forms.Label
    Friend WithEvents txtMontoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents MontoSol As System.Windows.Forms.Label
    Friend WithEvents MontoDol As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
End Class
