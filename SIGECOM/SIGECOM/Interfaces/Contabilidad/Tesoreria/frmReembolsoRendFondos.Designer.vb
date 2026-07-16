<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReembolsoRendFondos
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
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMonedas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReembolsoRendFondos))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbSolicitudGastos = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarReembolso = New System.Windows.Forms.Button()
        Me.txtTCCompra = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTCVenta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblMontoTotalNeto = New System.Windows.Forms.TextBox()
        Me.txtMontoTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIdReembolso = New System.Windows.Forms.TextBox()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cmbMonedas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.txtMontoOriginal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPendientes = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbSolicitudGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSolicitudGastos.SuspendLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.cmbMonedas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbSolicitudGastos
        '
        Me.gbSolicitudGastos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbSolicitudGastos.Controls.Add(Me.btnBuscarReembolso)
        Me.gbSolicitudGastos.Controls.Add(Me.txtTCCompra)
        Me.gbSolicitudGastos.Controls.Add(Me.Label10)
        Me.gbSolicitudGastos.Controls.Add(Me.txtTCVenta)
        Me.gbSolicitudGastos.Controls.Add(Me.Label2)
        Me.gbSolicitudGastos.Controls.Add(Me.cmbCodMon)
        Me.gbSolicitudGastos.Controls.Add(Me.UiGroupBox2)
        Me.gbSolicitudGastos.Controls.Add(Me.Label5)
        Me.gbSolicitudGastos.Controls.Add(Me.txtUbicacion)
        Me.gbSolicitudGastos.Controls.Add(Me.Label11)
        Me.gbSolicitudGastos.Controls.Add(Me.lblFecha)
        Me.gbSolicitudGastos.Controls.Add(Me.txtFecha)
        Me.gbSolicitudGastos.Controls.Add(Me.Label1)
        Me.gbSolicitudGastos.Controls.Add(Me.txtIdReembolso)
        Me.gbSolicitudGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSolicitudGastos.Location = New System.Drawing.Point(7, 7)
        Me.gbSolicitudGastos.Name = "gbSolicitudGastos"
        Me.gbSolicitudGastos.Size = New System.Drawing.Size(685, 316)
        Me.gbSolicitudGastos.TabIndex = 1
        Me.gbSolicitudGastos.Text = "Datos de Reembolso"
        Me.gbSolicitudGastos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarReembolso
        '
        Me.btnBuscarReembolso.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarReembolso.Location = New System.Drawing.Point(179, 26)
        Me.btnBuscarReembolso.Name = "btnBuscarReembolso"
        Me.btnBuscarReembolso.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarReembolso.TabIndex = 216
        Me.btnBuscarReembolso.TabStop = False
        Me.btnBuscarReembolso.UseVisualStyleBackColor = True
        '
        'txtTCCompra
        '
        Me.txtTCCompra.BackColor = System.Drawing.SystemColors.Control
        Me.txtTCCompra.DecimalDigits = 3
        Me.txtTCCompra.Location = New System.Drawing.Point(619, 57)
        Me.txtTCCompra.MaxLength = 12
        Me.txtTCCompra.Name = "txtTCCompra"
        Me.txtTCCompra.ReadOnly = True
        Me.txtTCCompra.Size = New System.Drawing.Size(49, 20)
        Me.txtTCCompra.TabIndex = 212
        Me.txtTCCompra.Text = "0.000"
        Me.txtTCCompra.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtTCCompra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(561, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 214
        Me.Label10.Text = "T.C. Com"
        '
        'txtTCVenta
        '
        Me.txtTCVenta.BackColor = System.Drawing.SystemColors.Control
        Me.txtTCVenta.DecimalDigits = 3
        Me.txtTCVenta.Location = New System.Drawing.Point(501, 57)
        Me.txtTCVenta.MaxLength = 12
        Me.txtTCVenta.Name = "txtTCVenta"
        Me.txtTCVenta.ReadOnly = True
        Me.txtTCVenta.Size = New System.Drawing.Size(49, 20)
        Me.txtTCVenta.TabIndex = 213
        Me.txtTCVenta.Text = "0.000"
        Me.txtTCVenta.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtTCVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(441, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 215
        Me.Label2.Text = "T.C. Vent"
        '
        'cmbCodMon
        '
        Me.cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(385, 57)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.ReadOnly = True
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(47, 20)
        Me.cmbCodMon.TabIndex = 211
        Me.cmbCodMon.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox2.Controls.Add(Me.UiGroupBox6)
        Me.UiGroupBox2.Controls.Add(Me.dgvDatos)
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 82)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(673, 228)
        Me.UiGroupBox2.TabIndex = 210
        Me.UiGroupBox2.Text = "Detalles"
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.lblMontoTotalNeto)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoTotalNeto)
        Me.UiGroupBox6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox6.Location = New System.Drawing.Point(3, 187)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(667, 38)
        Me.UiGroupBox6.TabIndex = 211
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblMontoTotalNeto
        '
        Me.lblMontoTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoTotalNeto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoTotalNeto.Location = New System.Drawing.Point(6, 12)
        Me.lblMontoTotalNeto.MaxLength = 20
        Me.lblMontoTotalNeto.Name = "lblMontoTotalNeto"
        Me.lblMontoTotalNeto.ReadOnly = True
        Me.lblMontoTotalNeto.Size = New System.Drawing.Size(527, 20)
        Me.lblMontoTotalNeto.TabIndex = 212
        Me.lblMontoTotalNeto.TabStop = False
        Me.lblMontoTotalNeto.Text = "MONTO TOTAL NETO"
        Me.lblMontoTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoTotalNeto
        '
        Me.txtMontoTotalNeto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoTotalNeto.Location = New System.Drawing.Point(532, 12)
        Me.txtMontoTotalNeto.MaxLength = 5
        Me.txtMontoTotalNeto.Name = "txtMontoTotalNeto"
        Me.txtMontoTotalNeto.ReadOnly = True
        Me.txtMontoTotalNeto.Size = New System.Drawing.Size(129, 20)
        Me.txtMontoTotalNeto.TabIndex = 211
        Me.txtMontoTotalNeto.TabStop = False
        Me.txtMontoTotalNeto.Text = "0.00"
        Me.txtMontoTotalNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 17)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(661, 164)
        Me.dgvDatos.TabIndex = 191
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(332, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 204
        Me.Label5.Text = "Moneda"
        '
        'txtUbicacion
        '
        Me.txtUbicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbicacion.Location = New System.Drawing.Point(222, 57)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.ReadOnly = True
        Me.txtUbicacion.Size = New System.Drawing.Size(100, 19)
        Me.txtUbicacion.TabIndex = 202
        Me.txtUbicacion.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(154, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 198
        Me.Label11.Text = "Ubic. Caja"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(9, 60)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 197
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.IsNullDate = True
        Me.txtFecha.Location = New System.Drawing.Point(52, 57)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(92, 20)
        Me.txtFecha.TabIndex = 200
        Me.txtFecha.TabStop = False
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nº Reembolso"
        '
        'txtIdReembolso
        '
        Me.txtIdReembolso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdReembolso.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdReembolso.Location = New System.Drawing.Point(101, 27)
        Me.txtIdReembolso.Name = "txtIdReembolso"
        Me.txtIdReembolso.ReadOnly = True
        Me.txtIdReembolso.Size = New System.Drawing.Size(75, 20)
        Me.txtIdReembolso.TabIndex = 1
        Me.txtIdReembolso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox4.Controls.Add(Me.btnGuardar)
        Me.UiGroupBox4.Controls.Add(Me.cmbMonedas)
        Me.UiGroupBox4.Controls.Add(Me.Label16)
        Me.UiGroupBox4.Controls.Add(Me.Label6)
        Me.UiGroupBox4.Controls.Add(Me.txtGlosa)
        Me.UiGroupBox4.Controls.Add(Me.txtMontoOriginal)
        Me.UiGroupBox4.Controls.Add(Me.Label3)
        Me.UiGroupBox4.Controls.Add(Me.btnPendientes)
        Me.UiGroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox4.Location = New System.Drawing.Point(0, 329)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(708, 126)
        Me.UiGroupBox4.TabIndex = 3
        Me.UiGroupBox4.Text = "Datos de Tesoreria - Asiento"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(344, 95)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 26)
        Me.btnCancelar.TabIndex = 216
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(260, 95)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 26)
        Me.btnGuardar.TabIndex = 217
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cmbMonedas
        '
        Me.cmbMonedas.BackColor = System.Drawing.SystemColors.Control
        Me.cmbMonedas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMonedas_DesignTimeLayout.LayoutString = resources.GetString("cmbMonedas_DesignTimeLayout.LayoutString")
        Me.cmbMonedas.DesignTimeLayout = cmbMonedas_DesignTimeLayout
        Me.cmbMonedas.Location = New System.Drawing.Point(182, 21)
        Me.cmbMonedas.Name = "cmbMonedas"
        Me.cmbMonedas.ReadOnly = True
        Me.cmbMonedas.SelectedIndex = -1
        Me.cmbMonedas.SelectedItem = Nothing
        Me.cmbMonedas.Size = New System.Drawing.Size(54, 20)
        Me.cmbMonedas.TabIndex = 225
        Me.cmbMonedas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMonedas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(19, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 223
        Me.Label16.Text = "Glosa "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(124, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 224
        Me.Label6.Text = "Moneda"
        '
        'txtGlosa
        '
        Me.txtGlosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlosa.Location = New System.Drawing.Point(68, 46)
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtGlosa.Size = New System.Drawing.Size(591, 43)
        Me.txtGlosa.TabIndex = 4
        '
        'txtMontoOriginal
        '
        Me.txtMontoOriginal.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoOriginal.Location = New System.Drawing.Point(385, 19)
        Me.txtMontoOriginal.MaxLength = 30
        Me.txtMontoOriginal.Name = "txtMontoOriginal"
        Me.txtMontoOriginal.ReadOnly = True
        Me.txtMontoOriginal.Size = New System.Drawing.Size(120, 20)
        Me.txtMontoOriginal.TabIndex = 211
        Me.txtMontoOriginal.TabStop = False
        Me.txtMontoOriginal.Text = "0.00"
        Me.txtMontoOriginal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoOriginal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(283, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 210
        Me.Label3.Text = "Importe Original"
        '
        'btnPendientes
        '
        Me.btnPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPendientes.Image = Global.SIGECOM.My.Resources.Resources.CrdFle12
        Me.btnPendientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPendientes.Location = New System.Drawing.Point(563, 17)
        Me.btnPendientes.Name = "btnPendientes"
        Me.btnPendientes.Size = New System.Drawing.Size(96, 24)
        Me.btnPendientes.TabIndex = 3
        Me.btnPendientes.Text = "Pendientes"
        Me.btnPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPendientes.UseVisualStyleBackColor = True
        '
        'frmReembolsoRendFondos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(708, 455)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Controls.Add(Me.gbSolicitudGastos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReembolsoRendFondos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reembolso Rendición de Fondos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbSolicitudGastos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSolicitudGastos.ResumeLayout(False)
        Me.gbSolicitudGastos.PerformLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.cmbMonedas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbSolicitudGastos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblMontoTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdReembolso As System.Windows.Forms.TextBox
    Friend WithEvents txtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTCVenta As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTCCompra As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbMonedas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoOriginal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPendientes As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarReembolso As System.Windows.Forms.Button
End Class
