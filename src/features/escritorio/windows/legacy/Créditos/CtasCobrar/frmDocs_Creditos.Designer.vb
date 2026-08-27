<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocs_Creditos
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
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocs_Creditos))
    Dim cmbDocu_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
    Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
    Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
    Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
    Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
    Me.ssBarra = New System.Windows.Forms.StatusStrip
    Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
    Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
    Me.ToolStrip = New System.Windows.Forms.ToolStrip
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
    Me.biMostrar = New System.Windows.Forms.ToolStripButton
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
    Me.biActualizar = New System.Windows.Forms.ToolStripButton
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
    Me.biSalir = New System.Windows.Forms.ToolStripButton
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
    Me.Grupo1 = New Janus.Windows.EditControls.UIGroupBox
    Me.txtNumDoc = New Janus.Windows.GridEX.EditControls.NumericEditBox
    Me.txtSaldoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox
    Me.txtSaldoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox
    Me.txtVencidoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox
    Me.txtVencidoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox
    Me.txtPorVencerDol = New Janus.Windows.GridEX.EditControls.NumericEditBox
    Me.txtPorVencerSol = New Janus.Windows.GridEX.EditControls.NumericEditBox
    Me.Label11 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label10 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label9 = New System.Windows.Forms.Label
    Me.txtCliente = New Janus.Windows.GridEX.EditControls.EditBox
    Me.btnBuscar = New System.Windows.Forms.Button
    Me.Label7 = New System.Windows.Forms.Label
    Me.cmbDocu = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Me.Label8 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.dgvDatos = New Janus.Windows.GridEX.GridEX
    Me.cmOpciones.SuspendLayout()
    CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ssBarra.SuspendLayout()
    Me.ToolStrip.SuspendLayout()
    CType(Me.Grupo1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Grupo1.SuspendLayout()
    CType(Me.cmbDocu, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cmOpciones
    '
    Me.cmOpciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
    Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMostrar, Me.ToolStripMenuItem1, Me.miActualizar})
    Me.cmOpciones.Name = "cmOpciones"
    Me.cmOpciones.Size = New System.Drawing.Size(143, 54)
    '
    'miMostrar
    '
    Me.miMostrar.Image = CType(resources.GetObject("miMostrar.Image"), System.Drawing.Image)
    Me.miMostrar.Name = "miMostrar"
    Me.miMostrar.Size = New System.Drawing.Size(142, 22)
    Me.miMostrar.Text = "Mostrar"
    '
    'ToolStripMenuItem1
    '
    Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
    Me.ToolStripMenuItem1.Size = New System.Drawing.Size(139, 6)
    '
    'miActualizar
    '
    Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
    Me.miActualizar.Name = "miActualizar"
    Me.miActualizar.Size = New System.Drawing.Size(142, 22)
    Me.miActualizar.Text = "Actualizar"
    '
    'ofEstiloForm
    '
    Me.ofEstiloForm.Form = Me
    Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
    '
    'ssBarra
    '
    Me.ssBarra.AutoSize = False
    Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
    Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
    Me.ssBarra.Location = New System.Drawing.Point(0, 396)
    Me.ssBarra.Name = "ssBarra"
    Me.ssBarra.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
    Me.ssBarra.Size = New System.Drawing.Size(792, 20)
    Me.ssBarra.TabIndex = 3
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
    Me.sslTotal.Size = New System.Drawing.Size(180, 15)
    Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'ToolStrip
    '
    Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
    Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biMostrar, Me.ToolStripSeparator1, Me.biActualizar, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator3})
    Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip.Name = "ToolStrip"
    Me.ToolStrip.Size = New System.Drawing.Size(792, 25)
    Me.ToolStrip.TabIndex = 0
    Me.ToolStrip.Text = "ToolStrip"
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
    '
    'biMostrar
    '
    Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.biMostrar.Image = CType(resources.GetObject("biMostrar.Image"), System.Drawing.Image)
    Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.biMostrar.Name = "biMostrar"
    Me.biMostrar.Size = New System.Drawing.Size(23, 22)
    Me.biMostrar.Text = "Mostrar los datos del registro seleccionado"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'biActualizar
    '
    Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.biActualizar.Image = CType(resources.GetObject("biActualizar.Image"), System.Drawing.Image)
    Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.biActualizar.Name = "biActualizar"
    Me.biActualizar.Size = New System.Drawing.Size(23, 22)
    Me.biActualizar.Text = "Actualizar Consulta"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'biSalir
    '
    Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.biSalir.Image = CType(resources.GetObject("biSalir.Image"), System.Drawing.Image)
    Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.biSalir.Name = "biSalir"
    Me.biSalir.Size = New System.Drawing.Size(23, 22)
    Me.biSalir.Text = "Cerrar la ventana actual"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
    '
    'Grupo1
    '
    Me.Grupo1.Controls.Add(Me.txtNumDoc)
    Me.Grupo1.Controls.Add(Me.txtSaldoDol)
    Me.Grupo1.Controls.Add(Me.txtSaldoSol)
    Me.Grupo1.Controls.Add(Me.txtVencidoDol)
    Me.Grupo1.Controls.Add(Me.txtVencidoSol)
    Me.Grupo1.Controls.Add(Me.txtPorVencerDol)
    Me.Grupo1.Controls.Add(Me.txtPorVencerSol)
    Me.Grupo1.Controls.Add(Me.Label11)
    Me.Grupo1.Controls.Add(Me.Label2)
    Me.Grupo1.Controls.Add(Me.Label10)
    Me.Grupo1.Controls.Add(Me.Label1)
    Me.Grupo1.Controls.Add(Me.Label9)
    Me.Grupo1.Controls.Add(Me.txtCliente)
    Me.Grupo1.Controls.Add(Me.btnBuscar)
    Me.Grupo1.Controls.Add(Me.Label7)
    Me.Grupo1.Controls.Add(Me.cmbDocu)
    Me.Grupo1.Controls.Add(Me.Label8)
    Me.Grupo1.Controls.Add(Me.Label3)
    Me.Grupo1.Controls.Add(Me.Label5)
    Me.Grupo1.Controls.Add(Me.Label4)
    Me.Grupo1.Controls.Add(Me.Label6)
    Me.Grupo1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Grupo1.Location = New System.Drawing.Point(0, 25)
    Me.Grupo1.Name = "Grupo1"
    Me.Grupo1.Size = New System.Drawing.Size(792, 90)
    Me.Grupo1.TabIndex = 1
    Me.Grupo1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
    '
    'txtNumDoc
    '
    Me.txtNumDoc.DecimalDigits = 0
    Me.txtNumDoc.EditMode = Janus.Windows.GridEX.NumericEditMode.Value
    Me.txtNumDoc.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
    Me.txtNumDoc.Location = New System.Drawing.Point(192, 65)
    Me.txtNumDoc.MaxLength = 10
    Me.txtNumDoc.Name = "txtNumDoc"
    Me.txtNumDoc.Size = New System.Drawing.Size(100, 20)
    Me.txtNumDoc.TabIndex = 4
    Me.txtNumDoc.Text = "0"
    Me.txtNumDoc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
    Me.txtNumDoc.Value = New Decimal(New Integer() {0, 0, 0, 0})
    Me.txtNumDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'txtSaldoDol
    '
    Me.txtSaldoDol.DecimalDigits = 2
    Me.txtSaldoDol.DisabledForeColor = System.Drawing.Color.Black
    Me.txtSaldoDol.Enabled = False
    Me.txtSaldoDol.Location = New System.Drawing.Point(685, 47)
    Me.txtSaldoDol.Name = "txtSaldoDol"
    Me.txtSaldoDol.Size = New System.Drawing.Size(100, 20)
    Me.txtSaldoDol.TabIndex = 20
    Me.txtSaldoDol.Text = "0.00"
    Me.txtSaldoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
    Me.txtSaldoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'txtSaldoSol
    '
    Me.txtSaldoSol.DecimalDigits = 2
    Me.txtSaldoSol.DisabledForeColor = System.Drawing.Color.Black
    Me.txtSaldoSol.Enabled = False
    Me.txtSaldoSol.Location = New System.Drawing.Point(685, 25)
    Me.txtSaldoSol.Name = "txtSaldoSol"
    Me.txtSaldoSol.Size = New System.Drawing.Size(100, 20)
    Me.txtSaldoSol.TabIndex = 14
    Me.txtSaldoSol.Text = "0.00"
    Me.txtSaldoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
    Me.txtSaldoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'txtVencidoDol
    '
    Me.txtVencidoDol.DecimalDigits = 2
    Me.txtVencidoDol.DisabledForeColor = System.Drawing.Color.Black
    Me.txtVencidoDol.Enabled = False
    Me.txtVencidoDol.Location = New System.Drawing.Point(570, 47)
    Me.txtVencidoDol.Name = "txtVencidoDol"
    Me.txtVencidoDol.Size = New System.Drawing.Size(100, 20)
    Me.txtVencidoDol.TabIndex = 18
    Me.txtVencidoDol.Text = "0.00"
    Me.txtVencidoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
    Me.txtVencidoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'txtVencidoSol
    '
    Me.txtVencidoSol.DecimalDigits = 2
    Me.txtVencidoSol.DisabledForeColor = System.Drawing.Color.Black
    Me.txtVencidoSol.Enabled = False
    Me.txtVencidoSol.Location = New System.Drawing.Point(570, 25)
    Me.txtVencidoSol.Name = "txtVencidoSol"
    Me.txtVencidoSol.Size = New System.Drawing.Size(100, 20)
    Me.txtVencidoSol.TabIndex = 12
    Me.txtVencidoSol.Text = "0.00"
    Me.txtVencidoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
    Me.txtVencidoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'txtPorVencerDol
    '
    Me.txtPorVencerDol.DecimalDigits = 2
    Me.txtPorVencerDol.DisabledForeColor = System.Drawing.Color.Black
    Me.txtPorVencerDol.Enabled = False
    Me.txtPorVencerDol.Location = New System.Drawing.Point(455, 47)
    Me.txtPorVencerDol.Name = "txtPorVencerDol"
    Me.txtPorVencerDol.Size = New System.Drawing.Size(100, 20)
    Me.txtPorVencerDol.TabIndex = 16
    Me.txtPorVencerDol.Text = "0.00"
    Me.txtPorVencerDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
    Me.txtPorVencerDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'txtPorVencerSol
    '
    Me.txtPorVencerSol.DecimalDigits = 2
    Me.txtPorVencerSol.DisabledForeColor = System.Drawing.Color.Black
    Me.txtPorVencerSol.Enabled = False
    Me.txtPorVencerSol.Location = New System.Drawing.Point(455, 25)
    Me.txtPorVencerSol.Name = "txtPorVencerSol"
    Me.txtPorVencerSol.Size = New System.Drawing.Size(100, 20)
    Me.txtPorVencerSol.TabIndex = 10
    Me.txtPorVencerSol.Text = "0.00"
    Me.txtPorVencerSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
    Me.txtPorVencerSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(715, 10)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(39, 13)
    Me.Label11.TabIndex = 8
    Me.Label11.Text = "Saldo"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(50, 50)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(71, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Documento"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(595, 10)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(53, 13)
    Me.Label10.TabIndex = 7
    Me.Label10.Text = "Vencido"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(30, 10)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(46, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Cliente"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(470, 10)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(70, 13)
    Me.Label9.TabIndex = 6
    Me.Label9.Text = "Por Vencer"
    '
    'txtCliente
    '
    Me.txtCliente.BackColor = System.Drawing.SystemColors.Control
    Me.txtCliente.ButtonImage = CType(resources.GetObject("txtCliente.ButtonImage"), System.Drawing.Image)
    Me.txtCliente.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
    Me.txtCliente.Location = New System.Drawing.Point(10, 25)
    Me.txtCliente.Name = "txtCliente"
    Me.txtCliente.ReadOnly = True
    Me.txtCliente.Size = New System.Drawing.Size(400, 20)
    Me.txtCliente.TabIndex = 1
    Me.txtCliente.TabStop = False
    Me.txtCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'btnBuscar
    '
    Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
    Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnBuscar.Location = New System.Drawing.Point(295, 63)
    Me.btnBuscar.Name = "btnBuscar"
    Me.btnBuscar.Size = New System.Drawing.Size(72, 25)
    Me.btnBuscar.TabIndex = 5
    Me.btnBuscar.Text = "Buscar"
    Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.btnBuscar.UseVisualStyleBackColor = True
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(670, 50)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(14, 13)
    Me.Label7.TabIndex = 19
    Me.Label7.Text = "="
    '
    'cmbDocu
    '
    Me.cmbDocu.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
    cmbDocu_DesignTimeLayout.LayoutString = resources.GetString("cmbDocu_DesignTimeLayout.LayoutString")
    Me.cmbDocu.DesignTimeLayout = cmbDocu_DesignTimeLayout
    Me.cmbDocu.Location = New System.Drawing.Point(30, 65)
    Me.cmbDocu.Name = "cmbDocu"
    Me.cmbDocu.SelectedIndex = -1
    Me.cmbDocu.SelectedItem = Nothing
    Me.cmbDocu.Size = New System.Drawing.Size(160, 20)
    Me.cmbDocu.TabIndex = 3
    Me.cmbDocu.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
    Me.cmbDocu.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(670, 28)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(14, 13)
    Me.Label8.TabIndex = 13
    Me.Label8.Text = "="
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(417, 28)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(25, 13)
    Me.Label3.TabIndex = 9
    Me.Label3.Text = "S/."
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(555, 50)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(14, 13)
    Me.Label5.TabIndex = 17
    Me.Label5.Text = "+"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(417, 50)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(35, 13)
    Me.Label4.TabIndex = 15
    Me.Label4.Text = "US $"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(555, 28)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(14, 13)
    Me.Label6.TabIndex = 11
    Me.Label6.Text = "+"
    '
    'dgvDatos
    '
    Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
    dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
    Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
    Me.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.dgvDatos.GroupByBoxVisible = False
    Me.dgvDatos.Location = New System.Drawing.Point(0, 115)
    Me.dgvDatos.Name = "dgvDatos"
    Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
    Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
    Me.dgvDatos.Size = New System.Drawing.Size(792, 281)
    Me.dgvDatos.TabIndex = 2
    Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '
    'frmDocs_Creditos
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(792, 416)
    Me.Controls.Add(Me.dgvDatos)
    Me.Controls.Add(Me.Grupo1)
    Me.Controls.Add(Me.ssBarra)
    Me.Controls.Add(Me.ToolStrip)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "frmDocs_Creditos"
    Me.Text = "Consulta de Documentos de Créditos"
    Me.cmOpciones.ResumeLayout(False)
    CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ssBarra.ResumeLayout(False)
    Me.ssBarra.PerformLayout()
    Me.ToolStrip.ResumeLayout(False)
    Me.ToolStrip.PerformLayout()
    CType(Me.Grupo1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Grupo1.ResumeLayout(False)
    Me.Grupo1.PerformLayout()
    CType(Me.cmbDocu, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
  Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
  Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
  Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
  Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
  Friend WithEvents Grupo1 As Janus.Windows.EditControls.UIGroupBox
  Friend WithEvents cmbDocu As Janus.Windows.GridEX.EditControls.MultiColumnCombo
  Friend WithEvents btnBuscar As System.Windows.Forms.Button
  Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
  Friend WithEvents txtCliente As Janus.Windows.GridEX.EditControls.EditBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txtPorVencerDol As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents txtPorVencerSol As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents txtSaldoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents txtSaldoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents txtVencidoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents txtVencidoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
  Friend WithEvents txtNumDoc As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
