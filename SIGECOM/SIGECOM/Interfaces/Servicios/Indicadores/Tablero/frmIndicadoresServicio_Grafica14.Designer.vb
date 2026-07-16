<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndicadoresServicio_Grafica14
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndicadoresServicio_Grafica14))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblNumJob = New System.Windows.Forms.Label()
        Me.HorAdi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesAtraso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdAtraso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesActividad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ejecutado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FecFinReal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProgramacionDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RucEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvAtraso = New System.Windows.Forms.DataGridView()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAtraso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAnterior
        '
        Me.btnAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnterior.Image = CType(resources.GetObject("btnAnterior.Image"), System.Drawing.Image)
        Me.btnAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnterior.Location = New System.Drawing.Point(821, 352)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAnterior.Size = New System.Drawing.Size(81, 25)
        Me.btnAnterior.TabIndex = 304
        Me.btnAnterior.TabStop = False
        Me.btnAnterior.Text = "Anterior"
        Me.btnAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAnterior.UseVisualStyleBackColor = True
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
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(735, 352)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(80, 26)
        Me.btnImprimir.TabIndex = 305
        Me.btnImprimir.Text = "    Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblNumJob
        '
        Me.lblNumJob.AutoSize = True
        Me.lblNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumJob.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNumJob.Location = New System.Drawing.Point(389, 18)
        Me.lblNumJob.Name = "lblNumJob"
        Me.lblNumJob.Size = New System.Drawing.Size(46, 18)
        Me.lblNumJob.TabIndex = 306
        Me.lblNumJob.Text = "Job :"
        '
        'HorAdi
        '
        Me.HorAdi.DataPropertyName = "HorAdi"
        DataGridViewCellStyle1.Format = "0.00"
        Me.HorAdi.DefaultCellStyle = DataGridViewCellStyle1
        Me.HorAdi.HeaderText = "Hor. Adic"
        Me.HorAdi.Name = "HorAdi"
        Me.HorAdi.Width = 50
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Detalles del Atraso"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 280
        '
        'DesAtraso
        '
        Me.DesAtraso.DataPropertyName = "DesAtraso"
        Me.DesAtraso.HeaderText = "Atraso "
        Me.DesAtraso.Name = "DesAtraso"
        '
        'IdAtraso
        '
        Me.IdAtraso.DataPropertyName = "IdAtraso"
        Me.IdAtraso.HeaderText = "IdAtraso"
        Me.IdAtraso.Name = "IdAtraso"
        Me.IdAtraso.Visible = False
        '
        'DesActividad
        '
        Me.DesActividad.DataPropertyName = "DesActividad"
        Me.DesActividad.HeaderText = "Actividad"
        Me.DesActividad.Name = "DesActividad"
        Me.DesActividad.Width = 320
        '
        'Ejecutado
        '
        Me.Ejecutado.DataPropertyName = "Ejecutado"
        Me.Ejecutado.HeaderText = "Culm."
        Me.Ejecutado.Name = "Ejecutado"
        Me.Ejecutado.Visible = False
        Me.Ejecutado.Width = 50
        '
        'FecFinReal
        '
        Me.FecFinReal.DataPropertyName = "FecFinReal"
        Me.FecFinReal.HeaderText = "F. Fin Real"
        Me.FecFinReal.Name = "FecFinReal"
        Me.FecFinReal.Width = 95
        '
        'IdProgramacionDet
        '
        Me.IdProgramacionDet.DataPropertyName = "IdProgramacionDet"
        Me.IdProgramacionDet.HeaderText = "IdProgramacionDet"
        Me.IdProgramacionDet.Name = "IdProgramacionDet"
        Me.IdProgramacionDet.Visible = False
        '
        'CodJob
        '
        Me.CodJob.DataPropertyName = "CodJob"
        Me.CodJob.HeaderText = "CodJob"
        Me.CodJob.Name = "CodJob"
        Me.CodJob.Visible = False
        '
        'RucEmp
        '
        Me.RucEmp.DataPropertyName = "RucEmp"
        Me.RucEmp.HeaderText = "RucEmp"
        Me.RucEmp.Name = "RucEmp"
        Me.RucEmp.Visible = False
        '
        'DesEmp
        '
        Me.DesEmp.DataPropertyName = "DesEmp"
        Me.DesEmp.HeaderText = "DesEmp"
        Me.DesEmp.Name = "DesEmp"
        Me.DesEmp.Visible = False
        '
        'CodEmp
        '
        Me.CodEmp.DataPropertyName = "CodEmp"
        Me.CodEmp.HeaderText = "CodEmp"
        Me.CodEmp.Name = "CodEmp"
        Me.CodEmp.Visible = False
        '
        'dgvAtraso
        '
        Me.dgvAtraso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAtraso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodEmp, Me.DesEmp, Me.RucEmp, Me.CodJob, Me.IdProgramacionDet, Me.FecFinReal, Me.Ejecutado, Me.DesActividad, Me.IdAtraso, Me.DesAtraso, Me.Descripcion, Me.HorAdi})
        Me.dgvAtraso.Location = New System.Drawing.Point(12, 52)
        Me.dgvAtraso.Name = "dgvAtraso"
        Me.dgvAtraso.Size = New System.Drawing.Size(890, 294)
        Me.dgvAtraso.TabIndex = 302
        '
        'frmIndicadoresServicio_Grafica14
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(938, 388)
        Me.Controls.Add(Me.lblNumJob)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.dgvAtraso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIndicadoresServicio_Grafica14"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalles de Atraso"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAtraso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblNumJob As System.Windows.Forms.Label
    Friend WithEvents dgvAtraso As System.Windows.Forms.DataGridView
    Friend WithEvents CodEmp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesEmp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RucEmp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodJob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdProgramacionDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FecFinReal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ejecutado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DesActividad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdAtraso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesAtraso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HorAdi As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
