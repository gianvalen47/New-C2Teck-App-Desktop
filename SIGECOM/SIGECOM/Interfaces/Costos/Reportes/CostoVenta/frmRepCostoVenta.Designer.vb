<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCostoVenta
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
        Dim cbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodRub_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbVendedor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMot_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCostoVenta))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbCliente = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.rbBuscarCliente = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbDetalle = New System.Windows.Forms.RadioButton()
        Me.rbAcumulado = New System.Windows.Forms.RadioButton()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbCosVentaGer = New System.Windows.Forms.RadioButton()
        Me.rbCosvsVal = New System.Windows.Forms.RadioButton()
        Me.rbCosVenta = New System.Windows.Forms.RadioButton()
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbMercaderia = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbMercaderia = New System.Windows.Forms.CheckBox()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.gbVendedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbVendedor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodMot = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbMotivo = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbRubro = New System.Windows.Forms.CheckBox()
        Me.gbRubro = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvRubro = New Janus.Windows.GridEX.GridEX()
        Me.gbImprimir = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbPantalla = New System.Windows.Forms.RadioButton()
        Me.rbExportExcel = New System.Windows.Forms.RadioButton()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCliente.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbMercaderia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMercaderia.SuspendLayout()
        CType(Me.gbVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbVendedor.SuspendLayout()
        CType(Me.cmbVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMotivo.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.gbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRubro.SuspendLayout()
        CType(Me.dgvRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbImprimir.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label6.Location = New System.Drawing.Point(253, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 16)
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
        Me.cbFecFinal.Location = New System.Drawing.Point(289, 16)
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
        Me.cbFecInicio.Location = New System.Drawing.Point(122, 16)
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
        Me.Label1.Location = New System.Drawing.Point(13, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = " Fechas Del : "
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(88, 42)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(152, 20)
        Me.cmbOficinas.TabIndex = 3
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Oficina:"
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(13, 71)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(72, 16)
        Me.lblAlmacen.TabIndex = 107
        Me.lblAlmacen.Text = "Almacén:"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(88, 68)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(152, 20)
        Me.cmbIdLocacion.TabIndex = 4
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbCodMon
        '
        Me.cbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cbCodMon_DesignTimeLayout.LayoutString")
        Me.cbCodMon.DesignTimeLayout = cbCodMon_DesignTimeLayout
        Me.cbCodMon.Location = New System.Drawing.Point(326, 160)
        Me.cbCodMon.Name = "cbCodMon"
        Me.cbCodMon.SelectedIndex = -1
        Me.cbCodMon.SelectedItem = Nothing
        Me.cbCodMon.Size = New System.Drawing.Size(53, 20)
        Me.cbCodMon.TabIndex = 5
        Me.cbCodMon.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbCliente
        '
        Me.gbCliente.Controls.Add(Me.txtCliente)
        Me.gbCliente.Controls.Add(Me.rbBuscarCliente)
        Me.gbCliente.Controls.Add(Me.Label12)
        Me.gbCliente.Controls.Add(Me.btnBuscarCliente)
        Me.gbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCliente.Location = New System.Drawing.Point(10, 332)
        Me.gbCliente.Name = "gbCliente"
        Me.gbCliente.Size = New System.Drawing.Size(313, 63)
        Me.gbCliente.TabIndex = 110
        Me.gbCliente.Text = "Buscar Cliente"
        Me.gbCliente.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(68, 33)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(207, 20)
        Me.txtCliente.TabIndex = 14
        '
        'rbBuscarCliente
        '
        Me.rbBuscarCliente.AutoSize = True
        Me.rbBuscarCliente.Checked = True
        Me.rbBuscarCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbBuscarCliente.Location = New System.Drawing.Point(143, 14)
        Me.rbBuscarCliente.Name = "rbBuscarCliente"
        Me.rbBuscarCliente.Size = New System.Drawing.Size(98, 17)
        Me.rbBuscarCliente.TabIndex = 13
        Me.rbBuscarCliente.TabStop = False
        Me.rbBuscarCliente.Text = "Todo Cliente"
        Me.rbBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 15)
        Me.Label12.TabIndex = 90
        Me.Label12.Text = "Cliente:"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(282, 31)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 15
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(278, 471)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 28)
        Me.btnCancelar.TabIndex = 112
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(193, 471)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 28)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Almacén:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Oficina:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(251, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Moneda :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.rbDetalle)
        Me.UiGroupBox2.Controls.Add(Me.rbAcumulado)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(270, 56)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(125, 71)
        Me.UiGroupBox2.TabIndex = 113
        Me.UiGroupBox2.Text = "Formato"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbDetalle
        '
        Me.rbDetalle.AutoSize = True
        Me.rbDetalle.Location = New System.Drawing.Point(22, 42)
        Me.rbDetalle.Name = "rbDetalle"
        Me.rbDetalle.Size = New System.Drawing.Size(65, 17)
        Me.rbDetalle.TabIndex = 1
        Me.rbDetalle.Text = "Detalle"
        Me.rbDetalle.UseVisualStyleBackColor = True
        '
        'rbAcumulado
        '
        Me.rbAcumulado.AutoSize = True
        Me.rbAcumulado.Checked = True
        Me.rbAcumulado.Location = New System.Drawing.Point(22, 21)
        Me.rbAcumulado.Name = "rbAcumulado"
        Me.rbAcumulado.Size = New System.Drawing.Size(87, 17)
        Me.rbAcumulado.TabIndex = 0
        Me.rbAcumulado.TabStop = True
        Me.rbAcumulado.Text = "Acumulado"
        Me.rbAcumulado.UseVisualStyleBackColor = True
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.rbCosVentaGer)
        Me.UiGroupBox3.Controls.Add(Me.rbCosvsVal)
        Me.UiGroupBox3.Controls.Add(Me.rbCosVenta)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(333, 280)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(192, 76)
        Me.UiGroupBox3.TabIndex = 114
        Me.UiGroupBox3.Text = "Reporte"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbCosVentaGer
        '
        Me.rbCosVentaGer.AutoSize = True
        Me.rbCosVentaGer.Location = New System.Drawing.Point(12, 53)
        Me.rbCosVentaGer.Name = "rbCosVentaGer"
        Me.rbCosVentaGer.Size = New System.Drawing.Size(152, 17)
        Me.rbCosVentaGer.TabIndex = 2
        Me.rbCosVentaGer.Text = "Costo Venta Gerencial"
        Me.rbCosVentaGer.UseVisualStyleBackColor = True
        '
        'rbCosvsVal
        '
        Me.rbCosvsVal.AutoSize = True
        Me.rbCosvsVal.Location = New System.Drawing.Point(12, 34)
        Me.rbCosvsVal.Name = "rbCosvsVal"
        Me.rbCosvsVal.Size = New System.Drawing.Size(167, 17)
        Me.rbCosvsVal.TabIndex = 1
        Me.rbCosvsVal.Text = "Cos. Venta vs Val. Venta"
        Me.rbCosvsVal.UseVisualStyleBackColor = True
        '
        'rbCosVenta
        '
        Me.rbCosVenta.AutoSize = True
        Me.rbCosVenta.Checked = True
        Me.rbCosVenta.Location = New System.Drawing.Point(12, 15)
        Me.rbCosVenta.Name = "rbCosVenta"
        Me.rbCosVenta.Size = New System.Drawing.Size(173, 17)
        Me.rbCosVenta.TabIndex = 0
        Me.rbCosVenta.TabStop = True
        Me.rbCosVenta.Text = "Costo Venta de Inventario"
        Me.rbCosVenta.UseVisualStyleBackColor = True
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Location = New System.Drawing.Point(88, 94)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(138, 20)
        Me.cmbCodRub.TabIndex = 115
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 16)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "Rubro:"
        '
        'gbMercaderia
        '
        Me.gbMercaderia.Controls.Add(Me.rbMercaderia)
        Me.gbMercaderia.Controls.Add(Me.txtCodMer)
        Me.gbMercaderia.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbMercaderia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMercaderia.Location = New System.Drawing.Point(244, 198)
        Me.gbMercaderia.Name = "gbMercaderia"
        Me.gbMercaderia.Size = New System.Drawing.Size(194, 76)
        Me.gbMercaderia.TabIndex = 117
        Me.gbMercaderia.Text = "Buscar Mercadería"
        Me.gbMercaderia.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbMercaderia
        '
        Me.rbMercaderia.AutoSize = True
        Me.rbMercaderia.Checked = True
        Me.rbMercaderia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbMercaderia.Location = New System.Drawing.Point(15, 21)
        Me.rbMercaderia.Name = "rbMercaderia"
        Me.rbMercaderia.Size = New System.Drawing.Size(124, 17)
        Me.rbMercaderia.TabIndex = 17
        Me.rbMercaderia.Text = "Toda Mercadería"
        Me.rbMercaderia.UseVisualStyleBackColor = True
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Location = New System.Drawing.Point(11, 43)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(147, 20)
        Me.txtCodMer.TabIndex = 19
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(159, 42)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderia.TabIndex = 21
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'gbVendedor
        '
        Me.gbVendedor.Controls.Add(Me.Label8)
        Me.gbVendedor.Controls.Add(Me.cmbVendedor)
        Me.gbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbVendedor.Location = New System.Drawing.Point(10, 398)
        Me.gbVendedor.Name = "gbVendedor"
        Me.gbVendedor.Size = New System.Drawing.Size(313, 50)
        Me.gbVendedor.TabIndex = 118
        Me.gbVendedor.Text = "Vendedor"
        Me.gbVendedor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 15)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Vendedor :"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbVendedor_DesignTimeLayout.LayoutString = resources.GetString("cmbVendedor_DesignTimeLayout.LayoutString")
        Me.cmbVendedor.DesignTimeLayout = cmbVendedor_DesignTimeLayout
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.Location = New System.Drawing.Point(94, 19)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.SelectedIndex = -1
        Me.cmbVendedor.SelectedItem = Nothing
        Me.cmbVendedor.SettingsKey = "cmbCodMot"
        Me.cmbVendedor.Size = New System.Drawing.Size(209, 20)
        Me.cmbVendedor.TabIndex = 12
        Me.cmbVendedor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodMot
        '
        Me.cmbCodMot.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMot_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMot_DesignTimeLayout.LayoutString")
        Me.cmbCodMot.DesignTimeLayout = cmbCodMot_DesignTimeLayout
        Me.cmbCodMot.FlatBorderColor = System.Drawing.SystemColors.Desktop
        Me.cmbCodMot.Location = New System.Drawing.Point(62, 18)
        Me.cmbCodMot.Name = "cmbCodMot"
        Me.cmbCodMot.SelectedIndex = -1
        Me.cmbCodMot.SelectedItem = Nothing
        Me.cmbCodMot.Size = New System.Drawing.Size(243, 20)
        Me.cmbCodMot.TabIndex = 120
        Me.cmbCodMot.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 15)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Motivo :"
        '
        'gbMotivo
        '
        Me.gbMotivo.Controls.Add(Me.cmbCodMot)
        Me.gbMotivo.Controls.Add(Me.Label9)
        Me.gbMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMotivo.Location = New System.Drawing.Point(10, 280)
        Me.gbMotivo.Name = "gbMotivo"
        Me.gbMotivo.Size = New System.Drawing.Size(313, 50)
        Me.gbMotivo.TabIndex = 121
        Me.gbMotivo.Text = "Motivo"
        Me.gbMotivo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.cbRubro)
        Me.UiGroupBox4.Controls.Add(Me.gbRubro)
        Me.UiGroupBox4.Controls.Add(Me.gbImprimir)
        Me.UiGroupBox4.Controls.Add(Me.Label1)
        Me.UiGroupBox4.Controls.Add(Me.gbMotivo)
        Me.UiGroupBox4.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox4.Controls.Add(Me.gbVendedor)
        Me.UiGroupBox4.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox4.Controls.Add(Me.gbMercaderia)
        Me.UiGroupBox4.Controls.Add(Me.Label6)
        Me.UiGroupBox4.Controls.Add(Me.cmbCodRub)
        Me.UiGroupBox4.Controls.Add(Me.cmbIdLocacion)
        Me.UiGroupBox4.Controls.Add(Me.Label7)
        Me.UiGroupBox4.Controls.Add(Me.lblAlmacen)
        Me.UiGroupBox4.Controls.Add(Me.UiGroupBox3)
        Me.UiGroupBox4.Controls.Add(Me.Label2)
        Me.UiGroupBox4.Controls.Add(Me.UiGroupBox2)
        Me.UiGroupBox4.Controls.Add(Me.Label3)
        Me.UiGroupBox4.Controls.Add(Me.cmbOficinas)
        Me.UiGroupBox4.Controls.Add(Me.Label4)
        Me.UiGroupBox4.Controls.Add(Me.gbCliente)
        Me.UiGroupBox4.Controls.Add(Me.cbCodMon)
        Me.UiGroupBox4.Controls.Add(Me.Label5)
        Me.UiGroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox4.Location = New System.Drawing.Point(8, 7)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(540, 457)
        Me.UiGroupBox4.TabIndex = 122
        Me.UiGroupBox4.Text = "Datos del Reporte"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbRubro
        '
        Me.cbRubro.AutoSize = True
        Me.cbRubro.Location = New System.Drawing.Point(88, 122)
        Me.cbRubro.Name = "cbRubro"
        Me.cbRubro.Size = New System.Drawing.Size(137, 17)
        Me.cbRubro.TabIndex = 204
        Me.cbRubro.Text = "Seleccionar Rubros"
        Me.cbRubro.UseVisualStyleBackColor = True
        '
        'gbRubro
        '
        Me.gbRubro.Controls.Add(Me.dgvRubro)
        Me.gbRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRubro.Location = New System.Drawing.Point(10, 137)
        Me.gbRubro.Name = "gbRubro"
        Me.gbRubro.Size = New System.Drawing.Size(220, 137)
        Me.gbRubro.TabIndex = 203
        Me.gbRubro.Visible = False
        Me.gbRubro.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvRubro
        '
        dgvRubro_DesignTimeLayout.LayoutString = resources.GetString("dgvRubro_DesignTimeLayout.LayoutString")
        Me.dgvRubro.DesignTimeLayout = dgvRubro_DesignTimeLayout
        Me.dgvRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvRubro.GroupByBoxVisible = False
        Me.dgvRubro.Location = New System.Drawing.Point(8, 15)
        Me.dgvRubro.Name = "dgvRubro"
        Me.dgvRubro.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvRubro.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvRubro.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvRubro.Size = New System.Drawing.Size(204, 116)
        Me.dgvRubro.TabIndex = 190
        Me.dgvRubro.TabStop = False
        Me.dgvRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gbImprimir
        '
        Me.gbImprimir.Controls.Add(Me.rbPantalla)
        Me.gbImprimir.Controls.Add(Me.rbExportExcel)
        Me.gbImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbImprimir.Location = New System.Drawing.Point(372, 362)
        Me.gbImprimir.Name = "gbImprimir"
        Me.gbImprimir.Size = New System.Drawing.Size(109, 86)
        Me.gbImprimir.TabIndex = 201
        Me.gbImprimir.Text = "Exportar"
        Me.gbImprimir.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbPantalla
        '
        Me.rbPantalla.AutoSize = True
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(18, 28)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(71, 17)
        Me.rbPantalla.TabIndex = 48
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.UseVisualStyleBackColor = True
        '
        'rbExportExcel
        '
        Me.rbExportExcel.AutoSize = True
        Me.rbExportExcel.Location = New System.Drawing.Point(18, 51)
        Me.rbExportExcel.Name = "rbExportExcel"
        Me.rbExportExcel.Size = New System.Drawing.Size(56, 17)
        Me.rbExportExcel.TabIndex = 47
        Me.rbExportExcel.Text = "Excel"
        Me.rbExportExcel.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(24, 471)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(44, 27)
        Me.DataGridView2.TabIndex = 193
        Me.DataGridView2.Visible = False
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(74, 471)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(44, 27)
        Me.DataGridView3.TabIndex = 194
        Me.DataGridView3.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(363, 473)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(61, 26)
        Me.DataGridView1.TabIndex = 202
        Me.DataGridView1.Visible = False
        '
        'frmRepCostoVenta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(555, 507)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepCostoVenta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Costo de Venta"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCliente.ResumeLayout(False)
        Me.gbCliente.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbMercaderia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMercaderia.ResumeLayout(False)
        Me.gbMercaderia.PerformLayout()
        CType(Me.gbVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbVendedor.ResumeLayout(False)
        Me.gbVendedor.PerformLayout()
        CType(Me.cmbVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMotivo.ResumeLayout(False)
        Me.gbMotivo.PerformLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.gbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRubro.ResumeLayout(False)
        CType(Me.dgvRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbImprimir.ResumeLayout(False)
        Me.gbImprimir.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents cbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbCliente As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents rbBuscarCliente As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbCosvsVal As System.Windows.Forms.RadioButton
    Friend WithEvents rbCosVenta As System.Windows.Forms.RadioButton
    Friend WithEvents rbDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents rbAcumulado As System.Windows.Forms.RadioButton
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbMercaderia As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbMercaderia As System.Windows.Forms.CheckBox
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents gbVendedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbVendedor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbMotivo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbCodMot As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents rbCosVentaGer As System.Windows.Forms.RadioButton
    Friend WithEvents gbImprimir As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rbExportExcel As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cbRubro As CheckBox
    Friend WithEvents gbRubro As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvRubro As Janus.Windows.GridEX.GridEX
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
End Class
