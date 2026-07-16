<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActivoFijo
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
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoActivo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUbicacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActivoFijo))
        Dim dgvObservaciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
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
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCodMaleta = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtValorAdquisicion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtFecBaja = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVidaUtil = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cmbTipoActivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtNumFactura = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodActivo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFecAdquisicion = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cmbUbicacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tpDetalles = New Janus.Windows.UI.Tab.UITab()
        Me.tpGastos = New Janus.Windows.UI.Tab.UITabPage()
        Me.tpObservaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvObservaciones = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesObs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.tpDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDetalles.SuspendLayout()
        Me.tpGastos.SuspendLayout()
        Me.tpObservaciones.SuspendLayout()
        CType(Me.dgvObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesObs.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 579)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(654, 20)
        Me.ssBarra.TabIndex = 236
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(400, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(180, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biGuardar, Me.ToolStripSeparator5, Me.biEditar, Me.ToolStripSeparator6, Me.biDeshacer, Me.ToolStripSeparator8, Me.biCerrar, Me.ToolStripSeparator9})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(654, 31)
        Me.ToolStrip1.TabIndex = 237
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
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 104)
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
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.txtCodMaleta)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.txtValorAdquisicion)
        Me.UiGroupBox1.Controls.Add(Me.Label25)
        Me.UiGroupBox1.Controls.Add(Me.txtFecBaja)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtVidaUtil)
        Me.UiGroupBox1.Controls.Add(Me.Label42)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipoActivo)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.lblSerie)
        Me.UiGroupBox1.Controls.Add(Me.txtSerie)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtModelo)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtMarca)
        Me.UiGroupBox1.Controls.Add(Me.txtNumFactura)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.txtDescripcion)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.txtCodActivo)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.gbEstado)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.txtFecAdquisicion)
        Me.UiGroupBox1.Controls.Add(Me.cmbUbicacion)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 33)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(632, 248)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Datos de Activo Fijo"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(550, 152)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(69, 20)
        Me.cmbMoneda.TabIndex = 12
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(492, 155)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 400
        Me.Label15.Text = "Moneda"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 217)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 398
        Me.Label14.Text = "Cod. Maleta"
        '
        'txtCodMaleta
        '
        Me.txtCodMaleta.Location = New System.Drawing.Point(97, 214)
        Me.txtCodMaleta.Name = "txtCodMaleta"
        Me.txtCodMaleta.Size = New System.Drawing.Size(255, 20)
        Me.txtCodMaleta.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(165, 156)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 396
        Me.Label11.Text = "meses"
        '
        'txtValorAdquisicion
        '
        Me.txtValorAdquisicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorAdquisicion.Location = New System.Drawing.Point(354, 152)
        Me.txtValorAdquisicion.MaxLength = 10
        Me.txtValorAdquisicion.Name = "txtValorAdquisicion"
        Me.txtValorAdquisicion.Size = New System.Drawing.Size(90, 20)
        Me.txtValorAdquisicion.TabIndex = 11
        Me.txtValorAdquisicion.Text = "0.00"
        Me.txtValorAdquisicion.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtValorAdquisicion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(254, 156)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(98, 13)
        Me.Label25.TabIndex = 395
        Me.Label25.Text = "Valor Aquisición"
        '
        'txtFecBaja
        '
        Me.txtFecBaja.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecBaja.DropDownCalendar.Name = ""
        Me.txtFecBaja.DropDownCalendar.Visible = False
        Me.txtFecBaja.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecBaja.IsNullDate = True
        Me.txtFecBaja.Location = New System.Drawing.Point(525, 214)
        Me.txtFecBaja.Name = "txtFecBaja"
        Me.txtFecBaja.ReadOnly = True
        Me.txtFecBaja.Size = New System.Drawing.Size(94, 20)
        Me.txtFecBaja.TabIndex = 15
        Me.txtFecBaja.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(434, 218)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 393
        Me.Label7.Text = "Fecha de Baja"
        '
        'txtVidaUtil
        '
        Me.txtVidaUtil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVidaUtil.Location = New System.Drawing.Point(98, 152)
        Me.txtVidaUtil.Maximum = 300000
        Me.txtVidaUtil.MaxLength = 200
        Me.txtVidaUtil.Name = "txtVidaUtil"
        Me.txtVidaUtil.Size = New System.Drawing.Size(65, 20)
        Me.txtVidaUtil.TabIndex = 10
        Me.txtVidaUtil.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtVidaUtil.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(37, 156)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(55, 13)
        Me.Label42.TabIndex = 390
        Me.Label42.Text = "Vida Útil"
        '
        'cmbTipoActivo
        '
        Me.cmbTipoActivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoActivo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoActivo_DesignTimeLayout.LayoutString")
        Me.cmbTipoActivo.DesignTimeLayout = cmbTipoActivo_DesignTimeLayout
        Me.cmbTipoActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoActivo.Location = New System.Drawing.Point(364, 128)
        Me.cmbTipoActivo.Name = "cmbTipoActivo"
        Me.cmbTipoActivo.SelectedIndex = -1
        Me.cmbTipoActivo.SelectedItem = Nothing
        Me.cmbTipoActivo.Size = New System.Drawing.Size(195, 20)
        Me.cmbTipoActivo.TabIndex = 9
        Me.cmbTipoActivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbTipoActivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(326, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 389
        Me.Label3.Text = "Tipo"
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = True
        Me.lblSerie.Location = New System.Drawing.Point(322, 107)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(36, 13)
        Me.lblSerie.TabIndex = 387
        Me.lblSerie.Text = "Serie"
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(364, 104)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(255, 20)
        Me.txtSerie.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(310, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 386
        Me.Label1.Text = "Modelo"
        '
        'txtModelo
        '
        Me.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModelo.Location = New System.Drawing.Point(364, 80)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(255, 20)
        Me.txtModelo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 385
        Me.Label2.Text = "Marca"
        '
        'txtMarca
        '
        Me.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarca.Location = New System.Drawing.Point(98, 104)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(177, 20)
        Me.txtMarca.TabIndex = 6
        '
        'txtNumFactura
        '
        Me.txtNumFactura.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumFactura.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumFactura.Location = New System.Drawing.Point(98, 80)
        Me.txtNumFactura.MaxLength = 20
        Me.txtNumFactura.Name = "txtNumFactura"
        Me.txtNumFactura.ReadOnly = True
        Me.txtNumFactura.Size = New System.Drawing.Size(139, 20)
        Me.txtNumFactura.TabIndex = 4
        Me.txtNumFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 381
        Me.Label10.Text = "N° Factura"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(98, 44)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(521, 32)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 378
        Me.Label9.Text = "Descripción"
        '
        'txtCodActivo
        '
        Me.txtCodActivo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodActivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodActivo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodActivo.Location = New System.Drawing.Point(98, 20)
        Me.txtCodActivo.MaxLength = 20
        Me.txtCodActivo.Name = "txtCodActivo"
        Me.txtCodActivo.ReadOnly = True
        Me.txtCodActivo.Size = New System.Drawing.Size(124, 20)
        Me.txtCodActivo.TabIndex = 1
        Me.txtCodActivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(46, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 377
        Me.Label6.Text = "Código"
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.Color.Transparent
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(484, 6)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(135, 36)
        Me.gbEstado.TabIndex = 376
        Me.gbEstado.TabStop = False
        Me.gbEstado.Visible = False
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(8, 11)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(119, 20)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(251, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 13)
        Me.Label8.TabIndex = 375
        Me.Label8.Text = "Fec. Adquisición"
        '
        'txtFecAdquisicion
        '
        '
        '
        '
        Me.txtFecAdquisicion.DropDownCalendar.Name = ""
        Me.txtFecAdquisicion.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecAdquisicion.Location = New System.Drawing.Point(354, 20)
        Me.txtFecAdquisicion.Name = "txtFecAdquisicion"
        Me.txtFecAdquisicion.Size = New System.Drawing.Size(92, 20)
        Me.txtFecAdquisicion.TabIndex = 2
        Me.txtFecAdquisicion.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUbicacion_DesignTimeLayout.LayoutString = resources.GetString("cmbUbicacion_DesignTimeLayout.LayoutString")
        Me.cmbUbicacion.DesignTimeLayout = cmbUbicacion_DesignTimeLayout
        Me.cmbUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacion.Location = New System.Drawing.Point(98, 128)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.SelectedIndex = -1
        Me.cmbUbicacion.SelectedItem = Nothing
        Me.cmbUbicacion.Size = New System.Drawing.Size(202, 20)
        Me.cmbUbicacion.TabIndex = 8
        Me.cmbUbicacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbUbicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 372
        Me.Label5.Text = "Ubicación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(98, 176)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(521, 32)
        Me.txtObservacion.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "Observación"
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
        Me.dgvDatos.Location = New System.Drawing.Point(11, 7)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(611, 191)
        Me.dgvDatos.TabIndex = 228
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtColaborador)
        Me.UiGroupBox2.Controls.Add(Me.Label13)
        Me.UiGroupBox2.Controls.Add(Me.txtMemo)
        Me.UiGroupBox2.Controls.Add(Me.Label12)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 287)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(632, 51)
        Me.UiGroupBox2.TabIndex = 240
        Me.UiGroupBox2.Text = "Asignacipon de Recursos"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtColaborador
        '
        Me.txtColaborador.BackColor = System.Drawing.SystemColors.Window
        Me.txtColaborador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColaborador.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtColaborador.Location = New System.Drawing.Point(313, 19)
        Me.txtColaborador.MaxLength = 20
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(306, 20)
        Me.txtColaborador.TabIndex = 380
        Me.txtColaborador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(235, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 381
        Me.Label13.Text = "Colaborador"
        '
        'txtMemo
        '
        Me.txtMemo.BackColor = System.Drawing.SystemColors.Window
        Me.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtMemo.Location = New System.Drawing.Point(98, 19)
        Me.txtMemo.MaxLength = 20
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.ReadOnly = True
        Me.txtMemo.Size = New System.Drawing.Size(124, 20)
        Me.txtMemo.TabIndex = 378
        Me.txtMemo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(46, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 379
        Me.Label12.Text = "Memo"
        '
        'tpDetalles
        '
        Me.tpDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tpDetalles.BackColor = System.Drawing.Color.Transparent
        Me.tpDetalles.Location = New System.Drawing.Point(6, 346)
        Me.tpDetalles.Name = "tpDetalles"
        Me.tpDetalles.Size = New System.Drawing.Size(636, 230)
        Me.tpDetalles.TabIndex = 241
        Me.tpDetalles.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tpGastos, Me.tpObservaciones})
        Me.tpDetalles.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'tpGastos
        '
        Me.tpGastos.Controls.Add(Me.dgvDatos)
        Me.tpGastos.Icon = CType(resources.GetObject("tpGastos.Icon"), System.Drawing.Icon)
        Me.tpGastos.Location = New System.Drawing.Point(1, 23)
        Me.tpGastos.Name = "tpGastos"
        Me.tpGastos.Size = New System.Drawing.Size(634, 206)
        Me.tpGastos.TabStop = True
        Me.tpGastos.Text = "GASTOS"
        '
        'tpObservaciones
        '
        Me.tpObservaciones.Controls.Add(Me.dgvObservaciones)
        Me.tpObservaciones.Icon = CType(resources.GetObject("tpObservaciones.Icon"), System.Drawing.Icon)
        Me.tpObservaciones.Location = New System.Drawing.Point(1, 23)
        Me.tpObservaciones.Name = "tpObservaciones"
        Me.tpObservaciones.Size = New System.Drawing.Size(630, 213)
        Me.tpObservaciones.TabStop = True
        Me.tpObservaciones.Text = "OBSERVACIONES"
        '
        'dgvObservaciones
        '
        Me.dgvObservaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvObservaciones.ContextMenuStrip = Me.cmOpcionesObs
        dgvObservaciones_DesignTimeLayout.LayoutString = resources.GetString("dgvObservaciones_DesignTimeLayout.LayoutString")
        Me.dgvObservaciones.DesignTimeLayout = dgvObservaciones_DesignTimeLayout
        Me.dgvObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvObservaciones.GroupByBoxVisible = False
        Me.dgvObservaciones.Location = New System.Drawing.Point(11, 9)
        Me.dgvObservaciones.Name = "dgvObservaciones"
        Me.dgvObservaciones.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvObservaciones.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvObservaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvObservaciones.Size = New System.Drawing.Size(611, 197)
        Me.dgvObservaciones.TabIndex = 340
        Me.dgvObservaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesObs
        '
        Me.cmOpcionesObs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoObs, Me.miMostrarObs, Me.miEliminarObs, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.miActualizarObs})
        Me.cmOpcionesObs.Name = "cmOpciones"
        Me.cmOpcionesObs.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoObs
        '
        Me.miNuevoObs.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoObs.Name = "miNuevoObs"
        Me.miNuevoObs.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoObs.Text = "Nuevo"
        Me.miNuevoObs.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarObs
        '
        Me.miMostrarObs.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarObs.Name = "miMostrarObs"
        Me.miMostrarObs.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarObs.Text = "Mostrar"
        Me.miMostrarObs.ToolTipText = "Mostrar Detalle"
        '
        'miEliminarObs
        '
        Me.miEliminarObs.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarObs.Name = "miEliminarObs"
        Me.miEliminarObs.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarObs.Text = "Eliminar"
        Me.miEliminarObs.ToolTipText = "Eliminar Detalle"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarObs
        '
        Me.miActualizarObs.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarObs.Name = "miActualizarObs"
        Me.miActualizarObs.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarObs.Text = "Actualizar"
        Me.miActualizarObs.ToolTipText = "Refrescar Lista Detalles"
        '
        'frmActivoFijo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(654, 599)
        Me.Controls.Add(Me.tpDetalles)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActivoFijo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activo Fijo"
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoActivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.tpDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDetalles.ResumeLayout(False)
        Me.tpGastos.ResumeLayout(False)
        Me.tpObservaciones.ResumeLayout(False)
        CType(Me.dgvObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesObs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
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
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbUbicacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNumFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCodActivo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFecAdquisicion As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblSerie As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbTipoActivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As Label
    Friend WithEvents txtVidaUtil As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label42 As Label
    Friend WithEvents txtFecBaja As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label7 As Label
    Friend WithEvents txtValorAdquisicion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtColaborador As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtMemo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents tpDetalles As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tpGastos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpObservaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvObservaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpcionesObs As ContextMenuStrip
    Friend WithEvents miNuevoObs As ToolStripMenuItem
    Friend WithEvents miMostrarObs As ToolStripMenuItem
    Friend WithEvents miEliminarObs As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents miActualizarObs As ToolStripMenuItem
    Friend WithEvents Label14 As Label
    Friend WithEvents txtCodMaleta As TextBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label15 As Label
End Class
