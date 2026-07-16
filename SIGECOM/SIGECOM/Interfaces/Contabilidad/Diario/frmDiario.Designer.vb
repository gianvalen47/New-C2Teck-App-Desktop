<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiario))
        Dim cmbTipo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoLibro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImportarImportaciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImportarCostos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImportarVenta = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDuplicar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miImportarDocsTesoreria = New System.Windows.Forms.ToolStripMenuItem()
        Me.miImportarDocs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miFormatoExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.miImportarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscarRegistro = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbTipo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbEstado = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbAnulado = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTipCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtDesCuenta = New System.Windows.Forms.TextBox()
        Me.txtDiferenciaDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalHaberDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDebeDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalNeto = New System.Windows.Forms.TextBox()
        Me.lbltotalIGV = New System.Windows.Forms.TextBox()
        Me.lblTotalVenta = New System.Windows.Forms.TextBox()
        Me.txtDiferenciaSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalHaberSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDebeSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.txtNumRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtMesRegistro = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtPeriodo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoLibro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.dgvImportarExcel = New System.Windows.Forms.DataGridView()
        Me.dgvFormatoExcel = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoLibro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvImportarExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFormatoExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ssBarra.Location = New System.Drawing.Point(0, 587)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(706, 20)
        Me.ssBarra.TabIndex = 190
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(440, 15)
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
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.biEditar, Me.ToolStripSeparator8, Me.biEliminar, Me.ToolStripSeparator3, Me.biGuardar, Me.ToolStripSeparator13, Me.biDeshacer, Me.ToolStripSeparator5, Me.biImportarImportaciones, Me.ToolStripSeparator4, Me.biImportarCostos, Me.ToolStripSeparator9, Me.biImportarVenta, Me.ToolStripSeparator7, Me.biImprimir, Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(706, 31)
        Me.ToolStrip.TabIndex = 189
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Cabecera"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar Registro"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biImportarImportaciones
        '
        Me.biImportarImportaciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImportarImportaciones.Image = CType(resources.GetObject("biImportarImportaciones.Image"), System.Drawing.Image)
        Me.biImportarImportaciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImportarImportaciones.Name = "biImportarImportaciones"
        Me.biImportarImportaciones.Size = New System.Drawing.Size(28, 28)
        Me.biImportarImportaciones.Text = "Importar Importación"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biImportarCostos
        '
        Me.biImportarCostos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImportarCostos.Image = CType(resources.GetObject("biImportarCostos.Image"), System.Drawing.Image)
        Me.biImportarCostos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImportarCostos.Name = "biImportarCostos"
        Me.biImportarCostos.Size = New System.Drawing.Size(28, 28)
        Me.biImportarCostos.Text = "Importar Costos"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'biImportarVenta
        '
        Me.biImportarVenta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImportarVenta.Image = CType(resources.GetObject("biImportarVenta.Image"), System.Drawing.Image)
        Me.biImportarVenta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImportarVenta.Name = "biImportarVenta"
        Me.biImportarVenta.Size = New System.Drawing.Size(28, 28)
        Me.biImportarVenta.Text = "Importar Venta"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Reportes"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biSalir
        '
        Me.biSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biSalir.Image = CType(resources.GetObject("biSalir.Image"), System.Drawing.Image)
        Me.biSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biSalir.Name = "biSalir"
        Me.biSalir.Size = New System.Drawing.Size(28, 28)
        Me.biSalir.Text = "Cerrar la ventana actual"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miDuplicar, Me.miEliminar, Me.miSeparador1, Me.miImportarDocsTesoreria, Me.miImportarDocs, Me.ToolStripMenuItem1, Me.miFormatoExcel, Me.miImportarExcel, Me.ToolStripSeparator10, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(224, 220)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(223, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(223, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miDuplicar
        '
        Me.miDuplicar.Image = Global.SIGECOM.My.Resources.Resources.Canjear
        Me.miDuplicar.Name = "miDuplicar"
        Me.miDuplicar.Size = New System.Drawing.Size(223, 22)
        Me.miDuplicar.Text = "Duplicar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(223, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(220, 6)
        '
        'miImportarDocsTesoreria
        '
        Me.miImportarDocsTesoreria.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.miImportarDocsTesoreria.Name = "miImportarDocsTesoreria"
        Me.miImportarDocsTesoreria.Size = New System.Drawing.Size(223, 22)
        Me.miImportarDocsTesoreria.Text = "Importar Docs Tesoreria"
        Me.miImportarDocsTesoreria.ToolTipText = "Importar documentos tesoreria"
        '
        'miImportarDocs
        '
        Me.miImportarDocs.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.miImportarDocs.Name = "miImportarDocs"
        Me.miImportarDocs.Size = New System.Drawing.Size(223, 22)
        Me.miImportarDocs.Text = "Importar Docs Masivamente"
        Me.miImportarDocs.ToolTipText = "Importar documentos masivamente"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(220, 6)
        '
        'miFormatoExcel
        '
        Me.miFormatoExcel.Image = CType(resources.GetObject("miFormatoExcel.Image"), System.Drawing.Image)
        Me.miFormatoExcel.Name = "miFormatoExcel"
        Me.miFormatoExcel.Size = New System.Drawing.Size(223, 22)
        Me.miFormatoExcel.Text = "Descargar Formato Excel"
        Me.miFormatoExcel.ToolTipText = "Descargar formato Excel"
        '
        'miImportarExcel
        '
        Me.miImportarExcel.Image = CType(resources.GetObject("miImportarExcel.Image"), System.Drawing.Image)
        Me.miImportarExcel.Name = "miImportarExcel"
        Me.miImportarExcel.Size = New System.Drawing.Size(223, 22)
        Me.miImportarExcel.Text = "Importar Detalles de Excel"
        Me.miImportarExcel.ToolTipText = "Importar Excel"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(220, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(223, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'btnBuscarRegistro
        '
        Me.btnBuscarRegistro.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarRegistro.Location = New System.Drawing.Point(514, 36)
        Me.btnBuscarRegistro.Name = "btnBuscarRegistro"
        Me.btnBuscarRegistro.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarRegistro.TabIndex = 196
        Me.btnBuscarRegistro.TabStop = False
        Me.btnBuscarRegistro.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(439, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 195
        Me.Label2.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(261, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 191
        Me.Label1.Text = "Comprobante :"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cmbTipo)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.gbEstado)
        Me.UiGroupBox1.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox1.Controls.Add(Me.Label17)
        Me.UiGroupBox1.Controls.Add(Me.Label16)
        Me.UiGroupBox1.Controls.Add(Me.txtGlosa)
        Me.UiGroupBox1.Controls.Add(Me.txtNombre)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.txtTipCambio)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.lblFecha)
        Me.UiGroupBox1.Controls.Add(Me.txtFecha)
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 60)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(675, 142)
        Me.UiGroupBox1.TabIndex = 4
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbTipo
        '
        Me.cmbTipo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipo_DesignTimeLayout.LayoutString")
        Me.cmbTipo.DesignTimeLayout = cmbTipo_DesignTimeLayout
        Me.cmbTipo.Location = New System.Drawing.Point(232, 113)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.SelectedIndex = -1
        Me.cmbTipo.SelectedItem = Nothing
        Me.cmbTipo.Size = New System.Drawing.Size(146, 20)
        Me.cmbTipo.TabIndex = 229
        Me.cmbTipo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(187, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "Tipo :"
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.rbAnulado)
        Me.gbEstado.Controls.Add(Me.Label18)
        Me.gbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEstado.Location = New System.Drawing.Point(485, 103)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(176, 33)
        Me.gbEstado.TabIndex = 11
        Me.gbEstado.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'rbAnulado
        '
        Me.rbAnulado.AutoSize = True
        Me.rbAnulado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAnulado.Location = New System.Drawing.Point(83, 12)
        Me.rbAnulado.Name = "rbAnulado"
        Me.rbAnulado.Size = New System.Drawing.Size(72, 17)
        Me.rbAnulado.TabIndex = 207
        Me.rbAnulado.Text = "Anulado"
        Me.rbAnulado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbAnulado.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(23, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 196
        Me.Label18.Text = "Estado :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(83, 113)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(67, 20)
        Me.cmbMoneda.TabIndex = 10
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 117)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 226
        Me.Label17.Text = "Moneda :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 79)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 224
        Me.Label16.Text = "Glosa :"
        '
        'txtGlosa
        '
        Me.txtGlosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlosa.Location = New System.Drawing.Point(83, 66)
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtGlosa.Size = New System.Drawing.Size(577, 37)
        Me.txtGlosa.TabIndex = 9
        '
        'txtNombre
        '
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(83, 40)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(577, 20)
        Me.txtNombre.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 221
        Me.Label5.Text = "Nombre :"
        '
        'txtTipCambio
        '
        Me.txtTipCambio.DecimalDigits = 4
        Me.txtTipCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCambio.Location = New System.Drawing.Point(306, 14)
        Me.txtTipCambio.MaxLength = 10
        Me.txtTipCambio.Name = "txtTipCambio"
        Me.txtTipCambio.Size = New System.Drawing.Size(72, 20)
        Me.txtTipCambio.TabIndex = 6
        Me.txtTipCambio.Text = "0.0000"
        Me.txtTipCambio.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtTipCambio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(228, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 218
        Me.Label15.Text = "T. Cambio :"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(13, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(50, 13)
        Me.lblFecha.TabIndex = 216
        Me.lblFecha.Text = "Fecha :"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecha.IsNullDate = True
        Me.txtFecha.Location = New System.Drawing.Point(83, 14)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(82, 20)
        Me.txtFecha.TabIndex = 5
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.txtDesCuenta)
        Me.UiGroupBox6.Controls.Add(Me.txtDiferenciaDol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalHaberDol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalDebeDol)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalNeto)
        Me.UiGroupBox6.Controls.Add(Me.lbltotalIGV)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalVenta)
        Me.UiGroupBox6.Controls.Add(Me.txtDiferenciaSol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalHaberSol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalDebeSol)
        Me.UiGroupBox6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox6.Location = New System.Drawing.Point(0, 508)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(706, 79)
        Me.UiGroupBox6.TabIndex = 220
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtDesCuenta
        '
        Me.txtDesCuenta.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.txtDesCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDesCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesCuenta.ForeColor = System.Drawing.Color.Brown
        Me.txtDesCuenta.Location = New System.Drawing.Point(10, 15)
        Me.txtDesCuenta.Name = "txtDesCuenta"
        Me.txtDesCuenta.ReadOnly = True
        Me.txtDesCuenta.Size = New System.Drawing.Size(376, 12)
        Me.txtDesCuenta.TabIndex = 221
        Me.txtDesCuenta.TabStop = False
        Me.txtDesCuenta.Text = "DESCRIPCIÓN DE CUENTA CONTABLE"
        Me.txtDesCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDiferenciaDol
        '
        Me.txtDiferenciaDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtDiferenciaDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtDiferenciaDol.Location = New System.Drawing.Point(579, 49)
        Me.txtDiferenciaDol.MaxLength = 5
        Me.txtDiferenciaDol.Name = "txtDiferenciaDol"
        Me.txtDiferenciaDol.ReadOnly = True
        Me.txtDiferenciaDol.Size = New System.Drawing.Size(90, 20)
        Me.txtDiferenciaDol.TabIndex = 13
        Me.txtDiferenciaDol.TabStop = False
        Me.txtDiferenciaDol.Text = "0.00"
        Me.txtDiferenciaDol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDiferenciaDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDiferenciaDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalHaberDol
        '
        Me.txtTotalHaberDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalHaberDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHaberDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalHaberDol.Location = New System.Drawing.Point(579, 30)
        Me.txtTotalHaberDol.MaxLength = 5
        Me.txtTotalHaberDol.Name = "txtTotalHaberDol"
        Me.txtTotalHaberDol.ReadOnly = True
        Me.txtTotalHaberDol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalHaberDol.TabIndex = 12
        Me.txtTotalHaberDol.TabStop = False
        Me.txtTotalHaberDol.Text = "0.00"
        Me.txtTotalHaberDol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalHaberDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalHaberDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalDebeDol
        '
        Me.txtTotalDebeDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDebeDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebeDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDebeDol.Location = New System.Drawing.Point(579, 11)
        Me.txtTotalDebeDol.MaxLength = 5
        Me.txtTotalDebeDol.Name = "txtTotalDebeDol"
        Me.txtTotalDebeDol.ReadOnly = True
        Me.txtTotalDebeDol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalDebeDol.TabIndex = 11
        Me.txtTotalDebeDol.TabStop = False
        Me.txtTotalDebeDol.Text = "0.00"
        Me.txtTotalDebeDol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDebeDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDebeDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalNeto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalNeto.Location = New System.Drawing.Point(6, 49)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(474, 20)
        Me.lblTotalNeto.TabIndex = 10
        Me.lblTotalNeto.TabStop = False
        Me.lblTotalNeto.Text = "DIFERENCIA :"
        Me.lblTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotalIGV
        '
        Me.lbltotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lbltotalIGV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lbltotalIGV.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lbltotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalIGV.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltotalIGV.Location = New System.Drawing.Point(6, 30)
        Me.lbltotalIGV.MaxLength = 20
        Me.lbltotalIGV.Name = "lbltotalIGV"
        Me.lbltotalIGV.ReadOnly = True
        Me.lbltotalIGV.Size = New System.Drawing.Size(474, 20)
        Me.lbltotalIGV.TabIndex = 9
        Me.lbltotalIGV.TabStop = False
        Me.lbltotalIGV.Text = "TOTAL HABER :"
        Me.lbltotalIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalVenta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalVenta.Location = New System.Drawing.Point(6, 11)
        Me.lblTotalVenta.MaxLength = 20
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.ReadOnly = True
        Me.lblTotalVenta.Size = New System.Drawing.Size(474, 20)
        Me.lblTotalVenta.TabIndex = 8
        Me.lblTotalVenta.TabStop = False
        Me.lblTotalVenta.Text = "TOTAL DEBE :"
        Me.lblTotalVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiferenciaSol
        '
        Me.txtDiferenciaSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtDiferenciaSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaSol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtDiferenciaSol.Location = New System.Drawing.Point(479, 49)
        Me.txtDiferenciaSol.MaxLength = 5
        Me.txtDiferenciaSol.Name = "txtDiferenciaSol"
        Me.txtDiferenciaSol.ReadOnly = True
        Me.txtDiferenciaSol.Size = New System.Drawing.Size(90, 20)
        Me.txtDiferenciaSol.TabIndex = 6
        Me.txtDiferenciaSol.TabStop = False
        Me.txtDiferenciaSol.Text = "0.00"
        Me.txtDiferenciaSol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDiferenciaSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDiferenciaSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalHaberSol
        '
        Me.txtTotalHaberSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalHaberSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHaberSol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalHaberSol.Location = New System.Drawing.Point(479, 30)
        Me.txtTotalHaberSol.MaxLength = 5
        Me.txtTotalHaberSol.Name = "txtTotalHaberSol"
        Me.txtTotalHaberSol.ReadOnly = True
        Me.txtTotalHaberSol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalHaberSol.TabIndex = 5
        Me.txtTotalHaberSol.TabStop = False
        Me.txtTotalHaberSol.Text = "0.00"
        Me.txtTotalHaberSol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalHaberSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalHaberSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalDebeSol
        '
        Me.txtTotalDebeSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDebeSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebeSol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDebeSol.Location = New System.Drawing.Point(479, 11)
        Me.txtTotalDebeSol.MaxLength = 5
        Me.txtTotalDebeSol.Name = "txtTotalDebeSol"
        Me.txtTotalDebeSol.ReadOnly = True
        Me.txtTotalDebeSol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalDebeSol.TabIndex = 3
        Me.txtTotalDebeSol.TabStop = False
        Me.txtTotalDebeSol.Text = "0.00"
        Me.txtTotalDebeSol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalDebeSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDebeSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(3, 8)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(675, 275)
        Me.dgvDatos.TabIndex = 219
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'txtNumRegistro
        '
        Me.txtNumRegistro.Location = New System.Drawing.Point(451, 37)
        Me.txtNumRegistro.MaxLength = 6
        Me.txtNumRegistro.Name = "txtNumRegistro"
        Me.txtNumRegistro.Numeric = True
        Me.txtNumRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNumRegistro.Size = New System.Drawing.Size(59, 20)
        Me.txtNumRegistro.TabIndex = 3
        '
        'txtMesRegistro
        '
        Me.txtMesRegistro.Location = New System.Drawing.Point(408, 37)
        Me.txtMesRegistro.MaxLength = 2
        Me.txtMesRegistro.Name = "txtMesRegistro"
        Me.txtMesRegistro.Numeric = True
        Me.txtMesRegistro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMesRegistro.Size = New System.Drawing.Size(30, 20)
        Me.txtMesRegistro.TabIndex = 2
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(184, 38)
        Me.txtPeriodo.Maximum = 2059
        Me.txtPeriodo.Minimum = 2006
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(58, 20)
        Me.txtPeriodo.TabIndex = 222
        Me.txtPeriodo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPeriodo.Value = 2006
        Me.txtPeriodo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(129, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 223
        Me.Label7.Text = "Periodo"
        '
        'cmbTipoLibro
        '
        Me.cmbTipoLibro.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoLibro_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoLibro_DesignTimeLayout.LayoutString")
        Me.cmbTipoLibro.DesignTimeLayout = cmbTipoLibro_DesignTimeLayout
        Me.cmbTipoLibro.Location = New System.Drawing.Point(352, 37)
        Me.cmbTipoLibro.Name = "cmbTipoLibro"
        Me.cmbTipoLibro.SelectedIndex = -1
        Me.cmbTipoLibro.SelectedItem = Nothing
        Me.cmbTipoLibro.Size = New System.Drawing.Size(50, 20)
        Me.cmbTipoLibro.TabIndex = 1
        Me.cmbTipoLibro.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbTipoLibro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvImportarExcel
        '
        Me.dgvImportarExcel.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImportarExcel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvImportarExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvImportarExcel.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvImportarExcel.Location = New System.Drawing.Point(622, 35)
        Me.dgvImportarExcel.Name = "dgvImportarExcel"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImportarExcel.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvImportarExcel.Size = New System.Drawing.Size(52, 19)
        Me.dgvImportarExcel.TabIndex = 289
        Me.dgvImportarExcel.Visible = False
        '
        'dgvFormatoExcel
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFormatoExcel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvFormatoExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFormatoExcel.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvFormatoExcel.Location = New System.Drawing.Point(564, 35)
        Me.dgvFormatoExcel.Name = "dgvFormatoExcel"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFormatoExcel.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvFormatoExcel.Size = New System.Drawing.Size(52, 19)
        Me.dgvFormatoExcel.TabIndex = 288
        Me.dgvFormatoExcel.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox2.Controls.Add(Me.dgvDatos)
        Me.UiGroupBox2.Location = New System.Drawing.Point(5, 208)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(689, 294)
        Me.UiGroupBox2.TabIndex = 290
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmDiario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(706, 607)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.dgvImportarExcel)
        Me.Controls.Add(Me.dgvFormatoExcel)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.cmbTipoLibro)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.UiGroupBox6)
        Me.Controls.Add(Me.txtNumRegistro)
        Me.Controls.Add(Me.txtMesRegistro)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.btnBuscarRegistro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contabilidad - Diario"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoLibro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvImportarExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFormatoExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDuplicar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnBuscarRegistro As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtTipCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents gbEstado As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtDiferenciaDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalHaberDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDebeDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalIGV As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalVenta As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferenciaSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalHaberSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDebeSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtDesCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtNumRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtMesRegistro As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents txtPeriodo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rbAnulado As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTipoLibro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents biImportarImportaciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImportarVenta As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents biImportarCostos As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents miImportarDocs As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTipo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents miImportarExcel As ToolStripMenuItem
    Friend WithEvents miFormatoExcel As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents dgvImportarExcel As DataGridView
    Friend WithEvents dgvFormatoExcel As DataGridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents miImportarDocsTesoreria As ToolStripMenuItem
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
End Class
