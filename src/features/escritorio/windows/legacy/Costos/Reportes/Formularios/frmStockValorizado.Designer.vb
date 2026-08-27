<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockValorizado
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
        Me.components = New System.ComponentModel.Container
        Dim cbAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbOficina_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockValorizado))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gpAlmacenes = New Janus.Windows.EditControls.UIGroupBox
        Me.cbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbFecha = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.rbStockActual = New Janus.Windows.EditControls.UIRadioButton
        Me.rbSaldoInicio = New Janus.Windows.EditControls.UIRadioButton
        Me.rbStockFecha = New Janus.Windows.EditControls.UIRadioButton
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox
        Me.rbCeros = New Janus.Windows.EditControls.UIRadioButton
        Me.rbNegativos = New Janus.Windows.EditControls.UIRadioButton
        Me.rbPositivos = New Janus.Windows.EditControls.UIRadioButton
        Me.rbSinCeros = New Janus.Windows.EditControls.UIRadioButton
        Me.rbTodos = New Janus.Windows.EditControls.UIRadioButton
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox
        Me.rbTotalGeneral = New Janus.Windows.EditControls.UIRadioButton
        Me.rbDetalle = New Janus.Windows.EditControls.UIRadioButton
        Me.ckLibro = New Janus.Windows.EditControls.UICheckBox
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpAlmacenes.SuspendLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gpAlmacenes
        '
        Me.gpAlmacenes.Controls.Add(Me.cbAlmacen)
        Me.gpAlmacenes.Controls.Add(Me.cbOficina)
        Me.gpAlmacenes.Controls.Add(Me.Label2)
        Me.gpAlmacenes.Controls.Add(Me.Label1)
        Me.gpAlmacenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpAlmacenes.Location = New System.Drawing.Point(141, 6)
        Me.gpAlmacenes.Name = "gpAlmacenes"
        Me.gpAlmacenes.Size = New System.Drawing.Size(321, 62)
        Me.gpAlmacenes.TabIndex = 5
        Me.gpAlmacenes.Text = "Almacenes"
        Me.gpAlmacenes.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbAlmacen
        '
        Me.cbAlmacen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbAlmacen_DesignTimeLayout.LayoutString = resources.GetString("cbAlmacen_DesignTimeLayout.LayoutString")
        Me.cbAlmacen.DesignTimeLayout = cbAlmacen_DesignTimeLayout
        Me.cbAlmacen.Location = New System.Drawing.Point(67, 37)
        Me.cbAlmacen.Name = "cbAlmacen"
        Me.cbAlmacen.SelectedIndex = -1
        Me.cbAlmacen.SelectedItem = Nothing
        Me.cbAlmacen.Size = New System.Drawing.Size(248, 20)
        Me.cbAlmacen.TabIndex = 3
        Me.cbAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbOficina
        '
        Me.cbOficina.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbOficina_DesignTimeLayout.LayoutString = resources.GetString("cbOficina_DesignTimeLayout.LayoutString")
        Me.cbOficina.DesignTimeLayout = cbOficina_DesignTimeLayout
        Me.cbOficina.Location = New System.Drawing.Point(67, 15)
        Me.cbOficina.Name = "cbOficina"
        Me.cbOficina.SelectedIndex = -1
        Me.cbOficina.SelectedItem = Nothing
        Me.cbOficina.Size = New System.Drawing.Size(161, 20)
        Me.cbOficina.TabIndex = 2
        Me.cbOficina.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Almacen :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Oficina :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "A la Fecha :"
        '
        'cbFecha
        '
        '
        '
        '
        Me.cbFecha.DropDownCalendar.Name = ""
        Me.cbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecha.Location = New System.Drawing.Point(84, 11)
        Me.cbFecha.Name = "cbFecha"
        Me.cbFecha.Size = New System.Drawing.Size(93, 20)
        Me.cbFecha.TabIndex = 7
        Me.cbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbStockActual)
        Me.UiGroupBox1.Controls.Add(Me.rbSaldoInicio)
        Me.UiGroupBox1.Controls.Add(Me.rbStockFecha)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(131, 98)
        Me.UiGroupBox1.TabIndex = 8
        Me.UiGroupBox1.Text = "Opciones"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbStockActual
        '
        Me.rbStockActual.Location = New System.Drawing.Point(7, 59)
        Me.rbStockActual.Name = "rbStockActual"
        Me.rbStockActual.Size = New System.Drawing.Size(111, 16)
        Me.rbStockActual.TabIndex = 2
        Me.rbStockActual.Text = "Stock Actual"
        Me.rbStockActual.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbSaldoInicio
        '
        Me.rbSaldoInicio.Location = New System.Drawing.Point(7, 39)
        Me.rbSaldoInicio.Name = "rbSaldoInicio"
        Me.rbSaldoInicio.Size = New System.Drawing.Size(118, 14)
        Me.rbSaldoInicio.TabIndex = 1
        Me.rbSaldoInicio.Text = "Saldos de Inicio"
        Me.rbSaldoInicio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbStockFecha
        '
        Me.rbStockFecha.Checked = True
        Me.rbStockFecha.Location = New System.Drawing.Point(7, 18)
        Me.rbStockFecha.Name = "rbStockFecha"
        Me.rbStockFecha.Size = New System.Drawing.Size(123, 14)
        Me.rbStockFecha.TabIndex = 0
        Me.rbStockFecha.TabStop = True
        Me.rbStockFecha.Text = "Stock a la Fecha"
        Me.rbStockFecha.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.rbCeros)
        Me.UiGroupBox3.Controls.Add(Me.rbNegativos)
        Me.UiGroupBox3.Controls.Add(Me.rbPositivos)
        Me.UiGroupBox3.Controls.Add(Me.rbSinCeros)
        Me.UiGroupBox3.Controls.Add(Me.rbTodos)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(335, 70)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(127, 114)
        Me.UiGroupBox3.TabIndex = 9
        Me.UiGroupBox3.Text = "Tipo Stock"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbCeros
        '
        Me.rbCeros.Location = New System.Drawing.Point(9, 93)
        Me.rbCeros.Name = "rbCeros"
        Me.rbCeros.Size = New System.Drawing.Size(107, 16)
        Me.rbCeros.TabIndex = 4
        Me.rbCeros.Text = "Con Ceros"
        Me.rbCeros.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbNegativos
        '
        Me.rbNegativos.Location = New System.Drawing.Point(9, 73)
        Me.rbNegativos.Name = "rbNegativos"
        Me.rbNegativos.Size = New System.Drawing.Size(109, 15)
        Me.rbNegativos.TabIndex = 3
        Me.rbNegativos.Text = "Negativos"
        Me.rbNegativos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPositivos
        '
        Me.rbPositivos.Location = New System.Drawing.Point(9, 53)
        Me.rbPositivos.Name = "rbPositivos"
        Me.rbPositivos.Size = New System.Drawing.Size(98, 15)
        Me.rbPositivos.TabIndex = 2
        Me.rbPositivos.Text = "Positivos"
        Me.rbPositivos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbSinCeros
        '
        Me.rbSinCeros.Location = New System.Drawing.Point(9, 35)
        Me.rbSinCeros.Name = "rbSinCeros"
        Me.rbSinCeros.Size = New System.Drawing.Size(111, 14)
        Me.rbSinCeros.TabIndex = 1
        Me.rbSinCeros.Text = "Todos sin Ceros"
        Me.rbSinCeros.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbTodos
        '
        Me.rbTodos.Checked = True
        Me.rbTodos.Location = New System.Drawing.Point(9, 16)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(103, 14)
        Me.rbTodos.TabIndex = 0
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(276, 193)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(87, 27)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(379, 193)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(84, 27)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.cbFecha)
        Me.UiGroupBox4.Controls.Add(Me.Label3)
        Me.UiGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox4.Location = New System.Drawing.Point(141, 68)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(182, 35)
        Me.UiGroupBox4.TabIndex = 12
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.Controls.Add(Me.rbTotalGeneral)
        Me.UiGroupBox5.Controls.Add(Me.rbDetalle)
        Me.UiGroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox5.Location = New System.Drawing.Point(5, 108)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(131, 77)
        Me.UiGroupBox5.TabIndex = 13
        Me.UiGroupBox5.Text = "Tipo Reporte"
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTotalGeneral
        '
        Me.rbTotalGeneral.Location = New System.Drawing.Point(9, 47)
        Me.rbTotalGeneral.Name = "rbTotalGeneral"
        Me.rbTotalGeneral.Size = New System.Drawing.Size(105, 16)
        Me.rbTotalGeneral.TabIndex = 2
        Me.rbTotalGeneral.Text = "Total General"
        Me.rbTotalGeneral.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbDetalle
        '
        Me.rbDetalle.Checked = True
        Me.rbDetalle.Location = New System.Drawing.Point(9, 24)
        Me.rbDetalle.Name = "rbDetalle"
        Me.rbDetalle.Size = New System.Drawing.Size(71, 14)
        Me.rbDetalle.TabIndex = 0
        Me.rbDetalle.TabStop = True
        Me.rbDetalle.Text = "Detalle"
        Me.rbDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckLibro
        '
        Me.ckLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckLibro.Location = New System.Drawing.Point(156, 142)
        Me.ckLibro.Name = "ckLibro"
        Me.ckLibro.Size = New System.Drawing.Size(152, 18)
        Me.ckLibro.TabIndex = 15
        Me.ckLibro.Text = "Impresion para el Libro"
        Me.ckLibro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'frmStockValorizado
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(477, 228)
        Me.Controls.Add(Me.ckLibro)
        Me.Controls.Add(Me.UiGroupBox5)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gpAlmacenes)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStockValorizado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Valorizado"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpAlmacenes.ResumeLayout(False)
        Me.gpAlmacenes.PerformLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gpAlmacenes As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbStockActual As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbSaldoInicio As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbStockFecha As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents cbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbCeros As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbNegativos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPositivos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbSinCeros As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbTodos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTotalGeneral As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDetalle As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents ckLibro As Janus.Windows.EditControls.UICheckBox
End Class
