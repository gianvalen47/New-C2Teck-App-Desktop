<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarPerfil
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
        Dim cmbMenu_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignarPerfil))
        Me.dgvSeleccionados = New System.Windows.Forms.DataGridView()
        Me.cIdOpcion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesOpc11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRegresarTodos = New System.Windows.Forms.Button()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMenu = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.CachedrpDiarioAlmacenTotales1 = New SIGECOM.CachedrpDiarioAlmacenTotales()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvOpciones = New System.Windows.Forms.DataGridView()
        Me.cIdOpcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesOpc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.cmbMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSeleccionados
        '
        Me.dgvSeleccionados.AllowUserToAddRows = False
        Me.dgvSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdOpcion1, Me.cDesOpc11})
        Me.dgvSeleccionados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvSeleccionados.Location = New System.Drawing.Point(386, 63)
        Me.dgvSeleccionados.Name = "dgvSeleccionados"
        Me.dgvSeleccionados.RowHeadersVisible = False
        Me.dgvSeleccionados.Size = New System.Drawing.Size(310, 298)
        Me.dgvSeleccionados.TabIndex = 1
        '
        'cIdOpcion1
        '
        Me.cIdOpcion1.HeaderText = "Codigo"
        Me.cIdOpcion1.Name = "cIdOpcion1"
        Me.cIdOpcion1.Width = 50
        '
        'cDesOpc11
        '
        Me.cDesOpc11.HeaderText = "Descripcion"
        Me.cDesOpc11.Name = "cDesOpc11"
        Me.cDesOpc11.Width = 240
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBorrar, Me.ToolStripSeparator3, Me.btnGuardar, Me.ToolStripSeparator2, Me.btnCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(724, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnBorrar
        '
        Me.btnBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBorrar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.btnBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(23, 22)
        Me.btnBorrar.Text = "ToolStripButton2"
        Me.btnBorrar.ToolTipText = "Borrar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnRegresarTodos
        '
        Me.btnRegresarTodos.Image = Global.SIGECOM.My.Resources.Resources.Izquierda
        Me.btnRegresarTodos.Location = New System.Drawing.Point(328, 251)
        Me.btnRegresarTodos.Name = "btnRegresarTodos"
        Me.btnRegresarTodos.Size = New System.Drawing.Size(50, 27)
        Me.btnRegresarTodos.TabIndex = 5
        Me.btnRegresarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(328, 206)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(50, 27)
        Me.btnAgregarTodos.TabIndex = 4
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.SIGECOM.My.Resources.Resources.Regresar
        Me.btnRegresar.Location = New System.Drawing.Point(328, 161)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(50, 27)
        Me.btnRegresar.TabIndex = 3
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(328, 117)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(50, 27)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Menú :"
        '
        'cmbMenu
        '
        Me.cmbMenu.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMenu_DesignTimeLayout.LayoutString = resources.GetString("cmbMenu_DesignTimeLayout.LayoutString")
        Me.cmbMenu.DesignTimeLayout = cmbMenu_DesignTimeLayout
        Me.cmbMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMenu.Location = New System.Drawing.Point(85, 30)
        Me.cmbMenu.Name = "cmbMenu"
        Me.cmbMenu.SelectedIndex = -1
        Me.cmbMenu.SelectedItem = Nothing
        Me.cmbMenu.Size = New System.Drawing.Size(136, 20)
        Me.cmbMenu.TabIndex = 10
        Me.cmbMenu.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvOpciones
        '
        Me.dgvOpciones.AllowUserToAddRows = False
        Me.dgvOpciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdOpcion, Me.cDesOpc1})
        Me.dgvOpciones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvOpciones.Location = New System.Drawing.Point(10, 61)
        Me.dgvOpciones.Name = "dgvOpciones"
        Me.dgvOpciones.RowHeadersVisible = False
        Me.dgvOpciones.Size = New System.Drawing.Size(310, 298)
        Me.dgvOpciones.TabIndex = 11
        '
        'cIdOpcion
        '
        Me.cIdOpcion.HeaderText = "Codigo"
        Me.cIdOpcion.Name = "cIdOpcion"
        Me.cIdOpcion.Width = 50
        '
        'cDesOpc1
        '
        Me.cDesOpc1.HeaderText = "Descripcion"
        Me.cDesOpc1.Name = "cDesOpc1"
        Me.cDesOpc1.Width = 240
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(244, 34)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(58, 13)
        Me.lblEmpresa.TabIndex = 12
        Me.lblEmpresa.Text = "lblEmpresa"
        '
        'frmAsignarPerfil
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(724, 385)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.dgvOpciones)
        Me.Controls.Add(Me.cmbMenu)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnRegresarTodos)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvSeleccionados)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAsignarPerfil"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Opciones"
        CType(Me.dgvSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.cmbMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSeleccionados As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents btnRegresarTodos As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMenu As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents CachedrpDiarioAlmacenTotales1 As SIGECOM.CachedrpDiarioAlmacenTotales
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cIdOpcion1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesOpc11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvOpciones As System.Windows.Forms.DataGridView
    Friend WithEvents cIdOpcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesOpc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblEmpresa As Label
End Class
