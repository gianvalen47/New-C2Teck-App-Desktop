<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVale_AgregarDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVale_AgregarDetalle))
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDscMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.txtCanMer = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.txtPreMer = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDesMer = New System.Windows.Forms.TextBox()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.DarkKhaki
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtTotal.Location = New System.Drawing.Point(251, 85)
        Me.txtTotal.MaxLength = 5
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(112, 21)
        Me.txtTotal.TabIndex = 7
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDscMer
        '
        Me.txtDscMer.Location = New System.Drawing.Point(301, 59)
        Me.txtDscMer.MaxLength = 10
        Me.txtDscMer.Name = "txtDscMer"
        Me.txtDscMer.Size = New System.Drawing.Size(62, 20)
        Me.txtDscMer.TabIndex = 6
        Me.txtDscMer.Text = "0.00"
        Me.txtDscMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDscMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtStock
        '
        Me.txtStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStock.Location = New System.Drawing.Point(301, 14)
        Me.txtStock.MaxLength = 50
        Me.txtStock.Name = "txtStock"
        Me.txtStock.ReadOnly = True
        Me.txtStock.Size = New System.Drawing.Size(62, 20)
        Me.txtStock.TabIndex = 2
        Me.txtStock.TabStop = False
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCanMer
        '
        Me.txtCanMer.Location = New System.Drawing.Point(67, 59)
        Me.txtCanMer.Maximum = 10000
        Me.txtCanMer.MaxLength = 200
        Me.txtCanMer.Minimum = 1
        Me.txtCanMer.Name = "txtCanMer"
        Me.txtCanMer.Size = New System.Drawing.Size(56, 20)
        Me.txtCanMer.TabIndex = 4
        Me.txtCanMer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCanMer.Value = 1
        Me.txtCanMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPreMer
        '
        Me.txtPreMer.Location = New System.Drawing.Point(175, 59)
        Me.txtPreMer.MaxLength = 10
        Me.txtPreMer.Name = "txtPreMer"
        Me.txtPreMer.Size = New System.Drawing.Size(58, 20)
        Me.txtPreMer.TabIndex = 5
        Me.txtPreMer.Text = "0.00"
        Me.txtPreMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPreMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.txtTotal)
        Me.gbDatos.Controls.Add(Me.txtDscMer)
        Me.gbDatos.Controls.Add(Me.txtStock)
        Me.gbDatos.Controls.Add(Me.txtCanMer)
        Me.gbDatos.Controls.Add(Me.txtPreMer)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbDatos.Controls.Add(Me.Panel1)
        Me.gbDatos.Controls.Add(Me.txtDesMer)
        Me.gbDatos.Controls.Add(Me.txtCodMer)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label14)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Location = New System.Drawing.Point(3, 3)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(371, 112)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos del Articulo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(262, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Stock"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(138, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Precio"
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = CType(resources.GetObject("btnBuscarMercaderia.Image"), System.Drawing.Image)
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(199, 14)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderia.TabIndex = 1
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Desktop
        Me.Panel1.Location = New System.Drawing.Point(13, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(350, 1)
        Me.Panel1.TabIndex = 11
        '
        'txtDesMer
        '
        Me.txtDesMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesMer.Location = New System.Drawing.Point(67, 37)
        Me.txtDesMer.MaxLength = 50
        Me.txtDesMer.Name = "txtDesMer"
        Me.txtDesMer.ReadOnly = True
        Me.txtDesMer.Size = New System.Drawing.Size(296, 20)
        Me.txtDesMer.TabIndex = 3
        Me.txtDesMer.TabStop = False
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodMer.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodMer.Location = New System.Drawing.Point(67, 15)
        Me.txtCodMer.MaxLength = 30
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.ReadOnly = True
        Me.txtCodMer.Size = New System.Drawing.Size(132, 20)
        Me.txtCodMer.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Código"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(242, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Descuento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Cantidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Location = New System.Drawing.Point(191, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "TOTAL"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(218, 119)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(293, 119)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmVale_AgregarDetalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(399, 168)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVale_AgregarDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Detalle"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDscMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents txtCanMer As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents txtPreMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtDesMer As System.Windows.Forms.TextBox
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner

End Class
