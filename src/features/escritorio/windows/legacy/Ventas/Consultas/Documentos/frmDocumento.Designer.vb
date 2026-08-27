<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumento
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
        Dim cmbPrecio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumento))
        Dim cmbMedio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.cmbPrecio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.cmbMedio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDireccionShip = New System.Windows.Forms.TextBox
        Me.txtdireccionSold = New System.Windows.Forms.TextBox
        Me.txtShip = New System.Windows.Forms.TextBox
        Me.btnBuscarShip = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTerms = New System.Windows.Forms.TextBox
        Me.txtOrders = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMarks = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.txtSold = New System.Windows.Forms.TextBox
        Me.btnBuscarSold = New System.Windows.Forms.Button
        Me.txtNumDoc = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbTotal = New System.Windows.Forms.GroupBox
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.gbPrecios = New System.Windows.Forms.GroupBox
        Me.txtGastos = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtDepNuc = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtGesCom = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtFleInt = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lblTotal = New System.Windows.Forms.TextBox
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.biEditar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.biGuardar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.biGenerarDocumento = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.biModificarReferencia = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.lblUbicacion = New System.Windows.Forms.Label
        CType(Me.cmbPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTotal.SuspendLayout()
        Me.gbPrecios.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbPrecio
        '
        Me.cmbPrecio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPrecio_DesignTimeLayout.LayoutString = resources.GetString("cmbPrecio_DesignTimeLayout.LayoutString")
        Me.cmbPrecio.DesignTimeLayout = cmbPrecio_DesignTimeLayout
        Me.cmbPrecio.Location = New System.Drawing.Point(401, 15)
        Me.cmbPrecio.Name = "cmbPrecio"
        Me.cmbPrecio.SelectedIndex = -1
        Me.cmbPrecio.SelectedItem = Nothing
        Me.cmbPrecio.Size = New System.Drawing.Size(111, 20)
        Me.cmbPrecio.TabIndex = 2
        Me.cmbPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(133, 98)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(132, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(132, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(132, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(129, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(132, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.cmbMedio)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.txtDireccionShip)
        Me.gbDatos.Controls.Add(Me.txtdireccionSold)
        Me.gbDatos.Controls.Add(Me.txtShip)
        Me.gbDatos.Controls.Add(Me.btnBuscarShip)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.cmbPrecio)
        Me.gbDatos.Controls.Add(Me.txtTerms)
        Me.gbDatos.Controls.Add(Me.txtOrders)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.txtMarks)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.txtFecDoc)
        Me.gbDatos.Controls.Add(Me.txtSold)
        Me.gbDatos.Controls.Add(Me.btnBuscarSold)
        Me.gbDatos.Controls.Add(Me.txtNumDoc)
        Me.gbDatos.Controls.Add(Me.Label15)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.Label12)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.gbTotal)
        Me.gbDatos.Controls.Add(Me.gbPrecios)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(4, 39)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(691, 186)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Pedido de Importación"
        '
        'cmbMedio
        '
        Me.cmbMedio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMedio_DesignTimeLayout.LayoutString = resources.GetString("cmbMedio_DesignTimeLayout.LayoutString")
        Me.cmbMedio.DesignTimeLayout = cmbMedio_DesignTimeLayout
        Me.cmbMedio.Location = New System.Drawing.Point(572, 15)
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
        Me.Label3.Location = New System.Drawing.Point(531, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Medio"
        '
        'txtDireccionShip
        '
        Me.txtDireccionShip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccionShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccionShip.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtDireccionShip.Location = New System.Drawing.Point(361, 57)
        Me.txtDireccionShip.MaxLength = 3
        Me.txtDireccionShip.Name = "txtDireccionShip"
        Me.txtDireccionShip.ReadOnly = True
        Me.txtDireccionShip.Size = New System.Drawing.Size(322, 20)
        Me.txtDireccionShip.TabIndex = 9
        Me.txtDireccionShip.TabStop = False
        '
        'txtdireccionSold
        '
        Me.txtdireccionSold.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdireccionSold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdireccionSold.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtdireccionSold.Location = New System.Drawing.Point(361, 36)
        Me.txtdireccionSold.MaxLength = 3
        Me.txtdireccionSold.Name = "txtdireccionSold"
        Me.txtdireccionSold.ReadOnly = True
        Me.txtdireccionSold.Size = New System.Drawing.Size(322, 20)
        Me.txtdireccionSold.TabIndex = 6
        Me.txtdireccionSold.TabStop = False
        '
        'txtShip
        '
        Me.txtShip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShip.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtShip.Location = New System.Drawing.Point(63, 57)
        Me.txtShip.MaxLength = 3
        Me.txtShip.Name = "txtShip"
        Me.txtShip.ReadOnly = True
        Me.txtShip.Size = New System.Drawing.Size(262, 20)
        Me.txtShip.TabIndex = 7
        '
        'btnBuscarShip
        '
        Me.btnBuscarShip.Image = CType(resources.GetObject("btnBuscarShip.Image"), System.Drawing.Image)
        Me.btnBuscarShip.Location = New System.Drawing.Point(325, 56)
        Me.btnBuscarShip.Name = "btnBuscarShip"
        Me.btnBuscarShip.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarShip.TabIndex = 8
        Me.btnBuscarShip.TabStop = False
        Me.btnBuscarShip.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 60)
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
        Me.txtTerms.Location = New System.Drawing.Point(63, 78)
        Me.txtTerms.MaxLength = 50
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.Size = New System.Drawing.Size(287, 20)
        Me.txtTerms.TabIndex = 10
        '
        'txtOrders
        '
        Me.txtOrders.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrders.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtOrders.Location = New System.Drawing.Point(401, 99)
        Me.txtOrders.MaxLength = 50
        Me.txtOrders.Name = "txtOrders"
        Me.txtOrders.Size = New System.Drawing.Size(282, 20)
        Me.txtOrders.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(359, 102)
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
        Me.txtMarks.Location = New System.Drawing.Point(401, 78)
        Me.txtMarks.MaxLength = 50
        Me.txtMarks.Name = "txtMarks"
        Me.txtMarks.Size = New System.Drawing.Size(282, 20)
        Me.txtMarks.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(359, 81)
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
        Me.txtFecDoc.Location = New System.Drawing.Point(252, 15)
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
        Me.txtSold.Location = New System.Drawing.Point(63, 36)
        Me.txtSold.MaxLength = 3
        Me.txtSold.Name = "txtSold"
        Me.txtSold.ReadOnly = True
        Me.txtSold.Size = New System.Drawing.Size(262, 20)
        Me.txtSold.TabIndex = 4
        '
        'btnBuscarSold
        '
        Me.btnBuscarSold.Image = CType(resources.GetObject("btnBuscarSold.Image"), System.Drawing.Image)
        Me.btnBuscarSold.Location = New System.Drawing.Point(325, 35)
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
        Me.txtNumDoc.Location = New System.Drawing.Point(63, 15)
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
        Me.Label15.Location = New System.Drawing.Point(211, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Fecha"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Terms"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(359, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Precio"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Sold to"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Invoice"
        '
        'gbTotal
        '
        Me.gbTotal.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbTotal.Controls.Add(Me.txtTotalNeto)
        Me.gbTotal.Controls.Add(Me.Label14)
        Me.gbTotal.Location = New System.Drawing.Point(493, 122)
        Me.gbTotal.Name = "gbTotal"
        Me.gbTotal.Size = New System.Drawing.Size(190, 60)
        Me.gbTotal.TabIndex = 15
        Me.gbTotal.TabStop = False
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.Color.DarkKhaki
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNeto.Location = New System.Drawing.Point(33, 30)
        Me.txtTotalNeto.MaxLength = 5
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(130, 22)
        Me.txtTotalNeto.TabIndex = 0
        Me.txtTotalNeto.TabStop = False
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label14.Location = New System.Drawing.Point(69, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 16)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "TOTAL"
        '
        'gbPrecios
        '
        Me.gbPrecios.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbPrecios.Controls.Add(Me.txtGastos)
        Me.gbPrecios.Controls.Add(Me.txtDepNuc)
        Me.gbPrecios.Controls.Add(Me.txtGesCom)
        Me.gbPrecios.Controls.Add(Me.txtFleInt)
        Me.gbPrecios.Controls.Add(Me.Label7)
        Me.gbPrecios.Controls.Add(Me.Label5)
        Me.gbPrecios.Controls.Add(Me.Label11)
        Me.gbPrecios.Controls.Add(Me.Label10)
        Me.gbPrecios.Location = New System.Drawing.Point(10, 122)
        Me.gbPrecios.Name = "gbPrecios"
        Me.gbPrecios.Size = New System.Drawing.Size(477, 60)
        Me.gbPrecios.TabIndex = 14
        Me.gbPrecios.TabStop = False
        Me.gbPrecios.Text = "Costos"
        '
        'txtGastos
        '
        Me.txtGastos.Location = New System.Drawing.Point(335, 35)
        Me.txtGastos.MaxLength = 12
        Me.txtGastos.Name = "txtGastos"
        Me.txtGastos.Size = New System.Drawing.Size(100, 20)
        Me.txtGastos.TabIndex = 3
        Me.txtGastos.Text = "0.00"
        Me.txtGastos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtDepNuc
        '
        Me.txtDepNuc.Location = New System.Drawing.Point(119, 35)
        Me.txtDepNuc.MaxLength = 12
        Me.txtDepNuc.Name = "txtDepNuc"
        Me.txtDepNuc.Size = New System.Drawing.Size(100, 20)
        Me.txtDepNuc.TabIndex = 2
        Me.txtDepNuc.Text = "0.00"
        Me.txtDepNuc.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtGesCom
        '
        Me.txtGesCom.Location = New System.Drawing.Point(335, 13)
        Me.txtGesCom.MaxLength = 12
        Me.txtGesCom.Name = "txtGesCom"
        Me.txtGesCom.Size = New System.Drawing.Size(100, 20)
        Me.txtGesCom.TabIndex = 1
        Me.txtGesCom.Text = "0.00"
        Me.txtGesCom.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtFleInt
        '
        Me.txtFleInt.Location = New System.Drawing.Point(119, 13)
        Me.txtFleInt.MaxLength = 12
        Me.txtFleInt.Name = "txtFleInt"
        Me.txtFleInt.Size = New System.Drawing.Size(100, 20)
        Me.txtFleInt.TabIndex = 0
        Me.txtFleInt.Text = "0.00"
        Me.txtFleInt.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Deposito x Núcleo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Felte Interno"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(253, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Total Flete"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(239, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Gestión Compra"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvDatos)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 236)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(708, 285)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lista de Detalle"
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(4, 35)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(698, 230)
        Me.dgvDatos.TabIndex = 19
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox1.Controls.Add(Me.txtTotal)
        Me.UiGroupBox1.Controls.Add(Me.lblTotal)
        Me.UiGroupBox1.Location = New System.Drawing.Point(4, 256)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(698, 28)
        Me.UiGroupBox1.TabIndex = 21
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotal.Location = New System.Drawing.Point(579, 8)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(101, 20)
        Me.txtTotal.TabIndex = 10
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotal.Location = New System.Drawing.Point(12, 8)
        Me.lblTotal.MaxLength = 20
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.ReadOnly = True
        Me.lblTotal.Size = New System.Drawing.Size(567, 20)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.Text = "TOTAL "
        Me.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 527)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(714, 20)
        Me.ssBarra.TabIndex = 8
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(150, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biEditar, Me.ToolStripSeparator1, Me.biGuardar, Me.ToolStripSeparator2, Me.biDeshacer, Me.ToolStripSeparator3, Me.biGenerarDocumento, Me.ToolStripSeparator4, Me.biModificarReferencia, Me.ToolStripSeparator5, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(714, 31)
        Me.ToolStrip.TabIndex = 9
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Black
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Cabecera del Documento"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Guardar Cambios Realizados"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios Realizados"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerarDocumento
        '
        Me.biGenerarDocumento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarDocumento.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.biGenerarDocumento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarDocumento.Name = "biGenerarDocumento"
        Me.biGenerarDocumento.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarDocumento.Text = "Generar Documento"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biModificarReferencia
        '
        Me.biModificarReferencia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biModificarReferencia.Image = Global.SIGECOM.My.Resources.Resources.UpLoad
        Me.biModificarReferencia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biModificarReferencia.Name = "biModificarReferencia"
        Me.biModificarReferencia.Size = New System.Drawing.Size(28, 28)
        Me.biModificarReferencia.Text = "Modificar Referencia"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
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
        'frmDocumento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(714, 547)
        Me.Controls.Add(Me.lblUbicacion)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDocumento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Documento"
        CType(Me.cmbPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTotal.ResumeLayout(False)
        Me.gbTotal.PerformLayout()
        Me.gbPrecios.ResumeLayout(False)
        Me.gbPrecios.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbPrecio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtOrders As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMarks As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtSold As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarSold As System.Windows.Forms.Button
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDireccionShip As System.Windows.Forms.TextBox
    Friend WithEvents txtdireccionSold As System.Windows.Forms.TextBox
    Friend WithEvents txtShip As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarShip As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbMedio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbPrecios As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtGastos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDepNuc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtGesCom As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtFleInt As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbTotal As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGenerarDocumento As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biModificarReferencia As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label

End Class
