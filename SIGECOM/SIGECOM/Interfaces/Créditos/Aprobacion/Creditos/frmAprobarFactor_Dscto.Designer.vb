<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAprobarFactor_Dscto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAprobarFactor_Dscto))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtFacCli = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtDscCli = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblCliente = New System.Windows.Forms.Label
        Me.txtPreFab = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPreMos = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPreLis = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPreCli = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPreVen = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtPreOfe = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCodMer = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtFacCli
        '
        Me.txtFacCli.Location = New System.Drawing.Point(67, 82)
        Me.txtFacCli.MaxLength = 12
        Me.txtFacCli.Name = "txtFacCli"
        Me.txtFacCli.ReadOnly = True
        Me.txtFacCli.Size = New System.Drawing.Size(57, 21)
        Me.txtFacCli.TabIndex = 47
        Me.txtFacCli.TabStop = False
        Me.txtFacCli.Text = "0.00"
        Me.txtFacCli.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtDscCli
        '
        Me.txtDscCli.Location = New System.Drawing.Point(225, 82)
        Me.txtDscCli.MaxLength = 12
        Me.txtDscCli.Name = "txtDscCli"
        Me.txtDscCli.ReadOnly = True
        Me.txtDscCli.Size = New System.Drawing.Size(57, 21)
        Me.txtDscCli.TabIndex = 48
        Me.txtDscCli.Text = "0.00"
        Me.txtDscCli.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(144, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 15)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "Descuento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Factor"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCliente.Location = New System.Drawing.Point(16, 9)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(59, 13)
        Me.lblCliente.TabIndex = 51
        Me.lblCliente.Text = "lblCliente"
        '
        'txtPreFab
        '
        Me.txtPreFab.Location = New System.Drawing.Point(183, 126)
        Me.txtPreFab.MaxLength = 12
        Me.txtPreFab.Name = "txtPreFab"
        Me.txtPreFab.ReadOnly = True
        Me.txtPreFab.Size = New System.Drawing.Size(57, 21)
        Me.txtPreFab.TabIndex = 52
        Me.txtPreFab.TabStop = False
        Me.txtPreFab.Text = "0.00"
        Me.txtPreFab.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Precio Fabrica"
        '
        'txtPreMos
        '
        Me.txtPreMos.Location = New System.Drawing.Point(183, 154)
        Me.txtPreMos.MaxLength = 12
        Me.txtPreMos.Name = "txtPreMos"
        Me.txtPreMos.ReadOnly = True
        Me.txtPreMos.Size = New System.Drawing.Size(57, 21)
        Me.txtPreMos.TabIndex = 54
        Me.txtPreMos.TabStop = False
        Me.txtPreMos.Text = "0.00"
        Me.txtPreMos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 15)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Precio Mostrador"
        '
        'txtPreLis
        '
        Me.txtPreLis.Location = New System.Drawing.Point(183, 182)
        Me.txtPreLis.MaxLength = 12
        Me.txtPreLis.Name = "txtPreLis"
        Me.txtPreLis.ReadOnly = True
        Me.txtPreLis.Size = New System.Drawing.Size(57, 21)
        Me.txtPreLis.TabIndex = 56
        Me.txtPreLis.TabStop = False
        Me.txtPreLis.Text = "0.00"
        Me.txtPreLis.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(49, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Precio Lista"
        '
        'txtPreCli
        '
        Me.txtPreCli.Location = New System.Drawing.Point(183, 210)
        Me.txtPreCli.MaxLength = 12
        Me.txtPreCli.Name = "txtPreCli"
        Me.txtPreCli.ReadOnly = True
        Me.txtPreCli.Size = New System.Drawing.Size(57, 21)
        Me.txtPreCli.TabIndex = 58
        Me.txtPreCli.TabStop = False
        Me.txtPreCli.Text = "0.00"
        Me.txtPreCli.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(49, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 15)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Precio Cliente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(49, 270)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 15)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Precio Venta"
        '
        'txtPreVen
        '
        Me.txtPreVen.Location = New System.Drawing.Point(183, 266)
        Me.txtPreVen.MaxLength = 12
        Me.txtPreVen.Name = "txtPreVen"
        Me.txtPreVen.ReadOnly = True
        Me.txtPreVen.Size = New System.Drawing.Size(57, 21)
        Me.txtPreVen.TabIndex = 61
        Me.txtPreVen.TabStop = False
        Me.txtPreVen.Text = "0.00"
        Me.txtPreVen.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtPreOfe
        '
        Me.txtPreOfe.Location = New System.Drawing.Point(183, 238)
        Me.txtPreOfe.MaxLength = 12
        Me.txtPreOfe.Name = "txtPreOfe"
        Me.txtPreOfe.ReadOnly = True
        Me.txtPreOfe.Size = New System.Drawing.Size(57, 21)
        Me.txtPreOfe.TabIndex = 62
        Me.txtPreOfe.TabStop = False
        Me.txtPreOfe.Text = "0.00"
        Me.txtPreOfe.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(49, 242)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 15)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Precio Oferta"
        '
        'txtCodMer
        '
        Me.txtCodMer.Location = New System.Drawing.Point(109, 37)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(131, 21)
        Me.txtCodMer.TabIndex = 64
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(49, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 16)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Codigo"
        '
        'frmAprobarFactor_Dscto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(303, 312)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCodMer)
        Me.Controls.Add(Me.txtPreOfe)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPreVen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPreCli)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPreLis)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPreMos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPreFab)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.txtFacCli)
        Me.Controls.Add(Me.txtDscCli)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAprobarFactor_Dscto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Factor / Descuento"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtFacCli As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDscCli As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents txtPreCli As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPreLis As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPreMos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPreFab As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPreOfe As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPreVen As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
End Class
