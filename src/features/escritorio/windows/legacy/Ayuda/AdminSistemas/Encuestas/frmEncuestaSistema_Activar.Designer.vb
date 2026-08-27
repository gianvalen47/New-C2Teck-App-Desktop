<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEncuestaSistema_Activar
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEncuestaSistema_Activar))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbActivar = New Janus.Windows.EditControls.UIGroupBox
        Me.cbDesactivar = New Janus.Windows.EditControls.UIRadioButton
        Me.cbActivar = New Janus.Windows.EditControls.UIRadioButton
        Me.btnSalir = New Janus.Windows.EditControls.UIButton
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbActivar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbActivar.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbActivar
        '
        Me.gbActivar.Controls.Add(Me.cbDesactivar)
        Me.gbActivar.Controls.Add(Me.cbActivar)
        Me.gbActivar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbActivar.Location = New System.Drawing.Point(10, 13)
        Me.gbActivar.Name = "gbActivar"
        Me.gbActivar.Size = New System.Drawing.Size(209, 49)
        Me.gbActivar.TabIndex = 190
        Me.gbActivar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbDesactivar
        '
        Me.cbDesactivar.Checked = True
        Me.cbDesactivar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDesactivar.Location = New System.Drawing.Point(104, 17)
        Me.cbDesactivar.Name = "cbDesactivar"
        Me.cbDesactivar.Size = New System.Drawing.Size(85, 23)
        Me.cbDesactivar.TabIndex = 8
        Me.cbDesactivar.TabStop = True
        Me.cbDesactivar.Text = "Desactivar"
        '
        'cbActivar
        '
        Me.cbActivar.Checked = True
        Me.cbActivar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbActivar.Location = New System.Drawing.Point(26, 17)
        Me.cbActivar.Name = "cbActivar"
        Me.cbActivar.Size = New System.Drawing.Size(72, 23)
        Me.cbActivar.TabIndex = 7
        Me.cbActivar.TabStop = True
        Me.cbActivar.Text = "Activar"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnSalir.Location = New System.Drawing.Point(119, 78)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 23)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnAceptar.Location = New System.Drawing.Point(25, 78)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(88, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        '
        'frmEncuestaSistema_Activar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(236, 115)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.gbActivar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEncuestaSistema_Activar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activar / Desactivar Encuesta"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbActivar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbActivar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbActivar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cbActivar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents cbDesactivar As Janus.Windows.EditControls.UIRadioButton
End Class
