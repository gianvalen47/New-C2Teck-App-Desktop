<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRendirFondos
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMonedas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRendirFondos))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtIdGasto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPersonaSolicita = New System.Windows.Forms.TextBox()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtPersonaAutoriza = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblMontoTotalNeto = New System.Windows.Forms.TextBox()
        Me.txtMontoTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.gbSolicitudGastos = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtMontoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnPendientes = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMontoOriginal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cmbMonedas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbSolicitudGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSolicitudGastos.SuspendLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'txtIdGasto
        '
        Me.txtIdGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdGasto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdGasto.Location = New System.Drawing.Point(72, 24)
        Me.txtIdGasto.Name = "txtIdGasto"
        Me.txtIdGasto.Size = New System.Drawing.Size(80, 20)
        Me.txtIdGasto.TabIndex = 1
        Me.txtIdGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nº Gasto"
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
        Me.txtFecha.Location = New System.Drawing.Point(72, 59)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(94, 20)
        Me.txtFecha.TabIndex = 200
        Me.txtFecha.TabStop = False
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(9, 62)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 197
        Me.lblFecha.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 199
        Me.Label3.Text = "Solicitado Por"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(178, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 198
        Me.Label11.Text = "Area"
        '
        'txtPersonaSolicita
        '
        Me.txtPersonaSolicita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonaSolicita.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonaSolicita.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersonaSolicita.Location = New System.Drawing.Point(95, 87)
        Me.txtPersonaSolicita.MaxLength = 3
        Me.txtPersonaSolicita.Name = "txtPersonaSolicita"
        Me.txtPersonaSolicita.ReadOnly = True
        Me.txtPersonaSolicita.Size = New System.Drawing.Size(236, 19)
        Me.txtPersonaSolicita.TabIndex = 201
        Me.txtPersonaSolicita.TabStop = False
        '
        'txtArea
        '
        Me.txtArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArea.Location = New System.Drawing.Point(213, 60)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(132, 19)
        Me.txtArea.TabIndex = 202
        Me.txtArea.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 204
        Me.Label5.Text = "Moneda"
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.Color.Transparent
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(394, 12)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(275, 39)
        Me.gbEstado.TabIndex = 205
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(6, 12)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(263, 21)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPersonaAutoriza
        '
        Me.txtPersonaAutoriza.BackColor = System.Drawing.SystemColors.Control
        Me.txtPersonaAutoriza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonaAutoriza.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonaAutoriza.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPersonaAutoriza.Location = New System.Drawing.Point(427, 87)
        Me.txtPersonaAutoriza.MaxLength = 20
        Me.txtPersonaAutoriza.Name = "txtPersonaAutoriza"
        Me.txtPersonaAutoriza.ReadOnly = True
        Me.txtPersonaAutoriza.Size = New System.Drawing.Size(242, 19)
        Me.txtPersonaAutoriza.TabIndex = 206
        Me.txtPersonaAutoriza.TabStop = False
        Me.txtPersonaAutoriza.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(337, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 207
        Me.Label4.Text = "Autorizado Por"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox2.Controls.Add(Me.UiGroupBox6)
        Me.UiGroupBox2.Controls.Add(Me.dgvDatos)
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 113)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(673, 196)
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
        Me.UiGroupBox6.Location = New System.Drawing.Point(3, 155)
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
        Me.dgvDatos.Size = New System.Drawing.Size(661, 131)
        Me.dgvDatos.TabIndex = 191
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gbSolicitudGastos
        '
        Me.gbSolicitudGastos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbSolicitudGastos.Controls.Add(Me.cmbCodMon)
        Me.gbSolicitudGastos.Controls.Add(Me.UiGroupBox2)
        Me.gbSolicitudGastos.Controls.Add(Me.txtMontoTotal)
        Me.gbSolicitudGastos.Controls.Add(Me.Label19)
        Me.gbSolicitudGastos.Controls.Add(Me.Label4)
        Me.gbSolicitudGastos.Controls.Add(Me.txtPersonaAutoriza)
        Me.gbSolicitudGastos.Controls.Add(Me.gbEstado)
        Me.gbSolicitudGastos.Controls.Add(Me.Label5)
        Me.gbSolicitudGastos.Controls.Add(Me.txtArea)
        Me.gbSolicitudGastos.Controls.Add(Me.txtPersonaSolicita)
        Me.gbSolicitudGastos.Controls.Add(Me.Label11)
        Me.gbSolicitudGastos.Controls.Add(Me.Label3)
        Me.gbSolicitudGastos.Controls.Add(Me.lblFecha)
        Me.gbSolicitudGastos.Controls.Add(Me.txtFecha)
        Me.gbSolicitudGastos.Controls.Add(Me.Label1)
        Me.gbSolicitudGastos.Controls.Add(Me.txtIdGasto)
        Me.gbSolicitudGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSolicitudGastos.Location = New System.Drawing.Point(7, 7)
        Me.gbSolicitudGastos.Name = "gbSolicitudGastos"
        Me.gbSolicitudGastos.Size = New System.Drawing.Size(685, 316)
        Me.gbSolicitudGastos.TabIndex = 0
        Me.gbSolicitudGastos.Text = "Datos de Solicitud de Gasto"
        Me.gbSolicitudGastos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbCodMon
        '
        Me.cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(415, 60)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.ReadOnly = True
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(54, 20)
        Me.cmbCodMon.TabIndex = 211
        Me.cmbCodMon.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotal.Location = New System.Drawing.Point(584, 59)
        Me.txtMontoTotal.MaxLength = 10
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(85, 20)
        Me.txtMontoTotal.TabIndex = 209
        Me.txtMontoTotal.TabStop = False
        Me.txtMontoTotal.Text = "0.00"
        Me.txtMontoTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(486, 63)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 13)
        Me.Label19.TabIndex = 208
        Me.Label19.Text = "Monto Tot Neto"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.BackColor = System.Drawing.SystemColors.Control
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(20, 20)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.ReadOnly = True
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(54, 20)
        Me.cmbMoneda.TabIndex = 203
        Me.cmbMoneda.TabStop = False
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(292, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 210
        Me.Label2.Text = "Importe Original"
        '
        'txtMontoOriginal
        '
        Me.txtMontoOriginal.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoOriginal.Location = New System.Drawing.Point(394, 19)
        Me.txtMontoOriginal.MaxLength = 10
        Me.txtMontoOriginal.Name = "txtMontoOriginal"
        Me.txtMontoOriginal.ReadOnly = True
        Me.txtMontoOriginal.Size = New System.Drawing.Size(105, 20)
        Me.txtMontoOriginal.TabIndex = 211
        Me.txtMontoOriginal.TabStop = False
        Me.txtMontoOriginal.Text = "0.00"
        Me.txtMontoOriginal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoOriginal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox4.Controls.Add(Me.btnGuardar)
        Me.UiGroupBox4.Controls.Add(Me.cmbMonedas)
        Me.UiGroupBox4.Controls.Add(Me.Label16)
        Me.UiGroupBox4.Controls.Add(Me.Label6)
        Me.UiGroupBox4.Controls.Add(Me.txtGlosa)
        Me.UiGroupBox4.Controls.Add(Me.txtMontoOriginal)
        Me.UiGroupBox4.Controls.Add(Me.Label2)
        Me.UiGroupBox4.Controls.Add(Me.btnPendientes)
        Me.UiGroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox4.Location = New System.Drawing.Point(0, 331)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(707, 131)
        Me.UiGroupBox4.TabIndex = 2
        Me.UiGroupBox4.Text = "Datos de Tesoreria - Asiento"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(340, 95)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 214
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
        Me.btnGuardar.Location = New System.Drawing.Point(256, 95)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 27)
        Me.btnGuardar.TabIndex = 215
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(124, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 224
        Me.Label6.Text = "Moneda"
        '
        'frmRendirFondos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(707, 462)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Controls.Add(Me.gbSolicitudGastos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRendirFondos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rendición de Fondos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbSolicitudGastos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSolicitudGastos.ResumeLayout(False)
        Me.gbSolicitudGastos.PerformLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.cmbMonedas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoOriginal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPendientes As System.Windows.Forms.Button
    Friend WithEvents gbSolicitudGastos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblMontoTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPersonaAutoriza As System.Windows.Forms.TextBox
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents txtPersonaSolicita As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdGasto As System.Windows.Forms.TextBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbMonedas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMontoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
