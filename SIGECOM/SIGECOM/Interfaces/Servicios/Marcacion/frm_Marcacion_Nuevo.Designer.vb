<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Marcacion_Nuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Marcacion_Nuevo))
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ButtonImage")
        Dim cmbOficinas1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbHorario_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biVerHoras = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.lblPersona = New System.Windows.Forms.Label()
        Me.cbCalcular25 = New System.Windows.Forms.RadioButton()
        Me.cbCalcular35 = New System.Windows.Forms.RadioButton()
        Me.cbCalcularNormal = New System.Windows.Forms.RadioButton()
        Me.cbCalcular100 = New System.Windows.Forms.RadioButton()
        Me.cbCalcularViaje = New System.Windows.Forms.RadioButton()
        Me.cbHorarioAsignado = New System.Windows.Forms.RadioButton()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtHoraIng = New System.Windows.Forms.TextBox()
        Me.txtHoraSal = New System.Windows.Forms.TextBox()
        Me.txtIngReal = New System.Windows.Forms.TextBox()
        Me.txtSalReal = New System.Windows.Forms.TextBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblHoraIn = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbOficinas1 = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbOpciones = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbDetalles = New Janus.Windows.EditControls.UIGroupBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblHorario = New System.Windows.Forms.Label()
        Me.cmbHorario = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ssBarra.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        CType(Me.cmbOficinas1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpciones.SuspendLayout()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalles.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbHorario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 534)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(796, 20)
        Me.ssBarra.TabIndex = 103
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
        Me.sslTotal.Size = New System.Drawing.Size(250, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biNuevo, Me.ToolStripSeparator3, Me.biEditar, Me.ToolStripSeparator2, Me.biDeshacer, Me.ToolStripSeparator1, Me.biVerHoras, Me.ToolStripSeparator4, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(796, 31)
        Me.ToolStrip.TabIndex = 104
        Me.ToolStrip.Text = "Guardar Datos de la Cotizacion"
        '
        'biNuevo
        '
        Me.biNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biNuevo.Enabled = False
        Me.biNuevo.Image = CType(resources.GetObject("biNuevo.Image"), System.Drawing.Image)
        Me.biNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.Text = "Agregar Nueva Marcación a la OT"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Enabled = False
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Marcación"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Enabled = False
        Me.biDeshacer.Image = CType(resources.GetObject("biDeshacer.Image"), System.Drawing.Image)
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
        'biVerHoras
        '
        Me.biVerHoras.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biVerHoras.Enabled = False
        Me.biVerHoras.Image = Global.SIGECOM.My.Resources.Resources.detalle
        Me.biVerHoras.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biVerHoras.Name = "biVerHoras"
        Me.biVerHoras.Size = New System.Drawing.Size(28, 28)
        Me.biVerHoras.Text = "Ver Horas"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
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
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.Location = New System.Drawing.Point(670, 186)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(30, 27)
        Me.btnGuardar.TabIndex = 105
        Me.btnGuardar.TabStop = False
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(113, 31)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 109
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
        Me.lblNumJob.TabIndex = 111
        Me.lblNumJob.Text = "OT"
        '
        'txtNumJob
        '
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.Location = New System.Drawing.Point(46, 32)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(67, 21)
        Me.txtNumJob.TabIndex = 110
        '
        'txtSolicitante
        '
        Me.txtSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicitante.Location = New System.Drawing.Point(244, 32)
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.Size = New System.Drawing.Size(269, 21)
        Me.txtSolicitante.TabIndex = 107
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(514, 31)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(24, 22)
        Me.btnBuscarPersona.TabIndex = 108
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
        Me.lblPersona.TabIndex = 106
        Me.lblPersona.Text = "Colaborador"
        '
        'cbCalcular25
        '
        Me.cbCalcular25.AutoSize = True
        Me.cbCalcular25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCalcular25.ForeColor = System.Drawing.SystemColors.Desktop
        Me.cbCalcular25.Location = New System.Drawing.Point(12, 132)
        Me.cbCalcular25.Name = "cbCalcular25"
        Me.cbCalcular25.Size = New System.Drawing.Size(111, 19)
        Me.cbCalcular25.TabIndex = 131
        Me.cbCalcular25.Text = "Calcular al 25%"
        Me.cbCalcular25.UseVisualStyleBackColor = True
        '
        'cbCalcular35
        '
        Me.cbCalcular35.AutoSize = True
        Me.cbCalcular35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCalcular35.ForeColor = System.Drawing.SystemColors.Desktop
        Me.cbCalcular35.Location = New System.Drawing.Point(12, 109)
        Me.cbCalcular35.Name = "cbCalcular35"
        Me.cbCalcular35.Size = New System.Drawing.Size(111, 19)
        Me.cbCalcular35.TabIndex = 130
        Me.cbCalcular35.Text = "Calcular al 35%"
        Me.cbCalcular35.UseVisualStyleBackColor = True
        '
        'cbCalcularNormal
        '
        Me.cbCalcularNormal.AutoSize = True
        Me.cbCalcularNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCalcularNormal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.cbCalcularNormal.Location = New System.Drawing.Point(12, 86)
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
        Me.cbCalcular100.Location = New System.Drawing.Point(12, 63)
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
        Me.cbCalcularViaje.Location = New System.Drawing.Point(12, 40)
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
        Me.cbHorarioAsignado.Location = New System.Drawing.Point(12, 17)
        Me.cbHorarioAsignado.Name = "cbHorarioAsignado"
        Me.cbHorarioAsignado.Size = New System.Drawing.Size(159, 19)
        Me.cbHorarioAsignado.TabIndex = 0
        Me.cbHorarioAsignado.Text = "Según Horario Asignado"
        Me.cbHorarioAsignado.UseVisualStyleBackColor = True
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(39, 126)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(41, 15)
        Me.lblFecha.TabIndex = 114
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
        Me.txtFecha.Location = New System.Drawing.Point(16, 147)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(84, 21)
        Me.txtFecha.TabIndex = 113
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtHoraIng
        '
        Me.txtHoraIng.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraIng.Location = New System.Drawing.Point(108, 147)
        Me.txtHoraIng.Name = "txtHoraIng"
        Me.txtHoraIng.Size = New System.Drawing.Size(101, 21)
        Me.txtHoraIng.TabIndex = 115
        '
        'txtHoraSal
        '
        Me.txtHoraSal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraSal.Location = New System.Drawing.Point(217, 147)
        Me.txtHoraSal.Name = "txtHoraSal"
        Me.txtHoraSal.Size = New System.Drawing.Size(101, 21)
        Me.txtHoraSal.TabIndex = 116
        '
        'txtIngReal
        '
        Me.txtIngReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIngReal.Location = New System.Drawing.Point(326, 147)
        Me.txtIngReal.Name = "txtIngReal"
        Me.txtIngReal.Size = New System.Drawing.Size(101, 21)
        Me.txtIngReal.TabIndex = 117
        '
        'txtSalReal
        '
        Me.txtSalReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalReal.Location = New System.Drawing.Point(436, 147)
        Me.txtSalReal.Name = "txtSalReal"
        Me.txtSalReal.Size = New System.Drawing.Size(101, 21)
        Me.txtSalReal.TabIndex = 118
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(91, 179)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(553, 44)
        Me.txtObservacion.TabIndex = 120
        '
        'lblHoraIn
        '
        Me.lblHoraIn.AutoSize = True
        Me.lblHoraIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraIn.Location = New System.Drawing.Point(132, 126)
        Me.lblHoraIn.Name = "lblHoraIn"
        Me.lblHoraIn.Size = New System.Drawing.Size(54, 15)
        Me.lblHoraIn.TabIndex = 121
        Me.lblHoraIn.Text = "Hora Ing"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(239, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Hora Sal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(336, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Hora Ing Real"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(444, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "Hora Sal Real"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 15)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Observación"
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(428, 69)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(85, 21)
        Me.cmbOficinas.TabIndex = 127
        Me.cmbOficinas.Visible = False
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatos_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatos_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatos_DesignTimeLayout_Reference_0})
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
        Me.dgvDatos.Size = New System.Drawing.Size(743, 209)
        Me.dgvDatos.TabIndex = 128
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevo, Me.miModificar})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(126, 48)
        '
        'miNuevo
        '
        Me.miNuevo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevo.Name = "miNuevo"
        Me.miNuevo.Size = New System.Drawing.Size(125, 22)
        Me.miNuevo.Text = "Nuevo"
        '
        'miModificar
        '
        Me.miModificar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miModificar.Name = "miModificar"
        Me.miModificar.Size = New System.Drawing.Size(125, 22)
        Me.miModificar.Text = "Modificar"
        '
        'cmbOficinas1
        '
        Me.cmbOficinas1.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas1_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas1_DesignTimeLayout.LayoutString")
        Me.cmbOficinas1.DesignTimeLayout = cmbOficinas1_DesignTimeLayout
        Me.cmbOficinas1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas1.Location = New System.Drawing.Point(428, 96)
        Me.cmbOficinas1.Name = "cmbOficinas1"
        Me.cmbOficinas1.SelectedIndex = -1
        Me.cmbOficinas1.SelectedItem = Nothing
        Me.cmbOficinas1.Size = New System.Drawing.Size(85, 21)
        Me.cmbOficinas1.TabIndex = 129
        Me.cmbOficinas1.Visible = False
        Me.cmbOficinas1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbOpciones
        '
        Me.gbOpciones.Controls.Add(Me.cbHorarioAsignado)
        Me.gbOpciones.Controls.Add(Me.cbCalcular25)
        Me.gbOpciones.Controls.Add(Me.cbCalcularViaje)
        Me.gbOpciones.Controls.Add(Me.cbCalcular100)
        Me.gbOpciones.Controls.Add(Me.cbCalcularNormal)
        Me.gbOpciones.Controls.Add(Me.cbCalcular35)
        Me.gbOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOpciones.Location = New System.Drawing.Point(557, 13)
        Me.gbOpciones.Name = "gbOpciones"
        Me.gbOpciones.Size = New System.Drawing.Size(180, 158)
        Me.gbOpciones.TabIndex = 132
        Me.gbOpciones.Text = "Opciones"
        Me.gbOpciones.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbDetalles
        '
        Me.gbDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalles.Controls.Add(Me.dgvDatos)
        Me.gbDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalles.Location = New System.Drawing.Point(5, 268)
        Me.gbDetalles.Name = "gbDetalles"
        Me.gbDetalles.Size = New System.Drawing.Size(756, 237)
        Me.gbDetalles.TabIndex = 133
        Me.gbDetalles.Text = "Marcaciones de OT"
        Me.gbDetalles.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.lblHorario)
        Me.UiGroupBox1.Controls.Add(Me.cmbHorario)
        Me.UiGroupBox1.Controls.Add(Me.gbOpciones)
        Me.UiGroupBox1.Controls.Add(Me.cmbOficinas1)
        Me.UiGroupBox1.Controls.Add(Me.cmbOficinas)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.lblHoraIn)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.txtSalReal)
        Me.UiGroupBox1.Controls.Add(Me.txtIngReal)
        Me.UiGroupBox1.Controls.Add(Me.txtHoraSal)
        Me.UiGroupBox1.Controls.Add(Me.txtHoraIng)
        Me.UiGroupBox1.Controls.Add(Me.lblFecha)
        Me.UiGroupBox1.Controls.Add(Me.txtFecha)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarJob)
        Me.UiGroupBox1.Controls.Add(Me.lblNumJob)
        Me.UiGroupBox1.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox1.Controls.Add(Me.txtSolicitante)
        Me.UiGroupBox1.Controls.Add(Me.lblPersona)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPersona)
        Me.UiGroupBox1.Controls.Add(Me.btnGuardar)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 30)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(748, 233)
        Me.UiGroupBox1.TabIndex = 134
        Me.UiGroupBox1.Text = "Datos de Marcación de la OT"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblHorario
        '
        Me.lblHorario.AutoSize = True
        Me.lblHorario.Location = New System.Drawing.Point(13, 82)
        Me.lblHorario.Name = "lblHorario"
        Me.lblHorario.Size = New System.Drawing.Size(112, 15)
        Me.lblHorario.TabIndex = 264
        Me.lblHorario.Text = "Calcular hrs. según"
        Me.lblHorario.Visible = False
        '
        'cmbHorario
        '
        Me.cmbHorario.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbHorario_DesignTimeLayout.LayoutString = resources.GetString("cmbHorario_DesignTimeLayout.LayoutString")
        Me.cmbHorario.DesignTimeLayout = cmbHorario_DesignTimeLayout
        Me.cmbHorario.Location = New System.Drawing.Point(130, 78)
        Me.cmbHorario.Name = "cmbHorario"
        Me.cmbHorario.SelectedIndex = -1
        Me.cmbHorario.SelectedItem = Nothing
        Me.cmbHorario.Size = New System.Drawing.Size(261, 21)
        Me.cmbHorario.TabIndex = 263
        Me.cmbHorario.Visible = False
        Me.cmbHorario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frm_Marcacion_Nuevo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(796, 554)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.gbDetalles)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Marcacion_Nuevo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva Marcación de OT"
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpciones.ResumeLayout(False)
        CType(Me.cmbOficinas1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpciones.ResumeLayout(False)
        Me.gbOpciones.PerformLayout()
        CType(Me.gbDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalles.ResumeLayout(False)
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbHorario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents biNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents txtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents lblPersona As System.Windows.Forms.Label
    Friend WithEvents cbCalcularViaje As System.Windows.Forms.RadioButton
    Friend WithEvents cbHorarioAsignado As System.Windows.Forms.RadioButton
    Friend WithEvents cbCalcular100 As System.Windows.Forms.RadioButton
    Friend WithEvents txtSalReal As System.Windows.Forms.TextBox
    Friend WithEvents txtIngReal As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraSal As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraIng As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblHoraIn As System.Windows.Forms.Label
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents biVerHoras As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cbCalcularNormal As System.Windows.Forms.RadioButton
    Friend WithEvents cmbOficinas1 As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbCalcular35 As System.Windows.Forms.RadioButton
    Friend WithEvents cbCalcular25 As System.Windows.Forms.RadioButton
    Friend WithEvents gbOpciones As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbDetalles As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblHorario As System.Windows.Forms.Label
    Friend WithEvents cmbHorario As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
