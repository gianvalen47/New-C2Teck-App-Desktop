<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSepOrdenCompra_Separar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSepOrdenCompra_Separar))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbSeparacion = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFecFinSep = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtCanSep = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecIniSep = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbSeparacion.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(408, 90)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(333, 90)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbSeparacion
        '
        Me.gbSeparacion.Controls.Add(Me.txtObservacion)
        Me.gbSeparacion.Controls.Add(Me.Label21)
        Me.gbSeparacion.Controls.Add(Me.txtFecFinSep)
        Me.gbSeparacion.Controls.Add(Me.txtCanSep)
        Me.gbSeparacion.Controls.Add(Me.Label2)
        Me.gbSeparacion.Controls.Add(Me.txtFecIniSep)
        Me.gbSeparacion.Controls.Add(Me.Label3)
        Me.gbSeparacion.Controls.Add(Me.Label10)
        Me.gbSeparacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSeparacion.Location = New System.Drawing.Point(5, 6)
        Me.gbSeparacion.Name = "gbSeparacion"
        Me.gbSeparacion.Size = New System.Drawing.Size(484, 78)
        Me.gbSeparacion.TabIndex = 5
        Me.gbSeparacion.TabStop = False
        Me.gbSeparacion.Text = "Datos de la Separación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(85, 38)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(391, 35)
        Me.txtObservacion.TabIndex = 27
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(4, 41)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Observación"
        '
        'txtFecFinSep
        '
        '
        '
        '
        Me.txtFecFinSep.DropDownCalendar.Name = ""
        Me.txtFecFinSep.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinSep.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free
        Me.txtFecFinSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinSep.Location = New System.Drawing.Point(383, 16)
        Me.txtFecFinSep.Name = "txtFecFinSep"
        Me.txtFecFinSep.Nullable = True
        Me.txtFecFinSep.NullButtonText = "Ninguno"
        Me.txtFecFinSep.ShowNullButton = True
        Me.txtFecFinSep.Size = New System.Drawing.Size(93, 20)
        Me.txtFecFinSep.TabIndex = 25
        Me.txtFecFinSep.TodayButtonText = "Hoy"
        Me.txtFecFinSep.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtCanSep
        '
        Me.txtCanSep.Location = New System.Drawing.Point(66, 16)
        Me.txtCanSep.Maximum = 8000
        Me.txtCanSep.MaxLength = 200
        Me.txtCanSep.Name = "txtCanSep"
        Me.txtCanSep.Size = New System.Drawing.Size(76, 20)
        Me.txtCanSep.TabIndex = 21
        Me.txtCanSep.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCanSep.Value = 1
        Me.txtCanSep.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Separar"
        '
        'txtFecIniSep
        '
        '
        '
        '
        Me.txtFecIniSep.DropDownCalendar.Name = ""
        Me.txtFecIniSep.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIniSep.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Free
        Me.txtFecIniSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecIniSep.Location = New System.Drawing.Point(215, 16)
        Me.txtFecIniSep.Name = "txtFecIniSep"
        Me.txtFecIniSep.Nullable = True
        Me.txtFecIniSep.NullButtonText = "Ninguno"
        Me.txtFecIniSep.ShowNullButton = True
        Me.txtFecIniSep.Size = New System.Drawing.Size(96, 20)
        Me.txtFecIniSep.TabIndex = 23
        Me.txtFecIniSep.TodayButtonText = "Hoy"
        Me.txtFecIniSep.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(146, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Fec. Inicio"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(317, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Fec. Final"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmSepOrdenCompra_Separar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(499, 138)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbSeparacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSepOrdenCompra_Separar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Separar Item"
        Me.gbSeparacion.ResumeLayout(False)
        Me.gbSeparacion.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbSeparacion As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinSep As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtCanSep As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFecIniSep As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
