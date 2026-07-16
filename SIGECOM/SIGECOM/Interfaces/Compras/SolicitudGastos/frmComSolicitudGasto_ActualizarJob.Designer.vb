<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComSolicitudGasto_ActualizarJob
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComSolicitudGasto_ActualizarJob))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.lblIdGasto = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(192, 43)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 20
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'lblIdGasto
        '
        Me.lblIdGasto.AutoSize = True
        Me.lblIdGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdGasto.Location = New System.Drawing.Point(188, 16)
        Me.lblIdGasto.Name = "lblIdGasto"
        Me.lblIdGasto.Size = New System.Drawing.Size(64, 13)
        Me.lblIdGasto.TabIndex = 19
        Me.lblIdGasto.Text = "lblIdGasto"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(46, 16)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(143, 13)
        Me.lblTitulo.TabIndex = 18
        Me.lblTitulo.Text = "Solicitud de Gastos Nº :"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnSalir.Location = New System.Drawing.Point(155, 79)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 25)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near
        Me.btnAceptar.Location = New System.Drawing.Point(70, 79)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 25)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "Aceptar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "OT"
        '
        'txtNumJob
        '
        Me.txtNumJob.Location = New System.Drawing.Point(113, 44)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(74, 20)
        Me.txtNumJob.TabIndex = 14
        '
        'frmComSolicitudGasto_ActualizarJob
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(294, 119)
        Me.Controls.Add(Me.btnBuscarJob)
        Me.Controls.Add(Me.lblIdGasto)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNumJob)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComSolicitudGasto_ActualizarJob"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizar Job"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents lblIdGasto As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
End Class
