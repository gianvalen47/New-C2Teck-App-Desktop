<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobConsulta_Mostrar_ManoObra
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobConsulta_Mostrar_ManoObra))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMontoTotal = New System.Windows.Forms.Label()
        Me.txtTotalNormal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotal25 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotal35 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotal100 = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalViaje = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Personal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraNormal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora100 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraViaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biActualizar, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(860, 31)
        Me.ToolStrip.TabIndex = 247
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Solicitud de Job"
        Me.biActualizar.Visible = False
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
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 395)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(860, 20)
        Me.ssBarra.TabIndex = 248
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(550, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRubro.Location = New System.Drawing.Point(321, 52)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(98, 15)
        Me.lblRubro.TabIndex = 253
        Me.lblRubro.Text = "Mano de Obra"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(257, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 252
        Me.Label3.Text = "Rubro :"
        '
        'lblNumJob
        '
        Me.lblNumJob.AutoSize = True
        Me.lblNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumJob.Location = New System.Drawing.Point(82, 52)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(76, 15)
        Me.lblNumJob.TabIndex = 251
        Me.lblNumJob.Text = "lblNumJob"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 250
        Me.Label1.Text = "OT :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(190, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 15)
        Me.Label8.TabIndex = 274
        Me.Label8.Text = "Total H. Normal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(319, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 15)
        Me.Label7.TabIndex = 273
        Me.Label7.Text = "Total H. 25"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(429, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 15)
        Me.Label6.TabIndex = 272
        Me.Label6.Text = "Total H. 35"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(537, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 15)
        Me.Label5.TabIndex = 271
        Me.Label5.Text = "Total H. 100"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(649, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 15)
        Me.Label4.TabIndex = 270
        Me.Label4.Text = "Total H. Viaje"
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.AutoSize = True
        Me.lblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotal.Location = New System.Drawing.Point(747, 22)
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.Size = New System.Drawing.Size(83, 15)
        Me.lblMontoTotal.TabIndex = 269
        Me.lblMontoTotal.Text = "Monto Total"
        '
        'txtTotalNormal
        '
        Me.txtTotalNormal.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtTotalNormal.DisabledForeColor = System.Drawing.SystemColors.MenuText
        Me.txtTotalNormal.Enabled = False
        Me.txtTotalNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNormal.FormatString = "#0.00"
        Me.txtTotalNormal.Location = New System.Drawing.Point(193, 40)
        Me.txtTotalNormal.Name = "txtTotalNormal"
        Me.txtTotalNormal.ReadOnly = True
        Me.txtTotalNormal.Size = New System.Drawing.Size(105, 21)
        Me.txtTotalNormal.TabIndex = 268
        Me.txtTotalNormal.TabStop = False
        Me.txtTotalNormal.Text = "0.00"
        Me.txtTotalNormal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotal25
        '
        Me.txtTotal25.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtTotal25.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotal25.Enabled = False
        Me.txtTotal25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal25.FormatString = "#0.00"
        Me.txtTotal25.Location = New System.Drawing.Point(304, 40)
        Me.txtTotal25.Name = "txtTotal25"
        Me.txtTotal25.ReadOnly = True
        Me.txtTotal25.Size = New System.Drawing.Size(105, 21)
        Me.txtTotal25.TabIndex = 267
        Me.txtTotal25.TabStop = False
        Me.txtTotal25.Text = "0.00"
        Me.txtTotal25.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotal35
        '
        Me.txtTotal35.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtTotal35.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotal35.Enabled = False
        Me.txtTotal35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal35.FormatString = "#0.00"
        Me.txtTotal35.Location = New System.Drawing.Point(415, 40)
        Me.txtTotal35.Name = "txtTotal35"
        Me.txtTotal35.ReadOnly = True
        Me.txtTotal35.Size = New System.Drawing.Size(105, 21)
        Me.txtTotal35.TabIndex = 266
        Me.txtTotal35.TabStop = False
        Me.txtTotal35.Text = "0.00"
        Me.txtTotal35.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotal100
        '
        Me.txtTotal100.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtTotal100.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotal100.Enabled = False
        Me.txtTotal100.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal100.FormatString = "#0.00"
        Me.txtTotal100.Location = New System.Drawing.Point(526, 40)
        Me.txtTotal100.Name = "txtTotal100"
        Me.txtTotal100.ReadOnly = True
        Me.txtTotal100.Size = New System.Drawing.Size(105, 21)
        Me.txtTotal100.TabIndex = 265
        Me.txtTotal100.TabStop = False
        Me.txtTotal100.Text = "0.00"
        Me.txtTotal100.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalViaje
        '
        Me.txtTotalViaje.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtTotalViaje.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotalViaje.Enabled = False
        Me.txtTotalViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalViaje.FormatString = "#0.00"
        Me.txtTotalViaje.Location = New System.Drawing.Point(637, 40)
        Me.txtTotalViaje.Name = "txtTotalViaje"
        Me.txtTotalViaje.ReadOnly = True
        Me.txtTotalViaje.Size = New System.Drawing.Size(105, 21)
        Me.txtTotalViaje.TabIndex = 264
        Me.txtTotalViaje.TabStop = False
        Me.txtTotalViaje.Text = "0.00"
        Me.txtTotalViaje.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotal
        '
        Me.txtTotal.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtTotal.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.FormatString = "#0.00"
        Me.txtTotal.Location = New System.Drawing.Point(748, 40)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(105, 21)
        Me.txtTotal.TabIndex = 263
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Column1, Me.Personal, Me.HoraNormal, Me.Hora25, Me.Hora35, Me.Hora100, Me.HoraViaje, Me.Costo, Me.IdPer})
        Me.dgvDatos.Location = New System.Drawing.Point(12, 83)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.Size = New System.Drawing.Size(834, 227)
        Me.dgvDatos.TabIndex = 275
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 62
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "CodJob"
        Me.Column1.HeaderText = "OT"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 47
        '
        'Personal
        '
        Me.Personal.DataPropertyName = "Personal"
        Me.Personal.HeaderText = "Personal"
        Me.Personal.Name = "Personal"
        Me.Personal.ReadOnly = True
        Me.Personal.Width = 73
        '
        'HoraNormal
        '
        Me.HoraNormal.DataPropertyName = "HoraNormal"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.HoraNormal.DefaultCellStyle = DataGridViewCellStyle1
        Me.HoraNormal.HeaderText = "HoraNormal"
        Me.HoraNormal.Name = "HoraNormal"
        Me.HoraNormal.ReadOnly = True
        Me.HoraNormal.Width = 88
        '
        'Hora25
        '
        Me.Hora25.DataPropertyName = "Hora25"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Hora25.DefaultCellStyle = DataGridViewCellStyle2
        Me.Hora25.HeaderText = "Hora25"
        Me.Hora25.Name = "Hora25"
        Me.Hora25.ReadOnly = True
        Me.Hora25.Width = 67
        '
        'Hora35
        '
        Me.Hora35.DataPropertyName = "Hora35"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Hora35.DefaultCellStyle = DataGridViewCellStyle3
        Me.Hora35.HeaderText = "Hora35"
        Me.Hora35.Name = "Hora35"
        Me.Hora35.ReadOnly = True
        Me.Hora35.Width = 67
        '
        'Hora100
        '
        Me.Hora100.DataPropertyName = "Hora100"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Hora100.DefaultCellStyle = DataGridViewCellStyle4
        Me.Hora100.HeaderText = "Hora100"
        Me.Hora100.Name = "Hora100"
        Me.Hora100.ReadOnly = True
        Me.Hora100.Width = 73
        '
        'HoraViaje
        '
        Me.HoraViaje.DataPropertyName = "HoraViaje"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.HoraViaje.DefaultCellStyle = DataGridViewCellStyle5
        Me.HoraViaje.HeaderText = "HoraViaje"
        Me.HoraViaje.Name = "HoraViaje"
        Me.HoraViaje.ReadOnly = True
        Me.HoraViaje.Width = 78
        '
        'Costo
        '
        Me.Costo.DataPropertyName = "Costo"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Costo.DefaultCellStyle = DataGridViewCellStyle6
        Me.Costo.HeaderText = "Costo"
        Me.Costo.Name = "Costo"
        Me.Costo.ReadOnly = True
        Me.Costo.Width = 59
        '
        'IdPer
        '
        Me.IdPer.DataPropertyName = "IdPer"
        Me.IdPer.HeaderText = "IdPer"
        Me.IdPer.Name = "IdPer"
        Me.IdPer.ReadOnly = True
        Me.IdPer.Visible = False
        Me.IdPer.Width = 57
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtTotalNormal)
        Me.UiGroupBox1.Controls.Add(Me.txtTotal)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalViaje)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtTotal100)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.txtTotal35)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtTotal25)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.lblMontoTotal)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 316)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(860, 79)
        Me.UiGroupBox1.TabIndex = 317
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmJobConsulta_Mostrar_ManoObra
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(860, 415)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.lblRubro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNumJob)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJobConsulta_Mostrar_ManoObra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mostrar Mano de Obra"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRubro As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMontoTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotalNormal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal25 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal35 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal100 As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalViaje As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Personal As DataGridViewTextBoxColumn
    Friend WithEvents HoraNormal As DataGridViewTextBoxColumn
    Friend WithEvents Hora25 As DataGridViewTextBoxColumn
    Friend WithEvents Hora35 As DataGridViewTextBoxColumn
    Friend WithEvents Hora100 As DataGridViewTextBoxColumn
    Friend WithEvents HoraViaje As DataGridViewTextBoxColumn
    Friend WithEvents Costo As DataGridViewTextBoxColumn
    Friend WithEvents IdPer As DataGridViewTextBoxColumn
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
End Class
