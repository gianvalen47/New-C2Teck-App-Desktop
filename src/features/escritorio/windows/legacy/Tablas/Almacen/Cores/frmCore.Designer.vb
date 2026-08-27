<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCore))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.gbNuevocodigo = New System.Windows.Forms.GroupBox
        Me.txtRubro = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtClase = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUniMedida = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDeaMer = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDesMer1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPais = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtMarca = New System.Windows.Forms.TextBox
        Me.txtCodMer = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.gbPrecios = New System.Windows.Forms.GroupBox
        Me.txtCorMer = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNuevocodigo.SuspendLayout()
        Me.gbPrecios.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(301, 202)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(448, 202)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbNuevocodigo
        '
        Me.gbNuevocodigo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbNuevocodigo.Controls.Add(Me.txtRubro)
        Me.gbNuevocodigo.Controls.Add(Me.Label4)
        Me.gbNuevocodigo.Controls.Add(Me.txtClase)
        Me.gbNuevocodigo.Controls.Add(Me.Label3)
        Me.gbNuevocodigo.Controls.Add(Me.txtUniMedida)
        Me.gbNuevocodigo.Controls.Add(Me.Label2)
        Me.gbNuevocodigo.Controls.Add(Me.txtDeaMer)
        Me.gbNuevocodigo.Controls.Add(Me.Label5)
        Me.gbNuevocodigo.Controls.Add(Me.txtDesMer1)
        Me.gbNuevocodigo.Controls.Add(Me.Label10)
        Me.gbNuevocodigo.Controls.Add(Me.txtPais)
        Me.gbNuevocodigo.Controls.Add(Me.Label11)
        Me.gbNuevocodigo.Controls.Add(Me.txtMarca)
        Me.gbNuevocodigo.Controls.Add(Me.txtCodMer)
        Me.gbNuevocodigo.Controls.Add(Me.Label17)
        Me.gbNuevocodigo.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbNuevocodigo.Controls.Add(Me.Label13)
        Me.gbNuevocodigo.Location = New System.Drawing.Point(8, 14)
        Me.gbNuevocodigo.Name = "gbNuevocodigo"
        Me.gbNuevocodigo.Size = New System.Drawing.Size(517, 128)
        Me.gbNuevocodigo.TabIndex = 43
        Me.gbNuevocodigo.TabStop = False
        Me.gbNuevocodigo.Text = "Mercadería"
        '
        'txtRubro
        '
        Me.txtRubro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRubro.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtRubro.Location = New System.Drawing.Point(395, 95)
        Me.txtRubro.MaxLength = 3
        Me.txtRubro.Name = "txtRubro"
        Me.txtRubro.ReadOnly = True
        Me.txtRubro.Size = New System.Drawing.Size(114, 20)
        Me.txtRubro.TabIndex = 45
        Me.txtRubro.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(349, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Rubro"
        '
        'txtClase
        '
        Me.txtClase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClase.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtClase.Location = New System.Drawing.Point(395, 67)
        Me.txtClase.MaxLength = 3
        Me.txtClase.Name = "txtClase"
        Me.txtClase.ReadOnly = True
        Me.txtClase.Size = New System.Drawing.Size(114, 20)
        Me.txtClase.TabIndex = 43
        Me.txtClase.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(351, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Clase"
        '
        'txtUniMedida
        '
        Me.txtUniMedida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUniMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUniMedida.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtUniMedida.Location = New System.Drawing.Point(394, 16)
        Me.txtUniMedida.MaxLength = 3
        Me.txtUniMedida.Name = "txtUniMedida"
        Me.txtUniMedida.ReadOnly = True
        Me.txtUniMedida.Size = New System.Drawing.Size(114, 20)
        Me.txtUniMedida.TabIndex = 41
        Me.txtUniMedida.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(306, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Unidad Medida"
        '
        'txtDeaMer
        '
        Me.txtDeaMer.BackColor = System.Drawing.SystemColors.Control
        Me.txtDeaMer.Location = New System.Drawing.Point(71, 91)
        Me.txtDeaMer.MaxLength = 10
        Me.txtDeaMer.Name = "txtDeaMer"
        Me.txtDeaMer.ReadOnly = True
        Me.txtDeaMer.Size = New System.Drawing.Size(79, 20)
        Me.txtDeaMer.TabIndex = 2
        Me.txtDeaMer.TabStop = False
        Me.txtDeaMer.Text = "0.00"
        Me.txtDeaMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDeaMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Precio Fob"
        '
        'txtDesMer1
        '
        Me.txtDesMer1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesMer1.Location = New System.Drawing.Point(70, 39)
        Me.txtDesMer1.MaxLength = 50
        Me.txtDesMer1.Name = "txtDesMer1"
        Me.txtDesMer1.ReadOnly = True
        Me.txtDesMer1.Size = New System.Drawing.Size(280, 20)
        Me.txtDesMer1.TabIndex = 4
        Me.txtDesMer1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Descrip"
        '
        'txtPais
        '
        Me.txtPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPais.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPais.Location = New System.Drawing.Point(395, 41)
        Me.txtPais.MaxLength = 3
        Me.txtPais.Name = "txtPais"
        Me.txtPais.ReadOnly = True
        Me.txtPais.Size = New System.Drawing.Size(114, 20)
        Me.txtPais.TabIndex = 5
        Me.txtPais.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "País"
        '
        'txtMarca
        '
        Me.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMarca.Location = New System.Drawing.Point(71, 65)
        Me.txtMarca.MaxLength = 3
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(235, 20)
        Me.txtMarca.TabIndex = 7
        Me.txtMarca.TabStop = False
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodMer.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodMer.Location = New System.Drawing.Point(70, 17)
        Me.txtCodMer.MaxLength = 50
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.Size = New System.Drawing.Size(131, 20)
        Me.txtCodMer.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(26, 70)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 13)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Marca"
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = CType(resources.GetObject("btnBuscarMercaderia.Image"), System.Drawing.Image)
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(201, 16)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderia.TabIndex = 1
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Código"
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(375, 202)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(73, 25)
        Me.btnEliminar.TabIndex = 4
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'gbPrecios
        '
        Me.gbPrecios.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbPrecios.Controls.Add(Me.txtCorMer)
        Me.gbPrecios.Controls.Add(Me.Label1)
        Me.gbPrecios.Location = New System.Drawing.Point(12, 160)
        Me.gbPrecios.Name = "gbPrecios"
        Me.gbPrecios.Size = New System.Drawing.Size(167, 44)
        Me.gbPrecios.TabIndex = 24
        Me.gbPrecios.TabStop = False
        Me.gbPrecios.Text = "Precio"
        '
        'txtCorMer
        '
        Me.txtCorMer.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtCorMer.Location = New System.Drawing.Point(42, 16)
        Me.txtCorMer.MaxLength = 10
        Me.txtCorMer.Name = "txtCorMer"
        Me.txtCorMer.Size = New System.Drawing.Size(114, 20)
        Me.txtCorMer.TabIndex = 2
        Me.txtCorMer.TabStop = False
        Me.txtCorMer.Text = "0.00"
        Me.txtCorMer.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCorMer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Core"
        '
        'frmCore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 235)
        Me.Controls.Add(Me.gbPrecios)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.gbNuevocodigo)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCore"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precio Core"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNuevocodigo.ResumeLayout(False)
        Me.gbNuevocodigo.PerformLayout()
        Me.gbPrecios.ResumeLayout(False)
        Me.gbPrecios.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gbNuevocodigo As System.Windows.Forms.GroupBox
    Friend WithEvents txtDeaMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDesMer1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtUniMedida As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClase As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRubro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents gbPrecios As System.Windows.Forms.GroupBox
    Friend WithEvents txtCorMer As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
