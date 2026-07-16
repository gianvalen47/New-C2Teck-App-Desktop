<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVistaCliente
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
        Dim cmbIdContacto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbIdPer_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbIdTipoVisita_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbGruVen_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbMotivo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbResultado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVistaCliente))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox
        Me.gbEstado = New System.Windows.Forms.GroupBox
        Me.lblEstado = New System.Windows.Forms.Label
        Me.cmbIdContacto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbIdPer = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbIdTipoVisita = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.lblFecha = New System.Windows.Forms.Label
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbGruVen = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblResultado = New System.Windows.Forms.Label
        Me.lblMotivo = New System.Windows.Forms.Label
        Me.cmbMotivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbResultado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtObservacion = New System.Windows.Forms.TextBox
        Me.lblObservacion = New System.Windows.Forms.Label
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator101 = New System.Windows.Forms.ToolStripSeparator
        Me.biEditar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator104 = New System.Windows.Forms.ToolStripSeparator
        Me.biGuardar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator107 = New System.Windows.Forms.ToolStripSeparator
        Me.biDeshacer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.gbDetalle = New System.Windows.Forms.GroupBox
        Me.ssBarra = New System.Windows.Forms.StatusStrip
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        Me.gbEstado.SuspendLayout()
        CType(Me.cmbIdContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdPer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdTipoVisita, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbGruVen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.gbDetalle.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.gbEstado)
        Me.gbDatos.Controls.Add(Me.cmbIdContacto)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.cmbIdPer)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.Label14)
        Me.gbDatos.Controls.Add(Me.cmbIdTipoVisita)
        Me.gbDatos.Controls.Add(Me.lblFecha)
        Me.gbDatos.Controls.Add(Me.txtFecha)
        Me.gbDatos.Controls.Add(Me.txtCliente)
        Me.gbDatos.Controls.Add(Me.btnBuscarCliente)
        Me.gbDatos.Controls.Add(Me.Label12)
        Me.gbDatos.Controls.Add(Me.cmbGruVen)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(3, 37)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(727, 96)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.Text = "Datos Generales"
        '
        'gbEstado
        '
        Me.gbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbEstado.Controls.Add(Me.lblEstado)
        Me.gbEstado.Location = New System.Drawing.Point(553, 8)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(164, 28)
        Me.gbEstado.TabIndex = 25
        Me.gbEstado.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblEstado.Location = New System.Drawing.Point(13, 10)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(136, 16)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbIdContacto
        '
        Me.cmbIdContacto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdContacto_DesignTimeLayout.LayoutString = resources.GetString("cmbIdContacto_DesignTimeLayout.LayoutString")
        Me.cmbIdContacto.DesignTimeLayout = cmbIdContacto_DesignTimeLayout
        Me.cmbIdContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdContacto.Location = New System.Drawing.Point(79, 39)
        Me.cmbIdContacto.Name = "cmbIdContacto"
        Me.cmbIdContacto.SelectedIndex = -1
        Me.cmbIdContacto.SelectedItem = Nothing
        Me.cmbIdContacto.Size = New System.Drawing.Size(286, 20)
        Me.cmbIdContacto.TabIndex = 3
        Me.cmbIdContacto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Contacto"
        '
        'cmbIdPer
        '
        Me.cmbIdPer.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdPer_DesignTimeLayout.LayoutString = resources.GetString("cmbIdPer_DesignTimeLayout.LayoutString")
        Me.cmbIdPer.DesignTimeLayout = cmbIdPer_DesignTimeLayout
        Me.cmbIdPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdPer.Location = New System.Drawing.Point(461, 61)
        Me.cmbIdPer.Name = "cmbIdPer"
        Me.cmbIdPer.SelectedIndex = -1
        Me.cmbIdPer.SelectedItem = Nothing
        Me.cmbIdPer.Size = New System.Drawing.Size(261, 20)
        Me.cmbIdPer.TabIndex = 6
        Me.cmbIdPer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Tipo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(400, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Vendedor"
        '
        'cmbIdTipoVisita
        '
        Me.cmbIdTipoVisita.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdTipoVisita_DesignTimeLayout.LayoutString = resources.GetString("cmbIdTipoVisita_DesignTimeLayout.LayoutString")
        Me.cmbIdTipoVisita.DesignTimeLayout = cmbIdTipoVisita_DesignTimeLayout
        Me.cmbIdTipoVisita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdTipoVisita.Location = New System.Drawing.Point(79, 61)
        Me.cmbIdTipoVisita.Name = "cmbIdTipoVisita"
        Me.cmbIdTipoVisita.SelectedIndex = -1
        Me.cmbIdTipoVisita.SelectedItem = Nothing
        Me.cmbIdTipoVisita.Size = New System.Drawing.Size(286, 20)
        Me.cmbIdTipoVisita.TabIndex = 5
        Me.cmbIdTipoVisita.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(403, 21)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(42, 13)
        Me.lblFecha.TabIndex = 12
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
        Me.txtFecha.Location = New System.Drawing.Point(446, 17)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(90, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtCliente.Location = New System.Drawing.Point(79, 17)
        Me.txtCliente.MaxLength = 3
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(286, 20)
        Me.txtCliente.TabIndex = 0
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(365, 16)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCliente.TabIndex = 1
        Me.btnBuscarCliente.TabStop = False
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Cliente"
        '
        'cmbGruVen
        '
        Me.cmbGruVen.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbGruVen_DesignTimeLayout.LayoutString = resources.GetString("cmbGruVen_DesignTimeLayout.LayoutString")
        Me.cmbGruVen.DesignTimeLayout = cmbGruVen_DesignTimeLayout
        Me.cmbGruVen.Location = New System.Drawing.Point(461, 39)
        Me.cmbGruVen.Name = "cmbGruVen"
        Me.cmbGruVen.SelectedIndex = -1
        Me.cmbGruVen.SelectedItem = Nothing
        Me.cmbGruVen.Size = New System.Drawing.Size(185, 20)
        Me.cmbGruVen.TabIndex = 4
        Me.cmbGruVen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(414, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Grupo"
        '
        'lblResultado
        '
        Me.lblResultado.AutoSize = True
        Me.lblResultado.Location = New System.Drawing.Point(4, 20)
        Me.lblResultado.Name = "lblResultado"
        Me.lblResultado.Size = New System.Drawing.Size(64, 13)
        Me.lblResultado.TabIndex = 18
        Me.lblResultado.Text = "Resultado"
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(0, 43)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(75, 13)
        Me.lblMotivo.TabIndex = 17
        Me.lblMotivo.Text = "Motivo Can."
        '
        'cmbMotivo
        '
        Me.cmbMotivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMotivo_DesignTimeLayout.LayoutString = resources.GetString("cmbMotivo_DesignTimeLayout.LayoutString")
        Me.cmbMotivo.DesignTimeLayout = cmbMotivo_DesignTimeLayout
        Me.cmbMotivo.Location = New System.Drawing.Point(79, 39)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.SelectedIndex = -1
        Me.cmbMotivo.SelectedItem = Nothing
        Me.cmbMotivo.Size = New System.Drawing.Size(212, 20)
        Me.cmbMotivo.TabIndex = 8
        Me.cmbMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbResultado
        '
        Me.cmbResultado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbResultado_DesignTimeLayout.LayoutString = resources.GetString("cmbResultado_DesignTimeLayout.LayoutString")
        Me.cmbResultado.DesignTimeLayout = cmbResultado_DesignTimeLayout
        Me.cmbResultado.Location = New System.Drawing.Point(79, 16)
        Me.cmbResultado.Name = "cmbResultado"
        Me.cmbResultado.SelectedIndex = -1
        Me.cmbResultado.SelectedItem = Nothing
        Me.cmbResultado.Size = New System.Drawing.Size(185, 20)
        Me.cmbResultado.TabIndex = 7
        Me.cmbResultado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtObservacion
        '
        Me.txtObservacion.AcceptsTab = True
        Me.txtObservacion.Location = New System.Drawing.Point(80, 62)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(642, 105)
        Me.txtObservacion.TabIndex = 9
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.Location = New System.Drawing.Point(-1, 65)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(78, 13)
        Me.lblObservacion.TabIndex = 11
        Me.lblObservacion.Text = "Observación"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator101, Me.biEditar, Me.ToolStripSeparator104, Me.biGuardar, Me.ToolStripSeparator107, Me.biDeshacer, Me.ToolStripSeparator1, Me.biSalir, Me.ToolStripSeparator2})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(734, 31)
        Me.ToolStrip.TabIndex = 111
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator101
        '
        Me.ToolStripSeparator101.Name = "ToolStripSeparator101"
        Me.ToolStripSeparator101.Size = New System.Drawing.Size(6, 31)
        '
        'biEditar
        '
        Me.biEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar Resultado/Observación"
        '
        'ToolStripSeparator104
        '
        Me.ToolStripSeparator104.Name = "ToolStripSeparator104"
        Me.ToolStripSeparator104.Size = New System.Drawing.Size(6, 31)
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Guardar los Cambios Realizados"
        '
        'ToolStripSeparator107
        '
        Me.ToolStripSeparator107.Name = "ToolStripSeparator107"
        Me.ToolStripSeparator107.Size = New System.Drawing.Size(6, 31)
        '
        'biDeshacer
        '
        Me.biDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.biDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.Text = "Deshacer los Cambios Realizados"
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
        Me.biSalir.Text = "Salir del Formulario"
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.cmbResultado)
        Me.gbDetalle.Controls.Add(Me.lblResultado)
        Me.gbDetalle.Controls.Add(Me.lblObservacion)
        Me.gbDetalle.Controls.Add(Me.lblMotivo)
        Me.gbDetalle.Controls.Add(Me.txtObservacion)
        Me.gbDetalle.Controls.Add(Me.cmbMotivo)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(3, 144)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(728, 178)
        Me.gbDetalle.TabIndex = 112
        Me.gbDetalle.TabStop = False
        Me.gbDetalle.Text = "Datos Visita"
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 326)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(734, 20)
        Me.ssBarra.TabIndex = 113
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(500, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'frmVistaCliente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(734, 346)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.gbDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVistaCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registrar Visita al Cliente"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.gbEstado.ResumeLayout(False)
        CType(Me.cmbIdContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdPer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdTipoVisita, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbGruVen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbGruVen As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbIdTipoVisita As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbIdPer As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbIdContacto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbResultado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator101 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator104 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biDeshacer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator107 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblResultado As System.Windows.Forms.Label
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents cmbMotivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents gbDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator

End Class
