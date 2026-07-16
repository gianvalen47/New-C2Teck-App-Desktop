<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCotizacion_EnviarCorreo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCotizacion_EnviarCorreo))
        Dim dgvArchivosDirectorio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbProcesoJob = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtcc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnEnviarCorreo = New System.Windows.Forms.Button()
        Me.dgvArchivosDirectorio = New Janus.Windows.GridEX.GridEX()
        Me.txtDe = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPara = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProcesoJob.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgvArchivosDirectorio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 31)
        Me.ToolStrip1.TabIndex = 21
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
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbProcesoJob
        '
        Me.gbProcesoJob.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbProcesoJob.Controls.Add(Me.txtcc)
        Me.gbProcesoJob.Controls.Add(Me.Label5)
        Me.gbProcesoJob.Controls.Add(Me.UiGroupBox1)
        Me.gbProcesoJob.Controls.Add(Me.dgvArchivosDirectorio)
        Me.gbProcesoJob.Controls.Add(Me.txtDe)
        Me.gbProcesoJob.Controls.Add(Me.Label6)
        Me.gbProcesoJob.Controls.Add(Me.txtPara)
        Me.gbProcesoJob.Controls.Add(Me.Label1)
        Me.gbProcesoJob.Controls.Add(Me.txtAsunto)
        Me.gbProcesoJob.Controls.Add(Me.Label4)
        Me.gbProcesoJob.Controls.Add(Me.Label2)
        Me.gbProcesoJob.Controls.Add(Me.Label3)
        Me.gbProcesoJob.Controls.Add(Me.txtMensaje)
        Me.gbProcesoJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProcesoJob.Location = New System.Drawing.Point(12, 34)
        Me.gbProcesoJob.Name = "gbProcesoJob"
        Me.gbProcesoJob.Size = New System.Drawing.Size(744, 430)
        Me.gbProcesoJob.TabIndex = 114
        Me.gbProcesoJob.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtcc
        '
        Me.txtcc.Location = New System.Drawing.Point(86, 93)
        Me.txtcc.Name = "txtcc"
        Me.txtcc.Size = New System.Drawing.Size(261, 20)
        Me.txtcc.TabIndex = 2
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
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnEnviarCorreo)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(302, 331)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(140, 74)
        Me.UiGroupBox1.TabIndex = 113
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnEnviarCorreo
        '
        Me.btnEnviarCorreo.Image = CType(resources.GetObject("btnEnviarCorreo.Image"), System.Drawing.Image)
        Me.btnEnviarCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviarCorreo.Location = New System.Drawing.Point(15, 23)
        Me.btnEnviarCorreo.Name = "btnEnviarCorreo"
        Me.btnEnviarCorreo.Size = New System.Drawing.Size(110, 36)
        Me.btnEnviarCorreo.TabIndex = 5
        Me.btnEnviarCorreo.Text = "Enviar Correo"
        Me.btnEnviarCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnviarCorreo.UseVisualStyleBackColor = True
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
        Me.dgvArchivosDirectorio.Size = New System.Drawing.Size(402, 91)
        Me.dgvArchivosDirectorio.TabIndex = 32
        Me.dgvArchivosDirectorio.TabStop = False
        Me.dgvArchivosDirectorio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtDe
        '
        Me.txtDe.BackColor = System.Drawing.SystemColors.Control
        Me.txtDe.Location = New System.Drawing.Point(86, 28)
        Me.txtDe.Name = "txtDe"
        Me.txtDe.ReadOnly = True
        Me.txtDe.Size = New System.Drawing.Size(261, 20)
        Me.txtDe.TabIndex = 30
        Me.txtDe.TabStop = False
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
        'txtPara
        '
        Me.txtPara.Location = New System.Drawing.Point(86, 61)
        Me.txtPara.Name = "txtPara"
        Me.txtPara.Size = New System.Drawing.Size(261, 20)
        Me.txtPara.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Para"
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(86, 125)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(635, 20)
        Me.txtAsunto.TabIndex = 3
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Asunto"
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
        Me.txtMensaje.TabIndex = 4
        '
        'frmCotizacion_EnviarCorreo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(784, 486)
        Me.Controls.Add(Me.gbProcesoJob)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCotizacion_EnviarCorreo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cotización - Enviar Correo"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProcesoJob.ResumeLayout(False)
        Me.gbProcesoJob.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.dgvArchivosDirectorio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents biSalir As ToolStripButton
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbProcesoJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtcc As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnEnviarCorreo As Button
    Friend WithEvents dgvArchivosDirectorio As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtDe As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPara As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAsunto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMensaje As TextBox
End Class
