<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHoraMotor_Mant
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
        Dim cmbTipoMantenimiento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHoraMotor_Mant))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosMantenimiento = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNumero = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbReparacion = New System.Windows.Forms.CheckBox()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtHrsTotales = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecha = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoMantenimiento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosMantenimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosMantenimiento.SuspendLayout()
        CType(Me.cmbTipoMantenimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosMantenimiento
        '
        Me.gbDatosMantenimiento.Controls.Add(Me.txtNumero)
        Me.gbDatosMantenimiento.Controls.Add(Me.Label7)
        Me.gbDatosMantenimiento.Controls.Add(Me.cbReparacion)
        Me.gbDatosMantenimiento.Controls.Add(Me.txtObservacion)
        Me.gbDatosMantenimiento.Controls.Add(Me.Label13)
        Me.gbDatosMantenimiento.Controls.Add(Me.txtHrsTotales)
        Me.gbDatosMantenimiento.Controls.Add(Me.Label3)
        Me.gbDatosMantenimiento.Controls.Add(Me.txtFecha)
        Me.gbDatosMantenimiento.Controls.Add(Me.Label2)
        Me.gbDatosMantenimiento.Controls.Add(Me.Label1)
        Me.gbDatosMantenimiento.Controls.Add(Me.cmbTipoMantenimiento)
        Me.gbDatosMantenimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosMantenimiento.Location = New System.Drawing.Point(10, 8)
        Me.gbDatosMantenimiento.Name = "gbDatosMantenimiento"
        Me.gbDatosMantenimiento.Size = New System.Drawing.Size(439, 175)
        Me.gbDatosMantenimiento.TabIndex = 0
        Me.gbDatosMantenimiento.Text = "Datos de Mantenimiento"
        Me.gbDatosMantenimiento.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(238, 83)
        Me.txtNumero.Maximum = 10000
        Me.txtNumero.MaxLength = 200
        Me.txtNumero.Minimum = 1
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(46, 21)
        Me.txtNumero.TabIndex = 412
        Me.txtNumero.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtNumero.Value = 1
        Me.txtNumero.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(217, 15)
        Me.Label7.TabIndex = 411
        Me.Label7.Text = "Numero Mantenimiento / Reparación :"
        '
        'cbReparacion
        '
        Me.cbReparacion.AutoSize = True
        Me.cbReparacion.BackColor = System.Drawing.Color.Transparent
        Me.cbReparacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbReparacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbReparacion.Location = New System.Drawing.Point(14, 57)
        Me.cbReparacion.Name = "cbReparacion"
        Me.cbReparacion.Size = New System.Drawing.Size(190, 19)
        Me.cbReparacion.TabIndex = 3
        Me.cbReparacion.Text = "¿Mantenimiento Reparación?"
        Me.cbReparacion.UseVisualStyleBackColor = False
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(95, 112)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(332, 55)
        Me.txtObservacion.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 132)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 15)
        Me.Label13.TabIndex = 410
        Me.Label13.Text = "Observación"
        '
        'txtHrsTotales
        '
        Me.txtHrsTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHrsTotales.Location = New System.Drawing.Point(333, 57)
        Me.txtHrsTotales.MaxLength = 10
        Me.txtHrsTotales.Name = "txtHrsTotales"
        Me.txtHrsTotales.Size = New System.Drawing.Size(94, 21)
        Me.txtHrsTotales.TabIndex = 4
        Me.txtHrsTotales.Text = "0.00"
        Me.txtHrsTotales.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHrsTotales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(255, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 408
        Me.Label3.Text = "Hrs. Totales"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.DropDownCalendar.FirstMonth = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecha.DropDownCalendar.Name = ""
        Me.txtFecha.DropDownCalendar.Visible = False
        Me.txtFecha.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(333, 22)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullButtonText = "Ninguno"
        Me.txtFecha.Size = New System.Drawing.Size(94, 21)
        Me.txtFecha.TabIndex = 2
        Me.txtFecha.TodayButtonText = "Hoy"
        Me.txtFecha.Value = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecha.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(286, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 400
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 15)
        Me.Label1.TabIndex = 354
        Me.Label1.Text = "Tipo Mantenimiento"
        '
        'cmbTipoMantenimiento
        '
        Me.cmbTipoMantenimiento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoMantenimiento_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoMantenimiento_DesignTimeLayout.LayoutString")
        Me.cmbTipoMantenimiento.DesignTimeLayout = cmbTipoMantenimiento_DesignTimeLayout
        Me.cmbTipoMantenimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoMantenimiento.Location = New System.Drawing.Point(137, 23)
        Me.cmbTipoMantenimiento.Name = "cmbTipoMantenimiento"
        Me.cmbTipoMantenimiento.SelectedIndex = -1
        Me.cmbTipoMantenimiento.SelectedItem = Nothing
        Me.cmbTipoMantenimiento.Size = New System.Drawing.Size(94, 21)
        Me.cmbTipoMantenimiento.TabIndex = 1
        Me.cmbTipoMantenimiento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbTipoMantenimiento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(232, 189)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 7
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
        Me.btnGuardar.Location = New System.Drawing.Point(148, 189)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 27)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmHoraMotor_Mant
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(460, 225)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatosMantenimiento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHoraMotor_Mant"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Horas Motor - Mantenimiento"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosMantenimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosMantenimiento.ResumeLayout(False)
        Me.gbDatosMantenimiento.PerformLayout()
        CType(Me.cmbTipoMantenimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosMantenimiento As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbTipoMantenimiento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHrsTotales As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbReparacion As System.Windows.Forms.CheckBox
    Friend WithEvents txtNumero As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label7 As Label
End Class
