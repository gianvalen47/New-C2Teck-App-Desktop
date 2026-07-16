<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios_Cotizacion_Aprobar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicios_Cotizacion_Aprobar))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rbAprobar = New System.Windows.Forms.RadioButton()
        Me.rbDesaprobar = New System.Windows.Forms.RadioButton()
        Me.lblNumCotizacion = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(116, 179)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 23)
        Me.btnAceptar.TabIndex = 128
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(212, 179)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 23)
        Me.btnCancelar.TabIndex = 129
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'rbAprobar
        '
        Me.rbAprobar.AutoSize = True
        Me.rbAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAprobar.Location = New System.Drawing.Point(165, 42)
        Me.rbAprobar.Name = "rbAprobar"
        Me.rbAprobar.Size = New System.Drawing.Size(69, 17)
        Me.rbAprobar.TabIndex = 130
        Me.rbAprobar.TabStop = True
        Me.rbAprobar.Text = "Aprobar"
        Me.rbAprobar.UseVisualStyleBackColor = True
        '
        'rbDesaprobar
        '
        Me.rbDesaprobar.AutoSize = True
        Me.rbDesaprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDesaprobar.Location = New System.Drawing.Point(165, 65)
        Me.rbDesaprobar.Name = "rbDesaprobar"
        Me.rbDesaprobar.Size = New System.Drawing.Size(90, 17)
        Me.rbDesaprobar.TabIndex = 131
        Me.rbDesaprobar.TabStop = True
        Me.rbDesaprobar.Text = "Desaprobar"
        Me.rbDesaprobar.UseVisualStyleBackColor = True
        '
        'lblNumCotizacion
        '
        Me.lblNumCotizacion.AutoSize = True
        Me.lblNumCotizacion.Location = New System.Drawing.Point(157, 18)
        Me.lblNumCotizacion.Name = "lblNumCotizacion"
        Me.lblNumCotizacion.Size = New System.Drawing.Size(88, 13)
        Me.lblNumCotizacion.TabIndex = 133
        Me.lblNumCotizacion.Text = "lblNumCotizacion"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(22, 89)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(356, 82)
        Me.txtObservacion.TabIndex = 134
        '
        'frmServicios_Cotizacion_Aprobar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(400, 212)
        Me.Controls.Add(Me.rbAprobar)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.rbDesaprobar)
        Me.Controls.Add(Me.lblNumCotizacion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios_Cotizacion_Aprobar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aprobar Cotización"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rbDesaprobar As System.Windows.Forms.RadioButton
    Friend WithEvents rbAprobar As System.Windows.Forms.RadioButton
    Friend WithEvents lblNumCotizacion As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
End Class
