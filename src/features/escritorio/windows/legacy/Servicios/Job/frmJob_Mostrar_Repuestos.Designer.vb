<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob_Mostrar_Repuestos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJob_Mostrar_Repuestos))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtPrecioDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PrecioDol = New System.Windows.Forms.Label()
        Me.txtMontoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtMontoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.MontoSol = New System.Windows.Forms.Label()
        Me.MontoDol = New System.Windows.Forms.Label()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entregado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Devuelto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantCotizado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCotizado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.txtpreciocotizado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblpreciocotizado = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biImprimir, Me.ToolStripSeparator1, Me.biActualizar, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1034, 31)
        Me.ToolStrip.TabIndex = 249
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Listado de Repuestos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Solicitud de Job"
        Me.biActualizar.Visible = False
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
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 487)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(1034, 20)
        Me.ssBarra.TabIndex = 250
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(550, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPrecioDol
        '
        Me.txtPrecioDol.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtPrecioDol.DisabledForeColor = System.Drawing.SystemColors.Desktop
        Me.txtPrecioDol.Enabled = False
        Me.txtPrecioDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioDol.FormatString = " ###,##0.00."
        Me.txtPrecioDol.Location = New System.Drawing.Point(362, 23)
        Me.txtPrecioDol.Name = "txtPrecioDol"
        Me.txtPrecioDol.ReadOnly = True
        Me.txtPrecioDol.Size = New System.Drawing.Size(105, 21)
        Me.txtPrecioDol.TabIndex = 293
        Me.txtPrecioDol.TabStop = False
        Me.txtPrecioDol.Text = " 0.00"
        Me.txtPrecioDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'PrecioDol
        '
        Me.PrecioDol.AutoSize = True
        Me.PrecioDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrecioDol.Location = New System.Drawing.Point(180, 28)
        Me.PrecioDol.Name = "PrecioDol"
        Me.PrecioDol.Size = New System.Drawing.Size(45, 13)
        Me.PrecioDol.TabIndex = 292
        Me.PrecioDol.Text = "Label2"
        '
        'txtMontoSol
        '
        Me.txtMontoSol.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtMontoSol.DisabledForeColor = System.Drawing.SystemColors.Desktop
        Me.txtMontoSol.Enabled = False
        Me.txtMontoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSol.FormatString = " ###,##0.00."
        Me.txtMontoSol.Location = New System.Drawing.Point(606, 49)
        Me.txtMontoSol.Name = "txtMontoSol"
        Me.txtMontoSol.ReadOnly = True
        Me.txtMontoSol.Size = New System.Drawing.Size(105, 21)
        Me.txtMontoSol.TabIndex = 291
        Me.txtMontoSol.TabStop = False
        Me.txtMontoSol.Text = " 0.00"
        Me.txtMontoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtMontoDol
        '
        Me.txtMontoDol.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtMontoDol.DisabledForeColor = System.Drawing.SystemColors.Desktop
        Me.txtMontoDol.Enabled = False
        Me.txtMontoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoDol.FormatString = " ###,##0.00."
        Me.txtMontoDol.Location = New System.Drawing.Point(606, 23)
        Me.txtMontoDol.Name = "txtMontoDol"
        Me.txtMontoDol.ReadOnly = True
        Me.txtMontoDol.Size = New System.Drawing.Size(105, 21)
        Me.txtMontoDol.TabIndex = 290
        Me.txtMontoDol.TabStop = False
        Me.txtMontoDol.Text = " 0.00"
        Me.txtMontoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'MontoSol
        '
        Me.MontoSol.AutoSize = True
        Me.MontoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MontoSol.Location = New System.Drawing.Point(514, 54)
        Me.MontoSol.Name = "MontoSol"
        Me.MontoSol.Size = New System.Drawing.Size(45, 13)
        Me.MontoSol.TabIndex = 289
        Me.MontoSol.Text = "Label4"
        '
        'MontoDol
        '
        Me.MontoDol.AutoSize = True
        Me.MontoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MontoDol.Location = New System.Drawing.Point(492, 28)
        Me.MontoDol.Name = "MontoDol"
        Me.MontoDol.Size = New System.Drawing.Size(45, 13)
        Me.MontoDol.TabIndex = 288
        Me.MontoDol.Text = "Label2"
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.Articulo, Me.Descripcion, Me.Entregado, Me.Devuelto, Me.Precio, Me.Costo, Me.CantCotizado, Me.PrecioCotizado})
        Me.dgvDatos.Location = New System.Drawing.Point(12, 81)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.Size = New System.Drawing.Size(1002, 308)
        Me.dgvDatos.TabIndex = 287
        '
        'Item
        '
        Me.Item.DataPropertyName = "Item"
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.Width = 50
        '
        'Articulo
        '
        Me.Articulo.DataPropertyName = "Articulo"
        Me.Articulo.HeaderText = "Articulo"
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        Me.Articulo.Width = 90
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 300
        '
        'Entregado
        '
        Me.Entregado.DataPropertyName = "Entregado"
        Me.Entregado.HeaderText = "Entregado"
        Me.Entregado.Name = "Entregado"
        Me.Entregado.ReadOnly = True
        Me.Entregado.Width = 65
        '
        'Devuelto
        '
        Me.Devuelto.DataPropertyName = "Devuelto"
        Me.Devuelto.HeaderText = "Devuelto"
        Me.Devuelto.Name = "Devuelto"
        Me.Devuelto.ReadOnly = True
        Me.Devuelto.Width = 65
        '
        'Precio
        '
        Me.Precio.DataPropertyName = "Precio"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Precio.DefaultCellStyle = DataGridViewCellStyle1
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.Width = 95
        '
        'Costo
        '
        Me.Costo.DataPropertyName = "Costo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Costo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Costo.HeaderText = "Costo"
        Me.Costo.Name = "Costo"
        Me.Costo.ReadOnly = True
        Me.Costo.Width = 95
        '
        'CantCotizado
        '
        Me.CantCotizado.DataPropertyName = "CantCotizado"
        Me.CantCotizado.HeaderText = "Cant.Cotizado"
        Me.CantCotizado.Name = "CantCotizado"
        Me.CantCotizado.ReadOnly = True
        Me.CantCotizado.Width = 80
        '
        'PrecioCotizado
        '
        Me.PrecioCotizado.DataPropertyName = "PrecioCotizado"
        Me.PrecioCotizado.HeaderText = "PrecioCotizado"
        Me.PrecioCotizado.Name = "PrecioCotizado"
        Me.PrecioCotizado.ReadOnly = True
        Me.PrecioCotizado.Width = 85
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRubro.Location = New System.Drawing.Point(417, 52)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(62, 15)
        Me.lblRubro.TabIndex = 286
        Me.lblRubro.Text = "lblRubro"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(357, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 285
        Me.Label3.Text = "Rubro :"
        '
        'lblNumJob
        '
        Me.lblNumJob.AutoSize = True
        Me.lblNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumJob.Location = New System.Drawing.Point(65, 52)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(76, 15)
        Me.lblNumJob.TabIndex = 284
        Me.lblNumJob.Text = "lblNumJob"
        '
        'txtpreciocotizado
        '
        Me.txtpreciocotizado.DisabledBackColor = System.Drawing.SystemColors.Window
        Me.txtpreciocotizado.DisabledForeColor = System.Drawing.SystemColors.Desktop
        Me.txtpreciocotizado.Enabled = False
        Me.txtpreciocotizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpreciocotizado.FormatString = " ###,##0.00."
        Me.txtpreciocotizado.Location = New System.Drawing.Point(889, 23)
        Me.txtpreciocotizado.Name = "txtpreciocotizado"
        Me.txtpreciocotizado.ReadOnly = True
        Me.txtpreciocotizado.Size = New System.Drawing.Size(105, 21)
        Me.txtpreciocotizado.TabIndex = 295
        Me.txtpreciocotizado.TabStop = False
        Me.txtpreciocotizado.Text = " 0.00"
        Me.txtpreciocotizado.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'lblpreciocotizado
        '
        Me.lblpreciocotizado.AutoSize = True
        Me.lblpreciocotizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpreciocotizado.Location = New System.Drawing.Point(730, 28)
        Me.lblpreciocotizado.Name = "lblpreciocotizado"
        Me.lblpreciocotizado.Size = New System.Drawing.Size(45, 13)
        Me.lblpreciocotizado.TabIndex = 294
        Me.lblpreciocotizado.Text = "Label2"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtMontoSol)
        Me.UiGroupBox1.Controls.Add(Me.txtpreciocotizado)
        Me.UiGroupBox1.Controls.Add(Me.MontoDol)
        Me.UiGroupBox1.Controls.Add(Me.lblpreciocotizado)
        Me.UiGroupBox1.Controls.Add(Me.MontoSol)
        Me.UiGroupBox1.Controls.Add(Me.txtPrecioDol)
        Me.UiGroupBox1.Controls.Add(Me.txtMontoDol)
        Me.UiGroupBox1.Controls.Add(Me.PrecioDol)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 400)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(1034, 87)
        Me.UiGroupBox1.TabIndex = 296
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmJob_Mostrar_Repuestos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1034, 507)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.lblRubro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNumJob)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJob_Mostrar_Repuestos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Repuestos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtPrecioDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PrecioDol As System.Windows.Forms.Label
    Friend WithEvents txtMontoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtMontoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents MontoSol As System.Windows.Forms.Label
    Friend WithEvents MontoDol As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents lblRubro As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents txtpreciocotizado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblpreciocotizado As Label
    Friend WithEvents Item As DataGridViewTextBoxColumn
    Friend WithEvents Articulo As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Entregado As DataGridViewTextBoxColumn
    Friend WithEvents Devuelto As DataGridViewTextBoxColumn
    Friend WithEvents Precio As DataGridViewTextBoxColumn
    Friend WithEvents Costo As DataGridViewTextBoxColumn
    Friend WithEvents CantCotizado As DataGridViewTextBoxColumn
    Friend WithEvents PrecioCotizado As DataGridViewTextBoxColumn
    Friend WithEvents biImprimir As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
End Class
