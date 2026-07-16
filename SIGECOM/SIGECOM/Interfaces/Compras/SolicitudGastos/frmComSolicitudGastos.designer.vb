<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudGastos
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
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudGastos))
        Dim cmbCodArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox()
        Me.chkPersona = New System.Windows.Forms.CheckBox()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.cmbCodArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAnio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biMostrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAprobar = New System.Windows.Forms.ToolStripButton()
        Me.biEnviar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.biRechazar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.biAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.biExportarGasto = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.biVerEstados = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.biVerAprobacion = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.biRegistrarArchivos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEnviar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAprobar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRechazar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.miExportarGasto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.miVerEstados = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAprobaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRegistrarArchivos = New System.Windows.Forms.ToolStripMenuItem()
        Me.miExportarCtasPorPagar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.txtIdGasto = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblUnidadNegocio = New System.Windows.Forms.Label()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.cmbOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(877, 30)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(67, 23)
        Me.btnBuscar.TabIndex = 190
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Location = New System.Drawing.Point(712, 32)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(160, 20)
        Me.cmbEstado.TabIndex = 189
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(768, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 196
        Me.Label2.Text = "Estado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(644, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 195
        Me.Label6.Text = "Número"
        '
        'txtSolicitante
        '
        Me.txtSolicitante.BackColor = System.Drawing.SystemColors.Window
        Me.txtSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicitante.Location = New System.Drawing.Point(400, 32)
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.ReadOnly = True
        Me.txtSolicitante.Size = New System.Drawing.Size(202, 20)
        Me.txtSolicitante.TabIndex = 187
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(548, 12)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 194
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'chkPersona
        '
        Me.chkPersona.AutoSize = True
        Me.chkPersona.Checked = True
        Me.chkPersona.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPersona.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPersona.Location = New System.Drawing.Point(530, 14)
        Me.chkPersona.Name = "chkPersona"
        Me.chkPersona.Size = New System.Drawing.Size(15, 14)
        Me.chkPersona.TabIndex = 193
        Me.chkPersona.Tag = ""
        Me.chkPersona.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkPersona.UseVisualStyleBackColor = True
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Location = New System.Drawing.Point(461, 15)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(67, 13)
        Me.lblPersona.TabIndex = 192
        Me.lblPersona.Text = "Solicitante"
        '
        'cmbCodArea
        '
        Me.cmbCodArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodArea_DesignTimeLayout.LayoutString = resources.GetString("cmbCodArea_DesignTimeLayout.LayoutString")
        Me.cmbCodArea.DesignTimeLayout = cmbCodArea_DesignTimeLayout
        Me.cmbCodArea.Location = New System.Drawing.Point(154, 31)
        Me.cmbCodArea.Name = "cmbCodArea"
        Me.cmbCodArea.SelectedIndex = -1
        Me.cmbCodArea.SelectedItem = Nothing
        Me.cmbCodArea.Size = New System.Drawing.Size(117, 20)
        Me.cmbCodArea.TabIndex = 185
        Me.cmbCodArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(603, 30)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarPersona.TabIndex = 187
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(188, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 191
        Me.Label7.Text = "Area"
        '
        'txtAnio
        '
        Me.txtAnio.Location = New System.Drawing.Point(7, 31)
        Me.txtAnio.Maximum = 2059
        Me.txtAnio.Minimum = 2006
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(49, 20)
        Me.txtAnio.TabIndex = 184
        Me.txtAnio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtAnio.Value = 2006
        Me.txtAnio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "Año"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.biImprimir, Me.ToolStripSeparator2, Me.biNuevo, Me.ToolStripSeparator1, Me.biMostrar, Me.ToolStripSeparator3, Me.biEliminar, Me.ToolStripSeparator10, Me.biAprobar, Me.biEnviar, Me.ToolStripSeparator4, Me.ToolStripSeparator8, Me.biRechazar, Me.ToolStripSeparator12, Me.biAnular, Me.ToolStripSeparator7, Me.biExportarGasto, Me.ToolStripSeparator13, Me.biVerEstados, Me.ToolStripSeparator14, Me.biVerAprobacion, Me.ToolStripSeparator9, Me.biRegistrarArchivos, Me.ToolStripSeparator15, Me.biActualizar, Me.ToolStripSeparator5, Me.biSalir, Me.ToolStripSeparator11})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1015, 31)
        Me.ToolStrip.TabIndex = 200
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
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Solicitud de Gastos"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Nueva Solicitud de Gastos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biMostrar
        '
        Me.biMostrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.biMostrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biMostrar.Name = "biMostrar"
        Me.biMostrar.Size = New System.Drawing.Size(28, 28)
        Me.biMostrar.Text = "Mostrar Solicitud de Gastos"
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
        Me.biEliminar.Text = "Eliminar Solicitud de Gastos"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripSeparator10.Visible = False
        '
        'biAprobar
        '
        Me.biAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.biAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAprobar.Name = "biAprobar"
        Me.biAprobar.Size = New System.Drawing.Size(28, 28)
        Me.biAprobar.Text = "Aprobar Solicitud de Gastos"
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'biRechazar
        '
        Me.biRechazar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biRechazar.Image = CType(resources.GetObject("biRechazar.Image"), System.Drawing.Image)
        Me.biRechazar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biRechazar.Name = "biRechazar"
        Me.biRechazar.Size = New System.Drawing.Size(28, 28)
        Me.biRechazar.Text = "Rechazar Solicitud de Gastos"
        Me.biRechazar.ToolTipText = "Rechazar Solicitud de Gastos"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        '
        'biAnular
        '
        Me.biAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAnular.Image = Global.SIGECOM.My.Resources.Resources.Anular
        Me.biAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAnular.Name = "biAnular"
        Me.biAnular.Size = New System.Drawing.Size(28, 28)
        Me.biAnular.Text = "Anular Solicitud de Gastos"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'biExportarGasto
        '
        Me.biExportarGasto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biExportarGasto.Image = CType(resources.GetObject("biExportarGasto.Image"), System.Drawing.Image)
        Me.biExportarGasto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biExportarGasto.Name = "biExportarGasto"
        Me.biExportarGasto.Size = New System.Drawing.Size(28, 28)
        Me.biExportarGasto.Text = "Exportar Gasto"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
        '
        'biVerEstados
        '
        Me.biVerEstados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biVerEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.biVerEstados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biVerEstados.Name = "biVerEstados"
        Me.biVerEstados.Size = New System.Drawing.Size(28, 28)
        Me.biVerEstados.Text = "Ver Estados"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 31)
        '
        'biVerAprobacion
        '
        Me.biVerAprobacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biVerAprobacion.Image = Global.SIGECOM.My.Resources.Resources.detalle
        Me.biVerAprobacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biVerAprobacion.Name = "biVerAprobacion"
        Me.biVerAprobacion.Size = New System.Drawing.Size(28, 28)
        Me.biVerAprobacion.Text = "ToolStripButton1"
        Me.biVerAprobacion.ToolTipText = "Consultar Aprobacion de Centros de Costos"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Solicitudes de Gastos"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.miNuevo, Me.miMostrar, Me.miEliminar, Me.miEnviar, Me.miAprobar, Me.miRechazar, Me.miAnular, Me.miExportarGasto, Me.ToolStripSeparator16, Me.miVerEstados, Me.miAprobaciones, Me.miRegistrarArchivos, Me.miExportarCtasPorPagar, Me.miSeparador1, Me.miActualizar, Me.miSalir})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(227, 346)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(226, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(226, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(226, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'miEliminar
        '
        Me.miEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminar.Name = "miEliminar"
        Me.miEliminar.Size = New System.Drawing.Size(226, 22)
        Me.miEliminar.Text = "Eliminar"
        '
        'miEnviar
        '
        Me.miEnviar.Image = CType(resources.GetObject("miEnviar.Image"), System.Drawing.Image)
        Me.miEnviar.Name = "miEnviar"
        Me.miEnviar.Size = New System.Drawing.Size(226, 22)
        Me.miEnviar.Text = "Enviar"
        Me.miEnviar.Visible = False
        '
        'miAprobar
        '
        Me.miAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.miAprobar.Name = "miAprobar"
        Me.miAprobar.Size = New System.Drawing.Size(226, 22)
        Me.miAprobar.Text = "Aprobar"
        '
        'miRechazar
        '
        Me.miRechazar.Image = CType(resources.GetObject("miRechazar.Image"), System.Drawing.Image)
        Me.miRechazar.Name = "miRechazar"
        Me.miRechazar.Size = New System.Drawing.Size(226, 22)
        Me.miRechazar.Text = "Rechazar"
        Me.miRechazar.ToolTipText = "Rechazar"
        '
        'miAnular
        '
        Me.miAnular.Image = Global.SIGECOM.My.Resources.Resources.Anular
        Me.miAnular.Name = "miAnular"
        Me.miAnular.Size = New System.Drawing.Size(226, 22)
        Me.miAnular.Text = "Anular"
        '
        'miExportarGasto
        '
        Me.miExportarGasto.Image = CType(resources.GetObject("miExportarGasto.Image"), System.Drawing.Image)
        Me.miExportarGasto.Name = "miExportarGasto"
        Me.miExportarGasto.Size = New System.Drawing.Size(226, 22)
        Me.miExportarGasto.Text = "Exportar a Contabilidad"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(223, 6)
        '
        'miVerEstados
        '
        Me.miVerEstados.Image = Global.SIGECOM.My.Resources.Resources.Lupa
        Me.miVerEstados.Name = "miVerEstados"
        Me.miVerEstados.Size = New System.Drawing.Size(226, 22)
        Me.miVerEstados.Text = "VerEstados"
        '
        'miAprobaciones
        '
        Me.miAprobaciones.Image = Global.SIGECOM.My.Resources.Resources.detalle
        Me.miAprobaciones.Name = "miAprobaciones"
        Me.miAprobaciones.Size = New System.Drawing.Size(226, 22)
        Me.miAprobaciones.Text = "Ver Aprobaciones"
        Me.miAprobaciones.ToolTipText = "Consultar Aprobaciones de Centros de Costos"
        '
        'miRegistrarArchivos
        '
        Me.miRegistrarArchivos.Image = CType(resources.GetObject("miRegistrarArchivos.Image"), System.Drawing.Image)
        Me.miRegistrarArchivos.Name = "miRegistrarArchivos"
        Me.miRegistrarArchivos.Size = New System.Drawing.Size(226, 22)
        Me.miRegistrarArchivos.Text = "Registrar Archivos"
        '
        'miExportarCtasPorPagar
        '
        Me.miExportarCtasPorPagar.Image = Global.SIGECOM.My.Resources.Resources.ctasPagar
        Me.miExportarCtasPorPagar.Name = "miExportarCtasPorPagar"
        Me.miExportarCtasPorPagar.Size = New System.Drawing.Size(226, 22)
        Me.miExportarCtasPorPagar.Text = "Exportar a Cuentas por Pagar"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(223, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(226, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(226, 22)
        Me.miSalir.Text = "Salir"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 474)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(1015, 20)
        Me.ssBarra.TabIndex = 201
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(650, 15)
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
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(0, 108)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(1015, 366)
        Me.dgvDatos.TabIndex = 202
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtIdGasto
        '
        Me.txtIdGasto.Location = New System.Drawing.Point(633, 32)
        Me.txtIdGasto.Name = "txtIdGasto"
        Me.txtIdGasto.Numeric = True
        Me.txtIdGasto.Size = New System.Drawing.Size(73, 20)
        Me.txtIdGasto.TabIndex = 188
        Me.txtIdGasto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label26)
        Me.UiGroupBox1.Controls.Add(Me.cmbCentroCosto)
        Me.UiGroupBox1.Controls.Add(Me.cmbMes)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtIdGasto)
        Me.UiGroupBox1.Controls.Add(Me.txtAnio)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.chkPersona)
        Me.UiGroupBox1.Controls.Add(Me.cmbCodArea)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.lblPersona)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtSolicitante)
        Me.UiGroupBox1.Controls.Add(Me.cmbEstado)
        Me.UiGroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPersona)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 37)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(950, 62)
        Me.UiGroupBox1.TabIndex = 203
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(291, 15)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 13)
        Me.Label26.TabIndex = 200
        Me.Label26.Text = "Centro Costo"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(275, 31)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(120, 20)
        Me.cmbCentroCosto.TabIndex = 186
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Location = New System.Drawing.Point(59, 31)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(89, 20)
        Me.cmbMes.TabIndex = 198
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(84, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 197
        Me.Label3.Text = "Mes"
        '
        'lblUnidadNegocio
        '
        Me.lblUnidadNegocio.AutoSize = True
        Me.lblUnidadNegocio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadNegocio.Location = New System.Drawing.Point(473, 9)
        Me.lblUnidadNegocio.Name = "lblUnidadNegocio"
        Me.lblUnidadNegocio.Size = New System.Drawing.Size(134, 15)
        Me.lblUnidadNegocio.TabIndex = 204
        Me.lblUnidadNegocio.Text = "Unidad de Negocio:"
        '
        'frmComSolicitudGastos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1015, 494)
        Me.Controls.Add(Me.lblUnidadNegocio)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudGastos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitudes de Gastos"
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.cmbOpciones.ResumeLayout(False)
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chkPersona As System.Windows.Forms.CheckBox
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents cmbCodArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAnio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biMostrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biAprobar As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAprobar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miVerEstados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biVerEstados As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtIdGasto As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents biEnviar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miEnviar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents biAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents biRechazar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miRechazar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblUnidadNegocio As System.Windows.Forms.Label
    Friend WithEvents biExportarGasto As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miExportarGasto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAprobaciones As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
    Friend WithEvents biVerAprobacion As ToolStripButton
    Friend WithEvents biRegistrarArchivos As ToolStripButton
    Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
    Friend WithEvents miRegistrarArchivos As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As ToolStripSeparator
    Friend WithEvents miExportarCtasPorPagar As ToolStripMenuItem
End Class
