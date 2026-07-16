<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepRequisiciones
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
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodRub_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepRequisiciones))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.rbtnDetalle = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbtnResumen = New System.Windows.Forms.RadioButton()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gpAlmacenes = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbRubro = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbExportar = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbExportar = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPantalla = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbTipoReporte = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpAlmacenes.SuspendLayout()
        CType(Me.gbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRubro.SuspendLayout()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExportar.SuspendLayout()
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoReporte.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'rbtnDetalle
        '
        Me.rbtnDetalle.AutoSize = True
        Me.rbtnDetalle.Location = New System.Drawing.Point(30, 43)
        Me.rbtnDetalle.Name = "rbtnDetalle"
        Me.rbtnDetalle.Size = New System.Drawing.Size(65, 17)
        Me.rbtnDetalle.TabIndex = 10
        Me.rbtnDetalle.Text = "Detalle"
        Me.rbtnDetalle.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Oficina"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(209, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Almacén"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(149, 225)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(82, 29)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(237, 225)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(82, 29)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Location = New System.Drawing.Point(67, 74)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(125, 20)
        Me.cmbOficinas.TabIndex = 3
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Location = New System.Drawing.Point(270, 74)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(159, 20)
        Me.cmbIdLocacion.TabIndex = 4
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(225, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 15)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Al"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.HourIncrement = 3
        Me.cbFecFinal.Location = New System.Drawing.Point(250, 19)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
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
        Me.cbFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicio.HourIncrement = 2
        Me.cbFecInicio.Location = New System.Drawing.Point(105, 19)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(54, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = " Del : "
        '
        'rbtnResumen
        '
        Me.rbtnResumen.AutoSize = True
        Me.rbtnResumen.Checked = True
        Me.rbtnResumen.Location = New System.Drawing.Point(30, 19)
        Me.rbtnResumen.Name = "rbtnResumen"
        Me.rbtnResumen.Size = New System.Drawing.Size(77, 17)
        Me.rbtnResumen.TabIndex = 9
        Me.rbtnResumen.TabStop = True
        Me.rbtnResumen.Text = "Resumen"
        Me.rbtnResumen.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(67, 103)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(117, 20)
        Me.cmbEstado.TabIndex = 5
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Estado"
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Location = New System.Drawing.Point(270, 103)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(132, 20)
        Me.cmbCodRub.TabIndex = 6
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(223, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Rubro"
        '
        'gpAlmacenes
        '
        Me.gpAlmacenes.Controls.Add(Me.gbRubro)
        Me.gpAlmacenes.Controls.Add(Me.gbExportar)
        Me.gpAlmacenes.Controls.Add(Me.gbTipoReporte)
        Me.gpAlmacenes.Controls.Add(Me.cmbCodRub)
        Me.gpAlmacenes.Controls.Add(Me.Label5)
        Me.gpAlmacenes.Controls.Add(Me.Label1)
        Me.gpAlmacenes.Controls.Add(Me.cmbEstado)
        Me.gpAlmacenes.Controls.Add(Me.Label2)
        Me.gpAlmacenes.Controls.Add(Me.Label4)
        Me.gpAlmacenes.Controls.Add(Me.cmbOficinas)
        Me.gpAlmacenes.Controls.Add(Me.cmbIdLocacion)
        Me.gpAlmacenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpAlmacenes.Location = New System.Drawing.Point(9, 6)
        Me.gpAlmacenes.Name = "gpAlmacenes"
        Me.gpAlmacenes.Size = New System.Drawing.Size(450, 214)
        Me.gpAlmacenes.TabIndex = 0
        Me.gpAlmacenes.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbRubro
        '
        Me.gbRubro.Controls.Add(Me.cbFecFinal)
        Me.gbRubro.Controls.Add(Me.Label3)
        Me.gbRubro.Controls.Add(Me.Label6)
        Me.gbRubro.Controls.Add(Me.cbFecInicio)
        Me.gbRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRubro.Location = New System.Drawing.Point(23, 16)
        Me.gbRubro.Name = "gbRubro"
        Me.gbRubro.Size = New System.Drawing.Size(404, 48)
        Me.gbRubro.TabIndex = 103
        Me.gbRubro.Text = "Rango de fechas"
        Me.gbRubro.TextOffset = 1
        Me.gbRubro.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbExportar
        '
        Me.gbExportar.Controls.Add(Me.rbExportar)
        Me.gbExportar.Controls.Add(Me.rbPantalla)
        Me.gbExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbExportar.Location = New System.Drawing.Point(240, 133)
        Me.gbExportar.Name = "gbExportar"
        Me.gbExportar.Size = New System.Drawing.Size(131, 70)
        Me.gbExportar.TabIndex = 11
        Me.gbExportar.Text = "Exportar"
        Me.gbExportar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbExportar
        '
        Me.rbExportar.Location = New System.Drawing.Point(25, 44)
        Me.rbExportar.Name = "rbExportar"
        Me.rbExportar.Size = New System.Drawing.Size(105, 16)
        Me.rbExportar.TabIndex = 13
        Me.rbExportar.Text = "Exportar"
        Me.rbExportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPantalla
        '
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(25, 20)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(71, 14)
        Me.rbPantalla.TabIndex = 12
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbTipoReporte
        '
        Me.gbTipoReporte.Controls.Add(Me.rbtnResumen)
        Me.gbTipoReporte.Controls.Add(Me.rbtnDetalle)
        Me.gbTipoReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoReporte.Location = New System.Drawing.Point(83, 133)
        Me.gbTipoReporte.Name = "gbTipoReporte"
        Me.gbTipoReporte.Size = New System.Drawing.Size(131, 70)
        Me.gbTipoReporte.TabIndex = 8
        Me.gbTipoReporte.Text = "Tipo Reporte"
        Me.gbTipoReporte.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmRepRequisiciones
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(475, 265)
        Me.Controls.Add(Me.gpAlmacenes)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepRequisiciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vales de Requisiciones"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpAlmacenes.ResumeLayout(False)
        Me.gpAlmacenes.PerformLayout()
        CType(Me.gbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRubro.ResumeLayout(False)
        Me.gbRubro.PerformLayout()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExportar.ResumeLayout(False)
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoReporte.ResumeLayout(False)
        Me.gbTipoReporte.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbtnDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbtnResumen As System.Windows.Forms.RadioButton
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gpAlmacenes As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbTipoReporte As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbExportar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbExportar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPantalla As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbRubro As Janus.Windows.EditControls.UIGroupBox
End Class
