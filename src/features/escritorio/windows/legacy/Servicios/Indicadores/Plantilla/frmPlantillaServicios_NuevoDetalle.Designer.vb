<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantillaServicios_NuevoDetalle
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
        Dim cmbCargo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlantillaServicios_NuevoDetalle))
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.dgvCargos = New System.Windows.Forms.DataGridView()
        Me.dgvPredecesor = New System.Windows.Forms.DataGridView()
        Me.btnLimpiarCargo = New System.Windows.Forms.Button()
        Me.txtDesCargo = New System.Windows.Forms.TextBox()
        Me.cmbCargo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPredecesor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDuracion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtNumPer = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.txtPosicion = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.txtDurTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtActividad = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBuscarPlantilla = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnPasarCargo = New System.Windows.Forms.Button()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPredecesor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
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
        Me.btnCancelar.Location = New System.Drawing.Point(406, 146)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(82, 27)
        Me.btnCancelar.TabIndex = 222
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'dgvCargos
        '
        Me.dgvCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCargos.Location = New System.Drawing.Point(774, 149)
        Me.dgvCargos.Name = "dgvCargos"
        Me.dgvCargos.Size = New System.Drawing.Size(25, 22)
        Me.dgvCargos.TabIndex = 221
        Me.dgvCargos.Visible = False
        '
        'dgvPredecesor
        '
        Me.dgvPredecesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPredecesor.Location = New System.Drawing.Point(743, 149)
        Me.dgvPredecesor.Name = "dgvPredecesor"
        Me.dgvPredecesor.Size = New System.Drawing.Size(24, 22)
        Me.dgvPredecesor.TabIndex = 220
        Me.dgvPredecesor.Visible = False
        '
        'btnLimpiarCargo
        '
        Me.btnLimpiarCargo.Image = CType(resources.GetObject("btnLimpiarCargo.Image"), System.Drawing.Image)
        Me.btnLimpiarCargo.Location = New System.Drawing.Point(771, 111)
        Me.btnLimpiarCargo.Name = "btnLimpiarCargo"
        Me.btnLimpiarCargo.Size = New System.Drawing.Size(30, 25)
        Me.btnLimpiarCargo.TabIndex = 219
        Me.btnLimpiarCargo.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnLimpiarCargo, "Borrar Cargos")
        Me.btnLimpiarCargo.UseVisualStyleBackColor = True
        '
        'txtDesCargo
        '
        Me.txtDesCargo.BackColor = System.Drawing.SystemColors.Window
        Me.txtDesCargo.Location = New System.Drawing.Point(252, 114)
        Me.txtDesCargo.Multiline = True
        Me.txtDesCargo.Name = "txtDesCargo"
        Me.txtDesCargo.ReadOnly = True
        Me.txtDesCargo.Size = New System.Drawing.Size(516, 20)
        Me.txtDesCargo.TabIndex = 218
        '
        'cmbCargo
        '
        Me.cmbCargo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCargo_DesignTimeLayout.LayoutString = resources.GetString("cmbCargo_DesignTimeLayout.LayoutString")
        Me.cmbCargo.DesignTimeLayout = cmbCargo_DesignTimeLayout
        Me.cmbCargo.Location = New System.Drawing.Point(85, 114)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.SelectedIndex = -1
        Me.cmbCargo.SelectedItem = Nothing
        Me.cmbCargo.Size = New System.Drawing.Size(135, 20)
        Me.cmbCargo.TabIndex = 217
        Me.cmbCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 117)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 216
        Me.Label9.Text = "Cargo : "
        '
        'txtPredecesor
        '
        Me.txtPredecesor.BackColor = System.Drawing.SystemColors.Window
        Me.txtPredecesor.Location = New System.Drawing.Point(743, 79)
        Me.txtPredecesor.Multiline = True
        Me.txtPredecesor.Name = "txtPredecesor"
        Me.txtPredecesor.Size = New System.Drawing.Size(56, 19)
        Me.txtPredecesor.TabIndex = 212
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(661, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 211
        Me.Label8.Text = "Predecesor :"
        '
        'txtDuracion
        '
        Me.txtDuracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuracion.Location = New System.Drawing.Point(246, 78)
        Me.txtDuracion.MaxLength = 10
        Me.txtDuracion.Name = "txtDuracion"
        Me.txtDuracion.Size = New System.Drawing.Size(60, 20)
        Me.txtDuracion.TabIndex = 156
        Me.txtDuracion.Text = "0.00"
        Me.txtDuracion.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDuracion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumPer
        '
        Me.txtNumPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumPer.Location = New System.Drawing.Point(407, 78)
        Me.txtNumPer.Maximum = 300000
        Me.txtNumPer.MaxLength = 200
        Me.txtNumPer.Name = "txtNumPer"
        Me.txtNumPer.Size = New System.Drawing.Size(56, 20)
        Me.txtNumPer.TabIndex = 155
        Me.txtNumPer.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtNumPer.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtPosicion
        '
        Me.txtPosicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosicion.Location = New System.Drawing.Point(85, 78)
        Me.txtPosicion.Maximum = 300000
        Me.txtPosicion.MaxLength = 200
        Me.txtPosicion.Name = "txtPosicion"
        Me.txtPosicion.Size = New System.Drawing.Size(51, 20)
        Me.txtPosicion.TabIndex = 153
        Me.txtPosicion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtPosicion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtDurTotal
        '
        Me.txtDurTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDurTotal.Location = New System.Drawing.Point(584, 78)
        Me.txtDurTotal.MaxLength = 10
        Me.txtDurTotal.Name = "txtDurTotal"
        Me.txtDurTotal.ReadOnly = True
        Me.txtDurTotal.Size = New System.Drawing.Size(60, 20)
        Me.txtDurTotal.TabIndex = 154
        Me.txtDurTotal.Text = "0.00"
        Me.txtDurTotal.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDurTotal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(484, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 152
        Me.Label3.Text = "Duración Total :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(322, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "N° Personas :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(149, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "Duración (Hrs) :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Posición :"
        '
        'txtActividad
        '
        Me.txtActividad.BackColor = System.Drawing.SystemColors.Control
        Me.txtActividad.Location = New System.Drawing.Point(85, 27)
        Me.txtActividad.Multiline = True
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.ReadOnly = True
        Me.txtActividad.Size = New System.Drawing.Size(683, 37)
        Me.txtActividad.TabIndex = 135
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(318, 146)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(82, 27)
        Me.btnGuardar.TabIndex = 138
        Me.btnGuardar.Text = "  Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 97
        Me.Label6.Text = "Actividad :"
        '
        'btnBuscarPlantilla
        '
        Me.btnBuscarPlantilla.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPlantilla.Location = New System.Drawing.Point(771, 33)
        Me.btnBuscarPlantilla.Name = "btnBuscarPlantilla"
        Me.btnBuscarPlantilla.Size = New System.Drawing.Size(30, 25)
        Me.btnBuscarPlantilla.TabIndex = 96
        Me.btnBuscarPlantilla.UseVisualStyleBackColor = True
        Me.btnBuscarPlantilla.Visible = False
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 202)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(835, 20)
        Me.ssBarra.TabIndex = 210
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(320, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(200, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.UiGroupBox1.Controls.Add(Me.btnPasarCargo)
        Me.UiGroupBox1.Controls.Add(Me.btnCancelar)
        Me.UiGroupBox1.Controls.Add(Me.txtActividad)
        Me.UiGroupBox1.Controls.Add(Me.dgvCargos)
        Me.UiGroupBox1.Controls.Add(Me.btnBuscarPlantilla)
        Me.UiGroupBox1.Controls.Add(Me.dgvPredecesor)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.btnLimpiarCargo)
        Me.UiGroupBox1.Controls.Add(Me.btnGuardar)
        Me.UiGroupBox1.Controls.Add(Me.Label7)
        Me.UiGroupBox1.Controls.Add(Me.txtDesCargo)
        Me.UiGroupBox1.Controls.Add(Me.Label4)
        Me.UiGroupBox1.Controls.Add(Me.cmbCargo)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.Label9)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Controls.Add(Me.txtPredecesor)
        Me.UiGroupBox1.Controls.Add(Me.txtDurTotal)
        Me.UiGroupBox1.Controls.Add(Me.Label8)
        Me.UiGroupBox1.Controls.Add(Me.txtPosicion)
        Me.UiGroupBox1.Controls.Add(Me.txtDuracion)
        Me.UiGroupBox1.Controls.Add(Me.txtNumPer)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(7, 8)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(820, 188)
        Me.UiGroupBox1.TabIndex = 211
        Me.UiGroupBox1.Text = "Mantenimiento de Plantillas"
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnPasarCargo
        '
        Me.btnPasarCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPasarCargo.Image = CType(resources.GetObject("btnPasarCargo.Image"), System.Drawing.Image)
        Me.btnPasarCargo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPasarCargo.Location = New System.Drawing.Point(222, 112)
        Me.btnPasarCargo.Name = "btnPasarCargo"
        Me.btnPasarCargo.Size = New System.Drawing.Size(24, 25)
        Me.btnPasarCargo.TabIndex = 223
        Me.btnPasarCargo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPasarCargo.UseVisualStyleBackColor = True
        '
        'frmPlantillaServicios_NuevoDetalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(835, 222)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.ssBarra)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlantillaServicios_NuevoDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Plantilla"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCargos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPredecesor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCargo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents txtActividad As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarPlantilla As System.Windows.Forms.Button
    Friend WithEvents txtDuracion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtNumPer As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents txtPosicion As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents txtDurTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPredecesor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarCargo As System.Windows.Forms.Button
    Friend WithEvents txtDesCargo As System.Windows.Forms.TextBox
    Friend WithEvents cmbCargo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvCargos As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPredecesor As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnPasarCargo As System.Windows.Forms.Button
End Class
