<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudCompra_Observacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudCompra_Observacion))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtOservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.biAceptar = New Janus.Windows.EditControls.UIButton()
        Me.biCancelar = New Janus.Windows.EditControls.UIButton()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtOservacion
        '
        Me.txtOservacion.Location = New System.Drawing.Point(12, 12)
        Me.txtOservacion.Multiline = True
        Me.txtOservacion.Name = "txtOservacion"
        Me.txtOservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOservacion.Size = New System.Drawing.Size(491, 301)
        Me.txtOservacion.TabIndex = 0
        '
        'biAceptar
        '
        Me.biAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.biAceptar.Location = New System.Drawing.Point(173, 319)
        Me.biAceptar.Name = "biAceptar"
        Me.biAceptar.Size = New System.Drawing.Size(77, 25)
        Me.biAceptar.TabIndex = 1
        Me.biAceptar.Text = "Aceptar"
        '
        'biCancelar
        '
        Me.biCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.biCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.biCancelar.Location = New System.Drawing.Point(265, 319)
        Me.biCancelar.Name = "biCancelar"
        Me.biCancelar.Size = New System.Drawing.Size(83, 25)
        Me.biCancelar.TabIndex = 2
        Me.biCancelar.Text = "Cancelar"
        '
        'frmComSolicitudCompra_Observacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(514, 353)
        Me.Controls.Add(Me.biCancelar)
        Me.Controls.Add(Me.biAceptar)
        Me.Controls.Add(Me.txtOservacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudCompra_Observacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Observacion"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents biCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents biAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtOservacion As Janus.Windows.GridEX.EditControls.EditBox
End Class
