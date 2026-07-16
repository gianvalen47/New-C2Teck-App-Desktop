<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPlanillaVarColaborador
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillaVarColaborador))
        Dim dgvIngresos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDsctos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvHrsExtras_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvAportaciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvCTS_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvGrati_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvVaca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.TabVariables = New Janus.Windows.UI.Tab.UITab()
        Me.tpVariables = New Janus.Windows.UI.Tab.UITabPage()
        Me.ckPagado = New System.Windows.Forms.CheckBox()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalNetoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalNetoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnDeshacer = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbHoras = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtHorasReales = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbMonto = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtMontoMovil = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gbDias = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtDiasMovilidad = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDiasPago = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDiasPDT = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDiasReales = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbFechasVacacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtVacacionFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtVacacionIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tpIngresos = New Janus.Windows.UI.Tab.UITabPage()
        Me.lblTotalesIng = New System.Windows.Forms.TextBox()
        Me.txtTotalUSIng = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalNSIng = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvIngresos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesIngresos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miReprocesarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpDescuentos = New Janus.Windows.UI.Tab.UITabPage()
        Me.lblTotalesDsctos = New System.Windows.Forms.TextBox()
        Me.txtTotalUSDsctos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalNSDsctos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvDsctos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesDsctos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.miReprocesarDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarDscto = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpHorasExtras = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvHrsExtras = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesHrsExtras = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoHrsExtras = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarHrsExtras = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarHrsExtras = New System.Windows.Forms.ToolStripMenuItem()
        Me.miReprocesarHrsExtras = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarHrsExtras = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpAportaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.txtTotalNSAport = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalesAport = New System.Windows.Forms.TextBox()
        Me.txtTotalUSAport = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvAportaciones = New Janus.Windows.GridEX.GridEX()
        Me.tpCTS = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalNSCTS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtTotalUSCTS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvCTS = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesCTS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mbNuevoCts = New System.Windows.Forms.ToolStripMenuItem()
        Me.mbMostrarCts = New System.Windows.Forms.ToolStripMenuItem()
        Me.mbEliminarCts = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mbRefrescarCts = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpGrati = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox7 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalNSGrati = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtTotalUSGrati = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvGrati = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesGrati = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoGrati = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarGrati = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarGrati = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarGrati = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpVaca = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox8 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalNSVaca = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.txtTotalUSVaca = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvVaca = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesVaca = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoVaca = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarVaca = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarVaca = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.miRefrescarVaca = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.txtIdPlanilla = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.TabVariables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabVariables.SuspendLayout()
        Me.tpVariables.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.gbHoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbHoras.SuspendLayout()
        CType(Me.gbMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMonto.SuspendLayout()
        CType(Me.gbDias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDias.SuspendLayout()
        CType(Me.gbFechasVacacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFechasVacacion.SuspendLayout()
        Me.tpIngresos.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.dgvIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesIngresos.SuspendLayout()
        Me.tpDescuentos.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.dgvDsctos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesDsctos.SuspendLayout()
        Me.tpHorasExtras.SuspendLayout()
        CType(Me.dgvHrsExtras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesHrsExtras.SuspendLayout()
        Me.tpAportaciones.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAportaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCTS.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        CType(Me.dgvCTS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesCTS.SuspendLayout()
        Me.tpGrati.SuspendLayout()
        CType(Me.UiGroupBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox7.SuspendLayout()
        CType(Me.dgvGrati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesGrati.SuspendLayout()
        Me.tpVaca.SuspendLayout()
        CType(Me.UiGroupBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox8.SuspendLayout()
        CType(Me.dgvVaca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesVaca.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabVariables
        '
        Me.TabVariables.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabVariables.Location = New System.Drawing.Point(6, 52)
        Me.TabVariables.Name = "TabVariables"
        Me.TabVariables.Size = New System.Drawing.Size(540, 292)
        Me.TabVariables.TabIndex = 188
        Me.TabVariables.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tpVariables, Me.tpIngresos, Me.tpDescuentos, Me.tpHorasExtras, Me.tpAportaciones, Me.tpCTS, Me.tpGrati, Me.tpVaca})
        Me.TabVariables.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'tpVariables
        '
        Me.tpVariables.Controls.Add(Me.ckPagado)
        Me.tpVariables.Controls.Add(Me.UiGroupBox3)
        Me.tpVariables.Controls.Add(Me.btnDeshacer)
        Me.tpVariables.Controls.Add(Me.btnEditar)
        Me.tpVariables.Controls.Add(Me.btnGuardar)
        Me.tpVariables.Controls.Add(Me.gbHoras)
        Me.tpVariables.Controls.Add(Me.gbMonto)
        Me.tpVariables.Controls.Add(Me.gbDias)
        Me.tpVariables.Controls.Add(Me.gbFechasVacacion)
        Me.tpVariables.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpVariables.Icon = CType(resources.GetObject("tpVariables.Icon"), System.Drawing.Icon)
        Me.tpVariables.Location = New System.Drawing.Point(1, 23)
        Me.tpVariables.Name = "tpVariables"
        Me.tpVariables.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tpVariables.Size = New System.Drawing.Size(522, 268)
        Me.tpVariables.TabStop = True
        Me.tpVariables.Text = "VARIABLES"
        '
        'ckPagado
        '
        Me.ckPagado.AutoSize = True
        Me.ckPagado.BackColor = System.Drawing.SystemColors.Control
        Me.ckPagado.Location = New System.Drawing.Point(421, 11)
        Me.ckPagado.Name = "ckPagado"
        Me.ckPagado.Size = New System.Drawing.Size(69, 17)
        Me.ckPagado.TabIndex = 232
        Me.ckPagado.Text = "Pagado?"
        Me.ckPagado.UseVisualStyleBackColor = False
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox3.Controls.Add(Me.txtTotalNetoSol)
        Me.UiGroupBox3.Controls.Add(Me.Label8)
        Me.UiGroupBox3.Controls.Add(Me.Label9)
        Me.UiGroupBox3.Controls.Add(Me.txtTotalNetoDol)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(33, 214)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(457, 45)
        Me.UiGroupBox3.TabIndex = 231
        Me.UiGroupBox3.Text = "Totales Netos"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalNetoSol
        '
        Me.txtTotalNetoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNetoSol.Location = New System.Drawing.Point(105, 17)
        Me.txtTotalNetoSol.MaxLength = 10
        Me.txtTotalNetoSol.Name = "txtTotalNetoSol"
        Me.txtTotalNetoSol.ReadOnly = True
        Me.txtTotalNetoSol.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalNetoSol.TabIndex = 229
        Me.txtTotalNetoSol.Text = "0.00"
        Me.txtTotalNetoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNetoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(268, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 15)
        Me.Label8.TabIndex = 228
        Me.Label8.Text = "Total Neto $/."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(23, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 15)
        Me.Label9.TabIndex = 230
        Me.Label9.Text = "Total Neto S/."
        '
        'txtTotalNetoDol
        '
        Me.txtTotalNetoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNetoDol.Location = New System.Drawing.Point(349, 17)
        Me.txtTotalNetoDol.MaxLength = 10
        Me.txtTotalNetoDol.Name = "txtTotalNetoDol"
        Me.txtTotalNetoDol.ReadOnly = True
        Me.txtTotalNetoDol.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalNetoDol.TabIndex = 227
        Me.txtTotalNetoDol.Text = "0.00"
        Me.txtTotalNetoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNetoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnDeshacer
        '
        Me.btnDeshacer.BackColor = System.Drawing.Color.Transparent
        Me.btnDeshacer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnDeshacer.Location = New System.Drawing.Point(106, 4)
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.btnDeshacer.TabIndex = 226
        Me.btnDeshacer.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.Transparent
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnEditar.Location = New System.Drawing.Point(18, 4)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(28, 28)
        Me.btnEditar.TabIndex = 225
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(63, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.TabIndex = 224
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'gbHoras
        '
        Me.gbHoras.BackColor = System.Drawing.Color.Transparent
        Me.gbHoras.Controls.Add(Me.txtHorasReales)
        Me.gbHoras.Controls.Add(Me.Label7)
        Me.gbHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbHoras.Location = New System.Drawing.Point(275, 101)
        Me.gbHoras.Name = "gbHoras"
        Me.gbHoras.Size = New System.Drawing.Size(215, 56)
        Me.gbHoras.TabIndex = 51
        Me.gbHoras.Text = "Horas"
        Me.gbHoras.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtHorasReales
        '
        Me.txtHorasReales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorasReales.Location = New System.Drawing.Point(110, 21)
        Me.txtHorasReales.MaxLength = 10
        Me.txtHorasReales.Name = "txtHorasReales"
        Me.txtHorasReales.Size = New System.Drawing.Size(65, 20)
        Me.txtHorasReales.TabIndex = 36
        Me.txtHorasReales.Text = "0.00"
        Me.txtHorasReales.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHorasReales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(42, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Hrs. Reales"
        '
        'gbMonto
        '
        Me.gbMonto.BackColor = System.Drawing.Color.Transparent
        Me.gbMonto.Controls.Add(Me.txtMontoMovil)
        Me.gbMonto.Controls.Add(Me.Label10)
        Me.gbMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMonto.Location = New System.Drawing.Point(275, 35)
        Me.gbMonto.Name = "gbMonto"
        Me.gbMonto.Size = New System.Drawing.Size(215, 56)
        Me.gbMonto.TabIndex = 50
        Me.gbMonto.Text = "Montos"
        Me.gbMonto.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtMontoMovil
        '
        Me.txtMontoMovil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoMovil.Location = New System.Drawing.Point(110, 21)
        Me.txtMontoMovil.MaxLength = 10
        Me.txtMontoMovil.Name = "txtMontoMovil"
        Me.txtMontoMovil.Size = New System.Drawing.Size(85, 20)
        Me.txtMontoMovil.TabIndex = 40
        Me.txtMontoMovil.Text = "0.00"
        Me.txtMontoMovil.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoMovil.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Monto Movilidad"
        '
        'gbDias
        '
        Me.gbDias.BackColor = System.Drawing.Color.Transparent
        Me.gbDias.Controls.Add(Me.txtDiasMovilidad)
        Me.gbDias.Controls.Add(Me.Label3)
        Me.gbDias.Controls.Add(Me.txtDiasPago)
        Me.gbDias.Controls.Add(Me.Label4)
        Me.gbDias.Controls.Add(Me.txtDiasPDT)
        Me.gbDias.Controls.Add(Me.Label5)
        Me.gbDias.Controls.Add(Me.txtDiasReales)
        Me.gbDias.Controls.Add(Me.Label6)
        Me.gbDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDias.Location = New System.Drawing.Point(33, 35)
        Me.gbDias.Name = "gbDias"
        Me.gbDias.Size = New System.Drawing.Size(205, 122)
        Me.gbDias.TabIndex = 49
        Me.gbDias.Text = "Días"
        Me.gbDias.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtDiasMovilidad
        '
        Me.txtDiasMovilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasMovilidad.Location = New System.Drawing.Point(105, 15)
        Me.txtDiasMovilidad.Maximum = 90
        Me.txtDiasMovilidad.MaxLength = 2
        Me.txtDiasMovilidad.Name = "txtDiasMovilidad"
        Me.txtDiasMovilidad.Size = New System.Drawing.Size(61, 20)
        Me.txtDiasMovilidad.TabIndex = 2
        Me.txtDiasMovilidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDiasMovilidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Movilidad"
        '
        'txtDiasPago
        '
        Me.txtDiasPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasPago.Location = New System.Drawing.Point(105, 67)
        Me.txtDiasPago.Maximum = 32
        Me.txtDiasPago.MaxLength = 2
        Me.txtDiasPago.Name = "txtDiasPago"
        Me.txtDiasPago.Size = New System.Drawing.Size(61, 20)
        Me.txtDiasPago.TabIndex = 4
        Me.txtDiasPago.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDiasPago.Value = 1
        Me.txtDiasPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(33, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Pago"
        '
        'txtDiasPDT
        '
        Me.txtDiasPDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasPDT.Location = New System.Drawing.Point(105, 41)
        Me.txtDiasPDT.Maximum = 90
        Me.txtDiasPDT.MaxLength = 2
        Me.txtDiasPDT.Name = "txtDiasPDT"
        Me.txtDiasPDT.Size = New System.Drawing.Size(61, 20)
        Me.txtDiasPDT.TabIndex = 6
        Me.txtDiasPDT.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDiasPDT.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "PDT"
        '
        'txtDiasReales
        '
        Me.txtDiasReales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasReales.Location = New System.Drawing.Point(105, 93)
        Me.txtDiasReales.Maximum = 32
        Me.txtDiasReales.MaxLength = 2
        Me.txtDiasReales.Name = "txtDiasReales"
        Me.txtDiasReales.Size = New System.Drawing.Size(61, 20)
        Me.txtDiasReales.TabIndex = 8
        Me.txtDiasReales.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDiasReales.Value = 1
        Me.txtDiasReales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(33, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Reales"
        '
        'gbFechasVacacion
        '
        Me.gbFechasVacacion.BackColor = System.Drawing.Color.Transparent
        Me.gbFechasVacacion.Controls.Add(Me.txtVacacionFin)
        Me.gbFechasVacacion.Controls.Add(Me.Label13)
        Me.gbFechasVacacion.Controls.Add(Me.txtVacacionIni)
        Me.gbFechasVacacion.Controls.Add(Me.Label12)
        Me.gbFechasVacacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFechasVacacion.Location = New System.Drawing.Point(33, 163)
        Me.gbFechasVacacion.Name = "gbFechasVacacion"
        Me.gbFechasVacacion.Size = New System.Drawing.Size(457, 45)
        Me.gbFechasVacacion.TabIndex = 48
        Me.gbFechasVacacion.Text = "Vacaciones"
        Me.gbFechasVacacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtVacacionFin
        '
        '
        '
        '
        Me.txtVacacionFin.DropDownCalendar.Name = ""
        Me.txtVacacionFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtVacacionFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVacacionFin.IsNullDate = True
        Me.txtVacacionFin.Location = New System.Drawing.Point(349, 17)
        Me.txtVacacionFin.Name = "txtVacacionFin"
        Me.txtVacacionFin.NullButtonText = "Ninguno"
        Me.txtVacacionFin.ShowNullButton = True
        Me.txtVacacionFin.Size = New System.Drawing.Size(86, 20)
        Me.txtVacacionFin.TabIndex = 46
        Me.txtVacacionFin.TodayButtonText = "Hoy"
        Me.txtVacacionFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(265, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "Fec. Fin Vacac."
        '
        'txtVacacionIni
        '
        '
        '
        '
        Me.txtVacacionIni.DropDownCalendar.Name = ""
        Me.txtVacacionIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtVacacionIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVacacionIni.IsNullDate = True
        Me.txtVacacionIni.Location = New System.Drawing.Point(105, 17)
        Me.txtVacacionIni.Name = "txtVacacionIni"
        Me.txtVacacionIni.NullButtonText = "Ninguno"
        Me.txtVacacionIni.ShowNullButton = True
        Me.txtVacacionIni.Size = New System.Drawing.Size(86, 20)
        Me.txtVacacionIni.TabIndex = 44
        Me.txtVacacionIni.TodayButtonText = "Hoy"
        Me.txtVacacionIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(21, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Fec. Ini. Vacac."
        '
        'tpIngresos
        '
        Me.tpIngresos.Controls.Add(Me.lblTotalesIng)
        Me.tpIngresos.Controls.Add(Me.txtTotalUSIng)
        Me.tpIngresos.Controls.Add(Me.UiGroupBox2)
        Me.tpIngresos.Controls.Add(Me.dgvIngresos)
        Me.tpIngresos.Icon = CType(resources.GetObject("tpIngresos.Icon"), System.Drawing.Icon)
        Me.tpIngresos.Location = New System.Drawing.Point(1, 23)
        Me.tpIngresos.Name = "tpIngresos"
        Me.tpIngresos.Size = New System.Drawing.Size(513, 268)
        Me.tpIngresos.TabStop = True
        Me.tpIngresos.Text = "INGRESOS"
        '
        'lblTotalesIng
        '
        Me.lblTotalesIng.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalesIng.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalesIng.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalesIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalesIng.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalesIng.Location = New System.Drawing.Point(38, 224)
        Me.lblTotalesIng.MaxLength = 20
        Me.lblTotalesIng.Name = "lblTotalesIng"
        Me.lblTotalesIng.ReadOnly = True
        Me.lblTotalesIng.Size = New System.Drawing.Size(254, 20)
        Me.lblTotalesIng.TabIndex = 218
        Me.lblTotalesIng.TabStop = False
        Me.lblTotalesIng.Text = "TOTALES :"
        Me.lblTotalesIng.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalUSIng
        '
        Me.txtTotalUSIng.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalUSIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalUSIng.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalUSIng.Location = New System.Drawing.Point(386, 224)
        Me.txtTotalUSIng.MaxLength = 5
        Me.txtTotalUSIng.Name = "txtTotalUSIng"
        Me.txtTotalUSIng.ReadOnly = True
        Me.txtTotalUSIng.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalUSIng.TabIndex = 217
        Me.txtTotalUSIng.TabStop = False
        Me.txtTotalUSIng.Text = "0.00"
        Me.txtTotalUSIng.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalUSIng.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalUSIng.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox2.Controls.Add(Me.txtTotalNSIng)
        Me.UiGroupBox2.Location = New System.Drawing.Point(22, 212)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(478, 37)
        Me.UiGroupBox2.TabIndex = 219
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalNSIng
        '
        Me.txtTotalNSIng.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNSIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNSIng.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNSIng.Location = New System.Drawing.Point(269, 12)
        Me.txtTotalNSIng.MaxLength = 5
        Me.txtTotalNSIng.Name = "txtTotalNSIng"
        Me.txtTotalNSIng.ReadOnly = True
        Me.txtTotalNSIng.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalNSIng.TabIndex = 6
        Me.txtTotalNSIng.TabStop = False
        Me.txtTotalNSIng.Text = "0.00"
        Me.txtTotalNSIng.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNSIng.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNSIng.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvIngresos
        '
        Me.dgvIngresos.ContextMenuStrip = Me.cmOpcionesIngresos
        dgvIngresos_DesignTimeLayout.LayoutString = resources.GetString("dgvIngresos_DesignTimeLayout.LayoutString")
        Me.dgvIngresos.DesignTimeLayout = dgvIngresos_DesignTimeLayout
        Me.dgvIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvIngresos.GroupByBoxVisible = False
        Me.dgvIngresos.Location = New System.Drawing.Point(22, 27)
        Me.dgvIngresos.Name = "dgvIngresos"
        Me.dgvIngresos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvIngresos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvIngresos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvIngresos.Size = New System.Drawing.Size(478, 179)
        Me.dgvIngresos.TabIndex = 2
        Me.dgvIngresos.TabStop = False
        Me.dgvIngresos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpcionesIngresos
        '
        Me.cmOpcionesIngresos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoIng, Me.miMostrarIng, Me.miEliminarIng, Me.miReprocesarIng, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizarIng})
        Me.cmOpcionesIngresos.Name = "cmOpciones"
        Me.cmOpcionesIngresos.Size = New System.Drawing.Size(133, 126)
        '
        'miNuevoIng
        '
        Me.miNuevoIng.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoIng.Name = "miNuevoIng"
        Me.miNuevoIng.Size = New System.Drawing.Size(132, 22)
        Me.miNuevoIng.Text = "Nuevo"
        Me.miNuevoIng.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarIng
        '
        Me.miMostrarIng.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarIng.Name = "miMostrarIng"
        Me.miMostrarIng.Size = New System.Drawing.Size(132, 22)
        Me.miMostrarIng.Text = "Mostrar"
        '
        'miEliminarIng
        '
        Me.miEliminarIng.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarIng.Name = "miEliminarIng"
        Me.miEliminarIng.Size = New System.Drawing.Size(132, 22)
        Me.miEliminarIng.Text = "Eliminar"
        Me.miEliminarIng.ToolTipText = "Eliminar Detalle"
        '
        'miReprocesarIng
        '
        Me.miReprocesarIng.Image = Global.SIGECOM.My.Resources.Resources.Recalcular
        Me.miReprocesarIng.Name = "miReprocesarIng"
        Me.miReprocesarIng.Size = New System.Drawing.Size(132, 22)
        Me.miReprocesarIng.Text = "Reprocesar"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(129, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(129, 6)
        '
        'miActualizarIng
        '
        Me.miActualizarIng.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarIng.Name = "miActualizarIng"
        Me.miActualizarIng.Size = New System.Drawing.Size(132, 22)
        Me.miActualizarIng.Text = "Actualizar"
        Me.miActualizarIng.ToolTipText = "Refrescar Lista Detalles"
        '
        'tpDescuentos
        '
        Me.tpDescuentos.Controls.Add(Me.lblTotalesDsctos)
        Me.tpDescuentos.Controls.Add(Me.txtTotalUSDsctos)
        Me.tpDescuentos.Controls.Add(Me.UiGroupBox6)
        Me.tpDescuentos.Controls.Add(Me.dgvDsctos)
        Me.tpDescuentos.Icon = CType(resources.GetObject("tpDescuentos.Icon"), System.Drawing.Icon)
        Me.tpDescuentos.Location = New System.Drawing.Point(1, 23)
        Me.tpDescuentos.Name = "tpDescuentos"
        Me.tpDescuentos.Size = New System.Drawing.Size(513, 268)
        Me.tpDescuentos.TabStop = True
        Me.tpDescuentos.Text = "DSCTOS"
        '
        'lblTotalesDsctos
        '
        Me.lblTotalesDsctos.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalesDsctos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalesDsctos.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalesDsctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalesDsctos.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalesDsctos.Location = New System.Drawing.Point(38, 224)
        Me.lblTotalesDsctos.MaxLength = 20
        Me.lblTotalesDsctos.Name = "lblTotalesDsctos"
        Me.lblTotalesDsctos.ReadOnly = True
        Me.lblTotalesDsctos.Size = New System.Drawing.Size(254, 20)
        Me.lblTotalesDsctos.TabIndex = 10
        Me.lblTotalesDsctos.TabStop = False
        Me.lblTotalesDsctos.Text = "TOTALES :"
        Me.lblTotalesDsctos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalUSDsctos
        '
        Me.txtTotalUSDsctos.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalUSDsctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalUSDsctos.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalUSDsctos.Location = New System.Drawing.Point(386, 224)
        Me.txtTotalUSDsctos.MaxLength = 5
        Me.txtTotalUSDsctos.Name = "txtTotalUSDsctos"
        Me.txtTotalUSDsctos.ReadOnly = True
        Me.txtTotalUSDsctos.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalUSDsctos.TabIndex = 7
        Me.txtTotalUSDsctos.TabStop = False
        Me.txtTotalUSDsctos.Text = "0.00"
        Me.txtTotalUSDsctos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalUSDsctos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalUSDsctos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtTotalNSDsctos)
        Me.UiGroupBox6.Location = New System.Drawing.Point(22, 212)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(478, 37)
        Me.UiGroupBox6.TabIndex = 216
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalNSDsctos
        '
        Me.txtTotalNSDsctos.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNSDsctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNSDsctos.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNSDsctos.Location = New System.Drawing.Point(269, 12)
        Me.txtTotalNSDsctos.MaxLength = 5
        Me.txtTotalNSDsctos.Name = "txtTotalNSDsctos"
        Me.txtTotalNSDsctos.ReadOnly = True
        Me.txtTotalNSDsctos.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalNSDsctos.TabIndex = 6
        Me.txtTotalNSDsctos.TabStop = False
        Me.txtTotalNSDsctos.Text = "0.00"
        Me.txtTotalNSDsctos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNSDsctos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNSDsctos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvDsctos
        '
        Me.dgvDsctos.ContextMenuStrip = Me.cmOpcionesDsctos
        dgvDsctos_DesignTimeLayout.LayoutString = resources.GetString("dgvDsctos_DesignTimeLayout.LayoutString")
        Me.dgvDsctos.DesignTimeLayout = dgvDsctos_DesignTimeLayout
        Me.dgvDsctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDsctos.GroupByBoxVisible = False
        Me.dgvDsctos.Location = New System.Drawing.Point(22, 27)
        Me.dgvDsctos.Name = "dgvDsctos"
        Me.dgvDsctos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDsctos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDsctos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDsctos.Size = New System.Drawing.Size(478, 179)
        Me.dgvDsctos.TabIndex = 3
        Me.dgvDsctos.TabStop = False
        Me.dgvDsctos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpcionesDsctos
        '
        Me.cmOpcionesDsctos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoDscto, Me.miMostrarDscto, Me.miEliminarDscto, Me.miReprocesarDscto, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.miActualizarDscto})
        Me.cmOpcionesDsctos.Name = "cmOpciones"
        Me.cmOpcionesDsctos.Size = New System.Drawing.Size(133, 126)
        '
        'miNuevoDscto
        '
        Me.miNuevoDscto.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoDscto.Name = "miNuevoDscto"
        Me.miNuevoDscto.Size = New System.Drawing.Size(132, 22)
        Me.miNuevoDscto.Text = "Nuevo"
        Me.miNuevoDscto.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarDscto
        '
        Me.miMostrarDscto.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarDscto.Name = "miMostrarDscto"
        Me.miMostrarDscto.Size = New System.Drawing.Size(132, 22)
        Me.miMostrarDscto.Text = "Mostrar"
        '
        'miEliminarDscto
        '
        Me.miEliminarDscto.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarDscto.Name = "miEliminarDscto"
        Me.miEliminarDscto.Size = New System.Drawing.Size(132, 22)
        Me.miEliminarDscto.Text = "Eliminar"
        Me.miEliminarDscto.ToolTipText = "Eliminar Detalle"
        '
        'miReprocesarDscto
        '
        Me.miReprocesarDscto.Image = Global.SIGECOM.My.Resources.Resources.Recalcular
        Me.miReprocesarDscto.Name = "miReprocesarDscto"
        Me.miReprocesarDscto.Size = New System.Drawing.Size(132, 22)
        Me.miReprocesarDscto.Text = "Reprocesar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(129, 6)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(129, 6)
        '
        'miActualizarDscto
        '
        Me.miActualizarDscto.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarDscto.Name = "miActualizarDscto"
        Me.miActualizarDscto.Size = New System.Drawing.Size(132, 22)
        Me.miActualizarDscto.Text = "Actualizar"
        Me.miActualizarDscto.ToolTipText = "Refrescar Lista Detalles"
        '
        'tpHorasExtras
        '
        Me.tpHorasExtras.Controls.Add(Me.dgvHrsExtras)
        Me.tpHorasExtras.Icon = CType(resources.GetObject("tpHorasExtras.Icon"), System.Drawing.Icon)
        Me.tpHorasExtras.Location = New System.Drawing.Point(1, 23)
        Me.tpHorasExtras.Name = "tpHorasExtras"
        Me.tpHorasExtras.Size = New System.Drawing.Size(522, 268)
        Me.tpHorasExtras.TabStop = True
        Me.tpHorasExtras.Text = "HRS EXTRAS"
        '
        'dgvHrsExtras
        '
        Me.dgvHrsExtras.ContextMenuStrip = Me.cmOpcionesHrsExtras
        dgvHrsExtras_DesignTimeLayout.LayoutString = resources.GetString("dgvHrsExtras_DesignTimeLayout.LayoutString")
        Me.dgvHrsExtras.DesignTimeLayout = dgvHrsExtras_DesignTimeLayout
        Me.dgvHrsExtras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvHrsExtras.GroupByBoxVisible = False
        Me.dgvHrsExtras.Location = New System.Drawing.Point(22, 27)
        Me.dgvHrsExtras.Name = "dgvHrsExtras"
        Me.dgvHrsExtras.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvHrsExtras.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvHrsExtras.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvHrsExtras.Size = New System.Drawing.Size(478, 216)
        Me.dgvHrsExtras.TabIndex = 4
        Me.dgvHrsExtras.TabStop = False
        Me.dgvHrsExtras.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpcionesHrsExtras
        '
        Me.cmOpcionesHrsExtras.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoHrsExtras, Me.miMostrarHrsExtras, Me.miEliminarHrsExtras, Me.miReprocesarHrsExtras, Me.ToolStripSeparator3, Me.ToolStripSeparator4, Me.miActualizarHrsExtras})
        Me.cmOpcionesHrsExtras.Name = "cmOpciones"
        Me.cmOpcionesHrsExtras.Size = New System.Drawing.Size(133, 126)
        '
        'miNuevoHrsExtras
        '
        Me.miNuevoHrsExtras.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoHrsExtras.Name = "miNuevoHrsExtras"
        Me.miNuevoHrsExtras.Size = New System.Drawing.Size(132, 22)
        Me.miNuevoHrsExtras.Text = "Nuevo"
        Me.miNuevoHrsExtras.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarHrsExtras
        '
        Me.miMostrarHrsExtras.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarHrsExtras.Name = "miMostrarHrsExtras"
        Me.miMostrarHrsExtras.Size = New System.Drawing.Size(132, 22)
        Me.miMostrarHrsExtras.Text = "Mostrar"
        '
        'miEliminarHrsExtras
        '
        Me.miEliminarHrsExtras.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarHrsExtras.Name = "miEliminarHrsExtras"
        Me.miEliminarHrsExtras.Size = New System.Drawing.Size(132, 22)
        Me.miEliminarHrsExtras.Text = "Eliminar"
        Me.miEliminarHrsExtras.ToolTipText = "Eliminar Detalle"
        '
        'miReprocesarHrsExtras
        '
        Me.miReprocesarHrsExtras.Image = Global.SIGECOM.My.Resources.Resources.Recalcular
        Me.miReprocesarHrsExtras.Name = "miReprocesarHrsExtras"
        Me.miReprocesarHrsExtras.Size = New System.Drawing.Size(132, 22)
        Me.miReprocesarHrsExtras.Text = "Reprocesar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(129, 6)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(129, 6)
        '
        'miActualizarHrsExtras
        '
        Me.miActualizarHrsExtras.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarHrsExtras.Name = "miActualizarHrsExtras"
        Me.miActualizarHrsExtras.Size = New System.Drawing.Size(132, 22)
        Me.miActualizarHrsExtras.Text = "Actualizar"
        Me.miActualizarHrsExtras.ToolTipText = "Refrescar Lista Detalles"
        '
        'tpAportaciones
        '
        Me.tpAportaciones.Controls.Add(Me.txtTotalNSAport)
        Me.tpAportaciones.Controls.Add(Me.lblTotalesAport)
        Me.tpAportaciones.Controls.Add(Me.txtTotalUSAport)
        Me.tpAportaciones.Controls.Add(Me.UiGroupBox4)
        Me.tpAportaciones.Controls.Add(Me.dgvAportaciones)
        Me.tpAportaciones.Icon = CType(resources.GetObject("tpAportaciones.Icon"), System.Drawing.Icon)
        Me.tpAportaciones.Location = New System.Drawing.Point(1, 23)
        Me.tpAportaciones.Name = "tpAportaciones"
        Me.tpAportaciones.Size = New System.Drawing.Size(523, 268)
        Me.tpAportaciones.TabStop = True
        Me.tpAportaciones.Text = "APORTACIONES"
        '
        'txtTotalNSAport
        '
        Me.txtTotalNSAport.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNSAport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNSAport.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNSAport.Location = New System.Drawing.Point(291, 224)
        Me.txtTotalNSAport.MaxLength = 5
        Me.txtTotalNSAport.Name = "txtTotalNSAport"
        Me.txtTotalNSAport.ReadOnly = True
        Me.txtTotalNSAport.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalNSAport.TabIndex = 7
        Me.txtTotalNSAport.TabStop = False
        Me.txtTotalNSAport.Text = "0.00"
        Me.txtTotalNSAport.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNSAport.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNSAport.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotalesAport
        '
        Me.lblTotalesAport.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalesAport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalesAport.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalesAport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalesAport.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalesAport.Location = New System.Drawing.Point(40, 224)
        Me.lblTotalesAport.MaxLength = 20
        Me.lblTotalesAport.Name = "lblTotalesAport"
        Me.lblTotalesAport.ReadOnly = True
        Me.lblTotalesAport.Size = New System.Drawing.Size(252, 20)
        Me.lblTotalesAport.TabIndex = 219
        Me.lblTotalesAport.TabStop = False
        Me.lblTotalesAport.Text = "TOTALES :"
        Me.lblTotalesAport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalUSAport
        '
        Me.txtTotalUSAport.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalUSAport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalUSAport.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalUSAport.Location = New System.Drawing.Point(386, 224)
        Me.txtTotalUSAport.MaxLength = 5
        Me.txtTotalUSAport.Name = "txtTotalUSAport"
        Me.txtTotalUSAport.ReadOnly = True
        Me.txtTotalUSAport.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalUSAport.TabIndex = 6
        Me.txtTotalUSAport.TabStop = False
        Me.txtTotalUSAport.Text = "0.00"
        Me.txtTotalUSAport.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalUSAport.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalUSAport.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox4.Location = New System.Drawing.Point(22, 212)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(478, 37)
        Me.UiGroupBox4.TabIndex = 220
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvAportaciones
        '
        dgvAportaciones_DesignTimeLayout.LayoutString = resources.GetString("dgvAportaciones_DesignTimeLayout.LayoutString")
        Me.dgvAportaciones.DesignTimeLayout = dgvAportaciones_DesignTimeLayout
        Me.dgvAportaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvAportaciones.GroupByBoxVisible = False
        Me.dgvAportaciones.Location = New System.Drawing.Point(22, 27)
        Me.dgvAportaciones.Name = "dgvAportaciones"
        Me.dgvAportaciones.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvAportaciones.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvAportaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvAportaciones.Size = New System.Drawing.Size(478, 179)
        Me.dgvAportaciones.TabIndex = 5
        Me.dgvAportaciones.TabStop = False
        Me.dgvAportaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'tpCTS
        '
        Me.tpCTS.Controls.Add(Me.UiGroupBox5)
        Me.tpCTS.Controls.Add(Me.dgvCTS)
        Me.tpCTS.Icon = CType(resources.GetObject("tpCTS.Icon"), System.Drawing.Icon)
        Me.tpCTS.Location = New System.Drawing.Point(1, 23)
        Me.tpCTS.Name = "tpCTS"
        Me.tpCTS.Size = New System.Drawing.Size(522, 268)
        Me.tpCTS.TabStop = True
        Me.tpCTS.Text = "CTS"
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox5.Controls.Add(Me.txtTotalNSCTS)
        Me.UiGroupBox5.Controls.Add(Me.TextBox1)
        Me.UiGroupBox5.Controls.Add(Me.txtTotalUSCTS)
        Me.UiGroupBox5.Location = New System.Drawing.Point(22, 224)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(478, 37)
        Me.UiGroupBox5.TabIndex = 222
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalNSCTS
        '
        Me.txtTotalNSCTS.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNSCTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNSCTS.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNSCTS.Location = New System.Drawing.Point(271, 12)
        Me.txtTotalNSCTS.MaxLength = 5
        Me.txtTotalNSCTS.Name = "txtTotalNSCTS"
        Me.txtTotalNSCTS.ReadOnly = True
        Me.txtTotalNSCTS.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalNSCTS.TabIndex = 221
        Me.txtTotalNSCTS.TabStop = False
        Me.txtTotalNSCTS.Text = "0.00"
        Me.txtTotalNSCTS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNSCTS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNSCTS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox1.Location = New System.Drawing.Point(20, 12)
        Me.TextBox1.MaxLength = 20
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(252, 20)
        Me.TextBox1.TabIndex = 222
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "TOTALES :"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalUSCTS
        '
        Me.txtTotalUSCTS.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalUSCTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalUSCTS.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalUSCTS.Location = New System.Drawing.Point(366, 12)
        Me.txtTotalUSCTS.MaxLength = 5
        Me.txtTotalUSCTS.Name = "txtTotalUSCTS"
        Me.txtTotalUSCTS.ReadOnly = True
        Me.txtTotalUSCTS.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalUSCTS.TabIndex = 220
        Me.txtTotalUSCTS.TabStop = False
        Me.txtTotalUSCTS.Text = "0.00"
        Me.txtTotalUSCTS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalUSCTS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalUSCTS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvCTS
        '
        Me.dgvCTS.ContextMenuStrip = Me.cmOpcionesCTS
        dgvCTS_DesignTimeLayout.LayoutString = resources.GetString("dgvCTS_DesignTimeLayout.LayoutString")
        Me.dgvCTS.DesignTimeLayout = dgvCTS_DesignTimeLayout
        Me.dgvCTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvCTS.GroupByBoxVisible = False
        Me.dgvCTS.Location = New System.Drawing.Point(5, 8)
        Me.dgvCTS.Name = "dgvCTS"
        Me.dgvCTS.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCTS.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCTS.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCTS.Size = New System.Drawing.Size(495, 216)
        Me.dgvCTS.TabIndex = 221
        Me.dgvCTS.TabStop = False
        Me.dgvCTS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpcionesCTS
        '
        Me.cmOpcionesCTS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mbNuevoCts, Me.mbMostrarCts, Me.mbEliminarCts, Me.ToolStripSeparator6, Me.mbRefrescarCts})
        Me.cmOpcionesCTS.Name = "cmOpciones"
        Me.cmOpcionesCTS.Size = New System.Drawing.Size(127, 98)
        '
        'mbNuevoCts
        '
        Me.mbNuevoCts.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.mbNuevoCts.Name = "mbNuevoCts"
        Me.mbNuevoCts.Size = New System.Drawing.Size(126, 22)
        Me.mbNuevoCts.Text = "Nuevo"
        Me.mbNuevoCts.ToolTipText = "Nuevo Detalle"
        '
        'mbMostrarCts
        '
        Me.mbMostrarCts.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.mbMostrarCts.Name = "mbMostrarCts"
        Me.mbMostrarCts.Size = New System.Drawing.Size(126, 22)
        Me.mbMostrarCts.Text = "Mostrar"
        '
        'mbEliminarCts
        '
        Me.mbEliminarCts.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.mbEliminarCts.Name = "mbEliminarCts"
        Me.mbEliminarCts.Size = New System.Drawing.Size(126, 22)
        Me.mbEliminarCts.Text = "Eliminar"
        Me.mbEliminarCts.ToolTipText = "Eliminar Detalle"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(123, 6)
        '
        'mbRefrescarCts
        '
        Me.mbRefrescarCts.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.mbRefrescarCts.Name = "mbRefrescarCts"
        Me.mbRefrescarCts.Size = New System.Drawing.Size(126, 22)
        Me.mbRefrescarCts.Text = "Actualizar"
        Me.mbRefrescarCts.ToolTipText = "Refrescar Lista Detalles"
        '
        'tpGrati
        '
        Me.tpGrati.Controls.Add(Me.UiGroupBox7)
        Me.tpGrati.Controls.Add(Me.dgvGrati)
        Me.tpGrati.Icon = CType(resources.GetObject("tpGrati.Icon"), System.Drawing.Icon)
        Me.tpGrati.Location = New System.Drawing.Point(1, 23)
        Me.tpGrati.Name = "tpGrati"
        Me.tpGrati.Size = New System.Drawing.Size(522, 268)
        Me.tpGrati.TabStop = True
        Me.tpGrati.Text = "Gratificación"
        '
        'UiGroupBox7
        '
        Me.UiGroupBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox7.Controls.Add(Me.txtTotalNSGrati)
        Me.UiGroupBox7.Controls.Add(Me.TextBox2)
        Me.UiGroupBox7.Controls.Add(Me.txtTotalUSGrati)
        Me.UiGroupBox7.Location = New System.Drawing.Point(26, 224)
        Me.UiGroupBox7.Name = "UiGroupBox7"
        Me.UiGroupBox7.Size = New System.Drawing.Size(478, 37)
        Me.UiGroupBox7.TabIndex = 224
        Me.UiGroupBox7.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalNSGrati
        '
        Me.txtTotalNSGrati.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNSGrati.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNSGrati.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNSGrati.Location = New System.Drawing.Point(271, 12)
        Me.txtTotalNSGrati.MaxLength = 5
        Me.txtTotalNSGrati.Name = "txtTotalNSGrati"
        Me.txtTotalNSGrati.ReadOnly = True
        Me.txtTotalNSGrati.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalNSGrati.TabIndex = 221
        Me.txtTotalNSGrati.TabStop = False
        Me.txtTotalNSGrati.Text = "0.00"
        Me.txtTotalNSGrati.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNSGrati.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNSGrati.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox2.Location = New System.Drawing.Point(20, 12)
        Me.TextBox2.MaxLength = 20
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(252, 20)
        Me.TextBox2.TabIndex = 222
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "TOTALES :"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalUSGrati
        '
        Me.txtTotalUSGrati.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalUSGrati.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalUSGrati.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalUSGrati.Location = New System.Drawing.Point(366, 12)
        Me.txtTotalUSGrati.MaxLength = 5
        Me.txtTotalUSGrati.Name = "txtTotalUSGrati"
        Me.txtTotalUSGrati.ReadOnly = True
        Me.txtTotalUSGrati.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalUSGrati.TabIndex = 220
        Me.txtTotalUSGrati.TabStop = False
        Me.txtTotalUSGrati.Text = "0.00"
        Me.txtTotalUSGrati.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalUSGrati.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalUSGrati.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvGrati
        '
        Me.dgvGrati.ContextMenuStrip = Me.cmOpcionesGrati
        dgvGrati_DesignTimeLayout.LayoutString = resources.GetString("dgvGrati_DesignTimeLayout.LayoutString")
        Me.dgvGrati.DesignTimeLayout = dgvGrati_DesignTimeLayout
        Me.dgvGrati.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvGrati.GroupByBoxVisible = False
        Me.dgvGrati.Location = New System.Drawing.Point(9, 8)
        Me.dgvGrati.Name = "dgvGrati"
        Me.dgvGrati.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvGrati.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvGrati.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvGrati.Size = New System.Drawing.Size(495, 216)
        Me.dgvGrati.TabIndex = 223
        Me.dgvGrati.TabStop = False
        Me.dgvGrati.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpcionesGrati
        '
        Me.cmOpcionesGrati.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoGrati, Me.miMostrarGrati, Me.miEliminarGrati, Me.ToolStripSeparator5, Me.miActualizarGrati})
        Me.cmOpcionesGrati.Name = "cmOpciones"
        Me.cmOpcionesGrati.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevoGrati
        '
        Me.miNuevoGrati.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoGrati.Name = "miNuevoGrati"
        Me.miNuevoGrati.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoGrati.Text = "Nuevo"
        Me.miNuevoGrati.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarGrati
        '
        Me.miMostrarGrati.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarGrati.Name = "miMostrarGrati"
        Me.miMostrarGrati.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarGrati.Text = "Mostrar"
        Me.miMostrarGrati.ToolTipText = "Mostrar Registro"
        '
        'miEliminarGrati
        '
        Me.miEliminarGrati.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarGrati.Name = "miEliminarGrati"
        Me.miEliminarGrati.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarGrati.Text = "Eliminar"
        Me.miEliminarGrati.ToolTipText = "Eliminar Detalle"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarGrati
        '
        Me.miActualizarGrati.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarGrati.Name = "miActualizarGrati"
        Me.miActualizarGrati.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarGrati.Text = "Actualizar"
        Me.miActualizarGrati.ToolTipText = "Refrescar Lista Detalles"
        '
        'tpVaca
        '
        Me.tpVaca.Controls.Add(Me.UiGroupBox8)
        Me.tpVaca.Controls.Add(Me.dgvVaca)
        Me.tpVaca.Icon = CType(resources.GetObject("tpVaca.Icon"), System.Drawing.Icon)
        Me.tpVaca.Location = New System.Drawing.Point(1, 23)
        Me.tpVaca.Name = "tpVaca"
        Me.tpVaca.Size = New System.Drawing.Size(538, 268)
        Me.tpVaca.TabStop = True
        Me.tpVaca.Text = "Vacaciones"
        '
        'UiGroupBox8
        '
        Me.UiGroupBox8.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox8.Controls.Add(Me.txtTotalNSVaca)
        Me.UiGroupBox8.Controls.Add(Me.TextBox3)
        Me.UiGroupBox8.Controls.Add(Me.txtTotalUSVaca)
        Me.UiGroupBox8.Location = New System.Drawing.Point(54, 224)
        Me.UiGroupBox8.Name = "UiGroupBox8"
        Me.UiGroupBox8.Size = New System.Drawing.Size(478, 37)
        Me.UiGroupBox8.TabIndex = 226
        Me.UiGroupBox8.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalNSVaca
        '
        Me.txtTotalNSVaca.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNSVaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNSVaca.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNSVaca.Location = New System.Drawing.Point(271, 12)
        Me.txtTotalNSVaca.MaxLength = 5
        Me.txtTotalNSVaca.Name = "txtTotalNSVaca"
        Me.txtTotalNSVaca.ReadOnly = True
        Me.txtTotalNSVaca.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalNSVaca.TabIndex = 221
        Me.txtTotalNSVaca.TabStop = False
        Me.txtTotalNSVaca.Text = "0.00"
        Me.txtTotalNSVaca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNSVaca.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNSVaca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox3.Location = New System.Drawing.Point(20, 12)
        Me.TextBox3.MaxLength = 20
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(252, 20)
        Me.TextBox3.TabIndex = 222
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "TOTALES :"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalUSVaca
        '
        Me.txtTotalUSVaca.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalUSVaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalUSVaca.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalUSVaca.Location = New System.Drawing.Point(366, 12)
        Me.txtTotalUSVaca.MaxLength = 5
        Me.txtTotalUSVaca.Name = "txtTotalUSVaca"
        Me.txtTotalUSVaca.ReadOnly = True
        Me.txtTotalUSVaca.Size = New System.Drawing.Size(96, 20)
        Me.txtTotalUSVaca.TabIndex = 220
        Me.txtTotalUSVaca.TabStop = False
        Me.txtTotalUSVaca.Text = "0.00"
        Me.txtTotalUSVaca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalUSVaca.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalUSVaca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvVaca
        '
        Me.dgvVaca.ContextMenuStrip = Me.cmOpcionesVaca
        dgvVaca_DesignTimeLayout.LayoutString = resources.GetString("dgvVaca_DesignTimeLayout.LayoutString")
        Me.dgvVaca.DesignTimeLayout = dgvVaca_DesignTimeLayout
        Me.dgvVaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvVaca.GroupByBoxVisible = False
        Me.dgvVaca.Location = New System.Drawing.Point(4, 3)
        Me.dgvVaca.Name = "dgvVaca"
        Me.dgvVaca.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvVaca.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvVaca.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvVaca.Size = New System.Drawing.Size(529, 216)
        Me.dgvVaca.TabIndex = 225
        Me.dgvVaca.TabStop = False
        Me.dgvVaca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpcionesVaca
        '
        Me.cmOpcionesVaca.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoVaca, Me.miMostrarVaca, Me.miEliminarVaca, Me.ToolStripSeparator7, Me.miRefrescarVaca})
        Me.cmOpcionesVaca.Name = "cmOpciones"
        Me.cmOpcionesVaca.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevoVaca
        '
        Me.miNuevoVaca.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoVaca.Name = "miNuevoVaca"
        Me.miNuevoVaca.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoVaca.Text = "Nuevo"
        Me.miNuevoVaca.ToolTipText = "Nuevo Detalle"
        '
        'miMostrarVaca
        '
        Me.miMostrarVaca.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarVaca.Name = "miMostrarVaca"
        Me.miMostrarVaca.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarVaca.Text = "Mostrar"
        Me.miMostrarVaca.ToolTipText = "Mostrar Registro"
        '
        'miEliminarVaca
        '
        Me.miEliminarVaca.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarVaca.Name = "miEliminarVaca"
        Me.miEliminarVaca.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarVaca.Text = "Eliminar"
        Me.miEliminarVaca.ToolTipText = "Eliminar Detalle"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(123, 6)
        '
        'miRefrescarVaca
        '
        Me.miRefrescarVaca.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miRefrescarVaca.Name = "miRefrescarVaca"
        Me.miRefrescarVaca.Size = New System.Drawing.Size(126, 22)
        Me.miRefrescarVaca.Text = "Actualizar"
        Me.miRefrescarVaca.ToolTipText = "Refrescar Lista Detalles"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPersona)
        Me.UiGroupBox1.Controls.Add(Me.txtColaborador)
        Me.UiGroupBox1.Controls.Add(Me.txtIdPlanilla)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(524, 43)
        Me.UiGroupBox1.TabIndex = 189
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "Colaborador"
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(491, 14)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarPersona.TabIndex = 188
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'txtColaborador
        '
        Me.txtColaborador.BackColor = System.Drawing.SystemColors.Control
        Me.txtColaborador.Location = New System.Drawing.Point(241, 15)
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(248, 20)
        Me.txtColaborador.TabIndex = 2
        '
        'txtIdPlanilla
        '
        Me.txtIdPlanilla.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPlanilla.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdPlanilla.Location = New System.Drawing.Point(84, 15)
        Me.txtIdPlanilla.Name = "txtIdPlanilla"
        Me.txtIdPlanilla.Size = New System.Drawing.Size(59, 20)
        Me.txtIdPlanilla.TabIndex = 1
        Me.txtIdPlanilla.TabStop = False
        Me.txtIdPlanilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nº de Planilla"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmPlanillaVarColaborador
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(551, 355)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.TabVariables)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanillaVarColaborador"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Variables del Colaborador"
        CType(Me.TabVariables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabVariables.ResumeLayout(False)
        Me.tpVariables.ResumeLayout(False)
        Me.tpVariables.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.gbHoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbHoras.ResumeLayout(False)
        Me.gbHoras.PerformLayout()
        CType(Me.gbMonto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMonto.ResumeLayout(False)
        Me.gbMonto.PerformLayout()
        CType(Me.gbDias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDias.ResumeLayout(False)
        Me.gbDias.PerformLayout()
        CType(Me.gbFechasVacacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFechasVacacion.ResumeLayout(False)
        Me.gbFechasVacacion.PerformLayout()
        Me.tpIngresos.ResumeLayout(False)
        Me.tpIngresos.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.dgvIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesIngresos.ResumeLayout(False)
        Me.tpDescuentos.ResumeLayout(False)
        Me.tpDescuentos.PerformLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.dgvDsctos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesDsctos.ResumeLayout(False)
        Me.tpHorasExtras.ResumeLayout(False)
        CType(Me.dgvHrsExtras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesHrsExtras.ResumeLayout(False)
        Me.tpAportaciones.ResumeLayout(False)
        Me.tpAportaciones.PerformLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAportaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCTS.ResumeLayout(False)
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.UiGroupBox5.PerformLayout()
        CType(Me.dgvCTS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesCTS.ResumeLayout(False)
        Me.tpGrati.ResumeLayout(False)
        CType(Me.UiGroupBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox7.ResumeLayout(False)
        Me.UiGroupBox7.PerformLayout()
        CType(Me.dgvGrati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesGrati.ResumeLayout(False)
        Me.tpVaca.ResumeLayout(False)
        CType(Me.UiGroupBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox8.ResumeLayout(False)
        Me.UiGroupBox8.PerformLayout()
        CType(Me.dgvVaca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesVaca.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabVariables As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tpVariables As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpIngresos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpDescuentos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpHorasExtras As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents txtIdPlanilla As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents txtDiasMovilidad As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDiasPago As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDiasPDT As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDiasReales As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtHorasReales As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMontoMovil As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtVacacionFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtVacacionIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents gbFechasVacacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbDias As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbHoras As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbMonto As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvIngresos As Janus.Windows.GridEX.GridEX
    Friend WithEvents tpAportaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvDsctos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpcionesIngresos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDeshacer As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents dgvHrsExtras As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgvAportaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpcionesDsctos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoDscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarDscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarDscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarDscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpcionesHrsExtras As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoHrsExtras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarHrsExtras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarHrsExtras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarHrsExtras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblTotalesDsctos As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNSDsctos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalUSDsctos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalUSIng As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalesIng As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalNSIng As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalUSAport As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalesAport As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNSAport As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents miReprocesarIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miReprocesarDscto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miReprocesarHrsExtras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalNetoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalNetoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ckPagado As CheckBox
    Friend WithEvents tpCTS As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalNSCTS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtTotalUSCTS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dgvCTS As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpcionesCTS As ContextMenuStrip
    Friend WithEvents mbNuevoCts As ToolStripMenuItem
    Friend WithEvents mbMostrarCts As ToolStripMenuItem
    Friend WithEvents mbEliminarCts As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents mbRefrescarCts As ToolStripMenuItem
    Friend WithEvents tpGrati As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiGroupBox7 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalNSGrati As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents txtTotalUSGrati As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dgvGrati As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpcionesGrati As ContextMenuStrip
    Friend WithEvents miNuevoGrati As ToolStripMenuItem
    Friend WithEvents miMostrarGrati As ToolStripMenuItem
    Friend WithEvents miEliminarGrati As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents miActualizarGrati As ToolStripMenuItem
    Friend WithEvents tpVaca As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiGroupBox8 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalNSVaca As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents txtTotalUSVaca As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dgvVaca As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpcionesVaca As ContextMenuStrip
    Friend WithEvents miNuevoVaca As ToolStripMenuItem
    Friend WithEvents miMostrarVaca As ToolStripMenuItem
    Friend WithEvents miEliminarVaca As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents miRefrescarVaca As ToolStripMenuItem
End Class
