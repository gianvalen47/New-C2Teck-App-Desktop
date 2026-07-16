<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudGastoDet_Viaje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudGastoDet_Viaje))
        Dim dgvCentrosCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvJos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbSubRubroViaje_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbRubroViaje_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbPlaca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Tooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.biLimpiarPdf = New Janus.Windows.EditControls.UIButton()
        Me.biLimpiarXml = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarPdf = New System.Windows.Forms.Button()
        Me.btnBuscarXml = New System.Windows.Forms.Button()
        Me.btnLimpiarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.btnAgregarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.cmOpcionesCentrosCosto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAsignarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarCentroCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmOpcionesJobs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miAsignarJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.miProcesarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarCompras = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbCentroCosto = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvCentrosCosto = New Janus.Windows.GridEX.GridEX()
        Me.gbJobs = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvJos = New Janus.Windows.GridEX.GridEX()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbFacturacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtItem = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPdfFE = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtXmlFE = New System.Windows.Forms.TextBox()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtSerieDoc = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbProveedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.gbGastoViaje = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbNoAplicaPolitica = New System.Windows.Forms.CheckBox()
        Me.txtObservSubRubro = New System.Windows.Forms.TextBox()
        Me.cmbSubRubroViaje = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbRubroViaje = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbPlaca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.bgMontos = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCantidad = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMontoIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtMontoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtMontoNoAfecto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbAfectoIgv = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesCentrosCosto.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.cmOpcionesJobs.SuspendLayout()
        CType(Me.gbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCentroCosto.SuspendLayout()
        CType(Me.dgvCentrosCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbJobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbJobs.SuspendLayout()
        CType(Me.dgvJos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFacturacion.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGastoViaje.SuspendLayout()
        CType(Me.cmbSubRubroViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbRubroViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgMontos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bgMontos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'biLimpiarPdf
        '
        Me.biLimpiarPdf.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.biLimpiarPdf.Location = New System.Drawing.Point(612, 52)
        Me.biLimpiarPdf.Name = "biLimpiarPdf"
        Me.biLimpiarPdf.Size = New System.Drawing.Size(25, 22)
        Me.biLimpiarPdf.TabIndex = 12
        Me.biLimpiarPdf.TabStop = False
        Me.Tooltip.SetToolTip(Me.biLimpiarPdf, "Limpiar Pdf")
        '
        'biLimpiarXml
        '
        Me.biLimpiarXml.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.biLimpiarXml.Location = New System.Drawing.Point(311, 52)
        Me.biLimpiarXml.Name = "biLimpiarXml"
        Me.biLimpiarXml.Size = New System.Drawing.Size(25, 22)
        Me.biLimpiarXml.TabIndex = 11
        Me.biLimpiarXml.TabStop = False
        Me.Tooltip.SetToolTip(Me.biLimpiarXml, "Limpiar Xml")
        '
        'btnBuscarPdf
        '
        Me.btnBuscarPdf.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPdf.Location = New System.Drawing.Point(586, 52)
        Me.btnBuscarPdf.Name = "btnBuscarPdf"
        Me.btnBuscarPdf.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPdf.TabIndex = 11
        Me.btnBuscarPdf.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnBuscarPdf, "Buscar Pdf")
        Me.btnBuscarPdf.UseVisualStyleBackColor = True
        '
        'btnBuscarXml
        '
        Me.btnBuscarXml.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarXml.Location = New System.Drawing.Point(285, 52)
        Me.btnBuscarXml.Name = "btnBuscarXml"
        Me.btnBuscarXml.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarXml.TabIndex = 10
        Me.btnBuscarXml.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnBuscarXml, "Buscar Xml")
        Me.btnBuscarXml.UseVisualStyleBackColor = True
        '
        'btnLimpiarProveedor
        '
        Me.btnLimpiarProveedor.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarProveedor.Location = New System.Drawing.Point(566, 13)
        Me.btnLimpiarProveedor.Name = "btnLimpiarProveedor"
        Me.btnLimpiarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarProveedor.TabIndex = 5
        Me.btnLimpiarProveedor.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnLimpiarProveedor, "Limpiar Proveedor")
        '
        'btnAgregarProveedor
        '
        Me.btnAgregarProveedor.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnAgregarProveedor.Location = New System.Drawing.Point(538, 13)
        Me.btnAgregarProveedor.Name = "btnAgregarProveedor"
        Me.btnAgregarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnAgregarProveedor.TabIndex = 4
        Me.btnAgregarProveedor.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnAgregarProveedor, "Agregar Proveedor")
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(510, 13)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 3
        Me.btnBuscarProveedor.TabStop = False
        Me.Tooltip.SetToolTip(Me.btnBuscarProveedor, "Buscar Proveedor")
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'cmOpcionesCentrosCosto
        '
        Me.cmOpcionesCentrosCosto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAsignarCentroCosto, Me.miMostrarCentroCosto, Me.ToolStripSeparator2, Me.ToolStripSeparator1, Me.miActualizarCentroCosto})
        Me.cmOpcionesCentrosCosto.Name = "cmOpciones"
        Me.cmOpcionesCentrosCosto.Size = New System.Drawing.Size(221, 82)
        '
        'miAsignarCentroCosto
        '
        Me.miAsignarCentroCosto.Image = CType(resources.GetObject("miAsignarCentroCosto.Image"), System.Drawing.Image)
        Me.miAsignarCentroCosto.Name = "miAsignarCentroCosto"
        Me.miAsignarCentroCosto.Size = New System.Drawing.Size(220, 22)
        Me.miAsignarCentroCosto.Text = "Asignar Centros de Costo"
        Me.miAsignarCentroCosto.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarCentroCosto
        '
        Me.miMostrarCentroCosto.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarCentroCosto.Name = "miMostrarCentroCosto"
        Me.miMostrarCentroCosto.Size = New System.Drawing.Size(220, 22)
        Me.miMostrarCentroCosto.Text = "Mostrar Centro de Costo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(217, 6)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(217, 6)
        '
        'miActualizarCentroCosto
        '
        Me.miActualizarCentroCosto.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarCentroCosto.Name = "miActualizarCentroCosto"
        Me.miActualizarCentroCosto.Size = New System.Drawing.Size(220, 22)
        Me.miActualizarCentroCosto.Text = "Actualizar Centros de Costo"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biGuardar, Me.ToolStripSeparator5, Me.biEditar, Me.ToolStripSeparator6, Me.biDeshacer, Me.ToolStripSeparator8, Me.biCerrar, Me.ToolStripSeparator9})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(671, 31)
        Me.ToolStrip1.TabIndex = 244
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Datos"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'cmOpcionesJobs
        '
        Me.cmOpcionesJobs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miAsignarJobs, Me.miMostrarJob, Me.miEliminarJob, Me.miProcesarJob, Me.miMostrarCompras, Me.ToolStripSeparator3, Me.ToolStripSeparator7, Me.miActualizarJobs})
        Me.cmOpcionesJobs.Name = "cmOpciones"
        Me.cmOpcionesJobs.Size = New System.Drawing.Size(167, 148)
        '
        'miAsignarJobs
        '
        Me.miAsignarJobs.Image = CType(resources.GetObject("miAsignarJobs.Image"), System.Drawing.Image)
        Me.miAsignarJobs.Name = "miAsignarJobs"
        Me.miAsignarJobs.Size = New System.Drawing.Size(166, 22)
        Me.miAsignarJobs.Text = "Asignar Job's"
        Me.miAsignarJobs.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarJob
        '
        Me.miMostrarJob.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarJob.Name = "miMostrarJob"
        Me.miMostrarJob.Size = New System.Drawing.Size(166, 22)
        Me.miMostrarJob.Text = "Mostrar Job"
        '
        'miEliminarJob
        '
        Me.miEliminarJob.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarJob.Name = "miEliminarJob"
        Me.miEliminarJob.Size = New System.Drawing.Size(166, 22)
        Me.miEliminarJob.Text = "Eliminar Job"
        '
        'miProcesarJob
        '
        Me.miProcesarJob.Image = CType(resources.GetObject("miProcesarJob.Image"), System.Drawing.Image)
        Me.miProcesarJob.Name = "miProcesarJob"
        Me.miProcesarJob.Size = New System.Drawing.Size(166, 22)
        Me.miProcesarJob.Text = "Procesar Job"
        Me.miProcesarJob.Visible = False
        '
        'miMostrarCompras
        '
        Me.miMostrarCompras.Image = CType(resources.GetObject("miMostrarCompras.Image"), System.Drawing.Image)
        Me.miMostrarCompras.Name = "miMostrarCompras"
        Me.miMostrarCompras.Size = New System.Drawing.Size(166, 22)
        Me.miMostrarCompras.Text = "Mostrar Compras"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(163, 6)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(163, 6)
        '
        'miActualizarJobs
        '
        Me.miActualizarJobs.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarJobs.Name = "miActualizarJobs"
        Me.miActualizarJobs.Size = New System.Drawing.Size(166, 22)
        Me.miActualizarJobs.Text = "Actualizar Job's"
        '
        'gbCentroCosto
        '
        Me.gbCentroCosto.Controls.Add(Me.dgvCentrosCosto)
        Me.gbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCentroCosto.Location = New System.Drawing.Point(5, 401)
        Me.gbCentroCosto.Name = "gbCentroCosto"
        Me.gbCentroCosto.Size = New System.Drawing.Size(658, 95)
        Me.gbCentroCosto.TabIndex = 248
        Me.gbCentroCosto.Text = "Centros de Costo"
        Me.gbCentroCosto.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbCentroCosto.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvCentrosCosto
        '
        Me.dgvCentrosCosto.ContextMenuStrip = Me.cmOpcionesCentrosCosto
        dgvCentrosCosto_DesignTimeLayout.LayoutString = resources.GetString("dgvCentrosCosto_DesignTimeLayout.LayoutString")
        Me.dgvCentrosCosto.DesignTimeLayout = dgvCentrosCosto_DesignTimeLayout
        Me.dgvCentrosCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvCentrosCosto.GroupByBoxVisible = False
        Me.dgvCentrosCosto.Location = New System.Drawing.Point(6, 13)
        Me.dgvCentrosCosto.Name = "dgvCentrosCosto"
        Me.dgvCentrosCosto.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCentrosCosto.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCentrosCosto.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCentrosCosto.Size = New System.Drawing.Size(646, 78)
        Me.dgvCentrosCosto.TabIndex = 228
        Me.dgvCentrosCosto.TabStop = False
        Me.dgvCentrosCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbJobs
        '
        Me.gbJobs.Controls.Add(Me.dgvJos)
        Me.gbJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbJobs.Location = New System.Drawing.Point(5, 495)
        Me.gbJobs.Name = "gbJobs"
        Me.gbJobs.Size = New System.Drawing.Size(658, 93)
        Me.gbJobs.TabIndex = 249
        Me.gbJobs.Text = "Job's"
        Me.gbJobs.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbJobs.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvJos
        '
        Me.dgvJos.ContextMenuStrip = Me.cmOpcionesJobs
        dgvJos_DesignTimeLayout.LayoutString = resources.GetString("dgvJos_DesignTimeLayout.LayoutString")
        Me.dgvJos.DesignTimeLayout = dgvJos_DesignTimeLayout
        Me.dgvJos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvJos.GroupByBoxVisible = False
        Me.dgvJos.Location = New System.Drawing.Point(6, 12)
        Me.dgvJos.Name = "dgvJos"
        Me.dgvJos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvJos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvJos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvJos.Size = New System.Drawing.Size(646, 78)
        Me.dgvJos.TabIndex = 228
        Me.dgvJos.TabStop = False
        Me.dgvJos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.UiGroupBox1)
        Me.gbDetalle.Controls.Add(Me.gbFacturacion)
        Me.gbDetalle.Controls.Add(Me.gbProveedor)
        Me.gbDetalle.Controls.Add(Me.gbGastoViaje)
        Me.gbDetalle.Controls.Add(Me.bgMontos)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(5, 28)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(658, 369)
        Me.gbDetalle.TabIndex = 247
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtDescripcion)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 200)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(646, 57)
        Me.UiGroupBox1.TabIndex = 16
        Me.UiGroupBox1.Text = "Detalle y Justificación"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(90, 19)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(550, 32)
        Me.txtDescripcion.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Descripción"
        '
        'gbFacturacion
        '
        Me.gbFacturacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.gbFacturacion.Controls.Add(Me.txtItem)
        Me.gbFacturacion.Controls.Add(Me.biLimpiarPdf)
        Me.gbFacturacion.Controls.Add(Me.biLimpiarXml)
        Me.gbFacturacion.Controls.Add(Me.btnBuscarPdf)
        Me.gbFacturacion.Controls.Add(Me.Label26)
        Me.gbFacturacion.Controls.Add(Me.txtPdfFE)
        Me.gbFacturacion.Controls.Add(Me.btnBuscarXml)
        Me.gbFacturacion.Controls.Add(Me.Label14)
        Me.gbFacturacion.Controls.Add(Me.txtXmlFE)
        Me.gbFacturacion.Controls.Add(Me.txtFecDoc)
        Me.gbFacturacion.Controls.Add(Me.txtSerieDoc)
        Me.gbFacturacion.Controls.Add(Me.Label16)
        Me.gbFacturacion.Controls.Add(Me.txtNumDoc)
        Me.gbFacturacion.Controls.Add(Me.Label5)
        Me.gbFacturacion.Controls.Add(Me.Label15)
        Me.gbFacturacion.Controls.Add(Me.cmbTipoDoc)
        Me.gbFacturacion.Controls.Add(Me.Label6)
        Me.gbFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFacturacion.ForeColor = System.Drawing.Color.Black
        Me.gbFacturacion.Location = New System.Drawing.Point(6, 55)
        Me.gbFacturacion.Name = "gbFacturacion"
        Me.gbFacturacion.Size = New System.Drawing.Size(646, 78)
        Me.gbFacturacion.TabIndex = 4
        Me.gbFacturacion.Text = "Facturación"
        Me.gbFacturacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtItem
        '
        Me.txtItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItem.Location = New System.Drawing.Point(568, 9)
        Me.txtItem.Maximum = 300
        Me.txtItem.MaxLength = 200
        Me.txtItem.Minimum = 1
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(46, 20)
        Me.txtItem.TabIndex = 186
        Me.txtItem.TabStop = False
        Me.txtItem.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtItem.Value = 1
        Me.txtItem.Visible = False
        Me.txtItem.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(343, 56)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(66, 13)
        Me.Label26.TabIndex = 47
        Me.Label26.Text = "PDF (F.E.)"
        '
        'txtPdfFE
        '
        Me.txtPdfFE.BackColor = System.Drawing.SystemColors.Control
        Me.txtPdfFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPdfFE.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPdfFE.Location = New System.Drawing.Point(409, 53)
        Me.txtPdfFE.MaxLength = 10
        Me.txtPdfFE.Name = "txtPdfFE"
        Me.txtPdfFE.ReadOnly = True
        Me.txtPdfFE.Size = New System.Drawing.Size(175, 20)
        Me.txtPdfFE.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(37, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 44
        Me.Label14.Text = "XML (F.E.)"
        '
        'txtXmlFE
        '
        Me.txtXmlFE.BackColor = System.Drawing.SystemColors.Control
        Me.txtXmlFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXmlFE.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtXmlFE.Location = New System.Drawing.Point(108, 53)
        Me.txtXmlFE.MaxLength = 10
        Me.txtXmlFE.Name = "txtXmlFE"
        Me.txtXmlFE.ReadOnly = True
        Me.txtXmlFE.Size = New System.Drawing.Size(175, 20)
        Me.txtXmlFE.TabIndex = 9
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.IsNullDate = True
        Me.txtFecDoc.Location = New System.Drawing.Point(461, 32)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = ""
        Me.txtFecDoc.Size = New System.Drawing.Size(96, 20)
        Me.txtFecDoc.TabIndex = 8
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtSerieDoc
        '
        Me.txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtSerieDoc.Location = New System.Drawing.Point(461, 10)
        Me.txtSerieDoc.MaxLength = 4
        Me.txtSerieDoc.Name = "txtSerieDoc"
        Me.txtSerieDoc.Size = New System.Drawing.Size(96, 20)
        Me.txtSerieDoc.TabIndex = 6
        Me.txtSerieDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(388, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 13)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Serie Doc."
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(109, 32)
        Me.txtNumDoc.MaxLength = 10
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(158, 20)
        Me.txtNumDoc.TabIndex = 7
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Nº Documento"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Tipo Documento"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Location = New System.Drawing.Point(109, 10)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(256, 20)
        Me.cmbTipoDoc.TabIndex = 5
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(345, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Fecha Documento"
        '
        'gbProveedor
        '
        Me.gbProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.gbProveedor.Controls.Add(Me.txtRuc)
        Me.gbProveedor.Controls.Add(Me.btnLimpiarProveedor)
        Me.gbProveedor.Controls.Add(Me.btnAgregarProveedor)
        Me.gbProveedor.Controls.Add(Me.Label9)
        Me.gbProveedor.Controls.Add(Me.txtProveedor)
        Me.gbProveedor.Controls.Add(Me.btnBuscarProveedor)
        Me.gbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProveedor.ForeColor = System.Drawing.Color.Black
        Me.gbProveedor.Location = New System.Drawing.Point(6, 11)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(646, 40)
        Me.gbProveedor.TabIndex = 1
        Me.gbProveedor.Text = "Proveedor"
        Me.gbProveedor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.SystemColors.Window
        Me.txtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtRuc.Location = New System.Drawing.Point(54, 15)
        Me.txtRuc.MaxLength = 11
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(101, 20)
        Me.txtRuc.TabIndex = 1
        Me.txtRuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "RUC :"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(160, 15)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(349, 20)
        Me.txtProveedor.TabIndex = 2
        '
        'gbGastoViaje
        '
        Me.gbGastoViaje.Controls.Add(Me.cbNoAplicaPolitica)
        Me.gbGastoViaje.Controls.Add(Me.txtObservSubRubro)
        Me.gbGastoViaje.Controls.Add(Me.cmbSubRubroViaje)
        Me.gbGastoViaje.Controls.Add(Me.cmbRubroViaje)
        Me.gbGastoViaje.Controls.Add(Me.Label21)
        Me.gbGastoViaje.Controls.Add(Me.Label22)
        Me.gbGastoViaje.Controls.Add(Me.Label17)
        Me.gbGastoViaje.Controls.Add(Me.cmbPlaca)
        Me.gbGastoViaje.Location = New System.Drawing.Point(6, 137)
        Me.gbGastoViaje.Name = "gbGastoViaje"
        Me.gbGastoViaje.Size = New System.Drawing.Size(646, 59)
        Me.gbGastoViaje.TabIndex = 11
        Me.gbGastoViaje.Text = "Gasto de Viaje"
        Me.gbGastoViaje.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbNoAplicaPolitica
        '
        Me.cbNoAplicaPolitica.AutoSize = True
        Me.cbNoAplicaPolitica.BackColor = System.Drawing.Color.White
        Me.cbNoAplicaPolitica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbNoAplicaPolitica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbNoAplicaPolitica.Location = New System.Drawing.Point(9, 14)
        Me.cbNoAplicaPolitica.Name = "cbNoAplicaPolitica"
        Me.cbNoAplicaPolitica.Size = New System.Drawing.Size(159, 17)
        Me.cbNoAplicaPolitica.TabIndex = 12
        Me.cbNoAplicaPolitica.Text = "NO APLICA POLÍTICAS"
        Me.cbNoAplicaPolitica.UseVisualStyleBackColor = False
        '
        'txtObservSubRubro
        '
        Me.txtObservSubRubro.Location = New System.Drawing.Point(374, 33)
        Me.txtObservSubRubro.Name = "txtObservSubRubro"
        Me.txtObservSubRubro.ReadOnly = True
        Me.txtObservSubRubro.Size = New System.Drawing.Size(266, 20)
        Me.txtObservSubRubro.TabIndex = 16
        Me.txtObservSubRubro.TabStop = False
        '
        'cmbSubRubroViaje
        '
        Me.cmbSubRubroViaje.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSubRubroViaje_DesignTimeLayout.LayoutString = resources.GetString("cmbSubRubroViaje_DesignTimeLayout.LayoutString")
        Me.cmbSubRubroViaje.DesignTimeLayout = cmbSubRubroViaje_DesignTimeLayout
        Me.cmbSubRubroViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubRubroViaje.Location = New System.Drawing.Point(90, 33)
        Me.cmbSubRubroViaje.Name = "cmbSubRubroViaje"
        Me.cmbSubRubroViaje.SelectedIndex = -1
        Me.cmbSubRubroViaje.SelectedItem = Nothing
        Me.cmbSubRubroViaje.Size = New System.Drawing.Size(278, 20)
        Me.cmbSubRubroViaje.TabIndex = 15
        Me.cmbSubRubroViaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbRubroViaje
        '
        Me.cmbRubroViaje.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRubroViaje_DesignTimeLayout.LayoutString = resources.GetString("cmbRubroViaje_DesignTimeLayout.LayoutString")
        Me.cmbRubroViaje.DesignTimeLayout = cmbRubroViaje_DesignTimeLayout
        Me.cmbRubroViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRubroViaje.Location = New System.Drawing.Point(288, 11)
        Me.cmbRubroViaje.Name = "cmbRubroViaje"
        Me.cmbRubroViaje.SelectedIndex = -1
        Me.cmbRubroViaje.SelectedItem = Nothing
        Me.cmbRubroViaje.Size = New System.Drawing.Size(165, 20)
        Me.cmbRubroViaje.TabIndex = 13
        Me.cmbRubroViaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(7, 37)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 13)
        Me.Label21.TabIndex = 246
        Me.Label21.Text = "Sub Rubro"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(212, 15)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 13)
        Me.Label22.TabIndex = 245
        Me.Label22.Text = "Rubro Viaje"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(485, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 13)
        Me.Label17.TabIndex = 242
        Me.Label17.Text = "Placa"
        '
        'cmbPlaca
        '
        Me.cmbPlaca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPlaca_DesignTimeLayout.LayoutString = resources.GetString("cmbPlaca_DesignTimeLayout.LayoutString")
        Me.cmbPlaca.DesignTimeLayout = cmbPlaca_DesignTimeLayout
        Me.cmbPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlaca.Location = New System.Drawing.Point(527, 11)
        Me.cmbPlaca.Name = "cmbPlaca"
        Me.cmbPlaca.SelectedIndex = -1
        Me.cmbPlaca.SelectedItem = Nothing
        Me.cmbPlaca.Size = New System.Drawing.Size(113, 20)
        Me.cmbPlaca.TabIndex = 14
        Me.cmbPlaca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'bgMontos
        '
        Me.bgMontos.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.bgMontos.Controls.Add(Me.txtCantidad)
        Me.bgMontos.Controls.Add(Me.Label7)
        Me.bgMontos.Controls.Add(Me.txtMontoIgv)
        Me.bgMontos.Controls.Add(Me.Label27)
        Me.bgMontos.Controls.Add(Me.txtMontoTotal)
        Me.bgMontos.Controls.Add(Me.Label19)
        Me.bgMontos.Controls.Add(Me.txtMontoNoAfecto)
        Me.bgMontos.Controls.Add(Me.Label18)
        Me.bgMontos.Controls.Add(Me.cbAfectoIgv)
        Me.bgMontos.Controls.Add(Me.Label10)
        Me.bgMontos.Controls.Add(Me.txtIgv)
        Me.bgMontos.Controls.Add(Me.Label8)
        Me.bgMontos.Controls.Add(Me.txtSubTotal)
        Me.bgMontos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bgMontos.ForeColor = System.Drawing.Color.Black
        Me.bgMontos.Location = New System.Drawing.Point(6, 261)
        Me.bgMontos.Name = "bgMontos"
        Me.bgMontos.Size = New System.Drawing.Size(646, 102)
        Me.bgMontos.TabIndex = 18
        Me.bgMontos.Text = "Montos"
        Me.bgMontos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(343, 10)
        Me.txtCantidad.Maximum = 300
        Me.txtCantidad.MaxLength = 200
        Me.txtCantidad.Minimum = 1
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(50, 20)
        Me.txtCantidad.TabIndex = 21
        Me.txtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCantidad.Value = 1
        Me.txtCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(300, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Cant."
        '
        'txtMontoIgv
        '
        Me.txtMontoIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoIgv.Location = New System.Drawing.Point(537, 33)
        Me.txtMontoIgv.MaxLength = 10
        Me.txtMontoIgv.Name = "txtMontoIgv"
        Me.txtMontoIgv.ReadOnly = True
        Me.txtMontoIgv.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoIgv.TabIndex = 23
        Me.txtMontoIgv.TabStop = False
        Me.txtMontoIgv.Text = "0.00"
        Me.txtMontoIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(435, 37)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 13)
        Me.Label27.TabIndex = 57
        Me.Label27.Text = "Monto IGV"
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotal.Location = New System.Drawing.Point(537, 77)
        Me.txtMontoTotal.MaxLength = 10
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoTotal.TabIndex = 25
        Me.txtMontoTotal.TabStop = False
        Me.txtMontoTotal.Text = "0.00"
        Me.txtMontoTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(435, 81)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(75, 13)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Monto Total"
        '
        'txtMontoNoAfecto
        '
        Me.txtMontoNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoNoAfecto.Location = New System.Drawing.Point(537, 55)
        Me.txtMontoNoAfecto.MaxLength = 10
        Me.txtMontoNoAfecto.Name = "txtMontoNoAfecto"
        Me.txtMontoNoAfecto.Size = New System.Drawing.Size(100, 20)
        Me.txtMontoNoAfecto.TabIndex = 24
        Me.txtMontoNoAfecto.Text = "0.00"
        Me.txtMontoNoAfecto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoNoAfecto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(435, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 13)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "Mont. No Afecto"
        '
        'cbAfectoIgv
        '
        Me.cbAfectoIgv.AutoSize = True
        Me.cbAfectoIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbAfectoIgv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAfectoIgv.Checked = True
        Me.cbAfectoIgv.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAfectoIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbAfectoIgv.ForeColor = System.Drawing.Color.Black
        Me.cbAfectoIgv.Location = New System.Drawing.Point(158, 13)
        Me.cbAfectoIgv.Name = "cbAfectoIgv"
        Me.cbAfectoIgv.Size = New System.Drawing.Size(96, 17)
        Me.cbAfectoIgv.TabIndex = 20
        Me.cbAfectoIgv.Text = "Afecto a Igv"
        Me.cbAfectoIgv.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "I.G.V."
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtIgv.Location = New System.Drawing.Point(56, 11)
        Me.txtIgv.MaxLength = 12
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(64, 20)
        Me.txtIgv.TabIndex = 19
        Me.txtIgv.TabStop = False
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(435, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Sub Total"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.Location = New System.Drawing.Point(537, 11)
        Me.txtSubTotal.MaxLength = 10
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtSubTotal.TabIndex = 22
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSubTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmComSolicitudGastoDet_Viaje
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(671, 609)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbCentroCosto)
        Me.Controls.Add(Me.gbJobs)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudGastoDet_Viaje"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Solicitud de Gastos Viaje"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesCentrosCosto.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmOpcionesJobs.ResumeLayout(False)
        CType(Me.gbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCentroCosto.ResumeLayout(False)
        CType(Me.dgvCentrosCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbJobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbJobs.ResumeLayout(False)
        CType(Me.dgvJos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFacturacion.ResumeLayout(False)
        Me.gbFacturacion.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGastoViaje.ResumeLayout(False)
        Me.gbGastoViaje.PerformLayout()
        CType(Me.cmbSubRubroViaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbRubroViaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgMontos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bgMontos.ResumeLayout(False)
        Me.bgMontos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Tooltip As System.Windows.Forms.ToolTip
    Friend WithEvents cmOpcionesCentrosCosto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miAsignarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarCentroCosto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpcionesJobs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miAsignarJobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miProcesarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarCompras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarJobs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbCentroCosto As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvCentrosCosto As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbJobs As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvJos As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbFacturacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents biLimpiarPdf As Janus.Windows.EditControls.UIButton
    Friend WithEvents biLimpiarXml As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarPdf As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPdfFE As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarXml As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtXmlFE As System.Windows.Forms.TextBox
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtSerieDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbProveedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnLimpiarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAgregarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtItem As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents gbGastoViaje As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbNoAplicaPolitica As System.Windows.Forms.CheckBox
    Friend WithEvents txtObservSubRubro As System.Windows.Forms.TextBox
    Friend WithEvents cmbSubRubroViaje As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbRubroViaje As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbPlaca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents bgMontos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtMontoIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtMontoNoAfecto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbAfectoIgv As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
End Class
