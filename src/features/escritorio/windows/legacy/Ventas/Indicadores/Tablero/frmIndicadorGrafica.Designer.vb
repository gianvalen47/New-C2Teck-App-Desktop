<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndicadorGrafica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndicadorGrafica))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ChartEstadistica = New AxMSChart20Lib.AxMSChart
        Me.dgvGrafica = New System.Windows.Forms.DataGridView
        Me.dgvTabla = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblDefinicion = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblMedicion = New System.Windows.Forms.Label
        Me.lblReporte = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pbAmarillo = New System.Windows.Forms.PictureBox
        Me.pbVerde = New System.Windows.Forms.PictureBox
        Me.pbRojo = New System.Windows.Forms.PictureBox
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblObservaciones = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.lblNotapie = New System.Windows.Forms.Label
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ChartEstadistica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGrafica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbAmarillo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbVerde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRojo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChartEstadistica
        '
        Me.ChartEstadistica.DataSource = Nothing
        Me.ChartEstadistica.Location = New System.Drawing.Point(12, 176)
        Me.ChartEstadistica.Name = "ChartEstadistica"
        Me.ChartEstadistica.OcxState = CType(resources.GetObject("ChartEstadistica.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ChartEstadistica.Size = New System.Drawing.Size(1069, 389)
        Me.ChartEstadistica.TabIndex = 100
        Me.ChartEstadistica.Visible = False
        '
        'dgvGrafica
        '
        Me.dgvGrafica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGrafica.Location = New System.Drawing.Point(1030, 204)
        Me.dgvGrafica.Name = "dgvGrafica"
        Me.dgvGrafica.Size = New System.Drawing.Size(32, 23)
        Me.dgvGrafica.TabIndex = 217
        Me.dgvGrafica.Visible = False
        '
        'dgvTabla
        '
        Me.dgvTabla.AllowUserToAddRows = False
        DataGridViewCellStyle1.Format = "##.##"
        Me.dgvTabla.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nombre})
        Me.dgvTabla.Location = New System.Drawing.Point(12, 577)
        Me.dgvTabla.Name = "dgvTabla"
        Me.dgvTabla.ReadOnly = True
        Me.dgvTabla.Size = New System.Drawing.Size(1069, 119)
        Me.dgvTabla.TabIndex = 216
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 218
        Me.Label1.Text = "Definición Conceptual :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "Exp. Matematica :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 13)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "Frecuencia de Medición :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 13)
        Me.Label4.TabIndex = 221
        Me.Label4.Text = "Frecuencia de Reporte :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 222
        Me.Label5.Text = "Observaciones :"
        '
        'lblDefinicion
        '
        Me.lblDefinicion.AutoSize = True
        Me.lblDefinicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefinicion.Location = New System.Drawing.Point(163, 14)
        Me.lblDefinicion.Name = "lblDefinicion"
        Me.lblDefinicion.Size = New System.Drawing.Size(163, 13)
        Me.lblDefinicion.TabIndex = 223
        Me.lblDefinicion.Text = "Cumplimiento al Pronóstico Anual"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(163, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(250, 13)
        Me.Label7.TabIndex = 224
        Me.Label7.Text = "Σ (Ventas Acumuladas) / Σ (Pronóstico Acumulado)"
        '
        'lblMedicion
        '
        Me.lblMedicion.AutoSize = True
        Me.lblMedicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedicion.Location = New System.Drawing.Point(163, 60)
        Me.lblMedicion.Name = "lblMedicion"
        Me.lblMedicion.Size = New System.Drawing.Size(47, 13)
        Me.lblMedicion.TabIndex = 225
        Me.lblMedicion.Text = "Mensual"
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.Location = New System.Drawing.Point(163, 83)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(47, 13)
        Me.lblReporte.TabIndex = 226
        Me.lblReporte.Text = "Mensual"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pbAmarillo)
        Me.GroupBox1.Controls.Add(Me.pbVerde)
        Me.GroupBox1.Controls.Add(Me.pbRojo)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblTitulo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblReporte)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblMedicion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblDefinicion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1069, 159)
        Me.GroupBox1.TabIndex = 227
        Me.GroupBox1.TabStop = False
        '
        'pbAmarillo
        '
        Me.pbAmarillo.Image = CType(resources.GetObject("pbAmarillo.Image"), System.Drawing.Image)
        Me.pbAmarillo.Location = New System.Drawing.Point(985, 19)
        Me.pbAmarillo.Name = "pbAmarillo"
        Me.pbAmarillo.Size = New System.Drawing.Size(65, 65)
        Me.pbAmarillo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbAmarillo.TabIndex = 275
        Me.pbAmarillo.TabStop = False
        '
        'pbVerde
        '
        Me.pbVerde.Image = CType(resources.GetObject("pbVerde.Image"), System.Drawing.Image)
        Me.pbVerde.Location = New System.Drawing.Point(985, 19)
        Me.pbVerde.Name = "pbVerde"
        Me.pbVerde.Size = New System.Drawing.Size(65, 65)
        Me.pbVerde.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbVerde.TabIndex = 274
        Me.pbVerde.TabStop = False
        '
        'pbRojo
        '
        Me.pbRojo.Image = CType(resources.GetObject("pbRojo.Image"), System.Drawing.Image)
        Me.pbRojo.Location = New System.Drawing.Point(985, 19)
        Me.pbRojo.Name = "pbRojo"
        Me.pbRojo.Size = New System.Drawing.Size(65, 65)
        Me.pbRojo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbRojo.TabIndex = 273
        Me.pbRojo.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(978, 129)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(85, 22)
        Me.btnBuscar.TabIndex = 271
        Me.btnBuscar.Text = "Regresar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(163, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 231
        Me.Label9.Text = "Dólares"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 13)
        Me.Label8.TabIndex = 230
        Me.Label8.Text = "Unidad de Moneda :"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.Location = New System.Drawing.Point(163, 129)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(78, 13)
        Me.lblObservaciones.TabIndex = 229
        Me.lblObservaciones.Text = "Observaciones"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(511, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 16)
        Me.Label6.TabIndex = 228
        Me.Label6.Text = "Indicador de Gestión :"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblTitulo.Location = New System.Drawing.Point(511, 60)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(67, 18)
        Me.lblTitulo.TabIndex = 227
        Me.lblTitulo.Text = "lblTitulo"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNotapie
        '
        Me.lblNotapie.AutoSize = True
        Me.lblNotapie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotapie.Location = New System.Drawing.Point(497, 536)
        Me.lblNotapie.Name = "lblNotapie"
        Me.lblNotapie.Size = New System.Drawing.Size(74, 15)
        Me.lblNotapie.TabIndex = 228
        Me.lblNotapie.Text = "lblNotaPie"
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
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
        Me.Nombre.Width = 155
        '
        'frmIndicadorGrafica
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1101, 716)
        Me.Controls.Add(Me.lblNotapie)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvTabla)
        Me.Controls.Add(Me.ChartEstadistica)
        Me.Controls.Add(Me.dgvGrafica)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIndicadorGrafica"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indicador de Venta - Grafica"
        CType(Me.ChartEstadistica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGrafica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbAmarillo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbVerde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRojo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChartEstadistica As AxMSChart20Lib.AxMSChart
    Friend WithEvents dgvGrafica As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTabla As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDefinicion As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblMedicion As System.Windows.Forms.Label
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblNotapie As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents pbRojo As System.Windows.Forms.PictureBox
    Friend WithEvents pbVerde As System.Windows.Forms.PictureBox
    Friend WithEvents pbAmarillo As System.Windows.Forms.PictureBox
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
