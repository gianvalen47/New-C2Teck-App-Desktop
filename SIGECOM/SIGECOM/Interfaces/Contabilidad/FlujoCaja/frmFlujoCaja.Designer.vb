<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlujoCaja
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
        Dim dgvObservaciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgDetalles_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFlujoCaja))
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
        Me.txtSaldoInicio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMesRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtIdFlujoCaja = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmOpcionesObs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarObs = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvObservaciones = New Janus.Windows.GridEX.GridEX()
        Me.tpObservaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.tpGastos = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgDetalles = New Janus.Windows.GridEX.GridEX()
        Me.txtIngresos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEgresos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSaldoFinal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesObs.SuspendLayout()
        CType(Me.dgvObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpObservaciones.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpGastos.SuspendLayout()
        CType(Me.dgDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 556)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(658, 20)
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
        Me.ToolStrip1.Size = New System.Drawing.Size(658, 31)
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
        Me.UiGroupBox1.Controls.Add(Me.txtSaldoInicio)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.txtPeriodo)
        Me.UiGroupBox1.Controls.Add(Me.Label13)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.txtMesRegistro)
        Me.UiGroupBox1.Controls.Add(Me.txtIdFlujoCaja)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.gbEstado)
        Me.UiGroupBox1.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(607, 146)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Datos de Activo Fijo"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtSaldoInicio
        '
        Me.txtSaldoInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoInicio.Location = New System.Drawing.Point(309, 77)
        Me.txtSaldoInicio.MaxLength = 10
        Me.txtSaldoInicio.Name = "txtSaldoInicio"
        Me.txtSaldoInicio.Size = New System.Drawing.Size(109, 20)
        Me.txtSaldoInicio.TabIndex = 398
        Me.txtSaldoInicio.Text = "0.00"
        Me.txtSaldoInicio.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSaldoInicio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(230, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 397
        Me.Label8.Text = "Saldo Inicio"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(98, 48)
        Me.txtPeriodo.Maximum = 2059
        Me.txtPeriodo.Minimum = 2021
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
        Me.txtPeriodo.TabIndex = 378
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.Value = 2021
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(42, 51)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 381
        Me.Label13.Text = "Periodo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(170, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 380
        Me.Label11.Text = "Mes"
        '
        'txtMesRegistro
        '
        Me.txtMesRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesRegistro.Location = New System.Drawing.Point(203, 48)
        Me.txtMesRegistro.MaxLength = 2
        Me.txtMesRegistro.Name = "txtMesRegistro"
        Me.txtMesRegistro.Numeric = True
        Me.txtMesRegistro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMesRegistro.Size = New System.Drawing.Size(47, 20)
        Me.txtMesRegistro.TabIndex = 379
        '
        'txtIdFlujoCaja
        '
        Me.txtIdFlujoCaja.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdFlujoCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdFlujoCaja.Enabled = False
        Me.txtIdFlujoCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdFlujoCaja.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdFlujoCaja.Location = New System.Drawing.Point(98, 20)
        Me.txtIdFlujoCaja.MaxLength = 20
        Me.txtIdFlujoCaja.Name = "txtIdFlujoCaja"
        Me.txtIdFlujoCaja.ReadOnly = True
        Me.txtIdFlujoCaja.Size = New System.Drawing.Size(93, 20)
        Me.txtIdFlujoCaja.TabIndex = 1
        Me.txtIdFlujoCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.gbEstado.Location = New System.Drawing.Point(445, 6)
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
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.Location = New System.Drawing.Point(98, 77)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(109, 20)
        Me.cmbMoneda.TabIndex = 8
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 372
        Me.Label5.Text = "Moneda"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(98, 106)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(487, 32)
        Me.txtObservacion.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "Descripción"
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
        'tpObservaciones
        '
        Me.tpObservaciones.Controls.Add(Me.dgvObservaciones)
        Me.tpObservaciones.Icon = CType(resources.GetObject("tpObservaciones.Icon"), System.Drawing.Icon)
        Me.tpObservaciones.Location = New System.Drawing.Point(1, 23)
        Me.tpObservaciones.Name = "tpObservaciones"
        Me.tpObservaciones.Size = New System.Drawing.Size(647, 237)
        Me.tpObservaciones.TabStop = True
        Me.tpObservaciones.Text = "OBSERVACIONES"
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
        Me.dgvDatos.Size = New System.Drawing.Size(623, 214)
        Me.dgvDatos.TabIndex = 228
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tpGastos
        '
        Me.tpGastos.Controls.Add(Me.dgvDatos)
        Me.tpGastos.Icon = CType(resources.GetObject("tpGastos.Icon"), System.Drawing.Icon)
        Me.tpGastos.Location = New System.Drawing.Point(1, 23)
        Me.tpGastos.Name = "tpGastos"
        Me.tpGastos.Size = New System.Drawing.Size(647, 237)
        Me.tpGastos.TabStop = True
        Me.tpGastos.Text = "GASTOS"
        '
        'dgDetalles
        '
        Me.dgDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDetalles.ContextMenuStrip = Me.cmOpciones
        dgDetalles_DesignTimeLayout.LayoutString = resources.GetString("dgDetalles_DesignTimeLayout.LayoutString")
        Me.dgDetalles.DesignTimeLayout = dgDetalles_DesignTimeLayout
        Me.dgDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgDetalles.GroupByBoxVisible = False
        Me.dgDetalles.Location = New System.Drawing.Point(8, 185)
        Me.dgDetalles.Name = "dgDetalles"
        Me.dgDetalles.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgDetalles.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgDetalles.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgDetalles.Size = New System.Drawing.Size(622, 338)
        Me.dgDetalles.TabIndex = 238
        Me.dgDetalles.TabStop = False
        Me.dgDetalles.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIngresos
        '
        Me.txtIngresos.BackColor = System.Drawing.SystemColors.Control
        Me.txtIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngresos.Location = New System.Drawing.Point(70, 530)
        Me.txtIngresos.MaxLength = 10
        Me.txtIngresos.Name = "txtIngresos"
        Me.txtIngresos.ReadOnly = True
        Me.txtIngresos.Size = New System.Drawing.Size(106, 20)
        Me.txtIngresos.TabIndex = 400
        Me.txtIngresos.Text = "0.00"
        Me.txtIngresos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIngresos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 533)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 399
        Me.Label1.Text = "Ingresos"
        '
        'txtEgresos
        '
        Me.txtEgresos.BackColor = System.Drawing.SystemColors.Control
        Me.txtEgresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEgresos.Location = New System.Drawing.Point(241, 530)
        Me.txtEgresos.MaxLength = 10
        Me.txtEgresos.Name = "txtEgresos"
        Me.txtEgresos.ReadOnly = True
        Me.txtEgresos.Size = New System.Drawing.Size(106, 20)
        Me.txtEgresos.TabIndex = 402
        Me.txtEgresos.Text = "0.00"
        Me.txtEgresos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtEgresos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(183, 533)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 401
        Me.Label2.Text = "Egresos"
        '
        'txtSaldoFinal
        '
        Me.txtSaldoFinal.BackColor = System.Drawing.SystemColors.Control
        Me.txtSaldoFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoFinal.Location = New System.Drawing.Point(427, 530)
        Me.txtSaldoFinal.MaxLength = 10
        Me.txtSaldoFinal.Name = "txtSaldoFinal"
        Me.txtSaldoFinal.ReadOnly = True
        Me.txtSaldoFinal.Size = New System.Drawing.Size(106, 20)
        Me.txtSaldoFinal.TabIndex = 404
        Me.txtSaldoFinal.Text = "0.00"
        Me.txtSaldoFinal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSaldoFinal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(353, 533)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 403
        Me.Label3.Text = "Saldo Final"
        '
        'frmFlujoCaja
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(658, 576)
        Me.Controls.Add(Me.txtSaldoFinal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEgresos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIngresos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgDetalles)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFlujoCaja"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Flujo de Caja"
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesObs.ResumeLayout(False)
        CType(Me.dgvObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpObservaciones.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpGastos.ResumeLayout(False)
        CType(Me.dgDetalles, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIdFlujoCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmOpcionesObs As ContextMenuStrip
    Friend WithEvents miNuevoObs As ToolStripMenuItem
    Friend WithEvents miMostrarObs As ToolStripMenuItem
    Friend WithEvents miEliminarObs As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents miActualizarObs As ToolStripMenuItem
    Friend WithEvents dgvObservaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents tpObservaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents tpGastos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgDetalles As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtMesRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtSaldoInicio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSaldoFinal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEgresos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtIngresos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As Label
End Class
