<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepventaMenxCli
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepventaMenxCli))
        Dim cmbCodSec_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbVendedor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gbMoneda = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbSoles = New System.Windows.Forms.RadioButton()
        Me.rbDolares = New System.Windows.Forms.RadioButton()
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.lblSector = New System.Windows.Forms.Label()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbResumen = New System.Windows.Forms.RadioButton()
        Me.rbDetalle = New System.Windows.Forms.RadioButton()
        Me.gbTipoOrden = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbDescendente = New System.Windows.Forms.RadioButton()
        Me.rbAscendente = New System.Windows.Forms.RadioButton()
        Me.gbOrdenadox = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTotVenta = New System.Windows.Forms.RadioButton()
        Me.rbCliente = New System.Windows.Forms.RadioButton()
        Me.cmbCodSec = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbVendedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTodoVendedor = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbVendedor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblOficina = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMoneda.SuspendLayout()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.gbTipoOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoOrden.SuspendLayout()
        CType(Me.gbOrdenadox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenadox.SuspendLayout()
        CType(Me.cmbCodSec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbVendedor.SuspendLayout()
        CType(Me.cmbVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbMoneda)
        Me.GroupBox1.Controls.Add(Me.cmbCodRub)
        Me.GroupBox1.Controls.Add(Me.lblRubro)
        Me.GroupBox1.Controls.Add(Me.lblSector)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox3)
        Me.GroupBox1.Controls.Add(Me.gbTipoOrden)
        Me.GroupBox1.Controls.Add(Me.gbOrdenadox)
        Me.GroupBox1.Controls.Add(Me.cmbCodSec)
        Me.GroupBox1.Controls.Add(Me.gbVendedor)
        Me.GroupBox1.Controls.Add(Me.cmbOficinas)
        Me.GroupBox1.Controls.Add(Me.lblOficina)
        Me.GroupBox1.Controls.Add(Me.lblAlmacen)
        Me.GroupBox1.Controls.Add(Me.cmbIdLocacion)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbFecFinal)
        Me.GroupBox1.Controls.Add(Me.cbFecInicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(469, 335)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'gbMoneda
        '
        Me.gbMoneda.Controls.Add(Me.rbSoles)
        Me.gbMoneda.Controls.Add(Me.rbDolares)
        Me.gbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMoneda.Location = New System.Drawing.Point(319, 256)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(106, 68)
        Me.gbMoneda.TabIndex = 119
        Me.gbMoneda.Text = "Moneda"
        Me.gbMoneda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbSoles
        '
        Me.rbSoles.AutoSize = True
        Me.rbSoles.Checked = True
        Me.rbSoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSoles.Location = New System.Drawing.Point(11, 19)
        Me.rbSoles.Name = "rbSoles"
        Me.rbSoles.Size = New System.Drawing.Size(75, 17)
        Me.rbSoles.TabIndex = 6
        Me.rbSoles.TabStop = True
        Me.rbSoles.Text = "En Soles"
        Me.rbSoles.UseVisualStyleBackColor = True
        '
        'rbDolares
        '
        Me.rbDolares.AutoSize = True
        Me.rbDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDolares.Location = New System.Drawing.Point(11, 42)
        Me.rbDolares.Name = "rbDolares"
        Me.rbDolares.Size = New System.Drawing.Size(87, 17)
        Me.rbDolares.TabIndex = 2
        Me.rbDolares.Text = "En Dólares"
        Me.rbDolares.UseVisualStyleBackColor = True
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Location = New System.Drawing.Point(96, 113)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(138, 20)
        Me.cmbCodRub.TabIndex = 5
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRubro.Location = New System.Drawing.Point(9, 115)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(54, 16)
        Me.lblRubro.TabIndex = 118
        Me.lblRubro.Text = "Rubro:"
        '
        'lblSector
        '
        Me.lblSector.AutoSize = True
        Me.lblSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSector.Location = New System.Drawing.Point(12, 224)
        Me.lblSector.Name = "lblSector"
        Me.lblSector.Size = New System.Drawing.Size(61, 16)
        Me.lblSector.TabIndex = 116
        Me.lblSector.Text = "Sector :"
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.rbResumen)
        Me.UiGroupBox3.Controls.Add(Me.rbDetalle)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(261, 57)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(181, 68)
        Me.UiGroupBox3.TabIndex = 115
        Me.UiGroupBox3.Text = "Reporte"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbResumen
        '
        Me.rbResumen.AutoSize = True
        Me.rbResumen.Location = New System.Drawing.Point(87, 28)
        Me.rbResumen.Name = "rbResumen"
        Me.rbResumen.Size = New System.Drawing.Size(77, 17)
        Me.rbResumen.TabIndex = 7
        Me.rbResumen.Text = "Resumen"
        Me.rbResumen.UseVisualStyleBackColor = True
        '
        'rbDetalle
        '
        Me.rbDetalle.AutoSize = True
        Me.rbDetalle.Checked = True
        Me.rbDetalle.Location = New System.Drawing.Point(16, 28)
        Me.rbDetalle.Name = "rbDetalle"
        Me.rbDetalle.Size = New System.Drawing.Size(65, 17)
        Me.rbDetalle.TabIndex = 6
        Me.rbDetalle.TabStop = True
        Me.rbDetalle.Text = "Detalle"
        Me.rbDetalle.UseVisualStyleBackColor = True
        '
        'gbTipoOrden
        '
        Me.gbTipoOrden.Controls.Add(Me.rbDescendente)
        Me.gbTipoOrden.Controls.Add(Me.rbAscendente)
        Me.gbTipoOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoOrden.Location = New System.Drawing.Point(176, 256)
        Me.gbTipoOrden.Name = "gbTipoOrden"
        Me.gbTipoOrden.Size = New System.Drawing.Size(130, 68)
        Me.gbTipoOrden.TabIndex = 114
        Me.gbTipoOrden.Text = "Tipo de Orden"
        Me.gbTipoOrden.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbDescendente
        '
        Me.rbDescendente.AutoSize = True
        Me.rbDescendente.Location = New System.Drawing.Point(16, 42)
        Me.rbDescendente.Name = "rbDescendente"
        Me.rbDescendente.Size = New System.Drawing.Size(100, 17)
        Me.rbDescendente.TabIndex = 1
        Me.rbDescendente.Text = "Descendente"
        Me.rbDescendente.UseVisualStyleBackColor = True
        '
        'rbAscendente
        '
        Me.rbAscendente.AutoSize = True
        Me.rbAscendente.Checked = True
        Me.rbAscendente.Location = New System.Drawing.Point(16, 19)
        Me.rbAscendente.Name = "rbAscendente"
        Me.rbAscendente.Size = New System.Drawing.Size(92, 17)
        Me.rbAscendente.TabIndex = 0
        Me.rbAscendente.TabStop = True
        Me.rbAscendente.Text = "Ascendente"
        Me.rbAscendente.UseVisualStyleBackColor = True
        '
        'gbOrdenadox
        '
        Me.gbOrdenadox.Controls.Add(Me.rbTotVenta)
        Me.gbOrdenadox.Controls.Add(Me.rbCliente)
        Me.gbOrdenadox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrdenadox.Location = New System.Drawing.Point(38, 256)
        Me.gbOrdenadox.Name = "gbOrdenadox"
        Me.gbOrdenadox.Size = New System.Drawing.Size(122, 68)
        Me.gbOrdenadox.TabIndex = 113
        Me.gbOrdenadox.Text = "Ordenado X"
        Me.gbOrdenadox.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTotVenta
        '
        Me.rbTotVenta.AutoSize = True
        Me.rbTotVenta.Location = New System.Drawing.Point(17, 42)
        Me.rbTotVenta.Name = "rbTotVenta"
        Me.rbTotVenta.Size = New System.Drawing.Size(91, 17)
        Me.rbTotVenta.TabIndex = 3
        Me.rbTotVenta.Text = "Total Venta"
        Me.rbTotVenta.UseVisualStyleBackColor = True
        '
        'rbCliente
        '
        Me.rbCliente.AutoSize = True
        Me.rbCliente.Checked = True
        Me.rbCliente.Location = New System.Drawing.Point(17, 19)
        Me.rbCliente.Name = "rbCliente"
        Me.rbCliente.Size = New System.Drawing.Size(64, 17)
        Me.rbCliente.TabIndex = 2
        Me.rbCliente.TabStop = True
        Me.rbCliente.Text = "Cliente"
        Me.rbCliente.UseVisualStyleBackColor = True
        '
        'cmbCodSec
        '
        Me.cmbCodSec.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodSec_DesignTimeLayout.LayoutString = resources.GetString("cmbCodSec_DesignTimeLayout.LayoutString")
        Me.cmbCodSec.DesignTimeLayout = cmbCodSec_DesignTimeLayout
        Me.cmbCodSec.Location = New System.Drawing.Point(80, 222)
        Me.cmbCodSec.Name = "cmbCodSec"
        Me.cmbCodSec.SelectedIndex = -1
        Me.cmbCodSec.SelectedItem = Nothing
        Me.cmbCodSec.Size = New System.Drawing.Size(134, 20)
        Me.cmbCodSec.TabIndex = 9
        Me.cmbCodSec.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbVendedor
        '
        Me.gbVendedor.Controls.Add(Me.rbTodoVendedor)
        Me.gbVendedor.Controls.Add(Me.Label4)
        Me.gbVendedor.Controls.Add(Me.cmbVendedor)
        Me.gbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbVendedor.Location = New System.Drawing.Point(11, 142)
        Me.gbVendedor.Name = "gbVendedor"
        Me.gbVendedor.Size = New System.Drawing.Size(448, 70)
        Me.gbVendedor.TabIndex = 110
        Me.gbVendedor.Text = "Buscar Por Vendedor"
        Me.gbVendedor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTodoVendedor
        '
        Me.rbTodoVendedor.AutoSize = True
        Me.rbTodoVendedor.Checked = True
        Me.rbTodoVendedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbTodoVendedor.Location = New System.Drawing.Point(9, 18)
        Me.rbTodoVendedor.Name = "rbTodoVendedor"
        Me.rbTodoVendedor.Size = New System.Drawing.Size(113, 17)
        Me.rbTodoVendedor.TabIndex = 11
        Me.rbTodoVendedor.TabStop = False
        Me.rbTodoVendedor.Text = "Todo Vendedor"
        Me.rbTodoVendedor.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 41)
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
        Me.cmbVendedor.Location = New System.Drawing.Point(91, 41)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.SelectedIndex = -1
        Me.cmbVendedor.SelectedItem = Nothing
        Me.cmbVendedor.SettingsKey = "cmbCodMot"
        Me.cmbVendedor.Size = New System.Drawing.Size(345, 20)
        Me.cmbVendedor.TabIndex = 8
        Me.cmbVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(96, 57)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(138, 20)
        Me.cmbOficinas.TabIndex = 3
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblOficina
        '
        Me.lblOficina.AutoSize = True
        Me.lblOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOficina.Location = New System.Drawing.Point(8, 59)
        Me.lblOficina.Name = "lblOficina"
        Me.lblOficina.Size = New System.Drawing.Size(60, 16)
        Me.lblOficina.TabIndex = 90
        Me.lblOficina.Text = "Oficina:"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(9, 89)
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
        Me.cmbIdLocacion.Location = New System.Drawing.Point(96, 85)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(138, 20)
        Me.cmbIdLocacion.TabIndex = 4
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(293, 24)
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
        Me.cbFecFinal.Location = New System.Drawing.Point(332, 22)
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
        Me.cbFecInicio.Location = New System.Drawing.Point(162, 22)
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
        Me.Label1.Location = New System.Drawing.Point(37, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Fechas      Del : "
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(159, 346)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 28)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(250, 346)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 28)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepventaMenxCli
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(498, 390)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepventaMenxCli"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ventas Mensuales por Cliente"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.gbTipoOrden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoOrden.ResumeLayout(False)
        Me.gbTipoOrden.PerformLayout()
        CType(Me.gbOrdenadox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenadox.ResumeLayout(False)
        Me.gbOrdenadox.PerformLayout()
        CType(Me.cmbCodSec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbVendedor.ResumeLayout(False)
        Me.gbVendedor.PerformLayout()
        CType(Me.cmbVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblOficina As System.Windows.Forms.Label
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbVendedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTodoVendedor As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbVendedor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbTipoOrden As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbOrdenadox As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbCodSec As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbAscendente As System.Windows.Forms.RadioButton
    Friend WithEvents rbDescendente As System.Windows.Forms.RadioButton
    Friend WithEvents lblSector As System.Windows.Forms.Label
    Friend WithEvents rbResumen As System.Windows.Forms.RadioButton
    Friend WithEvents rbDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents rbTotVenta As System.Windows.Forms.RadioButton
    Friend WithEvents rbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblRubro As System.Windows.Forms.Label
    Friend WithEvents rbDolares As System.Windows.Forms.RadioButton
    Friend WithEvents rbSoles As System.Windows.Forms.RadioButton
    Friend WithEvents gbMoneda As Janus.Windows.EditControls.UIGroupBox
End Class
