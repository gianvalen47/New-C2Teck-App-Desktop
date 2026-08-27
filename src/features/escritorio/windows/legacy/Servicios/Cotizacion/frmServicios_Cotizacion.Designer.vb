<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios_Cotizacion
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
        Dim cmbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMantenimiento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbSupervisor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbGarantia_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMedios_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCondPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbSubMarca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvCotRepAdjuntadas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicios_Cotizacion))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.biActualizarOrden = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAprobar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActMoneda = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.txtNumCot = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblRepuesto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBuscarCliente = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbMantenimiento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSolicitado = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDatEntrega = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCodProveedor = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbSupervisor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtLucCesante = New System.Windows.Forms.TextBox()
        Me.txtFecValidez = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.cmbGarantia = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbMedios = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.txtNumOrden = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbCondPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtUnidad = New System.Windows.Forms.TextBox()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.btnAgregarContacto = New System.Windows.Forms.Button()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.cmbSubMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtDescripcion = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.gbCotRepAdjuntadas = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvCotRepAdjuntadas = New Janus.Windows.GridEX.GridEX()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtMontoTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoTotalNeto = New System.Windows.Forms.TextBox()
        Me.txtMontoTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoTotal = New System.Windows.Forms.TextBox()
        Me.txtTotalDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblMontoDscto = New System.Windows.Forms.TextBox()
        Me.txtMontoSinIGV = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblTotalMontoSinIgv = New System.Windows.Forms.TextBox()
        Me.txtMontoBruto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblUnidadNegocio = New System.Windows.Forms.Label()
        Me.cbRepuesto = New System.Windows.Forms.CheckBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.cbCotAdicional = New System.Windows.Forms.CheckBox()
        Me.cbExportacion = New System.Windows.Forms.CheckBox()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMantenimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbGarantia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMedios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbCondPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbSubMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCotRepAdjuntadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCotRepAdjuntadas.SuspendLayout()
        CType(Me.dgvCotRepAdjuntadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biGuardar, Me.ToolStripSeparator4, Me.biEditar, Me.ToolStripSeparator2, Me.biDeshacer, Me.biActualizarOrden, Me.ToolStripSeparator1, Me.btnAprobar, Me.ToolStripSeparator3, Me.biActMoneda, Me.ToolStripSeparator5, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(866, 31)
        Me.ToolStrip.TabIndex = 43
        Me.ToolStrip.Text = "Guardar Datos de la Cotizacion"
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Guardar los Datos Modificados"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Cotizacion"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios de Cotizacion"
        '
        'biActualizarOrden
        '
        Me.biActualizarOrden.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizarOrden.Image = Global.SIGECOM.My.Resources.Resources.ordenesCompra
        Me.biActualizarOrden.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizarOrden.Name = "biActualizarOrden"
        Me.biActualizarOrden.Size = New System.Drawing.Size(28, 28)
        Me.biActualizarOrden.Text = "Actualizar Orden de Compra"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnAprobar
        '
        Me.btnAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.btnAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(28, 28)
        Me.btnAprobar.Text = "Aprobar Cotización de Servicios"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biActMoneda
        '
        Me.biActMoneda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActMoneda.Image = Global.SIGECOM.My.Resources.Resources.Moneda
        Me.biActMoneda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActMoneda.Name = "biActMoneda"
        Me.biActMoneda.Size = New System.Drawing.Size(28, 28)
        Me.biActMoneda.Text = "Actualizar Moneda"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'txtNumCot
        '
        Me.txtNumCot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCot.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumCot.Location = New System.Drawing.Point(80, 42)
        Me.txtNumCot.Name = "txtNumCot"
        Me.txtNumCot.ReadOnly = True
        Me.txtNumCot.Size = New System.Drawing.Size(85, 21)
        Me.txtNumCot.TabIndex = 44
        Me.txtNumCot.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "#Cotizacion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(167, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Oficina"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Location = New System.Drawing.Point(206, 42)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(74, 20)
        Me.cmbOficinas.TabIndex = 47
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblRepuesto
        '
        Me.lblRepuesto.AutoSize = True
        Me.lblRepuesto.Location = New System.Drawing.Point(288, 46)
        Me.lblRepuesto.Name = "lblRepuesto"
        Me.lblRepuesto.Size = New System.Drawing.Size(58, 13)
        Me.lblRepuesto.TabIndex = 48
        Me.lblRepuesto.Text = "Repuestos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(367, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Fabricante"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(514, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Sub Marca"
        Me.Label5.Visible = False
        '
        'cmbTipo
        '
        Me.cmbTipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipo_DesignTimeLayout.LayoutString")
        Me.cmbTipo.DesignTimeLayout = cmbTipo_DesignTimeLayout
        Me.cmbTipo.Location = New System.Drawing.Point(423, 42)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.SelectedIndex = -1
        Me.cmbTipo.SelectedItem = Nothing
        Me.cmbTipo.Size = New System.Drawing.Size(77, 20)
        Me.cmbTipo.TabIndex = 54
        Me.cmbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Razón Social"
        '
        'txtBuscarCliente
        '
        Me.txtBuscarCliente.Location = New System.Drawing.Point(80, 98)
        Me.txtBuscarCliente.Name = "txtBuscarCliente"
        Me.txtBuscarCliente.ReadOnly = True
        Me.txtBuscarCliente.Size = New System.Drawing.Size(266, 20)
        Me.txtBuscarCliente.TabIndex = 57
        Me.txtBuscarCliente.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(393, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Mant."
        '
        'cmbMantenimiento
        '
        Me.cmbMantenimiento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMantenimiento_DesignTimeLayout.LayoutString = resources.GetString("cmbMantenimiento_DesignTimeLayout.LayoutString")
        Me.cmbMantenimiento.DesignTimeLayout = cmbMantenimiento_DesignTimeLayout
        Me.cmbMantenimiento.Location = New System.Drawing.Point(433, 98)
        Me.cmbMantenimiento.Name = "cmbMantenimiento"
        Me.cmbMantenimiento.SelectedIndex = -1
        Me.cmbMantenimiento.SelectedItem = Nothing
        Me.cmbMantenimiento.Size = New System.Drawing.Size(113, 20)
        Me.cmbMantenimiento.TabIndex = 60
        Me.cmbMantenimiento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbMantenimiento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(38, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Serie"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(260, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Modelo"
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(80, 124)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(128, 20)
        Me.txtSerie.TabIndex = 63
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(305, 124)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(147, 20)
        Me.txtModelo.TabIndex = 65
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(496, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "Equipo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(704, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Cotz Adicional"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(716, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "Exportación"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 154)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 72
        Me.Label13.Text = "Descripción"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(23, 186)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Contacto"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(312, 186)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 13)
        Me.Label15.TabIndex = 75
        Me.Label15.Text = "Referencia"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(377, 183)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(201, 20)
        Me.txtReferencia.TabIndex = 76
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(602, 186)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 77
        Me.Label16.Text = "Solicitado por"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSolicitado
        '
        Me.txtSolicitado.Location = New System.Drawing.Point(679, 183)
        Me.txtSolicitado.Multiline = True
        Me.txtSolicitado.Name = "txtSolicitado"
        Me.txtSolicitado.Size = New System.Drawing.Size(145, 20)
        Me.txtSolicitado.TabIndex = 78
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 213)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 13)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "Dat.Entrega"
        '
        'txtDatEntrega
        '
        Me.txtDatEntrega.Location = New System.Drawing.Point(80, 210)
        Me.txtDatEntrega.Multiline = True
        Me.txtDatEntrega.Name = "txtDatEntrega"
        Me.txtDatEntrega.Size = New System.Drawing.Size(498, 20)
        Me.txtDatEntrega.TabIndex = 80
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(584, 213)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 13)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Código Proveedor"
        '
        'txtCodProveedor
        '
        Me.txtCodProveedor.Location = New System.Drawing.Point(679, 210)
        Me.txtCodProveedor.Name = "txtCodProveedor"
        Me.txtCodProveedor.Size = New System.Drawing.Size(91, 20)
        Me.txtCodProveedor.TabIndex = 82
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(39, 357)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(34, 13)
        Me.Label31.TabIndex = 93
        Me.Label31.Text = "Glosa"
        '
        'cmbSupervisor
        '
        Me.cmbSupervisor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSupervisor_DesignTimeLayout.LayoutString = resources.GetString("cmbSupervisor_DesignTimeLayout.LayoutString")
        Me.cmbSupervisor.DesignTimeLayout = cmbSupervisor_DesignTimeLayout
        Me.cmbSupervisor.Location = New System.Drawing.Point(661, 46)
        Me.cmbSupervisor.Name = "cmbSupervisor"
        Me.cmbSupervisor.SelectedIndex = -1
        Me.cmbSupervisor.SelectedItem = Nothing
        Me.cmbSupervisor.Size = New System.Drawing.Size(154, 20)
        Me.cmbSupervisor.TabIndex = 92
        Me.cmbSupervisor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(4, 21)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(62, 13)
        Me.Label48.TabIndex = 110
        Me.Label48.Text = "Pago Inicial"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(10, 21)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(65, 13)
        Me.Label50.TabIndex = 112
        Me.Label50.Text = "Fec. Validez"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(20, 13)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(46, 26)
        Me.Label51.TabIndex = 113
        Me.Label51.Text = "Lucro" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cesante"
        '
        'txtLucCesante
        '
        Me.txtLucCesante.Location = New System.Drawing.Point(74, 13)
        Me.txtLucCesante.Multiline = True
        Me.txtLucCesante.Name = "txtLucCesante"
        Me.txtLucCesante.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLucCesante.Size = New System.Drawing.Size(744, 29)
        Me.txtLucCesante.TabIndex = 89
        '
        'txtFecValidez
        '
        '
        '
        '
        Me.txtFecValidez.DropDownCalendar.Name = ""
        Me.txtFecValidez.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecValidez.Location = New System.Drawing.Point(81, 17)
        Me.txtFecValidez.Name = "txtFecValidez"
        Me.txtFecValidez.NullButtonText = "Ninguno"
        Me.txtFecValidez.Size = New System.Drawing.Size(82, 20)
        Me.txtFecValidez.TabIndex = 85
        Me.txtFecValidez.TodayButtonText = "Hoy"
        Me.txtFecValidez.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(207, 21)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(49, 13)
        Me.Label52.TabIndex = 117
        Me.Label52.Text = "Garantía"
        '
        'cmbGarantia
        '
        Me.cmbGarantia.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbGarantia_DesignTimeLayout.LayoutString = resources.GetString("cmbGarantia_DesignTimeLayout.LayoutString")
        Me.cmbGarantia.DesignTimeLayout = cmbGarantia_DesignTimeLayout
        Me.cmbGarantia.Location = New System.Drawing.Point(259, 17)
        Me.cmbGarantia.Name = "cmbGarantia"
        Me.cmbGarantia.SelectedIndex = -1
        Me.cmbGarantia.SelectedItem = Nothing
        Me.cmbGarantia.Size = New System.Drawing.Size(131, 20)
        Me.cmbGarantia.TabIndex = 86
        Me.cmbGarantia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbMedios
        '
        Me.cmbMedios.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMedios_DesignTimeLayout.LayoutString = resources.GetString("cmbMedios_DesignTimeLayout.LayoutString")
        Me.cmbMedios.DesignTimeLayout = cmbMedios_DesignTimeLayout
        Me.cmbMedios.Location = New System.Drawing.Point(130, 46)
        Me.cmbMedios.Name = "cmbMedios"
        Me.cmbMedios.SelectedIndex = -1
        Me.cmbMedios.SelectedItem = Nothing
        Me.cmbMedios.Size = New System.Drawing.Size(100, 20)
        Me.cmbMedios.TabIndex = 90
        Me.cmbMedios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(278, 50)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(45, 13)
        Me.Label55.TabIndex = 123
        Me.Label55.Text = "Nro 0/C"
        '
        'txtNumOrden
        '
        Me.txtNumOrden.Location = New System.Drawing.Point(327, 47)
        Me.txtNumOrden.Name = "txtNumOrden"
        Me.txtNumOrden.Size = New System.Drawing.Size(154, 20)
        Me.txtNumOrden.TabIndex = 91
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbCondPago)
        Me.GroupBox1.Controls.Add(Me.Label48)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 233)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 42)
        Me.GroupBox1.TabIndex = 127
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Condiciones de Pago"
        '
        'cmbCondPago
        '
        Me.cmbCondPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCondPago_DesignTimeLayout.LayoutString = resources.GetString("cmbCondPago_DesignTimeLayout.LayoutString")
        Me.cmbCondPago.DesignTimeLayout = cmbCondPago_DesignTimeLayout
        Me.cmbCondPago.Location = New System.Drawing.Point(74, 17)
        Me.cmbCondPago.Name = "cmbCondPago"
        Me.cmbCondPago.SelectedIndex = -1
        Me.cmbCondPago.SelectedItem = Nothing
        Me.cmbCondPago.Size = New System.Drawing.Size(238, 20)
        Me.cmbCondPago.TabIndex = 84
        Me.cmbCondPago.TabStop = False
        Me.cmbCondPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbGarantia)
        Me.GroupBox2.Controls.Add(Me.Label50)
        Me.GroupBox2.Controls.Add(Me.txtFecValidez)
        Me.GroupBox2.Controls.Add(Me.Label52)
        Me.GroupBox2.Location = New System.Drawing.Point(436, 233)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(399, 42)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Condiciones Generales"
        '
        'txtUnidad
        '
        Me.txtUnidad.Location = New System.Drawing.Point(542, 124)
        Me.txtUnidad.Name = "txtUnidad"
        Me.txtUnidad.Size = New System.Drawing.Size(132, 20)
        Me.txtUnidad.TabIndex = 66
        '
        'txtGlosa
        '
        Me.txtGlosa.Location = New System.Drawing.Point(79, 349)
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGlosa.Size = New System.Drawing.Size(745, 30)
        Me.txtGlosa.TabIndex = 115
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtLucCesante)
        Me.GroupBox3.Controls.Add(Me.Label51)
        Me.GroupBox3.Controls.Add(Me.cmbMedios)
        Me.GroupBox3.Controls.Add(Me.txtNumOrden)
        Me.GroupBox3.Controls.Add(Me.Label55)
        Me.GroupBox3.Controls.Add(Me.cmbSupervisor)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 272)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(832, 71)
        Me.GroupBox3.TabIndex = 88
        Me.GroupBox3.TabStop = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 50)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 13)
        Me.Label20.TabIndex = 125
        Me.Label20.Text = "Medio de Aprobación"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(533, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(122, 13)
        Me.Label19.TabIndex = 124
        Me.Label19.Text = "Supervisor Responsable"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(573, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "Moneda"
        '
        'cmbCodMon
        '
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(620, 97)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(54, 20)
        Me.cmbCodMon.TabIndex = 61
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(645, 47)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(189, 38)
        Me.gbEstado.TabIndex = 131
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(6, 15)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(179, 14)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAgregarContacto
        '
        Me.btnAgregarContacto.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnAgregarContacto.Location = New System.Drawing.Point(271, 181)
        Me.btnAgregarContacto.Name = "btnAgregarContacto"
        Me.btnAgregarContacto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnAgregarContacto.Size = New System.Drawing.Size(25, 23)
        Me.btnAgregarContacto.TabIndex = 75
        Me.btnAgregarContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarContacto.UseVisualStyleBackColor = True
        '
        'txtContacto
        '
        Me.txtContacto.Location = New System.Drawing.Point(80, 183)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.ReadOnly = True
        Me.txtContacto.Size = New System.Drawing.Size(189, 20)
        Me.txtContacto.TabIndex = 74
        '
        'cmbSubMarca
        '
        Me.cmbSubMarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSubMarca_DesignTimeLayout.LayoutString = resources.GetString("cmbSubMarca_DesignTimeLayout.LayoutString")
        Me.cmbSubMarca.DesignTimeLayout = cmbSubMarca_DesignTimeLayout
        Me.cmbSubMarca.Location = New System.Drawing.Point(573, 69)
        Me.cmbSubMarca.Name = "cmbSubMarca"
        Me.cmbSubMarca.SelectedIndex = -1
        Me.cmbSubMarca.SelectedItem = Nothing
        Me.cmbSubMarca.Size = New System.Drawing.Size(65, 20)
        Me.cmbSubMarca.TabIndex = 55
        Me.cmbSubMarca.Visible = False
        Me.cmbSubMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDescripcion
        '
        Me.txtDescripcion.ButtonImage = CType(resources.GetObject("txtDescripcion.ButtonImage"), System.Drawing.Image)
        Me.txtDescripcion.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtDescripcion.Location = New System.Drawing.Point(80, 151)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.PromptChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDescripcion.Size = New System.Drawing.Size(744, 24)
        Me.txtDescripcion.TabIndex = 70
        '
        'gbCotRepAdjuntadas
        '
        Me.gbCotRepAdjuntadas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbCotRepAdjuntadas.Controls.Add(Me.dgvCotRepAdjuntadas)
        Me.gbCotRepAdjuntadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCotRepAdjuntadas.Location = New System.Drawing.Point(0, 643)
        Me.gbCotRepAdjuntadas.Name = "gbCotRepAdjuntadas"
        Me.gbCotRepAdjuntadas.Size = New System.Drawing.Size(846, 112)
        Me.gbCotRepAdjuntadas.TabIndex = 134
        Me.gbCotRepAdjuntadas.Text = "Cotizaciones de Repuestos Adjuntadas"
        Me.gbCotRepAdjuntadas.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvCotRepAdjuntadas
        '
        Me.dgvCotRepAdjuntadas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvCotRepAdjuntadas_DesignTimeLayout.LayoutString = resources.GetString("dgvCotRepAdjuntadas_DesignTimeLayout.LayoutString")
        Me.dgvCotRepAdjuntadas.DesignTimeLayout = dgvCotRepAdjuntadas_DesignTimeLayout
        Me.dgvCotRepAdjuntadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvCotRepAdjuntadas.GroupByBoxVisible = False
        Me.dgvCotRepAdjuntadas.Location = New System.Drawing.Point(11, 19)
        Me.dgvCotRepAdjuntadas.Name = "dgvCotRepAdjuntadas"
        Me.dgvCotRepAdjuntadas.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvCotRepAdjuntadas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvCotRepAdjuntadas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvCotRepAdjuntadas.Size = New System.Drawing.Size(814, 82)
        Me.dgvCotRepAdjuntadas.TabIndex = 234
        Me.dgvCotRepAdjuntadas.TabStop = False
        Me.dgvCotRepAdjuntadas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gbDetalle
        '
        Me.gbDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(8, 379)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(838, 156)
        Me.gbDetalle.TabIndex = 186
        Me.gbDetalle.Text = "Detalles"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(9, 17)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(820, 133)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'txtMontoTotalNeto
        '
        Me.txtMontoTotalNeto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMontoTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoTotalNeto.Location = New System.Drawing.Point(705, 69)
        Me.txtMontoTotalNeto.MaxLength = 5
        Me.txtMontoTotalNeto.Name = "txtMontoTotalNeto"
        Me.txtMontoTotalNeto.ReadOnly = True
        Me.txtMontoTotalNeto.Size = New System.Drawing.Size(94, 20)
        Me.txtMontoTotalNeto.TabIndex = 16
        Me.txtMontoTotalNeto.TabStop = False
        Me.txtMontoTotalNeto.Text = "0.00"
        Me.txtMontoTotalNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoTotalNeto
        '
        Me.lblMontoTotalNeto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMontoTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoTotalNeto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoTotalNeto.Location = New System.Drawing.Point(11, 69)
        Me.lblMontoTotalNeto.MaxLength = 20
        Me.lblMontoTotalNeto.Name = "lblMontoTotalNeto"
        Me.lblMontoTotalNeto.ReadOnly = True
        Me.lblMontoTotalNeto.Size = New System.Drawing.Size(695, 20)
        Me.lblMontoTotalNeto.TabIndex = 15
        Me.lblMontoTotalNeto.TabStop = False
        Me.lblMontoTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoTotal
        '
        Me.txtMontoTotal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMontoTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoTotal.Location = New System.Drawing.Point(705, 31)
        Me.txtMontoTotal.MaxLength = 5
        Me.txtMontoTotal.Name = "txtMontoTotal"
        Me.txtMontoTotal.ReadOnly = True
        Me.txtMontoTotal.Size = New System.Drawing.Size(94, 20)
        Me.txtMontoTotal.TabIndex = 14
        Me.txtMontoTotal.TabStop = False
        Me.txtMontoTotal.Text = "0.00"
        Me.txtMontoTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMontoTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoTotal.Location = New System.Drawing.Point(11, 31)
        Me.lblMontoTotal.MaxLength = 20
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.ReadOnly = True
        Me.lblMontoTotal.Size = New System.Drawing.Size(695, 20)
        Me.lblMontoTotal.TabIndex = 13
        Me.lblMontoTotal.TabStop = False
        Me.lblMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDescuento.Location = New System.Drawing.Point(705, 12)
        Me.txtTotalDescuento.MaxLength = 5
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(94, 20)
        Me.txtTotalDescuento.TabIndex = 11
        Me.txtTotalDescuento.TabStop = False
        Me.txtTotalDescuento.Text = "0.00"
        Me.txtTotalDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDescuento.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblMontoDscto
        '
        Me.lblMontoDscto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMontoDscto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblMontoDscto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblMontoDscto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblMontoDscto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoDscto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblMontoDscto.Location = New System.Drawing.Point(11, 12)
        Me.lblMontoDscto.MaxLength = 20
        Me.lblMontoDscto.Name = "lblMontoDscto"
        Me.lblMontoDscto.ReadOnly = True
        Me.lblMontoDscto.Size = New System.Drawing.Size(603, 20)
        Me.lblMontoDscto.TabIndex = 10
        Me.lblMontoDscto.TabStop = False
        Me.lblMontoDscto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoSinIGV
        '
        Me.txtMontoSinIGV.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMontoSinIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoSinIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSinIGV.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoSinIGV.Location = New System.Drawing.Point(705, 50)
        Me.txtMontoSinIGV.MaxLength = 5
        Me.txtMontoSinIGV.Name = "txtMontoSinIGV"
        Me.txtMontoSinIGV.ReadOnly = True
        Me.txtMontoSinIGV.Size = New System.Drawing.Size(94, 20)
        Me.txtMontoSinIGV.TabIndex = 6
        Me.txtMontoSinIGV.TabStop = False
        Me.txtMontoSinIGV.Text = "0.00"
        Me.txtMontoSinIGV.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoSinIGV.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoSinIGV.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.lblTotalMontoSinIgv)
        Me.UiGroupBox1.Controls.Add(Me.txtMontoSinIGV)
        Me.UiGroupBox1.Controls.Add(Me.txtMontoBruto)
        Me.UiGroupBox1.Controls.Add(Me.txtMontoTotalNeto)
        Me.UiGroupBox1.Controls.Add(Me.lblMontoDscto)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDescuento)
        Me.UiGroupBox1.Controls.Add(Me.lblMontoTotalNeto)
        Me.UiGroupBox1.Controls.Add(Me.lblMontoTotal)
        Me.UiGroupBox1.Controls.Add(Me.txtMontoTotal)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 541)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(830, 96)
        Me.UiGroupBox1.TabIndex = 187
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblTotalMontoSinIgv
        '
        Me.lblTotalMontoSinIgv.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTotalMontoSinIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalMontoSinIgv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalMontoSinIgv.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalMontoSinIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMontoSinIgv.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalMontoSinIgv.Location = New System.Drawing.Point(11, 50)
        Me.lblTotalMontoSinIgv.MaxLength = 20
        Me.lblTotalMontoSinIgv.Name = "lblTotalMontoSinIgv"
        Me.lblTotalMontoSinIgv.ReadOnly = True
        Me.lblTotalMontoSinIgv.Size = New System.Drawing.Size(695, 20)
        Me.lblTotalMontoSinIgv.TabIndex = 18
        Me.lblTotalMontoSinIgv.TabStop = False
        Me.lblTotalMontoSinIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMontoBruto
        '
        Me.txtMontoBruto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtMontoBruto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtMontoBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoBruto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtMontoBruto.Location = New System.Drawing.Point(612, 12)
        Me.txtMontoBruto.MaxLength = 5
        Me.txtMontoBruto.Name = "txtMontoBruto"
        Me.txtMontoBruto.ReadOnly = True
        Me.txtMontoBruto.Size = New System.Drawing.Size(94, 20)
        Me.txtMontoBruto.TabIndex = 17
        Me.txtMontoBruto.TabStop = False
        Me.txtMontoBruto.Text = "0.00"
        Me.txtMontoBruto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoBruto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoBruto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(43, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(29, 13)
        Me.Label21.TabIndex = 188
        Me.Label21.Text = "Área"
        '
        'cmbArea
        '
        Me.cmbArea.BackColor = System.Drawing.SystemColors.Control
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(80, 68)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.ReadOnly = True
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(159, 20)
        Me.cmbArea.TabIndex = 189
        Me.cmbArea.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(271, 72)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 190
        Me.Label22.Text = "Centro Costo"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.BackColor = System.Drawing.SystemColors.Control
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(345, 68)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.ReadOnly = True
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(155, 20)
        Me.cmbCentroCosto.TabIndex = 191
        Me.cmbCentroCosto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblUnidadNegocio
        '
        Me.lblUnidadNegocio.AutoSize = True
        Me.lblUnidadNegocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadNegocio.Location = New System.Drawing.Point(312, 9)
        Me.lblUnidadNegocio.Name = "lblUnidadNegocio"
        Me.lblUnidadNegocio.Size = New System.Drawing.Size(134, 15)
        Me.lblUnidadNegocio.TabIndex = 192
        Me.lblUnidadNegocio.Text = "Unidad de Negocio:"
        '
        'cbRepuesto
        '
        Me.cbRepuesto.AutoSize = True
        Me.cbRepuesto.Location = New System.Drawing.Point(348, 45)
        Me.cbRepuesto.Name = "cbRepuesto"
        Me.cbRepuesto.Size = New System.Drawing.Size(15, 14)
        Me.cbRepuesto.TabIndex = 193
        Me.cbRepuesto.UseVisualStyleBackColor = True
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(351, 96)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 194
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'cbCotAdicional
        '
        Me.cbCotAdicional.AutoSize = True
        Me.cbCotAdicional.Location = New System.Drawing.Point(785, 100)
        Me.cbCotAdicional.Name = "cbCotAdicional"
        Me.cbCotAdicional.Size = New System.Drawing.Size(15, 14)
        Me.cbCotAdicional.TabIndex = 195
        Me.cbCotAdicional.UseVisualStyleBackColor = True
        '
        'cbExportacion
        '
        Me.cbExportacion.AutoSize = True
        Me.cbExportacion.Location = New System.Drawing.Point(785, 127)
        Me.cbExportacion.Name = "cbExportacion"
        Me.cbExportacion.Size = New System.Drawing.Size(15, 14)
        Me.cbExportacion.TabIndex = 196
        Me.cbExportacion.UseVisualStyleBackColor = True
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(214, 124)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderia.TabIndex = 197
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(515, 47)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 198
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(554, 43)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(85, 20)
        Me.txtFecha.TabIndex = 199
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'frmServicios_Cotizacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(866, 791)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnBuscarMercaderia)
        Me.Controls.Add(Me.cbExportacion)
        Me.Controls.Add(Me.cbCotAdicional)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.cbRepuesto)
        Me.Controls.Add(Me.lblUnidadNegocio)
        Me.Controls.Add(Me.cmbCentroCosto)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cmbArea)
        Me.Controls.Add(Me.txtContacto)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.btnAgregarContacto)
        Me.Controls.Add(Me.gbCotRepAdjuntadas)
        Me.Controls.Add(Me.gbEstado)
        Me.Controls.Add(Me.txtGlosa)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.cmbCodMon)
        Me.Controls.Add(Me.txtCodProveedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDatEntrega)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtSolicitado)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtModelo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtUnidad)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtBuscarCliente)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbMantenimiento)
        Me.Controls.Add(Me.cmbSubMarca)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblRepuesto)
        Me.Controls.Add(Me.cmbOficinas)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.txtNumCot)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios_Cotizacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmServicios_Cotizacion"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMantenimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbGarantia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMedios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbCondPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.cmbSubMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCotRepAdjuntadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCotRepAdjuntadas.ResumeLayout(False)
        CType(Me.dgvCotRepAdjuntadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumCot As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRepuesto As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtBuscarCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbMantenimiento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCodProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDatEntrega As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtSolicitado As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbSupervisor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtLucCesante As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cmbGarantia As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtFecValidez As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents cmbMedios As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUnidad As System.Windows.Forms.TextBox
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCondPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents btnAgregarContacto As System.Windows.Forms.Button
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents cmbSubMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents biActualizarOrden As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAprobar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtDescripcion As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActMoneda As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbCotRepAdjuntadas As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvCotRepAdjuntadas As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtMontoTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblMontoDscto As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoSinIGV As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblTotalMontoSinIgv As System.Windows.Forms.TextBox
    Friend WithEvents txtMontoBruto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblUnidadNegocio As System.Windows.Forms.Label
    Friend WithEvents cbRepuesto As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents cbExportacion As System.Windows.Forms.CheckBox
    Friend WithEvents cbCotAdicional As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents lblFecha As Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
End Class
