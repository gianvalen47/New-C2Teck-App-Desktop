<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaPrecioFabricante_Nuevo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListaPrecioFabricante_Nuevo))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbListaPrecio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditarr = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacerr = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biFormatoExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAprobar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miListaPrecioCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miFormatoExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miLimpiarLista = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pbTimer = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.txtNombreLista = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbListaPrecio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtFecVencimiento = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtLista = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ToolStrip.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbListaPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biEditarr, Me.ToolStripSeparator4, Me.biDeshacerr, Me.ToolStripSeparator7, Me.biFormatoExcel, Me.ToolStripSeparator6, Me.biAprobar, Me.ToolStripSeparator5, Me.biCerrar})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(791, 31)
        Me.ToolStrip.TabIndex = 190
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
        Me.biGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEditarr
        '
        Me.biEditarr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditarr.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditarr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditarr.Name = "biEditarr"
        Me.biEditarr.Size = New System.Drawing.Size(28, 28)
        Me.biEditarr.Text = "Editar Cabecera"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacerr
        '
        Me.biDeshacerr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacerr.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacerr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacerr.Name = "biDeshacerr"
        Me.biDeshacerr.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacerr.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'biAprobar
        '
        Me.biAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.biAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAprobar.Name = "biAprobar"
        Me.biAprobar.Size = New System.Drawing.Size(28, 28)
        Me.biAprobar.Text = "Aprobar"
        Me.biAprobar.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biCerrar
        '
        Me.biCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCerrar.Name = "biCerrar"
        Me.biCerrar.Size = New System.Drawing.Size(28, 28)
        Me.biCerrar.Text = "Cerrar el Formulario"
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miListaPrecioCliente, Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.miFormatoExcel, Me.ToolStripMenuItem1, Me.miLimpiarLista, Me.ToolStripSeparator1, Me.miActualizar, Me.miBuscar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(206, 198)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(205, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo Detalle"
        '
        'miListaPrecioCliente
        '
        Me.miListaPrecioCliente.Image = CType(resources.GetObject("miListaPrecioCliente.Image"), System.Drawing.Image)
        Me.miListaPrecioCliente.Name = "miListaPrecioCliente"
        Me.miListaPrecioCliente.Size = New System.Drawing.Size(205, 22)
        Me.miListaPrecioCliente.Text = "Importar Lista Fabricante"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(205, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(205, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(202, 6)
        '
        'miFormatoExcel
        '
        Me.miFormatoExcel.Image = CType(resources.GetObject("miFormatoExcel.Image"), System.Drawing.Image)
        Me.miFormatoExcel.Name = "miFormatoExcel"
        Me.miFormatoExcel.Size = New System.Drawing.Size(205, 22)
        Me.miFormatoExcel.Text = "Formato Excel"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(202, 6)
        '
        'miLimpiarLista
        '
        Me.miLimpiarLista.Image = CType(resources.GetObject("miLimpiarLista.Image"), System.Drawing.Image)
        Me.miLimpiarLista.Name = "miLimpiarLista"
        Me.miLimpiarLista.Size = New System.Drawing.Size(205, 22)
        Me.miLimpiarLista.Text = "Limpiar Lista Fabricante"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(202, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(205, 22)
        Me.miActualizar.Text = "Actualizar"
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'miBuscar
        '
        Me.miBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.miBuscar.Name = "miBuscar"
        Me.miBuscar.Size = New System.Drawing.Size(205, 22)
        Me.miBuscar.Text = "Buscar"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'pbTimer
        '
        Me.ErrorProvider1.SetIconAlignment(Me.pbTimer, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.pbTimer.Image = CType(resources.GetObject("pbTimer.Image"), System.Drawing.Image)
        Me.pbTimer.Location = New System.Drawing.Point(14, 349)
        Me.pbTimer.Name = "pbTimer"
        Me.pbTimer.Size = New System.Drawing.Size(24, 24)
        Me.pbTimer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbTimer.TabIndex = 215
        Me.pbTimer.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDetalle
        '
        Me.gbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalle.Controls.Add(Me.pbTimer)
        Me.gbDetalle.Controls.Add(Me.lblMensaje)
        Me.gbDetalle.Controls.Add(Me.dgvDatos)
        Me.gbDetalle.Controls.Add(Me.lblRegistros)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(12, 228)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(735, 412)
        Me.gbDetalle.TabIndex = 197
        Me.gbDetalle.Text = "Detalles"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.Red
        Me.lblMensaje.Location = New System.Drawing.Point(43, 355)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(421, 13)
        Me.lblMensaje.TabIndex = 214
        Me.lblMensaje.Text = "El importar lista es un proceso que demora, por favor no cierre el sistema"
        '
        'dgvDatos
        '
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(14, 19)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.SelectOnExpand = False
        Me.dgvDatos.Size = New System.Drawing.Size(707, 353)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.Location = New System.Drawing.Point(539, 355)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(73, 13)
        Me.lblRegistros.TabIndex = 213
        Me.lblRegistros.Text = "lblRegistros"
        '
        'dgvDetalle
        '
        Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalle.Location = New System.Drawing.Point(509, 149)
        Me.dgvDetalle.Name = "dgvDetalle"
        Me.dgvDetalle.Size = New System.Drawing.Size(34, 23)
        Me.dgvDetalle.TabIndex = 236
        Me.dgvDetalle.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(429, 149)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(34, 23)
        Me.DataGridView2.TabIndex = 235
        Me.DataGridView2.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(469, 149)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(34, 23)
        Me.DataGridView1.TabIndex = 234
        Me.DataGridView1.Visible = False
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.cbVigente)
        Me.UiGroupBox2.Controls.Add(Me.dgvDetalle)
        Me.UiGroupBox2.Controls.Add(Me.txtNombreLista)
        Me.UiGroupBox2.Controls.Add(Me.DataGridView2)
        Me.UiGroupBox2.Controls.Add(Me.DataGridView1)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.cmbListaPrecio)
        Me.UiGroupBox2.Controls.Add(Me.Label20)
        Me.UiGroupBox2.Controls.Add(Me.txtFecVencimiento)
        Me.UiGroupBox2.Controls.Add(Me.txtLista)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox2.Controls.Add(Me.Label21)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(12, 33)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(720, 189)
        Me.UiGroupBox2.TabIndex = 196
        Me.UiGroupBox2.Text = "Cabecera"
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigente.Location = New System.Drawing.Point(622, 152)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(69, 17)
        Me.cbVigente.TabIndex = 6
        Me.cbVigente.Text = "Vigente"
        Me.cbVigente.UseVisualStyleBackColor = True
        '
        'txtNombreLista
        '
        Me.txtNombreLista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreLista.Location = New System.Drawing.Point(103, 60)
        Me.txtNombreLista.Name = "txtNombreLista"
        Me.txtNombreLista.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNombreLista.Size = New System.Drawing.Size(588, 20)
        Me.txtNombreLista.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Nombre"
        '
        'cmbListaPrecio
        '
        Me.cmbListaPrecio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbListaPrecio_DesignTimeLayout.LayoutString = resources.GetString("cmbListaPrecio_DesignTimeLayout.LayoutString")
        Me.cmbListaPrecio.DesignTimeLayout = cmbListaPrecio_DesignTimeLayout
        Me.cmbListaPrecio.Location = New System.Drawing.Point(551, 24)
        Me.cmbListaPrecio.Name = "cmbListaPrecio"
        Me.cmbListaPrecio.SelectedIndex = -1
        Me.cmbListaPrecio.SelectedItem = Nothing
        Me.cmbListaPrecio.Size = New System.Drawing.Size(140, 20)
        Me.cmbListaPrecio.TabIndex = 2
        Me.cmbListaPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(460, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 13)
        Me.Label20.TabIndex = 253
        Me.Label20.Text = "Lista Precio"
        '
        'txtFecVencimiento
        '
        '
        '
        '
        Me.txtFecVencimiento.DropDownCalendar.Name = ""
        Me.txtFecVencimiento.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecVencimiento.Location = New System.Drawing.Point(131, 149)
        Me.txtFecVencimiento.Name = "txtFecVencimiento"
        Me.txtFecVencimiento.NullButtonText = "Ninguno"
        Me.txtFecVencimiento.Size = New System.Drawing.Size(92, 20)
        Me.txtFecVencimiento.TabIndex = 5
        Me.txtFecVencimiento.TodayButtonText = "Hoy"
        Me.txtFecVencimiento.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtLista
        '
        Me.txtLista.BackColor = System.Drawing.SystemColors.Control
        Me.txtLista.Location = New System.Drawing.Point(103, 24)
        Me.txtLista.Name = "txtLista"
        Me.txtLista.Numeric = True
        Me.txtLista.ReadOnly = True
        Me.txtLista.Size = New System.Drawing.Size(67, 20)
        Me.txtLista.TabIndex = 227
        Me.txtLista.TabStop = False
        Me.txtLista.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 228
        Me.Label8.Text = "N° Lista"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 223
        Me.Label7.Text = "Fec. Vencimiento :"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(322, 24)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(69, 20)
        Me.cmbMoneda.TabIndex = 1
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(264, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 216
        Me.Label3.Text = "Moneda"
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(103, 94)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(588, 42)
        Me.txtObservacion.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 105)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Observación"
        '
        'frmListaPrecioFabricante_Nuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(791, 677)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListaPrecioFabricante_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista Precio Fabricante"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTimer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbListaPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents biGuardar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents biEditarr As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents biDeshacerr As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents biFormatoExcel As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents biAprobar As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents biCerrar As ToolStripButton
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miNuevo As ToolStripMenuItem
    Friend WithEvents miListaPrecioCliente As ToolStripMenuItem
    Friend WithEvents miMostrar As ToolStripMenuItem
    Friend WithEvents miEliminar As ToolStripMenuItem
    Friend WithEvents miSeparador1 As ToolStripSeparator
    Friend WithEvents miFormatoExcel As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents miActualizar As ToolStripMenuItem
    Friend WithEvents miBuscar As ToolStripMenuItem
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblRegistros As Label
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtFecVencimiento As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtLista As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As Label
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents dgvDetalle As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtNombreLista As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbListaPrecio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label20 As Label
    Friend WithEvents cbVigente As CheckBox
    Friend WithEvents pbTimer As PictureBox
    Friend WithEvents lblMensaje As Label
    Friend WithEvents miLimpiarLista As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
