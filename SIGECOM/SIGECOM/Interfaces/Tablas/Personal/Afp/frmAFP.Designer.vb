<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAFP
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
        Dim dgvDatosAFP_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAFP))
        Dim dgvDatosRubroDscto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.TabAfps = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvDatosAFP = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpcionesAfp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoAfp = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarAfp = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarAfp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarAfp = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtDesAfp = New System.Windows.Forms.Label()
        Me.lblIdAfp = New System.Windows.Forms.Label()
        Me.dgvDatosRubroDscto = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpcionesRubroDscto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoRubro = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarRubro = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarRubro = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarRubro = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabAfps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAfps.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        CType(Me.dgvDatosAFP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpcionesAfp.SuspendLayout()
        Me.UiTabPage2.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.dgvDatosRubroDscto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpcionesRubroDscto.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'TabAfps
        '
        Me.TabAfps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabAfps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabAfps.Location = New System.Drawing.Point(6, 12)
        Me.TabAfps.Name = "TabAfps"
        Me.TabAfps.Size = New System.Drawing.Size(612, 315)
        Me.TabAfps.TabIndex = 234
        Me.TabAfps.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage2})
        Me.TabAfps.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabPage1.Controls.Add(Me.dgvDatosAFP)
        Me.UiTabPage1.Icon = CType(resources.GetObject("UiTabPage1.Icon"), System.Drawing.Icon)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(610, 291)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "[F2]  AFPs"
        '
        'dgvDatosAFP
        '
        Me.dgvDatosAFP.AllowCardSizing = False
        Me.dgvDatosAFP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatosAFP.ContextMenuStrip = Me.cmbOpcionesAfp
        dgvDatosAFP_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosAFP_DesignTimeLayout.LayoutString")
        Me.dgvDatosAFP.DesignTimeLayout = dgvDatosAFP_DesignTimeLayout
        Me.dgvDatosAFP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosAFP.GroupByBoxVisible = False
        Me.dgvDatosAFP.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatosAFP.Location = New System.Drawing.Point(24, 25)
        Me.dgvDatosAFP.Name = "dgvDatosAFP"
        Me.dgvDatosAFP.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosAFP.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosAFP.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosAFP.Size = New System.Drawing.Size(562, 242)
        Me.dgvDatosAFP.TabIndex = 212
        Me.dgvDatosAFP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbOpcionesAfp
        '
        Me.cmbOpcionesAfp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoAfp, Me.miMostrarAfp, Me.miEliminarAfp, Me.ToolStripSeparator5, Me.ToolStripSeparator6, Me.miActualizarAfp})
        Me.cmbOpcionesAfp.Name = "ContextMenuStrip1"
        Me.cmbOpcionesAfp.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoAfp
        '
        Me.miNuevoAfp.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoAfp.Name = "miNuevoAfp"
        Me.miNuevoAfp.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoAfp.Text = "Nuevo"
        '
        'miMostrarAfp
        '
        Me.miMostrarAfp.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarAfp.Name = "miMostrarAfp"
        Me.miMostrarAfp.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarAfp.Text = "Mostrar"
        '
        'miEliminarAfp
        '
        Me.miEliminarAfp.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarAfp.Name = "miEliminarAfp"
        Me.miEliminarAfp.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarAfp.Text = "Eliminar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarAfp
        '
        Me.miActualizarAfp.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarAfp.Name = "miActualizarAfp"
        Me.miActualizarAfp.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarAfp.Text = "Actualizar"
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabPage2.Controls.Add(Me.UiGroupBox2)
        Me.UiTabPage2.Controls.Add(Me.dgvDatosRubroDscto)
        Me.UiTabPage2.Icon = CType(resources.GetObject("UiTabPage2.Icon"), System.Drawing.Icon)
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(610, 291)
        Me.UiTabPage2.TabStop = True
        Me.UiTabPage2.Text = "[F3]  RUBROS DESCUENTO"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.BorderColor = System.Drawing.SystemColors.Desktop
        Me.UiGroupBox2.Controls.Add(Me.txtDesAfp)
        Me.UiGroupBox2.Controls.Add(Me.lblIdAfp)
        Me.UiGroupBox2.Location = New System.Drawing.Point(31, 21)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(540, 36)
        Me.UiGroupBox2.TabIndex = 7
        Me.UiGroupBox2.Text = "Datos de AFP"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtDesAfp
        '
        Me.txtDesAfp.ForeColor = System.Drawing.Color.Navy
        Me.txtDesAfp.Location = New System.Drawing.Point(93, 16)
        Me.txtDesAfp.Name = "txtDesAfp"
        Me.txtDesAfp.Size = New System.Drawing.Size(413, 13)
        Me.txtDesAfp.TabIndex = 9
        Me.txtDesAfp.Text = "DesAfp"
        '
        'lblIdAfp
        '
        Me.lblIdAfp.ForeColor = System.Drawing.Color.Navy
        Me.lblIdAfp.Location = New System.Drawing.Point(17, 16)
        Me.lblIdAfp.Name = "lblIdAfp"
        Me.lblIdAfp.Size = New System.Drawing.Size(60, 13)
        Me.lblIdAfp.TabIndex = 8
        Me.lblIdAfp.Text = "IdAfp"
        Me.lblIdAfp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvDatosRubroDscto
        '
        Me.dgvDatosRubroDscto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatosRubroDscto.ContextMenuStrip = Me.cmbOpcionesRubroDscto
        dgvDatosRubroDscto_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosRubroDscto_DesignTimeLayout.LayoutString")
        Me.dgvDatosRubroDscto.DesignTimeLayout = dgvDatosRubroDscto_DesignTimeLayout
        Me.dgvDatosRubroDscto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosRubroDscto.GroupByBoxVisible = False
        Me.dgvDatosRubroDscto.Location = New System.Drawing.Point(31, 68)
        Me.dgvDatosRubroDscto.Name = "dgvDatosRubroDscto"
        Me.dgvDatosRubroDscto.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosRubroDscto.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosRubroDscto.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosRubroDscto.Size = New System.Drawing.Size(548, 194)
        Me.dgvDatosRubroDscto.TabIndex = 3
        Me.dgvDatosRubroDscto.TabStop = False
        Me.dgvDatosRubroDscto.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005
        '
        'cmbOpcionesRubroDscto
        '
        Me.cmbOpcionesRubroDscto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoRubro, Me.miMostrarRubro, Me.miEliminarRubro, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.miActualizarRubro})
        Me.cmbOpcionesRubroDscto.Name = "ContextMenuStrip1"
        Me.cmbOpcionesRubroDscto.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoRubro
        '
        Me.miNuevoRubro.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoRubro.Name = "miNuevoRubro"
        Me.miNuevoRubro.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoRubro.Text = "Nuevo"
        '
        'miMostrarRubro
        '
        Me.miMostrarRubro.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarRubro.Name = "miMostrarRubro"
        Me.miMostrarRubro.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarRubro.Text = "Mostrar"
        '
        'miEliminarRubro
        '
        Me.miEliminarRubro.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarRubro.Name = "miEliminarRubro"
        Me.miEliminarRubro.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarRubro.Text = "Eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarRubro
        '
        Me.miActualizarRubro.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarRubro.Name = "miActualizarRubro"
        Me.miActualizarRubro.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarRubro.Text = "Actualizar"
        '
        'frmAFP
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(651, 356)
        Me.Controls.Add(Me.TabAfps)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAFP"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AFP"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabAfps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAfps.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        CType(Me.dgvDatosAFP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpcionesAfp.ResumeLayout(False)
        Me.UiTabPage2.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.dgvDatosRubroDscto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpcionesRubroDscto.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents TabAfps As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvDatosAFP As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvDatosRubroDscto As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbOpcionesAfp As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoAfp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarAfp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarAfp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarAfp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtDesAfp As System.Windows.Forms.Label
    Friend WithEvents lblIdAfp As System.Windows.Forms.Label
    Friend WithEvents cmbOpcionesRubroDscto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoRubro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarRubro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarRubro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarRubro As System.Windows.Forms.ToolStripMenuItem
End Class
