<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepVentaDetalle
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
        Dim cmbCodRub_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepVentaDetalle))
        Dim cmbVendedor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocCli_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.UiGroupBox7 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbExportar = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbExpDetallado = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbExpResumido = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbExportExcel = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPantalla = New Janus.Windows.EditControls.UIRadioButton()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTodoVendedor = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbVendedor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbIdLocCli = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblLocCliente = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.rbBuscarCliente = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbMercaderia = New System.Windows.Forms.CheckBox()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbReporteAgrupado = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbOrdenMerca = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbPorCliente = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPorFechaMerca = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbOrdenCliente = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbPorMercaderia = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPorFechaCliente = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbMerca = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbCliente = New Janus.Windows.EditControls.UIRadioButton()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbExportaciones = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbFacturadosSinEx = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbFacturacion = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbTodos = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbTipoReporte = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbDetalladoUnit = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbResumen = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbDetallado = New Janus.Windows.EditControls.UIRadioButton()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox7.SuspendLayout()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExportar.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        CType(Me.cmbVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.cmbIdLocCli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbReporteAgrupado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReporteAgrupado.SuspendLayout()
        CType(Me.gbOrdenMerca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenMerca.SuspendLayout()
        CType(Me.gbOrdenCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenCliente.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoReporte.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.cmbCodRub)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox7)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox5)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox6)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox4)
        Me.GroupBox1.Controls.Add(Me.cmbOficinas)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblAlmacen)
        Me.GroupBox1.Controls.Add(Me.cmbIdLocacion)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbFecFinal)
        Me.GroupBox1.Controls.Add(Me.cbFecInicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.gbReporteAgrupado)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.GroupBox1.Controls.Add(Me.gbTipoReporte)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(518, 528)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(217, 459)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(21, 18)
        Me.DataGridView1.TabIndex = 110
        Me.DataGridView1.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(278, 472)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(73, 25)
        Me.btnAceptar.TabIndex = 29
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Location = New System.Drawing.Point(100, 71)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(138, 20)
        Me.cmbCodRub.TabIndex = 8
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "Rubro:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(369, 472)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 31
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'UiGroupBox7
        '
        Me.UiGroupBox7.Controls.Add(Me.gbExportar)
        Me.UiGroupBox7.Controls.Add(Me.rbExportExcel)
        Me.UiGroupBox7.Controls.Add(Me.rbPantalla)
        Me.UiGroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox7.Location = New System.Drawing.Point(12, 446)
        Me.UiGroupBox7.Name = "UiGroupBox7"
        Me.UiGroupBox7.Size = New System.Drawing.Size(198, 77)
        Me.UiGroupBox7.TabIndex = 111
        Me.UiGroupBox7.Text = "Exportar"
        Me.UiGroupBox7.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbExportar
        '
        Me.gbExportar.Controls.Add(Me.rbExpDetallado)
        Me.gbExportar.Controls.Add(Me.rbExpResumido)
        Me.gbExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbExportar.Location = New System.Drawing.Point(87, 22)
        Me.gbExportar.Name = "gbExportar"
        Me.gbExportar.Size = New System.Drawing.Size(100, 49)
        Me.gbExportar.TabIndex = 113
        Me.gbExportar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbExpDetallado
        '
        Me.rbExpDetallado.Checked = True
        Me.rbExpDetallado.Location = New System.Drawing.Point(9, 8)
        Me.rbExpDetallado.Name = "rbExpDetallado"
        Me.rbExpDetallado.Size = New System.Drawing.Size(85, 20)
        Me.rbExpDetallado.TabIndex = 1
        Me.rbExpDetallado.TabStop = True
        Me.rbExpDetallado.Text = "Detallado"
        Me.rbExpDetallado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbExpResumido
        '
        Me.rbExpResumido.Location = New System.Drawing.Point(9, 27)
        Me.rbExpResumido.Name = "rbExpResumido"
        Me.rbExpResumido.Size = New System.Drawing.Size(90, 18)
        Me.rbExpResumido.TabIndex = 27
        Me.rbExpResumido.Text = "Resumido"
        Me.rbExpResumido.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbExportExcel
        '
        Me.rbExportExcel.Location = New System.Drawing.Point(13, 33)
        Me.rbExportExcel.Name = "rbExportExcel"
        Me.rbExportExcel.Size = New System.Drawing.Size(76, 18)
        Me.rbExportExcel.TabIndex = 28
        Me.rbExportExcel.Text = "Exportar"
        Me.rbExportExcel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPantalla
        '
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(12, 13)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(90, 18)
        Me.rbPantalla.TabIndex = 29
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.Controls.Add(Me.rbTodoVendedor)
        Me.UiGroupBox5.Controls.Add(Me.Label4)
        Me.UiGroupBox5.Controls.Add(Me.cmbVendedor)
        Me.UiGroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox5.Location = New System.Drawing.Point(12, 99)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(493, 63)
        Me.UiGroupBox5.TabIndex = 109
        Me.UiGroupBox5.Text = "Buscar Por Vendedor"
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTodoVendedor
        '
        Me.rbTodoVendedor.AutoSize = True
        Me.rbTodoVendedor.Checked = True
        Me.rbTodoVendedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbTodoVendedor.Location = New System.Drawing.Point(9, 15)
        Me.rbTodoVendedor.Name = "rbTodoVendedor"
        Me.rbTodoVendedor.Size = New System.Drawing.Size(113, 17)
        Me.rbTodoVendedor.TabIndex = 11
        Me.rbTodoVendedor.Text = "Todo Vendedor"
        Me.rbTodoVendedor.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Vendedor:"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbVendedor_DesignTimeLayout.LayoutString = resources.GetString("cmbVendedor_DesignTimeLayout.LayoutString")
        Me.cmbVendedor.DesignTimeLayout = cmbVendedor_DesignTimeLayout
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.Location = New System.Drawing.Point(91, 35)
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
        Me.UiGroupBox6.Controls.Add(Me.cmbIdLocCli)
        Me.UiGroupBox6.Controls.Add(Me.lblLocCliente)
        Me.UiGroupBox6.Controls.Add(Me.txtCliente)
        Me.UiGroupBox6.Controls.Add(Me.rbBuscarCliente)
        Me.UiGroupBox6.Controls.Add(Me.Label12)
        Me.UiGroupBox6.Controls.Add(Me.btnBuscarCliente)
        Me.UiGroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox6.Location = New System.Drawing.Point(12, 168)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(493, 85)
        Me.UiGroupBox6.TabIndex = 96
        Me.UiGroupBox6.Text = "Buscar Cliente"
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbIdLocCli
        '
        Me.cmbIdLocCli.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocCli_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocCli_DesignTimeLayout.LayoutString")
        Me.cmbIdLocCli.DesignTimeLayout = cmbIdLocCli_DesignTimeLayout
        Me.cmbIdLocCli.Enabled = False
        Me.cmbIdLocCli.Location = New System.Drawing.Point(156, 57)
        Me.cmbIdLocCli.Name = "cmbIdLocCli"
        Me.cmbIdLocCli.SelectedIndex = -1
        Me.cmbIdLocCli.SelectedItem = Nothing
        Me.cmbIdLocCli.Size = New System.Drawing.Size(190, 20)
        Me.cmbIdLocCli.TabIndex = 92
        Me.cmbIdLocCli.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblLocCliente
        '
        Me.lblLocCliente.AutoSize = True
        Me.lblLocCliente.Enabled = False
        Me.lblLocCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocCliente.Location = New System.Drawing.Point(52, 61)
        Me.lblLocCliente.Name = "lblLocCliente"
        Me.lblLocCliente.Size = New System.Drawing.Size(102, 13)
        Me.lblLocCliente.TabIndex = 91
        Me.lblLocCliente.Text = "Locación Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(80, 31)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(382, 20)
        Me.txtCliente.TabIndex = 13
        '
        'rbBuscarCliente
        '
        Me.rbBuscarCliente.AutoSize = True
        Me.rbBuscarCliente.Checked = True
        Me.rbBuscarCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbBuscarCliente.Location = New System.Drawing.Point(9, 13)
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
        Me.Label12.Location = New System.Drawing.Point(10, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 16)
        Me.Label12.TabIndex = 90
        Me.Label12.Text = "Cliente:"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(462, 30)
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
        Me.UiGroupBox4.Location = New System.Drawing.Point(12, 260)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(184, 68)
        Me.UiGroupBox4.TabIndex = 91
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
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(100, 48)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(138, 20)
        Me.cmbOficinas.TabIndex = 5
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Oficina:"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(286, 50)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(72, 16)
        Me.lblAlmacen.TabIndex = 85
        Me.lblAlmacen.Text = "Almacén:"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(369, 48)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(136, 20)
        Me.cmbIdLocacion.TabIndex = 7
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(265, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 16)
        Me.Label6.TabIndex = 83
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
        Me.cbFecFinal.Location = New System.Drawing.Point(304, 15)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 3
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
        Me.cbFecInicio.Location = New System.Drawing.Point(152, 15)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 16)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Fechas      Del : "
        '
        'gbReporteAgrupado
        '
        Me.gbReporteAgrupado.Controls.Add(Me.gbOrdenMerca)
        Me.gbReporteAgrupado.Controls.Add(Me.gbOrdenCliente)
        Me.gbReporteAgrupado.Controls.Add(Me.rbMerca)
        Me.gbReporteAgrupado.Controls.Add(Me.rbCliente)
        Me.gbReporteAgrupado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReporteAgrupado.Location = New System.Drawing.Point(223, 340)
        Me.gbReporteAgrupado.Name = "gbReporteAgrupado"
        Me.gbReporteAgrupado.Size = New System.Drawing.Size(276, 100)
        Me.gbReporteAgrupado.TabIndex = 79
        Me.gbReporteAgrupado.Text = "Reporte Agrupado"
        Me.gbReporteAgrupado.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbOrdenMerca
        '
        Me.gbOrdenMerca.Controls.Add(Me.rbPorCliente)
        Me.gbOrdenMerca.Controls.Add(Me.rbPorFechaMerca)
        Me.gbOrdenMerca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrdenMerca.Location = New System.Drawing.Point(96, 53)
        Me.gbOrdenMerca.Name = "gbOrdenMerca"
        Me.gbOrdenMerca.Size = New System.Drawing.Size(156, 36)
        Me.gbOrdenMerca.TabIndex = 114
        Me.gbOrdenMerca.Text = "Ordenar por :"
        Me.gbOrdenMerca.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbPorCliente
        '
        Me.rbPorCliente.Location = New System.Drawing.Point(79, 14)
        Me.rbPorCliente.Name = "rbPorCliente"
        Me.rbPorCliente.Size = New System.Drawing.Size(65, 18)
        Me.rbPorCliente.TabIndex = 114
        Me.rbPorCliente.Text = "Cliente"
        Me.rbPorCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPorFechaMerca
        '
        Me.rbPorFechaMerca.Checked = True
        Me.rbPorFechaMerca.Location = New System.Drawing.Point(10, 14)
        Me.rbPorFechaMerca.Name = "rbPorFechaMerca"
        Me.rbPorFechaMerca.Size = New System.Drawing.Size(90, 18)
        Me.rbPorFechaMerca.TabIndex = 27
        Me.rbPorFechaMerca.TabStop = True
        Me.rbPorFechaMerca.Text = "Fecha"
        Me.rbPorFechaMerca.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbOrdenCliente
        '
        Me.gbOrdenCliente.Controls.Add(Me.rbPorMercaderia)
        Me.gbOrdenCliente.Controls.Add(Me.rbPorFechaCliente)
        Me.gbOrdenCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrdenCliente.Location = New System.Drawing.Point(81, 14)
        Me.gbOrdenCliente.Name = "gbOrdenCliente"
        Me.gbOrdenCliente.Size = New System.Drawing.Size(171, 36)
        Me.gbOrdenCliente.TabIndex = 113
        Me.gbOrdenCliente.Text = "Ordenar por :"
        Me.gbOrdenCliente.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbPorMercaderia
        '
        Me.rbPorMercaderia.Location = New System.Drawing.Point(79, 15)
        Me.rbPorMercaderia.Name = "rbPorMercaderia"
        Me.rbPorMercaderia.Size = New System.Drawing.Size(88, 16)
        Me.rbPorMercaderia.TabIndex = 1
        Me.rbPorMercaderia.Text = "Mercaderia"
        Me.rbPorMercaderia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbPorFechaCliente
        '
        Me.rbPorFechaCliente.Checked = True
        Me.rbPorFechaCliente.Location = New System.Drawing.Point(10, 14)
        Me.rbPorFechaCliente.Name = "rbPorFechaCliente"
        Me.rbPorFechaCliente.Size = New System.Drawing.Size(90, 18)
        Me.rbPorFechaCliente.TabIndex = 27
        Me.rbPorFechaCliente.TabStop = True
        Me.rbPorFechaCliente.Text = "Fecha"
        Me.rbPorFechaCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbMerca
        '
        Me.rbMerca.Location = New System.Drawing.Point(7, 61)
        Me.rbMerca.Name = "rbMerca"
        Me.rbMerca.Size = New System.Drawing.Size(116, 15)
        Me.rbMerca.TabIndex = 1
        Me.rbMerca.Text = "Mercaderia"
        Me.rbMerca.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbCliente
        '
        Me.rbCliente.Checked = True
        Me.rbCliente.Location = New System.Drawing.Point(8, 16)
        Me.rbCliente.Name = "rbCliente"
        Me.rbCliente.Size = New System.Drawing.Size(90, 18)
        Me.rbCliente.TabIndex = 27
        Me.rbCliente.TabStop = True
        Me.rbCliente.Text = "Cliente"
        Me.rbCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.rbExportaciones)
        Me.UiGroupBox2.Controls.Add(Me.rbFacturadosSinEx)
        Me.UiGroupBox2.Controls.Add(Me.rbFacturacion)
        Me.UiGroupBox2.Controls.Add(Me.rbTodos)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(12, 334)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(205, 106)
        Me.UiGroupBox2.TabIndex = 78
        Me.UiGroupBox2.Text = "Documentos"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbExportaciones
        '
        Me.rbExportaciones.Location = New System.Drawing.Point(9, 79)
        Me.rbExportaciones.Name = "rbExportaciones"
        Me.rbExportaciones.Size = New System.Drawing.Size(101, 17)
        Me.rbExportaciones.TabIndex = 3
        Me.rbExportaciones.Text = "Exportaciones"
        Me.rbExportaciones.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbFacturadosSinEx
        '
        Me.rbFacturadosSinEx.Location = New System.Drawing.Point(9, 59)
        Me.rbFacturadosSinEx.Name = "rbFacturadosSinEx"
        Me.rbFacturadosSinEx.Size = New System.Drawing.Size(192, 15)
        Me.rbFacturadosSinEx.TabIndex = 2
        Me.rbFacturadosSinEx.Text = "Facturados sin Exportaciones"
        Me.rbFacturadosSinEx.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbFacturacion
        '
        Me.rbFacturacion.Location = New System.Drawing.Point(9, 37)
        Me.rbFacturacion.Name = "rbFacturacion"
        Me.rbFacturacion.Size = New System.Drawing.Size(116, 18)
        Me.rbFacturacion.TabIndex = 1
        Me.rbFacturacion.Text = "Facturacion"
        Me.rbFacturacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbTodos
        '
        Me.rbTodos.Checked = True
        Me.rbTodos.Location = New System.Drawing.Point(9, 16)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(90, 18)
        Me.rbTodos.TabIndex = 25
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbTipoReporte
        '
        Me.gbTipoReporte.Controls.Add(Me.rbDetalladoUnit)
        Me.gbTipoReporte.Controls.Add(Me.rbResumen)
        Me.gbTipoReporte.Controls.Add(Me.rbDetallado)
        Me.gbTipoReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoReporte.Location = New System.Drawing.Point(204, 256)
        Me.gbTipoReporte.Name = "gbTipoReporte"
        Me.gbTipoReporte.Size = New System.Drawing.Size(142, 78)
        Me.gbTipoReporte.TabIndex = 77
        Me.gbTipoReporte.Text = "Tipo Reporte"
        Me.gbTipoReporte.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbDetalladoUnit
        '
        Me.rbDetalladoUnit.Location = New System.Drawing.Point(9, 34)
        Me.rbDetalladoUnit.Name = "rbDetalladoUnit"
        Me.rbDetalladoUnit.Size = New System.Drawing.Size(129, 18)
        Me.rbDetalladoUnit.TabIndex = 24
        Me.rbDetalladoUnit.Text = "Detallado Unitario"
        Me.rbDetalladoUnit.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbResumen
        '
        Me.rbResumen.Location = New System.Drawing.Point(9, 55)
        Me.rbResumen.Name = "rbResumen"
        Me.rbResumen.Size = New System.Drawing.Size(70, 16)
        Me.rbResumen.TabIndex = 1
        Me.rbResumen.Text = "Resumen"
        Me.rbResumen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbDetallado
        '
        Me.rbDetallado.Checked = True
        Me.rbDetallado.Location = New System.Drawing.Point(9, 15)
        Me.rbDetallado.Name = "rbDetallado"
        Me.rbDetallado.Size = New System.Drawing.Size(90, 18)
        Me.rbDetallado.TabIndex = 23
        Me.rbDetallado.TabStop = True
        Me.rbDetallado.Text = "Detallado"
        Me.rbDetallado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'frmRepVentaDetalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(532, 549)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepVentaDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ventas Detallado"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox7.ResumeLayout(False)
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExportar.ResumeLayout(False)
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.UiGroupBox5.PerformLayout()
        CType(Me.cmbVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.cmbIdLocCli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbReporteAgrupado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReporteAgrupado.ResumeLayout(False)
        CType(Me.gbOrdenMerca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenMerca.ResumeLayout(False)
        CType(Me.gbOrdenCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenCliente.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        CType(Me.gbTipoReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoReporte.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbMercaderia As System.Windows.Forms.CheckBox
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbReporteAgrupado As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbMerca As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbCliente As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbExportaciones As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbFacturadosSinEx As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbFacturacion As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbTodos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbTipoReporte As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbResumen As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDetallado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbBuscarCliente As System.Windows.Forms.CheckBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbVendedor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTodoVendedor As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents UiGroupBox7 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbExportExcel As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPantalla As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblLocCliente As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocCli As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbExportar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbExpDetallado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbExpResumido As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbOrdenCliente As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbPorCliente As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPorFechaCliente As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPorMercaderia As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbOrdenMerca As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbPorFechaMerca As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDetalladoUnit As Janus.Windows.EditControls.UIRadioButton
End Class
