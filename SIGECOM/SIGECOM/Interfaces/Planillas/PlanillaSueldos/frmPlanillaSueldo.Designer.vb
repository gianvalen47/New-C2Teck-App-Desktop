<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillaSueldo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillaSueldo))
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoPlanilla_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image")
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miInsertarMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miEnviarCorreo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miProcesarLiquidacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.miProcesarVacaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.biProcesarDetalle = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.gbCabecera = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbGenProceso = New System.Windows.Forms.CheckBox()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbTipoPlanilla = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.txtTipCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbNoAplicaDscto = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMesRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtIdPlanilla = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDuracion = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFecPlaFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecPlaIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecTarFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecTarIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFecProFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecProIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFecExtFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecExtIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtAportacionDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtAportacionSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNetoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNetoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtDescuentoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtDescuentoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtIngresosDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtIngresosSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.gbCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCabecera.SuspendLayout()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoPlanilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miInsertarMasivo, Me.miSeparador1, Me.miEnviarCorreo, Me.ToolStripMenuItem1, Me.miProcesarLiquidacion, Me.miProcesarVacaciones, Me.ToolStripSeparator2, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(185, 198)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(184, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(184, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(184, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miInsertarMasivo
        '
        Me.miInsertarMasivo.Image = CType(resources.GetObject("miInsertarMasivo.Image"), System.Drawing.Image)
        Me.miInsertarMasivo.Name = "miInsertarMasivo"
        Me.miInsertarMasivo.Size = New System.Drawing.Size(184, 22)
        Me.miInsertarMasivo.Text = "Insertar Masivo"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(181, 6)
        '
        'miEnviarCorreo
        '
        Me.miEnviarCorreo.Image = Global.SIGECOM.My.Resources.Resources.Enviar_Pr
        Me.miEnviarCorreo.Name = "miEnviarCorreo"
        Me.miEnviarCorreo.Size = New System.Drawing.Size(184, 22)
        Me.miEnviarCorreo.Text = "Enviar Correo"
        Me.miEnviarCorreo.ToolTipText = "Enviar por correo la boleta de pago al personal"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 6)
        '
        'miProcesarLiquidacion
        '
        Me.miProcesarLiquidacion.Image = Global.SIGECOM.My.Resources.Resources.ManoHaciaAbajo
        Me.miProcesarLiquidacion.Name = "miProcesarLiquidacion"
        Me.miProcesarLiquidacion.Size = New System.Drawing.Size(184, 22)
        Me.miProcesarLiquidacion.Text = "Procesar Liquidación"
        Me.miProcesarLiquidacion.ToolTipText = "Procesar Liquidación de beneficios sociales"
        '
        'miProcesarVacaciones
        '
        Me.miProcesarVacaciones.Image = CType(resources.GetObject("miProcesarVacaciones.Image"), System.Drawing.Image)
        Me.miProcesarVacaciones.Name = "miProcesarVacaciones"
        Me.miProcesarVacaciones.Size = New System.Drawing.Size(184, 22)
        Me.miProcesarVacaciones.Text = "Procesar Vacaciones"
        Me.miProcesarVacaciones.ToolTipText = "Procesar vacaciones"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(181, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(184, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 707)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(798, 18)
        Me.ssBarra.TabIndex = 188
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(485, 13)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 13)
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator11, Me.biGrabar, Me.ToolStripSeparator1, Me.biEditar, Me.ToolStripSeparator13, Me.biDeshacer, Me.ToolStripSeparator14, Me.biProcesarDetalle, Me.ToolStripSeparator15, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(798, 31)
        Me.ToolStrip.TabIndex = 187
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
        'biProcesarDetalle
        '
        Me.biProcesarDetalle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biProcesarDetalle.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.biProcesarDetalle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biProcesarDetalle.Name = "biProcesarDetalle"
        Me.biProcesarDetalle.Size = New System.Drawing.Size(28, 28)
        Me.biProcesarDetalle.Text = "ToolStripButton1"
        Me.biProcesarDetalle.ToolTipText = "Procesar detalles"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
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
        'gbCabecera
        '
        Me.gbCabecera.Controls.Add(Me.cbGenProceso)
        Me.gbCabecera.Controls.Add(Me.gbEstado)
        Me.gbCabecera.Controls.Add(Me.cmbMoneda)
        Me.gbCabecera.Controls.Add(Me.Label16)
        Me.gbCabecera.Controls.Add(Me.cmbTipoPlanilla)
        Me.gbCabecera.Controls.Add(Me.Label14)
        Me.gbCabecera.Controls.Add(Me.txtObservacion)
        Me.gbCabecera.Controls.Add(Me.txtTipCambio)
        Me.gbCabecera.Controls.Add(Me.Label15)
        Me.gbCabecera.Controls.Add(Me.txtPeriodo)
        Me.gbCabecera.Controls.Add(Me.Label13)
        Me.gbCabecera.Controls.Add(Me.cbNoAplicaDscto)
        Me.gbCabecera.Controls.Add(Me.Label12)
        Me.gbCabecera.Controls.Add(Me.Label11)
        Me.gbCabecera.Controls.Add(Me.txtMesRegistro)
        Me.gbCabecera.Controls.Add(Me.txtIdPlanilla)
        Me.gbCabecera.Controls.Add(Me.Label10)
        Me.gbCabecera.Controls.Add(Me.txtDuracion)
        Me.gbCabecera.Controls.Add(Me.Label9)
        Me.gbCabecera.Controls.Add(Me.UiGroupBox4)
        Me.gbCabecera.Controls.Add(Me.UiGroupBox3)
        Me.gbCabecera.Controls.Add(Me.UiGroupBox2)
        Me.gbCabecera.Controls.Add(Me.UiGroupBox1)
        Me.gbCabecera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCabecera.Location = New System.Drawing.Point(5, 30)
        Me.gbCabecera.Name = "gbCabecera"
        Me.gbCabecera.Size = New System.Drawing.Size(743, 181)
        Me.gbCabecera.TabIndex = 0
        Me.gbCabecera.Text = "Cabecera"
        Me.gbCabecera.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbCabecera.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cbGenProceso
        '
        Me.cbGenProceso.AutoSize = True
        Me.cbGenProceso.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbGenProceso.Location = New System.Drawing.Point(477, 23)
        Me.cbGenProceso.Name = "cbGenProceso"
        Me.cbGenProceso.Size = New System.Drawing.Size(128, 17)
        Me.cbGenProceso.TabIndex = 234
        Me.cbGenProceso.Text = "Generar Proceso?"
        Me.cbGenProceso.UseVisualStyleBackColor = True
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.Color.Transparent
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(617, 7)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(123, 40)
        Me.gbEstado.TabIndex = 233
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(6, 13)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(110, 21)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(80, 54)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(60, 20)
        Me.cmbMoneda.TabIndex = 4
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 145)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 232
        Me.Label16.Text = "Observación"
        '
        'cmbTipoPlanilla
        '
        Me.cmbTipoPlanilla.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoPlanilla_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoPlanilla_DesignTimeLayout.LayoutString")
        Me.cmbTipoPlanilla.DesignTimeLayout = cmbTipoPlanilla_DesignTimeLayout
        Me.cmbTipoPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPlanilla.Location = New System.Drawing.Point(398, 54)
        Me.cmbTipoPlanilla.Name = "cmbTipoPlanilla"
        Me.cmbTipoPlanilla.SelectedIndex = -1
        Me.cmbTipoPlanilla.SelectedItem = Nothing
        Me.cmbTipoPlanilla.Size = New System.Drawing.Size(175, 20)
        Me.cmbTipoPlanilla.TabIndex = 6
        Me.cmbTipoPlanilla.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(315, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 230
        Me.Label14.Text = "Tipo Planilla"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(92, 135)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(638, 37)
        Me.txtObservacion.TabIndex = 23
        '
        'txtTipCambio
        '
        Me.txtTipCambio.DecimalDigits = 4
        Me.txtTipCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCambio.Location = New System.Drawing.Point(239, 54)
        Me.txtTipCambio.MaxLength = 10
        Me.txtTipCambio.Name = "txtTipCambio"
        Me.txtTipCambio.Size = New System.Drawing.Size(51, 20)
        Me.txtTipCambio.TabIndex = 5
        Me.txtTipCambio.Text = "0.0000"
        Me.txtTipCambio.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtTipCambio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(170, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 13)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "T. Cambio"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(201, 20)
        Me.txtPeriodo.Maximum = 2059
        Me.txtPeriodo.Minimum = 2006
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
        Me.txtPeriodo.TabIndex = 1
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.Value = 2006
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(145, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 226
        Me.Label13.Text = "Periodo"
        '
        'cbNoAplicaDscto
        '
        Me.cbNoAplicaDscto.AutoSize = True
        Me.cbNoAplicaDscto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbNoAplicaDscto.Location = New System.Drawing.Point(603, 56)
        Me.cbNoAplicaDscto.Name = "cbNoAplicaDscto"
        Me.cbNoAplicaDscto.Size = New System.Drawing.Size(118, 17)
        Me.cbNoAplicaDscto.TabIndex = 10
        Me.cbNoAplicaDscto.Text = "No Aplica Dscto"
        Me.cbNoAplicaDscto.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 223
        Me.Label12.Text = "Moneda"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(265, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 221
        Me.Label11.Text = "Mes"
        '
        'txtMesRegistro
        '
        Me.txtMesRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesRegistro.Location = New System.Drawing.Point(298, 20)
        Me.txtMesRegistro.MaxLength = 2
        Me.txtMesRegistro.Name = "txtMesRegistro"
        Me.txtMesRegistro.Numeric = True
        Me.txtMesRegistro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMesRegistro.Size = New System.Drawing.Size(47, 20)
        Me.txtMesRegistro.TabIndex = 2
        '
        'txtIdPlanilla
        '
        Me.txtIdPlanilla.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdPlanilla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPlanilla.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdPlanilla.Location = New System.Drawing.Point(80, 20)
        Me.txtIdPlanilla.MaxLength = 20
        Me.txtIdPlanilla.Name = "txtIdPlanilla"
        Me.txtIdPlanilla.ReadOnly = True
        Me.txtIdPlanilla.Size = New System.Drawing.Size(60, 20)
        Me.txtIdPlanilla.TabIndex = 11
        Me.txtIdPlanilla.TabStop = False
        Me.txtIdPlanilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Nº Planilla"
        '
        'txtDuracion
        '
        Me.txtDuracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuracion.Location = New System.Drawing.Point(410, 20)
        Me.txtDuracion.Maximum = 31
        Me.txtDuracion.MaxLength = 200
        Me.txtDuracion.Minimum = 1
        Me.txtDuracion.Name = "txtDuracion"
        Me.txtDuracion.Size = New System.Drawing.Size(58, 20)
        Me.txtDuracion.TabIndex = 3
        Me.txtDuracion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDuracion.Value = 1
        Me.txtDuracion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(349, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Duración"
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.Label6)
        Me.UiGroupBox4.Controls.Add(Me.Label5)
        Me.UiGroupBox4.Controls.Add(Me.txtFecPlaFin)
        Me.UiGroupBox4.Controls.Add(Me.txtFecPlaIni)
        Me.UiGroupBox4.Location = New System.Drawing.Point(15, 82)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(320, 44)
        Me.UiGroupBox4.TabIndex = 11
        Me.UiGroupBox4.Text = "Planilla"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Inicio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(173, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Final"
        '
        'txtFecPlaFin
        '
        '
        '
        '
        Me.txtFecPlaFin.DropDownCalendar.Name = ""
        Me.txtFecPlaFin.DropDownCalendar.Visible = False
        Me.txtFecPlaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecPlaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecPlaFin.Location = New System.Drawing.Point(213, 18)
        Me.txtFecPlaFin.Name = "txtFecPlaFin"
        Me.txtFecPlaFin.NullButtonText = "Ninguno"
        Me.txtFecPlaFin.Size = New System.Drawing.Size(92, 20)
        Me.txtFecPlaFin.TabIndex = 13
        Me.txtFecPlaFin.TodayButtonText = "Hoy"
        Me.txtFecPlaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecPlaIni
        '
        '
        '
        '
        Me.txtFecPlaIni.DropDownCalendar.Name = ""
        Me.txtFecPlaIni.DropDownCalendar.Visible = False
        Me.txtFecPlaIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecPlaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecPlaIni.Location = New System.Drawing.Point(60, 18)
        Me.txtFecPlaIni.Name = "txtFecPlaIni"
        Me.txtFecPlaIni.NullButtonText = "Ninguno"
        Me.txtFecPlaIni.Size = New System.Drawing.Size(92, 20)
        Me.txtFecPlaIni.TabIndex = 12
        Me.txtFecPlaIni.TodayButtonText = "Hoy"
        Me.txtFecPlaIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.Label4)
        Me.UiGroupBox3.Controls.Add(Me.Label3)
        Me.UiGroupBox3.Controls.Add(Me.txtFecTarFin)
        Me.UiGroupBox3.Controls.Add(Me.txtFecTarIni)
        Me.UiGroupBox3.Location = New System.Drawing.Point(362, 181)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(320, 44)
        Me.UiGroupBox3.TabIndex = 20
        Me.UiGroupBox3.Text = "Tardanzas"
        Me.UiGroupBox3.Visible = False
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(173, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Final"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Inicio"
        '
        'txtFecTarFin
        '
        '
        '
        '
        Me.txtFecTarFin.DropDownCalendar.Name = ""
        Me.txtFecTarFin.DropDownCalendar.Visible = False
        Me.txtFecTarFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecTarFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecTarFin.Location = New System.Drawing.Point(213, 18)
        Me.txtFecTarFin.Name = "txtFecTarFin"
        Me.txtFecTarFin.NullButtonText = "Ninguno"
        Me.txtFecTarFin.Size = New System.Drawing.Size(92, 20)
        Me.txtFecTarFin.TabIndex = 22
        Me.txtFecTarFin.TodayButtonText = "Hoy"
        Me.txtFecTarFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecTarIni
        '
        '
        '
        '
        Me.txtFecTarIni.DropDownCalendar.Name = ""
        Me.txtFecTarIni.DropDownCalendar.Visible = False
        Me.txtFecTarIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecTarIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecTarIni.Location = New System.Drawing.Point(60, 18)
        Me.txtFecTarIni.Name = "txtFecTarIni"
        Me.txtFecTarIni.NullButtonText = "Ninguno"
        Me.txtFecTarIni.Size = New System.Drawing.Size(92, 20)
        Me.txtFecTarIni.TabIndex = 21
        Me.txtFecTarIni.TodayButtonText = "Hoy"
        Me.txtFecTarIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtFecProFin)
        Me.UiGroupBox2.Controls.Add(Me.txtFecProIni)
        Me.UiGroupBox2.Location = New System.Drawing.Point(410, 82)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(320, 44)
        Me.UiGroupBox2.TabIndex = 14
        Me.UiGroupBox2.Text = "Proceso"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(171, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Final"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Inicio"
        '
        'txtFecProFin
        '
        '
        '
        '
        Me.txtFecProFin.DropDownCalendar.Name = ""
        Me.txtFecProFin.DropDownCalendar.Visible = False
        Me.txtFecProFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecProFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecProFin.Location = New System.Drawing.Point(211, 18)
        Me.txtFecProFin.Name = "txtFecProFin"
        Me.txtFecProFin.NullButtonText = "Ninguno"
        Me.txtFecProFin.Size = New System.Drawing.Size(92, 20)
        Me.txtFecProFin.TabIndex = 16
        Me.txtFecProFin.TodayButtonText = "Hoy"
        Me.txtFecProFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecProIni
        '
        '
        '
        '
        Me.txtFecProIni.DropDownCalendar.Name = ""
        Me.txtFecProIni.DropDownCalendar.Visible = False
        Me.txtFecProIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecProIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecProIni.Location = New System.Drawing.Point(59, 18)
        Me.txtFecProIni.Name = "txtFecProIni"
        Me.txtFecProIni.NullButtonText = "Ninguno"
        Me.txtFecProIni.Size = New System.Drawing.Size(92, 20)
        Me.txtFecProIni.TabIndex = 15
        Me.txtFecProIni.TodayButtonText = "Hoy"
        Me.txtFecProIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtFecExtFin)
        Me.UiGroupBox1.Controls.Add(Me.txtFecExtIni)
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 181)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(320, 44)
        Me.UiGroupBox1.TabIndex = 17
        Me.UiGroupBox1.Text = "Horas Extras"
        Me.UiGroupBox1.Visible = False
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(173, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Inicio"
        '
        'txtFecExtFin
        '
        '
        '
        '
        Me.txtFecExtFin.DropDownCalendar.Name = ""
        Me.txtFecExtFin.DropDownCalendar.Visible = False
        Me.txtFecExtFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecExtFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecExtFin.Location = New System.Drawing.Point(213, 18)
        Me.txtFecExtFin.Name = "txtFecExtFin"
        Me.txtFecExtFin.NullButtonText = "Ninguno"
        Me.txtFecExtFin.Size = New System.Drawing.Size(92, 20)
        Me.txtFecExtFin.TabIndex = 19
        Me.txtFecExtFin.TodayButtonText = "Hoy"
        Me.txtFecExtFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecExtIni
        '
        '
        '
        '
        Me.txtFecExtIni.DropDownCalendar.Name = ""
        Me.txtFecExtIni.DropDownCalendar.Visible = False
        Me.txtFecExtIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecExtIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecExtIni.Location = New System.Drawing.Point(60, 18)
        Me.txtFecExtIni.Name = "txtFecExtIni"
        Me.txtFecExtIni.NullButtonText = "Ninguno"
        Me.txtFecExtIni.Size = New System.Drawing.Size(92, 20)
        Me.txtFecExtIni.TabIndex = 18
        Me.txtFecExtIni.TodayButtonText = "Hoy"
        Me.txtFecExtIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatos_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatos_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatos_DesignTimeLayout_Reference_0})
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(0, 217)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(751, 390)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox5.Controls.Add(Me.Label26)
        Me.UiGroupBox5.Controls.Add(Me.txtAportacionDol)
        Me.UiGroupBox5.Controls.Add(Me.txtAportacionSol)
        Me.UiGroupBox5.Controls.Add(Me.Label17)
        Me.UiGroupBox5.Controls.Add(Me.txtNetoDol)
        Me.UiGroupBox5.Controls.Add(Me.Label18)
        Me.UiGroupBox5.Controls.Add(Me.txtNetoSol)
        Me.UiGroupBox5.Controls.Add(Me.Label19)
        Me.UiGroupBox5.Controls.Add(Me.txtDescuentoDol)
        Me.UiGroupBox5.Controls.Add(Me.Label20)
        Me.UiGroupBox5.Controls.Add(Me.txtDescuentoSol)
        Me.UiGroupBox5.Controls.Add(Me.Label21)
        Me.UiGroupBox5.Controls.Add(Me.txtIngresosDol)
        Me.UiGroupBox5.Controls.Add(Me.Label22)
        Me.UiGroupBox5.Controls.Add(Me.txtIngresosSol)
        Me.UiGroupBox5.Controls.Add(Me.Label23)
        Me.UiGroupBox5.Controls.Add(Me.Label24)
        Me.UiGroupBox5.Controls.Add(Me.Label25)
        Me.UiGroupBox5.Location = New System.Drawing.Point(0, 576)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(750, 106)
        Me.UiGroupBox5.TabIndex = 220
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(551, 12)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(101, 13)
        Me.Label26.TabIndex = 21
        Me.Label26.Text = "Total Aportación"
        '
        'txtAportacionDol
        '
        Me.txtAportacionDol.DecimalDigits = 2
        Me.txtAportacionDol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtAportacionDol.Location = New System.Drawing.Point(551, 49)
        Me.txtAportacionDol.Name = "txtAportacionDol"
        Me.txtAportacionDol.ReadOnly = True
        Me.txtAportacionDol.Size = New System.Drawing.Size(100, 20)
        Me.txtAportacionDol.TabIndex = 23
        Me.txtAportacionDol.Text = "0.00"
        Me.txtAportacionDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtAportacionDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtAportacionSol
        '
        Me.txtAportacionSol.DecimalDigits = 2
        Me.txtAportacionSol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtAportacionSol.Location = New System.Drawing.Point(551, 27)
        Me.txtAportacionSol.Name = "txtAportacionSol"
        Me.txtAportacionSol.ReadOnly = True
        Me.txtAportacionSol.Size = New System.Drawing.Size(100, 20)
        Me.txtAportacionSol.TabIndex = 22
        Me.txtAportacionSol.Text = "0.00"
        Me.txtAportacionSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtAportacionSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(436, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Total Neto"
        '
        'txtNetoDol
        '
        Me.txtNetoDol.DecimalDigits = 2
        Me.txtNetoDol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtNetoDol.Location = New System.Drawing.Point(419, 49)
        Me.txtNetoDol.Name = "txtNetoDol"
        Me.txtNetoDol.ReadOnly = True
        Me.txtNetoDol.Size = New System.Drawing.Size(100, 20)
        Me.txtNetoDol.TabIndex = 20
        Me.txtNetoDol.Text = "0.00"
        Me.txtNetoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtNetoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(242, 30)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(10, 13)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "-"
        '
        'txtNetoSol
        '
        Me.txtNetoSol.DecimalDigits = 2
        Me.txtNetoSol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtNetoSol.Location = New System.Drawing.Point(419, 27)
        Me.txtNetoSol.Name = "txtNetoSol"
        Me.txtNetoSol.ReadOnly = True
        Me.txtNetoSol.Size = New System.Drawing.Size(100, 20)
        Me.txtNetoSol.TabIndex = 14
        Me.txtNetoSol.Text = "0.00"
        Me.txtNetoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtNetoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(88, 52)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 13)
        Me.Label19.TabIndex = 15
        Me.Label19.Text = "US $"
        '
        'txtDescuentoDol
        '
        Me.txtDescuentoDol.DecimalDigits = 2
        Me.txtDescuentoDol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtDescuentoDol.Location = New System.Drawing.Point(272, 49)
        Me.txtDescuentoDol.Name = "txtDescuentoDol"
        Me.txtDescuentoDol.ReadOnly = True
        Me.txtDescuentoDol.Size = New System.Drawing.Size(100, 20)
        Me.txtDescuentoDol.TabIndex = 18
        Me.txtDescuentoDol.Text = "0.00"
        Me.txtDescuentoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDescuentoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(242, 52)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(10, 13)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "-"
        '
        'txtDescuentoSol
        '
        Me.txtDescuentoSol.DecimalDigits = 2
        Me.txtDescuentoSol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtDescuentoSol.Location = New System.Drawing.Point(272, 27)
        Me.txtDescuentoSol.Name = "txtDescuentoSol"
        Me.txtDescuentoSol.ReadOnly = True
        Me.txtDescuentoSol.Size = New System.Drawing.Size(100, 20)
        Me.txtDescuentoSol.TabIndex = 12
        Me.txtDescuentoSol.Text = "0.00"
        Me.txtDescuentoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDescuentoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(88, 30)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(25, 13)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "S/."
        '
        'txtIngresosDol
        '
        Me.txtIngresosDol.DecimalDigits = 2
        Me.txtIngresosDol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtIngresosDol.Location = New System.Drawing.Point(126, 49)
        Me.txtIngresosDol.Name = "txtIngresosDol"
        Me.txtIngresosDol.ReadOnly = True
        Me.txtIngresosDol.Size = New System.Drawing.Size(100, 20)
        Me.txtIngresosDol.TabIndex = 16
        Me.txtIngresosDol.Text = "0.00"
        Me.txtIngresosDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIngresosDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(387, 30)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(13, 13)
        Me.Label22.TabIndex = 13
        Me.Label22.Text = "="
        '
        'txtIngresosSol
        '
        Me.txtIngresosSol.DecimalDigits = 2
        Me.txtIngresosSol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtIngresosSol.Location = New System.Drawing.Point(126, 27)
        Me.txtIngresosSol.Name = "txtIngresosSol"
        Me.txtIngresosSol.ReadOnly = True
        Me.txtIngresosSol.Size = New System.Drawing.Size(100, 20)
        Me.txtIngresosSol.TabIndex = 10
        Me.txtIngresosSol.Text = "0.00"
        Me.txtIngresosSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIngresosSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(387, 52)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(13, 13)
        Me.Label23.TabIndex = 19
        Me.Label23.Text = "="
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(153, 12)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(55, 13)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "Ingresos"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(285, 12)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(74, 13)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "Descuentos"
        '
        'frmPlanillaSueldo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(798, 725)
        Me.Controls.Add(Me.UiGroupBox5)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.gbCabecera)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanillaSueldo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla Sueldo"
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.gbCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCabecera.ResumeLayout(False)
        Me.gbCabecera.PerformLayout()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoPlanilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.UiGroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbCabecera As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecExtIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecPlaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecPlaIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecTarFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecTarIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecProFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecProIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecExtFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDuracion As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtIdPlanilla As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMesRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents cbNoAplicaDscto As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTipCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPlanilla As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents miInsertarMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbGenProceso As CheckBox
    Friend WithEvents biProcesarDetalle As ToolStripButton
    Friend WithEvents miEnviarCorreo As ToolStripMenuItem
    Friend WithEvents miProcesarLiquidacion As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents miProcesarVacaciones As ToolStripMenuItem
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNetoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtNetoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtDescuentoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtDescuentoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtIngresosDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtIngresosSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtAportacionDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtAportacionSol As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
