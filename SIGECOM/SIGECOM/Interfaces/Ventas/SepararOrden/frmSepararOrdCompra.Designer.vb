<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSepararOrdCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSepararOrdCompra))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbAprobacion = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFecFinSep = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecIniSep = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAprobacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(292, 113)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbAprobacion
        '
        Me.gbAprobacion.Controls.Add(Me.txtObservacion)
        Me.gbAprobacion.Controls.Add(Me.Label21)
        Me.gbAprobacion.Controls.Add(Me.txtFecFinSep)
        Me.gbAprobacion.Controls.Add(Me.txtFecIniSep)
        Me.gbAprobacion.Controls.Add(Me.Label3)
        Me.gbAprobacion.Controls.Add(Me.Label10)
        Me.gbAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAprobacion.Location = New System.Drawing.Point(2, 4)
        Me.gbAprobacion.Name = "gbAprobacion"
        Me.gbAprobacion.Size = New System.Drawing.Size(442, 105)
        Me.gbAprobacion.TabIndex = 11
        Me.gbAprobacion.TabStop = False
        Me.gbAprobacion.Text = "Datos de la Separación"
        '
        'txtObservacion
        '
        Me.txtObservacion.AcceptsTab = True
        Me.txtObservacion.Location = New System.Drawing.Point(83, 38)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(353, 61)
        Me.txtObservacion.TabIndex = 3
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
        Me.txtFecFinSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinSep.Location = New System.Drawing.Point(262, 16)
        Me.txtFecFinSep.Name = "txtFecFinSep"
        Me.txtFecFinSep.NullButtonText = "Ninguno"
        Me.txtFecFinSep.Size = New System.Drawing.Size(94, 20)
        Me.txtFecFinSep.TabIndex = 2
        Me.txtFecFinSep.TodayButtonText = "Hoy"
        Me.txtFecFinSep.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecIniSep
        '
        '
        '
        '
        Me.txtFecIniSep.DropDownCalendar.Name = ""
        Me.txtFecIniSep.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIniSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecIniSep.Location = New System.Drawing.Point(83, 16)
        Me.txtFecIniSep.Name = "txtFecIniSep"
        Me.txtFecIniSep.NullButtonText = "Ninguno"
        Me.txtFecIniSep.Size = New System.Drawing.Size(94, 20)
        Me.txtFecIniSep.TabIndex = 1
        Me.txtFecIniSep.TodayButtonText = "Hoy"
        Me.txtFecIniSep.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Fec. Inicio"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(193, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Fec. Final"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(367, 113)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmSepararOrdCompra
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(465, 159)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbAprobacion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSepararOrdCompra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Separar Orden Compra"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAprobacion.ResumeLayout(False)
        Me.gbAprobacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbAprobacion As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinSep As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecIniSep As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
