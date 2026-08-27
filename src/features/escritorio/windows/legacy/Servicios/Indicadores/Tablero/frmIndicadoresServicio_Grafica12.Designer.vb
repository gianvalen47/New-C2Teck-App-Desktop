<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndicadoresServicio_Grafica12
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndicadoresServicio_Grafica12))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.chartTipo9 = New AxMSChart20Lib.AxMSChart()
        Me.ChartTipo3 = New AxMSChart20Lib.AxMSChart()
        Me.dgvTipo9 = New System.Windows.Forms.DataGridView()
        Me.dgvTipo8 = New System.Windows.Forms.DataGridView()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvTipo3 = New System.Windows.Forms.DataGridView()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnAtradoDet = New System.Windows.Forms.Button()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.lblNumJob2 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartTipo9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartTipo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipo9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipo8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipo3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'chartTipo9
        '
        Me.chartTipo9.DataSource = Nothing
        Me.chartTipo9.Location = New System.Drawing.Point(12, 12)
        Me.chartTipo9.Name = "chartTipo9"
        Me.chartTipo9.OcxState = CType(resources.GetObject("chartTipo9.OcxState"), System.Windows.Forms.AxHost.State)
        Me.chartTipo9.Size = New System.Drawing.Size(970, 323)
        Me.chartTipo9.TabIndex = 285
        '
        'ChartTipo3
        '
        Me.ChartTipo3.DataSource = Nothing
        Me.ChartTipo3.Location = New System.Drawing.Point(22, 466)
        Me.ChartTipo3.Name = "ChartTipo3"
        Me.ChartTipo3.OcxState = CType(resources.GetObject("ChartTipo3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ChartTipo3.Size = New System.Drawing.Size(865, 354)
        Me.ChartTipo3.TabIndex = 284
        '
        'dgvTipo9
        '
        Me.dgvTipo9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipo9.Location = New System.Drawing.Point(928, 478)
        Me.dgvTipo9.Name = "dgvTipo9"
        Me.dgvTipo9.Size = New System.Drawing.Size(54, 60)
        Me.dgvTipo9.TabIndex = 288
        Me.dgvTipo9.Visible = False
        '
        'dgvTipo8
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvTipo8.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTipo8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipo8.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nombre})
        Me.dgvTipo8.Location = New System.Drawing.Point(12, 325)
        Me.dgvTipo8.Name = "dgvTipo8"
        Me.dgvTipo8.ReadOnly = True
        Me.dgvTipo8.Size = New System.Drawing.Size(970, 128)
        Me.dgvTipo8.TabIndex = 287
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 170
        '
        'dgvTipo3
        '
        Me.dgvTipo3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipo3.Location = New System.Drawing.Point(928, 552)
        Me.dgvTipo3.Name = "dgvTipo3"
        Me.dgvTipo3.Size = New System.Drawing.Size(54, 31)
        Me.dgvTipo3.TabIndex = 286
        Me.dgvTipo3.Visible = False
        '
        'btnRegresar
        '
        Me.btnRegresar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegresar.Image = CType(resources.GetObject("btnRegresar.Image"), System.Drawing.Image)
        Me.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRegresar.Location = New System.Drawing.Point(893, 679)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(89, 25)
        Me.btnRegresar.TabIndex = 289
        Me.btnRegresar.TabStop = False
        Me.btnRegresar.Text = "Regresar"
        Me.btnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSiguiente.Location = New System.Drawing.Point(806, 29)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(122, 25)
        Me.btnSiguiente.TabIndex = 299
        Me.btnSiguiente.TabStop = False
        Me.btnSiguiente.Text = "Detalle por Día"
        Me.btnSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnterior.Location = New System.Drawing.Point(901, 648)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAnterior.Size = New System.Drawing.Size(81, 25)
        Me.btnAnterior.TabIndex = 300
        Me.btnAnterior.TabStop = False
        Me.btnAnterior.Text = "Anterior"
        Me.btnAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnterior.UseVisualStyleBackColor = True
        Me.btnAnterior.Visible = False
        '
        'btnAtradoDet
        '
        Me.btnAtradoDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtradoDet.Image = CType(resources.GetObject("btnAtradoDet.Image"), System.Drawing.Image)
        Me.btnAtradoDet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAtradoDet.Location = New System.Drawing.Point(744, 480)
        Me.btnAtradoDet.Name = "btnAtradoDet"
        Me.btnAtradoDet.Size = New System.Drawing.Size(131, 25)
        Me.btnAtradoDet.TabIndex = 301
        Me.btnAtradoDet.TabStop = False
        Me.btnAtradoDet.Text = "Detalle del Atraso"
        Me.btnAtradoDet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtradoDet.UseVisualStyleBackColor = True
        '
        'lblNumJob
        '
        Me.lblNumJob.AutoSize = True
        Me.lblNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumJob.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNumJob.Location = New System.Drawing.Point(684, 32)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(46, 18)
        Me.lblNumJob.TabIndex = 302
        Me.lblNumJob.Text = "Job :"
        '
        'lblNumJob2
        '
        Me.lblNumJob2.AutoSize = True
        Me.lblNumJob2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumJob2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNumJob2.Location = New System.Drawing.Point(623, 484)
        Me.lblNumJob2.Name = "lblNumJob2"
        Me.lblNumJob2.Size = New System.Drawing.Size(46, 18)
        Me.lblNumJob2.TabIndex = 303
        Me.lblNumJob2.Text = "Job :"
        '
        'frmIndicadoresServicio_Grafica12
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1007, 839)
        Me.Controls.Add(Me.lblNumJob2)
        Me.Controls.Add(Me.lblNumJob)
        Me.Controls.Add(Me.btnAtradoDet)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.dgvTipo9)
        Me.Controls.Add(Me.dgvTipo8)
        Me.Controls.Add(Me.dgvTipo3)
        Me.Controls.Add(Me.chartTipo9)
        Me.Controls.Add(Me.ChartTipo3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIndicadoresServicio_Grafica12"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indicadores de Servicio - Graficas"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartTipo9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartTipo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipo9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipo8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipo3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents chartTipo9 As AxMSChart20Lib.AxMSChart
    Friend WithEvents ChartTipo3 As AxMSChart20Lib.AxMSChart
    Friend WithEvents dgvTipo9 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTipo8 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTipo3 As System.Windows.Forms.DataGridView
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnAtradoDet As System.Windows.Forms.Button
    Friend WithEvents lblNumJob2 As System.Windows.Forms.Label
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
End Class
