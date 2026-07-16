<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCotizacion_Recalcular
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCotizacion_Recalcular))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnRecalcular = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descuento Total"
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnRecalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRecalcular.Location = New System.Drawing.Point(19, 102)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(81, 23)
        Me.btnRecalcular.TabIndex = 2
        Me.btnRecalcular.Text = "Recalcular"
        Me.btnRecalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRecalcular.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(106, 102)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(72, 23)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.TabStop = False
        Me.btnSalir.Text = "Cancelar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtDescuento
        '
        Me.txtDescuento.Location = New System.Drawing.Point(53, 55)
        Me.txtDescuento.MaxLength = 12
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(82, 20)
        Me.txtDescuento.TabIndex = 20
        Me.txtDescuento.TabStop = False
        Me.txtDescuento.Text = "0.00"
        Me.txtDescuento.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'frmCotizacion_Recalcular
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(196, 154)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnRecalcular)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(204, 188)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(204, 188)
        Me.Name = "frmCotizacion_Recalcular"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recalcular Descuento "
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRecalcular As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents txtDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
End Class
