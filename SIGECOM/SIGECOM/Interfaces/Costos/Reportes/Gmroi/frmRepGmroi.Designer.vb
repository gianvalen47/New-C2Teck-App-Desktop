<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepGmroi
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
        Dim cmbCodRub_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepGmroi))
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbExcel = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPantalla = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbFechas = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbResumenUnidad = New System.Windows.Forms.RadioButton()
        Me.rbResumenRubro = New System.Windows.Forms.RadioButton()
        Me.rbDetalladoxMercaderia = New System.Windows.Forms.RadioButton()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbFechas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFechas.SuspendLayout()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.DataGridView1)
        Me.UiGroupBox4.Controls.Add(Me.UiGroupBox1)
        Me.UiGroupBox4.Controls.Add(Me.gbFechas)
        Me.UiGroupBox4.Controls.Add(Me.cmbCodRub)
        Me.UiGroupBox4.Controls.Add(Me.cmbIdLocacion)
        Me.UiGroupBox4.Controls.Add(Me.Label7)
        Me.UiGroupBox4.Controls.Add(Me.lblAlmacen)
        Me.UiGroupBox4.Controls.Add(Me.cmbOficinas)
        Me.UiGroupBox4.Controls.Add(Me.Label4)
        Me.UiGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox4.Location = New System.Drawing.Point(8, 65)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(508, 190)
        Me.UiGroupBox4.TabIndex = 123
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(417, 113)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(70, 22)
        Me.DataGridView1.TabIndex = 119
        Me.DataGridView1.Visible = False
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbExcel)
        Me.UiGroupBox1.Controls.Add(Me.rbPantalla)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(133, 140)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(243, 39)
        Me.UiGroupBox1.TabIndex = 118
        Me.UiGroupBox1.Text = "Exportar"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbExcel
        '
        Me.rbExcel.Location = New System.Drawing.Point(141, 12)
        Me.rbExcel.Name = "rbExcel"
        Me.rbExcel.Size = New System.Drawing.Size(72, 23)
        Me.rbExcel.TabIndex = 5
        Me.rbExcel.Text = "Excel"
        '
        'rbPantalla
        '
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(38, 12)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(76, 23)
        Me.rbPantalla.TabIndex = 4
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        '
        'gbFechas
        '
        Me.gbFechas.Controls.Add(Me.cbFecInicio)
        Me.gbFechas.Controls.Add(Me.Label1)
        Me.gbFechas.Controls.Add(Me.Label6)
        Me.gbFechas.Controls.Add(Me.cbFecFinal)
        Me.gbFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFechas.Location = New System.Drawing.Point(17, 14)
        Me.gbFechas.Name = "gbFechas"
        Me.gbFechas.Size = New System.Drawing.Size(470, 52)
        Me.gbFechas.TabIndex = 117
        Me.gbFechas.Text = "Rango de Fechas"
        Me.gbFechas.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicio.Location = New System.Drawing.Point(130, 22)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = " Fechas Del : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(270, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Al :"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(302, 22)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 2
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodRub.Location = New System.Drawing.Point(74, 110)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(132, 20)
        Me.cmbCodRub.TabIndex = 115
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(304, 78)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(183, 20)
        Me.cmbIdLocacion.TabIndex = 4
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "Rubro:"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(239, 82)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(59, 13)
        Me.lblAlmacen.TabIndex = 107
        Me.lblAlmacen.Text = "Almacén:"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(74, 78)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(103, 20)
        Me.cmbOficinas.TabIndex = 3
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Oficina:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(258, 265)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 28)
        Me.btnCancelar.TabIndex = 125
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(173, 265)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 28)
        Me.btnAceptar.TabIndex = 124
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.rbResumenUnidad)
        Me.UiGroupBox2.Controls.Add(Me.rbResumenRubro)
        Me.UiGroupBox2.Controls.Add(Me.rbDetalladoxMercaderia)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 19)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(510, 40)
        Me.UiGroupBox2.TabIndex = 127
        Me.UiGroupBox2.Text = "Tipo"
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbResumenUnidad
        '
        Me.rbResumenUnidad.AutoSize = True
        Me.rbResumenUnidad.Location = New System.Drawing.Point(152, 15)
        Me.rbResumenUnidad.Name = "rbResumenUnidad"
        Me.rbResumenUnidad.Size = New System.Drawing.Size(182, 17)
        Me.rbResumenUnidad.TabIndex = 16
        Me.rbResumenUnidad.Text = "Resumen x Unidad Negocio"
        Me.rbResumenUnidad.UseVisualStyleBackColor = True
        '
        'rbResumenRubro
        '
        Me.rbResumenRubro.AutoSize = True
        Me.rbResumenRubro.Checked = True
        Me.rbResumenRubro.Location = New System.Drawing.Point(13, 15)
        Me.rbResumenRubro.Name = "rbResumenRubro"
        Me.rbResumenRubro.Size = New System.Drawing.Size(125, 17)
        Me.rbResumenRubro.TabIndex = 1
        Me.rbResumenRubro.TabStop = True
        Me.rbResumenRubro.Text = "Resumen x Rubro"
        Me.rbResumenRubro.UseVisualStyleBackColor = True
        '
        'rbDetalladoxMercaderia
        '
        Me.rbDetalladoxMercaderia.AutoSize = True
        Me.rbDetalladoxMercaderia.Location = New System.Drawing.Point(347, 15)
        Me.rbDetalladoxMercaderia.Name = "rbDetalladoxMercaderia"
        Me.rbDetalladoxMercaderia.Size = New System.Drawing.Size(156, 17)
        Me.rbDetalladoxMercaderia.TabIndex = 15
        Me.rbDetalladoxMercaderia.Text = "Detallado x Mercaderia"
        Me.rbDetalladoxMercaderia.UseVisualStyleBackColor = True
        '
        'frmRepGmroi
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(527, 301)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepGmroi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de GMROI"
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.gbFechas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFechas.ResumeLayout(False)
        Me.gbFechas.PerformLayout()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbFechas As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbExcel As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPantalla As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbResumenUnidad As System.Windows.Forms.RadioButton
    Friend WithEvents rbResumenRubro As System.Windows.Forms.RadioButton
    Friend WithEvents rbDetalladoxMercaderia As System.Windows.Forms.RadioButton
End Class
