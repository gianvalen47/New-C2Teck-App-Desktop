<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudJob_Nuevo
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
        Dim cmbVendedorv_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUbicacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDestinatarios_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudJob_Nuevo))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.cmbVendedorv = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbUbicacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCodArea = New System.Windows.Forms.TextBox()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cmbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumSolicitud = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscarBeneficiado = New System.Windows.Forms.TextBox()
        Me.txtNumCotizacion = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNumPedido = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.txtBuscarCliente = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDesMer = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtModMer = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.dgvDestinatarios = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtcontacto = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.gbImprimir = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtObservaciones = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMotivo = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarBeneficiado = New System.Windows.Forms.Button()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnEliminarTodo = New System.Windows.Forms.Button()
        Me.btnCorreo = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.cmbVendedorv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.dgvDestinatarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbImprimir.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biGuardar, Me.ToolStripSeparator1, Me.biEditar, Me.ToolStripSeparator2, Me.biDeshacer, Me.ToolStripSeparator3, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(765, 31)
        Me.ToolStrip.TabIndex = 44
        Me.ToolStrip.Text = "Guardar Datos de la Cotizacion"
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Guardar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar"
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
        Me.biDeshacer.Text = "Deshacer Cambios de Solicitud de OT"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
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
        'cmbVendedorv
        '
        Me.cmbVendedorv.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbVendedorv_DesignTimeLayout.LayoutString = resources.GetString("cmbVendedorv_DesignTimeLayout.LayoutString")
        Me.cmbVendedorv.DesignTimeLayout = cmbVendedorv_DesignTimeLayout
        Me.cmbVendedorv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedorv.Location = New System.Drawing.Point(310, 51)
        Me.cmbVendedorv.Name = "cmbVendedorv"
        Me.cmbVendedorv.SelectedIndex = -1
        Me.cmbVendedorv.SelectedItem = Nothing
        Me.cmbVendedorv.SettingsKey = "cmbCodMot"
        Me.cmbVendedorv.Size = New System.Drawing.Size(231, 20)
        Me.cmbVendedorv.TabIndex = 134
        Me.cmbVendedorv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(249, 54)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 13)
        Me.Label19.TabIndex = 92
        Me.Label19.Text = "Vendedor :"
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUbicacion_DesignTimeLayout.LayoutString = resources.GetString("cmbUbicacion_DesignTimeLayout.LayoutString")
        Me.cmbUbicacion.DesignTimeLayout = cmbUbicacion_DesignTimeLayout
        Me.cmbUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacion.Location = New System.Drawing.Point(618, 51)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.SelectedIndex = -1
        Me.cmbUbicacion.SelectedItem = Nothing
        Me.cmbUbicacion.Size = New System.Drawing.Size(93, 20)
        Me.cmbUbicacion.TabIndex = 91
        Me.cmbUbicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(553, 55)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 13)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "Ubicación : "
        '
        'txtCodArea
        '
        Me.txtCodArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodArea.Location = New System.Drawing.Point(614, 21)
        Me.txtCodArea.Name = "txtCodArea"
        Me.txtCodArea.ReadOnly = True
        Me.txtCodArea.Size = New System.Drawing.Size(112, 20)
        Me.txtCodArea.TabIndex = 72
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(477, 21)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(92, 20)
        Me.txtFecha.TabIndex = 71
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbTipo
        '
        Me.cmbTipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipo_DesignTimeLayout.LayoutString")
        Me.cmbTipo.DesignTimeLayout = cmbTipo_DesignTimeLayout
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(41, 51)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.SelectedIndex = -1
        Me.cmbTipo.SelectedItem = Nothing
        Me.cmbTipo.Size = New System.Drawing.Size(202, 20)
        Me.cmbTipo.TabIndex = 79
        Me.cmbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Tipo : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(578, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Area : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(431, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Fecha : "
        '
        'txtSolicitante
        '
        Me.txtSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicitante.Location = New System.Drawing.Point(214, 21)
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.ReadOnly = True
        Me.txtSolicitante.Size = New System.Drawing.Size(211, 20)
        Me.txtSolicitante.TabIndex = 69
        Me.txtSolicitante.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(143, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Colaborador : "
        '
        'txtNumSolicitud
        '
        Me.txtNumSolicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumSolicitud.Location = New System.Drawing.Point(41, 21)
        Me.txtNumSolicitud.Name = "txtNumSolicitud"
        Me.txtNumSolicitud.ReadOnly = True
        Me.txtNumSolicitud.Size = New System.Drawing.Size(96, 20)
        Me.txtNumSolicitud.TabIndex = 67
        Me.txtNumSolicitud.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Nro : "
        '
        'txtBuscarBeneficiado
        '
        Me.txtBuscarBeneficiado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarBeneficiado.Location = New System.Drawing.Point(425, 19)
        Me.txtBuscarBeneficiado.Name = "txtBuscarBeneficiado"
        Me.txtBuscarBeneficiado.ReadOnly = True
        Me.txtBuscarBeneficiado.Size = New System.Drawing.Size(259, 20)
        Me.txtBuscarBeneficiado.TabIndex = 88
        '
        'txtNumCotizacion
        '
        Me.txtNumCotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCotizacion.Location = New System.Drawing.Point(347, 76)
        Me.txtNumCotizacion.Name = "txtNumCotizacion"
        Me.txtNumCotizacion.Size = New System.Drawing.Size(103, 20)
        Me.txtNumCotizacion.TabIndex = 86
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(372, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 87
        Me.Label17.Text = "Externo :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(281, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "Cotización : "
        '
        'txtNumPedido
        '
        Me.txtNumPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumPedido.Location = New System.Drawing.Point(66, 76)
        Me.txtNumPedido.Name = "txtNumPedido"
        Me.txtNumPedido.Size = New System.Drawing.Size(96, 20)
        Me.txtNumPedido.TabIndex = 85
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(28, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 84
        Me.Label10.Text = "P:E. : "
        '
        'txtTelefono
        '
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(622, 49)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(84, 20)
        Me.txtTelefono.TabIndex = 83
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(562, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "Teléfono : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Interno :"
        '
        'txtCargo
        '
        Me.txtCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCargo.Location = New System.Drawing.Point(346, 48)
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.Size = New System.Drawing.Size(205, 20)
        Me.txtCargo.TabIndex = 81
        '
        'txtBuscarCliente
        '
        Me.txtBuscarCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarCliente.Location = New System.Drawing.Point(66, 19)
        Me.txtBuscarCliente.Name = "txtBuscarCliente"
        Me.txtBuscarCliente.ReadOnly = True
        Me.txtBuscarCliente.Size = New System.Drawing.Size(257, 20)
        Me.txtBuscarCliente.TabIndex = 74
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(302, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Cargo : "
        '
        'txtDesMer
        '
        Me.txtDesMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesMer.Location = New System.Drawing.Point(550, 29)
        Me.txtDesMer.Name = "txtDesMer"
        Me.txtDesMer.Size = New System.Drawing.Size(161, 20)
        Me.txtDesMer.TabIndex = 80
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(476, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 79
        Me.Label14.Text = "Descripción : "
        '
        'txtModMer
        '
        Me.txtModMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModMer.Location = New System.Drawing.Point(321, 29)
        Me.txtModMer.Name = "txtModMer"
        Me.txtModMer.Size = New System.Drawing.Size(123, 20)
        Me.txtModMer.TabIndex = 78
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(271, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 13)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "Modelo : "
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.Location = New System.Drawing.Point(98, 29)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(128, 20)
        Me.txtSerie.TabIndex = 68
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 13)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Serie / # Parte :"
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(6, 34)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(737, 28)
        Me.gbEstado.TabIndex = 132
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Red
        Me.lblEstado.Location = New System.Drawing.Point(11, 8)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(709, 18)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvDestinatarios
        '
        Me.dgvDestinatarios.AllowCardSizing = False
        Me.dgvDestinatarios.ContextMenuStrip = Me.cmbOpciones
        dgvDestinatarios_DesignTimeLayout.LayoutString = resources.GetString("dgvDestinatarios_DesignTimeLayout.LayoutString")
        Me.dgvDestinatarios.DesignTimeLayout = dgvDestinatarios_DesignTimeLayout
        Me.dgvDestinatarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDestinatarios.GroupByBoxVisible = False
        Me.dgvDestinatarios.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDestinatarios.Location = New System.Drawing.Point(6, 49)
        Me.dgvDestinatarios.Name = "dgvDestinatarios"
        Me.dgvDestinatarios.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDestinatarios.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDestinatarios.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDestinatarios.Size = New System.Drawing.Size(720, 140)
        Me.dgvDestinatarios.TabIndex = 136
        Me.dgvDestinatarios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miEliminar, Me.miActualizar})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(127, 48)
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'txtcontacto
        '
        Me.txtcontacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcontacto.Location = New System.Drawing.Point(66, 48)
        Me.txtcontacto.Name = "txtcontacto"
        Me.txtcontacto.Size = New System.Drawing.Size(216, 20)
        Me.txtcontacto.TabIndex = 77
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(6, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(59, 13)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "Contacto : "
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarMercaderia)
        Me.UiGroupBox1.Controls.Add(Me.txtDesMer)
        Me.UiGroupBox1.Controls.Add(Me.Label12)
        Me.UiGroupBox1.Controls.Add(Me.Label14)
        Me.UiGroupBox1.Controls.Add(Me.txtSerie)
        Me.UiGroupBox1.Controls.Add(Me.txtModMer)
        Me.UiGroupBox1.Controls.Add(Me.Label13)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 261)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(735, 65)
        Me.UiGroupBox1.TabIndex = 201
        Me.UiGroupBox1.Text = "DATOS DE LA MERCADERÍA"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(232, 28)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarMercaderia.TabIndex = 91
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'gbImprimir
        '
        Me.gbImprimir.Controls.Add(Me.txtObservaciones)
        Me.gbImprimir.Controls.Add(Me.Label15)
        Me.gbImprimir.Controls.Add(Me.txtMotivo)
        Me.gbImprimir.Controls.Add(Me.Label16)
        Me.gbImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbImprimir.Location = New System.Drawing.Point(6, 330)
        Me.gbImprimir.Name = "gbImprimir"
        Me.gbImprimir.Size = New System.Drawing.Size(735, 63)
        Me.gbImprimir.TabIndex = 200
        Me.gbImprimir.Text = "MOTIVOS"
        Me.gbImprimir.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BackColor = System.Drawing.SystemColors.Control
        Me.txtObservaciones.ButtonEnabled = False
        Me.txtObservaciones.ButtonImage = CType(resources.GetObject("txtObservaciones.ButtonImage"), System.Drawing.Image)
        Me.txtObservaciones.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(444, 24)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.PromptChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.Size = New System.Drawing.Size(284, 24)
        Me.txtObservaciones.TabIndex = 76
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 13)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Motivo : "
        '
        'txtMotivo
        '
        Me.txtMotivo.BackColor = System.Drawing.SystemColors.Control
        Me.txtMotivo.ButtonEnabled = False
        Me.txtMotivo.ButtonImage = CType(resources.GetObject("txtMotivo.ButtonImage"), System.Drawing.Image)
        Me.txtMotivo.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivo.Location = New System.Drawing.Point(66, 24)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.PromptChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtMotivo.ReadOnly = True
        Me.txtMotivo.Size = New System.Drawing.Size(284, 24)
        Me.txtMotivo.TabIndex = 75
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(359, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 13)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Observaciones : "
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarBeneficiado)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarCliente)
        Me.UiGroupBox2.Controls.Add(Me.txtcontacto)
        Me.UiGroupBox2.Controls.Add(Me.txtBuscarCliente)
        Me.UiGroupBox2.Controls.Add(Me.Label22)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.Label17)
        Me.UiGroupBox2.Controls.Add(Me.txtTelefono)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.txtNumPedido)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.txtBuscarBeneficiado)
        Me.UiGroupBox2.Controls.Add(Me.txtCargo)
        Me.UiGroupBox2.Controls.Add(Me.txtNumCotizacion)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 152)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(735, 104)
        Me.UiGroupBox2.TabIndex = 200
        Me.UiGroupBox2.Text = "DATOS DEL CLIENTE"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarBeneficiado
        '
        Me.btnBuscarBeneficiado.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarBeneficiado.Location = New System.Drawing.Point(690, 18)
        Me.btnBuscarBeneficiado.Name = "btnBuscarBeneficiado"
        Me.btnBuscarBeneficiado.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarBeneficiado.TabIndex = 90
        Me.btnBuscarBeneficiado.TabStop = False
        Me.btnBuscarBeneficiado.UseVisualStyleBackColor = True
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(329, 18)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarCliente.TabIndex = 89
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.cmbVendedorv)
        Me.UiGroupBox3.Controls.Add(Me.txtNumSolicitud)
        Me.UiGroupBox3.Controls.Add(Me.Label19)
        Me.UiGroupBox3.Controls.Add(Me.Label1)
        Me.UiGroupBox3.Controls.Add(Me.cmbUbicacion)
        Me.UiGroupBox3.Controls.Add(Me.Label2)
        Me.UiGroupBox3.Controls.Add(Me.Label18)
        Me.UiGroupBox3.Controls.Add(Me.txtSolicitante)
        Me.UiGroupBox3.Controls.Add(Me.txtCodArea)
        Me.UiGroupBox3.Controls.Add(Me.Label3)
        Me.UiGroupBox3.Controls.Add(Me.txtFecha)
        Me.UiGroupBox3.Controls.Add(Me.Label4)
        Me.UiGroupBox3.Controls.Add(Me.cmbTipo)
        Me.UiGroupBox3.Controls.Add(Me.Label7)
        Me.UiGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox3.Location = New System.Drawing.Point(6, 65)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(735, 83)
        Me.UiGroupBox3.TabIndex = 200
        Me.UiGroupBox3.Text = "DATOS DE LA SOLICITUD"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEnviar)
        Me.GroupBox1.Controls.Add(Me.btnEliminarTodo)
        Me.GroupBox1.Controls.Add(Me.btnCorreo)
        Me.GroupBox1.Controls.Add(Me.dgvDestinatarios)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 399)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(735, 199)
        Me.GroupBox1.TabIndex = 202
        Me.GroupBox1.TabStop = False
        '
        'btnEnviar
        '
        Me.btnEnviar.Image = CType(resources.GetObject("btnEnviar.Image"), System.Drawing.Image)
        Me.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnviar.Location = New System.Drawing.Point(655, 19)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(71, 25)
        Me.btnEnviar.TabIndex = 139
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'btnEliminarTodo
        '
        Me.btnEliminarTodo.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.btnEliminarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarTodo.Location = New System.Drawing.Point(554, 19)
        Me.btnEliminarTodo.Name = "btnEliminarTodo"
        Me.btnEliminarTodo.Size = New System.Drawing.Size(95, 25)
        Me.btnEliminarTodo.TabIndex = 138
        Me.btnEliminarTodo.Text = "Eliminar Todo"
        Me.btnEliminarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminarTodo.UseVisualStyleBackColor = True
        '
        'btnCorreo
        '
        Me.btnCorreo.Image = CType(resources.GetObject("btnCorreo.Image"), System.Drawing.Image)
        Me.btnCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCorreo.Location = New System.Drawing.Point(477, 19)
        Me.btnCorreo.Name = "btnCorreo"
        Me.btnCorreo.Size = New System.Drawing.Size(71, 25)
        Me.btnCorreo.TabIndex = 137
        Me.btnCorreo.Text = "Correo"
        Me.btnCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCorreo.UseVisualStyleBackColor = True
        '
        'frmSolicitudJob_Nuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(765, 622)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.gbImprimir)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gbEstado)
        Me.Controls.Add(Me.ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolicitudJob_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud OT Nuevo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.cmbVendedorv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.dgvDestinatarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.gbImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbImprimir.ResumeLayout(False)
        Me.gbImprimir.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumSolicitud As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNumPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCargo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDesMer As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtModMer As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCodArea As System.Windows.Forms.TextBox
    Friend WithEvents dgvDestinatarios As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarBeneficiado As System.Windows.Forms.TextBox
    Friend WithEvents cmbUbicacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbVendedorv As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtcontacto As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbImprimir As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtObservaciones As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMotivo As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarBeneficiado As System.Windows.Forms.Button
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents btnEliminarTodo As System.Windows.Forms.Button
    Friend WithEvents btnCorreo As System.Windows.Forms.Button
End Class
