<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModeloTelefonia
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
        Dim cmbMarca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModeloTelefonia))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gbDatosTipoHoraExtra = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cbActivo = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdModelo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDesModelo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.gbDatosTipoHoraExtra,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbDatosTipoHoraExtra.SuspendLayout
        CType(Me.cmbMarca,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ofEstiloForm,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(237, 164)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 28)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbDatosTipoHoraExtra
        '
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cmbMarca)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cbActivo)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label2)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtIdModelo)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label1)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label9)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtDesModelo)
        Me.gbDatosTipoHoraExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosTipoHoraExtra.Location = New System.Drawing.Point(12, 12)
        Me.gbDatosTipoHoraExtra.Name = "gbDatosTipoHoraExtra"
        Me.gbDatosTipoHoraExtra.Size = New System.Drawing.Size(447, 146)
        Me.gbDatosTipoHoraExtra.TabIndex = 14
        Me.gbDatosTipoHoraExtra.Text = "Datos de Modelo"
        Me.gbDatosTipoHoraExtra.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbMarca
        '
        Me.cmbMarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMarca_DesignTimeLayout.LayoutString = resources.GetString("cmbMarca_DesignTimeLayout.LayoutString")
        Me.cmbMarca.DesignTimeLayout = cmbMarca_DesignTimeLayout
        Me.cmbMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarca.Location = New System.Drawing.Point(99, 84)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.SelectedIndex = -1
        Me.cmbMarca.SelectedItem = Nothing
        Me.cmbMarca.Size = New System.Drawing.Size(224, 20)
        Me.cmbMarca.TabIndex = 3
        Me.cmbMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbActivo
        '
        Me.cbActivo.AutoSize = True
        Me.cbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.Location = New System.Drawing.Point(50, 117)
        Me.cbActivo.Name = "cbActivo"
        Me.cbActivo.Size = New System.Drawing.Size(62, 17)
        Me.cbActivo.TabIndex = 6
        Me.cbActivo.TabStop = False
        Me.cbActivo.Text = "Activo"
        Me.cbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbActivo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 258
        Me.Label2.Text = "Marca"
        '
        'txtIdModelo
        '
        Me.txtIdModelo.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdModelo.ForeColor = System.Drawing.Color.Navy
        Me.txtIdModelo.Location = New System.Drawing.Point(99, 24)
        Me.txtIdModelo.MaxLength = 5
        Me.txtIdModelo.Name = "txtIdModelo"
        Me.txtIdModelo.ReadOnly = True
        Me.txtIdModelo.Size = New System.Drawing.Size(63, 20)
        Me.txtIdModelo.TabIndex = 1
        Me.txtIdModelo.TabStop = False
        Me.txtIdModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Código"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "Descripción"
        '
        'txtDesModelo
        '
        Me.txtDesModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesModelo.Location = New System.Drawing.Point(99, 54)
        Me.txtDesModelo.Name = "txtDesModelo"
        Me.txtDesModelo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesModelo.Size = New System.Drawing.Size(331, 20)
        Me.txtDesModelo.TabIndex = 2
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(153, 164)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 28)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmModeloTelefonia
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(470, 197)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gbDatosTipoHoraExtra)
        Me.Controls.Add(Me.btnGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(478, 231)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(478, 231)
        Me.Name = "frmModeloTelefonia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modelo"
        CType(Me.gbDatosTipoHoraExtra,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbDatosTipoHoraExtra.ResumeLayout(false)
        Me.gbDatosTipoHoraExtra.PerformLayout
        CType(Me.cmbMarca,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ofEstiloForm,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gbDatosTipoHoraExtra As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdModelo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDesModelo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
End Class
