<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReembolso_Det
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
        Dim cmbTipoGasto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbPlaca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReembolso_Det))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtItem = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtDescripcion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoGasto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbPlaca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbTipoGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(249, 241)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 188
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
        Me.btnGuardar.Location = New System.Drawing.Point(166, 241)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(77, 25)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.TabStop = False
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Observación"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.txtItem)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.txtImporte)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.txtObservacion)
        Me.UiGroupBox2.Controls.Add(Me.txtDescripcion)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.cmbTipoGasto)
        Me.UiGroupBox2.Controls.Add(Me.cmbPlaca)
        Me.UiGroupBox2.Controls.Add(Me.Label15)
        Me.UiGroupBox2.Controls.Add(Me.Label11)
        Me.UiGroupBox2.Controls.Add(Me.cmbArea)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(480, 229)
        Me.UiGroupBox2.TabIndex = 186
        Me.UiGroupBox2.Text = "Detalle"
        Me.UiGroupBox2.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtItem
        '
        Me.txtItem.BackColor = System.Drawing.Color.Beige
        Me.txtItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItem.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtItem.Location = New System.Drawing.Point(89, 22)
        Me.txtItem.MaxLength = 200
        Me.txtItem.Minimum = 1
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(90, 22)
        Me.txtItem.TabIndex = 0
        Me.txtItem.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtItem.Value = 1
        Me.txtItem.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 252
        Me.Label5.Text = "Item"
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(89, 84)
        Me.txtImporte.MaxLength = 12
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(104, 20)
        Me.txtImporte.TabIndex = 4
        Me.txtImporte.Text = "0.00"
        Me.txtImporte.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Importe"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(89, 172)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(382, 46)
        Me.txtObservacion.TabIndex = 6
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(89, 115)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(382, 46)
        Me.txtDescripcion.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 248
        Me.Label1.Text = "Tipo Gasto"
        '
        'cmbTipoGasto
        '
        Me.cmbTipoGasto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoGasto_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoGasto_DesignTimeLayout.LayoutString")
        Me.cmbTipoGasto.DesignTimeLayout = cmbTipoGasto_DesignTimeLayout
        Me.cmbTipoGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoGasto.Location = New System.Drawing.Point(89, 53)
        Me.cmbTipoGasto.Name = "cmbTipoGasto"
        Me.cmbTipoGasto.SelectedIndex = -1
        Me.cmbTipoGasto.SelectedItem = Nothing
        Me.cmbTipoGasto.Size = New System.Drawing.Size(186, 20)
        Me.cmbTipoGasto.TabIndex = 2
        Me.cmbTipoGasto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbPlaca
        '
        Me.cmbPlaca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPlaca_DesignTimeLayout.LayoutString = resources.GetString("cmbPlaca_DesignTimeLayout.LayoutString")
        Me.cmbPlaca.DesignTimeLayout = cmbPlaca_DesignTimeLayout
        Me.cmbPlaca.Location = New System.Drawing.Point(337, 53)
        Me.cmbPlaca.Name = "cmbPlaca"
        Me.cmbPlaca.SelectedIndex = -1
        Me.cmbPlaca.SelectedItem = Nothing
        Me.cmbPlaca.Size = New System.Drawing.Size(100, 20)
        Me.cmbPlaca.TabIndex = 3
        Me.cmbPlaca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(294, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 245
        Me.Label15.Text = "Placa"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(294, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Area"
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(337, 24)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(133, 20)
        Me.cmbArea.TabIndex = 1
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Descripción"
        '
        'frmReembolso_Det
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(494, 276)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReembolso_Det"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbTipoGasto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbPlaca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoGasto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtItem As Janus.Windows.GridEX.EditControls.IntegerUpDown
End Class
