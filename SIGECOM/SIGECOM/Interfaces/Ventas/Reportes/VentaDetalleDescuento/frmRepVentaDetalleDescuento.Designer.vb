<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepVentaDetalleDescuento
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
        Dim cmbVendedor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepVentaDetalleDescuento))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTodoVendedor = New System.Windows.Forms.CheckBox()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.cmbVendedor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.rbBuscarCliente = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbMercaderia = New System.Windows.Forms.CheckBox()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.UiGroupBox7 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbExportExcel = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPantalla = New Janus.Windows.EditControls.UIRadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        CType(Me.cmbVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.UiGroupBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox7.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(268, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 16)
        Me.Label6.TabIndex = 87
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
        Me.cbFecFinal.Location = New System.Drawing.Point(307, 18)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 85
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
        Me.cbFecInicio.Location = New System.Drawing.Point(155, 18)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 84
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Fechas      Del : "
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(70, 53)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(138, 20)
        Me.cmbOficinas.TabIndex = 88
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Oficina:"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(229, 55)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(72, 16)
        Me.lblAlmacen.TabIndex = 91
        Me.lblAlmacen.Text = "Almacén:"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(307, 53)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(151, 20)
        Me.cmbIdLocacion.TabIndex = 89
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.Controls.Add(Me.rbTodoVendedor)
        Me.UiGroupBox5.Controls.Add(Me.lblVendedor)
        Me.UiGroupBox5.Controls.Add(Me.cmbVendedor)
        Me.UiGroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox5.Location = New System.Drawing.Point(7, 81)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(451, 68)
        Me.UiGroupBox5.TabIndex = 110
        Me.UiGroupBox5.Text = "Buscar Por Vendedor"
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTodoVendedor
        '
        Me.rbTodoVendedor.AutoSize = True
        Me.rbTodoVendedor.Checked = True
        Me.rbTodoVendedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbTodoVendedor.Location = New System.Drawing.Point(9, 19)
        Me.rbTodoVendedor.Name = "rbTodoVendedor"
        Me.rbTodoVendedor.Size = New System.Drawing.Size(113, 17)
        Me.rbTodoVendedor.TabIndex = 11
        Me.rbTodoVendedor.Text = "Todo Vendedor"
        Me.rbTodoVendedor.UseVisualStyleBackColor = True
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.Location = New System.Drawing.Point(3, 44)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(80, 16)
        Me.lblVendedor.TabIndex = 108
        Me.lblVendedor.Text = "Vendedor:"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbVendedor_DesignTimeLayout.LayoutString = resources.GetString("cmbVendedor_DesignTimeLayout.LayoutString")
        Me.cmbVendedor.DesignTimeLayout = cmbVendedor_DesignTimeLayout
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.Location = New System.Drawing.Point(91, 42)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.SelectedIndex = -1
        Me.cmbVendedor.SelectedItem = Nothing
        Me.cmbVendedor.SettingsKey = "cmbCodMot"
        Me.cmbVendedor.Size = New System.Drawing.Size(350, 20)
        Me.cmbVendedor.TabIndex = 9
        Me.cmbVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.Controls.Add(Me.txtCliente)
        Me.UiGroupBox6.Controls.Add(Me.rbBuscarCliente)
        Me.UiGroupBox6.Controls.Add(Me.Label12)
        Me.UiGroupBox6.Controls.Add(Me.btnBuscarCliente)
        Me.UiGroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox6.Location = New System.Drawing.Point(8, 167)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(450, 68)
        Me.UiGroupBox6.TabIndex = 111
        Me.UiGroupBox6.Text = "Buscar Cliente"
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(80, 42)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(341, 20)
        Me.txtCliente.TabIndex = 13
        '
        'rbBuscarCliente
        '
        Me.rbBuscarCliente.AutoSize = True
        Me.rbBuscarCliente.Checked = True
        Me.rbBuscarCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbBuscarCliente.Location = New System.Drawing.Point(9, 19)
        Me.rbBuscarCliente.Name = "rbBuscarCliente"
        Me.rbBuscarCliente.Size = New System.Drawing.Size(98, 17)
        Me.rbBuscarCliente.TabIndex = 11
        Me.rbBuscarCliente.Text = "Todo Cliente"
        Me.rbBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 16)
        Me.Label12.TabIndex = 90
        Me.Label12.Text = "Cliente:"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(421, 41)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 15
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.rbMercaderia)
        Me.UiGroupBox4.Controls.Add(Me.txtCodMer)
        Me.UiGroupBox4.Controls.Add(Me.btnBuscarMercaderia)
        Me.UiGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox4.Location = New System.Drawing.Point(46, 241)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(184, 68)
        Me.UiGroupBox4.TabIndex = 112
        Me.UiGroupBox4.Text = "Buscar Mercadería"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbMercaderia
        '
        Me.rbMercaderia.AutoSize = True
        Me.rbMercaderia.Checked = True
        Me.rbMercaderia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbMercaderia.Location = New System.Drawing.Point(13, 18)
        Me.rbMercaderia.Name = "rbMercaderia"
        Me.rbMercaderia.Size = New System.Drawing.Size(124, 17)
        Me.rbMercaderia.TabIndex = 17
        Me.rbMercaderia.Text = "Toda Mercadería"
        Me.rbMercaderia.UseVisualStyleBackColor = True
        '
        'txtCodMer
        '
        Me.txtCodMer.Location = New System.Drawing.Point(13, 41)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(132, 20)
        Me.txtCodMer.TabIndex = 19
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(145, 40)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderia.TabIndex = 21
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'UiGroupBox7
        '
        Me.UiGroupBox7.Controls.Add(Me.rbExportExcel)
        Me.UiGroupBox7.Controls.Add(Me.rbPantalla)
        Me.UiGroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox7.Location = New System.Drawing.Point(257, 242)
        Me.UiGroupBox7.Name = "UiGroupBox7"
        Me.UiGroupBox7.Size = New System.Drawing.Size(144, 67)
        Me.UiGroupBox7.TabIndex = 115
        Me.UiGroupBox7.Text = "Imprimir"
        Me.UiGroupBox7.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbExportExcel
        '
        Me.rbExportExcel.Location = New System.Drawing.Point(14, 37)
        Me.rbExportExcel.Name = "rbExportExcel"
        Me.rbExportExcel.Size = New System.Drawing.Size(116, 15)
        Me.rbExportExcel.TabIndex = 28
        Me.rbExportExcel.Text = "Exportar"
        Me.rbExportExcel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPantalla
        '
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(14, 14)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(90, 18)
        Me.rbPantalla.TabIndex = 29
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(152, 326)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(77, 25)
        Me.btnAceptar.TabIndex = 116
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(329, 326)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(32, 22)
        Me.DataGridView1.TabIndex = 118
        Me.DataGridView1.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(236, 326)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 25)
        Me.btnCancelar.TabIndex = 117
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepVentaDetalleDescuento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(464, 356)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.UiGroupBox7)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.UiGroupBox5)
        Me.Controls.Add(Me.cmbOficinas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblAlmacen)
        Me.Controls.Add(Me.cmbIdLocacion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbFecFinal)
        Me.Controls.Add(Me.cbFecInicio)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepVentaDetalleDescuento"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Venta Detallado  con Descuento"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.UiGroupBox5.PerformLayout()
        CType(Me.cmbVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.UiGroupBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox7.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTodoVendedor As System.Windows.Forms.CheckBox
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents cmbVendedor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents rbBuscarCliente As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbMercaderia As System.Windows.Forms.CheckBox
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox7 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbExportExcel As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPantalla As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
