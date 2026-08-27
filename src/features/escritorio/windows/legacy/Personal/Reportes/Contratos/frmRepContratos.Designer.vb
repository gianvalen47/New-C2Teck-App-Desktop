<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepContratos
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
        Dim dgvColumnas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepContratos))
        Dim cmbClase_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnAceptarD = New System.Windows.Forms.Button()
        Me.btnAceptarP = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.dgvDatosExcel = New System.Windows.Forms.DataGridView()
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvColumnas = New Janus.Windows.GridEX.GridEX()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.gbTipo = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbDinamico = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPrincipal = New Janus.Windows.EditControls.UIRadioButton()
        Me.cmbClase = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatosExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.dgvColumnas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipo.SuspendLayout()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnAceptarD
        '
        Me.btnAceptarD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarD.Image = Global.SIGECOM.My.Resources.Resources.excel_ico
        Me.btnAceptarD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarD.Location = New System.Drawing.Point(155, 185)
        Me.btnAceptarD.Name = "btnAceptarD"
        Me.btnAceptarD.Size = New System.Drawing.Size(76, 25)
        Me.btnAceptarD.TabIndex = 13
        Me.btnAceptarD.Text = "Aceptar"
        Me.btnAceptarD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptarD.UseVisualStyleBackColor = True
        '
        'btnAceptarP
        '
        Me.btnAceptarP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarP.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptarP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarP.Location = New System.Drawing.Point(154, 185)
        Me.btnAceptarP.Name = "btnAceptarP"
        Me.btnAceptarP.Size = New System.Drawing.Size(76, 25)
        Me.btnAceptarP.TabIndex = 15
        Me.btnAceptarP.Text = "Aceptar"
        Me.btnAceptarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptarP.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(237, 185)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 25)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'dgvDatosExcel
        '
        Me.dgvDatosExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatosExcel.Location = New System.Drawing.Point(469, 183)
        Me.dgvDatosExcel.Name = "dgvDatosExcel"
        Me.dgvDatosExcel.Size = New System.Drawing.Size(191, 24)
        Me.dgvDatosExcel.TabIndex = 16
        Me.dgvDatosExcel.Visible = False
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.dgvColumnas)
        Me.gbDatos.Controls.Add(Me.cbVigente)
        Me.gbDatos.Controls.Add(Me.gbTipo)
        Me.gbDatos.Controls.Add(Me.cmbClase)
        Me.gbDatos.Controls.Add(Me.Label21)
        Me.gbDatos.Controls.Add(Me.cmbArea)
        Me.gbDatos.Controls.Add(Me.cmbCentroCosto)
        Me.gbDatos.Controls.Add(Me.Label32)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(7, 4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(653, 173)
        Me.gbDatos.TabIndex = 17
        Me.gbDatos.Text = "Datos de Reporte"
        Me.gbDatos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvColumnas
        '
        dgvColumnas_DesignTimeLayout.LayoutString = resources.GetString("dgvColumnas_DesignTimeLayout.LayoutString")
        Me.dgvColumnas.DesignTimeLayout = dgvColumnas_DesignTimeLayout
        Me.dgvColumnas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvColumnas.GroupByBoxVisible = False
        Me.dgvColumnas.Location = New System.Drawing.Point(462, 13)
        Me.dgvColumnas.Name = "dgvColumnas"
        Me.dgvColumnas.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvColumnas.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvColumnas.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvColumnas.Size = New System.Drawing.Size(184, 154)
        Me.dgvColumnas.TabIndex = 382
        Me.dgvColumnas.TabStop = False
        Me.dgvColumnas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigente.Checked = True
        Me.cbVigente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbVigente.Location = New System.Drawing.Point(273, 132)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(122, 17)
        Me.cbVigente.TabIndex = 7
        Me.cbVigente.Text = "Personal Vigente"
        Me.cbVigente.UseVisualStyleBackColor = True
        '
        'gbTipo
        '
        Me.gbTipo.Controls.Add(Me.rbDinamico)
        Me.gbTipo.Controls.Add(Me.rbPrincipal)
        Me.gbTipo.Location = New System.Drawing.Point(66, 27)
        Me.gbTipo.Name = "gbTipo"
        Me.gbTipo.Size = New System.Drawing.Size(329, 38)
        Me.gbTipo.TabIndex = 1
        Me.gbTipo.Text = "Tipo"
        Me.gbTipo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbDinamico
        '
        Me.rbDinamico.Checked = True
        Me.rbDinamico.Location = New System.Drawing.Point(178, 14)
        Me.rbDinamico.Name = "rbDinamico"
        Me.rbDinamico.Size = New System.Drawing.Size(130, 18)
        Me.rbDinamico.TabIndex = 3
        Me.rbDinamico.TabStop = True
        Me.rbDinamico.Text = "Reporte Dinámico"
        '
        'rbPrincipal
        '
        Me.rbPrincipal.Location = New System.Drawing.Point(31, 14)
        Me.rbPrincipal.Name = "rbPrincipal"
        Me.rbPrincipal.Size = New System.Drawing.Size(126, 18)
        Me.rbPrincipal.TabIndex = 2
        Me.rbPrincipal.Text = "Reporte Principal"
        '
        'cmbClase
        '
        Me.cmbClase.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbClase_DesignTimeLayout.LayoutString = resources.GetString("cmbClase_DesignTimeLayout.LayoutString")
        Me.cmbClase.DesignTimeLayout = cmbClase_DesignTimeLayout
        Me.cmbClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClase.Location = New System.Drawing.Point(52, 128)
        Me.cmbClase.Name = "cmbClase"
        Me.cmbClase.SelectedIndex = -1
        Me.cmbClase.SelectedItem = Nothing
        Me.cmbClase.Size = New System.Drawing.Size(105, 20)
        Me.cmbClase.TabIndex = 6
        Me.cmbClase.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 132)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 374
        Me.Label21.Text = "Clase"
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(52, 86)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(114, 20)
        Me.cmbArea.TabIndex = 4
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(260, 87)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(189, 20)
        Me.cmbCentroCosto.TabIndex = 5
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(179, 90)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 13)
        Me.Label32.TabIndex = 372
        Me.Label32.Text = "Centro Costo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 371
        Me.Label9.Text = "Área"
        '
        'frmRepContratos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(666, 214)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.dgvDatosExcel)
        Me.Controls.Add(Me.btnAceptarP)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptarD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepContratos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Contratos"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatosExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.dgvColumnas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipo.ResumeLayout(False)
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnAceptarD As System.Windows.Forms.Button
    Friend WithEvents btnAceptarP As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents dgvDatosExcel As System.Windows.Forms.DataGridView
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvColumnas As Janus.Windows.GridEX.GridEX
    Friend WithEvents cbVigente As System.Windows.Forms.CheckBox
    Friend WithEvents gbTipo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbDinamico As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPrincipal As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents cmbClase As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
