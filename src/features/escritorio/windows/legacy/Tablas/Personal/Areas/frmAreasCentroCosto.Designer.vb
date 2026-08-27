<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAreasCentroCosto
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
        Dim dgvUnidadNegocio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAreasCentroCosto))
        Dim dgvAreas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.TabCuentas = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabPage3 = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvUnidadNegocio = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpcionesArea = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblDesUnidad = New System.Windows.Forms.Label()
        Me.lblIdUnidad = New System.Windows.Forms.Label()
        Me.dgvAreas = New Janus.Windows.GridEX.GridEX()
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage()
        Me.gbDatosArea = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblDesArea = New System.Windows.Forms.Label()
        Me.lblCodArea = New System.Windows.Forms.Label()
        Me.dgvCentroCosto = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpcionesCentroCosto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.TabCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCuentas.SuspendLayout()
        Me.UiTabPage3.SuspendLayout()
        CType(Me.dgvUnidadNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpcionesArea.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgvAreas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage2.SuspendLayout()
        CType(Me.gbDatosArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosArea.SuspendLayout()
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpcionesCentroCosto.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabCuentas
        '
        Me.TabCuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabCuentas.Location = New System.Drawing.Point(7, 35)
        Me.TabCuentas.Name = "TabCuentas"
        Me.TabCuentas.Size = New System.Drawing.Size(524, 298)
        Me.TabCuentas.TabIndex = 1
        Me.TabCuentas.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage3, Me.UiTabPage1, Me.UiTabPage2})
        Me.TabCuentas.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabPage3
        '
        Me.UiTabPage3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabPage3.Controls.Add(Me.dgvUnidadNegocio)
        Me.UiTabPage3.Icon = CType(resources.GetObject("UiTabPage3.Icon"), System.Drawing.Icon)
        Me.UiTabPage3.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage3.Name = "UiTabPage3"
        Me.UiTabPage3.Size = New System.Drawing.Size(522, 274)
        Me.UiTabPage3.TabStop = True
        Me.UiTabPage3.Text = "[F2] UNIDADES DE NEGOCIO"
        '
        'dgvUnidadNegocio
        '
        Me.dgvUnidadNegocio.ContextMenuStrip = Me.cmbOpcionesArea
        dgvUnidadNegocio_DesignTimeLayout.LayoutString = resources.GetString("dgvUnidadNegocio_DesignTimeLayout.LayoutString")
        Me.dgvUnidadNegocio.DesignTimeLayout = dgvUnidadNegocio_DesignTimeLayout
        Me.dgvUnidadNegocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvUnidadNegocio.GroupByBoxVisible = False
        Me.dgvUnidadNegocio.Location = New System.Drawing.Point(16, 15)
        Me.dgvUnidadNegocio.Name = "dgvUnidadNegocio"
        Me.dgvUnidadNegocio.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvUnidadNegocio.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvUnidadNegocio.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvUnidadNegocio.Size = New System.Drawing.Size(482, 236)
        Me.dgvUnidadNegocio.TabIndex = 4
        Me.dgvUnidadNegocio.TabStop = False
        Me.dgvUnidadNegocio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbOpcionesArea
        '
        Me.cmbOpcionesArea.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoArea, Me.miMostrarArea, Me.miEliminarArea, Me.ToolStripSeparator5, Me.ToolStripSeparator6, Me.miActualizarArea})
        Me.cmbOpcionesArea.Name = "ContextMenuStrip1"
        Me.cmbOpcionesArea.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoArea
        '
        Me.miNuevoArea.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoArea.Name = "miNuevoArea"
        Me.miNuevoArea.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoArea.Text = "Nuevo"
        '
        'miMostrarArea
        '
        Me.miMostrarArea.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarArea.Name = "miMostrarArea"
        Me.miMostrarArea.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarArea.Text = "Mostrar"
        '
        'miEliminarArea
        '
        Me.miEliminarArea.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarArea.Name = "miEliminarArea"
        Me.miEliminarArea.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarArea.Text = "Eliminar"
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
        'miActualizarArea
        '
        Me.miActualizarArea.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarArea.Name = "miActualizarArea"
        Me.miActualizarArea.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarArea.Text = "Actualizar"
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabPage1.Controls.Add(Me.UiGroupBox1)
        Me.UiTabPage1.Controls.Add(Me.dgvAreas)
        Me.UiTabPage1.Icon = CType(resources.GetObject("UiTabPage1.Icon"), System.Drawing.Icon)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(522, 274)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "[F3] AREA"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.lblDesUnidad)
        Me.UiGroupBox1.Controls.Add(Me.lblIdUnidad)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(16, 7)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(482, 40)
        Me.UiGroupBox1.TabIndex = 237
        Me.UiGroupBox1.Text = "Datos de Unidad de Negocio"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblDesUnidad
        '
        Me.lblDesUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDesUnidad.Location = New System.Drawing.Point(110, 16)
        Me.lblDesUnidad.Name = "lblDesUnidad"
        Me.lblDesUnidad.Size = New System.Drawing.Size(341, 13)
        Me.lblDesUnidad.TabIndex = 1
        Me.lblDesUnidad.Text = "lblDesUnidad"
        Me.lblDesUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIdUnidad
        '
        Me.lblIdUnidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIdUnidad.Location = New System.Drawing.Point(16, 16)
        Me.lblIdUnidad.Name = "lblIdUnidad"
        Me.lblIdUnidad.Size = New System.Drawing.Size(56, 13)
        Me.lblIdUnidad.TabIndex = 0
        Me.lblIdUnidad.Text = "lblIdUnidad"
        Me.lblIdUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvAreas
        '
        Me.dgvAreas.ContextMenuStrip = Me.cmbOpcionesArea
        dgvAreas_DesignTimeLayout.LayoutString = resources.GetString("dgvAreas_DesignTimeLayout.LayoutString")
        Me.dgvAreas.DesignTimeLayout = dgvAreas_DesignTimeLayout
        Me.dgvAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAreas.GroupByBoxVisible = False
        Me.dgvAreas.Location = New System.Drawing.Point(16, 55)
        Me.dgvAreas.Name = "dgvAreas"
        Me.dgvAreas.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvAreas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvAreas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvAreas.Size = New System.Drawing.Size(482, 196)
        Me.dgvAreas.TabIndex = 3
        Me.dgvAreas.TabStop = False
        Me.dgvAreas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabPage2.Controls.Add(Me.gbDatosArea)
        Me.UiTabPage2.Controls.Add(Me.dgvCentroCosto)
        Me.UiTabPage2.Icon = CType(resources.GetObject("UiTabPage2.Icon"), System.Drawing.Icon)
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(522, 274)
        Me.UiTabPage2.TabStop = True
        Me.UiTabPage2.Text = "[F4] CENTRO DE COSTO"
        '
        'gbDatosArea
        '
        Me.gbDatosArea.BackColor = System.Drawing.Color.Transparent
        Me.gbDatosArea.Controls.Add(Me.lblDesArea)
        Me.gbDatosArea.Controls.Add(Me.lblCodArea)
        Me.gbDatosArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosArea.Location = New System.Drawing.Point(16, 7)
        Me.gbDatosArea.Name = "gbDatosArea"
        Me.gbDatosArea.Size = New System.Drawing.Size(482, 40)
        Me.gbDatosArea.TabIndex = 236
        Me.gbDatosArea.Text = "Datos de Área"
        Me.gbDatosArea.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblDesArea
        '
        Me.lblDesArea.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDesArea.Location = New System.Drawing.Point(110, 16)
        Me.lblDesArea.Name = "lblDesArea"
        Me.lblDesArea.Size = New System.Drawing.Size(341, 13)
        Me.lblDesArea.TabIndex = 1
        Me.lblDesArea.Text = "lblDesArea"
        Me.lblDesArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCodArea
        '
        Me.lblCodArea.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCodArea.Location = New System.Drawing.Point(16, 16)
        Me.lblCodArea.Name = "lblCodArea"
        Me.lblCodArea.Size = New System.Drawing.Size(56, 13)
        Me.lblCodArea.TabIndex = 0
        Me.lblCodArea.Text = "lblCodArea"
        Me.lblCodArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvCentroCosto
        '
        Me.dgvCentroCosto.ContextMenuStrip = Me.cmbOpcionesCentroCosto
        dgvCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("dgvCentroCosto_DesignTimeLayout.LayoutString")
        Me.dgvCentroCosto.DesignTimeLayout = dgvCentroCosto_DesignTimeLayout
        Me.dgvCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvCentroCosto.GroupByBoxVisible = False
        Me.dgvCentroCosto.Location = New System.Drawing.Point(16, 55)
        Me.dgvCentroCosto.Name = "dgvCentroCosto"
        Me.dgvCentroCosto.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCentroCosto.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCentroCosto.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCentroCosto.Size = New System.Drawing.Size(482, 196)
        Me.dgvCentroCosto.TabIndex = 3
        Me.dgvCentroCosto.TabStop = False
        Me.dgvCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005
        '
        'cmbOpcionesCentroCosto
        '
        Me.cmbOpcionesCentroCosto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoCentroCosto, Me.miMostrarCentroCosto, Me.miEliminarCentroCosto, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.miActualizarCentroCosto})
        Me.cmbOpcionesCentroCosto.Name = "ContextMenuStrip1"
        Me.cmbOpcionesCentroCosto.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoCentroCosto
        '
        Me.miNuevoCentroCosto.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoCentroCosto.Name = "miNuevoCentroCosto"
        Me.miNuevoCentroCosto.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoCentroCosto.Text = "Nuevo"
        '
        'miMostrarCentroCosto
        '
        Me.miMostrarCentroCosto.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarCentroCosto.Name = "miMostrarCentroCosto"
        Me.miMostrarCentroCosto.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarCentroCosto.Text = "Mostrar"
        '
        'miEliminarCentroCosto
        '
        Me.miEliminarCentroCosto.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarCentroCosto.Name = "miEliminarCentroCosto"
        Me.miEliminarCentroCosto.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarCentroCosto.Text = "Eliminar"
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
        'miActualizarCentroCosto
        '
        Me.miActualizarCentroCosto.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarCentroCosto.Name = "miActualizarCentroCosto"
        Me.miActualizarCentroCosto.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarCentroCosto.Text = "Actualizar"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.biImprimir, Me.ToolStripSeparator4})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(563, 31)
        Me.ToolStrip.TabIndex = 201
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Solicitud de Gastos"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'frmAreasCentroCosto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(563, 359)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.TabCuentas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAreasCentroCosto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Áreas y Centros de Costo"
        CType(Me.TabCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCuentas.ResumeLayout(False)
        Me.UiTabPage3.ResumeLayout(False)
        CType(Me.dgvUnidadNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpcionesArea.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.dgvAreas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage2.ResumeLayout(False)
        CType(Me.gbDatosArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosArea.ResumeLayout(False)
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpcionesCentroCosto.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabCuentas As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvCentroCosto As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvAreas As Janus.Windows.GridEX.GridEX
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosArea As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblCodArea As System.Windows.Forms.Label
    Friend WithEvents lblDesArea As System.Windows.Forms.Label
    Friend WithEvents cmbOpcionesArea As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbOpcionesCentroCosto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UiTabPage3 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvUnidadNegocio As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblDesUnidad As System.Windows.Forms.Label
    Friend WithEvents lblIdUnidad As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
End Class
