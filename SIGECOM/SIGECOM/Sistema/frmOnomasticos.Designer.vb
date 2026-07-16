<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOnomasticos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOnomasticos))
        Me.dgvOnomasticos = New System.Windows.Forms.DataGridView
        Me.ApeNom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DesArea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Foto = New System.Windows.Forms.DataGridViewImageColumn
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.lblcabecera = New System.Windows.Forms.Label
        Me.lbldetalle = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.dgvOnomasticos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvOnomasticos
        '
        Me.dgvOnomasticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOnomasticos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ApeNom, Me.DesArea, Me.Foto})
        Me.dgvOnomasticos.Location = New System.Drawing.Point(30, 83)
        Me.dgvOnomasticos.Name = "dgvOnomasticos"
        Me.dgvOnomasticos.RowTemplate.Height = 100
        Me.dgvOnomasticos.Size = New System.Drawing.Size(706, 333)
        Me.dgvOnomasticos.TabIndex = 0
        '
        'ApeNom
        '
        Me.ApeNom.DataPropertyName = "ApeNom"
        Me.ApeNom.HeaderText = "Apellidos y Nombres"
        Me.ApeNom.Name = "ApeNom"
        Me.ApeNom.Width = 300
        '
        'DesArea
        '
        Me.DesArea.DataPropertyName = "DesArea"
        Me.DesArea.HeaderText = "Area"
        Me.DesArea.Name = "DesArea"
        Me.DesArea.Width = 200
        '
        'Foto
        '
        Me.Foto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Foto.DataPropertyName = "Foto"
        Me.Foto.HeaderText = "Foto"
        Me.Foto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Foto.Name = "Foto"
        Me.Foto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Foto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(351, 520)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(77, 32)
        Me.btnAceptar.TabIndex = 154
        Me.btnAceptar.Text = "Cerrar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblcabecera
        '
        Me.lblcabecera.AutoEllipsis = True
        Me.lblcabecera.AutoSize = True
        Me.lblcabecera.BackColor = System.Drawing.Color.Transparent
        Me.lblcabecera.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcabecera.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblcabecera.Location = New System.Drawing.Point(277, 38)
        Me.lblcabecera.Name = "lblcabecera"
        Me.lblcabecera.Size = New System.Drawing.Size(108, 24)
        Me.lblcabecera.TabIndex = 155
        Me.lblcabecera.Text = "Cabecera"
        '
        'lbldetalle
        '
        Me.lbldetalle.AutoSize = True
        Me.lbldetalle.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldetalle.ForeColor = System.Drawing.Color.Black
        Me.lbldetalle.Location = New System.Drawing.Point(37, 425)
        Me.lbldetalle.Name = "lbldetalle"
        Me.lbldetalle.Size = New System.Drawing.Size(60, 21)
        Me.lbldetalle.TabIndex = 156
        Me.lbldetalle.Text = "Detalle"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-2, -3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(780, 577)
        Me.PictureBox1.TabIndex = 157
        Me.PictureBox1.TabStop = False
        '
        'frmOnomasticos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(776, 569)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbldetalle)
        Me.Controls.Add(Me.lblcabecera)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgvOnomasticos)
        Me.Controls.Add(Me.PictureBox1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOnomasticos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvOnomasticos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvOnomasticos As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblcabecera As System.Windows.Forms.Label
    Friend WithEvents lbldetalle As System.Windows.Forms.Label
    Friend WithEvents ApeNom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DesArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Foto As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
