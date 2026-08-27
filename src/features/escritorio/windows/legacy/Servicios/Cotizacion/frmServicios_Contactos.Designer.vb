<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios_Contactos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicios_Contactos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnRegresarTodos = New System.Windows.Forms.Button
        Me.btnAgregarTodos = New System.Windows.Forms.Button
        Me.btnRegresar = New System.Windows.Forms.Button
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.dgvOpcionMenuAsignado = New System.Windows.Forms.DataGridView
        Me.cIdContacto1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cApeNom1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvOpcionMenu = New System.Windows.Forms.DataGridView
        Me.cIdContacto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnAgregarContacto = New System.Windows.Forms.Button
        Me.ToolStrip1.SuspendLayout()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOpcionMenuAsignado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOpcionMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(779, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 22)
        Me.btnGuardar.Text = "ToolStripButton1"
        Me.btnGuardar.ToolTipText = "Agregar Contactos"
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
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnRegresarTodos
        '
        Me.btnRegresarTodos.Enabled = False
        Me.btnRegresarTodos.Image = Global.SIGECOM.My.Resources.Resources.Izquierda
        Me.btnRegresarTodos.Location = New System.Drawing.Point(357, 212)
        Me.btnRegresarTodos.Name = "btnRegresarTodos"
        Me.btnRegresarTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnRegresarTodos.TabIndex = 13
        Me.btnRegresarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Enabled = False
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(357, 175)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarTodos.TabIndex = 12
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.SIGECOM.My.Resources.Resources.Regresar
        Me.btnRegresar.Location = New System.Drawing.Point(357, 135)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegresar.TabIndex = 11
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(357, 97)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 10
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvOpcionMenuAsignado
        '
        Me.dgvOpcionMenuAsignado.AllowUserToAddRows = False
        Me.dgvOpcionMenuAsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpcionMenuAsignado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdContacto1, Me.cApeNom1})
        Me.dgvOpcionMenuAsignado.Location = New System.Drawing.Point(444, 42)
        Me.dgvOpcionMenuAsignado.Name = "dgvOpcionMenuAsignado"
        Me.dgvOpcionMenuAsignado.Size = New System.Drawing.Size(323, 219)
        Me.dgvOpcionMenuAsignado.TabIndex = 9
        '
        'cIdContacto1
        '
        Me.cIdContacto1.HeaderText = "Codigo"
        Me.cIdContacto1.Name = "cIdContacto1"
        Me.cIdContacto1.ReadOnly = True
        '
        'cApeNom1
        '
        Me.cApeNom1.HeaderText = "Nombre"
        Me.cApeNom1.Name = "cApeNom1"
        Me.cApeNom1.ReadOnly = True
        '
        'dgvOpcionMenu
        '
        Me.dgvOpcionMenu.AllowUserToAddRows = False
        Me.dgvOpcionMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpcionMenu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdContacto, Me.cApeNom})
        Me.dgvOpcionMenu.Location = New System.Drawing.Point(12, 42)
        Me.dgvOpcionMenu.Name = "dgvOpcionMenu"
        Me.dgvOpcionMenu.Size = New System.Drawing.Size(339, 219)
        Me.dgvOpcionMenu.TabIndex = 8
        '
        'cIdContacto
        '
        Me.cIdContacto.HeaderText = "Codigo"
        Me.cIdContacto.Name = "cIdContacto"
        Me.cIdContacto.ReadOnly = True
        '
        'cApeNom
        '
        Me.cApeNom.HeaderText = "Nombre"
        Me.cApeNom.Name = "cApeNom"
        Me.cApeNom.ReadOnly = True
        '
        'btnAgregarContacto
        '
        Me.btnAgregarContacto.Image = CType(resources.GetObject("btnAgregarContacto.Image"), System.Drawing.Image)
        Me.btnAgregarContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarContacto.Location = New System.Drawing.Point(357, 52)
        Me.btnAgregarContacto.Name = "btnAgregarContacto"
        Me.btnAgregarContacto.Size = New System.Drawing.Size(75, 36)
        Me.btnAgregarContacto.TabIndex = 14
        Me.btnAgregarContacto.Text = "Agregar Contacto"
        Me.btnAgregarContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarContacto.UseVisualStyleBackColor = True
        '
        'frmServicios_Contactos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(779, 279)
        Me.Controls.Add(Me.btnAgregarContacto)
        Me.Controls.Add(Me.btnRegresarTodos)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvOpcionMenuAsignado)
        Me.Controls.Add(Me.dgvOpcionMenu)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios_Contactos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Contactos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOpcionMenuAsignado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOpcionMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnRegresarTodos As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvOpcionMenuAsignado As System.Windows.Forms.DataGridView
    Friend WithEvents dgvOpcionMenu As System.Windows.Forms.DataGridView
    Friend WithEvents cIdContacto1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cIdContacto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApeNom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAgregarContacto As System.Windows.Forms.Button
End Class
