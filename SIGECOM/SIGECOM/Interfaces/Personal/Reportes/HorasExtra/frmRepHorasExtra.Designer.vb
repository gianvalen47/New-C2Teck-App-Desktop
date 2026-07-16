<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepHorasExtra
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
        Dim cmbUbicacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepHorasExtra))
        Dim cmbPerAutoriza_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbClase_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox()
        Me.gbTipo = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbHrsCompensdas = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbExportar = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbResumen = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbDetallado = New Janus.Windows.EditControls.UIRadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbUbicacion = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbPerAutoriza = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.gbPersona = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.chkColaborador = New System.Windows.Forms.CheckBox()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbClase = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptarE = New System.Windows.Forms.Button()
        Me.dgvDatosExcel = New System.Windows.Forms.DataGridView()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipo.SuspendLayout()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPerAutoriza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPersona.SuspendLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDatosExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.gbTipo)
        Me.gbDatos.Controls.Add(Me.Label2)
        Me.gbDatos.Controls.Add(Me.cmbUbicacion)
        Me.gbDatos.Controls.Add(Me.btnBuscarJob)
        Me.gbDatos.Controls.Add(Me.txtNumJob)
        Me.gbDatos.Controls.Add(Me.Label14)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.cmbPerAutoriza)
        Me.gbDatos.Controls.Add(Me.gbPersona)
        Me.gbDatos.Controls.Add(Me.cmbArea)
        Me.gbDatos.Controls.Add(Me.cmbCentroCosto)
        Me.gbDatos.Controls.Add(Me.Label32)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.cmbClase)
        Me.gbDatos.Controls.Add(Me.Label21)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.txtFecFinal)
        Me.gbDatos.Controls.Add(Me.txtFecInicio)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(7, 4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(483, 257)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.Text = "Datos de Reporte"
        Me.gbDatos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbTipo
        '
        Me.gbTipo.Controls.Add(Me.rbHrsCompensdas)
        Me.gbTipo.Controls.Add(Me.rbExportar)
        Me.gbTipo.Controls.Add(Me.rbResumen)
        Me.gbTipo.Controls.Add(Me.rbDetallado)
        Me.gbTipo.Location = New System.Drawing.Point(36, 208)
        Me.gbTipo.Name = "gbTipo"
        Me.gbTipo.Size = New System.Drawing.Size(411, 38)
        Me.gbTipo.TabIndex = 13
        Me.gbTipo.Text = "Tipo"
        Me.gbTipo.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbHrsCompensdas
        '
        Me.rbHrsCompensdas.Location = New System.Drawing.Point(190, 13)
        Me.rbHrsCompensdas.Name = "rbHrsCompensdas"
        Me.rbHrsCompensdas.Size = New System.Drawing.Size(128, 18)
        Me.rbHrsCompensdas.TabIndex = 16
        Me.rbHrsCompensdas.Text = "Hrs. Compensadas"
        '
        'rbExportar
        '
        Me.rbExportar.Location = New System.Drawing.Point(329, 13)
        Me.rbExportar.Name = "rbExportar"
        Me.rbExportar.Size = New System.Drawing.Size(67, 18)
        Me.rbExportar.TabIndex = 17
        Me.rbExportar.Text = "Exportar"
        '
        'rbResumen
        '
        Me.rbResumen.Location = New System.Drawing.Point(103, 13)
        Me.rbResumen.Name = "rbResumen"
        Me.rbResumen.Size = New System.Drawing.Size(76, 18)
        Me.rbResumen.TabIndex = 15
        Me.rbResumen.Text = "Resumen"
        '
        'rbDetallado
        '
        Me.rbDetallado.Checked = True
        Me.rbDetallado.Location = New System.Drawing.Point(15, 13)
        Me.rbDetallado.Name = "rbDetallado"
        Me.rbDetallado.Size = New System.Drawing.Size(76, 18)
        Me.rbDetallado.TabIndex = 14
        Me.rbDetallado.TabStop = True
        Me.rbDetallado.Text = "Detallado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(302, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 355
        Me.Label2.Text = "Ubicación"
        '
        'cmbUbicacion
        '
        Me.cmbUbicacion.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbUbicacion_DesignTimeLayout.LayoutString = resources.GetString("cmbUbicacion_DesignTimeLayout.LayoutString")
        Me.cmbUbicacion.DesignTimeLayout = cmbUbicacion_DesignTimeLayout
        Me.cmbUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacion.Location = New System.Drawing.Point(369, 148)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.SelectedIndex = -1
        Me.cmbUbicacion.SelectedItem = Nothing
        Me.cmbUbicacion.Size = New System.Drawing.Size(102, 20)
        Me.cmbUbicacion.TabIndex = 11
        Me.cmbUbicacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.cmbUbicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(269, 147)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 10
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'txtNumJob
        '
        Me.txtNumJob.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNumJob.Location = New System.Drawing.Point(215, 148)
        Me.txtNumJob.MaxLength = 20
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(55, 20)
        Me.txtNumJob.TabIndex = 9
        Me.txtNumJob.Tag = ""
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(166, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 353
        Me.Label14.Text = "Nº Job"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 186)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 352
        Me.Label8.Text = "Autoriza"
        '
        'cmbPerAutoriza
        '
        Me.cmbPerAutoriza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbPerAutoriza.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPerAutoriza_DesignTimeLayout.LayoutString = resources.GetString("cmbPerAutoriza_DesignTimeLayout.LayoutString")
        Me.cmbPerAutoriza.DesignTimeLayout = cmbPerAutoriza_DesignTimeLayout
        Me.cmbPerAutoriza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPerAutoriza.Location = New System.Drawing.Point(63, 182)
        Me.cmbPerAutoriza.Name = "cmbPerAutoriza"
        Me.cmbPerAutoriza.SelectedIndex = -1
        Me.cmbPerAutoriza.SelectedItem = Nothing
        Me.cmbPerAutoriza.Size = New System.Drawing.Size(314, 20)
        Me.cmbPerAutoriza.TabIndex = 12
        Me.cmbPerAutoriza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbPerAutoriza.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbPersona
        '
        Me.gbPersona.Controls.Add(Me.btnBuscarPersona)
        Me.gbPersona.Controls.Add(Me.txtColaborador)
        Me.gbPersona.Controls.Add(Me.lblColaborador)
        Me.gbPersona.Controls.Add(Me.chkColaborador)
        Me.gbPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPersona.Location = New System.Drawing.Point(36, 48)
        Me.gbPersona.Name = "gbPersona"
        Me.gbPersona.Size = New System.Drawing.Size(411, 57)
        Me.gbPersona.TabIndex = 3
        Me.gbPersona.Text = "Buscar Persona"
        Me.gbPersona.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(368, 29)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersona.TabIndex = 5
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'txtColaborador
        '
        Me.txtColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColaborador.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtColaborador.Location = New System.Drawing.Point(101, 31)
        Me.txtColaborador.MaxLength = 3
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(264, 20)
        Me.txtColaborador.TabIndex = 4
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Location = New System.Drawing.Point(20, 34)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(75, 13)
        Me.lblColaborador.TabIndex = 20
        Me.lblColaborador.Text = "Colaborador"
        '
        'chkColaborador
        '
        Me.chkColaborador.AutoSize = True
        Me.chkColaborador.Checked = True
        Me.chkColaborador.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkColaborador.Location = New System.Drawing.Point(157, 12)
        Me.chkColaborador.Name = "chkColaborador"
        Me.chkColaborador.Size = New System.Drawing.Size(166, 17)
        Me.chkColaborador.TabIndex = 17
        Me.chkColaborador.TabStop = False
        Me.chkColaborador.Text = "Todos los Colaboradores"
        Me.chkColaborador.UseVisualStyleBackColor = True
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(63, 115)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(121, 20)
        Me.cmbArea.TabIndex = 6
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(283, 115)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(189, 20)
        Me.cmbCentroCosto.TabIndex = 7
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(201, 118)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 13)
        Me.Label32.TabIndex = 348
        Me.Label32.Text = "Centro Costo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(27, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 347
        Me.Label9.Text = "Área"
        '
        'cmbClase
        '
        Me.cmbClase.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbClase_DesignTimeLayout.LayoutString = resources.GetString("cmbClase_DesignTimeLayout.LayoutString")
        Me.cmbClase.DesignTimeLayout = cmbClase_DesignTimeLayout
        Me.cmbClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClase.Location = New System.Drawing.Point(63, 148)
        Me.cmbClase.Name = "cmbClase"
        Me.cmbClase.SelectedIndex = -1
        Me.cmbClase.SelectedItem = Nothing
        Me.cmbClase.Size = New System.Drawing.Size(89, 20)
        Me.cmbClase.TabIndex = 8
        Me.cmbClase.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(22, 152)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 13)
        Me.Label21.TabIndex = 346
        Me.Label21.Text = "Clase"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(283, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 341
        Me.Label6.Text = "Al :"
        '
        'txtFecFinal
        '
        '
        '
        '
        Me.txtFecFinal.DropDownCalendar.Name = ""
        Me.txtFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecFinal.Location = New System.Drawing.Point(315, 22)
        Me.txtFecFinal.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFecFinal.Name = "txtFecFinal"
        Me.txtFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.txtFecFinal.TabIndex = 2
        Me.txtFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecInicio
        '
        '
        '
        '
        Me.txtFecInicio.DropDownCalendar.Name = ""
        Me.txtFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecInicio.Location = New System.Drawing.Point(167, 22)
        Me.txtFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.txtFecInicio.TabIndex = 1
        Me.txtFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 340
        Me.Label1.Text = " Fechas   Del :"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(169, 267)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(77, 27)
        Me.btnAceptar.TabIndex = 18
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.SIGECOM.My.Resources.Resources.Cerrar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(252, 267)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 27)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptarE
        '
        Me.btnAceptarE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarE.Image = Global.SIGECOM.My.Resources.Resources.excel_ico
        Me.btnAceptarE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarE.Location = New System.Drawing.Point(169, 267)
        Me.btnAceptarE.Name = "btnAceptarE"
        Me.btnAceptarE.Size = New System.Drawing.Size(77, 27)
        Me.btnAceptarE.TabIndex = 18
        Me.btnAceptarE.Text = "Aceptar"
        Me.btnAceptarE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptarE.UseVisualStyleBackColor = True
        Me.btnAceptarE.Visible = False
        '
        'dgvDatosExcel
        '
        Me.dgvDatosExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatosExcel.Location = New System.Drawing.Point(362, 270)
        Me.dgvDatosExcel.Name = "dgvDatosExcel"
        Me.dgvDatosExcel.Size = New System.Drawing.Size(108, 24)
        Me.dgvDatosExcel.TabIndex = 19
        Me.dgvDatosExcel.Visible = False
        '
        'frmRepHorasExtra
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(498, 300)
        Me.Controls.Add(Me.dgvDatosExcel)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gbDatos)
        Me.Controls.Add(Me.btnAceptarE)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepHorasExtra"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Horas Extra"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.gbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipo.ResumeLayout(False)
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPerAutoriza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPersona.ResumeLayout(False)
        Me.gbPersona.PerformLayout()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbClase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDatosExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbPersona As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents chkColaborador As System.Windows.Forms.CheckBox
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbClase As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbPerAutoriza As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbUbicacion As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbTipo As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbResumen As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbDetallado As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbExportar As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents btnAceptarE As System.Windows.Forms.Button
    Friend WithEvents dgvDatosExcel As System.Windows.Forms.DataGridView
    Friend WithEvents rbHrsCompensdas As Janus.Windows.EditControls.UIRadioButton
End Class
