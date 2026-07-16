<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValorizarFIDatos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValorizarFIDatos))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotIpm = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotAdvalorem = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotIgvAd = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotSeguro = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotServicio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotTerminalAlmacen = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotCargaDescarga = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTransLocal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtGastoAgenciaAduana = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtResguardo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOtrosGastos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTorOtrosGastos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtHandLing = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotFobGen = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotFleteDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotDerAduDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTotDerAduSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(471, 483)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 28)
        Me.btnCancelar.TabIndex = 28
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(387, 483)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 28)
        Me.btnAceptar.TabIndex = 27
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.AllowColumnDrag = False
        Me.dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvDatos.AlternatingColors = True
        Me.dgvDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.EmptyRows = True
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvDatos.Location = New System.Drawing.Point(9, 11)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(936, 306)
        Me.dgvDatos.TabIndex = 29
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIgv
        '
        Me.txtIgv.Location = New System.Drawing.Point(81, 16)
        Me.txtIgv.MaxLength = 12
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(100, 21)
        Me.txtIgv.TabIndex = 30
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(49, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 15)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "IGV"
        '
        'txtTotIpm
        '
        Me.txtTotIpm.Location = New System.Drawing.Point(81, 43)
        Me.txtTotIpm.MaxLength = 12
        Me.txtTotIpm.Name = "txtTotIpm"
        Me.txtTotIpm.ReadOnly = True
        Me.txtTotIpm.Size = New System.Drawing.Size(100, 21)
        Me.txtTotIpm.TabIndex = 32
        Me.txtTotIpm.Text = "0.00"
        Me.txtTotIpm.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 15)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "IPM"
        '
        'txtTotAdvalorem
        '
        Me.txtTotAdvalorem.Location = New System.Drawing.Point(81, 97)
        Me.txtTotAdvalorem.MaxLength = 12
        Me.txtTotAdvalorem.Name = "txtTotAdvalorem"
        Me.txtTotAdvalorem.ReadOnly = True
        Me.txtTotAdvalorem.Size = New System.Drawing.Size(100, 21)
        Me.txtTotAdvalorem.TabIndex = 36
        Me.txtTotAdvalorem.Text = "0.00"
        Me.txtTotAdvalorem.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Advalorem"
        '
        'txtTotIgvAd
        '
        Me.txtTotIgvAd.Location = New System.Drawing.Point(81, 70)
        Me.txtTotIgvAd.MaxLength = 12
        Me.txtTotIgvAd.Name = "txtTotIgvAd"
        Me.txtTotIgvAd.ReadOnly = True
        Me.txtTotIgvAd.Size = New System.Drawing.Size(100, 21)
        Me.txtTotIgvAd.TabIndex = 34
        Me.txtTotIgvAd.Text = "0.00"
        Me.txtTotIgvAd.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "IGV AD"
        '
        'txtTotSeguro
        '
        Me.txtTotSeguro.Location = New System.Drawing.Point(349, 16)
        Me.txtTotSeguro.MaxLength = 12
        Me.txtTotSeguro.Name = "txtTotSeguro"
        Me.txtTotSeguro.ReadOnly = True
        Me.txtTotSeguro.Size = New System.Drawing.Size(100, 21)
        Me.txtTotSeguro.TabIndex = 40
        Me.txtTotSeguro.Text = "0.00"
        Me.txtTotSeguro.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(296, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Seguro"
        '
        'txtTotServicio
        '
        Me.txtTotServicio.Location = New System.Drawing.Point(81, 124)
        Me.txtTotServicio.MaxLength = 12
        Me.txtTotServicio.Name = "txtTotServicio"
        Me.txtTotServicio.ReadOnly = True
        Me.txtTotServicio.Size = New System.Drawing.Size(100, 21)
        Me.txtTotServicio.TabIndex = 38
        Me.txtTotServicio.Text = "0.00"
        Me.txtTotServicio.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 15)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Servicio"
        '
        'txtTotTerminalAlmacen
        '
        Me.txtTotTerminalAlmacen.Location = New System.Drawing.Point(349, 70)
        Me.txtTotTerminalAlmacen.MaxLength = 12
        Me.txtTotTerminalAlmacen.Name = "txtTotTerminalAlmacen"
        Me.txtTotTerminalAlmacen.ReadOnly = True
        Me.txtTotTerminalAlmacen.Size = New System.Drawing.Size(100, 21)
        Me.txtTotTerminalAlmacen.TabIndex = 44
        Me.txtTotTerminalAlmacen.Text = "0.00"
        Me.txtTotTerminalAlmacen.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(236, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 15)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Terminal Almacen"
        '
        'txtTotCargaDescarga
        '
        Me.txtTotCargaDescarga.Location = New System.Drawing.Point(349, 43)
        Me.txtTotCargaDescarga.MaxLength = 12
        Me.txtTotCargaDescarga.Name = "txtTotCargaDescarga"
        Me.txtTotCargaDescarga.ReadOnly = True
        Me.txtTotCargaDescarga.Size = New System.Drawing.Size(100, 21)
        Me.txtTotCargaDescarga.TabIndex = 42
        Me.txtTotCargaDescarga.Text = "0.00"
        Me.txtTotCargaDescarga.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(247, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 15)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Carga Descarga"
        '
        'txtTransLocal
        '
        Me.txtTransLocal.Location = New System.Drawing.Point(349, 124)
        Me.txtTransLocal.MaxLength = 12
        Me.txtTransLocal.Name = "txtTransLocal"
        Me.txtTransLocal.ReadOnly = True
        Me.txtTransLocal.Size = New System.Drawing.Size(100, 21)
        Me.txtTransLocal.TabIndex = 48
        Me.txtTransLocal.Text = "0.00"
        Me.txtTransLocal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(269, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 15)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Trans. Local"
        '
        'txtGastoAgenciaAduana
        '
        Me.txtGastoAgenciaAduana.Location = New System.Drawing.Point(349, 97)
        Me.txtGastoAgenciaAduana.MaxLength = 12
        Me.txtGastoAgenciaAduana.Name = "txtGastoAgenciaAduana"
        Me.txtGastoAgenciaAduana.ReadOnly = True
        Me.txtGastoAgenciaAduana.Size = New System.Drawing.Size(100, 21)
        Me.txtGastoAgenciaAduana.TabIndex = 46
        Me.txtGastoAgenciaAduana.Text = "0.00"
        Me.txtGastoAgenciaAduana.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(212, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(131, 15)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Gasto Agencia Aduana"
        '
        'txtResguardo
        '
        Me.txtResguardo.Location = New System.Drawing.Point(582, 43)
        Me.txtResguardo.MaxLength = 12
        Me.txtResguardo.Name = "txtResguardo"
        Me.txtResguardo.ReadOnly = True
        Me.txtResguardo.Size = New System.Drawing.Size(100, 21)
        Me.txtResguardo.TabIndex = 52
        Me.txtResguardo.Text = "0.00"
        Me.txtResguardo.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(508, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 15)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "Resguardo"
        '
        'txtOtrosGastos
        '
        Me.txtOtrosGastos.Location = New System.Drawing.Point(582, 16)
        Me.txtOtrosGastos.MaxLength = 12
        Me.txtOtrosGastos.Name = "txtOtrosGastos"
        Me.txtOtrosGastos.ReadOnly = True
        Me.txtOtrosGastos.Size = New System.Drawing.Size(100, 21)
        Me.txtOtrosGastos.TabIndex = 50
        Me.txtOtrosGastos.Text = "0.00"
        Me.txtOtrosGastos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(499, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 15)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Otros Gastos"
        '
        'txtTorOtrosGastos
        '
        Me.txtTorOtrosGastos.Location = New System.Drawing.Point(582, 97)
        Me.txtTorOtrosGastos.MaxLength = 12
        Me.txtTorOtrosGastos.Name = "txtTorOtrosGastos"
        Me.txtTorOtrosGastos.ReadOnly = True
        Me.txtTorOtrosGastos.Size = New System.Drawing.Size(100, 21)
        Me.txtTorOtrosGastos.TabIndex = 56
        Me.txtTorOtrosGastos.Text = "0.00"
        Me.txtTorOtrosGastos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(476, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 15)
        Me.Label13.TabIndex = 57
        Me.Label13.Text = "Tot. Otros Gastos"
        '
        'txtHandLing
        '
        Me.txtHandLing.Location = New System.Drawing.Point(582, 70)
        Me.txtHandLing.MaxLength = 12
        Me.txtHandLing.Name = "txtHandLing"
        Me.txtHandLing.ReadOnly = True
        Me.txtHandLing.Size = New System.Drawing.Size(100, 21)
        Me.txtHandLing.TabIndex = 54
        Me.txtHandLing.Text = "0.00"
        Me.txtHandLing.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(515, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 15)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "HandLing"
        '
        'txtTotFobGen
        '
        Me.txtTotFobGen.Location = New System.Drawing.Point(582, 124)
        Me.txtTotFobGen.MaxLength = 12
        Me.txtTotFobGen.Name = "txtTotFobGen"
        Me.txtTotFobGen.ReadOnly = True
        Me.txtTotFobGen.Size = New System.Drawing.Size(100, 21)
        Me.txtTotFobGen.TabIndex = 58
        Me.txtTotFobGen.Text = "0.00"
        Me.txtTotFobGen.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(499, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 15)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Tot. Fob Gen"
        '
        'txtTotFleteDol
        '
        Me.txtTotFleteDol.Location = New System.Drawing.Point(803, 16)
        Me.txtTotFleteDol.MaxLength = 12
        Me.txtTotFleteDol.Name = "txtTotFleteDol"
        Me.txtTotFleteDol.ReadOnly = True
        Me.txtTotFleteDol.Size = New System.Drawing.Size(100, 21)
        Me.txtTotFleteDol.TabIndex = 62
        Me.txtTotFleteDol.Text = "0.00"
        Me.txtTotFleteDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(730, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 15)
        Me.Label17.TabIndex = 63
        Me.Label17.Text = "Tot. Flete $"
        '
        'txtTotDerAduDol
        '
        Me.txtTotDerAduDol.Location = New System.Drawing.Point(803, 70)
        Me.txtTotDerAduDol.MaxLength = 12
        Me.txtTotDerAduDol.Name = "txtTotDerAduDol"
        Me.txtTotDerAduDol.ReadOnly = True
        Me.txtTotDerAduDol.Size = New System.Drawing.Size(100, 21)
        Me.txtTotDerAduDol.TabIndex = 66
        Me.txtTotDerAduDol.Text = "0.00"
        Me.txtTotDerAduDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(713, 73)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 15)
        Me.Label18.TabIndex = 67
        Me.Label18.Text = "Tot. Der Adu $"
        '
        'txtTotDerAduSol
        '
        Me.txtTotDerAduSol.Location = New System.Drawing.Point(803, 43)
        Me.txtTotDerAduSol.MaxLength = 12
        Me.txtTotDerAduSol.Name = "txtTotDerAduSol"
        Me.txtTotDerAduSol.ReadOnly = True
        Me.txtTotDerAduSol.Size = New System.Drawing.Size(100, 21)
        Me.txtTotDerAduSol.TabIndex = 64
        Me.txtTotDerAduSol.Text = "0.00"
        Me.txtTotDerAduSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(710, 46)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 15)
        Me.Label19.TabIndex = 65
        Me.Label19.Text = "Tot. Der Adu S/."
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.txtIgv)
        Me.UiGroupBox3.Controls.Add(Me.txtTotDerAduDol)
        Me.UiGroupBox3.Controls.Add(Me.Label10)
        Me.UiGroupBox3.Controls.Add(Me.Label18)
        Me.UiGroupBox3.Controls.Add(Me.Label1)
        Me.UiGroupBox3.Controls.Add(Me.txtTotDerAduSol)
        Me.UiGroupBox3.Controls.Add(Me.txtTotIpm)
        Me.UiGroupBox3.Controls.Add(Me.Label19)
        Me.UiGroupBox3.Controls.Add(Me.Label3)
        Me.UiGroupBox3.Controls.Add(Me.txtTotFleteDol)
        Me.UiGroupBox3.Controls.Add(Me.txtTotIgvAd)
        Me.UiGroupBox3.Controls.Add(Me.Label17)
        Me.UiGroupBox3.Controls.Add(Me.Label2)
        Me.UiGroupBox3.Controls.Add(Me.txtTotAdvalorem)
        Me.UiGroupBox3.Controls.Add(Me.Label5)
        Me.UiGroupBox3.Controls.Add(Me.txtTotFobGen)
        Me.UiGroupBox3.Controls.Add(Me.txtTotServicio)
        Me.UiGroupBox3.Controls.Add(Me.Label15)
        Me.UiGroupBox3.Controls.Add(Me.Label4)
        Me.UiGroupBox3.Controls.Add(Me.txtTorOtrosGastos)
        Me.UiGroupBox3.Controls.Add(Me.txtTotSeguro)
        Me.UiGroupBox3.Controls.Add(Me.Label13)
        Me.UiGroupBox3.Controls.Add(Me.Label7)
        Me.UiGroupBox3.Controls.Add(Me.txtHandLing)
        Me.UiGroupBox3.Controls.Add(Me.txtTotCargaDescarga)
        Me.UiGroupBox3.Controls.Add(Me.Label14)
        Me.UiGroupBox3.Controls.Add(Me.Label6)
        Me.UiGroupBox3.Controls.Add(Me.txtResguardo)
        Me.UiGroupBox3.Controls.Add(Me.txtTotTerminalAlmacen)
        Me.UiGroupBox3.Controls.Add(Me.Label11)
        Me.UiGroupBox3.Controls.Add(Me.Label9)
        Me.UiGroupBox3.Controls.Add(Me.txtOtrosGastos)
        Me.UiGroupBox3.Controls.Add(Me.txtGastoAgenciaAduana)
        Me.UiGroupBox3.Controls.Add(Me.Label12)
        Me.UiGroupBox3.Controls.Add(Me.Label8)
        Me.UiGroupBox3.Controls.Add(Me.txtTransLocal)
        Me.UiGroupBox3.Location = New System.Drawing.Point(9, 322)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(920, 155)
        Me.UiGroupBox3.TabIndex = 68
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmValorizarFIDatos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(971, 553)
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmValorizarFIDatos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Valorizar Facturas de Impotación - Datos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtTransLocal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtGastoAgenciaAduana As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotTerminalAlmacen As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotCargaDescarga As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotSeguro As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotServicio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotAdvalorem As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotIgvAd As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotIpm As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotDerAduDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotDerAduSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTotFleteDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtTotFobGen As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTorOtrosGastos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtHandLing As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtResguardo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtOtrosGastos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
End Class
