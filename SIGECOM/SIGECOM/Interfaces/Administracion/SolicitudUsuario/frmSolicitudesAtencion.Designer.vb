<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudesAtencion
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
        Dim cmbProblema_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudesAtencion))
        Dim dgvPersonalEjecutor_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.txtHoraFinal = New System.Windows.Forms.TextBox()
        Me.txtHoraInicial = New System.Windows.Forms.TextBox()
        Me.txtFechaFinal = New System.Windows.Forms.TextBox()
        Me.txtFechaInicio = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSolucion = New System.Windows.Forms.TextBox()
        Me.cmbProblema = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dgvPersonalEjecutor = New Janus.Windows.GridEX.GridEX()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnRegresarTodos = New System.Windows.Forms.Button()
        Me.btnAgregarTodos = New System.Windows.Forms.Button()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvOpcionMenu = New System.Windows.Forms.DataGridView()
        Me.IdPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.biEjecutar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnOpciones = New System.Windows.Forms.Button()
        Me.dgvOpcionMenuAsignado = New System.Windows.Forms.DataGridView()
        Me.IdPer1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApeNom1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbComentario = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtObsFinal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbProblema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPersonalEjecutor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOpcionMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.dgvOpcionMenuAsignado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbComentario.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtEstado
        '
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtEstado.Location = New System.Drawing.Point(425, 271)
        Me.txtEstado.MaxLength = 50
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(119, 20)
        Me.txtEstado.TabIndex = 156
        '
        'txtHoraFinal
        '
        Me.txtHoraFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraFinal.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtHoraFinal.Location = New System.Drawing.Point(281, 271)
        Me.txtHoraFinal.MaxLength = 50
        Me.txtHoraFinal.Name = "txtHoraFinal"
        Me.txtHoraFinal.Size = New System.Drawing.Size(58, 20)
        Me.txtHoraFinal.TabIndex = 155
        '
        'txtHoraInicial
        '
        Me.txtHoraInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraInicial.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtHoraInicial.Location = New System.Drawing.Point(281, 245)
        Me.txtHoraInicial.MaxLength = 50
        Me.txtHoraInicial.Name = "txtHoraInicial"
        Me.txtHoraInicial.Size = New System.Drawing.Size(58, 20)
        Me.txtHoraInicial.TabIndex = 154
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFinal.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtFechaFinal.Location = New System.Drawing.Point(102, 273)
        Me.txtFechaFinal.MaxLength = 50
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(81, 20)
        Me.txtFechaFinal.TabIndex = 153
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtFechaInicio.Location = New System.Drawing.Point(102, 247)
        Me.txtFechaInicio.MaxLength = 50
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(81, 20)
        Me.txtFechaInicio.TabIndex = 152
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(16, 411)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(183, 13)
        Me.Label20.TabIndex = 150
        Me.Label20.Text = "Personal Ejecutor del Trabajo :"
        '
        'txtSolucion
        '
        Me.txtSolucion.Location = New System.Drawing.Point(102, 329)
        Me.txtSolucion.Multiline = True
        Me.txtSolucion.Name = "txtSolucion"
        Me.txtSolucion.Size = New System.Drawing.Size(625, 69)
        Me.txtSolucion.TabIndex = 149
        '
        'cmbProblema
        '
        Me.cmbProblema.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbProblema_DesignTimeLayout.LayoutString = resources.GetString("cmbProblema_DesignTimeLayout.LayoutString")
        Me.cmbProblema.DesignTimeLayout = cmbProblema_DesignTimeLayout
        Me.cmbProblema.Location = New System.Drawing.Point(102, 301)
        Me.cmbProblema.Name = "cmbProblema"
        Me.cmbProblema.SelectedIndex = -1
        Me.cmbProblema.SelectedItem = Nothing
        Me.cmbProblema.Size = New System.Drawing.Size(442, 20)
        Me.cmbProblema.TabIndex = 148
        Me.cmbProblema.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(370, 276)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 13)
        Me.Label19.TabIndex = 147
        Me.Label19.Text = "Estado :"
        '
        'dgvPersonalEjecutor
        '
        Me.dgvPersonalEjecutor.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvPersonalEjecutor.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        dgvPersonalEjecutor_DesignTimeLayout.LayoutString = resources.GetString("dgvPersonalEjecutor_DesignTimeLayout.LayoutString")
        Me.dgvPersonalEjecutor.DesignTimeLayout = dgvPersonalEjecutor_DesignTimeLayout
        Me.dgvPersonalEjecutor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dgvPersonalEjecutor.GroupByBoxVisible = False
        Me.dgvPersonalEjecutor.Location = New System.Drawing.Point(13, 431)
        Me.dgvPersonalEjecutor.Name = "dgvPersonalEjecutor"
        Me.dgvPersonalEjecutor.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvPersonalEjecutor.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvPersonalEjecutor.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical
        Me.dgvPersonalEjecutor.Size = New System.Drawing.Size(436, 93)
        Me.dgvPersonalEjecutor.TabIndex = 144
        Me.dgvPersonalEjecutor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(34, 332)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 13)
        Me.Label17.TabIndex = 143
        Me.Label17.Text = "Solución :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(31, 304)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 13)
        Me.Label16.TabIndex = 142
        Me.Label16.Text = "Problema :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(205, 276)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 13)
        Me.Label15.TabIndex = 141
        Me.Label15.Text = "Hora Final :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(201, 250)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 13)
        Me.Label14.TabIndex = 140
        Me.Label14.Text = "Hora Inicio :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(17, 276)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 139
        Me.Label13.Text = "Fecha Final :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 250)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 138
        Me.Label11.Text = "Fecha Inicio :"
        '
        'btnRegresarTodos
        '
        Me.btnRegresarTodos.Image = Global.SIGECOM.My.Resources.Resources.Izquierda
        Me.btnRegresarTodos.Location = New System.Drawing.Point(303, 182)
        Me.btnRegresarTodos.Name = "btnRegresarTodos"
        Me.btnRegresarTodos.Size = New System.Drawing.Size(38, 23)
        Me.btnRegresarTodos.TabIndex = 137
        Me.btnRegresarTodos.UseVisualStyleBackColor = True
        '
        'btnAgregarTodos
        '
        Me.btnAgregarTodos.Image = Global.SIGECOM.My.Resources.Resources.Derecha
        Me.btnAgregarTodos.Location = New System.Drawing.Point(303, 145)
        Me.btnAgregarTodos.Name = "btnAgregarTodos"
        Me.btnAgregarTodos.Size = New System.Drawing.Size(38, 23)
        Me.btnAgregarTodos.TabIndex = 136
        Me.btnAgregarTodos.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.SIGECOM.My.Resources.Resources.Regresar
        Me.btnRegresar.Location = New System.Drawing.Point(303, 105)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(38, 23)
        Me.btnRegresar.TabIndex = 135
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnAgregar.Location = New System.Drawing.Point(304, 64)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(38, 23)
        Me.btnAgregar.TabIndex = 134
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvOpcionMenu
        '
        Me.dgvOpcionMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpcionMenu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdPer, Me.ApeNom})
        Me.dgvOpcionMenu.Location = New System.Drawing.Point(11, 35)
        Me.dgvOpcionMenu.Name = "dgvOpcionMenu"
        Me.dgvOpcionMenu.Size = New System.Drawing.Size(286, 194)
        Me.dgvOpcionMenu.TabIndex = 132
        '
        'IdPer
        '
        Me.IdPer.DataPropertyName = "IdPer"
        Me.IdPer.HeaderText = "IdPer"
        Me.IdPer.Name = "IdPer"
        Me.IdPer.Visible = False
        '
        'ApeNom
        '
        Me.ApeNom.DataPropertyName = "ApeNom"
        Me.ApeNom.HeaderText = "Personal de Sistemas"
        Me.ApeNom.Name = "ApeNom"
        Me.ApeNom.ReadOnly = True
        Me.ApeNom.Width = 210
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.biEjecutar, Me.ToolStripSeparator1, Me.biSalir, Me.ToolStripSeparator12})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(768, 31)
        Me.ToolStrip.TabIndex = 158
        Me.ToolStrip.Text = "ToolStrip"
        '
        'biEjecutar
        '
        Me.biEjecutar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biEjecutar.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.biEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biEjecutar.Name = "biEjecutar"
        Me.biEjecutar.Size = New System.Drawing.Size(28, 28)
        Me.biEjecutar.Text = "Crear Nuevo Job"
        Me.biEjecutar.Visible = False
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
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        '
        'btnOpciones
        '
        Me.btnOpciones.Location = New System.Drawing.Point(642, 125)
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(116, 23)
        Me.btnOpciones.TabIndex = 159
        Me.btnOpciones.Text = "Estado"
        Me.btnOpciones.UseVisualStyleBackColor = True
        '
        'dgvOpcionMenuAsignado
        '
        Me.dgvOpcionMenuAsignado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpcionMenuAsignado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdPer1, Me.ApeNom1})
        Me.dgvOpcionMenuAsignado.Location = New System.Drawing.Point(348, 35)
        Me.dgvOpcionMenuAsignado.Name = "dgvOpcionMenuAsignado"
        Me.dgvOpcionMenuAsignado.Size = New System.Drawing.Size(286, 194)
        Me.dgvOpcionMenuAsignado.TabIndex = 160
        '
        'IdPer1
        '
        Me.IdPer1.DataPropertyName = "IdPer"
        Me.IdPer1.HeaderText = "IdPer"
        Me.IdPer1.Name = "IdPer1"
        Me.IdPer1.Visible = False
        '
        'ApeNom1
        '
        Me.ApeNom1.DataPropertyName = "ApeNom"
        Me.ApeNom1.HeaderText = "Seleccionados"
        Me.ApeNom1.Name = "ApeNom1"
        Me.ApeNom1.ReadOnly = True
        Me.ApeNom1.Width = 210
        '
        'gbComentario
        '
        Me.gbComentario.Controls.Add(Me.btnAceptar)
        Me.gbComentario.Controls.Add(Me.txtObsFinal)
        Me.gbComentario.Controls.Add(Me.Label1)
        Me.gbComentario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbComentario.Location = New System.Drawing.Point(194, 136)
        Me.gbComentario.Name = "gbComentario"
        Me.gbComentario.Size = New System.Drawing.Size(361, 194)
        Me.gbComentario.TabIndex = 161
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
        'frmSolicitudesAtencion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(768, 538)
        Me.Controls.Add(Me.gbComentario)
        Me.Controls.Add(Me.dgvOpcionMenuAsignado)
        Me.Controls.Add(Me.dgvOpcionMenu)
        Me.Controls.Add(Me.btnOpciones)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.txtEstado)
        Me.Controls.Add(Me.txtHoraFinal)
        Me.Controls.Add(Me.txtHoraInicial)
        Me.Controls.Add(Me.txtFechaFinal)
        Me.Controls.Add(Me.txtFechaInicio)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtSolucion)
        Me.Controls.Add(Me.cmbProblema)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.dgvPersonalEjecutor)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnRegresarTodos)
        Me.Controls.Add(Me.btnAgregarTodos)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolicitudesAtencion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitudes Atencion"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbProblema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPersonalEjecutor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOpcionMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.dgvOpcionMenuAsignado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbComentario.ResumeLayout(False)
        Me.gbComentario.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaInicio As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtSolucion As System.Windows.Forms.TextBox
    Friend WithEvents cmbProblema As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dgvPersonalEjecutor As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnRegresarTodos As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTodos As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvOpcionMenu As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents biEjecutar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnOpciones As System.Windows.Forms.Button
    Friend WithEvents dgvOpcionMenuAsignado As System.Windows.Forms.DataGridView
    Friend WithEvents gbComentario As System.Windows.Forms.GroupBox
    Friend WithEvents txtObsFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents IdPer1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApeNom1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdPer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApeNom As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
