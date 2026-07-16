<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCajaBancos
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
        Dim cmbBanco_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCuentaBanco_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCajaBancos))
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCuentaBanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbPaginacion = New Janus.Windows.EditControls.UICheckBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.cmbBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCuentaBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnCancelar.Location = New System.Drawing.Point(251, 240)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnAceptar.Location = New System.Drawing.Point(167, 240)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 27)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "Aceptar"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox1.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(361, 54)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Rango de Fechas"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Location = New System.Drawing.Point(251, 21)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(93, 20)
        Me.cbFecFinal.TabIndex = 2
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Location = New System.Drawing.Point(97, 21)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(93, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(219, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Al :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fechas Del :"
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.Label5)
        Me.UiGroupBox4.Controls.Add(Me.cmbBanco)
        Me.UiGroupBox4.Controls.Add(Me.cmbCuentaBanco)
        Me.UiGroupBox4.Controls.Add(Me.Label4)
        Me.UiGroupBox4.Location = New System.Drawing.Point(12, 159)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(320, 70)
        Me.UiGroupBox4.TabIndex = 9
        Me.UiGroupBox4.Text = "Datos de Búsqueda"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Banco"
        '
        'cmbBanco
        '
        Me.cmbBanco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbBanco_DesignTimeLayout.LayoutString = resources.GetString("cmbBanco_DesignTimeLayout.LayoutString")
        Me.cmbBanco.DesignTimeLayout = cmbBanco_DesignTimeLayout
        Me.cmbBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBanco.Location = New System.Drawing.Point(85, 17)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.SelectedIndex = -1
        Me.cmbBanco.SelectedItem = Nothing
        Me.cmbBanco.Size = New System.Drawing.Size(195, 19)
        Me.cmbBanco.TabIndex = 10
        Me.cmbBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCuentaBanco
        '
        Me.cmbCuentaBanco.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCuentaBanco_DesignTimeLayout.LayoutString = resources.GetString("cmbCuentaBanco_DesignTimeLayout.LayoutString")
        Me.cmbCuentaBanco.DesignTimeLayout = cmbCuentaBanco_DesignTimeLayout
        Me.cmbCuentaBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCuentaBanco.Location = New System.Drawing.Point(113, 42)
        Me.cmbCuentaBanco.Name = "cmbCuentaBanco"
        Me.cmbCuentaBanco.SelectedIndex = -1
        Me.cmbCuentaBanco.SelectedItem = Nothing
        Me.cmbCuentaBanco.Size = New System.Drawing.Size(167, 20)
        Me.cmbCuentaBanco.TabIndex = 11
        Me.cmbCuentaBanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Cuenta Banco"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(19, 21)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(57, 20)
        Me.cmbMoneda.TabIndex = 4
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.cbPaginacion)
        Me.UiGroupBox3.Location = New System.Drawing.Point(348, 159)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(134, 70)
        Me.UiGroupBox3.TabIndex = 12
        Me.UiGroupBox3.Text = "Paginación"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbPaginacion
        '
        Me.cbPaginacion.Checked = True
        Me.cbPaginacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPaginacion.Location = New System.Drawing.Point(12, 27)
        Me.cbPaginacion.Name = "cbPaginacion"
        Me.cbPaginacion.Size = New System.Drawing.Size(112, 23)
        Me.cbPaginacion.TabIndex = 13
        Me.cbPaginacion.Text = "Con Paginación"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox2.Location = New System.Drawing.Point(388, 12)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(94, 54)
        Me.UiGroupBox2.TabIndex = 3
        Me.UiGroupBox2.Text = "Moneda"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.Controls.Add(Me.Label3)
        Me.UiGroupBox5.Controls.Add(Me.Label26)
        Me.UiGroupBox5.Controls.Add(Me.Label6)
        Me.UiGroupBox5.Controls.Add(Me.cmbCentroCosto)
        Me.UiGroupBox5.Controls.Add(Me.cmbArea)
        Me.UiGroupBox5.Controls.Add(Me.cmbUnidad)
        Me.UiGroupBox5.Location = New System.Drawing.Point(12, 75)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(470, 75)
        Me.UiGroupBox5.TabIndex = 5
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(269, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 255
        Me.Label3.Text = "Area"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(10, 49)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 13)
        Me.Label26.TabIndex = 203
        Me.Label26.Text = "Centro de Costo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 13)
        Me.Label6.TabIndex = 254
        Me.Label6.Text = "Unidad de Negocio"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(128, 45)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(171, 20)
        Me.cmbCentroCosto.TabIndex = 8
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Location = New System.Drawing.Point(304, 18)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(156, 20)
        Me.cmbArea.TabIndex = 7
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(128, 18)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(120, 20)
        Me.cmbUnidad.TabIndex = 6
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmRepCajaBancos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(491, 275)
        Me.Controls.Add(Me.UiGroupBox5)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepCajaBancos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Caja y Bancos"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.cmbBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCuentaBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.UiGroupBox5.PerformLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbPaginacion As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cmbCuentaBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbBanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
