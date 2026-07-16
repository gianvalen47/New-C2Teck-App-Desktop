<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepSolicitudGasto
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
        Dim cmbRubroViaje_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoDoc_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbEstado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoGasto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepSolicitudGasto))
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbPlaca_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.gbImprimir = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbExcel = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPantalla = New Janus.Windows.EditControls.UIRadioButton()
        Me.gbPersona = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.txtPersona = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.rbBuscarPersona = New System.Windows.Forms.CheckBox()
        Me.gbGastoViaje = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbRubroViaje = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.rbNoGastoViaje = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbSiGastoViaje = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbGVTodos = New Janus.Windows.EditControls.UIRadioButton()
        Me.cmbTipoDoc = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbProcesoJob = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbNoProcJob = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbSiProcJob = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbTodos = New Janus.Windows.EditControls.UIRadioButton()
        Me.txtArea = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbEstado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbCodArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btnBuscarJob = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodCuenta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumJob = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbTotalizado = New System.Windows.Forms.RadioButton()
        Me.rbDetallado = New System.Windows.Forms.RadioButton()
        Me.gbProveedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rbBuscarProveedor = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.cbFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbTipoGasto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.cmbPlaca = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbImprimir.SuspendLayout()
        CType(Me.gbPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPersona.SuspendLayout()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGastoViaje.SuspendLayout()
        CType(Me.cmbRubroViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProcesoJob.SuspendLayout()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.cmbTipoGasto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(674, 815)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(34, 32)
        Me.DataGridView1.TabIndex = 200
        Me.DataGridView1.Visible = False
        '
        'gbImprimir
        '
        Me.gbImprimir.Controls.Add(Me.rbExcel)
        Me.gbImprimir.Controls.Add(Me.rbPantalla)
        Me.gbImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbImprimir.Location = New System.Drawing.Point(236, 299)
        Me.gbImprimir.Name = "gbImprimir"
        Me.gbImprimir.Size = New System.Drawing.Size(238, 40)
        Me.gbImprimir.TabIndex = 199
        Me.gbImprimir.Text = "Exportar"
        Me.gbImprimir.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbExcel
        '
        Me.rbExcel.Location = New System.Drawing.Point(136, 13)
        Me.rbExcel.Name = "rbExcel"
        Me.rbExcel.Size = New System.Drawing.Size(72, 23)
        Me.rbExcel.TabIndex = 3
        Me.rbExcel.Text = "Excel"
        '
        'rbPantalla
        '
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(54, 13)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(76, 23)
        Me.rbPantalla.TabIndex = 2
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        '
        'gbPersona
        '
        Me.gbPersona.Controls.Add(Me.btnBuscarPersona)
        Me.gbPersona.Controls.Add(Me.txtPersona)
        Me.gbPersona.Controls.Add(Me.Label11)
        Me.gbPersona.Controls.Add(Me.rbBuscarPersona)
        Me.gbPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPersona.Location = New System.Drawing.Point(8, 183)
        Me.gbPersona.Name = "gbPersona"
        Me.gbPersona.Size = New System.Drawing.Size(332, 53)
        Me.gbPersona.TabIndex = 198
        Me.gbPersona.Text = "Buscar Persona"
        Me.gbPersona.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(299, 25)
        Me.btnBuscarPersona.Name = "btnBuscarPersona"
        Me.btnBuscarPersona.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarPersona.TabIndex = 150
        Me.btnBuscarPersona.TabStop = False
        Me.btnBuscarPersona.UseVisualStyleBackColor = True
        '
        'txtPersona
        '
        Me.txtPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersona.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtPersona.Location = New System.Drawing.Point(79, 27)
        Me.txtPersona.MaxLength = 3
        Me.txtPersona.Name = "txtPersona"
        Me.txtPersona.ReadOnly = True
        Me.txtPersona.Size = New System.Drawing.Size(217, 20)
        Me.txtPersona.TabIndex = 18
        Me.txtPersona.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Persona"
        '
        'rbBuscarPersona
        '
        Me.rbBuscarPersona.AutoSize = True
        Me.rbBuscarPersona.Checked = True
        Me.rbBuscarPersona.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbBuscarPersona.Location = New System.Drawing.Point(133, 10)
        Me.rbBuscarPersona.Name = "rbBuscarPersona"
        Me.rbBuscarPersona.Size = New System.Drawing.Size(108, 17)
        Me.rbBuscarPersona.TabIndex = 17
        Me.rbBuscarPersona.TabStop = False
        Me.rbBuscarPersona.Text = "Todo Personal"
        Me.rbBuscarPersona.UseVisualStyleBackColor = True
        '
        'gbGastoViaje
        '
        Me.gbGastoViaje.Controls.Add(Me.cmbRubroViaje)
        Me.gbGastoViaje.Controls.Add(Me.rbNoGastoViaje)
        Me.gbGastoViaje.Controls.Add(Me.rbSiGastoViaje)
        Me.gbGastoViaje.Controls.Add(Me.rbGVTodos)
        Me.gbGastoViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGastoViaje.Location = New System.Drawing.Point(510, 183)
        Me.gbGastoViaje.Name = "gbGastoViaje"
        Me.gbGastoViaje.Size = New System.Drawing.Size(195, 112)
        Me.gbGastoViaje.TabIndex = 197
        Me.gbGastoViaje.Text = "Gastos Viaje"
        Me.gbGastoViaje.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbRubroViaje
        '
        Me.cmbRubroViaje.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbRubroViaje_DesignTimeLayout.LayoutString = resources.GetString("cmbRubroViaje_DesignTimeLayout.LayoutString")
        Me.cmbRubroViaje.DesignTimeLayout = cmbRubroViaje_DesignTimeLayout
        Me.cmbRubroViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRubroViaje.Location = New System.Drawing.Point(41, 59)
        Me.cmbRubroViaje.Name = "cmbRubroViaje"
        Me.cmbRubroViaje.SelectedIndex = -1
        Me.cmbRubroViaje.SelectedItem = Nothing
        Me.cmbRubroViaje.Size = New System.Drawing.Size(138, 20)
        Me.cmbRubroViaje.TabIndex = 199
        Me.cmbRubroViaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'rbNoGastoViaje
        '
        Me.rbNoGastoViaje.AutoSize = True
        Me.rbNoGastoViaje.Location = New System.Drawing.Point(17, 88)
        Me.rbNoGastoViaje.Name = "rbNoGastoViaje"
        Me.rbNoGastoViaje.Size = New System.Drawing.Size(102, 17)
        Me.rbNoGastoViaje.TabIndex = 3
        Me.rbNoGastoViaje.Text = "No Gasto Viaje"
        '
        'rbSiGastoViaje
        '
        Me.rbSiGastoViaje.AutoSize = True
        Me.rbSiGastoViaje.Location = New System.Drawing.Point(17, 43)
        Me.rbSiGastoViaje.Name = "rbSiGastoViaje"
        Me.rbSiGastoViaje.Size = New System.Drawing.Size(82, 17)
        Me.rbSiGastoViaje.TabIndex = 2
        Me.rbSiGastoViaje.Text = "Gasto Viaje"
        '
        'rbGVTodos
        '
        Me.rbGVTodos.AutoSize = True
        Me.rbGVTodos.Checked = True
        Me.rbGVTodos.Location = New System.Drawing.Point(17, 19)
        Me.rbGVTodos.Name = "rbGVTodos"
        Me.rbGVTodos.Size = New System.Drawing.Size(52, 17)
        Me.rbGVTodos.TabIndex = 1
        Me.rbGVTodos.TabStop = True
        Me.rbGVTodos.Text = "Todos"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoDoc_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoDoc_DesignTimeLayout.LayoutString")
        Me.cmbTipoDoc.DesignTimeLayout = cmbTipoDoc_DesignTimeLayout
        Me.cmbTipoDoc.Location = New System.Drawing.Point(345, 125)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.SelectedIndex = -1
        Me.cmbTipoDoc.SelectedItem = Nothing
        Me.cmbTipoDoc.Size = New System.Drawing.Size(94, 20)
        Me.cmbTipoDoc.TabIndex = 196
        Me.cmbTipoDoc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(279, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 195
        Me.Label10.Text = "Tipo Doc :"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(345, 155)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(361, 20)
        Me.txtDescripcion.TabIndex = 194
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(261, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 193
        Me.Label3.Text = "Descripción :"
        '
        'gbProcesoJob
        '
        Me.gbProcesoJob.Controls.Add(Me.rbNoProcJob)
        Me.gbProcesoJob.Controls.Add(Me.rbSiProcJob)
        Me.gbProcesoJob.Controls.Add(Me.rbTodos)
        Me.gbProcesoJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProcesoJob.Location = New System.Drawing.Point(351, 183)
        Me.gbProcesoJob.Name = "gbProcesoJob"
        Me.gbProcesoJob.Size = New System.Drawing.Size(148, 112)
        Me.gbProcesoJob.TabIndex = 111
        Me.gbProcesoJob.Text = "Proceso OT"
        Me.gbProcesoJob.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbNoProcJob
        '
        Me.rbNoProcJob.AutoSize = True
        Me.rbNoProcJob.Location = New System.Drawing.Point(20, 78)
        Me.rbNoProcJob.Name = "rbNoProcJob"
        Me.rbNoProcJob.Size = New System.Drawing.Size(102, 17)
        Me.rbNoProcJob.TabIndex = 3
        Me.rbNoProcJob.Text = "No Proc. al OT"
        '
        'rbSiProcJob
        '
        Me.rbSiProcJob.AutoSize = True
        Me.rbSiProcJob.Location = New System.Drawing.Point(20, 51)
        Me.rbSiProcJob.Name = "rbSiProcJob"
        Me.rbSiProcJob.Size = New System.Drawing.Size(82, 17)
        Me.rbSiProcJob.TabIndex = 2
        Me.rbSiProcJob.Text = "Proc. al OT"
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Checked = True
        Me.rbTodos.Location = New System.Drawing.Point(20, 24)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(52, 17)
        Me.rbTodos.TabIndex = 1
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        '
        'txtArea
        '
        Me.txtArea.AutoSize = True
        Me.txtArea.ForeColor = System.Drawing.Color.Red
        Me.txtArea.Location = New System.Drawing.Point(59, 78)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(0, 13)
        Me.txtArea.TabIndex = 192
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Location = New System.Drawing.Point(469, 94)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(54, 20)
        Me.cmbMoneda.TabIndex = 191
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbEstado
        '
        Me.cmbEstado.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbEstado_DesignTimeLayout.LayoutString = resources.GetString("cmbEstado_DesignTimeLayout.LayoutString")
        Me.cmbEstado.DesignTimeLayout = cmbEstado_DesignTimeLayout
        Me.cmbEstado.Location = New System.Drawing.Point(596, 94)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedIndex = -1
        Me.cmbEstado.SelectedItem = Nothing
        Me.cmbEstado.Size = New System.Drawing.Size(110, 20)
        Me.cmbEstado.TabIndex = 190
        Me.cmbEstado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbCodArea
        '
        Me.cmbCodArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodArea_DesignTimeLayout.LayoutString = resources.GetString("cmbCodArea_DesignTimeLayout.LayoutString")
        Me.cmbCodArea.DesignTimeLayout = cmbCodArea_DesignTimeLayout
        Me.cmbCodArea.Location = New System.Drawing.Point(56, 94)
        Me.cmbCodArea.Name = "cmbCodArea"
        Me.cmbCodArea.SelectedIndex = -1
        Me.cmbCodArea.SelectedItem = Nothing
        Me.cmbCodArea.Size = New System.Drawing.Size(109, 20)
        Me.cmbCodArea.TabIndex = 186
        Me.cmbCodArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnBuscarJob
        '
        Me.btnBuscarJob.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarJob.Location = New System.Drawing.Point(96, 124)
        Me.btnBuscarJob.Name = "btnBuscarJob"
        Me.btnBuscarJob.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarJob.TabIndex = 149
        Me.btnBuscarJob.TabStop = False
        Me.btnBuscarJob.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(448, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = "Doc :"
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuenta.Location = New System.Drawing.Point(208, 125)
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Size = New System.Drawing.Size(64, 20)
        Me.txtCodCuenta.TabIndex = 147
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(127, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 146
        Me.Label8.Text = "Cod Cuenta :"
        '
        'txtDocumento
        '
        Me.txtDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumento.Location = New System.Drawing.Point(485, 125)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(74, 20)
        Me.txtDocumento.TabIndex = 145
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 144
        Me.Label7.Text = "OT :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(407, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "Moneda :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(540, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 140
        Me.Label4.Text = "Estado :"
        '
        'txtNumJob
        '
        Me.txtNumJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJob.Location = New System.Drawing.Point(40, 125)
        Me.txtNumJob.Name = "txtNumJob"
        Me.txtNumJob.Size = New System.Drawing.Size(55, 20)
        Me.txtNumJob.TabIndex = 139
        Me.txtNumJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "Area :"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(284, 358)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 27)
        Me.btnAceptar.TabIndex = 120
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
        Me.btnCancelar.Location = New System.Drawing.Point(366, 358)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 27)
        Me.btnCancelar.TabIndex = 121
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.Controls.Add(Me.rbTotalizado)
        Me.UiGroupBox1.Controls.Add(Me.rbDetallado)
        Me.UiGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox1.Location = New System.Drawing.Point(256, 10)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(199, 40)
        Me.UiGroupBox1.TabIndex = 111
        Me.UiGroupBox1.Text = "Tipo"
        Me.UiGroupBox1.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbTotalizado
        '
        Me.rbTotalizado.AutoSize = True
        Me.rbTotalizado.Checked = True
        Me.rbTotalizado.Location = New System.Drawing.Point(13, 15)
        Me.rbTotalizado.Name = "rbTotalizado"
        Me.rbTotalizado.Size = New System.Drawing.Size(84, 17)
        Me.rbTotalizado.TabIndex = 1
        Me.rbTotalizado.TabStop = True
        Me.rbTotalizado.Text = "Totalizado"
        Me.rbTotalizado.UseVisualStyleBackColor = True
        '
        'rbDetallado
        '
        Me.rbDetallado.AutoSize = True
        Me.rbDetallado.Location = New System.Drawing.Point(114, 15)
        Me.rbDetallado.Name = "rbDetallado"
        Me.rbDetallado.Size = New System.Drawing.Size(79, 17)
        Me.rbDetallado.TabIndex = 15
        Me.rbDetallado.Text = "Detallado"
        Me.rbDetallado.UseVisualStyleBackColor = True
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.btnBuscarProveedor)
        Me.gbProveedor.Controls.Add(Me.txtProveedor)
        Me.gbProveedor.Controls.Add(Me.Label12)
        Me.gbProveedor.Controls.Add(Me.rbBuscarProveedor)
        Me.gbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProveedor.Location = New System.Drawing.Point(8, 242)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(332, 53)
        Me.gbProveedor.TabIndex = 110
        Me.gbProveedor.Text = "Buscar Proveedor"
        Me.gbProveedor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(299, 25)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 150
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'txtProveedor
        '
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(78, 27)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(218, 20)
        Me.txtProveedor.TabIndex = 18
        Me.txtProveedor.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Proveedor"
        '
        'rbBuscarProveedor
        '
        Me.rbBuscarProveedor.AutoSize = True
        Me.rbBuscarProveedor.Checked = True
        Me.rbBuscarProveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbBuscarProveedor.Location = New System.Drawing.Point(132, 10)
        Me.rbBuscarProveedor.Name = "rbBuscarProveedor"
        Me.rbBuscarProveedor.Size = New System.Drawing.Size(117, 17)
        Me.rbBuscarProveedor.TabIndex = 17
        Me.rbBuscarProveedor.TabStop = False
        Me.rbBuscarProveedor.Text = "Todo Proveedor"
        Me.rbBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(402, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Al  :"
        '
        'cbFecFinal
        '
        '
        '
        '
        Me.cbFecFinal.DropDownCalendar.Name = ""
        Me.cbFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecFinal.Location = New System.Drawing.Point(434, 59)
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
        Me.cbFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFecInicio.Location = New System.Drawing.Point(277, 59)
        Me.cbFecInicio.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.cbFecInicio.Name = "cbFecInicio"
        Me.cbFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.cbFecInicio.TabIndex = 1
        Me.cbFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(180, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = " Fechas   Del : "
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.Controls.Add(Me.Label23)
        Me.UiGroupBox2.Controls.Add(Me.cmbTipoGasto)
        Me.UiGroupBox2.Controls.Add(Me.Label26)
        Me.UiGroupBox2.Controls.Add(Me.cmbCentroCosto)
        Me.UiGroupBox2.Controls.Add(Me.cmbPlaca)
        Me.UiGroupBox2.Controls.Add(Me.Label17)
        Me.UiGroupBox2.Controls.Add(Me.UiGroupBox1)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.gbImprimir)
        Me.UiGroupBox2.Controls.Add(Me.txtCodCuenta)
        Me.UiGroupBox2.Controls.Add(Me.txtDocumento)
        Me.UiGroupBox2.Controls.Add(Me.gbPersona)
        Me.UiGroupBox2.Controls.Add(Me.Label9)
        Me.UiGroupBox2.Controls.Add(Me.Label1)
        Me.UiGroupBox2.Controls.Add(Me.Label7)
        Me.UiGroupBox2.Controls.Add(Me.gbGastoViaje)
        Me.UiGroupBox2.Controls.Add(Me.btnBuscarJob)
        Me.UiGroupBox2.Controls.Add(Me.cbFecInicio)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Controls.Add(Me.cmbTipoDoc)
        Me.UiGroupBox2.Controls.Add(Me.cmbCodArea)
        Me.UiGroupBox2.Controls.Add(Me.cbFecFinal)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.Label10)
        Me.UiGroupBox2.Controls.Add(Me.cmbEstado)
        Me.UiGroupBox2.Controls.Add(Me.Label6)
        Me.UiGroupBox2.Controls.Add(Me.txtNumJob)
        Me.UiGroupBox2.Controls.Add(Me.txtDescripcion)
        Me.UiGroupBox2.Controls.Add(Me.cmbMoneda)
        Me.UiGroupBox2.Controls.Add(Me.gbProveedor)
        Me.UiGroupBox2.Controls.Add(Me.Label2)
        Me.UiGroupBox2.Controls.Add(Me.Label3)
        Me.UiGroupBox2.Controls.Add(Me.txtArea)
        Me.UiGroupBox2.Controls.Add(Me.gbProcesoJob)
        Me.UiGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiGroupBox2.Location = New System.Drawing.Point(8, 4)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(713, 348)
        Me.UiGroupBox2.TabIndex = 201
        Me.UiGroupBox2.Text = "Datos de Reporte"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 158)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 13)
        Me.Label23.TabIndex = 288
        Me.Label23.Text = "Tipo Gasto :"
        '
        'cmbTipoGasto
        '
        Me.cmbTipoGasto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoGasto_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoGasto_DesignTimeLayout.LayoutString")
        Me.cmbTipoGasto.DesignTimeLayout = cmbTipoGasto_DesignTimeLayout
        Me.cmbTipoGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoGasto.Location = New System.Drawing.Point(86, 155)
        Me.cmbTipoGasto.Name = "cmbTipoGasto"
        Me.cmbTipoGasto.SelectedIndex = -1
        Me.cmbTipoGasto.SelectedItem = Nothing
        Me.cmbTipoGasto.Size = New System.Drawing.Size(163, 20)
        Me.cmbTipoGasto.TabIndex = 287
        Me.cmbTipoGasto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(181, 97)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(88, 13)
        Me.Label26.TabIndex = 246
        Me.Label26.Text = "Centro Costo :"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(271, 94)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(120, 20)
        Me.cmbCentroCosto.TabIndex = 245
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbPlaca
        '
        Me.cmbPlaca.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbPlaca_DesignTimeLayout.LayoutString = resources.GetString("cmbPlaca_DesignTimeLayout.LayoutString")
        Me.cmbPlaca.DesignTimeLayout = cmbPlaca_DesignTimeLayout
        Me.cmbPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlaca.Location = New System.Drawing.Point(614, 125)
        Me.cmbPlaca.Name = "cmbPlaca"
        Me.cmbPlaca.SelectedIndex = -1
        Me.cmbPlaca.SelectedItem = Nothing
        Me.cmbPlaca.Size = New System.Drawing.Size(92, 20)
        Me.cmbPlaca.TabIndex = 243
        Me.cmbPlaca.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(568, 129)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 244
        Me.Label17.Text = "Placa :"
        '
        'frmRepSolicitudGasto
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(745, 406)
        Me.Controls.Add(Me.UiGroupBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepSolicitudGasto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Solicitud de Gasto"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbImprimir.ResumeLayout(False)
        CType(Me.gbPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPersona.ResumeLayout(False)
        Me.gbPersona.PerformLayout()
        CType(Me.gbGastoViaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGastoViaje.ResumeLayout(False)
        Me.gbGastoViaje.PerformLayout()
        CType(Me.cmbRubroViaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbProcesoJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProcesoJob.ResumeLayout(False)
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.cmbTipoGasto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumJob As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbTotalizado As System.Windows.Forms.RadioButton
    Friend WithEvents rbDetallado As System.Windows.Forms.RadioButton
    Friend WithEvents gbProveedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rbBuscarProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarJob As System.Windows.Forms.Button
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents cmbCodArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbEstado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtArea As System.Windows.Forms.Label
    Friend WithEvents gbProcesoJob As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbTodos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbNoProcJob As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbSiProcJob As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbGastoViaje As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbNoGastoViaje As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbSiGastoViaje As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbGVTodos As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents gbPersona As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents txtPersona As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rbBuscarPersona As System.Windows.Forms.CheckBox
    Friend WithEvents cmbRubroViaje As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents gbImprimir As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbExcel As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPantalla As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbPlaca As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoGasto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
