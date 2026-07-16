<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRepReembolsoxGasto
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepReembolsoxGasto))
        Dim cmbPlaca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUbicacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoGasto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTotalizado = New System.Windows.Forms.RadioButton()
        Me.rbDetallado = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumReembolso = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cmbPlaca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbRangoFechas = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbUbicacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbTipoGasto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbRangoFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRangoFechas.SuspendLayout()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(276, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Al  :"
        '
        'txtFecFinal
        '
        '
        '
        '
        Me.txtFecFinal.DropDownCalendar.Name = ""
        Me.txtFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinal.Location = New System.Drawing.Point(312, 19)
        Me.txtFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFecFinal.Name = "txtFecFinal"
        Me.txtFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.txtFecFinal.TabIndex = 2
        Me.txtFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecInicio
        '
        '
        '
        '
        Me.txtFecInicio.DropDownCalendar.Name = ""
        Me.txtFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecInicio.Location = New System.Drawing.Point(125, 19)
        Me.txtFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.txtFecInicio.TabIndex = 1
        Me.txtFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Fecha del  : "
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.UiGroupBox3)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.cmbUnidad)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtNumReembolso)
        Me.UiGroupBox1.Controls.Add(Me.btnAceptar)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox1.Controls.Add(Me.cmbPlaca)
        Me.UiGroupBox1.Controls.Add(Me.cmbArea)
        Me.UiGroupBox1.Controls.Add(Me.gbRangoFechas)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.cmbUbicacion)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipoGasto)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 7)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(476, 239)
        Me.UiGroupBox1.TabIndex = 96
        Me.UiGroupBox1.Text = "Datos de Reporte"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.UseDefault
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.rbTotalizado)
        Me.UiGroupBox3.Controls.Add(Me.rbDetallado)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(138, 12)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(199, 40)
        Me.UiGroupBox3.TabIndex = 112
        Me.UiGroupBox3.Text = "Tipo"
        Me.UiGroupBox3.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTotalizado
        '
        Me.rbTotalizado.AutoSize = True
        Me.rbTotalizado.Location = New System.Drawing.Point(104, 15)
        Me.rbTotalizado.Name = "rbTotalizado"
        Me.rbTotalizado.Size = New System.Drawing.Size(84, 17)
        Me.rbTotalizado.TabIndex = 1
        Me.rbTotalizado.Text = "Totalizado"
        Me.rbTotalizado.UseVisualStyleBackColor = True
        '
        'rbDetallado
        '
        Me.rbDetallado.AutoSize = True
        Me.rbDetallado.Checked = True
        Me.rbDetallado.Location = New System.Drawing.Point(14, 15)
        Me.rbDetallado.Name = "rbDetallado"
        Me.rbDetallado.Size = New System.Drawing.Size(79, 17)
        Me.rbDetallado.TabIndex = 15
        Me.rbDetallado.TabStop = True
        Me.rbDetallado.Text = "Detallado"
        Me.rbDetallado.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 259
        Me.Label5.Text = "Unidad de Negocio"
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(135, 146)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(120, 20)
        Me.cmbUnidad.TabIndex = 258
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(277, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 257
        Me.Label4.Text = "N° Reembolso :"
        '
        'txtNumReembolso
        '
        Me.txtNumReembolso.Location = New System.Drawing.Point(378, 175)
        Me.txtNumReembolso.Name = "txtNumReembolso"
        Me.txtNumReembolso.Size = New System.Drawing.Size(86, 20)
        Me.txtNumReembolso.TabIndex = 7
        Me.txtNumReembolso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(153, 201)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 28)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(272, 150)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 252
        Me.Label11.Text = "Area :"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(244, 201)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 28)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cmbPlaca
        '
        Me.cmbPlaca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPlaca_DesignTimeLayout.LayoutString = resources.GetString("cmbPlaca_DesignTimeLayout.LayoutString")
        Me.cmbPlaca.DesignTimeLayout = cmbPlaca_DesignTimeLayout
        Me.cmbPlaca.Location = New System.Drawing.Point(370, 118)
        Me.cmbPlaca.Name = "cmbPlaca"
        Me.cmbPlaca.SelectedIndex = -1
        Me.cmbPlaca.SelectedItem = Nothing
        Me.cmbPlaca.Size = New System.Drawing.Size(95, 20)
        Me.cmbPlaca.TabIndex = 4
        Me.cmbPlaca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(319, 146)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(146, 20)
        Me.cmbArea.TabIndex = 6
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbRangoFechas
        '
        Me.gbRangoFechas.Controls.Add(Me.Label6)
        Me.gbRangoFechas.Controls.Add(Me.txtFecFinal)
        Me.gbRangoFechas.Controls.Add(Me.txtFecInicio)
        Me.gbRangoFechas.Controls.Add(Me.Label1)
        Me.gbRangoFechas.Location = New System.Drawing.Point(12, 57)
        Me.gbRangoFechas.Name = "gbRangoFechas"
        Me.gbRangoFechas.Size = New System.Drawing.Size(453, 47)
        Me.gbRangoFechas.TabIndex = 0
        Me.gbRangoFechas.Text = "Rango de Fechas"
        Me.gbRangoFechas.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Ubicación Caja :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(317, 122)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 13)
        Me.Label15.TabIndex = 255
        Me.Label15.Text = "Placa :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 250
        Me.Label3.Text = "Tipo de Gasto :"
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUbicacion_DesignTimeLayout.LayoutString = resources.GetString("cmbUbicacion_DesignTimeLayout.LayoutString")
        Me.cmbUbicacion.DesignTimeLayout = cmbUbicacion_DesignTimeLayout
        Me.cmbUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacion.Location = New System.Drawing.Point(121, 174)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.SelectedIndex = -1
        Me.cmbUbicacion.SelectedItem = Nothing
        Me.cmbUbicacion.Size = New System.Drawing.Size(134, 20)
        Me.cmbUbicacion.TabIndex = 5
        Me.cmbUbicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbTipoGasto
        '
        Me.cmbTipoGasto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoGasto_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoGasto_DesignTimeLayout.LayoutString")
        Me.cmbTipoGasto.DesignTimeLayout = cmbTipoGasto_DesignTimeLayout
        Me.cmbTipoGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoGasto.Location = New System.Drawing.Point(116, 118)
        Me.cmbTipoGasto.Name = "cmbTipoGasto"
        Me.cmbTipoGasto.SelectedIndex = -1
        Me.cmbTipoGasto.SelectedItem = Nothing
        Me.cmbTipoGasto.Size = New System.Drawing.Size(186, 20)
        Me.cmbTipoGasto.TabIndex = 3
        Me.cmbTipoGasto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmRepReembolsoxGasto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(493, 253)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepReembolsoxGasto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Reembolso x Tipo de Gasto"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbRangoFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRangoFechas.ResumeLayout(False)
        Me.gbRangoFechas.PerformLayout()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoGasto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbUbicacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoGasto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbRangoFechas As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbPlaca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumReembolso As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTotalizado As System.Windows.Forms.RadioButton
    Friend WithEvents rbDetallado As System.Windows.Forms.RadioButton
End Class
