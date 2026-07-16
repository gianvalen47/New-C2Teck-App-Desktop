<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAfp_RubroDscto
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
        Dim cmbModalidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAfp_RubroDscto))
        Dim cmbDescuento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosRubroDscto = New Janus.Windows.EditControls.UIGroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbModalidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.btnBuscarCuenta = New System.Windows.Forms.Button
        Me.lblDesCuenta = New System.Windows.Forms.TextBox
        Me.txtCodCuenta = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbDescuento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPorcentaje = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGuardar = New System.Windows.Forms.Button
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosRubroDscto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosRubroDscto.SuspendLayout()
        CType(Me.cmbModalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Black
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosRubroDscto
        '
        Me.gbDatosRubroDscto.Controls.Add(Me.Label3)
        Me.gbDatosRubroDscto.Controls.Add(Me.cmbModalidad)
        Me.gbDatosRubroDscto.Controls.Add(Me.btnBuscarCuenta)
        Me.gbDatosRubroDscto.Controls.Add(Me.lblDesCuenta)
        Me.gbDatosRubroDscto.Controls.Add(Me.txtCodCuenta)
        Me.gbDatosRubroDscto.Controls.Add(Me.Label10)
        Me.gbDatosRubroDscto.Controls.Add(Me.Label4)
        Me.gbDatosRubroDscto.Controls.Add(Me.cmbDescuento)
        Me.gbDatosRubroDscto.Controls.Add(Me.Label8)
        Me.gbDatosRubroDscto.Controls.Add(Me.txtPorcentaje)
        Me.gbDatosRubroDscto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosRubroDscto.Location = New System.Drawing.Point(8, 6)
        Me.gbDatosRubroDscto.Name = "gbDatosRubroDscto"
        Me.gbDatosRubroDscto.Size = New System.Drawing.Size(425, 120)
        Me.gbDatosRubroDscto.TabIndex = 0
        Me.gbDatosRubroDscto.Text = "Datos de Rubro Descuento"
        Me.gbDatosRubroDscto.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(240, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 367
        Me.Label3.Text = "Modalidad"
        '
        'cmbModalidad
        '
        Me.cmbModalidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbModalidad_DesignTimeLayout.LayoutString = resources.GetString("cmbModalidad_DesignTimeLayout.LayoutString")
        Me.cmbModalidad.DesignTimeLayout = cmbModalidad_DesignTimeLayout
        Me.cmbModalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModalidad.Location = New System.Drawing.Point(311, 85)
        Me.cmbModalidad.Name = "cmbModalidad"
        Me.cmbModalidad.SelectedIndex = -1
        Me.cmbModalidad.SelectedItem = Nothing
        Me.cmbModalidad.Size = New System.Drawing.Size(95, 20)
        Me.cmbModalidad.TabIndex = 5
        Me.cmbModalidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbModalidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarCuenta
        '
        Me.btnBuscarCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarCuenta.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarCuenta.Location = New System.Drawing.Point(152, 54)
        Me.btnBuscarCuenta.Name = "btnBuscarCuenta"
        Me.btnBuscarCuenta.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarCuenta.TabIndex = 3
        Me.btnBuscarCuenta.TabStop = False
        Me.btnBuscarCuenta.UseVisualStyleBackColor = True
        '
        'lblDesCuenta
        '
        Me.lblDesCuenta.BackColor = System.Drawing.SystemColors.Control
        Me.lblDesCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDesCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblDesCuenta.Location = New System.Drawing.Point(181, 58)
        Me.lblDesCuenta.Name = "lblDesCuenta"
        Me.lblDesCuenta.ReadOnly = True
        Me.lblDesCuenta.Size = New System.Drawing.Size(225, 12)
        Me.lblDesCuenta.TabIndex = 365
        Me.lblDesCuenta.TabStop = False
        Me.lblDesCuenta.Text = "DESCRIPCIÓN DE CUENTA CONTABLE"
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.BackColor = System.Drawing.SystemColors.Window
        Me.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuenta.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCodCuenta.Location = New System.Drawing.Point(91, 55)
        Me.txtCodCuenta.MaxLength = 20
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Size = New System.Drawing.Size(58, 20)
        Me.txtCodCuenta.TabIndex = 2
        Me.txtCodCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(38, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 364
        Me.Label10.Text = "Cuenta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 359
        Me.Label4.Text = "Descuento"
        '
        'cmbDescuento
        '
        Me.cmbDescuento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbDescuento_DesignTimeLayout.LayoutString = resources.GetString("cmbDescuento_DesignTimeLayout.LayoutString")
        Me.cmbDescuento.DesignTimeLayout = cmbDescuento_DesignTimeLayout
        Me.cmbDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDescuento.Location = New System.Drawing.Point(91, 25)
        Me.cmbDescuento.Name = "cmbDescuento"
        Me.cmbDescuento.SelectedIndex = -1
        Me.cmbDescuento.SelectedItem = Nothing
        Me.cmbDescuento.Size = New System.Drawing.Size(241, 20)
        Me.cmbDescuento.TabIndex = 1
        Me.cmbDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 357
        Me.Label8.Text = "Porcentaje"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentaje.Location = New System.Drawing.Point(91, 85)
        Me.txtPorcentaje.MaxLength = 10
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(86, 20)
        Me.txtPorcentaje.TabIndex = 4
        Me.txtPorcentaje.Text = "0.00"
        Me.txtPorcentaje.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPorcentaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(223, 133)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 26)
        Me.btnCancelar.TabIndex = 7
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
        Me.btnGuardar.Location = New System.Drawing.Point(137, 133)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 26)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'frmAfp_RubroDscto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(440, 165)
        Me.Controls.Add(Me.gbDatosRubroDscto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAfp_RubroDscto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rubro Descuento"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosRubroDscto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosRubroDscto.ResumeLayout(False)
        Me.gbDatosRubroDscto.PerformLayout()
        CType(Me.cmbModalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosRubroDscto As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentaje As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbDescuento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnBuscarCuenta As System.Windows.Forms.Button
    Friend WithEvents lblDesCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbModalidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
