<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrecios
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
        Dim cmbMarca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrecios))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmbMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtRecord = New System.Windows.Forms.TextBox()
        Me.txtDesMer = New System.Windows.Forms.TextBox()
        Me.txtSupercession = New System.Windows.Forms.TextBox()
        Me.txtPublication = New System.Windows.Forms.TextBox()
        Me.txtSeries = New System.Windows.Forms.TextBox()
        Me.txtFunctional = New System.Windows.Forms.TextBox()
        Me.txtCountry = New System.Windows.Forms.TextBox()
        Me.txtMustBuy = New System.Windows.Forms.TextBox()
        Me.txtUnitCubes = New System.Windows.Forms.TextBox()
        Me.txtUnitWeight = New System.Windows.Forms.TextBox()
        Me.txtCubes = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtPrecioDistDom = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtExWork = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPrecioCore = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPrecioVentaSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPrecioVentaDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPrecioDealer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtWeight = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtGroupCode = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rtCambios = New System.Windows.Forms.TextBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmbMarca
        '
        Me.cmbMarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMarca_DesignTimeLayout.LayoutString = resources.GetString("cmbMarca_DesignTimeLayout.LayoutString")
        Me.cmbMarca.DesignTimeLayout = cmbMarca_DesignTimeLayout
        Me.cmbMarca.Location = New System.Drawing.Point(77, 17)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.SelectedIndex = -1
        Me.cmbMarca.SelectedItem = Nothing
        Me.cmbMarca.Size = New System.Drawing.Size(186, 20)
        Me.cmbMarca.TabIndex = 1
        Me.cmbMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtRecord
        '
        Me.txtRecord.BackColor = System.Drawing.SystemColors.Window
        Me.txtRecord.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecord.Location = New System.Drawing.Point(269, 63)
        Me.txtRecord.Name = "txtRecord"
        Me.txtRecord.ReadOnly = True
        Me.txtRecord.Size = New System.Drawing.Size(58, 22)
        Me.txtRecord.TabIndex = 3
        Me.txtRecord.TabStop = False
        Me.txtRecord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDesMer
        '
        Me.txtDesMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesMer.Location = New System.Drawing.Point(375, 25)
        Me.txtDesMer.Name = "txtDesMer"
        Me.txtDesMer.ReadOnly = True
        Me.txtDesMer.Size = New System.Drawing.Size(261, 20)
        Me.txtDesMer.TabIndex = 2
        Me.txtDesMer.TabStop = False
        '
        'txtSupercession
        '
        Me.txtSupercession.BackColor = System.Drawing.SystemColors.Window
        Me.txtSupercession.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSupercession.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupercession.Location = New System.Drawing.Point(269, 93)
        Me.txtSupercession.Name = "txtSupercession"
        Me.txtSupercession.ReadOnly = True
        Me.txtSupercession.Size = New System.Drawing.Size(58, 22)
        Me.txtSupercession.TabIndex = 13
        Me.txtSupercession.TabStop = False
        Me.txtSupercession.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPublication
        '
        Me.txtPublication.BackColor = System.Drawing.SystemColors.Window
        Me.txtPublication.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPublication.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPublication.Location = New System.Drawing.Point(269, 119)
        Me.txtPublication.Name = "txtPublication"
        Me.txtPublication.ReadOnly = True
        Me.txtPublication.Size = New System.Drawing.Size(58, 22)
        Me.txtPublication.TabIndex = 14
        Me.txtPublication.TabStop = False
        Me.txtPublication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSeries
        '
        Me.txtSeries.BackColor = System.Drawing.SystemColors.Window
        Me.txtSeries.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeries.Location = New System.Drawing.Point(269, 145)
        Me.txtSeries.Name = "txtSeries"
        Me.txtSeries.ReadOnly = True
        Me.txtSeries.Size = New System.Drawing.Size(58, 22)
        Me.txtSeries.TabIndex = 15
        Me.txtSeries.TabStop = False
        Me.txtSeries.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFunctional
        '
        Me.txtFunctional.BackColor = System.Drawing.SystemColors.Window
        Me.txtFunctional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFunctional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFunctional.Location = New System.Drawing.Point(269, 171)
        Me.txtFunctional.Name = "txtFunctional"
        Me.txtFunctional.ReadOnly = True
        Me.txtFunctional.Size = New System.Drawing.Size(58, 22)
        Me.txtFunctional.TabIndex = 16
        Me.txtFunctional.TabStop = False
        Me.txtFunctional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCountry
        '
        Me.txtCountry.BackColor = System.Drawing.SystemColors.Window
        Me.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountry.Location = New System.Drawing.Point(269, 198)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.ReadOnly = True
        Me.txtCountry.Size = New System.Drawing.Size(58, 22)
        Me.txtCountry.TabIndex = 17
        Me.txtCountry.TabStop = False
        Me.txtCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMustBuy
        '
        Me.txtMustBuy.BackColor = System.Drawing.SystemColors.Window
        Me.txtMustBuy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMustBuy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMustBuy.Location = New System.Drawing.Point(588, 63)
        Me.txtMustBuy.Name = "txtMustBuy"
        Me.txtMustBuy.ReadOnly = True
        Me.txtMustBuy.Size = New System.Drawing.Size(58, 22)
        Me.txtMustBuy.TabIndex = 18
        Me.txtMustBuy.TabStop = False
        Me.txtMustBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUnitCubes
        '
        Me.txtUnitCubes.BackColor = System.Drawing.SystemColors.Control
        Me.txtUnitCubes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCubes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitCubes.Location = New System.Drawing.Point(531, 198)
        Me.txtUnitCubes.Name = "txtUnitCubes"
        Me.txtUnitCubes.ReadOnly = True
        Me.txtUnitCubes.Size = New System.Drawing.Size(117, 22)
        Me.txtUnitCubes.TabIndex = 29
        Me.txtUnitCubes.TabStop = False
        Me.txtUnitCubes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUnitWeight
        '
        Me.txtUnitWeight.BackColor = System.Drawing.SystemColors.Control
        Me.txtUnitWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitWeight.Location = New System.Drawing.Point(531, 144)
        Me.txtUnitWeight.Name = "txtUnitWeight"
        Me.txtUnitWeight.ReadOnly = True
        Me.txtUnitWeight.Size = New System.Drawing.Size(117, 22)
        Me.txtUnitWeight.TabIndex = 29
        Me.txtUnitWeight.TabStop = False
        Me.txtUnitWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCubes
        '
        Me.txtCubes.BackColor = System.Drawing.SystemColors.Menu
        Me.txtCubes.DecimalDigits = 4
        Me.txtCubes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCubes.Location = New System.Drawing.Point(531, 171)
        Me.txtCubes.MaxLength = 10
        Me.txtCubes.Name = "txtCubes"
        Me.txtCubes.ReadOnly = True
        Me.txtCubes.Size = New System.Drawing.Size(117, 22)
        Me.txtCubes.TabIndex = 67
        Me.txtCubes.TabStop = False
        Me.txtCubes.Text = "0.0000"
        Me.txtCubes.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtCubes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(364, 201)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 16)
        Me.Label21.TabIndex = 65
        Me.Label21.Text = "Unit Cubes"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(364, 177)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 16)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "Cubes"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(364, 151)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(87, 16)
        Me.Label19.TabIndex = 63
        Me.Label19.Text = "Unit Weight"
        '
        'txtPrecioDistDom
        '
        Me.txtPrecioDistDom.BackColor = System.Drawing.SystemColors.Menu
        Me.txtPrecioDistDom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioDistDom.Location = New System.Drawing.Point(210, 252)
        Me.txtPrecioDistDom.MaxLength = 10
        Me.txtPrecioDistDom.Name = "txtPrecioDistDom"
        Me.txtPrecioDistDom.ReadOnly = True
        Me.txtPrecioDistDom.Size = New System.Drawing.Size(117, 22)
        Me.txtPrecioDistDom.TabIndex = 62
        Me.txtPrecioDistDom.TabStop = False
        Me.txtPrecioDistDom.Text = "0.00"
        Me.txtPrecioDistDom.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPrecioDistDom.Visible = False
        Me.txtPrecioDistDom.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtExWork
        '
        Me.txtExWork.BackColor = System.Drawing.SystemColors.Menu
        Me.txtExWork.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExWork.Location = New System.Drawing.Point(210, 278)
        Me.txtExWork.MaxLength = 10
        Me.txtExWork.Name = "txtExWork"
        Me.txtExWork.ReadOnly = True
        Me.txtExWork.Size = New System.Drawing.Size(117, 22)
        Me.txtExWork.TabIndex = 61
        Me.txtExWork.TabStop = False
        Me.txtExWork.Text = "0.00"
        Me.txtExWork.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtExWork.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPrecioCore
        '
        Me.txtPrecioCore.BackColor = System.Drawing.SystemColors.Menu
        Me.txtPrecioCore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioCore.Location = New System.Drawing.Point(210, 225)
        Me.txtPrecioCore.MaxLength = 10
        Me.txtPrecioCore.Name = "txtPrecioCore"
        Me.txtPrecioCore.ReadOnly = True
        Me.txtPrecioCore.Size = New System.Drawing.Size(117, 22)
        Me.txtPrecioCore.TabIndex = 60
        Me.txtPrecioCore.TabStop = False
        Me.txtPrecioCore.Text = "0.00"
        Me.txtPrecioCore.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPrecioCore.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPrecioVentaSol
        '
        Me.txtPrecioVentaSol.BackColor = System.Drawing.SystemColors.Menu
        Me.txtPrecioVentaSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioVentaSol.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPrecioVentaSol.Location = New System.Drawing.Point(531, 276)
        Me.txtPrecioVentaSol.MaxLength = 10
        Me.txtPrecioVentaSol.Name = "txtPrecioVentaSol"
        Me.txtPrecioVentaSol.ReadOnly = True
        Me.txtPrecioVentaSol.Size = New System.Drawing.Size(117, 22)
        Me.txtPrecioVentaSol.TabIndex = 59
        Me.txtPrecioVentaSol.TabStop = False
        Me.txtPrecioVentaSol.Text = "0.00"
        Me.txtPrecioVentaSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPrecioVentaSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPrecioVentaDol
        '
        Me.txtPrecioVentaDol.BackColor = System.Drawing.SystemColors.Menu
        Me.txtPrecioVentaDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioVentaDol.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPrecioVentaDol.Location = New System.Drawing.Point(531, 251)
        Me.txtPrecioVentaDol.MaxLength = 10
        Me.txtPrecioVentaDol.Name = "txtPrecioVentaDol"
        Me.txtPrecioVentaDol.ReadOnly = True
        Me.txtPrecioVentaDol.Size = New System.Drawing.Size(117, 22)
        Me.txtPrecioVentaDol.TabIndex = 58
        Me.txtPrecioVentaDol.TabStop = False
        Me.txtPrecioVentaDol.Text = "0.00"
        Me.txtPrecioVentaDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPrecioVentaDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPrecioDealer
        '
        Me.txtPrecioDealer.BackColor = System.Drawing.SystemColors.Menu
        Me.txtPrecioDealer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioDealer.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPrecioDealer.Location = New System.Drawing.Point(531, 226)
        Me.txtPrecioDealer.MaxLength = 10
        Me.txtPrecioDealer.Name = "txtPrecioDealer"
        Me.txtPrecioDealer.ReadOnly = True
        Me.txtPrecioDealer.Size = New System.Drawing.Size(117, 22)
        Me.txtPrecioDealer.TabIndex = 57
        Me.txtPrecioDealer.TabStop = False
        Me.txtPrecioDealer.Text = "0.00"
        Me.txtPrecioDealer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPrecioDealer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtWeight
        '
        Me.txtWeight.BackColor = System.Drawing.SystemColors.Menu
        Me.txtWeight.DecimalDigits = 4
        Me.txtWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(531, 117)
        Me.txtWeight.MaxLength = 10
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.ReadOnly = True
        Me.txtWeight.Size = New System.Drawing.Size(117, 22)
        Me.txtWeight.TabIndex = 56
        Me.txtWeight.TabStop = False
        Me.txtWeight.Text = "0.0000"
        Me.txtWeight.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtWeight.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtGroupCode
        '
        Me.txtGroupCode.BackColor = System.Drawing.SystemColors.Menu
        Me.txtGroupCode.DecimalDigits = 4
        Me.txtGroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupCode.Location = New System.Drawing.Point(531, 91)
        Me.txtGroupCode.MaxLength = 10
        Me.txtGroupCode.Name = "txtGroupCode"
        Me.txtGroupCode.ReadOnly = True
        Me.txtGroupCode.Size = New System.Drawing.Size(117, 22)
        Me.txtGroupCode.TabIndex = 55
        Me.txtGroupCode.TabStop = False
        Me.txtGroupCode.Text = "0.0000"
        Me.txtGroupCode.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtGroupCode.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(21, 281)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(151, 16)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "Precio Ex Work: US$"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(21, 254)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(183, 16)
        Me.Label17.TabIndex = 52
        Me.Label17.Text = "Precio Distrib. Dom.: US$"
        Me.Label17.Visible = False
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodMer.Location = New System.Drawing.Point(93, 25)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(152, 20)
        Me.txtCodMer.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(362, 282)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(148, 16)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Precio Venta        S/."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(362, 256)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(150, 16)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "Precio Venta :    US$"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(362, 229)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(130, 16)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Precio SLP :  US$"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(364, 122)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Weight"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(362, 93)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 16)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Group Code"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(362, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(130, 16)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Must Buy Quantity"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 16)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "Código :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 16)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Precio Core"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 16)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Country of Origen"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 16)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Functional Comp Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Series Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 16)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Publicacion Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 16)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Supercession Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Record Type :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(272, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Descripcion :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Marca :"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(583, 379)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 23)
        Me.btnCancelar.TabIndex = 28
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rtCambios)
        Me.GroupBox1.Controls.Add(Me.txtUnitCubes)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtUnitWeight)
        Me.GroupBox1.Controls.Add(Me.txtSeries)
        Me.GroupBox1.Controls.Add(Me.txtPublication)
        Me.GroupBox1.Controls.Add(Me.txtCubes)
        Me.GroupBox1.Controls.Add(Me.txtFunctional)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtCountry)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtSupercession)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtMustBuy)
        Me.GroupBox1.Controls.Add(Me.txtPrecioDistDom)
        Me.GroupBox1.Controls.Add(Me.txtDesMer)
        Me.GroupBox1.Controls.Add(Me.txtExWork)
        Me.GroupBox1.Controls.Add(Me.txtRecord)
        Me.GroupBox1.Controls.Add(Me.txtPrecioCore)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPrecioVentaSol)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPrecioVentaDol)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPrecioDealer)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtWeight)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtGroupCode)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtCodMer)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(665, 322)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mercaderia"
        '
        'rtCambios
        '
        Me.rtCambios.BackColor = System.Drawing.SystemColors.Control
        Me.rtCambios.Location = New System.Drawing.Point(5, 302)
        Me.rtCambios.Multiline = True
        Me.rtCambios.Name = "rtCambios"
        Me.rtCambios.Size = New System.Drawing.Size(645, 15)
        Me.rtCambios.TabIndex = 30
        '
        'frmPrecios
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(696, 416)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbMarca)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(697, 426)
        Me.Name = "frmPrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Precios"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmbMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtSeries As System.Windows.Forms.TextBox
    Friend WithEvents txtPublication As System.Windows.Forms.TextBox
    Friend WithEvents txtSupercession As System.Windows.Forms.TextBox
    Friend WithEvents txtDesMer As System.Windows.Forms.TextBox
    Friend WithEvents txtRecord As System.Windows.Forms.TextBox
    Friend WithEvents txtMustBuy As System.Windows.Forms.TextBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtFunctional As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioDealer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtWeight As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtGroupCode As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPrecioDistDom As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtExWork As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPrecioCore As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPrecioVentaSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPrecioVentaDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtCubes As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtUnitCubes As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitWeight As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents rtCambios As System.Windows.Forms.TextBox
End Class
