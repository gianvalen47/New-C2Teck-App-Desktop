<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidosImportacion_Facturar
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
        Dim cmbIdFiscalShip_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidosImportacion_Facturar))
        Dim cmbIdFiscalSold_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMedio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodPag_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmbIdFiscalShip = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscarProvider = New System.Windows.Forms.Button()
        Me.txtProvider = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbIdFiscalSold = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbMedio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtShip = New System.Windows.Forms.TextBox()
        Me.btnBuscarShip = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTerms = New System.Windows.Forms.TextBox()
        Me.txtOrders = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMarks = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtSold = New System.Windows.Forms.TextBox()
        Me.btnBuscarSold = New System.Windows.Forms.Button()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbPrecios = New System.Windows.Forms.GroupBox()
        Me.txttipocambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lbltipocambio = New System.Windows.Forms.Label()
        Me.txtmoneda = New System.Windows.Forms.TextBox()
        Me.lblmoneda = New System.Windows.Forms.Label()
        Me.txtOtrosGastos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtFleInt = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbCodPag = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtFecLlegadaMiami = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtNroPqte = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.dgvPrueba = New System.Windows.Forms.DataGridView()
        Me.IdDetPedidoImp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPedidoImp1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesMer1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodPar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodPais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodUniMedPes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanRec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PreMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPedidoDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPedido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanFac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PenFac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despacho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeterCEROTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        CType(Me.cmbIdFiscalShip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdFiscalSold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPrecios.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPrueba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbIdFiscalShip
        '
        Me.cmbIdFiscalShip.BackColor = System.Drawing.SystemColors.Control
        Me.cmbIdFiscalShip.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdFiscalShip_DesignTimeLayout.LayoutString = resources.GetString("cmbIdFiscalShip_DesignTimeLayout.LayoutString")
        Me.cmbIdFiscalShip.DesignTimeLayout = cmbIdFiscalShip_DesignTimeLayout
        Me.cmbIdFiscalShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdFiscalShip.Location = New System.Drawing.Point(371, 60)
        Me.cmbIdFiscalShip.Name = "cmbIdFiscalShip"
        Me.cmbIdFiscalShip.SelectedIndex = -1
        Me.cmbIdFiscalShip.SelectedItem = Nothing
        Me.cmbIdFiscalShip.Size = New System.Drawing.Size(327, 20)
        Me.cmbIdFiscalShip.TabIndex = 48
        Me.cmbIdFiscalShip.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarProvider
        '
        Me.btnBuscarProvider.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProvider.Location = New System.Drawing.Point(324, 80)
        Me.btnBuscarProvider.Name = "btnBuscarProvider"
        Me.btnBuscarProvider.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProvider.TabIndex = 10
        Me.btnBuscarProvider.TabStop = False
        Me.btnBuscarProvider.UseVisualStyleBackColor = True
        '
        'txtProvider
        '
        Me.txtProvider.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvider.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProvider.Location = New System.Drawing.Point(62, 81)
        Me.txtProvider.MaxLength = 3
        Me.txtProvider.Name = "txtProvider"
        Me.txtProvider.ReadOnly = True
        Me.txtProvider.Size = New System.Drawing.Size(262, 20)
        Me.txtProvider.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Provider"
        '
        'cmbIdFiscalSold
        '
        Me.cmbIdFiscalSold.BackColor = System.Drawing.SystemColors.Control
        Me.cmbIdFiscalSold.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdFiscalSold_DesignTimeLayout.LayoutString = resources.GetString("cmbIdFiscalSold_DesignTimeLayout.LayoutString")
        Me.cmbIdFiscalSold.DesignTimeLayout = cmbIdFiscalSold_DesignTimeLayout
        Me.cmbIdFiscalSold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdFiscalSold.Location = New System.Drawing.Point(371, 39)
        Me.cmbIdFiscalSold.Name = "cmbIdFiscalSold"
        Me.cmbIdFiscalSold.SelectedIndex = -1
        Me.cmbIdFiscalSold.SelectedItem = Nothing
        Me.cmbIdFiscalSold.Size = New System.Drawing.Size(327, 20)
        Me.cmbIdFiscalSold.TabIndex = 46
        Me.cmbIdFiscalSold.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbMedio
        '
        Me.cmbMedio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMedio_DesignTimeLayout.LayoutString = resources.GetString("cmbMedio_DesignTimeLayout.LayoutString")
        Me.cmbMedio.DesignTimeLayout = cmbMedio_DesignTimeLayout
        Me.cmbMedio.Location = New System.Drawing.Point(587, 17)
        Me.cmbMedio.Name = "cmbMedio"
        Me.cmbMedio.SelectedIndex = -1
        Me.cmbMedio.SelectedItem = Nothing
        Me.cmbMedio.Size = New System.Drawing.Size(111, 20)
        Me.cmbMedio.TabIndex = 3
        Me.cmbMedio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(546, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Medio"
        '
        'txtShip
        '
        Me.txtShip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShip.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtShip.Location = New System.Drawing.Point(62, 60)
        Me.txtShip.MaxLength = 3
        Me.txtShip.Name = "txtShip"
        Me.txtShip.ReadOnly = True
        Me.txtShip.Size = New System.Drawing.Size(262, 20)
        Me.txtShip.TabIndex = 7
        '
        'btnBuscarShip
        '
        Me.btnBuscarShip.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarShip.Location = New System.Drawing.Point(324, 59)
        Me.btnBuscarShip.Name = "btnBuscarShip"
        Me.btnBuscarShip.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarShip.TabIndex = 8
        Me.btnBuscarShip.TabStop = False
        Me.btnBuscarShip.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Ship to"
        '
        'txtTerms
        '
        Me.txtTerms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTerms.Location = New System.Drawing.Point(62, 102)
        Me.txtTerms.MaxLength = 50
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.Size = New System.Drawing.Size(287, 20)
        Me.txtTerms.TabIndex = 11
        '
        'txtOrders
        '
        Me.txtOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrders.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtOrders.Location = New System.Drawing.Point(416, 102)
        Me.txtOrders.MaxLength = 50
        Me.txtOrders.Name = "txtOrders"
        Me.txtOrders.Size = New System.Drawing.Size(282, 20)
        Me.txtOrders.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(374, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Orders"
        '
        'txtMarks
        '
        Me.txtMarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarks.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMarks.Location = New System.Drawing.Point(416, 81)
        Me.txtMarks.MaxLength = 50
        Me.txtMarks.Name = "txtMarks"
        Me.txtMarks.Size = New System.Drawing.Size(282, 20)
        Me.txtMarks.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(374, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Marks"
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Location = New System.Drawing.Point(251, 17)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.Size = New System.Drawing.Size(98, 20)
        Me.txtFecDoc.TabIndex = 1
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtSold
        '
        Me.txtSold.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSold.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtSold.Location = New System.Drawing.Point(62, 39)
        Me.txtSold.MaxLength = 3
        Me.txtSold.Name = "txtSold"
        Me.txtSold.ReadOnly = True
        Me.txtSold.Size = New System.Drawing.Size(262, 20)
        Me.txtSold.TabIndex = 4
        '
        'btnBuscarSold
        '
        Me.btnBuscarSold.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarSold.Location = New System.Drawing.Point(324, 38)
        Me.btnBuscarSold.Name = "btnBuscarSold"
        Me.btnBuscarSold.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarSold.TabIndex = 5
        Me.btnBuscarSold.TabStop = False
        Me.btnBuscarSold.UseVisualStyleBackColor = True
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.Color.Beige
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(66, 17)
        Me.txtNumDoc.MaxLength = 18
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(126, 20)
        Me.txtNumDoc.TabIndex = 0
        Me.txtNumDoc.TabStop = False
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(209, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Fecha"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Terms"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Sold to"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Invoice"
        '
        'gbPrecios
        '
        Me.gbPrecios.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbPrecios.Controls.Add(Me.txttipocambio)
        Me.gbPrecios.Controls.Add(Me.lbltipocambio)
        Me.gbPrecios.Controls.Add(Me.txtmoneda)
        Me.gbPrecios.Controls.Add(Me.lblmoneda)
        Me.gbPrecios.Controls.Add(Me.txtOtrosGastos)
        Me.gbPrecios.Controls.Add(Me.Label16)
        Me.gbPrecios.Controls.Add(Me.txtFleInt)
        Me.gbPrecios.Controls.Add(Me.Label5)
        Me.gbPrecios.Location = New System.Drawing.Point(9, 148)
        Me.gbPrecios.Name = "gbPrecios"
        Me.gbPrecios.Size = New System.Drawing.Size(489, 82)
        Me.gbPrecios.TabIndex = 14
        Me.gbPrecios.TabStop = False
        Me.gbPrecios.Text = "Costos"
        '
        'txttipocambio
        '
        Me.txttipocambio.DecimalDigits = 3
        Me.txttipocambio.Location = New System.Drawing.Point(139, 47)
        Me.txttipocambio.MaxLength = 12
        Me.txttipocambio.Name = "txttipocambio"
        Me.txttipocambio.Size = New System.Drawing.Size(54, 20)
        Me.txttipocambio.TabIndex = 278
        Me.txttipocambio.Text = "0.000"
        Me.txttipocambio.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'lbltipocambio
        '
        Me.lbltipocambio.AutoSize = True
        Me.lbltipocambio.Location = New System.Drawing.Point(40, 50)
        Me.lbltipocambio.Name = "lbltipocambio"
        Me.lbltipocambio.Size = New System.Drawing.Size(95, 13)
        Me.lbltipocambio.TabIndex = 279
        Me.lbltipocambio.Text = "Tipo de Cambio"
        '
        'txtmoneda
        '
        Me.txtmoneda.BackColor = System.Drawing.SystemColors.Window
        Me.txtmoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmoneda.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtmoneda.Location = New System.Drawing.Point(140, 19)
        Me.txtmoneda.MaxLength = 50
        Me.txtmoneda.Name = "txtmoneda"
        Me.txtmoneda.ReadOnly = True
        Me.txtmoneda.Size = New System.Drawing.Size(52, 20)
        Me.txtmoneda.TabIndex = 276
        '
        'lblmoneda
        '
        Me.lblmoneda.AutoSize = True
        Me.lblmoneda.Location = New System.Drawing.Point(41, 22)
        Me.lblmoneda.Name = "lblmoneda"
        Me.lblmoneda.Size = New System.Drawing.Size(52, 13)
        Me.lblmoneda.TabIndex = 277
        Me.lblmoneda.Text = "Moneda"
        '
        'txtOtrosGastos
        '
        Me.txtOtrosGastos.Location = New System.Drawing.Point(361, 47)
        Me.txtOtrosGastos.MaxLength = 12
        Me.txtOtrosGastos.Name = "txtOtrosGastos"
        Me.txtOtrosGastos.Size = New System.Drawing.Size(100, 20)
        Me.txtOtrosGastos.TabIndex = 5
        Me.txtOtrosGastos.Text = "0.00"
        Me.txtOtrosGastos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(275, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Otros Gastos"
        '
        'txtFleInt
        '
        Me.txtFleInt.Location = New System.Drawing.Point(361, 18)
        Me.txtFleInt.MaxLength = 12
        Me.txtFleInt.Name = "txtFleInt"
        Me.txtFleInt.Size = New System.Drawing.Size(100, 20)
        Me.txtFleInt.TabIndex = 0
        Me.txtFleInt.Text = "0.00"
        Me.txtFleInt.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(276, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Flete Interno"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicacion.Location = New System.Drawing.Point(301, 7)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(80, 15)
        Me.lblUbicacion.TabIndex = 16
        Me.lblUbicacion.Text = "Documento"
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.cmbCodPag)
        Me.gbDatosBusqueda.Controls.Add(Me.Label20)
        Me.gbDatosBusqueda.Controls.Add(Me.Label19)
        Me.gbDatosBusqueda.Controls.Add(Me.txtFecLlegadaMiami)
        Me.gbDatosBusqueda.Controls.Add(Me.txtNroPqte)
        Me.gbDatosBusqueda.Controls.Add(Me.Label18)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbIdFiscalShip)
        Me.gbDatosBusqueda.Controls.Add(Me.Label1)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscarProvider)
        Me.gbDatosBusqueda.Controls.Add(Me.gbPrecios)
        Me.gbDatosBusqueda.Controls.Add(Me.txtProvider)
        Me.gbDatosBusqueda.Controls.Add(Me.Label13)
        Me.gbDatosBusqueda.Controls.Add(Me.Label12)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbIdFiscalSold)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbMedio)
        Me.gbDatosBusqueda.Controls.Add(Me.Label8)
        Me.gbDatosBusqueda.Controls.Add(Me.Label3)
        Me.gbDatosBusqueda.Controls.Add(Me.Label15)
        Me.gbDatosBusqueda.Controls.Add(Me.txtShip)
        Me.gbDatosBusqueda.Controls.Add(Me.txtNumDoc)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscarShip)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscarSold)
        Me.gbDatosBusqueda.Controls.Add(Me.Label9)
        Me.gbDatosBusqueda.Controls.Add(Me.txtSold)
        Me.gbDatosBusqueda.Controls.Add(Me.txtFecDoc)
        Me.gbDatosBusqueda.Controls.Add(Me.txtTerms)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.txtOrders)
        Me.gbDatosBusqueda.Controls.Add(Me.txtMarks)
        Me.gbDatosBusqueda.Controls.Add(Me.Label4)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(4, 34)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(708, 239)
        Me.gbDatosBusqueda.TabIndex = 17
        Me.gbDatosBusqueda.Text = "Datos del Pedido de Importación"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbCodPag
        '
        Me.cmbCodPag.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodPag_DesignTimeLayout.LayoutString = resources.GetString("cmbCodPag_DesignTimeLayout.LayoutString")
        Me.cmbCodPag.DesignTimeLayout = cmbCodPag_DesignTimeLayout
        Me.cmbCodPag.Location = New System.Drawing.Point(89, 124)
        Me.cmbCodPag.Name = "cmbCodPag"
        Me.cmbCodPag.SelectedIndex = -1
        Me.cmbCodPag.SelectedItem = Nothing
        Me.cmbCodPag.Size = New System.Drawing.Size(188, 20)
        Me.cmbCodPag.TabIndex = 286
        Me.cmbCodPag.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(15, 128)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 13)
        Me.Label20.TabIndex = 287
        Me.Label20.Text = "Cond. Pago"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(462, 129)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(138, 13)
        Me.Label19.TabIndex = 283
        Me.Label19.Text = "Fecha Llegada a Miami"
        '
        'txtFecLlegadaMiami
        '
        '
        '
        '
        Me.txtFecLlegadaMiami.DropDownCalendar.FirstMonth = New Date(2014, 5, 1, 0, 0, 0, 0)
        Me.txtFecLlegadaMiami.DropDownCalendar.Name = ""
        Me.txtFecLlegadaMiami.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecLlegadaMiami.Location = New System.Drawing.Point(606, 125)
        Me.txtFecLlegadaMiami.Name = "txtFecLlegadaMiami"
        Me.txtFecLlegadaMiami.Size = New System.Drawing.Size(92, 20)
        Me.txtFecLlegadaMiami.TabIndex = 282
        Me.txtFecLlegadaMiami.Value = New Date(2014, 5, 13, 0, 0, 0, 0)
        Me.txtFecLlegadaMiami.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtNroPqte
        '
        Me.txtNroPqte.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroPqte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroPqte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroPqte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNroPqte.Location = New System.Drawing.Point(366, 124)
        Me.txtNroPqte.MaxLength = 50
        Me.txtNroPqte.Name = "txtNroPqte"
        Me.txtNroPqte.Size = New System.Drawing.Size(92, 20)
        Me.txtNroPqte.TabIndex = 274
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(281, 127)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 275
        Me.Label18.Text = "Nro. Paquete"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(537, 520)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(84, 29)
        Me.btnAceptar.TabIndex = 18
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(628, 520)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(84, 29)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'dgvPrueba
        '
        Me.dgvPrueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrueba.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDetPedidoImp, Me.IdPedidoImp1, Me.CodMer, Me.DesMer1, Me.CanMer, Me.CanStock, Me.CodMar, Me.CodPar, Me.CodPais, Me.PesMer, Me.CodUniMedPes, Me.CanRec, Me.PreMer, Me.Total, Me.Destino, Me.Observacion, Me.IdPedidoDet, Me.IdPedido, Me.CanFac, Me.PenFac, Me.Despacho})
        Me.dgvPrueba.ContextMenuStrip = Me.cmOpciones
        Me.dgvPrueba.Location = New System.Drawing.Point(4, 288)
        Me.dgvPrueba.Name = "dgvPrueba"
        Me.dgvPrueba.Size = New System.Drawing.Size(708, 215)
        Me.dgvPrueba.TabIndex = 21
        '
        'IdDetPedidoImp
        '
        Me.IdDetPedidoImp.DataPropertyName = "IdDetPedidoImp"
        Me.IdDetPedidoImp.HeaderText = "IdDetPedidoImp"
        Me.IdDetPedidoImp.Name = "IdDetPedidoImp"
        Me.IdDetPedidoImp.Visible = False
        '
        'IdPedidoImp1
        '
        Me.IdPedidoImp1.DataPropertyName = "IdPedidoImp"
        Me.IdPedidoImp1.HeaderText = "IdPedidoImp"
        Me.IdPedidoImp1.Name = "IdPedidoImp1"
        Me.IdPedidoImp1.Visible = False
        '
        'CodMer
        '
        Me.CodMer.DataPropertyName = "CodMer"
        Me.CodMer.HeaderText = "Código"
        Me.CodMer.Name = "CodMer"
        Me.CodMer.Width = 110
        '
        'DesMer1
        '
        Me.DesMer1.DataPropertyName = "DesMer1"
        Me.DesMer1.HeaderText = "Descripción"
        Me.DesMer1.Name = "DesMer1"
        Me.DesMer1.Width = 240
        '
        'CanMer
        '
        Me.CanMer.DataPropertyName = "CanMer"
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Me.CanMer.DefaultCellStyle = DataGridViewCellStyle1
        Me.CanMer.HeaderText = "Cant."
        Me.CanMer.Name = "CanMer"
        Me.CanMer.Width = 55
        '
        'CanStock
        '
        Me.CanStock.DataPropertyName = "CanStock"
        Me.CanStock.HeaderText = "Stock"
        Me.CanStock.Name = "CanStock"
        Me.CanStock.ReadOnly = True
        Me.CanStock.Width = 55
        '
        'CodMar
        '
        Me.CodMar.DataPropertyName = "CodMar"
        Me.CodMar.HeaderText = "CodMar"
        Me.CodMar.Name = "CodMar"
        Me.CodMar.Visible = False
        '
        'CodPar
        '
        Me.CodPar.DataPropertyName = "CodPar"
        Me.CodPar.HeaderText = "CodPar"
        Me.CodPar.Name = "CodPar"
        Me.CodPar.Visible = False
        '
        'CodPais
        '
        Me.CodPais.DataPropertyName = "CodPais"
        Me.CodPais.HeaderText = "CodPais"
        Me.CodPais.Name = "CodPais"
        Me.CodPais.Visible = False
        '
        'PesMer
        '
        Me.PesMer.DataPropertyName = "PesMer"
        Me.PesMer.HeaderText = "PesMer"
        Me.PesMer.Name = "PesMer"
        Me.PesMer.Visible = False
        '
        'CodUniMedPes
        '
        Me.CodUniMedPes.DataPropertyName = "CodUniMedPes"
        Me.CodUniMedPes.HeaderText = "CodUniMedPes"
        Me.CodUniMedPes.Name = "CodUniMedPes"
        Me.CodUniMedPes.Visible = False
        '
        'CanRec
        '
        Me.CanRec.DataPropertyName = "CanRec"
        Me.CanRec.HeaderText = "CanRec"
        Me.CanRec.Name = "CanRec"
        Me.CanRec.Visible = False
        '
        'PreMer
        '
        Me.PreMer.DataPropertyName = "PreMer"
        Me.PreMer.HeaderText = "PreMer"
        Me.PreMer.Name = "PreMer"
        Me.PreMer.Visible = False
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.Visible = False
        '
        'Destino
        '
        Me.Destino.DataPropertyName = "Destino"
        Me.Destino.HeaderText = "Destino"
        Me.Destino.Name = "Destino"
        Me.Destino.Visible = False
        '
        'Observacion
        '
        Me.Observacion.DataPropertyName = "Observacion"
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.Visible = False
        '
        'IdPedidoDet
        '
        Me.IdPedidoDet.DataPropertyName = "IdPedidoDet"
        Me.IdPedidoDet.HeaderText = "IdPedidoDet"
        Me.IdPedidoDet.Name = "IdPedidoDet"
        Me.IdPedidoDet.Visible = False
        '
        'IdPedido
        '
        Me.IdPedido.DataPropertyName = "IdPedido"
        Me.IdPedido.HeaderText = "IdPedido"
        Me.IdPedido.Name = "IdPedido"
        Me.IdPedido.Visible = False
        '
        'CanFac
        '
        Me.CanFac.DataPropertyName = "CanFac"
        Me.CanFac.HeaderText = "Fact."
        Me.CanFac.Name = "CanFac"
        Me.CanFac.Width = 55
        '
        'PenFac
        '
        Me.PenFac.DataPropertyName = "PenFac"
        Me.PenFac.HeaderText = "Pend."
        Me.PenFac.Name = "PenFac"
        Me.PenFac.Width = 55
        '
        'Despacho
        '
        Me.Despacho.DataPropertyName = "Despacho"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        Me.Despacho.DefaultCellStyle = DataGridViewCellStyle2
        Me.Despacho.HeaderText = "A Desp."
        Me.Despacho.Name = "Despacho"
        Me.Despacho.Width = 72
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodo, Me.miSeterCEROTodos, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(174, 76)
        '
        'miSeleccionarTodo
        '
        Me.miSeleccionarTodo.Image = CType(resources.GetObject("miSeleccionarTodo.Image"), System.Drawing.Image)
        Me.miSeleccionarTodo.Name = "miSeleccionarTodo"
        Me.miSeleccionarTodo.Size = New System.Drawing.Size(173, 22)
        Me.miSeleccionarTodo.Text = "Seleccionar Todos"
        '
        'miSeterCEROTodos
        '
        Me.miSeterCEROTodos.Image = CType(resources.GetObject("miSeterCEROTodos.Image"), System.Drawing.Image)
        Me.miSeterCEROTodos.Name = "miSeterCEROTodos"
        Me.miSeterCEROTodos.Size = New System.Drawing.Size(173, 22)
        Me.miSeterCEROTodos.Text = "Poner en ""0"" todos"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(170, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(173, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'dgvDatos
        '
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(9, 506)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(41, 25)
        Me.dgvDatos.TabIndex = 20
        Me.dgvDatos.Visible = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmPedidosImportacion_Facturar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(725, 563)
        Me.Controls.Add(Me.dgvPrueba)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Controls.Add(Me.lblUbicacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPedidosImportacion_Facturar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generar Factura"
        CType(Me.cmbIdFiscalShip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdFiscalSold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPrecios.ResumeLayout(False)
        Me.gbPrecios.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPrueba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOrders As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMarks As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtSold As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarSold As System.Windows.Forms.Button
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtShip As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarShip As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbMedio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbPrecios As System.Windows.Forms.GroupBox
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProvider As System.Windows.Forms.Button
    Friend WithEvents txtProvider As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbIdFiscalSold As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbIdFiscalShip As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtOtrosGastos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNroPqte As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtFecLlegadaMiami As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents txtFleInt As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbCodPag As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label20 As Label
    Friend WithEvents txtmoneda As TextBox
    Friend WithEvents lblmoneda As Label
    Friend WithEvents txttipocambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbltipocambio As Label
    Friend WithEvents dgvPrueba As DataGridView
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miSeleccionarTodo As ToolStripMenuItem
    Friend WithEvents miSeterCEROTodos As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents miActualizar As ToolStripMenuItem
    Friend WithEvents IdDetPedidoImp As DataGridViewTextBoxColumn
    Friend WithEvents IdPedidoImp1 As DataGridViewTextBoxColumn
    Friend WithEvents CodMer As DataGridViewTextBoxColumn
    Friend WithEvents DesMer1 As DataGridViewTextBoxColumn
    Friend WithEvents CanMer As DataGridViewTextBoxColumn
    Friend WithEvents CanStock As DataGridViewTextBoxColumn
    Friend WithEvents CodMar As DataGridViewTextBoxColumn
    Friend WithEvents CodPar As DataGridViewTextBoxColumn
    Friend WithEvents CodPais As DataGridViewTextBoxColumn
    Friend WithEvents PesMer As DataGridViewTextBoxColumn
    Friend WithEvents CodUniMedPes As DataGridViewTextBoxColumn
    Friend WithEvents CanRec As DataGridViewTextBoxColumn
    Friend WithEvents PreMer As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Destino As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents IdPedidoDet As DataGridViewTextBoxColumn
    Friend WithEvents IdPedido As DataGridViewTextBoxColumn
    Friend WithEvents CanFac As DataGridViewTextBoxColumn
    Friend WithEvents PenFac As DataGridViewTextBoxColumn
    Friend WithEvents Despacho As DataGridViewTextBoxColumn
End Class
