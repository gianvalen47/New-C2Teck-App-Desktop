<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobConsulta_Nuevo
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
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobConsulta_Nuevo))
        Dim cmbFabricante_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUbicacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbAplicacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMantenimiento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim CmbTipoJob_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image")
        Dim cmbSupervisor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvCotAsignadas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDocFacturacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbFabricante = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblRegularizar = New System.Windows.Forms.Label()
        Me.cmbUbicacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbNoFacturar = New System.Windows.Forms.CheckBox()
        Me.cmbAplicacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbKit = New System.Windows.Forms.CheckBox()
        Me.cmbMantenimiento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.CmbTipoJob = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosJob = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecEntrega = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFecLlegada = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecFinRep = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtFecIniRep = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFecFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.txtModMer = New System.Windows.Forms.TextBox()
        Me.txtBeneficiario = New System.Windows.Forms.TextBox()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.txtNumSolicitud = New System.Windows.Forms.TextBox()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.gbDetalleMontos = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecLiqAdm = New System.Windows.Forms.TextBox()
        Me.txtCreditState = New System.Windows.Forms.TextBox()
        Me.txtNroClaim = New System.Windows.Forms.TextBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtMontoVenta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoCosto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblAsterisco = New System.Windows.Forms.Label()
        Me.lblMontoVenta = New System.Windows.Forms.TextBox()
        Me.lblLeyenda = New System.Windows.Forms.Label()
        Me.lblMontoCosto = New System.Windows.Forms.TextBox()
        Me.cmbSupervisor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblNroClaim = New System.Windows.Forms.Label()
        Me.lblCreditState = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.gbDatosCotizacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnVerRepuestos = New System.Windows.Forms.Button()
        Me.dgvCotAsignadas = New Janus.Windows.GridEX.GridEX()
        Me.gbDatosFacturacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDocFacturacion = New Janus.Windows.GridEX.GridEX()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbFabricante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAplicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMantenimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbTipoJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosJob.SuspendLayout()
        CType(Me.gbDetalleMontos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalleMontos.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosCotizacion.SuspendLayout()
        CType(Me.dgvCotAsignadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosFacturacion.SuspendLayout()
        CType(Me.dgvDocFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbCodMon
        '
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(607, 104)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(61, 20)
        Me.cmbCodMon.TabIndex = 161
        Me.cmbCodMon.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbFabricante
        '
        Me.cmbFabricante.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbFabricante_DesignTimeLayout.LayoutString = resources.GetString("cmbFabricante_DesignTimeLayout.LayoutString")
        Me.cmbFabricante.DesignTimeLayout = cmbFabricante_DesignTimeLayout
        Me.cmbFabricante.Location = New System.Drawing.Point(90, 60)
        Me.cmbFabricante.Name = "cmbFabricante"
        Me.cmbFabricante.SelectedIndex = -1
        Me.cmbFabricante.SelectedItem = Nothing
        Me.cmbFabricante.Size = New System.Drawing.Size(117, 20)
        Me.cmbFabricante.TabIndex = 227
        Me.cmbFabricante.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbFabricante.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbTipo
        '
        Me.cmbTipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipo_DesignTimeLayout.LayoutString")
        Me.cmbTipo.DesignTimeLayout = cmbTipo_DesignTimeLayout
        Me.cmbTipo.Location = New System.Drawing.Point(460, 38)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.SelectedIndex = -1
        Me.cmbTipo.SelectedItem = Nothing
        Me.cmbTipo.Size = New System.Drawing.Size(70, 20)
        Me.cmbTipo.TabIndex = 3
        Me.cmbTipo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblRegularizar
        '
        Me.lblRegularizar.AutoSize = True
        Me.lblRegularizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblRegularizar.Location = New System.Drawing.Point(13, 23)
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
        Me.cmbUbicacion.Location = New System.Drawing.Point(607, 126)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.SelectedIndex = -1
        Me.cmbUbicacion.SelectedItem = Nothing
        Me.cmbUbicacion.Size = New System.Drawing.Size(93, 20)
        Me.cmbUbicacion.TabIndex = 16
        Me.cmbUbicacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbUbicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbNoFacturar
        '
        Me.cbNoFacturar.AutoSize = True
        Me.cbNoFacturar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbNoFacturar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbNoFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNoFacturar.Location = New System.Drawing.Point(375, 108)
        Me.cbNoFacturar.Name = "cbNoFacturar"
        Me.cbNoFacturar.Size = New System.Drawing.Size(101, 17)
        Me.cbNoFacturar.TabIndex = 142
        Me.cbNoFacturar.Text = "No Facturar :"
        Me.cbNoFacturar.UseVisualStyleBackColor = False
        '
        'cmbAplicacion
        '
        Me.cmbAplicacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAplicacion_DesignTimeLayout.LayoutString = resources.GetString("cmbAplicacion_DesignTimeLayout.LayoutString")
        Me.cmbAplicacion.DesignTimeLayout = cmbAplicacion_DesignTimeLayout
        Me.cmbAplicacion.Location = New System.Drawing.Point(90, 104)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.SelectedIndex = -1
        Me.cmbAplicacion.SelectedItem = Nothing
        Me.cmbAplicacion.Size = New System.Drawing.Size(100, 20)
        Me.cmbAplicacion.TabIndex = 12
        Me.cmbAplicacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbAplicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbKit
        '
        Me.cbKit.AutoSize = True
        Me.cbKit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbKit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbKit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbKit.Location = New System.Drawing.Point(610, 64)
        Me.cbKit.Name = "cbKit"
        Me.cbKit.Size = New System.Drawing.Size(78, 17)
        Me.cbKit.TabIndex = 136
        Me.cbKit.Text = "Kit Rpw :"
        Me.cbKit.UseVisualStyleBackColor = False
        '
        'cmbMantenimiento
        '
        Me.cmbMantenimiento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMantenimiento_DesignTimeLayout.LayoutString = resources.GetString("cmbMantenimiento_DesignTimeLayout.LayoutString")
        Me.cmbMantenimiento.DesignTimeLayout = cmbMantenimiento_DesignTimeLayout
        Me.cmbMantenimiento.Location = New System.Drawing.Point(274, 60)
        Me.cmbMantenimiento.Name = "cmbMantenimiento"
        Me.cmbMantenimiento.SelectedIndex = -1
        Me.cmbMantenimiento.SelectedItem = Nothing
        Me.cmbMantenimiento.Size = New System.Drawing.Size(67, 20)
        Me.cmbMantenimiento.TabIndex = 5
        Me.cmbMantenimiento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMantenimiento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Location = New System.Drawing.Point(274, 38)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(95, 20)
        Me.cmbOficinas.TabIndex = 2
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
        'CmbTipoJob
        '
        Me.CmbTipoJob.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        CmbTipoJob_DesignTimeLayout.LayoutString = resources.GetString("CmbTipoJob_DesignTimeLayout.LayoutString")
        Me.CmbTipoJob.DesignTimeLayout = CmbTipoJob_DesignTimeLayout
        Me.CmbTipoJob.Location = New System.Drawing.Point(649, 38)
        Me.CmbTipoJob.Name = "CmbTipoJob"
        Me.CmbTipoJob.SelectedIndex = -1
        Me.CmbTipoJob.SelectedItem = Nothing
        Me.CmbTipoJob.Size = New System.Drawing.Size(78, 20)
        Me.CmbTipoJob.TabIndex = 4
        Me.CmbTipoJob.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.CmbTipoJob.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 748)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(756, 20)
        Me.ssBarra.TabIndex = 238
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(550, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.biImprimir, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator3})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(756, 31)
        Me.ToolStrip.TabIndex = 239
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosJob
        '
        Me.gbDatosJob.Controls.Add(Me.txtFecEntrega)
        Me.gbDatosJob.Controls.Add(Me.Label21)
        Me.gbDatosJob.Controls.Add(Me.txtFecLlegada)
        Me.gbDatosJob.Controls.Add(Me.txtFecFinRep)
        Me.gbDatosJob.Controls.Add(Me.Label20)
        Me.gbDatosJob.Controls.Add(Me.txtFecIniRep)
        Me.gbDatosJob.Controls.Add(Me.Label19)
        Me.gbDatosJob.Controls.Add(Me.Label7)
        Me.gbDatosJob.Controls.Add(Me.txtFecFin)
        Me.gbDatosJob.Controls.Add(Me.txtFecInicio)
        Me.gbDatosJob.Controls.Add(Me.txtCodMer)
        Me.gbDatosJob.Controls.Add(Me.txtModMer)
        Me.gbDatosJob.Controls.Add(Me.txtBeneficiario)
        Me.gbDatosJob.Controls.Add(Me.txtSolicitante)
        Me.gbDatosJob.Controls.Add(Me.txtNumSolicitud)
        Me.gbDatosJob.Controls.Add(Me.cmbUbicacion)
        Me.gbDatosJob.Controls.Add(Me.txtNumJob)
        Me.gbDatosJob.Controls.Add(Me.cmbFabricante)
        Me.gbDatosJob.Controls.Add(Me.cmbTipo)
        Me.gbDatosJob.Controls.Add(Me.cbNoFacturar)
        Me.gbDatosJob.Controls.Add(Me.txtDescripcion)
        Me.gbDatosJob.Controls.Add(Me.cmbAplicacion)
        Me.gbDatosJob.Controls.Add(Me.Label30)
        Me.gbDatosJob.Controls.Add(Me.Label31)
        Me.gbDatosJob.Controls.Add(Me.Label32)
        Me.gbDatosJob.Controls.Add(Me.Label33)
        Me.gbDatosJob.Controls.Add(Me.Label34)
        Me.gbDatosJob.Controls.Add(Me.Label35)
        Me.gbDatosJob.Controls.Add(Me.Label36)
        Me.gbDatosJob.Controls.Add(Me.cbKit)
        Me.gbDatosJob.Controls.Add(Me.Label37)
        Me.gbDatosJob.Controls.Add(Me.Label38)
        Me.gbDatosJob.Controls.Add(Me.Label39)
        Me.gbDatosJob.Controls.Add(Me.Label40)
        Me.gbDatosJob.Controls.Add(Me.cmbMantenimiento)
        Me.gbDatosJob.Controls.Add(Me.Label45)
        Me.gbDatosJob.Controls.Add(Me.Label46)
        Me.gbDatosJob.Controls.Add(Me.Label47)
        Me.gbDatosJob.Controls.Add(Me.cmbOficinas)
        Me.gbDatosJob.Controls.Add(Me.Label48)
        Me.gbDatosJob.Controls.Add(Me.Label49)
        Me.gbDatosJob.Controls.Add(Me.Label50)
        Me.gbDatosJob.Controls.Add(Me.Label51)
        Me.gbDatosJob.Controls.Add(Me.lblEstado)
        Me.gbDatosJob.Controls.Add(Me.lblRegularizar)
        Me.gbDatosJob.Controls.Add(Me.CmbTipoJob)
        Me.gbDatosJob.Controls.Add(Me.cmbCodMon)
        Me.gbDatosJob.Location = New System.Drawing.Point(5, 32)
        Me.gbDatosJob.Name = "gbDatosJob"
        Me.gbDatosJob.Size = New System.Drawing.Size(741, 239)
        Me.gbDatosJob.TabIndex = 240
        Me.gbDatosJob.Text = "Datos del Job"
        Me.gbDatosJob.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFecEntrega
        '
        Me.txtFecEntrega.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecEntrega.DropDownCalendar.Name = ""
        Me.txtFecEntrega.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecEntrega.IsNullDate = True
        Me.txtFecEntrega.Location = New System.Drawing.Point(642, 206)
        Me.txtFecEntrega.Name = "txtFecEntrega"
        Me.txtFecEntrega.ReadOnly = True
        Me.txtFecEntrega.Size = New System.Drawing.Size(90, 20)
        Me.txtFecEntrega.TabIndex = 260
        Me.txtFecEntrega.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(552, 210)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(88, 13)
        Me.Label21.TabIndex = 258
        Me.Label21.Text = "Fec. Entrega :"
        '
        'txtFecLlegada
        '
        Me.txtFecLlegada.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecLlegada.DropDownCalendar.Name = ""
        Me.txtFecLlegada.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecLlegada.IsNullDate = True
        Me.txtFecLlegada.Location = New System.Drawing.Point(94, 206)
        Me.txtFecLlegada.Name = "txtFecLlegada"
        Me.txtFecLlegada.ReadOnly = True
        Me.txtFecLlegada.Size = New System.Drawing.Size(90, 20)
        Me.txtFecLlegada.TabIndex = 259
        Me.txtFecLlegada.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecFinRep
        '
        Me.txtFecFinRep.Location = New System.Drawing.Point(475, 207)
        Me.txtFecFinRep.Name = "txtFecFinRep"
        Me.txtFecFinRep.ReadOnly = True
        Me.txtFecFinRep.Size = New System.Drawing.Size(70, 20)
        Me.txtFecFinRep.TabIndex = 256
        Me.txtFecFinRep.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(377, 209)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 257
        Me.Label20.Text = "Fec. Fin. Rep. :"
        '
        'txtFecIniRep
        '
        Me.txtFecIniRep.Location = New System.Drawing.Point(292, 206)
        Me.txtFecIniRep.Name = "txtFecIniRep"
        Me.txtFecIniRep.ReadOnly = True
        Me.txtFecIniRep.Size = New System.Drawing.Size(70, 20)
        Me.txtFecIniRep.TabIndex = 254
        Me.txtFecIniRep.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(196, 210)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 13)
        Me.Label19.TabIndex = 255
        Me.Label19.Text = "Fec. Ini. Rep. :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 253
        Me.Label7.Text = "Fec. Llegada :"
        '
        'txtFecFin
        '
        '
        '
        '
        Me.txtFecFin.DropDownCalendar.Name = ""
        Me.txtFecFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFin.Location = New System.Drawing.Point(537, 148)
        Me.txtFecFin.Name = "txtFecFin"
        Me.txtFecFin.NullButtonText = "Ninguno"
        Me.txtFecFin.ReadOnly = True
        Me.txtFecFin.Size = New System.Drawing.Size(82, 20)
        Me.txtFecFin.TabIndex = 252
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
        Me.txtFecInicio.Location = New System.Drawing.Point(359, 148)
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.NullButtonText = "Ninguno"
        Me.txtFecInicio.ReadOnly = True
        Me.txtFecInicio.Size = New System.Drawing.Size(82, 20)
        Me.txtFecInicio.TabIndex = 242
        Me.txtFecInicio.TodayButtonText = "Hoy"
        Me.txtFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtCodMer
        '
        Me.txtCodMer.Location = New System.Drawing.Point(90, 126)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(105, 20)
        Me.txtCodMer.TabIndex = 241
        '
        'txtModMer
        '
        Me.txtModMer.Location = New System.Drawing.Point(325, 126)
        Me.txtModMer.Name = "txtModMer"
        Me.txtModMer.Size = New System.Drawing.Size(156, 20)
        Me.txtModMer.TabIndex = 242
        '
        'txtBeneficiario
        '
        Me.txtBeneficiario.Location = New System.Drawing.Point(460, 82)
        Me.txtBeneficiario.Name = "txtBeneficiario"
        Me.txtBeneficiario.Size = New System.Drawing.Size(227, 20)
        Me.txtBeneficiario.TabIndex = 251
        '
        'txtSolicitante
        '
        Me.txtSolicitante.Location = New System.Drawing.Point(90, 82)
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.Size = New System.Drawing.Size(243, 20)
        Me.txtSolicitante.TabIndex = 250
        '
        'txtNumSolicitud
        '
        Me.txtNumSolicitud.Location = New System.Drawing.Point(460, 60)
        Me.txtNumSolicitud.Name = "txtNumSolicitud"
        Me.txtNumSolicitud.Size = New System.Drawing.Size(100, 20)
        Me.txtNumSolicitud.TabIndex = 249
        '
        'txtNumJob
        '
        Me.txtNumJob.Location = New System.Drawing.Point(90, 38)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(70, 20)
        Me.txtNumJob.TabIndex = 248
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(90, 170)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(595, 30)
        Me.txtDescripcion.TabIndex = 247
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(11, 63)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(75, 13)
        Me.Label30.TabIndex = 246
        Me.Label30.Text = "Fabricante :"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(51, 41)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(32, 13)
        Me.Label31.TabIndex = 229
        Me.Label31.Text = "OT :"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(213, 41)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(55, 13)
        Me.Label32.TabIndex = 230
        Me.Label32.Text = "Oficina :"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(397, 42)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(61, 13)
        Me.Label33.TabIndex = 231
        Me.Label33.Text = "Realizar :"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(607, 41)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(40, 13)
        Me.Label34.TabIndex = 232
        Me.Label34.Text = "Tipo :"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(225, 63)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(43, 13)
        Me.Label35.TabIndex = 233
        Me.Label35.Text = "Mant.:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(366, 65)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(92, 13)
        Me.Label36.TabIndex = 234
        Me.Label36.Text = "Nro. Solicitud :"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(11, 85)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(75, 13)
        Me.Label37.TabIndex = 235
        Me.Label37.Text = "Solicitante :"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(376, 85)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(82, 13)
        Me.Label38.TabIndex = 236
        Me.Label38.Text = "Beneficiario :"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(12, 108)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(74, 13)
        Me.Label39.TabIndex = 237
        Me.Label39.Text = "Aplicación :"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(42, 129)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(44, 13)
        Me.Label40.TabIndex = 238
        Me.Label40.Text = "Serie :"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(263, 129)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(56, 13)
        Me.Label45.TabIndex = 239
        Me.Label45.Text = "Modelo :"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(4, 173)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(82, 13)
        Me.Label46.TabIndex = 244
        Me.Label46.Text = "Descripción :"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(529, 129)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(72, 13)
        Me.Label47.TabIndex = 240
        Me.Label47.Text = "Ubicación :"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(471, 152)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(60, 13)
        Me.Label48.TabIndex = 243
        Me.Label48.Text = "Termino :"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(4, 152)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(276, 13)
        Me.Label49.TabIndex = 241
        Me.Label49.Text = "Fechas Estimadas de Realizacion del Servicio :"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(307, 152)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(46, 13)
        Me.Label50.TabIndex = 242
        Me.Label50.Text = "Inicio :"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(541, 108)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(60, 13)
        Me.Label51.TabIndex = 245
        Me.Label51.Text = "Moneda :"
        '
        'gbDetalleMontos
        '
        Me.gbDetalleMontos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalleMontos.Controls.Add(Me.txtFecLiqAdm)
        Me.gbDetalleMontos.Controls.Add(Me.txtCreditState)
        Me.gbDetalleMontos.Controls.Add(Me.txtNroClaim)
        Me.gbDetalleMontos.Controls.Add(Me.dgvDatos)
        Me.gbDetalleMontos.Controls.Add(Me.UiGroupBox6)
        Me.gbDetalleMontos.Controls.Add(Me.cmbSupervisor)
        Me.gbDetalleMontos.Controls.Add(Me.Label41)
        Me.gbDetalleMontos.Controls.Add(Me.lblNroClaim)
        Me.gbDetalleMontos.Controls.Add(Me.lblCreditState)
        Me.gbDetalleMontos.Controls.Add(Me.Label43)
        Me.gbDetalleMontos.Location = New System.Drawing.Point(5, 277)
        Me.gbDetalleMontos.Name = "gbDetalleMontos"
        Me.gbDetalleMontos.Size = New System.Drawing.Size(741, 244)
        Me.gbDetalleMontos.TabIndex = 242
        Me.gbDetalleMontos.Text = "Detalle de Montos"
        Me.gbDetalleMontos.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalleMontos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFecLiqAdm
        '
        Me.txtFecLiqAdm.Location = New System.Drawing.Point(375, 220)
        Me.txtFecLiqAdm.Name = "txtFecLiqAdm"
        Me.txtFecLiqAdm.ReadOnly = True
        Me.txtFecLiqAdm.Size = New System.Drawing.Size(101, 20)
        Me.txtFecLiqAdm.TabIndex = 275
        '
        'txtCreditState
        '
        Me.txtCreditState.Location = New System.Drawing.Point(375, 197)
        Me.txtCreditState.Name = "txtCreditState"
        Me.txtCreditState.Size = New System.Drawing.Size(128, 20)
        Me.txtCreditState.TabIndex = 274
        '
        'txtNroClaim
        '
        Me.txtNroClaim.Location = New System.Drawing.Point(128, 197)
        Me.txtNroClaim.Name = "txtNroClaim"
        Me.txtNroClaim.Size = New System.Drawing.Size(128, 20)
        Me.txtNroClaim.TabIndex = 273
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.DataSource = Me.dgvDatos.Layouts
        dgvDatos_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatos_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatos_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatos_DesignTimeLayout_Reference_0})
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(26, 15)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(688, 123)
        Me.dgvDatos.TabIndex = 271
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtMontoVenta)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoCosto)
        Me.UiGroupBox6.Controls.Add(Me.lblAsterisco)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoVenta)
        Me.UiGroupBox6.Controls.Add(Me.lblLeyenda)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoCosto)
        Me.UiGroupBox6.Location = New System.Drawing.Point(27, 136)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(687, 55)
        Me.UiGroupBox6.TabIndex = 272
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtMontoVenta
        '
        Me.txtMontoVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoVenta.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoVenta.Location = New System.Drawing.Point(568, 11)
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
        Me.txtMontoCosto.Location = New System.Drawing.Point(568, 30)
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
        'lblAsterisco
        '
        Me.lblAsterisco.AutoSize = True
        Me.lblAsterisco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsterisco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblAsterisco.Location = New System.Drawing.Point(21, 32)
        Me.lblAsterisco.Name = "lblAsterisco"
        Me.lblAsterisco.Size = New System.Drawing.Size(14, 16)
        Me.lblAsterisco.TabIndex = 248
        Me.lblAsterisco.Text = "*"
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
        Me.lblMontoVenta.Size = New System.Drawing.Size(553, 20)
        Me.lblMontoVenta.TabIndex = 8
        Me.lblMontoVenta.TabStop = False
        Me.lblMontoVenta.Text = "(Montos no incluyen Igv)  TOTAL MONTO VENTA:"
        Me.lblMontoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLeyenda
        '
        Me.lblLeyenda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblLeyenda.Location = New System.Drawing.Point(31, 33)
        Me.lblLeyenda.Name = "lblLeyenda"
        Me.lblLeyenda.Size = New System.Drawing.Size(362, 16)
        Me.lblLeyenda.TabIndex = 247
        Me.lblLeyenda.Text = "lblLeyenda"
        Me.lblLeyenda.Visible = False
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
        Me.lblMontoCosto.Size = New System.Drawing.Size(553, 20)
        Me.lblMontoCosto.TabIndex = 9
        Me.lblMontoCosto.TabStop = False
        Me.lblMontoCosto.Text = "TOTAL MONTO COSTO:"
        Me.lblMontoCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbSupervisor
        '
        Me.cmbSupervisor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSupervisor_DesignTimeLayout.LayoutString = resources.GetString("cmbSupervisor_DesignTimeLayout.LayoutString")
        Me.cmbSupervisor.DesignTimeLayout = cmbSupervisor_DesignTimeLayout
        Me.cmbSupervisor.Location = New System.Drawing.Point(128, 219)
        Me.cmbSupervisor.Name = "cmbSupervisor"
        Me.cmbSupervisor.SelectedIndex = -1
        Me.cmbSupervisor.SelectedItem = Nothing
        Me.cmbSupervisor.Size = New System.Drawing.Size(128, 20)
        Me.cmbSupervisor.TabIndex = 20
        Me.cmbSupervisor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbSupervisor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(47, 222)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(75, 13)
        Me.Label41.TabIndex = 213
        Me.Label41.Text = "Supervisor :"
        '
        'lblNroClaim
        '
        Me.lblNroClaim.AutoSize = True
        Me.lblNroClaim.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroClaim.Location = New System.Drawing.Point(30, 200)
        Me.lblNroClaim.Name = "lblNroClaim"
        Me.lblNroClaim.Size = New System.Drawing.Size(92, 13)
        Me.lblNroClaim.TabIndex = 211
        Me.lblNroClaim.Text = "Nro. Reclamo :"
        '
        'lblCreditState
        '
        Me.lblCreditState.AutoSize = True
        Me.lblCreditState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditState.Location = New System.Drawing.Point(288, 200)
        Me.lblCreditState.Name = "lblCreditState"
        Me.lblCreditState.Size = New System.Drawing.Size(82, 13)
        Me.lblCreditState.TabIndex = 212
        Me.lblCreditState.Text = "Credit State :"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(289, 223)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(80, 13)
        Me.Label43.TabIndex = 218
        Me.Label43.Text = "Liquidación :"
        '
        'gbDatosCotizacion
        '
        Me.gbDatosCotizacion.Controls.Add(Me.btnVerRepuestos)
        Me.gbDatosCotizacion.Controls.Add(Me.dgvCotAsignadas)
        Me.gbDatosCotizacion.Location = New System.Drawing.Point(5, 525)
        Me.gbDatosCotizacion.Name = "gbDatosCotizacion"
        Me.gbDatosCotizacion.Size = New System.Drawing.Size(741, 115)
        Me.gbDatosCotizacion.TabIndex = 243
        Me.gbDatosCotizacion.Text = "Datos de Cotización"
        Me.gbDatosCotizacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnVerRepuestos
        '
        Me.btnVerRepuestos.Image = CType(resources.GetObject("btnVerRepuestos.Image"), System.Drawing.Image)
        Me.btnVerRepuestos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerRepuestos.Location = New System.Drawing.Point(7, 14)
        Me.btnVerRepuestos.Name = "btnVerRepuestos"
        Me.btnVerRepuestos.Size = New System.Drawing.Size(100, 24)
        Me.btnVerRepuestos.TabIndex = 235
        Me.btnVerRepuestos.Text = "Ver Repuestos"
        Me.btnVerRepuestos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVerRepuestos.UseVisualStyleBackColor = True
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
        Me.dgvCotAsignadas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvCotAsignadas.Size = New System.Drawing.Size(376, 70)
        Me.dgvCotAsignadas.TabIndex = 234
        Me.dgvCotAsignadas.TabStop = False
        Me.dgvCotAsignadas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gbDatosFacturacion
        '
        Me.gbDatosFacturacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDatosFacturacion.Controls.Add(Me.dgvDocFacturacion)
        Me.gbDatosFacturacion.Location = New System.Drawing.Point(5, 644)
        Me.gbDatosFacturacion.Name = "gbDatosFacturacion"
        Me.gbDatosFacturacion.Size = New System.Drawing.Size(741, 92)
        Me.gbDatosFacturacion.TabIndex = 244
        Me.gbDatosFacturacion.Text = "Datos de Facturación"
        Me.gbDatosFacturacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvDocFacturacion
        '
        Me.dgvDocFacturacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvDocFacturacion_DesignTimeLayout.LayoutString = resources.GetString("dgvDocFacturacion_DesignTimeLayout.LayoutString")
        Me.dgvDocFacturacion.DesignTimeLayout = dgvDocFacturacion_DesignTimeLayout
        Me.dgvDocFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDocFacturacion.GroupByBoxVisible = False
        Me.dgvDocFacturacion.Location = New System.Drawing.Point(7, 15)
        Me.dgvDocFacturacion.Name = "dgvDocFacturacion"
        Me.dgvDocFacturacion.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDocFacturacion.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDocFacturacion.Size = New System.Drawing.Size(727, 71)
        Me.dgvDocFacturacion.TabIndex = 235
        Me.dgvDocFacturacion.TabStop = False
        Me.dgvDocFacturacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmJobConsulta_Nuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 768)
        Me.Controls.Add(Me.gbDatosFacturacion)
        Me.Controls.Add(Me.gbDatosCotizacion)
        Me.Controls.Add(Me.gbDetalleMontos)
        Me.Controls.Add(Me.gbDatosJob)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJobConsulta_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OT Consulta Mostrar"
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbFabricante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAplicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMantenimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbTipoJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosJob.ResumeLayout(False)
        Me.gbDatosJob.PerformLayout()
        CType(Me.gbDetalleMontos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalleMontos.ResumeLayout(False)
        Me.gbDetalleMontos.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosCotizacion.ResumeLayout(False)
        CType(Me.dgvCotAsignadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosFacturacion.ResumeLayout(False)
        CType(Me.dgvDocFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblRegularizar As System.Windows.Forms.Label
    Friend WithEvents cmbUbicacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbNoFacturar As System.Windows.Forms.CheckBox
    Friend WithEvents cmbAplicacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbKit As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMantenimiento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents CmbTipoJob As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbFabricante As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbDatosJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents txtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents txtNumSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents txtModMer As System.Windows.Forms.TextBox
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents txtBeneficiario As System.Windows.Forms.TextBox
    Friend WithEvents txtFecFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbDatosFacturacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDocFacturacion As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDatosCotizacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnVerRepuestos As System.Windows.Forms.Button
    Friend WithEvents dgvCotAsignadas As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDetalleMontos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtMontoVenta As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoCosto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblAsterisco As System.Windows.Forms.Label
    Friend WithEvents lblMontoVenta As System.Windows.Forms.TextBox
    Friend WithEvents lblLeyenda As System.Windows.Forms.Label
    Friend WithEvents lblMontoCosto As System.Windows.Forms.TextBox
    Friend WithEvents cmbSupervisor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lblNroClaim As System.Windows.Forms.Label
    Friend WithEvents lblCreditState As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtFecEntrega As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtFecLlegada As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecFinRep As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtFecIniRep As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFecLiqAdm As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditState As System.Windows.Forms.TextBox
    Friend WithEvents txtNroClaim As System.Windows.Forms.TextBox
End Class
