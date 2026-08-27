<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarioLocaciones
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
        Dim cmdOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim cmbEmpresa_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarioLocaciones))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmdOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRegresarTodos = New System.Windows.Forms.Button()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cIdLocacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesAlm1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvLocaciones = New System.Windows.Forms.DataGridView()
        Me.cIdLocacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesAlm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLocaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmdOficina
        '
        Me.cmdOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmdOficina_DesignTimeLayout.LayoutString = resources.GetString("cmdOficina_DesignTimeLayout.LayoutString")
        Me.cmdOficina.DesignTimeLayout = cmdOficina_DesignTimeLayout
        Me.cmdOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOficina.Location = New System.Drawing.Point(394, 30)
        Me.cmdOficina.Name = "cmdOficina"
        Me.cmdOficina.SelectedIndex = -1
        Me.cmdOficina.SelectedItem = Nothing
        Me.cmdOficina.Size = New System.Drawing.Size(154, 20)
        Me.cmdOficina.TabIndex = 18
        Me.cmdOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnGuardar, Me.ToolStripSeparator3, Me.btnCerrar, Me.ToolStripSeparator4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(628, 25)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'btnRegresarTodos
        '
        Me.btnRegresarTodos.Image = Global.SIGECOM.My.Resources.Resources.Izquierda
        Me.btnRegresarTodos.Location = New System.Drawing.Point(287, 251)
        Me.btnRegresarTodos.Name = "btnRegresarTodos"
        Me.btnRegresarTodos.Size = New System.Drawing.Size(50, 27)
        Me.btnRegresarTodos.TabIndex = 16
        Me.btnRegresarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(287, 203)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(50, 27)
        Me.btnAgregarTodos.TabIndex = 15
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.SIGECOM.My.Resources.Resources.Regresar
        Me.btnRegresar.Location = New System.Drawing.Point(287, 161)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(50, 27)
        Me.btnRegresar.TabIndex = 14
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(287, 117)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(50, 27)
        Me.btnAgregar.TabIndex = 13
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdLocacion1, Me.cDesAlm1})
        Me.dgvSeleccionados.Location = New System.Drawing.Point(351, 63)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.RowHeadersWidth = 25
        Me.dgvSeleccionados.Size = New System.Drawing.Size(267, 264)
        Me.dgvSeleccionados.TabIndex = 12
        '
        'cIdLocacion1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cIdLocacion1.DefaultCellStyle = DataGridViewCellStyle1
        Me.cIdLocacion1.HeaderText = "Código"
        Me.cIdLocacion1.Name = "cIdLocacion1"
        Me.cIdLocacion1.Width = 50
        '
        'cDesAlm1
        '
        Me.cDesAlm1.HeaderText = "Descripción"
        Me.cDesAlm1.Name = "cDesAlm1"
        Me.cDesAlm1.Width = 213
        '
        'dgvLocaciones
        '
        Me.dgvLocaciones.AllowUserToAddRows = False
        Me.dgvLocaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLocaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdLocacion, Me.cDesAlm})
        Me.dgvLocaciones.Location = New System.Drawing.Point(7, 63)
        Me.dgvLocaciones.Name = "dgvLocaciones"
        Me.dgvLocaciones.RowHeadersVisible = False
        Me.dgvLocaciones.RowHeadersWidth = 25
        Me.dgvLocaciones.Size = New System.Drawing.Size(267, 264)
        Me.dgvLocaciones.TabIndex = 11
        '
        'cIdLocacion
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.cIdLocacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.cIdLocacion.HeaderText = "Código"
        Me.cIdLocacion.Name = "cIdLocacion"
        Me.cIdLocacion.Width = 50
        '
        'cDesAlm
        '
        Me.cDesAlm.HeaderText = "Descripción"
        Me.cDesAlm.Name = "cDesAlm"
        Me.cDesAlm.Width = 213
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(345, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Oficina :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Empresa :"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEmpresa_DesignTimeLayout.LayoutString = resources.GetString("cmbEmpresa_DesignTimeLayout.LayoutString")
        Me.cmbEmpresa.DesignTimeLayout = cmbEmpresa_DesignTimeLayout
        Me.cmbEmpresa.Location = New System.Drawing.Point(61, 30)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.SelectedIndex = -1
        Me.cmbEmpresa.SelectedItem = Nothing
        Me.cmbEmpresa.Size = New System.Drawing.Size(276, 20)
        Me.cmbEmpresa.TabIndex = 58
        Me.cmbEmpresa.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmUsuarioLocaciones
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(628, 364)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbEmpresa)
        Me.Controls.Add(Me.cmdOficina)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnRegresarTodos)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.Controls.Add(Me.dgvLocaciones)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuarioLocaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Locaciones"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOficina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLocaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmdOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRegresarTodos As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents dgvLocaciones As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cIdLocacion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesAlm1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdLocacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesAlm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbEmpresa As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
