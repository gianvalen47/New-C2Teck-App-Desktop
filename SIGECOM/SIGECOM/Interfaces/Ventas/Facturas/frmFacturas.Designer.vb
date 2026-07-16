<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturas
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
        Dim cmbTipFac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturas))
        Dim cmbSerieFactura_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEX2_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbTipFac = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.cmbSerieFactura = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GridEX2 = New Janus.Windows.GridEX.GridEX()
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox()
        Me.chkCliente = New System.Windows.Forms.CheckBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTicket = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEnviar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miB2Mining = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEstados = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFacturarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSugerir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miConsultarSugerido = New System.Windows.Forms.ToolStripMenuItem()
        Me.miBajarNivel = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCuotas = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizarLocacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGenerarNotaCredito = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEnviarFacturaElectronica = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.miGenerarFacturaElectronica = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDarBajaFacturaElectronica = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDescargarFacturaElectronica = New System.Windows.Forms.ToolStripMenuItem()
        Me.miListarFactElecxCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.miListarComunicadosBaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.miObservacionesSunat = New System.Windows.Forms.ToolStripMenuItem()
        Me.miObtenercdrdoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizarCDR = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.miGenerarAsiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.miVerAsiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator101 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.biTicket = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator102 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEnviar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biB2Mining = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator103 = New System.Windows.Forms.ToolStripSeparator()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator104 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEstados = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biFacturarJob = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.FacturarPendiente = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator105 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSugerir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biConsultarSugerido = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biBajarnivel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCuotas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator106 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizarLocacion = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerarNotaCredito = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEnviarCorreo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerarFacturaElectronica = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator107 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDarBajaFacturaElectronica = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDescargarFacturaElectronica = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.biListarFactElecxCliente = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.biListaComunicadosBaja = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.cmbTipFac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbSerieFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEX2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(314, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Tipo"
        '
        'cmbTipFac
        '
        Me.cmbTipFac.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipFac_DesignTimeLayout.LayoutString = resources.GetString("cmbTipFac_DesignTimeLayout.LayoutString")
        Me.cmbTipFac.DesignTimeLayout = cmbTipFac_DesignTimeLayout
        Me.cmbTipFac.Location = New System.Drawing.Point(314, 29)
        Me.cmbTipFac.Name = "cmbTipFac"
        Me.cmbTipFac.SelectedIndex = -1
        Me.cmbTipFac.SelectedItem = Nothing
        Me.cmbTipFac.Size = New System.Drawing.Size(100, 20)
        Me.cmbTipFac.TabIndex = 9
        Me.cmbTipFac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(747, 29)
        Me.txtNumDoc.MaxLength = 30
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(50, 20)
        Me.txtNumDoc.TabIndex = 15
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox1.Controls.Add(Me.txtIdCliente)
        Me.GroupBox1.Controls.Add(Me.cmbSerieFactura)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.GridEX2)
        Me.GroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.GroupBox1.Controls.Add(Me.chkCliente)
        Me.GroupBox1.Controls.Add(Me.txtObservacion)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmbTipFac)
        Me.GroupBox1.Controls.Add(Me.cmbMes)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtanio)
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.cmbIdLocacion)
        Me.GroupBox1.Controls.Add(Me.cmbOficinas)
        Me.GroupBox1.Controls.Add(Me.txtNumDoc)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(924, 55)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Búsqueda"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(635, 28)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarCliente.TabIndex = 12
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(500, 29)
        Me.txtIdCliente.MaxLength = 3
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(135, 20)
        Me.txtIdCliente.TabIndex = 11
        '
        'cmbSerieFactura
        '
        Me.cmbSerieFactura.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSerieFactura_DesignTimeLayout.LayoutString = resources.GetString("cmbSerieFactura_DesignTimeLayout.LayoutString")
        Me.cmbSerieFactura.DesignTimeLayout = cmbSerieFactura_DesignTimeLayout
        Me.cmbSerieFactura.Location = New System.Drawing.Point(415, 29)
        Me.cmbSerieFactura.Name = "cmbSerieFactura"
        Me.cmbSerieFactura.SelectedIndex = -1
        Me.cmbSerieFactura.SelectedItem = Nothing
        Me.cmbSerieFactura.Size = New System.Drawing.Size(84, 20)
        Me.cmbSerieFactura.TabIndex = 10
        Me.cmbSerieFactura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(414, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Serie"
        '
        'GridEX2
        '
        GridEX2_DesignTimeLayout.LayoutString = resources.GetString("GridEX2_DesignTimeLayout.LayoutString")
        Me.GridEX2.DesignTimeLayout = GridEX2_DesignTimeLayout
        Me.GridEX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridEX2.GroupByBoxVisible = False
        Me.GridEX2.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.GridEX2.Location = New System.Drawing.Point(871, 8)
        Me.GridEX2.Name = "GridEX2"
        Me.GridEX2.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GridEX2.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX2.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.GridEX2.Size = New System.Drawing.Size(49, 41)
        Me.GridEX2.TabIndex = 17
        Me.GridEX2.Visible = False
        Me.GridEX2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(570, 10)
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
        Me.chkCliente.Location = New System.Drawing.Point(553, 14)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(15, 14)
        Me.chkCliente.TabIndex = 27
        Me.chkCliente.Tag = ""
        Me.chkCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkCliente.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(804, 8)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(52, 16)
        Me.txtObservacion.TabIndex = 17
        Me.txtObservacion.Visible = False
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Location = New System.Drawing.Point(53, 29)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(77, 20)
        Me.cmbMes.TabIndex = 3
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(53, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Año"
        '
        'txtanio
        '
        Me.txtanio.Location = New System.Drawing.Point(4, 29)
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
        Me.cmbEstado.Location = New System.Drawing.Point(661, 29)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(85, 20)
        Me.cmbEstado.TabIndex = 13
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Location = New System.Drawing.Point(209, 29)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(104, 20)
        Me.cmbIdLocacion.TabIndex = 7
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Location = New System.Drawing.Point(131, 29)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(77, 20)
        Me.cmbOficinas.TabIndex = 5
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(798, 24)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 25)
        Me.btnBuscar.TabIndex = 16
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(501, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Cliente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(661, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Estado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(209, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Almacén"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(131, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Oficina"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(747, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Número"
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miTicket, Me.miEnviar, Me.miB2Mining, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miEstados, Me.miAnular, Me.miFacturarJob, Me.miSugerir, Me.miConsultarSugerido, Me.miBajarNivel, Me.miCuotas, Me.miActualizar, Me.miActualizarLocacion, Me.miGenerarNotaCredito, Me.miEnviarFacturaElectronica, Me.ToolStripSeparator19, Me.miGenerarFacturaElectronica, Me.miDarBajaFacturaElectronica, Me.miDescargarFacturaElectronica, Me.miListarFactElecxCliente, Me.miListarComunicadosBaja, Me.miObservacionesSunat, Me.miObtenercdrdoc, Me.miActualizarCDR, Me.ToolStripSeparator20, Me.miGenerarAsiento, Me.miVerAsiento, Me.ToolStripSeparator18, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(230, 660)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(229, 22)
        Me.miImprimir.Text = "&Imprimir"
        '
        'miTicket
        '
        Me.miTicket.Image = Global.SIGECOM.My.Resources.Resources.Ticket
        Me.miTicket.Name = "miTicket"
        Me.miTicket.Size = New System.Drawing.Size(229, 22)
        Me.miTicket.Text = "&Ticket"
        '
        'miEnviar
        '
        Me.miEnviar.Image = Global.SIGECOM.My.Resources.Resources.Pagos
        Me.miEnviar.Name = "miEnviar"
        Me.miEnviar.Size = New System.Drawing.Size(229, 22)
        Me.miEnviar.Text = "&Enviar"
        '
        'miB2Mining
        '
        Me.miB2Mining.Image = Global.SIGECOM.My.Resources.Resources.b2mining
        Me.miB2Mining.Name = "miB2Mining"
        Me.miB2Mining.Size = New System.Drawing.Size(229, 22)
        Me.miB2Mining.Text = "&B2Mining"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(229, 22)
        Me.miNuevo.Text = "&Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(229, 22)
        Me.miMostrar.Text = "&Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(229, 22)
        Me.miEliminar.Text = "&Eliminar"
        '
        'miEstados
        '
        Me.miEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miEstados.Name = "miEstados"
        Me.miEstados.Size = New System.Drawing.Size(229, 22)
        Me.miEstados.Text = "Estados"
        '
        'miAnular
        '
        Me.miAnular.Image = Global.SIGECOM.My.Resources.Resources.Anular
        Me.miAnular.Name = "miAnular"
        Me.miAnular.Size = New System.Drawing.Size(229, 22)
        Me.miAnular.Text = "&Anular"
        Me.miAnular.Visible = False
        '
        'miFacturarJob
        '
        Me.miFacturarJob.Image = Global.SIGECOM.My.Resources.Resources.Tools
        Me.miFacturarJob.Name = "miFacturarJob"
        Me.miFacturarJob.Size = New System.Drawing.Size(229, 22)
        Me.miFacturarJob.Text = "FacturarJob"
        '
        'miSugerir
        '
        Me.miSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.miSugerir.Name = "miSugerir"
        Me.miSugerir.Size = New System.Drawing.Size(229, 22)
        Me.miSugerir.Text = "Sugerir"
        '
        'miConsultarSugerido
        '
        Me.miConsultarSugerido.Image = CType(resources.GetObject("miConsultarSugerido.Image"), System.Drawing.Image)
        Me.miConsultarSugerido.Name = "miConsultarSugerido"
        Me.miConsultarSugerido.Size = New System.Drawing.Size(229, 22)
        Me.miConsultarSugerido.Text = "Consultar Sugeridos"
        '
        'miBajarNivel
        '
        Me.miBajarNivel.Image = Global.SIGECOM.My.Resources.Resources.bajar_estado
        Me.miBajarNivel.Name = "miBajarNivel"
        Me.miBajarNivel.Size = New System.Drawing.Size(229, 22)
        Me.miBajarNivel.Text = "Bajar Estado"
        Me.miBajarNivel.Visible = False
        '
        'miCuotas
        '
        Me.miCuotas.Image = CType(resources.GetObject("miCuotas.Image"), System.Drawing.Image)
        Me.miCuotas.Name = "miCuotas"
        Me.miCuotas.Size = New System.Drawing.Size(229, 22)
        Me.miCuotas.Text = "Cuotas"
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(229, 22)
        Me.miActualizar.Text = "A&ctualizar"
        '
        'miActualizarLocacion
        '
        Me.miActualizarLocacion.Image = Global.SIGECOM.My.Resources.Resources.Empresa
        Me.miActualizarLocacion.Name = "miActualizarLocacion"
        Me.miActualizarLocacion.Size = New System.Drawing.Size(229, 22)
        Me.miActualizarLocacion.Text = "Actualizar Locación"
        '
        'miGenerarNotaCredito
        '
        Me.miGenerarNotaCredito.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.miGenerarNotaCredito.Name = "miGenerarNotaCredito"
        Me.miGenerarNotaCredito.Size = New System.Drawing.Size(229, 22)
        Me.miGenerarNotaCredito.Text = "Generar Nota Credito"
        '
        'miEnviarFacturaElectronica
        '
        Me.miEnviarFacturaElectronica.Image = Global.SIGECOM.My.Resources.Resources.Enviar_
        Me.miEnviarFacturaElectronica.Name = "miEnviarFacturaElectronica"
        Me.miEnviarFacturaElectronica.Size = New System.Drawing.Size(229, 22)
        Me.miEnviarFacturaElectronica.Text = "Enviar Factura Electronica"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(226, 6)
        '
        'miGenerarFacturaElectronica
        '
        Me.miGenerarFacturaElectronica.Image = CType(resources.GetObject("miGenerarFacturaElectronica.Image"), System.Drawing.Image)
        Me.miGenerarFacturaElectronica.Name = "miGenerarFacturaElectronica"
        Me.miGenerarFacturaElectronica.Size = New System.Drawing.Size(229, 22)
        Me.miGenerarFacturaElectronica.Text = "Generar Factura Electronica"
        '
        'miDarBajaFacturaElectronica
        '
        Me.miDarBajaFacturaElectronica.Image = CType(resources.GetObject("miDarBajaFacturaElectronica.Image"), System.Drawing.Image)
        Me.miDarBajaFacturaElectronica.Name = "miDarBajaFacturaElectronica"
        Me.miDarBajaFacturaElectronica.Size = New System.Drawing.Size(229, 22)
        Me.miDarBajaFacturaElectronica.Text = "Dar Baja Factura Electronica"
        '
        'miDescargarFacturaElectronica
        '
        Me.miDescargarFacturaElectronica.Image = CType(resources.GetObject("miDescargarFacturaElectronica.Image"), System.Drawing.Image)
        Me.miDescargarFacturaElectronica.Name = "miDescargarFacturaElectronica"
        Me.miDescargarFacturaElectronica.Size = New System.Drawing.Size(229, 22)
        Me.miDescargarFacturaElectronica.Text = "Descargar Factura Electronica"
        '
        'miListarFactElecxCliente
        '
        Me.miListarFactElecxCliente.Image = CType(resources.GetObject("miListarFactElecxCliente.Image"), System.Drawing.Image)
        Me.miListarFactElecxCliente.Name = "miListarFactElecxCliente"
        Me.miListarFactElecxCliente.Size = New System.Drawing.Size(229, 22)
        Me.miListarFactElecxCliente.Text = "Listar Facturas Electronicas"
        '
        'miListarComunicadosBaja
        '
        Me.miListarComunicadosBaja.Image = CType(resources.GetObject("miListarComunicadosBaja.Image"), System.Drawing.Image)
        Me.miListarComunicadosBaja.Name = "miListarComunicadosBaja"
        Me.miListarComunicadosBaja.Size = New System.Drawing.Size(229, 22)
        Me.miListarComunicadosBaja.Text = "Listar Comunicados Baja"
        '
        'miObservacionesSunat
        '
        Me.miObservacionesSunat.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miObservacionesSunat.Name = "miObservacionesSunat"
        Me.miObservacionesSunat.Size = New System.Drawing.Size(229, 22)
        Me.miObservacionesSunat.Text = "Observaciones Sunat"
        '
        'miObtenercdrdoc
        '
        Me.miObtenercdrdoc.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miObtenercdrdoc.Name = "miObtenercdrdoc"
        Me.miObtenercdrdoc.Size = New System.Drawing.Size(229, 22)
        Me.miObtenercdrdoc.Text = "Obtener cdr documento"
        '
        'miActualizarCDR
        '
        Me.miActualizarCDR.Image = CType(resources.GetObject("miActualizarCDR.Image"), System.Drawing.Image)
        Me.miActualizarCDR.Name = "miActualizarCDR"
        Me.miActualizarCDR.Size = New System.Drawing.Size(229, 22)
        Me.miActualizarCDR.Text = "Actualizar CDR"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(226, 6)
        '
        'miGenerarAsiento
        '
        Me.miGenerarAsiento.Image = Global.SIGECOM.My.Resources.Resources.Cont_diario
        Me.miGenerarAsiento.Name = "miGenerarAsiento"
        Me.miGenerarAsiento.Size = New System.Drawing.Size(229, 22)
        Me.miGenerarAsiento.Text = "Generar Asiento Contable"
        '
        'miVerAsiento
        '
        Me.miVerAsiento.Image = Global.SIGECOM.My.Resources.Resources.laptop_48
        Me.miVerAsiento.Name = "miVerAsiento"
        Me.miVerAsiento.Size = New System.Drawing.Size(229, 22)
        Me.miVerAsiento.Text = "Ver Asiento Contable"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(226, 6)
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(229, 22)
        Me.miSalir.Text = "&Salir"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
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
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(0, 88)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(912, 396)
        Me.dgvDatos.TabIndex = 2
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator101, Me.biImprimir, Me.ToolStripSeparator11, Me.biTicket, Me.ToolStripSeparator102, Me.biEnviar, Me.ToolStripSeparator5, Me.biB2Mining, Me.ToolStripSeparator103, Me.biNuevo, Me.ToolStripSeparator3, Me.biMostrar, Me.ToolStripSeparator104, Me.biEliminar, Me.ToolStripSeparator4, Me.biEstados, Me.ToolStripSeparator6, Me.biAnular, Me.ToolStripSeparator7, Me.biFacturarJob, Me.ToolStripSeparator8, Me.FacturarPendiente, Me.ToolStripSeparator105, Me.biSugerir, Me.ToolStripSeparator9, Me.biConsultarSugerido, Me.ToolStripSeparator2, Me.biBajarnivel, Me.ToolStripSeparator10, Me.biCuotas, Me.ToolStripSeparator1, Me.biActualizar, Me.ToolStripSeparator106, Me.biActualizarLocacion, Me.ToolStripSeparator21, Me.biGenerarNotaCredito, Me.ToolStripSeparator13, Me.biEnviarCorreo, Me.ToolStripSeparator16, Me.biGenerarFacturaElectronica, Me.ToolStripSeparator107, Me.biDarBajaFacturaElectronica, Me.ToolStripSeparator12, Me.biDescargarFacturaElectronica, Me.ToolStripSeparator22, Me.biListarFactElecxCliente, Me.ToolStripSeparator14, Me.biListaComunicadosBaja, Me.ToolStripSeparator15, Me.biSalir, Me.ToolStripSeparator17})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(924, 31)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator101
        '
        Me.ToolStripSeparator101.Name = "ToolStripSeparator101"
        Me.ToolStripSeparator101.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'biTicket
        '
        Me.biTicket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biTicket.Image = Global.SIGECOM.My.Resources.Resources.Ticket
        Me.biTicket.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biTicket.Name = "biTicket"
        Me.biTicket.Size = New System.Drawing.Size(28, 28)
        Me.biTicket.Text = "Ticket"
        '
        'ToolStripSeparator102
        '
        Me.ToolStripSeparator102.Name = "ToolStripSeparator102"
        Me.ToolStripSeparator102.Size = New System.Drawing.Size(6, 31)
        '
        'biEnviar
        '
        Me.biEnviar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEnviar.Image = Global.SIGECOM.My.Resources.Resources.Pagos
        Me.biEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEnviar.Name = "biEnviar"
        Me.biEnviar.Size = New System.Drawing.Size(28, 28)
        Me.biEnviar.Text = "Enviar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biB2Mining
        '
        Me.biB2Mining.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biB2Mining.Image = Global.SIGECOM.My.Resources.Resources.b2mining
        Me.biB2Mining.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biB2Mining.Name = "biB2Mining"
        Me.biB2Mining.Size = New System.Drawing.Size(28, 28)
        Me.biB2Mining.Text = "B2Mining"
        '
        'ToolStripSeparator103
        '
        Me.ToolStripSeparator103.Name = "ToolStripSeparator103"
        Me.ToolStripSeparator103.Size = New System.Drawing.Size(6, 31)
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Black
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Nuevo"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar"
        '
        'ToolStripSeparator104
        '
        Me.ToolStripSeparator104.Name = "ToolStripSeparator104"
        Me.ToolStripSeparator104.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biEstados
        '
        Me.biEstados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.biEstados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEstados.Name = "biEstados"
        Me.biEstados.Size = New System.Drawing.Size(28, 28)
        Me.biEstados.Text = "Mostrar Estados de la Factura"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biAnular
        '
        Me.biAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAnular.Image = Global.SIGECOM.My.Resources.Resources.Anular
        Me.biAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAnular.Name = "biAnular"
        Me.biAnular.Size = New System.Drawing.Size(28, 28)
        Me.biAnular.Text = "Anular"
        Me.biAnular.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator7.Visible = False
        '
        'biFacturarJob
        '
        Me.biFacturarJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biFacturarJob.Image = Global.SIGECOM.My.Resources.Resources.Tools
        Me.biFacturarJob.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biFacturarJob.Name = "biFacturarJob"
        Me.biFacturarJob.Size = New System.Drawing.Size(28, 28)
        Me.biFacturarJob.Text = "Facturar OT"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'FacturarPendiente
        '
        Me.FacturarPendiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FacturarPendiente.Image = Global.SIGECOM.My.Resources.Resources.FacturaGuia
        Me.FacturarPendiente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FacturarPendiente.Name = "FacturarPendiente"
        Me.FacturarPendiente.Size = New System.Drawing.Size(28, 28)
        Me.FacturarPendiente.Text = "FacturarPendiente"
        Me.FacturarPendiente.ToolTipText = "Facturar Grupo G/R Pendientes"
        '
        'ToolStripSeparator105
        '
        Me.ToolStripSeparator105.Name = "ToolStripSeparator105"
        Me.ToolStripSeparator105.Size = New System.Drawing.Size(6, 31)
        '
        'biSugerir
        '
        Me.biSugerir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.biSugerir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSugerir.Name = "biSugerir"
        Me.biSugerir.Size = New System.Drawing.Size(28, 28)
        Me.biSugerir.Text = "Sugerir Factor o Descuento"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biBajarnivel
        '
        Me.biBajarnivel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biBajarnivel.Image = Global.SIGECOM.My.Resources.Resources.bajar_estado
        Me.biBajarnivel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biBajarnivel.Name = "biBajarnivel"
        Me.biBajarnivel.Size = New System.Drawing.Size(28, 28)
        Me.biBajarnivel.Text = "Bajar de nivel"
        Me.biBajarnivel.Visible = False
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator10.Visible = False
        '
        'biCuotas
        '
        Me.biCuotas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCuotas.Image = CType(resources.GetObject("biCuotas.Image"), System.Drawing.Image)
        Me.biCuotas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCuotas.Name = "biCuotas"
        Me.biCuotas.Size = New System.Drawing.Size(28, 28)
        Me.biCuotas.Text = "Cuotas"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator106
        '
        Me.ToolStripSeparator106.Name = "ToolStripSeparator106"
        Me.ToolStripSeparator106.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizarLocacion
        '
        Me.biActualizarLocacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizarLocacion.Image = Global.SIGECOM.My.Resources.Resources.Empresa
        Me.biActualizarLocacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizarLocacion.Name = "biActualizarLocacion"
        Me.biActualizarLocacion.Size = New System.Drawing.Size(28, 28)
        Me.biActualizarLocacion.ToolTipText = "Actualizar Locacion"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerarNotaCredito
        '
        Me.biGenerarNotaCredito.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarNotaCredito.Image = CType(resources.GetObject("biGenerarNotaCredito.Image"), System.Drawing.Image)
        Me.biGenerarNotaCredito.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarNotaCredito.Name = "biGenerarNotaCredito"
        Me.biGenerarNotaCredito.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarNotaCredito.Text = "Generar Nota Credito"
        Me.biGenerarNotaCredito.ToolTipText = "Generar Nota Credito"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'biEnviarCorreo
        '
        Me.biEnviarCorreo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEnviarCorreo.Image = CType(resources.GetObject("biEnviarCorreo.Image"), System.Drawing.Image)
        Me.biEnviarCorreo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEnviarCorreo.Name = "biEnviarCorreo"
        Me.biEnviarCorreo.Size = New System.Drawing.Size(28, 28)
        Me.biEnviarCorreo.Text = "Enviar Factura Electronica"
        Me.biEnviarCorreo.ToolTipText = "Enviar Factura Electronica"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerarFacturaElectronica
        '
        Me.biGenerarFacturaElectronica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarFacturaElectronica.Image = CType(resources.GetObject("biGenerarFacturaElectronica.Image"), System.Drawing.Image)
        Me.biGenerarFacturaElectronica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarFacturaElectronica.Name = "biGenerarFacturaElectronica"
        Me.biGenerarFacturaElectronica.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarFacturaElectronica.Text = "Generar Factura Electronica"
        Me.biGenerarFacturaElectronica.ToolTipText = "Generar Factura Electronica"
        '
        'ToolStripSeparator107
        '
        Me.ToolStripSeparator107.Name = "ToolStripSeparator107"
        Me.ToolStripSeparator107.Size = New System.Drawing.Size(6, 31)
        '
        'biDarBajaFacturaElectronica
        '
        Me.biDarBajaFacturaElectronica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDarBajaFacturaElectronica.Image = CType(resources.GetObject("biDarBajaFacturaElectronica.Image"), System.Drawing.Image)
        Me.biDarBajaFacturaElectronica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDarBajaFacturaElectronica.Name = "biDarBajaFacturaElectronica"
        Me.biDarBajaFacturaElectronica.Size = New System.Drawing.Size(28, 28)
        Me.biDarBajaFacturaElectronica.Text = "Comunicacion de Baja Factura Electronica"
        Me.biDarBajaFacturaElectronica.ToolTipText = "Comunicacion de Baja Factura Electronica"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        '
        'biDescargarFacturaElectronica
        '
        Me.biDescargarFacturaElectronica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDescargarFacturaElectronica.Image = CType(resources.GetObject("biDescargarFacturaElectronica.Image"), System.Drawing.Image)
        Me.biDescargarFacturaElectronica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDescargarFacturaElectronica.Name = "biDescargarFacturaElectronica"
        Me.biDescargarFacturaElectronica.Size = New System.Drawing.Size(28, 28)
        Me.biDescargarFacturaElectronica.Text = "Descargar Factura Electronica"
        Me.biDescargarFacturaElectronica.ToolTipText = "Descargar Factura Electronica"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(6, 31)
        '
        'biListarFactElecxCliente
        '
        Me.biListarFactElecxCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biListarFactElecxCliente.Image = CType(resources.GetObject("biListarFactElecxCliente.Image"), System.Drawing.Image)
        Me.biListarFactElecxCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biListarFactElecxCliente.Name = "biListarFactElecxCliente"
        Me.biListarFactElecxCliente.Size = New System.Drawing.Size(28, 28)
        Me.biListarFactElecxCliente.Text = "Lista Facturas Electronicas"
        Me.biListarFactElecxCliente.ToolTipText = "Lista Facturas Electronicas"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'biListaComunicadosBaja
        '
        Me.biListaComunicadosBaja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biListaComunicadosBaja.Image = CType(resources.GetObject("biListaComunicadosBaja.Image"), System.Drawing.Image)
        Me.biListaComunicadosBaja.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biListaComunicadosBaja.Name = "biListaComunicadosBaja"
        Me.biListaComunicadosBaja.Size = New System.Drawing.Size(28, 28)
        Me.biListaComunicadosBaja.Text = "Lista Comunicados Baja"
        Me.biListaComunicadosBaja.ToolTipText = "Lista Comunicados Baja"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Salir"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator17.Visible = False
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 502)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(924, 20)
        Me.ssBarra.TabIndex = 3
        '
        'frmFacturas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(924, 522)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturas de Venta"
        CType(Me.cmbTipFac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbSerieFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEX2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTipFac As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biTicket As System.Windows.Forms.ToolStripButton
    Friend WithEvents biEnviar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biB2Mining As System.Windows.Forms.ToolStripButton
    Friend WithEvents biAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator101 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator102 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator103 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator104 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator105 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator106 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator107 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miTicket As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEnviar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miB2Mining As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSugerir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biSugerir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biFacturarJob As System.Windows.Forms.ToolStripButton
    Friend WithEvents miFacturarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents biConsultarSugerido As System.Windows.Forms.ToolStripButton
    Friend WithEvents miConsultarSugerido As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturarPendiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents biEstados As System.Windows.Forms.ToolStripButton
    Friend WithEvents miEstados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miActualizarLocacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biActualizarLocacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biBajarnivel As System.Windows.Forms.ToolStripButton
    Friend WithEvents miBajarNivel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biGenerarFacturaElectronica As System.Windows.Forms.ToolStripButton
    Friend WithEvents biDarBajaFacturaElectronica As System.Windows.Forms.ToolStripButton
    Friend WithEvents biDescargarFacturaElectronica As System.Windows.Forms.ToolStripButton
    Friend WithEvents biListarFactElecxCliente As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridEX2 As Janus.Windows.GridEX.GridEX
    Friend WithEvents biListaComunicadosBaja As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miGenerarFacturaElectronica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDarBajaFacturaElectronica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDescargarFacturaElectronica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miListarFactElecxCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miListarComunicadosBaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miObservacionesSunat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miObtenercdrdoc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miActualizarCDR As ToolStripMenuItem
    Friend WithEvents miGenerarAsiento As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator18 As ToolStripSeparator
    Friend WithEvents miVerAsiento As ToolStripMenuItem
    Friend WithEvents biCuotas As ToolStripButton
    Friend WithEvents miCuotas As ToolStripMenuItem
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbSerieFactura As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ToolStripSeparator21 As ToolStripSeparator
    Friend WithEvents biEnviarCorreo As ToolStripButton
    Friend WithEvents miEnviarFacturaElectronica As ToolStripMenuItem
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents txtIdCliente As TextBox
    Friend WithEvents biGenerarNotaCredito As ToolStripButton
    Friend WithEvents ToolStripSeparator22 As ToolStripSeparator
    Friend WithEvents miGenerarNotaCredito As ToolStripMenuItem
End Class
