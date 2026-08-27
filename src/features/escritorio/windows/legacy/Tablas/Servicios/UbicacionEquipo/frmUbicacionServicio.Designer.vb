<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUbicacionServicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUbicacionServicio))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosUbicacion = New Janus.Windows.EditControls.UIGroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAbrUbicacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.txtCodUbicacion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDesUbicacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosUbicacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosUbicacion
        '
        Me.gbDatosUbicacion.Controls.Add(Me.Label2)
        Me.gbDatosUbicacion.Controls.Add(Me.txtAbrUbicacion)
        Me.gbDatosUbicacion.Controls.Add(Me.txtCodUbicacion)
        Me.gbDatosUbicacion.Controls.Add(Me.Label1)
        Me.gbDatosUbicacion.Controls.Add(Me.Label9)
        Me.gbDatosUbicacion.Controls.Add(Me.txtDesUbicacion)
        Me.gbDatosUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosUbicacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gbDatosUbicacion.Location = New System.Drawing.Point(8, 4)
        Me.gbDatosUbicacion.Name = "gbDatosUbicacion"
        Me.gbDatosUbicacion.Size = New System.Drawing.Size(551, 60)
        Me.gbDatosUbicacion.TabIndex = 0
        Me.gbDatosUbicacion.Text = "Datos de Ubicación de Servicio"
        Me.gbDatosUbicacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(431, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 258
        Me.Label2.Text = "Abrv."
        '
        'txtAbrUbicacion
        '
        Me.txtAbrUbicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbrUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbrUbicacion.Location = New System.Drawing.Point(474, 24)
        Me.txtAbrUbicacion.MaxLength = 5
        Me.txtAbrUbicacion.Name = "txtAbrUbicacion"
        Me.txtAbrUbicacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAbrUbicacion.Size = New System.Drawing.Size(63, 20)
        Me.txtAbrUbicacion.TabIndex = 3
        Me.txtAbrUbicacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '
        'txtCodUbicacion
        '
        Me.txtCodUbicacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodUbicacion.ForeColor = System.Drawing.Color.Navy
        Me.txtCodUbicacion.Location = New System.Drawing.Point(63, 24)
        Me.txtCodUbicacion.MaxLength = 3
        Me.txtCodUbicacion.Name = "txtCodUbicacion"
        Me.txtCodUbicacion.Size = New System.Drawing.Size(51, 20)
        Me.txtCodUbicacion.TabIndex = 1
        Me.txtCodUbicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Código"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(137, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "Descripción"
        '
        'txtDesUbicacion
        '
        Me.txtDesUbicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesUbicacion.Location = New System.Drawing.Point(217, 24)
        Me.txtDesUbicacion.Name = "txtDesUbicacion"
        Me.txtDesUbicacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesUbicacion.Size = New System.Drawing.Size(191, 20)
        Me.txtDesUbicacion.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(293, 71)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 5
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
        Me.btnGuardar.Location = New System.Drawing.Point(209, 71)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmUbicacionServicio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(566, 104)
        Me.Controls.Add(Me.gbDatosUbicacion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUbicacionServicio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ubicación de Servicio"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosUbicacion.ResumeLayout(False)
        Me.gbDatosUbicacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosUbicacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAbrUbicacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtCodUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDesUbicacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
End Class
