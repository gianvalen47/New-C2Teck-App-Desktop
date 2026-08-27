<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignacionComputadora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignacionComputadora))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbDatosAsignacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtFecFinAsig = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecIniAsig = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscarComputadora = New System.Windows.Forms.Button()
        Me.txtComputadora = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscarPersonaS = New System.Windows.Forms.Button()
        Me.txtPersona = New System.Windows.Forms.TextBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.gbDatosAsignacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosAsignacion.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(271, 182)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 277
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(187, 182)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 27)
        Me.btnGuardar.TabIndex = 276
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbDatosAsignacion
        '
        Me.gbDatosAsignacion.Controls.Add(Me.txtFecFinAsig)
        Me.gbDatosAsignacion.Controls.Add(Me.txtFecIniAsig)
        Me.gbDatosAsignacion.Controls.Add(Me.Label4)
        Me.gbDatosAsignacion.Controls.Add(Me.Label2)
        Me.gbDatosAsignacion.Controls.Add(Me.btnBuscarComputadora)
        Me.gbDatosAsignacion.Controls.Add(Me.txtComputadora)
        Me.gbDatosAsignacion.Controls.Add(Me.Label3)
        Me.gbDatosAsignacion.Controls.Add(Me.Label1)
        Me.gbDatosAsignacion.Controls.Add(Me.btnBuscarPersonaS)
        Me.gbDatosAsignacion.Controls.Add(Me.txtPersona)
        Me.gbDatosAsignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosAsignacion.Location = New System.Drawing.Point(12, 12)
        Me.gbDatosAsignacion.Name = "gbDatosAsignacion"
        Me.gbDatosAsignacion.Size = New System.Drawing.Size(510, 158)
        Me.gbDatosAsignacion.TabIndex = 275
        Me.gbDatosAsignacion.Text = "Datos de la Asignación"
        Me.gbDatosAsignacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFecFinAsig
        '
        '
        '
        '
        Me.txtFecFinAsig.DropDownCalendar.Name = ""
        Me.txtFecFinAsig.DropDownCalendar.Visible = False
        Me.txtFecFinAsig.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinAsig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecFinAsig.IsNullDate = True
        Me.txtFecFinAsig.Location = New System.Drawing.Point(385, 112)
        Me.txtFecFinAsig.Name = "txtFecFinAsig"
        Me.txtFecFinAsig.NullButtonText = "Ninguno"
        Me.txtFecFinAsig.Size = New System.Drawing.Size(90, 20)
        Me.txtFecFinAsig.TabIndex = 400
        Me.txtFecFinAsig.TodayButtonText = "Hoy"
        Me.txtFecFinAsig.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecIniAsig
        '
        '
        '
        '
        Me.txtFecIniAsig.DropDownCalendar.Name = ""
        Me.txtFecIniAsig.DropDownCalendar.Visible = False
        Me.txtFecIniAsig.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIniAsig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecIniAsig.IsNullDate = True
        Me.txtFecIniAsig.Location = New System.Drawing.Point(140, 112)
        Me.txtFecIniAsig.Name = "txtFecIniAsig"
        Me.txtFecIniAsig.NullButtonText = "Ninguno"
        Me.txtFecIniAsig.Size = New System.Drawing.Size(90, 20)
        Me.txtFecIniAsig.TabIndex = 399
        Me.txtFecIniAsig.TodayButtonText = "Hoy"
        Me.txtFecIniAsig.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(276, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 256
        Me.Label4.Text = "Fecha Fin Asig. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 253
        Me.Label2.Text = "Conputadora :"
        '
        'btnBuscarComputadora
        '
        Me.btnBuscarComputadora.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarComputadora.Location = New System.Drawing.Point(458, 72)
        Me.btnBuscarComputadora.Name = "btnBuscarComputadora"
        Me.btnBuscarComputadora.Size = New System.Drawing.Size(27, 25)
        Me.btnBuscarComputadora.TabIndex = 255
        Me.btnBuscarComputadora.TabStop = False
        Me.btnBuscarComputadora.UseVisualStyleBackColor = True
        '
        'txtComputadora
        '
        Me.txtComputadora.BackColor = System.Drawing.SystemColors.Window
        Me.txtComputadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComputadora.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtComputadora.Location = New System.Drawing.Point(109, 75)
        Me.txtComputadora.MaxLength = 3
        Me.txtComputadora.Name = "txtComputadora"
        Me.txtComputadora.ReadOnly = True
        Me.txtComputadora.Size = New System.Drawing.Size(346, 20)
        Me.txtComputadora.TabIndex = 254
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(39, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Personal :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 244
        Me.Label1.Text = "Fecha Inicio Asig, :"
        '
        'btnBuscarPersonaS
        '
        Me.btnBuscarPersonaS.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersonaS.Location = New System.Drawing.Point(458, 34)
        Me.btnBuscarPersonaS.Name = "btnBuscarPersonaS"
        Me.btnBuscarPersonaS.Size = New System.Drawing.Size(27, 25)
        Me.btnBuscarPersonaS.TabIndex = 18
        Me.btnBuscarPersonaS.TabStop = False
        Me.btnBuscarPersonaS.UseVisualStyleBackColor = True
        '
        'txtPersona
        '
        Me.txtPersona.BackColor = System.Drawing.SystemColors.Window
        Me.txtPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersona.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersona.Location = New System.Drawing.Point(109, 37)
        Me.txtPersona.MaxLength = 3
        Me.txtPersona.Name = "txtPersona"
        Me.txtPersona.ReadOnly = True
        Me.txtPersona.Size = New System.Drawing.Size(346, 20)
        Me.txtPersona.TabIndex = 17
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmAsignacionComputadora
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(535, 220)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatosAsignacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(543, 254)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(543, 254)
        Me.Name = "frmAsignacionComputadora"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación x Computadora"
        CType(Me.gbDatosAsignacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosAsignacion.ResumeLayout(False)
        Me.gbDatosAsignacion.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents gbDatosAsignacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBuscarComputadora As Button
    Friend WithEvents txtComputadora As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBuscarPersonaS As Button
    Friend WithEvents txtPersona As TextBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFecIniAsig As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecFinAsig As Janus.Windows.CalendarCombo.CalendarCombo
End Class
