<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarDetalle_Documento
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
        Me.components = New System.ComponentModel.Container
        Dim cmbPedidos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregarDetalle_Documento))
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.txtCantidadPendiente = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbPedidos = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtalmacen = New System.Windows.Forms.TextBox
        Me.btnBuscarAlmacen = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.gbSubDatos1 = New System.Windows.Forms.GroupBox
        Me.cbAnulado = New System.Windows.Forms.CheckBox
        Me.cbApliNucleo = New System.Windows.Forms.CheckBox
        Me.cbApliGes = New System.Windows.Forms.CheckBox
        Me.cbApliFle = New System.Windows.Forms.CheckBox
        Me.txtItem = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCanMer = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.gbNuevocodigo = New System.Windows.Forms.GroupBox
        Me.txtCodPartida = New System.Windows.Forms.TextBox
        Me.txtCodPais = New System.Windows.Forms.TextBox
        Me.txtCodMar = New System.Windows.Forms.TextBox
        Me.txtObsMer = New System.Windows.Forms.TextBox
        Me.txtDesPar = New System.Windows.Forms.TextBox
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtDeaMer = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPartida = New System.Windows.Forms.TextBox
        Me.btnBuscarPartida = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtDesMer2 = New System.Windows.Forms.TextBox
        Me.txtDesMer1 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPais = New System.Windows.Forms.TextBox
        Me.btnBuscarPais = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtMarca = New System.Windows.Forms.TextBox
        Me.btnBuscarMarca = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button
        Me.txtCodMer = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.gbDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSubDatos1.SuspendLayout()
        Me.gbNuevocodigo.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.txtCantidadPendiente)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.GroupBox1)
        Me.gbDatos.Controls.Add(Me.gbSubDatos1)
        Me.gbDatos.Controls.Add(Me.txtItem)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.txtCanMer)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.gbNuevocodigo)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(6, 4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(504, 444)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Generales"
        '
        'txtCantidadPendiente
        '
        Me.txtCantidadPendiente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadPendiente.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtCantidadPendiente.Location = New System.Drawing.Point(319, 15)
        Me.txtCantidadPendiente.MaxLength = 3
        Me.txtCantidadPendiente.Name = "txtCantidadPendiente"
        Me.txtCantidadPendiente.ReadOnly = True
        Me.txtCantidadPendiente.Size = New System.Drawing.Size(50, 20)
        Me.txtCantidadPendiente.TabIndex = 21
        Me.txtCantidadPendiente.TabStop = False
        Me.txtCantidadPendiente.Text = "0"
        Me.txtCantidadPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(245, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Cant. Pend."
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox1.Controls.Add(Me.cmbPedidos)
        Me.GroupBox1.Controls.Add(Me.txtalmacen)
        Me.GroupBox1.Controls.Add(Me.btnBuscarAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 366)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 41)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pedido"
        '
        'cmbPedidos
        '
        Me.cmbPedidos.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPedidos_DesignTimeLayout.LayoutString = resources.GetString("cmbPedidos_DesignTimeLayout.LayoutString")
        Me.cmbPedidos.DesignTimeLayout = cmbPedidos_DesignTimeLayout
        Me.cmbPedidos.Location = New System.Drawing.Point(71, 13)
        Me.cmbPedidos.Name = "cmbPedidos"
        Me.cmbPedidos.SelectedIndex = -1
        Me.cmbPedidos.SelectedItem = Nothing
        Me.cmbPedidos.Size = New System.Drawing.Size(180, 20)
        Me.cmbPedidos.TabIndex = 0
        Me.cmbPedidos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtalmacen
        '
        Me.txtalmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtalmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtalmacen.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtalmacen.Location = New System.Drawing.Point(306, 13)
        Me.txtalmacen.MaxLength = 3
        Me.txtalmacen.Name = "txtalmacen"
        Me.txtalmacen.ReadOnly = True
        Me.txtalmacen.Size = New System.Drawing.Size(163, 20)
        Me.txtalmacen.TabIndex = 1
        Me.txtalmacen.TabStop = False
        '
        'btnBuscarAlmacen
        '
        Me.btnBuscarAlmacen.Image = CType(resources.GetObject("btnBuscarAlmacen.Image"), System.Drawing.Image)
        Me.btnBuscarAlmacen.Location = New System.Drawing.Point(469, 12)
        Me.btnBuscarAlmacen.Name = "btnBuscarAlmacen"
        Me.btnBuscarAlmacen.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarAlmacen.TabIndex = 2
        Me.btnBuscarAlmacen.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(254, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Almacén"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Nº Pedido"
        '
        'gbSubDatos1
        '
        Me.gbSubDatos1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbSubDatos1.Controls.Add(Me.cbAnulado)
        Me.gbSubDatos1.Controls.Add(Me.cbApliNucleo)
        Me.gbSubDatos1.Controls.Add(Me.cbApliGes)
        Me.gbSubDatos1.Controls.Add(Me.cbApliFle)
        Me.gbSubDatos1.Location = New System.Drawing.Point(3, 408)
        Me.gbSubDatos1.Name = "gbSubDatos1"
        Me.gbSubDatos1.Size = New System.Drawing.Size(503, 30)
        Me.gbSubDatos1.TabIndex = 4
        Me.gbSubDatos1.TabStop = False
        '
        'cbAnulado
        '
        Me.cbAnulado.AutoSize = True
        Me.cbAnulado.Location = New System.Drawing.Point(415, 11)
        Me.cbAnulado.Name = "cbAnulado"
        Me.cbAnulado.Size = New System.Drawing.Size(72, 17)
        Me.cbAnulado.TabIndex = 3
        Me.cbAnulado.Text = "Anulado"
        Me.cbAnulado.UseVisualStyleBackColor = True
        '
        'cbApliNucleo
        '
        Me.cbApliNucleo.AutoSize = True
        Me.cbApliNucleo.Location = New System.Drawing.Point(271, 11)
        Me.cbApliNucleo.Name = "cbApliNucleo"
        Me.cbApliNucleo.Size = New System.Drawing.Size(142, 17)
        Me.cbApliNucleo.TabIndex = 2
        Me.cbApliNucleo.Text = "Deposito por Núcleo"
        Me.cbApliNucleo.UseVisualStyleBackColor = True
        '
        'cbApliGes
        '
        Me.cbApliGes.AutoSize = True
        Me.cbApliGes.Location = New System.Drawing.Point(129, 11)
        Me.cbApliGes.Name = "cbApliGes"
        Me.cbApliGes.Size = New System.Drawing.Size(139, 17)
        Me.cbApliGes.TabIndex = 1
        Me.cbApliGes.Text = "Gestión de compra?"
        Me.cbApliGes.UseVisualStyleBackColor = True
        '
        'cbApliFle
        '
        Me.cbApliFle.AutoSize = True
        Me.cbApliFle.Location = New System.Drawing.Point(18, 11)
        Me.cbApliFle.Name = "cbApliFle"
        Me.cbApliFle.Size = New System.Drawing.Size(104, 17)
        Me.cbApliFle.TabIndex = 0
        Me.cbApliFle.Text = "Flete interno?"
        Me.cbApliFle.UseVisualStyleBackColor = True
        '
        'txtItem
        '
        Me.txtItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItem.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtItem.Location = New System.Drawing.Point(40, 15)
        Me.txtItem.MaxLength = 18
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(67, 20)
        Me.txtItem.TabIndex = 0
        Me.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Item"
        '
        'txtCanMer
        '
        Me.txtCanMer.Location = New System.Drawing.Point(173, 15)
        Me.txtCanMer.Maximum = 10000
        Me.txtCanMer.MaxLength = 200
        Me.txtCanMer.Minimum = 1
        Me.txtCanMer.Name = "txtCanMer"
        Me.txtCanMer.Size = New System.Drawing.Size(66, 20)
        Me.txtCanMer.TabIndex = 1
        Me.txtCanMer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCanMer.Value = 1
        Me.txtCanMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(114, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Cantidad"
        '
        'gbNuevocodigo
        '
        Me.gbNuevocodigo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbNuevocodigo.Controls.Add(Me.txtCodPartida)
        Me.gbNuevocodigo.Controls.Add(Me.txtCodPais)
        Me.gbNuevocodigo.Controls.Add(Me.txtCodMar)
        Me.gbNuevocodigo.Controls.Add(Me.txtObsMer)
        Me.gbNuevocodigo.Controls.Add(Me.txtDesPar)
        Me.gbNuevocodigo.Controls.Add(Me.txtTotal)
        Me.gbNuevocodigo.Controls.Add(Me.txtDeaMer)
        Me.gbNuevocodigo.Controls.Add(Me.Label4)
        Me.gbNuevocodigo.Controls.Add(Me.Label8)
        Me.gbNuevocodigo.Controls.Add(Me.txtPartida)
        Me.gbNuevocodigo.Controls.Add(Me.btnBuscarPartida)
        Me.gbNuevocodigo.Controls.Add(Me.Label16)
        Me.gbNuevocodigo.Controls.Add(Me.txtDesMer2)
        Me.gbNuevocodigo.Controls.Add(Me.txtDesMer1)
        Me.gbNuevocodigo.Controls.Add(Me.Label5)
        Me.gbNuevocodigo.Controls.Add(Me.Label6)
        Me.gbNuevocodigo.Controls.Add(Me.txtPais)
        Me.gbNuevocodigo.Controls.Add(Me.btnBuscarPais)
        Me.gbNuevocodigo.Controls.Add(Me.Label15)
        Me.gbNuevocodigo.Controls.Add(Me.txtMarca)
        Me.gbNuevocodigo.Controls.Add(Me.btnBuscarMarca)
        Me.gbNuevocodigo.Controls.Add(Me.Label17)
        Me.gbNuevocodigo.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbNuevocodigo.Controls.Add(Me.txtCodMer)
        Me.gbNuevocodigo.Controls.Add(Me.Label1)
        Me.gbNuevocodigo.Controls.Add(Me.Label21)
        Me.gbNuevocodigo.Location = New System.Drawing.Point(9, 38)
        Me.gbNuevocodigo.Name = "gbNuevocodigo"
        Me.gbNuevocodigo.Size = New System.Drawing.Size(487, 322)
        Me.gbNuevocodigo.TabIndex = 2
        Me.gbNuevocodigo.TabStop = False
        Me.gbNuevocodigo.Text = "Mercadería"
        '
        'txtCodPartida
        '
        Me.txtCodPartida.Location = New System.Drawing.Point(99, 215)
        Me.txtCodPartida.Name = "txtCodPartida"
        Me.txtCodPartida.Size = New System.Drawing.Size(50, 20)
        Me.txtCodPartida.TabIndex = 24
        '
        'txtCodPais
        '
        Me.txtCodPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodPais.Location = New System.Drawing.Point(99, 79)
        Me.txtCodPais.MaxLength = 50
        Me.txtCodPais.Name = "txtCodPais"
        Me.txtCodPais.Size = New System.Drawing.Size(39, 20)
        Me.txtCodPais.TabIndex = 23
        '
        'txtCodMar
        '
        Me.txtCodMar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMar.Location = New System.Drawing.Point(99, 53)
        Me.txtCodMar.MaxLength = 50
        Me.txtCodMar.Name = "txtCodMar"
        Me.txtCodMar.Size = New System.Drawing.Size(39, 20)
        Me.txtCodMar.TabIndex = 22
        '
        'txtObsMer
        '
        Me.txtObsMer.Location = New System.Drawing.Point(99, 159)
        Me.txtObsMer.Multiline = True
        Me.txtObsMer.Name = "txtObsMer"
        Me.txtObsMer.Size = New System.Drawing.Size(268, 52)
        Me.txtObsMer.TabIndex = 11
        '
        'txtDesPar
        '
        Me.txtDesPar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesPar.Location = New System.Drawing.Point(99, 244)
        Me.txtDesPar.MaxLength = 50
        Me.txtDesPar.Name = "txtDesPar"
        Me.txtDesPar.ReadOnly = True
        Me.txtDesPar.Size = New System.Drawing.Size(322, 20)
        Me.txtDesPar.TabIndex = 12
        Me.txtDesPar.TabStop = False
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.DarkKhaki
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotal.Location = New System.Drawing.Point(310, 289)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(112, 21)
        Me.txtTotal.TabIndex = 18
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDeaMer
        '
        Me.txtDeaMer.Location = New System.Drawing.Point(99, 286)
        Me.txtDeaMer.MaxLength = 10
        Me.txtDeaMer.Name = "txtDeaMer"
        Me.txtDeaMer.Size = New System.Drawing.Size(95, 20)
        Me.txtDeaMer.TabIndex = 2
        Me.txtDeaMer.TabStop = False
        Me.txtDeaMer.Text = "0.00"
        Me.txtDeaMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDeaMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(246, 291)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "TOTAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(59, 289)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Precio"
        '
        'txtPartida
        '
        Me.txtPartida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartida.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPartida.Location = New System.Drawing.Point(152, 215)
        Me.txtPartida.MaxLength = 3
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.ReadOnly = True
        Me.txtPartida.Size = New System.Drawing.Size(97, 20)
        Me.txtPartida.TabIndex = 9
        Me.txtPartida.TabStop = False
        '
        'btnBuscarPartida
        '
        Me.btnBuscarPartida.Image = CType(resources.GetObject("btnBuscarPartida.Image"), System.Drawing.Image)
        Me.btnBuscarPartida.Location = New System.Drawing.Point(249, 214)
        Me.btnBuscarPartida.Name = "btnBuscarPartida"
        Me.btnBuscarPartida.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPartida.TabIndex = 10
        Me.btnBuscarPartida.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(17, 221)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Partida Aran."
        '
        'txtDesMer2
        '
        Me.txtDesMer2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesMer2.Location = New System.Drawing.Point(99, 129)
        Me.txtDesMer2.MaxLength = 50
        Me.txtDesMer2.Name = "txtDesMer2"
        Me.txtDesMer2.Size = New System.Drawing.Size(268, 20)
        Me.txtDesMer2.TabIndex = 6
        '
        'txtDesMer1
        '
        Me.txtDesMer1.Location = New System.Drawing.Point(99, 107)
        Me.txtDesMer1.MaxLength = 50
        Me.txtDesMer1.Name = "txtDesMer1"
        Me.txtDesMer1.Size = New System.Drawing.Size(268, 20)
        Me.txtDesMer1.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Descrip.2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Descrip.1"
        '
        'txtPais
        '
        Me.txtPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPais.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPais.Location = New System.Drawing.Point(139, 79)
        Me.txtPais.MaxLength = 3
        Me.txtPais.Name = "txtPais"
        Me.txtPais.ReadOnly = True
        Me.txtPais.Size = New System.Drawing.Size(202, 20)
        Me.txtPais.TabIndex = 7
        Me.txtPais.TabStop = False
        '
        'btnBuscarPais
        '
        Me.btnBuscarPais.Image = CType(resources.GetObject("btnBuscarPais.Image"), System.Drawing.Image)
        Me.btnBuscarPais.Location = New System.Drawing.Point(341, 78)
        Me.btnBuscarPais.Name = "btnBuscarPais"
        Me.btnBuscarPais.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPais.TabIndex = 8
        Me.btnBuscarPais.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(55, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "País"
        '
        'txtMarca
        '
        Me.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMarca.Location = New System.Drawing.Point(139, 53)
        Me.txtMarca.MaxLength = 3
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(202, 20)
        Me.txtMarca.TabIndex = 4
        Me.txtMarca.TabStop = False
        '
        'btnBuscarMarca
        '
        Me.btnBuscarMarca.Image = CType(resources.GetObject("btnBuscarMarca.Image"), System.Drawing.Image)
        Me.btnBuscarMarca.Location = New System.Drawing.Point(341, 53)
        Me.btnBuscarMarca.Name = "btnBuscarMarca"
        Me.btnBuscarMarca.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMarca.TabIndex = 5
        Me.btnBuscarMarca.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(55, 57)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Marca"
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = CType(resources.GetObject("btnBuscarMercaderia.Image"), System.Drawing.Image)
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(213, 21)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderia.TabIndex = 1
        Me.btnBuscarMercaderia.Text = " "
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodMer.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodMer.Location = New System.Drawing.Point(99, 22)
        Me.txtCodMer.MaxLength = 18
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(114, 20)
        Me.txtCodMer.TabIndex = 0
        Me.txtCodMer.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Código"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(19, 162)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Observación"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(363, 454)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(437, 454)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmAgregarDetalle_Documento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 491)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregarDetalle_Documento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Agregar Detalle"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSubDatos1.ResumeLayout(False)
        Me.gbSubDatos1.PerformLayout()
        Me.gbNuevocodigo.ResumeLayout(False)
        Me.gbNuevocodigo.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtCanMer As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbNuevocodigo As System.Windows.Forms.GroupBox
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarPais As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarMarca As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDesMer2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDesMer1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarPartida As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDeaMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbSubDatos1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbApliFle As System.Windows.Forms.CheckBox
    Friend WithEvents txtDesPar As System.Windows.Forms.TextBox
    Friend WithEvents cbAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents cbApliNucleo As System.Windows.Forms.CheckBox
    Friend WithEvents cbApliGes As System.Windows.Forms.CheckBox
    Friend WithEvents txtObsMer As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtalmacen As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarAlmacen As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbPedidos As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadPendiente As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCodMar As System.Windows.Forms.TextBox
    Friend WithEvents txtCodPartida As System.Windows.Forms.TextBox
    Friend WithEvents txtCodPais As System.Windows.Forms.TextBox

End Class
