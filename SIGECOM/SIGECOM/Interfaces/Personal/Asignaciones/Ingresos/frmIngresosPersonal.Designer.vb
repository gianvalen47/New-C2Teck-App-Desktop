<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresosPersonal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresosPersonal))
        Dim cmbIngreso_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFormatoExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miCuotas = New System.Windows.Forms.ToolStripMenuItem()
        Me.miIngresoMasivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miImportarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.miIngresarBonosMina = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miDescandoMedico = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biFormatoExcel = New System.Windows.Forms.ToolStripButton()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biIngresarMasivo = New System.Windows.Forms.ToolStripButton()
        Me.biCuotas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImportarExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biIngresarBonosMina = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbIngreso = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cmbCodArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.chkColaborador = New System.Windows.Forms.CheckBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscarColaborador = New System.Windows.Forms.Button()
        Me.pboxLimpiarColaborador = New System.Windows.Forms.PictureBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.dgvFormatoExcel = New System.Windows.Forms.DataGridView()
        Me.dgvImportarExcel = New System.Windows.Forms.DataGridView()
        Me.dgvPersonal = New System.Windows.Forms.DataGridView()
        Me.miIngresosubsidios = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbIngreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLimpiarColaborador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFormatoExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvImportarExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 382)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(802, 20)
        Me.ssBarra.TabIndex = 234
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(420, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(260, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miFormatoExcel, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miCuotas, Me.miIngresoMasivo, Me.miImportarExcel, Me.miIngresarBonosMina, Me.miSeparador1, Me.miDescandoMedico, Me.miIngresosubsidios, Me.ToolStripMenuItem1, Me.miActualizar, Me.miSalir})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(220, 324)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(219, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miFormatoExcel
        '
        Me.miFormatoExcel.Image = CType(resources.GetObject("miFormatoExcel.Image"), System.Drawing.Image)
        Me.miFormatoExcel.Name = "miFormatoExcel"
        Me.miFormatoExcel.Size = New System.Drawing.Size(219, 22)
        Me.miFormatoExcel.Text = "Formato Excel"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(219, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(219, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(219, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miCuotas
        '
        Me.miCuotas.Image = CType(resources.GetObject("miCuotas.Image"), System.Drawing.Image)
        Me.miCuotas.Name = "miCuotas"
        Me.miCuotas.Size = New System.Drawing.Size(219, 22)
        Me.miCuotas.Text = "Ingreso Cuotas"
        '
        'miIngresoMasivo
        '
        Me.miIngresoMasivo.Image = CType(resources.GetObject("miIngresoMasivo.Image"), System.Drawing.Image)
        Me.miIngresoMasivo.Name = "miIngresoMasivo"
        Me.miIngresoMasivo.Size = New System.Drawing.Size(219, 22)
        Me.miIngresoMasivo.Text = "Ingreso Masivo"
        '
        'miImportarExcel
        '
        Me.miImportarExcel.Image = CType(resources.GetObject("miImportarExcel.Image"), System.Drawing.Image)
        Me.miImportarExcel.Name = "miImportarExcel"
        Me.miImportarExcel.Size = New System.Drawing.Size(219, 22)
        Me.miImportarExcel.Text = "Importar Excel"
        '
        'miIngresarBonosMina
        '
        Me.miIngresarBonosMina.Image = CType(resources.GetObject("miIngresarBonosMina.Image"), System.Drawing.Image)
        Me.miIngresarBonosMina.Name = "miIngresarBonosMina"
        Me.miIngresarBonosMina.Size = New System.Drawing.Size(219, 22)
        Me.miIngresarBonosMina.Text = "Ingresar Bonos / Vales Mina"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(216, 6)
        '
        'miDescandoMedico
        '
        Me.miDescandoMedico.Image = CType(resources.GetObject("miDescandoMedico.Image"), System.Drawing.Image)
        Me.miDescandoMedico.Name = "miDescandoMedico"
        Me.miDescandoMedico.Size = New System.Drawing.Size(219, 22)
        Me.miDescandoMedico.Text = "Ingresar Descanso Medico"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(216, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(219, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(219, 22)
        Me.miSalir.Text = "Salir"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.biImprimir, Me.ToolStripSeparator2, Me.ToolStripSeparator8, Me.biFormatoExcel, Me.biNuevo, Me.ToolStripSeparator1, Me.biMostrar, Me.ToolStripSeparator3, Me.biEliminar, Me.ToolStripSeparator4, Me.biIngresarMasivo, Me.biCuotas, Me.ToolStripSeparator11, Me.biImportarExcel, Me.ToolStripSeparator9, Me.biIngresarBonosMina, Me.ToolStripSeparator7, Me.biActualizar, Me.ToolStripSeparator5, Me.biSalir, Me.ToolStripSeparator10})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(802, 31)
        Me.ToolStrip.TabIndex = 233
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
        Me.biImprimir.Text = "Imprimir Ingreso de Personal"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biFormatoExcel
        '
        Me.biFormatoExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biFormatoExcel.Image = CType(resources.GetObject("biFormatoExcel.Image"), System.Drawing.Image)
        Me.biFormatoExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biFormatoExcel.Name = "biFormatoExcel"
        Me.biFormatoExcel.Size = New System.Drawing.Size(28, 28)
        Me.biFormatoExcel.Text = "Descargar Formato Excel"
        Me.biFormatoExcel.ToolTipText = "Descargar Formato Excel"
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Nuevo Ingreso de Personal"
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
        Me.biMostrar.Text = "Mostrar Ingreso de Personal"
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
        Me.biEliminar.Text = "Eliminar Ingreso de Personal"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biIngresarMasivo
        '
        Me.biIngresarMasivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biIngresarMasivo.Image = CType(resources.GetObject("biIngresarMasivo.Image"), System.Drawing.Image)
        Me.biIngresarMasivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biIngresarMasivo.Name = "biIngresarMasivo"
        Me.biIngresarMasivo.Size = New System.Drawing.Size(28, 28)
        Me.biIngresarMasivo.Text = "Ingreso de Personal Masivo"
        '
        'biCuotas
        '
        Me.biCuotas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCuotas.Image = CType(resources.GetObject("biCuotas.Image"), System.Drawing.Image)
        Me.biCuotas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCuotas.Name = "biCuotas"
        Me.biCuotas.Size = New System.Drawing.Size(28, 28)
        Me.biCuotas.Text = "Ingresar Cuotas"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'biImportarExcel
        '
        Me.biImportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImportarExcel.Image = CType(resources.GetObject("biImportarExcel.Image"), System.Drawing.Image)
        Me.biImportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImportarExcel.Name = "biImportarExcel"
        Me.biImportarExcel.Size = New System.Drawing.Size(28, 28)
        Me.biImportarExcel.Text = "Importar Formato Excel"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'biIngresarBonosMina
        '
        Me.biIngresarBonosMina.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biIngresarBonosMina.Image = CType(resources.GetObject("biIngresarBonosMina.Image"), System.Drawing.Image)
        Me.biIngresarBonosMina.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biIngresarBonosMina.Name = "biIngresarBonosMina"
        Me.biIngresarBonosMina.Size = New System.Drawing.Size(28, 28)
        Me.biIngresarBonosMina.Text = "Ingresar Bonos / Vales de Alimentos Mina"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Ingresos de Personal"
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
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 31)
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.txtanio)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.Label1)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbIngreso)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbCodArea)
        Me.gbDatosBusqueda.Controls.Add(Me.chkColaborador)
        Me.gbDatosBusqueda.Controls.Add(Me.Label26)
        Me.gbDatosBusqueda.Controls.Add(Me.txtColaborador)
        Me.gbDatosBusqueda.Controls.Add(Me.Label7)
        Me.gbDatosBusqueda.Controls.Add(Me.lblPersona)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbCentroCosto)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscarColaborador)
        Me.gbDatosBusqueda.Controls.Add(Me.pboxLimpiarColaborador)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(5, 37)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(767, 57)
        Me.gbDatosBusqueda.TabIndex = 0
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtanio
        '
        Me.txtanio.Location = New System.Drawing.Point(6, 31)
        Me.txtanio.Maximum = 2099
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2003
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(47, 20)
        Me.txtanio.TabIndex = 1
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2003
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 237
        Me.Label2.Text = "Año"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(393, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 259
        Me.Label1.Text = "Rubro"
        '
        'cmbIngreso
        '
        Me.cmbIngreso.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIngreso_DesignTimeLayout.LayoutString = resources.GetString("cmbIngreso_DesignTimeLayout.LayoutString")
        Me.cmbIngreso.DesignTimeLayout = cmbIngreso_DesignTimeLayout
        Me.cmbIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIngreso.Location = New System.Drawing.Point(330, 31)
        Me.cmbIngreso.Name = "cmbIngreso"
        Me.cmbIngreso.SelectedIndex = -1
        Me.cmbIngreso.SelectedItem = Nothing
        Me.cmbIngreso.Size = New System.Drawing.Size(166, 20)
        Me.cmbIngreso.TabIndex = 4
        Me.cmbIngreso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(694, 28)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
        Me.btnBuscar.TabIndex = 7
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbCodArea
        '
        Me.cmbCodArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodArea_DesignTimeLayout.LayoutString = resources.GetString("cmbCodArea_DesignTimeLayout.LayoutString")
        Me.cmbCodArea.DesignTimeLayout = cmbCodArea_DesignTimeLayout
        Me.cmbCodArea.Location = New System.Drawing.Point(59, 31)
        Me.cmbCodArea.Name = "cmbCodArea"
        Me.cmbCodArea.SelectedIndex = -1
        Me.cmbCodArea.SelectedItem = Nothing
        Me.cmbCodArea.Size = New System.Drawing.Size(119, 20)
        Me.cmbCodArea.TabIndex = 2
        Me.cmbCodArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chkColaborador
        '
        Me.chkColaborador.AutoSize = True
        Me.chkColaborador.Checked = True
        Me.chkColaborador.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkColaborador.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkColaborador.Location = New System.Drawing.Point(602, 15)
        Me.chkColaborador.Name = "chkColaborador"
        Me.chkColaborador.Size = New System.Drawing.Size(15, 14)
        Me.chkColaborador.TabIndex = 257
        Me.chkColaborador.Tag = ""
        Me.chkColaborador.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkColaborador.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(213, 15)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 13)
        Me.Label26.TabIndex = 252
        Me.Label26.Text = "Centro Costo"
        '
        'txtColaborador
        '
        Me.txtColaborador.BackColor = System.Drawing.SystemColors.Window
        Me.txtColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColaborador.Location = New System.Drawing.Point(502, 31)
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(162, 20)
        Me.txtColaborador.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(102, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 251
        Me.Label7.Text = "Area"
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersona.Location = New System.Drawing.Point(527, 15)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(75, 13)
        Me.lblPersona.TabIndex = 256
        Me.lblPersona.Text = "Colaborador"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(184, 31)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(140, 20)
        Me.cmbCentroCosto.TabIndex = 3
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarColaborador
        '
        Me.btnBuscarColaborador.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarColaborador.Location = New System.Drawing.Point(666, 30)
        Me.btnBuscarColaborador.Name = "btnBuscarColaborador"
        Me.btnBuscarColaborador.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarColaborador.TabIndex = 6
        Me.btnBuscarColaborador.TabStop = False
        Me.btnBuscarColaborador.UseVisualStyleBackColor = True
        '
        'pboxLimpiarColaborador
        '
        Me.pboxLimpiarColaborador.Enabled = False
        Me.pboxLimpiarColaborador.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarColaborador.Location = New System.Drawing.Point(617, 11)
        Me.pboxLimpiarColaborador.Name = "pboxLimpiarColaborador"
        Me.pboxLimpiarColaborador.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarColaborador.TabIndex = 258
        Me.pboxLimpiarColaborador.TabStop = False
        Me.pboxLimpiarColaborador.Tag = "Limpiar Cliente"
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(0, 98)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(777, 281)
        Me.dgvDatos.TabIndex = 236
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvFormatoExcel
        '
        Me.dgvFormatoExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFormatoExcel.Location = New System.Drawing.Point(699, 8)
        Me.dgvFormatoExcel.Name = "dgvFormatoExcel"
        Me.dgvFormatoExcel.Size = New System.Drawing.Size(73, 23)
        Me.dgvFormatoExcel.TabIndex = 284
        Me.dgvFormatoExcel.Visible = False
        '
        'dgvImportarExcel
        '
        Me.dgvImportarExcel.AllowUserToAddRows = False
        Me.dgvImportarExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImportarExcel.Location = New System.Drawing.Point(620, 8)
        Me.dgvImportarExcel.Name = "dgvImportarExcel"
        Me.dgvImportarExcel.Size = New System.Drawing.Size(73, 23)
        Me.dgvImportarExcel.TabIndex = 285
        Me.dgvImportarExcel.Visible = False
        '
        'dgvPersonal
        '
        Me.dgvPersonal.AllowUserToAddRows = False
        Me.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPersonal.Location = New System.Drawing.Point(541, 8)
        Me.dgvPersonal.Name = "dgvPersonal"
        Me.dgvPersonal.Size = New System.Drawing.Size(73, 23)
        Me.dgvPersonal.TabIndex = 289
        Me.dgvPersonal.Visible = False
        '
        'miIngresosubsidios
        '
        Me.miIngresosubsidios.Image = CType(resources.GetObject("miIngresosubsidios.Image"), System.Drawing.Image)
        Me.miIngresosubsidios.Name = "miIngresosubsidios"
        Me.miIngresosubsidios.Size = New System.Drawing.Size(219, 22)
        Me.miIngresosubsidios.Text = "Ingresar Subsidios"
        Me.miIngresosubsidios.ToolTipText = "Importar las faltas por subsidios"
        '
        'frmIngresosPersonal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(802, 402)
        Me.Controls.Add(Me.dgvPersonal)
        Me.Controls.Add(Me.dgvImportarExcel)
        Me.Controls.Add(Me.dgvFormatoExcel)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIngresosPersonal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresos de Personal"
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbIngreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLimpiarColaborador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFormatoExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvImportarExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbCodArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents chkColaborador As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarColaborador As System.Windows.Forms.Button
    Friend WithEvents pboxLimpiarColaborador As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbIngreso As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents biIngresarMasivo As System.Windows.Forms.ToolStripButton
    Friend WithEvents miIngresoMasivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biFormatoExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents biImportarExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents miFormatoExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miImportarExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvFormatoExcel As System.Windows.Forms.DataGridView
    Friend WithEvents dgvImportarExcel As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPersonal As System.Windows.Forms.DataGridView
    Friend WithEvents miIngresarBonosMina As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biIngresarBonosMina As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biCuotas As ToolStripButton
    Friend WithEvents miCuotas As ToolStripMenuItem
    Friend WithEvents miDescandoMedico As ToolStripMenuItem
    Friend WithEvents miIngresosubsidios As ToolStripMenuItem
End Class
