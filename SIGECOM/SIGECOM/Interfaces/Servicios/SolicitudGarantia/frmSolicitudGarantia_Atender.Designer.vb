<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolicitudGarantia_Atender
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolicitudGarantia_Atender))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCreditState = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFechaCredit = New Janus.Windows.CalendarCombo.CalendarCombo()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnSalir.Location = New System.Drawing.Point(248, 137)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 28)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnAceptar.Location = New System.Drawing.Point(163, 137)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 28)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Credit State"
        '
        'txtCreditState
        '
        Me.txtCreditState.Location = New System.Drawing.Point(92, 20)
        Me.txtCreditState.Name = "txtCreditState"
        Me.txtCreditState.Size = New System.Drawing.Size(150, 20)
        Me.txtCreditState.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(92, 46)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(368, 69)
        Me.txtObservacion.TabIndex = 3
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtFechaCredit)
        Me.UiGroupBox1.Controls.Add(Me.Label10)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtCreditState)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(466, 123)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.Text = "Atender"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(252, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 557
        Me.Label2.Text = "Fec. Acreditación"
        '
        'txtFechaCredit
        '
        '
        '
        '
        Me.txtFechaCredit.DropDownCalendar.Name = ""
        Me.txtFechaCredit.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaCredit.Location = New System.Drawing.Point(365, 20)
        Me.txtFechaCredit.Name = "txtFechaCredit"
        Me.txtFechaCredit.Size = New System.Drawing.Size(95, 20)
        Me.txtFechaCredit.TabIndex = 2
        Me.txtFechaCredit.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'frmSolicitudGarantia_Atender
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(491, 173)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolicitudGarantia_Atender"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atender Atención de Formato de Orden de Reparación Nº"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCreditState As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFechaCredit As Janus.Windows.CalendarCombo.CalendarCombo
End Class
