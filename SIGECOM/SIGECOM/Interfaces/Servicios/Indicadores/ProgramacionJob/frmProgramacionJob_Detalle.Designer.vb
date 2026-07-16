<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramacionJob_Detalle
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
        Dim dgvDatos_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramacionJob_Detalle))
        Dim dgvDatos_DesignTimeLayout_Reference_1 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column8.Image")
        Dim cmbTipMot_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarFecha = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbGastoViaje = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecInicioRep = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipMot = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditarr = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacerr = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtCostoReal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtHoraReal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtHoraPlan = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtCostoPlan = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblCostoPlan = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCostoReal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGastoViaje.SuspendLayout()
        CType(Me.cmbTipMot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDetalle
        '
        Me.gbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(4, 102)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(896, 295)
        Me.gbDetalle.TabIndex = 209
        Me.gbDetalle.Text = "Detalles"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatos_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatos_DesignTimeLayout_Reference_1.Instance = CType(resources.GetObject("dgvDatos_DesignTimeLayout_Reference_1.Instance"), Object)
        dgvDatos_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatos_DesignTimeLayout_Reference_0, dgvDatos_DesignTimeLayout_Reference_1})
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(6, 19)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(884, 270)
        Me.dgvDatos.TabIndex = 204
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMostrar, Me.ToolStripSeparator6, Me.miActualizarFecha, Me.ToolStripSeparator7, Me.miActualizar})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(161, 82)
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(160, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(157, 6)
        '
        'miActualizarFecha
        '
        Me.miActualizarFecha.Image = Global.SIGECOM.My.Resources.Resources.Fecha
        Me.miActualizarFecha.Name = "miActualizarFecha"
        Me.miActualizarFecha.Size = New System.Drawing.Size(160, 22)
        Me.miActualizarFecha.Text = "Actualizar Fecha"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(157, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(160, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'gbGastoViaje
        '
        Me.gbGastoViaje.Controls.Add(Me.txtFecInicioRep)
        Me.gbGastoViaje.Controls.Add(Me.Label1)
        Me.gbGastoViaje.Controls.Add(Me.txtNumJob)
        Me.gbGastoViaje.Controls.Add(Me.Label4)
        Me.gbGastoViaje.Controls.Add(Me.btnBuscarJob)
        Me.gbGastoViaje.Controls.Add(Me.Label2)
        Me.gbGastoViaje.Controls.Add(Me.cmbTipMot)
        Me.gbGastoViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGastoViaje.Location = New System.Drawing.Point(4, 33)
        Me.gbGastoViaje.Name = "gbGastoViaje"
        Me.gbGastoViaje.Size = New System.Drawing.Size(896, 65)
        Me.gbGastoViaje.TabIndex = 0
        Me.gbGastoViaje.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFecInicioRep
        '
        '
        '
        '
        Me.txtFecInicioRep.DropDownCalendar.Name = ""
        Me.txtFecInicioRep.DropDownCalendar.Visible = False
        Me.txtFecInicioRep.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicioRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecInicioRep.Location = New System.Drawing.Point(694, 27)
        Me.txtFecInicioRep.Name = "txtFecInicioRep"
        Me.txtFecInicioRep.NullButtonText = "Ninguno"
        Me.txtFecInicioRep.Size = New System.Drawing.Size(102, 20)
        Me.txtFecInicioRep.TabIndex = 4
        Me.txtFecInicioRep.TodayButtonText = "Hoy"
        Me.txtFecInicioRep.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "N° OT :"
        '
        'txtNumJob
        '
        Me.txtNumJob.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumJob.Location = New System.Drawing.Point(139, 28)
        Me.txtNumJob.MaxLength = 20
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(78, 20)
        Me.txtNumJob.TabIndex = 1
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(582, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Fec. Inicio Rep. :"
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(219, 27)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 120
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(314, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Tipo Motor :"
        '
        'cmbTipMot
        '
        Me.cmbTipMot.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipMot_DesignTimeLayout.LayoutString = resources.GetString("cmbTipMot_DesignTimeLayout.LayoutString")
        Me.cmbTipMot.DesignTimeLayout = cmbTipMot_DesignTimeLayout
        Me.cmbTipMot.Location = New System.Drawing.Point(396, 27)
        Me.cmbTipMot.Name = "cmbTipMot"
        Me.cmbTipMot.SelectedIndex = -1
        Me.cmbTipMot.SelectedItem = Nothing
        Me.cmbTipMot.Size = New System.Drawing.Size(128, 20)
        Me.cmbTipMot.TabIndex = 2
        Me.cmbTipMot.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbTipMot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biEditarr, Me.ToolStripSeparator4, Me.biDeshacerr, Me.ToolStripSeparator5, Me.biActualizar, Me.ToolStripSeparator1, Me.biCerrar})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(912, 31)
        Me.ToolStrip.TabIndex = 211
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
        Me.biEditarr.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator4.Visible = False
        '
        'biDeshacerr
        '
        Me.biDeshacerr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacerr.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacerr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacerr.Name = "biDeshacerr"
        Me.biDeshacerr.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacerr.Text = "Deshacer Cambios"
        Me.biDeshacerr.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator5.Visible = False
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
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
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 463)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(912, 20)
        Me.ssBarra.TabIndex = 213
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(320, 15)
        Me.sslError.Visible = False
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.sslTotal.Visible = False
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtCostoReal
        '
        Me.txtCostoReal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtCostoReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoReal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtCostoReal.Location = New System.Drawing.Point(727, 406)
        Me.txtCostoReal.MaxLength = 5
        Me.txtCostoReal.Name = "txtCostoReal"
        Me.txtCostoReal.ReadOnly = True
        Me.txtCostoReal.Size = New System.Drawing.Size(90, 20)
        Me.txtCostoReal.TabIndex = 214
        Me.txtCostoReal.TabStop = False
        Me.txtCostoReal.Text = "0.00"
        Me.txtCostoReal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCostoReal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostoReal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtHoraReal
        '
        Me.txtHoraReal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtHoraReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraReal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtHoraReal.Location = New System.Drawing.Point(727, 432)
        Me.txtHoraReal.MaxLength = 5
        Me.txtHoraReal.Name = "txtHoraReal"
        Me.txtHoraReal.ReadOnly = True
        Me.txtHoraReal.Size = New System.Drawing.Size(90, 20)
        Me.txtHoraReal.TabIndex = 215
        Me.txtHoraReal.TabStop = False
        Me.txtHoraReal.Text = "0.00"
        Me.txtHoraReal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtHoraReal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHoraReal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtHoraPlan
        '
        Me.txtHoraPlan.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtHoraPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraPlan.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtHoraPlan.Location = New System.Drawing.Point(489, 432)
        Me.txtHoraPlan.MaxLength = 5
        Me.txtHoraPlan.Name = "txtHoraPlan"
        Me.txtHoraPlan.ReadOnly = True
        Me.txtHoraPlan.Size = New System.Drawing.Size(90, 20)
        Me.txtHoraPlan.TabIndex = 217
        Me.txtHoraPlan.TabStop = False
        Me.txtHoraPlan.Text = "0.00"
        Me.txtHoraPlan.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtHoraPlan.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHoraPlan.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCostoPlan
        '
        Me.txtCostoPlan.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtCostoPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoPlan.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtCostoPlan.Location = New System.Drawing.Point(489, 406)
        Me.txtCostoPlan.MaxLength = 5
        Me.txtCostoPlan.Name = "txtCostoPlan"
        Me.txtCostoPlan.ReadOnly = True
        Me.txtCostoPlan.Size = New System.Drawing.Size(90, 20)
        Me.txtCostoPlan.TabIndex = 216
        Me.txtCostoPlan.TabStop = False
        Me.txtCostoPlan.Text = "0.00"
        Me.txtCostoPlan.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCostoPlan.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostoPlan.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblCostoPlan
        '
        Me.lblCostoPlan.AutoSize = True
        Me.lblCostoPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoPlan.Location = New System.Drawing.Point(319, 408)
        Me.lblCostoPlan.Name = "lblCostoPlan"
        Me.lblCostoPlan.Size = New System.Drawing.Size(144, 15)
        Me.lblCostoPlan.TabIndex = 218
        Me.lblCostoPlan.Text = "Total Costo Planeado"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(318, 434)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 15)
        Me.Label5.TabIndex = 219
        Me.Label5.Text = "Total Horas Planeada"
        '
        'lblCostoReal
        '
        Me.lblCostoReal.AutoSize = True
        Me.lblCostoReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoReal.Location = New System.Drawing.Point(585, 408)
        Me.lblCostoReal.Name = "lblCostoReal"
        Me.lblCostoReal.Size = New System.Drawing.Size(113, 15)
        Me.lblCostoReal.TabIndex = 220
        Me.lblCostoReal.Text = "Total Costo Real"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(585, 434)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 15)
        Me.Label7.TabIndex = 221
        Me.Label7.Text = "Total Horas Real"
        '
        'frmProgramacionJob_Detalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(912, 483)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblCostoReal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCostoPlan)
        Me.Controls.Add(Me.txtHoraPlan)
        Me.Controls.Add(Me.txtCostoPlan)
        Me.Controls.Add(Me.txtHoraReal)
        Me.Controls.Add(Me.txtCostoReal)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbGastoViaje)
        Me.Controls.Add(Me.gbDetalle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProgramacionJob_Detalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programacion OT Detalle"
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGastoViaje.ResumeLayout(False)
        Me.gbGastoViaje.PerformLayout()
        CType(Me.cmbTipMot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbGastoViaje As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipMot As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditarr As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtFecInicioRep As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents biDeshacerr As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents miActualizarFecha As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents txtHoraReal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtCostoReal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblCostoReal As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblCostoPlan As Label
    Friend WithEvents txtHoraPlan As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtCostoPlan As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
