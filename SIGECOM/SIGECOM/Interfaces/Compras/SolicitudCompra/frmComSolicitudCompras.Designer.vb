<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudCompras
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstados_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudCompras))
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGenerar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAprobar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEstados = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biArchivo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New Janus.Windows.Ribbon.RibbonContextMenu(Me.components)
        Me.miImprimir = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miNuevo = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miMostrar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miEliminar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miGenerar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miAprobar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miEstados = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miActualizar = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miArchivo = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miAnular = New Janus.Windows.Ribbon.DropDownCommand()
        Me.miSalir = New Janus.Windows.Ribbon.DropDownCommand()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New Janus.Windows.EditControls.UIButton()
        Me.txtNumSolicitud = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.cmbEstados = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbAnio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator10, Me.biImprimir, Me.ToolStripSeparator1, Me.biNuevo, Me.ToolStripSeparator2, Me.biMostrar, Me.ToolStripSeparator3, Me.biEliminar, Me.ToolStripSeparator4, Me.biGenerar, Me.ToolStripSeparator5, Me.biAprobar, Me.ToolStripSeparator6, Me.biAnular, Me.ToolStripSeparator8, Me.biEstados, Me.ToolStripSeparator9, Me.biArchivo, Me.ToolStripSeparator12, Me.biActualizar, Me.ToolStripSeparator7, Me.biSalir, Me.ToolStripSeparator11})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(753, 31)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Solicitud de Compra"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Crear Nueva Solicitud de Compra"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar Solicitud de Compra"
        Me.biMostrar.ToolTipText = "Mostrar Solicitud Seleccionada"
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
        Me.biEliminar.Text = "Eliminar Solicitud Seleccionada"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biGenerar
        '
        Me.biGenerar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGenerar.Image = Global.SIGECOM.My.Resources.Resources.Generar
        Me.biGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGenerar.Name = "biGenerar"
        Me.biGenerar.Size = New System.Drawing.Size(28, 28)
        Me.biGenerar.Text = "Generar Orden de Comnpra"
        Me.biGenerar.ToolTipText = "Generar Orden de Compra"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biAprobar
        '
        Me.biAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.biAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAprobar.Name = "biAprobar"
        Me.biAprobar.Size = New System.Drawing.Size(28, 28)
        Me.biAprobar.Text = "Aprobar Solicitud de Compra"
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
        Me.biAnular.Text = "Anular Solicitud de Compra"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biEstados
        '
        Me.biEstados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.biEstados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEstados.Name = "biEstados"
        Me.biEstados.Size = New System.Drawing.Size(28, 28)
        Me.biEstados.Text = "Estados de la Solicitud de Compra"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'biArchivo
        '
        Me.biArchivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biArchivo.Image = Global.SIGECOM.My.Resources.Resources.documentosEmitidos
        Me.biArchivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biArchivo.Name = "biArchivo"
        Me.biArchivo.Size = New System.Drawing.Size(28, 28)
        Me.biArchivo.Text = "Registrar Archivos"
        Me.biArchivo.ToolTipText = "Registrar Archivos"
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
        Me.biActualizar.Text = "Actualizar Datos de Solicitud de Compras"
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
        Me.biSalir.Text = "Cerrar la Ventana Actual"
        Me.biSalir.ToolTipText = "Salir de la Ventana"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'dgvDatos
        '
        Me.cmOpciones.SetContextMenu(Me.dgvDatos, True)
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(0, 100)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Office2007CustomColor = System.Drawing.Color.White
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(738, 265)
        Me.dgvDatos.TabIndex = 8
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Commands.AddRange(New Janus.Windows.Ribbon.CommandBase() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miGenerar, Me.miAprobar, Me.miEstados, Me.miActualizar, Me.miArchivo, Me.miAnular, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Silver
        '
        'miImprimir
        '
        Me.miImprimir.Image = CType(resources.GetObject("miImprimir.Image"), System.Drawing.Image)
        Me.miImprimir.Key = "DropDownCommand1"
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Text = "Imprimir"
        '
        'miNuevo
        '
        Me.miNuevo.Image = CType(resources.GetObject("miNuevo.Image"), System.Drawing.Image)
        Me.miNuevo.Key = "DropDownCommand2"
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = CType(resources.GetObject("miMostrar.Image"), System.Drawing.Image)
        Me.miMostrar.Key = "DropDownCommand1"
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = CType(resources.GetObject("miEliminar.Image"), System.Drawing.Image)
        Me.miEliminar.Key = "DropDownCommand3"
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Text = "Eliminar"
        '
        'miGenerar
        '
        Me.miGenerar.Image = CType(resources.GetObject("miGenerar.Image"), System.Drawing.Image)
        Me.miGenerar.Key = "DropDownCommand2"
        Me.miGenerar.Name = "miGenerar"
        Me.miGenerar.Text = "Generar"
        '
        'miAprobar
        '
        Me.miAprobar.Image = CType(resources.GetObject("miAprobar.Image"), System.Drawing.Image)
        Me.miAprobar.Key = "DropDownCommand1"
        Me.miAprobar.Name = "miAprobar"
        Me.miAprobar.Text = "Aprobar"
        '
        'miEstados
        '
        Me.miEstados.Image = CType(resources.GetObject("miEstados.Image"), System.Drawing.Image)
        Me.miEstados.Key = "DropDownCommand1"
        Me.miEstados.Name = "miEstados"
        Me.miEstados.Text = "Estados"
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Key = "DropDownCommand1"
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Text = "Actualizar"
        '
        'miArchivo
        '
        Me.miArchivo.Icon = CType(resources.GetObject("miArchivo.Icon"), System.Drawing.Icon)
        Me.miArchivo.Key = "miArchivo"
        Me.miArchivo.Name = "miArchivo"
        Me.miArchivo.Text = "Archivos"
        '
        'miAnular
        '
        Me.miAnular.Image = CType(resources.GetObject("miAnular.Image"), System.Drawing.Image)
        Me.miAnular.Key = "DropDownCommand1"
        Me.miAnular.Name = "miAnular"
        Me.miAnular.Text = "Anular"
        '
        'miSalir
        '
        Me.miSalir.Image = CType(resources.GetObject("miSalir.Image"), System.Drawing.Image)
        Me.miSalir.Key = "DropDownCommand4"
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Text = "Salir"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.txtNumSolicitud)
        Me.UiGroupBox1.Controls.Add(Me.cmbEstados)
        Me.UiGroupBox1.Controls.Add(Me.cmbArea)
        Me.UiGroupBox1.Controls.Add(Me.cmbAnio)
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 32)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(722, 62)
        Me.UiGroupBox1.TabIndex = 9
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(539, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Número"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(197, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Área"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(390, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Estados"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Año"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.Location = New System.Drawing.Point(631, 31)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 26)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        '
        'txtNumSolicitud
        '
        Me.txtNumSolicitud.Location = New System.Drawing.Point(518, 35)
        Me.txtNumSolicitud.Name = "txtNumSolicitud"
        Me.txtNumSolicitud.Size = New System.Drawing.Size(81, 20)
        Me.txtNumSolicitud.TabIndex = 4
        Me.txtNumSolicitud.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtNumSolicitud.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbEstados
        '
        Me.cmbEstados.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstados_DesignTimeLayout.LayoutString = resources.GetString("cmbEstados_DesignTimeLayout.LayoutString")
        Me.cmbEstados.DesignTimeLayout = cmbEstados_DesignTimeLayout
        Me.cmbEstados.Location = New System.Drawing.Point(344, 35)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.SelectedIndex = -1
        Me.cmbEstados.SelectedItem = Nothing
        Me.cmbEstados.Size = New System.Drawing.Size(140, 20)
        Me.cmbEstados.TabIndex = 2
        Me.cmbEstados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Location = New System.Drawing.Point(114, 35)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(197, 20)
        Me.cmbArea.TabIndex = 1
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbAnio
        '
        Me.cmbAnio.Location = New System.Drawing.Point(17, 35)
        Me.cmbAnio.Maximum = 2059
        Me.cmbAnio.Minimum = 2006
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(64, 20)
        Me.cmbAnio.TabIndex = 0
        Me.cmbAnio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbAnio.Value = 2006
        Me.cmbAnio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 379)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(753, 20)
        Me.ssBarra.TabIndex = 169
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
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
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmComSolicitudCompras
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(753, 399)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudCompras"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbEstados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGenerar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As Janus.Windows.Ribbon.RibbonContextMenu
    Friend WithEvents miImprimir As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents miNuevo As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents miMostrar As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents miEliminar As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents miGenerar As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents miSalir As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbAnio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtNumSolicitud As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cmbEstados As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents miActualizar As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biAprobar As System.Windows.Forms.ToolStripButton
    Friend WithEvents miAprobar As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents miEstados As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents biEstados As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miAnular As Janus.Windows.Ribbon.DropDownCommand
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biArchivo As ToolStripButton
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents miArchivo As Janus.Windows.Ribbon.DropDownCommand
End Class
