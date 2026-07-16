<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarMoneda
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
        Dim cmdOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregarMoneda))
        Me.cmdOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnRegresarTodos = New System.Windows.Forms.Button()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvOpcionAsignada = New System.Windows.Forms.DataGridView()
        Me.dgvOpcion = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.cmdOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOpcionAsignada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOpcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOficina
        '
        Me.cmdOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmdOficina_DesignTimeLayout.LayoutString = resources.GetString("cmdOficina_DesignTimeLayout.LayoutString")
        Me.cmdOficina.DesignTimeLayout = cmdOficina_DesignTimeLayout
        Me.cmdOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOficina.Location = New System.Drawing.Point(64, 35)
        Me.cmdOficina.Name = "cmdOficina"
        Me.cmdOficina.SelectedIndex = -1
        Me.cmdOficina.SelectedItem = Nothing
        Me.cmdOficina.Size = New System.Drawing.Size(136, 20)
        Me.cmdOficina.TabIndex = 26
        Me.cmdOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnRegresarTodos
        '
        Me.btnRegresarTodos.Image = Global.SIGECOM.My.Resources.Resources.Izquierda
        Me.btnRegresarTodos.Location = New System.Drawing.Point(268, 229)
        Me.btnRegresarTodos.Name = "btnRegresarTodos"
        Me.btnRegresarTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnRegresarTodos.TabIndex = 25
        Me.btnRegresarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(268, 181)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarTodos.TabIndex = 24
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.SIGECOM.My.Resources.Resources.Regresar
        Me.btnRegresar.Location = New System.Drawing.Point(268, 139)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegresar.TabIndex = 23
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(268, 95)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 22
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvOpcionAsignada
        '
        Me.dgvOpcionAsignada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpcionAsignada.Location = New System.Drawing.Point(349, 68)
        Me.dgvOpcionAsignada.Name = "dgvOpcionAsignada"
        Me.dgvOpcionAsignada.Size = New System.Drawing.Size(252, 252)
        Me.dgvOpcionAsignada.TabIndex = 21
        '
        'dgvOpcion
        '
        Me.dgvOpcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpcion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.descripcion})
        Me.dgvOpcion.Location = New System.Drawing.Point(12, 68)
        Me.dgvOpcion.Name = "dgvOpcion"
        Me.dgvOpcion.Size = New System.Drawing.Size(243, 252)
        Me.dgvOpcion.TabIndex = 20
        '
        'codigo
        '
        Me.codigo.HeaderText = "codigo"
        Me.codigo.Name = "codigo"
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "descripcion"
        Me.descripcion.Name = "descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Oficina"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(621, 25)
        Me.ToolStrip1.TabIndex = 27
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmAgregarMoneda
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(621, 334)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cmdOficina)
        Me.Controls.Add(Me.btnRegresarTodos)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvOpcionAsignada)
        Me.Controls.Add(Me.dgvOpcion)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregarMoneda"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Moneda"
        CType(Me.cmdOficina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOpcionAsignada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOpcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnRegresarTodos As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvOpcionAsignada As System.Windows.Forms.DataGridView
    Friend WithEvents dgvOpcion As System.Windows.Forms.DataGridView
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
