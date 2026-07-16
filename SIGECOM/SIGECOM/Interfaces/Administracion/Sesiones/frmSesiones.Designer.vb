<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSesiones
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
        Dim dgvDatosSesion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSesiones))
        Dim dgvDatosOpciones_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.TabSesiones = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.lblTotalReg = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.dgvDatosSesion = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpcionesSesiones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarSesiones = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.dgvDatosOpciones = New Janus.Windows.GridEX.GridEX()
        Me.cmbOpcionesOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarOpciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.TabSesiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabSesiones.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.dgvDatosSesion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpcionesSesiones.SuspendLayout()
        Me.UiTabPage2.SuspendLayout()
        CType(Me.dgvDatosOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmbOpcionesOpciones.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabSesiones
        '
        Me.TabSesiones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabSesiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabSesiones.Location = New System.Drawing.Point(6, 5)
        Me.TabSesiones.Name = "TabSesiones"
        Me.TabSesiones.Size = New System.Drawing.Size(785, 410)
        Me.TabSesiones.TabIndex = 235
        Me.TabSesiones.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage2})
        Me.TabSesiones.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabPage1.Controls.Add(Me.lblTotalReg)
        Me.UiTabPage1.Controls.Add(Me.UiGroupBox1)
        Me.UiTabPage1.Controls.Add(Me.dgvDatosSesion)
        Me.UiTabPage1.Icon = CType(resources.GetObject("UiTabPage1.Icon"), System.Drawing.Icon)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(783, 386)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "[F2]  SESIONES"
        '
        'lblTotalReg
        '
        Me.lblTotalReg.AutoSize = True
        Me.lblTotalReg.Location = New System.Drawing.Point(530, 363)
        Me.lblTotalReg.Name = "lblTotalReg"
        Me.lblTotalReg.Size = New System.Drawing.Size(39, 13)
        Me.lblTotalReg.TabIndex = 214
        Me.lblTotalReg.Text = "Label2"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.BorderColor = System.Drawing.SystemColors.Desktop
        Me.UiGroupBox1.Controls.Add(Me.btnBuscar)
        Me.UiGroupBox1.Controls.Add(Me.txtUsuario)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaInicio)
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(743, 45)
        Me.UiGroupBox1.TabIndex = 213
        Me.UiGroupBox1.Text = "Datos de Búsqueda"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.Location = New System.Drawing.Point(565, 14)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(63, 23)
        Me.btnBuscar.TabIndex = 13
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(447, 17)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(111, 20)
        Me.txtUsuario.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(389, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Usuario"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(228, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Fecha"
        '
        'txtFechaInicio
        '
        '
        '
        '
        Me.txtFechaInicio.DropDownCalendar.Name = ""
        Me.txtFechaInicio.DropDownCalendar.Visible = False
        Me.txtFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaInicio.Location = New System.Drawing.Point(276, 19)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.NullButtonText = "Ninguno"
        Me.txtFechaInicio.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaInicio.TabIndex = 5
        Me.txtFechaInicio.TodayButtonText = "Hoy"
        Me.txtFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'dgvDatosSesion
        '
        Me.dgvDatosSesion.AllowCardSizing = False
        Me.dgvDatosSesion.ContextMenuStrip = Me.cmbOpcionesSesiones
        dgvDatosSesion_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosSesion_DesignTimeLayout.LayoutString")
        Me.dgvDatosSesion.DesignTimeLayout = dgvDatosSesion_DesignTimeLayout
        Me.dgvDatosSesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosSesion.GroupByBoxVisible = False
        Me.dgvDatosSesion.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.dgvDatosSesion.Location = New System.Drawing.Point(6, 54)
        Me.dgvDatosSesion.Name = "dgvDatosSesion"
        Me.dgvDatosSesion.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosSesion.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosSesion.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosSesion.Size = New System.Drawing.Size(743, 299)
        Me.dgvDatosSesion.TabIndex = 212
        Me.dgvDatosSesion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003
        '
        'cmbOpcionesSesiones
        '
        Me.cmbOpcionesSesiones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator10, Me.ToolStripSeparator3, Me.miActualizarSesiones})
        Me.cmbOpcionesSesiones.Name = "ContextMenuStrip1"
        Me.cmbOpcionesSesiones.Size = New System.Drawing.Size(127, 38)
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarSesiones
        '
        Me.miActualizarSesiones.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarSesiones.Name = "miActualizarSesiones"
        Me.miActualizarSesiones.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarSesiones.Text = "Actualizar"
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabPage2.Controls.Add(Me.lblUsuario)
        Me.UiTabPage2.Controls.Add(Me.dgvDatosOpciones)
        Me.UiTabPage2.Icon = CType(resources.GetObject("UiTabPage2.Icon"), System.Drawing.Icon)
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 23)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(783, 386)
        Me.UiTabPage2.TabStop = True
        Me.UiTabPage2.Text = "[F3]  OPCIONES DE SESION"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(14, 10)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(51, 17)
        Me.lblUsuario.TabIndex = 4
        Me.lblUsuario.Text = "Label2"
        '
        'dgvDatosOpciones
        '
        Me.dgvDatosOpciones.ContextMenuStrip = Me.cmbOpcionesOpciones
        dgvDatosOpciones_DesignTimeLayout.LayoutString = resources.GetString("dgvDatosOpciones_DesignTimeLayout.LayoutString")
        Me.dgvDatosOpciones.DesignTimeLayout = dgvDatosOpciones_DesignTimeLayout
        Me.dgvDatosOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dgvDatosOpciones.GroupByBoxVisible = False
        Me.dgvDatosOpciones.Location = New System.Drawing.Point(8, 34)
        Me.dgvDatosOpciones.Name = "dgvDatosOpciones"
        Me.dgvDatosOpciones.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatosOpciones.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatosOpciones.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatosOpciones.Size = New System.Drawing.Size(764, 321)
        Me.dgvDatosOpciones.TabIndex = 3
        Me.dgvDatosOpciones.TabStop = False
        Me.dgvDatosOpciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005
        '
        'cmbOpcionesOpciones
        '
        Me.cmbOpcionesOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.miActualizarOpciones})
        Me.cmbOpcionesOpciones.Name = "ContextMenuStrip1"
        Me.cmbOpcionesOpciones.Size = New System.Drawing.Size(127, 38)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarOpciones
        '
        Me.miActualizarOpciones.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarOpciones.Name = "miActualizarOpciones"
        Me.miActualizarOpciones.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarOpciones.Text = "Actualizar"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmSesiones
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(804, 432)
        Me.Controls.Add(Me.TabSesiones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSesiones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sesiones del Sistema"
        CType(Me.TabSesiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabSesiones.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        Me.UiTabPage1.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.dgvDatosSesion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpcionesSesiones.ResumeLayout(False)
        Me.UiTabPage2.ResumeLayout(False)
        Me.UiTabPage2.PerformLayout()
        CType(Me.dgvDatosOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmbOpcionesOpciones.ResumeLayout(False)
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabSesiones As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvDatosSesion As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvDatosOpciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cmbOpcionesSesiones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarSesiones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbOpcionesOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarOpciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblTotalReg As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBuscar As Button
End Class
