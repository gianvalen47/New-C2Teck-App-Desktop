<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudCompra_Aprobar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudCompra_Aprobar))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAprobar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.cbAprobar = New Janus.Windows.EditControls.UIRadioButton()
        Me.cbRechazar = New Janus.Windows.EditControls.UIRadioButton()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(12, 107)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(308, 118)
        Me.txtObservacion.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Observación : "
        '
        'btnAprobar
        '
        Me.btnAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAprobar.Location = New System.Drawing.Point(86, 231)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(78, 25)
        Me.btnAprobar.TabIndex = 2
        Me.btnAprobar.Text = "Aprobar"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.Location = New System.Drawing.Point(171, 231)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(78, 25)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Cancelar"
        '
        'cbAprobar
        '
        Me.cbAprobar.Checked = True
        Me.cbAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAprobar.Location = New System.Drawing.Point(119, 25)
        Me.cbAprobar.Name = "cbAprobar"
        Me.cbAprobar.Size = New System.Drawing.Size(104, 23)
        Me.cbAprobar.TabIndex = 4
        Me.cbAprobar.TabStop = True
        Me.cbAprobar.Text = "Aprobar"
        '
        'cbRechazar
        '
        Me.cbRechazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRechazar.Location = New System.Drawing.Point(119, 54)
        Me.cbRechazar.Name = "cbRechazar"
        Me.cbRechazar.Size = New System.Drawing.Size(104, 23)
        Me.cbRechazar.TabIndex = 5
        Me.cbRechazar.Text = "Rechazar"
        '
        'frmComSolicitudCompra_Aprobar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(329, 267)
        Me.Controls.Add(Me.cbRechazar)
        Me.Controls.Add(Me.cbAprobar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAprobar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtObservacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudCompra_Aprobar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmComSolicitudCompra_Aprobar"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnAprobar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents cbRechazar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents cbAprobar As Janus.Windows.EditControls.UIRadioButton
End Class
