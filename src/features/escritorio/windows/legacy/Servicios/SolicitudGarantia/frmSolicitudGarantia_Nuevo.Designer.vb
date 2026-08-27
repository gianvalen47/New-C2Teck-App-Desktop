<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSolicitudGarantia_Nuevo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudGarantia_Nuevo))
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbContactoCliente_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbAplicacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbSupervisor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEnviar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.cbSolicitud = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecLlegadaAlm = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFacturaImportacionAlm = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtPedidoAlm = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.btnComentarios = New System.Windows.Forms.Button()
        Me.btnCorreccion = New System.Windows.Forms.Button()
        Me.btnCausa = New System.Windows.Forms.Button()
        Me.btnQueja = New System.Windows.Forms.Button()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtIdAfa = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCantPzaPrimaria = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtSeriePiezaPrimaria = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtFecUltRepPzaFallada = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecReparacionGarantia = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecArranqueInicial = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbCores = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbRepuestos = New System.Windows.Forms.CheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtDiasServTotales = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.txtPartePzaPrimaria = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtHorasUltRepPzaFallada = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDescPzaPrimaria = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtHorasTotalMotor = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtDiasServicioPzaFallada = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.txtDistanciaKm = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCorreccion = New System.Windows.Forms.TextBox()
        Me.txtLugarServicio = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtSerieVehiculo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMarcaEquipo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtModeloEquipo = New System.Windows.Forms.TextBox()
        Me.txtCausa = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbCliente = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtVale = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtOT = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnAgregarContacto = New Janus.Windows.EditControls.UIButton()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbContactoCliente = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmailCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtQuejaDemandaProblema = New System.Windows.Forms.TextBox()
        Me.txtHorasViajeIdaVuelta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.gbMotor = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cmbAplicacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtModMotor = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSerieMotor = New System.Windows.Forms.TextBox()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTecnico = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSupervisor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAtender = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRechazar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizarEstado = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cbSolicitud.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        Me.gbEstado.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cbCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cbCliente.SuspendLayout()
        CType(Me.cmbContactoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbMotor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMotor.SuspendLayout()
        CType(Me.cmbAplicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator5, Me.biEditar, Me.ToolStripSeparator1, Me.biEnviar, Me.ToolStripSeparator4, Me.biDeshacer, Me.ToolStripSeparator3, Me.biSalir, Me.ToolStripSeparator6})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1033, 31)
        Me.ToolStrip.TabIndex = 114
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Guardar Cambios"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Datos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biEnviar
        '
        Me.biEnviar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEnviar.Image = CType(resources.GetObject("biEnviar.Image"), System.Drawing.Image)
        Me.biEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEnviar.Name = "biEnviar"
        Me.biEnviar.Size = New System.Drawing.Size(28, 28)
        Me.biEnviar.Text = "Enviar Formato AFA"
        Me.biEnviar.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios de Solicitud de Garantía"
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(964, 55)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarPersona.TabIndex = 8
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'cbSolicitud
        '
        Me.cbSolicitud.Controls.Add(Me.UiGroupBox3)
        Me.cbSolicitud.Controls.Add(Me.btnComentarios)
        Me.cbSolicitud.Controls.Add(Me.btnCorreccion)
        Me.cbSolicitud.Controls.Add(Me.btnCausa)
        Me.cbSolicitud.Controls.Add(Me.btnQueja)
        Me.cbSolicitud.Controls.Add(Me.Label41)
        Me.cbSolicitud.Controls.Add(Me.Label40)
        Me.cbSolicitud.Controls.Add(Me.Label39)
        Me.cbSolicitud.Controls.Add(Me.Label35)
        Me.cbSolicitud.Controls.Add(Me.Label34)
        Me.cbSolicitud.Controls.Add(Me.Label24)
        Me.cbSolicitud.Controls.Add(Me.gbEstado)
        Me.cbSolicitud.Controls.Add(Me.txtIdAfa)
        Me.cbSolicitud.Controls.Add(Me.Label22)
        Me.cbSolicitud.Controls.Add(Me.Label21)
        Me.cbSolicitud.Controls.Add(Me.UiGroupBox2)
        Me.cbSolicitud.Controls.Add(Me.txtComentarios)
        Me.cbSolicitud.Controls.Add(Me.txtDistanciaKm)
        Me.cbSolicitud.Controls.Add(Me.Label18)
        Me.cbSolicitud.Controls.Add(Me.Label33)
        Me.cbSolicitud.Controls.Add(Me.txtCorreccion)
        Me.cbSolicitud.Controls.Add(Me.txtLugarServicio)
        Me.cbSolicitud.Controls.Add(Me.Label17)
        Me.cbSolicitud.Controls.Add(Me.Label32)
        Me.cbSolicitud.Controls.Add(Me.Label15)
        Me.cbSolicitud.Controls.Add(Me.UiGroupBox1)
        Me.cbSolicitud.Controls.Add(Me.txtCausa)
        Me.cbSolicitud.Controls.Add(Me.Label11)
        Me.cbSolicitud.Controls.Add(Me.cbCliente)
        Me.cbSolicitud.Controls.Add(Me.txtQuejaDemandaProblema)
        Me.cbSolicitud.Controls.Add(Me.txtHorasViajeIdaVuelta)
        Me.cbSolicitud.Controls.Add(Me.Label31)
        Me.cbSolicitud.Controls.Add(Me.gbMotor)
        Me.cbSolicitud.Controls.Add(Me.txtTecnico)
        Me.cbSolicitud.Controls.Add(Me.btnBuscarPersona)
        Me.cbSolicitud.Controls.Add(Me.Label3)
        Me.cbSolicitud.Controls.Add(Me.Label2)
        Me.cbSolicitud.Controls.Add(Me.cmbSupervisor)
        Me.cbSolicitud.Controls.Add(Me.txtNumJob)
        Me.cbSolicitud.Controls.Add(Me.Label14)
        Me.cbSolicitud.Controls.Add(Me.btnBuscarJob)
        Me.cbSolicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSolicitud.Location = New System.Drawing.Point(5, 33)
        Me.cbSolicitud.Name = "cbSolicitud"
        Me.cbSolicitud.Size = New System.Drawing.Size(1011, 579)
        Me.cbSolicitud.TabIndex = 119
        Me.cbSolicitud.Text = "Datos de Formato de ORDEN DE REPARACIÓN"
        Me.cbSolicitud.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.txtFecLlegadaAlm)
        Me.UiGroupBox3.Controls.Add(Me.txtFacturaImportacionAlm)
        Me.UiGroupBox3.Controls.Add(Me.Label43)
        Me.UiGroupBox3.Controls.Add(Me.txtPedidoAlm)
        Me.UiGroupBox3.Controls.Add(Me.Label44)
        Me.UiGroupBox3.Controls.Add(Me.Label45)
        Me.UiGroupBox3.Location = New System.Drawing.Point(10, 317)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(992, 44)
        Me.UiGroupBox3.TabIndex = 291
        Me.UiGroupBox3.Text = "Datos de Almacen"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFecLlegadaAlm
        '
        '
        '
        '
        Me.txtFecLlegadaAlm.DropDownCalendar.Name = ""
        Me.txtFecLlegadaAlm.DropDownCalendar.Visible = False
        Me.txtFecLlegadaAlm.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecLlegadaAlm.IsNullDate = True
        Me.txtFecLlegadaAlm.Location = New System.Drawing.Point(892, 18)
        Me.txtFecLlegadaAlm.Name = "txtFecLlegadaAlm"
        Me.txtFecLlegadaAlm.Size = New System.Drawing.Size(94, 20)
        Me.txtFecLlegadaAlm.TabIndex = 240
        Me.txtFecLlegadaAlm.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFacturaImportacionAlm
        '
        Me.txtFacturaImportacionAlm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFacturaImportacionAlm.Location = New System.Drawing.Point(135, 18)
        Me.txtFacturaImportacionAlm.Name = "txtFacturaImportacionAlm"
        Me.txtFacturaImportacionAlm.Size = New System.Drawing.Size(175, 20)
        Me.txtFacturaImportacionAlm.TabIndex = 20
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(9, 21)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(120, 13)
        Me.Label43.TabIndex = 236
        Me.Label43.Text = "Factura Importación"
        '
        'txtPedidoAlm
        '
        Me.txtPedidoAlm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPedidoAlm.Location = New System.Drawing.Point(477, 18)
        Me.txtPedidoAlm.Name = "txtPedidoAlm"
        Me.txtPedidoAlm.Size = New System.Drawing.Size(200, 20)
        Me.txtPedidoAlm.TabIndex = 21
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(425, 21)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(46, 13)
        Me.Label44.TabIndex = 238
        Me.Label44.Text = "Pedido"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(795, 21)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(91, 13)
        Me.Label45.TabIndex = 239
        Me.Label45.Text = "Fecha Llegada"
        '
        'btnComentarios
        '
        Me.btnComentarios.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnComentarios.Location = New System.Drawing.Point(977, 527)
        Me.btnComentarios.Name = "btnComentarios"
        Me.btnComentarios.Size = New System.Drawing.Size(25, 22)
        Me.btnComentarios.TabIndex = 290
        Me.btnComentarios.TabStop = False
        Me.btnComentarios.UseVisualStyleBackColor = True
        '
        'btnCorreccion
        '
        Me.btnCorreccion.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnCorreccion.Location = New System.Drawing.Point(964, 477)
        Me.btnCorreccion.Name = "btnCorreccion"
        Me.btnCorreccion.Size = New System.Drawing.Size(25, 22)
        Me.btnCorreccion.TabIndex = 289
        Me.btnCorreccion.TabStop = False
        Me.btnCorreccion.UseVisualStyleBackColor = True
        '
        'btnCausa
        '
        Me.btnCausa.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnCausa.Location = New System.Drawing.Point(964, 430)
        Me.btnCausa.Name = "btnCausa"
        Me.btnCausa.Size = New System.Drawing.Size(25, 22)
        Me.btnCausa.TabIndex = 288
        Me.btnCausa.TabStop = False
        Me.btnCausa.UseVisualStyleBackColor = True
        '
        'btnQueja
        '
        Me.btnQueja.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnQueja.Location = New System.Drawing.Point(964, 383)
        Me.btnQueja.Name = "btnQueja"
        Me.btnQueja.Size = New System.Drawing.Size(25, 22)
        Me.btnQueja.TabIndex = 287
        Me.btnQueja.TabStop = False
        Me.btnQueja.UseVisualStyleBackColor = True
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Red
        Me.Label41.Location = New System.Drawing.Point(990, 504)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(13, 15)
        Me.Label41.TabIndex = 286
        Me.Label41.Text = "*"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Red
        Me.Label40.Location = New System.Drawing.Point(990, 457)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(13, 15)
        Me.Label40.TabIndex = 285
        Me.Label40.Text = "*"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Red
        Me.Label39.Location = New System.Drawing.Point(990, 407)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(13, 15)
        Me.Label39.TabIndex = 284
        Me.Label39.Text = "*"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Red
        Me.Label35.Location = New System.Drawing.Point(989, 59)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(13, 15)
        Me.Label35.TabIndex = 284
        Me.Label35.Text = "*"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Red
        Me.Label34.Location = New System.Drawing.Point(602, 59)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(13, 15)
        Me.Label34.TabIndex = 283
        Me.Label34.Text = "*"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(352, 26)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(13, 15)
        Me.Label24.TabIndex = 282
        Me.Label24.Text = "*"
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.Color.Transparent
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(819, 7)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(183, 40)
        Me.gbEstado.TabIndex = 281
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(6, 10)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(171, 26)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtIdAfa
        '
        Me.txtIdAfa.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdAfa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdAfa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdAfa.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdAfa.Location = New System.Drawing.Point(114, 23)
        Me.txtIdAfa.MaxLength = 20
        Me.txtIdAfa.Name = "txtIdAfa"
        Me.txtIdAfa.ReadOnly = True
        Me.txtIdAfa.Size = New System.Drawing.Size(86, 20)
        Me.txtIdAfa.TabIndex = 0
        Me.txtIdAfa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(19, 27)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(90, 13)
        Me.Label22.TabIndex = 280
        Me.Label22.Text = "Nº Orden Rep."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(15, 532)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 13)
        Me.Label21.TabIndex = 271
        Me.Label21.Text = "Comentarios :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtCantPzaPrimaria)
        Me.UiGroupBox2.Controls.Add(Me.Label42)
        Me.UiGroupBox2.Controls.Add(Me.txtSeriePiezaPrimaria)
        Me.UiGroupBox2.Controls.Add(Me.Label29)
        Me.UiGroupBox2.Controls.Add(Me.cmbUnidad)
        Me.UiGroupBox2.Controls.Add(Me.txtFecUltRepPzaFallada)
        Me.UiGroupBox2.Controls.Add(Me.txtFecReparacionGarantia)
        Me.UiGroupBox2.Controls.Add(Me.txtFecArranqueInicial)
        Me.UiGroupBox2.Controls.Add(Me.cbCores)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.cbRepuestos)
        Me.UiGroupBox2.Controls.Add(Me.Label27)
        Me.UiGroupBox2.Controls.Add(Me.txtDiasServTotales)
        Me.UiGroupBox2.Controls.Add(Me.txtPartePzaPrimaria)
        Me.UiGroupBox2.Controls.Add(Me.Label19)
        Me.UiGroupBox2.Controls.Add(Me.Label26)
        Me.UiGroupBox2.Controls.Add(Me.txtHorasUltRepPzaFallada)
        Me.UiGroupBox2.Controls.Add(Me.txtDescPzaPrimaria)
        Me.UiGroupBox2.Controls.Add(Me.lblTotal)
        Me.UiGroupBox2.Controls.Add(Me.txtHorasTotalMotor)
        Me.UiGroupBox2.Controls.Add(Me.Label20)
        Me.UiGroupBox2.Controls.Add(Me.Label25)
        Me.UiGroupBox2.Controls.Add(Me.txtDiasServicioPzaFallada)
        Me.UiGroupBox2.Controls.Add(Me.Label23)
        Me.UiGroupBox2.Location = New System.Drawing.Point(10, 216)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(992, 95)
        Me.UiGroupBox2.TabIndex = 23
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtCantPzaPrimaria
        '
        Me.txtCantPzaPrimaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantPzaPrimaria.Location = New System.Drawing.Point(768, 69)
        Me.txtCantPzaPrimaria.Maximum = 300000
        Me.txtCantPzaPrimaria.MaxLength = 200
        Me.txtCantPzaPrimaria.Name = "txtCantPzaPrimaria"
        Me.txtCantPzaPrimaria.Size = New System.Drawing.Size(58, 20)
        Me.txtCantPzaPrimaria.TabIndex = 269
        Me.txtCantPzaPrimaria.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCantPzaPrimaria.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(727, 72)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(37, 13)
        Me.Label42.TabIndex = 268
        Me.Label42.Text = "Cant."
        '
        'txtSeriePiezaPrimaria
        '
        Me.txtSeriePiezaPrimaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeriePiezaPrimaria.Location = New System.Drawing.Point(598, 69)
        Me.txtSeriePiezaPrimaria.Name = "txtSeriePiezaPrimaria"
        Me.txtSeriePiezaPrimaria.Size = New System.Drawing.Size(118, 20)
        Me.txtSeriePiezaPrimaria.TabIndex = 267
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(541, 72)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(54, 13)
        Me.Label29.TabIndex = 266
        Me.Label29.Text = "N° Serie"
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Location = New System.Drawing.Point(907, 12)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.ReadOnly = True
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(76, 20)
        Me.cmbUnidad.TabIndex = 28
        Me.cmbUnidad.TabStop = False
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtFecUltRepPzaFallada
        '
        '
        '
        '
        Me.txtFecUltRepPzaFallada.DropDownCalendar.Name = ""
        Me.txtFecUltRepPzaFallada.DropDownCalendar.Visible = False
        Me.txtFecUltRepPzaFallada.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecUltRepPzaFallada.IsNullDate = True
        Me.txtFecUltRepPzaFallada.Location = New System.Drawing.Point(233, 40)
        Me.txtFecUltRepPzaFallada.Name = "txtFecUltRepPzaFallada"
        Me.txtFecUltRepPzaFallada.NullButtonText = "Ninguno"
        Me.txtFecUltRepPzaFallada.ShowNullButton = True
        Me.txtFecUltRepPzaFallada.Size = New System.Drawing.Size(96, 20)
        Me.txtFecUltRepPzaFallada.TabIndex = 29
        Me.txtFecUltRepPzaFallada.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecReparacionGarantia
        '
        '
        '
        '
        Me.txtFecReparacionGarantia.DropDownCalendar.Name = ""
        Me.txtFecReparacionGarantia.DropDownCalendar.Visible = False
        Me.txtFecReparacionGarantia.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecReparacionGarantia.IsNullDate = True
        Me.txtFecReparacionGarantia.Location = New System.Drawing.Point(405, 12)
        Me.txtFecReparacionGarantia.Name = "txtFecReparacionGarantia"
        Me.txtFecReparacionGarantia.Size = New System.Drawing.Size(94, 20)
        Me.txtFecReparacionGarantia.TabIndex = 25
        Me.txtFecReparacionGarantia.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecArranqueInicial
        '
        '
        '
        '
        Me.txtFecArranqueInicial.DropDownCalendar.Name = ""
        Me.txtFecArranqueInicial.DropDownCalendar.Visible = False
        Me.txtFecArranqueInicial.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecArranqueInicial.IsNullDate = True
        Me.txtFecArranqueInicial.Location = New System.Drawing.Point(140, 12)
        Me.txtFecArranqueInicial.Name = "txtFecArranqueInicial"
        Me.txtFecArranqueInicial.Size = New System.Drawing.Size(94, 20)
        Me.txtFecArranqueInicial.TabIndex = 24
        Me.txtFecArranqueInicial.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbCores
        '
        Me.cbCores.AutoSize = True
        Me.cbCores.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbCores.Location = New System.Drawing.Point(925, 70)
        Me.cbCores.Name = "cbCores"
        Me.cbCores.Size = New System.Drawing.Size(58, 17)
        Me.cbCores.TabIndex = 35
        Me.cbCores.Text = "Cores"
        Me.cbCores.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 13)
        Me.Label7.TabIndex = 241
        Me.Label7.Text = "Fec. Arranque Inicial"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(272, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 13)
        Me.Label9.TabIndex = 243
        Me.Label9.Text = "Fec. Rep. x Garantía"
        '
        'cbRepuestos
        '
        Me.cbRepuestos.AutoSize = True
        Me.cbRepuestos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbRepuestos.Location = New System.Drawing.Point(832, 70)
        Me.cbRepuestos.Name = "cbRepuestos"
        Me.cbRepuestos.Size = New System.Drawing.Size(86, 17)
        Me.cbRepuestos.TabIndex = 34
        Me.cbRepuestos.Text = "Repuestos"
        Me.cbRepuestos.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(9, 72)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(133, 13)
        Me.Label27.TabIndex = 265
        Me.Label27.Text = "Nº Parte Pza. Primaria"
        '
        'txtDiasServTotales
        '
        Me.txtDiasServTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasServTotales.Location = New System.Drawing.Point(653, 12)
        Me.txtDiasServTotales.Maximum = 300000
        Me.txtDiasServTotales.MaxLength = 200
        Me.txtDiasServTotales.Name = "txtDiasServTotales"
        Me.txtDiasServTotales.Size = New System.Drawing.Size(72, 20)
        Me.txtDiasServTotales.TabIndex = 26
        Me.txtDiasServTotales.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDiasServTotales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPartePzaPrimaria
        '
        Me.txtPartePzaPrimaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartePzaPrimaria.Location = New System.Drawing.Point(148, 69)
        Me.txtPartePzaPrimaria.Name = "txtPartePzaPrimaria"
        Me.txtPartePzaPrimaria.Size = New System.Drawing.Size(137, 20)
        Me.txtPartePzaPrimaria.TabIndex = 32
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(536, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(111, 13)
        Me.Label19.TabIndex = 250
        Me.Label19.Text = "Días Servicio Tot."
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(291, 72)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(118, 13)
        Me.Label26.TabIndex = 263
        Me.Label26.Text = "Desc. Pza. Primaria"
        '
        'txtHorasUltRepPzaFallada
        '
        Me.txtHorasUltRepPzaFallada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorasUltRepPzaFallada.Location = New System.Drawing.Point(907, 40)
        Me.txtHorasUltRepPzaFallada.MaxLength = 10
        Me.txtHorasUltRepPzaFallada.Name = "txtHorasUltRepPzaFallada"
        Me.txtHorasUltRepPzaFallada.Size = New System.Drawing.Size(76, 20)
        Me.txtHorasUltRepPzaFallada.TabIndex = 31
        Me.txtHorasUltRepPzaFallada.Text = "0.00"
        Me.txtHorasUltRepPzaFallada.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHorasUltRepPzaFallada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDescPzaPrimaria
        '
        Me.txtDescPzaPrimaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescPzaPrimaria.Location = New System.Drawing.Point(415, 69)
        Me.txtDescPzaPrimaria.Name = "txtDescPzaPrimaria"
        Me.txtDescPzaPrimaria.Size = New System.Drawing.Size(118, 20)
        Me.txtDescPzaPrimaria.TabIndex = 33
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(746, 16)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(66, 13)
        Me.lblTotal.TabIndex = 248
        Me.lblTotal.Text = "Tot. Motor"
        '
        'txtHorasTotalMotor
        '
        Me.txtHorasTotalMotor.DecimalDigits = 3
        Me.txtHorasTotalMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorasTotalMotor.Location = New System.Drawing.Point(818, 12)
        Me.txtHorasTotalMotor.MaxLength = 10
        Me.txtHorasTotalMotor.Name = "txtHorasTotalMotor"
        Me.txtHorasTotalMotor.Size = New System.Drawing.Size(85, 20)
        Me.txtHorasTotalMotor.TabIndex = 27
        Me.txtHorasTotalMotor.Text = "0.000"
        Me.txtHorasTotalMotor.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtHorasTotalMotor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(9, 44)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(218, 13)
        Me.Label20.TabIndex = 254
        Me.Label20.Text = "Fec. Ult. Rep. (Montaje Pza. Fallada)"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(746, 44)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(155, 13)
        Me.Label25.TabIndex = 259
        Me.Label25.Text = "Hrs. Ult. Rep. Pza Fallada"
        '
        'txtDiasServicioPzaFallada
        '
        Me.txtDiasServicioPzaFallada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasServicioPzaFallada.Location = New System.Drawing.Point(605, 40)
        Me.txtDiasServicioPzaFallada.Maximum = 300000
        Me.txtDiasServicioPzaFallada.MaxLength = 200
        Me.txtDiasServicioPzaFallada.Name = "txtDiasServicioPzaFallada"
        Me.txtDiasServicioPzaFallada.Size = New System.Drawing.Size(72, 20)
        Me.txtDiasServicioPzaFallada.TabIndex = 30
        Me.txtDiasServicioPzaFallada.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtDiasServicioPzaFallada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(423, 44)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(176, 13)
        Me.Label23.TabIndex = 257
        Me.Label23.Text = "Días en Servicio Pza. Fallada"
        '
        'txtComentarios
        '
        Me.txtComentarios.Location = New System.Drawing.Point(121, 518)
        Me.txtComentarios.MaxLength = 327670000
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComentarios.Size = New System.Drawing.Size(854, 43)
        Me.txtComentarios.TabIndex = 39
        '
        'txtDistanciaKm
        '
        Me.txtDistanciaKm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistanciaKm.Location = New System.Drawing.Point(715, 24)
        Me.txtDistanciaKm.MaxLength = 10
        Me.txtDistanciaKm.Name = "txtDistanciaKm"
        Me.txtDistanciaKm.Size = New System.Drawing.Size(80, 20)
        Me.txtDistanciaKm.TabIndex = 4
        Me.txtDistanciaKm.Text = "0.00"
        Me.txtDistanciaKm.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDistanciaKm.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 483)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 13)
        Me.Label18.TabIndex = 269
        Me.Label18.Text = "Corección :"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(628, 26)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(81, 13)
        Me.Label33.TabIndex = 273
        Me.Label33.Text = "Distancia Km"
        '
        'txtCorreccion
        '
        Me.txtCorreccion.Location = New System.Drawing.Point(121, 469)
        Me.txtCorreccion.MaxLength = 327670000
        Me.txtCorreccion.Multiline = True
        Me.txtCorreccion.Name = "txtCorreccion"
        Me.txtCorreccion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCorreccion.Size = New System.Drawing.Size(840, 43)
        Me.txtCorreccion.TabIndex = 38
        '
        'txtLugarServicio
        '
        Me.txtLugarServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLugarServicio.Location = New System.Drawing.Point(114, 54)
        Me.txtLugarServicio.Name = "txtLugarServicio"
        Me.txtLugarServicio.Size = New System.Drawing.Size(206, 20)
        Me.txtLugarServicio.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 392)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 13)
        Me.Label17.TabIndex = 267
        Me.Label17.Text = "o problema :"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(19, 58)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(89, 13)
        Me.Label32.TabIndex = 276
        Me.Label32.Text = "Lugar Servicio"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 432)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 13)
        Me.Label15.TabIndex = 266
        Me.Label15.Text = "Causa :"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtSerieVehiculo)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.txtMarcaEquipo)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.txtModeloEquipo)
        Me.UiGroupBox1.Location = New System.Drawing.Point(10, 169)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(992, 44)
        Me.UiGroupBox1.TabIndex = 19
        Me.UiGroupBox1.Text = "Datos de Equipo"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtSerieVehiculo
        '
        Me.txtSerieVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieVehiculo.Location = New System.Drawing.Point(104, 18)
        Me.txtSerieVehiculo.Name = "txtSerieVehiculo"
        Me.txtSerieVehiculo.Size = New System.Drawing.Size(175, 20)
        Me.txtSerieVehiculo.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = "Serie Vehiculo"
        '
        'txtMarcaEquipo
        '
        Me.txtMarcaEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarcaEquipo.Location = New System.Drawing.Point(426, 18)
        Me.txtMarcaEquipo.Name = "txtMarcaEquipo"
        Me.txtMarcaEquipo.Size = New System.Drawing.Size(200, 20)
        Me.txtMarcaEquipo.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(335, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 238
        Me.Label5.Text = "Marca Equipo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(684, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 239
        Me.Label6.Text = "Modelo Equipo"
        '
        'txtModeloEquipo
        '
        Me.txtModeloEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModeloEquipo.Location = New System.Drawing.Point(781, 18)
        Me.txtModeloEquipo.Name = "txtModeloEquipo"
        Me.txtModeloEquipo.Size = New System.Drawing.Size(202, 20)
        Me.txtModeloEquipo.TabIndex = 22
        '
        'txtCausa
        '
        Me.txtCausa.Location = New System.Drawing.Point(121, 420)
        Me.txtCausa.MaxLength = 327670000
        Me.txtCausa.Multiline = True
        Me.txtCausa.Name = "txtCausa"
        Me.txtCausa.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCausa.Size = New System.Drawing.Size(840, 43)
        Me.txtCausa.TabIndex = 37
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 379)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 13)
        Me.Label11.TabIndex = 264
        Me.Label11.Text = "Queja, demanda "
        '
        'cbCliente
        '
        Me.cbCliente.Controls.Add(Me.txtVale)
        Me.cbCliente.Controls.Add(Me.Label28)
        Me.cbCliente.Controls.Add(Me.txtOT)
        Me.cbCliente.Controls.Add(Me.Label16)
        Me.cbCliente.Controls.Add(Me.btnAgregarContacto)
        Me.cbCliente.Controls.Add(Me.Label36)
        Me.cbCliente.Controls.Add(Me.cmbContactoCliente)
        Me.cbCliente.Controls.Add(Me.Label30)
        Me.cbCliente.Controls.Add(Me.Label1)
        Me.cbCliente.Controls.Add(Me.txtEmailCliente)
        Me.cbCliente.Controls.Add(Me.btnBuscarCliente)
        Me.cbCliente.Controls.Add(Me.Label8)
        Me.cbCliente.Controls.Add(Me.txtCliente)
        Me.cbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.Location = New System.Drawing.Point(10, 77)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(992, 43)
        Me.cbCliente.TabIndex = 9
        Me.cbCliente.Text = "Datos del Cliente"
        Me.cbCliente.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtVale
        '
        Me.txtVale.Location = New System.Drawing.Point(918, 15)
        Me.txtVale.Name = "txtVale"
        Me.txtVale.ReadOnly = True
        Me.txtVale.Size = New System.Drawing.Size(68, 20)
        Me.txtVale.TabIndex = 288
        Me.txtVale.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(864, 19)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(54, 13)
        Me.Label28.TabIndex = 287
        Me.Label28.Text = "N° Vale:"
        '
        'txtOT
        '
        Me.txtOT.Location = New System.Drawing.Point(795, 15)
        Me.txtOT.Name = "txtOT"
        Me.txtOT.ReadOnly = True
        Me.txtOT.Size = New System.Drawing.Size(66, 20)
        Me.txtOT.TabIndex = 286
        Me.txtOT.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(761, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 13)
        Me.Label16.TabIndex = 285
        Me.Label16.Text = "OT :"
        '
        'btnAgregarContacto
        '
        Me.btnAgregarContacto.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnAgregarContacto.Location = New System.Drawing.Point(525, 15)
        Me.btnAgregarContacto.Name = "btnAgregarContacto"
        Me.btnAgregarContacto.Size = New System.Drawing.Size(23, 21)
        Me.btnAgregarContacto.TabIndex = 284
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(310, 18)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(13, 15)
        Me.Label36.TabIndex = 283
        Me.Label36.Text = "*"
        '
        'cmbContactoCliente
        '
        Me.cmbContactoCliente.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbContactoCliente_DesignTimeLayout.LayoutString = resources.GetString("cmbContactoCliente_DesignTimeLayout.LayoutString")
        Me.cmbContactoCliente.DesignTimeLayout = cmbContactoCliente_DesignTimeLayout
        Me.cmbContactoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmbContactoCliente.Location = New System.Drawing.Point(388, 16)
        Me.cmbContactoCliente.Name = "cmbContactoCliente"
        Me.cmbContactoCliente.SelectedIndex = -1
        Me.cmbContactoCliente.SelectedItem = Nothing
        Me.cmbContactoCliente.Size = New System.Drawing.Size(131, 20)
        Me.cmbContactoCliente.TabIndex = 13
        Me.cmbContactoCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(324, 20)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(58, 13)
        Me.Label30.TabIndex = 121
        Me.Label30.Text = "Contacto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Cliente"
        '
        'txtEmailCliente
        '
        Me.txtEmailCliente.Location = New System.Drawing.Point(598, 16)
        Me.txtEmailCliente.Name = "txtEmailCliente"
        Me.txtEmailCliente.ReadOnly = True
        Me.txtEmailCliente.Size = New System.Drawing.Size(153, 20)
        Me.txtEmailCliente.TabIndex = 12
        Me.txtEmailCliente.TabStop = False
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(285, 15)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarCliente.TabIndex = 11
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(554, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "Email :"
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Control
        Me.txtCliente.Location = New System.Drawing.Point(61, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(218, 20)
        Me.txtCliente.TabIndex = 10
        '
        'txtQuejaDemandaProblema
        '
        Me.txtQuejaDemandaProblema.Location = New System.Drawing.Point(121, 371)
        Me.txtQuejaDemandaProblema.MaxLength = 327670000
        Me.txtQuejaDemandaProblema.Multiline = True
        Me.txtQuejaDemandaProblema.Name = "txtQuejaDemandaProblema"
        Me.txtQuejaDemandaProblema.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtQuejaDemandaProblema.Size = New System.Drawing.Size(840, 43)
        Me.txtQuejaDemandaProblema.TabIndex = 36
        '
        'txtHorasViajeIdaVuelta
        '
        Me.txtHorasViajeIdaVuelta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorasViajeIdaVuelta.Location = New System.Drawing.Point(520, 24)
        Me.txtHorasViajeIdaVuelta.MaxLength = 10
        Me.txtHorasViajeIdaVuelta.Name = "txtHorasViajeIdaVuelta"
        Me.txtHorasViajeIdaVuelta.Size = New System.Drawing.Size(81, 20)
        Me.txtHorasViajeIdaVuelta.TabIndex = 3
        Me.txtHorasViajeIdaVuelta.Text = "0.00"
        Me.txtHorasViajeIdaVuelta.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHorasViajeIdaVuelta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(380, 26)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(134, 13)
        Me.Label31.TabIndex = 270
        Me.Label31.Text = "Hrs. Viaje Ida y Vuelta"
        '
        'gbMotor
        '
        Me.gbMotor.Controls.Add(Me.Label38)
        Me.gbMotor.Controls.Add(Me.Label37)
        Me.gbMotor.Controls.Add(Me.cmbAplicacion)
        Me.gbMotor.Controls.Add(Me.Label10)
        Me.gbMotor.Controls.Add(Me.txtModMotor)
        Me.gbMotor.Controls.Add(Me.Label13)
        Me.gbMotor.Controls.Add(Me.txtSerieMotor)
        Me.gbMotor.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbMotor.Controls.Add(Me.Label12)
        Me.gbMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMotor.Location = New System.Drawing.Point(10, 123)
        Me.gbMotor.Name = "gbMotor"
        Me.gbMotor.Size = New System.Drawing.Size(992, 43)
        Me.gbMotor.TabIndex = 14
        Me.gbMotor.Text = "Datos de Motor"
        Me.gbMotor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Red
        Me.Label38.Location = New System.Drawing.Point(646, 18)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(13, 15)
        Me.Label38.TabIndex = 284
        Me.Label38.Text = "*"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Red
        Me.Label37.Location = New System.Drawing.Point(266, 19)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(13, 15)
        Me.Label37.TabIndex = 283
        Me.Label37.Text = "*"
        '
        'cmbAplicacion
        '
        Me.cmbAplicacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAplicacion_DesignTimeLayout.LayoutString = resources.GetString("cmbAplicacion_DesignTimeLayout.LayoutString")
        Me.cmbAplicacion.DesignTimeLayout = cmbAplicacion_DesignTimeLayout
        Me.cmbAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAplicacion.Location = New System.Drawing.Point(803, 16)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.SelectedIndex = -1
        Me.cmbAplicacion.SelectedItem = Nothing
        Me.cmbAplicacion.Size = New System.Drawing.Size(180, 20)
        Me.cmbAplicacion.TabIndex = 18
        Me.cmbAplicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(732, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 238
        Me.Label10.Text = "Aplicación"
        '
        'txtModMotor
        '
        Me.txtModMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModMotor.Location = New System.Drawing.Point(405, 16)
        Me.txtModMotor.Name = "txtModMotor"
        Me.txtModMotor.Size = New System.Drawing.Size(239, 20)
        Me.txtModMotor.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(350, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 13)
        Me.Label13.TabIndex = 235
        Me.Label13.Text = "Modelo"
        '
        'txtSerieMotor
        '
        Me.txtSerieMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieMotor.Location = New System.Drawing.Point(61, 16)
        Me.txtSerieMotor.Name = "txtSerieMotor"
        Me.txtSerieMotor.Size = New System.Drawing.Size(174, 20)
        Me.txtSerieMotor.TabIndex = 15
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarMercaderia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(239, 16)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarMercaderia.TabIndex = 16
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 233
        Me.Label12.Text = "Serie"
        '
        'txtTecnico
        '
        Me.txtTecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTecnico.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTecnico.Location = New System.Drawing.Point(715, 55)
        Me.txtTecnico.MaxLength = 3
        Me.txtTecnico.Name = "txtTecnico"
        Me.txtTecnico.ReadOnly = True
        Me.txtTecnico.Size = New System.Drawing.Size(246, 20)
        Me.txtTecnico.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(645, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Supervisor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(329, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "Jefe"
        '
        'cmbSupervisor
        '
        Me.cmbSupervisor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSupervisor_DesignTimeLayout.LayoutString = resources.GetString("cmbSupervisor_DesignTimeLayout.LayoutString")
        Me.cmbSupervisor.DesignTimeLayout = cmbSupervisor_DesignTimeLayout
        Me.cmbSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupervisor.Location = New System.Drawing.Point(366, 55)
        Me.cmbSupervisor.Name = "cmbSupervisor"
        Me.cmbSupervisor.SelectedIndex = -1
        Me.cmbSupervisor.SelectedItem = Nothing
        Me.cmbSupervisor.Size = New System.Drawing.Size(235, 20)
        Me.cmbSupervisor.TabIndex = 6
        Me.cmbSupervisor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumJob
        '
        Me.txtNumJob.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumJob.Location = New System.Drawing.Point(253, 23)
        Me.txtNumJob.MaxLength = 20
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(69, 20)
        Me.txtNumJob.TabIndex = 1
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(220, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 13)
        Me.Label14.TabIndex = 116
        Me.Label14.Text = "OT"
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(326, 22)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 2
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'gbDetalle
        '
        Me.gbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(5, 618)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(1010, 143)
        Me.gbDetalle.TabIndex = 283
        Me.gbDetalle.Text = "Detalle"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 19)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(998, 115)
        Me.dgvDatos.TabIndex = 2
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miAtender, Me.miRechazar, Me.miActualizarEstado, Me.ToolStripMenuItem1, Me.miSeparador1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(165, 170)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(164, 22)
        Me.miNuevo.Text = "Nueva Atención"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(164, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(164, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miAtender
        '
        Me.miAtender.Image = CType(resources.GetObject("miAtender.Image"), System.Drawing.Image)
        Me.miAtender.Name = "miAtender"
        Me.miAtender.Size = New System.Drawing.Size(164, 22)
        Me.miAtender.Text = "Atender"
        '
        'miRechazar
        '
        Me.miRechazar.Image = Global.SIGECOM.My.Resources.Resources.Rechazar_1
        Me.miRechazar.Name = "miRechazar"
        Me.miRechazar.Size = New System.Drawing.Size(164, 22)
        Me.miRechazar.Text = "Rechazar"
        '
        'miActualizarEstado
        '
        Me.miActualizarEstado.Image = CType(resources.GetObject("miActualizarEstado.Image"), System.Drawing.Image)
        Me.miActualizarEstado.Name = "miActualizarEstado"
        Me.miActualizarEstado.Size = New System.Drawing.Size(164, 22)
        Me.miActualizarEstado.Text = "Actualizar Estado"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(161, 6)
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(161, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(164, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'frmSolicitudGarantia_Nuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 775)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.cbSolicitud)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolicitudGarantia_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Formato de ORDEN DE REPARACIÓN"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cbSolicitud.ResumeLayout(False)
        Me.cbSolicitud.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cbCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cbCliente.ResumeLayout(False)
        Me.cbCliente.PerformLayout()
        CType(Me.cmbContactoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbMotor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMotor.ResumeLayout(False)
        Me.gbMotor.PerformLayout()
        CType(Me.cmbAplicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cbSolicitud As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents txtIdAfa As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecUltRepPzaFallada As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecReparacionGarantia As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecArranqueInicial As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbCores As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbRepuestos As System.Windows.Forms.CheckBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtDiasServTotales As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents txtPartePzaPrimaria As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtHorasUltRepPzaFallada As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDescPzaPrimaria As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtHorasTotalMotor As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtDiasServicioPzaFallada As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents txtDistanciaKm As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCorreccion As System.Windows.Forms.TextBox
    Friend WithEvents txtLugarServicio As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtSerieVehiculo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMarcaEquipo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtModeloEquipo As System.Windows.Forms.TextBox
    Friend WithEvents txtCausa As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbCliente As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtEmailCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtQuejaDemandaProblema As System.Windows.Forms.TextBox
    Friend WithEvents txtHorasViajeIdaVuelta As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents gbMotor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbAplicacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtModMotor As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSerieMotor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTecnico As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSupervisor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbContactoCliente As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarContacto As Janus.Windows.EditControls.UIButton
    Friend WithEvents miAtender As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miRechazar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCausa As System.Windows.Forms.Button
    Friend WithEvents btnQueja As System.Windows.Forms.Button
    Friend WithEvents btnComentarios As System.Windows.Forms.Button
    Friend WithEvents btnCorreccion As System.Windows.Forms.Button
    Friend WithEvents biEnviar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarEstado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecLlegadaAlm As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFacturaImportacionAlm As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents txtPedidoAlm As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents txtCantPzaPrimaria As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label42 As Label
    Friend WithEvents txtSeriePiezaPrimaria As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtVale As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtOT As TextBox
    Friend WithEvents Label16 As Label
End Class
