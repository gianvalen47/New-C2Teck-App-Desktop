<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepVencimientosResumen
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
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCobrador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbUnidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepVencimientosResumen))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblCobrador = New System.Windows.Forms.Label()
        Me.cmbCobrador = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbUnidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbCastigos = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbProvisiones = New System.Windows.Forms.RadioButton()
        Me.rbCtasCtes = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCobrador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Moneda:"
        '
        'cmbCodMon
        '
        Me.cmbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMon_DesignTimeLayout.LayoutString")
        Me.cmbCodMon.DesignTimeLayout = cmbCodMon_DesignTimeLayout
        Me.cmbCodMon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodMon.Location = New System.Drawing.Point(12, 162)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(150, 20)
        Me.cmbCodMon.TabIndex = 113
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblCobrador
        '
        Me.lblCobrador.AutoSize = True
        Me.lblCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobrador.Location = New System.Drawing.Point(12, 193)
        Me.lblCobrador.Name = "lblCobrador"
        Me.lblCobrador.Size = New System.Drawing.Size(81, 16)
        Me.lblCobrador.TabIndex = 124
        Me.lblCobrador.Text = "Cobrador :"
        '
        'cmbCobrador
        '
        Me.cmbCobrador.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCobrador_DesignTimeLayout.LayoutString = resources.GetString("cmbCobrador_DesignTimeLayout.LayoutString")
        Me.cmbCobrador.DesignTimeLayout = cmbCobrador_DesignTimeLayout
        Me.cmbCobrador.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbCobrador.Location = New System.Drawing.Point(12, 214)
        Me.cmbCobrador.Name = "cmbCobrador"
        Me.cmbCobrador.SelectedIndex = -1
        Me.cmbCobrador.SelectedItem = Nothing
        Me.cmbCobrador.Size = New System.Drawing.Size(250, 20)
        Me.cmbCobrador.TabIndex = 123
        Me.cmbCobrador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 16)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "Unidad Negocio:"
        '
        'cmbUnidad
        '
        Me.cmbUnidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUnidad_DesignTimeLayout.LayoutString = resources.GetString("cmbUnidad_DesignTimeLayout.LayoutString")
        Me.cmbUnidad.DesignTimeLayout = cmbUnidad_DesignTimeLayout
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.Location = New System.Drawing.Point(12, 113)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.SelectedIndex = -1
        Me.cmbUnidad.SelectedItem = Nothing
        Me.cmbUnidad.Size = New System.Drawing.Size(160, 20)
        Me.cmbUnidad.TabIndex = 163
        Me.cmbUnidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbCastigos)
        Me.GroupBox2.Controls.Add(Me.rbTodos)
        Me.GroupBox2.Controls.Add(Me.rbProvisiones)
        Me.GroupBox2.Controls.Add(Me.rbCtasCtes)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(283, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(122, 130)
        Me.GroupBox2.TabIndex = 165
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TIP CTA"
        '
        'rbCastigos
        '
        Me.rbCastigos.AutoSize = True
        Me.rbCastigos.Location = New System.Drawing.Point(15, 98)
        Me.rbCastigos.Name = "rbCastigos"
        Me.rbCastigos.Size = New System.Drawing.Size(80, 19)
        Me.rbCastigos.TabIndex = 174
        Me.rbCastigos.Text = "Castigos"
        Me.rbCastigos.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(15, 23)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(64, 19)
        Me.rbTodos.TabIndex = 171
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbProvisiones
        '
        Me.rbProvisiones.AutoSize = True
        Me.rbProvisiones.Location = New System.Drawing.Point(15, 73)
        Me.rbProvisiones.Name = "rbProvisiones"
        Me.rbProvisiones.Size = New System.Drawing.Size(99, 19)
        Me.rbProvisiones.TabIndex = 173
        Me.rbProvisiones.Text = "Provisiones"
        Me.rbProvisiones.UseVisualStyleBackColor = True
        '
        'rbCtasCtes
        '
        Me.rbCtasCtes.AutoSize = True
        Me.rbCtasCtes.Checked = True
        Me.rbCtasCtes.Location = New System.Drawing.Point(15, 48)
        Me.rbCtasCtes.Name = "rbCtasCtes"
        Me.rbCtasCtes.Size = New System.Drawing.Size(85, 19)
        Me.rbCtasCtes.TabIndex = 172
        Me.rbCtasCtes.TabStop = True
        Me.rbCtasCtes.Text = "Ctas Ctes"
        Me.rbCtasCtes.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbFecFinal)
        Me.GroupBox1.Controls.Add(Me.cbFecInicio)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 71)
        Me.GroupBox1.TabIndex = 166
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FECHAS"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(208, 28)
        Me.cbFecFinal.MinDate = New Date(1992, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.ReadOnly = True
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 38
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicio.Location = New System.Drawing.Point(56, 29)
        Me.cbFecInicio.MinDate = New Date(1992, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 37
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 16)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Del :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(174, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 16)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Al :"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(119, 246)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 27)
        Me.btnAceptar.TabIndex = 173
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(203, 246)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 174
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepVencimientosResumen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(413, 281)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmbUnidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblCobrador)
        Me.Controls.Add(Me.cmbCobrador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbCodMon)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepVencimientosResumen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Vencimientos Acumulado"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCobrador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblCobrador As System.Windows.Forms.Label
    Friend WithEvents cmbCobrador As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCastigos As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rbProvisiones As System.Windows.Forms.RadioButton
    Friend WithEvents rbCtasCtes As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
