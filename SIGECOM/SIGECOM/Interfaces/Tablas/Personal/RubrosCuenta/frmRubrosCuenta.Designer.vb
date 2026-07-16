<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRubrosCuenta
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
        Dim dgvDatosIngresos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRubrosCuenta))
        Dim dgvDatosDsctos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosAport_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.TabCuentas = New Janus.Windows.UI.Tab.UITab()
        Me.cmOpcionesDscto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimirDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevoDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdRubroIng = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgvDatosIngresos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesIng = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimirIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevoIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvDatosDsctos = New Janus.Windows.GridEX.GridEX()
        Me.UiTabPage3 = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvDatosAport = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesAport = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimirApor = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevoApor = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarApor = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarApor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarApor = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCuentas.SuspendLayout()
        Me.cmOpcionesDscto.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.dgvDatosIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesIng.SuspendLayout()
        Me.UiTabPage2.SuspendLayout()
        CType(Me.dgvDatosDsctos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage3.SuspendLayout()
        CType(Me.dgvDatosAport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesAport.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'TabCuentas
        '
        Me.TabCuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabCuentas.ContextMenuStrip = Me.cmOpcionesDscto
        Me.TabCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabCuentas.Location = New System.Drawing.Point(9, 13)
        Me.TabCuentas.Name = "TabCuentas"
        Me.TabCuentas.Size = New System.Drawing.Size(611, 307)
        Me.TabCuentas.TabIndex = 2
        Me.TabCuentas.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage2, Me.UiTabPage3})
        Me.TabCuentas.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'cmOpcionesDscto
        '
        Me.cmOpcionesDscto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimirDscto, Me.miNuevoDscto, Me.miMostrarDscto, Me.miEliminarDscto, Me.ToolStripSeparator1, Me.miActualizarDscto})
        Me.cmOpcionesDscto.Name = "cmOpciones"
        Me.cmOpcionesDscto.Size = New System.Drawing.Size(127, 120)
        '
        'miImprimirDscto
        '
        Me.miImprimirDscto.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimirDscto.Name = "miImprimirDscto"
        Me.miImprimirDscto.Size = New System.Drawing.Size(126, 22)
        Me.miImprimirDscto.Text = "Imprimir"
        '
        'miNuevoDscto
        '
        Me.miNuevoDscto.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoDscto.Name = "miNuevoDscto"
        Me.miNuevoDscto.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoDscto.Text = "Nuevo"
        '
        'miMostrarDscto
        '
        Me.miMostrarDscto.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarDscto.Name = "miMostrarDscto"
        Me.miMostrarDscto.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarDscto.Text = "Mostrar"
        '
        'miEliminarDscto
        '
        Me.miEliminarDscto.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarDscto.Name = "miEliminarDscto"
        Me.miEliminarDscto.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarDscto.Text = "Eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarDscto
        '
        Me.miActualizarDscto.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarDscto.Name = "miActualizarDscto"
        Me.miActualizarDscto.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarDscto.Text = "Actualizar"
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabPage1.Controls.Add(Me.gbDatosBusqueda)
        Me.UiTabPage1.Controls.Add(Me.dgvDatosIngresos)
        Me.UiTabPage1.Icon = CType(resources.GetObject("UiTabPage1.Icon"), System.Drawing.Icon)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(609, 283)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "[F2] INGRESOS"
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.BackColor = System.Drawing.Color.Transparent
        Me.gbDatosBusqueda.BorderColor = System.Drawing.SystemColors.Desktop
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.txtIdRubroIng)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(13, 8)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(582, 50)
        Me.gbDatosBusqueda.TabIndex = 178
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(175, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 228
        Me.Label2.Text = "Código"
        '
        'txtIdRubroIng
        '
        Me.txtIdRubroIng.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdRubroIng.Location = New System.Drawing.Point(147, 25)
        Me.txtIdRubroIng.MaxLength = 9
        Me.txtIdRubroIng.Name = "txtIdRubroIng"
        Me.txtIdRubroIng.Numeric = True
        Me.txtIdRubroIng.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtIdRubroIng.Size = New System.Drawing.Size(100, 20)
        Me.txtIdRubroIng.TabIndex = 226
        Me.txtIdRubroIng.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(406, 22)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(71, 23)
        Me.btnBuscar.TabIndex = 227
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvDatosIngresos
        '
        Me.dgvDatosIngresos.ContextMenuStrip = Me.cmOpcionesIng
        dgvDatosIngresos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosIngresos_DesignTimeLayout.LayoutString")
        Me.dgvDatosIngresos.DesignTimeLayout = dgvDatosIngresos_DesignTimeLayout
        Me.dgvDatosIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosIngresos.GroupByBoxVisible = False
        Me.dgvDatosIngresos.Location = New System.Drawing.Point(14, 66)
        Me.dgvDatosIngresos.Name = "dgvDatosIngresos"
        Me.dgvDatosIngresos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosIngresos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosIngresos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosIngresos.Size = New System.Drawing.Size(582, 198)
        Me.dgvDatosIngresos.TabIndex = 177
        Me.dgvDatosIngresos.TabStop = False
        Me.dgvDatosIngresos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesIng
        '
        Me.cmOpcionesIng.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimirIng, Me.miNuevoIng, Me.miMostrarIng, Me.miEliminarIng, Me.ToolStripMenuItem1, Me.miActualizarIng})
        Me.cmOpcionesIng.Name = "cmOpciones"
        Me.cmOpcionesIng.Size = New System.Drawing.Size(127, 120)
        '
        'miImprimirIng
        '
        Me.miImprimirIng.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimirIng.Name = "miImprimirIng"
        Me.miImprimirIng.Size = New System.Drawing.Size(126, 22)
        Me.miImprimirIng.Text = "Imprimir"
        '
        'miNuevoIng
        '
        Me.miNuevoIng.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoIng.Name = "miNuevoIng"
        Me.miNuevoIng.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoIng.Text = "Nuevo"
        '
        'miMostrarIng
        '
        Me.miMostrarIng.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarIng.Name = "miMostrarIng"
        Me.miMostrarIng.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarIng.Text = "Mostrar"
        '
        'miEliminarIng
        '
        Me.miEliminarIng.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarIng.Name = "miEliminarIng"
        Me.miEliminarIng.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarIng.Text = "Eliminar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarIng
        '
        Me.miActualizarIng.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarIng.Name = "miActualizarIng"
        Me.miActualizarIng.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarIng.Text = "Actualizar"
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabPage2.Controls.Add(Me.dgvDatosDsctos)
        Me.UiTabPage2.Icon = CType(resources.GetObject("UiTabPage2.Icon"), System.Drawing.Icon)
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(609, 283)
        Me.UiTabPage2.TabStop = True
        Me.UiTabPage2.Text = "[F3] DESCUENTOS"
        '
        'dgvDatosDsctos
        '
        Me.dgvDatosDsctos.ContextMenuStrip = Me.cmOpcionesDscto
        dgvDatosDsctos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosDsctos_DesignTimeLayout.LayoutString")
        Me.dgvDatosDsctos.DesignTimeLayout = dgvDatosDsctos_DesignTimeLayout
        Me.dgvDatosDsctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosDsctos.GroupByBoxVisible = False
        Me.dgvDatosDsctos.Location = New System.Drawing.Point(65, 21)
        Me.dgvDatosDsctos.Name = "dgvDatosDsctos"
        Me.dgvDatosDsctos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosDsctos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosDsctos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosDsctos.Size = New System.Drawing.Size(478, 242)
        Me.dgvDatosDsctos.TabIndex = 178
        Me.dgvDatosDsctos.TabStop = False
        Me.dgvDatosDsctos.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005
        '
        'UiTabPage3
        '
        Me.UiTabPage3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabPage3.Controls.Add(Me.dgvDatosAport)
        Me.UiTabPage3.Icon = CType(resources.GetObject("UiTabPage3.Icon"), System.Drawing.Icon)
        Me.UiTabPage3.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage3.Name = "UiTabPage3"
        Me.UiTabPage3.Size = New System.Drawing.Size(609, 283)
        Me.UiTabPage3.TabStop = True
        Me.UiTabPage3.Text = "[F4] APORTACIONES"
        '
        'dgvDatosAport
        '
        Me.dgvDatosAport.ContextMenuStrip = Me.cmOpcionesAport
        dgvDatosAport_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosAport_DesignTimeLayout.LayoutString")
        Me.dgvDatosAport.DesignTimeLayout = dgvDatosAport_DesignTimeLayout
        Me.dgvDatosAport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosAport.GroupByBoxVisible = False
        Me.dgvDatosAport.Location = New System.Drawing.Point(14, 19)
        Me.dgvDatosAport.Name = "dgvDatosAport"
        Me.dgvDatosAport.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosAport.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosAport.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosAport.Size = New System.Drawing.Size(582, 245)
        Me.dgvDatosAport.TabIndex = 177
        Me.dgvDatosAport.TabStop = False
        Me.dgvDatosAport.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesAport
        '
        Me.cmOpcionesAport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimirApor, Me.miNuevoApor, Me.miMostrarApor, Me.miEliminarApor, Me.ToolStripSeparator2, Me.miActualizarApor})
        Me.cmOpcionesAport.Name = "cmOpciones"
        Me.cmOpcionesAport.Size = New System.Drawing.Size(127, 120)
        '
        'miImprimirApor
        '
        Me.miImprimirApor.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimirApor.Name = "miImprimirApor"
        Me.miImprimirApor.Size = New System.Drawing.Size(126, 22)
        Me.miImprimirApor.Text = "Imprimir"
        '
        'miNuevoApor
        '
        Me.miNuevoApor.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoApor.Name = "miNuevoApor"
        Me.miNuevoApor.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoApor.Text = "Nuevo"
        '
        'miMostrarApor
        '
        Me.miMostrarApor.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarApor.Name = "miMostrarApor"
        Me.miMostrarApor.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarApor.Text = "Mostrar"
        '
        'miEliminarApor
        '
        Me.miEliminarApor.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarApor.Name = "miEliminarApor"
        Me.miEliminarApor.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarApor.Text = "Eliminar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarApor
        '
        Me.miActualizarApor.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarApor.Name = "miActualizarApor"
        Me.miActualizarApor.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarApor.Text = "Actualizar"
        '
        'frmRubrosCuenta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(630, 336)
        Me.Controls.Add(Me.TabCuentas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRubrosCuenta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rubros de Cuentas"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCuentas.ResumeLayout(False)
        Me.cmOpcionesDscto.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.dgvDatosIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesIng.ResumeLayout(False)
        Me.UiTabPage2.ResumeLayout(False)
        CType(Me.dgvDatosDsctos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage3.ResumeLayout(False)
        CType(Me.dgvDatosAport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesAport.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents TabCuentas As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvDatosIngresos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabPage3 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents cmOpcionesIng As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimirIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNuevoIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpcionesDscto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimirDscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNuevoDscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarDscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarDscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarDscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpcionesAport As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimirApor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNuevoApor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarApor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarApor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarApor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvDatosAport As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgvDatosDsctos As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdRubroIng As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
