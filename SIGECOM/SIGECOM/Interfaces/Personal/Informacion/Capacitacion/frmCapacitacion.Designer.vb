<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapacitacion
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
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapacitacion))
        Dim cmbTipoCapac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbDatosCapacitacion = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtNota = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInstructor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarColaborador = New System.Windows.Forms.Button()
        Me.cbEvaluadoCapac = New System.Windows.Forms.CheckBox()
        Me.txtFecEvaluacionCapac = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDuracionCapac = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMesesEvaluarCapac = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCostoCapac = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblCostoCapac = New System.Windows.Forms.Label()
        Me.lblDuracionCapac = New System.Windows.Forms.Label()
        Me.btnAgregarProveedor = New Janus.Windows.EditControls.UIButton()
        Me.lblProveedorCapac = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.cbProgramadoCapac = New System.Windows.Forms.CheckBox()
        Me.lblCursoCapac = New System.Windows.Forms.Label()
        Me.txtCursoCapac = New System.Windows.Forms.TextBox()
        Me.cmbTipoCapac = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lblTipoCapac = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtObservacion = New Janus.Windows.GridEX.EditControls.EditBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFechaFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label15 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosCapacitacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosCapacitacion.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoCapac, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnCancelar.Location = New System.Drawing.Point(287, 287)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 21
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
        Me.btnGuardar.Location = New System.Drawing.Point(204, 287)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 25)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'gbDatosCapacitacion
        '
        Me.gbDatosCapacitacion.Controls.Add(Me.txtNota)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label2)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtInstructor)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label1)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtColaborador)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label3)
        Me.gbDatosCapacitacion.Controls.Add(Me.btnBuscarColaborador)
        Me.gbDatosCapacitacion.Controls.Add(Me.cbEvaluadoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtFecEvaluacionCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.cmbMoneda)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label16)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label10)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtDuracionCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label11)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtMesesEvaluarCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label12)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtCostoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.lblCostoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.lblDuracionCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.btnAgregarProveedor)
        Me.gbDatosCapacitacion.Controls.Add(Me.lblProveedorCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtProveedor)
        Me.gbDatosCapacitacion.Controls.Add(Me.btnBuscarProveedor)
        Me.gbDatosCapacitacion.Controls.Add(Me.cbProgramadoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.lblCursoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtCursoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.cmbTipoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.lblTipoCapac)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label13)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtObservacion)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label14)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtFechaFinal)
        Me.gbDatosCapacitacion.Controls.Add(Me.txtFechaInicio)
        Me.gbDatosCapacitacion.Controls.Add(Me.Label15)
        Me.gbDatosCapacitacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosCapacitacion.Location = New System.Drawing.Point(9, 5)
        Me.gbDatosCapacitacion.Name = "gbDatosCapacitacion"
        Me.gbDatosCapacitacion.Size = New System.Drawing.Size(553, 276)
        Me.gbDatosCapacitacion.TabIndex = 0
        Me.gbDatosCapacitacion.Text = "Datos de Capacitación"
        Me.gbDatosCapacitacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtNota
        '
        Me.txtNota.DecimalDigits = 2
        Me.txtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNota.Location = New System.Drawing.Point(474, 174)
        Me.txtNota.MaxLength = 10
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(65, 20)
        Me.txtNota.TabIndex = 15
        Me.txtNota.Text = "0.00"
        Me.txtNota.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtNota.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(434, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 361
        Me.Label2.Text = "Nota"
        '
        'txtInstructor
        '
        Me.txtInstructor.BackColor = System.Drawing.SystemColors.Window
        Me.txtInstructor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInstructor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructor.Location = New System.Drawing.Point(95, 174)
        Me.txtInstructor.Name = "txtInstructor"
        Me.txtInstructor.Size = New System.Drawing.Size(299, 20)
        Me.txtInstructor.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 177)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 359
        Me.Label1.Text = "Instructor"
        '
        'txtColaborador
        '
        Me.txtColaborador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColaborador.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtColaborador.Location = New System.Drawing.Point(95, 23)
        Me.txtColaborador.MaxLength = 3
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(350, 20)
        Me.txtColaborador.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 357
        Me.Label3.Text = "Colaborador"
        '
        'btnBuscarColaborador
        '
        Me.btnBuscarColaborador.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarColaborador.Location = New System.Drawing.Point(448, 21)
        Me.btnBuscarColaborador.Name = "btnBuscarColaborador"
        Me.btnBuscarColaborador.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarColaborador.TabIndex = 2
        Me.btnBuscarColaborador.TabStop = False
        Me.btnBuscarColaborador.UseVisualStyleBackColor = True
        '
        'cbEvaluadoCapac
        '
        Me.cbEvaluadoCapac.AutoSize = True
        Me.cbEvaluadoCapac.BackColor = System.Drawing.Color.Transparent
        Me.cbEvaluadoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEvaluadoCapac.Location = New System.Drawing.Point(251, 206)
        Me.cbEvaluadoCapac.Name = "cbEvaluadoCapac"
        Me.cbEvaluadoCapac.Size = New System.Drawing.Size(79, 17)
        Me.cbEvaluadoCapac.TabIndex = 17
        Me.cbEvaluadoCapac.Text = "Evaluado"
        Me.cbEvaluadoCapac.UseVisualStyleBackColor = False
        '
        'txtFecEvaluacionCapac
        '
        Me.txtFecEvaluacionCapac.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtFecEvaluacionCapac.DropDownCalendar.Name = ""
        Me.txtFecEvaluacionCapac.DropDownCalendar.Visible = False
        Me.txtFecEvaluacionCapac.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecEvaluacionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecEvaluacionCapac.IsNullDate = True
        Me.txtFecEvaluacionCapac.Location = New System.Drawing.Point(448, 204)
        Me.txtFecEvaluacionCapac.Name = "txtFecEvaluacionCapac"
        Me.txtFecEvaluacionCapac.NullButtonText = "Ninguno"
        Me.txtFecEvaluacionCapac.ReadOnly = True
        Me.txtFecEvaluacionCapac.ShowNullButton = True
        Me.txtFecEvaluacionCapac.Size = New System.Drawing.Size(91, 20)
        Me.txtFecEvaluacionCapac.TabIndex = 18
        Me.txtFecEvaluacionCapac.TodayButtonText = "Hoy"
        Me.txtFecEvaluacionCapac.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(354, 114)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(55, 20)
        Me.cmbMoneda.TabIndex = 9
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(348, 207)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 13)
        Me.Label16.TabIndex = 350
        Me.Label16.Text = "Fec. Evaluación"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(299, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 354
        Me.Label10.Text = "Moneda"
        '
        'txtDuracionCapac
        '
        Me.txtDuracionCapac.BackColor = System.Drawing.SystemColors.Window
        Me.txtDuracionCapac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDuracionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuracionCapac.Location = New System.Drawing.Point(95, 114)
        Me.txtDuracionCapac.Name = "txtDuracionCapac"
        Me.txtDuracionCapac.Size = New System.Drawing.Size(185, 20)
        Me.txtDuracionCapac.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(185, 207)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 353
        Me.Label11.Text = "meses"
        '
        'txtMesesEvaluarCapac
        '
        Me.txtMesesEvaluarCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesesEvaluarCapac.Location = New System.Drawing.Point(133, 203)
        Me.txtMesesEvaluarCapac.Maximum = 90
        Me.txtMesesEvaluarCapac.MaxLength = 2
        Me.txtMesesEvaluarCapac.Name = "txtMesesEvaluarCapac"
        Me.txtMesesEvaluarCapac.Size = New System.Drawing.Size(50, 20)
        Me.txtMesesEvaluarCapac.TabIndex = 16
        Me.txtMesesEvaluarCapac.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtMesesEvaluarCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(24, 207)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 13)
        Me.Label12.TabIndex = 352
        Me.Label12.Text = "Evaluar dentro de"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCostoCapac
        '
        Me.txtCostoCapac.DecimalDigits = 2
        Me.txtCostoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoCapac.Location = New System.Drawing.Point(474, 114)
        Me.txtCostoCapac.MaxLength = 10
        Me.txtCostoCapac.Name = "txtCostoCapac"
        Me.txtCostoCapac.Size = New System.Drawing.Size(65, 20)
        Me.txtCostoCapac.TabIndex = 10
        Me.txtCostoCapac.Text = "0.00"
        Me.txtCostoCapac.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostoCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblCostoCapac
        '
        Me.lblCostoCapac.AutoSize = True
        Me.lblCostoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblCostoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoCapac.Location = New System.Drawing.Point(432, 118)
        Me.lblCostoCapac.Name = "lblCostoCapac"
        Me.lblCostoCapac.Size = New System.Drawing.Size(39, 13)
        Me.lblCostoCapac.TabIndex = 347
        Me.lblCostoCapac.Text = "Costo"
        '
        'lblDuracionCapac
        '
        Me.lblDuracionCapac.AutoSize = True
        Me.lblDuracionCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblDuracionCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuracionCapac.Location = New System.Drawing.Point(31, 117)
        Me.lblDuracionCapac.Name = "lblDuracionCapac"
        Me.lblDuracionCapac.Size = New System.Drawing.Size(58, 13)
        Me.lblDuracionCapac.TabIndex = 346
        Me.lblDuracionCapac.Text = "Duración"
        '
        'btnAgregarProveedor
        '
        Me.btnAgregarProveedor.Image = CType(resources.GetObject("btnAgregarProveedor.Image"), System.Drawing.Image)
        Me.btnAgregarProveedor.Location = New System.Drawing.Point(474, 144)
        Me.btnAgregarProveedor.Name = "btnAgregarProveedor"
        Me.btnAgregarProveedor.Size = New System.Drawing.Size(23, 21)
        Me.btnAgregarProveedor.TabIndex = 13
        Me.btnAgregarProveedor.TabStop = False
        '
        'lblProveedorCapac
        '
        Me.lblProveedorCapac.AutoSize = True
        Me.lblProveedorCapac.Location = New System.Drawing.Point(23, 147)
        Me.lblProveedorCapac.Name = "lblProveedorCapac"
        Me.lblProveedorCapac.Size = New System.Drawing.Size(65, 13)
        Me.lblProveedorCapac.TabIndex = 342
        Me.lblProveedorCapac.Text = "Proveedor"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Control
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProveedor.Location = New System.Drawing.Point(95, 144)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(350, 20)
        Me.txtProveedor.TabIndex = 11
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(448, 143)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 12
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'cbProgramadoCapac
        '
        Me.cbProgramadoCapac.AutoSize = True
        Me.cbProgramadoCapac.BackColor = System.Drawing.Color.Transparent
        Me.cbProgramadoCapac.Location = New System.Drawing.Point(39, 86)
        Me.cbProgramadoCapac.Name = "cbProgramadoCapac"
        Me.cbProgramadoCapac.Size = New System.Drawing.Size(93, 17)
        Me.cbProgramadoCapac.TabIndex = 5
        Me.cbProgramadoCapac.Text = "Programado"
        Me.cbProgramadoCapac.UseVisualStyleBackColor = False
        '
        'lblCursoCapac
        '
        Me.lblCursoCapac.AutoSize = True
        Me.lblCursoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblCursoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCursoCapac.Location = New System.Drawing.Point(199, 56)
        Me.lblCursoCapac.Name = "lblCursoCapac"
        Me.lblCursoCapac.Size = New System.Drawing.Size(39, 13)
        Me.lblCursoCapac.TabIndex = 333
        Me.lblCursoCapac.Text = "Curso"
        '
        'txtCursoCapac
        '
        Me.txtCursoCapac.BackColor = System.Drawing.SystemColors.Window
        Me.txtCursoCapac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCursoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCursoCapac.Location = New System.Drawing.Point(244, 53)
        Me.txtCursoCapac.Name = "txtCursoCapac"
        Me.txtCursoCapac.Size = New System.Drawing.Size(295, 20)
        Me.txtCursoCapac.TabIndex = 4
        '
        'cmbTipoCapac
        '
        Me.cmbTipoCapac.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoCapac_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoCapac_DesignTimeLayout.LayoutString")
        Me.cmbTipoCapac.DesignTimeLayout = cmbTipoCapac_DesignTimeLayout
        Me.cmbTipoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCapac.Location = New System.Drawing.Point(95, 52)
        Me.cmbTipoCapac.Name = "cmbTipoCapac"
        Me.cmbTipoCapac.SelectedIndex = -1
        Me.cmbTipoCapac.SelectedItem = Nothing
        Me.cmbTipoCapac.Size = New System.Drawing.Size(96, 20)
        Me.cmbTipoCapac.TabIndex = 3
        Me.cmbTipoCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblTipoCapac
        '
        Me.lblTipoCapac.AutoSize = True
        Me.lblTipoCapac.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCapac.Location = New System.Drawing.Point(56, 56)
        Me.lblTipoCapac.Name = "lblTipoCapac"
        Me.lblTipoCapac.Size = New System.Drawing.Size(32, 13)
        Me.lblTipoCapac.TabIndex = 330
        Me.lblTipoCapac.Text = "Tipo"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 240)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 257
        Me.Label13.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(95, 230)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacion.Size = New System.Drawing.Size(444, 34)
        Me.txtObservacion.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(379, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 253
        Me.Label14.Text = "Fec. Final"
        '
        'txtFechaFinal
        '
        '
        '
        '
        Me.txtFechaFinal.DropDownCalendar.Name = ""
        Me.txtFechaFinal.DropDownCalendar.Visible = False
        Me.txtFechaFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFinal.Location = New System.Drawing.Point(448, 83)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.NullButtonText = "Ninguno"
        Me.txtFechaFinal.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaFinal.TabIndex = 7
        Me.txtFechaFinal.TodayButtonText = "Hoy"
        Me.txtFechaFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFechaInicio
        '
        '
        '
        '
        Me.txtFechaInicio.DropDownCalendar.Name = ""
        Me.txtFechaInicio.DropDownCalendar.Visible = False
        Me.txtFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.Location = New System.Drawing.Point(253, 83)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.NullButtonText = "Ninguno"
        Me.txtFechaInicio.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaInicio.TabIndex = 6
        Me.txtFechaInicio.TodayButtonText = "Hoy"
        Me.txtFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(180, 87)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 252
        Me.Label15.Text = "Fec. Inicio"
        '
        'frmCapacitacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(571, 319)
        Me.Controls.Add(Me.gbDatosCapacitacion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapacitacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capacitación de Personal"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosCapacitacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosCapacitacion.ResumeLayout(False)
        Me.gbDatosCapacitacion.PerformLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoCapac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gbDatosCapacitacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDuracionCapac As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMesesEvaluarCapac As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCostoCapac As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblCostoCapac As System.Windows.Forms.Label
    Friend WithEvents lblDuracionCapac As System.Windows.Forms.Label
    Friend WithEvents btnAgregarProveedor As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblProveedorCapac As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents cbProgramadoCapac As System.Windows.Forms.CheckBox
    Friend WithEvents lblCursoCapac As System.Windows.Forms.Label
    Friend WithEvents txtCursoCapac As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoCapac As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lblTipoCapac As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbEvaluadoCapac As System.Windows.Forms.CheckBox
    Friend WithEvents txtFecEvaluacionCapac As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarColaborador As System.Windows.Forms.Button
    Friend WithEvents txtInstructor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNota As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
