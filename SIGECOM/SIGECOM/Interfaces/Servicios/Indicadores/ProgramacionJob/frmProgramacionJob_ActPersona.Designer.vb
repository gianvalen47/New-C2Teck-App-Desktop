<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramacionJob_ActPersona
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramacionJob_ActPersona))
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnPasarCargo = New System.Windows.Forms.Button()
        Me.txtHoraExtra = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarPersonaS = New System.Windows.Forms.Button()
        Me.txtPersona = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtHoraPlaneada = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtHoraReal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        Me.ssBarra.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDetalle
        '
        Me.gbDetalle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gbDetalle.Controls.Add(Me.btnPasarCargo)
        Me.gbDetalle.Controls.Add(Me.txtHoraExtra)
        Me.gbDetalle.Controls.Add(Me.Label3)
        Me.gbDetalle.Controls.Add(Me.btnBuscarPersonaS)
        Me.gbDetalle.Controls.Add(Me.txtPersona)
        Me.gbDetalle.Controls.Add(Me.btnGuardar)
        Me.gbDetalle.Controls.Add(Me.Label10)
        Me.gbDetalle.Controls.Add(Me.Label9)
        Me.gbDetalle.Controls.Add(Me.Label8)
        Me.gbDetalle.Controls.Add(Me.txtHoraPlaneada)
        Me.gbDetalle.Controls.Add(Me.txtHoraReal)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(8, 7)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(742, 101)
        Me.gbDetalle.TabIndex = 212
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnPasarCargo
        '
        Me.btnPasarCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPasarCargo.Image = CType(resources.GetObject("btnPasarCargo.Image"), System.Drawing.Image)
        Me.btnPasarCargo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPasarCargo.Location = New System.Drawing.Point(514, 19)
        Me.btnPasarCargo.Name = "btnPasarCargo"
        Me.btnPasarCargo.Size = New System.Drawing.Size(24, 25)
        Me.btnPasarCargo.TabIndex = 241
        Me.btnPasarCargo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPasarCargo.UseVisualStyleBackColor = True
        Me.btnPasarCargo.Visible = False
        '
        'txtHoraExtra
        '
        Me.txtHoraExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraExtra.Location = New System.Drawing.Point(564, 59)
        Me.txtHoraExtra.MaxLength = 10
        Me.txtHoraExtra.Name = "txtHoraExtra"
        Me.txtHoraExtra.Size = New System.Drawing.Size(47, 20)
        Me.txtHoraExtra.TabIndex = 240
        Me.txtHoraExtra.Text = "0.00"
        Me.txtHoraExtra.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHoraExtra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(59, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Personal :"
        '
        'btnBuscarPersonaS
        '
        Me.btnBuscarPersonaS.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersonaS.Location = New System.Drawing.Point(478, 19)
        Me.btnBuscarPersonaS.Name = "btnBuscarPersonaS"
        Me.btnBuscarPersonaS.Size = New System.Drawing.Size(30, 25)
        Me.btnBuscarPersonaS.TabIndex = 15
        Me.btnBuscarPersonaS.TabStop = False
        Me.btnBuscarPersonaS.UseVisualStyleBackColor = True
        Me.btnBuscarPersonaS.Visible = False
        '
        'txtPersona
        '
        Me.txtPersona.BackColor = System.Drawing.SystemColors.Window
        Me.txtPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersona.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersona.Location = New System.Drawing.Point(129, 22)
        Me.txtPersona.MaxLength = 3
        Me.txtPersona.Name = "txtPersona"
        Me.txtPersona.ReadOnly = True
        Me.txtPersona.Size = New System.Drawing.Size(346, 20)
        Me.txtPersona.TabIndex = 14
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(637, 52)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(79, 33)
        Me.btnGuardar.TabIndex = 212
        Me.btnGuardar.Text = "  Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(429, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 13)
        Me.Label10.TabIndex = 232
        Me.Label10.Text = "Hora Adicional (Hrs) :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(212, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(130, 13)
        Me.Label9.TabIndex = 231
        Me.Label9.Text = "Hora Planeada (Hrs) :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(26, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 13)
        Me.Label8.TabIndex = 230
        Me.Label8.Text = "Hora Real (Hrs) :"
        '
        'txtHoraPlaneada
        '
        Me.txtHoraPlaneada.BackColor = System.Drawing.SystemColors.Control
        Me.txtHoraPlaneada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraPlaneada.Location = New System.Drawing.Point(343, 59)
        Me.txtHoraPlaneada.MaxLength = 10
        Me.txtHoraPlaneada.Name = "txtHoraPlaneada"
        Me.txtHoraPlaneada.ReadOnly = True
        Me.txtHoraPlaneada.Size = New System.Drawing.Size(47, 20)
        Me.txtHoraPlaneada.TabIndex = 228
        Me.txtHoraPlaneada.Text = "0.00"
        Me.txtHoraPlaneada.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHoraPlaneada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtHoraReal
        '
        Me.txtHoraReal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraReal.Location = New System.Drawing.Point(129, 59)
        Me.txtHoraReal.MaxLength = 10
        Me.txtHoraReal.Name = "txtHoraReal"
        Me.txtHoraReal.Size = New System.Drawing.Size(47, 20)
        Me.txtHoraReal.TabIndex = 227
        Me.txtHoraReal.Text = "0.00"
        Me.txtHoraReal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHoraReal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 120)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(756, 20)
        Me.ssBarra.TabIndex = 214
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(320, 15)
        Me.sslError.Visible = False
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.sslTotal.Visible = False
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmProgramacionJob_ActPersona
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(756, 140)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProgramacionJob_ActPersona"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programación x Persona"
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPersonaS As System.Windows.Forms.Button
    Friend WithEvents txtPersona As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtHoraPlaneada As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtHoraReal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtHoraExtra As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnPasarCargo As System.Windows.Forms.Button
End Class
