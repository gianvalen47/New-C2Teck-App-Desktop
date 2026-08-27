<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAtenderJob_Detalles
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
        Dim cmbAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAtenderJob_Detalles))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.biImprimir = New System.Windows.Forms.ToolStripButton
        Me.biDespachar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton
        Me.biSeparar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.biGenerarTransferencia = New System.Windows.Forms.ToolStripButton
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.lblAlmacen = New System.Windows.Forms.Label
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNumero = New System.Windows.Forms.TextBox
        Me.dgvDatos = New System.Windows.Forms.DataGridView
        Me.cCodMer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cDesMer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cCanPed = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cCanAte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cCanPen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cAtender = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cStock = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rbSeleccionrTodos = New Janus.Windows.EditControls.UICheckBox
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cmbAlmacen_DesignTimeLayout.LayoutString")
        Me.cmbAlmacen.DesignTimeLayout = cmbAlmacen_DesignTimeLayout
        Me.cmbAlmacen.Location = New System.Drawing.Point(73, 55)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.SelectedIndex = -1
        Me.cmbAlmacen.SelectedItem = Nothing
        Me.cmbAlmacen.Size = New System.Drawing.Size(168, 20)
        Me.cmbAlmacen.TabIndex = 1
        Me.cmbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biImprimir, Me.biDespachar, Me.ToolStripSeparator1, Me.biDeshacer, Me.biSeparar, Me.ToolStripSeparator2, Me.biGenerarTransferencia, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(604, 31)
        Me.ToolStrip.TabIndex = 28
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Listado"
        '
        'biDespachar
        '
        Me.biDespachar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDespachar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biDespachar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDespachar.Name = "biDespachar"
        Me.biDespachar.Size = New System.Drawing.Size(28, 28)
        Me.biDespachar.Text = "Despachar Mercadería"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios Realizados"
        '
        'biSeparar
        '
        Me.biSeparar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSeparar.Image = Global.SIGECOM.My.Resources.Resources.CrdFle04
        Me.biSeparar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSeparar.Name = "biSeparar"
        Me.biSeparar.Size = New System.Drawing.Size(28, 28)
        Me.biSeparar.Text = "Separar Mercadería"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerarTransferencia
        '
        Me.biGenerarTransferencia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarTransferencia.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.biGenerarTransferencia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarTransferencia.Name = "biGenerarTransferencia"
        Me.biGenerarTransferencia.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarTransferencia.Text = "GenerarTransferencia"
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
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(12, 59)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(55, 13)
        Me.lblAlmacen.TabIndex = 29
        Me.lblAlmacen.Text = "Almacén"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 412)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(604, 20)
        Me.ssBarra.TabIndex = 31
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 383)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Número"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(172, 383)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Fecha"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(66, 380)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(80, 20)
        Me.txtNumero.TabIndex = 2
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
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cCodMer, Me.cDesMer, Me.cCanPed, Me.cCanAte, Me.cCanPen, Me.cAtender, Me.cStock})
        Me.dgvDatos.Location = New System.Drawing.Point(6, 94)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(592, 272)
        Me.dgvDatos.TabIndex = 34
        '
        'cCodMer
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodMer.DefaultCellStyle = DataGridViewCellStyle2
        Me.cCodMer.HeaderText = "Código"
        Me.cCodMer.Name = "cCodMer"
        Me.cCodMer.ReadOnly = True
        Me.cCodMer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cCodMer.Width = 90
        '
        'cDesMer
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.cDesMer.DefaultCellStyle = DataGridViewCellStyle3
        Me.cDesMer.HeaderText = "Descripción"
        Me.cDesMer.Name = "cDesMer"
        Me.cDesMer.ReadOnly = True
        Me.cDesMer.Width = 175
        '
        'cCanPed
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCanPed.DefaultCellStyle = DataGridViewCellStyle4
        Me.cCanPed.HeaderText = "Can.Ped."
        Me.cCanPed.Name = "cCanPed"
        Me.cCanPed.ReadOnly = True
        Me.cCanPed.Width = 60
        '
        'cCanAte
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCanAte.DefaultCellStyle = DataGridViewCellStyle5
        Me.cCanAte.HeaderText = "Can.Ate."
        Me.cCanAte.Name = "cCanAte"
        Me.cCanAte.ReadOnly = True
        Me.cCanAte.Width = 55
        '
        'cCanPen
        '
        Me.cCanPen.HeaderText = "Can.Pen."
        Me.cCanPen.Name = "cCanPen"
        Me.cCanPen.ReadOnly = True
        Me.cCanPen.Width = 60
        '
        'cAtender
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Tan
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.cAtender.DefaultCellStyle = DataGridViewCellStyle6
        Me.cAtender.HeaderText = "Atender"
        Me.cAtender.Name = "cAtender"
        Me.cAtender.ReadOnly = True
        Me.cAtender.Width = 55
        '
        'cStock
        '
        Me.cStock.HeaderText = "Stock"
        Me.cStock.Name = "cStock"
        Me.cStock.ReadOnly = True
        Me.cStock.Width = 55
        '
        'rbSeleccionrTodos
        '
        Me.rbSeleccionrTodos.Enabled = False
        Me.rbSeleccionrTodos.Location = New System.Drawing.Point(492, 68)
        Me.rbSeleccionrTodos.Name = "rbSeleccionrTodos"
        Me.rbSeleccionrTodos.Size = New System.Drawing.Size(20, 23)
        Me.rbSeleccionrTodos.TabIndex = 35
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(220, 380)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.ShowNullButton = True
        Me.txtFecha.Size = New System.Drawing.Size(85, 20)
        Me.txtFecha.TabIndex = 3
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'frmAtenderJob_Detalles
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(604, 432)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.rbSeleccionrTodos)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.lblAlmacen)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.cmbAlmacen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAtenderJob_Detalles"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAtenderJob_Detalles"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cmbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biDespachar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSeparar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents biGenerarTransferencia As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents rbSeleccionrTodos As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cCodMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDesMer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCanPed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCanAte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCanPen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cAtender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
End Class
