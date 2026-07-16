<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepMovimientosAlmacen
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
        Dim cmbCodRub_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepMovimientosAlmacen))
        Dim cmbTipoMovimiento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbCodMov_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbOficinas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim cmbIdLocacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.OfficeFormAdorner1 = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos = New System.Windows.Forms.GroupBox
        Me.gbMercaderia = New Janus.Windows.EditControls.UIGroupBox
        Me.rbFormato2 = New System.Windows.Forms.RadioButton
        Me.rbFormato1 = New System.Windows.Forms.RadioButton
        Me.gbOrdenar = New Janus.Windows.EditControls.UIGroupBox
        Me.cbUbicacion = New System.Windows.Forms.CheckBox
        Me.cbBajoMaximo = New System.Windows.Forms.CheckBox
        Me.cmbCodRub = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbTipoMovimiento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cmbCodMov = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtUbiMer = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbMarca = New System.Windows.Forms.RadioButton
        Me.txtMarca = New System.Windows.Forms.TextBox
        Me.btnBuscaMarca = New System.Windows.Forms.Button
        Me.cmbOficinas = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbIdLocacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.gbMercaderia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMercaderia.SuspendLayout()
        CType(Me.gbOrdenar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrdenar.SuspendLayout()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodMov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OfficeFormAdorner1
        '
        Me.OfficeFormAdorner1.Form = Me
        Me.OfficeFormAdorner1.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.gbMercaderia)
        Me.gbDatos.Controls.Add(Me.gbOrdenar)
        Me.gbDatos.Controls.Add(Me.cbBajoMaximo)
        Me.gbDatos.Controls.Add(Me.cmbCodRub)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.cmbTipoMovimiento)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.cbFecFinal)
        Me.gbDatos.Controls.Add(Me.cbFecInicio)
        Me.gbDatos.Controls.Add(Me.cmbCodMov)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.txtUbiMer)
        Me.gbDatos.Controls.Add(Me.GroupBox2)
        Me.gbDatos.Controls.Add(Me.cmbOficinas)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.cmbIdLocacion)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(6, 12)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(487, 274)
        Me.gbDatos.TabIndex = 25
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Movimientos de Almacén "
        '
        'gbMercaderia
        '
        Me.gbMercaderia.Controls.Add(Me.rbFormato2)
        Me.gbMercaderia.Controls.Add(Me.rbFormato1)
        Me.gbMercaderia.Location = New System.Drawing.Point(6, 198)
        Me.gbMercaderia.Name = "gbMercaderia"
        Me.gbMercaderia.Size = New System.Drawing.Size(160, 65)
        Me.gbMercaderia.TabIndex = 64
        Me.gbMercaderia.Text = "Reporte"
        Me.gbMercaderia.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbFormato2
        '
        Me.rbFormato2.AutoSize = True
        Me.rbFormato2.Location = New System.Drawing.Point(14, 40)
        Me.rbFormato2.Name = "rbFormato2"
        Me.rbFormato2.Size = New System.Drawing.Size(81, 17)
        Me.rbFormato2.TabIndex = 1
        Me.rbFormato2.Text = "Formato 2"
        Me.rbFormato2.UseVisualStyleBackColor = True
        '
        'rbFormato1
        '
        Me.rbFormato1.AutoSize = True
        Me.rbFormato1.Checked = True
        Me.rbFormato1.Location = New System.Drawing.Point(14, 17)
        Me.rbFormato1.Name = "rbFormato1"
        Me.rbFormato1.Size = New System.Drawing.Size(81, 17)
        Me.rbFormato1.TabIndex = 0
        Me.rbFormato1.TabStop = True
        Me.rbFormato1.Text = "Formato 1"
        Me.rbFormato1.UseVisualStyleBackColor = True
        '
        'gbOrdenar
        '
        Me.gbOrdenar.Controls.Add(Me.cbUbicacion)
        Me.gbOrdenar.Location = New System.Drawing.Point(314, 215)
        Me.gbOrdenar.Name = "gbOrdenar"
        Me.gbOrdenar.Size = New System.Drawing.Size(160, 43)
        Me.gbOrdenar.TabIndex = 61
        Me.gbOrdenar.Text = "Ordenar"
        Me.gbOrdenar.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbUbicacion
        '
        Me.cbUbicacion.AutoSize = True
        Me.cbUbicacion.Location = New System.Drawing.Point(28, 19)
        Me.cbUbicacion.Name = "cbUbicacion"
        Me.cbUbicacion.Size = New System.Drawing.Size(106, 17)
        Me.cbUbicacion.TabIndex = 44
        Me.cbUbicacion.Text = "Por Ubicación"
        Me.cbUbicacion.UseVisualStyleBackColor = True
        '
        'cbBajoMaximo
        '
        Me.cbBajoMaximo.AutoSize = True
        Me.cbBajoMaximo.Location = New System.Drawing.Point(185, 215)
        Me.cbBajoMaximo.Name = "cbBajoMaximo"
        Me.cbBajoMaximo.Size = New System.Drawing.Size(111, 17)
        Me.cbBajoMaximo.TabIndex = 45
        Me.cbBajoMaximo.Text = "Bajo el Máximo"
        Me.cbBajoMaximo.UseVisualStyleBackColor = True
        '
        'cmbCodRub
        '
        Me.cmbCodRub.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodRub_DesignTimeLayout.LayoutString = resources.GetString("cmbCodRub_DesignTimeLayout.LayoutString")
        Me.cmbCodRub.DesignTimeLayout = cmbCodRub_DesignTimeLayout
        Me.cmbCodRub.Location = New System.Drawing.Point(89, 135)
        Me.cmbCodRub.Name = "cmbCodRub"
        Me.cmbCodRub.SelectedIndex = -1
        Me.cmbCodRub.SelectedItem = Nothing
        Me.cmbCodRub.Size = New System.Drawing.Size(129, 20)
        Me.cmbCodRub.TabIndex = 44
        Me.cmbCodRub.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 16)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Rubro:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "{ TipMov }"
        '
        'cmbTipoMovimiento
        '
        Me.cmbTipoMovimiento.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoMovimiento_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoMovimiento_DesignTimeLayout.LayoutString")
        Me.cmbTipoMovimiento.DesignTimeLayout = cmbTipoMovimiento_DesignTimeLayout
        Me.cmbTipoMovimiento.Location = New System.Drawing.Point(89, 172)
        Me.cmbTipoMovimiento.Name = "cmbTipoMovimiento"
        Me.cmbTipoMovimiento.SelectedIndex = -1
        Me.cmbTipoMovimiento.SelectedItem = Nothing
        Me.cmbTipoMovimiento.Size = New System.Drawing.Size(129, 20)
        Me.cmbTipoMovimiento.TabIndex = 9
        Me.cmbTipoMovimiento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(262, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 16)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Al"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Location = New System.Drawing.Point(301, 16)
        Me.cbFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecFinal.Name = "cbFecFinal"
        Me.cbFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.cbFecFinal.TabIndex = 3
        Me.cbFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbFecInicio
        '
        '
        '
        '
        Me.cbFecInicio.DropDownCalendar.Name = ""
        Me.cbFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecInicio.Location = New System.Drawing.Point(149, 16)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 2
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbCodMov
        '
        Me.cmbCodMov.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodMov_DesignTimeLayout.LayoutString = resources.GetString("cmbCodMov_DesignTimeLayout.LayoutString")
        Me.cmbCodMov.DesignTimeLayout = cmbCodMov_DesignTimeLayout
        Me.cmbCodMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodMov.Location = New System.Drawing.Point(345, 55)
        Me.cmbCodMov.Name = "cmbCodMov"
        Me.cmbCodMov.SelectedIndex = -1
        Me.cmbCodMov.SelectedItem = Nothing
        Me.cmbCodMov.Size = New System.Drawing.Size(129, 20)
        Me.cmbCodMov.TabIndex = 40
        Me.cmbCodMov.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(236, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 16)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "{ Ubicación }"
        '
        'txtUbiMer
        '
        Me.txtUbiMer.Location = New System.Drawing.Point(345, 87)
        Me.txtUbiMer.Name = "txtUbiMer"
        Me.txtUbiMer.Size = New System.Drawing.Size(129, 20)
        Me.txtUbiMer.TabIndex = 36
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbMarca)
        Me.GroupBox2.Controls.Add(Me.txtMarca)
        Me.GroupBox2.Controls.Add(Me.btnBuscaMarca)
        Me.GroupBox2.Location = New System.Drawing.Point(309, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(167, 74)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar Marca"
        '
        'rbMarca
        '
        Me.rbMarca.AutoSize = True
        Me.rbMarca.Checked = True
        Me.rbMarca.Location = New System.Drawing.Point(11, 21)
        Me.rbMarca.Name = "rbMarca"
        Me.rbMarca.Size = New System.Drawing.Size(93, 17)
        Me.rbMarca.TabIndex = 32
        Me.rbMarca.TabStop = True
        Me.rbMarca.Text = "Toda Marca"
        Me.rbMarca.UseVisualStyleBackColor = True
        '
        'txtMarca
        '
        Me.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtMarca.Location = New System.Drawing.Point(11, 42)
        Me.txtMarca.MaxLength = 3
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(115, 20)
        Me.txtMarca.TabIndex = 27
        Me.txtMarca.TabStop = False
        '
        'btnBuscaMarca
        '
        Me.btnBuscaMarca.Image = CType(resources.GetObject("btnBuscaMarca.Image"), System.Drawing.Image)
        Me.btnBuscaMarca.Location = New System.Drawing.Point(126, 41)
        Me.btnBuscaMarca.Name = "btnBuscaMarca"
        Me.btnBuscaMarca.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscaMarca.TabIndex = 28
        Me.btnBuscaMarca.UseVisualStyleBackColor = True
        '
        'cmbOficinas
        '
        Me.cmbOficinas.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbOficinas_DesignTimeLayout.LayoutString = resources.GetString("cmbOficinas_DesignTimeLayout.LayoutString")
        Me.cmbOficinas.DesignTimeLayout = cmbOficinas_DesignTimeLayout
        Me.cmbOficinas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOficinas.Location = New System.Drawing.Point(89, 53)
        Me.cmbOficinas.Name = "cmbOficinas"
        Me.cmbOficinas.SelectedIndex = -1
        Me.cmbOficinas.SelectedItem = Nothing
        Me.cmbOficinas.Size = New System.Drawing.Size(129, 20)
        Me.cmbOficinas.TabIndex = 7
        Me.cmbOficinas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(236, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "{ Movimiento }"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fechas      Del : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Oficina:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(237, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 16)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "{ Marca }"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Almacén:"
        '
        'cmbIdLocacion
        '
        Me.cmbIdLocacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbIdLocacion_DesignTimeLayout.LayoutString = resources.GetString("cmbIdLocacion_DesignTimeLayout.LayoutString")
        Me.cmbIdLocacion.DesignTimeLayout = cmbIdLocacion_DesignTimeLayout
        Me.cmbIdLocacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdLocacion.Location = New System.Drawing.Point(89, 87)
        Me.cmbIdLocacion.Name = "cmbIdLocacion"
        Me.cmbIdLocacion.SelectedIndex = -1
        Me.cmbIdLocacion.SelectedItem = Nothing
        Me.cmbIdLocacion.Size = New System.Drawing.Size(129, 20)
        Me.cmbIdLocacion.TabIndex = 8
        Me.cmbIdLocacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(166, 291)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(73, 25)
        Me.btnAceptar.TabIndex = 28
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(271, 292)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 25)
        Me.btnCancelar.TabIndex = 29
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmRepMovimientosAlmacen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(504, 322)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gbDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(512, 280)
        Me.Name = "frmRepMovimientosAlmacen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Movimientos de Almacen"
        CType(Me.OfficeFormAdorner1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.gbMercaderia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMercaderia.ResumeLayout(False)
        Me.gbMercaderia.PerformLayout()
        CType(Me.gbOrdenar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrdenar.ResumeLayout(False)
        Me.gbOrdenar.PerformLayout()
        CType(Me.cmbCodRub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodMov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cmbOficinas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbIdLocacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OfficeFormAdorner1 As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtUbiMer As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbMarca As System.Windows.Forms.RadioButton
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscaMarca As System.Windows.Forms.Button
    Friend WithEvents cmbOficinas As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbIdLocacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbCodMov As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMovimiento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbCodRub As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cbBajoMaximo As System.Windows.Forms.CheckBox
    Friend WithEvents gbOrdenar As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbUbicacion As System.Windows.Forms.CheckBox
    Friend WithEvents gbMercaderia As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbFormato2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbFormato1 As System.Windows.Forms.RadioButton
End Class
