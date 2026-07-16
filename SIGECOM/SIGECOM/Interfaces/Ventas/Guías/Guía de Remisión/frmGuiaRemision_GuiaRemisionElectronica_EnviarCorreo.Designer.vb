<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaRemision_GuiaRemisionElectronica_EnviarCorreo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaRemision_GuiaRemisionElectronica_EnviarCorreo))
        Dim dgvArchivosDirectorio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.gbProcesoJob = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtcc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnVerGuiaRemision = New System.Windows.Forms.Button()
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
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProcesoJob.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgvArchivosDirectorio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbProcesoJob
        '
        Me.gbProcesoJob.Controls.Add(Me.txtcc)
        Me.gbProcesoJob.Controls.Add(Me.Label5)
        Me.gbProcesoJob.Controls.Add(Me.UiGroupBox2)
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
        Me.gbProcesoJob.Location = New System.Drawing.Point(12, 33)
        Me.gbProcesoJob.Name = "gbProcesoJob"
        Me.gbProcesoJob.Size = New System.Drawing.Size(739, 403)
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
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.btnVerGuiaRemision)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(247, 317)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(127, 72)
        Me.UiGroupBox2.TabIndex = 114
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnVerGuiaRemision
        '
        Me.btnVerGuiaRemision.Image = CType(resources.GetObject("btnVerGuiaRemision.Image"), System.Drawing.Image)
        Me.btnVerGuiaRemision.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerGuiaRemision.Location = New System.Drawing.Point(22, 21)
        Me.btnVerGuiaRemision.Name = "btnVerGuiaRemision"
        Me.btnVerGuiaRemision.Size = New System.Drawing.Size(84, 36)
        Me.btnVerGuiaRemision.TabIndex = 6
        Me.btnVerGuiaRemision.Text = "Ver Guia"
        Me.btnVerGuiaRemision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerGuiaRemision.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnEnviarCorreo)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(385, 317)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(127, 72)
        Me.UiGroupBox1.TabIndex = 113
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnEnviarCorreo
        '
        Me.btnEnviarCorreo.Image = CType(resources.GetObject("btnEnviarCorreo.Image"), System.Drawing.Image)
        Me.btnEnviarCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviarCorreo.Location = New System.Drawing.Point(9, 21)
        Me.btnEnviarCorreo.Name = "btnEnviarCorreo"
        Me.btnEnviarCorreo.Size = New System.Drawing.Size(110, 36)
        Me.btnEnviarCorreo.TabIndex = 5
        Me.btnEnviarCorreo.Text = "Enviar Correo"
        Me.btnEnviarCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnviarCorreo.UseVisualStyleBackColor = True
        '
        'dgvArchivosDirectorio
        '
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
        Me.dgvArchivosDirectorio.Size = New System.Drawing.Size(392, 93)
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
        Me.txtDe.TabIndex = 0
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
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(765, 31)
        Me.ToolStrip1.TabIndex = 115
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
        'frmGuiaRemision_GuiaRemisionElectronica_EnviarCorreo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(765, 450)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gbProcesoJob)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaRemision_GuiaRemisionElectronica_EnviarCorreo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guia Remision Electronica - Enviar Correo"
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProcesoJob.ResumeLayout(False)
        Me.gbProcesoJob.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.dgvArchivosDirectorio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbProcesoJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtcc As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnVerGuiaRemision As Button
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
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents biSalir As ToolStripButton
End Class
