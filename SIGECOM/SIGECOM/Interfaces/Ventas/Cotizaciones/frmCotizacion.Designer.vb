<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCotizacion
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodPag_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCotizacion))
        Dim cmbIdContacto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSugerir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarDetalles = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miAgregarPlantilla = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAgregarConsumoJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miFormatoExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.miImportarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalNetoSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalIgvSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalNeto = New System.Windows.Forms.TextBox()
        Me.lbltotalIGV = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.TextBox()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalIGV = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbCodPag = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtNumCot = New System.Windows.Forms.TextBox()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.btnAgregarCliente = New System.Windows.Forms.Button()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtObsDet = New System.Windows.Forms.RichTextBox()
        Me.txtObsCab = New System.Windows.Forms.RichTextBox()
        Me.btnModificarDetalle = New System.Windows.Forms.Button()
        Me.btnModificarCabecera = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAgregarContacto = New System.Windows.Forms.Button()
        Me.txtFacCli = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDscCli = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cmbIdContacto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtDiasValidez = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtGarantia = New System.Windows.Forms.TextBox()
        Me.txtProyecto = New System.Windows.Forms.TextBox()
        Me.txtEntrega = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtValidez = New System.Windows.Forms.TextBox()
        Me.txtPlazo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmOpcionesAtender = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeterCEROTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.biSugerir = New System.Windows.Forms.ToolStripButton()
        Me.btnGenerarDocumento = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRecalcularDscto = New System.Windows.Forms.ToolStripButton()
        Me.biActMoneda = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvImportarExcel = New System.Windows.Forms.DataGridView()
        Me.dgvFormatoExcel = New System.Windows.Forms.DataGridView()
        Me.cbExportacion = New System.Windows.Forms.CheckBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.cmbIdContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.cmOpcionesAtender.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.dgvImportarExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFormatoExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvDatos)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 260)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(857, 359)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lista de Detalle"
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 19)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(848, 212)
        Me.dgvDatos.TabIndex = 19
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSugerir, Me.miNuevo, Me.miModificar, Me.miEliminar, Me.miEliminarDetalles, Me.ToolStripMenuItem1, Me.miAgregarPlantilla, Me.miAgregarConsumoJob, Me.ToolStripSeparator2, Me.miFormatoExcel, Me.miImportarExcel, Me.ToolStripSeparator3, Me.miActualizar, Me.miBuscar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(193, 264)
        '
        'miSugerir
        '
        Me.miSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.miSugerir.Name = "miSugerir"
        Me.miSugerir.Size = New System.Drawing.Size(192, 22)
        Me.miSugerir.Text = "Sugerir"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(192, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miModificar
        '
        Me.miModificar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miModificar.Name = "miModificar"
        Me.miModificar.Size = New System.Drawing.Size(192, 22)
        Me.miModificar.Text = "Modificar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(192, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miEliminarDetalles
        '
        Me.miEliminarDetalles.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarDetalles.Name = "miEliminarDetalles"
        Me.miEliminarDetalles.Size = New System.Drawing.Size(192, 22)
        Me.miEliminarDetalles.Text = "Eliminar Detalles"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(189, 6)
        '
        'miAgregarPlantilla
        '
        Me.miAgregarPlantilla.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.miAgregarPlantilla.Name = "miAgregarPlantilla"
        Me.miAgregarPlantilla.Size = New System.Drawing.Size(192, 22)
        Me.miAgregarPlantilla.Text = "Agregar Plantilla"
        '
        'miAgregarConsumoJob
        '
        Me.miAgregarConsumoJob.Image = Global.SIGECOM.My.Resources.Resources.Tools
        Me.miAgregarConsumoJob.Name = "miAgregarConsumoJob"
        Me.miAgregarConsumoJob.Size = New System.Drawing.Size(192, 22)
        Me.miAgregarConsumoJob.Text = "Agregar Consumo Job"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(189, 6)
        '
        'miFormatoExcel
        '
        Me.miFormatoExcel.Image = Global.SIGECOM.My.Resources.Resources.excel_ico
        Me.miFormatoExcel.Name = "miFormatoExcel"
        Me.miFormatoExcel.Size = New System.Drawing.Size(192, 22)
        Me.miFormatoExcel.Text = "Formato Excel"
        '
        'miImportarExcel
        '
        Me.miImportarExcel.Image = Global.SIGECOM.My.Resources.Resources.excel_ico
        Me.miImportarExcel.Name = "miImportarExcel"
        Me.miImportarExcel.Size = New System.Drawing.Size(192, 22)
        Me.miImportarExcel.Text = "Importar Listado Excel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(189, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(192, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miBuscar
        '
        Me.miBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.miBuscar.Name = "miBuscar"
        Me.miBuscar.Size = New System.Drawing.Size(192, 22)
        Me.miBuscar.Text = "Buscar"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox1.Controls.Add(Me.txtTotalNetoSug)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalIgvSug)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalSug)
        Me.UiGroupBox1.Controls.Add(Me.lblTotalNeto)
        Me.UiGroupBox1.Controls.Add(Me.lbltotalIGV)
        Me.UiGroupBox1.Controls.Add(Me.lblTotal)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalNeto)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalIGV)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPrecio)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDescuento)
        Me.UiGroupBox1.Controls.Add(Me.txtTotal)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Location = New System.Drawing.Point(3, 274)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(851, 82)
        Me.UiGroupBox1.TabIndex = 20
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalNetoSug
        '
        Me.txtTotalNetoSug.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNetoSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNetoSug.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNetoSug.Location = New System.Drawing.Point(715, 47)
        Me.txtTotalNetoSug.MaxLength = 5
        Me.txtTotalNetoSug.Name = "txtTotalNetoSug"
        Me.txtTotalNetoSug.ReadOnly = True
        Me.txtTotalNetoSug.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalNetoSug.TabIndex = 16
        Me.txtTotalNetoSug.TabStop = False
        Me.txtTotalNetoSug.Text = "0.00"
        Me.txtTotalNetoSug.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNetoSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNetoSug.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalIgvSug
        '
        Me.txtTotalIgvSug.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalIgvSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIgvSug.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalIgvSug.Location = New System.Drawing.Point(715, 28)
        Me.txtTotalIgvSug.MaxLength = 5
        Me.txtTotalIgvSug.Name = "txtTotalIgvSug"
        Me.txtTotalIgvSug.ReadOnly = True
        Me.txtTotalIgvSug.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalIgvSug.TabIndex = 15
        Me.txtTotalIgvSug.TabStop = False
        Me.txtTotalIgvSug.Text = "0.00"
        Me.txtTotalIgvSug.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalIgvSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIgvSug.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalSug
        '
        Me.txtTotalSug.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSug.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalSug.Location = New System.Drawing.Point(715, 9)
        Me.txtTotalSug.MaxLength = 5
        Me.txtTotalSug.Name = "txtTotalSug"
        Me.txtTotalSug.ReadOnly = True
        Me.txtTotalSug.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalSug.TabIndex = 14
        Me.txtTotalSug.TabStop = False
        Me.txtTotalSug.Text = "0.00"
        Me.txtTotalSug.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalSug.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalNeto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalNeto.Location = New System.Drawing.Point(25, 47)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(602, 20)
        Me.lblTotalNeto.TabIndex = 13
        Me.lblTotalNeto.TabStop = False
        Me.lblTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotalIGV
        '
        Me.lbltotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lbltotalIGV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lbltotalIGV.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbltotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalIGV.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltotalIGV.Location = New System.Drawing.Point(25, 28)
        Me.lbltotalIGV.MaxLength = 20
        Me.lbltotalIGV.Name = "lbltotalIGV"
        Me.lbltotalIGV.ReadOnly = True
        Me.lbltotalIGV.Size = New System.Drawing.Size(602, 20)
        Me.lbltotalIGV.TabIndex = 12
        Me.lbltotalIGV.TabStop = False
        Me.lbltotalIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotal.Location = New System.Drawing.Point(25, 9)
        Me.lblTotal.MaxLength = 20
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.ReadOnly = True
        Me.lblTotal.Size = New System.Drawing.Size(433, 20)
        Me.lblTotal.TabIndex = 11
        Me.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNeto.Location = New System.Drawing.Point(626, 47)
        Me.txtTotalNeto.MaxLength = 5
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalNeto.TabIndex = 6
        Me.txtTotalNeto.TabStop = False
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalIGV
        '
        Me.txtTotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIGV.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalIGV.Location = New System.Drawing.Point(626, 28)
        Me.txtTotalIGV.MaxLength = 5
        Me.txtTotalIGV.Name = "txtTotalIGV"
        Me.txtTotalIGV.ReadOnly = True
        Me.txtTotalIGV.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalIGV.TabIndex = 5
        Me.txtTotalIGV.TabStop = False
        Me.txtTotalIGV.Text = "0.00"
        Me.txtTotalIGV.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIGV.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalPrecio
        '
        Me.txtTotalPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrecio.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalPrecio.Location = New System.Drawing.Point(457, 9)
        Me.txtTotalPrecio.MaxLength = 5
        Me.txtTotalPrecio.Name = "txtTotalPrecio"
        Me.txtTotalPrecio.ReadOnly = True
        Me.txtTotalPrecio.Size = New System.Drawing.Size(91, 20)
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
        Me.txtTotalDescuento.Location = New System.Drawing.Point(547, 9)
        Me.txtTotalDescuento.MaxLength = 5
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(80, 20)
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
        Me.txtTotal.Location = New System.Drawing.Point(626, 9)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(90, 20)
        Me.txtTotal.TabIndex = 3
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodPag
        '
        Me.cmbCodPag.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodPag_DesignTimeLayout.LayoutString = resources.GetString("cmbCodPag_DesignTimeLayout.LayoutString")
        Me.cmbCodPag.DesignTimeLayout = cmbCodPag_DesignTimeLayout
        Me.cmbCodPag.Location = New System.Drawing.Point(111, 37)
        Me.cmbCodPag.Name = "cmbCodPag"
        Me.cmbCodPag.SelectedIndex = -1
        Me.cmbCodPag.SelectedItem = Nothing
        Me.cmbCodPag.Size = New System.Drawing.Size(227, 20)
        Me.cmbCodPag.TabIndex = 9
        Me.cmbCodPag.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtIgv.Location = New System.Drawing.Point(160, 59)
        Me.txtIgv.MaxLength = 12
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(42, 20)
        Me.txtIgv.TabIndex = 15
        Me.txtIgv.TabStop = False
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(123, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "I.G.V."
        '
        'cmbCodMon
        '
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(56, 59)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(51, 20)
        Me.cmbCodMon.TabIndex = 13
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTipoCambio.Location = New System.Drawing.Point(273, 59)
        Me.txtTipoCambio.MaxLength = 20
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(54, 20)
        Me.txtTipoCambio.TabIndex = 17
        Me.txtTipoCambio.TabStop = False
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtCliente.Location = New System.Drawing.Point(379, 15)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(278, 20)
        Me.txtCliente.TabIndex = 5
        '
        'txtNumCot
        '
        Me.txtNumCot.BackColor = System.Drawing.Color.Beige
        Me.txtNumCot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumCot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCot.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumCot.Location = New System.Drawing.Point(56, 15)
        Me.txtNumCot.MaxLength = 200
        Me.txtNumCot.Name = "txtNumCot"
        Me.txtNumCot.Size = New System.Drawing.Size(118, 20)
        Me.txtNumCot.TabIndex = 1
        Me.txtNumCot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(712, 7)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(132, 51)
        Me.gbEstado.TabIndex = 28
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(6, 14)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(116, 28)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(5, 13)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Cabecera "
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.btnAgregarCliente)
        Me.gbDatos.Controls.Add(Me.UiGroupBox3)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.btnAgregarContacto)
        Me.gbDatos.Controls.Add(Me.txtFacCli)
        Me.gbDatos.Controls.Add(Me.txtVendedor)
        Me.gbDatos.Controls.Add(Me.txtCliente)
        Me.gbDatos.Controls.Add(Me.Label12)
        Me.gbDatos.Controls.Add(Me.txtDscCli)
        Me.gbDatos.Controls.Add(Me.btnBuscarCliente)
        Me.gbDatos.Controls.Add(Me.Label15)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.lblFecha)
        Me.gbDatos.Controls.Add(Me.txtFecha)
        Me.gbDatos.Controls.Add(Me.cmbIdContacto)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.cmbCodPag)
        Me.gbDatos.Controls.Add(Me.txtIgv)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Controls.Add(Me.cmbCodMon)
        Me.gbDatos.Controls.Add(Me.txtTipoCambio)
        Me.gbDatos.Controls.Add(Me.txtNumCot)
        Me.gbDatos.Controls.Add(Me.gbEstado)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.Label13)
        Me.gbDatos.Controls.Add(Me.UiGroupBox2)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(6, 34)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(849, 197)
        Me.gbDatos.TabIndex = 10
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos Generales"
        '
        'btnAgregarCliente
        '
        Me.btnAgregarCliente.Image = Global.SIGECOM.My.Resources.Resources.adicionarcontenedor
        Me.btnAgregarCliente.Location = New System.Drawing.Point(685, 14)
        Me.btnAgregarCliente.Name = "btnAgregarCliente"
        Me.btnAgregarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarCliente.TabIndex = 64
        Me.btnAgregarCliente.TabStop = False
        Me.btnAgregarCliente.UseVisualStyleBackColor = True
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.UiGroupBox3.Controls.Add(Me.txtObsDet)
        Me.UiGroupBox3.Controls.Add(Me.txtObsCab)
        Me.UiGroupBox3.Controls.Add(Me.btnModificarDetalle)
        Me.UiGroupBox3.Controls.Add(Me.btnModificarCabecera)
        Me.UiGroupBox3.Controls.Add(Me.Label19)
        Me.UiGroupBox3.Controls.Add(Me.Label21)
        Me.UiGroupBox3.Location = New System.Drawing.Point(6, 152)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(836, 45)
        Me.UiGroupBox3.TabIndex = 61
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.VS2005
        '
        'txtObsDet
        '
        Me.txtObsDet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObsDet.Location = New System.Drawing.Point(481, 10)
        Me.txtObsDet.Name = "txtObsDet"
        Me.txtObsDet.Size = New System.Drawing.Size(304, 28)
        Me.txtObsDet.TabIndex = 58
        Me.txtObsDet.Text = ""
        '
        'txtObsCab
        '
        Me.txtObsCab.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObsCab.Location = New System.Drawing.Point(71, 11)
        Me.txtObsCab.Name = "txtObsCab"
        Me.txtObsCab.Size = New System.Drawing.Size(304, 28)
        Me.txtObsCab.TabIndex = 57
        Me.txtObsCab.Text = ""
        '
        'btnModificarDetalle
        '
        Me.btnModificarDetalle.Image = CType(resources.GetObject("btnModificarDetalle.Image"), System.Drawing.Image)
        Me.btnModificarDetalle.Location = New System.Drawing.Point(791, 14)
        Me.btnModificarDetalle.Name = "btnModificarDetalle"
        Me.btnModificarDetalle.Size = New System.Drawing.Size(25, 22)
        Me.btnModificarDetalle.TabIndex = 41
        Me.btnModificarDetalle.TabStop = False
        Me.btnModificarDetalle.UseVisualStyleBackColor = True
        '
        'btnModificarCabecera
        '
        Me.btnModificarCabecera.Image = CType(resources.GetObject("btnModificarCabecera.Image"), System.Drawing.Image)
        Me.btnModificarCabecera.Location = New System.Drawing.Point(378, 14)
        Me.btnModificarCabecera.Name = "btnModificarCabecera"
        Me.btnModificarCabecera.Size = New System.Drawing.Size(25, 22)
        Me.btnModificarCabecera.TabIndex = 37
        Me.btnModificarCabecera.TabStop = False
        Me.btnModificarCabecera.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(431, 13)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Detalle"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(580, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Vendedor :"
        '
        'btnAgregarContacto
        '
        Me.btnAgregarContacto.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnAgregarContacto.Location = New System.Drawing.Point(662, 38)
        Me.btnAgregarContacto.Name = "btnAgregarContacto"
        Me.btnAgregarContacto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAgregarContacto.Size = New System.Drawing.Size(21, 19)
        Me.btnAgregarContacto.TabIndex = 13
        Me.btnAgregarContacto.TabStop = False
        Me.btnAgregarContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.btnAgregarContacto, "Agregar un Contacto al Cliente Seleccionado")
        Me.btnAgregarContacto.UseVisualStyleBackColor = True
        '
        'txtFacCli
        '
        Me.txtFacCli.BackColor = System.Drawing.SystemColors.Control
        Me.txtFacCli.Location = New System.Drawing.Point(383, 59)
        Me.txtFacCli.MaxLength = 12
        Me.txtFacCli.Name = "txtFacCli"
        Me.txtFacCli.ReadOnly = True
        Me.txtFacCli.Size = New System.Drawing.Size(57, 20)
        Me.txtFacCli.TabIndex = 19
        Me.txtFacCli.TabStop = False
        Me.txtFacCli.Text = "0.00"
        Me.txtFacCli.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtVendedor
        '
        Me.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtVendedor.Location = New System.Drawing.Point(649, 60)
        Me.txtVendedor.MaxLength = 20
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(193, 20)
        Me.txtVendedor.TabIndex = 62
        Me.txtVendedor.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(328, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Cliente"
        '
        'txtDscCli
        '
        Me.txtDscCli.BackColor = System.Drawing.SystemColors.Control
        Me.txtDscCli.Location = New System.Drawing.Point(515, 59)
        Me.txtDscCli.MaxLength = 12
        Me.txtDscCli.Name = "txtDscCli"
        Me.txtDscCli.ReadOnly = True
        Me.txtDscCli.Size = New System.Drawing.Size(57, 20)
        Me.txtDscCli.TabIndex = 21
        Me.txtDscCli.Text = "0.00"
        Me.txtDscCli.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(657, 14)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 7
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(450, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Descuento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(338, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Factor"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(179, 19)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 42
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(228, 15)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(92, 20)
        Me.txtFecha.TabIndex = 3
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbIdContacto
        '
        Me.cmbIdContacto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdContacto_DesignTimeLayout.LayoutString = resources.GetString("cmbIdContacto_DesignTimeLayout.LayoutString")
        Me.cmbIdContacto.DesignTimeLayout = cmbIdContacto_DesignTimeLayout
        Me.cmbIdContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmbIdContacto.Location = New System.Drawing.Point(410, 37)
        Me.cmbIdContacto.Name = "cmbIdContacto"
        Me.cmbIdContacto.SelectedIndex = -1
        Me.cmbIdContacto.SelectedItem = Nothing
        Me.cmbIdContacto.Size = New System.Drawing.Size(251, 20)
        Me.cmbIdContacto.TabIndex = 11
        Me.cmbIdContacto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(351, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Contacto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Moneda"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Número"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(214, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "T.Cambio"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Condicion Pago :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.UiGroupBox2.Controls.Add(Me.txtDiasValidez)
        Me.UiGroupBox2.Controls.Add(Me.txtReferencia)
        Me.UiGroupBox2.Controls.Add(Me.Label16)
        Me.UiGroupBox2.Controls.Add(Me.txtGarantia)
        Me.UiGroupBox2.Controls.Add(Me.txtProyecto)
        Me.UiGroupBox2.Controls.Add(Me.txtEntrega)
        Me.UiGroupBox2.Controls.Add(Me.Label18)
        Me.UiGroupBox2.Controls.Add(Me.txtValidez)
        Me.UiGroupBox2.Controls.Add(Me.txtPlazo)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.Label20)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.Label17)
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 77)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(836, 77)
        Me.UiGroupBox2.TabIndex = 60
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.VS2005
        '
        'txtDiasValidez
        '
        Me.txtDiasValidez.Location = New System.Drawing.Point(125, 53)
        Me.txtDiasValidez.Maximum = 160
        Me.txtDiasValidez.MaxLength = 200
        Me.txtDiasValidez.Minimum = 1
        Me.txtDiasValidez.Name = "txtDiasValidez"
        Me.txtDiasValidez.Size = New System.Drawing.Size(47, 20)
        Me.txtDiasValidez.TabIndex = 30
        Me.txtDiasValidez.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDiasValidez.Value = 1
        Me.txtDiasValidez.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtReferencia
        '
        Me.txtReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtReferencia.Location = New System.Drawing.Point(70, 9)
        Me.txtReferencia.MaxLength = 100
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(332, 20)
        Me.txtReferencia.TabIndex = 23
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(2, 35)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 13)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Garantía "
        '
        'txtGarantia
        '
        Me.txtGarantia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGarantia.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtGarantia.Location = New System.Drawing.Point(70, 31)
        Me.txtGarantia.MaxLength = 100
        Me.txtGarantia.Name = "txtGarantia"
        Me.txtGarantia.Size = New System.Drawing.Size(332, 20)
        Me.txtGarantia.TabIndex = 27
        '
        'txtProyecto
        '
        Me.txtProyecto.Location = New System.Drawing.Point(481, 53)
        Me.txtProyecto.MaxLength = 100
        Me.txtProyecto.Name = "txtProyecto"
        Me.txtProyecto.Size = New System.Drawing.Size(328, 20)
        Me.txtProyecto.TabIndex = 33
        '
        'txtEntrega
        '
        Me.txtEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntrega.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtEntrega.Location = New System.Drawing.Point(481, 31)
        Me.txtEntrega.MaxLength = 100
        Me.txtEntrega.Name = "txtEntrega"
        Me.txtEntrega.Size = New System.Drawing.Size(328, 20)
        Me.txtEntrega.TabIndex = 29
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(2, 57)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 13)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "Validez de la Oferta"
        '
        'txtValidez
        '
        Me.txtValidez.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValidez.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtValidez.Location = New System.Drawing.Point(176, 53)
        Me.txtValidez.MaxLength = 100
        Me.txtValidez.Name = "txtValidez"
        Me.txtValidez.Size = New System.Drawing.Size(226, 20)
        Me.txtValidez.TabIndex = 31
        '
        'txtPlazo
        '
        Me.txtPlazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlazo.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPlazo.Location = New System.Drawing.Point(481, 9)
        Me.txtPlazo.MaxLength = 100
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Size = New System.Drawing.Size(328, 20)
        Me.txtPlazo.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Referencia"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(421, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 13)
        Me.Label20.TabIndex = 57
        Me.Label20.Text = "Proyecto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(430, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Plazo"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(419, 35)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 13)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "L.Entrega"
        '
        'cmOpcionesAtender
        '
        Me.cmOpcionesAtender.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodo, Me.miSeterCEROTodos})
        Me.cmOpcionesAtender.Name = "cmOpciones"
        Me.cmOpcionesAtender.Size = New System.Drawing.Size(174, 48)
        '
        'miSeleccionarTodo
        '
        Me.miSeleccionarTodo.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miSeleccionarTodo.Name = "miSeleccionarTodo"
        Me.miSeleccionarTodo.Size = New System.Drawing.Size(173, 22)
        Me.miSeleccionarTodo.Text = "Seleccionar Todos"
        '
        'miSeterCEROTodos
        '
        Me.miSeterCEROTodos.Image = CType(resources.GetObject("miSeterCEROTodos.Image"), System.Drawing.Image)
        Me.miSeterCEROTodos.Name = "miSeterCEROTodos"
        Me.miSeterCEROTodos.Size = New System.Drawing.Size(173, 22)
        Me.miSeterCEROTodos.Text = "Poner en ""0"" todos"
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEditar, Me.ToolStripSeparator13, Me.ToolStripSeparator14, Me.btnGuardar, Me.btnDeshacer, Me.biSugerir, Me.btnGenerarDocumento, Me.ToolStripSeparator15, Me.btnRecalcularDscto, Me.biActMoneda, Me.ToolStripSeparator1, Me.btnCancelar})
        Me.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(884, 31)
        Me.ToolStrip.TabIndex = 16
        Me.ToolStrip.Text = "Actualiza"
        '
        'btnEditar
        '
        Me.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(28, 28)
        Me.btnEditar.Text = "Editar Cotizacion"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.Text = "Grabar Cambios"
        '
        'btnDeshacer
        '
        Me.btnDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.btnDeshacer.Text = "Deshacer Cambios"
        '
        'biSugerir
        '
        Me.biSugerir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.biSugerir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSugerir.Name = "biSugerir"
        Me.biSugerir.Size = New System.Drawing.Size(28, 28)
        Me.biSugerir.Text = "Sugerir Precio   "
        '
        'btnGenerarDocumento
        '
        Me.btnGenerarDocumento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGenerarDocumento.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.btnGenerarDocumento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerarDocumento.Name = "btnGenerarDocumento"
        Me.btnGenerarDocumento.Size = New System.Drawing.Size(28, 28)
        Me.btnGenerarDocumento.Text = "Generar G/F/B/O.C."
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
        '
        'btnRecalcularDscto
        '
        Me.btnRecalcularDscto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRecalcularDscto.Image = Global.SIGECOM.My.Resources.Resources.Dscto
        Me.btnRecalcularDscto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRecalcularDscto.Name = "btnRecalcularDscto"
        Me.btnRecalcularDscto.Size = New System.Drawing.Size(28, 28)
        Me.btnRecalcularDscto.Text = "Recalcular Descuento"
        Me.btnRecalcularDscto.Visible = False
        '
        'biActMoneda
        '
        Me.biActMoneda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActMoneda.Image = Global.SIGECOM.My.Resources.Resources.Moneda
        Me.biActMoneda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActMoneda.Name = "biActMoneda"
        Me.biActMoneda.Size = New System.Drawing.Size(28, 28)
        Me.biActMoneda.Text = "Actualizar Moneda de Cotizacion"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(28, 28)
        Me.btnCancelar.Text = "Cerrar el Formulario"
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicacion.Location = New System.Drawing.Point(474, 9)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(134, 13)
        Me.lblUbicacion.TabIndex = 17
        Me.lblUbicacion.Text = "OFICINA  -  ALMACÉN"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 647)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(884, 20)
        Me.ssBarra.TabIndex = 18
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.UiGroupBox4.Controls.Add(Me.dgvImportarExcel)
        Me.UiGroupBox4.Controls.Add(Me.dgvFormatoExcel)
        Me.UiGroupBox4.Controls.Add(Me.cbExportacion)
        Me.UiGroupBox4.Location = New System.Drawing.Point(12, 221)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(836, 35)
        Me.UiGroupBox4.TabIndex = 62
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.VS2005
        '
        'dgvImportarExcel
        '
        Me.dgvImportarExcel.AllowUserToAddRows = False
        Me.dgvImportarExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImportarExcel.Location = New System.Drawing.Point(178, 11)
        Me.dgvImportarExcel.Name = "dgvImportarExcel"
        Me.dgvImportarExcel.Size = New System.Drawing.Size(52, 19)
        Me.dgvImportarExcel.TabIndex = 285
        Me.dgvImportarExcel.Visible = False
        '
        'dgvFormatoExcel
        '
        Me.dgvFormatoExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFormatoExcel.Location = New System.Drawing.Point(120, 11)
        Me.dgvFormatoExcel.Name = "dgvFormatoExcel"
        Me.dgvFormatoExcel.Size = New System.Drawing.Size(52, 19)
        Me.dgvFormatoExcel.TabIndex = 284
        Me.dgvFormatoExcel.Visible = False
        '
        'cbExportacion
        '
        Me.cbExportacion.AutoSize = True
        Me.cbExportacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbExportacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbExportacion.Location = New System.Drawing.Point(4, 13)
        Me.cbExportacion.Name = "cbExportacion"
        Me.cbExportacion.Size = New System.Drawing.Size(93, 17)
        Me.cbExportacion.TabIndex = 59
        Me.cbExportacion.Text = "Exportación"
        Me.cbExportacion.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmCotizacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(884, 667)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.lblUbicacion)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCotizacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cotización"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.cmbIdContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.cmOpcionesAtender.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.dgvImportarExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFormatoExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCodPag As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtNumCot As System.Windows.Forms.TextBox
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents miSeleccionarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeterCEROTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpcionesAtender As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmbIdContacto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtValidez As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtGarantia As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPlazo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtProyecto As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtFacCli As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDscCli As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnModificarDetalle As System.Windows.Forms.Button
    Friend WithEvents btnModificarCabecera As System.Windows.Forms.Button
    Friend WithEvents txtTotalIGV As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalIGV As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents btnGenerarDocumento As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnAgregarContacto As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents btnRecalcularDscto As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSugerir As System.Windows.Forms.ToolStripButton
    Friend WithEvents miSugerir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTotalNetoSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalIgvSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents miAgregarPlantilla As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtDiasValidez As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents miAgregarConsumoJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biActMoneda As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbExportacion As System.Windows.Forms.CheckBox
    Friend WithEvents txtObsDet As System.Windows.Forms.RichTextBox
    Friend WithEvents txtObsCab As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miFormatoExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miImportarExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvFormatoExcel As System.Windows.Forms.DataGridView
    Friend WithEvents dgvImportarExcel As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents miEliminarDetalles As ToolStripMenuItem
    Friend WithEvents btnAgregarCliente As Button
End Class
