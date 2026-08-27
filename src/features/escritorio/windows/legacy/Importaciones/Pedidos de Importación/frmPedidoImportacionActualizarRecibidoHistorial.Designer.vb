<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidoImportacionActualizarRecibidoHistorial
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
        Dim cmbIdProveedor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidoImportacionActualizarRecibidoHistorial))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumFactura = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumPed = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbIdProveedor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvPrueba = New System.Windows.Forms.DataGridView()
        Me.IdDetPedidoImp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumPed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesMer1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanMer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanRec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdPedidoImp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeterCEROTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtEmbarque = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbIdProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPrueba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox1.BackgroundStyle = Janus.Windows.EditControls.BackgroundStyle.ExplorerBarGroupBackground
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.txtCodMer)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtNumFactura)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtNumPed)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.cmbIdProveedor)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.dgvPrueba)
        Me.UiGroupBox1.Controls.Add(Me.txtEmbarque)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 4)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(839, 350)
        Me.UiGroupBox1.TabIndex = 6
        Me.UiGroupBox1.Text = "Datos Generales"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.VS2005
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(610, 29)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(63, 25)
        Me.btnBuscar.TabIndex = 18
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtCodMer
        '
        Me.txtCodMer.BackColor = System.Drawing.Color.White
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodMer.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodMer.Location = New System.Drawing.Point(530, 31)
        Me.txtCodMer.MaxLength = 200
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(76, 20)
        Me.txtCodMer.TabIndex = 16
        Me.txtCodMer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(541, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Nro. Parte"
        '
        'txtNumFactura
        '
        Me.txtNumFactura.BackColor = System.Drawing.Color.White
        Me.txtNumFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumFactura.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumFactura.Location = New System.Drawing.Point(448, 31)
        Me.txtNumFactura.MaxLength = 200
        Me.txtNumFactura.Name = "txtNumFactura"
        Me.txtNumFactura.Size = New System.Drawing.Size(76, 20)
        Me.txtNumFactura.TabIndex = 14
        Me.txtNumFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(453, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Nro. Factura"
        '
        'txtNumPed
        '
        Me.txtNumPed.BackColor = System.Drawing.Color.White
        Me.txtNumPed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumPed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumPed.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumPed.Location = New System.Drawing.Point(366, 31)
        Me.txtNumPed.MaxLength = 200
        Me.txtNumPed.Name = "txtNumPed"
        Me.txtNumPed.Size = New System.Drawing.Size(76, 20)
        Me.txtNumPed.TabIndex = 12
        Me.txtNumPed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(373, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Nro. Pedido"
        '
        'cmbIdProveedor
        '
        Me.cmbIdProveedor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdProveedor_DesignTimeLayout.LayoutString = resources.GetString("cmbIdProveedor_DesignTimeLayout.LayoutString")
        Me.cmbIdProveedor.DesignTimeLayout = cmbIdProveedor_DesignTimeLayout
        Me.cmbIdProveedor.Location = New System.Drawing.Point(6, 31)
        Me.cmbIdProveedor.Name = "cmbIdProveedor"
        Me.cmbIdProveedor.SelectedIndex = -1
        Me.cmbIdProveedor.SelectedItem = Nothing
        Me.cmbIdProveedor.Size = New System.Drawing.Size(272, 20)
        Me.cmbIdProveedor.TabIndex = 10
        Me.cmbIdProveedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(113, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Proveedor"
        '
        'dgvPrueba
        '
        Me.dgvPrueba.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPrueba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrueba.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDetPedidoImp, Me.NumPed, Me.CodMer, Me.DesMer1, Me.CanMer, Me.CanRec, Me.Observacion, Me.IdPedidoImp})
        Me.dgvPrueba.ContextMenuStrip = Me.cmOpciones
        Me.dgvPrueba.Location = New System.Drawing.Point(7, 56)
        Me.dgvPrueba.Name = "dgvPrueba"
        Me.dgvPrueba.Size = New System.Drawing.Size(817, 284)
        Me.dgvPrueba.TabIndex = 7
        '
        'IdDetPedidoImp
        '
        Me.IdDetPedidoImp.DataPropertyName = "IdDetPedidoImp"
        Me.IdDetPedidoImp.HeaderText = "IdDetPedidoImp"
        Me.IdDetPedidoImp.Name = "IdDetPedidoImp"
        Me.IdDetPedidoImp.Visible = False
        Me.IdDetPedidoImp.Width = 80
        '
        'NumPed
        '
        Me.NumPed.DataPropertyName = "NumPed"
        Me.NumPed.HeaderText = "Nro.Pedido"
        Me.NumPed.Name = "NumPed"
        Me.NumPed.Width = 70
        '
        'CodMer
        '
        Me.CodMer.DataPropertyName = "CodMer"
        Me.CodMer.HeaderText = "Código"
        Me.CodMer.Name = "CodMer"
        Me.CodMer.Width = 110
        '
        'DesMer1
        '
        Me.DesMer1.DataPropertyName = "DesMer1"
        Me.DesMer1.HeaderText = "Descripción"
        Me.DesMer1.Name = "DesMer1"
        Me.DesMer1.Width = 230
        '
        'CanMer
        '
        Me.CanMer.DataPropertyName = "CanMer"
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Me.CanMer.DefaultCellStyle = DataGridViewCellStyle1
        Me.CanMer.HeaderText = "Cant."
        Me.CanMer.Name = "CanMer"
        Me.CanMer.Width = 55
        '
        'CanRec
        '
        Me.CanRec.DataPropertyName = "CanRec"
        Me.CanRec.HeaderText = "Recibido"
        Me.CanRec.Name = "CanRec"
        Me.CanRec.Width = 55
        '
        'Observacion
        '
        Me.Observacion.DataPropertyName = "Observacion"
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.Width = 220
        '
        'IdPedidoImp
        '
        Me.IdPedidoImp.DataPropertyName = "IdPedidoImp"
        Me.IdPedidoImp.HeaderText = "IdPedidoImp"
        Me.IdPedidoImp.Name = "IdPedidoImp"
        Me.IdPedidoImp.Visible = False
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodo, Me.miSeterCEROTodos, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(174, 76)
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
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(170, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(173, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'txtEmbarque
        '
        Me.txtEmbarque.BackColor = System.Drawing.Color.White
        Me.txtEmbarque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmbarque.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtEmbarque.Location = New System.Drawing.Point(284, 31)
        Me.txtEmbarque.MaxLength = 200
        Me.txtEmbarque.Name = "txtEmbarque"
        Me.txtEmbarque.Size = New System.Drawing.Size(76, 20)
        Me.txtEmbarque.TabIndex = 1
        Me.txtEmbarque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(295, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Embarque"
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
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(855, 360)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(415, 366)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(36, 13)
        Me.lblTotal.TabIndex = 12
        Me.lblTotal.Text = "Total"
        '
        'frmPedidoImportacionActualizarRecibidoHistorial
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(867, 419)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPedidoImportacionActualizarRecibidoHistorial"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Historial de Actualización de Orden de Pedidos de Importación"
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbIdProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPrueba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeleccionarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeterCEROTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvPrueba As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtCodMer As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNumFactura As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNumPed As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbIdProveedor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents IdDetPedidoImp As DataGridViewTextBoxColumn
    Friend WithEvents NumPed As DataGridViewTextBoxColumn
    Friend WithEvents CodMer As DataGridViewTextBoxColumn
    Friend WithEvents DesMer1 As DataGridViewTextBoxColumn
    Friend WithEvents CanMer As DataGridViewTextBoxColumn
    Friend WithEvents CanRec As DataGridViewTextBoxColumn
    Friend WithEvents Observacion As DataGridViewTextBoxColumn
    Friend WithEvents IdPedidoImp As DataGridViewTextBoxColumn
End Class
