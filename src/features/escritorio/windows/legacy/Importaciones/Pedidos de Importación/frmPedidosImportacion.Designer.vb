<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidosImportacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidosImportacion))
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdCliente_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizarCanRec = New System.Windows.Forms.ToolStripMenuItem()
        Me.miHistorialCanRec = New System.Windows.Forms.ToolStripMenuItem()
        Me.miActualizarFecPromesa = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRegistrarArchivos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.miFacturar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miVerEstados = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtFecFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbIdCliente = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumPed = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotGen = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gbTotalGeneral = New Janus.Windows.EditControls.UIGroupBox()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biimprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizarCanRec = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biHistorialCanRec = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizarFecPromesa = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biRegistrarArchivos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biVerEstados = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.biFacturar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.cmOpciones.SuspendLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.gbTotalGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTotalGeneral.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar, Me.miActualizarCanRec, Me.miHistorialCanRec, Me.miActualizarFecPromesa, Me.miRegistrarArchivos, Me.ToolStripSeparator7, Me.miFacturar, Me.miVerEstados, Me.ToolStripSeparator10, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(226, 286)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(225, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(225, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(225, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(225, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(222, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(225, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miActualizarCanRec
        '
        Me.miActualizarCanRec.Image = Global.SIGECOM.My.Resources.Resources.Cont_diario
        Me.miActualizarCanRec.Name = "miActualizarCanRec"
        Me.miActualizarCanRec.Size = New System.Drawing.Size(225, 22)
        Me.miActualizarCanRec.Text = "Actualizar Cantidad Recibida"
        Me.miActualizarCanRec.ToolTipText = "Actualizar Cantidad Recibida de Pedidos "
        '
        'miHistorialCanRec
        '
        Me.miHistorialCanRec.Image = CType(resources.GetObject("miHistorialCanRec.Image"), System.Drawing.Image)
        Me.miHistorialCanRec.Name = "miHistorialCanRec"
        Me.miHistorialCanRec.Size = New System.Drawing.Size(225, 22)
        Me.miHistorialCanRec.Text = "Historial Cantidad Recibida"
        '
        'miActualizarFecPromesa
        '
        Me.miActualizarFecPromesa.Image = CType(resources.GetObject("miActualizarFecPromesa.Image"), System.Drawing.Image)
        Me.miActualizarFecPromesa.Name = "miActualizarFecPromesa"
        Me.miActualizarFecPromesa.Size = New System.Drawing.Size(225, 22)
        Me.miActualizarFecPromesa.Text = "Actualizar Fecha Estimada"
        '
        'miRegistrarArchivos
        '
        Me.miRegistrarArchivos.Image = CType(resources.GetObject("miRegistrarArchivos.Image"), System.Drawing.Image)
        Me.miRegistrarArchivos.Name = "miRegistrarArchivos"
        Me.miRegistrarArchivos.Size = New System.Drawing.Size(225, 22)
        Me.miRegistrarArchivos.Text = "Registrar Archivos"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(222, 6)
        '
        'miFacturar
        '
        Me.miFacturar.Image = CType(resources.GetObject("miFacturar.Image"), System.Drawing.Image)
        Me.miFacturar.Name = "miFacturar"
        Me.miFacturar.Size = New System.Drawing.Size(225, 22)
        Me.miFacturar.Text = "Generar Factura"
        Me.miFacturar.ToolTipText = "Generar factura de importación"
        '
        'miVerEstados
        '
        Me.miVerEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miVerEstados.Name = "miVerEstados"
        Me.miVerEstados.Size = New System.Drawing.Size(225, 22)
        Me.miVerEstados.Text = "Consultar Estados"
        Me.miVerEstados.ToolTipText = "Ver estados de la orden"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(222, 6)
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(225, 22)
        Me.miSalir.Text = "Salir"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Location = New System.Drawing.Point(6, 31)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(91, 20)
        Me.cmbOficinas.TabIndex = 0
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtFecFin
        '
        '
        '
        '
        Me.txtFecFin.DropDownCalendar.Name = ""
        Me.txtFecFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFin.IsNullDate = True
        Me.txtFecFin.Location = New System.Drawing.Point(511, 31)
        Me.txtFecFin.Name = "txtFecFin"
        Me.txtFecFin.NullButtonText = "Ninguno"
        Me.txtFecFin.ShowNullButton = True
        Me.txtFecFin.Size = New System.Drawing.Size(90, 20)
        Me.txtFecFin.TabIndex = 4
        Me.txtFecFin.TodayButtonText = "Hoy"
        Me.txtFecFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecIni
        '
        '
        '
        '
        Me.txtFecIni.DropDownCalendar.Name = ""
        Me.txtFecIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIni.IsNullDate = True
        Me.txtFecIni.Location = New System.Drawing.Point(417, 31)
        Me.txtFecIni.Name = "txtFecIni"
        Me.txtFecIni.NullButtonText = "Ninguno"
        Me.txtFecIni.ShowNullButton = True
        Me.txtFecIni.Size = New System.Drawing.Size(90, 20)
        Me.txtFecIni.TabIndex = 3
        Me.txtFecIni.TodayButtonText = "Hoy"
        Me.txtFecIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(524, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Fecha Fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(423, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Fecha Inicio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(286, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Proveedor"
        '
        'cmbIdCliente
        '
        Me.cmbIdCliente.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdCliente_DesignTimeLayout.LayoutString = resources.GetString("cmbIdCliente_DesignTimeLayout.LayoutString")
        Me.cmbIdCliente.DesignTimeLayout = cmbIdCliente_DesignTimeLayout
        Me.cmbIdCliente.Location = New System.Drawing.Point(233, 31)
        Me.cmbIdCliente.Name = "cmbIdCliente"
        Me.cmbIdCliente.SelectedIndex = -1
        Me.cmbIdCliente.SelectedItem = Nothing
        Me.cmbIdCliente.Size = New System.Drawing.Size(179, 20)
        Me.cmbIdCliente.TabIndex = 2
        Me.cmbIdCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(135, 16)
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
        Me.cmbIdLocacion.Location = New System.Drawing.Point(101, 31)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(128, 20)
        Me.cmbIdLocacion.TabIndex = 1
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Oficina"
        '
        'txtNumPed
        '
        Me.txtNumPed.Location = New System.Drawing.Point(605, 31)
        Me.txtNumPed.MaxLength = 30
        Me.txtNumPed.Name = "txtNumPed"
        Me.txtNumPed.Size = New System.Drawing.Size(57, 20)
        Me.txtNumPed.TabIndex = 5
        Me.txtNumPed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(665, 28)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(66, 25)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(608, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Número"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 464)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(911, 20)
        Me.ssBarra.TabIndex = 2
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(686, 15)
        Me.sslError.Spring = True
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(210, 15)
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
        Me.dgvDatos.Location = New System.Drawing.Point(0, 108)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(899, 315)
        Me.dgvDatos.TabIndex = 19
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.txtFecIni)
        Me.gbDatosBusqueda.Controls.Add(Me.txtFecFin)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbOficinas)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Controls.Add(Me.Label2)
        Me.gbDatosBusqueda.Controls.Add(Me.Label3)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbIdLocacion)
        Me.gbDatosBusqueda.Controls.Add(Me.Label6)
        Me.gbDatosBusqueda.Controls.Add(Me.txtNumPed)
        Me.gbDatosBusqueda.Controls.Add(Me.Label4)
        Me.gbDatosBusqueda.Controls.Add(Me.Label1)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbIdCliente)
        Me.gbDatosBusqueda.Controls.Add(Me.Label5)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(3, 44)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(735, 58)
        Me.gbDatosBusqueda.TabIndex = 23
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(265, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 15)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Total General"
        '
        'txtTotGen
        '
        Me.txtTotGen.Location = New System.Drawing.Point(365, 14)
        Me.txtTotGen.MaxLength = 12
        Me.txtTotGen.Name = "txtTotGen"
        Me.txtTotGen.ReadOnly = True
        Me.txtTotGen.Size = New System.Drawing.Size(118, 20)
        Me.txtTotGen.TabIndex = 22
        Me.txtTotGen.Text = "0.00"
        Me.txtTotGen.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'gbTotalGeneral
        '
        Me.gbTotalGeneral.Controls.Add(Me.txtTotGen)
        Me.gbTotalGeneral.Controls.Add(Me.Label7)
        Me.gbTotalGeneral.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbTotalGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTotalGeneral.Location = New System.Drawing.Point(0, 423)
        Me.gbTotalGeneral.Name = "gbTotalGeneral"
        Me.gbTotalGeneral.Size = New System.Drawing.Size(911, 41)
        Me.gbTotalGeneral.TabIndex = 24
        Me.gbTotalGeneral.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biimprimir, Me.ToolStripSeparator4, Me.biNuevo, Me.ToolStripSeparator2, Me.biMostrar, Me.ToolStripSeparator3, Me.biActualizar, Me.ToolStripSeparator1, Me.biEliminar, Me.ToolStripSeparator5, Me.biActualizarCanRec, Me.ToolStripSeparator8, Me.biHistorialCanRec, Me.ToolStripSeparator9, Me.biActualizarFecPromesa, Me.ToolStripSeparator13, Me.biRegistrarArchivos, Me.ToolStripSeparator6, Me.biVerEstados, Me.ToolStripSeparator11, Me.biFacturar, Me.ToolStripSeparator12, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(911, 31)
        Me.ToolStrip.TabIndex = 25
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biimprimir
        '
        Me.biimprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biimprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biimprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biimprimir.Name = "biimprimir"
        Me.biimprimir.Size = New System.Drawing.Size(28, 28)
        Me.biimprimir.Text = "Imprimir Documento"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
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
        Me.biMostrar.Text = "Mostrar los datos del registro seleccionado"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Datos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizarCanRec
        '
        Me.biActualizarCanRec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizarCanRec.Image = Global.SIGECOM.My.Resources.Resources.Cont_diario
        Me.biActualizarCanRec.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizarCanRec.Name = "biActualizarCanRec"
        Me.biActualizarCanRec.Size = New System.Drawing.Size(28, 28)
        Me.biActualizarCanRec.Text = "Actualizar Cantidad Recibida"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biHistorialCanRec
        '
        Me.biHistorialCanRec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biHistorialCanRec.Image = CType(resources.GetObject("biHistorialCanRec.Image"), System.Drawing.Image)
        Me.biHistorialCanRec.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biHistorialCanRec.Name = "biHistorialCanRec"
        Me.biHistorialCanRec.Size = New System.Drawing.Size(28, 28)
        Me.biHistorialCanRec.Text = "Historial Cantidad Recibida"
        Me.biHistorialCanRec.ToolTipText = "Historial Actualización Cantidad Recibida"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizarFecPromesa
        '
        Me.biActualizarFecPromesa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizarFecPromesa.Image = CType(resources.GetObject("biActualizarFecPromesa.Image"), System.Drawing.Image)
        Me.biActualizarFecPromesa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizarFecPromesa.Name = "biActualizarFecPromesa"
        Me.biActualizarFecPromesa.Size = New System.Drawing.Size(28, 28)
        Me.biActualizarFecPromesa.Text = "Actualizar Fecha Estimada"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biVerEstados
        '
        Me.biVerEstados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biVerEstados.Image = CType(resources.GetObject("biVerEstados.Image"), System.Drawing.Image)
        Me.biVerEstados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biVerEstados.Name = "biVerEstados"
        Me.biVerEstados.Size = New System.Drawing.Size(28, 28)
        Me.biVerEstados.Text = "Consultar Estados de la Orden"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'biFacturar
        '
        Me.biFacturar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biFacturar.Image = CType(resources.GetObject("biFacturar.Image"), System.Drawing.Image)
        Me.biFacturar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biFacturar.Name = "biFacturar"
        Me.biFacturar.Size = New System.Drawing.Size(28, 28)
        Me.biFacturar.Text = "Facturar Orden de Pedido"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
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
        'frmPedidosImportacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(911, 484)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbTotalGeneral)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmPedidosImportacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ordenes de Pedido de Importación"
        Me.cmOpciones.ResumeLayout(false)
        CType(Me.cmbOficinas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ofEstiloForm,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbIdCliente,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cmbIdLocacion,System.ComponentModel.ISupportInitialize).EndInit
        Me.ssBarra.ResumeLayout(false)
        Me.ssBarra.PerformLayout
        CType(Me.dgvDatos,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gbDatosBusqueda,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbDatosBusqueda.ResumeLayout(false)
        Me.gbDatosBusqueda.PerformLayout
        CType(Me.gbTotalGeneral,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbTotalGeneral.ResumeLayout(false)
        Me.gbTotalGeneral.PerformLayout
        Me.ToolStrip.ResumeLayout(false)
        Me.ToolStrip.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbIdCliente As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumPed As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFecFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX

    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbTotalGeneral As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotGen As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biimprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents miActualizarCanRec As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents biActualizarCanRec As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents biHistorialCanRec As ToolStripButton
    Friend WithEvents miHistorialCanRec As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents biRegistrarArchivos As ToolStripButton
    Friend WithEvents miRegistrarArchivos As ToolStripMenuItem
    Friend WithEvents miVerEstados As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents biVerEstados As ToolStripButton
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents miFacturar As ToolStripMenuItem
    Friend WithEvents biFacturar As ToolStripButton
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents biActualizarFecPromesa As ToolStripButton
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents miActualizarFecPromesa As ToolStripMenuItem
End Class
