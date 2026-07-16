<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndicadoresServicio_Grafica13
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndicadoresServicio_Grafica13))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.dgvTipo6 = New System.Windows.Forms.DataGridView()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chartTipo7 = New AxMSChart20Lib.AxMSChart()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.dgvTipo7 = New System.Windows.Forms.DataGridView()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipo6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartTipo7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipo7, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'dgvTipo6
        '
        Me.dgvTipo6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipo6.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nombre})
        Me.dgvTipo6.Location = New System.Drawing.Point(12, 535)
        Me.dgvTipo6.Name = "dgvTipo6"
        Me.dgvTipo6.ReadOnly = True
        Me.dgvTipo6.Size = New System.Drawing.Size(1216, 140)
        Me.dgvTipo6.TabIndex = 291
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
        Me.Nombre.Width = 80
        '
        'chartTipo7
        '
        Me.chartTipo7.DataSource = Nothing
        Me.chartTipo7.Location = New System.Drawing.Point(12, 12)
        Me.chartTipo7.Name = "chartTipo7"
        Me.chartTipo7.OcxState = CType(resources.GetObject("chartTipo7.OcxState"), System.Windows.Forms.AxHost.State)
        Me.chartTipo7.Size = New System.Drawing.Size(1216, 515)
        Me.chartTipo7.TabIndex = 290
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.Image = CType(resources.GetObject("btnSiguiente.Image"), System.Drawing.Image)
        Me.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSiguiente.Location = New System.Drawing.Point(657, 688)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(85, 25)
        Me.btnSiguiente.TabIndex = 300
        Me.btnSiguiente.TabStop = False
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSiguiente.UseVisualStyleBackColor = True
        Me.btnSiguiente.Visible = False
        '
        'dgvTipo7
        '
        Me.dgvTipo7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTipo7.Location = New System.Drawing.Point(827, 688)
        Me.dgvTipo7.Name = "dgvTipo7"
        Me.dgvTipo7.Size = New System.Drawing.Size(68, 25)
        Me.dgvTipo7.TabIndex = 301
        Me.dgvTipo7.Visible = False
        '
        'btnAnterior
        '
        Me.btnAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnterior.Location = New System.Drawing.Point(901, 688)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAnterior.Size = New System.Drawing.Size(81, 25)
        Me.btnAnterior.TabIndex = 303
        Me.btnAnterior.TabStop = False
        Me.btnAnterior.Text = "Anterior"
        Me.btnAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegresar.Image = CType(resources.GetObject("btnRegresar.Image"), System.Drawing.Image)
        Me.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRegresar.Location = New System.Drawing.Point(487, 688)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(147, 25)
        Me.btnRegresar.TabIndex = 302
        Me.btnRegresar.TabStop = False
        Me.btnRegresar.Text = "Regresar al Tablero"
        Me.btnRegresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRegresar.UseVisualStyleBackColor = True
        Me.btnRegresar.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(306, 494)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 343
        Me.Label1.Text = "10"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(286, 494)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 342
        Me.Label2.Text = "9"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(262, 494)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 341
        Me.Label3.Text = "8"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(239, 494)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 340
        Me.Label4.Text = "7"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(216, 494)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 339
        Me.Label5.Text = "6"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(194, 494)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 338
        Me.Label6.Text = "5"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(171, 494)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 337
        Me.Label7.Text = "4"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(146, 494)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 336
        Me.Label8.Text = "3"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(121, 494)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 13)
        Me.Label9.TabIndex = 335
        Me.Label9.Text = "2"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(95, 494)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 13)
        Me.Label10.TabIndex = 334
        Me.Label10.Text = "1"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(332, 494)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(19, 13)
        Me.Label21.TabIndex = 344
        Me.Label21.Text = "11"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(355, 494)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(19, 13)
        Me.Label22.TabIndex = 345
        Me.Label22.Text = "12"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(379, 494)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(19, 13)
        Me.Label23.TabIndex = 346
        Me.Label23.Text = "13"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(476, 494)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(19, 13)
        Me.Label24.TabIndex = 350
        Me.Label24.Text = "17"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(451, 494)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(19, 13)
        Me.Label25.TabIndex = 349
        Me.Label25.Text = "16"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(427, 494)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(19, 13)
        Me.Label26.TabIndex = 348
        Me.Label26.Text = "15"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(402, 494)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(19, 13)
        Me.Label27.TabIndex = 347
        Me.Label27.Text = "14"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(570, 494)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(19, 13)
        Me.Label28.TabIndex = 354
        Me.Label28.Text = "21"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(546, 494)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(19, 13)
        Me.Label29.TabIndex = 353
        Me.Label29.Text = "20"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(522, 494)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(19, 13)
        Me.Label30.TabIndex = 352
        Me.Label30.Text = "19"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(498, 494)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(19, 13)
        Me.Label31.TabIndex = 351
        Me.Label31.Text = "18"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(666, 494)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(19, 13)
        Me.Label32.TabIndex = 358
        Me.Label32.Text = "25"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(642, 494)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(19, 13)
        Me.Label33.TabIndex = 357
        Me.Label33.Text = "24"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(618, 494)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(19, 13)
        Me.Label34.TabIndex = 356
        Me.Label34.Text = "23"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(594, 494)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(19, 13)
        Me.Label35.TabIndex = 355
        Me.Label35.Text = "22"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(762, 494)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(19, 13)
        Me.Label36.TabIndex = 362
        Me.Label36.Text = "29"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(738, 494)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(19, 13)
        Me.Label37.TabIndex = 361
        Me.Label37.Text = "28"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(714, 494)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(19, 13)
        Me.Label38.TabIndex = 360
        Me.Label38.Text = "27"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(690, 494)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(19, 13)
        Me.Label39.TabIndex = 359
        Me.Label39.Text = "26"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(786, 494)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(19, 13)
        Me.Label43.TabIndex = 363
        Me.Label43.Text = "30"
        '
        'lblNumJob
        '
        Me.lblNumJob.AutoSize = True
        Me.lblNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumJob.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNumJob.Location = New System.Drawing.Point(1053, 31)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(46, 18)
        Me.lblNumJob.TabIndex = 364
        Me.lblNumJob.Text = "Job :"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(1027, 494)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(19, 13)
        Me.Label40.TabIndex = 374
        Me.Label40.Text = "40"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(1003, 494)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(19, 13)
        Me.Label41.TabIndex = 373
        Me.Label41.Text = "39"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(979, 494)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(19, 13)
        Me.Label42.TabIndex = 372
        Me.Label42.Text = "38"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(955, 494)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(19, 13)
        Me.Label44.TabIndex = 371
        Me.Label44.Text = "37"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(931, 494)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(19, 13)
        Me.Label45.TabIndex = 370
        Me.Label45.Text = "36"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(907, 494)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(19, 13)
        Me.Label46.TabIndex = 369
        Me.Label46.Text = "35"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(883, 494)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(19, 13)
        Me.Label47.TabIndex = 368
        Me.Label47.Text = "34"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(859, 494)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(19, 13)
        Me.Label48.TabIndex = 367
        Me.Label48.Text = "33"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(835, 494)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(19, 13)
        Me.Label49.TabIndex = 366
        Me.Label49.Text = "32"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(811, 494)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(19, 13)
        Me.Label50.TabIndex = 365
        Me.Label50.Text = "31"
        '
        'frmIndicadoresServicio_Grafica13
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1263, 725)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.lblNumJob)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnRegresar)
        Me.Controls.Add(Me.dgvTipo7)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.dgvTipo6)
        Me.Controls.Add(Me.chartTipo7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIndicadoresServicio_Grafica13"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Indicadores de Servicio - Graficas"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipo6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartTipo7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipo7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents dgvTipo6 As System.Windows.Forms.DataGridView
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chartTipo7 As AxMSChart20Lib.AxMSChart
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents dgvTipo7 As System.Windows.Forms.DataGridView
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label50 As Label
End Class
