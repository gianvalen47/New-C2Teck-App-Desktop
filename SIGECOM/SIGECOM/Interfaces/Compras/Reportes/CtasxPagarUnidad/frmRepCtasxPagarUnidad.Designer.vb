<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCtasxPagarUnidad
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
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCtasxPagarUnidad))
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbTipoCompra = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbComprasExterior = New System.Windows.Forms.RadioButton()
        Me.rbComprasLocales = New System.Windows.Forms.RadioButton()
        Me.gbMoneda = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbDolares = New System.Windows.Forms.RadioButton()
        Me.rbSoles = New System.Windows.Forms.RadioButton()
        Me.gbOrden = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbAscendente = New System.Windows.Forms.RadioButton()
        Me.rbDescendente = New System.Windows.Forms.RadioButton()
        Me.gbOrdenadoPor = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbProveedor = New System.Windows.Forms.RadioButton()
        Me.rbTotal = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbCancelado = New System.Windows.Forms.RadioButton()
        Me.rbPendiente = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbResumido = New System.Windows.Forms.RadioButton()
        Me.rbDetallado = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbBuscarProveedor = New System.Windows.Forms.CheckBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoCompra.SuspendLayout()
        CType(Me.gbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMoneda.SuspendLayout()
        CType(Me.gbOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrden.SuspendLayout()
        CType(Me.gbOrdenadoPor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenadoPor.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.UiGroupBox4)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.GroupBox1.Controls.Add(Me.gbTipoCompra)
        Me.GroupBox1.Controls.Add(Me.gbMoneda)
        Me.GroupBox1.Controls.Add(Me.gbOrden)
        Me.GroupBox1.Controls.Add(Me.gbOrdenadoPor)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox3)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox1)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox6)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(468, 380)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox4.Controls.Add(Me.Label1)
        Me.UiGroupBox4.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox4.Controls.Add(Me.Label6)
        Me.UiGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox4.Location = New System.Drawing.Point(48, 13)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(372, 51)
        Me.UiGroupBox4.TabIndex = 0
        Me.UiGroupBox4.Text = "Rango de Fechas"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicio.Location = New System.Drawing.Point(81, 21)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Del : "
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(236, 21)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 2
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(200, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Al  :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.Label26)
        Me.UiGroupBox2.Controls.Add(Me.cmbCentroCosto)
        Me.UiGroupBox2.Controls.Add(Me.cmbArea)
        Me.UiGroupBox2.Controls.Add(Me.cmbUnidad)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(8, 71)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(452, 72)
        Me.UiGroupBox2.TabIndex = 3
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(269, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 259
        Me.Label4.Text = "Area"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(9, 46)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 13)
        Me.Label26.TabIndex = 258
        Me.Label26.Text = "Centro de Costo"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(113, 42)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(171, 20)
        Me.cmbCentroCosto.TabIndex = 6
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Location = New System.Drawing.Point(308, 16)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(135, 20)
        Me.cmbArea.TabIndex = 5
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(113, 16)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(128, 20)
        Me.cmbUnidad.TabIndex = 4
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Unidad Negocio"
        '
        'gbTipoCompra
        '
        Me.gbTipoCompra.Controls.Add(Me.rbComprasExterior)
        Me.gbTipoCompra.Controls.Add(Me.rbComprasLocales)
        Me.gbTipoCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoCompra.Location = New System.Drawing.Point(48, 216)
        Me.gbTipoCompra.Name = "gbTipoCompra"
        Me.gbTipoCompra.Size = New System.Drawing.Size(144, 79)
        Me.gbTipoCompra.TabIndex = 12
        Me.gbTipoCompra.Text = "Tipo de Compra"
        Me.gbTipoCompra.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbComprasExterior
        '
        Me.rbComprasExterior.AutoSize = True
        Me.rbComprasExterior.Location = New System.Drawing.Point(5, 45)
        Me.rbComprasExterior.Name = "rbComprasExterior"
        Me.rbComprasExterior.Size = New System.Drawing.Size(134, 17)
        Me.rbComprasExterior.TabIndex = 1
        Me.rbComprasExterior.TabStop = True
        Me.rbComprasExterior.Text = "Compras al Exterior"
        Me.rbComprasExterior.UseVisualStyleBackColor = True
        '
        'rbComprasLocales
        '
        Me.rbComprasLocales.AutoSize = True
        Me.rbComprasLocales.Checked = True
        Me.rbComprasLocales.Location = New System.Drawing.Point(5, 22)
        Me.rbComprasLocales.Name = "rbComprasLocales"
        Me.rbComprasLocales.Size = New System.Drawing.Size(121, 17)
        Me.rbComprasLocales.TabIndex = 0
        Me.rbComprasLocales.TabStop = True
        Me.rbComprasLocales.Text = "Compras Locales"
        Me.rbComprasLocales.UseVisualStyleBackColor = True
        '
        'gbMoneda
        '
        Me.gbMoneda.Controls.Add(Me.rbDolares)
        Me.gbMoneda.Controls.Add(Me.rbSoles)
        Me.gbMoneda.Enabled = False
        Me.gbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMoneda.Location = New System.Drawing.Point(302, 301)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(96, 68)
        Me.gbMoneda.TabIndex = 17
        Me.gbMoneda.Text = "Moneda"
        Me.gbMoneda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbDolares
        '
        Me.rbDolares.AutoSize = True
        Me.rbDolares.Location = New System.Drawing.Point(14, 41)
        Me.rbDolares.Name = "rbDolares"
        Me.rbDolares.Size = New System.Drawing.Size(68, 17)
        Me.rbDolares.TabIndex = 1
        Me.rbDolares.TabStop = True
        Me.rbDolares.Text = "Dolares"
        Me.rbDolares.UseVisualStyleBackColor = True
        '
        'rbSoles
        '
        Me.rbSoles.AutoSize = True
        Me.rbSoles.Checked = True
        Me.rbSoles.Location = New System.Drawing.Point(14, 18)
        Me.rbSoles.Name = "rbSoles"
        Me.rbSoles.Size = New System.Drawing.Size(56, 17)
        Me.rbSoles.TabIndex = 0
        Me.rbSoles.TabStop = True
        Me.rbSoles.Text = "Soles"
        Me.rbSoles.UseVisualStyleBackColor = True
        '
        'gbOrden
        '
        Me.gbOrden.Controls.Add(Me.rbAscendente)
        Me.gbOrden.Controls.Add(Me.rbDescendente)
        Me.gbOrden.Enabled = False
        Me.gbOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrden.Location = New System.Drawing.Point(176, 301)
        Me.gbOrden.Name = "gbOrden"
        Me.gbOrden.Size = New System.Drawing.Size(120, 68)
        Me.gbOrden.TabIndex = 16
        Me.gbOrden.Text = "Orden"
        Me.gbOrden.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbAscendente
        '
        Me.rbAscendente.AutoSize = True
        Me.rbAscendente.Location = New System.Drawing.Point(11, 41)
        Me.rbAscendente.Name = "rbAscendente"
        Me.rbAscendente.Size = New System.Drawing.Size(92, 17)
        Me.rbAscendente.TabIndex = 1
        Me.rbAscendente.TabStop = True
        Me.rbAscendente.Text = "Ascendente"
        Me.rbAscendente.UseVisualStyleBackColor = True
        '
        'rbDescendente
        '
        Me.rbDescendente.AutoSize = True
        Me.rbDescendente.Checked = True
        Me.rbDescendente.Location = New System.Drawing.Point(11, 18)
        Me.rbDescendente.Name = "rbDescendente"
        Me.rbDescendente.Size = New System.Drawing.Size(100, 17)
        Me.rbDescendente.TabIndex = 0
        Me.rbDescendente.TabStop = True
        Me.rbDescendente.Text = "Descendente"
        Me.rbDescendente.UseVisualStyleBackColor = True
        '
        'gbOrdenadoPor
        '
        Me.gbOrdenadoPor.Controls.Add(Me.rbProveedor)
        Me.gbOrdenadoPor.Controls.Add(Me.rbTotal)
        Me.gbOrdenadoPor.Enabled = False
        Me.gbOrdenadoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOrdenadoPor.Location = New System.Drawing.Point(66, 301)
        Me.gbOrdenadoPor.Name = "gbOrdenadoPor"
        Me.gbOrdenadoPor.Size = New System.Drawing.Size(104, 68)
        Me.gbOrdenadoPor.TabIndex = 15
        Me.gbOrdenadoPor.Text = "Ordenado X"
        Me.gbOrdenadoPor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbProveedor
        '
        Me.rbProveedor.AutoSize = True
        Me.rbProveedor.Location = New System.Drawing.Point(14, 41)
        Me.rbProveedor.Name = "rbProveedor"
        Me.rbProveedor.Size = New System.Drawing.Size(83, 17)
        Me.rbProveedor.TabIndex = 1
        Me.rbProveedor.TabStop = True
        Me.rbProveedor.Text = "Proveedor"
        Me.rbProveedor.UseVisualStyleBackColor = True
        '
        'rbTotal
        '
        Me.rbTotal.AutoSize = True
        Me.rbTotal.Checked = True
        Me.rbTotal.Location = New System.Drawing.Point(14, 18)
        Me.rbTotal.Name = "rbTotal"
        Me.rbTotal.Size = New System.Drawing.Size(54, 17)
        Me.rbTotal.TabIndex = 0
        Me.rbTotal.TabStop = True
        Me.rbTotal.Text = "Total"
        Me.rbTotal.UseVisualStyleBackColor = True
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.rbTodos)
        Me.UiGroupBox3.Controls.Add(Me.rbCancelado)
        Me.UiGroupBox3.Controls.Add(Me.rbPendiente)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(303, 216)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(109, 79)
        Me.UiGroupBox3.TabIndex = 14
        Me.UiGroupBox3.Text = "Condición"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(9, 53)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(60, 17)
        Me.rbTodos.TabIndex = 3
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbCancelado
        '
        Me.rbCancelado.AutoSize = True
        Me.rbCancelado.Location = New System.Drawing.Point(9, 35)
        Me.rbCancelado.Name = "rbCancelado"
        Me.rbCancelado.Size = New System.Drawing.Size(91, 17)
        Me.rbCancelado.TabIndex = 2
        Me.rbCancelado.TabStop = True
        Me.rbCancelado.Text = "Cancelados"
        Me.rbCancelado.UseVisualStyleBackColor = True
        '
        'rbPendiente
        '
        Me.rbPendiente.AutoSize = True
        Me.rbPendiente.Checked = True
        Me.rbPendiente.Location = New System.Drawing.Point(9, 17)
        Me.rbPendiente.Name = "rbPendiente"
        Me.rbPendiente.Size = New System.Drawing.Size(88, 17)
        Me.rbPendiente.TabIndex = 1
        Me.rbPendiente.TabStop = True
        Me.rbPendiente.Text = "Pendientes"
        Me.rbPendiente.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbResumido)
        Me.UiGroupBox1.Controls.Add(Me.rbDetallado)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(198, 216)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(96, 79)
        Me.UiGroupBox1.TabIndex = 13
        Me.UiGroupBox1.Text = "Tipo"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbResumido
        '
        Me.rbResumido.AutoSize = True
        Me.rbResumido.Location = New System.Drawing.Point(6, 45)
        Me.rbResumido.Name = "rbResumido"
        Me.rbResumido.Size = New System.Drawing.Size(80, 17)
        Me.rbResumido.TabIndex = 1
        Me.rbResumido.TabStop = True
        Me.rbResumido.Text = "Resumido"
        Me.rbResumido.UseVisualStyleBackColor = True
        '
        'rbDetallado
        '
        Me.rbDetallado.AutoSize = True
        Me.rbDetallado.Checked = True
        Me.rbDetallado.Location = New System.Drawing.Point(6, 22)
        Me.rbDetallado.Name = "rbDetallado"
        Me.rbDetallado.Size = New System.Drawing.Size(79, 17)
        Me.rbDetallado.TabIndex = 0
        Me.rbDetallado.TabStop = True
        Me.rbDetallado.Text = "Detallado"
        Me.rbDetallado.UseVisualStyleBackColor = True
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.Controls.Add(Me.txtProveedor)
        Me.UiGroupBox6.Controls.Add(Me.btnBuscarProveedor)
        Me.UiGroupBox6.Controls.Add(Me.Label12)
        Me.UiGroupBox6.Controls.Add(Me.rbBuscarProveedor)
        Me.UiGroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox6.Location = New System.Drawing.Point(48, 151)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(372, 56)
        Me.UiGroupBox6.TabIndex = 7
        Me.UiGroupBox6.Text = "Buscar Proveedor"
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(75, 29)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(251, 20)
        Me.txtProveedor.TabIndex = 8
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(327, 28)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 9
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Proveedor"
        '
        'rbBuscarProveedor
        '
        Me.rbBuscarProveedor.AutoSize = True
        Me.rbBuscarProveedor.Checked = True
        Me.rbBuscarProveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbBuscarProveedor.Location = New System.Drawing.Point(144, 10)
        Me.rbBuscarProveedor.Name = "rbBuscarProveedor"
        Me.rbBuscarProveedor.Size = New System.Drawing.Size(117, 17)
        Me.rbBuscarProveedor.TabIndex = 17
        Me.rbBuscarProveedor.TabStop = False
        Me.rbBuscarProveedor.Text = "Todo Proveedor"
        Me.rbBuscarProveedor.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(160, 391)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 29)
        Me.btnAceptar.TabIndex = 20
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
        Me.btnCancelar.Location = New System.Drawing.Point(246, 391)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 29)
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepCtasxPagarUnidad
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(485, 429)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepCtasxPagarUnidad"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ctas x Pagar x Unidad de Negocio"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbTipoCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoCompra.ResumeLayout(False)
        Me.gbTipoCompra.PerformLayout()
        CType(Me.gbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
        CType(Me.gbOrden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrden.ResumeLayout(False)
        Me.gbOrden.PerformLayout()
        CType(Me.gbOrdenadoPor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenadoPor.ResumeLayout(False)
        Me.gbOrdenadoPor.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbTipoCompra As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbComprasExterior As System.Windows.Forms.RadioButton
    Friend WithEvents rbComprasLocales As System.Windows.Forms.RadioButton
    Friend WithEvents gbMoneda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbDolares As System.Windows.Forms.RadioButton
    Friend WithEvents rbSoles As System.Windows.Forms.RadioButton
    Friend WithEvents gbOrden As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbAscendente As System.Windows.Forms.RadioButton
    Friend WithEvents rbDescendente As System.Windows.Forms.RadioButton
    Friend WithEvents gbOrdenadoPor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbTotal As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbCancelado As System.Windows.Forms.RadioButton
    Friend WithEvents rbPendiente As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbResumido As System.Windows.Forms.RadioButton
    Friend WithEvents rbDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rbBuscarProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
End Class
