<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactura_FacturaElectronica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFactura_FacturaElectronica))
        Dim dgvArchivosDirectorio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.GridEX1 = New Janus.Windows.GridEX.GridEX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPara = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.btnVerFactura = New System.Windows.Forms.Button()
        Me.btnEnviarCorreo = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDe = New System.Windows.Forms.TextBox()
        Me.gbProcesoJob = New Janus.Windows.EditControls.UIGroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtcc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvArchivosDirectorio = New Janus.Windows.GridEX.GridEX()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.GridEX1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip1.SuspendLayout
        CType(Me.gbProcesoJob,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbProcesoJob.SuspendLayout
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiGroupBox2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.UiGroupBox2.SuspendLayout
        CType(Me.UiGroupBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.UiGroupBox1.SuspendLayout
        CType(Me.dgvArchivosDirectorio,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.OfficeFormAdorner1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'GridEX1
        '
        GridEX1_DesignTimeLayout.LayoutString = resources.GetString("GridEX1_DesignTimeLayout.LayoutString")
        Me.GridEX1.DesignTimeLayout = GridEX1_DesignTimeLayout
        Me.GridEX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridEX1.GroupByBoxVisible = false
        Me.GridEX1.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.GridEX1.Location = New System.Drawing.Point(385, 26)
        Me.GridEX1.Name = "GridEX1"
        Me.GridEX1.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX1.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.GridEX1.Size = New System.Drawing.Size(336, 83)
        Me.GridEX1.TabIndex = 16
        Me.GridEX1.Visible = false
        Me.GridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(43, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Para"
        '
        'txtPara
        '
        Me.txtPara.Location = New System.Drawing.Point(86, 61)
        Me.txtPara.Name = "txtPara"
        Me.txtPara.Size = New System.Drawing.Size(261, 20)
        Me.txtPara.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(805, 31)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Asunto"
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(86, 125)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(635, 20)
        Me.txtAsunto.TabIndex = 4
        '
        'btnVerFactura
        '
        Me.btnVerFactura.Image = CType(resources.GetObject("btnVerFactura.Image"), System.Drawing.Image)
        Me.btnVerFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerFactura.Location = New System.Drawing.Point(16, 21)
        Me.btnVerFactura.Name = "btnVerFactura"
        Me.btnVerFactura.Size = New System.Drawing.Size(100, 36)
        Me.btnVerFactura.TabIndex = 7
        Me.btnVerFactura.Text = "Ver Factura"
        Me.btnVerFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerFactura.UseVisualStyleBackColor = True
        '
        'btnEnviarCorreo
        '
        Me.btnEnviarCorreo.Image = CType(resources.GetObject("btnEnviarCorreo.Image"), System.Drawing.Image)
        Me.btnEnviarCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviarCorreo.Location = New System.Drawing.Point(9, 21)
        Me.btnEnviarCorreo.Name = "btnEnviarCorreo"
        Me.btnEnviarCorreo.Size = New System.Drawing.Size(110, 36)
        Me.btnEnviarCorreo.TabIndex = 6
        Me.btnEnviarCorreo.Text = "Enviar Correo"
        Me.btnEnviarCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnviarCorreo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Mensaje"
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(86, 157)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(635, 47)
        Me.txtMensaje.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 242)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Adjuntos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(53, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "De"
        '
        'txtDe
        '
        Me.txtDe.BackColor = System.Drawing.SystemColors.Control
        Me.txtDe.Location = New System.Drawing.Point(86, 28)
        Me.txtDe.Name = "txtDe"
        Me.txtDe.ReadOnly = True
        Me.txtDe.Size = New System.Drawing.Size(261, 20)
        Me.txtDe.TabIndex = 1
        '
        'gbProcesoJob
        '
        Me.gbProcesoJob.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbProcesoJob.Controls.Add(Me.DataGridView1)
        Me.gbProcesoJob.Controls.Add(Me.txtcc)
        Me.gbProcesoJob.Controls.Add(Me.Label5)
        Me.gbProcesoJob.Controls.Add(Me.UiGroupBox2)
        Me.gbProcesoJob.Controls.Add(Me.UiGroupBox1)
        Me.gbProcesoJob.Controls.Add(Me.dgvArchivosDirectorio)
        Me.gbProcesoJob.Controls.Add(Me.txtDe)
        Me.gbProcesoJob.Controls.Add(Me.Label6)
        Me.gbProcesoJob.Controls.Add(Me.GridEX1)
        Me.gbProcesoJob.Controls.Add(Me.txtPara)
        Me.gbProcesoJob.Controls.Add(Me.Label1)
        Me.gbProcesoJob.Controls.Add(Me.txtAsunto)
        Me.gbProcesoJob.Controls.Add(Me.Label4)
        Me.gbProcesoJob.Controls.Add(Me.Label2)
        Me.gbProcesoJob.Controls.Add(Me.Label3)
        Me.gbProcesoJob.Controls.Add(Me.txtMensaje)
        Me.gbProcesoJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProcesoJob.Location = New System.Drawing.Point(12, 33)
        Me.gbProcesoJob.Name = "gbProcesoJob"
        Me.gbProcesoJob.Size = New System.Drawing.Size(757, 461)
        Me.gbProcesoJob.TabIndex = 112
        Me.gbProcesoJob.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(518, 239)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(203, 150)
        Me.DataGridView1.TabIndex = 117
        Me.DataGridView1.Visible = False
        '
        'txtcc
        '
        Me.txtcc.Location = New System.Drawing.Point(86, 93)
        Me.txtcc.Name = "txtcc"
        Me.txtcc.Size = New System.Drawing.Size(261, 20)
        Me.txtcc.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "Cc."
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.btnVerFactura)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(247, 317)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(130, 74)
        Me.UiGroupBox2.TabIndex = 114
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnEnviarCorreo)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(385, 317)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(130, 74)
        Me.UiGroupBox1.TabIndex = 113
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvArchivosDirectorio
        '
        Me.dgvArchivosDirectorio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvArchivosDirectorio_DesignTimeLayout.LayoutString = resources.GetString("dgvArchivosDirectorio_DesignTimeLayout.LayoutString")
        Me.dgvArchivosDirectorio.DesignTimeLayout = dgvArchivosDirectorio_DesignTimeLayout
        Me.dgvArchivosDirectorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvArchivosDirectorio.GroupByBoxVisible = False
        Me.dgvArchivosDirectorio.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvArchivosDirectorio.Location = New System.Drawing.Point(86, 218)
        Me.dgvArchivosDirectorio.Name = "dgvArchivosDirectorio"
        Me.dgvArchivosDirectorio.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvArchivosDirectorio.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvArchivosDirectorio.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvArchivosDirectorio.Size = New System.Drawing.Size(423, 91)
        Me.dgvArchivosDirectorio.TabIndex = 32
        Me.dgvArchivosDirectorio.TabStop = False
        Me.dgvArchivosDirectorio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmFactura_FacturaElectronica
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(805, 521)
        Me.Controls.Add(Me.gbProcesoJob)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmFactura_FacturaElectronica"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Factura Electronica"
        CType(Me.GridEX1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        CType(Me.gbProcesoJob,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbProcesoJob.ResumeLayout(false)
        Me.gbProcesoJob.PerformLayout
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiGroupBox2,System.ComponentModel.ISupportInitialize).EndInit
        Me.UiGroupBox2.ResumeLayout(false)
        CType(Me.UiGroupBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.UiGroupBox1.ResumeLayout(false)
        CType(Me.dgvArchivosDirectorio,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.OfficeFormAdorner1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents GridEX1 As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPara As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents btnVerFactura As System.Windows.Forms.Button
    Friend WithEvents btnEnviarCorreo As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDe As System.Windows.Forms.TextBox
    Friend WithEvents gbProcesoJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvArchivosDirectorio As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtcc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
