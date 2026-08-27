<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmConfigurarLector
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
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents cmdGetSN As System.Windows.Forms.Button
    Public WithEvents txtFPTepLate1 As System.Windows.Forms.TextBox
    Public WithEvents CmdFPConver As System.Windows.Forms.Button
    Public WithEvents txtFPTepLate As System.Windows.Forms.TextBox
    Public WithEvents txtDisableDeviceT As System.Windows.Forms.TextBox
    Public WithEvents cmdDisableDT As System.Windows.Forms.Button
    Public WithEvents cmdBeep As System.Windows.Forms.Button
    Public WithEvents cmdPlayVoiceByIndex As System.Windows.Forms.Button
    Public WithEvents cmdRestartDevice As System.Windows.Forms.Button
    Public WithEvents txtProductCode As System.Windows.Forms.TextBox
    Public WithEvents cmdGetProductCode As System.Windows.Forms.Button
    Public WithEvents txtSDeviceMAC As System.Windows.Forms.TextBox
    Public WithEvents cmdSetDeviceMAC As System.Windows.Forms.Button
    Public WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Public WithEvents cmdGetSerialNumber As System.Windows.Forms.Button
    Public WithEvents txtGetDeviceMAC As System.Windows.Forms.TextBox
    Public WithEvents cmdGetDeviceMAC As System.Windows.Forms.Button
    Public WithEvents txtSetIP As System.Windows.Forms.TextBox
    Public WithEvents cmdSetDeviceIP As System.Windows.Forms.Button
    Public WithEvents txtDeviceIP As System.Windows.Forms.TextBox
    Public WithEvents cmdGetDeviceIP As System.Windows.Forms.Button
    Public WithEvents cmdGetDevInfo As System.Windows.Forms.Button
    Public WithEvents ls2 As System.Windows.Forms.ListBox
    Public WithEvents cmdWriteLcd As System.Windows.Forms.Button
    Public WithEvents ls1 As System.Windows.Forms.ListBox
    Public WithEvents cmdGetDeviStat As System.Windows.Forms.Button
    Public WithEvents cmdDisEnableClock As System.Windows.Forms.Button
    Public WithEvents cmdEnableClock As System.Windows.Forms.Button
    Public WithEvents cmdDisEnable As System.Windows.Forms.Button
    Public WithEvents cmdEnable As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConfigurarLector))
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.Command1 = New System.Windows.Forms.Button
        Me.cmdGetSN = New System.Windows.Forms.Button
        Me.txtFPTepLate1 = New System.Windows.Forms.TextBox
        Me.CmdFPConver = New System.Windows.Forms.Button
        Me.txtFPTepLate = New System.Windows.Forms.TextBox
        Me.txtDisableDeviceT = New System.Windows.Forms.TextBox
        Me.cmdDisableDT = New System.Windows.Forms.Button
        Me.cmdBeep = New System.Windows.Forms.Button
        Me.cmdPlayVoiceByIndex = New System.Windows.Forms.Button
        Me.cmdRestartDevice = New System.Windows.Forms.Button
        Me.txtProductCode = New System.Windows.Forms.TextBox
        Me.cmdGetProductCode = New System.Windows.Forms.Button
        Me.txtSDeviceMAC = New System.Windows.Forms.TextBox
        Me.cmdSetDeviceMAC = New System.Windows.Forms.Button
        Me.txtSerialNumber = New System.Windows.Forms.TextBox
        Me.cmdGetSerialNumber = New System.Windows.Forms.Button
        Me.txtGetDeviceMAC = New System.Windows.Forms.TextBox
        Me.cmdGetDeviceMAC = New System.Windows.Forms.Button
        Me.txtSetIP = New System.Windows.Forms.TextBox
        Me.cmdSetDeviceIP = New System.Windows.Forms.Button
        Me.txtDeviceIP = New System.Windows.Forms.TextBox
        Me.cmdGetDeviceIP = New System.Windows.Forms.Button
        Me.cmdGetDevInfo = New System.Windows.Forms.Button
        Me.ls2 = New System.Windows.Forms.ListBox
        Me.cmdWriteLcd = New System.Windows.Forms.Button
        Me.ls1 = New System.Windows.Forms.ListBox
        Me.cmdGetDeviStat = New System.Windows.Forms.Button
        Me.cmdDisEnableClock = New System.Windows.Forms.Button
        Me.cmdEnableClock = New System.Windows.Forms.Button
        Me.cmdDisEnable = New System.Windows.Forms.Button
        Me.cmdEnable = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        Me.ToolTip1.Active = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Configurar Relog"
        Me.ClientSize = New System.Drawing.Size(566, 539)
        Me.Location = New System.Drawing.Point(222, 99)
        Me.Icon = CType(resources.GetObject("frm3.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
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
        Me.Name = "frm3"
        Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Command1.Text = "Apagar Equipo"
        Me.Command1.Size = New System.Drawing.Size(113, 25)
        Me.Command1.Location = New System.Drawing.Point(128, 184)
        Me.Command1.TabIndex = 32
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.CausesValidation = True
        Me.Command1.Enabled = True
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.TabStop = True
        Me.Command1.Name = "Command1"
        Me.cmdGetSN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdGetSN.Text = "GetSensorSN"
        Me.cmdGetSN.Size = New System.Drawing.Size(105, 25)
        Me.cmdGetSN.Location = New System.Drawing.Point(272, 456)
        Me.cmdGetSN.TabIndex = 31
        Me.cmdGetSN.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGetSN.CausesValidation = True
        Me.cmdGetSN.Enabled = True
        Me.cmdGetSN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGetSN.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGetSN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGetSN.TabStop = True
        Me.cmdGetSN.Name = "cmdGetSN"
        Me.txtFPTepLate1.AutoSize = False
        Me.txtFPTepLate1.Size = New System.Drawing.Size(169, 105)
        Me.txtFPTepLate1.Location = New System.Drawing.Point(392, 432)
        Me.txtFPTepLate1.MultiLine = True
        Me.txtFPTepLate1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFPTepLate1.TabIndex = 29
        Me.txtFPTepLate1.Text = "Text1"
        Me.txtFPTepLate1.AcceptsReturn = True
        Me.txtFPTepLate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtFPTepLate1.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPTepLate1.CausesValidation = True
        Me.txtFPTepLate1.Enabled = True
        Me.txtFPTepLate1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFPTepLate1.HideSelection = True
        Me.txtFPTepLate1.ReadOnly = False
        Me.txtFPTepLate1.Maxlength = 0
        Me.txtFPTepLate1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFPTepLate1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFPTepLate1.TabStop = True
        Me.txtFPTepLate1.Visible = True
        Me.txtFPTepLate1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtFPTepLate1.Name = "txtFPTepLate1"
        Me.CmdFPConver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CmdFPConver.Text = "FPconverToBiokey"
        Me.CmdFPConver.Size = New System.Drawing.Size(113, 25)
        Me.CmdFPConver.Location = New System.Drawing.Point(272, 416)
        Me.CmdFPConver.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.CmdFPConver, "convert finger template to other template that it was used by Biokey SDK")
        Me.CmdFPConver.BackColor = System.Drawing.SystemColors.Control
        Me.CmdFPConver.CausesValidation = True
        Me.CmdFPConver.Enabled = True
        Me.CmdFPConver.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdFPConver.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdFPConver.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdFPConver.TabStop = True
        Me.CmdFPConver.Name = "CmdFPConver"
        Me.txtFPTepLate.AutoSize = False
        Me.txtFPTepLate.Size = New System.Drawing.Size(169, 89)
        Me.txtFPTepLate.Location = New System.Drawing.Point(392, 312)
        Me.txtFPTepLate.MultiLine = True
        Me.txtFPTepLate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFPTepLate.TabIndex = 26
        Me.txtFPTepLate.Text = "ocojg52rWoEOOq1egQw1rEtB" & Chr(13) & Chr(10) & "Fp4uRAESmkBLQRZ0wlLBB2" & Chr(13) & Chr(10) & "1BKUEM3EIuQTPmKGhBCCm" & Chr(13) & Chr(10) & "8fEkdw7MnQRE6QCXBC9DD" & Chr(13) & Chr(10) & "VVEE3Kk3QR0iFjvBDRJAckE" & Chr(13) & Chr(10) & "Mz5VggQYbMn1BDy8uKwkN" & Chr(13) & Chr(10) & "MItPyQ0VL0uBSJozS4FQhR8" & Chr(13) & Chr(10) & "/ARSDoTHBIl0sIYEKQKYlghJ" & Chr(13) & Chr(10) & "DoxlBD02aKcERZJwaQRBbhi" & Chr(13) & Chr(10) & "oBKHkRS4EJhyUygVtEozPBP" & Chr(13) & Chr(10) & "wi4PsEQij5DQQl8HXQJDZtkL" & Chr(13) & Chr(10) & "BOrMM8LEBHCAgQPFBgPBo" & Chr(13) & Chr(10) & "HAwgKjrfxTfBfAwgIEDKLaiZw" & Chr(13) & Chr(10) & "dwMF1pKzLrMuqIcDBc6WZ6" & Chr(13) & Chr(10) & "93rmJrAwW+km87vzJmCwMF" & Chr(13) & Chr(10) & "moa3/DBWjy5qG" & Chr(13) & Chr(10)
        Me.txtFPTepLate.AcceptsReturn = True
        Me.txtFPTepLate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtFPTepLate.BackColor = System.Drawing.SystemColors.Window
        Me.txtFPTepLate.CausesValidation = True
        Me.txtFPTepLate.Enabled = True
        Me.txtFPTepLate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFPTepLate.HideSelection = True
        Me.txtFPTepLate.ReadOnly = False
        Me.txtFPTepLate.Maxlength = 0
        Me.txtFPTepLate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFPTepLate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFPTepLate.TabStop = True
        Me.txtFPTepLate.Visible = True
        Me.txtFPTepLate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtFPTepLate.Name = "txtFPTepLate"
        Me.txtDisableDeviceT.AutoSize = False
        Me.txtDisableDeviceT.Size = New System.Drawing.Size(121, 25)
        Me.txtDisableDeviceT.Location = New System.Drawing.Point(424, 256)
        Me.txtDisableDeviceT.TabIndex = 25
        Me.txtDisableDeviceT.AcceptsReturn = True
        Me.txtDisableDeviceT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDisableDeviceT.BackColor = System.Drawing.SystemColors.Window
        Me.txtDisableDeviceT.CausesValidation = True
        Me.txtDisableDeviceT.Enabled = True
        Me.txtDisableDeviceT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDisableDeviceT.HideSelection = True
        Me.txtDisableDeviceT.ReadOnly = False
        Me.txtDisableDeviceT.Maxlength = 0
        Me.txtDisableDeviceT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDisableDeviceT.MultiLine = False
        Me.txtDisableDeviceT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDisableDeviceT.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtDisableDeviceT.TabStop = True
        Me.txtDisableDeviceT.Visible = True
        Me.txtDisableDeviceT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDisableDeviceT.Name = "txtDisableDeviceT"
        Me.cmdDisableDT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdDisableDT.Text = " DisableDeviceWithTimeOut"
        Me.cmdDisableDT.Size = New System.Drawing.Size(145, 25)
        Me.cmdDisableDT.Location = New System.Drawing.Point(272, 256)
        Me.cmdDisableDT.TabIndex = 24
        Me.cmdDisableDT.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDisableDT.CausesValidation = True
        Me.cmdDisableDT.Enabled = True
        Me.cmdDisableDT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDisableDT.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDisableDT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDisableDT.TabStop = True
        Me.cmdDisableDT.Name = "cmdDisableDT"
        Me.cmdBeep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdBeep.Text = "Beep"
        Me.cmdBeep.Size = New System.Drawing.Size(105, 25)
        Me.cmdBeep.Location = New System.Drawing.Point(272, 376)
        Me.cmdBeep.TabIndex = 23
        Me.cmdBeep.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBeep.CausesValidation = True
        Me.cmdBeep.Enabled = True
        Me.cmdBeep.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBeep.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBeep.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBeep.TabStop = True
        Me.cmdBeep.Name = "cmdBeep"
        Me.cmdPlayVoiceByIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdPlayVoiceByIndex.Text = "PlayVoiceByIndex"
        Me.cmdPlayVoiceByIndex.Size = New System.Drawing.Size(105, 25)
        Me.cmdPlayVoiceByIndex.Location = New System.Drawing.Point(272, 296)
        Me.cmdPlayVoiceByIndex.TabIndex = 22
        Me.cmdPlayVoiceByIndex.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPlayVoiceByIndex.CausesValidation = True
        Me.cmdPlayVoiceByIndex.Enabled = True
        Me.cmdPlayVoiceByIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPlayVoiceByIndex.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPlayVoiceByIndex.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPlayVoiceByIndex.TabStop = True
        Me.cmdPlayVoiceByIndex.Name = "cmdPlayVoiceByIndex"
        Me.cmdRestartDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdRestartDevice.Text = "Reiniciar Equipo"
        Me.cmdRestartDevice.Size = New System.Drawing.Size(105, 25)
        Me.cmdRestartDevice.Location = New System.Drawing.Point(272, 336)
        Me.cmdRestartDevice.TabIndex = 21
        Me.cmdRestartDevice.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRestartDevice.CausesValidation = True
        Me.cmdRestartDevice.Enabled = True
        Me.cmdRestartDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRestartDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRestartDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRestartDevice.TabStop = True
        Me.cmdRestartDevice.Name = "cmdRestartDevice"
        Me.txtProductCode.AutoSize = False
        Me.txtProductCode.Enabled = False
        Me.txtProductCode.Size = New System.Drawing.Size(161, 25)
        Me.txtProductCode.Location = New System.Drawing.Point(384, 216)
        Me.txtProductCode.TabIndex = 20
        Me.txtProductCode.AcceptsReturn = True
        Me.txtProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtProductCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtProductCode.CausesValidation = True
        Me.txtProductCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtProductCode.HideSelection = True
        Me.txtProductCode.ReadOnly = False
        Me.txtProductCode.Maxlength = 0
        Me.txtProductCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductCode.MultiLine = False
        Me.txtProductCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtProductCode.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtProductCode.TabStop = True
        Me.txtProductCode.Visible = True
        Me.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductCode.Name = "txtProductCode"
        Me.cmdGetProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdGetProductCode.Text = "Codigo del Equipo"
        Me.cmdGetProductCode.Size = New System.Drawing.Size(105, 25)
        Me.cmdGetProductCode.Location = New System.Drawing.Point(272, 216)
        Me.cmdGetProductCode.TabIndex = 19
        Me.cmdGetProductCode.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGetProductCode.CausesValidation = True
        Me.cmdGetProductCode.Enabled = True
        Me.cmdGetProductCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGetProductCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGetProductCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGetProductCode.TabStop = True
        Me.cmdGetProductCode.Name = "cmdGetProductCode"
        Me.txtSDeviceMAC.AutoSize = False
        Me.txtSDeviceMAC.Size = New System.Drawing.Size(161, 25)
        Me.txtSDeviceMAC.Location = New System.Drawing.Point(384, 136)
        Me.txtSDeviceMAC.TabIndex = 18
        Me.txtSDeviceMAC.AcceptsReturn = True
        Me.txtSDeviceMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSDeviceMAC.BackColor = System.Drawing.SystemColors.Window
        Me.txtSDeviceMAC.CausesValidation = True
        Me.txtSDeviceMAC.Enabled = True
        Me.txtSDeviceMAC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSDeviceMAC.HideSelection = True
        Me.txtSDeviceMAC.ReadOnly = False
        Me.txtSDeviceMAC.Maxlength = 0
        Me.txtSDeviceMAC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSDeviceMAC.MultiLine = False
        Me.txtSDeviceMAC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSDeviceMAC.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSDeviceMAC.TabStop = True
        Me.txtSDeviceMAC.Visible = True
        Me.txtSDeviceMAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSDeviceMAC.Name = "txtSDeviceMAC"
        Me.cmdSetDeviceMAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdSetDeviceMAC.Text = "Cambiar MAC"
        Me.cmdSetDeviceMAC.Size = New System.Drawing.Size(105, 25)
        Me.cmdSetDeviceMAC.Location = New System.Drawing.Point(272, 136)
        Me.cmdSetDeviceMAC.TabIndex = 17
        Me.cmdSetDeviceMAC.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSetDeviceMAC.CausesValidation = True
        Me.cmdSetDeviceMAC.Enabled = True
        Me.cmdSetDeviceMAC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSetDeviceMAC.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSetDeviceMAC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSetDeviceMAC.TabStop = True
        Me.cmdSetDeviceMAC.Name = "cmdSetDeviceMAC"
        Me.txtSerialNumber.AutoSize = False
        Me.txtSerialNumber.Enabled = False
        Me.txtSerialNumber.Size = New System.Drawing.Size(161, 25)
        Me.txtSerialNumber.Location = New System.Drawing.Point(384, 176)
        Me.txtSerialNumber.TabIndex = 16
        Me.txtSerialNumber.AcceptsReturn = True
        Me.txtSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSerialNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtSerialNumber.CausesValidation = True
        Me.txtSerialNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSerialNumber.HideSelection = True
        Me.txtSerialNumber.ReadOnly = False
        Me.txtSerialNumber.Maxlength = 0
        Me.txtSerialNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerialNumber.MultiLine = False
        Me.txtSerialNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSerialNumber.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSerialNumber.TabStop = True
        Me.txtSerialNumber.Visible = True
        Me.txtSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.cmdGetSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdGetSerialNumber.Text = "Numero de Serie"
        Me.cmdGetSerialNumber.Size = New System.Drawing.Size(105, 25)
        Me.cmdGetSerialNumber.Location = New System.Drawing.Point(272, 176)
        Me.cmdGetSerialNumber.TabIndex = 15
        Me.cmdGetSerialNumber.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGetSerialNumber.CausesValidation = True
        Me.cmdGetSerialNumber.Enabled = True
        Me.cmdGetSerialNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGetSerialNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGetSerialNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGetSerialNumber.TabStop = True
        Me.cmdGetSerialNumber.Name = "cmdGetSerialNumber"
        Me.txtGetDeviceMAC.AutoSize = False
        Me.txtGetDeviceMAC.Enabled = False
        Me.txtGetDeviceMAC.Size = New System.Drawing.Size(161, 25)
        Me.txtGetDeviceMAC.Location = New System.Drawing.Point(384, 96)
        Me.txtGetDeviceMAC.TabIndex = 14
        Me.txtGetDeviceMAC.AcceptsReturn = True
        Me.txtGetDeviceMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtGetDeviceMAC.BackColor = System.Drawing.SystemColors.Window
        Me.txtGetDeviceMAC.CausesValidation = True
        Me.txtGetDeviceMAC.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGetDeviceMAC.HideSelection = True
        Me.txtGetDeviceMAC.ReadOnly = False
        Me.txtGetDeviceMAC.Maxlength = 0
        Me.txtGetDeviceMAC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGetDeviceMAC.MultiLine = False
        Me.txtGetDeviceMAC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGetDeviceMAC.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtGetDeviceMAC.TabStop = True
        Me.txtGetDeviceMAC.Visible = True
        Me.txtGetDeviceMAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGetDeviceMAC.Name = "txtGetDeviceMAC"
        Me.cmdGetDeviceMAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdGetDeviceMAC.Text = "Device MAC"
        Me.cmdGetDeviceMAC.Size = New System.Drawing.Size(105, 25)
        Me.cmdGetDeviceMAC.Location = New System.Drawing.Point(272, 96)
        Me.cmdGetDeviceMAC.TabIndex = 13
        Me.cmdGetDeviceMAC.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGetDeviceMAC.CausesValidation = True
        Me.cmdGetDeviceMAC.Enabled = True
        Me.cmdGetDeviceMAC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGetDeviceMAC.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGetDeviceMAC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGetDeviceMAC.TabStop = True
        Me.cmdGetDeviceMAC.Name = "cmdGetDeviceMAC"
        Me.txtSetIP.AutoSize = False
        Me.txtSetIP.Size = New System.Drawing.Size(161, 25)
        Me.txtSetIP.Location = New System.Drawing.Point(384, 56)
        Me.txtSetIP.TabIndex = 12
        Me.txtSetIP.AcceptsReturn = True
        Me.txtSetIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtSetIP.BackColor = System.Drawing.SystemColors.Window
        Me.txtSetIP.CausesValidation = True
        Me.txtSetIP.Enabled = True
        Me.txtSetIP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSetIP.HideSelection = True
        Me.txtSetIP.ReadOnly = False
        Me.txtSetIP.Maxlength = 0
        Me.txtSetIP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSetIP.MultiLine = False
        Me.txtSetIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSetIP.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtSetIP.TabStop = True
        Me.txtSetIP.Visible = True
        Me.txtSetIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSetIP.Name = "txtSetIP"
        Me.cmdSetDeviceIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdSetDeviceIP.Text = "Cambiar Dir. IP"
        Me.cmdSetDeviceIP.Size = New System.Drawing.Size(105, 25)
        Me.cmdSetDeviceIP.Location = New System.Drawing.Point(272, 56)
        Me.cmdSetDeviceIP.TabIndex = 11
        Me.cmdSetDeviceIP.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSetDeviceIP.CausesValidation = True
        Me.cmdSetDeviceIP.Enabled = True
        Me.cmdSetDeviceIP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSetDeviceIP.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSetDeviceIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSetDeviceIP.TabStop = True
        Me.cmdSetDeviceIP.Name = "cmdSetDeviceIP"
        Me.txtDeviceIP.AutoSize = False
        Me.txtDeviceIP.Enabled = False
        Me.txtDeviceIP.Size = New System.Drawing.Size(161, 25)
        Me.txtDeviceIP.Location = New System.Drawing.Point(384, 16)
        Me.txtDeviceIP.TabIndex = 10
        Me.txtDeviceIP.AcceptsReturn = True
        Me.txtDeviceIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDeviceIP.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeviceIP.CausesValidation = True
        Me.txtDeviceIP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeviceIP.HideSelection = True
        Me.txtDeviceIP.ReadOnly = False
        Me.txtDeviceIP.Maxlength = 0
        Me.txtDeviceIP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeviceIP.MultiLine = False
        Me.txtDeviceIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeviceIP.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtDeviceIP.TabStop = True
        Me.txtDeviceIP.Visible = True
        Me.txtDeviceIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeviceIP.Name = "txtDeviceIP"
        Me.cmdGetDeviceIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdGetDeviceIP.Text = "Direccion IP"
        Me.cmdGetDeviceIP.Size = New System.Drawing.Size(105, 25)
        Me.cmdGetDeviceIP.Location = New System.Drawing.Point(272, 16)
        Me.cmdGetDeviceIP.TabIndex = 9
        Me.cmdGetDeviceIP.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGetDeviceIP.CausesValidation = True
        Me.cmdGetDeviceIP.Enabled = True
        Me.cmdGetDeviceIP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGetDeviceIP.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGetDeviceIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGetDeviceIP.TabStop = True
        Me.cmdGetDeviceIP.Name = "cmdGetDeviceIP"
        Me.cmdGetDevInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdGetDevInfo.Text = "Informacion Lector"
        Me.cmdGetDevInfo.Size = New System.Drawing.Size(97, 25)
        Me.cmdGetDevInfo.Location = New System.Drawing.Point(8, 192)
        Me.cmdGetDevInfo.TabIndex = 8
        Me.cmdGetDevInfo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGetDevInfo.CausesValidation = True
        Me.cmdGetDevInfo.Enabled = True
        Me.cmdGetDevInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGetDevInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGetDevInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGetDevInfo.TabStop = True
        Me.cmdGetDevInfo.Name = "cmdGetDevInfo"
        Me.ls2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ls2.Size = New System.Drawing.Size(257, 291)
        Me.ls2.Location = New System.Drawing.Point(8, 216)
        Me.ls2.TabIndex = 7
        Me.ls2.BackColor = System.Drawing.SystemColors.Window
        Me.ls2.CausesValidation = True
        Me.ls2.Enabled = True
        Me.ls2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ls2.IntegralHeight = True
        Me.ls2.Cursor = System.Windows.Forms.Cursors.Default
        Me.ls2.SelectionMode = System.Windows.Forms.SelectionMode.One
        Me.ls2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ls2.Sorted = False
        Me.ls2.TabStop = True
        Me.ls2.Visible = True
        Me.ls2.MultiColumn = False
        Me.ls2.Name = "ls2"
        Me.cmdWriteLcd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdWriteLcd.Text = "Excribir LCD"
        Me.cmdWriteLcd.Size = New System.Drawing.Size(97, 25)
        Me.cmdWriteLcd.Location = New System.Drawing.Point(8, 112)
        Me.cmdWriteLcd.TabIndex = 6
        Me.cmdWriteLcd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdWriteLcd.CausesValidation = True
        Me.cmdWriteLcd.Enabled = True
        Me.cmdWriteLcd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdWriteLcd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdWriteLcd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdWriteLcd.TabStop = True
        Me.cmdWriteLcd.Name = "cmdWriteLcd"
        Me.ls1.Size = New System.Drawing.Size(153, 163)
        Me.ls1.Location = New System.Drawing.Point(112, 16)
        Me.ls1.TabIndex = 5
        Me.ls1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ls1.BackColor = System.Drawing.SystemColors.Window
        Me.ls1.CausesValidation = True
        Me.ls1.Enabled = True
        Me.ls1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ls1.IntegralHeight = True
        Me.ls1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ls1.SelectionMode = System.Windows.Forms.SelectionMode.One
        Me.ls1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ls1.Sorted = False
        Me.ls1.TabStop = True
        Me.ls1.Visible = True
        Me.ls1.MultiColumn = False
        Me.ls1.Name = "ls1"
        Me.cmdGetDeviStat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdGetDeviStat.Text = "Estado del Lector"
        Me.cmdGetDeviStat.Size = New System.Drawing.Size(97, 25)
        Me.cmdGetDeviStat.Location = New System.Drawing.Point(8, 160)
        Me.cmdGetDeviStat.TabIndex = 4
        Me.cmdGetDeviStat.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGetDeviStat.CausesValidation = True
        Me.cmdGetDeviStat.Enabled = True
        Me.cmdGetDeviStat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGetDeviStat.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGetDeviStat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGetDeviStat.TabStop = True
        Me.cmdGetDeviStat.Name = "cmdGetDeviStat"
        Me.cmdDisEnableClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdDisEnableClock.Text = "Desabilitar Relog"
        Me.cmdDisEnableClock.Size = New System.Drawing.Size(97, 25)
        Me.cmdDisEnableClock.Location = New System.Drawing.Point(8, 88)
        Me.cmdDisEnableClock.TabIndex = 3
        Me.cmdDisEnableClock.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDisEnableClock.CausesValidation = True
        Me.cmdDisEnableClock.Enabled = True
        Me.cmdDisEnableClock.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDisEnableClock.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDisEnableClock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDisEnableClock.TabStop = True
        Me.cmdDisEnableClock.Name = "cmdDisEnableClock"
        Me.cmdEnableClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdEnableClock.Text = "Habilitar Relog"
        Me.cmdEnableClock.Size = New System.Drawing.Size(97, 25)
        Me.cmdEnableClock.Location = New System.Drawing.Point(8, 64)
        Me.cmdEnableClock.TabIndex = 2
        Me.cmdEnableClock.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEnableClock.CausesValidation = True
        Me.cmdEnableClock.Enabled = True
        Me.cmdEnableClock.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEnableClock.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEnableClock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEnableClock.TabStop = True
        Me.cmdEnableClock.Name = "cmdEnableClock"
        Me.cmdDisEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdDisEnable.Text = "Desabilitar Lector"
        Me.cmdDisEnable.Size = New System.Drawing.Size(97, 25)
        Me.cmdDisEnable.Location = New System.Drawing.Point(8, 40)
        Me.cmdDisEnable.TabIndex = 1
        Me.cmdDisEnable.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDisEnable.CausesValidation = True
        Me.cmdDisEnable.Enabled = True
        Me.cmdDisEnable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDisEnable.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDisEnable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDisEnable.TabStop = True
        Me.cmdDisEnable.Name = "cmdDisEnable"
        Me.cmdEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdEnable.Text = "Habilitar Lector"
        Me.cmdEnable.Size = New System.Drawing.Size(97, 25)
        Me.cmdEnable.Location = New System.Drawing.Point(8, 16)
        Me.cmdEnable.TabIndex = 0
        Me.cmdEnable.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEnable.CausesValidation = True
        Me.cmdEnable.Enabled = True
        Me.cmdEnable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEnable.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEnable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEnable.TabStop = True
        Me.cmdEnable.Name = "cmdEnable"
        Me.Label2.Text = "finger template for BIOKEY SDK"
        Me.Label2.Size = New System.Drawing.Size(169, 17)
        Me.Label2.Location = New System.Drawing.Point(392, 416)
        Me.Label2.TabIndex = 30
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
        Me.Label1.Text = "finger template for machine"
        Me.Label1.Size = New System.Drawing.Size(169, 25)
        Me.Label1.Location = New System.Drawing.Point(392, 288)
        Me.Label1.TabIndex = 27
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
        Me.Controls.Add(Command1)
        Me.Controls.Add(cmdGetSN)
        Me.Controls.Add(txtFPTepLate1)
        Me.Controls.Add(CmdFPConver)
        Me.Controls.Add(txtFPTepLate)
        Me.Controls.Add(txtDisableDeviceT)
        Me.Controls.Add(cmdDisableDT)
        Me.Controls.Add(cmdBeep)
        Me.Controls.Add(cmdPlayVoiceByIndex)
        Me.Controls.Add(cmdRestartDevice)
        Me.Controls.Add(txtProductCode)
        Me.Controls.Add(cmdGetProductCode)
        Me.Controls.Add(txtSDeviceMAC)
        Me.Controls.Add(cmdSetDeviceMAC)
        Me.Controls.Add(txtSerialNumber)
        Me.Controls.Add(cmdGetSerialNumber)
        Me.Controls.Add(txtGetDeviceMAC)
        Me.Controls.Add(cmdGetDeviceMAC)
        Me.Controls.Add(txtSetIP)
        Me.Controls.Add(cmdSetDeviceIP)
        Me.Controls.Add(txtDeviceIP)
        Me.Controls.Add(cmdGetDeviceIP)
        Me.Controls.Add(cmdGetDevInfo)
        Me.Controls.Add(ls2)
        Me.Controls.Add(cmdWriteLcd)
        Me.Controls.Add(ls1)
        Me.Controls.Add(cmdGetDeviStat)
        Me.Controls.Add(cmdDisEnableClock)
        Me.Controls.Add(cmdEnableClock)
        Me.Controls.Add(cmdDisEnable)
        Me.Controls.Add(cmdEnable)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
#End Region
End Class