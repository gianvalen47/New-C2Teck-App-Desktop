<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComCotizacionSolicitud_AgregarDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComCotizacionSolicitud_AgregarDetalle))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtCodMer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtDesMer = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPreMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDscto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.txtCanMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecEntrega = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtCodMer
        '
        Me.txtCodMer.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodMer.Location = New System.Drawing.Point(92, 17)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.ReadOnly = True
        Me.txtCodMer.Size = New System.Drawing.Size(138, 20)
        Me.txtCodMer.TabIndex = 0
        Me.txtCodMer.TabStop = False
        Me.txtCodMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDesMer
        '
        Me.txtDesMer.BackColor = System.Drawing.SystemColors.Control
        Me.txtDesMer.Location = New System.Drawing.Point(92, 45)
        Me.txtDesMer.Name = "txtDesMer"
        Me.txtDesMer.ReadOnly = True
        Me.txtDesMer.Size = New System.Drawing.Size(313, 20)
        Me.txtDesMer.TabIndex = 1
        Me.txtDesMer.TabStop = False
        Me.txtDesMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción :"
        '
        'txtPreMer
        '
        Me.txtPreMer.DecimalDigits = 4
        Me.txtPreMer.Location = New System.Drawing.Point(92, 103)
        Me.txtPreMer.Name = "txtPreMer"
        Me.txtPreMer.Size = New System.Drawing.Size(92, 20)
        Me.txtPreMer.TabIndex = 5
        Me.txtPreMer.Text = "0.0000"
        Me.txtPreMer.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtPreMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDscto
        '
        Me.txtDscto.Location = New System.Drawing.Point(300, 103)
        Me.txtDscto.Name = "txtDscto"
        Me.txtDscto.Size = New System.Drawing.Size(83, 20)
        Me.txtDscto.TabIndex = 6
        Me.txtDscto.Text = "0.00"
        Me.txtDscto.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDscto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cantidad :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Precio :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(250, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Dscto : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Observación : "
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Location = New System.Drawing.Point(92, 132)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(311, 69)
        Me.txtObservacion.TabIndex = 11
        Me.txtObservacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.Location = New System.Drawing.Point(135, 226)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 27)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.Location = New System.Drawing.Point(219, 226)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(78, 27)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.Text = "Cancelar"
        '
        'txtCanMer
        '
        Me.txtCanMer.DecimalDigits = 4
        Me.txtCanMer.Location = New System.Drawing.Point(92, 74)
        Me.txtCanMer.Name = "txtCanMer"
        Me.txtCanMer.Size = New System.Drawing.Size(93, 20)
        Me.txtCanMer.TabIndex = 4
        Me.txtCanMer.TabStop = False
        Me.txtCanMer.Text = "0.0000"
        Me.txtCanMer.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtCanMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtFecEntrega)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtCanMer)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtDscto)
        Me.UiGroupBox1.Controls.Add(Me.txtPreMer)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtDesMer)
        Me.UiGroupBox1.Controls.Add(Me.txtCodMer)
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 5)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(415, 213)
        Me.UiGroupBox1.TabIndex = 14
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFecEntrega
        '
        '
        '
        '
        Me.txtFecEntrega.DropDownCalendar.Name = ""
        Me.txtFecEntrega.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecEntrega.IsNullDate = True
        Me.txtFecEntrega.Location = New System.Drawing.Point(300, 74)
        Me.txtFecEntrega.Name = "txtFecEntrega"
        Me.txtFecEntrega.NullButtonText = "Ninguno"
        Me.txtFecEntrega.ShowNullButton = True
        Me.txtFecEntrega.Size = New System.Drawing.Size(83, 20)
        Me.txtFecEntrega.TabIndex = 26
        Me.txtFecEntrega.TodayButtonText = "Hoy"
        Me.txtFecEntrega.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(226, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Fec. Entrega"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Observación :"
        '
        'frmComCotizacionSolicitud_AgregarDetalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(431, 263)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComCotizacionSolicitud_AgregarDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmComCotizacionSolicitud_AgregarDetalle"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtDesMer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtCodMer As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDscto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPreMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtCanMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFecEntrega As Janus.Windows.CalendarCombo.CalendarCombo
End Class
