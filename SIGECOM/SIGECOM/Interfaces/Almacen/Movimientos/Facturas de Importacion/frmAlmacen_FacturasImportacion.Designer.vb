<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlmacen_FacturasImportacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlmacen_FacturasImportacion))
        Dim cmbIdCliente_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstados_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTrasladar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miChequear = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGenerarMTI = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDescargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miIngresoMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizarFecha = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTrasladarMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeleccionMasiva = New System.Windows.Forms.ToolStripMenuItem()
        Me.miChequearMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miImpresionMasiva = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtFecIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biTrasladar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biChequear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerarMTI = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDescargar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.biIngresoMasivo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizarFecha = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSeleccionMasiva = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.biTrasladarMasivo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.biChequearMasivo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImpresionMasiva = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbIdCliente = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCodEmbarque = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFecFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbEstados = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.cmbIdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miTrasladar, Me.miChequear, Me.miGenerarMTI, Me.miDescargar, Me.miIngresoMasivo, Me.miActualizarFecha, Me.miTrasladarMasivo, Me.miSeleccionMasiva, Me.miChequearMasivo, Me.miImpresionMasiva, Me.ToolStripMenuItem1, Me.ToolStripSeparator10, Me.miActualizar, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(171, 368)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(170, 22)
        Me.miImprimir.Text = "Imprimir"
        Me.miImprimir.ToolTipText = "Imprimir Chequeo/Conformidad"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(170, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(170, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(170, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miTrasladar
        '
        Me.miTrasladar.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.miTrasladar.Name = "miTrasladar"
        Me.miTrasladar.Size = New System.Drawing.Size(170, 22)
        Me.miTrasladar.Text = "Trasladar"
        '
        'miChequear
        '
        Me.miChequear.Image = CType(resources.GetObject("miChequear.Image"), System.Drawing.Image)
        Me.miChequear.Name = "miChequear"
        Me.miChequear.Size = New System.Drawing.Size(170, 22)
        Me.miChequear.Text = "Chequear"
        '
        'miGenerarMTI
        '
        Me.miGenerarMTI.Image = CType(resources.GetObject("miGenerarMTI.Image"), System.Drawing.Image)
        Me.miGenerarMTI.Name = "miGenerarMTI"
        Me.miGenerarMTI.Size = New System.Drawing.Size(170, 22)
        Me.miGenerarMTI.Text = "Generar MTI"
        '
        'miDescargar
        '
        Me.miDescargar.Image = CType(resources.GetObject("miDescargar.Image"), System.Drawing.Image)
        Me.miDescargar.Name = "miDescargar"
        Me.miDescargar.Size = New System.Drawing.Size(170, 22)
        Me.miDescargar.Text = "Descargar Factura"
        Me.miDescargar.Visible = False
        '
        'miIngresoMasivo
        '
        Me.miIngresoMasivo.Image = CType(resources.GetObject("miIngresoMasivo.Image"), System.Drawing.Image)
        Me.miIngresoMasivo.Name = "miIngresoMasivo"
        Me.miIngresoMasivo.Size = New System.Drawing.Size(170, 22)
        Me.miIngresoMasivo.Text = "Ingresar Masivo"
        '
        'miActualizarFecha
        '
        Me.miActualizarFecha.Image = Global.SIGECOM.My.Resources.Resources.Fecha
        Me.miActualizarFecha.Name = "miActualizarFecha"
        Me.miActualizarFecha.Size = New System.Drawing.Size(170, 22)
        Me.miActualizarFecha.Text = "Act. Fecha Masivo"
        '
        'miTrasladarMasivo
        '
        Me.miTrasladarMasivo.Image = CType(resources.GetObject("miTrasladarMasivo.Image"), System.Drawing.Image)
        Me.miTrasladarMasivo.Name = "miTrasladarMasivo"
        Me.miTrasladarMasivo.Size = New System.Drawing.Size(170, 22)
        Me.miTrasladarMasivo.Text = "Trasladar Masivo"
        '
        'miSeleccionMasiva
        '
        Me.miSeleccionMasiva.Image = CType(resources.GetObject("miSeleccionMasiva.Image"), System.Drawing.Image)
        Me.miSeleccionMasiva.Name = "miSeleccionMasiva"
        Me.miSeleccionMasiva.Size = New System.Drawing.Size(170, 22)
        Me.miSeleccionMasiva.Text = "Selección Masiva"
        '
        'miChequearMasivo
        '
        Me.miChequearMasivo.Image = CType(resources.GetObject("miChequearMasivo.Image"), System.Drawing.Image)
        Me.miChequearMasivo.Name = "miChequearMasivo"
        Me.miChequearMasivo.Size = New System.Drawing.Size(170, 22)
        Me.miChequearMasivo.Text = "Chequear Masivo"
        '
        'miImpresionMasiva
        '
        Me.miImpresionMasiva.Image = CType(resources.GetObject("miImpresionMasiva.Image"), System.Drawing.Image)
        Me.miImpresionMasiva.Name = "miImpresionMasiva"
        Me.miImpresionMasiva.Size = New System.Drawing.Size(170, 22)
        Me.miImpresionMasiva.Text = "Impresión Masiva"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(167, 6)
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(167, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(170, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(170, 22)
        Me.miSalir.Text = "Salir"
        '
        'txtFecIni
        '
        '
        '
        '
        Me.txtFecIni.DropDownCalendar.Name = ""
        Me.txtFecIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIni.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free
        Me.txtFecIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecIni.IsNullDate = True
        Me.txtFecIni.Location = New System.Drawing.Point(328, 29)
        Me.txtFecIni.Name = "txtFecIni"
        Me.txtFecIni.NullButtonText = "Ninguno"
        Me.txtFecIni.ShowNullButton = True
        Me.txtFecIni.Size = New System.Drawing.Size(90, 20)
        Me.txtFecIni.TabIndex = 4
        Me.txtFecIni.TodayButtonText = "Hoy"
        Me.txtFecIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(335, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Fecha Inicio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(216, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Proveedor"
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
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Black
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Crear un nuevo registro"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator15, Me.biImprimir, Me.ToolStripSeparator1, Me.biNuevo, Me.ToolStripSeparator3, Me.biMostrar, Me.ToolStripSeparator4, Me.biEliminar, Me.ToolStripSeparator5, Me.biTrasladar, Me.ToolStripSeparator9, Me.biChequear, Me.ToolStripSeparator2, Me.biGenerarMTI, Me.ToolStripSeparator17, Me.biDescargar, Me.ToolStripSeparator11, Me.biIngresoMasivo, Me.ToolStripSeparator6, Me.biActualizarFecha, Me.ToolStripSeparator18, Me.biSeleccionMasiva, Me.ToolStripSeparator14, Me.biTrasladarMasivo, Me.ToolStripSeparator16, Me.biChequearMasivo, Me.ToolStripSeparator13, Me.biImpresionMasiva, Me.ToolStripSeparator12, Me.biActualizar, Me.ToolStripSeparator7, Me.biSalir, Me.ToolStripSeparator8})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(836, 31)
        Me.ToolStrip.TabIndex = 22
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
        Me.biImprimir.Text = "Imprimir Factura de Importación"
        Me.biImprimir.ToolTipText = "Imprimir Chequeo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biTrasladar
        '
        Me.biTrasladar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biTrasladar.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.biTrasladar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biTrasladar.Name = "biTrasladar"
        Me.biTrasladar.Size = New System.Drawing.Size(28, 28)
        Me.biTrasladar.Text = "Trasladar Factura de Importación"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'biChequear
        '
        Me.biChequear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biChequear.Image = CType(resources.GetObject("biChequear.Image"), System.Drawing.Image)
        Me.biChequear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biChequear.Name = "biChequear"
        Me.biChequear.Size = New System.Drawing.Size(28, 28)
        Me.biChequear.Text = "Chequear Factura de Importación"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerarMTI
        '
        Me.biGenerarMTI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarMTI.Image = CType(resources.GetObject("biGenerarMTI.Image"), System.Drawing.Image)
        Me.biGenerarMTI.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarMTI.Name = "biGenerarMTI"
        Me.biGenerarMTI.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarMTI.Text = "Generar MTI de Factura de Importación"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 31)
        '
        'biDescargar
        '
        Me.biDescargar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDescargar.Image = CType(resources.GetObject("biDescargar.Image"), System.Drawing.Image)
        Me.biDescargar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDescargar.Name = "biDescargar"
        Me.biDescargar.Size = New System.Drawing.Size(28, 28)
        Me.biDescargar.Text = "Descargar Factura"
        Me.biDescargar.ToolTipText = "Descargar Factura"
        Me.biDescargar.Visible = False
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator11.Visible = False
        '
        'biIngresoMasivo
        '
        Me.biIngresoMasivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biIngresoMasivo.Image = CType(resources.GetObject("biIngresoMasivo.Image"), System.Drawing.Image)
        Me.biIngresoMasivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biIngresoMasivo.Name = "biIngresoMasivo"
        Me.biIngresoMasivo.Size = New System.Drawing.Size(28, 28)
        Me.biIngresoMasivo.Text = "Ingresar Facturas de Importación Masivo"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizarFecha
        '
        Me.biActualizarFecha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizarFecha.Image = Global.SIGECOM.My.Resources.Resources.Fecha
        Me.biActualizarFecha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizarFecha.Name = "biActualizarFecha"
        Me.biActualizarFecha.Size = New System.Drawing.Size(28, 28)
        Me.biActualizarFecha.Text = "Actualizar la fecha de la(s) F/I por embarque"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 31)
        '
        'biSeleccionMasiva
        '
        Me.biSeleccionMasiva.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSeleccionMasiva.Image = CType(resources.GetObject("biSeleccionMasiva.Image"), System.Drawing.Image)
        Me.biSeleccionMasiva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSeleccionMasiva.Name = "biSeleccionMasiva"
        Me.biSeleccionMasiva.Size = New System.Drawing.Size(28, 28)
        Me.biSeleccionMasiva.Text = "Seleccionar Detalles Conformes"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'biTrasladarMasivo
        '
        Me.biTrasladarMasivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biTrasladarMasivo.Image = CType(resources.GetObject("biTrasladarMasivo.Image"), System.Drawing.Image)
        Me.biTrasladarMasivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biTrasladarMasivo.Name = "biTrasladarMasivo"
        Me.biTrasladarMasivo.Size = New System.Drawing.Size(28, 28)
        Me.biTrasladarMasivo.Text = "Trasladar Facturas de Importación Masivo"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 31)
        '
        'biChequearMasivo
        '
        Me.biChequearMasivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biChequearMasivo.Image = CType(resources.GetObject("biChequearMasivo.Image"), System.Drawing.Image)
        Me.biChequearMasivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biChequearMasivo.Name = "biChequearMasivo"
        Me.biChequearMasivo.Size = New System.Drawing.Size(28, 28)
        Me.biChequearMasivo.Text = "Chequear Factura de Importación Masivo"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'biImpresionMasiva
        '
        Me.biImpresionMasiva.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImpresionMasiva.Image = CType(resources.GetObject("biImpresionMasiva.Image"), System.Drawing.Image)
        Me.biImpresionMasiva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImpresionMasiva.Name = "biImpresionMasiva"
        Me.biImpresionMasiva.Size = New System.Drawing.Size(28, 28)
        Me.biImpresionMasiva.Text = "Impresión de Facturas de Importación Masiva"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar el Registro Seleccionado"
        Me.biActualizar.ToolTipText = "Refrescar Datos"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(150, 13)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 13)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 390)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(836, 18)
        Me.ssBarra.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(432, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Fecha Fin"
        '
        'cmbIdCliente
        '
        Me.cmbIdCliente.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdCliente_DesignTimeLayout.LayoutString = resources.GetString("cmbIdCliente_DesignTimeLayout.LayoutString")
        Me.cmbIdCliente.DesignTimeLayout = cmbIdCliente_DesignTimeLayout
        Me.cmbIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdCliente.Location = New System.Drawing.Point(180, 29)
        Me.cmbIdCliente.Name = "cmbIdCliente"
        Me.cmbIdCliente.SelectedIndex = -1
        Me.cmbIdCliente.SelectedItem = Nothing
        Me.cmbIdCliente.Size = New System.Drawing.Size(145, 20)
        Me.cmbIdCliente.TabIndex = 3
        Me.cmbIdCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCodEmbarque)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtFecFin)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbEstados)
        Me.GroupBox1.Controls.Add(Me.txtFecIni)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbIdCliente)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbIdLocacion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbOficinas)
        Me.GroupBox1.Controls.Add(Me.txtNumDoc)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(801, 55)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Búsqueda"
        '
        'txtCodEmbarque
        '
        Me.txtCodEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmbarque.Location = New System.Drawing.Point(604, 29)
        Me.txtCodEmbarque.MaxLength = 30
        Me.txtCodEmbarque.Name = "txtCodEmbarque"
        Me.txtCodEmbarque.Size = New System.Drawing.Size(65, 20)
        Me.txtCodEmbarque.TabIndex = 7
        Me.txtCodEmbarque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(605, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Embarque"
        '
        'txtFecFin
        '
        '
        '
        '
        Me.txtFecFin.DropDownCalendar.Name = ""
        Me.txtFecFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFin.Location = New System.Drawing.Point(421, 29)
        Me.txtFecFin.Name = "txtFecFin"
        Me.txtFecFin.NullButtonText = "Ninguno"
        Me.txtFecFin.ShowNullButton = True
        Me.txtFecFin.Size = New System.Drawing.Size(90, 20)
        Me.txtFecFin.TabIndex = 5
        Me.txtFecFin.TodayButtonText = "Hoy"
        Me.txtFecFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(534, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Estado"
        '
        'cmbEstados
        '
        Me.cmbEstados.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstados_DesignTimeLayout.LayoutString = resources.GetString("cmbEstados_DesignTimeLayout.LayoutString")
        Me.cmbEstados.DesignTimeLayout = cmbEstados_DesignTimeLayout
        Me.cmbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstados.Location = New System.Drawing.Point(514, 29)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.SelectedIndex = -1
        Me.cmbEstados.SelectedItem = Nothing
        Me.cmbEstados.Size = New System.Drawing.Size(87, 20)
        Me.cmbEstados.TabIndex = 6
        Me.cmbEstados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(94, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Almacén"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(65, 29)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(112, 20)
        Me.cmbIdLocacion.TabIndex = 2
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Oficina"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(5, 29)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(57, 20)
        Me.cmbOficinas.TabIndex = 1
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.Location = New System.Drawing.Point(671, 29)
        Me.txtNumDoc.MaxLength = 30
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(60, 20)
        Me.txtNumDoc.TabIndex = 8
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(733, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(65, 25)
        Me.btnBuscar.TabIndex = 9
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(677, 14)
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
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(0, 91)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(836, 296)
        Me.dgvDatos.TabIndex = 23
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'frmAlmacen_FacturasImportacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(836, 408)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(716, 399)
        Me.Name = "frmAlmacen_FacturasImportacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chequeo de Facturas de Importación"
        Me.cmOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.cmbIdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbEstados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFecIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbIdCliente As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbEstados As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biTrasladar As System.Windows.Forms.ToolStripButton
    Friend WithEvents miTrasladar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDescargar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biDescargar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtFecFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents biChequear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miChequear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biIngresoMasivo As System.Windows.Forms.ToolStripButton
    Friend WithEvents miIngresoMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImpresionMasiva As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miImpresionMasiva As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCodEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents biTrasladarMasivo As System.Windows.Forms.ToolStripButton
    Friend WithEvents biChequearMasivo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miChequearMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miTrasladarMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeleccionMasiva As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biSeleccionMasiva As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miGenerarMTI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biGenerarMTI As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarFecha As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biActualizarFecha As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
End Class
