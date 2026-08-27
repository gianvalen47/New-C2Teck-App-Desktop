<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKardex_VerStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKardex_VerStock))
        Dim cmbCodRub_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtComprometido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPorFacturar = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalFacturado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPedido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalStock = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(664, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Año"
        '
        'txtanio
        '
        Me.txtanio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtanio.Location = New System.Drawing.Point(696, 15)
        Me.txtanio.Maximum = 2059
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2010
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(70, 20)
        Me.txtanio.TabIndex = 20
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2010
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(780, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(72, 25)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Beige
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDisponible)
        Me.UiGroupBox1.Controls.Add(Me.txtComprometido)
        Me.UiGroupBox1.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPorFacturar)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalFacturado)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPedido)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalStock)
        Me.UiGroupBox1.Controls.Add(Me.lblTotal)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 348)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(895, 47)
        Me.UiGroupBox1.TabIndex = 2
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalDisponible
        '
        Me.txtTotalDisponible.BackColor = System.Drawing.Color.White
        Me.txtTotalDisponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDisponible.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDisponible.Location = New System.Drawing.Point(363, 15)
        Me.txtTotalDisponible.MaxLength = 5
        Me.txtTotalDisponible.Name = "txtTotalDisponible"
        Me.txtTotalDisponible.ReadOnly = True
        Me.txtTotalDisponible.Size = New System.Drawing.Size(63, 20)
        Me.txtTotalDisponible.TabIndex = 12
        Me.txtTotalDisponible.Text = "0"
        Me.txtTotalDisponible.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalDisponible.Value = CType(0, Long)
        Me.txtTotalDisponible.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtTotalDisponible.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtComprometido
        '
        Me.txtComprometido.BackColor = System.Drawing.Color.White
        Me.txtComprometido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprometido.ForeColor = System.Drawing.Color.Black
        Me.txtComprometido.Location = New System.Drawing.Point(301, 15)
        Me.txtComprometido.MaxLength = 5
        Me.txtComprometido.Name = "txtComprometido"
        Me.txtComprometido.ReadOnly = True
        Me.txtComprometido.Size = New System.Drawing.Size(61, 20)
        Me.txtComprometido.TabIndex = 11
        Me.txtComprometido.Text = "0"
        Me.txtComprometido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtComprometido.Value = CType(0, Long)
        Me.txtComprometido.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtComprometido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalPorFacturar
        '
        Me.txtTotalPorFacturar.BackColor = System.Drawing.Color.White
        Me.txtTotalPorFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPorFacturar.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPorFacturar.Location = New System.Drawing.Point(790, 15)
        Me.txtTotalPorFacturar.MaxLength = 5
        Me.txtTotalPorFacturar.Name = "txtTotalPorFacturar"
        Me.txtTotalPorFacturar.ReadOnly = True
        Me.txtTotalPorFacturar.Size = New System.Drawing.Size(56, 20)
        Me.txtTotalPorFacturar.TabIndex = 7
        Me.txtTotalPorFacturar.Text = "0"
        Me.txtTotalPorFacturar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalPorFacturar.Value = CType(0, Long)
        Me.txtTotalPorFacturar.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtTotalPorFacturar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalFacturado
        '
        Me.txtTotalFacturado.BackColor = System.Drawing.Color.White
        Me.txtTotalFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalFacturado.ForeColor = System.Drawing.Color.Black
        Me.txtTotalFacturado.Location = New System.Drawing.Point(729, 15)
        Me.txtTotalFacturado.MaxLength = 5
        Me.txtTotalFacturado.Name = "txtTotalFacturado"
        Me.txtTotalFacturado.ReadOnly = True
        Me.txtTotalFacturado.Size = New System.Drawing.Size(60, 20)
        Me.txtTotalFacturado.TabIndex = 5
        Me.txtTotalFacturado.Text = "0"
        Me.txtTotalFacturado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalFacturado.Value = CType(0, Long)
        Me.txtTotalFacturado.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtTotalFacturado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalPedido
        '
        Me.txtTotalPedido.BackColor = System.Drawing.Color.White
        Me.txtTotalPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPedido.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPedido.Location = New System.Drawing.Point(427, 15)
        Me.txtTotalPedido.MaxLength = 5
        Me.txtTotalPedido.Name = "txtTotalPedido"
        Me.txtTotalPedido.ReadOnly = True
        Me.txtTotalPedido.Size = New System.Drawing.Size(57, 20)
        Me.txtTotalPedido.TabIndex = 3
        Me.txtTotalPedido.Text = "0"
        Me.txtTotalPedido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalPedido.Value = CType(0, Long)
        Me.txtTotalPedido.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtTotalPedido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalStock
        '
        Me.txtTotalStock.BackColor = System.Drawing.Color.White
        Me.txtTotalStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalStock.ForeColor = System.Drawing.Color.Black
        Me.txtTotalStock.Location = New System.Drawing.Point(235, 15)
        Me.txtTotalStock.MaxLength = 5
        Me.txtTotalStock.Name = "txtTotalStock"
        Me.txtTotalStock.ReadOnly = True
        Me.txtTotalStock.Size = New System.Drawing.Size(65, 20)
        Me.txtTotalStock.TabIndex = 1
        Me.txtTotalStock.Text = "0"
        Me.txtTotalStock.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalStock.Value = CType(0, Long)
        Me.txtTotalStock.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtTotalStock.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotal.Location = New System.Drawing.Point(50, 17)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(77, 16)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "TOTALES"
        '
        'gbDatos
        '
        Me.gbDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.txtanio)
        Me.gbDatos.Controls.Add(Me.btnBuscar)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.dgvDatos)
        Me.gbDatos.Location = New System.Drawing.Point(8, 4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(867, 338)
        Me.gbDatos.TabIndex = 9
        Me.gbDatos.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(614, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 15)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "/--------------------^--------------------\"
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(5, 50)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(853, 272)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 26)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(852, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(31, 25)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Location = New System.Drawing.Point(375, 29)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(90, 20)
        Me.cmbCodRub.TabIndex = 8
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmKardex_VerStock
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(895, 395)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.cmbCodRub)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKardex_VerStock"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmKardex_VerStock"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalStock As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtTotalPorFacturar As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalFacturado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPedido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComprometido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDisponible As Janus.Windows.GridEX.EditControls.NumericEditBox

End Class
