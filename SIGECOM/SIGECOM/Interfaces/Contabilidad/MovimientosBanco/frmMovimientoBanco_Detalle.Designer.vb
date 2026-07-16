<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientoBanco_Detalle
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
        Dim cmbTipMov_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientoBanco_Detalle))
        Me.gbGastoViaje = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbConciliar = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lbltipmov = New System.Windows.Forms.Label()
        Me.cmbTipMov = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.txtDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtCheque = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecPlanilla = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFecBanco = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGastoViaje.SuspendLayout()
        CType(Me.cmbTipMov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbGastoViaje
        '
        Me.gbGastoViaje.Controls.Add(Me.cbConciliar)
        Me.gbGastoViaje.Controls.Add(Me.Label5)
        Me.gbGastoViaje.Controls.Add(Me.Label4)
        Me.gbGastoViaje.Controls.Add(Me.txtMonto)
        Me.gbGastoViaje.Controls.Add(Me.lbltipmov)
        Me.gbGastoViaje.Controls.Add(Me.cmbTipMov)
        Me.gbGastoViaje.Controls.Add(Me.lblMotivo)
        Me.gbGastoViaje.Controls.Add(Me.txtDescripcion)
        Me.gbGastoViaje.Controls.Add(Me.txtCheque)
        Me.gbGastoViaje.Controls.Add(Me.Label2)
        Me.gbGastoViaje.Controls.Add(Me.txtFecPlanilla)
        Me.gbGastoViaje.Controls.Add(Me.Label1)
        Me.gbGastoViaje.Controls.Add(Me.txtFecBanco)
        Me.gbGastoViaje.Controls.Add(Me.Label10)
        Me.gbGastoViaje.Location = New System.Drawing.Point(6, 29)
        Me.gbGastoViaje.Name = "gbGastoViaje"
        Me.gbGastoViaje.Size = New System.Drawing.Size(618, 165)
        Me.gbGastoViaje.TabIndex = 9
        Me.gbGastoViaje.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbConciliar
        '
        Me.cbConciliar.AutoSize = True
        Me.cbConciliar.Location = New System.Drawing.Point(526, 111)
        Me.cbConciliar.Name = "cbConciliar"
        Me.cbConciliar.Size = New System.Drawing.Size(15, 14)
        Me.cbConciliar.TabIndex = 8
        Me.cbConciliar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(464, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 256
        Me.Label5.Text = "Conciliar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 254
        Me.Label4.Text = "Monto"
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(101, 136)
        Me.txtMonto.MaxLength = 12
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(101, 20)
        Me.txtMonto.TabIndex = 6
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbltipmov
        '
        Me.lbltipmov.AutoSize = True
        Me.lbltipmov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltipmov.Location = New System.Drawing.Point(31, 112)
        Me.lbltipmov.Name = "lbltipmov"
        Me.lbltipmov.Size = New System.Drawing.Size(64, 13)
        Me.lbltipmov.TabIndex = 251
        Me.lbltipmov.Text = "Tipo Mov."
        '
        'cmbTipMov
        '
        Me.cmbTipMov.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipMov_DesignTimeLayout.LayoutString = resources.GetString("cmbTipMov_DesignTimeLayout.LayoutString")
        Me.cmbTipMov.DesignTimeLayout = cmbTipMov_DesignTimeLayout
        Me.cmbTipMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipMov.Location = New System.Drawing.Point(101, 108)
        Me.cmbTipMov.Name = "cmbTipMov"
        Me.cmbTipMov.SelectedIndex = -1
        Me.cmbTipMov.SelectedItem = Nothing
        Me.cmbTipMov.Size = New System.Drawing.Size(172, 19)
        Me.cmbTipMov.TabIndex = 5
        Me.cmbTipMov.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotivo.Location = New System.Drawing.Point(21, 65)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(74, 13)
        Me.lblMotivo.TabIndex = 250
        Me.lblMotivo.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(101, 45)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(504, 54)
        Me.txtDescripcion.TabIndex = 4
        '
        'txtCheque
        '
        Me.txtCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheque.Location = New System.Drawing.Point(474, 16)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Numeric = True
        Me.txtCheque.Size = New System.Drawing.Size(131, 20)
        Me.txtCheque.TabIndex = 3
        Me.txtCheque.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(418, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "Cheque"
        '
        'txtFecPlanilla
        '
        '
        '
        '
        Me.txtFecPlanilla.DropDownCalendar.FirstMonth = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecPlanilla.DropDownCalendar.Name = ""
        Me.txtFecPlanilla.DropDownCalendar.Visible = False
        Me.txtFecPlanilla.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecPlanilla.Location = New System.Drawing.Point(101, 16)
        Me.txtFecPlanilla.Name = "txtFecPlanilla"
        Me.txtFecPlanilla.NullButtonText = "Ninguno"
        Me.txtFecPlanilla.Size = New System.Drawing.Size(92, 20)
        Me.txtFecPlanilla.TabIndex = 1
        Me.txtFecPlanilla.TodayButtonText = "Hoy"
        Me.txtFecPlanilla.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 245
        Me.Label1.Text = "Fecha Planilla"
        '
        'txtFecBanco
        '
        '
        '
        '
        Me.txtFecBanco.DropDownCalendar.FirstMonth = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecBanco.DropDownCalendar.Name = ""
        Me.txtFecBanco.DropDownCalendar.Visible = False
        Me.txtFecBanco.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecBanco.Location = New System.Drawing.Point(305, 16)
        Me.txtFecBanco.Name = "txtFecBanco"
        Me.txtFecBanco.NullButtonText = "Ninguno"
        Me.txtFecBanco.Size = New System.Drawing.Size(92, 20)
        Me.txtFecBanco.TabIndex = 2
        Me.txtFecBanco.TodayButtonText = "Hoy"
        Me.txtFecBanco.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(217, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 243
        Me.Label10.Text = "Fecha Banco"
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(631, 31)
        Me.ToolStrip.TabIndex = 189
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmMovimientoBanco_Detalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(631, 204)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbGastoViaje)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMovimientoBanco_Detalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimiento Banco Detalle"
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGastoViaje.ResumeLayout(False)
        Me.gbGastoViaje.PerformLayout()
        CType(Me.cmbTipMov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbGastoViaje As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecPlanilla As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFecBanco As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCheque As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbltipmov As System.Windows.Forms.Label
    Friend WithEvents cmbTipMov As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cbConciliar As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
