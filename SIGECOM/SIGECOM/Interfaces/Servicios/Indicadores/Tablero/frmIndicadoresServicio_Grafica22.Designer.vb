<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndicadoresServicio_Grafica22
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndicadoresServicio_Grafica22))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.ChartTipo82 = New AxMSChart20Lib.AxMSChart()
        Me.dgvTipo82 = New System.Windows.Forms.DataGridView()
        Me.dgvTipo81 = New System.Windows.Forms.DataGridView()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Anio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Objetivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRegresar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartTipo82, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipo82, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipo81, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'ChartTipo82
        '
        Me.ChartTipo82.DataSource = Nothing
        Me.ChartTipo82.Location = New System.Drawing.Point(12, 12)
        Me.ChartTipo82.Name = "ChartTipo82"
        Me.ChartTipo82.OcxState = CType(resources.GetObject("ChartTipo82.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ChartTipo82.Size = New System.Drawing.Size(986, 485)
        Me.ChartTipo82.TabIndex = 295
        '
        'dgvTipo82
        '
        Me.dgvTipo82.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipo82.Location = New System.Drawing.Point(944, 419)
        Me.dgvTipo82.Name = "dgvTipo82"
        Me.dgvTipo82.Size = New System.Drawing.Size(45, 29)
        Me.dgvTipo82.TabIndex = 294
        Me.dgvTipo82.Visible = False
        '
        'dgvTipo81
        '
        Me.dgvTipo81.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipo81.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nombre, Me.Anio, Me.PB, Me.Objetivo})
        Me.dgvTipo81.Location = New System.Drawing.Point(12, 482)
        Me.dgvTipo81.Name = "dgvTipo81"
        Me.dgvTipo81.ReadOnly = True
        Me.dgvTipo81.Size = New System.Drawing.Size(986, 200)
        Me.dgvTipo81.TabIndex = 293
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.DefaultCellStyle = DataGridViewCellStyle1
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 130
        '
        'Anio
        '
        Me.Anio.DataPropertyName = "Anio"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Anio.DefaultCellStyle = DataGridViewCellStyle2
        Me.Anio.HeaderText = "Año"
        Me.Anio.Name = "Anio"
        Me.Anio.ReadOnly = True
        Me.Anio.Width = 40
        '
        'PB
        '
        Me.PB.DataPropertyName = "PB"
        Me.PB.HeaderText = "PB"
        Me.PB.Name = "PB"
        Me.PB.ReadOnly = True
        Me.PB.Width = 40
        '
        'Objetivo
        '
        Me.Objetivo.DataPropertyName = "Objetivo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Objetivo.DefaultCellStyle = DataGridViewCellStyle3
        Me.Objetivo.HeaderText = "Objetivo"
        Me.Objetivo.Name = "Objetivo"
        Me.Objetivo.ReadOnly = True
        Me.Objetivo.Width = 55
        '
        'btnRegresar
        '
        Me.btnRegresar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegresar.Image = CType(resources.GetObject("btnRegresar.Image"), System.Drawing.Image)
        Me.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRegresar.Location = New System.Drawing.Point(912, 690)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(86, 25)
        Me.btnRegresar.TabIndex = 296
        Me.btnRegresar.TabStop = False
        Me.btnRegresar.Text = "Regresar"
        Me.btnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'frmIndicadoresServicio_Grafica22
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1010, 725)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.dgvTipo82)
        Me.Controls.Add(Me.dgvTipo81)
        Me.Controls.Add(Me.ChartTipo82)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIndicadoresServicio_Grafica22"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indicadores de Servicio - Graficas"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartTipo82, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipo82, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipo81, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents ChartTipo82 As AxMSChart20Lib.AxMSChart
    Friend WithEvents dgvTipo82 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTipo81 As System.Windows.Forms.DataGridView
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Anio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Objetivo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
