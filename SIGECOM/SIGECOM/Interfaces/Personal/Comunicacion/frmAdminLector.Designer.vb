<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmAdminLector
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
    Public WithEvents Check1 As System.Windows.Forms.CheckBox
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents Command4 As System.Windows.Forms.Button
    Public WithEvents Progreso As System.Windows.Forms.ProgressBar
    Public WithEvents txtEnrollNum As System.Windows.Forms.TextBox
    Public WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents txtPaw As System.Windows.Forms.TextBox
    Public WithEvents cmbEnable As System.Windows.Forms.ComboBox
    Public WithEvents cmdCreate As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents txtMacNum As System.Windows.Forms.TextBox
    Public WithEvents cmdPri As System.Windows.Forms.ComboBox
    Public WithEvents labEnrollNum As System.Windows.Forms.Label
    Public WithEvents labName As System.Windows.Forms.Label
    Public WithEvents labPaw As System.Windows.Forms.Label
    Public WithEvents labPri As System.Windows.Forms.Label
    Public WithEvents labEnble As System.Windows.Forms.Label
    Public WithEvents labMacNum As System.Windows.Forms.Label
    Public WithEvents frmCrtuser As System.Windows.Forms.GroupBox
    Public WithEvents cmdeditar As System.Windows.Forms.Button
    Public WithEvents cmdnuevo As System.Windows.Forms.Button
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents cmdDelAUser As System.Windows.Forms.Button
    Public WithEvents cmdGetUserInfo As System.Windows.Forms.Button
    Public WithEvents txtMachNum As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents cmdSetDevice As System.Windows.Forms.Button
    Public WithEvents cmdConnect As System.Windows.Forms.Button
    Public WithEvents CZKEM1 As Axzkemkeeper.AxCZKEM
    Public WithEvents txtIP As System.Windows.Forms.TextBox
    Public WithEvents txtPort As System.Windows.Forms.TextBox
    Public WithEvents lvX As System.Windows.Forms.ListView
    Public WithEvents _StatusBar1_Panel1 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents StatusBar1 As System.Windows.Forms.StatusStrip
    Public WithEvents labMachNum As System.Windows.Forms.Label
    Public WithEvents labSDK As System.Windows.Forms.Label
    Public WithEvents labFirmV As System.Windows.Forms.Label
    Public WithEvents labIP As System.Windows.Forms.Label
    Public WithEvents labPort As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdminLector))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Check1 = New System.Windows.Forms.CheckBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Command4 = New System.Windows.Forms.Button
        Me.Progreso = New System.Windows.Forms.ProgressBar
        Me.frmCrtuser = New System.Windows.Forms.GroupBox
        Me.txtEnrollNum = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtPaw = New System.Windows.Forms.TextBox
        Me.cmbEnable = New System.Windows.Forms.ComboBox
        Me.cmdCreate = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtMacNum = New System.Windows.Forms.TextBox
        Me.cmdPri = New System.Windows.Forms.ComboBox
        Me.labEnrollNum = New System.Windows.Forms.Label
        Me.labName = New System.Windows.Forms.Label
        Me.labPaw = New System.Windows.Forms.Label
        Me.labPri = New System.Windows.Forms.Label
        Me.labEnble = New System.Windows.Forms.Label
        Me.labMacNum = New System.Windows.Forms.Label
        Me.cmdeditar = New System.Windows.Forms.Button
        Me.cmdnuevo = New System.Windows.Forms.Button
        Me.Command3 = New System.Windows.Forms.Button
        Me.Command2 = New System.Windows.Forms.Button
        Me.cmdDelAUser = New System.Windows.Forms.Button
        Me.cmdGetUserInfo = New System.Windows.Forms.Button
        Me.txtMachNum = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me.cmdSetDevice = New System.Windows.Forms.Button
        Me.cmdConnect = New System.Windows.Forms.Button
        Me.CZKEM1 = New Axzkemkeeper.AxCZKEM
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.lvX = New System.Windows.Forms.ListView
        Me.StatusBar1 = New System.Windows.Forms.StatusStrip
        Me._StatusBar1_Panel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.labMachNum = New System.Windows.Forms.Label
        Me.labSDK = New System.Windows.Forms.Label
        Me.labFirmV = New System.Windows.Forms.Label
        Me.labIP = New System.Windows.Forms.Label
        Me.labPort = New System.Windows.Forms.Label
        Me.cmbEquipo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.frmCrtuser.SuspendLayout()
        CType(Me.CZKEM1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Check1
        '
        Me.Check1.BackColor = System.Drawing.SystemColors.Control
        Me.Check1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check1.Enabled = False
        Me.Check1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check1.Location = New System.Drawing.Point(350, 46)
        Me.Check1.Name = "Check1"
        Me.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check1.Size = New System.Drawing.Size(136, 17)
        Me.Check1.TabIndex = 41
        Me.Check1.Text = "Descarga Automatica"
        Me.Check1.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 6000
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.SystemColors.Control
        Me.Command4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command4.Image = CType(resources.GetObject("Command4.Image"), System.Drawing.Image)
        Me.Command4.Location = New System.Drawing.Point(64, 392)
        Me.Command4.Name = "Command4"
        Me.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command4.Size = New System.Drawing.Size(41, 41)
        Me.Command4.TabIndex = 39
        Me.Command4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Command4.UseVisualStyleBackColor = False
        '
        'Progreso
        '
        Me.Progreso.Location = New System.Drawing.Point(208, 440)
        Me.Progreso.Maximum = 300
        Me.Progreso.Name = "Progreso"
        Me.Progreso.Size = New System.Drawing.Size(513, 25)
        Me.Progreso.TabIndex = 38
        Me.Progreso.Visible = False
        '
        'frmCrtuser
        '
        Me.frmCrtuser.BackColor = System.Drawing.SystemColors.Control
        Me.frmCrtuser.Controls.Add(Me.txtEnrollNum)
        Me.frmCrtuser.Controls.Add(Me.txtName)
        Me.frmCrtuser.Controls.Add(Me.txtPaw)
        Me.frmCrtuser.Controls.Add(Me.cmbEnable)
        Me.frmCrtuser.Controls.Add(Me.cmdCreate)
        Me.frmCrtuser.Controls.Add(Me.cmdCancel)
        Me.frmCrtuser.Controls.Add(Me.txtMacNum)
        Me.frmCrtuser.Controls.Add(Me.cmdPri)
        Me.frmCrtuser.Controls.Add(Me.labEnrollNum)
        Me.frmCrtuser.Controls.Add(Me.labName)
        Me.frmCrtuser.Controls.Add(Me.labPaw)
        Me.frmCrtuser.Controls.Add(Me.labPri)
        Me.frmCrtuser.Controls.Add(Me.labEnble)
        Me.frmCrtuser.Controls.Add(Me.labMacNum)
        Me.frmCrtuser.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmCrtuser.Location = New System.Drawing.Point(126, 74)
        Me.frmCrtuser.Name = "frmCrtuser"
        Me.frmCrtuser.Padding = New System.Windows.Forms.Padding(0)
        Me.frmCrtuser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmCrtuser.Size = New System.Drawing.Size(313, 241)
        Me.frmCrtuser.TabIndex = 20
        Me.frmCrtuser.TabStop = False
        Me.frmCrtuser.Text = "Informacion Usuario "
        Me.frmCrtuser.Visible = False
        '
        'txtEnrollNum
        '
        Me.txtEnrollNum.AcceptsReturn = True
        Me.txtEnrollNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtEnrollNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEnrollNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEnrollNum.Location = New System.Drawing.Point(96, 56)
        Me.txtEnrollNum.MaxLength = 0
        Me.txtEnrollNum.Name = "txtEnrollNum"
        Me.txtEnrollNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEnrollNum.Size = New System.Drawing.Size(193, 20)
        Me.txtEnrollNum.TabIndex = 28
        Me.txtEnrollNum.Text = "1"
        '
        'txtName
        '
        Me.txtName.AcceptsReturn = True
        Me.txtName.BackColor = System.Drawing.SystemColors.Window
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtName.Location = New System.Drawing.Point(96, 88)
        Me.txtName.MaxLength = 0
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(193, 20)
        Me.txtName.TabIndex = 27
        '
        'txtPaw
        '
        Me.txtPaw.AcceptsReturn = True
        Me.txtPaw.BackColor = System.Drawing.SystemColors.Window
        Me.txtPaw.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaw.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPaw.Location = New System.Drawing.Point(96, 120)
        Me.txtPaw.MaxLength = 0
        Me.txtPaw.Name = "txtPaw"
        Me.txtPaw.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPaw.Size = New System.Drawing.Size(193, 20)
        Me.txtPaw.TabIndex = 26
        '
        'cmbEnable
        '
        Me.cmbEnable.BackColor = System.Drawing.SystemColors.Window
        Me.cmbEnable.CausesValidation = False
        Me.cmbEnable.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbEnable.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbEnable.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cmbEnable.Items.AddRange(New Object() {"True", "False"})
        Me.cmbEnable.Location = New System.Drawing.Point(96, 184)
        Me.cmbEnable.Name = "cmbEnable"
        Me.cmbEnable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbEnable.Size = New System.Drawing.Size(193, 21)
        Me.cmbEnable.TabIndex = 25
        Me.cmbEnable.Text = "True"
        '
        'cmdCreate
        '
        Me.cmdCreate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCreate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCreate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCreate.Location = New System.Drawing.Point(16, 211)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCreate.Size = New System.Drawing.Size(89, 22)
        Me.cmdCreate.TabIndex = 24
        Me.cmdCreate.Text = "Guardar"
        Me.cmdCreate.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(200, 211)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(89, 22)
        Me.cmdCancel.TabIndex = 23
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'txtMacNum
        '
        Me.txtMacNum.AcceptsReturn = True
        Me.txtMacNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtMacNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMacNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMacNum.Location = New System.Drawing.Point(96, 24)
        Me.txtMacNum.MaxLength = 0
        Me.txtMacNum.Name = "txtMacNum"
        Me.txtMacNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMacNum.Size = New System.Drawing.Size(193, 20)
        Me.txtMacNum.TabIndex = 22
        Me.txtMacNum.Text = "1"
        '
        'cmdPri
        '
        Me.cmdPri.BackColor = System.Drawing.SystemColors.Window
        Me.cmdPri.CausesValidation = False
        Me.cmdPri.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPri.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmdPri.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cmdPri.Location = New System.Drawing.Point(96, 152)
        Me.cmdPri.Name = "cmdPri"
        Me.cmdPri.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPri.Size = New System.Drawing.Size(193, 21)
        Me.cmdPri.TabIndex = 21
        Me.cmdPri.Text = "0"
        '
        'labEnrollNum
        '
        Me.labEnrollNum.BackColor = System.Drawing.SystemColors.Control
        Me.labEnrollNum.Cursor = System.Windows.Forms.Cursors.Default
        Me.labEnrollNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labEnrollNum.Location = New System.Drawing.Point(8, 56)
        Me.labEnrollNum.Name = "labEnrollNum"
        Me.labEnrollNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labEnrollNum.Size = New System.Drawing.Size(89, 25)
        Me.labEnrollNum.TabIndex = 34
        Me.labEnrollNum.Text = "IdPersonal :"
        '
        'labName
        '
        Me.labName.BackColor = System.Drawing.SystemColors.Control
        Me.labName.Cursor = System.Windows.Forms.Cursors.Default
        Me.labName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labName.Location = New System.Drawing.Point(8, 88)
        Me.labName.Name = "labName"
        Me.labName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labName.Size = New System.Drawing.Size(49, 17)
        Me.labName.TabIndex = 33
        Me.labName.Text = "Nombres :"
        '
        'labPaw
        '
        Me.labPaw.BackColor = System.Drawing.SystemColors.Control
        Me.labPaw.Cursor = System.Windows.Forms.Cursors.Default
        Me.labPaw.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labPaw.Location = New System.Drawing.Point(8, 120)
        Me.labPaw.Name = "labPaw"
        Me.labPaw.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labPaw.Size = New System.Drawing.Size(65, 17)
        Me.labPaw.TabIndex = 32
        Me.labPaw.Text = "Password :"
        '
        'labPri
        '
        Me.labPri.BackColor = System.Drawing.SystemColors.Control
        Me.labPri.Cursor = System.Windows.Forms.Cursors.Default
        Me.labPri.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labPri.Location = New System.Drawing.Point(8, 152)
        Me.labPri.Name = "labPri"
        Me.labPri.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labPri.Size = New System.Drawing.Size(49, 25)
        Me.labPri.TabIndex = 31
        Me.labPri.Text = "Privilegio :"
        '
        'labEnble
        '
        Me.labEnble.BackColor = System.Drawing.SystemColors.Control
        Me.labEnble.Cursor = System.Windows.Forms.Cursors.Default
        Me.labEnble.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labEnble.Location = New System.Drawing.Point(8, 184)
        Me.labEnble.Name = "labEnble"
        Me.labEnble.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labEnble.Size = New System.Drawing.Size(57, 25)
        Me.labEnble.TabIndex = 30
        Me.labEnble.Text = "Habilitado :"
        '
        'labMacNum
        '
        Me.labMacNum.BackColor = System.Drawing.SystemColors.Control
        Me.labMacNum.Cursor = System.Windows.Forms.Cursors.Default
        Me.labMacNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labMacNum.Location = New System.Drawing.Point(8, 24)
        Me.labMacNum.Name = "labMacNum"
        Me.labMacNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labMacNum.Size = New System.Drawing.Size(89, 25)
        Me.labMacNum.TabIndex = 29
        Me.labMacNum.Text = "Num. Maquina :"
        '
        'cmdeditar
        '
        Me.cmdeditar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdeditar.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdeditar.Enabled = False
        Me.cmdeditar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdeditar.Location = New System.Drawing.Point(6, 216)
        Me.cmdeditar.Name = "cmdeditar"
        Me.cmdeditar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdeditar.Size = New System.Drawing.Size(108, 25)
        Me.cmdeditar.TabIndex = 19
        Me.cmdeditar.Text = "Actualizar Usuario"
        Me.cmdeditar.UseVisualStyleBackColor = False
        '
        'cmdnuevo
        '
        Me.cmdnuevo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdnuevo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdnuevo.Enabled = False
        Me.cmdnuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdnuevo.Location = New System.Drawing.Point(6, 184)
        Me.cmdnuevo.Name = "cmdnuevo"
        Me.cmdnuevo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdnuevo.Size = New System.Drawing.Size(108, 25)
        Me.cmdnuevo.TabIndex = 18
        Me.cmdnuevo.Text = "Nuevo Usuario"
        Me.cmdnuevo.UseVisualStyleBackColor = False
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.Enabled = False
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(6, 135)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(108, 25)
        Me.Command3.TabIndex = 17
        Me.Command3.Text = "Borrar Marcas"
        Me.Command3.UseVisualStyleBackColor = False
        Me.Command3.Visible = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.Enabled = False
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(6, 362)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(108, 25)
        Me.Command2.TabIndex = 16
        Me.Command2.Text = "Configurar Hora"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'cmdDelAUser
        '
        Me.cmdDelAUser.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDelAUser.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDelAUser.Enabled = False
        Me.cmdDelAUser.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDelAUser.Location = New System.Drawing.Point(6, 248)
        Me.cmdDelAUser.Name = "cmdDelAUser"
        Me.cmdDelAUser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDelAUser.Size = New System.Drawing.Size(108, 25)
        Me.cmdDelAUser.TabIndex = 15
        Me.cmdDelAUser.Text = "Borrar Usuario"
        Me.cmdDelAUser.UseVisualStyleBackColor = False
        '
        'cmdGetUserInfo
        '
        Me.cmdGetUserInfo.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGetUserInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGetUserInfo.Enabled = False
        Me.cmdGetUserInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGetUserInfo.Location = New System.Drawing.Point(6, 280)
        Me.cmdGetUserInfo.Name = "cmdGetUserInfo"
        Me.cmdGetUserInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGetUserInfo.Size = New System.Drawing.Size(108, 25)
        Me.cmdGetUserInfo.TabIndex = 14
        Me.cmdGetUserInfo.Text = "Mostrar Usuarios"
        Me.cmdGetUserInfo.UseVisualStyleBackColor = False
        '
        'txtMachNum
        '
        Me.txtMachNum.AcceptsReturn = True
        Me.txtMachNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtMachNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMachNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMachNum.Location = New System.Drawing.Point(262, 42)
        Me.txtMachNum.MaxLength = 0
        Me.txtMachNum.Name = "txtMachNum"
        Me.txtMachNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMachNum.Size = New System.Drawing.Size(61, 20)
        Me.txtMachNum.TabIndex = 12
        Me.txtMachNum.Text = "1"
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.Enabled = False
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(6, 103)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(108, 25)
        Me.Command1.TabIndex = 11
        Me.Command1.Text = "Descargar Marcas"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'cmdSetDevice
        '
        Me.cmdSetDevice.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSetDevice.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSetDevice.Enabled = False
        Me.cmdSetDevice.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSetDevice.Location = New System.Drawing.Point(6, 330)
        Me.cmdSetDevice.Name = "cmdSetDevice"
        Me.cmdSetDevice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSetDevice.Size = New System.Drawing.Size(108, 25)
        Me.cmdSetDevice.TabIndex = 10
        Me.cmdSetDevice.Text = "Seteo Relog"
        Me.cmdSetDevice.UseVisualStyleBackColor = False
        '
        'cmdConnect
        '
        Me.cmdConnect.BackColor = System.Drawing.SystemColors.Control
        Me.cmdConnect.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdConnect.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdConnect.Location = New System.Drawing.Point(6, 72)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdConnect.Size = New System.Drawing.Size(108, 25)
        Me.cmdConnect.TabIndex = 7
        Me.cmdConnect.Text = "Conectar"
        Me.cmdConnect.UseVisualStyleBackColor = False
        '
        'CZKEM1
        '
        Me.CZKEM1.Enabled = True
        Me.CZKEM1.Location = New System.Drawing.Point(1, -1)
        Me.CZKEM1.Name = "CZKEM1"
        Me.CZKEM1.OcxState = CType(resources.GetObject("CZKEM1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CZKEM1.Size = New System.Drawing.Size(41, 50)
        Me.CZKEM1.TabIndex = 4
        Me.CZKEM1.Visible = False
        '
        'txtIP
        '
        Me.txtIP.AcceptsReturn = True
        Me.txtIP.BackColor = System.Drawing.SystemColors.Window
        Me.txtIP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIP.Location = New System.Drawing.Point(478, 8)
        Me.txtIP.MaxLength = 0
        Me.txtIP.Name = "txtIP"
        Me.txtIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIP.Size = New System.Drawing.Size(92, 20)
        Me.txtIP.TabIndex = 1
        Me.txtIP.Text = "192.168.5.100"
        '
        'txtPort
        '
        Me.txtPort.AcceptsReturn = True
        Me.txtPort.BackColor = System.Drawing.SystemColors.Window
        Me.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPort.Location = New System.Drawing.Point(67, 42)
        Me.txtPort.MaxLength = 0
        Me.txtPort.Name = "txtPort"
        Me.txtPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPort.Size = New System.Drawing.Size(65, 20)
        Me.txtPort.TabIndex = 0
        Me.txtPort.Text = "4370"
        '
        'lvX
        '
        Me.lvX.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.lvX.BackColor = System.Drawing.SystemColors.Window
        Me.lvX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lvX.FullRowSelect = True
        Me.lvX.GridLines = True
        Me.lvX.Location = New System.Drawing.Point(121, 72)
        Me.lvX.Name = "lvX"
        Me.lvX.Size = New System.Drawing.Size(576, 361)
        Me.lvX.TabIndex = 8
        Me.lvX.UseCompatibleStateImageBehavior = False
        Me.lvX.View = System.Windows.Forms.View.Details
        '
        'StatusBar1
        '
        Me.StatusBar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._StatusBar1_Panel1})
        Me.StatusBar1.Location = New System.Drawing.Point(0, 434)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(705, 33)
        Me.StatusBar1.TabIndex = 9
        '
        '_StatusBar1_Panel1
        '
        Me._StatusBar1_Panel1.AutoSize = False
        Me._StatusBar1_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._StatusBar1_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._StatusBar1_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._StatusBar1_Panel1.Name = "_StatusBar1_Panel1"
        Me._StatusBar1_Panel1.Size = New System.Drawing.Size(201, 33)
        Me._StatusBar1_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labMachNum
        '
        Me.labMachNum.BackColor = System.Drawing.SystemColors.Control
        Me.labMachNum.Cursor = System.Windows.Forms.Cursors.Default
        Me.labMachNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labMachNum.Location = New System.Drawing.Point(146, 46)
        Me.labMachNum.Name = "labMachNum"
        Me.labMachNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labMachNum.Size = New System.Drawing.Size(105, 17)
        Me.labMachNum.TabIndex = 13
        Me.labMachNum.Text = "Numero Maquina :"
        '
        'labSDK
        '
        Me.labSDK.BackColor = System.Drawing.SystemColors.Control
        Me.labSDK.Cursor = System.Windows.Forms.Cursors.Default
        Me.labSDK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labSDK.Location = New System.Drawing.Point(586, 8)
        Me.labSDK.Name = "labSDK"
        Me.labSDK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labSDK.Size = New System.Drawing.Size(113, 17)
        Me.labSDK.TabIndex = 6
        '
        'labFirmV
        '
        Me.labFirmV.BackColor = System.Drawing.SystemColors.Control
        Me.labFirmV.Cursor = System.Windows.Forms.Cursors.Default
        Me.labFirmV.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labFirmV.Location = New System.Drawing.Point(579, 32)
        Me.labFirmV.Name = "labFirmV"
        Me.labFirmV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labFirmV.Size = New System.Drawing.Size(121, 17)
        Me.labFirmV.TabIndex = 5
        '
        'labIP
        '
        Me.labIP.BackColor = System.Drawing.SystemColors.Control
        Me.labIP.Cursor = System.Windows.Forms.Cursors.Default
        Me.labIP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labIP.Location = New System.Drawing.Point(402, 11)
        Me.labIP.Name = "labIP"
        Me.labIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labIP.Size = New System.Drawing.Size(72, 17)
        Me.labIP.TabIndex = 3
        Me.labIP.Text = "Direccion IP :"
        '
        'labPort
        '
        Me.labPort.BackColor = System.Drawing.SystemColors.Control
        Me.labPort.Cursor = System.Windows.Forms.Cursors.Default
        Me.labPort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labPort.Location = New System.Drawing.Point(21, 46)
        Me.labPort.Name = "labPort"
        Me.labPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labPort.Size = New System.Drawing.Size(49, 17)
        Me.labPort.TabIndex = 2
        Me.labPort.Text = "Puerto :"
        '
        'cmbEquipo
        '
        Me.cmbEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEquipo.FormattingEnabled = True
        Me.cmbEquipo.Location = New System.Drawing.Point(69, 8)
        Me.cmbEquipo.Name = "cmbEquipo"
        Me.cmbEquipo.Size = New System.Drawing.Size(329, 21)
        Me.cmbEquipo.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Lector :"
        '
        'frmAdminLector
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(705, 467)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEquipo)
        Me.Controls.Add(Me.Check1)
        Me.Controls.Add(Me.Command4)
        Me.Controls.Add(Me.Progreso)
        Me.Controls.Add(Me.frmCrtuser)
        Me.Controls.Add(Me.cmdeditar)
        Me.Controls.Add(Me.cmdnuevo)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.cmdDelAUser)
        Me.Controls.Add(Me.cmdGetUserInfo)
        Me.Controls.Add(Me.txtMachNum)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.cmdSetDevice)
        Me.Controls.Add(Me.cmdConnect)
        Me.Controls.Add(Me.CZKEM1)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.lvX)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.labMachNum)
        Me.Controls.Add(Me.labSDK)
        Me.Controls.Add(Me.labFirmV)
        Me.Controls.Add(Me.labIP)
        Me.Controls.Add(Me.labPort)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(4, 29)
        Me.MaximizeBox = False
        Me.Name = "frmAdminLector"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Modulo de Comunicacion"
        Me.frmCrtuser.ResumeLayout(False)
        Me.frmCrtuser.PerformLayout()
        CType(Me.CZKEM1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusBar1.ResumeLayout(False)
        Me.StatusBar1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbEquipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
#End Region
End Class