<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmLogin
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtTipoCambio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OK = New System.Windows.Forms.Button()
        Me.lblCambioClave = New System.Windows.Forms.LinkLabel()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Location = New System.Drawing.Point(64, 11)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(49, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "Usuario :"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(73, 37)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(41, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "Clave :"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(122, 14)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(117, 20)
        Me.txtUsuario.TabIndex = 1
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(122, 39)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(81, 20)
        Me.txtClave.TabIndex = 3
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(144, 124)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 8
        Me.Cancel.TabStop = False
        Me.Cancel.Text = "&Cancel"
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = Global.SIGECOM.My.Resources.Resources.SecurityLock
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(49, 47)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(70, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 23)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Fecha :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbFecha
        '
        '
        '
        '
        Me.cbFecha.DropDownCalendar.Name = ""
        Me.cbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecha.Location = New System.Drawing.Point(122, 64)
        Me.cbFecha.Name = "cbFecha"
        Me.cbFecha.Size = New System.Drawing.Size(88, 20)
        Me.cbFecha.TabIndex = 5
        Me.cbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.DecimalDigits = 3
        Me.txtTipoCambio.Location = New System.Drawing.Point(122, 90)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(59, 20)
        Me.txtTipoCambio.TabIndex = 6
        Me.txtTipoCambio.Text = "0.000"
        Me.txtTipoCambio.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Tipo de Cambio :"
        '
        'OK
        '
        Me.OK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK.Location = New System.Drawing.Point(44, 124)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 22)
        Me.OK.TabIndex = 7
        Me.OK.Text = "&OK"
        '
        'lblCambioClave
        '
        Me.lblCambioClave.AutoSize = True
        Me.lblCambioClave.ForeColor = System.Drawing.Color.Red
        Me.lblCambioClave.LinkColor = System.Drawing.Color.Red
        Me.lblCambioClave.Location = New System.Drawing.Point(56, 159)
        Me.lblCambioClave.Name = "lblCambioClave"
        Me.lblCambioClave.Size = New System.Drawing.Size(157, 13)
        Me.lblCambioClave.TabIndex = 12
        Me.lblCambioClave.TabStop = True
        Me.lblCambioClave.Text = "¿Olvidaste tu clave de acceso?"
        '
        'frmLogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(275, 185)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblCambioClave)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.cbFecha)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso al Sistema"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents lblCambioClave As LinkLabel
End Class
