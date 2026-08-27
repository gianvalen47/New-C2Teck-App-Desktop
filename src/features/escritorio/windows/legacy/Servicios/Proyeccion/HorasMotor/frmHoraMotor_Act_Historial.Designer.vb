<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoraMotor_Act_Historial
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
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtFecRegistro = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.gbDatosEquipo = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtHrsParciales = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHrsTotales = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosEquipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtFecRegistro
        '
        '
        '
        '
        Me.txtFecRegistro.DropDownCalendar.FirstMonth = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecRegistro.DropDownCalendar.Name = ""
        Me.txtFecRegistro.DropDownCalendar.Visible = False
        Me.txtFecRegistro.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecRegistro.Location = New System.Drawing.Point(110, 47)
        Me.txtFecRegistro.Name = "txtFecRegistro"
        Me.txtFecRegistro.NullButtonText = "Ninguno"
        Me.txtFecRegistro.Size = New System.Drawing.Size(90, 21)
        Me.txtFecRegistro.TabIndex = 3
        Me.txtFecRegistro.TodayButtonText = "Hoy"
        Me.txtFecRegistro.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'gbDatosEquipo
        '
        Me.gbDatosEquipo.Controls.Add(Me.txtHrsParciales)
        Me.gbDatosEquipo.Controls.Add(Me.Label6)
        Me.gbDatosEquipo.Controls.Add(Me.txtHrsTotales)
        Me.gbDatosEquipo.Controls.Add(Me.Label2)
        Me.gbDatosEquipo.Controls.Add(Me.Label1)
        Me.gbDatosEquipo.Controls.Add(Me.txtCodMer)
        Me.gbDatosEquipo.Controls.Add(Me.Label5)
        Me.gbDatosEquipo.Controls.Add(Me.txtFecRegistro)
        Me.gbDatosEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosEquipo.Location = New System.Drawing.Point(9, 6)
        Me.gbDatosEquipo.Name = "gbDatosEquipo"
        Me.gbDatosEquipo.Size = New System.Drawing.Size(271, 136)
        Me.gbDatosEquipo.TabIndex = 5
        Me.gbDatosEquipo.Text = "Datos de Historial"
        Me.gbDatosEquipo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtHrsParciales
        '
        Me.txtHrsParciales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHrsParciales.Location = New System.Drawing.Point(110, 103)
        Me.txtHrsParciales.MaxLength = 10
        Me.txtHrsParciales.Name = "txtHrsParciales"
        Me.txtHrsParciales.Size = New System.Drawing.Size(79, 21)
        Me.txtHrsParciales.TabIndex = 410
        Me.txtHrsParciales.Text = "0.00"
        Me.txtHrsParciales.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHrsParciales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 412
        Me.Label6.Text = "Hrs. Parciales"
        '
        'txtHrsTotales
        '
        Me.txtHrsTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHrsTotales.Location = New System.Drawing.Point(110, 75)
        Me.txtHrsTotales.MaxLength = 10
        Me.txtHrsTotales.Name = "txtHrsTotales"
        Me.txtHrsTotales.Size = New System.Drawing.Size(79, 21)
        Me.txtHrsTotales.TabIndex = 409
        Me.txtHrsTotales.Text = "0.00"
        Me.txtHrsTotales.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHrsTotales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 411
        Me.Label2.Text = "Hrs. Totales"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 15)
        Me.Label1.TabIndex = 375
        Me.Label1.Text = "Fecha Registro"
        '
        'txtCodMer
        '
        Me.txtCodMer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodMer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodMer.Location = New System.Drawing.Point(110, 20)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.ReadOnly = True
        Me.txtCodMer.Size = New System.Drawing.Size(140, 21)
        Me.txtCodMer.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 374
        Me.Label5.Text = "Serie Motor"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnSalir.Location = New System.Drawing.Point(148, 149)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 27)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnAceptar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnAceptar.Location = New System.Drawing.Point(62, 149)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 27)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Guardar"
        '
        'frmHoraMotor_Act_Historial
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(292, 187)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gbDatosEquipo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHoraMotor_Act_Historial"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizar Fecha Registro de Historial"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosEquipo.ResumeLayout(False)
        Me.gbDatosEquipo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtFecRegistro As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbDatosEquipo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtHrsParciales As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHrsTotales As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
