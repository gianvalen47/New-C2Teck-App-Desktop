<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPruebaBancos
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Prueba = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Prueba2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Prueba3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rgvTelerik = New Telerik.WinControls.UI.RadGridView
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgvTelerik, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rgvTelerik.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Prueba, Me.Prueba2, Me.Prueba3})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(694, 208)
        Me.DataGridView1.TabIndex = 0
        '
        'Prueba
        '
        Me.Prueba.HeaderText = "Prueba"
        Me.Prueba.Items.AddRange(New Object() {"Combo1", "Combo2", "Combo3"})
        Me.Prueba.Name = "Prueba"
        '
        'Prueba2
        '
        Me.Prueba2.HeaderText = "Prueba2"
        Me.Prueba2.Items.AddRange(New Object() {"SubCombo1", "SubCombo2", "SubCombo3"})
        Me.Prueba2.Name = "Prueba2"
        '
        'Prueba3
        '
        Me.Prueba3.HeaderText = "Prueba3"
        Me.Prueba3.Name = "Prueba3"
        '
        'rgvTelerik
        '
        Me.rgvTelerik.BackColor = System.Drawing.SystemColors.Control
        Me.rgvTelerik.Cursor = System.Windows.Forms.Cursors.Default
        Me.rgvTelerik.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rgvTelerik.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rgvTelerik.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rgvTelerik.Location = New System.Drawing.Point(12, 252)
        '
        'rgvTelerik
        '
        GridViewTextBoxColumn1.FormatString = ""
        GridViewTextBoxColumn1.HeaderText = "column1"
        GridViewTextBoxColumn1.Name = "column1"
        GridViewTextBoxColumn1.Width = 75
        GridViewTextBoxColumn2.FormatString = ""
        GridViewTextBoxColumn2.HeaderText = "column2"
        GridViewTextBoxColumn2.Name = "column2"
        GridViewTextBoxColumn2.Width = 75
        GridViewTextBoxColumn3.HeaderText = "column3"
        GridViewTextBoxColumn3.Name = "column3"
        Me.rgvTelerik.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3})
        Me.rgvTelerik.MasterTemplate.EnableFiltering = True
        Me.rgvTelerik.Name = "rgvTelerik"
        Me.rgvTelerik.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rgvTelerik.Size = New System.Drawing.Size(262, 205)
        Me.rgvTelerik.TabIndex = 1
        Me.rgvTelerik.Text = "RadGridView1"
        '
        'frmPruebaBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 511)
        Me.Controls.Add(Me.rgvTelerik)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmPruebaBancos"
        Me.Text = "frmPruebaBancos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgvTelerik.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rgvTelerik, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Prueba As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Prueba2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Prueba3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rgvTelerik As Telerik.WinControls.UI.RadGridView
End Class
