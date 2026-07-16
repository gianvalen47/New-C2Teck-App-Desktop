<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTipoCambio
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
        Dim cbCodMon_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTipoCambio))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.cbCodMon = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTipCamCompra = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.lblTipCamCompra = New System.Windows.Forms.Label()
        Me.lblTipCamVenta = New System.Windows.Forms.Label()
        Me.txtTipCamVenta = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnConsultarSunat = New System.Windows.Forms.Button()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.cbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbCodMon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK_Button.Location = New System.Drawing.Point(63, 212)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 3
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(136, 212)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'cbCodMon
        '
        Me.cbCodMon.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbCodMon_DesignTimeLayout.LayoutString = resources.GetString("cbCodMon_DesignTimeLayout.LayoutString")
        Me.cbCodMon.DesignTimeLayout = cbCodMon_DesignTimeLayout
        Me.cbCodMon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCodMon.Location = New System.Drawing.Point(113, 10)
        Me.cbCodMon.Name = "cbCodMon"
        Me.cbCodMon.SelectedIndex = -1
        Me.cbCodMon.SelectedItem = Nothing
        Me.cbCodMon.Size = New System.Drawing.Size(55, 20)
        Me.cbCodMon.TabIndex = 21
        Me.cbCodMon.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Moneda :"
        '
        'txtTipCamCompra
        '
        Me.txtTipCamCompra.DecimalDigits = 3
        Me.txtTipCamCompra.Location = New System.Drawing.Point(105, 20)
        Me.txtTipCamCompra.Name = "txtTipCamCompra"
        Me.txtTipCamCompra.Size = New System.Drawing.Size(67, 20)
        Me.txtTipCamCompra.TabIndex = 1
        Me.txtTipCamCompra.Text = "0.000"
        Me.txtTipCamCompra.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.lblTipCamCompra)
        Me.UiGroupBox1.Controls.Add(Me.lblTipCamVenta)
        Me.UiGroupBox1.Controls.Add(Me.txtTipCamVenta)
        Me.UiGroupBox1.Controls.Add(Me.txtTipCamCompra)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(8, 63)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(203, 80)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.Text = "Tipo de Cambio"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lblTipCamCompra
        '
        Me.lblTipCamCompra.AutoSize = True
        Me.lblTipCamCompra.Location = New System.Drawing.Point(29, 23)
        Me.lblTipCamCompra.Name = "lblTipCamCompra"
        Me.lblTipCamCompra.Size = New System.Drawing.Size(49, 13)
        Me.lblTipCamCompra.TabIndex = 27
        Me.lblTipCamCompra.Text = "Compra"
        '
        'lblTipCamVenta
        '
        Me.lblTipCamVenta.AutoSize = True
        Me.lblTipCamVenta.Location = New System.Drawing.Point(29, 52)
        Me.lblTipCamVenta.Name = "lblTipCamVenta"
        Me.lblTipCamVenta.Size = New System.Drawing.Size(40, 13)
        Me.lblTipCamVenta.TabIndex = 26
        Me.lblTipCamVenta.Text = "Venta"
        '
        'txtTipCamVenta
        '
        Me.txtTipCamVenta.DecimalDigits = 3
        Me.txtTipCamVenta.Location = New System.Drawing.Point(105, 49)
        Me.txtTipCamVenta.Name = "txtTipCamVenta"
        Me.txtTipCamVenta.Size = New System.Drawing.Size(67, 20)
        Me.txtTipCamVenta.TabIndex = 2
        Me.txtTipCamVenta.Text = "0.000"
        Me.txtTipCamVenta.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'btnConsultarSunat
        '
        Me.btnConsultarSunat.Location = New System.Drawing.Point(61, 151)
        Me.btnConsultarSunat.Name = "btnConsultarSunat"
        Me.btnConsultarSunat.Size = New System.Drawing.Size(91, 23)
        Me.btnConsultarSunat.TabIndex = 23
        Me.btnConsultarSunat.Text = "Consultar Sunat"
        Me.btnConsultarSunat.UseVisualStyleBackColor = True
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMensaje.Location = New System.Drawing.Point(5, 182)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(0, 13)
        Me.lblMensaje.TabIndex = 24
        '
        'cbFecha
        '
        Me.cbFecha.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.cbFecha.DropDownCalendar.Name = ""
        Me.cbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecha.Location = New System.Drawing.Point(113, 37)
        Me.cbFecha.Name = "cbFecha"
        Me.cbFecha.ReadOnly = True
        Me.cbFecha.Size = New System.Drawing.Size(98, 20)
        Me.cbFecha.TabIndex = 25
        Me.cbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Fecha :"
        '
        'frmTipoCambio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(279, 269)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbFecha)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.btnConsultarSunat)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.cbCodMon)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTipoCambio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresar Tipo de Cambio"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbCodMon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents cbCodMon As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTipCamCompra As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTipCamVenta As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblTipCamCompra As System.Windows.Forms.Label
    Friend WithEvents lblTipCamVenta As System.Windows.Forms.Label
    Friend WithEvents btnConsultarSunat As Button
    Friend WithEvents lblMensaje As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbFecha As Janus.Windows.CalendarCombo.CalendarCombo
End Class
