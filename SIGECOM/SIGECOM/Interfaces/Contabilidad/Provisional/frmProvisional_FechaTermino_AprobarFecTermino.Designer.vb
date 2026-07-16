<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProvisional_FechaTermino_AprobarFecTermino
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProvisional_FechaTermino_AprobarFecTermino))
        Me.cbRechazar = New Janus.Windows.EditControls.UIRadioButton()
        Me.cbAprobar = New Janus.Windows.EditControls.UIRadioButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnAprobar = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObservacionDatos = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtFecDoc = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbCorreos = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.gbCorreos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCorreos.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbRechazar
        '
        Me.cbRechazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRechazar.Location = New System.Drawing.Point(292, 22)
        Me.cbRechazar.Name = "cbRechazar"
        Me.cbRechazar.Size = New System.Drawing.Size(104, 23)
        Me.cbRechazar.TabIndex = 13
        Me.cbRechazar.Text = "Rechazar"
        '
        'cbAprobar
        '
        Me.cbAprobar.Checked = True
        Me.cbAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAprobar.Location = New System.Drawing.Point(202, 22)
        Me.cbAprobar.Name = "cbAprobar"
        Me.cbAprobar.Size = New System.Drawing.Size(84, 23)
        Me.cbAprobar.TabIndex = 12
        Me.cbAprobar.TabStop = True
        Me.cbAprobar.Text = "Aprobar"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnSalir.Location = New System.Drawing.Point(281, 162)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(78, 25)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "Cancelar"
        '
        'btnAprobar
        '
        Me.btnAprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAprobar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAprobar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnAprobar.Location = New System.Drawing.Point(191, 162)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(78, 25)
        Me.btnAprobar.TabIndex = 8
        Me.btnAprobar.Text = "Aprobar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(116, 51)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(391, 95)
        Me.txtObservacion.TabIndex = 10
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Observación"
        '
        'txtObservacionDatos
        '
        Me.txtObservacionDatos.Location = New System.Drawing.Point(125, 50)
        Me.txtObservacionDatos.Multiline = True
        Me.txtObservacionDatos.Name = "txtObservacionDatos"
        Me.txtObservacionDatos.ReadOnly = True
        Me.txtObservacionDatos.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacionDatos.Size = New System.Drawing.Size(308, 110)
        Me.txtObservacionDatos.TabIndex = 73
        '
        'txtFecDoc
        '
        '
        '
        '
        Me.txtFecDoc.DropDownCalendar.FirstMonth = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecDoc.DropDownCalendar.Name = ""
        Me.txtFecDoc.DropDownCalendar.Visible = False
        Me.txtFecDoc.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecDoc.Location = New System.Drawing.Point(125, 18)
        Me.txtFecDoc.Name = "txtFecDoc"
        Me.txtFecDoc.NullButtonText = "Ninguno"
        Me.txtFecDoc.ReadOnly = True
        Me.txtFecDoc.Size = New System.Drawing.Size(96, 20)
        Me.txtFecDoc.TabIndex = 71
        Me.txtFecDoc.TodayButtonText = "Hoy"
        Me.txtFecDoc.Value = New Date(2014, 7, 1, 0, 0, 0, 0)
        Me.txtFecDoc.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(29, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Fecha Termino"
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.txtObservacionDatos)
        Me.gbDetalle.Controls.Add(Me.Label2)
        Me.gbDetalle.Controls.Add(Me.Label9)
        Me.gbDetalle.Controls.Add(Me.txtFecDoc)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(12, 12)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(536, 172)
        Me.gbDetalle.TabIndex = 193
        Me.gbDetalle.Text = "Datos de la Fecha Termino"
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbCorreos
        '
        Me.gbCorreos.Controls.Add(Me.txtObservacion)
        Me.gbCorreos.Controls.Add(Me.Label1)
        Me.gbCorreos.Controls.Add(Me.cbRechazar)
        Me.gbCorreos.Controls.Add(Me.btnAprobar)
        Me.gbCorreos.Controls.Add(Me.cbAprobar)
        Me.gbCorreos.Controls.Add(Me.btnSalir)
        Me.gbCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCorreos.Location = New System.Drawing.Point(12, 196)
        Me.gbCorreos.Name = "gbCorreos"
        Me.gbCorreos.Size = New System.Drawing.Size(536, 204)
        Me.gbCorreos.TabIndex = 194
        Me.gbCorreos.Text = "Aprobar / Rechazar Fecha Termino"
        Me.gbCorreos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmProvisional_FechaTermino_AprobarFecTermino
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(580, 435)
        Me.Controls.Add(Me.gbCorreos)
        Me.Controls.Add(Me.gbDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProvisional_FechaTermino_AprobarFecTermino"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aprobar / Rechazar Fecha Termino"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        CType(Me.gbCorreos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCorreos.ResumeLayout(False)
        Me.gbCorreos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cbRechazar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents cbAprobar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAprobar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label2 As Label
    Friend WithEvents txtObservacionDatos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtFecDoc As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label9 As Label
    Friend WithEvents gbCorreos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
End Class
