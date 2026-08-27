<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarcacionConsulta_Nuevo
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
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbOficinas1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbHorario_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarcacionConsulta_Nuevo))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbCalcularNormal = New System.Windows.Forms.RadioButton()
        Me.cbCalcular100 = New System.Windows.Forms.RadioButton()
        Me.cbCalcularViaje = New System.Windows.Forms.RadioButton()
        Me.cbHorarioAsignado = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblHoraIn = New System.Windows.Forms.Label()
        Me.txtSalReal = New System.Windows.Forms.TextBox()
        Me.txtIngReal = New System.Windows.Forms.TextBox()
        Me.txtHoraSal = New System.Windows.Forms.TextBox()
        Me.txtHoraIng = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmbOficinas1 = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbMarcacionesJob = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbOpciones = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbCalcular25 = New System.Windows.Forms.RadioButton()
        Me.cbCalcular35 = New System.Windows.Forms.RadioButton()
        Me.lblHorario = New System.Windows.Forms.Label()
        Me.cmbHorario = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOficinas1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbMarcacionesJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMarcacionesJob.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpciones.SuspendLayout()
        CType(Me.cmbHorario, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.biSalir, Me.ToolStripSeparator1})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(762, 31)
        Me.ToolStrip.TabIndex = 106
        Me.ToolStrip.Text = "Guardar Datos de la Cotizacion"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 495)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(762, 20)
        Me.ssBarra.TabIndex = 105
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(440, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(113, 31)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 112
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'lblNumJob
        '
        Me.lblNumJob.AutoSize = True
        Me.lblNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumJob.Location = New System.Drawing.Point(13, 35)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(23, 15)
        Me.lblNumJob.TabIndex = 114
        Me.lblNumJob.Text = "OT"
        '
        'txtNumJob
        '
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.Location = New System.Drawing.Point(46, 32)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(67, 21)
        Me.txtNumJob.TabIndex = 113
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSolicitante
        '
        Me.txtSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicitante.Location = New System.Drawing.Point(244, 32)
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.Size = New System.Drawing.Size(269, 21)
        Me.txtSolicitante.TabIndex = 116
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(514, 31)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarPersona.TabIndex = 117
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'lblPersona
        '
        Me.lblPersona.AutoSize = True
        Me.lblPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersona.Location = New System.Drawing.Point(163, 35)
        Me.lblPersona.Name = "lblPersona"
        Me.lblPersona.Size = New System.Drawing.Size(75, 15)
        Me.lblPersona.TabIndex = 115
        Me.lblPersona.Text = "Colaborador"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(442, 69)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(85, 21)
        Me.cmbOficinas.TabIndex = 129
        Me.cmbOficinas.Visible = False
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbCalcularNormal
        '
        Me.cbCalcularNormal.AutoSize = True
        Me.cbCalcularNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCalcularNormal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.cbCalcularNormal.Location = New System.Drawing.Point(11, 87)
        Me.cbCalcularNormal.Name = "cbCalcularNormal"
        Me.cbCalcularNormal.Size = New System.Drawing.Size(136, 19)
        Me.cbCalcularNormal.TabIndex = 3
        Me.cbCalcularNormal.Text = "Calcular Hrs Normal"
        Me.cbCalcularNormal.UseVisualStyleBackColor = True
        '
        'cbCalcular100
        '
        Me.cbCalcular100.AutoSize = True
        Me.cbCalcular100.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCalcular100.ForeColor = System.Drawing.SystemColors.Desktop
        Me.cbCalcular100.Location = New System.Drawing.Point(11, 64)
        Me.cbCalcular100.Name = "cbCalcular100"
        Me.cbCalcular100.Size = New System.Drawing.Size(118, 19)
        Me.cbCalcular100.TabIndex = 2
        Me.cbCalcular100.Text = "Calcular al 100%"
        Me.cbCalcular100.UseVisualStyleBackColor = True
        '
        'cbCalcularViaje
        '
        Me.cbCalcularViaje.AutoSize = True
        Me.cbCalcularViaje.Checked = True
        Me.cbCalcularViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCalcularViaje.ForeColor = System.Drawing.SystemColors.Desktop
        Me.cbCalcularViaje.Location = New System.Drawing.Point(11, 41)
        Me.cbCalcularViaje.Name = "cbCalcularViaje"
        Me.cbCalcularViaje.Size = New System.Drawing.Size(139, 19)
        Me.cbCalcularViaje.TabIndex = 1
        Me.cbCalcularViaje.TabStop = True
        Me.cbCalcularViaje.Text = "Calcular Hrs de Viaje"
        Me.cbCalcularViaje.UseVisualStyleBackColor = True
        '
        'cbHorarioAsignado
        '
        Me.cbHorarioAsignado.AutoSize = True
        Me.cbHorarioAsignado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHorarioAsignado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.cbHorarioAsignado.Location = New System.Drawing.Point(11, 18)
        Me.cbHorarioAsignado.Name = "cbHorarioAsignado"
        Me.cbHorarioAsignado.Size = New System.Drawing.Size(159, 19)
        Me.cbHorarioAsignado.TabIndex = 0
        Me.cbHorarioAsignado.Text = "Según Horario Asignado"
        Me.cbHorarioAsignado.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(445, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Hora Sal Real"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(339, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 138
        Me.Label3.Text = "Hora Ing Real"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(248, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Hora Sal"
        '
        'lblHoraIn
        '
        Me.lblHoraIn.AutoSize = True
        Me.lblHoraIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraIn.Location = New System.Drawing.Point(140, 126)
        Me.lblHoraIn.Name = "lblHoraIn"
        Me.lblHoraIn.Size = New System.Drawing.Size(54, 15)
        Me.lblHoraIn.TabIndex = 136
        Me.lblHoraIn.Text = "Hora Ing"
        '
        'txtSalReal
        '
        Me.txtSalReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalReal.Location = New System.Drawing.Point(439, 146)
        Me.txtSalReal.Name = "txtSalReal"
        Me.txtSalReal.Size = New System.Drawing.Size(101, 21)
        Me.txtSalReal.TabIndex = 135
        '
        'txtIngReal
        '
        Me.txtIngReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngReal.Location = New System.Drawing.Point(331, 146)
        Me.txtIngReal.Name = "txtIngReal"
        Me.txtIngReal.Size = New System.Drawing.Size(101, 21)
        Me.txtIngReal.TabIndex = 134
        '
        'txtHoraSal
        '
        Me.txtHoraSal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraSal.Location = New System.Drawing.Point(223, 146)
        Me.txtHoraSal.Name = "txtHoraSal"
        Me.txtHoraSal.Size = New System.Drawing.Size(101, 21)
        Me.txtHoraSal.TabIndex = 133
        '
        'txtHoraIng
        '
        Me.txtHoraIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraIng.Location = New System.Drawing.Point(115, 146)
        Me.txtHoraIng.Name = "txtHoraIng"
        Me.txtHoraIng.Size = New System.Drawing.Size(101, 21)
        Me.txtHoraIng.TabIndex = 132
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(39, 126)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(41, 15)
        Me.lblFecha.TabIndex = 131
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(16, 146)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(92, 21)
        Me.txtFecha.TabIndex = 130
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(91, 179)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(553, 44)
        Me.txtObservacion.TabIndex = 140
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(7, 20)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(735, 185)
        Me.dgvDatos.TabIndex = 142
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOficinas1
        '
        Me.cmbOficinas1.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas1_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas1_DesignTimeLayout.LayoutString")
        Me.cmbOficinas1.DesignTimeLayout = cmbOficinas1_DesignTimeLayout
        Me.cmbOficinas1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas1.Location = New System.Drawing.Point(442, 96)
        Me.cmbOficinas1.Name = "cmbOficinas1"
        Me.cmbOficinas1.SelectedIndex = -1
        Me.cmbOficinas1.SelectedItem = Nothing
        Me.cmbOficinas1.Size = New System.Drawing.Size(85, 21)
        Me.cmbOficinas1.TabIndex = 143
        Me.cmbOficinas1.Visible = False
        Me.cmbOficinas1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbMarcacionesJob
        '
        Me.gbMarcacionesJob.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMarcacionesJob.Controls.Add(Me.dgvDatos)
        Me.gbMarcacionesJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMarcacionesJob.Location = New System.Drawing.Point(5, 271)
        Me.gbMarcacionesJob.Name = "gbMarcacionesJob"
        Me.gbMarcacionesJob.Size = New System.Drawing.Size(748, 213)
        Me.gbMarcacionesJob.TabIndex = 144
        Me.gbMarcacionesJob.Text = "Marcaciones de Job"
        Me.gbMarcacionesJob.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.gbOpciones)
        Me.UiGroupBox2.Controls.Add(Me.lblHorario)
        Me.UiGroupBox2.Controls.Add(Me.cmbHorario)
        Me.UiGroupBox2.Controls.Add(Me.cmbOficinas1)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.lblHoraIn)
        Me.UiGroupBox2.Controls.Add(Me.txtSalReal)
        Me.UiGroupBox2.Controls.Add(Me.txtIngReal)
        Me.UiGroupBox2.Controls.Add(Me.txtHoraSal)
        Me.UiGroupBox2.Controls.Add(Me.txtHoraIng)
        Me.UiGroupBox2.Controls.Add(Me.lblFecha)
        Me.UiGroupBox2.Controls.Add(Me.txtFecha)
        Me.UiGroupBox2.Controls.Add(Me.cmbOficinas)
        Me.UiGroupBox2.Controls.Add(Me.txtSolicitante)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarPersona)
        Me.UiGroupBox2.Controls.Add(Me.lblPersona)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarJob)
        Me.UiGroupBox2.Controls.Add(Me.lblNumJob)
        Me.UiGroupBox2.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(5, 30)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(748, 233)
        Me.UiGroupBox2.TabIndex = 145
        Me.UiGroupBox2.Text = "Datos de Marcación de Job"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbOpciones
        '
        Me.gbOpciones.Controls.Add(Me.cbCalcular25)
        Me.gbOpciones.Controls.Add(Me.cbCalcular35)
        Me.gbOpciones.Controls.Add(Me.cbCalcularNormal)
        Me.gbOpciones.Controls.Add(Me.cbHorarioAsignado)
        Me.gbOpciones.Controls.Add(Me.cbCalcular100)
        Me.gbOpciones.Controls.Add(Me.cbCalcularViaje)
        Me.gbOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.Location = New System.Drawing.Point(557, 13)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(180, 158)
        Me.gbOpciones.TabIndex = 146
        Me.gbOpciones.Text = "Opciones"
        Me.gbOpciones.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbCalcular25
        '
        Me.cbCalcular25.AutoSize = True
        Me.cbCalcular25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCalcular25.ForeColor = System.Drawing.SystemColors.Desktop
        Me.cbCalcular25.Location = New System.Drawing.Point(11, 133)
        Me.cbCalcular25.Name = "cbCalcular25"
        Me.cbCalcular25.Size = New System.Drawing.Size(111, 19)
        Me.cbCalcular25.TabIndex = 133
        Me.cbCalcular25.Text = "Calcular al 25%"
        Me.cbCalcular25.UseVisualStyleBackColor = True
        '
        'cbCalcular35
        '
        Me.cbCalcular35.AutoSize = True
        Me.cbCalcular35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCalcular35.ForeColor = System.Drawing.SystemColors.Desktop
        Me.cbCalcular35.Location = New System.Drawing.Point(11, 110)
        Me.cbCalcular35.Name = "cbCalcular35"
        Me.cbCalcular35.Size = New System.Drawing.Size(111, 19)
        Me.cbCalcular35.TabIndex = 132
        Me.cbCalcular35.Text = "Calcular al 35%"
        Me.cbCalcular35.UseVisualStyleBackColor = True
        '
        'lblHorario
        '
        Me.lblHorario.AutoSize = True
        Me.lblHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorario.Location = New System.Drawing.Point(13, 82)
        Me.lblHorario.Name = "lblHorario"
        Me.lblHorario.Size = New System.Drawing.Size(112, 15)
        Me.lblHorario.TabIndex = 266
        Me.lblHorario.Text = "Calcular hrs. según"
        Me.lblHorario.Visible = False
        '
        'cmbHorario
        '
        Me.cmbHorario.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbHorario_DesignTimeLayout.LayoutString = resources.GetString("cmbHorario_DesignTimeLayout.LayoutString")
        Me.cmbHorario.DesignTimeLayout = cmbHorario_DesignTimeLayout
        Me.cmbHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbHorario.Location = New System.Drawing.Point(130, 78)
        Me.cmbHorario.Name = "cmbHorario"
        Me.cmbHorario.SelectedIndex = -1
        Me.cmbHorario.SelectedItem = Nothing
        Me.cmbHorario.Size = New System.Drawing.Size(261, 21)
        Me.cmbHorario.TabIndex = 265
        Me.cmbHorario.Visible = False
        Me.cmbHorario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmMarcacionConsulta_Nuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(762, 515)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.gbMarcacionesJob)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMarcacionConsulta_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Marcación de la OT"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOficinas1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbMarcacionesJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMarcacionesJob.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpciones.ResumeLayout(False)
        Me.gbOpciones.PerformLayout()
        CType(Me.cmbHorario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents txtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbCalcular100 As System.Windows.Forms.RadioButton
    Friend WithEvents cbCalcularViaje As System.Windows.Forms.RadioButton
    Friend WithEvents cbHorarioAsignado As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHoraIn As System.Windows.Forms.Label
    Friend WithEvents txtSalReal As System.Windows.Forms.TextBox
    Friend WithEvents txtIngReal As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraSal As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraIng As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbOficinas1 As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbCalcularNormal As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbMarcacionesJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbCalcular25 As System.Windows.Forms.RadioButton
    Friend WithEvents cbCalcular35 As System.Windows.Forms.RadioButton
    Friend WithEvents gbOpciones As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblHorario As System.Windows.Forms.Label
    Friend WithEvents cmbHorario As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
