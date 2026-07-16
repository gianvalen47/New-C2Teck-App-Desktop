<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepVencimientosAcumulado
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
        Dim cmbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbDocu_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepVencimientosAcumulado))
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme
        Me.Office2007SilverTheme1 = New Telerik.WinControls.Themes.Office2007SilverTheme
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.cmbDocu = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox
        Me.rbTodos = New Telerik.WinControls.UI.RadRadioButton
        Me.rbCastigos = New Telerik.WinControls.UI.RadRadioButton
        Me.rbProvisiones = New Telerik.WinControls.UI.RadRadioButton
        Me.rbCtasCtes = New Telerik.WinControls.UI.RadRadioButton
        Me.biCancelar = New Telerik.WinControls.UI.RadButton
        Me.biAceptar = New Telerik.WinControls.UI.RadButton
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDocu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.rbTodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbCastigos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbProvisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbCtasCtes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.biCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.biAceptar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.Controls.Add(Me.cbFecFinal)
        Me.RadGroupBox1.Controls.Add(Me.cbFecInicio)
        Me.RadGroupBox1.Controls.Add(Me.Label12)
        Me.RadGroupBox1.Controls.Add(Me.Label13)
        Me.RadGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = "FECHAS"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(333, 71)
        Me.RadGroupBox1.TabIndex = 2
        Me.RadGroupBox1.Text = "FECHAS"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(213, 30)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 2
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
        Me.cbFecInicio.Location = New System.Drawing.Point(53, 30)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(174, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 16)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Al :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 16)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Del :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 95)
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
        Me.cmbCodMon.Location = New System.Drawing.Point(12, 114)
        Me.cmbCodMon.Name = "cmbCodMon"
        Me.cmbCodMon.SelectedIndex = -1
        Me.cmbCodMon.SelectedItem = Nothing
        Me.cmbCodMon.Size = New System.Drawing.Size(125, 20)
        Me.cmbCodMon.TabIndex = 3
        Me.cmbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbDocu
        '
        Me.cmbDocu.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbDocu_DesignTimeLayout.LayoutString = resources.GetString("cmbDocu_DesignTimeLayout.LayoutString")
        Me.cmbDocu.DesignTimeLayout = cmbDocu_DesignTimeLayout
        Me.cmbDocu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDocu.Location = New System.Drawing.Point(12, 174)
        Me.cmbDocu.Name = "cmbDocu"
        Me.cmbDocu.SelectedIndex = -1
        Me.cmbDocu.SelectedItem = Nothing
        Me.cmbDocu.Size = New System.Drawing.Size(194, 20)
        Me.cmbDocu.TabIndex = 4
        Me.cmbDocu.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbDocu.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'RadLabel4
        '
        Me.RadLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel4.Location = New System.Drawing.Point(15, 151)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(87, 17)
        Me.RadLabel4.TabIndex = 120
        Me.RadLabel4.Text = "Documentos:"
        Me.RadLabel4.ThemeName = "Office2007Blue"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.Controls.Add(Me.rbTodos)
        Me.RadGroupBox2.Controls.Add(Me.rbCastigos)
        Me.RadGroupBox2.Controls.Add(Me.rbProvisiones)
        Me.RadGroupBox2.Controls.Add(Me.rbCtasCtes)
        Me.RadGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadGroupBox2.FooterImageIndex = -1
        Me.RadGroupBox2.FooterImageKey = ""
        Me.RadGroupBox2.HeaderImageIndex = -1
        Me.RadGroupBox2.HeaderImageKey = ""
        Me.RadGroupBox2.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox2.HeaderText = "TIP CTA"
        Me.RadGroupBox2.Location = New System.Drawing.Point(236, 89)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox2.Size = New System.Drawing.Size(109, 125)
        Me.RadGroupBox2.TabIndex = 122
        Me.RadGroupBox2.Text = "TIP CTA"
        Me.RadGroupBox2.ThemeName = "ControlDefault"
        '
        'rbTodos
        '
        Me.rbTodos.AllowShowFocusCues = True
        Me.rbTodos.BackColor = System.Drawing.Color.Transparent
        Me.rbTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodos.Location = New System.Drawing.Point(11, 23)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.RadioCheckAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbTodos.Size = New System.Drawing.Size(97, 18)
        Me.rbTodos.TabIndex = 3
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbTodos.ThemeName = "Aqua"
        '
        'rbCastigos
        '
        Me.rbCastigos.AllowShowFocusCues = True
        Me.rbCastigos.BackColor = System.Drawing.Color.Transparent
        Me.rbCastigos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCastigos.Location = New System.Drawing.Point(11, 97)
        Me.rbCastigos.Name = "rbCastigos"
        Me.rbCastigos.RadioCheckAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbCastigos.Size = New System.Drawing.Size(97, 18)
        Me.rbCastigos.TabIndex = 2
        Me.rbCastigos.Text = "Castigos"
        Me.rbCastigos.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbCastigos.ThemeName = "Aqua"
        '
        'rbProvisiones
        '
        Me.rbProvisiones.AllowShowFocusCues = True
        Me.rbProvisiones.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.rbProvisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProvisiones.Location = New System.Drawing.Point(11, 71)
        Me.rbProvisiones.Name = "rbProvisiones"
        Me.rbProvisiones.RadioCheckAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbProvisiones.Size = New System.Drawing.Size(97, 18)
        Me.rbProvisiones.TabIndex = 1
        Me.rbProvisiones.Text = "Provisiones"
        Me.rbProvisiones.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbProvisiones.ThemeName = "Aqua"
        '
        'rbCtasCtes
        '
        Me.rbCtasCtes.AllowShowFocusCues = True
        Me.rbCtasCtes.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.rbCtasCtes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCtasCtes.IsChecked = True
        Me.rbCtasCtes.Location = New System.Drawing.Point(11, 47)
        Me.rbCtasCtes.Name = "rbCtasCtes"
        Me.rbCtasCtes.RadioCheckAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbCtasCtes.Size = New System.Drawing.Size(97, 18)
        Me.rbCtasCtes.TabIndex = 0
        Me.rbCtasCtes.Text = "Ctas.Ctes."
        Me.rbCtasCtes.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.rbCtasCtes.ThemeName = "Aqua"
        Me.rbCtasCtes.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'biCancelar
        '
        Me.biCancelar.AllowShowFocusCues = True
        Me.biCancelar.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.biCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCancelar.Location = New System.Drawing.Point(189, 234)
        Me.biCancelar.Name = "biCancelar"
        Me.biCancelar.Size = New System.Drawing.Size(82, 23)
        Me.biCancelar.TabIndex = 126
        Me.biCancelar.Text = "Cancelar"
        Me.biCancelar.ThemeName = "Office2007Silver"
        '
        'biAceptar
        '
        Me.biAceptar.AllowShowFocusCues = True
        Me.biAceptar.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.biAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.biAceptar.Location = New System.Drawing.Point(74, 234)
        Me.biAceptar.Name = "biAceptar"
        Me.biAceptar.Size = New System.Drawing.Size(83, 23)
        Me.biAceptar.TabIndex = 125
        Me.biAceptar.Text = "Aceptar"
        Me.biAceptar.ThemeName = "Office2007Silver"
        '
        'frmRepVencimientosDetalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(355, 269)
        Me.Controls.Add(Me.biCancelar)
        Me.Controls.Add(Me.biAceptar)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.cmbDocu)
        Me.Controls.Add(Me.RadLabel4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbCodMon)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepVencimientosDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Acumulado de Vencimientos"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.cmbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDocu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        CType(Me.rbTodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbCastigos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbProvisiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbCtasCtes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.biCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.biAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents Office2007SilverTheme1 As Telerik.WinControls.Themes.Office2007SilverTheme
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbDocu As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents rbTodos As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents rbCastigos As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents rbProvisiones As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents rbCtasCtes As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents biCancelar As Telerik.WinControls.UI.RadButton
    Friend WithEvents biAceptar As Telerik.WinControls.UI.RadButton
End Class
