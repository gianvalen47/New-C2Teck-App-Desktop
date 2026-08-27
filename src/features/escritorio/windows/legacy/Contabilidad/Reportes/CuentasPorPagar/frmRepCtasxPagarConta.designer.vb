<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCtasxPagarConta
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
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCtasxPagarConta))
        Dim cmbPosesion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.gbDocumento = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbCancelado = New System.Windows.Forms.RadioButton()
        Me.rbPendiente = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbPosesion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbResumido = New System.Windows.Forms.RadioButton()
        Me.rbDetallado = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbBuscarProveedor = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gbTipoCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoCompra.SuspendLayout()
        CType(Me.gbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMoneda.SuspendLayout()
        CType(Me.gbOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrden.SuspendLayout()
        CType(Me.gbOrdenadoPor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenadoPor.SuspendLayout()
        CType(Me.gbDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDocumento.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbPosesion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gbTipoCompra)
        Me.GroupBox1.Controls.Add(Me.gbMoneda)
        Me.GroupBox1.Controls.Add(Me.gbOrden)
        Me.GroupBox1.Controls.Add(Me.gbOrdenadoPor)
        Me.GroupBox1.Controls.Add(Me.gbDocumento)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox3)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox2)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox1)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox6)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbFecFinal)
        Me.GroupBox1.Controls.Add(Me.cbFecInicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 389)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'gbTipoCompra
        '
        Me.gbTipoCompra.Controls.Add(Me.rbComprasExterior)
        Me.gbTipoCompra.Controls.Add(Me.rbComprasLocales)
        Me.gbTipoCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoCompra.Location = New System.Drawing.Point(11, 213)
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
        Me.gbMoneda.Location = New System.Drawing.Point(263, 298)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(78, 79)
        Me.gbMoneda.TabIndex = 17
        Me.gbMoneda.Text = "Moneda"
        Me.gbMoneda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbDolares
        '
        Me.rbDolares.AutoSize = True
        Me.rbDolares.Location = New System.Drawing.Point(7, 45)
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
        Me.rbSoles.Location = New System.Drawing.Point(7, 22)
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
        Me.gbOrden.Location = New System.Drawing.Point(146, 298)
        Me.gbOrden.Name = "gbOrden"
        Me.gbOrden.Size = New System.Drawing.Size(109, 79)
        Me.gbOrden.TabIndex = 16
        Me.gbOrden.Text = "Orden"
        Me.gbOrden.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbAscendente
        '
        Me.rbAscendente.AutoSize = True
        Me.rbAscendente.Location = New System.Drawing.Point(7, 45)
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
        Me.rbDescendente.Location = New System.Drawing.Point(7, 22)
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
        Me.gbOrdenadoPor.Location = New System.Drawing.Point(48, 298)
        Me.gbOrdenadoPor.Name = "gbOrdenadoPor"
        Me.gbOrdenadoPor.Size = New System.Drawing.Size(90, 79)
        Me.gbOrdenadoPor.TabIndex = 15
        Me.gbOrdenadoPor.Text = "Ordenado X"
        Me.gbOrdenadoPor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbProveedor
        '
        Me.rbProveedor.AutoSize = True
        Me.rbProveedor.Location = New System.Drawing.Point(6, 45)
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
        Me.rbTotal.Location = New System.Drawing.Point(7, 22)
        Me.rbTotal.Name = "rbTotal"
        Me.rbTotal.Size = New System.Drawing.Size(54, 17)
        Me.rbTotal.TabIndex = 0
        Me.rbTotal.TabStop = True
        Me.rbTotal.Text = "Total"
        Me.rbTotal.UseVisualStyleBackColor = True
        '
        'gbDocumento
        '
        Me.gbDocumento.Controls.Add(Me.Label15)
        Me.gbDocumento.Controls.Add(Me.cmbTipoDoc)
        Me.gbDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDocumento.Location = New System.Drawing.Point(14, 162)
        Me.gbDocumento.Name = "gbDocumento"
        Me.gbDocumento.Size = New System.Drawing.Size(360, 43)
        Me.gbDocumento.TabIndex = 10
        Me.gbDocumento.Text = "Documento"
        Me.gbDocumento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Tipo Documento"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Location = New System.Drawing.Point(113, 15)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(237, 20)
        Me.cmbTipoDoc.TabIndex = 11
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.rbTodos)
        Me.UiGroupBox3.Controls.Add(Me.rbCancelado)
        Me.UiGroupBox3.Controls.Add(Me.rbPendiente)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(269, 213)
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
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.cmbPosesion)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(14, 112)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(362, 43)
        Me.UiGroupBox2.TabIndex = 8
        Me.UiGroupBox2.Text = "Posesión"
        Me.UiGroupBox2.Visible = False
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbPosesion
        '
        Me.cmbPosesion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPosesion_DesignTimeLayout.LayoutString = resources.GetString("cmbPosesion_DesignTimeLayout.LayoutString")
        Me.cmbPosesion.DesignTimeLayout = cmbPosesion_DesignTimeLayout
        Me.cmbPosesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPosesion.Location = New System.Drawing.Point(80, 15)
        Me.cmbPosesion.Name = "cmbPosesion"
        Me.cmbPosesion.SelectedIndex = -1
        Me.cmbPosesion.SelectedItem = Nothing
        Me.cmbPosesion.Size = New System.Drawing.Size(272, 20)
        Me.cmbPosesion.TabIndex = 9
        Me.cmbPosesion.Visible = False
        Me.cmbPosesion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Posesión"
        Me.Label2.Visible = False
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbResumido)
        Me.UiGroupBox1.Controls.Add(Me.rbDetallado)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(164, 213)
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
        Me.UiGroupBox6.Location = New System.Drawing.Point(14, 49)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(362, 56)
        Me.UiGroupBox6.TabIndex = 5
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
        Me.txtProveedor.TabIndex = 6
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(327, 27)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 7
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(232, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Al  :"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(265, 17)
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
        Me.cbFecInicio.Location = New System.Drawing.Point(115, 17)
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
        Me.Label1.Location = New System.Drawing.Point(17, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = " Fechas   Del : "
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(125, 401)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 27)
        Me.btnAceptar.TabIndex = 18
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
        Me.btnCancelar.Location = New System.Drawing.Point(209, 401)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepCtasxPagarConta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(426, 449)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepCtasxPagarConta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Cuentas x Pagar Contable"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
        CType(Me.gbDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDocumento.ResumeLayout(False)
        Me.gbDocumento.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbPosesion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbResumido As System.Windows.Forms.RadioButton
    Friend WithEvents rbDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbBuscarProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbPosesion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbPendiente As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbCancelado As System.Windows.Forms.RadioButton
    Friend WithEvents gbDocumento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbOrden As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbAscendente As System.Windows.Forms.RadioButton
    Friend WithEvents rbDescendente As System.Windows.Forms.RadioButton
    Friend WithEvents gbOrdenadoPor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbTotal As System.Windows.Forms.RadioButton
    Friend WithEvents gbMoneda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbDolares As System.Windows.Forms.RadioButton
    Friend WithEvents rbSoles As System.Windows.Forms.RadioButton
    Friend WithEvents gbTipoCompra As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbComprasExterior As System.Windows.Forms.RadioButton
    Friend WithEvents rbComprasLocales As System.Windows.Forms.RadioButton
End Class
