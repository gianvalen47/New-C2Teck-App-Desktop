<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudGarantia_Rep_MO
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
        Dim dgvRepuestos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudGarantia_Rep_MO))
        Dim dgvManoObra_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvRepuestos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpRepuestos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoRep = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCantAtendidaOk = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPrecFabricaOk = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarRep = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarRep = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvManoObra = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpManoObra = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimirMO = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevoMO = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarMO = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarMO = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarMO = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabOpciones = New Janus.Windows.UI.Tab.UITab()
        Me.tbRepuestos = New Janus.Windows.UI.Tab.UITabPage()
        Me.tbManoObra = New Janus.Windows.UI.Tab.UITabPage()
        Me.gbDatosArea = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblDesArea = New System.Windows.Forms.Label()
        Me.lblCodArea = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRepuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpRepuestos.SuspendLayout()
        CType(Me.dgvManoObra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpManoObra.SuspendLayout()
        CType(Me.TabOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabOpciones.SuspendLayout()
        Me.tbRepuestos.SuspendLayout()
        Me.tbManoObra.SuspendLayout()
        CType(Me.gbDatosArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosArea.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvRepuestos
        '
        Me.dgvRepuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRepuestos.ContextMenuStrip = Me.cmOpRepuestos
        dgvRepuestos_DesignTimeLayout.LayoutString = resources.GetString("dgvRepuestos_DesignTimeLayout.LayoutString")
        Me.dgvRepuestos.DesignTimeLayout = dgvRepuestos_DesignTimeLayout
        Me.dgvRepuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvRepuestos.GroupByBoxVisible = False
        Me.dgvRepuestos.Location = New System.Drawing.Point(5, 8)
        Me.dgvRepuestos.Name = "dgvRepuestos"
        Me.dgvRepuestos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvRepuestos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvRepuestos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvRepuestos.Size = New System.Drawing.Size(766, 289)
        Me.dgvRepuestos.TabIndex = 19
        Me.dgvRepuestos.TabStop = False
        Me.dgvRepuestos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpRepuestos
        '
        Me.cmOpRepuestos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoRep, Me.miCantAtendidaOk, Me.miPrecFabricaOk, Me.miEliminarRep, Me.miSeparador1, Me.ToolStripSeparator3, Me.miActualizarRep})
        Me.cmOpRepuestos.Name = "cmOpciones"
        Me.cmOpRepuestos.Size = New System.Drawing.Size(172, 126)
        '
        'miNuevoRep
        '
        Me.miNuevoRep.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoRep.Name = "miNuevoRep"
        Me.miNuevoRep.Size = New System.Drawing.Size(171, 22)
        Me.miNuevoRep.Text = "Ingresar Guía"
        Me.miNuevoRep.ToolTipText = "Nuevo Detalle"
        '
        'miCantAtendidaOk
        '
        Me.miCantAtendidaOk.Image = CType(resources.GetObject("miCantAtendidaOk.Image"), System.Drawing.Image)
        Me.miCantAtendidaOk.Name = "miCantAtendidaOk"
        Me.miCantAtendidaOk.Size = New System.Drawing.Size(171, 22)
        Me.miCantAtendidaOk.Text = "Cant. Atendida Ok"
        '
        'miPrecFabricaOk
        '
        Me.miPrecFabricaOk.Image = CType(resources.GetObject("miPrecFabricaOk.Image"), System.Drawing.Image)
        Me.miPrecFabricaOk.Name = "miPrecFabricaOk"
        Me.miPrecFabricaOk.Size = New System.Drawing.Size(171, 22)
        Me.miPrecFabricaOk.Text = "Prec. Fabrica Ok"
        '
        'miEliminarRep
        '
        Me.miEliminarRep.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarRep.Name = "miEliminarRep"
        Me.miEliminarRep.Size = New System.Drawing.Size(171, 22)
        Me.miEliminarRep.Text = "Eliminar Guía"
        Me.miEliminarRep.ToolTipText = "Eliminar Detalle"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(168, 6)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(168, 6)
        '
        'miActualizarRep
        '
        Me.miActualizarRep.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarRep.Name = "miActualizarRep"
        Me.miActualizarRep.Size = New System.Drawing.Size(171, 22)
        Me.miActualizarRep.Text = "Actualizar"
        Me.miActualizarRep.ToolTipText = "Refrescar Lista Detalles"
        '
        'dgvManoObra
        '
        Me.dgvManoObra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvManoObra.ContextMenuStrip = Me.cmbOpManoObra
        dgvManoObra_DesignTimeLayout.LayoutString = resources.GetString("dgvManoObra_DesignTimeLayout.LayoutString")
        Me.dgvManoObra.DesignTimeLayout = dgvManoObra_DesignTimeLayout
        Me.dgvManoObra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvManoObra.GroupByBoxVisible = False
        Me.dgvManoObra.Location = New System.Drawing.Point(5, 8)
        Me.dgvManoObra.Name = "dgvManoObra"
        Me.dgvManoObra.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvManoObra.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvManoObra.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvManoObra.Size = New System.Drawing.Size(774, 283)
        Me.dgvManoObra.TabIndex = 20
        Me.dgvManoObra.TabStop = False
        Me.dgvManoObra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbOpManoObra
        '
        Me.cmbOpManoObra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimirMO, Me.miNuevoMO, Me.miMostrarMO, Me.miEliminarMO, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.miActualizarMO})
        Me.cmbOpManoObra.Name = "ContextMenuStrip1"
        Me.cmbOpManoObra.Size = New System.Drawing.Size(127, 126)
        '
        'miImprimirMO
        '
        Me.miImprimirMO.Image = Global.SIGECOM.My.Resources.Resources.Impresora1
        Me.miImprimirMO.Name = "miImprimirMO"
        Me.miImprimirMO.Size = New System.Drawing.Size(126, 22)
        Me.miImprimirMO.Text = "Imprimir"
        '
        'miNuevoMO
        '
        Me.miNuevoMO.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoMO.Name = "miNuevoMO"
        Me.miNuevoMO.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoMO.Text = "Nuevo"
        '
        'miMostrarMO
        '
        Me.miMostrarMO.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarMO.Name = "miMostrarMO"
        Me.miMostrarMO.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarMO.Text = "Mostrar"
        '
        'miEliminarMO
        '
        Me.miEliminarMO.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarMO.Name = "miEliminarMO"
        Me.miEliminarMO.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarMO.Text = "Eliminar"
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
        'miActualizarMO
        '
        Me.miActualizarMO.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarMO.Name = "miActualizarMO"
        Me.miActualizarMO.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarMO.Text = "Actualizar"
        '
        'TabOpciones
        '
        Me.TabOpciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabOpciones.Location = New System.Drawing.Point(3, 5)
        Me.TabOpciones.Name = "TabOpciones"
        Me.TabOpciones.Size = New System.Drawing.Size(785, 319)
        Me.TabOpciones.TabIndex = 120
        Me.TabOpciones.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tbRepuestos, Me.tbManoObra})
        Me.TabOpciones.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'tbRepuestos
        '
        Me.tbRepuestos.Controls.Add(Me.dgvRepuestos)
        Me.tbRepuestos.Icon = CType(resources.GetObject("tbRepuestos.Icon"), System.Drawing.Icon)
        Me.tbRepuestos.Location = New System.Drawing.Point(1, 23)
        Me.tbRepuestos.Name = "tbRepuestos"
        Me.tbRepuestos.Size = New System.Drawing.Size(775, 301)
        Me.tbRepuestos.TabStop = True
        Me.tbRepuestos.Text = "[F2] REPUESTOS"
        '
        'tbManoObra
        '
        Me.tbManoObra.Controls.Add(Me.dgvManoObra)
        Me.tbManoObra.Icon = CType(resources.GetObject("tbManoObra.Icon"), System.Drawing.Icon)
        Me.tbManoObra.Location = New System.Drawing.Point(1, 23)
        Me.tbManoObra.Name = "tbManoObra"
        Me.tbManoObra.Size = New System.Drawing.Size(783, 295)
        Me.tbManoObra.TabStop = True
        Me.tbManoObra.Text = "[F3] MANO DE OBRA"
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
        'frmSolicitudGarantia_Rep_MO
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 335)
        Me.Controls.Add(Me.TabOpciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolicitudGarantia_Rep_MO"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Repuestos y Mano de Obra de Orden de Reparación N°"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRepuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpRepuestos.ResumeLayout(False)
        CType(Me.dgvManoObra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpManoObra.ResumeLayout(False)
        CType(Me.TabOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabOpciones.ResumeLayout(False)
        Me.tbRepuestos.ResumeLayout(False)
        Me.tbManoObra.ResumeLayout(False)
        CType(Me.gbDatosArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosArea.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvRepuestos As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgvManoObra As Janus.Windows.GridEX.GridEX
    Friend WithEvents TabOpciones As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tbRepuestos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tbManoObra As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents gbDatosArea As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblDesArea As System.Windows.Forms.Label
    Friend WithEvents lblCodArea As System.Windows.Forms.Label
    Friend WithEvents cmbOpManoObra As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoMO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarMO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarMO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarMO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miImprimirMO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpRepuestos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoRep As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCantAtendidaOk As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miPrecFabricaOk As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarRep As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarRep As System.Windows.Forms.ToolStripMenuItem
End Class
