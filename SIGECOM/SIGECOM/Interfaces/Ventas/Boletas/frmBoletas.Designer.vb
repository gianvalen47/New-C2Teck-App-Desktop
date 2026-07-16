<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoletas
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
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBoletas))
        Dim cmbTipFac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim GridEX2_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTicket = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEnviar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEstados = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFacturarJob = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSugerir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miConsultarSugerido = New System.Windows.Forms.ToolStripMenuItem()
        Me.miBajarNivel = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEnviarBoletaElectronica = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miGenerarBoletaElectronica = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDarBajaBoletaElectronica = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDescargarBoletaElectronica = New System.Windows.Forms.ToolStripMenuItem()
        Me.miListarBolElecxCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.miListarComunicadoBaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.miObservacionesSunat = New System.Windows.Forms.ToolStripMenuItem()
        Me.miObtenercdrdoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.miGenerarAsiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.miVerAsientoContable = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biTicket = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEnviar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEstados = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biFacturarJob = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSugerir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biConsultarSugerido = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biBajarNivel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEnviarCorreo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerarBoletaElectronica = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDarBajaBoletaElectronica = New System.Windows.Forms.ToolStripButton()
        Me.biDescargarBoletaElectronica = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.biListarBolElecxCliente = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.biListarComunicadosBaja = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.cmbTipFac = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox()
        Me.chkCliente = New System.Windows.Forms.CheckBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.GridEX2 = New Janus.Windows.GridEX.GridEX()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.cmbTipFac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.GridEX2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(53, 30)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(77, 20)
        Me.cmbMes.TabIndex = 1
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miTicket, Me.miEnviar, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miEstados, Me.miAnular, Me.miFacturarJob, Me.miSugerir, Me.miConsultarSugerido, Me.miBajarNivel, Me.miEnviarBoletaElectronica, Me.miActualizar, Me.ToolStripSeparator10, Me.ToolStripMenuItem1, Me.miGenerarBoletaElectronica, Me.miDarBajaBoletaElectronica, Me.miDescargarBoletaElectronica, Me.miListarBolElecxCliente, Me.miListarComunicadoBaja, Me.miObservacionesSunat, Me.miObtenercdrdoc, Me.ToolStripSeparator22, Me.miGenerarAsiento, Me.miVerAsientoContable, Me.ToolStripSeparator23, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(224, 556)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(223, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miTicket
        '
        Me.miTicket.Image = Global.SIGECOM.My.Resources.Resources.Ticket
        Me.miTicket.Name = "miTicket"
        Me.miTicket.Size = New System.Drawing.Size(223, 22)
        Me.miTicket.Text = "Ticket"
        '
        'miEnviar
        '
        Me.miEnviar.Image = Global.SIGECOM.My.Resources.Resources.Pagos
        Me.miEnviar.Name = "miEnviar"
        Me.miEnviar.Size = New System.Drawing.Size(223, 22)
        Me.miEnviar.Text = "Enviar"
        Me.miEnviar.ToolTipText = "Enviar a Creditos y Cobranzas"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(223, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(223, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(223, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miEstados
        '
        Me.miEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miEstados.Name = "miEstados"
        Me.miEstados.Size = New System.Drawing.Size(223, 22)
        Me.miEstados.Text = "Estados"
        '
        'miAnular
        '
        Me.miAnular.Image = Global.SIGECOM.My.Resources.Resources.Anular
        Me.miAnular.Name = "miAnular"
        Me.miAnular.Size = New System.Drawing.Size(223, 22)
        Me.miAnular.Text = "Anular"
        Me.miAnular.ToolTipText = "Anular Boleta"
        '
        'miFacturarJob
        '
        Me.miFacturarJob.Image = Global.SIGECOM.My.Resources.Resources.Tools
        Me.miFacturarJob.Name = "miFacturarJob"
        Me.miFacturarJob.Size = New System.Drawing.Size(223, 22)
        Me.miFacturarJob.Text = "Facturar Job"
        '
        'miSugerir
        '
        Me.miSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.miSugerir.Name = "miSugerir"
        Me.miSugerir.Size = New System.Drawing.Size(223, 22)
        Me.miSugerir.Text = "Sugerir"
        Me.miSugerir.ToolTipText = "Sugerir Factor / Descuento"
        '
        'miConsultarSugerido
        '
        Me.miConsultarSugerido.Image = CType(resources.GetObject("miConsultarSugerido.Image"), System.Drawing.Image)
        Me.miConsultarSugerido.Name = "miConsultarSugerido"
        Me.miConsultarSugerido.Size = New System.Drawing.Size(223, 22)
        Me.miConsultarSugerido.Text = "Consultar Sugeridos"
        '
        'miBajarNivel
        '
        Me.miBajarNivel.Image = Global.SIGECOM.My.Resources.Resources.bajar_estado
        Me.miBajarNivel.Name = "miBajarNivel"
        Me.miBajarNivel.Size = New System.Drawing.Size(223, 22)
        Me.miBajarNivel.Text = "Bajar Nivel"
        Me.miBajarNivel.Visible = False
        '
        'miEnviarBoletaElectronica
        '
        Me.miEnviarBoletaElectronica.Image = Global.SIGECOM.My.Resources.Resources.Enviar_
        Me.miEnviarBoletaElectronica.Name = "miEnviarBoletaElectronica"
        Me.miEnviarBoletaElectronica.Size = New System.Drawing.Size(223, 22)
        Me.miEnviarBoletaElectronica.Text = "Enviar Boleta Electronica"
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(223, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(220, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(220, 6)
        '
        'miGenerarBoletaElectronica
        '
        Me.miGenerarBoletaElectronica.Image = CType(resources.GetObject("miGenerarBoletaElectronica.Image"), System.Drawing.Image)
        Me.miGenerarBoletaElectronica.Name = "miGenerarBoletaElectronica"
        Me.miGenerarBoletaElectronica.Size = New System.Drawing.Size(223, 22)
        Me.miGenerarBoletaElectronica.Text = "Generar Boleta Electronica"
        '
        'miDarBajaBoletaElectronica
        '
        Me.miDarBajaBoletaElectronica.Image = CType(resources.GetObject("miDarBajaBoletaElectronica.Image"), System.Drawing.Image)
        Me.miDarBajaBoletaElectronica.Name = "miDarBajaBoletaElectronica"
        Me.miDarBajaBoletaElectronica.Size = New System.Drawing.Size(223, 22)
        Me.miDarBajaBoletaElectronica.Text = "Dar Baja Boleta Electronica"
        Me.miDarBajaBoletaElectronica.Visible = False
        '
        'miDescargarBoletaElectronica
        '
        Me.miDescargarBoletaElectronica.Image = CType(resources.GetObject("miDescargarBoletaElectronica.Image"), System.Drawing.Image)
        Me.miDescargarBoletaElectronica.Name = "miDescargarBoletaElectronica"
        Me.miDescargarBoletaElectronica.Size = New System.Drawing.Size(223, 22)
        Me.miDescargarBoletaElectronica.Text = "Descargar Boleta Electronica"
        '
        'miListarBolElecxCliente
        '
        Me.miListarBolElecxCliente.Image = CType(resources.GetObject("miListarBolElecxCliente.Image"), System.Drawing.Image)
        Me.miListarBolElecxCliente.Name = "miListarBolElecxCliente"
        Me.miListarBolElecxCliente.Size = New System.Drawing.Size(223, 22)
        Me.miListarBolElecxCliente.Text = "Listar Boletas Electronicas"
        '
        'miListarComunicadoBaja
        '
        Me.miListarComunicadoBaja.Image = CType(resources.GetObject("miListarComunicadoBaja.Image"), System.Drawing.Image)
        Me.miListarComunicadoBaja.Name = "miListarComunicadoBaja"
        Me.miListarComunicadoBaja.Size = New System.Drawing.Size(223, 22)
        Me.miListarComunicadoBaja.Text = "Listar Comunicados Baja"
        '
        'miObservacionesSunat
        '
        Me.miObservacionesSunat.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miObservacionesSunat.Name = "miObservacionesSunat"
        Me.miObservacionesSunat.Size = New System.Drawing.Size(223, 22)
        Me.miObservacionesSunat.Text = "Observaciones Sunat"
        '
        'miObtenercdrdoc
        '
        Me.miObtenercdrdoc.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miObtenercdrdoc.Name = "miObtenercdrdoc"
        Me.miObtenercdrdoc.Size = New System.Drawing.Size(223, 22)
        Me.miObtenercdrdoc.Text = "Obtener cdr documento"
        Me.miObtenercdrdoc.Visible = False
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(220, 6)
        '
        'miGenerarAsiento
        '
        Me.miGenerarAsiento.Image = Global.SIGECOM.My.Resources.Resources.Cont_diario
        Me.miGenerarAsiento.Name = "miGenerarAsiento"
        Me.miGenerarAsiento.Size = New System.Drawing.Size(223, 22)
        Me.miGenerarAsiento.Text = "Generar Asiento Contable"
        '
        'miVerAsientoContable
        '
        Me.miVerAsientoContable.Image = Global.SIGECOM.My.Resources.Resources.laptop_48
        Me.miVerAsientoContable.Name = "miVerAsientoContable"
        Me.miVerAsientoContable.Size = New System.Drawing.Size(223, 22)
        Me.miVerAsientoContable.Text = "Ver Asiento Contable"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(220, 6)
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(223, 22)
        Me.miSalir.Text = "Salir"
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar los datos del registro seleccionado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(314, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Tipo"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator15, Me.biImprimir, Me.ToolStripSeparator4, Me.biTicket, Me.ToolStripSeparator5, Me.biEnviar, Me.ToolStripSeparator11, Me.biNuevo, Me.ToolStripSeparator1, Me.biMostrar, Me.ToolStripSeparator2, Me.biEliminar, Me.ToolStripSeparator3, Me.biEstados, Me.ToolStripSeparator13, Me.biAnular, Me.ToolStripSeparator6, Me.biFacturarJob, Me.ToolStripSeparator16, Me.biSugerir, Me.ToolStripSeparator7, Me.biConsultarSugerido, Me.ToolStripSeparator9, Me.biBajarNivel, Me.ToolStripSeparator12, Me.ToolStripSeparator17, Me.biEnviarCorreo, Me.ToolStripSeparator21, Me.biActualizar, Me.ToolStripSeparator8, Me.biGenerarBoletaElectronica, Me.ToolStripSeparator14, Me.biDarBajaBoletaElectronica, Me.biDescargarBoletaElectronica, Me.ToolStripSeparator18, Me.biListarBolElecxCliente, Me.ToolStripSeparator19, Me.biListarComunicadosBaja, Me.ToolStripSeparator20, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(857, 31)
        Me.ToolStrip.TabIndex = 15
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "ToolStripButton1"
        Me.biImprimir.ToolTipText = "Imprimir Boleta"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biTicket
        '
        Me.biTicket.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biTicket.Image = Global.SIGECOM.My.Resources.Resources.Ticket
        Me.biTicket.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biTicket.Name = "biTicket"
        Me.biTicket.Size = New System.Drawing.Size(28, 28)
        Me.biTicket.Text = "ToolStripButton1"
        Me.biTicket.ToolTipText = "Imprimir Ticket"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biEnviar
        '
        Me.biEnviar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEnviar.Image = Global.SIGECOM.My.Resources.Resources.Pagos
        Me.biEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEnviar.Name = "biEnviar"
        Me.biEnviar.Size = New System.Drawing.Size(28, 28)
        Me.biEnviar.Text = "ToolStripButton1"
        Me.biEnviar.ToolTipText = "Enviar a Credito y cobranzas para aprobacion de precios"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Black
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Crear un nuevo registro"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar el registro seleccionado"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEstados
        '
        Me.biEstados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.biEstados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEstados.Name = "biEstados"
        Me.biEstados.Size = New System.Drawing.Size(28, 28)
        Me.biEstados.Text = "Mostrar los Estados de la Boleta"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'biAnular
        '
        Me.biAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAnular.Image = Global.SIGECOM.My.Resources.Resources.Anular
        Me.biAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAnular.Name = "biAnular"
        Me.biAnular.Size = New System.Drawing.Size(28, 28)
        Me.biAnular.Text = "ToolStripButton1"
        Me.biAnular.ToolTipText = "Anular Boleta"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biFacturarJob
        '
        Me.biFacturarJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biFacturarJob.Image = Global.SIGECOM.My.Resources.Resources.Tools
        Me.biFacturarJob.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biFacturarJob.Name = "biFacturarJob"
        Me.biFacturarJob.Size = New System.Drawing.Size(28, 28)
        Me.biFacturarJob.Text = "Facturar OT"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 31)
        '
        'biSugerir
        '
        Me.biSugerir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSugerir.Image = Global.SIGECOM.My.Resources.Resources.Sugerir
        Me.biSugerir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSugerir.Name = "biSugerir"
        Me.biSugerir.Size = New System.Drawing.Size(28, 28)
        Me.biSugerir.Text = "ToolStripButton1"
        Me.biSugerir.ToolTipText = "Sugerir Factor / Descuento"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'biConsultarSugerido
        '
        Me.biConsultarSugerido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biConsultarSugerido.Image = CType(resources.GetObject("biConsultarSugerido.Image"), System.Drawing.Image)
        Me.biConsultarSugerido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biConsultarSugerido.Name = "biConsultarSugerido"
        Me.biConsultarSugerido.Size = New System.Drawing.Size(28, 28)
        Me.biConsultarSugerido.Text = "Mostrar Precios Sugeridos"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator9.Visible = False
        '
        'biBajarNivel
        '
        Me.biBajarNivel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biBajarNivel.Image = Global.SIGECOM.My.Resources.Resources.bajar_estado
        Me.biBajarNivel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biBajarNivel.Name = "biBajarNivel"
        Me.biBajarNivel.Size = New System.Drawing.Size(28, 28)
        Me.biBajarNivel.Text = "Bajar de nivel"
        Me.biBajarNivel.ToolTipText = "Bajar de nivel"
        Me.biBajarNivel.Visible = False
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator12.Visible = False
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 31)
        '
        'biEnviarCorreo
        '
        Me.biEnviarCorreo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEnviarCorreo.Image = CType(resources.GetObject("biEnviarCorreo.Image"), System.Drawing.Image)
        Me.biEnviarCorreo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEnviarCorreo.Name = "biEnviarCorreo"
        Me.biEnviarCorreo.Size = New System.Drawing.Size(28, 28)
        Me.biEnviarCorreo.Text = "Enviar Boleta Electronica"
        Me.biEnviarCorreo.ToolTipText = "Enviar Boleta Electronica"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "ToolStripButton1"
        Me.biActualizar.ToolTipText = "Refrescar Datos"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerarBoletaElectronica
        '
        Me.biGenerarBoletaElectronica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarBoletaElectronica.Image = CType(resources.GetObject("biGenerarBoletaElectronica.Image"), System.Drawing.Image)
        Me.biGenerarBoletaElectronica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarBoletaElectronica.Name = "biGenerarBoletaElectronica"
        Me.biGenerarBoletaElectronica.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarBoletaElectronica.Text = "Generar Boleta Electronica"
        Me.biGenerarBoletaElectronica.ToolTipText = "Generar Boleta Electronica"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'biDarBajaBoletaElectronica
        '
        Me.biDarBajaBoletaElectronica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDarBajaBoletaElectronica.Image = CType(resources.GetObject("biDarBajaBoletaElectronica.Image"), System.Drawing.Image)
        Me.biDarBajaBoletaElectronica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDarBajaBoletaElectronica.Name = "biDarBajaBoletaElectronica"
        Me.biDarBajaBoletaElectronica.Size = New System.Drawing.Size(28, 28)
        Me.biDarBajaBoletaElectronica.Text = "Comunicacion de Baja Boleta Electronica"
        Me.biDarBajaBoletaElectronica.ToolTipText = "Comunicacion de Baja Boleta Electronica"
        Me.biDarBajaBoletaElectronica.Visible = False
        '
        'biDescargarBoletaElectronica
        '
        Me.biDescargarBoletaElectronica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDescargarBoletaElectronica.Image = CType(resources.GetObject("biDescargarBoletaElectronica.Image"), System.Drawing.Image)
        Me.biDescargarBoletaElectronica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDescargarBoletaElectronica.Name = "biDescargarBoletaElectronica"
        Me.biDescargarBoletaElectronica.Size = New System.Drawing.Size(28, 28)
        Me.biDescargarBoletaElectronica.Text = "Descargar Boleta Electronica"
        Me.biDescargarBoletaElectronica.ToolTipText = "Descargar Boleta Electronica"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 31)
        '
        'biListarBolElecxCliente
        '
        Me.biListarBolElecxCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biListarBolElecxCliente.Image = CType(resources.GetObject("biListarBolElecxCliente.Image"), System.Drawing.Image)
        Me.biListarBolElecxCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biListarBolElecxCliente.Name = "biListarBolElecxCliente"
        Me.biListarBolElecxCliente.Size = New System.Drawing.Size(28, 28)
        Me.biListarBolElecxCliente.Text = "Listar Boleta Electronica"
        Me.biListarBolElecxCliente.ToolTipText = "Listar Boleta Electronica"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(6, 31)
        '
        'biListarComunicadosBaja
        '
        Me.biListarComunicadosBaja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biListarComunicadosBaja.Image = CType(resources.GetObject("biListarComunicadosBaja.Image"), System.Drawing.Image)
        Me.biListarComunicadosBaja.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biListarComunicadosBaja.Name = "biListarComunicadosBaja"
        Me.biListarComunicadosBaja.Size = New System.Drawing.Size(28, 28)
        Me.biListarComunicadosBaja.Text = "Listar Boleta Electronica"
        Me.biListarComunicadosBaja.ToolTipText = "Listar Comunicados Baja"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(6, 31)
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
        'cmbTipFac
        '
        Me.cmbTipFac.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipFac_DesignTimeLayout.LayoutString = resources.GetString("cmbTipFac_DesignTimeLayout.LayoutString")
        Me.cmbTipFac.DesignTimeLayout = cmbTipFac_DesignTimeLayout
        Me.cmbTipFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipFac.Location = New System.Drawing.Point(314, 30)
        Me.cmbTipFac.Name = "cmbTipFac"
        Me.cmbTipFac.SelectedIndex = -1
        Me.cmbTipFac.SelectedItem = Nothing
        Me.cmbTipFac.Size = New System.Drawing.Size(100, 20)
        Me.cmbTipFac.TabIndex = 4
        Me.cmbTipFac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(53, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Año"
        '
        'txtanio
        '
        Me.txtanio.Location = New System.Drawing.Point(4, 30)
        Me.txtanio.Maximum = 2059
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2006
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(48, 20)
        Me.txtanio.TabIndex = 0
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2006
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(575, 30)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(85, 20)
        Me.cmbEstado.TabIndex = 7
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(209, 30)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(104, 20)
        Me.cmbIdLocacion.TabIndex = 3
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(131, 30)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(77, 20)
        Me.cmbOficinas.TabIndex = 2
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(661, 30)
        Me.txtNumDoc.MaxLength = 30
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(50, 20)
        Me.txtNumDoc.TabIndex = 8
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(714, 26)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 25)
        Me.btnBuscar.TabIndex = 9
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(415, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Cliente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(575, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Estado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(209, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Almacén"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(131, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Oficina"
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(483, 10)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 24
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'chkCliente
        '
        Me.chkCliente.AutoSize = True
        Me.chkCliente.Checked = True
        Me.chkCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCliente.Location = New System.Drawing.Point(466, 14)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(15, 14)
        Me.chkCliente.TabIndex = 23
        Me.chkCliente.Tag = ""
        Me.chkCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkCliente.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(722, 10)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(52, 16)
        Me.txtObservacion.TabIndex = 22
        Me.txtObservacion.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(661, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Número"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 417)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(857, 20)
        Me.ssBarra.TabIndex = 14
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(0, 95)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(857, 322)
        Me.dgvDatos.TabIndex = 16
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.UiGroupBox1.Controls.Add(Me.txtIdCliente)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.UiGroupBox1.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox1.Controls.Add(Me.cmbIdLocacion)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.chkCliente)
        Me.UiGroupBox1.Controls.Add(Me.cmbEstado)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.txtanio)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipFac)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.cmbOficinas)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.cmbMes)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(2, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(784, 55)
        Me.UiGroupBox1.TabIndex = 25
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(548, 29)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(26, 22)
        Me.btnBuscarCliente.TabIndex = 6
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(415, 30)
        Me.txtIdCliente.MaxLength = 3
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(133, 20)
        Me.txtIdCliente.TabIndex = 5
        '
        'GridEX2
        '
        GridEX2_DesignTimeLayout.LayoutString = resources.GetString("GridEX2_DesignTimeLayout.LayoutString")
        Me.GridEX2.DesignTimeLayout = GridEX2_DesignTimeLayout
        Me.GridEX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridEX2.GroupByBoxVisible = False
        Me.GridEX2.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.GridEX2.Location = New System.Drawing.Point(791, 34)
        Me.GridEX2.Name = "GridEX2"
        Me.GridEX2.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GridEX2.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridEX2.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.GridEX2.Size = New System.Drawing.Size(60, 54)
        Me.GridEX2.TabIndex = 118
        Me.GridEX2.Visible = False
        Me.GridEX2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmBoletas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(857, 437)
        Me.Controls.Add(Me.GridEX2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1400, 700)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(796, 401)
        Me.Name = "frmBoletas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Boletas de Venta"
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.cmbTipFac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.GridEX2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbTipFac As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSugerir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biTicket As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miTicket As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSugerir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEnviar As System.Windows.Forms.ToolStripButton
    Friend WithEvents miEnviar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents biConsultarSugerido As System.Windows.Forms.ToolStripButton
    Friend WithEvents miConsultarSugerido As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miEstados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biEstados As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biFacturarJob As System.Windows.Forms.ToolStripButton
    Friend WithEvents miFacturarJob As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miBajarNivel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biBajarNivel As System.Windows.Forms.ToolStripButton
    Friend WithEvents biGenerarBoletaElectronica As System.Windows.Forms.ToolStripButton
    Friend WithEvents biDarBajaBoletaElectronica As System.Windows.Forms.ToolStripButton
    Friend WithEvents biDescargarBoletaElectronica As System.Windows.Forms.ToolStripButton
    Friend WithEvents biListarBolElecxCliente As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biListarComunicadosBaja As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miGenerarBoletaElectronica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDarBajaBoletaElectronica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDescargarBoletaElectronica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miListarBolElecxCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miListarComunicadoBaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GridEX2 As Janus.Windows.GridEX.GridEX
    Friend WithEvents miObservacionesSunat As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miObtenercdrdoc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAnular As ToolStripMenuItem
    Friend WithEvents miGenerarAsiento As ToolStripMenuItem
    Friend WithEvents miVerAsientoContable As ToolStripMenuItem
    Friend WithEvents biEnviarCorreo As ToolStripButton
    Friend WithEvents ToolStripSeparator21 As ToolStripSeparator
    Friend WithEvents miEnviarBoletaElectronica As ToolStripMenuItem
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents txtIdCliente As TextBox
End Class
