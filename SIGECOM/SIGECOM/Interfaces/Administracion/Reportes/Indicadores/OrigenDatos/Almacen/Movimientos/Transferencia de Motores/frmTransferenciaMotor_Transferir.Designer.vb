<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferenciaMotor_Transferir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferenciaMotor_Transferir))
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbAlmacen = New System.Windows.Forms.RadioButton
        Me.rbMotor = New System.Windows.Forms.RadioButton
        Me.btnBuscarMercaderia = New System.Windows.Forms.Button
        Me.txtMotor = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtalmacen = New System.Windows.Forms.TextBox
        Me.btnBuscarAlmacen = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.gbDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.GroupBox1)
        Me.gbDatos.Controls.Add(Me.btnBuscarMercaderia)
        Me.gbDatos.Controls.Add(Me.txtMotor)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.txtalmacen)
        Me.gbDatos.Controls.Add(Me.btnBuscarAlmacen)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(5, 1)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(397, 96)
        Me.gbDatos.TabIndex = 9
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos de la Trnaferencia"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbAlmacen)
        Me.GroupBox1.Controls.Add(Me.rbMotor)
        Me.GroupBox1.Location = New System.Drawing.Point(116, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 32)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'rbAlmacen
        '
        Me.rbAlmacen.AutoSize = True
        Me.rbAlmacen.Location = New System.Drawing.Point(115, 11)
        Me.rbAlmacen.Name = "rbAlmacen"
        Me.rbAlmacen.Size = New System.Drawing.Size(84, 17)
        Me.rbAlmacen.TabIndex = 1
        Me.rbAlmacen.TabStop = True
        Me.rbAlmacen.Text = "A almacén"
        Me.rbAlmacen.UseVisualStyleBackColor = True
        '
        'rbMotor
        '
        Me.rbMotor.AutoSize = True
        Me.rbMotor.Checked = True
        Me.rbMotor.Location = New System.Drawing.Point(22, 11)
        Me.rbMotor.Name = "rbMotor"
        Me.rbMotor.Size = New System.Drawing.Size(69, 17)
        Me.rbMotor.TabIndex = 0
        Me.rbMotor.TabStop = True
        Me.rbMotor.Text = "A Motor"
        Me.rbMotor.UseVisualStyleBackColor = True
        '
        'btnBuscarMercaderia
        '
        Me.btnBuscarMercaderia.Image = CType(resources.GetObject("btnBuscarMercaderia.Image"), System.Drawing.Image)
        Me.btnBuscarMercaderia.Location = New System.Drawing.Point(207, 71)
        Me.btnBuscarMercaderia.Name = "btnBuscarMercaderia"
        Me.btnBuscarMercaderia.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarMercaderia.TabIndex = 4
        Me.btnBuscarMercaderia.TabStop = False
        Me.btnBuscarMercaderia.UseVisualStyleBackColor = True
        '
        'txtMotor
        '
        Me.txtMotor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMotor.Location = New System.Drawing.Point(89, 72)
        Me.txtMotor.MaxLength = 50
        Me.txtMotor.Name = "txtMotor"
        Me.txtMotor.ReadOnly = True
        Me.txtMotor.Size = New System.Drawing.Size(118, 20)
        Me.txtMotor.TabIndex = 3
        Me.txtMotor.Text = " "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Motor Destino"
        '
        'txtalmacen
        '
        Me.txtalmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtalmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtalmacen.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtalmacen.Location = New System.Drawing.Point(89, 48)
        Me.txtalmacen.MaxLength = 3
        Me.txtalmacen.Name = "txtalmacen"
        Me.txtalmacen.ReadOnly = True
        Me.txtalmacen.Size = New System.Drawing.Size(275, 20)
        Me.txtalmacen.TabIndex = 1
        '
        'btnBuscarAlmacen
        '
        Me.btnBuscarAlmacen.Image = CType(resources.GetObject("btnBuscarAlmacen.Image"), System.Drawing.Image)
        Me.btnBuscarAlmacen.Location = New System.Drawing.Point(364, 47)
        Me.btnBuscarAlmacen.Name = "btnBuscarAlmacen"
        Me.btnBuscarAlmacen.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarAlmacen.TabIndex = 2
        Me.btnBuscarAlmacen.TabStop = False
        Me.btnBuscarAlmacen.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Almacén"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(193, 101)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(133, 25)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Transferir Documento"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(327, 101)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmTransferenciaMotor_Transferir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 129)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(414, 163)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(414, 163)
        Me.Name = "frmTransferenciaMotor_Transferir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Transferir Documento"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtalmacen As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarAlmacen As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMotor As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscarMercaderia As System.Windows.Forms.Button
    Friend WithEvents txtMotor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbAlmacen As System.Windows.Forms.RadioButton

End Class
