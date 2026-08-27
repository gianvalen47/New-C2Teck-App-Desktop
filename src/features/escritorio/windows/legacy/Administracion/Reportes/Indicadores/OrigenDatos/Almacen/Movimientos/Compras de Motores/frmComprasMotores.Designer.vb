<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComprasMotores
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
        Dim SuperTipSettings1 As Janus.Windows.Common.SuperTipSettings = New Janus.Windows.Common.SuperTipSettings
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComprasMotores))
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox
        Me.chkCliente = New System.Windows.Forms.CheckBox
        Me.txtIdCliente = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtNumDoc = New System.Windows.Forms.TextBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.tipMensajes = New Janus.Windows.Common.JanusSuperTip(Me.components)
        Me.RadToolStrip1 = New Telerik.WinControls.UI.RadToolStrip
        Me.RadToolStripElement1 = New Telerik.WinControls.UI.RadToolStripElement
        Me.RadToolStripItem1 = New Telerik.WinControls.UI.RadToolStripItem
        Me.biImprimir = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem3 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biNuevo = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem1 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biMostrar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem6 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biEliminar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem2 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biActualizar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem5 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biSalir = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem4 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.RadButtonElement9 = New Telerik.WinControls.UI.RadButtonElement
        Me.RadButtonElement14 = New Telerik.WinControls.UI.RadButtonElement
        Me.RadButtonElement10 = New Telerik.WinControls.UI.RadButtonElement
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadToolStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.GroupBox1.Controls.Add(Me.chkCliente)
        Me.GroupBox1.Controls.Add(Me.txtIdCliente)
        Me.GroupBox1.Controls.Add(Me.cmbMes)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtanio)
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.cmbIdLocacion)
        Me.GroupBox1.Controls.Add(Me.cmbOficinas)
        Me.GroupBox1.Controls.Add(Me.txtNumDoc)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(775, 55)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Búsqueda"
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(437, 10)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 26
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'chkCliente
        '
        Me.chkCliente.AutoSize = True
        Me.chkCliente.Checked = True
        Me.chkCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCliente.Location = New System.Drawing.Point(420, 14)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(15, 14)
        Me.chkCliente.TabIndex = 25
        Me.chkCliente.Tag = ""
        Me.chkCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkCliente.UseVisualStyleBackColor = True
        '
        'txtIdCliente
        '
        Me.txtIdCliente.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Ellipsis
        Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(365, 29)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(204, 20)
        SuperTipSettings1.HeaderImage = CType(resources.GetObject("SuperTipSettings1.HeaderImage"), System.Drawing.Image)
        SuperTipSettings1.HeaderText = "Buscar Cliente"
        SuperTipSettings1.ImageListProvider = Nothing
        SuperTipSettings1.Text = "En esta opción puede buscar un cliente, por todos los parámetros que se especific" & _
            "an."
        Me.tipMensajes.SetSuperTip(Me.txtIdCliente, SuperTipSettings1)
        Me.txtIdCliente.TabIndex = 4
        Me.txtIdCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(53, 29)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(88, 20)
        Me.cmbMes.TabIndex = 1
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(53, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Año"
        '
        'txtanio
        '
        Me.txtanio.Location = New System.Drawing.Point(4, 29)
        Me.txtanio.Maximum = 2020
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2006
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(48, 20)
        Me.txtanio.TabIndex = 0
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2006
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(570, 29)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(85, 20)
        Me.cmbEstado.TabIndex = 5
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(228, 29)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(136, 20)
        Me.cmbIdLocacion.TabIndex = 3
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(142, 29)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(85, 20)
        Me.cmbOficinas.TabIndex = 2
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.Location = New System.Drawing.Point(656, 29)
        Me.txtNumDoc.MaxLength = 30
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(50, 20)
        Me.txtNumDoc.TabIndex = 6
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(706, 26)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 25)
        Me.btnBuscar.TabIndex = 7
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(365, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Cliente"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(570, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Estado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(228, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Almacén"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Oficina"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(656, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Número"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 361)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(786, 20)
        Me.ssBarra.TabIndex = 2
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
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(5, 105)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(775, 254)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 142)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(126, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(126, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(126, 22)
        Me.miSalir.Text = "Salir"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'tipMensajes
        '
        Me.tipMensajes.AutoPopDelay = 10000
        Me.tipMensajes.ImageList = Nothing
        Me.tipMensajes.Office2007ColorScheme = Janus.Windows.Common.Office2007ColorScheme.Black
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
        Me.RadToolStrip1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.RadToolStrip1.RootElement.MinSize = New System.Drawing.Size(5, 5)
        Me.RadToolStrip1.ShowOverFlowButton = True
        Me.RadToolStrip1.Size = New System.Drawing.Size(786, 43)
        Me.RadToolStrip1.TabIndex = 3
        Me.RadToolStrip1.Text = "RadToolStrip1"
        '
        'RadToolStripElement1
        '
        Me.RadToolStripElement1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadToolStripItem1})
        Me.RadToolStripElement1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.RadToolStripElement1.MinSize = New System.Drawing.Size(0, 36)
        Me.RadToolStripElement1.Name = "RadToolStripElement1"
        '
        'RadToolStripItem1
        '
        Me.RadToolStripItem1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.biImprimir, Me.RadToolStripSeparatorItem3, Me.biNuevo, Me.RadToolStripSeparatorItem1, Me.biMostrar, Me.RadToolStripSeparatorItem6, Me.biEliminar, Me.RadToolStripSeparatorItem2, Me.biActualizar, Me.RadToolStripSeparatorItem5, Me.biSalir, Me.RadToolStripSeparatorItem4})
        Me.RadToolStripItem1.Key = "0"
        Me.RadToolStripItem1.MaxSize = New System.Drawing.Size(0, 36)
        Me.RadToolStripItem1.MinSize = New System.Drawing.Size(790, 40)
        Me.RadToolStripItem1.Name = "RadToolStripItem1"
        Me.RadToolStripItem1.Text = "RadToolStripItem1"
        CType(Me.RadToolStripItem1.GetChildAt(4), Telerik.WinControls.UI.RadToolStripOverFlowButtonElement).Enabled = False
        CType(Me.RadToolStripItem1.GetChildAt(4), Telerik.WinControls.UI.RadToolStripOverFlowButtonElement).Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'biImprimir
        '
        Me.biImprimir.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biImprimir.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.MaxSize = New System.Drawing.Size(36, 36)
        Me.biImprimir.MinSize = New System.Drawing.Size(36, 36)
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.ShouldPaint = True
        Me.biImprimir.ShowBorder = False
        Me.biImprimir.Text = "newToolStripButtonItem"
        Me.biImprimir.ToolTipText = "Imprimir Compra Actual"
        CType(Me.biImprimir.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(0.6!, 0.55!)
        '
        'RadToolStripSeparatorItem3
        '
        Me.RadToolStripSeparatorItem3.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem3.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem3.Name = "RadToolStripSeparatorItem3"
        Me.RadToolStripSeparatorItem3.Text = "RadToolStripSeparatorItem3"
        '
        'biNuevo
        '
        Me.biNuevo.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biNuevo.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.MaxSize = New System.Drawing.Size(36, 36)
        Me.biNuevo.MinSize = New System.Drawing.Size(36, 36)
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.ShouldPaint = True
        Me.biNuevo.ShowBorder = False
        Me.biNuevo.Text = "newToolStripButtonItem"
        Me.biNuevo.ToolTipText = "Crear Nueva Compra de Motor"
        CType(Me.biNuevo.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(0.55!, 0.55!)
        '
        'RadToolStripSeparatorItem1
        '
        Me.RadToolStripSeparatorItem1.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem1.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem1.Name = "RadToolStripSeparatorItem1"
        Me.RadToolStripSeparatorItem1.Text = "RadToolStripSeparatorItem1"
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
        Me.biMostrar.ShowBorder = False
        Me.biMostrar.Text = "saveToolStripButtonItem"
        Me.biMostrar.ToolTipText = "Mostrar Compra Seleccionada"
        CType(Me.biMostrar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.biMostrar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem6
        '
        Me.RadToolStripSeparatorItem6.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem6.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem6.Name = "RadToolStripSeparatorItem6"
        Me.RadToolStripSeparatorItem6.Text = "RadToolStripSeparatorItem6"
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
        Me.biEliminar.ShowBorder = False
        Me.biEliminar.Text = "openToolStripButtonItem"
        Me.biEliminar.ToolTipText = "Eliminar Compra Seleccionada"
        CType(Me.biEliminar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.biEliminar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem2
        '
        Me.RadToolStripSeparatorItem2.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem2.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem2.Name = "RadToolStripSeparatorItem2"
        Me.RadToolStripSeparatorItem2.Text = "RadToolStripSeparatorItem2"
        '
        'biActualizar
        '
        Me.biActualizar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biActualizar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.MaxSize = New System.Drawing.Size(36, 36)
        Me.biActualizar.MinSize = New System.Drawing.Size(36, 36)
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.ShouldPaint = True
        Me.biActualizar.ShowBorder = False
        Me.biActualizar.Text = "newToolStripButtonItem"
        Me.biActualizar.ToolTipText = "Actualizar Datos de Formulario"
        CType(Me.biActualizar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(0.9!, 0.9!)
        '
        'RadToolStripSeparatorItem5
        '
        Me.RadToolStripSeparatorItem5.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem5.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem5.Name = "RadToolStripSeparatorItem5"
        Me.RadToolStripSeparatorItem5.Text = "RadToolStripSeparatorItem5"
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
        Me.biSalir.ShowBorder = False
        Me.biSalir.Text = "printToolStripButtonItem"
        Me.biSalir.ToolTipText = "Salir del Formulario"
        CType(Me.biSalir.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.biSalir.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem4
        '
        Me.RadToolStripSeparatorItem4.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem4.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem4.Name = "RadToolStripSeparatorItem4"
        Me.RadToolStripSeparatorItem4.Text = "RadToolStripSeparatorItem4"
        '
        'RadButtonElement9
        '
        Me.RadButtonElement9.Name = "RadButtonElement9"
        Me.RadButtonElement9.Text = "RadButtonElement9"
        '
        'RadButtonElement14
        '
        Me.RadButtonElement14.Name = "RadButtonElement14"
        Me.RadButtonElement14.Text = "RadButtonElement14"
        '
        'RadButtonElement10
        '
        Me.RadButtonElement10.Name = "RadButtonElement10"
        Me.RadButtonElement10.Text = "RadButtonElement10"
        '
        'frmComprasMotores
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(786, 381)
        Me.Controls.Add(Me.RadToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(794, 415)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(794, 415)
        Me.Name = "frmComprasMotores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Compra para Motores"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadToolStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIdCliente As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents tipMensajes As Janus.Windows.Common.JanusSuperTip
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadToolStrip1 As Telerik.WinControls.UI.RadToolStrip
    Friend WithEvents RadToolStripElement1 As Telerik.WinControls.UI.RadToolStripElement
    Friend WithEvents RadToolStripItem1 As Telerik.WinControls.UI.RadToolStripItem
    Friend WithEvents biNuevo As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents biEliminar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents biMostrar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents biSalir As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem1 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadToolStripSeparatorItem2 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadButtonElement9 As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem3 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents biImprimir As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadButtonElement14 As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem5 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadToolStripSeparatorItem6 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents biActualizar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadButtonElement10 As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem4 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
