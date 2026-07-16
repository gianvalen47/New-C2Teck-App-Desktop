<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios_PedRepuesto
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicios_PedRepuesto))
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cIdLocacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCanPed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCanAte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCanPen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cUbica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDeaMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbAtender = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDespachar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAtender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMer1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cModMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesCli1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cRucEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cSupervisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cPreMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNuevoCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cStockNuevo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miNinguno = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biTicket = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimirTicketA4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdLocacion, Me.cCodJob, Me.cCodMer, Me.cDesMer, Me.cCanPed, Me.cCanAte, Me.cCanPen, Me.cUbica, Me.cDeaMer, Me.cbAtender, Me.cStock, Me.cDespachar, Me.cAtender, Me.cCodMer1, Me.cModMer, Me.cCliente, Me.cDesCli1, Me.cDesEmp, Me.cRucEmp, Me.cSupervisor, Me.cPreMer, Me.cNuevoCodigo, Me.cStockNuevo})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.Location = New System.Drawing.Point(4, 75)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidth = 37
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(777, 250)
        Me.dgvDatos.TabIndex = 38
        '
        'cIdLocacion
        '
        Me.cIdLocacion.HeaderText = "IdLocacion"
        Me.cIdLocacion.Name = "cIdLocacion"
        Me.cIdLocacion.Visible = False
        '
        'cCodJob
        '
        Me.cCodJob.HeaderText = "CodJob"
        Me.cCodJob.Name = "cCodJob"
        Me.cCodJob.Visible = False
        '
        'cCodMer
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodMer.DefaultCellStyle = DataGridViewCellStyle9
        Me.cCodMer.HeaderText = "Código"
        Me.cCodMer.Name = "cCodMer"
        Me.cCodMer.ReadOnly = True
        Me.cCodMer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cCodMer.Width = 90
        '
        'cDesMer
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.cDesMer.DefaultCellStyle = DataGridViewCellStyle10
        Me.cDesMer.HeaderText = "Descripción"
        Me.cDesMer.Name = "cDesMer"
        Me.cDesMer.ReadOnly = True
        Me.cDesMer.Width = 175
        '
        'cCanPed
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCanPed.DefaultCellStyle = DataGridViewCellStyle11
        Me.cCanPed.HeaderText = "Can.Ped."
        Me.cCanPed.Name = "cCanPed"
        Me.cCanPed.ReadOnly = True
        Me.cCanPed.Width = 60
        '
        'cCanAte
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCanAte.DefaultCellStyle = DataGridViewCellStyle12
        Me.cCanAte.HeaderText = "Can.Ate."
        Me.cCanAte.Name = "cCanAte"
        Me.cCanAte.ReadOnly = True
        Me.cCanAte.Width = 59
        '
        'cCanPen
        '
        Me.cCanPen.HeaderText = "Can.Pen."
        Me.cCanPen.Name = "cCanPen"
        Me.cCanPen.ReadOnly = True
        Me.cCanPen.Width = 60
        '
        'cUbica
        '
        Me.cUbica.HeaderText = "Ubica"
        Me.cUbica.Name = "cUbica"
        Me.cUbica.Visible = False
        '
        'cDeaMer
        '
        Me.cDeaMer.HeaderText = "DeaMer"
        Me.cDeaMer.Name = "cDeaMer"
        Me.cDeaMer.Visible = False
        '
        'cbAtender
        '
        Me.cbAtender.FalseValue = ""
        Me.cbAtender.HeaderText = "Aten"
        Me.cbAtender.Name = "cbAtender"
        Me.cbAtender.Width = 40
        '
        'cStock
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cStock.DefaultCellStyle = DataGridViewCellStyle13
        Me.cStock.HeaderText = "Stock"
        Me.cStock.Name = "cStock"
        Me.cStock.ReadOnly = True
        Me.cStock.Width = 70
        '
        'cDespachar
        '
        Me.cDespachar.HeaderText = "Despachar"
        Me.cDespachar.Name = "cDespachar"
        Me.cDespachar.Visible = False
        '
        'cAtender
        '
        Me.cAtender.HeaderText = "Atender"
        Me.cAtender.Name = "cAtender"
        Me.cAtender.Visible = False
        '
        'cCodMer1
        '
        Me.cCodMer1.HeaderText = "CodMer1"
        Me.cCodMer1.Name = "cCodMer1"
        Me.cCodMer1.Visible = False
        '
        'cModMer
        '
        Me.cModMer.HeaderText = "ModMer"
        Me.cModMer.Name = "cModMer"
        Me.cModMer.Visible = False
        '
        'cCliente
        '
        Me.cCliente.HeaderText = "Cliente"
        Me.cCliente.Name = "cCliente"
        Me.cCliente.Visible = False
        '
        'cDesCli1
        '
        Me.cDesCli1.HeaderText = "DesCli1"
        Me.cDesCli1.Name = "cDesCli1"
        Me.cDesCli1.Visible = False
        '
        'cDesEmp
        '
        Me.cDesEmp.HeaderText = "DesEmp"
        Me.cDesEmp.Name = "cDesEmp"
        Me.cDesEmp.Visible = False
        '
        'cRucEmp
        '
        Me.cRucEmp.HeaderText = "RucEmp"
        Me.cRucEmp.Name = "cRucEmp"
        Me.cRucEmp.Visible = False
        '
        'cSupervisor
        '
        Me.cSupervisor.HeaderText = "Supervisor"
        Me.cSupervisor.Name = "cSupervisor"
        Me.cSupervisor.Visible = False
        '
        'cPreMer
        '
        Me.cPreMer.HeaderText = "PreMer"
        Me.cPreMer.Name = "cPreMer"
        Me.cPreMer.Visible = False
        '
        'cNuevoCodigo
        '
        Me.cNuevoCodigo.HeaderText = "NuevoCodigo"
        Me.cNuevoCodigo.Name = "cNuevoCodigo"
        Me.cNuevoCodigo.Width = 85
        '
        'cStockNuevo
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cStockNuevo.DefaultCellStyle = DataGridViewCellStyle14
        Me.cStockNuevo.HeaderText = "StockNuevo"
        Me.cStockNuevo.Name = "cStockNuevo"
        Me.cStockNuevo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cStockNuevo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cStockNuevo.Width = 80
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
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 340)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(794, 20)
        Me.ssBarra.TabIndex = 40
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biImprimir, Me.ToolStripSeparator1, Me.biTicket, Me.ToolStripSeparator2, Me.biImprimirTicketA4, Me.ToolStripSeparator3, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(794, 31)
        Me.ToolStrip.TabIndex = 41
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir listado de pedido"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biTicket
        '
        Me.biTicket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biTicket.Image = Global.SIGECOM.My.Resources.Resources.Ticket
        Me.biTicket.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biTicket.Name = "biTicket"
        Me.biTicket.Size = New System.Drawing.Size(28, 28)
        Me.biTicket.Text = "Imprimir Ticket"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimirTicketA4
        '
        Me.biImprimirTicketA4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimirTicketA4.Image = CType(resources.GetObject("biImprimirTicketA4.Image"), System.Drawing.Image)
        Me.biImprimirTicketA4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimirTicketA4.Name = "biImprimirTicketA4"
        Me.biImprimirTicketA4.Size = New System.Drawing.Size(28, 28)
        Me.biImprimirTicketA4.Text = "Imprimir Ticket A4"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
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
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(575, 50)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 42
        Me.TextBox1.Visible = False
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Location = New System.Drawing.Point(279, 50)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(233, 20)
        Me.cmbIdLocacion.TabIndex = 46
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Location = New System.Drawing.Point(57, 50)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(150, 20)
        Me.cmbOficinas.TabIndex = 44
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(228, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Almacén"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Oficina"
        '
        'frmServicios_PedRepuesto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(794, 360)
        Me.Controls.Add(Me.cmbIdLocacion)
        Me.Controls.Add(Me.cmbOficinas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios_PedRepuesto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmServicios_PedRepuesto"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biTicket As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miNinguno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cIdLocacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodJob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCanPed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCanAte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCanPen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cUbica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDeaMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbAtender As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDespachar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cAtender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodMer1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cModMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesCli1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesEmp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cRucEmp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cSupervisor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cPreMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNuevoCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStockNuevo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents biImprimirTicketA4 As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
End Class
