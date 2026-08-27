<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartida
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
        Dim cmbCodRubPar_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPartida))
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtParPar = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.cmbCodRubPar = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDesPar = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCodPar = New System.Windows.Forms.TextBox
        Me.gbSubDatos1 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSobPar = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtFacPar = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSegPar = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAdvPar = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnGuardar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbCodRubPar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSubDatos1.SuspendLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.txtParPar)
        Me.gbDatos.Controls.Add(Me.cmbCodRubPar)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.txtDesPar)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.txtCodPar)
        Me.gbDatos.Controls.Add(Me.gbSubDatos1)
        Me.gbDatos.Location = New System.Drawing.Point(5, 2)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(391, 160)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos de la Partida"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Partida"
        '
        'txtParPar
        '
        Me.txtParPar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtParPar.Location = New System.Drawing.Point(74, 61)
        Me.txtParPar.Mask = "####.##.##.##"
        Me.txtParPar.Name = "txtParPar"
        Me.txtParPar.PromptChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtParPar.Size = New System.Drawing.Size(100, 20)
        Me.txtParPar.TabIndex = 3
        Me.txtParPar.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        '
        'cmbCodRubPar
        '
        Me.cmbCodRubPar.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRubPar_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRubPar_DesignTimeLayout.LayoutString")
        Me.cmbCodRubPar.DesignTimeLayout = cmbCodRubPar_DesignTimeLayout
        Me.cmbCodRubPar.Location = New System.Drawing.Point(258, 15)
        Me.cmbCodRubPar.Name = "cmbCodRubPar"
        Me.cmbCodRubPar.SelectedIndex = -1
        Me.cmbCodRubPar.SelectedItem = Nothing
        Me.cmbCodRubPar.Size = New System.Drawing.Size(127, 20)
        Me.cmbCodRubPar.TabIndex = 1
        Me.cmbCodRubPar.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(223, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Rubro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Descripción"
        '
        'txtDesPar
        '
        Me.txtDesPar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesPar.Location = New System.Drawing.Point(74, 38)
        Me.txtDesPar.MaxLength = 50
        Me.txtDesPar.Name = "txtDesPar"
        Me.txtDesPar.Size = New System.Drawing.Size(311, 20)
        Me.txtDesPar.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Código"
        '
        'txtCodPar
        '
        Me.txtCodPar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodPar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodPar.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodPar.Location = New System.Drawing.Point(74, 15)
        Me.txtCodPar.MaxLength = 3
        Me.txtCodPar.Name = "txtCodPar"
        Me.txtCodPar.ReadOnly = True
        Me.txtCodPar.Size = New System.Drawing.Size(95, 20)
        Me.txtCodPar.TabIndex = 0
        Me.txtCodPar.TabStop = False
        '
        'gbSubDatos1
        '
        Me.gbSubDatos1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gbSubDatos1.Controls.Add(Me.Label12)
        Me.gbSubDatos1.Controls.Add(Me.Label11)
        Me.gbSubDatos1.Controls.Add(Me.Label10)
        Me.gbSubDatos1.Controls.Add(Me.Label9)
        Me.gbSubDatos1.Controls.Add(Me.Label8)
        Me.gbSubDatos1.Controls.Add(Me.txtSobPar)
        Me.gbSubDatos1.Controls.Add(Me.Label7)
        Me.gbSubDatos1.Controls.Add(Me.txtFacPar)
        Me.gbSubDatos1.Controls.Add(Me.Label6)
        Me.gbSubDatos1.Controls.Add(Me.txtSegPar)
        Me.gbSubDatos1.Controls.Add(Me.Label5)
        Me.gbSubDatos1.Controls.Add(Me.txtAdvPar)
        Me.gbSubDatos1.Location = New System.Drawing.Point(12, 84)
        Me.gbSubDatos1.Name = "gbSubDatos1"
        Me.gbSubDatos1.Size = New System.Drawing.Size(372, 70)
        Me.gbSubDatos1.TabIndex = 4
        Me.gbSubDatos1.TabStop = False
        Me.gbSubDatos1.Text = "Porcentajes"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(348, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(348, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(164, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(164, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(203, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Sobretasa"
        '
        'txtSobPar
        '
        Me.txtSobPar.Location = New System.Drawing.Point(266, 42)
        Me.txtSobPar.MaxLength = 5
        Me.txtSobPar.Name = "txtSobPar"
        Me.txtSobPar.Size = New System.Drawing.Size(79, 20)
        Me.txtSobPar.TabIndex = 3
        Me.txtSobPar.Text = "0.00"
        Me.txtSobPar.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(203, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Factor"
        '
        'txtFacPar
        '
        Me.txtFacPar.Location = New System.Drawing.Point(266, 19)
        Me.txtFacPar.MaxLength = 5
        Me.txtFacPar.Name = "txtFacPar"
        Me.txtFacPar.Size = New System.Drawing.Size(79, 20)
        Me.txtFacPar.TabIndex = 1
        Me.txtFacPar.Text = "0.00"
        Me.txtFacPar.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Seguro"
        '
        'txtSegPar
        '
        Me.txtSegPar.Location = New System.Drawing.Point(83, 42)
        Me.txtSegPar.MaxLength = 5
        Me.txtSegPar.Name = "txtSegPar"
        Me.txtSegPar.Size = New System.Drawing.Size(79, 20)
        Me.txtSegPar.TabIndex = 2
        Me.txtSegPar.Text = "0.00"
        Me.txtSegPar.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Advalorem"
        '
        'txtAdvPar
        '
        Me.txtAdvPar.Location = New System.Drawing.Point(83, 19)
        Me.txtAdvPar.MaxLength = 5
        Me.txtAdvPar.Name = "txtAdvPar"
        Me.txtAdvPar.Size = New System.Drawing.Size(79, 20)
        Me.txtAdvPar.TabIndex = 0
        Me.txtAdvPar.Text = "0.00"
        Me.txtAdvPar.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(175, 167)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(73, 25)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(323, 167)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(249, 167)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(73, 25)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'frmPartida
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(401, 197)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEliminar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPartida"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Partida"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbCodRubPar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSubDatos1.ResumeLayout(False)
        Me.gbSubDatos1.PerformLayout()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbCodRubPar As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDesPar As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodPar As System.Windows.Forms.TextBox
    Friend WithEvents gbSubDatos1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtParPar As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSobPar As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFacPar As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSegPar As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAdvPar As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
