<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContIngreso_Det
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim cmbIngreso_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContIngreso_Det))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbSueldo = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbIngreso = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtTotalImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cbAplicaCalculo = New System.Windows.Forms.CheckBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbIngreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.cbSueldo)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.cmbIngreso)
        Me.gbDatos.Controls.Add(Me.txtTotalImporte)
        Me.gbDatos.Controls.Add(Me.Label34)
        Me.gbDatos.Controls.Add(Me.cbAplicaCalculo)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(8, 5)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(297, 118)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.Text = "Datos de Ingreso"
        Me.gbDatos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbSueldo
        '
        Me.cbSueldo.AutoSize = True
        Me.cbSueldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbSueldo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbSueldo.Checked = True
        Me.cbSueldo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbSueldo.ForeColor = System.Drawing.Color.Black
        Me.cbSueldo.Location = New System.Drawing.Point(24, 88)
        Me.cbSueldo.Name = "cbSueldo"
        Me.cbSueldo.Size = New System.Drawing.Size(65, 17)
        Me.cbSueldo.TabIndex = 4
        Me.cbSueldo.Text = "Sueldo"
        Me.cbSueldo.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 337
        Me.Label1.Text = "Ingreso"
        '
        'cmbIngreso
        '
        Me.cmbIngreso.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIngreso_DesignTimeLayout.LayoutString = resources.GetString("cmbIngreso_DesignTimeLayout.LayoutString")
        Me.cmbIngreso.DesignTimeLayout = cmbIngreso_DesignTimeLayout
        Me.cmbIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIngreso.Location = New System.Drawing.Point(76, 25)
        Me.cmbIngreso.Name = "cmbIngreso"
        Me.cmbIngreso.SelectedIndex = -1
        Me.cmbIngreso.SelectedItem = Nothing
        Me.cmbIngreso.Size = New System.Drawing.Size(194, 20)
        Me.cmbIngreso.TabIndex = 1
        Me.cmbIngreso.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalImporte
        '
        Me.txtTotalImporte.DecimalDigits = 2
        Me.txtTotalImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalImporte.Location = New System.Drawing.Point(76, 54)
        Me.txtTotalImporte.MaxLength = 10
        Me.txtTotalImporte.Name = "txtTotalImporte"
        Me.txtTotalImporte.Size = New System.Drawing.Size(92, 20)
        Me.txtTotalImporte.TabIndex = 2
        Me.txtTotalImporte.Text = "0.00"
        Me.txtTotalImporte.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(21, 58)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(49, 13)
        Me.Label34.TabIndex = 334
        Me.Label34.Text = "Importe"
        '
        'cbAplicaCalculo
        '
        Me.cbAplicaCalculo.AutoSize = True
        Me.cbAplicaCalculo.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbAplicaCalculo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAplicaCalculo.Checked = True
        Me.cbAplicaCalculo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAplicaCalculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cbAplicaCalculo.ForeColor = System.Drawing.Color.Black
        Me.cbAplicaCalculo.Location = New System.Drawing.Point(208, 57)
        Me.cbAplicaCalculo.Name = "cbAplicaCalculo"
        Me.cbAplicaCalculo.Size = New System.Drawing.Size(46, 17)
        Me.cbAplicaCalculo.TabIndex = 3
        Me.cbAplicaCalculo.Text = "Fijo"
        Me.cbAplicaCalculo.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(161, 130)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(77, 130)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 27)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmContIngreso_Det
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(317, 165)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContIngreso_Det"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Ingresos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbIngreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbAplicaCalculo As System.Windows.Forms.CheckBox
    Friend WithEvents txtTotalImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbIngreso As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cbSueldo As System.Windows.Forms.CheckBox
End Class
