<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocumentosTransito
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
        Me.components = New System.ComponentModel.Container
        Dim cmbTipoDocumento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumentosTransito))
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbTipoDocumento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtNumFac = New System.Windows.Forms.TextBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbRecepcionado = New System.Windows.Forms.CheckBox
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miTrasladar = New System.Windows.Forms.ToolStripMenuItem
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX
        Me.RadToolStrip1 = New Telerik.WinControls.UI.RadToolStrip
        Me.RadToolStripElement1 = New Telerik.WinControls.UI.RadToolStripElement
        Me.RadToolStripItem1 = New Telerik.WinControls.UI.RadToolStripItem
        Me.biTrasladar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem2 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biMostrar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem1 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biEliminar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem3 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biActualizar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem4 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biSalir = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem5 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.RadToolStripItem2 = New Telerik.WinControls.UI.RadToolStripItem
        Me.RadButtonElement9 = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStrip2 = New Telerik.WinControls.UI.RadToolStrip
        Me.RadToolStripItem3 = New Telerik.WinControls.UI.RadToolStripItem
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbTipoDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadToolStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadToolStrip2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtanio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbTipoDocumento)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbIdLocacion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbOficinas)
        Me.GroupBox1.Controls.Add(Me.txtNumFac)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbRecepcionado)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(2, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(774, 55)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Búsqueda"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(515, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Año Docum."
        '
        'txtanio
        '
        Me.txtanio.Location = New System.Drawing.Point(517, 29)
        Me.txtanio.Maximum = 2020
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2006
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(70, 20)
        Me.txtanio.TabIndex = 17
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2006
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(251, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Tipo Documento"
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDocumento_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDocumento_DesignTimeLayout.LayoutString")
        Me.cmbTipoDocumento.DesignTimeLayout = cmbTipoDocumento_DesignTimeLayout
        Me.cmbTipoDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(251, 29)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.SelectedIndex = -1
        Me.cmbTipoDocumento.SelectedItem = Nothing
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(182, 20)
        Me.cmbTipoDocumento.TabIndex = 15
        Me.cmbTipoDocumento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(91, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Almacén"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(91, 29)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(158, 20)
        Me.cmbIdLocacion.TabIndex = 1
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Oficina"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(6, 29)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(83, 20)
        Me.cmbOficinas.TabIndex = 0
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumFac
        '
        Me.txtNumFac.Location = New System.Drawing.Point(435, 29)
        Me.txtNumFac.MaxLength = 30
        Me.txtNumFac.Name = "txtNumFac"
        Me.txtNumFac.Size = New System.Drawing.Size(80, 20)
        Me.txtNumFac.TabIndex = 6
        Me.txtNumFac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(701, 24)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 25)
        Me.btnBuscar.TabIndex = 7
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(435, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Número"
        '
        'cbRecepcionado
        '
        Me.cbRecepcionado.AutoSize = True
        Me.cbRecepcionado.Location = New System.Drawing.Point(595, 31)
        Me.cbRecepcionado.Name = "cbRecepcionado"
        Me.cbRecepcionado.Size = New System.Drawing.Size(108, 17)
        Me.cbRecepcionado.TabIndex = 18
        Me.cbRecepcionado.Text = "Recepcionado"
        Me.cbRecepcionado.UseVisualStyleBackColor = True
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miTrasladar, Me.miMostrar, Me.ToolStripMenuItem1, Me.miEliminar, Me.miActualizar, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(133, 120)
        '
        'miTrasladar
        '
        Me.miTrasladar.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.miTrasladar.Name = "miTrasladar"
        Me.miTrasladar.Size = New System.Drawing.Size(132, 22)
        Me.miTrasladar.Text = "Trasladar"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(132, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(129, 6)
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(132, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(132, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(132, 22)
        Me.miSalir.Text = "Salir"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 375)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(778, 20)
        Me.ssBarra.TabIndex = 10
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
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(8, 113)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(761, 257)
        Me.dgvDatos.TabIndex = 19
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'RadToolStrip1
        '
        Me.RadToolStrip1.AllowDragging = False
        Me.RadToolStrip1.AllowFloating = False
        Me.RadToolStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadToolStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadToolStripElement1})
        Me.RadToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.RadToolStrip1.MinimumSize = New System.Drawing.Size(5, 5)
        Me.RadToolStrip1.Name = "RadToolStrip1"
        Me.RadToolStrip1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        '
        '
        Me.RadToolStrip1.RootElement.MinSize = New System.Drawing.Size(5, 5)
        Me.RadToolStrip1.ShowOverFlowButton = True
        Me.RadToolStrip1.Size = New System.Drawing.Size(778, 43)
        Me.RadToolStrip1.TabIndex = 20
        Me.RadToolStrip1.Text = "RadToolStrip1"
        '
        'RadToolStripElement1
        '
        Me.RadToolStripElement1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadToolStripItem1, Me.RadToolStripItem2})
        Me.RadToolStripElement1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.RadToolStripElement1.MaxSize = New System.Drawing.Size(0, 42)
        Me.RadToolStripElement1.MinSize = New System.Drawing.Size(0, 42)
        Me.RadToolStripElement1.Name = "RadToolStripElement1"
        '
        'RadToolStripItem1
        '
        Me.RadToolStripItem1.AutoSize = False
        Me.RadToolStripItem1.Bounds = New System.Drawing.Rectangle(0, 0, 778, 42)
        Me.RadToolStripItem1.ClipDrawing = True
        Me.RadToolStripItem1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.biTrasladar, Me.RadToolStripSeparatorItem2, Me.biMostrar, Me.RadToolStripSeparatorItem1, Me.biEliminar, Me.RadToolStripSeparatorItem3, Me.biActualizar, Me.RadToolStripSeparatorItem4, Me.biSalir, Me.RadToolStripSeparatorItem5})
        Me.RadToolStripItem1.Key = "0"
        Me.RadToolStripItem1.MaxSize = New System.Drawing.Size(778, 0)
        Me.RadToolStripItem1.MinSize = New System.Drawing.Size(778, 42)
        Me.RadToolStripItem1.Name = "RadToolStripItem1"
        Me.RadToolStripItem1.Text = "RadToolStripItem1"
        CType(Me.RadToolStripItem1.GetChildAt(4), Telerik.WinControls.UI.RadToolStripOverFlowButtonElement).Enabled = False
        CType(Me.RadToolStripItem1.GetChildAt(4), Telerik.WinControls.UI.RadToolStripOverFlowButtonElement).Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'biTrasladar
        '
        Me.biTrasladar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biTrasladar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biTrasladar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biTrasladar.Image = Global.SIGECOM.My.Resources.Resources.Trasladar
        Me.biTrasladar.MinSize = New System.Drawing.Size(36, 36)
        Me.biTrasladar.Name = "biTrasladar"
        Me.biTrasladar.ShouldPaint = True
        Me.biTrasladar.Text = "newToolStripButtonItem"
        Me.biTrasladar.ToolTipText = "Trasladar Documento en Transito"
        CType(Me.biTrasladar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.biTrasladar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem2
        '
        Me.RadToolStripSeparatorItem2.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RadToolStripSeparatorItem2.MaxSize = New System.Drawing.Size(4, 30)
        Me.RadToolStripSeparatorItem2.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem2.Name = "RadToolStripSeparatorItem2"
        Me.RadToolStripSeparatorItem2.ShouldPaint = True
        Me.RadToolStripSeparatorItem2.Text = "RadToolStripSeparatorItem2"
        '
        'biMostrar
        '
        Me.biMostrar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biMostrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biMostrar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.MinSize = New System.Drawing.Size(36, 36)
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.ShouldPaint = True
        Me.biMostrar.Text = "openToolStripButtonItem"
        Me.biMostrar.ToolTipText = "Mostrar Documento Actual"
        CType(Me.biMostrar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.biMostrar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem1
        '
        Me.RadToolStripSeparatorItem1.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RadToolStripSeparatorItem1.MaxSize = New System.Drawing.Size(4, 30)
        Me.RadToolStripSeparatorItem1.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem1.Name = "RadToolStripSeparatorItem1"
        Me.RadToolStripSeparatorItem1.ShouldPaint = True
        Me.RadToolStripSeparatorItem1.Text = "RadToolStripSeparatorItem1"
        '
        'biEliminar
        '
        Me.biEliminar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biEliminar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biEliminar.MinSize = New System.Drawing.Size(36, 36)
        Me.biEliminar.Name = "biEliminar"
        Me.biEliminar.ShouldPaint = True
        Me.biEliminar.Text = "saveToolStripButtonItem"
        Me.biEliminar.ToolTipText = "Eliminar Documento Actual"
        CType(Me.biEliminar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.biEliminar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem3
        '
        Me.RadToolStripSeparatorItem3.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem3.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RadToolStripSeparatorItem3.MaxSize = New System.Drawing.Size(4, 30)
        Me.RadToolStripSeparatorItem3.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem3.Name = "RadToolStripSeparatorItem3"
        Me.RadToolStripSeparatorItem3.ShouldPaint = True
        Me.RadToolStripSeparatorItem3.Text = "RadToolStripSeparatorItem3"
        '
        'biActualizar
        '
        Me.biActualizar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biActualizar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.ShouldPaint = True
        Me.biActualizar.Text = "printToolStripButtonItem"
        Me.biActualizar.ToolTipText = "Actualizar Formulario "
        '
        'RadToolStripSeparatorItem4
        '
        Me.RadToolStripSeparatorItem4.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem4.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RadToolStripSeparatorItem4.MaxSize = New System.Drawing.Size(4, 30)
        Me.RadToolStripSeparatorItem4.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem4.Name = "RadToolStripSeparatorItem4"
        Me.RadToolStripSeparatorItem4.ShouldPaint = True
        Me.RadToolStripSeparatorItem4.Text = "RadToolStripSeparatorItem4"
        '
        'biSalir
        '
        Me.biSalir.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biSalir.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biSalir.MinSize = New System.Drawing.Size(36, 36)
        Me.biSalir.Name = "biSalir"
        Me.biSalir.ShouldPaint = True
        Me.biSalir.Text = "cutToolStripButtonItem"
        Me.biSalir.ToolTipText = "Salir del Formulario"
        CType(Me.biSalir.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.biSalir.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem5
        '
        Me.RadToolStripSeparatorItem5.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem5.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.RadToolStripSeparatorItem5.MaxSize = New System.Drawing.Size(4, 30)
        Me.RadToolStripSeparatorItem5.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem5.Name = "RadToolStripSeparatorItem5"
        Me.RadToolStripSeparatorItem5.ShouldPaint = True
        Me.RadToolStripSeparatorItem5.Text = "RadToolStripSeparatorItem5"
        '
        'RadToolStripItem2
        '
        Me.RadToolStripItem2.Key = "1"
        Me.RadToolStripItem2.Name = "RadToolStripItem2"
        Me.RadToolStripItem2.Text = "RadToolStripItem2"
        '
        'RadButtonElement9
        '
        Me.RadButtonElement9.Name = "RadButtonElement9"
        Me.RadButtonElement9.Text = "RadButtonElement9"
        '
        'RadToolStrip2
        '
        Me.RadToolStrip2.AllowDragging = False
        Me.RadToolStrip2.AllowFloating = False
        Me.RadToolStrip2.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadToolStrip2.Location = New System.Drawing.Point(0, 43)
        Me.RadToolStrip2.MinimumSize = New System.Drawing.Size(5, 5)
        Me.RadToolStrip2.Name = "RadToolStrip2"
        Me.RadToolStrip2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        '
        '
        Me.RadToolStrip2.RootElement.MinSize = New System.Drawing.Size(5, 5)
        Me.RadToolStrip2.ShowOverFlowButton = True
        Me.RadToolStrip2.Size = New System.Drawing.Size(778, 22)
        Me.RadToolStrip2.TabIndex = 21
        Me.RadToolStrip2.Text = "RadToolStrip2"
        '
        'RadToolStripItem3
        '
        Me.RadToolStripItem3.Name = "RadToolStripItem3"
        Me.RadToolStripItem3.Text = "RadToolStripItem3"
        '
        'frmDocumentosTransito
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(778, 395)
        Me.Controls.Add(Me.RadToolStrip2)
        Me.Controls.Add(Me.RadToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(786, 429)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(786, 429)
        Me.Name = "frmDocumentosTransito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documentos en Transito"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbTipoDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadToolStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadToolStrip2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDocumento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumFac As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents cbRecepcionado As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents miTrasladar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadToolStrip1 As Telerik.WinControls.UI.RadToolStrip
    Friend WithEvents RadToolStripElement1 As Telerik.WinControls.UI.RadToolStripElement
    Friend WithEvents RadToolStripItem1 As Telerik.WinControls.UI.RadToolStripItem
    Friend WithEvents biTrasladar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents biMostrar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents biEliminar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents biActualizar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents biSalir As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem2 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadButtonElement9 As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem1 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadToolStripSeparatorItem3 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadToolStripSeparatorItem4 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadToolStripSeparatorItem5 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadToolStrip2 As Telerik.WinControls.UI.RadToolStrip
    Friend WithEvents RadToolStripItem2 As Telerik.WinControls.UI.RadToolStripItem
    Friend WithEvents RadToolStripItem3 As Telerik.WinControls.UI.RadToolStripItem
End Class
