<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreMarcacion_Aprobar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreMarcacion_Aprobar))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAProbar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNinguno = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.chkPersona = New System.Windows.Forms.CheckBox()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.cIdPreMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAbrPer2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cHoraIngreso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cHoraSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbAprobar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cEnv = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cAprob = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biImprimir, Me.ToolStripSeparator1, Me.biAProbar, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator3})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(822, 31)
        Me.ToolStrip.TabIndex = 45
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator4.Visible = False
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Listado de Provisionales"
        Me.biImprimir.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biAProbar
        '
        Me.biAProbar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAProbar.Image = CType(resources.GetObject("biAProbar.Image"), System.Drawing.Image)
        Me.biAProbar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAProbar.Name = "biAProbar"
        Me.biAProbar.Size = New System.Drawing.Size(28, 28)
        Me.biAProbar.Text = "Aprobar Pre Marcaciones Seleccionados"
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 345)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(822, 20)
        Me.ssBarra.TabIndex = 44
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
        Me.sslTotal.Size = New System.Drawing.Size(141, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodos, Me.ToolStripSeparator5, Me.miNinguno, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(169, 82)
        '
        'miSeleccionarTodos
        '
        Me.miSeleccionarTodos.Image = CType(resources.GetObject("miSeleccionarTodos.Image"), System.Drawing.Image)
        Me.miSeleccionarTodos.Name = "miSeleccionarTodos"
        Me.miSeleccionarTodos.Size = New System.Drawing.Size(168, 22)
        Me.miSeleccionarTodos.Text = "Seleccionar Todos"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(165, 6)
        '
        'miNinguno
        '
        Me.miNinguno.Image = CType(resources.GetObject("miNinguno.Image"), System.Drawing.Image)
        Me.miNinguno.Name = "miNinguno"
        Me.miNinguno.Size = New System.Drawing.Size(168, 22)
        Me.miNinguno.Text = "Ninguno"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(168, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(679, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 191
        Me.TextBox1.Visible = False
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdPreMarca, Me.cIdPer, Me.cAbrPer2, Me.cApeNom, Me.cCodJob, Me.cFecha, Me.cHoraIngreso, Me.cHoraSalida, Me.cObservacion, Me.cbAprobar, Me.cEnv, Me.cAprob})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.Location = New System.Drawing.Point(5, 96)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(793, 227)
        Me.dgvDatos.TabIndex = 192
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.chkPersona)
        Me.UiGroupBox1.Controls.Add(Me.lblPersona)
        Me.UiGroupBox1.Controls.Add(Me.TextBox1)
        Me.UiGroupBox1.Controls.Add(Me.txtSolicitante)
        Me.UiGroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPersona)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 33)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(793, 57)
        Me.UiGroupBox1.TabIndex = 225
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(536, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 224
        Me.Label5.Text = "Nro. OT"
        '
        'txtNumJob
        '
        Me.txtNumJob.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumJob.Location = New System.Drawing.Point(503, 30)
        Me.txtNumJob.MaxLength = 20
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(120, 20)
        Me.txtNumJob.TabIndex = 3
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(692, 28)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 23)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'chkPersona
        '
        Me.chkPersona.AutoSize = True
        Me.chkPersona.Checked = True
        Me.chkPersona.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPersona.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPersona.Location = New System.Drawing.Point(236, 13)
        Me.chkPersona.Name = "chkPersona"
        Me.chkPersona.Size = New System.Drawing.Size(15, 14)
        Me.chkPersona.TabIndex = 213
        Me.chkPersona.Tag = ""
        Me.chkPersona.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkPersona.UseVisualStyleBackColor = True
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersona.Location = New System.Drawing.Point(162, 14)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(75, 13)
        Me.lblPersona.TabIndex = 212
        Me.lblPersona.Text = "Colaborador"
        '
        'txtSolicitante
        '
        Me.txtSolicitante.BackColor = System.Drawing.SystemColors.Window
        Me.txtSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicitante.Location = New System.Drawing.Point(37, 30)
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.ReadOnly = True
        Me.txtSolicitante.Size = New System.Drawing.Size(380, 20)
        Me.txtSolicitante.TabIndex = 1
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(257, 9)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 214
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(423, 28)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarPersona.TabIndex = 2
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'cIdPreMarca
        '
        Me.cIdPreMarca.HeaderText = "Cod."
        Me.cIdPreMarca.Name = "cIdPreMarca"
        Me.cIdPreMarca.ReadOnly = True
        Me.cIdPreMarca.Width = 35
        '
        'cIdPer
        '
        Me.cIdPer.HeaderText = "IdPer"
        Me.cIdPer.Name = "cIdPer"
        Me.cIdPer.ReadOnly = True
        Me.cIdPer.Visible = False
        '
        'cAbrPer2
        '
        Me.cAbrPer2.HeaderText = "cAbrPer2"
        Me.cAbrPer2.Name = "cAbrPer2"
        Me.cAbrPer2.ReadOnly = True
        Me.cAbrPer2.Visible = False
        Me.cAbrPer2.Width = 75
        '
        'cApeNom
        '
        Me.cApeNom.HeaderText = "Solicitante"
        Me.cApeNom.Name = "cApeNom"
        Me.cApeNom.ReadOnly = True
        Me.cApeNom.Width = 190
        '
        'cCodJob
        '
        Me.cCodJob.HeaderText = "OT"
        Me.cCodJob.Name = "cCodJob"
        Me.cCodJob.ReadOnly = True
        Me.cCodJob.Width = 50
        '
        'cFecha
        '
        Me.cFecha.HeaderText = "Fecha"
        Me.cFecha.Name = "cFecha"
        Me.cFecha.ReadOnly = True
        Me.cFecha.Width = 75
        '
        'cHoraIngreso
        '
        Me.cHoraIngreso.HeaderText = "Hora Ingreso"
        Me.cHoraIngreso.Name = "cHoraIngreso"
        Me.cHoraIngreso.ReadOnly = True
        Me.cHoraIngreso.Width = 90
        '
        'cHoraSalida
        '
        Me.cHoraSalida.HeaderText = "Hora Salida"
        Me.cHoraSalida.Name = "cHoraSalida"
        Me.cHoraSalida.ReadOnly = True
        Me.cHoraSalida.Width = 85
        '
        'cObservacion
        '
        Me.cObservacion.HeaderText = "Observacion"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.ReadOnly = True
        Me.cObservacion.Width = 165
        '
        'cbAprobar
        '
        Me.cbAprobar.FalseValue = ""
        Me.cbAprobar.HeaderText = "AProb"
        Me.cbAprobar.Name = "cbAprobar"
        Me.cbAprobar.Width = 40
        '
        'cEnv
        '
        Me.cEnv.HeaderText = "Enviado"
        Me.cEnv.Name = "cEnv"
        Me.cEnv.Visible = False
        '
        'cAprob
        '
        Me.cAprob.HeaderText = "Aprobado"
        Me.cAprob.Name = "cAprob"
        Me.cAprob.Visible = False
        '
        'frmPreMarcacion_Aprobar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(822, 365)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPreMarcacion_Aprobar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aprobar Pre Marcaciones Masivo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biAProbar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miNinguno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents chkPersona As System.Windows.Forms.CheckBox
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents txtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents cEnviado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cAprobado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cIdPreMarca As DataGridViewTextBoxColumn
    Friend WithEvents cIdPer As DataGridViewTextBoxColumn
    Friend WithEvents cAbrPer2 As DataGridViewTextBoxColumn
    Friend WithEvents cApeNom As DataGridViewTextBoxColumn
    Friend WithEvents cCodJob As DataGridViewTextBoxColumn
    Friend WithEvents cFecha As DataGridViewTextBoxColumn
    Friend WithEvents cHoraIngreso As DataGridViewTextBoxColumn
    Friend WithEvents cHoraSalida As DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As DataGridViewTextBoxColumn
    Friend WithEvents cbAprobar As DataGridViewCheckBoxColumn
    Friend WithEvents cEnv As DataGridViewCheckBoxColumn
    Friend WithEvents cAprob As DataGridViewCheckBoxColumn
End Class
