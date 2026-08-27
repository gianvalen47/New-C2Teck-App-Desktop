<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudGarantia_Detalle
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
        Dim cmbDocumento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudGarantia_Detalle))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvManoObra_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvSistemas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvLocaciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumClaim = New System.Windows.Forms.TextBox()
        Me.txtCreditState = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotRepuestosAtendido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbAtendido = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaCredit = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotOtros = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTotNetItem = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtTotalMontoAtendido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotRepuestosCli = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtHorasManoObraAtendido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotManoObraAtendido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHorasViajeAtendido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotViajeAtendido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMillasDistanciaAtendido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotDistanciaAtendido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotOtrosRec = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtTotNetItemRec = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtTotalMontoReclamado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtHorasManoObraRec = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotManoObraRec = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtHorasViajeRec = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotViajeRec = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTotRepuestosRec = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMillasDistanciaRec = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTotDistanciaRec = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbRechazado = New System.Windows.Forms.CheckBox()
        Me.cmbDocumento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbCobrado = New System.Windows.Forms.CheckBox()
        Me.txtNumDocumento = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAtender = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biRechazar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbRepuestos = New Janus.Windows.EditControls.UIGroupBox()
        Me.TabOpciones = New Janus.Windows.UI.Tab.UITab()
        Me.tbEmpresas = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCantAtendidaOk = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPrecFabricaOk = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarGuia = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbRubroRecurso = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvManoObra = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesMO = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoMO = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarMO = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarMO = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizarMO = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAsignarSistemas = New System.Windows.Forms.Button()
        Me.dgvSistemas = New Janus.Windows.GridEX.GridEX()
        Me.ckVerPrecios = New Janus.Windows.EditControls.UICheckBox()
        Me.ckVendeOficina = New Janus.Windows.EditControls.UICheckBox()
        Me.ckGastoGerencia = New Janus.Windows.EditControls.UICheckBox()
        Me.ckPrecioFlete = New Janus.Windows.EditControls.UICheckBox()
        Me.ckVerGastos = New Janus.Windows.EditControls.UICheckBox()
        Me.txtPerfil = New System.Windows.Forms.TextBox()
        Me.gbFacturacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTipFacTodos = New System.Windows.Forms.RadioButton()
        Me.rbTipFacCon = New System.Windows.Forms.RadioButton()
        Me.rbTipFacCre = New System.Windows.Forms.RadioButton()
        Me.ckPerPrecioFOB = New Janus.Windows.EditControls.UICheckBox()
        Me.ckPerPrecio = New Janus.Windows.EditControls.UICheckBox()
        Me.ckCartera = New Janus.Windows.EditControls.UICheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.ckTipCam = New Janus.Windows.EditControls.UICheckBox()
        Me.btnAsignarLocaciones = New System.Windows.Forms.Button()
        Me.dgvLocaciones = New Janus.Windows.GridEX.GridEX()
        Me.btnAsignarCentrosCosto = New System.Windows.Forms.Button()
        Me.dgvCentroCosto = New Janus.Windows.GridEX.GridEX()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.gbRepuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRepuestos.SuspendLayout()
        CType(Me.TabOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabOpciones.SuspendLayout()
        Me.tbEmpresas.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.tbRubroRecurso.SuspendLayout()
        CType(Me.dgvManoObra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesMO.SuspendLayout()
        CType(Me.dgvSistemas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFacturacion.SuspendLayout()
        CType(Me.dgvLocaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nro de Claim"
        '
        'txtNumClaim
        '
        Me.txtNumClaim.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumClaim.Location = New System.Drawing.Point(120, 22)
        Me.txtNumClaim.Name = "txtNumClaim"
        Me.txtNumClaim.Size = New System.Drawing.Size(98, 20)
        Me.txtNumClaim.TabIndex = 1
        '
        'txtCreditState
        '
        Me.txtCreditState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreditState.Location = New System.Drawing.Point(120, 50)
        Me.txtCreditState.Name = "txtCreditState"
        Me.txtCreditState.ReadOnly = True
        Me.txtCreditState.Size = New System.Drawing.Size(98, 20)
        Me.txtCreditState.TabIndex = 3
        Me.txtCreditState.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Credit State"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Total Repuestos"
        '
        'txtTotRepuestosAtendido
        '
        Me.txtTotRepuestosAtendido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotRepuestosAtendido.Location = New System.Drawing.Point(176, 166)
        Me.txtTotRepuestosAtendido.MaxLength = 10
        Me.txtTotRepuestosAtendido.Name = "txtTotRepuestosAtendido"
        Me.txtTotRepuestosAtendido.Size = New System.Drawing.Size(100, 20)
        Me.txtTotRepuestosAtendido.TabIndex = 34
        Me.txtTotRepuestosAtendido.TabStop = False
        Me.txtTotRepuestosAtendido.Text = "0.00"
        Me.txtTotRepuestosAtendido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotRepuestosAtendido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cbAtendido)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaCredit)
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox3)
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Controls.Add(Me.Label13)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.txtFecha)
        Me.UiGroupBox1.Controls.Add(Me.cbRechazado)
        Me.UiGroupBox1.Controls.Add(Me.cmbDocumento)
        Me.UiGroupBox1.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox1.Controls.Add(Me.Label12)
        Me.UiGroupBox1.Controls.Add(Me.cbCobrado)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDocumento)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.txtCreditState)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtNumClaim)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(656, 440)
        Me.UiGroupBox1.TabIndex = 36
        Me.UiGroupBox1.Text = "Datos de Atención"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbAtendido
        '
        Me.cbAtendido.AutoSize = True
        Me.cbAtendido.BackColor = System.Drawing.SystemColors.Control
        Me.cbAtendido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAtendido.Enabled = False
        Me.cbAtendido.Location = New System.Drawing.Point(556, 52)
        Me.cbAtendido.Name = "cbAtendido"
        Me.cbAtendido.Size = New System.Drawing.Size(76, 17)
        Me.cbAtendido.TabIndex = 561
        Me.cbAtendido.TabStop = False
        Me.cbAtendido.Text = "Atendido"
        Me.cbAtendido.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(228, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 13)
        Me.Label14.TabIndex = 560
        Me.Label14.Text = "Fec. Acreditación"
        '
        'txtFechaCredit
        '
        Me.txtFechaCredit.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFechaCredit.DropDownCalendar.Name = ""
        Me.txtFechaCredit.DropDownCalendar.Visible = False
        Me.txtFechaCredit.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaCredit.IsNullDate = True
        Me.txtFechaCredit.Location = New System.Drawing.Point(337, 50)
        Me.txtFechaCredit.Name = "txtFechaCredit"
        Me.txtFechaCredit.ReadOnly = True
        Me.txtFechaCredit.Size = New System.Drawing.Size(95, 20)
        Me.txtFechaCredit.TabIndex = 559
        Me.txtFechaCredit.TabStop = False
        Me.txtFechaCredit.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.txtTotOtros)
        Me.UiGroupBox3.Controls.Add(Me.Label29)
        Me.UiGroupBox3.Controls.Add(Me.txtTotNetItem)
        Me.UiGroupBox3.Controls.Add(Me.Label25)
        Me.UiGroupBox3.Controls.Add(Me.Label24)
        Me.UiGroupBox3.Controls.Add(Me.txtTotalMontoAtendido)
        Me.UiGroupBox3.Controls.Add(Me.txtTotRepuestosCli)
        Me.UiGroupBox3.Controls.Add(Me.Label22)
        Me.UiGroupBox3.Controls.Add(Me.txtHorasManoObraAtendido)
        Me.UiGroupBox3.Controls.Add(Me.Label3)
        Me.UiGroupBox3.Controls.Add(Me.txtTotManoObraAtendido)
        Me.UiGroupBox3.Controls.Add(Me.Label4)
        Me.UiGroupBox3.Controls.Add(Me.txtHorasViajeAtendido)
        Me.UiGroupBox3.Controls.Add(Me.Label5)
        Me.UiGroupBox3.Controls.Add(Me.txtTotViajeAtendido)
        Me.UiGroupBox3.Controls.Add(Me.Label6)
        Me.UiGroupBox3.Controls.Add(Me.txtTotRepuestosAtendido)
        Me.UiGroupBox3.Controls.Add(Me.txtMillasDistanciaAtendido)
        Me.UiGroupBox3.Controls.Add(Me.Label8)
        Me.UiGroupBox3.Controls.Add(Me.Label7)
        Me.UiGroupBox3.Controls.Add(Me.txtTotDistanciaAtendido)
        Me.UiGroupBox3.Controls.Add(Me.Label9)
        Me.UiGroupBox3.Location = New System.Drawing.Point(331, 103)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(305, 291)
        Me.UiGroupBox3.TabIndex = 12
        Me.UiGroupBox3.Text = "Montos Atendidos x Fábrica"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtTotOtros
        '
        Me.txtTotOtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotOtros.Location = New System.Drawing.Point(176, 216)
        Me.txtTotOtros.MaxLength = 10
        Me.txtTotOtros.Name = "txtTotOtros"
        Me.txtTotOtros.Size = New System.Drawing.Size(100, 20)
        Me.txtTotOtros.TabIndex = 20
        Me.txtTotOtros.Text = "0.00"
        Me.txtTotOtros.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotOtros.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(28, 220)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(113, 13)
        Me.Label29.TabIndex = 68
        Me.Label29.Text = "Total Otros Gastos"
        '
        'txtTotNetItem
        '
        Me.txtTotNetItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotNetItem.Location = New System.Drawing.Point(176, 242)
        Me.txtTotNetItem.MaxLength = 10
        Me.txtTotNetItem.Name = "txtTotNetItem"
        Me.txtTotNetItem.Size = New System.Drawing.Size(100, 20)
        Me.txtTotNetItem.TabIndex = 50
        Me.txtTotNetItem.Text = "0.00"
        Me.txtTotNetItem.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotNetItem.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(29, 246)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 13)
        Me.Label25.TabIndex = 66
        Me.Label25.Text = "Total Net Item"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(29, 271)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(129, 13)
        Me.Label24.TabIndex = 64
        Me.Label24.Text = "Total Monto Atendido"
        '
        'txtTotalMontoAtendido
        '
        Me.txtTotalMontoAtendido.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalMontoAtendido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMontoAtendido.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtTotalMontoAtendido.Location = New System.Drawing.Point(176, 267)
        Me.txtTotalMontoAtendido.MaxLength = 10
        Me.txtTotalMontoAtendido.Name = "txtTotalMontoAtendido"
        Me.txtTotalMontoAtendido.ReadOnly = True
        Me.txtTotalMontoAtendido.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalMontoAtendido.TabIndex = 67
        Me.txtTotalMontoAtendido.Text = "0.00"
        Me.txtTotalMontoAtendido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalMontoAtendido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotRepuestosCli
        '
        Me.txtTotRepuestosCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotRepuestosCli.Location = New System.Drawing.Point(176, 191)
        Me.txtTotRepuestosCli.MaxLength = 10
        Me.txtTotRepuestosCli.Name = "txtTotRepuestosCli"
        Me.txtTotRepuestosCli.Size = New System.Drawing.Size(100, 20)
        Me.txtTotRepuestosCli.TabIndex = 19
        Me.txtTotRepuestosCli.Text = "0.00"
        Me.txtTotRepuestosCli.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotRepuestosCli.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(28, 195)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(143, 13)
        Me.Label22.TabIndex = 49
        Me.Label22.Text = "Total Repuestos Cliente"
        '
        'txtHorasManoObraAtendido
        '
        Me.txtHorasManoObraAtendido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorasManoObraAtendido.Location = New System.Drawing.Point(176, 16)
        Me.txtHorasManoObraAtendido.MaxLength = 10
        Me.txtHorasManoObraAtendido.Name = "txtHorasManoObraAtendido"
        Me.txtHorasManoObraAtendido.Size = New System.Drawing.Size(100, 20)
        Me.txtHorasManoObraAtendido.TabIndex = 13
        Me.txtHorasManoObraAtendido.Text = "0.00"
        Me.txtHorasManoObraAtendido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHorasManoObraAtendido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Horas Mano de Obra"
        '
        'txtTotManoObraAtendido
        '
        Me.txtTotManoObraAtendido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotManoObraAtendido.Location = New System.Drawing.Point(176, 41)
        Me.txtTotManoObraAtendido.MaxLength = 10
        Me.txtTotManoObraAtendido.Name = "txtTotManoObraAtendido"
        Me.txtTotManoObraAtendido.Size = New System.Drawing.Size(100, 20)
        Me.txtTotManoObraAtendido.TabIndex = 14
        Me.txtTotManoObraAtendido.Text = "0.00"
        Me.txtTotManoObraAtendido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotManoObraAtendido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Total Mano de Obra"
        '
        'txtHorasViajeAtendido
        '
        Me.txtHorasViajeAtendido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorasViajeAtendido.Location = New System.Drawing.Point(176, 66)
        Me.txtHorasViajeAtendido.MaxLength = 10
        Me.txtHorasViajeAtendido.Name = "txtHorasViajeAtendido"
        Me.txtHorasViajeAtendido.Size = New System.Drawing.Size(100, 20)
        Me.txtHorasViajeAtendido.TabIndex = 15
        Me.txtHorasViajeAtendido.Text = "0.00"
        Me.txtHorasViajeAtendido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHorasViajeAtendido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Horas de Viaje"
        '
        'txtTotViajeAtendido
        '
        Me.txtTotViajeAtendido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotViajeAtendido.Location = New System.Drawing.Point(176, 91)
        Me.txtTotViajeAtendido.MaxLength = 10
        Me.txtTotViajeAtendido.Name = "txtTotViajeAtendido"
        Me.txtTotViajeAtendido.Size = New System.Drawing.Size(100, 20)
        Me.txtTotViajeAtendido.TabIndex = 16
        Me.txtTotViajeAtendido.Text = "0.00"
        Me.txtTotViajeAtendido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotViajeAtendido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Total Viaje"
        '
        'txtMillasDistanciaAtendido
        '
        Me.txtMillasDistanciaAtendido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMillasDistanciaAtendido.Location = New System.Drawing.Point(176, 116)
        Me.txtMillasDistanciaAtendido.MaxLength = 10
        Me.txtMillasDistanciaAtendido.Name = "txtMillasDistanciaAtendido"
        Me.txtMillasDistanciaAtendido.Size = New System.Drawing.Size(100, 20)
        Me.txtMillasDistanciaAtendido.TabIndex = 17
        Me.txtMillasDistanciaAtendido.Text = "0.00"
        Me.txtMillasDistanciaAtendido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMillasDistanciaAtendido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(29, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Millas Distancia"
        '
        'txtTotDistanciaAtendido
        '
        Me.txtTotDistanciaAtendido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotDistanciaAtendido.Location = New System.Drawing.Point(176, 141)
        Me.txtTotDistanciaAtendido.MaxLength = 10
        Me.txtTotDistanciaAtendido.Name = "txtTotDistanciaAtendido"
        Me.txtTotDistanciaAtendido.Size = New System.Drawing.Size(100, 20)
        Me.txtTotDistanciaAtendido.TabIndex = 18
        Me.txtTotDistanciaAtendido.Text = "0.00"
        Me.txtTotDistanciaAtendido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotDistanciaAtendido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(29, 145)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Total Distancia"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtTotOtrosRec)
        Me.UiGroupBox2.Controls.Add(Me.Label28)
        Me.UiGroupBox2.Controls.Add(Me.txtTotNetItemRec)
        Me.UiGroupBox2.Controls.Add(Me.Label26)
        Me.UiGroupBox2.Controls.Add(Me.Label23)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalMontoReclamado)
        Me.UiGroupBox2.Controls.Add(Me.txtHorasManoObraRec)
        Me.UiGroupBox2.Controls.Add(Me.Label15)
        Me.UiGroupBox2.Controls.Add(Me.txtTotManoObraRec)
        Me.UiGroupBox2.Controls.Add(Me.Label16)
        Me.UiGroupBox2.Controls.Add(Me.txtHorasViajeRec)
        Me.UiGroupBox2.Controls.Add(Me.Label17)
        Me.UiGroupBox2.Controls.Add(Me.txtTotViajeRec)
        Me.UiGroupBox2.Controls.Add(Me.Label18)
        Me.UiGroupBox2.Controls.Add(Me.txtTotRepuestosRec)
        Me.UiGroupBox2.Controls.Add(Me.txtMillasDistanciaRec)
        Me.UiGroupBox2.Controls.Add(Me.Label19)
        Me.UiGroupBox2.Controls.Add(Me.Label20)
        Me.UiGroupBox2.Controls.Add(Me.txtTotDistanciaRec)
        Me.UiGroupBox2.Controls.Add(Me.Label21)
        Me.UiGroupBox2.Location = New System.Drawing.Point(17, 103)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(305, 268)
        Me.UiGroupBox2.TabIndex = 557
        Me.UiGroupBox2.Text = "Montos Reclamados"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtTotOtrosRec
        '
        Me.txtTotOtrosRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotOtrosRec.Location = New System.Drawing.Point(175, 191)
        Me.txtTotOtrosRec.MaxLength = 10
        Me.txtTotOtrosRec.Name = "txtTotOtrosRec"
        Me.txtTotOtrosRec.Size = New System.Drawing.Size(100, 20)
        Me.txtTotOtrosRec.TabIndex = 11
        Me.txtTotOtrosRec.Text = "0.00"
        Me.txtTotOtrosRec.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotOtrosRec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(32, 195)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(113, 13)
        Me.Label28.TabIndex = 70
        Me.Label28.Text = "Total Otros Gastos"
        '
        'txtTotNetItemRec
        '
        Me.txtTotNetItemRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotNetItemRec.Location = New System.Drawing.Point(175, 216)
        Me.txtTotNetItemRec.MaxLength = 10
        Me.txtTotNetItemRec.Name = "txtTotNetItemRec"
        Me.txtTotNetItemRec.Size = New System.Drawing.Size(100, 20)
        Me.txtTotNetItemRec.TabIndex = 62
        Me.txtTotNetItemRec.Text = "0.00"
        Me.txtTotNetItemRec.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotNetItemRec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(32, 220)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(88, 13)
        Me.Label26.TabIndex = 68
        Me.Label26.Text = "Total Net Item"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(32, 245)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(142, 13)
        Me.Label23.TabIndex = 63
        Me.Label23.Text = "Total Monto Reclamado"
        '
        'txtTotalMontoReclamado
        '
        Me.txtTotalMontoReclamado.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalMontoReclamado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMontoReclamado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtTotalMontoReclamado.Location = New System.Drawing.Point(175, 241)
        Me.txtTotalMontoReclamado.MaxLength = 10
        Me.txtTotalMontoReclamado.Name = "txtTotalMontoReclamado"
        Me.txtTotalMontoReclamado.ReadOnly = True
        Me.txtTotalMontoReclamado.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalMontoReclamado.TabIndex = 69
        Me.txtTotalMontoReclamado.Text = "0.00"
        Me.txtTotalMontoReclamado.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalMontoReclamado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtHorasManoObraRec
        '
        Me.txtHorasManoObraRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorasManoObraRec.Location = New System.Drawing.Point(175, 16)
        Me.txtHorasManoObraRec.MaxLength = 10
        Me.txtHorasManoObraRec.Name = "txtHorasManoObraRec"
        Me.txtHorasManoObraRec.Size = New System.Drawing.Size(100, 20)
        Me.txtHorasManoObraRec.TabIndex = 4
        Me.txtHorasManoObraRec.Text = "0.00"
        Me.txtHorasManoObraRec.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHorasManoObraRec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(32, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 13)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "Horas Mano de Obra"
        '
        'txtTotManoObraRec
        '
        Me.txtTotManoObraRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotManoObraRec.Location = New System.Drawing.Point(175, 41)
        Me.txtTotManoObraRec.MaxLength = 10
        Me.txtTotManoObraRec.Name = "txtTotManoObraRec"
        Me.txtTotManoObraRec.Size = New System.Drawing.Size(100, 20)
        Me.txtTotManoObraRec.TabIndex = 5
        Me.txtTotManoObraRec.Text = "0.00"
        Me.txtTotManoObraRec.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotManoObraRec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(32, 45)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 13)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Total Mano de Obra"
        '
        'txtHorasViajeRec
        '
        Me.txtHorasViajeRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorasViajeRec.Location = New System.Drawing.Point(175, 66)
        Me.txtHorasViajeRec.MaxLength = 10
        Me.txtHorasViajeRec.Name = "txtHorasViajeRec"
        Me.txtHorasViajeRec.Size = New System.Drawing.Size(100, 20)
        Me.txtHorasViajeRec.TabIndex = 6
        Me.txtHorasViajeRec.Text = "0.00"
        Me.txtHorasViajeRec.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHorasViajeRec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(32, 70)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Horas de Viaje"
        '
        'txtTotViajeRec
        '
        Me.txtTotViajeRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotViajeRec.Location = New System.Drawing.Point(175, 91)
        Me.txtTotViajeRec.MaxLength = 10
        Me.txtTotViajeRec.Name = "txtTotViajeRec"
        Me.txtTotViajeRec.Size = New System.Drawing.Size(100, 20)
        Me.txtTotViajeRec.TabIndex = 7
        Me.txtTotViajeRec.Text = "0.00"
        Me.txtTotViajeRec.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotViajeRec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(32, 95)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Total Viaje"
        '
        'txtTotRepuestosRec
        '
        Me.txtTotRepuestosRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotRepuestosRec.Location = New System.Drawing.Point(175, 166)
        Me.txtTotRepuestosRec.MaxLength = 10
        Me.txtTotRepuestosRec.Name = "txtTotRepuestosRec"
        Me.txtTotRepuestosRec.Size = New System.Drawing.Size(100, 20)
        Me.txtTotRepuestosRec.TabIndex = 10
        Me.txtTotRepuestosRec.Text = "0.00"
        Me.txtTotRepuestosRec.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotRepuestosRec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMillasDistanciaRec
        '
        Me.txtMillasDistanciaRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMillasDistanciaRec.Location = New System.Drawing.Point(175, 116)
        Me.txtMillasDistanciaRec.MaxLength = 10
        Me.txtMillasDistanciaRec.Name = "txtMillasDistanciaRec"
        Me.txtMillasDistanciaRec.Size = New System.Drawing.Size(100, 20)
        Me.txtMillasDistanciaRec.TabIndex = 8
        Me.txtMillasDistanciaRec.Text = "0.00"
        Me.txtMillasDistanciaRec.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMillasDistanciaRec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(32, 170)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 13)
        Me.Label19.TabIndex = 55
        Me.Label19.Text = "Total Repuestos"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(32, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 13)
        Me.Label20.TabIndex = 60
        Me.Label20.Text = "Millas Distancia"
        '
        'txtTotDistanciaRec
        '
        Me.txtTotDistanciaRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotDistanciaRec.Location = New System.Drawing.Point(175, 141)
        Me.txtTotDistanciaRec.MaxLength = 10
        Me.txtTotDistanciaRec.Name = "txtTotDistanciaRec"
        Me.txtTotDistanciaRec.Size = New System.Drawing.Size(100, 20)
        Me.txtTotDistanciaRec.TabIndex = 9
        Me.txtTotDistanciaRec.Text = "0.00"
        Me.txtTotDistanciaRec.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotDistanciaRec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(32, 145)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(93, 13)
        Me.Label21.TabIndex = 61
        Me.Label21.Text = "Total Distancia"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(257, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 13)
        Me.Label13.TabIndex = 556
        Me.Label13.Text = "Fecha Reclamo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(22, 405)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(106, 398)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(530, 36)
        Me.txtObservacion.TabIndex = 21
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(370, 22)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(95, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbRechazado
        '
        Me.cbRechazado.AutoSize = True
        Me.cbRechazado.BackColor = System.Drawing.SystemColors.Control
        Me.cbRechazado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbRechazado.Enabled = False
        Me.cbRechazado.Location = New System.Drawing.Point(451, 52)
        Me.cbRechazado.Name = "cbRechazado"
        Me.cbRechazado.Size = New System.Drawing.Size(90, 17)
        Me.cbRechazado.TabIndex = 554
        Me.cbRechazado.TabStop = False
        Me.cbRechazado.Text = "Rechazado"
        Me.cbRechazado.UseVisualStyleBackColor = False
        '
        'cmbDocumento
        '
        Me.cmbDocumento.BackColor = System.Drawing.SystemColors.Control
        Me.cmbDocumento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbDocumento_DesignTimeLayout.LayoutString = resources.GetString("cmbDocumento_DesignTimeLayout.LayoutString")
        Me.cmbDocumento.DesignTimeLayout = cmbDocumento_DesignTimeLayout
        Me.cmbDocumento.Location = New System.Drawing.Point(239, 78)
        Me.cmbDocumento.Name = "cmbDocumento"
        Me.cmbDocumento.ReadOnly = True
        Me.cmbDocumento.SelectedIndex = -1
        Me.cmbDocumento.SelectedItem = Nothing
        Me.cmbDocumento.Size = New System.Drawing.Size(193, 20)
        Me.cmbDocumento.TabIndex = 553
        Me.cmbDocumento.TabStop = False
        Me.cmbDocumento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(565, 22)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(48, 20)
        Me.cmbMoneda.TabIndex = 3
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(498, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "Moneda"
        '
        'cbCobrado
        '
        Me.cbCobrado.AutoSize = True
        Me.cbCobrado.BackColor = System.Drawing.SystemColors.Control
        Me.cbCobrado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbCobrado.Enabled = False
        Me.cbCobrado.Location = New System.Drawing.Point(501, 80)
        Me.cbCobrado.Name = "cbCobrado"
        Me.cbCobrado.Size = New System.Drawing.Size(73, 17)
        Me.cbCobrado.TabIndex = 52
        Me.cbCobrado.TabStop = False
        Me.cbCobrado.Text = "Cobrado"
        Me.cbCobrado.UseVisualStyleBackColor = False
        '
        'txtNumDocumento
        '
        Me.txtNumDocumento.BackColor = System.Drawing.SystemColors.Control
        Me.txtNumDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDocumento.Location = New System.Drawing.Point(120, 78)
        Me.txtNumDocumento.Name = "txtNumDocumento"
        Me.txtNumDocumento.ReadOnly = True
        Me.txtNumDocumento.Size = New System.Drawing.Size(104, 20)
        Me.txtNumDocumento.TabIndex = 51
        Me.txtNumDocumento.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(29, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 13)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Nº Documento"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator5, Me.biAtender, Me.ToolStripSeparator3, Me.biRechazar, Me.ToolStripSeparator1, Me.biSalir, Me.ToolStripSeparator4})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(683, 31)
        Me.ToolStrip.TabIndex = 116
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
        Me.biGuardar.Text = "Guardar Cambios"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biAtender
        '
        Me.biAtender.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAtender.Image = CType(resources.GetObject("biAtender.Image"), System.Drawing.Image)
        Me.biAtender.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAtender.Name = "biAtender"
        Me.biAtender.Size = New System.Drawing.Size(28, 28)
        Me.biAtender.Text = "Atender Atención de Reclamo Fabrica"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biRechazar
        '
        Me.biRechazar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biRechazar.Image = Global.SIGECOM.My.Resources.Resources.Anular
        Me.biRechazar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biRechazar.Name = "biRechazar"
        Me.biRechazar.Size = New System.Drawing.Size(28, 28)
        Me.biRechazar.Text = "Rechazar Atención de Reclamo Fabrica"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 715)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(683, 20)
        Me.ssBarra.TabIndex = 115
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(300, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbRepuestos
        '
        Me.gbRepuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRepuestos.Controls.Add(Me.TabOpciones)
        Me.gbRepuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRepuestos.Location = New System.Drawing.Point(5, 473)
        Me.gbRepuestos.Name = "gbRepuestos"
        Me.gbRepuestos.Size = New System.Drawing.Size(664, 233)
        Me.gbRepuestos.TabIndex = 117
        Me.gbRepuestos.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbRepuestos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'TabOpciones
        '
        Me.TabOpciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabOpciones.Location = New System.Drawing.Point(9, 19)
        Me.TabOpciones.Name = "TabOpciones"
        Me.TabOpciones.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.TabOpciones.Size = New System.Drawing.Size(645, 209)
        Me.TabOpciones.TabIndex = 118
        Me.TabOpciones.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tbEmpresas, Me.tbRubroRecurso})
        Me.TabOpciones.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'tbEmpresas
        '
        Me.tbEmpresas.Controls.Add(Me.dgvDatos)
        Me.tbEmpresas.Image = CType(resources.GetObject("tbEmpresas.Image"), System.Drawing.Image)
        Me.tbEmpresas.Location = New System.Drawing.Point(1, 23)
        Me.tbEmpresas.Name = "tbEmpresas"
        Me.tbEmpresas.Size = New System.Drawing.Size(643, 185)
        Me.tbEmpresas.TabStop = True
        Me.tbEmpresas.Text = "REPUESTOS"
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 12)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(631, 162)
        Me.dgvDatos.TabIndex = 19
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miCantAtendidaOk, Me.miPrecFabricaOk, Me.miEliminarGuia, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(172, 126)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(171, 22)
        Me.miNuevo.Text = "Ingresar Guía"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miCantAtendidaOk
        '
        Me.miCantAtendidaOk.Image = CType(resources.GetObject("miCantAtendidaOk.Image"), System.Drawing.Image)
        Me.miCantAtendidaOk.Name = "miCantAtendidaOk"
        Me.miCantAtendidaOk.Size = New System.Drawing.Size(171, 22)
        Me.miCantAtendidaOk.Text = "Cant. Atendida Ok"
        '
        'miPrecFabricaOk
        '
        Me.miPrecFabricaOk.Image = CType(resources.GetObject("miPrecFabricaOk.Image"), System.Drawing.Image)
        Me.miPrecFabricaOk.Name = "miPrecFabricaOk"
        Me.miPrecFabricaOk.Size = New System.Drawing.Size(171, 22)
        Me.miPrecFabricaOk.Text = "Prec. Fabrica Ok"
        '
        'miEliminarGuia
        '
        Me.miEliminarGuia.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarGuia.Name = "miEliminarGuia"
        Me.miEliminarGuia.Size = New System.Drawing.Size(171, 22)
        Me.miEliminarGuia.Text = "Eliminar Guía"
        Me.miEliminarGuia.ToolTipText = "Eliminar Detalle"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(168, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(168, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(171, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'tbRubroRecurso
        '
        Me.tbRubroRecurso.Controls.Add(Me.dgvManoObra)
        Me.tbRubroRecurso.Icon = CType(resources.GetObject("tbRubroRecurso.Icon"), System.Drawing.Icon)
        Me.tbRubroRecurso.Location = New System.Drawing.Point(1, 23)
        Me.tbRubroRecurso.Name = "tbRubroRecurso"
        Me.tbRubroRecurso.Size = New System.Drawing.Size(636, 179)
        Me.tbRubroRecurso.TabStop = True
        Me.tbRubroRecurso.Text = "MANO DE OBRA"
        '
        'dgvManoObra
        '
        Me.dgvManoObra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvManoObra.ContextMenuStrip = Me.cmOpcionesMO
        dgvManoObra_DesignTimeLayout.LayoutString = resources.GetString("dgvManoObra_DesignTimeLayout.LayoutString")
        Me.dgvManoObra.DesignTimeLayout = dgvManoObra_DesignTimeLayout
        Me.dgvManoObra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvManoObra.GroupByBoxVisible = False
        Me.dgvManoObra.Location = New System.Drawing.Point(6, 12)
        Me.dgvManoObra.Name = "dgvManoObra"
        Me.dgvManoObra.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvManoObra.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvManoObra.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvManoObra.Size = New System.Drawing.Size(624, 156)
        Me.dgvManoObra.TabIndex = 20
        Me.dgvManoObra.TabStop = False
        Me.dgvManoObra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpcionesMO
        '
        Me.cmOpcionesMO.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoMO, Me.miMostrarMO, Me.miEliminarMO, Me.ToolStripSeparator7, Me.miImprimir, Me.miActualizarMO})
        Me.cmOpcionesMO.Name = "cmOpciones"
        Me.cmOpcionesMO.Size = New System.Drawing.Size(127, 120)
        '
        'miNuevoMO
        '
        Me.miNuevoMO.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoMO.Name = "miNuevoMO"
        Me.miNuevoMO.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoMO.Text = "Nuevo"
        Me.miNuevoMO.ToolTipText = "Nuevo"
        '
        'miMostrarMO
        '
        Me.miMostrarMO.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarMO.Name = "miMostrarMO"
        Me.miMostrarMO.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarMO.Text = "Mostrar"
        '
        'miEliminarMO
        '
        Me.miEliminarMO.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarMO.Name = "miEliminarMO"
        Me.miEliminarMO.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarMO.Text = "Eliminar"
        Me.miEliminarMO.ToolTipText = "Eliminar"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(123, 6)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora1
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(126, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miActualizarMO
        '
        Me.miActualizarMO.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarMO.Name = "miActualizarMO"
        Me.miActualizarMO.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarMO.Text = "Actualizar"
        Me.miActualizarMO.ToolTipText = "Refrescar Lista Detalles"
        '
        'btnAsignarSistemas
        '
        Me.btnAsignarSistemas.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnAsignarSistemas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignarSistemas.Location = New System.Drawing.Point(515, 16)
        Me.btnAsignarSistemas.Name = "btnAsignarSistemas"
        Me.btnAsignarSistemas.Size = New System.Drawing.Size(114, 27)
        Me.btnAsignarSistemas.TabIndex = 51
        Me.btnAsignarSistemas.Text = "Asignar Sistemas"
        Me.btnAsignarSistemas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignarSistemas.UseVisualStyleBackColor = True
        '
        'dgvSistemas
        '
        Me.dgvSistemas.AllowCardSizing = False
        Me.dgvSistemas.AllowColumnDrag = False
        Me.dgvSistemas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvSistemas.AlternatingColors = True
        dgvSistemas_DesignTimeLayout.LayoutString = resources.GetString("dgvSistemas_DesignTimeLayout.LayoutString")
        Me.dgvSistemas.DesignTimeLayout = dgvSistemas_DesignTimeLayout
        Me.dgvSistemas.EmptyRows = True
        Me.dgvSistemas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSistemas.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvSistemas.GroupByBoxVisible = False
        Me.dgvSistemas.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvSistemas.Location = New System.Drawing.Point(27, 25)
        Me.dgvSistemas.Name = "dgvSistemas"
        Me.dgvSistemas.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvSistemas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvSistemas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvSistemas.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvSistemas.Size = New System.Drawing.Size(467, 179)
        Me.dgvSistemas.TabIndex = 50
        Me.dgvSistemas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ckVerPrecios
        '
        Me.ckVerPrecios.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckVerPrecios.Enabled = False
        Me.ckVerPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerPrecios.Location = New System.Drawing.Point(376, 163)
        Me.ckVerPrecios.Name = "ckVerPrecios"
        Me.ckVerPrecios.Size = New System.Drawing.Size(87, 16)
        Me.ckVerPrecios.TabIndex = 16
        Me.ckVerPrecios.Text = "Ver Precios"
        Me.ckVerPrecios.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckVendeOficina
        '
        Me.ckVendeOficina.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckVendeOficina.Enabled = False
        Me.ckVendeOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVendeOficina.Location = New System.Drawing.Point(120, 187)
        Me.ckVendeOficina.Name = "ckVendeOficina"
        Me.ckVendeOficina.Size = New System.Drawing.Size(127, 16)
        Me.ckVendeOficina.TabIndex = 15
        Me.ckVendeOficina.Text = "Venta Solo Oficina"
        Me.ckVendeOficina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckGastoGerencia
        '
        Me.ckGastoGerencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckGastoGerencia.Enabled = False
        Me.ckGastoGerencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckGastoGerencia.Location = New System.Drawing.Point(120, 163)
        Me.ckGastoGerencia.Name = "ckGastoGerencia"
        Me.ckGastoGerencia.Size = New System.Drawing.Size(161, 16)
        Me.ckGastoGerencia.TabIndex = 14
        Me.ckGastoGerencia.Text = "Procesa Gasto Gerencia"
        Me.ckGastoGerencia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckPrecioFlete
        '
        Me.ckPrecioFlete.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckPrecioFlete.Enabled = False
        Me.ckPrecioFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPrecioFlete.Location = New System.Drawing.Point(120, 139)
        Me.ckPrecioFlete.Name = "ckPrecioFlete"
        Me.ckPrecioFlete.Size = New System.Drawing.Size(139, 16)
        Me.ckPrecioFlete.TabIndex = 13
        Me.ckPrecioFlete.Text = "Ingresa Precio Flete"
        Me.ckPrecioFlete.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckVerGastos
        '
        Me.ckVerGastos.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckVerGastos.Enabled = False
        Me.ckVerGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerGastos.Location = New System.Drawing.Point(376, 187)
        Me.ckVerGastos.Name = "ckVerGastos"
        Me.ckVerGastos.Size = New System.Drawing.Size(87, 16)
        Me.ckVerGastos.TabIndex = 12
        Me.ckVerGastos.Text = "Ver Gastos"
        Me.ckVerGastos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtPerfil
        '
        Me.txtPerfil.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtPerfil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPerfil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPerfil.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtPerfil.Location = New System.Drawing.Point(178, 9)
        Me.txtPerfil.Name = "txtPerfil"
        Me.txtPerfil.Size = New System.Drawing.Size(350, 20)
        Me.txtPerfil.TabIndex = 11
        '
        'gbFacturacion
        '
        Me.gbFacturacion.BackColor = System.Drawing.Color.Transparent
        Me.gbFacturacion.Controls.Add(Me.rbTipFacTodos)
        Me.gbFacturacion.Controls.Add(Me.rbTipFacCon)
        Me.gbFacturacion.Controls.Add(Me.rbTipFacCre)
        Me.gbFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFacturacion.Location = New System.Drawing.Point(356, 46)
        Me.gbFacturacion.Name = "gbFacturacion"
        Me.gbFacturacion.Size = New System.Drawing.Size(172, 105)
        Me.gbFacturacion.TabIndex = 9
        Me.gbFacturacion.Text = "Tipo de Facturación"
        Me.gbFacturacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTipFacTodos
        '
        Me.rbTipFacTodos.AutoSize = True
        Me.rbTipFacTodos.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.rbTipFacTodos.Enabled = False
        Me.rbTipFacTodos.Location = New System.Drawing.Point(20, 22)
        Me.rbTipFacTodos.Name = "rbTipFacTodos"
        Me.rbTipFacTodos.Size = New System.Drawing.Size(60, 17)
        Me.rbTipFacTodos.TabIndex = 2
        Me.rbTipFacTodos.TabStop = True
        Me.rbTipFacTodos.Text = "Todos"
        Me.rbTipFacTodos.UseVisualStyleBackColor = False
        '
        'rbTipFacCon
        '
        Me.rbTipFacCon.AutoSize = True
        Me.rbTipFacCon.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.rbTipFacCon.Enabled = False
        Me.rbTipFacCon.Location = New System.Drawing.Point(20, 76)
        Me.rbTipFacCon.Name = "rbTipFacCon"
        Me.rbTipFacCon.Size = New System.Drawing.Size(133, 17)
        Me.rbTipFacCon.TabIndex = 1
        Me.rbTipFacCon.TabStop = True
        Me.rbTipFacCon.Text = "Factura al Contado"
        Me.rbTipFacCon.UseVisualStyleBackColor = False
        '
        'rbTipFacCre
        '
        Me.rbTipFacCre.AutoSize = True
        Me.rbTipFacCre.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.rbTipFacCre.Enabled = False
        Me.rbTipFacCre.Location = New System.Drawing.Point(20, 49)
        Me.rbTipFacCre.Name = "rbTipFacCre"
        Me.rbTipFacCre.Size = New System.Drawing.Size(126, 17)
        Me.rbTipFacCre.TabIndex = 0
        Me.rbTipFacCre.TabStop = True
        Me.rbTipFacCre.Text = "Factura al Crédito"
        Me.rbTipFacCre.UseVisualStyleBackColor = False
        '
        'ckPerPrecioFOB
        '
        Me.ckPerPrecioFOB.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckPerPrecioFOB.Enabled = False
        Me.ckPerPrecioFOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPerPrecioFOB.Location = New System.Drawing.Point(120, 115)
        Me.ckPerPrecioFOB.Name = "ckPerPrecioFOB"
        Me.ckPerPrecioFOB.Size = New System.Drawing.Size(193, 16)
        Me.ckPerPrecioFOB.TabIndex = 8
        Me.ckPerPrecioFOB.Text = "Puede Modificar Precio FOB?"
        Me.ckPerPrecioFOB.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckPerPrecio
        '
        Me.ckPerPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckPerPrecio.Enabled = False
        Me.ckPerPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPerPrecio.Location = New System.Drawing.Point(120, 92)
        Me.ckPerPrecio.Name = "ckPerPrecio"
        Me.ckPerPrecio.Size = New System.Drawing.Size(170, 15)
        Me.ckPerPrecio.TabIndex = 7
        Me.ckPerPrecio.Text = "Puede Modificar Precios?"
        Me.ckPerPrecio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckCartera
        '
        Me.ckCartera.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckCartera.Enabled = False
        Me.ckCartera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCartera.Location = New System.Drawing.Point(120, 69)
        Me.ckCartera.Name = "ckCartera"
        Me.ckCartera.Size = New System.Drawing.Size(107, 15)
        Me.ckCartera.TabIndex = 3
        Me.ckCartera.Text = "Tiene Cartera?"
        Me.ckCartera.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(117, 12)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(58, 13)
        Me.Label27.TabIndex = 1
        Me.Label27.Text = "PERFIL :"
        '
        'ckTipCam
        '
        Me.ckTipCam.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ckTipCam.Enabled = False
        Me.ckTipCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckTipCam.Location = New System.Drawing.Point(120, 46)
        Me.ckTipCam.Name = "ckTipCam"
        Me.ckTipCam.Size = New System.Drawing.Size(170, 15)
        Me.ckTipCam.TabIndex = 0
        Me.ckTipCam.Text = "Ingresa Tipo de Cambio ?"
        Me.ckTipCam.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAsignarLocaciones
        '
        Me.btnAsignarLocaciones.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnAsignarLocaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignarLocaciones.Location = New System.Drawing.Point(537, 3)
        Me.btnAsignarLocaciones.Name = "btnAsignarLocaciones"
        Me.btnAsignarLocaciones.Size = New System.Drawing.Size(124, 27)
        Me.btnAsignarLocaciones.TabIndex = 52
        Me.btnAsignarLocaciones.Text = "Asignar Locaciones"
        Me.btnAsignarLocaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignarLocaciones.UseVisualStyleBackColor = True
        '
        'dgvLocaciones
        '
        Me.dgvLocaciones.AllowCardSizing = False
        Me.dgvLocaciones.AllowColumnDrag = False
        Me.dgvLocaciones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvLocaciones.AlternatingColors = True
        dgvLocaciones_DesignTimeLayout.LayoutString = resources.GetString("dgvLocaciones_DesignTimeLayout.LayoutString")
        Me.dgvLocaciones.DesignTimeLayout = dgvLocaciones_DesignTimeLayout
        Me.dgvLocaciones.EmptyRows = True
        Me.dgvLocaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvLocaciones.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvLocaciones.GroupByBoxVisible = False
        Me.dgvLocaciones.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvLocaciones.Location = New System.Drawing.Point(11, 37)
        Me.dgvLocaciones.Name = "dgvLocaciones"
        Me.dgvLocaciones.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvLocaciones.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvLocaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvLocaciones.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvLocaciones.Size = New System.Drawing.Size(649, 173)
        Me.dgvLocaciones.TabIndex = 51
        Me.dgvLocaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnAsignarCentrosCosto
        '
        Me.btnAsignarCentrosCosto.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnAsignarCentrosCosto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignarCentrosCosto.Location = New System.Drawing.Point(515, 4)
        Me.btnAsignarCentrosCosto.Name = "btnAsignarCentrosCosto"
        Me.btnAsignarCentrosCosto.Size = New System.Drawing.Size(150, 27)
        Me.btnAsignarCentrosCosto.TabIndex = 52
        Me.btnAsignarCentrosCosto.Text = "Asignar Centros de Costo"
        Me.btnAsignarCentrosCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAsignarCentrosCosto.UseVisualStyleBackColor = True
        '
        'dgvCentroCosto
        '
        Me.dgvCentroCosto.AllowCardSizing = False
        Me.dgvCentroCosto.AllowColumnDrag = False
        Me.dgvCentroCosto.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvCentroCosto.AlternatingColors = True
        dgvCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("dgvCentroCosto_DesignTimeLayout.LayoutString")
        Me.dgvCentroCosto.DesignTimeLayout = dgvCentroCosto_DesignTimeLayout
        Me.dgvCentroCosto.EmptyRows = True
        Me.dgvCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCentroCosto.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvCentroCosto.GroupByBoxVisible = False
        Me.dgvCentroCosto.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvCentroCosto.Location = New System.Drawing.Point(4, 35)
        Me.dgvCentroCosto.Name = "dgvCentroCosto"
        Me.dgvCentroCosto.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCentroCosto.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCentroCosto.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCentroCosto.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCentroCosto.Size = New System.Drawing.Size(660, 173)
        Me.dgvCentroCosto.TabIndex = 51
        Me.dgvCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmSolicitudGarantia_Detalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(683, 735)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gbRepuestos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolicitudGarantia_Detalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atención de Formato de ORDEN DE REPARACIÓN"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.gbRepuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRepuestos.ResumeLayout(False)
        CType(Me.TabOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabOpciones.ResumeLayout(False)
        Me.tbEmpresas.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.tbRubroRecurso.ResumeLayout(False)
        CType(Me.dgvManoObra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesMO.ResumeLayout(False)
        CType(Me.dgvSistemas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFacturacion.ResumeLayout(False)
        Me.gbFacturacion.PerformLayout()
        CType(Me.dgvLocaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtCreditState As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumClaim As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotRepuestosAtendido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotManoObraAtendido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHorasManoObraAtendido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHorasViajeAtendido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotViajeAtendido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMillasDistanciaAtendido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotDistanciaAtendido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtNumDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents cbCobrado As System.Windows.Forms.CheckBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbDocumento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbRepuestos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarGuia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCantAtendidaOk As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miPrecFabricaOk As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbRechazado As System.Windows.Forms.CheckBox
    Friend WithEvents biAtender As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biRechazar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaCredit As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtHorasManoObraRec As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTotManoObraRec As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtHorasViajeRec As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotViajeRec As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotRepuestosRec As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMillasDistanciaRec As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTotDistanciaRec As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cbAtendido As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotRepuestosCli As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTotalMontoAtendido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtTotalMontoReclamado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotNetItem As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtTotNetItemRec As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TabOpciones As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tbEmpresas As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tbRubroRecurso As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvManoObra As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpcionesMO As ContextMenuStrip
    Friend WithEvents miNuevoMO As ToolStripMenuItem
    Friend WithEvents miMostrarMO As ToolStripMenuItem
    Friend WithEvents miEliminarMO As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents miActualizarMO As ToolStripMenuItem
    Friend WithEvents btnAsignarSistemas As Button
    Friend WithEvents dgvSistemas As Janus.Windows.GridEX.GridEX
    Friend WithEvents ckVerPrecios As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckVendeOficina As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckGastoGerencia As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckPrecioFlete As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckVerGastos As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents txtPerfil As TextBox
    Friend WithEvents gbFacturacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTipFacTodos As RadioButton
    Friend WithEvents rbTipFacCon As RadioButton
    Friend WithEvents rbTipFacCre As RadioButton
    Friend WithEvents ckPerPrecioFOB As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckPerPrecio As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckCartera As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents Label27 As Label
    Friend WithEvents ckTipCam As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents btnAsignarLocaciones As Button
    Friend WithEvents dgvLocaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnAsignarCentrosCosto As Button
    Friend WithEvents dgvCentroCosto As Janus.Windows.GridEX.GridEX
    Friend WithEvents miImprimir As ToolStripMenuItem
    Friend WithEvents txtTotOtros As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtTotOtrosRec As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label28 As Label
End Class
