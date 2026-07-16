<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanillaDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlanillaDet))
        Dim cbMotivo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cbDocumento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbMotivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalDocSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalDocDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTotalPagoSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtTotalPagoDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtPagarSol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPagarDol = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbDocumento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.cbMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        CType(Me.cbDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(251, 302)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(162, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Enabled = False
        Me.OK_Button.Image = CType(resources.GetObject("OK_Button.Image"), System.Drawing.Image)
        Me.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(75, 23)
        Me.OK_Button.TabIndex = 6
        Me.OK_Button.Text = "Aceptar"
        Me.OK_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OK_Button.Visible = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Image = CType(resources.GetObject("Cancel_Button.Image"), System.Drawing.Image)
        Me.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel_Button.Location = New System.Drawing.Point(84, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_Button.TabIndex = 7
        Me.Cancel_Button.TabStop = False
        Me.Cancel_Button.Text = "Cancelar"
        Me.Cancel_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Motivo :"
        '
        'cbMotivo
        '
        Me.cbMotivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbMotivo_DesignTimeLayout.LayoutString = resources.GetString("cbMotivo_DesignTimeLayout.LayoutString")
        Me.cbMotivo.DesignTimeLayout = cbMotivo_DesignTimeLayout
        Me.cbMotivo.Enabled = False
        Me.cbMotivo.Location = New System.Drawing.Point(63, 7)
        Me.cbMotivo.Name = "cbMotivo"
        Me.cbMotivo.SelectedIndex = -1
        Me.cbMotivo.SelectedItem = Nothing
        Me.cbMotivo.Size = New System.Drawing.Size(173, 20)
        Me.cbMotivo.TabIndex = 1
        Me.cbMotivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDocSol)
        Me.UiGroupBox1.Controls.Add(Me.txtTotalDocDol)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Location = New System.Drawing.Point(6, 139)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(194, 76)
        Me.UiGroupBox1.TabIndex = 15
        Me.UiGroupBox1.Text = "Total Documento"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalDocSol
        '
        Me.txtTotalDocSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalDocSol.Enabled = False
        Me.txtTotalDocSol.FormatString = "n"
        Me.txtTotalDocSol.Location = New System.Drawing.Point(67, 49)
        Me.txtTotalDocSol.Name = "txtTotalDocSol"
        Me.txtTotalDocSol.Size = New System.Drawing.Size(103, 20)
        Me.txtTotalDocSol.TabIndex = 2
        Me.txtTotalDocSol.TabStop = False
        Me.txtTotalDocSol.Text = "0.00"
        Me.txtTotalDocSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalDocDol
        '
        Me.txtTotalDocDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalDocDol.Enabled = False
        Me.txtTotalDocDol.FormatString = "n"
        Me.txtTotalDocDol.Location = New System.Drawing.Point(67, 25)
        Me.txtTotalDocDol.Name = "txtTotalDocDol"
        Me.txtTotalDocDol.Size = New System.Drawing.Size(103, 20)
        Me.txtTotalDocDol.TabIndex = 1
        Me.txtTotalDocDol.TabStop = False
        Me.txtTotalDocDol.Text = "0.00"
        Me.txtTotalDocDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Soles :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Dolares :"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtTotalPagoSol)
        Me.UiGroupBox2.Controls.Add(Me.txtTotalPagoDol)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Location = New System.Drawing.Point(225, 139)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(194, 76)
        Me.UiGroupBox2.TabIndex = 16
        Me.UiGroupBox2.Text = "Total Pagado"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTotalPagoSol
        '
        Me.txtTotalPagoSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalPagoSol.Enabled = False
        Me.txtTotalPagoSol.FormatString = "n"
        Me.txtTotalPagoSol.Location = New System.Drawing.Point(69, 49)
        Me.txtTotalPagoSol.Name = "txtTotalPagoSol"
        Me.txtTotalPagoSol.Size = New System.Drawing.Size(109, 20)
        Me.txtTotalPagoSol.TabIndex = 2
        Me.txtTotalPagoSol.TabStop = False
        Me.txtTotalPagoSol.Text = "0.00"
        Me.txtTotalPagoSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtTotalPagoDol
        '
        Me.txtTotalPagoDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotalPagoDol.Enabled = False
        Me.txtTotalPagoDol.FormatString = "n"
        Me.txtTotalPagoDol.Location = New System.Drawing.Point(69, 25)
        Me.txtTotalPagoDol.Name = "txtTotalPagoDol"
        Me.txtTotalPagoDol.Size = New System.Drawing.Size(109, 20)
        Me.txtTotalPagoDol.TabIndex = 1
        Me.txtTotalPagoDol.TabStop = False
        Me.txtTotalPagoDol.Text = "0.00"
        Me.txtTotalPagoDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Soles :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Dolares :"
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.Controls.Add(Me.txtPagarSol)
        Me.UiGroupBox3.Controls.Add(Me.txtPagarDol)
        Me.UiGroupBox3.Controls.Add(Me.Label11)
        Me.UiGroupBox3.Controls.Add(Me.Label12)
        Me.UiGroupBox3.Location = New System.Drawing.Point(7, 222)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(202, 76)
        Me.UiGroupBox3.TabIndex = 17
        Me.UiGroupBox3.Text = "A Pagar"
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtPagarSol
        '
        Me.txtPagarSol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPagarSol.Enabled = False
        Me.txtPagarSol.FormatString = "n"
        Me.txtPagarSol.Location = New System.Drawing.Point(66, 47)
        Me.txtPagarSol.Name = "txtPagarSol"
        Me.txtPagarSol.Size = New System.Drawing.Size(103, 20)
        Me.txtPagarSol.TabIndex = 2
        Me.txtPagarSol.TabStop = False
        Me.txtPagarSol.Text = "0.00"
        Me.txtPagarSol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'txtPagarDol
        '
        Me.txtPagarDol.DisabledForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPagarDol.Enabled = False
        Me.txtPagarDol.FormatString = "n"
        Me.txtPagarDol.Location = New System.Drawing.Point(66, 23)
        Me.txtPagarDol.Name = "txtPagarDol"
        Me.txtPagarDol.Size = New System.Drawing.Size(103, 20)
        Me.txtPagarDol.TabIndex = 1
        Me.txtPagarDol.Text = "0.00"
        Me.txtPagarDol.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Soles :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Dolares :"
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.Controls.Add(Me.txtTipoCambio)
        Me.UiGroupBox4.Controls.Add(Me.Label6)
        Me.UiGroupBox4.Controls.Add(Me.txtMoneda)
        Me.UiGroupBox4.Controls.Add(Me.Label5)
        Me.UiGroupBox4.Controls.Add(Me.txtFecha)
        Me.UiGroupBox4.Controls.Add(Me.Label4)
        Me.UiGroupBox4.Controls.Add(Me.txtCliente)
        Me.UiGroupBox4.Controls.Add(Me.Label3)
        Me.UiGroupBox4.Location = New System.Drawing.Point(6, 72)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(413, 61)
        Me.UiGroupBox4.TabIndex = 18
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Location = New System.Drawing.Point(279, 35)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(64, 20)
        Me.txtTipoCambio.TabIndex = 4
        Me.txtTipoCambio.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(240, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "T.C. :"
        '
        'txtMoneda
        '
        Me.txtMoneda.Location = New System.Drawing.Point(196, 35)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(40, 20)
        Me.txtMoneda.TabIndex = 3
        Me.txtMoneda.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Moneda :"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(57, 35)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(79, 20)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Fecha :"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(57, 12)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(337, 20)
        Me.txtCliente.TabIndex = 1
        Me.txtCliente.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Cliente :"
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.Controls.Add(Me.cbDocumento)
        Me.UiGroupBox5.Controls.Add(Me.txtNumDoc)
        Me.UiGroupBox5.Controls.Add(Me.txtSerie)
        Me.UiGroupBox5.Controls.Add(Me.Label2)
        Me.UiGroupBox5.Location = New System.Drawing.Point(6, 29)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(412, 44)
        Me.UiGroupBox5.TabIndex = 19
        Me.UiGroupBox5.Text = "Documento"
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbDocumento
        '
        Me.cbDocumento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cbDocumento_DesignTimeLayout.LayoutString = resources.GetString("cbDocumento_DesignTimeLayout.LayoutString")
        Me.cbDocumento.DesignTimeLayout = cbDocumento_DesignTimeLayout
        Me.cbDocumento.Enabled = False
        Me.cbDocumento.Location = New System.Drawing.Point(79, 16)
        Me.cbDocumento.Name = "cbDocumento"
        Me.cbDocumento.SelectedIndex = -1
        Me.cbDocumento.SelectedItem = Nothing
        Me.cbDocumento.Size = New System.Drawing.Size(194, 20)
        Me.cbDocumento.TabIndex = 2
        Me.cbDocumento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(318, 16)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(86, 20)
        Me.txtNumDoc.TabIndex = 4
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(275, 16)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(40, 20)
        Me.txtSerie.TabIndex = 3
        Me.txtSerie.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Documento :"
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmPlanillaDet
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(428, 335)
        Me.ControlBox = False
        Me.Controls.Add(Me.UiGroupBox5)
        Me.Controls.Add(Me.UiGroupBox4)
        Me.Controls.Add(Me.UiGroupBox3)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.cbMotivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlanillaDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalles de Planilla"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.cbMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        Me.UiGroupBox5.PerformLayout()
        CType(Me.cbDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbMotivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDocSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalDocDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPagoSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalPagoDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPagarSol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPagarDol As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbDocumento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner

End Class
