<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepPlanillaOficial
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
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepPlanillaOficial))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtMesRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.rbPeriodo = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPlanilla = New Janus.Windows.EditControls.UIRadioButton()
        Me.txtIdPlanilla = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.btnBuscarPlanillaSueldo = New System.Windows.Forms.Button()
        Me.gbExportar = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbResumen = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbDetalle = New Janus.Windows.EditControls.UIRadioButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExportar.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.cmbUnidad)
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox1.Controls.Add(Me.gbExportar)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 3)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(264, 219)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 261
        Me.Label5.Text = "Unidad de Negocio"
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(133, 68)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(120, 20)
        Me.cmbUnidad.TabIndex = 260
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtMesRegistro)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.txtPeriodo)
        Me.UiGroupBox2.Controls.Add(Me.rbPeriodo)
        Me.UiGroupBox2.Controls.Add(Me.rbPlanilla)
        Me.UiGroupBox2.Controls.Add(Me.txtIdPlanilla)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarPlanillaSueldo)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(9, 96)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(244, 115)
        Me.UiGroupBox2.TabIndex = 21
        Me.UiGroupBox2.Text = "Busqueda X"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtMesRegistro
        '
        Me.txtMesRegistro.BackColor = System.Drawing.SystemColors.Control
        Me.txtMesRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesRegistro.Location = New System.Drawing.Point(87, 86)
        Me.txtMesRegistro.MaxLength = 2
        Me.txtMesRegistro.Name = "txtMesRegistro"
        Me.txtMesRegistro.Numeric = True
        Me.txtMesRegistro.ReadOnly = True
        Me.txtMesRegistro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMesRegistro.Size = New System.Drawing.Size(47, 20)
        Me.txtMesRegistro.TabIndex = 228
        Me.txtMesRegistro.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 227
        Me.Label2.Text = "Mes"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.SystemColors.Control
        Me.txtPeriodo.Location = New System.Drawing.Point(148, 86)
        Me.txtPeriodo.Maximum = 2059
        Me.txtPeriodo.Minimum = 2006
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.Size = New System.Drawing.Size(65, 20)
        Me.txtPeriodo.TabIndex = 193
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.Value = 2006
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'rbPeriodo
        '
        Me.rbPeriodo.Location = New System.Drawing.Point(25, 66)
        Me.rbPeriodo.Name = "rbPeriodo"
        Me.rbPeriodo.Size = New System.Drawing.Size(85, 16)
        Me.rbPeriodo.TabIndex = 3
        Me.rbPeriodo.Text = "Periodo"
        Me.rbPeriodo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPlanilla
        '
        Me.rbPlanilla.Checked = True
        Me.rbPlanilla.Location = New System.Drawing.Point(25, 21)
        Me.rbPlanilla.Name = "rbPlanilla"
        Me.rbPlanilla.Size = New System.Drawing.Size(105, 14)
        Me.rbPlanilla.TabIndex = 1
        Me.rbPlanilla.TabStop = True
        Me.rbPlanilla.Text = "Nro de Planilla"
        Me.rbPlanilla.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtIdPlanilla
        '
        Me.txtIdPlanilla.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIdPlanilla.Location = New System.Drawing.Point(87, 40)
        Me.txtIdPlanilla.MaxLength = 9
        Me.txtIdPlanilla.Name = "txtIdPlanilla"
        Me.txtIdPlanilla.Numeric = True
        Me.txtIdPlanilla.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtIdPlanilla.Size = New System.Drawing.Size(64, 20)
        Me.txtIdPlanilla.TabIndex = 1
        Me.txtIdPlanilla.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '
        'btnBuscarPlanillaSueldo
        '
        Me.btnBuscarPlanillaSueldo.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPlanillaSueldo.Location = New System.Drawing.Point(154, 39)
        Me.btnBuscarPlanillaSueldo.Name = "btnBuscarPlanillaSueldo"
        Me.btnBuscarPlanillaSueldo.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPlanillaSueldo.TabIndex = 2
        Me.btnBuscarPlanillaSueldo.UseVisualStyleBackColor = True
        '
        'gbExportar
        '
        Me.gbExportar.Controls.Add(Me.rbResumen)
        Me.gbExportar.Controls.Add(Me.rbDetalle)
        Me.gbExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbExportar.Location = New System.Drawing.Point(9, 10)
        Me.gbExportar.Name = "gbExportar"
        Me.gbExportar.Size = New System.Drawing.Size(246, 50)
        Me.gbExportar.TabIndex = 20
        Me.gbExportar.Text = "Tipo"
        Me.gbExportar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbResumen
        '
        Me.rbResumen.Location = New System.Drawing.Point(110, 21)
        Me.rbResumen.Name = "rbResumen"
        Me.rbResumen.Size = New System.Drawing.Size(80, 16)
        Me.rbResumen.TabIndex = 3
        Me.rbResumen.Text = "Resumen"
        Me.rbResumen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbDetalle
        '
        Me.rbDetalle.Checked = True
        Me.rbDetalle.Location = New System.Drawing.Point(27, 23)
        Me.rbDetalle.Name = "rbDetalle"
        Me.rbDetalle.Size = New System.Drawing.Size(71, 14)
        Me.rbDetalle.TabIndex = 1
        Me.rbDetalle.TabStop = True
        Me.rbDetalle.Text = "Detalle"
        Me.rbDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnSalir.Location = New System.Drawing.Point(135, 228)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(79, 25)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnAceptar.Location = New System.Drawing.Point(50, 228)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 25)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        '
        'frmRepPlanillaOficial
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(297, 276)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepPlanillaOficial"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla Oficial de Sueldos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExportar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarPlanillaSueldo As System.Windows.Forms.Button
    Friend WithEvents txtIdPlanilla As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents gbExportar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbResumen As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDetalle As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbPeriodo As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPlanilla As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMesRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
