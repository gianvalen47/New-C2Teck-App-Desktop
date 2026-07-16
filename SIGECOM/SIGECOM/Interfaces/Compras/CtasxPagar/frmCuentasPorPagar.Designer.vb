<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentasPorPagar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentasPorPagar))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDescargarXml = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDescargarPdf = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miConsultarEstados = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCancelacionManual = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biPagarManual = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biConsulEstados = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.txtAnio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox()
        Me.chkProveedor = New System.Windows.Forms.CheckBox()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdGasto = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSaldoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSaldoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVencidoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtVencidoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPorVencerDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPorVencerSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miDescargarXml, Me.miDescargarPdf, Me.miSeparador1, Me.miConsultarEstados, Me.miCancelacionManual, Me.ToolStripMenuItem1, Me.miActualizar, Me.miSalir})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(179, 236)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(178, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(178, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(178, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(178, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miDescargarXml
        '
        Me.miDescargarXml.Image = CType(resources.GetObject("miDescargarXml.Image"), System.Drawing.Image)
        Me.miDescargarXml.Name = "miDescargarXml"
        Me.miDescargarXml.Size = New System.Drawing.Size(178, 22)
        Me.miDescargarXml.Text = "Descargar Xml"
        Me.miDescargarXml.ToolTipText = "Descargar Xml"
        '
        'miDescargarPdf
        '
        Me.miDescargarPdf.Image = CType(resources.GetObject("miDescargarPdf.Image"), System.Drawing.Image)
        Me.miDescargarPdf.Name = "miDescargarPdf"
        Me.miDescargarPdf.Size = New System.Drawing.Size(178, 22)
        Me.miDescargarPdf.Text = "Descargar Pdf"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(175, 6)
        '
        'miConsultarEstados
        '
        Me.miConsultarEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miConsultarEstados.Name = "miConsultarEstados"
        Me.miConsultarEstados.Size = New System.Drawing.Size(178, 22)
        Me.miConsultarEstados.Text = "Consultar Estados"
        '
        'miCancelacionManual
        '
        Me.miCancelacionManual.Image = Global.SIGECOM.My.Resources.Resources.ctasPagar
        Me.miCancelacionManual.Name = "miCancelacionManual"
        Me.miCancelacionManual.Size = New System.Drawing.Size(178, 22)
        Me.miCancelacionManual.Text = "Pago Manualmente"
        Me.miCancelacionManual.ToolTipText = "Cancelar pago manualmente"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(175, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(178, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(178, 22)
        Me.miSalir.Text = "Salir"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.biImprimir, Me.ToolStripSeparator2, Me.biNuevo, Me.ToolStripSeparator1, Me.biMostrar, Me.ToolStripSeparator3, Me.biEliminar, Me.ToolStripSeparator9, Me.biActualizar, Me.ToolStripSeparator5, Me.biPagarManual, Me.ToolStripSeparator7, Me.biConsulEstados, Me.ToolStripSeparator4, Me.biSalir, Me.ToolStripSeparator8})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1004, 31)
        Me.ToolStrip.TabIndex = 170
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Cuenta por Pagar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Nueva Cuenta por Pagar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar Cuenta por Pagar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar Cuenta por Pagar"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Cuentas por Pagar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biPagarManual
        '
        Me.biPagarManual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biPagarManual.Image = Global.SIGECOM.My.Resources.Resources.ctasPagar
        Me.biPagarManual.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biPagarManual.Name = "biPagarManual"
        Me.biPagarManual.Size = New System.Drawing.Size(28, 28)
        Me.biPagarManual.Text = "Cancelar pago manualmente el documento"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'biConsulEstados
        '
        Me.biConsulEstados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biConsulEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.biConsulEstados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biConsulEstados.Name = "biConsulEstados"
        Me.biConsulEstados.Size = New System.Drawing.Size(28, 28)
        Me.biConsulEstados.Text = "Consultar Estados"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 578)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(1004, 20)
        Me.ssBarra.TabIndex = 171
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
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
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(0, 97)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(1004, 401)
        Me.dgvDatos.TabIndex = 203
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtAnio
        '
        Me.txtAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnio.Location = New System.Drawing.Point(7, 29)
        Me.txtAnio.Maximum = 2059
        Me.txtAnio.Minimum = 2006
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(51, 20)
        Me.txtAnio.TabIndex = 1
        Me.txtAnio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtAnio.Value = 2006
        Me.txtAnio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 207
        Me.Label1.Text = "Año"
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(65, 29)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(117, 20)
        Me.cmbMes.TabIndex = 2
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(114, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 208
        Me.Label2.Text = "Mes"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Window
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(189, 30)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(254, 20)
        Me.txtProveedor.TabIndex = 3
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(325, 10)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 213
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'chkProveedor
        '
        Me.chkProveedor.AutoSize = True
        Me.chkProveedor.Checked = True
        Me.chkProveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkProveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkProveedor.Location = New System.Drawing.Point(304, 12)
        Me.chkProveedor.Name = "chkProveedor"
        Me.chkProveedor.Size = New System.Drawing.Size(15, 14)
        Me.chkProveedor.TabIndex = 212
        Me.chkProveedor.Tag = ""
        Me.chkProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkProveedor.UseVisualStyleBackColor = True
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersona.Location = New System.Drawing.Point(234, 13)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(65, 13)
        Me.lblPersona.TabIndex = 211
        Me.lblPersona.Text = "Proveedor"
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(445, 28)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarProveedor.TabIndex = 210
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(579, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 214
        Me.Label6.Text = "Nro. Comprobante"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(736, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 217
        Me.Label3.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(695, 29)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(128, 20)
        Me.cmbEstado.TabIndex = 6
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(829, 27)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 23)
        Me.btnBuscar.TabIndex = 7
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtIdGasto)
        Me.UiGroupBox1.Controls.Add(Me.txtProveedor)
        Me.UiGroupBox1.Controls.Add(Me.cmbEstado)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.chkProveedor)
        Me.UiGroupBox1.Controls.Add(Me.cmbMes)
        Me.UiGroupBox1.Controls.Add(Me.lblPersona)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarProveedor)
        Me.UiGroupBox1.Controls.Add(Me.txtAnio)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(905, 57)
        Me.UiGroupBox1.TabIndex = 218
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(580, 29)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(108, 20)
        Me.txtNumDoc.TabIndex = 220
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(496, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 219
        Me.Label4.Text = "Nro Gasto"
        '
        'txtIdGasto
        '
        Me.txtIdGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdGasto.Location = New System.Drawing.Point(479, 29)
        Me.txtIdGasto.Name = "txtIdGasto"
        Me.txtIdGasto.Numeric = True
        Me.txtIdGasto.Size = New System.Drawing.Size(95, 20)
        Me.txtIdGasto.TabIndex = 4
        Me.txtIdGasto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.txtSaldoDol)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.txtSaldoSol)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtVencidoDol)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtVencidoSol)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.txtPorVencerDol)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.txtPorVencerSol)
        Me.UiGroupBox2.Controls.Add(Me.Label12)
        Me.UiGroupBox2.Controls.Add(Me.Label13)
        Me.UiGroupBox2.Controls.Add(Me.Label14)
        Me.UiGroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox2.Location = New System.Drawing.Point(0, 504)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(1004, 74)
        Me.UiGroupBox2.TabIndex = 219
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(623, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Saldo"
        '
        'txtSaldoDol
        '
        Me.txtSaldoDol.DecimalDigits = 2
        Me.txtSaldoDol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtSaldoDol.Location = New System.Drawing.Point(593, 49)
        Me.txtSaldoDol.Name = "txtSaldoDol"
        Me.txtSaldoDol.ReadOnly = True
        Me.txtSaldoDol.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoDol.TabIndex = 20
        Me.txtSaldoDol.Text = "0.00"
        Me.txtSaldoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSaldoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(416, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "+"
        '
        'txtSaldoSol
        '
        Me.txtSaldoSol.DecimalDigits = 2
        Me.txtSaldoSol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtSaldoSol.Location = New System.Drawing.Point(593, 27)
        Me.txtSaldoSol.Name = "txtSaldoSol"
        Me.txtSaldoSol.ReadOnly = True
        Me.txtSaldoSol.Size = New System.Drawing.Size(100, 20)
        Me.txtSaldoSol.TabIndex = 14
        Me.txtSaldoSol.Text = "0.00"
        Me.txtSaldoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSaldoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(262, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "US $"
        '
        'txtVencidoDol
        '
        Me.txtVencidoDol.DecimalDigits = 2
        Me.txtVencidoDol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtVencidoDol.Location = New System.Drawing.Point(446, 49)
        Me.txtVencidoDol.Name = "txtVencidoDol"
        Me.txtVencidoDol.ReadOnly = True
        Me.txtVencidoDol.Size = New System.Drawing.Size(100, 20)
        Me.txtVencidoDol.TabIndex = 18
        Me.txtVencidoDol.Text = "0.00"
        Me.txtVencidoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVencidoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(416, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "+"
        '
        'txtVencidoSol
        '
        Me.txtVencidoSol.DecimalDigits = 2
        Me.txtVencidoSol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtVencidoSol.Location = New System.Drawing.Point(446, 27)
        Me.txtVencidoSol.Name = "txtVencidoSol"
        Me.txtVencidoSol.ReadOnly = True
        Me.txtVencidoSol.Size = New System.Drawing.Size(100, 20)
        Me.txtVencidoSol.TabIndex = 12
        Me.txtVencidoSol.Text = "0.00"
        Me.txtVencidoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVencidoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(262, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "S/."
        '
        'txtPorVencerDol
        '
        Me.txtPorVencerDol.DecimalDigits = 2
        Me.txtPorVencerDol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtPorVencerDol.Location = New System.Drawing.Point(300, 49)
        Me.txtPorVencerDol.Name = "txtPorVencerDol"
        Me.txtPorVencerDol.ReadOnly = True
        Me.txtPorVencerDol.Size = New System.Drawing.Size(100, 20)
        Me.txtPorVencerDol.TabIndex = 16
        Me.txtPorVencerDol.Text = "0.00"
        Me.txtPorVencerDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPorVencerDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(561, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "="
        '
        'txtPorVencerSol
        '
        Me.txtPorVencerSol.DecimalDigits = 2
        Me.txtPorVencerSol.DisabledForeColor = System.Drawing.Color.Black
        Me.txtPorVencerSol.Location = New System.Drawing.Point(300, 27)
        Me.txtPorVencerSol.Name = "txtPorVencerSol"
        Me.txtPorVencerSol.ReadOnly = True
        Me.txtPorVencerSol.Size = New System.Drawing.Size(100, 20)
        Me.txtPorVencerSol.TabIndex = 10
        Me.txtPorVencerSol.Text = "0.00"
        Me.txtPorVencerSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPorVencerSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(561, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "="
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(315, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Por Vencer"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(471, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Vencido"
        '
        'frmCuentasPorPagar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1004, 598)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCuentasPorPagar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas Por Pagar"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtAnio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chkProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIdGasto As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents miDescargarXml As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDescargarPdf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSaldoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSaldoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtVencidoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtVencidoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPorVencerDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPorVencerSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents biConsulEstados As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents miConsultarEstados As ToolStripMenuItem
    Friend WithEvents miCancelacionManual As ToolStripMenuItem
    Friend WithEvents biPagarManual As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
End Class
