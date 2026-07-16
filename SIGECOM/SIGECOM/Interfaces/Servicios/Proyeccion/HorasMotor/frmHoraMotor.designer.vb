<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoraMotor
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
        Dim cmbPlanMant_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoPlanMant_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHoraMotor))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosEquipo = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnNumSerie = New System.Windows.Forms.Button()
        Me.txtNombreEquipo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.txtPotencia = New System.Windows.Forms.TextBox()
        Me.txtModeloEquipo = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtTipoEquipo = New System.Windows.Forms.TextBox()
        Me.txtModeloMotor = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbPlanMant = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtFecMantenimiento = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbCalcAutomatico = New System.Windows.Forms.CheckBox()
        Me.cbSwing = New System.Windows.Forms.CheckBox()
        Me.txtFecFinGarantia = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoPlanMant = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtHrsDiarias = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHrsTotales = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHrsParciales = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbDatosHrsEquipo = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbDetenido = New System.Windows.Forms.CheckBox()
        Me.txtFecArranque = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gbProximoMantenimiento = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbMantenimiento = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
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
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosEquipo.SuspendLayout()
        CType(Me.cmbPlanMant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoPlanMant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosHrsEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosHrsEquipo.SuspendLayout()
        CType(Me.gbProximoMantenimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProximoMantenimiento.SuspendLayout()
        CType(Me.gbMantenimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMantenimiento.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosEquipo
        '
        Me.gbDatosEquipo.Controls.Add(Me.btnNumSerie)
        Me.gbDatosEquipo.Controls.Add(Me.txtNombreEquipo)
        Me.gbDatosEquipo.Controls.Add(Me.Label9)
        Me.gbDatosEquipo.Controls.Add(Me.txtUbicacion)
        Me.gbDatosEquipo.Controls.Add(Me.txtPotencia)
        Me.gbDatosEquipo.Controls.Add(Me.txtModeloEquipo)
        Me.gbDatosEquipo.Controls.Add(Me.Label21)
        Me.gbDatosEquipo.Controls.Add(Me.txtTipoEquipo)
        Me.gbDatosEquipo.Controls.Add(Me.txtModeloMotor)
        Me.gbDatosEquipo.Controls.Add(Me.Label18)
        Me.gbDatosEquipo.Controls.Add(Me.Label19)
        Me.gbDatosEquipo.Controls.Add(Me.Label8)
        Me.gbDatosEquipo.Controls.Add(Me.txtCodMer)
        Me.gbDatosEquipo.Controls.Add(Me.Label5)
        Me.gbDatosEquipo.Controls.Add(Me.Label4)
        Me.gbDatosEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosEquipo.Location = New System.Drawing.Point(10, 30)
        Me.gbDatosEquipo.Name = "gbDatosEquipo"
        Me.gbDatosEquipo.Size = New System.Drawing.Size(586, 138)
        Me.gbDatosEquipo.TabIndex = 0
        Me.gbDatosEquipo.Text = "Datos de Equipo"
        Me.gbDatosEquipo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnNumSerie
        '
        Me.btnNumSerie.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnNumSerie.Location = New System.Drawing.Point(258, 18)
        Me.btnNumSerie.Name = "btnNumSerie"
        Me.btnNumSerie.Size = New System.Drawing.Size(25, 22)
        Me.btnNumSerie.TabIndex = 398
        Me.btnNumSerie.TabStop = False
        Me.btnNumSerie.UseVisualStyleBackColor = True
        '
        'txtNombreEquipo
        '
        Me.txtNombreEquipo.BackColor = System.Drawing.SystemColors.Control
        Me.txtNombreEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreEquipo.Location = New System.Drawing.Point(103, 105)
        Me.txtNombreEquipo.Name = "txtNombreEquipo"
        Me.txtNombreEquipo.ReadOnly = True
        Me.txtNombreEquipo.Size = New System.Drawing.Size(197, 21)
        Me.txtNombreEquipo.TabIndex = 397
        Me.txtNombreEquipo.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 15)
        Me.Label9.TabIndex = 396
        Me.Label9.Text = "Nombre Equipo"
        '
        'txtUbicacion
        '
        Me.txtUbicacion.BackColor = System.Drawing.SystemColors.Control
        Me.txtUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbicacion.Location = New System.Drawing.Point(401, 105)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.ReadOnly = True
        Me.txtUbicacion.Size = New System.Drawing.Size(107, 21)
        Me.txtUbicacion.TabIndex = 17
        Me.txtUbicacion.TabStop = False
        '
        'txtPotencia
        '
        Me.txtPotencia.BackColor = System.Drawing.SystemColors.Control
        Me.txtPotencia.Location = New System.Drawing.Point(435, 77)
        Me.txtPotencia.MaxLength = 4
        Me.txtPotencia.Name = "txtPotencia"
        Me.txtPotencia.ReadOnly = True
        Me.txtPotencia.Size = New System.Drawing.Size(63, 21)
        Me.txtPotencia.TabIndex = 395
        Me.txtPotencia.TabStop = False
        Me.txtPotencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtModeloEquipo
        '
        Me.txtModeloEquipo.BackColor = System.Drawing.SystemColors.Control
        Me.txtModeloEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModeloEquipo.Location = New System.Drawing.Point(103, 77)
        Me.txtModeloEquipo.Name = "txtModeloEquipo"
        Me.txtModeloEquipo.ReadOnly = True
        Me.txtModeloEquipo.Size = New System.Drawing.Size(166, 21)
        Me.txtModeloEquipo.TabIndex = 16
        Me.txtModeloEquipo.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(315, 80)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 15)
        Me.Label21.TabIndex = 394
        Me.Label21.Text = "Potencia Motor (HP)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTipoEquipo
        '
        Me.txtTipoEquipo.BackColor = System.Drawing.SystemColors.Control
        Me.txtTipoEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEquipo.Location = New System.Drawing.Point(103, 48)
        Me.txtTipoEquipo.Name = "txtTipoEquipo"
        Me.txtTipoEquipo.ReadOnly = True
        Me.txtTipoEquipo.Size = New System.Drawing.Size(197, 21)
        Me.txtTipoEquipo.TabIndex = 14
        Me.txtTipoEquipo.TabStop = False
        '
        'txtModeloMotor
        '
        Me.txtModeloMotor.BackColor = System.Drawing.SystemColors.Control
        Me.txtModeloMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModeloMotor.Location = New System.Drawing.Point(401, 48)
        Me.txtModeloMotor.Name = "txtModeloMotor"
        Me.txtModeloMotor.ReadOnly = True
        Me.txtModeloMotor.Size = New System.Drawing.Size(176, 21)
        Me.txtModeloMotor.TabIndex = 15
        Me.txtModeloMotor.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(28, 51)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 15)
        Me.Label18.TabIndex = 390
        Me.Label18.Text = "Tipo Equipo"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(10, 80)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 15)
        Me.Label19.TabIndex = 389
        Me.Label19.Text = "Modelo Equipo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(315, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 15)
        Me.Label8.TabIndex = 384
        Me.Label8.Text = "Modelo Motor"
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodMer.Location = New System.Drawing.Point(103, 19)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(150, 21)
        Me.txtCodMer.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 374
        Me.Label5.Text = "Serie Motor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(336, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 15)
        Me.Label4.TabIndex = 370
        Me.Label4.Text = "Ubicación"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(18, 34)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 15)
        Me.Label15.TabIndex = 252
        Me.Label15.Text = "Arranque"
        '
        'cmbPlanMant
        '
        Me.cmbPlanMant.BackColor = System.Drawing.SystemColors.Control
        Me.cmbPlanMant.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPlanMant_DesignTimeLayout.LayoutString = resources.GetString("cmbPlanMant_DesignTimeLayout.LayoutString")
        Me.cmbPlanMant.DesignTimeLayout = cmbPlanMant_DesignTimeLayout
        Me.cmbPlanMant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlanMant.Location = New System.Drawing.Point(271, 21)
        Me.cmbPlanMant.Name = "cmbPlanMant"
        Me.cmbPlanMant.ReadOnly = True
        Me.cmbPlanMant.SelectedIndex = -1
        Me.cmbPlanMant.SelectedItem = Nothing
        Me.cmbPlanMant.Size = New System.Drawing.Size(75, 21)
        Me.cmbPlanMant.TabIndex = 10
        Me.cmbPlanMant.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbPlanMant.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(152, 24)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 15)
        Me.Label17.TabIndex = 382
        Me.Label17.Text = "Tipo Mant. Próximo"
        '
        'txtFecMantenimiento
        '
        Me.txtFecMantenimiento.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecMantenimiento.DropDownCalendar.FirstMonth = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecMantenimiento.DropDownCalendar.Name = ""
        Me.txtFecMantenimiento.DropDownCalendar.Visible = False
        Me.txtFecMantenimiento.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecMantenimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecMantenimiento.IsNullDate = True
        Me.txtFecMantenimiento.Location = New System.Drawing.Point(487, 21)
        Me.txtFecMantenimiento.Name = "txtFecMantenimiento"
        Me.txtFecMantenimiento.NullButtonText = "Ninguno"
        Me.txtFecMantenimiento.ReadOnly = True
        Me.txtFecMantenimiento.ShowNullButton = True
        Me.txtFecMantenimiento.Size = New System.Drawing.Size(90, 21)
        Me.txtFecMantenimiento.TabIndex = 11
        Me.txtFecMantenimiento.TodayButtonText = "Hoy"
        Me.txtFecMantenimiento.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(369, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 15)
        Me.Label10.TabIndex = 402
        Me.Label10.Text = "Fec. Mant. Próximo"
        '
        'cbCalcAutomatico
        '
        Me.cbCalcAutomatico.AutoSize = True
        Me.cbCalcAutomatico.BackColor = System.Drawing.Color.Transparent
        Me.cbCalcAutomatico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbCalcAutomatico.Checked = True
        Me.cbCalcAutomatico.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCalcAutomatico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCalcAutomatico.Location = New System.Drawing.Point(7, 23)
        Me.cbCalcAutomatico.Name = "cbCalcAutomatico"
        Me.cbCalcAutomatico.Size = New System.Drawing.Size(117, 19)
        Me.cbCalcAutomatico.TabIndex = 9
        Me.cbCalcAutomatico.Text = "Calc. Automático"
        Me.cbCalcAutomatico.UseVisualStyleBackColor = False
        '
        'cbSwing
        '
        Me.cbSwing.AutoSize = True
        Me.cbSwing.BackColor = System.Drawing.Color.Transparent
        Me.cbSwing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbSwing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSwing.Location = New System.Drawing.Point(21, 62)
        Me.cbSwing.Name = "cbSwing"
        Me.cbSwing.Size = New System.Drawing.Size(60, 19)
        Me.cbSwing.TabIndex = 5
        Me.cbSwing.Text = "Swing"
        Me.cbSwing.UseVisualStyleBackColor = False
        '
        'txtFecFinGarantia
        '
        '
        '
        '
        Me.txtFecFinGarantia.DropDownCalendar.FirstMonth = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecFinGarantia.DropDownCalendar.Name = ""
        Me.txtFecFinGarantia.DropDownCalendar.Visible = False
        Me.txtFecFinGarantia.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinGarantia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinGarantia.Location = New System.Drawing.Point(247, 23)
        Me.txtFecFinGarantia.Name = "txtFecFinGarantia"
        Me.txtFecFinGarantia.NullButtonText = "Ninguno"
        Me.txtFecFinGarantia.Size = New System.Drawing.Size(90, 21)
        Me.txtFecFinGarantia.TabIndex = 3
        Me.txtFecFinGarantia.TodayButtonText = "Hoy"
        Me.txtFecFinGarantia.Value = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecFinGarantia.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(188, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 15)
        Me.Label2.TabIndex = 398
        Me.Label2.Text = "Fin"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(350, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 15)
        Me.Label7.TabIndex = 379
        Me.Label7.Text = "Tipo Plan Mant."
        '
        'cmbTipoPlanMant
        '
        Me.cmbTipoPlanMant.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoPlanMant_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoPlanMant_DesignTimeLayout.LayoutString")
        Me.cmbTipoPlanMant.DesignTimeLayout = cmbTipoPlanMant_DesignTimeLayout
        Me.cmbTipoPlanMant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPlanMant.Location = New System.Drawing.Point(449, 24)
        Me.cmbTipoPlanMant.Name = "cmbTipoPlanMant"
        Me.cmbTipoPlanMant.SelectedIndex = -1
        Me.cmbTipoPlanMant.SelectedItem = Nothing
        Me.cmbTipoPlanMant.Size = New System.Drawing.Size(129, 21)
        Me.cmbTipoPlanMant.TabIndex = 4
        Me.cmbTipoPlanMant.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 15)
        Me.Label13.TabIndex = 257
        Me.Label13.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(87, 50)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(490, 34)
        Me.txtObservacion.TabIndex = 12
        '
        'txtHrsDiarias
        '
        Me.txtHrsDiarias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHrsDiarias.Location = New System.Drawing.Point(176, 60)
        Me.txtHrsDiarias.MaxLength = 10
        Me.txtHrsDiarias.Name = "txtHrsDiarias"
        Me.txtHrsDiarias.Size = New System.Drawing.Size(45, 21)
        Me.txtHrsDiarias.TabIndex = 6
        Me.txtHrsDiarias.Text = "0.00"
        Me.txtHrsDiarias.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHrsDiarias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(103, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 404
        Me.Label3.Text = "Hrs. Diarias"
        '
        'txtHrsTotales
        '
        Me.txtHrsTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHrsTotales.Location = New System.Drawing.Point(324, 59)
        Me.txtHrsTotales.MaxLength = 10
        Me.txtHrsTotales.Name = "txtHrsTotales"
        Me.txtHrsTotales.Size = New System.Drawing.Size(79, 21)
        Me.txtHrsTotales.TabIndex = 7
        Me.txtHrsTotales.Text = "0.00"
        Me.txtHrsTotales.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHrsTotales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(246, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 406
        Me.Label1.Text = "Hrs. Totales"
        '
        'txtHrsParciales
        '
        Me.txtHrsParciales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHrsParciales.Location = New System.Drawing.Point(503, 59)
        Me.txtHrsParciales.MaxLength = 10
        Me.txtHrsParciales.Name = "txtHrsParciales"
        Me.txtHrsParciales.Size = New System.Drawing.Size(72, 21)
        Me.txtHrsParciales.TabIndex = 8
        Me.txtHrsParciales.Text = "0.00"
        Me.txtHrsParciales.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHrsParciales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(414, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 408
        Me.Label6.Text = "Hrs. Parciales"
        '
        'gbDatosHrsEquipo
        '
        Me.gbDatosHrsEquipo.Controls.Add(Me.cbDetenido)
        Me.gbDatosHrsEquipo.Controls.Add(Me.txtFecArranque)
        Me.gbDatosHrsEquipo.Controls.Add(Me.Label12)
        Me.gbDatosHrsEquipo.Controls.Add(Me.Label11)
        Me.gbDatosHrsEquipo.Controls.Add(Me.txtFecFinGarantia)
        Me.gbDatosHrsEquipo.Controls.Add(Me.txtHrsParciales)
        Me.gbDatosHrsEquipo.Controls.Add(Me.Label6)
        Me.gbDatosHrsEquipo.Controls.Add(Me.Label2)
        Me.gbDatosHrsEquipo.Controls.Add(Me.cbSwing)
        Me.gbDatosHrsEquipo.Controls.Add(Me.txtHrsTotales)
        Me.gbDatosHrsEquipo.Controls.Add(Me.Label1)
        Me.gbDatosHrsEquipo.Controls.Add(Me.txtHrsDiarias)
        Me.gbDatosHrsEquipo.Controls.Add(Me.Label3)
        Me.gbDatosHrsEquipo.Controls.Add(Me.cmbTipoPlanMant)
        Me.gbDatosHrsEquipo.Controls.Add(Me.Label7)
        Me.gbDatosHrsEquipo.Controls.Add(Me.Label15)
        Me.gbDatosHrsEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosHrsEquipo.Location = New System.Drawing.Point(10, 175)
        Me.gbDatosHrsEquipo.Name = "gbDatosHrsEquipo"
        Me.gbDatosHrsEquipo.Size = New System.Drawing.Size(586, 114)
        Me.gbDatosHrsEquipo.TabIndex = 1
        Me.gbDatosHrsEquipo.Text = "Hrs de recorrido de Motor"
        Me.gbDatosHrsEquipo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbDetenido
        '
        Me.cbDetenido.AutoSize = True
        Me.cbDetenido.BackColor = System.Drawing.Color.Transparent
        Me.cbDetenido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbDetenido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDetenido.Location = New System.Drawing.Point(21, 89)
        Me.cbDetenido.Name = "cbDetenido"
        Me.cbDetenido.Size = New System.Drawing.Size(76, 19)
        Me.cbDetenido.TabIndex = 411
        Me.cbDetenido.Text = "Detenido"
        Me.cbDetenido.UseVisualStyleBackColor = False
        '
        'txtFecArranque
        '
        '
        '
        '
        Me.txtFecArranque.DropDownCalendar.FirstMonth = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecArranque.DropDownCalendar.Name = ""
        Me.txtFecArranque.DropDownCalendar.Visible = False
        Me.txtFecArranque.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecArranque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecArranque.Location = New System.Drawing.Point(81, 24)
        Me.txtFecArranque.Name = "txtFecArranque"
        Me.txtFecArranque.NullButtonText = "Ninguno"
        Me.txtFecArranque.Size = New System.Drawing.Size(90, 21)
        Me.txtFecArranque.TabIndex = 2
        Me.txtFecArranque.TodayButtonText = "Hoy"
        Me.txtFecArranque.Value = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecArranque.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(187, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 15)
        Me.Label12.TabIndex = 410
        Me.Label12.Text = "Garantía"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 15)
        Me.Label11.TabIndex = 409
        Me.Label11.Text = "Fec."
        '
        'gbProximoMantenimiento
        '
        Me.gbProximoMantenimiento.Controls.Add(Me.txtObservacion)
        Me.gbProximoMantenimiento.Controls.Add(Me.Label17)
        Me.gbProximoMantenimiento.Controls.Add(Me.txtFecMantenimiento)
        Me.gbProximoMantenimiento.Controls.Add(Me.Label13)
        Me.gbProximoMantenimiento.Controls.Add(Me.Label10)
        Me.gbProximoMantenimiento.Controls.Add(Me.cbCalcAutomatico)
        Me.gbProximoMantenimiento.Controls.Add(Me.cmbPlanMant)
        Me.gbProximoMantenimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProximoMantenimiento.Location = New System.Drawing.Point(10, 297)
        Me.gbProximoMantenimiento.Name = "gbProximoMantenimiento"
        Me.gbProximoMantenimiento.Size = New System.Drawing.Size(586, 93)
        Me.gbProximoMantenimiento.TabIndex = 8
        Me.gbProximoMantenimiento.Text = "Próximo Mantenimiento"
        Me.gbProximoMantenimiento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbMantenimiento
        '
        Me.gbMantenimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMantenimiento.Controls.Add(Me.dgvDatos)
        Me.gbMantenimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMantenimiento.Location = New System.Drawing.Point(10, 396)
        Me.gbMantenimiento.Name = "gbMantenimiento"
        Me.gbMantenimiento.Size = New System.Drawing.Size(594, 170)
        Me.gbMantenimiento.TabIndex = 235
        Me.gbMantenimiento.Text = "Mantenimientos Realizados"
        Me.gbMantenimiento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 18)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(582, 146)
        Me.dgvDatos.TabIndex = 228
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        Me.ssBarra.Location = New System.Drawing.Point(0, 582)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(624, 20)
        Me.ssBarra.TabIndex = 236
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biEditar, Me.ToolStripSeparator4, Me.biDeshacer, Me.ToolStripSeparator6, Me.biCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(624, 31)
        Me.ToolStrip.TabIndex = 238
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
        'frmHoraMotor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(624, 602)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbMantenimiento)
        Me.Controls.Add(Me.gbDatosHrsEquipo)
        Me.Controls.Add(Me.gbProximoMantenimiento)
        Me.Controls.Add(Me.gbDatosEquipo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHoraMotor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Horas de recorrido de Motor"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosEquipo.ResumeLayout(False)
        Me.gbDatosEquipo.PerformLayout()
        CType(Me.cmbPlanMant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoPlanMant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosHrsEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosHrsEquipo.ResumeLayout(False)
        Me.gbDatosHrsEquipo.PerformLayout()
        CType(Me.gbProximoMantenimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProximoMantenimiento.ResumeLayout(False)
        Me.gbProximoMantenimiento.PerformLayout()
        CType(Me.gbMantenimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMantenimiento.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosEquipo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbPlanMant As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPlanMant As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbCalcAutomatico As System.Windows.Forms.CheckBox
    Friend WithEvents cbSwing As System.Windows.Forms.CheckBox
    Friend WithEvents txtFecFinGarantia As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFecMantenimiento As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtHrsParciales As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHrsTotales As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHrsDiarias As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbDatosHrsEquipo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtPotencia As System.Windows.Forms.TextBox
    Friend WithEvents txtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents txtModeloEquipo As System.Windows.Forms.TextBox
    Friend WithEvents txtModeloMotor As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoEquipo As System.Windows.Forms.TextBox
    Friend WithEvents gbProximoMantenimiento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbMantenimiento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents txtNombreEquipo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFecArranque As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnNumSerie As System.Windows.Forms.Button
    Friend WithEvents cbDetenido As System.Windows.Forms.CheckBox
End Class
