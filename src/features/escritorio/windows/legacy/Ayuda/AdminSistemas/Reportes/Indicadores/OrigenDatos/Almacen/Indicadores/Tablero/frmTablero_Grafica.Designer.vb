<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTablero_Grafica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTablero_Grafica))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvGrafica = New System.Windows.Forms.DataGridView
        Me.ChartGrafico = New AxMSChart20Lib.AxMSChart
        Me.ChartMotivo = New AxMSChart20Lib.AxMSChart
        Me.dgvTablero = New System.Windows.Forms.DataGridView
        Me.dgvMotivos = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIndicador = New System.Windows.Forms.TextBox
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGrafica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartGrafico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTablero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMotivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'dgvGrafica
        '
        Me.dgvGrafica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGrafica.Location = New System.Drawing.Point(12, 12)
        Me.dgvGrafica.Name = "dgvGrafica"
        Me.dgvGrafica.Size = New System.Drawing.Size(37, 21)
        Me.dgvGrafica.TabIndex = 0
        Me.dgvGrafica.Visible = False
        '
        'ChartGrafico
        '
        Me.ChartGrafico.DataSource = Nothing
        Me.ChartGrafico.Location = New System.Drawing.Point(0, -12)
        Me.ChartGrafico.Name = "ChartGrafico"
        Me.ChartGrafico.OcxState = CType(resources.GetObject("ChartGrafico.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ChartGrafico.Size = New System.Drawing.Size(854, 281)
        Me.ChartGrafico.TabIndex = 1
        Me.ChartGrafico.Visible = False
        '
        'ChartMotivo
        '
        Me.ChartMotivo.DataSource = Nothing
        Me.ChartMotivo.Location = New System.Drawing.Point(-1, 375)
        Me.ChartMotivo.Name = "ChartMotivo"
        Me.ChartMotivo.OcxState = CType(resources.GetObject("ChartMotivo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ChartMotivo.Size = New System.Drawing.Size(855, 219)
        Me.ChartMotivo.TabIndex = 3
        Me.ChartMotivo.Visible = False
        '
        'dgvTablero
        '
        Me.dgvTablero.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTablero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTablero.Location = New System.Drawing.Point(11, 261)
        Me.dgvTablero.MaximumSize = New System.Drawing.Size(829, 120)
        Me.dgvTablero.MinimumSize = New System.Drawing.Size(829, 120)
        Me.dgvTablero.Name = "dgvTablero"
        Me.dgvTablero.Size = New System.Drawing.Size(829, 120)
        Me.dgvTablero.TabIndex = 92
        '
        'dgvMotivos
        '
        Me.dgvMotivos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMotivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMotivos.Location = New System.Drawing.Point(10, 577)
        Me.dgvMotivos.MaximumSize = New System.Drawing.Size(829, 120)
        Me.dgvMotivos.MinimumSize = New System.Drawing.Size(829, 120)
        Me.dgvMotivos.Name = "dgvMotivos"
        Me.dgvMotivos.Size = New System.Drawing.Size(829, 120)
        Me.dgvMotivos.TabIndex = 93
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(591, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 15)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "VALORES EXPRESADOS EN DOLARES"
        '
        'txtIndicador
        '
        Me.txtIndicador.BackColor = System.Drawing.SystemColors.Control
        Me.txtIndicador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIndicador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIndicador.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndicador.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtIndicador.Location = New System.Drawing.Point(64, 9)
        Me.txtIndicador.Name = "txtIndicador"
        Me.txtIndicador.ReadOnly = True
        Me.txtIndicador.Size = New System.Drawing.Size(274, 16)
        Me.txtIndicador.TabIndex = 96
        Me.txtIndicador.Text = "LBLINDICADOR"
        '
        'frmTablero_Grafica
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(849, 705)
        Me.Controls.Add(Me.txtIndicador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvMotivos)
        Me.Controls.Add(Me.dgvTablero)
        Me.Controls.Add(Me.ChartMotivo)
        Me.Controls.Add(Me.ChartGrafico)
        Me.Controls.Add(Me.dgvGrafica)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTablero_Grafica"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grafica de Tablero"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGrafica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartGrafico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTablero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMotivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvGrafica As System.Windows.Forms.DataGridView
    Friend WithEvents ChartGrafico As AxMSChart20Lib.AxMSChart
    Friend WithEvents ChartMotivo As AxMSChart20Lib.AxMSChart
    Friend WithEvents dgvTablero As System.Windows.Forms.DataGridView
    Friend WithEvents dgvMotivos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIndicador As System.Windows.Forms.TextBox
End Class
