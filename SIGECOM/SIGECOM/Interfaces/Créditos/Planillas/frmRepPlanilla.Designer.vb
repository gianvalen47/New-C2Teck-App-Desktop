<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepPlanilla
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
        Dim cmbCobrador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepPlanilla))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cmbCobrador = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.biCancelar = New Telerik.WinControls.UI.RadButton
        Me.biAceptar = New Telerik.WinControls.UI.RadButton
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme
        Me.Office2007SilverTheme1 = New Telerik.WinControls.Themes.Office2007SilverTheme
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.cmbCobrador, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.RadGroupBox1.Controls.Add(Me.cmbCobrador)
        Me.RadGroupBox1.Controls.Add(Me.Label1)
        Me.RadGroupBox1.Controls.Add(Me.biCancelar)
        Me.RadGroupBox1.Controls.Add(Me.biAceptar)
        Me.RadGroupBox1.Controls.Add(Me.Label12)
        Me.RadGroupBox1.Controls.Add(Me.Label13)
        Me.RadGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = "Planillas"
        Me.RadGroupBox1.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox1.Location = New System.Drawing.Point(6, 5)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(353, 236)
        Me.RadGroupBox1.TabIndex = 9
        Me.RadGroupBox1.Text = "Planillas"
        Me.RadGroupBox1.ThemeName = "ControlDefault"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(246, 48)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 103
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
        Me.cbFecInicio.Location = New System.Drawing.Point(97, 48)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 102
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbCobrador
        '
        Me.cmbCobrador.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCobrador_DesignTimeLayout.LayoutString = resources.GetString("cmbCobrador_DesignTimeLayout.LayoutString")
        Me.cmbCobrador.DesignTimeLayout = cmbCobrador_DesignTimeLayout
        Me.cmbCobrador.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbCobrador.Location = New System.Drawing.Point(97, 109)
        Me.cmbCobrador.Name = "cmbCobrador"
        Me.cmbCobrador.SelectedIndex = -1
        Me.cmbCobrador.SelectedItem = Nothing
        Me.cmbCobrador.Size = New System.Drawing.Size(250, 20)
        Me.cmbCobrador.TabIndex = 101
        Me.cmbCobrador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Vendedor :"
        '
        'biCancelar
        '
        Me.biCancelar.AllowShowFocusCues = True
        Me.biCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCancelar.Location = New System.Drawing.Point(204, 174)
        Me.biCancelar.Name = "biCancelar"
        Me.biCancelar.Size = New System.Drawing.Size(84, 30)
        Me.biCancelar.TabIndex = 27
        Me.biCancelar.Text = "Cancelar"
        Me.biCancelar.ThemeName = "Office2007Silver"
        '
        'biAceptar
        '
        Me.biAceptar.AllowShowFocusCues = True
        Me.biAceptar.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.biAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.biAceptar.Location = New System.Drawing.Point(69, 174)
        Me.biAceptar.Name = "biAceptar"
        Me.biAceptar.Size = New System.Drawing.Size(85, 30)
        Me.biAceptar.TabIndex = 26
        Me.biAceptar.Text = "Aceptar"
        Me.biAceptar.ThemeName = "Office2007Silver"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(210, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 16)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Al :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 16)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Fecha Del :"
        '
        'frmRepPlanilla
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(365, 248)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(373, 282)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(373, 282)
        Me.Name = "frmRepPlanilla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Planilla"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.cmbCobrador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.biCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.biAceptar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents biCancelar As Telerik.WinControls.UI.RadButton
    Friend WithEvents biAceptar As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCobrador As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents Office2007SilverTheme1 As Telerik.WinControls.Themes.Office2007SilverTheme
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
End Class
