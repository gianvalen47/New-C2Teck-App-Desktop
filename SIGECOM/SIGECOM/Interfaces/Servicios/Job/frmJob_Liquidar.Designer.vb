<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob_Liquidar
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
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvcotizaciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJob_Liquidar))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnLiquidar = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.GrupoLiquidacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbParcial = New System.Windows.Forms.CheckBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtporcentaje = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.txtutilidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.txtMontoCosto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoVenta = New System.Windows.Forms.TextBox()
        Me.txtMontoVenta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoCosto = New System.Windows.Forms.TextBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txttotalporcentajeteorica = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.txttotalutilidadteorica = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.txttotalcostoteorica = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txttotalventateorica = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.dgvcotizaciones = New Janus.Windows.GridEX.GridEX()
        Me.btnvalidar = New System.Windows.Forms.Button()
        Me.btnrechazar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrupoLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoLiquidacion.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.dgvcotizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(742, 411)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 39)
        Me.btnCancelar.TabIndex = 246
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnLiquidar
        '
        Me.btnLiquidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiquidar.Image = CType(resources.GetObject("btnLiquidar.Image"), System.Drawing.Image)
        Me.btnLiquidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLiquidar.Location = New System.Drawing.Point(522, 411)
        Me.btnLiquidar.Name = "btnLiquidar"
        Me.btnLiquidar.Size = New System.Drawing.Size(79, 39)
        Me.btnLiquidar.TabIndex = 245
        Me.btnLiquidar.Text = "Liquidar"
        Me.btnLiquidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLiquidar.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(337, 19)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(60, 13)
        Me.Label28.TabIndex = 170
        Me.Label28.Text = "Moneda :"
        '
        'cmbCodMon
        '
        Me.cmbCodMon.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(403, 15)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.ReadOnly = True
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(51, 20)
        Me.cmbCodMon.TabIndex = 161
        Me.cmbCodMon.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrupoLiquidacion
        '
        Me.GrupoLiquidacion.Controls.Add(Me.cbParcial)
        Me.GrupoLiquidacion.Controls.Add(Me.cmbCodMon)
        Me.GrupoLiquidacion.Controls.Add(Me.Label28)
        Me.GrupoLiquidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrupoLiquidacion.Location = New System.Drawing.Point(6, 6)
        Me.GrupoLiquidacion.Name = "GrupoLiquidacion"
        Me.GrupoLiquidacion.Size = New System.Drawing.Size(512, 43)
        Me.GrupoLiquidacion.TabIndex = 253
        Me.GrupoLiquidacion.Text = "Datos de Liquidación"
        Me.GrupoLiquidacion.Visible = False
        Me.GrupoLiquidacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cbParcial
        '
        Me.cbParcial.AutoSize = True
        Me.cbParcial.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbParcial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbParcial.Location = New System.Drawing.Point(114, 19)
        Me.cbParcial.Name = "cbParcial"
        Me.cbParcial.Size = New System.Drawing.Size(134, 17)
        Me.cbParcial.TabIndex = 0
        Me.cbParcial.Text = "Liquidación Parcial"
        Me.cbParcial.UseVisualStyleBackColor = False
        Me.cbParcial.Visible = False
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.DataSource = Me.dgvDatos.Layouts
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(6, 18)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(634, 220)
        Me.dgvDatos.TabIndex = 270
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.UiGroupBox6)
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Location = New System.Drawing.Point(6, 55)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(652, 341)
        Me.gbDetalle.TabIndex = 271
        Me.gbDetalle.Text = "Detalles OT"
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtporcentaje)
        Me.UiGroupBox6.Controls.Add(Me.TextBox4)
        Me.UiGroupBox6.Controls.Add(Me.txtutilidad)
        Me.UiGroupBox6.Controls.Add(Me.TextBox3)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoCosto)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoVenta)
        Me.UiGroupBox6.Controls.Add(Me.txtMontoVenta)
        Me.UiGroupBox6.Controls.Add(Me.lblMontoCosto)
        Me.UiGroupBox6.Location = New System.Drawing.Point(6, 241)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(635, 93)
        Me.UiGroupBox6.TabIndex = 272
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtporcentaje
        '
        Me.txtporcentaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtporcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtporcentaje.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtporcentaje.Location = New System.Drawing.Point(523, 68)
        Me.txtporcentaje.MaxLength = 5
        Me.txtporcentaje.Name = "txtporcentaje"
        Me.txtporcentaje.ReadOnly = True
        Me.txtporcentaje.Size = New System.Drawing.Size(104, 20)
        Me.txtporcentaje.TabIndex = 14
        Me.txtporcentaje.TabStop = False
        Me.txtporcentaje.Text = "0.00"
        Me.txtporcentaje.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtporcentaje.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtporcentaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox4.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox4.Location = New System.Drawing.Point(6, 68)
        Me.TextBox4.MaxLength = 20
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(518, 20)
        Me.TextBox4.TabIndex = 13
        Me.TextBox4.TabStop = False
        Me.TextBox4.Text = "TOTAL PORCENTAJE (%):"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtutilidad
        '
        Me.txtutilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtutilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilidad.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtutilidad.Location = New System.Drawing.Point(523, 49)
        Me.txtutilidad.MaxLength = 5
        Me.txtutilidad.Name = "txtutilidad"
        Me.txtutilidad.ReadOnly = True
        Me.txtutilidad.Size = New System.Drawing.Size(104, 20)
        Me.txtutilidad.TabIndex = 12
        Me.txtutilidad.TabStop = False
        Me.txtutilidad.Text = "0.00"
        Me.txtutilidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtutilidad.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtutilidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox3.Location = New System.Drawing.Point(6, 49)
        Me.TextBox3.MaxLength = 20
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(518, 20)
        Me.TextBox3.TabIndex = 11
        Me.TextBox3.TabStop = False
        Me.TextBox3.Text = "TOTAL UTILIDAD:"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoCosto
        '
        Me.txtMontoCosto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoCosto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoCosto.Location = New System.Drawing.Point(523, 30)
        Me.txtMontoCosto.MaxLength = 5
        Me.txtMontoCosto.Name = "txtMontoCosto"
        Me.txtMontoCosto.ReadOnly = True
        Me.txtMontoCosto.Size = New System.Drawing.Size(104, 20)
        Me.txtMontoCosto.TabIndex = 10
        Me.txtMontoCosto.TabStop = False
        Me.txtMontoCosto.Text = "0.00"
        Me.txtMontoCosto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoCosto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoVenta
        '
        Me.lblMontoVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoVenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoVenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoVenta.Location = New System.Drawing.Point(6, 11)
        Me.lblMontoVenta.MaxLength = 20
        Me.lblMontoVenta.Name = "lblMontoVenta"
        Me.lblMontoVenta.ReadOnly = True
        Me.lblMontoVenta.Size = New System.Drawing.Size(518, 20)
        Me.lblMontoVenta.TabIndex = 8
        Me.lblMontoVenta.TabStop = False
        Me.lblMontoVenta.Text = "(Montos no incluyen Igv)  TOTAL MONTO VENTA:"
        Me.lblMontoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoVenta
        '
        Me.txtMontoVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoVenta.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoVenta.Location = New System.Drawing.Point(523, 11)
        Me.txtMontoVenta.MaxLength = 5
        Me.txtMontoVenta.Name = "txtMontoVenta"
        Me.txtMontoVenta.ReadOnly = True
        Me.txtMontoVenta.Size = New System.Drawing.Size(104, 20)
        Me.txtMontoVenta.TabIndex = 3
        Me.txtMontoVenta.TabStop = False
        Me.txtMontoVenta.Text = "0.00"
        Me.txtMontoVenta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoVenta.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoCosto
        '
        Me.lblMontoCosto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoCosto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoCosto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoCosto.Location = New System.Drawing.Point(6, 30)
        Me.lblMontoCosto.MaxLength = 20
        Me.lblMontoCosto.Name = "lblMontoCosto"
        Me.lblMontoCosto.ReadOnly = True
        Me.lblMontoCosto.Size = New System.Drawing.Size(518, 20)
        Me.lblMontoCosto.TabIndex = 9
        Me.lblMontoCosto.TabStop = False
        Me.lblMontoCosto.Text = "TOTAL MONTO COSTO:"
        Me.lblMontoCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Controls.Add(Me.dgvcotizaciones)
        Me.UiGroupBox1.Location = New System.Drawing.Point(668, 55)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(622, 341)
        Me.UiGroupBox1.TabIndex = 272
        Me.UiGroupBox1.Text = "Cotizaciones Asignadas"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox2.Controls.Add(Me.txttotalporcentajeteorica)
        Me.UiGroupBox2.Controls.Add(Me.TextBox6)
        Me.UiGroupBox2.Controls.Add(Me.txttotalutilidadteorica)
        Me.UiGroupBox2.Controls.Add(Me.TextBox5)
        Me.UiGroupBox2.Controls.Add(Me.txttotalcostoteorica)
        Me.UiGroupBox2.Controls.Add(Me.TextBox1)
        Me.UiGroupBox2.Controls.Add(Me.txttotalventateorica)
        Me.UiGroupBox2.Controls.Add(Me.TextBox2)
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 241)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(604, 93)
        Me.UiGroupBox2.TabIndex = 272
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txttotalporcentajeteorica
        '
        Me.txttotalporcentajeteorica.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txttotalporcentajeteorica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalporcentajeteorica.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txttotalporcentajeteorica.Location = New System.Drawing.Point(492, 68)
        Me.txttotalporcentajeteorica.MaxLength = 5
        Me.txttotalporcentajeteorica.Name = "txttotalporcentajeteorica"
        Me.txttotalporcentajeteorica.ReadOnly = True
        Me.txttotalporcentajeteorica.Size = New System.Drawing.Size(104, 20)
        Me.txttotalporcentajeteorica.TabIndex = 14
        Me.txttotalporcentajeteorica.TabStop = False
        Me.txttotalporcentajeteorica.Text = "0.00"
        Me.txttotalporcentajeteorica.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txttotalporcentajeteorica.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txttotalporcentajeteorica.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox6.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox6.Location = New System.Drawing.Point(6, 68)
        Me.TextBox6.MaxLength = 20
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(487, 20)
        Me.TextBox6.TabIndex = 13
        Me.TextBox6.TabStop = False
        Me.TextBox6.Text = "TOTAL PORCENTAJE (%):"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotalutilidadteorica
        '
        Me.txttotalutilidadteorica.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txttotalutilidadteorica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalutilidadteorica.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txttotalutilidadteorica.Location = New System.Drawing.Point(492, 49)
        Me.txttotalutilidadteorica.MaxLength = 5
        Me.txttotalutilidadteorica.Name = "txttotalutilidadteorica"
        Me.txttotalutilidadteorica.ReadOnly = True
        Me.txttotalutilidadteorica.Size = New System.Drawing.Size(104, 20)
        Me.txttotalutilidadteorica.TabIndex = 12
        Me.txttotalutilidadteorica.TabStop = False
        Me.txttotalutilidadteorica.Text = "0.00"
        Me.txttotalutilidadteorica.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txttotalutilidadteorica.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txttotalutilidadteorica.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox5.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox5.Location = New System.Drawing.Point(6, 49)
        Me.TextBox5.MaxLength = 20
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(487, 20)
        Me.TextBox5.TabIndex = 11
        Me.TextBox5.TabStop = False
        Me.TextBox5.Text = "TOTAL UTILIDAD:"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotalcostoteorica
        '
        Me.txttotalcostoteorica.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txttotalcostoteorica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalcostoteorica.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txttotalcostoteorica.Location = New System.Drawing.Point(492, 30)
        Me.txttotalcostoteorica.MaxLength = 5
        Me.txttotalcostoteorica.Name = "txttotalcostoteorica"
        Me.txttotalcostoteorica.ReadOnly = True
        Me.txttotalcostoteorica.Size = New System.Drawing.Size(104, 20)
        Me.txttotalcostoteorica.TabIndex = 10
        Me.txttotalcostoteorica.TabStop = False
        Me.txttotalcostoteorica.Text = "0.00"
        Me.txttotalcostoteorica.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txttotalcostoteorica.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txttotalcostoteorica.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox1.Location = New System.Drawing.Point(6, 11)
        Me.TextBox1.MaxLength = 20
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(487, 20)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "(Montos no incluyen Igv)  TOTAL MONTO VENTA:"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotalventateorica
        '
        Me.txttotalventateorica.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txttotalventateorica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalventateorica.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txttotalventateorica.Location = New System.Drawing.Point(492, 11)
        Me.txttotalventateorica.MaxLength = 5
        Me.txttotalventateorica.Name = "txttotalventateorica"
        Me.txttotalventateorica.ReadOnly = True
        Me.txttotalventateorica.Size = New System.Drawing.Size(104, 20)
        Me.txttotalventateorica.TabIndex = 3
        Me.txttotalventateorica.TabStop = False
        Me.txttotalventateorica.Text = "0.00"
        Me.txttotalventateorica.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txttotalventateorica.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txttotalventateorica.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.TextBox2.Location = New System.Drawing.Point(6, 30)
        Me.TextBox2.MaxLength = 20
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(487, 20)
        Me.TextBox2.TabIndex = 9
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = "TOTAL MONTO COSTO:"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvcotizaciones
        '
        Me.dgvcotizaciones.AllowCardSizing = False
        Me.dgvcotizaciones.DataSource = Me.dgvcotizaciones.Layouts
        dgvcotizaciones_DesignTimeLayout.LayoutString = resources.GetString("dgvcotizaciones_DesignTimeLayout.LayoutString")
        Me.dgvcotizaciones.DesignTimeLayout = dgvcotizaciones_DesignTimeLayout
        Me.dgvcotizaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvcotizaciones.GroupByBoxVisible = False
        Me.dgvcotizaciones.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvcotizaciones.Location = New System.Drawing.Point(6, 18)
        Me.dgvcotizaciones.Name = "dgvcotizaciones"
        Me.dgvcotizaciones.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvcotizaciones.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvcotizaciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvcotizaciones.Size = New System.Drawing.Size(604, 220)
        Me.dgvcotizaciones.TabIndex = 270
        Me.dgvcotizaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnvalidar
        '
        Me.btnvalidar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnvalidar.Image = Global.SIGECOM.My.Resources.Resources.Cont_diario
        Me.btnvalidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnvalidar.Location = New System.Drawing.Point(529, 6)
        Me.btnvalidar.Name = "btnvalidar"
        Me.btnvalidar.Size = New System.Drawing.Size(128, 43)
        Me.btnvalidar.TabIndex = 273
        Me.btnvalidar.Text = "Validar Datos"
        Me.btnvalidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnvalidar.UseVisualStyleBackColor = True
        '
        'btnrechazar
        '
        Me.btnrechazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrechazar.Image = Global.SIGECOM.My.Resources.Resources.ManoHaciaAbajo
        Me.btnrechazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrechazar.Location = New System.Drawing.Point(624, 411)
        Me.btnrechazar.Name = "btnrechazar"
        Me.btnrechazar.Size = New System.Drawing.Size(98, 39)
        Me.btnrechazar.TabIndex = 274
        Me.btnrechazar.Text = "Rechazar"
        Me.btnrechazar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnrechazar.UseVisualStyleBackColor = True
        '
        'frmJob_Liquidar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1302, 479)
        Me.Controls.Add(Me.btnrechazar)
        Me.Controls.Add(Me.btnvalidar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.GrupoLiquidacion)
        Me.Controls.Add(Me.btnLiquidar)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJob_Liquidar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liquidar"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrupoLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoLiquidacion.ResumeLayout(False)
        Me.GrupoLiquidacion.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.dgvcotizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnLiquidar As System.Windows.Forms.Button
    Friend WithEvents GrupoLiquidacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbParcial As System.Windows.Forms.CheckBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtMontoCosto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoVenta As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoVenta As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoCosto As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txttotalcostoteorica As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txttotalventateorica As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents dgvcotizaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtporcentaje As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents txtutilidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents txttotalporcentajeteorica As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents txttotalutilidadteorica As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents btnvalidar As Button
    Friend WithEvents btnrechazar As Button
End Class
