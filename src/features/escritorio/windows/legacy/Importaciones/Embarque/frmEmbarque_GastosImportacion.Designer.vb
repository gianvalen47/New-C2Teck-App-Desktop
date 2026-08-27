<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmbarque_GastosImportacion
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
        Dim cmbMedio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmbarque_GastosImportacion))
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gbHoraExtra = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFecLlenadoCont = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtInvoiceGE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalGE = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFecLlegada = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbEstadoEmbarque = New System.Windows.Forms.GroupBox()
        Me.lblEstadoMesa = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNroIng = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodEmbarque = New System.Windows.Forms.TextBox()
        Me.cmbMedio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalNeto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.gbDetalles = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lbltotalGasto = New System.Windows.Forms.TextBox()
        Me.lblTotalMontoDol = New System.Windows.Forms.TextBox()
        Me.txtTotalMontoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalMontoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip.SuspendLayout()
        CType(Me.gbHoraExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbHoraExtra.SuspendLayout()
        Me.gbEstadoEmbarque.SuspendLayout()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalles.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biGuardar, Me.ToolStripSeparator3, Me.biEditar, Me.ToolStripSeparator4, Me.biDeshacer, Me.ToolStripSeparator6, Me.biCerrar, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(706, 31)
        Me.ToolStrip.TabIndex = 235
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator2.Visible = False
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Grabar Cambios"
        Me.biGuardar.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator3.Visible = False
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Datos"
        Me.biEditar.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator4.Visible = False
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios"
        Me.biDeshacer.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'gbHoraExtra
        '
        Me.gbHoraExtra.Controls.Add(Me.Label10)
        Me.gbHoraExtra.Controls.Add(Me.txtFecLlenadoCont)
        Me.gbHoraExtra.Controls.Add(Me.txtInvoiceGE)
        Me.gbHoraExtra.Controls.Add(Me.Label8)
        Me.gbHoraExtra.Controls.Add(Me.txtTotalGE)
        Me.gbHoraExtra.Controls.Add(Me.Label7)
        Me.gbHoraExtra.Controls.Add(Me.txtFecLlegada)
        Me.gbHoraExtra.Controls.Add(Me.Label6)
        Me.gbHoraExtra.Controls.Add(Me.gbEstadoEmbarque)
        Me.gbHoraExtra.Controls.Add(Me.Label5)
        Me.gbHoraExtra.Controls.Add(Me.txtNroIng)
        Me.gbHoraExtra.Controls.Add(Me.Label2)
        Me.gbHoraExtra.Controls.Add(Me.txtCodEmbarque)
        Me.gbHoraExtra.Controls.Add(Me.cmbMedio)
        Me.gbHoraExtra.Controls.Add(Me.Label3)
        Me.gbHoraExtra.Controls.Add(Me.Label9)
        Me.gbHoraExtra.Controls.Add(Me.txtTotalNeto)
        Me.gbHoraExtra.Controls.Add(Me.txtObservacion)
        Me.gbHoraExtra.Controls.Add(Me.Label11)
        Me.gbHoraExtra.Controls.Add(Me.Label1)
        Me.gbHoraExtra.Controls.Add(Me.btnBuscarProveedor)
        Me.gbHoraExtra.Controls.Add(Me.txtProveedor)
        Me.gbHoraExtra.Controls.Add(Me.Label4)
        Me.gbHoraExtra.Controls.Add(Me.txtFecha)
        Me.gbHoraExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbHoraExtra.Location = New System.Drawing.Point(11, 34)
        Me.gbHoraExtra.Name = "gbHoraExtra"
        Me.gbHoraExtra.Size = New System.Drawing.Size(657, 170)
        Me.gbHoraExtra.TabIndex = 236
        Me.gbHoraExtra.Text = "Datos Embarque"
        Me.gbHoraExtra.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(452, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 28)
        Me.Label10.TabIndex = 281
        Me.Label10.Text = "Fecha Llenado de Contenedor"
        '
        'txtFecLlenadoCont
        '
        '
        '
        '
        Me.txtFecLlenadoCont.DropDownCalendar.FirstMonth = New Date(2014, 5, 1, 0, 0, 0, 0)
        Me.txtFecLlenadoCont.DropDownCalendar.Name = ""
        Me.txtFecLlenadoCont.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecLlenadoCont.Location = New System.Drawing.Point(549, 141)
        Me.txtFecLlenadoCont.Name = "txtFecLlenadoCont"
        Me.txtFecLlenadoCont.NullButtonText = "Ninguno"
        Me.txtFecLlenadoCont.ShowNullButton = True
        Me.txtFecLlenadoCont.Size = New System.Drawing.Size(92, 20)
        Me.txtFecLlenadoCont.TabIndex = 11
        Me.txtFecLlenadoCont.Value = New Date(2014, 5, 13, 0, 0, 0, 0)
        Me.txtFecLlenadoCont.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtInvoiceGE
        '
        Me.txtInvoiceGE.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvoiceGE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInvoiceGE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceGE.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtInvoiceGE.Location = New System.Drawing.Point(105, 142)
        Me.txtInvoiceGE.MaxLength = 50
        Me.txtInvoiceGE.Name = "txtInvoiceGE"
        Me.txtInvoiceGE.Size = New System.Drawing.Size(98, 20)
        Me.txtInvoiceGE.TabIndex = 9
        Me.txtInvoiceGE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(13, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 29)
        Me.Label8.TabIndex = 278
        Me.Label8.Text = "Invoice Gasto Embarque"
        '
        'txtTotalGE
        '
        Me.txtTotalGE.Location = New System.Drawing.Point(319, 142)
        Me.txtTotalGE.MaxLength = 12
        Me.txtTotalGE.Name = "txtTotalGE"
        Me.txtTotalGE.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalGE.TabIndex = 10
        Me.txtTotalGE.Text = "0.00"
        Me.txtTotalGE.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(242, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 27)
        Me.Label7.TabIndex = 276
        Me.Label7.Text = "Total Gasto Embarque"
        '
        'txtFecLlegada
        '
        '
        '
        '
        Me.txtFecLlegada.DropDownCalendar.FirstMonth = New Date(2014, 5, 1, 0, 0, 0, 0)
        Me.txtFecLlegada.DropDownCalendar.Name = ""
        Me.txtFecLlegada.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecLlegada.IsNullDate = True
        Me.txtFecLlegada.Location = New System.Drawing.Point(105, 75)
        Me.txtFecLlegada.Name = "txtFecLlegada"
        Me.txtFecLlegada.Size = New System.Drawing.Size(95, 20)
        Me.txtFecLlegada.TabIndex = 5
        Me.txtFecLlegada.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 274
        Me.Label6.Text = "Fec. Llegada"
        '
        'gbEstadoEmbarque
        '
        Me.gbEstadoEmbarque.BackColor = System.Drawing.Color.Transparent
        Me.gbEstadoEmbarque.Controls.Add(Me.lblEstadoMesa)
        Me.gbEstadoEmbarque.Location = New System.Drawing.Point(467, 5)
        Me.gbEstadoEmbarque.Name = "gbEstadoEmbarque"
        Me.gbEstadoEmbarque.Size = New System.Drawing.Size(174, 39)
        Me.gbEstadoEmbarque.TabIndex = 272
        Me.gbEstadoEmbarque.TabStop = False
        '
        'lblEstadoMesa
        '
        Me.lblEstadoMesa.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEstadoMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoMesa.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblEstadoMesa.Location = New System.Drawing.Point(6, 12)
        Me.lblEstadoMesa.Name = "lblEstadoMesa"
        Me.lblEstadoMesa.Size = New System.Drawing.Size(162, 21)
        Me.lblEstadoMesa.TabIndex = 0
        Me.lblEstadoMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(252, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 271
        Me.Label5.Text = "Nro. Ingreso"
        '
        'txtNroIng
        '
        Me.txtNroIng.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroIng.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroIng.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtNroIng.Location = New System.Drawing.Point(335, 76)
        Me.txtNroIng.MaxLength = 50
        Me.txtNroIng.Name = "txtNroIng"
        Me.txtNroIng.Size = New System.Drawing.Size(94, 20)
        Me.txtNroIng.TabIndex = 6
        Me.txtNroIng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 269
        Me.Label2.Text = "Código"
        '
        'txtCodEmbarque
        '
        Me.txtCodEmbarque.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodEmbarque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmbarque.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtCodEmbarque.Location = New System.Drawing.Point(105, 21)
        Me.txtCodEmbarque.MaxLength = 50
        Me.txtCodEmbarque.Name = "txtCodEmbarque"
        Me.txtCodEmbarque.Size = New System.Drawing.Size(103, 20)
        Me.txtCodEmbarque.TabIndex = 1
        Me.txtCodEmbarque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbMedio
        '
        Me.cmbMedio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMedio_DesignTimeLayout.LayoutString = resources.GetString("cmbMedio_DesignTimeLayout.LayoutString")
        Me.cmbMedio.DesignTimeLayout = cmbMedio_DesignTimeLayout
        Me.cmbMedio.Location = New System.Drawing.Point(105, 48)
        Me.cmbMedio.Name = "cmbMedio"
        Me.cmbMedio.SelectedIndex = -1
        Me.cmbMedio.SelectedItem = Nothing
        Me.cmbMedio.Size = New System.Drawing.Size(84, 20)
        Me.cmbMedio.TabIndex = 3
        Me.cmbMedio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 243
        Me.Label3.Text = "Medio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 267
        Me.Label9.Text = "Observación"
        '
        'txtTotalNeto
        '
        Me.txtTotalNeto.Location = New System.Drawing.Point(542, 76)
        Me.txtTotalNeto.MaxLength = 12
        Me.txtTotalNeto.Name = "txtTotalNeto"
        Me.txtTotalNeto.Size = New System.Drawing.Size(99, 20)
        Me.txtTotalNeto.TabIndex = 7
        Me.txtTotalNeto.Text = "0.00"
        Me.txtTotalNeto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(105, 102)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(536, 32)
        Me.txtObservacion.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(468, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 239
        Me.Label11.Text = "Total Flete"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(274, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 264
        Me.Label1.Text = "Fecha"
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(616, 48)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 2
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(301, 49)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(312, 20)
        Me.txtProveedor.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(230, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 263
        Me.Label4.Text = "Proveedor"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.FirstMonth = New Date(2014, 5, 1, 0, 0, 0, 0)
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(321, 21)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(95, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.Value = New Date(2014, 5, 13, 0, 0, 0, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Blue
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Location = New System.Drawing.Point(0, 550)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(706, 20)
        Me.ssBarra.TabIndex = 237
        '
        'gbDetalles
        '
        Me.gbDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalles.Controls.Add(Me.UiGroupBox6)
        Me.gbDetalles.Controls.Add(Me.dgvDatos)
        Me.gbDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalles.Location = New System.Drawing.Point(11, 210)
        Me.gbDetalles.Name = "gbDetalles"
        Me.gbDetalles.Size = New System.Drawing.Size(662, 322)
        Me.gbDetalles.TabIndex = 238
        Me.gbDetalles.Text = "Gastos de Importación"
        Me.gbDetalles.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalles.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox6.Controls.Add(Me.lbltotalGasto)
        Me.UiGroupBox6.Controls.Add(Me.lblTotalMontoDol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalMontoSol)
        Me.UiGroupBox6.Controls.Add(Me.txtTotalMontoDol)
        Me.UiGroupBox6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UiGroupBox6.Location = New System.Drawing.Point(3, 273)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(656, 46)
        Me.UiGroupBox6.TabIndex = 229
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lbltotalGasto
        '
        Me.lbltotalGasto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lbltotalGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lbltotalGasto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lbltotalGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalGasto.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltotalGasto.Location = New System.Drawing.Point(342, 15)
        Me.lbltotalGasto.MaxLength = 20
        Me.lbltotalGasto.Name = "lbltotalGasto"
        Me.lbltotalGasto.ReadOnly = True
        Me.lbltotalGasto.Size = New System.Drawing.Size(180, 20)
        Me.lbltotalGasto.TabIndex = 9
        Me.lbltotalGasto.TabStop = False
        Me.lbltotalGasto.Text = "TOTAL SOLES (NS) :"
        Me.lbltotalGasto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalMontoDol
        '
        Me.lblTotalMontoDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotalMontoDol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotalMontoDol.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTotalMontoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMontoDol.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotalMontoDol.Location = New System.Drawing.Point(48, 15)
        Me.lblTotalMontoDol.MaxLength = 20
        Me.lblTotalMontoDol.Name = "lblTotalMontoDol"
        Me.lblTotalMontoDol.ReadOnly = True
        Me.lblTotalMontoDol.Size = New System.Drawing.Size(180, 20)
        Me.lblTotalMontoDol.TabIndex = 8
        Me.lblTotalMontoDol.TabStop = False
        Me.lblTotalMontoDol.Text = "TOTAL DOLARES (USD) :"
        Me.lblTotalMontoDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalMontoSol
        '
        Me.txtTotalMontoSol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalMontoSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMontoSol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalMontoSol.Location = New System.Drawing.Point(519, 15)
        Me.txtTotalMontoSol.MaxLength = 5
        Me.txtTotalMontoSol.Name = "txtTotalMontoSol"
        Me.txtTotalMontoSol.ReadOnly = True
        Me.txtTotalMontoSol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalMontoSol.TabIndex = 5
        Me.txtTotalMontoSol.TabStop = False
        Me.txtTotalMontoSol.Text = "0.00"
        Me.txtTotalMontoSol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalMontoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalMontoSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalMontoDol
        '
        Me.txtTotalMontoDol.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalMontoDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMontoDol.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalMontoDol.Location = New System.Drawing.Point(225, 15)
        Me.txtTotalMontoDol.MaxLength = 5
        Me.txtTotalMontoDol.Name = "txtTotalMontoDol"
        Me.txtTotalMontoDol.ReadOnly = True
        Me.txtTotalMontoDol.Size = New System.Drawing.Size(90, 20)
        Me.txtTotalMontoDol.TabIndex = 3
        Me.txtTotalMontoDol.TabStop = False
        Me.txtTotalMontoDol.Text = "0.00"
        Me.txtTotalMontoDol.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalMontoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalMontoDol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(6, 18)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(645, 227)
        Me.dgvDatos.TabIndex = 228
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        Me.miNuevo.ToolTipText = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        Me.miMostrar.ToolTipText = "Mostrar Detalle"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(126, 22)
        Me.miEliminar.Text = "Eliminar"
        Me.miEliminar.ToolTipText = "Eliminar Detalle"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(123, 6)
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
        Me.miActualizar.ToolTipText = "Refrescar Lista Detalles"
        '
        'frmEmbarque_GastosImportacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(706, 570)
        Me.Controls.Add(Me.gbDetalles)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbHoraExtra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmbarque_GastosImportacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Embarque - Gastos de Importación"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.gbHoraExtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbHoraExtra.ResumeLayout(False)
        Me.gbHoraExtra.PerformLayout()
        Me.gbEstadoEmbarque.ResumeLayout(False)
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalles.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents biGuardar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents biEditar As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents biDeshacer As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents biCerrar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents gbHoraExtra As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtFecLlenadoCont As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtInvoiceGE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTotalGE As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFecLlegada As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label6 As Label
    Friend WithEvents gbEstadoEmbarque As GroupBox
    Friend WithEvents lblEstadoMesa As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNroIng As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCodEmbarque As TextBox
    Friend WithEvents cmbMedio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTotalNeto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBuscarProveedor As Button
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As StatusStrip
    Friend WithEvents gbDetalles As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpciones As ContextMenuStrip
    Friend WithEvents miNuevo As ToolStripMenuItem
    Friend WithEvents miMostrar As ToolStripMenuItem
    Friend WithEvents miEliminar As ToolStripMenuItem
    Friend WithEvents miSeparador1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents miActualizar As ToolStripMenuItem
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lbltotalGasto As TextBox
    Friend WithEvents lblTotalMontoDol As TextBox
    Friend WithEvents txtTotalMontoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalMontoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
