<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillasSueldos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillasSueldos))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCalcular = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCalcularEPS = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miProcesar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miExportarPlanilla = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFormatoExcelDsctos = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFormatoExcelIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGenerarArchivoAfpNet = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGenerarArchivoPlame = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.miImportarExcelDsctos = New System.Windows.Forms.ToolStripMenuItem()
        Me.miImportarExcelIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miEnviarCorreoMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biExportarPlanilla = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImportarExcelDsctos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImportarExcelIng = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCalcular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.biProcesar = New System.Windows.Forms.ToolStripButton()
        Me.biGenerarArchivoAfpNet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.biFormatoExcelDsctos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biFormatoExcelIng = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerarArchivo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerarArchivoPlame = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtIdPlanilla = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMes = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvFormatoExcelDsctos = New System.Windows.Forms.DataGridView()
        Me.dgvImportarExcelDsctos = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.dgvExportarPlanilla = New System.Windows.Forms.DataGridView()
        Me.dgvFormatoExcelIng = New System.Windows.Forms.DataGridView()
        Me.dgvImportarExcelIng = New System.Windows.Forms.DataGridView()
        Me.dgvGenerarAfpNet = New System.Windows.Forms.DataGridView()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFormatoExcelDsctos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvImportarExcelDsctos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExportarPlanilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFormatoExcelIng, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvImportarExcelIng, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGenerarAfpNet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miCalcular, Me.miCalcularEPS, Me.miCerrar, Me.miProcesar, Me.miSeparador1, Me.miExportarPlanilla, Me.miFormatoExcelDsctos, Me.miFormatoExcelIng, Me.miGenerarArchivoAfpNet, Me.miGenerarArchivoPlame, Me.ToolStripSeparator19, Me.miImportarExcelDsctos, Me.miImportarExcelIng, Me.ToolStripMenuItem1, Me.miEnviarCorreoMasivo, Me.ToolStripSeparator9, Me.miActualizar, Me.miSalir})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(201, 424)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(200, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(200, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(200, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(200, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miCalcular
        '
        Me.miCalcular.Image = CType(resources.GetObject("miCalcular.Image"), System.Drawing.Image)
        Me.miCalcular.Name = "miCalcular"
        Me.miCalcular.Size = New System.Drawing.Size(200, 22)
        Me.miCalcular.Text = "Calcular Dsctos"
        '
        'miCalcularEPS
        '
        Me.miCalcularEPS.Image = CType(resources.GetObject("miCalcularEPS.Image"), System.Drawing.Image)
        Me.miCalcularEPS.Name = "miCalcularEPS"
        Me.miCalcularEPS.Size = New System.Drawing.Size(200, 22)
        Me.miCalcularEPS.Text = "Calcular EPS"
        Me.miCalcularEPS.ToolTipText = "Calcular EPS de la planilla seleccionada"
        '
        'miCerrar
        '
        Me.miCerrar.Image = CType(resources.GetObject("miCerrar.Image"), System.Drawing.Image)
        Me.miCerrar.Name = "miCerrar"
        Me.miCerrar.Size = New System.Drawing.Size(200, 22)
        Me.miCerrar.Text = "Cerrar"
        '
        'miProcesar
        '
        Me.miProcesar.Image = CType(resources.GetObject("miProcesar.Image"), System.Drawing.Image)
        Me.miProcesar.Name = "miProcesar"
        Me.miProcesar.Size = New System.Drawing.Size(200, 22)
        Me.miProcesar.Text = "Procesar"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(197, 6)
        '
        'miExportarPlanilla
        '
        Me.miExportarPlanilla.Image = CType(resources.GetObject("miExportarPlanilla.Image"), System.Drawing.Image)
        Me.miExportarPlanilla.Name = "miExportarPlanilla"
        Me.miExportarPlanilla.Size = New System.Drawing.Size(200, 22)
        Me.miExportarPlanilla.Text = "Exportar Planilla"
        '
        'miFormatoExcelDsctos
        '
        Me.miFormatoExcelDsctos.Image = CType(resources.GetObject("miFormatoExcelDsctos.Image"), System.Drawing.Image)
        Me.miFormatoExcelDsctos.Name = "miFormatoExcelDsctos"
        Me.miFormatoExcelDsctos.Size = New System.Drawing.Size(200, 22)
        Me.miFormatoExcelDsctos.Text = "Formato Dsctos"
        '
        'miFormatoExcelIng
        '
        Me.miFormatoExcelIng.Image = CType(resources.GetObject("miFormatoExcelIng.Image"), System.Drawing.Image)
        Me.miFormatoExcelIng.Name = "miFormatoExcelIng"
        Me.miFormatoExcelIng.Size = New System.Drawing.Size(200, 22)
        Me.miFormatoExcelIng.Text = "Formato Ingresos"
        '
        'miGenerarArchivoAfpNet
        '
        Me.miGenerarArchivoAfpNet.Image = CType(resources.GetObject("miGenerarArchivoAfpNet.Image"), System.Drawing.Image)
        Me.miGenerarArchivoAfpNet.Name = "miGenerarArchivoAfpNet"
        Me.miGenerarArchivoAfpNet.Size = New System.Drawing.Size(200, 22)
        Me.miGenerarArchivoAfpNet.Text = "Generar Archivo AfpNet"
        '
        'miGenerarArchivoPlame
        '
        Me.miGenerarArchivoPlame.Image = Global.SIGECOM.My.Resources.Resources.documentosEmitidos
        Me.miGenerarArchivoPlame.Name = "miGenerarArchivoPlame"
        Me.miGenerarArchivoPlame.Size = New System.Drawing.Size(200, 22)
        Me.miGenerarArchivoPlame.Text = "Generar Archivo Plame"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(197, 6)
        '
        'miImportarExcelDsctos
        '
        Me.miImportarExcelDsctos.Image = CType(resources.GetObject("miImportarExcelDsctos.Image"), System.Drawing.Image)
        Me.miImportarExcelDsctos.Name = "miImportarExcelDsctos"
        Me.miImportarExcelDsctos.Size = New System.Drawing.Size(200, 22)
        Me.miImportarExcelDsctos.Text = "Importar Dsctos"
        '
        'miImportarExcelIng
        '
        Me.miImportarExcelIng.Image = CType(resources.GetObject("miImportarExcelIng.Image"), System.Drawing.Image)
        Me.miImportarExcelIng.Name = "miImportarExcelIng"
        Me.miImportarExcelIng.Size = New System.Drawing.Size(200, 22)
        Me.miImportarExcelIng.Text = "Importar Ingresos"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(197, 6)
        '
        'miEnviarCorreoMasivo
        '
        Me.miEnviarCorreoMasivo.Image = Global.SIGECOM.My.Resources.Resources.Enviar_Pr
        Me.miEnviarCorreoMasivo.Name = "miEnviarCorreoMasivo"
        Me.miEnviarCorreoMasivo.Size = New System.Drawing.Size(200, 22)
        Me.miEnviarCorreoMasivo.Text = "Enviar Correo Masivo"
        Me.miEnviarCorreoMasivo.ToolTipText = "Enviar correo masivo con la boleta de pago a todo el personal"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(197, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(200, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(200, 22)
        Me.miSalir.Text = "Salir"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.biImprimir, Me.ToolStripSeparator2, Me.biExportarPlanilla, Me.ToolStripSeparator13, Me.biNuevo, Me.ToolStripSeparator1, Me.biMostrar, Me.ToolStripSeparator3, Me.biEliminar, Me.ToolStripSeparator10, Me.biImportarExcelDsctos, Me.ToolStripSeparator12, Me.biImportarExcelIng, Me.ToolStripSeparator18, Me.biCalcular, Me.ToolStripSeparator4, Me.biCerrar, Me.ToolStripSeparator11, Me.biProcesar, Me.biGenerarArchivoAfpNet, Me.ToolStripSeparator5, Me.ToolStripSeparator14, Me.biFormatoExcelDsctos, Me.ToolStripSeparator8, Me.biFormatoExcelIng, Me.ToolStripSeparator17, Me.biActualizar, Me.ToolStripSeparator7, Me.biGenerarArchivo, Me.ToolStripSeparator16, Me.biGenerarArchivoPlame, Me.ToolStripSeparator15, Me.biSalir, Me.ToolStripSeparator20})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(772, 31)
        Me.ToolStrip.TabIndex = 205
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Planilla de Sueldos"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biExportarPlanilla
        '
        Me.biExportarPlanilla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biExportarPlanilla.Image = CType(resources.GetObject("biExportarPlanilla.Image"), System.Drawing.Image)
        Me.biExportarPlanilla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biExportarPlanilla.Name = "biExportarPlanilla"
        Me.biExportarPlanilla.Size = New System.Drawing.Size(28, 28)
        Me.biExportarPlanilla.Text = "Exportar Planilla de Sueldo a Excel"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Nueva Planilla de Sueldos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar Planilla de Sueldos"
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
        Me.biEliminar.Text = "Eliminar Planilla de Sueldos"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 31)
        '
        'biImportarExcelDsctos
        '
        Me.biImportarExcelDsctos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImportarExcelDsctos.Image = CType(resources.GetObject("biImportarExcelDsctos.Image"), System.Drawing.Image)
        Me.biImportarExcelDsctos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImportarExcelDsctos.Name = "biImportarExcelDsctos"
        Me.biImportarExcelDsctos.Size = New System.Drawing.Size(28, 28)
        Me.biImportarExcelDsctos.Text = "Importar Excel Dsctos a Planilla de Sueldos"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        '
        'biImportarExcelIng
        '
        Me.biImportarExcelIng.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImportarExcelIng.Image = CType(resources.GetObject("biImportarExcelIng.Image"), System.Drawing.Image)
        Me.biImportarExcelIng.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImportarExcelIng.Name = "biImportarExcelIng"
        Me.biImportarExcelIng.Size = New System.Drawing.Size(28, 28)
        Me.biImportarExcelIng.Text = "Importar Excel Ingresos a Planilla de Sueldos"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 31)
        '
        'biCalcular
        '
        Me.biCalcular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCalcular.Image = CType(resources.GetObject("biCalcular.Image"), System.Drawing.Image)
        Me.biCalcular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCalcular.Name = "biCalcular"
        Me.biCalcular.Size = New System.Drawing.Size(28, 28)
        Me.biCalcular.Text = "Calcular Descuentos de Planilla de Sueldos"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = CType(resources.GetObject("biCerrar.Image"), System.Drawing.Image)
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar / Revertir Cierre de Planilla de Sueldos"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'biProcesar
        '
        Me.biProcesar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biProcesar.Image = CType(resources.GetObject("biProcesar.Image"), System.Drawing.Image)
        Me.biProcesar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biProcesar.Name = "biProcesar"
        Me.biProcesar.Size = New System.Drawing.Size(28, 28)
        Me.biProcesar.Text = "Procesar Planilla de Sueldos"
        '
        'biGenerarArchivoAfpNet
        '
        Me.biGenerarArchivoAfpNet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarArchivoAfpNet.Image = CType(resources.GetObject("biGenerarArchivoAfpNet.Image"), System.Drawing.Image)
        Me.biGenerarArchivoAfpNet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarArchivoAfpNet.Name = "biGenerarArchivoAfpNet"
        Me.biGenerarArchivoAfpNet.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarArchivoAfpNet.Text = "Generar Archivo AfpNet"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'biFormatoExcelDsctos
        '
        Me.biFormatoExcelDsctos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biFormatoExcelDsctos.Image = CType(resources.GetObject("biFormatoExcelDsctos.Image"), System.Drawing.Image)
        Me.biFormatoExcelDsctos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biFormatoExcelDsctos.Name = "biFormatoExcelDsctos"
        Me.biFormatoExcelDsctos.Size = New System.Drawing.Size(28, 28)
        Me.biFormatoExcelDsctos.Text = "Formato de Descuentos de Planilla"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biFormatoExcelIng
        '
        Me.biFormatoExcelIng.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biFormatoExcelIng.Image = CType(resources.GetObject("biFormatoExcelIng.Image"), System.Drawing.Image)
        Me.biFormatoExcelIng.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biFormatoExcelIng.Name = "biFormatoExcelIng"
        Me.biFormatoExcelIng.Size = New System.Drawing.Size(28, 28)
        Me.biFormatoExcelIng.Text = "Formato de Ingresos de Planilla"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Planillas de Sueldos"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerarArchivo
        '
        Me.biGenerarArchivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarArchivo.Image = CType(resources.GetObject("biGenerarArchivo.Image"), System.Drawing.Image)
        Me.biGenerarArchivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarArchivo.Name = "biGenerarArchivo"
        Me.biGenerarArchivo.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarArchivo.Text = "Generar Archivo"
        Me.biGenerarArchivo.ToolTipText = "Generar Archivo para pago de haberes en el banco"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerarArchivoPlame
        '
        Me.biGenerarArchivoPlame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerarArchivoPlame.Image = Global.SIGECOM.My.Resources.Resources.documentosEmitidos
        Me.biGenerarArchivoPlame.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerarArchivoPlame.Name = "biGenerarArchivoPlame"
        Me.biGenerarArchivoPlame.Size = New System.Drawing.Size(28, 28)
        Me.biGenerarArchivoPlame.Text = "ToolStripButton1"
        Me.biGenerarArchivoPlame.ToolTipText = "Generar Archivo Plame"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(6, 31)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 519)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(772, 20)
        Me.ssBarra.TabIndex = 207
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(210, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(0, 100)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(772, 419)
        Me.dgvDatos.TabIndex = 5
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.Label14)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbEstado)
        Me.gbDatosBusqueda.Controls.Add(Me.txtIdPlanilla)
        Me.gbDatosBusqueda.Controls.Add(Me.Label6)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.txtMes)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Controls.Add(Me.txtPeriodo)
        Me.gbDatosBusqueda.Controls.Add(Me.Label1)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(12, 34)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(747, 60)
        Me.gbDatosBusqueda.TabIndex = 0
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(514, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 232
        Me.Label14.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(478, 34)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(116, 20)
        Me.cmbEstado.TabIndex = 4
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIdPlanilla
        '
        Me.txtIdPlanilla.Location = New System.Drawing.Point(309, 34)
        Me.txtIdPlanilla.Name = "txtIdPlanilla"
        Me.txtIdPlanilla.Numeric = True
        Me.txtIdPlanilla.Size = New System.Drawing.Size(94, 20)
        Me.txtIdPlanilla.TabIndex = 3
        Me.txtIdPlanilla.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(336, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 227
        Me.Label6.Text = "Código"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(178, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 225
        Me.Label2.Text = "Mes"
        '
        'txtMes
        '
        Me.txtMes.Location = New System.Drawing.Point(142, 34)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Numeric = True
        Me.txtMes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMes.Size = New System.Drawing.Size(98, 20)
        Me.txtMes.TabIndex = 2
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(643, 31)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(71, 23)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(27, 34)
        Me.txtPeriodo.Maximum = 2059
        Me.txtPeriodo.Minimum = 2006
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(65, 20)
        Me.txtPeriodo.TabIndex = 1
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.Value = 2006
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "Periodo"
        '
        'dgvFormatoExcelDsctos
        '
        Me.dgvFormatoExcelDsctos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFormatoExcelDsctos.Location = New System.Drawing.Point(714, 5)
        Me.dgvFormatoExcelDsctos.Name = "dgvFormatoExcelDsctos"
        Me.dgvFormatoExcelDsctos.Size = New System.Drawing.Size(27, 23)
        Me.dgvFormatoExcelDsctos.TabIndex = 284
        Me.dgvFormatoExcelDsctos.Visible = False
        '
        'dgvImportarExcelDsctos
        '
        Me.dgvImportarExcelDsctos.AllowUserToAddRows = False
        Me.dgvImportarExcelDsctos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImportarExcelDsctos.Location = New System.Drawing.Point(681, 5)
        Me.dgvImportarExcelDsctos.Name = "dgvImportarExcelDsctos"
        Me.dgvImportarExcelDsctos.Size = New System.Drawing.Size(27, 23)
        Me.dgvImportarExcelDsctos.TabIndex = 286
        Me.dgvImportarExcelDsctos.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'dgvExportarPlanilla
        '
        Me.dgvExportarPlanilla.AllowUserToAddRows = False
        Me.dgvExportarPlanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExportarPlanilla.Location = New System.Drawing.Point(582, 5)
        Me.dgvExportarPlanilla.Name = "dgvExportarPlanilla"
        Me.dgvExportarPlanilla.Size = New System.Drawing.Size(27, 23)
        Me.dgvExportarPlanilla.TabIndex = 287
        Me.dgvExportarPlanilla.Visible = False
        '
        'dgvFormatoExcelIng
        '
        Me.dgvFormatoExcelIng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFormatoExcelIng.Location = New System.Drawing.Point(648, 5)
        Me.dgvFormatoExcelIng.Name = "dgvFormatoExcelIng"
        Me.dgvFormatoExcelIng.Size = New System.Drawing.Size(27, 23)
        Me.dgvFormatoExcelIng.TabIndex = 288
        Me.dgvFormatoExcelIng.Visible = False
        '
        'dgvImportarExcelIng
        '
        Me.dgvImportarExcelIng.AllowUserToAddRows = False
        Me.dgvImportarExcelIng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImportarExcelIng.Location = New System.Drawing.Point(615, 5)
        Me.dgvImportarExcelIng.Name = "dgvImportarExcelIng"
        Me.dgvImportarExcelIng.Size = New System.Drawing.Size(27, 23)
        Me.dgvImportarExcelIng.TabIndex = 289
        Me.dgvImportarExcelIng.Visible = False
        '
        'dgvGenerarAfpNet
        '
        Me.dgvGenerarAfpNet.AllowUserToAddRows = False
        Me.dgvGenerarAfpNet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGenerarAfpNet.Location = New System.Drawing.Point(744, 5)
        Me.dgvGenerarAfpNet.Name = "dgvGenerarAfpNet"
        Me.dgvGenerarAfpNet.Size = New System.Drawing.Size(27, 23)
        Me.dgvGenerarAfpNet.TabIndex = 290
        Me.dgvGenerarAfpNet.Visible = False
        '
        'frmPlanillasSueldos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(772, 539)
        Me.Controls.Add(Me.dgvGenerarAfpNet)
        Me.Controls.Add(Me.dgvFormatoExcelIng)
        Me.Controls.Add(Me.dgvImportarExcelIng)
        Me.Controls.Add(Me.dgvExportarPlanilla)
        Me.Controls.Add(Me.dgvFormatoExcelDsctos)
        Me.Controls.Add(Me.dgvImportarExcelDsctos)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanillasSueldos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planillas de Sueldo"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFormatoExcelDsctos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvImportarExcelDsctos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExportarPlanilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFormatoExcelIng, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvImportarExcelIng, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGenerarAfpNet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMes As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtIdPlanilla As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents biProcesar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCalcular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miProcesar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCalcular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miCerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miImportarExcelDsctos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miFormatoExcelDsctos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvFormatoExcelDsctos As System.Windows.Forms.DataGridView
    Friend WithEvents dgvImportarExcelDsctos As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents biImportarExcelDsctos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biExportarPlanilla As System.Windows.Forms.ToolStripButton
    Friend WithEvents miExportarPlanilla As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvExportarPlanilla As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biFormatoExcelDsctos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGenerarArchivo As ToolStripButton
    Friend WithEvents ToolStripSeparator16 As ToolStripSeparator
    Friend WithEvents biFormatoExcelIng As System.Windows.Forms.ToolStripButton
    Friend WithEvents miFormatoExcelIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miImportarExcelIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biImportarExcelIng As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvFormatoExcelIng As System.Windows.Forms.DataGridView
    Friend WithEvents dgvImportarExcelIng As System.Windows.Forms.DataGridView
    Friend WithEvents miEnviarCorreoMasivo As ToolStripMenuItem
    Friend WithEvents miGenerarArchivoAfpNet As ToolStripMenuItem
    Friend WithEvents dgvGenerarAfpNet As DataGridView
    Friend WithEvents biGenerarArchivoAfpNet As ToolStripButton
    Friend WithEvents miGenerarArchivoPlame As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator19 As ToolStripSeparator
    Friend WithEvents biGenerarArchivoPlame As ToolStripButton
    Friend WithEvents ToolStripSeparator20 As ToolStripSeparator
    Friend WithEvents miCalcularEPS As ToolStripMenuItem
End Class
