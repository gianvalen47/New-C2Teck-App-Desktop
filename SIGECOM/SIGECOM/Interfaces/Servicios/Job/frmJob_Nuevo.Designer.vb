<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob_Nuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJob_Nuevo))
        Dim cmbSupervisor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbFabricante_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUbicacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbAplicacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMantenimiento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoJob_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDocFacturacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvCotAsignadas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image")
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biRegularGastos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.lblAsterisco = New System.Windows.Forms.Label()
        Me.lblLeyenda = New System.Windows.Forms.Label()
        Me.txtCreditState = New System.Windows.Forms.TextBox()
        Me.txtNroClaim = New System.Windows.Forms.TextBox()
        Me.txtFecLiqAdm = New System.Windows.Forms.TextBox()
        Me.lblCreditState = New System.Windows.Forms.Label()
        Me.lblNroClaim = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cmbSupervisor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtModMer = New System.Windows.Forms.TextBox()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.txtBeneficiario = New System.Windows.Forms.TextBox()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.txtNumSolicitud = New System.Windows.Forms.TextBox()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.cmbFabricante = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblRegularizar = New System.Windows.Forms.Label()
        Me.cmbUbicacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.cbNoFacturar = New System.Windows.Forms.CheckBox()
        Me.cmbAplicacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscarBeneficiario = New System.Windows.Forms.Button()
        Me.btnBuscarSolicitante = New System.Windows.Forms.Button()
        Me.cbKitRepower = New System.Windows.Forms.CheckBox()
        Me.btnBuscarSolicitud = New System.Windows.Forms.Button()
        Me.cmbMantenimiento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoJob = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.dgvDocFacturacion = New Janus.Windows.GridEX.GridEX()
        Me.dgvCotAsignadas = New Janus.Windows.GridEX.GridEX()
        Me.btnAsignarCotizacion = New System.Windows.Forms.Button()
        Me.btnDesvincularCotizacion = New System.Windows.Forms.Button()
        Me.btnVerRepuestos = New System.Windows.Forms.Button()
        Me.gbDatosJob = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtMontoHrsHombre = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gbEstado = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecFinRep = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecIniRep = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecFinDesarmado = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecFinModulo = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtFecIniModulo = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtFecEntrega = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecLlegada = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblMarcable = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtFecFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.gbDetalleMontos = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbDatosCotizacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbDatosFacturacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtMontoVenta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoCosto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoVenta = New System.Windows.Forms.TextBox()
        Me.lblMontoCosto = New System.Windows.Forms.TextBox()
        Me.lblUnidadNegocio = New System.Windows.Forms.Label()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbFabricante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAplicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMantenimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDocFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCotAsignadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosJob.SuspendLayout()
        CType(Me.gbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalleMontos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalleMontos.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.gbDatosCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosCotizacion.SuspendLayout()
        CType(Me.gbDatosFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosFacturacion.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 760)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(759, 20)
        Me.ssBarra.TabIndex = 111
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(475, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(240, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.btnGuardar, Me.ToolStripSeparator5, Me.btnEditar, Me.ToolStripSeparator1, Me.biRegularGastos, Me.ToolStripSeparator2, Me.biImprimir, Me.ToolStripSeparator3, Me.biSalir, Me.ToolStripSeparator6})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(759, 31)
        Me.ToolStrip.TabIndex = 112
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.Text = "Guardar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'btnEditar
        '
        Me.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(28, 28)
        Me.btnEditar.Text = "Editar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biRegularGastos
        '
        Me.biRegularGastos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biRegularGastos.Image = CType(resources.GetObject("biRegularGastos.Image"), System.Drawing.Image)
        Me.biRegularGastos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biRegularGastos.Name = "biRegularGastos"
        Me.biRegularGastos.Size = New System.Drawing.Size(28, 28)
        Me.biRegularGastos.Text = "Regularizar Gastos de la OT"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir OT"
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
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'lblAsterisco
        '
        Me.lblAsterisco.AutoSize = True
        Me.lblAsterisco.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblAsterisco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsterisco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblAsterisco.Location = New System.Drawing.Point(21, 32)
        Me.lblAsterisco.Name = "lblAsterisco"
        Me.lblAsterisco.Size = New System.Drawing.Size(14, 16)
        Me.lblAsterisco.TabIndex = 246
        Me.lblAsterisco.Text = "*"
        '
        'lblLeyenda
        '
        Me.lblLeyenda.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblLeyenda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblLeyenda.Location = New System.Drawing.Point(31, 33)
        Me.lblLeyenda.Name = "lblLeyenda"
        Me.lblLeyenda.Size = New System.Drawing.Size(362, 16)
        Me.lblLeyenda.TabIndex = 245
        Me.lblLeyenda.Text = "lblLeyenda"
        Me.lblLeyenda.Visible = False
        '
        'txtCreditState
        '
        Me.txtCreditState.Location = New System.Drawing.Point(270, 221)
        Me.txtCreditState.Name = "txtCreditState"
        Me.txtCreditState.Size = New System.Drawing.Size(80, 20)
        Me.txtCreditState.TabIndex = 33
        '
        'txtNroClaim
        '
        Me.txtNroClaim.Location = New System.Drawing.Point(95, 221)
        Me.txtNroClaim.Name = "txtNroClaim"
        Me.txtNroClaim.Size = New System.Drawing.Size(80, 20)
        Me.txtNroClaim.TabIndex = 32
        '
        'txtFecLiqAdm
        '
        Me.txtFecLiqAdm.Location = New System.Drawing.Point(650, 221)
        Me.txtFecLiqAdm.Name = "txtFecLiqAdm"
        Me.txtFecLiqAdm.ReadOnly = True
        Me.txtFecLiqAdm.Size = New System.Drawing.Size(68, 20)
        Me.txtFecLiqAdm.TabIndex = 35
        Me.txtFecLiqAdm.TabStop = False
        '
        'lblCreditState
        '
        Me.lblCreditState.AutoSize = True
        Me.lblCreditState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditState.Location = New System.Drawing.Point(194, 224)
        Me.lblCreditState.Name = "lblCreditState"
        Me.lblCreditState.Size = New System.Drawing.Size(74, 13)
        Me.lblCreditState.TabIndex = 212
        Me.lblCreditState.Text = "Credit State"
        '
        'lblNroClaim
        '
        Me.lblNroClaim.AutoSize = True
        Me.lblNroClaim.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroClaim.Location = New System.Drawing.Point(9, 224)
        Me.lblNroClaim.Name = "lblNroClaim"
        Me.lblNroClaim.Size = New System.Drawing.Size(84, 13)
        Me.lblNroClaim.TabIndex = 211
        Me.lblNroClaim.Text = "Nro. Reclamo"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(576, 224)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(72, 13)
        Me.Label43.TabIndex = 218
        Me.Label43.Text = "Liquidación"
        '
        'cmbSupervisor
        '
        Me.cmbSupervisor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSupervisor_DesignTimeLayout.LayoutString = resources.GetString("cmbSupervisor_DesignTimeLayout.LayoutString")
        Me.cmbSupervisor.DesignTimeLayout = cmbSupervisor_DesignTimeLayout
        Me.cmbSupervisor.Location = New System.Drawing.Point(426, 221)
        Me.cmbSupervisor.Name = "cmbSupervisor"
        Me.cmbSupervisor.SelectedIndex = -1
        Me.cmbSupervisor.SelectedItem = Nothing
        Me.cmbSupervisor.Size = New System.Drawing.Size(144, 20)
        Me.cmbSupervisor.TabIndex = 34
        Me.cmbSupervisor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbSupervisor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(357, 224)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(67, 13)
        Me.Label41.TabIndex = 213
        Me.Label41.Text = "Supervisor"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(606, 69)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(60, 13)
        Me.Label28.TabIndex = 170
        Me.Label28.Text = "Moneda :"
        '
        'cmbCodMon
        '
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(669, 66)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(64, 20)
        Me.cmbCodMon.TabIndex = 5
        Me.cmbCodMon.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(90, 159)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(643, 30)
        Me.txtDescripcion.TabIndex = 20
        '
        'txtModMer
        '
        Me.txtModMer.Location = New System.Drawing.Point(614, 135)
        Me.txtModMer.Name = "txtModMer"
        Me.txtModMer.Size = New System.Drawing.Size(119, 20)
        Me.txtModMer.TabIndex = 19
        '
        'txtCodMer
        '
        Me.txtCodMer.Location = New System.Drawing.Point(429, 135)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(95, 20)
        Me.txtCodMer.TabIndex = 17
        '
        'txtBeneficiario
        '
        Me.txtBeneficiario.Location = New System.Drawing.Point(460, 112)
        Me.txtBeneficiario.Name = "txtBeneficiario"
        Me.txtBeneficiario.ReadOnly = True
        Me.txtBeneficiario.Size = New System.Drawing.Size(242, 20)
        Me.txtBeneficiario.TabIndex = 13
        '
        'txtSolicitante
        '
        Me.txtSolicitante.Location = New System.Drawing.Point(90, 112)
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.ReadOnly = True
        Me.txtSolicitante.Size = New System.Drawing.Size(243, 20)
        Me.txtSolicitante.TabIndex = 11
        '
        'txtNumSolicitud
        '
        Me.txtNumSolicitud.Location = New System.Drawing.Point(487, 89)
        Me.txtNumSolicitud.Name = "txtNumSolicitud"
        Me.txtNumSolicitud.ReadOnly = True
        Me.txtNumSolicitud.Size = New System.Drawing.Size(89, 20)
        Me.txtNumSolicitud.TabIndex = 8
        '
        'txtNumJob
        '
        Me.txtNumJob.Location = New System.Drawing.Point(90, 42)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.ReadOnly = True
        Me.txtNumJob.Size = New System.Drawing.Size(70, 20)
        Me.txtNumJob.TabIndex = 0
        Me.txtNumJob.TabStop = False
        '
        'cmbFabricante
        '
        Me.cmbFabricante.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbFabricante_DesignTimeLayout.LayoutString = resources.GetString("cmbFabricante_DesignTimeLayout.LayoutString")
        Me.cmbFabricante.DesignTimeLayout = cmbFabricante_DesignTimeLayout
        Me.cmbFabricante.Location = New System.Drawing.Point(90, 89)
        Me.cmbFabricante.Name = "cmbFabricante"
        Me.cmbFabricante.SelectedIndex = -1
        Me.cmbFabricante.SelectedItem = Nothing
        Me.cmbFabricante.Size = New System.Drawing.Size(114, 20)
        Me.cmbFabricante.TabIndex = 6
        Me.cmbFabricante.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbFabricante.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 226
        Me.Label11.Text = "Fabricante :"
        '
        'cmbTipo
        '
        Me.cmbTipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipo_DesignTimeLayout.LayoutString")
        Me.cmbTipo.DesignTimeLayout = cmbTipo_DesignTimeLayout
        Me.cmbTipo.Location = New System.Drawing.Point(280, 66)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.SelectedIndex = -1
        Me.cmbTipo.SelectedItem = Nothing
        Me.cmbTipo.Size = New System.Drawing.Size(60, 20)
        Me.cmbTipo.TabIndex = 2
        Me.cmbTipo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblRegularizar
        '
        Me.lblRegularizar.AutoSize = True
        Me.lblRegularizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblRegularizar.Location = New System.Drawing.Point(13, 24)
        Me.lblRegularizar.Name = "lblRegularizar"
        Me.lblRegularizar.Size = New System.Drawing.Size(70, 13)
        Me.lblRegularizar.TabIndex = 225
        Me.lblRegularizar.Text = "lblRegularizar"
        Me.lblRegularizar.Visible = False
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUbicacion_DesignTimeLayout.LayoutString = resources.GetString("cmbUbicacion_DesignTimeLayout.LayoutString")
        Me.cmbUbicacion.DesignTimeLayout = cmbUbicacion_DesignTimeLayout
        Me.cmbUbicacion.Location = New System.Drawing.Point(279, 135)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.SelectedIndex = -1
        Me.cmbUbicacion.SelectedItem = Nothing
        Me.cmbUbicacion.Size = New System.Drawing.Size(90, 20)
        Me.cmbUbicacion.TabIndex = 16
        Me.cmbUbicacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbUbicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(524, 135)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarMercaderia.TabIndex = 18
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'cbNoFacturar
        '
        Me.cbNoFacturar.AutoSize = True
        Me.cbNoFacturar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbNoFacturar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbNoFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNoFacturar.ForeColor = System.Drawing.Color.Black
        Me.cbNoFacturar.Location = New System.Drawing.Point(490, 66)
        Me.cbNoFacturar.Name = "cbNoFacturar"
        Me.cbNoFacturar.Size = New System.Drawing.Size(93, 17)
        Me.cbNoFacturar.TabIndex = 4
        Me.cbNoFacturar.Text = "No Facturar"
        Me.cbNoFacturar.UseVisualStyleBackColor = False
        '
        'cmbAplicacion
        '
        Me.cmbAplicacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAplicacion_DesignTimeLayout.LayoutString = resources.GetString("cmbAplicacion_DesignTimeLayout.LayoutString")
        Me.cmbAplicacion.DesignTimeLayout = cmbAplicacion_DesignTimeLayout
        Me.cmbAplicacion.Location = New System.Drawing.Point(90, 135)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.SelectedIndex = -1
        Me.cmbAplicacion.SelectedItem = Nothing
        Me.cmbAplicacion.Size = New System.Drawing.Size(100, 20)
        Me.cmbAplicacion.TabIndex = 15
        Me.cmbAplicacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbAplicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarBeneficiario
        '
        Me.btnBuscarBeneficiario.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarBeneficiario.Location = New System.Drawing.Point(703, 112)
        Me.btnBuscarBeneficiario.Name = "btnBuscarBeneficiario"
        Me.btnBuscarBeneficiario.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarBeneficiario.TabIndex = 14
        Me.btnBuscarBeneficiario.TabStop = False
        Me.btnBuscarBeneficiario.UseVisualStyleBackColor = True
        '
        'btnBuscarSolicitante
        '
        Me.btnBuscarSolicitante.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarSolicitante.Location = New System.Drawing.Point(335, 112)
        Me.btnBuscarSolicitante.Name = "btnBuscarSolicitante"
        Me.btnBuscarSolicitante.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarSolicitante.TabIndex = 12
        Me.btnBuscarSolicitante.TabStop = False
        Me.btnBuscarSolicitante.UseVisualStyleBackColor = True
        '
        'cbKitRepower
        '
        Me.cbKitRepower.AutoSize = True
        Me.cbKitRepower.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbKitRepower.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbKitRepower.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbKitRepower.ForeColor = System.Drawing.Color.Black
        Me.cbKitRepower.Location = New System.Drawing.Point(638, 89)
        Me.cbKitRepower.Name = "cbKitRepower"
        Me.cbKitRepower.Size = New System.Drawing.Size(78, 17)
        Me.cbKitRepower.TabIndex = 10
        Me.cbKitRepower.Text = "Kit Rpw :"
        Me.cbKitRepower.UseVisualStyleBackColor = False
        '
        'btnBuscarSolicitud
        '
        Me.btnBuscarSolicitud.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarSolicitud.Location = New System.Drawing.Point(577, 88)
        Me.btnBuscarSolicitud.Name = "btnBuscarSolicitud"
        Me.btnBuscarSolicitud.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarSolicitud.TabIndex = 9
        Me.btnBuscarSolicitud.TabStop = False
        Me.btnBuscarSolicitud.UseVisualStyleBackColor = True
        '
        'cmbMantenimiento
        '
        Me.cmbMantenimiento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMantenimiento_DesignTimeLayout.LayoutString = resources.GetString("cmbMantenimiento_DesignTimeLayout.LayoutString")
        Me.cmbMantenimiento.DesignTimeLayout = cmbMantenimiento_DesignTimeLayout
        Me.cmbMantenimiento.Location = New System.Drawing.Point(280, 89)
        Me.cmbMantenimiento.Name = "cmbMantenimiento"
        Me.cmbMantenimiento.SelectedIndex = -1
        Me.cmbMantenimiento.SelectedItem = Nothing
        Me.cmbMantenimiento.Size = New System.Drawing.Size(67, 20)
        Me.cmbMantenimiento.TabIndex = 7
        Me.cmbMantenimiento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMantenimiento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Location = New System.Drawing.Point(90, 66)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(95, 20)
        Me.cmbOficinas.TabIndex = 1
        Me.cmbOficinas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(325, 8)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(74, 16)
        Me.lblEstado.TabIndex = 129
        Me.lblEstado.Text = "lblEstado"
        Me.lblEstado.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(5, 162)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 128
        Me.Label18.Text = "Descripción :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(420, 196)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 127
        Me.Label17.Text = "Termino :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(280, 196)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 126
        Me.Label16.Text = "Inicio :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 196)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(276, 13)
        Me.Label15.TabIndex = 125
        Me.Label15.Text = "Fechas Estimadas de Realizacion del Servicio :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(205, 138)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 124
        Me.Label14.Text = "Ubicación :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(557, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 123
        Me.Label13.Text = "Modelo :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(382, 138)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 122
        Me.Label12.Text = "Serie :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 120
        Me.Label10.Text = "Aplicación :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(376, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Beneficiario :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = "Solicitante :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(390, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "Nro. Solicitud :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(231, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = "Mant.:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(358, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "Tipo :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(217, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Realizar :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Oficina :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "OT :"
        '
        'cmbTipoJob
        '
        Me.cmbTipoJob.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoJob_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoJob_DesignTimeLayout.LayoutString")
        Me.cmbTipoJob.DesignTimeLayout = cmbTipoJob_DesignTimeLayout
        Me.cmbTipoJob.Location = New System.Drawing.Point(400, 66)
        Me.cmbTipoJob.Name = "cmbTipoJob"
        Me.cmbTipoJob.SelectedIndex = -1
        Me.cmbTipoJob.SelectedItem = Nothing
        Me.cmbTipoJob.Size = New System.Drawing.Size(61, 20)
        Me.cmbTipoJob.TabIndex = 3
        Me.cmbTipoJob.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbTipoJob.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvDocFacturacion
        '
        dgvDocFacturacion_DesignTimeLayout.LayoutString = resources.GetString("dgvDocFacturacion_DesignTimeLayout.LayoutString")
        Me.dgvDocFacturacion.DesignTimeLayout = dgvDocFacturacion_DesignTimeLayout
        Me.dgvDocFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDocFacturacion.GroupByBoxVisible = False
        Me.dgvDocFacturacion.Location = New System.Drawing.Point(7, 15)
        Me.dgvDocFacturacion.Name = "dgvDocFacturacion"
        Me.dgvDocFacturacion.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDocFacturacion.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDocFacturacion.Size = New System.Drawing.Size(727, 71)
        Me.dgvDocFacturacion.TabIndex = 234
        Me.dgvDocFacturacion.TabStop = False
        Me.dgvDocFacturacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'dgvCotAsignadas
        '
        dgvCotAsignadas_DesignTimeLayout.LayoutString = resources.GetString("dgvCotAsignadas_DesignTimeLayout.LayoutString")
        Me.dgvCotAsignadas.DesignTimeLayout = dgvCotAsignadas_DesignTimeLayout
        Me.dgvCotAsignadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvCotAsignadas.GroupByBoxVisible = False
        Me.dgvCotAsignadas.Location = New System.Drawing.Point(7, 40)
        Me.dgvCotAsignadas.Name = "dgvCotAsignadas"
        Me.dgvCotAsignadas.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCotAsignadas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCotAsignadas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCotAsignadas.Size = New System.Drawing.Size(526, 70)
        Me.dgvCotAsignadas.TabIndex = 233
        Me.dgvCotAsignadas.TabStop = False
        Me.dgvCotAsignadas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'btnAsignarCotizacion
        '
        Me.btnAsignarCotizacion.Image = CType(resources.GetObject("btnAsignarCotizacion.Image"), System.Drawing.Image)
        Me.btnAsignarCotizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignarCotizacion.Location = New System.Drawing.Point(7, 14)
        Me.btnAsignarCotizacion.Name = "btnAsignarCotizacion"
        Me.btnAsignarCotizacion.Size = New System.Drawing.Size(121, 24)
        Me.btnAsignarCotizacion.TabIndex = 26
        Me.btnAsignarCotizacion.Text = "Asignar Cotización"
        Me.btnAsignarCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignarCotizacion.UseVisualStyleBackColor = True
        '
        'btnDesvincularCotizacion
        '
        Me.btnDesvincularCotizacion.Image = CType(resources.GetObject("btnDesvincularCotizacion.Image"), System.Drawing.Image)
        Me.btnDesvincularCotizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesvincularCotizacion.Location = New System.Drawing.Point(131, 14)
        Me.btnDesvincularCotizacion.Name = "btnDesvincularCotizacion"
        Me.btnDesvincularCotizacion.Size = New System.Drawing.Size(142, 24)
        Me.btnDesvincularCotizacion.TabIndex = 27
        Me.btnDesvincularCotizacion.Text = "Desvincular Cotización"
        Me.btnDesvincularCotizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDesvincularCotizacion.UseVisualStyleBackColor = True
        '
        'btnVerRepuestos
        '
        Me.btnVerRepuestos.Image = CType(resources.GetObject("btnVerRepuestos.Image"), System.Drawing.Image)
        Me.btnVerRepuestos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerRepuestos.Location = New System.Drawing.Point(276, 14)
        Me.btnVerRepuestos.Name = "btnVerRepuestos"
        Me.btnVerRepuestos.Size = New System.Drawing.Size(100, 24)
        Me.btnVerRepuestos.TabIndex = 28
        Me.btnVerRepuestos.Text = "Ver Repuestos"
        Me.btnVerRepuestos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerRepuestos.UseVisualStyleBackColor = True
        '
        'gbDatosJob
        '
        Me.gbDatosJob.Controls.Add(Me.Label27)
        Me.gbDatosJob.Controls.Add(Me.txtMontoHrsHombre)
        Me.gbDatosJob.Controls.Add(Me.gbEstado)
        Me.gbDatosJob.Controls.Add(Me.lblMarcable)
        Me.gbDatosJob.Controls.Add(Me.Label22)
        Me.gbDatosJob.Controls.Add(Me.cmbCentroCosto)
        Me.gbDatosJob.Controls.Add(Me.Label23)
        Me.gbDatosJob.Controls.Add(Me.cmbArea)
        Me.gbDatosJob.Controls.Add(Me.txtFecFin)
        Me.gbDatosJob.Controls.Add(Me.txtFecInicio)
        Me.gbDatosJob.Controls.Add(Me.txtDescripcion)
        Me.gbDatosJob.Controls.Add(Me.lblRegularizar)
        Me.gbDatosJob.Controls.Add(Me.txtModMer)
        Me.gbDatosJob.Controls.Add(Me.cmbTipoJob)
        Me.gbDatosJob.Controls.Add(Me.txtCodMer)
        Me.gbDatosJob.Controls.Add(Me.Label1)
        Me.gbDatosJob.Controls.Add(Me.txtBeneficiario)
        Me.gbDatosJob.Controls.Add(Me.Label2)
        Me.gbDatosJob.Controls.Add(Me.txtSolicitante)
        Me.gbDatosJob.Controls.Add(Me.Label3)
        Me.gbDatosJob.Controls.Add(Me.txtNumSolicitud)
        Me.gbDatosJob.Controls.Add(Me.Label4)
        Me.gbDatosJob.Controls.Add(Me.txtNumJob)
        Me.gbDatosJob.Controls.Add(Me.Label5)
        Me.gbDatosJob.Controls.Add(Me.cmbFabricante)
        Me.gbDatosJob.Controls.Add(Me.Label6)
        Me.gbDatosJob.Controls.Add(Me.Label11)
        Me.gbDatosJob.Controls.Add(Me.cmbTipo)
        Me.gbDatosJob.Controls.Add(Me.Label8)
        Me.gbDatosJob.Controls.Add(Me.Label9)
        Me.gbDatosJob.Controls.Add(Me.Label10)
        Me.gbDatosJob.Controls.Add(Me.cmbUbicacion)
        Me.gbDatosJob.Controls.Add(Me.Label12)
        Me.gbDatosJob.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbDatosJob.Controls.Add(Me.Label13)
        Me.gbDatosJob.Controls.Add(Me.cbNoFacturar)
        Me.gbDatosJob.Controls.Add(Me.Label14)
        Me.gbDatosJob.Controls.Add(Me.cmbAplicacion)
        Me.gbDatosJob.Controls.Add(Me.Label15)
        Me.gbDatosJob.Controls.Add(Me.btnBuscarBeneficiario)
        Me.gbDatosJob.Controls.Add(Me.Label16)
        Me.gbDatosJob.Controls.Add(Me.btnBuscarSolicitante)
        Me.gbDatosJob.Controls.Add(Me.Label17)
        Me.gbDatosJob.Controls.Add(Me.cbKitRepower)
        Me.gbDatosJob.Controls.Add(Me.Label18)
        Me.gbDatosJob.Controls.Add(Me.btnBuscarSolicitud)
        Me.gbDatosJob.Controls.Add(Me.lblEstado)
        Me.gbDatosJob.Controls.Add(Me.cmbMantenimiento)
        Me.gbDatosJob.Controls.Add(Me.cmbOficinas)
        Me.gbDatosJob.Controls.Add(Me.cmbCodMon)
        Me.gbDatosJob.Controls.Add(Me.Label28)
        Me.gbDatosJob.Location = New System.Drawing.Point(5, 31)
        Me.gbDatosJob.Name = "gbDatosJob"
        Me.gbDatosJob.Size = New System.Drawing.Size(741, 226)
        Me.gbDatosJob.TabIndex = 0
        Me.gbDatosJob.Text = "Datos del Job"
        Me.gbDatosJob.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(579, 196)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(88, 13)
        Me.Label27.TabIndex = 250
        Me.Label27.Text = "Hrs. Hombre $"
        '
        'txtMontoHrsHombre
        '
        Me.txtMontoHrsHombre.Location = New System.Drawing.Point(669, 192)
        Me.txtMontoHrsHombre.MaxLength = 12
        Me.txtMontoHrsHombre.Name = "txtMontoHrsHombre"
        Me.txtMontoHrsHombre.Size = New System.Drawing.Size(64, 20)
        Me.txtMontoHrsHombre.TabIndex = 23
        Me.txtMontoHrsHombre.Text = "0.00"
        Me.txtMontoHrsHombre.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoHrsHombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.txtFecFinRep)
        Me.gbEstado.Controls.Add(Me.txtFecIniRep)
        Me.gbEstado.Controls.Add(Me.txtFecFinDesarmado)
        Me.gbEstado.Controls.Add(Me.txtFecFinModulo)
        Me.gbEstado.Controls.Add(Me.Label24)
        Me.gbEstado.Controls.Add(Me.txtFecIniModulo)
        Me.gbEstado.Controls.Add(Me.Label19)
        Me.gbEstado.Controls.Add(Me.txtFecEntrega)
        Me.gbEstado.Controls.Add(Me.txtFecLlegada)
        Me.gbEstado.Controls.Add(Me.Label21)
        Me.gbEstado.Controls.Add(Me.Label7)
        Me.gbEstado.Controls.Add(Me.Label20)
        Me.gbEstado.Controls.Add(Me.Label26)
        Me.gbEstado.Controls.Add(Me.Label25)
        Me.gbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEstado.Location = New System.Drawing.Point(5, 208)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(731, 13)
        Me.gbEstado.TabIndex = 24
        Me.gbEstado.Visible = False
        Me.gbEstado.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtFecFinRep
        '
        Me.txtFecFinRep.DateFormat = Janus.Windows.CalendarCombo.DateFormat.DateTime
        '
        '
        '
        Me.txtFecFinRep.DropDownCalendar.Name = ""
        Me.txtFecFinRep.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinRep.IsNullDate = True
        Me.txtFecFinRep.Location = New System.Drawing.Point(641, 13)
        Me.txtFecFinRep.Name = "txtFecFinRep"
        Me.txtFecFinRep.NullButtonText = "Ninguno"
        Me.txtFecFinRep.ShowNullButton = True
        Me.txtFecFinRep.Size = New System.Drawing.Size(83, 20)
        Me.txtFecFinRep.TabIndex = 28
        Me.txtFecFinRep.TodayButtonText = "Hoy"
        Me.txtFecFinRep.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecIniRep
        '
        Me.txtFecIniRep.DateFormat = Janus.Windows.CalendarCombo.DateFormat.DateTime
        '
        '
        '
        Me.txtFecIniRep.DropDownCalendar.Name = ""
        Me.txtFecIniRep.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIniRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecIniRep.IsNullDate = True
        Me.txtFecIniRep.Location = New System.Drawing.Point(269, 13)
        Me.txtFecIniRep.Name = "txtFecIniRep"
        Me.txtFecIniRep.NullButtonText = "Ninguno"
        Me.txtFecIniRep.ShowNullButton = True
        Me.txtFecIniRep.Size = New System.Drawing.Size(83, 20)
        Me.txtFecIniRep.TabIndex = 26
        Me.txtFecIniRep.TodayButtonText = "Hoy"
        Me.txtFecIniRep.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecFinDesarmado
        '
        '
        '
        '
        Me.txtFecFinDesarmado.DropDownCalendar.Name = ""
        Me.txtFecFinDesarmado.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinDesarmado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinDesarmado.IsNullDate = True
        Me.txtFecFinDesarmado.Location = New System.Drawing.Point(459, 13)
        Me.txtFecFinDesarmado.Name = "txtFecFinDesarmado"
        Me.txtFecFinDesarmado.NullButtonText = "Ninguno"
        Me.txtFecFinDesarmado.ShowNullButton = True
        Me.txtFecFinDesarmado.Size = New System.Drawing.Size(83, 20)
        Me.txtFecFinDesarmado.TabIndex = 27
        Me.txtFecFinDesarmado.TodayButtonText = "Hoy"
        Me.txtFecFinDesarmado.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecFinModulo
        '
        '
        '
        '
        Me.txtFecFinModulo.DropDownCalendar.Name = ""
        Me.txtFecFinModulo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinModulo.IsNullDate = True
        Me.txtFecFinModulo.Location = New System.Drawing.Point(390, 37)
        Me.txtFecFinModulo.Name = "txtFecFinModulo"
        Me.txtFecFinModulo.NullButtonText = "Ninguno"
        Me.txtFecFinModulo.ShowNullButton = True
        Me.txtFecFinModulo.Size = New System.Drawing.Size(83, 20)
        Me.txtFecFinModulo.TabIndex = 30
        Me.txtFecFinModulo.TodayButtonText = "Hoy"
        Me.txtFecFinModulo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(3, 41)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(120, 13)
        Me.Label24.TabIndex = 244
        Me.Label24.Text = "Fec. Inicio Módulo :"
        '
        'txtFecIniModulo
        '
        '
        '
        '
        Me.txtFecIniModulo.DropDownCalendar.Name = ""
        Me.txtFecIniModulo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIniModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecIniModulo.IsNullDate = True
        Me.txtFecIniModulo.Location = New System.Drawing.Point(123, 37)
        Me.txtFecIniModulo.Name = "txtFecIniModulo"
        Me.txtFecIniModulo.NullButtonText = "Ninguno"
        Me.txtFecIniModulo.ShowNullButton = True
        Me.txtFecIniModulo.Size = New System.Drawing.Size(83, 20)
        Me.txtFecIniModulo.TabIndex = 29
        Me.txtFecIniModulo.TodayButtonText = "Hoy"
        Me.txtFecIniModulo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(182, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 13)
        Me.Label19.TabIndex = 237
        Me.Label19.Text = "Fec. Ini. Rep.:"
        '
        'txtFecEntrega
        '
        '
        '
        '
        Me.txtFecEntrega.DropDownCalendar.Name = ""
        Me.txtFecEntrega.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecEntrega.IsNullDate = True
        Me.txtFecEntrega.Location = New System.Drawing.Point(641, 37)
        Me.txtFecEntrega.Name = "txtFecEntrega"
        Me.txtFecEntrega.NullButtonText = "Ninguno"
        Me.txtFecEntrega.ShowNullButton = True
        Me.txtFecEntrega.Size = New System.Drawing.Size(83, 20)
        Me.txtFecEntrega.TabIndex = 31
        Me.txtFecEntrega.TodayButtonText = "Hoy"
        Me.txtFecEntrega.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecLlegada
        '
        '
        '
        '
        Me.txtFecLlegada.DropDownCalendar.Name = ""
        Me.txtFecLlegada.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecLlegada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecLlegada.IsNullDate = True
        Me.txtFecLlegada.Location = New System.Drawing.Point(90, 13)
        Me.txtFecLlegada.Name = "txtFecLlegada"
        Me.txtFecLlegada.NullButtonText = "Ninguno"
        Me.txtFecLlegada.ShowNullButton = True
        Me.txtFecLlegada.Size = New System.Drawing.Size(83, 20)
        Me.txtFecLlegada.TabIndex = 25
        Me.txtFecLlegada.TodayButtonText = "Hoy"
        Me.txtFecLlegada.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(554, 41)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(88, 13)
        Me.Label21.TabIndex = 241
        Me.Label21.Text = "Fec. Entrega :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 235
        Me.Label7.Text = "Fec. Llegada :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(551, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(92, 13)
        Me.Label20.TabIndex = 239
        Me.Label20.Text = "Fec. Fin. Rep.:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(361, 17)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(99, 13)
        Me.Label26.TabIndex = 248
        Me.Label26.Text = "Fin Desarmado :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(284, 41)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(106, 13)
        Me.Label25.TabIndex = 246
        Me.Label25.Text = "Fec. Fin Módulo :"
        '
        'lblMarcable
        '
        Me.lblMarcable.AutoSize = True
        Me.lblMarcable.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMarcable.Location = New System.Drawing.Point(582, 24)
        Me.lblMarcable.Name = "lblMarcable"
        Me.lblMarcable.Size = New System.Drawing.Size(61, 13)
        Me.lblMarcable.TabIndex = 248
        Me.lblMarcable.Text = "lblMarcable"
        Me.lblMarcable.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblMarcable.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(455, 46)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 13)
        Me.Label22.TabIndex = 246
        Me.Label22.Text = "Centro Costo"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(541, 42)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.ReadOnly = True
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(192, 20)
        Me.cmbCentroCosto.TabIndex = 3
        Me.cmbCentroCosto.TabStop = False
        Me.cmbCentroCosto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(192, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(33, 13)
        Me.Label23.TabIndex = 244
        Me.Label23.Text = "Área"
        '
        'cmbArea
        '
        Me.cmbArea.BackColor = System.Drawing.SystemColors.Control
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(235, 42)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.ReadOnly = True
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(177, 20)
        Me.cmbArea.TabIndex = 2
        Me.cmbArea.TabStop = False
        Me.cmbArea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtFecFin
        '
        '
        '
        '
        Me.txtFecFin.DropDownCalendar.Name = ""
        Me.txtFecFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFin.Location = New System.Drawing.Point(482, 192)
        Me.txtFecFin.Name = "txtFecFin"
        Me.txtFecFin.NullButtonText = "Ninguno"
        Me.txtFecFin.Size = New System.Drawing.Size(80, 20)
        Me.txtFecFin.TabIndex = 22
        Me.txtFecFin.TodayButtonText = "Hoy"
        Me.txtFecFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecInicio
        '
        '
        '
        '
        Me.txtFecInicio.DropDownCalendar.Name = ""
        Me.txtFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicio.Location = New System.Drawing.Point(328, 192)
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.NullButtonText = "Ninguno"
        Me.txtFecInicio.Size = New System.Drawing.Size(80, 20)
        Me.txtFecInicio.TabIndex = 21
        Me.txtFecInicio.TodayButtonText = "Hoy"
        Me.txtFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'gbDetalleMontos
        '
        Me.gbDetalleMontos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalleMontos.Controls.Add(Me.dgvDatos)
        Me.gbDetalleMontos.Controls.Add(Me.txtCreditState)
        Me.gbDetalleMontos.Controls.Add(Me.lblCreditState)
        Me.gbDetalleMontos.Controls.Add(Me.lblNroClaim)
        Me.gbDetalleMontos.Controls.Add(Me.txtNroClaim)
        Me.gbDetalleMontos.Controls.Add(Me.cmbSupervisor)
        Me.gbDetalleMontos.Controls.Add(Me.txtFecLiqAdm)
        Me.gbDetalleMontos.Controls.Add(Me.Label43)
        Me.gbDetalleMontos.Controls.Add(Me.Label41)
        Me.gbDetalleMontos.Location = New System.Drawing.Point(5, 263)
        Me.gbDetalleMontos.Name = "gbDetalleMontos"
        Me.gbDetalleMontos.Size = New System.Drawing.Size(742, 247)
        Me.gbDetalleMontos.TabIndex = 0
        Me.gbDetalleMontos.Text = "Detalle de Montos"
        Me.gbDetalleMontos.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalleMontos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.DataSource = Me.dgvDatos.Layouts
        dgvDatos_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatos_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatos_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatos_DesignTimeLayout_Reference_0})
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(12, 13)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(716, 147)
        Me.dgvDatos.TabIndex = 269
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'gbDatosCotizacion
        '
        Me.gbDatosCotizacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDatosCotizacion.Controls.Add(Me.btnVerRepuestos)
        Me.gbDatosCotizacion.Controls.Add(Me.btnDesvincularCotizacion)
        Me.gbDatosCotizacion.Controls.Add(Me.btnAsignarCotizacion)
        Me.gbDatosCotizacion.Controls.Add(Me.dgvCotAsignadas)
        Me.gbDatosCotizacion.Location = New System.Drawing.Point(5, 516)
        Me.gbDatosCotizacion.Name = "gbDatosCotizacion"
        Me.gbDatosCotizacion.Size = New System.Drawing.Size(744, 115)
        Me.gbDatosCotizacion.TabIndex = 0
        Me.gbDatosCotizacion.Text = "Datos de Cotización"
        Me.gbDatosCotizacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbDatosFacturacion
        '
        Me.gbDatosFacturacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDatosFacturacion.Controls.Add(Me.dgvDocFacturacion)
        Me.gbDatosFacturacion.Location = New System.Drawing.Point(5, 634)
        Me.gbDatosFacturacion.Name = "gbDatosFacturacion"
        Me.gbDatosFacturacion.Size = New System.Drawing.Size(721, 92)
        Me.gbDatosFacturacion.TabIndex = 245
        Me.gbDatosFacturacion.Text = "Datos de Facturación"
        Me.gbDatosFacturacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtMontoVenta)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoCosto)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoVenta)
        Me.UiGroupBox6.Controls.Add(Me.lblAsterisco)
        Me.UiGroupBox6.Controls.Add(Me.lblLeyenda)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoCosto)
        Me.UiGroupBox6.Location = New System.Drawing.Point(17, 423)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(715, 55)
        Me.UiGroupBox6.TabIndex = 270
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtMontoVenta
        '
        Me.txtMontoVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoVenta.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoVenta.Location = New System.Drawing.Point(589, 11)
        Me.txtMontoVenta.MaxLength = 5
        Me.txtMontoVenta.Name = "txtMontoVenta"
        Me.txtMontoVenta.ReadOnly = True
        Me.txtMontoVenta.Size = New System.Drawing.Size(104, 20)
        Me.txtMontoVenta.TabIndex = 3
        Me.txtMontoVenta.TabStop = False
        Me.txtMontoVenta.Text = "0.00"
        Me.txtMontoVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoVenta.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoCosto
        '
        Me.txtMontoCosto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoCosto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoCosto.Location = New System.Drawing.Point(589, 30)
        Me.txtMontoCosto.MaxLength = 5
        Me.txtMontoCosto.Name = "txtMontoCosto"
        Me.txtMontoCosto.ReadOnly = True
        Me.txtMontoCosto.Size = New System.Drawing.Size(104, 20)
        Me.txtMontoCosto.TabIndex = 10
        Me.txtMontoCosto.TabStop = False
        Me.txtMontoCosto.Text = "0.00"
        Me.txtMontoCosto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoCosto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoVenta
        '
        Me.lblMontoVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoVenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoVenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoVenta.Location = New System.Drawing.Point(16, 11)
        Me.lblMontoVenta.MaxLength = 20
        Me.lblMontoVenta.Name = "lblMontoVenta"
        Me.lblMontoVenta.ReadOnly = True
        Me.lblMontoVenta.Size = New System.Drawing.Size(574, 20)
        Me.lblMontoVenta.TabIndex = 8
        Me.lblMontoVenta.TabStop = False
        Me.lblMontoVenta.Text = "(Montos no incluyen Igv)  TOTAL MONTO VENTA:"
        Me.lblMontoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMontoCosto
        '
        Me.lblMontoCosto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoCosto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoCosto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoCosto.Location = New System.Drawing.Point(16, 30)
        Me.lblMontoCosto.MaxLength = 20
        Me.lblMontoCosto.Name = "lblMontoCosto"
        Me.lblMontoCosto.ReadOnly = True
        Me.lblMontoCosto.Size = New System.Drawing.Size(574, 20)
        Me.lblMontoCosto.TabIndex = 9
        Me.lblMontoCosto.TabStop = False
        Me.lblMontoCosto.Text = "TOTAL MONTO COSTO:"
        Me.lblMontoCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnidadNegocio
        '
        Me.lblUnidadNegocio.AutoSize = True
        Me.lblUnidadNegocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadNegocio.Location = New System.Drawing.Point(198, 9)
        Me.lblUnidadNegocio.Name = "lblUnidadNegocio"
        Me.lblUnidadNegocio.Size = New System.Drawing.Size(134, 15)
        Me.lblUnidadNegocio.TabIndex = 271
        Me.lblUnidadNegocio.Text = "Unidad de Negocio:"
        '
        'frmJob_Nuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(759, 780)
        Me.Controls.Add(Me.lblUnidadNegocio)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.gbDatosFacturacion)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbDatosCotizacion)
        Me.Controls.Add(Me.gbDatosJob)
        Me.Controls.Add(Me.gbDetalleMontos)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJob_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva OT"
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbFabricante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAplicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMantenimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDocFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCotAsignadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosJob.ResumeLayout(False)
        Me.gbDatosJob.PerformLayout()
        CType(Me.gbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalleMontos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalleMontos.ResumeLayout(False)
        Me.gbDetalleMontos.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.gbDatosCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosCotizacion.ResumeLayout(False)
        CType(Me.gbDatosFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosFacturacion.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biRegularGastos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents lblCreditState As System.Windows.Forms.Label
    Friend WithEvents lblNroClaim As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents cmbSupervisor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbFabricante As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblRegularizar As System.Windows.Forms.Label
    Friend WithEvents cmbUbicacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents cbNoFacturar As System.Windows.Forms.CheckBox
    Friend WithEvents cmbAplicacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarBeneficiario As System.Windows.Forms.Button
    Friend WithEvents btnBuscarSolicitante As System.Windows.Forms.Button
    Friend WithEvents cbKitRepower As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscarSolicitud As System.Windows.Forms.Button
    Friend WithEvents cmbMantenimiento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoJob As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents dgvDocFacturacion As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgvCotAsignadas As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtNumSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtModMer As System.Windows.Forms.TextBox
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents txtBeneficiario As System.Windows.Forms.TextBox
    Friend WithEvents txtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditState As System.Windows.Forms.TextBox
    Friend WithEvents txtNroClaim As System.Windows.Forms.TextBox
    Friend WithEvents txtFecLiqAdm As System.Windows.Forms.TextBox
    Friend WithEvents btnAsignarCotizacion As System.Windows.Forms.Button
    Friend WithEvents btnDesvincularCotizacion As System.Windows.Forms.Button
    Friend WithEvents btnVerRepuestos As System.Windows.Forms.Button
    Friend WithEvents lblAsterisco As System.Windows.Forms.Label
    Friend WithEvents lblLeyenda As System.Windows.Forms.Label
    Friend WithEvents gbDatosJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbDetalleMontos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDatosFacturacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbDatosCotizacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblMontoVenta As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoVenta As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtMontoCosto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoCosto As System.Windows.Forms.TextBox
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFecEntrega As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecLlegada As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblUnidadNegocio As System.Windows.Forms.Label
    Friend WithEvents lblMarcable As System.Windows.Forms.Label
    Friend WithEvents gbEstado As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinDesarmado As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinModulo As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtFecIniModulo As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecFinRep As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecIniRep As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtMontoHrsHombre As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
