<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedido))
        Dim cmbIdPer_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cmOpcionesAtender = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeterCEROTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizarCodigo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbSeleccionrTodos = New Janus.Windows.EditControls.UICheckBox()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumOrden = New System.Windows.Forms.TextBox()
        Me.cmbIdPer = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtTecnico = New System.Windows.Forms.TextBox()
        Me.txtInterprete = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerMot = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtIdPedido = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.gbTotal = New System.Windows.Forms.GroupBox()
        Me.txtTotNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCambiarEstado1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerar1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDescargarExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImportarExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.cIdPedidoDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMerAnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCanPed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCanAte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAtender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPreMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cTotalFila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesAtender.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdPer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        Me.gbTotal.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdPedidoDet, Me.cCodMer, Me.cCodMerAnt, Me.cDesMer, Me.cCanPed, Me.cCanAte, Me.cAtender, Me.cPreMer, Me.cTotalFila})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.Location = New System.Drawing.Point(5, 29)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidth = 15
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(763, 200)
        Me.dgvDatos.TabIndex = 1
        '
        'cmOpcionesAtender
        '
        Me.cmOpcionesAtender.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodo, Me.miSeterCEROTodos})
        Me.cmOpcionesAtender.Name = "cmOpciones"
        Me.cmOpcionesAtender.Size = New System.Drawing.Size(174, 48)
        '
        'miSeleccionarTodo
        '
        Me.miSeleccionarTodo.Image = CType(resources.GetObject("miSeleccionarTodo.Image"), System.Drawing.Image)
        Me.miSeleccionarTodo.Name = "miSeleccionarTodo"
        Me.miSeleccionarTodo.Size = New System.Drawing.Size(173, 22)
        Me.miSeleccionarTodo.Text = "Seleccionar Todos"
        '
        'miSeterCEROTodos
        '
        Me.miSeterCEROTodos.Image = CType(resources.GetObject("miSeterCEROTodos.Image"), System.Drawing.Image)
        Me.miSeterCEROTodos.Name = "miSeterCEROTodos"
        Me.miSeterCEROTodos.Size = New System.Drawing.Size(173, 22)
        Me.miSeterCEROTodos.Text = "Poner en ""0"" todos"
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miActualizarCodigo, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(169, 120)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(168, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(168, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(168, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miActualizarCodigo
        '
        Me.miActualizarCodigo.Image = CType(resources.GetObject("miActualizarCodigo.Image"), System.Drawing.Image)
        Me.miActualizarCodigo.Name = "miActualizarCodigo"
        Me.miActualizarCodigo.Size = New System.Drawing.Size(168, 22)
        Me.miActualizarCodigo.Text = "Actualizar Codigo"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(168, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvDatos)
        Me.GroupBox1.Controls.Add(Me.rbSeleccionrTodos)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 215)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(773, 236)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lista de Detalle"
        '
        'rbSeleccionrTodos
        '
        Me.rbSeleccionrTodos.Location = New System.Drawing.Point(507, 7)
        Me.rbSeleccionrTodos.Name = "rbSeleccionrTodos"
        Me.rbSeleccionrTodos.Size = New System.Drawing.Size(20, 23)
        Me.rbSeleccionrTodos.TabIndex = 2
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.DataGridView2)
        Me.gbDatos.Controls.Add(Me.DataGridView1)
        Me.gbDatos.Controls.Add(Me.txtObservacion)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.txtNumOrden)
        Me.gbDatos.Controls.Add(Me.cmbIdPer)
        Me.gbDatos.Controls.Add(Me.txtTecnico)
        Me.gbDatos.Controls.Add(Me.txtInterprete)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.txtNumJob)
        Me.gbDatos.Controls.Add(Me.Button1)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.txtSerMot)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.txtFecha)
        Me.gbDatos.Controls.Add(Me.txtCliente)
        Me.gbDatos.Controls.Add(Me.btnBuscarCliente)
        Me.gbDatos.Controls.Add(Me.txtIdPedido)
        Me.gbDatos.Controls.Add(Me.Label15)
        Me.gbDatos.Controls.Add(Me.gbEstado)
        Me.gbDatos.Controls.Add(Me.gbTotal)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.Label12)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(4, 34)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(773, 175)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Pedido de Importación"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(464, 116)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(32, 20)
        Me.DataGridView2.TabIndex = 132
        Me.DataGridView2.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(464, 139)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(32, 20)
        Me.DataGridView1.TabIndex = 131
        Me.DataGridView1.Visible = False
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(100, 110)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(330, 56)
        Me.txtObservacion.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Observación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(451, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "N° Orden"
        '
        'txtNumOrden
        '
        Me.txtNumOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumOrden.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtNumOrden.Location = New System.Drawing.Point(514, 87)
        Me.txtNumOrden.MaxLength = 50
        Me.txtNumOrden.Name = "txtNumOrden"
        Me.txtNumOrden.Size = New System.Drawing.Size(243, 20)
        Me.txtNumOrden.TabIndex = 21
        '
        'cmbIdPer
        '
        Me.cmbIdPer.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdPer_DesignTimeLayout.LayoutString = resources.GetString("cmbIdPer_DesignTimeLayout.LayoutString")
        Me.cmbIdPer.DesignTimeLayout = cmbIdPer_DesignTimeLayout
        Me.cmbIdPer.Location = New System.Drawing.Point(80, 65)
        Me.cmbIdPer.Name = "cmbIdPer"
        Me.cmbIdPer.SelectedIndex = -1
        Me.cmbIdPer.SelectedItem = Nothing
        Me.cmbIdPer.Size = New System.Drawing.Size(350, 20)
        Me.cmbIdPer.TabIndex = 7
        Me.cmbIdPer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTecnico
        '
        Me.txtTecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTecnico.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTecnico.Location = New System.Drawing.Point(80, 87)
        Me.txtTecnico.MaxLength = 50
        Me.txtTecnico.Name = "txtTecnico"
        Me.txtTecnico.Size = New System.Drawing.Size(350, 20)
        Me.txtTecnico.TabIndex = 9
        '
        'txtInterprete
        '
        Me.txtInterprete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInterprete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInterprete.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtInterprete.Location = New System.Drawing.Point(514, 65)
        Me.txtInterprete.MaxLength = 50
        Me.txtInterprete.Name = "txtInterprete"
        Me.txtInterprete.Size = New System.Drawing.Size(243, 20)
        Me.txtInterprete.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(451, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Interprete"
        '
        'txtNumJob
        '
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtNumJob.Location = New System.Drawing.Point(645, 43)
        Me.txtNumJob.MaxLength = 7
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.ReadOnly = True
        Me.txtNumJob.Size = New System.Drawing.Size(70, 20)
        Me.txtNumJob.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(715, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 22)
        Me.Button1.TabIndex = 6
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(605, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "# Job"
        '
        'txtSerMot
        '
        Me.txtSerMot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerMot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerMot.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtSerMot.Location = New System.Drawing.Point(514, 43)
        Me.txtSerMot.MaxLength = 20
        Me.txtSerMot.Name = "txtSerMot"
        Me.txtSerMot.Size = New System.Drawing.Size(85, 20)
        Me.txtSerMot.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(461, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Motor"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.FirstMonth = New Date(2014, 11, 1, 0, 0, 0, 0)
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free
        Me.txtFecha.Location = New System.Drawing.Point(329, 20)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.ShowNullButton = True
        Me.txtFecha.Size = New System.Drawing.Size(85, 20)
        Me.txtFecha.TabIndex = 1
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.Value = New Date(2014, 12, 2, 0, 0, 0, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtCliente.Location = New System.Drawing.Point(80, 43)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(322, 20)
        Me.txtCliente.TabIndex = 2
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(405, 42)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 3
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtIdPedido
        '
        Me.txtIdPedido.BackColor = System.Drawing.Color.Beige
        Me.txtIdPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPedido.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdPedido.Location = New System.Drawing.Point(80, 21)
        Me.txtIdPedido.MaxLength = 50
        Me.txtIdPedido.Name = "txtIdPedido"
        Me.txtIdPedido.ReadOnly = True
        Me.txtIdPedido.Size = New System.Drawing.Size(115, 20)
        Me.txtIdPedido.TabIndex = 0
        Me.txtIdPedido.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(281, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Fecha"
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(501, 13)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(256, 28)
        Me.gbEstado.TabIndex = 17
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(6, 9)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(244, 17)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbTotal
        '
        Me.gbTotal.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbTotal.Controls.Add(Me.txtTotNeto)
        Me.gbTotal.Controls.Add(Me.Label5)
        Me.gbTotal.Location = New System.Drawing.Point(521, 117)
        Me.gbTotal.Name = "gbTotal"
        Me.gbTotal.Size = New System.Drawing.Size(236, 40)
        Me.gbTotal.TabIndex = 12
        Me.gbTotal.TabStop = False
        '
        'txtTotNeto
        '
        Me.txtTotNeto.BackColor = System.Drawing.Color.DarkKhaki
        Me.txtTotNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtTotNeto.Location = New System.Drawing.Point(83, 13)
        Me.txtTotNeto.MaxLength = 5
        Me.txtTotNeto.Name = "txtTotNeto"
        Me.txtTotNeto.ReadOnly = True
        Me.txtTotNeto.Size = New System.Drawing.Size(147, 22)
        Me.txtTotNeto.TabIndex = 0
        Me.txtTotNeto.TabStop = False
        Me.txtTotNeto.Text = "0.00"
        Me.txtTotNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Location = New System.Drawing.Point(17, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "TOTAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Técnico"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Supervisor"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Número"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 455)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(782, 23)
        Me.ssBarra.TabIndex = 10
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 18)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(150, 18)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar1, Me.ToolStripSeparator3, Me.biEditar1, Me.ToolStripSeparator1, Me.biDeshacer1, Me.ToolStripSeparator4, Me.biCambiarEstado1, Me.ToolStripSeparator5, Me.biGenerar1, Me.ToolStripSeparator6, Me.biDescargarExcel, Me.ToolStripSeparator7, Me.biImportarExcel, Me.ToolStripSeparator8, Me.biCerrar, Me.ToolStripSeparator12})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(782, 31)
        Me.ToolStrip.TabIndex = 115
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar1
        '
        Me.biGuardar1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar1.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar1.Name = "biGuardar1"
        Me.biGuardar1.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar1.Text = "Grabar Cambios"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar1
        '
        Me.biEditar1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar1.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar1.Name = "biEditar1"
        Me.biEditar1.Size = New System.Drawing.Size(28, 28)
        Me.biEditar1.Text = "Editar Datos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer1
        '
        Me.biDeshacer1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer1.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer1.Name = "biDeshacer1"
        Me.biDeshacer1.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer1.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biCambiarEstado1
        '
        Me.biCambiarEstado1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCambiarEstado1.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.biCambiarEstado1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCambiarEstado1.Name = "biCambiarEstado1"
        Me.biCambiarEstado1.Size = New System.Drawing.Size(28, 28)
        Me.biCambiarEstado1.Text = "Generar Solicitud de Gastos"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerar1
        '
        Me.biGenerar1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerar1.Image = CType(resources.GetObject("biGenerar1.Image"), System.Drawing.Image)
        Me.biGenerar1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerar1.Name = "biGenerar1"
        Me.biGenerar1.Size = New System.Drawing.Size(28, 28)
        Me.biGenerar1.Text = "Generar Pedido"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biDescargarExcel
        '
        Me.biDescargarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDescargarExcel.Image = CType(resources.GetObject("biDescargarExcel.Image"), System.Drawing.Image)
        Me.biDescargarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDescargarExcel.Name = "biDescargarExcel"
        Me.biDescargarExcel.Size = New System.Drawing.Size(28, 28)
        Me.biDescargarExcel.Text = "Descargar Formato Excel"
        Me.biDescargarExcel.ToolTipText = "Descargar Formato Excel"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'biImportarExcel
        '
        Me.biImportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImportarExcel.Image = CType(resources.GetObject("biImportarExcel.Image"), System.Drawing.Image)
        Me.biImportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImportarExcel.Name = "biImportarExcel"
        Me.biImportarExcel.Size = New System.Drawing.Size(28, 28)
        Me.biImportarExcel.Text = "Cargar Formato Excel"
        Me.biImportarExcel.ToolTipText = "Cargar Formato Excel"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar la ventana actual"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Location = New System.Drawing.Point(371, 11)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(109, 13)
        Me.lblUbicacion.TabIndex = 116
        Me.lblUbicacion.Text = "OFICINA - ALMACEN"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'cIdPedidoDet
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdPedidoDet.DefaultCellStyle = DataGridViewCellStyle2
        Me.cIdPedidoDet.HeaderText = "Código"
        Me.cIdPedidoDet.MinimumWidth = 2
        Me.cIdPedidoDet.Name = "cIdPedidoDet"
        Me.cIdPedidoDet.ReadOnly = True
        Me.cIdPedidoDet.Visible = False
        '
        'cCodMer
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodMer.DefaultCellStyle = DataGridViewCellStyle3
        Me.cCodMer.HeaderText = "Código"
        Me.cCodMer.Name = "cCodMer"
        Me.cCodMer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cCodMer.Width = 138
        '
        'cCodMerAnt
        '
        Me.cCodMerAnt.HeaderText = "Cod. Ant."
        Me.cCodMerAnt.Name = "cCodMerAnt"
        Me.cCodMerAnt.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cCodMerAnt.Width = 90
        '
        'cDesMer
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.cDesMer.DefaultCellStyle = DataGridViewCellStyle4
        Me.cDesMer.HeaderText = "Descripción"
        Me.cDesMer.Name = "cDesMer"
        Me.cDesMer.ReadOnly = True
        Me.cDesMer.Width = 155
        '
        'cCanPed
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCanPed.DefaultCellStyle = DataGridViewCellStyle5
        Me.cCanPed.HeaderText = "Cant."
        Me.cCanPed.Name = "cCanPed"
        Me.cCanPed.ReadOnly = True
        Me.cCanPed.Width = 55
        '
        'cCanAte
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCanAte.DefaultCellStyle = DataGridViewCellStyle6
        Me.cCanAte.HeaderText = "Can.Ate"
        Me.cCanAte.Name = "cCanAte"
        Me.cCanAte.Width = 55
        '
        'cAtender
        '
        Me.cAtender.ContextMenuStrip = Me.cmOpcionesAtender
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.cAtender.DefaultCellStyle = DataGridViewCellStyle7
        Me.cAtender.HeaderText = "Atender"
        Me.cAtender.Name = "cAtender"
        Me.cAtender.Width = 55
        '
        'cPreMer
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cPreMer.DefaultCellStyle = DataGridViewCellStyle8
        Me.cPreMer.HeaderText = "Precio"
        Me.cPreMer.Name = "cPreMer"
        Me.cPreMer.ReadOnly = True
        Me.cPreMer.Width = 80
        '
        'cTotalFila
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.cTotalFila.DefaultCellStyle = DataGridViewCellStyle9
        Me.cTotalFila.FillWeight = 90.0!
        Me.cTotalFila.HeaderText = "Total"
        Me.cTotalFila.Name = "cTotalFila"
        Me.cTotalFila.ReadOnly = True
        '
        'frmPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 478)
        Me.Controls.Add(Me.lblUbicacion)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPedido"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPedido"
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesAtender.ResumeLayout(False)
        Me.cmOpciones.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdPer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        Me.gbTotal.ResumeLayout(False)
        Me.gbTotal.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtIdPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents gbTotal As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtSerMot As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTecnico As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInterprete As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbIdPer As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmOpcionesAtender As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeterCEROTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rbSeleccionrTodos As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumOrden As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents miActualizarCodigo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents biEditar1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCambiarEstado1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGenerar1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biDescargarExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImportarExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cIdPedidoDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodMerAnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCanPed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCanAte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cAtender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cPreMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTotalFila As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
