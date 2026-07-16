<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProvisional_Enviar
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
        Dim dgvCorreos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProvisional_Enviar))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.gbCorreos = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvCorreos = New Janus.Windows.GridEX.GridEX()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCorreos.SuspendLayout()
        CType(Me.dgvCorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnEnviar
        '
        Me.btnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.Image = Global.SIGECOM.My.Resources.Resources.Enviar_
        Me.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnviar.Location = New System.Drawing.Point(226, 185)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(67, 25)
        Me.btnEnviar.TabIndex = 193
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnSalir.Location = New System.Drawing.Point(299, 185)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 25)
        Me.btnSalir.TabIndex = 194
        Me.btnSalir.Text = "Cancelar"
        '
        'gbCorreos
        '
        Me.gbCorreos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCorreos.Controls.Add(Me.dgvCorreos)
        Me.gbCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCorreos.Location = New System.Drawing.Point(8, 12)
        Me.gbCorreos.Name = "gbCorreos"
        Me.gbCorreos.Size = New System.Drawing.Size(584, 175)
        Me.gbCorreos.TabIndex = 192
        Me.gbCorreos.Text = "Enviar Correos"
        Me.gbCorreos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvCorreos
        '
        dgvCorreos_DesignTimeLayout.LayoutString = resources.GetString("dgvCorreos_DesignTimeLayout.LayoutString")
        Me.dgvCorreos.DesignTimeLayout = dgvCorreos_DesignTimeLayout
        Me.dgvCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCorreos.GroupByBoxVisible = False
        Me.dgvCorreos.Location = New System.Drawing.Point(6, 18)
        Me.dgvCorreos.Name = "dgvCorreos"
        Me.dgvCorreos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCorreos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCorreos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCorreos.Size = New System.Drawing.Size(563, 142)
        Me.dgvCorreos.TabIndex = 187
        Me.dgvCorreos.TabStop = False
        Me.dgvCorreos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmProvisional_Enviar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(607, 229)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.gbCorreos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProvisional_Enviar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar Provisional para su aprobación"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCorreos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCorreos.ResumeLayout(False)
        CType(Me.dgvCorreos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents gbCorreos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvCorreos As Janus.Windows.GridEX.GridEX
End Class
