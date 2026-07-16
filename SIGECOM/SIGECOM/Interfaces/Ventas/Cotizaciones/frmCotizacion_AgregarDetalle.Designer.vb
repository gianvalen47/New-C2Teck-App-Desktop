<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCotizacion_AgregarDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCotizacion_AgregarDetalle))
        Dim cmbModMer_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.txtPreMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMensajePrecio2 = New System.Windows.Forms.Label()
        Me.lblMensajePrecio = New System.Windows.Forms.Label()
        Me.btnBuscarMarca = New System.Windows.Forms.Button()
        Me.cbNoCore = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblPrecioSug2 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.lblDsctoSug2 = New System.Windows.Forms.Label()
        Me.cbSugerir = New System.Windows.Forms.CheckBox()
        Me.txtDsctoSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPrecioSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblDsctoSug = New System.Windows.Forms.Label()
        Me.lblPrecioSug = New System.Windows.Forms.Label()
        Me.txtItem = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbImportado = New System.Windows.Forms.CheckBox()
        Me.cmbModMer = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDscMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.txtCanMer = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDesMer = New System.Windows.Forms.TextBox()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbModMer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.txtPreMer)
        Me.gbDatos.Controls.Add(Me.lblMensajePrecio2)
        Me.gbDatos.Controls.Add(Me.lblMensajePrecio)
        Me.gbDatos.Controls.Add(Me.btnBuscarMarca)
        Me.gbDatos.Controls.Add(Me.cbNoCore)
        Me.gbDatos.Controls.Add(Me.Label17)
        Me.gbDatos.Controls.Add(Me.lblPrecioSug2)
        Me.gbDatos.Controls.Add(Me.txtMarca)
        Me.gbDatos.Controls.Add(Me.lblDsctoSug2)
        Me.gbDatos.Controls.Add(Me.cbSugerir)
        Me.gbDatos.Controls.Add(Me.txtDsctoSug)
        Me.gbDatos.Controls.Add(Me.txtPrecioSug)
        Me.gbDatos.Controls.Add(Me.lblDsctoSug)
        Me.gbDatos.Controls.Add(Me.lblPrecioSug)
        Me.gbDatos.Controls.Add(Me.txtItem)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Controls.Add(Me.cbImportado)
        Me.gbDatos.Controls.Add(Me.cmbModMer)
        Me.gbDatos.Controls.Add(Me.txtObservacion)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.txtReferencia)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.txtDscMer)
        Me.gbDatos.Controls.Add(Me.txtStock)
        Me.gbDatos.Controls.Add(Me.txtCanMer)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.txtTotal)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbDatos.Controls.Add(Me.Panel1)
        Me.gbDatos.Controls.Add(Me.txtDesMer)
        Me.gbDatos.Controls.Add(Me.txtCodMer)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label14)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Location = New System.Drawing.Point(5, 2)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(608, 242)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Articulo"
        '
        'txtPreMer
        '
        Me.txtPreMer.Location = New System.Drawing.Point(229, 88)
        Me.txtPreMer.MaxLength = 10
        Me.txtPreMer.Name = "txtPreMer"
        Me.txtPreMer.Size = New System.Drawing.Size(98, 20)
        Me.txtPreMer.TabIndex = 17
        Me.txtPreMer.Text = "0.00"
        Me.txtPreMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPreMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMensajePrecio2
        '
        Me.lblMensajePrecio2.AutoSize = True
        Me.lblMensajePrecio2.ForeColor = System.Drawing.Color.Red
        Me.lblMensajePrecio2.Location = New System.Drawing.Point(326, 92)
        Me.lblMensajePrecio2.Name = "lblMensajePrecio2"
        Me.lblMensajePrecio2.Size = New System.Drawing.Size(11, 13)
        Me.lblMensajePrecio2.TabIndex = 42
        Me.lblMensajePrecio2.Text = "*"
        Me.lblMensajePrecio2.Visible = False
        '
        'lblMensajePrecio
        '
        Me.lblMensajePrecio.AutoSize = True
        Me.lblMensajePrecio.ForeColor = System.Drawing.Color.Red
        Me.lblMensajePrecio.Location = New System.Drawing.Point(5, 210)
        Me.lblMensajePrecio.Name = "lblMensajePrecio"
        Me.lblMensajePrecio.Size = New System.Drawing.Size(275, 13)
        Me.lblMensajePrecio.TabIndex = 41
        Me.lblMensajePrecio.Text = "* Precio sugerido por el Sistema. Consultar con Finanzas."
        Me.lblMensajePrecio.Visible = False
        '
        'btnBuscarMarca
        '
        Me.btnBuscarMarca.Image = CType(resources.GetObject("btnBuscarMarca.Image"), System.Drawing.Image)
        Me.btnBuscarMarca.Location = New System.Drawing.Point(578, 37)
        Me.btnBuscarMarca.Name = "btnBuscarMarca"
        Me.btnBuscarMarca.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMarca.TabIndex = 13
        Me.btnBuscarMarca.TabStop = False
        Me.btnBuscarMarca.UseVisualStyleBackColor = True
        '
        'cbNoCore
        '
        Me.cbNoCore.AutoSize = True
        Me.cbNoCore.Location = New System.Drawing.Point(8, 166)
        Me.cbNoCore.Name = "cbNoCore"
        Me.cbNoCore.Size = New System.Drawing.Size(96, 17)
        Me.cbNoCore.TabIndex = 40
        Me.cbNoCore.TabStop = False
        Me.cbNoCore.Text = "No Incluir Core"
        Me.cbNoCore.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(410, 42)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 13)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Marca"
        '
        'lblPrecioSug2
        '
        Me.lblPrecioSug2.AutoSize = True
        Me.lblPrecioSug2.Location = New System.Drawing.Point(247, 173)
        Me.lblPrecioSug2.Name = "lblPrecioSug2"
        Me.lblPrecioSug2.Size = New System.Drawing.Size(55, 13)
        Me.lblPrecioSug2.TabIndex = 39
        Me.lblPrecioSug2.Text = "Sugerido :"
        Me.lblPrecioSug2.Visible = False
        '
        'txtMarca
        '
        Me.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMarca.Location = New System.Drawing.Point(447, 38)
        Me.txtMarca.MaxLength = 50
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(131, 20)
        Me.txtMarca.TabIndex = 11
        '
        'lblDsctoSug2
        '
        Me.lblDsctoSug2.AutoSize = True
        Me.lblDsctoSug2.Location = New System.Drawing.Point(414, 173)
        Me.lblDsctoSug2.Name = "lblDsctoSug2"
        Me.lblDsctoSug2.Size = New System.Drawing.Size(55, 13)
        Me.lblDsctoSug2.TabIndex = 38
        Me.lblDsctoSug2.Text = "Sugerido :"
        Me.lblDsctoSug2.Visible = False
        '
        'cbSugerir
        '
        Me.cbSugerir.AutoSize = True
        Me.cbSugerir.Location = New System.Drawing.Point(131, 166)
        Me.cbSugerir.Name = "cbSugerir"
        Me.cbSugerir.Size = New System.Drawing.Size(92, 17)
        Me.cbSugerir.TabIndex = 37
        Me.cbSugerir.TabStop = False
        Me.cbSugerir.Text = "Sugerir Precio"
        Me.cbSugerir.UseVisualStyleBackColor = True
        '
        'txtDsctoSug
        '
        Me.txtDsctoSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsctoSug.FormatString = "#0.00"
        Me.txtDsctoSug.Location = New System.Drawing.Point(477, 166)
        Me.txtDsctoSug.Name = "txtDsctoSug"
        Me.txtDsctoSug.Size = New System.Drawing.Size(73, 20)
        Me.txtDsctoSug.TabIndex = 36
        Me.txtDsctoSug.Text = "0.00"
        Me.txtDsctoSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDsctoSug.Visible = False
        '
        'txtPrecioSug
        '
        Me.txtPrecioSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioSug.FormatString = "#0.00"
        Me.txtPrecioSug.Location = New System.Drawing.Point(307, 166)
        Me.txtPrecioSug.Name = "txtPrecioSug"
        Me.txtPrecioSug.Size = New System.Drawing.Size(76, 20)
        Me.txtPrecioSug.TabIndex = 34
        Me.txtPrecioSug.Text = "0.00"
        Me.txtPrecioSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPrecioSug.Visible = False
        '
        'lblDsctoSug
        '
        Me.lblDsctoSug.AutoSize = True
        Me.lblDsctoSug.Location = New System.Drawing.Point(414, 157)
        Me.lblDsctoSug.Name = "lblDsctoSug"
        Me.lblDsctoSug.Size = New System.Drawing.Size(59, 13)
        Me.lblDsctoSug.TabIndex = 35
        Me.lblDsctoSug.Text = "Descuento"
        Me.lblDsctoSug.Visible = False
        '
        'lblPrecioSug
        '
        Me.lblPrecioSug.AutoSize = True
        Me.lblPrecioSug.Location = New System.Drawing.Point(247, 157)
        Me.lblPrecioSug.Name = "lblPrecioSug"
        Me.lblPrecioSug.Size = New System.Drawing.Size(37, 13)
        Me.lblPrecioSug.TabIndex = 33
        Me.lblPrecioSug.Text = "Precio"
        Me.lblPrecioSug.Visible = False
        '
        'txtItem
        '
        Me.txtItem.BackColor = System.Drawing.Color.Beige
        Me.txtItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItem.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtItem.Location = New System.Drawing.Point(408, 14)
        Me.txtItem.Maximum = 10000
        Me.txtItem.MaxLength = 200
        Me.txtItem.Minimum = 1
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(84, 22)
        Me.txtItem.TabIndex = 7
        Me.txtItem.TabStop = False
        Me.txtItem.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtItem.Value = 1
        Me.txtItem.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(361, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Item"
        '
        'cbImportado
        '
        Me.cbImportado.AutoSize = True
        Me.cbImportado.Enabled = False
        Me.cbImportado.Location = New System.Drawing.Point(526, 90)
        Me.cbImportado.Name = "cbImportado"
        Me.cbImportado.Size = New System.Drawing.Size(73, 17)
        Me.cbImportado.TabIndex = 31
        Me.cbImportado.TabStop = False
        Me.cbImportado.Text = "Importado"
        Me.cbImportado.UseVisualStyleBackColor = True
        '
        'cmbModMer
        '
        Me.cmbModMer.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbModMer_DesignTimeLayout.LayoutString = resources.GetString("cmbModMer_DesignTimeLayout.LayoutString")
        Me.cmbModMer.DesignTimeLayout = cmbModMer_DesignTimeLayout
        Me.cmbModMer.Location = New System.Drawing.Point(408, 109)
        Me.cmbModMer.Name = "cmbModMer"
        Me.cmbModMer.SelectedIndex = -1
        Me.cmbModMer.SelectedItem = Nothing
        Me.cmbModMer.Size = New System.Drawing.Size(194, 20)
        Me.cmbModMer.TabIndex = 23
        Me.cmbModMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtObservacion.Location = New System.Drawing.Point(67, 131)
        Me.txtObservacion.MaxLength = 500
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(535, 20)
        Me.txtObservacion.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Observación"
        '
        'txtReferencia
        '
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtReferencia.Location = New System.Drawing.Point(67, 110)
        Me.txtReferencia.MaxLength = 30
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(260, 20)
        Me.txtReferencia.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "C.Merc. Clie."
        '
        'txtDscMer
        '
        Me.txtDscMer.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtDscMer.Location = New System.Drawing.Point(408, 88)
        Me.txtDscMer.MaxLength = 10
        Me.txtDscMer.Name = "txtDscMer"
        Me.txtDscMer.Size = New System.Drawing.Size(62, 20)
        Me.txtDscMer.TabIndex = 19
        Me.txtDscMer.Text = "0.00"
        Me.txtDscMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDscMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtStock
        '
        Me.txtStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStock.Location = New System.Drawing.Point(278, 14)
        Me.txtStock.MaxLength = 50
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(62, 20)
        Me.txtStock.TabIndex = 5
        Me.txtStock.TabStop = False
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCanMer
        '
        Me.txtCanMer.Location = New System.Drawing.Point(67, 88)
        Me.txtCanMer.Maximum = 10000
        Me.txtCanMer.MaxLength = 200
        Me.txtCanMer.Minimum = 1
        Me.txtCanMer.Name = "txtCanMer"
        Me.txtCanMer.Size = New System.Drawing.Size(70, 20)
        Me.txtCanMer.TabIndex = 15
        Me.txtCanMer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCanMer.Value = 1
        Me.txtCanMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(244, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Stock"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(190, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Precio"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.DarkKhaki
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotal.Location = New System.Drawing.Point(425, 204)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(112, 21)
        Me.txtTotal.TabIndex = 27
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Location = New System.Drawing.Point(362, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "TOTAL"
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = CType(resources.GetObject("btnBuscarMercaderia.Image"), System.Drawing.Image)
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(198, 14)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderia.TabIndex = 3
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Desktop
        Me.Panel1.Location = New System.Drawing.Point(11, 197)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(525, 1)
        Me.Panel1.TabIndex = 14
        '
        'txtDesMer
        '
        Me.txtDesMer.BackColor = System.Drawing.SystemColors.Window
        Me.txtDesMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesMer.Location = New System.Drawing.Point(67, 37)
        Me.txtDesMer.MaxLength = 500
        Me.txtDesMer.Multiline = True
        Me.txtDesMer.Name = "txtDesMer"
        Me.txtDesMer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesMer.Size = New System.Drawing.Size(342, 48)
        Me.txtDesMer.TabIndex = 9
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodMer.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodMer.Location = New System.Drawing.Point(67, 15)
        Me.txtCodMer.MaxLength = 30
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(132, 20)
        Me.txtCodMer.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Código"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(351, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Descuento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Cantidad"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(361, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Modelo"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(469, 250)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 31
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(394, 250)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 29
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmCotizacion_AgregarDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 280)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCotizacion_AgregarDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Articulo"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbModMer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtDscMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents txtCanMer As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents txtPreMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtDesMer As System.Windows.Forms.TextBox
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarMarca As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbModMer As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbImportado As System.Windows.Forms.CheckBox
    Friend WithEvents txtItem As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbSugerir As System.Windows.Forms.CheckBox
    Friend WithEvents txtDsctoSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPrecioSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblDsctoSug As System.Windows.Forms.Label
    Friend WithEvents lblPrecioSug As System.Windows.Forms.Label
    Friend WithEvents cbNoCore As System.Windows.Forms.CheckBox
    Friend WithEvents lblPrecioSug2 As System.Windows.Forms.Label
    Friend WithEvents lblDsctoSug2 As System.Windows.Forms.Label
    Friend WithEvents lblMensajePrecio2 As System.Windows.Forms.Label
    Friend WithEvents lblMensajePrecio As System.Windows.Forms.Label

End Class
