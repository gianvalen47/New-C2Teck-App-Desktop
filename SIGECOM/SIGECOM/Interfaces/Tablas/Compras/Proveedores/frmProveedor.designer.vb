<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedor
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
        Dim cmbCodPag_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdTipoCon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedor))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnUbigeo = New System.Windows.Forms.Button()
        Me.btnBuscarPais = New System.Windows.Forms.Button()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbEmiteFacElect = New System.Windows.Forms.CheckBox()
        Me.lblAstApeMat = New System.Windows.Forms.Label()
        Me.txtFecFinHomologacion = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.lblAstApePat = New System.Windows.Forms.Label()
        Me.lblAstAbr = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblAstCondPago = New System.Windows.Forms.Label()
        Me.lblAstRubro = New System.Windows.Forms.Label()
        Me.cmbCodPag = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbImportacion = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbRubro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblAstDni = New System.Windows.Forms.Label()
        Me.lblAstRazSoc = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblAstNombre = New System.Windows.Forms.Label()
        Me.lblAstTipCon = New System.Windows.Forms.Label()
        Me.lblAstNroDoc = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDniProv = New System.Windows.Forms.TextBox()
        Me.lblApeMat = New System.Windows.Forms.Label()
        Me.lblApePat = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtApeMat = New System.Windows.Forms.TextBox()
        Me.txtApePat = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtUbigeo = New System.Windows.Forms.TextBox()
        Me.lblUbigeo = New System.Windows.Forms.Label()
        Me.cmbIdTipoCon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtObsProv = New System.Windows.Forms.TextBox()
        Me.txtUrlProv = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtFaxProv = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTelProv = New System.Windows.Forms.TextBox()
        Me.txtNroDoc = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtAbrProv = New System.Windows.Forms.TextBox()
        Me.txtDirProv = New System.Windows.Forms.TextBox()
        Me.txtDesProv = New System.Windows.Forms.TextBox()
        Me.txtIdProveedor = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tabpContactos = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAgregarContacto = New System.Windows.Forms.Button()
        Me.dgvContactos = New System.Windows.Forms.DataGridView()
        Me.cIdContacto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cApellidos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabVentanas = New Janus.Windows.UI.Tab.UITab()
        Me.TabCuentaPago = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvCuentaPago = New System.Windows.Forms.DataGridView()
        Me.cIdProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodBan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesBan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodTipoCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumCta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cCodDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cDesDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cAbrDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cNumDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbOpcionesCtaPago = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoCtaPago = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarCtaPago = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarCtaPago = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarCtaPago = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAgregarCuentaBanco = New System.Windows.Forms.Button()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.btnConsultaSunat = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.lblAstTipDoc = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ToolStrip.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdTipoCon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpContactos.SuspendLayout()
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabVentanas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabVentanas.SuspendLayout()
        Me.TabCuentaPago.SuspendLayout()
        CType(Me.dgvCuentaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpcionesCtaPago.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator13, Me.btnGuardar, Me.ToolStripSeparator14, Me.btnDeshacer, Me.ToolStripSeparator15, Me.btnEditar, Me.ToolStripSeparator1, Me.btnCancelar, Me.ToolStripSeparator2})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(696, 31)
        Me.ToolStrip.TabIndex = 26
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.Text = "Grabar Cambios"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'btnDeshacer
        '
        Me.btnDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.btnDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
        '
        'btnEditar
        '
        Me.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(28, 28)
        Me.btnEditar.Text = "Editar Datos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnCancelar
        '
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(28, 28)
        Me.btnCancelar.Text = "Cerrar el Formulario"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'btnUbigeo
        '
        Me.btnUbigeo.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnUbigeo.Location = New System.Drawing.Point(361, 169)
        Me.btnUbigeo.Name = "btnUbigeo"
        Me.btnUbigeo.Size = New System.Drawing.Size(29, 21)
        Me.btnUbigeo.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.btnUbigeo, "Seleccionar Departamento,Provincicia y Distrito")
        Me.btnUbigeo.UseVisualStyleBackColor = True
        '
        'btnBuscarPais
        '
        Me.btnBuscarPais.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPais.Location = New System.Drawing.Point(235, 236)
        Me.btnBuscarPais.Name = "btnBuscarPais"
        Me.btnBuscarPais.Size = New System.Drawing.Size(29, 21)
        Me.btnBuscarPais.TabIndex = 69
        Me.ToolTip1.SetToolTip(Me.btnBuscarPais, "Seleccionar Departamento,Provincicia y Distrito")
        Me.btnBuscarPais.UseVisualStyleBackColor = True
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miModificar, Me.miEliminar, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miModificar
        '
        Me.miModificar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miModificar.Name = "miModificar"
        Me.miModificar.Size = New System.Drawing.Size(126, 22)
        Me.miModificar.Text = "Modificar"
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
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 564)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(696, 20)
        Me.ssBarra.TabIndex = 27
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbEmiteFacElect)
        Me.GroupBox2.Location = New System.Drawing.Point(496, 229)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(172, 31)
        Me.GroupBox2.TabIndex = 64
        Me.GroupBox2.TabStop = False
        '
        'cbEmiteFacElect
        '
        Me.cbEmiteFacElect.AutoSize = True
        Me.cbEmiteFacElect.Location = New System.Drawing.Point(13, 11)
        Me.cbEmiteFacElect.Name = "cbEmiteFacElect"
        Me.cbEmiteFacElect.Size = New System.Drawing.Size(147, 17)
        Me.cbEmiteFacElect.TabIndex = 30
        Me.cbEmiteFacElect.TabStop = False
        Me.cbEmiteFacElect.Text = "Emite Factura Electrónica"
        Me.cbEmiteFacElect.UseVisualStyleBackColor = True
        '
        'lblAstApeMat
        '
        Me.lblAstApeMat.AutoSize = True
        Me.lblAstApeMat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstApeMat.ForeColor = System.Drawing.Color.Red
        Me.lblAstApeMat.Location = New System.Drawing.Point(100, 128)
        Me.lblAstApeMat.Name = "lblAstApeMat"
        Me.lblAstApeMat.Size = New System.Drawing.Size(12, 13)
        Me.lblAstApeMat.TabIndex = 63
        Me.lblAstApeMat.Text = "*"
        '
        'txtFecFinHomologacion
        '
        '
        '
        '
        Me.txtFecFinHomologacion.DropDownCalendar.Name = ""
        Me.txtFecFinHomologacion.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinHomologacion.IsNullDate = True
        Me.txtFecFinHomologacion.Location = New System.Drawing.Point(580, 206)
        Me.txtFecFinHomologacion.Name = "txtFecFinHomologacion"
        Me.txtFecFinHomologacion.NullButtonText = "Ninguno"
        Me.txtFecFinHomologacion.ShowNullButton = True
        Me.txtFecFinHomologacion.Size = New System.Drawing.Size(86, 20)
        Me.txtFecFinHomologacion.TabIndex = 43
        Me.txtFecFinHomologacion.TodayButtonText = "Hoy"
        Me.txtFecFinHomologacion.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lblAstApePat
        '
        Me.lblAstApePat.AutoSize = True
        Me.lblAstApePat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstApePat.ForeColor = System.Drawing.Color.Red
        Me.lblAstApePat.Location = New System.Drawing.Point(100, 106)
        Me.lblAstApePat.Name = "lblAstApePat"
        Me.lblAstApePat.Size = New System.Drawing.Size(12, 13)
        Me.lblAstApePat.TabIndex = 62
        Me.lblAstApePat.Text = "*"
        '
        'lblAstAbr
        '
        Me.lblAstAbr.AutoSize = True
        Me.lblAstAbr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstAbr.ForeColor = System.Drawing.Color.Red
        Me.lblAstAbr.Location = New System.Drawing.Point(534, 63)
        Me.lblAstAbr.Name = "lblAstAbr"
        Me.lblAstAbr.Size = New System.Drawing.Size(12, 13)
        Me.lblAstAbr.TabIndex = 61
        Me.lblAstAbr.Text = "*"
        Me.lblAstAbr.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(500, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 27)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Fecha Fin Homologación"
        '
        'lblAstCondPago
        '
        Me.lblAstCondPago.AutoSize = True
        Me.lblAstCondPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstCondPago.ForeColor = System.Drawing.Color.Red
        Me.lblAstCondPago.Location = New System.Drawing.Point(332, 220)
        Me.lblAstCondPago.Name = "lblAstCondPago"
        Me.lblAstCondPago.Size = New System.Drawing.Size(12, 13)
        Me.lblAstCondPago.TabIndex = 60
        Me.lblAstCondPago.Text = "*"
        '
        'lblAstRubro
        '
        Me.lblAstRubro.AutoSize = True
        Me.lblAstRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstRubro.ForeColor = System.Drawing.Color.Red
        Me.lblAstRubro.Location = New System.Drawing.Point(99, 218)
        Me.lblAstRubro.Name = "lblAstRubro"
        Me.lblAstRubro.Size = New System.Drawing.Size(12, 13)
        Me.lblAstRubro.TabIndex = 59
        Me.lblAstRubro.Text = "*"
        '
        'cmbCodPag
        '
        Me.cmbCodPag.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodPag_DesignTimeLayout.LayoutString = resources.GetString("cmbCodPag_DesignTimeLayout.LayoutString")
        Me.cmbCodPag.DesignTimeLayout = cmbCodPag_DesignTimeLayout
        Me.cmbCodPag.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodPag.Location = New System.Drawing.Point(344, 214)
        Me.cmbCodPag.Name = "cmbCodPag"
        Me.cmbCodPag.SelectedIndex = -1
        Me.cmbCodPag.SelectedItem = Nothing
        Me.cmbCodPag.Size = New System.Drawing.Size(129, 19)
        Me.cmbCodPag.TabIndex = 18
        Me.cmbCodPag.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(256, 218)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Cond. de Pago"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbImportacion)
        Me.GroupBox1.Location = New System.Drawing.Point(523, 167)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(133, 31)
        Me.GroupBox1.TabIndex = 56
        Me.GroupBox1.TabStop = False
        '
        'cbImportacion
        '
        Me.cbImportacion.AutoSize = True
        Me.cbImportacion.Location = New System.Drawing.Point(24, 11)
        Me.cbImportacion.Name = "cbImportacion"
        Me.cbImportacion.Size = New System.Drawing.Size(73, 17)
        Me.cbImportacion.TabIndex = 16
        Me.cbImportacion.TabStop = False
        Me.cbImportacion.Text = "Extranjero"
        Me.cbImportacion.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Rubro"
        '
        'cmbRubro
        '
        Me.cmbRubro.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRubro_DesignTimeLayout.LayoutString = resources.GetString("cmbRubro_DesignTimeLayout.LayoutString")
        Me.cmbRubro.DesignTimeLayout = cmbRubro_DesignTimeLayout
        Me.cmbRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRubro.Location = New System.Drawing.Point(116, 214)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.SelectedIndex = -1
        Me.cmbRubro.SelectedItem = Nothing
        Me.cmbRubro.Size = New System.Drawing.Size(117, 19)
        Me.cmbRubro.TabIndex = 17
        Me.cmbRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(508, 270)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(46, 13)
        Me.lblEstado.TabIndex = 52
        Me.lblEstado.Text = "Estado :"
        Me.lblEstado.Visible = False
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Enabled = False
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(559, 266)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(107, 20)
        Me.cmbEstado.TabIndex = 20
        Me.cmbEstado.TabStop = False
        Me.cmbEstado.Visible = False
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblAstDni
        '
        Me.lblAstDni.AutoSize = True
        Me.lblAstDni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstDni.ForeColor = System.Drawing.Color.Red
        Me.lblAstDni.Location = New System.Drawing.Point(535, 129)
        Me.lblAstDni.Name = "lblAstDni"
        Me.lblAstDni.Size = New System.Drawing.Size(12, 13)
        Me.lblAstDni.TabIndex = 49
        Me.lblAstDni.Text = "*"
        Me.lblAstDni.Visible = False
        '
        'lblAstRazSoc
        '
        Me.lblAstRazSoc.AutoSize = True
        Me.lblAstRazSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstRazSoc.ForeColor = System.Drawing.Color.Red
        Me.lblAstRazSoc.Location = New System.Drawing.Point(100, 63)
        Me.lblAstRazSoc.Name = "lblAstRazSoc"
        Me.lblAstRazSoc.Size = New System.Drawing.Size(12, 13)
        Me.lblAstRazSoc.TabIndex = 46
        Me.lblAstRazSoc.Text = "*"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(100, 151)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(12, 13)
        Me.Label19.TabIndex = 47
        Me.Label19.Text = "*"
        '
        'lblAstNombre
        '
        Me.lblAstNombre.AutoSize = True
        Me.lblAstNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstNombre.ForeColor = System.Drawing.Color.Red
        Me.lblAstNombre.Location = New System.Drawing.Point(100, 85)
        Me.lblAstNombre.Name = "lblAstNombre"
        Me.lblAstNombre.Size = New System.Drawing.Size(12, 13)
        Me.lblAstNombre.TabIndex = 46
        Me.lblAstNombre.Text = "*"
        '
        'lblAstTipCon
        '
        Me.lblAstTipCon.AutoSize = True
        Me.lblAstTipCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstTipCon.ForeColor = System.Drawing.Color.Red
        Me.lblAstTipCon.Location = New System.Drawing.Point(334, 18)
        Me.lblAstTipCon.Name = "lblAstTipCon"
        Me.lblAstTipCon.Size = New System.Drawing.Size(12, 13)
        Me.lblAstTipCon.TabIndex = 45
        Me.lblAstTipCon.Text = "*"
        Me.lblAstTipCon.Visible = False
        '
        'lblAstNroDoc
        '
        Me.lblAstNroDoc.AutoSize = True
        Me.lblAstNroDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstNroDoc.ForeColor = System.Drawing.Color.Red
        Me.lblAstNroDoc.Location = New System.Drawing.Point(290, 41)
        Me.lblAstNroDoc.Name = "lblAstNroDoc"
        Me.lblAstNroDoc.Size = New System.Drawing.Size(12, 13)
        Me.lblAstNroDoc.TabIndex = 44
        Me.lblAstNroDoc.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(557, 296)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "* Campos Obligatorios"
        '
        'txtDniProv
        '
        Me.txtDniProv.Location = New System.Drawing.Point(548, 125)
        Me.txtDniProv.MaxLength = 20
        Me.txtDniProv.Name = "txtDniProv"
        Me.txtDniProv.Size = New System.Drawing.Size(119, 20)
        Me.txtDniProv.TabIndex = 8
        Me.txtDniProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDniProv.Visible = False
        '
        'lblApeMat
        '
        Me.lblApeMat.AutoSize = True
        Me.lblApeMat.Location = New System.Drawing.Point(6, 127)
        Me.lblApeMat.Name = "lblApeMat"
        Me.lblApeMat.Size = New System.Drawing.Size(44, 13)
        Me.lblApeMat.TabIndex = 42
        Me.lblApeMat.Text = "ApeMat"
        '
        'lblApePat
        '
        Me.lblApePat.AutoSize = True
        Me.lblApePat.Location = New System.Drawing.Point(6, 104)
        Me.lblApePat.Name = "lblApePat"
        Me.lblApePat.Size = New System.Drawing.Size(42, 13)
        Me.lblApePat.TabIndex = 41
        Me.lblApePat.Text = "ApePat"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(4, 84)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(49, 13)
        Me.lblNombre.TabIndex = 40
        Me.lblNombre.Text = "Nombres"
        '
        'txtApeMat
        '
        Me.txtApeMat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApeMat.Location = New System.Drawing.Point(115, 125)
        Me.txtApeMat.MaxLength = 50
        Me.txtApeMat.Name = "txtApeMat"
        Me.txtApeMat.Size = New System.Drawing.Size(248, 20)
        Me.txtApeMat.TabIndex = 9
        '
        'txtApePat
        '
        Me.txtApePat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApePat.Location = New System.Drawing.Point(115, 103)
        Me.txtApePat.MaxLength = 50
        Me.txtApePat.Name = "txtApePat"
        Me.txtApePat.Size = New System.Drawing.Size(248, 20)
        Me.txtApePat.TabIndex = 7
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(115, 81)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(248, 20)
        Me.txtNombre.TabIndex = 5
        '
        'txtUbigeo
        '
        Me.txtUbigeo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUbigeo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbigeo.Location = New System.Drawing.Point(115, 169)
        Me.txtUbigeo.MaxLength = 3
        Me.txtUbigeo.Name = "txtUbigeo"
        Me.txtUbigeo.ReadOnly = True
        Me.txtUbigeo.Size = New System.Drawing.Size(246, 20)
        Me.txtUbigeo.TabIndex = 12
        '
        'lblUbigeo
        '
        Me.lblUbigeo.AutoSize = True
        Me.lblUbigeo.Location = New System.Drawing.Point(6, 172)
        Me.lblUbigeo.Name = "lblUbigeo"
        Me.lblUbigeo.Size = New System.Drawing.Size(55, 13)
        Me.lblUbigeo.TabIndex = 34
        Me.lblUbigeo.Text = "Ubicacion"
        '
        'cmbIdTipoCon
        '
        Me.cmbIdTipoCon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdTipoCon_DesignTimeLayout.LayoutString = resources.GetString("cmbIdTipoCon_DesignTimeLayout.LayoutString")
        Me.cmbIdTipoCon.DesignTimeLayout = cmbIdTipoCon_DesignTimeLayout
        Me.cmbIdTipoCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdTipoCon.Location = New System.Drawing.Point(349, 15)
        Me.cmbIdTipoCon.Name = "cmbIdTipoCon"
        Me.cmbIdTipoCon.SelectedIndex = -1
        Me.cmbIdTipoCon.SelectedItem = Nothing
        Me.cmbIdTipoCon.Size = New System.Drawing.Size(181, 19)
        Me.cmbIdTipoCon.TabIndex = 1
        Me.cmbIdTipoCon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtObsProv
        '
        Me.txtObsProv.Location = New System.Drawing.Point(116, 260)
        Me.txtObsProv.Multiline = True
        Me.txtObsProv.Name = "txtObsProv"
        Me.txtObsProv.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObsProv.Size = New System.Drawing.Size(357, 49)
        Me.txtObsProv.TabIndex = 19
        '
        'txtUrlProv
        '
        Me.txtUrlProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUrlProv.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUrlProv.Location = New System.Drawing.Point(548, 103)
        Me.txtUrlProv.MaxLength = 100
        Me.txtUrlProv.Name = "txtUrlProv"
        Me.txtUrlProv.Size = New System.Drawing.Size(119, 20)
        Me.txtUrlProv.TabIndex = 10
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEmail.Location = New System.Drawing.Point(344, 192)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(129, 20)
        Me.txtEmail.TabIndex = 15
        '
        'txtFaxProv
        '
        Me.txtFaxProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFaxProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxProv.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFaxProv.Location = New System.Drawing.Point(116, 192)
        Me.txtFaxProv.MaxLength = 20
        Me.txtFaxProv.Name = "txtFaxProv"
        Me.txtFaxProv.Size = New System.Drawing.Size(117, 20)
        Me.txtFaxProv.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 195)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 13)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Fax"
        '
        'txtTelProv
        '
        Me.txtTelProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelProv.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTelProv.Location = New System.Drawing.Point(548, 81)
        Me.txtTelProv.MaxLength = 20
        Me.txtTelProv.Name = "txtTelProv"
        Me.txtTelProv.Size = New System.Drawing.Size(119, 20)
        Me.txtTelProv.TabIndex = 6
        Me.txtTelProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNroDoc
        '
        Me.txtNroDoc.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.txtNroDoc.Location = New System.Drawing.Point(304, 37)
        Me.txtNroDoc.MaxLength = 11
        Me.txtNroDoc.Name = "txtNroDoc"
        Me.txtNroDoc.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull
        Me.txtNroDoc.Size = New System.Drawing.Size(119, 20)
        Me.txtNroDoc.TabIndex = 2
        Me.txtNroDoc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtNroDoc.UseCompatibleTextRendering = False
        Me.txtNroDoc.Value = CType(resources.GetObject("txtNroDoc.Value"), Object)
        Me.txtNroDoc.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64
        '
        'txtAbrProv
        '
        Me.txtAbrProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbrProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbrProv.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAbrProv.Location = New System.Drawing.Point(548, 59)
        Me.txtAbrProv.MaxLength = 3
        Me.txtAbrProv.Name = "txtAbrProv"
        Me.txtAbrProv.Size = New System.Drawing.Size(119, 20)
        Me.txtAbrProv.TabIndex = 4
        Me.txtAbrProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDirProv
        '
        Me.txtDirProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDirProv.Location = New System.Drawing.Point(115, 147)
        Me.txtDirProv.MaxLength = 150
        Me.txtDirProv.Multiline = True
        Me.txtDirProv.Name = "txtDirProv"
        Me.txtDirProv.Size = New System.Drawing.Size(552, 20)
        Me.txtDirProv.TabIndex = 11
        '
        'txtDesProv
        '
        Me.txtDesProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesProv.Location = New System.Drawing.Point(115, 59)
        Me.txtDesProv.MaxLength = 300
        Me.txtDesProv.Name = "txtDesProv"
        Me.txtDesProv.Size = New System.Drawing.Size(354, 20)
        Me.txtDesProv.TabIndex = 3
        '
        'txtIdProveedor
        '
        Me.txtIdProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProveedor.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtIdProveedor.Location = New System.Drawing.Point(115, 15)
        Me.txtIdProveedor.MaxLength = 30
        Me.txtIdProveedor.Name = "txtIdProveedor"
        Me.txtIdProveedor.ReadOnly = True
        Me.txtIdProveedor.Size = New System.Drawing.Size(103, 20)
        Me.txtIdProveedor.TabIndex = 0
        Me.txtIdProveedor.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 263)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 13)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Observación"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Dirección"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(4, 62)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblRazonSocial.TabIndex = 23
        Me.lblRazonSocial.Text = "Razón Social"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Código"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(256, 195)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Email"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Tipo Contribuyente"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(477, 106)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Página Web"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(477, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Teléfono"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(477, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "D.N.I."
        Me.Label13.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(204, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Nro. Documento"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(477, 63)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 13)
        Me.Label24.TabIndex = 29
        Me.Label24.Text = "Abreviatura"
        '
        'tabpContactos
        '
        Me.tabpContactos.Controls.Add(Me.btnAgregarContacto)
        Me.tabpContactos.Controls.Add(Me.dgvContactos)
        Me.tabpContactos.Location = New System.Drawing.Point(1, 21)
        Me.tabpContactos.Name = "tabpContactos"
        Me.tabpContactos.Size = New System.Drawing.Size(672, 171)
        Me.tabpContactos.TabStop = True
        Me.tabpContactos.Text = "Contactos"
        '
        'btnAgregarContacto
        '
        Me.btnAgregarContacto.Image = CType(resources.GetObject("btnAgregarContacto.Image"), System.Drawing.Image)
        Me.btnAgregarContacto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarContacto.Location = New System.Drawing.Point(522, 2)
        Me.btnAgregarContacto.Name = "btnAgregarContacto"
        Me.btnAgregarContacto.Size = New System.Drawing.Size(116, 25)
        Me.btnAgregarContacto.TabIndex = 0
        Me.btnAgregarContacto.Text = "Agregar Contacto"
        Me.btnAgregarContacto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarContacto.UseVisualStyleBackColor = True
        '
        'dgvContactos
        '
        Me.dgvContactos.AllowUserToAddRows = False
        Me.dgvContactos.AllowUserToDeleteRows = False
        Me.dgvContactos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContactos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvContactos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdContacto, Me.cNombres, Me.cApellidos})
        Me.dgvContactos.ContextMenuStrip = Me.cmOpciones
        Me.dgvContactos.Location = New System.Drawing.Point(9, 29)
        Me.dgvContactos.MultiSelect = False
        Me.dgvContactos.Name = "dgvContactos"
        Me.dgvContactos.ReadOnly = True
        Me.dgvContactos.RowHeadersWidth = 20
        Me.dgvContactos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvContactos.Size = New System.Drawing.Size(656, 139)
        Me.dgvContactos.TabIndex = 1
        '
        'cIdContacto
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cIdContacto.DefaultCellStyle = DataGridViewCellStyle2
        Me.cIdContacto.HeaderText = "Código"
        Me.cIdContacto.Name = "cIdContacto"
        Me.cIdContacto.ReadOnly = True
        Me.cIdContacto.Width = 120
        '
        'cNombres
        '
        Me.cNombres.HeaderText = "Nombres"
        Me.cNombres.Name = "cNombres"
        Me.cNombres.ReadOnly = True
        Me.cNombres.Width = 225
        '
        'cApellidos
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cApellidos.DefaultCellStyle = DataGridViewCellStyle3
        Me.cApellidos.HeaderText = "Apellidos"
        Me.cApellidos.Name = "cApellidos"
        Me.cApellidos.ReadOnly = True
        Me.cApellidos.Width = 245
        '
        'tabVentanas
        '
        Me.tabVentanas.Location = New System.Drawing.Point(7, 361)
        Me.tabVentanas.Name = "tabVentanas"
        Me.tabVentanas.Size = New System.Drawing.Size(676, 195)
        Me.tabVentanas.TabIndex = 29
        Me.tabVentanas.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tabpContactos, Me.TabCuentaPago})
        Me.tabVentanas.TabStop = False
        '
        'TabCuentaPago
        '
        Me.TabCuentaPago.Controls.Add(Me.dgvCuentaPago)
        Me.TabCuentaPago.Controls.Add(Me.btnAgregarCuentaBanco)
        Me.TabCuentaPago.Location = New System.Drawing.Point(1, 21)
        Me.TabCuentaPago.Name = "TabCuentaPago"
        Me.TabCuentaPago.Size = New System.Drawing.Size(652, 171)
        Me.TabCuentaPago.TabStop = True
        Me.TabCuentaPago.Text = "Cuenta Pago"
        '
        'dgvCuentaPago
        '
        Me.dgvCuentaPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuentaPago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cIdProveedor, Me.cCodBan, Me.cDesBan, Me.cCodMon, Me.cCodTipoCuenta, Me.cNumCta, Me.cCodDoc, Me.cDesDoc, Me.cAbrDoc, Me.cNumDoc})
        Me.dgvCuentaPago.ContextMenuStrip = Me.cmbOpcionesCtaPago
        Me.dgvCuentaPago.Location = New System.Drawing.Point(10, 34)
        Me.dgvCuentaPago.Name = "dgvCuentaPago"
        Me.dgvCuentaPago.Size = New System.Drawing.Size(639, 134)
        Me.dgvCuentaPago.TabIndex = 4
        '
        'cIdProveedor
        '
        Me.cIdProveedor.HeaderText = "IdProveedor"
        Me.cIdProveedor.Name = "cIdProveedor"
        Me.cIdProveedor.Visible = False
        '
        'cCodBan
        '
        Me.cCodBan.HeaderText = "CodBan"
        Me.cCodBan.Name = "cCodBan"
        Me.cCodBan.Visible = False
        '
        'cDesBan
        '
        Me.cDesBan.HeaderText = "Banco"
        Me.cDesBan.Name = "cDesBan"
        Me.cDesBan.Width = 180
        '
        'cCodMon
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cCodMon.DefaultCellStyle = DataGridViewCellStyle4
        Me.cCodMon.HeaderText = "Mon."
        Me.cCodMon.Name = "cCodMon"
        Me.cCodMon.Width = 50
        '
        'cCodTipoCuenta
        '
        Me.cCodTipoCuenta.HeaderText = "CodTipoCuenta"
        Me.cCodTipoCuenta.Name = "cCodTipoCuenta"
        Me.cCodTipoCuenta.Visible = False
        '
        'cNumCta
        '
        Me.cNumCta.HeaderText = "N° Cuenta"
        Me.cNumCta.Name = "cNumCta"
        Me.cNumCta.Width = 120
        '
        'cCodDoc
        '
        Me.cCodDoc.HeaderText = "CodDoc"
        Me.cCodDoc.Name = "cCodDoc"
        Me.cCodDoc.Visible = False
        '
        'cDesDoc
        '
        Me.cDesDoc.HeaderText = "Doc."
        Me.cDesDoc.Name = "cDesDoc"
        '
        'cAbrDoc
        '
        Me.cAbrDoc.HeaderText = "AbrDoc"
        Me.cAbrDoc.Name = "cAbrDoc"
        Me.cAbrDoc.Visible = False
        '
        'cNumDoc
        '
        Me.cNumDoc.HeaderText = "N° Doc."
        Me.cNumDoc.Name = "cNumDoc"
        Me.cNumDoc.Width = 120
        '
        'cmbOpcionesCtaPago
        '
        Me.cmbOpcionesCtaPago.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoCtaPago, Me.miMostrarCtaPago, Me.miEliminarCtaPago, Me.ToolStripSeparator3, Me.miActualizarCtaPago})
        Me.cmbOpcionesCtaPago.Name = "cmOpciones"
        Me.cmbOpcionesCtaPago.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevoCtaPago
        '
        Me.miNuevoCtaPago.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoCtaPago.Name = "miNuevoCtaPago"
        Me.miNuevoCtaPago.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoCtaPago.Text = "Nuevo"
        '
        'miMostrarCtaPago
        '
        Me.miMostrarCtaPago.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarCtaPago.Name = "miMostrarCtaPago"
        Me.miMostrarCtaPago.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarCtaPago.Text = "Modificar"
        '
        'miEliminarCtaPago
        '
        Me.miEliminarCtaPago.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarCtaPago.Name = "miEliminarCtaPago"
        Me.miEliminarCtaPago.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarCtaPago.Text = "Eliminar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarCtaPago
        '
        Me.miActualizarCtaPago.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarCtaPago.Name = "miActualizarCtaPago"
        Me.miActualizarCtaPago.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarCtaPago.Text = "Actualizar"
        '
        'btnAgregarCuentaBanco
        '
        Me.btnAgregarCuentaBanco.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAgregarCuentaBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarCuentaBanco.Location = New System.Drawing.Point(503, 3)
        Me.btnAgregarCuentaBanco.Name = "btnAgregarCuentaBanco"
        Me.btnAgregarCuentaBanco.Size = New System.Drawing.Size(135, 25)
        Me.btnAgregarCuentaBanco.TabIndex = 2
        Me.btnAgregarCuentaBanco.Text = "Agregar Cuenta Pago"
        Me.btnAgregarCuentaBanco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarCuentaBanco.UseVisualStyleBackColor = True
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.lblMensaje)
        Me.UiGroupBox2.Controls.Add(Me.btnConsultaSunat)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarPais)
        Me.UiGroupBox2.Controls.Add(Me.txtPais)
        Me.UiGroupBox2.Controls.Add(Me.lblAstTipDoc)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.cmbTipoDoc)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.GroupBox2)
        Me.UiGroupBox2.Controls.Add(Me.Label24)
        Me.UiGroupBox2.Controls.Add(Me.lblAstApeMat)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.txtFecFinHomologacion)
        Me.UiGroupBox2.Controls.Add(Me.Label13)
        Me.UiGroupBox2.Controls.Add(Me.lblAstApePat)
        Me.UiGroupBox2.Controls.Add(Me.Label14)
        Me.UiGroupBox2.Controls.Add(Me.lblAstAbr)
        Me.UiGroupBox2.Controls.Add(Me.Label17)
        Me.UiGroupBox2.Controls.Add(Me.Label6)
        Me.UiGroupBox2.Controls.Add(Me.lblAstCondPago)
        Me.UiGroupBox2.Controls.Add(Me.Label16)
        Me.UiGroupBox2.Controls.Add(Me.lblAstRubro)
        Me.UiGroupBox2.Controls.Add(Me.lblRazonSocial)
        Me.UiGroupBox2.Controls.Add(Me.cmbCodPag)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.Label21)
        Me.UiGroupBox2.Controls.Add(Me.GroupBox1)
        Me.UiGroupBox2.Controls.Add(Me.txtIdProveedor)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.txtDesProv)
        Me.UiGroupBox2.Controls.Add(Me.cmbRubro)
        Me.UiGroupBox2.Controls.Add(Me.txtDirProv)
        Me.UiGroupBox2.Controls.Add(Me.lblEstado)
        Me.UiGroupBox2.Controls.Add(Me.txtAbrProv)
        Me.UiGroupBox2.Controls.Add(Me.cmbEstado)
        Me.UiGroupBox2.Controls.Add(Me.txtNroDoc)
        Me.UiGroupBox2.Controls.Add(Me.lblAstDni)
        Me.UiGroupBox2.Controls.Add(Me.txtTelProv)
        Me.UiGroupBox2.Controls.Add(Me.lblAstRazSoc)
        Me.UiGroupBox2.Controls.Add(Me.Label15)
        Me.UiGroupBox2.Controls.Add(Me.Label19)
        Me.UiGroupBox2.Controls.Add(Me.txtFaxProv)
        Me.UiGroupBox2.Controls.Add(Me.lblAstNombre)
        Me.UiGroupBox2.Controls.Add(Me.txtEmail)
        Me.UiGroupBox2.Controls.Add(Me.lblAstTipCon)
        Me.UiGroupBox2.Controls.Add(Me.txtUrlProv)
        Me.UiGroupBox2.Controls.Add(Me.lblAstNroDoc)
        Me.UiGroupBox2.Controls.Add(Me.txtObsProv)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.cmbIdTipoCon)
        Me.UiGroupBox2.Controls.Add(Me.txtDniProv)
        Me.UiGroupBox2.Controls.Add(Me.lblUbigeo)
        Me.UiGroupBox2.Controls.Add(Me.lblApeMat)
        Me.UiGroupBox2.Controls.Add(Me.btnUbigeo)
        Me.UiGroupBox2.Controls.Add(Me.lblApePat)
        Me.UiGroupBox2.Controls.Add(Me.txtUbigeo)
        Me.UiGroupBox2.Controls.Add(Me.lblNombre)
        Me.UiGroupBox2.Controls.Add(Me.txtNombre)
        Me.UiGroupBox2.Controls.Add(Me.txtApeMat)
        Me.UiGroupBox2.Controls.Add(Me.txtApePat)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(7, 34)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(676, 319)
        Me.UiGroupBox2.TabIndex = 216
        Me.UiGroupBox2.Text = "Datos del Proveedor"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.ForeColor = System.Drawing.Color.Red
        Me.lblMensaje.Location = New System.Drawing.Point(474, 39)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(0, 13)
        Me.lblMensaje.TabIndex = 73
        '
        'btnConsultaSunat
        '
        Me.btnConsultaSunat.Location = New System.Drawing.Point(554, 14)
        Me.btnConsultaSunat.Name = "btnConsultaSunat"
        Me.btnConsultaSunat.Size = New System.Drawing.Size(108, 23)
        Me.btnConsultaSunat.TabIndex = 72
        Me.btnConsultaSunat.Text = "Consulta en Linea"
        Me.btnConsultaSunat.UseVisualStyleBackColor = True
        Me.btnConsultaSunat.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(534, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 13)
        Me.Label11.TabIndex = 71
        Me.Label11.Text = "*"
        Me.Label11.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 239)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "Pais"
        '
        'txtPais
        '
        Me.txtPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPais.Location = New System.Drawing.Point(116, 236)
        Me.txtPais.MaxLength = 3
        Me.txtPais.Name = "txtPais"
        Me.txtPais.ReadOnly = True
        Me.txtPais.Size = New System.Drawing.Size(117, 20)
        Me.txtPais.TabIndex = 68
        '
        'lblAstTipDoc
        '
        Me.lblAstTipDoc.AutoSize = True
        Me.lblAstTipDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAstTipDoc.ForeColor = System.Drawing.Color.Red
        Me.lblAstTipDoc.Location = New System.Drawing.Point(100, 40)
        Me.lblAstTipDoc.Name = "lblAstTipDoc"
        Me.lblAstTipDoc.Size = New System.Drawing.Size(12, 13)
        Me.lblAstTipDoc.TabIndex = 67
        Me.lblAstTipDoc.Text = "*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Tipo Documento"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDoc.Location = New System.Drawing.Point(115, 37)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(79, 19)
        Me.cmbTipoDoc.TabIndex = 2
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmProveedor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(696, 584)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.tabVentanas)
        Me.Controls.Add(Me.ToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProveedor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proveedor"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cmbCodPag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdTipoCon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpContactos.ResumeLayout(False)
        CType(Me.dgvContactos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabVentanas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabVentanas.ResumeLayout(False)
        Me.TabCuentaPago.ResumeLayout(False)
        CType(Me.dgvCuentaPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpcionesCtaPago.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblAstDni As System.Windows.Forms.Label
    Friend WithEvents lblAstRazSoc As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblAstNombre As System.Windows.Forms.Label
    Friend WithEvents lblAstTipCon As System.Windows.Forms.Label
    Friend WithEvents lblAstNroDoc As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDniProv As System.Windows.Forms.TextBox
    Friend WithEvents lblApeMat As System.Windows.Forms.Label
    Friend WithEvents lblApePat As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtApeMat As System.Windows.Forms.TextBox
    Friend WithEvents txtApePat As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtUbigeo As System.Windows.Forms.TextBox
    Friend WithEvents btnUbigeo As System.Windows.Forms.Button
    Friend WithEvents lblUbigeo As System.Windows.Forms.Label
    Friend WithEvents cmbIdTipoCon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtObsProv As System.Windows.Forms.TextBox
    Friend WithEvents txtUrlProv As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtFaxProv As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTelProv As System.Windows.Forms.TextBox
    Friend WithEvents txtNroDoc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtAbrProv As System.Windows.Forms.TextBox
    Friend WithEvents txtDirProv As System.Windows.Forms.TextBox
    Friend WithEvents txtDesProv As System.Windows.Forms.TextBox
    Friend WithEvents txtIdProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbImportacion As System.Windows.Forms.CheckBox
    Friend WithEvents tabVentanas As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tabpContactos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents btnAgregarContacto As System.Windows.Forms.Button
    Friend WithEvents dgvContactos As System.Windows.Forms.DataGridView
    Friend WithEvents cmbRubro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCodPag As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblAstCondPago As System.Windows.Forms.Label
    Friend WithEvents lblAstRubro As System.Windows.Forms.Label
    Friend WithEvents lblAstAbr As System.Windows.Forms.Label
    Friend WithEvents lblAstApeMat As System.Windows.Forms.Label
    Friend WithEvents lblAstApePat As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtFecFinHomologacion As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbEmiteFacElect As System.Windows.Forms.CheckBox
    Friend WithEvents cIdContacto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cNombres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cApellidos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents TabCuentaPago As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvCuentaPago As DataGridView
    Friend WithEvents btnAgregarCuentaBanco As Button
    Friend WithEvents cmbOpcionesCtaPago As ContextMenuStrip
    Friend WithEvents miNuevoCtaPago As ToolStripMenuItem
    Friend WithEvents miMostrarCtaPago As ToolStripMenuItem
    Friend WithEvents miEliminarCtaPago As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents miActualizarCtaPago As ToolStripMenuItem
    Friend WithEvents cNumDoc As DataGridViewTextBoxColumn
    Friend WithEvents cAbrDoc As DataGridViewTextBoxColumn
    Friend WithEvents cDesDoc As DataGridViewTextBoxColumn
    Friend WithEvents cCodDoc As DataGridViewTextBoxColumn
    Friend WithEvents cNumCta As DataGridViewTextBoxColumn
    Friend WithEvents cCodTipoCuenta As DataGridViewTextBoxColumn
    Friend WithEvents cCodMon As DataGridViewTextBoxColumn
    Friend WithEvents cDesBan As DataGridViewTextBoxColumn
    Friend WithEvents cCodBan As DataGridViewTextBoxColumn
    Friend WithEvents cIdProveedor As DataGridViewTextBoxColumn
    Friend WithEvents lblAstTipDoc As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As Label
    Friend WithEvents btnBuscarPais As Button
    Friend WithEvents txtPais As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnConsultaSunat As Button
    Friend WithEvents lblMensaje As Label
End Class
