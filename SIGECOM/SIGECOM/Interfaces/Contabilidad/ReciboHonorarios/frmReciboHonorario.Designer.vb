<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReciboHonorario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReciboHonorario))
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator101 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator102 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator104 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.gbCabecera = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtMesRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbAnulado = New System.Windows.Forms.CheckBox()
        Me.gbIgv = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbAfectoIR = New System.Windows.Forms.CheckBox()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerieDoc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLimpiarPdf = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarXml = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarPdf = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPdfFE = New System.Windows.Forms.TextBox()
        Me.btnBuscarXml = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtXmlFE = New System.Windows.Forms.TextBox()
        Me.txtFecPago = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnModificarGlosa = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtIR = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.txtTotalNetoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalIRDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalNeto = New System.Windows.Forms.TextBox()
        Me.lbltotalIR = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.TextBox()
        Me.txtTotalNetoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalIRSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gbCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCabecera.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.gbIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbIgv.SuspendLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator101, Me.biEditar, Me.ToolStripSeparator102, Me.biGrabar, Me.ToolStripSeparator104, Me.biDeshacer, Me.ToolStripSeparator2, Me.biSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(845, 31)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator101
        '
        Me.ToolStripSeparator101.Name = "ToolStripSeparator101"
        Me.ToolStripSeparator101.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar"
        '
        'ToolStripSeparator102
        '
        Me.ToolStripSeparator102.Name = "ToolStripSeparator102"
        Me.ToolStripSeparator102.Size = New System.Drawing.Size(6, 31)
        '
        'biGrabar
        '
        Me.biGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGrabar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGrabar.Name = "biGrabar"
        Me.biGrabar.Size = New System.Drawing.Size(28, 28)
        Me.biGrabar.Text = "Grabar"
        '
        'ToolStripSeparator104
        '
        Me.ToolStripSeparator104.Name = "ToolStripSeparator104"
        Me.ToolStripSeparator104.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
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
        'gbCabecera
        '
        Me.gbCabecera.Controls.Add(Me.txtPeriodo)
        Me.gbCabecera.Controls.Add(Me.Label7)
        Me.gbCabecera.Controls.Add(Me.txtNumRegistro)
        Me.gbCabecera.Controls.Add(Me.txtMesRegistro)
        Me.gbCabecera.Controls.Add(Me.Label8)
        Me.gbCabecera.Controls.Add(Me.Label11)
        Me.gbCabecera.Controls.Add(Me.UiGroupBox3)
        Me.gbCabecera.Controls.Add(Me.gbIgv)
        Me.gbCabecera.Controls.Add(Me.txtNumDoc)
        Me.gbCabecera.Controls.Add(Me.Label4)
        Me.gbCabecera.Controls.Add(Me.txtSerieDoc)
        Me.gbCabecera.Controls.Add(Me.Label1)
        Me.gbCabecera.Controls.Add(Me.btnLimpiarPdf)
        Me.gbCabecera.Controls.Add(Me.btnLimpiarXml)
        Me.gbCabecera.Controls.Add(Me.btnBuscarPdf)
        Me.gbCabecera.Controls.Add(Me.Label26)
        Me.gbCabecera.Controls.Add(Me.txtPdfFE)
        Me.gbCabecera.Controls.Add(Me.btnBuscarXml)
        Me.gbCabecera.Controls.Add(Me.Label14)
        Me.gbCabecera.Controls.Add(Me.txtXmlFE)
        Me.gbCabecera.Controls.Add(Me.txtFecPago)
        Me.gbCabecera.Controls.Add(Me.Label6)
        Me.gbCabecera.Controls.Add(Me.txtFecha)
        Me.gbCabecera.Controls.Add(Me.Label5)
        Me.gbCabecera.Controls.Add(Me.Label9)
        Me.gbCabecera.Controls.Add(Me.Label12)
        Me.gbCabecera.Controls.Add(Me.btnModificarGlosa)
        Me.gbCabecera.Controls.Add(Me.Label2)
        Me.gbCabecera.Controls.Add(Me.txtGlosa)
        Me.gbCabecera.Controls.Add(Me.Label21)
        Me.gbCabecera.Controls.Add(Me.txtFecDoc)
        Me.gbCabecera.Controls.Add(Me.btnBuscarProveedor)
        Me.gbCabecera.Controls.Add(Me.lblFecha)
        Me.gbCabecera.Controls.Add(Me.txtProveedor)
        Me.gbCabecera.Controls.Add(Me.txtTipoCambio)
        Me.gbCabecera.Controls.Add(Me.txtIR)
        Me.gbCabecera.Controls.Add(Me.cmbCodMon)
        Me.gbCabecera.Controls.Add(Me.Label10)
        Me.gbCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbCabecera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCabecera.Location = New System.Drawing.Point(0, 31)
        Me.gbCabecera.Name = "gbCabecera"
        Me.gbCabecera.Size = New System.Drawing.Size(845, 164)
        Me.gbCabecera.TabIndex = 2
        Me.gbCabecera.Text = " [  Cabecera  ] "
        Me.gbCabecera.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(292, 19)
        Me.txtPeriodo.Maximum = 2059
        Me.txtPeriodo.Minimum = 2006
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
        Me.txtPeriodo.TabIndex = 322
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.Value = 2006
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(237, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 323
        Me.Label7.Text = "Periodo"
        '
        'txtNumRegistro
        '
        Me.txtNumRegistro.Location = New System.Drawing.Point(524, 19)
        Me.txtNumRegistro.MaxLength = 6
        Me.txtNumRegistro.Name = "txtNumRegistro"
        Me.txtNumRegistro.Numeric = True
        Me.txtNumRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumRegistro.Size = New System.Drawing.Size(59, 20)
        Me.txtNumRegistro.TabIndex = 1
        '
        'txtMesRegistro
        '
        Me.txtMesRegistro.Location = New System.Drawing.Point(479, 19)
        Me.txtMesRegistro.MaxLength = 2
        Me.txtMesRegistro.Name = "txtMesRegistro"
        Me.txtMesRegistro.Numeric = True
        Me.txtMesRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMesRegistro.Size = New System.Drawing.Size(30, 20)
        Me.txtMesRegistro.TabIndex = 324
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(511, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 321
        Me.Label8.Text = "-"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(398, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 13)
        Me.Label11.TabIndex = 320
        Me.Label11.Text = "Nº Registro :"
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.Label3)
        Me.UiGroupBox3.Controls.Add(Me.cbAnulado)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(653, 123)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(169, 28)
        Me.UiGroupBox3.TabIndex = 318
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 319
        Me.Label3.Text = "Estado :"
        '
        'cbAnulado
        '
        Me.cbAnulado.AutoSize = True
        Me.cbAnulado.BackColor = System.Drawing.Color.Transparent
        Me.cbAnulado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAnulado.ForeColor = System.Drawing.Color.Black
        Me.cbAnulado.Location = New System.Drawing.Point(66, 9)
        Me.cbAnulado.Name = "cbAnulado"
        Me.cbAnulado.Size = New System.Drawing.Size(65, 17)
        Me.cbAnulado.TabIndex = 12
        Me.cbAnulado.Text = "Anulado"
        Me.cbAnulado.UseVisualStyleBackColor = False
        '
        'gbIgv
        '
        Me.gbIgv.Controls.Add(Me.cbAfectoIR)
        Me.gbIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbIgv.Location = New System.Drawing.Point(653, 93)
        Me.gbIgv.Name = "gbIgv"
        Me.gbIgv.Size = New System.Drawing.Size(169, 28)
        Me.gbIgv.TabIndex = 317
        Me.gbIgv.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cbAfectoIR
        '
        Me.cbAfectoIR.AutoSize = True
        Me.cbAfectoIR.BackColor = System.Drawing.Color.Transparent
        Me.cbAfectoIR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAfectoIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAfectoIR.ForeColor = System.Drawing.Color.Black
        Me.cbAfectoIR.Location = New System.Drawing.Point(44, 10)
        Me.cbAfectoIR.Name = "cbAfectoIR"
        Me.cbAfectoIR.Size = New System.Drawing.Size(71, 17)
        Me.cbAfectoIR.TabIndex = 11
        Me.cbAfectoIR.Text = "Afecto IR"
        Me.cbAfectoIR.UseVisualStyleBackColor = False
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(214, 49)
        Me.txtNumDoc.MaxLength = 4
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(72, 20)
        Me.txtNumDoc.TabIndex = 3
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(131, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 316
        Me.Label4.Text = "N° Documento :"
        '
        'txtSerieDoc
        '
        Me.txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtSerieDoc.Location = New System.Drawing.Point(68, 49)
        Me.txtSerieDoc.MaxLength = 4
        Me.txtSerieDoc.Name = "txtSerieDoc"
        Me.txtSerieDoc.Size = New System.Drawing.Size(53, 20)
        Me.txtSerieDoc.TabIndex = 2
        Me.txtSerieDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 314
        Me.Label1.Text = "Serie Doc."
        '
        'btnLimpiarPdf
        '
        Me.btnLimpiarPdf.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarPdf.Location = New System.Drawing.Point(593, 92)
        Me.btnLimpiarPdf.Name = "btnLimpiarPdf"
        Me.btnLimpiarPdf.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarPdf.TabIndex = 312
        Me.btnLimpiarPdf.TabStop = False
        '
        'btnLimpiarXml
        '
        Me.btnLimpiarXml.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarXml.Location = New System.Drawing.Point(273, 92)
        Me.btnLimpiarXml.Name = "btnLimpiarXml"
        Me.btnLimpiarXml.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarXml.TabIndex = 311
        Me.btnLimpiarXml.TabStop = False
        '
        'btnBuscarPdf
        '
        Me.btnBuscarPdf.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPdf.Location = New System.Drawing.Point(567, 92)
        Me.btnBuscarPdf.Name = "btnBuscarPdf"
        Me.btnBuscarPdf.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPdf.TabIndex = 310
        Me.btnBuscarPdf.TabStop = False
        Me.btnBuscarPdf.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(333, 96)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 13)
        Me.Label26.TabIndex = 309
        Me.Label26.Text = "PDF (F.E.)"
        '
        'txtPdfFE
        '
        Me.txtPdfFE.BackColor = System.Drawing.SystemColors.Control
        Me.txtPdfFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPdfFE.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPdfFE.Location = New System.Drawing.Point(400, 93)
        Me.txtPdfFE.MaxLength = 10
        Me.txtPdfFE.Name = "txtPdfFE"
        Me.txtPdfFE.ReadOnly = True
        Me.txtPdfFE.Size = New System.Drawing.Size(165, 20)
        Me.txtPdfFE.TabIndex = 308
        '
        'btnBuscarXml
        '
        Me.btnBuscarXml.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarXml.Location = New System.Drawing.Point(247, 92)
        Me.btnBuscarXml.Name = "btnBuscarXml"
        Me.btnBuscarXml.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarXml.TabIndex = 307
        Me.btnBuscarXml.TabStop = False
        Me.btnBuscarXml.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 306
        Me.Label14.Text = "XML (F.E.)"
        '
        'txtXmlFE
        '
        Me.txtXmlFE.BackColor = System.Drawing.SystemColors.Control
        Me.txtXmlFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXmlFE.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtXmlFE.Location = New System.Drawing.Point(79, 93)
        Me.txtXmlFE.MaxLength = 10
        Me.txtXmlFE.Name = "txtXmlFE"
        Me.txtXmlFE.ReadOnly = True
        Me.txtXmlFE.Size = New System.Drawing.Size(166, 20)
        Me.txtXmlFE.TabIndex = 305
        '
        'txtFecPago
        '
        Me.txtFecPago.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecPago.DropDownCalendar.Name = ""
        Me.txtFecPago.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecPago.Location = New System.Drawing.Point(573, 71)
        Me.txtFecPago.Name = "txtFecPago"
        Me.txtFecPago.NullButtonText = "Ninguno"
        Me.txtFecPago.ReadOnly = True
        Me.txtFecPago.Size = New System.Drawing.Size(92, 20)
        Me.txtFecPago.TabIndex = 10
        Me.txtFecPago.TodayButtonText = "Hoy"
        Me.txtFecPago.Value = New Date(2022, 6, 22, 0, 0, 0, 0)
        Me.txtFecPago.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(510, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 303
        Me.Label6.Text = "Fec. Pago :"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(409, 71)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(92, 20)
        Me.txtFecha.TabIndex = 9
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.Value = New Date(2022, 6, 22, 0, 0, 0, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 301
        Me.Label5.Text = "Fecha :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(647, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Tip.Cam. :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Proveedor :"
        '
        'btnModificarGlosa
        '
        Me.btnModificarGlosa.Image = CType(resources.GetObject("btnModificarGlosa.Image"), System.Drawing.Image)
        Me.btnModificarGlosa.Location = New System.Drawing.Point(611, 116)
        Me.btnModificarGlosa.Name = "btnModificarGlosa"
        Me.btnModificarGlosa.Size = New System.Drawing.Size(25, 22)
        Me.btnModificarGlosa.TabIndex = 31
        Me.btnModificarGlosa.TabStop = False
        Me.btnModificarGlosa.UseVisualStyleBackColor = True
        Me.btnModificarGlosa.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(455, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Moneda :"
        '
        'txtGlosa
        '
        Me.txtGlosa.Location = New System.Drawing.Point(79, 116)
        Me.txtGlosa.MaxLength = 250
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(532, 35)
        Me.txtGlosa.TabIndex = 11
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(5, 119)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "Glosa :"
        '
        'txtFecDoc
        '
        Me.txtFecDoc.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Location = New System.Drawing.Point(358, 49)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.ReadOnly = True
        Me.txtFecDoc.Size = New System.Drawing.Size(92, 20)
        Me.txtFecDoc.TabIndex = 4
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(334, 70)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 7
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(289, 52)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(66, 13)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "Fecha Doc.:"
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(68, 71)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(264, 20)
        Me.txtProveedor.TabIndex = 8
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTipoCambio.Location = New System.Drawing.Point(705, 49)
        Me.txtTipoCambio.MaxLength = 20
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(47, 20)
        Me.txtTipoCambio.TabIndex = 9
        Me.txtTipoCambio.TabStop = False
        '
        'txtIR
        '
        Me.txtIR.Location = New System.Drawing.Point(600, 49)
        Me.txtIR.MaxLength = 12
        Me.txtIR.Name = "txtIR"
        Me.txtIR.Size = New System.Drawing.Size(42, 20)
        Me.txtIR.TabIndex = 6
        Me.txtIR.Text = "0.00"
        Me.txtIR.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'cmbCodMon
        '
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(509, 49)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(58, 20)
        Me.cmbCodMon.TabIndex = 5
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(573, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "IR :"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Controls.Add(Me.dgvDatos)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 195)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(845, 433)
        Me.UiGroupBox1.TabIndex = 5
        Me.UiGroupBox1.Text = "Detalles"
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox2.Controls.Add(Me.TextBox1)
        Me.UiGroupBox2.Controls.Add(Me.TextBox2)
        Me.UiGroupBox2.Controls.Add(Me.TextBox3)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalNetoDol)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalIRDol)
        Me.UiGroupBox2.Controls.Add(Me.txtTotDol)
        Me.UiGroupBox2.Controls.Add(Me.lblTotalNeto)
        Me.UiGroupBox2.Controls.Add(Me.lbltotalIR)
        Me.UiGroupBox2.Controls.Add(Me.lblTotal)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalNetoSol)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalIRSol)
        Me.UiGroupBox2.Controls.Add(Me.txtTotSol)
        Me.UiGroupBox2.Location = New System.Drawing.Point(8, 332)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(820, 73)
        Me.UiGroupBox2.TabIndex = 9
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox1.Location = New System.Drawing.Point(451, 49)
        Me.TextBox1.MaxLength = 20
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(135, 20)
        Me.TextBox1.TabIndex = 13
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "MONTO NETO DOL"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox2.Location = New System.Drawing.Point(451, 30)
        Me.TextBox2.MaxLength = 20
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(135, 20)
        Me.TextBox2.TabIndex = 12
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "MONTO IR DOL"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox3.Location = New System.Drawing.Point(451, 11)
        Me.TextBox3.MaxLength = 20
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(135, 20)
        Me.TextBox3.TabIndex = 11
        Me.TextBox3.Text = "MONTO TOTAL DOL"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNetoDol
        '
        Me.txtTotalNetoDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNetoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNetoDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNetoDol.Location = New System.Drawing.Point(585, 49)
        Me.txtTotalNetoDol.MaxLength = 5
        Me.txtTotalNetoDol.Name = "txtTotalNetoDol"
        Me.txtTotalNetoDol.ReadOnly = True
        Me.txtTotalNetoDol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalNetoDol.TabIndex = 10
        Me.txtTotalNetoDol.TabStop = False
        Me.txtTotalNetoDol.Text = "0.00"
        Me.txtTotalNetoDol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNetoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNetoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalIRDol
        '
        Me.txtTotalIRDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalIRDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIRDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalIRDol.Location = New System.Drawing.Point(585, 30)
        Me.txtTotalIRDol.MaxLength = 5
        Me.txtTotalIRDol.Name = "txtTotalIRDol"
        Me.txtTotalIRDol.ReadOnly = True
        Me.txtTotalIRDol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalIRDol.TabIndex = 9
        Me.txtTotalIRDol.TabStop = False
        Me.txtTotalIRDol.Text = "0.00"
        Me.txtTotalIRDol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalIRDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIRDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotDol
        '
        Me.txtTotDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotDol.Location = New System.Drawing.Point(585, 11)
        Me.txtTotDol.MaxLength = 5
        Me.txtTotDol.Name = "txtTotDol"
        Me.txtTotDol.ReadOnly = True
        Me.txtTotDol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotDol.TabIndex = 8
        Me.txtTotDol.TabStop = False
        Me.txtTotDol.Text = "0.00"
        Me.txtTotDol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalNeto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalNeto.Location = New System.Drawing.Point(172, 49)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(135, 20)
        Me.lblTotalNeto.TabIndex = 2
        Me.lblTotalNeto.TabStop = False
        Me.lblTotalNeto.Text = "MONTO NETO SOL"
        Me.lblTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotalIR
        '
        Me.lbltotalIR.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lbltotalIR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lbltotalIR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbltotalIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalIR.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltotalIR.Location = New System.Drawing.Point(172, 30)
        Me.lbltotalIR.MaxLength = 20
        Me.lbltotalIR.Name = "lbltotalIR"
        Me.lbltotalIR.ReadOnly = True
        Me.lbltotalIR.Size = New System.Drawing.Size(135, 20)
        Me.lbltotalIR.TabIndex = 1
        Me.lbltotalIR.TabStop = False
        Me.lbltotalIR.Text = "MONTO IR SOL"
        Me.lbltotalIR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotal.Location = New System.Drawing.Point(172, 11)
        Me.lblTotal.MaxLength = 20
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.ReadOnly = True
        Me.lblTotal.Size = New System.Drawing.Size(135, 20)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "MONTO TOTAL SOL"
        Me.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNetoSol
        '
        Me.txtTotalNetoSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNetoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNetoSol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNetoSol.Location = New System.Drawing.Point(306, 49)
        Me.txtTotalNetoSol.MaxLength = 5
        Me.txtTotalNetoSol.Name = "txtTotalNetoSol"
        Me.txtTotalNetoSol.ReadOnly = True
        Me.txtTotalNetoSol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalNetoSol.TabIndex = 7
        Me.txtTotalNetoSol.TabStop = False
        Me.txtTotalNetoSol.Text = "0.00"
        Me.txtTotalNetoSol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalNetoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNetoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalIRSol
        '
        Me.txtTotalIRSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalIRSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIRSol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalIRSol.Location = New System.Drawing.Point(306, 30)
        Me.txtTotalIRSol.MaxLength = 5
        Me.txtTotalIRSol.Name = "txtTotalIRSol"
        Me.txtTotalIRSol.ReadOnly = True
        Me.txtTotalIRSol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalIRSol.TabIndex = 6
        Me.txtTotalIRSol.TabStop = False
        Me.txtTotalIRSol.Text = "0.00"
        Me.txtTotalIRSol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalIRSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIRSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotSol
        '
        Me.txtTotSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotSol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotSol.Location = New System.Drawing.Point(306, 11)
        Me.txtTotSol.MaxLength = 5
        Me.txtTotSol.Name = "txtTotSol"
        Me.txtTotSol.ReadOnly = True
        Me.txtTotSol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotSol.TabIndex = 5
        Me.txtTotSol.TabStop = False
        Me.txtTotSol.Text = "0.00"
        Me.txtTotSol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(4, 19)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(829, 307)
        Me.dgvDatos.TabIndex = 8
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Modificar"
        Me.miMostrar.ToolTipText = "Editar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
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
        Me.miActualizar.ToolTipText = "Refrescar Detalle"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 608)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(845, 20)
        Me.ssBarra.TabIndex = 6
        '
        'sslError
        '
        Me.sslError.AutoSize = False
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
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmReciboHonorario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(845, 628)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gbCabecera)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReciboHonorario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibo por Honorario"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gbCabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCabecera.ResumeLayout(False)
        Me.gbCabecera.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.gbIgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbIgv.ResumeLayout(False)
        Me.gbIgv.PerformLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator101 As ToolStripSeparator
    Friend WithEvents biEditar As ToolStripButton
    Friend WithEvents ToolStripSeparator102 As ToolStripSeparator
    Friend WithEvents biGrabar As ToolStripButton
    Friend WithEvents ToolStripSeparator104 As ToolStripSeparator
    Friend WithEvents biDeshacer As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents biSalir As ToolStripButton
    Friend WithEvents gbCabecera As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbAfectoIR As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnModificarGlosa As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtGlosa As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnBuscarProveedor As Button
    Friend WithEvents lblFecha As Label
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents txtTipoCambio As TextBox
    Friend WithEvents txtIR As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label10 As Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ssBarra As StatusStrip
    Friend WithEvents sslError As ToolStripStatusLabel
    Friend WithEvents sslTotal As ToolStripStatusLabel
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalNetoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalIRDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalNeto As TextBox
    Friend WithEvents lbltotalIR As TextBox
    Friend WithEvents lblTotal As TextBox
    Friend WithEvents txtTotalNetoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalIRSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtFecPago As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label5 As Label
    Friend WithEvents cbAnulado As CheckBox
    Friend WithEvents btnLimpiarPdf As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarXml As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscarPdf As Button
    Friend WithEvents Label26 As Label
    Friend WithEvents txtPdfFE As TextBox
    Friend WithEvents btnBuscarXml As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents txtXmlFE As TextBox
    Friend WithEvents txtNumDoc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSerieDoc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miNuevo As ToolStripMenuItem
    Friend WithEvents miMostrar As ToolStripMenuItem
    Friend WithEvents miEliminar As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents miActualizar As ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbIgv As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNumRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtMesRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
End Class
