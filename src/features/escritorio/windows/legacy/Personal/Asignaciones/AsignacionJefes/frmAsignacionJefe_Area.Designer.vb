<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignacionJefe_Area
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
        Me.components = New System.ComponentModel.Container
        Dim cmbMonCompra_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbMonViatico_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignacionJefe_Area))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.gbJefeArea = New Janus.Windows.EditControls.UIGroupBox
        Me.cmbMonCompra = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMontoViatico = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMontoCompra = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.cbLimiteViatico = New System.Windows.Forms.CheckBox
        Me.cbLimiteCompra = New System.Windows.Forms.CheckBox
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label26 = New System.Windows.Forms.Label
        Me.cmbMonViatico = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbJefeArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbJefeArea.SuspendLayout()
        CType(Me.cmbMonCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMonViatico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(274, 181)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(79, 27)
        Me.btnCancelar.TabIndex = 11
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
        Me.btnGuardar.Location = New System.Drawing.Point(189, 181)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(79, 27)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 263
        Me.Label9.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(93, 118)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(435, 39)
        Me.txtObservacion.TabIndex = 9
        '
        'gbJefeArea
        '
        Me.gbJefeArea.Controls.Add(Me.txtMontoViatico)
        Me.gbJefeArea.Controls.Add(Me.cmbMonViatico)
        Me.gbJefeArea.Controls.Add(Me.Label1)
        Me.gbJefeArea.Controls.Add(Me.Label3)
        Me.gbJefeArea.Controls.Add(Me.txtMontoCompra)
        Me.gbJefeArea.Controls.Add(Me.Label8)
        Me.gbJefeArea.Controls.Add(Me.cmbMonCompra)
        Me.gbJefeArea.Controls.Add(Me.Label2)
        Me.gbJefeArea.Controls.Add(Me.cbLimiteViatico)
        Me.gbJefeArea.Controls.Add(Me.cbLimiteCompra)
        Me.gbJefeArea.Controls.Add(Me.cmbCentroCosto)
        Me.gbJefeArea.Controls.Add(Me.Label7)
        Me.gbJefeArea.Controls.Add(Me.cmbArea)
        Me.gbJefeArea.Controls.Add(Me.Label26)
        Me.gbJefeArea.Controls.Add(Me.Label9)
        Me.gbJefeArea.Controls.Add(Me.txtObservacion)
        Me.gbJefeArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbJefeArea.Location = New System.Drawing.Point(9, 6)
        Me.gbJefeArea.Name = "gbJefeArea"
        Me.gbJefeArea.Size = New System.Drawing.Size(538, 168)
        Me.gbJefeArea.TabIndex = 0
        Me.gbJefeArea.Text = "Datos de Asignación de Área"
        Me.gbJefeArea.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbMonCompra
        '
        Me.cmbMonCompra.BackColor = System.Drawing.SystemColors.Control
        Me.cmbMonCompra.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMonCompra_DesignTimeLayout.LayoutString = resources.GetString("cmbMonCompra_DesignTimeLayout.LayoutString")
        Me.cmbMonCompra.DesignTimeLayout = cmbMonCompra_DesignTimeLayout
        Me.cmbMonCompra.Location = New System.Drawing.Point(249, 57)
        Me.cmbMonCompra.Name = "cmbMonCompra"
        Me.cmbMonCompra.ReadOnly = True
        Me.cmbMonCompra.SelectedIndex = -1
        Me.cmbMonCompra.SelectedItem = Nothing
        Me.cmbMonCompra.Size = New System.Drawing.Size(74, 20)
        Me.cmbMonCompra.TabIndex = 4
        Me.cmbMonCompra.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMonCompra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(152, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 274
        Me.Label2.Text = "Moneda Comp."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(355, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 273
        Me.Label1.Text = "Monto Viático"
        '
        'txtMontoViatico
        '
        Me.txtMontoViatico.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoViatico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoViatico.Location = New System.Drawing.Point(446, 87)
        Me.txtMontoViatico.MaxLength = 10
        Me.txtMontoViatico.Name = "txtMontoViatico"
        Me.txtMontoViatico.ReadOnly = True
        Me.txtMontoViatico.Size = New System.Drawing.Size(82, 20)
        Me.txtMontoViatico.TabIndex = 8
        Me.txtMontoViatico.Text = "0.00"
        Me.txtMontoViatico.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoViatico.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(352, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 271
        Me.Label8.Text = "Monto Compra"
        '
        'txtMontoCompra
        '
        Me.txtMontoCompra.BackColor = System.Drawing.SystemColors.Control
        Me.txtMontoCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoCompra.Location = New System.Drawing.Point(446, 57)
        Me.txtMontoCompra.MaxLength = 10
        Me.txtMontoCompra.Name = "txtMontoCompra"
        Me.txtMontoCompra.ReadOnly = True
        Me.txtMontoCompra.Size = New System.Drawing.Size(82, 20)
        Me.txtMontoCompra.TabIndex = 5
        Me.txtMontoCompra.Text = "0.00"
        Me.txtMontoCompra.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoCompra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbLimiteViatico
        '
        Me.cbLimiteViatico.AutoSize = True
        Me.cbLimiteViatico.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbLimiteViatico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbLimiteViatico.ForeColor = System.Drawing.Color.Black
        Me.cbLimiteViatico.Location = New System.Drawing.Point(16, 90)
        Me.cbLimiteViatico.Name = "cbLimiteViatico"
        Me.cbLimiteViatico.Size = New System.Drawing.Size(102, 17)
        Me.cbLimiteViatico.TabIndex = 6
        Me.cbLimiteViatico.Text = "Limite Viático"
        Me.cbLimiteViatico.UseVisualStyleBackColor = False
        '
        'cbLimiteCompra
        '
        Me.cbLimiteCompra.AutoSize = True
        Me.cbLimiteCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbLimiteCompra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbLimiteCompra.ForeColor = System.Drawing.Color.Black
        Me.cbLimiteCompra.Location = New System.Drawing.Point(13, 60)
        Me.cbLimiteCompra.Name = "cbLimiteCompra"
        Me.cbLimiteCompra.Size = New System.Drawing.Size(105, 17)
        Me.cbLimiteCompra.TabIndex = 3
        Me.cbLimiteCompra.Text = "Limite Compra"
        Me.cbLimiteCompra.UseVisualStyleBackColor = False
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(322, 26)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(206, 20)
        Me.cmbCentroCosto.TabIndex = 2
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 266
        Me.Label7.Text = "Area"
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Location = New System.Drawing.Point(52, 26)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(133, 20)
        Me.cmbArea.TabIndex = 1
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(236, 30)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(80, 13)
        Me.Label26.TabIndex = 267
        Me.Label26.Text = "Centro Costo"
        '
        'cmbMonViatico
        '
        Me.cmbMonViatico.BackColor = System.Drawing.SystemColors.Control
        Me.cmbMonViatico.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMonViatico_DesignTimeLayout.LayoutString = resources.GetString("cmbMonViatico_DesignTimeLayout.LayoutString")
        Me.cmbMonViatico.DesignTimeLayout = cmbMonViatico_DesignTimeLayout
        Me.cmbMonViatico.Location = New System.Drawing.Point(249, 87)
        Me.cmbMonViatico.Name = "cmbMonViatico"
        Me.cmbMonViatico.ReadOnly = True
        Me.cmbMonViatico.SelectedIndex = -1
        Me.cmbMonViatico.SelectedItem = Nothing
        Me.cmbMonViatico.Size = New System.Drawing.Size(74, 20)
        Me.cmbMonViatico.TabIndex = 7
        Me.cmbMonViatico.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMonViatico.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(157, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 276
        Me.Label3.Text = "Moneda Vtco."
        '
        'frmAsignacionJefe_Area
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(556, 215)
        Me.Controls.Add(Me.gbJefeArea)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAsignacionJefe_Area"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignacion de Área"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbJefeArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbJefeArea.ResumeLayout(False)
        Me.gbJefeArea.PerformLayout()
        CType(Me.cmbMonCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMonViatico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbJefeArea As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cbLimiteCompra As System.Windows.Forms.CheckBox
    Friend WithEvents cbLimiteViatico As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMontoViatico As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMontoCompra As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbMonCompra As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMonViatico As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
