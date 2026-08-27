<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaldoBancos
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaldoBancos))
        Dim dgvBancos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgvCuentas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgvDatosFin_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgvDatosFin_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column22.Image")
        Dim dgvDatosFin_DesignTimeLayout_Reference_1 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column23.Image")
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim dgVentasAlmacen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbAlmacenva_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbOficinava_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbAlmacenvm_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbOficinavm_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgVentasMateriales_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbIdProveedorps_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgPedidosSemana_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbAlmacenps_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbOficinaps_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgPedidosFechaLlegada_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbIdProveedorpf_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbAlmacenpf_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbOficinapf_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbSemaforo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbSupervisor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgDetalleServicios_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX
        Me.TabCuentas = New Janus.Windows.UI.Tab.UITab
        Me.tabBancos = New Janus.Windows.UI.Tab.UITabPage
        Me.dgvBancos = New Janus.Windows.GridEX.GridEX
        Me.tbLocaciones = New Janus.Windows.UI.Tab.UITabPage
        Me.txtBanco = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgvCuentas = New Janus.Windows.GridEX.GridEX
        Me.TabDetalles = New Janus.Windows.UI.Tab.UITabPage
        Me.dgvDatosFin = New Janus.Windows.GridEX.GridEX
        Me.txtMoneda = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtBanco2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnExaminar = New System.Windows.Forms.Button
        Me.txtDirFile = New System.Windows.Forms.TextBox
        Me.dgvDatosFin2 = New System.Windows.Forms.DataGridView
        Me.IdSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodBan2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumCta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FecVal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cargo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cargo1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Abono = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Abono1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SucAge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumOpe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Hora = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.utc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Estado = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.dventasAlmacenes = New System.Windows.Forms.DataGridView
        Me.GroupBox16 = New System.Windows.Forms.GroupBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.cbFecFinva = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbFecIniciova = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.btnExcelva = New System.Windows.Forms.Button
        Me.btnBuscarva = New System.Windows.Forms.Button
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.txtIdMarcava = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtIdMercaderiava = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.dgVentasAlmacen = New Janus.Windows.GridEX.GridEX
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbAlmacenva = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbOficinava = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label14 = New System.Windows.Forms.Label
        Me.dvenntasMateriales = New System.Windows.Forms.DataGridView
        Me.GroupBox18 = New System.Windows.Forms.GroupBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.cbFecFinvm = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbFecIniciovm = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.GroupBox17 = New System.Windows.Forms.GroupBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.cmbAlmacenvm = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbOficinavm = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label32 = New System.Windows.Forms.Label
        Me.btnExcelvm = New System.Windows.Forms.Button
        Me.btnBuscarvm = New System.Windows.Forms.Button
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.txtIdMarcavm = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtIdMercaderiavm = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.dgVentasMateriales = New Janus.Windows.GridEX.GridEX
        Me.dpedidosSemana = New System.Windows.Forms.DataGridView
        Me.btnExcelps = New System.Windows.Forms.Button
        Me.btnBuscarps = New System.Windows.Forms.Button
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.txtNumDoc = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.cmbIdProveedorps = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtIdMarcaps = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtIdMercaderiaps = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cbFecFinps = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbFecIniciops = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.dgPedidosSemana = New Janus.Windows.GridEX.GridEX
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmbAlmacenps = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbOficinaps = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label23 = New System.Windows.Forms.Label
        Me.dpedidosFechaLlegada = New System.Windows.Forms.DataGridView
        Me.dgPedidosFechaLlegada = New Janus.Windows.GridEX.GridEX
        Me.btnExcelpf = New System.Windows.Forms.Button
        Me.btnBuscarpf = New System.Windows.Forms.Button
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.txtNumDocpf = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.cmbIdProveedorpf = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtIdMarcapf = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtIdMercaderiapf = New Janus.Windows.GridEX.EditControls.EditBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.cbFecFinpf = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbFecIniciopf = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.cmbAlmacenpf = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbOficinapf = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label44 = New System.Windows.Forms.Label
        Me.btnPorcentaje = New System.Windows.Forms.Button
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.txtVerde = New System.Windows.Forms.TextBox
        Me.txtAmbar = New System.Windows.Forms.TextBox
        Me.txtRojo = New System.Windows.Forms.TextBox
        Me.GroupBox20 = New System.Windows.Forms.GroupBox
        Me.cmbSemaforo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label45 = New System.Windows.Forms.Label
        Me.cmbSupervisor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label50 = New System.Windows.Forms.Label
        Me.dServicios = New System.Windows.Forms.DataGridView
        Me.btnImprimirSer = New System.Windows.Forms.Button
        Me.dgDetalleServicios = New Janus.Windows.GridEX.GridEX
        Me.btnExcelSer = New System.Windows.Forms.Button
        Me.btnBuscarSer = New System.Windows.Forms.Button
        Me.GroupBox19 = New System.Windows.Forms.GroupBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.cbFecFinalSer = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbFecInicioSer = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.dgvTablero = New System.Windows.Forms.DataGridView
        Me.btnExcelTab = New System.Windows.Forms.Button
        Me.btnBuscarTab = New System.Windows.Forms.Button
        Me.gbOpciones = New System.Windows.Forms.GroupBox
        Me.rbFiltros = New System.Windows.Forms.RadioButton
        Me.rbChimbote = New System.Windows.Forms.RadioButton
        Me.rbBaterias = New System.Windows.Forms.RadioButton
        Me.rbMotores = New System.Windows.Forms.RadioButton
        Me.rbGrupElec = New System.Windows.Forms.RadioButton
        Me.rbRepConsig = New System.Windows.Forms.RadioButton
        Me.rbVenOfi = New System.Windows.Forms.RadioButton
        Me.rbManoObra = New System.Windows.Forms.RadioButton
        Me.rbRepServ = New System.Windows.Forms.RadioButton
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCuentas.SuspendLayout()
        Me.tabBancos.SuspendLayout()
        CType(Me.dgvBancos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbLocaciones.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDetalles.SuspendLayout()
        CType(Me.dgvDatosFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatosFin2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dventasAlmacenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.dgVentasAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.cmbAlmacenva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinava, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvenntasMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        CType(Me.cmbAlmacenvm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinavm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        CType(Me.dgVentasMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dpedidosSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        CType(Me.cmbIdProveedorps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox12.SuspendLayout()
        CType(Me.dgPedidosSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.cmbAlmacenps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinaps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dpedidosFechaLlegada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPedidosFechaLlegada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox15.SuspendLayout()
        CType(Me.cmbIdProveedorpf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.cmbAlmacenpf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinapf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox20.SuspendLayout()
        CType(Me.cmbSemaforo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDetalleServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox19.SuspendLayout()
        CType(Me.dgvTablero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpciones.SuspendLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(7, 471)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(48, 51)
        Me.dgvDatos.TabIndex = 204
        Me.dgvDatos.Visible = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'TabCuentas
        '
        Me.TabCuentas.Location = New System.Drawing.Point(8, 11)
        Me.TabCuentas.Name = "TabCuentas"
        Me.TabCuentas.Size = New System.Drawing.Size(1230, 555)
        Me.TabCuentas.TabIndex = 205
        Me.TabCuentas.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tabBancos, Me.tbLocaciones, Me.TabDetalles})
        Me.TabCuentas.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003
        '
        'tabBancos
        '
        Me.tabBancos.Controls.Add(Me.dgvBancos)
        Me.tabBancos.Icon = CType(resources.GetObject("tabBancos.Icon"), System.Drawing.Icon)
        Me.tabBancos.Location = New System.Drawing.Point(1, 23)
        Me.tabBancos.Name = "tabBancos"
        Me.tabBancos.Size = New System.Drawing.Size(1228, 531)
        Me.tabBancos.TabStop = True
        Me.tabBancos.Text = "Bancos - [F1]"
        '
        'dgvBancos
        '
        Me.dgvBancos.AllowCardSizing = False
        dgvBancos_DesignTimeLayout.LayoutString = resources.GetString("dgvBancos_DesignTimeLayout.LayoutString")
        Me.dgvBancos.DesignTimeLayout = dgvBancos_DesignTimeLayout
        Me.dgvBancos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvBancos.GroupByBoxVisible = False
        Me.dgvBancos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvBancos.Location = New System.Drawing.Point(312, 163)
        Me.dgvBancos.Name = "dgvBancos"
        Me.dgvBancos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvBancos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvBancos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvBancos.Size = New System.Drawing.Size(500, 229)
        Me.dgvBancos.TabIndex = 205
        Me.dgvBancos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'tbLocaciones
        '
        Me.tbLocaciones.Controls.Add(Me.txtBanco)
        Me.tbLocaciones.Controls.Add(Me.Label5)
        Me.tbLocaciones.Controls.Add(Me.dgvCuentas)
        Me.tbLocaciones.Icon = CType(resources.GetObject("tbLocaciones.Icon"), System.Drawing.Icon)
        Me.tbLocaciones.Location = New System.Drawing.Point(1, 23)
        Me.tbLocaciones.Name = "tbLocaciones"
        Me.tbLocaciones.Size = New System.Drawing.Size(1228, 531)
        Me.tbLocaciones.TabStop = True
        Me.tbLocaciones.Text = "Cuentas - [F2]"
        '
        'txtBanco
        '
        Me.txtBanco.BackColor = System.Drawing.SystemColors.Window
        Me.txtBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanco.Location = New System.Drawing.Point(434, 113)
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.ReadOnly = True
        Me.txtBanco.Size = New System.Drawing.Size(233, 20)
        Me.txtBanco.TabIndex = 208
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(375, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 207
        Me.Label5.Text = "Banco :"
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AllowCardSizing = False
        dgvCuentas_DesignTimeLayout.LayoutString = resources.GetString("dgvCuentas_DesignTimeLayout.LayoutString")
        Me.dgvCuentas.DesignTimeLayout = dgvCuentas_DesignTimeLayout
        Me.dgvCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvCuentas.GroupByBoxVisible = False
        Me.dgvCuentas.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvCuentas.Location = New System.Drawing.Point(300, 151)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCuentas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCuentas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCuentas.Size = New System.Drawing.Size(449, 229)
        Me.dgvCuentas.TabIndex = 206
        Me.dgvCuentas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'TabDetalles
        '
        Me.TabDetalles.Controls.Add(Me.dgvDatosFin)
        Me.TabDetalles.Controls.Add(Me.txtMoneda)
        Me.TabDetalles.Controls.Add(Me.Label1)
        Me.TabDetalles.Controls.Add(Me.btnImprimir)
        Me.TabDetalles.Controls.Add(Me.txtCuenta)
        Me.TabDetalles.Controls.Add(Me.Label6)
        Me.TabDetalles.Controls.Add(Me.txtBanco2)
        Me.TabDetalles.Controls.Add(Me.Label4)
        Me.TabDetalles.Controls.Add(Me.btnExaminar)
        Me.TabDetalles.Controls.Add(Me.txtDirFile)
        Me.TabDetalles.Controls.Add(Me.dgvDatos)
        Me.TabDetalles.Controls.Add(Me.dgvDatosFin2)
        Me.TabDetalles.Enabled = False
        Me.TabDetalles.Icon = CType(resources.GetObject("TabDetalles.Icon"), System.Drawing.Icon)
        Me.TabDetalles.Location = New System.Drawing.Point(1, 23)
        Me.TabDetalles.Name = "TabDetalles"
        Me.TabDetalles.Size = New System.Drawing.Size(1228, 531)
        Me.TabDetalles.TabStop = True
        Me.TabDetalles.Text = "Detalles - [F3]"
        '
        'dgvDatosFin
        '
        Me.dgvDatosFin.AllowCardSizing = False
        Me.dgvDatosFin.AlternatingColors = True
        dgvDatosFin_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatosFin_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatosFin_DesignTimeLayout_Reference_1.Instance = CType(resources.GetObject("dgvDatosFin_DesignTimeLayout_Reference_1.Instance"), Object)
        dgvDatosFin_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatosFin_DesignTimeLayout_Reference_0, dgvDatosFin_DesignTimeLayout_Reference_1})
        dgvDatosFin_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosFin_DesignTimeLayout.LayoutString")
        Me.dgvDatosFin.DesignTimeLayout = dgvDatosFin_DesignTimeLayout
        Me.dgvDatosFin.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None
        Me.dgvDatosFin.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.dgvDatosFin.FlatBorderColor = System.Drawing.SystemColors.Control
        Me.dgvDatosFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatosFin.GroupByBoxVisible = False
        Me.dgvDatosFin.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatosFin.Location = New System.Drawing.Point(7, 53)
        Me.dgvDatosFin.Name = "dgvDatosFin"
        Me.dgvDatosFin.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosFin.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosFin.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosFin.ScrollBarWidth = 17
        Me.dgvDatosFin.Size = New System.Drawing.Size(1208, 400)
        Me.dgvDatosFin.TabIndex = 219
        Me.dgvDatosFin.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtMoneda
        '
        Me.txtMoneda.BackColor = System.Drawing.SystemColors.Window
        Me.txtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.Location = New System.Drawing.Point(1054, 18)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(117, 20)
        Me.txtMoneda.TabIndex = 216
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(1002, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 215
        Me.Label1.Text = "Moneda : "
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(1120, 474)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(95, 28)
        Me.btnImprimir.TabIndex = 213
        Me.btnImprimir.Text = "      Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.SystemColors.Window
        Me.txtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(575, 18)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(142, 20)
        Me.txtCuenta.TabIndex = 212
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(523, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 211
        Me.Label6.Text = "Cuenta :"
        '
        'txtBanco2
        '
        Me.txtBanco2.BackColor = System.Drawing.SystemColors.Window
        Me.txtBanco2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanco2.Location = New System.Drawing.Point(81, 18)
        Me.txtBanco2.Name = "txtBanco2"
        Me.txtBanco2.ReadOnly = True
        Me.txtBanco2.Size = New System.Drawing.Size(198, 20)
        Me.txtBanco2.TabIndex = 210
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(34, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 209
        Me.Label4.Text = "Banco :"
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = CType(resources.GetObject("btnExaminar.Image"), System.Drawing.Image)
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.Location = New System.Drawing.Point(706, 473)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(89, 28)
        Me.btnExaminar.TabIndex = 207
        Me.btnExaminar.Text = "      Cargar"
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'txtDirFile
        '
        Me.txtDirFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtDirFile.Location = New System.Drawing.Point(427, 478)
        Me.txtDirFile.Name = "txtDirFile"
        Me.txtDirFile.ReadOnly = True
        Me.txtDirFile.Size = New System.Drawing.Size(273, 20)
        Me.txtDirFile.TabIndex = 206
        '
        'dgvDatosFin2
        '
        Me.dgvDatosFin2.AllowUserToAddRows = False
        Me.dgvDatosFin2.AllowUserToDeleteRows = False
        Me.dgvDatosFin2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatosFin2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdSaldo, Me.CodBan2, Me.NumCta, Me.Fecha, Me.FecVal, Me.Referencia, Me.Cargo, Me.Cargo1, Me.Abono, Me.Abono1, Me.Saldo, Me.SucAge, Me.NumOpe, Me.Hora, Me.Usuario, Me.utc, Me.Estado})
        Me.dgvDatosFin2.GridColor = System.Drawing.SystemColors.ButtonShadow
        Me.dgvDatosFin2.Location = New System.Drawing.Point(65, 474)
        Me.dgvDatosFin2.Name = "dgvDatosFin2"
        Me.dgvDatosFin2.ReadOnly = True
        Me.dgvDatosFin2.RowHeadersWidth = 20
        Me.dgvDatosFin2.Size = New System.Drawing.Size(26, 46)
        Me.dgvDatosFin2.TabIndex = 218
        Me.dgvDatosFin2.Visible = False
        '
        'IdSaldo
        '
        Me.IdSaldo.DataPropertyName = "IdSaldo"
        Me.IdSaldo.HeaderText = "IdSaldo"
        Me.IdSaldo.Name = "IdSaldo"
        Me.IdSaldo.ReadOnly = True
        Me.IdSaldo.Visible = False
        Me.IdSaldo.Width = 160
        '
        'CodBan2
        '
        Me.CodBan2.DataPropertyName = "CodBan"
        Me.CodBan2.HeaderText = "CodBan"
        Me.CodBan2.Name = "CodBan2"
        Me.CodBan2.ReadOnly = True
        Me.CodBan2.Visible = False
        '
        'NumCta
        '
        Me.NumCta.DataPropertyName = "NumCta"
        Me.NumCta.HeaderText = "NumCta"
        Me.NumCta.Name = "NumCta"
        Me.NumCta.ReadOnly = True
        Me.NumCta.Visible = False
        Me.NumCta.Width = 180
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle13.Format = "d"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle13
        Me.Fecha.HeaderText = "  Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Fecha.Width = 81
        '
        'FecVal
        '
        Me.FecVal.DataPropertyName = "FecVal"
        DataGridViewCellStyle14.Format = "d"
        Me.FecVal.DefaultCellStyle = DataGridViewCellStyle14
        Me.FecVal.HeaderText = "FecVal"
        Me.FecVal.Name = "FecVal"
        Me.FecVal.ReadOnly = True
        Me.FecVal.Visible = False
        Me.FecVal.Width = 82
        '
        'Referencia
        '
        Me.Referencia.DataPropertyName = "Referencia"
        Me.Referencia.HeaderText = "          Referencia"
        Me.Referencia.Name = "Referencia"
        Me.Referencia.ReadOnly = True
        Me.Referencia.Width = 180
        '
        'Cargo
        '
        Me.Cargo.DataPropertyName = "Cargo"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cargo.DefaultCellStyle = DataGridViewCellStyle15
        Me.Cargo.HeaderText = "    Cargo"
        Me.Cargo.Name = "Cargo"
        Me.Cargo.ReadOnly = True
        Me.Cargo.Visible = False
        Me.Cargo.Width = 92
        '
        'Cargo1
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.Cargo1.DefaultCellStyle = DataGridViewCellStyle16
        Me.Cargo1.HeaderText = "     Cargo"
        Me.Cargo1.Name = "Cargo1"
        Me.Cargo1.ReadOnly = True
        Me.Cargo1.Width = 92
        '
        'Abono
        '
        Me.Abono.DataPropertyName = "Abono"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.NullValue = Nothing
        Me.Abono.DefaultCellStyle = DataGridViewCellStyle17
        Me.Abono.HeaderText = "     Abono"
        Me.Abono.Name = "Abono"
        Me.Abono.ReadOnly = True
        Me.Abono.Visible = False
        Me.Abono.Width = 92
        '
        'Abono1
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.Abono1.DefaultCellStyle = DataGridViewCellStyle18
        Me.Abono1.HeaderText = "     Abono"
        Me.Abono1.Name = "Abono1"
        Me.Abono1.ReadOnly = True
        Me.Abono1.Width = 92
        '
        'Saldo
        '
        Me.Saldo.DataPropertyName = "Saldo"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Saldo.DefaultCellStyle = DataGridViewCellStyle19
        Me.Saldo.HeaderText = "     Saldo"
        Me.Saldo.Name = "Saldo"
        Me.Saldo.ReadOnly = True
        Me.Saldo.Width = 102
        '
        'SucAge
        '
        Me.SucAge.DataPropertyName = "SucAge"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SucAge.DefaultCellStyle = DataGridViewCellStyle20
        Me.SucAge.HeaderText = "Sucursal Agencia"
        Me.SucAge.Name = "SucAge"
        Me.SucAge.ReadOnly = True
        Me.SucAge.Width = 74
        '
        'NumOpe
        '
        Me.NumOpe.DataPropertyName = "NumOpe"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NumOpe.DefaultCellStyle = DataGridViewCellStyle21
        Me.NumOpe.HeaderText = "Num. Operac."
        Me.NumOpe.Name = "NumOpe"
        Me.NumOpe.ReadOnly = True
        Me.NumOpe.Width = 69
        '
        'Hora
        '
        Me.Hora.DataPropertyName = "Hora"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Hora.DefaultCellStyle = DataGridViewCellStyle22
        Me.Hora.HeaderText = "Hora"
        Me.Hora.Name = "Hora"
        Me.Hora.ReadOnly = True
        Me.Hora.Width = 64
        '
        'Usuario
        '
        Me.Usuario.DataPropertyName = "Usuario"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Usuario.DefaultCellStyle = DataGridViewCellStyle23
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        Me.Usuario.Width = 65
        '
        'utc
        '
        Me.utc.DataPropertyName = "utc"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.utc.DefaultCellStyle = DataGridViewCellStyle24
        Me.utc.HeaderText = "Utc"
        Me.utc.Name = "utc"
        Me.utc.ReadOnly = True
        Me.utc.Width = 50
        '
        'Estado
        '
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Est"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Visible = False
        Me.Estado.Width = 40
        '
        'dventasAlmacenes
        '
        Me.dventasAlmacenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dventasAlmacenes.Location = New System.Drawing.Point(546, 113)
        Me.dventasAlmacenes.Name = "dventasAlmacenes"
        Me.dventasAlmacenes.Size = New System.Drawing.Size(40, 23)
        Me.dventasAlmacenes.TabIndex = 127
        Me.dventasAlmacenes.Visible = False
        '
        'GroupBox16
        '
        Me.GroupBox16.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox16.Controls.Add(Me.Label25)
        Me.GroupBox16.Controls.Add(Me.Label27)
        Me.GroupBox16.Controls.Add(Me.cbFecFinva)
        Me.GroupBox16.Controls.Add(Me.cbFecIniciova)
        Me.GroupBox16.Location = New System.Drawing.Point(3, 8)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(335, 48)
        Me.GroupBox16.TabIndex = 126
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "FECHAS"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(190, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(26, 13)
        Me.Label25.TabIndex = 117
        Me.Label25.Text = "Al :"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(27, 24)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 117
        Me.Label27.Text = "Del :"
        '
        'cbFecFinva
        '
        '
        '
        '
        Me.cbFecFinva.DropDownCalendar.Name = ""
        Me.cbFecFinva.DropDownCalendar.Visible = False
        Me.cbFecFinva.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinva.Location = New System.Drawing.Point(218, 20)
        Me.cbFecFinva.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinva.Name = "cbFecFinva"
        Me.cbFecFinva.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinva.TabIndex = 111
        Me.cbFecFinva.Value = New Date(2012, 8, 1, 0, 0, 0, 0)
        Me.cbFecFinva.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecIniciova
        '
        '
        '
        '
        Me.cbFecIniciova.DropDownCalendar.Name = ""
        Me.cbFecIniciova.DropDownCalendar.Visible = False
        Me.cbFecIniciova.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecIniciova.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecIniciova.Location = New System.Drawing.Point(67, 20)
        Me.cbFecIniciova.MinDate = New Date(2005, 1, 1, 0, 0, 0, 0)
        Me.cbFecIniciova.Name = "cbFecIniciova"
        Me.cbFecIniciova.Size = New System.Drawing.Size(97, 20)
        Me.cbFecIniciova.TabIndex = 110
        Me.cbFecIniciova.Value = New Date(2012, 8, 1, 0, 0, 0, 0)
        Me.cbFecIniciova.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'btnExcelva
        '
        Me.btnExcelva.Image = CType(resources.GetObject("btnExcelva.Image"), System.Drawing.Image)
        Me.btnExcelva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelva.Location = New System.Drawing.Point(666, 113)
        Me.btnExcelva.Name = "btnExcelva"
        Me.btnExcelva.Size = New System.Drawing.Size(65, 23)
        Me.btnExcelva.TabIndex = 124
        Me.btnExcelva.Text = "Excel"
        Me.btnExcelva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelva.UseVisualStyleBackColor = True
        '
        'btnBuscarva
        '
        Me.btnBuscarva.Image = CType(resources.GetObject("btnBuscarva.Image"), System.Drawing.Image)
        Me.btnBuscarva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarva.Location = New System.Drawing.Point(592, 113)
        Me.btnBuscarva.Name = "btnBuscarva"
        Me.btnBuscarva.Size = New System.Drawing.Size(64, 23)
        Me.btnBuscarva.TabIndex = 123
        Me.btnBuscarva.Text = "Buscar"
        Me.btnBuscarva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarva.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox10.Controls.Add(Me.txtIdMarcava)
        Me.GroupBox10.Controls.Add(Me.Label20)
        Me.GroupBox10.Controls.Add(Me.txtIdMercaderiava)
        Me.GroupBox10.Controls.Add(Me.Label19)
        Me.GroupBox10.Location = New System.Drawing.Point(344, 7)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(431, 97)
        Me.GroupBox10.TabIndex = 122
        Me.GroupBox10.TabStop = False
        '
        'txtIdMarcava
        '
        Me.txtIdMarcava.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.txtIdMarcava.Location = New System.Drawing.Point(250, 43)
        Me.txtIdMarcava.Name = "txtIdMarcava"
        Me.txtIdMarcava.ReadOnly = True
        Me.txtIdMarcava.Size = New System.Drawing.Size(175, 20)
        Me.txtIdMarcava.TabIndex = 122
        Me.txtIdMarcava.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(201, 47)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 13)
        Me.Label20.TabIndex = 123
        Me.Label20.Text = "Marca :"
        '
        'txtIdMercaderiava
        '
        Me.txtIdMercaderiava.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.txtIdMercaderiava.Location = New System.Drawing.Point(79, 43)
        Me.txtIdMercaderiava.Name = "txtIdMercaderiava"
        Me.txtIdMercaderiava.ReadOnly = True
        Me.txtIdMercaderiava.Size = New System.Drawing.Size(116, 20)
        Me.txtIdMercaderiava.TabIndex = 120
        Me.txtIdMercaderiava.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(2, 46)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 13)
        Me.Label19.TabIndex = 121
        Me.Label19.Text = "Mercaderia :"
        '
        'dgVentasAlmacen
        '
        Me.dgVentasAlmacen.AllowCardSizing = False
        Me.dgVentasAlmacen.AllowColumnDrag = False
        Me.dgVentasAlmacen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgVentasAlmacen.AlternatingColors = True
        dgVentasAlmacen_DesignTimeLayout.LayoutString = resources.GetString("dgVentasAlmacen_DesignTimeLayout.LayoutString")
        Me.dgVentasAlmacen.DesignTimeLayout = dgVentasAlmacen_DesignTimeLayout
        Me.dgVentasAlmacen.EmptyRows = True
        Me.dgVentasAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgVentasAlmacen.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgVentasAlmacen.GroupByBoxVisible = False
        Me.dgVentasAlmacen.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgVentasAlmacen.Location = New System.Drawing.Point(11, 142)
        Me.dgVentasAlmacen.Name = "dgVentasAlmacen"
        Me.dgVentasAlmacen.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgVentasAlmacen.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgVentasAlmacen.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgVentasAlmacen.Size = New System.Drawing.Size(764, 294)
        Me.dgVentasAlmacen.TabIndex = 110
        Me.dgVentasAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Controls.Add(Me.cmbAlmacenva)
        Me.GroupBox7.Controls.Add(Me.cmbOficinava)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 54)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(335, 50)
        Me.GroupBox7.TabIndex = 68
        Me.GroupBox7.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(147, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 119
        Me.Label13.Text = "Almacén :"
        '
        'cmbAlmacenva
        '
        Me.cmbAlmacenva.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAlmacenva_DesignTimeLayout.LayoutString = resources.GetString("cmbAlmacenva_DesignTimeLayout.LayoutString")
        Me.cmbAlmacenva.DesignTimeLayout = cmbAlmacenva_DesignTimeLayout
        Me.cmbAlmacenva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAlmacenva.Location = New System.Drawing.Point(212, 19)
        Me.cmbAlmacenva.Name = "cmbAlmacenva"
        Me.cmbAlmacenva.SelectedIndex = -1
        Me.cmbAlmacenva.SelectedItem = Nothing
        Me.cmbAlmacenva.Size = New System.Drawing.Size(115, 20)
        Me.cmbAlmacenva.TabIndex = 118
        Me.cmbAlmacenva.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinava
        '
        Me.cmbOficinava.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinava_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinava_DesignTimeLayout.LayoutString")
        Me.cmbOficinava.DesignTimeLayout = cmbOficinava_DesignTimeLayout
        Me.cmbOficinava.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinava.Location = New System.Drawing.Point(56, 19)
        Me.cmbOficinava.Name = "cmbOficinava"
        Me.cmbOficinava.SelectedIndex = -1
        Me.cmbOficinava.SelectedItem = Nothing
        Me.cmbOficinava.Size = New System.Drawing.Size(90, 20)
        Me.cmbOficinava.TabIndex = 60
        Me.cmbOficinava.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(2, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 62
        Me.Label14.Text = "Oficina :"
        '
        'dvenntasMateriales
        '
        Me.dvenntasMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvenntasMateriales.Location = New System.Drawing.Point(547, 114)
        Me.dvenntasMateriales.Name = "dvenntasMateriales"
        Me.dvenntasMateriales.Size = New System.Drawing.Size(42, 23)
        Me.dvenntasMateriales.TabIndex = 129
        Me.dvenntasMateriales.Visible = False
        '
        'GroupBox18
        '
        Me.GroupBox18.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox18.Controls.Add(Me.Label33)
        Me.GroupBox18.Controls.Add(Me.Label34)
        Me.GroupBox18.Controls.Add(Me.cbFecFinvm)
        Me.GroupBox18.Controls.Add(Me.cbFecIniciovm)
        Me.GroupBox18.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(334, 48)
        Me.GroupBox18.TabIndex = 128
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "FECHAS"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(190, 24)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(26, 13)
        Me.Label33.TabIndex = 117
        Me.Label33.Text = "Al :"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(35, 24)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(34, 13)
        Me.Label34.TabIndex = 117
        Me.Label34.Text = "Del :"
        '
        'cbFecFinvm
        '
        '
        '
        '
        Me.cbFecFinvm.DropDownCalendar.Name = ""
        Me.cbFecFinvm.DropDownCalendar.Visible = False
        Me.cbFecFinvm.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinvm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinvm.Location = New System.Drawing.Point(218, 20)
        Me.cbFecFinvm.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinvm.Name = "cbFecFinvm"
        Me.cbFecFinvm.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinvm.TabIndex = 111
        Me.cbFecFinvm.Value = New Date(2012, 8, 1, 0, 0, 0, 0)
        Me.cbFecFinvm.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecIniciovm
        '
        '
        '
        '
        Me.cbFecIniciovm.DropDownCalendar.Name = ""
        Me.cbFecIniciovm.DropDownCalendar.Visible = False
        Me.cbFecIniciovm.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecIniciovm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecIniciovm.Location = New System.Drawing.Point(67, 20)
        Me.cbFecIniciovm.MinDate = New Date(2005, 1, 1, 0, 0, 0, 0)
        Me.cbFecIniciovm.Name = "cbFecIniciovm"
        Me.cbFecIniciovm.Size = New System.Drawing.Size(97, 20)
        Me.cbFecIniciovm.TabIndex = 110
        Me.cbFecIniciovm.Value = New Date(2012, 8, 1, 0, 0, 0, 0)
        Me.cbFecIniciovm.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'GroupBox17
        '
        Me.GroupBox17.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox17.Controls.Add(Me.Label31)
        Me.GroupBox17.Controls.Add(Me.cmbAlmacenvm)
        Me.GroupBox17.Controls.Add(Me.cmbOficinavm)
        Me.GroupBox17.Controls.Add(Me.Label32)
        Me.GroupBox17.Location = New System.Drawing.Point(7, 58)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(332, 50)
        Me.GroupBox17.TabIndex = 127
        Me.GroupBox17.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(150, 23)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(63, 13)
        Me.Label31.TabIndex = 119
        Me.Label31.Text = "Almacén :"
        '
        'cmbAlmacenvm
        '
        Me.cmbAlmacenvm.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAlmacenvm_DesignTimeLayout.LayoutString = resources.GetString("cmbAlmacenvm_DesignTimeLayout.LayoutString")
        Me.cmbAlmacenvm.DesignTimeLayout = cmbAlmacenvm_DesignTimeLayout
        Me.cmbAlmacenvm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAlmacenvm.Location = New System.Drawing.Point(213, 19)
        Me.cmbAlmacenvm.Name = "cmbAlmacenvm"
        Me.cmbAlmacenvm.SelectedIndex = -1
        Me.cmbAlmacenvm.SelectedItem = Nothing
        Me.cmbAlmacenvm.Size = New System.Drawing.Size(115, 20)
        Me.cmbAlmacenvm.TabIndex = 118
        Me.cmbAlmacenvm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinavm
        '
        Me.cmbOficinavm.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinavm_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinavm_DesignTimeLayout.LayoutString")
        Me.cmbOficinavm.DesignTimeLayout = cmbOficinavm_DesignTimeLayout
        Me.cmbOficinavm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinavm.Location = New System.Drawing.Point(55, 19)
        Me.cmbOficinavm.Name = "cmbOficinavm"
        Me.cmbOficinavm.SelectedIndex = -1
        Me.cmbOficinavm.SelectedItem = Nothing
        Me.cmbOficinavm.Size = New System.Drawing.Size(90, 20)
        Me.cmbOficinavm.TabIndex = 60
        Me.cmbOficinavm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(2, 23)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(55, 13)
        Me.Label32.TabIndex = 62
        Me.Label32.Text = "Oficina :"
        '
        'btnExcelvm
        '
        Me.btnExcelvm.Image = CType(resources.GetObject("btnExcelvm.Image"), System.Drawing.Image)
        Me.btnExcelvm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelvm.Location = New System.Drawing.Point(671, 114)
        Me.btnExcelvm.Name = "btnExcelvm"
        Me.btnExcelvm.Size = New System.Drawing.Size(65, 23)
        Me.btnExcelvm.TabIndex = 126
        Me.btnExcelvm.Text = "Excel"
        Me.btnExcelvm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelvm.UseVisualStyleBackColor = True
        '
        'btnBuscarvm
        '
        Me.btnBuscarvm.Image = CType(resources.GetObject("btnBuscarvm.Image"), System.Drawing.Image)
        Me.btnBuscarvm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarvm.Location = New System.Drawing.Point(595, 114)
        Me.btnBuscarvm.Name = "btnBuscarvm"
        Me.btnBuscarvm.Size = New System.Drawing.Size(65, 23)
        Me.btnBuscarvm.TabIndex = 125
        Me.btnBuscarvm.Text = "Buscar"
        Me.btnBuscarvm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarvm.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox11.Controls.Add(Me.txtIdMarcavm)
        Me.GroupBox11.Controls.Add(Me.Label21)
        Me.GroupBox11.Controls.Add(Me.txtIdMercaderiavm)
        Me.GroupBox11.Controls.Add(Me.Label22)
        Me.GroupBox11.Location = New System.Drawing.Point(345, 5)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(430, 103)
        Me.GroupBox11.TabIndex = 123
        Me.GroupBox11.TabStop = False
        '
        'txtIdMarcavm
        '
        Me.txtIdMarcavm.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.txtIdMarcavm.Location = New System.Drawing.Point(250, 43)
        Me.txtIdMarcavm.Name = "txtIdMarcavm"
        Me.txtIdMarcavm.ReadOnly = True
        Me.txtIdMarcavm.Size = New System.Drawing.Size(174, 20)
        Me.txtIdMarcavm.TabIndex = 122
        Me.txtIdMarcavm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(198, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(50, 13)
        Me.Label21.TabIndex = 123
        Me.Label21.Text = "Marca :"
        '
        'txtIdMercaderiavm
        '
        Me.txtIdMercaderiavm.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.txtIdMercaderiavm.Location = New System.Drawing.Point(77, 44)
        Me.txtIdMercaderiavm.Name = "txtIdMercaderiavm"
        Me.txtIdMercaderiavm.ReadOnly = True
        Me.txtIdMercaderiavm.Size = New System.Drawing.Size(116, 20)
        Me.txtIdMercaderiavm.TabIndex = 120
        Me.txtIdMercaderiavm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(0, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 13)
        Me.Label22.TabIndex = 121
        Me.Label22.Text = "Mercaderia :"
        '
        'dgVentasMateriales
        '
        Me.dgVentasMateriales.AllowCardSizing = False
        Me.dgVentasMateriales.AllowColumnDrag = False
        Me.dgVentasMateriales.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgVentasMateriales.AlternatingColors = True
        dgVentasMateriales_DesignTimeLayout.LayoutString = resources.GetString("dgVentasMateriales_DesignTimeLayout.LayoutString")
        Me.dgVentasMateriales.DesignTimeLayout = dgVentasMateriales_DesignTimeLayout
        Me.dgVentasMateriales.EmptyRows = True
        Me.dgVentasMateriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgVentasMateriales.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgVentasMateriales.GroupByBoxVisible = False
        Me.dgVentasMateriales.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgVentasMateriales.Location = New System.Drawing.Point(11, 143)
        Me.dgVentasMateriales.Name = "dgVentasMateriales"
        Me.dgVentasMateriales.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgVentasMateriales.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgVentasMateriales.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgVentasMateriales.Size = New System.Drawing.Size(764, 286)
        Me.dgVentasMateriales.TabIndex = 110
        Me.dgVentasMateriales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dpedidosSemana
        '
        Me.dpedidosSemana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dpedidosSemana.Location = New System.Drawing.Point(550, 121)
        Me.dpedidosSemana.Name = "dpedidosSemana"
        Me.dpedidosSemana.Size = New System.Drawing.Size(34, 21)
        Me.dpedidosSemana.TabIndex = 129
        Me.dpedidosSemana.Visible = False
        '
        'btnExcelps
        '
        Me.btnExcelps.Image = CType(resources.GetObject("btnExcelps.Image"), System.Drawing.Image)
        Me.btnExcelps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelps.Location = New System.Drawing.Point(666, 121)
        Me.btnExcelps.Name = "btnExcelps"
        Me.btnExcelps.Size = New System.Drawing.Size(66, 23)
        Me.btnExcelps.TabIndex = 128
        Me.btnExcelps.Text = "Excel"
        Me.btnExcelps.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelps.UseVisualStyleBackColor = True
        '
        'btnBuscarps
        '
        Me.btnBuscarps.Image = CType(resources.GetObject("btnBuscarps.Image"), System.Drawing.Image)
        Me.btnBuscarps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarps.Location = New System.Drawing.Point(590, 121)
        Me.btnBuscarps.Name = "btnBuscarps"
        Me.btnBuscarps.Size = New System.Drawing.Size(65, 23)
        Me.btnBuscarps.TabIndex = 127
        Me.btnBuscarps.Text = "Buscar"
        Me.btnBuscarps.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarps.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox13.Controls.Add(Me.txtNumDoc)
        Me.GroupBox13.Controls.Add(Me.Label38)
        Me.GroupBox13.Controls.Add(Me.Label37)
        Me.GroupBox13.Controls.Add(Me.cmbIdProveedorps)
        Me.GroupBox13.Controls.Add(Me.txtIdMarcaps)
        Me.GroupBox13.Controls.Add(Me.Label36)
        Me.GroupBox13.Controls.Add(Me.txtIdMercaderiaps)
        Me.GroupBox13.Controls.Add(Me.Label26)
        Me.GroupBox13.Location = New System.Drawing.Point(363, 11)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(412, 104)
        Me.GroupBox13.TabIndex = 123
        Me.GroupBox13.TabStop = False
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(78, 72)
        Me.txtNumDoc.MaxLength = 30
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(83, 20)
        Me.txtNumDoc.TabIndex = 128
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(1, 77)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(78, 13)
        Me.Label38.TabIndex = 129
        Me.Label38.Text = "Nro Pedido :"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(4, 21)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(73, 13)
        Me.Label37.TabIndex = 127
        Me.Label37.Text = "Proveedor :"
        '
        'cmbIdProveedorps
        '
        Me.cmbIdProveedorps.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdProveedorps_DesignTimeLayout.LayoutString = resources.GetString("cmbIdProveedorps_DesignTimeLayout.LayoutString")
        Me.cmbIdProveedorps.DesignTimeLayout = cmbIdProveedorps_DesignTimeLayout
        Me.cmbIdProveedorps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdProveedorps.Location = New System.Drawing.Point(80, 17)
        Me.cmbIdProveedorps.Name = "cmbIdProveedorps"
        Me.cmbIdProveedorps.SelectedIndex = -1
        Me.cmbIdProveedorps.SelectedItem = Nothing
        Me.cmbIdProveedorps.Size = New System.Drawing.Size(326, 20)
        Me.cmbIdProveedorps.TabIndex = 126
        Me.cmbIdProveedorps.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIdMarcaps
        '
        Me.txtIdMarcaps.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.txtIdMarcaps.Location = New System.Drawing.Point(266, 45)
        Me.txtIdMarcaps.Name = "txtIdMarcaps"
        Me.txtIdMarcaps.ReadOnly = True
        Me.txtIdMarcaps.Size = New System.Drawing.Size(140, 20)
        Me.txtIdMarcaps.TabIndex = 124
        Me.txtIdMarcaps.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(219, 49)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(50, 13)
        Me.Label36.TabIndex = 125
        Me.Label36.Text = "Marca :"
        '
        'txtIdMercaderiaps
        '
        Me.txtIdMercaderiaps.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.txtIdMercaderiaps.Location = New System.Drawing.Point(79, 45)
        Me.txtIdMercaderiaps.Name = "txtIdMercaderiaps"
        Me.txtIdMercaderiaps.ReadOnly = True
        Me.txtIdMercaderiaps.Size = New System.Drawing.Size(134, 20)
        Me.txtIdMercaderiaps.TabIndex = 120
        Me.txtIdMercaderiaps.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(2, 48)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(78, 13)
        Me.Label26.TabIndex = 121
        Me.Label26.Text = "Mercaderia :"
        '
        'GroupBox12
        '
        Me.GroupBox12.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox12.Controls.Add(Me.Label15)
        Me.GroupBox12.Controls.Add(Me.Label16)
        Me.GroupBox12.Controls.Add(Me.cbFecFinps)
        Me.GroupBox12.Controls.Add(Me.cbFecIniciops)
        Me.GroupBox12.Location = New System.Drawing.Point(5, 11)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(352, 48)
        Me.GroupBox12.TabIndex = 115
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "FECHAS"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(192, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(26, 13)
        Me.Label15.TabIndex = 119
        Me.Label15.Text = "Al :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(29, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 118
        Me.Label16.Text = "Del :"
        '
        'cbFecFinps
        '
        '
        '
        '
        Me.cbFecFinps.DropDownCalendar.Name = ""
        Me.cbFecFinps.DropDownCalendar.Visible = False
        Me.cbFecFinps.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinps.Location = New System.Drawing.Point(218, 20)
        Me.cbFecFinps.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinps.Name = "cbFecFinps"
        Me.cbFecFinps.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinps.TabIndex = 111
        Me.cbFecFinps.Value = New Date(2012, 8, 1, 0, 0, 0, 0)
        Me.cbFecFinps.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecIniciops
        '
        '
        '
        '
        Me.cbFecIniciops.DropDownCalendar.Name = ""
        Me.cbFecIniciops.DropDownCalendar.Visible = False
        Me.cbFecIniciops.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecIniciops.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecIniciops.Location = New System.Drawing.Point(67, 20)
        Me.cbFecIniciops.MinDate = New Date(2005, 1, 1, 0, 0, 0, 0)
        Me.cbFecIniciops.Name = "cbFecIniciops"
        Me.cbFecIniciops.Size = New System.Drawing.Size(97, 20)
        Me.cbFecIniciops.TabIndex = 110
        Me.cbFecIniciops.Value = New Date(2012, 8, 1, 0, 0, 0, 0)
        Me.cbFecIniciops.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'dgPedidosSemana
        '
        Me.dgPedidosSemana.AllowCardSizing = False
        Me.dgPedidosSemana.AllowColumnDrag = False
        Me.dgPedidosSemana.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgPedidosSemana.AlternatingColors = True
        dgPedidosSemana_DesignTimeLayout.LayoutString = resources.GetString("dgPedidosSemana_DesignTimeLayout.LayoutString")
        Me.dgPedidosSemana.DesignTimeLayout = dgPedidosSemana_DesignTimeLayout
        Me.dgPedidosSemana.EmptyRows = True
        Me.dgPedidosSemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgPedidosSemana.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgPedidosSemana.GroupByBoxVisible = False
        Me.dgPedidosSemana.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgPedidosSemana.Location = New System.Drawing.Point(11, 150)
        Me.dgPedidosSemana.Name = "dgPedidosSemana"
        Me.dgPedidosSemana.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgPedidosSemana.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgPedidosSemana.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgPedidosSemana.Size = New System.Drawing.Size(764, 288)
        Me.dgPedidosSemana.TabIndex = 110
        Me.dgPedidosSemana.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox8.Controls.Add(Me.Label17)
        Me.GroupBox8.Controls.Add(Me.cmbAlmacenps)
        Me.GroupBox8.Controls.Add(Me.cmbOficinaps)
        Me.GroupBox8.Controls.Add(Me.Label23)
        Me.GroupBox8.Location = New System.Drawing.Point(5, 65)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(352, 50)
        Me.GroupBox8.TabIndex = 68
        Me.GroupBox8.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(154, 23)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 13)
        Me.Label17.TabIndex = 119
        Me.Label17.Text = "Almacén :"
        '
        'cmbAlmacenps
        '
        Me.cmbAlmacenps.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAlmacenps_DesignTimeLayout.LayoutString = resources.GetString("cmbAlmacenps_DesignTimeLayout.LayoutString")
        Me.cmbAlmacenps.DesignTimeLayout = cmbAlmacenps_DesignTimeLayout
        Me.cmbAlmacenps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAlmacenps.Location = New System.Drawing.Point(217, 19)
        Me.cmbAlmacenps.Name = "cmbAlmacenps"
        Me.cmbAlmacenps.SelectedIndex = -1
        Me.cmbAlmacenps.SelectedItem = Nothing
        Me.cmbAlmacenps.Size = New System.Drawing.Size(122, 20)
        Me.cmbAlmacenps.TabIndex = 118
        Me.cmbAlmacenps.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinaps
        '
        Me.cmbOficinaps.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinaps_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinaps_DesignTimeLayout.LayoutString")
        Me.cmbOficinaps.DesignTimeLayout = cmbOficinaps_DesignTimeLayout
        Me.cmbOficinaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinaps.Location = New System.Drawing.Point(61, 19)
        Me.cmbOficinaps.Name = "cmbOficinaps"
        Me.cmbOficinaps.SelectedIndex = -1
        Me.cmbOficinaps.SelectedItem = Nothing
        Me.cmbOficinaps.Size = New System.Drawing.Size(90, 20)
        Me.cmbOficinaps.TabIndex = 60
        Me.cmbOficinaps.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 23)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 13)
        Me.Label23.TabIndex = 62
        Me.Label23.Text = "Oficina :"
        '
        'dpedidosFechaLlegada
        '
        Me.dpedidosFechaLlegada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dpedidosFechaLlegada.Location = New System.Drawing.Point(550, 123)
        Me.dpedidosFechaLlegada.Name = "dpedidosFechaLlegada"
        Me.dpedidosFechaLlegada.Size = New System.Drawing.Size(38, 22)
        Me.dpedidosFechaLlegada.TabIndex = 133
        Me.dpedidosFechaLlegada.Visible = False
        '
        'dgPedidosFechaLlegada
        '
        Me.dgPedidosFechaLlegada.AllowCardSizing = False
        Me.dgPedidosFechaLlegada.AllowColumnDrag = False
        Me.dgPedidosFechaLlegada.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgPedidosFechaLlegada.AlternatingColors = True
        dgPedidosFechaLlegada_DesignTimeLayout.LayoutString = resources.GetString("dgPedidosFechaLlegada_DesignTimeLayout.LayoutString")
        Me.dgPedidosFechaLlegada.DesignTimeLayout = dgPedidosFechaLlegada_DesignTimeLayout
        Me.dgPedidosFechaLlegada.EmptyRows = True
        Me.dgPedidosFechaLlegada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgPedidosFechaLlegada.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgPedidosFechaLlegada.GroupByBoxVisible = False
        Me.dgPedidosFechaLlegada.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgPedidosFechaLlegada.Location = New System.Drawing.Point(11, 151)
        Me.dgPedidosFechaLlegada.Name = "dgPedidosFechaLlegada"
        Me.dgPedidosFechaLlegada.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgPedidosFechaLlegada.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgPedidosFechaLlegada.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgPedidosFechaLlegada.Size = New System.Drawing.Size(764, 281)
        Me.dgPedidosFechaLlegada.TabIndex = 132
        Me.dgPedidosFechaLlegada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnExcelpf
        '
        Me.btnExcelpf.Image = CType(resources.GetObject("btnExcelpf.Image"), System.Drawing.Image)
        Me.btnExcelpf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelpf.Location = New System.Drawing.Point(670, 122)
        Me.btnExcelpf.Name = "btnExcelpf"
        Me.btnExcelpf.Size = New System.Drawing.Size(65, 23)
        Me.btnExcelpf.TabIndex = 130
        Me.btnExcelpf.Text = "Excel"
        Me.btnExcelpf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelpf.UseVisualStyleBackColor = True
        '
        'btnBuscarpf
        '
        Me.btnBuscarpf.Image = CType(resources.GetObject("btnBuscarpf.Image"), System.Drawing.Image)
        Me.btnBuscarpf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarpf.Location = New System.Drawing.Point(594, 122)
        Me.btnBuscarpf.Name = "btnBuscarpf"
        Me.btnBuscarpf.Size = New System.Drawing.Size(65, 23)
        Me.btnBuscarpf.TabIndex = 129
        Me.btnBuscarpf.Text = "Buscar"
        Me.btnBuscarpf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarpf.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox15.Controls.Add(Me.txtNumDocpf)
        Me.GroupBox15.Controls.Add(Me.Label39)
        Me.GroupBox15.Controls.Add(Me.Label40)
        Me.GroupBox15.Controls.Add(Me.cmbIdProveedorpf)
        Me.GroupBox15.Controls.Add(Me.txtIdMarcapf)
        Me.GroupBox15.Controls.Add(Me.Label41)
        Me.GroupBox15.Controls.Add(Me.txtIdMercaderiapf)
        Me.GroupBox15.Controls.Add(Me.Label28)
        Me.GroupBox15.Location = New System.Drawing.Point(346, 12)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(429, 104)
        Me.GroupBox15.TabIndex = 124
        Me.GroupBox15.TabStop = False
        '
        'txtNumDocpf
        '
        Me.txtNumDocpf.Location = New System.Drawing.Point(81, 71)
        Me.txtNumDocpf.MaxLength = 30
        Me.txtNumDocpf.Name = "txtNumDocpf"
        Me.txtNumDocpf.Size = New System.Drawing.Size(83, 20)
        Me.txtNumDocpf.TabIndex = 134
        Me.txtNumDocpf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(3, 75)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(78, 13)
        Me.Label39.TabIndex = 135
        Me.Label39.Text = "Nro Pedido :"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(5, 19)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(73, 13)
        Me.Label40.TabIndex = 133
        Me.Label40.Text = "Proveedor :"
        '
        'cmbIdProveedorpf
        '
        Me.cmbIdProveedorpf.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdProveedorpf_DesignTimeLayout.LayoutString = resources.GetString("cmbIdProveedorpf_DesignTimeLayout.LayoutString")
        Me.cmbIdProveedorpf.DesignTimeLayout = cmbIdProveedorpf_DesignTimeLayout
        Me.cmbIdProveedorpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdProveedorpf.Location = New System.Drawing.Point(81, 15)
        Me.cmbIdProveedorpf.Name = "cmbIdProveedorpf"
        Me.cmbIdProveedorpf.SelectedIndex = -1
        Me.cmbIdProveedorpf.SelectedItem = Nothing
        Me.cmbIdProveedorpf.Size = New System.Drawing.Size(342, 20)
        Me.cmbIdProveedorpf.TabIndex = 132
        Me.cmbIdProveedorpf.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIdMarcapf
        '
        Me.txtIdMarcapf.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.txtIdMarcapf.Location = New System.Drawing.Point(279, 45)
        Me.txtIdMarcapf.Name = "txtIdMarcapf"
        Me.txtIdMarcapf.ReadOnly = True
        Me.txtIdMarcapf.Size = New System.Drawing.Size(144, 20)
        Me.txtIdMarcapf.TabIndex = 130
        Me.txtIdMarcapf.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(223, 49)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(50, 13)
        Me.Label41.TabIndex = 131
        Me.Label41.Text = "Marca :"
        '
        'txtIdMercaderiapf
        '
        Me.txtIdMercaderiapf.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.txtIdMercaderiapf.Location = New System.Drawing.Point(81, 45)
        Me.txtIdMercaderiapf.Name = "txtIdMercaderiapf"
        Me.txtIdMercaderiapf.ReadOnly = True
        Me.txtIdMercaderiapf.Size = New System.Drawing.Size(129, 20)
        Me.txtIdMercaderiapf.TabIndex = 120
        Me.txtIdMercaderiapf.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(3, 48)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(78, 13)
        Me.Label28.TabIndex = 121
        Me.Label28.Text = "Mercaderia :"
        '
        'GroupBox14
        '
        Me.GroupBox14.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox14.Controls.Add(Me.Label24)
        Me.GroupBox14.Controls.Add(Me.Label42)
        Me.GroupBox14.Controls.Add(Me.cbFecFinpf)
        Me.GroupBox14.Controls.Add(Me.cbFecIniciopf)
        Me.GroupBox14.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(337, 48)
        Me.GroupBox14.TabIndex = 116
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "FECHAS"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(192, 24)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(26, 13)
        Me.Label24.TabIndex = 119
        Me.Label24.Text = "Al :"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(27, 24)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(34, 13)
        Me.Label42.TabIndex = 118
        Me.Label42.Text = "Del :"
        '
        'cbFecFinpf
        '
        '
        '
        '
        Me.cbFecFinpf.DropDownCalendar.Name = ""
        Me.cbFecFinpf.DropDownCalendar.Visible = False
        Me.cbFecFinpf.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinpf.Location = New System.Drawing.Point(218, 20)
        Me.cbFecFinpf.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinpf.Name = "cbFecFinpf"
        Me.cbFecFinpf.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinpf.TabIndex = 111
        Me.cbFecFinpf.Value = New Date(2012, 8, 1, 0, 0, 0, 0)
        Me.cbFecFinpf.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecIniciopf
        '
        '
        '
        '
        Me.cbFecIniciopf.DropDownCalendar.Name = ""
        Me.cbFecIniciopf.DropDownCalendar.Visible = False
        Me.cbFecIniciopf.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecIniciopf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecIniciopf.Location = New System.Drawing.Point(67, 20)
        Me.cbFecIniciopf.MinDate = New Date(2005, 1, 1, 0, 0, 0, 0)
        Me.cbFecIniciopf.Name = "cbFecIniciopf"
        Me.cbFecIniciopf.Size = New System.Drawing.Size(97, 20)
        Me.cbFecIniciopf.TabIndex = 110
        Me.cbFecIniciopf.Value = New Date(2012, 8, 1, 0, 0, 0, 0)
        Me.cbFecIniciopf.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox9.Controls.Add(Me.Label43)
        Me.GroupBox9.Controls.Add(Me.cmbAlmacenpf)
        Me.GroupBox9.Controls.Add(Me.cmbOficinapf)
        Me.GroupBox9.Controls.Add(Me.Label44)
        Me.GroupBox9.Location = New System.Drawing.Point(4, 66)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(338, 50)
        Me.GroupBox9.TabIndex = 68
        Me.GroupBox9.TabStop = False
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(143, 23)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(63, 13)
        Me.Label43.TabIndex = 119
        Me.Label43.Text = "Almacén :"
        '
        'cmbAlmacenpf
        '
        Me.cmbAlmacenpf.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAlmacenpf_DesignTimeLayout.LayoutString = resources.GetString("cmbAlmacenpf_DesignTimeLayout.LayoutString")
        Me.cmbAlmacenpf.DesignTimeLayout = cmbAlmacenpf_DesignTimeLayout
        Me.cmbAlmacenpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAlmacenpf.Location = New System.Drawing.Point(206, 19)
        Me.cmbAlmacenpf.Name = "cmbAlmacenpf"
        Me.cmbAlmacenpf.SelectedIndex = -1
        Me.cmbAlmacenpf.SelectedItem = Nothing
        Me.cmbAlmacenpf.Size = New System.Drawing.Size(130, 20)
        Me.cmbAlmacenpf.TabIndex = 118
        Me.cmbAlmacenpf.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinapf
        '
        Me.cmbOficinapf.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinapf_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinapf_DesignTimeLayout.LayoutString")
        Me.cmbOficinapf.DesignTimeLayout = cmbOficinapf_DesignTimeLayout
        Me.cmbOficinapf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinapf.Location = New System.Drawing.Point(52, 19)
        Me.cmbOficinapf.Name = "cmbOficinapf"
        Me.cmbOficinapf.SelectedIndex = -1
        Me.cmbOficinapf.SelectedItem = Nothing
        Me.cmbOficinapf.Size = New System.Drawing.Size(90, 20)
        Me.cmbOficinapf.TabIndex = 60
        Me.cmbOficinapf.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(0, 23)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(55, 13)
        Me.Label44.TabIndex = 62
        Me.Label44.Text = "Oficina :"
        '
        'btnPorcentaje
        '
        Me.btnPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPorcentaje.Image = CType(resources.GetObject("btnPorcentaje.Image"), System.Drawing.Image)
        Me.btnPorcentaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPorcentaje.Location = New System.Drawing.Point(347, 67)
        Me.btnPorcentaje.Name = "btnPorcentaje"
        Me.btnPorcentaje.Size = New System.Drawing.Size(96, 24)
        Me.btnPorcentaje.TabIndex = 142
        Me.btnPorcentaje.Text = "Estadisticas"
        Me.btnPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPorcentaje.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(690, 393)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(82, 13)
        Me.Label48.TabIndex = 141
        Me.Label48.Text = "Todo el resto"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(344, 390)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(270, 26)
        Me.Label47.TabIndex = 140
        Me.Label47.Text = "Job cuya fecha estimada queda a una semana" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "para vencerse y siguen en ejecución"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(63, 387)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(202, 52)
        Me.Label46.TabIndex = 139
        Me.Label46.Text = "Job cuya fecha estimada de cierre" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " ya vencio y sigue en ejecución " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtVerde
        '
        Me.txtVerde.BackColor = System.Drawing.Color.Green
        Me.txtVerde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVerde.Location = New System.Drawing.Point(636, 390)
        Me.txtVerde.Name = "txtVerde"
        Me.txtVerde.Size = New System.Drawing.Size(48, 20)
        Me.txtVerde.TabIndex = 138
        Me.txtVerde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAmbar
        '
        Me.txtAmbar.BackColor = System.Drawing.Color.Yellow
        Me.txtAmbar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmbar.Location = New System.Drawing.Point(290, 390)
        Me.txtAmbar.Name = "txtAmbar"
        Me.txtAmbar.Size = New System.Drawing.Size(48, 20)
        Me.txtAmbar.TabIndex = 137
        Me.txtAmbar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRojo
        '
        Me.txtRojo.BackColor = System.Drawing.Color.Red
        Me.txtRojo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRojo.Location = New System.Drawing.Point(9, 390)
        Me.txtRojo.Name = "txtRojo"
        Me.txtRojo.Size = New System.Drawing.Size(48, 20)
        Me.txtRojo.TabIndex = 75
        Me.txtRojo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox20
        '
        Me.GroupBox20.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox20.Controls.Add(Me.cmbSemaforo)
        Me.GroupBox20.Controls.Add(Me.Label45)
        Me.GroupBox20.Controls.Add(Me.cmbSupervisor)
        Me.GroupBox20.Controls.Add(Me.Label50)
        Me.GroupBox20.Location = New System.Drawing.Point(347, 14)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(428, 50)
        Me.GroupBox20.TabIndex = 136
        Me.GroupBox20.TabStop = False
        '
        'cmbSemaforo
        '
        Me.cmbSemaforo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSemaforo_DesignTimeLayout.LayoutString = resources.GetString("cmbSemaforo_DesignTimeLayout.LayoutString")
        Me.cmbSemaforo.DesignTimeLayout = cmbSemaforo_DesignTimeLayout
        Me.cmbSemaforo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSemaforo.Location = New System.Drawing.Point(324, 19)
        Me.cmbSemaforo.Name = "cmbSemaforo"
        Me.cmbSemaforo.SelectedIndex = -1
        Me.cmbSemaforo.SelectedItem = Nothing
        Me.cmbSemaforo.Size = New System.Drawing.Size(98, 20)
        Me.cmbSemaforo.TabIndex = 64
        Me.cmbSemaforo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(250, 22)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(68, 13)
        Me.Label45.TabIndex = 63
        Me.Label45.Text = "Semáforo :"
        '
        'cmbSupervisor
        '
        Me.cmbSupervisor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSupervisor_DesignTimeLayout.LayoutString = resources.GetString("cmbSupervisor_DesignTimeLayout.LayoutString")
        Me.cmbSupervisor.DesignTimeLayout = cmbSupervisor_DesignTimeLayout
        Me.cmbSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupervisor.Location = New System.Drawing.Point(89, 18)
        Me.cmbSupervisor.Name = "cmbSupervisor"
        Me.cmbSupervisor.SelectedIndex = -1
        Me.cmbSupervisor.SelectedItem = Nothing
        Me.cmbSupervisor.Size = New System.Drawing.Size(146, 20)
        Me.cmbSupervisor.TabIndex = 60
        Me.cmbSupervisor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(15, 21)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(75, 13)
        Me.Label50.TabIndex = 62
        Me.Label50.Text = "Supervisor :"
        '
        'dServicios
        '
        Me.dServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dServicios.Location = New System.Drawing.Point(688, 69)
        Me.dServicios.Name = "dServicios"
        Me.dServicios.Size = New System.Drawing.Size(38, 22)
        Me.dServicios.TabIndex = 135
        Me.dServicios.Visible = False
        '
        'btnImprimirSer
        '
        Me.btnImprimirSer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirSer.Image = CType(resources.GetObject("btnImprimirSer.Image"), System.Drawing.Image)
        Me.btnImprimirSer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimirSer.Location = New System.Drawing.Point(446, 67)
        Me.btnImprimirSer.Name = "btnImprimirSer"
        Me.btnImprimirSer.Size = New System.Drawing.Size(73, 24)
        Me.btnImprimirSer.TabIndex = 134
        Me.btnImprimirSer.Text = "Imprimir"
        Me.btnImprimirSer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimirSer.UseVisualStyleBackColor = True
        '
        'dgDetalleServicios
        '
        Me.dgDetalleServicios.AllowCardSizing = False
        Me.dgDetalleServicios.AllowColumnDrag = False
        Me.dgDetalleServicios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgDetalleServicios.AlternatingColors = True
        Me.dgDetalleServicios.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        dgDetalleServicios_DesignTimeLayout.LayoutString = resources.GetString("dgDetalleServicios_DesignTimeLayout.LayoutString")
        Me.dgDetalleServicios.DesignTimeLayout = dgDetalleServicios_DesignTimeLayout
        Me.dgDetalleServicios.EmptyRows = True
        Me.dgDetalleServicios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgDetalleServicios.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgDetalleServicios.GroupByBoxVisible = False
        Me.dgDetalleServicios.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive
        Me.dgDetalleServicios.Location = New System.Drawing.Point(6, 97)
        Me.dgDetalleServicios.Name = "dgDetalleServicios"
        Me.dgDetalleServicios.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgDetalleServicios.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgDetalleServicios.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgDetalleServicios.SelectOnExpand = False
        Me.dgDetalleServicios.Size = New System.Drawing.Size(766, 275)
        Me.dgDetalleServicios.TabIndex = 133
        Me.dgDetalleServicios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnExcelSer
        '
        Me.btnExcelSer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelSer.Image = CType(resources.GetObject("btnExcelSer.Image"), System.Drawing.Image)
        Me.btnExcelSer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelSer.Location = New System.Drawing.Point(596, 67)
        Me.btnExcelSer.Name = "btnExcelSer"
        Me.btnExcelSer.Size = New System.Drawing.Size(70, 24)
        Me.btnExcelSer.TabIndex = 132
        Me.btnExcelSer.Text = "Excel"
        Me.btnExcelSer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelSer.UseVisualStyleBackColor = True
        '
        'btnBuscarSer
        '
        Me.btnBuscarSer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarSer.Image = CType(resources.GetObject("btnBuscarSer.Image"), System.Drawing.Image)
        Me.btnBuscarSer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarSer.Location = New System.Drawing.Point(523, 67)
        Me.btnBuscarSer.Name = "btnBuscarSer"
        Me.btnBuscarSer.Size = New System.Drawing.Size(72, 24)
        Me.btnBuscarSer.TabIndex = 131
        Me.btnBuscarSer.Text = "Buscar"
        Me.btnBuscarSer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarSer.UseVisualStyleBackColor = True
        '
        'GroupBox19
        '
        Me.GroupBox19.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox19.Controls.Add(Me.Label51)
        Me.GroupBox19.Controls.Add(Me.Label52)
        Me.GroupBox19.Controls.Add(Me.cbFecFinalSer)
        Me.GroupBox19.Controls.Add(Me.cbFecInicioSer)
        Me.GroupBox19.Location = New System.Drawing.Point(6, 15)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(335, 48)
        Me.GroupBox19.TabIndex = 117
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "FECHAS"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(190, 24)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(26, 13)
        Me.Label51.TabIndex = 119
        Me.Label51.Text = "Al :"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(30, 24)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(34, 13)
        Me.Label52.TabIndex = 118
        Me.Label52.Text = "Del :"
        '
        'cbFecFinalSer
        '
        '
        '
        '
        Me.cbFecFinalSer.DropDownCalendar.Name = ""
        Me.cbFecFinalSer.DropDownCalendar.Visible = False
        Me.cbFecFinalSer.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinalSer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinalSer.Location = New System.Drawing.Point(218, 20)
        Me.cbFecFinalSer.Name = "cbFecFinalSer"
        Me.cbFecFinalSer.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinalSer.TabIndex = 111
        Me.cbFecFinalSer.Value = New Date(2012, 8, 1, 0, 0, 0, 0)
        Me.cbFecFinalSer.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecInicioSer
        '
        '
        '
        '
        Me.cbFecInicioSer.DropDownCalendar.Name = ""
        Me.cbFecInicioSer.DropDownCalendar.Visible = False
        Me.cbFecInicioSer.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicioSer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicioSer.Location = New System.Drawing.Point(65, 20)
        Me.cbFecInicioSer.Name = "cbFecInicioSer"
        Me.cbFecInicioSer.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicioSer.TabIndex = 110
        Me.cbFecInicioSer.Value = New Date(2012, 8, 1, 0, 0, 0, 0)
        Me.cbFecInicioSer.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'dgvTablero
        '
        Me.dgvTablero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTablero.Location = New System.Drawing.Point(16, 121)
        Me.dgvTablero.Name = "dgvTablero"
        Me.dgvTablero.Size = New System.Drawing.Size(751, 298)
        Me.dgvTablero.TabIndex = 147
        '
        'btnExcelTab
        '
        Me.btnExcelTab.Image = CType(resources.GetObject("btnExcelTab.Image"), System.Drawing.Image)
        Me.btnExcelTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelTab.Location = New System.Drawing.Point(100, 73)
        Me.btnExcelTab.Name = "btnExcelTab"
        Me.btnExcelTab.Size = New System.Drawing.Size(65, 23)
        Me.btnExcelTab.TabIndex = 4
        Me.btnExcelTab.Text = "Excel"
        Me.btnExcelTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelTab.UseVisualStyleBackColor = True
        '
        'btnBuscarTab
        '
        Me.btnBuscarTab.Image = CType(resources.GetObject("btnBuscarTab.Image"), System.Drawing.Image)
        Me.btnBuscarTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarTab.Location = New System.Drawing.Point(18, 73)
        Me.btnBuscarTab.Name = "btnBuscarTab"
        Me.btnBuscarTab.Size = New System.Drawing.Size(65, 23)
        Me.btnBuscarTab.TabIndex = 3
        Me.btnBuscarTab.Text = "Buscar"
        Me.btnBuscarTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarTab.UseVisualStyleBackColor = True
        '
        'gbOpciones
        '
        Me.gbOpciones.Controls.Add(Me.rbFiltros)
        Me.gbOpciones.Controls.Add(Me.rbChimbote)
        Me.gbOpciones.Controls.Add(Me.rbBaterias)
        Me.gbOpciones.Controls.Add(Me.rbMotores)
        Me.gbOpciones.Controls.Add(Me.rbGrupElec)
        Me.gbOpciones.Controls.Add(Me.rbRepConsig)
        Me.gbOpciones.Controls.Add(Me.rbVenOfi)
        Me.gbOpciones.Controls.Add(Me.rbManoObra)
        Me.gbOpciones.Controls.Add(Me.rbRepServ)
        Me.gbOpciones.Location = New System.Drawing.Point(218, 21)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(549, 84)
        Me.gbOpciones.TabIndex = 146
        Me.gbOpciones.TabStop = False
        Me.gbOpciones.Text = "Opciones"
        '
        'rbFiltros
        '
        Me.rbFiltros.AutoSize = True
        Me.rbFiltros.Location = New System.Drawing.Point(284, 52)
        Me.rbFiltros.Name = "rbFiltros"
        Me.rbFiltros.Size = New System.Drawing.Size(52, 17)
        Me.rbFiltros.TabIndex = 11
        Me.rbFiltros.TabStop = True
        Me.rbFiltros.Text = "Filtros"
        Me.rbFiltros.UseVisualStyleBackColor = True
        '
        'rbChimbote
        '
        Me.rbChimbote.AutoSize = True
        Me.rbChimbote.Location = New System.Drawing.Point(462, 52)
        Me.rbChimbote.Name = "rbChimbote"
        Me.rbChimbote.Size = New System.Drawing.Size(69, 17)
        Me.rbChimbote.TabIndex = 13
        Me.rbChimbote.TabStop = True
        Me.rbChimbote.Text = "Chimbote"
        Me.rbChimbote.UseVisualStyleBackColor = True
        '
        'rbBaterias
        '
        Me.rbBaterias.AutoSize = True
        Me.rbBaterias.Location = New System.Drawing.Point(369, 52)
        Me.rbBaterias.Name = "rbBaterias"
        Me.rbBaterias.Size = New System.Drawing.Size(63, 17)
        Me.rbBaterias.TabIndex = 12
        Me.rbBaterias.TabStop = True
        Me.rbBaterias.Text = "Baterias"
        Me.rbBaterias.UseVisualStyleBackColor = True
        '
        'rbMotores
        '
        Me.rbMotores.AutoSize = True
        Me.rbMotores.Checked = True
        Me.rbMotores.Location = New System.Drawing.Point(9, 19)
        Me.rbMotores.Name = "rbMotores"
        Me.rbMotores.Size = New System.Drawing.Size(63, 17)
        Me.rbMotores.TabIndex = 5
        Me.rbMotores.TabStop = True
        Me.rbMotores.Text = "Motores"
        Me.rbMotores.UseVisualStyleBackColor = True
        '
        'rbGrupElec
        '
        Me.rbGrupElec.AutoSize = True
        Me.rbGrupElec.Location = New System.Drawing.Point(118, 20)
        Me.rbGrupElec.Name = "rbGrupElec"
        Me.rbGrupElec.Size = New System.Drawing.Size(119, 17)
        Me.rbGrupElec.TabIndex = 6
        Me.rbGrupElec.TabStop = True
        Me.rbGrupElec.Text = "Grupo Electrógenos"
        Me.rbGrupElec.UseVisualStyleBackColor = True
        '
        'rbRepConsig
        '
        Me.rbRepConsig.AutoSize = True
        Me.rbRepConsig.Location = New System.Drawing.Point(283, 19)
        Me.rbRepConsig.Name = "rbRepConsig"
        Me.rbRepConsig.Size = New System.Drawing.Size(120, 17)
        Me.rbRepConsig.TabIndex = 7
        Me.rbRepConsig.TabStop = True
        Me.rbRepConsig.Text = "Rptos Consignación"
        Me.rbRepConsig.UseVisualStyleBackColor = True
        '
        'rbVenOfi
        '
        Me.rbVenOfi.AutoSize = True
        Me.rbVenOfi.Location = New System.Drawing.Point(437, 20)
        Me.rbVenOfi.Name = "rbVenOfi"
        Me.rbVenOfi.Size = New System.Drawing.Size(94, 17)
        Me.rbVenOfi.TabIndex = 8
        Me.rbVenOfi.TabStop = True
        Me.rbVenOfi.Text = "Ventas Oficina"
        Me.rbVenOfi.UseVisualStyleBackColor = True
        '
        'rbManoObra
        '
        Me.rbManoObra.AutoSize = True
        Me.rbManoObra.Location = New System.Drawing.Point(143, 52)
        Me.rbManoObra.Name = "rbManoObra"
        Me.rbManoObra.Size = New System.Drawing.Size(113, 17)
        Me.rbManoObra.TabIndex = 10
        Me.rbManoObra.TabStop = True
        Me.rbManoObra.Text = "M.Obra y Terceros"
        Me.rbManoObra.UseVisualStyleBackColor = True
        '
        'rbRepServ
        '
        Me.rbRepServ.AutoSize = True
        Me.rbRepServ.Location = New System.Drawing.Point(9, 52)
        Me.rbRepServ.Name = "rbRepServ"
        Me.rbRepServ.Size = New System.Drawing.Size(99, 17)
        Me.rbRepServ.TabIndex = 9
        Me.rbRepServ.TabStop = True
        Me.rbRepServ.Text = "Rptos Servicios"
        Me.rbRepServ.UseVisualStyleBackColor = True
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(111, 28)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(101, 20)
        Me.cmbMes.TabIndex = 2
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtanio
        '
        Me.txtanio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtanio.Location = New System.Drawing.Point(18, 28)
        Me.txtanio.Maximum = 9999
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2010
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(70, 20)
        Me.txtanio.TabIndex = 1
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2010
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.dventasAlmacenes)
        Me.UiTabPage1.Controls.Add(Me.GroupBox16)
        Me.UiTabPage1.Controls.Add(Me.btnExcelva)
        Me.UiTabPage1.Controls.Add(Me.btnBuscarva)
        Me.UiTabPage1.Controls.Add(Me.GroupBox10)
        Me.UiTabPage1.Controls.Add(Me.dgVentasAlmacen)
        Me.UiTabPage1.Controls.Add(Me.GroupBox7)
        Me.UiTabPage1.Image = CType(resources.GetObject("UiTabPage1.Image"), System.Drawing.Image)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(778, 439)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "Ventas Almacenes"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmSaldoBancos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(1244, 579)
        Me.Controls.Add(Me.TabCuentas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaldoBancos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saldo de Bancos"
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCuentas.ResumeLayout(False)
        Me.tabBancos.ResumeLayout(False)
        CType(Me.dgvBancos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbLocaciones.ResumeLayout(False)
        Me.tbLocaciones.PerformLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDetalles.ResumeLayout(False)
        Me.TabDetalles.PerformLayout()
        CType(Me.dgvDatosFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatosFin2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dventasAlmacenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.dgVentasAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.cmbAlmacenva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinava, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvenntasMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        CType(Me.cmbAlmacenvm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinavm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.dgVentasMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dpedidosSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        CType(Me.cmbIdProveedorps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        CType(Me.dgPedidosSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.cmbAlmacenps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinaps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dpedidosFechaLlegada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPedidosFechaLlegada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.cmbIdProveedorpf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.cmbAlmacenpf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinapf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        CType(Me.cmbSemaforo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dServicios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDetalleServicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        CType(Me.dgvTablero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpciones.ResumeLayout(False)
        Me.gbOpciones.PerformLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TabCuentas As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tabBancos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tbLocaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents TabDetalles As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dventasAlmacenes As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Private WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinva As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecIniciova As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents btnExcelva As System.Windows.Forms.Button
    Friend WithEvents btnBuscarva As System.Windows.Forms.Button
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdMarcava As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtIdMercaderiava As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dgVentasAlmacen As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacenva As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinava As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dvenntasMateriales As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Private WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinvm As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecIniciovm As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacenvm As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinavm As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnExcelvm As System.Windows.Forms.Button
    Friend WithEvents btnBuscarvm As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdMarcavm As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtIdMercaderiavm As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dgVentasMateriales As Janus.Windows.GridEX.GridEX
    Friend WithEvents dpedidosSemana As System.Windows.Forms.DataGridView
    Friend WithEvents btnExcelps As System.Windows.Forms.Button
    Friend WithEvents btnBuscarps As System.Windows.Forms.Button
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cmbIdProveedorps As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtIdMarcaps As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtIdMercaderiaps As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinps As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecIniciops As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents dgPedidosSemana As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacenps As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinaps As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dpedidosFechaLlegada As System.Windows.Forms.DataGridView
    Friend WithEvents dgPedidosFechaLlegada As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnExcelpf As System.Windows.Forms.Button
    Friend WithEvents btnBuscarpf As System.Windows.Forms.Button
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumDocpf As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents cmbIdProveedorpf As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtIdMarcapf As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtIdMercaderiapf As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Private WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinpf As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecIniciopf As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents cmbAlmacenpf As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinapf As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents btnPorcentaje As System.Windows.Forms.Button
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtVerde As System.Windows.Forms.TextBox
    Friend WithEvents txtAmbar As System.Windows.Forms.TextBox
    Friend WithEvents txtRojo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSemaforo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cmbSupervisor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents dServicios As System.Windows.Forms.DataGridView
    Friend WithEvents btnImprimirSer As System.Windows.Forms.Button
    Friend WithEvents dgDetalleServicios As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnExcelSer As System.Windows.Forms.Button
    Friend WithEvents btnBuscarSer As System.Windows.Forms.Button
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Private WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinalSer As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicioSer As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents dgvTablero As System.Windows.Forms.DataGridView
    Friend WithEvents btnExcelTab As System.Windows.Forms.Button
    Friend WithEvents btnBuscarTab As System.Windows.Forms.Button
    Friend WithEvents gbOpciones As System.Windows.Forms.GroupBox
    Friend WithEvents rbFiltros As System.Windows.Forms.RadioButton
    Friend WithEvents rbChimbote As System.Windows.Forms.RadioButton
    Friend WithEvents rbBaterias As System.Windows.Forms.RadioButton
    Friend WithEvents rbMotores As System.Windows.Forms.RadioButton
    Friend WithEvents rbGrupElec As System.Windows.Forms.RadioButton
    Friend WithEvents rbRepConsig As System.Windows.Forms.RadioButton
    Friend WithEvents rbVenOfi As System.Windows.Forms.RadioButton
    Friend WithEvents rbManoObra As System.Windows.Forms.RadioButton
    Friend WithEvents rbRepServ As System.Windows.Forms.RadioButton
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents txtDirFile As System.Windows.Forms.TextBox
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents dgvBancos As Janus.Windows.GridEX.GridEX
    Friend WithEvents dgvCuentas As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBanco As System.Windows.Forms.TextBox
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBanco2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvDatosFin2 As System.Windows.Forms.DataGridView
    Friend WithEvents IdSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodBan2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumCta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecVal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Referencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargo1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abono1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SucAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumOpe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents utc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgvDatosFin As Janus.Windows.GridEX.GridEX
End Class
