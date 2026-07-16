<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarjetaGerencia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTarjetaGerencia))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcion2 = New System.Windows.Forms.TextBox()
        Me.txtRubro = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodRubro = New System.Windows.Forms.TextBox()
        Me.txtCodPartida = New System.Windows.Forms.TextBox()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPeso = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodTipMov = New System.Windows.Forms.TextBox()
        Me.txtTipMov = New System.Windows.Forms.TextBox()
        Me.txtFabricaUSA = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtCostoUSA = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMostradorUSA = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMostradorNS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCostoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtCostoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtStock = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnBuscarMercaderia = New Janus.Windows.EditControls.UIButton()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblLeyenda = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
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
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo : "
        '
        'txtCodigo
        '
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(115, 48)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(200, 21)
        Me.txtCodigo.TabIndex = 1
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.Control
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(115, 75)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(361, 21)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción : "
        '
        'txtDescripcion2
        '
        Me.txtDescripcion2.BackColor = System.Drawing.SystemColors.Control
        Me.txtDescripcion2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion2.Location = New System.Drawing.Point(115, 98)
        Me.txtDescripcion2.Name = "txtDescripcion2"
        Me.txtDescripcion2.ReadOnly = True
        Me.txtDescripcion2.Size = New System.Drawing.Size(361, 21)
        Me.txtDescripcion2.TabIndex = 4
        '
        'txtRubro
        '
        Me.txtRubro.BackColor = System.Drawing.SystemColors.Control
        Me.txtRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRubro.Location = New System.Drawing.Point(166, 121)
        Me.txtRubro.Name = "txtRubro"
        Me.txtRubro.ReadOnly = True
        Me.txtRubro.Size = New System.Drawing.Size(149, 21)
        Me.txtRubro.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(57, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Rubro : "
        '
        'txtCodRubro
        '
        Me.txtCodRubro.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodRubro.Location = New System.Drawing.Point(115, 121)
        Me.txtCodRubro.Name = "txtCodRubro"
        Me.txtCodRubro.ReadOnly = True
        Me.txtCodRubro.Size = New System.Drawing.Size(41, 21)
        Me.txtCodRubro.TabIndex = 7
        '
        'txtCodPartida
        '
        Me.txtCodPartida.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodPartida.Location = New System.Drawing.Point(115, 144)
        Me.txtCodPartida.Name = "txtCodPartida"
        Me.txtCodPartida.ReadOnly = True
        Me.txtCodPartida.Size = New System.Drawing.Size(41, 21)
        Me.txtCodPartida.TabIndex = 10
        '
        'txtPartida
        '
        Me.txtPartida.BackColor = System.Drawing.SystemColors.Control
        Me.txtPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartida.Location = New System.Drawing.Point(166, 144)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.ReadOnly = True
        Me.txtPartida.Size = New System.Drawing.Size(149, 21)
        Me.txtPartida.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Partida : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Peso (Libras) : "
        '
        'txtPeso
        '
        Me.txtPeso.BackColor = System.Drawing.SystemColors.Control
        Me.txtPeso.DecimalDigits = 4
        Me.txtPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeso.Location = New System.Drawing.Point(115, 168)
        Me.txtPeso.MaxLength = 10
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.ReadOnly = True
        Me.txtPeso.Size = New System.Drawing.Size(95, 21)
        Me.txtPeso.TabIndex = 12
        Me.txtPeso.TabStop = False
        Me.txtPeso.Text = "0.0000"
        Me.txtPeso.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtPeso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(290, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Tipo de Movimiento : "
        '
        'txtCodTipMov
        '
        Me.txtCodTipMov.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodTipMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodTipMov.Location = New System.Drawing.Point(441, 167)
        Me.txtCodTipMov.Name = "txtCodTipMov"
        Me.txtCodTipMov.ReadOnly = True
        Me.txtCodTipMov.Size = New System.Drawing.Size(27, 21)
        Me.txtCodTipMov.TabIndex = 16
        '
        'txtTipMov
        '
        Me.txtTipMov.BackColor = System.Drawing.SystemColors.Control
        Me.txtTipMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipMov.Location = New System.Drawing.Point(468, 167)
        Me.txtTipMov.Name = "txtTipMov"
        Me.txtTipMov.ReadOnly = True
        Me.txtTipMov.Size = New System.Drawing.Size(162, 21)
        Me.txtTipMov.TabIndex = 15
        '
        'txtFabricaUSA
        '
        Me.txtFabricaUSA.BackColor = System.Drawing.SystemColors.Control
        Me.txtFabricaUSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFabricaUSA.Location = New System.Drawing.Point(128, 7)
        Me.txtFabricaUSA.MaxLength = 10
        Me.txtFabricaUSA.Name = "txtFabricaUSA"
        Me.txtFabricaUSA.ReadOnly = True
        Me.txtFabricaUSA.Size = New System.Drawing.Size(107, 21)
        Me.txtFabricaUSA.TabIndex = 17
        Me.txtFabricaUSA.TabStop = False
        Me.txtFabricaUSA.Text = "0.00"
        Me.txtFabricaUSA.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtFabricaUSA.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCostoUSA
        '
        Me.txtCostoUSA.BackColor = System.Drawing.SystemColors.Control
        Me.txtCostoUSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoUSA.Location = New System.Drawing.Point(128, 33)
        Me.txtCostoUSA.MaxLength = 10
        Me.txtCostoUSA.Name = "txtCostoUSA"
        Me.txtCostoUSA.ReadOnly = True
        Me.txtCostoUSA.Size = New System.Drawing.Size(107, 21)
        Me.txtCostoUSA.TabIndex = 18
        Me.txtCostoUSA.TabStop = False
        Me.txtCostoUSA.Text = "0.00"
        Me.txtCostoUSA.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostoUSA.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMostradorUSA
        '
        Me.txtMostradorUSA.BackColor = System.Drawing.SystemColors.Control
        Me.txtMostradorUSA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMostradorUSA.Location = New System.Drawing.Point(128, 59)
        Me.txtMostradorUSA.MaxLength = 10
        Me.txtMostradorUSA.Name = "txtMostradorUSA"
        Me.txtMostradorUSA.ReadOnly = True
        Me.txtMostradorUSA.Size = New System.Drawing.Size(107, 21)
        Me.txtMostradorUSA.TabIndex = 19
        Me.txtMostradorUSA.TabStop = False
        Me.txtMostradorUSA.Text = "0.00"
        Me.txtMostradorUSA.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMostradorUSA.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMostradorNS
        '
        Me.txtMostradorNS.BackColor = System.Drawing.SystemColors.Control
        Me.txtMostradorNS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMostradorNS.Location = New System.Drawing.Point(128, 85)
        Me.txtMostradorNS.MaxLength = 10
        Me.txtMostradorNS.Name = "txtMostradorNS"
        Me.txtMostradorNS.ReadOnly = True
        Me.txtMostradorNS.Size = New System.Drawing.Size(107, 21)
        Me.txtMostradorNS.TabIndex = 20
        Me.txtMostradorNS.TabStop = False
        Me.txtMostradorNS.Text = "0.00"
        Me.txtMostradorNS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMostradorNS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 15)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Fabrica USA $ :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(33, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 15)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Costo USA $ :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(123, 15)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Mostrador USA $ :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(20, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 15)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Mostrador N/S :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(22, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 15)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Stock Actual :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(52, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 15)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Costo $ :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(37, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 15)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Costo N/S :"
        '
        'txtCostoDol
        '
        Me.txtCostoDol.BackColor = System.Drawing.SystemColors.Control
        Me.txtCostoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoDol.Location = New System.Drawing.Point(116, 33)
        Me.txtCostoDol.MaxLength = 10
        Me.txtCostoDol.Name = "txtCostoDol"
        Me.txtCostoDol.ReadOnly = True
        Me.txtCostoDol.Size = New System.Drawing.Size(120, 21)
        Me.txtCostoDol.TabIndex = 28
        Me.txtCostoDol.TabStop = False
        Me.txtCostoDol.Text = "0.00"
        Me.txtCostoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCostoSol
        '
        Me.txtCostoSol.BackColor = System.Drawing.SystemColors.Control
        Me.txtCostoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoSol.Location = New System.Drawing.Point(116, 59)
        Me.txtCostoSol.MaxLength = 10
        Me.txtCostoSol.Name = "txtCostoSol"
        Me.txtCostoSol.ReadOnly = True
        Me.txtCostoSol.Size = New System.Drawing.Size(120, 21)
        Me.txtCostoSol.TabIndex = 29
        Me.txtCostoSol.TabStop = False
        Me.txtCostoSol.Text = "0.00"
        Me.txtCostoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(44, 202)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 15)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "PRECIOS"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(312, 202)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 15)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "COSTOS"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtFabricaUSA)
        Me.Panel1.Controls.Add(Me.txtCostoUSA)
        Me.Panel1.Controls.Add(Me.txtMostradorUSA)
        Me.Panel1.Controls.Add(Me.txtMostradorNS)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(47, 220)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(268, 116)
        Me.Panel1.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtStock)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtCostoSol)
        Me.Panel2.Controls.Add(Me.txtCostoDol)
        Me.Panel2.Location = New System.Drawing.Point(315, 220)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(268, 116)
        Me.Panel2.TabIndex = 33
        '
        'txtStock
        '
        Me.txtStock.DecimalDigits = 0
        Me.txtStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock.ForeColor = System.Drawing.Color.Blue
        Me.txtStock.Location = New System.Drawing.Point(116, 6)
        Me.txtStock.MaxLength = 10
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(120, 21)
        Me.txtStock.TabIndex = 30
        Me.txtStock.TabStop = False
        Me.txtStock.Text = "0"
        Me.txtStock.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtStock.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtStock.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(316, 47)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscarMercaderia.TabIndex = 36
        '
        'dgvDatos
        '
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 37)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(793, 194)
        Me.dgvDatos.TabIndex = 37
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(360, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 15)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Año"
        '
        'txtanio
        '
        Me.txtanio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtanio.Location = New System.Drawing.Point(395, 11)
        Me.txtanio.Maximum = 2100
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2010
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(70, 20)
        Me.txtanio.TabIndex = 38
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2010
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox1.Controls.Add(Me.lblLeyenda)
        Me.UiGroupBox1.Controls.Add(Me.txtanio)
        Me.UiGroupBox1.Controls.Add(Me.dgvDatos)
        Me.UiGroupBox1.Controls.Add(Me.Label16)
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 348)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(804, 241)
        Me.UiGroupBox1.TabIndex = 40
        Me.UiGroupBox1.Text = "Kardex General"
        '
        'lblLeyenda
        '
        Me.lblLeyenda.AutoSize = True
        Me.lblLeyenda.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeyenda.ForeColor = System.Drawing.Color.Blue
        Me.lblLeyenda.Location = New System.Drawing.Point(587, 18)
        Me.lblLeyenda.Name = "lblLeyenda"
        Me.lblLeyenda.Size = New System.Drawing.Size(127, 12)
        Me.lblLeyenda.TabIndex = 40
        Me.lblLeyenda.Text = "*Doble Click para Ver Kardex"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biImprimir, Me.ToolStripSeparator1, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(819, 31)
        Me.ToolStrip.TabIndex = 41
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Cotizacion"
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
        'frmTarjetaGerencia
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(819, 600)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnBuscarMercaderia)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtCodTipMov)
        Me.Controls.Add(Me.txtTipMov)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPeso)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCodPartida)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodRubro)
        Me.Controls.Add(Me.txtRubro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescripcion2)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTarjetaGerencia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Tarjeta de Mercaderia a Nivel Empresa"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtCodPartida As System.Windows.Forms.TextBox
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodRubro As System.Windows.Forms.TextBox
    Friend WithEvents txtRubro As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCodTipMov As System.Windows.Forms.TextBox
    Friend WithEvents txtTipMov As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPeso As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMostradorNS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMostradorUSA As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtCostoUSA As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtFabricaUSA As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCostoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtCostoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnBuscarMercaderia As Janus.Windows.EditControls.UIButton
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblLeyenda As System.Windows.Forms.Label
    Friend WithEvents txtStock As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
