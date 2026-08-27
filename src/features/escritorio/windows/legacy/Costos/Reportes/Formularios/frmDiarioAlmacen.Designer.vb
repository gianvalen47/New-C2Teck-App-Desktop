<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiarioAlmacen
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
        Dim ExplorerBarGroup1 As Janus.Windows.ExplorerBar.ExplorerBarGroup = New Janus.Windows.ExplorerBar.ExplorerBarGroup
        Dim ExplorerBarItem1 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem
        Dim ExplorerBarItem2 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem
        Dim ExplorerBarItem3 As Janus.Windows.ExplorerBar.ExplorerBarItem = New Janus.Windows.ExplorerBar.ExplorerBarItem
        Dim cbTipoMovimiento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbDocumento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbMotivo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbAlmacenDestino_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cbOficinaDestino_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiarioAlmacen))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gpAlmacenes = New Janus.Windows.EditControls.UIGroupBox
        Me.cbAlmacen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cbOficina = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ExplorerBar1 = New Janus.Windows.ExplorerBar.ExplorerBar
        Me.gbFacturacion = New Janus.Windows.EditControls.UIGroupBox
        Me.gbFacturado = New Janus.Windows.EditControls.UIGroupBox
        Me.rbNoFacturado = New Janus.Windows.EditControls.UIRadioButton
        Me.rbFacturado = New Janus.Windows.EditControls.UIRadioButton
        Me.gbComprobante = New Janus.Windows.EditControls.UIGroupBox
        Me.rbNota = New Janus.Windows.EditControls.UIRadioButton
        Me.rbBoleta = New Janus.Windows.EditControls.UIRadioButton
        Me.rbFactura = New Janus.Windows.EditControls.UIRadioButton
        Me.gbCondicion = New Janus.Windows.EditControls.UIGroupBox
        Me.rbContado = New Janus.Windows.EditControls.UIRadioButton
        Me.rbCredito = New Janus.Windows.EditControls.UIRadioButton
        Me.gbCondicionFact = New Janus.Windows.EditControls.UIGroupBox
        Me.rbContado1 = New Janus.Windows.EditControls.UIRadioButton
        Me.rbCredito1 = New Janus.Windows.EditControls.UIRadioButton
        Me.rbTodos = New Janus.Windows.EditControls.UIRadioButton
        Me.cbTipoMovimiento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.gbTipoMovimiento = New Janus.Windows.EditControls.UIGroupBox
        Me.gbDocumento = New Janus.Windows.EditControls.UIGroupBox
        Me.cbDocumento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.gbMotivos = New Janus.Windows.EditControls.UIGroupBox
        Me.cbMotivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.gbArea = New Janus.Windows.EditControls.UIGroupBox
        Me.cbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.gbNumJob = New Janus.Windows.EditControls.UIGroupBox
        Me.txtNumJob = New System.Windows.Forms.TextBox
        Me.gbDestino = New Janus.Windows.EditControls.UIGroupBox
        Me.cbAlmacenDestino = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cbOficinaDestino = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.UiGroupBox11 = New Janus.Windows.EditControls.UIGroupBox
        Me.rbTotalizado = New Janus.Windows.EditControls.UIRadioButton
        Me.rbDetalle = New Janus.Windows.EditControls.UIRadioButton
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.rbBuscarCliente = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpAlmacenes.SuspendLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExplorerBar1.SuspendLayout()
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFacturacion.SuspendLayout()
        CType(Me.gbFacturado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFacturado.SuspendLayout()
        CType(Me.gbComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbComprobante.SuspendLayout()
        CType(Me.gbCondicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCondicion.SuspendLayout()
        CType(Me.gbCondicionFact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCondicionFact.SuspendLayout()
        CType(Me.cbTipoMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbTipoMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoMovimiento.SuspendLayout()
        CType(Me.gbDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDocumento.SuspendLayout()
        CType(Me.cbDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbMotivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMotivos.SuspendLayout()
        CType(Me.cbMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbArea.SuspendLayout()
        CType(Me.cbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbNumJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNumJob.SuspendLayout()
        CType(Me.gbDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDestino.SuspendLayout()
        CType(Me.cbAlmacenDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOficinaDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox11.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
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
        Me.gpAlmacenes.Location = New System.Drawing.Point(169, 42)
        Me.gpAlmacenes.Name = "gpAlmacenes"
        Me.gpAlmacenes.Size = New System.Drawing.Size(427, 62)
        Me.gpAlmacenes.TabIndex = 6
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
        Me.cbAlmacen.Size = New System.Drawing.Size(354, 20)
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
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox1.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(169, 106)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(270, 47)
        Me.UiGroupBox1.TabIndex = 7
        Me.UiGroupBox1.Text = "Fechas"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Location = New System.Drawing.Point(168, 19)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(93, 20)
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
        Me.cbFecInicio.Location = New System.Drawing.Point(42, 18)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(95, 20)
        Me.cbFecInicio.TabIndex = 2
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(141, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Al :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Del :"
        '
        'ExplorerBar1
        '
        Me.ExplorerBar1.Controls.Add(Me.gbFacturacion)
        Me.ExplorerBar1.Controls.Add(Me.gbCondicionFact)
        ExplorerBarItem1.Key = "Item1"
        ExplorerBarItem1.Text = "General"
        ExplorerBarItem2.Key = "Item2"
        ExplorerBarItem2.Text = "Entrega de Materiales"
        ExplorerBarItem3.Key = "Item3"
        ExplorerBarItem3.Text = "Facturación"
        ExplorerBarGroup1.Items.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarItem() {ExplorerBarItem1, ExplorerBarItem2, ExplorerBarItem3})
        ExplorerBarGroup1.Key = "Group1"
        ExplorerBarGroup1.Text = "Movimientos"
        Me.ExplorerBar1.Groups.AddRange(New Janus.Windows.ExplorerBar.ExplorerBarGroup() {ExplorerBarGroup1})
        Me.ExplorerBar1.Location = New System.Drawing.Point(4, 6)
        Me.ExplorerBar1.Name = "ExplorerBar1"
        Me.ExplorerBar1.Size = New System.Drawing.Size(161, 419)
        Me.ExplorerBar1.TabIndex = 8
        Me.ExplorerBar1.VisualStyle = Janus.Windows.ExplorerBar.VisualStyle.Office2007
        '
        'gbFacturacion
        '
        Me.gbFacturacion.Controls.Add(Me.gbFacturado)
        Me.gbFacturacion.Controls.Add(Me.gbComprobante)
        Me.gbFacturacion.Controls.Add(Me.gbCondicion)
        Me.gbFacturacion.Location = New System.Drawing.Point(13, 108)
        Me.gbFacturacion.Name = "gbFacturacion"
        Me.gbFacturacion.Size = New System.Drawing.Size(135, 200)
        Me.gbFacturacion.TabIndex = 16
        Me.gbFacturacion.Visible = False
        Me.gbFacturacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbFacturado
        '
        Me.gbFacturado.Controls.Add(Me.rbNoFacturado)
        Me.gbFacturado.Controls.Add(Me.rbFacturado)
        Me.gbFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFacturado.Location = New System.Drawing.Point(0, -1)
        Me.gbFacturado.Name = "gbFacturado"
        Me.gbFacturado.Size = New System.Drawing.Size(135, 57)
        Me.gbFacturado.TabIndex = 4
        Me.gbFacturado.Text = "Facturación"
        Me.gbFacturado.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbNoFacturado
        '
        Me.rbNoFacturado.Location = New System.Drawing.Point(8, 34)
        Me.rbNoFacturado.Name = "rbNoFacturado"
        Me.rbNoFacturado.Size = New System.Drawing.Size(98, 16)
        Me.rbNoFacturado.TabIndex = 1
        Me.rbNoFacturado.Text = "No Facturado"
        Me.rbNoFacturado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbFacturado
        '
        Me.rbFacturado.Checked = True
        Me.rbFacturado.Location = New System.Drawing.Point(8, 15)
        Me.rbFacturado.Name = "rbFacturado"
        Me.rbFacturado.Size = New System.Drawing.Size(77, 16)
        Me.rbFacturado.TabIndex = 0
        Me.rbFacturado.TabStop = True
        Me.rbFacturado.Text = "Facturado"
        Me.rbFacturado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbComprobante
        '
        Me.gbComprobante.Controls.Add(Me.rbNota)
        Me.gbComprobante.Controls.Add(Me.rbBoleta)
        Me.gbComprobante.Controls.Add(Me.rbFactura)
        Me.gbComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbComprobante.Location = New System.Drawing.Point(0, 63)
        Me.gbComprobante.Name = "gbComprobante"
        Me.gbComprobante.Size = New System.Drawing.Size(135, 74)
        Me.gbComprobante.TabIndex = 2
        Me.gbComprobante.Text = "Comprobante"
        Me.gbComprobante.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbNota
        '
        Me.rbNota.Location = New System.Drawing.Point(8, 53)
        Me.rbNota.Name = "rbNota"
        Me.rbNota.Size = New System.Drawing.Size(106, 17)
        Me.rbNota.TabIndex = 2
        Me.rbNota.Text = "Nota de Credito"
        Me.rbNota.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbBoleta
        '
        Me.rbBoleta.Location = New System.Drawing.Point(8, 34)
        Me.rbBoleta.Name = "rbBoleta"
        Me.rbBoleta.Size = New System.Drawing.Size(53, 16)
        Me.rbBoleta.TabIndex = 1
        Me.rbBoleta.Text = "Boleta"
        Me.rbBoleta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbFactura
        '
        Me.rbFactura.Checked = True
        Me.rbFactura.Location = New System.Drawing.Point(8, 15)
        Me.rbFactura.Name = "rbFactura"
        Me.rbFactura.Size = New System.Drawing.Size(74, 16)
        Me.rbFactura.TabIndex = 0
        Me.rbFactura.TabStop = True
        Me.rbFactura.Text = "Factura"
        Me.rbFactura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbCondicion
        '
        Me.gbCondicion.Controls.Add(Me.rbContado)
        Me.gbCondicion.Controls.Add(Me.rbCredito)
        Me.gbCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCondicion.Location = New System.Drawing.Point(0, 143)
        Me.gbCondicion.Name = "gbCondicion"
        Me.gbCondicion.Size = New System.Drawing.Size(135, 57)
        Me.gbCondicion.TabIndex = 3
        Me.gbCondicion.Text = "Condicion"
        Me.gbCondicion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbContado
        '
        Me.rbContado.Location = New System.Drawing.Point(8, 34)
        Me.rbContado.Name = "rbContado"
        Me.rbContado.Size = New System.Drawing.Size(87, 16)
        Me.rbContado.TabIndex = 1
        Me.rbContado.Text = "Contado"
        Me.rbContado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbCredito
        '
        Me.rbCredito.Checked = True
        Me.rbCredito.Location = New System.Drawing.Point(8, 15)
        Me.rbCredito.Name = "rbCredito"
        Me.rbCredito.Size = New System.Drawing.Size(74, 16)
        Me.rbCredito.TabIndex = 0
        Me.rbCredito.TabStop = True
        Me.rbCredito.Text = "Credito"
        Me.rbCredito.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbCondicionFact
        '
        Me.gbCondicionFact.Controls.Add(Me.rbContado1)
        Me.gbCondicionFact.Controls.Add(Me.rbCredito1)
        Me.gbCondicionFact.Controls.Add(Me.rbTodos)
        Me.gbCondicionFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCondicionFact.Location = New System.Drawing.Point(13, 314)
        Me.gbCondicionFact.Name = "gbCondicionFact"
        Me.gbCondicionFact.Size = New System.Drawing.Size(135, 77)
        Me.gbCondicionFact.TabIndex = 19
        Me.gbCondicionFact.Text = "Condicion"
        Me.gbCondicionFact.Visible = False
        Me.gbCondicionFact.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbContado1
        '
        Me.rbContado1.Location = New System.Drawing.Point(8, 55)
        Me.rbContado1.Name = "rbContado1"
        Me.rbContado1.Size = New System.Drawing.Size(87, 16)
        Me.rbContado1.TabIndex = 2
        Me.rbContado1.Text = "Contado"
        Me.rbContado1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbCredito1
        '
        Me.rbCredito1.Location = New System.Drawing.Point(8, 34)
        Me.rbCredito1.Name = "rbCredito1"
        Me.rbCredito1.Size = New System.Drawing.Size(87, 16)
        Me.rbCredito1.TabIndex = 1
        Me.rbCredito1.Text = "Crédito"
        Me.rbCredito1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbTodos
        '
        Me.rbTodos.Checked = True
        Me.rbTodos.Location = New System.Drawing.Point(8, 15)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(74, 16)
        Me.rbTodos.TabIndex = 0
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbTipoMovimiento
        '
        Me.cbTipoMovimiento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbTipoMovimiento_DesignTimeLayout.LayoutString = resources.GetString("cbTipoMovimiento_DesignTimeLayout.LayoutString")
        Me.cbTipoMovimiento.DesignTimeLayout = cbTipoMovimiento_DesignTimeLayout
        Me.cbTipoMovimiento.Location = New System.Drawing.Point(7, 14)
        Me.cbTipoMovimiento.Name = "cbTipoMovimiento"
        Me.cbTipoMovimiento.SelectedIndex = -1
        Me.cbTipoMovimiento.SelectedItem = Nothing
        Me.cbTipoMovimiento.Size = New System.Drawing.Size(98, 20)
        Me.cbTipoMovimiento.TabIndex = 9
        Me.cbTipoMovimiento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbTipoMovimiento
        '
        Me.gbTipoMovimiento.Controls.Add(Me.cbTipoMovimiento)
        Me.gbTipoMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoMovimiento.Location = New System.Drawing.Point(332, 1)
        Me.gbTipoMovimiento.Name = "gbTipoMovimiento"
        Me.gbTipoMovimiento.Size = New System.Drawing.Size(112, 39)
        Me.gbTipoMovimiento.TabIndex = 10
        Me.gbTipoMovimiento.Text = "Tipo Movimiento"
        Me.gbTipoMovimiento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbDocumento
        '
        Me.gbDocumento.Controls.Add(Me.cbDocumento)
        Me.gbDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDocumento.Location = New System.Drawing.Point(169, 155)
        Me.gbDocumento.Name = "gbDocumento"
        Me.gbDocumento.Size = New System.Drawing.Size(317, 41)
        Me.gbDocumento.TabIndex = 11
        Me.gbDocumento.Text = "Documento"
        Me.gbDocumento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbDocumento
        '
        Me.cbDocumento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbDocumento_DesignTimeLayout.LayoutString = resources.GetString("cbDocumento_DesignTimeLayout.LayoutString")
        Me.cbDocumento.DesignTimeLayout = cbDocumento_DesignTimeLayout
        Me.cbDocumento.Location = New System.Drawing.Point(7, 16)
        Me.cbDocumento.Name = "cbDocumento"
        Me.cbDocumento.SelectedIndex = -1
        Me.cbDocumento.SelectedItem = Nothing
        Me.cbDocumento.Size = New System.Drawing.Size(304, 20)
        Me.cbDocumento.TabIndex = 9
        Me.cbDocumento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbMotivos
        '
        Me.gbMotivos.Controls.Add(Me.cbMotivo)
        Me.gbMotivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMotivos.Location = New System.Drawing.Point(487, 155)
        Me.gbMotivos.Name = "gbMotivos"
        Me.gbMotivos.Size = New System.Drawing.Size(150, 41)
        Me.gbMotivos.TabIndex = 12
        Me.gbMotivos.Text = "Motivos"
        Me.gbMotivos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbMotivo
        '
        Me.cbMotivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbMotivo_DesignTimeLayout.LayoutString = resources.GetString("cbMotivo_DesignTimeLayout.LayoutString")
        Me.cbMotivo.DesignTimeLayout = cbMotivo_DesignTimeLayout
        Me.cbMotivo.Location = New System.Drawing.Point(7, 16)
        Me.cbMotivo.Name = "cbMotivo"
        Me.cbMotivo.SelectedIndex = -1
        Me.cbMotivo.SelectedItem = Nothing
        Me.cbMotivo.Size = New System.Drawing.Size(137, 20)
        Me.cbMotivo.TabIndex = 9
        Me.cbMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbArea
        '
        Me.gbArea.Controls.Add(Me.cbArea)
        Me.gbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbArea.Location = New System.Drawing.Point(171, 341)
        Me.gbArea.Name = "gbArea"
        Me.gbArea.Size = New System.Drawing.Size(184, 40)
        Me.gbArea.TabIndex = 13
        Me.gbArea.Text = "Area"
        Me.gbArea.Visible = False
        Me.gbArea.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbArea
        '
        Me.cbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbArea_DesignTimeLayout.LayoutString = resources.GetString("cbArea_DesignTimeLayout.LayoutString")
        Me.cbArea.DesignTimeLayout = cbArea_DesignTimeLayout
        Me.cbArea.Location = New System.Drawing.Point(7, 15)
        Me.cbArea.Name = "cbArea"
        Me.cbArea.SelectedIndex = -1
        Me.cbArea.SelectedItem = Nothing
        Me.cbArea.Size = New System.Drawing.Size(172, 20)
        Me.cbArea.TabIndex = 9
        Me.cbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbNumJob
        '
        Me.gbNumJob.Controls.Add(Me.txtNumJob)
        Me.gbNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbNumJob.Location = New System.Drawing.Point(371, 340)
        Me.gbNumJob.Name = "gbNumJob"
        Me.gbNumJob.Size = New System.Drawing.Size(103, 40)
        Me.gbNumJob.TabIndex = 14
        Me.gbNumJob.Text = "Job"
        Me.gbNumJob.Visible = False
        Me.gbNumJob.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNumJob
        '
        Me.txtNumJob.Location = New System.Drawing.Point(9, 15)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(84, 20)
        Me.txtNumJob.TabIndex = 0
        '
        'gbDestino
        '
        Me.gbDestino.Controls.Add(Me.cbAlmacenDestino)
        Me.gbDestino.Controls.Add(Me.cbOficinaDestino)
        Me.gbDestino.Controls.Add(Me.Label5)
        Me.gbDestino.Controls.Add(Me.Label6)
        Me.gbDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDestino.Location = New System.Drawing.Point(169, 198)
        Me.gbDestino.Name = "gbDestino"
        Me.gbDestino.Size = New System.Drawing.Size(428, 62)
        Me.gbDestino.TabIndex = 15
        Me.gbDestino.Text = "Almacen Destino"
        Me.gbDestino.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbAlmacenDestino
        '
        Me.cbAlmacenDestino.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbAlmacenDestino_DesignTimeLayout.LayoutString = resources.GetString("cbAlmacenDestino_DesignTimeLayout.LayoutString")
        Me.cbAlmacenDestino.DesignTimeLayout = cbAlmacenDestino_DesignTimeLayout
        Me.cbAlmacenDestino.Location = New System.Drawing.Point(66, 37)
        Me.cbAlmacenDestino.Name = "cbAlmacenDestino"
        Me.cbAlmacenDestino.SelectedIndex = -1
        Me.cbAlmacenDestino.SelectedItem = Nothing
        Me.cbAlmacenDestino.Size = New System.Drawing.Size(356, 20)
        Me.cbAlmacenDestino.TabIndex = 3
        Me.cbAlmacenDestino.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbOficinaDestino
        '
        Me.cbOficinaDestino.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbOficinaDestino_DesignTimeLayout.LayoutString = resources.GetString("cbOficinaDestino_DesignTimeLayout.LayoutString")
        Me.cbOficinaDestino.DesignTimeLayout = cbOficinaDestino_DesignTimeLayout
        Me.cbOficinaDestino.Location = New System.Drawing.Point(66, 15)
        Me.cbOficinaDestino.Name = "cbOficinaDestino"
        Me.cbOficinaDestino.SelectedIndex = -1
        Me.cbOficinaDestino.SelectedItem = Nothing
        Me.cbOficinaDestino.Size = New System.Drawing.Size(161, 20)
        Me.cbOficinaDestino.TabIndex = 2
        Me.cbOficinaDestino.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Almacen :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Oficina :"
        '
        'UiGroupBox11
        '
        Me.UiGroupBox11.Controls.Add(Me.rbTotalizado)
        Me.UiGroupBox11.Controls.Add(Me.rbDetalle)
        Me.UiGroupBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox11.Location = New System.Drawing.Point(169, 1)
        Me.UiGroupBox11.Name = "UiGroupBox11"
        Me.UiGroupBox11.Size = New System.Drawing.Size(159, 39)
        Me.UiGroupBox11.TabIndex = 16
        Me.UiGroupBox11.Text = "Tipo de Reporte"
        Me.UiGroupBox11.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTotalizado
        '
        Me.rbTotalizado.Location = New System.Drawing.Point(75, 17)
        Me.rbTotalizado.Name = "rbTotalizado"
        Me.rbTotalizado.Size = New System.Drawing.Size(77, 13)
        Me.rbTotalizado.TabIndex = 1
        Me.rbTotalizado.Text = "Totalizado"
        Me.rbTotalizado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbDetalle
        '
        Me.rbDetalle.Checked = True
        Me.rbDetalle.Location = New System.Drawing.Point(6, 17)
        Me.rbDetalle.Name = "rbDetalle"
        Me.rbDetalle.Size = New System.Drawing.Size(63, 13)
        Me.rbDetalle.TabIndex = 0
        Me.rbDetalle.TabStop = True
        Me.rbDetalle.Text = "Detalle"
        Me.rbDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(297, 385)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(84, 25)
        Me.btnAceptar.TabIndex = 17
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(418, 385)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(84, 25)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.Controls.Add(Me.txtCliente)
        Me.UiGroupBox6.Controls.Add(Me.rbBuscarCliente)
        Me.UiGroupBox6.Controls.Add(Me.Label12)
        Me.UiGroupBox6.Controls.Add(Me.btnBuscarCliente)
        Me.UiGroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox6.Location = New System.Drawing.Point(171, 261)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(465, 75)
        Me.UiGroupBox6.TabIndex = 106
        Me.UiGroupBox6.Text = "Buscar Cliente"
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(53, 41)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(380, 20)
        Me.txtCliente.TabIndex = 14
        '
        'rbBuscarCliente
        '
        Me.rbBuscarCliente.AutoSize = True
        Me.rbBuscarCliente.Checked = True
        Me.rbBuscarCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbBuscarCliente.Location = New System.Drawing.Point(118, 18)
        Me.rbBuscarCliente.Name = "rbBuscarCliente"
        Me.rbBuscarCliente.Size = New System.Drawing.Size(98, 17)
        Me.rbBuscarCliente.TabIndex = 13
        Me.rbBuscarCliente.Text = "Todo Cliente"
        Me.rbBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 90
        Me.Label12.Text = "Cliente:"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(434, 40)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 15
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'frmDiarioAlmacen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(642, 420)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox11)
        Me.Controls.Add(Me.gbDestino)
        Me.Controls.Add(Me.gbNumJob)
        Me.Controls.Add(Me.gbArea)
        Me.Controls.Add(Me.gbMotivos)
        Me.Controls.Add(Me.gbDocumento)
        Me.Controls.Add(Me.gbTipoMovimiento)
        Me.Controls.Add(Me.ExplorerBar1)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gpAlmacenes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiarioAlmacen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Diario de Almacen"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpAlmacenes.ResumeLayout(False)
        Me.gpAlmacenes.PerformLayout()
        CType(Me.cbAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.ExplorerBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExplorerBar1.ResumeLayout(False)
        CType(Me.gbFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFacturacion.ResumeLayout(False)
        CType(Me.gbFacturado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFacturado.ResumeLayout(False)
        CType(Me.gbComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbComprobante.ResumeLayout(False)
        CType(Me.gbCondicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCondicion.ResumeLayout(False)
        CType(Me.gbCondicionFact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCondicionFact.ResumeLayout(False)
        CType(Me.cbTipoMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbTipoMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoMovimiento.ResumeLayout(False)
        Me.gbTipoMovimiento.PerformLayout()
        CType(Me.gbDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDocumento.ResumeLayout(False)
        Me.gbDocumento.PerformLayout()
        CType(Me.cbDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbMotivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMotivos.ResumeLayout(False)
        Me.gbMotivos.PerformLayout()
        CType(Me.cbMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbArea.ResumeLayout(False)
        Me.gbArea.PerformLayout()
        CType(Me.cbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbNumJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNumJob.ResumeLayout(False)
        Me.gbNumJob.PerformLayout()
        CType(Me.gbDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDestino.ResumeLayout(False)
        Me.gbDestino.PerformLayout()
        CType(Me.cbAlmacenDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOficinaDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox11.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gpAlmacenes As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbAlmacen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficina As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ExplorerBar1 As Janus.Windows.ExplorerBar.ExplorerBar
    Friend WithEvents cbTipoMovimiento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbTipoMovimiento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbNumJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbArea As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbMotivos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbMotivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbDocumento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbDocumento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents gbDestino As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbAlmacenDestino As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbOficinaDestino As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbComprobante As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbNota As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbBoleta As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbFactura As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbCondicion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbContado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbCredito As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbFacturacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox11 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbDetalle As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbTotalizado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents gbFacturado As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbNoFacturado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbFacturado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbCondicionFact As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbCredito1 As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbTodos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbContado1 As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents rbBuscarCliente As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
End Class
