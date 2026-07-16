<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarioPermisos
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
        Dim cmbPerfil_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarioPermisos))
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPerfil = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.ckPerPrecio = New Janus.Windows.EditControls.UICheckBox()
        Me.rbTipFacCon = New System.Windows.Forms.RadioButton()
        Me.rbTipFacCre = New System.Windows.Forms.RadioButton()
        Me.ckCartera = New Janus.Windows.EditControls.UICheckBox()
        Me.ckTipCam = New Janus.Windows.EditControls.UICheckBox()
        Me.ckPerPrecioFOB = New Janus.Windows.EditControls.UICheckBox()
        Me.gbTipoFact = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTipFacTodos = New System.Windows.Forms.RadioButton()
        Me.ckVerGastos = New Janus.Windows.EditControls.UICheckBox()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.ckAprobacionUnica = New Janus.Windows.EditControls.UICheckBox()
        Me.ckExportarDatos = New Janus.Windows.EditControls.UICheckBox()
        Me.ckVendeOficina = New Janus.Windows.EditControls.UICheckBox()
        Me.ckGastoGerencia = New Janus.Windows.EditControls.UICheckBox()
        Me.ckPrecioFlete = New Janus.Windows.EditControls.UICheckBox()
        Me.ckVerPrecios = New Janus.Windows.EditControls.UICheckBox()
        Me.ckLibreLicencia = New Janus.Windows.EditControls.UICheckBox()
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbTipoFact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoFact.SuspendLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(219, 309)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(82, 27)
        Me.btnCancelar.TabIndex = 121
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(131, 309)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(82, 27)
        Me.btnGuardar.TabIndex = 120
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Perfil : "
        '
        'cmbPerfil
        '
        Me.cmbPerfil.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.cmbPerfil.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPerfil_DesignTimeLayout.LayoutString = resources.GetString("cmbPerfil_DesignTimeLayout.LayoutString")
        Me.cmbPerfil.DesignTimeLayout = cmbPerfil_DesignTimeLayout
        Me.cmbPerfil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPerfil.Location = New System.Drawing.Point(117, 24)
        Me.cmbPerfil.Name = "cmbPerfil"
        Me.cmbPerfil.SelectedIndex = -1
        Me.cmbPerfil.SelectedItem = Nothing
        Me.cmbPerfil.Size = New System.Drawing.Size(212, 20)
        Me.cmbPerfil.TabIndex = 123
        Me.cmbPerfil.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ckPerPrecio
        '
        Me.ckPerPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPerPrecio.Location = New System.Drawing.Point(20, 112)
        Me.ckPerPrecio.Name = "ckPerPrecio"
        Me.ckPerPrecio.Size = New System.Drawing.Size(167, 15)
        Me.ckPerPrecio.TabIndex = 127
        Me.ckPerPrecio.Text = "Puede Modificar Precios?"
        Me.ckPerPrecio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbTipFacCon
        '
        Me.rbTipFacCon.AutoSize = True
        Me.rbTipFacCon.Location = New System.Drawing.Point(23, 77)
        Me.rbTipFacCon.Name = "rbTipFacCon"
        Me.rbTipFacCon.Size = New System.Drawing.Size(133, 17)
        Me.rbTipFacCon.TabIndex = 1
        Me.rbTipFacCon.TabStop = True
        Me.rbTipFacCon.Text = "Factura al Contado"
        Me.rbTipFacCon.UseVisualStyleBackColor = True
        '
        'rbTipFacCre
        '
        Me.rbTipFacCre.AutoSize = True
        Me.rbTipFacCre.Location = New System.Drawing.Point(23, 51)
        Me.rbTipFacCre.Name = "rbTipFacCre"
        Me.rbTipFacCre.Size = New System.Drawing.Size(126, 17)
        Me.rbTipFacCre.TabIndex = 0
        Me.rbTipFacCre.TabStop = True
        Me.rbTipFacCre.Text = "Factura al Crédito"
        Me.rbTipFacCre.UseVisualStyleBackColor = True
        '
        'ckCartera
        '
        Me.ckCartera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCartera.Location = New System.Drawing.Point(20, 87)
        Me.ckCartera.Name = "ckCartera"
        Me.ckCartera.Size = New System.Drawing.Size(167, 15)
        Me.ckCartera.TabIndex = 125
        Me.ckCartera.Text = "Tiene Cartera?"
        Me.ckCartera.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckTipCam
        '
        Me.ckTipCam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckTipCam.Location = New System.Drawing.Point(20, 62)
        Me.ckTipCam.Name = "ckTipCam"
        Me.ckTipCam.Size = New System.Drawing.Size(167, 15)
        Me.ckTipCam.TabIndex = 124
        Me.ckTipCam.Text = "Ingresa Tipo de Cambio ?"
        Me.ckTipCam.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckPerPrecioFOB
        '
        Me.ckPerPrecioFOB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPerPrecioFOB.Location = New System.Drawing.Point(20, 137)
        Me.ckPerPrecioFOB.Name = "ckPerPrecioFOB"
        Me.ckPerPrecioFOB.Size = New System.Drawing.Size(187, 15)
        Me.ckPerPrecioFOB.TabIndex = 128
        Me.ckPerPrecioFOB.Text = "Puede Modificar Precio FOB?"
        Me.ckPerPrecioFOB.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbTipoFact
        '
        Me.gbTipoFact.Controls.Add(Me.rbTipFacTodos)
        Me.gbTipoFact.Controls.Add(Me.rbTipFacCon)
        Me.gbTipoFact.Controls.Add(Me.rbTipFacCre)
        Me.gbTipoFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTipoFact.Location = New System.Drawing.Point(230, 62)
        Me.gbTipoFact.Name = "gbTipoFact"
        Me.gbTipoFact.Size = New System.Drawing.Size(170, 111)
        Me.gbTipoFact.TabIndex = 129
        Me.gbTipoFact.Text = "Tipo de Facturación"
        Me.gbTipoFact.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTipFacTodos
        '
        Me.rbTipFacTodos.AutoSize = True
        Me.rbTipFacTodos.Location = New System.Drawing.Point(23, 25)
        Me.rbTipFacTodos.Name = "rbTipFacTodos"
        Me.rbTipFacTodos.Size = New System.Drawing.Size(60, 17)
        Me.rbTipFacTodos.TabIndex = 2
        Me.rbTipFacTodos.TabStop = True
        Me.rbTipFacTodos.Text = "Todos"
        Me.rbTipFacTodos.UseVisualStyleBackColor = True
        '
        'ckVerGastos
        '
        Me.ckVerGastos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerGastos.Location = New System.Drawing.Point(253, 212)
        Me.ckVerGastos.Name = "ckVerGastos"
        Me.ckVerGastos.Size = New System.Drawing.Size(147, 15)
        Me.ckVerGastos.TabIndex = 130
        Me.ckVerGastos.Text = "Ver Gastos"
        Me.ckVerGastos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.ckLibreLicencia)
        Me.UiGroupBox1.Controls.Add(Me.ckAprobacionUnica)
        Me.UiGroupBox1.Controls.Add(Me.ckExportarDatos)
        Me.UiGroupBox1.Controls.Add(Me.ckVendeOficina)
        Me.UiGroupBox1.Controls.Add(Me.ckGastoGerencia)
        Me.UiGroupBox1.Controls.Add(Me.ckPrecioFlete)
        Me.UiGroupBox1.Controls.Add(Me.ckVerPrecios)
        Me.UiGroupBox1.Controls.Add(Me.cmbPerfil)
        Me.UiGroupBox1.Controls.Add(Me.ckVerGastos)
        Me.UiGroupBox1.Controls.Add(Me.Label1)
        Me.UiGroupBox1.Controls.Add(Me.gbTipoFact)
        Me.UiGroupBox1.Controls.Add(Me.ckTipCam)
        Me.UiGroupBox1.Controls.Add(Me.ckPerPrecioFOB)
        Me.UiGroupBox1.Controls.Add(Me.ckCartera)
        Me.UiGroupBox1.Controls.Add(Me.ckPerPrecio)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(9, 6)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(431, 297)
        Me.UiGroupBox1.TabIndex = 131
        Me.UiGroupBox1.Text = "Datos de Permiso"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'ckAprobacionUnica
        '
        Me.ckAprobacionUnica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckAprobacionUnica.Location = New System.Drawing.Point(21, 262)
        Me.ckAprobacionUnica.Name = "ckAprobacionUnica"
        Me.ckAprobacionUnica.Size = New System.Drawing.Size(206, 15)
        Me.ckAprobacionUnica.TabIndex = 136
        Me.ckAprobacionUnica.Text = "Aprobacion Unica para Compras"
        Me.ckAprobacionUnica.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckExportarDatos
        '
        Me.ckExportarDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckExportarDatos.Location = New System.Drawing.Point(21, 237)
        Me.ckExportarDatos.Name = "ckExportarDatos"
        Me.ckExportarDatos.Size = New System.Drawing.Size(180, 15)
        Me.ckExportarDatos.TabIndex = 135
        Me.ckExportarDatos.Text = "Puede Exportar Datos"
        Me.ckExportarDatos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckVendeOficina
        '
        Me.ckVendeOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVendeOficina.Location = New System.Drawing.Point(20, 212)
        Me.ckVendeOficina.Name = "ckVendeOficina"
        Me.ckVendeOficina.Size = New System.Drawing.Size(180, 15)
        Me.ckVendeOficina.TabIndex = 134
        Me.ckVendeOficina.Text = "Venta Solo Oficina"
        Me.ckVendeOficina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckGastoGerencia
        '
        Me.ckGastoGerencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckGastoGerencia.Location = New System.Drawing.Point(20, 187)
        Me.ckGastoGerencia.Name = "ckGastoGerencia"
        Me.ckGastoGerencia.Size = New System.Drawing.Size(180, 15)
        Me.ckGastoGerencia.TabIndex = 133
        Me.ckGastoGerencia.Text = "Procesa Gasto Gerencia"
        Me.ckGastoGerencia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckPrecioFlete
        '
        Me.ckPrecioFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPrecioFlete.Location = New System.Drawing.Point(20, 162)
        Me.ckPrecioFlete.Name = "ckPrecioFlete"
        Me.ckPrecioFlete.Size = New System.Drawing.Size(180, 15)
        Me.ckPrecioFlete.TabIndex = 132
        Me.ckPrecioFlete.Text = "Ingresa Precio Flete"
        Me.ckPrecioFlete.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckVerPrecios
        '
        Me.ckVerPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckVerPrecios.Location = New System.Drawing.Point(253, 187)
        Me.ckVerPrecios.Name = "ckVerPrecios"
        Me.ckVerPrecios.Size = New System.Drawing.Size(147, 15)
        Me.ckVerPrecios.TabIndex = 131
        Me.ckVerPrecios.Text = "Ver Precios"
        Me.ckVerPrecios.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ckLibreLicencia
        '
        Me.ckLibreLicencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckLibreLicencia.Location = New System.Drawing.Point(253, 237)
        Me.ckLibreLicencia.Name = "ckLibreLicencia"
        Me.ckLibreLicencia.Size = New System.Drawing.Size(168, 15)
        Me.ckLibreLicencia.TabIndex = 137
        Me.ckLibreLicencia.Text = "Libre Licencia de Equipos"
        Me.ckLibreLicencia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'frmUsuarioPermisos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(452, 374)
        Me.Controls.Add(Me.UiGroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUsuarioPermisos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresar Permisos"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPerfil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbTipoFact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoFact.ResumeLayout(False)
        Me.gbTipoFact.PerformLayout()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPerfil As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents ckPerPrecio As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents rbTipFacCon As System.Windows.Forms.RadioButton
    Friend WithEvents rbTipFacCre As System.Windows.Forms.RadioButton
    Friend WithEvents ckCartera As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckTipCam As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckPerPrecioFOB As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckVerGastos As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents gbTipoFact As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTipFacTodos As System.Windows.Forms.RadioButton
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ckVerPrecios As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckVendeOficina As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckGastoGerencia As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckPrecioFlete As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckExportarDatos As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckAprobacionUnica As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ckLibreLicencia As Janus.Windows.EditControls.UICheckBox
End Class
