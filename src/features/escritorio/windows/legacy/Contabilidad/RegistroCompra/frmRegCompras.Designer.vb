<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegCompras
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim cmbTipoDetraccion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoRef_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCondPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegCompras))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnBuscarRegistro = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSerieDoc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumRef = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSerieRef = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNumGasto = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFechaPagoDetraccion = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtNroPagoDetraccion = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipoDetraccion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbAfectoDetraccion = New System.Windows.Forms.CheckBox()
        Me.txtNumDoc = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.gbReferencia = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCodTipoRef = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtFecDocRef = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cmbTipoRef = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbIgv = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbAfectoIgv = New System.Windows.Forms.CheckBox()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtCodTipoDoc = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.gbEstado = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbAnulado = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.gbProveedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnDescargarPdf = New Janus.Windows.EditControls.UIButton()
        Me.btnDescargarXml = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarPdf = New Janus.Windows.EditControls.UIButton()
        Me.btnLimpiarXml = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscarPdf = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPdfFE = New System.Windows.Forms.TextBox()
        Me.btnBuscarXml = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtXmlFE = New System.Windows.Forms.TextBox()
        Me.btnAgregarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.cmbCondPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.txtTipCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFecVencimiento = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFecEmision = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDuplicar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtDesCuenta = New System.Windows.Forms.TextBox()
        Me.txtNumRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtMesRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblMontoTotalNeto = New System.Windows.Forms.TextBox()
        Me.lblMontoTotalNoAfecto = New System.Windows.Forms.TextBox()
        Me.lblMontoTotalIgv = New System.Windows.Forms.TextBox()
        Me.txtMontoTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoTotalNoAfecto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoTotalIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoTotal = New System.Windows.Forms.TextBox()
        Me.txtMontoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbTipoDetraccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReferencia.SuspendLayout()
        CType(Me.cmbTipoRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbIgv.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        CType(Me.cmbCondPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.biImportar, Me.ToolStripSeparator5, Me.biEditar, Me.ToolStripSeparator8, Me.biEliminar, Me.ToolStripSeparator3, Me.biGuardar, Me.ToolStripSeparator13, Me.biDeshacer, Me.ToolStripSeparator4, Me.biImprimir, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(745, 31)
        Me.ToolStrip.TabIndex = 173
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biImportar
        '
        Me.biImportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImportar.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.biImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImportar.Name = "biImportar"
        Me.biImportar.Size = New System.Drawing.Size(28, 28)
        Me.biImportar.Text = "Importar Documento"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Cabecera"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar Registro"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Reportes"
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
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 588)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(745, 20)
        Me.ssBarra.TabIndex = 174
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(470, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(240, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(256, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 175
        Me.Label1.Text = "Nº Registro :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(369, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "-"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(525, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 180
        Me.Label10.Text = "I.G.V."
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIgv.Location = New System.Drawing.Point(567, 35)
        Me.txtIgv.MaxLength = 12
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(60, 20)
        Me.txtIgv.TabIndex = 179
        Me.txtIgv.TabStop = False
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarRegistro
        '
        Me.btnBuscarRegistro.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarRegistro.Location = New System.Drawing.Point(444, 34)
        Me.btnBuscarRegistro.Name = "btnBuscarRegistro"
        Me.btnBuscarRegistro.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarRegistro.TabIndex = 181
        Me.btnBuscarRegistro.TabStop = False
        Me.btnBuscarRegistro.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 182
        Me.Label3.Text = "Documento :"
        '
        'txtSerieDoc
        '
        Me.txtSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieDoc.Location = New System.Drawing.Point(180, 21)
        Me.txtSerieDoc.MaxLength = 4
        Me.txtSerieDoc.Name = "txtSerieDoc"
        Me.txtSerieDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSerieDoc.Size = New System.Drawing.Size(40, 20)
        Me.txtSerieDoc.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(221, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "-"
        '
        'txtNumRef
        '
        Me.txtNumRef.BackColor = System.Drawing.SystemColors.Control
        Me.txtNumRef.Location = New System.Drawing.Point(224, 14)
        Me.txtNumRef.MaxLength = 10
        Me.txtNumRef.Name = "txtNumRef"
        Me.txtNumRef.Size = New System.Drawing.Size(82, 20)
        Me.txtNumRef.TabIndex = 12
        Me.txtNumRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(211, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 192
        Me.Label5.Text = "-"
        '
        'txtSerieRef
        '
        Me.txtSerieRef.BackColor = System.Drawing.SystemColors.Control
        Me.txtSerieRef.Location = New System.Drawing.Point(170, 14)
        Me.txtSerieRef.MaxLength = 4
        Me.txtSerieRef.Name = "txtSerieRef"
        Me.txtSerieRef.Size = New System.Drawing.Size(40, 20)
        Me.txtSerieRef.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 188
        Me.Label6.Text = "Referencia :"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtNumGasto)
        Me.UiGroupBox1.Controls.Add(Me.Label13)
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Controls.Add(Me.gbReferencia)
        Me.UiGroupBox1.Controls.Add(Me.gbIgv)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipoDoc)
        Me.UiGroupBox1.Controls.Add(Me.txtCodTipoDoc)
        Me.UiGroupBox1.Controls.Add(Me.gbEstado)
        Me.UiGroupBox1.Controls.Add(Me.gbProveedor)
        Me.UiGroupBox1.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox1.Controls.Add(Me.Label17)
        Me.UiGroupBox1.Controls.Add(Me.Label16)
        Me.UiGroupBox1.Controls.Add(Me.txtGlosa)
        Me.UiGroupBox1.Controls.Add(Me.txtTipCambio)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.txtFecVencimiento)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.txtSerieDoc)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtFecEmision)
        Me.UiGroupBox1.Controls.Add(Me.lblFecha)
        Me.UiGroupBox1.Controls.Add(Me.txtFecha)
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 57)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(731, 240)
        Me.UiGroupBox1.TabIndex = 12
        Me.UiGroupBox1.Text = "DATOS DE REGISTRO"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNumGasto
        '
        Me.txtNumGasto.BackColor = System.Drawing.SystemColors.Control
        Me.txtNumGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumGasto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumGasto.Location = New System.Drawing.Point(454, 207)
        Me.txtNumGasto.MaxLength = 0
        Me.txtNumGasto.Name = "txtNumGasto"
        Me.txtNumGasto.ReadOnly = True
        Me.txtNumGasto.Size = New System.Drawing.Size(51, 20)
        Me.txtNumGasto.TabIndex = 300
        Me.txtNumGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(387, 210)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 13)
        Me.Label13.TabIndex = 301
        Me.Label13.Text = "N° Gasto :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtFechaPagoDetraccion)
        Me.UiGroupBox2.Controls.Add(Me.txtNroPagoDetraccion)
        Me.UiGroupBox2.Controls.Add(Me.Label23)
        Me.UiGroupBox2.Controls.Add(Me.Label25)
        Me.UiGroupBox2.Controls.Add(Me.Label19)
        Me.UiGroupBox2.Controls.Add(Me.cmbTipoDetraccion)
        Me.UiGroupBox2.Controls.Add(Me.cbAfectoDetraccion)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(8, 173)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(351, 62)
        Me.UiGroupBox2.TabIndex = 248
        Me.UiGroupBox2.Text = "Detracción"
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFechaPagoDetraccion
        '
        Me.txtFechaPagoDetraccion.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFechaPagoDetraccion.DropDownCalendar.Name = ""
        Me.txtFechaPagoDetraccion.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaPagoDetraccion.IsNullDate = True
        Me.txtFechaPagoDetraccion.Location = New System.Drawing.Point(254, 37)
        Me.txtFechaPagoDetraccion.Name = "txtFechaPagoDetraccion"
        Me.txtFechaPagoDetraccion.NullButtonText = "Ninguno"
        Me.txtFechaPagoDetraccion.ReadOnly = True
        Me.txtFechaPagoDetraccion.ShowNullButton = True
        Me.txtFechaPagoDetraccion.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaPagoDetraccion.TabIndex = 301
        Me.txtFechaPagoDetraccion.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtNroPagoDetraccion
        '
        Me.txtNroPagoDetraccion.BackColor = System.Drawing.SystemColors.Control
        Me.txtNroPagoDetraccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroPagoDetraccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroPagoDetraccion.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNroPagoDetraccion.Location = New System.Drawing.Point(67, 37)
        Me.txtNroPagoDetraccion.MaxLength = 0
        Me.txtNroPagoDetraccion.Name = "txtNroPagoDetraccion"
        Me.txtNroPagoDetraccion.ReadOnly = True
        Me.txtNroPagoDetraccion.Size = New System.Drawing.Size(106, 20)
        Me.txtNroPagoDetraccion.TabIndex = 297
        Me.txtNroPagoDetraccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 41)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 13)
        Me.Label23.TabIndex = 299
        Me.Label23.Text = "Nro Pago"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(177, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(75, 13)
        Me.Label25.TabIndex = 300
        Me.Label25.Text = "Fecha Pago"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(160, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 296
        Me.Label19.Text = "Tipo(%)"
        '
        'cmbTipoDetraccion
        '
        Me.cmbTipoDetraccion.BackColor = System.Drawing.SystemColors.Control
        Me.cmbTipoDetraccion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDetraccion_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDetraccion_DesignTimeLayout.LayoutString")
        Me.cmbTipoDetraccion.DesignTimeLayout = cmbTipoDetraccion_DesignTimeLayout
        Me.cmbTipoDetraccion.Location = New System.Drawing.Point(210, 14)
        Me.cmbTipoDetraccion.Name = "cmbTipoDetraccion"
        Me.cmbTipoDetraccion.ReadOnly = True
        Me.cmbTipoDetraccion.SelectedIndex = -1
        Me.cmbTipoDetraccion.SelectedItem = Nothing
        Me.cmbTipoDetraccion.Size = New System.Drawing.Size(66, 20)
        Me.cmbTipoDetraccion.TabIndex = 295
        Me.cmbTipoDetraccion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbAfectoDetraccion
        '
        Me.cbAfectoDetraccion.AutoSize = True
        Me.cbAfectoDetraccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbAfectoDetraccion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAfectoDetraccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbAfectoDetraccion.ForeColor = System.Drawing.Color.Black
        Me.cbAfectoDetraccion.Location = New System.Drawing.Point(6, 15)
        Me.cbAfectoDetraccion.Name = "cbAfectoDetraccion"
        Me.cbAfectoDetraccion.Size = New System.Drawing.Size(147, 17)
        Me.cbAfectoDetraccion.TabIndex = 294
        Me.cbAfectoDetraccion.Text = "Afecto a Detracción?"
        Me.cbAfectoDetraccion.UseVisualStyleBackColor = False
        '
        'txtNumDoc
        '
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Location = New System.Drawing.Point(234, 21)
        Me.txtNumDoc.MaxLength = 10
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumDoc.Size = New System.Drawing.Size(85, 20)
        Me.txtNumDoc.TabIndex = 7
        '
        'gbReferencia
        '
        Me.gbReferencia.Controls.Add(Me.txtCodTipoRef)
        Me.gbReferencia.Controls.Add(Me.txtFecDocRef)
        Me.gbReferencia.Controls.Add(Me.cmbTipoRef)
        Me.gbReferencia.Controls.Add(Me.txtNumRef)
        Me.gbReferencia.Controls.Add(Me.Label5)
        Me.gbReferencia.Controls.Add(Me.txtSerieRef)
        Me.gbReferencia.Controls.Add(Me.Label6)
        Me.gbReferencia.Location = New System.Drawing.Point(325, 7)
        Me.gbReferencia.Name = "gbReferencia"
        Me.gbReferencia.Size = New System.Drawing.Size(399, 40)
        Me.gbReferencia.TabIndex = 8
        Me.gbReferencia.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCodTipoRef
        '
        Me.txtCodTipoRef.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodTipoRef.Location = New System.Drawing.Point(82, 14)
        Me.txtCodTipoRef.MaxLength = 2
        Me.txtCodTipoRef.Name = "txtCodTipoRef"
        Me.txtCodTipoRef.Numeric = True
        Me.txtCodTipoRef.ReadOnly = True
        Me.txtCodTipoRef.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCodTipoRef.Size = New System.Drawing.Size(32, 20)
        Me.txtCodTipoRef.TabIndex = 9
        '
        'txtFecDocRef
        '
        Me.txtFecDocRef.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecDocRef.DropDownCalendar.Name = ""
        Me.txtFecDocRef.DropDownCalendar.Visible = False
        Me.txtFecDocRef.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDocRef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecDocRef.IsNullDate = True
        Me.txtFecDocRef.Location = New System.Drawing.Point(310, 14)
        Me.txtFecDocRef.Name = "txtFecDocRef"
        Me.txtFecDocRef.NullButtonText = "Ninguno"
        Me.txtFecDocRef.ReadOnly = True
        Me.txtFecDocRef.Size = New System.Drawing.Size(82, 20)
        Me.txtFecDocRef.TabIndex = 13
        Me.txtFecDocRef.TodayButtonText = "Hoy"
        Me.txtFecDocRef.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbTipoRef
        '
        Me.cmbTipoRef.BackColor = System.Drawing.SystemColors.Control
        Me.cmbTipoRef.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoRef_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoRef_DesignTimeLayout.LayoutString")
        Me.cmbTipoRef.DesignTimeLayout = cmbTipoRef_DesignTimeLayout
        Me.cmbTipoRef.Location = New System.Drawing.Point(117, 14)
        Me.cmbTipoRef.Name = "cmbTipoRef"
        Me.cmbTipoRef.ReadOnly = True
        Me.cmbTipoRef.SelectedIndex = -1
        Me.cmbTipoRef.SelectedItem = Nothing
        Me.cmbTipoRef.Size = New System.Drawing.Size(50, 20)
        Me.cmbTipoRef.TabIndex = 10
        Me.cmbTipoRef.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbTipoRef.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbIgv
        '
        Me.gbIgv.Controls.Add(Me.cbAfectoIgv)
        Me.gbIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbIgv.Location = New System.Drawing.Point(540, 174)
        Me.gbIgv.Name = "gbIgv"
        Me.gbIgv.Size = New System.Drawing.Size(169, 28)
        Me.gbIgv.TabIndex = 26
        Me.gbIgv.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cbAfectoIgv
        '
        Me.cbAfectoIgv.AutoSize = True
        Me.cbAfectoIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAfectoIgv.Location = New System.Drawing.Point(44, 10)
        Me.cbAfectoIgv.Name = "cbAfectoIgv"
        Me.cbAfectoIgv.Size = New System.Drawing.Size(111, 17)
        Me.cbAfectoIgv.TabIndex = 27
        Me.cbAfectoIgv.Text = "Afecto a I.G.V."
        Me.cbAfectoIgv.UseVisualStyleBackColor = True
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Location = New System.Drawing.Point(124, 21)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(50, 20)
        Me.cmbTipoDoc.TabIndex = 5
        Me.cmbTipoDoc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtCodTipoDoc
        '
        Me.txtCodTipoDoc.Location = New System.Drawing.Point(86, 21)
        Me.txtCodTipoDoc.MaxLength = 2
        Me.txtCodTipoDoc.Name = "txtCodTipoDoc"
        Me.txtCodTipoDoc.Numeric = True
        Me.txtCodTipoDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCodTipoDoc.Size = New System.Drawing.Size(32, 20)
        Me.txtCodTipoDoc.TabIndex = 4
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.rbAnulado)
        Me.gbEstado.Controls.Add(Me.Label18)
        Me.gbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEstado.Location = New System.Drawing.Point(540, 199)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(170, 29)
        Me.gbEstado.TabIndex = 23
        Me.gbEstado.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'rbAnulado
        '
        Me.rbAnulado.AutoSize = True
        Me.rbAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAnulado.Location = New System.Drawing.Point(81, 10)
        Me.rbAnulado.Name = "rbAnulado"
        Me.rbAnulado.Size = New System.Drawing.Size(72, 17)
        Me.rbAnulado.TabIndex = 206
        Me.rbAnulado.Text = "Anulado"
        Me.rbAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbAnulado.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(19, 11)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 196
        Me.Label18.Text = "Estado :"
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.btnDescargarPdf)
        Me.gbProveedor.Controls.Add(Me.btnDescargarXml)
        Me.gbProveedor.Controls.Add(Me.btnLimpiarPdf)
        Me.gbProveedor.Controls.Add(Me.btnLimpiarXml)
        Me.gbProveedor.Controls.Add(Me.btnBuscarPdf)
        Me.gbProveedor.Controls.Add(Me.Label26)
        Me.gbProveedor.Controls.Add(Me.txtPdfFE)
        Me.gbProveedor.Controls.Add(Me.btnBuscarXml)
        Me.gbProveedor.Controls.Add(Me.Label11)
        Me.gbProveedor.Controls.Add(Me.txtXmlFE)
        Me.gbProveedor.Controls.Add(Me.btnAgregarProveedor)
        Me.gbProveedor.Controls.Add(Me.cmbCondPago)
        Me.gbProveedor.Controls.Add(Me.Label12)
        Me.gbProveedor.Controls.Add(Me.btnBuscarProveedor)
        Me.gbProveedor.Controls.Add(Me.txtProveedor)
        Me.gbProveedor.Controls.Add(Me.Label8)
        Me.gbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProveedor.Location = New System.Drawing.Point(8, 46)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(716, 63)
        Me.gbProveedor.TabIndex = 14
        Me.gbProveedor.Text = "PROVEEDOR"
        Me.gbProveedor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnDescargarPdf
        '
        Me.btnDescargarPdf.Image = CType(resources.GetObject("btnDescargarPdf.Image"), System.Drawing.Image)
        Me.btnDescargarPdf.Location = New System.Drawing.Point(683, 39)
        Me.btnDescargarPdf.Name = "btnDescargarPdf"
        Me.btnDescargarPdf.Size = New System.Drawing.Size(25, 22)
        Me.btnDescargarPdf.TabIndex = 257
        Me.btnDescargarPdf.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnDescargarPdf, "Descargar Pdf")
        '
        'btnDescargarXml
        '
        Me.btnDescargarXml.Image = CType(resources.GetObject("btnDescargarXml.Image"), System.Drawing.Image)
        Me.btnDescargarXml.Location = New System.Drawing.Point(317, 38)
        Me.btnDescargarXml.Name = "btnDescargarXml"
        Me.btnDescargarXml.Size = New System.Drawing.Size(25, 22)
        Me.btnDescargarXml.TabIndex = 256
        Me.btnDescargarXml.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnDescargarXml, "Descargar Xml")
        '
        'btnLimpiarPdf
        '
        Me.btnLimpiarPdf.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarPdf.Location = New System.Drawing.Point(656, 39)
        Me.btnLimpiarPdf.Name = "btnLimpiarPdf"
        Me.btnLimpiarPdf.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarPdf.TabIndex = 255
        Me.btnLimpiarPdf.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnLimpiarPdf, "Limpiar Pdf")
        '
        'btnLimpiarXml
        '
        Me.btnLimpiarXml.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.btnLimpiarXml.Location = New System.Drawing.Point(290, 38)
        Me.btnLimpiarXml.Name = "btnLimpiarXml"
        Me.btnLimpiarXml.Size = New System.Drawing.Size(25, 22)
        Me.btnLimpiarXml.TabIndex = 254
        Me.btnLimpiarXml.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnLimpiarXml, "Limpiar Xml")
        '
        'btnBuscarPdf
        '
        Me.btnBuscarPdf.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPdf.Location = New System.Drawing.Point(627, 39)
        Me.btnBuscarPdf.Name = "btnBuscarPdf"
        Me.btnBuscarPdf.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPdf.TabIndex = 210
        Me.btnBuscarPdf.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnBuscarPdf, "Buscar Pdf")
        Me.btnBuscarPdf.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(376, 42)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(66, 13)
        Me.Label26.TabIndex = 209
        Me.Label26.Text = "PDF (F.E.)"
        '
        'txtPdfFE
        '
        Me.txtPdfFE.BackColor = System.Drawing.SystemColors.Control
        Me.txtPdfFE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPdfFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPdfFE.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPdfFE.Location = New System.Drawing.Point(447, 39)
        Me.txtPdfFE.MaxLength = 10
        Me.txtPdfFE.Name = "txtPdfFE"
        Me.txtPdfFE.ReadOnly = True
        Me.txtPdfFE.Size = New System.Drawing.Size(175, 20)
        Me.txtPdfFE.TabIndex = 208
        Me.txtPdfFE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarXml
        '
        Me.btnBuscarXml.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarXml.Location = New System.Drawing.Point(259, 37)
        Me.btnBuscarXml.Name = "btnBuscarXml"
        Me.btnBuscarXml.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarXml.TabIndex = 207
        Me.btnBuscarXml.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnBuscarXml, "Buscar Xml")
        Me.btnBuscarXml.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 206
        Me.Label11.Text = "XML (F.E.)"
        '
        'txtXmlFE
        '
        Me.txtXmlFE.BackColor = System.Drawing.SystemColors.Control
        Me.txtXmlFE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtXmlFE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXmlFE.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtXmlFE.Location = New System.Drawing.Point(78, 37)
        Me.txtXmlFE.MaxLength = 10
        Me.txtXmlFE.Name = "txtXmlFE"
        Me.txtXmlFE.ReadOnly = True
        Me.txtXmlFE.Size = New System.Drawing.Size(175, 20)
        Me.txtXmlFE.TabIndex = 205
        Me.txtXmlFE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAgregarProveedor
        '
        Me.btnAgregarProveedor.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnAgregarProveedor.Location = New System.Drawing.Point(404, 14)
        Me.btnAgregarProveedor.Name = "btnAgregarProveedor"
        Me.btnAgregarProveedor.Size = New System.Drawing.Size(23, 21)
        Me.btnAgregarProveedor.TabIndex = 204
        Me.btnAgregarProveedor.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnAgregarProveedor, "Agregar Proveedor")
        '
        'cmbCondPago
        '
        Me.cmbCondPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCondPago_DesignTimeLayout.LayoutString = resources.GetString("cmbCondPago_DesignTimeLayout.LayoutString")
        Me.cmbCondPago.DesignTimeLayout = cmbCondPago_DesignTimeLayout
        Me.cmbCondPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCondPago.Location = New System.Drawing.Point(550, 14)
        Me.cmbCondPago.Name = "cmbCondPago"
        Me.cmbCondPago.SelectedIndex = -1
        Me.cmbCondPago.SelectedItem = Nothing
        Me.cmbCondPago.Size = New System.Drawing.Size(160, 19)
        Me.cmbCondPago.TabIndex = 16
        Me.cmbCondPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(455, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 13)
        Me.Label12.TabIndex = 199
        Me.Label12.Text = "Cond de Pago :"
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(379, 14)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(23, 21)
        Me.btnBuscarProveedor.TabIndex = 201
        Me.btnBuscarProveedor.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnBuscarProveedor, "Buscar Proveedor")
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(78, 14)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(299, 20)
        Me.txtProveedor.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 199
        Me.Label8.Text = "Proveedor :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(455, 183)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(50, 20)
        Me.cmbMoneda.TabIndex = 22
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(393, 186)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 205
        Me.Label17.Text = "Moneda :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 148)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 203
        Me.Label16.Text = "Glosa :"
        '
        'txtGlosa
        '
        Me.txtGlosa.Location = New System.Drawing.Point(68, 136)
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtGlosa.Size = New System.Drawing.Size(656, 33)
        Me.txtGlosa.TabIndex = 21
        '
        'txtTipCambio
        '
        Me.txtTipCambio.DecimalDigits = 4
        Me.txtTipCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCambio.Location = New System.Drawing.Point(651, 113)
        Me.txtTipCambio.MaxLength = 10
        Me.txtTipCambio.Name = "txtTipCambio"
        Me.txtTipCambio.Size = New System.Drawing.Size(73, 20)
        Me.txtTipCambio.TabIndex = 20
        Me.txtTipCambio.Text = "0.0000"
        Me.txtTipCambio.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtTipCambio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(576, 117)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 201
        Me.Label15.Text = "T. Cambio :"
        '
        'txtFecVencimiento
        '
        '
        '
        '
        Me.txtFecVencimiento.DropDownCalendar.Name = ""
        Me.txtFecVencimiento.DropDownCalendar.Visible = False
        Me.txtFecVencimiento.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecVencimiento.IsNullDate = True
        Me.txtFecVencimiento.Location = New System.Drawing.Point(465, 113)
        Me.txtFecVencimiento.Name = "txtFecVencimiento"
        Me.txtFecVencimiento.NullButtonText = "Ninguno"
        Me.txtFecVencimiento.Size = New System.Drawing.Size(82, 20)
        Me.txtFecVencimiento.TabIndex = 19
        Me.txtFecVencimiento.TodayButtonText = "Hoy"
        Me.txtFecVencimiento.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(363, 117)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 13)
        Me.Label14.TabIndex = 199
        Me.Label14.Text = "F. Vencimiento :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(176, 117)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 197
        Me.Label9.Text = "F. Emisión :"
        '
        'txtFecEmision
        '
        '
        '
        '
        Me.txtFecEmision.DropDownCalendar.Name = ""
        Me.txtFecEmision.DropDownCalendar.Visible = False
        Me.txtFecEmision.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecEmision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecEmision.IsNullDate = True
        Me.txtFecEmision.Location = New System.Drawing.Point(252, 113)
        Me.txtFecEmision.Name = "txtFecEmision"
        Me.txtFecEmision.NullButtonText = "Ninguno"
        Me.txtFecEmision.Size = New System.Drawing.Size(82, 20)
        Me.txtFecEmision.TabIndex = 18
        Me.txtFecEmision.TodayButtonText = "Hoy"
        Me.txtFecEmision.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(6, 117)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(50, 13)
        Me.lblFecha.TabIndex = 195
        Me.lblFecha.Text = "Fecha :"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecha.IsNullDate = True
        Me.txtFecha.Location = New System.Drawing.Point(68, 113)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(82, 20)
        Me.txtFecha.TabIndex = 17
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 303)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(730, 185)
        Me.dgvDatos.TabIndex = 212
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miDuplicar, Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 126)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miDuplicar
        '
        Me.miDuplicar.Image = Global.SIGECOM.My.Resources.Resources.Canjear
        Me.miDuplicar.Name = "miDuplicar"
        Me.miDuplicar.Size = New System.Drawing.Size(126, 22)
        Me.miDuplicar.Text = "Duplicar"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(123, 6)
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
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'txtDesCuenta
        '
        Me.txtDesCuenta.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.txtDesCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDesCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesCuenta.ForeColor = System.Drawing.Color.Brown
        Me.txtDesCuenta.Location = New System.Drawing.Point(10, 15)
        Me.txtDesCuenta.Name = "txtDesCuenta"
        Me.txtDesCuenta.ReadOnly = True
        Me.txtDesCuenta.Size = New System.Drawing.Size(451, 12)
        Me.txtDesCuenta.TabIndex = 215
        Me.txtDesCuenta.TabStop = False
        Me.txtDesCuenta.Text = "DESCRIPCIÓN DE CUENTA CONTABLE"
        Me.txtDesCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumRegistro
        '
        Me.txtNumRegistro.Location = New System.Drawing.Point(382, 35)
        Me.txtNumRegistro.MaxLength = 6
        Me.txtNumRegistro.Name = "txtNumRegistro"
        Me.txtNumRegistro.Numeric = True
        Me.txtNumRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumRegistro.Size = New System.Drawing.Size(59, 20)
        Me.txtNumRegistro.TabIndex = 1
        '
        'txtMesRegistro
        '
        Me.txtMesRegistro.Location = New System.Drawing.Point(337, 35)
        Me.txtMesRegistro.MaxLength = 2
        Me.txtMesRegistro.Name = "txtMesRegistro"
        Me.txtMesRegistro.Numeric = True
        Me.txtMesRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMesRegistro.Size = New System.Drawing.Size(30, 20)
        Me.txtMesRegistro.TabIndex = 219
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.lblMontoTotalNeto)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoTotalNoAfecto)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoTotalIgv)
        Me.UiGroupBox6.Controls.Add(Me.txtDesCuenta)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoTotalNeto)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoTotalNoAfecto)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoTotalIgv)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoTotal)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoTotal)
        Me.UiGroupBox6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox6.Location = New System.Drawing.Point(0, 494)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(745, 94)
        Me.UiGroupBox6.TabIndex = 217
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblMontoTotalNeto
        '
        Me.lblMontoTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoTotalNeto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoTotalNeto.Location = New System.Drawing.Point(6, 68)
        Me.lblMontoTotalNeto.MaxLength = 20
        Me.lblMontoTotalNeto.Name = "lblMontoTotalNeto"
        Me.lblMontoTotalNeto.ReadOnly = True
        Me.lblMontoTotalNeto.Size = New System.Drawing.Size(612, 20)
        Me.lblMontoTotalNeto.TabIndex = 15
        Me.lblMontoTotalNeto.TabStop = False
        Me.lblMontoTotalNeto.Text = "MONTO TOTAL NETO"
        Me.lblMontoTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMontoTotalNoAfecto
        '
        Me.lblMontoTotalNoAfecto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoTotalNoAfecto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoTotalNoAfecto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoTotalNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotalNoAfecto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoTotalNoAfecto.Location = New System.Drawing.Point(6, 49)
        Me.lblMontoTotalNoAfecto.MaxLength = 20
        Me.lblMontoTotalNoAfecto.Name = "lblMontoTotalNoAfecto"
        Me.lblMontoTotalNoAfecto.ReadOnly = True
        Me.lblMontoTotalNoAfecto.Size = New System.Drawing.Size(612, 20)
        Me.lblMontoTotalNoAfecto.TabIndex = 13
        Me.lblMontoTotalNoAfecto.TabStop = False
        Me.lblMontoTotalNoAfecto.Text = "MONTO TOTAL NO AFECTO IGV"
        Me.lblMontoTotalNoAfecto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMontoTotalIgv
        '
        Me.lblMontoTotalIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoTotalIgv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoTotalIgv.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoTotalIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotalIgv.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoTotalIgv.Location = New System.Drawing.Point(6, 30)
        Me.lblMontoTotalIgv.MaxLength = 20
        Me.lblMontoTotalIgv.Name = "lblMontoTotalIgv"
        Me.lblMontoTotalIgv.ReadOnly = True
        Me.lblMontoTotalIgv.Size = New System.Drawing.Size(612, 20)
        Me.lblMontoTotalIgv.TabIndex = 10
        Me.lblMontoTotalIgv.TabStop = False
        Me.lblMontoTotalIgv.Text = "MONTO TOTAL I.G.V."
        Me.lblMontoTotalIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoTotalNeto
        '
        Me.txtMontoTotalNeto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoTotalNeto.Location = New System.Drawing.Point(615, 68)
        Me.txtMontoTotalNeto.MaxLength = 5
        Me.txtMontoTotalNeto.Name = "txtMontoTotalNeto"
        Me.txtMontoTotalNeto.ReadOnly = True
        Me.txtMontoTotalNeto.Size = New System.Drawing.Size(124, 20)
        Me.txtMontoTotalNeto.TabIndex = 16
        Me.txtMontoTotalNeto.TabStop = False
        Me.txtMontoTotalNeto.Text = "0.00"
        Me.txtMontoTotalNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoTotalNoAfecto
        '
        Me.txtMontoTotalNoAfecto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoTotalNoAfecto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoTotalNoAfecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotalNoAfecto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoTotalNoAfecto.Location = New System.Drawing.Point(615, 49)
        Me.txtMontoTotalNoAfecto.MaxLength = 5
        Me.txtMontoTotalNoAfecto.Name = "txtMontoTotalNoAfecto"
        Me.txtMontoTotalNoAfecto.ReadOnly = True
        Me.txtMontoTotalNoAfecto.Size = New System.Drawing.Size(124, 20)
        Me.txtMontoTotalNoAfecto.TabIndex = 14
        Me.txtMontoTotalNoAfecto.TabStop = False
        Me.txtMontoTotalNoAfecto.Text = "0.00"
        Me.txtMontoTotalNoAfecto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoTotalNoAfecto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotalNoAfecto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoTotalIgv
        '
        Me.txtMontoTotalIgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoTotalIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoTotalIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotalIgv.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoTotalIgv.Location = New System.Drawing.Point(615, 30)
        Me.txtMontoTotalIgv.MaxLength = 5
        Me.txtMontoTotalIgv.Name = "txtMontoTotalIgv"
        Me.txtMontoTotalIgv.ReadOnly = True
        Me.txtMontoTotalIgv.Size = New System.Drawing.Size(124, 20)
        Me.txtMontoTotalIgv.TabIndex = 6
        Me.txtMontoTotalIgv.TabStop = False
        Me.txtMontoTotalIgv.Text = "0.00"
        Me.txtMontoTotalIgv.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoTotalIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotalIgv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoTotal.Location = New System.Drawing.Point(6, 11)
        Me.lblMontoTotal.MaxLength = 20
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.ReadOnly = True
        Me.lblMontoTotal.Size = New System.Drawing.Size(612, 20)
        Me.lblMontoTotal.TabIndex = 12
        Me.lblMontoTotal.TabStop = False
        Me.lblMontoTotal.Text = "MONTO TOTAL"
        Me.lblMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoTotal.Location = New System.Drawing.Point(615, 11)
        Me.txtMontoTotal.MaxLength = 5
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(124, 20)
        Me.txtMontoTotal.TabIndex = 11
        Me.txtMontoTotal.TabStop = False
        Me.txtMontoTotal.Text = "0.00"
        Me.txtMontoTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(150, 35)
        Me.txtPeriodo.Maximum = 2059
        Me.txtPeriodo.Minimum = 2006
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
        Me.txtPeriodo.TabIndex = 218
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.Value = 2006
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(95, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 219
        Me.Label7.Text = "Periodo"
        '
        'frmRegCompras
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(745, 608)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.txtNumRegistro)
        Me.Controls.Add(Me.txtMesRegistro)
        Me.Controls.Add(Me.btnBuscarRegistro)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtIgv)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRegCompras"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras - Ingreso de Compra"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbTipoDetraccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReferencia.ResumeLayout(False)
        Me.gbReferencia.PerformLayout()
        CType(Me.cmbTipoRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbIgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbIgv.ResumeLayout(False)
        Me.gbIgv.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        CType(Me.cmbCondPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnBuscarRegistro As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtNumRef As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSerieRef As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSerieDoc As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFecEmision As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbProveedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbCondPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFecVencimiento As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTipCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents gbEstado As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbIgv As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbAfectoIgv As System.Windows.Forms.CheckBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtDesCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtNumRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtMesRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtCodTipoDoc As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents btnAgregarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblMontoTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents lblMontoTotalNoAfecto As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoTotalNoAfecto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoTotalIgv As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoTotalIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbTipoRef As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbReferencia As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecDocRef As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtNumDoc As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtCodTipoRef As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rbAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miDuplicar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscarPdf As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPdfFE As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarXml As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtXmlFE As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiarXml As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLimpiarPdf As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDescargarPdf As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDescargarXml As Janus.Windows.EditControls.UIButton
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFechaPagoDetraccion As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtNroPagoDetraccion As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents cmbTipoDetraccion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbAfectoDetraccion As CheckBox
    Friend WithEvents txtNumGasto As TextBox
    Friend WithEvents Label13 As Label
End Class
