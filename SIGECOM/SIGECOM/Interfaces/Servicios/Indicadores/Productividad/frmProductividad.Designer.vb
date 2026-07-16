<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductividad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductividad))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.dgvDatos = New System.Windows.Forms.DataGridView
        Me.ChartMotivo = New AxMSChart20Lib.AxMSChart
        Me.btnProductividad = New System.Windows.Forms.Button
        Me.btnPorColaborador = New System.Windows.Forms.Button
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtanio
        '
        Me.txtanio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtanio.Location = New System.Drawing.Point(393, 25)
        Me.txtanio.Maximum = 2050
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2003
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(57, 20)
        Me.txtanio.TabIndex = 136
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2014
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(350, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "Año :"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(499, 22)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(119, 27)
        Me.btnBuscar.TabIndex = 137
        Me.btnBuscar.Text = "Mostrar Gráfico"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Location = New System.Drawing.Point(12, 68)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Size = New System.Drawing.Size(949, 240)
        Me.dgvDatos.TabIndex = 138
        '
        'ChartMotivo
        '
        Me.ChartMotivo.DataSource = Nothing
        Me.ChartMotivo.Location = New System.Drawing.Point(-8, 309)
        Me.ChartMotivo.Name = "ChartMotivo"
        Me.ChartMotivo.OcxState = CType(resources.GetObject("ChartMotivo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ChartMotivo.Size = New System.Drawing.Size(984, 296)
        Me.ChartMotivo.TabIndex = 280
        Me.ChartMotivo.Visible = False
        '
        'btnProductividad
        '
        Me.btnProductividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProductividad.Image = CType(resources.GetObject("btnProductividad.Image"), System.Drawing.Image)
        Me.btnProductividad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProductividad.Location = New System.Drawing.Point(822, 324)
        Me.btnProductividad.Name = "btnProductividad"
        Me.btnProductividad.Size = New System.Drawing.Size(135, 27)
        Me.btnProductividad.TabIndex = 281
        Me.btnProductividad.Text = "Ver Productividad"
        Me.btnProductividad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProductividad.UseVisualStyleBackColor = True
        '
        'btnPorColaborador
        '
        Me.btnPorColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPorColaborador.Image = Global.SIGECOM.My.Resources.Resources.User
        Me.btnPorColaborador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPorColaborador.Location = New System.Drawing.Point(840, 22)
        Me.btnPorColaborador.Name = "btnPorColaborador"
        Me.btnPorColaborador.Size = New System.Drawing.Size(121, 27)
        Me.btnPorColaborador.TabIndex = 282
        Me.btnPorColaborador.Text = "Por Colaborador"
        Me.btnPorColaborador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPorColaborador.UseVisualStyleBackColor = True
        '
        'frmProductividad
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(974, 614)
        Me.Controls.Add(Me.btnPorColaborador)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtanio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnProductividad)
        Me.Controls.Add(Me.ChartMotivo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductividad"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productividad"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents ChartMotivo As AxMSChart20Lib.AxMSChart
    Friend WithEvents btnProductividad As System.Windows.Forms.Button
    Friend WithEvents btnPorColaborador As System.Windows.Forms.Button
End Class
