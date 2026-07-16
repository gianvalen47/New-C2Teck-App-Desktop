<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarcarOT
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim cmbCodArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarcarOT))
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.cmbCodArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSalirOT = New System.Windows.Forms.Button()
        Me.btnMarcarOtraActividad = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblEstado = New System.Windows.Forms.Label()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.ColumnHeadersVisible = False
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dgvDatos.Location = New System.Drawing.Point(9, 57)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDatos.RowTemplate.Height = 70
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvDatos.Size = New System.Drawing.Size(506, 380)
        Me.dgvDatos.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Columna1"
        Me.Column1.HeaderText = "Columna1"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Columna2"
        Me.Column2.HeaderText = "Columna2"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Columna3"
        Me.Column3.HeaderText = "Columna3"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "Columna4"
        Me.Column4.HeaderText = "Columna4"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "Columna5"
        Me.Column5.HeaderText = "Columna5"
        Me.Column5.Name = "Column5"
        '
        'cmbCodArea
        '
        Me.cmbCodArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodArea_DesignTimeLayout.LayoutString = resources.GetString("cmbCodArea_DesignTimeLayout.LayoutString")
        Me.cmbCodArea.DesignTimeLayout = cmbCodArea_DesignTimeLayout
        Me.cmbCodArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodArea.Location = New System.Drawing.Point(12, 23)
        Me.cmbCodArea.Name = "cmbCodArea"
        Me.cmbCodArea.SelectedIndex = -1
        Me.cmbCodArea.SelectedItem = Nothing
        Me.cmbCodArea.Size = New System.Drawing.Size(279, 20)
        Me.cmbCodArea.TabIndex = 208
        Me.cmbCodArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(118, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 209
        Me.Label7.Text = "Area"
        '
        'btnSalirOT
        '
        Me.btnSalirOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalirOT.Image = Global.SIGECOM.My.Resources.Resources.Aprobar
        Me.btnSalirOT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalirOT.Location = New System.Drawing.Point(567, 89)
        Me.btnSalirOT.Name = "btnSalirOT"
        Me.btnSalirOT.Size = New System.Drawing.Size(121, 33)
        Me.btnSalirOT.TabIndex = 210
        Me.btnSalirOT.Text = "Salir de OT"
        Me.btnSalirOT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalirOT.UseVisualStyleBackColor = True
        '
        'btnMarcarOtraActividad
        '
        Me.btnMarcarOtraActividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcarOtraActividad.Image = Global.SIGECOM.My.Resources.Resources.Agregar
        Me.btnMarcarOtraActividad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMarcarOtraActividad.Location = New System.Drawing.Point(533, 195)
        Me.btnMarcarOtraActividad.Name = "btnMarcarOtraActividad"
        Me.btnMarcarOtraActividad.Size = New System.Drawing.Size(183, 29)
        Me.btnMarcarOtraActividad.TabIndex = 211
        Me.btnMarcarOtraActividad.Text = "Marcar Otra Actividad"
        Me.btnMarcarOtraActividad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMarcarOtraActividad.UseVisualStyleBackColor = True
        Me.btnMarcarOtraActividad.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(581, 400)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 30)
        Me.btnSalir.TabIndex = 212
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Red
        Me.lblEstado.Location = New System.Drawing.Point(21, 465)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(63, 20)
        Me.lblEstado.TabIndex = 213
        Me.lblEstado.Text = "Label1"
        '
        'frmMarcarOT
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(754, 508)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnMarcarOtraActividad)
        Me.Controls.Add(Me.btnSalirOT)
        Me.Controls.Add(Me.cmbCodArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgvDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMarcarOT"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marcación de OT"
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvDatos As DataGridView
    Friend WithEvents cmbCodArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As Label
    Friend WithEvents Column1 As DataGridViewButtonColumn
    Friend WithEvents Column2 As DataGridViewButtonColumn
    Friend WithEvents Column3 As DataGridViewButtonColumn
    Friend WithEvents Column4 As DataGridViewButtonColumn
    Friend WithEvents Column5 As DataGridViewButtonColumn
    Friend WithEvents btnSalirOT As Button
    Friend WithEvents btnMarcarOtraActividad As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblEstado As Label
End Class
