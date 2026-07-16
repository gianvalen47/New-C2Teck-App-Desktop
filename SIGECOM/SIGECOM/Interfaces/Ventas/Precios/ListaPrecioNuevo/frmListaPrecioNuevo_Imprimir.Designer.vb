<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaPrecioNuevo_Imprimir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListaPrecioNuevo_Imprimir))
        Me.rbLisPreVig = New System.Windows.Forms.RadioButton()
        Me.gbExportar = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbExcel = New System.Windows.Forms.RadioButton()
        Me.rbPantalla = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.rbLisPreSel = New System.Windows.Forms.RadioButton()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExportar.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbLisPreVig
        '
        Me.rbLisPreVig.AutoSize = True
        Me.rbLisPreVig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLisPreVig.Location = New System.Drawing.Point(23, 148)
        Me.rbLisPreVig.Name = "rbLisPreVig"
        Me.rbLisPreVig.Size = New System.Drawing.Size(157, 17)
        Me.rbLisPreVig.TabIndex = 273
        Me.rbLisPreVig.Text = "Lista de Precio Vigente"
        Me.rbLisPreVig.UseVisualStyleBackColor = True
        Me.rbLisPreVig.Visible = False
        '
        'gbExportar
        '
        Me.gbExportar.Controls.Add(Me.rbExcel)
        Me.gbExportar.Controls.Add(Me.rbPantalla)
        Me.gbExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbExportar.Location = New System.Drawing.Point(23, 56)
        Me.gbExportar.Name = "gbExportar"
        Me.gbExportar.Size = New System.Drawing.Size(204, 46)
        Me.gbExportar.TabIndex = 277
        Me.gbExportar.Text = "Exportar"
        Me.gbExportar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
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
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(215, 141)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(33, 24)
        Me.DataGridView1.TabIndex = 276
        Me.DataGridView1.Visible = False
        '
        'rbLisPreSel
        '
        Me.rbLisPreSel.AutoSize = True
        Me.rbLisPreSel.Checked = True
        Me.rbLisPreSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLisPreSel.Location = New System.Drawing.Point(36, 23)
        Me.rbLisPreSel.Name = "rbLisPreSel"
        Me.rbLisPreSel.Size = New System.Drawing.Size(191, 17)
        Me.rbLisPreSel.TabIndex = 1
        Me.rbLisPreSel.TabStop = True
        Me.rbLisPreSel.Text = "Lista de Precio Seleccionada"
        Me.rbLisPreSel.UseVisualStyleBackColor = True
        Me.rbLisPreSel.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(132, 115)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 27)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(39, 115)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 27)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmListaPrecioNuevo_Imprimir
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(253, 174)
        Me.Controls.Add(Me.rbLisPreVig)
        Me.Controls.Add(Me.gbExportar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.rbLisPreSel)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListaPrecioNuevo_Imprimir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista Precio Imprimir"
        CType(Me.gbExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExportar.ResumeLayout(False)
        Me.gbExportar.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rbLisPreVig As RadioButton
    Friend WithEvents gbExportar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbExcel As RadioButton
    Friend WithEvents rbPantalla As RadioButton
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents rbLisPreSel As RadioButton
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
