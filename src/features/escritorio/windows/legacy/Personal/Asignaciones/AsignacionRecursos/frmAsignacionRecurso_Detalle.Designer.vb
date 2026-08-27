<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignacionRecurso_Detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignacionRecurso_Detalle))
        Dim cmbEmpCom_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarActivo = New System.Windows.Forms.Button()
        Me.gbComunicaciones = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNumCelular = New System.Windows.Forms.TextBox()
        Me.txtNumRadio = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDesPlan = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbEmpCom = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblRubro = New System.Windows.Forms.Label()
        Me.cbUsoPersonal = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTalla = New System.Windows.Forms.TextBox()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDesOtroUso = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtFecDevuelto = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbDevuelto = New System.Windows.Forms.CheckBox()
        Me.gbDatosDevolucion = New Janus.Windows.EditControls.UIGroupBox()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.gbComunicaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbComunicaciones.SuspendLayout()
        CType(Me.cmbEmpCom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosDevolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosDevolucion.SuspendLayout()
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
        Me.btnCancelar.Location = New System.Drawing.Point(271, 331)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 20
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
        Me.btnGuardar.Location = New System.Drawing.Point(187, 331)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 19
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.btnBuscarActivo)
        Me.gbDetalle.Controls.Add(Me.gbComunicaciones)
        Me.gbDetalle.Controls.Add(Me.cbUsoPersonal)
        Me.gbDetalle.Controls.Add(Me.Label13)
        Me.gbDetalle.Controls.Add(Me.txtTalla)
        Me.gbDetalle.Controls.Add(Me.lblSerie)
        Me.gbDetalle.Controls.Add(Me.txtSerie)
        Me.gbDetalle.Controls.Add(Me.Label11)
        Me.gbDetalle.Controls.Add(Me.txtObservacion)
        Me.gbDetalle.Controls.Add(Me.Label8)
        Me.gbDetalle.Controls.Add(Me.txtModelo)
        Me.gbDetalle.Controls.Add(Me.Label5)
        Me.gbDetalle.Controls.Add(Me.txtMarca)
        Me.gbDetalle.Controls.Add(Me.Label3)
        Me.gbDetalle.Controls.Add(Me.txtDesOtroUso)
        Me.gbDetalle.Controls.Add(Me.lblDescripcion)
        Me.gbDetalle.Controls.Add(Me.txtDescripcion)
        Me.gbDetalle.Controls.Add(Me.txtCantidad)
        Me.gbDetalle.Controls.Add(Me.lblCantidad)
        Me.gbDetalle.Controls.Add(Me.lblCodigo)
        Me.gbDetalle.Controls.Add(Me.txtCodigo)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(8, 6)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(552, 276)
        Me.gbDetalle.TabIndex = 0
        Me.gbDetalle.Text = "Detalle"
        Me.gbDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarActivo
        '
        Me.btnBuscarActivo.Image = CType(resources.GetObject("btnBuscarActivo.Image"), System.Drawing.Image)
        Me.btnBuscarActivo.Location = New System.Drawing.Point(300, 18)
        Me.btnBuscarActivo.Name = "btnBuscarActivo"
        Me.btnBuscarActivo.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarActivo.TabIndex = 211
        Me.btnBuscarActivo.TabStop = False
        Me.btnBuscarActivo.UseVisualStyleBackColor = True
        '
        'gbComunicaciones
        '
        Me.gbComunicaciones.Controls.Add(Me.Label9)
        Me.gbComunicaciones.Controls.Add(Me.txtNumCelular)
        Me.gbComunicaciones.Controls.Add(Me.txtNumRadio)
        Me.gbComunicaciones.Controls.Add(Me.Label10)
        Me.gbComunicaciones.Controls.Add(Me.txtDesPlan)
        Me.gbComunicaciones.Controls.Add(Me.Label4)
        Me.gbComunicaciones.Controls.Add(Me.cmbEmpCom)
        Me.gbComunicaciones.Controls.Add(Me.lblRubro)
        Me.gbComunicaciones.Location = New System.Drawing.Point(7, 188)
        Me.gbComunicaciones.Name = "gbComunicaciones"
        Me.gbComunicaciones.Size = New System.Drawing.Size(539, 80)
        Me.gbComunicaciones.TabIndex = 11
        Me.gbComunicaciones.Text = "Equipo de Comunicaciones"
        Me.gbComunicaciones.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(196, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 202
        Me.Label9.Text = "# Celular"
        '
        'txtNumCelular
        '
        Me.txtNumCelular.Location = New System.Drawing.Point(256, 21)
        Me.txtNumCelular.Name = "txtNumCelular"
        Me.txtNumCelular.Size = New System.Drawing.Size(87, 20)
        Me.txtNumCelular.TabIndex = 14
        '
        'txtNumRadio
        '
        Me.txtNumRadio.Location = New System.Drawing.Point(411, 21)
        Me.txtNumRadio.Name = "txtNumRadio"
        Me.txtNumRadio.Size = New System.Drawing.Size(122, 20)
        Me.txtNumRadio.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(358, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 204
        Me.Label10.Text = "# Radio"
        '
        'txtDesPlan
        '
        Me.txtDesPlan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesPlan.Location = New System.Drawing.Point(70, 50)
        Me.txtDesPlan.Name = "txtDesPlan"
        Me.txtDesPlan.Size = New System.Drawing.Size(463, 18)
        Me.txtDesPlan.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Plan"
        '
        'cmbEmpCom
        '
        Me.cmbEmpCom.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEmpCom_DesignTimeLayout.LayoutString = resources.GetString("cmbEmpCom_DesignTimeLayout.LayoutString")
        Me.cmbEmpCom.DesignTimeLayout = cmbEmpCom_DesignTimeLayout
        Me.cmbEmpCom.Location = New System.Drawing.Point(70, 21)
        Me.cmbEmpCom.Name = "cmbEmpCom"
        Me.cmbEmpCom.SelectedIndex = -1
        Me.cmbEmpCom.SelectedItem = Nothing
        Me.cmbEmpCom.Size = New System.Drawing.Size(114, 20)
        Me.cmbEmpCom.TabIndex = 12
        Me.cmbEmpCom.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.Location = New System.Drawing.Point(11, 25)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(55, 13)
        Me.lblRubro.TabIndex = 194
        Me.lblRubro.Text = "Empresa"
        '
        'cbUsoPersonal
        '
        Me.cbUsoPersonal.AutoSize = True
        Me.cbUsoPersonal.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbUsoPersonal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbUsoPersonal.Checked = True
        Me.cbUsoPersonal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbUsoPersonal.ForeColor = System.Drawing.Color.Black
        Me.cbUsoPersonal.Location = New System.Drawing.Point(12, 120)
        Me.cbUsoPersonal.Name = "cbUsoPersonal"
        Me.cbUsoPersonal.Size = New System.Drawing.Size(101, 17)
        Me.cbUsoPersonal.TabIndex = 8
        Me.cbUsoPersonal.Text = "Uso Personal"
        Me.cbUsoPersonal.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(48, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 210
        Me.Label13.Text = "Talla"
        '
        'txtTalla
        '
        Me.txtTalla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTalla.Location = New System.Drawing.Point(89, 86)
        Me.txtTalla.Name = "txtTalla"
        Me.txtTalla.Size = New System.Drawing.Size(50, 20)
        Me.txtTalla.TabIndex = 5
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = True
        Me.lblSerie.Location = New System.Drawing.Point(342, 22)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(36, 13)
        Me.lblSerie.TabIndex = 208
        Me.lblSerie.Text = "Serie"
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(380, 19)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(166, 20)
        Me.txtSerie.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 205
        Me.Label11.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(89, 152)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(457, 31)
        Me.txtObservacion.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(154, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 200
        Me.Label8.Text = "Modelo"
        '
        'txtModelo
        '
        Me.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModelo.Location = New System.Drawing.Point(204, 86)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(106, 20)
        Me.txtModelo.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(326, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 198
        Me.Label5.Text = "Marca"
        '
        'txtMarca
        '
        Me.txtMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMarca.Location = New System.Drawing.Point(371, 86)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(175, 20)
        Me.txtMarca.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(145, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Otro Uso"
        '
        'txtDesOtroUso
        '
        Me.txtDesOtroUso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesOtroUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesOtroUso.Location = New System.Drawing.Point(204, 114)
        Me.txtDesOtroUso.Multiline = True
        Me.txtDesOtroUso.Name = "txtDesOtroUso"
        Me.txtDesOtroUso.ReadOnly = True
        Me.txtDesOtroUso.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesOtroUso.Size = New System.Drawing.Size(342, 31)
        Me.txtDesOtroUso.TabIndex = 9
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(9, 55)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(74, 13)
        Me.lblDescripcion.TabIndex = 15
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(89, 47)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescripcion.Size = New System.Drawing.Size(457, 31)
        Me.txtDescripcion.TabIndex = 4
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(89, 19)
        Me.txtCantidad.Maximum = 300
        Me.txtCantidad.MaxLength = 200
        Me.txtCantidad.Minimum = 1
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(50, 20)
        Me.txtCantidad.TabIndex = 1
        Me.txtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCantidad.Value = 1
        Me.txtCantidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(26, 22)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(57, 13)
        Me.lblCantidad.TabIndex = 2
        Me.lblCantidad.Text = "Cantidad"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(156, 22)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(46, 13)
        Me.lblCodigo.TabIndex = 1
        Me.lblCodigo.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Location = New System.Drawing.Point(204, 19)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigo.TabIndex = 2
        '
        'txtFecDevuelto
        '
        Me.txtFecDevuelto.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecDevuelto.DropDownCalendar.Name = ""
        Me.txtFecDevuelto.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecDevuelto.IsNullDate = True
        Me.txtFecDevuelto.Location = New System.Drawing.Point(373, 14)
        Me.txtFecDevuelto.Name = "txtFecDevuelto"
        Me.txtFecDevuelto.ReadOnly = True
        Me.txtFecDevuelto.Size = New System.Drawing.Size(99, 20)
        Me.txtFecDevuelto.TabIndex = 18
        Me.txtFecDevuelto.TabStop = False
        Me.txtFecDevuelto.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(280, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 196
        Me.Label6.Text = "Fec. Devuelto"
        '
        'cbDevuelto
        '
        Me.cbDevuelto.AutoSize = True
        Me.cbDevuelto.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.cbDevuelto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbDevuelto.Enabled = False
        Me.cbDevuelto.ForeColor = System.Drawing.Color.Black
        Me.cbDevuelto.Location = New System.Drawing.Point(78, 17)
        Me.cbDevuelto.Name = "cbDevuelto"
        Me.cbDevuelto.Size = New System.Drawing.Size(77, 17)
        Me.cbDevuelto.TabIndex = 17
        Me.cbDevuelto.TabStop = False
        Me.cbDevuelto.Text = "Devuelto"
        Me.cbDevuelto.UseVisualStyleBackColor = False
        '
        'gbDatosDevolucion
        '
        Me.gbDatosDevolucion.Controls.Add(Me.txtFecDevuelto)
        Me.gbDatosDevolucion.Controls.Add(Me.Label6)
        Me.gbDatosDevolucion.Controls.Add(Me.cbDevuelto)
        Me.gbDatosDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosDevolucion.Location = New System.Drawing.Point(8, 285)
        Me.gbDatosDevolucion.Name = "gbDatosDevolucion"
        Me.gbDatosDevolucion.Size = New System.Drawing.Size(552, 40)
        Me.gbDatosDevolucion.TabIndex = 16
        Me.gbDatosDevolucion.Text = "Datos de Devolución"
        Me.gbDatosDevolucion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'frmAsignacionRecurso_Detalle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(576, 368)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbDatosDevolucion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAsignacionRecurso_Detalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación "
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        Me.gbDetalle.PerformLayout()
        CType(Me.gbComunicaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbComunicaciones.ResumeLayout(False)
        Me.gbComunicaciones.PerformLayout()
        CType(Me.cmbEmpCom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosDevolucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosDevolucion.ResumeLayout(False)
        Me.gbDatosDevolucion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDesOtroUso As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDesPlan As System.Windows.Forms.TextBox
    Friend WithEvents cbDevuelto As System.Windows.Forms.CheckBox
    Friend WithEvents lblRubro As System.Windows.Forms.Label
    Friend WithEvents cmbEmpCom As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtFecDevuelto As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNumCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNumRadio As System.Windows.Forms.TextBox
    Friend WithEvents cbUsoPersonal As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTalla As System.Windows.Forms.TextBox
    Friend WithEvents lblSerie As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents gbComunicaciones As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbDatosDevolucion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarActivo As Button
End Class
