<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramacionJob_DetalleAct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramacionJob_DetalleAct))
        Dim cmbAtraso_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout_Reference_0 As Janus.Windows.Common.Layouts.JanusLayoutReference = New Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.Image")
        Me.txtDesActividad = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.gb = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.biActualizar = New System.Windows.Forms.Button()
        Me.biNuevo = New System.Windows.Forms.Button()
        Me.biDeshacer = New System.Windows.Forms.Button()
        Me.biEditar = New System.Windows.Forms.Button()
        Me.biGrabar = New System.Windows.Forms.Button()
        Me.cbEjecutado = New System.Windows.Forms.CheckBox()
        Me.txtFecFinReal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbAtraso = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDesAtraso = New System.Windows.Forms.TextBox()
        Me.cmbOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.gb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb.SuspendLayout()
        CType(Me.cmbAtraso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpciones.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDesActividad
        '
        Me.txtDesActividad.BackColor = System.Drawing.SystemColors.Window
        Me.txtDesActividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesActividad.Location = New System.Drawing.Point(87, 20)
        Me.txtDesActividad.Multiline = True
        Me.txtDesActividad.Name = "txtDesActividad"
        Me.txtDesActividad.ReadOnly = True
        Me.txtDesActividad.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesActividad.Size = New System.Drawing.Size(615, 38)
        Me.txtDesActividad.TabIndex = 14
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(11, 33)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 13)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "Actividad :"
        '
        'gb
        '
        Me.gb.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gb.Controls.Add(Me.btnCerrar)
        Me.gb.Controls.Add(Me.biActualizar)
        Me.gb.Controls.Add(Me.biNuevo)
        Me.gb.Controls.Add(Me.biDeshacer)
        Me.gb.Controls.Add(Me.biEditar)
        Me.gb.Controls.Add(Me.biGrabar)
        Me.gb.Controls.Add(Me.cbEjecutado)
        Me.gb.Controls.Add(Me.txtFecFinReal)
        Me.gb.Controls.Add(Me.Label7)
        Me.gb.Controls.Add(Me.Label6)
        Me.gb.Controls.Add(Me.cmbAtraso)
        Me.gb.Controls.Add(Me.Label5)
        Me.gb.Controls.Add(Me.txtDesAtraso)
        Me.gb.DisabledFormatStyle.ForeColor = System.Drawing.Color.Black
        Me.gb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb.Location = New System.Drawing.Point(5, 79)
        Me.gb.Name = "gb"
        Me.gb.Size = New System.Drawing.Size(720, 110)
        Me.gb.TabIndex = 239
        Me.gb.Text = "Programación Real"
        Me.gb.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.Transparent
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCerrar.Location = New System.Drawing.Point(244, 17)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(28, 28)
        Me.btnCerrar.TabIndex = 248
        Me.btnCerrar.TabStop = False
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'biActualizar
        '
        Me.biActualizar.BackColor = System.Drawing.Color.Transparent
        Me.biActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biActualizar.Image = CType(resources.GetObject("biActualizar.Image"), System.Drawing.Image)
        Me.biActualizar.Location = New System.Drawing.Point(199, 17)
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.TabIndex = 247
        Me.biActualizar.TabStop = False
        Me.biActualizar.UseVisualStyleBackColor = False
        '
        'biNuevo
        '
        Me.biNuevo.BackColor = System.Drawing.Color.Transparent
        Me.biNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biNuevo.Image = CType(resources.GetObject("biNuevo.Image"), System.Drawing.Image)
        Me.biNuevo.Location = New System.Drawing.Point(11, 17)
        Me.biNuevo.Name = "biNuevo"
        Me.biNuevo.Size = New System.Drawing.Size(28, 28)
        Me.biNuevo.TabIndex = 246
        Me.biNuevo.TabStop = False
        Me.biNuevo.UseVisualStyleBackColor = False
        '
        'biDeshacer
        '
        Me.biDeshacer.BackColor = System.Drawing.Color.Transparent
        Me.biDeshacer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biDeshacer.Image = CType(resources.GetObject("biDeshacer.Image"), System.Drawing.Image)
        Me.biDeshacer.Location = New System.Drawing.Point(152, 17)
        Me.biDeshacer.Name = "biDeshacer"
        Me.biDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.biDeshacer.TabIndex = 245
        Me.biDeshacer.TabStop = False
        Me.biDeshacer.UseVisualStyleBackColor = False
        '
        'biEditar
        '
        Me.biEditar.BackColor = System.Drawing.Color.Transparent
        Me.biEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biEditar.Image = CType(resources.GetObject("biEditar.Image"), System.Drawing.Image)
        Me.biEditar.Location = New System.Drawing.Point(57, 17)
        Me.biEditar.Name = "biEditar"
        Me.biEditar.Size = New System.Drawing.Size(28, 28)
        Me.biEditar.TabIndex = 244
        Me.biEditar.TabStop = False
        Me.biEditar.UseVisualStyleBackColor = False
        '
        'biGrabar
        '
        Me.biGrabar.BackColor = System.Drawing.Color.Transparent
        Me.biGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biGrabar.Image = CType(resources.GetObject("biGrabar.Image"), System.Drawing.Image)
        Me.biGrabar.Location = New System.Drawing.Point(104, 17)
        Me.biGrabar.Name = "biGrabar"
        Me.biGrabar.Size = New System.Drawing.Size(28, 28)
        Me.biGrabar.TabIndex = 243
        Me.biGrabar.UseVisualStyleBackColor = False
        '
        'cbEjecutado
        '
        Me.cbEjecutado.AutoSize = True
        Me.cbEjecutado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbEjecutado.Location = New System.Drawing.Point(540, 52)
        Me.cbEjecutado.Name = "cbEjecutado"
        Me.cbEjecutado.Size = New System.Drawing.Size(85, 17)
        Me.cbEjecutado.TabIndex = 241
        Me.cbEjecutado.Text = "Terminado"
        Me.cbEjecutado.UseVisualStyleBackColor = True
        '
        'txtFecFinReal
        '
        '
        '
        '
        Me.txtFecFinReal.DropDownCalendar.Name = ""
        Me.txtFecFinReal.DropDownCalendar.Visible = False
        Me.txtFecFinReal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecFinReal.Location = New System.Drawing.Point(85, 49)
        Me.txtFecFinReal.Name = "txtFecFinReal"
        Me.txtFecFinReal.NullButtonText = "Ninguno"
        Me.txtFecFinReal.Size = New System.Drawing.Size(93, 20)
        Me.txtFecFinReal.TabIndex = 239
        Me.txtFecFinReal.TodayButtonText = "Hoy"
        Me.txtFecFinReal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 240
        Me.Label7.Text = "Fecha :"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 30)
        Me.Label6.TabIndex = 224
        Me.Label6.Text = "Motivo del Atraso:"
        '
        'cmbAtraso
        '
        Me.cmbAtraso.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbAtraso_DesignTimeLayout.LayoutString = resources.GetString("cmbAtraso_DesignTimeLayout.LayoutString")
        Me.cmbAtraso.DesignTimeLayout = cmbAtraso_DesignTimeLayout
        Me.cmbAtraso.Location = New System.Drawing.Point(314, 49)
        Me.cmbAtraso.Name = "cmbAtraso"
        Me.cmbAtraso.SelectedIndex = -1
        Me.cmbAtraso.SelectedItem = Nothing
        Me.cmbAtraso.Size = New System.Drawing.Size(160, 20)
        Me.cmbAtraso.TabIndex = 6
        Me.cmbAtraso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(259, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 222
        Me.Label5.Text = "Atraso :"
        '
        'txtDesAtraso
        '
        Me.txtDesAtraso.Location = New System.Drawing.Point(85, 75)
        Me.txtDesAtraso.Multiline = True
        Me.txtDesAtraso.Name = "txtDesAtraso"
        Me.txtDesAtraso.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesAtraso.Size = New System.Drawing.Size(617, 30)
        Me.txtDesAtraso.TabIndex = 7
        '
        'cmbOpciones
        '
        Me.cmbOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMostrar, Me.ToolStripSeparator4, Me.miActualizar})
        Me.cmbOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpciones.Size = New System.Drawing.Size(127, 54)
        '
        'miMostrar
        '
        Me.miMostrar.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrar.Name = "miMostrar"
        Me.miMostrar.Size = New System.Drawing.Size(126, 22)
        Me.miMostrar.Text = "Mostrar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(123, 6)
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
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 431)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(749, 20)
        Me.ssBarra.TabIndex = 243
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(320, 15)
        Me.sslError.Visible = False
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
        Me.sslTotal.Visible = False
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowCardSizing = False
        Me.dgvDatos.ContextMenuStrip = Me.cmbOpciones
        dgvDatos_DesignTimeLayout_Reference_0.Instance = CType(resources.GetObject("dgvDatos_DesignTimeLayout_Reference_0.Instance"), Object)
        dgvDatos_DesignTimeLayout.LayoutReferences.AddRange(New Janus.Windows.Common.Layouts.JanusLayoutReference() {dgvDatos_DesignTimeLayout_Reference_0})
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatos.Location = New System.Drawing.Point(5, 196)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(720, 215)
        Me.dgvDatos.TabIndex = 244
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.UiGroupBox2.Controls.Add(Me.txtDesActividad)
        Me.UiGroupBox2.Controls.Add(Me.Label21)
        Me.UiGroupBox2.DisabledFormatStyle.ForeColor = System.Drawing.Color.Black
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(5, 8)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(720, 64)
        Me.UiGroupBox2.TabIndex = 246
        Me.UiGroupBox2.Text = "Datos de Programación"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'frmProgramacionJob_DetalleAct
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(749, 451)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.gb)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmProgramacionJob_DetalleAct"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programación Job Detalle"
        CType(Me.gb,System.ComponentModel.ISupportInitialize).EndInit
        Me.gb.ResumeLayout(false)
        Me.gb.PerformLayout
        CType(Me.cmbAtraso,System.ComponentModel.ISupportInitialize).EndInit
        Me.cmbOpciones.ResumeLayout(false)
        Me.ssBarra.ResumeLayout(false)
        Me.ssBarra.PerformLayout
        CType(Me.dgvDatos,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ofEstiloForm,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiGroupBox2,System.ComponentModel.ISupportInitialize).EndInit
        Me.UiGroupBox2.ResumeLayout(false)
        Me.UiGroupBox2.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents txtDesActividad As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents gb As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbAtraso As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDesAtraso As System.Windows.Forms.TextBox
    Friend WithEvents txtFecFinReal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miMostrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cbEjecutado As System.Windows.Forms.CheckBox
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents biNuevo As System.Windows.Forms.Button
    Friend WithEvents biDeshacer As System.Windows.Forms.Button
    Friend WithEvents biEditar As System.Windows.Forms.Button
    Friend WithEvents biGrabar As System.Windows.Forms.Button
    Friend WithEvents biActualizar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
End Class
