<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudGastoNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudGastoNew))
        Dim cmbProvisional_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbDestinoViaje_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvCorreos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGastosReales = New System.Windows.Forms.ToolStripMenuItem()
        Me.miProcesarViatico = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarDetPlanilla = New System.Windows.Forms.ToolStripMenuItem()
        Me.miProcesarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActCuentaContable = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActivarMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarCompras = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDescargarXml = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDescargarPdf = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFormatoExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.miImportarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNuevoDetViaje = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbTipo = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbViajeNacional = New System.Windows.Forms.RadioButton()
        Me.rbViajeExterior = New System.Windows.Forms.RadioButton()
        Me.txtTipoProv = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbProvisional = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbGastoViaje = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbDestinoViaje = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.txtFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbGastoViaje = New System.Windows.Forms.CheckBox()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPersonaAutoriza = New System.Windows.Forms.TextBox()
        Me.txtPersonaSolicita = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarPersonaS = New System.Windows.Forms.Button()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObsGasto = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtNumGasto = New System.Windows.Forms.TextBox()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotNeto = New System.Windows.Forms.TextBox()
        Me.txtTotSubtotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotIgv = New System.Windows.Forms.TextBox()
        Me.txtTotOtroCargo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotOtroCargo = New System.Windows.Forms.TextBox()
        Me.txtTotNoAfecto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotNoAfecto = New System.Windows.Forms.TextBox()
        Me.lblSubTotal = New System.Windows.Forms.TextBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditarr = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacerr = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAprobar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizarJob = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvCorreos = New Janus.Windows.GridEX.GridEX()
        Me.gbCorreos = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.lblUnidadNegocio = New System.Windows.Forms.Label()
        Me.dgvFormatoExcel = New System.Windows.Forms.DataGridView()
        Me.dgvImportarExcel = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipo.SuspendLayout()
        CType(Me.cmbProvisional, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGastoViaje.SuspendLayout()
        CType(Me.cmbDestinoViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgvCorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCorreos.SuspendLayout()
        CType(Me.dgvFormatoExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvImportarExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miGastosReales, Me.miProcesarViatico, Me.miMostrarDetPlanilla, Me.miProcesarJob, Me.miActCuentaContable, Me.miActivarMasivo, Me.miMostrarCompras, Me.miMostrar, Me.miEliminar, Me.miDescargarXml, Me.miDescargarPdf, Me.miFormatoExcel, Me.miImportarExcel, Me.ToolStripSeparator10, Me.miNuevoDetViaje, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(196, 374)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(195, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miGastosReales
        '
        Me.miGastosReales.Image = CType(resources.GetObject("miGastosReales.Image"), System.Drawing.Image)
        Me.miGastosReales.Name = "miGastosReales"
        Me.miGastosReales.Size = New System.Drawing.Size(195, 22)
        Me.miGastosReales.Text = "Gastos Reales"
        '
        'miProcesarViatico
        '
        Me.miProcesarViatico.Image = CType(resources.GetObject("miProcesarViatico.Image"), System.Drawing.Image)
        Me.miProcesarViatico.Name = "miProcesarViatico"
        Me.miProcesarViatico.Size = New System.Drawing.Size(195, 22)
        Me.miProcesarViatico.Text = "Procesar Viatico"
        '
        'miMostrarDetPlanilla
        '
        Me.miMostrarDetPlanilla.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miMostrarDetPlanilla.Name = "miMostrarDetPlanilla"
        Me.miMostrarDetPlanilla.Size = New System.Drawing.Size(195, 22)
        Me.miMostrarDetPlanilla.Text = "Mostrar Detalle Planilla"
        '
        'miProcesarJob
        '
        Me.miProcesarJob.Image = CType(resources.GetObject("miProcesarJob.Image"), System.Drawing.Image)
        Me.miProcesarJob.Name = "miProcesarJob"
        Me.miProcesarJob.Size = New System.Drawing.Size(195, 22)
        Me.miProcesarJob.Text = "Procesar Job"
        Me.miProcesarJob.Visible = False
        '
        'miActCuentaContable
        '
        Me.miActCuentaContable.Image = CType(resources.GetObject("miActCuentaContable.Image"), System.Drawing.Image)
        Me.miActCuentaContable.Name = "miActCuentaContable"
        Me.miActCuentaContable.Size = New System.Drawing.Size(195, 22)
        Me.miActCuentaContable.Text = "Act. Nro de Cuenta"
        Me.miActCuentaContable.Visible = False
        '
        'miActivarMasivo
        '
        Me.miActivarMasivo.Image = CType(resources.GetObject("miActivarMasivo.Image"), System.Drawing.Image)
        Me.miActivarMasivo.Name = "miActivarMasivo"
        Me.miActivarMasivo.Size = New System.Drawing.Size(195, 22)
        Me.miActivarMasivo.Text = "Act. Cuenta Masivo"
        '
        'miMostrarCompras
        '
        Me.miMostrarCompras.Image = CType(resources.GetObject("miMostrarCompras.Image"), System.Drawing.Image)
        Me.miMostrarCompras.Name = "miMostrarCompras"
        Me.miMostrarCompras.Size = New System.Drawing.Size(195, 22)
        Me.miMostrarCompras.Text = "Mostrar Compras"
        Me.miMostrarCompras.Visible = False
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(195, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(195, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miDescargarXml
        '
        Me.miDescargarXml.Image = CType(resources.GetObject("miDescargarXml.Image"), System.Drawing.Image)
        Me.miDescargarXml.Name = "miDescargarXml"
        Me.miDescargarXml.Size = New System.Drawing.Size(195, 22)
        Me.miDescargarXml.Text = "Descargar Xml"
        Me.miDescargarXml.ToolTipText = "Descargar Xml"
        '
        'miDescargarPdf
        '
        Me.miDescargarPdf.Image = CType(resources.GetObject("miDescargarPdf.Image"), System.Drawing.Image)
        Me.miDescargarPdf.Name = "miDescargarPdf"
        Me.miDescargarPdf.Size = New System.Drawing.Size(195, 22)
        Me.miDescargarPdf.Text = "Descargar Pdf"
        Me.miDescargarPdf.ToolTipText = "Descargar Pdf"
        '
        'miFormatoExcel
        '
        Me.miFormatoExcel.Image = CType(resources.GetObject("miFormatoExcel.Image"), System.Drawing.Image)
        Me.miFormatoExcel.Name = "miFormatoExcel"
        Me.miFormatoExcel.Size = New System.Drawing.Size(195, 22)
        Me.miFormatoExcel.Text = "Formato Excel"
        '
        'miImportarExcel
        '
        Me.miImportarExcel.Image = CType(resources.GetObject("miImportarExcel.Image"), System.Drawing.Image)
        Me.miImportarExcel.Name = "miImportarExcel"
        Me.miImportarExcel.Size = New System.Drawing.Size(195, 22)
        Me.miImportarExcel.Text = "Importar Excel"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(192, 6)
        '
        'miNuevoDetViaje
        '
        Me.miNuevoDetViaje.Image = CType(resources.GetObject("miNuevoDetViaje.Image"), System.Drawing.Image)
        Me.miNuevoDetViaje.Name = "miNuevoDetViaje"
        Me.miNuevoDetViaje.Size = New System.Drawing.Size(195, 22)
        Me.miNuevoDetViaje.Text = "Nuevo Detalle Viaje"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(192, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(192, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(195, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Location = New System.Drawing.Point(0, 779)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(1080, 20)
        Me.ssBarra.TabIndex = 183
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
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
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
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.gbTipo)
        Me.UiGroupBox2.Controls.Add(Me.txtTipoProv)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.cmbProvisional)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.gbGastoViaje)
        Me.UiGroupBox2.Controls.Add(Me.cbGastoViaje)
        Me.UiGroupBox2.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.txtPersonaAutoriza)
        Me.UiGroupBox2.Controls.Add(Me.txtPersonaSolicita)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarPersonaS)
        Me.UiGroupBox2.Controls.Add(Me.cmbArea)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.txtObsGasto)
        Me.UiGroupBox2.Controls.Add(Me.lblFecha)
        Me.UiGroupBox2.Controls.Add(Me.txtFecha)
        Me.UiGroupBox2.Controls.Add(Me.txtNumGasto)
        Me.UiGroupBox2.Controls.Add(Me.gbEstado)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.Label21)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 31)
        Me.UiGroupBox2.MinimumSize = New System.Drawing.Size(797, 124)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(1046, 192)
        Me.UiGroupBox2.TabIndex = 184
        Me.UiGroupBox2.Text = "Cabecera"
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'gbTipo
        '
        Me.gbTipo.Controls.Add(Me.rbViajeNacional)
        Me.gbTipo.Controls.Add(Me.rbViajeExterior)
        Me.gbTipo.Location = New System.Drawing.Point(8, 148)
        Me.gbTipo.Name = "gbTipo"
        Me.gbTipo.Size = New System.Drawing.Size(176, 38)
        Me.gbTipo.TabIndex = 254
        Me.gbTipo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'rbViajeNacional
        '
        Me.rbViajeNacional.AutoSize = True
        Me.rbViajeNacional.Location = New System.Drawing.Point(15, 14)
        Me.rbViajeNacional.Name = "rbViajeNacional"
        Me.rbViajeNacional.Size = New System.Drawing.Size(75, 17)
        Me.rbViajeNacional.TabIndex = 1
        Me.rbViajeNacional.Text = "Nacional"
        Me.rbViajeNacional.UseVisualStyleBackColor = True
        '
        'rbViajeExterior
        '
        Me.rbViajeExterior.AutoSize = True
        Me.rbViajeExterior.Location = New System.Drawing.Point(100, 14)
        Me.rbViajeExterior.Name = "rbViajeExterior"
        Me.rbViajeExterior.Size = New System.Drawing.Size(68, 17)
        Me.rbViajeExterior.TabIndex = 2
        Me.rbViajeExterior.Text = "Exterior"
        Me.rbViajeExterior.UseVisualStyleBackColor = True
        '
        'txtTipoProv
        '
        Me.txtTipoProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoProv.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTipoProv.Location = New System.Drawing.Point(837, 76)
        Me.txtTipoProv.MaxLength = 3
        Me.txtTipoProv.Name = "txtTipoProv"
        Me.txtTipoProv.ReadOnly = True
        Me.txtTipoProv.Size = New System.Drawing.Size(121, 20)
        Me.txtTipoProv.TabIndex = 253
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(770, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "Tipo Prov."
        '
        'cmbProvisional
        '
        Me.cmbProvisional.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbProvisional_DesignTimeLayout.LayoutString = resources.GetString("cmbProvisional_DesignTimeLayout.LayoutString")
        Me.cmbProvisional.DesignTimeLayout = cmbProvisional_DesignTimeLayout
        Me.cmbProvisional.Location = New System.Drawing.Point(678, 76)
        Me.cmbProvisional.Name = "cmbProvisional"
        Me.cmbProvisional.SelectedIndex = -1
        Me.cmbProvisional.SelectedItem = Nothing
        Me.cmbProvisional.Size = New System.Drawing.Size(84, 20)
        Me.cmbProvisional.TabIndex = 198
        Me.cmbProvisional.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbProvisional.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(606, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 199
        Me.Label5.Text = "Provisional"
        '
        'gbGastoViaje
        '
        Me.gbGastoViaje.Controls.Add(Me.cmbDestinoViaje)
        Me.gbGastoViaje.Controls.Add(Me.Label23)
        Me.gbGastoViaje.Controls.Add(Me.txtFecFinal)
        Me.gbGastoViaje.Controls.Add(Me.Label7)
        Me.gbGastoViaje.Controls.Add(Me.btnBuscarJob)
        Me.gbGastoViaje.Controls.Add(Me.Label8)
        Me.gbGastoViaje.Controls.Add(Me.txtNumJob)
        Me.gbGastoViaje.Controls.Add(Me.txtFecInicio)
        Me.gbGastoViaje.Controls.Add(Me.Label6)
        Me.gbGastoViaje.Location = New System.Drawing.Point(186, 148)
        Me.gbGastoViaje.Name = "gbGastoViaje"
        Me.gbGastoViaje.Size = New System.Drawing.Size(839, 38)
        Me.gbGastoViaje.TabIndex = 197
        Me.gbGastoViaje.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cmbDestinoViaje
        '
        Me.cmbDestinoViaje.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbDestinoViaje_DesignTimeLayout.LayoutString = resources.GetString("cmbDestinoViaje_DesignTimeLayout.LayoutString")
        Me.cmbDestinoViaje.DesignTimeLayout = cmbDestinoViaje_DesignTimeLayout
        Me.cmbDestinoViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDestinoViaje.Location = New System.Drawing.Point(89, 12)
        Me.cmbDestinoViaje.Name = "cmbDestinoViaje"
        Me.cmbDestinoViaje.SelectedIndex = -1
        Me.cmbDestinoViaje.SelectedItem = Nothing
        Me.cmbDestinoViaje.Size = New System.Drawing.Size(181, 20)
        Me.cmbDestinoViaje.TabIndex = 248
        Me.cmbDestinoViaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(5, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(82, 13)
        Me.Label23.TabIndex = 249
        Me.Label23.Text = "Destino Viaje"
        '
        'txtFecFinal
        '
        '
        '
        '
        Me.txtFecFinal.DropDownCalendar.Name = ""
        Me.txtFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinal.IsNullDate = True
        Me.txtFecFinal.Location = New System.Drawing.Point(550, 12)
        Me.txtFecFinal.Name = "txtFecFinal"
        Me.txtFecFinal.NullButtonText = "Ninguno"
        Me.txtFecFinal.ShowNullButton = True
        Me.txtFecFinal.Size = New System.Drawing.Size(96, 20)
        Me.txtFecFinal.TabIndex = 195
        Me.txtFecFinal.TodayButtonText = "Hoy"
        Me.txtFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(276, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 194
        Me.Label7.Text = "Fecha Inicio"
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(785, 11)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 8
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(475, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 196
        Me.Label8.Text = "Fecha Final"
        '
        'txtNumJob
        '
        Me.txtNumJob.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumJob.Location = New System.Drawing.Point(728, 12)
        Me.txtNumJob.MaxLength = 20
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(56, 20)
        Me.txtNumJob.TabIndex = 7
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFecInicio
        '
        '
        '
        '
        Me.txtFecInicio.DropDownCalendar.Name = ""
        Me.txtFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicio.IsNullDate = True
        Me.txtFecInicio.Location = New System.Drawing.Point(355, 12)
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.NullButtonText = "Ninguno"
        Me.txtFecInicio.ShowNullButton = True
        Me.txtFecInicio.Size = New System.Drawing.Size(96, 20)
        Me.txtFecInicio.TabIndex = 193
        Me.txtFecInicio.TodayButtonText = "Hoy"
        Me.txtFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(681, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 191
        Me.Label6.Text = "Nº OT"
        '
        'cbGastoViaje
        '
        Me.cbGastoViaje.AutoSize = True
        Me.cbGastoViaje.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbGastoViaje.Location = New System.Drawing.Point(450, 79)
        Me.cbGastoViaje.Name = "cbGastoViaje"
        Me.cbGastoViaje.Size = New System.Drawing.Size(131, 17)
        Me.cbGastoViaje.TabIndex = 6
        Me.cbGastoViaje.Text = "Tiene Provisional?"
        Me.cbGastoViaje.UseVisualStyleBackColor = True
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(533, 20)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(69, 20)
        Me.cmbMoneda.TabIndex = 4
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(475, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Moneda"
        '
        'txtPersonaAutoriza
        '
        Me.txtPersonaAutoriza.BackColor = System.Drawing.SystemColors.Control
        Me.txtPersonaAutoriza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonaAutoriza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonaAutoriza.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPersonaAutoriza.Location = New System.Drawing.Point(591, 47)
        Me.txtPersonaAutoriza.MaxLength = 20
        Me.txtPersonaAutoriza.Name = "txtPersonaAutoriza"
        Me.txtPersonaAutoriza.ReadOnly = True
        Me.txtPersonaAutoriza.Size = New System.Drawing.Size(434, 20)
        Me.txtPersonaAutoriza.TabIndex = 7
        '
        'txtPersonaSolicita
        '
        Me.txtPersonaSolicita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonaSolicita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonaSolicita.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersonaSolicita.Location = New System.Drawing.Point(107, 47)
        Me.txtPersonaSolicita.MaxLength = 3
        Me.txtPersonaSolicita.Name = "txtPersonaSolicita"
        Me.txtPersonaSolicita.ReadOnly = True
        Me.txtPersonaSolicita.Size = New System.Drawing.Size(347, 20)
        Me.txtPersonaSolicita.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Área"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Solicitado Por"
        '
        'btnBuscarPersonaS
        '
        Me.btnBuscarPersonaS.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersonaS.Location = New System.Drawing.Point(455, 46)
        Me.btnBuscarPersonaS.Name = "btnBuscarPersonaS"
        Me.btnBuscarPersonaS.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersonaS.TabIndex = 6
        Me.btnBuscarPersonaS.TabStop = False
        Me.btnBuscarPersonaS.UseVisualStyleBackColor = True
        '
        'cmbArea
        '
        Me.cmbArea.BackColor = System.Drawing.SystemColors.Control
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(107, 76)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.ReadOnly = True
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(269, 20)
        Me.cmbArea.TabIndex = 3
        Me.cmbArea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(491, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Autorizado Por"
        '
        'txtObsGasto
        '
        Me.txtObsGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObsGasto.Location = New System.Drawing.Point(107, 104)
        Me.txtObsGasto.Multiline = True
        Me.txtObsGasto.Name = "txtObsGasto"
        Me.txtObsGasto.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObsGasto.Size = New System.Drawing.Size(918, 42)
        Me.txtObsGasto.TabIndex = 8
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(270, 24)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "Fecha"
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
        Me.txtFecha.Location = New System.Drawing.Point(318, 20)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(102, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.Value = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtNumGasto
        '
        Me.txtNumGasto.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumGasto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumGasto.Location = New System.Drawing.Point(107, 20)
        Me.txtNumGasto.MaxLength = 20
        Me.txtNumGasto.Name = "txtNumGasto"
        Me.txtNumGasto.ReadOnly = True
        Me.txtNumGasto.Size = New System.Drawing.Size(115, 20)
        Me.txtNumGasto.TabIndex = 1
        Me.txtNumGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.Color.Transparent
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(723, 3)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(252, 40)
        Me.gbEstado.TabIndex = 0
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(6, 13)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(240, 21)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº de Gasto"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(15, 117)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Observación"
        '
        'gbDetalle
        '
        Me.gbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalle.Controls.Add(Me.UiGroupBox6)
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(5, 229)
        Me.gbDetalle.MinimumSize = New System.Drawing.Size(978, 345)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(1047, 367)
        Me.gbDetalle.TabIndex = 185
        Me.gbDetalle.Text = "Detalles"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtTotNeto)
        Me.UiGroupBox6.Controls.Add(Me.lblTotNeto)
        Me.UiGroupBox6.Controls.Add(Me.txtTotSubtotal)
        Me.UiGroupBox6.Controls.Add(Me.txtTotIgv)
        Me.UiGroupBox6.Controls.Add(Me.lblTotIgv)
        Me.UiGroupBox6.Controls.Add(Me.txtTotOtroCargo)
        Me.UiGroupBox6.Controls.Add(Me.lblTotOtroCargo)
        Me.UiGroupBox6.Controls.Add(Me.txtTotNoAfecto)
        Me.UiGroupBox6.Controls.Add(Me.lblTotNoAfecto)
        Me.UiGroupBox6.Controls.Add(Me.lblSubTotal)
        Me.UiGroupBox6.Location = New System.Drawing.Point(6, 249)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(1034, 112)
        Me.UiGroupBox6.TabIndex = 23
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotNeto
        '
        Me.txtTotNeto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotNeto.Location = New System.Drawing.Point(731, 87)
        Me.txtTotNeto.MaxLength = 5
        Me.txtTotNeto.Name = "txtTotNeto"
        Me.txtTotNeto.ReadOnly = True
        Me.txtTotNeto.Size = New System.Drawing.Size(297, 20)
        Me.txtTotNeto.TabIndex = 18
        Me.txtTotNeto.TabStop = False
        Me.txtTotNeto.Text = "0.00"
        Me.txtTotNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotNeto
        '
        Me.lblTotNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotNeto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotNeto.Location = New System.Drawing.Point(7, 87)
        Me.lblTotNeto.MaxLength = 20
        Me.lblTotNeto.Name = "lblTotNeto"
        Me.lblTotNeto.ReadOnly = True
        Me.lblTotNeto.Size = New System.Drawing.Size(725, 20)
        Me.lblTotNeto.TabIndex = 17
        Me.lblTotNeto.TabStop = False
        Me.lblTotNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotSubtotal
        '
        Me.txtTotSubtotal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotSubtotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotSubtotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotSubtotal.Location = New System.Drawing.Point(731, 11)
        Me.txtTotSubtotal.MaxLength = 5
        Me.txtTotSubtotal.Name = "txtTotSubtotal"
        Me.txtTotSubtotal.ReadOnly = True
        Me.txtTotSubtotal.Size = New System.Drawing.Size(297, 20)
        Me.txtTotSubtotal.TabIndex = 11
        Me.txtTotSubtotal.TabStop = False
        Me.txtTotSubtotal.Text = "0.00"
        Me.txtTotSubtotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotSubtotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotSubtotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotIgv
        '
        Me.txtTotIgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotIgv.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotIgv.Location = New System.Drawing.Point(731, 30)
        Me.txtTotIgv.MaxLength = 5
        Me.txtTotIgv.Name = "txtTotIgv"
        Me.txtTotIgv.ReadOnly = True
        Me.txtTotIgv.Size = New System.Drawing.Size(297, 20)
        Me.txtTotIgv.TabIndex = 6
        Me.txtTotIgv.TabStop = False
        Me.txtTotIgv.Text = "0.00"
        Me.txtTotIgv.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotIgv
        '
        Me.lblTotIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotIgv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotIgv.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotIgv.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotIgv.Location = New System.Drawing.Point(7, 30)
        Me.lblTotIgv.MaxLength = 20
        Me.lblTotIgv.Name = "lblTotIgv"
        Me.lblTotIgv.ReadOnly = True
        Me.lblTotIgv.Size = New System.Drawing.Size(725, 20)
        Me.lblTotIgv.TabIndex = 10
        Me.lblTotIgv.TabStop = False
        Me.lblTotIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotOtroCargo
        '
        Me.txtTotOtroCargo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotOtroCargo.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotOtroCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotOtroCargo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotOtroCargo.Location = New System.Drawing.Point(731, 68)
        Me.txtTotOtroCargo.MaxLength = 5
        Me.txtTotOtroCargo.Name = "txtTotOtroCargo"
        Me.txtTotOtroCargo.ReadOnly = True
        Me.txtTotOtroCargo.Size = New System.Drawing.Size(297, 20)
        Me.txtTotOtroCargo.TabIndex = 16
        Me.txtTotOtroCargo.TabStop = False
        Me.txtTotOtroCargo.Text = "0.00"
        Me.txtTotOtroCargo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotOtroCargo.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotOtroCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotOtroCargo
        '
        Me.lblTotOtroCargo.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotOtroCargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotOtroCargo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotOtroCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotOtroCargo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotOtroCargo.Location = New System.Drawing.Point(7, 68)
        Me.lblTotOtroCargo.MaxLength = 20
        Me.lblTotOtroCargo.Name = "lblTotOtroCargo"
        Me.lblTotOtroCargo.ReadOnly = True
        Me.lblTotOtroCargo.Size = New System.Drawing.Size(725, 20)
        Me.lblTotOtroCargo.TabIndex = 15
        Me.lblTotOtroCargo.TabStop = False
        Me.lblTotOtroCargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotNoAfecto
        '
        Me.txtTotNoAfecto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotNoAfecto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotNoAfecto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotNoAfecto.Location = New System.Drawing.Point(731, 49)
        Me.txtTotNoAfecto.MaxLength = 5
        Me.txtTotNoAfecto.Name = "txtTotNoAfecto"
        Me.txtTotNoAfecto.ReadOnly = True
        Me.txtTotNoAfecto.Size = New System.Drawing.Size(297, 20)
        Me.txtTotNoAfecto.TabIndex = 14
        Me.txtTotNoAfecto.TabStop = False
        Me.txtTotNoAfecto.Text = "0.00"
        Me.txtTotNoAfecto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotNoAfecto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotNoAfecto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotNoAfecto
        '
        Me.lblTotNoAfecto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotNoAfecto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotNoAfecto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotNoAfecto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotNoAfecto.Location = New System.Drawing.Point(7, 49)
        Me.lblTotNoAfecto.MaxLength = 20
        Me.lblTotNoAfecto.Name = "lblTotNoAfecto"
        Me.lblTotNoAfecto.ReadOnly = True
        Me.lblTotNoAfecto.Size = New System.Drawing.Size(725, 20)
        Me.lblTotNoAfecto.TabIndex = 13
        Me.lblTotNoAfecto.TabStop = False
        Me.lblTotNoAfecto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSubTotal
        '
        Me.lblSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblSubTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblSubTotal.Location = New System.Drawing.Point(7, 11)
        Me.lblSubTotal.MaxLength = 20
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.ReadOnly = True
        Me.lblSubTotal.Size = New System.Drawing.Size(725, 20)
        Me.lblSubTotal.TabIndex = 12
        Me.lblSubTotal.TabStop = False
        Me.lblSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 19)
        Me.dgvDatos.MinimumSize = New System.Drawing.Size(876, 50)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(1036, 224)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biEditarr, Me.ToolStripSeparator4, Me.biDeshacerr, Me.ToolStripSeparator7, Me.biAprobar, Me.ToolStripSeparator8, Me.biActualizarJob, Me.ToolStripSeparator6, Me.biCerrar, Me.ToolStripSeparator5})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1080, 31)
        Me.ToolStrip.TabIndex = 186
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEditarr
        '
        Me.biEditarr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditarr.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditarr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditarr.Name = "biEditarr"
        Me.biEditarr.Size = New System.Drawing.Size(28, 28)
        Me.biEditarr.Text = "Editar Cabecera"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacerr
        '
        Me.biDeshacerr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacerr.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacerr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacerr.Name = "biDeshacerr"
        Me.biDeshacerr.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacerr.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'biAprobar
        '
        Me.biAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.biAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAprobar.Name = "biAprobar"
        Me.biAprobar.Size = New System.Drawing.Size(28, 28)
        Me.biAprobar.Text = "Aprobar"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizarJob
        '
        Me.biActualizarJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizarJob.Image = CType(resources.GetObject("biActualizarJob.Image"), System.Drawing.Image)
        Me.biActualizarJob.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizarJob.Name = "biActualizarJob"
        Me.biActualizarJob.Size = New System.Drawing.Size(28, 28)
        Me.biActualizarJob.Text = "Actualizar Job"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'dgvCorreos
        '
        Me.dgvCorreos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvCorreos_DesignTimeLayout.LayoutString = resources.GetString("dgvCorreos_DesignTimeLayout.LayoutString")
        Me.dgvCorreos.DesignTimeLayout = dgvCorreos_DesignTimeLayout
        Me.dgvCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCorreos.GroupByBoxVisible = False
        Me.dgvCorreos.Location = New System.Drawing.Point(6, 37)
        Me.dgvCorreos.Name = "dgvCorreos"
        Me.dgvCorreos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCorreos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCorreos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCorreos.Size = New System.Drawing.Size(892, 94)
        Me.dgvCorreos.TabIndex = 187
        Me.dgvCorreos.TabStop = False
        Me.dgvCorreos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbCorreos
        '
        Me.gbCorreos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCorreos.Controls.Add(Me.btnEnviar)
        Me.gbCorreos.Controls.Add(Me.dgvCorreos)
        Me.gbCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCorreos.Location = New System.Drawing.Point(5, 599)
        Me.gbCorreos.Name = "gbCorreos"
        Me.gbCorreos.Size = New System.Drawing.Size(1046, 137)
        Me.gbCorreos.TabIndex = 188
        Me.gbCorreos.Text = "Enviar Correos"
        Me.gbCorreos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnEnviar
        '
        Me.btnEnviar.Image = Global.SIGECOM.My.Resources.Resources.Enviar_
        Me.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnviar.Location = New System.Drawing.Point(105, 11)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(67, 23)
        Me.btnEnviar.TabIndex = 188
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'lblUnidadNegocio
        '
        Me.lblUnidadNegocio.AutoSize = True
        Me.lblUnidadNegocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadNegocio.Location = New System.Drawing.Point(339, 7)
        Me.lblUnidadNegocio.Name = "lblUnidadNegocio"
        Me.lblUnidadNegocio.Size = New System.Drawing.Size(134, 15)
        Me.lblUnidadNegocio.TabIndex = 189
        Me.lblUnidadNegocio.Text = "Unidad de Negocio:"
        '
        'dgvFormatoExcel
        '
        Me.dgvFormatoExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFormatoExcel.Location = New System.Drawing.Point(744, 7)
        Me.dgvFormatoExcel.Name = "dgvFormatoExcel"
        Me.dgvFormatoExcel.Size = New System.Drawing.Size(73, 23)
        Me.dgvFormatoExcel.TabIndex = 284
        Me.dgvFormatoExcel.Visible = False
        '
        'dgvImportarExcel
        '
        Me.dgvImportarExcel.AllowUserToAddRows = False
        Me.dgvImportarExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImportarExcel.Location = New System.Drawing.Point(823, 7)
        Me.dgvImportarExcel.Name = "dgvImportarExcel"
        Me.dgvImportarExcel.Size = New System.Drawing.Size(73, 23)
        Me.dgvImportarExcel.TabIndex = 285
        Me.dgvImportarExcel.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmComSolicitudGastoNew
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1080, 799)
        Me.Controls.Add(Me.dgvImportarExcel)
        Me.Controls.Add(Me.gbCorreos)
        Me.Controls.Add(Me.dgvFormatoExcel)
        Me.Controls.Add(Me.lblUnidadNegocio)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(818, 219)
        Me.Name = "frmComSolicitudGastoNew"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud de Gasto"
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipo.ResumeLayout(False)
        Me.gbTipo.PerformLayout()
        CType(Me.cmbProvisional, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGastoViaje.ResumeLayout(False)
        Me.gbGastoViaje.PerformLayout()
        CType(Me.cmbDestinoViaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgvCorreos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCorreos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCorreos.ResumeLayout(False)
        CType(Me.dgvFormatoExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvImportarExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtPersonaSolicita As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPersonaS As System.Windows.Forms.Button
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtObsGasto As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtNumGasto As System.Windows.Forms.TextBox
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtPersonaAutoriza As System.Windows.Forms.TextBox
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActCuentaContable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditarr As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacerr As System.Windows.Forms.ToolStripButton
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miProcesarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biAprobar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbCorreos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvCorreos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblTotIgv As System.Windows.Forms.TextBox
    Friend WithEvents txtTotIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotSubtotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotOtroCargo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotOtroCargo As System.Windows.Forms.TextBox
    Friend WithEvents txtTotNoAfecto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotNoAfecto As System.Windows.Forms.TextBox
    Friend WithEvents miActivarMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miProcesarViatico As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarCompras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbGastoViaje As System.Windows.Forms.CheckBox
    Friend WithEvents miMostrarDetPlanilla As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizarJob As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblUnidadNegocio As System.Windows.Forms.Label
    Friend WithEvents miDescargarXml As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDescargarPdf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miGastosReales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miFormatoExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miImportarExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvFormatoExcel As System.Windows.Forms.DataGridView
    Friend WithEvents dgvImportarExcel As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents gbGastoViaje As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cmbDestinoViaje As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents miNuevoDetViaje As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtTotNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotNeto As TextBox
    Friend WithEvents cmbProvisional As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTipoProv As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents gbTipo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbViajeNacional As RadioButton
    Friend WithEvents rbViajeExterior As RadioButton
End Class
