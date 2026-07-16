<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadoCliente
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim dgvContactos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstadoCliente))
        Dim dgvVentas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvOcurrencias_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvOcurrencias_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column5.Image")
        Me.TbOpciones = New Janus.Windows.UI.Tab.UITab()
        Me.tbClientes = New Janus.Windows.UI.Tab.UITabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvContactos = New Janus.Windows.GridEX.GridEX()
        Me.btnSalirCli = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtDesEco = New System.Windows.Forms.TextBox()
        Me.txtCodEco = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.txtTelf = New System.Windows.Forms.TextBox()
        Me.txtDir = New System.Windows.Forms.TextBox()
        Me.txtDesCli = New System.Windows.Forms.TextBox()
        Me.txtDNI = New System.Windows.Forms.TextBox()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.txtCodCli = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.tbVentas = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnSalirVen = New System.Windows.Forms.Button()
        Me.lblVencido = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblNoVencido = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.lblDespues = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.lblEnFecha = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.lblAntes = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.dgvVentas = New Janus.Windows.GridEX.GridEX()
        Me.tbEstadisticas = New Janus.Windows.UI.Tab.UITabPage()
        Me.txtMensualFact = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblEstadisticas = New System.Windows.Forms.Label()
        Me.txtTotalesSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalesPagado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalesVentas = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPendientesVencido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPendientesNoVencido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPagadosDespués = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPagadosEnFecha = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPagadosAntes = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvGrafica = New System.Windows.Forms.DataGridView()
        Me.ChartEstadistica = New AxMSChart20Lib.AxMSChart()
        Me.gbGraficas = New System.Windows.Forms.GroupBox()
        Me.rbCircular = New System.Windows.Forms.RadioButton()
        Me.rbBloques = New System.Windows.Forms.RadioButton()
        Me.rbLineas = New System.Windows.Forms.RadioButton()
        Me.btnSalirEst = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblTotalesSaldo = New System.Windows.Forms.Label()
        Me.lblTotalesAntes = New System.Windows.Forms.Label()
        Me.lblTotalesVentas = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblPendientesEnFecha = New System.Windows.Forms.Label()
        Me.lblPendientesNoVencido = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblPagadoDespues = New System.Windows.Forms.Label()
        Me.lblPagadoEnFecha = New System.Windows.Forms.Label()
        Me.lblPagadoAntes = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbIndicadores = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvgrafica2 = New System.Windows.Forms.DataGridView()
        Me.btnSalirInd = New System.Windows.Forms.Button()
        Me.txtClienteInd = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPlazoenExceso = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPlazoAutorizado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtIndicadorDVPC = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDiasTranscurridos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtCuentasporCobrar = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtVentasAcumuladas = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbOcurrencias = New Janus.Windows.UI.Tab.UITabPage()
        Me.lblOcurrencia = New System.Windows.Forms.Label()
        Me.txtOcurrenciaDetalle = New System.Windows.Forms.TextBox()
        Me.dgvOcurrencias = New Janus.Windows.GridEX.GridEX()
        Me.btnOcurSalir = New System.Windows.Forms.Button()
        Me.btnOcurImprimir = New System.Windows.Forms.Button()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.TbOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbOpciones.SuspendLayout()
        Me.tbClientes.SuspendLayout()
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbVentas.SuspendLayout()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbEstadisticas.SuspendLayout()
        CType(Me.dgvGrafica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartEstadistica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGraficas.SuspendLayout()
        Me.tbIndicadores.SuspendLayout()
        CType(Me.dgvgrafica2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbOcurrencias.SuspendLayout()
        CType(Me.dgvOcurrencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbOpciones
        '
        Me.TbOpciones.Location = New System.Drawing.Point(12, 12)
        Me.TbOpciones.Name = "TbOpciones"
        Me.TbOpciones.Size = New System.Drawing.Size(962, 564)
        Me.TbOpciones.TabIndex = 0
        Me.TbOpciones.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tbClientes, Me.tbVentas, Me.tbEstadisticas, Me.tbIndicadores, Me.tbOcurrencias})
        Me.TbOpciones.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003
        '
        'tbClientes
        '
        Me.tbClientes.Controls.Add(Me.Label1)
        Me.tbClientes.Controls.Add(Me.dgvContactos)
        Me.tbClientes.Controls.Add(Me.btnSalirCli)
        Me.tbClientes.Controls.Add(Me.btnBuscar)
        Me.tbClientes.Controls.Add(Me.txtObservaciones)
        Me.tbClientes.Controls.Add(Me.txtDesEco)
        Me.tbClientes.Controls.Add(Me.txtCodEco)
        Me.tbClientes.Controls.Add(Me.txtFax)
        Me.tbClientes.Controls.Add(Me.txtTelf)
        Me.tbClientes.Controls.Add(Me.txtDir)
        Me.tbClientes.Controls.Add(Me.txtDesCli)
        Me.tbClientes.Controls.Add(Me.txtDNI)
        Me.tbClientes.Controls.Add(Me.txtRuc)
        Me.tbClientes.Controls.Add(Me.txtCodCli)
        Me.tbClientes.Controls.Add(Me.Label59)
        Me.tbClientes.Controls.Add(Me.Label60)
        Me.tbClientes.Controls.Add(Me.Label61)
        Me.tbClientes.Controls.Add(Me.Label64)
        Me.tbClientes.Controls.Add(Me.Label65)
        Me.tbClientes.Controls.Add(Me.Label66)
        Me.tbClientes.Controls.Add(Me.Label67)
        Me.tbClientes.Controls.Add(Me.Label68)
        Me.tbClientes.Controls.Add(Me.Label69)
        Me.tbClientes.Image = CType(resources.GetObject("tbClientes.Image"), System.Drawing.Image)
        Me.tbClientes.Location = New System.Drawing.Point(1, 23)
        Me.tbClientes.Name = "tbClientes"
        Me.tbClientes.Size = New System.Drawing.Size(960, 540)
        Me.tbClientes.TabStop = True
        Me.tbClientes.Text = "CLIENTES "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 275)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Contactos :"
        '
        'dgvContactos
        '
        Me.dgvContactos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        dgvContactos_DesignTimeLayout.LayoutString = resources.GetString("dgvContactos_DesignTimeLayout.LayoutString")
        Me.dgvContactos.DesignTimeLayout = dgvContactos_DesignTimeLayout
        Me.dgvContactos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvContactos.GroupByBoxVisible = False
        Me.dgvContactos.Location = New System.Drawing.Point(119, 261)
        Me.dgvContactos.Name = "dgvContactos"
        Me.dgvContactos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvContactos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvContactos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvContactos.Size = New System.Drawing.Size(811, 214)
        Me.dgvContactos.TabIndex = 96
        Me.dgvContactos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnSalirCli
        '
        Me.btnSalirCli.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalirCli.Location = New System.Drawing.Point(807, 480)
        Me.btnSalirCli.Name = "btnSalirCli"
        Me.btnSalirCli.Size = New System.Drawing.Size(50, 23)
        Me.btnSalirCli.TabIndex = 112
        Me.btnSalirCli.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.Location = New System.Drawing.Point(202, 32)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(42, 23)
        Me.btnBuscar.TabIndex = 111
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtObservaciones.Location = New System.Drawing.Point(119, 135)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.Size = New System.Drawing.Size(811, 104)
        Me.txtObservaciones.TabIndex = 108
        '
        'txtDesEco
        '
        Me.txtDesEco.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDesEco.Location = New System.Drawing.Point(799, 108)
        Me.txtDesEco.Name = "txtDesEco"
        Me.txtDesEco.ReadOnly = True
        Me.txtDesEco.Size = New System.Drawing.Size(131, 20)
        Me.txtDesEco.TabIndex = 107
        '
        'txtCodEco
        '
        Me.txtCodEco.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCodEco.Location = New System.Drawing.Point(757, 108)
        Me.txtCodEco.Name = "txtCodEco"
        Me.txtCodEco.ReadOnly = True
        Me.txtCodEco.Size = New System.Drawing.Size(36, 20)
        Me.txtCodEco.TabIndex = 106
        '
        'txtFax
        '
        Me.txtFax.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtFax.Location = New System.Drawing.Point(446, 108)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.ReadOnly = True
        Me.txtFax.Size = New System.Drawing.Size(171, 20)
        Me.txtFax.TabIndex = 105
        '
        'txtTelf
        '
        Me.txtTelf.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtTelf.Location = New System.Drawing.Point(119, 109)
        Me.txtTelf.Name = "txtTelf"
        Me.txtTelf.ReadOnly = True
        Me.txtTelf.Size = New System.Drawing.Size(260, 20)
        Me.txtTelf.TabIndex = 104
        '
        'txtDir
        '
        Me.txtDir.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDir.Location = New System.Drawing.Point(119, 83)
        Me.txtDir.Name = "txtDir"
        Me.txtDir.ReadOnly = True
        Me.txtDir.Size = New System.Drawing.Size(811, 20)
        Me.txtDir.TabIndex = 103
        '
        'txtDesCli
        '
        Me.txtDesCli.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDesCli.Location = New System.Drawing.Point(119, 58)
        Me.txtDesCli.Name = "txtDesCli"
        Me.txtDesCli.ReadOnly = True
        Me.txtDesCli.Size = New System.Drawing.Size(811, 20)
        Me.txtDesCli.TabIndex = 102
        '
        'txtDNI
        '
        Me.txtDNI.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtDNI.Location = New System.Drawing.Point(799, 33)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.ReadOnly = True
        Me.txtDNI.Size = New System.Drawing.Size(131, 20)
        Me.txtDNI.TabIndex = 101
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtRuc.Location = New System.Drawing.Point(446, 33)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.ReadOnly = True
        Me.txtRuc.Size = New System.Drawing.Size(171, 20)
        Me.txtRuc.TabIndex = 100
        '
        'txtCodCli
        '
        Me.txtCodCli.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCodCli.Location = New System.Drawing.Point(119, 33)
        Me.txtCodCli.Name = "txtCodCli"
        Me.txtCodCli.ReadOnly = True
        Me.txtCodCli.Size = New System.Drawing.Size(81, 20)
        Me.txtCodCli.TabIndex = 99
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(14, 142)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(99, 13)
        Me.Label59.TabIndex = 96
        Me.Label59.Text = "Observaciones :"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(685, 112)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(67, 13)
        Me.Label60.TabIndex = 95
        Me.Label60.Text = "Sec. Eco :"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(410, 112)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(35, 13)
        Me.Label61.TabIndex = 94
        Me.Label61.Text = "Fax :"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(48, 113)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(65, 13)
        Me.Label64.TabIndex = 93
        Me.Label64.Text = "Teléfono :"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(44, 87)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(69, 13)
        Me.Label65.TabIndex = 92
        Me.Label65.Text = "Dirección :"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(31, 63)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(82, 13)
        Me.Label66.TabIndex = 91
        Me.Label66.Text = "Descripción :"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(746, 37)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(49, 13)
        Me.Label67.TabIndex = 90
        Me.Label67.Text = "D.N.I. :"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(392, 37)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(53, 13)
        Me.Label68.TabIndex = 89
        Me.Label68.Text = "R.U.C. :"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(59, 37)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(54, 13)
        Me.Label69.TabIndex = 88
        Me.Label69.Text = "Código :"
        '
        'tbVentas
        '
        Me.tbVentas.Controls.Add(Me.btnSalirVen)
        Me.tbVentas.Controls.Add(Me.lblVencido)
        Me.tbVentas.Controls.Add(Me.TextBox1)
        Me.tbVentas.Controls.Add(Me.lblNoVencido)
        Me.tbVentas.Controls.Add(Me.TextBox2)
        Me.tbVentas.Controls.Add(Me.lblDespues)
        Me.tbVentas.Controls.Add(Me.TextBox3)
        Me.tbVentas.Controls.Add(Me.lblEnFecha)
        Me.tbVentas.Controls.Add(Me.TextBox4)
        Me.tbVentas.Controls.Add(Me.lblAntes)
        Me.tbVentas.Controls.Add(Me.TextBox5)
        Me.tbVentas.Controls.Add(Me.Label55)
        Me.tbVentas.Controls.Add(Me.Label56)
        Me.tbVentas.Controls.Add(Me.dgvVentas)
        Me.tbVentas.Image = CType(resources.GetObject("tbVentas.Image"), System.Drawing.Image)
        Me.tbVentas.Location = New System.Drawing.Point(1, 23)
        Me.tbVentas.Name = "tbVentas"
        Me.tbVentas.Size = New System.Drawing.Size(960, 540)
        Me.tbVentas.TabStop = True
        Me.tbVentas.Text = "[ F2 ] - VENTAS US $  "
        '
        'btnSalirVen
        '
        Me.btnSalirVen.Image = CType(resources.GetObject("btnSalirVen.Image"), System.Drawing.Image)
        Me.btnSalirVen.Location = New System.Drawing.Point(913, 474)
        Me.btnSalirVen.Name = "btnSalirVen"
        Me.btnSalirVen.Size = New System.Drawing.Size(31, 27)
        Me.btnSalirVen.TabIndex = 175
        Me.btnSalirVen.UseVisualStyleBackColor = True
        '
        'lblVencido
        '
        Me.lblVencido.AutoSize = True
        Me.lblVencido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVencido.Location = New System.Drawing.Point(662, 484)
        Me.lblVencido.Name = "lblVencido"
        Me.lblVencido.Size = New System.Drawing.Size(19, 13)
        Me.lblVencido.TabIndex = 174
        Me.lblVencido.Text = "..."
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Red
        Me.TextBox1.Location = New System.Drawing.Point(637, 481)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(19, 20)
        Me.TextBox1.TabIndex = 173
        '
        'lblNoVencido
        '
        Me.lblNoVencido.AutoSize = True
        Me.lblNoVencido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoVencido.Location = New System.Drawing.Point(518, 484)
        Me.lblNoVencido.Name = "lblNoVencido"
        Me.lblNoVencido.Size = New System.Drawing.Size(19, 13)
        Me.lblNoVencido.TabIndex = 172
        Me.lblNoVencido.Text = "..."
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.DarkOrange
        Me.TextBox2.Location = New System.Drawing.Point(493, 481)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(19, 20)
        Me.TextBox2.TabIndex = 171
        '
        'lblDespues
        '
        Me.lblDespues.AutoSize = True
        Me.lblDespues.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDespues.Location = New System.Drawing.Point(329, 484)
        Me.lblDespues.Name = "lblDespues"
        Me.lblDespues.Size = New System.Drawing.Size(19, 13)
        Me.lblDespues.TabIndex = 170
        Me.lblDespues.Text = "..."
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Yellow
        Me.TextBox3.Location = New System.Drawing.Point(304, 481)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(19, 20)
        Me.TextBox3.TabIndex = 169
        '
        'lblEnFecha
        '
        Me.lblEnFecha.AutoSize = True
        Me.lblEnFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnFecha.Location = New System.Drawing.Point(192, 484)
        Me.lblEnFecha.Name = "lblEnFecha"
        Me.lblEnFecha.Size = New System.Drawing.Size(19, 13)
        Me.lblEnFecha.TabIndex = 168
        Me.lblEnFecha.Text = "..."
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.PaleGreen
        Me.TextBox4.Location = New System.Drawing.Point(167, 481)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(19, 20)
        Me.TextBox4.TabIndex = 167
        '
        'lblAntes
        '
        Me.lblAntes.AutoSize = True
        Me.lblAntes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAntes.Location = New System.Drawing.Point(60, 484)
        Me.lblAntes.Name = "lblAntes"
        Me.lblAntes.Size = New System.Drawing.Size(19, 13)
        Me.lblAntes.TabIndex = 166
        Me.lblAntes.Text = "..."
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.ForestGreen
        Me.TextBox5.Location = New System.Drawing.Point(35, 481)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(19, 20)
        Me.TextBox5.TabIndex = 165
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(492, 459)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(84, 13)
        Me.Label55.TabIndex = 164
        Me.Label55.Text = "No Pagados :"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(33, 460)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(64, 13)
        Me.Label56.TabIndex = 163
        Me.Label56.Text = "Pagados :"
        '
        'dgvVentas
        '
        Me.dgvVentas.AllowCardSizing = False
        Me.dgvVentas.AllowColumnDrag = False
        Me.dgvVentas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvVentas.AlternatingColors = True
        Me.dgvVentas.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        dgvVentas_DesignTimeLayout.LayoutString = resources.GetString("dgvVentas_DesignTimeLayout.LayoutString")
        Me.dgvVentas.DesignTimeLayout = dgvVentas_DesignTimeLayout
        Me.dgvVentas.EmptyRows = True
        Me.dgvVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvVentas.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvVentas.GroupByBoxVisible = False
        Me.dgvVentas.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgvVentas.Location = New System.Drawing.Point(19, 16)
        Me.dgvVentas.Name = "dgvVentas"
        Me.dgvVentas.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvVentas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvVentas.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvVentas.SelectOnExpand = False
        Me.dgvVentas.Size = New System.Drawing.Size(923, 427)
        Me.dgvVentas.TabIndex = 162
        Me.dgvVentas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tbEstadisticas
        '
        Me.tbEstadisticas.Controls.Add(Me.txtMensualFact)
        Me.tbEstadisticas.Controls.Add(Me.Label3)
        Me.tbEstadisticas.Controls.Add(Me.lblEstadisticas)
        Me.tbEstadisticas.Controls.Add(Me.txtTotalesSaldo)
        Me.tbEstadisticas.Controls.Add(Me.txtTotalesPagado)
        Me.tbEstadisticas.Controls.Add(Me.txtTotalesVentas)
        Me.tbEstadisticas.Controls.Add(Me.txtPendientesVencido)
        Me.tbEstadisticas.Controls.Add(Me.txtPendientesNoVencido)
        Me.tbEstadisticas.Controls.Add(Me.txtPagadosDespués)
        Me.tbEstadisticas.Controls.Add(Me.txtPagadosEnFecha)
        Me.tbEstadisticas.Controls.Add(Me.txtPagadosAntes)
        Me.tbEstadisticas.Controls.Add(Me.dgvGrafica)
        Me.tbEstadisticas.Controls.Add(Me.ChartEstadistica)
        Me.tbEstadisticas.Controls.Add(Me.gbGraficas)
        Me.tbEstadisticas.Controls.Add(Me.btnSalirEst)
        Me.tbEstadisticas.Controls.Add(Me.btnImprimir)
        Me.tbEstadisticas.Controls.Add(Me.lblTotalesSaldo)
        Me.tbEstadisticas.Controls.Add(Me.lblTotalesAntes)
        Me.tbEstadisticas.Controls.Add(Me.lblTotalesVentas)
        Me.tbEstadisticas.Controls.Add(Me.Label24)
        Me.tbEstadisticas.Controls.Add(Me.lblPendientesEnFecha)
        Me.tbEstadisticas.Controls.Add(Me.lblPendientesNoVencido)
        Me.tbEstadisticas.Controls.Add(Me.Label23)
        Me.tbEstadisticas.Controls.Add(Me.lblPagadoDespues)
        Me.tbEstadisticas.Controls.Add(Me.lblPagadoEnFecha)
        Me.tbEstadisticas.Controls.Add(Me.lblPagadoAntes)
        Me.tbEstadisticas.Controls.Add(Me.Label22)
        Me.tbEstadisticas.Controls.Add(Me.txtCliente)
        Me.tbEstadisticas.Controls.Add(Me.Label21)
        Me.tbEstadisticas.Image = CType(resources.GetObject("tbEstadisticas.Image"), System.Drawing.Image)
        Me.tbEstadisticas.Location = New System.Drawing.Point(1, 23)
        Me.tbEstadisticas.Name = "tbEstadisticas"
        Me.tbEstadisticas.Size = New System.Drawing.Size(960, 540)
        Me.tbEstadisticas.TabStop = True
        Me.tbEstadisticas.Text = "[ F3 ] - ESTADISTICAS US $  "
        '
        'txtMensualFact
        '
        Me.txtMensualFact.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMensualFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensualFact.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMensualFact.Location = New System.Drawing.Point(839, 139)
        Me.txtMensualFact.MaxLength = 5
        Me.txtMensualFact.Name = "txtMensualFact"
        Me.txtMensualFact.ReadOnly = True
        Me.txtMensualFact.Size = New System.Drawing.Size(98, 20)
        Me.txtMensualFact.TabIndex = 111
        Me.txtMensualFact.TabStop = False
        Me.txtMensualFact.Text = "0.00"
        Me.txtMensualFact.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMensualFact.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMensualFact.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(733, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 13)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "Total Mensual Facturado"
        '
        'lblEstadisticas
        '
        Me.lblEstadisticas.AutoSize = True
        Me.lblEstadisticas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadisticas.ForeColor = System.Drawing.Color.Black
        Me.lblEstadisticas.Location = New System.Drawing.Point(22, 509)
        Me.lblEstadisticas.Name = "lblEstadisticas"
        Me.lblEstadisticas.Size = New System.Drawing.Size(566, 13)
        Me.lblEstadisticas.TabIndex = 109
        Me.lblEstadisticas.Text = "La Información pertenece al Historial Crediticio del Cliente desde Octubre del 20" & _
    "10 hasta la fecha."
        '
        'txtTotalesSaldo
        '
        Me.txtTotalesSaldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalesSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalesSaldo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalesSaldo.Location = New System.Drawing.Point(839, 437)
        Me.txtTotalesSaldo.MaxLength = 5
        Me.txtTotalesSaldo.Name = "txtTotalesSaldo"
        Me.txtTotalesSaldo.ReadOnly = True
        Me.txtTotalesSaldo.Size = New System.Drawing.Size(98, 20)
        Me.txtTotalesSaldo.TabIndex = 108
        Me.txtTotalesSaldo.TabStop = False
        Me.txtTotalesSaldo.Text = "0.00"
        Me.txtTotalesSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalesSaldo.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalesSaldo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalesPagado
        '
        Me.txtTotalesPagado.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalesPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalesPagado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalesPagado.Location = New System.Drawing.Point(839, 409)
        Me.txtTotalesPagado.MaxLength = 5
        Me.txtTotalesPagado.Name = "txtTotalesPagado"
        Me.txtTotalesPagado.ReadOnly = True
        Me.txtTotalesPagado.Size = New System.Drawing.Size(98, 20)
        Me.txtTotalesPagado.TabIndex = 107
        Me.txtTotalesPagado.TabStop = False
        Me.txtTotalesPagado.Text = "0.00"
        Me.txtTotalesPagado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalesPagado.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalesPagado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalesVentas
        '
        Me.txtTotalesVentas.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalesVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalesVentas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalesVentas.Location = New System.Drawing.Point(839, 382)
        Me.txtTotalesVentas.MaxLength = 5
        Me.txtTotalesVentas.Name = "txtTotalesVentas"
        Me.txtTotalesVentas.ReadOnly = True
        Me.txtTotalesVentas.Size = New System.Drawing.Size(98, 20)
        Me.txtTotalesVentas.TabIndex = 106
        Me.txtTotalesVentas.TabStop = False
        Me.txtTotalesVentas.Text = "0.00"
        Me.txtTotalesVentas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalesVentas.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalesVentas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPendientesVencido
        '
        Me.txtPendientesVencido.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtPendientesVencido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendientesVencido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPendientesVencido.Location = New System.Drawing.Point(839, 326)
        Me.txtPendientesVencido.MaxLength = 5
        Me.txtPendientesVencido.Name = "txtPendientesVencido"
        Me.txtPendientesVencido.ReadOnly = True
        Me.txtPendientesVencido.Size = New System.Drawing.Size(98, 20)
        Me.txtPendientesVencido.TabIndex = 105
        Me.txtPendientesVencido.TabStop = False
        Me.txtPendientesVencido.Text = "0.00"
        Me.txtPendientesVencido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPendientesVencido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPendientesVencido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPendientesNoVencido
        '
        Me.txtPendientesNoVencido.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtPendientesNoVencido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendientesNoVencido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPendientesNoVencido.Location = New System.Drawing.Point(839, 300)
        Me.txtPendientesNoVencido.MaxLength = 5
        Me.txtPendientesNoVencido.Name = "txtPendientesNoVencido"
        Me.txtPendientesNoVencido.ReadOnly = True
        Me.txtPendientesNoVencido.Size = New System.Drawing.Size(98, 20)
        Me.txtPendientesNoVencido.TabIndex = 104
        Me.txtPendientesNoVencido.TabStop = False
        Me.txtPendientesNoVencido.Text = "0.00"
        Me.txtPendientesNoVencido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPendientesNoVencido.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPendientesNoVencido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPagadosDespués
        '
        Me.txtPagadosDespués.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtPagadosDespués.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagadosDespués.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPagadosDespués.Location = New System.Drawing.Point(839, 243)
        Me.txtPagadosDespués.MaxLength = 5
        Me.txtPagadosDespués.Name = "txtPagadosDespués"
        Me.txtPagadosDespués.ReadOnly = True
        Me.txtPagadosDespués.Size = New System.Drawing.Size(98, 20)
        Me.txtPagadosDespués.TabIndex = 103
        Me.txtPagadosDespués.TabStop = False
        Me.txtPagadosDespués.Text = "0.00"
        Me.txtPagadosDespués.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPagadosDespués.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPagadosDespués.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPagadosEnFecha
        '
        Me.txtPagadosEnFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtPagadosEnFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagadosEnFecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPagadosEnFecha.Location = New System.Drawing.Point(839, 216)
        Me.txtPagadosEnFecha.MaxLength = 5
        Me.txtPagadosEnFecha.Name = "txtPagadosEnFecha"
        Me.txtPagadosEnFecha.ReadOnly = True
        Me.txtPagadosEnFecha.Size = New System.Drawing.Size(98, 20)
        Me.txtPagadosEnFecha.TabIndex = 102
        Me.txtPagadosEnFecha.TabStop = False
        Me.txtPagadosEnFecha.Text = "0.00"
        Me.txtPagadosEnFecha.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPagadosEnFecha.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPagadosEnFecha.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPagadosAntes
        '
        Me.txtPagadosAntes.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtPagadosAntes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagadosAntes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPagadosAntes.Location = New System.Drawing.Point(839, 189)
        Me.txtPagadosAntes.MaxLength = 5
        Me.txtPagadosAntes.Name = "txtPagadosAntes"
        Me.txtPagadosAntes.ReadOnly = True
        Me.txtPagadosAntes.Size = New System.Drawing.Size(98, 20)
        Me.txtPagadosAntes.TabIndex = 101
        Me.txtPagadosAntes.TabStop = False
        Me.txtPagadosAntes.Text = "0.00"
        Me.txtPagadosAntes.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPagadosAntes.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPagadosAntes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvGrafica
        '
        Me.dgvGrafica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGrafica.Location = New System.Drawing.Point(736, 474)
        Me.dgvGrafica.Name = "dgvGrafica"
        Me.dgvGrafica.Size = New System.Drawing.Size(35, 25)
        Me.dgvGrafica.TabIndex = 100
        Me.dgvGrafica.Visible = False
        '
        'ChartEstadistica
        '
        Me.ChartEstadistica.DataSource = Nothing
        Me.ChartEstadistica.Location = New System.Drawing.Point(20, 74)
        Me.ChartEstadistica.Name = "ChartEstadistica"
        Me.ChartEstadistica.OcxState = CType(resources.GetObject("ChartEstadistica.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ChartEstadistica.Size = New System.Drawing.Size(688, 421)
        Me.ChartEstadistica.TabIndex = 99
        Me.ChartEstadistica.Visible = False
        '
        'gbGraficas
        '
        Me.gbGraficas.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gbGraficas.Controls.Add(Me.rbCircular)
        Me.gbGraficas.Controls.Add(Me.rbBloques)
        Me.gbGraficas.Controls.Add(Me.rbLineas)
        Me.gbGraficas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGraficas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbGraficas.Location = New System.Drawing.Point(777, 12)
        Me.gbGraficas.Name = "gbGraficas"
        Me.gbGraficas.Size = New System.Drawing.Size(118, 95)
        Me.gbGraficas.TabIndex = 98
        Me.gbGraficas.TabStop = False
        Me.gbGraficas.Text = "Graficas"
        '
        'rbCircular
        '
        Me.rbCircular.AutoSize = True
        Me.rbCircular.Location = New System.Drawing.Point(29, 67)
        Me.rbCircular.Name = "rbCircular"
        Me.rbCircular.Size = New System.Drawing.Size(51, 17)
        Me.rbCircular.TabIndex = 2
        Me.rbCircular.TabStop = True
        Me.rbCircular.Text = "Area"
        Me.rbCircular.UseVisualStyleBackColor = True
        '
        'rbBloques
        '
        Me.rbBloques.AutoSize = True
        Me.rbBloques.Location = New System.Drawing.Point(30, 20)
        Me.rbBloques.Name = "rbBloques"
        Me.rbBloques.Size = New System.Drawing.Size(70, 17)
        Me.rbBloques.TabIndex = 1
        Me.rbBloques.TabStop = True
        Me.rbBloques.Text = "Bloques"
        Me.rbBloques.UseVisualStyleBackColor = True
        '
        'rbLineas
        '
        Me.rbLineas.AutoSize = True
        Me.rbLineas.Location = New System.Drawing.Point(30, 44)
        Me.rbLineas.Name = "rbLineas"
        Me.rbLineas.Size = New System.Drawing.Size(62, 17)
        Me.rbLineas.TabIndex = 0
        Me.rbLineas.TabStop = True
        Me.rbLineas.Text = "Lineas"
        Me.rbLineas.UseVisualStyleBackColor = True
        '
        'btnSalirEst
        '
        Me.btnSalirEst.Image = CType(resources.GetObject("btnSalirEst.Image"), System.Drawing.Image)
        Me.btnSalirEst.Location = New System.Drawing.Point(897, 476)
        Me.btnSalirEst.Name = "btnSalirEst"
        Me.btnSalirEst.Size = New System.Drawing.Size(40, 23)
        Me.btnSalirEst.TabIndex = 92
        Me.btnSalirEst.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora1
        Me.btnImprimir.Location = New System.Drawing.Point(833, 476)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(50, 23)
        Me.btnImprimir.TabIndex = 91
        Me.btnImprimir.UseVisualStyleBackColor = True
        Me.btnImprimir.Visible = False
        '
        'lblTotalesSaldo
        '
        Me.lblTotalesSaldo.AutoSize = True
        Me.lblTotalesSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalesSaldo.Location = New System.Drawing.Point(733, 440)
        Me.lblTotalesSaldo.Name = "lblTotalesSaldo"
        Me.lblTotalesSaldo.Size = New System.Drawing.Size(39, 13)
        Me.lblTotalesSaldo.TabIndex = 82
        Me.lblTotalesSaldo.Text = "Saldo"
        '
        'lblTotalesAntes
        '
        Me.lblTotalesAntes.AutoSize = True
        Me.lblTotalesAntes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalesAntes.Location = New System.Drawing.Point(733, 413)
        Me.lblTotalesAntes.Name = "lblTotalesAntes"
        Me.lblTotalesAntes.Size = New System.Drawing.Size(50, 13)
        Me.lblTotalesAntes.TabIndex = 81
        Me.lblTotalesAntes.Text = "Pagado"
        '
        'lblTotalesVentas
        '
        Me.lblTotalesVentas.AutoSize = True
        Me.lblTotalesVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalesVentas.Location = New System.Drawing.Point(733, 386)
        Me.lblTotalesVentas.Name = "lblTotalesVentas"
        Me.lblTotalesVentas.Size = New System.Drawing.Size(64, 13)
        Me.lblTotalesVentas.TabIndex = 80
        Me.lblTotalesVentas.Text = "Facturado"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(789, 360)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(95, 13)
        Me.Label24.TabIndex = 79
        Me.Label24.Text = "TOTALES US $"
        '
        'lblPendientesEnFecha
        '
        Me.lblPendientesEnFecha.AutoSize = True
        Me.lblPendientesEnFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendientesEnFecha.Location = New System.Drawing.Point(733, 330)
        Me.lblPendientesEnFecha.Name = "lblPendientesEnFecha"
        Me.lblPendientesEnFecha.Size = New System.Drawing.Size(53, 13)
        Me.lblPendientesEnFecha.TabIndex = 78
        Me.lblPendientesEnFecha.Text = "Vencido"
        '
        'lblPendientesNoVencido
        '
        Me.lblPendientesNoVencido.AutoSize = True
        Me.lblPendientesNoVencido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendientesNoVencido.Location = New System.Drawing.Point(733, 304)
        Me.lblPendientesNoVencido.Name = "lblPendientesNoVencido"
        Me.lblPendientesNoVencido.Size = New System.Drawing.Size(69, 13)
        Me.lblPendientesNoVencido.TabIndex = 77
        Me.lblPendientesNoVencido.Text = "NoVencido"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(789, 277)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(118, 13)
        Me.Label23.TabIndex = 76
        Me.Label23.Text = "PENDIENTES US $"
        '
        'lblPagadoDespues
        '
        Me.lblPagadoDespues.AutoSize = True
        Me.lblPagadoDespues.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagadoDespues.Location = New System.Drawing.Point(733, 249)
        Me.lblPagadoDespues.Name = "lblPagadoDespues"
        Me.lblPagadoDespues.Size = New System.Drawing.Size(56, 13)
        Me.lblPagadoDespues.TabIndex = 75
        Me.lblPagadoDespues.Text = "Después"
        '
        'lblPagadoEnFecha
        '
        Me.lblPagadoEnFecha.AutoSize = True
        Me.lblPagadoEnFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagadoEnFecha.Location = New System.Drawing.Point(733, 221)
        Me.lblPagadoEnFecha.Name = "lblPagadoEnFecha"
        Me.lblPagadoEnFecha.Size = New System.Drawing.Size(61, 13)
        Me.lblPagadoEnFecha.TabIndex = 74
        Me.lblPagadoEnFecha.Text = "En Fecha"
        '
        'lblPagadoAntes
        '
        Me.lblPagadoAntes.AutoSize = True
        Me.lblPagadoAntes.BackColor = System.Drawing.SystemColors.Control
        Me.lblPagadoAntes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagadoAntes.Location = New System.Drawing.Point(733, 193)
        Me.lblPagadoAntes.Name = "lblPagadoAntes"
        Me.lblPagadoAntes.Size = New System.Drawing.Size(39, 13)
        Me.lblPagadoAntes.TabIndex = 73
        Me.lblPagadoAntes.Text = "Antes"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(789, 170)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 13)
        Me.Label22.TabIndex = 72
        Me.Label22.Text = "PAGADOS US $"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtCliente.Location = New System.Drawing.Point(92, 27)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(578, 20)
        Me.txtCliente.TabIndex = 71
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(26, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 13)
        Me.Label21.TabIndex = 70
        Me.Label21.Text = "Cliente :"
        '
        'tbIndicadores
        '
        Me.tbIndicadores.Controls.Add(Me.dgvgrafica2)
        Me.tbIndicadores.Controls.Add(Me.btnSalirInd)
        Me.tbIndicadores.Controls.Add(Me.txtClienteInd)
        Me.tbIndicadores.Controls.Add(Me.Label10)
        Me.tbIndicadores.Controls.Add(Me.txtPlazoenExceso)
        Me.tbIndicadores.Controls.Add(Me.txtPlazoAutorizado)
        Me.tbIndicadores.Controls.Add(Me.txtIndicadorDVPC)
        Me.tbIndicadores.Controls.Add(Me.txtDiasTranscurridos)
        Me.tbIndicadores.Controls.Add(Me.txtCuentasporCobrar)
        Me.tbIndicadores.Controls.Add(Me.txtVentasAcumuladas)
        Me.tbIndicadores.Controls.Add(Me.Label9)
        Me.tbIndicadores.Controls.Add(Me.Label8)
        Me.tbIndicadores.Controls.Add(Me.Label7)
        Me.tbIndicadores.Controls.Add(Me.Label6)
        Me.tbIndicadores.Controls.Add(Me.Label5)
        Me.tbIndicadores.Controls.Add(Me.Label4)
        Me.tbIndicadores.Image = CType(resources.GetObject("tbIndicadores.Image"), System.Drawing.Image)
        Me.tbIndicadores.Location = New System.Drawing.Point(1, 23)
        Me.tbIndicadores.Name = "tbIndicadores"
        Me.tbIndicadores.Size = New System.Drawing.Size(960, 540)
        Me.tbIndicadores.TabStop = True
        Me.tbIndicadores.Text = "INDICADORES"
        '
        'dgvgrafica2
        '
        Me.dgvgrafica2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvgrafica2.Location = New System.Drawing.Point(697, 13)
        Me.dgvgrafica2.Name = "dgvgrafica2"
        Me.dgvgrafica2.Size = New System.Drawing.Size(36, 42)
        Me.dgvgrafica2.TabIndex = 116
        Me.dgvgrafica2.Visible = False
        '
        'btnSalirInd
        '
        Me.btnSalirInd.Image = CType(resources.GetObject("btnSalirInd.Image"), System.Drawing.Image)
        Me.btnSalirInd.Location = New System.Drawing.Point(869, 483)
        Me.btnSalirInd.Name = "btnSalirInd"
        Me.btnSalirInd.Size = New System.Drawing.Size(50, 23)
        Me.btnSalirInd.TabIndex = 115
        Me.btnSalirInd.UseVisualStyleBackColor = True
        '
        'txtClienteInd
        '
        Me.txtClienteInd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtClienteInd.Location = New System.Drawing.Point(113, 34)
        Me.txtClienteInd.Name = "txtClienteInd"
        Me.txtClienteInd.ReadOnly = True
        Me.txtClienteInd.Size = New System.Drawing.Size(578, 20)
        Me.txtClienteInd.TabIndex = 114
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(47, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Cliente :"
        '
        'txtPlazoenExceso
        '
        Me.txtPlazoenExceso.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtPlazoenExceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlazoenExceso.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPlazoenExceso.Location = New System.Drawing.Point(239, 250)
        Me.txtPlazoenExceso.MaxLength = 5
        Me.txtPlazoenExceso.Name = "txtPlazoenExceso"
        Me.txtPlazoenExceso.ReadOnly = True
        Me.txtPlazoenExceso.Size = New System.Drawing.Size(98, 20)
        Me.txtPlazoenExceso.TabIndex = 112
        Me.txtPlazoenExceso.TabStop = False
        Me.txtPlazoenExceso.Text = "0"
        Me.txtPlazoenExceso.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPlazoenExceso.Value = CType(0, Long)
        Me.txtPlazoenExceso.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtPlazoenExceso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPlazoAutorizado
        '
        Me.txtPlazoAutorizado.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtPlazoAutorizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlazoAutorizado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPlazoAutorizado.Location = New System.Drawing.Point(239, 217)
        Me.txtPlazoAutorizado.MaxLength = 5
        Me.txtPlazoAutorizado.Name = "txtPlazoAutorizado"
        Me.txtPlazoAutorizado.Size = New System.Drawing.Size(98, 20)
        Me.txtPlazoAutorizado.TabIndex = 111
        Me.txtPlazoAutorizado.TabStop = False
        Me.txtPlazoAutorizado.Text = "0"
        Me.txtPlazoAutorizado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPlazoAutorizado.Value = CType(0, Long)
        Me.txtPlazoAutorizado.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtPlazoAutorizado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIndicadorDVPC
        '
        Me.txtIndicadorDVPC.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtIndicadorDVPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicadorDVPC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIndicadorDVPC.Location = New System.Drawing.Point(239, 184)
        Me.txtIndicadorDVPC.MaxLength = 5
        Me.txtIndicadorDVPC.Name = "txtIndicadorDVPC"
        Me.txtIndicadorDVPC.ReadOnly = True
        Me.txtIndicadorDVPC.Size = New System.Drawing.Size(98, 20)
        Me.txtIndicadorDVPC.TabIndex = 110
        Me.txtIndicadorDVPC.TabStop = False
        Me.txtIndicadorDVPC.Text = "0"
        Me.txtIndicadorDVPC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtIndicadorDVPC.Value = CType(0, Long)
        Me.txtIndicadorDVPC.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtIndicadorDVPC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDiasTranscurridos
        '
        Me.txtDiasTranscurridos.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtDiasTranscurridos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasTranscurridos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDiasTranscurridos.Location = New System.Drawing.Point(239, 149)
        Me.txtDiasTranscurridos.MaxLength = 5
        Me.txtDiasTranscurridos.Name = "txtDiasTranscurridos"
        Me.txtDiasTranscurridos.ReadOnly = True
        Me.txtDiasTranscurridos.Size = New System.Drawing.Size(98, 20)
        Me.txtDiasTranscurridos.TabIndex = 109
        Me.txtDiasTranscurridos.TabStop = False
        Me.txtDiasTranscurridos.Text = "0"
        Me.txtDiasTranscurridos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDiasTranscurridos.Value = CType(0, Long)
        Me.txtDiasTranscurridos.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtDiasTranscurridos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCuentasporCobrar
        '
        Me.txtCuentasporCobrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtCuentasporCobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentasporCobrar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCuentasporCobrar.Location = New System.Drawing.Point(239, 115)
        Me.txtCuentasporCobrar.MaxLength = 5
        Me.txtCuentasporCobrar.Name = "txtCuentasporCobrar"
        Me.txtCuentasporCobrar.ReadOnly = True
        Me.txtCuentasporCobrar.Size = New System.Drawing.Size(98, 20)
        Me.txtCuentasporCobrar.TabIndex = 108
        Me.txtCuentasporCobrar.TabStop = False
        Me.txtCuentasporCobrar.Text = "0.00"
        Me.txtCuentasporCobrar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCuentasporCobrar.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCuentasporCobrar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtVentasAcumuladas
        '
        Me.txtVentasAcumuladas.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtVentasAcumuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentasAcumuladas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtVentasAcumuladas.Location = New System.Drawing.Point(239, 82)
        Me.txtVentasAcumuladas.MaxLength = 5
        Me.txtVentasAcumuladas.Name = "txtVentasAcumuladas"
        Me.txtVentasAcumuladas.ReadOnly = True
        Me.txtVentasAcumuladas.Size = New System.Drawing.Size(98, 20)
        Me.txtVentasAcumuladas.TabIndex = 107
        Me.txtVentasAcumuladas.TabStop = False
        Me.txtVentasAcumuladas.Text = "0.00"
        Me.txtVentasAcumuladas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtVentasAcumuladas.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVentasAcumuladas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(46, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Plazo en exceso :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(47, 221)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Plazo Autorizado (días) :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(47, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(142, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Indicador DVPC (días) :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(47, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Días Transcurridos :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Cuentas por Cobrar :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(47, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ventas Acumuladas (con IGV) :"
        '
        'tbOcurrencias
        '
        Me.tbOcurrencias.Controls.Add(Me.lblOcurrencia)
        Me.tbOcurrencias.Controls.Add(Me.txtOcurrenciaDetalle)
        Me.tbOcurrencias.Controls.Add(Me.dgvOcurrencias)
        Me.tbOcurrencias.Controls.Add(Me.btnOcurSalir)
        Me.tbOcurrencias.Controls.Add(Me.btnOcurImprimir)
        Me.tbOcurrencias.Image = CType(resources.GetObject("tbOcurrencias.Image"), System.Drawing.Image)
        Me.tbOcurrencias.Location = New System.Drawing.Point(1, 23)
        Me.tbOcurrencias.Name = "tbOcurrencias"
        Me.tbOcurrencias.Size = New System.Drawing.Size(960, 540)
        Me.tbOcurrencias.TabStop = True
        Me.tbOcurrencias.Text = "OCURRENCIAS "
        '
        'lblOcurrencia
        '
        Me.lblOcurrencia.AutoSize = True
        Me.lblOcurrencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOcurrencia.Location = New System.Drawing.Point(20, 267)
        Me.lblOcurrencia.Name = "lblOcurrencia"
        Me.lblOcurrencia.Size = New System.Drawing.Size(88, 13)
        Me.lblOcurrencia.TabIndex = 97
        Me.lblOcurrencia.Text = "OCURRENCIA"
        '
        'txtOcurrenciaDetalle
        '
        Me.txtOcurrenciaDetalle.Location = New System.Drawing.Point(23, 296)
        Me.txtOcurrenciaDetalle.Multiline = True
        Me.txtOcurrenciaDetalle.Name = "txtOcurrenciaDetalle"
        Me.txtOcurrenciaDetalle.Size = New System.Drawing.Size(914, 145)
        Me.txtOcurrenciaDetalle.TabIndex = 96
        '
        'dgvOcurrencias
        '
        Me.dgvOcurrencias.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        dgvOcurrencias_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvOcurrencias_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvOcurrencias_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvOcurrencias_DesignTimeLayout_Reference_0})
        dgvOcurrencias_DesignTimeLayout.LayoutString = resources.GetString("dgvOcurrencias_DesignTimeLayout.LayoutString")
        Me.dgvOcurrencias.DesignTimeLayout = dgvOcurrencias_DesignTimeLayout
        Me.dgvOcurrencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvOcurrencias.GroupByBoxVisible = False
        Me.dgvOcurrencias.Location = New System.Drawing.Point(22, 33)
        Me.dgvOcurrencias.Name = "dgvOcurrencias"
        Me.dgvOcurrencias.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvOcurrencias.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvOcurrencias.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvOcurrencias.Size = New System.Drawing.Size(915, 219)
        Me.dgvOcurrencias.TabIndex = 95
        Me.dgvOcurrencias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnOcurSalir
        '
        Me.btnOcurSalir.Image = CType(resources.GetObject("btnOcurSalir.Image"), System.Drawing.Image)
        Me.btnOcurSalir.Location = New System.Drawing.Point(887, 463)
        Me.btnOcurSalir.Name = "btnOcurSalir"
        Me.btnOcurSalir.Size = New System.Drawing.Size(50, 23)
        Me.btnOcurSalir.TabIndex = 94
        Me.btnOcurSalir.UseVisualStyleBackColor = True
        '
        'btnOcurImprimir
        '
        Me.btnOcurImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora1
        Me.btnOcurImprimir.Location = New System.Drawing.Point(817, 463)
        Me.btnOcurImprimir.Name = "btnOcurImprimir"
        Me.btnOcurImprimir.Size = New System.Drawing.Size(50, 23)
        Me.btnOcurImprimir.TabIndex = 93
        Me.btnOcurImprimir.UseVisualStyleBackColor = True
        Me.btnOcurImprimir.Visible = False
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmEstadoCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(986, 584)
        Me.Controls.Add(Me.TbOpciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEstadoCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Cliente"
        CType(Me.TbOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbOpciones.ResumeLayout(False)
        Me.tbClientes.ResumeLayout(False)
        Me.tbClientes.PerformLayout()
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbVentas.ResumeLayout(False)
        Me.tbVentas.PerformLayout()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbEstadisticas.ResumeLayout(False)
        Me.tbEstadisticas.PerformLayout()
        CType(Me.dgvGrafica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartEstadistica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGraficas.ResumeLayout(False)
        Me.gbGraficas.PerformLayout()
        Me.tbIndicadores.ResumeLayout(False)
        Me.tbIndicadores.PerformLayout()
        CType(Me.dgvgrafica2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbOcurrencias.ResumeLayout(False)
        Me.tbOcurrencias.PerformLayout()
        CType(Me.dgvOcurrencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TbOpciones As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tbClientes As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents tbVentas As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tbEstadisticas As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tbOcurrencias As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents btnSalirCli As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtDesEco As System.Windows.Forms.TextBox
    Friend WithEvents txtCodEco As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtTelf As System.Windows.Forms.TextBox
    Friend WithEvents txtDir As System.Windows.Forms.TextBox
    Friend WithEvents txtDesCli As System.Windows.Forms.TextBox
    Friend WithEvents txtDNI As System.Windows.Forms.TextBox
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCli As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents btnSalirVen As System.Windows.Forms.Button
    Friend WithEvents lblVencido As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblNoVencido As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents lblDespues As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents lblEnFecha As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents lblAntes As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents dgvVentas As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnSalirEst As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblTotalesSaldo As System.Windows.Forms.Label
    Friend WithEvents lblTotalesAntes As System.Windows.Forms.Label
    Friend WithEvents lblTotalesVentas As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblPendientesEnFecha As System.Windows.Forms.Label
    Friend WithEvents lblPendientesNoVencido As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblPagadoDespues As System.Windows.Forms.Label
    Friend WithEvents lblPagadoEnFecha As System.Windows.Forms.Label
    Friend WithEvents lblPagadoAntes As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnOcurSalir As System.Windows.Forms.Button
    Friend WithEvents btnOcurImprimir As System.Windows.Forms.Button
    Friend WithEvents dgvOcurrencias As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtOcurrenciaDetalle As System.Windows.Forms.TextBox
    Friend WithEvents lblOcurrencia As System.Windows.Forms.Label
    Friend WithEvents gbGraficas As System.Windows.Forms.GroupBox
    Friend WithEvents rbCircular As System.Windows.Forms.RadioButton
    Friend WithEvents rbBloques As System.Windows.Forms.RadioButton
    Friend WithEvents rbLineas As System.Windows.Forms.RadioButton
    Friend WithEvents dgvContactos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChartEstadistica As AxMSChart20Lib.AxMSChart
    Friend WithEvents dgvGrafica As System.Windows.Forms.DataGridView
    Friend WithEvents txtTotalesSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalesPagado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalesVentas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPendientesVencido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPendientesNoVencido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPagadosDespués As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPagadosEnFecha As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPagadosAntes As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblEstadisticas As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMensualFact As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents tbIndicadores As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPlazoenExceso As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPlazoAutorizado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtIndicadorDVPC As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDiasTranscurridos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtCuentasporCobrar As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtVentasAcumuladas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtClienteInd As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSalirInd As System.Windows.Forms.Button
    Friend WithEvents dgvgrafica2 As System.Windows.Forms.DataGridView
End Class
