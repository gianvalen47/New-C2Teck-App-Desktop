<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContratos
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
        Dim cmbCentroCosto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbCodArea_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDatos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbNoAporte_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContratos))
        Dim cmbModalidad_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMoneda_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvIngresos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbBancoAbono_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbBancoCTS_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim cmbMonedaCTS_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvPeriodoContrato_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvAumentos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvAfps_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvOtrosSueldos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvOtroEmpleador_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim dgvDHMayores_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.ofEstiloForm = New Janus.Windows.Ribbon.OfficeFormAdorner(Me.components)
        Me.gbDatosBusqueda = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbVigente = New System.Windows.Forms.CheckBox()
        Me.cmbCentroCosto = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCodArea = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.ssBarra = New System.Windows.Forms.StatusStrip()
        Me.sslError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvDatos = New Janus.Windows.GridEX.GridEX()
        Me.gtPestanas = New Janus.Windows.UI.Tab.UITab()
        Me.tpContratos = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox3 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCantidadDH = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMontoEPS = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbJubilacion = New System.Windows.Forms.CheckBox()
        Me.cbEPS = New System.Windows.Forms.CheckBox()
        Me.cmbNoAporte = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.UiGroupBox1 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtcentroCostoContrato = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAreaContrato = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombreContrato = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnDeshacer = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gbDatos = New Janus.Windows.EditControls.UIGroupBox()
        Me.cbSCTR = New System.Windows.Forms.CheckBox()
        Me.cbAsignacionFamiliar = New System.Windows.Forms.CheckBox()
        Me.cbSaludVida = New System.Windows.Forms.CheckBox()
        Me.txtNumSeguro = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtMovilidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.cmbModalidad = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtTotalIngresos = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.cmbMoneda = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.gbVigencia = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtFecFinal = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.txtFecInicio = New Janus.Windows.CalendarCombo.CalendarCombo()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.gbIngresos = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvIngresos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesIngresos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbAbono = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cmbBancoAbono = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumCuentaAbono = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.gbCts = New Janus.Windows.EditControls.UIGroupBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cmbBancoCTS = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.txtNumCuentaCTS = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbMonedaCTS = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tpPerContratos = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox2 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCentroCostoPerContrato = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAreaPerContrato = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNombrePerContrato = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbContratoDetalle = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvPeriodoContrato = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesPerContrato = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoPerContrato = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarPerContrato = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarPerContrato = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarPerContrato = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpAumentosMovAFPs = New Janus.Windows.UI.Tab.UITabPage()
        Me.gbAumentos = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvAumentos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesAumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoAumento = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarAumento = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarAumento = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarAumento = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbDetallesFP = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvAfps = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesAfp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoAFP = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarAFP = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarAFP = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarAFP = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbDatosAfp = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCentroCostoAfp = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAreaAfp = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtNombreAfp = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.tpOtroEmpleador = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiGroupBox6 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtanioOtroSueldo = New Janus.Windows.GridEX.EditControls.IntegerUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgvOtrosSueldos = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesOtroSueldo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoOtroSueldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostraOtroSueldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miBorrarOtroSueldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarOtroSueldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiGroupBox5 = New Janus.Windows.EditControls.UIGroupBox()
        Me.dgvOtroEmpleador = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesOtroEmpleador = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoEmpleador = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarEmpleador = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarEmpleador = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarEmpleador = New System.Windows.Forms.ToolStripMenuItem()
        Me.UiGroupBox4 = New Janus.Windows.EditControls.UIGroupBox()
        Me.txtCentroOtro = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAreaOtro = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPersonaOtro = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tpDHMayores = New Janus.Windows.UI.Tab.UITabPage()
        Me.dgvDHMayores = New Janus.Windows.GridEX.GridEX()
        Me.cmOpcionesDHMayores = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.miNuevoDHMayor = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMostrarDHMayor = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEliminarDHMayor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.miActualizarDHMayor = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosBusqueda.SuspendLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ssBarra.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gtPestanas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gtPestanas.SuspendLayout()
        Me.tpContratos.SuspendLayout()
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox3.SuspendLayout()
        CType(Me.cmbNoAporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox1.SuspendLayout()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatos.SuspendLayout()
        CType(Me.cmbModalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbVigencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbVigencia.SuspendLayout()
        CType(Me.gbIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbIngresos.SuspendLayout()
        CType(Me.dgvIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesIngresos.SuspendLayout()
        CType(Me.gbAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAbono.SuspendLayout()
        CType(Me.cmbBancoAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCts.SuspendLayout()
        CType(Me.cmbBancoCTS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMonedaCTS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPerContratos.SuspendLayout()
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox2.SuspendLayout()
        CType(Me.gbContratoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbContratoDetalle.SuspendLayout()
        CType(Me.dgvPeriodoContrato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesPerContrato.SuspendLayout()
        Me.tpAumentosMovAFPs.SuspendLayout()
        CType(Me.gbAumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAumentos.SuspendLayout()
        CType(Me.dgvAumentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesAumentos.SuspendLayout()
        CType(Me.gbDetallesFP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetallesFP.SuspendLayout()
        CType(Me.dgvAfps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesAfp.SuspendLayout()
        CType(Me.gbDatosAfp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatosAfp.SuspendLayout()
        Me.tpOtroEmpleador.SuspendLayout()
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox6.SuspendLayout()
        CType(Me.dgvOtrosSueldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesOtroSueldo.SuspendLayout()
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox5.SuspendLayout()
        CType(Me.dgvOtroEmpleador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesOtroEmpleador.SuspendLayout()
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiGroupBox4.SuspendLayout()
        Me.tpDHMayores.SuspendLayout()
        CType(Me.dgvDHMayores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmOpcionesDHMayores.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofEstiloForm
        '
        Me.ofEstiloForm.Form = Me
        Me.ofEstiloForm.Office2007CustomColor = System.Drawing.Color.Empty
        '
        'gbDatosBusqueda
        '
        Me.gbDatosBusqueda.Controls.Add(Me.Label10)
        Me.gbDatosBusqueda.Controls.Add(Me.cbVigente)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbCentroCosto)
        Me.gbDatosBusqueda.Controls.Add(Me.Label32)
        Me.gbDatosBusqueda.Controls.Add(Me.btnBuscar)
        Me.gbDatosBusqueda.Controls.Add(Me.Label1)
        Me.gbDatosBusqueda.Controls.Add(Me.cmbCodArea)
        Me.gbDatosBusqueda.Controls.Add(Me.Label7)
        Me.gbDatosBusqueda.Controls.Add(Me.txtColaborador)
        Me.gbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatosBusqueda.Location = New System.Drawing.Point(4, 2)
        Me.gbDatosBusqueda.Name = "gbDatosBusqueda"
        Me.gbDatosBusqueda.Size = New System.Drawing.Size(465, 63)
        Me.gbDatosBusqueda.TabIndex = 0
        Me.gbDatosBusqueda.Text = "Datos de Búsqueda"
        Me.gbDatosBusqueda.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(352, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 338
        Me.Label10.Text = "Vigente"
        '
        'cbVigente
        '
        Me.cbVigente.AutoSize = True
        Me.cbVigente.Checked = True
        Me.cbVigente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbVigente.Location = New System.Drawing.Point(371, 37)
        Me.cbVigente.Name = "cbVigente"
        Me.cbVigente.Size = New System.Drawing.Size(15, 14)
        Me.cbVigente.TabIndex = 337
        Me.cbVigente.UseVisualStyleBackColor = True
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCentroCosto_DesignTimeLayout.LayoutString = resources.GetString("cmbCentroCosto_DesignTimeLayout.LayoutString")
        Me.cmbCentroCosto.DesignTimeLayout = cmbCentroCosto_DesignTimeLayout
        Me.cmbCentroCosto.Location = New System.Drawing.Point(112, 34)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.SelectedIndex = -1
        Me.cmbCentroCosto.SelectedItem = Nothing
        Me.cmbCentroCosto.Size = New System.Drawing.Size(118, 20)
        Me.cmbCentroCosto.TabIndex = 336
        Me.cmbCentroCosto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(130, 18)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 13)
        Me.Label32.TabIndex = 335
        Me.Label32.Text = "Centro Costo"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(401, 33)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 23)
        Me.btnBuscar.TabIndex = 200
        Me.btnBuscar.Text = "Busc."
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(259, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "Colaborador"
        '
        'cmbCodArea
        '
        Me.cmbCodArea.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbCodArea_DesignTimeLayout.LayoutString = resources.GetString("cmbCodArea_DesignTimeLayout.LayoutString")
        Me.cmbCodArea.DesignTimeLayout = cmbCodArea_DesignTimeLayout
        Me.cmbCodArea.Location = New System.Drawing.Point(5, 34)
        Me.cmbCodArea.Name = "cmbCodArea"
        Me.cmbCodArea.SelectedIndex = -1
        Me.cmbCodArea.SelectedItem = Nothing
        Me.cmbCodArea.Size = New System.Drawing.Size(101, 20)
        Me.cmbCodArea.TabIndex = 195
        Me.cmbCodArea.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(38, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 198
        Me.Label7.Text = "Area"
        '
        'txtColaborador
        '
        Me.txtColaborador.BackColor = System.Drawing.SystemColors.Window
        Me.txtColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColaborador.Location = New System.Drawing.Point(236, 35)
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.Size = New System.Drawing.Size(118, 20)
        Me.txtColaborador.TabIndex = 196
        '
        'ssBarra
        '
        Me.ssBarra.AutoSize = False
        Me.ssBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslError, Me.sslTotal})
        Me.ssBarra.Location = New System.Drawing.Point(0, 506)
        Me.ssBarra.Name = "ssBarra"
        Me.ssBarra.Size = New System.Drawing.Size(1039, 20)
        Me.ssBarra.TabIndex = 202
        '
        'sslError
        '
        Me.sslError.AutoSize = False
        Me.sslError.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.sslError.Name = "sslError"
        Me.sslError.Size = New System.Drawing.Size(468, 15)
        '
        'sslTotal
        '
        Me.sslTotal.AutoSize = False
        Me.sslTotal.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.sslTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sslTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.sslTotal.Name = "sslTotal"
        Me.sslTotal.Size = New System.Drawing.Size(575, 15)
        Me.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvDatos
        '
        dgvDatos_DesignTimeLayout.LayoutString = resources.GetString("dgvDatos_DesignTimeLayout.LayoutString")
        Me.dgvDatos.DesignTimeLayout = dgvDatos_DesignTimeLayout
        Me.dgvDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDatos.GroupByBoxVisible = False
        Me.dgvDatos.Location = New System.Drawing.Point(4, 71)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDatos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDatos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDatos.Size = New System.Drawing.Size(465, 423)
        Me.dgvDatos.TabIndex = 227
        Me.dgvDatos.TabStop = False
        Me.dgvDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gtPestanas
        '
        Me.gtPestanas.BackColor = System.Drawing.SystemColors.Control
        Me.gtPestanas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gtPestanas.Location = New System.Drawing.Point(475, 7)
        Me.gtPestanas.Name = "gtPestanas"
        Me.gtPestanas.Size = New System.Drawing.Size(558, 488)
        Me.gtPestanas.TabIndex = 228
        Me.gtPestanas.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.tpContratos, Me.tpPerContratos, Me.tpAumentosMovAFPs, Me.tpOtroEmpleador, Me.tpDHMayores})
        Me.gtPestanas.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'tpContratos
        '
        Me.tpContratos.Controls.Add(Me.UiGroupBox3)
        Me.tpContratos.Controls.Add(Me.UiGroupBox1)
        Me.tpContratos.Controls.Add(Me.btnEliminar)
        Me.tpContratos.Controls.Add(Me.btnDeshacer)
        Me.tpContratos.Controls.Add(Me.btnEditar)
        Me.tpContratos.Controls.Add(Me.btnGuardar)
        Me.tpContratos.Controls.Add(Me.gbDatos)
        Me.tpContratos.Controls.Add(Me.gbIngresos)
        Me.tpContratos.Controls.Add(Me.gbAbono)
        Me.tpContratos.Controls.Add(Me.gbCts)
        Me.tpContratos.Icon = CType(resources.GetObject("tpContratos.Icon"), System.Drawing.Icon)
        Me.tpContratos.Location = New System.Drawing.Point(1, 23)
        Me.tpContratos.Name = "tpContratos"
        Me.tpContratos.Size = New System.Drawing.Size(556, 464)
        Me.tpContratos.TabStop = True
        Me.tpContratos.Text = "CONTRATO"
        '
        'UiGroupBox3
        '
        Me.UiGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox3.Controls.Add(Me.txtCantidadDH)
        Me.UiGroupBox3.Controls.Add(Me.Label17)
        Me.UiGroupBox3.Controls.Add(Me.txtMontoEPS)
        Me.UiGroupBox3.Controls.Add(Me.Label16)
        Me.UiGroupBox3.Controls.Add(Me.cbJubilacion)
        Me.UiGroupBox3.Controls.Add(Me.cbEPS)
        Me.UiGroupBox3.Controls.Add(Me.cmbNoAporte)
        Me.UiGroupBox3.Controls.Add(Me.Label11)
        Me.UiGroupBox3.Location = New System.Drawing.Point(204, 280)
        Me.UiGroupBox3.Name = "UiGroupBox3"
        Me.UiGroupBox3.Size = New System.Drawing.Size(347, 87)
        Me.UiGroupBox3.TabIndex = 302
        Me.UiGroupBox3.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCantidadDH
        '
        Me.txtCantidadDH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadDH.Location = New System.Drawing.Point(253, 36)
        Me.txtCantidadDH.Maximum = 3000
        Me.txtCantidadDH.MaxLength = 200
        Me.txtCantidadDH.Name = "txtCantidadDH"
        Me.txtCantidadDH.ReadOnly = True
        Me.txtCantidadDH.Size = New System.Drawing.Size(60, 20)
        Me.txtCantidadDH.TabIndex = 345
        Me.txtCantidadDH.TabStop = False
        Me.txtCantidadDH.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtCantidadDH.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(112, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(139, 13)
        Me.Label17.TabIndex = 346
        Me.Label17.Text = "Cantidad Derecho Habiente"
        '
        'txtMontoEPS
        '
        Me.txtMontoEPS.DecimalDigits = 2
        Me.txtMontoEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoEPS.Location = New System.Drawing.Point(136, 62)
        Me.txtMontoEPS.MaxLength = 10
        Me.txtMontoEPS.Name = "txtMontoEPS"
        Me.txtMontoEPS.ReadOnly = True
        Me.txtMontoEPS.Size = New System.Drawing.Size(83, 20)
        Me.txtMontoEPS.TabIndex = 343
        Me.txtMontoEPS.Text = "0.00"
        Me.txtMontoEPS.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoEPS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(125, 13)
        Me.Label16.TabIndex = 344
        Me.Label16.Text = "Monto EPS (Incluye IGV)"
        '
        'cbJubilacion
        '
        Me.cbJubilacion.AutoSize = True
        Me.cbJubilacion.BackColor = System.Drawing.Color.Transparent
        Me.cbJubilacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbJubilacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbJubilacion.Location = New System.Drawing.Point(8, 12)
        Me.cbJubilacion.Name = "cbJubilacion"
        Me.cbJubilacion.Size = New System.Drawing.Size(127, 17)
        Me.cbJubilacion.TabIndex = 340
        Me.cbJubilacion.Tag = ""
        Me.cbJubilacion.Text = "¿No Aporta Pensión?"
        Me.cbJubilacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbJubilacion.UseVisualStyleBackColor = False
        '
        'cbEPS
        '
        Me.cbEPS.AutoSize = True
        Me.cbEPS.BackColor = System.Drawing.Color.Transparent
        Me.cbEPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEPS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbEPS.Location = New System.Drawing.Point(8, 38)
        Me.cbEPS.Name = "cbEPS"
        Me.cbEPS.Size = New System.Drawing.Size(89, 17)
        Me.cbEPS.TabIndex = 341
        Me.cbEPS.Tag = ""
        Me.cbEPS.Text = "¿Tiene EPS?"
        Me.cbEPS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbEPS.UseVisualStyleBackColor = False
        '
        'cmbNoAporte
        '
        Me.cmbNoAporte.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbNoAporte_DesignTimeLayout.LayoutString = resources.GetString("cmbNoAporte_DesignTimeLayout.LayoutString")
        Me.cmbNoAporte.DesignTimeLayout = cmbNoAporte_DesignTimeLayout
        Me.cmbNoAporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNoAporte.Location = New System.Drawing.Point(238, 10)
        Me.cmbNoAporte.Name = "cmbNoAporte"
        Me.cmbNoAporte.SelectedIndex = -1
        Me.cmbNoAporte.SelectedItem = Nothing
        Me.cmbNoAporte.Size = New System.Drawing.Size(56, 20)
        Me.cmbNoAporte.TabIndex = 342
        Me.cmbNoAporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbNoAporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(146, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 13)
        Me.Label11.TabIndex = 341
        Me.Label11.Text = "Codigo No Aporte"
        '
        'UiGroupBox1
        '
        Me.UiGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox1.Controls.Add(Me.txtcentroCostoContrato)
        Me.UiGroupBox1.Controls.Add(Me.Label6)
        Me.UiGroupBox1.Controls.Add(Me.txtAreaContrato)
        Me.UiGroupBox1.Controls.Add(Me.Label2)
        Me.UiGroupBox1.Controls.Add(Me.txtNombreContrato)
        Me.UiGroupBox1.Controls.Add(Me.Label3)
        Me.UiGroupBox1.Location = New System.Drawing.Point(5, 33)
        Me.UiGroupBox1.Name = "UiGroupBox1"
        Me.UiGroupBox1.Size = New System.Drawing.Size(546, 70)
        Me.UiGroupBox1.TabIndex = 301
        Me.UiGroupBox1.Text = "Datos de Colaborador"
        Me.UiGroupBox1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtcentroCostoContrato
        '
        Me.txtcentroCostoContrato.BackColor = System.Drawing.Color.AliceBlue
        Me.txtcentroCostoContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcentroCostoContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcentroCostoContrato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtcentroCostoContrato.Location = New System.Drawing.Point(330, 44)
        Me.txtcentroCostoContrato.Name = "txtcentroCostoContrato"
        Me.txtcentroCostoContrato.ReadOnly = True
        Me.txtcentroCostoContrato.Size = New System.Drawing.Size(204, 20)
        Me.txtcentroCostoContrato.TabIndex = 301
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label6.Location = New System.Drawing.Point(226, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 300
        Me.Label6.Text = "Centro de Costo"
        '
        'txtAreaContrato
        '
        Me.txtAreaContrato.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAreaContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAreaContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAreaContrato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAreaContrato.Location = New System.Drawing.Point(65, 44)
        Me.txtAreaContrato.Name = "txtAreaContrato"
        Me.txtAreaContrato.ReadOnly = True
        Me.txtAreaContrato.Size = New System.Drawing.Size(145, 20)
        Me.txtAreaContrato.TabIndex = 299
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(9, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 298
        Me.Label2.Text = "Area"
        '
        'txtNombreContrato
        '
        Me.txtNombreContrato.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNombreContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreContrato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombreContrato.Location = New System.Drawing.Point(65, 18)
        Me.txtNombreContrato.Name = "txtNombreContrato"
        Me.txtNombreContrato.ReadOnly = True
        Me.txtNombreContrato.Size = New System.Drawing.Size(358, 20)
        Me.txtNombreContrato.TabIndex = 297
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(9, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 282
        Me.Label3.Text = "Nombre"
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.btnEliminar.Location = New System.Drawing.Point(62, 4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(28, 28)
        Me.btnEliminar.TabIndex = 223
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnDeshacer
        '
        Me.btnDeshacer.BackColor = System.Drawing.Color.Transparent
        Me.btnDeshacer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeshacer.Image = Global.SIGECOM.My.Resources.Resources.Deshacer
        Me.btnDeshacer.Location = New System.Drawing.Point(159, 4)
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Size = New System.Drawing.Size(28, 28)
        Me.btnDeshacer.TabIndex = 222
        Me.btnDeshacer.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.Transparent
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.SIGECOM.My.Resources.Resources.Editar
        Me.btnEditar.Location = New System.Drawing.Point(12, 4)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(28, 28)
        Me.btnEditar.TabIndex = 221
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(111, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(28, 28)
        Me.btnGuardar.TabIndex = 220
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'gbDatos
        '
        Me.gbDatos.BackColor = System.Drawing.Color.Transparent
        Me.gbDatos.Controls.Add(Me.cbSCTR)
        Me.gbDatos.Controls.Add(Me.cbAsignacionFamiliar)
        Me.gbDatos.Controls.Add(Me.cbSaludVida)
        Me.gbDatos.Controls.Add(Me.txtNumSeguro)
        Me.gbDatos.Controls.Add(Me.Label42)
        Me.gbDatos.Controls.Add(Me.Label41)
        Me.gbDatos.Controls.Add(Me.txtMovilidad)
        Me.gbDatos.Controls.Add(Me.Label40)
        Me.gbDatos.Controls.Add(Me.cmbModalidad)
        Me.gbDatos.Controls.Add(Me.txtTotalIngresos)
        Me.gbDatos.Controls.Add(Me.Label34)
        Me.gbDatos.Controls.Add(Me.cmbMoneda)
        Me.gbDatos.Controls.Add(Me.Label33)
        Me.gbDatos.Controls.Add(Me.gbVigencia)
        Me.gbDatos.Location = New System.Drawing.Point(5, 106)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(193, 261)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'cbSCTR
        '
        Me.cbSCTR.AutoSize = True
        Me.cbSCTR.BackColor = System.Drawing.Color.Transparent
        Me.cbSCTR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSCTR.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbSCTR.Location = New System.Drawing.Point(15, 240)
        Me.cbSCTR.Name = "cbSCTR"
        Me.cbSCTR.Size = New System.Drawing.Size(97, 17)
        Me.cbSCTR.TabIndex = 343
        Me.cbSCTR.Tag = ""
        Me.cbSCTR.Text = "¿Tiene SCTR?"
        Me.cbSCTR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbSCTR.UseVisualStyleBackColor = False
        '
        'cbAsignacionFamiliar
        '
        Me.cbAsignacionFamiliar.AutoSize = True
        Me.cbAsignacionFamiliar.BackColor = System.Drawing.Color.Transparent
        Me.cbAsignacionFamiliar.Checked = True
        Me.cbAsignacionFamiliar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAsignacionFamiliar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAsignacionFamiliar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbAsignacionFamiliar.Location = New System.Drawing.Point(31, 197)
        Me.cbAsignacionFamiliar.Name = "cbAsignacionFamiliar"
        Me.cbAsignacionFamiliar.Size = New System.Drawing.Size(128, 17)
        Me.cbAsignacionFamiliar.TabIndex = 7
        Me.cbAsignacionFamiliar.Tag = ""
        Me.cbAsignacionFamiliar.Text = "¿Asignación Familiar?"
        Me.cbAsignacionFamiliar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbAsignacionFamiliar.UseVisualStyleBackColor = False
        '
        'cbSaludVida
        '
        Me.cbSaludVida.AutoSize = True
        Me.cbSaludVida.BackColor = System.Drawing.Color.Transparent
        Me.cbSaludVida.Checked = True
        Me.cbSaludVida.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSaludVida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSaludVida.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbSaludVida.Location = New System.Drawing.Point(15, 217)
        Me.cbSaludVida.Name = "cbSaludVida"
        Me.cbSaludVida.Size = New System.Drawing.Size(164, 17)
        Me.cbSaludVida.TabIndex = 8
        Me.cbSaludVida.Tag = ""
        Me.cbSaludVida.Text = "¿Afiliación a EsSalud + Vida?"
        Me.cbSaludVida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbSaludVida.UseVisualStyleBackColor = False
        '
        'txtNumSeguro
        '
        Me.txtNumSeguro.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumSeguro.Location = New System.Drawing.Point(65, 105)
        Me.txtNumSeguro.Name = "txtNumSeguro"
        Me.txtNumSeguro.ReadOnly = True
        Me.txtNumSeguro.Size = New System.Drawing.Size(120, 20)
        Me.txtNumSeguro.TabIndex = 4
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(8, 108)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(56, 13)
        Me.Label42.TabIndex = 339
        Me.Label42.Text = "Nº Seguro"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(8, 86)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(56, 13)
        Me.Label41.TabIndex = 338
        Me.Label41.Text = "Modalidad"
        '
        'txtMovilidad
        '
        Me.txtMovilidad.DecimalDigits = 2
        Me.txtMovilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovilidad.Location = New System.Drawing.Point(65, 174)
        Me.txtMovilidad.MaxLength = 10
        Me.txtMovilidad.Name = "txtMovilidad"
        Me.txtMovilidad.Size = New System.Drawing.Size(83, 20)
        Me.txtMovilidad.TabIndex = 6
        Me.txtMovilidad.Text = "0.00"
        Me.txtMovilidad.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMovilidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(8, 178)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(52, 13)
        Me.Label40.TabIndex = 336
        Me.Label40.Text = "Movilidad"
        '
        'cmbModalidad
        '
        Me.cmbModalidad.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbModalidad_DesignTimeLayout.LayoutString = resources.GetString("cmbModalidad_DesignTimeLayout.LayoutString")
        Me.cmbModalidad.DesignTimeLayout = cmbModalidad_DesignTimeLayout
        Me.cmbModalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModalidad.Location = New System.Drawing.Point(65, 82)
        Me.cmbModalidad.Name = "cmbModalidad"
        Me.cmbModalidad.SelectedIndex = -1
        Me.cmbModalidad.SelectedItem = Nothing
        Me.cmbModalidad.Size = New System.Drawing.Size(100, 20)
        Me.cmbModalidad.TabIndex = 3
        Me.cmbModalidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtTotalIngresos
        '
        Me.txtTotalIngresos.BackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIngresos.DecimalDigits = 2
        Me.txtTotalIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIngresos.Location = New System.Drawing.Point(65, 151)
        Me.txtTotalIngresos.MaxLength = 10
        Me.txtTotalIngresos.Name = "txtTotalIngresos"
        Me.txtTotalIngresos.ReadOnly = True
        Me.txtTotalIngresos.Size = New System.Drawing.Size(83, 20)
        Me.txtTotalIngresos.TabIndex = 333
        Me.txtTotalIngresos.TabStop = False
        Me.txtTotalIngresos.Text = "0.00"
        Me.txtTotalIngresos.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIngresos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(8, 155)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(42, 13)
        Me.Label34.TabIndex = 332
        Me.Label34.Text = "Importe"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMoneda_DesignTimeLayout.LayoutString = resources.GetString("cmbMoneda_DesignTimeLayout.LayoutString")
        Me.cmbMoneda.DesignTimeLayout = cmbMoneda_DesignTimeLayout
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.Location = New System.Drawing.Point(65, 128)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.SelectedIndex = -1
        Me.cmbMoneda.SelectedItem = Nothing
        Me.cmbMoneda.Size = New System.Drawing.Size(56, 20)
        Me.cmbMoneda.TabIndex = 5
        Me.cmbMoneda.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMoneda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(8, 132)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(46, 13)
        Me.Label33.TabIndex = 228
        Me.Label33.Text = "Moneda"
        '
        'gbVigencia
        '
        Me.gbVigencia.Controls.Add(Me.Label31)
        Me.gbVigencia.Controls.Add(Me.txtFecFinal)
        Me.gbVigencia.Controls.Add(Me.txtFecInicio)
        Me.gbVigencia.Controls.Add(Me.Label30)
        Me.gbVigencia.Location = New System.Drawing.Point(7, 9)
        Me.gbVigencia.Name = "gbVigencia"
        Me.gbVigencia.Size = New System.Drawing.Size(179, 66)
        Me.gbVigencia.TabIndex = 0
        Me.gbVigencia.Text = "Vigencia"
        Me.gbVigencia.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(18, 43)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(45, 13)
        Me.Label31.TabIndex = 328
        Me.Label31.Text = "Término"
        '
        'txtFecFinal
        '
        '
        '
        '
        Me.txtFecFinal.DropDownCalendar.Name = ""
        Me.txtFecFinal.DropDownCalendar.Visible = False
        Me.txtFecFinal.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecFinal.IsNullDate = True
        Me.txtFecFinal.Location = New System.Drawing.Point(69, 39)
        Me.txtFecFinal.Name = "txtFecFinal"
        Me.txtFecFinal.NullButtonText = "Ninguno"
        Me.txtFecFinal.Size = New System.Drawing.Size(90, 20)
        Me.txtFecFinal.TabIndex = 2
        Me.txtFecFinal.TodayButtonText = "Hoy"
        Me.txtFecFinal.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'txtFecInicio
        '
        '
        '
        '
        Me.txtFecInicio.DropDownCalendar.Name = ""
        Me.txtFecInicio.DropDownCalendar.Visible = False
        Me.txtFecInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.txtFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFecInicio.IsNullDate = True
        Me.txtFecInicio.Location = New System.Drawing.Point(69, 13)
        Me.txtFecInicio.Name = "txtFecInicio"
        Me.txtFecInicio.NullButtonText = "Ninguno"
        Me.txtFecInicio.Size = New System.Drawing.Size(90, 20)
        Me.txtFecInicio.TabIndex = 1
        Me.txtFecInicio.TodayButtonText = "Hoy"
        Me.txtFecInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(18, 18)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(32, 13)
        Me.Label30.TabIndex = 327
        Me.Label30.Text = "Inicio"
        '
        'gbIngresos
        '
        Me.gbIngresos.BackColor = System.Drawing.Color.Transparent
        Me.gbIngresos.Controls.Add(Me.dgvIngresos)
        Me.gbIngresos.Location = New System.Drawing.Point(205, 106)
        Me.gbIngresos.Name = "gbIngresos"
        Me.gbIngresos.Size = New System.Drawing.Size(346, 174)
        Me.gbIngresos.TabIndex = 4
        Me.gbIngresos.Text = "Ingresos"
        Me.gbIngresos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvIngresos
        '
        Me.dgvIngresos.ContextMenuStrip = Me.cmOpcionesIngresos
        dgvIngresos_DesignTimeLayout.LayoutString = resources.GetString("dgvIngresos_DesignTimeLayout.LayoutString")
        Me.dgvIngresos.DesignTimeLayout = dgvIngresos_DesignTimeLayout
        Me.dgvIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvIngresos.GroupByBoxVisible = False
        Me.dgvIngresos.Location = New System.Drawing.Point(12, 22)
        Me.dgvIngresos.Name = "dgvIngresos"
        Me.dgvIngresos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvIngresos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvIngresos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvIngresos.Size = New System.Drawing.Size(322, 146)
        Me.dgvIngresos.TabIndex = 229
        Me.dgvIngresos.TabStop = False
        Me.dgvIngresos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesIngresos
        '
        Me.cmOpcionesIngresos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoIng, Me.miMostrarIng, Me.miEliminarIng, Me.miSeparador1, Me.ToolStripMenuItem1, Me.miActualizarIng})
        Me.cmOpcionesIngresos.Name = "cmOpciones"
        Me.cmOpcionesIngresos.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoIng
        '
        Me.miNuevoIng.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoIng.Name = "miNuevoIng"
        Me.miNuevoIng.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoIng.Text = "Nuevo"
        Me.miNuevoIng.ToolTipText = "Nuevo Ingreso"
        '
        'miMostrarIng
        '
        Me.miMostrarIng.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarIng.Name = "miMostrarIng"
        Me.miMostrarIng.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarIng.Text = "Mostrar"
        '
        'miEliminarIng
        '
        Me.miEliminarIng.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarIng.Name = "miEliminarIng"
        Me.miEliminarIng.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarIng.Text = "Eliminar"
        Me.miEliminarIng.ToolTipText = "Eliminar Ingreso"
        '
        'miSeparador1
        '
        Me.miSeparador1.Name = "miSeparador1"
        Me.miSeparador1.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarIng
        '
        Me.miActualizarIng.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarIng.Name = "miActualizarIng"
        Me.miActualizarIng.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarIng.Text = "Actualizar"
        Me.miActualizarIng.ToolTipText = "Refrescar Lista Ingresos"
        '
        'gbAbono
        '
        Me.gbAbono.BackColor = System.Drawing.Color.Transparent
        Me.gbAbono.Controls.Add(Me.Label38)
        Me.gbAbono.Controls.Add(Me.cmbBancoAbono)
        Me.gbAbono.Controls.Add(Me.txtNumCuentaAbono)
        Me.gbAbono.Controls.Add(Me.Label39)
        Me.gbAbono.Location = New System.Drawing.Point(281, 369)
        Me.gbAbono.Name = "gbAbono"
        Me.gbAbono.Size = New System.Drawing.Size(270, 89)
        Me.gbAbono.TabIndex = 11
        Me.gbAbono.Text = "Cuenta de Abono"
        Me.gbAbono.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(18, 35)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(43, 13)
        Me.Label38.TabIndex = 305
        Me.Label38.Text = "Entidad"
        '
        'cmbBancoAbono
        '
        Me.cmbBancoAbono.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbBancoAbono_DesignTimeLayout.LayoutString = resources.GetString("cmbBancoAbono_DesignTimeLayout.LayoutString")
        Me.cmbBancoAbono.DesignTimeLayout = cmbBancoAbono_DesignTimeLayout
        Me.cmbBancoAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBancoAbono.Location = New System.Drawing.Point(85, 31)
        Me.cmbBancoAbono.Name = "cmbBancoAbono"
        Me.cmbBancoAbono.SelectedIndex = -1
        Me.cmbBancoAbono.SelectedItem = Nothing
        Me.cmbBancoAbono.Size = New System.Drawing.Size(170, 20)
        Me.cmbBancoAbono.TabIndex = 12
        Me.cmbBancoAbono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumCuentaAbono
        '
        Me.txtNumCuentaAbono.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumCuentaAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCuentaAbono.Location = New System.Drawing.Point(85, 61)
        Me.txtNumCuentaAbono.Name = "txtNumCuentaAbono"
        Me.txtNumCuentaAbono.ReadOnly = True
        Me.txtNumCuentaAbono.Size = New System.Drawing.Size(150, 20)
        Me.txtNumCuentaAbono.TabIndex = 13
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(18, 64)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(61, 13)
        Me.Label39.TabIndex = 302
        Me.Label39.Text = "Nro Cuenta"
        '
        'gbCts
        '
        Me.gbCts.BackColor = System.Drawing.Color.Transparent
        Me.gbCts.Controls.Add(Me.Label37)
        Me.gbCts.Controls.Add(Me.cmbBancoCTS)
        Me.gbCts.Controls.Add(Me.txtNumCuentaCTS)
        Me.gbCts.Controls.Add(Me.Label36)
        Me.gbCts.Controls.Add(Me.cmbMonedaCTS)
        Me.gbCts.Controls.Add(Me.Label35)
        Me.gbCts.Location = New System.Drawing.Point(5, 369)
        Me.gbCts.Name = "gbCts"
        Me.gbCts.Size = New System.Drawing.Size(269, 89)
        Me.gbCts.TabIndex = 7
        Me.gbCts.Text = "CTS"
        Me.gbCts.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(20, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(43, 13)
        Me.Label37.TabIndex = 301
        Me.Label37.Text = "Entidad"
        '
        'cmbBancoCTS
        '
        Me.cmbBancoCTS.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbBancoCTS_DesignTimeLayout.LayoutString = resources.GetString("cmbBancoCTS_DesignTimeLayout.LayoutString")
        Me.cmbBancoCTS.DesignTimeLayout = cmbBancoCTS_DesignTimeLayout
        Me.cmbBancoCTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBancoCTS.Location = New System.Drawing.Point(87, 12)
        Me.cmbBancoCTS.Name = "cmbBancoCTS"
        Me.cmbBancoCTS.SelectedIndex = -1
        Me.cmbBancoCTS.SelectedItem = Nothing
        Me.cmbBancoCTS.Size = New System.Drawing.Size(170, 20)
        Me.cmbBancoCTS.TabIndex = 8
        Me.cmbBancoCTS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'txtNumCuentaCTS
        '
        Me.txtNumCuentaCTS.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumCuentaCTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumCuentaCTS.Location = New System.Drawing.Point(87, 36)
        Me.txtNumCuentaCTS.Name = "txtNumCuentaCTS"
        Me.txtNumCuentaCTS.ReadOnly = True
        Me.txtNumCuentaCTS.Size = New System.Drawing.Size(150, 20)
        Me.txtNumCuentaCTS.TabIndex = 9
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(20, 39)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(61, 13)
        Me.Label36.TabIndex = 298
        Me.Label36.Text = "Nro Cuenta"
        '
        'cmbMonedaCTS
        '
        Me.cmbMonedaCTS.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList
        cmbMonedaCTS_DesignTimeLayout.LayoutString = resources.GetString("cmbMonedaCTS_DesignTimeLayout.LayoutString")
        Me.cmbMonedaCTS.DesignTimeLayout = cmbMonedaCTS_DesignTimeLayout
        Me.cmbMonedaCTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonedaCTS.Location = New System.Drawing.Point(87, 59)
        Me.cmbMonedaCTS.Name = "cmbMonedaCTS"
        Me.cmbMonedaCTS.SelectedIndex = -1
        Me.cmbMonedaCTS.SelectedItem = Nothing
        Me.cmbMonedaCTS.Size = New System.Drawing.Size(56, 20)
        Me.cmbMonedaCTS.TabIndex = 10
        Me.cmbMonedaCTS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.cmbMonedaCTS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(20, 65)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(46, 13)
        Me.Label35.TabIndex = 230
        Me.Label35.Text = "Moneda"
        '
        'tpPerContratos
        '
        Me.tpPerContratos.Controls.Add(Me.UiGroupBox2)
        Me.tpPerContratos.Controls.Add(Me.gbContratoDetalle)
        Me.tpPerContratos.Icon = CType(resources.GetObject("tpPerContratos.Icon"), System.Drawing.Icon)
        Me.tpPerContratos.Location = New System.Drawing.Point(1, 23)
        Me.tpPerContratos.Name = "tpPerContratos"
        Me.tpPerContratos.Size = New System.Drawing.Size(556, 464)
        Me.tpPerContratos.TabStop = True
        Me.tpPerContratos.Text = "PERIODOS CONTRATO"
        '
        'UiGroupBox2
        '
        Me.UiGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox2.Controls.Add(Me.txtCentroCostoPerContrato)
        Me.UiGroupBox2.Controls.Add(Me.Label8)
        Me.UiGroupBox2.Controls.Add(Me.txtAreaPerContrato)
        Me.UiGroupBox2.Controls.Add(Me.Label4)
        Me.UiGroupBox2.Controls.Add(Me.txtNombrePerContrato)
        Me.UiGroupBox2.Controls.Add(Me.Label5)
        Me.UiGroupBox2.Location = New System.Drawing.Point(11, 75)
        Me.UiGroupBox2.Name = "UiGroupBox2"
        Me.UiGroupBox2.Size = New System.Drawing.Size(533, 70)
        Me.UiGroupBox2.TabIndex = 302
        Me.UiGroupBox2.Text = "Datos de Colaborador"
        Me.UiGroupBox2.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCentroCostoPerContrato
        '
        Me.txtCentroCostoPerContrato.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCentroCostoPerContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCentroCostoPerContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCentroCostoPerContrato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCentroCostoPerContrato.Location = New System.Drawing.Point(322, 42)
        Me.txtCentroCostoPerContrato.Name = "txtCentroCostoPerContrato"
        Me.txtCentroCostoPerContrato.ReadOnly = True
        Me.txtCentroCostoPerContrato.Size = New System.Drawing.Size(204, 20)
        Me.txtCentroCostoPerContrato.TabIndex = 303
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label8.Location = New System.Drawing.Point(218, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 302
        Me.Label8.Text = "Centro de Costo"
        '
        'txtAreaPerContrato
        '
        Me.txtAreaPerContrato.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAreaPerContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAreaPerContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAreaPerContrato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAreaPerContrato.Location = New System.Drawing.Point(65, 42)
        Me.txtAreaPerContrato.Name = "txtAreaPerContrato"
        Me.txtAreaPerContrato.ReadOnly = True
        Me.txtAreaPerContrato.Size = New System.Drawing.Size(145, 20)
        Me.txtAreaPerContrato.TabIndex = 299
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(9, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 298
        Me.Label4.Text = "Area"
        '
        'txtNombrePerContrato
        '
        Me.txtNombrePerContrato.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNombrePerContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombrePerContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombrePerContrato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombrePerContrato.Location = New System.Drawing.Point(65, 16)
        Me.txtNombrePerContrato.Name = "txtNombrePerContrato"
        Me.txtNombrePerContrato.ReadOnly = True
        Me.txtNombrePerContrato.Size = New System.Drawing.Size(339, 20)
        Me.txtNombrePerContrato.TabIndex = 297
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(9, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 282
        Me.Label5.Text = "Nombre"
        '
        'gbContratoDetalle
        '
        Me.gbContratoDetalle.BackColor = System.Drawing.Color.Transparent
        Me.gbContratoDetalle.Controls.Add(Me.dgvPeriodoContrato)
        Me.gbContratoDetalle.Icon = CType(resources.GetObject("gbContratoDetalle.Icon"), System.Drawing.Icon)
        Me.gbContratoDetalle.Location = New System.Drawing.Point(11, 155)
        Me.gbContratoDetalle.Name = "gbContratoDetalle"
        Me.gbContratoDetalle.Size = New System.Drawing.Size(533, 232)
        Me.gbContratoDetalle.TabIndex = 7
        Me.gbContratoDetalle.Text = "PERIODOS CONTRATO"
        Me.gbContratoDetalle.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbContratoDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvPeriodoContrato
        '
        Me.dgvPeriodoContrato.ContextMenuStrip = Me.cmOpcionesPerContrato
        dgvPeriodoContrato_DesignTimeLayout.LayoutString = resources.GetString("dgvPeriodoContrato_DesignTimeLayout.LayoutString")
        Me.dgvPeriodoContrato.DesignTimeLayout = dgvPeriodoContrato_DesignTimeLayout
        Me.dgvPeriodoContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPeriodoContrato.GroupByBoxVisible = False
        Me.dgvPeriodoContrato.Location = New System.Drawing.Point(9, 21)
        Me.dgvPeriodoContrato.Name = "dgvPeriodoContrato"
        Me.dgvPeriodoContrato.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvPeriodoContrato.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvPeriodoContrato.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvPeriodoContrato.Size = New System.Drawing.Size(515, 201)
        Me.dgvPeriodoContrato.TabIndex = 230
        Me.dgvPeriodoContrato.TabStop = False
        Me.dgvPeriodoContrato.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesPerContrato
        '
        Me.cmOpcionesPerContrato.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoPerContrato, Me.miMostrarPerContrato, Me.miEliminarPerContrato, Me.ToolStripSeparator5, Me.ToolStripSeparator6, Me.miActualizarPerContrato})
        Me.cmOpcionesPerContrato.Name = "cmOpciones"
        Me.cmOpcionesPerContrato.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoPerContrato
        '
        Me.miNuevoPerContrato.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoPerContrato.Name = "miNuevoPerContrato"
        Me.miNuevoPerContrato.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoPerContrato.Text = "Nuevo"
        Me.miNuevoPerContrato.ToolTipText = "Nuevo Ingreso"
        '
        'miMostrarPerContrato
        '
        Me.miMostrarPerContrato.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarPerContrato.Name = "miMostrarPerContrato"
        Me.miMostrarPerContrato.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarPerContrato.Text = "Mostrar"
        '
        'miEliminarPerContrato
        '
        Me.miEliminarPerContrato.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarPerContrato.Name = "miEliminarPerContrato"
        Me.miEliminarPerContrato.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarPerContrato.Text = "Eliminar"
        Me.miEliminarPerContrato.ToolTipText = "Eliminar Ingreso"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarPerContrato
        '
        Me.miActualizarPerContrato.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarPerContrato.Name = "miActualizarPerContrato"
        Me.miActualizarPerContrato.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarPerContrato.Text = "Actualizar"
        Me.miActualizarPerContrato.ToolTipText = "Refrescar Lista Ingresos"
        '
        'tpAumentosMovAFPs
        '
        Me.tpAumentosMovAFPs.Controls.Add(Me.gbAumentos)
        Me.tpAumentosMovAFPs.Controls.Add(Me.gbDetallesFP)
        Me.tpAumentosMovAFPs.Controls.Add(Me.gbDatosAfp)
        Me.tpAumentosMovAFPs.Icon = CType(resources.GetObject("tpAumentosMovAFPs.Icon"), System.Drawing.Icon)
        Me.tpAumentosMovAFPs.Location = New System.Drawing.Point(1, 23)
        Me.tpAumentosMovAFPs.Name = "tpAumentosMovAFPs"
        Me.tpAumentosMovAFPs.Size = New System.Drawing.Size(556, 464)
        Me.tpAumentosMovAFPs.TabStop = True
        Me.tpAumentosMovAFPs.Text = "AUMENTOS / MOV. AFPs"
        '
        'gbAumentos
        '
        Me.gbAumentos.BackColor = System.Drawing.Color.Transparent
        Me.gbAumentos.Controls.Add(Me.dgvAumentos)
        Me.gbAumentos.Icon = CType(resources.GetObject("gbAumentos.Icon"), System.Drawing.Icon)
        Me.gbAumentos.Location = New System.Drawing.Point(17, 104)
        Me.gbAumentos.Name = "gbAumentos"
        Me.gbAumentos.Size = New System.Drawing.Size(520, 163)
        Me.gbAumentos.TabIndex = 302
        Me.gbAumentos.Text = "AUMENTOS"
        Me.gbAumentos.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbAumentos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvAumentos
        '
        Me.dgvAumentos.ContextMenuStrip = Me.cmOpcionesAumentos
        dgvAumentos_DesignTimeLayout.LayoutString = resources.GetString("dgvAumentos_DesignTimeLayout.LayoutString")
        Me.dgvAumentos.DesignTimeLayout = dgvAumentos_DesignTimeLayout
        Me.dgvAumentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAumentos.GroupByBoxVisible = False
        Me.dgvAumentos.Location = New System.Drawing.Point(11, 19)
        Me.dgvAumentos.Name = "dgvAumentos"
        Me.dgvAumentos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvAumentos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvAumentos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvAumentos.Size = New System.Drawing.Size(498, 132)
        Me.dgvAumentos.TabIndex = 229
        Me.dgvAumentos.TabStop = False
        Me.dgvAumentos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesAumentos
        '
        Me.cmOpcionesAumentos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoAumento, Me.miMostrarAumento, Me.miEliminarAumento, Me.ToolStripSeparator3, Me.ToolStripSeparator4, Me.miActualizarAumento})
        Me.cmOpcionesAumentos.Name = "cmOpciones"
        Me.cmOpcionesAumentos.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoAumento
        '
        Me.miNuevoAumento.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoAumento.Name = "miNuevoAumento"
        Me.miNuevoAumento.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoAumento.Text = "Nuevo"
        Me.miNuevoAumento.ToolTipText = "Nuevo Aumento"
        '
        'miMostrarAumento
        '
        Me.miMostrarAumento.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarAumento.Name = "miMostrarAumento"
        Me.miMostrarAumento.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarAumento.Text = "Mostrar"
        '
        'miEliminarAumento
        '
        Me.miEliminarAumento.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarAumento.Name = "miEliminarAumento"
        Me.miEliminarAumento.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarAumento.Text = "Eliminar"
        Me.miEliminarAumento.ToolTipText = "Eliminar Aumento"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarAumento
        '
        Me.miActualizarAumento.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarAumento.Name = "miActualizarAumento"
        Me.miActualizarAumento.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarAumento.Text = "Actualizar"
        Me.miActualizarAumento.ToolTipText = "Refrescar Lista Aumentos"
        '
        'gbDetallesFP
        '
        Me.gbDetallesFP.BackColor = System.Drawing.Color.Transparent
        Me.gbDetallesFP.Controls.Add(Me.dgvAfps)
        Me.gbDetallesFP.Icon = CType(resources.GetObject("gbDetallesFP.Icon"), System.Drawing.Icon)
        Me.gbDetallesFP.Location = New System.Drawing.Point(17, 276)
        Me.gbDetallesFP.Name = "gbDetallesFP"
        Me.gbDetallesFP.Size = New System.Drawing.Size(521, 163)
        Me.gbDetallesFP.TabIndex = 301
        Me.gbDetallesFP.Text = "AFPs"
        Me.gbDetallesFP.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.gbDetallesFP.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvAfps
        '
        Me.dgvAfps.ContextMenuStrip = Me.cmOpcionesAfp
        dgvAfps_DesignTimeLayout.LayoutString = resources.GetString("dgvAfps_DesignTimeLayout.LayoutString")
        Me.dgvAfps.DesignTimeLayout = dgvAfps_DesignTimeLayout
        Me.dgvAfps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAfps.GroupByBoxVisible = False
        Me.dgvAfps.Location = New System.Drawing.Point(12, 19)
        Me.dgvAfps.Name = "dgvAfps"
        Me.dgvAfps.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvAfps.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvAfps.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvAfps.Size = New System.Drawing.Size(498, 132)
        Me.dgvAfps.TabIndex = 228
        Me.dgvAfps.TabStop = False
        Me.dgvAfps.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesAfp
        '
        Me.cmOpcionesAfp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoAFP, Me.miMostrarAFP, Me.miEliminarAFP, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.miActualizarAFP})
        Me.cmOpcionesAfp.Name = "cmOpciones"
        Me.cmOpcionesAfp.Size = New System.Drawing.Size(127, 104)
        '
        'miNuevoAFP
        '
        Me.miNuevoAFP.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoAFP.Name = "miNuevoAFP"
        Me.miNuevoAFP.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoAFP.Text = "Nuevo"
        Me.miNuevoAFP.ToolTipText = "Nuevo AFP"
        '
        'miMostrarAFP
        '
        Me.miMostrarAFP.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarAFP.Name = "miMostrarAFP"
        Me.miMostrarAFP.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarAFP.Text = "Mostrar"
        '
        'miEliminarAFP
        '
        Me.miEliminarAFP.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarAFP.Name = "miEliminarAFP"
        Me.miEliminarAFP.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarAFP.Text = "Eliminar"
        Me.miEliminarAFP.ToolTipText = "Eliminar AFP"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarAFP
        '
        Me.miActualizarAFP.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarAFP.Name = "miActualizarAFP"
        Me.miActualizarAFP.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarAFP.Text = "Actualizar"
        Me.miActualizarAFP.ToolTipText = "Refrescar Lista AFPs"
        '
        'gbDatosAfp
        '
        Me.gbDatosAfp.BackColor = System.Drawing.Color.Transparent
        Me.gbDatosAfp.Controls.Add(Me.txtCentroCostoAfp)
        Me.gbDatosAfp.Controls.Add(Me.Label9)
        Me.gbDatosAfp.Controls.Add(Me.txtAreaAfp)
        Me.gbDatosAfp.Controls.Add(Me.Label29)
        Me.gbDatosAfp.Controls.Add(Me.txtNombreAfp)
        Me.gbDatosAfp.Controls.Add(Me.Label28)
        Me.gbDatosAfp.Location = New System.Drawing.Point(17, 23)
        Me.gbDatosAfp.Name = "gbDatosAfp"
        Me.gbDatosAfp.Size = New System.Drawing.Size(521, 70)
        Me.gbDatosAfp.TabIndex = 300
        Me.gbDatosAfp.Text = "Datos de Colaborador"
        Me.gbDatosAfp.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCentroCostoAfp
        '
        Me.txtCentroCostoAfp.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCentroCostoAfp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCentroCostoAfp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCentroCostoAfp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCentroCostoAfp.Location = New System.Drawing.Point(310, 41)
        Me.txtCentroCostoAfp.Name = "txtCentroCostoAfp"
        Me.txtCentroCostoAfp.ReadOnly = True
        Me.txtCentroCostoAfp.Size = New System.Drawing.Size(204, 20)
        Me.txtCentroCostoAfp.TabIndex = 305
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label9.Location = New System.Drawing.Point(212, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 304
        Me.Label9.Text = "Centro de Costo"
        '
        'txtAreaAfp
        '
        Me.txtAreaAfp.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAreaAfp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAreaAfp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAreaAfp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAreaAfp.Location = New System.Drawing.Point(59, 41)
        Me.txtAreaAfp.Name = "txtAreaAfp"
        Me.txtAreaAfp.ReadOnly = True
        Me.txtAreaAfp.Size = New System.Drawing.Size(145, 20)
        Me.txtAreaAfp.TabIndex = 299
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label29.Location = New System.Drawing.Point(6, 44)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(33, 13)
        Me.Label29.TabIndex = 298
        Me.Label29.Text = "Area"
        '
        'txtNombreAfp
        '
        Me.txtNombreAfp.BackColor = System.Drawing.Color.AliceBlue
        Me.txtNombreAfp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreAfp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreAfp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombreAfp.Location = New System.Drawing.Point(59, 15)
        Me.txtNombreAfp.Name = "txtNombreAfp"
        Me.txtNombreAfp.ReadOnly = True
        Me.txtNombreAfp.Size = New System.Drawing.Size(339, 20)
        Me.txtNombreAfp.TabIndex = 297
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label28.Location = New System.Drawing.Point(6, 18)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(50, 13)
        Me.Label28.TabIndex = 282
        Me.Label28.Text = "Nombre"
        '
        'tpOtroEmpleador
        '
        Me.tpOtroEmpleador.Controls.Add(Me.UiGroupBox6)
        Me.tpOtroEmpleador.Controls.Add(Me.UiGroupBox5)
        Me.tpOtroEmpleador.Controls.Add(Me.UiGroupBox4)
        Me.tpOtroEmpleador.Icon = CType(resources.GetObject("tpOtroEmpleador.Icon"), System.Drawing.Icon)
        Me.tpOtroEmpleador.Location = New System.Drawing.Point(1, 23)
        Me.tpOtroEmpleador.Name = "tpOtroEmpleador"
        Me.tpOtroEmpleador.Size = New System.Drawing.Size(556, 464)
        Me.tpOtroEmpleador.TabStop = True
        Me.tpOtroEmpleador.Text = "OTRO EMPLEADOR"
        '
        'UiGroupBox6
        '
        Me.UiGroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox6.Controls.Add(Me.txtanioOtroSueldo)
        Me.UiGroupBox6.Controls.Add(Me.Label15)
        Me.UiGroupBox6.Controls.Add(Me.dgvOtrosSueldos)
        Me.UiGroupBox6.Icon = CType(resources.GetObject("UiGroupBox6.Icon"), System.Drawing.Icon)
        Me.UiGroupBox6.Location = New System.Drawing.Point(12, 208)
        Me.UiGroupBox6.Name = "UiGroupBox6"
        Me.UiGroupBox6.Size = New System.Drawing.Size(533, 253)
        Me.UiGroupBox6.TabIndex = 306
        Me.UiGroupBox6.Text = "SUELDOS"
        Me.UiGroupBox6.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox6.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtanioOtroSueldo
        '
        Me.txtanioOtroSueldo.Location = New System.Drawing.Point(253, 16)
        Me.txtanioOtroSueldo.Maximum = 2099
        Me.txtanioOtroSueldo.MaxLength = 4
        Me.txtanioOtroSueldo.Minimum = 2022
        Me.txtanioOtroSueldo.Name = "txtanioOtroSueldo"
        Me.txtanioOtroSueldo.Size = New System.Drawing.Size(49, 20)
        Me.txtanioOtroSueldo.TabIndex = 231
        Me.txtanioOtroSueldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.txtanioOtroSueldo.Value = 2022
        Me.txtanioOtroSueldo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(200, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 13)
        Me.Label15.TabIndex = 232
        Me.Label15.Text = "Periodo"
        '
        'dgvOtrosSueldos
        '
        Me.dgvOtrosSueldos.ContextMenuStrip = Me.cmOpcionesOtroSueldo
        dgvOtrosSueldos_DesignTimeLayout.LayoutString = resources.GetString("dgvOtrosSueldos_DesignTimeLayout.LayoutString")
        Me.dgvOtrosSueldos.DesignTimeLayout = dgvOtrosSueldos_DesignTimeLayout
        Me.dgvOtrosSueldos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvOtrosSueldos.GroupByBoxVisible = False
        Me.dgvOtrosSueldos.Location = New System.Drawing.Point(9, 38)
        Me.dgvOtrosSueldos.Name = "dgvOtrosSueldos"
        Me.dgvOtrosSueldos.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvOtrosSueldos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvOtrosSueldos.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvOtrosSueldos.Size = New System.Drawing.Size(515, 210)
        Me.dgvOtrosSueldos.TabIndex = 230
        Me.dgvOtrosSueldos.TabStop = False
        Me.dgvOtrosSueldos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesOtroSueldo
        '
        Me.cmOpcionesOtroSueldo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoOtroSueldo, Me.miMostraOtroSueldo, Me.miBorrarOtroSueldo, Me.ToolStripSeparator8, Me.miActualizarOtroSueldo})
        Me.cmOpcionesOtroSueldo.Name = "cmOpciones"
        Me.cmOpcionesOtroSueldo.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevoOtroSueldo
        '
        Me.miNuevoOtroSueldo.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoOtroSueldo.Name = "miNuevoOtroSueldo"
        Me.miNuevoOtroSueldo.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoOtroSueldo.Text = "Nuevo"
        Me.miNuevoOtroSueldo.ToolTipText = "Nuevo Empleador"
        '
        'miMostraOtroSueldo
        '
        Me.miMostraOtroSueldo.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostraOtroSueldo.Name = "miMostraOtroSueldo"
        Me.miMostraOtroSueldo.Size = New System.Drawing.Size(126, 22)
        Me.miMostraOtroSueldo.Text = "Mostrar"
        Me.miMostraOtroSueldo.ToolTipText = "Mostrar Empleador"
        '
        'miBorrarOtroSueldo
        '
        Me.miBorrarOtroSueldo.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miBorrarOtroSueldo.Name = "miBorrarOtroSueldo"
        Me.miBorrarOtroSueldo.Size = New System.Drawing.Size(126, 22)
        Me.miBorrarOtroSueldo.Text = "Eliminar"
        Me.miBorrarOtroSueldo.ToolTipText = "Eliminar Empleador"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarOtroSueldo
        '
        Me.miActualizarOtroSueldo.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarOtroSueldo.Name = "miActualizarOtroSueldo"
        Me.miActualizarOtroSueldo.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarOtroSueldo.Text = "Actualizar"
        Me.miActualizarOtroSueldo.ToolTipText = "Refrescar Lista de Empleadores"
        '
        'UiGroupBox5
        '
        Me.UiGroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox5.Controls.Add(Me.dgvOtroEmpleador)
        Me.UiGroupBox5.Icon = CType(resources.GetObject("UiGroupBox5.Icon"), System.Drawing.Icon)
        Me.UiGroupBox5.Location = New System.Drawing.Point(12, 78)
        Me.UiGroupBox5.Name = "UiGroupBox5"
        Me.UiGroupBox5.Size = New System.Drawing.Size(533, 121)
        Me.UiGroupBox5.TabIndex = 305
        Me.UiGroupBox5.Text = "EMPRESAS"
        Me.UiGroupBox5.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center
        Me.UiGroupBox5.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'dgvOtroEmpleador
        '
        Me.dgvOtroEmpleador.ContextMenuStrip = Me.cmOpcionesOtroEmpleador
        dgvOtroEmpleador_DesignTimeLayout.LayoutString = resources.GetString("dgvOtroEmpleador_DesignTimeLayout.LayoutString")
        Me.dgvOtroEmpleador.DesignTimeLayout = dgvOtroEmpleador_DesignTimeLayout
        Me.dgvOtroEmpleador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvOtroEmpleador.GroupByBoxVisible = False
        Me.dgvOtroEmpleador.Location = New System.Drawing.Point(9, 19)
        Me.dgvOtroEmpleador.Name = "dgvOtroEmpleador"
        Me.dgvOtroEmpleador.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvOtroEmpleador.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvOtroEmpleador.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvOtroEmpleador.Size = New System.Drawing.Size(515, 97)
        Me.dgvOtroEmpleador.TabIndex = 230
        Me.dgvOtroEmpleador.TabStop = False
        Me.dgvOtroEmpleador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesOtroEmpleador
        '
        Me.cmOpcionesOtroEmpleador.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoEmpleador, Me.miMostrarEmpleador, Me.miEliminarEmpleador, Me.ToolStripSeparator7, Me.miActualizarEmpleador})
        Me.cmOpcionesOtroEmpleador.Name = "cmOpciones"
        Me.cmOpcionesOtroEmpleador.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevoEmpleador
        '
        Me.miNuevoEmpleador.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoEmpleador.Name = "miNuevoEmpleador"
        Me.miNuevoEmpleador.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoEmpleador.Text = "Nuevo"
        Me.miNuevoEmpleador.ToolTipText = "Nuevo Empleador"
        '
        'miMostrarEmpleador
        '
        Me.miMostrarEmpleador.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarEmpleador.Name = "miMostrarEmpleador"
        Me.miMostrarEmpleador.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarEmpleador.Text = "Mostrar"
        Me.miMostrarEmpleador.ToolTipText = "Mostrar Empleador"
        '
        'miEliminarEmpleador
        '
        Me.miEliminarEmpleador.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarEmpleador.Name = "miEliminarEmpleador"
        Me.miEliminarEmpleador.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarEmpleador.Text = "Eliminar"
        Me.miEliminarEmpleador.ToolTipText = "Eliminar Empleador"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarEmpleador
        '
        Me.miActualizarEmpleador.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarEmpleador.Name = "miActualizarEmpleador"
        Me.miActualizarEmpleador.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarEmpleador.Text = "Actualizar"
        Me.miActualizarEmpleador.ToolTipText = "Refrescar Lista de Empleadores"
        '
        'UiGroupBox4
        '
        Me.UiGroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.UiGroupBox4.Controls.Add(Me.txtCentroOtro)
        Me.UiGroupBox4.Controls.Add(Me.Label12)
        Me.UiGroupBox4.Controls.Add(Me.txtAreaOtro)
        Me.UiGroupBox4.Controls.Add(Me.Label13)
        Me.UiGroupBox4.Controls.Add(Me.txtPersonaOtro)
        Me.UiGroupBox4.Controls.Add(Me.Label14)
        Me.UiGroupBox4.Location = New System.Drawing.Point(11, 4)
        Me.UiGroupBox4.Name = "UiGroupBox4"
        Me.UiGroupBox4.Size = New System.Drawing.Size(533, 70)
        Me.UiGroupBox4.TabIndex = 304
        Me.UiGroupBox4.Text = "Datos de Colaborador"
        Me.UiGroupBox4.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'txtCentroOtro
        '
        Me.txtCentroOtro.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCentroOtro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCentroOtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCentroOtro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCentroOtro.Location = New System.Drawing.Point(322, 42)
        Me.txtCentroOtro.Name = "txtCentroOtro"
        Me.txtCentroOtro.ReadOnly = True
        Me.txtCentroOtro.Size = New System.Drawing.Size(204, 20)
        Me.txtCentroOtro.TabIndex = 303
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(218, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 13)
        Me.Label12.TabIndex = 302
        Me.Label12.Text = "Centro de Costo"
        '
        'txtAreaOtro
        '
        Me.txtAreaOtro.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAreaOtro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAreaOtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAreaOtro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAreaOtro.Location = New System.Drawing.Point(65, 42)
        Me.txtAreaOtro.Name = "txtAreaOtro"
        Me.txtAreaOtro.ReadOnly = True
        Me.txtAreaOtro.Size = New System.Drawing.Size(145, 20)
        Me.txtAreaOtro.TabIndex = 299
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label13.Location = New System.Drawing.Point(9, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 298
        Me.Label13.Text = "Area"
        '
        'txtPersonaOtro
        '
        Me.txtPersonaOtro.BackColor = System.Drawing.Color.AliceBlue
        Me.txtPersonaOtro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersonaOtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonaOtro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPersonaOtro.Location = New System.Drawing.Point(65, 16)
        Me.txtPersonaOtro.Name = "txtPersonaOtro"
        Me.txtPersonaOtro.ReadOnly = True
        Me.txtPersonaOtro.Size = New System.Drawing.Size(339, 20)
        Me.txtPersonaOtro.TabIndex = 297
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label14.Location = New System.Drawing.Point(9, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 282
        Me.Label14.Text = "Nombre"
        '
        'tpDHMayores
        '
        Me.tpDHMayores.Controls.Add(Me.dgvDHMayores)
        Me.tpDHMayores.Icon = CType(resources.GetObject("tpDHMayores.Icon"), System.Drawing.Icon)
        Me.tpDHMayores.Location = New System.Drawing.Point(1, 23)
        Me.tpDHMayores.Name = "tpDHMayores"
        Me.tpDHMayores.Size = New System.Drawing.Size(556, 464)
        Me.tpDHMayores.TabStop = True
        Me.tpDHMayores.Text = "DERECHO HABIENTE MAYORES"
        '
        'dgvDHMayores
        '
        Me.dgvDHMayores.ContextMenuStrip = Me.cmOpcionesDHMayores
        dgvDHMayores_DesignTimeLayout.LayoutString = resources.GetString("dgvDHMayores_DesignTimeLayout.LayoutString")
        Me.dgvDHMayores.DesignTimeLayout = dgvDHMayores_DesignTimeLayout
        Me.dgvDHMayores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDHMayores.GroupByBoxVisible = False
        Me.dgvDHMayores.Location = New System.Drawing.Point(3, 20)
        Me.dgvDHMayores.Name = "dgvDHMayores"
        Me.dgvDHMayores.RowFormatStyle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.dgvDHMayores.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.dgvDHMayores.ScrollBars = Janus.Windows.GridEX.ScrollBars.Both
        Me.dgvDHMayores.Size = New System.Drawing.Size(550, 275)
        Me.dgvDHMayores.TabIndex = 231
        Me.dgvDHMayores.TabStop = False
        Me.dgvDHMayores.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmOpcionesDHMayores
        '
        Me.cmOpcionesDHMayores.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miNuevoDHMayor, Me.miMostrarDHMayor, Me.miEliminarDHMayor, Me.ToolStripSeparator9, Me.miActualizarDHMayor})
        Me.cmOpcionesDHMayores.Name = "cmOpciones"
        Me.cmOpcionesDHMayores.Size = New System.Drawing.Size(127, 98)
        '
        'miNuevoDHMayor
        '
        Me.miNuevoDHMayor.Image = Global.SIGECOM.My.Resources.Resources.Nuevo
        Me.miNuevoDHMayor.Name = "miNuevoDHMayor"
        Me.miNuevoDHMayor.Size = New System.Drawing.Size(126, 22)
        Me.miNuevoDHMayor.Text = "Nuevo"
        Me.miNuevoDHMayor.ToolTipText = "Nuevo Empleador"
        '
        'miMostrarDHMayor
        '
        Me.miMostrarDHMayor.Image = Global.SIGECOM.My.Resources.Resources.Seleccionar
        Me.miMostrarDHMayor.Name = "miMostrarDHMayor"
        Me.miMostrarDHMayor.Size = New System.Drawing.Size(126, 22)
        Me.miMostrarDHMayor.Text = "Mostrar"
        Me.miMostrarDHMayor.ToolTipText = "Mostrar Empleador"
        '
        'miEliminarDHMayor
        '
        Me.miEliminarDHMayor.Image = Global.SIGECOM.My.Resources.Resources.Eliminar
        Me.miEliminarDHMayor.Name = "miEliminarDHMayor"
        Me.miEliminarDHMayor.Size = New System.Drawing.Size(126, 22)
        Me.miEliminarDHMayor.Text = "Eliminar"
        Me.miEliminarDHMayor.ToolTipText = "Eliminar Empleador"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(123, 6)
        '
        'miActualizarDHMayor
        '
        Me.miActualizarDHMayor.Image = Global.SIGECOM.My.Resources.Resources.Actualizar
        Me.miActualizarDHMayor.Name = "miActualizarDHMayor"
        Me.miActualizarDHMayor.Size = New System.Drawing.Size(126, 22)
        Me.miActualizarDHMayor.Text = "Actualizar"
        Me.miActualizarDHMayor.ToolTipText = "Refrescar Lista de Empleadores"
        '
        'frmContratos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1039, 526)
        Me.Controls.Add(Me.gtPestanas)
        Me.Controls.Add(Me.ssBarra)
        Me.Controls.Add(Me.gbDatosBusqueda)
        Me.Controls.Add(Me.dgvDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContratos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contratos de Personal"
        CType(Me.ofEstiloForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbDatosBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosBusqueda.ResumeLayout(False)
        Me.gbDatosBusqueda.PerformLayout()
        CType(Me.cmbCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ssBarra.ResumeLayout(False)
        Me.ssBarra.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gtPestanas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gtPestanas.ResumeLayout(False)
        Me.tpContratos.ResumeLayout(False)
        CType(Me.UiGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox3.ResumeLayout(False)
        Me.UiGroupBox3.PerformLayout()
        CType(Me.cmbNoAporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox1.ResumeLayout(False)
        Me.UiGroupBox1.PerformLayout()
        CType(Me.gbDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.cmbModalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbVigencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbVigencia.ResumeLayout(False)
        Me.gbVigencia.PerformLayout()
        CType(Me.gbIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbIngresos.ResumeLayout(False)
        CType(Me.dgvIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesIngresos.ResumeLayout(False)
        CType(Me.gbAbono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAbono.ResumeLayout(False)
        Me.gbAbono.PerformLayout()
        CType(Me.cmbBancoAbono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCts.ResumeLayout(False)
        Me.gbCts.PerformLayout()
        CType(Me.cmbBancoCTS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMonedaCTS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPerContratos.ResumeLayout(False)
        CType(Me.UiGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox2.ResumeLayout(False)
        Me.UiGroupBox2.PerformLayout()
        CType(Me.gbContratoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbContratoDetalle.ResumeLayout(False)
        CType(Me.dgvPeriodoContrato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesPerContrato.ResumeLayout(False)
        Me.tpAumentosMovAFPs.ResumeLayout(False)
        CType(Me.gbAumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAumentos.ResumeLayout(False)
        CType(Me.dgvAumentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesAumentos.ResumeLayout(False)
        CType(Me.gbDetallesFP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetallesFP.ResumeLayout(False)
        CType(Me.dgvAfps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesAfp.ResumeLayout(False)
        CType(Me.gbDatosAfp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatosAfp.ResumeLayout(False)
        Me.gbDatosAfp.PerformLayout()
        Me.tpOtroEmpleador.ResumeLayout(False)
        CType(Me.UiGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox6.ResumeLayout(False)
        Me.UiGroupBox6.PerformLayout()
        CType(Me.dgvOtrosSueldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesOtroSueldo.ResumeLayout(False)
        CType(Me.UiGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox5.ResumeLayout(False)
        CType(Me.dgvOtroEmpleador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesOtroEmpleador.ResumeLayout(False)
        CType(Me.UiGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiGroupBox4.ResumeLayout(False)
        Me.UiGroupBox4.PerformLayout()
        Me.tpDHMayores.ResumeLayout(False)
        CType(Me.dgvDHMayores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmOpcionesDHMayores.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ofEstiloForm As Janus.Windows.Ribbon.OfficeFormAdorner
    Friend WithEvents gbDatosBusqueda As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ssBarra As System.Windows.Forms.StatusStrip
    Friend WithEvents sslError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents sslTotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbCodArea As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As Janus.Windows.GridEX.GridEX
    Friend WithEvents gtPestanas As Janus.Windows.UI.Tab.UITab
    Friend WithEvents tpContratos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents tpAumentosMovAFPs As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents gbAbono As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbCts As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvAfps As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtAreaAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtNombreAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents gbDetallesFP As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbDatosAfp As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmOpcionesIngresos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbIngresos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvIngresos As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbDatos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbVigencia As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtFecFinal As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents txtFecInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtTotalIngresos As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtNumCuentaCTS As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbMonedaCTS As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cmbBancoCTS As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents cmbModalidad As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cmbBancoAbono As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents txtNumCuentaAbono As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtMovilidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtNumSeguro As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmOpcionesAfp As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoAFP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarAFP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarAFP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarAFP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDeshacer As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents gbAumentos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvAumentos As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpcionesAumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoAumento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarAumento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarAumento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarAumento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UiGroupBox1 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtAreaContrato As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombreContrato As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tpPerContratos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents gbContratoDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvPeriodoContrato As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox2 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtAreaPerContrato As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNombrePerContrato As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmOpcionesPerContrato As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents miNuevoPerContrato As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miMostrarPerContrato As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miEliminarPerContrato As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miActualizarPerContrato As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbCentroCosto As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtcentroCostoContrato As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCentroCostoPerContrato As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCentroCostoAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbVigente As System.Windows.Forms.CheckBox
    Friend WithEvents cbSaludVida As System.Windows.Forms.CheckBox
    Friend WithEvents cbAsignacionFamiliar As System.Windows.Forms.CheckBox
    Friend WithEvents cbJubilacion As CheckBox
    Friend WithEvents UiGroupBox3 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cmbNoAporte As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Label11 As Label
    Friend WithEvents cbSCTR As CheckBox
    Friend WithEvents cbEPS As CheckBox
    Friend WithEvents tpOtroEmpleador As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiGroupBox5 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvOtroEmpleador As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiGroupBox4 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents txtCentroOtro As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtAreaOtro As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtPersonaOtro As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmOpcionesOtroEmpleador As ContextMenuStrip
    Friend WithEvents miNuevoEmpleador As ToolStripMenuItem
    Friend WithEvents miMostrarEmpleador As ToolStripMenuItem
    Friend WithEvents miEliminarEmpleador As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents miActualizarEmpleador As ToolStripMenuItem
    Friend WithEvents UiGroupBox6 As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents dgvOtrosSueldos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtanioOtroSueldo As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label15 As Label
    Friend WithEvents cmOpcionesOtroSueldo As ContextMenuStrip
    Friend WithEvents miNuevoOtroSueldo As ToolStripMenuItem
    Friend WithEvents miMostraOtroSueldo As ToolStripMenuItem
    Friend WithEvents miBorrarOtroSueldo As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents miActualizarOtroSueldo As ToolStripMenuItem
    Friend WithEvents txtMontoEPS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCantidadDH As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents tpDHMayores As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents dgvDHMayores As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmOpcionesDHMayores As ContextMenuStrip
    Friend WithEvents miNuevoDHMayor As ToolStripMenuItem
    Friend WithEvents miMostrarDHMayor As ToolStripMenuItem
    Friend WithEvents miEliminarDHMayor As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents miActualizarDHMayor As ToolStripMenuItem
End Class
