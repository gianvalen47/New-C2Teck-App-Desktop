<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndicadoresServicio_Grafica11
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndicadoresServicio_Grafica11))
        Me.dgvTipo4 = New System.Windows.Forms.DataGridView()
        Me.ChartGrafico = New AxMSChart20Lib.AxMSChart()
        Me.ChartMotivo = New AxMSChart20Lib.AxMSChart()
        Me.lblFechaCierre = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblUbiMantMot = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMedicion = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDefinicion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvTipo5 = New System.Windows.Forms.DataGridView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ChartGrafico5 = New AxMSChart20Lib.AxMSChart()
        Me.lblDiasPlaneados = New System.Windows.Forms.Label()
        Me.lblDiasEjecutados = New System.Windows.Forms.Label()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.lblDiasEstandar = New System.Windows.Forms.Label()
        Me.lblDiasPromesa = New System.Windows.Forms.Label()
        Me.lblDiasProyectados = New System.Windows.Forms.Label()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        CType(Me.dgvTipo4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartGrafico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvTipo5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartGrafico5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTipo4
        '
        Me.dgvTipo4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipo4.Location = New System.Drawing.Point(21, 552)
        Me.dgvTipo4.Name = "dgvTipo4"
        Me.dgvTipo4.Size = New System.Drawing.Size(29, 21)
        Me.dgvTipo4.TabIndex = 277
        Me.dgvTipo4.Visible = False
        '
        'ChartGrafico
        '
        Me.ChartGrafico.DataSource = Nothing
        Me.ChartGrafico.Location = New System.Drawing.Point(12, 782)
        Me.ChartGrafico.Name = "ChartGrafico"
        Me.ChartGrafico.OcxState = CType(resources.GetObject("ChartGrafico.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ChartGrafico.Size = New System.Drawing.Size(22, 20)
        Me.ChartGrafico.TabIndex = 278
        Me.ChartGrafico.Visible = False
        '
        'ChartMotivo
        '
        Me.ChartMotivo.DataSource = Nothing
        Me.ChartMotivo.Location = New System.Drawing.Point(37, 175)
        Me.ChartMotivo.Name = "ChartMotivo"
        Me.ChartMotivo.OcxState = CType(resources.GetObject("ChartMotivo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ChartMotivo.Size = New System.Drawing.Size(488, 344)
        Me.ChartMotivo.TabIndex = 279
        Me.ChartMotivo.Visible = False
        '
        'lblFechaCierre
        '
        Me.lblFechaCierre.AutoSize = True
        Me.lblFechaCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaCierre.Location = New System.Drawing.Point(207, 157)
        Me.lblFechaCierre.Name = "lblFechaCierre"
        Me.lblFechaCierre.Size = New System.Drawing.Size(79, 13)
        Me.lblFechaCierre.TabIndex = 287
        Me.lblFechaCierre.Text = "Fecha Cierre"
        Me.lblFechaCierre.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblUbiMantMot)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.lblNumJob)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblReporte)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblMedicion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblDefinicion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1085, 128)
        Me.GroupBox1.TabIndex = 288
        Me.GroupBox1.TabStop = False
        '
        'lblUbiMantMot
        '
        Me.lblUbiMantMot.AutoSize = True
        Me.lblUbiMantMot.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbiMantMot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblUbiMantMot.Location = New System.Drawing.Point(652, 56)
        Me.lblUbiMantMot.Name = "lblUbiMantMot"
        Me.lblUbiMantMot.Size = New System.Drawing.Size(48, 18)
        Me.lblUbiMantMot.TabIndex = 303
        Me.lblUbiMantMot.Text = "UMM"
        '
        'btnBuscar
        '
        Me.btnBuscar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(991, 96)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 22)
        Me.btnBuscar.TabIndex = 302
        Me.btnBuscar.Text = "Tablero"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblNumJob
        '
        Me.lblNumJob.AutoSize = True
        Me.lblNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumJob.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNumJob.Location = New System.Drawing.Point(523, 55)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(46, 18)
        Me.lblNumJob.TabIndex = 299
        Me.lblNumJob.Text = "Job :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(872, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(197, 18)
        Me.Label12.TabIndex = 301
        Me.Label12.Text = "Nivel de Servicio por Job"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label6.Location = New System.Drawing.Point(905, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(164, 18)
        Me.Label6.TabIndex = 300
        Me.Label6.Text = "Indicador de Gestión"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.Location = New System.Drawing.Point(163, 105)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(391, 13)
        Me.lblObservaciones.TabIndex = 229
        Me.lblObservaciones.Text = "Los días proyectados se calculan con la tendencia de la última semana trabajada"
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
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.Location = New System.Drawing.Point(163, 83)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(34, 13)
        Me.lblReporte.TabIndex = 226
        Me.lblReporte.Text = "Diario"
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
        'lblMedicion
        '
        Me.lblMedicion.AutoSize = True
        Me.lblMedicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedicion.Location = New System.Drawing.Point(163, 60)
        Me.lblMedicion.Name = "lblMedicion"
        Me.lblMedicion.Size = New System.Drawing.Size(48, 13)
        Me.lblMedicion.TabIndex = 225
        Me.lblMedicion.Text = "Semanal"
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(163, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(261, 13)
        Me.Label7.TabIndex = 224
        Me.Label7.Text = "SI (días proyectados>días promesa cliente; 0%,100%)"
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
        'lblDefinicion
        '
        Me.lblDefinicion.AutoSize = True
        Me.lblDefinicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefinicion.Location = New System.Drawing.Point(163, 14)
        Me.lblDefinicion.Name = "lblDefinicion"
        Me.lblDefinicion.Size = New System.Drawing.Size(406, 13)
        Me.lblDefinicion.TabIndex = 223
        Me.lblDefinicion.Text = "Indica si el mantenimiento será entregado dentro del plazo establecido para el cl" &
    "iente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 222
        Me.Label5.Text = "Observaciones :"
        '
        'dgvTipo5
        '
        Me.dgvTipo5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipo5.Location = New System.Drawing.Point(740, 552)
        Me.dgvTipo5.Name = "dgvTipo5"
        Me.dgvTipo5.Size = New System.Drawing.Size(34, 22)
        Me.dgvTipo5.TabIndex = 289
        Me.dgvTipo5.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(888, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 292
        Me.Label10.Text = "Dias Ejecución "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(737, 153)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 13)
        Me.Label11.TabIndex = 291
        Me.Label11.Text = "Dias Planeados"
        '
        'ChartGrafico5
        '
        Me.ChartGrafico5.DataSource = Nothing
        Me.ChartGrafico5.Location = New System.Drawing.Point(559, 175)
        Me.ChartGrafico5.Name = "ChartGrafico5"
        Me.ChartGrafico5.OcxState = CType(resources.GetObject("ChartGrafico5.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ChartGrafico5.Size = New System.Drawing.Size(538, 344)
        Me.ChartGrafico5.TabIndex = 290
        Me.ChartGrafico5.Visible = False
        '
        'lblDiasPlaneados
        '
        Me.lblDiasPlaneados.AutoSize = True
        Me.lblDiasPlaneados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasPlaneados.Location = New System.Drawing.Point(778, 169)
        Me.lblDiasPlaneados.Name = "lblDiasPlaneados"
        Me.lblDiasPlaneados.Size = New System.Drawing.Size(24, 13)
        Me.lblDiasPlaneados.TabIndex = 293
        Me.lblDiasPlaneados.Text = "DP"
        '
        'lblDiasEjecutados
        '
        Me.lblDiasEjecutados.AutoSize = True
        Me.lblDiasEjecutados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasEjecutados.Location = New System.Drawing.Point(923, 169)
        Me.lblDiasEjecutados.Name = "lblDiasEjecutados"
        Me.lblDiasEjecutados.Size = New System.Drawing.Size(24, 13)
        Me.lblDiasEjecutados.TabIndex = 294
        Me.lblDiasEjecutados.Text = "DE"
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
        'lblDiasEstandar
        '
        Me.lblDiasEstandar.AutoSize = True
        Me.lblDiasEstandar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasEstandar.Location = New System.Drawing.Point(223, 491)
        Me.lblDiasEstandar.Name = "lblDiasEstandar"
        Me.lblDiasEstandar.Size = New System.Drawing.Size(86, 13)
        Me.lblDiasEstandar.TabIndex = 295
        Me.lblDiasEstandar.Text = "Dias Estandar"
        '
        'lblDiasPromesa
        '
        Me.lblDiasPromesa.AutoSize = True
        Me.lblDiasPromesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasPromesa.Location = New System.Drawing.Point(223, 516)
        Me.lblDiasPromesa.Name = "lblDiasPromesa"
        Me.lblDiasPromesa.Size = New System.Drawing.Size(84, 13)
        Me.lblDiasPromesa.TabIndex = 296
        Me.lblDiasPromesa.Text = "Dias Promesa"
        '
        'lblDiasProyectados
        '
        Me.lblDiasProyectados.AutoSize = True
        Me.lblDiasProyectados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasProyectados.Location = New System.Drawing.Point(223, 541)
        Me.lblDiasProyectados.Name = "lblDiasProyectados"
        Me.lblDiasProyectados.Size = New System.Drawing.Size(106, 13)
        Me.lblDiasProyectados.TabIndex = 297
        Me.lblDiasProyectados.Text = "Dias Proyectados"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSiguiente.Location = New System.Drawing.Point(1010, 520)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(88, 25)
        Me.btnSiguiente.TabIndex = 298
        Me.btnSiguiente.TabStop = False
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'frmIndicadoresServicio_Grafica11
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1147, 615)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.dgvTipo4)
        Me.Controls.Add(Me.lblDiasProyectados)
        Me.Controls.Add(Me.lblDiasPromesa)
        Me.Controls.Add(Me.dgvTipo5)
        Me.Controls.Add(Me.lblDiasEstandar)
        Me.Controls.Add(Me.lblDiasEjecutados)
        Me.Controls.Add(Me.lblDiasPlaneados)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ChartGrafico5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblFechaCierre)
        Me.Controls.Add(Me.ChartMotivo)
        Me.Controls.Add(Me.ChartGrafico)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIndicadoresServicio_Grafica11"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indicadores de Servicio - Graficas"
        CType(Me.dgvTipo4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartGrafico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvTipo5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartGrafico5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvTipo4 As System.Windows.Forms.DataGridView
    Friend WithEvents ChartGrafico As AxMSChart20Lib.AxMSChart
    'Friend WithEvents DirectoryEntry1 As System.DirectoryServices.DirectoryEntry
    Friend WithEvents ChartMotivo As AxMSChart20Lib.AxMSChart
    Friend WithEvents lblFechaCierre As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMedicion As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDefinicion As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ChartGrafico5 As AxMSChart20Lib.AxMSChart
    Friend WithEvents dgvTipo5 As System.Windows.Forms.DataGridView
    Friend WithEvents lblDiasPlaneados As System.Windows.Forms.Label
    Friend WithEvents lblDiasEjecutados As System.Windows.Forms.Label
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents lblDiasProyectados As System.Windows.Forms.Label
    Friend WithEvents lblDiasPromesa As System.Windows.Forms.Label
    Friend WithEvents lblDiasEstandar As System.Windows.Forms.Label
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblUbiMantMot As System.Windows.Forms.Label
End Class
