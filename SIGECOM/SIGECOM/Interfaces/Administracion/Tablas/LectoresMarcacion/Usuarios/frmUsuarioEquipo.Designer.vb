<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarioEquipo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarioEquipo))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.LblNombreSO = New System.Windows.Forms.Label()
        Me.LblVersionSO = New System.Windows.Forms.Label()
        Me.LblArquitecturaSO = New System.Windows.Forms.Label()
        Me.LblNombreUsuario = New System.Windows.Forms.Label()
        Me.LblNombreEquipo = New System.Windows.Forms.Label()
        Me.LblSerialBoard = New System.Windows.Forms.Label()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(183, 175)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 27)
        Me.btnCancelar.TabIndex = 3
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
        Me.btnGuardar.Location = New System.Drawing.Point(79, 174)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(81, 27)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'LblNombreSO
        '
        Me.LblNombreSO.AutoSize = True
        Me.LblNombreSO.Location = New System.Drawing.Point(11, 16)
        Me.LblNombreSO.Name = "LblNombreSO"
        Me.LblNombreSO.Size = New System.Drawing.Size(28, 13)
        Me.LblNombreSO.TabIndex = 68
        Me.LblNombreSO.Text = "SO :"
        '
        'LblVersionSO
        '
        Me.LblVersionSO.AutoSize = True
        Me.LblVersionSO.Location = New System.Drawing.Point(12, 40)
        Me.LblVersionSO.Name = "LblVersionSO"
        Me.LblVersionSO.Size = New System.Drawing.Size(63, 13)
        Me.LblVersionSO.TabIndex = 69
        Me.LblVersionSO.Text = "Vesion SO :"
        '
        'LblArquitecturaSO
        '
        Me.LblArquitecturaSO.AutoSize = True
        Me.LblArquitecturaSO.Location = New System.Drawing.Point(11, 62)
        Me.LblArquitecturaSO.Name = "LblArquitecturaSO"
        Me.LblArquitecturaSO.Size = New System.Drawing.Size(47, 13)
        Me.LblArquitecturaSO.TabIndex = 70
        Me.LblArquitecturaSO.Text = "Arq SO :"
        '
        'LblNombreUsuario
        '
        Me.LblNombreUsuario.AutoSize = True
        Me.LblNombreUsuario.Location = New System.Drawing.Point(11, 114)
        Me.LblNombreUsuario.Name = "LblNombreUsuario"
        Me.LblNombreUsuario.Size = New System.Drawing.Size(49, 13)
        Me.LblNombreUsuario.TabIndex = 72
        Me.LblNombreUsuario.Text = "Usuario :"
        '
        'LblNombreEquipo
        '
        Me.LblNombreEquipo.AutoSize = True
        Me.LblNombreEquipo.Location = New System.Drawing.Point(11, 88)
        Me.LblNombreEquipo.Name = "LblNombreEquipo"
        Me.LblNombreEquipo.Size = New System.Drawing.Size(50, 13)
        Me.LblNombreEquipo.TabIndex = 73
        Me.LblNombreEquipo.Text = "Nombre :"
        '
        'LblSerialBoard
        '
        Me.LblSerialBoard.AutoSize = True
        Me.LblSerialBoard.Location = New System.Drawing.Point(11, 139)
        Me.LblSerialBoard.Name = "LblSerialBoard"
        Me.LblSerialBoard.Size = New System.Drawing.Size(41, 13)
        Me.LblSerialBoard.TabIndex = 74
        Me.LblSerialBoard.Text = "Board :"
        '
        'frmUsuarioEquipo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(336, 214)
        Me.Controls.Add(Me.LblSerialBoard)
        Me.Controls.Add(Me.LblNombreEquipo)
        Me.Controls.Add(Me.LblNombreUsuario)
        Me.Controls.Add(Me.LblArquitecturaSO)
        Me.Controls.Add(Me.LblVersionSO)
        Me.Controls.Add(Me.LblNombreSO)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuarioEquipo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Habilitar Acceso Equipo"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents LblNombreSO As Label
    Friend WithEvents LblVersionSO As Label
    Friend WithEvents LblNombreEquipo As Label
    Friend WithEvents LblNombreUsuario As Label
    Friend WithEvents LblArquitecturaSO As Label
    Friend WithEvents LblSerialBoard As Label
End Class
