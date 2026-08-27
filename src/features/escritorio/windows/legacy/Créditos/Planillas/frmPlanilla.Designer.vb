<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanilla
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
        Dim dgDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgPagos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbCobrador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanilla))
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.TabOpciones = New Janus.Windows.UI.Tab.UITab()
        Me.tbDocumentos = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgDetalle = New Janus.Windows.GridEX.GridEX()
        Me.CMenuDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmBorrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmRefrescar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbPagos = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgPagos = New Janus.Windows.GridEX.GridEX()
        Me.CMenuPagos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmNuevoPago = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmModificarPago = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmBorrarPago = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmMostrarPago = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmRefrescarPagos = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbCobrador = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalPagos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDifCam = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDoc = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabOpciones.SuspendLayout()
        Me.tbDocumentos.SuspendLayout()
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuDetalle.SuspendLayout()
        Me.tbPagos.SuspendLayout()
        CType(Me.dgPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuPagos.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cbCobrador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.Text = "ToolStripButton1"
        Me.btnGuardar.ToolTipText = "Guardar"
        '
        'btnModificar
        '
        Me.btnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnModificar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(28, 28)
        Me.btnModificar.Text = "ToolStripButton1"
        Me.btnModificar.ToolTipText = "Modificar"
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(28, 28)
        Me.btnCancelar.Text = "ToolStripButton1"
        Me.btnCancelar.ToolTipText = "Cancelar"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnModificar, Me.ToolStripSeparator1, Me.btnGuardar, Me.ToolStripSeparator2, Me.btnCancelar, Me.ToolStripSeparator3, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(858, 31)
        Me.ToolStrip1.TabIndex = 78
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'btnSalir
        '
        Me.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(28, 28)
        Me.btnSalir.Text = "ToolStripButton1"
        Me.btnSalir.ToolTipText = "Salir de la Ventana"
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'TabOpciones
        '
        Me.TabOpciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabOpciones.Location = New System.Drawing.Point(4, 72)
        Me.TabOpciones.Name = "TabOpciones"
        Me.TabOpciones.Size = New System.Drawing.Size(818, 401)
        Me.TabOpciones.TabIndex = 93
        Me.TabOpciones.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tbDocumentos, Me.tbPagos})
        Me.TabOpciones.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003
        '
        'tbDocumentos
        '
        Me.tbDocumentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDocumentos.Controls.Add(Me.dgDetalle)
        Me.tbDocumentos.Icon = CType(resources.GetObject("tbDocumentos.Icon"), System.Drawing.Icon)
        Me.tbDocumentos.Location = New System.Drawing.Point(1, 23)
        Me.tbDocumentos.Name = "tbDocumentos"
        Me.tbDocumentos.Size = New System.Drawing.Size(816, 377)
        Me.tbDocumentos.TabStop = True
        Me.tbDocumentos.Text = "Documentos"
        '
        'dgDetalle
        '
        Me.dgDetalle.AllowCardSizing = False
        Me.dgDetalle.AllowColumnDrag = False
        Me.dgDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgDetalle.AlternatingColors = True
        Me.dgDetalle.ContextMenuStrip = Me.CMenuDetalle
        dgDetalle_DesignTimeLayout.LayoutString = resources.GetString("dgDetalle_DesignTimeLayout.LayoutString")
        Me.dgDetalle.DesignTimeLayout = dgDetalle_DesignTimeLayout
        Me.dgDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDetalle.EmptyRows = True
        Me.dgDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgDetalle.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgDetalle.GroupByBoxVisible = False
        Me.dgDetalle.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgDetalle.Location = New System.Drawing.Point(0, 0)
        Me.dgDetalle.Name = "dgDetalle"
        Me.dgDetalle.RowFormatStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dgDetalle.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.dgDetalle.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgDetalle.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgDetalle.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgDetalle.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgDetalle.Size = New System.Drawing.Size(816, 377)
        Me.dgDetalle.TabIndex = 50
        Me.dgDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CMenuDetalle
        '
        Me.CMenuDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmNuevo, Me.cmModificar, Me.cmBorrar, Me.ToolStripSeparator4, Me.cmMostrar, Me.cmRefrescar})
        Me.CMenuDetalle.Name = "ContextMenuStrip1"
        Me.CMenuDetalle.Size = New System.Drawing.Size(126, 120)
        '
        'cmNuevo
        '
        Me.cmNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.cmNuevo.Name = "cmNuevo"
        Me.cmNuevo.Size = New System.Drawing.Size(125, 22)
        Me.cmNuevo.Text = "Nuevo"
        Me.cmNuevo.ToolTipText = "Nuevo Detalle"
        '
        'cmModificar
        '
        Me.cmModificar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.cmModificar.Name = "cmModificar"
        Me.cmModificar.Size = New System.Drawing.Size(125, 22)
        Me.cmModificar.Text = "Modificar"
        Me.cmModificar.ToolTipText = "Modificar Detalle"
        '
        'cmBorrar
        '
        Me.cmBorrar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.cmBorrar.Name = "cmBorrar"
        Me.cmBorrar.Size = New System.Drawing.Size(125, 22)
        Me.cmBorrar.Text = "Borrar"
        Me.cmBorrar.ToolTipText = "Borrar Detalle"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(122, 6)
        '
        'cmMostrar
        '
        Me.cmMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.cmMostrar.Name = "cmMostrar"
        Me.cmMostrar.Size = New System.Drawing.Size(125, 22)
        Me.cmMostrar.Text = "Mostrar"
        Me.cmMostrar.ToolTipText = "Mostrar Detalle"
        '
        'cmRefrescar
        '
        Me.cmRefrescar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.cmRefrescar.Name = "cmRefrescar"
        Me.cmRefrescar.Size = New System.Drawing.Size(125, 22)
        Me.cmRefrescar.Text = "Refrescar"
        Me.cmRefrescar.ToolTipText = "Refrescar Detalles"
        '
        'tbPagos
        '
        Me.tbPagos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPagos.Controls.Add(Me.dgPagos)
        Me.tbPagos.Icon = CType(resources.GetObject("tbPagos.Icon"), System.Drawing.Icon)
        Me.tbPagos.Location = New System.Drawing.Point(1, 23)
        Me.tbPagos.Name = "tbPagos"
        Me.tbPagos.Size = New System.Drawing.Size(816, 377)
        Me.tbPagos.TabStop = True
        Me.tbPagos.Text = "Pagos"
        '
        'dgPagos
        '
        Me.dgPagos.AllowCardSizing = False
        Me.dgPagos.AllowColumnDrag = False
        Me.dgPagos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgPagos.AlternatingColors = True
        Me.dgPagos.ContextMenuStrip = Me.CMenuPagos
        dgPagos_DesignTimeLayout.LayoutString = resources.GetString("dgPagos_DesignTimeLayout.LayoutString")
        Me.dgPagos.DesignTimeLayout = dgPagos_DesignTimeLayout
        Me.dgPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPagos.EmptyRows = True
        Me.dgPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dgPagos.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgPagos.GroupByBoxVisible = False
        Me.dgPagos.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgPagos.Location = New System.Drawing.Point(0, 0)
        Me.dgPagos.Name = "dgPagos"
        Me.dgPagos.RowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.dgPagos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgPagos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgPagos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgPagos.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgPagos.Size = New System.Drawing.Size(816, 377)
        Me.dgPagos.TabIndex = 51
        Me.dgPagos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CMenuPagos
        '
        Me.CMenuPagos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmNuevoPago, Me.cmModificarPago, Me.cmBorrarPago, Me.ToolStripSeparator5, Me.cmMostrarPago, Me.cmRefrescarPagos})
        Me.CMenuPagos.Name = "ContextMenuStrip1"
        Me.CMenuPagos.Size = New System.Drawing.Size(126, 120)
        '
        'cmNuevoPago
        '
        Me.cmNuevoPago.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.cmNuevoPago.Name = "cmNuevoPago"
        Me.cmNuevoPago.Size = New System.Drawing.Size(125, 22)
        Me.cmNuevoPago.Text = "Nuevo"
        Me.cmNuevoPago.ToolTipText = "Nuevo Pago"
        '
        'cmModificarPago
        '
        Me.cmModificarPago.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.cmModificarPago.Name = "cmModificarPago"
        Me.cmModificarPago.Size = New System.Drawing.Size(125, 22)
        Me.cmModificarPago.Text = "Modificar"
        Me.cmModificarPago.ToolTipText = "Modificar Pago"
        '
        'cmBorrarPago
        '
        Me.cmBorrarPago.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.cmBorrarPago.Name = "cmBorrarPago"
        Me.cmBorrarPago.Size = New System.Drawing.Size(125, 22)
        Me.cmBorrarPago.Text = "Borrar"
        Me.cmBorrarPago.ToolTipText = "Borrar Pago"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(122, 6)
        '
        'cmMostrarPago
        '
        Me.cmMostrarPago.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.cmMostrarPago.Name = "cmMostrarPago"
        Me.cmMostrarPago.Size = New System.Drawing.Size(125, 22)
        Me.cmMostrarPago.Text = "Mostrar"
        Me.cmMostrarPago.ToolTipText = "Mostrar Pago"
        '
        'cmRefrescarPagos
        '
        Me.cmRefrescarPagos.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.cmRefrescarPagos.Name = "cmRefrescarPagos"
        Me.cmRefrescarPagos.Size = New System.Drawing.Size(125, 22)
        Me.cmRefrescarPagos.Text = "Refrescar"
        Me.cmRefrescarPagos.ToolTipText = "Refrescar Pagos"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtFecha)
        Me.UiGroupBox1.Controls.Add(Me.cbCobrador)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtTipoCambio)
        Me.UiGroupBox1.Controls.Add(Me.txtNumero)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(4, 28)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(732, 40)
        Me.UiGroupBox1.TabIndex = 94
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.Location = New System.Drawing.Point(190, 12)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(93, 20)
        Me.txtFecha.TabIndex = 3
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbCobrador
        '
        Me.cbCobrador.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbCobrador_DesignTimeLayout.LayoutString = resources.GetString("cbCobrador_DesignTimeLayout.LayoutString")
        Me.cbCobrador.DesignTimeLayout = cbCobrador_DesignTimeLayout
        Me.cbCobrador.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.cbCobrador.Enabled = False
        Me.cbCobrador.Location = New System.Drawing.Point(477, 12)
        Me.cbCobrador.Name = "cbCobrador"
        Me.cbCobrador.SelectedIndex = -1
        Me.cbCobrador.SelectedItem = Nothing
        Me.cbCobrador.Size = New System.Drawing.Size(250, 20)
        Me.cbCobrador.TabIndex = 7
        Me.cbCobrador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(411, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Cobrador :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Fecha :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Planilla :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(284, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "T.Cambio :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(352, 12)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(59, 20)
        Me.txtTipoCambio.TabIndex = 5
        Me.txtTipoCambio.TabStop = False
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(58, 12)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(81, 20)
        Me.txtNumero.TabIndex = 1
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtTotalPagos)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalDifCam)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalDoc)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox2.Location = New System.Drawing.Point(0, 503)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(858, 38)
        Me.UiGroupBox2.TabIndex = 95
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalPagos
        '
        Me.txtTotalPagos.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalPagos.Enabled = False
        Me.txtTotalPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagos.FormatString = "n"
        Me.txtTotalPagos.Location = New System.Drawing.Point(591, 12)
        Me.txtTotalPagos.Name = "txtTotalPagos"
        Me.txtTotalPagos.ReadOnly = True
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
        Me.txtTotalDifCam.Location = New System.Drawing.Point(357, 12)
        Me.txtTotalDifCam.Name = "txtTotalDifCam"
        Me.txtTotalDifCam.ReadOnly = True
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
        Me.txtTotalDoc.Location = New System.Drawing.Point(108, 11)
        Me.txtTotalDoc.Name = "txtTotalDoc"
        Me.txtTotalDoc.ReadOnly = True
        Me.txtTotalDoc.Size = New System.Drawing.Size(89, 20)
        Me.txtTotalDoc.TabIndex = 3
        Me.txtTotalDoc.Text = "0.00"
        Me.txtTotalDoc.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(507, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Total Pagos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(253, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Total Dif. Camb."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total a Pagar."
        '
        'frmPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 541)
        Me.ControlBox = False
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TabOpciones)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanilla"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Planilla"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabOpciones.ResumeLayout(False)
        Me.tbDocumentos.ResumeLayout(False)
        CType(Me.dgDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuDetalle.ResumeLayout(False)
        Me.tbPagos.ResumeLayout(False)
        CType(Me.dgPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuPagos.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cbCobrador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents TabOpciones As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tbDocumentos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents tbPagos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgPagos As Janus.Windows.GridEX.GridEX
    Friend WithEvents CMenuDetalle As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmBorrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmRefrescar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuPagos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmNuevoPago As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmModificarPago As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmBorrarPago As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmMostrarPago As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmRefrescarPagos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbCobrador As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalDoc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPagos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDifCam As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo

End Class
