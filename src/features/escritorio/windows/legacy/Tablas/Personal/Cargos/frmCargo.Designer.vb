<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargo
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
        Dim cmbClaseCargo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargo))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosCargo = New Janus.Windows.EditControls.UIGroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAbrCargo = New Janus.Windows.GridEX.EditControls.EditBox
        Me.txtCodCargo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbClaseCargo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDesCargo = New Janus.Windows.GridEX.EditControls.EditBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosCargo.SuspendLayout()
        CType(Me.cmbClaseCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosCargo
        '
        Me.gbDatosCargo.Controls.Add(Me.Label2)
        Me.gbDatosCargo.Controls.Add(Me.txtAbrCargo)
        Me.gbDatosCargo.Controls.Add(Me.txtCodCargo)
        Me.gbDatosCargo.Controls.Add(Me.Label1)
        Me.gbDatosCargo.Controls.Add(Me.Label4)
        Me.gbDatosCargo.Controls.Add(Me.cmbClaseCargo)
        Me.gbDatosCargo.Controls.Add(Me.Label9)
        Me.gbDatosCargo.Controls.Add(Me.txtDesCargo)
        Me.gbDatosCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosCargo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.gbDatosCargo.Location = New System.Drawing.Point(8, 4)
        Me.gbDatosCargo.Name = "gbDatosCargo"
        Me.gbDatosCargo.Size = New System.Drawing.Size(480, 113)
        Me.gbDatosCargo.TabIndex = 0
        Me.gbDatosCargo.Text = "Datos de Cargo de Personal"
        Me.gbDatosCargo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 258
        Me.Label2.Text = "Abreviatura"
        '
        'txtAbrCargo
        '
        Me.txtAbrCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbrCargo.Location = New System.Drawing.Point(90, 80)
        Me.txtAbrCargo.MaxLength = 3
        Me.txtAbrCargo.Name = "txtAbrCargo"
        Me.txtAbrCargo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAbrCargo.Size = New System.Drawing.Size(100, 20)
        Me.txtAbrCargo.TabIndex = 3
        '
        'txtCodCargo
        '
        Me.txtCodCargo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodCargo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodCargo.Location = New System.Drawing.Point(90, 20)
        Me.txtCodCargo.Name = "txtCodCargo"
        Me.txtCodCargo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodCargo.TabIndex = 1
        Me.txtCodCargo.TabStop = False
        Me.txtCodCargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Código"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(271, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 254
        Me.Label4.Text = "Clase Cargo"
        '
        'cmbClaseCargo
        '
        Me.cmbClaseCargo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbClaseCargo_DesignTimeLayout.LayoutString = resources.GetString("cmbClaseCargo_DesignTimeLayout.LayoutString")
        Me.cmbClaseCargo.DesignTimeLayout = cmbClaseCargo_DesignTimeLayout
        Me.cmbClaseCargo.Location = New System.Drawing.Point(352, 80)
        Me.cmbClaseCargo.Name = "cmbClaseCargo"
        Me.cmbClaseCargo.SelectedIndex = -1
        Me.cmbClaseCargo.SelectedItem = Nothing
        Me.cmbClaseCargo.Size = New System.Drawing.Size(115, 20)
        Me.cmbClaseCargo.TabIndex = 4
        Me.cmbClaseCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "Descripción"
        '
        'txtDesCargo
        '
        Me.txtDesCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesCargo.Location = New System.Drawing.Point(90, 50)
        Me.txtDesCargo.Name = "txtDesCargo"
        Me.txtDesCargo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesCargo.Size = New System.Drawing.Size(377, 20)
        Me.txtDesCargo.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(251, 124)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 5
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
        Me.btnGuardar.Location = New System.Drawing.Point(167, 124)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmCargo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(496, 157)
        Me.Controls.Add(Me.gbDatosCargo)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCargo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargo de Personal"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosCargo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosCargo.ResumeLayout(False)
        Me.gbDatosCargo.PerformLayout()
        CType(Me.cmbClaseCargo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosCargo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDesCargo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbClaseCargo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtCodCargo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAbrCargo As Janus.Windows.GridEX.EditControls.EditBox
End Class
