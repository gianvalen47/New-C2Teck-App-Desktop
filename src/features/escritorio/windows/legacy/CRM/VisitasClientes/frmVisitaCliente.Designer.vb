<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitaCliente
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
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoVisita_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbIdContacto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoCancelacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisitaCliente))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.gbGastoViaje = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnAgregarContacto = New Janus.Windows.EditControls.UIButton()
        Me.txtPersona = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtObjetivos = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.gbEjecutado = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtResultados = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLugar = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTemas = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOportunidad = New System.Windows.Forms.TextBox()
        Me.btnBuscarOportunidad = New System.Windows.Forms.Button()
        Me.cbEjecutado = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipoVisita = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbIdContacto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.gbEstado = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbTipoCancelacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbCancelacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGastoViaje.SuspendLayout()
        CType(Me.gbEjecutado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEjecutado.SuspendLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoVisita, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbTipoCancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCancelacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'lblObservacion
        '
        Me.lblObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacion.Location = New System.Drawing.Point(9, 100)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(119, 43)
        Me.lblObservacion.TabIndex = 11
        Me.lblObservacion.Text = "Entregable / Tareas a entregar para cerrar la venta"
        Me.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbGastoViaje
        '
        Me.gbGastoViaje.Controls.Add(Me.btnAgregarContacto)
        Me.gbGastoViaje.Controls.Add(Me.txtPersona)
        Me.gbGastoViaje.Controls.Add(Me.Label7)
        Me.gbGastoViaje.Controls.Add(Me.txtObjetivos)
        Me.gbGastoViaje.Controls.Add(Me.Label8)
        Me.gbGastoViaje.Controls.Add(Me.btnBuscarPersona)
        Me.gbGastoViaje.Controls.Add(Me.gbEjecutado)
        Me.gbGastoViaje.Controls.Add(Me.Label5)
        Me.gbGastoViaje.Controls.Add(Me.txtOportunidad)
        Me.gbGastoViaje.Controls.Add(Me.btnBuscarOportunidad)
        Me.gbGastoViaje.Controls.Add(Me.cbEjecutado)
        Me.gbGastoViaje.Controls.Add(Me.Label6)
        Me.gbGastoViaje.Controls.Add(Me.cmbUnidad)
        Me.gbGastoViaje.Controls.Add(Me.Label3)
        Me.gbGastoViaje.Controls.Add(Me.cmbTipoVisita)
        Me.gbGastoViaje.Controls.Add(Me.cmbIdContacto)
        Me.gbGastoViaje.Controls.Add(Me.Label1)
        Me.gbGastoViaje.Controls.Add(Me.txtCliente)
        Me.gbGastoViaje.Controls.Add(Me.btnBuscarCliente)
        Me.gbGastoViaje.Controls.Add(Me.Label12)
        Me.gbGastoViaje.Controls.Add(Me.lblFecha)
        Me.gbGastoViaje.Controls.Add(Me.txtFecha)
        Me.gbGastoViaje.Controls.Add(Me.gbEstado)
        Me.gbGastoViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGastoViaje.Location = New System.Drawing.Point(6, 3)
        Me.gbGastoViaje.Name = "gbGastoViaje"
        Me.gbGastoViaje.Size = New System.Drawing.Size(627, 341)
        Me.gbGastoViaje.TabIndex = 1
        Me.gbGastoViaje.Text = "Datos Generales"
        Me.gbGastoViaje.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'btnAgregarContacto
        '
        Me.btnAgregarContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarContacto.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnAgregarContacto.Location = New System.Drawing.Point(397, 52)
        Me.btnAgregarContacto.Name = "btnAgregarContacto"
        Me.btnAgregarContacto.Size = New System.Drawing.Size(23, 22)
        Me.btnAgregarContacto.TabIndex = 282
        Me.btnAgregarContacto.TabStop = False
        '
        'txtPersona
        '
        Me.txtPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersona.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersona.Location = New System.Drawing.Point(347, 84)
        Me.txtPersona.MaxLength = 3
        Me.txtPersona.Name = "txtPersona"
        Me.txtPersona.ReadOnly = True
        Me.txtPersona.Size = New System.Drawing.Size(244, 20)
        Me.txtPersona.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(271, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 281
        Me.Label7.Text = "Colaborador"
        '
        'txtObjetivos
        '
        Me.txtObjetivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObjetivos.Location = New System.Drawing.Point(96, 147)
        Me.txtObjetivos.Multiline = True
        Me.txtObjetivos.Name = "txtObjetivos"
        Me.txtObjetivos.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObjetivos.Size = New System.Drawing.Size(520, 32)
        Me.txtObjetivos.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 26)
        Me.Label8.TabIndex = 278
        Me.Label8.Text = "Objetivos de la visita"
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(591, 83)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersona.TabIndex = 8
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'gbEjecutado
        '
        Me.gbEjecutado.Controls.Add(Me.txtHora)
        Me.gbEjecutado.Controls.Add(Me.Label10)
        Me.gbEjecutado.Controls.Add(Me.txtResultados)
        Me.gbEjecutado.Controls.Add(Me.Label9)
        Me.gbEjecutado.Controls.Add(Me.txtLugar)
        Me.gbEjecutado.Controls.Add(Me.Label4)
        Me.gbEjecutado.Controls.Add(Me.txtTemas)
        Me.gbEjecutado.Controls.Add(Me.lblObservacion)
        Me.gbEjecutado.Enabled = False
        Me.gbEjecutado.Location = New System.Drawing.Point(6, 181)
        Me.gbEjecutado.Name = "gbEjecutado"
        Me.gbEjecutado.Size = New System.Drawing.Size(615, 153)
        Me.gbEjecutado.TabIndex = 12
        Me.gbEjecutado.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'txtHora
        '
        Me.txtHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.Location = New System.Drawing.Point(90, 44)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(513, 20)
        Me.txtHora.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 282
        Me.Label10.Text = "Horario"
        '
        'txtResultados
        '
        Me.txtResultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResultados.Location = New System.Drawing.Point(90, 72)
        Me.txtResultados.Name = "txtResultados"
        Me.txtResultados.Size = New System.Drawing.Size(513, 20)
        Me.txtResultados.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 280
        Me.Label9.Text = "Resultados"
        '
        'txtLugar
        '
        Me.txtLugar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLugar.Location = New System.Drawing.Point(90, 16)
        Me.txtLugar.Name = "txtLugar"
        Me.txtLugar.Size = New System.Drawing.Size(513, 20)
        Me.txtLugar.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 276
        Me.Label4.Text = "Lugar"
        '
        'txtTemas
        '
        Me.txtTemas.AcceptsTab = True
        Me.txtTemas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTemas.Location = New System.Drawing.Point(134, 100)
        Me.txtTemas.Multiline = True
        Me.txtTemas.Name = "txtTemas"
        Me.txtTemas.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTemas.Size = New System.Drawing.Size(469, 43)
        Me.txtTemas.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 28)
        Me.Label5.TabIndex = 280
        Me.Label5.Text = "Oportunidad Negocio"
        '
        'txtOportunidad
        '
        Me.txtOportunidad.BackColor = System.Drawing.SystemColors.Control
        Me.txtOportunidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOportunidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOportunidad.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtOportunidad.Location = New System.Drawing.Point(96, 116)
        Me.txtOportunidad.MaxLength = 3
        Me.txtOportunidad.Name = "txtOportunidad"
        Me.txtOportunidad.ReadOnly = True
        Me.txtOportunidad.Size = New System.Drawing.Size(351, 20)
        Me.txtOportunidad.TabIndex = 8
        Me.txtOportunidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBuscarOportunidad
        '
        Me.btnBuscarOportunidad.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarOportunidad.Location = New System.Drawing.Point(448, 114)
        Me.btnBuscarOportunidad.Name = "btnBuscarOportunidad"
        Me.btnBuscarOportunidad.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarOportunidad.TabIndex = 9
        Me.btnBuscarOportunidad.TabStop = False
        Me.btnBuscarOportunidad.UseVisualStyleBackColor = True
        '
        'cbEjecutado
        '
        Me.cbEjecutado.AutoSize = True
        Me.cbEjecutado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbEjecutado.Location = New System.Drawing.Point(510, 118)
        Me.cbEjecutado.Name = "cbEjecutado"
        Me.cbEjecutado.Size = New System.Drawing.Size(83, 17)
        Me.cbEjecutado.TabIndex = 10
        Me.cbEjecutado.Text = "Ejecutado"
        Me.cbEjecutado.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 268
        Me.Label6.Text = "Unidad Neg."
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(96, 84)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(150, 20)
        Me.cmbUnidad.TabIndex = 6
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(441, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Tipo"
        '
        'cmbTipoVisita
        '
        Me.cmbTipoVisita.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoVisita_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoVisita_DesignTimeLayout.LayoutString")
        Me.cmbTipoVisita.DesignTimeLayout = cmbTipoVisita_DesignTimeLayout
        Me.cmbTipoVisita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoVisita.Location = New System.Drawing.Point(479, 52)
        Me.cmbTipoVisita.Name = "cmbTipoVisita"
        Me.cmbTipoVisita.SelectedIndex = -1
        Me.cmbTipoVisita.SelectedItem = Nothing
        Me.cmbTipoVisita.Size = New System.Drawing.Size(137, 20)
        Me.cmbTipoVisita.TabIndex = 5
        Me.cmbTipoVisita.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbIdContacto
        '
        Me.cmbIdContacto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdContacto_DesignTimeLayout.LayoutString = resources.GetString("cmbIdContacto_DesignTimeLayout.LayoutString")
        Me.cmbIdContacto.DesignTimeLayout = cmbIdContacto_DesignTimeLayout
        Me.cmbIdContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdContacto.Location = New System.Drawing.Point(272, 53)
        Me.cmbIdContacto.Name = "cmbIdContacto"
        Me.cmbIdContacto.SelectedIndex = -1
        Me.cmbIdContacto.SelectedItem = Nothing
        Me.cmbIdContacto.Size = New System.Drawing.Size(124, 20)
        Me.cmbIdContacto.TabIndex = 4
        Me.cmbIdContacto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(211, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Contacto"
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtCliente.Location = New System.Drawing.Point(96, 21)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(315, 20)
        Me.txtCliente.TabIndex = 1
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.Location = New System.Drawing.Point(412, 19)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 2
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Cliente"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(12, 57)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 27
        Me.lblFecha.Text = "Fecha"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(96, 53)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(91, 20)
        Me.txtFecha.TabIndex = 3
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(475, 10)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(141, 32)
        Me.gbEstado.TabIndex = 28
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(11, 11)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(117, 16)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbTipoCancelacion
        '
        Me.cmbTipoCancelacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoCancelacion_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoCancelacion_DesignTimeLayout.LayoutString")
        Me.cmbTipoCancelacion.DesignTimeLayout = cmbTipoCancelacion_DesignTimeLayout
        Me.cmbTipoCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCancelacion.Location = New System.Drawing.Point(125, 16)
        Me.cmbTipoCancelacion.Name = "cmbTipoCancelacion"
        Me.cmbTipoCancelacion.SelectedIndex = -1
        Me.cmbTipoCancelacion.SelectedItem = Nothing
        Me.cmbTipoCancelacion.Size = New System.Drawing.Size(162, 20)
        Me.cmbTipoCancelacion.TabIndex = 18
        Me.cmbTipoCancelacion.TabStop = False
        Me.cmbTipoCancelacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 278
        Me.Label2.Text = "Tipo Cancelación"
        '
        'gbCancelacion
        '
        Me.gbCancelacion.Controls.Add(Me.cmbTipoCancelacion)
        Me.gbCancelacion.Controls.Add(Me.Label2)
        Me.gbCancelacion.Location = New System.Drawing.Point(6, 347)
        Me.gbCancelacion.Name = "gbCancelacion"
        Me.gbCancelacion.Size = New System.Drawing.Size(627, 46)
        Me.gbCancelacion.TabIndex = 17
        Me.gbCancelacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(322, 398)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 28)
        Me.btnCancelar.TabIndex = 281
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
        Me.btnGuardar.Location = New System.Drawing.Point(238, 398)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 28)
        Me.btnGuardar.TabIndex = 19
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmVisitaCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(639, 432)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbCancelacion)
        Me.Controls.Add(Me.gbGastoViaje)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVisitaCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registrar Visita al Cliente"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGastoViaje.ResumeLayout(False)
        Me.gbGastoViaje.PerformLayout()
        CType(Me.gbEjecutado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEjecutado.ResumeLayout(False)
        Me.gbEjecutado.PerformLayout()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoVisita, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.cmbTipoCancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCancelacion.ResumeLayout(False)
        Me.gbCancelacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents gbGastoViaje As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTipoVisita As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbIdContacto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents btnBuscarCliente As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbEstado As GroupBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents txtTemas As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLugar As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbTipoCancelacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbEjecutado As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtOportunidad As TextBox
    Friend WithEvents btnBuscarOportunidad As Button
    Friend WithEvents gbEjecutado As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbCancelacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents txtPersona As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents txtObjetivos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtResultados As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarContacto As Janus.Windows.EditControls.UIButton
End Class
