<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorario_Nuevo
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
        Dim cmbTurno_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHorario_Nuevo))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gbDetalles = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.gbDatosHorario = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTurno = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbAplicaTardanza = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotHoraNormal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtToleranciaRefrig = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtToleranciaIng = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTiempoRefrig = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.cbAplicaFeriado = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtCodHor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalles.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosHorario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosHorario.SuspendLayout()
        CType(Me.cmbTurno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
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
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Location = New System.Drawing.Point(0, 442)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(526, 20)
        Me.ssBarra.TabIndex = 235
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biEditar, Me.ToolStripSeparator4, Me.biDeshacer, Me.ToolStripSeparator6, Me.biCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(526, 31)
        Me.ToolStrip.TabIndex = 234
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
        Me.biEditar.Text = "Editar Datos"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'gbDetalles
        '
        Me.gbDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalles.Controls.Add(Me.dgvDatos)
        Me.gbDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalles.Location = New System.Drawing.Point(7, 219)
        Me.gbDetalles.Name = "gbDetalles"
        Me.gbDetalles.Size = New System.Drawing.Size(507, 210)
        Me.gbDetalles.TabIndex = 236
        Me.gbDetalles.Text = "Detalles"
        Me.gbDetalles.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalles.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
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
        Me.dgvDatos.Location = New System.Drawing.Point(7, 16)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(493, 187)
        Me.dgvDatos.TabIndex = 228
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbDatosHorario
        '
        Me.gbDatosHorario.Controls.Add(Me.Label6)
        Me.gbDatosHorario.Controls.Add(Me.cmbTurno)
        Me.gbDatosHorario.Controls.Add(Me.cbAplicaTardanza)
        Me.gbDatosHorario.Controls.Add(Me.Label5)
        Me.gbDatosHorario.Controls.Add(Me.txtTotHoraNormal)
        Me.gbDatosHorario.Controls.Add(Me.Label4)
        Me.gbDatosHorario.Controls.Add(Me.txtToleranciaRefrig)
        Me.gbDatosHorario.Controls.Add(Me.Label3)
        Me.gbDatosHorario.Controls.Add(Me.txtToleranciaIng)
        Me.gbDatosHorario.Controls.Add(Me.Label2)
        Me.gbDatosHorario.Controls.Add(Me.txtTiempoRefrig)
        Me.gbDatosHorario.Controls.Add(Me.cbVigente)
        Me.gbDatosHorario.Controls.Add(Me.cbAplicaFeriado)
        Me.gbDatosHorario.Controls.Add(Me.Label9)
        Me.gbDatosHorario.Controls.Add(Me.txtDescripcion)
        Me.gbDatosHorario.Controls.Add(Me.txtCodHor)
        Me.gbDatosHorario.Controls.Add(Me.Label1)
        Me.gbDatosHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosHorario.Location = New System.Drawing.Point(7, 36)
        Me.gbDatosHorario.Name = "gbDatosHorario"
        Me.gbDatosHorario.Size = New System.Drawing.Size(507, 176)
        Me.gbDatosHorario.TabIndex = 0
        Me.gbDatosHorario.Text = "Datos de Horario"
        Me.gbDatosHorario.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 281
        Me.Label6.Text = "Turno"
        '
        'cmbTurno
        '
        Me.cmbTurno.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTurno_DesignTimeLayout.LayoutString = resources.GetString("cmbTurno_DesignTimeLayout.LayoutString")
        Me.cmbTurno.DesignTimeLayout = cmbTurno_DesignTimeLayout
        Me.cmbTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTurno.Location = New System.Drawing.Point(84, 46)
        Me.cmbTurno.Name = "cmbTurno"
        Me.cmbTurno.SelectedIndex = -1
        Me.cmbTurno.SelectedItem = Nothing
        Me.cmbTurno.Size = New System.Drawing.Size(80, 20)
        Me.cmbTurno.TabIndex = 2
        Me.cmbTurno.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbAplicaTardanza
        '
        Me.cbAplicaTardanza.AutoSize = True
        Me.cbAplicaTardanza.BackColor = System.Drawing.SystemColors.Control
        Me.cbAplicaTardanza.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAplicaTardanza.ForeColor = System.Drawing.Color.Black
        Me.cbAplicaTardanza.Location = New System.Drawing.Point(174, 47)
        Me.cbAplicaTardanza.Name = "cbAplicaTardanza"
        Me.cbAplicaTardanza.Size = New System.Drawing.Size(118, 17)
        Me.cbAplicaTardanza.TabIndex = 3
        Me.cbAplicaTardanza.Text = "Aplica Tardanza"
        Me.cbAplicaTardanza.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(282, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 279
        Me.Label5.Text = "Tot Hrs Normal"
        '
        'txtTotHoraNormal
        '
        Me.txtTotHoraNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotHoraNormal.Location = New System.Drawing.Point(380, 146)
        Me.txtTotHoraNormal.MaxLength = 10
        Me.txtTotHoraNormal.Name = "txtTotHoraNormal"
        Me.txtTotHoraNormal.Size = New System.Drawing.Size(67, 20)
        Me.txtTotHoraNormal.TabIndex = 10
        Me.txtTotHoraNormal.Text = "0.00"
        Me.txtTotHoraNormal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotHoraNormal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 277
        Me.Label4.Text = "Tolerancia Refrig"
        '
        'txtToleranciaRefrig
        '
        Me.txtToleranciaRefrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToleranciaRefrig.Location = New System.Drawing.Point(158, 146)
        Me.txtToleranciaRefrig.MaxLength = 10
        Me.txtToleranciaRefrig.Name = "txtToleranciaRefrig"
        Me.txtToleranciaRefrig.Size = New System.Drawing.Size(67, 20)
        Me.txtToleranciaRefrig.TabIndex = 9
        Me.txtToleranciaRefrig.Text = "0.00"
        Me.txtToleranciaRefrig.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtToleranciaRefrig.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 275
        Me.Label3.Text = "Tolerancia Ingreso"
        '
        'txtToleranciaIng
        '
        Me.txtToleranciaIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToleranciaIng.Location = New System.Drawing.Point(158, 118)
        Me.txtToleranciaIng.MaxLength = 10
        Me.txtToleranciaIng.Name = "txtToleranciaIng"
        Me.txtToleranciaIng.Size = New System.Drawing.Size(67, 20)
        Me.txtToleranciaIng.TabIndex = 7
        Me.txtToleranciaIng.Text = "0.00"
        Me.txtToleranciaIng.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtToleranciaIng.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(288, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 273
        Me.Label2.Text = "Tiempo Refrig"
        '
        'txtTiempoRefrig
        '
        Me.txtTiempoRefrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiempoRefrig.Location = New System.Drawing.Point(380, 118)
        Me.txtTiempoRefrig.MaxLength = 10
        Me.txtTiempoRefrig.Name = "txtTiempoRefrig"
        Me.txtTiempoRefrig.Size = New System.Drawing.Size(67, 20)
        Me.txtTiempoRefrig.TabIndex = 8
        Me.txtTiempoRefrig.Text = "0.00"
        Me.txtTiempoRefrig.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTiempoRefrig.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.BackColor = System.Drawing.SystemColors.Control
        Me.cbVigente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigente.ForeColor = System.Drawing.Color.Black
        Me.cbVigente.Location = New System.Drawing.Point(426, 47)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(69, 17)
        Me.cbVigente.TabIndex = 5
        Me.cbVigente.Text = "Vigente"
        Me.cbVigente.UseVisualStyleBackColor = False
        '
        'cbAplicaFeriado
        '
        Me.cbAplicaFeriado.AutoSize = True
        Me.cbAplicaFeriado.BackColor = System.Drawing.SystemColors.Control
        Me.cbAplicaFeriado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAplicaFeriado.ForeColor = System.Drawing.Color.Black
        Me.cbAplicaFeriado.Location = New System.Drawing.Point(306, 47)
        Me.cbAplicaFeriado.Name = "cbAplicaFeriado"
        Me.cbAplicaFeriado.Size = New System.Drawing.Size(107, 17)
        Me.cbAplicaFeriado.TabIndex = 4
        Me.cbAplicaFeriado.Text = "Aplica Feriado"
        Me.cbAplicaFeriado.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 269
        Me.Label9.Text = "Descripción"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(84, 72)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(411, 40)
        Me.txtDescripcion.TabIndex = 6
        '
        'txtCodHor
        '
        Me.txtCodHor.Location = New System.Drawing.Point(84, 20)
        Me.txtCodHor.Name = "txtCodHor"
        Me.txtCodHor.Size = New System.Drawing.Size(67, 20)
        Me.txtCodHor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'frmHorario_Nuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(526, 462)
        Me.Controls.Add(Me.gbDatosHorario)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDetalles)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHorario_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Horario"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalles.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosHorario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosHorario.ResumeLayout(False)
        Me.gbDatosHorario.PerformLayout()
        CType(Me.cmbTurno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbDetalles As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDatosHorario As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCodHor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbVigente As System.Windows.Forms.CheckBox
    Friend WithEvents cbAplicaFeriado As System.Windows.Forms.CheckBox
    Friend WithEvents txtTiempoRefrig As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotHoraNormal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtToleranciaRefrig As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtToleranciaIng As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbAplicaTardanza As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTurno As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
