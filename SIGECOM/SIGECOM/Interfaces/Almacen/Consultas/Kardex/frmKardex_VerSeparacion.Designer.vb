<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKardex_VerSeparacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKardex_VerSeparacion))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalSeparado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPendiente = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.cmOpciones.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(944, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 26)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 26)
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
        Me.dgvDatos.Location = New System.Drawing.Point(5, 16)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(1067, 306)
        Me.dgvDatos.TabIndex = 0
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gbDatos
        '
        Me.gbDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDatos.Controls.Add(Me.dgvDatos)
        Me.gbDatos.Location = New System.Drawing.Point(3, 1)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(1081, 338)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Beige
        Me.UiGroupBox1.Controls.Add(Me.txtTotalSeparado)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPendiente)
        Me.UiGroupBox1.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox1.Controls.Add(Me.lblTotal)
        Me.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox1.Location = New System.Drawing.Point(0, 350)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(1116, 33)
        Me.UiGroupBox1.TabIndex = 3
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalSeparado
        '
        Me.txtTotalSeparado.BackColor = System.Drawing.Color.White
        Me.txtTotalSeparado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSeparado.ForeColor = System.Drawing.Color.Black
        Me.txtTotalSeparado.Location = New System.Drawing.Point(827, 9)
        Me.txtTotalSeparado.MaxLength = 5
        Me.txtTotalSeparado.Name = "txtTotalSeparado"
        Me.txtTotalSeparado.ReadOnly = True
        Me.txtTotalSeparado.Size = New System.Drawing.Size(56, 20)
        Me.txtTotalSeparado.TabIndex = 7
        Me.txtTotalSeparado.Text = "0"
        Me.txtTotalSeparado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalSeparado.Value = CType(0, Long)
        Me.txtTotalSeparado.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtTotalSeparado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalPendiente
        '
        Me.txtTotalPendiente.BackColor = System.Drawing.Color.White
        Me.txtTotalPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPendiente.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPendiente.Location = New System.Drawing.Point(766, 9)
        Me.txtTotalPendiente.MaxLength = 5
        Me.txtTotalPendiente.Name = "txtTotalPendiente"
        Me.txtTotalPendiente.ReadOnly = True
        Me.txtTotalPendiente.Size = New System.Drawing.Size(60, 20)
        Me.txtTotalPendiente.TabIndex = 5
        Me.txtTotalPendiente.Text = "0"
        Me.txtTotalPendiente.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalPendiente.Value = CType(0, Long)
        Me.txtTotalPendiente.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        Me.txtTotalPendiente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotal.Location = New System.Drawing.Point(705, 11)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(57, 16)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "TOTAL"
        '
        'frmKardex_VerSeparacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1116, 383)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gbDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmKardex_VerSeparacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmKardex_VerSeparacion"
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalSeparado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPendiente As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label

End Class
