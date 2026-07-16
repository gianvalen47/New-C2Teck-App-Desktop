<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompraMotor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompraMotor))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem
        Me.btnModificarObservacion = New System.Windows.Forms.Button
        Me.txtMotorDestino = New System.Windows.Forms.TextBox
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.gbEstado = New System.Windows.Forms.GroupBox
        Me.lblEstado = New System.Windows.Forms.Label
        Me.txtObservacion = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtNumJob = New System.Windows.Forms.TextBox
        Me.txtIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnBuscarJob = New System.Windows.Forms.Button
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTipoCambio = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.lblFecha = New System.Windows.Forms.Label
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.txtNumDoc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.gbTotal = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox
        Me.lblTotalNeto = New System.Windows.Forms.TextBox
        Me.lbltotalIGV = New System.Windows.Forms.TextBox
        Me.lblTotal = New System.Windows.Forms.TextBox
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotalIGV = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotalPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotalDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.cmOpcionesAtender = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miSeleccionarTodo = New System.Windows.Forms.ToolStripMenuItem
        Me.miSeterCEROTodos = New System.Windows.Forms.ToolStripMenuItem
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.RadToolStrip1 = New Telerik.WinControls.UI.RadToolStrip
        Me.lblUbicacion = New System.Windows.Forms.Label
        Me.RadToolStripElement1 = New Telerik.WinControls.UI.RadToolStripElement
        Me.RadToolStripItem1 = New Telerik.WinControls.UI.RadToolStripItem
        Me.biGuardar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem1 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biEditar = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem2 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biDeshacer = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem3 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.biSalir = New Telerik.WinControls.UI.RadButtonElement
        Me.RadToolStripSeparatorItem4 = New Telerik.WinControls.UI.RadToolStripSeparatorItem
        Me.RadButtonElement9 = New Telerik.WinControls.UI.RadButtonElement
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTotal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.cmOpcionesAtender.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.RadToolStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = CType(resources.GetObject("btnBuscarMercaderia.Image"), System.Drawing.Image)
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(222, 15)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderia.TabIndex = 1
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(5, 23)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvDatos.Size = New System.Drawing.Size(763, 238)
        Me.dgvDatos.TabIndex = 1
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(133, 98)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(132, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(132, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(132, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(129, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(132, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'btnModificarObservacion
        '
        Me.btnModificarObservacion.Image = CType(resources.GetObject("btnModificarObservacion.Image"), System.Drawing.Image)
        Me.btnModificarObservacion.Location = New System.Drawing.Point(727, 65)
        Me.btnModificarObservacion.Name = "btnModificarObservacion"
        Me.btnModificarObservacion.Size = New System.Drawing.Size(25, 22)
        Me.btnModificarObservacion.TabIndex = 13
        Me.btnModificarObservacion.TabStop = False
        Me.btnModificarObservacion.UseVisualStyleBackColor = True
        '
        'txtMotorDestino
        '
        Me.txtMotorDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotorDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotorDestino.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMotorDestino.Location = New System.Drawing.Point(104, 16)
        Me.txtMotorDestino.MaxLength = 50
        Me.txtMotorDestino.Name = "txtMotorDestino"
        Me.txtMotorDestino.ReadOnly = True
        Me.txtMotorDestino.Size = New System.Drawing.Size(118, 20)
        Me.txtMotorDestino.TabIndex = 0
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.gbEstado)
        Me.gbDatos.Controls.Add(Me.btnModificarObservacion)
        Me.gbDatos.Controls.Add(Me.txtObservacion)
        Me.gbDatos.Controls.Add(Me.Label21)
        Me.gbDatos.Controls.Add(Me.txtNumJob)
        Me.gbDatos.Controls.Add(Me.txtIgv)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Controls.Add(Me.btnBuscarJob)
        Me.gbDatos.Controls.Add(Me.cmbCodMon)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.txtTipoCambio)
        Me.gbDatos.Controls.Add(Me.txtCliente)
        Me.gbDatos.Controls.Add(Me.lblFecha)
        Me.gbDatos.Controls.Add(Me.btnBuscarCliente)
        Me.gbDatos.Controls.Add(Me.txtFecDoc)
        Me.gbDatos.Controls.Add(Me.txtNumDoc)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.Label12)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.gbTotal)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(4, 47)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(775, 108)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos Generales"
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(633, 8)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(139, 28)
        Me.gbEstado.TabIndex = 21
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(5, 10)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(124, 16)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(419, 60)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(308, 40)
        Me.txtObservacion.TabIndex = 12
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(343, 75)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Observación"
        '
        'txtNumJob
        '
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtNumJob.Location = New System.Drawing.Point(549, 16)
        Me.txtNumJob.MaxLength = 7
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.ReadOnly = True
        Me.txtNumJob.Size = New System.Drawing.Size(56, 20)
        Me.txtNumJob.TabIndex = 4
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.SystemColors.Control
        Me.txtIgv.Location = New System.Drawing.Point(549, 37)
        Me.txtIgv.MaxLength = 12
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(56, 20)
        Me.txtIgv.TabIndex = 9
        Me.txtIgv.TabStop = False
        Me.txtIgv.Text = "0.00"
        Me.txtIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(511, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "I.G.V."
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = CType(resources.GetObject("btnBuscarJob.Image"), System.Drawing.Image)
        Me.btnBuscarJob.Location = New System.Drawing.Point(605, 15)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 5
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'cmbCodMon
        '
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Location = New System.Drawing.Point(419, 38)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(62, 20)
        Me.cmbCodMon.TabIndex = 8
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(512, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "# Job"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtTipoCambio.Location = New System.Drawing.Point(684, 39)
        Me.txtTipoCambio.MaxLength = 20
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(81, 20)
        Me.txtTipoCambio.TabIndex = 10
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(67, 38)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(273, 20)
        Me.txtCliente.TabIndex = 6
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(370, 21)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 17
        Me.lblFecha.Text = "Fecha"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(340, 37)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 7
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecDoc.Location = New System.Drawing.Point(419, 17)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.Size = New System.Drawing.Size(91, 20)
        Me.txtFecDoc.TabIndex = 3
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.Color.Beige
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumDoc.Location = New System.Drawing.Point(67, 17)
        Me.txtNumDoc.MaxLength = 200
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(83, 20)
        Me.txtNumDoc.TabIndex = 0
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(369, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Moneda"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(2, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Nº Factura"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(623, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "T.Cambio"
        '
        'gbTotal
        '
        Me.gbTotal.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbTotal.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbTotal.Controls.Add(Me.txtMotorDestino)
        Me.gbTotal.Controls.Add(Me.Label5)
        Me.gbTotal.Location = New System.Drawing.Point(47, 58)
        Me.gbTotal.Name = "gbTotal"
        Me.gbTotal.Size = New System.Drawing.Size(278, 47)
        Me.gbTotal.TabIndex = 11
        Me.gbTotal.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Motor Destino"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvDatos)
        Me.GroupBox1.Controls.Add(Me.UiGroupBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 158)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(773, 327)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lista de Detalle"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox1.Controls.Add(Me.lblTotalNeto)
        Me.UiGroupBox1.Controls.Add(Me.lbltotalIGV)
        Me.UiGroupBox1.Controls.Add(Me.lblTotal)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalNeto)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalIGV)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPrecio)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDescuento)
        Me.UiGroupBox1.Controls.Add(Me.txtTotal)
        Me.UiGroupBox1.Location = New System.Drawing.Point(4, 252)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(764, 66)
        Me.UiGroupBox1.TabIndex = 2
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalNeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalNeto.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalNeto.Location = New System.Drawing.Point(0, 46)
        Me.lblTotalNeto.MaxLength = 20
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.ReadOnly = True
        Me.lblTotalNeto.Size = New System.Drawing.Size(621, 20)
        Me.lblTotalNeto.TabIndex = 6
        Me.lblTotalNeto.TabStop = False
        Me.lblTotalNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotalIGV
        '
        Me.lbltotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lbltotalIGV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lbltotalIGV.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbltotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalIGV.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltotalIGV.Location = New System.Drawing.Point(0, 27)
        Me.lbltotalIGV.MaxLength = 20
        Me.lbltotalIGV.Name = "lbltotalIGV"
        Me.lbltotalIGV.ReadOnly = True
        Me.lbltotalIGV.Size = New System.Drawing.Size(621, 20)
        Me.lbltotalIGV.TabIndex = 4
        Me.lbltotalIGV.TabStop = False
        Me.lbltotalIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotal.Location = New System.Drawing.Point(0, 8)
        Me.lblTotal.MaxLength = 20
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.ReadOnly = True
        Me.lblTotal.Size = New System.Drawing.Size(434, 20)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNeto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalNeto.Location = New System.Drawing.Point(618, 46)
        Me.txtTotalNeto.MaxLength = 5
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.ReadOnly = True
        Me.txtTotalNeto.Size = New System.Drawing.Size(129, 20)
        Me.txtTotalNeto.TabIndex = 7
        Me.txtTotalNeto.TabStop = False
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNeto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalIGV
        '
        Me.txtTotalIGV.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalIGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIGV.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalIGV.Location = New System.Drawing.Point(618, 27)
        Me.txtTotalIGV.MaxLength = 5
        Me.txtTotalIGV.Name = "txtTotalIGV"
        Me.txtTotalIGV.ReadOnly = True
        Me.txtTotalIGV.Size = New System.Drawing.Size(129, 20)
        Me.txtTotalIGV.TabIndex = 5
        Me.txtTotalIGV.TabStop = False
        Me.txtTotalIGV.Text = "0.00"
        Me.txtTotalIGV.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalIGV.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIGV.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalPrecio
        '
        Me.txtTotalPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrecio.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalPrecio.Location = New System.Drawing.Point(433, 8)
        Me.txtTotalPrecio.MaxLength = 5
        Me.txtTotalPrecio.Name = "txtTotalPrecio"
        Me.txtTotalPrecio.ReadOnly = True
        Me.txtTotalPrecio.Size = New System.Drawing.Size(97, 20)
        Me.txtTotalPrecio.TabIndex = 1
        Me.txtTotalPrecio.TabStop = False
        Me.txtTotalPrecio.Text = "0.00"
        Me.txtTotalPrecio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalPrecio.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDescuento.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalDescuento.Location = New System.Drawing.Point(529, 8)
        Me.txtTotalDescuento.MaxLength = 5
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(92, 20)
        Me.txtTotalDescuento.TabIndex = 2
        Me.txtTotalDescuento.TabStop = False
        Me.txtTotalDescuento.Text = "0.00"
        Me.txtTotalDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotalDescuento.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotal.Location = New System.Drawing.Point(618, 8)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(129, 20)
        Me.txtTotal.TabIndex = 3
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesAtender
        '
        Me.cmOpcionesAtender.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSeleccionarTodo, Me.miSeterCEROTodos})
        Me.cmOpcionesAtender.Name = "cmOpciones"
        Me.cmOpcionesAtender.Size = New System.Drawing.Size(176, 48)
        '
        'miSeleccionarTodo
        '
        Me.miSeleccionarTodo.Image = CType(resources.GetObject("miSeleccionarTodo.Image"), System.Drawing.Image)
        Me.miSeleccionarTodo.Name = "miSeleccionarTodo"
        Me.miSeleccionarTodo.Size = New System.Drawing.Size(175, 22)
        Me.miSeleccionarTodo.Text = "Seleccionar Todos"
        '
        'miSeterCEROTodos
        '
        Me.miSeterCEROTodos.Image = CType(resources.GetObject("miSeterCEROTodos.Image"), System.Drawing.Image)
        Me.miSeterCEROTodos.Name = "miSeterCEROTodos"
        Me.miSeterCEROTodos.Size = New System.Drawing.Size(175, 22)
        Me.miSeterCEROTodos.Text = "Poner en ""0"" todos"
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
        Me.ssBarra.Location = New System.Drawing.Point(0, 488)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(781, 20)
        Me.ssBarra.TabIndex = 7
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadToolStrip1
        '
        Me.RadToolStrip1.AllowDragging = False
        Me.RadToolStrip1.AllowFloating = False
        Me.RadToolStrip1.Controls.Add(Me.lblUbicacion)
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
        Me.RadToolStrip1.Size = New System.Drawing.Size(781, 43)
        Me.RadToolStrip1.TabIndex = 8
        Me.RadToolStrip1.Text = "RadToolStrip1"
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicacion.Location = New System.Drawing.Point(290, 14)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(97, 15)
        Me.lblUbicacion.TabIndex = 17
        Me.lblUbicacion.Text = "Oficina-Almacen"
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
        Me.RadToolStripItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RadToolStripItem1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadToolStripItem1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.biGuardar, Me.RadToolStripSeparatorItem1, Me.biEditar, Me.RadToolStripSeparatorItem2, Me.biDeshacer, Me.RadToolStripSeparatorItem3, Me.biSalir, Me.RadToolStripSeparatorItem4})
        Me.RadToolStripItem1.Key = "0"
        Me.RadToolStripItem1.MaxSize = New System.Drawing.Size(0, 36)
        Me.RadToolStripItem1.MinSize = New System.Drawing.Size(785, 40)
        Me.RadToolStripItem1.Name = "RadToolStripItem1"
        Me.RadToolStripItem1.Text = "RadToolStripItem1"
        CType(Me.RadToolStripItem1.GetChildAt(4), Telerik.WinControls.UI.RadToolStripOverFlowButtonElement).Enabled = False
        CType(Me.RadToolStripItem1.GetChildAt(4), Telerik.WinControls.UI.RadToolStripOverFlowButtonElement).Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'biGuardar
        '
        Me.biGuardar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biGuardar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.MinSize = New System.Drawing.Size(36, 36)
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.ShouldPaint = True
        Me.biGuardar.Text = "newToolStripButtonItem"
        Me.biGuardar.ToolTipText = "Guardar Cambios Realizados"
        CType(Me.biGuardar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.biGuardar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem1
        '
        Me.RadToolStripSeparatorItem1.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem1.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem1.Name = "RadToolStripSeparatorItem1"
        Me.RadToolStripSeparatorItem1.Text = "RadToolStripSeparatorItem1"
        '
        'biEditar
        '
        Me.biEditar.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biEditar.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biEditar.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.MinSize = New System.Drawing.Size(36, 36)
        Me.biEditar.Name = "biEditar"
        Me.biEditar.ShouldPaint = True
        Me.biEditar.Text = "openToolStripButtonItem"
        Me.biEditar.ToolTipText = "Editar Cabecera "
        CType(Me.biEditar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.biEditar.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem2
        '
        Me.RadToolStripSeparatorItem2.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem2.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem2.Name = "RadToolStripSeparatorItem2"
        Me.RadToolStripSeparatorItem2.Text = "RadToolStripSeparatorItem2"
        '
        'biDeshacer
        '
        Me.biDeshacer.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.biDeshacer.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.biDeshacer.DisplayStyle = Telerik.WinControls.DisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.MinSize = New System.Drawing.Size(36, 36)
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.ShouldPaint = True
        Me.biDeshacer.Text = "saveToolStripButtonItem"
        Me.biDeshacer.ToolTipText = "Deshacer Cambios Realizados"
        CType(Me.biDeshacer.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).Opacity = 1.6
        CType(Me.biDeshacer.GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.ImagePrimitive).ScaleTransform = New System.Drawing.SizeF(1.6!, 1.6!)
        '
        'RadToolStripSeparatorItem3
        '
        Me.RadToolStripSeparatorItem3.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadToolStripSeparatorItem3.MinSize = New System.Drawing.Size(2, 0)
        Me.RadToolStripSeparatorItem3.Name = "RadToolStripSeparatorItem3"
        Me.RadToolStripSeparatorItem3.Text = "RadToolStripSeparatorItem3"
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
        Me.biSalir.Text = "printToolStripButtonItem"
        Me.biSalir.ToolTipText = "Salir de Ventana Actual"
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
        'frmCompraMotor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 508)
        Me.Controls.Add(Me.RadToolStrip1)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCompraMotor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCompraMotor"
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTotal.ResumeLayout(False)
        Me.gbTotal.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.cmOpcionesAtender.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.RadToolStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadToolStrip1.ResumeLayout(False)
        Me.RadToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnModificarObservacion As System.Windows.Forms.Button
    Friend WithEvents txtMotorDestino As System.Windows.Forms.TextBox
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents txtIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gbTotal As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblTotalNeto As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalIGV As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalIGV As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmOpcionesAtender As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miSeleccionarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeterCEROTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents RadToolStrip1 As Telerik.WinControls.UI.RadToolStrip
    Friend WithEvents RadToolStripElement1 As Telerik.WinControls.UI.RadToolStripElement
    Friend WithEvents RadToolStripItem1 As Telerik.WinControls.UI.RadToolStripItem
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents biGuardar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents biEditar As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents biDeshacer As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents biSalir As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem1 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadToolStripSeparatorItem2 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadButtonElement9 As Telerik.WinControls.UI.RadButtonElement
    Friend WithEvents RadToolStripSeparatorItem3 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents RadToolStripSeparatorItem4 As Telerik.WinControls.UI.RadToolStripSeparatorItem
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label

End Class
