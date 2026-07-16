<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudesEstados
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
        Me.components = New System.ComponentModel.Container
        Dim dgvEstados_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim dgvEstados_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column5.Image")
        Dim cmbMedio_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbPrioridad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbAplicacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbTipSol_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbMotivo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudesEstados))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvEstados = New Janus.Windows.GridEX.GridEX
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtSolicitante = New System.Windows.Forms.TextBox
        Me.cmbMedio = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbPrioridad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbAplicacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbTipSol = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToolStrip = New System.Windows.Forms.ToolStrip
        Me.biGuardar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.biEditar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.biAtencion = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.biCancelar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.biSalir = New System.Windows.Forms.ToolStripButton
        Me.txtNumero = New System.Windows.Forms.TextBox
        Me.gbComentario = New System.Windows.Forms.GroupBox
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.txtObsFinal = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnBuscarPersonal = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbMotivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPrioridad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbAplicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipSol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.gbComentario.SuspendLayout()
        CType(Me.cmbMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvEstados
        '
        Me.dgvEstados.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        dgvEstados_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvEstados_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvEstados_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvEstados_DesignTimeLayout_Reference_0})
        dgvEstados_DesignTimeLayout.LayoutString = resources.GetString("dgvEstados_DesignTimeLayout.LayoutString")
        Me.dgvEstados.DesignTimeLayout = dgvEstados_DesignTimeLayout
        Me.dgvEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvEstados.GroupByBoxVisible = False
        Me.dgvEstados.Location = New System.Drawing.Point(86, 270)
        Me.dgvEstados.Name = "dgvEstados"
        Me.dgvEstados.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvEstados.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvEstados.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvEstados.Size = New System.Drawing.Size(783, 150)
        Me.dgvEstados.TabIndex = 195
        Me.dgvEstados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(86, 111)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(783, 146)
        Me.txtDescripcion.TabIndex = 194
        '
        'txtSolicitante
        '
        Me.txtSolicitante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicitante.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtSolicitante.Location = New System.Drawing.Point(615, 74)
        Me.txtSolicitante.MaxLength = 50
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.Size = New System.Drawing.Size(226, 20)
        Me.txtSolicitante.TabIndex = 193
        '
        'cmbMedio
        '
        Me.cmbMedio.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMedio_DesignTimeLayout.LayoutString = resources.GetString("cmbMedio_DesignTimeLayout.LayoutString")
        Me.cmbMedio.DesignTimeLayout = cmbMedio_DesignTimeLayout
        Me.cmbMedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedio.Location = New System.Drawing.Point(424, 74)
        Me.cmbMedio.Name = "cmbMedio"
        Me.cmbMedio.SelectedIndex = -1
        Me.cmbMedio.SelectedItem = Nothing
        Me.cmbMedio.Size = New System.Drawing.Size(96, 20)
        Me.cmbMedio.TabIndex = 192
        Me.cmbMedio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbPrioridad
        '
        Me.cmbPrioridad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPrioridad_DesignTimeLayout.LayoutString = resources.GetString("cmbPrioridad_DesignTimeLayout.LayoutString")
        Me.cmbPrioridad.DesignTimeLayout = cmbPrioridad_DesignTimeLayout
        Me.cmbPrioridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrioridad.Location = New System.Drawing.Point(286, 74)
        Me.cmbPrioridad.Name = "cmbPrioridad"
        Me.cmbPrioridad.SelectedIndex = -1
        Me.cmbPrioridad.SelectedItem = Nothing
        Me.cmbPrioridad.Size = New System.Drawing.Size(76, 20)
        Me.cmbPrioridad.TabIndex = 191
        Me.cmbPrioridad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbAplicacion
        '
        Me.cmbAplicacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAplicacion_DesignTimeLayout.LayoutString = resources.GetString("cmbAplicacion_DesignTimeLayout.LayoutString")
        Me.cmbAplicacion.DesignTimeLayout = cmbAplicacion_DesignTimeLayout
        Me.cmbAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAplicacion.Location = New System.Drawing.Point(86, 74)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.SelectedIndex = -1
        Me.cmbAplicacion.SelectedItem = Nothing
        Me.cmbAplicacion.Size = New System.Drawing.Size(121, 20)
        Me.cmbAplicacion.TabIndex = 190
        Me.cmbAplicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbTipSol
        '
        Me.cmbTipSol.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipSol_DesignTimeLayout.LayoutString = resources.GetString("cmbTipSol_DesignTimeLayout.LayoutString")
        Me.cmbTipSol.DesignTimeLayout = cmbTipSol_DesignTimeLayout
        Me.cmbTipSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipSol.Location = New System.Drawing.Point(424, 42)
        Me.cmbTipSol.Name = "cmbTipSol"
        Me.cmbTipSol.SelectedIndex = -1
        Me.cmbTipSol.SelectedItem = Nothing
        Me.cmbTipSol.Size = New System.Drawing.Size(179, 20)
        Me.cmbTipSol.TabIndex = 189
        Me.cmbTipSol.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(224, 42)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(92, 20)
        Me.txtFecha.TabIndex = 188
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 121)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 186
        Me.Label10.Text = "Descripción :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 274)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 185
        Me.Label9.Text = "Estados  :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(537, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 184
        Me.Label8.Text = "Solicitante :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(373, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 183
        Me.Label7.Text = "Medio :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(219, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "Prioridad :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 181
        Me.Label5.Text = "Aplicación :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(332, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 180
        Me.Label4.Text = "Tipo Solicitud :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(174, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "Fecha :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 178
        Me.Label2.Text = "Número :"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biGuardar, Me.ToolStripSeparator3, Me.biEditar, Me.ToolStripSeparator1, Me.biAtencion, Me.ToolStripSeparator2, Me.biCancelar, Me.ToolStripSeparator4, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(878, 31)
        Me.ToolStrip.TabIndex = 202
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biGuardar
        '
        Me.biGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.biGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biGuardar.Name = "biGuardar"
        Me.biGuardar.Size = New System.Drawing.Size(28, 28)
        Me.biGuardar.Text = "Guardar"
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
        Me.biEditar.Image = CType(resources.GetObject("biEditar.Image"), System.Drawing.Image)
        Me.biEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.Text = "Editar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'biAtencion
        '
        Me.biAtencion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biAtencion.Image = CType(resources.GetObject("biAtencion.Image"), System.Drawing.Image)
        Me.biAtencion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biAtencion.Name = "biAtencion"
        Me.biAtencion.Size = New System.Drawing.Size(28, 28)
        Me.biAtencion.Text = "Atención"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'biCancelar
        '
        Me.biCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biCancelar.Enabled = False
        Me.biCancelar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.biCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biCancelar.Name = "biCancelar"
        Me.biCancelar.Size = New System.Drawing.Size(28, 28)
        Me.biCancelar.Text = "Cancelar Solicitud"
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
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtNumero.Location = New System.Drawing.Point(86, 43)
        Me.txtNumero.MaxLength = 50
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(63, 20)
        Me.txtNumero.TabIndex = 203
        '
        'gbComentario
        '
        Me.gbComentario.Controls.Add(Me.btnAceptar)
        Me.gbComentario.Controls.Add(Me.txtObsFinal)
        Me.gbComentario.Controls.Add(Me.Label1)
        Me.gbComentario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbComentario.Location = New System.Drawing.Point(251, 121)
        Me.gbComentario.Name = "gbComentario"
        Me.gbComentario.Size = New System.Drawing.Size(361, 194)
        Me.gbComentario.TabIndex = 204
        Me.gbComentario.TabStop = False
        Me.gbComentario.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(143, 155)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 27)
        Me.btnAceptar.TabIndex = 196
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtObsFinal
        '
        Me.txtObsFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObsFinal.Location = New System.Drawing.Point(15, 35)
        Me.txtObsFinal.Multiline = True
        Me.txtObsFinal.Name = "txtObsFinal"
        Me.txtObsFinal.Size = New System.Drawing.Size(332, 111)
        Me.txtObsFinal.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(239, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ingrese su Observación y/o Comentario :"
        '
        'btnBuscarPersonal
        '
        Me.btnBuscarPersonal.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersonal.Location = New System.Drawing.Point(844, 73)
        Me.btnBuscarPersonal.Name = "btnBuscarPersonal"
        Me.btnBuscarPersonal.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarPersonal.TabIndex = 205
        Me.btnBuscarPersonal.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(621, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 206
        Me.Label11.Text = "Motivo :"
        '
        'cmbMotivo
        '
        Me.cmbMotivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMotivo_DesignTimeLayout.LayoutString = resources.GetString("cmbMotivo_DesignTimeLayout.LayoutString")
        Me.cmbMotivo.DesignTimeLayout = cmbMotivo_DesignTimeLayout
        Me.cmbMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMotivo.Location = New System.Drawing.Point(674, 42)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.SelectedIndex = -1
        Me.cmbMotivo.SelectedItem = Nothing
        Me.cmbMotivo.Size = New System.Drawing.Size(195, 20)
        Me.cmbMotivo.TabIndex = 207
        Me.cmbMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmSolicitudesEstados
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(878, 438)
        Me.Controls.Add(Me.cmbMotivo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnBuscarPersonal)
        Me.Controls.Add(Me.gbComentario)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.dgvEstados)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtSolicitante)
        Me.Controls.Add(Me.cmbMedio)
        Me.Controls.Add(Me.cmbPrioridad)
        Me.Controls.Add(Me.cmbAplicacion)
        Me.Controls.Add(Me.cmbTipSol)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolicitudesEstados"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitudes Estado"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEstados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMedio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPrioridad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbAplicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipSol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.gbComentario.ResumeLayout(False)
        Me.gbComentario.PerformLayout()
        CType(Me.cmbMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvEstados As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents cmbMedio As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbPrioridad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbAplicacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbTipSol As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biAtencion As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents biGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents biCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gbComentario As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtObsFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPersonal As System.Windows.Forms.Button
    Friend WithEvents cmbMotivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
