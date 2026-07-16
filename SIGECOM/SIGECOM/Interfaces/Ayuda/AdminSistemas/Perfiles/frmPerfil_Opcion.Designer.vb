<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerfil_Opcion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerfil_Opcion))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbOpcion = New Janus.Windows.EditControls.UIGroupBox
        Me.txtDesOpcion = New System.Windows.Forms.TextBox
        Me.lblPerfil = New System.Windows.Forms.Label
        Me.cbLectura = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbOpcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpcion.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbOpcion
        '
        Me.gbOpcion.Controls.Add(Me.txtDesOpcion)
        Me.gbOpcion.Controls.Add(Me.lblPerfil)
        Me.gbOpcion.Controls.Add(Me.cbLectura)
        Me.gbOpcion.Controls.Add(Me.Label2)
        Me.gbOpcion.Controls.Add(Me.Label1)
        Me.gbOpcion.Location = New System.Drawing.Point(9, 7)
        Me.gbOpcion.Name = "gbOpcion"
        Me.gbOpcion.Size = New System.Drawing.Size(329, 128)
        Me.gbOpcion.TabIndex = 0
        Me.gbOpcion.Text = "Datos de Opción"
        Me.gbOpcion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtDesOpcion
        '
        Me.txtDesOpcion.BackColor = System.Drawing.SystemColors.Control
        Me.txtDesOpcion.Location = New System.Drawing.Point(86, 50)
        Me.txtDesOpcion.Multiline = True
        Me.txtDesOpcion.Name = "txtDesOpcion"
        Me.txtDesOpcion.ReadOnly = True
        Me.txtDesOpcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesOpcion.Size = New System.Drawing.Size(235, 35)
        Me.txtDesOpcion.TabIndex = 2
        Me.txtDesOpcion.TabStop = False
        '
        'lblPerfil
        '
        Me.lblPerfil.AutoSize = True
        Me.lblPerfil.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblPerfil.Location = New System.Drawing.Point(83, 27)
        Me.lblPerfil.Name = "lblPerfil"
        Me.lblPerfil.Size = New System.Drawing.Size(40, 13)
        Me.lblPerfil.TabIndex = 1
        Me.lblPerfil.Text = "lblPerfil"
        '
        'cbLectura
        '
        Me.cbLectura.AutoSize = True
        Me.cbLectura.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbLectura.Location = New System.Drawing.Point(133, 97)
        Me.cbLectura.Name = "cbLectura"
        Me.cbLectura.Size = New System.Drawing.Size(62, 17)
        Me.cbLectura.TabIndex = 4
        Me.cbLectura.Text = "Lectura"
        Me.cbLectura.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripción:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Perfil:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(176, 142)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(72, 25)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(98, 142)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(72, 25)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmPerfil_Opcion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(347, 174)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbOpcion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPerfil_Opcion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opción de Perfil"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbOpcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpcion.ResumeLayout(False)
        Me.gbOpcion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbOpcion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblPerfil As System.Windows.Forms.Label
    Friend WithEvents cbLectura As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDesOpcion As System.Windows.Forms.TextBox
End Class
