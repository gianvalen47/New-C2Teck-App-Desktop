<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVencimientos
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
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVencimientos))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbFecIni = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.pboxLimpiarCliente = New System.Windows.Forms.PictureBox()
        Me.chkCliente = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.biImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.biActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.biSalir = New System.Windows.Forms.ToolStripButton()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        Me.cmOpciones.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 346)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.ssBarra.Size = New System.Drawing.Size(885, 20)
        Me.ssBarra.TabIndex = 9
        '
        'sslError
        '
        Me.sslError.AutoSize = False
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
        Me.sslTotal.Size = New System.Drawing.Size(180, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmOpciones
        '
        Me.cmOpciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImprimir, Me.ToolStripMenuItem1, Me.miActualizar, Me.miSalir})
        Me.cmOpciones.Name = "cmOpciones"
        Me.cmOpciones.Size = New System.Drawing.Size(122, 76)
        '
        'miImprimir
        '
        Me.miImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.miImprimir.Name = "miImprimir"
        Me.miImprimir.Size = New System.Drawing.Size(121, 22)
        Me.miImprimir.Text = "Imprimir"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(118, 6)
        '
        'miActualizar
        '
        Me.miActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizar.Name = "miActualizar"
        Me.miActualizar.Size = New System.Drawing.Size(121, 22)
        Me.miActualizar.Text = "Actualizar"
        '
        'miSalir
        '
        Me.miSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.miSalir.Name = "miSalir"
        Me.miSalir.Size = New System.Drawing.Size(121, 22)
        Me.miSalir.Text = "Salir"
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.dgvDatos.AutomaticSort = False
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.EmptyRows = True
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgvDatos.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(0, 104)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.SelectedFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.Size = New System.Drawing.Size(868, 226)
        Me.dgvDatos.TabIndex = 14
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(24, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 15)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Fecha Inicio"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(155, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 15)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Fecha Fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(429, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Cliente"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(286, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 15)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Numero"
        '
        'cbFecIni
        '
        '
        '
        '
        Me.cbFecIni.DropDownCalendar.Name = ""
        Me.cbFecIni.DropDownCalendar.Office2007ColorScheme = Janus.Windows.CalendarCombo.Office2007ColorScheme.Blue
        Me.cbFecIni.DropDownCalendar.Visible = False
        Me.cbFecIni.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecIni.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free
        Me.cbFecIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecIni.Location = New System.Drawing.Point(23, 41)
        Me.cbFecIni.Name = "cbFecIni"
        Me.cbFecIni.NullButtonText = "Ninguno"
        Me.cbFecIni.Office2007ColorScheme = Janus.Windows.CalendarCombo.Office2007ColorScheme.Blue
        Me.cbFecIni.ShowNullButton = True
        Me.cbFecIni.Size = New System.Drawing.Size(88, 20)
        Me.cbFecIni.TabIndex = 23
        Me.cbFecIni.TodayButtonText = "Hoy"
        Me.cbFecIni.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecFin
        '
        '
        '
        '
        Me.cbFecFin.DropDownCalendar.Name = ""
        Me.cbFecFin.DropDownCalendar.Visible = False
        Me.cbFecFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFin.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free
        Me.cbFecFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFin.Location = New System.Drawing.Point(154, 41)
        Me.cbFecFin.Name = "cbFecFin"
        Me.cbFecFin.NullButtonText = "Ninguno"
        Me.cbFecFin.ShowNullButton = True
        Me.cbFecFin.Size = New System.Drawing.Size(88, 20)
        Me.cbFecFin.TabIndex = 24
        Me.cbFecFin.TodayButtonText = "Hoy"
        Me.cbFecFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'pboxLimpiarCliente
        '
        Me.pboxLimpiarCliente.Enabled = False
        Me.pboxLimpiarCliente.Image = Global.SIGECOM.My.Resources.Resources.cleanCliente
        Me.pboxLimpiarCliente.Location = New System.Drawing.Point(512, 18)
        Me.pboxLimpiarCliente.Name = "pboxLimpiarCliente"
        Me.pboxLimpiarCliente.Size = New System.Drawing.Size(24, 18)
        Me.pboxLimpiarCliente.TabIndex = 28
        Me.pboxLimpiarCliente.TabStop = False
        Me.pboxLimpiarCliente.Tag = "Limpiar Cliente"
        '
        'chkCliente
        '
        Me.chkCliente.AutoSize = True
        Me.chkCliente.Checked = True
        Me.chkCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCliente.Location = New System.Drawing.Point(495, 22)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(15, 14)
        Me.chkCliente.TabIndex = 27
        Me.chkCliente.Tag = ""
        Me.chkCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkCliente.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.txtNumDoc)
        Me.GroupBox1.Controls.Add(Me.pboxLimpiarCliente)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.chkCliente)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cbFecFin)
        Me.GroupBox1.Controls.Add(Me.cbFecIni)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(851, 68)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda de Datos"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCliente.Location = New System.Drawing.Point(711, 40)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(25, 21)
        Me.btnBuscarCliente.TabIndex = 32
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(761, 36)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(68, 25)
        Me.btnBuscar.TabIndex = 31
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(422, 41)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(288, 20)
        Me.txtCliente.TabIndex = 30
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(282, 41)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(98, 20)
        Me.txtNumDoc.TabIndex = 29
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.biImprimir, Me.ToolStripSeparator3, Me.biActualizar, Me.ToolStripSeparator2, Me.biSalir})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(885, 31)
        Me.ToolStrip.TabIndex = 16
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'biImprimir
        '
        Me.biImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biImprimir.Image = Global.SIGECOM.My.Resources.Resources.Impresora
        Me.biImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biImprimir.Name = "biImprimir"
        Me.biImprimir.Size = New System.Drawing.Size(28, 28)
        Me.biImprimir.Text = "Imprimir Documento de Cta Cte"
        Me.biImprimir.ToolTipText = "Imprimir Documento de CtaCte"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'biActualizar
        '
        Me.biActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.biActualizar.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.biActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.biActualizar.Name = "biActualizar"
        Me.biActualizar.Size = New System.Drawing.Size(28, 28)
        Me.biActualizar.Text = "Actualizar Consulta"
        Me.biActualizar.ToolTipText = "Refrescar Consulta"
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
        'frmVencimientos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(885, 366)
        Me.ContextMenuStrip = Me.cmOpciones
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.ssBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVencimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vencimiento de Documentos por Cobrar"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        Me.cmOpciones.ResumeLayout(False)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxLimpiarCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cbFecFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecIni As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pboxLimpiarCliente As System.Windows.Forms.PictureBox
    Friend WithEvents chkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents biSalir As System.Windows.Forms.ToolStripButton
End Class
