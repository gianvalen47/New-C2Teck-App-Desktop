<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios_Cotizacion_Revertir
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
        Me.components = New System.ComponentModel.Container
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnDuplicar = New System.Windows.Forms.Button
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtFecha = New Telerik.WinControls.UI.RadDateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(125, 83)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(68, 23)
        Me.btnCancelar.TabIndex = 131
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnDuplicar
        '
        Me.btnDuplicar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnDuplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDuplicar.Location = New System.Drawing.Point(46, 83)
        Me.btnDuplicar.Name = "btnDuplicar"
        Me.btnDuplicar.Size = New System.Drawing.Size(73, 23)
        Me.btnDuplicar.TabIndex = 130
        Me.btnDuplicar.Text = "Duplicar"
        Me.btnDuplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDuplicar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtFecha
        '
        Me.txtFecha.AutoSize = True
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecha.Location = New System.Drawing.Point(96, 28)
        Me.txtFecha.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.txtFecha.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.NullDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.txtFecha.Size = New System.Drawing.Size(82, 22)
        Me.txtFecha.TabIndex = 132
        Me.txtFecha.Text = "RadDateTimePicker1"
        Me.txtFecha.Value = New Date(2011, 4, 4, 14, 1, 30, 813)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Fecha :"
        '
        'frmServicios_Cotizacion_Revertir
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(238, 132)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnDuplicar)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios_Cotizacion_Revertir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmServicios_Cotizacion_Revertir"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnDuplicar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Telerik.WinControls.UI.RadDateTimePicker
End Class
