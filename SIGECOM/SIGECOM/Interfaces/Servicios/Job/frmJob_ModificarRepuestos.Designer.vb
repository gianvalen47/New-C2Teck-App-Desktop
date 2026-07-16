<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob_ModificarRepuestos
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
        Dim cmbRubro_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJob_ModificarRepuestos))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCodMer = New System.Windows.Forms.TextBox()
        Me.btnModificarRepuestos = New System.Windows.Forms.Button()
        Me.cbActivo = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCantidad = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbRubro = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(286, 45)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(295, 54)
        Me.txtObservacion.TabIndex = 261
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(286, 17)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(204, 20)
        Me.txtDescripcion.TabIndex = 148
        '
        'txtCodMer
        '
        Me.txtCodMer.Location = New System.Drawing.Point(67, 16)
        Me.txtCodMer.Name = "txtCodMer"
        Me.txtCodMer.ReadOnly = True
        Me.txtCodMer.Size = New System.Drawing.Size(100, 20)
        Me.txtCodMer.TabIndex = 147
        '
        'btnModificarRepuestos
        '
        Me.btnModificarRepuestos.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnModificarRepuestos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificarRepuestos.Location = New System.Drawing.Point(587, 62)
        Me.btnModificarRepuestos.Name = "btnModificarRepuestos"
        Me.btnModificarRepuestos.Size = New System.Drawing.Size(70, 27)
        Me.btnModificarRepuestos.TabIndex = 146
        Me.btnModificarRepuestos.Text = "  Guardar"
        Me.btnModificarRepuestos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModificarRepuestos.UseVisualStyleBackColor = True
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbActivo.Location = New System.Drawing.Point(6, 47)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(62, 17)
        Me.cbActivo.TabIndex = 144
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(198, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 140
        Me.Label5.Text = "Observación :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(531, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 138
        Me.Label3.Text = "Cantidad :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(198, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Descripción :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "Código :"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.Label23)
        Me.UiGroupBox1.Controls.Add(Me.cmbRubro)
        Me.UiGroupBox1.Controls.Add(Me.txtCantidad)
        Me.UiGroupBox1.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtDescripcion)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtCodMer)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.btnModificarRepuestos)
        Me.UiGroupBox1.Controls.Add(Me.cbActivo)
        Me.UiGroupBox1.Controls.Add(Me.Label5)
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 2)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(666, 108)
        Me.UiGroupBox1.TabIndex = 1
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(602, 17)
        Me.txtCantidad.Maximum = 300
        Me.txtCantidad.MaxLength = 200
        Me.txtCantidad.Minimum = 1
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(55, 20)
        Me.txtCantidad.TabIndex = 262
        Me.txtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCantidad.Value = 1
        Me.txtCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(13, 78)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 13)
        Me.Label23.TabIndex = 264
        Me.Label23.Text = "Rubro :"
        '
        'cmbRubro
        '
        Me.cmbRubro.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRubro_DesignTimeLayout.LayoutString = resources.GetString("cmbRubro_DesignTimeLayout.LayoutString")
        Me.cmbRubro.DesignTimeLayout = cmbRubro_DesignTimeLayout
        Me.cmbRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRubro.Location = New System.Drawing.Point(68, 76)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.ReadOnly = True
        Me.cmbRubro.SelectedIndex = -1
        Me.cmbRubro.SelectedItem = Nothing
        Me.cmbRubro.Size = New System.Drawing.Size(164, 20)
        Me.cmbRubro.TabIndex = 263
        Me.cmbRubro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'frmJob_ModificarRepuestos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(697, 132)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJob_ModificarRepuestos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Repuestos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbRubro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnModificarRepuestos As System.Windows.Forms.Button
    Friend WithEvents cbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodMer As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCantidad As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label23 As Label
    Friend WithEvents cmbRubro As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
