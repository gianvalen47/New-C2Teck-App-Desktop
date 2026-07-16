<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocsCreditoPago
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
        Dim cbTipoPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbSerie_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocsCreditoPago))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbTipoPago = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTipCam = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalDocUS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDocNS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPagNS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPagUS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalaPagarNS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalaPagarUS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDifCam = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.RichTextBox()
        Me.cbSerie = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbTipoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cbSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(390, 242)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(76, 27)
        Me.btnCancelar.TabIndex = 28
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipo Pago :"
        '
        'cbTipoPago
        '
        Me.cbTipoPago.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbTipoPago_DesignTimeLayout.LayoutString = resources.GetString("cbTipoPago_DesignTimeLayout.LayoutString")
        Me.cbTipoPago.DesignTimeLayout = cbTipoPago_DesignTimeLayout
        Me.cbTipoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoPago.Location = New System.Drawing.Point(82, 12)
        Me.cbTipoPago.Name = "cbTipoPago"
        Me.cbTipoPago.ReadOnly = True
        Me.cbTipoPago.SelectedIndex = -1
        Me.cbTipoPago.SelectedItem = Nothing
        Me.cbTipoPago.Size = New System.Drawing.Size(208, 20)
        Me.cbTipoPago.TabIndex = 1
        Me.cbTipoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumero.Location = New System.Drawing.Point(296, 38)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(50, 13)
        Me.lblNumero.TabIndex = 4
        Me.lblNumero.Text = "Numero :"
        Me.lblNumero.Visible = False
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDoc.Location = New System.Drawing.Point(352, 34)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(108, 20)
        Me.txtNumDoc.TabIndex = 3
        Me.txtNumDoc.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha :"
        '
        'cbFecha
        '
        '
        '
        '
        Me.cbFecha.DropDownCalendar.Name = ""
        Me.cbFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecha.Location = New System.Drawing.Point(61, 56)
        Me.cbFecha.Name = "cbFecha"
        Me.cbFecha.Size = New System.Drawing.Size(98, 20)
        Me.cbFecha.TabIndex = 4
        Me.cbFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtMoneda
        '
        Me.txtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.Location = New System.Drawing.Point(230, 56)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(51, 20)
        Me.txtMoneda.TabIndex = 5
        Me.txtMoneda.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(169, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Moneda :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(285, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Tipo Cambio :"
        '
        'txtTipCam
        '
        Me.txtTipCam.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTipCam.Enabled = False
        Me.txtTipCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipCam.FormatString = "n3"
        Me.txtTipCam.Location = New System.Drawing.Point(363, 57)
        Me.txtTipCam.Name = "txtTipCam"
        Me.txtTipCam.Size = New System.Drawing.Size(69, 20)
        Me.txtTipCam.TabIndex = 6
        Me.txtTipCam.TabStop = False
        Me.txtTipCam.Text = "0.000"
        Me.txtTipCam.Value = New Decimal(New Integer() {0, 0, 0, 196608})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Dolares"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Soles"
        '
        'txtTotalDocUS
        '
        Me.txtTotalDocUS.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalDocUS.Enabled = False
        Me.txtTotalDocUS.Location = New System.Drawing.Point(71, 30)
        Me.txtTotalDocUS.Name = "txtTotalDocUS"
        Me.txtTotalDocUS.Size = New System.Drawing.Size(115, 20)
        Me.txtTotalDocUS.TabIndex = 7
        Me.txtTotalDocUS.TabStop = False
        Me.txtTotalDocUS.Text = "0.00"
        Me.txtTotalDocUS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalDocNS
        '
        Me.txtTotalDocNS.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalDocNS.Enabled = False
        Me.txtTotalDocNS.Location = New System.Drawing.Point(71, 56)
        Me.txtTotalDocNS.Name = "txtTotalDocNS"
        Me.txtTotalDocNS.Size = New System.Drawing.Size(115, 20)
        Me.txtTotalDocNS.TabIndex = 10
        Me.txtTotalDocNS.TabStop = False
        Me.txtTotalDocNS.Text = "0.00"
        Me.txtTotalDocNS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalPagNS
        '
        Me.txtTotalPagNS.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalPagNS.Enabled = False
        Me.txtTotalPagNS.Location = New System.Drawing.Point(198, 56)
        Me.txtTotalPagNS.Name = "txtTotalPagNS"
        Me.txtTotalPagNS.Size = New System.Drawing.Size(115, 20)
        Me.txtTotalPagNS.TabIndex = 11
        Me.txtTotalPagNS.TabStop = False
        Me.txtTotalPagNS.Text = "0.00"
        Me.txtTotalPagNS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalPagUS
        '
        Me.txtTotalPagUS.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalPagUS.Enabled = False
        Me.txtTotalPagUS.Location = New System.Drawing.Point(198, 30)
        Me.txtTotalPagUS.Name = "txtTotalPagUS"
        Me.txtTotalPagUS.Size = New System.Drawing.Size(115, 20)
        Me.txtTotalPagUS.TabIndex = 8
        Me.txtTotalPagUS.TabStop = False
        Me.txtTotalPagUS.Text = "0.00"
        Me.txtTotalPagUS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalaPagarNS
        '
        Me.txtTotalaPagarNS.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalaPagarNS.Enabled = False
        Me.txtTotalaPagarNS.Location = New System.Drawing.Point(327, 56)
        Me.txtTotalaPagarNS.Name = "txtTotalaPagarNS"
        Me.txtTotalaPagarNS.Size = New System.Drawing.Size(115, 20)
        Me.txtTotalaPagarNS.TabIndex = 12
        Me.txtTotalaPagarNS.Text = "0.00"
        Me.txtTotalaPagarNS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalaPagarUS
        '
        Me.txtTotalaPagarUS.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalaPagarUS.Enabled = False
        Me.txtTotalaPagarUS.Location = New System.Drawing.Point(327, 30)
        Me.txtTotalaPagarUS.Name = "txtTotalaPagarUS"
        Me.txtTotalaPagarUS.Size = New System.Drawing.Size(115, 20)
        Me.txtTotalaPagarUS.TabIndex = 9
        Me.txtTotalaPagarUS.Text = "0.00"
        Me.txtTotalaPagarUS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(82, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Total Documento"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(225, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Total Pagado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(352, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Total a Pagar"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label11)
        Me.UiGroupBox1.Controls.Add(Me.txtDifCam)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDocUS)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalaPagarNS)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDocNS)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalaPagarUS)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPagUS)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalPagNS)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 85)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(474, 115)
        Me.UiGroupBox1.TabIndex = 23
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(187, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Diferencia de Cambio :"
        '
        'txtDifCam
        '
        Me.txtDifCam.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDifCam.Enabled = False
        Me.txtDifCam.Location = New System.Drawing.Point(327, 83)
        Me.txtDifCam.Name = "txtDifCam"
        Me.txtDifCam.Size = New System.Drawing.Size(115, 20)
        Me.txtDifCam.TabIndex = 13
        Me.txtDifCam.Text = "0.00"
        Me.txtDifCam.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Observacion :"
        '
        'txtObservacion
        '
        Me.txtObservacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(99, 214)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ReadOnly = True
        Me.txtObservacion.Size = New System.Drawing.Size(377, 19)
        Me.txtObservacion.TabIndex = 14
        Me.txtObservacion.Text = ""
        '
        'cbSerie
        '
        Me.cbSerie.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbSerie_DesignTimeLayout.LayoutString = resources.GetString("cbSerie_DesignTimeLayout.LayoutString")
        Me.cbSerie.DesignTimeLayout = cbSerie_DesignTimeLayout
        Me.cbSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSerie.Location = New System.Drawing.Point(82, 34)
        Me.cbSerie.Name = "cbSerie"
        Me.cbSerie.ReadOnly = True
        Me.cbSerie.SelectedIndex = -1
        Me.cbSerie.SelectedItem = Nothing
        Me.cbSerie.Size = New System.Drawing.Size(208, 20)
        Me.cbSerie.TabIndex = 2
        Me.cbSerie.Visible = False
        Me.cbSerie.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblDocumento
        '
        Me.lblDocumento.AutoSize = True
        Me.lblDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumento.Location = New System.Drawing.Point(12, 36)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(68, 13)
        Me.lblDocumento.TabIndex = 26
        Me.lblDocumento.Text = "Documento :"
        Me.lblDocumento.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(309, 242)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 27)
        Me.btnAceptar.TabIndex = 27
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmDocsCreditoPago
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(512, 302)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cbSerie)
        Me.Controls.Add(Me.lblDocumento)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.txtTipCam)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtMoneda)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbFecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNumDoc)
        Me.Controls.Add(Me.lblNumero)
        Me.Controls.Add(Me.cbTipoPago)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDocsCreditoPago"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registro de Pago"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbTipoPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cbSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents cbTipoPago As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalaPagarNS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalaPagarUS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPagNS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPagUS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDocNS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDocUS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTipCam As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDifCam As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtObservacion As System.Windows.Forms.RichTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbSerie As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
