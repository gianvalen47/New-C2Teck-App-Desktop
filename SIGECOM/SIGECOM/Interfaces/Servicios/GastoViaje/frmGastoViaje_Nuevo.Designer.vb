<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGastoViaje_Nuevo
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
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipMov_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGastoViaje_Nuevo))
        Dim cmbPlaca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbSubRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image")
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biVerHoras = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.txtEstadoJob = New System.Windows.Forms.TextBox()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnInfUsuario = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVoucher = New System.Windows.Forms.TextBox()
        Me.txtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFecRegVou = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbTipMov = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtToAproSinIgv = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotalAprobado = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSupervisor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFecAproSup = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAdministrador = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFecAproAdm = New System.Windows.Forms.TextBox()
        Me.btnGuardarDetalle = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbPlaca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbTipDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbSubRubro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbRubro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.txtFechaDet = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotal = New System.Windows.Forms.TextBox()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtSerieDoc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnAgregarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipMov, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSubRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpciones.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.biGuardar, Me.ToolStripSeparator4, Me.biEditar, Me.ToolStripSeparator2, Me.biVerHoras, Me.ToolStripSeparator5, Me.biDeshacer, Me.ToolStripSeparator1, Me.biSalir, Me.ToolStripSeparator6})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1016, 31)
        Me.ToolStrip.TabIndex = 147
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Guardar Gasto de Viaje"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Gasto de Viaje"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biVerHoras
        '
        Me.biVerHoras.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biVerHoras.Image = Global.SIGECOM.My.Resources.Resources.detalle
        Me.biVerHoras.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biVerHoras.Name = "biVerHoras"
        Me.biVerHoras.Size = New System.Drawing.Size(28, 28)
        Me.biVerHoras.Text = "Ver Horas "
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer Cambios"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblEstado.Location = New System.Drawing.Point(449, 39)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(0, 17)
        Me.lblEstado.TabIndex = 149
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumero.Location = New System.Drawing.Point(51, 19)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(71, 20)
        Me.txtNumero.TabIndex = 156
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "#"
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = CType(resources.GetObject("btnBuscarJob.Image"), System.Drawing.Image)
        Me.btnBuscarJob.Location = New System.Drawing.Point(301, 17)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 199
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'txtNumJob
        '
        Me.txtNumJob.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.Location = New System.Drawing.Point(224, 19)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(72, 20)
        Me.txtNumJob.TabIndex = 198
        '
        'lblNumJob
        '
        Me.lblNumJob.AutoSize = True
        Me.lblNumJob.Location = New System.Drawing.Point(174, 22)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(42, 13)
        Me.lblNumJob.TabIndex = 197
        Me.lblNumJob.Text = "Nº OT"
        '
        'txtEstadoJob
        '
        Me.txtEstadoJob.BackColor = System.Drawing.SystemColors.Window
        Me.txtEstadoJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstadoJob.Location = New System.Drawing.Point(332, 19)
        Me.txtEstadoJob.Name = "txtEstadoJob"
        Me.txtEstadoJob.ReadOnly = True
        Me.txtEstadoJob.Size = New System.Drawing.Size(60, 20)
        Me.txtEstadoJob.TabIndex = 200
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = CType(resources.GetObject("btnBuscarPersona.Image"), System.Drawing.Image)
        Me.btnBuscarPersona.Location = New System.Drawing.Point(730, 17)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarPersona.TabIndex = 203
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'txtSolicitante
        '
        Me.txtSolicitante.BackColor = System.Drawing.SystemColors.Window
        Me.txtSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicitante.Location = New System.Drawing.Point(481, 19)
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.ReadOnly = True
        Me.txtSolicitante.Size = New System.Drawing.Size(243, 20)
        Me.txtSolicitante.TabIndex = 202
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(400, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 201
        Me.Label2.Text = "Colaborador"
        '
        'btnInfUsuario
        '
        Me.btnInfUsuario.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnInfUsuario.Location = New System.Drawing.Point(760, 17)
        Me.btnInfUsuario.Name = "btnInfUsuario"
        Me.btnInfUsuario.Size = New System.Drawing.Size(24, 22)
        Me.btnInfUsuario.TabIndex = 204
        Me.btnInfUsuario.TabStop = False
        Me.btnInfUsuario.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(807, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 206
        Me.Label3.Text = "Voucher"
        '
        'txtVoucher
        '
        Me.txtVoucher.Location = New System.Drawing.Point(867, 19)
        Me.txtVoucher.Name = "txtVoucher"
        Me.txtVoucher.Size = New System.Drawing.Size(86, 20)
        Me.txtVoucher.TabIndex = 205
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.FormatString = "#0.00"
        Me.txtMonto.Location = New System.Drawing.Point(51, 50)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(102, 20)
        Me.txtMonto.TabIndex = 210
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 209
        Me.Label11.Text = "Monto"
        '
        'txtFecRegVou
        '
        '
        '
        '
        Me.txtFecRegVou.DropDownCalendar.Name = ""
        Me.txtFecRegVou.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecRegVou.IsNullDate = True
        Me.txtFecRegVou.Location = New System.Drawing.Point(301, 49)
        Me.txtFecRegVou.Name = "txtFecRegVou"
        Me.txtFecRegVou.Size = New System.Drawing.Size(91, 20)
        Me.txtFecRegVou.TabIndex = 212
        Me.txtFecRegVou.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(182, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 13)
        Me.Label7.TabIndex = 211
        Me.Label7.Text = "Fec. Reg. Voucher"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(470, 49)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(81, 20)
        Me.cmbMoneda.TabIndex = 214
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(415, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 213
        Me.Label9.Text = "Moneda"
        '
        'cmbTipMov
        '
        Me.cmbTipMov.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipMov_DesignTimeLayout.LayoutString = resources.GetString("cmbTipMov_DesignTimeLayout.LayoutString")
        Me.cmbTipMov.DesignTimeLayout = cmbTipMov_DesignTimeLayout
        Me.cmbTipMov.Location = New System.Drawing.Point(648, 49)
        Me.cmbTipMov.Name = "cmbTipMov"
        Me.cmbTipMov.SelectedIndex = -1
        Me.cmbTipMov.SelectedItem = Nothing
        Me.cmbTipMov.Size = New System.Drawing.Size(95, 20)
        Me.cmbTipMov.TabIndex = 216
        Me.cmbTipMov.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(578, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 215
        Me.Label4.Text = "Tipo Mov."
        '
        'txtToAproSinIgv
        '
        Me.txtToAproSinIgv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToAproSinIgv.FormatString = "#0.00"
        Me.txtToAproSinIgv.Location = New System.Drawing.Point(867, 49)
        Me.txtToAproSinIgv.Name = "txtToAproSinIgv"
        Me.txtToAproSinIgv.ReadOnly = True
        Me.txtToAproSinIgv.Size = New System.Drawing.Size(104, 20)
        Me.txtToAproSinIgv.TabIndex = 218
        Me.txtToAproSinIgv.Text = "0.00"
        Me.txtToAproSinIgv.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'lblTotalAprobado
        '
        Me.lblTotalAprobado.AutoSize = True
        Me.lblTotalAprobado.Location = New System.Drawing.Point(767, 52)
        Me.lblTotalAprobado.Name = "lblTotalAprobado"
        Me.lblTotalAprobado.Size = New System.Drawing.Size(94, 13)
        Me.lblTotalAprobado.TabIndex = 217
        Me.lblTotalAprobado.Text = "Total Aprobado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 220
        Me.Label6.Text = "Aprob.Supervisor"
        '
        'txtSupervisor
        '
        Me.txtSupervisor.BackColor = System.Drawing.SystemColors.Window
        Me.txtSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupervisor.Location = New System.Drawing.Point(117, 157)
        Me.txtSupervisor.Name = "txtSupervisor"
        Me.txtSupervisor.ReadOnly = True
        Me.txtSupervisor.Size = New System.Drawing.Size(102, 20)
        Me.txtSupervisor.TabIndex = 219
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(268, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 13)
        Me.Label8.TabIndex = 222
        Me.Label8.Text = "Fecha Aprobación"
        '
        'txtFecAproSup
        '
        Me.txtFecAproSup.BackColor = System.Drawing.SystemColors.Window
        Me.txtFecAproSup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecAproSup.Location = New System.Drawing.Point(384, 157)
        Me.txtFecAproSup.Name = "txtFecAproSup"
        Me.txtFecAproSup.ReadOnly = True
        Me.txtFecAproSup.Size = New System.Drawing.Size(82, 20)
        Me.txtFecAproSup.TabIndex = 221
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(510, 160)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 13)
        Me.Label10.TabIndex = 224
        Me.Label10.Text = "Aprob.Administrador"
        '
        'txtAdministrador
        '
        Me.txtAdministrador.BackColor = System.Drawing.SystemColors.Window
        Me.txtAdministrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdministrador.Location = New System.Drawing.Point(637, 157)
        Me.txtAdministrador.Name = "txtAdministrador"
        Me.txtAdministrador.ReadOnly = True
        Me.txtAdministrador.Size = New System.Drawing.Size(111, 20)
        Me.txtAdministrador.TabIndex = 223
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(789, 160)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 13)
        Me.Label12.TabIndex = 226
        Me.Label12.Text = "Fecha Aprobación"
        '
        'txtFecAproAdm
        '
        Me.txtFecAproAdm.BackColor = System.Drawing.SystemColors.Window
        Me.txtFecAproAdm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecAproAdm.Location = New System.Drawing.Point(905, 157)
        Me.txtFecAproAdm.Name = "txtFecAproAdm"
        Me.txtFecAproAdm.ReadOnly = True
        Me.txtFecAproAdm.Size = New System.Drawing.Size(82, 20)
        Me.txtFecAproAdm.TabIndex = 225
        '
        'btnGuardarDetalle
        '
        Me.btnGuardarDetalle.Image = CType(resources.GetObject("btnGuardarDetalle.Image"), System.Drawing.Image)
        Me.btnGuardarDetalle.Location = New System.Drawing.Point(957, 275)
        Me.btnGuardarDetalle.Name = "btnGuardarDetalle"
        Me.btnGuardarDetalle.Size = New System.Drawing.Size(33, 31)
        Me.btnGuardarDetalle.TabIndex = 11
        Me.btnGuardarDetalle.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(41, 220)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 13)
        Me.Label14.TabIndex = 245
        Me.Label14.Text = "Fecha"
        '
        'cmbPlaca
        '
        Me.cmbPlaca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPlaca_DesignTimeLayout.LayoutString = resources.GetString("cmbPlaca_DesignTimeLayout.LayoutString")
        Me.cmbPlaca.DesignTimeLayout = cmbPlaca_DesignTimeLayout
        Me.cmbPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlaca.Location = New System.Drawing.Point(858, 283)
        Me.cmbPlaca.Name = "cmbPlaca"
        Me.cmbPlaca.SelectedIndex = -1
        Me.cmbPlaca.SelectedItem = Nothing
        Me.cmbPlaca.Size = New System.Drawing.Size(91, 20)
        Me.cmbPlaca.TabIndex = 10
        Me.cmbPlaca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.FormatString = "#0.00"
        Me.txtTotal.Location = New System.Drawing.Point(763, 283)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(81, 20)
        Me.txtTotal.TabIndex = 9
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(452, 283)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(297, 20)
        Me.txtDescripcion.TabIndex = 8
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.SystemColors.Control
        Me.txtRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuc.Location = New System.Drawing.Point(329, 283)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.ReadOnly = True
        Me.txtRuc.Size = New System.Drawing.Size(108, 20)
        Me.txtRuc.TabIndex = 7
        Me.txtRuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(882, 268)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 240
        Me.Label15.Text = "Placa"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(783, 267)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 239
        Me.Label16.Text = "Total"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(562, 268)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 238
        Me.Label17.Text = "Descripción"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(351, 267)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 13)
        Me.Label18.TabIndex = 237
        Me.Label18.Text = "Ruc / Dni"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.Location = New System.Drawing.Point(838, 236)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(111, 20)
        Me.txtNumDoc.TabIndex = 6
        Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(860, 220)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 13)
        Me.Label19.TabIndex = 235
        Me.Label19.Text = "Nro. Doc."
        '
        'cmbTipDoc
        '
        Me.cmbTipDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipDoc.DesignTimeLayout = cmbTipDoc_DesignTimeLayout
        Me.cmbTipDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipDoc.Location = New System.Drawing.Point(462, 236)
        Me.cmbTipDoc.Name = "cmbTipDoc"
        Me.cmbTipDoc.SelectedIndex = -1
        Me.cmbTipDoc.SelectedItem = Nothing
        Me.cmbTipDoc.Size = New System.Drawing.Size(228, 20)
        Me.cmbTipDoc.TabIndex = 4
        Me.cmbTipDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(550, 220)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 13)
        Me.Label20.TabIndex = 233
        Me.Label20.Text = "Tipo Doc."
        '
        'cmbSubRubro
        '
        Me.cmbSubRubro.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSubRubro_DesignTimeLayout.LayoutString = resources.GetString("cmbSubRubro_DesignTimeLayout.LayoutString")
        Me.cmbSubRubro.DesignTimeLayout = cmbSubRubro_DesignTimeLayout
        Me.cmbSubRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubRubro.Location = New System.Drawing.Point(311, 236)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.SelectedIndex = -1
        Me.cmbSubRubro.SelectedItem = Nothing
        Me.cmbSubRubro.Size = New System.Drawing.Size(120, 20)
        Me.cmbSubRubro.TabIndex = 3
        Me.cmbSubRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(342, 220)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 13)
        Me.Label21.TabIndex = 231
        Me.Label21.Text = "Concepto"
        '
        'cmbRubro
        '
        Me.cmbRubro.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRubro_DesignTimeLayout.LayoutString = resources.GetString("cmbRubro_DesignTimeLayout.LayoutString")
        Me.cmbRubro.DesignTimeLayout = cmbRubro_DesignTimeLayout
        Me.cmbRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRubro.Location = New System.Drawing.Point(143, 236)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.SelectedIndex = -1
        Me.cmbRubro.SelectedItem = Nothing
        Me.cmbRubro.Size = New System.Drawing.Size(135, 20)
        Me.cmbRubro.TabIndex = 2
        Me.cmbRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRubro.Location = New System.Drawing.Point(191, 220)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(41, 13)
        Me.lblRubro.TabIndex = 229
        Me.lblRubro.Text = "Rubro"
        '
        'txtFechaDet
        '
        '
        '
        '
        Me.txtFechaDet.DropDownCalendar.Name = ""
        Me.txtFechaDet.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaDet.Location = New System.Drawing.Point(12, 237)
        Me.txtFechaDet.Name = "txtFechaDet"
        Me.txtFechaDet.Size = New System.Drawing.Size(98, 20)
        Me.txtFechaDet.TabIndex = 1
        Me.txtFechaDet.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.cmOpciones
        dgvDatos_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatos_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatos_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatos_DesignTimeLayout_Reference_0})
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(0, 313)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(998, 345)
        Me.dgvDatos.TabIndex = 251
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmOpciones
        '
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMostrar, Me.miEliminar, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizar})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(127, 82)
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
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.UiGroupBox1.Controls.Add(Me.txtTotalMonto)
        Me.UiGroupBox1.Controls.Add(Me.lblTotal)
        Me.UiGroupBox1.Location = New System.Drawing.Point(4, 662)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(992, 45)
        Me.UiGroupBox1.TabIndex = 252
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalMonto
        '
        Me.txtTotalMonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.txtTotalMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalMonto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalMonto.Location = New System.Drawing.Point(857, 16)
        Me.txtTotalMonto.MaxLength = 5
        Me.txtTotalMonto.Name = "txtTotalMonto"
        Me.txtTotalMonto.ReadOnly = True
        Me.txtTotalMonto.Size = New System.Drawing.Size(129, 20)
        Me.txtTotalMonto.TabIndex = 16
        Me.txtTotalMonto.TabStop = False
        Me.txtTotalMonto.Text = "0.00"
        Me.txtTotalMonto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalMonto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalMonto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lblTotal.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblTotal.Location = New System.Drawing.Point(7, 16)
        Me.lblTotal.MaxLength = 20
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.ReadOnly = True
        Me.lblTotal.Size = New System.Drawing.Size(856, 20)
        Me.lblTotal.TabIndex = 13
        Me.lblTotal.TabStop = False
        Me.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 734)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(1016, 20)
        Me.ssBarra.TabIndex = 253
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
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtToAproSinIgv)
        Me.UiGroupBox2.Controls.Add(Me.lblTotalAprobado)
        Me.UiGroupBox2.Controls.Add(Me.txtSolicitante)
        Me.UiGroupBox2.Controls.Add(Me.cmbTipMov)
        Me.UiGroupBox2.Controls.Add(Me.txtNumero)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.lblNumJob)
        Me.UiGroupBox2.Controls.Add(Me.txtFecRegVou)
        Me.UiGroupBox2.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarJob)
        Me.UiGroupBox2.Controls.Add(Me.txtMonto)
        Me.UiGroupBox2.Controls.Add(Me.txtEstadoJob)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarPersona)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.btnInfUsuario)
        Me.UiGroupBox2.Controls.Add(Me.txtVoucher)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 59)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(985, 82)
        Me.UiGroupBox2.TabIndex = 255
        Me.UiGroupBox2.Text = "Datos de Gasto de Viaje"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtSerieDoc
        '
        Me.txtSerieDoc.BackColor = System.Drawing.SystemColors.Window
        Me.txtSerieDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieDoc.Location = New System.Drawing.Point(719, 236)
        Me.txtSerieDoc.Name = "txtSerieDoc"
        Me.txtSerieDoc.Size = New System.Drawing.Size(89, 20)
        Me.txtSerieDoc.TabIndex = 5
        Me.txtSerieDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(728, 220)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 257
        Me.Label5.Text = "Serie Doc."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Location = New System.Drawing.Point(9, 195)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(199, 16)
        Me.Label13.TabIndex = 227
        Me.Label13.Text = "Detalles del Gasto de Viaje"
        '
        'btnAgregarProveedor
        '
        Me.btnAgregarProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarProveedor.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnAgregarProveedor.Location = New System.Drawing.Point(296, 283)
        Me.btnAgregarProveedor.Name = "btnAgregarProveedor"
        Me.btnAgregarProveedor.Size = New System.Drawing.Size(23, 21)
        Me.btnAgregarProveedor.TabIndex = 260
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(12, 283)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(250, 20)
        Me.txtProveedor.TabIndex = 259
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarProveedor.Image = CType(resources.GetObject("btnBuscarProveedor.Image"), System.Drawing.Image)
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(268, 282)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 258
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(111, 268)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 13)
        Me.Label22.TabIndex = 261
        Me.Label22.Text = "Proveedor"
        '
        'frmGastoViaje_Nuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1016, 754)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.btnAgregarProveedor)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.btnBuscarProveedor)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.btnGuardarDetalle)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbPlaca)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtSerieDoc)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtRuc)
        Me.Controls.Add(Me.txtNumDoc)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmbSubRubro)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFechaDet)
        Me.Controls.Add(Me.cmbRubro)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.cmbTipDoc)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblRubro)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtFecAproAdm)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAdministrador)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFecAproSup)
        Me.Controls.Add(Me.txtSupervisor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGastoViaje_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Gasto de Viaje"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipMov, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSubRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biVerHoras As System.Windows.Forms.ToolStripButton
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents txtEstadoJob As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVoucher As System.Windows.Forms.TextBox
    Friend WithEvents btnInfUsuario As System.Windows.Forms.Button
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents txtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFecRegVou As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtToAproSinIgv As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotalAprobado As System.Windows.Forms.Label
    Friend WithEvents cmbTipMov As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFecAproAdm As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAdministrador As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFecAproSup As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSupervisor As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardarDetalle As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbPlaca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbSubRubro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbRubro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblRubro As System.Windows.Forms.Label
    Friend WithEvents txtFechaDet As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTotalMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblTotal As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSerieDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
