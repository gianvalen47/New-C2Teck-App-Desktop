<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarioCentrosCosto
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
        Dim cmbCodArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarioCentrosCosto))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.cmbCodArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnRegresarTodos = New System.Windows.Forms.Button
        Me.btnAgregarTodos = New System.Windows.Forms.Button
        Me.btnRegresar = New System.Windows.Forms.Button
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView
        Me.cCodCentro1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cDesCentro1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvCentros = New System.Windows.Forms.DataGridView
        Me.cCodCentro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cDesCentro = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCentros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btnGuardar, Me.ToolStripSeparator3, Me.btnCerrar, Me.ToolStripSeparator4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(626, 25)
        Me.ToolStrip1.TabIndex = 25
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 22)
        Me.btnGuardar.Text = "ToolStripButton1"
        Me.btnGuardar.ToolTipText = "Guardar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnCerrar
        '
        Me.btnCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(23, 22)
        Me.btnCerrar.Text = "ToolStripButton1"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'cmbCodArea
        '
        Me.cmbCodArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbCodArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodArea_DesignTimeLayout.LayoutString = resources.GetString("cmbCodArea_DesignTimeLayout.LayoutString")
        Me.cmbCodArea.DesignTimeLayout = cmbCodArea_DesignTimeLayout
        Me.cmbCodArea.Location = New System.Drawing.Point(85, 30)
        Me.cmbCodArea.Name = "cmbCodArea"
        Me.cmbCodArea.SelectedIndex = -1
        Me.cmbCodArea.SelectedItem = Nothing
        Me.cmbCodArea.Size = New System.Drawing.Size(134, 20)
        Me.cmbCodArea.TabIndex = 290
        Me.cmbCodArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 291
        Me.Label7.Text = "Area :"
        '
        'btnRegresarTodos
        '
        Me.btnRegresarTodos.Image = Global.SIGECOM.My.Resources.Resources.Izquierda
        Me.btnRegresarTodos.Location = New System.Drawing.Point(287, 251)
        Me.btnRegresarTodos.Name = "btnRegresarTodos"
        Me.btnRegresarTodos.Size = New System.Drawing.Size(50, 27)
        Me.btnRegresarTodos.TabIndex = 297
        Me.btnRegresarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(287, 206)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(50, 27)
        Me.btnAgregarTodos.TabIndex = 296
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.SIGECOM.My.Resources.Resources.Regresar
        Me.btnRegresar.Location = New System.Drawing.Point(287, 161)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(50, 27)
        Me.btnRegresar.TabIndex = 295
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(287, 117)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(50, 27)
        Me.btnAgregar.TabIndex = 294
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodCentro1, Me.cDesCentro1})
        Me.dgvSeleccionados.Location = New System.Drawing.Point(351, 63)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.RowHeadersWidth = 25
        Me.dgvSeleccionados.Size = New System.Drawing.Size(267, 264)
        Me.dgvSeleccionados.TabIndex = 293
        '
        'cCodCentro1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cCodCentro1.DefaultCellStyle = DataGridViewCellStyle1
        Me.cCodCentro1.HeaderText = "Código"
        Me.cCodCentro1.Name = "cCodCentro1"
        Me.cCodCentro1.Width = 50
        '
        'cDesCentro1
        '
        Me.cDesCentro1.HeaderText = "Descripción"
        Me.cDesCentro1.Name = "cDesCentro1"
        Me.cDesCentro1.Width = 213
        '
        'dgvCentros
        '
        Me.dgvCentros.AllowUserToAddRows = False
        Me.dgvCentros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCentros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodCentro, Me.cDesCentro})
        Me.dgvCentros.Location = New System.Drawing.Point(7, 63)
        Me.dgvCentros.Name = "dgvCentros"
        Me.dgvCentros.RowHeadersVisible = False
        Me.dgvCentros.RowHeadersWidth = 25
        Me.dgvCentros.Size = New System.Drawing.Size(267, 264)
        Me.dgvCentros.TabIndex = 292
        '
        'cCodCentro
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cCodCentro.DefaultCellStyle = DataGridViewCellStyle2
        Me.cCodCentro.HeaderText = "Código"
        Me.cCodCentro.Name = "cCodCentro"
        Me.cCodCentro.Width = 50
        '
        'cDesCentro
        '
        Me.cDesCentro.HeaderText = "Descripción"
        Me.cDesCentro.Name = "cDesCentro"
        Me.cDesCentro.Width = 213
        '
        'frmUsuarioCentrosCosto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(626, 335)
        Me.Controls.Add(Me.btnRegresarTodos)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.dgvCentros)
        Me.Controls.Add(Me.cmbCodArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuarioCentrosCosto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Centros de Costo"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCentros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbCodArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnRegresarTodos As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCentros As System.Windows.Forms.DataGridView
    Friend WithEvents cCodCentro1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodCentro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesCentro As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
