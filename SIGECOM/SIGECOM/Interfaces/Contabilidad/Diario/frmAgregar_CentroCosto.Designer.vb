<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregar_CentroCosto
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
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregar_CentroCosto))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cCodCentro1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCentro1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoSol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cMontoDol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblPersonal = New System.Windows.Forms.Label()
        Me.dgvCentroCosto = New System.Windows.Forms.DataGridView()
        Me.cCodCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCentro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbProrratear = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMontoSoles = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoDolares = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGenerar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.cmbArea)
        Me.gbDatosBusqueda.Controls.Add(Me.Label7)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(7, 24)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(798, 56)
        Me.gbDatosBusqueda.TabIndex = 1
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(237, 30)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(166, 20)
        Me.cmbArea.TabIndex = 192
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(300, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 193
        Me.Label7.Text = "Area"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(551, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 25)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(234, 215)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregarTodos.TabIndex = 293
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(234, 171)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 23)
        Me.btnAgregar.TabIndex = 291
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(279, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 290
        Me.Label1.Text = "Seleccionados"
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodCentro1, Me.cDesCentro1, Me.cMontoSol, Me.cMontoDol, Me.cObservacion})
        Me.dgvSeleccionados.ContextMenuStrip = Me.cmbOpciones
        Me.dgvSeleccionados.Location = New System.Drawing.Point(282, 109)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(523, 177)
        Me.dgvSeleccionados.TabIndex = 289
        '
        'cCodCentro1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodCentro1.DefaultCellStyle = DataGridViewCellStyle5
        Me.cCodCentro1.HeaderText = "Cod."
        Me.cCodCentro1.Name = "cCodCentro1"
        Me.cCodCentro1.ReadOnly = True
        Me.cCodCentro1.Width = 43
        '
        'cDesCentro1
        '
        Me.cDesCentro1.HeaderText = "Centro Costo"
        Me.cDesCentro1.Name = "cDesCentro1"
        Me.cDesCentro1.ReadOnly = True
        Me.cDesCentro1.Width = 165
        '
        'cMontoSol
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N5"
        DataGridViewCellStyle6.NullValue = "0.00000"
        Me.cMontoSol.DefaultCellStyle = DataGridViewCellStyle6
        Me.cMontoSol.HeaderText = "MontoSol"
        Me.cMontoSol.Name = "cMontoSol"
        Me.cMontoSol.Width = 90
        '
        'cMontoDol
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.Format = "N5"
        DataGridViewCellStyle7.NullValue = "0.00000"
        Me.cMontoDol.DefaultCellStyle = DataGridViewCellStyle7
        Me.cMontoDol.HeaderText = "MontoDol"
        Me.cMontoDol.Name = "cMontoDol"
        Me.cMontoDol.Width = 90
        '
        'cObservacion
        '
        Me.cObservacion.HeaderText = "Observación"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.Width = 115
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEliminar})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(118, 26)
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(117, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPersonal.Location = New System.Drawing.Point(4, 89)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(116, 15)
        Me.lblPersonal.TabIndex = 288
        Me.lblPersonal.Text = "Centros de Costo"
        '
        'dgvCentroCosto
        '
        Me.dgvCentroCosto.AllowUserToAddRows = False
        Me.dgvCentroCosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCentroCosto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodCentro, Me.cDesCentro})
        Me.dgvCentroCosto.Location = New System.Drawing.Point(7, 110)
        Me.dgvCentroCosto.Name = "dgvCentroCosto"
        Me.dgvCentroCosto.RowHeadersVisible = False
        Me.dgvCentroCosto.Size = New System.Drawing.Size(221, 177)
        Me.dgvCentroCosto.TabIndex = 287
        '
        'cCodCentro
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodCentro.DefaultCellStyle = DataGridViewCellStyle8
        Me.cCodCentro.HeaderText = "Cod."
        Me.cCodCentro.Name = "cCodCentro"
        Me.cCodCentro.ReadOnly = True
        Me.cCodCentro.Width = 43
        '
        'cDesCentro
        '
        Me.cDesCentro.HeaderText = "Centro Costo"
        Me.cDesCentro.Name = "cDesCentro"
        Me.cDesCentro.ReadOnly = True
        Me.cDesCentro.Width = 175
        '
        'cbProrratear
        '
        Me.cbProrratear.AutoSize = True
        Me.cbProrratear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProrratear.Location = New System.Drawing.Point(538, 89)
        Me.cbProrratear.Name = "cbProrratear"
        Me.cbProrratear.Size = New System.Drawing.Size(82, 17)
        Me.cbProrratear.TabIndex = 294
        Me.cbProrratear.Text = "Prorratear"
        Me.cbProrratear.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(489, 297)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 300
        Me.Label8.Text = "Monto Soles"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(617, 297)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 299
        Me.Label2.Text = "Monto Dolares"
        '
        'txtMontoSoles
        '
        Me.txtMontoSoles.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoSoles.DisabledForeColor = System.Drawing.SystemColors.MenuText
        Me.txtMontoSoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSoles.FormatString = "#0.00"
        Me.txtMontoSoles.Location = New System.Drawing.Point(463, 313)
        Me.txtMontoSoles.Name = "txtMontoSoles"
        Me.txtMontoSoles.ReadOnly = True
        Me.txtMontoSoles.Size = New System.Drawing.Size(125, 20)
        Me.txtMontoSoles.TabIndex = 298
        Me.txtMontoSoles.TabStop = False
        Me.txtMontoSoles.Text = "0.00"
        Me.txtMontoSoles.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoSoles.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMontoDolares
        '
        Me.txtMontoDolares.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoDolares.DisabledForeColor = System.Drawing.SystemColors.InfoText
        Me.txtMontoDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoDolares.FormatString = "#0.00"
        Me.txtMontoDolares.Location = New System.Drawing.Point(599, 313)
        Me.txtMontoDolares.Name = "txtMontoDolares"
        Me.txtMontoDolares.ReadOnly = True
        Me.txtMontoDolares.Size = New System.Drawing.Size(125, 20)
        Me.txtMontoDolares.TabIndex = 297
        Me.txtMontoDolares.TabStop = False
        Me.txtMontoDolares.Text = "0.00"
        Me.txtMontoDolares.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoDolares.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.btnGenerar, Me.ToolStripSeparator2, Me.btnCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(813, 27)
        Me.ToolStrip1.TabIndex = 301
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'btnGenerar
        '
        Me.btnGenerar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(24, 24)
        Me.btnGenerar.Text = "Asignar Centros de Costo Seleccionados"
        Me.btnGenerar.ToolTipText = "Asignar Centros de Costo Seleccionados"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'btnCerrar
        '
        Me.btnCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(24, 24)
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'frmAgregar_CentroCosto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(813, 343)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.cbProrratear)
        Me.Controls.Add(Me.txtMontoSoles)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMontoDolares)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvCentroCosto)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregar_CentroCosto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Centro de Costo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.dgvCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents dgvCentroCosto As System.Windows.Forms.DataGridView
    Friend WithEvents cbProrratear As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMontoSoles As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoDolares As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGenerar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cCodCentro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodCentro1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMontoSol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cMontoDol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
