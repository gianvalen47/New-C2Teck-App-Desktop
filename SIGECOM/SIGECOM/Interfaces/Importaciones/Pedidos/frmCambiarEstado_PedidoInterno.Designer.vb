<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiarEstado_PedidoInterno
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambiarEstado_PedidoInterno))
        Dim dgvCorreos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.cEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cObservacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnCambiarEstado = New System.Windows.Forms.Button()
        Me.btnRechazarPedido = New System.Windows.Forms.Button()
        Me.gbCorreos = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvCorreos = New Janus.Windows.GridEX.GridEX()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCorreos.SuspendLayout()
        CType(Me.dgvCorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cEstado, Me.cFecha, Me.cObservacion, Me.cCodUsu})
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        Me.dgvDatos.Location = New System.Drawing.Point(4, 17)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDatos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(551, 170)
        Me.dgvDatos.TabIndex = 0
        '
        'cEstado
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cEstado.DefaultCellStyle = DataGridViewCellStyle2
        Me.cEstado.HeaderText = "Estado"
        Me.cEstado.Name = "cEstado"
        Me.cEstado.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'cFecha
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.cFecha.DefaultCellStyle = DataGridViewCellStyle3
        Me.cFecha.HeaderText = "Fecha"
        Me.cFecha.Name = "cFecha"
        Me.cFecha.ReadOnly = True
        Me.cFecha.Width = 130
        '
        'cObservacion
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cObservacion.DefaultCellStyle = DataGridViewCellStyle4
        Me.cObservacion.HeaderText = "Observación"
        Me.cObservacion.Name = "cObservacion"
        Me.cObservacion.ReadOnly = True
        Me.cObservacion.Width = 200
        '
        'cCodUsu
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodUsu.DefaultCellStyle = DataGridViewCellStyle5
        Me.cCodUsu.HeaderText = "Usuario"
        Me.cCodUsu.Name = "cCodUsu"
        Me.cCodUsu.ReadOnly = True
        Me.cCodUsu.Width = 80
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
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.txtUsuario)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.txtObservacion)
        Me.gbDatos.Controls.Add(Me.Label21)
        Me.gbDatos.Controls.Add(Me.txtEstado)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(6, 1)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(560, 83)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Cambio de Estado"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtUsuario.Location = New System.Drawing.Point(361, 15)
        Me.txtUsuario.MaxLength = 50
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(194, 20)
        Me.txtUsuario.TabIndex = 1
        Me.txtUsuario.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(312, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Usuario"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(110, 37)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(446, 40)
        Me.txtObservacion.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 35)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Observación"
        '
        'txtEstado
        '
        Me.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtEstado.Location = New System.Drawing.Point(110, 15)
        Me.txtEstado.MaxLength = 50
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(194, 20)
        Me.txtEstado.TabIndex = 0
        Me.txtEstado.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Siguiente Estado"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvDatos)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 193)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seguimiento de los procesos del pedido"
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
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(488, 89)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 27)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCambiarEstado
        '
        Me.btnCambiarEstado.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnCambiarEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCambiarEstado.Location = New System.Drawing.Point(410, 89)
        Me.btnCambiarEstado.Name = "btnCambiarEstado"
        Me.btnCambiarEstado.Size = New System.Drawing.Size(77, 27)
        Me.btnCambiarEstado.TabIndex = 2
        Me.btnCambiarEstado.Text = "Aprobar"
        Me.btnCambiarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCambiarEstado.UseVisualStyleBackColor = True
        '
        'btnRechazarPedido
        '
        Me.btnRechazarPedido.Image = CType(resources.GetObject("btnRechazarPedido.Image"), System.Drawing.Image)
        Me.btnRechazarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRechazarPedido.Location = New System.Drawing.Point(291, 89)
        Me.btnRechazarPedido.Name = "btnRechazarPedido"
        Me.btnRechazarPedido.Size = New System.Drawing.Size(113, 27)
        Me.btnRechazarPedido.TabIndex = 5
        Me.btnRechazarPedido.Text = "Rechazar Pedido"
        Me.btnRechazarPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRechazarPedido.UseVisualStyleBackColor = True
        '
        'gbCorreos
        '
        Me.gbCorreos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCorreos.Controls.Add(Me.dgvCorreos)
        Me.gbCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCorreos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.gbCorreos.Location = New System.Drawing.Point(5, 266)
        Me.gbCorreos.Name = "gbCorreos"
        Me.gbCorreos.Size = New System.Drawing.Size(563, 147)
        Me.gbCorreos.TabIndex = 190
        Me.gbCorreos.Text = "Enviar Correos"
        Me.gbCorreos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvCorreos
        '
        Me.dgvCorreos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvCorreos_DesignTimeLayout.LayoutString = resources.GetString("dgvCorreos_DesignTimeLayout.LayoutString")
        Me.dgvCorreos.DesignTimeLayout = dgvCorreos_DesignTimeLayout
        Me.dgvCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvCorreos.GroupByBoxVisible = False
        Me.dgvCorreos.Location = New System.Drawing.Point(6, 17)
        Me.dgvCorreos.Name = "dgvCorreos"
        Me.dgvCorreos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCorreos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCorreos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCorreos.Size = New System.Drawing.Size(549, 122)
        Me.dgvCorreos.TabIndex = 187
        Me.dgvCorreos.TabStop = False
        Me.dgvCorreos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmCambiarEstado_PedidoInterno
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(595, 433)
        Me.Controls.Add(Me.btnRechazarPedido)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.gbCorreos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCambiarEstado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambiarEstado_PedidoInterno"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cambiar estado del pedido interno"
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCorreos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCorreos.ResumeLayout(False)
        CType(Me.dgvCorreos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCambiarEstado As System.Windows.Forms.Button
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cObservacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCodUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRechazarPedido As System.Windows.Forms.Button
    Friend WithEvents gbCorreos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvCorreos As Janus.Windows.GridEX.GridEX

End Class
