<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCotizaciones
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
        Dim cmbVendedor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCotizaciones))
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbVendedor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox()
        Me.chkCliente = New System.Windows.Forms.CheckBox()
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumCot = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnseguimiento = New System.Windows.Forms.ToolStripButton()
        Me.biGenerar = New System.Windows.Forms.ToolStripButton()
        Me.biEnviar = New System.Windows.Forms.ToolStripButton()
        Me.biGenerarGuiasMulti = New System.Windows.Forms.ToolStripButton()
        Me.biGenerarCoti = New System.Windows.Forms.ToolStripButton()
        Me.biRechazar = New System.Windows.Forms.ToolStripButton()
        Me.biEstado = New System.Windows.Forms.ToolStripButton()
        Me.biConsultarSugerido = New System.Windows.Forms.ToolStripButton()
        Me.biSugerir = New System.Windows.Forms.ToolStripButton()
        Me.biModificarValidez = New System.Windows.Forms.ToolStripButton()
        Me.biArchivos = New System.Windows.Forms.ToolStripButton()
        Me.biactualizar = New System.Windows.Forms.ToolStripButton()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSeguimiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGenerar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEnviar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGenerarGuiasMulti = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGenerarCoti = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRechazar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEstado = New System.Windows.Forms.ToolStripMenuItem()
        Me.miConsultarSugerido = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSugerir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miModificarValidez = New System.Windows.Forms.ToolStripMenuItem()
        Me.miArchivos = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(543, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Estado"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox1.Controls.Add(Me.txtIdCliente)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmbVendedor)
        Me.GroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.GroupBox1.Controls.Add(Me.chkCliente)
        Me.GroupBox1.Controls.Add(Me.cmbMes)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtanio)
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.cmbIdLocacion)
        Me.GroupBox1.Controls.Add(Me.cmbOficinas)
        Me.GroupBox1.Controls.Add(Me.txtNumCot)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(2, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(856, 55)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Búsqueda"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(516, 28)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarCliente.TabIndex = 6
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(351, 29)
        Me.txtIdCliente.MaxLength = 3
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(164, 20)
        Me.txtIdCliente.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(638, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Vendedor"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbVendedor_DesignTimeLayout.LayoutString = resources.GetString("cmbVendedor_DesignTimeLayout.LayoutString")
        Me.cmbVendedor.DesignTimeLayout = cmbVendedor_DesignTimeLayout
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.Location = New System.Drawing.Point(639, 29)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.SelectedIndex = -1
        Me.cmbVendedor.SelectedItem = Nothing
        Me.cmbVendedor.Size = New System.Drawing.Size(81, 20)
        Me.cmbVendedor.TabIndex = 8
        Me.cmbVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(425, 10)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 28
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'chkCliente
        '
        Me.chkCliente.AutoSize = True
        Me.chkCliente.Checked = True
        Me.chkCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCliente.Location = New System.Drawing.Point(408, 14)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(15, 14)
        Me.chkCliente.TabIndex = 27
        Me.chkCliente.Tag = ""
        Me.chkCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkCliente.UseVisualStyleBackColor = True
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(55, 29)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(82, 20)
        Me.cmbMes.TabIndex = 2
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(55, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Año"
        '
        'txtanio
        '
        Me.txtanio.Location = New System.Drawing.Point(6, 29)
        Me.txtanio.Maximum = 2059
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2006
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(48, 20)
        Me.txtanio.TabIndex = 1
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2006
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(543, 29)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(94, 20)
        Me.cmbEstado.TabIndex = 7
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(220, 29)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(130, 20)
        Me.cmbIdLocacion.TabIndex = 4
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(138, 29)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(81, 20)
        Me.cmbOficinas.TabIndex = 3
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumCot
        '
        Me.txtNumCot.Location = New System.Drawing.Point(722, 29)
        Me.txtNumCot.MaxLength = 30
        Me.txtNumCot.Name = "txtNumCot"
        Me.txtNumCot.Size = New System.Drawing.Size(58, 20)
        Me.txtNumCot.TabIndex = 9
        Me.txtNumCot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(782, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 25)
        Me.btnBuscar.TabIndex = 10
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(351, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Cliente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(220, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Almacén"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Oficina"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(726, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Número"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biImprimir, Me.biNuevo, Me.biMostrar, Me.biEliminar, Me.btnseguimiento, Me.biGenerar, Me.biEnviar, Me.biGenerarGuiasMulti, Me.biGenerarCoti, Me.biRechazar, Me.biEstado, Me.biConsultarSugerido, Me.biSugerir, Me.biModificarValidez, Me.biArchivos, Me.biactualizar, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(881, 31)
        Me.ToolStrip.TabIndex = 3
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
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Black
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Crear un nuevo cotizacion"
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar los datos la cotizacion seleccionada"
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar cotizacion seleccionada"
        '
        'btnseguimiento
        '
        Me.btnseguimiento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnseguimiento.Image = Global.SIGECOM.My.Resources.Resources.ACTIVITL
        Me.btnseguimiento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnseguimiento.Name = "btnseguimiento"
        Me.btnseguimiento.Size = New System.Drawing.Size(28, 28)
        Me.btnseguimiento.Text = "Observaciones de la Cotizacion"
        '
        'biGenerar
        '
        Me.biGenerar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerar.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.biGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerar.Name = "biGenerar"
        Me.biGenerar.Size = New System.Drawing.Size(28, 28)
        Me.biGenerar.Text = "Generar G/F/B/O.C."
        '
        'biEnviar
        '
        Me.biEnviar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEnviar.Image = Global.SIGECOM.My.Resources.Resources.Pagos
        Me.biEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEnviar.Name = "biEnviar"
        Me.biEnviar.Size = New System.Drawing.Size(28, 28)
        Me.biEnviar.Text = "Enviar a Créditos"
        '
        'biGenerarGuiasMulti
        '
        Me.biGenerarGuiasMulti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarGuiasMulti.Image = Global.SIGECOM.My.Resources.Resources.GuiaRemision
        Me.biGenerarGuiasMulti.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarGuiasMulti.Name = "biGenerarGuiasMulti"
        Me.biGenerarGuiasMulti.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarGuiasMulti.Text = "Generar Guias de Remisión Múltiples"
        '
        'biGenerarCoti
        '
        Me.biGenerarCoti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarCoti.Image = Global.SIGECOM.My.Resources.Resources.Canjear
        Me.biGenerarCoti.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarCoti.Name = "biGenerarCoti"
        Me.biGenerarCoti.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarCoti.Text = "Duplicar Cotización"
        '
        'biRechazar
        '
        Me.biRechazar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biRechazar.Image = Global.SIGECOM.My.Resources.Resources.Rechazar
        Me.biRechazar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biRechazar.Name = "biRechazar"
        Me.biRechazar.Size = New System.Drawing.Size(28, 28)
        Me.biRechazar.Text = "Rechazar Cotización"
        '
        'biEstado
        '
        Me.biEstado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEstado.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.biEstado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.biEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEstado.Name = "biEstado"
        Me.biEstado.Size = New System.Drawing.Size(28, 28)
        Me.biEstado.Text = "Mostrar Estados de La Cotización"
        '
        'biConsultarSugerido
        '
        Me.biConsultarSugerido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biConsultarSugerido.Image = CType(resources.GetObject("biConsultarSugerido.Image"), System.Drawing.Image)
        Me.biConsultarSugerido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biConsultarSugerido.Name = "biConsultarSugerido"
        Me.biConsultarSugerido.Size = New System.Drawing.Size(28, 28)
        Me.biConsultarSugerido.Text = "Mostrar Precios Sugeridos"
        '
        'biSugerir
        '
        Me.biSugerir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.biSugerir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSugerir.Name = "biSugerir"
        Me.biSugerir.Size = New System.Drawing.Size(28, 28)
        Me.biSugerir.Text = "Sugerir Factor/Descuento"
        '
        'biModificarValidez
        '
        Me.biModificarValidez.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biModificarValidez.Image = Global.SIGECOM.My.Resources.Resources.Fecha
        Me.biModificarValidez.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biModificarValidez.Name = "biModificarValidez"
        Me.biModificarValidez.Size = New System.Drawing.Size(28, 28)
        Me.biModificarValidez.Text = "Modificar Días de Validez"
        Me.biModificarValidez.Visible = False
        '
        'biArchivos
        '
        Me.biArchivos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biArchivos.Image = CType(resources.GetObject("biArchivos.Image"), System.Drawing.Image)
        Me.biArchivos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.biArchivos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biArchivos.Name = "biArchivos"
        Me.biArchivos.Size = New System.Drawing.Size(28, 28)
        Me.biArchivos.Text = "Mostrar Archivos"
        '
        'biactualizar
        '
        Me.biactualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biactualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biactualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biactualizar.Name = "biactualizar"
        Me.biactualizar.Size = New System.Drawing.Size(28, 28)
        Me.biactualizar.Text = "Actualizar Cotizacion"
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
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miSeguimiento, Me.miGenerar, Me.miEnviar, Me.miGenerarGuiasMulti, Me.miGenerarCoti, Me.miRechazar, Me.miEstado, Me.miConsultarSugerido, Me.miSugerir, Me.miModificarValidez, Me.miArchivos, Me.miActualizar, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(200, 384)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(199, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(199, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(199, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(199, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(196, 6)
        '
        'miSeguimiento
        '
        Me.miSeguimiento.Image = Global.SIGECOM.My.Resources.Resources.ACTIVITL
        Me.miSeguimiento.Name = "miSeguimiento"
        Me.miSeguimiento.Size = New System.Drawing.Size(199, 22)
        Me.miSeguimiento.Text = "Observacion"
        '
        'miGenerar
        '
        Me.miGenerar.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.miGenerar.Name = "miGenerar"
        Me.miGenerar.Size = New System.Drawing.Size(199, 22)
        Me.miGenerar.Text = "Generar Documento"
        '
        'miEnviar
        '
        Me.miEnviar.Image = Global.SIGECOM.My.Resources.Resources.Pagos
        Me.miEnviar.Name = "miEnviar"
        Me.miEnviar.Size = New System.Drawing.Size(199, 22)
        Me.miEnviar.Text = "Enviar "
        '
        'miGenerarGuiasMulti
        '
        Me.miGenerarGuiasMulti.Image = Global.SIGECOM.My.Resources.Resources.GuiaRemision
        Me.miGenerarGuiasMulti.Name = "miGenerarGuiasMulti"
        Me.miGenerarGuiasMulti.Size = New System.Drawing.Size(199, 22)
        Me.miGenerarGuiasMulti.Text = "Generar Guias Multiples"
        '
        'miGenerarCoti
        '
        Me.miGenerarCoti.Image = Global.SIGECOM.My.Resources.Resources.UpLoad
        Me.miGenerarCoti.Name = "miGenerarCoti"
        Me.miGenerarCoti.Size = New System.Drawing.Size(199, 22)
        Me.miGenerarCoti.Text = "Generar Cotización"
        '
        'miRechazar
        '
        Me.miRechazar.Image = Global.SIGECOM.My.Resources.Resources.Rechazar
        Me.miRechazar.Name = "miRechazar"
        Me.miRechazar.Size = New System.Drawing.Size(199, 22)
        Me.miRechazar.Text = "Rechazar Cotización"
        '
        'miEstado
        '
        Me.miEstado.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miEstado.Name = "miEstado"
        Me.miEstado.Size = New System.Drawing.Size(199, 22)
        Me.miEstado.Text = "Estados Cotización"
        '
        'miConsultarSugerido
        '
        Me.miConsultarSugerido.Image = CType(resources.GetObject("miConsultarSugerido.Image"), System.Drawing.Image)
        Me.miConsultarSugerido.Name = "miConsultarSugerido"
        Me.miConsultarSugerido.Size = New System.Drawing.Size(199, 22)
        Me.miConsultarSugerido.Text = "Consultar Sugeridos"
        '
        'miSugerir
        '
        Me.miSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.miSugerir.Name = "miSugerir"
        Me.miSugerir.Size = New System.Drawing.Size(199, 22)
        Me.miSugerir.Text = "Sugerir"
        '
        'miModificarValidez
        '
        Me.miModificarValidez.Image = Global.SIGECOM.My.Resources.Resources.Fecha
        Me.miModificarValidez.Name = "miModificarValidez"
        Me.miModificarValidez.Size = New System.Drawing.Size(199, 22)
        Me.miModificarValidez.Text = "Modificar Validez"
        '
        'miArchivos
        '
        Me.miArchivos.Image = CType(resources.GetObject("miArchivos.Image"), System.Drawing.Image)
        Me.miArchivos.Name = "miArchivos"
        Me.miArchivos.Size = New System.Drawing.Size(199, 22)
        Me.miArchivos.Text = "Archivos"
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(199, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(199, 22)
        Me.miSalir.Text = "Salir"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 342)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(881, 20)
        Me.ssBarra.TabIndex = 2
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
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(2, 92)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(867, 241)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmCotizaciones
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(881, 362)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCotizaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cotizaciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumCot As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents biactualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnseguimiento As System.Windows.Forms.ToolStripButton
    Friend WithEvents miSeguimiento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biGenerar As System.Windows.Forms.ToolStripButton
    Friend WithEvents miGenerar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents biGenerarCoti As System.Windows.Forms.ToolStripButton
    Friend WithEvents miGenerarCoti As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biRechazar As System.Windows.Forms.ToolStripButton
    Friend WithEvents miRechazar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents miEstado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biSugerir As System.Windows.Forms.ToolStripButton
    Friend WithEvents miSugerir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biGenerarGuiasMulti As System.Windows.Forms.ToolStripButton
    Friend WithEvents miGenerarGuiasMulti As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biEnviar As System.Windows.Forms.ToolStripButton
    Friend WithEvents miEnviar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbVendedor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents biModificarValidez As System.Windows.Forms.ToolStripButton
    Friend WithEvents miModificarValidez As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biConsultarSugerido As System.Windows.Forms.ToolStripButton
    Friend WithEvents miConsultarSugerido As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents biArchivos As ToolStripButton
    Friend WithEvents miArchivos As ToolStripMenuItem
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents txtIdCliente As TextBox
End Class
