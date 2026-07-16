<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComOrdenCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComOrdenCompra))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbContacto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDescargarExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImportarExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblTotalNeto = New System.Windows.Forms.TextBox()
        Me.lbltotalIGV = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.TextBox()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalIGV = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFecEntrega = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumCotizacion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtNumOrden = New System.Windows.Forms.TextBox()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtObsOrden = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbCodPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPersonaSolicita = New System.Windows.Forms.TextBox()
        Me.btnBuscarPersonaA = New System.Windows.Forms.Button()
        Me.btnBuscarPersonaS = New System.Windows.Forms.Button()
        Me.txtPersonaAutoriza = New System.Windows.Forms.TextBox()
        Me.txtCodUsu = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.txtLugarEntrega = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnObservacion = New System.Windows.Forms.Button()
        Me.gbProveedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.txtFormaPago = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbContacto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblSolicitud = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbCodMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbCodPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        CType(Me.cmbContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miActMasivo, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(168, 126)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(167, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(167, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(167, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miActMasivo
        '
        Me.miActMasivo.Image = CType(resources.GetObject("miActMasivo.Image"), System.Drawing.Image)
        Me.miActMasivo.Name = "miActMasivo"
        Me.miActMasivo.Size = New System.Drawing.Size(167, 22)
        Me.miActMasivo.Text = "Actualizar Masivo"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(164, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(164, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(167, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 615)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(812, 20)
        Me.ssBarra.TabIndex = 181
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
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator11, Me.biGrabar, Me.ToolStripSeparator1, Me.biEditar, Me.ToolStripSeparator13, Me.biDeshacer, Me.ToolStripSeparator14, Me.biDescargarExcel, Me.ToolStripSeparator2, Me.biImportarExcel, Me.ToolStripSeparator3, Me.biSalir, Me.ToolStripSeparator15})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(812, 31)
        Me.ToolStrip.TabIndex = 180
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'biGrabar
        '
        Me.biGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGrabar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGrabar.Name = "biGrabar"
        Me.biGrabar.Size = New System.Drawing.Size(28, 28)
        Me.biGrabar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Cabecera"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'biDescargarExcel
        '
        Me.biDescargarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDescargarExcel.Image = CType(resources.GetObject("biDescargarExcel.Image"), System.Drawing.Image)
        Me.biDescargarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDescargarExcel.Name = "biDescargarExcel"
        Me.biDescargarExcel.Size = New System.Drawing.Size(28, 28)
        Me.biDescargarExcel.Text = "Descargar Formato Excel"
        Me.biDescargarExcel.ToolTipText = "Descargar Formato Excel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biImportarExcel
        '
        Me.biImportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImportarExcel.Image = CType(resources.GetObject("biImportarExcel.Image"), System.Drawing.Image)
        Me.biImportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImportarExcel.Name = "biImportarExcel"
        Me.biImportarExcel.Size = New System.Drawing.Size(28, 28)
        Me.biImportarExcel.Text = "Cargar Formato Excel"
        Me.biImportarExcel.ToolTipText = "Cargar Formato Excel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDetalle
        '
        Me.gbDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Controls.Add(Me.UiGroupBox6)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(5, 335)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(795, 258)
        Me.gbDetalle.TabIndex = 184
        Me.gbDetalle.Text = "Detalles"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(7, 19)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(781, 147)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.lblTotalNeto)
        Me.UiGroupBox6.Controls.Add(Me.lbltotalIGV)
        Me.UiGroupBox6.Controls.Add(Me.lblTotal)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalNeto)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalIGV)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalPrecio)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalDescuento)
        Me.UiGroupBox6.Controls.Add(Me.txtTotal)
        Me.UiGroupBox6.Location = New System.Drawing.Point(7, 172)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(778, 80)
        Me.UiGroupBox6.TabIndex = 22
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalNeto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalNeto.Location = New System.Drawing.Point(6, 52)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(671, 20)
        Me.lblTotalNeto.TabIndex = 10
        Me.lblTotalNeto.TabStop = False
        Me.lblTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotalIGV
        '
        Me.lbltotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lbltotalIGV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lbltotalIGV.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lbltotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalIGV.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltotalIGV.Location = New System.Drawing.Point(6, 33)
        Me.lbltotalIGV.MaxLength = 20
        Me.lbltotalIGV.Name = "lbltotalIGV"
        Me.lbltotalIGV.ReadOnly = True
        Me.lbltotalIGV.Size = New System.Drawing.Size(671, 20)
        Me.lbltotalIGV.TabIndex = 9
        Me.lbltotalIGV.TabStop = False
        Me.lbltotalIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotal.Location = New System.Drawing.Point(6, 14)
        Me.lblTotal.MaxLength = 20
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.ReadOnly = True
        Me.lblTotal.Size = New System.Drawing.Size(512, 20)
        Me.lblTotal.TabIndex = 8
        Me.lblTotal.TabStop = False
        Me.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNeto.Location = New System.Drawing.Point(676, 52)
        Me.txtTotalNeto.MaxLength = 5
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalNeto.TabIndex = 6
        Me.txtTotalNeto.TabStop = False
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalIGV
        '
        Me.txtTotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIGV.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalIGV.Location = New System.Drawing.Point(676, 33)
        Me.txtTotalIGV.MaxLength = 5
        Me.txtTotalIGV.Name = "txtTotalIGV"
        Me.txtTotalIGV.ReadOnly = True
        Me.txtTotalIGV.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalIGV.TabIndex = 5
        Me.txtTotalIGV.TabStop = False
        Me.txtTotalIGV.Text = "0.00"
        Me.txtTotalIGV.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalIGV.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIGV.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalPrecio
        '
        Me.txtTotalPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrecio.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalPrecio.Location = New System.Drawing.Point(517, 14)
        Me.txtTotalPrecio.MaxLength = 5
        Me.txtTotalPrecio.Name = "txtTotalPrecio"
        Me.txtTotalPrecio.ReadOnly = True
        Me.txtTotalPrecio.Size = New System.Drawing.Size(93, 20)
        Me.txtTotalPrecio.TabIndex = 1
        Me.txtTotalPrecio.TabStop = False
        Me.txtTotalPrecio.Text = "0.00"
        Me.txtTotalPrecio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalPrecio.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDescuento.Location = New System.Drawing.Point(609, 14)
        Me.txtTotalDescuento.MaxLength = 5
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(68, 20)
        Me.txtTotalDescuento.TabIndex = 2
        Me.txtTotalDescuento.TabStop = False
        Me.txtTotalDescuento.Text = "0.00"
        Me.txtTotalDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalDescuento.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotal.Location = New System.Drawing.Point(676, 14)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(84, 20)
        Me.txtTotal.TabIndex = 3
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 258)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Observación"
        '
        'txtFecEntrega
        '
        '
        '
        '
        Me.txtFecEntrega.DropDownCalendar.Name = ""
        Me.txtFecEntrega.DropDownCalendar.Visible = False
        Me.txtFecEntrega.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecEntrega.Location = New System.Drawing.Point(108, 165)
        Me.txtFecEntrega.Name = "txtFecEntrega"
        Me.txtFecEntrega.NullButtonText = "Ninguno"
        Me.txtFecEntrega.Size = New System.Drawing.Size(92, 20)
        Me.txtFecEntrega.TabIndex = 9
        Me.txtFecEntrega.TodayButtonText = "Hoy"
        Me.txtFecEntrega.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fec. Entrega"
        '
        'txtNumCotizacion
        '
        Me.txtNumCotizacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumCotizacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumCotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCotizacion.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumCotizacion.Location = New System.Drawing.Point(364, 165)
        Me.txtNumCotizacion.MaxLength = 20
        Me.txtNumCotizacion.Name = "txtNumCotizacion"
        Me.txtNumCotizacion.Size = New System.Drawing.Size(100, 20)
        Me.txtNumCotizacion.TabIndex = 10
        Me.txtNumCotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(292, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Cotización"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº Orden"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(384, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Moneda"
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.Color.Transparent
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(621, 7)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(162, 40)
        Me.gbEstado.TabIndex = 0
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(4, 13)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(149, 21)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNumOrden
        '
        Me.txtNumOrden.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumOrden.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumOrden.Location = New System.Drawing.Point(108, 22)
        Me.txtNumOrden.MaxLength = 20
        Me.txtNumOrden.Name = "txtNumOrden"
        Me.txtNumOrden.ReadOnly = True
        Me.txtNumOrden.Size = New System.Drawing.Size(100, 20)
        Me.txtNumOrden.TabIndex = 1
        Me.txtNumOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.Location = New System.Drawing.Point(276, 22)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(94, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(226, 27)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "Fecha"
        '
        'txtObsOrden
        '
        Me.txtObsOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObsOrden.Location = New System.Drawing.Point(108, 246)
        Me.txtObsOrden.Multiline = True
        Me.txtObsOrden.Name = "txtObsOrden"
        Me.txtObsOrden.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObsOrden.Size = New System.Drawing.Size(648, 42)
        Me.txtObsOrden.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(506, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "I.G.V."
        '
        'txtIgv
        '
        Me.txtIgv.Location = New System.Drawing.Point(549, 22)
        Me.txtIgv.MaxLength = 12
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.Size = New System.Drawing.Size(53, 20)
        Me.txtIgv.TabIndex = 4
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodPago
        '
        Me.cmbCodPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodPago_DesignTimeLayout.LayoutString = resources.GetString("cmbCodPago_DesignTimeLayout.LayoutString")
        Me.cmbCodPago.DesignTimeLayout = cmbCodPago_DesignTimeLayout
        Me.cmbCodPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodPago.Location = New System.Drawing.Point(102, 45)
        Me.cmbCodPago.Name = "cmbCodPago"
        Me.cmbCodPago.SelectedIndex = -1
        Me.cmbCodPago.SelectedItem = Nothing
        Me.cmbCodPago.Size = New System.Drawing.Size(211, 19)
        Me.cmbCodPago.TabIndex = 8
        Me.cmbCodPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cond. de Pago"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Solicitado Por"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Autorizado Por"
        '
        'txtPersonaSolicita
        '
        Me.txtPersonaSolicita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonaSolicita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonaSolicita.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersonaSolicita.Location = New System.Drawing.Point(108, 192)
        Me.txtPersonaSolicita.MaxLength = 3
        Me.txtPersonaSolicita.Name = "txtPersonaSolicita"
        Me.txtPersonaSolicita.ReadOnly = True
        Me.txtPersonaSolicita.Size = New System.Drawing.Size(356, 20)
        Me.txtPersonaSolicita.TabIndex = 13
        '
        'btnBuscarPersonaA
        '
        Me.btnBuscarPersonaA.Image = CType(resources.GetObject("btnBuscarPersonaA.Image"), System.Drawing.Image)
        Me.btnBuscarPersonaA.Location = New System.Drawing.Point(470, 218)
        Me.btnBuscarPersonaA.Name = "btnBuscarPersonaA"
        Me.btnBuscarPersonaA.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersonaA.TabIndex = 12
        Me.btnBuscarPersonaA.TabStop = False
        Me.btnBuscarPersonaA.UseVisualStyleBackColor = True
        Me.btnBuscarPersonaA.Visible = False
        '
        'btnBuscarPersonaS
        '
        Me.btnBuscarPersonaS.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersonaS.Location = New System.Drawing.Point(470, 192)
        Me.btnBuscarPersonaS.Name = "btnBuscarPersonaS"
        Me.btnBuscarPersonaS.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersonaS.TabIndex = 11
        Me.btnBuscarPersonaS.TabStop = False
        Me.btnBuscarPersonaS.UseVisualStyleBackColor = True
        '
        'txtPersonaAutoriza
        '
        Me.txtPersonaAutoriza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonaAutoriza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonaAutoriza.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPersonaAutoriza.Location = New System.Drawing.Point(108, 219)
        Me.txtPersonaAutoriza.MaxLength = 3
        Me.txtPersonaAutoriza.Name = "txtPersonaAutoriza"
        Me.txtPersonaAutoriza.ReadOnly = True
        Me.txtPersonaAutoriza.Size = New System.Drawing.Size(387, 20)
        Me.txtPersonaAutoriza.TabIndex = 14
        Me.txtPersonaAutoriza.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCodUsu
        '
        Me.txtCodUsu.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCodUsu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodUsu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodUsu.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodUsu.Location = New System.Drawing.Point(616, 219)
        Me.txtCodUsu.MaxLength = 20
        Me.txtCodUsu.Name = "txtCodUsu"
        Me.txtCodUsu.ReadOnly = True
        Me.txtCodUsu.Size = New System.Drawing.Size(162, 20)
        Me.txtCodUsu.TabIndex = 15
        Me.txtCodUsu.TabStop = False
        Me.txtCodUsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(102, 16)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(307, 20)
        Me.txtProveedor.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Proveedor"
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(408, 15)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 5
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(546, 196)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Area"
        '
        'cmbArea
        '
        Me.cmbArea.BackColor = System.Drawing.SystemColors.Control
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(604, 192)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.ReadOnly = True
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(174, 20)
        Me.cmbArea.TabIndex = 12
        Me.cmbArea.TabStop = False
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.DataGridView2)
        Me.UiGroupBox2.Controls.Add(Me.txtLugarEntrega)
        Me.UiGroupBox2.Controls.Add(Me.DataGridView1)
        Me.UiGroupBox2.Controls.Add(Me.Label19)
        Me.UiGroupBox2.Controls.Add(Me.btnObservacion)
        Me.UiGroupBox2.Controls.Add(Me.gbProveedor)
        Me.UiGroupBox2.Controls.Add(Me.lblSolicitud)
        Me.UiGroupBox2.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox2.Controls.Add(Me.Label13)
        Me.UiGroupBox2.Controls.Add(Me.txtPersonaSolicita)
        Me.UiGroupBox2.Controls.Add(Me.txtCodUsu)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarPersonaS)
        Me.UiGroupBox2.Controls.Add(Me.txtPersonaAutoriza)
        Me.UiGroupBox2.Controls.Add(Me.cmbArea)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.txtNumCotizacion)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarPersonaA)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtFecEntrega)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.txtIgv)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.txtObsOrden)
        Me.UiGroupBox2.Controls.Add(Me.lblFecha)
        Me.UiGroupBox2.Controls.Add(Me.txtFecha)
        Me.UiGroupBox2.Controls.Add(Me.txtNumOrden)
        Me.UiGroupBox2.Controls.Add(Me.gbEstado)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.Label21)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(5, 34)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(791, 295)
        Me.UiGroupBox2.TabIndex = 183
        Me.UiGroupBox2.Text = "Cabecera"
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(706, 164)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(32, 20)
        Me.DataGridView2.TabIndex = 186
        Me.DataGridView2.Visible = False
        '
        'txtLugarEntrega
        '
        Me.txtLugarEntrega.Location = New System.Drawing.Point(132, 138)
        Me.txtLugarEntrega.Name = "txtLugarEntrega"
        Me.txtLugarEntrega.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLugarEntrega.Size = New System.Drawing.Size(646, 20)
        Me.txtLugarEntrega.TabIndex = 8
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(746, 164)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(32, 20)
        Me.DataGridView1.TabIndex = 185
        Me.DataGridView1.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 141)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(113, 13)
        Me.Label19.TabIndex = 195
        Me.Label19.Text = "Lugar de Entrega :"
        '
        'btnObservacion
        '
        Me.btnObservacion.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnObservacion.Location = New System.Drawing.Point(760, 254)
        Me.btnObservacion.Name = "btnObservacion"
        Me.btnObservacion.Size = New System.Drawing.Size(25, 24)
        Me.btnObservacion.TabIndex = 37
        Me.btnObservacion.TabStop = False
        Me.btnObservacion.UseVisualStyleBackColor = True
        '
        'gbProveedor
        '
        Me.gbProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.gbProveedor.Controls.Add(Me.btnAgregarProveedor)
        Me.gbProveedor.Controls.Add(Me.txtFormaPago)
        Me.gbProveedor.Controls.Add(Me.Label18)
        Me.gbProveedor.Controls.Add(Me.cmbContacto)
        Me.gbProveedor.Controls.Add(Me.Label17)
        Me.gbProveedor.Controls.Add(Me.Label12)
        Me.gbProveedor.Controls.Add(Me.txtProveedor)
        Me.gbProveedor.Controls.Add(Me.btnBuscarProveedor)
        Me.gbProveedor.Controls.Add(Me.cmbCodPago)
        Me.gbProveedor.Controls.Add(Me.Label6)
        Me.gbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProveedor.ForeColor = System.Drawing.Color.Black
        Me.gbProveedor.Location = New System.Drawing.Point(6, 48)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(779, 85)
        Me.gbProveedor.TabIndex = 5
        Me.gbProveedor.Text = "Proveedor"
        Me.gbProveedor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnAgregarProveedor
        '
        Me.btnAgregarProveedor.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnAgregarProveedor.Location = New System.Drawing.Point(436, 15)
        Me.btnAgregarProveedor.Name = "btnAgregarProveedor"
        Me.btnAgregarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarProveedor.TabIndex = 188
        Me.btnAgregarProveedor.TabStop = False
        '
        'txtFormaPago
        '
        Me.txtFormaPago.Location = New System.Drawing.Point(441, 41)
        Me.txtFormaPago.Multiline = True
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFormaPago.Size = New System.Drawing.Size(331, 36)
        Me.txtFormaPago.TabIndex = 43
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(343, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 13)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Forma de Pago"
        '
        'cmbContacto
        '
        Me.cmbContacto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbContacto_DesignTimeLayout.LayoutString = resources.GetString("cmbContacto_DesignTimeLayout.LayoutString")
        Me.cmbContacto.DesignTimeLayout = cmbContacto_DesignTimeLayout
        Me.cmbContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbContacto.Location = New System.Drawing.Point(523, 16)
        Me.cmbContacto.Name = "cmbContacto"
        Me.cmbContacto.SelectedIndex = -1
        Me.cmbContacto.SelectedItem = Nothing
        Me.cmbContacto.Size = New System.Drawing.Size(249, 19)
        Me.cmbContacto.TabIndex = 7
        Me.cmbContacto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(462, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Contacto"
        '
        'lblSolicitud
        '
        Me.lblSolicitud.AutoSize = True
        Me.lblSolicitud.Location = New System.Drawing.Point(413, 0)
        Me.lblSolicitud.Name = "lblSolicitud"
        Me.lblSolicitud.Size = New System.Drawing.Size(14, 13)
        Me.lblSolicitud.TabIndex = 36
        Me.lblSolicitud.Text = "0"
        Me.lblSolicitud.Visible = False
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(439, 21)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(58, 20)
        Me.cmbMoneda.TabIndex = 3
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(518, 223)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Originado Por"
        '
        'cmbCodMoneda
        '
        Me.cmbCodMoneda.BackColor = System.Drawing.SystemColors.InfoText
        Me.cmbCodMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMoneda_DesignTimeLayout.LayoutString")
        Me.cmbCodMoneda.DesignTimeLayout = cmbCodMoneda_DesignTimeLayout
        Me.cmbCodMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodMoneda.Location = New System.Drawing.Point(440, 17)
        Me.cmbCodMoneda.Name = "cmbCodMoneda"
        Me.cmbCodMoneda.SelectedIndex = -1
        Me.cmbCodMoneda.SelectedItem = Nothing
        Me.cmbCodMoneda.Size = New System.Drawing.Size(47, 20)
        Me.cmbCodMoneda.TabIndex = 8767
        Me.cmbCodMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmComOrdenCompra
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(812, 635)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComOrdenCompra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de Compra"
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.cmbCodPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        CType(Me.cmbContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalIGV As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalIGV As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtPersonaSolicita As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPersonaS As System.Windows.Forms.Button
    Friend WithEvents txtPersonaAutoriza As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPersonaA As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents txtCodUsu As System.Windows.Forms.TextBox
    Friend WithEvents cmbCodPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtObsOrden As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtNumOrden As System.Windows.Forms.TextBox
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFecEntrega As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbCodMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblSolicitud As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents gbProveedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbContacto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnObservacion As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFormaPago As System.Windows.Forms.TextBox
    Friend WithEvents txtLugarEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents miActMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biDescargarExcel As ToolStripButton
    Friend WithEvents biImportarExcel As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnAgregarProveedor As Janus.Windows.EditControls.UIButton
End Class
