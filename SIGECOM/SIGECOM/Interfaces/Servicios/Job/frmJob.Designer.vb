<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmJob
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbSupervisor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstados_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image")
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJob))
        Dim cmbCodArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEnviar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biHabilitarMarcacion = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerarGuia = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biLiquidar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCulminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biRegularGastos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biTrasladarGastos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizarEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.biRecalcular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.biHistorialActivar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.biRegistrarArchivos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbSupervisor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox()
        Me.chkCliente = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.cmbEstados = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtBuscarCliente = New System.Windows.Forms.TextBox()
        Me.lblVendedor = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEnviar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miHabilitarMarcacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGenerarGuia = New System.Windows.Forms.ToolStripMenuItem()
        Me.miLiquidar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCulminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEstado = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRegular = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTrasladarGastos = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizarEstado = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRecalcular = New System.Windows.Forms.ToolStripMenuItem()
        Me.miHistorialActivacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRegistrarArchivos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblUnidadNegocio = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator14, Me.biImprimir, Me.ToolStripSeparator2, Me.biNuevo, Me.ToolStripSeparator1, Me.biMostrar, Me.ToolStripSeparator3, Me.biEliminar, Me.ToolStripSeparator22, Me.biEnviar, Me.ToolStripSeparator4, Me.biHabilitarMarcacion, Me.ToolStripSeparator17, Me.biGenerarGuia, Me.ToolStripSeparator5, Me.biLiquidar, Me.ToolStripSeparator15, Me.biCulminar, Me.ToolStripSeparator6, Me.biAnular, Me.ToolStripSeparator7, Me.biEstado, Me.ToolStripSeparator8, Me.biRegularGastos, Me.ToolStripSeparator13, Me.biTrasladarGastos, Me.ToolStripSeparator9, Me.biActualizarEstado, Me.ToolStripSeparator10, Me.biRecalcular, Me.ToolStripSeparator16, Me.biHistorialActivar, Me.ToolStripSeparator18, Me.biRegistrarArchivos, Me.ToolStripSeparator21, Me.biActualizar, Me.ToolStripSeparator11, Me.biSalir, Me.ToolStripSeparator12})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1146, 31)
        Me.ToolStrip.TabIndex = 45
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Listado de OT"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Crear Nueva OT"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = CType(resources.GetObject("biMostrar.Image"), System.Drawing.Image)
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar OT"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar OT"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(6, 31)
        '
        'biEnviar
        '
        Me.biEnviar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEnviar.Image = Global.SIGECOM.My.Resources.Resources.Pagos
        Me.biEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEnviar.Name = "biEnviar"
        Me.biEnviar.Size = New System.Drawing.Size(28, 28)
        Me.biEnviar.Text = "Enviar a Créditos"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biHabilitarMarcacion
        '
        Me.biHabilitarMarcacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biHabilitarMarcacion.Image = CType(resources.GetObject("biHabilitarMarcacion.Image"), System.Drawing.Image)
        Me.biHabilitarMarcacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biHabilitarMarcacion.Name = "biHabilitarMarcacion"
        Me.biHabilitarMarcacion.Size = New System.Drawing.Size(28, 28)
        Me.biHabilitarMarcacion.Text = "Habilitar Marcación a la OT"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerarGuia
        '
        Me.biGenerarGuia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarGuia.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.biGenerarGuia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarGuia.Name = "biGenerarGuia"
        Me.biGenerarGuia.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarGuia.Text = "Generar Guia"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biLiquidar
        '
        Me.biLiquidar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biLiquidar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.biLiquidar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biLiquidar.Name = "biLiquidar"
        Me.biLiquidar.Size = New System.Drawing.Size(28, 28)
        Me.biLiquidar.Text = "Liquidar OT"
        Me.biLiquidar.ToolTipText = "Liquidar OT"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
        '
        'biCulminar
        '
        Me.biCulminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCulminar.Image = CType(resources.GetObject("biCulminar.Image"), System.Drawing.Image)
        Me.biCulminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCulminar.Name = "biCulminar"
        Me.biCulminar.Size = New System.Drawing.Size(28, 28)
        Me.biCulminar.Text = "Culminar OT"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biAnular
        '
        Me.biAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAnular.Image = Global.SIGECOM.My.Resources.Resources.Anular
        Me.biAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAnular.Name = "biAnular"
        Me.biAnular.Size = New System.Drawing.Size(28, 28)
        Me.biAnular.Text = "Anular OT"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'biEstado
        '
        Me.biEstado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEstado.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.biEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEstado.Name = "biEstado"
        Me.biEstado.Size = New System.Drawing.Size(28, 28)
        Me.biEstado.Text = "Estados OT"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biRegularGastos
        '
        Me.biRegularGastos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biRegularGastos.Image = CType(resources.GetObject("biRegularGastos.Image"), System.Drawing.Image)
        Me.biRegularGastos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biRegularGastos.Name = "biRegularGastos"
        Me.biRegularGastos.Size = New System.Drawing.Size(28, 28)
        Me.biRegularGastos.Text = "Regularizar Gastos de la OT"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'biTrasladarGastos
        '
        Me.biTrasladarGastos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biTrasladarGastos.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.biTrasladarGastos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biTrasladarGastos.Name = "biTrasladarGastos"
        Me.biTrasladarGastos.Size = New System.Drawing.Size(28, 28)
        Me.biTrasladarGastos.Text = "Trasladar Gastos a Otra OT"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizarEstado
        '
        Me.biActualizarEstado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizarEstado.Image = CType(resources.GetObject("biActualizarEstado.Image"), System.Drawing.Image)
        Me.biActualizarEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizarEstado.Name = "biActualizarEstado"
        Me.biActualizarEstado.Size = New System.Drawing.Size(28, 28)
        Me.biActualizarEstado.Text = "Bajar de nivel"
        Me.biActualizarEstado.ToolTipText = "Bajar de nivel"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 31)
        '
        'biRecalcular
        '
        Me.biRecalcular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biRecalcular.Image = CType(resources.GetObject("biRecalcular.Image"), System.Drawing.Image)
        Me.biRecalcular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biRecalcular.Name = "biRecalcular"
        Me.biRecalcular.Size = New System.Drawing.Size(28, 28)
        Me.biRecalcular.Text = "ReCalcular OT"
        Me.biRecalcular.ToolTipText = "Recalcular OT"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 31)
        '
        'biHistorialActivar
        '
        Me.biHistorialActivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biHistorialActivar.Image = CType(resources.GetObject("biHistorialActivar.Image"), System.Drawing.Image)
        Me.biHistorialActivar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biHistorialActivar.Name = "biHistorialActivar"
        Me.biHistorialActivar.Size = New System.Drawing.Size(28, 28)
        Me.biHistorialActivar.Text = "Ver Historial de Activación de la OT"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 31)
        '
        'biRegistrarArchivos
        '
        Me.biRegistrarArchivos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biRegistrarArchivos.Image = CType(resources.GetObject("biRegistrarArchivos.Image"), System.Drawing.Image)
        Me.biRegistrarArchivos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biRegistrarArchivos.Name = "biRegistrarArchivos"
        Me.biRegistrarArchivos.Size = New System.Drawing.Size(28, 28)
        Me.biRegistrarArchivos.Text = "Registrar Archivos"
        Me.biRegistrarArchivos.ToolTipText = "Registrar Archivos"
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
        Me.biActualizar.Text = "Actualizar"
        Me.biActualizar.ToolTipText = "Actualizar Datos"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(265, 34)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(63, 20)
        Me.cmbOficinas.TabIndex = 135
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtanio
        '
        Me.txtanio.Location = New System.Drawing.Point(5, 34)
        Me.txtanio.Maximum = 2059
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2003
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(49, 20)
        Me.txtanio.TabIndex = 134
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2003
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(888, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Supervisor"
        '
        'cmbSupervisor
        '
        Me.cmbSupervisor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSupervisor_DesignTimeLayout.LayoutString = resources.GetString("cmbSupervisor_DesignTimeLayout.LayoutString")
        Me.cmbSupervisor.DesignTimeLayout = cmbSupervisor_DesignTimeLayout
        Me.cmbSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupervisor.Location = New System.Drawing.Point(854, 34)
        Me.cmbSupervisor.Name = "cmbSupervisor"
        Me.cmbSupervisor.SelectedIndex = -1
        Me.cmbSupervisor.SelectedItem = Nothing
        Me.cmbSupervisor.Size = New System.Drawing.Size(138, 20)
        Me.cmbSupervisor.TabIndex = 132
        Me.cmbSupervisor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(633, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Serie"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(615, 34)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(73, 20)
        Me.txtSerie.TabIndex = 130
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "Año"
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(413, 13)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 128
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'chkCliente
        '
        Me.chkCliente.AutoSize = True
        Me.chkCliente.Checked = True
        Me.chkCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCliente.Location = New System.Drawing.Point(396, 17)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(15, 14)
        Me.chkCliente.TabIndex = 127
        Me.chkCliente.Tag = ""
        Me.chkCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkCliente.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(545, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 125
        Me.Label8.Text = "Proceso"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.Location = New System.Drawing.Point(994, 32)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscar.TabIndex = 126
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtNumJob
        '
        Me.txtNumJob.Location = New System.Drawing.Point(691, 34)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(59, 20)
        Me.txtNumJob.TabIndex = 124
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(753, 34)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(98, 20)
        Me.txtDescripcion.TabIndex = 123
        '
        'cmbEstados
        '
        Me.cmbEstados.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstados_DesignTimeLayout.LayoutString = resources.GetString("cmbEstados_DesignTimeLayout.LayoutString")
        Me.cmbEstados.DesignTimeLayout = cmbEstados_DesignTimeLayout
        Me.cmbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstados.Location = New System.Drawing.Point(532, 34)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.SelectedIndex = -1
        Me.cmbEstados.SelectedItem = Nothing
        Me.cmbEstados.Size = New System.Drawing.Size(80, 20)
        Me.cmbEstados.TabIndex = 122
        Me.cmbEstados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbTipo
        '
        Me.cmbTipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipo_DesignTimeLayout.LayoutString")
        Me.cmbTipo.DesignTimeLayout = cmbTipo_DesignTimeLayout
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(474, 34)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.SelectedIndex = -1
        Me.cmbTipo.SelectedItem = Nothing
        Me.cmbTipo.Size = New System.Drawing.Size(55, 20)
        Me.cmbTipo.TabIndex = 121
        Me.cmbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(447, 33)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarCliente.TabIndex = 120
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtBuscarCliente
        '
        Me.txtBuscarCliente.BackColor = System.Drawing.SystemColors.Window
        Me.txtBuscarCliente.Location = New System.Drawing.Point(330, 34)
        Me.txtBuscarCliente.Name = "txtBuscarCliente"
        Me.txtBuscarCliente.ReadOnly = True
        Me.txtBuscarCliente.Size = New System.Drawing.Size(117, 20)
        Me.txtBuscarCliente.TabIndex = 119
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVendedor.Location = New System.Drawing.Point(485, 18)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(32, 13)
        Me.lblVendedor.TabIndex = 117
        Me.lblVendedor.Text = "Tipo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(706, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 118
        Me.Label9.Text = "OT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(344, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Cliente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(764, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(267, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Locación"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 429)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(1146, 20)
        Me.ssBarra.TabIndex = 109
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(550, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miEnviar, Me.miHabilitarMarcacion, Me.miGenerarGuia, Me.miLiquidar, Me.miCulminar, Me.miAnular, Me.miEstado, Me.miRegular, Me.miTrasladarGastos, Me.miActualizarEstado, Me.miRecalcular, Me.miHistorialActivacion, Me.miRegistrarArchivos, Me.ToolStripSeparator19, Me.miActualizar, Me.miSalir})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(179, 428)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora1
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(178, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(178, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(178, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(178, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miEnviar
        '
        Me.miEnviar.Image = Global.SIGECOM.My.Resources.Resources.Pagos
        Me.miEnviar.Name = "miEnviar"
        Me.miEnviar.Size = New System.Drawing.Size(178, 22)
        Me.miEnviar.Text = "Enviar a Creditos"
        '
        'miHabilitarMarcacion
        '
        Me.miHabilitarMarcacion.Image = CType(resources.GetObject("miHabilitarMarcacion.Image"), System.Drawing.Image)
        Me.miHabilitarMarcacion.Name = "miHabilitarMarcacion"
        Me.miHabilitarMarcacion.Size = New System.Drawing.Size(178, 22)
        Me.miHabilitarMarcacion.Text = "Habilitar Marcación"
        '
        'miGenerarGuia
        '
        Me.miGenerarGuia.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.miGenerarGuia.Name = "miGenerarGuia"
        Me.miGenerarGuia.Size = New System.Drawing.Size(178, 22)
        Me.miGenerarGuia.Text = "Generar Guia"
        '
        'miLiquidar
        '
        Me.miLiquidar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.miLiquidar.Name = "miLiquidar"
        Me.miLiquidar.Size = New System.Drawing.Size(178, 22)
        Me.miLiquidar.Text = "Liquidar"
        '
        'miCulminar
        '
        Me.miCulminar.Image = CType(resources.GetObject("miCulminar.Image"), System.Drawing.Image)
        Me.miCulminar.Name = "miCulminar"
        Me.miCulminar.Size = New System.Drawing.Size(178, 22)
        Me.miCulminar.Text = "Culminar"
        '
        'miAnular
        '
        Me.miAnular.Image = Global.SIGECOM.My.Resources.Resources.Anular
        Me.miAnular.Name = "miAnular"
        Me.miAnular.Size = New System.Drawing.Size(178, 22)
        Me.miAnular.Text = "Anular"
        '
        'miEstado
        '
        Me.miEstado.Image = Global.SIGECOM.My.Resources.Resources.detalle
        Me.miEstado.Name = "miEstado"
        Me.miEstado.Size = New System.Drawing.Size(178, 22)
        Me.miEstado.Text = "Estado"
        '
        'miRegular
        '
        Me.miRegular.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.miRegular.Name = "miRegular"
        Me.miRegular.Size = New System.Drawing.Size(178, 22)
        Me.miRegular.Text = "Regularizar Gastos"
        '
        'miTrasladarGastos
        '
        Me.miTrasladarGastos.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.miTrasladarGastos.Name = "miTrasladarGastos"
        Me.miTrasladarGastos.Size = New System.Drawing.Size(178, 22)
        Me.miTrasladarGastos.Text = "Trasladar Gastos"
        '
        'miActualizarEstado
        '
        Me.miActualizarEstado.Image = CType(resources.GetObject("miActualizarEstado.Image"), System.Drawing.Image)
        Me.miActualizarEstado.Name = "miActualizarEstado"
        Me.miActualizarEstado.Size = New System.Drawing.Size(178, 22)
        Me.miActualizarEstado.Text = "Bajar de nivel"
        '
        'miRecalcular
        '
        Me.miRecalcular.Image = Global.SIGECOM.My.Resources.Resources.Recalcular
        Me.miRecalcular.Name = "miRecalcular"
        Me.miRecalcular.Size = New System.Drawing.Size(178, 22)
        Me.miRecalcular.Text = "ReCalcular"
        '
        'miHistorialActivacion
        '
        Me.miHistorialActivacion.Image = CType(resources.GetObject("miHistorialActivacion.Image"), System.Drawing.Image)
        Me.miHistorialActivacion.Name = "miHistorialActivacion"
        Me.miHistorialActivacion.Size = New System.Drawing.Size(178, 22)
        Me.miHistorialActivacion.Text = "Historial Activación"
        '
        'miRegistrarArchivos
        '
        Me.miRegistrarArchivos.Image = CType(resources.GetObject("miRegistrarArchivos.Image"), System.Drawing.Image)
        Me.miRegistrarArchivos.Name = "miRegistrarArchivos"
        Me.miRegistrarArchivos.Size = New System.Drawing.Size(178, 22)
        Me.miRegistrarArchivos.Text = "Registrar Archivos"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(175, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(178, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(178, 22)
        Me.miSalir.Text = "Salir"
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatos_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatos_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatos_DesignTimeLayout_Reference_0})
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(5, 102)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(1124, 308)
        Me.dgvDatos.TabIndex = 111
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label26)
        Me.UiGroupBox1.Controls.Add(Me.cmbCentroCosto)
        Me.UiGroupBox1.Controls.Add(Me.cmbCodArea)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtanio)
        Me.UiGroupBox1.Controls.Add(Me.cmbOficinas)
        Me.UiGroupBox1.Controls.Add(Me.cmbEstados)
        Me.UiGroupBox1.Controls.Add(Me.txtDescripcion)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.UiGroupBox1.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox1.Controls.Add(Me.txtBuscarCliente)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.cmbSupervisor)
        Me.UiGroupBox1.Controls.Add(Me.lblVendedor)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.cmbTipo)
        Me.UiGroupBox1.Controls.Add(Me.chkCliente)
        Me.UiGroupBox1.Controls.Add(Me.txtSerie)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 36)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(1023, 60)
        Me.UiGroupBox1.TabIndex = 136
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(169, 18)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 13)
        Me.Label26.TabIndex = 204
        Me.Label26.Text = "Centro Costo"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(154, 34)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(109, 20)
        Me.cmbCentroCosto.TabIndex = 202
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodArea
        '
        Me.cmbCodArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodArea_DesignTimeLayout.LayoutString = resources.GetString("cmbCodArea_DesignTimeLayout.LayoutString")
        Me.cmbCodArea.DesignTimeLayout = cmbCodArea_DesignTimeLayout
        Me.cmbCodArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodArea.Location = New System.Drawing.Point(58, 34)
        Me.cmbCodArea.Name = "cmbCodArea"
        Me.cmbCodArea.SelectedIndex = -1
        Me.cmbCodArea.SelectedItem = Nothing
        Me.cmbCodArea.Size = New System.Drawing.Size(94, 20)
        Me.cmbCodArea.TabIndex = 201
        Me.cmbCodArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(90, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 203
        Me.Label7.Text = "Area"
        '
        'lblUnidadNegocio
        '
        Me.lblUnidadNegocio.AutoSize = True
        Me.lblUnidadNegocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadNegocio.Location = New System.Drawing.Point(617, 11)
        Me.lblUnidadNegocio.Name = "lblUnidadNegocio"
        Me.lblUnidadNegocio.Size = New System.Drawing.Size(134, 15)
        Me.lblUnidadNegocio.TabIndex = 206
        Me.lblUnidadNegocio.Text = "Unidad de Negocio:"
        '
        'frmJob
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1146, 449)
        Me.Controls.Add(Me.lblUnidadNegocio)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.dgvDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJob"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OT"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biLiquidar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCulminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biRegularGastos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biRecalcular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbSupervisor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents cmbEstados As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtBuscarCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblVendedor As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miLiquidar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCulminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEstado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miRegular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miRecalcular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biTrasladarGastos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miTrasladarGastos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents biGenerarGuia As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miGenerarGuia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biActualizarEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarEstado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCodArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblUnidadNegocio As System.Windows.Forms.Label
    Friend WithEvents biHabilitarMarcacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miHabilitarMarcacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biHistorialActivar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miHistorialActivacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biRegistrarArchivos As ToolStripButton
    Friend WithEvents ToolStripSeparator21 As ToolStripSeparator
    Friend WithEvents miRegistrarArchivos As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As ToolStripSeparator
    Friend WithEvents biEnviar As ToolStripButton
    Friend WithEvents miEnviar As ToolStripMenuItem
End Class
