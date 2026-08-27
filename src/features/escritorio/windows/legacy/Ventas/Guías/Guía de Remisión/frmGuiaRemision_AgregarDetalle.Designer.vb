<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuiaRemision_AgregarDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuiaRemision_AgregarDetalle))
        Me.txtItem = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.cbNoCore = New System.Windows.Forms.CheckBox()
        Me.lblPrecioSug2 = New System.Windows.Forms.Label()
        Me.lblDsctoSug2 = New System.Windows.Forms.Label()
        Me.cbRegalo = New System.Windows.Forms.CheckBox()
        Me.cbSugerir = New System.Windows.Forms.CheckBox()
        Me.txtDsctoSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPrecioSug = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblDsctoSug = New System.Windows.Forms.Label()
        Me.lblPrecioSug = New System.Windows.Forms.Label()
        Me.txtCodMer = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDscMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.txtCanMer = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.txtPreMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDesMer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbDatos.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtItem
        '
        Me.txtItem.BackColor = System.Drawing.Color.Beige
        Me.txtItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItem.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtItem.Location = New System.Drawing.Point(512, 13)
        Me.txtItem.Maximum = 999
        Me.txtItem.MaxLength = 3
        Me.txtItem.Minimum = 1
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(66, 22)
        Me.txtItem.TabIndex = 5
        Me.txtItem.TabStop = False
        Me.txtItem.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtItem.Value = 1
        Me.txtItem.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.cbNoCore)
        Me.gbDatos.Controls.Add(Me.lblPrecioSug2)
        Me.gbDatos.Controls.Add(Me.lblDsctoSug2)
        Me.gbDatos.Controls.Add(Me.cbRegalo)
        Me.gbDatos.Controls.Add(Me.cbSugerir)
        Me.gbDatos.Controls.Add(Me.txtDsctoSug)
        Me.gbDatos.Controls.Add(Me.txtPrecioSug)
        Me.gbDatos.Controls.Add(Me.lblDsctoSug)
        Me.gbDatos.Controls.Add(Me.lblPrecioSug)
        Me.gbDatos.Controls.Add(Me.txtCodMer)
        Me.gbDatos.Controls.Add(Me.txtTotal)
        Me.gbDatos.Controls.Add(Me.txtItem)
        Me.gbDatos.Controls.Add(Me.Label10)
        Me.gbDatos.Controls.Add(Me.txtDscMer)
        Me.gbDatos.Controls.Add(Me.txtStock)
        Me.gbDatos.Controls.Add(Me.txtCanMer)
        Me.gbDatos.Controls.Add(Me.txtPreMer)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.Panel1)
        Me.gbDatos.Controls.Add(Me.txtDesMer)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label14)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Location = New System.Drawing.Point(3, 5)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(591, 196)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Articulo"
        '
        'cbNoCore
        '
        Me.cbNoCore.AutoSize = True
        Me.cbNoCore.Location = New System.Drawing.Point(13, 126)
        Me.cbNoCore.Name = "cbNoCore"
        Me.cbNoCore.Size = New System.Drawing.Size(111, 17)
        Me.cbNoCore.TabIndex = 24
        Me.cbNoCore.TabStop = False
        Me.cbNoCore.Text = "No Incluir Core"
        Me.cbNoCore.UseVisualStyleBackColor = True
        '
        'lblPrecioSug2
        '
        Me.lblPrecioSug2.AutoSize = True
        Me.lblPrecioSug2.Location = New System.Drawing.Point(246, 133)
        Me.lblPrecioSug2.Name = "lblPrecioSug2"
        Me.lblPrecioSug2.Size = New System.Drawing.Size(65, 13)
        Me.lblPrecioSug2.TabIndex = 23
        Me.lblPrecioSug2.Text = "Sugerido :"
        Me.lblPrecioSug2.Visible = False
        '
        'lblDsctoSug2
        '
        Me.lblDsctoSug2.AutoSize = True
        Me.lblDsctoSug2.Location = New System.Drawing.Point(421, 133)
        Me.lblDsctoSug2.Name = "lblDsctoSug2"
        Me.lblDsctoSug2.Size = New System.Drawing.Size(65, 13)
        Me.lblDsctoSug2.TabIndex = 22
        Me.lblDsctoSug2.Text = "Sugerido :"
        Me.lblDsctoSug2.Visible = False
        '
        'cbRegalo
        '
        Me.cbRegalo.AutoSize = True
        Me.cbRegalo.Location = New System.Drawing.Point(520, 92)
        Me.cbRegalo.Name = "cbRegalo"
        Me.cbRegalo.Size = New System.Drawing.Size(66, 17)
        Me.cbRegalo.TabIndex = 21
        Me.cbRegalo.TabStop = False
        Me.cbRegalo.Text = "Regalo"
        Me.cbRegalo.UseVisualStyleBackColor = True
        '
        'cbSugerir
        '
        Me.cbSugerir.AutoSize = True
        Me.cbSugerir.Location = New System.Drawing.Point(134, 126)
        Me.cbSugerir.Name = "cbSugerir"
        Me.cbSugerir.Size = New System.Drawing.Size(106, 17)
        Me.cbSugerir.TabIndex = 20
        Me.cbSugerir.TabStop = False
        Me.cbSugerir.Text = "Sugerir Precio"
        Me.cbSugerir.UseVisualStyleBackColor = True
        '
        'txtDsctoSug
        '
        Me.txtDsctoSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDsctoSug.FormatString = "#0.00"
        Me.txtDsctoSug.Location = New System.Drawing.Point(494, 126)
        Me.txtDsctoSug.Name = "txtDsctoSug"
        Me.txtDsctoSug.Size = New System.Drawing.Size(85, 20)
        Me.txtDsctoSug.TabIndex = 19
        Me.txtDsctoSug.Text = "0.00"
        Me.txtDsctoSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDsctoSug.Visible = False
        '
        'txtPrecioSug
        '
        Me.txtPrecioSug.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioSug.FormatString = "#0.00"
        Me.txtPrecioSug.Location = New System.Drawing.Point(315, 126)
        Me.txtPrecioSug.Name = "txtPrecioSug"
        Me.txtPrecioSug.Size = New System.Drawing.Size(88, 20)
        Me.txtPrecioSug.TabIndex = 17
        Me.txtPrecioSug.Text = "0.00"
        Me.txtPrecioSug.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPrecioSug.Visible = False
        '
        'lblDsctoSug
        '
        Me.lblDsctoSug.AutoSize = True
        Me.lblDsctoSug.Location = New System.Drawing.Point(421, 118)
        Me.lblDsctoSug.Name = "lblDsctoSug"
        Me.lblDsctoSug.Size = New System.Drawing.Size(68, 13)
        Me.lblDsctoSug.TabIndex = 18
        Me.lblDsctoSug.Text = "Descuento"
        Me.lblDsctoSug.Visible = False
        '
        'lblPrecioSug
        '
        Me.lblPrecioSug.AutoSize = True
        Me.lblPrecioSug.Location = New System.Drawing.Point(246, 118)
        Me.lblPrecioSug.Name = "lblPrecioSug"
        Me.lblPrecioSug.Size = New System.Drawing.Size(43, 13)
        Me.lblPrecioSug.TabIndex = 16
        Me.lblPrecioSug.Text = "Precio"
        Me.lblPrecioSug.Visible = False
        '
        'txtCodMer
        '
        Me.txtCodMer.ButtonImage = CType(resources.GetObject("txtCodMer.ButtonImage"), System.Drawing.Image)
        Me.txtCodMer.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Location = New System.Drawing.Point(95, 13)
        Me.txtCodMer.MaxLength = 30
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(185, 20)
        Me.txtCodMer.TabIndex = 1
        Me.txtCodMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.DarkKhaki
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotal.FormatString = "#,###,##0.00"
        Me.txtTotal.Location = New System.Drawing.Point(449, 161)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(131, 21)
        Me.txtTotal.TabIndex = 15
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(469, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Item :"
        '
        'txtDscMer
        '
        Me.txtDscMer.FormatString = "#0.00"
        Me.txtDscMer.Location = New System.Drawing.Point(423, 88)
        Me.txtDscMer.MaxLength = 10
        Me.txtDscMer.Name = "txtDscMer"
        Me.txtDscMer.Size = New System.Drawing.Size(79, 20)
        Me.txtDscMer.TabIndex = 13
        Me.txtDscMer.Text = "0.00"
        Me.txtDscMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDscMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtStock
        '
        Me.txtStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStock.Location = New System.Drawing.Point(360, 14)
        Me.txtStock.MaxLength = 50
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(72, 20)
        Me.txtStock.TabIndex = 3
        Me.txtStock.TabStop = False
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCanMer
        '
        Me.txtCanMer.Location = New System.Drawing.Point(95, 88)
        Me.txtCanMer.Maximum = 10000
        Me.txtCanMer.MaxLength = 200
        Me.txtCanMer.Minimum = 1
        Me.txtCanMer.Name = "txtCanMer"
        Me.txtCanMer.Size = New System.Drawing.Size(70, 20)
        Me.txtCanMer.TabIndex = 9
        Me.txtCanMer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCanMer.Value = 1
        Me.txtCanMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPreMer
        '
        Me.txtPreMer.FormatString = "#,###,##0.00"
        Me.txtPreMer.Location = New System.Drawing.Point(233, 88)
        Me.txtPreMer.MaxLength = 10
        Me.txtPreMer.Name = "txtPreMer"
        Me.txtPreMer.Size = New System.Drawing.Size(91, 20)
        Me.txtPreMer.TabIndex = 11
        Me.txtPreMer.Text = "0.00"
        Me.txtPreMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPreMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(300, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Stock :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(178, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Precio :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Desktop
        Me.Panel1.Location = New System.Drawing.Point(15, 154)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(564, 1)
        Me.Panel1.TabIndex = 14
        '
        'txtDesMer
        '
        Me.txtDesMer.BackColor = System.Drawing.SystemColors.Window
        Me.txtDesMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesMer.Location = New System.Drawing.Point(95, 37)
        Me.txtDesMer.MaxLength = 500
        Me.txtDesMer.Multiline = True
        Me.txtDesMer.Name = "txtDesMer"
        Me.txtDesMer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesMer.Size = New System.Drawing.Size(484, 48)
        Me.txtDesMer.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descripción :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(338, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Descuento :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Cantidad :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Location = New System.Drawing.Point(388, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "TOTAL"
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
        Me.btnCancelar.Location = New System.Drawing.Point(498, 207)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 25)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(411, 207)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(85, 25)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmGuiaRemision_AgregarDetalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(604, 246)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGuiaRemision_AgregarDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalles"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtItem As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDscMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents txtCanMer As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents txtPreMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtDesMer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtCodMer As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents cbSugerir As System.Windows.Forms.CheckBox
    Friend WithEvents txtDsctoSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPrecioSug As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblDsctoSug As System.Windows.Forms.Label
    Friend WithEvents lblPrecioSug As System.Windows.Forms.Label
    Friend WithEvents cbRegalo As System.Windows.Forms.CheckBox
    Friend WithEvents cbNoCore As System.Windows.Forms.CheckBox
    Friend WithEvents lblPrecioSug2 As System.Windows.Forms.Label
    Friend WithEvents lblDsctoSug2 As System.Windows.Forms.Label

End Class
