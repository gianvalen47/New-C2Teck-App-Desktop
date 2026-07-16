<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaPrecioCliente_Imprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListaPrecioCliente_Imprimir))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.rbPantalla = New System.Windows.Forms.RadioButton
        Me.rbExcel = New System.Windows.Forms.RadioButton
        Me.gbExportar = New Janus.Windows.EditControls.UIGroupBox
        Me.rbLisPreVig = New System.Windows.Forms.RadioButton
        Me.rbLisPreSel = New System.Windows.Forms.RadioButton
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExportar.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(130, 126)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 27)
        Me.btnCancelar.TabIndex = 155
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(37, 126)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 27)
        Me.btnAceptar.TabIndex = 154
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'rbPantalla
        '
        Me.rbPantalla.AutoSize = True
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPantalla.Location = New System.Drawing.Point(40, 19)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(71, 17)
        Me.rbPantalla.TabIndex = 2
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        Me.rbPantalla.UseVisualStyleBackColor = True
        '
        'rbExcel
        '
        Me.rbExcel.AutoSize = True
        Me.rbExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbExcel.Location = New System.Drawing.Point(117, 19)
        Me.rbExcel.Name = "rbExcel"
        Me.rbExcel.Size = New System.Drawing.Size(56, 17)
        Me.rbExcel.TabIndex = 3
        Me.rbExcel.Text = "Excel"
        Me.rbExcel.UseVisualStyleBackColor = True
        '
        'gbExportar
        '
        Me.gbExportar.Controls.Add(Me.rbExcel)
        Me.gbExportar.Controls.Add(Me.rbPantalla)
        Me.gbExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbExportar.Location = New System.Drawing.Point(21, 67)
        Me.gbExportar.Name = "gbExportar"
        Me.gbExportar.Size = New System.Drawing.Size(204, 46)
        Me.gbExportar.TabIndex = 271
        Me.gbExportar.Text = "Exportar"
        Me.gbExportar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbLisPreVig
        '
        Me.rbLisPreVig.AutoSize = True
        Me.rbLisPreVig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLisPreVig.Location = New System.Drawing.Point(34, 38)
        Me.rbLisPreVig.Name = "rbLisPreVig"
        Me.rbLisPreVig.Size = New System.Drawing.Size(157, 17)
        Me.rbLisPreVig.TabIndex = 3
        Me.rbLisPreVig.Text = "Lista de Precio Vigente"
        Me.rbLisPreVig.UseVisualStyleBackColor = True
        '
        'rbLisPreSel
        '
        Me.rbLisPreSel.AutoSize = True
        Me.rbLisPreSel.Checked = True
        Me.rbLisPreSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLisPreSel.Location = New System.Drawing.Point(34, 15)
        Me.rbLisPreSel.Name = "rbLisPreSel"
        Me.rbLisPreSel.Size = New System.Drawing.Size(191, 17)
        Me.rbLisPreSel.TabIndex = 2
        Me.rbLisPreSel.TabStop = True
        Me.rbLisPreSel.Text = "Lista de Precio Seleccionada"
        Me.rbLisPreSel.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(197, 38)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(33, 24)
        Me.DataGridView1.TabIndex = 156
        Me.DataGridView1.Visible = False
        '
        'frmListaPrecioCliente_Imprimir
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(247, 164)
        Me.Controls.Add(Me.rbLisPreVig)
        Me.Controls.Add(Me.gbExportar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.rbLisPreSel)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListaPrecioCliente_Imprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExportar.ResumeLayout(False)
        Me.gbExportar.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rbPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents rbExcel As System.Windows.Forms.RadioButton
    Friend WithEvents gbExportar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbLisPreVig As System.Windows.Forms.RadioButton
    Friend WithEvents rbLisPreSel As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
