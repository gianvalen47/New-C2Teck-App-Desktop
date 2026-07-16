<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCapacitacion
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
        Dim cmbCargo_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCapacitacion))
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbTipoCapac_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox()
        Me.cmbCargo = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbProveedor = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarProveedor = New System.Windows.Forms.Button()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkProveedor = New System.Windows.Forms.CheckBox()
        Me.txtNomCurso = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.gbPersona = New Janus.Windows.EditControls.UIGroupBox()
        Me.btnBuscarPersona = New System.Windows.Forms.Button()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.chkColaborador = New System.Windows.Forms.CheckBox()
        Me.txtFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cmbArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbTipoCapac = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gbImprimir = New Janus.Windows.EditControls.UIGroupBox()
        Me.rbExcel = New Janus.Windows.EditControls.UIRadioButton()
        Me.rbPantalla = New Janus.Windows.EditControls.UIRadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        CType(Me.gbPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPersona.SuspendLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoCapac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbImprimir.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.cmbCargo)
        Me.gbDatos.Controls.Add(Me.Label8)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.gbProveedor)
        Me.gbDatos.Controls.Add(Me.txtNomCurso)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.txtFecFinal)
        Me.gbDatos.Controls.Add(Me.gbPersona)
        Me.gbDatos.Controls.Add(Me.txtFecInicio)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Controls.Add(Me.cmbCentroCosto)
        Me.gbDatos.Controls.Add(Me.Label32)
        Me.gbDatos.Controls.Add(Me.cmbArea)
        Me.gbDatos.Controls.Add(Me.Label9)
        Me.gbDatos.Controls.Add(Me.cmbTipoCapac)
        Me.gbDatos.Controls.Add(Me.Label21)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(8, 4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(501, 258)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.Text = "Datos de Reporte"
        Me.gbDatos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cmbCargo
        '
        Me.cmbCargo.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCargo_DesignTimeLayout.LayoutString = resources.GetString("cmbCargo_DesignTimeLayout.LayoutString")
        Me.cmbCargo.DesignTimeLayout = cmbCargo_DesignTimeLayout
        Me.cmbCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCargo.Location = New System.Drawing.Point(55, 199)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.SelectedIndex = -1
        Me.cmbCargo.SelectedItem = Nothing
        Me.cmbCargo.Size = New System.Drawing.Size(260, 20)
        Me.cmbCargo.TabIndex = 11
        Me.cmbCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 365
        Me.Label8.Text = "Cargo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 279
        Me.Label3.Text = "Curso"
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.btnBuscarProveedor)
        Me.gbProveedor.Controls.Add(Me.txtProveedor)
        Me.gbProveedor.Controls.Add(Me.Label2)
        Me.gbProveedor.Controls.Add(Me.chkProveedor)
        Me.gbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbProveedor.Location = New System.Drawing.Point(27, 107)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(448, 54)
        Me.gbProveedor.TabIndex = 6
        Me.gbProveedor.Text = "Buscar Proveedor"
        Me.gbProveedor.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(400, 26)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(25, 22)
        Me.btnBuscarProveedor.TabIndex = 8
        Me.btnBuscarProveedor.TabStop = False
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'txtProveedor
        '
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txtProveedor.Location = New System.Drawing.Point(100, 28)
        Me.txtProveedor.MaxLength = 3
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(298, 20)
        Me.txtProveedor.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Proveedor"
        '
        'chkProveedor
        '
        Me.chkProveedor.AutoSize = True
        Me.chkProveedor.Checked = True
        Me.chkProveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkProveedor.Location = New System.Drawing.Point(169, 10)
        Me.chkProveedor.Name = "chkProveedor"
        Me.chkProveedor.Size = New System.Drawing.Size(156, 17)
        Me.chkProveedor.TabIndex = 4
        Me.chkProveedor.TabStop = False
        Me.chkProveedor.Text = "Todos los Proveedores"
        Me.chkProveedor.UseVisualStyleBackColor = True
        '
        'txtNomCurso
        '
        Me.txtNomCurso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomCurso.Location = New System.Drawing.Point(55, 229)
        Me.txtNomCurso.Name = "txtNomCurso"
        Me.txtNomCurso.Size = New System.Drawing.Size(435, 20)
        Me.txtNomCurso.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(289, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 363
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
        Me.txtFecFinal.Location = New System.Drawing.Point(321, 20)
        Me.txtFecFinal.MinDate = New Date(2005, 1, 1, 0, 0, 0, 0)
        Me.txtFecFinal.Name = "txtFecFinal"
        Me.txtFecFinal.Size = New System.Drawing.Size(94, 20)
        Me.txtFecFinal.TabIndex = 2
        Me.txtFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'gbPersona
        '
        Me.gbPersona.Controls.Add(Me.btnBuscarPersona)
        Me.gbPersona.Controls.Add(Me.txtColaborador)
        Me.gbPersona.Controls.Add(Me.lblColaborador)
        Me.gbPersona.Controls.Add(Me.chkColaborador)
        Me.gbPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPersona.Location = New System.Drawing.Point(27, 46)
        Me.gbPersona.Name = "gbPersona"
        Me.gbPersona.Size = New System.Drawing.Size(448, 54)
        Me.gbPersona.TabIndex = 3
        Me.gbPersona.Text = "Buscar Persona"
        Me.gbPersona.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btnBuscarPersona
        '
        Me.btnBuscarPersona.Image = Global.SIGECOM.My.Resources.Resources.Buscar
        Me.btnBuscarPersona.Location = New System.Drawing.Point(400, 26)
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
        Me.txtColaborador.Location = New System.Drawing.Point(100, 28)
        Me.txtColaborador.MaxLength = 3
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.ReadOnly = True
        Me.txtColaborador.Size = New System.Drawing.Size(298, 20)
        Me.txtColaborador.TabIndex = 4
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Location = New System.Drawing.Point(19, 31)
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
        Me.chkColaborador.Location = New System.Drawing.Point(164, 10)
        Me.chkColaborador.Name = "chkColaborador"
        Me.chkColaborador.Size = New System.Drawing.Size(166, 17)
        Me.chkColaborador.TabIndex = 4
        Me.chkColaborador.TabStop = False
        Me.chkColaborador.Text = "Todos los Colaboradores"
        Me.chkColaborador.UseVisualStyleBackColor = True
        '
        'txtFecInicio
        '
        '
        '
        '
        Me.txtFecInicio.DropDownCalendar.Name = ""
        Me.txtFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecInicio.Location = New System.Drawing.Point(175, 20)
        Me.txtFecInicio.MinDate = New Date(2005, 1, 1, 0, 0, 0, 0)
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.Size = New System.Drawing.Size(97, 20)
        Me.txtFecInicio.TabIndex = 1
        Me.txtFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(78, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 361
        Me.Label1.Text = " Fechas   Del :"
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.Location = New System.Drawing.Point(306, 171)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(184, 20)
        Me.cmbCentroCosto.TabIndex = 10
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(220, 174)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 13)
        Me.Label32.TabIndex = 358
        Me.Label32.Text = "Centro Costo"
        '
        'cmbArea
        '
        Me.cmbArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbArea_DesignTimeLayout.LayoutString = resources.GetString("cmbArea_DesignTimeLayout.LayoutString")
        Me.cmbArea.DesignTimeLayout = cmbArea_DesignTimeLayout
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Location = New System.Drawing.Point(55, 170)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.SelectedIndex = -1
        Me.cmbArea.SelectedItem = Nothing
        Me.cmbArea.Size = New System.Drawing.Size(124, 20)
        Me.cmbArea.TabIndex = 9
        Me.cmbArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 174)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 356
        Me.Label9.Text = "Área"
        '
        'cmbTipoCapac
        '
        Me.cmbTipoCapac.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbTipoCapac_DesignTimeLayout.LayoutString = resources.GetString("cmbTipoCapac_DesignTimeLayout.LayoutString")
        Me.cmbTipoCapac.DesignTimeLayout = cmbTipoCapac_DesignTimeLayout
        Me.cmbTipoCapac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCapac.Location = New System.Drawing.Point(399, 199)
        Me.cmbTipoCapac.Name = "cmbTipoCapac"
        Me.cmbTipoCapac.SelectedIndex = -1
        Me.cmbTipoCapac.SelectedItem = Nothing
        Me.cmbTipoCapac.Size = New System.Drawing.Size(91, 20)
        Me.cmbTipoCapac.TabIndex = 12
        Me.cmbTipoCapac.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(361, 203)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(32, 13)
        Me.Label21.TabIndex = 354
        Me.Label21.Text = "Tipo"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.SIGECOM.My.Resources.Resources.Aceptar
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(182, 317)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 25)
        Me.btnAceptar.TabIndex = 14
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
        Me.btnCancelar.Location = New System.Drawing.Point(264, 317)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 25)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbImprimir
        '
        Me.gbImprimir.Controls.Add(Me.rbExcel)
        Me.gbImprimir.Controls.Add(Me.rbPantalla)
        Me.gbImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbImprimir.Location = New System.Drawing.Point(142, 267)
        Me.gbImprimir.Name = "gbImprimir"
        Me.gbImprimir.Size = New System.Drawing.Size(238, 40)
        Me.gbImprimir.TabIndex = 366
        Me.gbImprimir.Text = "Exportar"
        Me.gbImprimir.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'rbExcel
        '
        Me.rbExcel.Location = New System.Drawing.Point(143, 13)
        Me.rbExcel.Name = "rbExcel"
        Me.rbExcel.Size = New System.Drawing.Size(72, 23)
        Me.rbExcel.TabIndex = 3
        Me.rbExcel.Text = "Excel"
        '
        'rbPantalla
        '
        Me.rbPantalla.Checked = True
        Me.rbPantalla.Location = New System.Drawing.Point(38, 13)
        Me.rbPantalla.Name = "rbPantalla"
        Me.rbPantalla.Size = New System.Drawing.Size(76, 23)
        Me.rbPantalla.TabIndex = 2
        Me.rbPantalla.TabStop = True
        Me.rbPantalla.Text = "Pantalla"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(422, 276)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(75, 30)
        Me.DataGridView1.TabIndex = 367
        Me.DataGridView1.Visible = False
        '
        'frmRepCapacitacion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(521, 352)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.gbImprimir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gbDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRepCapacitacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Capacitación"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbCargo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        CType(Me.gbPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPersona.ResumeLayout(False)
        Me.gbPersona.PerformLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoCapac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbImprimir.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbPersona As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarPersona As System.Windows.Forms.Button
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents chkColaborador As System.Windows.Forms.CheckBox
    Friend WithEvents txtFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCapac As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents gbProveedor As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNomCurso As System.Windows.Forms.TextBox
    Friend WithEvents cmbCargo As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbImprimir As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents rbExcel As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbPantalla As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
