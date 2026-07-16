<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProcesador
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcesador))
        Dim cmbMarca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoDispositivo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gbDatosTipoHoraExtra = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnObtener = New System.Windows.Forms.Button()
        Me.txtFecFinGarantia = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbMarca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbTipoDispositivo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.txtMotivoFinUso = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtFecFinUso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecIniUso = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtGeneracionProcesador = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVelocidadProcesador = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTipoProcesador = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerie = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.txtModelo = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtIdProcesador = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDesProcesador = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        CType(Me.gbDatosTipoHoraExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosTipoHoraExtra.SuspendLayout()
        CType(Me.cmbMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoDispositivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(296, 498)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbDatosTipoHoraExtra
        '
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.btnObtener)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtFecFinGarantia)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label12)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cmbMarca)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cmbTipoDispositivo)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label11)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label10)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.cbVigente)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtMotivoFinUso)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label30)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtFecFinUso)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtFecIniUso)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label19)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label20)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtGeneracionProcesador)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label5)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtVelocidadProcesador)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label8)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtTipoProcesador)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label7)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label4)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtSerie)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtModelo)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label2)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label3)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtObservacion)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label6)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.lblFecha)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtIdProcesador)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label1)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.Label9)
        Me.gbDatosTipoHoraExtra.Controls.Add(Me.txtDesProcesador)
        Me.gbDatosTipoHoraExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosTipoHoraExtra.Location = New System.Drawing.Point(12, 12)
        Me.gbDatosTipoHoraExtra.Name = "gbDatosTipoHoraExtra"
        Me.gbDatosTipoHoraExtra.Size = New System.Drawing.Size(562, 468)
        Me.gbDatosTipoHoraExtra.TabIndex = 18
        Me.gbDatosTipoHoraExtra.Text = "Datos del Procesador"
        Me.gbDatosTipoHoraExtra.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnObtener
        '
        Me.btnObtener.Image = CType(resources.GetObject("btnObtener.Image"), System.Drawing.Image)
        Me.btnObtener.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnObtener.Location = New System.Drawing.Point(465, 17)
        Me.btnObtener.Name = "btnObtener"
        Me.btnObtener.Size = New System.Drawing.Size(77, 23)
        Me.btnObtener.TabIndex = 494
        Me.btnObtener.Text = "Obtener"
        Me.btnObtener.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnObtener.UseVisualStyleBackColor = True
        '
        'txtFecFinGarantia
        '
        '
        '
        '
        Me.txtFecFinGarantia.DropDownCalendar.Name = ""
        Me.txtFecFinGarantia.DropDownCalendar.Visible = False
        Me.txtFecFinGarantia.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinGarantia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinGarantia.IsNullDate = True
        Me.txtFecFinGarantia.Location = New System.Drawing.Point(125, 403)
        Me.txtFecFinGarantia.Name = "txtFecFinGarantia"
        Me.txtFecFinGarantia.NullButtonText = "Ninguno"
        Me.txtFecFinGarantia.Size = New System.Drawing.Size(96, 20)
        Me.txtFecFinGarantia.TabIndex = 492
        Me.txtFecFinGarantia.TodayButtonText = "Hoy"
        Me.txtFecFinGarantia.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(25, 405)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 13)
        Me.Label12.TabIndex = 493
        Me.Label12.Text = "F. Fin Garantia"
        '
        'cmbMarca
        '
        Me.cmbMarca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMarca_DesignTimeLayout.LayoutString = resources.GetString("cmbMarca_DesignTimeLayout.LayoutString")
        Me.cmbMarca.DesignTimeLayout = cmbMarca_DesignTimeLayout
        Me.cmbMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarca.Location = New System.Drawing.Point(127, 110)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.SelectedIndex = -1
        Me.cmbMarca.SelectedItem = Nothing
        Me.cmbMarca.Size = New System.Drawing.Size(119, 20)
        Me.cmbMarca.TabIndex = 7
        Me.cmbMarca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbTipoDispositivo
        '
        Me.cmbTipoDispositivo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDispositivo_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDispositivo_DesignTimeLayout.LayoutString")
        Me.cmbTipoDispositivo.DesignTimeLayout = cmbTipoDispositivo_DesignTimeLayout
        Me.cmbTipoDispositivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDispositivo.Location = New System.Drawing.Point(127, 81)
        Me.cmbTipoDispositivo.Name = "cmbTipoDispositivo"
        Me.cmbTipoDispositivo.SelectedIndex = -1
        Me.cmbTipoDispositivo.SelectedItem = Nothing
        Me.cmbTipoDispositivo.Size = New System.Drawing.Size(119, 20)
        Me.cmbTipoDispositivo.TabIndex = 6
        Me.cmbTipoDispositivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(21, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 13)
        Me.Label11.TabIndex = 435
        Me.Label11.Text = "Tipo Dispositivo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(65, 435)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 433
        Me.Label10.Text = "Vigente"
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.BackColor = System.Drawing.Color.Transparent
        Me.cbVigente.Checked = True
        Me.cbVigente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbVigente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVigente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbVigente.Location = New System.Drawing.Point(127, 435)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(15, 14)
        Me.cbVigente.TabIndex = 432
        Me.cbVigente.TabStop = False
        Me.cbVigente.Tag = ""
        Me.cbVigente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbVigente.UseVisualStyleBackColor = False
        '
        'txtMotivoFinUso
        '
        Me.txtMotivoFinUso.Location = New System.Drawing.Point(125, 362)
        Me.txtMotivoFinUso.Multiline = True
        Me.txtMotivoFinUso.Name = "txtMotivoFinUso"
        Me.txtMotivoFinUso.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMotivoFinUso.Size = New System.Drawing.Size(415, 30)
        Me.txtMotivoFinUso.TabIndex = 16
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(24, 369)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(92, 13)
        Me.Label30.TabIndex = 429
        Me.Label30.Text = "Motivo Fin Uso"
        '
        'txtFecFinUso
        '
        '
        '
        '
        Me.txtFecFinUso.DropDownCalendar.Name = ""
        Me.txtFecFinUso.DropDownCalendar.Visible = False
        Me.txtFecFinUso.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinUso.IsNullDate = True
        Me.txtFecFinUso.Location = New System.Drawing.Point(353, 330)
        Me.txtFecFinUso.Name = "txtFecFinUso"
        Me.txtFecFinUso.NullButtonText = "Ninguno"
        Me.txtFecFinUso.ShowNullButton = True
        Me.txtFecFinUso.Size = New System.Drawing.Size(96, 20)
        Me.txtFecFinUso.TabIndex = 15
        Me.txtFecFinUso.TodayButtonText = "Hoy"
        Me.txtFecFinUso.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecIniUso
        '
        '
        '
        '
        Me.txtFecIniUso.DropDownCalendar.Name = ""
        Me.txtFecIniUso.DropDownCalendar.Visible = False
        Me.txtFecIniUso.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecIniUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecIniUso.IsNullDate = True
        Me.txtFecIniUso.Location = New System.Drawing.Point(125, 330)
        Me.txtFecIniUso.Name = "txtFecIniUso"
        Me.txtFecIniUso.NullButtonText = "Ninguno"
        Me.txtFecIniUso.Size = New System.Drawing.Size(96, 20)
        Me.txtFecIniUso.TabIndex = 14
        Me.txtFecIniUso.TodayButtonText = "Hoy"
        Me.txtFecIniUso.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(268, 334)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(79, 13)
        Me.Label19.TabIndex = 427
        Me.Label19.Text = "Fec. Fin Uso"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(35, 334)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 13)
        Me.Label20.TabIndex = 426
        Me.Label20.Text = "Fec. Ini. Uso"
        '
        'txtGeneracionProcesador
        '
        Me.txtGeneracionProcesador.Location = New System.Drawing.Point(125, 250)
        Me.txtGeneracionProcesador.MaxLength = 12
        Me.txtGeneracionProcesador.Name = "txtGeneracionProcesador"
        Me.txtGeneracionProcesador.Size = New System.Drawing.Size(49, 20)
        Me.txtGeneracionProcesador.TabIndex = 12
        Me.txtGeneracionProcesador.Text = "0"
        Me.txtGeneracionProcesador.Value = 0
        Me.txtGeneracionProcesador.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.txtGeneracionProcesador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(188, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 290
        Me.Label5.Text = "Ghz."
        '
        'txtVelocidadProcesador
        '
        Me.txtVelocidadProcesador.Location = New System.Drawing.Point(125, 221)
        Me.txtVelocidadProcesador.MaxLength = 12
        Me.txtVelocidadProcesador.Name = "txtVelocidadProcesador"
        Me.txtVelocidadProcesador.Size = New System.Drawing.Size(60, 20)
        Me.txtVelocidadProcesador.TabIndex = 11
        Me.txtVelocidadProcesador.Text = "0.00"
        Me.txtVelocidadProcesador.Value = 0R
        Me.txtVelocidadProcesador.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        Me.txtVelocidadProcesador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(42, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 287
        Me.Label8.Text = "Veloc. Proc."
        '
        'txtTipoProcesador
        '
        Me.txtTipoProcesador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoProcesador.Location = New System.Drawing.Point(125, 194)
        Me.txtTipoProcesador.Name = "txtTipoProcesador"
        Me.txtTipoProcesador.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTipoProcesador.Size = New System.Drawing.Size(171, 20)
        Me.txtTipoProcesador.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(53, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 285
        Me.Label7.Text = "Tipo Proc."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 254)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 280
        Me.Label4.Text = "Generacion Proc."
        '
        'txtSerie
        '
        Me.txtSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.Location = New System.Drawing.Point(126, 166)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSerie.Size = New System.Drawing.Size(170, 20)
        Me.txtSerie.TabIndex = 9
        '
        'txtModelo
        '
        Me.txtModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelo.Location = New System.Drawing.Point(127, 139)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtModelo.Size = New System.Drawing.Size(169, 20)
        Me.txtModelo.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 276
        Me.Label2.Text = "Marca"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(83, 294)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 275
        Me.Label3.Text = "Nota"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(125, 281)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(417, 39)
        Me.txtObservacion.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(72, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 271
        Me.Label6.Text = "Modelo"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(83, 169)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(36, 13)
        Me.lblFecha.TabIndex = 263
        Me.lblFecha.Text = "Serie"
        '
        'txtIdProcesador
        '
        Me.txtIdProcesador.BackColor = System.Drawing.SystemColors.Control
        Me.txtIdProcesador.ForeColor = System.Drawing.Color.Navy
        Me.txtIdProcesador.Location = New System.Drawing.Point(126, 24)
        Me.txtIdProcesador.MaxLength = 5
        Me.txtIdProcesador.Name = "txtIdProcesador"
        Me.txtIdProcesador.ReadOnly = True
        Me.txtIdProcesador.Size = New System.Drawing.Size(63, 20)
        Me.txtIdProcesador.TabIndex = 1
        Me.txtIdProcesador.TabStop = False
        Me.txtIdProcesador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Código"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(47, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 252
        Me.Label9.Text = "Descripción"
        '
        'txtDesProcesador
        '
        Me.txtDesProcesador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesProcesador.Location = New System.Drawing.Point(127, 51)
        Me.txtDesProcesador.Name = "txtDesProcesador"
        Me.txtDesProcesador.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDesProcesador.Size = New System.Drawing.Size(415, 20)
        Me.txtDesProcesador.TabIndex = 2
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = Global.SIGECOM.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(212, 498)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'frmProcesador
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(607, 543)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gbDatosTipoHoraExtra)
        Me.Controls.Add(Me.btnGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(592, 528)
        Me.Name = "frmProcesador"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procesador"
        CType(Me.gbDatosTipoHoraExtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosTipoHoraExtra.ResumeLayout(False)
        Me.gbDatosTipoHoraExtra.PerformLayout()
        CType(Me.cmbMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoDispositivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents gbDatosTipoHoraExtra As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSerie As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtModelo As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents txtIdProcesador As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDesProcesador As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTipoProcesador As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtVelocidadProcesador As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtGeneracionProcesador As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cbVigente As CheckBox
    Friend WithEvents txtMotivoFinUso As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents txtFecFinUso As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecIniUso As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cmbTipoDispositivo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbMarca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtFecFinGarantia As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label12 As Label
    Friend WithEvents btnObtener As Button
End Class
