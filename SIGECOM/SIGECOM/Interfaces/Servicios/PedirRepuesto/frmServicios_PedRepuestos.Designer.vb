<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios_PedRepuestos
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicios_PedRepuestos))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biactualizar = New System.Windows.Forms.ToolStripButton()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkCliente = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biMostrar, Me.ToolStripSeparator2, Me.biactualizar, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(503, 31)
        Me.ToolStrip.TabIndex = 17
        Me.ToolStrip.Text = "ToolStrip"
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
        'biactualizar
        '
        Me.biactualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biactualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biactualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biactualizar.Name = "biactualizar"
        Me.biactualizar.Size = New System.Drawing.Size(28, 28)
        Me.biactualizar.Text = "Actualizar Datos"
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
        'txtIdCliente
        '
        Me.txtIdCliente.Location = New System.Drawing.Point(116, 57)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(202, 20)
        Me.txtIdCliente.TabIndex = 19
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(318, 56)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(28, 22)
        Me.btnBuscarCliente.TabIndex = 20
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(350, 57)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(71, 20)
        Me.txtNumDoc.TabIndex = 21
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(424, 55)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 23)
        Me.btnBuscar.TabIndex = 22
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(9, 89)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(480, 232)
        Me.dgvDatos.TabIndex = 22
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 333)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(503, 20)
        Me.ssBarra.TabIndex = 26
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
        'PictureBox1
        '
        Me.PictureBox1.Enabled = False
        Me.PictureBox1.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.PictureBox1.Location = New System.Drawing.Point(246, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 18)
        Me.PictureBox1.TabIndex = 32
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = "Limpiar Cliente"
        '
        'chkCliente
        '
        Me.chkCliente.AutoSize = True
        Me.chkCliente.Checked = True
        Me.chkCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCliente.Location = New System.Drawing.Point(229, 40)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(15, 14)
        Me.chkCliente.TabIndex = 31
        Me.chkCliente.Tag = ""
        Me.chkCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkCliente.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(181, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Cliente"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Location = New System.Drawing.Point(9, 57)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(101, 20)
        Me.cmbIdLocacion.TabIndex = 18
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Locación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(372, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "OT"
        '
        'frmServicios_PedRepuestos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(503, 353)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbIdLocacion)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.chkCliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtNumDoc)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios_PedRepuestos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos de Mercaderia para OT's"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biactualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
