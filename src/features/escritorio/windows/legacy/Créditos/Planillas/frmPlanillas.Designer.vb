<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillas
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
        Dim cbCobrador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillas))
        Dim cbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cbCobrador = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmBorrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmAprobar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmRevertir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmRefrescar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.txtNumero = New System.Windows.Forms.MaskedTextBox()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.cbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.btnMostrar = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAprobar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRevertir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgDetalle = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslbMensaje = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslbTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalPagos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDifCam = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDoc = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.cbCobrador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbCobrador
        '
        Me.cbCobrador.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbCobrador_DesignTimeLayout.LayoutString = resources.GetString("cbCobrador_DesignTimeLayout.LayoutString")
        Me.cbCobrador.DesignTimeLayout = cbCobrador_DesignTimeLayout
        Me.cbCobrador.Location = New System.Drawing.Point(188, 33)
        Me.cbCobrador.Name = "cbCobrador"
        Me.cbCobrador.SelectedIndex = -1
        Me.cbCobrador.SelectedItem = Nothing
        Me.cbCobrador.Size = New System.Drawing.Size(287, 20)
        Me.cbCobrador.TabIndex = 30
        Me.cbCobrador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmNuevo, Me.cmModificar, Me.cmBorrar, Me.cmMostrar, Me.ToolStripSeparator7, Me.cmAprobar, Me.cmRevertir, Me.ToolStripSeparator9, Me.cmRefrescar, Me.cmImprimir})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(180, 192)
        '
        'cmNuevo
        '
        Me.cmNuevo.Image = CType(resources.GetObject("cmNuevo.Image"), System.Drawing.Image)
        Me.cmNuevo.Name = "cmNuevo"
        Me.cmNuevo.Size = New System.Drawing.Size(179, 22)
        Me.cmNuevo.Text = "Nuevo"
        Me.cmNuevo.ToolTipText = "Nuevo"
        '
        'cmModificar
        '
        Me.cmModificar.Image = CType(resources.GetObject("cmModificar.Image"), System.Drawing.Image)
        Me.cmModificar.Name = "cmModificar"
        Me.cmModificar.Size = New System.Drawing.Size(179, 22)
        Me.cmModificar.Text = "Modificar"
        Me.cmModificar.ToolTipText = "Modificar"
        '
        'cmBorrar
        '
        Me.cmBorrar.Image = CType(resources.GetObject("cmBorrar.Image"), System.Drawing.Image)
        Me.cmBorrar.Name = "cmBorrar"
        Me.cmBorrar.Size = New System.Drawing.Size(179, 22)
        Me.cmBorrar.Text = "Borrar"
        Me.cmBorrar.ToolTipText = "Borrar"
        '
        'cmMostrar
        '
        Me.cmMostrar.Image = CType(resources.GetObject("cmMostrar.Image"), System.Drawing.Image)
        Me.cmMostrar.Name = "cmMostrar"
        Me.cmMostrar.Size = New System.Drawing.Size(179, 22)
        Me.cmMostrar.Text = "Mostrar Datos"
        Me.cmMostrar.ToolTipText = "Mostrar Detalles del documento"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(176, 6)
        '
        'cmAprobar
        '
        Me.cmAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.cmAprobar.Name = "cmAprobar"
        Me.cmAprobar.Size = New System.Drawing.Size(179, 22)
        Me.cmAprobar.Text = "Aprobar"
        Me.cmAprobar.ToolTipText = "Aprobar Planilla"
        '
        'cmRevertir
        '
        Me.cmRevertir.Image = CType(resources.GetObject("cmRevertir.Image"), System.Drawing.Image)
        Me.cmRevertir.Name = "cmRevertir"
        Me.cmRevertir.Size = New System.Drawing.Size(179, 22)
        Me.cmRevertir.Text = "Revertir Aprobación"
        Me.cmRevertir.ToolTipText = "Revertir Aprobación"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(176, 6)
        '
        'cmRefrescar
        '
        Me.cmRefrescar.Image = CType(resources.GetObject("cmRefrescar.Image"), System.Drawing.Image)
        Me.cmRefrescar.Name = "cmRefrescar"
        Me.cmRefrescar.Size = New System.Drawing.Size(179, 22)
        Me.cmRefrescar.Text = "Actualizar"
        Me.cmRefrescar.ToolTipText = "Refrescar"
        '
        'cmImprimir
        '
        Me.cmImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.cmImprimir.Name = "cmImprimir"
        Me.cmImprimir.Size = New System.Drawing.Size(179, 22)
        Me.cmImprimir.Text = "Imprimir"
        Me.cmImprimir.ToolTipText = "Imprimir Documento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(298, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Cobrador"
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(28, 28)
        Me.btnSalir.Text = "ToolStripButton1"
        Me.btnSalir.ToolTipText = "Salir de la Ventana"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(479, 33)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(93, 20)
        Me.txtNumero.TabIndex = 31
        '
        'btnImprimir
        '
        Me.btnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(28, 28)
        Me.btnImprimir.Text = "ToolStripButton1"
        Me.btnImprimir.ToolTipText = "Imprimir"
        '
        'cbMes
        '
        Me.cbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbMes_DesignTimeLayout.LayoutString = resources.GetString("cbMes_DesignTimeLayout.LayoutString")
        Me.cbMes.DesignTimeLayout = cbMes_DesignTimeLayout
        Me.cbMes.Location = New System.Drawing.Point(67, 33)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.SelectedIndex = -1
        Me.cbMes.SelectedItem = Nothing
        Me.cbMes.Size = New System.Drawing.Size(118, 20)
        Me.cbMes.TabIndex = 27
        Me.cbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(12, 33)
        Me.txtPeriodo.Maximum = 3000
        Me.txtPeriodo.Minimum = 2009
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(52, 20)
        Me.txtPeriodo.TabIndex = 26
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.UpDownStyle = Janus.Windows.GridEX.UpDownStyle.UpDownList
        Me.txtPeriodo.Value = 2009
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnMostrar
        '
        Me.btnMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMostrar.Image = CType(resources.GetObject("btnMostrar.Image"), System.Drawing.Image)
        Me.btnMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(28, 28)
        Me.btnMostrar.Text = "ToolStripButton1"
        Me.btnMostrar.ToolTipText = "Mostrar los Datos del Registro"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(579, 30)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 25)
        Me.btnBuscar.TabIndex = 32
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.ToolStripSeparator1, Me.btnModificar, Me.ToolStripSeparator2, Me.btnBorrar, Me.ToolStripSeparator3, Me.btnMostrar, Me.ToolStripSeparator8, Me.btnAprobar, Me.ToolStripSeparator4, Me.btnRevertir, Me.ToolStripSeparator10, Me.btnRefrescar, Me.ToolStripSeparator5, Me.btnImprimir, Me.ToolStripSeparator6, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(769, 31)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(28, 28)
        Me.btnNuevo.Text = "ToolStripButton1"
        Me.btnNuevo.ToolTipText = "Nueva Planilla"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnModificar
        '
        Me.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(28, 28)
        Me.btnModificar.Text = "Modificar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'btnBorrar
        '
        Me.btnBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(28, 28)
        Me.btnBorrar.Text = "ToolStripButton1"
        Me.btnBorrar.ToolTipText = "Borrar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'btnAprobar
        '
        Me.btnAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.btnAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(28, 28)
        Me.btnAprobar.Text = "ToolStripButton1"
        Me.btnAprobar.ToolTipText = "Aprobar Planilla"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'btnRevertir
        '
        Me.btnRevertir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRevertir.Image = CType(resources.GetObject("btnRevertir.Image"), System.Drawing.Image)
        Me.btnRevertir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRevertir.Name = "btnRevertir"
        Me.btnRevertir.Size = New System.Drawing.Size(28, 28)
        Me.btnRevertir.Text = "ToolStripButton1"
        Me.btnRevertir.ToolTipText = "Revertir Aprobacion"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 31)
        '
        'btnRefrescar
        '
        Me.btnRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRefrescar.Image = CType(resources.GetObject("btnRefrescar.Image"), System.Drawing.Image)
        Me.btnRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(28, 28)
        Me.btnRefrescar.Text = "ToolStripButton1"
        Me.btnRefrescar.ToolTipText = "Refrescar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cbCobrador)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtNumero)
        Me.UiGroupBox1.Controls.Add(Me.cbMes)
        Me.UiGroupBox1.Controls.Add(Me.txtPeriodo)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(3, 33)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(756, 59)
        Me.UiGroupBox1.TabIndex = 7
        Me.UiGroupBox1.Text = "Datos de Busqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(501, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Numero"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Periodo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(108, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Mes"
        '
        'dgDetalle
        '
        Me.dgDetalle.AllowCardSizing = False
        Me.dgDetalle.AllowColumnDrag = False
        Me.dgDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgDetalle.AlternatingColors = True
        Me.dgDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDetalle.ContextMenuStrip = Me.ContextMenuStrip1
        dgDetalle_DesignTimeLayout.LayoutString = resources.GetString("dgDetalle_DesignTimeLayout.LayoutString")
        Me.dgDetalle.DesignTimeLayout = dgDetalle_DesignTimeLayout
        Me.dgDetalle.EmptyRows = True
        Me.dgDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgDetalle.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgDetalle.GroupByBoxVisible = False
        Me.dgDetalle.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgDetalle.Location = New System.Drawing.Point(5, 11)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.RowFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dgDetalle.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgDetalle.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgDetalle.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgDetalle.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgDetalle.Size = New System.Drawing.Size(738, 418)
        Me.dgDetalle.TabIndex = 33
        Me.dgDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox2.Controls.Add(Me.dgDetalle)
        Me.UiGroupBox2.Location = New System.Drawing.Point(3, 92)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(760, 435)
        Me.UiGroupBox2.TabIndex = 52
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'ssBarra
        '
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslbMensaje, Me.sslbTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 566)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(769, 22)
        Me.ssBarra.TabIndex = 53
        Me.ssBarra.Text = "StatusStrip1"
        '
        'sslbMensaje
        '
        Me.sslbMensaje.AutoSize = False
        Me.sslbMensaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslbMensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sslbMensaje.Name = "sslbMensaje"
        Me.sslbMensaje.Size = New System.Drawing.Size(450, 17)
        '
        'sslbTotal
        '
        Me.sslbTotal.AutoSize = False
        Me.sslbTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslbTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sslbTotal.Name = "sslbTotal"
        Me.sslbTotal.Size = New System.Drawing.Size(200, 17)
        Me.sslbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.txtTotalPagos)
        Me.UiGroupBox3.Controls.Add(Me.txtTotalDifCam)
        Me.UiGroupBox3.Controls.Add(Me.txtTotalDoc)
        Me.UiGroupBox3.Controls.Add(Me.Label7)
        Me.UiGroupBox3.Controls.Add(Me.Label1)
        Me.UiGroupBox3.Controls.Add(Me.Label6)
        Me.UiGroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox3.Location = New System.Drawing.Point(0, 528)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(769, 38)
        Me.UiGroupBox3.TabIndex = 96
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalPagos
        '
        Me.txtTotalPagos.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalPagos.Enabled = False
        Me.txtTotalPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagos.FormatString = "n"
        Me.txtTotalPagos.Location = New System.Drawing.Point(591, 13)
        Me.txtTotalPagos.Name = "txtTotalPagos"
        Me.txtTotalPagos.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalPagos.TabIndex = 5
        Me.txtTotalPagos.Text = "0.00"
        Me.txtTotalPagos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalDifCam
        '
        Me.txtTotalDifCam.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalDifCam.Enabled = False
        Me.txtTotalDifCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDifCam.FormatString = "n"
        Me.txtTotalDifCam.Location = New System.Drawing.Point(357, 13)
        Me.txtTotalDifCam.Name = "txtTotalDifCam"
        Me.txtTotalDifCam.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalDifCam.TabIndex = 4
        Me.txtTotalDifCam.Text = "0.00"
        Me.txtTotalDifCam.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalDoc
        '
        Me.txtTotalDoc.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalDoc.Enabled = False
        Me.txtTotalDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDoc.FormatString = "n"
        Me.txtTotalDoc.Location = New System.Drawing.Point(101, 12)
        Me.txtTotalDoc.Name = "txtTotalDoc"
        Me.txtTotalDoc.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalDoc.TabIndex = 3
        Me.txtTotalDoc.Text = "0.00"
        Me.txtTotalDoc.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(507, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Total Pagos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(253, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total Dif. Camb."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Total Docs."
        '
        'frmPlanillas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(769, 588)
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanillas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla de Cobranzas"
        CType(Me.cbCobrador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.cbMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbCobrador As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmBorrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmRefrescar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslbMensaje As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslbTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmAprobar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAprobar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmRevertir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRevertir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalPagos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDifCam As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDoc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
