<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmConfigurarHora
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmbDateFormats As System.Windows.Forms.ComboBox
    Public WithEvents cmdGetTime As System.Windows.Forms.Button
    Public WithEvents cmdUpdateFirmware As System.Windows.Forms.Button
    Public WithEvents cmdDateFormat As System.Windows.Forms.Button
    Public WithEvents txtSecond As System.Windows.Forms.TextBox
    Public WithEvents txtMinute As System.Windows.Forms.TextBox
    Public WithEvents txtHour As System.Windows.Forms.TextBox
    Public WithEvents cmdSetDeviceTime As System.Windows.Forms.Button
    Public WithEvents txtDay As System.Windows.Forms.TextBox
    Public WithEvents txtMonth As System.Windows.Forms.TextBox
    Public WithEvents txtYear As System.Windows.Forms.TextBox
    Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents lblInfo As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConfigurarHora))
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.cmbDateFormats = New System.Windows.Forms.ComboBox
        Me.cmdGetTime = New System.Windows.Forms.Button
        Me.cmdUpdateFirmware = New System.Windows.Forms.Button
        Me.cmdDateFormat = New System.Windows.Forms.Button
        Me.txtSecond = New System.Windows.Forms.TextBox
        Me.txtMinute = New System.Windows.Forms.TextBox
        Me.txtHour = New System.Windows.Forms.TextBox
        Me.cmdSetDeviceTime = New System.Windows.Forms.Button
        Me.txtDay = New System.Windows.Forms.TextBox
        Me.txtMonth = New System.Windows.Forms.TextBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblInfo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        Me.ToolTip1.Active = True
        Me.Text = "Configurar Horario del Relog"
        Me.ClientSize = New System.Drawing.Size(439, 175)
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Icon = CType(resources.GetObject("frm2.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.ControlBox = True
        Me.Enabled = True
        Me.KeyPreview = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = True
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "frm2"
        Me.cmbDateFormats.Size = New System.Drawing.Size(137, 21)
        Me.cmbDateFormats.Location = New System.Drawing.Point(16, 120)
        Me.cmbDateFormats.Items.AddRange(New Object() {"YY-MM-DD", "YY/MM/DD", "YY.MM.DD", "MM-DD-YY", "MM/DD/YY", "MM.DD.YY", "DD-MM-YY", "DD/MM/YY", "DD.MM.YY", "YYYYMMDD"})
        Me.cmbDateFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDateFormats.TabIndex = 15
        Me.cmbDateFormats.BackColor = System.Drawing.SystemColors.Window
        Me.cmbDateFormats.CausesValidation = True
        Me.cmbDateFormats.Enabled = True
        Me.cmbDateFormats.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbDateFormats.IntegralHeight = True
        Me.cmbDateFormats.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDateFormats.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDateFormats.Sorted = False
        Me.cmbDateFormats.TabStop = True
        Me.cmbDateFormats.Visible = True
        Me.cmbDateFormats.Name = "cmbDateFormats"
        Me.cmdGetTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdGetTime.Text = "Ver Hora del Relog"
        Me.cmdGetTime.Size = New System.Drawing.Size(121, 25)
        Me.cmdGetTime.Location = New System.Drawing.Point(176, 56)
        Me.cmdGetTime.TabIndex = 13
        Me.cmdGetTime.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGetTime.CausesValidation = True
        Me.cmdGetTime.Enabled = True
        Me.cmdGetTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGetTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGetTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGetTime.TabStop = True
        Me.cmdGetTime.Name = "cmdGetTime"
        Me.cmdUpdateFirmware.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdUpdateFirmware.Text = "Actualizar Firmware"
        Me.cmdUpdateFirmware.Size = New System.Drawing.Size(105, 25)
        Me.cmdUpdateFirmware.Location = New System.Drawing.Point(320, 40)
        Me.cmdUpdateFirmware.TabIndex = 12
        Me.cmdUpdateFirmware.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdateFirmware.CausesValidation = True
        Me.cmdUpdateFirmware.Enabled = True
        Me.cmdUpdateFirmware.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpdateFirmware.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpdateFirmware.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpdateFirmware.TabStop = True
        Me.cmdUpdateFirmware.Name = "cmdUpdateFirmware"
        Me.cmdDateFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdDateFormat.Text = "Cambiar Formato de Fecha Delimitado"
        Me.cmdDateFormat.Size = New System.Drawing.Size(121, 33)
        Me.cmdDateFormat.Location = New System.Drawing.Point(176, 100)
        Me.cmdDateFormat.TabIndex = 10
        Me.cmdDateFormat.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDateFormat.CausesValidation = True
        Me.cmdDateFormat.Enabled = True
        Me.cmdDateFormat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDateFormat.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDateFormat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDateFormat.TabStop = True
        Me.cmdDateFormat.Name = "cmdDateFormat"
        Me.txtSecond.AutoSize = False
        Me.txtSecond.Size = New System.Drawing.Size(41, 19)
        Me.txtSecond.Location = New System.Drawing.Point(96, 64)
        Me.txtSecond.TabIndex = 6
        Me.txtSecond.Text = "0"
        Me.txtSecond.AcceptsReturn = True
        Me.txtSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSecond.BackColor = System.Drawing.SystemColors.Window
        Me.txtSecond.CausesValidation = True
        Me.txtSecond.Enabled = True
        Me.txtSecond.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSecond.HideSelection = True
        Me.txtSecond.ReadOnly = False
        Me.txtSecond.Maxlength = 0
        Me.txtSecond.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSecond.MultiLine = False
        Me.txtSecond.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSecond.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSecond.TabStop = True
        Me.txtSecond.Visible = True
        Me.txtSecond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtSecond.Name = "txtSecond"
        Me.txtMinute.AutoSize = False
        Me.txtMinute.Size = New System.Drawing.Size(33, 19)
        Me.txtMinute.Location = New System.Drawing.Point(56, 64)
        Me.txtMinute.TabIndex = 5
        Me.txtMinute.Text = "20"
        Me.txtMinute.AcceptsReturn = True
        Me.txtMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMinute.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinute.CausesValidation = True
        Me.txtMinute.Enabled = True
        Me.txtMinute.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMinute.HideSelection = True
        Me.txtMinute.ReadOnly = False
        Me.txtMinute.Maxlength = 0
        Me.txtMinute.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMinute.MultiLine = False
        Me.txtMinute.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMinute.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtMinute.TabStop = True
        Me.txtMinute.Visible = True
        Me.txtMinute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtMinute.Name = "txtMinute"
        Me.txtHour.AutoSize = False
        Me.txtHour.Size = New System.Drawing.Size(33, 19)
        Me.txtHour.Location = New System.Drawing.Point(16, 64)
        Me.txtHour.TabIndex = 4
        Me.txtHour.Text = "12"
        Me.txtHour.AcceptsReturn = True
        Me.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtHour.BackColor = System.Drawing.SystemColors.Window
        Me.txtHour.CausesValidation = True
        Me.txtHour.Enabled = True
        Me.txtHour.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHour.HideSelection = True
        Me.txtHour.ReadOnly = False
        Me.txtHour.Maxlength = 0
        Me.txtHour.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHour.MultiLine = False
        Me.txtHour.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHour.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtHour.TabStop = True
        Me.txtHour.Visible = True
        Me.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtHour.Name = "txtHour"
        Me.cmdSetDeviceTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdSetDeviceTime.Text = "Cambiar Hora"
        Me.cmdSetDeviceTime.Size = New System.Drawing.Size(121, 25)
        Me.cmdSetDeviceTime.Location = New System.Drawing.Point(176, 24)
        Me.cmdSetDeviceTime.TabIndex = 3
        Me.cmdSetDeviceTime.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSetDeviceTime.CausesValidation = True
        Me.cmdSetDeviceTime.Enabled = True
        Me.cmdSetDeviceTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSetDeviceTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSetDeviceTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSetDeviceTime.TabStop = True
        Me.cmdSetDeviceTime.Name = "cmdSetDeviceTime"
        Me.txtDay.AutoSize = False
        Me.txtDay.Size = New System.Drawing.Size(41, 19)
        Me.txtDay.Location = New System.Drawing.Point(16, 24)
        Me.txtDay.TabIndex = 2
        Me.txtDay.Text = "12"
        Me.txtDay.AcceptsReturn = True
        Me.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDay.BackColor = System.Drawing.SystemColors.Window
        Me.txtDay.CausesValidation = True
        Me.txtDay.Enabled = True
        Me.txtDay.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDay.HideSelection = True
        Me.txtDay.ReadOnly = False
        Me.txtDay.Maxlength = 0
        Me.txtDay.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDay.MultiLine = False
        Me.txtDay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDay.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtDay.TabStop = True
        Me.txtDay.Visible = True
        Me.txtDay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtDay.Name = "txtDay"
        Me.txtMonth.AutoSize = False
        Me.txtMonth.Size = New System.Drawing.Size(41, 19)
        Me.txtMonth.Location = New System.Drawing.Point(64, 24)
        Me.txtMonth.TabIndex = 1
        Me.txtMonth.Text = "2"
        Me.txtMonth.AcceptsReturn = True
        Me.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtMonth.BackColor = System.Drawing.SystemColors.Window
        Me.txtMonth.CausesValidation = True
        Me.txtMonth.Enabled = True
        Me.txtMonth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMonth.HideSelection = True
        Me.txtMonth.ReadOnly = False
        Me.txtMonth.Maxlength = 0
        Me.txtMonth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMonth.MultiLine = False
        Me.txtMonth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMonth.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtMonth.TabStop = True
        Me.txtMonth.Visible = True
        Me.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtMonth.Name = "txtMonth"
        Me.txtYear.AutoSize = False
        Me.txtYear.Size = New System.Drawing.Size(49, 19)
        Me.txtYear.Location = New System.Drawing.Point(112, 24)
        Me.txtYear.TabIndex = 0
        Me.txtYear.Text = "2007"
        Me.txtYear.AcceptsReturn = True
        Me.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtYear.BackColor = System.Drawing.SystemColors.Window
        Me.txtYear.CausesValidation = True
        Me.txtYear.Enabled = True
        Me.txtYear.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtYear.HideSelection = True
        Me.txtYear.ReadOnly = False
        Me.txtYear.Maxlength = 0
        Me.txtYear.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtYear.MultiLine = False
        Me.txtYear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtYear.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtYear.TabStop = True
        Me.txtYear.Visible = True
        Me.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtYear.Name = "txtYear"
        Me.CommonDialog1Open.DefaultExt = "cfg"
        Me.CommonDialog1Open.Title = "Select The Firmware File"
        Me.CommonDialog1Open.FileName = "emfw.cfg"
        Me.CommonDialog1Open.Filter = "Firmware File|*.cfg"
        Me.Label6.Text = "Label3"
        Me.Label6.Size = New System.Drawing.Size(121, 17)
        Me.Label6.Location = New System.Drawing.Point(312, 96)
        Me.Label6.TabIndex = 14
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Enabled = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.UseMnemonic = True
        Me.Label6.Visible = True
        Me.Label6.AutoSize = False
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label6.Name = "Label6"
        Me.Label4.Text = "Formatos de Fecha Delimitado"
        Me.Label4.Size = New System.Drawing.Size(153, 17)
        Me.Label4.Location = New System.Drawing.Point(12, 100)
        Me.Label4.TabIndex = 11
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Enabled = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.UseMnemonic = True
        Me.Label4.Visible = True
        Me.Label4.AutoSize = False
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label4.Name = "Label4"
        Me.lblInfo.Text = "Information"
        Me.lblInfo.Size = New System.Drawing.Size(321, 17)
        Me.lblInfo.Location = New System.Drawing.Point(8, 152)
        Me.lblInfo.TabIndex = 9
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblInfo.BackColor = System.Drawing.SystemColors.Control
        Me.lblInfo.Enabled = True
        Me.lblInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblInfo.UseMnemonic = True
        Me.lblInfo.Visible = True
        Me.lblInfo.AutoSize = False
        Me.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblInfo.Name = "lblInfo"
        Me.Label2.Text = "Hour      Minute   Second"
        Me.Label2.Size = New System.Drawing.Size(153, 17)
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.TabIndex = 8
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Enabled = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.UseMnemonic = True
        Me.Label2.Visible = True
        Me.Label2.AutoSize = False
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label2.Name = "Label2"
        Me.Label1.Text = "Dia           Mes          Año"
        Me.Label1.Size = New System.Drawing.Size(153, 17)
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.TabIndex = 7
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Enabled = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.UseMnemonic = True
        Me.Label1.Visible = True
        Me.Label1.AutoSize = False
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Label1.Name = "Label1"
        Me.Controls.Add(cmbDateFormats)
        Me.Controls.Add(cmdGetTime)
        Me.Controls.Add(cmdUpdateFirmware)
        Me.Controls.Add(cmdDateFormat)
        Me.Controls.Add(txtSecond)
        Me.Controls.Add(txtMinute)
        Me.Controls.Add(txtHour)
        Me.Controls.Add(cmdSetDeviceTime)
        Me.Controls.Add(txtDay)
        Me.Controls.Add(txtMonth)
        Me.Controls.Add(txtYear)
        Me.Controls.Add(Label6)
        Me.Controls.Add(Label4)
        Me.Controls.Add(lblInfo)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
#End Region
End Class