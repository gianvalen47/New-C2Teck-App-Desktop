<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMovimAlmacen_OrdenCompra
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimAlmacen_OrdenCompra))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnInsertarDetalles = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeterCEROTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMarcarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDesmarcarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvDatosN = New System.Windows.Forms.DataGridView()
        Me.IdOrdenGrd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanRec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanPen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Despacho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PreMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DscMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalFila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Placa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbAtender = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtUpdate = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.dgvDatosN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.btnInsertarDetalles, Me.ToolStripSeparator2, Me.btnCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(868, 27)
        Me.ToolStrip1.TabIndex = 303
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'btnInsertarDetalles
        '
        Me.btnInsertarDetalles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnInsertarDetalles.Image = CType(resources.GetObject("btnInsertarDetalles.Image"), System.Drawing.Image)
        Me.btnInsertarDetalles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsertarDetalles.Name = "btnInsertarDetalles"
        Me.btnInsertarDetalles.Size = New System.Drawing.Size(24, 24)
        Me.btnInsertarDetalles.Text = "Ingresar Datos"
        Me.btnInsertarDetalles.ToolTipText = "Ingresar Datos"
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
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 583)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(868, 20)
        Me.ssBarra.TabIndex = 304
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(12, 601)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(74, 60)
        Me.dgvDatos.TabIndex = 305
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.Visible = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodo, Me.miSeterCEROTodos, Me.ToolStripMenuItem1, Me.miBuscar, Me.miMarcarTodos, Me.miDesmarcarTodos, Me.ToolStripSeparator4, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(174, 148)
        '
        'miSeleccionarTodo
        '
        Me.miSeleccionarTodo.Image = CType(resources.GetObject("miSeleccionarTodo.Image"), System.Drawing.Image)
        Me.miSeleccionarTodo.Name = "miSeleccionarTodo"
        Me.miSeleccionarTodo.Size = New System.Drawing.Size(173, 22)
        Me.miSeleccionarTodo.Text = "Recepcionar Todos"
        '
        'miSeterCEROTodos
        '
        Me.miSeterCEROTodos.Image = CType(resources.GetObject("miSeterCEROTodos.Image"), System.Drawing.Image)
        Me.miSeterCEROTodos.Name = "miSeterCEROTodos"
        Me.miSeterCEROTodos.Size = New System.Drawing.Size(173, 22)
        Me.miSeterCEROTodos.Text = "Poner en ""0"" todos"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(170, 6)
        '
        'miBuscar
        '
        Me.miBuscar.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miBuscar.Name = "miBuscar"
        Me.miBuscar.Size = New System.Drawing.Size(173, 22)
        Me.miBuscar.Text = "Buscar"
        '
        'miMarcarTodos
        '
        Me.miMarcarTodos.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMarcarTodos.Name = "miMarcarTodos"
        Me.miMarcarTodos.Size = New System.Drawing.Size(173, 22)
        Me.miMarcarTodos.Text = "Marcar Todos"
        Me.miMarcarTodos.Visible = False
        '
        'miDesmarcarTodos
        '
        Me.miDesmarcarTodos.Image = Global.SIGECOM.My.Resources.Resources.Borrar
        Me.miDesmarcarTodos.Name = "miDesmarcarTodos"
        Me.miDesmarcarTodos.Size = New System.Drawing.Size(173, 22)
        Me.miDesmarcarTodos.Text = "Desmarcar Todos"
        Me.miDesmarcarTodos.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(170, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(173, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'dgvDatosN
        '
        Me.dgvDatosN.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatosN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatosN.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdOrdenGrd, Me.IdOrden, Me.CodArea, Me.CodRubro, Me.CodJob, Me.Item, Me.CodMer, Me.DesMer, Me.CanMer, Me.CanRec, Me.CanPen, Me.Despacho, Me.PreMer, Me.DscMer, Me.TotalFila, Me.Observacion, Me.Placa, Me.cbAtender})
        Me.dgvDatosN.ContextMenuStrip = Me.cmOpciones
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDatosN.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvDatosN.Location = New System.Drawing.Point(11, 43)
        Me.dgvDatosN.Name = "dgvDatosN"
        Me.dgvDatosN.Size = New System.Drawing.Size(837, 526)
        Me.dgvDatosN.TabIndex = 308
        '
        'IdOrdenGrd
        '
        Me.IdOrdenGrd.DataPropertyName = "IdOrdenDet"
        Me.IdOrdenGrd.HeaderText = "IdOrdenGrd"
        Me.IdOrdenGrd.Name = "IdOrdenGrd"
        Me.IdOrdenGrd.Visible = False
        '
        'IdOrden
        '
        Me.IdOrden.DataPropertyName = "IdOrden"
        Me.IdOrden.HeaderText = "IdOrden"
        Me.IdOrden.Name = "IdOrden"
        Me.IdOrden.Visible = False
        '
        'CodArea
        '
        Me.CodArea.DataPropertyName = "CodArea"
        Me.CodArea.HeaderText = "CodArea"
        Me.CodArea.Name = "CodArea"
        Me.CodArea.Visible = False
        '
        'CodRubro
        '
        Me.CodRubro.DataPropertyName = "CodRubro"
        Me.CodRubro.HeaderText = "CodRubro"
        Me.CodRubro.Name = "CodRubro"
        Me.CodRubro.Visible = False
        '
        'CodJob
        '
        Me.CodJob.DataPropertyName = "CodJob"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CodJob.DefaultCellStyle = DataGridViewCellStyle1
        Me.CodJob.HeaderText = "Job"
        Me.CodJob.Name = "CodJob"
        Me.CodJob.Visible = False
        Me.CodJob.Width = 60
        '
        'Item
        '
        Me.Item.DataPropertyName = "Item"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Item.DefaultCellStyle = DataGridViewCellStyle2
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.Width = 40
        '
        'CodMer
        '
        Me.CodMer.DataPropertyName = "CodMer"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodMer.DefaultCellStyle = DataGridViewCellStyle3
        Me.CodMer.HeaderText = "Codigo"
        Me.CodMer.Name = "CodMer"
        Me.CodMer.Width = 110
        '
        'DesMer
        '
        Me.DesMer.DataPropertyName = "DesMer"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesMer.DefaultCellStyle = DataGridViewCellStyle4
        Me.DesMer.HeaderText = "Descripción"
        Me.DesMer.Name = "DesMer"
        Me.DesMer.Width = 150
        '
        'CanMer
        '
        Me.CanMer.DataPropertyName = "CanMer"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.CanMer.DefaultCellStyle = DataGridViewCellStyle5
        Me.CanMer.HeaderText = "Cant."
        Me.CanMer.Name = "CanMer"
        Me.CanMer.Width = 60
        '
        'CanRec
        '
        Me.CanRec.DataPropertyName = "CanRec"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.CanRec.DefaultCellStyle = DataGridViewCellStyle6
        Me.CanRec.HeaderText = "Cant Recibida"
        Me.CanRec.Name = "CanRec"
        Me.CanRec.Width = 60
        '
        'CanPen
        '
        Me.CanPen.DataPropertyName = "CanPen"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.CanPen.DefaultCellStyle = DataGridViewCellStyle7
        Me.CanPen.HeaderText = "Pendiente"
        Me.CanPen.Name = "CanPen"
        Me.CanPen.Width = 70
        '
        'Despacho
        '
        Me.Despacho.DataPropertyName = "Despacho"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Beige
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Despacho.DefaultCellStyle = DataGridViewCellStyle8
        Me.Despacho.HeaderText = "Recibir"
        Me.Despacho.Name = "Despacho"
        Me.Despacho.Width = 70
        '
        'PreMer
        '
        Me.PreMer.DataPropertyName = "PreMer"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PreMer.DefaultCellStyle = DataGridViewCellStyle9
        Me.PreMer.HeaderText = "Precio"
        Me.PreMer.Name = "PreMer"
        Me.PreMer.Visible = False
        Me.PreMer.Width = 60
        '
        'DscMer
        '
        Me.DscMer.DataPropertyName = "DscMer"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DscMer.DefaultCellStyle = DataGridViewCellStyle10
        Me.DscMer.HeaderText = "Dscto."
        Me.DscMer.Name = "DscMer"
        Me.DscMer.Visible = False
        Me.DscMer.Width = 60
        '
        'TotalFila
        '
        Me.TotalFila.DataPropertyName = "TotalFila"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TotalFila.DefaultCellStyle = DataGridViewCellStyle11
        Me.TotalFila.HeaderText = "Total"
        Me.TotalFila.Name = "TotalFila"
        Me.TotalFila.Visible = False
        Me.TotalFila.Width = 60
        '
        'Observacion
        '
        Me.Observacion.DataPropertyName = "Observacion"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Observacion.DefaultCellStyle = DataGridViewCellStyle12
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.Width = 200
        '
        'Placa
        '
        Me.Placa.DataPropertyName = "Placa"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Placa.DefaultCellStyle = DataGridViewCellStyle13
        Me.Placa.HeaderText = "Placa"
        Me.Placa.Name = "Placa"
        Me.Placa.Visible = False
        '
        'cbAtender
        '
        Me.cbAtender.HeaderText = "Imp"
        Me.cbAtender.Name = "cbAtender"
        Me.cbAtender.Visible = False
        Me.cbAtender.Width = 50
        '
        'txtUpdate
        '
        Me.txtUpdate.Location = New System.Drawing.Point(104, 601)
        Me.txtUpdate.Name = "txtUpdate"
        Me.txtUpdate.Size = New System.Drawing.Size(28, 20)
        Me.txtUpdate.TabIndex = 309
        '
        'frmMovimAlmacen_OrdenCompra
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(868, 603)
        Me.Controls.Add(Me.txtUpdate)
        Me.Controls.Add(Me.dgvDatosN)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovimAlmacen_OrdenCompra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden Compra"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.dgvDatosN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnInsertarDetalles As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As StatusStrip
    Friend WithEvents sslError As ToolStripStatusLabel
    Friend WithEvents sslTotal As ToolStripStatusLabel
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miSeleccionarTodo As ToolStripMenuItem
    Friend WithEvents miSeterCEROTodos As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents miActualizar As ToolStripMenuItem
    Friend WithEvents CanAte As DataGridViewTextBoxColumn
    Friend WithEvents Selector As DataGridViewCheckBoxColumn
    Friend WithEvents dgvDatosN As DataGridView
    Friend WithEvents miMarcarTodos As ToolStripMenuItem
    Friend WithEvents miDesmarcarTodos As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents miBuscar As ToolStripMenuItem
    Friend WithEvents txtUpdate As TextBox
    Friend WithEvents IdOrdenGrd As DataGridViewTextBoxColumn
    Friend WithEvents IdOrden As DataGridViewTextBoxColumn
    Friend WithEvents CodArea As DataGridViewTextBoxColumn
    Friend WithEvents CodRubro As DataGridViewTextBoxColumn
    Friend WithEvents CodJob As DataGridViewTextBoxColumn
    Friend WithEvents Item As DataGridViewTextBoxColumn
    Friend WithEvents CodMer As DataGridViewTextBoxColumn
    Friend WithEvents DesMer As DataGridViewTextBoxColumn
    Friend WithEvents CanMer As DataGridViewTextBoxColumn
    Friend WithEvents CanRec As DataGridViewTextBoxColumn
    Friend WithEvents CanPen As DataGridViewTextBoxColumn
    Friend WithEvents Despacho As DataGridViewTextBoxColumn
    Friend WithEvents PreMer As DataGridViewTextBoxColumn
    Friend WithEvents DscMer As DataGridViewTextBoxColumn
    Friend WithEvents TotalFila As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents Placa As DataGridViewTextBoxColumn
    Friend WithEvents cbAtender As DataGridViewCheckBoxColumn
End Class
