<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportacionDet
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
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarPartida = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDesPar = New System.Windows.Forms.TextBox()
        Me.txtCodPar = New System.Windows.Forms.TextBox()
        Me.txtUnidad = New System.Windows.Forms.TextBox()
        Me.txtDesMer = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.mkPreMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkCosSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkCosDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkPeso = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNomPed = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCanFac = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCanMer = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.mkOtroGasto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkNucleo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkGestionCompra = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.mkFleteInterno = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CkGestion = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(316, 281)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(79, 27)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "Aceptar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        Me.btnGuardar.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(399, 281)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(81, 27)
        Me.btnSalir.TabIndex = 25
        Me.btnSalir.Text = "Cancelar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPartida)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtDesPar)
        Me.UiGroupBox1.Controls.Add(Me.txtCodPar)
        Me.UiGroupBox1.Controls.Add(Me.txtUnidad)
        Me.UiGroupBox1.Controls.Add(Me.txtDesMer)
        Me.UiGroupBox1.Controls.Add(Me.txtCodigo)
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 4)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(473, 66)
        Me.UiGroupBox1.TabIndex = 28
        Me.UiGroupBox1.Text = "Datos de Mercaderia"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarPartida
        '
        Me.btnBuscarPartida.Enabled = False
        Me.btnBuscarPartida.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPartida.Location = New System.Drawing.Point(370, 38)
        Me.btnBuscarPartida.Name = "btnBuscarPartida"
        Me.btnBuscarPartida.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPartida.TabIndex = 25
        Me.btnBuscarPartida.TabStop = False
        Me.btnBuscarPartida.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Codigo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Descripcion :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Uni.Med. :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(120, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Partida :"
        '
        'txtDesPar
        '
        Me.txtDesPar.Location = New System.Drawing.Point(212, 39)
        Me.txtDesPar.Name = "txtDesPar"
        Me.txtDesPar.ReadOnly = True
        Me.txtDesPar.Size = New System.Drawing.Size(158, 20)
        Me.txtDesPar.TabIndex = 24
        Me.txtDesPar.TabStop = False
        '
        'txtCodPar
        '
        Me.txtCodPar.Location = New System.Drawing.Point(169, 39)
        Me.txtCodPar.Name = "txtCodPar"
        Me.txtCodPar.ReadOnly = True
        Me.txtCodPar.Size = New System.Drawing.Size(42, 20)
        Me.txtCodPar.TabIndex = 1
        '
        'txtUnidad
        '
        Me.txtUnidad.Location = New System.Drawing.Point(63, 39)
        Me.txtUnidad.Name = "txtUnidad"
        Me.txtUnidad.ReadOnly = True
        Me.txtUnidad.Size = New System.Drawing.Size(49, 20)
        Me.txtUnidad.TabIndex = 22
        Me.txtUnidad.TabStop = False
        '
        'txtDesMer
        '
        Me.txtDesMer.Location = New System.Drawing.Point(253, 17)
        Me.txtDesMer.Name = "txtDesMer"
        Me.txtDesMer.ReadOnly = True
        Me.txtDesMer.Size = New System.Drawing.Size(214, 20)
        Me.txtDesMer.TabIndex = 21
        Me.txtDesMer.TabStop = False
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(51, 17)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(130, 20)
        Me.txtCodigo.TabIndex = 20
        Me.txtCodigo.TabStop = False
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.mkPreMer)
        Me.UiGroupBox2.Controls.Add(Me.mkCosSol)
        Me.UiGroupBox2.Controls.Add(Me.mkCosDol)
        Me.UiGroupBox2.Controls.Add(Me.mkPeso)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.txtNomPed)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtCanFac)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtCanMer)
        Me.UiGroupBox2.Controls.Add(Me.Label6)
        Me.UiGroupBox2.Location = New System.Drawing.Point(7, 70)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(473, 105)
        Me.UiGroupBox2.TabIndex = 29
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'mkPreMer
        '
        Me.mkPreMer.DecimalDigits = 4
        Me.mkPreMer.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkPreMer.Enabled = False
        Me.mkPreMer.Location = New System.Drawing.Point(68, 34)
        Me.mkPreMer.Name = "mkPreMer"
        Me.mkPreMer.Size = New System.Drawing.Size(88, 20)
        Me.mkPreMer.TabIndex = 2
        Me.mkPreMer.Text = "0.0000"
        Me.mkPreMer.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkCosSol
        '
        Me.mkCosSol.DecimalDigits = 10
        Me.mkCosSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkCosSol.Enabled = False
        Me.mkCosSol.Location = New System.Drawing.Point(284, 57)
        Me.mkCosSol.Name = "mkCosSol"
        Me.mkCosSol.Size = New System.Drawing.Size(156, 20)
        Me.mkCosSol.TabIndex = 5
        Me.mkCosSol.Text = "0.0000000000"
        Me.mkCosSol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'mkCosDol
        '
        Me.mkCosDol.DecimalDigits = 10
        Me.mkCosDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkCosDol.Enabled = False
        Me.mkCosDol.Location = New System.Drawing.Point(68, 57)
        Me.mkCosDol.Name = "mkCosDol"
        Me.mkCosDol.Size = New System.Drawing.Size(149, 20)
        Me.mkCosDol.TabIndex = 4
        Me.mkCosDol.Text = "0.0000000000"
        Me.mkCosDol.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'mkPeso
        '
        Me.mkPeso.DecimalDigits = 4
        Me.mkPeso.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkPeso.Enabled = False
        Me.mkPeso.Location = New System.Drawing.Point(210, 34)
        Me.mkPeso.Name = "mkPeso"
        Me.mkPeso.Size = New System.Drawing.Size(111, 20)
        Me.mkPeso.TabIndex = 3
        Me.mkPeso.Text = "0.0000"
        Me.mkPeso.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Cantidad Factura :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Numero Pedido :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(166, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Peso :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(221, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Costo S/. :"
        '
        'txtNomPed
        '
        Me.txtNomPed.Location = New System.Drawing.Point(93, 80)
        Me.txtNomPed.Name = "txtNomPed"
        Me.txtNomPed.ReadOnly = True
        Me.txtNomPed.Size = New System.Drawing.Size(153, 20)
        Me.txtNomPed.TabIndex = 36
        Me.txtNomPed.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Costo $ :"
        '
        'txtCanFac
        '
        Me.txtCanFac.Location = New System.Drawing.Point(101, 11)
        Me.txtCanFac.Name = "txtCanFac"
        Me.txtCanFac.ReadOnly = True
        Me.txtCanFac.Size = New System.Drawing.Size(55, 20)
        Me.txtCanFac.TabIndex = 33
        Me.txtCanFac.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Precio Fob :"
        '
        'txtCanMer
        '
        Me.txtCanMer.Location = New System.Drawing.Point(257, 11)
        Me.txtCanMer.Name = "txtCanMer"
        Me.txtCanMer.ReadOnly = True
        Me.txtCanMer.Size = New System.Drawing.Size(64, 20)
        Me.txtCanMer.TabIndex = 34
        Me.txtCanMer.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(162, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Cantidad Fisica :"
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.mkOtroGasto)
        Me.UiGroupBox3.Controls.Add(Me.mkNucleo)
        Me.UiGroupBox3.Controls.Add(Me.mkGestionCompra)
        Me.UiGroupBox3.Controls.Add(Me.mkFleteInterno)
        Me.UiGroupBox3.Controls.Add(Me.Label15)
        Me.UiGroupBox3.Controls.Add(Me.Label14)
        Me.UiGroupBox3.Controls.Add(Me.CkGestion)
        Me.UiGroupBox3.Controls.Add(Me.Label13)
        Me.UiGroupBox3.Controls.Add(Me.Label12)
        Me.UiGroupBox3.Location = New System.Drawing.Point(7, 175)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(473, 101)
        Me.UiGroupBox3.TabIndex = 30
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'mkOtroGasto
        '
        Me.mkOtroGasto.DecimalDigits = 4
        Me.mkOtroGasto.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkOtroGasto.Enabled = False
        Me.mkOtroGasto.Location = New System.Drawing.Point(85, 76)
        Me.mkOtroGasto.Name = "mkOtroGasto"
        Me.mkOtroGasto.Size = New System.Drawing.Size(121, 20)
        Me.mkOtroGasto.TabIndex = 9
        Me.mkOtroGasto.Text = "0.0000"
        Me.mkOtroGasto.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkNucleo
        '
        Me.mkNucleo.DecimalDigits = 4
        Me.mkNucleo.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkNucleo.Enabled = False
        Me.mkNucleo.Location = New System.Drawing.Point(112, 53)
        Me.mkNucleo.Name = "mkNucleo"
        Me.mkNucleo.Size = New System.Drawing.Size(132, 20)
        Me.mkNucleo.TabIndex = 8
        Me.mkNucleo.Text = "0.0000"
        Me.mkNucleo.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkGestionCompra
        '
        Me.mkGestionCompra.DecimalDigits = 4
        Me.mkGestionCompra.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkGestionCompra.Enabled = False
        Me.mkGestionCompra.Location = New System.Drawing.Point(284, 30)
        Me.mkGestionCompra.Name = "mkGestionCompra"
        Me.mkGestionCompra.Size = New System.Drawing.Size(115, 20)
        Me.mkGestionCompra.TabIndex = 7
        Me.mkGestionCompra.Text = "0.0000"
        Me.mkGestionCompra.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'mkFleteInterno
        '
        Me.mkFleteInterno.DecimalDigits = 10
        Me.mkFleteInterno.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.mkFleteInterno.Enabled = False
        Me.mkFleteInterno.Location = New System.Drawing.Point(81, 11)
        Me.mkFleteInterno.Name = "mkFleteInterno"
        Me.mkFleteInterno.Size = New System.Drawing.Size(104, 20)
        Me.mkFleteInterno.TabIndex = 6
        Me.mkFleteInterno.Text = "0.0000000000"
        Me.mkFleteInterno.Value = New Decimal(New Integer() {0, 0, 0, 655360})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Otros Gastos :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 58)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Deposito X Nucleo :"
        '
        'CkGestion
        '
        Me.CkGestion.AutoSize = True
        Me.CkGestion.Enabled = False
        Me.CkGestion.Location = New System.Drawing.Point(8, 33)
        Me.CkGestion.Name = "CkGestion"
        Me.CkGestion.Size = New System.Drawing.Size(157, 17)
        Me.CkGestion.TabIndex = 15
        Me.CkGestion.TabStop = False
        Me.CkGestion.Text = "Aplica Gestion de Compra ?"
        Me.CkGestion.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(179, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Gestion de Compra :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Flete Interno :"
        '
        'frmImportacionDet
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(490, 320)
        Me.ControlBox = False
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportacionDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalles"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDesPar As System.Windows.Forms.TextBox
    Friend WithEvents txtCodPar As System.Windows.Forms.TextBox
    Friend WithEvents txtUnidad As System.Windows.Forms.TextBox
    Friend WithEvents txtDesMer As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents mkOtroGasto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkNucleo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkGestionCompra As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkFleteInterno As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CkGestion As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents mkCosSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkCosDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents mkPeso As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNomPed As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCanFac As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCanMer As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPartida As System.Windows.Forms.Button
    Friend WithEvents mkPreMer As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
