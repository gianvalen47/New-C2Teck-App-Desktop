<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReclamoCliente
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
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReclamoCliente))
        Dim cmbSupervisor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbEstadoGarantia = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecFinGarantia = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbEnGarantia = New System.Windows.Forms.CheckBox()
        Me.gbAcciones = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbDevLlamada = New System.Windows.Forms.CheckBox()
        Me.cbSumRepuestos = New System.Windows.Forms.CheckBox()
        Me.cbAteTecnico = New System.Windows.Forms.CheckBox()
        Me.txtTotalHoras = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSupervisor = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEnsayoPrimario = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtComponentes = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCausa = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtProblema = New System.Windows.Forms.TextBox()
        Me.txtLugarServicio = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.gbMotor = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtModMotor = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSerieMotor = New System.Windows.Forms.TextBox()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbCliente = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbEstadoGarantia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstadoGarantia.SuspendLayout()
        CType(Me.gbAcciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAcciones.SuspendLayout()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbMotor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMotor.SuspendLayout()
        CType(Me.cbCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cbCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.gbEstadoGarantia)
        Me.UiGroupBox1.Controls.Add(Me.gbAcciones)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalHoras)
        Me.UiGroupBox1.Controls.Add(Me.lblTotal)
        Me.UiGroupBox1.Controls.Add(Me.gbEstado)
        Me.UiGroupBox1.Controls.Add(Me.cmbUnidad)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.cmbSupervisor)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtEnsayoPrimario)
        Me.UiGroupBox1.Controls.Add(Me.Label18)
        Me.UiGroupBox1.Controls.Add(Me.txtComponentes)
        Me.UiGroupBox1.Controls.Add(Me.Label15)
        Me.UiGroupBox1.Controls.Add(Me.txtCausa)
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.txtProblema)
        Me.UiGroupBox1.Controls.Add(Me.txtLugarServicio)
        Me.UiGroupBox1.Controls.Add(Me.Label32)
        Me.UiGroupBox1.Controls.Add(Me.gbMotor)
        Me.UiGroupBox1.Controls.Add(Me.txtFecha)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.cbCliente)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(669, 470)
        Me.UiGroupBox1.TabIndex = 0
        Me.UiGroupBox1.Text = "Datos del Reclamo de Cliente"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbEstadoGarantia
        '
        Me.gbEstadoGarantia.Controls.Add(Me.txtFecFinGarantia)
        Me.gbEstadoGarantia.Controls.Add(Me.Label9)
        Me.gbEstadoGarantia.Controls.Add(Me.cbEnGarantia)
        Me.gbEstadoGarantia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEstadoGarantia.Location = New System.Drawing.Point(12, 416)
        Me.gbEstadoGarantia.Name = "gbEstadoGarantia"
        Me.gbEstadoGarantia.Size = New System.Drawing.Size(353, 43)
        Me.gbEstadoGarantia.TabIndex = 20
        Me.gbEstadoGarantia.Text = "Estado de garantía"
        Me.gbEstadoGarantia.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFecFinGarantia
        '
        '
        '
        '
        Me.txtFecFinGarantia.DropDownCalendar.Name = ""
        Me.txtFecFinGarantia.DropDownCalendar.Visible = False
        Me.txtFecFinGarantia.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinGarantia.IsNullDate = True
        Me.txtFecFinGarantia.Location = New System.Drawing.Point(245, 16)
        Me.txtFecFinGarantia.Name = "txtFecFinGarantia"
        Me.txtFecFinGarantia.Size = New System.Drawing.Size(94, 20)
        Me.txtFecFinGarantia.TabIndex = 22
        Me.txtFecFinGarantia.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(135, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 13)
        Me.Label9.TabIndex = 326
        Me.Label9.Text = "Fec. Fin Garantía"
        '
        'cbEnGarantia
        '
        Me.cbEnGarantia.AutoSize = True
        Me.cbEnGarantia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbEnGarantia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEnGarantia.Location = New System.Drawing.Point(15, 19)
        Me.cbEnGarantia.Name = "cbEnGarantia"
        Me.cbEnGarantia.Size = New System.Drawing.Size(95, 17)
        Me.cbEnGarantia.TabIndex = 21
        Me.cbEnGarantia.Text = "En Garantía"
        Me.cbEnGarantia.UseVisualStyleBackColor = True
        '
        'gbAcciones
        '
        Me.gbAcciones.Controls.Add(Me.cbDevLlamada)
        Me.gbAcciones.Controls.Add(Me.cbSumRepuestos)
        Me.gbAcciones.Controls.Add(Me.cbAteTecnico)
        Me.gbAcciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAcciones.Location = New System.Drawing.Point(12, 316)
        Me.gbAcciones.Name = "gbAcciones"
        Me.gbAcciones.Size = New System.Drawing.Size(647, 43)
        Me.gbAcciones.TabIndex = 15
        Me.gbAcciones.Text = "Acciones requeridas por el cliente"
        Me.gbAcciones.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbDevLlamada
        '
        Me.cbDevLlamada.AutoSize = True
        Me.cbDevLlamada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbDevLlamada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDevLlamada.Location = New System.Drawing.Point(26, 19)
        Me.cbDevLlamada.Name = "cbDevLlamada"
        Me.cbDevLlamada.Size = New System.Drawing.Size(138, 17)
        Me.cbDevLlamada.TabIndex = 16
        Me.cbDevLlamada.Text = "Devolver la llamada"
        Me.cbDevLlamada.UseVisualStyleBackColor = True
        '
        'cbSumRepuestos
        '
        Me.cbSumRepuestos.AutoSize = True
        Me.cbSumRepuestos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbSumRepuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSumRepuestos.Location = New System.Drawing.Point(241, 19)
        Me.cbSumRepuestos.Name = "cbSumRepuestos"
        Me.cbSumRepuestos.Size = New System.Drawing.Size(147, 17)
        Me.cbSumRepuestos.TabIndex = 17
        Me.cbSumRepuestos.Text = "Suministrar repuestos"
        Me.cbSumRepuestos.UseVisualStyleBackColor = True
        '
        'cbAteTecnico
        '
        Me.cbAteTecnico.AutoSize = True
        Me.cbAteTecnico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAteTecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAteTecnico.Location = New System.Drawing.Point(457, 19)
        Me.cbAteTecnico.Name = "cbAteTecnico"
        Me.cbAteTecnico.Size = New System.Drawing.Size(158, 17)
        Me.cbAteTecnico.TabIndex = 18
        Me.cbAteTecnico.Text = "Atención por el técnico"
        Me.cbAteTecnico.UseVisualStyleBackColor = True
        '
        'txtTotalHoras
        '
        Me.txtTotalHoras.DecimalDigits = 3
        Me.txtTotalHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHoras.Location = New System.Drawing.Point(519, 60)
        Me.txtTotalHoras.MaxLength = 10
        Me.txtTotalHoras.Name = "txtTotalHoras"
        Me.txtTotalHoras.Size = New System.Drawing.Size(75, 20)
        Me.txtTotalHoras.TabIndex = 6
        Me.txtTotalHoras.Text = "0.000"
        Me.txtTotalHoras.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtTotalHoras.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(424, 64)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(92, 13)
        Me.lblTotal.TabIndex = 306
        Me.lblTotal.Text = "Horas actuales"
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.Color.Transparent
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(477, 8)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(183, 40)
        Me.gbEstado.TabIndex = 0
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(6, 10)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(171, 26)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Location = New System.Drawing.Point(596, 60)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.ReadOnly = True
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(63, 20)
        Me.cmbUnidad.TabIndex = 7
        Me.cmbUnidad.TabStop = False
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(380, 436)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 321
        Me.Label3.Text = "Supervisor"
        '
        'cmbSupervisor
        '
        Me.cmbSupervisor.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbSupervisor_DesignTimeLayout.LayoutString = resources.GetString("cmbSupervisor_DesignTimeLayout.LayoutString")
        Me.cmbSupervisor.DesignTimeLayout = cmbSupervisor_DesignTimeLayout
        Me.cmbSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSupervisor.Location = New System.Drawing.Point(452, 432)
        Me.cmbSupervisor.Name = "cmbSupervisor"
        Me.cmbSupervisor.SelectedIndex = -1
        Me.cmbSupervisor.SelectedItem = Nothing
        Me.cmbSupervisor.Size = New System.Drawing.Size(207, 20)
        Me.cmbSupervisor.TabIndex = 23
        Me.cmbSupervisor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 385)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 317
        Me.Label2.Text = "Ensayo primario"
        '
        'txtEnsayoPrimario
        '
        Me.txtEnsayoPrimario.Location = New System.Drawing.Point(117, 369)
        Me.txtEnsayoPrimario.MaxLength = 327670000
        Me.txtEnsayoPrimario.Multiline = True
        Me.txtEnsayoPrimario.Name = "txtEnsayoPrimario"
        Me.txtEnsayoPrimario.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEnsayoPrimario.Size = New System.Drawing.Size(542, 43)
        Me.txtEnsayoPrimario.TabIndex = 19
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(13, 252)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(149, 55)
        Me.Label18.TabIndex = 312
        Me.Label18.Text = "Decripción de los componentes con la indicación mas exacta posible del lugar"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComponentes
        '
        Me.txtComponentes.Location = New System.Drawing.Point(162, 251)
        Me.txtComponentes.MaxLength = 327670000
        Me.txtComponentes.Multiline = True
        Me.txtComponentes.Name = "txtComponentes"
        Me.txtComponentes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComponentes.Size = New System.Drawing.Size(497, 59)
        Me.txtComponentes.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 198)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(149, 43)
        Me.Label15.TabIndex = 311
        Me.Label15.Text = "Condición del servicio en las que se presentan las causas de reclamo"
        '
        'txtCausa
        '
        Me.txtCausa.Location = New System.Drawing.Point(162, 195)
        Me.txtCausa.MaxLength = 327670000
        Me.txtCausa.Multiline = True
        Me.txtCausa.Name = "txtCausa"
        Me.txtCausa.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCausa.Size = New System.Drawing.Size(497, 50)
        Me.txtCausa.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 153)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(149, 29)
        Me.Label11.TabIndex = 310
        Me.Label11.Text = "Reclamo / percepción del Cliente"
        '
        'txtProblema
        '
        Me.txtProblema.Location = New System.Drawing.Point(162, 146)
        Me.txtProblema.MaxLength = 327670000
        Me.txtProblema.Multiline = True
        Me.txtProblema.Name = "txtProblema"
        Me.txtProblema.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtProblema.Size = New System.Drawing.Size(497, 43)
        Me.txtProblema.TabIndex = 12
        '
        'txtLugarServicio
        '
        Me.txtLugarServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLugarServicio.Location = New System.Drawing.Point(108, 21)
        Me.txtLugarServicio.Name = "txtLugarServicio"
        Me.txtLugarServicio.Size = New System.Drawing.Size(204, 20)
        Me.txtLugarServicio.TabIndex = 1
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(13, 25)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(89, 13)
        Me.Label32.TabIndex = 303
        Me.Label32.Text = "Lugar Servicio"
        '
        'gbMotor
        '
        Me.gbMotor.Controls.Add(Me.txtModMotor)
        Me.gbMotor.Controls.Add(Me.Label13)
        Me.gbMotor.Controls.Add(Me.txtSerieMotor)
        Me.gbMotor.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbMotor.Controls.Add(Me.Label12)
        Me.gbMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMotor.Location = New System.Drawing.Point(12, 94)
        Me.gbMotor.Name = "gbMotor"
        Me.gbMotor.Size = New System.Drawing.Size(647, 43)
        Me.gbMotor.TabIndex = 8
        Me.gbMotor.Text = "Datos de Motor"
        Me.gbMotor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtModMotor
        '
        Me.txtModMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModMotor.Location = New System.Drawing.Point(397, 16)
        Me.txtModMotor.Name = "txtModMotor"
        Me.txtModMotor.Size = New System.Drawing.Size(243, 20)
        Me.txtModMotor.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(342, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 13)
        Me.Label13.TabIndex = 235
        Me.Label13.Text = "Modelo"
        '
        'txtSerieMotor
        '
        Me.txtSerieMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieMotor.Location = New System.Drawing.Point(61, 16)
        Me.txtSerieMotor.Name = "txtSerieMotor"
        Me.txtSerieMotor.Size = New System.Drawing.Size(201, 20)
        Me.txtSerieMotor.TabIndex = 9
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarMercaderia.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(264, 16)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarMercaderia.TabIndex = 10
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 233
        Me.Label12.Text = "Serie"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Location = New System.Drawing.Point(371, 21)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(91, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(323, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 300
        Me.Label7.Text = "Fecha"
        '
        'cbCliente
        '
        Me.cbCliente.Controls.Add(Me.Label1)
        Me.cbCliente.Controls.Add(Me.btnBuscarCliente)
        Me.cbCliente.Controls.Add(Me.txtCliente)
        Me.cbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCliente.Location = New System.Drawing.Point(12, 45)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(398, 43)
        Me.cbCliente.TabIndex = 3
        Me.cbCliente.Text = "Datos del Cliente"
        Me.cbCliente.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Cliente"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(366, 14)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 23)
        Me.btnBuscarCliente.TabIndex = 5
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.Control
        Me.txtCliente.Location = New System.Drawing.Point(61, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(304, 20)
        Me.txtCliente.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(345, 481)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 28)
        Me.btnCancelar.TabIndex = 25
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(261, 481)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 28)
        Me.btnGuardar.TabIndex = 24
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmReclamoCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(687, 516)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReclamoCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReclamoCliente"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.gbEstadoGarantia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstadoGarantia.ResumeLayout(False)
        Me.gbEstadoGarantia.PerformLayout()
        CType(Me.gbAcciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAcciones.ResumeLayout(False)
        Me.gbAcciones.PerformLayout()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbSupervisor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbMotor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMotor.ResumeLayout(False)
        Me.gbMotor.PerformLayout()
        CType(Me.cbCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cbCliente.ResumeLayout(False)
        Me.cbCliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbEstadoGarantia As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbEnGarantia As System.Windows.Forms.CheckBox
    Friend WithEvents gbAcciones As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbDevLlamada As System.Windows.Forms.CheckBox
    Friend WithEvents cbSumRepuestos As System.Windows.Forms.CheckBox
    Friend WithEvents cbAteTecnico As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotalHoras As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbSupervisor As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEnsayoPrimario As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtComponentes As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCausa As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtProblema As System.Windows.Forms.TextBox
    Friend WithEvents txtLugarServicio As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents gbMotor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtModMotor As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSerieMotor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbCliente As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtFecFinGarantia As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
