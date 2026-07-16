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
        Me.components = New System.ComponentModel.Container()
        Dim cmbPrecio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumento))
        Dim cmbIdFiscalShip_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdFiscalSold_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMedio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodPag_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmbPrecio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btiBuscar = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbTotal = New System.Windows.Forms.GroupBox()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.gbPrecios = New System.Windows.Forms.GroupBox()
        Me.txtTotalDscto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtOtrosGastos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtGesCom = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtFlete = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDepNuc = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtFleInt = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotal = New System.Windows.Forms.TextBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerarDocumento = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biModificarReferencia = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbCodPag = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtFecLlegadaMiami = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtNroPqte = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.gbDetalles = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.cmbPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.cmbIdFiscalShip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdFiscalSold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTotal.SuspendLayout()
        Me.gbPrecios.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalles.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbPrecio
        '
        Me.cmbPrecio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPrecio_DesignTimeLayout.LayoutString = resources.GetString("cmbPrecio_DesignTimeLayout.LayoutString")
        Me.cmbPrecio.DesignTimeLayout = cmbPrecio_DesignTimeLayout
        Me.cmbPrecio.Location = New System.Drawing.Point(416, 17)
        Me.cmbPrecio.Name = "cmbPrecio"
        Me.cmbPrecio.SelectedIndex = -1
        Me.cmbPrecio.SelectedItem = Nothing
        Me.cmbPrecio.Size = New System.Drawing.Size(111, 20)
        Me.cmbPrecio.TabIndex = 2
        Me.cmbPrecio.Visible = False
        Me.cmbPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar, Me.btiBuscar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 120)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'btiBuscar
        '
        Me.btiBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btiBuscar.Name = "btiBuscar"
        Me.btiBuscar.Size = New System.Drawing.Size(126, 22)
        Me.btiBuscar.Text = "Buscar"
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(373, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Precio"
        Me.Label6.Visible = False
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
        'gbTotal
        '
        Me.gbTotal.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbTotal.Controls.Add(Me.txtTotalNeto)
        Me.gbTotal.Controls.Add(Me.Label14)
        Me.gbTotal.Location = New System.Drawing.Point(504, 148)
        Me.gbTotal.Name = "gbTotal"
        Me.gbTotal.Size = New System.Drawing.Size(195, 82)
        Me.gbTotal.TabIndex = 15
        Me.gbTotal.TabStop = False
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNeto.Location = New System.Drawing.Point(33, 43)
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
        Me.Label14.Location = New System.Drawing.Point(69, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 16)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "TOTAL"
        '
        'gbPrecios
        '
        Me.gbPrecios.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbPrecios.Controls.Add(Me.txtTotalDscto)
        Me.gbPrecios.Controls.Add(Me.txtOtrosGastos)
        Me.gbPrecios.Controls.Add(Me.txtGesCom)
        Me.gbPrecios.Controls.Add(Me.Label10)
        Me.gbPrecios.Controls.Add(Me.Label16)
        Me.gbPrecios.Controls.Add(Me.Label17)
        Me.gbPrecios.Controls.Add(Me.txtFlete)
        Me.gbPrecios.Controls.Add(Me.txtDepNuc)
        Me.gbPrecios.Controls.Add(Me.txtFleInt)
        Me.gbPrecios.Controls.Add(Me.Label7)
        Me.gbPrecios.Controls.Add(Me.Label5)
        Me.gbPrecios.Controls.Add(Me.Label11)
        Me.gbPrecios.Location = New System.Drawing.Point(9, 148)
        Me.gbPrecios.Name = "gbPrecios"
        Me.gbPrecios.Size = New System.Drawing.Size(489, 82)
        Me.gbPrecios.TabIndex = 14
        Me.gbPrecios.TabStop = False
        Me.gbPrecios.Text = "Costos"
        '
        'txtTotalDscto
        '
        Me.txtTotalDscto.Location = New System.Drawing.Point(361, 13)
        Me.txtTotalDscto.MaxLength = 12
        Me.txtTotalDscto.Name = "txtTotalDscto"
        Me.txtTotalDscto.ReadOnly = True
        Me.txtTotalDscto.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalDscto.TabIndex = 4
        Me.txtTotalDscto.Text = "0.00"
        Me.txtTotalDscto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtOtrosGastos
        '
        Me.txtOtrosGastos.Location = New System.Drawing.Point(361, 57)
        Me.txtOtrosGastos.MaxLength = 12
        Me.txtOtrosGastos.Name = "txtOtrosGastos"
        Me.txtOtrosGastos.Size = New System.Drawing.Size(100, 20)
        Me.txtOtrosGastos.TabIndex = 5
        Me.txtOtrosGastos.Text = "0.00"
        Me.txtOtrosGastos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtGesCom
        '
        Me.txtGesCom.Location = New System.Drawing.Point(133, 13)
        Me.txtGesCom.MaxLength = 12
        Me.txtGesCom.Name = "txtGesCom"
        Me.txtGesCom.Size = New System.Drawing.Size(100, 20)
        Me.txtGesCom.TabIndex = 1
        Me.txtGesCom.Text = "0.00"
        Me.txtGesCom.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGesCom.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(31, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Gestión Compra"
        Me.Label10.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(275, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Otros Gastos"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(282, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Total Dscto"
        '
        'txtFlete
        '
        Me.txtFlete.Location = New System.Drawing.Point(133, 57)
        Me.txtFlete.MaxLength = 12
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.Size = New System.Drawing.Size(100, 20)
        Me.txtFlete.TabIndex = 3
        Me.txtFlete.Text = "0.00"
        Me.txtFlete.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtFlete.Visible = False
        '
        'txtDepNuc
        '
        Me.txtDepNuc.BackColor = System.Drawing.SystemColors.Control
        Me.txtDepNuc.Location = New System.Drawing.Point(133, 35)
        Me.txtDepNuc.MaxLength = 12
        Me.txtDepNuc.Name = "txtDepNuc"
        Me.txtDepNuc.ReadOnly = True
        Me.txtDepNuc.Size = New System.Drawing.Size(100, 20)
        Me.txtDepNuc.TabIndex = 2
        Me.txtDepNuc.TabStop = False
        Me.txtDepNuc.Text = "0.00"
        Me.txtDepNuc.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDepNuc.Visible = False
        '
        'txtFleInt
        '
        Me.txtFleInt.Location = New System.Drawing.Point(361, 35)
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
        Me.Label7.Location = New System.Drawing.Point(16, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Deposito x Núcleo"
        Me.Label7.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(276, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Flete Interno"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(59, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Total Flete"
        Me.Label11.Visible = False
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(5, 15)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(698, 230)
        Me.dgvDatos.TabIndex = 19
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox1.Controls.Add(Me.txtTotal)
        Me.UiGroupBox1.Controls.Add(Me.lblTotal)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Location = New System.Drawing.Point(3, 253)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(703, 29)
        Me.UiGroupBox1.TabIndex = 21
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotal.Location = New System.Drawing.Point(580, 8)
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
        Me.lblTotal.Location = New System.Drawing.Point(13, 8)
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
        Me.ssBarra.Location = New System.Drawing.Point(0, 579)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(733, 20)
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
        Me.ToolStrip.Size = New System.Drawing.Size(733, 31)
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
        Me.gbDatosBusqueda.Controls.Add(Me.gbTotal)
        Me.gbDatosBusqueda.Controls.Add(Me.Label13)
        Me.gbDatosBusqueda.Controls.Add(Me.Label12)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbIdFiscalSold)
        Me.gbDatosBusqueda.Controls.Add(Me.Label6)
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
        Me.gbDatosBusqueda.Controls.Add(Me.cmbPrecio)
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
        Me.cmbCodPag.Location = New System.Drawing.Point(82, 124)
        Me.cmbCodPag.Name = "cmbCodPag"
        Me.cmbCodPag.SelectedIndex = -1
        Me.cmbCodPag.SelectedItem = Nothing
        Me.cmbCodPag.Size = New System.Drawing.Size(188, 20)
        Me.cmbCodPag.TabIndex = 284
        Me.cmbCodPag.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 128)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 13)
        Me.Label20.TabIndex = 285
        Me.Label20.Text = "Cond. Pago"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(461, 129)
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
        Me.txtFecLlegadaMiami.Location = New System.Drawing.Point(605, 125)
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
        Me.txtNroPqte.Location = New System.Drawing.Point(360, 124)
        Me.txtNroPqte.MaxLength = 50
        Me.txtNroPqte.Name = "txtNroPqte"
        Me.txtNroPqte.Size = New System.Drawing.Size(99, 20)
        Me.txtNroPqte.TabIndex = 274
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(272, 127)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 275
        Me.Label18.Text = "Nro. Paquete"
        '
        'gbDetalles
        '
        Me.gbDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalles.Controls.Add(Me.dgvDatos)
        Me.gbDetalles.Controls.Add(Me.UiGroupBox1)
        Me.gbDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalles.Location = New System.Drawing.Point(4, 277)
        Me.gbDetalles.Name = "gbDetalles"
        Me.gbDetalles.Size = New System.Drawing.Size(709, 285)
        Me.gbDetalles.TabIndex = 18
        Me.gbDetalles.Text = "Datos de Búsqueda"
        Me.gbDetalles.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmDocumento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(733, 599)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDetalles)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Controls.Add(Me.lblUbicacion)
        Me.Controls.Add(Me.ToolStrip)
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
        CType(Me.cmbIdFiscalShip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdFiscalSold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTotal.ResumeLayout(False)
        Me.gbTotal.PerformLayout()
        Me.gbPrecios.ResumeLayout(False)
        Me.gbPrecios.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalles.ResumeLayout(False)
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
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtShip As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarShip As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbMedio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbPrecios As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFlete As Janus.Windows.GridEX.EditControls.NumericEditBox
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
    Friend WithEvents btiBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscarProvider As System.Windows.Forms.Button
    Friend WithEvents txtProvider As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbIdFiscalSold As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbIdFiscalShip As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalDscto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtOtrosGastos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents gbDetalles As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtNroPqte As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtFecLlegadaMiami As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cmbCodPag As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label20 As Label
End Class
