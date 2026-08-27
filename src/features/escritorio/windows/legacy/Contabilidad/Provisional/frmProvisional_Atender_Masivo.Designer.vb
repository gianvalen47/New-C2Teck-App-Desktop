<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProvisional_Atender_Masivo
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
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProvisional_Atender_Masivo))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAtender = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cIdProvisional = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdUbicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNomUbicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cIdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAbrMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotEntega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cViatico = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cIdEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbAtender = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNinguno = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 314)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(805, 20)
        Me.ssBarra.TabIndex = 41
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(350, 15)
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
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biImprimir, Me.ToolStripSeparator1, Me.biAtender, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator3})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(805, 31)
        Me.ToolStrip.TabIndex = 43
        Me.ToolStrip.Text = "ToolStrip"
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
        Me.biImprimir.Text = "Imprimir Listado de Provisionales"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biAtender
        '
        Me.biAtender.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAtender.Image = CType(resources.GetObject("biAtender.Image"), System.Drawing.Image)
        Me.biAtender.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAtender.Name = "biAtender"
        Me.biAtender.Size = New System.Drawing.Size(28, 28)
        Me.biAtender.Text = "Atender Provisionales Seleccionados"
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
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdProvisional, Me.cIdUbicacion, Me.cNomUbicacion, Me.cCodArea, Me.cDesArea, Me.cIdPer, Me.cApeNom, Me.cFecha, Me.cCodJob, Me.cMotivo, Me.cCodMon, Me.cDesMon, Me.cAbrMon, Me.cTotEntega, Me.cObservacion, Me.cViatico, Me.cIdEstado, Me.cDesEstado, Me.cCodUsu, Me.cbAtender})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.Location = New System.Drawing.Point(6, 91)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(793, 213)
        Me.dgvDatos.TabIndex = 189
        '
        'cIdProvisional
        '
        Me.cIdProvisional.HeaderText = "Código"
        Me.cIdProvisional.Name = "cIdProvisional"
        Me.cIdProvisional.ReadOnly = True
        Me.cIdProvisional.Width = 50
        '
        'cIdUbicacion
        '
        Me.cIdUbicacion.HeaderText = "IdUbicacion"
        Me.cIdUbicacion.Name = "cIdUbicacion"
        Me.cIdUbicacion.ReadOnly = True
        Me.cIdUbicacion.Visible = False
        Me.cIdUbicacion.Width = 80
        '
        'cNomUbicacion
        '
        Me.cNomUbicacion.HeaderText = "Ubicación"
        Me.cNomUbicacion.Name = "cNomUbicacion"
        Me.cNomUbicacion.ReadOnly = True
        Me.cNomUbicacion.Width = 80
        '
        'cCodArea
        '
        Me.cCodArea.HeaderText = "CodArea"
        Me.cCodArea.Name = "cCodArea"
        Me.cCodArea.ReadOnly = True
        Me.cCodArea.Visible = False
        '
        'cDesArea
        '
        Me.cDesArea.HeaderText = "Área"
        Me.cDesArea.Name = "cDesArea"
        Me.cDesArea.ReadOnly = True
        Me.cDesArea.Width = 90
        '
        'cIdPer
        '
        Me.cIdPer.HeaderText = "IdPer"
        Me.cIdPer.Name = "cIdPer"
        Me.cIdPer.ReadOnly = True
        Me.cIdPer.Visible = False
        '
        'cApeNom
        '
        Me.cApeNom.HeaderText = "Solicitante"
        Me.cApeNom.Name = "cApeNom"
        Me.cApeNom.ReadOnly = True
        Me.cApeNom.Width = 120
        '
        'cFecha
        '
        Me.cFecha.HeaderText = "Fecha"
        Me.cFecha.Name = "cFecha"
        Me.cFecha.ReadOnly = True
        Me.cFecha.Width = 80
        '
        'cCodJob
        '
        Me.cCodJob.HeaderText = "Job"
        Me.cCodJob.Name = "cCodJob"
        Me.cCodJob.ReadOnly = True
        Me.cCodJob.Visible = False
        Me.cCodJob.Width = 50
        '
        'cMotivo
        '
        Me.cMotivo.HeaderText = "Motivo"
        Me.cMotivo.Name = "cMotivo"
        Me.cMotivo.ReadOnly = True
        '
        'cCodMon
        '
        Me.cCodMon.HeaderText = "Mon."
        Me.cCodMon.Name = "cCodMon"
        Me.cCodMon.ReadOnly = True
        Me.cCodMon.Width = 40
        '
        'cDesMon
        '
        Me.cDesMon.HeaderText = "DesMon"
        Me.cDesMon.Name = "cDesMon"
        Me.cDesMon.ReadOnly = True
        Me.cDesMon.Visible = False
        '
        'cAbrMon
        '
        Me.cAbrMon.HeaderText = "AbrMon"
        Me.cAbrMon.Name = "cAbrMon"
        Me.cAbrMon.ReadOnly = True
        Me.cAbrMon.Visible = False
        '
        'cTotEntega
        '
        Me.cTotEntega.HeaderText = "Total Ent."
        Me.cTotEntega.Name = "cTotEntega"
        Me.cTotEntega.ReadOnly = True
        Me.cTotEntega.Width = 80
        '
        'cObservacion
        '
        Me.cObservacion.HeaderText = "Observacion"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.ReadOnly = True
        Me.cObservacion.Visible = False
        '
        'cViatico
        '
        Me.cViatico.HeaderText = "Viatico"
        Me.cViatico.Name = "cViatico"
        Me.cViatico.ReadOnly = True
        Me.cViatico.Visible = False
        '
        'cIdEstado
        '
        Me.cIdEstado.HeaderText = "IdEstado"
        Me.cIdEstado.Name = "cIdEstado"
        Me.cIdEstado.ReadOnly = True
        Me.cIdEstado.Visible = False
        '
        'cDesEstado
        '
        Me.cDesEstado.HeaderText = "DesEstado"
        Me.cDesEstado.Name = "cDesEstado"
        Me.cDesEstado.ReadOnly = True
        Me.cDesEstado.Visible = False
        '
        'cCodUsu
        '
        Me.cCodUsu.HeaderText = "Aprobado Por"
        Me.cCodUsu.Name = "cCodUsu"
        Me.cCodUsu.ReadOnly = True
        Me.cCodUsu.Width = 70
        '
        'cbAtender
        '
        Me.cbAtender.FalseValue = ""
        Me.cbAtender.HeaderText = "Aten"
        Me.cbAtender.Name = "cbAtender"
        Me.cbAtender.Width = 40
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
        Me.TextBox1.Location = New System.Drawing.Point(460, 29)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 190
        Me.TextBox1.Visible = False
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.Location = New System.Drawing.Point(172, 29)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(77, 20)
        Me.cmbMoneda.TabIndex = 192
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(183, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "Moneda"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.TextBox1)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 31)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(793, 54)
        Me.UiGroupBox1.TabIndex = 193
        Me.UiGroupBox1.Text = "Datos de Busqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(690, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
        Me.btnBuscar.TabIndex = 193
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'frmProvisional_Atender_Masivo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(805, 334)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProvisional_Atender_Masivo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atender Provisionales de Viático Másivo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biAtender As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents cIdProvisional As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdUbicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNomUbicacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdPer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodJob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMotivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodMon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesMon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cAbrMon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotEntega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cViatico As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cIdEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbAtender As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miNinguno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
