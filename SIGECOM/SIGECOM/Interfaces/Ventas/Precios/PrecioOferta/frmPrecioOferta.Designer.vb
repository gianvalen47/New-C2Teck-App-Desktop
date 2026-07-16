<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrecioOferta
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrecioOferta))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.miEnviar = New System.Windows.Forms.ToolStripMenuItem
        Me.miAprobar = New System.Windows.Forms.ToolStripMenuItem
        Me.miVerEstados = New System.Windows.Forms.ToolStripMenuItem
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.miFormatoExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.miInsertarLista = New System.Windows.Forms.ToolStripMenuItem
        Me.miBuscar = New System.Windows.Forms.ToolStripMenuItem
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.biImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.biNuevo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.biMostrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.biEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.biEnviar = New System.Windows.Forms.ToolStripButton
        Me.biAprobar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.biVerEstados = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.biFormatoExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.biActualizar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.cmbRubro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.cmbOpciones.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ssBarra.Location = New System.Drawing.Point(0, 334)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(784, 20)
        Me.ssBarra.TabIndex = 210
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(450, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(260, 15)
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miEnviar, Me.miAprobar, Me.miVerEstados, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miFormatoExcel, Me.miInsertarLista, Me.miBuscar, Me.miActualizar, Me.miSalir})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(214, 280)
        '
        'miImprimir
        '
        Me.miImprimir.Image = CType(resources.GetObject("miImprimir.Image"), System.Drawing.Image)
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(213, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miNuevo
        '
        Me.miNuevo.Image = CType(resources.GetObject("miNuevo.Image"), System.Drawing.Image)
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(213, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = CType(resources.GetObject("miMostrar.Image"), System.Drawing.Image)
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(213, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = CType(resources.GetObject("miEliminar.Image"), System.Drawing.Image)
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(213, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miEnviar
        '
        Me.miEnviar.Image = CType(resources.GetObject("miEnviar.Image"), System.Drawing.Image)
        Me.miEnviar.Name = "miEnviar"
        Me.miEnviar.Size = New System.Drawing.Size(213, 22)
        Me.miEnviar.Text = "Enviar"
        Me.miEnviar.Visible = False
        '
        'miAprobar
        '
        Me.miAprobar.Image = CType(resources.GetObject("miAprobar.Image"), System.Drawing.Image)
        Me.miAprobar.Name = "miAprobar"
        Me.miAprobar.Size = New System.Drawing.Size(213, 22)
        Me.miAprobar.Text = "Aprobar"
        Me.miAprobar.Visible = False
        '
        'miVerEstados
        '
        Me.miVerEstados.Image = CType(resources.GetObject("miVerEstados.Image"), System.Drawing.Image)
        Me.miVerEstados.Name = "miVerEstados"
        Me.miVerEstados.Size = New System.Drawing.Size(213, 22)
        Me.miVerEstados.Text = "VerEstados"
        Me.miVerEstados.Visible = False
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(210, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(210, 6)
        '
        'miFormatoExcel
        '
        Me.miFormatoExcel.Image = CType(resources.GetObject("miFormatoExcel.Image"), System.Drawing.Image)
        Me.miFormatoExcel.Name = "miFormatoExcel"
        Me.miFormatoExcel.Size = New System.Drawing.Size(213, 22)
        Me.miFormatoExcel.Text = "Formato Excel"
        Me.miFormatoExcel.Visible = False
        '
        'miInsertarLista
        '
        Me.miInsertarLista.Image = CType(resources.GetObject("miInsertarLista.Image"), System.Drawing.Image)
        Me.miInsertarLista.Name = "miInsertarLista"
        Me.miInsertarLista.Size = New System.Drawing.Size(213, 22)
        Me.miInsertarLista.Text = "Insertar Lista de Repuestos"
        Me.miInsertarLista.Visible = False
        '
        'miBuscar
        '
        Me.miBuscar.Image = CType(resources.GetObject("miBuscar.Image"), System.Drawing.Image)
        Me.miBuscar.Name = "miBuscar"
        Me.miBuscar.Size = New System.Drawing.Size(213, 22)
        Me.miBuscar.Text = "Buscar"
        '
        'miActualizar
        '
        Me.miActualizar.Image = CType(resources.GetObject("miActualizar.Image"), System.Drawing.Image)
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(213, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = CType(resources.GetObject("miSalir.Image"), System.Drawing.Image)
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(213, 22)
        Me.miSalir.Text = "Salir"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.biImprimir, Me.ToolStripSeparator2, Me.biNuevo, Me.ToolStripSeparator1, Me.biMostrar, Me.ToolStripSeparator3, Me.biEliminar, Me.ToolStripSeparator10, Me.biEnviar, Me.biAprobar, Me.ToolStripSeparator8, Me.biVerEstados, Me.ToolStripSeparator9, Me.biFormatoExcel, Me.ToolStripSeparator4, Me.biActualizar, Me.ToolStripSeparator5, Me.biSalir, Me.ToolStripSeparator11})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(784, 31)
        Me.ToolStrip.TabIndex = 209
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
        Me.biImprimir.Image = CType(resources.GetObject("biImprimir.Image"), System.Drawing.Image)
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Lista de Precio"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = CType(resources.GetObject("biNuevo.Image"), System.Drawing.Image)
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Nueva Lista de Precio"
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
        Me.biMostrar.Text = "Mostrar Lista de Precio"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEliminar
        '
        Me.biEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEliminar.Image = CType(resources.GetObject("biEliminar.Image"), System.Drawing.Image)
        Me.biEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.Size = New System.Drawing.Size(28, 28)
        Me.biEliminar.Text = "Eliminar Lista de Precio"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 31)
        '
        'biEnviar
        '
        Me.biEnviar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEnviar.Image = CType(resources.GetObject("biEnviar.Image"), System.Drawing.Image)
        Me.biEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEnviar.Name = "biEnviar"
        Me.biEnviar.Size = New System.Drawing.Size(28, 28)
        Me.biEnviar.Text = "Enviar Solicitud de Gastos"
        Me.biEnviar.Visible = False
        '
        'biAprobar
        '
        Me.biAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAprobar.Image = CType(resources.GetObject("biAprobar.Image"), System.Drawing.Image)
        Me.biAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAprobar.Name = "biAprobar"
        Me.biAprobar.Size = New System.Drawing.Size(28, 28)
        Me.biAprobar.Text = "Aprobar Lista de Precio"
        Me.biAprobar.Visible = False
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator8.Visible = False
        '
        'biVerEstados
        '
        Me.biVerEstados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biVerEstados.Image = CType(resources.GetObject("biVerEstados.Image"), System.Drawing.Image)
        Me.biVerEstados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biVerEstados.Name = "biVerEstados"
        Me.biVerEstados.Size = New System.Drawing.Size(28, 28)
        Me.biVerEstados.Text = "Ver Estados"
        Me.biVerEstados.Visible = False
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator9.Visible = False
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
        Me.biFormatoExcel.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = CType(resources.GetObject("biActualizar.Image"), System.Drawing.Image)
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Lista de Precio"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(7, 103)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(770, 215)
        Me.dgvDatos.TabIndex = 212
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiGroupBox1.Controls.Add(Me.DataGridView2)
        Me.UiGroupBox1.Controls.Add(Me.cmbRubro)
        Me.UiGroupBox1.Controls.Add(Me.DataGridView1)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 34)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(770, 62)
        Me.UiGroupBox1.TabIndex = 211
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(664, 24)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(34, 23)
        Me.DataGridView2.TabIndex = 234
        Me.DataGridView2.Visible = False
        '
        'cmbRubro
        '
        Me.cmbRubro.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRubro_DesignTimeLayout.LayoutString = resources.GetString("cmbRubro_DesignTimeLayout.LayoutString")
        Me.cmbRubro.DesignTimeLayout = cmbRubro_DesignTimeLayout
        Me.cmbRubro.Location = New System.Drawing.Point(71, 27)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.SelectedIndex = -1
        Me.cmbRubro.SelectedItem = Nothing
        Me.cmbRubro.Size = New System.Drawing.Size(134, 20)
        Me.cmbRubro.TabIndex = 205
        Me.cmbRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(704, 24)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(34, 23)
        Me.DataGridView1.TabIndex = 233
        Me.DataGridView1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 197
        Me.Label3.Text = "Rubro : "
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(211, 26)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
        Me.btnBuscar.TabIndex = 190
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        Me.btnBuscar.Visible = False
        '
        'frmPrecioOferta
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(784, 354)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrecioOferta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precio Oferta"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.cmbOpciones.ResumeLayout(False)
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
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
    Friend WithEvents biEnviar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biAprobar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biVerEstados As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biFormatoExcel As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents miEnviar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAprobar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miVerEstados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miFormatoExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miInsertarLista As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miBuscar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents cmbRubro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
