<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaRemision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaRemision))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbModoTraslado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUnidMedPeso_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdFiscal_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdCotizacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocCli_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMot_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator201 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSugerir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator202 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miInsertarMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.miFormatoExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator203 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator204 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSugerir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.biTransportista = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActMoneda = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.gbDetalles = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
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
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnModificarDirFiscal = New System.Windows.Forms.Button()
        Me.btnModificarLocacion = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbModoTraslado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtFecIniTraslado = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbUnidMedPeso = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtPesoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCanBultos = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnAgregarDirFiscal = New System.Windows.Forms.Button()
        Me.cmbIdFiscal = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnAgregarLocacion = New System.Windows.Forms.Button()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtNum_Orden = New System.Windows.Forms.TextBox()
        Me.txtLlegada = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumJob = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.cmbIdCotizacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbIdLocCli = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodMot = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTotEmbarque = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotFlete = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalles.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbModoTraslado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidMedPeso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocCli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator201, Me.miSugerir, Me.ToolStripSeparator202, Me.miNuevo, Me.miModificar, Me.miEliminar, Me.miInsertarMasivo, Me.ToolStripSeparator3, Me.miFormatoExcel, Me.ToolStripSeparator203, Me.miActualizar, Me.ToolStripSeparator204})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(155, 188)
        '
        'ToolStripSeparator201
        '
        Me.ToolStripSeparator201.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator201.Name = "ToolStripSeparator201"
        Me.ToolStripSeparator201.Size = New System.Drawing.Size(151, 6)
        '
        'miSugerir
        '
        Me.miSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.miSugerir.Name = "miSugerir"
        Me.miSugerir.Size = New System.Drawing.Size(154, 22)
        Me.miSugerir.Text = "&Sugerir"
        '
        'ToolStripSeparator202
        '
        Me.ToolStripSeparator202.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripSeparator202.Name = "ToolStripSeparator202"
        Me.ToolStripSeparator202.Size = New System.Drawing.Size(151, 6)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(154, 22)
        Me.miNuevo.Text = "&Nuevo"
        '
        'miModificar
        '
        Me.miModificar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.miModificar.Name = "miModificar"
        Me.miModificar.Size = New System.Drawing.Size(154, 22)
        Me.miModificar.Text = "&Modificar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(154, 22)
        Me.miEliminar.Text = "&Eliminar"
        '
        'miInsertarMasivo
        '
        Me.miInsertarMasivo.Image = CType(resources.GetObject("miInsertarMasivo.Image"), System.Drawing.Image)
        Me.miInsertarMasivo.Name = "miInsertarMasivo"
        Me.miInsertarMasivo.Size = New System.Drawing.Size(154, 22)
        Me.miInsertarMasivo.Text = "Insertar Masivo"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(151, 6)
        '
        'miFormatoExcel
        '
        Me.miFormatoExcel.Image = CType(resources.GetObject("miFormatoExcel.Image"), System.Drawing.Image)
        Me.miFormatoExcel.Name = "miFormatoExcel"
        Me.miFormatoExcel.Size = New System.Drawing.Size(154, 22)
        Me.miFormatoExcel.Text = "Formato Excel"
        '
        'ToolStripSeparator203
        '
        Me.ToolStripSeparator203.Name = "ToolStripSeparator203"
        Me.ToolStripSeparator203.Size = New System.Drawing.Size(151, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(154, 22)
        Me.miActualizar.Text = "&Actualizar"
        '
        'ToolStripSeparator204
        '
        Me.ToolStripSeparator204.Name = "ToolStripSeparator204"
        Me.ToolStripSeparator204.Size = New System.Drawing.Size(151, 6)
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator11, Me.biEditar, Me.ToolStripSeparator12, Me.biSugerir, Me.ToolStripSeparator13, Me.biGrabar, Me.ToolStripSeparator2, Me.biDeshacer, Me.ToolStripSeparator14, Me.biTransportista, Me.ToolStripSeparator15, Me.biActMoneda, Me.ToolStripSeparator1, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(865, 31)
        Me.ToolStrip.TabIndex = 2
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        '
        'biSugerir
        '
        Me.biSugerir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.biSugerir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSugerir.Name = "biSugerir"
        Me.biSugerir.Size = New System.Drawing.Size(28, 28)
        Me.biSugerir.Text = "Sugerir Factor-Descuento"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = CType(resources.GetObject("biDeshacer.Image"), System.Drawing.Image)
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
        'biTransportista
        '
        Me.biTransportista.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biTransportista.Image = Global.SIGECOM.My.Resources.Resources.Transporte
        Me.biTransportista.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biTransportista.Name = "biTransportista"
        Me.biTransportista.Size = New System.Drawing.Size(28, 28)
        Me.biTransportista.Text = "Transportista"
        Me.biTransportista.ToolTipText = "Ingresar Transportista"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
        '
        'biActMoneda
        '
        Me.biActMoneda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActMoneda.Image = Global.SIGECOM.My.Resources.Resources.Moneda1
        Me.biActMoneda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActMoneda.Name = "biActMoneda"
        Me.biActMoneda.Size = New System.Drawing.Size(28, 28)
        Me.biActMoneda.Text = "Actualizar Moneda de Guía"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = CType(resources.GetObject("biSalir.Image"), System.Drawing.Image)
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar el Formulario"
        '
        'gbDetalles
        '
        Me.gbDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalles.Controls.Add(Me.dgvDatos)
        Me.gbDetalles.Controls.Add(Me.UiGroupBox1)
        Me.gbDetalles.Location = New System.Drawing.Point(0, 259)
        Me.gbDetalles.Name = "gbDetalles"
        Me.gbDetalles.Size = New System.Drawing.Size(849, 310)
        Me.gbDetalles.TabIndex = 0
        Me.gbDetalles.Text = "  [ Detalles ]  "
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(10, 17)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(826, 210)
        Me.dgvDatos.TabIndex = 0
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox1.Controls.Add(Me.DataGridView1)
        Me.UiGroupBox1.Controls.Add(Me.DataGridView2)
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
        Me.UiGroupBox1.Location = New System.Drawing.Point(3, 234)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(843, 73)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 42)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(34, 23)
        Me.DataGridView1.TabIndex = 234
        Me.DataGridView1.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(16, 16)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(34, 23)
        Me.DataGridView2.TabIndex = 233
        Me.DataGridView2.Visible = False
        '
        'txtTotalNetoSug
        '
        Me.txtTotalNetoSug.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNetoSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNetoSug.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNetoSug.Location = New System.Drawing.Point(719, 49)
        Me.txtTotalNetoSug.MaxLength = 5
        Me.txtTotalNetoSug.Name = "txtTotalNetoSug"
        Me.txtTotalNetoSug.ReadOnly = True
        Me.txtTotalNetoSug.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalNetoSug.TabIndex = 10
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
        Me.txtTotalIgvSug.Location = New System.Drawing.Point(719, 30)
        Me.txtTotalIgvSug.MaxLength = 5
        Me.txtTotalIgvSug.Name = "txtTotalIgvSug"
        Me.txtTotalIgvSug.ReadOnly = True
        Me.txtTotalIgvSug.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalIgvSug.TabIndex = 9
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
        Me.txtTotalSug.Location = New System.Drawing.Point(719, 11)
        Me.txtTotalSug.MaxLength = 5
        Me.txtTotalSug.Name = "txtTotalSug"
        Me.txtTotalSug.ReadOnly = True
        Me.txtTotalSug.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalSug.TabIndex = 8
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
        Me.lblTotalNeto.Location = New System.Drawing.Point(28, 49)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(602, 20)
        Me.lblTotalNeto.TabIndex = 2
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
        Me.lbltotalIGV.Location = New System.Drawing.Point(28, 30)
        Me.lbltotalIGV.MaxLength = 20
        Me.lbltotalIGV.Name = "lbltotalIGV"
        Me.lbltotalIGV.ReadOnly = True
        Me.lbltotalIGV.Size = New System.Drawing.Size(602, 20)
        Me.lbltotalIGV.TabIndex = 1
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
        Me.lblTotal.Location = New System.Drawing.Point(28, 11)
        Me.lblTotal.MaxLength = 20
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.ReadOnly = True
        Me.lblTotal.Size = New System.Drawing.Size(433, 20)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNeto.Location = New System.Drawing.Point(630, 49)
        Me.txtTotalNeto.MaxLength = 5
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalNeto.TabIndex = 7
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
        Me.txtTotalIGV.Location = New System.Drawing.Point(630, 30)
        Me.txtTotalIGV.MaxLength = 5
        Me.txtTotalIGV.Name = "txtTotalIGV"
        Me.txtTotalIGV.ReadOnly = True
        Me.txtTotalIGV.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalIGV.TabIndex = 6
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
        Me.txtTotalPrecio.Location = New System.Drawing.Point(461, 11)
        Me.txtTotalPrecio.MaxLength = 5
        Me.txtTotalPrecio.Name = "txtTotalPrecio"
        Me.txtTotalPrecio.ReadOnly = True
        Me.txtTotalPrecio.Size = New System.Drawing.Size(91, 20)
        Me.txtTotalPrecio.TabIndex = 3
        Me.txtTotalPrecio.TabStop = False
        Me.txtTotalPrecio.Text = "0.00"
        Me.txtTotalPrecio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalPrecio.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDescuento.Location = New System.Drawing.Point(551, 11)
        Me.txtTotalDescuento.MaxLength = 5
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(80, 20)
        Me.txtTotalDescuento.TabIndex = 4
        Me.txtTotalDescuento.TabStop = False
        Me.txtTotalDescuento.Text = "0.00"
        Me.txtTotalDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDescuento.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotal.Location = New System.Drawing.Point(630, 11)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(90, 20)
        Me.txtTotal.TabIndex = 5
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtObservacion
        '
        Me.txtObservacion.BackColor = System.Drawing.SystemColors.Control
        Me.txtObservacion.ButtonEnabled = False
        Me.txtObservacion.ButtonImage = CType(resources.GetObject("txtObservacion.ButtonImage"), System.Drawing.Image)
        Me.txtObservacion.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtObservacion.Location = New System.Drawing.Point(98, 188)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.PromptChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.Size = New System.Drawing.Size(740, 24)
        Me.txtObservacion.TabIndex = 28
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarCliente)
        Me.UiGroupBox2.Controls.Add(Me.txtCliente)
        Me.UiGroupBox2.Controls.Add(Me.btnModificarDirFiscal)
        Me.UiGroupBox2.Controls.Add(Me.btnModificarLocacion)
        Me.UiGroupBox2.Controls.Add(Me.Label19)
        Me.UiGroupBox2.Controls.Add(Me.cmbModoTraslado)
        Me.UiGroupBox2.Controls.Add(Me.txtFecIniTraslado)
        Me.UiGroupBox2.Controls.Add(Me.Label18)
        Me.UiGroupBox2.Controls.Add(Me.cmbUnidMedPeso)
        Me.UiGroupBox2.Controls.Add(Me.Label25)
        Me.UiGroupBox2.Controls.Add(Me.txtPesoTotal)
        Me.UiGroupBox2.Controls.Add(Me.Label22)
        Me.UiGroupBox2.Controls.Add(Me.txtCanBultos)
        Me.UiGroupBox2.Controls.Add(Me.Label17)
        Me.UiGroupBox2.Controls.Add(Me.btnAgregarDirFiscal)
        Me.UiGroupBox2.Controls.Add(Me.cmbIdFiscal)
        Me.UiGroupBox2.Controls.Add(Me.Label16)
        Me.UiGroupBox2.Controls.Add(Me.btnAgregarLocacion)
        Me.UiGroupBox2.Controls.Add(Me.txtPartida)
        Me.UiGroupBox2.Controls.Add(Me.Label15)
        Me.UiGroupBox2.Controls.Add(Me.Label14)
        Me.UiGroupBox2.Controls.Add(Me.Label13)
        Me.UiGroupBox2.Controls.Add(Me.txtVendedor)
        Me.UiGroupBox2.Controls.Add(Me.txtNum_Orden)
        Me.UiGroupBox2.Controls.Add(Me.txtLlegada)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox2.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox2.Controls.Add(Me.cmbIdCotizacion)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.Label21)
        Me.UiGroupBox2.Controls.Add(Me.cmbIdLocCli)
        Me.UiGroupBox2.Controls.Add(Me.cmbCodMot)
        Me.UiGroupBox2.Controls.Add(Me.txtIgv)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.cmbCodMon)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.txtTipoCambio)
        Me.UiGroupBox2.Controls.Add(Me.txtFecDoc)
        Me.UiGroupBox2.Controls.Add(Me.gbEstado)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.Label12)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.GroupBox2)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.lblFecha)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.UiGroupBox2.Location = New System.Drawing.Point(0, 31)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(865, 222)
        Me.UiGroupBox2.TabIndex = 1
        Me.UiGroupBox2.Text = "|"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(340, 45)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 12
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(70, 46)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(268, 20)
        Me.txtCliente.TabIndex = 11
        '
        'btnModificarDirFiscal
        '
        Me.btnModificarDirFiscal.Image = Global.SIGECOM.My.Resources.Resources.editar2
        Me.btnModificarDirFiscal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModificarDirFiscal.Location = New System.Drawing.Point(336, 69)
        Me.btnModificarDirFiscal.Name = "btnModificarDirFiscal"
        Me.btnModificarDirFiscal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnModificarDirFiscal.Size = New System.Drawing.Size(21, 20)
        Me.btnModificarDirFiscal.TabIndex = 59
        Me.btnModificarDirFiscal.TabStop = False
        Me.btnModificarDirFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificarDirFiscal.UseVisualStyleBackColor = True
        '
        'btnModificarLocacion
        '
        Me.btnModificarLocacion.Image = Global.SIGECOM.My.Resources.Resources.editar2
        Me.btnModificarLocacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModificarLocacion.Location = New System.Drawing.Point(633, 46)
        Me.btnModificarLocacion.Name = "btnModificarLocacion"
        Me.btnModificarLocacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnModificarLocacion.Size = New System.Drawing.Size(21, 20)
        Me.btnModificarLocacion.TabIndex = 58
        Me.btnModificarLocacion.TabStop = False
        Me.btnModificarLocacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificarLocacion.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(10, 167)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 13)
        Me.Label19.TabIndex = 57
        Me.Label19.Text = "Modo Traslado :"
        '
        'cmbModoTraslado
        '
        Me.cmbModoTraslado.BackColor = System.Drawing.SystemColors.Control
        Me.cmbModoTraslado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbModoTraslado_DesignTimeLayout.LayoutString = resources.GetString("cmbModoTraslado_DesignTimeLayout.LayoutString")
        Me.cmbModoTraslado.DesignTimeLayout = cmbModoTraslado_DesignTimeLayout
        Me.cmbModoTraslado.Location = New System.Drawing.Point(115, 163)
        Me.cmbModoTraslado.Name = "cmbModoTraslado"
        Me.cmbModoTraslado.ReadOnly = True
        Me.cmbModoTraslado.SelectedIndex = -1
        Me.cmbModoTraslado.SelectedItem = Nothing
        Me.cmbModoTraslado.Size = New System.Drawing.Size(181, 20)
        Me.cmbModoTraslado.TabIndex = 26
        Me.cmbModoTraslado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtFecIniTraslado
        '
        Me.txtFecIniTraslado.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecIniTraslado.DropDownCalendar.FirstMonth = New Date(2014, 5, 1, 0, 0, 0, 0)
        Me.txtFecIniTraslado.DropDownCalendar.Name = ""
        Me.txtFecIniTraslado.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIniTraslado.Location = New System.Drawing.Point(745, 163)
        Me.txtFecIniTraslado.Name = "txtFecIniTraslado"
        Me.txtFecIniTraslado.NullButtonText = "Ninguno"
        Me.txtFecIniTraslado.ReadOnly = True
        Me.txtFecIniTraslado.Size = New System.Drawing.Size(92, 20)
        Me.txtFecIniTraslado.TabIndex = 27
        Me.txtFecIniTraslado.TodayButtonText = "Hoy"
        Me.txtFecIniTraslado.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(612, 166)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(134, 13)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "Fecha Inicio Traslado:"
        '
        'cmbUnidMedPeso
        '
        Me.cmbUnidMedPeso.BackColor = System.Drawing.SystemColors.Control
        Me.cmbUnidMedPeso.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidMedPeso_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidMedPeso_DesignTimeLayout.LayoutString")
        Me.cmbUnidMedPeso.DesignTimeLayout = cmbUnidMedPeso_DesignTimeLayout
        Me.cmbUnidMedPeso.Location = New System.Drawing.Point(467, 138)
        Me.cmbUnidMedPeso.Name = "cmbUnidMedPeso"
        Me.cmbUnidMedPeso.ReadOnly = True
        Me.cmbUnidMedPeso.SelectedIndex = -1
        Me.cmbUnidMedPeso.SelectedItem = Nothing
        Me.cmbUnidMedPeso.Size = New System.Drawing.Size(87, 20)
        Me.cmbUnidMedPeso.TabIndex = 24
        Me.cmbUnidMedPeso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(346, 142)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(122, 13)
        Me.Label25.TabIndex = 53
        Me.Label25.Text = "Unid. Medida Peso :"
        '
        'txtPesoTotal
        '
        Me.txtPesoTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtPesoTotal.FormatString = "n3"
        Me.txtPesoTotal.Location = New System.Drawing.Point(98, 138)
        Me.txtPesoTotal.MaxLength = 0
        Me.txtPesoTotal.Name = "txtPesoTotal"
        Me.txtPesoTotal.ReadOnly = True
        Me.txtPesoTotal.Size = New System.Drawing.Size(92, 20)
        Me.txtPesoTotal.TabIndex = 23
        Me.txtPesoTotal.Text = "0.000"
        Me.txtPesoTotal.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtPesoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(10, 142)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(76, 13)
        Me.Label22.TabIndex = 50
        Me.Label22.Text = "Peso Total :"
        '
        'txtCanBultos
        '
        Me.txtCanBultos.BackColor = System.Drawing.SystemColors.Control
        Me.txtCanBultos.Location = New System.Drawing.Point(783, 138)
        Me.txtCanBultos.Maximum = 10000
        Me.txtCanBultos.MaxLength = 200
        Me.txtCanBultos.Minimum = 1
        Me.txtCanBultos.Name = "txtCanBultos"
        Me.txtCanBultos.ReadOnly = True
        Me.txtCanBultos.Size = New System.Drawing.Size(53, 20)
        Me.txtCanBultos.TabIndex = 25
        Me.txtCanBultos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCanBultos.Value = 1
        Me.txtCanBultos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(651, 142)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(133, 13)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Cant. Bultos / Palets :"
        '
        'btnAgregarDirFiscal
        '
        Me.btnAgregarDirFiscal.Image = Global.SIGECOM.My.Resources.Resources.Office
        Me.btnAgregarDirFiscal.Location = New System.Drawing.Point(357, 68)
        Me.btnAgregarDirFiscal.Name = "btnAgregarDirFiscal"
        Me.btnAgregarDirFiscal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAgregarDirFiscal.Size = New System.Drawing.Size(23, 22)
        Me.btnAgregarDirFiscal.TabIndex = 15
        Me.btnAgregarDirFiscal.TabStop = False
        Me.btnAgregarDirFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarDirFiscal.UseVisualStyleBackColor = True
        '
        'cmbIdFiscal
        '
        Me.cmbIdFiscal.BackColor = System.Drawing.SystemColors.Control
        Me.cmbIdFiscal.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdFiscal_DesignTimeLayout.LayoutString = resources.GetString("cmbIdFiscal_DesignTimeLayout.LayoutString")
        Me.cmbIdFiscal.DesignTimeLayout = cmbIdFiscal_DesignTimeLayout
        Me.cmbIdFiscal.Location = New System.Drawing.Point(84, 69)
        Me.cmbIdFiscal.Name = "cmbIdFiscal"
        Me.cmbIdFiscal.ReadOnly = True
        Me.cmbIdFiscal.SelectedIndex = -1
        Me.cmbIdFiscal.SelectedItem = Nothing
        Me.cmbIdFiscal.Size = New System.Drawing.Size(250, 20)
        Me.cmbIdFiscal.TabIndex = 14
        Me.cmbIdFiscal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 73)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 13)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "Dir. Fiscal :"
        '
        'btnAgregarLocacion
        '
        Me.btnAgregarLocacion.Image = Global.SIGECOM.My.Resources.Resources.Empresa
        Me.btnAgregarLocacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarLocacion.Location = New System.Drawing.Point(654, 46)
        Me.btnAgregarLocacion.Name = "btnAgregarLocacion"
        Me.btnAgregarLocacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAgregarLocacion.Size = New System.Drawing.Size(21, 20)
        Me.btnAgregarLocacion.TabIndex = 32
        Me.btnAgregarLocacion.TabStop = False
        Me.btnAgregarLocacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarLocacion.UseVisualStyleBackColor = True
        '
        'txtPartida
        '
        Me.txtPartida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartida.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPartida.Location = New System.Drawing.Point(411, 92)
        Me.txtPartida.MaxLength = 60
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.ReadOnly = True
        Me.txtPartida.Size = New System.Drawing.Size(262, 20)
        Me.txtPartida.TabIndex = 19
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(356, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Partida :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(342, 118)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Vendedor :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(664, 119)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "O/C :"
        '
        'txtVendedor
        '
        Me.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtVendedor.Location = New System.Drawing.Point(412, 115)
        Me.txtVendedor.MaxLength = 20
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(250, 20)
        Me.txtVendedor.TabIndex = 21
        Me.txtVendedor.TabStop = False
        '
        'txtNum_Orden
        '
        Me.txtNum_Orden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNum_Orden.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtNum_Orden.Location = New System.Drawing.Point(703, 116)
        Me.txtNum_Orden.MaxLength = 20
        Me.txtNum_Orden.Name = "txtNum_Orden"
        Me.txtNum_Orden.ReadOnly = True
        Me.txtNum_Orden.Size = New System.Drawing.Size(135, 20)
        Me.txtNum_Orden.TabIndex = 22
        '
        'txtLlegada
        '
        Me.txtLlegada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLlegada.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtLlegada.Location = New System.Drawing.Point(70, 115)
        Me.txtLlegada.MaxLength = 60
        Me.txtLlegada.Name = "txtLlegada"
        Me.txtLlegada.ReadOnly = True
        Me.txtLlegada.Size = New System.Drawing.Size(268, 20)
        Me.txtLlegada.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Llegada :"
        '
        'txtNumJob
        '
        Me.txtNumJob.BackColor = System.Drawing.SystemColors.Control
        Me.txtNumJob.ButtonEnabled = False
        Me.txtNumJob.ButtonImage = CType(resources.GetObject("txtNumJob.ButtonImage"), System.Drawing.Image)
        Me.txtNumJob.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Location = New System.Drawing.Point(70, 92)
        Me.txtNumJob.MaxLength = 7
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.ReadOnly = True
        Me.txtNumJob.Size = New System.Drawing.Size(80, 21)
        Me.txtNumJob.TabIndex = 17
        '
        'cmbIdCotizacion
        '
        Me.cmbIdCotizacion.BackColor = System.Drawing.SystemColors.Control
        Me.cmbIdCotizacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdCotizacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdCotizacion_DesignTimeLayout.LayoutString")
        Me.cmbIdCotizacion.DesignTimeLayout = cmbIdCotizacion_DesignTimeLayout
        Me.cmbIdCotizacion.Location = New System.Drawing.Point(229, 92)
        Me.cmbIdCotizacion.Name = "cmbIdCotizacion"
        Me.cmbIdCotizacion.ReadOnly = True
        Me.cmbIdCotizacion.SelectedIndex = -1
        Me.cmbIdCotizacion.SelectedItem = Nothing
        Me.cmbIdCotizacion.Size = New System.Drawing.Size(116, 20)
        Me.cmbIdCotizacion.TabIndex = 18
        Me.cmbIdCotizacion.TabStop = False
        Me.cmbIdCotizacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(155, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Cotización :"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.Color.Beige
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(70, 23)
        Me.txtNumDoc.MaxLength = 200
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(83, 20)
        Me.txtNumDoc.TabIndex = 1
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 193)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(86, 13)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "Observación :"
        '
        'cmbIdLocCli
        '
        Me.cmbIdLocCli.BackColor = System.Drawing.SystemColors.Control
        Me.cmbIdLocCli.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocCli_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocCli_DesignTimeLayout.LayoutString")
        Me.cmbIdLocCli.DesignTimeLayout = cmbIdLocCli_DesignTimeLayout
        Me.cmbIdLocCli.Location = New System.Drawing.Point(463, 46)
        Me.cmbIdLocCli.Name = "cmbIdLocCli"
        Me.cmbIdLocCli.ReadOnly = True
        Me.cmbIdLocCli.SelectedIndex = -1
        Me.cmbIdLocCli.SelectedItem = Nothing
        Me.cmbIdLocCli.Size = New System.Drawing.Size(169, 20)
        Me.cmbIdLocCli.TabIndex = 13
        Me.cmbIdLocCli.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodMot
        '
        Me.cmbCodMot.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodMot.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMot_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMot_DesignTimeLayout.LayoutString")
        Me.cmbCodMot.DesignTimeLayout = cmbCodMot_DesignTimeLayout
        Me.cmbCodMot.Location = New System.Drawing.Point(443, 69)
        Me.cmbCodMot.Name = "cmbCodMot"
        Me.cmbCodMot.ReadOnly = True
        Me.cmbCodMot.SelectedIndex = -1
        Me.cmbCodMot.SelectedItem = Nothing
        Me.cmbCodMot.Size = New System.Drawing.Size(230, 20)
        Me.cmbCodMot.TabIndex = 16
        Me.cmbCodMot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtIgv.Location = New System.Drawing.Point(490, 23)
        Me.txtIgv.MaxLength = 12
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(45, 20)
        Me.txtIgv.TabIndex = 7
        Me.txtIgv.TabStop = False
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(450, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "IGV :"
        '
        'cmbCodMon
        '
        Me.cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(385, 23)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.ReadOnly = True
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(58, 20)
        Me.cmbCodMon.TabIndex = 5
        Me.cmbCodMon.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "# OT :"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTipoCambio.Location = New System.Drawing.Point(615, 23)
        Me.txtTipoCambio.MaxLength = 20
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(54, 20)
        Me.txtTipoCambio.TabIndex = 9
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFecDoc
        '
        Me.txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.FirstMonth = New Date(2014, 5, 1, 0, 0, 0, 0)
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Location = New System.Drawing.Point(220, 23)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.ReadOnly = True
        Me.txtFecDoc.Size = New System.Drawing.Size(92, 20)
        Me.txtFecDoc.TabIndex = 3
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(676, 13)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(150, 28)
        Me.gbEstado.TabIndex = 23
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(13, 10)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(136, 16)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(320, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Moneda :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Cliente :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(545, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Tip.Cam. :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox2.Controls.Add(Me.txtTotEmbarque)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtTotFlete)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(676, 45)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(163, 68)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Costos"
        '
        'txtTotEmbarque
        '
        Me.txtTotEmbarque.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotEmbarque.Location = New System.Drawing.Point(78, 41)
        Me.txtTotEmbarque.MaxLength = 12
        Me.txtTotEmbarque.Name = "txtTotEmbarque"
        Me.txtTotEmbarque.ReadOnly = True
        Me.txtTotEmbarque.Size = New System.Drawing.Size(80, 20)
        Me.txtTotEmbarque.TabIndex = 2
        Me.txtTotEmbarque.Text = "0.00"
        Me.txtTotEmbarque.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotEmbarque.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Embarque :"
        '
        'txtTotFlete
        '
        Me.txtTotFlete.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotFlete.Location = New System.Drawing.Point(78, 16)
        Me.txtTotFlete.MaxLength = 12
        Me.txtTotFlete.Name = "txtTotFlete"
        Me.txtTotFlete.ReadOnly = True
        Me.txtTotFlete.Size = New System.Drawing.Size(80, 20)
        Me.txtTotFlete.TabIndex = 1
        Me.txtTotFlete.Text = "0.00"
        Me.txtTotFlete.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotFlete.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Flete :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(390, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Motivo :"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(165, 26)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(50, 13)
        Me.lblFecha.TabIndex = 2
        Me.lblFecha.Text = "Fecha :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(384, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Loc.Cliente :"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 588)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(865, 20)
        Me.ssBarra.TabIndex = 3
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
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Location = New System.Drawing.Point(435, 12)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(134, 13)
        Me.lblUbicacion.TabIndex = 4
        Me.lblUbicacion.Text = "OFICINA  -  ALMACÉN"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmGuiaRemision
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(865, 608)
        Me.Controls.Add(Me.lblUbicacion)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDetalles)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ToolStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaRemision"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = ""
        Me.Text = "frmGuiaRemision"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalles.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbModoTraslado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidMedPeso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocCli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator202 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miSugerir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSugerir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents gbDetalles As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalNetoSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalIgvSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalIGV As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalIGV As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbIdCotizacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocCli As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCodMot As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotEmbarque As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotFlete As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator201 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator203 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator204 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents txtNumJob As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents biTransportista As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLlegada As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents txtNum_Orden As System.Windows.Forms.TextBox
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarLocacion As System.Windows.Forms.Button
    Friend WithEvents biActMoneda As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAgregarDirFiscal As System.Windows.Forms.Button
    Friend WithEvents cmbIdFiscal As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents miFormatoExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miInsertarMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtCanBultos As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPesoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidMedPeso As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtFecIniTraslado As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents cmbModoTraslado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnModificarLocacion As Button
    Friend WithEvents btnModificarDirFiscal As Button
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents txtCliente As TextBox
End Class
