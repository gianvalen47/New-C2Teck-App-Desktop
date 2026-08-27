<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRubrosPlanilla
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
        Dim dgvDatosDsctos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatosIngresos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRubrosPlanilla))
        Dim dgvDatosCtaContable_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvDatosDsctos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesDscto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimirDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevoDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvDatosIngresos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesIng = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimirIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevoIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabCuentas = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabPage3 = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvDatosCtaContable = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNomSubCuenta = New System.Windows.Forms.Label()
        Me.lblCodSubCuenta = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage2.SuspendLayout()
        CType(Me.dgvDatosDsctos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesDscto.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        CType(Me.dgvDatosIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesIng.SuspendLayout()
        CType(Me.TabCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCuentas.SuspendLayout()
        Me.UiTabPage3.SuspendLayout()
        CType(Me.dgvDatosCtaContable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
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
        Me.dgvDatosDsctos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatosDsctos.ContextMenuStrip = Me.cmOpcionesDscto
        dgvDatosDsctos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosDsctos_DesignTimeLayout.LayoutString")
        Me.dgvDatosDsctos.DesignTimeLayout = dgvDatosDsctos_DesignTimeLayout
        Me.dgvDatosDsctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosDsctos.GroupByBoxVisible = False
        Me.dgvDatosDsctos.Location = New System.Drawing.Point(21, 23)
        Me.dgvDatosDsctos.Name = "dgvDatosDsctos"
        Me.dgvDatosDsctos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosDsctos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosDsctos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosDsctos.Size = New System.Drawing.Size(567, 239)
        Me.dgvDatosDsctos.TabIndex = 176
        Me.dgvDatosDsctos.TabStop = False
        Me.dgvDatosDsctos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        Me.UiTabPage1.Controls.Add(Me.dgvDatosIngresos)
        Me.UiTabPage1.Icon = CType(resources.GetObject("UiTabPage1.Icon"), System.Drawing.Icon)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(609, 283)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "[F2] INGRESOS"
        '
        'dgvDatosIngresos
        '
        Me.dgvDatosIngresos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatosIngresos.ContextMenuStrip = Me.cmOpcionesIng
        dgvDatosIngresos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosIngresos_DesignTimeLayout.LayoutString")
        Me.dgvDatosIngresos.DesignTimeLayout = dgvDatosIngresos_DesignTimeLayout
        Me.dgvDatosIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosIngresos.GroupByBoxVisible = False
        Me.dgvDatosIngresos.Location = New System.Drawing.Point(8, 19)
        Me.dgvDatosIngresos.Name = "dgvDatosIngresos"
        Me.dgvDatosIngresos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosIngresos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosIngresos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosIngresos.Size = New System.Drawing.Size(592, 248)
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
        'TabCuentas
        '
        Me.TabCuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabCuentas.Location = New System.Drawing.Point(10, 12)
        Me.TabCuentas.Name = "TabCuentas"
        Me.TabCuentas.Size = New System.Drawing.Size(611, 307)
        Me.TabCuentas.TabIndex = 1
        Me.TabCuentas.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage2})
        Me.TabCuentas.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabPage3
        '
        Me.UiTabPage3.Controls.Add(Me.dgvDatosCtaContable)
        Me.UiTabPage3.Controls.Add(Me.UiGroupBox1)
        Me.UiTabPage3.Icon = CType(resources.GetObject("UiTabPage3.Icon"), System.Drawing.Icon)
        Me.UiTabPage3.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage3.Name = "UiTabPage3"
        Me.UiTabPage3.Size = New System.Drawing.Size(602, 283)
        Me.UiTabPage3.TabStop = True
        Me.UiTabPage3.Text = "[F4] CUENTA CONTABLE"
        '
        'dgvDatosCtaContable
        '
        dgvDatosCtaContable_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosCtaContable_DesignTimeLayout.LayoutString")
        Me.dgvDatosCtaContable.DesignTimeLayout = dgvDatosCtaContable_DesignTimeLayout
        Me.dgvDatosCtaContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosCtaContable.GroupByBoxVisible = False
        Me.dgvDatosCtaContable.Location = New System.Drawing.Point(8, 55)
        Me.dgvDatosCtaContable.Name = "dgvDatosCtaContable"
        Me.dgvDatosCtaContable.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosCtaContable.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosCtaContable.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosCtaContable.Size = New System.Drawing.Size(585, 218)
        Me.dgvDatosCtaContable.TabIndex = 3
        Me.dgvDatosCtaContable.TabStop = False
        Me.dgvDatosCtaContable.Visible = False
        Me.dgvDatosCtaContable.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.BorderColor = System.Drawing.SystemColors.Desktop
        Me.UiGroupBox1.Controls.Add(Me.txtNomSubCuenta)
        Me.UiGroupBox1.Controls.Add(Me.lblCodSubCuenta)
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 13)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(585, 36)
        Me.UiGroupBox1.TabIndex = 9
        Me.UiGroupBox1.Text = "Datos de Sub Cuenta"
        '
        'txtNomSubCuenta
        '
        Me.txtNomSubCuenta.AutoSize = True
        Me.txtNomSubCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNomSubCuenta.Location = New System.Drawing.Point(93, 16)
        Me.txtNomSubCuenta.Name = "txtNomSubCuenta"
        Me.txtNomSubCuenta.Size = New System.Drawing.Size(79, 13)
        Me.txtNomSubCuenta.TabIndex = 10
        Me.txtNomSubCuenta.Text = "DesSubCuenta"
        '
        'lblCodSubCuenta
        '
        Me.lblCodSubCuenta.AutoSize = True
        Me.lblCodSubCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblCodSubCuenta.Location = New System.Drawing.Point(8, 16)
        Me.lblCodSubCuenta.Name = "lblCodSubCuenta"
        Me.lblCodSubCuenta.Size = New System.Drawing.Size(79, 13)
        Me.lblCodSubCuenta.TabIndex = 9
        Me.lblCodSubCuenta.Text = "CodSubCuenta"
        Me.lblCodSubCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmRubrosPlanilla
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(644, 345)
        Me.Controls.Add(Me.TabCuentas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRubrosPlanilla"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rubros de Planilla"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage2.ResumeLayout(False)
        CType(Me.dgvDatosDsctos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesDscto.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        CType(Me.dgvDatosIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesIng.ResumeLayout(False)
        CType(Me.TabCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCuentas.ResumeLayout(False)
        Me.UiTabPage3.ResumeLayout(False)
        CType(Me.dgvDatosCtaContable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents TabCuentas As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabPage3 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvDatosCtaContable As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtNomSubCuenta As System.Windows.Forms.Label
    Friend WithEvents lblCodSubCuenta As System.Windows.Forms.Label
    Friend WithEvents dgvDatosDsctos As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgvDatosIngresos As Janus.Windows.GridEX.GridEX
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
End Class
