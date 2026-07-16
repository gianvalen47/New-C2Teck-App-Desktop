<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepuestosServicioClientes
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepuestosServicioClientes))
        Dim cmbCodServicio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbTipMot_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbModMer_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.biNuevo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.biMostrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.biEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.biFormatoExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.biEliminarTodo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.biActualizar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.miFormatoExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.miInsertarListado = New System.Windows.Forms.ToolStripMenuItem
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX
        Me.cmbCodServicio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbTipMot = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbModMer = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipMot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbModMer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biNuevo, Me.ToolStripSeparator1, Me.biMostrar, Me.ToolStripSeparator2, Me.biEliminar, Me.ToolStripSeparator3, Me.biFormatoExcel, Me.ToolStripSeparator4, Me.biEliminarTodo, Me.ToolStripSeparator5, Me.biActualizar, Me.ToolStripSeparator6, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(692, 31)
        Me.ToolStrip.TabIndex = 37
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Black
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Crear un nuevo registro"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar los datos del registro seleccionado"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar el registro seleccionado"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biFormatoExcel
        '
        Me.biFormatoExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biFormatoExcel.Image = CType(resources.GetObject("biFormatoExcel.Image"), System.Drawing.Image)
        Me.biFormatoExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biFormatoExcel.Name = "biFormatoExcel"
        Me.biFormatoExcel.Size = New System.Drawing.Size(28, 28)
        Me.biFormatoExcel.Text = "Descargar Formato Excel"
        Me.biFormatoExcel.ToolTipText = "Descargar Formato Excel"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminarTodo
        '
        Me.biEliminarTodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminarTodo.Image = Global.SIGECOM.My.Resources.Resources.brocha
        Me.biEliminarTodo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminarTodo.Name = "biEliminarTodo"
        Me.biEliminarTodo.Size = New System.Drawing.Size(28, 28)
        Me.biEliminarTodo.Text = "Eliminar todos los registros del tipo de servicio seleccionado"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "ToolStripButton1"
        Me.biActualizar.ToolTipText = "Refrescar"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
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
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miActualizar, Me.miSalir, Me.miFormatoExcel, Me.miInsertarListado})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(228, 180)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(227, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(227, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(227, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(227, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(227, 22)
        Me.miSalir.Text = "Salir"
        '
        'miFormatoExcel
        '
        Me.miFormatoExcel.Image = Global.SIGECOM.My.Resources.Resources.excel_ico
        Me.miFormatoExcel.Name = "miFormatoExcel"
        Me.miFormatoExcel.Size = New System.Drawing.Size(227, 22)
        Me.miFormatoExcel.Text = "Formato Excel"
        '
        'miInsertarListado
        '
        Me.miInsertarListado.Image = Global.SIGECOM.My.Resources.Resources.excel_ico
        Me.miInsertarListado.Name = "miInsertarListado"
        Me.miInsertarListado.Size = New System.Drawing.Size(227, 22)
        Me.miInsertarListado.Text = "Insertar Listado de Repuestos"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(629, 57)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(61, 23)
        Me.btnBuscar.TabIndex = 46
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(215, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Tipo Servicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(489, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Tipo Motor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(354, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Modelo"
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(5, 91)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(683, 212)
        Me.dgvDatos.TabIndex = 42
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbCodServicio
        '
        Me.cmbCodServicio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodServicio_DesignTimeLayout.LayoutString = resources.GetString("cmbCodServicio_DesignTimeLayout.LayoutString")
        Me.cmbCodServicio.DesignTimeLayout = cmbCodServicio_DesignTimeLayout
        Me.cmbCodServicio.Location = New System.Drawing.Point(216, 59)
        Me.cmbCodServicio.Name = "cmbCodServicio"
        Me.cmbCodServicio.SelectedIndex = -1
        Me.cmbCodServicio.SelectedItem = Nothing
        Me.cmbCodServicio.Size = New System.Drawing.Size(136, 20)
        Me.cmbCodServicio.TabIndex = 39
        Me.cmbCodServicio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbTipMot
        '
        Me.cmbTipMot.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipMot_DesignTimeLayout.LayoutString = resources.GetString("cmbTipMot_DesignTimeLayout.LayoutString")
        Me.cmbTipMot.DesignTimeLayout = cmbTipMot_DesignTimeLayout
        Me.cmbTipMot.Location = New System.Drawing.Point(491, 59)
        Me.cmbTipMot.Name = "cmbTipMot"
        Me.cmbTipMot.SelectedIndex = -1
        Me.cmbTipMot.SelectedItem = Nothing
        Me.cmbTipMot.Size = New System.Drawing.Size(136, 20)
        Me.cmbTipMot.TabIndex = 41
        Me.cmbTipMot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbModMer
        '
        Me.cmbModMer.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbModMer_DesignTimeLayout.LayoutString = resources.GetString("cmbModMer_DesignTimeLayout.LayoutString")
        Me.cmbModMer.DesignTimeLayout = cmbModMer_DesignTimeLayout
        Me.cmbModMer.Location = New System.Drawing.Point(355, 59)
        Me.cmbModMer.Name = "cmbModMer"
        Me.cmbModMer.SelectedIndex = -1
        Me.cmbModMer.SelectedItem = Nothing
        Me.cmbModMer.Size = New System.Drawing.Size(133, 20)
        Me.cmbModMer.TabIndex = 40
        Me.cmbModMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(5, 60)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(182, 20)
        Me.txtCliente.TabIndex = 49
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(187, 58)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(27, 23)
        Me.btnBuscarCliente.TabIndex = 50
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(609, 36)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(32, 20)
        Me.DataGridView2.TabIndex = 52
        Me.DataGridView2.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(571, 36)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(32, 20)
        Me.DataGridView1.TabIndex = 51
        Me.DataGridView1.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmRepuestosServicioClientes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(692, 308)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.cmbCodServicio)
        Me.Controls.Add(Me.cmbTipMot)
        Me.Controls.Add(Me.cmbModMer)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepuestosServicioClientes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Repuestos x Cliente"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipMot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbModMer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbCodServicio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbTipMot As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbModMer As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents biEliminarTodo As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biFormatoExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miFormatoExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miInsertarListado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
