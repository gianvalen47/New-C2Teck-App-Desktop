<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepResuGeneral
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
        Dim cmbMes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepResuGeneral))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbMes = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtanio = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbtnMovResumen = New System.Windows.Forms.RadioButton()
        Me.rbtnTransfMotores = New System.Windows.Forms.RadioButton()
        Me.rbtnTransfVentas = New System.Windows.Forms.RadioButton()
        Me.rbtnCostos = New System.Windows.Forms.RadioButton()
        Me.rbtnCompras = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.cmbMes)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.txtanio)
        Me.UiGroupBox1.Location = New System.Drawing.Point(20, 12)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(253, 47)
        Me.UiGroupBox1.TabIndex = 10
        Me.UiGroupBox1.Text = "Fechas"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbMes
        '
        Me.cmbMes.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMes_DesignTimeLayout.LayoutString = resources.GetString("cmbMes_DesignTimeLayout.LayoutString")
        Me.cmbMes.DesignTimeLayout = cmbMes_DesignTimeLayout
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(141, 19)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.SelectedIndex = -1
        Me.cmbMes.SelectedItem = Nothing
        Me.cmbMes.Size = New System.Drawing.Size(94, 20)
        Me.cmbMes.TabIndex = 17
        Me.cmbMes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(108, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Año"
        '
        'txtanio
        '
        Me.txtanio.Location = New System.Drawing.Point(39, 19)
        Me.txtanio.Maximum = 9999
        Me.txtanio.MaxLength = 4
        Me.txtanio.Minimum = 2010
        Me.txtanio.Name = "txtanio"
        Me.txtanio.Size = New System.Drawing.Size(48, 20)
        Me.txtanio.TabIndex = 15
        Me.txtanio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanio.Value = 2010
        Me.txtanio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.rbtnMovResumen)
        Me.UiGroupBox2.Controls.Add(Me.rbtnTransfMotores)
        Me.UiGroupBox2.Controls.Add(Me.rbtnTransfVentas)
        Me.UiGroupBox2.Controls.Add(Me.rbtnCostos)
        Me.UiGroupBox2.Controls.Add(Me.rbtnCompras)
        Me.UiGroupBox2.Location = New System.Drawing.Point(20, 76)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(253, 192)
        Me.UiGroupBox2.TabIndex = 11
        Me.UiGroupBox2.Text = "Opciones"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbtnMovResumen
        '
        Me.rbtnMovResumen.AutoSize = True
        Me.rbtnMovResumen.Location = New System.Drawing.Point(10, 160)
        Me.rbtnMovResumen.Name = "rbtnMovResumen"
        Me.rbtnMovResumen.Size = New System.Drawing.Size(198, 17)
        Me.rbtnMovResumen.TabIndex = 4
        Me.rbtnMovResumen.TabStop = True
        Me.rbtnMovResumen.Text = "5) Mov. Resumen vs Mov. Detallado"
        Me.rbtnMovResumen.UseVisualStyleBackColor = True
        '
        'rbtnTransfMotores
        '
        Me.rbtnTransfMotores.AutoSize = True
        Me.rbtnTransfMotores.Location = New System.Drawing.Point(10, 125)
        Me.rbtnTransfMotores.Name = "rbtnTransfMotores"
        Me.rbtnTransfMotores.Size = New System.Drawing.Size(206, 17)
        Me.rbtnTransfMotores.TabIndex = 3
        Me.rbtnTransfMotores.Text = "4) Transferencias a Motores  y Depart."
        Me.rbtnTransfMotores.UseVisualStyleBackColor = True
        '
        'rbtnTransfVentas
        '
        Me.rbtnTransfVentas.AutoSize = True
        Me.rbtnTransfVentas.Location = New System.Drawing.Point(9, 90)
        Me.rbtnTransfVentas.Name = "rbtnTransfVentas"
        Me.rbtnTransfVentas.Size = New System.Drawing.Size(189, 17)
        Me.rbtnTransfVentas.TabIndex = 2
        Me.rbtnTransfVentas.Text = "3) Transferencias y Venta Gratuita "
        Me.rbtnTransfVentas.UseVisualStyleBackColor = True
        '
        'rbtnCostos
        '
        Me.rbtnCostos.AutoSize = True
        Me.rbtnCostos.Location = New System.Drawing.Point(9, 53)
        Me.rbtnCostos.Name = "rbtnCostos"
        Me.rbtnCostos.Size = New System.Drawing.Size(115, 17)
        Me.rbtnCostos.TabIndex = 1
        Me.rbtnCostos.Text = "2) Costo de Ventas"
        Me.rbtnCostos.UseVisualStyleBackColor = True
        '
        'rbtnCompras
        '
        Me.rbtnCompras.AutoSize = True
        Me.rbtnCompras.Checked = True
        Me.rbtnCompras.Location = New System.Drawing.Point(9, 19)
        Me.rbtnCompras.Name = "rbtnCompras"
        Me.rbtnCompras.Size = New System.Drawing.Size(193, 17)
        Me.rbtnCompras.TabIndex = 0
        Me.rbtnCompras.TabStop = True
        Me.rbtnCompras.Text = "1) Compras y Notas de Contabilidad"
        Me.rbtnCompras.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(62, 289)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 27)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(154, 288)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 27)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepResuGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 326)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepResuGeneral"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resumen General"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbtnTransfMotores As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnTransfVentas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCostos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCompras As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cmbMes As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtanio As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents rbtnMovResumen As System.Windows.Forms.RadioButton
End Class
