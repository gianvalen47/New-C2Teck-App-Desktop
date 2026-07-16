<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobTiempoReparacion
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
        Dim gbDatosReporte As Janus.Windows.EditControls.UIGroupBox
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobTiempoReparacion))
        Me.txtFechaFin = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        gbDatosReporte = New Janus.Windows.EditControls.UIGroupBox()
        CType(gbDatosReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        gbDatosReporte.SuspendLayout()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatosReporte
        '
        gbDatosReporte.Controls.Add(Me.txtFechaFin)
        gbDatosReporte.Controls.Add(Me.txtFechaInicio)
        gbDatosReporte.Controls.Add(Me.Label5)
        gbDatosReporte.Controls.Add(Me.Label6)
        gbDatosReporte.Controls.Add(Me.cmbEstado)
        gbDatosReporte.Controls.Add(Me.Label4)
        gbDatosReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        gbDatosReporte.Location = New System.Drawing.Point(8, 6)
        gbDatosReporte.Name = "gbDatosReporte"
        gbDatosReporte.Size = New System.Drawing.Size(215, 116)
        gbDatosReporte.TabIndex = 151
        gbDatosReporte.Text = "Datos de Reporte"
        gbDatosReporte.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtFechaFin
        '
        '
        '
        '
        Me.txtFechaFin.DropDownCalendar.Name = ""
        Me.txtFechaFin.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFin.Location = New System.Drawing.Point(105, 82)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(92, 20)
        Me.txtFechaFin.TabIndex = 147
        Me.txtFechaFin.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFechaInicio
        '
        '
        '
        '
        Me.txtFechaInicio.DropDownCalendar.Name = ""
        Me.txtFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.Location = New System.Drawing.Point(105, 52)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(92, 20)
        Me.txtFechaInicio.TabIndex = 145
        Me.txtFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Fecha Inicio :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Fecha Fin:"
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(105, 22)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(87, 20)
        Me.cmbEstado.TabIndex = 144
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(45, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 143
        Me.Label4.Text = "Estado :"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(119, 128)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 25)
        Me.btnCancelar.TabIndex = 150
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(36, 128)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(77, 25)
        Me.btnAceptar.TabIndex = 149
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmJobTiempoReparacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(250, 175)
        Me.Controls.Add(gbDatosReporte)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJobTiempoReparacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OT Tiempo de Reparación"
        CType(gbDatosReporte, System.ComponentModel.ISupportInitialize).EndInit()
        gbDatosReporte.ResumeLayout(False)
        gbDatosReporte.PerformLayout()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFin As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
