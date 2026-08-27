<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsolidadoMes
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
        Dim dgConsolidado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsolidadoMes))
        Dim cbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnMostrar = New System.Windows.Forms.ToolStripButton()
        Me.btnBorrar = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnRevertir = New System.Windows.Forms.ToolStripButton()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmBorrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmRevertir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgConsolidado = New Janus.Windows.GridEX.GridEX()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgConsolidado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(23, 23)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImprimir, Me.btnNuevo, Me.btnMostrar, Me.btnBorrar, Me.btnCerrar, Me.btnRevertir, Me.btnActualizar, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(666, 30)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(27, 27)
        Me.btnImprimir.Text = "ToolStripButton1"
        Me.btnImprimir.ToolTipText = "Imprimir Consolidado"
        '
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(27, 27)
        Me.btnNuevo.Text = "Crear Nuevo Consolidado"
        Me.btnNuevo.ToolTipText = "Nuevo Consolidado"
        '
        'btnMostrar
        '
        Me.btnMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.btnMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(27, 27)
        Me.btnMostrar.Text = "ToolStripButton1"
        Me.btnMostrar.ToolTipText = "Mostrar Consolidado"
        '
        'btnBorrar
        '
        Me.btnBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBorrar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.btnBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(27, 27)
        Me.btnBorrar.Text = "Eliminar"
        Me.btnBorrar.ToolTipText = "Eliminar Consolidado"
        '
        'btnCerrar
        '
        Me.btnCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCerrar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(27, 27)
        Me.btnCerrar.Text = "ToolStripButton1"
        Me.btnCerrar.ToolTipText = "Cerrar Proceso del Mes "
        '
        'btnRevertir
        '
        Me.btnRevertir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRevertir.Image = Global.SIGECOM.My.Resources.Resources.ManoHaciaAbajo
        Me.btnRevertir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRevertir.Name = "btnRevertir"
        Me.btnRevertir.Size = New System.Drawing.Size(27, 27)
        Me.btnRevertir.Text = "ToolStripButton1"
        Me.btnRevertir.ToolTipText = "Revertir Proceso"
        '
        'btnActualizar
        '
        Me.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(27, 27)
        Me.btnActualizar.Text = "Actualizar Datos del Formulario"
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(27, 27)
        Me.btnSalir.Text = "ToolStripButton1"
        Me.btnSalir.ToolTipText = "Salir de la Ventana"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmImprimir, Me.cmNuevo, Me.cmMostrar, Me.cmBorrar, Me.cmCerrar, Me.cmRevertir, Me.ToolStripMenuItem2, Me.ToolStripMenuItem1, Me.cmActualizar, Me.cmSalir})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 192)
        Me.ContextMenuStrip1.Text = "Actualizar"
        '
        'cmImprimir
        '
        Me.cmImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.cmImprimir.Name = "cmImprimir"
        Me.cmImprimir.Size = New System.Drawing.Size(159, 22)
        Me.cmImprimir.Text = "Imprimir"
        '
        'cmNuevo
        '
        Me.cmNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.cmNuevo.Name = "cmNuevo"
        Me.cmNuevo.Size = New System.Drawing.Size(159, 22)
        Me.cmNuevo.Text = "Nuevo"
        '
        'cmMostrar
        '
        Me.cmMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.cmMostrar.Name = "cmMostrar"
        Me.cmMostrar.Size = New System.Drawing.Size(159, 22)
        Me.cmMostrar.Text = "Mostrar"
        Me.cmMostrar.ToolTipText = "Mostrar el contenido de la factura"
        '
        'cmBorrar
        '
        Me.cmBorrar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.cmBorrar.Name = "cmBorrar"
        Me.cmBorrar.Size = New System.Drawing.Size(159, 22)
        Me.cmBorrar.Text = "Eliminar"
        '
        'cmCerrar
        '
        Me.cmCerrar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.cmCerrar.Name = "cmCerrar"
        Me.cmCerrar.Size = New System.Drawing.Size(159, 22)
        Me.cmCerrar.Text = "Cerrar Proceso"
        Me.cmCerrar.ToolTipText = "Cerrar el proceso del mes"
        '
        'cmRevertir
        '
        Me.cmRevertir.Image = Global.SIGECOM.My.Resources.Resources.ManoHaciaAbajo
        Me.cmRevertir.Name = "cmRevertir"
        Me.cmRevertir.Size = New System.Drawing.Size(159, 22)
        Me.cmRevertir.Text = "Revertir Proceso"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(156, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(156, 6)
        '
        'cmActualizar
        '
        Me.cmActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.cmActualizar.Name = "cmActualizar"
        Me.cmActualizar.Size = New System.Drawing.Size(159, 22)
        Me.cmActualizar.Text = "Actualizar"
        Me.cmActualizar.ToolTipText = "Actualizar / Refrescar los datos"
        '
        'cmSalir
        '
        Me.cmSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.cmSalir.Name = "cmSalir"
        Me.cmSalir.Size = New System.Drawing.Size(159, 22)
        Me.cmSalir.Text = "Salir"
        '
        'dgConsolidado
        '
        Me.dgConsolidado.AllowCardSizing = False
        Me.dgConsolidado.AllowColumnDrag = False
        Me.dgConsolidado.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgConsolidado.AlternatingColors = True
        Me.dgConsolidado.ContextMenuStrip = Me.ContextMenuStrip1
        dgConsolidado_DesignTimeLayout.LayoutString = resources.GetString("dgConsolidado_DesignTimeLayout.LayoutString")
        Me.dgConsolidado.DesignTimeLayout = dgConsolidado_DesignTimeLayout
        Me.dgConsolidado.EmptyRows = True
        Me.dgConsolidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgConsolidado.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgConsolidado.GroupByBoxVisible = False
        Me.dgConsolidado.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgConsolidado.Location = New System.Drawing.Point(4, 100)
        Me.dgConsolidado.Name = "dgConsolidado"
        Me.dgConsolidado.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgConsolidado.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgConsolidado.Size = New System.Drawing.Size(658, 367)
        Me.dgConsolidado.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.dgConsolidado, "Listado de Facturas de Importacion")
        Me.dgConsolidado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cbEstado)
        Me.UiGroupBox1.Controls.Add(Me.cbAlmacen)
        Me.UiGroupBox1.Controls.Add(Me.cbOficina)
        Me.UiGroupBox1.Controls.Add(Me.cbMes)
        Me.UiGroupBox1.Controls.Add(Me.txtPeriodo)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Location = New System.Drawing.Point(4, 39)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(658, 59)
        Me.UiGroupBox1.TabIndex = 3
        Me.UiGroupBox1.Text = "Datos de Busqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbEstado
        '
        Me.cbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbEstado_DesignTimeLayout.LayoutString = resources.GetString("cbEstado_DesignTimeLayout.LayoutString")
        Me.cbEstado.DesignTimeLayout = cbEstado_DesignTimeLayout
        Me.cbEstado.Location = New System.Drawing.Point(508, 30)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.SelectedIndex = -1
        Me.cbEstado.SelectedItem = Nothing
        Me.cbEstado.Size = New System.Drawing.Size(78, 20)
        Me.cbEstado.TabIndex = 30
        Me.cbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbAlmacen
        '
        Me.cbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cbAlmacen_DesignTimeLayout.LayoutString")
        Me.cbAlmacen.DesignTimeLayout = cbAlmacen_DesignTimeLayout
        Me.cbAlmacen.Location = New System.Drawing.Point(260, 30)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.SelectedIndex = -1
        Me.cbAlmacen.SelectedItem = Nothing
        Me.cbAlmacen.Size = New System.Drawing.Size(246, 20)
        Me.cbAlmacen.TabIndex = 29
        Me.cbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbOficina
        '
        Me.cbOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbOficina_DesignTimeLayout.LayoutString = resources.GetString("cbOficina_DesignTimeLayout.LayoutString")
        Me.cbOficina.DesignTimeLayout = cbOficina_DesignTimeLayout
        Me.cbOficina.Location = New System.Drawing.Point(159, 30)
        Me.cbOficina.Name = "cbOficina"
        Me.cbOficina.SelectedIndex = -1
        Me.cbOficina.SelectedItem = Nothing
        Me.cbOficina.Size = New System.Drawing.Size(99, 20)
        Me.cbOficina.TabIndex = 28
        Me.cbOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbMes
        '
        Me.cbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbMes_DesignTimeLayout.LayoutString = resources.GetString("cbMes_DesignTimeLayout.LayoutString")
        Me.cbMes.DesignTimeLayout = cbMes_DesignTimeLayout
        Me.cbMes.Location = New System.Drawing.Point(61, 30)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.SelectedIndex = -1
        Me.cbMes.SelectedItem = Nothing
        Me.cbMes.Size = New System.Drawing.Size(96, 20)
        Me.cbMes.TabIndex = 27
        Me.cbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(4, 30)
        Me.txtPeriodo.Maximum = 3000
        Me.txtPeriodo.Minimum = 2009
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(55, 20)
        Me.txtPeriodo.TabIndex = 26
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.UpDownStyle = Janus.Windows.GridEX.UpDownStyle.UpDownList
        Me.txtPeriodo.Value = 2009
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(161, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Oficina"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(588, 28)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(65, 22)
        Me.btnBuscar.TabIndex = 25
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(510, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Estado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Periodo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(86, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(262, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Almacen"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 470)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(666, 20)
        Me.ssBarra.TabIndex = 4
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        '
        'frmConsolidadoMes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(666, 490)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgConsolidado)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsolidadoMes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consolidado de Cierres de Mes"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgConsolidado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgConsolidado As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmBorrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmCerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnRevertir As ToolStripButton
    Friend WithEvents cmRevertir As ToolStripMenuItem
End Class
