<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillaServicio
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillaServicio))
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNumDias = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalDias = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.txtActividad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDurTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPosicion = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumPer = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.btnBuscarPlantilla = New System.Windows.Forms.Button()
        Me.txtPredecesor = New System.Windows.Forms.TextBox()
        Me.txtDuracion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoCargo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarCargo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarCargo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarCargo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblMantenimiento = New System.Windows.Forms.Label()
        Me.lblTipoMotor = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.UiGroupBox1.Controls.Add(Me.txtNumDias)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDias)
        Me.UiGroupBox1.Controls.Add(Me.txtActividad)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtDurTotal)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtPosicion)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.txtNumPer)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPlantilla)
        Me.UiGroupBox1.Controls.Add(Me.txtPredecesor)
        Me.UiGroupBox1.Controls.Add(Me.txtDuracion)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 72)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(672, 143)
        Me.UiGroupBox1.TabIndex = 216
        Me.UiGroupBox1.Text = "Mantenimiento de Plantillas"
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNumDias
        '
        Me.txtNumDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDias.Location = New System.Drawing.Point(241, 107)
        Me.txtNumDias.Maximum = 300000
        Me.txtNumDias.MaxLength = 200
        Me.txtNumDias.Name = "txtNumDias"
        Me.txtNumDias.ReadOnly = True
        Me.txtNumDias.Size = New System.Drawing.Size(56, 20)
        Me.txtNumDias.TabIndex = 214
        Me.txtNumDias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtNumDias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(318, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 213
        Me.Label1.Text = "Total Dias :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(183, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 212
        Me.Label5.Text = "N° Dia :"
        '
        'txtTotalDias
        '
        Me.txtTotalDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDias.Location = New System.Drawing.Point(397, 107)
        Me.txtTotalDias.Maximum = 300000
        Me.txtTotalDias.MaxLength = 200
        Me.txtTotalDias.Name = "txtTotalDias"
        Me.txtTotalDias.ReadOnly = True
        Me.txtTotalDias.Size = New System.Drawing.Size(56, 20)
        Me.txtTotalDias.TabIndex = 211
        Me.txtTotalDias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalDias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtActividad
        '
        Me.txtActividad.BackColor = System.Drawing.SystemColors.Control
        Me.txtActividad.Location = New System.Drawing.Point(79, 22)
        Me.txtActividad.Multiline = True
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.ReadOnly = True
        Me.txtActividad.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtActividad.Size = New System.Drawing.Size(544, 37)
        Me.txtActividad.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(309, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "N° Personas :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(143, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Duración (Hrs) :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(476, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "Duración Total :"
        '
        'txtDurTotal
        '
        Me.txtDurTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDurTotal.Location = New System.Drawing.Point(575, 69)
        Me.txtDurTotal.MaxLength = 10
        Me.txtDurTotal.Name = "txtDurTotal"
        Me.txtDurTotal.ReadOnly = True
        Me.txtDurTotal.Size = New System.Drawing.Size(53, 20)
        Me.txtDurTotal.TabIndex = 146
        Me.txtDurTotal.Text = "0.00"
        Me.txtDurTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDurTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 100
        Me.Label7.Text = "Posición :"
        '
        'txtPosicion
        '
        Me.txtPosicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosicion.Location = New System.Drawing.Point(79, 69)
        Me.txtPosicion.Maximum = 300000
        Me.txtPosicion.MaxLength = 200
        Me.txtPosicion.Name = "txtPosicion"
        Me.txtPosicion.Size = New System.Drawing.Size(48, 20)
        Me.txtPosicion.TabIndex = 145
        Me.txtPosicion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPosicion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 97
        Me.Label6.Text = "Actividad :"
        '
        'txtNumPer
        '
        Me.txtNumPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumPer.Location = New System.Drawing.Point(397, 69)
        Me.txtNumPer.Maximum = 300000
        Me.txtNumPer.MaxLength = 200
        Me.txtNumPer.Name = "txtNumPer"
        Me.txtNumPer.ReadOnly = True
        Me.txtNumPer.Size = New System.Drawing.Size(56, 20)
        Me.txtNumPer.TabIndex = 3
        Me.txtNumPer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtNumPer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarPlantilla
        '
        Me.btnBuscarPlantilla.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPlantilla.Location = New System.Drawing.Point(629, 22)
        Me.btnBuscarPlantilla.Name = "btnBuscarPlantilla"
        Me.btnBuscarPlantilla.Size = New System.Drawing.Size(30, 25)
        Me.btnBuscarPlantilla.TabIndex = 125
        Me.btnBuscarPlantilla.UseVisualStyleBackColor = True
        '
        'txtPredecesor
        '
        Me.txtPredecesor.BackColor = System.Drawing.SystemColors.Window
        Me.txtPredecesor.Location = New System.Drawing.Point(96, 108)
        Me.txtPredecesor.Multiline = True
        Me.txtPredecesor.Name = "txtPredecesor"
        Me.txtPredecesor.Size = New System.Drawing.Size(56, 19)
        Me.txtPredecesor.TabIndex = 4
        Me.txtPredecesor.Visible = False
        '
        'txtDuracion
        '
        Me.txtDuracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuracion.Location = New System.Drawing.Point(241, 69)
        Me.txtDuracion.MaxLength = 10
        Me.txtDuracion.Name = "txtDuracion"
        Me.txtDuracion.ReadOnly = True
        Me.txtDuracion.Size = New System.Drawing.Size(45, 20)
        Me.txtDuracion.TabIndex = 2
        Me.txtDuracion.Text = "0.00"
        Me.txtDuracion.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDuracion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 209
        Me.Label8.Text = "Predecesor :"
        Me.Label8.Visible = False
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biEditar, Me.ToolStripSeparator4, Me.biDeshacer, Me.ToolStripSeparator7, Me.biCerrar, Me.ToolStripSeparator5})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(694, 31)
        Me.ToolStrip.TabIndex = 217
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
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Cabecera"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
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
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(16, 19)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(643, 238)
        Me.dgvDatos.TabIndex = 218
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoCargo, Me.miMostrarCargo, Me.miEliminarCargo, Me.ToolStripMenuItem1, Me.miActualizarCargo})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevoCargo
        '
        Me.miNuevoCargo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoCargo.Name = "miNuevoCargo"
        Me.miNuevoCargo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoCargo.Text = "Nuevo"
        Me.miNuevoCargo.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarCargo
        '
        Me.miMostrarCargo.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarCargo.Name = "miMostrarCargo"
        Me.miMostrarCargo.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarCargo.Text = "Mostrar"
        Me.miMostrarCargo.ToolTipText = "Mostrar Detalle"
        '
        'miEliminarCargo
        '
        Me.miEliminarCargo.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarCargo.Name = "miEliminarCargo"
        Me.miEliminarCargo.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarCargo.Text = "Eliminar"
        Me.miEliminarCargo.ToolTipText = "Eliminar Detalle"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarCargo
        '
        Me.miActualizarCargo.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarCargo.Name = "miActualizarCargo"
        Me.miActualizarCargo.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarCargo.Text = "Actualizar"
        Me.miActualizarCargo.ToolTipText = "Refrescar Lista Detalles"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(198, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 220
        Me.Label9.Text = "Mantenimiento :"
        '
        'lblMantenimiento
        '
        Me.lblMantenimiento.AutoSize = True
        Me.lblMantenimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMantenimiento.Location = New System.Drawing.Point(301, 44)
        Me.lblMantenimiento.Name = "lblMantenimiento"
        Me.lblMantenimiento.Size = New System.Drawing.Size(0, 13)
        Me.lblMantenimiento.TabIndex = 221
        '
        'lblTipoMotor
        '
        Me.lblTipoMotor.AutoSize = True
        Me.lblTipoMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoMotor.Location = New System.Drawing.Point(438, 44)
        Me.lblTipoMotor.Name = "lblTipoMotor"
        Me.lblTipoMotor.Size = New System.Drawing.Size(0, 13)
        Me.lblTipoMotor.TabIndex = 223
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(357, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 222
        Me.Label11.Text = "Tipo Motor :"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(12, 221)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(672, 271)
        Me.gbDetalle.TabIndex = 224
        Me.gbDetalle.Text = "Personal"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'frmPlanillaServicio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(694, 504)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.lblTipoMotor)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblMantenimiento)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanillaServicio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtActividad As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDurTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPosicion As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNumPer As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents btnBuscarPlantilla As Button
    Friend WithEvents txtPredecesor As TextBox
    Friend WithEvents txtDuracion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents biGuardar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents biEditar As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents biDeshacer As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents biCerrar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtNumDias As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotalDias As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miNuevoCargo As ToolStripMenuItem
    Friend WithEvents miMostrarCargo As ToolStripMenuItem
    Friend WithEvents miEliminarCargo As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents miActualizarCargo As ToolStripMenuItem
    Friend WithEvents Label9 As Label
    Friend WithEvents lblMantenimiento As Label
    Friend WithEvents lblTipoMotor As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
End Class
